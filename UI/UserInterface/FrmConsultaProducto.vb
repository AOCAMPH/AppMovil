Imports BusinessEntities
Imports BusinessLayer

Public Class FrmConsultaProducto
    Private oProductoBL As New ProductoBL
    Private oP As New ProductoBE
   

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        If CBool(MsgBox("Desea Salir del formulario actual?", MsgBoxStyle.YesNo, "Salir Formulario")) Then
            Me.Close()
        End If
        FrmBienvenida.Show()
    End Sub

    Private Sub txtNombreProducto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNombreProducto.TextChanged
        With oP
            .NombreProducto = txtNombreProducto.Text
        End With
        Try
            DataGridView1.DataSource = oProductoBL.BuscarProducto(oP)
        Catch ex As Exception
            MessageBox.Show("Error:" & ex.Message)
        End Try
    End Sub
End Class