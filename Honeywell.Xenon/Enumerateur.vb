Public Module Enumerateur

    Public Enum Style
        ''' <summary>
        ''' This processing allows a few frames to be taken until the exposure parameters are met. The last frame is the, available for further use.
        ''' </summary>
        DecodingStyle = 0
        ''' <summary>
        ''' Thismimics a simple digital camera, and result in a visually optimized image.
        ''' </summary>
        PhotoStyle = 1
        ''' <summary>
        ''' This is an advanced style that should only be used by an experienced user. It allows you th most freedom to set up the scanner, and has no auto-exposure.
        ''' </summary>
        ManualStyle = 2
    End Enum

    Public Enum Gain
        NoGain = 1
        MediumGain = 2
        HeavyGain = 4
        MaximunGain = 8
    End Enum

    Public Enum PixelDepth
        ''' <summary>
        ''' 8 bits per pixel, grayscale image
        ''' </summary>
        Grayscale = 8
        ''' <summary>
        ''' 1 bits per pixel, black and white image
        ''' </summary>
        BlackAndWhite = 1
    End Enum

    Public Enum FileFormat
        ''' <summary>
        ''' KIM format
        ''' </summary>
        KIM = 0
        ''' <summary>
        ''' TIFF binary
        ''' </summary>
        TIFF = 1
        ''' <summary>
        ''' TIFF binary group 4, compressed
        ''' </summary>
        TIFF_Compressed = 2
        ''' <summary>
        ''' TIFF grayscale
        ''' </summary>
        TIFF_Grayscale = 3
        ''' <summary>
        ''' Uncompressed binary (upper left to lower right, 1 pixel/bit, 0 padded end of line)
        ''' </summary>
        UncompressedBinary = 4
        ''' <summary>
        ''' Uncompressed grayscale (upper left to lower right, bitmap format)
        ''' </summary>
        UncompressedGrayscale = 5
        ''' <summary>
        ''' JPEG image
        ''' </summary>
        JPEG = 6
        ''' <summary>
        ''' BMP image (lower right to upper left, uncompressed)
        ''' </summary>
        BMP = 8
        ''' <summary>
        ''' TIFF color compressed image
        ''' </summary>
        TIFF_ColorCompressed = 10
        ''' <summary>
        ''' TIFF color uncompressed image
        ''' </summary>
        TIFF_ColorUncompressed = 11
        ''' <summary>
        ''' JPEG color image
        ''' </summary>
        JPEG_Color = 12
        ''' <summary>
        ''' BMP color image
        ''' </summary>
        BMP_Color = 14
        ''' <summary>
        ''' BMP uncompressed raw image
        ''' </summary>
        BMP_Uncompressed = 15
    End Enum

    Public Enum InvertImage
        None = -1
        ''' <summary>
        ''' Invert around the X axis (flips picture upside to down)
        ''' </summary>
        X = 0
        ''' <summary>
        ''' Invert around the Y axis (flips picture left to right)
        ''' </summary>
        Y = 1
    End Enum

    Public Enum ImageRotate
        ''' <summary>
        ''' Image as snapped (rightside up)
        ''' </summary>
        r000 = 0
        ''' <summary>
        ''' Rotate image 90 degrees to the right
        ''' </summary>
        r090 = 1
        ''' <summary>
        ''' Rotate image 180 degrees (upside down)
        ''' </summary>
        r180 = 2
        ''' <summary>
        ''' Rotate image 90 degrees to the left
        ''' </summary>
        r260 = 3
    End Enum

    Public Enum Protocol
        ''' <summary>
        ''' None (raw data)
        ''' </summary>
        None = 0
        ''' <summary>
        ''' None (default for USB)
        ''' </summary>
        NoneForUSB = 2
        ''' <summary>
        ''' Hmodem compressed (default for RS232)
        ''' </summary>
        HmodemCompressed = 3
        ''' <summary>
        ''' Hmodem
        ''' </summary>
        Hmodem = 4
    End Enum

    Public Enum PixelShip
        ''' <summary>
        ''' Ship every pixel
        ''' </summary>
        Ship1 = 1
        ''' <summary>
        ''' Ship every 2nd pixel, both horizontally and vertically
        ''' </summary>
        Ship2 = 2
        ''' <summary>
        ''' Ship every 3nd pixel, both horizontally and vertically
        ''' </summary>
        Ship3 = 3
    End Enum
End Module
