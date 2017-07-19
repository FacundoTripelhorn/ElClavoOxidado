Imports Negocio
Public Class _Default
    Inherits Page

    Dim _dal_proveedor As New Negocio.Proveedor
    Dim _dal_categoria As New Negocio.Categoria
    Dim _dal_producto As New Negocio.Producto

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        Dim _listaProveedor As List(Of Entity.Proveedor) = _dal_proveedor.Get_Proveedores
        Dim _listaCategoria As List(Of Entity.Categoria) = _dal_categoria.Get_Categorias
        Dim _listaProducto As List(Of Entity.Producto) = _dal_producto.Obtener_Productos
        Dim _listaError As New List(Of Entity.ErrorBD)
        Dim _id As Integer = 1
        For Each _producto As Entity.Producto In _listaProducto
            If Not _dal_producto.Check_Producto(_producto) Then
                _listaError.Add(New Entity.ErrorBD(_id, "Producto", _listaProducto.IndexOf(_producto) + 1))
                _id += 1
            End If
        Next
        For Each _proveedor As Entity.Proveedor In _listaProveedor
            If Not _dal_proveedor.Check_Proveedor(_proveedor) Then
                _listaError.Add(New Entity.ErrorBD(_id, "Proveedor", _listaProveedor.IndexOf(_proveedor) + 1))
                _id += 1
            End If
        Next
        For Each _categoria As Entity.Categoria In _listaCategoria
            If Not _dal_categoria.Check_Categoria(_categoria) Then
                _listaError.Add(New Entity.ErrorBD(_id, "Categoria", _listaCategoria.IndexOf(_categoria) + 1))
                _id += 1
            End If
        Next
        If _listaError.Count > 0 And Context.User.IsInRole("1") Then
            Session("ListaError") = _listaError
            Session("CheckError") = 1
            Response.Redirect("ErrorPage", True)
        End If
    End Sub
End Class