namespace BSNLEntity
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class BSNLContext : DbContext
    {
        public BSNLContext()
            : base("name=BSNLContext")
        {
        }

        public virtual DbSet<BaseData> BaseDatas { get; set; }
        public virtual DbSet<Dispute> Disputes { get; set; }
        public virtual DbSet<EmailTemplate> EmailTemplates { get; set; }
        public virtual DbSet<MenuMaster> MenuMasters { get; set; }
        public virtual DbSet<RevenueData> RevenueDatas { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BaseData>()
                .HasOptional(e => e.Dispute)
                .WithRequired(e => e.BaseData);

            modelBuilder.Entity<BaseData>()
                .HasOptional(e => e.RevenueData)
                .WithRequired(e => e.BaseData);

            modelBuilder.Entity<MenuMaster>()
                .Property(e => e.MenuName)
                .IsUnicode(false);

            modelBuilder.Entity<MenuMaster>()
                .Property(e => e.MenuURL)
                .IsUnicode(false);
        }
    }
}
