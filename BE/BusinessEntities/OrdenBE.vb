Public Class OrdenBE

    Private _NroOrden As Int32
    Private _Cliente As String
    Private _Producto As String
    Private _PaisEnvio As String
    Private _PaisLlegada As String
    Private _FechaEnvio As Date
    Private _FechaLlegada As Date
    Private _Lineas As List(Of DetalleOrdenBE)
    Sub New()
        Me.Lineas = New List(Of DetalleOrdenBE)()
    End Sub
    Public Property NroOrden() As Int32
        Get
            Return _NroOrden
        End Get
        Set(ByVal value As Int32)
            _NroOrden = value
        End Set
    End Property
    Public Property Cliente() As String
        Get
            Return _Cliente
        End Get
        Set(ByVal value As String)
            _Cliente = value
        End Set
    End Property
    Public Property Producto() As String
        Get
            Return _Producto
        End Get
        Set(ByVal value As String)
            _Producto = value
        End Set
    End Property
    Public Property PaisEnvio() As String
        Get
            Return _PaisEnvio
        End Get
        Set(ByVal value As String)
            _PaisEnvio = value
        End Set
    End Property
    Public Property PaisLlegada() As String
        Get
            Return _PaisLlegada
        End Get
        Set(ByVal value As String)
            _PaisLlegada = value
        End Set
    End Property
    Public Property FechaEnvio() As Date
        Get
            Return _FechaEnvio
        End Get
        Set(ByVal value As Date)
            _FechaEnvio = value
        End Set
    End Property
    Public Property FechaLlegada() As Date
        Get
            Return _FechaLlegada
        End Get
        Set(ByVal value As Date)
            _FechaLlegada = value
        End Set
    End Property
    Public Property Lineas() As List(Of DetalleOrdenBE)
        Get
            Return _Lineas
        End Get
        Set(ByVal value As List(Of DetalleOrdenBE))
            _Lineas = value
        End Set
    End Property

End Class
