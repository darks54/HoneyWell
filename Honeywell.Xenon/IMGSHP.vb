Imports Honeywell.Xenon

Public Class IMGSHP

    Private _infinitFilter As Boolean = False
    ''' <summary>
    ''' <para>Enhances pictures taken from very long distances (greater than 10 feet or 3m). The Infinity Filter should not be used with IMGSNP Modifiers.</para>
    ''' <para>False: Infinity filter off (default)</para>
    ''' <para>True: Infinity filter on</para>
    ''' </summary>
    Public Property InfinitFilter As Boolean
        Get
            Return _infinitFilter
        End Get
        Set(value As Boolean)
            _infinitFilter = value
        End Set
    End Property

    Private _compensation As Boolean = False
    ''' <summary>
    ''' <para>Flattens the image to account for variation in illumination across the image.</para>
    ''' <para>False: Compensation disabled (default)</para>
    ''' <para>True: Compensation enabled</para>
    ''' </summary>
    Public Property Compensation As Boolean
        Get
            Return _compensation
        End Get
        Set(value As Boolean)
            _compensation = value
        End Set
    End Property

    Private _pixelDepth As PixelDepth = PixelDepth.Grayscale
    ''' <summary>
    ''' <para>Indicates the number of bits per pixel in the transmitted image (KIM or BMP format only).</para>
    ''' <para>Default: Grayscale</para>
    ''' </summary>
    Public Property PixelDepth As PixelDepth
        Get
            Return _pixelDepth
        End Get
        Set(value As PixelDepth)
            _pixelDepth = value
        End Set
    End Property

    Private _edgeSharpen As Integer = 0
    ''' <summary>
    ''' <para>An edge sharpen filter cleans up the edges of an image, making it look cleaner and sharper.</para>
    ''' <para>Range: 0 - 24</para>
    ''' <para>Default: 0</para>
    ''' </summary>
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

    Private _fileFormat As FileFormat = FileFormat.JPEG
    ''' <summary>
    ''' <para>Indicates the desired format for the image.</para>
    ''' <para>Default: JPEG</para>
    ''' </summary>
    Public Property FileFormat As FileFormat
        Get
            Return _fileFormat
        End Get
        Set(value As FileFormat)
            _fileFormat = value
        End Set
    End Property

    Private _histogramStretch As Boolean = False
    ''' <summary>
    ''' <para>Increases the contrast of the transmitted image. Not available with some image formats.</para>
    ''' <para>False: No stretch (default)</para>
    ''' <para>True: Histogram stretch</para>
    ''' </summary>
    Public Property HistogramStretch As Boolean
        Get
            Return _histogramStretch
        End Get
        Set(value As Boolean)
            _histogramStretch = value
        End Set
    End Property

    Private _invertImage As InvertImage = InvertImage.None
    ''' <summary>
    ''' <para>Invert image is used to rotate the image around the X or Y axis.</para>
    ''' <para>Default: None</para>
    ''' </summary>
    Public Property InvertImage As InvertImage
        Get
            Return _invertImage
        End Get
        Set(value As InvertImage)
            _invertImage = value
        End Set
    End Property

    Private _noiseReduction As Boolean = False
    ''' <summary>
    ''' <para>Used to reduce the salt and pepper noise in an image.</para>
    ''' <para>False: No salt and pepper noise reduction (default)</para>
    ''' <para>True: Salt and pepper noise reduction</para>
    ''' </summary>
    Public Property NoiseReduction As Boolean
        Get
            Return _noiseReduction
        End Get
        Set(value As Boolean)
            _noiseReduction = value
        End Set
    End Property

    Private _imageRotate As ImageRotate = ImageRotate.r000
    ''' <summary>
    ''' <para>Used to rotate the image.</para>
    ''' <para>Default: r000</para>
    ''' </summary>
    Public Property ImageRotate As ImageRotate
        Get
            Return _imageRotate
        End Get
        Set(value As ImageRotate)
            _imageRotate = value
        End Set
    End Property

    Private _jpegImageQuality As Integer = 50
    ''' <summary>
    ''' <para>Sets the desired quality when the JPEG image format is selected. Higher numbers result in higher quality, but lager files.</para>
    ''' <para>Range: 0 - 100</para>
    ''' <para>Default: 50</para>
    ''' </summary>
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

    Private _gammaCorrection As Integer = 0
    ''' <summary>
    ''' <para>Gamma measures the brightness of midtone values produced by the iamge.</para>
    ''' <para>Range: 0 - 255</para>
    ''' <para>Default: 0</para>
    ''' </summary>
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

    Private _imageCroppingLeft As Integer = 0
    ''' <summary>
    ''' <para>Ships a window of the image by specifying the left pixel coordinates.</para>
    ''' <para>Range: 0 - 843</para>
    ''' <para>Default: 0</para>
    ''' </summary>
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

    Private _imageCroppingRight As Integer = 0
    ''' <summary>
    ''' <para>Ships a window of the image by specifying the right pixel coordinates.</para>
    ''' <para>Range: 0 - 843</para>
    ''' <para>Default: 0</para>
    ''' </summary>
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

    Private _imageCroppingTop As Integer = 0
    ''' <summary>
    ''' <para>Ships a window of the image by specifying the top pixel coordinates.</para>
    ''' <para>Range: 0 - 639</para>
    ''' <para>Default: 0</para>
    ''' </summary>
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

    Private _imageCroppingBottom As Integer = 0
    ''' <summary>
    ''' <para>Ships a window of the image by specifying the bottom pixel coordinates.</para>
    ''' <para>Range: 0 - 639</para>
    ''' <para>Default: 0</para>
    ''' </summary>
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

    Private _imageMargin As Integer = 0
    ''' <summary>
    ''' <para>Specify the number of pixels to cut from the ouside margin of the image.</para>
    ''' <para>Range: 0 - 238</para>
    ''' <para>Default: 0</para>
    ''' </summary>
    Public Property ImageMargin As Integer
        Get
            Return _imageMargin
        End Get
        Set(value As Integer)
            If value >= 0 And value <= 238 Then
                _imageMargin = value
            End If
        End Set
    End Property

    Private _protocol As Protocol = Protocol.NoneForUSB
    ''' <summary>
    ''' <para>Used for shipping an image.</para>
    ''' <para>Default: NoneForUSB</para>
    ''' </summary>
    Public Property Protocol As Protocol
        Get
            Return _protocol
        End Get
        Set(value As Protocol)
            _protocol = value
        End Set
    End Property

    Private _pixelShip As PixelShip = PixelShip.Ship1
    ''' <summary>
    ''' <para>Used for shipping an image.</para>
    ''' <para>Default: Ship1</para>
    ''' </summary>
    Public Property PixelShip As PixelShip
        Get
            Return _pixelShip
        End Get
        Set(value As PixelShip)
            _pixelShip = value
        End Set
    End Property

    Private _documentImageFilter As Integer = 0
    ''' <summary>
    ''' <para>Allows you to input parameters to sharpen the edges andd smooth the area between the edges of text in an image.</para>
    ''' <para>Range: 0 - 255</para>
    ''' <para>Default: 0</para>
    ''' </summary>
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

    Private _blurImage As Boolean = False
    ''' <summary>
    ''' <para>Smooths transitions by averaging the pixels next to the hard edges of defined lines and shaded areas in a image.</para>
    ''' <para>False: Don't blur (default)</para>
    ''' <para>True: Blur</para>
    ''' </summary>
    Public Property BlurImage As Boolean
        Get
            Return _blurImage
        End Get
        Set(value As Boolean)
            _blurImage = value
        End Set
    End Property

    Private _histogramShip As Boolean = False
    ''' <summary>
    ''' <para>histogram gives a quick picture of the tonal range of an image, or key type.</para>
    ''' <para>False: Don't ship histogram (default)</para>
    ''' <para>True: Ship histogram</para>
    ''' </summary>
    Public Property HistogramShip As Boolean
        Get
            Return _histogramShip
        End Get
        Set(value As Boolean)
            _histogramShip = value
        End Set
    End Property

End Class
