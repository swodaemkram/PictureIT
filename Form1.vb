﻿Imports System.Net.Mail
Imports System.IO
Imports System.Text
Imports System.Net

Public Module Module1
    Public MouzeX As Integer
    Public MouzeY As Integer
    Public EditMode As Boolean = False
    Public LINE_COUNT As Integer = 0
    Public ADD_NEW_RECORD As Boolean = False

End Module

Public Class Form1


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = 2

        Form3.MdiParent = Me
        Form3.WindowState = 0
        Form3.Show()

        Form2.MdiParent = Me
        Form2.Height = Me.Height - 300 : Form2.Width = Me.Width - 50
        Form2.WindowState = 1
        Form2.Show()


        'Lets Load the Database *******************************************************************
        Dim FILE_NAME As String = Application.StartupPath & "\PictureIT.cfg"

        Dim TextLine As String = ""
        If System.IO.File.Exists(FILE_NAME) = True Then
            Dim objReader As New System.IO.StreamReader(FILE_NAME)

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

        End If
        'Done Loading The Database *****************************************************************






    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        ' Me.ToolStripStatusLabel2.Text = String.Format("Mouse Position X:{0}, Y:{1}", Control.MousePosition.X, Control.MousePosition.Y - 50)
        Me.ToolStripStatusLabel2.Text = String.Format("Mouse Position X:{0}, Y:{1}", Control.MousePosition.X, Control.MousePosition.Y)
        Me.ToolStripStatusLabel1.Text = DateString + " " + TimeString

    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        End
    End Sub

    Private Sub ToolStripStatusLabel2_Click(sender As Object, e As EventArgs) Handles ToolStripStatusLabel2.Click

    End Sub

    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click


        Using sw As System.IO.StreamWriter = New System.IO.StreamWriter(Application.StartupPath & "\PictureIT.cfg")

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

    End Sub

    Private Sub AddToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddToolStripMenuItem.Click
        EditMode = True
        Form3.DataGridView1.ReadOnly = False
        Form2.Timer1.Enabled = False
        SaveToolStripMenuItem.Enabled = True
    End Sub

    Private Sub ToolStripStatusLabel1_Click(sender As Object, e As EventArgs) Handles ToolStripStatusLabel1.Click

    End Sub

    Private Sub EditToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditToolStripMenuItem.Click
        ADD_NEW_RECORD = True
        EditMode = True
        Form3.DataGridView1.ReadOnly = False
        Form2.Timer1.Enabled = False
        SaveToolStripMenuItem.Enabled = True
    End Sub

    Private Sub FileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FileToolStripMenuItem.Click

    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click

    End Sub
End Class