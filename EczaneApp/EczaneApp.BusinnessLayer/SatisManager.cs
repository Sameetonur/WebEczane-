using EczaneApp.DataAccessLayer;
using EczaneApp.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EczaneApp.BusinnessLayer
{
    public class SatisManager : IDisposable
    {
        private UnitOfWork uow;
        public SatisManager()
        {
            uow = new UnitOfWork();
        }
        public List<Satis> Listele()
        {
            return uow.SatisRepo.GetWithAllDetays().ToList();
        }
        public int Ekle(Satis satis)
        {
            foreach (var detay in satis.SatisDetaylar)
            {
                Ilac ilac = uow.IlacRepo.GetItem(detay.IlacId);
                ilac.Adet -= detay.Adet;
                uow.IlacRepo.Update(ilac);
            }
            uow.SatisRepo.Add(satis);
            return uow.Save();
        }
        public int Sil(Satis satis)
        {
            uow.SatisRepo.Remove(satis);
            return uow.Save();
        }
        public int Sil(int id)
        {
            uow.SatisRepo.Remove(id);
            return uow.Save();
        }
        public void Dispose()
        {
            uow?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
