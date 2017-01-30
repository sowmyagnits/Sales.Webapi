using System;
using System.Collections.Generic;

namespace Order.Business.DataContract
{
    public class OrderContract
    {
        public int ORDERID { get; set; }
        public string DESCRIPTION { get; set; }
        public Nullable<System.DateTime> CREATEDDATE { get; set; }

        public virtual ICollection<OrderDetailsContract> ORDERDETAILs { get; set; }
    }
}