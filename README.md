# Todo API

REST API untuk manajemen todo list, dibangun dengan ASP.NET Core 8.

## Teknologi
- ASP.NET Core 8 Web API
- Entity Framework Core + SQLite
- JWT Authentication
- Swagger UI

## Cara Pemakaian
1. Clone repo ini
2. Buka dengan Visual Studio
3. Jalankan: Update-Database di Package Manager Console

## Endpoint utama
POST /api/auth/register - Daftar akun baru
POST /api/auth/login    - Login dan dapat JWT token
GET  /api/todo          - Ambil semua todo (butuh token)
POST /api/todo          - Buat todo baru (butuh token)
