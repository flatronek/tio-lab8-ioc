using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TIO_lab8.Models;

namespace TIO_lab8.DBInterfaces
{
    public interface IAuthorsRepository
    {
        int Add(Author author);
        bool Delete(int id);
        Author Get(int id);
        List<Author> GetAll();
        Author Update(Author author);
    }
}
