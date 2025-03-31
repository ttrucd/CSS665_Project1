-- Create tables for IT Asset Management System (ITAMS)

-- Assets Table
-- Functional Dependency: Asset_Id -> (Asset_Type, Serial_Number, Purchase_Date, Status)
CREATE TABLE Assets (
    Asset_Id INT IDENTITY(1,1) PRIMARY KEY,
    Asset_Type VARCHAR(50) NOT NULL, 
    Serial_Number VARCHAR(100) UNIQUE NOT NULL,
    Purchase_Date DATE NOT NULL, 
    Status VARCHAR(20) CHECK (Status IN ('In Use', 'Available', 'Under Maintenance', 'Retired')) NOT NULL

);

--Administrators Table
-- Funtional Dependency: Admin-Id -> (Name, Email, Department, Permissions)
CREATE TABLE Administrators (
    Admin_Id INT IDENTITY(1,1) PRIMARY KEY,
    Name VARCHAR(100) NOT NULL,
    Email VARCHAR(100) UNIQUE NOT NULL,
    Department VARCHAR(50) NOT NULL, 
    Permissions TEXT NOT NULL
);

-- Employees Table 
-- Functional Dependency: Employee_Id -> (First_Name, Last_Name, Email, Department)
CREATE TABLE Employees (
    Employee_Id INT IDENTITY(1,1) PRIMARY KEY, 
    First_Name VARCHAR(50) NOT NULL, 
    Last_Name VARCHAR(50) NOT NULL, 
    Email VARCHAR(100) UNIQUE NOT NULL, 
    Department VARCHAR(50) NOT NULL,
);

-- Software Licenses Table
CREATE TABLE Software_Licenses (
    License_ID INT IDENTITY(1,1) PRIMARY KEY,
    Software_Name VARCHAR(100) NOT NULL,
    License_Key VARCHAR(100) UNIQUE NOT NULL,
    Expiration_Date DATE NOT NULL,
    Assigned_Employee_ID INT NULL,
    FOREIGN KEY (Assigned_Employee_ID) REFERENCES Employees(Employee_ID) ON DELETE SET NULL
    -- Functional Dependency: License_ID → (Software_Name, License_Key, Expiration_Date, Assigned_Employee_ID)
);

-- Maintenance Records Table
CREATE TABLE Maintenance_Records (
    Record_ID INT IDENTITY(1,1) PRIMARY KEY,
    Asset_ID INT NOT NULL,
    Issue_Description TEXT NOT NULL,
    Maintenance_Date DATE NOT NULL,
    Technician_Name VARCHAR(100) NOT NULL,
    FOREIGN KEY (Asset_ID) REFERENCES Assets(Asset_ID) ON DELETE CASCADE
    -- Functional Dependency: Record_ID → (Asset_ID, Issue_Description, Maintenance_Date, Technician_Name)
);
