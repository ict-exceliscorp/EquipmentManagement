//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EquipmentManagement.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class RegisteredEquipment
    {
        public int ID { get; set; }
        public Nullable<int> EquipmentID { get; set; }
        public Nullable<int> SiteID { get; set; }
    
        public virtual Equipment Equipment { get; set; }
        public virtual Site Site { get; set; }
    }
}
