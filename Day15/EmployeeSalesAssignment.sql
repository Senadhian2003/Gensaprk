create database CompanyAsgn;

use CompanyAsgn;

Create table Employee(
	id int constraint pk_employeeId primary key,
	Name varchar(20),
	Salary Decimal(10,2),
	DeptName varchar(20),
	BossNo int NULL constraint fk_Employee_EmpBoss foreign key references Employee(id),
);


Create table Department(
	Name varchar(20) constraint pk_DeptName primary key,
	Deptfloor int,
	Phone varchar(15),
	EmpNo int NOT NULL
);

alter table Employee
add constraint fk_Dept_EmpDept 
foreign key (DeptName) references Department(Name);


select * from Employee;

Create table Sales(
	SalesId int constraint pk_SalesId primary key,
	SaleQuantity float,
	ItemName varchar(50) NOT NULL constraint fk_Sales_ItemName foreign key references Item(Name),
	DeptName varchar(20) NOT NULL constraint fk_Sales_DeptName foreign key references Department(Name),

)

Create table Item(
	Name varchar(50) constraint pk_ItemName primary key,
	Type varchar(20),
	Color varchar(20)
)




INSERT INTO Employee (id, Name, Salary, BossNo)
VALUES
(1, 'Alice', 75000, NULL),
(2, 'Ned', 45000, 1),
(3, 'Andrew', 25000, 2),
(4, 'Clare', 22000, 2),
(5, 'Todd', 38000, 1),
(6, 'Nancy', 22000, 5),
(7, 'Brier', 43000, 1),
(8, 'Sarah', 56000, 7),
(9, 'Sophie', 35000, 1),
(10, 'Sanjay', 15000, 3),
(11, 'Rita', 15000, 4),
(12, 'Gigi', 16000, 4),
(13, 'Maggie', 11000, 4),
(14, 'Paul', 15000, 3),
(15, 'James', 15000, 3),
(16, 'Pat', 15000, 3),
(17, 'Mark', 15000, 3);

alter table Department drop constraint fk_Dept_EmpName;
drop table Department;

Alter table Department add constraint fk_Dept_ManagerId foreign key(EmpNo) references Employee(id); 

INSERT INTO Department (Name, DeptFloor, Phone, EmpNo)
VALUES
('Management', 5, 34, 1),
('Books', 1, 81, 4),
('Clothes', 2, 24, 4),
('Equipment', 3, 57, 3),
('Furniture', 4, 14, 3),
('Navigation', 1, 41, 3),
('Recreation', 2, 29, 4),
('Accounting', 5, 35, 5),
('Purchasing', 5, 36, 7),
('Personnel', 5, 37, 9),
('Marketing', 5, 38, 2);

UPDATE Employee
SET DeptName = 'Management'
WHERE id = 1;

UPDATE Employee
SET DeptName = 'Marketing'
WHERE id IN (2, 3, 4);

UPDATE Employee
SET DeptName = 'Accounting'
WHERE id IN (5, 6);

UPDATE Employee
SET DeptName = 'Purchasing'
WHERE id IN (7, 8);

UPDATE Employee
SET DeptName = 'Personnel'
WHERE id = 9;

UPDATE Employee
SET DeptName = 'Navigation'
WHERE id = 10;

UPDATE Employee
SET DeptName = 'Books'
WHERE id IN (11, 12, 13);

UPDATE Employee
SET DeptName = 'Equipment'
WHERE id IN (14, 15, 16, 17);




ALTER TABLE Employee
ALTER column DeptName varchar(20) NOT NULL;

INSERT INTO Item (Name, Type, Color)
VALUES
('Pocket Knife-Nile', 'E', 'Brown'),
('Pocket Knife-Avon', 'E', 'Brown'),
('Compass', 'N', NULL),
('Geo positioning system', 'N', NULL),
('Elephant Polo stick', 'R', 'Bamboo'),
('Camel Saddle', 'R', 'Brown'),
('Sextant', 'N', NULL),
('Map Measure', 'N', NULL),
('Boots-snake proof', 'C', 'Green'),
('Pith Helmet', 'C', 'Khaki'),
('Hat-polar Explorer', 'C', 'White'),
('Exploring in 10 Easy Lessons', 'B', NULL),
('Hammock', 'F', 'Khaki'),
('How to win Foreign Friends', 'B', NULL),
('Map case', 'E', 'Brown'),
('Safari Chair', 'F', 'Khaki'),
('Safari cooking kit', 'F', 'Khaki'),
('Stetson', 'C', 'Black'),
('Tent - 2 person', 'F', 'Khaki'),
('Tent -8 person', 'F', 'Khaki');


INSERT INTO Sales (SalesId, ItemName, DeptName)
VALUES
(101, 'Boots-snake proof', 'Clothes'),
(102, 'Pith Helmet', 'Clothes'),
(103, 'Sextant', 'Navigation'),
(104, 'Hat-polar Explorer', 'Clothes'),
(105, 'Pith Helmet', 'Equipment'),
(106, 'Pocket Knife-Nile', 'Clothes'),
(107, 'Pocket Knife-Nile', 'Recreation'),
(108, 'Compass', 'Navigation'),
(109, 'Geo positioning system', 'Navigation'),
(110, 'Map Measure', 'Navigation'),
(111, 'Geo positioning system', 'Books'),
(112, 'Sextant', 'Books'),
(113, 'Pocket Knife-Nile', 'Books'),
(114, 'Pocket Knife-Nile', 'Navigation'),
(115, 'Pocket Knife-Nile', 'Equipment'),
(116, 'Sextant', 'Clothes'),
(117, 'Sextant', 'Equipment'),
(118, 'Sextant', 'Recreation'),
(119, 'Sextant', 'Furniture'),
(120, 'Pocket Knife-Nile', 'Furniture'),
(121, 'Exploring in 10 easy lessons', 'Books'),
(122, 'How to win foreign friends', 'Books'),
(123, 'Compass', 'Books'),
(124, 'Pith Helmet', 'Books'),
(125, 'Elephant Polo stick', 'Recreation'),
(126, 'Camel Saddle', 'Recreation');

