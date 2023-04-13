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
    public class SatisRepository : Repository<Satis>, ISatisRepository
    {
        public SatisRepository(DbContext context) : base(context)
        {
        }

        public IEnumerable<Satis> GetWithAllDetays()
        {
            return context.Set<Satis>().Include(x => x.Musteri).Include(x => x.Personel).ToList();
        }
    }
}
