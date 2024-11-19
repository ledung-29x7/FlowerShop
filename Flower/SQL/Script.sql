-- Tạo cơ sở dữ liệu mới
CREATE DATABASE FlowerDB;
GO

-- Sử dụng cơ sở dữ liệu
USE FlowerDB;
GO

-- Bảng Roles
CREATE TABLE Roles(
    role_id INT IDENTITY(1,1) PRIMARY KEY,
    name NVARCHAR(50)
);
INSERT INTO Roles (name) VALUES ('Admin'), ('Manager'), ('Customer');
GO
-- Bảng Users
CREATE TABLE Users (
    user_id INT IDENTITY(1,1) PRIMARY KEY,
    full_name NVARCHAR(100) NOT NULL,
    email NVARCHAR(100) NOT NULL UNIQUE,
    password_hash NVARCHAR(255) NOT NULL,
    phone_number NVARCHAR(20),
    address NVARCHAR(MAX),
    role_id INT FOREIGN KEY REFERENCES Roles(role_id),
    created_at DATETIME DEFAULT GETDATE(),
    update_at DATETIME
);
GO
-- Bảng Stores
CREATE TABLE Stores (
    store_id INT IDENTITY(1,1) PRIMARY KEY,
    store_name NVARCHAR(100) NOT NULL,
    address NVARCHAR(MAX) NOT NULL,
    phone_number NVARCHAR(20),
    email NVARCHAR(100),
    created_at DATETIME DEFAULT GETDATE()
);
GO
-- Bảng UserStores: Phân quyền quản lý cửa hàng cho Manager
CREATE TABLE UserStores (
    user_store_id INT IDENTITY(1,1) PRIMARY KEY, 
    user_id INT NOT NULL FOREIGN KEY REFERENCES Users(user_id),
    store_id INT NOT NULL FOREIGN KEY REFERENCES Stores(store_id)
);
GO
-- Bảng Occasions
CREATE TABLE Occasions (
    occasion_id INT IDENTITY(1,1) PRIMARY KEY,
    name NVARCHAR(100) NOT NULL UNIQUE,
    description NVARCHAR(MAX)
);
GO
-- Bảng Messages
CREATE TABLE Messages (
    message_id INT IDENTITY(1,1) PRIMARY KEY,
    occasion_id INT FOREIGN KEY REFERENCES Occasions(occasion_id) ON DELETE CASCADE,
    message_text NVARCHAR(255) NOT NULL
);
GO
-- Bảng Flowers
CREATE TABLE Flowers (
    flower_id INT IDENTITY(1,1) PRIMARY KEY,
    name NVARCHAR(100) NOT NULL,
    description NVARCHAR(MAX),
    price DECIMAL(10, 2) NOT NULL,
    occasion_id INT FOREIGN KEY REFERENCES Occasions(occasion_id) ON DELETE SET NULL,
    stock INT DEFAULT 0,
    created_at DATETIME DEFAULT GETDATE()
);
GO
ALTER TABLE Flowers
ADD is_active BIT DEFAULT 1;
GO
-- Bảng Images
CREATE TABLE Images (
    image_id INT IDENTITY(1,1) PRIMARY KEY,
    name NVARCHAR(255),
    imagebase64 TEXT,
    flower_id INT FOREIGN KEY REFERENCES Flowers(flower_id)
);
GO
-- Bảng Orders
CREATE TABLE Orders (
    order_id INT IDENTITY(1,1) PRIMARY KEY,
    user_id INT FOREIGN KEY REFERENCES Users(user_id) ON DELETE SET NULL,
    store_id INT FOREIGN KEY REFERENCES Stores(store_id) ON DELETE SET NULL,
    total_amount DECIMAL(10, 2) NOT NULL,
    payment_status NVARCHAR(20) DEFAULT 'Pending',
    payment_method NVARCHAR(50) DEFAULT 'Credit Card',
    recipient_name NVARCHAR(100) NOT NULL,
    recipient_address NVARCHAR(MAX) NOT NULL,
    recipient_phone NVARCHAR(20) NOT NULL,
    delivery_time DATETIME NOT NULL,
    created_at DATETIME DEFAULT GETDATE()
);
GO
-- Bảng Order_Items
CREATE TABLE Order_Items (
    order_item_id INT IDENTITY(1,1) PRIMARY KEY,
    order_id INT FOREIGN KEY REFERENCES Orders(order_id) ON DELETE CASCADE,
    flower_id INT FOREIGN KEY REFERENCES Flowers(flower_id) ON DELETE SET NULL,
    quantity INT NOT NULL DEFAULT 1,
    unit_price DECIMAL(10, 2) NOT NULL,
    total_price DECIMAL(10, 2) NOT NULL
);
GO
-- Bảng Cart
CREATE TABLE Cart (
    cart_id INT IDENTITY(1,1) PRIMARY KEY,
    user_id INT FOREIGN KEY REFERENCES Users(user_id) ON DELETE CASCADE,
    created_at DATETIME DEFAULT GETDATE()
);
GO
-- Bảng Cart_Items
CREATE TABLE Cart_Items (
    cart_item_id INT IDENTITY(1,1) PRIMARY KEY,
    cart_id INT FOREIGN KEY REFERENCES Cart(cart_id) ON DELETE CASCADE,
    flower_id INT FOREIGN KEY REFERENCES Flowers(flower_id) ON DELETE SET NULL,
    quantity INT NOT NULL DEFAULT 1,
    added_at DATETIME DEFAULT GETDATE()
);
GO
-- Bảng Notifications: Lưu thông báo cho Manager
CREATE TABLE Notifications (
    notification_id INT IDENTITY(1,1) PRIMARY KEY,
    user_id INT FOREIGN KEY REFERENCES Users(user_id) ON DELETE CASCADE,
    order_id INT FOREIGN KEY REFERENCES Orders(order_id) ON DELETE CASCADE,
    store_id INT FOREIGN KEY REFERENCES Stores(store_id) ON DELETE CASCADE,
    message NVARCHAR(255) NOT NULL,
    is_read BIT DEFAULT 0,
    created_at DATETIME DEFAULT GETDATE()
);
GO
-- Bảng SalesReports: Lưu báo cáo doanh thu
CREATE TABLE SalesReports (
    report_id INT IDENTITY(1,1) PRIMARY KEY,
    store_id INT FOREIGN KEY REFERENCES Stores(store_id) ON DELETE CASCADE,
    report_date DATE NOT NULL,
    daily_sales DECIMAL(10, 2) NOT NULL,
    weekly_sales DECIMAL(10, 2),
    monthly_sales DECIMAL(10, 2),
    yearly_sales DECIMAL(10, 2)
);
GO
-- Xóa các cột không cần thiết khỏi bảng SalesReports
ALTER TABLE SalesReports
DROP COLUMN weekly_sales, monthly_sales, yearly_sales;

-- Ghi chú: Đảm bảo các truy vấn hoặc báo cáo liên quan được cập nhật để tính toán các giá trị này khi cần.

GO
-- Bảng StoreFlowers: Lưu tồn kho hoa theo cửa hàng
CREATE TABLE StoreFlowers (
    store_flower_id INT IDENTITY(1,1) PRIMARY KEY,
    store_id INT FOREIGN KEY REFERENCES Stores(store_id) ON DELETE CASCADE,
    flower_id INT FOREIGN KEY REFERENCES Flowers(flower_id) ON DELETE CASCADE,
    quantity INT NOT NULL DEFAULT 0,
    last_updated DATETIME DEFAULT GETDATE()
);
ALTER TABLE Orders
ADD is_cancelled BIT DEFAULT 0; -- 0: Không hủy, 1: Đã hủy
GO
-- Tạo Stored Procedure để lấy báo cáo doanh thu
CREATE PROCEDURE GetSalesReportByDateRange
    @StoreID INT = NULL,
    @StartDate DATE,
    @EndDate DATE
AS
BEGIN
    SELECT 
        store_id,
        SUM(daily_sales) AS total_sales,
        MIN(report_date) AS start_date,
        MAX(report_date) AS end_date
    FROM SalesReports
    WHERE (store_id = @StoreID OR @StoreID IS NULL)
    AND report_date BETWEEN @StartDate AND @EndDate
    GROUP BY store_id;
END;
GO
-- Tạo Trigger để tự động thêm thông báo khi có đơn hàng mới cho Manager
CREATE TRIGGER trg_NewOrderNotification
ON Orders
AFTER INSERT
AS
BEGIN
    INSERT INTO Notifications (user_id, order_id, store_id, message, created_at)
    SELECT 
        us.user_id,
        i.order_id,
        i.store_id,
        'New order placed in your store',
        GETDATE()
    FROM 
        INSERTED i
    JOIN UserStores us ON us.store_id = i.store_id;
END;
GO
-- Tạo Trigger để cập nhật tồn kho sau khi đơn hàng được xác nhận
CREATE TRIGGER trg_UpdateStockAfterOrder
ON Order_Items
AFTER INSERT
AS
BEGIN
    UPDATE sf
    SET sf.quantity = sf.quantity - oi.quantity,
        sf.last_updated = GETDATE()
    FROM StoreFlowers sf
    JOIN INSERTED oi ON sf.flower_id = oi.flower_id 
                    AND sf.store_id = (SELECT store_id FROM Orders WHERE order_id = oi.order_id);
END;


GO
-- khi hủy thì phục hồi lại số lượng
CREATE TRIGGER trg_RestoreStockOnOrderCancel
ON Orders
AFTER UPDATE
AS
BEGIN
    IF UPDATE(is_cancelled)
    BEGIN
        UPDATE sf
        SET sf.quantity = sf.quantity + oi.quantity,
            sf.last_updated = GETDATE()
        FROM StoreFlowers sf
        JOIN Order_Items oi ON sf.flower_id = oi.flower_id
        WHERE EXISTS (
            SELECT 1 
            FROM INSERTED i
            WHERE i.order_id = oi.order_id AND i.is_cancelled = 1
        );
    END;
END;
GO
-- store hủy đơn hàng
CREATE PROCEDURE CancelOrderByUser
    @user_id INT,
    @order_id INT
AS
BEGIN
    SET NOCOUNT ON;

    -- Kiểm tra điều kiện: trạng thái đơn hàng và quyền sở hữu
    IF EXISTS (
        SELECT 1 
        FROM Orders 
        WHERE order_id = @order_id 
          AND user_id = @user_id 
          AND payment_status = 'Pending' 
          AND is_cancelled = 0
    )
    BEGIN
        -- Đánh dấu đơn hàng là đã hủy
        UPDATE Orders
        SET is_cancelled = 1
        WHERE order_id = @order_id;

        PRINT 'Order has been successfully cancelled.';
    END
    ELSE
    BEGIN
        PRINT 'Order cannot be cancelled. Please check the order status or ownership.';
    END
END;
GO
-- tạo thông báo cho manager khi có người hủy đơn 
CREATE TRIGGER trg_NotifyManagerOnOrderCancel
ON Orders
AFTER UPDATE
AS
BEGIN
    IF UPDATE(is_cancelled)
    BEGIN
        INSERT INTO Notifications (user_id, order_id, store_id, message, created_at)
        SELECT 
            us.user_id, 
            i.order_id, 
            i.store_id,
            CONCAT('Order ', i.order_id, ' has been cancelled by the customer.'),
            GETDATE()
        FROM INSERTED i
        JOIN UserStores us ON us.store_id = i.store_id
        WHERE i.is_cancelled = 1;
    END;
END;
GO
CREATE PROCEDURE RegisterUser
    @FullName NVARCHAR(100),
    @Email NVARCHAR(100),
    @PasswordHash NVARCHAR(255),
    @PhoneNumber NVARCHAR(20),
    @Address NVARCHAR(MAX)
AS
BEGIN
    INSERT INTO Users (full_name, email, password_hash, phone_number, address, role_id)
    VALUES (@FullName, @Email, @PasswordHash, @PhoneNumber, @Address, 3);
END;
GO
CREATE PROCEDURE GetUserByEmail
    @Email NVARCHAR(100)
AS
BEGIN
    SELECT * FROM Users WHERE email = @Email;
END;
GO
GO
CREATE PROCEDURE dbo.CreateOccasion
    @Name NVARCHAR(255),
    @Description NVARCHAR(MAX)
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO Occasions (Name, Description)
    VALUES (@Name, @Description);
END;
GO

CREATE PROCEDURE dbo.DeleteOccasion
    @Occasion_id INT
AS
BEGIN
    SET NOCOUNT ON;

    DELETE FROM Occasions
    WHERE Occasion_id = @Occasion_id;
END;
GO
CREATE PROCEDURE dbo.GetAllOccasion
AS
BEGIN
    SET NOCOUNT ON;

    SELECT * FROM Occasions;
END;
GO
CREATE PROCEDURE dbo.GetOccasionById
    @Occasion_id INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT * 
    FROM Occasions
    WHERE Occasion_id = @Occasion_id;
END;
GO
CREATE PROCEDURE dbo.UpdateOccasion
    @Occasion_id INT,
    @Name NVARCHAR(255),
    @Description NVARCHAR(MAX)
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE Occasions
    SET Name = @Name,
        Description = @Description
    WHERE Occasion_id = @Occasion_id;
END;
GO

CREATE PROCEDURE dbo.CreateFlower
    @Name NVARCHAR(255),
    @Description NVARCHAR(MAX),
    @Price DECIMAL(18, 2),
    @Occasion_id INT,
    @Stock INT
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO Flowers (Name, Description, Price, Occasion_id, Stock)
    VALUES (@Name, @Description, @Price, @Occasion_id, @Stock);
END;
GO
CREATE PROCEDURE dbo.DeleteFlower
    @Flower_id INT
AS
BEGIN
    SET NOCOUNT ON;

    DELETE FROM Flowers
    WHERE Flower_id = @Flower_id;
END;
GO
CREATE PROCEDURE dbo.GetFlower
AS
BEGIN
    SET NOCOUNT ON;

    SELECT * FROM Flowers;
END;
GO
CREATE PROCEDURE dbo.GetFlowerById
    @Flower_id INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT * 
    FROM Flowers
    WHERE Flower_id = @Flower_id;
END;
GO
CREATE PROCEDURE dbo.UpdateFlower
    @Flower_id INT,
    @Name NVARCHAR(255),
    @Description NVARCHAR(MAX),
    @Price DECIMAL(18, 2),
    @Occasion_id INT,
    @Stock INT
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE Flowers
    SET Name = @Name,
        Description = @Description,
        Price = @Price,
        Occasion_id = @Occasion_id,
        Stock = @Stock
    WHERE Flower_id = @Flower_id;
END;
GO

CREATE TYPE ImageTableType AS TABLE
(
    Name NVARCHAR(255),
    ImageBase64 TEXT,
    FlowerId INT
);
GO
CREATE PROCEDURE AddImages
    @ImageList ImageTableType READONLY
AS
BEGIN
    INSERT INTO Images (name, imagebase64, flower_id)
    SELECT Name, ImageBase64, FlowerId
    FROM @ImageList;
END;

GO
CREATE PROCEDURE GetImageByFlowerId
    @FlowerId INT
AS
BEGIN
    SELECT image_id, name, imagebase64, flower_id
    FROM Images
    WHERE flower_id = @FlowerId;
END;

GO
CREATE PROCEDURE DeleteImageByFlowerId
    @FlowerId INT
AS
BEGIN
    DELETE FROM [dbo].[Images]
    WHERE flower_id = @FlowerId;
END;
GO
