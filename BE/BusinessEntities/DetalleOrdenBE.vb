Public Class DetalleOrdenBE

    Private _NroOrden As Int32
    Private _Producto As String
    Private _Cantidad As Int32
    Private _Precio As Decimal
    Private _Total As Decimal
    Private _Stock As Int32
    Private _StockRestante As Int32

    Public Property NroOrden() As Int32
        Get
            Return _NroOrden
        End Get
        Set(ByVal value As Int32)
            _NroOrden = value
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
    Public Property Cantidad() As Int32
        Get
            Return _Cantidad
        End Get
        Set(ByVal value As Int32)
            _Cantidad = value
        End Set
    End Property
    Public Property Precio() As Decimal
        Get
            Return _Precio
        End Get
        Set(ByVal value As Decimal)
            _Precio = value
        End Set
    End Property
    Public Property Total() As Decimal
        Get
            Return _Total
        End Get
        Set(ByVal value As Decimal)
            _Total = value
        End Set
    End Property
    Public Property Stock() As Int32
        Get
            Return _Stock
        End Get
        Set(ByVal value As Int32)
            _Stock = value
        End Set
    End Property
    Public Property StockRestante() As Int32
        Get
            Return _StockRestante
        End Get
        Set(ByVal value As Int32)
            _StockRestante = value
        End Set
    End Property
End Class
