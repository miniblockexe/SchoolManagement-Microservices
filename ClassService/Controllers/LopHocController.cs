using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClassService.Models;
using ClassService.DTOs;
using System.Net.Http.Json;
using ClassService.Data;

namespace ClassService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LopHocController : ControllerBase
{
    private readonly ClassDbContext _context;
    private readonly IConfiguration _config;
    private readonly IHttpClientFactory _httpFactory;
    public LopHocController(ClassDbContext context, IConfiguration config, IHttpClientFactory httpFactory)
    {
        _context = context;
        _config = config;
        _httpFactory = httpFactory;
    }


    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _context.LopHocs.ToListAsync());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var lop = await _context.LopHocs.FindAsync(id);
        if (lop == null) return NotFound();

        return Ok(lop);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateLopHocDto dto)
    {
        var lop = new LopHoc
        {
            MaLop = dto.MaLop,
            TenLop = dto.TenLop,
            Khoi = dto.Khoi,
            PhongHoc = dto.PhongHoc,
            NamHoc = dto.NamHoc,
            GiaoVienChuNhiemId = dto.GiaoVienChuNhiemId,
            SiSoToiDa = dto.SiSoToiDa,
            CreatedAt = DateTime.Now
        };

        _context.LopHocs.Add(lop);
        await _context.SaveChangesAsync();

        return Ok(lop);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateLopHocDto dto)
    {
        var lop = await _context.LopHocs.FindAsync(id);
        if (lop == null) return NotFound();

        lop.TenLop = dto.TenLop;
        lop.Khoi = dto.Khoi;
        lop.PhongHoc = dto.PhongHoc;
        lop.NamHoc = dto.NamHoc;
        lop.GiaoVienChuNhiemId = dto.GiaoVienChuNhiemId;

        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var lop = await _context.LopHocs.FindAsync(id);
        if (lop == null) return NotFound();

        _context.LopHocs.Remove(lop);
        await _context.SaveChangesAsync();

        return NoContent();
    }


    [HttpGet("{id}/full")]
    public async Task<IActionResult> GetFull(int id)
    {
        var lop = await _context.LopHocs.FindAsync(id);
        if (lop == null) return NotFound();

        var http = _httpFactory.CreateClient();
        var UrlHs = _config["Services:StudentService"];
        var UrlGv = _config["Services:TeacherService"];

        var students = await http.GetFromJsonAsync<List<HocSinhDto>>(
            $"{UrlHs}/api/hocsinh?lopHocId={id}"
        );

        object? giaoVien = null;

        if (lop.GiaoVienChuNhiemId.HasValue)
        {
            giaoVien = await http.GetFromJsonAsync<object>(
                $"{UrlGv}/api/teachers/{lop.GiaoVienChuNhiemId}"
            );
        }
        int siSo;

        if (students != null)
            siSo = students.Count;
        else
            siSo = 0;

        var result = new LopHocViewDto
        {
            LopHoc = lop,
            GiaoVienChuNhiem = giaoVien,
            DanhSachHocSinh = students,
            SiSo = siSo
        };

        return Ok(result);
    }
    [HttpGet("{id}/bang-diem")]
    public async Task<IActionResult> GetBangDiem(int id)
    {
        var http = _httpFactory.CreateClient();
        var UrlHs = _config["Services:StudentService"];

        var students = await http.GetFromJsonAsync<List<HocSinhDto>>(
            $"{UrlHs}/api/hocsinh?lopHocId={id}"
        );

        if (students == null)
            return Ok(new List<BangDiemLopDto>());

        var result = new List<BangDiemLopDto>();

        foreach (var s in students)
        {
            result.Add(new BangDiemLopDto
            {
                HocSinhId = s.Id,
                HoTen = s.HoTen,
                DiemTrungBinh = s.DiemTrungBinh,
                HocLuc = s.HocLuc
            });
        }

        return Ok(result);
    }
}