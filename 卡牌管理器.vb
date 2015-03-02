Imports 红警杀.核心
Imports 红警杀.资源
Imports System.Reflection
Namespace 基元
    Public MustInherit Class 卡牌管理器(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型)
        Implements 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I卡牌管理器
        Protected MustOverride Function CreateCardFromCardInfo(CardInfo As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I手牌) As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I手牌控件
        Protected MustOverride Function GetValidAssemblyFromDirectory(Directory As String) As IEnumerable(Of Assembly)
        Protected Sub SetCardTypesFromAssemblyDirectory(Directory As String)
            For Each mem In GetValidAssemblyFromDirectory(Directory)
                For Each tp In mem.GetTypes
                    Dim o = tp.GetDefaultObject
                    If TypeOf o Is 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I手牌 Then
                        m_可用手牌.Add(CreateCardFromCardInfo(DirectCast(o, 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I手牌)))
                    End If
                    If TypeOf o Is 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I手牌控件 Then
                        m_可用手牌.Add(DirectCast(o, 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I手牌控件))
                    End If
                Next
            Next
        End Sub
        Sub New()
            SetCardTypesFromAssemblyDirectory(拓展目录)
        End Sub
        Dim m_可用手牌 As New List(Of 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I手牌控件)
        Public ReadOnly Property 可用手牌 As IList(Of 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I手牌控件) Implements 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I卡牌管理器.可用手牌
            Get
                Return m_可用手牌
            End Get
        End Property

        Public Function 新建手牌(卡牌 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I手牌控件) As 用户控件类型 Implements 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I卡牌管理器.新建手牌
            Throw New NotImplementedException()
        End Function

        Public Function 随机手牌() As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I手牌控件 Implements 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I卡牌管理器.随机手牌
            Throw New NotImplementedException()
        End Function
    End Class

End Namespace
