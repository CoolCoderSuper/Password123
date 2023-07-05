Imports Password123.Core
Imports Password123.Core.Encryption

Public Class frmEntry
    Dim currentEntry As Entry
    Dim deletedIds As List(Of Integer)

    Public Sub ShowNew()
        Text = "New Entry"
        txtName.Clear()
        txtUsername.Clear()
        txtPassword.Clear()
        txtNotes.Clear()
        chFavourite.Checked = False
        lvURLs.Items.Clear()
        LoadCategories()
        currentEntry = New Entry
        deletedIds = New List(Of Integer)
        tmrCheck.Start()
        ShowDialog()
    End Sub

    Public Sub ShowEdit(intId As Integer)
        Try
            Text = "Edit Entry"
            LoadCategories()
            currentEntry = DB.Query(Of Entry).FirstOrDefault(Function(x) x.Id = intId)
            txtName.Text = DecryptAES(Key, currentEntry.Name)
            txtUsername.Text = DecryptAES(Key, currentEntry.Username)
            txtPassword.Text = DecryptAES(Key, currentEntry.Password)
            chFavourite.Checked = currentEntry.Favourite
            txtNotes.Text = DecryptAES(Key, currentEntry.Notes)
            cbxCategory.SelectedValue = currentEntry.CategoryId
            lvURLs.Clear
            For Each url As URL In DB.Query(Of URL).Where(Function(x) x.EntryId = intId).ToList
                lvURLs.Items.Add(New ListViewItem(url.URL) With {.Tag = url.Id})
            Next
            deletedIds = New List(Of Integer)
            tmrCheck.Start()
            ShowDialog()
        Catch ex As Exception
            MsgBox($"Failed to load with this error: {ex.Message}")
        End Try
    End Sub

    Private Sub Save()
        Try
            currentEntry.Name = EncryptAES(Key, txtName.Text)
            currentEntry.Username = EncryptAES(Key, txtUsername.Text)
            currentEntry.Password = EncryptAES(Key, txtPassword.Text)
            currentEntry.Notes = EncryptAES(Key, txtNotes.Text)
            currentEntry.Favourite = chFavourite.Checked
            currentEntry.CategoryId = cbxCategory.SelectedValue
            DB.Save(currentEntry)
            currentEntry.Id = If(currentEntry.Id = Nothing, DB.Query(Of Entry).ProjectTo(Function(x) x.Id).Max, currentEntry.Id)
            For Each item As ListViewItem In lvURLs.Items
                DB.Save(New URL() With {.Id = item.Tag, .URL = item.Text, .EntryId = currentEntry.Id})
            Next
            DB.DeleteMany(Of URL).Where(Function(x) deletedIds.Contains(x.Id)).Execute
        Catch ex As Exception
            MsgBox($"Failed to save with this error: {ex.Message}")
        End Try
    End Sub

    Private Sub LoadCategories()
        Try
            Dim categories As List(Of Category) = DB.Query(Of Category).ToList
            For Each cat As Category In categories
                cat.Name = DecryptAES(Key, cat.Name)
            Next
            categories.Add(New Category With {.Id = -1, .Name = "No Category"})
            cbxCategory.DataSource = categories
            cbxCategory.DisplayMember = "Name"
            cbxCategory.ValueMember = "Id"
            cbxCategory.SelectedIndex = 0
        Catch ex As Exception
            MsgBox($"Failed to load with this error: {ex.Message}")
        End Try
    End Sub

    Private Sub chPWD_CheckedChanged(sender As Object, e As EventArgs) Handles chPWD.CheckedChanged
        txtPassword.UseSystemPasswordChar = Not chPWD.Checked
    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        lvURLs.Items.Add(String.Empty)
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Try
            Dim item As ListViewItem = lvURLs.SelectedItems(0)
            If item.Tag IsNot Nothing Then deletedIds.Add(item.Tag)
            lvURLs.Items.Remove(item)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        Save()
        Dispose()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Dispose()
    End Sub

    Private Sub tmrCheck_Tick(sender As Object, e As EventArgs) Handles tmrCheck.Tick
        If txtName.Text.Trim() = String.Empty Then
            epError.SetError(txtName, "Enter a name")
        Else
            epError.SetError(txtName, String.Empty)
        End If
        btnOk.Enabled = Not txtName.Text.Trim() = String.Empty
    End Sub

    Private Sub pbIcon_DoubleClick(sender As Object, e As EventArgs) Handles pbIcon.DoubleClick
        Dim lURLs As New List(Of String)
        For Each item As ListViewItem In lvURLs.Items
            lURLs.Add(item.Text)
        Next
        frmIconChooser.Show(lURLs.ToArray())
    End Sub

    Private Sub pbIcon_Paint(sender As Object, e As PaintEventArgs) Handles pbIcon.Paint
        If pbIcon.Image Is Nothing Then
            e.Graphics.DrawString("No Icon", New Font("Microsoft Sans Serif", 6), Brushes.Black, New Point(0, 0))
        End If
    End Sub

End Class