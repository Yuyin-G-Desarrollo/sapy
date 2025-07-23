Imports System.Collections.Generic
Imports System.Data.SqlClient

Public Class DevolucionCliente_IntegracionInventarioDA
    Dim operaciones As New Persistencia.OperacionesProcedimientos

    Public Function ConsultaDetallesDevolucion(ByVal FolioDev As Integer, ByVal FoliosDev As String) As DataTable
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@FolioDev"
        parametro.Value = FolioDev
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FoliosDev"
        parametro.Value = FoliosDev
        listaparametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Almacen].[SP_DevolucionCliente_IngresoGranel_ConsultaDetallesFolio]", listaparametros)

    End Function


    Public Function ConsultaDocenaNormal(ByVal TallaID As Integer) As DataTable
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@TallaId"
        parametro.Value = TallaID
        listaparametros.Add(parametro)


        Return operaciones.EjecutarConsultaSP("[Almacen].[SP_DevolucionCliente_IngresoGranel_ConsultaDocenaNormal]", listaparametros)

    End Function

    Public Function ConsultaTallasFolio(ByVal FolioDevolucionID As Integer) As DataTable
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@FolioDev"
        parametro.Value = FolioDevolucionID
        listaparametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Almacen].[SP_DevolucionCliente_IngresoGranel_ConsultaTallasFolio]", listaparametros)

    End Function

    Public Function ConsultaParesTallasFolio(ByVal FolioDevolucionID As Integer) As DataTable
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@FolioDev"
        parametro.Value = FolioDevolucionID
        listaparametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Almacen].[SP_DevolucionCliente_IngresoGranel_ConsultaTallasPorArticulo]", listaparametros)

    End Function

    Public Function ConsultaInformacionDetalle(ByVal FolioDetalleID As Integer) As DataTable
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@FolioDevolucionDetalleId"
        parametro.Value = FolioDetalleID
        listaparametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("Almacen.SP_DevolucionCliente_IngresoGranel_ConsultaInfoDetallesFolio", listaparametros)

    End Function

    Public Function ConsultaTallasCorridas(ByVal TallaId As Integer) As DataTable
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@TallaId"
        parametro.Value = TallaId
        listaparametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("Almacen.SP_DevolucionCliente_IngresoGranel_ConsultaITallasCorrida", listaparametros)

    End Function


    Public Function BuscarLoteDocena(ByVal idCodigoSicy As String, ByVal tallaSicy As String)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Try
            parametro.ParameterName = "@IdCodigo"
            parametro.Value = idCodigoSicy
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@idTallaSicy"
            parametro.Value = tallaSicy
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_DevolucionCliente_IngresoGranel_BuscarLoteDocena]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function InsertarLoteGranel(ByVal Lote As Integer, ByVal PielColor As String, ByVal CodigoSicy As String, ByVal tallaSicy As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Try
            parametro.ParameterName = "@lote"
            parametro.Value = Lote
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@PielColor"
            parametro.Value = PielColor
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@CodigoSicy"
            parametro.Value = CodigoSicy
            listaParametros.Add(parametro)


            parametro = New SqlParameter
            parametro.ParameterName = "@tallaSicy"
            parametro.Value = tallaSicy
            listaParametros.Add(parametro)


            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_DevolucionCliente_IngresoGranel_IngresarLoteGranel]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try

    End Function


    Public Function ReingresosGranelInsertaDocenasNormales(ByVal FolioDevolucionID As Integer,
                                                           ByVal FolioDevolucionSICYId As Integer,
                                                          ByVal NumDocenas As Integer,
                                                          ByVal Nave As Integer,
                                                          ByVal Lote As Integer,
                                                          ByVal idTallaSicy As String,
                                                          ByVal idCodigoSICY As String,
                                                          ByVal idDocena As Integer,
                                                          ByVal ProductoEstiloOriginalID As Integer,
                                                           ByVal ProductoEstiloID As Integer
                                                          )
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Try
            parametro.ParameterName = "@FolioDevolucionClienteId"
            parametro.Value = FolioDevolucionID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@FolioDevolucionSICYId"
            parametro.Value = FolioDevolucionSICYId
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@NumDocenas"
            parametro.Value = NumDocenas
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@Nave"
            parametro.Value = Nave
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@Lote"
            parametro.Value = Lote
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@Tipo"
            parametro.Value = "G"
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@Saldo"
            parametro.Value = 0
            listaParametros.Add(parametro)


            parametro = New SqlParameter
            parametro.ParameterName = "@IdAlmacen"
            parametro.Value = 1
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@PedidoSICY"
            parametro.Value = 0
            listaParametros.Add(parametro)


            parametro = New SqlParameter
            parametro.ParameterName = "@IdPartida"
            parametro.Value = 0
            listaParametros.Add(parametro)


            parametro = New SqlParameter
            parametro.ParameterName = "@IdLote"
            parametro.Value = 0
            listaParametros.Add(parametro)


            parametro = New SqlParameter
            parametro.ParameterName = "@IdtblCancelacion"
            parametro.Value = 0
            listaParametros.Add(parametro)


            parametro = New SqlParameter
            parametro.ParameterName = "@Empaque"
            parametro.Value = "A"
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@StAtado"
            parametro.Value = "A"
            listaParametros.Add(parametro)


            parametro = New SqlParameter
            parametro.ParameterName = "@IdTallaSICY"
            parametro.Value = idTallaSicy
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@IdCodigoSICY"
            parametro.Value = idCodigoSICY
            listaParametros.Add(parametro)


            parametro = New SqlParameter
            parametro.ParameterName = "@IdDocena"
            parametro.Value = idDocena
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@FechaPrograma"
            parametro.Value = Date.Now
            listaParametros.Add(parametro)


            parametro = New SqlParameter
            parametro.ParameterName = "@ProductoEstiloOriginalID"
            parametro.Value = ProductoEstiloOriginalID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@ProductoEstiloID"
            parametro.Value = ProductoEstiloID
            listaParametros.Add(parametro)


            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_DevolucionCliente_IngresoGranel_InsertaDocenasNormales]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function BuscarFinTallas(ByVal idTallaSicy As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Try
            parametro.ParameterName = "@idTalla"
            parametro.Value = idTallaSicy
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("Programacion.SP_ImprimirEtiquetasOpcionesAvanzadasBuscarFinTallas", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function BuscarTalla(ByVal num As String, ByVal idTallaSicy As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Try
            parametro.ParameterName = "@Num"
            parametro.Value = num
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@p_idTalla"
            parametro.Value = idTallaSicy
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("Programacion.SP_ImprimirEtiquetasOpcionesAvanzadasBuscarTalla", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function EjecutaConsulta(ByVal Tabla As Boolean, ByVal sql As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Try

            parametro.ParameterName = "@Tabla"
            parametro.Value = Tabla
            listaParametros.Add(parametro)


            parametro = New SqlParameter
            parametro.ParameterName = "@sql"
            parametro.Value = sql
            listaParametros.Add(parametro)


            Return objPersistencia.EjecutarConsultaSP("Programacion.EjecutaConsulta", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub ActualizaFolioLotesGenerados(ByVal FolioDevolucionID As Integer, ByVal UsuarioId As Integer)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Try

            parametro.ParameterName = "@FolioDevolucionID"
            parametro.Value = FolioDevolucionID
            listaParametros.Add(parametro)


            parametro = New SqlParameter
            parametro.ParameterName = "@UsuarioId"
            parametro.Value = UsuarioId
            listaParametros.Add(parametro)


            objPersistencia.EjecutarConsultaSP("[Almacen].[SP_DevolucionCliente_IngresoGranel_ActualizaLotesGeneradosFolio]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function ConsultaParesFolioDevolucion(ByVal FolioDevolucionID As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Try

            parametro.ParameterName = "@FolioDevolucionID"
            parametro.Value = FolioDevolucionID
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_DevolucionCliente_IngresoGranel_ConsultarParesFolioDevolucion]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ConsultaAtadosFolioDevolucion(ByVal FolioDevolucionID As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Try

            parametro.ParameterName = "@FolioDevolucionID"
            parametro.Value = FolioDevolucionID
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_DevolucionCliente_IngresoGranel_ConsultarAtados]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function GuardarLoteGranelFolioDetalle(ByVal FolioDetalleID As Integer, LoteGranel As Integer, ByVal Año As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Try

            parametro.ParameterName = "@FolioDetalle"
            parametro.Value = FolioDetalleID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@LoteGranel"
            parametro.Value = LoteGranel
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@año"
            parametro.Value = Año
            listaParametros.Add(parametro)


            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_DevolucionCliente_IngresoGranel_GuardarLoteGranelFolioDetalle]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ConsultarModelos(ByVal Modelo As String, ByVal TallaId As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Try

            parametro.ParameterName = "@Modelo"
            parametro.Value = Modelo
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@TallaID"
            parametro.Value = TallaId
            listaParametros.Add(parametro)


            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_DevolucionCliente_IngresoGranel_ConsultarModelos]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ConsultarArticulosPorColeccion(ByVal Modelo As String, ByVal Coleccion As String, ByVal TallaId As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Try

            parametro.ParameterName = "@Modelo"
            parametro.Value = Modelo
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@Coleccion"
            parametro.Value = Coleccion
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@TallaID"
            parametro.Value = TallaId
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_DevolucionCliente_IngresoGranel_ConsultarModelosPorColeccion]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function SustituirArticulo(ByVal FolioDetalleDevolucionId As String, ByVal ProductoEstiloOriginal As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Try

            parametro.ParameterName = "@FolioDetalleDevolucionId"
            parametro.Value = FolioDetalleDevolucionId
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@ProductoEstilo"
            parametro.Value = ProductoEstiloOriginal
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_DevolucionCliente_IngresoGranel_SustituirArticulo]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class
