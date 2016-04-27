using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TIO_lab8.DBInterfaces;
using TIO_lab8.Models;
using TIO_lab8.Logger;

namespace TIO_lab8.Controllers
{
    public class AuthorsController : ApiController
    {
        private IAuthorsRepository authorsRepository;
        private ILogger logger;

        public AuthorsController(IAuthorsRepository authorsRepository, ILogger logger)
        {
            this.authorsRepository = authorsRepository;
            this.logger = logger;
        }

        // GET: api/Authors
        public IEnumerable<Author> Get()
        {
            logger.Write("GET for authors", LogLevel.INFO);
            return authorsRepository.GetAll();
        }

        // GET: api/Authors/5
        public Author Get(int id)
        {
            return authorsRepository.Get(id);
        }

        // POST: api/Authors
        public int Post([FromBody]Author value)
        {
            return authorsRepository.Add(value);
        }

        // PUT: api/Authors/5
        public void Put(int id, [FromBody]Author value)
        {
            value.Id = id;

            authorsRepository.Update(value);
        }

        // DELETE: api/Authors/5
        public void Delete(int id)
        {
            authorsRepository.Delete(id);
        }
    }
}
