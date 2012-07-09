Public Class ProductoBE

    Private _IdProducto As Integer
    Private _NombreProducto As String
    Private _TipoProducto As String
    Private _StockProducto As Integer
    Private _PrecioProducto As Double
    Private _FotoProducto As Byte()
    Private _Ruta As String

    Public Property IdProducto() As Integer
        Get
            Return _IdProducto
        End Get
        Set(ByVal value As Integer)
            _IdProducto = value
        End Set
    End Property
    Public Property NombreProducto() As String
        Get
            Return _NombreProducto
        End Get
        Set(ByVal value As String)
            _NombreProducto = value
        End Set
    End Property
    Public Property TipoProducto() As String
        Get
            Return _TipoProducto
        End Get
        Set(ByVal value As String)
            _TipoProducto = value
        End Set
    End Property
    Public Property StockProducto() As Integer
        Get
            Return _StockProducto
        End Get
        Set(ByVal value As Integer)
            _StockProducto = value
        End Set
    End Property
    Public Property PrecioProducto() As Double
        Get
            Return _PrecioProducto
        End Get
        Set(ByVal value As Double)
            _PrecioProducto = value
        End Set
    End Property
    Public Property FotoProducto() As Byte()
        Get
            Return _FotoProducto
        End Get
        Set(ByVal value As Byte())
            _FotoProducto = value
        End Set
    End Property
    Public Property Ruta() As String
        Get
            Return _Ruta
        End Get
        Set(ByVal value As String)
            _Ruta = value
        End Set
    End Property
End Class
