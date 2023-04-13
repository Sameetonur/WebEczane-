using EczaneApp.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EczaneApp.DataAccessLayer.Abstract
{
    public interface IKullaniciRepository : IRepository<Kullanici>
    {
        bool Login(string ad, string sifre);
        IEnumerable<Kullanici> GetAllWithPersonel();
        Kullanici GetItemWithPersonel(string ad);
    }
}
