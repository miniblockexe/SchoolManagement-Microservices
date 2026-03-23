using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TeacherService.Models;
using TeacherService.DTOs;
using System.Net.Http.Json;
using TeacherService.Data;
using Azure;

namespace TeacherService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TeachersController : ControllerBase
{
    private readonly TeacherDbContext _context;
    private readonly IConfiguration _config;

    public TeachersController(TeacherDbContext context, IConfiguration config)
    {
        _context = context;
        _config = config;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _context.GiaoViens.ToListAsync());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var gv = await _context.GiaoViens.FindAsync(id);
        if (gv == null) return NotFound();
        return Ok(gv);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateGiaoVienDto dto)
    {
        var gv = new GiaoVien
        {
            MaGiaoVien = dto.MaGiaoVien,
            HoTen = dto.HoTen,
            GioiTinh = dto.GioiTinh,
            DienThoai = dto.DienThoai,
            Email = dto.Email,
            MonChuyenMon = dto.MonChuyenMon,
            NgayVaoLam = dto.NgayVaoLam.HasValue
                ? DateOnly.FromDateTime(dto.NgayVaoLam.Value)
                : null,
            TrangThai = dto.TrangThai,
            CreatedAt = DateTime.Now
        };

        _context.GiaoViens.Add(gv);
        await _context.SaveChangesAsync();

        return Ok(gv);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateGiaoVienDto dto)
    {
        var gv = await _context.GiaoViens.FindAsync(id);
        if (gv == null) return NotFound();

        gv.HoTen = dto.HoTen;
        gv.GioiTinh = dto.GioiTinh;
        gv.DienThoai = dto.DienThoai;
        gv.Email = dto.Email;
        gv.MonChuyenMon = dto.MonChuyenMon;
        gv.NgayVaoLam = dto.NgayVaoLam.HasValue
            ? DateOnly.FromDateTime(dto.NgayVaoLam.Value)
            : null;
        gv.TrangThai = dto.TrangThai;

        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var gv = await _context.GiaoViens.FindAsync(id);
        if (gv == null) return NotFound();

        _context.GiaoViens.Remove(gv);
        await _context.SaveChangesAsync();

        return NoContent();
    }


    [HttpPost("nhap-diem")]
    public async Task<IActionResult> NhapDiem(NhapDiemDto dto)
    {
        var diemList = new List<decimal>();

        if (dto.DiemMieng.HasValue) diemList.Add(dto.DiemMieng.Value);
        if (dto.Diem15Phut.HasValue) diemList.Add(dto.Diem15Phut.Value);
        if (dto.Diem1Tiet.HasValue) diemList.Add(dto.Diem1Tiet.Value);
        if (dto.DiemThi.HasValue) diemList.Add(dto.DiemThi.Value);

        decimal dtb = diemList.Count > 0 ? diemList.Average() : 0;

        var bangDiem = new BangDiem
        {
            HocSinhId = dto.HocSinhId,
            GiaoVienId = dto.GiaoVienId,
            MonHocId = dto.MonHocId,
            NamHoc = dto.NamHoc,
            HocKy = dto.HocKy,
            DiemMieng = dto.DiemMieng,
            Diem15Phut = dto.Diem15Phut,
            Diem1Tiet = dto.Diem1Tiet,
            DiemThi = dto.DiemThi,
            DiemTrungBinh = dtb
        };

        _context.BangDiems.Add(bangDiem);
        await _context.SaveChangesAsync();

        using var http = new HttpClient();

        var hocLuc = XepLoaiHocLuc(dtb);

        var data = new
        {
            DiemTrungBinh = dtb,
            HocLuc = hocLuc
        };
        var baseUrl = _config["Services:StudentService"];
        await http.PutAsJsonAsync($"{baseUrl}/api/hocsinh/{dto.HocSinhId}/cap-nhat-diem", data);
        return Ok(bangDiem);
    }


    private string XepLoaiHocLuc(decimal dtb)
    {
        if (dtb >= 8) return "Gioi";
        if (dtb >= 6.5m) return "Kha";
        if (dtb >= 5) return "Trung binh";
        return "Yeu";
    }
}