Imports System.IO
Imports System.Threading
Imports Newtonsoft.Json
Imports RestSharp

Public Class Form1
    Private settings As Common.Models.Settings

    Private Sub btnGetOrders_Click(sender As Object, e As EventArgs) Handles btnGetOrders.Click
        ' Create OrderStatuses array.
        Dim status As String = Nothing
        Select Case cmbOrderStatus.Text
            Case "All"
                status = "PendingAvailability,Pending,Unshipped,PartiallyShipped,Shipped,InvoiceUnconfirmed,Canceled,Unfulfillable"
            Case "Pending Availability"
                status = "PendingAvailability"
            Case "Pending"
                status = "Pending"
            Case "Unshipped"
                status = "Unshipped"
            Case "Partially Shipped"
                status = "PartiallyShipped"
            Case "Shipped"
                status = "Shipped"
            Case "Invoice Unconfirmed"
                status = "InvoiceUnconfirmed"
            Case "Canceled"
                status = "Canceled"
            Case "Unfulfillable"
                status = "Unfulfillable"
        End Select

        ' Create FulfillmentChannels array.
        Dim channels As String = Nothing
        Select Case cmbFulfillmentNetwork.Text
            Case "Amazon and Merchant Fulfillment Networks"
                channels = "AFN,MFN"
            Case "Amazon Fulfillment Network"
                channels = "AFN"
            Case "Merchant Fulfillment Network"
                channels = "MFN"
        End Select

        ' Create the request.
        Dim resource As String = "/orders/v0/orders"
        Dim request As IRestRequest = New RestRequest(resource, Method.GET)
        request.AddParameter("MarketplaceIds", "ATVPDKIKX0DER", ParameterType.QueryString)
        request.AddParameter("CreatedAfter", DateTime.UtcNow.AddDays(-5).ToString("yyyy-MM-dd"), ParameterType.QueryString)
        request.AddParameter("CreatedBefore", DateTime.UtcNow.ToString("yyyy-MM-dd"), ParameterType.QueryString)
        request.AddParameter("OrderStatuses", status, ParameterType.QueryString)
        request.AddParameter("FulfillmentChannels", channels, ParameterType.QueryString)

        Dim client As RestClient = New RestClient("https://sellingpartnerapi-na.amazon.com")

        Dim credentials As New Models.SellerApiCredentials With {
            .LWA_App_ClientId = settings.Amazon.Credentials.LwaClientIdentifier,
            .LWA_App_ClientSecret = Common.Encryption.DecryptString(settings.Amazon.Credentials.LwaClientSecret),
            .RefreshToken = settings.Amazon.Credentials.RefreshToken,
            .AWSKey = settings.Amazon.Credentials.AccessKeyId,
            .AWSSecret = Common.Encryption.DecryptString(settings.Amazon.Credentials.SecretAccessKey),
            .RoleARN = settings.Amazon.Credentials.RoleArn
        }

        request = Classes.Signing.SignWithAccessToken(request, credentials.LWA_App_ClientId, credentials.LWA_App_ClientSecret, credentials.RefreshToken)
        request = Classes.Signing.SignWithSTSKeysAndSecurityTokenn(request, client.BaseUrl.Host, credentials.RoleARN, credentials.AWSKey, credentials.AWSSecret)

        Dim response As New RestResponse
        Try
            response = client.Execute(request)
            While response.Headers.Where(Function(x) x.Name = "x-amzn-ErrorType").Count() > 0
                UseRequestToken(False)
                response = client.Execute(request)
            End While
            UseRequestToken(True, response.Headers.ToList().Find(Function(x) x.Name = "x-amzn-RateLimit-Limit").Value)


            Select Case response.StatusCode
                Case System.Net.HttpStatusCode.OK
                    ' Received a 200 response from the Amazon Selling Partner API.
                    Common.Logging.WriteToLog("INFO", "AMAZON API", "Successfully requested orders.")
                Case System.Net.HttpStatusCode.Forbidden
                    ' Received a 403 response from the Amazon Selling Partner API.
                    Common.Logging.WriteToLog("ERROR", "AMAZON API", "Received a 403 response when trying to import orders.")
                Case Else
                    ' Received a differing response from those covered above.
                    Common.Logging.WriteToLog("ERROR", "AMAZON API", "Recieved a bad response code when trying to import orders. " & response.StatusCode & ": " & response.StatusDescription)
            End Select

        Catch ex As Exception
            ' If this is hit switch status to red.
            Common.Logging.WriteToLog("ERROR", "APPLICATION", "Was unable to connect to the Amazon Selling Partner API while trying to import orders. " & ex.Message)
        End Try

        ' Create the Orders object.
        Dim orders As Common.Models.Amzn.Orders.GetOrdersResponse = JsonConvert.DeserializeObject(Of Common.Models.Amzn.Orders.GetOrdersResponse)(response.Content)
        Dim filteredOrders = orders

        lblOrders.Text = "Orders: " & orders.Payload.Orders.Count
        lblFilteredOrders.Text = "Filtered Orders: 0"
        Application.DoEvents()

        '' Remove imported orders is asked to.
        'For Each order As Common.Models.Amzn.Orders.Order In orders.Payload.Orders.ToList()
        '    Dim imported As Boolean = False
        '    If chkUnimportedOnly.Checked Then
        '        If Atrex.Orders.InvoiceExists(order.AmazonOrderId) Or Atrex.Orders.OrderExists(order.AmazonOrderId) Then
        '            filteredOrders.Payload.Orders.RemoveAll(Function(x) x.AmazonOrderId = order.AmazonOrderId)

        '            ' Record keeping mainly for testing.
        '            lblFilteredOrders.Text = "Filtered Orders: " & filteredOrders.Payload.Orders.Count()
        '            Application.DoEvents()
        '        End If
        '    End If
        'Next

        ' Reset the current DataGridView and hide the check all CheckBox.
        dgvOrders.Rows.Clear()
        dgvOrders.Columns.Clear()
        dgvOrders.ColumnHeadersVisible = True
        dgvOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None

        ' If no orders were returned tell the user and exit this Sub.
        If orders.Payload.Orders.Count() = 0 Then
            dgvOrders.ColumnHeadersVisible = False
            dgvOrders.Columns.Add("Message", "Message")
            dgvOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            dgvOrders.Columns("Message").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgvOrders.Rows.Add("No orders returned...")
            dgvOrders.ClearSelection()
            Return
        End If


        ' Build the DataGridView.
        Dim chk As New DataGridViewCheckBoxColumn()
        chk.Name = "Import"
        chk.HeaderText = "Import"

        dgvOrders.Columns.Add(chk)
        dgvOrders.Columns.Add("AmazonOrderId", "Amazon Order ID")
        dgvOrders.Columns.Add("FulfillmentNetwork", "Fulfillment Network")
        dgvOrders.Columns.Add("Status", "Order Status")
        dgvOrders.Columns.Add("BuyerName", "Buyer Name")
        dgvOrders.Columns.Add("PurchaseDate", "Purchase Date")
        'dgvOrders.Columns.Add("DeliveryDate", "DeliveryDate")
        dgvOrders.Columns.Add("ShippingMethod", "Shipping Method")
        'dgvOrders.Columns.Add("ShippingFirstName", "Shipping First Name")
        'dgvOrders.Columns.Add("ShippingLastName", "Shipping Last Name")
        'dgvOrders.Columns.Add("ShippingAddress1", "Shipping Address 1")
        'dgvOrders.Columns.Add("ShippingAddress2", "Shipping Address 2")
        'dgvOrders.Columns.Add("ShippingCity", "Shipping City")
        'dgvOrders.Columns.Add("ShippingState", "Shipping State")
        'dgvOrders.Columns.Add("ShippingCountry", "Shipping Country")
        'dgvOrders.Columns.Add("ShippingZipCode", "Shipping Zip Code")
        'dgvOrders.Columns.Add("ShippingPhone", "Shipping Phone Number")
        'dgvOrders.Columns.Add("ShippingExtention", "Shipping Extension")

        ' Autosize the columns.
        For i As Integer = 0 To dgvOrders.ColumnCount - 1
            dgvOrders.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        Next

        ' Turn off ReadOnly on the Import column.
        dgvOrders.ReadOnly = False
        For Each dgvc As DataGridViewColumn In dgvOrders.Columns
            dgvc.ReadOnly = True
        Next
        dgvOrders.Columns("Import").ReadOnly = False

        ' Insert rows into the DataGridView
        For Each order As Common.Models.Amzn.Orders.Order In filteredOrders.Payload.Orders

            ' Get Buyer information.
            resource = "/orders/v0/orders/" & order.AmazonOrderId & "/buyerInfo"
            request = New RestRequest(resource, Method.GET)

            client = New RestClient("https://sellingpartnerapi-na.amazon.com")

            credentials = New Models.SellerApiCredentials With {
                .LWA_App_ClientId = settings.Amazon.Credentials.LwaClientIdentifier,
                .LWA_App_ClientSecret = Common.Encryption.DecryptString(settings.Amazon.Credentials.LwaClientSecret),
                .RefreshToken = settings.Amazon.Credentials.RefreshToken,
                .AWSKey = settings.Amazon.Credentials.AccessKeyId,
                .AWSSecret = Common.Encryption.DecryptString(settings.Amazon.Credentials.SecretAccessKey),
                .RoleARN = settings.Amazon.Credentials.RoleArn
            }

            request = Classes.Signing.SignWithAccessToken(request, credentials.LWA_App_ClientId, credentials.LWA_App_ClientSecret, credentials.RefreshToken)
            request = Classes.Signing.SignWithSTSKeysAndSecurityTokenn(request, client.BaseUrl.Host, credentials.RoleARN, credentials.AWSKey, credentials.AWSSecret)

            response = New RestResponse
            Try

                response = client.Execute(request)
                While response.Headers.Where(Function(x) x.Name = "x-amzn-ErrorType").Count() > 0
                    'UseRequestToken(False)
                    response = client.Execute(request)
                End While
                'UseRequestToken(True, response.Headers.ToList().Find(Function(x) x.Name = "x-amzn-RateLimit-Limit").Value)

                Select Case response.StatusCode
                    Case System.Net.HttpStatusCode.OK
                        ' Received a 200 response from the Amazon Selling Partner API.
                        Common.Logging.WriteToLog("INFO", "AMAZON API", "Successfully retrieved buyer information for Amazon order ID " & order.AmazonOrderId & ".")
                    Case System.Net.HttpStatusCode.Forbidden
                        ' Received a 403 response from the Amazon Selling Partner API.
                        Common.Logging.WriteToLog("ERROR", "AMAZON API", "Received a 403 response when trying to retrieve the order's buyer information for Amazon order ID " & order.AmazonOrderId & ".")
                    Case Else
                        ' Received a differing response from those covered above.
                        Common.Logging.WriteToLog("ERROR", "AMAZON API", "Recieved a bad response code when trying to retrieve the order's buyer information for Amazon order ID " & order.AmazonOrderId & "." & response.StatusCode & ": " & response.StatusDescription)
                End Select

            Catch ex As Exception
                ' If this is hit switch status to red.
                Common.Logging.WriteToLog("ERROR", "APPLICATION", "Was unable to connect to the Amazon Selling Partner API while trying to retrieve the order's buyer information for Amazon order ID " & order.AmazonOrderId & ". " & ex.Message)
            End Try

            ' Create the Orders object.
            Dim buyer As Common.Models.Amzn.Orders.GetOrderBuyerInfoResponse = JsonConvert.DeserializeObject(Of Common.Models.Amzn.Orders.GetOrderBuyerInfoResponse)(response.Content)



            dgvOrders.Rows.Add(New String() {False, order.AmazonOrderId, order.FulfillmentChannel, order.OrderStatus, buyer.Payload.BuyerName, order.PurchaseDate, order.ShipmentServiceLevelCategory})
        Next

    End Sub

#Region "Private Methods"

    Private Sub UseRequestToken(tokenUsed As Boolean, Optional rateLimit As Double = 0)
        ' Assign value to rate and tokens from Settings.json if no value was provided.
        rateLimit = settings.Application.Throttling.Orders.Rate
        Dim rate As Decimal = settings.Application.Throttling.Orders.Rate
        Dim tokens As Integer = settings.Application.Throttling.Orders.Tokens
        Dim nextToken As DateTime = settings.Application.Throttling.Orders.NextToken

        ' Update the rate with the supplied rateLimit if a value was supplied.
        If Not rateLimit = 0 Then rate = rateLimit

        ' Check if token(s) were added to the bucket.
        If nextToken <= DateTime.Now Then
            ' Get seconds between last request and now then add the appropriate amount of tokens making sure the amount does not eclipse the burst rate.
            Thread.Sleep(1000)
            Dim seconds As Long = (DateTime.Now - nextToken).TotalSeconds()

            Dim minues As Long

            If seconds * rate + tokens >= settings.Application.Throttling.Orders.Burst Then
                tokens = settings.Application.Throttling.Orders.Burst
            Else
                tokens = Math.Floor(seconds * rate) + 1
            End If
            settings.Application.Throttling.Orders.Tokens = tokens

            ' Calculate when the next token will be made available.
            nextToken = DateTime.Now.AddSeconds(1 / rate)
        End If

        ' If the bucket is empty of token sleep until one is added.
        If tokens = 0 Then
            Dim waitTime As Integer = (nextToken - DateTime.Now).TotalMilliseconds()
            lblTokens.Text = "Tokens: Waiting " & Math.Ceiling(waitTime / 1000) & " seconds until next token is added."
            Application.DoEvents()
            Thread.Sleep(waitTime)
            tokens = 1
        End If

        ' If a token was used remove it from the bucket.
        If tokenUsed Then
            tokens = tokens - 1
        End If

        ' Save changes to the Settings.json file.
        settings.Application.Throttling.Orders.Rate = rate
        settings.Application.Throttling.Orders.Tokens = tokens
        settings.Application.Throttling.Orders.NextToken = nextToken
        Try
            File.WriteAllText(Path.Combine(Application.StartupPath, "Settings.json"), JsonConvert.SerializeObject(settings, Formatting.Indented))
        Catch ex As Exception
            Common.Logging.WriteToLog("ERROR", "APPLICATION", "Unable to write the file Settings.json. " + ex.Message)
            MessageBox.Show("Unable to create Settings.json." + Environment.NewLine + ex.Message, "Unable to Create Settings.json")
        End Try

        lblTokens.Text = "Tokens: " & tokens
        Application.DoEvents()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Load Settings
        Dim json As String = File.ReadAllText(Path.Combine(Application.StartupPath, "Settings.json"))
        settings = JsonConvert.DeserializeObject(Of Common.Models.Settings)(json)

        ' Setup the form.
        cmbMarketplace.SelectedIndex = 0
        cmbFulfillmentNetwork.SelectedIndex = 0
        dtpCreatedAfter.Value = DateTime.Now.AddDays(-5)
        cmbOrderStatus.SelectedIndex = 3

        UseRequestToken(False)
    End Sub

#End Region
End Class
