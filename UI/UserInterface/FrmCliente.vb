Imports BusinessEntities
Imports BusinessLayer
Imports System.IO
Public Class form2
    Private oClienteBL As New ClienteBL
    Private oOpcionBL As New OpcionBL
    'Private oE As New ClienteBE
    Dim flagAccion As String = ""
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        label4.Text = FrmBienvenida.Label2.Text.ToUpper
        dgwCliente.DataSource = oClienteBL.ListarClientes
        txtCodigo.Text = CStr(oClienteBL.obtenerIdCliente)
        CargarPais()
        CargarOpcion()
    End Sub
    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        If Not Validaciones() Then
            Return
        Else
            flagAccion = "I"
            Dim oE As New ClienteBE
            With oE
                .IdCliente = txtCodigo.Text
                .Nombre = txtNombre.Text
                .Direccion = cboPais.Text
                .DNI = txtDNI.Text
                .Fecha = dtpFecha.Value
                Dim data() As Byte
                If Not Me.PictureBox1.Image Is Nothing Then
                    Dim ms As New MemoryStream
                    Me.PictureBox1.Image.Save(ms, Imaging.ImageFormat.Jpeg)
                    data = ms.ToArray
                Else
                    data = Nothing
                End If
                .Foto = data
                .Ruta = TextBox1.Text
            End With
            Try
                If oClienteBL.InsertaCliente(oE, flagAccion) Then
                    dgwCliente.DataSource = oClienteBL.ListarClientes
                    flagAccion = ""
                    MessageBox.Show("El cliente ha sido insertado exitosamente")
                    txtCodigo.Text = CStr(oClienteBL.obtenerIdCliente)
                    limpiar()
                End If
            Catch ex As Exception
                MessageBox.Show("La operacion no ha podido realizarse")
            End Try
        End If
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Private Sub btnActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActualizar.Click
        'actualizar
        If Not Validaciones() Then
            Return
        Else
            flagAccion = "A"
            Dim oE As New ClienteBE
            With oE
                .IdCliente = txtCodigo.Text
                .Nombre = txtNombre.Text
                .Direccion = cboPais.Text
                .DNI = txtDNI.Text
                .Fecha = CDate(dtpFecha.Text)
                Dim data() As Byte
                If Not Me.PictureBox1.Image Is Nothing Then
                    Dim ms As New MemoryStream
                    Me.PictureBox1.Image.Save(ms, Imaging.ImageFormat.Jpeg)
                    data = ms.ToArray
                Else
                    data = Nothing
                End If
                .Foto = data
                .Ruta = TextBox1.Text
            End With
            Try
                If oClienteBL.ActualizaCliente(oE, flagAccion) Then
                    dgwCliente.DataSource = oClienteBL.ListarClientes
                    flagAccion = ""
                    MessageBox.Show("El cliente ha sido actualizado exitosamente")
                    limpiar()
                    txtCodigo.Text = CStr(oClienteBL.obtenerIdCliente)
                End If
            Catch ex As Exception
                MessageBox.Show("Error:" & ex.Message)
            End Try
        End If
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        If txtCodigo.Text = "" Then
            MsgBox("Seleccione un Registro", MsgBoxStyle.Critical)
        End If
        flagAccion = "E"
        Dim oE As New ClienteBE
        With oE
            .IdCliente = txtCodigo.Text
        End With
        If MessageBox.Show("Esta seguro de Eliminar el Registro", _
                           "Tutorial", MessageBoxButtons.YesNo, MessageBoxIcon.Question, _
                           MessageBoxDefaultButton.Button1) = DialogResult.Yes Then
            Try
                If oClienteBL.EliminarCliente(oE, flagAccion) Then
                    dgwCliente.DataSource = oClienteBL.ListarClientes
                    flagAccion = ""
                    MessageBox.Show("El cliente ha sido removido exitosamente")
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message.GetType.ToString)
            End Try
        End If
    End Sub
    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        If CBool(MsgBox("Desea Salir del formulario actual?", MsgBoxStyle.YesNo, "Salir Formulario")) Then
            Me.Close()
        End If
        FrmBienvenida.Show()
    End Sub
    Private Sub DataGridView1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgwCliente.CellClick
        With dgwCliente.CurrentRow
            txtCodigo.Text = .Cells(0).Value.ToString
            txtNombre.Text = .Cells(1).Value.ToString
            cboPais.Text = .Cells(2).Value.ToString
            txtDNI.Text = .Cells(3).Value.ToString
            dtpFecha.Text = .Cells(4).Value.ToString
            If IsDBNull(.Cells(5).Value.ToString) = True Then
                PictureBox1.ImageLocation = "Resources/NoDisponible.jpg"
            Else
                PictureBox1.Image = CType(.Cells(5).FormattedValue, Image)
            End If
            TextBox1.Text = .Cells(6).Value.ToString
        End With
    End Sub
    Public Sub limpiar()
        txtNombre.Text = Nothing
        cboPais.Text = Nothing
        txtDNI.Text = Nothing
        dtpFecha.Text = Nothing
        PictureBox1.Image = Nothing
        TextBox1.Text = Nothing
    End Sub
    Private Function Validaciones() As Boolean
        Dim result As Boolean = True
        If String.IsNullOrEmpty(txtNombre.Text) Then
            MsgBox("Debe ingresar el nombre del cliente", MsgBoxStyle.Exclamation, "Advertencia")
            result = False
        ElseIf String.IsNullOrEmpty(cboPais.Text) Then
            MsgBox("Debe ingresar la direccion del cliente", MsgBoxStyle.Exclamation, "Advertencia")
            result = False
        ElseIf String.IsNullOrEmpty(txtDNI.Text) Then
            MsgBox("Debe ingresar el dni del cliente", MsgBoxStyle.Exclamation, "Advertencia")
            result = False
        ElseIf String.IsNullOrEmpty(dtpFecha.Text) Then
            MsgBox("Debe ingresar la fecha de Registro", MsgBoxStyle.Exclamation, "Advertencia")
            result = False
        End If
        Return result
    End Function
    Public Sub CargarPais()
        cboPais.DataSource = oClienteBL.obtenerPais
        cboPais.DisplayMember = "NombrePais"
        cboPais.ValueMember = "IdPais"
    End Sub
    Public Sub CargarOpcion()
        ComboBox1.DataSource = oOpcionBL.obtenerOpcion
        ComboBox1.DisplayMember = "Descripcion"
        ComboBox1.ValueMember = "IdOpcion"
    End Sub
    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        FrmListadoOrden.Show()
    End Sub
    Public Sub MostrarBotones()
        'grabar
        If ComboBox1.SelectedIndex = 0 Then
            btnGrabar.Enabled = True
            btnActualizar.Enabled = False
            btnEliminar.Enabled = False
            txtCodigo.ReadOnly = True
            lblNombre.Visible = True
            txtNombre.Visible = True
            lblPais.Visible = True
            cboPais.Visible = True
            lblDNI.Visible = True
            txtDNI.Visible = True
            lblFecha.Visible = True
            dtpFecha.Visible = True
            Label1.Visible = True
            btnBusca.Visible = True
            btnQuitar.Visible = True
            PictureBox1.Visible = True
            TextBox1.Visible = True
        End If
        'actualizar
        If ComboBox1.SelectedIndex = 1 Then
            btnGrabar.Enabled = False
            btnEliminar.Enabled = False
            btnActualizar.Enabled = True
            txtCodigo.ReadOnly = True
            lblNombre.Visible = True
            txtNombre.Visible = True
            lblPais.Visible = True
            cboPais.Visible = True
            lblDNI.Visible = True
            txtDNI.Visible = True
            lblFecha.Visible = True
            dtpFecha.Visible = True
            Label1.Visible = True
            btnBusca.Visible = True
            btnQuitar.Visible = True
            PictureBox1.Visible = True
            TextBox1.Visible = True
        End If
        'eliminar
        If ComboBox1.SelectedIndex = 2 Then
            btnGrabar.Enabled = False
            btnActualizar.Enabled = False
            btnEliminar.Enabled = True
            txtCodigo.ReadOnly = False
            lblNombre.Visible = False
            txtNombre.Visible = False
            lblPais.Visible = False
            cboPais.Visible = False
            lblDNI.Visible = False
            txtDNI.Visible = False
            lblFecha.Visible = False
            dtpFecha.Visible = False
            Label1.Visible = False
            btnBusca.Visible = False
            btnQuitar.Visible = False
            PictureBox1.Visible = False
            TextBox1.Visible = False
        End If
        'consultar
        If ComboBox1.SelectedIndex = 3 Then
            btnGrabar.Enabled = False
            btnActualizar.Enabled = False
            btnEliminar.Enabled = False
            txtCodigo.ReadOnly = False
            lblNombre.Visible = True
            txtNombre.Visible = True
            lblPais.Visible = False
            cboPais.Visible = False
            lblDNI.Visible = False
            txtDNI.Visible = False
            lblFecha.Visible = False
            dtpFecha.Visible = False
            Label1.Visible = False
            btnBusca.Visible = False
            btnQuitar.Visible = False
            PictureBox1.Visible = False
            TextBox1.Visible = False
        End If
    End Sub
    Private Sub ComboBox1_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedValueChanged
        MostrarBotones()
    End Sub
    Private Sub btnBusca_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBusca.Click
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
    Private Sub btnQuitar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuitar.Click
        PictureBox1.Image = Nothing
        TextBox1.Text = Nothing
    End Sub
End Class