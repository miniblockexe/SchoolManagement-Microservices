using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ClassService.Models;

[Table("LopHoc")]
[Index("MaLop", Name = "UQ__LopHoc__3B98D2724990DA61", IsUnique = true)]
public partial class LopHoc
{
    [Key]
    public int Id { get; set; }

    [StringLength(20)]
    public string MaLop { get; set; } = null!;

    [StringLength(50)]
    public string TenLop { get; set; } = null!;

    [StringLength(20)]
    public string? Khoi { get; set; }

    [StringLength(50)]
    public string? PhongHoc { get; set; }

    [StringLength(20)]
    public string? NamHoc { get; set; }

    public int? GiaoVienChuNhiemId { get; set; }

    public int? SiSoToiDa { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }
}
