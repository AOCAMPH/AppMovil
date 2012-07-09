Imports MySql.Data.MySqlClient
Imports MySql.Data
Imports BusinessEntities
Imports System.Configuration
Public Class ProductoDAO
    Public Function ListarTipoProducto() As List(Of TipoProductoBE)
        Dim tipos As New List(Of TipoProductoBE)
        Using cn As New MySqlConnection(ConfigurationManager.ConnectionStrings("ordenes").ToString())
            cn.Open()
            Dim cmd As New MySqlCommand("Select IdTipoProducto,Descripcion from tipo_producto", cn)
            Dim reader As MySqlDataReader = cmd.ExecuteReader
            While reader.Read
                tipos.Add(ObtenerTipos(reader))
            End While
        End Using
        Return tipos
    End Function
    Public Function ObtenerTipos(ByVal reader As IDataReader) As TipoProductoBE
        Dim productos As New TipoProductoBE
        With productos
            .IdTipoProducto = CInt(reader("IdTipoProducto"))
            .Descripcion = CStr(reader("Descripcion"))
        End With
        Return productos
    End Function
    Public Function listarProductos() As List(Of ProductoBE)
        Dim productos As New List(Of ProductoBE)
        Using cn As New MySqlConnection(ConfigurationManager.ConnectionStrings("ordenes").ToString())
            cn.Open()
            Dim cmd As New  _
            MySqlCommand("Select IdProducto,NombreProducto,TipoProducto,StockProducto,PrecioProducto,FotoProducto,Ruta from Producto", cn)
            Dim reader As MySqlDataReader = cmd.ExecuteReader
            While reader.Read
                productos.Add(ObtenerProductos(reader))
            End While
        End Using
        Return productos
    End Function
    Public Function ObtenerProductos(ByVal reader As IDataReader) As ProductoBE
        Dim productos As New ProductoBE
        With productos
            .IdProducto = CInt(reader("IdProducto"))
            .NombreProducto = CStr(reader("NombreProducto"))
            .TipoProducto = CStr(reader("TipoProducto"))
            .StockProducto = CInt(reader("StockProducto"))
            .PrecioProducto = CDec(reader("PrecioProducto"))
            .FotoProducto = CType(reader("FotoProducto"), Byte())
            .Ruta = CStr(reader("Ruta"))
        End With
        Return productos
    End Function
    Public Function insertar(ByVal oProducto As ProductoBE, ByVal flagaccion As String) As Boolean
        Using cn As New MySqlConnection(ConfigurationManager.ConnectionStrings("ordenes").ToString())
            If flagaccion = "I" Then
                cn.Open()
                Using trx As MySqlTransaction = cn.BeginTransaction(IsolationLevel.ReadUncommitted)
                    Dim cmd As New MySqlCommand("Insert into Producto Values(?IdProducto,?NombreProducto,?TipoProducto,?StockProducto,?PrecioProducto,?FotoProducto,?Ruta)", cn, trx)
                    With cmd.Parameters
                        .Add("?IdProducto", MySqlDbType.Int32).Value = oProducto.IdProducto
                        .Add("?NombreProducto", MySqlDbType.VarChar, 100).Value = oProducto.NombreProducto
                        .Add("?TipoProducto", MySqlDbType.VarChar, 100).Value = oProducto.TipoProducto
                        .Add("?StockProducto", MySqlDbType.Int32).Value = oProducto.StockProducto
                        .Add("?PrecioProducto", MySqlDbType.Decimal).Value = oProducto.PrecioProducto
                        .Add("?FotoProducto", MySqlDbType.Blob).Value = oProducto.FotoProducto
                        .Add("?Ruta", MySqlDbType.VarChar).Value = oProducto.Ruta
                        Dim i As Integer = cmd.ExecuteNonQuery()
                        If i > 0 Then
                            trx.Commit()
                            Return True
                            MsgBox(i.ToString + "Registro Insertado")
                        Else
                            trx.Rollback()
                            Return False
                            MsgBox("La transaccion ha finalizado")
                        End If
                    End With
                End Using
            End If
        End Using
    End Function
    Public Function obtenerIdProducto() As Int32
        Using cn As New MySqlConnection(ConfigurationManager.ConnectionStrings("ordenes").ToString())
            Dim cmd As New MySqlCommand("Select Max(IdProducto)+1 from Producto", cn)
            Try
                cn.Open()
                Return Convert.ToInt32(cmd.ExecuteScalar())
            Catch ex As Exception
                Return 0
            Finally
                cn.Close()
            End Try
        End Using
    End Function
    Public Function buscar(ByVal oProducto As ProductoBE) As List(Of ProductoBE)
        Dim productos As New List(Of ProductoBE)
        Using cn As New MySqlConnection(ConfigurationManager.ConnectionStrings("ordenes").ToString())
            cn.Open()
            Dim cmd As New MySqlCommand("Select IdProducto,NombreProducto,TipoProducto,StockProducto,PrecioProducto,FotoProducto,Ruta from Producto where NombreProducto LIKE CONCAT ('%', ?Nombre, '%')", cn)
            With cmd.Parameters
                .Add("?Nombre", MySqlDbType.VarChar).Value = oProducto.NombreProducto
            End With
            Dim reader As MySqlDataReader = cmd.ExecuteReader()
            While reader.Read
                productos.Add(ObtenerProductos(reader))
            End While
        End Using
        Return productos
    End Function
    Public Function actualizar(ByVal oProducto As ProductoBE, ByVal flagaccion As String) As Boolean
        Using cn As New MySqlConnection(ConfigurationManager.ConnectionStrings("ordenes").ToString())
            If flagaccion = "A" Then
                cn.Open()
                Using trx As MySqlTransaction = cn.BeginTransaction(IsolationLevel.ReadUncommitted)
                    Dim cmd As New MySqlCommand("update Producto set NombreProducto=?NombreProducto,TipoProducto=?TipoProducto,StockProducto=?StockProducto,PrecioProducto=?PrecioProducto, FotoProducto=?FotoProducto, Ruta=?Ruta where IdProducto=?IdProducto", cn)
                    With cmd.Parameters
                        .Add("?IdProducto", MySqlDbType.Int32).Value = oProducto.IdProducto
                        .Add("?NombreProducto", MySqlDbType.VarChar).Value = oProducto.NombreProducto
                        .Add("?TipoProducto", MySqlDbType.VarChar).Value = oProducto.TipoProducto
                        .Add("?StockProducto", MySqlDbType.Int32).Value = oProducto.StockProducto
                        .Add("?PrecioProducto", MySqlDbType.Decimal).Value = oProducto.PrecioProducto
                        .Add("?FotoProducto", MySqlDbType.Blob).Value = oProducto.FotoProducto
                        .Add("?Ruta", MySqlDbType.VarChar).Value = oProducto.Ruta
                    End With
                    Dim i As Integer = cmd.ExecuteNonQuery()
                    If i > 0 Then
                        trx.Commit()
                        Return True
                        MsgBox(i.ToString + "Registro Actualizado")
                    Else
                        trx.Rollback()
                        Return False
                        MsgBox("La transaccion ha finalizado")
                    End If
                End Using
            End If
        End Using
    End Function
    Public Function eliminar(ByVal oProducto As ProductoBE, ByVal flagaccion As String) As Boolean
        Using cn As New MySqlConnection(ConfigurationManager.ConnectionStrings("ordenes").ToString())
            If flagaccion = "E" Then
                cn.Open()
                Using trx As MySqlTransaction = cn.BeginTransaction(IsolationLevel.ReadUncommitted)
                    Dim cmd As New MySqlCommand( _
            "Delete from Producto where IdProducto=?IdProducto", cn)
                    With cmd.Parameters
                        .Add("?IdProducto", MySqlDbType.Int32).Value = oProducto.IdProducto
                    End With
                    Dim i As Integer = cmd.ExecuteNonQuery
                    If i > 0 Then
                        MsgBox(i.ToString + "registro eliminado")
                        trx.Commit()
                        Return True
                    Else
                        trx.Rollback()
                        Return False
                    End If
                End Using
            End If
        End Using
    End Function
End Class
