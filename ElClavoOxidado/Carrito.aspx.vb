Public Class Carrito
    Inherits System.Web.UI.Page

    Dim mCarrito As Entity.Carrito
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Page.IsPostBack = False) Then
            'Dim miprod As New prod
            'miprod.ProductId = "1"
            'miprod.Description = "Product1"
            'miprod.Quantity = 1
            'miprod.UnitPrice = 5
            'miprod.TotalPrice = 5
            'Dim mlista As New List(Of prod)
            'mlista.Add(miprod)

            mCarrito = DirectCast(Session("Carrito"), Entity.Carrito)
            gvShoppingCart.DataSource = mCarrito.getLista
            gvShoppingCart.DataBind()
        End If

    End Sub



    Private Sub Carrito_PreLoad(sender As Object, e As EventArgs) Handles Me.PreLoad
        'TODO: Activar verificacion de roles
        ' If Not Context.User.IsInRole("2") Then
        'Response.Redirect("Default", True)
        'End If
        DirectCast(Session("Carrito"), Entity.Carrito).agregarProd(New Entity.Producto With {.Codigo = 1, .Descripcion = "Producto1", .cantidad = 1, .Precio = 2.5})
        DirectCast(Session("Carrito"), Entity.Carrito).agregarProd(New Entity.Producto With {.Codigo = 1, .Descripcion = "Producto1", .cantidad = 1, .Precio = 2.5})
        DirectCast(Session("Carrito"), Entity.Carrito).agregarProd(New Entity.Producto With {.Codigo = 2, .Descripcion = "Producto2", .cantidad = 1, .Precio = 6.4})
    End Sub

    Private Sub gvShoppingCart_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles gvShoppingCart.RowDataBound
        Debug.Write("Prueba")
        Try
            If e.Row.RowType = DataControlRowType.Footer Then
                e.Row.Cells(3).Text = "$" + FormatNumber(mCarrito.Total, 2).ToString
            End If
        Catch
        End Try

    End Sub

    Private Sub gvShoppingCart_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gvShoppingCart.RowCommand
        Debug.Write("Prueba2")
    End Sub

    Protected Sub CalcularEnvio_Click(sender As Object, e As EventArgs)
        Try
            Dim mWebService As New CostoEnvioWebService.ClavoService
            txtCosto.Text = "$" + FormatNumber(mWebService.CostoEnvio(DropDownList1.Text), 2).ToString
        Catch
        End Try
    End Sub
End Class
