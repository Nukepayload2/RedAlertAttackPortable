
Imports 红警杀.基元
Imports 红警杀.核心
Namespace 基元
    Public Class 标记Base(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型)
        Implements 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I标记

        Public Property 数量 As Integer = 1 Implements 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I标记.数量

        Public ReadOnly Property 特技表 As IList(Of 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I标记特技) =
            New List(Of 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I标记特技) Implements 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I标记.特技表
        Sub New()

        End Sub
        Sub New(特技 As IEnumerable(Of 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I标记特技))
            For Each tj In 特技
                tj.拥有者 = Me
                特技表.Add(tj)
            Next
        End Sub
    End Class
End Namespace
Namespace 基本标记
    Public Class 力场护盾(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型)
        Inherits 标记Base(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型)
        Sub New()
            MyBase.New({New 力场特技(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型)})
        End Sub
    End Class
    Public Class 核弹读秒(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型)
        Inherits 标记Base(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型)
        Sub New()
            MyBase.New({New 核弹读秒特技(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型)})
        End Sub
    End Class
    Public Class 核弹发射(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型)
        Inherits 标记Base(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型)
        Sub New()
            MyBase.New({New 核弹特技(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型)})
        End Sub
    End Class
End Namespace
