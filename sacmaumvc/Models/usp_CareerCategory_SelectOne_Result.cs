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
    
    public partial class usp_CareerCategory_SelectOne_Result
    {
        public int CareerCategoryID { get; set; }
        public string CareerCategoryName { get; set; }
        public string CareerCategoryNameEn { get; set; }
        public string Description { get; set; }
        public string DescriptionEn { get; set; }
        public string Content { get; set; }
        public string ContentEn { get; set; }
        public string MetaTitle { get; set; }
        public string MetaTitleEn { get; set; }
        public string MetaDescription { get; set; }
        public string MetaDescriptionEn { get; set; }
        public string ImageName { get; set; }
        public Nullable<int> ParentID { get; set; }
        public Nullable<byte> SortOrder { get; set; }
        public Nullable<bool> IsShowOnMenu { get; set; }
        public Nullable<bool> IsAvailable { get; set; }
    }
}
