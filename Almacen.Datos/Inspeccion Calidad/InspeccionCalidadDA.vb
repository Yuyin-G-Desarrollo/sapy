Imports System.Data.SqlClient
Imports System.Collections.Generic
Imports Entidades

Public Class InspeccionCalidadDA

    Public Function ValidaFolio(ByVal Folio As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@Folio"
            parametro.Value = Folio
            listaParametros.Add(parametro)
            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_InspeccionCalidad_ValidaFolio]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function ValidarExisteIncidenciaPar(ByVal InspeccionParID As Integer, ByVal IncidenciaID As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@InspeccionParID"
            parametro.Value = InspeccionParID
            listaParametros.Add(parametro)
            parametro = New SqlParameter

            parametro.ParameterName = "@IdIncidencia"
            parametro.Value = IncidenciaID
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_InspeccionCalidad_ValidarExisteIncidenciaPar]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function RegistrarIncidenciaPar(ByVal InspeccionParID As Integer, ByVal InspeccionId As Integer, ByVal IdIncidencia As Integer, ByVal UsuarioID As Integer, ByVal Observaciones As String, ByVal TipoIncidencia As String, ByVal RutaFotoUno As String, ByVal RutaFotoDos As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@InspeccionParID"
            parametro.Value = InspeccionParID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@InspeccionId"
            parametro.Value = InspeccionId
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@IdIncidencia"
            parametro.Value = IdIncidencia
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@UsuarioID"
            parametro.Value = UsuarioID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@Observaciones"
            parametro.Value = Observaciones
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@TipoIncidencia"
            parametro.Value = TipoIncidencia
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@RutaFotoUno"
            parametro.Value = RutaFotoUno
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@RutaFotoDos"
            parametro.Value = RutaFotoDos
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_InspeccionCalidad_RegistroIncidenciaPar]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function ObtenerInformacionCodigoClienteEscaneado(ByVal CodigoCliente As String, ByVal CodigoAtado As String, ByVal FolioInspeccion As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@CodigoCliente"
            parametro.Value = CodigoCliente
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@CodigoAtado"
            parametro.Value = CodigoAtado
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@FolioInspeccion"
            parametro.Value = FolioInspeccion
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_InspeccionCalidad_ObtenerInformacionCodigoClienteEscaneado]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function ObtenerInformacionParEscaneado(ByVal CodigoPar As String, ByVal FolioInspeccion As String, ByVal FolioSalidaID As String, ByVal UsuarioID As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@CodigoPar"
            parametro.Value = CodigoPar
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@FolioInspeccion"
            parametro.Value = FolioInspeccion
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@FolioSalidaID"
            parametro.Value = FolioSalidaID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@UsuarioID"
            parametro.Value = UsuarioID
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_InspeccionCalidad_ObtenerInformacionParEscaneado]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function ObtenerInformacionParEscaneado(ByVal Folio As Integer, ByVal UsuarioId As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@Folio"
            parametro.Value = Folio
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@UsuarioId"
            parametro.Value = UsuarioId
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_InspeccionCalidad_ObtenerInformacionFolio]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try

    End Function



    Public Function CheckLogin(ByVal Usuario As String, ByVal Md5 As String) As Usuarios
        Try
            Dim operaciones As New Persistencia.OperacionesProcedimientos
            Dim ParametrosList As New List(Of SqlParameter)

            Dim Param As New SqlParameter
            Param.ParameterName = "username"
            Param.Value = Usuario
            ParametrosList.Add(Param)
            ''
            Dim Param2 As New SqlParameter
            Param2.ParameterName = "password"
            Param2.Value = Md5
            ParametrosList.Add(Param2)

            Dim DT As New DataTable
            DT = operaciones.EjecutarConsultaSP("Framework.SP_login", ParametrosList)
            CheckLogin = New Usuarios
            If DT.Rows.Count > 0 Then
                For Each row As DataRow In DT.Rows
                    CheckLogin.PUserUsuarioid = CInt(row(0))
                    CheckLogin.PUserUsername = CStr(row(1))
                    CheckLogin.PUserEmail = CStr(row(2))
                    CheckLogin.PUserNombreReal = CStr(row(3))
                    If Not IsDBNull(row("user_sicy")) Then
                        CheckLogin.PUsuariosSicy = CStr(row("user_sicy"))
                    End If
                    If Not IsDBNull(row("user_colaboradorid")) Then
                        CheckLogin.PIDColaboradorUser = CInt(row("user_colaboradorid"))
                    End If
                Next
                Return CheckLogin
            Else
                Return New Usuarios
            End If
        Catch ex As SqlClient.SqlException
            Throw ex
        End Try
    End Function

    Public Function CheckLogin(ByVal Usuario As String) As Usuarios
        Try
            Dim operaciones As New Persistencia.OperacionesProcedimientos
            Dim ParametrosList As New List(Of SqlParameter)

            Dim Param As New SqlParameter
            Param.ParameterName = "username"
            Param.Value = Usuario
            ParametrosList.Add(Param)

            Dim DT As New DataTable
            DT = operaciones.EjecutarConsultaSP("Framework.SP_login_APPMovil", ParametrosList)

            CheckLogin = New Usuarios
            If DT.Rows.Count > 0 Then
                For Each row As DataRow In DT.Rows
                    CheckLogin.PUserUsuarioid = CInt(row(0))
                    CheckLogin.PUserUsername = CStr(row(1))
                    CheckLogin.PUserEmail = CStr(row(2))
                    CheckLogin.PUserNombreReal = CStr(row(3))
                    If Not IsDBNull(row("user_sicy")) Then
                        CheckLogin.PUsuariosSicy = CStr(row("user_sicy"))
                    End If
                    If Not IsDBNull(row("user_colaboradorid")) Then
                        CheckLogin.PIDColaboradorUser = CInt(row("user_colaboradorid"))
                    End If
                Next
                Return CheckLogin
            Else
                Return New Usuarios
            End If
        Catch ex As SqlClient.SqlException
            Throw ex
        End Try
    End Function

    Public Function ObtenerLotesPiloto(ByVal FolioInspeccionID As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@FolioInspeccionID"
            parametro.Value = FolioInspeccionID
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_InspeccionCalidad_ObtenerLotesPilotoFolio]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try

    End Function


    Public Function ValidaCodigoLeido(ByVal CodigoLeido As String, ByVal EsCodigoPar As Boolean, ByVal FolioSalidaID As Integer, ByVal NaveID As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@CodigoLeido"
            parametro.Value = CodigoLeido
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@EsCodigoPar"
            parametro.Value = EsCodigoPar
            listaParametros.Add(parametro)


            parametro = New SqlParameter
            parametro.ParameterName = "@FolioSalidaID"
            parametro.Value = FolioSalidaID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@NaveID"
            parametro.Value = NaveID
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_InspeccionCalidad_ValidarCodigoLeido]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function ObtenerInformacionCapturaIncidencia(ByVal InspeccionParID As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try

            parametro.ParameterName = "@InspeccionParID"
            parametro.Value = InspeccionParID
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_InspeccionCalidad_ObtenerInformacionParInspeccionado]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try

    End Function


    Public Function ObtenerIncidenciasDepartamento(ByVal DepartamentoID As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try

            parametro.ParameterName = "@DepartamentoID"
            parametro.Value = DepartamentoID
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_InspeccionCalidad_ObtenerIncidenciasDepartamento]", listaParametros)

        Catch ex As Exception
            Throw ex
        End Try

    End Function


    Public Function CapturaInciedenciaPar(ByVal InspeccionParID As Integer, ByVal IncidenciaID As Integer, ByVal UsuarioID As Integer, ByVal Observaciones As String, ByVal TipoIncidencia As String, ByVal Foto1 As String, ByVal Foto2 As String, ByVal TipoDevolucion As Integer, ByVal Accion As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try

            parametro.ParameterName = "@InspeccionParID"
            parametro.Value = InspeccionParID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@IncidenciaID"
            parametro.Value = IncidenciaID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@UsuarioID"
            parametro.Value = UsuarioID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@Observaciones"
            parametro.Value = Observaciones
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@TipoIncidencia"
            parametro.Value = TipoIncidencia
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@Foto1"
            parametro.Value = Foto1
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@Foto2"
            parametro.Value = Foto2
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@TipoDevolucion"
            parametro.Value = TipoDevolucion
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@Accion"
            parametro.Value = Accion
            listaParametros.Add(parametro)


            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_InspeccionCalidad_InsertarIncidenciaPar]", listaParametros)

        Catch ex As Exception
            Throw ex
        End Try


    End Function


    Public Function ResumenInspeccion(ByVal FolioInspeccion As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@FolioInspeccion"
            parametro.Value = FolioInspeccion
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_InspeccionCalidad_ResumenInspeccion]", listaParametros)

        Catch ex As Exception
            Throw ex
        End Try


    End Function

    Public Function ObtenerInformacionParMaquila(ByVal CodigoPar As String, ByVal FolioInspeccion As String, ByVal NaveId As Integer, ByVal UsuarioId As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try

            parametro.ParameterName = "@CodigoPar"
            parametro.Value = CodigoPar
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@FolioInspeccion"
            parametro.Value = FolioInspeccion
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@NaveID"
            parametro.Value = NaveId
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@UsuarioID"
            parametro.Value = UsuarioId
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_InspeccionCalidad_ObtenerInformacionParEscaneadoMaquila]", listaParametros)

        Catch ex As Exception
            Throw ex
        End Try


    End Function


    Public Function ObtenerInformacionParCodigoCliente(ByVal CodigoAtado As String, ByVal CodigoCliente As String, ByVal FolioInspeccion As String, ByVal FolioSalidaID As Integer, ByVal UsuarioId As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try

            parametro.ParameterName = "@Atado"
            parametro.Value = CodigoAtado
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@CodigoCliente"
            parametro.Value = CodigoCliente
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@FolioInspeccion"
            parametro.Value = FolioInspeccion
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@FolioSalidaID"
            parametro.Value = FolioSalidaID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@UsuarioID"
            parametro.Value = UsuarioId
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_InspeccionCalidad_ObtenerInformacionParEscaneadoCodigoCliente]", listaParametros)

        Catch ex As Exception
            Throw ex
        End Try


    End Function

    Public Function ObtenerInformacionParCodigoCliente_Maquila(ByVal CodigoAtado As String, ByVal CodigoCliente As String, ByVal FolioInspeccion As String, ByVal NaveId As Integer, ByVal UsuarioId As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try

            parametro.ParameterName = "@Atado"
            parametro.Value = CodigoAtado
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@CodigoCliente"
            parametro.Value = CodigoCliente
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@FolioInspeccion"
            parametro.Value = FolioInspeccion
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@NaveID"
            parametro.Value = NaveId
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@UsuarioID"
            parametro.Value = UsuarioId
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_InspeccionCalidad_ObtenerInformacionParEscaneadoMaquila_CodigoCliente]", listaParametros)

        Catch ex As Exception
            Throw ex
        End Try


    End Function

    Public Function ReporteDeInspeccion(ByVal NaveId As String, ByVal FiltrarPorFecha As Boolean, ByVal FechaInicio As Date, ByVal FechaFin As Date, ByVal ResultadoInspeccion As String, ByVal FolioInspeccion As String, ByVal FolioSalida As String, ByVal Almacen2 As Boolean, ByVal Cedis As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try

            parametro.ParameterName = "@NaveId"
            parametro.Value = NaveId
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@FiltrarPorFecha"
            parametro.Value = FiltrarPorFecha
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@FechaInicio"
            parametro.Value = FechaInicio
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@FechaFin"
            parametro.Value = FechaFin
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@ResultadoInspeccion"
            parametro.Value = ResultadoInspeccion
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@FolioInspeccion"
            parametro.Value = FolioInspeccion
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@FolioSalida"
            parametro.Value = FolioSalida
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@EsAlmacen2"
            parametro.Value = Almacen2
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@Cedis"
            parametro.Value = Cedis
            listaParametros.Add(parametro)

            'Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_InspeccionCalidad_Reporte_ObtenerReporteFolios]", listaParametros)
            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_InspeccionCalidad_Reporte_ObtenerReporteFolios_Cedis]", listaParametros)

        Catch ex As Exception
            Throw ex
        End Try


    End Function


    Public Function ReporteDetallesFolioInspeccion(ByVal FolioInspeccion As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try

            parametro.ParameterName = "@FolioInspeccion"
            parametro.Value = FolioInspeccion
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_InspeccionCalidad_Reporte_DetalleFolioInspeccion]", listaParametros)

        Catch ex As Exception
            Throw ex
        End Try

    End Function


    Public Function ListadoParametroProyeccionEntregas(tipo_busqueda As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "TipoConsulta"
            parametro.Value = tipo_busqueda
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("Ventas.SP_Proyeccion_ConsultasFiltros", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function ConsultaListadoClientesPorcentajeInspeccion() As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Try
            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_InspeccionCalidad_ConsultaPorcentajeInspeccionClientes]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function FinalizarInspeccion(ByVal FolioInspeccionID As Integer, ByVal ColaboradorID As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@FolioInspeccionID"
            parametro.Value = FolioInspeccionID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@ColaboradorID"
            parametro.Value = ColaboradorID
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_InspeccionCalidad_FinalizarInspeccion]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function ConsultarDevolucionesNave(ByVal FolioDevolucionId As String, ByVal FolioSalidaId As String, ByVal FolioInspeccionId As String, ByVal NaveId As String, ByVal StatusId As String, ByVal FiltrarPorFecha As Boolean, ByVal FechaInicio As String, ByVal FechaFin As String, ByVal CEDISID As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try

            parametro.ParameterName = "@FolioDevolucionID"
            parametro.Value = FolioDevolucionId
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@FolioSalida"
            parametro.Value = FolioSalidaId
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@FolioInspeccion"
            parametro.Value = FolioInspeccionId
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@NaveId"
            parametro.Value = NaveId
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@StatusID"
            parametro.Value = StatusId
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@FiltrarPorFecha"
            parametro.Value = FiltrarPorFecha
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@FechaInicio"
            parametro.Value = FechaInicio
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@FechaFin"
            parametro.Value = FechaFin
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@Cedis"
            parametro.Value = CEDISID
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_DevolucionNave_ConsultaDevolucion_cedis]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try

    End Function


    Public Function ConsultarDetallesDevolucion(ByVal FolioDevolucionID As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@DevolucionID"
            parametro.Value = FolioDevolucionID
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_DevolucionNave_ConsultaDetallesDevolucion]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function ConsultaParesPendientesIngresar(ByVal FolioDevolucionID As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@DevolucionID"
            parametro.Value = FolioDevolucionID
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_DevolucionNave_ConsultaParesPendientesIngreso]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function ConsultaParesIngresados(ByVal FolioDevolucionID As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@DevolucionID"
            parametro.Value = FolioDevolucionID
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_DevolucionNave_ConsultaParesIngresados]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try

    End Function


    Public Function ObtenerInformacionFolioDevolucion(ByVal FolioDevolucionID As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@FolioDevolucionID"
            parametro.Value = FolioDevolucionID
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_DevolucionNave_ObtenerInformacionFolioDevolucion]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function ConsultaOperadoresNave(ByVal NaveSICYID As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@Nave"
            parametro.Value = NaveSICYID
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_DevolucionNave_ConsultaOperadoresNaves]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try

    End Function


    Public Function ConsultaEncabezadoDevolucionReporte(ByVal FolioDevolucion As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@FolioDevolucionID"
            parametro.Value = FolioDevolucion
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_Devolucion_Reporte_ConsultaEncabezado]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try

    End Function


    Public Function ConsultaDetallesDevolucionReporte(ByVal FolioDevolucion As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@FolioDevolucionID"
            parametro.Value = FolioDevolucion
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_Devolucion_Reporte_ConsultaDetallesFolio]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function ConsultaParesDevolucion(ByVal FolioDevolucionID As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@DevolucionID"
            parametro.Value = FolioDevolucionID
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_DevolucionNave_ConsultaPares]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function IngresarParesDevolucion(ByVal FolioDevolucionID As Integer, ByVal EsCodigoPar As Boolean, ByVal CodigoLeido As String, ByVal ColaboradorId As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@DevolucionID"
            parametro.Value = FolioDevolucionID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@EsPar"
            parametro.Value = EsCodigoPar
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@Codigo"
            parametro.Value = CodigoLeido
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@ColaboradorId"
            parametro.Value = ColaboradorId
            listaParametros.Add(parametro)


            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_DevolucionNave_IngresarPares]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function FinalizarIngreso(ByVal FolioDevolucionID As Integer, ByVal ColaboradorId As Integer, ByVal Entrego As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@DevolucionID"
            parametro.Value = FolioDevolucionID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@ColaboradorId"
            parametro.Value = ColaboradorId
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@Entrego"
            parametro.Value = Entrego
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_DevolucionNave_FinalizarIngreso]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function DevlucionValidaAtado_Alta(ByVal Atado As String, ByVal NaveId As Integer, ByVal EsCodigoPar As Boolean) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@Atado"
            parametro.Value = Atado
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@NaveId"
            parametro.Value = NaveId
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@EsCodigoPar"
            parametro.Value = EsCodigoPar
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_Devolucion_Alta_ValidarAtado]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try

    End Function



    Public Function DevlucionObtenerInformacionAtado_Alta(ByVal Atado As String, ByVal EsCodigoPar As Boolean) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@Atado"
            parametro.Value = Atado
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@EsCodigoPar"
            parametro.Value = EsCodigoPar
            listaParametros.Add(parametro)


            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_Devolucion_Alta_ObtenerInformacionAtado]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try

    End Function


    Public Function GuardarEncabezadoFolioAlta(ByVal NaveID As Integer, ByVal UsuarioId As Integer, ByVal FechaEstimadaRegreso As Date, ByVal CantidadPares As Integer, ByVal Tratamiento As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@NaveId"
            parametro.Value = NaveID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@usuarioid"
            parametro.Value = UsuarioId
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@FechaEstimadaRegreso"
            parametro.Value = FechaEstimadaRegreso
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@CantidadPares"
            parametro.Value = CantidadPares
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@Tratamiento"
            parametro.Value = Tratamiento
            listaParametros.Add(parametro)



            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_Devolucion_Alta_GuardarEncabezadoFolio]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function ConsultaNavesDevolucion_Alta() As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try

            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_Devolucion_Alta_ConsultaNaves]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try

    End Function


    Public Function GuardarParesFolioAlta(ByVal FolioDevolucion As Integer, ByVal CodigoAtado As String, ByVal ColaboradorId As Integer, ByVal EsAtado As Boolean) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@FolioDevolucionID"
            parametro.Value = FolioDevolucion
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@CodigoAtado"
            parametro.Value = CodigoAtado
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@ColaboradorID"
            parametro.Value = ColaboradorId
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@EsAtado"
            parametro.Value = EsAtado
            listaParametros.Add(parametro)


            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_Devolucion_Alta_GuardarParesReproceso]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function ValidaFolioDevolucion(ByVal FolioDevolucion As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@Folio"
            parametro.Value = FolioDevolucion
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_Devolucion_ValidaFolio]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function EditarFolioDevolucion(ByVal FolioDevolucion As Integer, ByVal FechaEstimadaRegreso As Date, ByVal Tratamiento As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@FolioDevolucion"
            parametro.Value = FolioDevolucion
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@FechaEstimadaRegreso"
            parametro.Value = FechaEstimadaRegreso
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@Tratamiento"
            parametro.Value = Tratamiento
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_Devolucion_Editar_Folio]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try

    End Function


End Class
