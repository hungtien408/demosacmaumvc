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
    
    public partial class Menu
    {
        public int MenuID { get; set; }
        public string ImageName { get; set; }
        public string ImageNameEn { get; set; }
        public string MenuTitle { get; set; }
        public string MenuTitleEn { get; set; }
        public string Link { get; set; }
        public string LinkEn { get; set; }
        public Nullable<int> MenuPositionID { get; set; }
        public Nullable<int> ParentID { get; set; }
        public Nullable<byte> SortOrder { get; set; }
        public Nullable<bool> IsAvailable { get; set; }
    
        public virtual MenuPosition MenuPosition { get; set; }
    }
}
