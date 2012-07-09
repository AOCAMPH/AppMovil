Public Class TipoProductoBE
    Private _IdTipoProducto As Int32
    Private _Descripcion As String

    Public Property IdTipoProducto() As Int32
        Get
            Return _IdTipoProducto
        End Get
        Set(ByVal value As Int32)
            _IdTipoProducto = value
        End Set
    End Property
    Public Property Descripcion() As String
        Get
            Return _Descripcion
        End Get
        Set(ByVal value As String)
            _Descripcion = value
        End Set
    End Property
End Class
