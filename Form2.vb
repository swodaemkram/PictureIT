Imports System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar

Public Class Form2

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load






    End Sub

    Private Sub Form2_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        ' Dim Surface As Graphics = CreateGraphics()
        ' Dim penGreen As Pen = New Pen(Color.Green, 5)

        ' Surface.DrawLine(penGreen, 466, 158, 591, 139)


    End Sub


    Private Sub Form2_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed

    End Sub

    Private Sub Form2_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles Me.MouseDoubleClick


        If EditMode = True Then


            Dim x As Integer = Form3.DataGridView1.CurrentCellAddress.X
            'MsgBox(MousePosition().ToString())
            Form3.DataGridView1.CurrentCell.Value = e.X & "." & e.Y 'Make Changes Here


        End If

    End Sub

    Private Sub Form2_ClientSizeChanged(sender As Object, e As EventArgs) Handles Me.ClientSizeChanged



    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        Me.Timer1.Enabled = False
        Dim t As Integer = 0
        Dim POINT1 As Integer = 0
        Dim POINT2 As Integer = 0
        Dim POINT3 As Integer = 0
        Dim POINT4 As Integer = 0
        Dim POINT12 As String = ""
        Dim POINT34 As String = ""

        ' For t = 0 To LINE_COUNT - 1
        For t = 0 To LINE_COUNT - 1
            Dim PATH_QUALITY As Integer = Form3.DataGridView1.Rows(t).Cells(1).Value

            POINT12 = Form3.DataGridView1.Rows(t).Cells(1).Value
            Dim FIRST_POINT As String() = POINT12.Split(".")
            POINT34 = Form3.DataGridView1.Rows(t).Cells(2).Value
            Dim SECOND_POINT As String() = POINT34.Split(".")

            Dim myPen As New System.Drawing.Pen(System.Drawing.Color.Red, 5)



            Dim formGraphics As System.Drawing.Graphics
            formGraphics = Me.CreateGraphics()
            formGraphics.DrawLine(myPen, Convert.ToInt32(FIRST_POINT(0)), Convert.ToInt32(FIRST_POINT(1)), Convert.ToInt32(SECOND_POINT(0)), Convert.ToInt32(SECOND_POINT(1)))
            myPen.Dispose()
            formGraphics.Dispose()

        Next t

        'Dim ping As New System.Net.NetworkInformation.Ping
        'Dim ms = ping.Send("10.10.2.230").RoundtripTime()
        'Me.Text = ms

        t = 0
        Me.Timer1.Enabled = True

    End Sub

    Private Sub Form2_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove
        ' Me.Text = e.Location.ToString



    End Sub
End Class