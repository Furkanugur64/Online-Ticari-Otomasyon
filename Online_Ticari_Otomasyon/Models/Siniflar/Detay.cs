using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Online_Ticari_Otomasyon.Models.Siniflar
{
    public class Detay
    {
        public int DetayID { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string UrunAd { get; set; }
        
        [Column(TypeName = "Varchar")]
        [StringLength(2000)]
        public string Urunbilgi { get; set; }
    }
}