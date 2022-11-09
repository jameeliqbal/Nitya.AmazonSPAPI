Imports System.IO
Imports System.Threading
Imports Newtonsoft.Json
Imports RestSharp

Public Class Form1
    Private Const spApiBaseUrl As String = "https://sellingpartnerapi-eu.amazon.com"
    Private settings As Common.Models.Settings
    Private credentials As Models.SellerApiCredentials

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Load Settings
        Dim json As String = File.ReadAllText(Path.Combine(Application.StartupPath, "Settings.json"))
        settings = JsonConvert.DeserializeObject(Of Common.Models.Settings)(json)

        ' Setup the form.
        cmbMarketplace.SelectedIndex = 0
        cmbFulfillmentNetwork.SelectedIndex = 0
        dtpCreatedAfter.Value = DateTime.Now.AddDays(-5)
        cmbOrderStatus.SelectedIndex = 3

        'credentials
        credentials = New Models.SellerApiCredentials With {
                .LWA_App_ClientId = "amzn1.application-oa2-client.8bae9facde45464fb4665ab6460c4760",
                .LWA_App_ClientSecret = "de24b0a3f1ac72c3be67191c85ed00e8189061b6b43f54b698b12f74406ccf3a",
                .RefreshToken = "Atzr|IwEBIMnLcyNzzICnYV0EeZikWVffGb6VvEknF8ENXR7OBKqQLA5Bgh1TYZPYSxjVzhn5wTnqpCrWUJt2-L6G3AwtFBmTMxxRCWuWr9L8clILqSXZEKa2ZXYGVAfGvgVlBxavYck-UgDO2c5kkEy39VhjmfqZGVzaC7In4hAVxqnIZLMAPBluLeZtym36dcSBK80_Q99M38H1DQv_agQ4u4fCEPsJn3_IhayAAh9af2-MwrOrFJfBlsAHe4H5aI6tKioIBX3vsjyj8DZcQcaVLSBXSZWoFLgZGxe_wLrl24l5h65ZLj6fH8R6GXFtzGpKK00-YlsHuMMWUm4T2U-oduvcgCdC",
                .AWSKey = "AKIA5ZFSODMIQCYFD6G7",
                .AWSSecret = "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",
                .RoleARN = "arn:aws:iam::947414506257:role/SellerApiAccess"
                }


        'UseRequestToken(False)
    End Sub

    Private Sub btnGetOrder_Click(sender As Object, e As EventArgs) Handles btnGetOrder.Click

        Dim orderID = ctbGetOrder.Text.Trim()
        If String.IsNullOrEmpty(orderID) Then
            MessageBox.Show("Enter a Order Number")
            Return
        End If

        Cursor = Cursors.WaitCursor
        Dim resource As String = "/orders/v0/orders/" & orderID
        Dim request As IRestRequest = New RestRequest(resource, Method.GET)
        Dim client As RestClient = New RestClient(spApiBaseUrl)

        SignRequest(client, credentials, request)

        'get the order
        Dim response = GetResponse(client, request, orderID)

        ' Create the Order object.
        Dim order As Common.Models.Amzn.Orders.GetOrderResponse = JsonConvert.DeserializeObject(Of Common.Models.Amzn.Orders.GetOrderResponse)(response.Content)

        ' If no orders were returned tell the user and exit this Sub.
        If order.Payload.AmazonOrderId Is Nothing Then
            dgvOrders.Rows.Clear()
            dgvOrders.ColumnHeadersVisible = False
            dgvOrders.Columns.Add("Message", "Message")
            dgvOrders.Columns("Message").ValueType = GetType(String)
            dgvOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            dgvOrders.Columns("Message").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgvOrders.Rows.Add("No orders returned...")
            'dgvOrders.ClearSelection()
            Cursor = Cursors.Default
            Return
        End If

        'list order in gridview
        If dgvOrders.Columns.Count > 0 Then
            dgvOrders.ColumnHeadersVisible = True

            dgvOrders.Rows.Clear()
        Else
            BuildDataGridView()
        End If

        dgvOrders.Rows.Add(New String() {False, order.Payload.AmazonOrderId, order.Payload.FulfillmentChannel, order.Payload.OrderStatus, Nothing, order.Payload.PurchaseDate, order.Payload.ShipmentServiceLevelCategory})

        Cursor = Cursors.Default
    End Sub


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

        Cursor = Cursors.WaitCursor
        ' Create the request.
        Dim resource As String = "/orders/v0/orders"
        Dim request As IRestRequest = New RestRequest(resource, Method.GET)
        request.AddParameter("MarketplaceIds", "A21TJRUUN4KGV", ParameterType.QueryString)
        request.AddParameter("CreatedAfter", dtpCreatedAfter.Value.ToUniversalTime().AddDays(-7).ToString("yyyy-MM-dd"), ParameterType.QueryString)
        'request.AddParameter("CreatedAfter", DateTime.UtcNow.AddDays(-5).ToString("yyyy-MM-dd"), ParameterType.QueryString)
        'request.AddParameter("CreatedBefore", DateTime.UtcNow.ToString("yyyy-MM-dd"), ParameterType.QueryString)
        request.AddParameter("OrderStatuses", status, ParameterType.QueryString)
        request.AddParameter("FulfillmentChannels", channels, ParameterType.QueryString)

        Dim client As RestClient = New RestClient(spApiBaseUrl)
        SignRequest(client, credentials, request)
        'get the orders
        Dim response = GetResponse(client, request, "")

        ' Create the Orders object.
        Dim orders As Common.Models.Amzn.Orders.GetOrdersResponse = JsonConvert.DeserializeObject(Of Common.Models.Amzn.Orders.GetOrdersResponse)(response.Content)
        Dim filteredOrders = orders

        lblOrders.Text = "Orders: " & orders.Payload.Orders.Count
        lblFilteredOrders.Text = "Filtered Orders: 0"
        Application.DoEvents()



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
            Cursor = Cursors.Default
            Return
        End If



        BuildDataGridView()
        ' Insert rows into the DataGridView
        For Each order As Common.Models.Amzn.Orders.Order In filteredOrders.Payload.Orders

            ' Get Buyer information.
            Dim buyer = GetBuyerInfo(order)



            dgvOrders.Rows.Add(New String() {False, order.AmazonOrderId, order.FulfillmentChannel, order.OrderStatus, buyer.Payload?.BuyerName, order.PurchaseDate, order.ShipmentServiceLevelCategory})
            Application.DoEvents()
        Next

        Cursor = Cursors.Default
    End Sub

    Private Function GetBuyerInfo(order As Common.Models.Amzn.Orders.Order) As Common.Models.Amzn.Orders.GetOrderBuyerInfoResponse
        Dim resource = "/orders/v0/orders/" & order.AmazonOrderId & "/buyerInfo"
        Dim request = New RestRequest(resource, Method.GET)


        Dim client As RestClient = New RestClient(spApiBaseUrl)
        SignRequest(client, credentials, request)

        'get buyer info
        Dim response = GetResponse(client, request, order.AmazonOrderId)

        ' Create the buyer object.
        Dim buyer As Common.Models.Amzn.Orders.GetOrderBuyerInfoResponse = JsonConvert.DeserializeObject(Of Common.Models.Amzn.Orders.GetOrderBuyerInfoResponse)(response.Content)

        Return buyer
    End Function

    Private Sub btnGetBuyerInfo_Click(sender As Object, e As EventArgs) Handles btnGetBuyerInfo.Click
        Dim orderID = ctbGetOrder.Text.Trim()
        If String.IsNullOrEmpty(orderID) Then
            MessageBox.Show("Enter a Order Number")
            Return
        End If

        Cursor = Cursors.WaitCursor
        Dim resource = "/orders/v0/orders/" & orderID & "/buyerInfo"
        Dim request As IRestRequest = New RestRequest(resource, Method.GET)

        Dim client As RestClient = New RestClient(spApiBaseUrl)
        SignRequest(client, credentials, request)

        'get the order
        Dim response = GetResponse(client, request, orderID)

        ' Create the Order buyer object.
        Dim buyer As Common.Models.Amzn.Orders.GetOrderBuyerInfoResponse = JsonConvert.DeserializeObject(Of Common.Models.Amzn.Orders.GetOrderBuyerInfoResponse)(response.Content)

        'list buyer info in gridview
        If dgvOrders.Columns.Count > 0 Then
            dgvOrders.Rows.Clear()
        Else
            BuildDataGridView()
        End If

        dgvOrders.Rows.Add(New String() {False, buyer.Payload.AmazonOrderId, Nothing, Nothing, buyer.Payload.BuyerName, Nothing, buyer.Payload.BuyerName, Nothing, buyer.Payload.BuyerCounty, buyer.Payload.BuyerEmail})

        Cursor = Cursors.Default
    End Sub


    Private Sub btnGetAddress_Click(sender As Object, e As EventArgs) Handles btnGetAddress.Click
        Dim orderID = ctbGetOrder.Text.Trim()
        If String.IsNullOrEmpty(orderID) Then
            MessageBox.Show("Enter a Order Number")
            Return
        End If

        Cursor = Cursors.WaitCursor
        Dim resource = "/orders/v0/orders/" & orderID & "/address"
        Dim request As IRestRequest = New RestRequest(resource, Method.GET)

        Dim client As RestClient = New RestClient(spApiBaseUrl)
        SignRequest(client, credentials, request)

        'get the order
        Dim response = GetResponse(client, request, orderID)

        ' Create the Order buyer object.
        Dim address As Common.Models.Amzn.Orders.GetOrderAddressResponse = JsonConvert.DeserializeObject(Of Common.Models.Amzn.Orders.GetOrderAddressResponse)(response.Content)

        'list buyer info in gridview
        If dgvOrders.Columns.Count > 0 Then
            dgvOrders.Rows.Clear()
        Else
            BuildDataGridView()
        End If

        dgvOrders.Rows.Add(New String() _
            {False,
                address.Payload.ShippingAddress.Name,
                address.Payload.ShippingAddress.AddressLine1,
                address.Payload.ShippingAddress.AddressLine2,
                address.Payload.ShippingAddress.AddressLine3,
                           address.Payload.ShippingAddress.AddressType,
                           address.Payload.ShippingAddress.City,
                           address.Payload.ShippingAddress.CountryCode,
                           address.Payload.ShippingAddress.County,
                           address.Payload.ShippingAddress.District,
                           address.Payload.ShippingAddress.Municipality,
                           address.Payload.ShippingAddress.PostalCode,
                           address.Payload.ShippingAddress.StateOrRegion
                           })

        Cursor = Cursors.Default
    End Sub


    Private Sub btnGetOrderItems_Click(sender As Object, e As EventArgs) Handles btnGetOrderItems.Click
        Dim orderID = ctbGetOrder.Text.Trim()
        If String.IsNullOrEmpty(orderID) Then
            MessageBox.Show("Enter a Order Number")
            Return
        End If

        Cursor = Cursors.WaitCursor
        Dim resource = "/orders/v0/orders/" & orderID & "/orderItems"
        Dim request As IRestRequest = New RestRequest(resource, Method.GET)

        Dim client As RestClient = New RestClient(spApiBaseUrl)
        SignRequest(client, credentials, request)
        'get the order
        Dim response = GetResponse(client, request, orderID)

        ' Create the Order items object.
        Dim orderItems As Common.Models.Amzn.Orders.GetOrderItemsResponse = JsonConvert.DeserializeObject(Of Common.Models.Amzn.Orders.GetOrderItemsResponse)(response.Content)

        'list order items in gridview
        If dgvOrders.Columns.Count > 0 Then
            dgvOrders.Rows.Clear()
        Else
            BuildDataGridView()
        End If


        For Each item In orderItems.Payload.OrderItems
            dgvOrders.Rows.Add(New String() _
            {False,
                item.SellerSKU,
                item.Title,
                item.ASIN,
                item.CODFee?.Amount,
                item.CODFee?.CurrencyCode,
                item.CODFeeDiscount?.Amount,
                item.CODFeeDiscount?.CurrencyCode,
                item.ConditionId,
                item.ConditionNote,
                item.ConditionSubtypeId,
                item.DeemedResellerCategory,
                item.IossNumber,
                item.IsGift,
                item.IsTransparency,
                item.ItemPrice.Amount,
                item.ItemPrice.CurrencyCode
                               })

        Next


        Cursor = Cursors.Default
    End Sub

    Private Sub btnGetTrackingInfo_Click(sender As Object, e As EventArgs) Handles btnGetTrackingInfo.Click
        Dim trackingID = txtTrackingID.Text.Trim()
        Dim carrierID = "ATS" ' txtcarrierID.Text.Trim()

        'If String.IsNullOrEmpty(carrierID) Then
        '    MessageBox.Show("Enter a Carrier ID")
        '    Return
        'End If

        If String.IsNullOrEmpty(trackingID) Then
            MessageBox.Show("Enter a Tracking ID")
            Return
        End If

        Cursor = Cursors.WaitCursor
        'Dim resource = $"/shipping/v2/tracking"
        'Dim resource = "/shipping/sandbox/v2/tracking"
        Dim resource = $"/shipping/v1/tracking/{trackingID}"
        Dim request As IRestRequest = New RestRequest(resource, Method.GET)

        'request.AddParameter("carrierId", carrierID)
        'request.AddParameter("trackingId", trackingID)
        'request.AddParameter("X-amzn-shipping-business-id", "AmazonShipping_IN", ParameterType.HttpHeader)
        'request.AddHeader("X-amzn-shipping-business-id", "AmazonShipping_IN")


        Dim client As RestClient = New RestClient(spApiBaseUrl)
        SignRequest(client, credentials, request)

        ''get rdt token
        'request = Classes.Signing.SignWithRDT(request)

        'get the tracking info
        Dim response = GetResponse(client, request, trackingID)
        ' Create the tracking info object.
        Dim trackingInfo As Common.Models.Amzn.Shipping.GetTrackingInformationResponse = JsonConvert.DeserializeObject(Of Common.Models.Amzn.Shipping.GetTrackingInformationResponse)(response.Content)

        If trackingInfo.Errors IsNot Nothing Then
            Dim errMsg = trackingInfo.Errors(0).code + Environment.NewLine + trackingInfo.Errors(0).details + Environment.NewLine + trackingInfo.Errors(0).message
            Cursor = Cursors.Default

            MessageBox.Show(errMsg)
            Return
        End If
        'list tracking items in gridview
        If dgvOrders.Columns.Count > 0 Then
            dgvOrders.Rows.Clear()
        Else
            BuildDataGridView()
        End If


        For Each item In trackingInfo.Payload.EventHistory.Events
            dgvOrders.Rows.Add(New String() _
            {False,
            trackingInfo.Payload.TrackingId(),
            trackingInfo.Payload.PromisedDeliveryDate,
            trackingInfo.Payload.Summary.Status,
                item.EventCode,
                item.EventTime,
                item.Location.City,
                item.Location.PostalCode,
                item.Location.StateOrRegion
                               })

        Next


        Cursor = Cursors.Default
    End Sub

#Region "Private Methods"
    Private Sub BuildDataGridView()
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
        dgvOrders.Columns.Add("DeliveryDate", "DeliveryDate")
        dgvOrders.Columns.Add("ShippingMethod", "Shipping Method")
        dgvOrders.Columns.Add("ShippingFirstName", "Shipping First Name")
        dgvOrders.Columns.Add("ShippingLastName", "Shipping Last Name")
        dgvOrders.Columns.Add("ShippingAddress1", "Shipping Address 1")
        dgvOrders.Columns.Add("ShippingAddress2", "Shipping Address 2")
        dgvOrders.Columns.Add("ShippingCity", "Shipping City")
        dgvOrders.Columns.Add("ShippingState", "Shipping State")
        dgvOrders.Columns.Add("ShippingCountry", "Shipping Country")
        dgvOrders.Columns.Add("ShippingZipCode", "Shipping Zip Code")
        dgvOrders.Columns.Add("ShippingPhone", "Shipping Phone Number")
        dgvOrders.Columns.Add("ShippingExtention", "Shipping Extension")

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
        dgvOrders.ColumnHeadersVisible = False
    End Sub

    Private Sub UseRequestToken(tokenUsed As Boolean, Optional rateLimit As Double = 0)
        Dim rate As Decimal
        Dim tokens As Integer
        Dim nextToken As DateTime

        If settings.Application.Throttling IsNot Nothing Then

            ' Assign value to rate and tokens from Settings.json if no value was provided.
            rateLimit = settings.Application.Throttling.Orders.Rate
            rate = settings.Application.Throttling.Orders.Rate
            tokens = settings.Application.Throttling.Orders.Tokens
            nextToken = settings.Application.Throttling.Orders.NextToken
        Else
            settings.Application.Throttling = New Common.Models.Throttling()
            settings.Application.Throttling.Orders = New Common.Models.Orders()

        End If
        ' Update the rate with the supplied rateLimit if a value was supplied.
        If Not rateLimit = 0 Then rate = rateLimit

        ' Check if token(s) were added to the bucket.
        If nextToken <= DateTime.Now Then
            ' Get seconds between last request and now then add the appropriate amount of tokens making sure the amount does not eclipse the burst rate.
            Thread.Sleep(1000)
            Dim seconds As Long = (DateTime.Now - nextToken).TotalSeconds()

            Dim minues As Long

            If seconds * rate + tokens >= settings.Application.Throttling?.Orders?.Burst Then
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

    Private Function GetResponse(client As RestClient, request As IRestRequest, orderID As String) As RestResponse
        Dim response = New RestResponse
        Try

            response = client.Execute(request)
            While response.Headers.Where(Function(x) x.Name = "x-amzn-ErrorType").Count() > 0
                If request.Attempts >= 3 Then
                    Return response
                End If
                'UseRequestToken(False)
                response = client.Execute(request)
            End While
            'UseRequestToken(True, response.Headers.ToList().Find(Function(x) x.Name = "x-amzn-RateLimit-Limit").Value)

            Select Case response.StatusCode
                Case System.Net.HttpStatusCode.OK
                    ' Received a 200 response from the Amazon Selling Partner API.
                    Common.Logging.WriteToLog("INFO", "AMAZON API", "Successfully retrieved buyer information for Amazon order ID " & orderID & ".")
                Case System.Net.HttpStatusCode.Forbidden
                    ' Received a 403 response from the Amazon Selling Partner API.
                    Common.Logging.WriteToLog("ERROR", "AMAZON API", "Received a 403 response when trying to retrieve the order's buyer information for Amazon order ID " & orderID & ".")
                Case Else
                    ' Received a differing response from those covered above.
                    Common.Logging.WriteToLog("ERROR", "AMAZON API", "Recieved a bad response code when trying to retrieve the order's buyer information for Amazon order ID " & orderID & "." & response.StatusCode & ": " & response.StatusDescription)
            End Select

        Catch ex As Exception
            ' If this is hit switch status to red.
            Common.Logging.WriteToLog("ERROR", "APPLICATION", "Was unable to connect to the Amazon Selling Partner API while trying to retrieve the order's buyer information for Amazon order ID " & orderID & ". " & ex.Message)
        End Try
        Return response
    End Function

    Private Function GetClient_OLD(credentials As Models.SellerApiCredentials, request As IRestRequest) As RestClient
        'Dim client As RestClient = New RestClient("https://sellingpartnerapi-na.amazon.com")

        Dim client As RestClient = New RestClient("https://sellingpartnerapi-eu.amazon.com")

        'credentials = New Models.SellerApiCredentials With {
        '        .LWA_App_ClientId = settings.Amazon.Credentials.LwaClientIdentifier,
        '        .LWA_App_ClientSecret = Common.Encryption.DecryptString(settings.Amazon.Credentials.LwaClientSecret),
        '        .RefreshToken = settings.Amazon.Credentials.RefreshToken,
        '        .AWSKey = settings.Amazon.Credentials.AccessKeyId,
        '        .AWSSecret = Common.Encryption.DecryptString(settings.Amazon.Credentials.SecretAccessKey),
        '        .RoleARN = settings.Amazon.Credentials.RoleArn
        '    }

        credentials = New Models.SellerApiCredentials With {
                .LWA_App_ClientId = settings.Amazon.Credentials.LwaClientIdentifier,
                .LWA_App_ClientSecret = settings.Amazon.Credentials.LwaClientSecret,
                .RefreshToken = settings.Amazon.Credentials.RefreshToken,
                .AWSKey = settings.Amazon.Credentials.AccessKeyId,
                .AWSSecret = settings.Amazon.Credentials.SecretAccessKey,
                .RoleARN = settings.Amazon.Credentials.RoleArn
            }

        request = Classes.Signing.SignWithAccessToken(request, credentials.LWA_App_ClientId, credentials.LWA_App_ClientSecret, credentials.RefreshToken)
        request = Classes.Signing.SignWithSTSKeysAndSecurityTokenn(request, client.BaseUrl.Host, credentials.RoleARN, credentials.AWSKey, credentials.AWSSecret)

        Return client
    End Function

    Private Function SignRequest(client As RestClient, credentials As Models.SellerApiCredentials, request As IRestRequest)

        request = Classes.Signing.SignWithAccessToken(request, credentials.LWA_App_ClientId, credentials.LWA_App_ClientSecret, credentials.RefreshToken)
        request = Classes.Signing.SignWithSTSKeysAndSecurityTokenn(request, client.BaseUrl.Host, credentials.RoleARN, credentials.AWSKey, credentials.AWSSecret)
    End Function

#End Region
End Class
