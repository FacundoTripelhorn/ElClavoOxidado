Public Class Restore
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub Restore_PreLoad(sender As Object, e As EventArgs) Handles Me.PreLoad
        If Not Context.User.IsInRole("1") Then
            Response.Redirect("Default", True)
        End If
    End Sub
End Class