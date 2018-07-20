/*
 Navicat Premium Data Transfer

 Source Server         : generalLedgerDB
 Source Server Type    : SQL Server
 Source Server Version : 10001600
 Source Host           : dfarm3:1433
 Source Catalog        : gflsPayrollSystem
 Source Schema         : dbo

 Target Server Type    : SQL Server
 Target Server Version : 10001600
 File Encoding         : 65001

 Date: 10/07/2018 17:00:31
*/


-- ----------------------------
-- Table structure for tblEmployee
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[tblEmployee]') AND type IN ('U'))
	DROP TABLE [dbo].[tblEmployee]
GO

CREATE TABLE [dbo].[tblEmployee] (
  [empid] varchar(255) COLLATE Latin1_General_CI_AS  NOT NULL,
  [lastname] varchar(255) COLLATE Latin1_General_CI_AS  NULL,
  [firstname] varchar(255) COLLATE Latin1_General_CI_AS  NULL,
  [middlename] varchar(255) COLLATE Latin1_General_CI_AS  NULL,
  [address] varchar(255) COLLATE Latin1_General_CI_AS  NULL,
  [contactNo] varchar(255) COLLATE Latin1_General_CI_AS  NULL,
  [birthDate] datetime2(7)  NULL,
  [gender] varchar(255) COLLATE Latin1_General_CI_AS  NULL,
  [civilStatus] varchar(255) COLLATE Latin1_General_CI_AS  NULL,
  [position] varchar(255) COLLATE Latin1_General_CI_AS  NULL,
  [rate] int  NULL,
  [payMethod] varchar(255) COLLATE Latin1_General_CI_AS  NULL,
  [dateHired] datetime2(7)  NULL,
  [Status] varchar(255) COLLATE Latin1_General_CI_AS  NULL,
  [sss] varchar(255) COLLATE Latin1_General_CI_AS  NULL,
  [tin] varchar(255) COLLATE Latin1_General_CI_AS  NULL,
  [pagibig] varchar(255) COLLATE Latin1_General_CI_AS  NULL,
  [philhealth] varchar(255) COLLATE Latin1_General_CI_AS  NULL,
  [allowPremsDeductions] varchar(255) COLLATE Latin1_General_CI_AS  NULL,
  [remarks] varchar(255) COLLATE Latin1_General_CI_AS  NULL
)
GO

ALTER TABLE [dbo].[tblEmployee] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of tblEmployee
-- ----------------------------
INSERT INTO [dbo].[tblEmployee]  VALUES (N'EMP-00001', N'DUMAGO', N'RODMAR', N'AGUILAR', N'GREENVILLE, CALUMPANG GENERAL SANTOS CITY', N'12312321', N'1996-06-19 00:00:00.0000000', N'Male', N'Single', N'TEACHER 1', N'20000', N'Monthly', N'2017-10-01 00:00:00.0000000', N'Active', N'', N'', N'', N'', N'Yes', N'Employee Updated of 10/07/2018 3:51:18 PM')
GO


-- ----------------------------
-- Table structure for tblPayroll
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[tblPayroll]') AND type IN ('U'))
	DROP TABLE [dbo].[tblPayroll]
GO

CREATE TABLE [dbo].[tblPayroll] (
  [payrollID] varchar(1) COLLATE Latin1_General_CI_AS  NOT NULL,
  [dateCreated] datetime2(7)  NULL,
  [dateFrom] datetime2(7)  NULL,
  [dateTo] datetime2(7)  NULL,
  [totalEmployees] varchar(255) COLLATE Latin1_General_CI_AS  NULL,
  [totalOvertime] int  NULL,
  [totalGrossPay] int  NULL,
  [totalDeduction] int  NULL,
  [totalNetpay] int  NULL,
  [preparedBy] varchar(255) COLLATE Latin1_General_CI_AS  NULL,
  [remarks] varchar(255) COLLATE Latin1_General_CI_AS  NULL
)
GO

ALTER TABLE [dbo].[tblPayroll] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Table structure for tblPayrollofEmployees
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[tblPayrollofEmployees]') AND type IN ('U'))
	DROP TABLE [dbo].[tblPayrollofEmployees]
GO

CREATE TABLE [dbo].[tblPayrollofEmployees] (
  [empPayrollTransNo] int  NOT NULL,
  [payrollID] varchar(255) COLLATE Latin1_General_CI_AS  NULL,
  [empID] varchar(255) COLLATE Latin1_General_CI_AS  NULL,
  [absent] int  NULL,
  [regHolidays] int  NULL,
  [NonWorkHolidays] int  NULL,
  [leavePay] int  NULL,
  [overtimeHRS] int  NULL,
  [basicPay] money  NULL,
  [regHolidayPay] money  NULL,
  [nonWorkHolidayPay] money  NULL,
  [leavePayCash] money  NULL,
  [overtimePay] money  NULL,
  [lateUndertimeMins] money  NULL,
  [cashAdvance] money  NULL,
  [wHoldingTax] money  NULL,
  [sssPrems] money  NULL,
  [piPrems] money  NULL,
  [phPrems] money  NULL,
  [sssLoans] money  NULL,
  [piLoans] money  NULL,
  [phLoans] money  NULL,
  [grossPay] money  NULL,
  [Deduction] money  NULL,
  [Netpay] money  NULL
)
GO

ALTER TABLE [dbo].[tblPayrollofEmployees] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Primary Key structure for table tblEmployee
-- ----------------------------
ALTER TABLE [dbo].[tblEmployee] ADD CONSTRAINT [PK__tblEmplo__AF4CE8657F60ED59] PRIMARY KEY CLUSTERED ([empid])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table tblPayroll
-- ----------------------------
ALTER TABLE [dbo].[tblPayroll] ADD CONSTRAINT [PK__tblPayro__EBDFA71A03317E3D] PRIMARY KEY CLUSTERED ([payrollID])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table tblPayrollofEmployees
-- ----------------------------
ALTER TABLE [dbo].[tblPayrollofEmployees] ADD CONSTRAINT [PK__tblPayro__AB921DDA07020F21] PRIMARY KEY CLUSTERED ([empPayrollTransNo])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO

