Namespace 核心.呈现
    ''' <summary>
    ''' 平台无关且不与用户交互
    ''' </summary>
    Public Module 可视元素
        ''' <summary>
        ''' 表示平面中的向量
        ''' </summary>
        Public Structure Vector2
            Public X As Double
            Public Y As Double
            Sub New(X As Double, Y As Double)
                Me.X = X
                Me.Y = Y
            End Sub
        End Structure
        Public Enum 动画状态
            未加载
            未播放
            正在播放
            结束
        End Enum
        Public Interface I多帧生成器
            Function 生成(资源路径 As IEnumerable(Of String), 持续时间 As TimeSpan) As IEnumerable(Of I帧)
        End Interface
        Public Interface I帧
            ReadOnly Property 资源路径 As String
            ReadOnly Property 持续时间 As TimeSpan
        End Interface
        Public Interface I动画
            ReadOnly Property 整体状态 As 动画状态
            Sub 播放全部()
            Sub 停止全部()
            Property 全局偏移 As Vector2
            Property 帧资源 As IEnumerable(Of I帧)
        End Interface
        Public Interface I超级武器动画
            Inherits I动画
            Property 发射动画 As IEnumerable(Of I动画)
            Property 爆炸动画 As IEnumerable(Of I动画)
            Property 子爆炸动画 As IEnumerable(Of I动画)
            Sub 播放目标动画()
            Sub 播放发射动画()
            Sub 播放爆炸动画和子爆炸动画()
        End Interface
    End Module
End Namespace
