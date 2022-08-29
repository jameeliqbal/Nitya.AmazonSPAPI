Imports System.IO
Imports System.Security.Cryptography
Imports System.Text

Namespace Common
    Public Class Encryption

        Public Shared Function EncryptString(ByVal clearText As String) As String

            ' For now we will store the key here.
            ' This Is definatly Not the ideal place to keep it but for now it will have to do.
            ' Maybe move this to the registry later on...
            Dim EncryptionKey As String = "lo6DtfioP534KKhASoxhrnD2Vb9rO8OC"

            Dim clearBytes As Byte() = Encoding.Unicode.GetBytes(clearText)

            Using encryptor As Aes = Aes.Create()
                Dim pdb As Rfc2898DeriveBytes = New Rfc2898DeriveBytes(EncryptionKey, New Byte() {&H49, &H76, &H61, &H6E, &H20, &H4D, &H65, &H64, &H76, &H65, &H64, &H65, &H76})
                encryptor.Key = pdb.GetBytes(32)
                encryptor.IV = pdb.GetBytes(16)

                Using ms As MemoryStream = New MemoryStream()

                    Using cs As CryptoStream = New CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write)
                        cs.Write(clearBytes, 0, clearBytes.Length)
                        cs.Close()
                    End Using

                    clearText = Convert.ToBase64String(ms.ToArray())
                End Using
            End Using

            Return clearText
        End Function

        Public Shared Function DecryptString(ByVal cipherText As String) As String

            ' For now we will store the key here.
            ' This Is definatly Not the ideal place to keep it but for now it will have to do.
            ' Maybe move this to the registry later on...
            Dim EncryptionKey As String = "lo6DtfioP534KKhASoxhrnD2Vb9rO8OC"

            cipherText = cipherText.Replace(" ", "+")
            Dim cipherBytes As Byte() = Convert.FromBase64String(cipherText)

            Using encryptor As Aes = Aes.Create()
                Dim pdb As Rfc2898DeriveBytes = New Rfc2898DeriveBytes(EncryptionKey, New Byte() {&H49, &H76, &H61, &H6E, &H20, &H4D, &H65, &H64, &H76, &H65, &H64, &H65, &H76})
                encryptor.Key = pdb.GetBytes(32)
                encryptor.IV = pdb.GetBytes(16)

                Using ms As MemoryStream = New MemoryStream()

                    Using cs As CryptoStream = New CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write)
                        cs.Write(cipherBytes, 0, cipherBytes.Length)
                        cs.Close()
                    End Using

                    cipherText = Encoding.Unicode.GetString(ms.ToArray())
                End Using
            End Using

            Return cipherText
        End Function

    End Class
End Namespace