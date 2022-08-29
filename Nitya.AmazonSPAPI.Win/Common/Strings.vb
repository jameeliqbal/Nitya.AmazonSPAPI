Imports System
Imports System.Text

Namespace Common
    Public Class Strings

        Private Shared Function GenerateRandomString(size As Integer, Optional lowerCase As Boolean = False, Optional legalCharacters As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789")
            Dim random As Random = New Random()
            Dim builder As Text.StringBuilder = New Text.StringBuilder()
            Dim ch As Char

            For cntr As Integer = 0 To size
                ch = legalCharacters.Substring(random.Next(0, legalCharacters.Length), 1)
                builder.Append(ch)
            Next

            If lowerCase Then
                Return builder.ToString().ToLower()
            End If
            Return builder.ToString()
        End Function

    End Class
End Namespace