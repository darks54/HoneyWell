Imports System.IO
Imports System.IO.Ports
Imports System.Text
Imports System.Threading
Imports Honeywell.Xenon

Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnPhoto_Click(sender As Object, e As EventArgs) Handles btnPhoto.Click
        If PictureBox1.Image IsNot Nothing Then
            PictureBox1.Image.Dispose()
        End If
        Dim xenon As Xenon = New Xenon("COM6")
        If xenon.GetImageJpeg("C:\temp\test.jpg") Then
            PictureBox1.Image = Image.FromFile("C:\temp\test.jpg")
        Else
            MsgBox("erreur")
        End If
        xenon.Dispose()
    End Sub
End Class