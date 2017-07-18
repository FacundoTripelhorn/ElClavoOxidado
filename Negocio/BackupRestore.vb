Public Class BackupRestore

    Dim _dal As New DAL.DAL_BackupRestore

    Public Sub Crear_Backup(_path As String, _nombre As String)
        _dal.Crear_Backup(_path, _nombre)
    End Sub
    Public Sub Restore_BD(_path As String, _nombre As String)
        _dal.Restore_BD(_path, _nombre)
    End Sub
End Class
