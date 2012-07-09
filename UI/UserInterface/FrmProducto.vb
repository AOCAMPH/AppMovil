Imports BusinessEntities
Imports BusinessLayer
Imports System.IO
Public Class FrmProducto
    Private oProductoBL As New ProductoBL
    Private oOpcionBL As New OpcionBL
    'Private oP As New ProductoBE
    Dim flagAccion As String = ""
    'carga combobox
    Public Sub cargar()
        cboProducto.DataSource = oProductoBL.ListarTipoProducto
        cboProducto.DisplayMember = "Descripcion"
        cboProducto.ValueMember = "IdTipoProducto"
        ComboBox1.DataSource = oOpcionBL.obtenerOpcion
        ComboBox1.DisplayMember = "Descripcion"
        ComboBox1.ValueMember = "IdOpcion"
    End Sub
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        label4.Text = FrmBienvenida.Label2.Text.ToUpper
        dwgProducto.DataSource = oProductoBL.listarProductos
        txtIdProducto.Text = Convert.ToString(oProductoBL.ObtenerIdProducto)
        cargar()
    End Sub
    'insertar
    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        ''insertar
        flagAccion = "I"
        Dim oP As New ProductoBE
        With oP
            .IdProducto = Convert.ToInt32(txtIdProducto.Text)
            .NombreProducto = txtNombreProducto.Text
            .TipoProducto = cboProducto.Text
            .StockProducto = Convert.ToInt32(txtStockProducto.Text)
            .PrecioProducto = Convert.ToDecimal(txtPrecioProducto.Text)
            Dim data() As Byte
            If Not Me.PictureBox1.Image Is Nothing Then
                Dim ms As New MemoryStream
                Me.PictureBox1.Image.Save(ms, Imaging.ImageFormat.Jpeg)
                data = ms.ToArray
            Else
                data = Nothing
            End If
            .FotoProducto = data
            .Ruta = TextBox1.Text
        End With
        Try
            If oProductoBL.InsertarProducto(oP, flagAccion) Then
                dwgProducto.DataSource = oProductoBL.listarProductos
                flagAccion = ""
                MessageBox.Show("El producto ha sido insertado exitosamente")
                limpiar()
                txtIdProducto.Text = Convert.ToString(oProductoBL.ObtenerIdProducto)
            End If
        Catch ex As Exception
            MessageBox.Show("Error" & ex.Message)
        End Try
    End Sub
    'actualizar
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActualizar.Click
        flagAccion = "A"
        Dim oP As New ProductoBE
        With oP
            .IdProducto = Convert.ToInt32(txtIdProducto.Text)
            .NombreProducto = txtNombreProducto.Text
            .TipoProducto = cboProducto.Text
            .StockProducto = Convert.ToInt32(txtStockProducto.Text)
            .PrecioProducto = Convert.ToDecimal(txtPrecioProducto.Text)
            Dim data() As Byte
            If Not Me.PictureBox1.Image Is Nothing Then
                Dim ms As New MemoryStream
                Me.PictureBox1.Image.Save(ms, Imaging.ImageFormat.Jpeg)
                data = ms.ToArray
            Else
                data = Nothing
            End If
            .FotoProducto = data
            .Ruta = TextBox1.Text
        End With
        Try
            If oProductoBL.ActualizarProducto(oP, flagAccion) Then
                dwgProducto.DataSource = oProductoBL.listarProductos
                MessageBox.Show("El producto ha sido actualizado exitosamente")
                limpiar()
                txtIdProducto.Text = Convert.ToString(oProductoBL.ObtenerIdProducto)
            End If
        Catch ex As Exception
            MessageBox.Show("Error")
            dwgProducto.DataSource = oProductoBL.listarProductos
        End Try
    End Sub
    'eliminar
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        flagAccion = "E"
        Dim oP As New ProductoBE
        With oP
            .IdProducto = Convert.ToInt32(txtIdProducto.Text)
        End With
        Try
            If oProductoBL.EliminarProducto(oP, flagAccion) Then
                dwgProducto.DataSource = oProductoBL.listarProductos
                MessageBox.Show("El producto ha sido removido exitosamente")
                oProductoBL.ObtenerIdProducto()
            End If
        Catch ex As Exception
            MessageBox.Show("Error" & ex.Message)
        End Try
    End Sub
    'cancelar
    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        If CBool(MsgBox("Desea Salir del formulario actual?", MsgBoxStyle.YesNo, "Salir Formulario")) Then
            Me.Close()
            FrmBienvenida.Show()
        End If
    End Sub
    'obtener registros
    Private Sub DataGridView1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dwgProducto.CellClick
        With dwgProducto.CurrentRow
            txtIdProducto.Text = .Cells(0).Value.ToString
            txtNombreProducto.Text = .Cells(1).Value.ToString
            cboProducto.Text = .Cells(2).Value.ToString
            txtStockProducto.Text = .Cells(3).Value.ToString
            txtPrecioProducto.Text = .Cells(4).Value.ToString
            PictureBox1.Image = CType(.Cells(5).FormattedValue, Image)
            TextBox1.Text = .Cells(6).Value.ToString
        End With
    End Sub
    'limpiar
    Public Sub limpiar()
        txtIdProducto.Text = Nothing
        txtNombreProducto.Text = Nothing
        cboProducto.Text = Nothing
        txtStockProducto.Text = Nothing
        txtPrecioProducto.Text = Nothing
        PictureBox1.Image = Nothing
        TextBox1.Text = Nothing
    End Sub
    'validacion
    Private Function Validaciones() As Boolean
        Dim result As Boolean = True
        If String.IsNullOrEmpty(txtIdProducto.Text) Then
            MsgBox("Debe ingresar el codigo", MsgBoxStyle.Exclamation, "Advertencia")
            result = False
        ElseIf String.IsNullOrEmpty(txtNombreProducto.Text) Then
            MsgBox("Debe ingresar el nombre del producto", MsgBoxStyle.Exclamation, "Advertencia")
            result = False
        ElseIf String.IsNullOrEmpty(cboProducto.Text) Then
            MsgBox("Debe ingresar el tipo de producto", MsgBoxStyle.Exclamation, "Advertencia")
            result = False
        ElseIf String.IsNullOrEmpty(txtStockProducto.Text) Then
            MsgBox("Debe ingresar el stock", MsgBoxStyle.Exclamation, "Advertencia")
            result = False
        ElseIf String.IsNullOrEmpty(txtPrecioProducto.Text) Then
            MsgBox("Debe ingresar el precio", MsgBoxStyle.Exclamation, "Advertencia")
            result = False
        End If
        Return result
    End Function
    'opcion segun boton seleccionado
    Public Sub MostrarBotones()
        If ComboBox1.SelectedIndex = 0 Then
            btnGrabar.Visible = True
            btnActualizar.Visible = False
            btnEliminar.Visible = False
            txtIdProducto.ReadOnly = True
            lblNombre.Visible = True
            txtNombreProducto.Visible = True
            lblTipo.Visible = True
            cboProducto.Visible = True
            txtStockProducto.Visible = True
            lblStock.Visible = True
            lblPrecio.Visible = True
            txtPrecioProducto.Visible = True
            Label1.Visible = True
            btnAgregar.Visible = True
            btnQuitar.Visible = True
            PictureBox1.Visible = True
            TextBox1.Visible = True
        End If
        If ComboBox1.SelectedIndex = 1 Then
            btnGrabar.Visible = False
            btnEliminar.Visible = False
            btnActualizar.Visible = True
            txtIdProducto.ReadOnly = True
            lblNombre.Visible = True
            txtNombreProducto.Visible = True
            lblTipo.Visible = True
            cboProducto.Visible = True
            txtStockProducto.Visible = True
            lblStock.Visible = True
            lblPrecio.Visible = True
            txtPrecioProducto.Visible = True
            Label1.Visible = True
            btnAgregar.Visible = True
            btnQuitar.Visible = True
            PictureBox1.Visible = True
            TextBox1.Visible = True
        End If
        If ComboBox1.SelectedIndex = 2 Then
            btnGrabar.Visible = False
            btnActualizar.Visible = False
            btnEliminar.Visible = True
            lblNombre.Visible = False
            txtNombreProducto.Visible = False
            lblTipo.Visible = False
            cboProducto.Visible = False
            txtStockProducto.Visible = False
            lblStock.Visible = False
            lblPrecio.Visible = False
            txtPrecioProducto.Visible = False
            txtIdProducto.ReadOnly = False
            Label1.Visible = False
            btnAgregar.Visible = False
            btnQuitar.Visible = False
            PictureBox1.Visible = False
            TextBox1.Visible = False
        End If
        If ComboBox1.SelectedIndex = 3 Then
            btnGrabar.Visible = False
            btnActualizar.Visible = False
            btnEliminar.Visible = False
            lblNombre.Visible = True
            txtNombreProducto.Visible = True
            lblTipo.Visible = False
            cboProducto.Visible = False
            txtStockProducto.Visible = False
            lblStock.Visible = False
            lblPrecio.Visible = False
            txtPrecioProducto.Visible = False
            txtIdProducto.ReadOnly = False
            Label1.Visible = False
            btnAgregar.Visible = False
            btnQuitar.Visible = False
            PictureBox1.Visible = False
            TextBox1.Visible = False
        End If
    End Sub
    'muestra controles segun boton seleccionado
    Private Sub ComboBox1_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedValueChanged
        MostrarBotones()
    End Sub
    'agrega foto
    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        Dim op As New OpenFileDialog
        op.Filter = "Archivos Imagen|*.jpg"
        op.Multiselect = False
        op.Title = "Seleccione su Foto"
        If op.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.PictureBox1.Image = Image.FromFile(op.FileName)
            PictureBox1.Tag = op.FileName
            TextBox1.Text = Convert.ToString(PictureBox1.Tag)
        End If
    End Sub
    'quita foto
    Private Sub btnQuitar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuitar.Click
        PictureBox1.Image = Nothing
    End Sub
End Class