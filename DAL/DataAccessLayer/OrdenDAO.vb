Imports MySql.Data.MySqlClient
Imports MySql.Data
Imports BusinessEntities
Imports System.Configuration
Public Class OrdenDAO
    Dim oDetalle As New DetalleOrdenBE
    Public Function ObtenerId() As Int32
        Using cn As New MySqlConnection(ConfigurationManager.ConnectionStrings("ordenes").ToString())
            Dim cmd As New MySqlCommand("Select Max(NroOrden)+1 from Orden", cn)
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
    Public Function Listar() As DataTable
        Using cn As New MySqlConnection(ConfigurationManager.ConnectionStrings("ordenes").ToString())
            cn.Open()
            Dim dta As New MySqlDataAdapter("Select * from Orden", cn)
            Dim dt As New DataTable
            dta.Fill(dt)
            Return dt
        End Using
    End Function
    Public Function insertar(ByVal oOrden As OrdenBE, ByVal flagaccion As String) As Boolean
        Using cn As New MySqlConnection(ConfigurationManager.ConnectionStrings("ordenes").ToString())
            If flagaccion = "I" Then
                cn.Open()
                Using trx As MySqlTransaction = cn.BeginTransaction(IsolationLevel.ReadUncommitted)
                    Dim orden As String = "Insert into Orden Values(?NROORDEN,?CLIENTE,?PRODUCTO,?PAISENVIO,?PAISLLEGADA,?FECHAENVIO,?FECHALLEGADA)"
                    Using cmd As New MySqlCommand(orden, cn)
                        With cmd.Parameters
                            .Add("?NROORDEN", MySqlDbType.Int32).Value = oOrden.NroOrden
                            .Add("?CLIENTE", MySqlDbType.VarChar, 100).Value = oOrden.Cliente
                            .Add("?PRODUCTO", MySqlDbType.VarChar, 100).Value = oOrden.Producto
                            .Add("?PAISENVIO", MySqlDbType.VarChar, 30).Value = oOrden.PaisEnvio
                            .Add("?PAISLLEGADA", MySqlDbType.VarChar, 30).Value = oOrden.PaisLlegada
                            .Add("?FECHAENVIO", MySqlDbType.DateTime).Value = oOrden.FechaEnvio
                            .Add("?FECHALLEGADA", MySqlDbType.DateTime).Value = oOrden.FechaLlegada
                            oOrden.NroOrden = Convert.ToInt32(cmd.ExecuteScalar())
                        End With
                    End Using
                    Dim detalle As String = "Insert into detalleorden Values(?NROORDEN,?PRODUCTO,?CANTIDAD,?PRECIO,?STOCK,?STOCKRESTANTE,?TOTAL)"
                    Using cmd As New MySqlCommand(detalle, cn)
                        For Each oDetalle As DetalleOrdenBE In oOrden.Lineas
                            cmd.Parameters.Clear()
                            With cmd.Parameters
                                .Add("?NROORDEN", MySqlDbType.Int32).Value = oDetalle.NroOrden
                                .Add("?PRODUCTO", MySqlDbType.VarChar, 100).Value = oDetalle.Producto
                                .Add("?CANTIDAD", MySqlDbType.VarChar, 100).Value = oDetalle.Cantidad
                                .Add("?PRECIO", MySqlDbType.VarChar, 30).Value = oDetalle.Precio
                                .Add("?STOCK", MySqlDbType.Int32).Value = oDetalle.Stock
                                .Add("?STOCKRESTANTE", MySqlDbType.Int32).Value = oDetalle.StockRestante
                                .Add("?TOTAL", MySqlDbType.Decimal).Value = oDetalle.Total
                                oDetalle.NroOrden = Convert.ToInt32(cmd.ExecuteScalar())
                            End With
                        Next
                    End Using
                    trx.Commit()
                    Return True
                    trx.Rollback()
                    Return False
                End Using
            End If
        End Using
    End Function
    Public Function actualizar(ByVal oOrden As OrdenBE, ByVal flagaccion As String) As Boolean
        Using cn As New MySqlConnection(ConfigurationManager.ConnectionStrings("ordenes").ToString())
            cn.Open()
            If flagaccion = "A" Then
                Using trx As MySqlTransaction = cn.BeginTransaction(IsolationLevel.ReadUncommitted)
                    Dim cmd As New MySqlCommand("Update Orden set CLIENTE=?CLIENTE,PRODUCTO=?PRODUCTO,PAISENVIO=?PAISENVIO,PAISLLEGADA=?PAISLLEGADA,FECHAENVIO=?FECHAENVIO,FECHALLEGADA=?FECHALLEGADA WHERE NROORDEN=?NROORDEN)", cn)
                    With cmd.Parameters
                        .Add("?NROORDEN", MySqlDbType.Int32).Value = oOrden.NroOrden
                        .Add("?CLIENTE", MySqlDbType.VarChar, 100).Value = oOrden.Cliente
                        .Add("?PRODUCTO", MySqlDbType.VarChar, 100).Value = oOrden.Producto
                        .Add("?PAISENVIO", MySqlDbType.VarChar, 30).Value = oOrden.PaisEnvio
                        .Add("?PAISLLEGADA", MySqlDbType.VarChar, 30).Value = oOrden.PaisLlegada
                        .Add("?FECHAENVIO", MySqlDbType.DateTime).Value = oOrden.FechaEnvio
                        .Add("?FECHALLEGADA", MySqlDbType.DateTime).Value = oOrden.FechaLlegada
                        Dim i As Integer = cmd.ExecuteNonQuery()
                        If i > 0 Then
                            trx.Commit()
                            Return True
                            MsgBox(i.ToString + "Registro Actualizado")
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
    Public Function eliminar(ByVal oOrden As OrdenBE, ByVal flagaccion As String) As Boolean
        Using cn As New MySqlConnection(ConfigurationManager.ConnectionStrings("ordenes").ToString())
            If flagaccion = "E" Then
                cn.Open()
                Using trx As MySqlTransaction = cn.BeginTransaction(IsolationLevel.ReadUncommitted)
                    Dim cmd As New MySqlCommand( _
            "Delete from Orden where NroOrden=?NroOrden", cn)
                    With cmd.Parameters
                        .Add("?NroOrden", MySqlDbType.Int32).Value = oOrden.NroOrden
                    End With
                    Dim i As Integer = cmd.ExecuteNonQuery
                    MsgBox(i.ToString + "registro eliminado")
                    If i > 0 Then
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
    Public Function obtenerPrecio(ByVal id As Integer) As Decimal
        Dim precio As Decimal = 0
        Using cn As New MySqlConnection(ConfigurationManager.ConnectionStrings("ordenes").ToString())
            cn.Open()
            Dim cmd As New MySqlCommand("SELECT PrecioProducto FROM Producto where IdProducto=?Id", cn)
            With cmd.Parameters
                .Add("?Id", MySqlDbType.Int32).Value = id
            End With
            precio = Convert.ToDecimal(cmd.ExecuteScalar())
        End Using
        Return precio
    End Function
    Public Function FiltrarFechas(ByVal oOrden As OrdenBE) As DataTable
        Using cn As New MySqlConnection(ConfigurationManager.ConnectionStrings("ordenes").ToString())
            cn.Open()
            Dim dta As New MySqlDataAdapter("SELECT D.NROORDEN, D.PRODUCTO,D.CANTIDAD, D.PRECIO FROM DETALLEORDEN D INNER JOIN ORDEN O ON O.NROORDEN=D.NROORDEN WHERE O.CLIENTE=?cliente AND O.FECHAENVIO>=?f1 AND O.FECHALLEGADA<=?f2", cn)
            With dta.SelectCommand.Parameters
                .Add("?f1", MySqlDbType.Date).Value = oOrden.FechaEnvio
                .Add("?f2", MySqlDbType.Date).Value = oOrden.FechaLlegada
                .Add("?cliente", MySqlDbType.VarChar).Value = oOrden.Cliente
            End With
            Dim dt As New DataTable
            dta.Fill(dt)
            Return dt
        End Using
    End Function
    Public Function listaxOrden(ByVal cliente As String) As DataTable
        Using cn As New MySqlConnection(ConfigurationManager.ConnectionStrings("ordenes").ToString())
            cn.Open()
            Dim dta As New MySqlDataAdapter("SELECT D.NROORDEN, D.PRODUCTO,D.CANTIDAD, D.PRECIO FROM DETALLEORDEN D INNER JOIN ORDEN O ON O.NROORDEN=D.NROORDEN WHERE O.CLIENTE=?Cliente", cn)
            With dta.SelectCommand.Parameters
                .Add("?Cliente", MySqlDbType.VarChar).Value = cliente
            End With
            Dim dt As New DataTable
            dta.Fill(dt)
            Return dt
        End Using
    End Function
    Public Function obtenerStock(ByVal id As Integer) As Int32
        Dim stock As Integer = 0
        Using cn As New MySqlConnection(ConfigurationManager.ConnectionStrings("ordenes").ToString())
            cn.Open()
            Dim cmd As New MySqlCommand("SELECT StockProducto FROM Producto where IdProducto=?Id", cn)
            With cmd.Parameters
                .Add("?Id", MySqlDbType.Int32).Value = id
            End With
            stock = Convert.ToInt32(cmd.ExecuteScalar())
            Return stock
        End Using
    End Function
End Class
