using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TIO_lab8.Models;

namespace TIO_lab8.DBInterfaces
{
    public interface IPaintingsRepository
    {
        int Add(Painting painting);

        bool Delete(int id);

        Painting Get(int id);

        List<Painting> GetAll();

        Painting Update(Painting painting);
    }
}
