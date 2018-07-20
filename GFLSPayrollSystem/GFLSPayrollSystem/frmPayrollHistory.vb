Public Class frmPayrollHistory
    Sub viewEmployeePayrollHistory()

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
                .CommandText = "SELECT dbo.tblPayroll.payrollID,dbo.tblPayroll.dateFrom,dbo.tblPayroll.dateTo,dbo.tblPayrollofEmployees.Netpay," & _
                        "dbo.tblPayrollofEmployees.Deduction,dbo.tblPayrollofEmployees.grossPay FROM dbo.tblPayrollofEmployees INNER JOIN dbo.tblPayroll " & _
                        "ON dbo.tblPayroll.payrollID = dbo.tblPayrollofEmployees.payrollID where empid = '" & txtemID.Text & "' order by dateTo desc"

            End With
            OleDBDR = OleDBC.ExecuteReader
            dgw.Rows.Clear()
            If OleDBDR.HasRows Then
                While OleDBDR.Read
                    dgw.Rows.Add()
                    dgw.Item(0, c).Value = OleDBDR.Item(0)
                    dgw.Item(1, c).Value = OleDBDR.Item(1) & " - " & OleDBDR.Item(2)
                    dgw.Item(2, c).Value = Format(OleDBDR.Item(3), "N")
                    dgw.Item(3, c).Value = Format(OleDBDR.Item(4), "N")
                    dgw.Item(4, c).Value = Format(OleDBDR.Item(5), "N")
                    c = c + 1
                End While
                dgw.ClearSelection()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub frmPayrollHistory_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewEmployeePayrollHistory()
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
                                "dbo.tblPayrollofEmployees.overtimeHRS,dbo.tblPayrollofEmployees.lateUTMins,dbo.tblPayrollofEmployees.basicPay," & _
                                "dbo.tblPayrollofEmployees.absentInAmount,dbo.tblPayrollofEmployees.overtimePay," & _
                                "dbo.tblPayrollofEmployees.regHolidayPay,dbo.tblPayrollofEmployees.nonWorkHolidayPay,dbo.tblPayrollofEmployees.lateUndertimeDed," & _
                                "dbo.tblPayrollofEmployees.sssPrems,dbo.tblPayrollofEmployees.piPrems,dbo.tblPayrollofEmployees.phPrems,dbo.tblPayrollofEmployees.sssLoans," & _
                                "dbo.tblPayrollofEmployees.piLoans,dbo.tblPayrollofEmployees.ledgerBalance,dbo.tblPayrollofEmployees.wHoldingTax,dbo.tblPayrollofEmployees.cashAdvance," & _
                                "dbo.tblPayrollofEmployees.Deduction,dbo.tblPayrollofEmployees.grossPay,dbo.tblPayrollofEmployees.Netpay FROM dbo.tblPayrollofEmployees INNER JOIN dbo.tblEmployee ON " & _
                                "dbo.tblEmployee.empid = dbo.tblPayrollofEmployees.empID INNER JOIN dbo.tblPayroll ON dbo.tblPayroll.payrollID = dbo.tblPayrollofEmployees.payrollID" & _
                                " where dbo.tblPayroll.payrollID = '" & dgw.CurrentRow.Cells(0).Value & "' and dbo.tblPayrollofEmployees.empid = '" & txtemID.Text & "'"
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
                .Columns.Add("SPECHOLIDAYS")
                .Columns.Add("NONWORKHOLIDAYS")
                .Columns.Add("OVERTIME")
                .Columns.Add("LATEUNDERTIME")
                .Columns.Add("REGWORKCASH")
                .Columns.Add("AbsentInAmount")
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
                                    OleDBDR.Item(3) & ", " & OleDBDR.Item(4) & " " & OleDBDR.Item(5), OleDBDR.Item(6), Format(OleDBDR.Item(7), "N"), Format(OleDBDR.Item(8), "MM/dd/yyyy"),
                                    Format(OleDBDR.Item(9), "0.0"), Format(OleDBDR.Item(10), "0.0"), Format(OleDBDR.Item(11), "0.0"), Format(OleDBDR.Item(12), "0.0"), Format(OleDBDR.Item(13), "0.0"),
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
    Private Sub PrintPayslipToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintPayslipToolStripMenuItem.Click
        printPayslip()
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

End Class