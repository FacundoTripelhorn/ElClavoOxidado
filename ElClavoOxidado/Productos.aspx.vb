Public Class Productos
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub



    Private Sub Productos_PreLoad(sender As Object, e As EventArgs) Handles Me.PreLoad
        '' If Not (Context.User.IsInRole("2") Or Context.User.IsInRole("3")) Then
        ''Response.Redirect("Default", True)
        ''End If
    End Sub

End Class