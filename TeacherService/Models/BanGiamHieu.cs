using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TeacherService.Models;

[Table("BanGiamHieu")]
public partial class BanGiamHieu
{
    [Key]
    public int Id { get; set; }

    public int GiaoVienId { get; set; }

    [StringLength(50)]
    public string ChucVu { get; set; } = null!;

    public DateOnly? NgayBoNhiem { get; set; }

    [StringLength(20)]
    public string? TrangThai { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }
}
