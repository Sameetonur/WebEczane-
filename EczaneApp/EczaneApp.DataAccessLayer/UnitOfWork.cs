using EczaneApp.DataAccessLayer.Concrete;
using EczaneApp.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EczaneApp.DataAccessLayer
{
    public class UnitOfWork : IDisposable
    {
        private DatabaseContext context;

        private Repository<Personel> _personelRepo;
        private KullaniciRepository _kullaniciRepo;
        private Repository<Musteri> _musteriRepo;
        private IlacRepository _ilacRepo;
        private Repository<Kategori> _kategoriRepo;
        private SatisRepository _satisRepo;
        private SatisDetayRepository _satisDetayRepo;

        public Repository<Personel> PersonelRepo
        {
            get
            {
                if (_personelRepo == null)
                    _personelRepo = new Repository<Personel>(context);
                return _personelRepo;
            }
        }
        public KullaniciRepository KullaniciRepo
        {
            get
            {
                if (_kullaniciRepo == null)
                    _kullaniciRepo = new KullaniciRepository(context);
                return _kullaniciRepo;
            }
        }
        public Repository<Musteri> MusteriRepo
        {
            get
            {
                if (_musteriRepo == null)
                    _musteriRepo = new Repository<Musteri>(context);
                return _musteriRepo;
            }
        }
        public IlacRepository IlacRepo
        {
            get
            {
                if (_ilacRepo == null)
                    _ilacRepo = new IlacRepository(context);
                return _ilacRepo;
            }
        }
        public Repository<Kategori> KategoriRepo
        {
            get
            {
                if (_kategoriRepo == null)
                    _kategoriRepo = new Repository<Kategori>(context);
                return _kategoriRepo;
            }
        }
        public SatisRepository SatisRepo
        {
            get
            {
                if (_satisRepo == null)
                    _satisRepo = new SatisRepository(context);
                return _satisRepo;
            }
        }
        public SatisDetayRepository SatisDetayRepo
        {
            get
            {
                if (_satisDetayRepo == null)
                    _satisDetayRepo = new SatisDetayRepository(context);
                return _satisDetayRepo;
            }
        }

        public UnitOfWork()
        {
            context = new DatabaseContext();
        }
        public int Save()
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    int i = context.SaveChanges();
                    transaction.Commit();
                    return i;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
            }
        }

        public void Dispose()
        {
            _personelRepo?.Dispose();
            _kullaniciRepo?.Dispose();
            _musteriRepo?.Dispose();
            _ilacRepo?.Dispose();
            _kategoriRepo?.Dispose();
            _satisRepo?.Dispose();
            _satisDetayRepo?.Dispose();
            context?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
