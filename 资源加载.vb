
Namespace 资源
    Module Constants
        Public 音效目录 As String = "SE\"
        Public 背景音乐目录 As String = "BGM\"
        Public 图片目录 As String = "Images\"
        Public 拓展目录 As String = "Extensions\"
    End Module
    Public MustInherit Class 资源加载器
        Public StreamCache As New Dictionary(Of String, Stream)
        MustOverride Sub LoadRegisteredStreamToStreamCache()
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
        Enum PixelFormats
            Raa1bppRes
            Black1bpp
            Gray256
            Rgb24
            Argb32
        End Enum
        Public MustOverride Function PngStreamToImage(strm As Stream) As 图像类型
        Public MustOverride Function FileToImage(path As String) As 图像类型
        Public MustOverride Function ToImage(Data As Byte(), PixelFormat As PixelFormats) As 图像类型
        Public MustOverride Function PngToImage(PngData As Byte()) As 图像类型

    End Class
End Namespace

