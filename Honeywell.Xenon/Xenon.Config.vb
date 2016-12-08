Partial Class Xenon

#Region "IMGSNP"
    ''' <summary>
    ''' 
    ''' </summary>
    Enum Style
        DecodingStyle = 0
        PhotoStyle = 1
        ManualStyle = 2
    End Enum

    Private _beeper As Boolean
    Public Property Beeper As Boolean
        Get
            Return _beeper
        End Get
        Set(value As Boolean)
            _beeper = value
        End Set
    End Property

    Private _waitForTrigger As Boolean
    Public Property WaitForTrigger As Boolean
        Get
            Return _waitForTrigger
        End Get
        Set(value As Boolean)
            _waitForTrigger = value
        End Set
    End Property

    Private _ledState As Boolean
    Public Property LedState As Boolean
        Get
            Return _ledState
        End Get
        Set(value As Boolean)
            _ledState = value
        End Set
    End Property

    Private _exposure As Integer

    Public Property Exposure As Integer
        Get
            Return _exposure
        End Get
        Set(value As Integer)
            If value >= 1 And value <= 7874 Then
                _exposure = value
            End If
        End Set
    End Property

    Enum Gain
        NoGain = 1
        MediumGain = 2
        HeavyGain = 4
        MaximunGain = 8
    End Enum

    Private _targetWhiteValue As Integer

    Public Property TargetWhiteValue As Integer
        Get
            Return _targetWhiteValue
        End Get
        Set(value As Integer)
            If value >= 0 And value <= 255 Then
                _targetWhiteValue = value
            End If
        End Set
    End Property

    Private _deltaForAcceptance As Integer

    Public Property DeltaForAcceptance As Integer
        Get
            Return _deltaForAcceptance
        End Get
        Set(value As Integer)
            If value >= 0 And value <= 255 Then
                _deltaForAcceptance = value
            End If
        End Set
    End Property

    Private _updateTries As Integer

    Public Property UpdateTries As Integer
        Get
            Return _updateTries
        End Get
        Set(value As Integer)
            If value >= 0 And value <= 10 Then
                _updateTries = value
            End If
        End Set
    End Property

    Private _targetSetPointPercentage As Integer

    Public Property TargetSetPointPercentage As Integer
        Get
            Return _targetSetPointPercentage
        End Get
        Set(value As Integer)
            If value >= 1 And value <= 99 Then
                _targetSetPointPercentage = value
            End If
        End Set
    End Property

#End Region

#Region "IMGSHP"
    Private _infinitFilter As Boolean
    Public Property InfinitFilter As Boolean
        Get
            Return _infinitFilter
        End Get
        Set(value As Boolean)
            _infinitFilter = value
        End Set
    End Property

    Private _compensation As Boolean
    Public Property Compensation As Boolean
        Get
            Return _compensation
        End Get
        Set(value As Boolean)
            _compensation = value
        End Set
    End Property

    Enum PixelDepth
        Grayscale = 8
        BlackAndWhite = 1
    End Enum

    Private _edgeSharpen As Integer

    Public Property EdgeSharpen As Integer
        Get
            Return _edgeSharpen
        End Get
        Set(value As Integer)
            If value >= 0 And value <= 24 Then
                _edgeSharpen = value
            End If
        End Set
    End Property

    Enum FileFormat
        KIM = 0
        TIFF = 1
        TIFF_Compressed = 2
        TIFF_Grayscale = 3
        UncompressedBinary = 4
        UncompressedGrayscale = 5
        JPEG = 6
        BMP = 8
        TIFF_ColorCompressed = 10
        TIFF_ColorUncompressed = 11
        JPEG_Color = 12
        BMP_Color = 14
        BMP_Uncompressed = 15
    End Enum

    Private _histogramStretch As Boolean
    Public Property HistogramStretch As Boolean
        Get
            Return _histogramStretch
        End Get
        Set(value As Boolean)
            _histogramStretch = value
        End Set
    End Property

    Enum InvertImage
        X = 0
        Y = 1
    End Enum

    Private _noiseReduction As Boolean
    Public Property NoiseReduction As Boolean
        Get
            Return _noiseReduction
        End Get
        Set(value As Boolean)
            _noiseReduction = value
        End Set
    End Property

    Enum ImageRotate
        r000 = 0
        r090 = 1
        r180 = 2
        r260 = 3
    End Enum

    Private _jpegImageQuality As Integer

    Public Property JpegImageQuality As Integer
        Get
            Return _jpegImageQuality
        End Get
        Set(value As Integer)
            If value >= 0 And value <= 100 Then
                _jpegImageQuality = value
            End If
        End Set
    End Property

    Private _gammaCorrection As Integer

    Public Property GammaCorrection As Integer
        Get
            Return _gammaCorrection
        End Get
        Set(value As Integer)
            If value >= 0 And value <= 255 Then
                _gammaCorrection = value
            End If
        End Set
    End Property

    Private _imageCroppingLeft As Integer

    Public Property ImageCroppingLeft As Integer
        Get
            Return _imageCroppingLeft
        End Get
        Set(value As Integer)
            If value >= 0 And value <= 843 Then
                _imageCroppingLeft = value
            End If
        End Set
    End Property

    Private _imageCroppingRight As Integer

    Public Property ImageCroppingRight As Integer
        Get
            Return _imageCroppingRight
        End Get
        Set(value As Integer)
            If value >= 0 And value <= 843 Then
                _imageCroppingRight = value
            End If
        End Set
    End Property

    Private _imageCroppingTop As Integer

    Public Property ImageCroppingTop As Integer
        Get
            Return _imageCroppingTop
        End Get
        Set(value As Integer)
            If value >= 0 And value <= 639 Then
                _imageCroppingTop = value
            End If
        End Set
    End Property

    Private _imageCroppingBottom As Integer

    Public Property ImageCroppingBottom As Integer
        Get
            Return _imageCroppingBottom
        End Get
        Set(value As Integer)
            If value >= 0 And value <= 639 Then
                _imageCroppingBottom = value
            End If
        End Set
    End Property

    Enum Protocol
        None = 0
        NoneForUSB = 2
        HmodemCompressed = 3
        Hmodem = 4
    End Enum

    Enum PixelShip
        Ship1 = 1
        Ship2 = 2
        Ship3 = 3
    End Enum

    Private _documentImageFilter As Integer

    Public Property DocumentImageFilter As Integer
        Get
            Return _documentImageFilter
        End Get
        Set(value As Integer)
            If value >= 0 And value <= 255 Then
                _documentImageFilter = value
            End If
        End Set
    End Property

    Private _blurImage As Boolean
    Public Property BlurImage As Boolean
        Get
            Return _blurImage
        End Get
        Set(value As Boolean)
            _blurImage = value
        End Set
    End Property

    Private _histogramShip As Boolean
    Public Property HistogramShip As Boolean
        Get
            Return _histogramShip
        End Get
        Set(value As Boolean)
            _histogramShip = value
        End Set
    End Property
#End Region
End Class
