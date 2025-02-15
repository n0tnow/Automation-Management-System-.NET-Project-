﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TicariOtomasyon.Models.Siniflar
{
    public class Fatura
    {
        [Key]
        public int FaturaID { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(8,ErrorMessage ="8 Karakterden Fazla Girilemez!!")]
        
        public string SiraNo { get; set; }


        [Column(TypeName = "Char")]
        [StringLength(1)]
        public string SeriNo { get; set; }

        public DateTime Tarih { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string VergiDairesi { get; set; }


        [Column(TypeName = "VarChar")]
        [StringLength(5)]
        public string Saat { get; set; }


        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string TedarikciTeslim { get; set; }


        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string PersonelTeslimAlan { get; set; }


        public decimal Toplam { get; set; }
        public ICollection<FaturaKalem> FaturaKalems { get; set; }
    }
}