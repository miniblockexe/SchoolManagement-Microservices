namespace TeacherService.DTOs;

public class CreateGiaoVienDto
{
    public string MaGiaoVien { get; set; } = string.Empty;
    public string HoTen { get; set; } = string.Empty;
    public string? GioiTinh { get; set; }
    public string? DienThoai { get; set; }
    public string? Email { get; set; }
    public string? MonChuyenMon { get; set; }
    public DateTime? NgayVaoLam { get; set; }
    public string? TrangThai { get; set; }
}