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
1. POST /api/auth/register - Daftar akun baru
2. POST /api/auth/login    - Login dan dapat JWT token
3. GET  /api/todo          - Ambil semua todo (butuh token)
4. POST /api/todo          - Buat todo baru (butuh token)
