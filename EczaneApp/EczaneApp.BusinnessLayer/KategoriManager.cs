using EczaneApp.DataAccessLayer;
using EczaneApp.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EczaneApp.BusinnessLayer
{
    public class KategoriManager : IDisposable
    {
        private UnitOfWork uow;
        public KategoriManager()
        {
            uow = new UnitOfWork();
        }
        public List<Kategori> Listele()
        {
            return uow.KategoriRepo.GetAll().ToList();
        }
        public int Ekle(Kategori kategori)
        {
            uow.KategoriRepo.Add(kategori);
            return uow.Save();
        }
        public int Sil(Kategori kategori)
        {
            uow.KategoriRepo.Remove(kategori);
            return uow.Save();
        }
        public int Sil(int id)
        {
            uow.KategoriRepo.Remove(id);
            return uow.Save();
        }
        public int Guncelle(Kategori kategori)
        {
            uow.KategoriRepo.Update(kategori);
            return uow.Save();
        }
        public void Dispose()
        {
            uow?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
