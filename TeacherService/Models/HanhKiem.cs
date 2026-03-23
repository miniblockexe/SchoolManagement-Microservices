using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TeacherService.Models;

[Table("HanhKiem")]
public partial class HanhKiem
{
    [Key]
    public int Id { get; set; }

    public int HocSinhId { get; set; }

    public int GiaoVienChuNhiemId { get; set; }

    [StringLength(20)]
    public string NamHoc { get; set; } = null!;

    [StringLength(20)]
    public string HocKy { get; set; } = null!;

    [StringLength(50)]
    public string XepLoai { get; set; } = null!;

    [StringLength(255)]
    public string? NhanXet { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? NgayNhap { get; set; }
}
