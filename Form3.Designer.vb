<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form3
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
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.LinkName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Link1_Location = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Link2_Location = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IP_Address_Link1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IP_Address_Link2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Link1PingTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Link2_PingTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Link1_Number_of_Pings = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Link2_Number_of_Pings = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Link1_Number_of_Failed_Pings = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Link2_Number_of_Failed_Pings = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Link1_Ping_Average = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Link2_Ping_Average = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.BackgroundColor = System.Drawing.SystemColors.ControlDarkDark
        Me.DataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.LinkName, Me.Link1_Location, Me.Link2_Location, Me.IP_Address_Link1, Me.IP_Address_Link2, Me.Link1PingTime, Me.Link2_PingTime, Me.Link1_Number_of_Pings, Me.Link2_Number_of_Pings, Me.Link1_Number_of_Failed_Pings, Me.Link2_Number_of_Failed_Pings, Me.Link1_Ping_Average, Me.Link2_Ping_Average})
        Me.DataGridView1.GridColor = System.Drawing.SystemColors.ControlText
        Me.DataGridView1.Location = New System.Drawing.Point(12, 12)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowTemplate.Height = 25
        Me.DataGridView1.Size = New System.Drawing.Size(1130, 119)
        Me.DataGridView1.TabIndex = 0
        '
        'BackgroundWorker1
        '
        Me.BackgroundWorker1.WorkerSupportsCancellation = True
        '
        'LinkName
        '
        Me.LinkName.HeaderText = "Link Name"
        Me.LinkName.Name = "LinkName"
        Me.LinkName.ReadOnly = True
        '
        'Link1_Location
        '
        Me.Link1_Location.HeaderText = "Link1 Location"
        Me.Link1_Location.Name = "Link1_Location"
        Me.Link1_Location.ReadOnly = True
        '
        'Link2_Location
        '
        Me.Link2_Location.HeaderText = "Link2 Location"
        Me.Link2_Location.Name = "Link2_Location"
        Me.Link2_Location.ReadOnly = True
        '
        'IP_Address_Link1
        '
        Me.IP_Address_Link1.HeaderText = "IP Address Link1"
        Me.IP_Address_Link1.Name = "IP_Address_Link1"
        Me.IP_Address_Link1.ReadOnly = True
        '
        'IP_Address_Link2
        '
        Me.IP_Address_Link2.HeaderText = "IP Address Link2"
        Me.IP_Address_Link2.Name = "IP_Address_Link2"
        Me.IP_Address_Link2.ReadOnly = True
        '
        'Link1PingTime
        '
        Me.Link1PingTime.HeaderText = "Link1 PingTime"
        Me.Link1PingTime.Name = "Link1PingTime"
        Me.Link1PingTime.ReadOnly = True
        '
        'Link2_PingTime
        '
        Me.Link2_PingTime.HeaderText = "Link2 PingTime"
        Me.Link2_PingTime.Name = "Link2_PingTime"
        Me.Link2_PingTime.ReadOnly = True
        '
        'Link1_Number_of_Pings
        '
        Me.Link1_Number_of_Pings.HeaderText = "Link1 Total Pings"
        Me.Link1_Number_of_Pings.Name = "Link1_Number_of_Pings"
        Me.Link1_Number_of_Pings.ReadOnly = True
        '
        'Link2_Number_of_Pings
        '
        Me.Link2_Number_of_Pings.HeaderText = "Link2 Total Pings"
        Me.Link2_Number_of_Pings.Name = "Link2_Number_of_Pings"
        Me.Link2_Number_of_Pings.ReadOnly = True
        '
        'Link1_Number_of_Failed_Pings
        '
        Me.Link1_Number_of_Failed_Pings.HeaderText = "Link1 Number Failed Pings"
        Me.Link1_Number_of_Failed_Pings.Name = "Link1_Number_of_Failed_Pings"
        Me.Link1_Number_of_Failed_Pings.ReadOnly = True
        '
        'Link2_Number_of_Failed_Pings
        '
        Me.Link2_Number_of_Failed_Pings.HeaderText = "Link2 Number Failed Pings"
        Me.Link2_Number_of_Failed_Pings.Name = "Link2_Number_of_Failed_Pings"
        Me.Link2_Number_of_Failed_Pings.ReadOnly = True
        '
        'Link1_Ping_Average
        '
        Me.Link1_Ping_Average.HeaderText = "Link1 % Faile"
        Me.Link1_Ping_Average.Name = "Link1_Ping_Average"
        Me.Link1_Ping_Average.ReadOnly = True
        '
        'Link2_Ping_Average
        '
        Me.Link2_Ping_Average.HeaderText = "Link2 % Failed"
        Me.Link2_Ping_Average.Name = "Link2_Ping_Average"
        Me.Link2_Ping_Average.ReadOnly = True
        '
        'Form3
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1156, 145)
        Me.Controls.Add(Me.DataGridView1)
        Me.Location = New System.Drawing.Point(1, 11080)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(1172, 184)
        Me.Name = "Form3"
        Me.Opacity = 0.5R
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Network Database Management"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents LinkName As DataGridViewTextBoxColumn
    Friend WithEvents Link1_Location As DataGridViewTextBoxColumn
    Friend WithEvents Link2_Location As DataGridViewTextBoxColumn
    Friend WithEvents IP_Address_Link1 As DataGridViewTextBoxColumn
    Friend WithEvents IP_Address_Link2 As DataGridViewTextBoxColumn
    Friend WithEvents Link1PingTime As DataGridViewTextBoxColumn
    Friend WithEvents Link2_PingTime As DataGridViewTextBoxColumn
    Friend WithEvents Link1_Number_of_Pings As DataGridViewTextBoxColumn
    Friend WithEvents Link2_Number_of_Pings As DataGridViewTextBoxColumn
    Friend WithEvents Link1_Number_of_Failed_Pings As DataGridViewTextBoxColumn
    Friend WithEvents Link2_Number_of_Failed_Pings As DataGridViewTextBoxColumn
    Friend WithEvents Link1_Ping_Average As DataGridViewTextBoxColumn
    Friend WithEvents Link2_Ping_Average As DataGridViewTextBoxColumn
End Class
