﻿Imports Nukepayload2.Ra2CodeAnalysis
Imports 红警杀.核心
Public Interface ISettingReadWriter
    Function ReadAllText() As Task(Of String)
    Function WriteAllText(Text As String) As Task
End Interface
Public Class 设置管理器(Of 图像类型, 鼠标光标, 用户控件类型)
    Implements I设置管理器

    Dim Analizer As INIAnalizer
    Const GeneralSetting As String = "General"
    Dim SettingReadWriter As ISettingReadWriter
    Sub New(ReadWriter As ISettingReadWriter)
        Analizer = New INIAnalizer(ReadWriter.ReadAllText.Result)
        Me.SettingReadWriter = ReadWriter
        If Not Analizer.Values.ContainsKey(GeneralSetting) Then
            Analizer.Values.Add(GeneralSetting, New Dictionary(Of String, Tuple(Of String, Integer)))
        End If
        For Each t In Me.GetType.GetProperties
            If Not Analizer.Values(GeneralSetting).ContainsKey(t.Name) Then
                Analizer.Values(GeneralSetting).Add(t.Name, New Tuple(Of String, Integer)(String.Empty, 0))
            End If
        Next
    End Sub
    Private Sub SetGeneralValue(Of T)(Value As T, Key As String)
        Analizer.Values(GeneralSetting)(Key) = New Tuple(Of String, Integer)(CStr(CObj(Value)), 0)
    End Sub
    Private Function GetGeneralValue(Of T As New)(Key As String) As T
        Dim s = Analizer.Values(GeneralSetting)(Key).Item1
        If String.IsNullOrEmpty(s) Then
            s = (New T).ToString
            SetGeneralValue(s, Key)
        End If
        Return CType(CObj(s), T)
    End Function
    Private Function GetGeneralValue(Key As String) As String
        Return Analizer.Values(GeneralSetting)(Key).Item1
    End Function
    Public Property 人类玩家出牌超时 As TimeSpan Implements I设置管理器.人类玩家出牌超时
        Get
            Return TimeSpan.FromMilliseconds(GetGeneralValue(Of Double)("人类玩家出牌超时"))
        End Get
        Set(value As TimeSpan)
            SetGeneralValue(value.TotalMilliseconds, "人类玩家出牌超时")
        End Set
    End Property

    Public Property 允许红警Mod卡牌 As Boolean Implements I设置管理器.允许红警Mod卡牌
        Get
            Return GetGeneralValue(Of Boolean)("允许红警Mod卡牌")
        End Get
        Set(value As Boolean)
            SetGeneralValue(value, "允许红警Mod卡牌")
        End Set
    End Property

    Public Property 在盟友附近进攻 As Boolean Implements I设置管理器.在盟友附近进攻
        Get
            Return GetGeneralValue(Of Boolean)("在盟友附近进攻")
        End Get
        Set(value As Boolean)
            SetGeneralValue(value, "在盟友附近进攻")
        End Set
    End Property

    Public Property 多位工程师 As Boolean Implements I设置管理器.多位工程师
        Get
            Return GetGeneralValue(Of Boolean)("多位工程师")
        End Get
        Set(value As Boolean)
            SetGeneralValue(value, "多位工程师")
        End Set
    End Property

    Public Property 每回合获取手牌数 As Integer Implements I设置管理器.每回合获取手牌数
        Get
            Return GetGeneralValue(Of Integer)("每回合获取手牌数")
        End Get
        Set(value As Integer)
            SetGeneralValue(value, "每回合获取手牌数")
        End Set
    End Property

    Public Property 离子风暴 As Boolean Implements I设置管理器.离子风暴
        Get
            Return GetGeneralValue(Of Boolean)("离子风暴")
        End Get
        Set(value As Boolean)
            SetGeneralValue(value, "离子风暴")
        End Set
    End Property

    Public Property 科技等级上限 As Integer Implements I设置管理器.科技等级上限
        Get
            Return GetGeneralValue(Of Integer)("科技等级上限")
        End Get
        Set(value As Integer)
            SetGeneralValue(value, "科技等级上限")
        End Set
    End Property

    Public Property 超级武器 As Boolean Implements I设置管理器.超级武器
        Get
            Return GetGeneralValue(Of Boolean)("超级武器")
        End Get
        Set(value As Boolean)
            SetGeneralValue(value, "超级武器")
        End Set
    End Property

    Public Property 随机宝箱 As Boolean Implements I设置管理器.随机宝箱
        Get
            Return GetGeneralValue(Of Boolean)("随机宝箱")
        End Get
        Set(value As Boolean)
            SetGeneralValue(value, "随机宝箱")
        End Set
    End Property

    Public Async Function 保存设置() As Task Implements I设置管理器.保存设置
        Await SettingReadWriter.WriteAllText(Analizer.ToString)
    End Function

    Public Async Function 读取设置() As Task Implements I设置管理器.读取设置
        If Analizer Is Nothing Then
            Analizer = New INIAnalizer(Await SettingReadWriter.ReadAllText)
        Else
            Analizer.Reload(Await SettingReadWriter.ReadAllText)
        End If
    End Function
End Class
