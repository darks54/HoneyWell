﻿Imports System.IO
Imports System.IO.Ports
Imports System.Text
Imports System.Threading

Public Class Xenon
    Implements IDisposable
    ' Keep track of when the object is disposed.
    Protected disposed As Boolean = False

    Dim photo As Boolean = False
    Private path As String = ""
    Private eventEnd As Boolean = False


    Private _port As IO.Ports.SerialPort
    Public Property Port As SerialPort
        Get
            Return _port
        End Get
        Set(value As SerialPort)
            _port = value
        End Set
    End Property

    Sub New(ByVal port As String)
        _port = My.Computer.Ports.OpenSerialPort(port)
    End Sub

    Public Function GetImageJpeg(ByVal save_path As String) As Boolean
        path = save_path
        photo = True

        AddHandler _port.DataReceived, AddressOf DataReceivedHandler
        _port.ReadExisting()
        Dim commande As String = ChrW(22) & ChrW(77) & ChrW(13) & "IMGSNP1L1B1T;IMGSHP6F70K18E."
        _port.WriteLine(commande)
        Dim compteur As Integer = 0
        While Not eventEnd And compteur <= 100
            Thread.Sleep(100)
            compteur += 1
        End While
        If compteur > 100 Then
            Return False
        Else
            Return True
        End If
    End Function

    Private Sub DataReceivedHandler(sender As Object, e As SerialDataReceivedEventArgs)
        Thread.Sleep(1000)
        Dim sp As SerialPort = CType(sender, SerialPort)
        If photo And sp.IsOpen Then
            Dim rx As Integer
            rx = sp.BytesToRead
            If rx > 0 Then
                Dim test As Byte() = New Byte(rx - 1) {}
                sp.Read(test, 0, rx)

                Dim beginJpg() As Byte = {&H1D} 'for example

                For x As Integer = 0 To test.GetUpperBound(0)
                    If test.Skip(x).Take(1).SequenceEqual(beginJpg) Then
                        test = test.Skip(x + 1).ToArray
                        Exit For
                    End If
                Next
                My.Computer.FileSystem.WriteAllBytes(path, test, False)

                photo = False
            End If

            sp.ReadExisting()
        End If
        eventEnd = True
    End Sub

    ' This method disposes the base object's resources.
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposed Then
            If disposing Then
                ' Insert code to free managed resources.
                _port.Close()
                _port.Dispose()
            End If
            ' Insert code to free unmanaged resources.
        End If
        Me.disposed = True
    End Sub

#Region " IDisposable Support "
    ' Do not change or add Overridable to these methods.
    ' Put cleanup code in Dispose(ByVal disposing As Boolean).
    Public Sub Dispose() Implements IDisposable.Dispose
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
    Protected Overrides Sub Finalize()
        Dispose(False)
        MyBase.Finalize()
    End Sub
#End Region
End Class