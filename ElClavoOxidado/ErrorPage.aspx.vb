Public Class ErrorPage
    Inherits System.Web.UI.Page

    Dim _backup As New Negocio.BackupRestore
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        GrillaError.DataSource = Session("ListaError")
        GrillaError.DataBind()
    End Sub

    Private Sub ErrorPage_PreLoad(sender As Object, e As EventArgs) Handles Me.PreLoad
        If Not Context.User.IsInRole("1") Then
            Response.Redirect("Default", True)
        End If
        If Session("CheckError") = 0 Then
            Response.Redirect("Default", True)
        End If
    End Sub

    Protected Sub RestoreBtn_Click(sender As Object, e As EventArgs) Handles RestoreBtn.Click
        Dim _usuarioEntity As New Entity.Usuario
        _usuarioEntity.Usuario = HttpContext.Current.User.Identity.Name
        Dim _path As String = "C:\BK\"
        Dim _nombre As String = Nombre.Text
        _backup.Restore_BD(_path, _nombre)
        Session("CheckError") = 0
        CargarBitacora(_usuarioEntity.Usuario, _nombre)
    End Sub

    Private Sub CargarBitacora(_usuario As String, _nombre As String)
        Dim _bitacoraNeg As New Negocio.Bitacora
        Dim _bitacoraEntity As New Entity.Bitacora

        Dim _listaBitacora = _bitacoraNeg.Obtener_Bitacora()
        If _listaBitacora.Count > 0 Then
            _bitacoraEntity.Id = _listaBitacora.Last.Id + 1
        Else
            _bitacoraEntity.Id = 1
        End If
        _bitacoraEntity.Usuario = _usuario
        _bitacoraEntity.Tipo = "Restauración de backup"
        _bitacoraEntity.Actividad = _usuario & " restauró el backup: " & _nombre
        _bitacoraNeg.Alta_Bitacora(_bitacoraEntity)
    End Sub
End Class