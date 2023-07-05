Imports System.IO
Imports System.Text.RegularExpressions
Imports HtmlAgilityPack

Public Class IconChooser

    Public Function Load(strURL As String) As Image()
        Dim lImages As New List(Of Image)
        Dim doc As New HtmlDocument
        Dim bWWW As Boolean = False
        Using client As New Net.WebClient
            Try
                doc.LoadHtml(client.DownloadString(strURL))
            Catch ex As Net.WebException
                bWWW = True
            End Try
        End Using
        If bWWW Then
            Using client As New Net.WebClient
                doc.LoadHtml(client.DownloadString(InsertWWW(strURL)))
                strURL = InsertWWW(strURL)
            End Using
        End If
        For Each node As HtmlNode In doc.DocumentNode.SelectNodes("//link").ToArray()
            Dim attr As HtmlAttribute = node.Attributes.Where(Function(x) x.Name = "rel").FirstOrDefault()
            If attr IsNot Nothing AndAlso (attr.Value = "icon" OrElse attr.Value = "shortcut icon" OrElse attr.Value = "apple-touch-icon" OrElse attr.Value = "apple-touch-icon-precomposed") Then
                Dim href As HtmlAttribute = node.Attributes.Where(Function(x) x.Name = "href").FirstOrDefault()
                Using client As New Net.WebClient
                    lImages.Add(Image.FromStream(New MemoryStream(client.DownloadData(GetURL(href.Value, strURL)))))
                End Using
            End If
        Next
        Return lImages.ToArray()
    End Function

    Private Function InsertWWW(url As String) As String
        Dim m As Match = Regex.Match(url, "(?i)\b(http:\/\/|https:\/\/|file:\/\/\/)\b")
        Return url.Insert(m.Length, "www.")
    End Function

    Private Function GetURL(url As String, header As String) As String
        Return If(Not Regex.IsMatch(url, "(?i)\b(http:\/\/|https:\/\/|file:\/\/\/)\b"), $"{header}{url}", url)
    End Function

End Class