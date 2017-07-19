Imports Entity
Imports DAL
Public Class Categoria

    Dim _dal As New DAL_Categoria
    Public Function Check_Categoria(_categoria As Entity.Categoria) As Boolean
        Return _dal.Check_Categoria(_categoria)
    End Function

    Public Function Get_Categoria(_id As Integer) As Entity.Categoria
        Return _dal.Get_Categoria(_id)
    End Function

    Public Function Get_Categorias() As List(Of Entity.Categoria)
        Return _dal.Get_Categorias
    End Function

End Class
