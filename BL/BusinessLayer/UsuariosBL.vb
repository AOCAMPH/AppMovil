Imports DataAccessLayer
Imports BusinessEntities
Public Class UsuariosBL
    Dim oUsuarioDAO As New UsuarioDAO
    Public Function AutenticarUsuario(ByVal oUsuario As UsuarioBE) As Boolean
        Return oUsuarioDAO.autenticar(oUsuario)
    End Function
   
End Class
