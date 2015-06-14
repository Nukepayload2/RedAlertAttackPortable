
Imports 红警杀.核心

Namespace 资源
    Public Module Constants
        Public Const 音效目录 As String = "SE\"
        Public Const 背景音乐目录 As String = "BGM\"
        Public Const 图片目录 As String = "Images\"
        Public Const 拓展目录 As String = "Extensions\"
    End Module
    Public MustInherit Class 资源加载器
        Public StreamCache As New Dictionary(Of String, Stream)
        MustOverride Function GetStreamFromFile(path As String) As Stream

        ''' <summary>
        ''' 加载到缓存中。Key 名称，Value 路径
        ''' </summary> 
        Public Sub LoadFilesToStreamCache(ParamArray Name_Path() As KeyValuePair(Of String, String))
            For Each s In Name_Path
                If Not StreamCache.ContainsKey(s.Key) Then
                    StreamCache.Add(s.Key, GetStreamFromFile(s.Value))
                End If
            Next
        End Sub
    End Class
    Public MustInherit Class 图像资源加载器(Of 图像类型)
        Inherits 资源加载器
        Enum PixelFormats
            ''' <summary>
            ''' 红警杀专用。压缩的黑白像素格式。
            ''' </summary>
            Raa1bppRes
            ''' <summary>
            ''' 只有黑色和白色
            ''' </summary>
            Black1bpp
            ''' <summary>
            ''' 它可显示每像素 8 位的灰度通道，允许使用 256 种灰色底纹。 
            ''' </summary>
            Gray8
            ''' <summary>
            ''' 具有 24 每像素位数 (BPP) 的 sRGB 格式。 每个通道（蓝色、绿色、红色）都分配了 8 每像素位数 (BPP)
            ''' </summary>
            Rgb24
            ''' <summary>
            ''' 具有 32 每像素位数 (BPP) 的 sRGB 格式。 每个通道（蓝色、绿色、红色和 alpha 通道）都分配了 8 每像素位数 (BPP)
            ''' </summary>
            Argb32
            ''' <summary>
            ''' WPF大多数情况下默认的像素格式,具有 32 每像素位数 (BPP) 的 sRGB 格式。 每个通道（蓝色、绿色、红色和 alpha 通道）都分配了 8 每像素位数 (BPP)。 每个颜色通道都预先乘以 alpha 值。
            ''' </summary>
            Pbgra32
        End Enum
        Public MustOverride Function PngStreamToImage(strm As Stream) As 图像类型

    End Class
    Public MustInherit Class 声音播放器(Of 图像类型, 鼠标光标, 用户控件类型)
        Inherits 资源加载器
        Implements I声音播放器
        Protected BGMNames As List(Of String)
        Protected PlayIndex As Integer
        Public ReadOnly Property 背景音乐 As IEnumerable(Of Stream) Implements I声音播放器.背景音乐
            Get
                Return From s In BGMNames Select StreamCache(s)
            End Get
        End Property
        Public Sub 增加背景音乐(Name As String, Path As String)
            LoadFilesToStreamCache(New KeyValuePair(Of String, String)(Name, Path))
            BGMNames.Add(Name)
        End Sub
        Public Sub 下一首() Implements I声音播放器.下一首
            PlayIndex = If(PlayIndex >= BGMNames.Count - 1, 0, PlayIndex + 1)
            播放背景音乐()
        End Sub
        Public MustOverride Sub 播放背景音乐() Implements I声音播放器.播放背景音乐
        Public MustOverride Function 播放音效(声音 As Stream) As Task Implements I声音播放器.播放音效
        Public MustOverride Sub 暂停背景音乐() Implements I声音播放器.暂停背景音乐
        Public MustOverride Sub 继续背景音乐() Implements I声音播放器.继续背景音乐

    End Class
End Namespace

