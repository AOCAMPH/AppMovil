Imports DataAccessLayer
Imports BusinessEntities
Public Class OrdenBL
    Private oOrdenDAO As New OrdenDAO
    Public Function ListarOrdenes() As DataTable
        Return oOrdenDAO.Listar
    End Function
    Public Function InsertarOrden(ByVal oOrden As OrdenBE, ByVal flagaccion As String) As Boolean
        Return oOrdenDAO.insertar(oOrden, flagaccion)
    End Function
    Public Function ActualizarOrden(ByVal oOrden As OrdenBE, ByVal flagaccion As String) As Boolean
        Return oOrdenDAO.actualizar(oOrden, flagaccion)
    End Function
    Public Function EliminarOrden(ByVal oOrden As OrdenBE, ByVal flagaccion As String) As Boolean
        Return oOrdenDAO.eliminar(oOrden, flagaccion)
    End Function
    Public Function ObtenerIdOrden() As Int32
        Return oOrdenDAO.ObtenerId
    End Function
    Public Function ObtenerStockPorProducto(ByVal id As Integer) As Int32
        Return oOrdenDAO.obtenerStock(id)
    End Function
    Public Function FiltrarOrdenesFechas(ByVal oOrden As OrdenBE) As DataTable
        Return oOrdenDAO.FiltrarFechas(oOrden)
    End Function
    Public Function ListarDetalles(ByVal cliente As String) As DataTable
        Return oOrdenDAO.listaxOrden(cliente)
    End Function
    Public Function ObtenerPrecioPorId(ByVal id As String) As Decimal
        Return oOrdenDAO.obtenerPrecio(id)
    End Function
End Class
