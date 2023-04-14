Public Class Form3
    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Location = New Point(200, 580)
    End Sub

    Private Sub Form3_Resize(sender As Object, e As EventArgs) Handles Me.Resize

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
THEVERYTOP:

        Threading.Thread.Sleep(300)

        If BackgroundWorker1.CancellationPending = True Then Exit Sub



        Dim ping As New System.Net.NetworkInformation.Ping
        'Dim ms = ping.Send("10.10.2.1").RoundtripTime()
        Dim ms = ping.Send(DataGridView1.Rows.Item(0).Cells(3).Value).RoundtripTime()

        DataGridView1.Rows.Item(0).Cells(5).Value = ms
        DataGridView1.Rows.Item(0).Cells(7).Value = DataGridView1.Rows.Item(0).Cells(7).Value + 1

        ms = ping.Send(DataGridView1.Rows.Item(0).Cells(4).Value).RoundtripTime()
        DataGridView1.Rows.Item(0).Cells(6).Value = ms
        DataGridView1.Rows.Item(0).Cells(8).Value = DataGridView1.Rows.Item(0).Cells(8).Value + 1

        'DataGridView1.Rows.Item(0).Cells(9).Value = DataGridView1.Rows.Item(9).Cells(7).Value + 1


        GoTo THEVERYTOP

    End Sub
End Class