Imports MySql.Data.MySqlClient
Imports MySql.Data
Imports BusinessEntities
Imports System.Configuration
Public Class OpcionDAO
    Dim cn As New DataAccessLayer.Conexion
    Public Function obtenerOpcion() As DataTable
        Using cn As New MySqlConnection(ConfigurationManager.ConnectionStrings("ordenes").ToString())
            cn.Open()
            Dim dta As New MySqlDataAdapter("Select * from Opcion", cn)
            Dim dt As New DataTable
            dta.Fill(dt)
            Return dt
        End Using
    End Function
End Class
