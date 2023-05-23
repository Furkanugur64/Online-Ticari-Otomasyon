using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Online_Ticari_Otomasyon.Models.Siniflar
{
    public class Cariler
    {
        [Key]
        public int CariID { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30, ErrorMessage = "Ad bilgisi 30 karakterden uzun olamaz !")]
        [Required(ErrorMessage ="Bu alan boş bırakılamaz !!")]
        public string CariAd { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30,ErrorMessage ="Soyad bilgisi 30 karakterden uzun olamaz !")]
        [Required(ErrorMessage = "Bu alan boş bırakılamaz !!")]
        public string CariSoyad { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(13)]
        public string CariSehir { get; set; }
       
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string CariMail { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(20)]
        public string CariSifre { get; set; }
        public bool Durum { get; set; }

        public ICollection<SatisHareket> SatisHarekets { get; set; }
    }
}