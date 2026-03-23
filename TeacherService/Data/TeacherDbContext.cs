using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TeacherService.Models;

namespace TeacherService.Data;

public partial class TeacherDbContext : DbContext
{
    public TeacherDbContext()
    {
    }

    public TeacherDbContext(DbContextOptions<TeacherDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BanGiamHieu> BanGiamHieus { get; set; }

    public virtual DbSet<BangDiem> BangDiems { get; set; }

    public virtual DbSet<GiaoVien> GiaoViens { get; set; }

    public virtual DbSet<HanhKiem> HanhKiems { get; set; }

    public virtual DbSet<MonHoc> MonHocs { get; set; }

    public virtual DbSet<PhanCongGiangDay> PhanCongGiangDays { get; set; }

    public virtual DbSet<ThanhTich> ThanhTiches { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=giaovien");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BanGiamHieu>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BanGiamH__3214EC07A9B46A34");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<BangDiem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BangDiem__3214EC07548B6C8A");

            entity.Property(e => e.NgayNhap).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<GiaoVien>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__GiaoVien__3214EC0759797E41");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<HanhKiem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__HanhKiem__3214EC07C641BCED");

            entity.Property(e => e.NgayNhap).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<MonHoc>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__MonHoc__3214EC070286B514");
        });

        modelBuilder.Entity<PhanCongGiangDay>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PhanCong__3214EC071E9DCA5C");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<ThanhTich>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ThanhTic__3214EC072BA2BA0B");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
