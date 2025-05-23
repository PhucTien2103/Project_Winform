USE SimpleSalesApp;
GO

-- 1. Thêm dữ liệu vào bảng [User]
INSERT INTO [User] (Username, Email, Password, Role, Status)
VALUES 
    ('admin1', 'admin1@example.com', 'adminpass123', 'Admin', 'Active'),
    ('emp1', 'emp1@example.com', 'emppass123', 'Employee', 'Active'),
    ('cust1', 'cust2@example.com', 'custpass123', 'Customer', 'Active'); -- Thay đổi Email để tránh trùng

-- 2. Thêm dữ liệu vào bảng Supplier
INSERT INTO Supplier (Name)
VALUES 
    ('Supplier A'),
    ('Supplier B'),
    ('Supplier C');

-- 3. Thêm dữ liệu vào bảng Product
INSERT INTO Product (SupplierId, Name, UnitPrice, StockQuantity)
VALUES 
    (1, 'Laptop A', 15000.00, 10),
    (2, 'Phone B', 8000.00, 20),
    (3, 'Tablet C', 5000.00, 15);

-- 4. Thêm dữ liệu vào bảng Invoice
INSERT INTO Invoice (CustomerId, EmployeeId, InvoiceDate, TotalAmount)
VALUES 
    (3, 2, '2025-05-01', 23000.00), -- Customer 3 (cust1), Employee 2 (emp1)
    (3, 2, '2025-05-02', 5000.00),  -- Customer 3, Employee 2
    (3, 2, '2025-05-03', 13000.00); -- Customer 3, Employee 2

-- 5. Thêm dữ liệu vào bảng InvoiceItem
INSERT INTO InvoiceItem (InvoiceId, ProductId, Quantity, UnitPrice)
VALUES 
    (1, 1, 1, 15000.00), -- Invoice 1: 1 Laptop A
    (1, 2, 1, 8000.00),  -- Invoice 1: 1 Phone B (Total = 23000)
    (2, 3, 1, 5000.00),  -- Invoice 2: 1 Tablet C
    (3, 2, 1, 8000.00),  -- Invoice 3: 1 Phone B
    (3, 3, 1, 5000.00);  -- Invoice 3: 1 Tablet C (Total = 13000)

-- 6. Thêm dữ liệu vào bảng WarrantyVoucher
INSERT INTO WarrantyVoucher (InvoiceId, ProductId, IssueDate, ExpiryDate)
VALUES 
    (1, 1, '2025-05-01', '2026-05-01'), -- Warranty for Laptop A from Invoice 1
    (1, 2, '2025-05-01', '2026-05-01'), -- Warranty for Phone B from Invoice 1
    (2, 3, '2025-05-02', '2026-05-02'); -- Warranty for Tablet C from Invoice 2
GO