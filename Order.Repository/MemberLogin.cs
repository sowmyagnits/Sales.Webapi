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

    public partial class MemberLogin
    {
        public string LoginProvider { get; set; }
        public string ProviderKey { get; set; }
        public int MemberId { get; set; }
    
        public virtual Member Member { get; set; }
    }
}
