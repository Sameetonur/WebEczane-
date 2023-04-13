using EczaneApp.DataAccessLayer;
using EczaneApp.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EczaneApp.BusinnessLayer
{
    public class PersonelManager : IDisposable
    {
        private UnitOfWork uow;
        public PersonelManager()
        {
            uow = new UnitOfWork();
        }
        public List<Personel> Listele()
        {
            return uow.PersonelRepo.GetAll().ToList();
        }
        public int Ekle(Personel personel)
        {
            uow.PersonelRepo.Add(personel);
            return uow.Save();
        }
        public int Sil(Personel personel)
        {
            uow.PersonelRepo.Remove(personel);
            return uow.Save();
        }
        public int Sil(int id)
        {
            uow.PersonelRepo.Remove(id);
            return uow.Save();
        }
        public int Guncelle(Personel personel)
        {
            uow.PersonelRepo.Update(personel);
            return uow.Save();
        }
        public void Dispose()
        {
            uow?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
