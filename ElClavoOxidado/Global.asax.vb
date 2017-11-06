Imports System.Web.Optimization

Public Class Global_asax
    Inherits HttpApplication

    Sub Application_Start(sender As Object, e As EventArgs)
        ' Se desencadena al iniciar la aplicación
        RouteConfig.RegisterRoutes(RouteTable.Routes)
        BundleConfig.RegisterBundles(BundleTable.Bundles)
        Try
            Roles.CreateRole("1")
            Roles.CreateRole("2")
            Roles.CreateRole("3")
        Catch
        End Try
    End Sub

    Sub Session_Start(sender As Object, e As EventArgs)
        Session("CheckError") = 0
        Session("CheckErrorValidate") = 0 ''Use this to optimize default.aspx'
        Session("Carrito") = New Entity.Carrito
    End Sub
End Class