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
    [Table("tblMusteri")]
    public class Musteri
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Boş bırakılamaz."), MinLength(3, ErrorMessage = "En az 3 karakter olabilir."), MaxLength(15, ErrorMessage = "En fazla 15 karakter olabilir.")]
        public string Ad { get; set; }
        [Required(ErrorMessage = "Boş bırakılamaz."), MinLength(3, ErrorMessage = "En az 3 karakter olabilir."), MaxLength(15, ErrorMessage = "En fazla 15 karakter olabilir.")]
        public string Soyad { get; set; }
        [Required(ErrorMessage = "Boş bırakılamaz."), StringLength(11, ErrorMessage = "11 karakter olmalı.")]
        public string TC { get; set; }
        [Required(ErrorMessage = "Boş bırakılamaz."), DisplayName("Doğum Tarihi")]
        public DateTime DogumTarih { get; set; } = DateTime.Now;
    }
}
