Public Class MiCuenta
    Inherits System.Web.UI.Page

    Protected Property SuccessMessageText() As String
        Get
            Return m_SuccessMessage
        End Get
        Private Set(value As String)
            m_SuccessMessage = value
        End Set
    End Property
    Private m_SuccessMessage As String

    Dim _usuarioNeg As New Negocio.Usuario
    Dim _usuarioEntity As Entity.Usuario

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub CambiarContraseñaBtn_Click(sender As Object, e As EventArgs) Handles CambiarContraseñaBtn.Click
        _usuarioEntity = New Entity.Usuario
        If ContraseñaNueva.Text = ConfirmarContraseña.Text Then
            _usuarioEntity.Usuario = HttpContext.Current.User.Identity.Name
            _usuarioEntity.Password = ContraseñaActual.Text
            If _usuarioNeg.Validar_Login(_usuarioEntity, _usuarioEntity.Password) Then
                _usuarioNeg.Cambiar_Contraseña(_usuarioEntity.Usuario, ContraseñaNueva.Text)
                CargarBitacora(_usuarioEntity.Usuario)
                SuccessMessageText = "Cambio de contraseña exitoso"
                successMessage.Visible = True
                changePasswordHolder.Visible = False
                ContraseñaActual.Text = ""
                ContraseñaNueva.Text = ""
                ConfirmarContraseña.Text = ""
            End If
        End If
    End Sub

    Private Sub CargarBitacora(usuario As String)
        Dim _bitacoraNeg As New Negocio.Bitacora
        Dim _bitacoraEntity As New Entity.Bitacora

        Dim _listaBitacora = _bitacoraNeg.Obtener_Bitacora()
        If _listaBitacora.Count > 0 Then
            _bitacoraEntity.Id = _listaBitacora.Last.Id + 1
        Else
            _bitacoraEntity.Id = 1
        End If
        _bitacoraEntity.Usuario = usuario
        _bitacoraEntity.Tipo = "Cambio de contraseña"
        _bitacoraEntity.Actividad = usuario & " cambió su contraseña"
        _bitacoraNeg.Alta_Bitacora(_bitacoraEntity)
    End Sub
End Class