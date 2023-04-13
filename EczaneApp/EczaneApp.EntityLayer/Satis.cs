using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EczaneApp.EntityLayer
{
    [Table("tblSatis")]
    public class Satis
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Boş bırakılamaz.")]
        public DateTime Tarih { get; set; }
        [Required(ErrorMessage = "Boş bırakılamaz.")]
        public decimal Tutar { get; set; }
        [Required(ErrorMessage = "Boş bırakılamaz.")]
        public int MusteriId { get; set; }
        [ForeignKey("MusteriId")]
        public Musteri Musteri { get; set; }
        [Required(ErrorMessage = "Boş bırakılamaz.")]
        public int PersonelId { get; set; }
        [ForeignKey("PersonelId")]
        public Personel Personel { get; set; }
        public ICollection<SatisDetay> SatisDetaylar { get; set; }

        public Satis()
        {
            SatisDetaylar = new List<SatisDetay>();
        }
    }
}
