//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Order.Repository
{
    using System;
    using System.Collections.Generic;
    
    public partial class ORDER
    {
        public ORDER()
        {
            this.ORDERDETAILs = new HashSet<ORDERDETAIL>();
        }
    
        public int ORDERID { get; set; }
        public string DESCRIPTION { get; set; }
        public Nullable<System.DateTime> CREATEDDATE { get; set; }
    
        public virtual ICollection<ORDERDETAIL> ORDERDETAILs { get; set; }
    }
}
