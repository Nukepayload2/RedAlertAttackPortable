Namespace 资源
    Public Interface I资源加载器
        Sub LoadFilesToStreamCache(ParamArray Name_Path() As KeyValuePair(Of String, String))
        Function GetStreamFromFile(path As String) As Stream
    End Interface
End Namespace
