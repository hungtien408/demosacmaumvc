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
    
    public partial class WishList
    {
        public int ProductID { get; set; }
        public string UserName { get; set; }
        public Nullable<int> Quantity { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public string ImageName { get; set; }
        public string ProductName { get; set; }
        public string ProductNameEn { get; set; }
        public string ProductCode { get; set; }
        public Nullable<int> ProductOptionCategoryID { get; set; }
        public string ProductOptionCategoryName { get; set; }
        public Nullable<int> ProductLengthID { get; set; }
        public string ProductLengthName { get; set; }
        public Nullable<int> ProductSizeColorID { get; set; }
        public Nullable<int> QuantityList { get; set; }
    }
}
