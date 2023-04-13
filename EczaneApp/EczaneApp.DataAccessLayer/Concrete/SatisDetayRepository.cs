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
    public class SatisDetayRepository : Repository<SatisDetay>, ISatisDetayRepository
    {
        public SatisDetayRepository(DbContext context) : base(context)
        {
        }

        public IEnumerable<SatisDetay> GetWithAllDetays()
        {
            return context.Set<SatisDetay>().Include(x => x.Ilac).ToList();
        }
    }
}
