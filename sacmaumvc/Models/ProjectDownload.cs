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
    
    public partial class ProjectDownload
    {
        public int ProjectDownloadID { get; set; }
        public Nullable<int> ProjectID { get; set; }
        public string FileName { get; set; }
        public string FileNameEn { get; set; }
        public string LinkDownload { get; set; }
        public Nullable<bool> IsAvailable { get; set; }
        public Nullable<int> Priority { get; set; }
    
        public virtual Project Project { get; set; }
    }
}
