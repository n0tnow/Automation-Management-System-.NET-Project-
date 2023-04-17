﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TicariOtomasyon.Models.Siniflar
{
    public class SatisHareket
    {
        [Key]
        public int SatisHareketID { get; set; }
        public int Urunid { get; set; }
        public virtual Urun Urun { get; set; }
        public int Personelid { get; set; }
        public virtual Personel Personel { get; set; }
        public int Cariid { get; set; }
        public virtual Cari Cari { get; set; }
        public DateTime Tarih { get; set; }
        public int Adet { get; set; }
        public decimal Fiyat { get; set; }
        public decimal Tutar { get; set; }
    }
}