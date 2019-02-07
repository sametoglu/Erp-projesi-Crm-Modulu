using System;
using System.Collections.Generic;

namespace Erp.Models
{
    public partial class Sati
    {
        public int satis_ID { get; set; }
        public string bayi_adi { get; set; }
        public Nullable<int> kucuk { get; set; }
        public Nullable<int> orta { get; set; }
        public Nullable<int> buyuk { get; set; }
        public Nullable<int> enbuyuk { get; set; }
        public Nullable<int> toplamsatis { get; set; }
        public Nullable<System.DateTime> tarih { get; set; }
    }
}
