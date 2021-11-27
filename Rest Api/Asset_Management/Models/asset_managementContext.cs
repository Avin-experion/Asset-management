using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Asset_Management.Models
{
    public partial class asset_managementContext : DbContext
    {
        public asset_managementContext()
        {
        }

        public asset_managementContext(DbContextOptions<asset_managementContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AssetDefinition> AssetDefinition { get; set; }
        public virtual DbSet<AssetType> AssetType { get; set; }
        public virtual DbSet<Login> Login { get; set; }
        public virtual DbSet<PurchaseOrder> PurchaseOrder { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<UserRegistration> UserRegistration { get; set; }
        public virtual DbSet<Vendor> Vendor { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=AVINJOSEPH\\SQLEXPRESS; Initial Catalog=asset_management;Integrated security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AssetDefinition>(entity =>
            {
                entity.HasKey(e => e.AdId)
                    .HasName("PK__AssetDef__7130D5AE729611E5");

                entity.Property(e => e.AdClass)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.AdName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.AdType)
                    .WithMany(p => p.AssetDefinition)
                    .HasForeignKey(d => d.AdTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_atid");
            });

            modelBuilder.Entity<AssetType>(entity =>
            {
                entity.HasKey(e => e.AssetId)
                    .HasName("PK__AssetTyp__434923522E78C8DC");

                entity.Property(e => e.AssetName)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Login>(entity =>
            {
                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.UserTypeNavigation)
                    .WithMany(p => p.Login)
                    .HasForeignKey(d => d.UserType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("login_fk");
            });

            modelBuilder.Entity<PurchaseOrder>(entity =>
            {
                entity.HasKey(e => e.PdId)
                    .HasName("PK__Purchase__A0023E7C91231D48");

                entity.Property(e => e.PdDate).HasColumnType("date");

                entity.Property(e => e.PdDdate)
                    .HasColumnName("PdDDate")
                    .HasColumnType("date");

                entity.Property(e => e.PdOrder)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PdStatus)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.PdAd)
                    .WithMany(p => p.PurchaseOrder)
                    .HasForeignKey(d => d.PdAdId)
                    .HasConstraintName("fk_ad_id2");

                entity.HasOne(d => d.PdType)
                    .WithMany(p => p.PurchaseOrder)
                    .HasForeignKey(d => d.PdTypeId)
                    .HasConstraintName("fk_pus_id");

                entity.HasOne(d => d.PdVendor)
                    .WithMany(p => p.PurchaseOrder)
                    .HasForeignKey(d => d.PdVendorId)
                    .HasConstraintName("fk_vd_id");
            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.HasKey(e => e.RoleId)
                    .HasName("PK__Roles__8AFACE1AAA4BFE7A");

                entity.Property(e => e.RoleType)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserRegistration>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__UserRegi__1788CC4CBC8282CB");

                entity.Property(e => e.Address)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Age)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasMaxLength(9)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.Login)
                    .WithMany(p => p.UserRegistration)
                    .HasForeignKey(d => d.LoginId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_user");
            });

            modelBuilder.Entity<Vendor>(entity =>
            {
                entity.HasKey(e => e.Vid)
                    .HasName("PK__Vendor__C5DF235BD1BA8965");

                entity.Property(e => e.Vid).HasColumnName("VId");

                entity.Property(e => e.VdAddress)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.VdFrom).HasColumnType("date");

                entity.Property(e => e.VdName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.VdTo).HasColumnType("date");

                entity.Property(e => e.VdType)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.VdTypeNavigation)
                    .WithMany(p => p.Vendor)
                    .HasForeignKey(d => d.VdTypeId)
                    .HasConstraintName("fk_vartype");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
