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
    
    public partial class usp_CareerCategoryForEdit_SelectAll_Result
    {
        public int CareerCategoryID { get; set; }
        public string CareerCategoryName { get; set; }
        public string CareerCategoryNameEn { get; set; }
        public int ParentID { get; set; }
        public string ParentCategoryName { get; set; }
        public Nullable<byte> SortOrder { get; set; }
        public Nullable<bool> IsAvailable { get; set; }
    }
}