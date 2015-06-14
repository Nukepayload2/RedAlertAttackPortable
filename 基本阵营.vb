Imports 红警杀.核心
Imports 红警杀.基元
Namespace 基元
    Public MustInherit Class 阵营Base(Of 图像类型, 鼠标光标, 用户控件类型)
        Implements I阵营(Of 图像类型, 鼠标光标, 用户控件类型)

        Public Overridable ReadOnly Property 名称 As String Implements I阵营(Of 图像类型, 鼠标光标, 用户控件类型).名称
            Get
                Return Me.GetType.Name
            End Get
        End Property
        Public MustOverride ReadOnly Property 固有能力 As IList(Of I武将特技(Of 图像类型, 鼠标光标, 用户控件类型)) Implements I阵营(Of 图像类型, 鼠标光标, 用户控件类型).固有能力
        Public Overridable ReadOnly Property 大图标 As 图像类型 Implements I阵营(Of 图像类型, 鼠标光标, 用户控件类型).大图标
            Get
                Return Nothing
            End Get
        End Property
        Public Overridable ReadOnly Property 小图标 As 图像类型 Implements I阵营(Of 图像类型, 鼠标光标, 用户控件类型).小图标
            Get
                Return Nothing
            End Get
        End Property
        Public MustOverride ReadOnly Property 短说明 As String Implements I阵营(Of 图像类型, 鼠标光标, 用户控件类型).短说明
        Public MustOverride ReadOnly Property 长说明 As String Implements I阵营(Of 图像类型, 鼠标光标, 用户控件类型).长说明
        Public MustOverride ReadOnly Property 默认阵营色Argb As Integer Implements I阵营(Of 图像类型, 鼠标光标, 用户控件类型).默认阵营色Argb
    End Class
End Namespace

Namespace 基本阵营

    Public Class 苏联(Of 图像类型, 鼠标光标, 用户控件类型)
        Inherits 阵营Base(Of 图像类型, 鼠标光标, 用户控件类型)

        Public Overrides ReadOnly Property 固有能力 As IList(Of I武将特技(Of 图像类型, 鼠标光标, 用户控件类型))
            Get
                Dim l As New List(Of I武将特技(Of 图像类型, 鼠标光标, 用户控件类型))
                l.Add(New 基本技能.重甲(Of 图像类型, 鼠标光标, 用户控件类型))
                Return l
            End Get
        End Property
        Public Overrides ReadOnly Property 短说明 As String = "苏军的单位装甲厚，但是缺乏机动性"
        Public Overrides ReadOnly Property 长说明 As String = "苏军的单位装甲厚，但是缺乏机动性，能制造铁幕装置和核弹发射井。"
        Public Overrides ReadOnly Property 默认阵营色Argb As Integer
            Get
                Return &HFF << 24 Or &HFF << 16
            End Get
        End Property
    End Class
    Public Class 盟军(Of 图像类型, 鼠标光标, 用户控件类型)
        Inherits 阵营Base(Of 图像类型, 鼠标光标, 用户控件类型)

        Public Overrides ReadOnly Property 固有能力 As IList(Of I武将特技(Of 图像类型, 鼠标光标, 用户控件类型))
            Get
                Dim l As New List(Of I武将特技(Of 图像类型, 鼠标光标, 用户控件类型))
                l.Add(New 基本技能.高科(Of 图像类型, 鼠标光标, 用户控件类型))
                Return l
            End Get
        End Property
        Public Overrides ReadOnly Property 短说明 As String = "盟军的单位机动性强，但是缺乏装甲"
        Public Overrides ReadOnly Property 长说明 As String = "盟军的单位机动性强，但是缺乏装甲，能制造超时空传送仪和天气控制机。"
        Public Overrides ReadOnly Property 默认阵营色Argb As Integer
            Get
                Return &HFF << 24 Or &HFF
            End Get
        End Property
    End Class

    Public Class 尤里(Of 图像类型, 鼠标光标, 用户控件类型)
        Inherits 阵营Base(Of 图像类型, 鼠标光标, 用户控件类型)

        Public Overrides ReadOnly Property 固有能力 As IList(Of I武将特技(Of 图像类型, 鼠标光标, 用户控件类型))
            Get
                Dim l As New List(Of I武将特技(Of 图像类型, 鼠标光标, 用户控件类型))
                l.Add(New 基本技能.复仇(Of 图像类型, 鼠标光标, 用户控件类型))
                Return l
            End Get
        End Property
        Public Overrides ReadOnly Property 短说明 As String = "尤里的阵营必定是独一无二的"
        Public Overrides ReadOnly Property 长说明 As String = "尤里的阵营必定是独一无二的，拥有众多黑科技，能制造基因突变器和心灵控制器。"
        Public Overrides ReadOnly Property 默认阵营色Argb As Integer
            Get
                Return &HFF << 24 Or &H7F << 16 Or &H7F
            End Get
        End Property
    End Class

End Namespace
