Public Class UsuarioBE
    Private _IdUsuario As String
    Private _PasswordUsuario As String
    Private _Perfil As String

    Public Property IdUsuario() As String
        Get
            Return _IdUsuario
        End Get
        Set(ByVal value As String)
            _IdUsuario = value
        End Set
    End Property
    Public Property PasswordUsuario() As String
        Get
            Return _PasswordUsuario
        End Get
        Set(ByVal value As String)
            _PasswordUsuario = value
        End Set
    End Property

End Class
