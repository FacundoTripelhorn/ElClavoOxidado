﻿Imports System.Data.SqlClient
Imports System.Collections

Public Class SQL_Desconectado
    Private _sqlConnection As SqlConnection
    Private mDs As DataSet
    Private mDa As SqlDataAdapter

    Sub New()
        Dim server As String = "."
        Try
            ConexionIniciar()
        Catch _ex As Exception
            '
        End Try
    End Sub

    Public Sub ConexionIniciar()
        Try
            Dim connectionString As String = "Data Source=.;Initial Catalog=ElClavoOxidado;Integrated Security=True"
            _sqlConnection = New SqlConnection(connectionString)
            _sqlConnection.Open()
        Catch ex As Exception
            '
        End Try
    End Sub

    Public Sub CambiarBase(_string As String)
        _sqlConnection.ChangeDatabase(_string)
    End Sub

    Public Sub ConexionFinalizar()
        Try
            _sqlConnection.Close()
            SqlConnection.ClearAllPools()
        Catch ex As Exception
            '
        End Try
    End Sub

    Public Function Obtener_DatasetStoreProcedure(sp As String, Optional parametros As Dictionary(Of String, Object) = Nothing)
        Try

            Dim unComando As New SqlCommand()

            '1) La conexion abierta.
            unComando.Connection = _sqlConnection

            '2) Texto de la consulta.
            unComando.CommandText = sp

            If Not parametros Is Nothing Then
                For Each p In parametros
                    unComando.Parameters.AddWithValue(p.Key, p.Value)
                Next
            End If


            '3) Tipo de consulta.
            unComando.CommandType = CommandType.StoredProcedure

            'SE CREA EL OBJETO DATAADAPTER PARA LLENAR EL DATASET
            mDa = New SqlDataAdapter(unComando)

            mDs = New DataSet
            mDa.Fill(mDs)
            ConexionFinalizar()
        Catch ex As Exception
            ConexionFinalizar()
        End Try
        Return mDs
    End Function

    Public Function EjecutarEscalar_StoreProcedure(consulta As String, parametros As Dictionary(Of String, Object)) As Object
        Try
            Dim unComando As New SqlCommand()

            '1) La conexion abierta.
            unComando.Connection = _sqlConnection
            'unComando.Transaction = _unaTransaccion

            '2) Texto de la consulta.
            unComando.CommandText = consulta

            For Each p In parametros
                unComando.Parameters.AddWithValue(p.Key, p.Value)
            Next

            '3) Tipo de consulta.
            unComando.CommandType = CommandType.StoredProcedure

            '4) Ejecutar y esperar el resultado.
            Return unComando.ExecuteScalar()
            ConexionFinalizar()
        Catch ex As Exception
            ConexionFinalizar()
            Return -1
        End Try
    End Function

    Public Sub EjecutarNonQuery_StoreProcedure(sp As String, Optional parametros As Dictionary(Of String, Object) = Nothing)
        Try
            Dim unComando As New SqlCommand()

            '1) La conexion abierta.
            unComando.Connection = _sqlConnection

            '2) Texto de la consulta.
            unComando.CommandText = sp

            unComando.Parameters.Clear()

            If Not parametros Is Nothing Then
                For Each p In parametros
                    unComando.Parameters.AddWithValue(p.Key, p.Value)
                Next
            End If
            '3) Tipo de consulta.
            unComando.CommandType = CommandType.StoredProcedure

            '4) Ejecutar y esperar el resultado.
            unComando.ExecuteNonQuery()
            ConexionFinalizar()
        Catch ex As Exception
            ConexionFinalizar()
        End Try
    End Sub

    Public Sub EjecutarConsulta(_consulta As String)
        Dim _comando As New SqlCommand
        Try
            _comando.Connection = _sqlConnection
            _comando.CommandText = _consulta


            _comando.ExecuteNonQuery()
            _comando.Connection.Close()
        Catch ex As Exception
            _comando.connection.close
        End Try
    End Sub
End Class
