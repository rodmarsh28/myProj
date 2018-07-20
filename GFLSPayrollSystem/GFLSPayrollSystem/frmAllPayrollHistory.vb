Public Class frmAllPayrollHistory
    Sub ShowAllPayrollHistory()
        Try
            If conn.State = ConnectionState.Open Then
                OleDBC.Dispose()
                conn.Close()
            End If
            If conn.State <> ConnectionState.Open Then
                ConnectDatabase()
            End If
            Dim c As Integer
            c = 0
            With OleDBC
                .Connection = conn
                .CommandText = "select * from tblPayroll "

            End With
            OleDBDR = OleDBC.ExecuteReader
            dgw.Rows.Clear()
            If OleDBDR.HasRows Then
                While OleDBDR.Read
                    dgw.Rows.Add()
                    dgw.Item(0, c).Value = OleDBDR.Item(0)
                    dgw.Item(1, c).Value = OleDBDR.Item(2) & " - " & OleDBDR.Item(3)
                    dgw.Item(2, c).Value = Format(OleDBDR.Item(6), "N")
                    dgw.Item(3, c).Value = Format(OleDBDR.Item(7), "N")
                    dgw.Item(4, c).Value = Format(OleDBDR.Item(8), "N")
                    dgw.Item(5, c).Value = OleDBDR.Item(9)
                    c = c + 1
                End While
                dgw.ClearSelection()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub printPayroll()
        Try
            If conn.State = ConnectionState.Open Then
                OleDBC.Dispose()
                conn.Close()
            End If
            If conn.State <> ConnectionState.Open Then
                ConnectDatabase()
            End If
            Dim c As Integer
            c = 0
            With OleDBC
                .Connection = conn
                .CommandText = "SELECT dbo.tblPayroll.payrollID,dbo.tblPayroll.dateFrom,dbo.tblPayroll.dateTo,dbo.tblEmployee.empid,dbo.tblEmployee.lastname," & _
                                "dbo.tblEmployee.firstname,dbo.tblEmployee.middlename,dbo.tblPayrollofEmployees.absent,dbo.tblPayrollofEmployees.regHolidays," & _
                                "dbo.tblPayrollofEmployees.NonWorkHolidays,dbo.tblPayrollofEmployees.leavePay,dbo.tblPayrollofEmployees.overtimeHRS," & _
                                "dbo.tblPayrollofEmployees.lateUTMins,dbo.tblPayrollofEmployees.basicPay,dbo.tblPayrollofEmployees.absentInAmount,dbo.tblPayrollofEmployees.regHolidayPay," & _
                                "dbo.tblPayrollofEmployees.nonWorkHolidayPay,dbo.tblPayrollofEmployees.leavePayCash,dbo.tblPayrollofEmployees.overtimePay," & _
                                "dbo.tblPayrollofEmployees.lateUndertimeDed,dbo.tblPayrollofEmployees.sssPrems,dbo.tblPayrollofEmployees.piPrems,dbo.tblPayrollofEmployees.phPrems," & _
                                "dbo.tblPayrollofEmployees.sssLoans,dbo.tblPayrollofEmployees.piLoans,dbo.tblPayrollofEmployees.ledgerBalance,dbo.tblPayrollofEmployees.cashAdvance," & _
                                "dbo.tblPayrollofEmployees.grossPay,dbo.tblPayrollofEmployees.Deduction,dbo.tblPayrollofEmployees.Netpay,dbo.tblPayroll.totalDeduction," & _
                                "dbo.tblPayroll.totalGrossPay,dbo.tblPayroll.totalNetpay FROM dbo.tblPayroll INNER JOIN dbo.tblPayrollofEmployees ON dbo.tblPayroll.payrollID = " & _
                                "dbo.tblPayrollofEmployees.payrollID INNER JOIN dbo.tblEmployee ON dbo.tblEmployee.empid = dbo.tblPayrollofEmployees.empID " & _
                                " where dbo.tblPayroll.payrollID = '" & dgw.CurrentRow.Cells(0).Value & "'"
            End With
            OleDBDR = OleDBC.ExecuteReader
            Dim dt As New DataTable
            With dt
                .Columns.Add("payrollID")
                .Columns.Add("DATERANGE")
                .Columns.Add("Name")
                .Columns.Add("Worked Days")
                .Columns.Add("Holidays")
                .Columns.Add("NonWorkingHolidays")
                .Columns.Add("leavepay")
                .Columns.Add("overtime(HRS)")
                .Columns.Add("lateundertime(min)")
                .Columns.Add("Basic Pay")
                .Columns.Add("AbsentInAmount")
                .Columns.Add("RegularHolidayCash")
                .Columns.Add("NonWorkingHolidaysCash")
                .Columns.Add("Leave Pay")
                .Columns.Add("Overtime / Restday Report")
                .Columns.Add("Gross Pay")
                .Columns.Add("Late / Undertime")
                .Columns.Add("SSS Premiums")
                .Columns.Add("Pagibig Premiums")
                .Columns.Add("Philhealth Premiums")
                .Columns.Add("SSS Loans")
                .Columns.Add("Pagibig Loans")
                .Columns.Add("Philhealth Loans")
                .Columns.Add("Cash Advance")
                .Columns.Add("Total Deduction")
                .Columns.Add("Net Pay")
                .Columns.Add("DATE")
                .Columns.Add("totalAllDed")
                .Columns.Add("totalAllGross")
                .Columns.Add("totalallNet")
                .Columns.Add("PreparedBy")

            End With

            If OleDBDR.HasRows Then
                While OleDBDR.Read
                    dt.Rows.Add(OleDBDR.Item(0), Format(OleDBDR.Item(1), "MMMM") & " " & Format(OleDBDR.Item(1), "dd") & " - " + Format(OleDBDR.Item(2), "dd") & " " & Format(OleDBDR.Item(2), "yyyy"),
                                OleDBDR.Item(3) & ", " & OleDBDR.Item(4) & " " & OleDBDR.Item(5), OleDBDR.Item(6), OleDBDR.Item(7), OleDBDR.Item(8),
                                Format(OleDBDR.Item(9), "0.0"), Format(OleDBDR.Item(10), "0.0"), Format(OleDBDR.Item(11), "0.0"), Format(OleDBDR.Item(12), "N"), Format(OleDBDR.Item(13), "N"), Format(OleDBDR.Item(14), "N"),
                                Format(OleDBDR.Item(15), "N"), Format(OleDBDR.Item(16), "N"), Format(OleDBDR.Item(17), "N"), Format(OleDBDR.Item(18), "N"),
                                Format(OleDBDR.Item(19), "N"), Format(OleDBDR.Item(20), "N"), Format(OleDBDR.Item(21), "N"), Format(OleDBDR.Item(22), "N"),
                                Format(OleDBDR.Item(23), "N"), Format(OleDBDR.Item(24), "N"), Format(OleDBDR.Item(25), "N"), Format(OleDBDR.Item(26), "N"),
                                Format(OleDBDR.Item(27), "N"), Format(OleDBDR.Item(28), "N"), Format(Now, "MM/dd/yyyy"), Format(OleDBDR.Item(29), "N"),
                                Format(OleDBDR.Item(30), "N"), Format(OleDBDR.Item(31), "N"), frmMain.lblUsername.Text)
                    c = c + 1
                End While
            End If
            Dim rptDoc As CrystalDecisions.CrystalReports.Engine.ReportDocument
            rptDoc = New Payroll
            rptDoc.SetDataSource(dt)
            frmReportViewer.CrystalReportViewer1.ReportSource = rptDoc
            frmReportViewer.ShowDialog()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub printPayslip()
        Try
            If conn.State = ConnectionState.Open Then
                OleDBC.Dispose()
                conn.Close()
            End If
            If conn.State <> ConnectionState.Open Then
                ConnectDatabase()
            End If
            Dim c As Integer

            With OleDBC
                .Connection = conn
                .CommandText = "SELECT dbo.tblEmployee.empid,dbo.tblPayroll.datefrom,dbo.tblPayroll.dateto,dbo.tblEmployee.lastname," & _
                                "dbo.tblEmployee.firstname,dbo.tblEmployee.middlename,dbo.tblEmployee.[position],dbo.tblEmployee.rate,dbo.tblEmployee.dateHired," & _
                                "dbo.tblPayrollofEmployees.absent,dbo.tblPayrollofEmployees.regHolidays,dbo.tblPayrollofEmployees.NonWorkHolidays," & _
                                "dbo.tblPayrollofEmployees.overtimeHRS,dbo.tblPayrollofEmployees.lateUTMins,dbo.tblPayrollofEmployees.basicPay,dbo.tblPayrollofEmployees.absentInAmount,dbo.tblPayrollofEmployees.overtimePay," & _
                                "dbo.tblPayrollofEmployees.regHolidayPay,dbo.tblPayrollofEmployees.nonWorkHolidayPay,dbo.tblPayrollofEmployees.lateUndertimeDed," & _
                                "dbo.tblPayrollofEmployees.sssPrems,dbo.tblPayrollofEmployees.piPrems,dbo.tblPayrollofEmployees.phPrems,dbo.tblPayrollofEmployees.sssLoans," & _
                                "dbo.tblPayrollofEmployees.piLoans,dbo.tblPayrollofEmployees.ledgerBalance,dbo.tblPayrollofEmployees.wHoldingTax,dbo.tblPayrollofEmployees.cashAdvance," & _
                                "dbo.tblPayrollofEmployees.Deduction,dbo.tblPayrollofEmployees.grossPay,dbo.tblPayrollofEmployees.Netpay FROM dbo.tblPayrollofEmployees INNER JOIN dbo.tblEmployee ON " & _
                                "dbo.tblEmployee.empid = dbo.tblPayrollofEmployees.empID INNER JOIN dbo.tblPayroll ON dbo.tblPayroll.payrollID = dbo.tblPayrollofEmployees.payrollID" & _
                                " where dbo.tblPayroll.payrollID = '" & dgw.CurrentRow.Cells(0).Value & "'"
            End With
            OleDBDR = OleDBC.ExecuteReader
            Dim dt As New DataTable
           With dt
                .Columns.Add("EMPID")
                .Columns.Add("DATEPERIOD")
                .Columns.Add("NAME")
                .Columns.Add("POSITION")
                .Columns.Add("RATE")
                .Columns.Add("DATEHIRED")
                .Columns.Add("REGWORKDAYS")
                .Columns.Add("AbsentInAmountS")
                .Columns.Add("SPECHOLIDAYS")
                .Columns.Add("NONWORKHOLIDAYS")
                .Columns.Add("OVERTIME")
                .Columns.Add("LATEUNDERTIME")
                .Columns.Add("REGWORKCASH")
                .Columns.Add("OVERTIMECASH")
                .Columns.Add("SPECHOLIDAYCASH")
                .Columns.Add("NONWORKHOLIDAYCASH")
                .Columns.Add("LATEUNDERTIMECASH")
                .Columns.Add("SSS")
                .Columns.Add("PAGIBIG")
                .Columns.Add("PHILHEALTH")
                .Columns.Add("SSS LOANS")
                .Columns.Add("PAGIBIG LOANS")
                .Columns.Add("PHILHEALTH LOANS")
                .Columns.Add("WHOLDINGTAX")
                .Columns.Add("CASHADVANCE")
                .Columns.Add("TOTALDEDUCTIONS")
                .Columns.Add("GROSSPAY")
                .Columns.Add("NETPAY")


            End With

            If OleDBDR.HasRows Then
                While OleDBDR.Read
                    c = 0
                    While c < 2
                        dt.Rows.Add(OleDBDR.Item(0), Format(OleDBDR.Item(1), "MMMM") & " " & Format(OleDBDR.Item(1), "dd") & " - " + Format(OleDBDR.Item(2), "dd") & " " & Format(OleDBDR.Item(2), "yyyy"),
                                   OleDBDR.Item(3) & ", " & OleDBDR.Item(4) & " " & OleDBDR.Item(5), OleDBDR.Item(6), Format(OleDBDR.Item(7), "N"), Format(OleDBDR.Item(8), "N"),
                                   Format(OleDBDR.Item(9), "MM/dd/yyyy"), Format(OleDBDR.Item(10), "0.0"), Format(OleDBDR.Item(11), "0.0"), Format(OleDBDR.Item(12), "0.0"), Format(OleDBDR.Item(13), "0.0"),
                                   Format(OleDBDR.Item(14), "0.0"), Format(OleDBDR.Item(15), "N"), Format(OleDBDR.Item(16), "N"), Format(OleDBDR.Item(17), "N"),
                                   Format(OleDBDR.Item(18), "N"), Format(OleDBDR.Item(19), "N"), Format(OleDBDR.Item(20), "N"), Format(OleDBDR.Item(21), "N"),
                                    Format(OleDBDR.Item(22), "N"), Format(OleDBDR.Item(23), "N"), Format(OleDBDR.Item(24), "N"), Format(OleDBDR.Item(25), "N"),
                                     Format(OleDBDR.Item(26), "N"), Format(OleDBDR.Item(27), "N"), Format(OleDBDR.Item(28), "N"), Format(OleDBDR.Item(29), "N"), Format(OleDBDR.Item(30), "N"))
                        c = c + 1
                    End While
                End While
            End If
            Dim rptDoc As CrystalDecisions.CrystalReports.Engine.ReportDocument
            rptDoc = New Payslip
            rptDoc.SetDataSource(dt)
            frmReportViewer.CrystalReportViewer1.ReportSource = rptDoc
            frmReportViewer.ShowDialog()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub frmAllPayrollHistory_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            dgw.ClearSelection()
        End If
    End Sub

    Private Sub frmAllPayrollHistory_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ShowAllPayrollHistory()
    End Sub


    Private Sub dgw_CellMouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgw.CellMouseDown
        Try
            If e.Button = MouseButtons.Right Then
                dgw.CurrentCell = dgw(e.ColumnIndex, e.RowIndex)
                dgw.ContextMenuStrip = ContextMenuStrip1
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ContextMenuStrip1_Closing(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolStripDropDownClosingEventArgs) Handles ContextMenuStrip1.Closing
        dgw.ContextMenuStrip = ContextMenuStrip2
    End Sub

   
    Private Sub PrintPayrollToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintPayrollToolStripMenuItem.Click
        printPayroll()
    End Sub

    Private Sub PrintPayslipToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintPayslipToolStripMenuItem.Click
        printPayslip()
    End Sub
End Class