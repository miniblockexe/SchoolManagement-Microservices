namespace ClassService.DTOs;

public class CreateLopHocDto
{
    public string MaLop { get; set; } = string.Empty;
    public string TenLop { get; set; } = string.Empty;
    public string? Khoi { get; set; }
    public string? PhongHoc { get; set; }
    public string? NamHoc { get; set; }
    public int GiaoVienChuNhiemId { get; set; }

    public int SiSoToiDa { get; set; } 
}