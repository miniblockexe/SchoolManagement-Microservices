using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentService.Models;
using StudentService.DTOs;
using StudentService.Data;

namespace StudentService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HocSinhController : ControllerBase
{
    private readonly StudentDbContext _context;

    public HocSinhController(StudentDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var data = await _context.HocSinhs.ToListAsync();
        return Ok(data);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var hs = await _context.HocSinhs.FindAsync(id);

        if (hs == null)
            return NotFound();

        return Ok(hs);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateHocSinhDto dto)
    {
        var hs = new HocSinh
        {
            MaHocSinh = dto.MaHocSinh,
            HoTen = dto.HoTen,
            NgaySinh = DateOnly.FromDateTime(dto.NgaySinh),
            GioiTinh = dto.GioiTinh,
            DiaChi = dto.DiaChi,
            DienThoai = dto.DienThoai,
            Email = dto.Email,

            LopHocId = dto.LopHocId,
            GiaoVienPhuTrachId = dto.GiaoVienPhuTrachId,
            GiaoVienChuNhiemId = dto.GiaoVienChuNhiemId,

            NgayNhapHoc = dto.NgayNhapHoc.HasValue
                ? DateOnly.FromDateTime(dto.NgayNhapHoc.Value)
                : null,

            TrangThai = dto.TrangThai,
            CreatedAt = DateTime.Now
        };

        _context.HocSinhs.Add(hs);
        await _context.SaveChangesAsync();

        return Ok(hs);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateHocSinhDto dto)
    {
        var hs = await _context.HocSinhs.FindAsync(id);

        if (hs == null)
            return NotFound();

        hs.HoTen = dto.HoTen;
        hs.GioiTinh = dto.GioiTinh;
        hs.DiaChi = dto.DiaChi;
        hs.DienThoai = dto.DienThoai;
        hs.Email = dto.Email;

        hs.LopHocId = dto.LopHocId;
        hs.GiaoVienPhuTrachId = dto.GiaoVienPhuTrachId;
        hs.GiaoVienChuNhiemId = dto.GiaoVienChuNhiemId;

        hs.TrangThai = dto.TrangThai;

        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var hs = await _context.HocSinhs.FindAsync(id);

        if (hs == null)
            return NotFound();

        _context.HocSinhs.Remove(hs);
        await _context.SaveChangesAsync();

        return NoContent();
    }
    [HttpPut("{id}/cap-nhat-diem")]
    public async Task<IActionResult> CapNhatDiem(int id, UpdateDiemDto dto)
    {
        var hs = await _context.HocSinhs.FindAsync(id);

        if (hs == null)
            return NotFound();

        hs.DiemTrungBinh = dto.DiemTrungBinh;
        hs.HocLuc = dto.HocLuc;

        if (dto.DiemTrungBinh >= 8)
            hs.ThanhTich = "Hoc sinh gioi";
        else if (dto.DiemTrungBinh >= 6.5m)
            hs.ThanhTich = "Hoc sinh kha";
        else if (dto.DiemTrungBinh >= 5)
            hs.ThanhTich = "Trung binh";
        else
            hs.ThanhTich = "Yeu";

        await _context.SaveChangesAsync();

        return Ok(hs);
    }
}
