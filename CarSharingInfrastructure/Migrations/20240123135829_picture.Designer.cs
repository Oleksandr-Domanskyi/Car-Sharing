﻿// <auto-generated />
using System;
using CarSharingInfrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CarSharingInfrastructure.Migrations
{
    [DbContext(typeof(CarSharingDbContext))]
    [Migration("20240123135829_picture")]
    partial class picture
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CarSharingDomain.DomainModels.CarProfileModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("PricePerDay")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("CarProfileModels");
                });

            modelBuilder.Entity("CarSharingDomain.DomainModels.Image", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CarProfileId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CarProfileModelId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte[]>("DataFile")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("FileType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CarProfileModelId");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("CarSharingDomain.DomainModels.CarProfileModel", b =>
                {
                    b.OwnsOne("CarSharingDomain.DomainModels.Chatacteristics", "Characteristics", b1 =>
                        {
                            b1.Property<Guid>("CarProfileModelId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Color")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Felgi")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Silnik")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Tapicerka")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("CarProfileModelId");

                            b1.ToTable("CarProfileModels");

                            b1.WithOwner()
                                .HasForeignKey("CarProfileModelId");
                        });

                    b.Navigation("Characteristics")
                        .IsRequired();
                });

            modelBuilder.Entity("CarSharingDomain.DomainModels.Image", b =>
                {
                    b.HasOne("CarSharingDomain.DomainModels.CarProfileModel", "CarProfileModel")
                        .WithMany("Image")
                        .HasForeignKey("CarProfileModelId");

                    b.Navigation("CarProfileModel");
                });

            modelBuilder.Entity("CarSharingDomain.DomainModels.CarProfileModel", b =>
                {
                    b.Navigation("Image");
                });
#pragma warning restore 612, 618
        }
    }
}