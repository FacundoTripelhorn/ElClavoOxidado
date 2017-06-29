Public Class About
    Inherits Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

    End Sub


    Private Sub About_PreLoad(sender As Object, e As EventArgs) Handles Me.PreLoad
        If Context.User.IsInRole("1") Or Context.User.IsInRole("3") Then
            Response.Redirect("Default", True)
        End If
    End Sub
End Class