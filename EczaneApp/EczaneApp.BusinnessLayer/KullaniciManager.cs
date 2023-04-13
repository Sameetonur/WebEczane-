using EczaneApp.DataAccessLayer;
using EczaneApp.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EczaneApp.BusinnessLayer
{
    public class KullaniciManager : IDisposable
    {
        private UnitOfWork uow;
        public KullaniciManager()
        {
            uow = new UnitOfWork();
        }
        public Kullanici kullaniciGetir(string ad)
        {
            return uow.KullaniciRepo.GetItemWithPersonel(ad);
        }
        public bool GirisYap(string ad, string sifre)
        {
            return uow.KullaniciRepo.Login(ad, sifre);
        }
        public List<Kullanici> Listele()
        {
            return uow.KullaniciRepo.GetAllWithPersonel().ToList();
        }
        public int Ekle(Kullanici kullanici)
        {
            if (uow.KullaniciRepo.GetAll().FirstOrDefault(x => x.Ad == kullanici.Ad) != null)
                throw new Exception(kullanici.Ad + " adında bir kayıt mevcut.");

            uow.KullaniciRepo.Add(kullanici);
            return uow.Save();
        }
        public int Sil(Kullanici kullanici)
        {
            uow.KullaniciRepo.Remove(kullanici);
            return uow.Save();
        }
        public int Sil(int id)
        {
            uow.KullaniciRepo.Remove(id);
            return uow.Save();
        }
        public int Guncelle(Kullanici kullanici)
        {
            uow.KullaniciRepo.Update(kullanici);
            return uow.Save();
        }
        public void Dispose()
        {
            uow?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
