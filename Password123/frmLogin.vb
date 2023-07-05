Public Class frmLogin

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Application.Exit()
    End Sub

    Private Sub frmLogin_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If e.CloseReason = CloseReason.UserClosing Then
            Application.Exit()
        End If
    End Sub

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        Key = txtKey.Text
        frmMain.Show()
        Dispose()
    End Sub

    Private Sub frmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tmrCheck.Start()
    End Sub

    Private Sub tmrCheck_Tick(sender As Object, e As EventArgs) Handles tmrCheck.Tick
        If txtKey.Text.Trim = "" Then
            epError.SetError(txtKey, "Enter a key")
        Else
            epError.SetError(txtKey, "")
        End If
        btnOk.Enabled = Not txtKey.Text.Trim = ""
    End Sub

End Class