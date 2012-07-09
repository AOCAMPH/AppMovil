Imports MySql.Data.MySqlClient
Imports MySql.Data
Imports BusinessEntities
Imports System.Configuration

Public Class ClienteDAO
    Public Function listarClientes() As List(Of ClienteBE)
        Dim clientes As New List(Of ClienteBE)
        Using cn As New MySqlConnection(ConfigurationManager.ConnectionStrings("ordenes").ToString())
            cn.Open()
            Dim cmd As New  _
            MySqlCommand("Select IdCliente,Nombre,Direccion,Dni,Fecha,Foto,Ruta from Clientes", cn)
            Dim reader As MySqlDataReader = cmd.ExecuteReader
            While reader.Read
                clientes.Add(ObtenerClientes(reader))
            End While
        End Using
        Return clientes
    End Function
    Public Function obtenerIdCliente() As Int32
        Using cn As New MySqlConnection(ConfigurationManager.ConnectionStrings("ordenes").ToString())
            Dim cmd As New MySqlCommand("Select max(IdCliente)+1 from Clientes", cn)
            Try
                cn.Open()
                Return Convert.ToInt32(cmd.ExecuteScalar)
            Catch ex As Exception
                Return 0
            Finally
                cn.Close()
            End Try
        End Using
    End Function
    Public Function insertarCliente(ByVal oCliente As ClienteBE, ByVal flagaccion As String) As Boolean
        Using cn As New MySqlConnection(ConfigurationManager.ConnectionStrings("ordenes").ToString())
            If flagaccion = "I" Then
                cn.Open()
                Using trx As MySqlTransaction = cn.BeginTransaction(IsolationLevel.ReadUncommitted)
                    Dim cmd As New MySqlCommand("Insert into Clientes Values(?IdCliente,?Nombre,?Direccion,?Dni,?Fecha,?Foto,?Ruta)", cn)
                    With cmd.Parameters
                        .Add("?IdCliente", MySqlDbType.Int32).Value = oCliente.IdCliente
                        .Add("?Nombre", MySqlDbType.VarChar, 100).Value = oCliente.Nombre
                        .Add("?Direccion", MySqlDbType.VarChar, 200).Value = oCliente.Direccion
                        .Add("?Dni", MySqlDbType.VarChar, 8).Value = oCliente.DNI
                        .Add("?Fecha", MySqlDbType.DateTime).Value = oCliente.Fecha
                        .Add("?Foto", MySqlDbType.Blob).Value = oCliente.Foto
                        .Add("?Ruta", MySqlDbType.VarChar).Value = oCliente.Ruta
                        Dim i As Integer = cmd.ExecuteNonQuery()
                        If i > 0 Then
                            MsgBox(i.ToString + "Registro Insertado")
                            trx.Commit()
                            Return True
                        Else
                            trx.Rollback()
                            Return False
                            MsgBox("La transaccion ha fallado")
                        End If
                    End With
                End Using
            End If
        End Using
    End Function
    Public Function BuscarCliente(ByVal ocliente As ClienteBE) As List(Of ClienteBE)
        Dim clientes As New List(Of ClienteBE)
        Using cn As New MySqlConnection(ConfigurationManager.ConnectionStrings("ordenes").ToString())
            cn.Open()
            Dim cmd As New MySqlCommand("Select IdCliente,Nombre,Direccion,Dni,Fecha,Foto,Ruta from Clientes where Nombre LIKE CONCAT('%',?Nombre,'%')", cn)
            With cmd.Parameters
                .Add("?Nombre", MySqlDbType.VarChar).Value = ocliente.Nombre
            End With
            Dim reader As MySqlDataReader = cmd.ExecuteReader()
            While reader.Read
                clientes.Add(ObtenerClientes(reader))
            End While
        End Using
        Return clientes
    End Function
    Public Function ObtenerClientes(ByVal reader As IDataReader) As ClienteBE
        Dim clientes As New ClienteBE
        With clientes
            .IdCliente = CStr(reader("IdCliente"))
            .Nombre = CStr(reader("Nombre"))
            .Direccion = CStr(reader("Direccion"))
            .DNI = CStr(reader("Dni"))
            .Fecha = CDate(reader("Fecha"))
            .Foto = CType(reader("Foto"), Byte())
            .Ruta = CStr(reader("Ruta"))
        End With
        Return clientes
    End Function
    Public Function modificarCliente(ByVal oCliente As ClienteBE, ByVal flagaccion As String) As Boolean
        Using cn As New MySqlConnection(ConfigurationManager.ConnectionStrings("ordenes").ToString())
            If flagaccion = "A" Then
                cn.Open()
                Using trx As MySqlTransaction = cn.BeginTransaction(IsolationLevel.ReadUncommitted)
                    Dim cmd As New MySqlCommand("update Clientes set Nombre=?Nombre, Direccion=?Direccion,Dni=?Dni,Fecha=?Fecha,Ruta=?Ruta where IdCliente=?IdCliente", cn)
                    With cmd.Parameters
                        .Add("?IdCliente", MySqlDbType.Int32).Value = oCliente.IdCliente
                        .Add("?Nombre", MySqlDbType.VarChar).Value = oCliente.Nombre
                        .Add("?Direccion", MySqlDbType.VarChar).Value = oCliente.Direccion
                        .Add("?Dni", MySqlDbType.VarChar).Value = oCliente.DNI
                        .Add("?Fecha", MySqlDbType.DateTime).Value = oCliente.Fecha
                        .Add("?Foto", MySqlDbType.Blob).Value = oCliente.Foto
                        .Add("?Ruta", MySqlDbType.VarChar).Value = oCliente.Ruta
                    End With
                    Dim i As Integer = cmd.ExecuteNonQuery()
                    If i > 0 Then
                        MsgBox(i.ToString + "Registro Actualizado")
                        trx.Commit()
                        Return True
                    Else
                        trx.Rollback()
                        Return False
                        MsgBox("La transaccion ha fallado")
                    End If
                End Using
            End If
        End Using
    End Function
    Public Function eliminarCliente(ByVal ocliente As ClienteBE, ByVal flagaccion As String) As Boolean
        Using cn As New MySqlConnection(ConfigurationManager.ConnectionStrings("ordenes").ToString())
            If flagaccion = "E" Then
                cn.Open()
                Using trx As MySqlTransaction = cn.BeginTransaction(IsolationLevel.ReadUncommitted)
                    Dim cmd As New MySqlCommand( _
            "Delete from Clientes where IdCliente=?IdCliente", cn)
                    With cmd.Parameters
                        .Add("?IdCliente", MySqlDbType.Int32).Value = ocliente.IdCliente
                    End With
                    Dim i As Integer = cmd.ExecuteNonQuery
                    If i > 0 Then
                        trx.Commit()
                        Return True
                        MsgBox(i.ToString + "registro eliminado")
                    Else
                        trx.Rollback()
                        Return False
                        MsgBox("La transaccion ha fallado")
                    End If
                End Using
            End If
        End Using
    End Function
    Public Function obtenerPais() As DataTable
        Using cn As New MySqlConnection(ConfigurationManager.ConnectionStrings("ordenes").ToString())
            cn.Open()
            Dim da As New MySqlDataAdapter("Select * from Pais", cn)
            Dim dt As New DataTable
            da.Fill(dt)
            Return dt
        End Using
    End Function
    Public Function existe(ByVal ocliente As ClienteBE) As Boolean
        Dim numreg As Integer = 0
        Using cn As New MySqlConnection(ConfigurationManager.ConnectionStrings("ordenes").ToString())
            cn.Open()
            Dim cmd As New MySqlCommand("Select Count(*) from clientes where IdCliente=?Id", cn)
            With cmd.Parameters
                .Add("?Id", MySqlDbType.Int32).Value = ocliente.IdCliente
            End With
            numreg = Convert.ToInt32(cmd.ExecuteScalar())
        End Using
        Return numreg > 0
    End Function
End Class
