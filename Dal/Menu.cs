//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Dal
{
    using System;
    using System.Collections.Generic;
    
    public partial class Menu
    {
        public int Id { get; set; }
        public int MenuOrderNumber { get; set; }
        public int VolunteerId { get; set; }
        public string Name { get; set; }
        public int EventId { get; set; }
        public Nullable<int> Quantity { get; set; }
        public Nullable<int> Cost { get; set; }
        public virtual Events Events { get; set; }
        public virtual User User { get; set; }
    }
}
