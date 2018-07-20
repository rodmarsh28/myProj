Public Class frmEmployeeMasterlist
    Sub viewEmployees()
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
                .CommandText = "SELECT dbo.tblEmployee.empID,dbo.tblEmployee.lastname,dbo.tblEmployee.firstname," & _
                    "dbo.tblEmployee.middlename,dbo.tblEmployee.gender,dbo.tblEmployee.[position],dbo.tblEmployee.dateHired," & _
                    "dbo.tblEmployee.status FROM dbo.tblEmployee order by lastname asc"

            End With
            OleDBDR = OleDBC.ExecuteReader
            dgw.Rows.Clear()
            If OleDBDR.HasRows Then
                While OleDBDR.Read
                    dgw.Rows.Add()
                    dgw.Item(0, c).Value = OleDBDR.Item(0)
                    dgw.Item(1, c).Value = OleDBDR.Item(1) & ", " & OleDBDR.Item(2) & " " & OleDBDR.Item(3) & "."
                    dgw.Item(2, c).Value = OleDBDR.Item(4)
                    dgw.Item(3, c).Value = OleDBDR.Item(5)
                    dgw.Item(4, c).Value = Format(OleDBDR.Item(6), "MM/dd/yyyy")
                    dgw.Item(5, c).Value = OleDBDR.Item(7)

                    c = c + 1
                End While
                dgw.ClearSelection()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub SearchEmployees()
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
                .CommandText = "SELECT dbo.tblEmployee.empID,dbo.tblEmployee.lastname,dbo.tblEmployee.firstname," & _
                    "dbo.tblEmployee.middlename,dbo.tblEmployee.gender,dbo.tblEmployee.[position],dbo.tblEmployee.dateHired," & _
                    "dbo.tblEmployee.status FROM dbo.tblEmployee where empID like '%" & txtSearch.Text & "%' " & _
                    "or lastname like '%" & txtSearch.Text & "%' or firstname like '%" & txtSearch.Text & "%' or middlename like '%" & txtSearch.Text & "%' "

            End With
            OleDBDR = OleDBC.ExecuteReader
            dgw.Rows.Clear()
            If OleDBDR.HasRows Then
                While OleDBDR.Read
                    dgw.Rows.Add()
                    dgw.Item(0, c).Value = OleDBDR.Item(0)
                    dgw.Item(1, c).Value = OleDBDR.Item(1) & ", " & OleDBDR.Item(2) & " " & OleDBDR.Item(3) & "."
                    dgw.Item(2, c).Value = OleDBDR.Item(4)
                    dgw.Item(3, c).Value = OleDBDR.Item(5)
                    dgw.Item(4, c).Value = Format(OleDBDR.Item(6), "MM/dd/yyyy")
                    dgw.Item(5, c).Value = OleDBDR.Item(7)

                    c = c + 1
                End While
                dgw.ClearSelection()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub showEmployeesInfo()
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
                .CommandText = "SELECT * FROM dbo.tblEmployee where empID = '" & dgw.CurrentRow.Cells(0).Value & "'"
            End With
            OleDBDR = OleDBC.ExecuteReader
            If OleDBDR.HasRows Then
                If OleDBDR.Read Then
                    frmAddEmployee.txtemID.Text = OleDBDR.Item(0)
                    frmAddEmployee.txtln.Text = OleDBDR.Item(1)
                    frmAddEmployee.txtfn.Text = OleDBDR.Item(2)
                    frmAddEmployee.txtmi.Text = OleDBDR.Item(3)
                    frmAddEmployee.txtAdd.Text = OleDBDR.Item(4)
                    frmAddEmployee.txtCN.Text = OleDBDR.Item(5)
                    frmAddEmployee.txtBD.Value = OleDBDR.Item(6)
                    frmAddEmployee.txtGender.Text = OleDBDR.Item(7)
                    frmAddEmployee.txtCS.Text = OleDBDR.Item(8)
                    frmAddEmployee.txtPos.Text = OleDBDR.Item(9)
                    frmAddEmployee.txtDR.Text = OleDBDR.Item(10)
                    frmAddEmployee.txtPM.Text = OleDBDR.Item(11)
                    frmAddEmployee.txtDH.Value = OleDBDR.Item(12)
                    frmAddEmployee.txtStatus.Text = OleDBDR.Item(13)
                    frmAddEmployee.txtSSSNo.Text = OleDBDR.Item(14)
                    frmAddEmployee.txtTinNo.Text = OleDBDR.Item(15)
                    frmAddEmployee.txtPINo.Text = OleDBDR.Item(16)
                    frmAddEmployee.txtPHNo.Text = OleDBDR.Item(17)
                    If OleDBDR.Item(18) = "Yes" Then
                        frmAddEmployee.CheckBox1.Checked = True
                    ElseIf OleDBDR.Item(18) = "No" Then
                        frmAddEmployee.CheckBox1.Checked = False
                    End If
                End If

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub frmEmployeeMasterlist_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            dgw.ClearSelection()
        End If
    End Sub

    Private Sub frmEmployeeMasterlist_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewEmployees()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        SearchEmployees()
    End Sub

    Private Sub UpdateEmployeesInformationToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UpdateEmployeesInformationToolStripMenuItem.Click
        showEmployeesInfo()
        frmAddEmployee.cmbAdd.Text = "Update"
        frmAddEmployee.ShowDialog()
    End Sub

    Private Sub ContextMenuStrip1_Closing(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolStripDropDownClosingEventArgs) Handles ContextMenuStrip1.Closing
        dgw.ContextMenuStrip = ContextMenuStrip2
    End Sub

    Private Sub dgw_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgw.CellContentClick

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
    
   

    Private Sub ViewEmployeesPayrollHistoryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ViewEmployeesPayrollHistoryToolStripMenuItem.Click
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
                .CommandText = "SELECT dbo.tblEmployee.empID,dbo.tblEmployee.lastname,dbo.tblEmployee.firstname," & _
                    "dbo.tblEmployee.middlename,dbo.tblEmployee.[position],dbo.tblEmployee.payMethod," & _
                    "dbo.tblEmployee.rate,dbo.tblEmployee.dateHired" & _
                    " FROM dbo.tblEmployee where empid = '" & dgw.CurrentRow.Cells(0).Value & "'"
            End With
            OleDBDR = OleDBC.ExecuteReader
            If OleDBDR.Read Then
                frmPayrollHistory.txtemID.Text = OleDBDR.Item(0)
                frmPayrollHistory.txtName.Text = OleDBDR.Item(1) & ", " & OleDBDR.Item(2) & " " & OleDBDR.Item(3)
                frmPayrollHistory.txtPos.Text = OleDBDR.Item(4)
                frmPayrollHistory.txtPayMethod.Text = OleDBDR.Item(5)
                frmPayrollHistory.txtDR.Text = OleDBDR.Item(6)
                frmPayrollHistory.dtrDH.Value = OleDBDR.Item(7)
                frmPayrollHistory.ShowDialog()
            End If
           
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class