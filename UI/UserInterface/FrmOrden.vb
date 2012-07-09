Imports BusinessEntities
Imports BusinessLayer
Public Class FrmOrden
    Private oOrdenBL As New OrdenBL
    Private oClienteBL As New ClienteBL
    Private oProductoBL As New ProductoBL
    Private oOpcionBL As New OpcionBL
    'Private oO As New OrdenBE
    'Private oD As New DetalleOrdenBE
    Dim dtDetalle As New DataTable
    Dim flagaccion As String = ""
    Sub DefaultSettings()
        cboCliente.Text = Nothing
        cboProducto.Text = Nothing
        cboPaisDestino.Text = Nothing
        CboPaisSalida.Text = Nothing
    End Sub
    Private Sub FrmOrden_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        label4.Text = FrmBienvenida.Label2.Text.ToUpper
        txtNroOrden.Text = CStr(oOrdenBL.ObtenerIdOrden)
        cargar()
        crearDetalleLocal()
        DefaultSettings()
    End Sub
    Public Sub MostrarBotones()
        If ComboBox5.SelectedIndex = 0 Then
            btnGrabar.Visible = True
            btnActualizar.Visible = False
            btnEliminar.Visible = False
            txtNroOrden.ReadOnly = True
            lblCliente.Visible = True
            cboCliente.Visible = True
            lblProducto.Visible = True
            cboProducto.Visible = True
            lblPaisE.Visible = True
            cboPaisDestino.Visible = True
            lblPaisL.Visible = True
            CboPaisSalida.Visible = True
            dtpEnvio.Visible = True
            lblFecheE.Visible = True
            dtpLlegada.Visible = True
            lblFechaL.Visible = True
            lblCantidad.Visible = True
            txtCantidad.Visible = True
            lblPrecio.Visible = True
            txtPrecio.Visible = True
        End If
        If ComboBox5.SelectedIndex = 1 Then
            btnGrabar.Visible = False
            btnEliminar.Visible = False
            btnActualizar.Visible = True
            txtNroOrden.ReadOnly = True
            lblCliente.Visible = True
            cboCliente.Visible = True
            lblProducto.Visible = True
            cboProducto.Visible = True
            lblPaisE.Visible = True
            cboPaisDestino.Visible = True
            lblPaisL.Visible = True
            CboPaisSalida.Visible = True
            dtpEnvio.Visible = True
            lblFecheE.Visible = True
            dtpLlegada.Visible = True
            lblFechaL.Visible = True
            lblCantidad.Visible = True
            txtCantidad.Visible = True
            lblPrecio.Visible = True
            txtPrecio.Visible = True
        End If
        If ComboBox5.SelectedIndex = 2 Then
            btnGrabar.Visible = False
            btnActualizar.Visible = False
            btnEliminar.Visible = True
            txtNroOrden.ReadOnly = False
            lblCliente.Visible = False
            cboCliente.Visible = False
            lblProducto.Visible = False
            cboProducto.Visible = False
            lblPaisE.Visible = False
            cboPaisDestino.Visible = False
            lblPaisL.Visible = False
            CboPaisSalida.Visible = False
            dtpEnvio.Visible = False
            lblFecheE.Visible = False
            dtpLlegada.Visible = False
            lblFechaL.Visible = False
            lblCantidad.Visible = False
            txtCantidad.Visible = False
            lblPrecio.Visible = False
            txtPrecio.Visible = False
            GroupBox1.Visible = False
            datagridview1.Visible = False
        End If
        If ComboBox5.SelectedIndex = 3 Then
            btnGrabar.Visible = False
            btnActualizar.Visible = False
            btnEliminar.Visible = False
            txtNroOrden.ReadOnly = False
            lblCliente.Visible = False
            cboCliente.Visible = False
            lblProducto.Visible = False
            cboProducto.Visible = False
            lblPaisE.Visible = False
            cboPaisDestino.Visible = False
            lblPaisL.Visible = False
            CboPaisSalida.Visible = False
            dtpEnvio.Visible = False
            lblFecheE.Visible = False
            dtpLlegada.Visible = False
            lblFechaL.Visible = False
            lblCantidad.Visible = False
            txtCantidad.Visible = False
            lblPrecio.Visible = False
            txtPrecio.Visible = False
            GroupBox1.Visible = False
            datagridview1.Visible = False
        End If
    End Sub
    Private Sub ComboBox5_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox5.SelectedValueChanged
        MostrarBotones()
    End Sub
    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        flagaccion = "I"

        Dim oO As New OrdenBE
        oO.NroOrden = Convert.ToInt32(txtNroOrden.Text)
        oO.Cliente = cboCliente.Text
        oO.Producto = cboProducto.Text
        oO.PaisEnvio = CboPaisSalida.Text
        oO.PaisLlegada = cboPaisDestino.Text
        oO.FechaEnvio = Convert.ToDateTime(dtpEnvio.Text)
        oO.FechaLlegada = Convert.ToDateTime(dtpLlegada.Text)

        For Each row As DataGridViewRow In datagridview1.Rows
            Dim oD As New DetalleOrdenBE

            oD.NroOrden = Convert.ToInt32(txtNroOrden.Text)
            oD.Producto = Convert.ToString(row.Cells("NombreProducto").Value)
            oD.Cantidad = Convert.ToInt32(row.Cells("Cantidad").Value)
            oD.Precio = Convert.ToInt32(row.Cells("Precio").Value)
            oD.Stock = Convert.ToInt32(row.Cells("Stock").Value)
            oD.StockRestante = Convert.ToInt32(row.Cells("StockRestante").Value)
            oD.Total = Convert.ToDecimal(row.Cells("Total").Value)

            oO.Lineas.Add(oD)

        Next

        oOrdenBL.InsertarOrden(oO, flagaccion)
        FrmListadoOrden.dgwMaestro.DataSource = oOrdenBL.ListarOrdenes
        flagaccion = ""
        MessageBox.Show("la orden y su detalle ha sido generado")

    End Sub
    Private Sub btnActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActualizar.Click
        flagaccion = "A"
        Dim oO As New OrdenBE
        With oO
            oO.NroOrden = Convert.ToInt32(txtNroOrden.Text)
            oO.Cliente = cboCliente.Text
            oO.Producto = cboProducto.Text
            oO.PaisEnvio = CboPaisSalida.Text
            oO.PaisLlegada = cboPaisDestino.Text
            oO.FechaEnvio = Convert.ToDateTime(dtpEnvio.Text)
            oO.FechaLlegada = Convert.ToDateTime(dtpLlegada.Text)
        End With
        Try
            If oOrdenBL.ActualizarOrden(oO, flagaccion) Then
                FrmListadoOrden.dgwMaestro.DataSource = oOrdenBL.ListarOrdenes
                MessageBox.Show("La orden ha sido actualizada exitosamente")
                flagaccion = ""
                limpia()
            End If
        Catch ex As Exception
            MessageBox.Show("Error" & ex.Message)
        End Try
    End Sub
    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        flagaccion = "E"
        Dim oO As New OrdenBE
        With oO
            .NroOrden = Convert.ToInt32(txtNroOrden.Text)
        End With
        If MessageBox.Show("Esta seguro de Eliminar el Registro", _
                           "Tutorial", MessageBoxButtons.YesNo, MessageBoxIcon.Question, _
                           MessageBoxDefaultButton.Button1) = DialogResult.Yes Then
            Try
                If oOrdenBL.EliminarOrden(oO, flagaccion) Then
                    FrmListadoOrden.dgwMaestro.DataSource = oOrdenBL.ListarOrdenes
                    MessageBox.Show("La orden ha sido removido exitosamente")
                    flagaccion = ""
                    oProductoBL.ObtenerIdProducto()
                End If
            Catch ex As Exception
                MessageBox.Show("Error" & ex.Message)
            End Try
        End If
    End Sub
    Public Function validaciones() As Boolean
        Dim result As Boolean = False
        If String.IsNullOrEmpty(cboCliente.Text) Then
            MsgBox("Debe seleccionar un cliente", MsgBoxStyle.Exclamation, "Advertencia")
            result = False
        ElseIf String.IsNullOrEmpty(cboProducto.Text) Then
            MsgBox("Debe seleccionar un producto", MsgBoxStyle.Exclamation, "Advertencia")
            result = False
        ElseIf String.IsNullOrEmpty(cboPaisDestino.Text) Then
            MsgBox("Debe seleccionar un Pais de destino", MsgBoxStyle.Exclamation, "Advertencia")
            result = False
        ElseIf String.IsNullOrEmpty(CboPaisSalida.Text) Then
            MsgBox("Debe seleccionar un Pais de Salida", MsgBoxStyle.Exclamation, "Advertencia")
            result = False
        ElseIf String.IsNullOrEmpty(CStr(dtpEnvio.Value)) Then
            MsgBox("Debe seleccionar una Fecha de envio", MsgBoxStyle.Exclamation, "Advertencia")
            result = False
        ElseIf String.IsNullOrEmpty(CStr(dtpLlegada.Value)) Then
            MsgBox("Debe seleccionar una Fecha de Llegada", MsgBoxStyle.Exclamation, "Advertencia")
            result = False
        End If
        Return result
    End Function
    Public Sub limpia()
        cboCliente.SelectedItem = Nothing
        cboProducto.SelectedItem = Nothing
        cboPaisDestino.SelectedItem = Nothing
        CboPaisSalida.SelectedItem = Nothing
        dtpEnvio.Value = Now
        dtpLlegada.Value = Now
        txtCantidad.Text = Nothing
        txtPrecio.Text = Nothing
    End Sub
    Public Sub cargar()
        cboCliente.DataSource = oClienteBL.listarClientes
        cboCliente.DisplayMember = "Nombre"
        cboCliente.ValueMember = "IdCliente"

        cboProducto.DataSource = oProductoBL.listarProductos
        cboProducto.DisplayMember = "NombreProducto"
        cboProducto.ValueMember = "IdProducto"

        cboPaisDestino.DataSource = oClienteBL.obtenerPais
        cboPaisDestino.DisplayMember = "NombrePais"
        cboPaisDestino.ValueMember = "IdPais"

        CboPaisSalida.DataSource = oClienteBL.obtenerPais
        CboPaisSalida.DisplayMember = "NombrePais"
        CboPaisSalida.ValueMember = "IdPais"

        ComboBox5.DataSource = oOpcionBL.obtenerOpcion
        ComboBox5.DisplayMember = "Descripcion"
        ComboBox5.ValueMember = "IdOpcion"

    End Sub
    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        If CBool(MsgBox("Desea Salir del formulario actual?", MsgBoxStyle.YesNo, "Salir Formulario")) Then
            Me.Close()
            FrmListadoOrden.Show()
        End If
    End Sub
    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        Dim dr As DataRow
        dr = dtDetalle.NewRow
        dr("NroOrden") = CInt(txtNroOrden.Text)
        dr("NombreProducto") = cboProducto.Text.ToString
        dr("Precio") = CDbl(txtPrecio.Text)
        dr("Cantidad") = CInt(txtCantidad.Text)
        dr("Stock") = CInt(txtStock.Text)
        dtDetalle.Rows.Add(dr)
        datagridview1.DataSource = dtDetalle
    End Sub
    Private Sub btnRemover_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemover.Click
    End Sub
    Sub crearDetalleLocal()
        'crear estructura del datatable equivalente al detalle pedido
        Dim dc As DataColumn
        dc = New DataColumn("NroOrden", Type.GetType("System.Int32"))
        dtDetalle.Columns.Add(dc)
        dc = New DataColumn("NombreProducto", Type.GetType("System.String"))
        dtDetalle.Columns.Add(dc)
        dc = New DataColumn("Stock", Type.GetType("System.Int32"))
        dtDetalle.Columns.Add(dc)
        dc = New DataColumn("Precio", Type.GetType("System.Double"))
        dtDetalle.Columns.Add(dc)
        dc = New DataColumn("Cantidad", Type.GetType("System.Int32"))
        dtDetalle.Columns.Add(dc)
        dc = New DataColumn("StockRestante", Type.GetType("System.Int32"), "Stock-Cantidad")
        dtDetalle.Columns.Add(dc)
        dc = New DataColumn("SubTotalParcial", Type.GetType("System.Double"), "Precio*Cantidad")
        dtDetalle.Columns.Add(dc)
        dc = New DataColumn("Subtotal", Type.GetType("System.Double"), "(Precio*Cantidad)* 0.19")
        dtDetalle.Columns.Add(dc)
        dc = New DataColumn("Total", Type.GetType("System.Double"), "SubTotalParcial+SubTotal")
        dtDetalle.Columns.Add(dc)
        'establecer  primarykey
        'dtDetalle.PrimaryKey = New DataColumn() {dtDetalle.Columns("NroOrden")}
    End Sub

    Private Sub cboProducto_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboProducto.SelectionChangeCommitted
        Dim id As String = Convert.ToString(cboProducto.SelectedValue.ToString)
        txtStock.Text = Convert.ToString(oOrdenBL.ObtenerStockPorProducto(CInt(id)))
        txtPrecio.Text = Convert.ToString(oOrdenBL.ObtenerPrecioPorId((id)))
    End Sub
End Class