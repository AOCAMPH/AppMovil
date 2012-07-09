Imports MySql.Data.MySqlClient
Imports MySql.Data
Imports BusinessEntities
Imports System.Configuration
Public Class UsuarioDAO
    Public Function autenticar(ByVal oUsuario As UsuarioBE) As Boolean
        Using cn As New MySqlConnection(ConfigurationManager.ConnectionStrings("ordenes").ToString())
            cn.Open()
            Dim cmd As New MySqlCommand("Select IdUsuario, PasswordUsuario from Usuario where IdUsuario=?Usuario and PasswordUsuario=?Password", cn)
            With cmd.Parameters
                .Add("?Usuario", MySqlDbType.VarChar).Value = oUsuario.IdUsuario
                .Add("?Password", MySqlDbType.VarChar).Value = oUsuario.PasswordUsuario
            End With
            Dim retVal As Boolean = False
            Dim dr As MySqlDataReader = cmd.ExecuteReader()

            If dr IsNot Nothing AndAlso dr.Read() Then
                dr.Close()
                retVal = True
            End If
            Return retVal
        End Using
    End Function
    
End Class
