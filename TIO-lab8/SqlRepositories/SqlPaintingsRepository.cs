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
    public class SqlPaintingsRepository : IPaintingsRepository
    {
        private MuseumContext db = new MuseumContext();

        public int Add(Painting painting)
        {
            db.Paintings.Add(painting);
            db.SaveChanges();

            return painting.Id;
        }

        public bool Delete(int id)
        {
            Painting painting = db.Paintings.Find(id);
            if (painting == null)
            {
                return false;
            }

            db.Paintings.Remove(painting);
            db.SaveChanges();

            return true;
        }

        public Painting Get(int id)
        {
            Painting painting = db.Paintings.Find(id);

            return painting;
        }

        public List<Painting> GetAll()
        {
            return db.Paintings.ToList();
        }

        public Painting Update(Painting painting)
        {
            db.Entry(painting).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
                return painting;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaintingExists(painting.Id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }
        }

        private bool PaintingExists(int id)
        {
            return db.Paintings.Count(e => e.Id == id) > 0;
        }
    }
}