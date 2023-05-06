Imports System.ComponentModel

Public Class Form6

    Private Sub Form6_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Form6_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        e.Cancel = True
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If CURRENT_EVENT <> "" Then Me.Label1.Text = CURRENT_EVENT & " Has timed out... @ " & DateString & " " & TimeString : CURRENT_EVENT = ""
    End Sub
End Class