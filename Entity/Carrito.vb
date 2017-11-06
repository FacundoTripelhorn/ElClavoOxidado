Imports System.Xml
Public Class Carrito
    Dim mListaProd As New List(Of Producto)

    Public Sub agregarProd(pProd As Producto)
        If validarExistencia(pProd.Codigo) = False Then
            mListaProd.Add(pProd)
        End If
    End Sub

    Public Sub quitarProd(pProd As Producto)
        Try
            mListaProd.Remove(pProd)
        Catch ex As Exception

        End Try
    End Sub

    Public Function getLista() As List(Of Producto)
        Return mListaProd
    End Function
    Private Function validarExistencia(pProdId As Integer) As Boolean
        Dim answer As Boolean = False
        For Each pProd As Producto In mListaProd
            If pProd.Codigo = pProdId Then
                answer = True
                pProd.cantidad += 1
                Exit For
            End If
        Next
        Return answer
    End Function

    ReadOnly Property Total As Decimal
        Get
            Dim mTotal As Decimal = 0
            For Each mProd As Producto In mListaProd
                mTotal += mProd.total
            Next
            Return mTotal
        End Get

    End Property
End Class
