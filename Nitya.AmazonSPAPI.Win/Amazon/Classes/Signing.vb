Imports System.Threading
Imports Amazon
Imports Amazon.SecurityToken
Imports Amazon.SecurityToken.Model
Imports Amazon.SellingPartnerAPIAA
Imports RestSharp

Namespace Classes

    Public Class Signing

        Public Shared Function SignWithAccessToken(ByVal restRequest As IRestRequest, ByVal clientId As String, ByVal clientSecret As String, ByVal refreshToken As String) As IRestRequest
            Dim lwaAuthorizationCredentials = New LWAAuthorizationCredentials With {
                .ClientId = clientId,
                .ClientSecret = clientSecret,
                .Endpoint = New Uri("https://api.amazon.com/auth/o2/token"),
                .RefreshToken = refreshToken
            }
            Return New LWAAuthorizationSigner(lwaAuthorizationCredentials).Sign(restRequest)
        End Function

        Public Shared Function SignWithSTSKeysAndSecurityTokenn(ByVal restRequest As IRestRequest, ByVal host As String, ByVal roleARN As String, ByVal accessKey As String, ByVal secretKey As String) As IRestRequest
            Dim response1 As AssumeRoleResponse = Nothing
            'Dim policy As String = "{""Version"": ""2012-10-17"",""Statement"": [{""Effect"": ""Allow"",""Action"": ""execute-api:Invoke"",""Resource"": ""arn:aws:execute-api:::*""}]}"
            '.Policy = policy,
            Using STSClient = New AmazonSecurityTokenServiceClient(accessKey, secretKey, RegionEndpoint.EUWest1)
                Dim req = New AssumeRoleRequest() With {
                .RoleArn = roleARN,
                    .DurationSeconds = 950,
                    .RoleSessionName = Guid.NewGuid().ToString()
                }

                response1 = STSClient.AssumeRoleAsync(req, New CancellationToken()).Result
            End Using

            Dim awsAuthenticationCredentials = New AWSAuthenticationCredentials With {
                .AccessKeyId = response1.Credentials.AccessKeyId,
                .SecretKey = response1.Credentials.SecretAccessKey,
                .Region = "eu-west-1"
            }
            restRequest.AddHeader("x-amz-security-token", response1.Credentials.SessionToken)
            Return New AWSSigV4Signer(awsAuthenticationCredentials).Sign(restRequest, host)
        End Function
        Public Shared Function SignWithRDT(ByVal restRequest As IRestRequest) As IRestRequest
            Dim client = New RestClient("https: //sellingpartnerapi-eu.amazon.com")
            Dim rdtRequest = New RestRequest("/tokens/2021-03-01/restrictedDataToken", Method.POST, DataFormat.Json)
            rdtRequest.AddParameter("x-amz-access-token", restRequest.Parameters.SingleOrDefault(Function(p) p.Name = "x-amz-access-token").Value)
            'rdtRequest.AddParameter("x-amz-content-sha256", restRequest.Parameters.SingleOrDefault(Function(p) p.Name = "x-amz-content-sha256").Value)
            rdtRequest.AddParameter("x-amz-security-token", restRequest.Parameters.SingleOrDefault(Function(p) p.Name = "x-amz-security-token").Value)
            rdtRequest.AddParameter("X-Amz-Date", restRequest.Parameters.SingleOrDefault(Function(p) p.Name = "X-Amz-Date").Value)
            rdtRequest.AddParameter("Authorization", restRequest.Parameters.SingleOrDefault(Function(p) p.Name = "Authorization").Value)
            'Dim restrictedResources As Object = New Object()
            'restrictedResources.method = "Get"
            'restrictedResources.path = "/tracking/a"

            Dim restrictedResources = New With {Key .method = "Get", .path = "/tracking/a"}
            'Dim requestBody = New {"restrictedResources": {"method": "Get", "path": "/tracking/a"}}
            rdtRequest.AddBody(restrictedResources)
            Dim response = New RestResponse
            Try

                response = client.Execute(rdtRequest)
                While response.Headers.Where(Function(x) x.Name = "x-amzn-ErrorType").Count() > 0
                    'UseRequestToken(False)
                    response = client.Execute(restRequest)
                End While
                'UseRequestToken(True, response.Headers.ToList().Find(Function(x) x.Name = "x-amzn-RateLimit-Limit").Value)

                Select Case response.StatusCode
                    Case System.Net.HttpStatusCode.OK
                        ' Received a 200 response from the Amazon Selling Partner API.
                        Common.Logging.WriteToLog("INFO", "AMAZON API", "Successfully retrieved buyer information for Amazon order ID ")
                    Case System.Net.HttpStatusCode.Forbidden
                        ' Received a 403 response from the Amazon Selling Partner API.
                        Common.Logging.WriteToLog("ERROR", "AMAZON API", "Received a 403 response when trying to retrieve the order's buyer information for Amazon order ID ")
                    Case Else
                        ' Received a differing response from those covered above.
                        Common.Logging.WriteToLog("ERROR", "AMAZON API", "Recieved a bad response code when trying to retrieve the order's buyer information for Amazon order ID " & response.StatusCode & ": " & response.StatusDescription)
                End Select

            Catch ex As Exception
                ' If this is hit switch status to red.
                Common.Logging.WriteToLog("ERROR", "APPLICATION", "Was unable to connect to the Amazon Selling Partner API while trying to retrieve the order's buyer information for Amazon order ID " & ". " & ex.Message)
            End Try

        End Function
    End Class


End Namespace