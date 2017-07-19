Imports Entity
Public Class DAL_Categoria

    Public Function Check_Categoria(_categoria As Categoria) As Boolean
        Try
            Dim _dal As New DAL.SQL_Desconectado
            Dim _ds As DataSet
            Dim _storeProcedure As String
            Dim _parametros As New Dictionary(Of String, Object)

            _storeProcedure = "CheckCategoria"

            _parametros.Clear()
            _parametros.Add("@Id", _categoria.Id)
            _parametros.Add("@Nombre", _categoria.Nombre)

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

    Public Function Get_Categoria(_id As Integer) As Categoria
        Try
            Dim _categoria As New Categoria
            Dim _dal As New SQL_Desconectado
            Dim _ds As New DataSet
            Dim _storeProcedure As String
            Dim _parametros As New Dictionary(Of String, Object)

            _storeProcedure = "GetCategoria"

            _parametros.Clear()
            _parametros.Add("@Id", _id)

            _ds = _dal.Obtener_DatasetStoreProcedure(_storeProcedure, _parametros)

            If _ds.Tables(0).Rows.Count > 0 Then
                Dim _drow As DataRow = _ds.Tables(0).Rows(0)
                _categoria.Id = _drow(0)
                _categoria.Nombre = _drow(1)
            End If
            Return _categoria
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function Get_Categorias() As List(Of Categoria)
        Dim _listaCategoria As New List(Of Categoria)
        Try
            Dim _dal As New DAL.SQL_Desconectado

            Dim _ds As DataSet
            Dim _storeProcedure As String
            _storeProcedure = "GetCategorias"
            _ds = _dal.Obtener_DatasetStoreProcedure(_storeProcedure)

            For Each Item As DataRow In _ds.Tables(0).Rows
                _listaCategoria.Add(New Categoria(Item(0), Item(1)))
            Next

        Catch ex As Exception
        End Try
        Return _listaCategoria
    End Function

End Class
