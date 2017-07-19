Imports Entity
Public Class DAL_Producto

    Dim _dal As New DAL.SQL_Desconectado
    Dim _dalcategoria As New DAL_Categoria
    Dim _dalproveedor As New DAL_Proveedor

    Public Function Check_Producto(_producto As Producto) As Boolean
        Try
            Dim _ds As DataSet
            Dim _storeProcedure As String
            Dim _parametros As New Dictionary(Of String, Object)

            _storeProcedure = "CheckProducto"

            _parametros.Clear()
            _parametros.Add("@Codigo", _producto.Codigo)
            _parametros.Add("@Categoria", _producto.Categoria.Id)
            _parametros.Add("@Proveedor", _producto.Proveedor.Id)
            _parametros.Add("@Descripcion", _producto.Descripcion)
            _parametros.Add("@Precio", _producto.Precio)

            _ds = _dal.Obtener_DatasetStoreProcedure(_storeProcedure, _parametros)
            If _ds.Tables(0).Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function Obtener_Productos() As List(Of Producto)
        Dim _listaProductos As New List(Of Producto)
        Try
            Dim _ds As DataSet
            Dim _storeProcedure As String
            _storeProcedure = "GetProductos"
            _ds = _dal.Obtener_DatasetStoreProcedure(_storeProcedure)

            For Each Item As DataRow In _ds.Tables(0).Rows
                Dim _categoria As Categoria = _dalcategoria.Get_Categoria(Item(1))
                Dim _proveedor As Proveedor = _dalproveedor.Get_Proveedor(Item(2))
                _listaProductos.Add(New Producto(Item(0), _categoria, _proveedor, Item(3), Item(4)))
            Next

        Catch ex As Exception
        End Try
        Return _listaProductos
    End Function

    Public Sub Alta_Producto(_producto As Producto)
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

    Public Function Get_Producto(_codigo As Integer) As Producto
        Try
            Dim _producto As New Producto
            Dim _ds As New DataSet
            Dim _storeProcedure As String
            Dim _parametros As New Dictionary(Of String, Object)

            _storeProcedure = "GetProducto"

            _parametros.Clear()
            _parametros.Add("@Codigo", _codigo)

            _ds = _dal.Obtener_DatasetStoreProcedure(_storeProcedure, _parametros)

            If _ds.Tables(0).Rows.Count > 0 Then
                Dim _drow As DataRow = _ds.Tables(0).Rows(0)
                _producto.Codigo = _drow(0)
                _producto.Categoria = _dalcategoria.Get_Categoria(_drow(1))
                _producto.Proveedor = _dalproveedor.Get_Proveedor(_drow(2))
                _producto.Descripcion = _drow(3)
                _producto.Precio = _drow(4)
            End If
            Return _producto
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
End Class
