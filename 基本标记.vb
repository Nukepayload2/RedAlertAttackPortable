
Imports 红警杀.基元
Imports 红警杀.核心
Namespace 基元
    Public MustInherit Class 标记Base(Of 图像类型, 鼠标光标, 用户控件类型)
        Implements I标记(Of 图像类型, 鼠标光标, 用户控件类型)

        Public Property 数量 As Integer = 1 Implements I标记(Of 图像类型, 鼠标光标, 用户控件类型).数量

        Public ReadOnly Property 特技表 As IList(Of I标记特技(Of 图像类型, 鼠标光标, 用户控件类型)) =
            New List(Of I标记特技(Of 图像类型, 鼠标光标, 用户控件类型)) Implements I标记(Of 图像类型, 鼠标光标, 用户控件类型).特技表
        Sub New()

        End Sub
        Sub New(特技 As IEnumerable(Of I标记特技(Of 图像类型, 鼠标光标, 用户控件类型)))
            For Each tj In 特技
                tj.拥有者 = Me
                特技表.Add(tj)
            Next
        End Sub
    End Class
End Namespace
Namespace 基本标记
    Public Class 力场护盾(Of 图像类型, 鼠标光标, 用户控件类型)
        Inherits 标记Base(Of 图像类型, 鼠标光标, 用户控件类型)
        Sub New()
            MyBase.New({New 力场特技(Of 图像类型, 鼠标光标, 用户控件类型)})
        End Sub
    End Class
    Public Class 核弹读秒(Of 图像类型, 鼠标光标, 用户控件类型)
        Inherits 标记Base(Of 图像类型, 鼠标光标, 用户控件类型)
        Sub New()
            MyBase.New({New 核弹读秒特技(Of 图像类型, 鼠标光标, 用户控件类型)})
        End Sub
    End Class
    Public Class 核弹发射(Of 图像类型, 鼠标光标, 用户控件类型)
        Inherits 标记Base(Of 图像类型, 鼠标光标, 用户控件类型)
        Sub New()
            MyBase.New({New 核弹特技(Of 图像类型, 鼠标光标, 用户控件类型)})
        End Sub
    End Class
    Public Class 闪电读秒(Of 图像类型, 鼠标光标, 用户控件类型)
        Inherits 标记Base(Of 图像类型, 鼠标光标, 用户控件类型)
        Sub New()
            MyBase.New({New 闪电读秒特技(Of 图像类型, 鼠标光标, 用户控件类型)})
        End Sub
    End Class
    Public Class 闪电发射(Of 图像类型, 鼠标光标, 用户控件类型)
        Inherits 标记Base(Of 图像类型, 鼠标光标, 用户控件类型)
        Sub New()
            MyBase.New({New 闪电特技(Of 图像类型, 鼠标光标, 用户控件类型)})
        End Sub
    End Class
    Public Class 精神控制读秒(Of 图像类型, 鼠标光标, 用户控件类型)
        Inherits 标记Base(Of 图像类型, 鼠标光标, 用户控件类型)
        Sub New()
            MyBase.New({New 精神控制读秒特技(Of 图像类型, 鼠标光标, 用户控件类型)})
        End Sub
    End Class
    Public Class 精神控制发射(Of 图像类型, 鼠标光标, 用户控件类型)
        Inherits 标记Base(Of 图像类型, 鼠标光标, 用户控件类型)
        Sub New(源玩家 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型))
            MyBase.New({New 精神控制特技(Of 图像类型, 鼠标光标, 用户控件类型)(源玩家)})
        End Sub
    End Class
End Namespace
