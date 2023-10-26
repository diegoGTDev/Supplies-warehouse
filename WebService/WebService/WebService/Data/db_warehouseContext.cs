using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using WebService.Models;

namespace WebService.Data
{
    public partial class db_warehouseContext : DbContext
    {
        public db_warehouseContext()
        {
        }

        public db_warehouseContext(DbContextOptions<db_warehouseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Concept> Concepts { get; set; } = null!;
        public virtual DbSet<Department> Departments { get; set; } = null!;
        public virtual DbSet<Item> Items { get; set; } = null!;
        public virtual DbSet<Location> Locations { get; set; } = null!;
        public virtual DbSet<Material> Materials { get; set; } = null!;
        public virtual DbSet<Measure> Measures { get; set; } = null!;
        public virtual DbSet<Requirement> Requirements { get; set; } = null!;
        public virtual DbSet<RequirementStatus> RequirementStatuses { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-17OBIDL\\SQLEXPRESS;Database=db_warehouse;Trusted_Connection=true;TrustServerCertificate=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(e => e.AccId)
                    .HasName("PK__Account__9A20D5547893F938");

                entity.ToTable("Account");

                entity.Property(e => e.AccId).HasColumnName("acc_id");

                entity.Property(e => e.Department).HasColumnName("department");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Password)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.Role).HasColumnName("role");

                entity.HasOne(d => d.DepartmentNavigation)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.Department)
                    .HasConstraintName("FK__Account__departm__5070F446");

                entity.HasOne(d => d.RoleNavigation)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.Role)
                    .HasConstraintName("FK__Account__role__4F7CD00D");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.Property(e => e.CategoryId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("category_id");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Concept>(entity =>
            {
                entity.ToTable("Concept");

                entity.Property(e => e.ConceptId).HasColumnName("concept_id");

                entity.Property(e => e.RequiId).HasColumnName("requi_id");

                entity.Property(e => e.SupllyCode)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("suplly_code");

                entity.Property(e => e.Unts).HasColumnName("unts");

                entity.HasOne(d => d.Requi)
                    .WithMany(p => p.Concepts)
                    .HasForeignKey(d => d.RequiId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Concept__requi_i__6754599E");

                entity.HasOne(d => d.SupllyCodeNavigation)
                    .WithMany(p => p.Concepts)
                    .HasForeignKey(d => d.SupllyCode)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Concept__suplly___68487DD7");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.ToTable("Department");

                entity.HasIndex(e => e.Name, "UQ__Departme__72E12F1B76E0AE44")
                    .IsUnique();

                entity.Property(e => e.DepartmentId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("department_id");

                entity.Property(e => e.Name)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.HasKey(e => e.Code)
                    .HasName("PK__Item__357D4CF8B5359660");

                entity.ToTable("Item");

                entity.Property(e => e.Code)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("code");

                entity.Property(e => e.Category).HasColumnName("category");

                entity.Property(e => e.Description)
                    .HasColumnType("text")
                    .HasColumnName("description");

                entity.Property(e => e.Location).HasColumnName("location");

                entity.Property(e => e.Material).HasColumnName("material");

                entity.Property(e => e.Measure).HasColumnName("measure");

                entity.Property(e => e.Name)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.HasOne(d => d.CategoryNavigation)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.Category)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Item__category__5AEE82B9");

                entity.HasOne(d => d.LocationNavigation)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.Location)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Item__location__5CD6CB2B");

                entity.HasOne(d => d.MaterialNavigation)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.Material)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Item__material__5DCAEF64");

                entity.HasOne(d => d.MeasureNavigation)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.Measure)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Item__measure__5BE2A6F2");
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.ToTable("Location");

                entity.Property(e => e.LocationId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("location_id");

                entity.Property(e => e.Name)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Material>(entity =>
            {
                entity.ToTable("Material");

                entity.Property(e => e.MaterialId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("material_id");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Measure>(entity =>
            {
                entity.ToTable("Measure");

                entity.Property(e => e.MeasureId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("measure_id");

                entity.Property(e => e.Symbol)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("symbol");
            });

            modelBuilder.Entity<Requirement>(entity =>
            {
                entity.HasKey(e => e.RequiId)
                    .HasName("PK__Requirem__ED19C6D1474AF54F");

                entity.ToTable("Requirement");

                entity.Property(e => e.RequiId).HasColumnName("requi_id");

                entity.Property(e => e.Account).HasColumnName("account");

                entity.Property(e => e.Date)
                    .HasColumnType("datetime")
                    .HasColumnName("date");

                entity.Property(e => e.Description)
                    .HasColumnType("text")
                    .HasColumnName("description");

                entity.Property(e => e.RequiStatus).HasColumnName("requi_status");

                entity.Property(e => e.Responsable).HasColumnName("responsable");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.HasOne(d => d.AccountNavigation)
                    .WithMany(p => p.RequirementAccountNavigations)
                    .HasForeignKey(d => d.Account)
                    .HasConstraintName("FK__Requireme__accou__628FA481");

                entity.HasOne(d => d.ResponsableNavigation)
                    .WithMany(p => p.RequirementResponsableNavigations)
                    .HasForeignKey(d => d.Responsable)
                    .HasConstraintName("FK__Requireme__respo__6477ECF3");

                entity.HasOne(d => d.StatusNavigation)
                    .WithMany(p => p.Requirements)
                    .HasForeignKey(d => d.Status)
                    .HasConstraintName("FK__Requireme__statu__6383C8BA");
            });

            modelBuilder.Entity<RequirementStatus>(entity =>
            {
                entity.HasKey(e => e.RequiStatusId)
                    .HasName("PK__Requirem__8F69E6AD82F8094D");

                entity.ToTable("Requirement_status");

                entity.Property(e => e.RequiStatusId).HasColumnName("requi_status_id");

                entity.Property(e => e.StatusName)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("status_name");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.HasIndex(e => e.Name, "UQ__Role__72E12F1B76375EA3")
                    .IsUnique();

                entity.Property(e => e.RoleId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("role_ID");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
