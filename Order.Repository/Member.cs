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
    using Order.Repository.DomainModel;
    using System;
    using System.Collections.Generic;

    public partial class Member
    {
        public Member()
        {
            this.MemberClaims = new HashSet<MemberClaim>();
            this.MemberLogins = new HashSet<MemberLogin>();
            this.Roles = new HashSet<Role>();
        }
    
        public int Id { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public Nullable<System.DateTime> LockoutEndDateUtc { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
        public string UserName { get; set; }
    
        public virtual ICollection<MemberClaim> MemberClaims { get; set; }
        public virtual ICollection<MemberLogin> MemberLogins { get; set; }
        public virtual ICollection<Role> Roles { get; set; }
    }
}
