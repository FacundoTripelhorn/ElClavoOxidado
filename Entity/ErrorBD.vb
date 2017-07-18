Public Class ErrorBD
    Property Id As Integer
    Property Tabla As String
    Property Campo As Integer

    Sub New()

    End Sub

    Sub New(_id As Integer, _tabla As String, _campo As Integer)
        Id = _id
        Tabla = _tabla
        Campo = _campo
    End Sub
End Class
