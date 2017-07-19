Imports DAL
Public Class Proveedor

    Dim _dal As New DAL_Proveedor

    Public Function Check_Proveedor(_proveedor As Entity.Proveedor) As Boolean
        Return _dal.Check_Proveedor(_proveedor)
    End Function

    Public Function Get_Proveedor(_id As Integer) As Entity.Proveedor
        Return _dal.Get_Proveedor(_id)
    End Function

    Public Function Get_Proveedores() As List(Of Entity.Proveedor)
        Return _dal.Get_Proveedores
    End Function
End Class
