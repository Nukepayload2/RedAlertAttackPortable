Imports 红警杀.核心
Imports 红警杀.基元
Namespace 基元
    Public MustInherit Class 特效Base(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型)
        Implements 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I特效

        Public Overridable ReadOnly Property 名称 As String Implements 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I特效.名称
            Get
                Return Me.GetType.Name
            End Get
        End Property

        Public Property 启用 As Boolean = True Implements 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I特效.启用

        Public MustOverride ReadOnly Property 说明 As String Implements 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I特效.说明

        Public Overridable ReadOnly Property 附带资源 As IEnumerable(Of KeyValuePair(Of String, String)) Implements 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I特效.附带资源
            Get
                Return {}
            End Get
        End Property

        Public Overridable ReadOnly Property 内嵌资源 As IEnumerable(Of KeyValuePair(Of String, Stream)) Implements 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I特效.内嵌资源
            Get
                Return {}
            End Get
        End Property

        Public Overridable Function 响应牌结束(游戏 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I游戏, 目标 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I玩家, 来源 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I玩家, 牌 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I手牌控件, 成功响应 As Boolean) As Boolean Implements 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I特效.响应牌结束
            Return True
        End Function

        Public Overridable Sub 回合增加(游戏 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I游戏) Implements 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I特效.回合增加

        End Sub

        Public Overridable Sub 开局(游戏 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I游戏, 相关玩家 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I玩家) Implements 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I特效.开局

        End Sub

        Public Overridable Sub 玩家战败(游戏 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I游戏, 玩家 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I玩家, 战败方 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I玩家) Implements 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I特效.玩家战败

        End Sub

        Public Overridable Sub 结束(游戏 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I游戏, 相关玩家 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I玩家) Implements 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I特效.结束

        End Sub

        Public Overridable Function 出牌阶段(游戏 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I游戏, 玩家 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I玩家) As Boolean Implements 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I特效.出牌阶段
            Return True
        End Function

        Public Overridable Function 即将展示手牌(游戏 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I游戏, 玩家 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I玩家, 展示成功 As StrongBox(Of Boolean)) As Boolean Implements 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I特效.即将展示手牌
            Return True
        End Function

        Public Overridable Function 即将求救(游戏 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I游戏, 玩家 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I玩家) As Boolean Implements 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I特效.即将求救
            Return True
        End Function

        Public Overridable Function 响应牌(游戏 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I游戏, 目标 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I玩家, 来源 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I玩家, 牌 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I手牌控件) As Boolean Implements 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I特效.响应牌
            Return True
        End Function

        Public Overridable Function 失去牌(游戏 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I游戏, 玩家 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I玩家, 牌 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I手牌控件) As Boolean Implements 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I特效.失去牌
            Return True
        End Function

        Public Overridable Function 开始阶段(游戏 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I游戏, 玩家 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I玩家) As Boolean Implements 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I特效.开始阶段
            Return True
        End Function

        Public Overridable Function 得到牌(游戏 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I游戏, 玩家 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I玩家, 牌 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I手牌控件) As Boolean Implements 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I特效.得到牌
            Return True
        End Function

        Public Overridable Function 打出牌(游戏 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I游戏, 目标 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I玩家, 来源 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I玩家, 牌 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I手牌控件) As Boolean Implements 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I特效.打出牌
            Return True
        End Function

        Public Overridable Function 标记改变(游戏 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I游戏, 玩家 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I玩家, 来源 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I玩家, 变的标记 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I标记) As Boolean Implements 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I特效.标记改变
            Return True
        End Function

        Public Overridable Function 求救开始(游戏 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I游戏, 玩家 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I玩家) As Boolean Implements 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I特效.求救开始
            Return True
        End Function

        Public Overridable Function 生命值上限改变(游戏 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I游戏, 玩家 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I玩家, 来源 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I玩家, 新的生命值 As Integer) As Boolean Implements 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I特效.生命值上限改变
            Return True
        End Function

        Public Overridable Function 生命值改变(游戏 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I游戏, 玩家 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I玩家, 来源 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I玩家, 新的生命值 As Integer) As Boolean Implements 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I特效.生命值改变
            Return True
        End Function

        Public Overridable Function 电力改变(游戏 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I游戏, 玩家 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I玩家, 来源 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I玩家, 新的电力值 As Integer) As Boolean Implements 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I特效.电力改变
            Return True
        End Function

        Public Overridable Function 结束阶段(游戏 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I游戏, 玩家 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I玩家) As Boolean Implements 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I特效.结束阶段
            Return True
        End Function

        Public Overridable Function 结束阶段之后(游戏 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I游戏, 玩家 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I玩家) As Boolean Implements 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I特效.结束阶段之后
            Return True
        End Function
    End Class

    Public MustInherit Class 武将技能Base(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型)
        Inherits 特效Base(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型)
        Implements 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I武将特技

        Public MustOverride ReadOnly Property 是阵营特技 As Boolean Implements 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I武将特技.是阵营特技

    End Class
End Namespace
Namespace 基本技能
    Public Class 重甲(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型)
        Inherits 武将技能Base(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型)
        Public Overrides ReadOnly Property 是阵营特技 As Boolean = True
        Public Overrides ReadOnly Property 说明 As String = "【苏军专用】开局时增加1点生命值和生命上限"
        Public Overrides Sub 开局(游戏 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I游戏, 相关玩家 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I玩家)
            MyBase.开局(游戏, 相关玩家)
            相关玩家.生命值(游戏, 相关玩家) += 1
        End Sub
    End Class

    Public Class 高科(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型)
        Inherits 武将技能Base(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型)
        Public Overrides ReadOnly Property 是阵营特技 As Boolean = True
        Public Overrides ReadOnly Property 说明 As String = "【盟军专用】开局时增加2个手牌上限"
        Public Overrides Sub 开局(游戏 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I游戏, 相关玩家 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I玩家)
            MyBase.开局(游戏, 相关玩家)
            相关玩家.手牌上限附加值 += 2
        End Sub
    End Class
    Public Class 复仇(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型)
        Inherits 武将技能Base(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型)
        Public Overrides ReadOnly Property 是阵营特技 As Boolean = True
        Public Overrides ReadOnly Property 说明 As String = "尤里的超能力能让我方闪避的杀服从尤里"
        Public Overrides ReadOnly Property 附带资源 As IEnumerable(Of KeyValuePair(Of String, String))
            Get
                Return {New KeyValuePair(Of String, String)("复仇", 资源.音效目录 + "复仇.wav")}
            End Get
        End Property
        Public Overrides Function 响应牌结束(游戏 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I游戏, 目标 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I玩家, 来源 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I玩家, 牌 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I手牌控件, 成功响应 As Boolean) As Boolean
            Dim r = MyBase.响应牌结束(游戏, 目标, 来源, 牌, 成功响应)
            If (牌.特性.AI分类.Contain(动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).卡牌分类.普通杀) OrElse
                牌.特性.AI分类.Contain(动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).卡牌分类.特殊杀)) AndAlso
                Not 牌.特性.免疫心灵控制 Then
                游戏.播放器.播放音效(游戏.声音资源加载器.StreamCache("复仇"))
                目标.得到手牌(游戏, 牌)
            End If
            Return r
        End Function
    End Class


End Namespace
