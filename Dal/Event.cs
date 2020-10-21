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
    
    public partial class Event
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Event()
        {
            this.ChatMessages = new HashSet<ChatMessage>();
            this.Menus = new HashSet<Menu>();
            this.Messages = new HashSet<Message>();
            this.Pictures = new HashSet<Picture>();
        }
    
        public int Id { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public System.DateTime Date { get; set; }
        public string Description { get; set; }
        public int Promoter { get; set; }
        public string Comment { get; set; }
        public Nullable<bool> IsDairy { get; set; }
        public Nullable<int> GroupId { get; set; }
        public Nullable<int> Repeat { get; set; }
        public int EventKindId { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChatMessage> ChatMessages { get; set; }
        public virtual EventsKind EventsKind { get; set; }
        public virtual Group Group { get; set; }
        public virtual User User { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Menu> Menus { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Message> Messages { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Picture> Pictures { get; set; }
    }
}