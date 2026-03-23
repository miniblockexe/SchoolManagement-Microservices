using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ClassService.Models;

[Table("MonHocLop")]
public partial class MonHocLop
{
    [Key]
    public int Id { get; set; }

    public int LopHocId { get; set; }

    public int MonHocId { get; set; }

    public int GiaoVienId { get; set; }

    [StringLength(100)]
    public string TenMonHoc { get; set; } = null!;

    [StringLength(100)]
    public string TenGiaoVien { get; set; } = null!;

    public int? SoTietTuan { get; set; }

    [StringLength(255)]
    public string? GhiChu { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }
}
