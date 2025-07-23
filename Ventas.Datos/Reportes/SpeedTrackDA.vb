Imports System.Data.SqlClient

Public Class SpeedTrackDA



    Public Function ConsultarModelosSpeedTrack() As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Return objPersistencia.EjecutaConsulta("EXEC Ventas.SP_SpeedTrack_ConsultarModelos")
    End Function
    Public Function ConsultarReporteSpeedTrack(ByVal fechaInicio As Date, ByVal fechafin As Date) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY

        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "@fechaInicia"
        parametro.Value = fechaInicio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@fechaFin"
        parametro.Value = fechafin
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("Ventas.SP_SpeedTrack_ReporteSpeedTrack", listaParametros)
    End Function
    Public Function ConsultarListasDePrecios() As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Return objPersistencia.EjecutaConsulta("EXEC Ventas.SP_ListasPrecio_MostrarListaBase")
    End Function

    Public Function ConsultarModelosADDSpeedTrack(ByVal listaPrecio As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos

        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "@listaPrecio"
        parametro.Value = listaPrecio
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("Ventas.SP_SpeedTrack_ConsultarProductoEstilo_De_La_ListadePrecio", listaParametros)

    End Function

    Public Function AgregarModelosSpeedTrack(ByVal productoEstilo As String, ByVal usuario As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos

        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "@productosEstilos"
        parametro.Value = productoEstilo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@usuarioid"
        parametro.Value = usuario
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("Ventas.SP_SpeedTrack_AgregarModelos", listaParametros)

    End Function

    Public Function EliminarTodosLosModelosSpeedTrack() As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Return objPersistencia.EjecutaConsulta("EXEC Ventas.SP_SpeedTrack_EliminarTodosLosModelos")
    End Function

    Public Function EliminarSoloUnModelo(ByVal modelo As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos

        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "@modelo"
        parametro.Value = modelo
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("Ventas.SP_SpeedTrack_EliminarUnModelos", listaParametros)

    End Function

    Public Function ConsultarModelosActializarParesAutorizados() As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Return objPersistencia.EjecutaConsulta("EXEC Ventas.SP_SpeedTrack_ConsultarModelosActualizarPares")
    End Function

    Public Function ActualizarParesAutorizados(ByVal cadena As String, ByVal usuario As String, ByVal Id As String, ByVal exporto As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos

        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "@usuarioid"
        parametro.Value = usuario
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@cadena"
        parametro.Value = cadena
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@ID"
        parametro.Value = Id
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@exporto"
        parametro.Value = exporto
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("Ventas.SP_SpeedTrack_ActualizarParesAutorizados", listaParametros)

    End Function

End Class
