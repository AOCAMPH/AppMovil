Public Class OpcionBE
    Private _IdOpcion As Integer
    Private _Descripcion As String

    Public Property IdOpcion() As Integer
        Get
            Return _IdOpcion
        End Get
        Set(ByVal value As Integer)
            _IdOpcion = value
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
