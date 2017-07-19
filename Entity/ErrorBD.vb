Public Class ErrorBD
    Property Id As Integer
    Property Tabla As String
    Property Fila As Integer

    Sub New()

    End Sub

    Sub New(_id As Integer, _tabla As String, _fila As Integer)
        Id = _id
        Tabla = _tabla
        Fila = _fila
    End Sub
End Class
