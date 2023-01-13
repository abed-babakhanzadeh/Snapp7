﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Snapp.DataAccessLayer.Context;

#nullable disable

namespace Snapp.DataAccessLayer.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20221225195926_tbl-PriceType")]
    partial class tblPriceType
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Snapp.DataAccessLayer.Entities.Car", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("Snapp.DataAccessLayer.Entities.Color", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Colors");
                });

            modelBuilder.Entity("Snapp.DataAccessLayer.Entities.Driver", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Avatar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CarCode")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<Guid?>("CarId")
                        .IsRequired()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ColorId")
                        .IsRequired()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Img")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsConfirm")
                        .HasColumnType("bit");

                    b.Property<string>("NationalCode")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Tel")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("UserId");

                    b.HasIndex("CarId");

                    b.HasIndex("ColorId");

                    b.ToTable("Drivers");
                });

            modelBuilder.Entity("Snapp.DataAccessLayer.Entities.PriceType", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("End")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<long>("Price")
                        .HasColumnType("bigint");

                    b.Property<int>("Start")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("PriceTypes");
                });

            modelBuilder.Entity("Snapp.DataAccessLayer.Entities.RateType", b =>
                {
                    b.Property<Guid>("id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<bool>("Ok")
                        .HasColumnType("bit");

                    b.Property<int>("ViewOrder")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("RateTypes");
                });

            modelBuilder.Entity("Snapp.DataAccessLayer.Entities.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Snapp.DataAccessLayer.Entities.Setting", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("About")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Desc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Fax")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<bool>("IsDistance")
                        .HasColumnType("bit");

                    b.Property<bool>("IsWeatherPrice")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Tel")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("Terms")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Settings");
                });

            modelBuilder.Entity("Snapp.DataAccessLayer.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Token")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<long>("Wallet")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Snapp.DataAccessLayer.Entities.UserDetail", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BirthDate")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Date")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("FullName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Time")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("UserId");

                    b.ToTable("UserDetails");
                });

            modelBuilder.Entity("Snapp.DataAccessLayer.Entities.Driver", b =>
                {
                    b.HasOne("Snapp.DataAccessLayer.Entities.Car", "Car")
                        .WithMany("Drivers")
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Snapp.DataAccessLayer.Entities.Color", "Color")
                        .WithMany("Drivers")
                        .HasForeignKey("ColorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Snapp.DataAccessLayer.Entities.User", "User")
                        .WithOne("Driver")
                        .HasForeignKey("Snapp.DataAccessLayer.Entities.Driver", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");

                    b.Navigation("Color");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Snapp.DataAccessLayer.Entities.User", b =>
                {
                    b.HasOne("Snapp.DataAccessLayer.Entities.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Snapp.DataAccessLayer.Entities.UserDetail", b =>
                {
                    b.HasOne("Snapp.DataAccessLayer.Entities.User", "User")
                        .WithOne("UserDetail")
                        .HasForeignKey("Snapp.DataAccessLayer.Entities.UserDetail", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Snapp.DataAccessLayer.Entities.Car", b =>
                {
                    b.Navigation("Drivers");
                });

            modelBuilder.Entity("Snapp.DataAccessLayer.Entities.Color", b =>
                {
                    b.Navigation("Drivers");
                });

            modelBuilder.Entity("Snapp.DataAccessLayer.Entities.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("Snapp.DataAccessLayer.Entities.User", b =>
                {
                    b.Navigation("Driver")
                        .IsRequired();

                    b.Navigation("UserDetail")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}