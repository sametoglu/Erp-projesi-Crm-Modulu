using System;
using System.Collections.Generic;

namespace Bayi.Models
{
    public partial class Deger
    {
        public int deger_ID { get; set; }
        public Nullable<int> sirket_ID { get; set; }
        public Nullable<double> puan { get; set; }
        public virtual NakliyeSirketleri NakliyeSirketleri { get; set; }
    }
}
