﻿// <auto-generated />
using System;
using Crawler.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Crawler.Models.Migrations
{
    [DbContext(typeof(LoteryContext))]
    partial class LoteryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:Enum:lotery_types", "traditional,viet_lot")
                .HasAnnotation("Npgsql:PostgresExtension:uuid-ossp", ",,")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Crawler.Models.Crawlerlog", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<DateTime>("Lastrun")
                        .HasColumnName("lastrun")
                        .HasColumnType("timestamp(3) without time zone");

                    b.Property<string>("Sourceurl")
                        .IsRequired()
                        .HasColumnName("sourceurl")
                        .HasColumnType("character varying(1024)")
                        .HasMaxLength(1024);

                    b.HasKey("Id");

                    b.ToTable("crawlerlog");
                });

            modelBuilder.Entity("Crawler.Models.Crawlingsettings", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("character varying(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Type")
                        .HasColumnName("type")
                        .HasColumnType("character varying(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnName("value")
                        .HasColumnType("character varying(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("crawlingsettings");
                });

            modelBuilder.Entity("Crawler.Models.Crawlingstate", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<DateTime>("Lastdate")
                        .HasColumnName("lastdate")
                        .HasColumnType("timestamp(3) without time zone");

                    b.HasKey("Id");

                    b.ToTable("crawlingstate");
                });

            modelBuilder.Entity("Crawler.Models.Lotteryinfo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnName("createdAt")
                        .HasColumnType("timestamp(3) without time zone");

                    b.Property<DateTime?>("Date")
                        .HasColumnName("date")
                        .HasColumnType("timestamp(3) without time zone");

                    b.Property<int>("LoteryType")
                        .HasColumnType("integer");

                    b.Property<short?>("Matchtype")
                        .HasColumnName("matchtype")
                        .HasColumnType("smallint");

                    b.Property<string>("Number")
                        .HasColumnName("number")
                        .HasColumnType("character varying(512)")
                        .HasMaxLength(512);

                    b.Property<string>("Province")
                        .HasColumnName("province")
                        .HasColumnType("character varying(512)")
                        .HasMaxLength(512);

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnName("updatedAt")
                        .HasColumnType("timestamp(3) without time zone");

                    b.HasKey("Id");

                    b.ToTable("lotteryinfo");
                });
#pragma warning restore 612, 618
        }
    }
}
