using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TeacherService.Models;

[Table("PhanCongGiangDay")]
public partial class PhanCongGiangDay
{
    [Key]
    public int Id { get; set; }

    public int GiaoVienId { get; set; }

    public int LopHocId { get; set; }

    public int MonHocId { get; set; }

    [StringLength(20)]
    public string NamHoc { get; set; } = null!;

    [StringLength(20)]
    public string HocKy { get; set; } = null!;

    public bool LaChuNhiem { get; set; }

    [StringLength(255)]
    public string? GhiChu { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }
}
