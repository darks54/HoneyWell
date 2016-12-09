Imports System.IO
Imports System.IO.Ports
Imports System.Text
Imports System.Threading
Imports System.Windows.Forms

Public Class Xenon
    Implements IDisposable

    Public IMGSNP As New IMGSNP
    Public IMGSHP As New IMGSHP
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
        'If sendKeyAuto Then
        AddHandler _port.DataReceived, AddressOf DataReceivedHandler
        'End If

    End Sub

    Public Function GetImage(ByVal save_path As String) As Boolean
        path = save_path
        photo = True
        eventEnd = False
        'AddHandler _port.DataReceived, AddressOf DataReceivedHandler
        _port.ReadExisting()
        Dim commande As String = BuildCommand()
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

    Public Function GetImageBmp(ByVal save_path As String) As Boolean
        path = save_path
        photo = True
        eventEnd = False
        'AddHandler _port.DataReceived, AddressOf DataReceivedHandler
        _port.ReadExisting()
        Dim commande As String = ChrW(22) & ChrW(77) & ChrW(13) & "IMGSNP1L1B1T;IMGSHP8F70K18E."
        _port.WriteLine(commande)
        Dim compteur As Integer = 0
        While Not eventEnd 'And compteur <= 100
            Thread.Sleep(100)
            compteur += 1
        End While
        If compteur > 100 Then
            Return False
        Else
            Return True
        End If
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub DataReceivedHandler(sender As Object, e As SerialDataReceivedEventArgs)
        Thread.Sleep(1000)
        Dim sp As SerialPort = CType(sender, SerialPort)
        If photo And sp.IsOpen Then
            Dim rx As Integer
            rx = sp.BytesToRead
            Dim first As Boolean = True

            Dim result() As Byte = New Byte(0) {}
            While rx > 0
                Dim test As Byte() = New Byte(rx - 1) {}
                sp.Read(test, 0, rx)
                If first Then
                    Dim beginJpg() As Byte = {&H1D} 'for example

                    For x As Integer = 0 To test.GetUpperBound(0)
                        If test.Skip(x).Take(1).SequenceEqual(beginJpg) Then
                            test = test.Skip(x + 1).ToArray
                            Exit For
                        End If
                    Next
                    first = False

                    result = test
                Else
                    result = result.Concat(test).ToArray
                End If

                rx = sp.BytesToRead
            End While

            My.Computer.FileSystem.WriteAllBytes(path, result, False)

            photo = False

        ElseIf sp.IsOpen Then
            Dim data As String = ""
            data = sp.ReadExisting
            SendKeys.SendWait(data)
            sp.ReadExisting()
        End If
        eventEnd = True
    End Sub

    Private Function BuildCommand() As String
        Dim command As String = ""

        Dim snp = "IMGSNP"
        If Not IMGSNP.Style = Style.PhotoStyle Then
            snp += Convert.ToInt32(IMGSNP.Style) & "P"
        End If
        If IMGSNP.Beeper Then
            snp += "1B"
        End If
        If IMGSNP.WaitForTrigger Then
            snp += "1T"
        End If
        If IMGSNP.LedState Then
            snp += "1L"
        End If
        If Not IMGSNP.Exposure = 7874 Then
            snp += IMGSNP.Exposure & "E"
        End If
        If Not IMGSNP.Gain = Gain.NoGain Then
            snp += Convert.ToInt32(IMGSNP.Gain) & "G"
        End If
        If Not IMGSNP.TargetWhiteValue = 125 Then
            snp += IMGSNP.TargetWhiteValue & "W"
        End If
        If Not IMGSNP.DeltaForAcceptance = 25 Then
            snp += IMGSNP.DeltaForAcceptance & "D"
        End If
        If Not IMGSNP.UpdateTries = 6 Then
            snp += IMGSNP.UpdateTries & "U"
        End If
        If Not IMGSNP.TargetSetPointPercentage = 50 Then
            snp += IMGSNP.TargetSetPointPercentage & "%"
        End If

        Dim shp = ";IMGSHP"
        If IMGSHP.InfinitFilter Then
            shp += "1A"
        End If
        If IMGSHP.Compensation Then
            shp += "1C"
        End If
        If IMGSHP.PixelDepth = PixelDepth.BlackAndWhite Then
            shp += "1D"
        End If
        If Not IMGSHP.EdgeSharpen = 0 Then
            shp += IMGSHP.EdgeSharpen & "E"
        End If
        If Not IMGSHP.FileFormat = FileFormat.JPEG Then
            shp += Convert.ToInt32(IMGSHP.FileFormat) & "F"
        End If
        If IMGSHP.HistogramStretch Then
            shp += "1H"
        End If
        If Not IMGSHP.InvertImage = InvertImage.None Then
            If IMGSHP.InvertImage = InvertImage.X Then
                shp += "1ix"
            Else
                shp += "1iy"
            End If
        End If
        If IMGSHP.NoiseReduction Then
            shp += "1if"
        End If
        Select Case IMGSHP.ImageRotate
            Case ImageRotate.r090
                shp += "1ir"
            Case ImageRotate.r180
                shp += "2ir"
            Case ImageRotate.r260
                shp += "3ir"
        End Select
        If Not IMGSHP.JpegImageQuality = 50 Then
            shp += IMGSHP.JpegImageQuality & "J"
        End If
        If Not IMGSHP.GammaCorrection = 0 Then
            shp += IMGSHP.GammaCorrection & "K"
        End If
        If Not IMGSHP.ImageMargin = 0 Then
            shp += IMGSHP.ImageMargin & "M"
        Else
            If Not IMGSHP.ImageCroppingLeft = 0 Then
                shp += IMGSHP.ImageCroppingLeft & "L"
            End If
            If Not IMGSHP.ImageCroppingRight = 0 Then
                shp += IMGSHP.ImageCroppingRight & "R"
            End If
            If Not IMGSHP.ImageCroppingTop = 0 Then
                shp += IMGSHP.ImageCroppingTop & "T"
            End If
            If Not IMGSHP.ImageCroppingBottom = 0 Then
                shp += IMGSHP.ImageCroppingBottom & "B"
            End If
        End If
        Select Case IMGSHP.Protocol
            Case Protocol.None
                shp += "0P"
            Case Protocol.NoneForUSB
                shp += ""
            Case Protocol.HmodemCompressed
                shp += "3P"
            Case Protocol.Hmodem
                shp += "4P"
        End Select
        Select Case IMGSHP.PixelShip
            Case PixelShip.Ship1
                shp += ""
            Case PixelShip.Ship2
                shp += "2S"
            Case PixelShip.Ship3
                shp += "3S"
        End Select
        If Not IMGSHP.DocumentImageFilter = 0 Then
            shp += IMGSHP.DocumentImageFilter & "U"
        End If
        If IMGSHP.BlurImage Then
            shp += "1V"
        End If
        If IMGSHP.HistogramShip Then
            shp += "1W"
        End If

        command = ChrW(22) & ChrW(77) & ChrW(13) & snp & shp & "."
        Return command
    End Function


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