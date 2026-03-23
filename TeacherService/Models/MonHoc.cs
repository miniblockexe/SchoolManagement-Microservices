using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TeacherService.Models;

[Table("MonHoc")]
[Index("TenMonHoc", Name = "UQ__MonHoc__AB9BBBD609F4600B", IsUnique = true)]
public partial class MonHoc
{
    [Key]
    public int Id { get; set; }

    [StringLength(100)]
    public string TenMonHoc { get; set; } = null!;

    [StringLength(255)]
    public string? MoTa { get; set; }
}
