using EczaneApp.DataAccessLayer;
using EczaneApp.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EczaneApp.BusinnessLayer
{
    public class SatisDetaylarManager : IDisposable
    {
        private UnitOfWork uow;
        public SatisDetaylarManager()
        {
            uow = new UnitOfWork();
        }
        public List<SatisDetay> Listele()
        {
            return uow.SatisDetayRepo.GetWithAllDetays().ToList();
        }
        public List<SatisDetay> GetDetay(int i)
        {
            return uow.SatisDetayRepo.GetWithAllDetays().Where(x => x.SatisId == i).ToList();
        }
        public void Dispose()
        {
            uow?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
