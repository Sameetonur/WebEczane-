using EczaneApp.DataAccessLayer;
using EczaneApp.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EczaneApp.BusinnessLayer
{
    public class IlacManager : IDisposable
    {
        private UnitOfWork uow;
        public IlacManager()
        {
            uow = new UnitOfWork();
        }
        public List<Ilac> Listele()
        {
            return uow.IlacRepo.GetWithAllKategori().ToList();
        }
        public int Ekle(Ilac ilac)
        {
            int durum = 0;
            if (uow.IlacRepo.GetAll().FirstOrDefault(x => x.Ad == ilac.Ad) != null && uow.IlacRepo.GetAll().FirstOrDefault(x => x.SKT == ilac.SKT) != null)
            {
                Ilac yeniIlac;
                yeniIlac = uow.IlacRepo.GetAll().FirstOrDefault(x => x.Ad == ilac.Ad && x.SKT == ilac.SKT);
                yeniIlac.Adet += ilac.Adet;
                uow.IlacRepo.Update(yeniIlac);
                durum = 1;
            }
            else uow.IlacRepo.Add(ilac);
            uow.Save();
            return durum;
        }
        public int Sil(Ilac ilac)
        {
            uow.IlacRepo.Remove(ilac);
            return uow.Save();
        }
        public int Sil(int id)
        {
            uow.IlacRepo.Remove(id);
            return uow.Save();
        }
        public int Guncelle(Ilac ilac)
        {
            uow.IlacRepo.Update(ilac);
            return uow.Save();
        }
        public void Dispose()
        {
            uow?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
