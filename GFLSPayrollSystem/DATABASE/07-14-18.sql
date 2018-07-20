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

 Date: 14/07/2018 17:07:23
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
INSERT INTO [dbo].[tblEmployee]  VALUES (N'EMP-00001', N'DUMAGO', N'RODMAR', N'AGUILAR', N'GREENVILLE, CALUMPANG GENERAL SANTOS CITY', N'12312321', N'1996-06-19 00:00:00.0000000', N'Male', N'Single', N'TEACHER 1', N'20000', N'Monthly', N'2017-10-01 00:00:00.0000000', N'Active', N'', N'', N'', N'', N'Yes', N'Employee Updated of 11/07/2018 1:26:53 PM')
GO

INSERT INTO [dbo].[tblEmployee]  VALUES (N'EMP-00002', N'ADSDASD', N'ASDASDA', N'ASDASD', N'ASDASDA', N'ASDASDASD', N'2017-10-01 00:00:00.0000000', N'Male', N'Single', N'11231', N'10000', N'Monthly', N'2018-07-13 00:00:00.0000000', N'Active', N'', N'', N'', N'', N'No', N'Employee Added of 13/07/2018 4:01:16 PM')
GO


-- ----------------------------
-- Table structure for tblPayroll
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[tblPayroll]') AND type IN ('U'))
	DROP TABLE [dbo].[tblPayroll]
GO

CREATE TABLE [dbo].[tblPayroll] (
  [payrollID] varchar(255) COLLATE Latin1_General_CI_AS  NOT NULL,
  [dateCreated] datetime2(7)  NULL,
  [dateFrom] datetime2(7)  NULL,
  [dateTo] datetime2(7)  NULL,
  [totalEmployees] int  NULL,
  [totalOvertime] money  NULL,
  [totalGrossPay] money  NULL,
  [totalDeduction] money  NULL,
  [totalNetpay] money  NULL,
  [preparedBy] varchar(255) COLLATE Latin1_General_CI_AS  NULL,
  [remarks] varchar(255) COLLATE Latin1_General_CI_AS  NULL
)
GO

ALTER TABLE [dbo].[tblPayroll] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of tblPayroll
-- ----------------------------
INSERT INTO [dbo].[tblPayroll]  VALUES (N'PR-00001', N'2018-07-13 00:00:00.0000000', N'2018-07-16 00:00:00.0000000', N'2018-07-31 00:00:00.0000000', N'2', N'.0000', N'15000.0000', N'.0000', N'15000.0000', N'RODMAR DUMAGO', N'TEST')
GO

INSERT INTO [dbo].[tblPayroll]  VALUES (N'PR-00002', N'2018-07-14 00:00:00.0000000', N'2018-08-01 00:00:00.0000000', N'2018-08-15 00:00:00.0000000', N'1', N'.0000', N'15000.0000', N'.0000', N'15000.0000', N'RODMAR DUMAGO', N'TEST')
GO

INSERT INTO [dbo].[tblPayroll]  VALUES (N'PR-00003', N'2018-07-14 00:00:00.0000000', N'2018-08-01 00:00:00.0000000', N'2018-08-15 00:00:00.0000000', N'1', N'.0000', N'10000.0000', N'.0000', N'10000.0000', N'RODMAR DUMAGO', N'TEST')
GO

INSERT INTO [dbo].[tblPayroll]  VALUES (N'PR-00004', N'2018-07-14 00:00:00.0000000', N'2018-08-16 00:00:00.0000000', N'2018-08-31 00:00:00.0000000', N'2', N'336.5400', N'15951.9300', N'60.1000', N'15891.8300', N'RODMAR DUMAGO', N'TEST')
GO

INSERT INTO [dbo].[tblPayroll]  VALUES (N'PR-00006', N'2018-07-14 00:00:00.0000000', N'2018-09-01 00:00:00.0000000', N'2018-09-15 00:00:00.0000000', N'2', N'.0000', N'15000.0000', N'.0000', N'15000.0000', N'Rodmar Dumago', N'Payroll Generated:07/14/2018')
GO

INSERT INTO [dbo].[tblPayroll]  VALUES (N'PR-00007', N'2018-07-14 00:00:00.0000000', N'2018-10-01 00:00:00.0000000', N'2018-10-15 00:00:00.0000000', N'2', N'.0000', N'15000.0000', N'.0000', N'15000.0000', N'Rodmar', N'Payroll Generated:07/14/2018')
GO


-- ----------------------------
-- Table structure for tblPayrollofEmployees
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[tblPayrollofEmployees]') AND type IN ('U'))
	DROP TABLE [dbo].[tblPayrollofEmployees]
GO

CREATE TABLE [dbo].[tblPayrollofEmployees] (
  [empPayrollTransNo] int  IDENTITY(1,1) NOT NULL,
  [payrollID] varchar(255) COLLATE Latin1_General_CI_AS  NULL,
  [empID] varchar(255) COLLATE Latin1_General_CI_AS  NULL,
  [absent] int  NULL,
  [regHolidays] int  NULL,
  [NonWorkHolidays] int  NULL,
  [leavePay] int  NULL,
  [overtimeHRS] int  NULL,
  [lateUTMins] int  NULL,
  [basicPay] money  NULL,
  [regHolidayPay] money  NULL,
  [nonWorkHolidayPay] money  NULL,
  [leavePayCash] money  NULL,
  [overtimePay] money  NULL,
  [lateUndertimeDed] money  NULL,
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
-- Records of tblPayrollofEmployees
-- ----------------------------
SET IDENTITY_INSERT [dbo].[tblPayrollofEmployees] ON
GO

INSERT INTO [dbo].[tblPayrollofEmployees] ([empPayrollTransNo], [payrollID], [empID], [absent], [regHolidays], [NonWorkHolidays], [leavePay], [overtimeHRS], [lateUTMins], [basicPay], [regHolidayPay], [nonWorkHolidayPay], [leavePayCash], [overtimePay], [lateUndertimeDed], [cashAdvance], [wHoldingTax], [sssPrems], [piPrems], [phPrems], [sssLoans], [piLoans], [phLoans], [grossPay], [Deduction], [Netpay]) VALUES (N'23', N'PR-00001', N'EMP-00001', N'0', N'0', N'0', N'0', N'0', N'0', N'10000.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'10000.0000', N'.0000', N'10000.0000')
GO

INSERT INTO [dbo].[tblPayrollofEmployees] ([empPayrollTransNo], [payrollID], [empID], [absent], [regHolidays], [NonWorkHolidays], [leavePay], [overtimeHRS], [lateUTMins], [basicPay], [regHolidayPay], [nonWorkHolidayPay], [leavePayCash], [overtimePay], [lateUndertimeDed], [cashAdvance], [wHoldingTax], [sssPrems], [piPrems], [phPrems], [sssLoans], [piLoans], [phLoans], [grossPay], [Deduction], [Netpay]) VALUES (N'24', N'PR-00001', N'EMP-00002', N'0', N'0', N'0', N'0', N'0', N'0', N'5000.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'5000.0000', N'.0000', N'5000.0000')
GO

INSERT INTO [dbo].[tblPayrollofEmployees] ([empPayrollTransNo], [payrollID], [empID], [absent], [regHolidays], [NonWorkHolidays], [leavePay], [overtimeHRS], [lateUTMins], [basicPay], [regHolidayPay], [nonWorkHolidayPay], [leavePayCash], [overtimePay], [lateUndertimeDed], [cashAdvance], [wHoldingTax], [sssPrems], [piPrems], [phPrems], [sssLoans], [piLoans], [phLoans], [grossPay], [Deduction], [Netpay]) VALUES (N'28', N'PR-00002', N'EMP-00002', N'0', N'0', N'0', N'0', N'0', N'0', N'5000.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'5000.0000', N'.0000', N'5000.0000')
GO

INSERT INTO [dbo].[tblPayrollofEmployees] ([empPayrollTransNo], [payrollID], [empID], [absent], [regHolidays], [NonWorkHolidays], [leavePay], [overtimeHRS], [lateUTMins], [basicPay], [regHolidayPay], [nonWorkHolidayPay], [leavePayCash], [overtimePay], [lateUndertimeDed], [cashAdvance], [wHoldingTax], [sssPrems], [piPrems], [phPrems], [sssLoans], [piLoans], [phLoans], [grossPay], [Deduction], [Netpay]) VALUES (N'29', N'PR-00003', N'EMP-00001', N'0', N'0', N'0', N'0', N'0', N'0', N'10000.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'10000.0000', N'.0000', N'10000.0000')
GO

INSERT INTO [dbo].[tblPayrollofEmployees] ([empPayrollTransNo], [payrollID], [empID], [absent], [regHolidays], [NonWorkHolidays], [leavePay], [overtimeHRS], [lateUTMins], [basicPay], [regHolidayPay], [nonWorkHolidayPay], [leavePayCash], [overtimePay], [lateUndertimeDed], [cashAdvance], [wHoldingTax], [sssPrems], [piPrems], [phPrems], [sssLoans], [piLoans], [phLoans], [grossPay], [Deduction], [Netpay]) VALUES (N'30', N'PR-00004', N'EMP-00001', N'1', N'1', N'1', N'1', N'2', N'30', N'9230.7700', N'769.2300', N'230.7700', N'769.2300', N'192.3100', N'48.0800', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'11192.3100', N'48.0800', N'11144.2300')
GO

INSERT INTO [dbo].[tblPayrollofEmployees] ([empPayrollTransNo], [payrollID], [empID], [absent], [regHolidays], [NonWorkHolidays], [leavePay], [overtimeHRS], [lateUTMins], [basicPay], [regHolidayPay], [nonWorkHolidayPay], [leavePayCash], [overtimePay], [lateUndertimeDed], [cashAdvance], [wHoldingTax], [sssPrems], [piPrems], [phPrems], [sssLoans], [piLoans], [phLoans], [grossPay], [Deduction], [Netpay]) VALUES (N'31', N'PR-00004', N'EMP-00002', N'1', N'0', N'0', N'0', N'3', N'15', N'4615.3800', N'.0000', N'.0000', N'.0000', N'144.2300', N'12.0200', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'4759.6200', N'12.0200', N'4747.6000')
GO

INSERT INTO [dbo].[tblPayrollofEmployees] ([empPayrollTransNo], [payrollID], [empID], [absent], [regHolidays], [NonWorkHolidays], [leavePay], [overtimeHRS], [lateUTMins], [basicPay], [regHolidayPay], [nonWorkHolidayPay], [leavePayCash], [overtimePay], [lateUndertimeDed], [cashAdvance], [wHoldingTax], [sssPrems], [piPrems], [phPrems], [sssLoans], [piLoans], [phLoans], [grossPay], [Deduction], [Netpay]) VALUES (N'47', N'PR-00006', N'EMP-00001', N'0', N'0', N'0', N'0', N'0', N'0', N'10000.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'10000.0000', N'.0000', N'10000.0000')
GO

INSERT INTO [dbo].[tblPayrollofEmployees] ([empPayrollTransNo], [payrollID], [empID], [absent], [regHolidays], [NonWorkHolidays], [leavePay], [overtimeHRS], [lateUTMins], [basicPay], [regHolidayPay], [nonWorkHolidayPay], [leavePayCash], [overtimePay], [lateUndertimeDed], [cashAdvance], [wHoldingTax], [sssPrems], [piPrems], [phPrems], [sssLoans], [piLoans], [phLoans], [grossPay], [Deduction], [Netpay]) VALUES (N'48', N'PR-00006', N'EMP-00002', N'0', N'0', N'0', N'0', N'0', N'0', N'5000.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'5000.0000', N'.0000', N'5000.0000')
GO

INSERT INTO [dbo].[tblPayrollofEmployees] ([empPayrollTransNo], [payrollID], [empID], [absent], [regHolidays], [NonWorkHolidays], [leavePay], [overtimeHRS], [lateUTMins], [basicPay], [regHolidayPay], [nonWorkHolidayPay], [leavePayCash], [overtimePay], [lateUndertimeDed], [cashAdvance], [wHoldingTax], [sssPrems], [piPrems], [phPrems], [sssLoans], [piLoans], [phLoans], [grossPay], [Deduction], [Netpay]) VALUES (N'49', N'PR-00007', N'EMP-00001', N'0', N'0', N'0', N'0', N'0', N'0', N'10000.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'10000.0000', N'.0000', N'10000.0000')
GO

INSERT INTO [dbo].[tblPayrollofEmployees] ([empPayrollTransNo], [payrollID], [empID], [absent], [regHolidays], [NonWorkHolidays], [leavePay], [overtimeHRS], [lateUTMins], [basicPay], [regHolidayPay], [nonWorkHolidayPay], [leavePayCash], [overtimePay], [lateUndertimeDed], [cashAdvance], [wHoldingTax], [sssPrems], [piPrems], [phPrems], [sssLoans], [piLoans], [phLoans], [grossPay], [Deduction], [Netpay]) VALUES (N'50', N'PR-00007', N'EMP-00002', N'0', N'0', N'0', N'0', N'0', N'0', N'5000.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'.0000', N'5000.0000', N'.0000', N'5000.0000')
GO

SET IDENTITY_INSERT [dbo].[tblPayrollofEmployees] OFF
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
ALTER TABLE [dbo].[tblPayrollofEmployees] ADD CONSTRAINT [PK__tblPayro__AB921DDA0EA330E9] PRIMARY KEY CLUSTERED ([empPayrollTransNo])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO

