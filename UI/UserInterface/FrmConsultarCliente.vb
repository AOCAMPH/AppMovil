Imports BusinessEntities
Imports BusinessLayer
Public Class FrmConsultarCliente
    Private oClienteBL As New ClienteBL
    Dim oC As New ClienteBE
    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim oC As New ClienteBE
        With oC
            .Nombre = txtNombre.Text
        End With
        If txtNombre.Text = "" Then
            MsgBox("Seleccione un Registro", MsgBoxStyle.Critical)
        End If
        Dim Nombre As String = txtNombre.Text
        DataGridView1.DataSource = oClienteBL.buscarCliente(oC)
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        If CBool(MsgBox("Desea Salir del formulario actual?", MsgBoxStyle.YesNo, "Salir Formulario")) Then
            Me.Close()
        End If
        FrmBienvenida.Show()
    End Sub

    Private Sub txtNombre_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNombre.TextChanged

        With oC
            .Nombre = txtNombre.Text
        End With
        Try
            DataGridView1.DataSource = oClienteBL.buscarCliente(oC)
        Catch ex As Exception
            MessageBox.Show("Error:" & ex.Message)
        End Try

    End Sub
End Class