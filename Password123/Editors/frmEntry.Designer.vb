<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmEntry
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.txtUsername = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.chPWD = New System.Windows.Forms.CheckBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtNotes = New System.Windows.Forms.TextBox()
        Me.lvURLs = New System.Windows.Forms.ListView()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.chFavourite = New System.Windows.Forms.CheckBox()
        Me.btnOk = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.tmrCheck = New System.Windows.Forms.Timer(Me.components)
        Me.epError = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.btnNew = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.cbxCategory = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.pbIcon = New System.Windows.Forms.PictureBox()
        CType(Me.epError,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.pbIcon,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'Label1
        '
        Me.Label1.AutoSize = true
        Me.Label1.Location = New System.Drawing.Point(54, 61)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Name: "
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(172, 58)
        Me.txtName.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(271, 23)
        Me.txtName.TabIndex = 1
        '
        'txtUsername
        '
        Me.txtUsername.Location = New System.Drawing.Point(172, 88)
        Me.txtUsername.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.Size = New System.Drawing.Size(271, 23)
        Me.txtUsername.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = true
        Me.Label2.Location = New System.Drawing.Point(54, 91)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 15)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Username: "
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(172, 118)
        Me.txtPassword.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.Size = New System.Drawing.Size(247, 23)
        Me.txtPassword.TabIndex = 5
        Me.txtPassword.UseSystemPasswordChar = true
        '
        'Label3
        '
        Me.Label3.AutoSize = true
        Me.Label3.Location = New System.Drawing.Point(54, 121)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(63, 15)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Password: "
        '
        'chPWD
        '
        Me.chPWD.AutoSize = true
        Me.chPWD.Location = New System.Drawing.Point(427, 122)
        Me.chPWD.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.chPWD.Name = "chPWD"
        Me.chPWD.Size = New System.Drawing.Size(15, 14)
        Me.chPWD.TabIndex = 6
        Me.chPWD.UseVisualStyleBackColor = true
        '
        'Label4
        '
        Me.Label4.AutoSize = true
        Me.Label4.Location = New System.Drawing.Point(54, 178)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(44, 15)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Notes: "
        '
        'txtNotes
        '
        Me.txtNotes.Location = New System.Drawing.Point(172, 174)
        Me.txtNotes.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txtNotes.Multiline = true
        Me.txtNotes.Name = "txtNotes"
        Me.txtNotes.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtNotes.Size = New System.Drawing.Size(271, 144)
        Me.txtNotes.TabIndex = 8
        '
        'lvURLs
        '
        Me.lvURLs.LabelEdit = true
        Me.lvURLs.Location = New System.Drawing.Point(172, 359)
        Me.lvURLs.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.lvURLs.MultiSelect = false
        Me.lvURLs.Name = "lvURLs"
        Me.lvURLs.Size = New System.Drawing.Size(271, 114)
        Me.lvURLs.TabIndex = 9
        Me.lvURLs.UseCompatibleStateImageBehavior = false
        Me.lvURLs.View = System.Windows.Forms.View.List
        '
        'Label5
        '
        Me.Label5.AutoSize = true
        Me.Label5.Location = New System.Drawing.Point(54, 325)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(39, 15)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "URLs: "
        '
        'chFavourite
        '
        Me.chFavourite.AutoSize = true
        Me.chFavourite.Location = New System.Drawing.Point(362, 148)
        Me.chFavourite.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.chFavourite.Name = "chFavourite"
        Me.chFavourite.Size = New System.Drawing.Size(75, 19)
        Me.chFavourite.TabIndex = 11
        Me.chFavourite.Text = "Favourite"
        Me.chFavourite.UseVisualStyleBackColor = true
        '
        'btnOk
        '
        Me.btnOk.Location = New System.Drawing.Point(261, 511)
        Me.btnOk.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(88, 27)
        Me.btnOk.TabIndex = 12
        Me.btnOk.Text = "Ok"
        Me.btnOk.UseVisualStyleBackColor = true
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(356, 511)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(88, 27)
        Me.btnCancel.TabIndex = 13
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = true
        '
        'tmrCheck
        '
        '
        'epError
        '
        Me.epError.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.epError.ContainerControl = Me
        Me.epError.RightToLeft = true
        '
        'btnNew
        '
        Me.btnNew.Location = New System.Drawing.Point(172, 325)
        Me.btnNew.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(88, 27)
        Me.btnNew.TabIndex = 14
        Me.btnNew.Text = "New"
        Me.btnNew.UseVisualStyleBackColor = true
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(356, 325)
        Me.btnDelete.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(88, 27)
        Me.btnDelete.TabIndex = 15
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = true
        '
        'cbxCategory
        '
        Me.cbxCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxCategory.FormattingEnabled = true
        Me.cbxCategory.Location = New System.Drawing.Point(172, 480)
        Me.cbxCategory.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.cbxCategory.Name = "cbxCategory"
        Me.cbxCategory.Size = New System.Drawing.Size(271, 23)
        Me.cbxCategory.TabIndex = 16
        '
        'Label6
        '
        Me.Label6.AutoSize = true
        Me.Label6.Location = New System.Drawing.Point(54, 483)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(61, 15)
        Me.Label6.TabIndex = 17
        Me.Label6.Text = "Category: "
        '
        'pbIcon
        '
        Me.pbIcon.Location = New System.Drawing.Point(406, 14)
        Me.pbIcon.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.pbIcon.Name = "pbIcon"
        Me.pbIcon.Size = New System.Drawing.Size(37, 37)
        Me.pbIcon.TabIndex = 18
        Me.pbIcon.TabStop = false
        '
        'frmEntry
        '
        Me.AcceptButton = Me.btnOk
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7!, 15!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(457, 548)
        Me.Controls.Add(Me.pbIcon)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.cbxCategory)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnNew)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.chFavourite)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.lvURLs)
        Me.Controls.Add(Me.txtNotes)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.chPWD)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtUsername)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtName)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "frmEntry"
        Me.ShowIcon = false
        Me.ShowInTaskbar = false
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.epError,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.pbIcon,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents txtName As TextBox
    Friend WithEvents txtUsername As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents chPWD As CheckBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtNotes As TextBox
    Friend WithEvents lvURLs As ListView
    Friend WithEvents Label5 As Label
    Friend WithEvents chFavourite As CheckBox
    Friend WithEvents btnOk As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents tmrCheck As Timer
    Friend WithEvents epError As ErrorProvider
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnNew As Button
    Friend WithEvents cbxCategory As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents pbIcon As PictureBox
End Class
