-- 1. TẠO DATABASE
CREATE DATABASE SimpleSalesApp;
GO
USE SimpleSalesApp;
GO

-- 2. BẢNG [User]: lưu chung Admin/Employee/Customer và hỗ trợ reset mật khẩu
CREATE TABLE [User] (
    UserId           INT IDENTITY(1,1) PRIMARY KEY,
    Username         NVARCHAR(50)  NOT NULL UNIQUE,
    Email            NVARCHAR(100) NOT NULL UNIQUE,
    Password         NVARCHAR(100) NOT NULL,
    Role             NVARCHAR(20)  NOT NULL 
                        CONSTRAINT CHK_User_Role CHECK (Role IN ('Admin','Employee','Customer')),
    Status           NVARCHAR(10)  NOT NULL DEFAULT 'Active',
    ResetToken       NVARCHAR(100) NULL,
    ResetTokenExpiry DATETIME      NULL,
    CreatedAt        DATETIME      NOT NULL DEFAULT GETDATE()
);
GO

-- 3. BẢNG Supplier: nhà cung cấp
CREATE TABLE Supplier (
    SupplierId  INT IDENTITY(1,1) PRIMARY KEY,
    Name        NVARCHAR(100) NOT NULL
);
GO

-- 4. BẢNG Product: mặt hàng
CREATE TABLE Product (
    ProductId      INT IDENTITY(1,1) PRIMARY KEY,
    SupplierId     INT           NOT NULL 
                       CONSTRAINT FK_Product_Supplier REFERENCES Supplier(SupplierId),
    Name           NVARCHAR(100) NOT NULL,
    UnitPrice      DECIMAL(12,2) NOT NULL,
    StockQuantity  INT           NOT NULL DEFAULT 0
);
GO

-- 5. BẢNG Invoice: hóa đơn
CREATE TABLE Invoice (
    InvoiceId    INT IDENTITY(1,1) PRIMARY KEY,
    CustomerId   INT NOT NULL 
                   CONSTRAINT FK_Invoice_Customer REFERENCES [User](UserId),
    EmployeeId   INT NOT NULL 
                   CONSTRAINT FK_Invoice_Employee REFERENCES [User](UserId),
    InvoiceDate  DATETIME    NOT NULL DEFAULT GETDATE(),
    TotalAmount  DECIMAL(14,2) NOT NULL
);
GO

-- 6. BẢNG InvoiceItem: chi tiết hóa đơn
CREATE TABLE InvoiceItem (
    InvoiceId   INT     NOT NULL 
                   CONSTRAINT FK_InvItem_Invoice REFERENCES Invoice(InvoiceId) ON DELETE CASCADE,
    ProductId   INT     NOT NULL 
                   CONSTRAINT FK_InvItem_Product REFERENCES Product(ProductId),
    Quantity    INT     NOT NULL CHECK (Quantity > 0),
    UnitPrice   DECIMAL(12,2) NOT NULL,
    PRIMARY KEY (InvoiceId, ProductId)
);
GO

-- 7. BẢNG WarrantyVoucher: phiếu bảo hành
CREATE TABLE WarrantyVoucher (
    VoucherId     INT IDENTITY(1,1) PRIMARY KEY,
    InvoiceId     INT NOT NULL 
                   CONSTRAINT FK_WV_Invoice REFERENCES Invoice(InvoiceId),
    ProductId     INT NOT NULL 
                   CONSTRAINT FK_WV_Product REFERENCES Product(ProductId),
    IssueDate     DATE   NOT NULL,
    ExpiryDate    DATE   NOT NULL
);
GO

-- 8. INDEX TỐI ƯU
CREATE INDEX IX_User_Username  ON [User](Username);
CREATE INDEX IX_User_Email     ON [User](Email);
CREATE INDEX IX_Product_Name   ON Product(Name);
CREATE INDEX IX_Invoice_Date   ON Invoice(InvoiceDate);
GO
