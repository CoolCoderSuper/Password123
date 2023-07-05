Imports Password123.Core
Imports Password123.Core.Encryption

Public Class frmCategory
    Dim currentCategory As Category

    Public Sub ShowNew()
        Text = "New Category"
        currentCategory = New Category
        tmrCheck.Start()
        ShowDialog()
    End Sub

    Public Sub ShowEdit(intId As Integer)
        Text = "Edit Category"
        Try
            currentCategory = DB.Query(Of Category).FirstOrDefault(Function(x) x.Id = intId)
            If currentCategory Is Nothing Then
                MsgBox("Failed to get item.")
            Else
                txtName.Text = DecryptAES(Key, currentCategory.Name)
            End If
        Catch ex As Exception
            MsgBox($"Failed to load with this error: {ex.Message}")
        End Try
        tmrCheck.Start
        ShowDialog()
    End Sub

    Private Sub Save()
        Try
            currentCategory.Name = EncryptAES(Key, txtName.Text)
            DB.Save(currentCategory)
        Catch ex As Exception
            MsgBox($"Failed to save with this error: {ex.Message}")
        End Try
    End Sub

    Private Sub tmrCheck_Tick(sender As Object, e As EventArgs) Handles tmrCheck.Tick
        If txtName.Text.Trim = "" Then
            epError.SetError(txtName, "Enter a name")
        Else
            epError.SetError(txtName, "")
        End If
        btnOk.Enabled = Not txtName.Text.Trim = ""
    End Sub

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        Save()
        Dispose()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Dispose()
    End Sub

End Class