Public Class Categoria
    Property Id As Integer
    Property Nombre As String

    Sub New()

    End Sub

    Sub New(_Id As Integer, _Nombre As String)
        Id = _Id
        Nombre = _Nombre
    End Sub
End Class
