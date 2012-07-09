Imports BusinessEntities
Imports BusinessLayer
Public Class FrmListadoOrden
    Private oOrdenBL As New OrdenBL
    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        Dim frmOrden As New FrmOrden
        frmOrden.txtNroOrden.Text = CStr(oOrdenBL.ObtenerIdOrden())
        frmOrden.ShowDialog()
        dgwMaestro.DataSource = oOrdenBL.ListarOrdenes
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If CBool(MsgBox("Desea Salir del formulario actual?", MsgBoxStyle.YesNo, "Salir Formulario")) Then
            Me.Close()
        End If
        FrmBienvenida.Show()
    End Sub

    Private Sub FrmListadoOrden_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        dgwMaestro.DataSource = oOrdenBL.ListarOrdenes
    End Sub

    Private Sub dgwMaestro_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgwMaestro.CellContentClick
        Dim cliente As String = CStr(dgwMaestro.CurrentRow.Cells(1).Value)
        dgwDetalle.DataSource = oOrdenBL.ListarDetalles(cliente)
        Label2.Text = CStr(dgwDetalle.RowCount)
        dgwDetalle.Columns _
        (dgwDetalle.Columns.Count - 1).Visible = True
        dgwDetalle.Columns _
        (dgwDetalle.Columns.Count - 2).Visible = True
    End Sub
End Class