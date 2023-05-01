Imports System.Net.Mail
Imports System.IO
Imports System.Text
Imports System.Net
Imports System.Net.NetworkInformation
Imports System.Threading
Imports System.Windows.Forms.Design.AxImporter
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.Runtime.InteropServices
Public Module Module1

    Public MouzeX As Integer = 0
    Public MouzeY As Integer = 0
    Public EditMode As Boolean = False
    Public LINE_COUNT As Integer = 0
    Public ADD_NEW_RECORD As Boolean = False
    Public FILE_NAME As String = ""
    Public NETWORK_MAP As String = ""
    Public NEW_MAP As String = ""
    Public eend As Integer = 0
    Public HEIGHT_OFF_SET As Integer = 0
    Public WIDTH_OFF_SET As Integer = 0
    'Public X As Integer = 0
    'Public Y As Integer = 0

End Module

Public Class Form1


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = 2

        Form3.MdiParent = Me
        Form3.WindowState = 0
        Form3.Show()

        Form2.MdiParent = Me
        Form2.Height = Me.Height - 300 : Form2.Width = Me.Width - 50
        Form2.WindowState = 0
        Form2.Show()

        Form4.MdiParent = Me
        Form4.WindowState = 1
        Form4.Show()

        Form6.MdiParent = Me
        Form6.WindowState = 1
        Form6.Show()




    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        ' Me.ToolStripStatusLabel2.Text = String.Format("Mouse Position X:{0}, Y:{1}", Control.MousePosition.X, Control.MousePosition.Y - 50)
        Me.ToolStripStatusLabel2.Text = String.Format("Mouse Position X:{0}, Y:{1}", Control.MousePosition.X, Control.MousePosition.Y)
        Me.ToolStripStatusLabel1.Text = DateString + " " + TimeString

    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        End
    End Sub


    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click

        'Using sw As System.IO.StreamWriter = New System.IO.StreamWriter(Application.StartupPath & "\PictureIT.cfg")

        Me.SaveFileDialog1.Filter = "Picture I.T. File|*.pin"
        Me.SaveFileDialog1.ShowDialog()
        FILE_NAME = Me.SaveFileDialog1.FileName

        Using sw As System.IO.StreamWriter = New System.IO.StreamWriter(FILE_NAME)

            sw.Write(NETWORK_MAP & vbLf)

            For t = 0 To 256

                If Form3.DataGridView1.Rows.Item(t).Cells(0).Value = "" And Form3.DataGridView1.Rows.Item(t).Cells(1).Value = "" Then GoTo CLOSEIT
                sw.Write(Form3.DataGridView1.Rows.Item(t).Cells(0).Value & "," & Form3.DataGridView1.Rows.Item(t).Cells(1).Value &
                 "," & Form3.DataGridView1.Rows.Item(t).Cells(2).Value & "," & Form3.DataGridView1.Rows.Item(t).Cells(3).Value & "," _
                 & Form3.DataGridView1.Rows.Item(t).Cells(4).Value & vbLf)

            Next

CLOSEIT:

            sw.Close()

        End Using

        EditMode = False
        Form3.DataGridView1.ReadOnly = True
        SaveToolStripMenuItem.Enabled = False
        If ADD_NEW_RECORD = True Then LINE_COUNT = LINE_COUNT + 1 : ADD_NEW_RECORD = False
        Form2.Timer1.Enabled = True
        Me.SaveToolStripMenuItem.Enabled = False
    End Sub




    Private Sub EditToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditToolStripMenuItem.Click
        ADD_NEW_RECORD = True
        EditMode = True
        Form3.DataGridView1.ReadOnly = False
        ' Form2.Timer1.Enabled = False
        SaveToolStripMenuItem.Enabled = True
        DeleteToolStripMenuItem.Enabled = True

    End Sub



    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click

        Form3.DataGridView1.Rows.RemoveAt(Form3.DataGridView1.CurrentRow.Index)
        LINE_COUNT = LINE_COUNT - 1
    End Sub

    Private Sub LoadNetworkToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LoadNetworkToolStripMenuItem.Click
        Me.EditToolStripMenuItem.Enabled = True
        Me.OpenFileDialog1.Filter = "Picture I.T. File|*.pin"

        Form2.Timer1.Enabled = False

        Form3.DataGridView1.Rows.Clear()
        ' Form3.DataGridView1.Columns.Clear()

        Me.OpenFileDialog1.ShowDialog()

        'Lets Load the Database *******************************************************************

        FILE_NAME = Me.OpenFileDialog1.FileName

        Dim TextLine As String = ""
        If System.IO.File.Exists(FILE_NAME) = True Then
            Dim objReader As New System.IO.StreamReader(FILE_NAME)

            TextLine = objReader.ReadLine()
            NETWORK_MAP = TextLine
            'Form2.BackgroundImage = New System.Drawing.Bitmap(TextLine)
            Form2.PictureBox1.Image = New System.Drawing.Bitmap(TextLine)
            'Form2.PictureBox1.Width = Form2.Width
            'Form2.PictureBox1.Height = Form2.Height

            LINE_COUNT = Form3.DataGridView1.Rows.Add()

            Do While objReader.Peek() <> -1

                TextLine = objReader.ReadLine()

                LINE_COUNT = Form3.DataGridView1.Rows.Add() - 1

                Dim LinkName As String = ""
                Dim Link1_Location As String = ""
                Dim Link2_Location As String = ""
                Dim IP_Address_Link1 As String = ""
                Dim IP_Address_Link2 As String = ""
                Dim The_DATA As String() = TextLine.Split(",")

                Form3.DataGridView1.Rows.Item(LINE_COUNT).Cells(0).Value = The_DATA(0)
                Form3.DataGridView1.Rows.Item(LINE_COUNT).Cells(1).Value = The_DATA(1)
                Form3.DataGridView1.Rows.Item(LINE_COUNT).Cells(2).Value = The_DATA(2)
                Form3.DataGridView1.Rows.Item(LINE_COUNT).Cells(3).Value = The_DATA(3)
                Form3.DataGridView1.Rows.Item(LINE_COUNT).Cells(4).Value = The_DATA(4)

                LINE_COUNT = LINE_COUNT + 1
            Loop

            objReader.Close()

            Me.StartTestingToolStripMenuItem.Enabled = True


        End If
        'Done Loading The Database *****************************************************************
        Form2.Timer1.Enabled = True
    End Sub


    Private Sub StartTestingToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StartTestingToolStripMenuItem.Click
        Me.EditToolStripMenuItem.Enabled = False
        Me.CeateNewNetworkToolStripMenuItem.Enabled = False
        Me.LoadNetworkToolStripMenuItem.Enabled = False
        Me.ExitToolStripMenuItem.Enabled = False
        Form3.BackgroundWorker1.RunWorkerAsync()
        Me.StopTestingToolStripMenuItem.Enabled = True
        Me.StartTestingToolStripMenuItem.Enabled = False
    End Sub

    Private Sub StopTestingToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StopTestingToolStripMenuItem.Click

        Me.EditToolStripMenuItem.Enabled = True
        Me.CeateNewNetworkToolStripMenuItem.Enabled = True
        Me.LoadNetworkToolStripMenuItem.Enabled = True
        Me.ExitToolStripMenuItem.Enabled = True
        Form3.BackgroundWorker1.CancelAsync()
        Me.StopTestingToolStripMenuItem.Enabled = False
        Me.StartTestingToolStripMenuItem.Enabled = True
    End Sub

    Private Sub ToolStripStatusLabel3_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub CeateNewNetworkToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CeateNewNetworkToolStripMenuItem.Click

        EditMode = True
        Form2.Timer1.Enabled = True
        Form3.DataGridView1.Rows.Clear()
        Me.SaveToolStripMenuItem.Enabled = True
        Me.OpenFileDialog1.Filter = "Picture File|*.jpg"
        Me.OpenFileDialog1.ShowDialog()
        NETWORK_MAP = Me.OpenFileDialog1.FileName
        'Form2.BackgroundImage = New System.Drawing.Bitmap(NETWORK_MAP)

        Form2.PictureBox1.Image = New System.Drawing.Bitmap(NETWORK_MAP)


        Form3.DataGridView1.ReadOnly = False

    End Sub

    Private Sub TraceRouteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TraceRouteToolStripMenuItem.Click
        Form4.WindowState = 0
        Form4.BringToFront()
    End Sub

    Private Sub TraceToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TraceToolStripMenuItem.Click



        If Form4.TextBox1.Text = "" Then MsgBox("Requiered URL or I.P. Missing") : Exit Sub

        Dim iplist As IEnumerable(Of IPAddress)
        Dim ee As Integer = 0
        Form4.DataGridView1.Rows.Clear()

        iplist = TraceRoute.GetTraceRoute(Form4.TextBox1.Text)
        eend = iplist.Count

        For ee = 0 To eend - 1

            Form4.DataGridView1.Rows.Add(iplist(ee).ToString)
            ' Dim macAddress As String = clsARP.GetMAC(iplist(ee).ToString)
            ' Form4.DataGridView1.Rows.Item(ee).Cells(1).Value = macAddress
        Next ee

        MsgBox("Trace Complete over " & eend & " Hopps...")

    End Sub

    Private Sub ExportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExportToolStripMenuItem.Click
        Form3.DataGridView1.Rows.Clear()

        Dim IMPORTTRACE As Integer = 0
        Form3.DataGridView1.Rows.Add()

        For IMPORTTRACE = 0 To eend - 1
            Form3.DataGridView1.Rows.Add()
            Form3.DataGridView1.Rows.Item(IMPORTTRACE).Cells(0).Value = "Link " & IMPORTTRACE
            Form3.DataGridView1.Rows.Item(IMPORTTRACE).Cells(3).Value = Form4.DataGridView1.Rows.Item(IMPORTTRACE).Cells(0).Value

            If (IMPORTTRACE + 1) < eend Then

                Form3.DataGridView1.Rows.Item(IMPORTTRACE).Cells(4).Value = Form4.DataGridView1.Rows.Item(IMPORTTRACE + 1).Cells(0).Value

            Else

                Form3.DataGridView1.Rows.Item(IMPORTTRACE).Cells(4).Value = Form4.TextBox1.Text

            End If


        Next

    End Sub

    Private Sub MACToolStripMenuItem_Click(sender As Object, e As EventArgs)



    End Sub

    Private Sub ToolStripStatusLabel4_Click(sender As Object, e As EventArgs) Handles ToolStripStatusLabel4.Click

    End Sub

    Private Sub StatusStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles StatusStrip1.ItemClicked

    End Sub
End Class

Public Class TraceRoute
    Private Const Data As String = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa"

    Public Shared Function GetTraceRoute(ByVal hostNameOrAddress As String) As IEnumerable(Of IPAddress)
        Return GetTraceRoute(hostNameOrAddress, 1)
    End Function
    Private Shared Function GetTraceRoute(ByVal hostNameOrAddress As String, ByVal ttl As Integer) As IEnumerable(Of IPAddress)
        Dim pinger As Ping = New Ping
        Dim pingerOptions As PingOptions = New PingOptions(ttl, True)
        Dim timeout As Integer = 10000
        Dim buffer() As Byte = Encoding.ASCII.GetBytes(Data)
        Dim reply As PingReply

        reply = pinger.Send(hostNameOrAddress, timeout, buffer, pingerOptions)

        Dim result As List(Of IPAddress) = New List(Of IPAddress)
        If reply.Status = IPStatus.Success Then
            result.Add(reply.Address)
        ElseIf reply.Status = IPStatus.TtlExpired Then
            'add the currently returned address
            result.Add(reply.Address)
            'recurse to get the next address...
            Dim tempResult As IEnumerable(Of IPAddress)
            tempResult = GetTraceRoute(hostNameOrAddress, ttl + 1)
            result.AddRange(tempResult)
        Else
            'failure 
        End If

        Return result
    End Function

End Class



Public Class clsARP
    Declare Function SendARP Lib "iphlpapi.dll" (ByVal DestIP As UInt32, ByVal SrcIP As UInt32, ByVal pMacAddr As Byte(), ByRef PhyAddrLen As Integer) As Integer
    Public Shared Function GetMAC(ByVal IPAddress As String) As String
        Dim addr As IPAddress = Net.IPAddress.Parse(IPAddress)
        Dim mac() As Byte = New Byte(6) {}
        Dim len As Integer = mac.Length
        SendARP(CUInt(addr.Address), 0, mac, len)
        Dim macAddress As String = BitConverter.ToString(mac, 0, len)
        Return macAddress
    End Function
    Private Sub New()
    End Sub


    ' This is how to use this Function  Dim macAddress As String = clsARP.GetMAC("10.10.2.1")





End Class

