using System;
using System.Collections.Generic;

namespace Order.Business.DataContract
{
    public class CATEGORYContract
    {
        public int CATEGORYID { get; set; }
        public string DESCRIPTION { get; set; }
        public Nullable<System.DateTime> CREATEDDATE { get; set; }

        public virtual ICollection<ProductContract> PRODUCTs { get; set; }
    }
}