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
    
    public partial class Download
    {
        public int DownloadID { get; set; }
        public string ImageName { get; set; }
        public string FilePath { get; set; }
        public string DownloadName { get; set; }
        public string DownloadNameEn { get; set; }
        public Nullable<int> DownloadCategoryID { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<bool> IsAvailable { get; set; }
        public Nullable<int> Priority { get; set; }
    
        public virtual DownloadCategory DownloadCategory { get; set; }
    }
}
