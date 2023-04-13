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
    [Table("tblIlac")]
    public class Ilac
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Boş bırakılamaz."), MinLength(3, ErrorMessage = "En az 3 karakter olabilir."), MaxLength(50, ErrorMessage = "En fazla 50 karakter olabilir.")]
        public string Ad { get; set; }
        [Required(ErrorMessage = "Boş bırakılamaz.")]
        [DisplayName("Son Kullanma Tarihi")]
        public DateTime SKT { get; set; } = DateTime.Now;
        [Required(ErrorMessage = "Boş bırakılamaz.")]
        public decimal Fiyat { get; set; }
        [Required(ErrorMessage = "Boş bırakılamaz."), MaxLength(200, ErrorMessage = "En fazla 200 karakter olabilir.")]
        public string Aciklama { get; set; }
        [Required(ErrorMessage = "Boş bırakılamaz.")]
        public int Adet { get; set; }
        [Required(ErrorMessage = "Boş bırakılamaz.")]
        public int KategoriId { get; set; }
        [ForeignKey("KategoriId")]
        public Kategori Kategori { get; set; }
    }
}
