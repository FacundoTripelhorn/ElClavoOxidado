Imports Entity
Public Class DAL_Proveedor
    Public Function Check_Proveedor(_proveedor As Proveedor) As Boolean
        Try
            Dim _dal As New DAL.SQL_Desconectado
            Dim _ds As DataSet
            Dim _storeProcedure As String
            Dim _parametros As New Dictionary(Of String, Object)

            _storeProcedure = "CheckProveedor"

            _parametros.Clear()
            _parametros.Add("@Id", _proveedor.Id)
            _parametros.Add("@Nombre", _proveedor.Nombre)

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

    Public Function Get_Proveedor(_id As Integer) As Proveedor
        Try
            Dim _proveedor As New Proveedor
            Dim _dal As New SQL_Desconectado
            Dim _ds As New DataSet
            Dim _storeProcedure As String
            Dim _parametros As New Dictionary(Of String, Object)

            _storeProcedure = "GetProveedor"

            _parametros.Clear()
            _parametros.Add("@Id", _id)

            _ds = _dal.Obtener_DatasetStoreProcedure(_storeProcedure, _parametros)

            If _ds.Tables(0).Rows.Count > 0 Then
                Dim _drow As DataRow = _ds.Tables(0).Rows(0)
                _proveedor.Id = _drow(0)
                _proveedor.Nombre = _drow(1)
            End If
            Return _proveedor
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function Get_Proveedores() As List(Of Proveedor)
        Dim _listaProveedores As New List(Of Proveedor)
        Try
            Dim _dal As New DAL.SQL_Desconectado

            Dim _ds As DataSet
            Dim _storeProcedure As String
            _storeProcedure = "GetProveedores"
            _ds = _dal.Obtener_DatasetStoreProcedure(_storeProcedure)

            For Each Item As DataRow In _ds.Tables(0).Rows
                _listaProveedores.Add(New Proveedor(Item(0), Item(1)))
            Next

        Catch ex As Exception
        End Try
        Return _listaProveedores
    End Function
End Class
