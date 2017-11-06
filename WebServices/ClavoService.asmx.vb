Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel

' Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente.
' <System.Web.Script.Services.ScriptService()> _
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
Public Class ClavoService
    Inherits System.Web.Services.WebService

    <WebMethod()>
    Public Function CostoEnvio(pProvincia As String) As Decimal
        Return buscarCosto(pProvincia)
    End Function

    Private Function buscarCosto(pProvincia As String) As Decimal
        Dim answer As Decimal = 0
        Select Case pProvincia
            Case "CABA"
                answer = 100
            Case "Buenos Aires"
                answer = 150
            Case Else
                answer = 250
        End Select
        Return answer
    End Function

End Class