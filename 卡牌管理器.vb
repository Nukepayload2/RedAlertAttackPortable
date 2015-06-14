Imports 红警杀.核心
Imports 红警杀.资源
Imports System.Reflection
Namespace 基元
    Public MustInherit Class 卡牌管理器(Of 图像类型, 鼠标光标, 用户控件类型)
        Implements I卡牌管理器(Of 图像类型, 鼠标光标, 用户控件类型)
        Protected MustOverride Function CreateCardFromCardInfo(CardInfo As I手牌(Of 图像类型, 鼠标光标, 用户控件类型)) As I手牌控件(Of 图像类型, 鼠标光标, 用户控件类型)
        Protected MustOverride Function GetValidAssemblyFromDirectory(Directory As String) As IEnumerable(Of Assembly)
        Protected Sub SetCardTypesFromAssemblyDirectory(Directory As String)
            For Each mem In GetValidAssemblyFromDirectory(Directory)
                For Each tp In mem.GetTypes
                    Dim o = tp.GetDefaultObject
                    If TypeOf o Is I手牌(Of 图像类型, 鼠标光标, 用户控件类型) Then
                        m_可用手牌.Add(CreateCardFromCardInfo(DirectCast(o, I手牌(Of 图像类型, 鼠标光标, 用户控件类型))))
                    End If
                    If TypeOf o Is I手牌控件(Of 图像类型, 鼠标光标, 用户控件类型) Then
                        m_可用手牌.Add(DirectCast(o, I手牌控件(Of 图像类型, 鼠标光标, 用户控件类型)))
                    End If
                Next
            Next
        End Sub
        Sub New()
            SetCardTypesFromAssemblyDirectory(拓展目录)
        End Sub
        Dim m_可用手牌 As New List(Of I手牌控件(Of 图像类型, 鼠标光标, 用户控件类型))
        Public ReadOnly Property 可用手牌 As IList(Of I手牌控件(Of 图像类型, 鼠标光标, 用户控件类型)) Implements I卡牌管理器(Of 图像类型, 鼠标光标, 用户控件类型).可用手牌
            Get
                Return m_可用手牌
            End Get
        End Property

        Public Function 新建手牌(卡牌 As I手牌(Of 图像类型, 鼠标光标, 用户控件类型)) As I手牌控件(Of 图像类型, 鼠标光标, 用户控件类型) Implements I卡牌管理器(Of 图像类型, 鼠标光标, 用户控件类型).新建手牌
            Throw New NotImplementedException()
        End Function

        Public Function 随机手牌() As I手牌控件(Of 图像类型, 鼠标光标, 用户控件类型) Implements I卡牌管理器(Of 图像类型, 鼠标光标, 用户控件类型).随机手牌
            Throw New NotImplementedException()
        End Function
    End Class

End Namespace
