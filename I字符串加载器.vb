Namespace 资源
    Public Interface I字符串加载器
        Property CurrentLanguage As String
        ReadOnly Property Languages As List(Of String)
        Function GetString(Name As String) As String
    End Interface
End Namespace
