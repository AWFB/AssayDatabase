﻿// <auto-generated />
using System;
using AssayDatabaseAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AssayDatabaseAPI.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.0");

            modelBuilder.Entity("AssayDatabaseAPI.Models.AppUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("FullName")
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("BLOB");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("BLOB");

                    b.Property<string>("UserName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("AssayDatabaseAPI.Models.Assay", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AccreditationNumber")
                        .HasColumnType("TEXT");

                    b.Property<string>("AddressLineOne")
                        .HasColumnType("TEXT");

                    b.Property<string>("AddressLineTwo")
                        .HasColumnType("TEXT");

                    b.Property<int>("AppUserId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("AutoComment")
                        .HasColumnType("TEXT");

                    b.Property<string>("City")
                        .HasColumnType("TEXT");

                    b.Property<string>("Comments")
                        .HasColumnType("TEXT");

                    b.Property<string>("ContactName")
                        .HasColumnType("TEXT");

                    b.Property<string>("ContactNumber")
                        .HasColumnType("TEXT");

                    b.Property<string>("Country")
                        .HasColumnType("TEXT");

                    b.Property<string>("County")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<bool>("EqaScheme")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("LastUpdated")
                        .HasColumnType("TEXT");

                    b.Property<string>("NameOfTest")
                        .HasColumnType("TEXT");

                    b.Property<bool>("NpexSupport")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PostCode")
                        .HasColumnType("TEXT");

                    b.Property<string>("SampleType")
                        .HasColumnType("TEXT");

                    b.Property<string>("SampleVolume")
                        .HasColumnType("TEXT");

                    b.Property<string>("StorageConditions")
                        .HasColumnType("TEXT");

                    b.Property<string>("TestNameAlias")
                        .HasColumnType("TEXT");

                    b.Property<string>("TransportConditions")
                        .HasColumnType("TEXT");

                    b.Property<string>("TurnAroundTime")
                        .HasColumnType("TEXT");

                    b.Property<bool>("UkasAccredited")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.ToTable("Assays");
                });

            modelBuilder.Entity("AssayDatabaseAPI.Models.Assay", b =>
                {
                    b.HasOne("AssayDatabaseAPI.Models.AppUser", "AppUser")
                        .WithMany("Assays")
                        .HasForeignKey("AppUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppUser");
                });

            modelBuilder.Entity("AssayDatabaseAPI.Models.AppUser", b =>
                {
                    b.Navigation("Assays");
                });
#pragma warning restore 612, 618
        }
    }
}
