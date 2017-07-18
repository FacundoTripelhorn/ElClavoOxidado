Public Class DAL_BackupRestore

    Public Sub Crear_Backup(_path As String, _nombre As String)
        Dim _dal As New DAL.SQL_Desconectado
        Dim _storeProcedure As String
        Dim _parametros As New Dictionary(Of String, Object)

        _storeProcedure = "CrearBackup"

        _parametros.Clear()
        _parametros.Add("@Path", _path)
        _parametros.Add("@Nombre", _nombre)

        _dal.EjecutarNonQuery_StoreProcedure(_storeProcedure, _parametros)
    End Sub

    Public Sub Restore_BD(_path As String, _nombre As String)
        Dim _dal As New DAL.SQL_Desconectado
        Dim _storeProcedure As String
        Dim _parametros As New Dictionary(Of String, Object)
        Dim _archivo As String = _path + _nombre + ".bak"

        _storeProcedure = "RestoreBase"

        _parametros.Clear()
        _parametros.Add("@Archivo", _archivo)

        _dal.CambiarBase("master")
        _dal.EjecutarNonQuery_StoreProcedure(_storeProcedure, _parametros)
    End Sub

End Class
