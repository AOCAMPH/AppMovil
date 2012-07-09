Imports BusinessEntities
Imports BusinessLayer
Class WndLogin
    Private oUsuarioBL As New UsuariosBL
    Dim WB As New WndBienvenida
    Private Sub btnIngresar_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles btnIngresar.Click
        Dim oU As New UsuarioBE
        With oU
            .IdUsuario = txtUsuario.Text
            .PasswordUsuario = txtClave.text
        End With
        Try
            If oUsuarioBL.AutenticarUsuario(oU) Then
                MessageBox.Show("Bienvenido usuario" + " " + txtUsuario.Text.ToUpper)
                Me.Hide()
                WB.Show()
                limpiar()
            End If
        Catch ex As Exception
            MessageBox.Show("Verificar sus datos de ingreso")
        End Try
    End Sub
    Sub limpiar()
        txtUsuario.Text = Nothing
        txtClave.Text = Nothing
    End Sub

    Private Sub WndLogin_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles Me.Closing
        If MessageBox.Show("¿Esta seguro que desea salir de la aplicacón?", "Módulo de ", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No) = MessageBoxResult.No Then
            e.Cancel = True
        Else
            e.Cancel = False
        End If
    End Sub
End Class
