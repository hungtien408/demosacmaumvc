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
    
    public partial class ProductImage
    {
        public int ProductImageID { get; set; }
        public string ImageName { get; set; }
        public string Title { get; set; }
        public string Descripttion { get; set; }
        public string TitleEn { get; set; }
        public string DescripttionEn { get; set; }
        public Nullable<int> ProductID { get; set; }
        public Nullable<bool> IsAvailable { get; set; }
        public Nullable<int> Priority { get; set; }
    
        public virtual Product Product { get; set; }
    }
}
