using EczaneApp.EntityLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EczaneApp.DataAccessLayer
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Personel> Personeller { get; set; }
        public DbSet<Kullanici> Kullanicilar { get; set; }
        public DbSet<Ilac> Ilaclar { get; set; }
        public DbSet<Kategori> Kategoriler { get; set; }
        public DbSet<Musteri> Musteriler { get; set; }
        public DbSet<Satis> Satislar { get; set; }
        public DbSet<SatisDetay> SatisDetaylar { get; set; }
        public DatabaseContext() : base("name=EczaneAppDB_ConnStr")
        {
            Database.SetInitializer<DatabaseContext>(new MyInitialize());
        }
        public class MyInitialize : CreateDatabaseIfNotExists<DatabaseContext>
        {
            protected override void Seed(DatabaseContext context)
            {
                base.Seed(context);

                Kategori kat1 = context.Kategoriler.Add(new Kategori { Ad = "Tablet" });
                Kategori kat2 = context.Kategoriler.Add(new Kategori { Ad = "Efervesan Tablet" });
                Kategori kat3 = context.Kategoriler.Add(new Kategori { Ad = "Kapsül" });
                Kategori kat4 = context.Kategoriler.Add(new Kategori { Ad = "Flakon" });
                Kategori kat5 = context.Kategoriler.Add(new Kategori { Ad = "Ampul" });
                Kategori kat6 = context.Kategoriler.Add(new Kategori { Ad = "Krem" });
                Kategori kat7 = context.Kategoriler.Add(new Kategori { Ad = "Merhem" });
                Kategori kat8 = context.Kategoriler.Add(new Kategori { Ad = "Şampuan" });
                Kategori kat9 = context.Kategoriler.Add(new Kategori { Ad = "Transdermal Sistem" });
                Kategori kat10 = context.Kategoriler.Add(new Kategori { Ad = "İnhaler Sistem" });
                Kategori kat11 = context.Kategoriler.Add(new Kategori { Ad = "Şurup" });
                Kategori kat12 = context.Kategoriler.Add(new Kategori { Ad = "Fitil" });
                Kategori kat13 = context.Kategoriler.Add(new Kategori { Ad = "Losyon" });
                Kategori kat14 = context.Kategoriler.Add(new Kategori { Ad = "Damla" });
                Kategori kat15 = context.Kategoriler.Add(new Kategori { Ad = "Sprey" });


                Musteri mus1 = context.Musteriler.Add(new Musteri { Ad = "Enes", Soyad = "Taşdemir", TC = "11111111111", DogumTarih = DateTime.Now });
                Musteri mus2 = context.Musteriler.Add(new Musteri { Ad = "Namık", Soyad = "Kemal", TC = "15682349756", DogumTarih = DateTime.Now });
                Musteri mus3 = context.Musteriler.Add(new Musteri { Ad = "Turgut", Soyad = "Pala", TC = "12385459753", DogumTarih = DateTime.Now });
                Musteri mus4 = context.Musteriler.Add(new Musteri { Ad = "Ferit", Soyad = "Taş", TC = "74968512485", DogumTarih = DateTime.Now });
                Musteri mus5 = context.Musteriler.Add(new Musteri { Ad = "Kartal", Soyad = "Delen", TC = "84591216377", DogumTarih = DateTime.Now });

                Personel per1 = context.Personeller.Add(new Personel { Ad = "Enes", Soyad = "TAŞDEMİR", TC = "19015927499", DogumTarih = DateTime.Now });
                Personel per2 = context.Personeller.Add(new Personel { Ad = "Samet", Soyad = "ÖNÜR", TC = "46874367811", DogumTarih = DateTime.Now });
                Personel per3 = context.Personeller.Add(new Personel { Ad = "Mert Ali", Soyad = "TUNÇ", TC = "46874367811", DogumTarih = DateTime.Now });
                Personel per4 = context.Personeller.Add(new Personel { Ad = "Ali Osman", Soyad = "KAYA", TC = "19485326788", DogumTarih = DateTime.Now });
                Personel per5 = context.Personeller.Add(new Personel { Ad = "Yasin", Soyad = "Kalaycı", TC = "84591216377", DogumTarih = DateTime.Now });

                Kullanici kul1 = context.Kullanicilar.Add(new Kullanici { Ad = "enes", Sifre = "12345678", Yetki = Yetkiler.Admin, Personel = per1 });
                Kullanici kul2 = context.Kullanicilar.Add(new Kullanici { Ad = "samet", Sifre= "12345678", Yetki = Yetkiler.Kullanıcı, Personel = per2 });
                Kullanici kul3 = context.Kullanicilar.Add(new Kullanici { Ad = "mert", Sifre= "12345678", Yetki = Yetkiler.Admin, Personel = per3 });
                Kullanici kul4 = context.Kullanicilar.Add(new Kullanici { Ad = "osman", Sifre= "12345678", Yetki = Yetkiler.Kullanıcı, Personel = per4 });

                Ilac il1 = context.Ilaclar.Add(new Ilac { Ad = "EDİCİN", Kategori = kat4, SKT = DateTime.Now, Fiyat = 33, Adet = 15, Aciklama = "Ağır enfeksiyonların tedavisinde kullanılır" });
                Ilac il2 = context.Ilaclar.Add(new Ilac { Ad = "LUMINALETEN", Kategori = kat1, SKT = DateTime.Now, Fiyat = 15, Adet = 15, Aciklama = "Epilepsi nöbetlerinin önlenmesinde kullanılır" });
                Ilac il3 = context.Ilaclar.Add(new Ilac { Ad = "VİTABİOL", Kategori = kat5, SKT = DateTime.Now, Fiyat = 20, Adet = 15, Aciklama = "Ebesinlerin yetersiz emilimi, protein eksikliği,ağız-boğaz" });
                Ilac il4 = context.Ilaclar.Add(new Ilac { Ad = "TİENAM", Kategori = kat4, SKT = DateTime.Now, Fiyat = 25, Adet = 15, Aciklama = "Ciddi enfeksiyonların tedavisinde kullanılan bir antibiyotiktir" });
                Ilac il5 = context.Ilaclar.Add(new Ilac { Ad = "DİAZEPAM", Kategori = kat1, SKT = DateTime.Now, Fiyat = 12, Adet = 5, Aciklama = "Ağır enfeksiyonların tedavisinde kullanılır" });
                Ilac il6 = context.Ilaclar.Add(new Ilac { Ad = "Arzerra", Kategori = kat4, SKT = DateTime.Now, Fiyat = 9, Adet = 50, Aciklama = "1000 mg IV infüzyonluk çözelti konsantresi içeren flakon" });
                Ilac il7 = context.Ilaclar.Add(new Ilac { Ad = "AZARGA", Kategori = kat6, SKT = DateTime.Now, Fiyat = 10, Adet = 15, Aciklama = "10 mg/ml brinzolamid, 5 mg/ml timolol" });
                Ilac il8 = context.Ilaclar.Add(new Ilac { Ad = "Azopt", Kategori = kat14, SKT = DateTime.Now, Fiyat = 7, Adet = 25, Aciklama = "%1 Steril Göz Damlası, Süspansiyon" });
                Ilac il9 = context.Ilaclar.Add(new Ilac { Ad = "Betoptic", Kategori = kat14, SKT = DateTime.Now, Fiyat = 13, Adet = 15, Aciklama = "%0.5 Steril Göz Damlası, Çözelti" });
                Ilac il10 = context.Ilaclar.Add(new Ilac { Ad = "CATAFLAM", Kategori = kat10, SKT = DateTime.Now, Fiyat = 17, Adet = 20, Aciklama = "Diklofenak potasyum" });
                Ilac il11 = context.Ilaclar.Add(new Ilac { Ad = "Certican", Kategori = kat1, SKT = DateTime.Now, Fiyat = 30, Adet = 8, Aciklama = "0.25 mg suda çözünür tablet" });
                Ilac il12 = context.Ilaclar.Add(new Ilac { Ad = "CILOXAN", Kategori = kat7, SKT = DateTime.Now, Fiyat = 6, Adet = 15, Aciklama = "%0.3 oftalmik merhem" });

                context.SaveChanges();
            }
        }
    }
}
