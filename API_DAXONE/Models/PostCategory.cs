//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace API_DAXONE.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class PostCategory
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PostCategory()
        {
            this.Posts = new HashSet<Post>();
        }
    
        public long ID { get; set; }
        public string Name { get; set; }
        public string MetaTitle { get; set; }
        public string Description { get; set; }
        public Nullable<long> ParentID { get; set; }
        public Nullable<bool> Status { get; set; }
        public Nullable<bool> ShowOnHome { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Post> Posts { get; set; }
    }
}
