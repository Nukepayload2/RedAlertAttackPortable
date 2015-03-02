Imports 红警杀.基元
Imports 红警杀.核心
Namespace 基元
    Public MustInherit Class 基本标记特技(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型)
        Inherits 特效Base(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型)
        Implements 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I标记特技
        Sub New()

        End Sub
        Public Property 拥有者 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I标记 Implements 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I标记特技.拥有者
        Sub New(owner As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I标记)
            拥有者 = owner
        End Sub
        Public MustOverride Sub 减少(游戏 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I游戏, 玩家 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I玩家) Implements 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I标记特技.减少

        Public MustOverride Sub 增加(游戏 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I游戏, 玩家 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I玩家) Implements 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I标记特技.增加

    End Class
End Namespace
Public Class 力场特技(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型)
    Inherits 基本标记特技(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型)

    Sub New()
        MyBase.New()
    End Sub
    Public Overrides ReadOnly Property 说明 As String
        Get
            Return "受到力场保护的玩家能抵挡一次伤害,但是本回合电力下降2个"
        End Get
    End Property
    Public Overrides Sub 回合增加(游戏 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I游戏)
        MyBase.回合增加(游戏)
        If 拥有者 Is Nothing Then
            Throw New InvalidOperationException("拥有者还没设定")
        End If
        If 拥有者.数量 >= 1 Then 拥有者.数量 -= 1
    End Sub

    Public Overrides Function 生命值改变(游戏 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I游戏, 玩家 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I玩家, 来源 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I玩家, 新的生命值 As Integer) As Boolean
        If 玩家.生命值(游戏, 玩家) > 新的生命值 Then
            If 拥有者 Is Nothing Then
                Throw New InvalidOperationException("拥有者还没设定")
            End If
            If 拥有者.数量 >= 1 Then
                拥有者.数量 -= 1
                Return False
            End If
        End If
        Return True
    End Function
    Public Overrides Sub 减少(游戏 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I游戏, 玩家 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I玩家)
        玩家.电力(游戏, 玩家) += 2
    End Sub

    Public Overrides Sub 增加(游戏 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I游戏, 玩家 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I玩家)
        玩家.电力(游戏, 玩家) -= 2
    End Sub
End Class