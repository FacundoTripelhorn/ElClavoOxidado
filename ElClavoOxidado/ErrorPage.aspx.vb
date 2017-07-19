Public Class ErrorPage
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        GrillaError.DataSource = Session("ListaError")
        GrillaError.DataBind()
    End Sub

End Class