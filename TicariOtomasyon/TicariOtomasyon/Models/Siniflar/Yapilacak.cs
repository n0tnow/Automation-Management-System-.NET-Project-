﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TicariOtomasyon.Models.Siniflar
{
    public class Yapilacak
    {

        [Key]
        public int YapilacakID { get; set; }
        
        [Column(TypeName = "Varchar")]
        [StringLength(150)]
        public string Baslik { get; set; }


        [Column(TypeName = "bit")]
        public bool Durum { get; set; }
        
    }
}