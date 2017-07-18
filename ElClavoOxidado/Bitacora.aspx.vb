Imports Negocio
Public Class Bitacora
    Inherits System.Web.UI.Page
    Dim _Bitacora_Negocio As New Negocio.Bitacora
    Dim mListaOriginal As New List(Of Entity.Bitacora)
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        mListaOriginal = _Bitacora_Negocio.Obtener_Bitacora
        GrillaBitacora.DataSource = Nothing
        GrillaBitacora.DataSource = mListaOriginal
        GrillaBitacora.DataBind()
    End Sub


    Private Sub Bitacora_PreLoad(sender As Object, e As EventArgs) Handles Me.PreLoad
        If Not Context.User.IsInRole("1") Then
            Response.Redirect("Default", True)
        End If

    End Sub
    Private Sub FiltrarBitacoraPorFecha(fecha As Date)
        Try
            Dim mLista As New List(Of Entity.Bitacora)
            For Each elemento As Entity.Bitacora In mListaOriginal
                If elemento.Fecha.Date = fecha Then
                    mLista.Add(elemento)
                End If
            Next
            GrillaBitacora.DataSource = mLista
            GrillaBitacora.DataBind()
            '  GrillaBitacora.
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try

        Catch ex As Exception

        End Try

    End Sub


End Class