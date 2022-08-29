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

            Using STSClient = New AmazonSecurityTokenServiceClient(accessKey, secretKey, RegionEndpoint.USEast1)
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
                .Region = "us-east-1"
            }
            restRequest.AddHeader("x-amz-security-token", response1.Credentials.SessionToken)
            Return New AWSSigV4Signer(awsAuthenticationCredentials).Sign(restRequest, host)
        End Function

    End Class

End Namespace