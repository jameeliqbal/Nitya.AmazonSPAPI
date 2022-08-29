<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.lblTokens = New System.Windows.Forms.Label()
        Me.lblFilteredOrders = New System.Windows.Forms.Label()
        Me.lblOrders = New System.Windows.Forms.Label()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.cmbOrderStatus = New System.Windows.Forms.ComboBox()
        Me.lblMarketplace = New System.Windows.Forms.Label()
        Me.cmbMarketplace = New System.Windows.Forms.ComboBox()
        Me.btnGetOrders = New System.Windows.Forms.Button()
        Me.lblCreatedAfter = New System.Windows.Forms.Label()
        Me.lblFulfillmentNetwork = New System.Windows.Forms.Label()
        Me.cmbFulfillmentNetwork = New System.Windows.Forms.ComboBox()
        Me.dtpCreatedAfter = New System.Windows.Forms.DateTimePicker()
        Me.dgvOrders = New System.Windows.Forms.DataGridView()
        Me.btnGetOrder = New System.Windows.Forms.Button()
        Me.ctbGetOrder = New System.Windows.Forms.TextBox()
        CType(Me.dgvOrders, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblTokens
        '
        Me.lblTokens.AutoSize = True
        Me.lblTokens.Location = New System.Drawing.Point(15, 17)
        Me.lblTokens.Name = "lblTokens"
        Me.lblTokens.Size = New System.Drawing.Size(64, 13)
        Me.lblTokens.TabIndex = 37
        Me.lblTokens.Text = "Tokens: NA"
        '
        'lblFilteredOrders
        '
        Me.lblFilteredOrders.AutoSize = True
        Me.lblFilteredOrders.Location = New System.Drawing.Point(12, 212)
        Me.lblFilteredOrders.Name = "lblFilteredOrders"
        Me.lblFilteredOrders.Size = New System.Drawing.Size(87, 13)
        Me.lblFilteredOrders.TabIndex = 36
        Me.lblFilteredOrders.Text = "Filtered Orders: 0"
        '
        'lblOrders
        '
        Me.lblOrders.AutoSize = True
        Me.lblOrders.Location = New System.Drawing.Point(49, 196)
        Me.lblOrders.Name = "lblOrders"
        Me.lblOrders.Size = New System.Drawing.Size(50, 13)
        Me.lblOrders.TabIndex = 35
        Me.lblOrders.Text = "Orders: 0"
        '
        'lblStatus
        '
        Me.lblStatus.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Location = New System.Drawing.Point(38, 165)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(69, 13)
        Me.lblStatus.TabIndex = 34
        Me.lblStatus.Text = "Order Status:"
        '
        'cmbOrderStatus
        '
        Me.cmbOrderStatus.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbOrderStatus.FormattingEnabled = True
        Me.cmbOrderStatus.Items.AddRange(New Object() {"All", "Pending Availability", "Pending", "Unshipped", "Partially Shipped", "Shipped", "Invoice Unconfirmed", "Canceled", "Unfulfillable"})
        Me.cmbOrderStatus.Location = New System.Drawing.Point(113, 162)
        Me.cmbOrderStatus.Name = "cmbOrderStatus"
        Me.cmbOrderStatus.Size = New System.Drawing.Size(200, 21)
        Me.cmbOrderStatus.TabIndex = 33
        '
        'lblMarketplace
        '
        Me.lblMarketplace.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblMarketplace.AutoSize = True
        Me.lblMarketplace.Location = New System.Drawing.Point(38, 84)
        Me.lblMarketplace.Name = "lblMarketplace"
        Me.lblMarketplace.Size = New System.Drawing.Size(69, 13)
        Me.lblMarketplace.TabIndex = 32
        Me.lblMarketplace.Text = "Marketplace:"
        '
        'cmbMarketplace
        '
        Me.cmbMarketplace.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbMarketplace.FormattingEnabled = True
        Me.cmbMarketplace.Items.AddRange(New Object() {"All"})
        Me.cmbMarketplace.Location = New System.Drawing.Point(113, 81)
        Me.cmbMarketplace.Name = "cmbMarketplace"
        Me.cmbMarketplace.Size = New System.Drawing.Size(200, 21)
        Me.cmbMarketplace.TabIndex = 31
        '
        'btnGetOrders
        '
        Me.btnGetOrders.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGetOrders.Location = New System.Drawing.Point(113, 52)
        Me.btnGetOrders.Name = "btnGetOrders"
        Me.btnGetOrders.Size = New System.Drawing.Size(200, 23)
        Me.btnGetOrders.TabIndex = 30
        Me.btnGetOrders.Text = "Get All Orders"
        Me.btnGetOrders.UseVisualStyleBackColor = True
        '
        'lblCreatedAfter
        '
        Me.lblCreatedAfter.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCreatedAfter.AutoSize = True
        Me.lblCreatedAfter.Location = New System.Drawing.Point(1, 140)
        Me.lblCreatedAfter.Name = "lblCreatedAfter"
        Me.lblCreatedAfter.Size = New System.Drawing.Size(106, 13)
        Me.lblCreatedAfter.TabIndex = 29
        Me.lblCreatedAfter.Text = "Orders Created After:"
        '
        'lblFulfillmentNetwork
        '
        Me.lblFulfillmentNetwork.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblFulfillmentNetwork.AutoSize = True
        Me.lblFulfillmentNetwork.Location = New System.Drawing.Point(8, 111)
        Me.lblFulfillmentNetwork.Name = "lblFulfillmentNetwork"
        Me.lblFulfillmentNetwork.Size = New System.Drawing.Size(99, 13)
        Me.lblFulfillmentNetwork.TabIndex = 28
        Me.lblFulfillmentNetwork.Text = "Fulfillment Network:"
        '
        'cmbFulfillmentNetwork
        '
        Me.cmbFulfillmentNetwork.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbFulfillmentNetwork.FormattingEnabled = True
        Me.cmbFulfillmentNetwork.Items.AddRange(New Object() {"Amazon and Merchant Fulfillment Networks", "Amazon Fulfillment Network", "Merchant Fulfillment Network"})
        Me.cmbFulfillmentNetwork.Location = New System.Drawing.Point(113, 108)
        Me.cmbFulfillmentNetwork.Name = "cmbFulfillmentNetwork"
        Me.cmbFulfillmentNetwork.Size = New System.Drawing.Size(200, 21)
        Me.cmbFulfillmentNetwork.TabIndex = 27
        '
        'dtpCreatedAfter
        '
        Me.dtpCreatedAfter.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtpCreatedAfter.Location = New System.Drawing.Point(113, 136)
        Me.dtpCreatedAfter.Name = "dtpCreatedAfter"
        Me.dtpCreatedAfter.Size = New System.Drawing.Size(200, 20)
        Me.dtpCreatedAfter.TabIndex = 26
        '
        'dgvOrders
        '
        Me.dgvOrders.AllowUserToAddRows = False
        Me.dgvOrders.AllowUserToDeleteRows = False
        Me.dgvOrders.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvOrders.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.dgvOrders.Location = New System.Drawing.Point(0, 416)
        Me.dgvOrders.Name = "dgvOrders"
        Me.dgvOrders.RowHeadersVisible = False
        Me.dgvOrders.Size = New System.Drawing.Size(1244, 253)
        Me.dgvOrders.TabIndex = 38
        '
        'btnGetOrder
        '
        Me.btnGetOrder.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGetOrder.Location = New System.Drawing.Point(419, 52)
        Me.btnGetOrder.Name = "btnGetOrder"
        Me.btnGetOrder.Size = New System.Drawing.Size(200, 23)
        Me.btnGetOrder.TabIndex = 40
        Me.btnGetOrder.Text = "Get Single Order"
        Me.btnGetOrder.UseVisualStyleBackColor = True
        '
        'ctbGetOrder
        '
        Me.ctbGetOrder.Location = New System.Drawing.Point(419, 82)
        Me.ctbGetOrder.Name = "ctbGetOrder"
        Me.ctbGetOrder.Size = New System.Drawing.Size(200, 20)
        Me.ctbGetOrder.TabIndex = 41
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1244, 669)
        Me.Controls.Add(Me.ctbGetOrder)
        Me.Controls.Add(Me.btnGetOrder)
        Me.Controls.Add(Me.dgvOrders)
        Me.Controls.Add(Me.lblTokens)
        Me.Controls.Add(Me.lblFilteredOrders)
        Me.Controls.Add(Me.lblOrders)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.cmbOrderStatus)
        Me.Controls.Add(Me.lblMarketplace)
        Me.Controls.Add(Me.cmbMarketplace)
        Me.Controls.Add(Me.btnGetOrders)
        Me.Controls.Add(Me.lblCreatedAfter)
        Me.Controls.Add(Me.lblFulfillmentNetwork)
        Me.Controls.Add(Me.cmbFulfillmentNetwork)
        Me.Controls.Add(Me.dtpCreatedAfter)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.dgvOrders, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblTokens As Label
    Friend WithEvents lblFilteredOrders As Label
    Friend WithEvents lblOrders As Label
    Friend WithEvents lblStatus As Label
    Friend WithEvents cmbOrderStatus As ComboBox
    Friend WithEvents lblMarketplace As Label
    Friend WithEvents cmbMarketplace As ComboBox
    Friend WithEvents btnGetOrders As Button
    Friend WithEvents lblCreatedAfter As Label
    Friend WithEvents lblFulfillmentNetwork As Label
    Friend WithEvents cmbFulfillmentNetwork As ComboBox
    Friend WithEvents dtpCreatedAfter As DateTimePicker
    Friend WithEvents dgvOrders As DataGridView
    Friend WithEvents btnGetOrder As Button
    Friend WithEvents ctbGetOrder As TextBox
End Class
