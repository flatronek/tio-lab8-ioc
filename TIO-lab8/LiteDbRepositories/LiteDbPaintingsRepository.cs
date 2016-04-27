using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TIO_lab8.DBInterfaces;
using TIO_lab8.Models;

namespace TIO_lab8.LiteDbRepositories
{
    public class LiteDbPaintingsRepository : IPaintingsRepository
    {
        private readonly string _databaseConnection = DatabaseConnections.PaintingsConnection;
        private readonly string _collectionName = "paintings";

        public int Add(Painting painting)
        {
            using (var db = new LiteDatabase(_databaseConnection))
            {
                var repository = db.GetCollection<Painting>(_collectionName);

                if (repository.FindById(painting.Id) != null)
                    repository.Update(painting);
                else
                    repository.Insert(painting);

                return painting.Id;
            }
        }

        public bool Delete(int id)
        {
            using (var db = new LiteDatabase(_databaseConnection))
            {
                var repository = db.GetCollection<Painting>(_collectionName);

                return repository.Delete(id);
            }
        }

        public Painting Get(int id)
        {
            using (var db = new LiteDatabase(_databaseConnection))
            {
                var repository = db.GetCollection<Painting>(_collectionName);

                return repository.FindById(id);
            }
        }

        public List<Painting> GetAll()
        {
            using (var db = new LiteDatabase(_databaseConnection))
            {
                return db.GetCollection<Painting>(_collectionName).FindAll().ToList();
            }
        }

        public Painting Update(Painting painting)
        {
            using (var db = new LiteDatabase(_databaseConnection))
            {
                var repository = db.GetCollection<Painting>(_collectionName);

                if (repository.Update(painting))
                    return painting;
                else
                    return null;
            }
        }
    }
}