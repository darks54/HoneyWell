Public Class IMGSNP

    Private _style As Style = Style.PhotoStyle
    ''' <summary>
    ''' <para>This get or set the image Snap style.</para>
    ''' <para>Default: PhotoStyle</para>
    ''' </summary>
    Public Property Style As Style
        Get
            Return _style
        End Get
        Set(value As Style)
            _style = value
        End Set
    End Property

    Private _beeper As Boolean = False
    ''' <summary>
    ''' <para>Causes a beep to sound after an image is snapped.</para>
    ''' <para>False: No beep (default)</para>
    ''' <para>True: Sound a beep when the image is captured</para>
    ''' </summary>
    Public Property Beeper As Boolean
        Get
            Return _beeper
        End Get
        Set(value As Boolean)
            _beeper = value
        End Set
    End Property

    Private _waitForTrigger As Boolean = False
    ''' <summary>
    ''' <para>Waits for a hardware button push before taking the image. This is only available when using Photo Style.</para>
    ''' <para>False: Take image immediately (default)</para>
    ''' <para>True: Waits for a butoon push, then takes the image</para>
    ''' </summary>
    Public Property WaitForTrigger As Boolean
        Get
            Return _waitForTrigger
        End Get
        Set(value As Boolean)
            _waitForTrigger = value
        End Set
    End Property

    Private _ledState As Boolean
    ''' <summary>
    ''' <para>Determines if the LEDs should be on or off, and when. LED State is not available when using Decoding Style.</para>
    ''' <para>False: LEDs off (default)</para>
    ''' <para>True: LEDs on</para>
    ''' </summary>
    Public Property LedState As Boolean
        Get
            Return _ledState
        End Get
        Set(value As Boolean)
            _ledState = value
        End Set
    End Property

    Private _exposure As Integer = 7874
    ''' <summary>
    ''' <para>Exposure is used in Manual Style only, and allows you to set the exposure time. Units are 172 microseconds.</para>
    ''' <para>Range: 1 - 7874</para>
    ''' <para>Default: 7874</para>
    ''' </summary>
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

    Private _gain As Gain = Gain.NoGain
    ''' <summary>
    ''' <para>Gain is used in Manual Style only.</para>
    ''' <para>Default: NoGain</para>
    ''' </summary>
    Public Property Gain As Gain
        Get
            Return _gain
        End Get
        Set(value As Gain)
            _gain = value
        End Set
    End Property

    Private _targetWhiteValue As Integer = 125
    ''' <summary>
    ''' <para>Sets the target for the median grayscale value in the captured image.</para>
    ''' <para>Range: 0 - 255</para>
    ''' <para>Default: 125</para>
    ''' </summary>
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

    Private _deltaForAcceptance As Integer = 25
    ''' <summary>
    ''' <para>This sets the allowable range for the white value setting. Delta is only available when using Photo Style.</para>
    ''' <para>Range: 0 - 255</para>
    ''' <para>Default: 25</para>
    ''' </summary>
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
    ''' <summary>
    ''' <para>This sets the maximum number of frames the scanner should take to reach the Delta for Acceptance. Update Tries is only available when using Photo Style.</para>
    ''' <para>Range: 0 - 10</para>
    ''' <para>Default: 6</para>
    ''' </summary>
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

    Private _targetSetPointPercentage As Integer = 50
    ''' <summary>
    ''' Sets the target point for the light and dark values in the captured image.
    ''' <para>Range: 1 - 99</para>
    ''' <para>Default: 50</para>
    ''' </summary>
    ''' <returns></returns>
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

End Class