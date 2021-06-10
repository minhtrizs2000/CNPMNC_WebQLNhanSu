using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Web_QLNS.Models
{
    public partial class QLNSContext : DbContext
    {
        public QLNSContext()
        {
        }

        public QLNSContext(DbContextOptions<QLNSContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ChamCong> ChamCongs { get; set; }
        public virtual DbSet<ChucVu> ChucVus { get; set; }
        public virtual DbSet<HopDongLaoDong> HopDongLaoDongs { get; set; }
        public virtual DbSet<KhenThuong> KhenThuongs { get; set; }
        public virtual DbSet<KyLuat> KyLuats { get; set; }
        public virtual DbSet<LoaiKhenThuong> LoaiKhenThuongs { get; set; }
        public virtual DbSet<LoaiKyLuat> LoaiKyLuats { get; set; }
        public virtual DbSet<NhanVien> NhanViens { get; set; }
        public virtual DbSet<PhongBan> PhongBans { get; set; }
        public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-18VI6MD;Database=QLNS;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<ChamCong>(entity =>
            {
                entity.HasKey(e => new { e.Ngay, e.Idnv });

                entity.ToTable("ChamCong");

                entity.Property(e => e.Ngay).HasColumnType("date");

                entity.Property(e => e.Idnv).HasColumnName("IDNV");

                entity.HasOne(d => d.IdnvNavigation)
                    .WithMany(p => p.ChamCongs)
                    .HasForeignKey(d => d.Idnv)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ChamCong_NhanVien");
            });

            modelBuilder.Entity<ChucVu>(entity =>
            {
                entity.HasKey(e => e.Idcv);

                entity.ToTable("ChucVu");

                entity.Property(e => e.Idcv).HasColumnName("IDCV");

                entity.Property(e => e.TenCv)
                    .HasMaxLength(50)
                    .HasColumnName("TenCV");
            });

            modelBuilder.Entity<HopDongLaoDong>(entity =>
            {
                entity.HasKey(e => e.Idnv)
                    .HasName("PK_HopDongLaoDong_1");

                entity.ToTable("HopDongLaoDong");

                entity.Property(e => e.Idnv)
                    .ValueGeneratedNever()
                    .HasColumnName("IDNV");

                entity.Property(e => e.LuongCb).HasColumnName("LuongCB");

                entity.Property(e => e.NgayKy).HasColumnType("date");

                entity.HasOne(d => d.IdnvNavigation)
                    .WithOne(p => p.HopDongLaoDong)
                    .HasForeignKey<HopDongLaoDong>(d => d.Idnv)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HopDongLaoDong_NhanVien");
            });

            modelBuilder.Entity<KhenThuong>(entity =>
            {
                entity.HasKey(e => e.Idkt);

                entity.ToTable("KhenThuong");

                entity.Property(e => e.Idkt).HasColumnName("IDKT");

                entity.Property(e => e.IdloaiKt).HasColumnName("IDLoaiKT");

                entity.Property(e => e.Idnv).HasColumnName("IDNV");

                entity.Property(e => e.Ngay).HasColumnType("date");

                entity.HasOne(d => d.IdloaiKtNavigation)
                    .WithMany(p => p.KhenThuongs)
                    .HasForeignKey(d => d.IdloaiKt)
                    .HasConstraintName("FK_KhenThuong_LoaiKhenThuong");

                entity.HasOne(d => d.IdnvNavigation)
                    .WithMany(p => p.KhenThuongs)
                    .HasForeignKey(d => d.Idnv)
                    .HasConstraintName("FK_KhenThuong_NhanVien");
            });

            modelBuilder.Entity<KyLuat>(entity =>
            {
                entity.HasKey(e => e.Idkl);

                entity.ToTable("KyLuat");

                entity.Property(e => e.Idkl).HasColumnName("IDKL");

                entity.Property(e => e.IdloaiKl).HasColumnName("IDLoaiKL");

                entity.Property(e => e.Idnv).HasColumnName("IDNV");

                entity.Property(e => e.Ngay).HasColumnType("date");

                entity.HasOne(d => d.IdloaiKlNavigation)
                    .WithMany(p => p.KyLuats)
                    .HasForeignKey(d => d.IdloaiKl)
                    .HasConstraintName("FK_KyLuat_LoaiKyLuat");

                entity.HasOne(d => d.IdnvNavigation)
                    .WithMany(p => p.KyLuats)
                    .HasForeignKey(d => d.Idnv)
                    .HasConstraintName("FK_KyLuat_NhanVien");
            });

            modelBuilder.Entity<LoaiKhenThuong>(entity =>
            {
                entity.HasKey(e => e.IdloaiKt);

                entity.ToTable("LoaiKhenThuong");

                entity.Property(e => e.IdloaiKt).HasColumnName("IDLoaiKT");

                entity.Property(e => e.TenKt)
                    .HasMaxLength(50)
                    .HasColumnName("TenKT");
            });

            modelBuilder.Entity<LoaiKyLuat>(entity =>
            {
                entity.HasKey(e => e.IdloaiKl);

                entity.ToTable("LoaiKyLuat");

                entity.Property(e => e.IdloaiKl).HasColumnName("IDLoaiKL");

                entity.Property(e => e.TenKl)
                    .HasMaxLength(50)
                    .HasColumnName("TenKL");
            });

            modelBuilder.Entity<NhanVien>(entity =>
            {
                entity.HasKey(e => e.Idnv);

                entity.ToTable("NhanVien");

                entity.Property(e => e.Idnv).HasColumnName("IDNV");

                entity.Property(e => e.Cmnd).HasColumnName("CMND");

                entity.Property(e => e.DiaChi).HasMaxLength(50);

                entity.Property(e => e.DienThoai)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.HinhAnh)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Idcv).HasColumnName("IDCV");

                entity.Property(e => e.Idpb).HasColumnName("IDPB");

                entity.Property(e => e.NgaySinh).HasColumnType("date");

                entity.Property(e => e.TenNv)
                    .HasMaxLength(50)
                    .HasColumnName("TenNV");

                entity.HasOne(d => d.IdcvNavigation)
                    .WithMany(p => p.NhanViens)
                    .HasForeignKey(d => d.Idcv)
                    .HasConstraintName("FK_NhanVien_ChucVu");

                entity.HasOne(d => d.IdpbNavigation)
                    .WithMany(p => p.NhanViens)
                    .HasForeignKey(d => d.Idpb)
                    .HasConstraintName("FK_NhanVien_PhongBan");
            });

            modelBuilder.Entity<PhongBan>(entity =>
            {
                entity.HasKey(e => e.Idpb);

                entity.ToTable("PhongBan");

                entity.Property(e => e.Idpb).HasColumnName("IDPB");

                entity.Property(e => e.TenPb)
                    .HasMaxLength(50)
                    .HasColumnName("TenPB");
            });

            modelBuilder.Entity<TaiKhoan>(entity =>
            {
                entity.HasKey(e => e.Idnv);

                entity.ToTable("TaiKhoan");

                entity.Property(e => e.Idnv)
                    .ValueGeneratedNever()
                    .HasColumnName("IDNV");

                entity.Property(e => e.Pass)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdnvNavigation)
                    .WithOne(p => p.TaiKhoan)
                    .HasForeignKey<TaiKhoan>(d => d.Idnv)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TaiKhoan_NhanVien");
            });

            OnModelCreatingPartial(modelBuilder);
        }
                
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
