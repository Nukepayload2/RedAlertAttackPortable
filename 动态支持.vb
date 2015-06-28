
Namespace 核心

#Region "方法"

#End Region

#Region "结构"
    ''' <summary>
    ''' 表示手牌的花色和点数
    ''' </summary>
    Public Structure 花色点数结构
        Public 花色 As 花色枚举
        Public 点数 As String
        Sub New(花色1 As 花色枚举, 点数1 As Integer)
            花色 = 花色1
            Dim tmp = String.Empty
            Select Case 点数1
                Case 1
                    tmp = "A"
                Case 11
                    tmp = "J"
                Case 12
                    tmp = "Q"
                Case 13
                    tmp = "K"
                Case Else
                    tmp = 点数1.ToString
            End Select
            点数 = tmp
        End Sub
    End Structure
    ''' <summary>
    ''' 表示玩家的姓名和分组信息
    ''' </summary>
    Public Structure 玩家信息
        Dim name As String
        Dim group As String
        Shared Operator =(a As 玩家信息, b As 玩家信息) As Boolean
            Return a.name = b.name AndAlso a.group = b.group
        End Operator
        Shared Operator <>(a As 玩家信息, b As 玩家信息) As Boolean
            Return a.name <> b.name OrElse a.group <> b.group
        End Operator
        Sub New(PlayerName As String, GroupName As String)
            name = PlayerName
            group = GroupName
        End Sub
    End Structure
#End Region

#Region "枚举"
    ''' <summary>
    ''' 等同于MsgBoxStyles
    ''' </summary>
    Public Enum 消息框样式枚举
        一般
        消息
        警告
        错误
    End Enum
    ''' <summary>
    ''' 表示消息框上的按钮
    ''' </summary>
    Public Enum 消息框按钮枚举
        确定
        确定和取消
        是
        是和否
    End Enum
    ''' <summary>
    ''' 表示输入框上面的按钮
    ''' </summary>
    Public Enum 输入框按钮枚举
        确定
        确定和取消
        确定和帮助
        全部
    End Enum
    ''' <summary>
    ''' 消息框返回的状态
    ''' </summary>
    Public Enum 消息框状态枚举
        没选
        确定
        取消
    End Enum

    ''' <summary>
    ''' 用于控制AI的出牌方式，通常对高级的AI有效，对简单的意义不大。
    ''' </summary>
    Public Enum AI性格
        固守
        激进
        爆发
        平衡
        游击
    End Enum
    ''' <summary>
    ''' 表示AI思考的复杂程度
    ''' </summary>
    Public Enum AI难度
        非AI
        不动
        低
        中
        高
        极高
    End Enum
    ''' <summary>
    ''' 告诉游戏管理器应该怎样结束当前局
    ''' </summary>
    Public Enum 游戏结束原因
        结束进程
        手动退出
        玩家胜利
        电脑胜利
    End Enum

    ''' <summary>
    ''' 扑克牌的四种花色，在手牌使用这些花色。
    ''' </summary>
    Public Enum 花色枚举
        梅花
        黑桃
        红桃
        方片
    End Enum
    ''' <summary>
    ''' 每个人回合的三种阶段
    ''' </summary>
    Public Enum 阶段枚举
        出牌前
        出牌时
        出牌后
    End Enum

    ''' <summary>
    ''' 用于让AI识别卡牌的类型。 
    ''' 此类型可以用Or运算符来混合多个值
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum 卡牌分类
        未定义的类型 = 0
        回复系 = 1
        普通杀 = 1 << 1
        特殊杀 = 1 << 2
        闪 = 1 << 3
        超级武器 = 1 << 4
        防具装备 = 1 << 5
        战术_攻击 = 1 << 6
        战术_协助 = 1 << 7
        战术_冒险 = 1 << 8
        电厂 = 1 << 9
        高级电厂 = 1 << 10
        Truncate = 1 << 11 - 1
    End Enum
#End Region

#Region "属性和字段"

#End Region
#Region "委托"

#End Region
#Region "接口"

    ''' <summary>
    ''' 各种钩子，用于打造神奇的特效。
    ''' </summary>
    Public Interface I特效(Of 图像类型, 鼠标光标, 用户控件类型)

        ReadOnly Property 附带资源 As IEnumerable(Of KeyValuePair(Of String, String))
        ReadOnly Property 内嵌资源 As IEnumerable(Of KeyValuePair(Of String, Stream))
        ''' <summary>
        ''' 是否已经启用这种特效
        ''' </summary> 
        Property 启用 As Boolean
        ''' <summary>
        ''' 特效的名称
        ''' </summary> 
        ReadOnly Property 名称 As String
        ''' <summary>
        ''' 特效的简短描述
        ''' </summary> 
        ReadOnly Property 说明 As String
        ''' <summary>
        ''' 刚开局时触发的效果
        ''' </summary> 
        Function 开局(相关玩家 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型)) As Task
        ''' <summary>
        ''' 刚结束时触发的效果
        ''' </summary> 
        Function 结束(相关玩家 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型)) As Task
        ''' <summary>
        ''' 玩家战败时触发的效果
        ''' </summary>
        Function 玩家战败(玩家 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型), 战败方 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型)) As Task
        ''' <summary>
        ''' 发牌之前进行的动作。
        ''' 返回False则这回合不能拿牌。
        ''' </summary>
        ''' <returns>这回合能不能拿牌</returns>
        Function 开始阶段(玩家 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型)) As Task(Of Boolean)
        ''' <summary>
        ''' 发牌之后进行的动作。
        ''' 返回False则这回合不能出牌。
        ''' </summary>
        ''' <returns>这回合能不能出牌</returns>
        Function 出牌阶段(玩家 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型)) As Task(Of Boolean)
        ''' <summary>
        ''' 弃牌之前进行的动作。
        ''' 返回False则这回合不能弃牌。
        ''' </summary>
        ''' <returns>这回合能不能弃牌</returns>
        Function 结束阶段(玩家 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型)) As Task(Of Boolean)
        ''' <summary>
        ''' 切换玩家前进行的动作。
        ''' 返回False则这回合不能切换到下家。
        ''' </summary>
        ''' <returns>这回合能不能切换到下家</returns>
        Function 结束阶段之后(玩家 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型)) As Task(Of Boolean)
        ''' <summary>
        ''' 进行到下一回合时触发
        ''' </summary> 
        Function 回合增加() As Task
        ''' <summary>
        ''' 生命值即将改变时触发。返回False则会阻止生命值的变化
        ''' </summary>
        ''' <returns>是否允许生命值的变化</returns>
        Function 生命值改变(玩家 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型), 来源 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型), 新的生命值 As Integer) As Task(Of Boolean)
        ''' <summary>
        ''' 生命值上限即将改变时触发。返回False则会阻止生命值的变化
        ''' </summary> 
        ''' <returns>是否允许生命值上限的变化</returns>
        Function 生命值上限改变(玩家 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型), 来源 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型), 新的生命值 As Integer) As Task(Of Boolean)
        ''' <summary>
        ''' 电力即将改变时触发。返回False则会阻止电力的变化
        ''' </summary> 
        ''' <returns>是否允许电力的变化</returns>
        Function 电力改变(玩家 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型), 来源 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型), 新的电力值 As Integer) As Task(Of Boolean)
        ''' <summary>
        ''' 标记即将增加减少时触发。返回False则会阻止标记的变化
        ''' </summary> 
        ''' <returns>是否允许标记的减少</returns>
        Function 标记减少(玩家 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型), 来源 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型), 变的标记 As IEnumerable(Of I标记(Of 图像类型, 鼠标光标, 用户控件类型))) As Task(Of Boolean)
        ''' <summary>
        ''' 标记即将增加增加时触发。返回False则会阻止标记的变化
        ''' </summary> 
        ''' <returns>是否允许标记的增加</returns>
        Function 标记增加(玩家 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型), 来源 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型), 变的标记 As IEnumerable(Of I标记(Of 图像类型, 鼠标光标, 用户控件类型))) As Task(Of Boolean)
        ''' <summary>
        ''' 返回False则不能从其它区域得到这张牌
        ''' </summary>
        ''' <returns>能否从其它区域得到这张牌</returns>
        Function 手牌增加(玩家 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型), 牌 As I手牌控件(Of 图像类型, 鼠标光标, 用户控件类型)) As Task(Of Boolean)
        ''' <summary>
        ''' 返回False则不能将这张牌移动到弃牌区
        ''' </summary>
        ''' <returns>能否将这张牌移动到弃牌区</returns>
        Function 手牌减少(玩家 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型), 牌 As I手牌控件(Of 图像类型, 鼠标光标, 用户控件类型)) As Task(Of Boolean)
        ''' <summary>
        ''' 返回False则不允许打出这张牌
        ''' </summary>
        ''' <returns>能否打出这张牌</returns>
        Function 打出牌(目标 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型), 来源 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型), 牌 As I手牌控件(Of 图像类型, 鼠标光标, 用户控件类型)) As Task(Of Boolean)
        ''' <summary>
        ''' 返回False则不允许阻止这张牌，直接触发牌的效果。
        ''' </summary>
        ''' <returns>能否阻止这张牌生效</returns>
        Function 响应牌(目标 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型), 来源 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型), 牌 As I手牌控件(Of 图像类型, 鼠标光标, 用户控件类型)) As Task(Of Boolean)
        ''' <summary>
        ''' 已经完成对牌的响应
        ''' </summary> 
        ''' <returns>保留的值</returns>
        Function 响应牌结束(目标 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型), 来源 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型), 牌 As I手牌控件(Of 图像类型, 鼠标光标, 用户控件类型), 成功响应 As Boolean) As Task(Of Boolean)
        ''' <summary>
        ''' 生命值&lt;1时触发
        ''' </summary> 
        ''' <returns>是否进行求救</returns>
        Function 即将求救(玩家 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型)) As Task(Of Boolean)
        ''' <summary>
        ''' 即将求救之后触发
        ''' </summary> 
        ''' <returns>是否立刻认为求救失败</returns>
        Function 求救开始(玩家 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型)) As Task(Of Boolean)
        ''' <summary>
        ''' 控制是否能展示手牌,修改展示的结果
        ''' </summary> 
        ''' <returns>是否显示展示的手牌</returns>
        Function 即将展示手牌(玩家 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型), 展示成功 As StrongBox(Of Boolean)) As Task(Of Boolean)

    End Interface
    ''' <summary>
    ''' 表示武将拥有的武将技能
    ''' </summary>
    Public Interface I武将特技(Of 图像类型, 鼠标光标, 用户控件类型)
        Inherits I特效(Of 图像类型, 鼠标光标, 用户控件类型)
        ReadOnly Property 是阵营特技 As Boolean
    End Interface
    ''' <summary>
    ''' 表示标记拥有的特殊效果
    ''' </summary>
    Public Interface I标记特技(Of 图像类型, 鼠标光标, 用户控件类型)
        Inherits I特效(Of 图像类型, 鼠标光标, 用户控件类型)
        ''' <summary>
        ''' 在增加后触发这个过程
        ''' </summary> 
        Function 增加(玩家 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型)) As Task
        ''' <summary>
        ''' 在减少后触发这个过程
        ''' </summary> 
        Function 减少(玩家 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型)) As Task
        Property 拥有者 As I标记(Of 图像类型, 鼠标光标, 用户控件类型)
    End Interface
    ''' <summary>
    ''' 表示武将牌上附加的标记
    ''' </summary>
    Public Interface I标记(Of 图像类型, 鼠标光标, 用户控件类型)
        Property 数量 As Integer
        ReadOnly Property 特技表 As IList(Of I标记特技(Of 图像类型, 鼠标光标, 用户控件类型))
    End Interface
    ''' <summary>
    ''' 用来播放声音，具体实现是平台相关的
    ''' </summary>
    Public Interface I声音播放器
        ReadOnly Property 背景音乐 As IEnumerable(Of Stream)
        Sub 播放背景音乐()
        Sub 暂停背景音乐()
        Sub 继续背景音乐()
        Sub 下一首()
        Function 播放音效(声音 As Stream) As Task
    End Interface
    ''' <summary>
    ''' 表示一种阵营
    ''' </summary>
    Public Interface I阵营(Of 图像类型, 鼠标光标, 用户控件类型)
        ReadOnly Property 名称 As String
        ReadOnly Property 短说明 As String
        ReadOnly Property 长说明 As String
        ReadOnly Property 固有能力 As IList(Of I武将特技(Of 图像类型, 鼠标光标, 用户控件类型))
        ReadOnly Property 小图标 As 图像类型
        ReadOnly Property 大图标 As 图像类型
        ReadOnly Property 默认阵营色Argb As Integer
    End Interface
    Public Interface I标记管理器(Of 图像类型, 鼠标光标, 用户控件类型)
        Function 创建标记控件(标记 As I标记(Of 图像类型, 鼠标光标, 用户控件类型)) As I标记控件(Of 图像类型, 鼠标光标, 用户控件类型)
    End Interface
    ''' <summary>
    ''' 是一种武将牌选择器
    ''' </summary>
    Public Interface I角色管理器(Of 图像类型, 鼠标光标, 用户控件类型)
        ReadOnly Property 可用阵营 As IList(Of I阵营(Of 图像类型, 鼠标光标, 用户控件类型))
        Function 选择阵营(手动选择 As Boolean) As I阵营(Of 图像类型, 鼠标光标, 用户控件类型)
        Function 选择武将(手动选择 As Boolean) As I武将控件(Of 图像类型, 鼠标光标, 用户控件类型)
    End Interface
    ''' <summary>
    ''' 进行游戏设定
    ''' </summary>
    Public Interface I设置管理器
        Property 多位工程师 As Boolean
        Property 在盟友附近进攻 As Boolean
        Property 离子风暴 As Boolean
        Property 允许红警Mod卡牌 As Boolean
        Property 超级武器 As Boolean
        Property 随机宝箱 As Boolean
        Property 科技等级上限 As Integer
        ''' <summary>
        ''' 每个地图的资源状况不一样。
        ''' 注意这项不能写到设置文件里去
        ''' </summary>
        ''' <returns></returns>
        Property 每回合获取手牌数 As Integer
        Property 人类玩家出牌超时 As TimeSpan
        Function 保存设置() As Task
        Function 读取设置() As Task
    End Interface
    ''' <summary>
    ''' 表示战场的天气
    ''' </summary>
    Public Interface I天气(Of 图像类型, 鼠标光标, 用户控件类型)
        Inherits I特效(Of 图像类型, 鼠标光标, 用户控件类型)
        ''' <summary>
        ''' 影响战场的主题色
        ''' </summary>
        ''' <returns></returns>
        Property 颜色Argb As Integer
    End Interface
    ''' <summary>
    ''' 游戏管理器
    ''' </summary>
    Public Interface I游戏(Of 图像类型, 鼠标光标, 用户控件类型)
        ReadOnly Property 日志 As StringBuilder
        ReadOnly Property 窗体 As I游戏窗口(Of 图像类型, 鼠标光标, 用户控件类型)
        ReadOnly Property 客户区 As I控件表(Of I自制控件(Of 用户控件类型))
        ReadOnly Property 设置 As I设置管理器
        ReadOnly Property 默认图标 As 图像类型
        ReadOnly Property 默认光标 As 鼠标光标
        ReadOnly Property 角色管理器 As I角色管理器(Of 图像类型, 鼠标光标, 用户控件类型)
        ReadOnly Property 存档管理器 As I存档管理器
        ReadOnly Property 卡牌管理器 As I卡牌管理器(Of 图像类型, 鼠标光标, 用户控件类型)
        ReadOnly Property 播放器 As I声音播放器
        ReadOnly Property 标记管理器 As I标记管理器(Of 图像类型, 鼠标光标, 用户控件类型)
        ReadOnly Property 声音资源加载器 As 资源.资源加载器
        ReadOnly Property 图像资源加载器 As 资源.图像资源加载器(Of 图像类型)
        ''' <summary>
        ''' 表示活着的玩家
        ''' </summary>
        ReadOnly Property 玩家表 As IList(Of I玩家(Of 图像类型, 鼠标光标, 用户控件类型))
        ReadOnly Property 回合数 As Integer
        Property 出牌阶段拥有者 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型)
        Function 下家() As I玩家(Of 图像类型, 鼠标光标, 用户控件类型)
        Property 游戏已开始 As Boolean
        Function 玩家求救(发起者 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型), e As 玩家生死判定EventArgs) As Task
        Function 游戏开始() As Task
        Function 开始阶段(玩家 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型)) As Task
        Function 出牌阶段(玩家 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型)) As Task
        Function 结束阶段(玩家 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型)) As Task
        Function 游戏结束(理由 As 游戏结束原因) As Task
    End Interface
    ''' <summary>
    ''' 控制存档读档
    ''' </summary>
    Public Interface I存档管理器
        Function 保存游戏(strm As Stream) As Task
        Function 载入游戏(strm As Stream) As Task
    End Interface
    ''' <summary>
    ''' 可发牌，获取判定牌
    ''' </summary>
    Public Interface I卡牌管理器(Of 图像类型, 鼠标光标, 用户控件类型)
        ReadOnly Property 可用手牌 As IList(Of I手牌控件(Of 图像类型, 鼠标光标, 用户控件类型))
        Function 随机手牌() As I手牌控件(Of 图像类型, 鼠标光标, 用户控件类型)
        Function 新建手牌(卡牌 As I手牌(Of 图像类型, 鼠标光标, 用户控件类型)) As I手牌控件(Of 图像类型, 鼠标光标, 用户控件类型)
    End Interface
    ''' <summary>
    ''' 表示超级武器的特效
    ''' </summary>
    Public Interface I超级武器(Of 图像类型, 鼠标光标, 用户控件类型)
        Inherits I特效(Of 图像类型, 鼠标光标, 用户控件类型)
        Function 投放时(发起者 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型), 目标 As IList(Of I玩家(Of 图像类型, 鼠标光标, 用户控件类型))) As Task
    End Interface
    Public Interface I作弊特效(Of 图像类型, 鼠标光标, 用户控件类型)
        Inherits I特效(Of 图像类型, 鼠标光标, 用户控件类型)
        Function 启用时() As Task(Of Boolean)
        Function 已经启用() As Task
        Function 即将禁用() As Task(Of Boolean)
        Function 已经禁用() As Task
    End Interface
    ''' <summary>
    ''' 牌桌上的玩家
    ''' </summary>
    Public Interface I玩家(Of 图像类型, 鼠标光标, 用户控件类型)
        Property 手牌上限附加值 As Integer
        Property 顺序号 As Integer
        Property 连续进行回合计数 As Integer
        ReadOnly Property 手牌上限 As Integer
        Property 当前阶段 As 阶段枚举
        Property 性格 As AI性格
        Property 难度 As AI难度
        Property 存活 As Boolean
        Property 控制者信息 As 玩家信息
        ReadOnly Property 将 As I武将控件(Of 图像类型, 鼠标光标, 用户控件类型)
        Property 玩家控制 As Boolean
        Property 正在出牌 As Boolean
        ReadOnly Property 全部手牌 As I不变控件表(Of I手牌控件(Of 图像类型, 鼠标光标, 用户控件类型))
        ReadOnly Property 全部标记 As I不变控件表(Of I标记控件(Of 图像类型, 鼠标光标, 用户控件类型))
        ReadOnly Property 选择的手牌 As IEnumerable(Of I手牌控件(Of 图像类型, 鼠标光标, 用户控件类型))
        Property 生命值(来源 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型)) As Integer
        Property 生命值上限(来源 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型)) As Integer
        Property 电力(来源 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型)) As Integer
        Sub 控件表增加手牌(源玩家 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型), 牌 As I手牌控件(Of 图像类型, 鼠标光标, 用户控件类型))
        Sub 控件表删除手牌(源玩家 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型), 牌 As I手牌控件(Of 图像类型, 鼠标光标, 用户控件类型))
        Sub 控件表增加标记(源玩家 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型), 标 As I标记控件(Of 图像类型, 鼠标光标, 用户控件类型))
        Sub 控件表减少标记(源玩家 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型), 标 As I标记控件(Of 图像类型, 鼠标光标, 用户控件类型))
        Function 失去标记(卡牌 As I标记控件(Of 图像类型, 鼠标光标, 用户控件类型)) As Task
        Function 得到标记(卡牌 As I标记控件(Of 图像类型, 鼠标光标, 用户控件类型)) As Task
        Function 失去手牌(卡牌 As I手牌控件(Of 图像类型, 鼠标光标, 用户控件类型)) As Task
        Function 失去手牌(卡牌 As IEnumerable(Of I手牌控件(Of 图像类型, 鼠标光标, 用户控件类型))) As Task
        Function 失去选定的手牌(卡牌 As IEnumerable(Of I手牌控件(Of 图像类型, 鼠标光标, 用户控件类型))) As Task
        Function 失去手牌(索引 As Integer) As Task(Of I手牌控件(Of 图像类型, 鼠标光标, 用户控件类型))
        Function 随机失去手牌(数量 As Integer) As Task(Of IEnumerable(Of I手牌控件(Of 图像类型, 鼠标光标, 用户控件类型)))
        Function 得到手牌(卡牌 As I手牌控件(Of 图像类型, 鼠标光标, 用户控件类型)) As Task
        Function 得到手牌(卡牌 As IEnumerable(Of I手牌控件(Of 图像类型, 鼠标光标, 用户控件类型))) As Task
        Function 获取手牌位置(卡牌 As I手牌控件(Of 图像类型, 鼠标光标, 用户控件类型)) As Integer '存在首个Index否则<0
        Function 获取标记位置(标记 As I标记控件(Of 图像类型, 鼠标光标, 用户控件类型)) As Integer '存在首个Index否则<0
        Function 清空手牌() As Task
        Function 处理求救(目标玩家 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型), e As 玩家生死判定EventArgs) As Task
        Function AI开始() As Task
        Function AI出牌() As Task
        Function AI结束() As Task
        Function AI响应(玩家 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型), 卡牌 As I手牌控件(Of 图像类型, 鼠标光标, 用户控件类型)) As Task
        Function HM开始() As Task
        Function HM出牌() As Task
        Function HM结束() As Task
        Function HM响应(玩家 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型), 卡牌 As I手牌控件(Of 图像类型, 鼠标光标, 用户控件类型)) As Task
        Function HM响应超时(玩家 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型), 卡牌 As I手牌控件(Of 图像类型, 鼠标光标, 用户控件类型)) As Task
        Function 使用手牌(目标 As IEnumerable(Of I玩家(Of 图像类型, 鼠标光标, 用户控件类型)), 卡牌 As I手牌控件(Of 图像类型, 鼠标光标, 用户控件类型)) As Task
        Function 使用手牌(目标 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型), 卡牌 As I手牌控件(Of 图像类型, 鼠标光标, 用户控件类型)) As Task
        '把牌放到弃牌堆，然后收回。返回 True 卡牌展示成功 返回 False 卡牌展示失败
        Function 展示手牌(卡牌 As I手牌控件(Of 图像类型, 鼠标光标, 用户控件类型)) As Task(Of Boolean)
        Function 有某类牌(分类 As Integer) As Boolean
        Function 有某类牌(分类 As IEnumerable(Of 卡牌分类)) As Boolean
        Function 取某类牌(分类 As IEnumerable(Of 卡牌分类)) As IEnumerable(Of I手牌控件(Of 图像类型, 鼠标光标, 用户控件类型))
        ''' <summary>
        ''' 人类或AI在牌区选择特定的手牌.AI会选择全部符合条件的牌
        ''' </summary>
        ''' <param name="分类"></param>
        ''' <returns></returns>
        Function 选牌(分类 As IEnumerable(Of 卡牌分类)) As Task(Of IEnumerable(Of I手牌控件(Of 图像类型, 鼠标光标, 用户控件类型)))
    End Interface
    ''' <summary>
    ''' 小李子外挂的核心
    ''' </summary>
    Public Interface I作弊引擎(Of 图像类型, 鼠标光标, 用户控件类型)
        ReadOnly Property 作弊玩家 As IList(Of I玩家(Of 图像类型, 鼠标光标, 用户控件类型)) '在开局的时候把效果加到玩家身上
        ReadOnly Property 作弊效果 As IList(Of I作弊特效(Of 图像类型, 鼠标光标, 用户控件类型))
    End Interface
    ''' <summary>
    ''' 手牌和将牌的特性
    ''' </summary>
    Public Interface I牌(Of 图像类型, 鼠标光标, 用户控件类型)
        ''' <summary>
        ''' 触屏版 未实施,可设置为Nothing.
        ''' </summary>
        ''' <returns></returns>
        ReadOnly Property 光标 As 鼠标光标
        ReadOnly Property 选择声音 As IEnumerable(Of Stream)
        ReadOnly Property 使用声音 As IEnumerable(Of Stream)
        ReadOnly Property 死亡声音 As IEnumerable(Of Stream)
        ReadOnly Property 图标(阵营 As I阵营(Of 图像类型, 鼠标光标, 用户控件类型)) As 图像类型
        ReadOnly Property 大图标(阵营 As I阵营(Of 图像类型, 鼠标光标, 用户控件类型)) As 图像类型
        ReadOnly Property 是红警杀Mod牌 As Boolean
        ReadOnly Property 名称 As String
        ReadOnly Property 短说明 As String
        ReadOnly Property 长说明 As String
        Function 当初始化完成() As Task
        Function 当生命周期完成() As Task
    End Interface
    ''' <summary>
    ''' 武将的特性
    ''' </summary>
    Public Interface I武将(Of 图像类型, 鼠标光标, 用户控件类型)
        Inherits I牌(Of 图像类型, 鼠标光标, 用户控件类型)
        Property 阵营 As I阵营(Of 图像类型, 鼠标光标, 用户控件类型)
        Property 特有特技表 As IList(Of I武将特技(Of 图像类型, 鼠标光标, 用户控件类型))
    End Interface
    ''' <summary>
    ''' 手牌的特性
    ''' </summary>
    Public Interface I手牌(Of 图像类型, 鼠标光标, 用户控件类型)
        Inherits I牌(Of 图像类型, 鼠标光标, 用户控件类型)
        Function 筛选玩家(玩家表 As IEnumerable(Of I玩家(Of 图像类型, 鼠标光标, 用户控件类型)), 当前玩家 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型)) As IEnumerable(Of I玩家(Of 图像类型, 鼠标光标, 用户控件类型))
        Property 花色和点数 As 花色点数结构
        ReadOnly Property 是黑牌 As Boolean
        ReadOnly Property 是桃牌 As Boolean
        ReadOnly Property AI分类 As Integer '卡牌分类
        ReadOnly Property 免疫心灵控制 As Boolean
        ReadOnly Property 是超级武器 As Boolean
        Sub 随机获得花色点数()
        Function 当得到时(源玩家 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型), 目标玩家 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型)) As Task
        Function 当失去时(源玩家 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型), 目标玩家 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型)) As Task
        Function 被响应(源玩家 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型), 目标玩家 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型), e As 牌响应EventArgs) As Task(Of Boolean)
        ReadOnly Property 科技等级 As Integer
        ReadOnly Property 回合数限制 As Integer
        ReadOnly Property 出牌阶段能被打出 As Boolean
        ReadOnly Property 是群攻牌 As Boolean
        ReadOnly Property 最大目标数量 As Integer
        ReadOnly Property 是阵营特定牌 As Boolean
        ReadOnly Property 特定阵营 As IEnumerable(Of I阵营(Of 图像类型, 鼠标光标, 用户控件类型))
    End Interface

    'UI相关接口
    ''' <summary>
    ''' 所有与UserControl相关操作的UI元素都要实现这个接口。为了UIElementCollection能正常Add,Remove。
    ''' </summary>
    Public Interface I自制控件(Of 用户控件类型)
        ReadOnly Property 本体 As 用户控件类型
        Property 启用 As Boolean
    End Interface
    ''' <summary>
    ''' 武将牌和手牌
    ''' </summary>
    Public Interface I牌控件(Of 用户控件类型)
        Inherits I自制控件(Of 用户控件类型) '在牌框添加和移除
        Property 背面朝上 As Boolean
        Property 被选中 As Boolean
        Function 当点选时() As Task
        Function 更新显示() As Task
    End Interface
    ''' <summary>
    ''' 存放叠加的标记
    ''' </summary>
    Public Interface I标记区(Of 图像类型, 鼠标光标, 用户控件类型)
        Inherits I控件表(Of I标记控件(Of 图像类型, 鼠标光标, 用户控件类型))
    End Interface
    ''' <summary>
    ''' 武将牌上附加的标记控件
    ''' </summary>
    Public Interface I标记控件(Of 图像类型, 鼠标光标, 用户控件类型)
        Inherits I自制控件(Of 用户控件类型) '标记区添加移除
        Property 信息 As I标记(Of 图像类型, 鼠标光标, 用户控件类型)
        Property 字 As String
        Property 说明 As String
        Property 图标 As 图像类型
    End Interface
    ''' <summary>
    ''' 武将槽内的武将牌
    ''' </summary>
    Public Interface I武将控件(Of 图像类型, 鼠标光标, 用户控件类型)
        Inherits I牌控件(Of 用户控件类型)
        ReadOnly Property 标记区 As I标记区(Of 图像类型, 鼠标光标, 用户控件类型)
        Property 特性 As I武将(Of 图像类型, 鼠标光标, 用户控件类型)
        ReadOnly Property 血条 As I血条控件
        ReadOnly Property 电条 As I电条控件
        ReadOnly Property 名牌 As I名牌控件
    End Interface
    ''' <summary>
    ''' 可打出可判定的手牌
    ''' </summary>
    Public Interface I手牌控件(Of 图像类型, 鼠标光标, 用户控件类型)
        Inherits I牌控件(Of 用户控件类型)
        Property 花色 As String
        Property 点数 As String
        Property 特性 As I手牌(Of 图像类型, 鼠标光标, 用户控件类型)
    End Interface

    ''' <summary>
    ''' 让用户输入一段字，相当于InputBox
    ''' </summary>
    Public Interface I输入框
        Function ShowDialog(Prompt As String, Title As String, Optional Buttons As 输入框按钮枚举 = 输入框按钮枚举.确定和取消) As Task(Of String)
    End Interface
    ''' <summary>
    ''' 弹框通知用户或让用户选择，相当于MsgBox
    ''' </summary>
    Public Interface I消息框
        Function ShowDialog(Prompt As String, Title As String, Optional Buttons As 消息框按钮枚举 = 消息框按钮枚举.确定, Optional Style As 消息框样式枚举 = 消息框样式枚举.消息) As Task(Of 消息框状态枚举)
        Function Show(Prompt As String, Title As String, Optional Buttons As 消息框按钮枚举 = 消息框按钮枚举.确定, Optional Style As 消息框样式枚举 = 消息框样式枚举.消息) As Task(Of 消息框状态枚举)
    End Interface
    ''' <summary>
    ''' 弃牌区和人类玩家的牌区
    ''' </summary>
    Public Interface I手牌框(Of 图像类型, 鼠标光标, 用户控件类型)
        Inherits I控件表(Of I手牌控件(Of 图像类型, 鼠标光标, 用户控件类型))
        Overloads Property Left As Double
        Overloads Property Top As Double
        Property Visible As Boolean
        Property Opecity As Double
    End Interface
    ''' <summary>
    ''' 显示玩家的生命值
    ''' </summary>
    Public Interface I血条控件
        Property 生命值 As Integer
        Property 生命上限 As Integer
    End Interface
    ''' <summary>
    ''' 显示电力百分比
    ''' </summary>
    Public Interface I电条控件 '新东西 
        Property 电力值 As Integer
        Property 电力使用 As Integer
    End Interface
    ''' <summary>
    ''' 显示玩家的信息
    ''' </summary>
    Public Interface I名牌控件 '新东西,牌局初始化时更新上面的数据
        Property 玩家名 As String
        Property 小队名 As String
        Property 行动编号 As Integer
    End Interface
    ''' <summary>
    ''' 按钮控件，名称一般是Button
    ''' </summary>
    Public Interface I按钮(Of 用户控件类型)
        Inherits I自制控件(Of 用户控件类型)
        Function OnClick() As Task
    End Interface
    ''' <summary>
    ''' 游戏界面最外层的框架，内容会跟着它移动
    ''' </summary>
    Public Interface I游戏窗口(Of 图像类型, 鼠标光标, 用户控件类型)
        ReadOnly Property 消息框 As I消息框
        ReadOnly Property 输入框 As I输入框
        ReadOnly Property 判定区 As I手牌框(Of 图像类型, 鼠标光标, 用户控件类型)
        ReadOnly Property 图形叠加区 As 呈现.I动画
        Function 显示玩家胜利画面() As Task
        Function 显示玩家战败画面() As Task
        Function 返回标题画面() As Task
        Function 退出应用() As Task
        Function 振动(振幅 As Double, 长度 As TimeSpan) As Task
    End Interface
    ''' <summary>
    ''' 玩家查看或操作当前武将的区域
    ''' </summary>
    Public Interface I玩家区(Of 图像类型, 鼠标光标, 用户控件类型)
        Inherits I自制控件(Of 用户控件类型) '可滚动的玩家框中添加移除
        ReadOnly Property 武将牌 As I武将控件(Of 图像类型, 鼠标光标, 用户控件类型)
        ReadOnly Property 手牌区 As I手牌框(Of 图像类型, 鼠标光标, 用户控件类型)
        Property 人类玩家出牌模式 As Boolean
        Property 人类玩家弃牌模式 As Boolean
        ReadOnly Property 人类玩家过程结束按钮 As I按钮(Of 用户控件类型)
        Function 选牌() As Task(Of IEnumerable(Of I手牌控件(Of 图像类型, 鼠标光标, 用户控件类型)))
    End Interface

    ''' <summary>
    ''' 设备相关的接口 
    ''' </summary>
    Public Interface I设备控制
        Sub 振动(时间 As TimeSpan) '能振动的就振动吧！配合一下游戏区的晃动与音效就完美了！

    End Interface

    ''' <summary>
    ''' 像访问一般的列表那样访问各种内部的控件,而且能获取元素的位置。
    ''' </summary> 
    Public Interface I控件表(Of 用户控件类型)
        Inherits IList(Of 用户控件类型)
        ReadOnly Property Left(Item As 用户控件类型) As Double
        ReadOnly Property Top(Item As 用户控件类型) As Double
    End Interface
    ''' <summary>
    ''' 枚举内部的控件,而且能获取元素的位置。
    ''' </summary> 
    Public Interface I不变控件表(Of 用户控件类型)
        Inherits IEnumerable(Of 用户控件类型)
        ReadOnly Property Left(Item As 用户控件类型) As Double
        ReadOnly Property Top(Item As 用户控件类型) As Double
    End Interface
    Public Interface I可异步表(Of 用户控件类型)
        Inherits IList(Of 用户控件类型)
        Function AddAsync(Item As 用户控件类型) As Task
        Function RemoveAsync(Item As 用户控件类型) As Task
    End Interface
#End Region
End Namespace