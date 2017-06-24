Public Class Usuario
    Public Property Usuario As String
    Public Property Email As String
    Public Property Password As String
    Public Property IsValid As Boolean
    Public Property Bloqueado As Boolean
    Public Property Cant_Bloqueos As Integer
    Public Property Ultimo_intento As Date
    Public Property Familia As Integer

    Sub New()

    End Sub

    Sub New(_usuario As String, _email As String, _password As String, _familia As Integer, _bloqueado As Boolean)
        Usuario = _usuario
        Email = _email
        Password = _password
        Familia = _familia
        Bloqueado = _bloqueado
    End Sub

End Class
