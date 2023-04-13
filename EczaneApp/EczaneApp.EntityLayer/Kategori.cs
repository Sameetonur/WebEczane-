using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EczaneApp.EntityLayer
{
    [Table("tblKategori")]
    public class Kategori
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Boş bırakılamaz."), MaxLength(25, ErrorMessage = "En fazla 25 karakter olabilir.")]
        public string Ad { get; set; }
    }
}
