using System;
using System.Collections.Generic;

namespace Order.Business.DataContract
{
    public class ProductContract
    {
        public int ProductID { get; set; }

        public string Description { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string Brand { get; set; }

        public virtual ICollection<ReviewContract> REVIEWs { get; set; }
    }
}