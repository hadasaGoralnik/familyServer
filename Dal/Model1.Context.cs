﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class familydbEntities8 : DbContext
    {
        public familydbEntities8()
            : base("name=familydbEntities8")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ChatMessages> ChatMessages { get; set; }
        public virtual DbSet<Events> Events { get; set; }
        public virtual DbSet<EventsKind> EventsKind { get; set; }
        public virtual DbSet<Groups> Groups { get; set; }
        public virtual DbSet<Menu> Menu { get; set; }
        public virtual DbSet<Message> Message { get; set; }
        public virtual DbSet<Picture> Picture { get; set; }
        public virtual DbSet<User> User { get; set; }
    }
}
