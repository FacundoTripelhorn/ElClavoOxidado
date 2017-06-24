Public Class VistaUsuario
    Property Usuario As String
    Property Email As String
    Property Familia As Integer
    Property Bloqueado As Boolean

    Sub New()

    End Sub

    Sub New(_usuario As String, _email As String, _familia As Integer, _bloqueado As Boolean)
        Usuario = _usuario
        Email = _email
        Familia = _familia
        Bloqueado = _bloqueado
    End Sub
End Class
