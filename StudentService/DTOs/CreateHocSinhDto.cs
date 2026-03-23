namespace StudentService.DTOs;

public class CreateHocSinhDto
{
    public string MaHocSinh { get; set; } = string.Empty;
    public string HoTen { get; set; } = string.Empty;
    public DateTime NgaySinh { get; set; }
    public string? GioiTinh { get; set; }
    public string? DiaChi { get; set; }
    public string? DienThoai { get; set; }
    public string? Email { get; set; }

    public int LopHocId { get; set; }
    public int? GiaoVienPhuTrachId { get; set; }
    public int? GiaoVienChuNhiemId { get; set; }

    public DateTime? NgayNhapHoc { get; set; }
    public string? TrangThai { get; set; }
}

public class UpdateHocSinhDto
{
    public string HoTen { get; set; } = string.Empty;
    public string? GioiTinh { get; set; }
    public string? DiaChi { get; set; }
    public string? DienThoai { get; set; }
    public string? Email { get; set; }

    public int LopHocId { get; set; }
    public int? GiaoVienPhuTrachId { get; set; }
    public int? GiaoVienChuNhiemId { get; set; }

    public string? TrangThai { get; set; }
}