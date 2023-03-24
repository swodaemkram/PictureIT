Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Form2.MdiParent = Me
        Form2.Show()


    End Sub
End Class
