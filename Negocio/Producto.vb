Imports DAL
Public Class Producto

    Dim _dal As New DAL_Producto

    Public Function Check_Producto(_producto As Entity.Producto) As Boolean
        Return _dal.Check_Producto(_producto)
    End Function

    Public Function Obtener_Productos() As List(Of Entity.Producto)
        Return _dal.Obtener_Productos
    End Function

    Public Sub Alta_Producto(_producto As Entity.Producto)
        _dal.Alta_Producto(_producto)
    End Sub

    Public Function Get_Producto(_codigo As Integer) As Entity.Producto
        Return _dal.Get_Producto(_codigo)
    End Function
End Class
