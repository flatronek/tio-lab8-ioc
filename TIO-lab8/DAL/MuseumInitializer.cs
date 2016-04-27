using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TIO_lab8.Models;

namespace TIO_lab8.DAL
{
    public class MuseumInitializer : System.Data.Entity.DropCreateDatabaseAlways<MuseumContext>
    {
        protected override void Seed(MuseumContext context)
        {
            var paintings = new List<Painting>
            {
                new Painting() { Id = 1, Title = "Book1", Year = 10 },
                new Painting() { Id = 2, Title = "Book2", Year = 20 }
            };
            context.Paintings.AddRange(paintings);
            context.SaveChanges();

            var authors = new List<Author>
            {
                new Author() { Id = 1, Name = "Name1", Surname = "Surname1" },
                new Author() { Id = 2, Name = "name2", Surname = "surname2" }
            };
            context.Authors.AddRange(authors);
            context.SaveChanges();
        }
    }
}