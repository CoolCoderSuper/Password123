<NPoco.TableName("Categories")>
Public Class Category
    Public Property Id As Integer
    Public Property Name As String
End Class

<NPoco.TableName("Entries")>
Public Class Entry
    Public Property Id As Integer
    Public Property Name As String
    Public Property Username As String
    Public Property Password As String
    Public Property Notes As String
    Public Property Favourite As Boolean
    Public Property CategoryId As Integer
End Class

<NPoco.TableName("Fields")>
Public Class Field
    Public Property Id As Integer
    Public Property Name As String
    Public Property Value As String
    Public Property Type As String
    Public Property EntryId As Integer
End Class

<NPoco.TableName("URLs")>
Public Class URL
    Public Property Id As Integer
    Public Property URL As String
    Public Property EntryId As Integer
End Class