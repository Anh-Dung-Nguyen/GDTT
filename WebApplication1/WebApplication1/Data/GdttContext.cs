using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data;

public partial class GdttContext : DbContext
{
    public GdttContext()
    {
    }

    public GdttContext(DbContextOptions<GdttContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DmGaRa> DmGaRas { get; set; }
    public virtual DbSet<DmDonvi> DmDonvis { get; set; }
    public virtual DbSet<DmPquyenKyh> DmPquyenKyhs { get; set; }
    public virtual DbSet<DmUser> DmUsers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DmGaRa>(entity =>
        {
            entity.HasKey(e => e.MaGara);
            entity.ToTable("dm_ga_ra");

            entity.Property(e => e.DiaChi)
                .HasMaxLength(200)
                .HasColumnName("dia_chi");
            entity.Property(e => e.DiaChiXuong)
                .HasMaxLength(300)
                .HasDefaultValue("")
                .HasColumnName("dia_chi_xuong");
            entity.Property(e => e.DienThoaiGara)
                .HasMaxLength(50)
                .HasDefaultValue("")
                .HasColumnName("dien_thoai_gara");
            entity.Property(e => e.EmailGara)
                .HasMaxLength(100)
                .HasDefaultValue("")
                .HasColumnName("email_gara");
            entity.Property(e => e.GaraTthai).HasColumnName("gara_tthai");
            entity.Property(e => e.MaDonvi)
                .HasMaxLength(8)
                .HasColumnName("ma_donvi");
            entity.Property(e => e.MaGara)
                .HasMaxLength(11)
                .HasColumnName("ma_gara");
            entity.Property(e => e.MaUsercNhat)
                .HasMaxLength(50)
                .HasDefaultValue("")
                .HasColumnName("ma_userc_nhat");
            entity.Property(e => e.NgayCnhat)
                .HasColumnType("smalldatetime")
                .HasColumnName("ngay_cnhat");
            entity.Property(e => e.QuanHuyen)
                .HasMaxLength(100)
                .HasDefaultValue("")
                .HasColumnName("quan_huyen");
            entity.Property(e => e.TenGara)
                .HasMaxLength(150)
                .HasColumnName("ten_gara");
            entity.Property(e => e.TenTat)
                .HasMaxLength(50)
                .HasDefaultValue("")
                .HasColumnName("ten_tat");
            entity.Property(e => e.TenTinh)
                .HasMaxLength(100)
                .HasDefaultValue("")
                .HasColumnName("ten_tinh");
            entity.Property(e => e.TyleggPhutung)
                .HasDefaultValue(0.00m)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("tylegg_phutung");
            entity.Property(e => e.TyleggSuachua)
                .HasDefaultValue(0.00m)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("tylegg_suachua");
        });

        modelBuilder.Entity<DmDonvi>(entity =>
        {
            entity.HasKey(e => e.MaDonvi);

            entity.ToTable("dm_donvi");

            entity.Property(e => e.MaDonvi)
                .HasMaxLength(8)
                .HasColumnName("ma_donvi");
            entity.Property(e => e.MaDvchuquan)
                .HasMaxLength(8)
                .HasDefaultValue("")
                .HasColumnName("ma_dvchuquan");
            entity.Property(e => e.MaKh)
                .HasMaxLength(11)
                .HasDefaultValue("")
                .HasColumnName("ma_kh");
            entity.Property(e => e.TenDonvi)
                .HasMaxLength(50)
                .HasDefaultValue("")
                .HasColumnName("ten_donvi");
        });

        modelBuilder.Entity<DmPquyenKyh>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("dm_pquyen_kyhs");

            entity.Property(e => e.IsActive).HasColumnName("isActive");
            entity.Property(e => e.MaSp)
                .HasMaxLength(150)
                .HasDefaultValue("")
                .HasColumnName("ma_sp");
            entity.Property(e => e.MaUser)
                .HasMaxLength(250)
                .HasDefaultValue("")
                .HasColumnName("ma_user");
            entity.Property(e => e.MaUserCapnhat)
                .HasMaxLength(100)
                .HasDefaultValue("")
                .HasColumnName("ma_user_capnhat");
            entity.Property(e => e.NgayCnhat)
                .HasColumnType("smalldatetime")
                .HasColumnName("ngay_cnhat");
            entity.Property(e => e.PrKey)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("pr_key");
            entity.Property(e => e.SoTien)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("so_tien");
        });

        modelBuilder.Entity<DmUser>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.ToTable("dm_user");

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.Dienthoai)
                .HasMaxLength(100)
                .HasColumnName("dienthoai");
            entity.Property(e => e.IsActive).HasDefaultValue(false);
            entity.Property(e => e.IsActiveGddk).HasColumnName("IsActive_gddk");
            entity.Property(e => e.IsActiveGqkn).HasColumnName("IsActive_gqkn");
            entity.Property(e => e.IsActiveKytt).HasColumnName("IsActive_kytt");
            entity.Property(e => e.IsGdvHotro).HasColumnName("isGdv_hotro");
            entity.Property(e => e.IsactiveChkc).HasColumnName("isactive_chkc");
            entity.Property(e => e.LoaiCbo)
                .HasMaxLength(2)
                .HasDefaultValue("")
                .HasColumnName("loai_cbo");
            entity.Property(e => e.LoaiUser).HasColumnName("loai_user");
            entity.Property(e => e.MaDonvi)
                .HasMaxLength(50)
                .HasColumnName("ma_donvi");
            entity.Property(e => e.MaDonviPquyen)
                .HasMaxLength(150)
                .HasDefaultValue("")
                .HasColumnName("ma_donvi_pquyen");
            entity.Property(e => e.MaUser)
                .HasMaxLength(100)
                .HasColumnName("ma_user");
            entity.Property(e => e.MaUserCapnhat)
                .HasMaxLength(100)
                .HasDefaultValue("")
                .HasColumnName("ma_user_capnhat");
            entity.Property(e => e.MaUserPias)
                .HasMaxLength(20)
                .HasDefaultValue("")
                .HasColumnName("ma_user_pias");
            entity.Property(e => e.Mail).HasMaxLength(100);
            entity.Property(e => e.NgayCnhat)
                .HasColumnType("smalldatetime")
                .HasColumnName("ngay_cnhat");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .HasDefaultValue("")
                .HasColumnName("password");
            entity.Property(e => e.PhanQuyen).HasColumnName("phan_quyen");
            entity.Property(e => e.PquyenUplHinhAnh).HasColumnName("pquyen_upl_hinh_anh");
            entity.Property(e => e.TenUser)
                .HasMaxLength(100)
                .HasColumnName("ten_user");
        });

        OnModelCreatingPartial(modelBuilder);
    }
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
