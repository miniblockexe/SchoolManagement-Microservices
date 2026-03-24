  ########### SchoolManagement-Microservices ###########

Dự án quản lý trường học sử dụng:
- ASP.NET Core Web API
- SQL Server
- Swagger
- Microservices

## Các service
- StudentService: quản lý học sinh
- TeacherService: quản lý giáo viên, nhập điểm
- ClassService: quản lý lớp học

## Yêu cầu cài đặt
- .NET SDK 8.x
- SQL Server
- SQL Server Management Studio (SSMS)
- Visual Studio 2022 hoặc VS Code

## Cách chạy database
1. Mở SSMS
2. Chạy file:
   - `SQL/SchoolManagement.sql`
3. File này sẽ tạo 3 database:
   - `SchoolStudentDB`
   - `SchoolTeacherDB`
   - `SchoolClassDB`
     
## Cách chạy project
1. Mở SchoolManagement-OPEN
2. Đồng ý mở khi cảnh báo
3. Khi mở sẽ tạo 3 cmd và mở 3 trang web
4. Test thôi


   
## Nếu lỗi thì Cấu hình connection string cho đúng máy bạn
Mở file `appsettings.json` của từng service và sửa connection string cho đúng máy bạn.

Ví dụ:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=.;Database=SchoolStudentDB;Trusted_Connection=True;TrustServerCertificate=True"
  }
}
