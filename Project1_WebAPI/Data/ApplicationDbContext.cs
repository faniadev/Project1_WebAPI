using System;
using Microsoft.EntityFrameworkCore;
using Project1_WebAPI.Models;

namespace Project1_WebAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Course> Courses { get; set; }
    }
}

