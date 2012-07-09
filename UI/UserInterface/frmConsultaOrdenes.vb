Imports BusinessEntities
Imports BusinessLayer
Public Class frmConsultaOrdenes
    Dim oClienteBL As New ClienteBL
    Dim oOrdenBL As New OrdenBL
    Public Sub cargar()
        ComboBox1.DataSource = oClienteBL.ListarClientes
        ComboBox1.DisplayMember = "Nombre"
        ComboBox1.ValueMember = "IdCliente"
    End Sub
    Private Sub frmConsultaOrdenes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar()
    End Sub

    Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
        Dim oOrden As New OrdenBE
        oOrden.Cliente = ComboBox1.Text
        oOrden.FechaEnvio = DateTimePicker1.Value
        oOrden.FechaLlegada = DateTimePicker2.Value

        DataGridView1.DataSource = oOrdenBL.FiltrarOrdenesFechas(oOrden)
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        If CBool(MsgBox("Desea Salir del formulario actual?", MsgBoxStyle.YesNo, "Salir Formulario")) Then
            Me.Close()
        End If
        FrmBienvenida.Show()
    End Sub
End Class