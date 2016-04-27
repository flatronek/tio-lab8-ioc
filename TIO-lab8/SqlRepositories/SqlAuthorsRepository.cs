using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using TIO_lab8.DAL;
using TIO_lab8.DBInterfaces;
using TIO_lab8.Models;

namespace TIO_lab8.SqlRepositories
{
    public class SqlAuthorsRepository : IAuthorsRepository
    {
        private MuseumContext db = new MuseumContext();

        public int Add(Author author)
        {
            db.Authors.Add(author);
            db.SaveChanges();

            return author.Id;
        }

        public bool Delete(int id)
        {
            Author author = db.Authors.Find(id);
            if (author == null)
            {
                return false;
            }

            db.Authors.Remove(author);
            db.SaveChanges();

            return true;
        }

        public Author Get(int id)
        {
            Author author = db.Authors.Find(id);

            return author;
        }

        public List<Author> GetAll()
        {
            return db.Authors.ToList();
        }

        public Author Update(Author author)
        {
            db.Entry(author).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
                return author;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AuthorExists(author.Id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }
        }

        private bool AuthorExists(int id)
        {
            return db.Authors.Count(e => e.Id == id) > 0;
        }
    }
}