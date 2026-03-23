using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace StudentService.Models;

[Table("HocSinh")]
[Index("MaHocSinh", Name = "UQ__HocSinh__90BD01E1EB7F6714", IsUnique = true)]
public partial class HocSinh
{
    [Key]
    public int Id { get; set; }

    [StringLength(20)]
    public string MaHocSinh { get; set; } = null!;

    [StringLength(100)]
    public string HoTen { get; set; } = null!;

    public DateOnly NgaySinh { get; set; }

    [StringLength(10)]
    public string? GioiTinh { get; set; }

    [StringLength(255)]
    public string? DiaChi { get; set; }

    [StringLength(20)]
    public string? DienThoai { get; set; }

    [StringLength(100)]
    public string? Email { get; set; }

    public int LopHocId { get; set; }

    public int? GiaoVienPhuTrachId { get; set; }

    public int? GiaoVienChuNhiemId { get; set; }

    [Column(TypeName = "decimal(4, 2)")]
    public decimal? DiemTrungBinh { get; set; }

    [StringLength(30)]
    public string? HocLuc { get; set; }

    [StringLength(255)]
    public string? ThanhTich { get; set; }

    public DateOnly? NgayNhapHoc { get; set; }

    [StringLength(20)]
    public string? TrangThai { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }
}
