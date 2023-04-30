Imports System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar

Public Class Form2

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.PictureBox1.Height = Me.Height + 600
        Me.PictureBox1.Width = Me.Width + 600

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

            Form3.DataGridView1.CurrentCell.Value = e.X & "." & e.Y


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
        Dim RColor As Integer = 0
        Dim GColor As Integer = 0
        Dim BColor As Integer = 0
        Dim PingDelay As Integer = 0

        On Error Resume Next

        For t = 0 To LINE_COUNT - 1
            'Dim PATH_QUALITY As Integer = Form3.DataGridView1.Rows(t).Cells(6).Value 'Color of Line

            POINT12 = Form3.DataGridView1.Rows(t).Cells(1).Value
            Dim FIRST_POINT As String() = POINT12.Split(".")
            POINT34 = Form3.DataGridView1.Rows(t).Cells(2).Value
            Dim SECOND_POINT As String() = POINT34.Split(".")

            PingDelay = Form3.DataGridView1.Rows(t).Cells(6).Value
            Form1.ToolStripStatusLabel3.Text = PingDelay

            If PingDelay > 250 Then PingDelay = 250
            If PingDelay = 0 Then RColor = 250 : GColor = 0 : BColor = 0

            If PingDelay > 0 Then GColor = 250 - PingDelay : RColor = PingDelay : BColor = PingDelay


            Dim myPen As New System.Drawing.Pen(System.Drawing.Color.FromArgb(RColor, GColor, BColor), 5)

            ' Draw lines of each link

            Dim Surface As Graphics = Me.PictureBox1.CreateGraphics()

            Surface.DrawLine(myPen, Convert.ToInt32(FIRST_POINT(0)), Convert.ToInt32(FIRST_POINT(1)), Convert.ToInt32(SECOND_POINT(0)), Convert.ToInt32(SECOND_POINT(1)))

            'myPen.Dispose()
            'formGraphics.Dispose()

            ' End of Draw Lines

            Next t

            t = 0
        Me.Timer1.Enabled = True

    End Sub

    Private Sub Form2_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove
        ' Me.Text = e.Location.ToString
        'Form1.ToolStripStatusLabel2.Text = String.Format("Mouse Position X:{0}, Y:{1}", Control.MousePosition.X, Control.MousePosition.Y)


    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub PictureBox1_MouseWheel(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseWheel



    End Sub

    Private Sub PictureBox1_DoubleClick(sender As Object, e As EventArgs) Handles PictureBox1.DoubleClick

    End Sub

    Private Sub Form2_DoubleClick(sender As Object, e As EventArgs) Handles Me.DoubleClick

    End Sub

    Private Sub PictureBox1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseDoubleClick
        If EditMode = True Then


            Dim x As Integer = Form3.DataGridView1.CurrentCellAddress.X
            'MsgBox(MousePosition().ToString())
            Form3.DataGridView1.CurrentCell.Value = e.X & "." & e.Y 'Make Changes Here


        End If
    End Sub

    Private Sub PictureBox1_Paint(sender As Object, e As PaintEventArgs) Handles PictureBox1.Paint

    End Sub
End Class