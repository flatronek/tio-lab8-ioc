using TIO_lab8.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TIO_lab8.DBInterfaces;
using TIO_lab8.Models;

namespace TIO_lab8.Controllers
{
    public class PaintingsController : ApiController
    {
        private IPaintingsRepository paintingsRepository;
        private ILogger logger;

        public PaintingsController(IPaintingsRepository paintingsRepository, ILogger logger)
        {
            this.paintingsRepository = paintingsRepository;
            this.logger = logger;
        }

        // GET: api/Paintings
        public IEnumerable<Painting> Get()
        {
            logger.Write("GET for paintings", LogLevel.INFO);
            return paintingsRepository.GetAll();
        }

        // GET: api/Paintings/5
        public Painting Get(int id)
        {
            logger.Write("GET for paintings with id " + id, LogLevel.INFO);
            return paintingsRepository.Get(id);
        }

        // POST: api/Paintings
        public int Post([FromBody]Painting value)
        {
            logger.Write("POST for paintings", LogLevel.INFO);
            if (value == null)
                return 0;
            
            return paintingsRepository.Add(value);
        }

        // PUT: api/Paintings/5
        public void Put(int id, [FromBody]Painting value)
        {
            logger.Write("PUT for paintings with id " + id, LogLevel.INFO);
       
            value.Id = id;

            paintingsRepository.Update(value);
        }

        // DELETE: api/Paintings/5
        public void Delete(int id)
        {
            logger.Write("DELETE for paintings", LogLevel.INFO);
            paintingsRepository.Delete(id);
        }
    }
}
