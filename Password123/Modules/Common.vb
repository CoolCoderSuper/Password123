Imports System.Data.SqlClient

Module Common
    Public DB As New NPoco.Database(New SqlConnection("Server=CCH\CODINGCOOL;Database=Password123;Integrated Security=true;"))
    Public Key As String = ""
End Module