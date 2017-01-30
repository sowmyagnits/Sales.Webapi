using System;

namespace Order.Business.DataContract
{
    public class OrderDetailsContract
    {
        public int ORDERDETAILID { get; set; }
        public string DESCRIPTION { get; set; }
        public Nullable<System.DateTime> CREATEDDATE { get; set; }
    }
}