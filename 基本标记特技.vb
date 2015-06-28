
Imports 红警杀.基元
Imports 红警杀.基本手牌
Imports 红警杀.核心
Namespace 基元
    Public MustInherit Class 基本标记特技(Of 图像类型, 鼠标光标, 用户控件类型)
        Inherits 特效Base(Of 图像类型, 鼠标光标, 用户控件类型)
        Implements I标记特技(Of 图像类型, 鼠标光标, 用户控件类型)
        Sub New()

        End Sub
        Public Property 拥有者 As I标记(Of 图像类型, 鼠标光标, 用户控件类型) Implements I标记特技(Of 图像类型, 鼠标光标, 用户控件类型).拥有者
        Sub New(owner As I标记(Of 图像类型, 鼠标光标, 用户控件类型))
            拥有者 = owner
        End Sub
        Public MustOverride Async Function 减少(玩家 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型)) As Task Implements I标记特技(Of 图像类型, 鼠标光标, 用户控件类型).减少

        Public MustOverride Async Function 增加(玩家 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型)) As Task Implements I标记特技(Of 图像类型, 鼠标光标, 用户控件类型).增加

    End Class
End Namespace
Public Class 力场特技(Of 图像类型, 鼠标光标, 用户控件类型)
    Inherits 基本标记特技(Of 图像类型, 鼠标光标, 用户控件类型)

    Sub New()
        MyBase.New()
    End Sub
    Public Overrides ReadOnly Property 说明 As String
        Get
            Return "受到力场保护的玩家能抵挡一次伤害,但是本回合电力下降2个"
        End Get
    End Property
    Public Overrides Async Function 回合增加() As Task
        Await MyBase.回合增加()
        If 拥有者 Is Nothing Then
            Throw New InvalidOperationException("拥有者还没设定")
        End If
        If 拥有者.数量 >= 1 Then 拥有者.数量 -= 1
    End Function

    Public Overrides Async Function 生命值改变(玩家 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型), 来源 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型), 新的生命值 As Integer) As Task(Of Boolean)
        If 玩家.生命值(玩家) > 新的生命值 Then
            If 拥有者 Is Nothing Then
                Throw New InvalidOperationException("拥有者还没设定")
            End If
            If 拥有者.数量 >= 1 Then
                拥有者.数量 -= 1
                Return False
            End If
        End If
        Await DoNothingTask()
        Return True
    End Function
    Public Overrides Async Function 减少(玩家 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型)) As Task
        玩家.电力(玩家) += 2
        Await DoNothingTask()
    End Function

    Public Overrides Async Function 增加(玩家 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型)) As Task
        玩家.电力(玩家) -= 2
        Await DoNothingTask()
    End Function
End Class

Public Class 核弹读秒特技(Of 图像类型, 鼠标光标, 用户控件类型)
    Inherits 基本标记特技(Of 图像类型, 鼠标光标, 用户控件类型)

    Public Overrides ReadOnly Property 说明 As String = "每5的倍数回合将一枚核弹准备好"
    Dim Round As Integer = 1
    Public Overrides Async Function 回合增加() As Task
        Await MyBase.回合增加()
        If Round Mod 5 = 0 Then
            Await 玩家.得到手牌(游戏(Of 图像类型, 鼠标光标, 用户控件类型).当前.卡牌管理器.新建手牌(New 核弹攻击(Of 图像类型, 鼠标光标, 用户控件类型)))
        End If
        Round += 1
    End Function
    Public Overrides Async Function 减少(玩家 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型)) As Task
        Await DoNothingTask()
    End Function
    Dim 玩家 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型)
    Public Overrides Async Function 增加(玩家 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型)) As Task
        Me.玩家 = 玩家
        Await DoNothingTask()
    End Function
End Class
Public Class 核弹特技(Of 图像类型, 鼠标光标, 用户控件类型)
    Inherits 基本标记特技(Of 图像类型, 鼠标光标, 用户控件类型)

    Public Overrides ReadOnly Property 说明 As String = "引发核弹爆炸和伤害效果"

    Public Overrides Async Function 减少(玩家 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型)) As Task

        玩家.生命值(玩家) = 玩家.生命值(玩家) \ 2
        For i As Integer = 1 To 3
            Dim Card = 游戏(Of 图像类型, 鼠标光标, 用户控件类型).当前.卡牌管理器.随机手牌
            游戏(Of 图像类型, 鼠标光标, 用户控件类型).当前.窗体.判定区.Add(Card)
            If Card.特性.是黑牌 Then
                Await 玩家.随机失去手牌(1)
            End If
            Await TaskEx.Delay(游戏(Of 图像类型, 鼠标光标, 用户控件类型).当前.设置.人类玩家出牌超时)
        Next
    End Function

    Public Overrides Async Function 增加(玩家 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型)) As Task
        Await DoNothingTask()
    End Function
End Class


Public Class 闪电读秒特技(Of 图像类型, 鼠标光标, 用户控件类型)
    Inherits 基本标记特技(Of 图像类型, 鼠标光标, 用户控件类型)

    Public Overrides ReadOnly Property 说明 As String = "每5的倍数回合将闪电风暴准备好"
    Dim Round As Integer = 1
    Public Overrides Async Function 回合增加() As Task
        Await MyBase.回合增加()
        If Round Mod 5 = 0 Then
            Await 玩家.得到手牌(游戏(Of 图像类型, 鼠标光标, 用户控件类型).当前.卡牌管理器.新建手牌(New 闪电风暴(Of 图像类型, 鼠标光标, 用户控件类型)))
        End If
        Round += 1
    End Function

    Dim 玩家 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型)
    Public Overrides Async Function 增加(玩家 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型)) As Task
        Me.玩家 = 玩家
        Await DoNothingTask()
    End Function

    Public Overrides Async Function 减少(玩家 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型)) As Task
        Await DoNothingTask()
    End Function
End Class
Public Class 闪电特技(Of 图像类型, 鼠标光标, 用户控件类型)
    Inherits 基本标记特技(Of 图像类型, 鼠标光标, 用户控件类型)

    Public Overrides ReadOnly Property 说明 As String = "引发闪电风暴效果"

    Public Overrides Async Function 减少(玩家 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型)) As Task
        For i As Integer = 1 To 8
            Dim Card = 游戏(Of 图像类型, 鼠标光标, 用户控件类型).当前.卡牌管理器.随机手牌
            游戏(Of 图像类型, 鼠标光标, 用户控件类型).当前.窗体.判定区.Add(Card)
            If Card.特性.花色和点数.花色 = 花色枚举.黑桃 Then
                Dim d = CInt(Card.特性.花色和点数.点数)
                If d >= 2 AndAlso d <= 9 Then
                    玩家.生命值(玩家) -= 2
                End If
            End If
            Await TaskEx.Delay(游戏(Of 图像类型, 鼠标光标, 用户控件类型).当前.设置.人类玩家出牌超时)
        Next
    End Function

    Public Overrides Async Function 增加(玩家 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型)) As Task
        Await DoNothingTask()
    End Function
End Class


Public Class 精神控制读秒特技(Of 图像类型, 鼠标光标, 用户控件类型)
    Inherits 基本标记特技(Of 图像类型, 鼠标光标, 用户控件类型)

    Public Overrides ReadOnly Property 说明 As String = "每5的倍数回合将心灵激荡准备好"
    Dim Round As Integer = 1
    Public Overrides Async Function 回合增加() As Task
        Await MyBase.回合增加()
        If Round Mod 5 = 0 Then
            Await 玩家.得到手牌(游戏(Of 图像类型, 鼠标光标, 用户控件类型).当前.卡牌管理器.新建手牌(New 心灵激荡(Of 图像类型, 鼠标光标, 用户控件类型)))
        End If
        Round += 1
    End Function
    Public Overrides Async Function 减少(玩家 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型)) As Task
        Await DoNothingTask()
    End Function
    Dim 玩家 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型)
    Public Overrides Async Function 增加(玩家 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型)) As Task
        Me.玩家 = 玩家
        Await DoNothingTask()
    End Function
End Class
Public Class 精神控制特技(Of 图像类型, 鼠标光标, 用户控件类型)
    Inherits 基本标记特技(Of 图像类型, 鼠标光标, 用户控件类型)
    Sub New(源玩家 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型))
        MyBase.New
        Me.源玩家 = 源玩家
    End Sub
    Public Overrides ReadOnly Property 说明 As String = "引发爆炸和精神控制"
    Public 源玩家 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型)
    Public Overrides Async Function 减少(玩家 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型)) As Task
        Dim Loss As Integer = 0
        For i As Integer = 玩家.全部手牌.Count To 0 Step -1
            If Loss >= 2 Then Exit For
            Dim card = Await 玩家.随机失去手牌(1)
            If card Is Nothing Then
                Exit For
            Else
                Loss += 1
                Await 源玩家.得到手牌(card)
            End If
        Next
    End Function

    Public Overrides Async Function 增加(玩家 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型)) As Task
        Await DoNothingTask()
    End Function
End Class