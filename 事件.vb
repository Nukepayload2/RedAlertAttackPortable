Namespace 核心
    <HideModuleName()>
    Module 公共事件
        Event 玩家出局(玩家顺序号 As Integer)
        Public Sub 引发玩家出局(Of 图像类型, 鼠标光标, 用户控件类型)(玩家 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型))
            RaiseEvent 玩家出局(玩家.顺序号)
        End Sub
    End Module

    Public Class 玩家生死判定EventArgs
        Inherits EventArgs
        Public ReadOnly 需要救治 As Boolean, 不能救活 As Boolean
        Sub New(Optional 需要救治 As Boolean = False, Optional 不能救活 As Boolean = False)
            Me.需要救治 = 需要救治
            Me.不能救活 = 不能救活
        End Sub
    End Class
    Public Class 牌响应EventArgs
        Inherits EventArgs
        Public 已处理, 是人类玩家, 已超时 As Boolean
        Sub New(_已处理 As Boolean, _是人类玩家 As Boolean, Optional _已超时 As Boolean = False)
            已处理 = _已处理
            是人类玩家 = _是人类玩家
            已超时 = _已超时
        End Sub
    End Class
End Namespace
