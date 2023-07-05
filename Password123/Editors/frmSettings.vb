Imports Password123.Core
Imports Password123.Core.Encryption

Public Class frmSettings

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Dispose()
    End Sub

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        Try
            Dim newKey As String = txtKey.Text
            Dim categories As List(Of Category) = DB.Query(Of Category).ToList
            For Each cat As Category In categories
                cat.Name = EncryptAES(newKey, DecryptAES(Key, cat.Name))
                DB.Update(cat)
            Next
            Dim entries As List(Of Entry) = DB.Query(Of Entry).ToList
            For Each en As Entry In entries
                en.Name = EncryptAES(newKey, DecryptAES(Key, en.Name))
                en.Username = EncryptAES(newKey, DecryptAES(Key, en.Username))
                en.Password = EncryptAES(newKey, DecryptAES(Key, en.Password))
                en.Notes = EncryptAES(newKey, DecryptAES(Key, en.Notes))
                DB.Update(en)
            Next
            Key = newKey
        Catch ex As Exception
            MsgBox($"Failed to update key with this error: {ex.Message}")
        End Try
        Dispose
    End Sub

    Private Sub tmrCheck_Tick(sender As Object, e As EventArgs) Handles tmrCheck.Tick
        If txtKey.Text.Trim = "" Then
            epError.SetError(txtKey, "Enter a key")
        Else
            epError.SetError(txtKey, "")
        End If
        btnOk.Enabled = Not txtKey.Text.Trim = ""
    End Sub

    Private Sub frmSettings_Load(sender As Object, e As EventArgs) Handles Me.Load
        tmrCheck.Start()
    End Sub

End Class