-- Insert sample data into ITAMS

-- Insert Employees
INSERT INTO Assets (Asset_Type, Serial_Number, Purchase_Date, Status) VALUES
('Computer', 'SN0001', '2025-03-10', 'In Use'),
('Monitor', 'SN0002', '2025-03-28','Available'),
('Printer', 'SN0003', '2025-02-02', 'Under Maintenance');

INSERT INTO Administrators (Name, Email, Department, Permissions) VALUES
('Thanh Admin', 'thanhadmin@example.com', 'IT', 'Full Access'),
('James Smith', 'james.smith@example.com', 'Database','Limited Acces');

INSERT INTO Employees (First_Name, Last_Name, Email, Department) VALUES
('Alice', 'Brown', 'alice.brown@example.com', 'IT'),
('Bana','na', 'bana.na@example.com', 'Finance'),
('Mao','Mao','mao.mao@example.com', 'HR'),
('Charlie','Johnson', 'charlie.johnson@example.com', 'Marketing');

-- Insert Software Licenses
INSERT INTO Software_Licenses (Software_Name, License_Key, Expiration_Date, Assigned_Employee_Id) VALUES
('Microsoft Office', 'KEY-1111-2222-3333', '2026-05-10', 1),
('Adobe Acrobat ', 'KEY-4444-5555-6666', '2025-08-15', 2),
('AutoCAD', 'KEY-7777-8888-9999', '2027-01-20', NULL);

-- Insert Maintenance Records
INSERT INTO Maintenance_Records (Asset_Id, Issue_Description, Maintenance_Date, Technician_Name) VALUES
(3, 'Printer not responding', '2024-03-10', 'John Will'),
(1, 'Laptop battery replacement', '2024-02-20', 'Sarah Kim');
