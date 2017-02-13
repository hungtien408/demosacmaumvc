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
    
    public partial class Project
    {
        public Project()
        {
            this.ProjectDownloads = new HashSet<ProjectDownload>();
            this.ProjectImages = new HashSet<ProjectImage>();
            this.ProjectVideos = new HashSet<ProjectVideo>();
        }
    
        public int ProjectID { get; set; }
        public string ImageName { get; set; }
        public string MetaTittle { get; set; }
        public string MetaDescription { get; set; }
        public string ProjectTitle { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public string MetaTittleEn { get; set; }
        public string MetaDescriptionEn { get; set; }
        public string ProjectTitleEn { get; set; }
        public string DescriptionEn { get; set; }
        public string ContentEn { get; set; }
        public string TagEn { get; set; }
        public Nullable<int> ProjectCategoryID { get; set; }
        public string Tag { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<bool> IsShowOnHomePage { get; set; }
        public Nullable<bool> IsAvailable { get; set; }
        public Nullable<int> Priority { get; set; }
    
        public virtual ProjectCategory ProjectCategory { get; set; }
        public virtual ICollection<ProjectDownload> ProjectDownloads { get; set; }
        public virtual ICollection<ProjectImage> ProjectImages { get; set; }
        public virtual ICollection<ProjectVideo> ProjectVideos { get; set; }
    }
}