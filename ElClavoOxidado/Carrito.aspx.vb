Imports System.Xml
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
        DirectCast(Session("Carrito"), Entity.Carrito).agregarProd(New Entity.Producto With {.Codigo = 2, .Descripcion = "Producto2", .cantidad = 1, .Precio = 6.4000000000000004})
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

    Private Sub GuardarBtn_Click(sender As Object, e As EventArgs) Handles GuardarBtn.Click
        mCarrito = DirectCast(Session("Carrito"), Entity.Carrito)
        Dim vEscritor As New XmlTextWriter(Server.MapPath("Carrito de " & Context.User.Identity.Name & ".xml"), Nothing)
        vEscritor.Formatting = Formatting.Indented
        vEscritor.WriteStartDocument()
        vEscritor.WriteComment("Carrito de compras de " & Context.User.Identity.Name)
        vEscritor.WriteStartElement("Carrito")
        For Each Producto As Entity.Producto In mCarrito.getLista
            vEscritor.WriteStartElement("Producto")
            vEscritor.WriteStartElement("Codigo", "")
            vEscritor.WriteString(Producto.Codigo)
            vEscritor.WriteEndElement()
            vEscritor.WriteStartElement("Descripcion", "")
            vEscritor.WriteString(Producto.Descripcion)
            vEscritor.WriteEndElement()
            vEscritor.WriteStartElement("Precio", "")
            vEscritor.WriteString(Producto.Precio)
            vEscritor.WriteEndElement()
            vEscritor.WriteStartElement("Cantidad", "")
            vEscritor.WriteString(Producto.cantidad)
            vEscritor.WriteEndElement()
            vEscritor.WriteStartElement("Total", "")
            vEscritor.WriteString(Producto.total)
            vEscritor.WriteEndElement()
            vEscritor.WriteEndElement()
        Next
        vEscritor.WriteStartElement("Total del carrito", "")
        vEscritor.WriteString(mCarrito.Total)
        vEscritor.WriteEndDocument()
        vEscritor.Flush()
        vEscritor.Close()
        MostrarMensaje()
    End Sub

    Private Sub MostrarMensaje()
        Dim message As String = "El carrito se guardó con éxito"
        Dim sb As New System.Text.StringBuilder()
        sb.Append("<script type = 'text/javascript'>")
        sb.Append("window.onload=function(){")
        sb.Append("alert('")
        sb.Append(message)
        sb.Append("')};")
        sb.Append("</script>")
        ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb.ToString())
    End Sub
End Class
