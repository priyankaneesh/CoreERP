create database CoreERPDB
use CoreERPDB
drop database CoreERPDB
 drop table login
 CREATE TABLE Login (
     
    Username VARCHAR(50) NOT NULL,                      -- Username for login
    PasswordHash VARCHAR(255) NOT NULL,                 -- Encrypted password
    Role VARCHAR(20) NOT NULL DEFAULT 'Admin',          -- Role of the user (default is Admin)
    CreatedAt DATETIME DEFAULT GETDATE()                -- Timestamp for when the user was created
);

INSERT INTO Login (Username, Password, Role, CreatedAt)
VALUES 
('admin', HASHBYTES('SHA2_256', 'admin123'), 'Admin', GETDATE());



select * from Login
----create table Company
 CREATE TABLE Company (
    CompanyID UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    Name VARCHAR(255) NOT NULL,
    Address VARCHAR(500),
    GSTNumber VARCHAR(15),
    Phone VARCHAR(15),
    Email VARCHAR(255),
    Website VARCHAR(255),
    Capital DECIMAL(18, 2),
    Income DECIMAL(18, 2)
);



CREATE TABLE StatusCodes (
    StatusCode INT PRIMARY KEY,
    StatusDescription VARCHAR(50) NOT NULL
);

-- Example Status Codes
INSERT INTO StatusCodes (StatusCode, StatusDescription)
VALUES 
(1, 'Active'),
(2, 'Inactive'),
(3, 'Suspended');

----create table Accounting
CREATE TABLE Accounting (
    AccountingID UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    CompanyID UNIQUEIDENTIFIER,
    Income DECIMAL(18, 2),
    Expenses DECIMAL(18, 2),
    ProfitLoss AS (Income - Expenses) PERSISTED,
    FOREIGN KEY (CompanyID) REFERENCES Company(CompanyID)
);
----create table Vendor
CREATE TABLE Vendor (
    VendorID UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    Name VARCHAR(255) NOT NULL,
    Address VARCHAR(500),
    GSTNumber VARCHAR(15),
    AccountNumber VARCHAR(20),
    Phone VARCHAR(15),
    Email VARCHAR(255),
    Website VARCHAR(255),
    StatusCode INT NOT NULL,
    CONSTRAINT FK_Vendor_StatusCodes FOREIGN KEY (StatusCode) REFERENCES StatusCodes(StatusCode)
);


CREATE TABLE Inventory (
    ItemID UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    ItemCode VARCHAR(50) NOT NULL,
    ItemName VARCHAR(255),
    Quantity INT,
    BatchNumber VARCHAR(50),
    ExpiryDate DATE,
    SellingPrice DECIMAL(18, 2),
    CostPrice DECIMAL(18, 2)
);


CREATE TABLE Purchase (
    PurchaseID UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    VendorID UNIQUEIDENTIFIER NOT NULL,
    PurchaseDate DATE,
    TotalAmount DECIMAL(18, 2),
    CONSTRAINT FK_Purchase_Vendor FOREIGN KEY (VendorID) REFERENCES Vendor(VendorID)
);
CREATE TABLE PurchaseItem (
    PurchaseItemID UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    PurchaseID UNIQUEIDENTIFIER NOT NULL,
    ItemID UNIQUEIDENTIFIER NOT NULL,
    Quantity INT,
    MRP DECIMAL(18, 2),
    BatchNumber VARCHAR(50),
    ExpiryDate DATE,
    SellingCost DECIMAL(18, 2),
    CONSTRAINT FK_PurchaseItem_Purchase FOREIGN KEY (PurchaseID) REFERENCES Purchase(PurchaseID),
    CONSTRAINT FK_PurchaseItem_Inventory FOREIGN KEY (ItemID) REFERENCES Inventory(ItemID)
);
CREATE TABLE PurchaseReturn (
    ReturnID UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    PurchaseID UNIQUEIDENTIFIER NOT NULL,
    ItemID UNIQUEIDENTIFIER NOT NULL,
    Quantity INT,
    ReturnReason VARCHAR(255),
    ReturnDate DATE DEFAULT GETDATE(),
    CONSTRAINT FK_PurchaseReturn_Purchase FOREIGN KEY (PurchaseID) REFERENCES Purchase(PurchaseID),
    CONSTRAINT FK_PurchaseReturn_Inventory FOREIGN KEY (ItemID) REFERENCES Inventory(ItemID)
);
CREATE TABLE Sales (
    SalesID UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    CustomerName VARCHAR(255),
     
    Phone VARCHAR(15),
    Email VARCHAR(255),
    BillDate DATE,
    TotalAmount DECIMAL(18, 2)
);
 
CREATE TABLE SalesItem (
    SalesItemID UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    SalesID UNIQUEIDENTIFIER NOT NULL,
    ItemID UNIQUEIDENTIFIER NOT NULL,
    Quantity INT,
    BatchNumber VARCHAR(50),
    SellingPrice DECIMAL(18, 2),
    CONSTRAINT FK_SalesItem_Sales FOREIGN KEY (SalesID) REFERENCES Sales(SalesID),
    CONSTRAINT FK_SalesItem_Inventory FOREIGN KEY (ItemID) REFERENCES Inventory(ItemID)
);
CREATE TABLE SalesReturn (
    ReturnID UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    SalesID UNIQUEIDENTIFIER NOT NULL,
    ItemID UNIQUEIDENTIFIER NOT NULL,
    Quantity INT,
    ReturnReason VARCHAR(255),
    ReturnDate DATE DEFAULT GETDATE(),
    CONSTRAINT FK_SalesReturn_Sales FOREIGN KEY (SalesID) REFERENCES Sales(SalesID),
    CONSTRAINT FK_SalesReturn_Inventory FOREIGN KEY (ItemID) REFERENCES Inventory(ItemID)
);


CREATE TABLE Employee (
    EmployeeID UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    Name VARCHAR(255) NOT NULL,
    Address VARCHAR(500),
    Education VARCHAR(255),
    Position VARCHAR(100),
    DOJ DATE,
    SalaryPackage DECIMAL(18, 2),
    Phone VARCHAR(15),
    Email VARCHAR(255),
    StatusCode INT NOT NULL,
    CONSTRAINT FK_Employee_StatusCodes FOREIGN KEY (StatusCode) REFERENCES StatusCodes(StatusCode)
);
--if needed
CREATE TABLE Payroll (
    PayrollID UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    EmployeeID UNIQUEIDENTIFIER NOT NULL,
    BasicSalary DECIMAL(18, 2),
    DA DECIMAL(18, 2),  -- Dearness Allowance
    OtherAllowances DECIMAL(18, 2),
    TotalSalary AS (BasicSalary + DA + OtherAllowances) PERSISTED,
    CONSTRAINT FK_Payroll_Employee FOREIGN KEY (EmployeeID) REFERENCES Employee(EmployeeID)
);
