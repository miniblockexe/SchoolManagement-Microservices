using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TeacherService.Models;

[Table("BangDiem")]
public partial class BangDiem
{
    [Key]
    public int Id { get; set; }

    public int HocSinhId { get; set; }

    public int GiaoVienId { get; set; }

    public int MonHocId { get; set; }

    [StringLength(20)]
    public string NamHoc { get; set; } = null!;

    [StringLength(20)]
    public string HocKy { get; set; } = null!;

    [Column(TypeName = "decimal(4, 2)")]
    public decimal? DiemMieng { get; set; }

    [Column(TypeName = "decimal(4, 2)")]
    public decimal? Diem15Phut { get; set; }

    [Column(TypeName = "decimal(4, 2)")]
    public decimal? Diem1Tiet { get; set; }

    [Column(TypeName = "decimal(4, 2)")]
    public decimal? DiemThi { get; set; }

    [Column(TypeName = "decimal(4, 2)")]
    public decimal? DiemTrungBinh { get; set; }

    [StringLength(255)]
    public string? GhiChu { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? NgayNhap { get; set; }
}
