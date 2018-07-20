Public Class frmDateGenerator
    Public mode As String

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If mode = "AddPayroll" Then
            frmPayroll.dtrFrom.Value = DateTimePicker1.Value
            frmPayroll.dtrTo.Value = DateTimePicker2.Value
            Me.Close()
            frmPayroll.ShowDialog()
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class