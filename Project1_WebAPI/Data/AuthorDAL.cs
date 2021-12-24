using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Project1_WebAPI.Models;

namespace Project1_WebAPI.Data
{
    public class AuthorDAL : IAuthor
    {
        private ApplicationDbContext _db;

        public AuthorDAL(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task Delete(string id)
        {
            var result = await GetById(id);
            if (result == null) throw new Exception("Data tidak ditemukan !");
            try
            {
                _db.Authors.Remove(result);
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateException dbEx)
            {
                throw new Exception($"Error: {dbEx.Message}");
            }
        }

        public async Task<IEnumerable<Author>> GetAll()
        {
            var results = await(from a in _db.Authors
                                orderby a.FirstName ascending
                                select a).ToListAsync();
            return results;
        }

        public async Task<Author> GetById(string id)
        {
            var result = await _db.Authors.Where(a => a.ID == Convert.ToInt32(id)).SingleOrDefaultAsync<Author>();
            if (result != null)
                return result;
            else
                throw new Exception("Data tidak ditemukan !");
        }

        public Task<IEnumerable<Author>> GetByName(string title)
        {
            throw new NotImplementedException();
        }

        public async Task<Author> Insert(Author obj)
        {
            try
            {
                _db.Authors.Add(obj);
                await _db.SaveChangesAsync();
                return obj;
            }
            catch (DbUpdateException dbEx)
            {
                throw new Exception($"Error: {dbEx.Message}");
            }
        }

        public async Task<Author> Update(string id, Author obj)
        {
            try
            {
                var result = await GetById(id);
                result.FirstName = obj.FirstName;
                result.LastName = obj.LastName;
                result.DateOfBirth = obj.DateOfBirth;
                await _db.SaveChangesAsync();
                obj.ID = Convert.ToInt32(id);
                return obj;
            }
            catch (DbUpdateException dbEx)
            {
                throw new Exception($"Error: {dbEx.Message}");
            }
        }

    }
}
