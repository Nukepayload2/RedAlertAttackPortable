Imports 红警杀.核心
Imports 红警杀.资源
Namespace 基元
    Public MustInherit Class 游戏(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型)
        Implements 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I游戏
        Public ReadOnly Property 卡牌管理器 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I卡牌管理器 Implements 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I游戏.卡牌管理器
        Public ReadOnly Property 回合数 As Integer Implements 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I游戏.回合数
        Public ReadOnly Property 存档管理器 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I存档管理器 Implements 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I游戏.存档管理器
        Public ReadOnly Property 客户区 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I控件表(Of 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I自制控件) Implements 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I游戏.客户区
        Public ReadOnly Property 播放器 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I声音播放器 Implements 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I游戏.播放器
        Public Property 游戏已开始 As Boolean Implements 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I游戏.游戏已开始
        ''' <summary>
        ''' 没出局都在里面
        ''' </summary>
        ''' <returns></returns>
        Public ReadOnly Property 玩家表 As IList(Of 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I玩家) Implements 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I游戏.玩家表
        Public ReadOnly Property 声音资源加载器 As 资源加载器 Implements 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I游戏.声音资源加载器
        Public ReadOnly Property 图像资源加载器 As 图像资源加载器(Of 图像类型) Implements 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I游戏.图像资源加载器
        Public ReadOnly Property 窗体 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I游戏窗口 Implements 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I游戏.窗体
        Public ReadOnly Property 角色管理器 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I角色管理器 Implements 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I游戏.角色管理器
        Public ReadOnly Property 设置 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I设置管理器 Implements 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I游戏.设置
        Public ReadOnly Property 默认光标 As 鼠标光标 Implements 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I游戏.默认光标
        Public ReadOnly Property 默认图标 As 图像类型 Implements 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I游戏.默认图标
        Sub New(窗体 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I游戏窗口,
            卡牌管理器 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I卡牌管理器,
            存档管理器 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I存档管理器,
            客户区 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I控件表(Of 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I自制控件),
            播放器 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I声音播放器,
            玩家表 As IList(Of 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I玩家),
            角色管理器 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I角色管理器,
            设置 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I设置管理器,
            声音资源加载器 As 资源加载器,
            图像资源加载器 As 图像资源加载器(Of 图像类型))
            Me.窗体 = 窗体
            Me.声音资源加载器 = 声音资源加载器
            Me.图像资源加载器 = 图像资源加载器
            Me.卡牌管理器 = 卡牌管理器
            Me.存档管理器 = 存档管理器
            Me.客户区 = 客户区
            Me.播放器 = 播放器
            Me.玩家表 = New List(Of 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I玩家)
            For Each pl In From p In 玩家表 Order By p.顺序号
                Me.玩家表.Add(pl)
            Next
            Me.角色管理器 = 角色管理器
            Me.设置 = 设置
            回合数 = 0
            游戏已开始 = False
            默认图标 = 图像资源加载器.PngToImage(MissingCameoPngData)
        End Sub
        Public Property 出牌阶段拥有者 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I玩家 Implements 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I游戏.出牌阶段拥有者
        Public ReadOnly Property 日志 As New StringBuilder Implements 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I游戏.日志

        Public Sub 出牌阶段(玩家 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I玩家) Implements 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I游戏.出牌阶段
            出牌阶段拥有者 = 玩家
            If 玩家.玩家控制 Then
                玩家.HM出牌(Me)
            Else
                玩家.AI出牌(Me)
            End If
        End Sub

        Public Sub 开始阶段(玩家 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I玩家) Implements 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I游戏.开始阶段
            If 玩家.玩家控制 Then
                玩家.HM开始(Me)
            Else
                玩家.AI开始(Me)
            End If
        End Sub

        Private Sub OnPlayerOut(SeqID As Integer)
            Dim pdeath = Aggregate p In From pl In 玩家表 Where pl.顺序号 = SeqID Into First
            日志.AppendFormat("小组{1}的玩家{0}已出局：", pdeath.控制者信息.name, pdeath.控制者信息.group)
            If (Aggregate co In From pl In 玩家表 Where pl.存活 Into Count) < 2 Then
                Dim reason As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).游戏结束原因
                If pdeath.玩家控制 Then
                    reason = 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).游戏结束原因.电脑胜利
                Else
                    reason = 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).游戏结束原因.玩家胜利
                End If
                游戏结束(reason)
            End If
        End Sub
        Public Sub 游戏开始() Implements 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I游戏.游戏开始
            AddHandler 玩家出局, AddressOf OnPlayerOut
            SyncLock 玩家表
                For Each p In 玩家表
                    For Each tj In p.将.特性.特有特技表
                        tj.开局(Me, p)
                    Next
                Next
            End SyncLock
            开始阶段(玩家表.First)
        End Sub

        Public Sub 游戏结束(理由 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).游戏结束原因) Implements 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I游戏.游戏结束
            RemoveHandler 玩家出局, AddressOf OnPlayerOut
            SyncLock 玩家表
                For Each p In 玩家表
                    For Each tj In p.将.特性.特有特技表
                        tj.结束(Me, p)
                    Next
                Next
            End SyncLock
            Select Case 理由
                Case 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).游戏结束原因.玩家胜利
                    窗体.显示玩家胜利画面()
                Case 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).游戏结束原因.电脑胜利
                    窗体.显示玩家战败画面()
                Case 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).游戏结束原因.手动退出
                    窗体.返回标题画面()
                Case Else
                    窗体.退出应用()
            End Select
        End Sub

        Public Sub 玩家求救(发起者 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I玩家, e As 玩家生死判定EventArgs) Implements 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I游戏.玩家求救
            If e.不能救活 Then
                发起者.存活 = False
            Else
                If e.需要救治 Then
                    For Each p In From pl In 玩家表 Where pl.存活
                        p.处理求救(Me, 发起者, e)
                    Next
                    If 发起者.生命值(Me, 发起者) < 1 Then
                        发起者.存活 = False
                        玩家表.Remove(发起者)
                    End If
                End If
            End If
        End Sub

        Public Sub 结束阶段(玩家 As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I玩家) Implements 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I游戏.结束阶段
            If 玩家.玩家控制 Then
                玩家.HM结束(Me)
            Else
                玩家.AI结束(Me)
            End If
            开始阶段(下家)
        End Sub

        Public Function 下家() As 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I玩家 Implements 动态支持(Of 鼠标光标, 图像类型, 画刷类型, 用户控件类型).I游戏.下家
            Dim p = From pl In 玩家表 Where pl.存活 Order By pl.顺序号
            If p.Count < 2 Then
                Throw New InvalidOperationException("游戏应该结束，但是仍在获取下家")
            Else
                If p.Last Is 出牌阶段拥有者 Then
                    Return p.First
                Else
                    Return Aggregate a In From n In p Where n.顺序号 > 出牌阶段拥有者.顺序号 Into Min
                End If
            End If
        End Function
    End Class

End Namespace
