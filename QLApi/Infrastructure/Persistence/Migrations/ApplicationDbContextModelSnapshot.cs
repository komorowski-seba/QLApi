﻿// <auto-generated />
using System;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Domain.Entities.AirAnalysisContext.AirTest", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AirHistoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CalcDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DownloadDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("No2IndexLevel")
                        .HasColumnType("int");

                    b.Property<string>("No2IndexName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("O3IndexLevel")
                        .HasColumnType("int");

                    b.Property<string>("O3IndexName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Pm10IndexLevel")
                        .HasColumnType("int");

                    b.Property<string>("Pm10IndexName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Pm25IndexLevel")
                        .HasColumnType("int");

                    b.Property<string>("Pm25IndexName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("So2IndexLevel")
                        .HasColumnType("int");

                    b.Property<string>("So2IndexName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("StationId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("AirHistoryId");

                    b.ToTable("AirTests");
                });

            modelBuilder.Entity("Domain.Entities.AirAnalysisContext.AirTestHistory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<Guid?>("LastTestId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<long>("StationId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("AirTestHistories");
                });

            modelBuilder.Entity("Domain.Entities.ProvinceContext.City", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint");

                    b.Property<long>("CommuneId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CommuneId");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("Domain.Entities.ProvinceContext.Commune", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint");

                    b.Property<string>("CommuneName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DistrictName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ProvinceId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ProvinceId");

                    b.ToTable("Communes");
                });

            modelBuilder.Entity("Domain.Entities.ProvinceContext.Province", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Provinces");
                });

            modelBuilder.Entity("Domain.Entities.ProvinceContext.Station", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint");

                    b.Property<string>("AddressStreet")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("CityId")
                        .HasColumnType("bigint");

                    b.Property<string>("GegrLat")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GegrLon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StationName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("Stations");
                });

            modelBuilder.Entity("Domain.Entities.AirAnalysisContext.AirTest", b =>
                {
                    b.HasOne("Domain.Entities.AirAnalysisContext.AirTestHistory", "AirHistory")
                        .WithMany("AirTests")
                        .HasForeignKey("AirHistoryId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("AirHistory");
                });

            modelBuilder.Entity("Domain.Entities.ProvinceContext.City", b =>
                {
                    b.HasOne("Domain.Entities.ProvinceContext.Commune", "Commune")
                        .WithMany("Cities")
                        .HasForeignKey("CommuneId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Commune");
                });

            modelBuilder.Entity("Domain.Entities.ProvinceContext.Commune", b =>
                {
                    b.HasOne("Domain.Entities.ProvinceContext.Province", "Province")
                        .WithMany("Communes")
                        .HasForeignKey("ProvinceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Province");
                });

            modelBuilder.Entity("Domain.Entities.ProvinceContext.Station", b =>
                {
                    b.HasOne("Domain.Entities.ProvinceContext.City", "City")
                        .WithMany("Stations")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("Domain.Entities.AirAnalysisContext.AirTestHistory", b =>
                {
                    b.Navigation("AirTests");
                });

            modelBuilder.Entity("Domain.Entities.ProvinceContext.City", b =>
                {
                    b.Navigation("Stations");
                });

            modelBuilder.Entity("Domain.Entities.ProvinceContext.Commune", b =>
                {
                    b.Navigation("Cities");
                });

            modelBuilder.Entity("Domain.Entities.ProvinceContext.Province", b =>
                {
                    b.Navigation("Communes");
                });
#pragma warning restore 612, 618
        }
    }
}
