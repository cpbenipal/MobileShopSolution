//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace webMobileShop.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            this.UserRolesMappings = new HashSet<UserRolesMapping>();
        }
    
        public long Id { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string Password { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
        public int IsActive { get; set; }
        public System.DateTime AddedOn { get; set; }
        public long AddedBy { get; set; }
        public System.DateTime ModifiedOn { get; set; }
        public long ModifiedBy { get; set; }
    
        public virtual mVariable mVariable { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserRolesMapping> UserRolesMappings { get; set; }
    }
}
