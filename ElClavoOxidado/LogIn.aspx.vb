Imports Negocio
Imports Entity
Public Class LogIn
    Inherits System.Web.UI.Page

    Dim _usuarioNeg As New Negocio.Usuario
    Dim _usuarioEntity As Entity.Usuario
    Dim _bitacoraNeg As New Negocio.Bitacora
    Dim _bitacoraEntity As Entity.Bitacora


    Protected Sub LogInBtn_Click(sender As Object, e As EventArgs) Handles LogInBtn.Click
        _usuarioEntity = New Entity.Usuario With {.Usuario = UserName.Text, .Password = Password.Text}
        Try
            If Password.Text.Length > 5 Then
                If _usuarioNeg.Validar_Login(_usuarioEntity, _usuarioEntity.Password) Then
                    If RememberMe.Checked Then
                        FormsAuthentication.SetAuthCookie(UserName.Text, True)
                    Else
                        FormsAuthentication.SetAuthCookie(UserName.Text, False)
                    End If
                    If Roles.IsUserInRole(_usuarioEntity.Usuario, _usuarioEntity.Familia) = False Then
                        Roles.AddUserToRole(_usuarioEntity.Usuario, _usuarioEntity.Familia)
                    End If
                    CargarBitacora(_usuarioEntity.Usuario)

                    ''Select Case _usuarioEntity.Familia.ToString
                    'Case 1
                    'ScriptManager.RegisterClientScriptBlock(Me, Me.GetType, "Bienvenido Webmaster", "alert('Bienvenido WebMaster')", True)
                    'Case 2
                    'ScriptManager.RegisterClientScriptBlock(Me, Me.GetType, "Bienvenido administrador", "alert('Bienvenido Administrador')", True)
                    'Case 3
                    'ScriptManager.RegisterClientScriptBlock(Me, Me.GetType, "Bienvenido Usuario", "alert('Bienvenido Cliente')", True)
                    'Case Else

                    'End Select
                    Response.Redirect("/Default", True)

                Else
                    _usuarioEntity.Cant_Bloqueos += 1
                End If
            End If
        Catch ex As Exception
            If Not TryCast(ex, Entity.Excepcion_Login) Is Nothing Then
                Dim miError As Entity.Excepcion_Login = DirectCast(ex, Entity.Excepcion_Login)
                If miError.Descripcion = "Usuario invalido" Then
                    ScriptManager.RegisterClientScriptBlock(Me, Me.GetType, "Usuario Invalido", "alert('Usuario inválido. Si aún no se registro presione la opción Registrarse')", True)
                ElseIf miError.Descripcion = "Usuario Bloqueado" Then
                    ScriptManager.RegisterClientScriptBlock(Me, Me.GetType, "Usuario bloqueado", "alert('Usuario bloqueado, por favor contactese con el web master')", True)
                ElseIf miError.Descripcion = "Password invalida" Then
                    ScriptManager.RegisterClientScriptBlock(Me, Me.GetType, "Contraseña invalida", "alert('Contraseña incorrecta')", True)
                End If



            End If

        End Try
    End Sub

    Private Sub LogIn_PreLoad(sender As Object, e As EventArgs) Handles Me.PreLoad
        Dim isSomeoneLoggedIn As Boolean = HttpContext.Current.User.Identity.IsAuthenticated
        If isSomeoneLoggedIn Then
            Response.Redirect("~/Default", True)
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
        _bitacoraEntity.Tipo = "Inicio de sesión"
        _bitacoraEntity.Actividad = usuario & " inició sesión"
        _bitacoraNeg.Alta_Bitacora(_bitacoraEntity)
    End Sub
End Class