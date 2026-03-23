namespace TeacherService.DTOs;

public class NhapDiemDto
{
    public int HocSinhId { get; set; }
    public int GiaoVienId { get; set; }
    public int MonHocId { get; set; }

    public string NamHoc { get; set; } = string.Empty;
    public string HocKy { get; set; } = string.Empty;

    public decimal? DiemMieng { get; set; }
    public decimal? Diem15Phut { get; set; }
    public decimal? Diem1Tiet { get; set; }
    public decimal? DiemThi { get; set; }
}
