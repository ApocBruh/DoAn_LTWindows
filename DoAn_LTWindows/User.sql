-- 1. Tạo Database
CREATE DATABASE QLBanVeXeBuyt;
GO

USE QLBanVeXeBuyt;
GO

-- 2. Tạo bảng Nhân Viên (Tài Khoản)
CREATE TABLE NhanVien (
    MaNhanVien INT IDENTITY(1,1) PRIMARY KEY, -- Tự động tăng
    TenDangNhap VARCHAR(50) UNIQUE NOT NULL,
    MatKhau VARCHAR(50) NOT NULL,
    TenNhanVien NVARCHAR(100) NOT NULL,
    VaiTro VARCHAR(20) NOT NULL, -- Sẽ lưu chữ 'Admin' hoặc 'User'
    TrangThai BIT DEFAULT 1 -- 1: Đang hoạt động, 0: Bị khóa
);
GO

-- 3. Chèn dữ liệu mẫu để test Đăng Nhập
INSERT INTO NhanVien (TenDangNhap, MatKhau, TenNhanVien, VaiTro, TrangThai)
VALUES 
('admin', '123456', N'Lê Đức Phong', 'Admin', 1),
('nhanvien1', '123456', N'Nguyễn Văn A', 'User', 1);
GO