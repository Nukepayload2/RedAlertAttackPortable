Imports 红警杀.核心
Imports 红警杀.基元
Namespace 基元
    Public MustInherit Class 特效Base(Of 图像类型, 鼠标光标, 用户控件类型)
        Implements I特效(Of 图像类型, 鼠标光标, 用户控件类型)

        Public Overridable ReadOnly Property 名称 As String Implements I特效(Of 图像类型, 鼠标光标, 用户控件类型).名称
            Get
                Return Me.GetType.Name
            End Get
        End Property

        Public Property 启用 As Boolean = True Implements I特效(Of 图像类型, 鼠标光标, 用户控件类型).启用

        Public MustOverride ReadOnly Property 说明 As String Implements I特效(Of 图像类型, 鼠标光标, 用户控件类型).说明

        Public Overridable ReadOnly Property 附带资源 As IEnumerable(Of KeyValuePair(Of String, String)) Implements I特效(Of 图像类型, 鼠标光标, 用户控件类型).附带资源
            Get
                Return {}
            End Get
        End Property

        Public Overridable ReadOnly Property 内嵌资源 As IEnumerable(Of KeyValuePair(Of String, Stream)) Implements I特效(Of 图像类型, 鼠标光标, 用户控件类型).内嵌资源
            Get
                Return {}
            End Get
        End Property

        Public Overridable Async Function 响应牌结束(目标 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型), 来源 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型), 牌 As I手牌控件(Of 图像类型, 鼠标光标, 用户控件类型), 成功响应 As Boolean) As Task(Of Boolean) Implements I特效(Of 图像类型, 鼠标光标, 用户控件类型).响应牌结束
            Return Await RetTrueTask()
        End Function

        Public Overridable Async Function 回合增加() As Task Implements I特效(Of 图像类型, 鼠标光标, 用户控件类型).回合增加
            Await DoNothingTask()
        End Function

        Public Overridable Async Function 开局(相关玩家 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型)) As Task Implements I特效(Of 图像类型, 鼠标光标, 用户控件类型).开局
            Await DoNothingTask()
        End Function

        Public Overridable Async Function 玩家战败(玩家 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型), 战败方 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型)) As Task Implements I特效(Of 图像类型, 鼠标光标, 用户控件类型).玩家战败
            Await DoNothingTask()
        End Function

        Public Overridable Async Function 结束(相关玩家 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型)) As Task Implements I特效(Of 图像类型, 鼠标光标, 用户控件类型).结束
            Await DoNothingTask()
        End Function

        Public Overridable Async Function 出牌阶段(玩家 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型)) As Task(Of Boolean) Implements I特效(Of 图像类型, 鼠标光标, 用户控件类型).出牌阶段
            Return Await RetTrueTask()
        End Function

        Public Overridable Async Function 即将展示手牌(玩家 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型), 展示成功 As StrongBox(Of Boolean)) As Task(Of Boolean) Implements I特效(Of 图像类型, 鼠标光标, 用户控件类型).即将展示手牌
            Return Await RetTrueTask()
        End Function

        Public Overridable Async Function 即将求救(玩家 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型)) As Task(Of Boolean) Implements I特效(Of 图像类型, 鼠标光标, 用户控件类型).即将求救
            Return Await RetTrueTask()
        End Function

        Public Overridable Async Function 响应牌(目标 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型), 来源 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型), 牌 As I手牌控件(Of 图像类型, 鼠标光标, 用户控件类型)) As Task(Of Boolean) Implements I特效(Of 图像类型, 鼠标光标, 用户控件类型).响应牌
            Return Await RetTrueTask()
        End Function

        Public Overridable Async Function 手牌减少(玩家 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型), 牌 As I手牌控件(Of 图像类型, 鼠标光标, 用户控件类型)) As Task(Of Boolean) Implements I特效(Of 图像类型, 鼠标光标, 用户控件类型).手牌减少
            Return Await RetTrueTask()
        End Function

        Public Overridable Async Function 开始阶段(玩家 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型)) As Task(Of Boolean) Implements I特效(Of 图像类型, 鼠标光标, 用户控件类型).开始阶段
            Return Await RetTrueTask()
        End Function

        Public Overridable Async Function 手牌增加(玩家 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型), 牌 As I手牌控件(Of 图像类型, 鼠标光标, 用户控件类型)) As Task(Of Boolean) Implements I特效(Of 图像类型, 鼠标光标, 用户控件类型).手牌增加
            Return Await RetTrueTask()
        End Function

        Public Overridable Async Function 打出牌(目标 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型), 来源 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型), 牌 As I手牌控件(Of 图像类型, 鼠标光标, 用户控件类型)) As Task(Of Boolean) Implements I特效(Of 图像类型, 鼠标光标, 用户控件类型).打出牌
            Return Await RetTrueTask()
        End Function

        Public Overridable Async Function 标记减少(玩家 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型), 来源 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型), 变的标记 As IEnumerable(Of I标记(Of 图像类型, 鼠标光标, 用户控件类型))) As Task(Of Boolean) Implements I特效(Of 图像类型, 鼠标光标, 用户控件类型).标记减少
            Return Await RetTrueTask()
        End Function

        Public Overridable Async Function 求救开始(玩家 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型)) As Task(Of Boolean) Implements I特效(Of 图像类型, 鼠标光标, 用户控件类型).求救开始
            Return Await RetTrueTask()
        End Function

        Public Overridable Async Function 生命值上限改变(玩家 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型), 来源 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型), 新的生命值 As Integer) As Task(Of Boolean) Implements I特效(Of 图像类型, 鼠标光标, 用户控件类型).生命值上限改变
            Return Await RetTrueTask()
        End Function

        Public Overridable Async Function 生命值改变(玩家 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型), 来源 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型), 新的生命值 As Integer) As Task(Of Boolean) Implements I特效(Of 图像类型, 鼠标光标, 用户控件类型).生命值改变
            Return Await RetTrueTask()
        End Function

        Public Overridable Async Function 电力改变(玩家 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型), 来源 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型), 新的电力值 As Integer) As Task(Of Boolean) Implements I特效(Of 图像类型, 鼠标光标, 用户控件类型).电力改变
            Return Await RetTrueTask()
        End Function

        Public Overridable Async Function 结束阶段(玩家 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型)) As Task(Of Boolean) Implements I特效(Of 图像类型, 鼠标光标, 用户控件类型).结束阶段
            Return Await RetTrueTask()
        End Function

        Public Overridable Async Function 结束阶段之后(玩家 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型)) As Task(Of Boolean) Implements I特效(Of 图像类型, 鼠标光标, 用户控件类型).结束阶段之后
            Return Await RetTrueTask()
        End Function

        Public Overridable Async Function 标记增加(玩家 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型), 来源 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型), 变的标记 As IEnumerable(Of I标记(Of 图像类型, 鼠标光标, 用户控件类型))) As Task(Of Boolean) Implements I特效(Of 图像类型, 鼠标光标, 用户控件类型).标记增加
            Return Await RetTrueTask()
        End Function
    End Class

    Public MustInherit Class 武将技能Base(Of 图像类型, 鼠标光标, 用户控件类型)
        Inherits 特效Base(Of 图像类型, 鼠标光标, 用户控件类型)
        Implements I武将特技(Of 图像类型, 鼠标光标, 用户控件类型)

        Public MustOverride ReadOnly Property 是阵营特技 As Boolean Implements I武将特技(Of 图像类型, 鼠标光标, 用户控件类型).是阵营特技

    End Class
End Namespace
Namespace 基本技能
    Public Class 重甲(Of 图像类型, 鼠标光标, 用户控件类型)
        Inherits 武将技能Base(Of 图像类型, 鼠标光标, 用户控件类型)
        Public Overrides ReadOnly Property 是阵营特技 As Boolean = True
        Public Overrides ReadOnly Property 说明 As String = "【苏军专用】开局时增加1点生命值和生命上限"
        Public Overrides Async Function 开局(相关玩家 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型)) As Task
            Await MyBase.开局(相关玩家)
            相关玩家.生命值(相关玩家) += 1
        End Function
    End Class

    Public Class 高科(Of 图像类型, 鼠标光标, 用户控件类型)
        Inherits 武将技能Base(Of 图像类型, 鼠标光标, 用户控件类型)
        Public Overrides ReadOnly Property 是阵营特技 As Boolean = True
        Public Overrides ReadOnly Property 说明 As String = "【盟军专用】开局时增加2个手牌上限"
        Public Overrides Async Function 开局(相关玩家 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型)) As Task
            Await MyBase.开局(相关玩家)
            相关玩家.手牌上限附加值 += 2
        End Function
    End Class
    Public Class 复仇(Of 图像类型, 鼠标光标, 用户控件类型)
        Inherits 武将技能Base(Of 图像类型, 鼠标光标, 用户控件类型)
        Public Overrides ReadOnly Property 是阵营特技 As Boolean = True
        Public Overrides ReadOnly Property 说明 As String = "尤里的超能力能让我方闪避的杀服从尤里"
        Public Overrides ReadOnly Property 附带资源 As IEnumerable(Of KeyValuePair(Of String, String))
            Get
                Return {New KeyValuePair(Of String, String)("复仇", 资源.音效目录 + "复仇.wav")}
            End Get
        End Property
        Public Overrides Async Function 响应牌结束(目标 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型), 来源 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型), 牌 As I手牌控件(Of 图像类型, 鼠标光标, 用户控件类型), 成功响应 As Boolean) As Task(Of Boolean)
            Dim r = Await MyBase.响应牌结束(目标, 来源, 牌, 成功响应)
            If (牌.特性.AI分类.Contain(卡牌分类.普通杀) OrElse
                牌.特性.AI分类.Contain(卡牌分类.特殊杀)) AndAlso
                Not 牌.特性.免疫心灵控制 Then
                Await 游戏(Of 图像类型, 鼠标光标, 用户控件类型).当前.播放器.播放音效(游戏(Of 图像类型, 鼠标光标, 用户控件类型).当前.声音资源加载器.StreamCache("复仇"))
                Await 目标.得到手牌(牌)
            End If
            Return r
        End Function
    End Class

End Namespace
