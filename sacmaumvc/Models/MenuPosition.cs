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
    
    public partial class MenuPosition
    {
        public MenuPosition()
        {
            this.Menus = new HashSet<Menu>();
        }
    
        public int MenuPositionID { get; set; }
        public string MenuPositionName { get; set; }
        public Nullable<bool> IsAvailable { get; set; }
    
        public virtual ICollection<Menu> Menus { get; set; }
    }
}