Public Class frmEmployeeName
    Dim empids As ComboBox
    Dim combocount As Integer

    Sub AddPayrollCMD()
        Dim sssData As String
        Dim phData As String
        Dim piData As String
        Try
            If conn.State = ConnectionState.Open Then
                OleDBC.Dispose()
                conn.Close()
            End If
            If conn.State <> ConnectionState.Open Then
                ConnectDatabase()
            End If
            With OleDBC
                .Connection = conn
                .CommandText = "select * from tblEmployee where EMPID = '" & dgw.CurrentRow.Cells(0).Value & "'"
            End With
            OleDBDR = OleDBC.ExecuteReader
            If OleDBDR.HasRows Then
                If OleDBDR.Read Then
                    frmPayroll.txtemID.Text = OleDBDR.Item(0)
                    frmPayroll.txtName.Text = OleDBDR.Item(1) & ", " & OleDBDR.Item(2) & " " & OleDBDR.Item(3)
                    frmPayroll.txtPos.Text = OleDBDR.Item(9)
                    frmPayroll.txtPayMethod.Text = OleDBDR.Item(11)
                    frmPayroll.dtrDH.Value = OleDBDR.Item(12)
                    frmPayroll.rate = OleDBDR.Item(10)
                    frmPayroll.txtDR.Text = OleDBDR.Item(10)
                    If frmPayroll.txtPayMethod.Text = "Monthly" Then
                        frmPayroll.lblRW.Text = "Absent/Rest Days"
                    Else
                        frmPayroll.lblRW.Text = "Regular Worked Days"
                    End If
                    frmPayroll.premDed = OleDBDR.Item(18)
                    sssData = OleDBDR.Item(14)
                    If sssData = "" Then
                        frmPayroll.sssNo = False
                    Else
                        frmPayroll.sssNo = True
                    End If
                    phData = OleDBDR.Item(17)
                    If phData = "" Then
                        frmPayroll.phNo = False
                    Else
                        frmPayroll.phNo = True
                    End If
                    piData = OleDBDR.Item(16)
                    If piData = "" Then
                        frmPayroll.piNo = False
                    Else
                        frmPayroll.piNo = True
                    End If
                    frmPayroll.clear()
                    Me.Close()
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub searchExisting()
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
                .CommandText = "select dbo.tblEmployee.empid,dbo.tblEmployee.lastname,dbo.tblEmployee.firstname,dbo.tblEmployee.middlename from dbo.tblEmployee INNER JOIN " & _
                                "dbo.tblPayrollofEmployees ON dbo.tblEmployee.empid = dbo.tblPayrollofEmployees.empID INNER JOIN dbo.tblPayroll ON dbo.tblPayrollofEmployees.payrollID = " & _
                                "dbo.tblPayroll.payrollID where '" & Format(frmPayroll.dtrFrom.Value, "MM/dd/yyyy") & "' between dbo.tblPayroll.DATEFROM and " & _
                                "dbo.tblPayroll.DATETO  or '" & Format(frmPayroll.dtrTo.Value, "MM/dd/yyyy") & _
                                "' between dbo.tblPayroll.DATEFROM and dbo.tblPayroll.DATETO "

            End With
            OleDBDR = OleDBC.ExecuteReader
            combocount = 0
            empidss.Items.Clear()
            If OleDBDR.HasRows Then
                While OleDBDR.Read
                    empidss.Items.Add(OleDBDR.Item(0))
                    combocount = combocount + 1
                End While
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub showEmployee()
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
                '.CommandText = "select dbo.tblEmployee.empid,dbo.tblEmployee.lastname,dbo.tblEmployee.firstname,dbo.tblEmployee.middlename from dbo.tblEmployee INNER JOIN " & _
                '                "dbo.tblPayrollofEmployees ON dbo.tblEmployee.empid = dbo.tblPayrollofEmployees.empID INNER JOIN dbo.tblPayroll ON dbo.tblPayrollofEmployees.payrollID = " & _
                '                "dbo.tblPayroll.payrollID where '" & Format(frmPayroll.dtrFrom.Value, "MM/dd/yyyy") & "' between dbo.tblPayroll.DATEFROM and " & _
                '                "dbo.tblPayroll.DATETO and dbo.tblPayrollofEmployees.EMPID  = '" & frmPayroll.txtemID.Text & "' or '" & Format(frmPayroll.dtrTo.Value, "MM/dd/yyyy") & _
                '                "' between dbo.tblPayroll.DATEFROM and dbo.tblPayroll.DATETO and dbo.tblPayrollofEmployees.EMPID  = '" & frmPayroll.txtemID.Text & "'"
                .CommandText = "select * from tblEmployee"
            End With
            OleDBDR = OleDBC.ExecuteReader
            dgw.Rows.Clear()
            If OleDBDR.HasRows Then
                While OleDBDR.Read
                    Dim row1 As Integer
                    Dim col As Integer = 0
                    Dim hasitems As Integer = 0
                    'Dim i As Integer
                    row1 = combocount
                    While col < row1
                        If empidss.Items(col) = OleDBDR.Item(0) Then
                            hasitems = hasitems + 1

                        End If
                        col = col + 1
                    End While
                    If hasitems = 0 Then
                        dgw.Rows.Add()
                        dgw.Item(0, c).Value = OleDBDR.Item(0)
                        dgw.Item(1, c).Value = OleDBDR.Item(1) & ", " & OleDBDR.Item(2) & " " & OleDBDR.Item(3)
                        c = c + 1
                    End If
                End While
            End If
            dgw.ClearSelection()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub frmEmployeeName_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub frmEmployeeName_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub dgw_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgw.CellContentClick
        AddPayrollCMD()
    End Sub
End Class