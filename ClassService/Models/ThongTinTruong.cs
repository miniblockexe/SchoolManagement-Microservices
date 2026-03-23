using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ClassService.Models;

[Table("ThongTinTruong")]
public partial class ThongTinTruong
{
    [Key]
    public int Id { get; set; }

    [StringLength(200)]
    public string TenTruong { get; set; } = null!;

    public int? HieuTruongId { get; set; }

    [StringLength(100)]
    public string? TenHieuTruong { get; set; }

    [StringLength(20)]
    public string? NamHocHienTai { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }
}
