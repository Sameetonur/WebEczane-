using EczaneApp.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EczaneApp.DataAccessLayer.Abstract
{
    public interface IIlacRepository : IRepository<Ilac>
    {
        IEnumerable<Ilac> GetWithAllKategori();
    }
}
