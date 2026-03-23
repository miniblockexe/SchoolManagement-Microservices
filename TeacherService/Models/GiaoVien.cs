using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TeacherService.Models;

[Table("GiaoVien")]
[Index("MaGiaoVien", Name = "UQ__GiaoVien__8D374F5192BA84B6", IsUnique = true)]
public partial class GiaoVien
{
    [Key]
    public int Id { get; set; }

    [StringLength(20)]
    public string MaGiaoVien { get; set; } = null!;

    [StringLength(100)]
    public string HoTen { get; set; } = null!;

    [StringLength(10)]
    public string? GioiTinh { get; set; }

    public DateOnly? NgaySinh { get; set; }

    [StringLength(255)]
    public string? DiaChi { get; set; }

    [StringLength(20)]
    public string? DienThoai { get; set; }

    [StringLength(100)]
    public string? Email { get; set; }

    [StringLength(100)]
    public string? MonChuyenMon { get; set; }

    public DateOnly? NgayVaoLam { get; set; }

    [StringLength(20)]
    public string? TrangThai { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }
}
