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
    
    public partial class District
    {
        public int DistrictID { get; set; }
        public string DistrictName { get; set; }
        public Nullable<int> ProvinceID { get; set; }
        public Nullable<bool> IsAvailable { get; set; }
        public Nullable<int> Priority { get; set; }
        public Nullable<decimal> ShippingPrice { get; set; }
        public string DistrictNameEn { get; set; }
    }
}
