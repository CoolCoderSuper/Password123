Imports Password123.Core
Imports Password123.Core.Encryption
'TODO: Add search

Public Class frmMain

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Application.Exit()
    End Sub

    Private Sub btnLock_Click(sender As Object, e As EventArgs) Handles btnLock.Click
        Dispose()
        frmLogin.ShowDialog()
    End Sub

    Private Sub btnNewCategory_Click(sender As Object, e As EventArgs) Handles btnNewCategory.Click
        frmCategory.ShowNew()
        LoadCategories()
    End Sub

    Private Sub btnEditCategory_Click(sender As Object, e As EventArgs) Handles btnEditCategory.Click
        frmCategory.ShowEdit(Integer.Parse(lstCategories.SelectedValue.ToString))
        LoadCategories()
    End Sub

    Private Sub btnDeleteCategory_Click(sender As Object, e As EventArgs) Handles btnDeleteCategory.Click
        Try
            Dim intId As Integer = Integer.Parse(lstCategories.SelectedValue.ToString)
            If DB.Query(Of Entry).Any(Function(x) x.CategoryId = intId) AndAlso MsgBox($"This category has entries in it, if you procede all entries will be deleted.{vbCrLf}Are you sure you want to continue?", MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.No Then Exit Sub
            DB.DeleteMany(Of Entry).Where(Function(x) x.CategoryId = intId).Execute
            DB.Delete(Of Category)(intId)
            LoadCategories()
        Catch ex As Exception
            MsgBox($"Failed to delete with this error: {ex.Message}")
        End Try
    End Sub

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadCategories()
    End Sub

    Private Sub LoadCategories()
        Try
            Dim categories As List(Of Category) = DB.Fetch(Of Category)
            For Each cat As Category In categories
                cat.Name = DecryptAES(Key, cat.Name)
            Next
            categories.Insert(0, New Category() With {.Id = 0, .Name = "All"})
            categories.Add(New Category() With {.Id = -1, .Name = "No Category"})
            lstCategories.DisplayMember = "Name"
            lstCategories.ValueMember = "Id"
            lstCategories.DataSource = categories
        Catch ex As Exception
            MsgBox($"Failed to load with this error: {ex.Message}")
        End Try
    End Sub

    Private Sub btnNewEntry_Click(sender As Object, e As EventArgs) Handles btnNewEntry.Click
        frmEntry.ShowNew()
        LoadEntries(lstCategories.SelectedValue, txtSearchEntries.Text)
    End Sub

    Private Sub btnEditEntry_Click(sender As Object, e As EventArgs) Handles btnEditEntry.Click
        Dim intId As Integer
        intId = Integer.Parse(dgvEntries.SelectedRows(0).Cells(0).Value.ToString)
        frmEntry.ShowEdit(intId)
        LoadEntries(lstCategories.SelectedValue, txtSearchEntries.Text)
    End Sub

    Private Sub btnDeleteEntry_Click(sender As Object, e As EventArgs) Handles btnDeleteEntry.Click
        Try
            Dim intId As Integer = Integer.Parse(dgvEntries.SelectedRows(0).Cells(0).Value.ToString)
            DB.DeleteMany(Of URL)().Where(Function(x) x.EntryId = intId).Execute()
            DB.Delete(Of Entry)(intId)
            LoadEntries(lstCategories.SelectedValue, txtSearchEntries.Text)
        Catch ex As Exception
            MsgBox($"Failed to delete with this error: {ex.Message}")
        End Try
    End Sub

    Private Sub btnCopyUser_Click(sender As Object, e As EventArgs) Handles btnCopyUser.Click
        Try
            Dim intId As Integer = Integer.Parse(dgvEntries.SelectedRows(0).Cells(0).Value.ToString)
            Clipboard.SetText(DecryptAES(Key, DB.Query(Of Entry).First(Function(x) x.Id = intId).Username))
        Catch ex As Exception
            MsgBox($"Failed to retrieve data with this error: {ex.Message}")
        End Try
    End Sub

    Private Sub btnCopyPassword_Click(sender As Object, e As EventArgs) Handles btnCopyPassword.Click
        Try
            Dim intId As Integer = Integer.Parse(dgvEntries.SelectedRows(0).Cells(0).Value.ToString)
            Clipboard.SetText(DecryptAES(Key, DB.Query(Of Entry).First(Function(x) x.Id = intId).Password))
        Catch ex As Exception
            MsgBox($"Failed to retrieve data with this error: {ex.Message}")
        End Try
    End Sub

    Private Sub txtSearchEntries_TextChanged(sender As Object, e As EventArgs) Handles txtSearchEntries.TextChanged
        LoadEntries(lstCategories.SelectedValue, txtSearchEntries.Text)
    End Sub

    Private Sub lstCategories_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstCategories.SelectedIndexChanged
        LoadEntries(lstCategories.SelectedValue, txtSearchEntries.Text)
    End Sub

    Private Sub LoadEntries(intCategoryId As Integer, strSeacrh As String)
        Try
            Dim entries As List(Of Entry) = DB.Query(Of Entry).Where(Function(x) x.CategoryId = intCategoryId OrElse intCategoryId = 0).ToList
            For Each e As Entry In entries
                e.Name = DecryptAES(Key, e.Name)
                e.Username = DecryptAES(Key, e.Username)
                e.Notes = DecryptAES(Key, e.Notes)
            Next
            dgvEntries.DataSource = entries
            dgvEntries.Columns(0).Visible = False
            dgvEntries.Columns(3).Visible = False
            dgvEntries.Columns(6).Visible = False
        Catch ex As Exception
            MsgBox($"Failed to load with this error: {ex.Message}")
        End Try
    End Sub

    Private Sub btnSettings_Click(sender As Object, e As EventArgs) Handles btnSettings.Click
        frmSettings.ShowDialog()
    End Sub

    Private Sub frmMain_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If e.CloseReason = CloseReason.UserClosing Then
            Application.Exit()
        End If
    End Sub

End Class