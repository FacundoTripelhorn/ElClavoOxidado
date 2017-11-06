Public Class Producto
    Property Codigo As Integer
    Property Categoria As Categoria
    Property Proveedor As Proveedor
    Property Descripcion As String
    Property Precio As Decimal
    ReadOnly Property total As Decimal
        Get
            Return Precio * cantidad
        End Get
    End Property
    Property cantidad As Integer

    Sub New()

    End Sub

    Sub New(_codigo As Integer, _categoria As Categoria, _proveedor As Proveedor, _descripcion As String, _precio As Decimal)
        Codigo = _codigo
        Categoria = _categoria
        Proveedor = _proveedor
        Descripcion = _descripcion
        Precio = _precio
    End Sub
End Class
