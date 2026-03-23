namespace ClassService.DTOs;

public class LopHocViewDto
{
    public object? LopHoc { get; set; }
    public object? GiaoVienChuNhiem { get; set; }
    public List<HocSinhDto>? DanhSachHocSinh { get; set; }
    public int SiSo { get; set; }
}
public class HocSinhDto
{
    public int Id { get; set; }
    public string? HoTen { get; set; }
    public decimal? DiemTrungBinh { get; set; }
    public string? HocLuc { get; set; }
}