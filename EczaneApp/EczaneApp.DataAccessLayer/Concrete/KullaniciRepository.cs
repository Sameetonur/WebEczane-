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
    public class KullaniciRepository : Repository<Kullanici>, IKullaniciRepository
    {
        public KullaniciRepository(DbContext context) : base(context)
        {
        }

        public IEnumerable<Kullanici> GetAllWithPersonel()
        {
            return context.Set<Kullanici>().Include(x => x.Personel).ToList();
        }

        public Kullanici GetItemWithPersonel(string ad)
        {
            return context.Set<Kullanici>().Include(x => x.Personel).FirstOrDefault(x => x.Ad.Equals(ad));
        }

        public bool Login(string ad, string sifre)
        {
            return context.Set<Kullanici>().FirstOrDefault(x => x.Ad.Equals(ad) && x.Sifre.Equals(sifre)) != null;
        }
    }
}
