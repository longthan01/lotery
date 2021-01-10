using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace Crawler.Models
{
    public partial class LoteryContext : DbContext
    {
        private readonly IConfiguration configuration;


        static LoteryContext()
        {
            NpgsqlConnection.GlobalTypeMapper.MapEnum<LoteryTypes>();
        }
        public LoteryContext()
        {
            this.configuration = new ConfigurationBuilder()
               .SetBasePath(AppContext.BaseDirectory)
               .AddJsonFile("appsettings.json")
               .Build();
        }

        public LoteryContext(DbContextOptions<LoteryContext> options)
            : base(options)
        {

            this.configuration = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
        }

        public virtual DbSet<Crawlerlog> Crawlerlog { get; set; }
        public virtual DbSet<Crawlingsettings> Crawlingsettings { get; set; }
        public virtual DbSet<Crawlingstate> Crawlingstate { get; set; }
        public virtual DbSet<Lotteryinfo> Lotteryinfo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseNpgsql(configuration.GetConnectionString("LoteryDatabase"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresEnum<LoteryTypes>();
            modelBuilder.HasPostgresExtension("uuid-ossp");

            modelBuilder.Entity<Crawlerlog>(entity =>
            {
                entity.ToTable("crawlerlog");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("uuid_generate_v4()");

                entity.Property(e => e.Lastrun)
                    .HasColumnName("lastrun")
                    .HasColumnType("timestamp(3) without time zone");

                entity.Property(e => e.Sourceurl)
                    .IsRequired()
                    .HasColumnName("sourceurl")
                    .HasMaxLength(1024);
            });

            modelBuilder.Entity<Crawlingsettings>(entity =>
            {
                entity.ToTable("crawlingsettings");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("uuid_generate_v4()");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(100);

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasMaxLength(100);

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasColumnName("value")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Crawlingstate>(entity =>
            {
                entity.ToTable("crawlingstate");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("uuid_generate_v4()");

                entity.Property(e => e.Lastdate)
                    .HasColumnName("lastdate")
                    .HasColumnType("timestamp(3) without time zone");
            });

            modelBuilder.Entity<Lotteryinfo>(entity =>
            {
                entity.ToTable("lotteryinfo");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("uuid_generate_v4()");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("createdAt")
                    .HasColumnType("timestamp(3) without time zone");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("timestamp(3) without time zone");

                entity.Property(e => e.Matchtype).HasColumnName("matchtype");

                entity.Property(e => e.Number)
                    .HasColumnName("number")
                    .HasMaxLength(512);

                entity.Property(e => e.Province)
                    .HasColumnName("province")
                    .HasMaxLength(512);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updatedAt")
                    .HasColumnType("timestamp(3) without time zone");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
