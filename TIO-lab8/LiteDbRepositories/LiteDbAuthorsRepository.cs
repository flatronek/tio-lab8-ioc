using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TIO_lab8.DBInterfaces;
using TIO_lab8.Models;

namespace TIO_lab8.LiteDbRepositories
{
    public class LiteDbAuthorsRepository : IAuthorsRepository
    {
        private readonly string _databaseConnection = DatabaseConnections.AuthorsConnection;
        private readonly string _collectionName = "authors";

        public int Add(Author author)
        {
            using (var db = new LiteDatabase(_databaseConnection))
            {
                var repository = db.GetCollection<Author>(_collectionName);

                if (repository.FindById(author.Id) != null)
                    repository.Update(author);
                else
                    repository.Insert(author);

                return author.Id;
            }
        }

        public bool Delete(int id)
        {
            using (var db = new LiteDatabase(_databaseConnection))
            {
                var repository = db.GetCollection<Author>(_collectionName);

                return repository.Delete(id);
            }
        }

        public Author Get(int id)
        {
            using (var db = new LiteDatabase(_databaseConnection))
            {
                var repository = db.GetCollection<Author>(_collectionName);

                return repository.FindById(id);
            }
        }

        public List<Author> GetAll()
        {
            using (var db = new LiteDatabase(_databaseConnection))
            {
                return db.GetCollection<Author>(_collectionName).FindAll().ToList();
            }
        }

        public Author Update(Author review)
        {
            using (var db = new LiteDatabase(_databaseConnection))
            {
                var repository = db.GetCollection<Author>(_collectionName);

                if (repository.Update(review))
                    return review;
                else
                    return null;
            }
        }
    }
}