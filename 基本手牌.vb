Imports 红警杀.核心

Imports 红警杀.基元
Namespace 基元
    Public MustInherit Class 手牌Base(Of 图像类型, 鼠标光标, 用户控件类型)
        Implements I手牌(Of 图像类型, 鼠标光标, 用户控件类型)
        Sub New()
        End Sub
        Sub New(花色和点数 As 花色点数结构, 免疫心灵控制 As Boolean)
            Me.花色和点数 = 花色和点数
            Me.免疫心灵控制 = 免疫心灵控制
        End Sub

        Public MustOverride ReadOnly Property AI分类 As Integer Implements I手牌(Of 图像类型, 鼠标光标, 用户控件类型).AI分类
        Public Property 免疫心灵控制 As Boolean Implements I手牌(Of 图像类型, 鼠标光标, 用户控件类型).免疫心灵控制
        Public MustOverride ReadOnly Property 回合数限制 As Integer Implements I手牌(Of 图像类型, 鼠标光标, 用户控件类型).回合数限制
        Public ReadOnly Property 是桃牌 As Boolean Implements I手牌(Of 图像类型, 鼠标光标, 用户控件类型).是桃牌
            Get
                Return 花色和点数.花色 = 花色枚举.红桃 OrElse 花色和点数.花色 = 花色枚举.黑桃
            End Get
        End Property
        Public MustOverride ReadOnly Property 是红警杀Mod牌 As Boolean Implements I牌(Of 图像类型, 鼠标光标, 用户控件类型).是红警杀Mod牌
        Public MustOverride ReadOnly Property 是超级武器 As Boolean Implements I手牌(Of 图像类型, 鼠标光标, 用户控件类型).是超级武器
        Public ReadOnly Property 是黑牌 As Boolean Implements I手牌(Of 图像类型, 鼠标光标, 用户控件类型).是黑牌
            Get
                Return 花色和点数.花色 = 花色枚举.梅花 OrElse 花色和点数.花色 = 花色枚举.黑桃
            End Get
        End Property
        ''' <summary>
        ''' 表示单位科技程度。科技程度越高，在初期发牌时越难发到。
        ''' 超出科技等级限制的卡牌不能被发牌。
        ''' </summary>
        ''' <returns></returns>
        Public MustOverride ReadOnly Property 科技等级 As Integer Implements I手牌(Of 图像类型, 鼠标光标, 用户控件类型).科技等级
        Public MustOverride ReadOnly Property 出牌阶段能被打出 As Boolean Implements I手牌(Of 图像类型, 鼠标光标, 用户控件类型).出牌阶段能被打出
        Public Property 花色和点数 As 花色点数结构 Implements I手牌(Of 图像类型, 鼠标光标, 用户控件类型).花色和点数
        Public Overridable ReadOnly Property 名称 As String Implements I牌(Of 图像类型, 鼠标光标, 用户控件类型).名称
            Get
                Return Me.GetType.Name
            End Get
        End Property
        Public MustOverride ReadOnly Property 短说明 As String Implements I牌(Of 图像类型, 鼠标光标, 用户控件类型).短说明
        Public MustOverride ReadOnly Property 长说明 As String Implements I牌(Of 图像类型, 鼠标光标, 用户控件类型).长说明
        ''' <summary>
        ''' 卡牌上显示的小图标,默认是空。
        ''' 如果是空的则加载手牌时会变成默认图标。
        ''' </summary> 
        ''' <returns></returns>
        Public Overridable ReadOnly Property 图标(阵营 As I阵营(Of 图像类型, 鼠标光标, 用户控件类型)) As 图像类型 Implements I手牌(Of 图像类型, 鼠标光标, 用户控件类型).图标
            Get
                Return Nothing
            End Get
        End Property
        ''' <summary>
        ''' 卡牌工具提示上显示的大图标,默认是空。
        ''' 如果是空的则加载手牌时会变成默认图标。
        ''' </summary> 
        ''' <returns></returns>
        Public Overridable ReadOnly Property 大图标(阵营 As I阵营(Of 图像类型, 鼠标光标, 用户控件类型)) As 图像类型 Implements I手牌(Of 图像类型, 鼠标光标, 用户控件类型).大图标
            Get
                Return Nothing
            End Get
        End Property
        ''' <summary>
        ''' 是否按照筛选玩家对其它成员生效，默认是False
        ''' </summary>
        ''' <returns></returns>
        Public Overridable ReadOnly Property 是群攻牌 As Boolean Implements I手牌(Of 图像类型, 鼠标光标, 用户控件类型).是群攻牌
            Get
                Return False
            End Get
        End Property
        ''' <summary>
        ''' 如果是群攻牌，返回筛选过的能攻击的玩家列表。
        ''' </summary>
        ''' <exception cref="InvalidOperationException">不是群攻牌时引发</exception>
        ''' <returns></returns>
        Public Overridable Function 筛选玩家(玩家表 As IEnumerable(Of I玩家(Of 图像类型, 鼠标光标, 用户控件类型)), 当前玩家 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型)) As IEnumerable(Of I玩家(Of 图像类型, 鼠标光标, 用户控件类型)) Implements I手牌(Of 图像类型, 鼠标光标, 用户控件类型).筛选玩家
            If 是群攻牌 Then
                Return From p In 玩家表 Where p IsNot 当前玩家
            Else
                Throw New InvalidOperationException("非群攻牌不能群攻。名称：" & 名称)
            End If
        End Function
        ''' <summary>
        ''' 如果这张牌不是群攻的，那么它最多能选择几个目标。
        ''' 默认是1。
        ''' </summary>
        ''' <returns></returns>
        Public Overridable ReadOnly Property 最大目标数量 As Integer Implements I手牌(Of 图像类型, 鼠标光标, 用户控件类型).最大目标数量
            Get
                Return 1
            End Get
        End Property
        ''' <summary>
        ''' 如果玩这个游戏时使用了鼠标，设置光标的外观。
        ''' 如果是空的则使用游戏设置的默认鼠标。
        ''' 默认是空的。
        ''' </summary>
        ''' <returns></returns>
        Public Overridable ReadOnly Property 光标 As 鼠标光标 Implements I牌(Of 图像类型, 鼠标光标, 用户控件类型).光标
            Get
                Return Nothing
            End Get
        End Property
        ''' <summary>
        ''' 卡牌被选中时播放的声音从这些声音里选出来。默认是空集。
        ''' </summary> 
        Public Overridable ReadOnly Property 选择声音 As IEnumerable(Of Stream) Implements I牌(Of 图像类型, 鼠标光标, 用户控件类型).选择声音
            Get
                Return {}
            End Get
        End Property
        ''' <summary>
        ''' 卡牌被使用时播放的声音从这些声音里选出来。默认是空集。
        ''' </summary> 
        Public Overridable ReadOnly Property 使用声音 As IEnumerable(Of Stream) Implements I牌(Of 图像类型, 鼠标光标, 用户控件类型).使用声音
            Get
                Return {}
            End Get
        End Property
        ''' <summary>
        ''' 武将死亡和攻击性卡牌失效时播放的声音从这些声音里选出来。默认是空集。
        ''' </summary> 
        Public Overridable ReadOnly Property 死亡声音 As IEnumerable(Of Stream) Implements I牌(Of 图像类型, 鼠标光标, 用户控件类型).死亡声音
            Get
                Return {}
            End Get
        End Property
        ''' <summary>
        ''' 是不是一种特定阵营才能使用的牌，默认是False
        ''' </summary>
        ''' <returns></returns>
        Public Overridable ReadOnly Property 是阵营特定牌 As Boolean Implements I手牌(Of 图像类型, 鼠标光标, 用户控件类型).是阵营特定牌
            Get
                Return False
            End Get
        End Property
        ''' <summary>
        ''' 如果是特定阵营才能用的牌，是哪些阵营能用。如果指定为空集且是阵营特定牌则会屏蔽这张牌。默认为空集。
        ''' </summary>
        ''' <returns></returns>
        Public Overridable ReadOnly Property 特定阵营 As IEnumerable(Of I阵营(Of 图像类型, 鼠标光标, 用户控件类型)) Implements I手牌(Of 图像类型, 鼠标光标, 用户控件类型).特定阵营
            Get
                Return {}
            End Get
        End Property

        ''' <summary>
        ''' 加载一些临时的资源
        ''' </summary> 
        Public Overridable Async Function 当初始化完成() As Task Implements I牌(Of 图像类型, 鼠标光标, 用户控件类型).当初始化完成
            Await DoNothingTask()
        End Function
        Public Overridable Async Function 当失去时(源玩家 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型), 目标玩家 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型)) As Task Implements I手牌(Of 图像类型, 鼠标光标, 用户控件类型).当失去时
            Await DoNothingTask()
        End Function
        Public Overridable Async Function 当得到时(源玩家 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型), 目标玩家 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型)) As Task Implements I手牌(Of 图像类型, 鼠标光标, 用户控件类型).当得到时
            Await DoNothingTask()
        End Function
        ''' <summary>
        ''' 用于释放临时的资源
        ''' </summary> 
        Public Overridable Async Function 当生命周期完成() As Task Implements I牌(Of 图像类型, 鼠标光标, 用户控件类型).当生命周期完成
            Await DoNothingTask()
        End Function
        ''' <summary>
        ''' 注意：如果要重写此方法，还要使用 人类响应 或 AI响应 或 响应失败则要先调用基类的此方法。
        ''' </summary> 
        Public Overridable Async Function 被响应(源玩家 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型), 目标玩家 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型), e As 牌响应EventArgs) As Task(Of Boolean) Implements I手牌(Of 图像类型, 鼠标光标, 用户控件类型).被响应
            If Not e.已处理 Then
                If Not e.已超时 Then
                    If e.是人类玩家 Then
                        If Await 人类响应(源玩家, 目标玩家) Then Return True
                    Else
                        If Await AI响应(源玩家, 目标玩家) Then Return True
                    End If
                End If
                Await 响应失败(源玩家, 目标玩家)
                Return False
            Else
                Await 不用响应(源玩家, 目标玩家)
                Return True
            End If
        End Function
        Public Overridable Async Function 响应失败(源玩家 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型), 目标玩家 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型)) As Task
            Await DoNothingTask()
        End Function
        Public Overridable Async Function 不用响应(源玩家 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型), 目标玩家 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型)) As Task
            Await DoNothingTask()
        End Function
        ''' <summary>
        ''' 返回值表示人类是否成功响应卡牌的要求。
        ''' 默认是响应失败
        ''' </summary> 
        Public Overridable Async Function 人类响应(源玩家 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型), 目标玩家 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型)) As Task(Of Boolean)
            Return Await RetFalseTask()
        End Function
        ''' <summary>
        ''' 返回值表示AI是否成功响应卡牌的要求。
        ''' 默认是响应失败
        ''' </summary> 
        Public Overridable Async Function AI响应(源玩家 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型), 目标玩家 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型)) As Task(Of Boolean)
            Return Await RetFalseTask()
        End Function
        Public Overridable Sub 随机获得花色点数() Implements I手牌(Of 图像类型, 鼠标光标, 用户控件类型).随机获得花色点数
            花色和点数 = New 花色点数结构(CType(RndEx(0, 3), 花色枚举), RndEx(1, 13))
        End Sub
    End Class

End Namespace
Namespace 基本手牌
    Friend Module Constants
        Enum DefaultRoundLimits
            NoLimit
            HighAmmor = 4
            DefenseAbility = 4
            Commando = 7 'HighInfantry 和 HeroAmmor 
            StrikeAbility = 8
            SuperWeapon = 9
        End Enum
        Enum DefaultTechLevels
            Essential = 1 '杀，闪，电
            SupportAbility '维修
            MidInfantry  '工程师,疯狂依文
            DropPods '空降
            DefenseAbility = 5 '防御建筑
            HighInfantry = 6 '鲍里斯，谭雅，尤里X
            HighAmmor = 7 '天启，光棱坦克，脑车
            HeroAmmor = 8 '保留。添加标记为Mod的卡牌，类似：根除者虫甲，MARV，救赎者，万夫长攻城机甲...
            StrikeAbility = 9 '磁力卫星等
            SuperWeapon = 10 '六大SW
        End Enum
    End Module
    Public Class 杀(Of 图像类型, 鼠标光标, 用户控件类型)
        Inherits 手牌Base(Of 图像类型, 鼠标光标, 用户控件类型)
        Public Overrides ReadOnly Property AI分类 As Integer =
             卡牌分类.普通杀
        Public Overrides ReadOnly Property 回合数限制 As Integer = DefaultRoundLimits.NoLimit
        Public Overrides ReadOnly Property 是红警杀Mod牌 As Boolean = False
        Public Overrides ReadOnly Property 是超级武器 As Boolean = False
        Public Overrides ReadOnly Property 科技等级 As Integer = DefaultTechLevels.Essential
        Public Overrides ReadOnly Property 出牌阶段能被打出 As Boolean = True
        Public Overrides ReadOnly Property 短说明 As String = "对敌人造成一点伤害"
        Public Overrides ReadOnly Property 长说明 As String = "如果敌人不出闪来对付，则受到一点伤害"
        Public Overrides Async Function 响应失败(源玩家 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型), 目标玩家 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型)) As Task
            Await MyBase.响应失败(源玩家, 目标玩家)
            目标玩家.生命值(源玩家) -= 1
        End Function
        Protected Async Function AI响应Internal(源玩家 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型), 目标玩家 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型), 牌类型 As IEnumerable(Of 卡牌分类)) As Task(Of Boolean)
            Dim ca = Await 目标玩家.选牌(牌类型)
            If ca.Count <> 0 Then
                Await 目标玩家.失去手牌(ca.First)
                Return True
            Else
                Return False
            End If
        End Function
        Public Overrides Async Function AI响应(源玩家 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型), 目标玩家 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型)) As Task(Of Boolean)
            Await MyBase.AI响应(源玩家, 目标玩家)
            Return Await AI响应Internal(源玩家, 目标玩家, {卡牌分类.闪})
        End Function
        Protected Async Function HM响应Internal(源玩家 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型), 目标玩家 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型), 牌类型 As IEnumerable(Of 卡牌分类)) As Task(Of Boolean)
            Dim types As New StringBuilder
            Dim i As Integer = 0, le As Integer = 牌类型.Count
            For Each t In 牌类型
                types.Append(t.ToString)
                i += 1
                If i < 牌类型.Count Then
                    types.Append(" 或者 ")
                End If
            Next
            Dim typ = types.ToString
            If Await 游戏(Of 图像类型, 鼠标光标, 用户控件类型).当前.窗体.消息框.ShowDialog("是否打出一张" & typ & "？", "响应 " + 名称,
                                                消息框按钮枚举.是和否,
                                                消息框样式枚举.消息) =
                                                消息框状态枚举.确定 Then
                Dim ca = Await 目标玩家.选牌(牌类型)
                If ca.Count <> 0 Then
                    If ca.Count > 1 Then
                        Await 游戏(Of 图像类型, 鼠标光标, 用户控件类型).当前.窗体.消息框.ShowDialog("选择一张" & typ & "就够了，点击确定打出选择的第一张。", "数量错误",,
                                             消息框样式枚举.警告)
                    End If
                    Await 目标玩家.失去手牌(ca.First)
                    Return True
                End If
            End If
            Return False
        End Function
        Public Overrides Async Function 人类响应(源玩家 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型), 目标玩家 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型)) As Task(Of Boolean)
            Await MyBase.人类响应(源玩家, 目标玩家)
            Return Await HM响应Internal(源玩家, 目标玩家, {卡牌分类.闪})
        End Function
    End Class
    Public Class 闪(Of 图像类型, 鼠标光标, 用户控件类型)
        Inherits 手牌Base(Of 图像类型, 鼠标光标, 用户控件类型)

        Public Overrides ReadOnly Property AI分类 As Integer =
            卡牌分类.闪
        Public Overrides ReadOnly Property 出牌阶段能被打出 As Boolean = False
        Public Overrides ReadOnly Property 回合数限制 As Integer = DefaultRoundLimits.NoLimit
        Public Overrides ReadOnly Property 是红警杀Mod牌 As Boolean = False
        Public Overrides ReadOnly Property 是超级武器 As Boolean = False
        Public Overrides ReadOnly Property 短说明 As String = "避免杀的伤害"
        Public Overrides ReadOnly Property 科技等级 As Integer = DefaultTechLevels.Essential
        Public Overrides ReadOnly Property 长说明 As String = "在对方给你打出杀时使用，能避免杀的伤害"
    End Class
    Public Class 维修(Of 图像类型, 鼠标光标, 用户控件类型)
        Inherits 手牌Base(Of 图像类型, 鼠标光标, 用户控件类型)
        Public Overrides ReadOnly Property AI分类 As Integer = 卡牌分类.回复系
        Public Overrides ReadOnly Property 出牌阶段能被打出 As Boolean = True
        Public Overrides ReadOnly Property 回合数限制 As Integer = DefaultRoundLimits.NoLimit
        Public Overrides ReadOnly Property 是红警杀Mod牌 As Boolean = False
        Public Overrides ReadOnly Property 是超级武器 As Boolean = False
        Public Overrides ReadOnly Property 短说明 As String = "恢复生命值"
        Public Overrides ReadOnly Property 科技等级 As Integer = DefaultTechLevels.SupportAbility
        Public Overrides ReadOnly Property 长说明 As String = "让目标恢复一点生命值，通常对自己使用，在濒死时可以用来救所有阵营的人"

        Public Overrides Async Function 响应失败(源玩家 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型), 目标玩家 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型)) As Task
            Await MyBase.响应失败(源玩家, 目标玩家)
            目标玩家.生命值(源玩家) += 1
        End Function
    End Class
    Public Class 工程师(Of 图像类型, 鼠标光标, 用户控件类型)
        Inherits 手牌Base(Of 图像类型, 鼠标光标, 用户控件类型)
        Public Overrides ReadOnly Property AI分类 As Integer =
            卡牌分类.回复系
        Public Overrides ReadOnly Property 出牌阶段能被打出 As Boolean = True
        Public Overrides ReadOnly Property 回合数限制 As Integer = DefaultRoundLimits.NoLimit
        Public Overrides ReadOnly Property 是红警杀Mod牌 As Boolean = False
        Public Overrides ReadOnly Property 是超级武器 As Boolean = False
        Public Overrides ReadOnly Property 短说明 As String = "给自己阵营的人恢复体力，抢夺其它阵营的人的体力"
        Public Overrides ReadOnly Property 科技等级 As Integer = DefaultTechLevels.MidInfantry
        Public Overrides ReadOnly Property 长说明 As String = "如果给自己阵营的人使用则恢复体力，如果对其它阵营使用则其它阵营的人需要展示随机指定的一张[杀]或[特殊杀]，如果不展示则抢夺其它阵营的人的体力给自己，可以用来救我方阵营的人或在其它阵营的人求救时加害没有杀的其它阵营的人。"
        Public Overrides Async Function AI响应(源玩家 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型), 目标玩家 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型)) As Task(Of Boolean)
            Await MyBase.AI响应(源玩家, 目标玩家)
            If 源玩家.控制者信息.group = 目标玩家.控制者信息.group Then
                Return False
            Else
                Return 目标玩家.有某类牌({卡牌分类.普通杀,
                                 卡牌分类.特殊杀})
            End If
        End Function
        Public Overrides Async Function 人类响应(源玩家 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型), 目标玩家 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型)) As Task(Of Boolean)
            Await MyBase.人类响应(源玩家, 目标玩家)
            If 源玩家.控制者信息.group = 目标玩家.控制者信息.group Then
                Return False
            Else
                Dim cards = 目标玩家.取某类牌({卡牌分类.普通杀,
                                       卡牌分类.特殊杀})
                If 0 = cards.Count Then
                    Return False
                Else
                    Return Await 目标玩家.展示手牌(cards(RndEx(0, cards.Count - 1)))
                End If
            End If
        End Function
        Public Overrides Async Function 响应失败(源玩家 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型), 目标玩家 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型)) As Task
            Await MyBase.响应失败(源玩家, 目标玩家)
            If 源玩家.控制者信息.group = 目标玩家.控制者信息.group Then
                目标玩家.生命值(源玩家) += 1
            Else
                目标玩家.生命值(源玩家) -= 1
                源玩家.生命值(源玩家) += 1
            End If
        End Function
    End Class
    Public Class 默认高装甲杀(Of 图像类型, 鼠标光标, 用户控件类型)
        Inherits 杀(Of 图像类型, 鼠标光标, 用户控件类型)
        Public Overrides ReadOnly Property AI分类 As Integer = 卡牌分类.特殊杀
        Public Overrides ReadOnly Property 出牌阶段能被打出 As Boolean = True
        Public Overrides ReadOnly Property 回合数限制 As Integer = DefaultRoundLimits.HighAmmor
        Public Overrides ReadOnly Property 是超级武器 As Boolean = False
        Public Overrides ReadOnly Property 科技等级 As Integer = DefaultTechLevels.HighAmmor
    End Class
    Public Class 天启杀(Of 图像类型, 鼠标光标, 用户控件类型)
        Inherits 默认高装甲杀(Of 图像类型, 鼠标光标, 用户控件类型)
        Public Overrides ReadOnly Property 短说明 As String = "这张杀需要两张闪回避"
        Public Overrides ReadOnly Property 长说明 As String = "苏联的重型装甲坦克，使用后如果对方不能打出两张闪则受到一点伤害。"
        Public Overrides ReadOnly Property 是阵营特定牌 As Boolean = True
        Public Overrides ReadOnly Property 特定阵营 As IEnumerable(Of I阵营(Of 图像类型, 鼠标光标, 用户控件类型))
            Get
                Return {New 基本阵营.苏联(Of 图像类型, 鼠标光标, 用户控件类型)}
            End Get
        End Property

        Public Overrides Async Function AI响应(源玩家 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型), 目标玩家 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型)) As Task(Of Boolean)
            Await AI响应(源玩家, 目标玩家)
            Dim ca = Await 目标玩家.选牌({卡牌分类.闪})
            If ca.Count > 1 Then
                Await 目标玩家.失去手牌({ca(0), ca(1)})
                Return True
            Else
                Return False
            End If
        End Function
        Public Overrides Async Function 人类响应(源玩家 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型), 目标玩家 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型)) As Task(Of Boolean)
            Await MyBase.人类响应(源玩家, 目标玩家)
            If Await 游戏(Of 图像类型, 鼠标光标, 用户控件类型).当前.窗体.消息框.ShowDialog("是否打出两张闪？", "响应 " + 名称,
                                                消息框按钮枚举.是和否,
                                                消息框样式枚举.消息) =
                                                消息框状态枚举.确定 Then
                Dim ca = Await 目标玩家.选牌({卡牌分类.闪})
                If ca.Count > 1 Then
                    If ca.Count > 2 Then
                        Await 游戏(Of 图像类型, 鼠标光标, 用户控件类型).当前.窗体.消息框.ShowDialog("选择两张闪就够了，点击确定打出选择的前两张闪。", "数量错误",,
                                             消息框样式枚举.警告)
                    End If
                    Await 目标玩家.失去手牌({ca(0), ca(1)})
                    Return True
                End If
            End If
            Return False
        End Function
    End Class
    Public Class 光棱杀(Of 图像类型, 鼠标光标, 用户控件类型)
        Inherits 默认高装甲杀(Of 图像类型, 鼠标光标, 用户控件类型)
        Public Overrides ReadOnly Property 是阵营特定牌 As Boolean = True
        Public Overrides ReadOnly Property 短说明 As String = "此杀击中之后再丢弃一张牌可增加1点伤害"
        Public Overrides ReadOnly Property 长说明 As String = "盟军的光棱武器移动版，此杀击中之后再丢弃一张牌可增加1点伤害"
        Public Overrides ReadOnly Property 特定阵营 As IEnumerable(Of I阵营(Of 图像类型, 鼠标光标, 用户控件类型))
            Get
                Return {New 基本阵营.盟军(Of 图像类型, 鼠标光标, 用户控件类型)}
            End Get
        End Property
        Public Overrides Async Function 响应失败(源玩家 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型), 目标玩家 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型)) As Task
            Await MyBase.响应失败(源玩家, 目标玩家)
            目标玩家.生命值(源玩家) -= 1
            If 源玩家.全部手牌.Count > 0 Then
                If 源玩家.玩家控制 Then
                    If Await 游戏(Of 图像类型, 鼠标光标, 用户控件类型).当前.窗体.消息框.ShowDialog("是否丢弃一张牌增加一点伤害？", "特殊效果： " + 名称,
                                               消息框按钮枚举.是和否,
                                               消息框样式枚举.消息) =
                                               消息框状态枚举.确定 Then
                        Await 源玩家.失去手牌(Await 源玩家.选牌({卡牌分类.Truncate}))
                    Else
                        Return
                    End If
                Else
                    Dim cards = From ca In 源玩家.全部手牌 Group By ca.特性.AI分类 Into First, Count Order By Count Descending
                    Await 源玩家.失去手牌(cards.First.First)
                End If
                目标玩家.生命值(源玩家) -= 1
            End If
        End Function
    End Class
    Public Class 脑车杀(Of 图像类型, 鼠标光标, 用户控件类型)
        Inherits 默认高装甲杀(Of 图像类型, 鼠标光标, 用户控件类型)
        Public Overrides ReadOnly Property 是阵营特定牌 As Boolean = True
        Public Overrides ReadOnly Property 短说明 As String = "此杀击中之后再丢弃一张牌可增加1点伤害"
        Public Overrides ReadOnly Property 长说明 As String = "盟军的光棱武器移动版，此杀击中之后再丢弃一张牌可增加1点伤害"
        Public Overrides ReadOnly Property 特定阵营 As IEnumerable(Of I阵营(Of 图像类型, 鼠标光标, 用户控件类型))
            Get
                Return {New 基本阵营.尤里(Of 图像类型, 鼠标光标, 用户控件类型)}
            End Get
        End Property
        Public Overrides Async Function 响应失败(源玩家 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型), 目标玩家 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型)) As Task
            Await MyBase.响应失败(源玩家, 目标玩家)
            Dim ca = From c In 目标玩家.全部手牌 Where c.特性.免疫心灵控制
            Dim co = ca.Count
            If co > 0 Then
                Await 目标玩家.失去手牌(ca(RndEx(0, co - 1)))
            End If
        End Function
    End Class

    Public Class 日寇入侵(Of 图像类型, 鼠标光标, 用户控件类型)
        Inherits 杀(Of 图像类型, 鼠标光标, 用户控件类型)
        Public Overrides ReadOnly Property AI分类 As Integer
            Get
                Return 卡牌分类.战术_攻击
            End Get
        End Property
        Public Overrides ReadOnly Property 短说明 As String = "升阳帝国海军来捣乱了！"
        Public Overrides ReadOnly Property 长说明 As String = "升阳帝国海军来捣乱了！除了使用者，每人都要打出一张杀或特殊杀，否则受到1点伤害."
        Public Overrides ReadOnly Property 是群攻牌 As Boolean = True

        Public Overrides Async Function AI响应(源玩家 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型), 目标玩家 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型)) As Task(Of Boolean)
            Await MyBase.AI响应(源玩家, 目标玩家)
            Return Await AI响应Internal(源玩家, 目标玩家, {卡牌分类.普通杀,
                                卡牌分类.特殊杀})
        End Function
        Public Overrides Async Function 人类响应(源玩家 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型), 目标玩家 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型)) As Task(Of Boolean)
            Await MyBase.人类响应(源玩家, 目标玩家)
            Return Await HM响应Internal(源玩家, 目标玩家, {卡牌分类.普通杀,
                                卡牌分类.特殊杀})
        End Function
    End Class
    Public Class 鳄鱼突袭(Of 图像类型, 鼠标光标, 用户控件类型)
        Inherits 杀(Of 图像类型, 鼠标光标, 用户控件类型)
        Public Overrides ReadOnly Property AI分类 As Integer
            Get
                Return 卡牌分类.战术_攻击
            End Get
        End Property
        Public Overrides ReadOnly Property 是群攻牌 As Boolean = True
        Public Overrides ReadOnly Property 短说明 As String = "一大群鳄鱼正在接近。。。"
        Public Overrides ReadOnly Property 长说明 As String = "一大群鳄鱼正在接近！使用者阵营之外的玩家需要打出闪"
        Public Overrides Function 筛选玩家(玩家表 As IEnumerable(Of I玩家(Of 图像类型, 鼠标光标, 用户控件类型)), 当前玩家 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型)) As IEnumerable(Of I玩家(Of 图像类型, 鼠标光标, 用户控件类型))
            Return From p In 玩家表 Where p.控制者信息.group = 当前玩家.控制者信息.group
        End Function
    End Class
    Public MustInherit Class 超级武器或发射器(Of 图像类型, 鼠标光标, 用户控件类型)
        Inherits 手牌Base(Of 图像类型, 鼠标光标, 用户控件类型)
        Public Overrides ReadOnly Property AI分类 As Integer = 卡牌分类.超级武器
        Public Overrides ReadOnly Property 出牌阶段能被打出 As Boolean = True
        Public Overrides ReadOnly Property 回合数限制 As Integer = DefaultRoundLimits.SuperWeapon
        Public Overrides ReadOnly Property 是超级武器 As Boolean = True
        Public Overrides ReadOnly Property 科技等级 As Integer = DefaultTechLevels.SuperWeapon
    End Class
    Public Class 力场护盾(Of 图像类型, 鼠标光标, 用户控件类型)
        Inherits 手牌Base(Of 图像类型, 鼠标光标, 用户控件类型)
        Public Overrides ReadOnly Property AI分类 As Integer
            Get
                Return 卡牌分类.战术_协助
            End Get
        End Property
        Public Overrides ReadOnly Property 出牌阶段能被打出 As Boolean = True
        Public Overrides ReadOnly Property 回合数限制 As Integer = DefaultRoundLimits.DefenseAbility
        Public Overrides ReadOnly Property 是红警杀Mod牌 As Boolean = False
        Public Overrides ReadOnly Property 是超级武器 As Boolean = False
        Public Overrides ReadOnly Property 短说明 As String = "下回合1/2几率抵消任何效果"
        Public Overrides ReadOnly Property 科技等级 As Integer = DefaultTechLevels.DefenseAbility
        Public Overrides ReadOnly Property 长说明 As String = "下回合每个效果生效前翻一张新牌，如果是黑色则抵消此次效果。"
        Public Overrides Async Function 响应失败(源玩家 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型), 目标玩家 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型)) As Task
            Await MyBase.响应失败(源玩家, 目标玩家)
            目标玩家.控件表增加标记(源玩家, 游戏(Of 图像类型, 鼠标光标, 用户控件类型).当前.标记管理器.创建标记控件(New 基本标记.力场护盾(Of 图像类型, 鼠标光标, 用户控件类型)))
        End Function
    End Class
    Public Class 核弹发射井(Of 图像类型, 鼠标光标, 用户控件类型)
        Inherits 超级武器或发射器(Of 图像类型, 鼠标光标, 用户控件类型)
        Public Overrides ReadOnly Property 是红警杀Mod牌 As Boolean = False
        Public Overrides ReadOnly Property 短说明 As String = "每5的倍数回合可发射核弹"
        Public Overrides ReadOnly Property 长说明 As String = "每存在5的倍数回合可以发射一枚核弹"
        Public Overrides Async Function 响应失败(源玩家 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型), 目标玩家 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型)) As Task
            Await MyBase.响应失败(源玩家, 目标玩家)
            源玩家.控件表增加标记(源玩家, 游戏(Of 图像类型, 鼠标光标, 用户控件类型).当前.标记管理器.创建标记控件(New 基本标记.核弹读秒(Of 图像类型, 鼠标光标, 用户控件类型)))
        End Function
        Public Overrides Function 筛选玩家(玩家表 As IEnumerable(Of I玩家(Of 图像类型, 鼠标光标, 用户控件类型)), 当前玩家 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型)) As IEnumerable(Of I玩家(Of 图像类型, 鼠标光标, 用户控件类型))
            Return {当前玩家}
        End Function
    End Class
    Public Class 核弹攻击(Of 图像类型, 鼠标光标, 用户控件类型)
        Inherits 超级武器或发射器(Of 图像类型, 鼠标光标, 用户控件类型)
        Public Overrides ReadOnly Property 是红警杀Mod牌 As Boolean = False
        Public Overrides ReadOnly Property 短说明 As String = "向敌人发射核弹"
        Public Overrides ReadOnly Property 长说明 As String = "苏联的科学家用最少的金钱研制了这种杀伤力极强的改良版核弹。仅一枚核弹就能让敌人的基地失去一半的实力。效果：敌生命值减半，每一张黑牌意味着失去一张手牌。对没有牌的1血敌人有秒杀效果。"
        Public Overrides Async Function 响应失败(源玩家 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型), 目标玩家 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型)) As Task
            Await MyBase.响应失败(源玩家, 目标玩家)
            目标玩家.控件表增加标记(源玩家, 游戏(Of 图像类型, 鼠标光标, 用户控件类型).当前.标记管理器.创建标记控件(New 基本标记.核弹发射(Of 图像类型, 鼠标光标, 用户控件类型)))
        End Function
    End Class
#Region "pre_write"
    Public Class 天气控制机(Of 图像类型, 鼠标光标, 用户控件类型)
        Inherits 超级武器或发射器(Of 图像类型, 鼠标光标, 用户控件类型)
        Public Overrides ReadOnly Property 是红警杀Mod牌 As Boolean = False
        Public Overrides ReadOnly Property 短说明 As String = "每5的倍数回合产生闪电风暴"
        Public Overrides ReadOnly Property 长说明 As String = "每5的倍数回合在目标区域产生闪电风暴"
        Public Overrides Async Function 响应失败(源玩家 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型), 目标玩家 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型)) As Task
            Await MyBase.响应失败(源玩家, 目标玩家)
            源玩家.控件表增加标记(源玩家, 游戏(Of 图像类型, 鼠标光标, 用户控件类型).当前.标记管理器.创建标记控件(New 基本标记.闪电读秒(Of 图像类型, 鼠标光标, 用户控件类型)))
        End Function
        Public Overrides Function 筛选玩家(玩家表 As IEnumerable(Of I玩家(Of 图像类型, 鼠标光标, 用户控件类型)), 当前玩家 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型)) As IEnumerable(Of I玩家(Of 图像类型, 鼠标光标, 用户控件类型))
            Return {当前玩家}
        End Function
    End Class
    Public Class 闪电风暴(Of 图像类型, 鼠标光标, 用户控件类型)
        Inherits 超级武器或发射器(Of 图像类型, 鼠标光标, 用户控件类型)
        Public Overrides ReadOnly Property 是红警杀Mod牌 As Boolean = False
        Public Overrides ReadOnly Property 短说明 As String = "在目标区域产生闪电风暴"
        Public Overrides ReadOnly Property 长说明 As String = "盟军的超级武器。立即在目标区域释放充满不祥之气的雷云，在目标回合结束时电闪雷鸣。目标区域将接受8次判定，每一张黑桃2-9产生2点伤害。"
        Public Overrides Async Function 响应失败(源玩家 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型), 目标玩家 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型)) As Task
            Await MyBase.响应失败(源玩家, 目标玩家)
            目标玩家.控件表增加标记(源玩家, 游戏(Of 图像类型, 鼠标光标, 用户控件类型).当前.标记管理器.创建标记控件(New 基本标记.闪电发射(Of 图像类型, 鼠标光标, 用户控件类型)))
        End Function

    End Class
    Public Class 精神控制器(Of 图像类型, 鼠标光标, 用户控件类型)
        Inherits 超级武器或发射器(Of 图像类型, 鼠标光标, 用户控件类型)

        Public Overrides ReadOnly Property 是红警杀Mod牌 As Boolean = False
        Public Overrides ReadOnly Property 短说明 As String = "每5的倍数回合发动心灵激荡"
        Public Overrides ReadOnly Property 长说明 As String = "每5的倍数回合产生心灵激荡攻击"
        Public Overrides Function 筛选玩家(玩家表 As IEnumerable(Of I玩家(Of 图像类型, 鼠标光标, 用户控件类型)), 当前玩家 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型)) As IEnumerable(Of I玩家(Of 图像类型, 鼠标光标, 用户控件类型))
            Return {当前玩家}
        End Function
        Public Overrides Async Function 响应失败(源玩家 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型), 目标玩家 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型)) As Task
            Await MyBase.响应失败(源玩家, 目标玩家)
            源玩家.控件表增加标记(源玩家, 游戏(Of 图像类型, 鼠标光标, 用户控件类型).当前.标记管理器.创建标记控件(New 基本标记.精神控制读秒(Of 图像类型, 鼠标光标, 用户控件类型)))
        End Function
    End Class
    Public Class 心灵激荡(Of 图像类型, 鼠标光标, 用户控件类型)
        Inherits 超级武器或发射器(Of 图像类型, 鼠标光标, 用户控件类型)
        Public Overrides ReadOnly Property 是红警杀Mod牌 As Boolean = False
        Public Overrides ReadOnly Property 短说明 As String = "控制敌人3张牌"
        Public Overrides ReadOnly Property 长说明 As String = "尤里的黑科技，在敌人摸牌后出牌前抢夺最多3张不免疫精神控制的牌"
        Public Overrides Async Function 响应失败(源玩家 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型), 目标玩家 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型)) As Task
            Await MyBase.响应失败(源玩家, 目标玩家)
            目标玩家.控件表增加标记(源玩家, 游戏(Of 图像类型, 鼠标光标, 用户控件类型).当前.标记管理器.创建标记控件(New 基本标记.精神控制发射(Of 图像类型, 鼠标光标, 用户控件类型)(源玩家)))
        End Function
    End Class
#End Region

End Namespace