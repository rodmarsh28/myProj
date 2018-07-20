Public Class frmAddEmployee
    Sub clear()
        txtemID.Text = ""
        txtln.Text = ""
        txtAdd.Text = ""
        txtCN.Text = ""
        txtBD.Text = Now
        txtGender.Text = ""
        txtCS.Text = ""
        txtPos.Text = ""
        txtDR.Text = ""
        txtPM.Text = ""
        txtDH.Text = Now
        txtStatus.Text = ""
        txtSSSNo.Text = ""
        txtTinNo.Text = ""
        txtPINo.Text = ""
        txtPHNo.Text = ""
     
    End Sub
    Sub AddEmployees()
        Dim ad As String
        If CheckBox1.Checked = True Then
            ad = "Yes"
        Else
            ad = "No"
        End If
        If CheckBox1.Checked = True And txtPHNo.Text = "" And txtPINo.Text = "" And txtSSSNo.Text = "" Then
            MsgBox("you allow premiums deduction of this employee but they don't have premiums, automatically we cancel deduction of premiums in this employee", MsgBoxStyle.Information, "Note:")
        End If
        If MsgBox("ARE YOU SURE YOU WANT TO ADD ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "WARNING") = MsgBoxResult.Yes Then
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
                    .CommandText = "INSERT INTO tblEmployee VALUES('" & txtemID.Text & _
                        "','" & txtln.Text & _
                        "','" & txtfn.Text & _
                        "','" & txtmi.Text & _
                        "','" & txtAdd.Text & _
                        "','" & txtCN.Text & _
                        "','" & txtBD.Value.ToString("MM/dd/yyyy") & _
                        "','" & txtGender.Text & _
                        "','" & txtCS.Text & _
                        "','" & txtPos.Text & _
                        "','" & txtDR.Text & _
                        "','" & txtPM.Text & _
                        "','" & txtDH.Value.ToString("MM/dd/yyyy") & _
                        "','" & txtStatus.Text & _
                        "','" & txtSSSNo.Text & _
                        "','" & txtTinNo.Text & _
                        "','" & txtPINo.Text & _
                        "','" & txtPHNo.Text & _
                        "','" & ad & _
                         "','Employee Added of " & Now & "')"
                    .ExecuteNonQuery()
                End With
                MsgBox("Employee Added", MsgBoxStyle.Information, "SUCCESS")
                clear()
                Me.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub
    Sub updateEmployees()
        Dim ad As String
        If CheckBox1.Checked = True Then
            ad = "Yes"
        Else
            ad = "No"
        End If
        If CheckBox1.Checked = True And txtPHNo.Text = "" And txtPINo.Text = "" And txtSSSNo.Text = "" Then
            MsgBox("you allow premiums deduction of this employee but they don't have premiums, automatically we cancel deduction of premiums in this employee", MsgBoxStyle.Information, "Note:")
        End If
        If MsgBox("Save Changes?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "WARNING") = MsgBoxResult.Yes Then
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
                    .CommandText = " update  tblEmployee set  lastname ='" & txtln.Text & _
                            "',firstname='" & txtfn.Text & _
                            "',middlename='" & txtmi.Text & _
                            "',ADDRESS='" & txtAdd.Text & _
                            "',CONTACTNO='" & txtCN.Text & _
                            "',BIRTHDATE='" & txtBD.Value.ToString("MM/dd/yyyy") & _
                            "',GENDER='" & txtGender.Text & _
                            "',CIVILSTATUS='" & txtCS.Text & _
                            "',POSITION='" & txtPos.Text & _
                            "',RATE='" & txtDR.Text & _
                            "',PAYMETHOD='" & txtPM.Text & _
                            "',DATEHIRED='" & txtDH.Value.ToString("MM/dd/yyyy") & _
                            "',STATUS='" & txtStatus.Text & _
                            "',sss='" & txtSSSNo.Text & _
                            "',tin='" & txtTinNo.Text & _
                            "',pagibig='" & txtPINo.Text & _
                            "',philhealth='" & txtPHNo.Text & _
                            "',allowPremsDeductions='" & ad & _
                            "',remarks='Employee Updated of " & Now & _
                            "' WHERE EMPID='" & txtemID.Text & "'"
                    .ExecuteNonQuery()
                End With
                MsgBox("EMPLOYEE RECORD UPDATED !", MsgBoxStyle.OkOnly, "SUCCESS")
                clear()
                Me.Close()
            Catch ex As Exception
                MsgBox(ex.Message)

            End Try
        End If
    End Sub
    Sub generateEmpNo()
        Dim StrID As String
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
                .CommandText = "SELECT * from tblEmployee order by EMPID DESC"
            End With
            OleDBDR = OleDBC.ExecuteReader
            If OleDBDR.Read Then
                StrID = Mid(OleDBDR(0), 7, Len(OleDBDR(0)))
                txtemID.Text = "EMP-" & Format(Val(StrID) + 1, "00000")
            Else
                txtemID.Text = "EMP-00001"
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try
    End Sub

    Private Sub frmAddEmployee_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If cmbAdd.Text = "Add" Then
            generateEmpNo()
        End If
    End Sub

    Private Sub cmbAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbAdd.Click
        If cmbAdd.Text = "Add" Then
            AddEmployees()
        ElseIf cmbAdd.Text = "Update" Then
            updateEmployees()
        End If

    End Sub

    Private Sub cmbCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCancel.Click
        clear()
        Me.Close()
    End Sub
End Class
