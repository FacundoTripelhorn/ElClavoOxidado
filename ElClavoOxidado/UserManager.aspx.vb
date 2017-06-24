Imports Entity
Imports Negocio
Public Class UserManager
    Inherits System.Web.UI.Page

    Dim _usuarioNeg As New Negocio.Usuario
    Dim _usuarioEntity As Entity.Usuario

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Llenar_Grilla()
        Llenar_Combo()
    End Sub

    Protected Sub UpdateUsuarioBtn_Click(sender As Object, e As EventArgs) Handles UpdateUsuarioBtn.Click
        _usuarioNeg.Asignar_Rol(Username.Text, Familia.SelectedIndex + 1)
        Llenar_Grilla()
    End Sub

    Private Sub Llenar_Grilla()
        Dim _listaUsuario As New List(Of VistaUsuario)
        GrillaUsuarios.DataSource = Nothing
        For Each _usuario As Entity.Usuario In _usuarioNeg.Get_Usuarios
            _listaUsuario.Add(New VistaUsuario(_usuario.Usuario, _usuario.Email, _usuario.Familia, _usuario.Bloqueado))
        Next
        GrillaUsuarios.DataSource = _listaUsuario
        GrillaUsuarios.DataBind()
    End Sub

    Private Sub Llenar_Combo()
        Familia.Items.Add("Webmaster")
        Familia.Items.Add("Administrador")
        Familia.Items.Add("Cliente")
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
        _bitacoraEntity.Tipo = "Asignación de rol"
        _bitacoraEntity.Actividad = "El usuario " & usuario & "le asigno al usuario " & Username.Text & " el rol de " & Familia.Text
        _bitacoraNeg.Alta_Bitacora(_bitacoraEntity)
    End Sub
End Class