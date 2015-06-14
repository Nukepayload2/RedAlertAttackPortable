Imports 红警杀.核心
Namespace 基元
    Public MustInherit Class 玩家(Of 图像类型, 鼠标光标, 用户控件类型)
        Implements I玩家(Of 图像类型, 鼠标光标, 用户控件类型)
        'Protected ReadOnly Property 发起者 As I游戏(Of 图像类型, 鼠标光标, 用户控件类型)
        '    Get
        '        Return 游戏(Of 图像类型, 鼠标光标, 用户控件类型).当前
        '    End Get
        'End Property
        Protected 区域 As I玩家区(Of 图像类型, 鼠标光标, 用户控件类型)

        Private Alive As Boolean = True
        Public Property 存活 As Boolean Implements I玩家(Of 图像类型, 鼠标光标, 用户控件类型).存活
            Get
                Return Alive
            End Get
            Set(value As Boolean)
                Alive = value
                If Not Alive Then 引发玩家出局(Me)
            End Set
        End Property
        Public Property 性格 As AI性格 Implements I玩家(Of 图像类型, 鼠标光标, 用户控件类型).性格
        Public Property 控制者信息 As 玩家信息 Implements I玩家(Of 图像类型, 鼠标光标, 用户控件类型).控制者信息
        Public Property 正在出牌 As Boolean Implements I玩家(Of 图像类型, 鼠标光标, 用户控件类型).正在出牌
        Dim _玩家控制 As Boolean
        Public Property 难度 As AI难度 Implements I玩家(Of 图像类型, 鼠标光标, 用户控件类型).难度
        Public Property 当前阶段 As 阶段枚举 Implements I玩家(Of 图像类型, 鼠标光标, 用户控件类型).当前阶段
        Public Property 连续进行回合计数 As Integer Implements I玩家(Of 图像类型, 鼠标光标, 用户控件类型).连续进行回合计数

        Sub New(区域 As I玩家区(Of 图像类型, 鼠标光标, 用户控件类型),
            性格 As AI性格,
            控制者信息 As 玩家信息,
            玩家控制 As Boolean,
            Optional 难度 As AI难度 = AI难度.低,
            Optional 存活 As Boolean = True)
            Me.区域 = 区域
            Me.难度 = 难度
            Me.玩家控制 = 玩家控制 '必须在难度之后
            Me.存活 = 存活
            Me.性格 = 性格
            Me.控制者信息 = 控制者信息
            正在出牌 = False
            当前阶段 = 阶段枚举.出牌前
            连续进行回合计数 = 0
        End Sub
        Protected MustOverride Property 武将牌有装饰 As Boolean
        Public ReadOnly Property 全部手牌 As I不变控件表(Of I手牌控件(Of 图像类型, 鼠标光标, 用户控件类型)) Implements I玩家(Of 图像类型, 鼠标光标, 用户控件类型).全部手牌
            Get
                Return CType(区域.手牌区, I不变控件表(Of I手牌控件(Of 图像类型, 鼠标光标, 用户控件类型)))
            End Get
        End Property

        Public ReadOnly Property 全部标记 As I不变控件表(Of I标记控件(Of 图像类型, 鼠标光标, 用户控件类型)) Implements I玩家(Of 图像类型, 鼠标光标, 用户控件类型).全部标记
            Get
                Return CType(区域.武将牌.标记区, I不变控件表(Of I标记控件(Of 图像类型, 鼠标光标, 用户控件类型))) 'todo:if contain inc else addnew
            End Get
        End Property

        Public Property 玩家控制 As Boolean Implements I玩家(Of 图像类型, 鼠标光标, 用户控件类型).玩家控制
            Set(value As Boolean)
                _玩家控制 = value
                难度 = AI难度.非AI
            End Set
            Get
                Return _玩家控制
            End Get
        End Property
        Public ReadOnly Property 选择的手牌 As IEnumerable(Of I手牌控件(Of 图像类型, 鼠标光标, 用户控件类型)) Implements I玩家(Of 图像类型, 鼠标光标, 用户控件类型).选择的手牌
            Get
                Dim lst As New List(Of I手牌控件(Of 图像类型, 鼠标光标, 用户控件类型))
                lst.AddRange(From card In 区域.手牌区 Where card.被选中)
                Return lst
            End Get
        End Property
        Protected Overridable Function GetAttackablePlayers(Player As I玩家(Of 图像类型, 鼠标光标, 用户控件类型)) As IEnumerable(Of I玩家(Of 图像类型, 鼠标光标, 用户控件类型))
            Select Case 难度
                Case AI难度.低
                    Dim lst As New List(Of I玩家(Of 图像类型, 鼠标光标, 用户控件类型))
                    lst.AddRange(From Pl In 游戏(Of 图像类型, 鼠标光标, 用户控件类型).当前.玩家表 Where Pl.控制者信息.group <> Pl.控制者信息.group)
                    Return lst
                Case Else
                    Throw New NotImplementedException
            End Select
        End Function
        Protected Overridable Function SelectAttackablePlayer(Players As IEnumerable(Of I玩家(Of 图像类型, 鼠标光标, 用户控件类型))) As I玩家(Of 图像类型, 鼠标光标, 用户控件类型)
            Select Case 难度
                Case AI难度.低
                    If Players.Count > 0 Then
                        Return Players(RndEx(0, Players.Count - 1))
                    Else
                        Return Nothing
                    End If
                Case Else
                    Throw New NotImplementedException
            End Select
        End Function

        Protected Overridable Function GetHelpablePlayers(Player As I玩家(Of 图像类型, 鼠标光标, 用户控件类型)) As IEnumerable(Of I玩家(Of 图像类型, 鼠标光标, 用户控件类型))
            Select Case 难度
                Case AI难度.低
                    Dim lst As New List(Of I玩家(Of 图像类型, 鼠标光标, 用户控件类型))
                    lst.AddRange(From p In 游戏(Of 图像类型, 鼠标光标, 用户控件类型).当前.玩家表 Where p.控制者信息.group = p.控制者信息.group)
                    Return lst
                Case Else
                    Throw New NotImplementedException
            End Select
        End Function
        Protected Overridable Function SelectHelpablePlayer(Players As IEnumerable(Of I玩家(Of 图像类型, 鼠标光标, 用户控件类型))) As I玩家(Of 图像类型, 鼠标光标, 用户控件类型)
            Select Case 难度
                Case AI难度.低
                    If Players.Count > 0 Then
                        Return Players(RndEx(0, Players.Count - 1))
                    Else
                        Return Nothing
                    End If
                Case Else
                    Throw New NotImplementedException
            End Select
        End Function
        Protected Overridable Async Function 默认攻击手牌处理(卡牌 As I手牌控件(Of 图像类型, 鼠标光标, 用户控件类型), IsDangerous As Boolean) As Task
            Select Case 性格
                Case AI性格.激进
                    Dim pl = SelectAttackablePlayer(GetAttackablePlayers(Me))
                    If pl IsNot Nothing Then Await 使用手牌(pl, 卡牌)
                Case Else
                    Throw New NotImplementedException
            End Select
        End Function
        Protected Overridable Async Function 默认协助手牌处理(卡牌 As I手牌控件(Of 图像类型, 鼠标光标, 用户控件类型)) As Task
            Select Case 性格
                Case AI性格.激进
                    Dim pl = SelectHelpablePlayer(GetHelpablePlayers(Me))
                    If pl IsNot Nothing Then Await 使用手牌(pl, 卡牌)
                Case Else
                    Throw New NotImplementedException
            End Select
        End Function
        Protected Overridable Async Function 默认自用手牌处理(卡牌 As I手牌控件(Of 图像类型, 鼠标光标, 用户控件类型), IsDangerous As Boolean) As Task
            Select Case 性格
                Case AI性格.激进
                    Await 使用手牌(Me, 卡牌)
                Case Else
                    Throw New NotImplementedException
            End Select
        End Function
        Public Overridable Async Function AI出牌() As Task Implements I玩家(Of 图像类型, 鼠标光标, 用户控件类型).AI出牌
            If Await 出牌阶段公共() Then
                '出牌
                Select Case 难度
                    Case AI难度.不动
                        '直接结束。什么也不用打
                    Case AI难度.低
                        For i As Integer = 区域.手牌区.Count - 1 To 0 Step -1
                            Dim fl = 区域.手牌区(i).特性.AI分类
                            If fl.Contain(卡牌分类.电厂) OrElse
                                 fl.Contain(卡牌分类.防具装备) Then
                                Await 默认自用手牌处理(区域.手牌区(i), False)
                            ElseIf fl.Contain(卡牌分类.高级电厂)
                                Await 默认自用手牌处理(区域.手牌区(i), True)
                            ElseIf fl.Contain(卡牌分类.回复系)
                                If 区域.血条.生命上限 > 区域.血条.生命值 Then
                                    Await 使用手牌(Me, 区域.手牌区(i))
                                End If
                            ElseIf fl.Contain(卡牌分类.普通杀) OrElse
                                 fl.Contain(卡牌分类.特殊杀) OrElse
                                 fl.Contain(卡牌分类.超级武器) OrElse
                                 fl.Contain(卡牌分类.战术_攻击) Then
                                Await 默认攻击手牌处理(区域.手牌区(i), False)
                            ElseIf fl.Contain(卡牌分类.战术_冒险) Then
                                Await 默认攻击手牌处理(区域.手牌区(i), True)
                            ElseIf fl.Contain(卡牌分类.战术_协助) Then
                                Await 默认协助手牌处理(区域.手牌区(i))
                            ElseIf fl.Contain(卡牌分类.未定义的类型) Then
                                Throw New ArgumentNullException("卡牌分类")
                            End If
                        Next
                    Case Else
                        Throw New NotImplementedException("未实现的功能")
                End Select
            End If
            Await 游戏(Of 图像类型, 鼠标光标, 用户控件类型).当前.结束阶段(Me)
        End Function

        Public Async Function AI响应(玩家 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型), 卡牌 As I手牌控件(Of 图像类型, 鼠标光标, 用户控件类型)) As Task Implements I玩家(Of 图像类型, 鼠标光标, 用户控件类型).AI响应
            Dim suc = 卡牌.特性.被响应(玩家, Me, New 牌响应EventArgs(Not Await ValueEffectProc("响应牌", Me, 玩家, 卡牌), False))
            Await ValueEffectProc("响应牌结束", Me, 玩家, 卡牌, suc)
        End Function

        Public ReadOnly Property 手牌上限 As Integer Implements I玩家(Of 图像类型, 鼠标光标, 用户控件类型).手牌上限
            Get
                Return 区域.血条.生命值 + 区域.电条.电力值 + 手牌上限附加值
            End Get
        End Property

        Public Property 生命值(来源 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型)) As Integer Implements I玩家(Of 图像类型, 鼠标光标, 用户控件类型).生命值
            Get
                Return 区域.血条.生命值
            End Get
            Set(value As Integer)
                If ValueEffectProc("生命值改变", Me, 来源, value).Result Then
                    区域.血条.生命值 = If(区域.血条.生命上限 > value, value, 区域.血条.生命上限)
                    If 区域.血条.生命值 <= 0 AndAlso StageEffectProc("即将求救", Me).Result Then
                        游戏(Of 图像类型, 鼠标光标, 用户控件类型).当前.玩家求救(Me, New 玩家生死判定EventArgs(True, StageEffectProc("求救开始", Me).Result))
                    End If
                End If
            End Set
        End Property

        Public Property 电力(来源 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型)) As Integer Implements I玩家(Of 图像类型, 鼠标光标, 用户控件类型).电力
            Get
                Return 区域.电条.电力值
            End Get
            Set(value As Integer)
                If ValueEffectProc("电力改变", Me, 来源, value).Result Then
                    区域.电条.电力值 = value
                End If
            End Set
        End Property

        Public ReadOnly Property 将 As I武将控件(Of 图像类型, 鼠标光标, 用户控件类型) Implements I玩家(Of 图像类型, 鼠标光标, 用户控件类型).将
            Get
                Return 区域.武将牌
            End Get
        End Property

        Public Property 顺序号 As Integer Implements I玩家(Of 图像类型, 鼠标光标, 用户控件类型).顺序号
            Get
                Return 区域.名牌.行动编号
            End Get
            Set(value As Integer)
                区域.名牌.行动编号 = value
            End Set
        End Property

        Public Property 生命值上限(来源 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型)) As Integer Implements I玩家(Of 图像类型, 鼠标光标, 用户控件类型).生命值上限
            Get
                Return 区域.血条.生命上限
            End Get
            Set(value As Integer)
                If ValueEffectProc("生命值上限改变", Me, 来源, value).Result Then
                    区域.血条.生命上限 = value
                    If 区域.血条.生命值 > value Then 区域.血条.生命值 = value
                    If 区域.血条.生命值 <= 0 AndAlso StageEffectProc("即将求救", Me).Result Then
                        游戏(Of 图像类型, 鼠标光标, 用户控件类型).当前.玩家求救(Me, New 玩家生死判定EventArgs(True, True)) '必死无疑
                    End If
                End If
            End Set
        End Property

        Public Property 手牌上限附加值 As Integer = 0 Implements I玩家(Of 图像类型, 鼠标光标, 用户控件类型).手牌上限附加值


        ''' <summary>
        ''' 处理武将牌的装饰，标记和摸牌
        ''' </summary> 
        Protected Overridable Async Function 开始阶段公共() As Task
            武将牌有装饰 = True
            连续进行回合计数 += 1
            Dim CanGetCards As Boolean = Await StageEffectProc("开始阶段", Me)
            If CanGetCards Then
                当前阶段 = 阶段枚举.出牌前
                Dim lc As New List(Of I手牌控件(Of 图像类型, 鼠标光标, 用户控件类型))
                For i As Integer = 1 To 游戏(Of 图像类型, 鼠标光标, 用户控件类型).当前.设置.每回合获取手牌数
                    lc.Add(游戏(Of 图像类型, 鼠标光标, 用户控件类型).当前.卡牌管理器.随机手牌)
                Next
                Await 得到手牌(lc)
            End If
            Await 游戏(Of 图像类型, 鼠标光标, 用户控件类型).当前.出牌阶段(Me)
        End Function

        '压制Obsolete产生的警告,vb 14 +
#Disable Warning BC40000, BC40008
        ''' <summary>
        ''' 用于处理阶段相关的特效
        ''' </summary>
        ''' <returns>能否通过阶段</returns>
        Protected Overridable Async Function StageEffectProc(EffectName As String, 玩家 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型)) As Task(Of Boolean)
            Return Await WeakEffectProc(EffectName, 玩家)
        End Function
        ''' <summary>
        ''' 用于处理值相关的特效,例如生命值改变，牌被响应，牌能不能打出
        ''' </summary>
        ''' <returns>能否通过阶段</returns>
        Protected Overridable Async Function ValueEffectProc(Of T)(EffectName As String, 玩家 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型), 来源 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型), 相关值 As T) As Task(Of Boolean)
            Return Await WeakEffectProc(EffectName, 玩家, 来源, 相关值)
        End Function
        ''' <summary>
        ''' 用于处理与前一阶段相关的值相关的特效,例如牌响应结束
        ''' </summary>
        ''' <returns>能否通过阶段</returns>
        Protected Overridable Async Function ValueEffectProc(Of T1, T2)(EffectName As String, 玩家 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型), 来源 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型), 相关值 As T1, 前一阶段参数 As T2) As Task(Of Boolean)
            Return Await WeakEffectProc(EffectName, 玩家, 来源, 相关值, 前一阶段参数)
        End Function
        ''' <summary>
        ''' 用于处理与源头无关的值相关的特效,例如得到手牌
        ''' </summary>
        ''' <returns>能否通过阶段</returns>
        Protected Overridable Async Function ValueEffectProcNoSource(Of T)(EffectName As String, 玩家 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型), 相关值 As T) As Task(Of Boolean)
            Return Await WeakEffectProc(EffectName, 玩家, 相关值)
        End Function
#Enable Warning BC40000, BC40008

        ''' <summary>
        ''' 基于反射的弱类型特效处理。用于判断是否能通过目标阶段。
        ''' 不要直接使用这个API，直接用非常容易出错。
        ''' </summary>
        ''' <param name="StageName">阶段名称，必须匹配函数名</param>
        ''' <param name="Params">调用这个阶段时应使用的参数</param>
        ''' <returns>是否能通过相应的阶段</returns>
        <Obsolete("为了提高安全性，请改用ValueChangeEffectProcNoSource,ValueChangeEffectProc或StageEffectProc等强类型的API")>
        Protected Overridable Async Function WeakEffectProc(StageName As String, ParamArray Params As Object()) As Task(Of Boolean)
            Dim CanPassStage As Boolean = True
            For Each bj In 区域.武将牌.标记区
                For Each tj In bj.信息.特技表
                    If tj.启用 AndAlso Not Await tj.EnterStage(StageName, Params) Then CanPassStage = False
                Next
            Next
            If CanPassStage Then
                For Each tj In 区域.武将牌.特性.特有特技表
                    If tj.启用 AndAlso Not Await tj.EnterStage(StageName, Params) Then CanPassStage = False
                Next
            End If
            Return CanPassStage
        End Function
        ''' <summary>
        ''' 处理标记并返回是否能出牌
        ''' </summary> 
        ''' <returns>是否能出牌</returns>
        Protected Overridable Async Function 出牌阶段公共() As Task(Of Boolean)
            Dim CanUseCards As Boolean = Await StageEffectProc("出牌阶段", Me)
            当前阶段 = 阶段枚举.出牌时
            Return CanUseCards
        End Function

        ''' <summary>
        ''' 处理标记并返回是否能弃牌
        ''' </summary> 
        ''' <returns>是否能弃牌</returns>
        Protected Overridable Async Function 结束阶段公共() As Task(Of Boolean)
            Dim CanRemoveCards As Boolean = Await StageEffectProc("结束阶段", Me)
            当前阶段 = 阶段枚举.出牌后
            Return CanRemoveCards
        End Function

        ''' <summary>
        ''' 处理标记并返回是否能弃牌
        ''' </summary> 
        Protected Overridable Async Sub 结束阶段后公共()
            Dim CanGoNextStage As Boolean = Await StageEffectProc("结束阶段之后", Me)
            武将牌有装饰 = False
            If Not CanGoNextStage Then
                Await 游戏(Of 图像类型, 鼠标光标, 用户控件类型).当前.出牌阶段(Me)
            Else
                连续进行回合计数 = 0
            End If
        End Sub

        '武将牌
        Public Async Function AI开始() As Task Implements I玩家(Of 图像类型, 鼠标光标, 用户控件类型).AI开始
            Await 开始阶段公共()
        End Function

        Public Async Function AI结束() As Task Implements I玩家(Of 图像类型, 鼠标光标, 用户控件类型).AI结束
            If Await 结束阶段公共() Then
                '弃牌。
                Select Case 难度
                    Case AI难度.不动
                        '不动的...不弃牌了吧。
                    Case AI难度.低
                        Dim lc As New List(Of I手牌控件(Of 图像类型, 鼠标光标, 用户控件类型))
                        Do While 全部手牌.Count - lc.Count > 手牌上限 AndAlso 全部手牌.Count > 0
                            Dim card = 全部手牌(RndEx(0, 全部手牌.Count))
                            If Not lc.Contains(card) Then
                                lc.Add(card)
                            End If
                        Loop
                        Await 失去手牌(lc)
                    Case Else
                        Throw New NotImplementedException
                End Select
            End If
            结束阶段后公共()
        End Function

        Public Async Function HM出牌() As Task Implements I玩家(Of 图像类型, 鼠标光标, 用户控件类型).HM出牌
            If Await 出牌阶段公共() Then
                区域.人类玩家出牌模式 = True
                Dim Cancel As New Threading.CancellationToken
                Cancel.Register(AddressOf 区域.人类玩家过程结束按钮.OnClick)
                Await TaskEx.Delay(游戏(Of 图像类型, 鼠标光标, 用户控件类型).当前.设置.人类玩家出牌超时, Cancel)
                区域.人类玩家出牌模式 = False
            End If
            Await 游戏(Of 图像类型, 鼠标光标, 用户控件类型).当前.结束阶段(Me)
        End Function

        Public Async Function HM响应(玩家 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型), 卡牌 As I手牌控件(Of 图像类型, 鼠标光标, 用户控件类型)) As Task Implements I玩家(Of 图像类型, 鼠标光标, 用户控件类型).HM响应
            Await 卡牌.特性.被响应(玩家, Me, New 牌响应EventArgs(Not Await ValueEffectProc("响应牌", Me, 玩家, 卡牌), True))
        End Function

        Public Async Function HM响应超时(玩家 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型), 卡牌 As I手牌控件(Of 图像类型, 鼠标光标, 用户控件类型)) As Task Implements I玩家(Of 图像类型, 鼠标光标, 用户控件类型).HM响应超时
            Await 卡牌.特性.被响应(玩家, Me, New 牌响应EventArgs(Not Await ValueEffectProc("响应牌", Me, 玩家, 卡牌), True, True))
        End Function

        Public Async Function HM开始() As Task Implements I玩家(Of 图像类型, 鼠标光标, 用户控件类型).HM开始
            Await 开始阶段公共()
        End Function

        Public Async Function HM结束() As Task Implements I玩家(Of 图像类型, 鼠标光标, 用户控件类型).HM结束
            If Await 结束阶段公共() Then
                区域.人类玩家弃牌模式 = True
                Dim Cancel As New Threading.CancellationToken
                Cancel.Register(AddressOf 区域.人类玩家过程结束按钮.OnClick)
                Await TaskEx.Delay(游戏(Of 图像类型, 鼠标光标, 用户控件类型).当前.设置.人类玩家出牌超时, Cancel)
                区域.人类玩家弃牌模式 = False
            End If
            结束阶段后公共()
        End Function

        Public Async Function 使用手牌(目标 As IEnumerable(Of I玩家(Of 图像类型, 鼠标光标, 用户控件类型)), 卡牌 As I手牌控件(Of 图像类型, 鼠标光标, 用户控件类型)) As Task Implements I玩家(Of 图像类型, 鼠标光标, 用户控件类型).使用手牌
            If 卡牌.特性.是群攻牌 Then
                目标 = 卡牌.特性.筛选玩家(游戏(Of 图像类型, 鼠标光标, 用户控件类型).当前.玩家表, Me)
            End If
            For Each mb In 目标
                If mb.玩家控制 Then
                    Await mb.HM响应(Me, 卡牌)
                Else
                    Await mb.AI响应(Me, 卡牌)
                End If
            Next
        End Function

        Protected Sub EnableNonHealCards(Enable As Boolean)
            EnableNonSpecificCards(Enable, {卡牌分类.回复系})
        End Sub
        Protected Sub EnableNonSpecificCards(Enable As Boolean, type As IEnumerable(Of 卡牌分类))
            For Each tp In type
                For Each c In From ca In 全部手牌 Where Not CInt(tp).Contain(ca.特性.AI分类)
                    c.启用 = Enable
                Next
            Next
        End Sub
        Protected Sub EnableSpecificCards(Enable As Boolean, type As IEnumerable(Of 卡牌分类))
            For Each tp In type
                For Each c In From ca In 全部手牌 Where CInt(tp).Contain(ca.特性.AI分类)
                    c.启用 = Enable
                Next
            Next
        End Sub

        Public Async Function 处理求救(玩家 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型), e As 玩家生死判定EventArgs) As Task Implements I玩家(Of 图像类型, 鼠标光标, 用户控件类型).处理求救
            If 有某类牌(卡牌分类.回复系) Then
                If 玩家控制 Then
                    If Await 游戏(Of 图像类型, 鼠标光标, 用户控件类型).当前.窗体.消息框.ShowDialog("是否救" + 玩家.控制者信息.name + ",小组" + 玩家.控制者信息.group + "?", "玩家求救", 消息框按钮枚举.是和否) = 消息框状态枚举.确定 Then
                        EnableNonHealCards(False)
                        For Each card In Await 区域.选牌()
                            Await 使用手牌(玩家, card)
                        Next
                        EnableNonHealCards(True)
                    End If
                Else
                    For Each c In 全部手牌
                        If c.特性.AI分类 = 卡牌分类.回复系 Then
                            Await 使用手牌(玩家, c)
                        End If
                        If 玩家.生命值(Me) > 0 Then Exit For
                    Next
                End If
            End If
        End Function

        Public Async Function 清空手牌() As Task Implements I玩家(Of 图像类型, 鼠标光标, 用户控件类型).清空手牌
            Await 失去手牌(全部手牌)
        End Function


        Public Async Function 失去手牌(索引 As Integer) As Task(Of I手牌控件(Of 图像类型, 鼠标光标, 用户控件类型)) Implements I玩家(Of 图像类型, 鼠标光标, 用户控件类型).失去手牌
            Dim r = 全部手牌(索引)
            Await 失去手牌({全部手牌(索引)})
            Return r
        End Function

        Public Async Function 失去手牌(卡牌 As I手牌控件(Of 图像类型, 鼠标光标, 用户控件类型)) As Task Implements I玩家(Of 图像类型, 鼠标光标, 用户控件类型).失去手牌
            Await 失去手牌({卡牌})
        End Function

        Public Async Function 失去选定的手牌(卡牌 As IEnumerable(Of I手牌控件(Of 图像类型, 鼠标光标, 用户控件类型))) As Task Implements I玩家(Of 图像类型, 鼠标光标, 用户控件类型).失去选定的手牌
            Dim lsele As New List(Of I手牌控件(Of 图像类型, 鼠标光标, 用户控件类型))
            For Each c In 全部手牌
                If c.被选中 Then
                    lsele.Add(c)
                End If
            Next
            Await 失去手牌(lsele)
        End Function

        Public Function 获取手牌位置(卡牌 As I手牌控件(Of 图像类型, 鼠标光标, 用户控件类型)) As Integer Implements I玩家(Of 图像类型, 鼠标光标, 用户控件类型).获取手牌位置
            Dim i As Integer = 0
            For Each c In 全部手牌
                If c.Equals(卡牌) Then
                    Return i
                End If
                i += 1
            Next
            Return -1
        End Function

        Public Function 获取标记位置(标记 As I标记控件(Of 图像类型, 鼠标光标, 用户控件类型)) As Integer Implements I玩家(Of 图像类型, 鼠标光标, 用户控件类型).获取标记位置
            Dim i As Integer = 0
            For Each c In 全部标记
                If c.Equals(标记) Then
                    Return i
                End If
                i += 1
            Next
            Return -1
        End Function

        Public Async Function 得到手牌(卡牌 As I手牌控件(Of 图像类型, 鼠标光标, 用户控件类型)) As Task Implements I玩家(Of 图像类型, 鼠标光标, 用户控件类型).得到手牌
            Await 得到手牌({卡牌})
        End Function

        Public Async Function 随机失去手牌(数量 As Integer) As Task(Of IEnumerable(Of I手牌控件(Of 图像类型, 鼠标光标, 用户控件类型))) Implements I玩家(Of 图像类型, 鼠标光标, 用户控件类型).随机失去手牌
            If 数量 > 全部手牌.Count Then
                Dim r = 全部手牌.ToArray
                Await 清空手牌()
                Return r
            Else
                Dim ids As New List(Of Integer)
                Dim cards As New List(Of I手牌控件(Of 图像类型, 鼠标光标, 用户控件类型))
                Do While ids.Count < 数量
                    Dim ran = RndEx(0, 数量)
                    If Not ids.Contains(ran) Then
                        ids.Add(ran)
                        cards.Add(全部手牌(ran))
                    End If
                Loop
                Dim r = cards.ToArray
                Await 失去手牌(cards)
                Return r
            End If
        End Function

        Public Async Function 使用手牌(目标 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型), 卡牌 As I手牌控件(Of 图像类型, 鼠标光标, 用户控件类型)) As Task Implements I玩家(Of 图像类型, 鼠标光标, 用户控件类型).使用手牌
            Await 使用手牌({目标}, 卡牌)
        End Function
        Public MustOverride Async Function 失去手牌(卡牌 As IEnumerable(Of I手牌控件(Of 图像类型, 鼠标光标, 用户控件类型))) As Task Implements I玩家(Of 图像类型, 鼠标光标, 用户控件类型).失去手牌

        Public MustOverride Async Function 得到手牌(卡牌 As IEnumerable(Of I手牌控件(Of 图像类型, 鼠标光标, 用户控件类型))) As Task Implements I玩家(Of 图像类型, 鼠标光标, 用户控件类型).得到手牌

        Public Async Function 选牌(分类 As IEnumerable(Of 卡牌分类)) As Task(Of IEnumerable(Of I手牌控件(Of 图像类型, 鼠标光标, 用户控件类型))) Implements I玩家(Of 图像类型, 鼠标光标, 用户控件类型).选牌
            If 玩家控制 Then
                EnableNonSpecificCards(False, 分类)
                Dim ca = Await 区域.选牌
                EnableNonSpecificCards(True, 分类)
                Return ca
            Else
                Return From ca In 全部手牌 Where 分类.Contains(ca.特性.AI分类)
            End If
        End Function

        Protected MustOverride Function 展示手牌Impl(卡牌 As I手牌控件(Of 图像类型, 鼠标光标, 用户控件类型)) As Task

        Public Async Function 展示手牌(卡牌 As I手牌控件(Of 图像类型, 鼠标光标, 用户控件类型)) As Task(Of Boolean) Implements I玩家(Of 图像类型, 鼠标光标, 用户控件类型).展示手牌
            If 玩家控制 AndAlso Await 游戏(Of 图像类型, 鼠标光标, 用户控件类型).当前.窗体.消息框.ShowDialog("是否展示卡牌" + 卡牌.ToString + "？", "展示", 消息框按钮枚举.是和否) = 消息框状态枚举.确定 OrElse Not 玩家控制 Then
                Dim result As New StrongBox(Of Boolean)
                If Await ValueEffectProcNoSource("即将展示手牌", Me, result) Then
                    Await 展示手牌Impl(卡牌)
                End If
                Return result.Value
            Else
                Return False
            End If
        End Function
        Public Function 有某类牌(分类 As IEnumerable(Of 卡牌分类)) As Boolean Implements I玩家(Of 图像类型, 鼠标光标, 用户控件类型).有某类牌
            For Each fl In 分类
                For Each c In 全部手牌
                    If (c.特性.AI分类 And fl) <> 0 Then
                        Return True
                    End If
                Next
            Next
            Return False
        End Function

        Public Function 取某类牌(分类 As IEnumerable(Of 卡牌分类)) As IEnumerable(Of I手牌控件(Of 图像类型, 鼠标光标, 用户控件类型)) Implements I玩家(Of 图像类型, 鼠标光标, 用户控件类型).取某类牌
            Dim ls As New List(Of I手牌控件(Of 图像类型, 鼠标光标, 用户控件类型))
            For Each fl In 分类
                For Each c In 全部手牌
                    If (c.特性.AI分类 And fl) <> 0 Then
                        ls.Add(c)
                    End If
                Next
            Next
            Return ls
        End Function
        Protected Friend MustOverride Async Function 播放失去标记动画() As Task
        Protected Friend MustOverride Async Function 播放得到标记动画() As Task
        Public Async Function 失去标记(标记 As I标记控件(Of 图像类型, 鼠标光标, 用户控件类型)) As Task Implements I玩家(Of 图像类型, 鼠标光标, 用户控件类型).失去标记
            If Await ValueEffectProcNoSource("标记减少", Me, 标记) Then
                区域.武将牌.标记区.Remove(标记)
                Await 播放失去标记动画()
            End If
        End Function
        Public Async Function 得到标记(标记 As I标记控件(Of 图像类型, 鼠标光标, 用户控件类型)) As Task Implements I玩家(Of 图像类型, 鼠标光标, 用户控件类型).得到标记
            If Await ValueEffectProcNoSource("标记增加", Me, 标记) Then
                区域.武将牌.标记区.Add(标记)
                Await 播放得到标记动画()
            End If
        End Function
        Public Async Sub 控件表增加手牌(玩家 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型), 牌 As I手牌控件(Of 图像类型, 鼠标光标, 用户控件类型)) Implements I玩家(Of 图像类型, 鼠标光标, 用户控件类型).控件表增加手牌
            Await 得到手牌(牌)
            Await 牌.特性.当得到时(玩家, Me)
        End Sub

        Public Async Sub 控件表删除手牌(玩家 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型), 牌 As I手牌控件(Of 图像类型, 鼠标光标, 用户控件类型)) Implements I玩家(Of 图像类型, 鼠标光标, 用户控件类型).控件表删除手牌
            Await 牌.特性.当失去时(玩家, Me)
            Await 失去手牌(牌)
        End Sub

        Public Async Sub 控件表增加标记(玩家 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型), 标 As I标记控件(Of 图像类型, 鼠标光标, 用户控件类型)) Implements I玩家(Of 图像类型, 鼠标光标, 用户控件类型).控件表增加标记
            For Each bj In 区域.武将牌.标记区
                If bj.信息.GetType.FullName = 标.信息.GetType.FullName Then
                    bj.信息.数量 += 1
                    For Each tj In bj.信息.特技表
                        Await tj.增加(玩家)
                    Next
                    Return
                End If
            Next
            Await 得到标记(标)
            For Each tj In 标.信息.特技表
                Await tj.增加(玩家)
            Next
        End Sub

        Public Async Sub 控件表减少标记(玩家 As I玩家(Of 图像类型, 鼠标光标, 用户控件类型), 标 As I标记控件(Of 图像类型, 鼠标光标, 用户控件类型)) Implements I玩家(Of 图像类型, 鼠标光标, 用户控件类型).控件表减少标记
            For Each bj In 区域.武将牌.标记区
                If bj.信息.GetType.FullName = 标.信息.GetType.FullName Then
                    If bj.信息.数量 > 1 Then
                        bj.信息.数量 -= 1
                    Else
                        Await 失去标记(bj)
                    End If
                    For Each tj In bj.信息.特技表
                        Await tj.减少(玩家)
                    Next
                    Return
                End If
            Next
        End Sub

        Public Function 有某类牌(分类 As Integer) As Boolean Implements I玩家(Of 图像类型, 鼠标光标, 用户控件类型).有某类牌
            Return 有某类牌((Iterator Function()
                             For i = 0 To CInt(Math.Log(卡牌分类.Truncate) / Math.Log(2)) - 1
                                 Dim v = (分类 And 1 << i)
                                 If v <> 0 Then
                                     Yield CType(v, 卡牌分类)
                                 End If
                             Next
                         End Function).Invoke)
        End Function
    End Class

End Namespace
