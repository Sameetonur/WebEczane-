using EczaneApp.DataAccessLayer;
using EczaneApp.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EczaneApp.BusinnessLayer
{
    public class MusteriManager : IDisposable
    {
        private UnitOfWork uow;
        public MusteriManager()
        {
            uow = new UnitOfWork();
        }
        public List<Musteri> Listele()
        {
            return uow.MusteriRepo.GetAll().ToList();
        }
        public int Ekle(Musteri musteri)
        {
            uow.MusteriRepo.Add(musteri);
            return uow.Save();
        }
        public int Sil(Musteri musteri)
        {
            uow.MusteriRepo.Remove(musteri);
            return uow.Save();
        }
        public int Sil(int id)
        {
            uow.MusteriRepo.Remove(id);
            return uow.Save();
        }
        public int Guncelle(Musteri musteri)
        {
            uow.MusteriRepo.Update(musteri);
            return uow.Save();
        }
        public void Dispose()
        {
            uow?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
