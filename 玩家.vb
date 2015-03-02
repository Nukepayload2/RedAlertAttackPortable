Imports 红警杀.核心
Namespace 基元
    Public MustInherit Class 玩家(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型)
        Implements 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I玩家

        Protected 区域 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I玩家区

        Private Alive As Boolean = True
        Public Property 存活 As Boolean Implements 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I玩家.存活
            Get
                Return Alive
            End Get
            Set(value As Boolean)
                Alive = value
                If Not Alive Then 引发玩家出局(Me)
            End Set
        End Property
        Public Property 性格 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).AI性格 Implements 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I玩家.性格
        Public Property 控制者信息 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).玩家信息 Implements 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I玩家.控制者信息
        Public Property 正在出牌 As Boolean Implements 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I玩家.正在出牌
        Dim _玩家控制 As Boolean
        Public Property 难度 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).AI难度 Implements 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I玩家.难度
        Public Property 当前阶段 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).阶段枚举 Implements 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I玩家.当前阶段
        Public Property 连续进行回合计数 As Integer Implements 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I玩家.连续进行回合计数

        Sub New(区域 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I玩家区,
            性格 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).AI性格,
            控制者信息 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).玩家信息,
            玩家控制 As Boolean,
            Optional 难度 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).AI难度 = 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).AI难度.低,
            Optional 存活 As Boolean = True)
            Me.区域 = 区域
            Me.难度 = 难度
            Me.玩家控制 = 玩家控制 '必须在难度之后
            Me.存活 = 存活
            Me.性格 = 性格
            Me.控制者信息 = 控制者信息
            正在出牌 = False
            当前阶段 = 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).阶段枚举.出牌前
            连续进行回合计数 = 0
        End Sub
        Protected MustOverride Property 武将牌有装饰 As Boolean
        Public ReadOnly Property 全部手牌 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I控件表(Of 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I手牌控件) Implements 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I玩家.全部手牌
            Get
                Return 区域.手牌区
            End Get
        End Property

        Public ReadOnly Property 全部标记 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I控件表(Of 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I标记控件) Implements 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I玩家.全部标记
            Get
                Return 区域.武将牌.标记区 'todo:if contain inc else addnew
            End Get
        End Property

        Public Property 玩家控制 As Boolean Implements 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I玩家.玩家控制
            Set(value As Boolean)
                _玩家控制 = value
                难度 = 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).AI难度.非AI
            End Set
            Get
                Return _玩家控制
            End Get
        End Property
        Public ReadOnly Property 选择的手牌 As IEnumerable(Of 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I手牌控件) Implements 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I玩家.选择的手牌
            Get
                Dim lst As New List(Of 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I手牌控件)
                lst.AddRange(From card In 区域.手牌区 Where card.被选中)
                Return lst
            End Get
        End Property
        Protected Overridable Function GetAttackablePlayers(发起者 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I游戏, Player As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I玩家) As IEnumerable(Of 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I玩家)
            Select Case 难度
                Case 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).AI难度.低
                    Dim lst As New List(Of 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I玩家)
                    lst.AddRange(From Pl In 发起者.玩家表 Where Pl.控制者信息.group <> Pl.控制者信息.group)
                    Return lst
                Case Else
                    Throw New NotImplementedException
            End Select
        End Function
        Protected Overridable Function SelectAttackablePlayer(Players As IEnumerable(Of 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I玩家)) As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I玩家
            Select Case 难度
                Case 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).AI难度.低
                    If Players.Count > 0 Then
                        Return Players(RndEx(0, Players.Count - 1))
                    Else
                        Return Nothing
                    End If
                Case Else
                    Throw New NotImplementedException
            End Select
        End Function

        Protected Overridable Function GetHelpablePlayers(发起者 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I游戏, Player As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I玩家) As IEnumerable(Of 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I玩家)
            Select Case 难度
                Case 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).AI难度.低
                    Dim lst As New List(Of 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I玩家)
                    lst.AddRange(From p In 发起者.玩家表 Where p.控制者信息.group = p.控制者信息.group)
                    Return lst
                Case Else
                    Throw New NotImplementedException
            End Select
        End Function
        Protected Overridable Function SelectHelpablePlayer(Players As IEnumerable(Of 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I玩家)) As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I玩家
            Select Case 难度
                Case 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).AI难度.低
                    If Players.Count > 0 Then
                        Return Players(RndEx(0, Players.Count - 1))
                    Else
                        Return Nothing
                    End If
                Case Else
                    Throw New NotImplementedException
            End Select
        End Function
        Protected Overridable Sub 默认攻击手牌处理(发起者 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I游戏, 卡牌 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I手牌控件, IsDangerous As Boolean)
            Select Case 性格
                Case 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).AI性格.激进
                    Dim pl = SelectAttackablePlayer(GetAttackablePlayers(发起者, Me))
                    If pl IsNot Nothing Then 使用手牌(发起者, pl, 卡牌)
                Case Else
                    Throw New NotImplementedException
            End Select
        End Sub
        Protected Overridable Sub 默认协助手牌处理(发起者 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I游戏, 卡牌 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I手牌控件)
            Select Case 性格
                Case 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).AI性格.激进
                    Dim pl = SelectHelpablePlayer(GetHelpablePlayers(发起者, Me))
                    If pl IsNot Nothing Then 使用手牌(发起者, pl, 卡牌)
                Case Else
                    Throw New NotImplementedException
            End Select
        End Sub
        Protected Overridable Sub 默认自用手牌处理(发起者 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I游戏, 卡牌 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I手牌控件, IsDangerous As Boolean)
            Select Case 性格
                Case 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).AI性格.激进
                    使用手牌(发起者, Me, 卡牌)
                Case Else
                    Throw New NotImplementedException
            End Select
        End Sub
        Public Overridable Sub AI出牌(发起者 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I游戏) Implements 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I玩家.AI出牌
            If 出牌阶段公共(发起者) Then
                '出牌
                Select Case 难度
                    Case 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).AI难度.不动
                    '直接结束。什么也不用打
                    Case 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).AI难度.低
                        For i As Integer = 区域.手牌区.Count - 1 To 0 Step -1
                            Dim fl = 区域.手牌区(i).特性.AI分类
                            If fl.Contain(动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).卡牌分类.电厂) OrElse
                                 fl.Contain(动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).卡牌分类.防具装备) Then
                                默认自用手牌处理(发起者, 区域.手牌区(i), False)
                            ElseIf fl.Contain(动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).卡牌分类.高级电厂)
                                默认自用手牌处理(发起者, 区域.手牌区(i), True)
                            ElseIf fl.Contain(动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).卡牌分类.回复系)
                                If 区域.血条.生命上限 > 区域.血条.生命值 Then
                                    使用手牌(发起者, Me, 区域.手牌区(i))
                                End If
                            ElseIf fl.Contain(动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).卡牌分类.普通杀) OrElse
                                 fl.Contain(动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).卡牌分类.特殊杀) OrElse
                                 fl.Contain(动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).卡牌分类.超级武器) OrElse
                                 fl.Contain(动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).卡牌分类.战术_攻击) Then
                                默认攻击手牌处理(发起者, 区域.手牌区(i), False)
                            ElseIf fl.Contain(动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).卡牌分类.战术_冒险) Then
                                默认攻击手牌处理(发起者, 区域.手牌区(i), True)
                            ElseIf fl.Contain(动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).卡牌分类.战术_协助) Then
                                默认协助手牌处理(发起者, 区域.手牌区(i))
                            ElseIf fl.Contain(动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).卡牌分类.未定义的类型) Then
                                Throw New ArgumentNullException("卡牌分类")
                            End If
                        Next
                    Case Else
                        Throw New NotImplementedException("未实现的功能")
                End Select
            End If

            发起者.结束阶段(Me)
        End Sub

        Public Sub AI响应(发起者 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I游戏, 玩家 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I玩家, 卡牌 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I手牌控件) Implements 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I玩家.AI响应
            Dim suc = 卡牌.特性.被响应(发起者, 玩家, Me, New 牌响应EventArgs(Not ValueEffectProc("响应牌", 发起者, Me, 玩家, 卡牌), False))
            ValueEffectProc("响应牌结束", 发起者, Me, 玩家, 卡牌, suc)
        End Sub

        Public ReadOnly Property 手牌上限 As Integer Implements 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I玩家.手牌上限
            Get
                Return 区域.血条.生命值 + 区域.电条.电力值 + 手牌上限附加值
            End Get
        End Property

        Public Property 生命值(发起者 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I游戏, 来源 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I玩家) As Integer Implements 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I玩家.生命值
            Get
                Return 区域.血条.生命值
            End Get
            Set(value As Integer)
                If ValueEffectProc("生命值改变", 发起者, Me, 来源, value) Then
                    区域.血条.生命值 = If(区域.血条.生命上限 > value, value, 区域.血条.生命上限)
                    If 区域.血条.生命值 <= 0 AndAlso StageEffectProc("即将求救", 发起者, Me) Then
                        发起者.玩家求救(Me, New 玩家生死判定EventArgs(True, StageEffectProc("求救开始", 发起者, Me)))
                    End If
                End If
            End Set
        End Property

        Public Property 电力(发起者 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I游戏, 来源 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I玩家) As Integer Implements 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I玩家.电力
            Get
                Return 区域.电条.电力值
            End Get
            Set(value As Integer)
                If ValueEffectProc("电力改变", 发起者, Me, 来源, value) Then
                    区域.电条.电力值 = value
                End If
            End Set
        End Property

        Public ReadOnly Property 将 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I武将控件 Implements 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I玩家.将
            Get
                Return 区域.武将牌
            End Get
        End Property

        Public Property 顺序号 As Integer Implements 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I玩家.顺序号
            Get
                Return 区域.名牌.行动编号
            End Get
            Set(value As Integer)
                区域.名牌.行动编号 = value
            End Set
        End Property

        Public Property 生命值上限(发起者 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I游戏, 来源 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I玩家) As Integer Implements 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I玩家.生命值上限
            Get
                Return 区域.血条.生命上限
            End Get
            Set(value As Integer)
                If ValueEffectProc("生命值上限改变", 发起者, Me, 来源, value) Then
                    区域.血条.生命上限 = value
                    If 区域.血条.生命值 > value Then 区域.血条.生命值 = value
                    If 区域.血条.生命值 <= 0 AndAlso StageEffectProc("即将求救", 发起者, Me) Then
                        发起者.玩家求救(Me, New 玩家生死判定EventArgs(True, True)) '必死无疑
                    End If
                End If
            End Set
        End Property

        Public Property 手牌上限附加值 As Integer = 0 Implements 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I玩家.手牌上限附加值


        ''' <summary>
        ''' 处理武将牌的装饰，标记和摸牌
        ''' </summary>
        ''' <param name="发起者"></param>
        Protected Overridable Async Sub 开始阶段公共(发起者 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I游戏)
            武将牌有装饰 = True
            连续进行回合计数 += 1
            Dim CanGetCards As Boolean = StageEffectProc("开始阶段", 发起者, Me)
            If CanGetCards Then
                当前阶段 = 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).阶段枚举.出牌前
                Dim lc As New List(Of 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I手牌控件)
                For i As Integer = 1 To 发起者.设置.每回合获取手牌数
                    lc.Add(发起者.卡牌管理器.随机手牌)
                Next
                Await 得到手牌(发起者, lc)
            End If
            发起者.出牌阶段(Me)
        End Sub

        '压制Obsolete产生的警告,vb 14 +
#Disable Warning BC40000, BC40008
        ''' <summary>
        ''' 用于处理阶段相关的特效
        ''' </summary>
        ''' <returns>能否通过阶段</returns>
        Protected Overridable Function StageEffectProc(EffectName As String, 游戏 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I游戏, 玩家 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I玩家) As Boolean
            Return WeakEffectProc(EffectName, 游戏, 玩家)
        End Function
        ''' <summary>
        ''' 用于处理值相关的特效,例如生命值改变，牌被响应，牌能不能打出
        ''' </summary>
        ''' <returns>能否通过阶段</returns>
        Protected Overridable Function ValueEffectProc(Of T)(EffectName As String, 游戏 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I游戏, 玩家 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I玩家, 来源 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I玩家, 相关值 As T) As Boolean
            Return WeakEffectProc(EffectName, 游戏, 玩家, 来源, 相关值)
        End Function
        ''' <summary>
        ''' 用于处理与前一阶段相关的值相关的特效,例如牌响应结束
        ''' </summary>
        ''' <returns>能否通过阶段</returns>
        Protected Overridable Function ValueEffectProc(Of T1, T2)(EffectName As String, 游戏 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I游戏, 玩家 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I玩家, 来源 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I玩家, 相关值 As T1, 前一阶段参数 As T2) As Boolean
            Return WeakEffectProc(EffectName, 游戏, 玩家, 来源, 相关值, 前一阶段参数)
        End Function
        ''' <summary>
        ''' 用于处理与源头无关的值相关的特效,例如得到手牌
        ''' </summary>
        ''' <returns>能否通过阶段</returns>
        Protected Overridable Function ValueEffectProcNoSource(Of T)(EffectName As String, 游戏 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I游戏, 玩家 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I玩家, 相关值 As T) As Boolean
            Return WeakEffectProc(EffectName, 游戏, 玩家, 相关值)
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
        Protected Overridable Function WeakEffectProc(StageName As String, ParamArray Params As Object()) As Boolean
            Dim CanPassStage As Boolean = True
            SyncLock 区域
                For Each bj In 区域.武将牌.标记区
                    For Each tj In bj.信息.特技表
                        If tj.启用 AndAlso Not tj.EnterStage(StageName, Params) Then CanPassStage = False
                    Next
                Next
                If CanPassStage Then
                    For Each tj In 区域.武将牌.特性.特有特技表
                        If tj.启用 AndAlso Not tj.EnterStage(StageName, Params) Then CanPassStage = False
                    Next
                End If
            End SyncLock
            Return CanPassStage
        End Function
        ''' <summary>
        ''' 处理标记并返回是否能出牌
        ''' </summary>
        ''' <param name="发起者"></param>
        ''' <returns>是否能出牌</returns>
        Protected Overridable Function 出牌阶段公共(发起者 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I游戏) As Boolean
            Dim CanUseCards As Boolean = StageEffectProc("出牌阶段", 发起者, Me)
            当前阶段 = 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).阶段枚举.出牌时
            Return CanUseCards
        End Function

        ''' <summary>
        ''' 处理标记并返回是否能弃牌
        ''' </summary>
        ''' <param name="发起者"></param>
        ''' <returns>是否能弃牌</returns>
        Protected Overridable Function 结束阶段公共(发起者 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I游戏) As Boolean
            Dim CanRemoveCards As Boolean = StageEffectProc("结束阶段", 发起者, Me)
            当前阶段 = 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).阶段枚举.出牌后
            Return CanRemoveCards
        End Function

        ''' <summary>
        ''' 处理标记并返回是否能弃牌
        ''' </summary>
        ''' <param name="发起者"></param>
        Protected Overridable Sub 结束阶段后公共(发起者 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I游戏)
            Dim CanGoNextStage As Boolean = StageEffectProc("结束阶段之后", 发起者, Me)
            武将牌有装饰 = False
            If Not CanGoNextStage Then
                发起者.出牌阶段(Me)
            Else
                连续进行回合计数 = 0
            End If
        End Sub

        '武将牌
        Public Sub AI开始(发起者 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I游戏) Implements 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I玩家.AI开始
            开始阶段公共(发起者)
        End Sub

        Public Async Sub AI结束(发起者 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I游戏) Implements 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I玩家.AI结束
            If 结束阶段公共(发起者) Then
                '弃牌。
                Select Case 难度
                    Case 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).AI难度.不动
                    '不动的...不弃牌了吧。
                    Case 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).AI难度.低
                        Dim lc As New List(Of 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I手牌控件)
                        Do While 全部手牌.Count - lc.Count > 手牌上限 AndAlso 全部手牌.Count > 0
                            Dim card = 全部手牌(RndEx(0, 全部手牌.Count))
                            If Not lc.Contains(card) Then
                                lc.Add(card)
                            End If
                        Loop
                        Await 失去手牌(发起者, lc)
                    Case Else
                        Throw New NotImplementedException
                End Select
            End If
            结束阶段后公共(发起者)
        End Sub

        Public Async Sub HM出牌(发起者 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I游戏) Implements 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I玩家.HM出牌
            If 出牌阶段公共(发起者) Then
                区域.人类玩家出牌模式 = True
                Dim Cancel As New Threading.CancellationToken
                Cancel.Register(AddressOf 区域.人类玩家过程结束按钮.OnClick)
                Await TaskEx.Delay(发起者.设置.人类玩家出牌超时, Cancel)
                区域.人类玩家出牌模式 = False
            End If
            发起者.结束阶段(Me)
        End Sub

        Public Sub HM响应(发起者 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I游戏, 玩家 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I玩家, 卡牌 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I手牌控件) Implements 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I玩家.HM响应
            卡牌.特性.被响应(发起者, 玩家, Me, New 牌响应EventArgs(Not ValueEffectProc("响应牌", 发起者, Me, 玩家, 卡牌), True))
        End Sub

        Public Sub HM响应超时(发起者 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I游戏, 玩家 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I玩家, 卡牌 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I手牌控件) Implements 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I玩家.HM响应超时
            卡牌.特性.被响应(发起者, 玩家, Me, New 牌响应EventArgs(Not ValueEffectProc("响应牌", 发起者, Me, 玩家, 卡牌), True, True))
        End Sub

        Public Sub HM开始(发起者 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I游戏) Implements 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I玩家.HM开始
            开始阶段公共(发起者)
        End Sub

        Public Async Sub HM结束(发起者 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I游戏) Implements 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I玩家.HM结束
            If 结束阶段公共(发起者) Then
                区域.人类玩家弃牌模式 = True
                Dim Cancel As New Threading.CancellationToken
                Cancel.Register(AddressOf 区域.人类玩家过程结束按钮.OnClick)
                Await TaskEx.Delay(发起者.设置.人类玩家出牌超时, Cancel)
                区域.人类玩家弃牌模式 = False
            End If
            结束阶段后公共(发起者)
        End Sub

        Public Sub 使用手牌(游戏 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I游戏, 目标 As IEnumerable(Of 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I玩家), 卡牌 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I手牌控件) Implements 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I玩家.使用手牌
            If 卡牌.特性.是群攻牌 Then
                目标 = 卡牌.特性.筛选玩家(游戏.玩家表, Me)
            End If
            For Each mb In 目标
                If mb.玩家控制 Then
                    mb.HM响应(游戏, Me, 卡牌)
                Else
                    mb.AI响应(游戏, Me, 卡牌)
                End If
            Next
        End Sub

        Protected Sub EnableNonHealCards(Enable As Boolean)
            EnableNonSpecificCards(Enable, {动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).卡牌分类.回复系})
        End Sub
        Protected Sub EnableNonSpecificCards(Enable As Boolean, type As IEnumerable(Of 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).卡牌分类))
            For Each tp In type
                For Each c In From ca In 全部手牌 Where Not CInt(tp).Contain(ca.特性.AI分类)
                    c.启用 = Enable
                Next
            Next
        End Sub
        Protected Sub EnableSpecificCards(Enable As Boolean, type As IEnumerable(Of 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).卡牌分类))
            For Each tp In type
                For Each c In From ca In 全部手牌 Where CInt(tp).Contain(ca.特性.AI分类)
                    c.启用 = Enable
                Next
            Next
        End Sub

        Public Sub 处理求救(发起者 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I游戏, 玩家 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I玩家, e As 玩家生死判定EventArgs) Implements 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I玩家.处理求救
            If 有某类牌(动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).卡牌分类.回复系) Then
                If 玩家控制 Then
                    If 发起者.窗体.消息框.ShowDialog("是否救" + 玩家.控制者信息.name + ",小组" + 玩家.控制者信息.group + "?", "玩家求救", 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).消息框按钮枚举.是和否) = 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).消息框状态枚举.确定 Then
                        EnableNonHealCards(False)
                        For Each card In 区域.选牌()
                            使用手牌(发起者, 玩家, card)
                        Next
                        EnableNonHealCards(True)
                    End If
                Else
                    For Each c In 全部手牌
                        If c.特性.AI分类 = 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).卡牌分类.回复系 Then
                            使用手牌(发起者, 玩家, c)
                        End If
                        If 玩家.生命值(发起者, Me) > 0 Then Exit For
                    Next
                End If
            End If
        End Sub

        Public Async Function 清空手牌(发起者 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I游戏) As Task(Of IEnumerable(Of 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I手牌控件)) Implements 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I玩家.清空手牌
            Return Await 失去手牌(发起者, 全部手牌)
        End Function

        Public MustOverride Async Function 失去手牌(发起者 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I游戏, 卡牌 As IEnumerable(Of 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I手牌控件)) As Task(Of IEnumerable(Of 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I手牌控件)) Implements 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I玩家.失去手牌

        Public Async Function 失去手牌(发起者 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I游戏, 索引 As Integer) As Task(Of IEnumerable(Of 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I手牌控件)) Implements 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I玩家.失去手牌
            Return Await 失去手牌(发起者, {全部手牌(索引)})
        End Function

        Public Async Function 失去手牌(发起者 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I游戏, 卡牌 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I手牌控件) As Task(Of IEnumerable(Of 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I手牌控件)) Implements 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I玩家.失去手牌
            Return Await 失去手牌(发起者, {卡牌})
        End Function

        Public Async Function 失去选定的手牌(发起者 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I游戏, 卡牌 As IEnumerable(Of 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I手牌控件)) As Task(Of IEnumerable(Of 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I手牌控件)) Implements 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I玩家.失去选定的手牌
            Dim lsele As New List(Of 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I手牌控件)
            For Each c In 全部手牌
                If c.被选中 Then
                    lsele.Add(c)
                End If
            Next
            Return Await 失去手牌(发起者, lsele)
        End Function

        Public Function 存在手牌(发起者 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I游戏, 卡牌 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I手牌控件) As Integer Implements 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I玩家.存在手牌
            Dim i As Integer = 0
            For Each c In 全部手牌
                If c.Equals(卡牌) Then
                    Return i
                End If
                i += 1
            Next
            Return -1
        End Function

        Public Function 存在标记(标记 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I标记控件) As Integer Implements 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I玩家.存在标记
            Dim i As Integer = 0
            For Each c In 全部标记
                If c.Equals(标记) Then
                    Return i
                End If
                i += 1
            Next
            Return -1
        End Function

        Public Async Function 得到手牌(发起者 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I游戏, 卡牌 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I手牌控件) As Task(Of IEnumerable(Of 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I手牌控件)) Implements 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I玩家.得到手牌
            Return Await 得到手牌(发起者, {卡牌})
        End Function

        Public Async Function 随机失去手牌(发起者 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I游戏, 数量 As Integer) As Task(Of IEnumerable(Of 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I手牌控件)) Implements 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I玩家.随机失去手牌
            If 数量 > 全部手牌.Count Then
                Return Await 清空手牌(发起者)
            Else
                Dim ids As New List(Of Integer)
                Dim cards As New List(Of 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I手牌控件)
                Do While ids.Count < 数量
                    Dim ran = RndEx(0, 数量)
                    If Not ids.Contains(ran) Then
                        ids.Add(ran)
                        cards.Add(全部手牌(ran))
                    End If
                Loop
                Return Await 失去手牌(发起者, cards)
            End If
        End Function

        Public Sub 使用手牌(发起者 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I游戏, 目标 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I玩家, 卡牌 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I手牌控件) Implements 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I玩家.使用手牌
            使用手牌(发起者, {目标}, 卡牌)
        End Sub

        Public MustOverride Async Function 得到手牌(发起者 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I游戏, 卡牌 As IEnumerable(Of 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I手牌控件)) As Task(Of IEnumerable(Of 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I手牌控件)) Implements 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I玩家.得到手牌

        Public Function 有某类牌(分类 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).卡牌分类) As Boolean Implements 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I玩家.有某类牌
            Return 有某类牌({分类})
        End Function

        Public Function 选牌(分类 As IEnumerable(Of 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).卡牌分类)) As IEnumerable(Of 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I手牌控件) Implements 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I玩家.选牌
            If 玩家控制 Then
                EnableNonSpecificCards(False, 分类)
                Dim ca = 区域.选牌
                EnableNonSpecificCards(True, 分类)
                Return ca
            Else
                Return From ca In 全部手牌 Where 分类.Contains(ca.特性.AI分类)
            End If
        End Function

        Protected MustOverride Sub 展示手牌Impl(游戏 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I游戏, 卡牌 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I手牌控件)

        Public Function 展示手牌(游戏 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I游戏, 卡牌 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I手牌控件) As Boolean Implements 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I玩家.展示手牌
            If 玩家控制 AndAlso 游戏.窗体.消息框.ShowDialog("是否展示卡牌" + 卡牌.ToString + "？", "展示", 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).消息框按钮枚举.是和否) = 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).消息框状态枚举.确定 OrElse Not 玩家控制 Then
                Dim result As New StrongBox(Of Boolean)
                If ValueEffectProcNoSource("即将展示手牌", 游戏, Me, result) Then 展示手牌Impl(游戏, 卡牌)
                Return result.Value
            Else
                Return False
            End If
        End Function
        Public Function 有某类牌(分类 As IEnumerable(Of 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).卡牌分类)) As Boolean Implements 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I玩家.有某类牌
            For Each fl In 分类
                For Each c In 全部手牌
                    If (c.特性.AI分类 And fl) <> 0 Then
                        Return True
                    End If
                Next
            Next
            Return False
        End Function

        Public Function 取某类牌(分类 As IEnumerable(Of 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).卡牌分类)) As IEnumerable(Of 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I手牌控件) Implements 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I玩家.取某类牌
            Dim ls As New List(Of 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I手牌控件)
            For Each fl In 分类
                For Each c In 全部手牌
                    If (c.特性.AI分类 And fl) <> 0 Then
                        ls.Add(c)
                    End If
                Next
            Next
            Return ls
        End Function

        Public MustOverride Async Function 失去标记(发起者 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I游戏, 卡牌 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I标记控件) As Task(Of IEnumerable(Of 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I标记控件)) Implements 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I玩家.失去标记

        Public MustOverride Async Function 得到标记(发起者 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I游戏, 卡牌 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I标记控件) As Task(Of IEnumerable(Of 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I标记控件)) Implements 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I玩家.得到标记

    End Class

End Namespace
