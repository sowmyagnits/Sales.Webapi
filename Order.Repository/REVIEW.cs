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

    public partial class REVIEW
    {
        public int PRODUCTREVIEWID { get; set; }
        public Nullable<int> PRODUCTID { get; set; }
        public string COMMENTS { get; set; }
        public Nullable<System.DateTime> REVIEWDATE { get; set; }
        public string REVIEWERNAME { get; set; }
        public Nullable<int> RATINGS { get; set; }
        public Nullable<System.DateTime> CREATEDDATE { get; set; }
    
        public virtual PRODUCT PRODUCT { get; set; }
    }
}
