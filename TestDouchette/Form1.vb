Imports System.IO
Imports System.IO.Ports
Imports System.Text
Imports System.Threading
Imports Honeywell.Xenon

Public Class Form1
    Dim xenon As Xenon = New Xenon("COM4")
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnJPG_Click(sender As Object, e As EventArgs) Handles btnJPG.Click
        If PictureBox1.Image IsNot Nothing Then
            PictureBox1.Image.Dispose()
        End If
        xenon.IMGSNP.LedState = True
        xenon.IMGSNP.Beeper = True
        xenon.IMGSNP.WaitForTrigger = True
        xenon.IMGSHP.FileFormat = FileFormat.JPEG
        xenon.IMGSHP.GammaCorrection = 70
        xenon.IMGSHP.EdgeSharpen = 18
        If xenon.GetImage("C:\temp\test.jpg") Then
            PictureBox1.Image = Image.FromFile("C:\temp\test.jpg")
        Else
            MsgBox("erreur")
        End If
    End Sub

    Private Sub btnBMP_Click(sender As Object, e As EventArgs) Handles btnBMP.Click
        If PictureBox1.Image IsNot Nothing Then
            PictureBox1.Image.Dispose()
        End If
        xenon.IMGSNP.LedState = True
        xenon.IMGSNP.Beeper = True
        xenon.IMGSNP.WaitForTrigger = True
        xenon.IMGSHP.FileFormat = FileFormat.BMP
        xenon.IMGSHP.GammaCorrection = 70
        xenon.IMGSHP.EdgeSharpen = 18
        If xenon.GetImage("C:\temp\test.bmp") Then
            PictureBox1.Image = Image.FromFile("C:\temp\test.bmp")
        Else
            MsgBox("erreur")
        End If
    End Sub

    Private Sub Form1_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        xenon.Dispose()
    End Sub
End Class