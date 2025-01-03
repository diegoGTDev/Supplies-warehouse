﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebService.Data;

#nullable disable

namespace WebService.Migrations
{
    [DbContext(typeof(db_warehouseContext))]
    [Migration("20241204080356_ChangePrimaryKeyType")]
    partial class ChangePrimaryKeyType
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.23")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("WebService.Models.Account", b =>
                {
                    b.Property<short>("AccId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint")
                        .HasColumnName("acc_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<short>("AccId"), 1L, 1);

                    b.Property<short>("Department")
                        .HasColumnType("smallint")
                        .HasColumnName("department");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(256)
                        .IsUnicode(false)
                        .HasColumnType("varchar(256)")
                        .HasColumnName("password");

                    b.Property<short>("Role")
                        .HasColumnType("smallint")
                        .HasColumnName("role");

                    b.HasKey("AccId")
                        .HasName("PK__Account__9A20D5547893F938");

                    b.HasIndex("Department");

                    b.HasIndex("Role");

                    b.ToTable("Account", (string)null);
                });

            modelBuilder.Entity("WebService.Models.Category", b =>
                {
                    b.Property<short>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint")
                        .HasColumnName("category_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<short>("CategoryId"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("name");

                    b.HasKey("CategoryId");

                    b.ToTable("Category", (string)null);
                });

            modelBuilder.Entity("WebService.Models.Concept", b =>
                {
                    b.Property<int>("ConceptId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("concept_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ConceptId"), 1L, 1);

                    b.Property<int?>("RequiId")
                        .HasColumnType("int")
                        .HasColumnName("requi_id");

                    b.Property<string>("SupllyCode")
                        .HasMaxLength(15)
                        .IsUnicode(false)
                        .HasColumnType("varchar(15)")
                        .HasColumnName("suplly_code");

                    b.Property<short>("Unts")
                        .HasColumnType("smallint")
                        .HasColumnName("unts");

                    b.HasKey("ConceptId");

                    b.HasIndex("RequiId");

                    b.HasIndex("SupllyCode");

                    b.ToTable("Concept", (string)null);
                });

            modelBuilder.Entity("WebService.Models.Department", b =>
                {
                    b.Property<short>("DepartmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint")
                        .HasColumnName("department_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<short>("DepartmentId"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60)
                        .IsUnicode(false)
                        .HasColumnType("varchar(60)")
                        .HasColumnName("name");

                    b.HasKey("DepartmentId");

                    b.HasIndex(new[] { "Name" }, "UQ__Departme__72E12F1B76E0AE44")
                        .IsUnique();

                    b.ToTable("Department", (string)null);
                });

            modelBuilder.Entity("WebService.Models.Item", b =>
                {
                    b.Property<string>("Code")
                        .HasMaxLength(15)
                        .IsUnicode(false)
                        .HasColumnType("varchar(15)")
                        .HasColumnName("code");

                    b.Property<short?>("Category")
                        .HasColumnType("smallint")
                        .HasColumnName("category");

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<short?>("Location")
                        .HasColumnType("smallint")
                        .HasColumnName("location");

                    b.Property<int?>("Material")
                        .HasColumnType("int")
                        .HasColumnName("material");

                    b.Property<int?>("Measure")
                        .HasColumnType("int")
                        .HasColumnName("measure");

                    b.Property<string>("Name")
                        .HasMaxLength(60)
                        .IsUnicode(false)
                        .HasColumnType("varchar(60)")
                        .HasColumnName("name");

                    b.Property<short?>("Quantity")
                        .HasColumnType("smallint")
                        .HasColumnName("quantity");

                    b.HasKey("Code")
                        .HasName("PK__Item__357D4CF8B5359660");

                    b.HasIndex("Category");

                    b.HasIndex("Location");

                    b.HasIndex("Material");

                    b.HasIndex("Measure");

                    b.ToTable("Item", (string)null);
                });

            modelBuilder.Entity("WebService.Models.Location", b =>
                {
                    b.Property<short>("LocationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint")
                        .HasColumnName("location_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<short>("LocationId"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)")
                        .HasColumnName("name");

                    b.HasKey("LocationId");

                    b.ToTable("Location", (string)null);
                });

            modelBuilder.Entity("WebService.Models.Material", b =>
                {
                    b.Property<int>("MaterialId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("material_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaterialId"), 1L, 1);

                    b.Property<string>("Nombre")
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)")
                        .HasColumnName("nombre");

                    b.HasKey("MaterialId");

                    b.ToTable("Material", (string)null);
                });

            modelBuilder.Entity("WebService.Models.Measure", b =>
                {
                    b.Property<int>("MeasureId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("measure_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MeasureId"), 1L, 1);

                    b.Property<string>("Symbol")
                        .HasMaxLength(5)
                        .IsUnicode(false)
                        .HasColumnType("varchar(5)")
                        .HasColumnName("symbol");

                    b.HasKey("MeasureId");

                    b.ToTable("Measure", (string)null);
                });

            modelBuilder.Entity("WebService.Models.Requirement", b =>
                {
                    b.Property<int>("RequiId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("requi_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RequiId"), 1L, 1);

                    b.Property<short?>("Account")
                        .HasColumnType("smallint")
                        .HasColumnName("account");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime")
                        .HasColumnName("date");

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<byte?>("RequiStatus")
                        .HasColumnType("tinyint")
                        .HasColumnName("requi_status");

                    b.Property<short?>("Responsable")
                        .HasColumnType("smallint")
                        .HasColumnName("responsable");

                    b.Property<byte?>("Status")
                        .HasColumnType("tinyint")
                        .HasColumnName("status");

                    b.HasKey("RequiId")
                        .HasName("PK__Requirem__ED19C6D1474AF54F");

                    b.HasIndex("Account");

                    b.HasIndex("Responsable");

                    b.HasIndex("Status");

                    b.ToTable("Requirement", (string)null);
                });

            modelBuilder.Entity("WebService.Models.RequirementStatus", b =>
                {
                    b.Property<byte>("RequiStatusId")
                        .HasColumnType("tinyint")
                        .HasColumnName("requi_status_id");

                    b.Property<string>("StatusName")
                        .IsRequired()
                        .HasMaxLength(25)
                        .IsUnicode(false)
                        .HasColumnType("varchar(25)")
                        .HasColumnName("status_name");

                    b.HasKey("RequiStatusId")
                        .HasName("PK__Requirem__8F69E6AD82F8094D");

                    b.ToTable("Requirement_status", (string)null);
                });

            modelBuilder.Entity("WebService.Models.Role", b =>
                {
                    b.Property<short>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint")
                        .HasColumnName("role_ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<short>("RoleId"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("name");

                    b.HasKey("RoleId");

                    b.HasIndex(new[] { "Name" }, "UQ__Role__72E12F1B76375EA3")
                        .IsUnique();

                    b.ToTable("Role", (string)null);
                });

            modelBuilder.Entity("WebService.Models.Account", b =>
                {
                    b.HasOne("WebService.Models.Department", "DepartmentNavigation")
                        .WithMany("Accounts")
                        .HasForeignKey("Department")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK__Account__departm__5070F446");

                    b.HasOne("WebService.Models.Role", "RoleNavigation")
                        .WithMany("Accounts")
                        .HasForeignKey("Role")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK__Account__role__4F7CD00D");

                    b.Navigation("DepartmentNavigation");

                    b.Navigation("RoleNavigation");
                });

            modelBuilder.Entity("WebService.Models.Concept", b =>
                {
                    b.HasOne("WebService.Models.Requirement", "Requi")
                        .WithMany("Concepts")
                        .HasForeignKey("RequiId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("FK__Concept__requi_i__6754599E");

                    b.HasOne("WebService.Models.Item", "SupllyCodeNavigation")
                        .WithMany("Concepts")
                        .HasForeignKey("SupllyCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("FK__Concept__suplly___68487DD7");

                    b.Navigation("Requi");

                    b.Navigation("SupllyCodeNavigation");
                });

            modelBuilder.Entity("WebService.Models.Item", b =>
                {
                    b.HasOne("WebService.Models.Category", "CategoryNavigation")
                        .WithMany("Items")
                        .HasForeignKey("Category")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("FK__Item__category__5AEE82B9");

                    b.HasOne("WebService.Models.Location", "LocationNavigation")
                        .WithMany("Items")
                        .HasForeignKey("Location")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("FK__Item__location__5CD6CB2B");

                    b.HasOne("WebService.Models.Material", "MaterialNavigation")
                        .WithMany("Items")
                        .HasForeignKey("Material")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("FK__Item__material__5DCAEF64");

                    b.HasOne("WebService.Models.Measure", "MeasureNavigation")
                        .WithMany("Items")
                        .HasForeignKey("Measure")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("FK__Item__measure__5BE2A6F2");

                    b.Navigation("CategoryNavigation");

                    b.Navigation("LocationNavigation");

                    b.Navigation("MaterialNavigation");

                    b.Navigation("MeasureNavigation");
                });

            modelBuilder.Entity("WebService.Models.Requirement", b =>
                {
                    b.HasOne("WebService.Models.Account", "AccountNavigation")
                        .WithMany("RequirementAccountNavigations")
                        .HasForeignKey("Account")
                        .HasConstraintName("FK__Requireme__accou__628FA481");

                    b.HasOne("WebService.Models.Account", "ResponsableNavigation")
                        .WithMany("RequirementResponsableNavigations")
                        .HasForeignKey("Responsable")
                        .HasConstraintName("FK__Requireme__respo__6477ECF3");

                    b.HasOne("WebService.Models.RequirementStatus", "StatusNavigation")
                        .WithMany("Requirements")
                        .HasForeignKey("Status")
                        .HasConstraintName("FK__Requireme__statu__6383C8BA");

                    b.Navigation("AccountNavigation");

                    b.Navigation("ResponsableNavigation");

                    b.Navigation("StatusNavigation");
                });

            modelBuilder.Entity("WebService.Models.Account", b =>
                {
                    b.Navigation("RequirementAccountNavigations");

                    b.Navigation("RequirementResponsableNavigations");
                });

            modelBuilder.Entity("WebService.Models.Category", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("WebService.Models.Department", b =>
                {
                    b.Navigation("Accounts");
                });

            modelBuilder.Entity("WebService.Models.Item", b =>
                {
                    b.Navigation("Concepts");
                });

            modelBuilder.Entity("WebService.Models.Location", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("WebService.Models.Material", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("WebService.Models.Measure", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("WebService.Models.Requirement", b =>
                {
                    b.Navigation("Concepts");
                });

            modelBuilder.Entity("WebService.Models.RequirementStatus", b =>
                {
                    b.Navigation("Requirements");
                });

            modelBuilder.Entity("WebService.Models.Role", b =>
                {
                    b.Navigation("Accounts");
                });
#pragma warning restore 612, 618
        }
    }
}
