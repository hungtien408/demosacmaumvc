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
    
    public partial class Province
    {
        public int ProvinceID { get; set; }
        public string ProvinceName { get; set; }
        public Nullable<bool> IsAvailable { get; set; }
        public Nullable<int> Priority { get; set; }
        public string ShortName { get; set; }
        public Nullable<int> CountryID { get; set; }
        public Nullable<decimal> ShippingPrice { get; set; }
    }
}