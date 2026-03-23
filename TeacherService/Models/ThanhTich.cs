using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TeacherService.Models;

[Table("ThanhTich")]
public partial class ThanhTich
{
    [Key]
    public int Id { get; set; }

    public int HocSinhId { get; set; }

    public int GiaoVienId { get; set; }

    [StringLength(20)]
    public string NamHoc { get; set; } = null!;

    [StringLength(100)]
    public string TieuDe { get; set; } = null!;

    [StringLength(255)]
    public string? MoTa { get; set; }

    public DateOnly? NgayDat { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }
}
