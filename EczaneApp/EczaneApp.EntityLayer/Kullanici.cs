using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EczaneApp.EntityLayer
{
    public enum Yetkiler
    {
        Kullanıcı = 0,
        Admin = 1
    }
    [Table("tblKullanici")]
    public class Kullanici
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage ="Boş bırakılamaz."),MinLength(3,ErrorMessage ="En az 3 karakter olabilir."), MaxLength(15,ErrorMessage ="En fazla 15 karakter olabilir."),DisplayName("Kullanıcı Adı")]
        public string Ad { get; set; }
        [Required(ErrorMessage = "Boş bırakılamaz."), MinLength(8, ErrorMessage = "En az 3 karakter olabilir."), MaxLength(20, ErrorMessage = "En fazla 15 karakter olabilir.")]
        public string Sifre { get; set; }
        [Required(ErrorMessage = "Boş bırakılamaz."), DisplayName("Son Giriş Tarihi")]
        public DateTime sonGirisT { get; set; } = DateTime.Now;
        [Required(ErrorMessage = "Boş bırakılamaz.")]
        public int PersonelId { get; set; }
        [ForeignKey("PersonelId")]
        public Personel Personel { get; set; }
        [Required(ErrorMessage = "Boş bırakılamaz.")]
        public Yetkiler Yetki { get; set; }
    }
}
