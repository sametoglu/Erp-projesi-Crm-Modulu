using System;
using System.Collections.Generic;

namespace Bayi.Models
{
    public partial class Stok
    {
        public int stok_ID { get; set; }
        public Nullable<int> kucuk { get; set; }
        public Nullable<int> orta { get; set; }
        public Nullable<int> buyuk { get; set; }
        public Nullable<int> enbuyuk { get; set; }
    }
}
