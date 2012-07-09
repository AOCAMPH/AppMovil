Imports BusinessEntities
Imports BusinessLayer
Public Class FrmLogin
    Private oUsuarioBL As New UsuariosBL
    Private Sub btnLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogin.Click
        Dim oU As New UsuarioBE
        With oU
            .IdUsuario = txtUsuario.Text
            .PasswordUsuario = txtPassword.Text
        End With
        Try
            If oUsuarioBL.AutenticarUsuario(oU) Then
                MessageBox.Show("Bienvenido usuario" + " " + txtUsuario.Text.ToUpper)
                FrmBienvenida.Show()
                Me.Hide()
                limpiar()
            End If
        Catch ex As Exception
            MessageBox.Show("Verificar sus datos de ingreso")
        End Try
    End Sub
    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        If CBool(MsgBox("Desea Salir del formulario actual?", MsgBoxStyle.YesNo, "Salir Formulario")) Then
            Me.Close()
        End If
    End Sub
    Sub limpiar()
        txtUsuario.Text = Nothing
        txtPassword.Text = Nothing
    End Sub

End Class