Imports System.IO
Public Class Backup
    Inherits System.Web.UI.Page

    Dim _backup As New Negocio.BackupRestore

    Protected Property SuccessMessageText() As String
        Get
            Return m_SuccessMessage
        End Get
        Private Set(value As String)
            m_SuccessMessage = value
        End Set
    End Property
    Private m_SuccessMessage As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub Backup_PreLoad(sender As Object, e As EventArgs) Handles Me.PreLoad
        If Not Context.User.IsInRole("1") Then
            Response.Redirect("Default", True)
        End If
    End Sub

    Protected Sub BackupBtn_Click(sender As Object, e As EventArgs) Handles BackupBtn.Click
        Dim _usuarioEntity As New Entity.Usuario
        _usuarioEntity.Usuario = HttpContext.Current.User.Identity.Name
        If Not Directory.Exists("C:\BK\") Then
            Directory.CreateDirectory("C:\BK\")
        End If
        Dim _path As String = "C:\BK\"
        Dim _nombre As String = Nombre.Text
            _backup.Crear_Backup(_path, _nombre)
        CargarBitacora(_usuarioEntity.Usuario, _nombre)
        SuccessMessageText = "Se ha realizado el backup de la base exitosamente en el archivo " + _path + _nombre + ".bak"
        successMessage.Visible = True
        Nombre.Text = ""
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
        _bitacoraEntity.Tipo = "Creación de Backup"
        _bitacoraEntity.Actividad = _usuario & " creó el backup: " & _nombre
        _bitacoraNeg.Alta_Bitacora(_bitacoraEntity)
    End Sub
End Class