Imports System.Runtime.CompilerServices
Imports System.Reflection
''' <summary>
''' 为了帮助更容易地编写SDK的代码而出现的模块.这些内容与红警杀没有直接关系。
''' </summary>
''' <remarks></remarks>
<HideModuleName()>
Friend Module 语言拓展
    Dim ran As New Random
    ''' <summary>
    ''' 产生随机整数
    ''' </summary> 
    ''' <returns></returns>
    Public Function RndEx(从 As Integer, 到 As Integer) As Integer
        Return CInt(从 - 0.5 + (ran.NextDouble * (到 - 从 + 1)))
    End Function
    <Extension>
    Public Function EnterStage(Of T1, T2, T3, T4)(tj As 红警杀.核心.动态支持(Of T1, T2, T3, T4).I特效, StageName As String, Params As Object()) As Boolean
        Return CBool(tj.GetType.GetMethod(StageName).Invoke(tj, Params))
    End Function
    ''' <summary>
    ''' 计算围成圆形的标号最小差距
    ''' </summary>
    <Extension>
    Public Function DistanceOf(总数 As Integer, v1 As Integer, v2 As Integer) As Integer
        If v1 > v2 Then
            Dim t = v2
            v2 = v1
            v1 = t
        End If
        Return Math.Min(v2 - v1, v1 + 总数 - v2)
    End Function
    ''' <summary>
    ''' a和b进行位与操作之后是否为b
    ''' </summary> 
    ''' <returns></returns>
    <Extension>
    Public Function Contain(a As Integer, b As Integer) As Boolean
        Return b <> (a And b)
    End Function
    ''' <summary>
    ''' 将a中全部成员进行位或操作之后是否.Contain(b)
    ''' 可以判断没编码的AI分类是否包含编码后的AI分类
    ''' </summary> 
    <Extension>
    Public Function Contains(Of T1, T2, T3, T4)(a As IEnumerable(Of 核心.动态支持(Of T1, T2, T3, T4).卡牌分类), b As Integer) As Boolean
        Dim va As Integer = 0
        For Each t In a
            va = va Or t
        Next
        Return va.Contain(b)
    End Function

    ''' <summary>
    ''' 获取当前Type的用无参数Sub New构造而来的对象。只能用于Class的Type。
    ''' </summary>
    ''' <param name="tp"></param>
    ''' <returns></returns>
    <Extension>
    Public Function GetDefaultObject(tp As Type) As Object
        Return tp.GetConstructor({}).Invoke({})
    End Function
End Module


