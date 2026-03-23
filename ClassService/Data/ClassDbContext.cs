using System;
using System.Collections.Generic;
using ClassService.Models;
using Microsoft.EntityFrameworkCore;

namespace ClassService.Data;

public partial class ClassDbContext : DbContext
{
    public ClassDbContext()
    {
    }

    public ClassDbContext(DbContextOptions<ClassDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<HocSinhLop> HocSinhLops { get; set; }

    public virtual DbSet<LopHoc> LopHocs { get; set; }

    public virtual DbSet<MonHocLop> MonHocLops { get; set; }

    public virtual DbSet<ThongTinTruong> ThongTinTruongs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=lophoc");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<HocSinhLop>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__HocSinhL__3214EC07ACD603F8");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<LopHoc>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__LopHoc__3214EC073D5C468C");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<MonHocLop>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__MonHocLo__3214EC0790A450CD");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<ThongTinTruong>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ThongTin__3214EC070CBFE3CF");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
