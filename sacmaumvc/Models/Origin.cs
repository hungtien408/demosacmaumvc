//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace sacmaumvc.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Origin
    {
        public Origin()
        {
            this.Products = new HashSet<Product>();
        }
    
        public int OriginID { get; set; }
        public string OriginName { get; set; }
        public string OriginNameEn { get; set; }
        public Nullable<bool> IsAvailable { get; set; }
        public Nullable<int> Priority { get; set; }
    
        public virtual ICollection<Product> Products { get; set; }
    }
}