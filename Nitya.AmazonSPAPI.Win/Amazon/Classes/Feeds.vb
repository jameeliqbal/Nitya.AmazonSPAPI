Imports System.IO
Imports System.Net
Imports System.Security.Cryptography
Imports RestSharp

Namespace Classes

    Public Class Feeds

        Public Function EncryptAndUpload(ByVal url As String, ByVal iv As String, ByVal key As String, ByVal content As String) As String
            Dim encrypted As Byte()

            Using aesAlg = Aes.Create()
                aesAlg.Key = Convert.FromBase64String(key)
                aesAlg.IV = Convert.FromBase64String(iv)
                Dim encryptor As ICryptoTransform = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV)

                Using memoryStream = New MemoryStream()

                    Using cryptoStream = New CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write)

                        Using sw = New StreamWriter(cryptoStream)
                            sw.Write(content)
                        End Using

                        encrypted = memoryStream.ToArray()
                        Dim contentType = "text/plain; charset=UTF-8"
                        Dim client = New RestClient(url)
                        Dim request = New RestRequest(Method.PUT)
                        request.AddParameter(contentType, encrypted, ParameterType.RequestBody)
                        Dim response = client.Execute(request)
                        Return response.Content.ToString()
                    End Using
                End Using
            End Using
        End Function

        Public Function DownloadAndDecrypt(url As String, iv As String, key As String, Optional algorythm As String = Nothing) As String
            Dim client = New WebClient()
            Dim cipherText = client.DownloadData(url)
            Dim plainText As String = Nothing

            Using aesAlg = Aes.Create()
                aesAlg.Key = Convert.FromBase64String(key)
                aesAlg.IV = Convert.FromBase64String(iv)
                Dim decryptor As ICryptoTransform = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV)

                Using ms = New MemoryStream(cipherText)

                    Using cs = New CryptoStream(ms, decryptor, CryptoStreamMode.Read)

                        Using sr = New StreamReader(cs)
                            plainText = sr.ReadToEnd()
                        End Using
                    End Using
                End Using
            End Using

            Return plainText
        End Function

    End Class

End Namespace