using System;
using System.Collections.Generic;

namespace Erp.Models
{
    public partial class NakliyeSirketleri
    {
        public NakliyeSirketleri()
        {
            this.Degers = new List<Deger>();
            this.Teslimats = new List<Teslimat>();
        }

        public int sirket_ID { get; set; }
        public string sirket_adi { get; set; }
        public Nullable<int> km_fiyat { get; set; }
        public Nullable<int> litre_fiyat { get; set; }
        public string teslimat_hizi { get; set; }
        public virtual ICollection<Deger> Degers { get; set; }
        public virtual ICollection<Teslimat> Teslimats { get; set; }
    }
}
