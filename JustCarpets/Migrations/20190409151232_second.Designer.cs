﻿// <auto-generated />
using System;
using JustCarpets.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace JustCarpets.Migrations
{
    [DbContext(typeof(JustCarpetDbContext))]
    [Migration("20190409151232_second")]
    partial class second
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("JustCarpets.Data.Entities.CarpetColourPalletEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CarpetEntityId");

                    b.Property<int>("CarpetId");

                    b.Property<string>("DisplayName");

                    b.Property<string>("Hex");

                    b.Property<string>("RGB");

                    b.HasKey("Id");

                    b.HasIndex("CarpetEntityId");

                    b.HasIndex("CarpetId");

                    b.ToTable("CarpetColourPallet");
                });

            modelBuilder.Entity("JustCarpets.Data.Entities.CarpetEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CompanyEntityId");

                    b.Property<string>("Description");

                    b.Property<int>("DurabilityFactor");

                    b.Property<string>("Name");

                    b.Property<bool>("PetFriendly");

                    b.Property<decimal>("PriceM2");

                    b.Property<int>("Style");

                    b.HasKey("Id");

                    b.HasIndex("CompanyEntityId");

                    b.ToTable("Carpet");
                });

            modelBuilder.Entity("JustCarpets.Data.Entities.CarpetImageEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AlternateText");

                    b.Property<int?>("CarpetEntityId");

                    b.Property<int>("CarpetId");

                    b.Property<string>("ImageName");

                    b.Property<int>("ImageType");

                    b.Property<string>("Link");

                    b.HasKey("Id");

                    b.HasIndex("CarpetEntityId");

                    b.HasIndex("CarpetId");

                    b.ToTable("CarpetImage");
                });

            modelBuilder.Entity("JustCarpets.Data.Entities.CarpetPropertyEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BulletPoint");

                    b.Property<int?>("CarpetEntityId");

                    b.Property<int>("CarpetId");

                    b.HasKey("Id");

                    b.HasIndex("CarpetEntityId");

                    b.HasIndex("CarpetId");

                    b.ToTable("CarpetPropertys");
                });

            modelBuilder.Entity("JustCarpets.Data.Entities.CarpetSizeOptionEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CarpetEntityId");

                    b.Property<int>("CarpetId");

                    b.Property<int>("Length");

                    b.Property<int>("M2");

                    b.Property<int>("Width");

                    b.HasKey("Id");

                    b.HasIndex("CarpetEntityId");

                    b.HasIndex("CarpetId");

                    b.ToTable("CarpetSizeOptionEntity");
                });

            modelBuilder.Entity("JustCarpets.Data.Entities.CompanyEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.Property<string>("Telephone");

                    b.Property<string>("Website");

                    b.HasKey("Id");

                    b.ToTable("Company");
                });

            modelBuilder.Entity("JustCarpets.Data.Entities.CompanyLocationEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<int>("CompanyId");

                    b.Property<string>("LocationName");

                    b.Property<int>("Type");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("CompanyLocations");
                });

            modelBuilder.Entity("JustCarpets.Data.Entities.CustomerEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<DateTime>("AgreedDataProtection");

                    b.Property<DateTime>("AgreedMarketing");

                    b.Property<DateTime>("AgreedTerms");

                    b.Property<DateTime>("Created");

                    b.Property<string>("EmailAddress");

                    b.Property<string>("MacAddress");

                    b.Property<string>("Name");

                    b.Property<string>("TelephoneNumber");

                    b.HasKey("Id");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("JustCarpets.Data.Entities.CustomerOrderEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created");

                    b.Property<int>("CustomerId");

                    b.Property<int?>("InstallerDate");

                    b.Property<int?>("InstallerReviewId");

                    b.Property<DateTime>("ReviewDate");

                    b.Property<decimal>("TotalPrice");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("CustomerOrder");
                });

            modelBuilder.Entity("JustCarpets.Data.Entities.InstallerAppointmentsEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("AM");

                    b.Property<DateTime>("Date");

                    b.Property<int>("InstallerId");

                    b.Property<int>("OrderId");

                    b.HasKey("Id");

                    b.HasIndex("InstallerId");

                    b.HasIndex("OrderId");

                    b.ToTable("InstallerAppointment");
                });

            modelBuilder.Entity("JustCarpets.Data.Entities.InstallerRatesEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CompanyLocationId");

                    b.Property<decimal>("HalfDayRate");

                    b.Property<int>("Type");

                    b.HasKey("Id");

                    b.HasIndex("CompanyLocationId");

                    b.ToTable("InstallerRates");
                });

            modelBuilder.Entity("JustCarpets.Data.Entities.InstallerReviewEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CleanupFactor");

                    b.Property<string>("Comments");

                    b.Property<int>("CustomerOrderId");

                    b.Property<int>("InstallerId");

                    b.Property<int>("PunctualityFactor");

                    b.Property<int>("QualityFactor");

                    b.Property<int>("TimeKeepingFactor");

                    b.HasKey("Id");

                    b.HasIndex("CustomerOrderId");

                    b.HasIndex("InstallerId");

                    b.ToTable("InstallerReview");
                });

            modelBuilder.Entity("JustCarpets.Data.Entities.OrderLineEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CarpetId");

                    b.Property<int>("CarpetSizeOptionId");

                    b.Property<int>("CustomerOrderId");

                    b.Property<int>("Qty");

                    b.Property<int?>("SizeOptionId");

                    b.HasKey("Id");

                    b.HasIndex("CarpetId");

                    b.HasIndex("CustomerOrderId");

                    b.HasIndex("SizeOptionId");

                    b.ToTable("OrderLine");
                });

            modelBuilder.Entity("JustCarpets.Data.Entities.CarpetColourPalletEntity", b =>
                {
                    b.HasOne("JustCarpets.Data.Entities.CarpetEntity")
                        .WithMany("CarpetColourPallets")
                        .HasForeignKey("CarpetEntityId");

                    b.HasOne("JustCarpets.Data.Entities.CarpetEntity", "Carpet")
                        .WithMany()
                        .HasForeignKey("CarpetId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("JustCarpets.Data.Entities.CarpetEntity", b =>
                {
                    b.HasOne("JustCarpets.Data.Entities.CompanyEntity")
                        .WithMany("Carpets")
                        .HasForeignKey("CompanyEntityId");
                });

            modelBuilder.Entity("JustCarpets.Data.Entities.CarpetImageEntity", b =>
                {
                    b.HasOne("JustCarpets.Data.Entities.CarpetEntity")
                        .WithMany("Images")
                        .HasForeignKey("CarpetEntityId");

                    b.HasOne("JustCarpets.Data.Entities.CarpetEntity", "Carpet")
                        .WithMany()
                        .HasForeignKey("CarpetId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("JustCarpets.Data.Entities.CarpetPropertyEntity", b =>
                {
                    b.HasOne("JustCarpets.Data.Entities.CarpetEntity")
                        .WithMany("Propertys")
                        .HasForeignKey("CarpetEntityId");

                    b.HasOne("JustCarpets.Data.Entities.CarpetEntity", "Carpet")
                        .WithMany()
                        .HasForeignKey("CarpetId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("JustCarpets.Data.Entities.CarpetSizeOptionEntity", b =>
                {
                    b.HasOne("JustCarpets.Data.Entities.CarpetEntity")
                        .WithMany("Options")
                        .HasForeignKey("CarpetEntityId");

                    b.HasOne("JustCarpets.Data.Entities.CarpetEntity", "Carpet")
                        .WithMany()
                        .HasForeignKey("CarpetId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("JustCarpets.Data.Entities.CompanyLocationEntity", b =>
                {
                    b.HasOne("JustCarpets.Data.Entities.CompanyEntity", "Company")
                        .WithMany("CompanyLocations")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("JustCarpets.Data.Entities.CustomerOrderEntity", b =>
                {
                    b.HasOne("JustCarpets.Data.Entities.CustomerEntity", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("JustCarpets.Data.Entities.InstallerAppointmentsEntity", b =>
                {
                    b.HasOne("JustCarpets.Data.Entities.CompanyLocationEntity", "Installer")
                        .WithMany()
                        .HasForeignKey("InstallerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("JustCarpets.Data.Entities.CustomerOrderEntity", "Order")
                        .WithMany()
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("JustCarpets.Data.Entities.InstallerRatesEntity", b =>
                {
                    b.HasOne("JustCarpets.Data.Entities.CompanyLocationEntity", "CompanyLocation")
                        .WithMany("Rates")
                        .HasForeignKey("CompanyLocationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("JustCarpets.Data.Entities.InstallerReviewEntity", b =>
                {
                    b.HasOne("JustCarpets.Data.Entities.CustomerOrderEntity", "CustomerOrder")
                        .WithMany()
                        .HasForeignKey("CustomerOrderId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("JustCarpets.Data.Entities.CompanyLocationEntity", "Installer")
                        .WithMany()
                        .HasForeignKey("InstallerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("JustCarpets.Data.Entities.OrderLineEntity", b =>
                {
                    b.HasOne("JustCarpets.Data.Entities.CarpetEntity", "Carpet")
                        .WithMany()
                        .HasForeignKey("CarpetId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("JustCarpets.Data.Entities.CustomerOrderEntity", "CustomerOrder")
                        .WithMany("OrderLines")
                        .HasForeignKey("CustomerOrderId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("JustCarpets.Data.Entities.CarpetSizeOptionEntity", "SizeOption")
                        .WithMany()
                        .HasForeignKey("SizeOptionId");
                });
#pragma warning restore 612, 618
        }
    }
}
