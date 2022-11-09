Option Explicit On
Option Compare Text
'Option Strict On
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports System.Net.Http
Imports System.Security.Cryptography
Imports System.Text
Imports System.Xml




Public Module Program
    Public strAccessKey, strSecretKey, strSessionToken, ashishSign As String
    Public Function AmazonTempToken()

        'If args.Length <> 5 Then
        'Throw New Exception("AWS Integration requires 5 parameters: url accessKey secretKey awsRegion awsServiceName")
        ' End If

        Dim url As String = "https://sts.amazonaws.com/?Version=2011-06-15&Action=AssumeRole&RoleSessionName=Test&RoleArn=arn:aws:iam::947414506257:role/SellerApiAccess&DurationSeconds=3600"

        'url = "httpResponse.Responsebody"
        Dim accessKey As String = "AKIA5ZFSODMIQCYFD6G7"      ' api key
        Dim secretkey As String = "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"       ' api secret
        Dim awsRegion As String = "us-east-1"       ' = "us-east-2"
        Dim awsServiceName As String = "sts"  '= "ec2"

        Dim msg As HttpRequestMessage = New HttpRequestMessage(HttpMethod.[Get], url)
        msg.Headers.Host = msg.RequestUri.Host
        Dim utcNowSaved As DateTimeOffset = DateTimeOffset.UtcNow
        Dim amzLongDate As String = utcNowSaved.ToString("yyyyMMddTHHmmssZ")
        Dim amzShortDate As String = utcNowSaved.ToString("yyyyMMdd")
        msg.Headers.Add("x-amz-date", amzLongDate)
        Dim canonicalRequest As New StringBuilder
        canonicalRequest.Append(msg.Method.ToString & vbLf)
        canonicalRequest.Append(String.Join("/", msg.RequestUri.AbsolutePath.Split("/"c).Select(AddressOf Uri.EscapeDataString)) & vbLf)
        canonicalRequest.Append(GetCanonicalQueryParams(msg) & vbLf)
        Dim headersToBeSigned As New List(Of String)

        For Each header In msg.Headers.OrderBy(Function(a) a.Key.ToLowerInvariant, StringComparer.OrdinalIgnoreCase)
            canonicalRequest.Append(header.Key.ToLowerInvariant)
            canonicalRequest.Append(":")
            canonicalRequest.Append(String.Join(",", header.Value.[Select](Function(s) s.Trim)))
            canonicalRequest.Append(vbLf)
            headersToBeSigned.Add(header.Key.ToLowerInvariant)
        Next

        canonicalRequest.Append(vbLf)
        Dim signedHeaders As String = String.Join(";", headersToBeSigned)
        canonicalRequest.Append(signedHeaders & vbLf)
        canonicalRequest.Append("e3b0c44298fc1c149afbf4c8996fb92427ae41e4649b934ca495991b7852b855")
        Dim stringToSign As String = "AWS4-HMAC-SHA256" & vbLf & amzLongDate & vbLf & amzShortDate & "/" & awsRegion & "/" & awsServiceName & "/aws4_request" & vbLf & Hash(Encoding.UTF8.GetBytes(canonicalRequest.ToString))
        Dim dateKey() As Byte = HmacSha256(Encoding.UTF8.GetBytes("AWS4" & secretkey), amzShortDate)
        Dim dateRegionKey() As Byte = HmacSha256(dateKey, awsRegion)
        Dim dateRegionServiceKey() As Byte = HmacSha256(dateRegionKey, awsServiceName)
        Dim signingKey() As Byte = HmacSha256(dateRegionServiceKey, "aws4_request")
        Dim signature As String = ToHexString(HmacSha256(signingKey, stringToSign.ToString))
        Dim credentialScope As String = amzShortDate & "/" & awsRegion & "/" & awsServiceName & "/aws4_request"
        Dim CredentialTextForApiCall = amzShortDate & "/eu-west-1/execute-api/aws4_request"
        msg.Headers.TryAddWithoutValidation("Authorization", "AWS4-HMAC-SHA256 Credential=" & accessKey & "/" & credentialScope & ", SignedHeaders=" & signedHeaders & ", Signature=" & signature)
        Dim client As HttpClient = New HttpClient
        Dim result As HttpResponseMessage = client.SendAsync(msg).Result
        'AmzSigniture = "AWS4-HMAC-SHA256 Credential=" & accessKey & "/" & credentialScope & ", SignedHeaders=" & signedHeaders & ", Signature=" & signature
        '  Dim AmzSigniture As String = "AWS4-HMAC-SHA256 Credential=" & accessKey & "/" & CredentialTextForApiCall & ", SignedHeaders=" & signedHeaders & ", Signature=" & signature

        'MsgBox("Temp Token  ::" & msg.ToString)
        Dim response As String
        If result.IsSuccessStatusCode Then
            'Console.WriteLine(result.Headers)
            response = result.Content.ReadAsStringAsync().Result
            Console.WriteLine(response)

        Else
            Console.WriteLine(result.StatusCode & vbCrLf & result.ToString.Replace(vbCr, "").Replace(vbLf, ""))
        End If


        Dim AccessKeyId As String
        Dim SecretAccessKey As String
        Dim SessionToken As String

        Dim XMLDoc As New XmlDocument()

        XMLDoc.LoadXml(response)
        ' Dim XmlNodeList As Xml.XmlNode = XMLDoc.DocumentElement.SelectNodes("/Store/Product");

        Dim nodeList As XmlNodeList = XMLDoc.GetElementsByTagName(“Credentials”)
        Dim i As Integer

        For i = 0 To nodeList.Count - 1
            AccessKeyId = (nodeList(i).ChildNodes.Item(0).InnerXml)
            SecretAccessKey = (nodeList(i).ChildNodes.Item(1).InnerXml)
            SessionToken = (nodeList(i).ChildNodes.Item(2).InnerXml)

        Next i

        ' Dim strCredentials() As String = {AccessKeyId, SecretAccessKey, SessionToken}
        strAccessKey = AccessKeyId
        strSecretKey = SecretAccessKey
        strSessionToken = SessionToken



        'strCredentials(0) = AccessKeyId
        'strCredentials(1) = SecretAccessKey
        'strCredentials(2) = SessionToken
        'strCredentials(3) = AmzSigniture


        ' Return strCredentials '(AccessKeyId & "," & SecretAccessKey & "," & SessionToken & "," & AmzSigniture)
        ' Dim json As XmlText = response
        'Dim prasejson As JObject = JObject.Parse(json)
        'AccessKeyId = prasejson.SelectToken("AccessKeyId").ToString()
        MsgBox(SessionToken)

    End Function

    Private Function GetCanonicalQueryParams(ByVal request As HttpRequestMessage) As String
        Dim values = New SortedDictionary(Of String, String)
        Dim querystring = System.Web.HttpUtility.ParseQueryString(request.RequestUri.Query)

        For Each key In querystring.AllKeys

            If key Is Nothing Then
                values.Add(Uri.EscapeDataString(querystring(key)), $"{Uri.EscapeDataString(querystring(key))}=")
            Else
                values.Add(Uri.EscapeDataString(key), $"{Uri.EscapeDataString(key)}={Uri.EscapeDataString(querystring(key))}")
            End If
        Next

        Dim queryParams = values.Select(Function(a) a.Value)
        Return String.Join("&", queryParams)
    End Function

    Public Function Hash(ByVal bytesToHash() As Byte) As String
        Return ToHexString(SHA256.Create.ComputeHash(bytesToHash))
    End Function

    Private Function ToHexString(ByVal array As IReadOnlyCollection(Of Byte)) As String
        Dim hex = New StringBuilder(array.Count * 2)

        For Each b In array
            hex.AppendFormat("{0:x2}", b)
        Next

        Return hex.ToString
    End Function

    Private Function HmacSha256(ByVal key() As Byte, ByVal data As String) As Byte()
        Return New HMACSHA256(key).ComputeHash(Encoding.UTF8.GetBytes(data))
    End Function



    Function AwsRefereshToken()
        Dim ClientId As String
        Dim ClientSecret As String
        Dim strpara As String

        strpara = "grant_type=refresh_token&refresh_token=Atzr|IwEBID8CIh2epqQB5ULVWqLhE_zHNDRynrELw14-5Zh2__bQ0C63od9qX5ScNeIFdG3X85Av-ESuwALCSI4EBc9FFIY_90qEsV5C2jOUQYlQAQk83cADHarB6afbNfq-DFNKtanYWApXZNNyatXjKH1TiFont1K0LX3h8QUh3kORbrxphZl7RtcRzMdErQNQzriIVVuouXEdNjK_ZmQS61-NrTTUUJIGA-8pOSKXJxOnntOdZenuIiwynLirPFqF_AzB9jnSBETxd0WDXBe6Q7V4VR1x038HLgsgNLRg1nt0AkUAWoyiuw5V0yl8yie_qnN_ZCQsIK0jp3vwPvX6GxZlF95r&client_id=amzn1.application-oa2-client.8bae9facde45464fb4665ab6460c4760&client_secret=de24b0a3f1ac72c3be67191c85ed00e8189061b6b43f54b698b12f74406ccf3a"

        sql.ExecQuery("select Client_id,Client_Secret from accountMaster where Alias='Amazon'")
        ClientId = sql.DBDT(0)(0)
        ClientSecret = sql.DBDT(0)(1)


        Dim hreq As Object

        Dim strUrl As String
        strUrl = "https://api.amazon.com/auth/o2/token"
        hreq = CreateObject("MSXML2.XMLHTTP")
        With hreq
            .Open("POST", strUrl, False)
            .setRequestHeader("Content-Type", "application/x-www-form-urlencoded")

            .send(strpara)
        End With

        Dim awsAccessToken As String
        If hreq.status = 200 Then
            Form_Dispatch.ToolStripStatusLabel1.Text = "Login sucessful"
            awsAccessToken = hreq.responsetext
        Else
            MsgBox("Msg from aws refresh token: " & hreq.responsetext)
        End If
        ' MsgBox(awsAccessToken)

        Dim json As String = awsAccessToken
        Dim prasejson As JObject = JObject.Parse(json)
        awsAccessToken = prasejson.SelectToken("access_token").ToString()
        ' MsgBox(awsAccessToken)
        Return awsAccessToken
    End Function

    Function CreateReport()
        Call AmazonTempToken()


        Dim url As String = "https://sellingpartnerapi-eu.amazon.com/reports/2021-06-30/reports"
        Dim accessKey As String = strAccessKey     ' api key
        Dim secretkey As String = strSecretKey      ' api secret
        Dim awsRegion As String = "eu-west-1"       ' = "us-east-2"
        Dim awsServiceName As String = "execute-api"  '= "ec2"

        Dim msg As HttpRequestMessage = New HttpRequestMessage(HttpMethod.[Post], url)
        msg.Headers.Host = msg.RequestUri.Host
        Dim utcNowSaved As DateTimeOffset = DateTimeOffset.UtcNow
        Dim amzLongDate As String = utcNowSaved.ToString("yyyyMMddTHHmmssZ")
        Dim amzShortDate As String = utcNowSaved.ToString("yyyyMMdd")


        msg.Headers.Add("x-amz-date", amzLongDate)
        ' msg.Content("Content-Type", "application/json; charset=utf-8")
        'msg.Content.Headers.Add("Content-Type", "application/json; charset=utf-8")
        ' msg.Headers.Add("Content-Type", "application/json")
        msg.Headers.Add("X-Amz-Security-Token", strSessionToken)
        Dim canonicalRequest As New StringBuilder
        canonicalRequest.Append(msg.Method.ToString & vbLf)
        canonicalRequest.Append(String.Join("/", msg.RequestUri.AbsolutePath.Split("/"c).Select(AddressOf Uri.EscapeDataString)) & vbLf)
        canonicalRequest.Append(GetCanonicalQueryParams(msg) & vbLf)
        Dim headersToBeSigned As New List(Of String)

        For Each header In msg.Headers.OrderBy(Function(a) a.Key.ToLowerInvariant, StringComparer.OrdinalIgnoreCase)
            canonicalRequest.Append(header.Key.ToLowerInvariant)
            canonicalRequest.Append(":")
            canonicalRequest.Append(String.Join(",", header.Value.[Select](Function(s) s.Trim)))
            canonicalRequest.Append(vbLf)
            headersToBeSigned.Add(header.Key.ToLowerInvariant)

        Next

        canonicalRequest.Append(vbLf)
        Dim signedHeaders As String = String.Join(";", headersToBeSigned)
        canonicalRequest.Append(signedHeaders & vbLf)
        canonicalRequest.Append("e3b0c44298fc1c149afbf4c8996fb92427ae41e4649b934ca495991b7852b855")

        MsgBox(canonicalRequest.ToString)

        Dim stringToSign As String = "AWS4-HMAC-SHA256" & vbLf & amzLongDate & vbLf & amzShortDate & "/" & awsRegion & "/" & awsServiceName & "/aws4_request" & vbLf & Hash(Encoding.UTF8.GetBytes(canonicalRequest.ToString))
        ' MsgBox("stringToSIgn :   " & stringToSign)
        Dim dateKey() As Byte = HmacSha256(Encoding.UTF8.GetBytes("AWS4" & secretkey), amzShortDate)
        Dim dateRegionKey() As Byte = HmacSha256(dateKey, awsRegion)
        Dim dateRegionServiceKey() As Byte = HmacSha256(dateRegionKey, awsServiceName)
        Dim signingKey() As Byte = HmacSha256(dateRegionServiceKey, "aws4_request")
        Dim signature As String = ToHexString(HmacSha256(signingKey, stringToSign.ToString))
        Dim credentialScope As String = amzShortDate & "/" & awsRegion & "/" & awsServiceName & "/aws4_request"

        msg.Headers.Add("x-amz-access-token", AwsRefereshToken)
        msg.Headers.Add("X-Amz-Content-Sha256", "beaead3198f7da1e70d03ab969765e0821b24fc913697e929e726aeaebf0eba3")

        msg.Headers.TryAddWithoutValidation("Authorization", "AWS4-HMAC-SHA256 Credential=" & accessKey & "/" & credentialScope & ", SignedHeaders=" & signedHeaders & "x-amz-access-token;x-amz-content-sha256;x-amz-date;x-amz-security-token" & ", Signature=" & signature)

        ' msg.Headers.TryAddWithoutValidation("Content-Type", "application/json")
        ' MsgBox(msg.Headers.ToString)
        ashishSign = "AWS4-HMAC-SHA256 Credential=" & accessKey & "/" & credentialScope & ", SignedHeaders=" & signedHeaders & "x-amz-access-token;x-amz-content-sha256;x-amz-date;x-amz-security-token" &", Signature=" & signature
        Dim client As HttpClient = New HttpClient
        Dim result As HttpResponseMessage = client.SendAsync(msg).Result
        ' AmzSigniture = "AWS4-HMAC-SHA256" & "/" & credentialScope & ", SignedHeaders=" & signedHeaders & ", Signature=" & signature
        'AmzSigniture = "AWS4-HMAC-SHA256 Credential=" & accessKey & "/" & CredentialTextForApiCall & ", SignedHeaders=" & signedHeaders & ", Signature=" & signature
        Dim response As String
        If result.IsSuccessStatusCode Then
            'Console.WriteLine(result.Headers)
            response = result.Content.ReadAsStringAsync().Result
            Console.WriteLine(response)

        Else
            Console.WriteLine(result.StatusCode & vbCrLf & result.ToString.Replace(vbCr, "").Replace(vbLf, ""))
        End If
        MsgBox(result.ToString)
        'Stop
        'MsgBox("AMZ SIG:  " & AmzSigniture)
        'Dim AccessKeyId As String
        'Dim SecretAccessKey As String
        'Dim SessionToken As String

        'Dim XMLDoc As New XmlDocument()

        'XMLDoc.LoadXml(response)
        '' Dim XmlNodeList As Xml.XmlNode = XMLDoc.DocumentElement.SelectNodes("/Store/Product");

        'Dim nodeList As XmlNodeList = XMLDoc.GetElementsByTagName(“Credentials”)
        'Dim i As Integer

        'For i = 0 To nodeList.Count - 1
        '    AccessKeyId = (nodeList(i).ChildNodes.Item(0).InnerXml)
        '    SecretAccessKey = (nodeList(i).ChildNodes.Item(1).InnerXml)
        '    SessionToken = (nodeList(i).ChildNodes.Item(2).InnerXml)

        'Next i

        ' Dim strCredentials() As String = {AccessKeyId, SecretAccessKey, SessionToken, AmzSigniture}
        'strCredentials(0) = AccessKeyId
        'strCredentials(1) = SecretAccessKey
        'strCredentials(2) = SessionToken
        'strCredentials(3) = AmzSigniture


        ' Return AmzSigniture 'strCredentials '(AccessKeyId & "," & SecretAccessKey & "," & SessionToken & "," & AmzSigniture)
        ' Dim json As XmlText = response
        'Dim prasejson As JObject = JObject.Parse(json)
        'AccessKeyId = prasejson.SelectToken("AccessKeyId").ToString()
        'MsgBox(AccessKeyId)
    End Function
End Module