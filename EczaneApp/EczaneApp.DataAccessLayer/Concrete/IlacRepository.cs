using EczaneApp.DataAccessLayer.Abstract;
using EczaneApp.EntityLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EczaneApp.DataAccessLayer.Concrete
{
    public class IlacRepository : Repository<Ilac>, IIlacRepository
    {
        public IlacRepository(DbContext context) : base(context)
        {
        }

        public IEnumerable<Ilac> GetWithAllKategori()
        {
            return context.Set<Ilac>().Include(x => x.Kategori).ToList();
        }
    }
}
