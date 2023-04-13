using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EczaneApp.EntityLayer
{
    [Table("tblSatisDetay")]
    public class SatisDetay
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Adet { get; set; }
        public decimal AdetFiyat { get; set; }
        public decimal Tutar { get { return Adet * AdetFiyat; } }
        public int IlacId { get; set; }
        [ForeignKey("IlacId")]
        public Ilac Ilac { get; set; }
        [NotMapped]
        public string IlacAd { get; set; }
        public int SatisId { get; set; }
        [ForeignKey("SatisId")]
        public Satis Satis { get; set; }
    }
}
