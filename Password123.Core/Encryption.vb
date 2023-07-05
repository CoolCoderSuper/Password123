Imports System.IO
Imports System.Security.Cryptography
Imports System.Text

Public Class Encryption
    Private Shared blockSize As Integer = 128

    Public Shared Function EncryptAES(key As String, input As String) As String
        Dim crypt As SymmetricAlgorithm = Aes.Create
        crypt.BlockSize = blockSize
        crypt.Key = SHA256.HashData(Encoding.Unicode.GetBytes(key))
        Using mStream = New MemoryStream
            Using cStream = New CryptoStream(mStream, crypt.CreateEncryptor, CryptoStreamMode.Write)
                Using sw = New StreamWriter(cStream)
                    sw.Write(input)
                End Using
            End Using
            Return $"{Convert.ToBase64String(crypt.IV)}!{Convert.ToBase64String(mStream.ToArray)}"
        End Using
    End Function

    Public Shared Function DecryptAES(key As String, input As String) As String
        If input = Nothing Then Return ""
        Dim inputBytes As Byte() = Convert.FromBase64String(input.Split("!")(1))
        Dim crypt As SymmetricAlgorithm = Aes.Create
        crypt.BlockSize = blockSize
        crypt.IV = Convert.FromBase64String(input.Split("!")(0))
        crypt.Key = SHA256.HashData(Encoding.Unicode.GetBytes(key))
        Using mStream = New MemoryStream(inputBytes)
            Using cStream = New CryptoStream(mStream, crypt.CreateDecryptor, CryptoStreamMode.Read)
                Using sReader = New StreamReader(cStream)
                    Return sReader.ReadToEnd
                End Using
            End Using
        End Using
    End Function

End Class