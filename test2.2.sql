-- Đảm bảo sử dụng đúng database
USE UserAuthDB;
GO

-- 1. Xem tất cả thông tin users đã đăng ký
SELECT * FROM Users;
GO

-- 2. Xem thông tin users theo định dạng đẹp hơn
SELECT 
    UserId,
    Username,
    Email,
    Phone,
    IsEmailConfirmed,
    CreatedAt
FROM Users
ORDER BY CreatedAt DESC;
GO

-- 3. Đếm tổng số users đã đăng ký
SELECT COUNT(*) AS TotalUsers FROM Users;
GO

-- 4. Xem users đã xác nhận email
SELECT 
    Username,
    Email,
    Phone,
    CreatedAt
FROM Users 
WHERE IsEmailConfirmed = 1;
GO

-- 5. Xem users chưa xác nhận email
SELECT 
    Username,
    Email,
    Phone,
    CreatedAt
FROM Users 
WHERE IsEmailConfirmed = 0;
GO

-- 6. Xem thông tin chi tiết của user cụ thể (thay 'username' bằng tên thật)
SELECT 
    UserId,
    Username,
    Email,
    Phone,
    IsEmailConfirmed,
    CreatedAt,
    CASE 
        WHEN IsEmailConfirmed = 1 THEN 'Đã xác nhận'
        ELSE 'Chưa xác nhận'
    END AS EmailStatus
FROM Users 
WHERE Username = 'your_username_here';
GO

-- 7. Xem cấu trúc bảng Users
SELECT 
    COLUMN_NAME as 'Tên Cột',
    DATA_TYPE as 'Kiểu Dữ Liệu',
    IS_NULLABLE as 'Cho Phép NULL',
    COLUMN_DEFAULT as 'Giá Trị Mặc Định'
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = 'Users'
ORDER BY ORDINAL_POSITION;
GO