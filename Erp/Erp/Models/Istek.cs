using System;
using System.Collections.Generic;

namespace Erp.Models
{
    public partial class Istek
    {
        public int istek_ID { get; set; }
        public string bayi_adi { get; set; }
        public Nullable<int> kucuk { get; set; }
        public Nullable<int> orta { get; set; }
        public Nullable<int> buyuk { get; set; }
        public Nullable<int> enbuyuk { get; set; }
        public Nullable<System.DateTime> istektarihi { get; set; }
        public string Durum { get; set; }
    }
}
