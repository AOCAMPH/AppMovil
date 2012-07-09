Imports DataAccessLayer
Imports BusinessEntities
Public Class ProductoBL
    Private oProductoDAO As New ProductoDAO
    Public Function listarProductos() As List(Of ProductoBE)
        Return oProductoDAO.listarProductos
    End Function
    Public Function InsertarProducto(ByVal oProducto As ProductoBE, ByVal flagaccion As String) As Boolean
        Return oProductoDAO.insertar(oProducto, flagaccion)
    End Function
    Public Function ObtenerIdProducto() As Int32
        Return oProductoDAO.obtenerIdProducto
    End Function
    Public Function BuscarProducto(ByVal oProducto As ProductoBE) As List(Of ProductoBE)
        Return oProductoDAO.buscar(oProducto)
    End Function
    Public Function ActualizarProducto(ByVal oProducto As ProductoBE, ByVal flagaccion As String) As Boolean
        Return oProductoDAO.actualizar(oProducto, flagaccion)
    End Function
    Public Function EliminarProducto(ByVal oProducto As ProductoBE, ByVal flagaccion As String) As Boolean
        Return oProductoDAO.eliminar(oProducto, flagaccion)
    End Function
    Public Function ListarTipoProducto() As List(Of TipoProductoBE)
        Return oProductoDAO.ListarTipoProducto
    End Function

End Class
