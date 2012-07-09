Imports DataAccessLayer
Imports BusinessEntities
Public Class OpcionBL
    Private oOpcionDAO As New OpcionDAO
    Public Function obtenerOpcion() As DataTable
        Return oOpcionDAO.obtenerOpcion()
    End Function
End Class
