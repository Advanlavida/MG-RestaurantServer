Option Explicit On

Imports System.IO
Imports System.Net.Sockets

Public Class Form2
    Dim Listener As New TcpListener(8000)
    Dim Client As TcpClient

    Private Sub Form2_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Listener.Stop()
    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Start()
        Listener.Start()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim Message As String
        Message = ""
        If Listener.Pending = True Then
            Client = Listener.AcceptTcpClient()
            Dim Reader As New StreamReader(Client.GetStream())
            While Reader.Peek > -1
                Message &= Convert.ToChar(Reader.Read()).ToString
            End While
            DataGridView1.Rows(DataGridView1.RowCount - 2).Cells(0).Value = Message
        End If
    End Sub
End Class