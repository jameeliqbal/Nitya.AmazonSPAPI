Namespace Common.Models

    Public Class Settings
        Public Property Amazon As Amazon
        Public Property Application As Application
        Public Property Atrex As Atrex
        Public Property ThirdPartyServices As ThirdPartyServices
    End Class

    Public Class Amazon
        Public Property Credentials As Credentials
        Public Property Marketplaces As List(Of Marketplace)
    End Class

    Public Class Application
        Public Property Administrator As Administrator
        Public Property Logging As Logging
        Public Property PosSystem As String
        Public Property Currency As String
        Public Property Throttling As Throttling
    End Class

    Public Class Atrex
        Public Property ElevateDB As ElevateDB
        Public Property LastImportedOrder As Integer
    End Class

    Public Class ThirdPartyServices
        Public Property FixerApiKey As String
    End Class

    Public Class Credentials
        Public Property LwaClientIdentifier As String
        Public Property LwaClientSecret As String
        Public Property RefreshToken As String
        Public Property MarketplaceId As String
        Public Property AccessKeyId As String
        Public Property SecretAccessKey As String
        Public Property RoleArn As String
    End Class

    Public Class Marketplace
        Public Property Name As String
        Public Property MarketplaceId As String
        Public Property UsingAfn As Boolean
        Public Property UsingMfn As Boolean
        Public Property Currency As String
        Public Property ConversionRate As Decimal
        Public Property ConversionRateUpdated As String
    End Class

    Public Class Administrator
        Public Property Login As String
        Public Property Password As String
    End Class

    Public Class Throttling
        Public Property Orders As Orders
    End Class

    Public Class Logging
        Public Property Enabled As Boolean
        Public Property RotateLogs As Boolean
        Public Property DaysToKeep As Decimal
    End Class

    Public Class ElevateDB
        Public Property Type As String
        Public Property Database As String
        Public Property Host As String
        Public Property Port As Decimal
        Public Property Uid As String
        Public Property Pwd As String
    End Class

    Public Class Orders
        Public Property Burst As Integer
        Public Property Rate As Decimal
        Public Property Tokens As Integer
        Public Property NextToken As DateTime
    End Class

End Namespace