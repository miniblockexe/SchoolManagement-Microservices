using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ClassService.Models;

[Table("HocSinhLop")]
public partial class HocSinhLop
{
    [Key]
    public int Id { get; set; }

    public int LopHocId { get; set; }

    public int HocSinhId { get; set; }

    [StringLength(100)]
    public string HoTenHocSinh { get; set; } = null!;

    public DateOnly? NgaySinh { get; set; }

    [StringLength(10)]
    public string? GioiTinh { get; set; }

    [Column(TypeName = "decimal(4, 2)")]
    public decimal? DiemTrungBinh { get; set; }

    [StringLength(30)]
    public string? HocLuc { get; set; }

    public int? GiaoVienChuNhiemId { get; set; }

    [StringLength(20)]
    public string? TrangThai { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }
}
