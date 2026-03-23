CREATE DATABASE SchoolStudentDB;
GO
CREATE DATABASE SchoolTeacherDB;
GO
CREATE DATABASE SchoolClassDB;
GO

-- ========
-- STUDENT 
-- ========
USE SchoolStudentDB;
GO

CREATE TABLE HocSinh (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    MaHocSinh NVARCHAR(20) NOT NULL UNIQUE,
    HoTen NVARCHAR(100) NOT NULL,
    NgaySinh DATE NOT NULL,
    GioiTinh NVARCHAR(10) NULL,
    DiaChi NVARCHAR(255) NULL,
    DienThoai NVARCHAR(20) NULL,
    Email NVARCHAR(100) NULL,

    LopHocId INT NOT NULL,
    GiaoVienPhuTrachId INT NULL,
    GiaoVienChuNhiemId INT NULL,

    DiemTrungBinh DECIMAL(4,2) NULL,
    HocLuc NVARCHAR(30) NULL,
    ThanhTich NVARCHAR(255) NULL,

    NgayNhapHoc DATE NULL,
    TrangThai NVARCHAR(20) NULL,

    CreatedAt DATETIME DEFAULT GETDATE()
);
GO

-- ========
-- TEACHER 
-- ========
USE SchoolTeacherDB;
GO

CREATE TABLE GiaoVien (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    MaGiaoVien NVARCHAR(20) NOT NULL UNIQUE,
    HoTen NVARCHAR(100) NOT NULL,
    GioiTinh NVARCHAR(10) NULL,
    NgaySinh DATE NULL,
    DiaChi NVARCHAR(255) NULL,
    DienThoai NVARCHAR(20) NULL,
    Email NVARCHAR(100) NULL,
    MonChuyenMon NVARCHAR(100) NULL,
    NgayVaoLam DATE NULL,
    TrangThai NVARCHAR(20) NULL,
    CreatedAt DATETIME DEFAULT GETDATE()
);
GO

CREATE TABLE MonHoc (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    TenMonHoc NVARCHAR(100) NOT NULL UNIQUE,
    MoTa NVARCHAR(255) NULL
);
GO

CREATE TABLE PhanCongGiangDay (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    GiaoVienId INT NOT NULL,
    LopHocId INT NOT NULL,
    MonHocId INT NOT NULL,
    NamHoc NVARCHAR(20) NOT NULL,
    HocKy NVARCHAR(20) NOT NULL,
    LaChuNhiem BIT NOT NULL DEFAULT 0,
    GhiChu NVARCHAR(255) NULL,
    CreatedAt DATETIME DEFAULT GETDATE()
);
GO

CREATE TABLE BangDiem (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    HocSinhId INT NOT NULL,
    GiaoVienId INT NOT NULL,
    MonHocId INT NOT NULL,
    NamHoc NVARCHAR(20) NOT NULL,
    HocKy NVARCHAR(20) NOT NULL,
    DiemMieng DECIMAL(4,2) NULL,
    Diem15Phut DECIMAL(4,2) NULL,
    Diem1Tiet DECIMAL(4,2) NULL,
    DiemThi DECIMAL(4,2) NULL,
    DiemTrungBinh DECIMAL(4,2) NULL,
    GhiChu NVARCHAR(255) NULL,
    NgayNhap DATETIME DEFAULT GETDATE()
);
GO

CREATE TABLE HanhKiem (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    HocSinhId INT NOT NULL,
    GiaoVienChuNhiemId INT NOT NULL,
    NamHoc NVARCHAR(20) NOT NULL,
    HocKy NVARCHAR(20) NOT NULL,
    XepLoai NVARCHAR(50) NOT NULL,
    NhanXet NVARCHAR(255) NULL,
    NgayNhap DATETIME DEFAULT GETDATE()
);
GO

CREATE TABLE ThanhTich (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    HocSinhId INT NOT NULL,
    GiaoVienId INT NOT NULL,
    NamHoc NVARCHAR(20) NOT NULL,
    TieuDe NVARCHAR(100) NOT NULL,
    MoTa NVARCHAR(255) NULL,
    NgayDat DATE NULL,
    CreatedAt DATETIME DEFAULT GETDATE()
);
GO

CREATE TABLE BanGiamHieu (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    GiaoVienId INT NOT NULL,
    ChucVu NVARCHAR(50) NOT NULL,
    NgayBoNhiem DATE NULL,
    TrangThai NVARCHAR(20) NULL,
    CreatedAt DATETIME DEFAULT GETDATE()
);
GO

-- ======
-- CLASS 
-- ======
USE SchoolClassDB;
GO

CREATE TABLE LopHoc (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    MaLop NVARCHAR(20) NOT NULL UNIQUE,
    TenLop NVARCHAR(50) NOT NULL,
    Khoi NVARCHAR(20) NULL,
    PhongHoc NVARCHAR(50) NULL,
    NamHoc NVARCHAR(20) NULL,
    GiaoVienChuNhiemId INT NULL,
    SiSoToiDa INT NULL,
    CreatedAt DATETIME DEFAULT GETDATE()
);
GO

CREATE TABLE MonHocLop (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    LopHocId INT NOT NULL,
    MonHocId INT NOT NULL,
    GiaoVienId INT NOT NULL,
    TenMonHoc NVARCHAR(100) NOT NULL,
    TenGiaoVien NVARCHAR(100) NOT NULL,
    SoTietTuan INT NULL,
    GhiChu NVARCHAR(255) NULL,
    CreatedAt DATETIME DEFAULT GETDATE()
);
GO

CREATE TABLE HocSinhLop (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    LopHocId INT NOT NULL,
    HocSinhId INT NOT NULL,
    HoTenHocSinh NVARCHAR(100) NOT NULL,
    NgaySinh DATE NULL,
    GioiTinh NVARCHAR(10) NULL,
    DiemTrungBinh DECIMAL(4,2) NULL,
    HocLuc NVARCHAR(30) NULL,
    GiaoVienChuNhiemId INT NULL,
    TrangThai NVARCHAR(20) NULL,
    CreatedAt DATETIME DEFAULT GETDATE()
);
GO

CREATE TABLE ThongTinTruong (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    TenTruong NVARCHAR(200) NOT NULL,
    HieuTruongId INT NULL,
    TenHieuTruong NVARCHAR(100) NULL,
    NamHocHienTai NVARCHAR(20) NULL,
    CreatedAt DATETIME DEFAULT GETDATE()
);
GO

-- ================
-- SCHOOL TEACHER 
-- ================
USE SchoolTeacherDB;
GO

SET IDENTITY_INSERT GiaoVien ON;
INSERT INTO GiaoVien
(Id, MaGiaoVien, HoTen, GioiTinh, NgaySinh, DiaChi, DienThoai, Email, MonChuyenMon, NgayVaoLam, TrangThai, CreatedAt)
VALUES
(1, 'GV001', N'Nguyễn Văn An', N'Nam', '1985-03-12', N'Đà Lạt', '0901111111', 'an@gmail.com', N'Toán', '2010-08-01', N'Đang dạy', GETDATE()),
(2, 'GV002', N'Trần Thị Bình', N'Nữ', '1987-07-21', N'Đà Lạt', '0902222222', 'binh@gmail.com', N'Văn', '2012-08-01', N'Đang dạy', GETDATE()),
(3, 'GV003', N'Lê Minh Châu', N'Nam', '1984-11-05', N'Đà Lạt', '0903333333', 'chau@gmail.com', N'Anh văn', '2011-08-01', N'Đang dạy', GETDATE()),
(4, 'GV004', N'Phạm Thu Dung', N'Nữ', '1983-01-18', N'Đà Lạt', '0904444444', 'dung@gmail.com', N'Vật lý', '2009-08-01', N'Đang dạy', GETDATE());
SET IDENTITY_INSERT GiaoVien OFF;
GO

SET IDENTITY_INSERT MonHoc ON;
INSERT INTO MonHoc
(Id, TenMonHoc, MoTa)
VALUES
(1, N'Toán', N'Môn Toán'),
(2, N'Văn', N'Môn Ngữ văn'),
(3, N'Anh văn', N'Môn tiếng Anh'),
(4, N'Vật lý', N'Môn Vật lý'),
(5, N'Hóa học', N'Môn Hóa học');
SET IDENTITY_INSERT MonHoc OFF;
GO

SET IDENTITY_INSERT PhanCongGiangDay ON;
INSERT INTO PhanCongGiangDay
(Id, GiaoVienId, LopHocId, MonHocId, NamHoc, HocKy, LaChuNhiem, GhiChu, CreatedAt)
VALUES
(1, 1, 1, 1, '2024-2025', 'HK1', 1, N'Chủ nhiệm lớp 10A1, dạy Toán', GETDATE()),
(2, 2, 1, 2, '2024-2025', 'HK1', 0, N'Dạy Văn lớp 10A1', GETDATE()),
(3, 3, 1, 3, '2024-2025', 'HK1', 0, N'Dạy Anh văn lớp 10A1', GETDATE()),
(4, 4, 2, 4, '2024-2025', 'HK1', 1, N'Chủ nhiệm lớp 10A2, dạy Vật lý', GETDATE()),
(5, 1, 2, 1, '2024-2025', 'HK1', 0, N'Dạy Toán lớp 10A2', GETDATE());
SET IDENTITY_INSERT PhanCongGiangDay OFF;
GO

SET IDENTITY_INSERT BangDiem ON;
INSERT INTO BangDiem
(Id, HocSinhId, GiaoVienId, MonHocId, NamHoc, HocKy, DiemMieng, Diem15Phut, Diem1Tiet, DiemThi, DiemTrungBinh, GhiChu, NgayNhap)
VALUES
(1, 1, 1, 1, '2024-2025', 'HK1', 8, 7, 9, 8, 8.00, N'Tốt', GETDATE()),
(2, 2, 1, 1, '2024-2025', 'HK1', 6, 7, 6, 7, 6.50, N'Khá', GETDATE()),
(3, 3, 4, 4, '2024-2025', 'HK1', 9, 8, 9, 9, 8.75, N'Rất tốt', GETDATE());
SET IDENTITY_INSERT BangDiem OFF;
GO

SET IDENTITY_INSERT HanhKiem ON;
INSERT INTO HanhKiem
(Id, HocSinhId, GiaoVienChuNhiemId, NamHoc, HocKy, XepLoai, NhanXet, NgayNhap)
VALUES
(1, 1, 1, '2024-2025', 'HK1', N'Tốt', N'Chăm ngoan, lễ phép', GETDATE()),
(2, 2, 1, '2024-2025', 'HK1', N'Khá', N'Có ý thức học tập tốt', GETDATE()),
(3, 3, 4, '2024-2025', 'HK1', N'Tốt', N'Tham gia hoạt động tốt', GETDATE());
SET IDENTITY_INSERT HanhKiem OFF;
GO

SET IDENTITY_INSERT ThanhTich ON;
INSERT INTO ThanhTich
(Id, HocSinhId, GiaoVienId, NamHoc, TieuDe, MoTa, NgayDat, CreatedAt)
VALUES
(1, 1, 1, '2024-2025', N'Học sinh giỏi', N'Đạt điểm trung bình cao', '2025-01-15', GETDATE()),
(2, 2, 2, '2024-2025', N'Tiến bộ vượt bậc', N'Tăng điểm mạnh trong học kỳ', '2025-01-15', GETDATE()),
(3, 3, 4, '2024-2025', N'Giải nhì HSG', N'Đạt giải học sinh giỏi cấp trường', '2025-01-15', GETDATE());
SET IDENTITY_INSERT ThanhTich OFF;
GO

SET IDENTITY_INSERT BanGiamHieu ON;
INSERT INTO BanGiamHieu
(Id, GiaoVienId, ChucVu, NgayBoNhiem, TrangThai, CreatedAt)
VALUES
(1, 1, N'Hiệu trưởng', '2023-08-01', N'Đang công tác', GETDATE()),
(2, 2, N'Phó hiệu trưởng', '2023-08-01', N'Đang công tác', GETDATE());
SET IDENTITY_INSERT BanGiamHieu OFF;
GO

-- ==============
-- SCHOOL CLASS 
-- ==============
USE SchoolClassDB;
GO

SET IDENTITY_INSERT LopHoc ON;
INSERT INTO LopHoc
(Id, MaLop, TenLop, Khoi, PhongHoc, NamHoc, GiaoVienChuNhiemId, SiSoToiDa, CreatedAt)
VALUES
(1, '10A1', N'Lớp 10A1', '10', 'A101', '2024-2025', 1, 40, GETDATE()),
(2, '10A2', N'Lớp 10A2', '10', 'A102', '2024-2025', 4, 40, GETDATE()),
(3, '11A1', N'Lớp 11A1', '11', 'B201', '2024-2025', 2, 45, GETDATE());
SET IDENTITY_INSERT LopHoc OFF;
GO

SET IDENTITY_INSERT MonHocLop ON;
INSERT INTO MonHocLop
(Id, LopHocId, MonHocId, GiaoVienId, TenMonHoc, TenGiaoVien, SoTietTuan, GhiChu, CreatedAt)
VALUES
(1, 1, 1, 1, N'Toán', N'Nguyễn Văn An', 4, N'Môn chính', GETDATE()),
(2, 1, 2, 2, N'Văn', N'Trần Thị Bình', 3, N'Môn chính', GETDATE()),
(3, 1, 3, 3, N'Anh văn', N'Lê Minh Châu', 3, N'Môn chính', GETDATE()),
(4, 2, 4, 4, N'Vật lý', N'Phạm Thu Dung', 3, N'Môn chính', GETDATE()),
(5, 2, 1, 1, N'Toán', N'Nguyễn Văn An', 4, N'Môn chính', GETDATE()),
(6, 3, 2, 2, N'Văn', N'Trần Thị Bình', 3, N'Môn chính', GETDATE());
SET IDENTITY_INSERT MonHocLop OFF;
GO

SET IDENTITY_INSERT HocSinhLop ON;
INSERT INTO HocSinhLop
(Id, LopHocId, HocSinhId, HoTenHocSinh, NgaySinh, GioiTinh, DiemTrungBinh, HocLuc, GiaoVienChuNhiemId, TrangThai, CreatedAt)
VALUES
(1, 1, 1, N'Nguyễn Văn A', '2005-05-10', N'Nam', 8.00, N'Giỏi', 1, N'Đang học', GETDATE()),
(2, 1, 2, N'Trần Thị B', '2005-06-15', N'Nữ', 6.50, N'Khá', 1, N'Đang học', GETDATE()),
(3, 2, 3, N'Lê Văn C', '2005-07-20', N'Nam', 8.75, N'Giỏi', 4, N'Đang học', GETDATE());
SET IDENTITY_INSERT HocSinhLop OFF;
GO

SET IDENTITY_INSERT ThongTinTruong ON;
INSERT INTO ThongTinTruong
(Id, TenTruong, HieuTruongId, TenHieuTruong, NamHocHienTai, CreatedAt)
VALUES
(1, N'Trường Trung học Phổ thông Đà Lạt', 1, N'Nguyễn Văn An', '2024-2025', GETDATE());
SET IDENTITY_INSERT ThongTinTruong OFF;
GO

-- ================
-- SCHOOL STUDENT
-- ================
USE SchoolStudentDB;
GO

SET IDENTITY_INSERT HocSinh ON;
INSERT INTO HocSinh
(Id, MaHocSinh, HoTen, NgaySinh, GioiTinh, DiaChi, DienThoai, Email,
 LopHocId, GiaoVienPhuTrachId, GiaoVienChuNhiemId,
 DiemTrungBinh, HocLuc, ThanhTich, NgayNhapHoc, TrangThai, CreatedAt)
VALUES
(1, 'HS001', N'Nguyễn Văn A', '2005-05-10', N'Nam', N'Đà Lạt', '0911111111', 'a@gmail.com', 1, 1, 1, 8.00, N'Giỏi', N'Học sinh giỏi', '2023-09-01', N'Đang học', GETDATE()),
(2, 'HS002', N'Trần Thị B', '2005-06-15', N'Nữ', N'Đà Lạt', '0922222222', 'b@gmail.com', 1, 1, 1, 6.50, N'Khá', N'Có tiến bộ', '2023-09-01', N'Đang học', GETDATE()),
(3, 'HS003', N'Lê Văn C', '2005-07-20', N'Nam', N'Đà Lạt', '0933333333', 'c@gmail.com', 2, 4, 4, 8.75, N'Giỏi', N'Giải nhì HSG', '2023-09-01', N'Đang học', GETDATE()),
(4, 'HS004', N'Phạm Thị D', '2005-08-25', N'Nữ', N'Đà Lạt', '0944444444', 'd@gmail.com', 2, 4, 4, 7.25, N'Khá', N'Chăm chỉ', '2023-09-01', N'Đang học', GETDATE()),
(5, 'HS005', N'Hoàng Văn E', '2005-09-30', N'Nam', N'Đà Lạt', '0955555555', 'e@gmail.com', 3, 2, 2, 5.75, N'Trung bình', N'Đạt yêu cầu', '2023-09-01', N'Đang học', GETDATE());
SET IDENTITY_INSERT HocSinh OFF;
GO