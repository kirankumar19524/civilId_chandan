using System;
using System.Collections.Generic;
using CivilIDWeb.DB.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CivilIDWeb.DB.APPContext
{
    public partial class PACIDBContext : DbContext
    {
        public PACIDBContext()
        {
        }

        public PACIDBContext(DbContextOptions<PACIDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<PacirequestLog> PacirequestLogs { get; set; } = null!;

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Data Source=LAPTOP-L0G2P9H5\\SQLEXPRESS;Initial Catalog=PACIDB;Integrated Security=True");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PacirequestLog>(entity =>
            {
                entity.HasKey(e => e.LogId);

                entity.ToTable("PACIRequestLog");

                entity.Property(e => e.CivilId).HasMaxLength(50);

                entity.Property(e => e.ErrorCode).HasMaxLength(50);

                entity.Property(e => e.RequestDateTime).HasColumnType("datetime");

                entity.Property(e => e.RequestId).HasMaxLength(200);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
