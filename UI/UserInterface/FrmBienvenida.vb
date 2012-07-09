Imports BusinessLayer
Public Class FrmBienvenida
    Private Sub SalirToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalirToolStripMenuItem1.Click
        If CBool(MsgBox("Desea Salir del formulario actual?", MsgBoxStyle.YesNo, "Salir Formulario")) Then
            Application.Exit()
        End If
    End Sub
    Private Sub InicioToolStripMenuItem1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InicioToolStripMenuItem1.Click
        Me.Hide()
        FrmLogin.Show()
    End Sub
    Private Sub FrmBienvenida_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Label2.Text = FrmLogin.txtUsuario.Text.ToUpper
    End Sub

    Private Sub ConsultarOrdenesPorFechasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConsultarOrdenesPorFechasToolStripMenuItem.Click
        Me.Hide()
        frmConsultaOrdenes.Show()
    End Sub

    Private Sub ConsultarClienteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConsultarClienteToolStripMenuItem.Click
        Me.Hide()
        FrmConsultarCliente.Show()
    End Sub
    Private Sub MantenerClienteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MantenerClienteToolStripMenuItem.Click
        Me.Hide()
        form2.Show()
    End Sub
    Private Sub MantenerProductoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MantenerProductoToolStripMenuItem.Click
        Me.Hide()
        FrmProducto.Show()
    End Sub

    Private Sub ConsultarProductoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConsultarProductoToolStripMenuItem.Click
        Me.Hide()
        FrmConsultaProducto.Show()
    End Sub

    Private Sub MantenerOrdenesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MantenerOrdenesToolStripMenuItem.Click
        Me.Hide()
        FrmOrden.Show()
    End Sub
End Class