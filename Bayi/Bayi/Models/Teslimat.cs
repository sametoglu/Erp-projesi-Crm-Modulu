using System;
using System.Collections.Generic;

namespace Bayi.Models
{
    public partial class Teslimat
    {
        public int teslimat_ID { get; set; }
        public string bayi_adi { get; set; }
        public Nullable<int> sirket_ID { get; set; }
        public Nullable<int> kucuk { get; set; }
        public Nullable<int> orta { get; set; }
        public Nullable<int> buyuk { get; set; }
        public Nullable<int> enbuyuk { get; set; }
        public Nullable<System.DateTime> teslimtarihi { get; set; }
        public Nullable<int> istek_ID { get; set; }
        public virtual Istek Istek { get; set; }
        public virtual NakliyeSirketleri NakliyeSirketleri { get; set; }
    }
}
