﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GNAY_New1
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class TorqueSolutionsEntities : DbContext
    {
        public TorqueSolutionsEntities()
            : base("name=TorqueSolutionsEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<GNAY_Application> GNAY_Application { get; set; }
        public virtual DbSet<GNAYallotment> GNAYallotments { get; set; }
    }
}
