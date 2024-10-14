USE master
GO

CREATE DATABASE EmployeeJobTitle
GO

USE EmployeeJobTitle
GO

CREATE TABLE DBAccount(
  AccountID nvarchar(20) primary key,
  AccountPassword nvarchar(80) not null,
  FullName nvarchar(100), 
  AccountRole int
)
GO
INSERT INTO DBAccount VALUES(N'lauria',N'123', N'Lauria', 2);
INSERT INTO DBAccount VALUES(N'admin',N'123', N'Administrator', 1);
GO

CREATE TABLE JobTitle(
  JobTitleID nvarchar(20) primary key,
  JobTitleName nvarchar(80) not null,
  JobTitleDescription nvarchar(250)
)
GO

CREATE TABLE Employee (
 EmployeeID nvarchar(20) primary key,
 EmployeeName nvarchar(120) not null,
 YearOfBirth int,
 DepartmentName nvarchar(50),
 JobTitleID nvarchar(20) references JobTitle(JobTitleID) on delete cascade on update cascade
)
GO

INSERT INTO JobTitle VALUES(N'JT0001',N'Software Engineering', N'Software Engineering Description')
INSERT INTO JobTitle VALUES(N'JT0002',N'Business Analysis', N'Business Analysis Description')
INSERT INTO JobTitle VALUES(N'JT0003',N'Accountant', N'Accountant Description')
INSERT INTO JobTitle VALUES(N'JT0004',N'HR Specialist', N'HR Specialist Description')
INSERT INTO JobTitle VALUES(N'JT0005',N'Software Tester', N'Software Tester Description')


INSERT INTO Employee VALUES(N'EM0001',N'Rahaf Mohammed', 1991, N'Information Technology', 'JT0001')
INSERT INTO Employee VALUES(N'EM0002',N'Liza Koshy', 1992, N'Information Technology', 'JT0002')
INSERT INTO Employee VALUES(N'EM0003',N'Brian Kolfage', 1982, N'Financial', 'JT0003')
INSERT INTO Employee VALUES(N'EM0004',N'James Charles', 1983, N'Human Resource', 'JT0004')
INSERT INTO Employee VALUES(N'EM0005',N'Micheal Jackson', 1984, N'Information Technology', 'JT0001')
INSERT INTO Employee VALUES(N'EM0006',N'Tom Hank', 1984, N'Information Technology', 'JT0005')