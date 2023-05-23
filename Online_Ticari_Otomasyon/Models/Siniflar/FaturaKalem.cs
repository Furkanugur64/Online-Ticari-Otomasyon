using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Online_Ticari_Otomasyon.Models.Siniflar
{
    public class FaturaKalem
    {
        [Key]
        public int FaturaKalemID { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string Aciklama { get; set; }

        public int Miktar { get; set; }
        public Decimal BirimFiyat { get; set; }
        public Decimal Tutar { get; set; }

        public int Faturaid { get; set; }
        public virtual Faturalar Faturalar { get; set; }
    }
}