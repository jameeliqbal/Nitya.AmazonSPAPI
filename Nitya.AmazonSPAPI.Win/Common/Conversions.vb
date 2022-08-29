Imports System.Xml

Namespace Common

    Public Class Conversions

        Public Shared Function ConvertJsonStringToDataSet(ByVal jsonString As String) As DataSet
            Dim xd As XmlDocument = New XmlDocument()
            jsonString = "{ ""rootNode"": {" & jsonString.Trim().TrimStart("{"c).TrimEnd("}"c) & "} }"
            xd = CType(Newtonsoft.Json.JsonConvert.DeserializeXmlNode(jsonString), XmlDocument)
            Dim ds As DataSet = New DataSet()
            ds.ReadXml(New XmlNodeReader(xd))
            Return ds
        End Function

    End Class
End Namespace