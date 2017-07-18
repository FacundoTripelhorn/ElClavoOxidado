Imports Entity
Public Class DAL_Producto

    Public Function Check_Producto(_producto As Producto) As Boolean
        Dim _listaProducto As New List(Of Producto)
        Try
            Dim _dal As New DAL.SQL_Desconectado
            Dim _ds As DataSet
            Dim _storeProcedure As String
            Dim _parametros As New Dictionary(Of String, Object)

            _storeProcedure = "GetProducto"

            _parametros.Clear()
            _parametros.Add("@Codigo", _producto.Codigo)
            _parametros.Add("@Categoria", _producto.Categoria.Id)
            _parametros.Add("@Proveedor", _producto.Proveedor.Id)
            _parametros.Add("@Descripcion", _producto.Descripcion)
            _parametros.Add("@Precio", _producto.Precio)

            _ds = _dal.Obtener_DatasetStoreProcedure(_storeProcedure)
            If _ds.Tables(0).Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Sub Alta_Bitacora(_producto As Producto)
        Dim _dal As New DAL.SQL_Desconectado
        Dim _storeProcedure As String
        Dim _parametros As New Dictionary(Of String, Object)

        _storeProcedure = "AltaProducto"

        _parametros.Clear()
        _parametros.Add("@Codigo", _producto.Codigo)
        _parametros.Add("@Categoria", _producto.Categoria.Id)
        _parametros.Add("@Proveedor", _producto.Proveedor.Id)
        _parametros.Add("@Descripcion", _producto.Descripcion)
        _parametros.Add("@Precio", _producto.Precio)

        _dal.EjecutarNonQuery_StoreProcedure(_storeProcedure, _parametros)
    End Sub
End Class
