USE QLBanVeXeBuyt;
GO

-- =======================================================
-- 1. BẢNG TUYẾN XE (Được cập nhật để phân loại Nội/Ngoại)
-- =======================================================
CREATE TABLE TuyenXe (
    MaTuyen INT IDENTITY(1,1) PRIMARY KEY,
    TenTuyen NVARCHAR(200) NOT NULL,
    LoaiTuyen BIT NOT NULL, -- 0: Nội thành (Xe buýt), 1: Ngoại thành (Xe khách)
    GiaVe DECIMAL(18,0) NOT NULL, -- Cần có giá vé cố định để tính tiền nội thành
    TrangThai BIT DEFAULT 1
);
GO

-- Thêm dữ liệu mẫu Tuyến Nội Thành (LoaiTuyen = 0)
INSERT INTO TuyenXe (TenTuyen, LoaiTuyen, GiaVe, TrangThai)
VALUES 
(N'Tuyến 01: Bến Thành - Bến xe Chợ Lớn', 0, 6000, 1),
(N'Tuyến 08: Bến xe Quận 8 - Đại học Quốc Gia', 0, 7000, 1),
(N'Tuyến 150: Bến xe Chợ Lớn - Ngã 3 Tân Vạn', 0, 7000, 1);
GO

-- Thêm dữ liệu mẫu Tuyến Ngoại Thành (LoaiTuyen = 1) để dùng sau
INSERT INTO TuyenXe (TenTuyen, LoaiTuyen, GiaVe, TrangThai)
VALUES 
(N'Sài Gòn - Đà Lạt', 1, 300000, 1),
(N'Sài Gòn - Nha Trang', 1, 250000, 1);
GO

-- =======================================================
-- 2. BẢNG GIAO DỊCH NỘI THÀNH (Lịch sử in vé)
-- =======================================================
CREATE TABLE GiaoDichNoiThanh (
    MaGiaoDich INT IDENTITY(1,1) PRIMARY KEY,
    MaTuyen INT NOT NULL,
    MaNhanVien INT NOT NULL, -- Để biết nhân viên nào bán, phục vụ báo cáo doanh thu
    SoLuongVe INT NOT NULL CHECK (SoLuongVe > 0),
    TongTien DECIMAL(18,0) NOT NULL,
    ThoiGianBan DATETIME DEFAULT GETDATE(), -- Tự động lấy giờ hệ thống lúc in vé
    
    -- Khóa ngoại liên kết dữ liệu
    FOREIGN KEY (MaTuyen) REFERENCES TuyenXe(MaTuyen),
    FOREIGN KEY (MaNhanVien) REFERENCES NhanVien(MaNhanVien) 
);
GO