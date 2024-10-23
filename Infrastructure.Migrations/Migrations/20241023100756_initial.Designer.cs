﻿// <auto-generated />
using System;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20241023100756_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.Blog", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<Guid>("created_by_id")
                        .HasColumnType("char(36)");

                    b.Property<DateTime?>("last_update_date")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("record_date")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("updated_by_id")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("created_by_id");

                    b.HasIndex("updated_by_id");

                    b.ToTable("Blogs");
                });

            modelBuilder.Entity("Domain.Entities.RoleAggregate.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = new Guid("20de9c25-cd28-47cf-b205-ea19430e00f2"),
                            Description = "Super Admin",
                            Name = "SuperAdmin"
                        });
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("longtext");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("a658cdb4-4e8b-40eb-9385-863880cddd60"),
                            Email = "example@gmail.com",
                            FirstName = "name",
                            IsDeleted = false,
                            LastName = "surname",
                            PasswordHash = "AQAAAAEACSfAAAAAEG+J3m+aq5Ze7Da3Vmcm6OD5Dj2NjAHDHrr/LdIon4TEPCCIyZDkPSyAw/1dSCBrDg==",
                            RoleId = new Guid("20de9c25-cd28-47cf-b205-ea19430e00f2")
                        });
                });

            modelBuilder.Entity("Domain.Entities.Blog", b =>
                {
                    b.HasOne("Domain.Entities.User", "created_by")
                        .WithMany()
                        .HasForeignKey("created_by_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.User", "updated_by")
                        .WithMany()
                        .HasForeignKey("updated_by_id");

                    b.Navigation("created_by");

                    b.Navigation("updated_by");
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.HasOne("Domain.Entities.RoleAggregate.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Domain.Entities.RoleAggregate.Role", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}