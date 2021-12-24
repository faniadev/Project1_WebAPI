using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Project1_WebAPI.Data;
using Project1_WebAPI.Models;

namespace Project1_WebAPI.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Authors.Any())
            {
                return;
            }

            var authors = new Author[]
            {
                new Author{FirstName="Andrew",LastName="Hunt",DateOfBirth=DateTimeOffset.Parse("1989-04-12"),MainCategory="abcdefghij"},
                new Author{FirstName="Harold",LastName="Abelson",DateOfBirth=DateTimeOffset.Parse("1990-11-09"),MainCategory="abcdefghij"},
                new Author{FirstName="Steve",LastName="McConnel",DateOfBirth=DateTimeOffset.Parse("1978-12-12"),MainCategory="abcdefghij"}
            };

            foreach (var a in authors)
            {
                context.Authors.Add(a);
            }

            context.SaveChanges();

            var courses = new Course[]
            {
                new Course{Title="The Pragmatic Programmer",Description="This book is..."},
                new Course{Title="Structure and Interpretation of Computer Programs",Description="This book is..."},
                new Course{Title="Code Complete: A Practical Handbook of Software Construction",Description="This book is..." }
            };

            foreach (var c in courses)
            {
                context.Courses.Add(c);
            }

            context.SaveChanges();
        }
    }
}
