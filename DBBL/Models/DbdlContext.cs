using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DBBL.Models;

public partial class DbdlContext : DbContext
{
    public DbdlContext()
    {
    }

    public DbdlContext(DbContextOptions<DbdlContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CongTy> CongTies { get; set; }

    public virtual DbSet<NhanVien> NhanViens { get; set; }

    public virtual DbSet<SanPham> SanPhams { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOP-AHUR737H;Database=DBDL;Trusted_Connection=True;encrypt=false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CongTy>(entity =>
        {
            entity.HasKey(e => e.IdCt);

            entity.ToTable("CONG_TY");

            entity.Property(e => e.IdCt)
                .HasMaxLength(50)
                .HasColumnName("ID_CT");
            entity.Property(e => e.EmailNql)
                .HasMaxLength(150)
                .HasColumnName("Email_NQL");
            entity.Property(e => e.Mk).HasColumnName("MK");
            entity.Property(e => e.SđtNql)
                .HasMaxLength(100)
                .HasColumnName("SĐT_NQL");
            entity.Property(e => e.TenCt)
                .HasMaxLength(150)
                .HasColumnName("Ten_CT");
            entity.Property(e => e.TenNql)
                .HasMaxLength(150)
                .HasColumnName("Ten_NQL");
        });

        modelBuilder.Entity<NhanVien>(entity =>
        {
            entity.HasKey(e => e.IdNv);

            entity.ToTable("NHAN_VIEN");

            entity.Property(e => e.IdNv)
                .HasMaxLength(50)
                .HasColumnName("ID_NV");
            entity.Property(e => e.EmailNv)
                .HasMaxLength(150)
                .HasColumnName("EMAIL_NV");
            entity.Property(e => e.IdCt)
                .HasMaxLength(50)
                .HasColumnName("ID_CT");
            entity.Property(e => e.Mk).HasColumnName("MK");
            entity.Property(e => e.SđtNv)
                .HasMaxLength(100)
                .HasColumnName("SĐT_NV");
            entity.Property(e => e.TenNv)
                .HasMaxLength(150)
                .HasColumnName("Ten_NV");
            entity.Property(e => e.Trangthai).HasColumnName("trangthai");
        });

        modelBuilder.Entity<SanPham>(entity =>
        {
            entity.HasKey(e => e.IdSp);

            entity.ToTable("SAN_PHAM");

            entity.Property(e => e.IdSp)
                .HasMaxLength(50)
                .HasColumnName("ID_SP");
            entity.Property(e => e.GioiHan)
                .HasMaxLength(20)
                .IsFixedLength()
                .HasColumnName("GIOI_HAN");
            entity.Property(e => e.IdCt)
                .HasMaxLength(50)
                .HasColumnName("ID_CT");
            entity.Property(e => e.SlHt)
                .HasMaxLength(20)
                .IsFixedLength()
                .HasColumnName("SL_HT");
            entity.Property(e => e.TenSp)
                .HasMaxLength(150)
                .HasColumnName("Ten_SP");
            entity.Property(e => e.Trangthai).HasColumnName("trangthai");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
