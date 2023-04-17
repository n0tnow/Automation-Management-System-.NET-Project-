using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TicariOtomasyon.Models.Siniflar
{
    public class Tedarikci
    {
        [Key]
        public int TedarikciID { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(30, ErrorMessage = "En Fazla 30 Karakter Yazabilirsiniz!")]
        public string TedarikciAd { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(30)]
        [Required(ErrorMessage = "Bu Alan Boş Geçilemez!")]
        public string TedarikciSoyad { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(15)]
        public string TedarikciSehir { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(100)]
        public string TedarikciMail { get; set; }

        public bool Durum { get; set; }
        public ICollection<FaturaKalem> FaturaKalems { get; set; }
        
    }
}