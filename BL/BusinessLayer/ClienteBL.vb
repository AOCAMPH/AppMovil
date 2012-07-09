Imports DataAccessLayer
Imports BusinessEntities
Public Class ClienteBL
    Private oClienteDAO As New ClienteDAO
    Public Function ListarClientes() As List(Of ClienteBE)
        Return oClienteDAO.listarClientes()
    End Function
    Public Function InsertaCliente(ByVal ocliente As ClienteBE, ByVal flagaccion As String) As Boolean
        Return oClienteDAO.insertarCliente(ocliente, flagaccion)
    End Function
    Public Function ActualizaCliente(ByVal ocliente As ClienteBE, ByVal flagaccion As String) As Boolean
        Return oClienteDAO.modificarCliente(ocliente, flagaccion)
    End Function
    Public Function EliminarCliente(ByVal ocliente As ClienteBE, ByVal flagaccion As String) As Boolean
        Return oClienteDAO.eliminarCliente(ocliente, flagaccion)
    End Function
    Public Function obtenerIdCliente() As Int32
        Return oClienteDAO.obtenerIdCliente
    End Function
    Public Function buscarCliente(ByVal ocliente As ClienteBE) As List(Of ClienteBE)
        Return oClienteDAO.BuscarCliente(ocliente)
    End Function
    Public Function obtenerPais() As DataTable
        Return oClienteDAO.obtenerPais()
    End Function
    Public Function ExisteCliente(ByVal ocliente As ClienteBE) As Boolean
        Return oClienteDAO.existe(ocliente)
    End Function
End Class
