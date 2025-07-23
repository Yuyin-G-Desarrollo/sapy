Imports System.Data.SqlClient
Imports Entidades

Public Class EtiquetasDA

    ''' <summary>
    ''' Consulta los lotes que se encuentran en un programa para cierta nave
    ''' </summary>
    ''' <param name="NaveSICYID">NaveID del SICY</param>
    ''' <param name="FechaPrograma">Fecha corta del programa</param>
    ''' <remarks></remarks>
    Public Function ConsultarLotesPorPrograma(ByVal NaveSICYID As Integer, ByVal FechaPrograma As Date) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "Nave"
        parametro.Value = NaveSICYID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FechaPrograma"
        parametro.Value = FechaPrograma
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_Etiquetas_ConsultarLotesPrograma]", listaParametros)
    End Function


    ''' <summary>
    ''' Consultar las naves que se encuentran activas en el SICY
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ConsultarNavesSICY() As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_ConsultarNavesActivas]", listaParametros)
    End Function

    Public Function ImprimirEtiquetasSAY(ByVal Lotes As String, ByVal Nave As Integer, ByVal Año As Int32) As DataTable

        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "lotes"
        parametro.Value = Lotes
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "nave"
        parametro.Value = Nave
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "anio"
        parametro.Value = Año
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_ImprimirEtiquetasSAY]", listaParametros)
    End Function


    Public Function ComandosImprimirEtiquetasSAY(ByVal Lotes As String, ByVal Nave As Integer, ByVal Año As Int32) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "lotes"
        parametro.Value = Lotes
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "nave"
        parametro.Value = Nave
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "anio"
        parametro.Value = Año
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_ComandosImprimirEtiqueta]", listaParametros)
    End Function


    Public Function ImprimirEtiquetasSAY300dpi(ByVal Lotes As String, ByVal Nave As Integer, ByVal Año As Int32) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "lotes"
        parametro.Value = Lotes
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "nave"
        parametro.Value = Nave
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "anio"
        parametro.Value = Año
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_ImprimirEtiquetasSAY_300dpi]", listaParametros)
    End Function

    Public Function ListaImpresoras() As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter


        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_Etiquetas_ConsultaImpresoras]", listaParametros)
    End Function


    Public Function ObtenerEtiquetasLote(ByVal Lotes As String, ByVal Nave As Integer, ByVal Año As Int32, ByVal ImpresoraID As Integer, ByVal UsuarioID As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "lotes"
            parametro.Value = Lotes
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "nave"
            parametro.Value = Nave
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "anio"
            parametro.Value = Año
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_ImprimirEtiquetasSAY]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function ImpresionEtiquetasLote(ByVal Lotes As String, ByVal Nave As Integer, ByVal Año As Int32, ByVal ImpresoraID As Integer, ByVal UsuarioID As Integer, ByVal FechaPrograma As Date) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "lotes"
            parametro.Value = Lotes
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "nave"
            parametro.Value = Nave
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "anio"
            parametro.Value = Año
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "ImpresoraID"
            parametro.Value = ImpresoraID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "UsuarioID"
            parametro.Value = UsuarioID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "FechaPrograma"
            parametro.Value = FechaPrograma
            listaParametros.Add(parametro)

            'Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_ImprimirEtiquetas]", listaParametros)
            Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_ImprimirEtiquetas_PPrueba]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function GuardarBitacoraImpresionLotes(ByVal Lotes As String, ByVal NaveSICYID As Integer, ByVal FechaPrograma As Date, ByVal UsuarioID As Integer, ByVal Año As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "lotes"
            parametro.Value = Lotes
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "NaveSICYId"
            parametro.Value = NaveSICYID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "FechaPrograma"
            parametro.Value = FechaPrograma
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "UsuarioId"
            parametro.Value = UsuarioID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "Año"
            parametro.Value = Año
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_Etiquetas_GuardarBitacoraImpresionLotes]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try

    End Function






    Public Function ConsultarImpresorasZebra() As DataTable


        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Try

            Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_Consulta_Impresoras_Zebra]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ConsultarEtiquetasEspeciales(ByVal StatusEtiquetaId As String)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@StatusEtiquetaID"
            parametro.Value = StatusEtiquetaId
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_Etiquetas_ConsultaClientesEtiquetaEspecial_v2]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function ActualizarImpresorasZebra(ByVal accion As Integer, ByVal entidadImpresora As Entidades.ImpresorasZebra)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Try
            parametro.ParameterName = "accion"
            parametro.Value = accion
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@IdImpresora"
            parametro.Value = entidadImpresora.idImpresora
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@Nombre"
            parametro.Value = entidadImpresora.Nombre
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@Comando"
            parametro.Value = entidadImpresora.Comando
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@StImpresora"
            parametro.Value = entidadImpresora.StImpresion
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@Resolucion"
            parametro.Value = entidadImpresora.Resolucion
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@Abreviatura"
            parametro.Value = entidadImpresora.Abreviatura
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@UsuarioCreoId"
            parametro.Value = entidadImpresora.UsuarioCreoId
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@FechaCreacion"
            parametro.Value = Nothing
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@UsuarioModificoId"
            parametro.Value = entidadImpresora.UsuarioCreoId
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@FechaModificacion"
            parametro.Value = Nothing
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_Inserta_Actualiza_Elimina_ImpresoraZebra]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ConsultarEtiquetasEspecialesClientes(ByVal idEtiqueta As Integer) As DataTable

        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro = New SqlParameter
            parametro.ParameterName = "@EtiquetaID"
            parametro.Value = idEtiqueta
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_Etiquetas_ConsultaEtiqueta]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try


    End Function

    Public Function AltaEtiquetaConfiguracion(ByVal Etiqueta As Entidades.ConfiguracionEtiqueta, ByVal accion As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try

            parametro = New SqlParameter
            parametro.ParameterName = "@ACCION"
            parametro.Value = accion
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@etiq_etiquetaid"
            parametro.Value = Etiqueta.EtiquetaId
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@etiq_clave"
            parametro.Value = Etiqueta.EtiquetaClave
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@etiq_tipoetiquetaid"
            parametro.Value = Etiqueta.TipoEtiquetaId
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@etiq_nombre"
            parametro.Value = Etiqueta.EtiquetaNombre
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@etiq_descripcion"
            parametro.Value = Etiqueta.EtiquetaDescripcion
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@etiq_codigozpl"
            parametro.Value = Etiqueta.CodigoZPL
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@etiq_ancho"
            parametro.Value = Etiqueta.EtiquetaAncho
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@etiq_alto"
            parametro.Value = Etiqueta.EtiquetaAlto
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@etiq_orientacion"
            parametro.Value = Etiqueta.EtiquetaOrientacion
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@etiq_usuariocreoid"
            parametro.Value = Etiqueta.EtiquetaUsuarioCreoId
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@etiq_fechacreacion"
            parametro.Value = Nothing
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@etiq_usuariomodificoid"
            parametro.Value = Etiqueta.UsuarioModificoId
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@etiq_fechamodificacion"
            parametro.Value = Nothing
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@etiq_clienteid"
            parametro.Value = Etiqueta.ClienteId
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@etiq_etiquetayuyin"
            parametro.Value = Etiqueta.EtiquetaYuyin
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@etiq_codigozpl300"
            parametro.Value = Etiqueta.EtiquetaCodigoZPL300
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@etiq_activa"
            parametro.Value = Etiqueta.EtiquetaActiva
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@etiq_vistaprevia"
            parametro.Value = Etiqueta.EtiquetaVistaPrevia
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@etiq_impresionesalpaso"
            parametro.Value = Etiqueta.EtiquetaImpresionesAlPaso
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@etiq_rutalbl"
            parametro.Value = Etiqueta.RutaLBL
            listaParametros.Add(parametro)


            Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_ConfiguracionEtiquetasInsertaActualizaElimina]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function ConsultaEtiquetaYuyin(ByVal StatusID As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro = New SqlParameter
            parametro.ParameterName = "@StatusId"
            parametro.Value = StatusID
            listaParametros.Add(parametro)


            Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_Etiquetas_ConsultarEtiquetasYuyin_v2]", listaParametros)

        Catch ex As Exception
            Throw ex
        End Try

    End Function


    Public Function ConsultarParametrosRelacionados() As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_RelacionarParametrosEtiquetas]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function ConsultarParametros() As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_ConsultaParametrosEtiquetas]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Consulta los pèdidos COPPEL dentro de un programa
    ''' </summary>
    ''' <param name="FechaInicioPrograma">Fecha de Inicio del programa</param>
    ''' <param name="FechaFinPrograma">Fecha fin del programa</param>
    ''' <param name="NaveSICYID">Nave SICY ID , 0 = Todas las NAves, 0 <> Nave seleccionada</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function EtiquetasPedidosCoppel(ByVal FechaInicioPrograma As String, ByVal NaveSICYID As Int16) As DataTable ' ByVal FechaFinPrograma As Date,
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter


        Try
            parametro = New SqlParameter
            parametro.ParameterName = "@FechaInicio"
            parametro.Value = FechaInicioPrograma
            listaParametros.Add(parametro)

            'parametro = New SqlParameter
            'parametro.ParameterName = "@FechaFin"
            'parametro.Value = FechaFinPrograma
            'listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@NaveId"
            parametro.Value = NaveSICYID
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_Etiquetas_PedidosCOPPEL]", listaParametros)
        Catch ex As Exception
            Throw ex

        End Try

    End Function

    Public Function ReporteCOPPEL_ConsultaProgramas(ByVal FechaInicio As Date, ByVal FechaFin As Date) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@FechaInicio"
            parametro.Value = FechaInicio
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@FechaFin"
            parametro.Value = FechaFin
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_Etiquetas_ReporteCOPPEL_FechasPrograma]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ReporteCOPPEL_ConsultaNaveProgramas(ByVal FechaInicio As Date, ByVal FechaFin As Date, ByVal NaveID As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@FechaInicio"
            parametro.Value = FechaInicio
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@FechaFin"
            parametro.Value = FechaFin
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@NaveID"
            parametro.Value = NaveID
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_Etiquetas_ReporteCOPPEL_NavesPrograma]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ReporteCOPPEL_ConsultaParesNaveProgramas(ByVal FechaInicio As Date, ByVal FechaFin As Date, ByVal NaveID As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@FechaInicio"
            parametro.Value = FechaInicio
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@FechaFin"
            parametro.Value = FechaFin
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@NaveID"
            parametro.Value = NaveID
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_Etiquetas_ReporteCOPPEL_ParesNavesPrograma]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ReporteCOPPEL_ConsultaPedidosProgramas(ByVal FechaInicio As Date, ByVal FechaFin As Date, ByVal NaveID As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@FechaInicio"
            parametro.Value = FechaInicio
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@FechaFin"
            parametro.Value = FechaFin
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@NaveID"
            parametro.Value = NaveID
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_Etiquetas_ReporteCOPPEL_PedidosCOPPELPrograma]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function ReporteCOPPEL_ConsultaParesPedidosProgramas(ByVal FechaInicio As Date, ByVal FechaFin As Date, ByVal NaveID As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@FechaInicio"
            parametro.Value = FechaInicio
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@FechaFin"
            parametro.Value = FechaFin
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@NaveID"
            parametro.Value = NaveID
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_Etiquetas_ReporteCOPPEL_TotalParesPedidoCOPPELPorPrograma]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ReporteCOPPEL_ConsultaDetallesPedidosProgramas(ByVal FechaInicio As Date, ByVal FechaFin As Date, ByVal NaveID As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@FechaInicio"
            parametro.Value = FechaInicio
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@FechaFin"
            parametro.Value = FechaFin
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@NaveID"
            parametro.Value = NaveID
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_Etiquetas_ReporteCOPPEL_DetallesPedidosCOPPELPorPrograma]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Inserta parametro etiqueta
    ''' </summary>
    ''' <param name="EtiquetaID">Identificador de la Etiqueta</param>
    ''' <param name="ParametroID">Identificador del parametro</param>    
    ''' <remarks></remarks>
    Public Sub InsertarParametroEtiqueta(ByVal EtiquetaID As Integer, ByVal ParametroID As Integer, ByVal Resolucion As Integer)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@EtiquetaID"
            parametro.Value = EtiquetaID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@ParametroID"
            parametro.Value = ParametroID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@Resolucion"
            parametro.Value = Resolucion
            listaParametros.Add(parametro)

            objPersistencia.EjecutarConsultaSP("[Programacion].[SP_Etiquetas_InsertarParametros]", listaParametros)


        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub LimpiarParametroEtiqueta(ByVal EtiquetaID As Integer, ByVal Resolucion As Integer)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@EtiquetaID"
            parametro.Value = EtiquetaID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@Resolucion"
            parametro.Value = Resolucion
            listaParametros.Add(parametro)

            objPersistencia.EjecutarConsultaSP("[Programacion].[SP_Etiquetas_EliminarParametros]", listaParametros)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function GuardarEncabezadoImpresionEtiquetasCoppel(ByVal PedidoCliente As String, ByVal Usuario As String, ByVal PedidoSICY As Integer, ByVal Pares As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "Archivo"
            parametro.Value = PedidoCliente
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "Usuario"
            parametro.Value = Usuario
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "PedidoSICY"
            parametro.Value = PedidoSICY
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "Pares"
            parametro.Value = Pares
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_Etiquetas_InsertarEncabezadoImpresionEtiquetaCoppel]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function GuardarDetalleImpresionEtiquetasCoppel(ByVal IdArchivo As Integer, ByVal Cantidad As Integer, ByVal Precio As String, ByVal CodigoBarras As String, ByVal Codigo As String, ByVal Familia As String, ByVal Bodega As String, ByVal Talla As String, ByVal Descripcion As String, ByVal Pedido As String, ByVal Tipo As String, ByVal Modelo As String, ByVal Color As String, ByVal IdCodigo As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "IdArchivo"
            parametro.Value = IdArchivo
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "Pares"
            parametro.Value = Cantidad
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "Precio"
            parametro.Value = Precio
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "CodigoBarras"
            parametro.Value = CodigoBarras
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "Codigo"
            parametro.Value = Codigo
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "Familia"
            parametro.Value = Familia
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "Bodega"
            parametro.Value = Bodega
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "Talla"
            parametro.Value = Talla
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "Descripcion"
            parametro.Value = Descripcion
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "Pedido"
            parametro.Value = Pedido
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "Tipo"
            parametro.Value = Tipo
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "Modelo"
            parametro.Value = Modelo
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "Color"
            parametro.Value = Color
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "IdCodigo"
            parametro.Value = IdCodigo
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_Etiquetas_InsertarDetalleImpresionEtiquetaCoppel]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function GuardaBitacoraEtiquetaLotes(ByVal año As Integer, ByVal nave As Integer, ByVal fechaprograma As Date, ByVal usuarioid As Integer, ByVal fechaimpresion As DateTime, ByVal pedidocliente As String, ByVal pares As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlParameter)
        Dim Parametro As SqlParameter

        Try

            Parametro = New SqlParameter
            Parametro.ParameterName = "año"
            Parametro.Value = año
            ListaParametros.Add(Parametro)

            Parametro = New SqlParameter
            Parametro.ParameterName = "nave"
            Parametro.Value = nave
            ListaParametros.Add(Parametro)

            Parametro = New SqlParameter
            Parametro.ParameterName = "fechaprograma"
            Parametro.Value = fechaprograma
            ListaParametros.Add(Parametro)

            Parametro = New SqlParameter
            Parametro.ParameterName = "usuarioid"
            Parametro.Value = usuarioid
            ListaParametros.Add(Parametro)

            Parametro = New SqlParameter
            Parametro.ParameterName = "fechaimpresion"
            Parametro.Value = fechaimpresion
            ListaParametros.Add(Parametro)

            Parametro = New SqlParameter
            Parametro.ParameterName = "pedidocliente"
            Parametro.Value = pedidocliente
            ListaParametros.Add(Parametro)

            Parametro = New SqlParameter
            Parametro.ParameterName = "pares"
            Parametro.Value = pares
            ListaParametros.Add(Parametro)

            Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_Etiquetas_InsertaBitacoraEtiquetaLotes]", ListaParametros)

        Catch ex As Exception

            Throw ex

        End Try

    End Function



    Public Function ConsultarTodoModelosImagenes(ByVal estatus As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try

            parametro = New SqlParameter
            parametro.ParameterName = "@estatus"
            parametro.Value = estatus
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_Consulta_ModelosImagenTodos]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try

    End Function


    Public Function ConsultarModelosImagenesConGraficos(ByVal estatus As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Try
            parametro = New SqlParameter
            parametro.ParameterName = "@estatus"
            parametro.Value = estatus
            listaParametros.Add(parametro)
            Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_Consulta_ModelosImagenconGraficos]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try

    End Function


    Public Function ConsultarModelosImagenesSinGraficos(ByVal estatus As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Try
            parametro = New SqlParameter
            parametro.ParameterName = "@estatus"
            parametro.Value = estatus
            listaParametros.Add(parametro)
            Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_Consulta_ModelosImagenesSinGraficos]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function ConsultarCadenaRutaJPGOpciones() As DataTable

        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim consultaSQL = " SELECT opci_valor_cadena FROM Programacion.Opciones WHERE opci_tipoopcion = 'Etiquetas' AND opci_descripcion = 'Rutas de imagenes jpg' "

        Try
            Return objPersistencia.EjecutaConsulta(consultaSQL)
        Catch ex As Exception
            Throw ex
        End Try

    End Function



    Public Function ConsultarCadenaRutaCompletaJPGOpciones() As DataTable

        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim consultaSQL = " SELECT opci_valor_cadena FROM Programacion.Opciones WHERE opci_tipoopcion = 'ETIQUETAS' AND opci_descripcion = 'Ruta completa de siluetas jpg' "

        Try
            Return objPersistencia.EjecutaConsulta(consultaSQL)
        Catch ex As Exception
            Throw ex
        End Try

    End Function


    Public Function COnsultarModeloSeleccionado(ByVal IdLinea As String, ByVal IdTalla As String, ByVal IdModelo As String) As DataTable
        Dim objpers As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Try

            parametro = New SqlParameter
            parametro.ParameterName = "@IdLinea"
            parametro.Value = IdLinea
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@IdTalla"
            parametro.Value = IdTalla
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@IdModelo"
            parametro.Value = IdModelo
            listaParametros.Add(parametro)


            Return objpers.EjecutarConsultaSP("[Programacion].[SP_ConsultaModeloImagen]", listaParametros)

        Catch ex As Exception
            Throw ex
        End Try

    End Function


    Public Function ConsultarCadenaRutaGRFOpciones() As DataTable

        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim consultaSQL = " SELECT opci_valor_cadena FROM Programacion.Opciones WHERE opci_tipoopcion = 'ETIQUETAS' AND opci_descripcion = 'Rutas de imagen GRF' "

        Try
            Return objPersistencia.EjecutaConsulta(consultaSQL)
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function ConsultaEstatusEtiquetas() As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_Etiquetas_ConsultaEstatus]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Sub PreAutorizarEtiqueta(ByVal EtiquetaID As Integer, ByVal UsuarioId As Integer)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@EtiquetaID"
            parametro.Value = EtiquetaID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@UsuarioID"
            parametro.Value = UsuarioId
            listaParametros.Add(parametro)

            objPersistencia.EjecutarConsultaSP("[Programacion].[SP_Etiquetas_PreAutorizarEtiqueta]", listaParametros)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#Region "VistaPrevia"
    Public Function VistaPrevia(ByVal etiquetaId As Integer, Optional ByVal ClienteId As Integer = 0, Optional ByVal StatusEtiquetaID As Integer = 0, Optional ByVal ResolucionImpresora As String = "203dpi", Optional ByVal UsuarioImprimio As String = "") As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro = New SqlParameter
            parametro.ParameterName = "@p_etiquetaId"
            parametro.Value = etiquetaId
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@p_ClienteId"
            'parametro.Value = IIf(ClienteId = 0, DBNull.Value, ClienteId)
            parametro.Value = ClienteId
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@StatusEtiquetaId"
            parametro.Value = StatusEtiquetaID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@ResolucionImpresora"
            parametro.Value = ResolucionImpresora
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@UsuarioImprimio"
            parametro.Value = UsuarioImprimio
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("Programacion.SP_ImprimirEtiquetaVistaPrevia_v2", listaParametros)
            'Return objPersistencia.EjecutarConsultaSP("Programacion.SP_ImprimirEtiquetaVistaPrevia", listaParametros)
            'Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_ImprimirEtiquetaVistaPrevia_v2_PPrueba]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region

#Region "OpcionesAvanzadas"
    Public Function ImprimirAtados(ByVal nave As Integer,
                                   ByVal FechaPrograma As Date,
                                   ByVal UsuarioId As Integer,
                                   ByVal ImpresoraID As Integer,
                                   ByVal LoteDe As Integer,
                                   ByVal LoteHasta As Integer,
                                   ByVal imprimirPares As Boolean,
                                   ByVal CadenaAtados As String
                                   ) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro = New SqlParameter
            parametro.ParameterName = "@nave"
            parametro.Value = nave
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@FechaPrograma"
            parametro.Value = FechaPrograma
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@UsuarioID"
            parametro.Value = UsuarioId
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@ImpresoraID"
            parametro.Value = ImpresoraID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@LoteDe"
            parametro.Value = LoteDe
            listaParametros.Add(parametro)


            parametro = New SqlParameter
            parametro.ParameterName = "@LoteHasta"
            parametro.Value = LoteHasta
            listaParametros.Add(parametro)


            parametro = New SqlParameter
            parametro.ParameterName = "@imprimirPares"
            parametro.Value = imprimirPares
            listaParametros.Add(parametro)


            parametro = New SqlParameter
            parametro.ParameterName = "@CadenaAtados"
            parametro.Value = CadenaAtados
            listaParametros.Add(parametro)



            Return objPersistencia.EjecutarConsultaSP("Programacion.SP_ImprimirEtiquetasOpcionesAvanzadasAtados", listaParametros)
            'Return objPersistencia.EjecutarConsultaSP("Programacion.SP_ImprimirEtiquetasOpcionesAvanzadasAtados_PPrueba", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ImprimirAtados_Devolucion(ByVal FolioDev As Integer,
                                              ByVal nave As Integer,
                                              ByVal UsuarioId As Integer,
                                              ByVal ImpresoraID As Integer,
                                              ByVal LoteDe As Integer,
                                              ByVal LoteHasta As Integer,
                                              ByVal imprimirPares As Boolean,
                                              ByVal CadenaAtados As String
                                              ) As DataTable

        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)

        Try
            listaParametros.Add(New SqlParameter With {
                .ParameterName = "@FolioDev",
                .Value = FolioDev
            })

            listaParametros.Add(New SqlParameter With {
                .ParameterName = "@nave",
                .Value = nave
            })

            listaParametros.Add(New SqlParameter With {
                .ParameterName = "@UsuarioID",
                .Value = UsuarioId
            })

            listaParametros.Add(New SqlParameter With {
                .ParameterName = "@ImpresoraID",
                .Value = ImpresoraID
            })

            listaParametros.Add(New SqlParameter With {
                .ParameterName = "@LoteDe",
                .Value = LoteDe
            })

            listaParametros.Add(New SqlParameter With {
                .ParameterName = "@LoteHasta",
                .Value = LoteHasta
            })

            listaParametros.Add(New SqlParameter With {
                .ParameterName = "@imprimirPares",
                .Value = imprimirPares
            })

            listaParametros.Add(New SqlParameter With {
                .ParameterName = "@CadenaAtados",
                .Value = CadenaAtados
            })

            Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_ImprimirEtiquetasOpcionesAvanzadasAtados_Devolucion]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ConsultaImpresoraAsignada(ByVal Equipo As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro = New SqlParameter
            parametro.ParameterName = "@Equipo"
            parametro.Value = Equipo
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("Programacion.SP_Etiquetas_ConsultaImpresoraAsignada", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    'Public Function MostrarPares(ByVal naveId As Integer, ByVal sql As String) As List(Of Entidades.Pares)
    '    Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
    '    Dim listaParametros As New List(Of SqlParameter)
    '    Dim parametro As New SqlParameter
    '    Dim dt As DataTable
    '    Dim ListaPares As New List(Of Pares)
    '    Try
    '        parametro = New SqlParameter
    '        parametro.ParameterName = "@nave"
    '        parametro.Value = naveId
    '        listaParametros.Add(parametro)

    '        parametro = New SqlParameter
    '        parametro.ParameterName = "@AddQuery"
    '        parametro.Value = sql
    '        listaParametros.Add(parametro)

    '        dt = objPersistencia.EjecutarConsultaSP("[dbo].[sp_ConsultaImpresionEtiquetasPar]", listaParametros)
    '        For Each row As DataRow In dt.Rows
    '            Dim par As New Pares
    '            par.Lote = IIf(IsDBNull(row("Lote")), 0, row("Lote"))
    '            par.Docena = IIf(IsDBNull(row("No_Docena")), "", row("No_Docena"))
    '            par.idDocena = IIf(IsDBNull(row("idDocena")), "", row("idDocena"))
    '            par.idPar = IIf(IsDBNull(row("idpar")), "", row("idpar"))
    '            par.Talla = IIf(IsDBNull(row("Talla")), "", row("Talla"))

    '            ListaPares.Add(par)
    '        Next
    '        Return ListaPares
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Function

    Public Function MostrarPares(ByVal naveId As Integer, ByVal AnioLote As Int16, LoteInicio As Integer, LoteFin As Integer, AtadoInicio As String, AtadoFin As String, ByVal FolioDevSay As Integer) As List(Of Entidades.Pares)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)

        Dim dt As DataTable
        Dim ListaPares As New List(Of Pares)
        Try
            listaParametros.Add(New SqlParameter With {
                .ParameterName = "@nave",
                .Value = naveId
            })

            listaParametros.Add(New SqlParameter With {
                .ParameterName = "@AnioLote",
                .Value = AnioLote
            })

            listaParametros.Add(New SqlParameter With {
                .ParameterName = "@Lote_Inicio",
                .Value = LoteInicio
            })

            listaParametros.Add(New SqlParameter With {
                .ParameterName = "@Lote_Fin",
                .Value = LoteFin
            })

            listaParametros.Add(New SqlParameter With {
                .ParameterName = "@Atado_Inicio",
                .Value = AtadoInicio
            })

            listaParametros.Add(New SqlParameter With {
                .ParameterName = "@Atado_Fin",
                .Value = AtadoFin
            })

            listaParametros.Add(New SqlParameter With {
                .ParameterName = "@FolioDevolucionSAY",
                .Value = FolioDevSay
            })

            dt = objPersistencia.EjecutarConsultaSP("[Programacion].[SP_Etiquetas_ConsultaImpresionEtiquetasPar]", listaParametros)
            For Each row As DataRow In dt.Rows
                Dim par As New Pares
                par.Lote = IIf(IsDBNull(row("Lote")), 0, row("Lote"))
                par.Docena = IIf(IsDBNull(row("No_Docena")), "", row("No_Docena"))
                par.idDocena = IIf(IsDBNull(row("idDocena")), "", row("idDocena"))
                par.idPar = IIf(IsDBNull(row("idpar")), "", row("idpar"))
                par.Talla = IIf(IsDBNull(row("Talla")), "", row("Talla"))
                par.ModeloSAY = IIf(IsDBNull(row("ModeloSAY")), "", row("ModeloSAY"))
                par.Color = IIf(IsDBNull(row("Color")), "", row("Color"))
                ListaPares.Add(par)
            Next
            Return ListaPares
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ImprimirPares(ByVal nave As Integer,
                                   ByVal FechaPrograma As Date,
                                   ByVal UsuarioId As Integer,
                                   ByVal ImpresoraID As Integer,
                                   ByVal LoteDe As Integer,
                                   ByVal LoteHasta As Integer,
                                   ByVal ProgramaCompleto As Boolean,
                                   ByVal Lotes As String,
                                   ByVal CadenaAtados As String,
                                   ByVal CadenaPares As String
                                   ) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro = New SqlParameter
            parametro.ParameterName = "@nave"
            parametro.Value = nave
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@FechaPrograma"
            parametro.Value = FechaPrograma
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@UsuarioID"
            parametro.Value = UsuarioId
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@ImpresoraID"
            parametro.Value = ImpresoraID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@LoteDe"
            parametro.Value = LoteDe
            listaParametros.Add(parametro)


            parametro = New SqlParameter
            parametro.ParameterName = "@LoteHasta"
            parametro.Value = LoteHasta
            listaParametros.Add(parametro)


            parametro = New SqlParameter
            parametro.ParameterName = "@ProgramaCompleto"
            parametro.Value = ProgramaCompleto
            listaParametros.Add(parametro)


            parametro = New SqlParameter
            parametro.ParameterName = "@lotes"
            parametro.Value = Lotes
            listaParametros.Add(parametro)


            parametro = New SqlParameter
            parametro.ParameterName = "@CadenaAtados"
            parametro.Value = CadenaAtados
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@CadenaPares"
            parametro.Value = CadenaPares
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("Programacion.SP_ImprimirEtiquetasOpcionesAvanzadasPares", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function ImprimirPares_Devolucion(ByVal FolioDev As Integer,
                                             ByVal Nave As Int32,
                                             ByVal UsuarioId As Integer,
                                             ByVal ImpresoraID As Integer,
                                             ByVal LoteDe As Integer,
                                             ByVal LoteHasta As Integer,
                                             ByVal CadenaAtados As String,
                                             ByVal CadenaPares As String
                                             ) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)

        Try
            listaParametros.Add(New SqlParameter With {
                .ParameterName = "@FolioDev",
                .Value = FolioDev
            })

            listaParametros.Add(New SqlParameter With {
                .ParameterName = "@nave",
                .Value = Nave
            })

            listaParametros.Add(New SqlParameter With {
                .ParameterName = "@UsuarioID",
                .Value = UsuarioId
            })

            listaParametros.Add(New SqlParameter With {
                .ParameterName = "@ImpresoraID",
                .Value = ImpresoraID
            })

            listaParametros.Add(New SqlParameter With {
                .ParameterName = "@LoteDe",
                .Value = LoteDe
            })

            listaParametros.Add(New SqlParameter With {
                .ParameterName = "@LoteHasta",
                .Value = LoteHasta
            })

            listaParametros.Add(New SqlParameter With {
                .ParameterName = "@CadenaAtados",
                .Value = CadenaAtados
            })

            listaParametros.Add(New SqlParameter With {
                .ParameterName = "@CadenaPares",
                .Value = CadenaPares
            })

            Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_ImprimirEtiquetasOpcionesAvanzadasPares_Devoluciones]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ConsultarClientesEtiqueta() As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Try
            Return objPersistencia.EjecutarConsultaSP("Programacion.SP_Etiquetas_ConsultaClientesEtiquetas", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ConsultarClientesTipoEtiqueta(ByVal Accion As Int16, ByVal id As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Try
            parametro.ParameterName = "@Accion"
            parametro.Value = Accion
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@idCliente"
            parametro.Value = id
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("Programacion.SP_Etiquetas_ConsultaClientesTipoEtiqueta", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ConsultarClientesApartados(ByVal id As Integer, ByVal fInicial As Date, ByVal fFinal As Date) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Try
            parametro.ParameterName = "@idCliente"
            parametro.Value = id
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@fechaInicial"
            parametro.Value = fInicial
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@fechaFinal"
            parametro.Value = fFinal
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("Programacion.SP_Etiquetas_ConsultaClientesApartados", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ImprimirClientesPrueba(ByVal ImpresoraID As Integer,
                                           ByVal UsuarioID As Integer,
                                           ByVal ClienteID As Integer,
                                           ByVal tipoetiquetaid As Integer,
                                           ByVal MostrarDetalles As Boolean,
                                           ByVal PorLotes As Boolean,
                                           ByVal nave As Integer,
                                           ByVal FechaPrograma As Date,
                                           ByVal LoteDe As Integer,
                                           ByVal LoteHasta As Integer,
                                           ByVal PorPedido As Boolean,
                                           ByVal PedidoSicy As Integer,
                                           ByVal PedidoSay As Integer,
                                           ByVal PorApartados As Boolean,
                                           ByVal CadenaApartados As String)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro = New SqlParameter
            parametro.ParameterName = "@ImpresoraID"
            parametro.Value = ImpresoraID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@UsuarioID"
            parametro.Value = UsuarioID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@ClienteID"
            parametro.Value = ClienteID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@tipoetiquetaid"
            parametro.Value = tipoetiquetaid
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@MostrarDetalle"
            parametro.Value = MostrarDetalles
            listaParametros.Add(parametro)


            parametro = New SqlParameter
            parametro.ParameterName = "@PorLotes"
            parametro.Value = PorLotes
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@nave"
            parametro.Value = IIf(nave = 0, DBNull.Value, nave)
            listaParametros.Add(parametro)


            parametro = New SqlParameter
            parametro.ParameterName = "@FechaPrograma"
            parametro.Value = FechaPrograma
            listaParametros.Add(parametro)


            parametro = New SqlParameter
            parametro.ParameterName = "@LoteDe"
            parametro.Value = IIf(LoteDe = 0, DBNull.Value, LoteDe)
            listaParametros.Add(parametro)


            parametro = New SqlParameter
            parametro.ParameterName = "@LoteHasta"
            parametro.Value = IIf(LoteHasta = 0, DBNull.Value, LoteHasta)
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@PorPedido"
            parametro.Value = PorPedido
            listaParametros.Add(parametro)


            parametro = New SqlParameter
            parametro.ParameterName = "@PedidoSicy"
            parametro.Value = IIf(PedidoSicy = 0, DBNull.Value, PedidoSicy)
            listaParametros.Add(parametro)


            parametro = New SqlParameter
            parametro.ParameterName = "@PedidoSay"
            parametro.Value = IIf(PedidoSay = 0, DBNull.Value, PedidoSay)
            listaParametros.Add(parametro)


            parametro = New SqlParameter
            parametro.ParameterName = "@PorApartados"
            parametro.Value = PorApartados
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@CadenaApartados"
            parametro.Value = IIf(CadenaApartados = "", DBNull.Value, CadenaApartados)
            listaParametros.Add(parametro)


            Return objPersistencia.EjecutarConsultaSP("Programacion.SP_ImprimirEtiquetasOpcionesClientesPruebav2", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function ImprimirClientesProduccion(ByVal ImpresoraID As Integer,
                                               ByVal UsuarioID As Integer,
                                               ByVal ClienteID As Integer,
                                               ByVal tipoetiquetaid As Integer,
                                               ByVal MostrarDetalles As Boolean,
                                               ByVal PorLotes As Boolean,
                                               ByVal nave As Integer,
                                               ByVal FechaPrograma As Date,
                                               ByVal LoteDe As Integer,
                                               ByVal LoteHasta As Integer,
                                               ByVal PorPedido As Boolean,
                                               ByVal PedidoSicy As Integer,
                                               ByVal PedidoSay As Integer,
                                               ByVal PorApartados As Boolean,
                                               ByVal CadenaApartados As String)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro = New SqlParameter
            parametro.ParameterName = "@ImpresoraID"
            parametro.Value = ImpresoraID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@UsuarioID"
            parametro.Value = UsuarioID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@ClienteID"
            parametro.Value = ClienteID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@tipoetiquetaid"
            parametro.Value = tipoetiquetaid
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@MostrarDetalle"
            parametro.Value = MostrarDetalles
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@PorLotes"
            parametro.Value = PorLotes
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@nave"
            parametro.Value = IIf(nave = 0, DBNull.Value, nave)
            listaParametros.Add(parametro)


            parametro = New SqlParameter
            parametro.ParameterName = "@FechaPrograma"
            parametro.Value = FechaPrograma
            listaParametros.Add(parametro)


            parametro = New SqlParameter
            parametro.ParameterName = "@LoteDe"
            parametro.Value = IIf(LoteDe = 0, DBNull.Value, LoteDe)
            listaParametros.Add(parametro)


            parametro = New SqlParameter
            parametro.ParameterName = "@LoteHasta"
            parametro.Value = IIf(LoteHasta = 0, DBNull.Value, LoteHasta)
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@PorPedido"
            parametro.Value = PorPedido
            listaParametros.Add(parametro)


            parametro = New SqlParameter
            parametro.ParameterName = "@PedidoSicy"
            parametro.Value = IIf(PedidoSicy = 0, DBNull.Value, PedidoSicy)
            listaParametros.Add(parametro)


            parametro = New SqlParameter
            parametro.ParameterName = "@PedidoSay"
            parametro.Value = IIf(PedidoSay = 0, DBNull.Value, PedidoSay)
            listaParametros.Add(parametro)


            parametro = New SqlParameter
            parametro.ParameterName = "@PorApartados"
            parametro.Value = PorApartados
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@CadenaApartados"
            parametro.Value = IIf(CadenaApartados = "", DBNull.Value, CadenaApartados)
            listaParametros.Add(parametro)


            Return objPersistencia.EjecutarConsultaSP("Programacion.SP_ImprimirEtiquetasOpcionesClientesProduccionV2_PPrueba", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function ImprimirEtiquetaResumen(ByVal ClienteID As Integer,
                                            ByVal Cliente As String,
                                            ByVal TipoEtiquetaID As Integer,
                                            ByVal ImpresoraID As Int16,
                                            ByVal Imprimio As String,
                                            ByVal fImpresion As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Try

            parametro.ParameterName = "@ClienteID"
            parametro.Value = ClienteID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@Cliente"
            parametro.Value = Cliente
            listaParametros.Add(parametro)


            parametro = New SqlParameter
            parametro.ParameterName = "@TipoEtiquetaID"
            parametro.Value = TipoEtiquetaID
            listaParametros.Add(parametro)


            parametro = New SqlParameter
            parametro.ParameterName = "@ImpresoraID"
            parametro.Value = ImpresoraID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@Imprimio"
            parametro.Value = Imprimio
            listaParametros.Add(parametro)


            parametro = New SqlParameter
            parametro.ParameterName = "@fImpresion"
            parametro.Value = fImpresion
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("Programacion.SP_ImprimirEtiquetasOpcionesAvanzadasResumen", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ImprimirClientesPruebaDetalles(ByVal ImpresoraID As Integer,
                                             ByVal UsuarioID As Integer,
                                             ByVal tipoetiquetaid As Integer,
                                             ByVal CadenaPares As String,
                                             ByVal ClienteID As Integer)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro = New SqlParameter
            parametro.ParameterName = "@ImpresoraID"
            parametro.Value = ImpresoraID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@UsuarioID"
            parametro.Value = UsuarioID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@tipoetiquetaid"
            parametro.Value = tipoetiquetaid
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@CadenaPares"
            parametro.Value = CadenaPares
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@ClienteID"
            parametro.Value = ClienteID
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("Programacion.SP_ImprimirEtiquetasOpcionesClientesPruebaDetalles", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function ImprimirClientesProduccionDetalles(ByVal ImpresoraID As Integer,
                                            ByVal UsuarioID As Integer,
                                            ByVal tipoetiquetaid As Integer,
                                            ByVal CadenaPares As String,
                                            ByVal ClienteID As Integer)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro = New SqlParameter
            parametro.ParameterName = "@ImpresoraID"
            parametro.Value = ImpresoraID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@UsuarioID"
            parametro.Value = UsuarioID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@tipoetiquetaid"
            parametro.Value = tipoetiquetaid
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@CadenaPares"
            parametro.Value = CadenaPares
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@ClienteID"
            parametro.Value = ClienteID
            listaParametros.Add(parametro)

            'Return objPersistencia.EjecutarConsultaSP("Programacion.SP_ImprimirEtiquetasOpcionesClientesProduccionDetalles", listaParametros)
            Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_ImprimirEtiquetasOpcionesClientesProduccionDetalles_PPrueba]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function ConsultarModelosGranel(ByVal ModeloSAY As String)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Try
            parametro.ParameterName = "@ModeloSAY"
            parametro.Value = ModeloSAY
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("Programacion.SP_ImprimirEtiquetasOpcionesAvanzadasModelos", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function InsertarLoteGranel(ByVal Lote As Integer, ByVal PielColor As String, ByVal CodigoSicy As String, ByVal tallaSicy As String)
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


            Return objPersistencia.EjecutarConsultaSP("Programacion.SP_ImprimirEtiquetasOpcionesAvanzadasInsertarLoteGranel", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try

    End Function


    Public Function InsertarLoteDocenaGranel(ByVal LoteDocena As Integer, ByVal Lote As Integer, ByVal año As Integer, ByVal NoDocena As Integer, ByVal NoPares As Integer)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Try
            parametro.ParameterName = "@LoteDocena"
            parametro.Value = LoteDocena
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@Lote"
            parametro.Value = Lote
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@año"
            parametro.Value = año
            listaParametros.Add(parametro)


            parametro = New SqlParameter
            parametro.ParameterName = "@NoDocena"
            parametro.Value = NoDocena
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@NoPares"
            parametro.Value = NoPares
            listaParametros.Add(parametro)


            Return objPersistencia.EjecutarConsultaSP("Programacion.SP_ImprimirEtiquetasOpcionesAvanzadasInsertarLoteDocenaGranel", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function InsertarDocenaParGranel(ByVal idDocena As String, ByVal idPar As String, ByVal talla As String, ByVal loteGranel As Integer, ByVal Codigo As String, ByVal tallaSicy As String)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Try

            parametro.ParameterName = "@idDocena"
            parametro.Value = idDocena
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@idPar"
            parametro.Value = idPar
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@talla"
            parametro.Value = talla
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@LoteGranel"
            parametro.Value = loteGranel
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@LoteGranel"
            parametro.Value = loteGranel
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@año"
            parametro.Value = loteGranel
            listaParametros.Add(parametro)


            parametro = New SqlParameter
            parametro.ParameterName = "@Codigo"
            parametro.Value = Codigo
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@idTallaSicy"
            parametro.Value = tallaSicy
            listaParametros.Add(parametro)


            Return objPersistencia.EjecutarConsultaSP("Programacion.SP_ImprimirEtiquetasOpcionesAvanzadasInsertarDocenaParesGranel", listaParametros)
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


    Public Function ColocarNumeracion(ByVal talla As String, Optional ByVal Especial As Boolean = False)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Try
            parametro.ParameterName = "@p_tallaid"
            parametro.Value = talla
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@Especial"
            parametro.Value = Especial
            listaParametros.Add(parametro)


            Return objPersistencia.EjecutarConsultaSP("Programacion.SP_ImprimirEtiquetasOpcionesAvanzadasTallas", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
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

            Return objPersistencia.EjecutarConsultaSP("Programacion.SP_ImprimirEtiquetasOpcionesAvanzadasGranelBuscarLoteDocena", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function ReingresosGranelInsertaDocenasNormales(ByVal NumDocenas As Integer,
                                                           ByVal Nave As Integer,
                                                           ByVal Lote As Integer,
                                                           ByVal idTallaSicy As String,
                                                           ByVal idCodigoSICY As String,
                                                           ByVal idDocena As Integer
                                                           )
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Try
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


            Return objPersistencia.EjecutarConsultaSP("Almacen.Reingresos_Granel_InsertaDocenasNormales", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ImprimirGranel(ByVal Lote As Integer,
                                    ByVal NoDocena As Integer,
                                    ByVal Nave As Integer,
                                    ByVal Año As Integer,
                                    ByVal ImpresoraId As Integer,
                                    ByVal UsuarioId As Integer,
                                    ByVal FechaPrograma As Date
                                   ) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@p_lote"
            parametro.Value = Lote
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@No_Docena"
            parametro.Value = NoDocena
            listaParametros.Add(parametro)


            parametro = New SqlParameter
            parametro.ParameterName = "@nave"
            parametro.Value = Nave
            listaParametros.Add(parametro)


            parametro = New SqlParameter
            parametro.ParameterName = "@anio"
            parametro.Value = Año
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@ImpresoraID"
            parametro.Value = ImpresoraId
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@UsuarioID"
            parametro.Value = UsuarioId
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@FechaPrograma"
            parametro.Value = FechaPrograma
            listaParametros.Add(parametro)


            Return objPersistencia.EjecutarConsultaSP("Programacion.SP_ImprimirEtiquetasGranel", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region


    Public Sub ActualizarModeloSiluetaSICY(ByVal Modelo As Entidades.ModeloTallas)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro = New SqlParameter
            parametro.ParameterName = "@IdLinea"
            parametro.Value = Modelo.IdLinea
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@IdTalla"
            parametro.Value = Modelo.IdTalla
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@IdModelo"
            parametro.Value = Modelo.IdModelo
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@ArchivoZebra"
            parametro.Value = Modelo.ArchivoZebra
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@RutaSilueta203"
            parametro.Value = Modelo.RutaSilueta203
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@RutaSilueta300"
            parametro.Value = Modelo.RutaSilueta300
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@ArchivoZebra300"
            parametro.Value = Modelo.ArchivoZebra300
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@RutaCompletaSiluetajpg"
            parametro.Value = Modelo.RutaCompletaJPG
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@UsuarioModificoId"
            parametro.Value = Modelo.UsuarioModifico
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@RutaRelativa"
            parametro.Value = Modelo.SiluetaZebra
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@ArchivoZebraCN203"
            parametro.Value = Modelo.ArchivoZebraCN203
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@ArchivoZebraCN300"
            parametro.Value = Modelo.ArchivoZebraCN300
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@ArchivoZebraCA203"
            parametro.Value = Modelo.ArchivoZebraCA203
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@ArchivoZebraCA300"
            parametro.Value = Modelo.ArchivoZebraCA300
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@RutaSiluetaCN203"
            parametro.Value = Modelo.RutaSiluetaCN203
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@RutaSiluetaCN300"
            parametro.Value = Modelo.RutaSiluetaCN300
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@RutaSiluetaCA203"
            parametro.Value = Modelo.RutaSiluetaCA203
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@RutaSiluetaCA300"
            parametro.Value = Modelo.RutaSiluetaCA300
            listaParametros.Add(parametro)

            objPersistencia.EjecutarConsultaSP("[Programacion].[SP_Actualiza_ModeloSilueta]", listaParametros)
            'objPersistencia.EjecutarConsultaSP("[Programacion].[SP_Actualiza_ModeloSilueta_PPrueba]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function ConsultarImpresionLotesPorPrograma(ByVal NaveSICYID As Integer, ByVal FechaPrograma As Date) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "Nave"
        parametro.Value = NaveSICYID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FechaPrograma"
        parametro.Value = FechaPrograma
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_Etiquetas_ConsultarLotesImpresion_V2]", listaParametros)
    End Function

    Public Function AltaEtiquetaPorAutorizar(ByVal Etiqueta As Entidades.ConfiguracionEtiqueta, ByVal accion As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try

            parametro = New SqlParameter
            parametro.ParameterName = "@ACCION"
            parametro.Value = accion
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@etiq_etiquetaid"
            parametro.Value = Etiqueta.EtiquetaId
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@etiq_clave"
            parametro.Value = Etiqueta.EtiquetaClave
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@etiq_tipoetiquetaid"
            parametro.Value = Etiqueta.TipoEtiquetaId
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@etiq_nombre"
            parametro.Value = Etiqueta.EtiquetaNombre
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@etiq_descripcion"
            parametro.Value = Etiqueta.EtiquetaDescripcion
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@etiq_codigozpl"
            parametro.Value = Etiqueta.CodigoZPL
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@etiq_ancho"
            parametro.Value = Etiqueta.EtiquetaAncho
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@etiq_alto"
            parametro.Value = Etiqueta.EtiquetaAlto
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@etiq_orientacion"
            parametro.Value = Etiqueta.EtiquetaOrientacion
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@etiq_usuariocreoid"
            parametro.Value = Etiqueta.EtiquetaUsuarioCreoId
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@etiq_fechacreacion"
            parametro.Value = Nothing
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@etiq_usuariomodificoid"
            parametro.Value = Etiqueta.UsuarioModificoId
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@etiq_fechamodificacion"
            parametro.Value = Nothing
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@etiq_clienteid"
            parametro.Value = Etiqueta.ClienteId
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@etiq_etiquetayuyin"
            parametro.Value = Etiqueta.EtiquetaYuyin
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@etiq_codigozpl300"
            parametro.Value = Etiqueta.EtiquetaCodigoZPL300
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@etiq_activa"
            parametro.Value = Etiqueta.EtiquetaActiva
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@etiq_vistaprevia"
            parametro.Value = Etiqueta.EtiquetaVistaPrevia
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@etiq_impresionesalpaso"
            parametro.Value = Etiqueta.EtiquetaImpresionesAlPaso
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@etiq_rutalbl"
            parametro.Value = Etiqueta.RutaLBL
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@etiq_ColeccionID"
            parametro.Value = Etiqueta.ColeccionID
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_Etiquetas_AltaDiseñoEtiqueta_v2]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try

    End Function


    Public Function ConsultarEtiquetasPorAutorizar(ByVal idEtiqueta As Integer) As DataTable

        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro = New SqlParameter
            parametro.ParameterName = "@EtiquetaID"
            parametro.Value = idEtiqueta
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_Etiquetas_ConsultaEtiqueta_PorAutorizar]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try


    End Function

    Public Function AutorizarEtiqueta(ByVal idEtiqueta As Integer, ByVal UsuarioID As Integer) As DataTable

        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro = New SqlParameter
            parametro.ParameterName = "@EtiquetaAutorizadaID"
            parametro.Value = idEtiqueta
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@UsuarioAutorizo"
            parametro.Value = UsuarioID
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_Etiquetas_InsertarEtiquetaAutorizada]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try

    End Function
    Public Sub InactivarEtiquetaLengua(ByVal idEtiqueta As Integer, ByVal TipoEtiqueta As Integer)

        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro = New SqlParameter
            parametro.ParameterName = "@EtiquetaID"
            parametro.Value = idEtiqueta
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@TipoEtiqueta"
            parametro.Value = TipoEtiqueta
            listaParametros.Add(parametro)

            objPersistencia.EjecutarConsultaSP("[Programacion].[SP_Etiquetas_InactivarEtiquetas]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try

    End Sub
    Public Sub RechazarEtiqueta(ByVal idEtiqueta As Integer, ByVal UsuarioID As Integer)

        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro = New SqlParameter
            parametro.ParameterName = "@EtiquetaId"
            parametro.Value = idEtiqueta
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@UsuarioID"
            parametro.Value = UsuarioID
            listaParametros.Add(parametro)

            objPersistencia.EjecutarConsultaSP("[Programacion].[SP_Etiquetas_RechazarEtiqueta]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Function ConsultarInformacionEtiquetaPorAutorizar(ByVal idEtiqueta As Integer) As DataTable

        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro = New SqlParameter
            parametro.ParameterName = "@EtiquetaID"
            parametro.Value = idEtiqueta
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_Etiquetas_ConsultaEtiquetaPorAutorizar_ConColeccion]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try


    End Function

    Public Function ValidarEtiquetaPorAutorizar(ByVal ClienteID As Integer, ByVal TipoEtiquetaID As Integer, ByVal ColeccionId As Integer) As DataTable

        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro = New SqlParameter
            parametro.ParameterName = "@ClienteID"
            parametro.Value = ClienteID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@TipoEtiquetaID"
            parametro.Value = TipoEtiquetaID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@ColeccionID"
            parametro.Value = ColeccionId
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_Etiquetas_ValidarExisteEtiquetaPorAutorizar]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function ConsultarNavesProduccion() As DataTable

        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_Etiquetas_ConsultarNavesProduccion]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function ConsultarRutaLBLOpciones() As DataTable

        Dim objPersistencia As New Persistencia.OperacionesProcedimientos

        Dim consultaSQL As String = " SELECT opci_valor_cadena FROM Programacion.Opciones " +
             " WHERE opci_tipoopcion = 'ETIQUETAS' AND opci_descripcion = 'Ruta modelo imagen lbl' "
        Try
            Return objPersistencia.EjecutaConsulta(consultaSQL)
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Sub AsignarEquípoPorDefecto(ByVal NombreEquipo As String, ByVal IdImpresora As Integer)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro = New SqlParameter
            parametro.ParameterName = "@NombreEquipo"
            parametro.Value = NombreEquipo
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@IdImpresora"
            parametro.Value = IdImpresora
            listaParametros.Add(parametro)

            objPersistencia.EjecutarConsultaSP("[Programacion].[SP_Asigna_ImpresoraDefaultEquipo]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try

    End Sub


    Public Function ConsultarClientesTallasExtranjeras() As DataTable
        Dim persistencias As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Try
            Return persistencias.EjecutarConsultaSP("[Programacion].[Sp_AdministradorTallasExtranjeras_ConsultarClientes]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ConsultarTallasExtranjeras(ClienteID As Integer) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Try

            parametro = New SqlParameter
            parametro.ParameterName = "@ClienteID"
            parametro.Value = ClienteID
            listaParametros.Add(parametro)
            Return persistencia.EjecutarConsultaSP("[Programacion].[SP_AdministradorTallasExtranjeras_ConsultarTallasExtranjeras]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function ConsultarPerimisoAgente(UsuarioID As Integer, ClienteID As Integer) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Try
            parametro = New SqlParameter
            parametro.ParameterName = "@ClienteID"
            parametro.Value = ClienteID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@UsuarioID"
            parametro.Value = UsuarioID
            listaParametros.Add(parametro)

            Return persistencia.EjecutarConsultaSP("[Programacion].[SP_AdministradorTallasExtranjeras_ConsultarUsuarioAgente]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub GuardarTallaExtranjeraClienteDetalle(TallasExtranjeras As Entidades.TallasExtranjerasClienteDetalle, UsuarioCreoID As Integer)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Try
            parametro = New SqlParameter
            parametro.ParameterName = "@taee_clienteid"
            parametro.Value = TallasExtranjeras.Cliente
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@taee_tallaid"
            parametro.Value = TallasExtranjeras.TallaID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@taee_familiaid"
            parametro.Value = TallasExtranjeras.FamiliaID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@taee_paisidtallaextranjera"
            parametro.Value = TallasExtranjeras.Pais
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@taee_talla_mexicana"
            parametro.Value = TallasExtranjeras.TallaMexicana
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@taee_talla_extranjera"
            parametro.Value = TallasExtranjeras.TallaExtranjera
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@taee_activo"
            parametro.Value = True
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@taee_usuariocreoid"
            parametro.Value = UsuarioCreoID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@taee_usuariomodificoid"
            parametro.Value = UsuarioCreoID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@Pais_Abreviatura"
            parametro.Value = TallasExtranjeras.PaisAbreviatura
            listaParametros.Add(parametro)

            objPersistencia.EjecutarConsultaSP("[Programacion].[SP_AdministradorTallasExtranjeras_InsertarTallasExtranjerasClienteDetalle]", listaParametros)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function ConsultarPerfilUsuario(UsuarioID) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Try
            parametro = New SqlParameter
            parametro.ParameterName = "@UsuarioID"
            parametro.Value = UsuarioID
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_AdministradorTallasExtranjeras_ConsultarPerfilUsuario]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ConsultarClientesDestinoCopiarTallas(ClienteOrigenID As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Try
            parametro = New SqlParameter
            parametro.ParameterName = "@ClienteOrigenID"
            parametro.Value = ClienteOrigenID
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Programacion].[Sp_AdministradorTallasExtranjeras_ConsultarClientesDestino]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function ConsultarClientesDestinoCopiarTallasAgente(ClienteOrigenID As Integer, UsuarioID As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Try
            parametro = New SqlParameter
            parametro.ParameterName = "@ClienteOrigenID"
            parametro.Value = ClienteOrigenID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@UsuarioID"
            parametro.Value = UsuarioID
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Programacion].[Sp_AdministradorTallasExtranjeras_ConsultarClientesDestinoAgentesDeVentas]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function ConsultarPaisesCorridasXCliente(ClienteID As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro = New SqlParameter
            parametro.ParameterName = "@ClienteID"
            parametro.Value = ClienteID
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_AdministradosTallasExtranjeras_ConsultarPaisesXCliente]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function ConsultarConfiguracionGeneralCorridasExtranjeras(ByVal Licencia As Integer) As DataTable
        Dim objPers As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            If Licencia = 1 Then
                Return objPers.EjecutarConsultaSP("[Programacion].[SP_AdministradorTallasExtranjeras_ConsultarConfiguracionLicencia]", listaParametros)
            Else
                Return objPers.EjecutarConsultaSP("[Programacion].[SP_AdministradorTallasExtranjeras_ConsultarConfiguracionGeneral]", listaParametros)
            End If

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Sub GuardarConfiguracionGeneral(ByVal ConfGeneral As TallasExtranjerasClienteDetalle, UsuarioID As Integer)
        Dim objPers As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try

            parametro = New SqlParameter
            parametro.ParameterName = "@taeg_tallaid"
            parametro.Value = ConfGeneral.TallaID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@taeg_paisid_tallaextranjera"
            parametro.Value = ConfGeneral.Pais
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@taeg_tallamexicana"
            parametro.Value = ConfGeneral.TallaMexicana
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@taeg_tallaextranjera"
            parametro.Value = ConfGeneral.TallaExtranjera
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@taeg_activo"
            parametro.Value = ConfGeneral.Activo
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@taeg_usuariocreoid"
            parametro.Value = UsuarioID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@taeg_usuariomodificoid"
            parametro.Value = UsuarioID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@Pais_Abreviatura"
            parametro.Value = ConfGeneral.PaisAbreviatura
            listaParametros.Add(parametro)

            objPers.EjecutarConsultaSP("[Programacion].[SP_AdministracionTallasExtranjeras_InsertarConfiguracionGeneral]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Public Function CoosultaCodigoRapidoCoppel(ByVal codigorapido As String, ByVal TallaIni As String, ByVal TallaFin As String) As DataTable ', ByVal Talla As String
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro = New SqlParameter
            parametro.ParameterName = "@codrapido"
            parametro.Value = codigorapido
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@tallaini"
            parametro.Value = TallaIni
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@tallafin"
            parametro.Value = TallaFin
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_Etiquetas_ConsultaEstiloPielColorColppel]", listaParametros)

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function ConsultarImpresoraEquipo(ByVal NombreEquipo As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro = New SqlParameter
            parametro.ParameterName = "@NombreEquipo"
            parametro.Value = NombreEquipo
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_Etiquetas_ConsultaImpresoraDefaultEquipo]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try

    End Function


    Public Function ValidaInformacionImpresionLote(ByVal Lotes As String, ByVal Año As Integer, ByVal NaveSICYID As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro = New SqlParameter
            parametro.ParameterName = "@Lotes"
            parametro.Value = Lotes
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@Año"
            parametro.Value = Año
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@NaveSICY"
            parametro.Value = NaveSICYID
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_Etiquetas_ValidarInformacion]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function ComandosImprimirEtiquetasSAY_V2(ByVal Lotes As String, ByVal Nave As Integer, ByVal Año As Int32, ByVal ImpresoraId As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "lotes"
        parametro.Value = Lotes
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "nave"
        parametro.Value = Nave
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "anio"
        parametro.Value = Año
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ImpresoraSAYID"
        parametro.Value = ImpresoraId
        listaParametros.Add(parametro)

        'Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_ComandosImprimirEtiqueta_v2]", listaParametros)
        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_ComandosImprimirEtiqueta_v2_PPrueba]", listaParametros)
    End Function

    Public Function ComandosImprimirEtiquetasSAY_Lotes(ByVal LoteDe As Integer, ByVal LoteHasta As Integer, ByVal Nave As Integer, ByVal Año As Int32, ByVal ImpresoraId As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@LoteDe"
        parametro.Value = LoteDe
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@LoteHasta"
        parametro.Value = LoteHasta
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "nave"
        parametro.Value = Nave
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "anio"
        parametro.Value = Año
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ImpresoraSAYID"
        parametro.Value = ImpresoraId
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_ComandosImprimirEtiqueta_Lotes]", listaParametros)
        'Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_ComandosImprimirEtiqueta_Lotes_PPrueba]", listaParametros)
    End Function

    Public Function ComandosImprimirEtiquetasSAY_Lotes_Devolucion(ByVal FolioDev As Integer, ByVal LoteDe As Integer, ByVal LoteHasta As Integer, ByVal Nave As Integer, ByVal Año As Int32, ByVal ImpresoraId As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)

        listaParametros.Add(New SqlParameter With {
            .ParameterName = "@FolioDev",
            .Value = FolioDev
        })

        listaParametros.Add(New SqlParameter With {
            .ParameterName = "@LoteDe",
            .Value = LoteDe
        })

        listaParametros.Add(New SqlParameter With {
            .ParameterName = "@LoteHasta",
            .Value = LoteHasta
        })

        listaParametros.Add(New SqlParameter With {
            .ParameterName = "@nave",
            .Value = Nave
        })

        listaParametros.Add(New SqlParameter With {
            .ParameterName = "@anio",
            .Value = Año
        })

        listaParametros.Add(New SqlParameter With {
            .ParameterName = "@ImpresoraSAYID",
            .Value = ImpresoraId
        })

        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_ComandosImprimirEtiqueta_Lotes_Devolucion]", listaParametros)
    End Function

    Public Function ConsultaDetallesImpresion(ByVal Lotes As String, ByVal Nave As Integer, ByVal Año As Int32, ByVal FechaPrograma As Date, ByVal ImpresoraId As Integer, ByVal EtiquetaId As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@lotes"
        parametro.Value = Lotes
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@nave"
        parametro.Value = Nave
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@anio"
        parametro.Value = Año
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FechaPrograma"
        parametro.Value = FechaPrograma
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@ImpresoraID"
        parametro.Value = ImpresoraId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@EtiquetaId"
        parametro.Value = EtiquetaId
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_Etiquetas_DetallesImpresion]", listaParametros)
    End Function



    Public Function ConsultarParametrosEtiqueta(ByVal EtiquetaId As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@EtiquetaID"
            parametro.Value = EtiquetaId
            listaParametros.Add(parametro)
            Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_Etiquetas_ConsultaParametros_Varios]", listaParametros)

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ValidarZplCargado(ByVal Lotes As String, ByVal Año As Integer, ByVal NaveSICYID As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@Lotes"
            parametro.Value = Lotes
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@Año"
            parametro.Value = Año
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@NaveSICY"
            parametro.Value = NaveSICYID
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_Etiquetas_ValidarZPLCapturado]", listaParametros)

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ConsultaLotes(ByVal LoteInicio As String, ByVal LoteFin As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@LoteInicio"
            parametro.Value = LoteInicio
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@LoteFin"
            parametro.Value = LoteFin
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_Etiquetas_Batta]", listaParametros)

        Catch ex As Exception
            Throw ex
        End Try

    End Function


    Public Function ConsultaEtiquetasDiferenteTamaño(ByVal Lotes As String, ByVal NaveSICYID As Integer, ByVal Año As Integer, ByVal FechaPrograma As Date) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@lotes"
            parametro.Value = Lotes
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@nave"
            parametro.Value = NaveSICYID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@anio"
            parametro.Value = Año
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@FechaPrograma"
            parametro.Value = FechaPrograma
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_Etiquetas_EtiquetasDiferenteTamaño]", listaParametros)

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    ''' <summary>
    ''' Consulta las etiquetas de Lengua
    ''' </summary>
    ''' <param name="StatusID">'' => Todos los status</param>
    ''' <returns>DataTable con los datos de laas etiquetas de LENGUA</returns>
    ''' <remarks></remarks>
    Public Function ConsultaEtiquetasLengua(ByVal StatusID As String, ByVal etiquetasConDiseño As Boolean) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Try
            parametro = New SqlParameter
            parametro.ParameterName = "@StatusId"
            parametro.Value = StatusID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@EtiquetasConDiseño"
            parametro.Value = etiquetasConDiseño
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_Etiquetas_ConsultarEtiquetasLengua]", listaParametros)
        Catch ex As Exception
        End Try
    End Function

    Public Function ValidarEtiquetasYUYIN(ByVal Lotes As String, ByVal Año As Integer, ByVal NaveSICYID As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Try
            parametro = New SqlParameter
            parametro.ParameterName = "@Lotes"
            parametro.Value = Lotes
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@Año"
            parametro.Value = Año
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@NaveSICY"
            parametro.Value = NaveSICYID
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_Etiquetas_ValidarEtiquetasYuyin]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ImpresionEtiquetasLengua(ByVal LoteInicio As String, ByVal LoteFin As String, ByVal NaveSICYID As Integer, ByVal Año As Integer, ByVal ImpresoraID As Integer, ByVal UsuarioId As Integer, ByVal FechaPrograma As Date, TipoImpresion As Integer, ByVal ColeccionID As Integer, ByVal Amarres As String, Optional ByVal MostrarDetalles As Boolean = False, Optional ByVal ClienteSAY As Integer = 0) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Try
            parametro = New SqlParameter
            parametro.ParameterName = "@LoteInicio"
            parametro.Value = LoteInicio
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@LoteFin"
            parametro.Value = LoteFin
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@nave"
            parametro.Value = NaveSICYID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@anio"
            parametro.Value = Año
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@ImpresoraID"
            parametro.Value = ImpresoraID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@UsuarioID"
            parametro.Value = UsuarioId
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@FechaPrograma"
            parametro.Value = FechaPrograma
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@TipoImpresion"
            parametro.Value = TipoImpresion
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@ColeccionID"
            parametro.Value = ColeccionID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@Amarres"
            parametro.Value = Amarres
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@MostrarDetalle"
            parametro.Value = MostrarDetalles
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@ClienteSay_ID"
            parametro.Value = ClienteSAY
            listaParametros.Add(parametro)


            'Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_Etiquetas_ImpresionEtiquetasLengua_2]", listaParametros)
            'Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_Etiquetas_ImpresionEtiquetasLengua_3]", listaParametros)
            Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_Etiquetas_ImpresionEtiquetasLengua_FamiliaColeccion]", listaParametros)
            'Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_Etiquetas_ImpresionEtiquetasLengua_FamiliaColeccion_Discovery]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Consulta las colecciones que se imprimen para las etiquetas de Lengua
    ''' </summary>
    ''' <returns>DataTable con la informacion de las colecciones.</returns>
    ''' <remarks></remarks>
    Public Function ConsultaColeccionesLengua(ByVal ClienteID As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Try
            parametro = New SqlParameter
            parametro.ParameterName = "@ClienteID"
            parametro.Value = ClienteID
            listaParametros.Add(parametro)
            Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_Etiquetas_ConsultaColeccionesLengua_v2]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Consulta los pares a imprimir de Lengua
    ''' </summary>
    ''' <param name="LoteInicio">Lote Inicio</param>
    ''' <param name="LoteFin">Lote Fin</param>
    ''' <param name="Amarre">Numeros de amarre</param>
    ''' <param name="NaveSICYId">El identificador de la Nave SICY ID</param>
    ''' <param name="Año">Es el año del programa</param>
    ''' <returns>DataTable con la informacion de los pares a imprimir</returns>
    ''' <remarks></remarks>
    Public Function ConsultaParesLengua(ByVal LoteInicio As String, ByVal LoteFin As String, ByVal Amarre As String, ByVal NaveSICYId As Integer, ByVal Año As Integer, ByVal ColeccionID As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Try
            parametro = New SqlParameter
            parametro.ParameterName = "@LoteInicio"
            parametro.Value = LoteInicio
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@LoteFin"
            parametro.Value = LoteFin
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@Amarres"
            parametro.Value = Amarre
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@nave"
            parametro.Value = NaveSICYId
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@anio"
            parametro.Value = Año
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@ColeccionID"
            parametro.Value = ColeccionID
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_Etiquetas_ConsultaParesLengua]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Inserta los parametros de la etiqueta Por Autorizar
    ''' </summary>
    ''' <param name="EtiquetaID">Identificador de la etiqueta</param>
    ''' <param name="ParametroID">Parametro de la etiqueta</param>
    ''' <param name="Resolucion">Resolucion de la etiqueta</param>
    ''' <remarks></remarks>
    Public Function InsertarParametroEtiquetaPorAutorizar(ByVal EtiquetaID As Integer, ByVal ParametroID As Integer, ByVal Resolucion As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@EtiquetaID"
            parametro.Value = EtiquetaID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@ParametroID"
            parametro.Value = ParametroID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@Resolucion"
            parametro.Value = Resolucion
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_Etiquetas_InsertarParametros_Autorizar]", listaParametros)

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Generacion de impresion de etiquetas de Lengua por Par
    ''' </summary>
    ''' <param name="Lotes">Lotes a imprimir</param>
    ''' <param name="NaveSICYID">Identificador de la nave SICY</param>
    ''' <param name="Año">Año del porgrama</param>
    ''' <param name="ParesImpresion">Codigos de par a imprimir</param>
    ''' <param name="ImpresoraID">Identificador de la impresora</param>
    ''' <param name="UsuarioID">Identidicador del usuario a imprimir</param>
    ''' <param name="FechaPrograma">Fecha del programa.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ImpresionEtiquetasPorParLengua(ByVal Lotes As String, ByVal NaveSICYID As Integer, ByVal Año As Integer, ByVal ParesImpresion As String, ByVal ImpresoraID As Integer, ByVal UsuarioID As Integer, ByVal FechaPrograma As Date, ByVal ColeccionID As Integer, Optional ByVal MostrarDetalles As Boolean = False, Optional ByVal ClienteSAY As Integer = 0, Optional ByVal TipoImpresion As Integer = 0) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@lotes"
            parametro.Value = Lotes
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@nave"
            parametro.Value = NaveSICYID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@anio"
            parametro.Value = Año
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@ParesImpresion"
            parametro.Value = ParesImpresion
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@ImpresoraID"
            parametro.Value = ImpresoraID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@UsuarioID"
            parametro.Value = UsuarioID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@FechaPrograma"
            parametro.Value = FechaPrograma
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@ColeccionID"
            parametro.Value = ColeccionID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@MostrarDetalle"
            parametro.Value = MostrarDetalles
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@ClienteSAY_ID"
            parametro.Value = ClienteSAY
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@TipoImpresion"
            parametro.Value = TipoImpresion
            listaParametros.Add(parametro)

            'Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_Etiquetas_ImprimirEtiquetasParLengua_4]", listaParametros)
            Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_Etiquetas_ImprimirEtiquetasParLengua_4FamiliaColeccion]", listaParametros)
            'Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_Etiquetas_ImprimirEtiquetasParLengua_4FamiliaColeccion_Discovery]", listaParametros)

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Valida que exista la etiqueta de Lengua Yuyin
    ''' </summary>
    ''' <returns>DataTable si existe o no la etiqueta</returns>
    ''' <remarks></remarks>
    Public Function ValidarExisteEtiquetaLenguaYuyin() As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Try
            Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_Etiquetas_ValidarExisteEtiquetaLenguaYuyin]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ValidarExisteEtiquetaLenguaColeccion(ByVal ColeccionID As Integer, ByVal EsEtiquetaPrueba As Boolean) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Try
            parametro = New SqlParameter
            parametro.ParameterName = "@ColeccionID"
            parametro.Value = ColeccionID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@EsEtiquetaPrueba"
            parametro.Value = EsEtiquetaPrueba
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_Etiquetas_ValidarExisteEtiquetaLenguaColeccion]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Consulta los clientes que requieren etiqueta de rastreo
    ''' </summary>
    ''' <returns>DataTable con los clientes que requieren etiqueta rastreo</returns>
    ''' <remarks></remarks>
    Public Function ConsultarClientesRastreo() As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Try
            Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_Etiquetas_ConsultaClientesRastreo]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ImpresionEtiquetasRastreo(ByVal LoteInicio As Integer, ByVal LoteFin As Integer, ByVal AmarreInicio As String, ByVal AmarreFin As String, ByVal NaveSICYID As Integer, ByVal AñoPrograma As Integer, ByVal ImpresoraId As Integer, UsuarioId As Integer, ByVal FechaPrograma As Date, ByVal ClienteSICYID As Integer, Optional ByVal MostrarDetalles As Boolean = False) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Try
            parametro = New SqlParameter
            parametro.ParameterName = "@LoteInicio"
            parametro.Value = LoteInicio
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@LoteFin"
            parametro.Value = LoteFin
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@AmarreInicio"
            parametro.Value = AmarreInicio
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@AmarreFin"
            parametro.Value = AmarreFin
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@nave"
            parametro.Value = NaveSICYID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@anio"
            parametro.Value = AñoPrograma
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@ImpresoraID"
            parametro.Value = ImpresoraId
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@UsuarioID"
            parametro.Value = UsuarioId
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@FechaPrograma"
            parametro.Value = FechaPrograma
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@ClienteSICYId"
            parametro.Value = ClienteSICYID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@MostrarDetalle"
            parametro.Value = MostrarDetalles
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_Etiquetas_ImpresionEtiquetasRastreo]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ConsultarParesImprimirRastreo(ByVal LoteInicio As Integer, ByVal LoteFin As Integer, ByVal AmarreInicio As String, ByVal AmarreFin As String, ByVal NaveSICYID As Integer, ByVal AñoPrograma As Integer, ByVal FechaPrograma As Date, ByVal ClienteSICYID As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Try
            parametro = New SqlParameter
            parametro.ParameterName = "@LoteInicio"
            parametro.Value = LoteInicio
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@LoteFin"
            parametro.Value = LoteFin
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@AmarreInicio"
            parametro.Value = AmarreInicio
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@AmarreFin"
            parametro.Value = AmarreFin
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@nave"
            parametro.Value = NaveSICYID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@anio"
            parametro.Value = AñoPrograma
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@FechaPrograma"
            parametro.Value = FechaPrograma
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@ClienteSICYID"
            parametro.Value = ClienteSICYID
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_Etiquetas_ConsultaParesRastreo]", listaParametros)

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ImpresionParesRastreo(ByVal Pares As String, ByVal NaveSICYID As Integer, ByVal AñoPrograma As Integer, ByVal ImpresoraId As Integer, ByVal UsuarioID As Integer, ByVal FechaPrograma As Date, ByVal ClienteSICYID As Integer, Optional ByVal MostrarDetalles As Boolean = False) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Try
            parametro = New SqlParameter
            parametro.ParameterName = "@ParesImpresion"
            parametro.Value = Pares
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@nave"
            parametro.Value = NaveSICYID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@anio"
            parametro.Value = AñoPrograma
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@ImpresoraID"
            parametro.Value = ImpresoraId
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@UsuarioID"
            parametro.Value = UsuarioID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@FechaPrograma"
            parametro.Value = FechaPrograma
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@ClienteSICYId"
            parametro.Value = ClienteSICYID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@MostrarDetalle"
            parametro.Value = MostrarDetalles
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_Etiquetas_ImpresionEtiquetasParesRastreo]", listaParametros)

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ImpresionEtiquetasRastreoPrueba(ByVal LoteInicio As Integer, ByVal LoteFin As Integer, ByVal AmarreInicio As String, ByVal AmarreFin As String, ByVal NaveSICYID As Integer, ByVal AñoPrograma As Integer, ByVal ImpresoraId As Integer, UsuarioId As Integer, ByVal FechaPrograma As Date, ByVal ClienteSICYID As Integer, Optional ByVal MostrarDetalles As Boolean = False) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Try
            parametro = New SqlParameter
            parametro.ParameterName = "@LoteInicio"
            parametro.Value = LoteInicio
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@LoteFin"
            parametro.Value = LoteFin
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@AmarreInicio"
            parametro.Value = AmarreInicio
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@AmarreFin"
            parametro.Value = AmarreFin
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@nave"
            parametro.Value = NaveSICYID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@anio"
            parametro.Value = AñoPrograma
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@ImpresoraID"
            parametro.Value = ImpresoraId
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@UsuarioID"
            parametro.Value = UsuarioId
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@FechaPrograma"
            parametro.Value = FechaPrograma
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@ClienteSICYId"
            parametro.Value = ClienteSICYID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@MostrarDetalle"
            parametro.Value = MostrarDetalles
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_Etiquetas_ImpresionEtiquetasRastreo_ImpresionPrueba]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ImpresionParesRastreoPruebas(ByVal Pares As String, ByVal NaveSICYID As Integer, ByVal AñoPrograma As Integer, ByVal ImpresoraId As Integer, ByVal UsuarioID As Integer, ByVal FechaPrograma As Date, ByVal ClienteSICYID As Integer, Optional ByVal MostrarDetalles As Boolean = False) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Try
            parametro = New SqlParameter
            parametro.ParameterName = "@ParesImpresion"
            parametro.Value = Pares
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@nave"
            parametro.Value = NaveSICYID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@anio"
            parametro.Value = AñoPrograma
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@ImpresoraID"
            parametro.Value = ImpresoraId
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@UsuarioID"
            parametro.Value = UsuarioID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@FechaPrograma"
            parametro.Value = FechaPrograma
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@ClienteSICYId"
            parametro.Value = ClienteSICYID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@MostrarDetalle"
            parametro.Value = MostrarDetalles
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_Etiquetas_ImpresionEtiquetasParesRastreo_ImpresionPrueba]", listaParametros)

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ImpresionEtiquetasLenguaPrueba(ByVal LoteInicio As String, ByVal LoteFin As String, ByVal NaveSICYID As Integer, ByVal Año As Integer, ByVal ImpresoraID As Integer, ByVal UsuarioId As Integer, ByVal FechaPrograma As Date, TipoImpresion As Integer, ByVal ColeccionID As Integer, ByVal Amarres As String, Optional ByVal MostrarDetalles As Boolean = False) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Try
            parametro = New SqlParameter
            parametro.ParameterName = "@LoteInicio"
            parametro.Value = LoteInicio
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@LoteFin"
            parametro.Value = LoteFin
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@nave"
            parametro.Value = NaveSICYID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@anio"
            parametro.Value = Año
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@ImpresoraID"
            parametro.Value = ImpresoraID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@UsuarioID"
            parametro.Value = UsuarioId
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@FechaPrograma"
            parametro.Value = FechaPrograma
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@TipoImpresion"
            parametro.Value = TipoImpresion
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@ColeccionID"
            parametro.Value = ColeccionID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@Amarres"
            parametro.Value = Amarres
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@MostrarDetalle"
            parametro.Value = MostrarDetalles
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_Etiquetas_ImpresionEtiquetasLengua_ImpresionPrueba]", listaParametros)
            'Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_Etiquetas_ImpresionEtiquetasLengua_ImpresionPrueba_Discovery]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Impresion de etiquetas de par de Lengua con los diseños de las etiquetas de prueba.
    ''' </summary>
    ''' <param name="Lotes"></param>
    ''' <param name="NaveSICYID"></param>
    ''' <param name="Año"></param>
    ''' <param name="ParesImpresion"></param>
    ''' <param name="ImpresoraID"></param>
    ''' <param name="UsuarioID"></param>
    ''' <param name="FechaPrograma"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ImpresionEtiquetasPorParLenguaPrueba(ByVal Lotes As String, ByVal NaveSICYID As Integer, ByVal Año As Integer, ByVal ParesImpresion As String, ByVal ImpresoraID As Integer, ByVal UsuarioID As Integer, ByVal FechaPrograma As Date, ByVal ColeccionId As Integer, Optional ByVal MostrarDetalles As Boolean = False, Optional ByVal ClienteSAY As Integer = 0) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@lotes"
            parametro.Value = Lotes
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@nave"
            parametro.Value = NaveSICYID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@anio"
            parametro.Value = Año
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@ParesImpresion"
            parametro.Value = ParesImpresion
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@ImpresoraID"
            parametro.Value = ImpresoraID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@UsuarioID"
            parametro.Value = UsuarioID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@FechaPrograma"
            parametro.Value = FechaPrograma
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@ColeccionID"
            parametro.Value = ColeccionId
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@MostrarDetalle"
            parametro.Value = MostrarDetalles
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@ClienteSAY_ID"
            parametro.Value = ClienteSAY
            listaParametros.Add(parametro)


            'Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_Etiquetas_ImprimirEtiquetasParLengua_ImpresionPrueba]", listaParametros)
            Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_Etiquetas_ImprimirEtiquetasParLengua_ImpresionPrueba]", listaParametros)

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Elimnina los registros de los parametros relacionados a una etiqueta.
    ''' </summary>
    ''' <param name="EtiquetaId"></param>
    ''' <param name="Resolucion"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function EliminarParametrosEtiquetaPorAutorizar(ByVal EtiquetaId As Integer, ByVal Resolucion As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@EtiquetaID"
            parametro.Value = EtiquetaId
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@Resolucion"
            parametro.Value = Resolucion
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_Etiquetas_EliminarParametros_PorAutorizar]", listaParametros)

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ValidarExisteEtiquetaRastreo(ByVal ClienteID As Integer, ByVal EsEtiquetaPrueba As Boolean) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@ClienteID"
            parametro.Value = ClienteID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@EtiquetaPrueba"
            parametro.Value = EsEtiquetaPrueba
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_Etiquetas_ValidarExisteEtiqueRastreo]", listaParametros)

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ValidarInformacionEtiquetaRastreo(ByVal LoteInicio As String, ByVal LoteFin As String, ByVal AmarreInicio As String, ByVal AmarreFin As String, ByVal NaveSICYID As Integer, ByVal AñoPrograma As Integer, ByVal ImpresoraID As Integer, ByVal UsuarioId As Integer, ByVal FechaPrograma As Date, ByVal ClienteSICYID As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@LoteInicio"
            parametro.Value = LoteInicio
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@LoteFin"
            parametro.Value = LoteFin
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@AmarreInicio"
            parametro.Value = AmarreInicio
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@AmarreFin"
            parametro.Value = AmarreFin
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@nave"
            parametro.Value = NaveSICYID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@anio"
            parametro.Value = AñoPrograma
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@ImpresoraID"
            parametro.Value = ImpresoraID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@UsuarioID"
            parametro.Value = UsuarioId
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@FechaPrograma"
            parametro.Value = FechaPrograma
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@ClienteSICYId"
            parametro.Value = ClienteSICYID
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_Etiquetas_ValidarInformacionEtiquetasRastreo]", listaParametros)

        Catch ex As Exception
            Throw ex
        End Try

    End Function


    Public Function ValidarImpresionEtiquetasLengua(ByVal LoteInicio As String, ByVal LoteFin As String, ByVal NaveSICYID As Integer, ByVal Año As Integer, ByVal ImpresoraID As Integer, ByVal UsuarioId As Integer, ByVal FechaPrograma As Date, TipoImpresion As Integer, ByVal ColeccionID As Integer, ByVal Amarres As String, ByVal ClienteID As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Try
            parametro = New SqlParameter
            parametro.ParameterName = "@LoteInicio"
            parametro.Value = LoteInicio
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@LoteFin"
            parametro.Value = LoteFin
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@nave"
            parametro.Value = NaveSICYID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@anio"
            parametro.Value = Año
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@ImpresoraID"
            parametro.Value = ImpresoraID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@UsuarioID"
            parametro.Value = UsuarioId
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@FechaPrograma"
            parametro.Value = FechaPrograma
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@TipoImpresion"
            parametro.Value = TipoImpresion
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@ColeccionID"
            parametro.Value = ColeccionID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@Amarres"
            parametro.Value = Amarres
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@ClienteSAYID"
            parametro.Value = ClienteID
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_Etiquetas_ValidarInformacionImpresionEtiquetasLengua]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ValidarTallasExtranjerasEtiquetaLengua(ByVal LoteInicio As Integer, ByVal LoteFin As Integer, ByVal NaveSICYID As Integer, ByVal ColeccionID As Integer, ByVal AñoPrograma As Integer, ByVal FechaPrograma As Date, ByVal EsEtiquetaPrueba As Boolean) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Try
            parametro = New SqlParameter
            parametro.ParameterName = "@LoteInicio"
            parametro.Value = LoteInicio
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@LoteFin"
            parametro.Value = LoteFin
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@NaveSICYId"
            parametro.Value = NaveSICYID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@ColeccionID"
            parametro.Value = ColeccionID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@AñoPrograma"
            parametro.Value = AñoPrograma
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@FechaPrograma"
            parametro.Value = FechaPrograma
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@EsEtiquetaPrueba"
            parametro.Value = EsEtiquetaPrueba
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_Etiquetas_ValidarTallasExtranjeras]", listaParametros)

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ValidarTallasExtranjerasEtiquetaRastreo(ByVal LoteInicio As Integer, ByVal LoteFin As Integer, ByVal NaveSICYID As Integer, ByVal ClienteSICYID As Integer, ByVal AñoPrograma As Integer, ByVal FechaPrograma As Date, ByVal EsEtiquetaPrueba As Boolean) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Try
            parametro = New SqlParameter
            parametro.ParameterName = "@LoteInicio"
            parametro.Value = LoteInicio
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@LoteFin"
            parametro.Value = LoteFin
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@NaveSICYId"
            parametro.Value = NaveSICYID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@ClienteSICYID"
            parametro.Value = ClienteSICYID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@AñoPrograma"
            parametro.Value = AñoPrograma
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@FechaPrograma"
            parametro.Value = FechaPrograma
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@EsEtiquetaPrueba"
            parametro.Value = EsEtiquetaPrueba
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_Etiquetas_ValidarTallasExtranjeras_Rastreo]", listaParametros)

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ValidarTallasExtranjerasPorLote(ByVal Lotes As String, ByVal NaveSICYID As Integer, ByVal AñoPrograma As Integer, ByVal FechaPrograma As Date) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Try
            parametro = New SqlParameter
            parametro.ParameterName = "@Lotes"
            parametro.Value = Lotes
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@NaveSICYId"
            parametro.Value = NaveSICYID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@AñoPrograma"
            parametro.Value = AñoPrograma
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@FechaPrograma"
            parametro.Value = FechaPrograma
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_Etiquetas_ValidarTallasExtranjeras_Lotes]", listaParametros)

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ValidarTallasExtranjerasPares(ByVal LoteInicio As Integer, ByVal LoteFin As Integer, ByVal NaveSICYID As Integer, ByVal AñoPrograma As Integer, ByVal FechaPrograma As Date) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Try
            parametro = New SqlParameter
            parametro.ParameterName = "@LoteInicio"
            parametro.Value = LoteInicio
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@LoteFin"
            parametro.Value = LoteFin
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@NaveSICYId"
            parametro.Value = NaveSICYID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@AñoPrograma"
            parametro.Value = AñoPrograma
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@FechaPrograma"
            parametro.Value = FechaPrograma
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_Etiquetas_ValidarTallasExtranjeras_Pares]", listaParametros)

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function MostrarDetallesTallasExtranjerasLengua(ByVal LoteInicio As Integer, ByVal LoteFin As Integer, ByVal NaveSICYID As Integer, ByVal ColeccionId As Integer, ByVal AñoPrograma As Integer, ByVal FechaPrograma As Date, ByVal EsEtiquetaPrueba As Boolean) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Try
            parametro = New SqlParameter
            parametro.ParameterName = "@LoteInicio"
            parametro.Value = LoteInicio
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@LoteFin"
            parametro.Value = LoteFin
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@NaveSICYId"
            parametro.Value = NaveSICYID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@ColeccionID"
            parametro.Value = ColeccionId
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@AñoPrograma"
            parametro.Value = AñoPrograma
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@FechaPrograma"
            parametro.Value = FechaPrograma
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@EsEtiquetaPrueba"
            parametro.Value = EsEtiquetaPrueba
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_Etiquetas_MostrarDetallesTallasExtranjeras]", listaParametros)

        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function MostrarDetallesTallasExtranjerasRastreo(ByVal LoteInicio As Integer, ByVal LoteFin As Integer, ByVal NaveSICYID As Integer, ByVal ClienteSICYID As Integer, ByVal AñoPrograma As Integer, ByVal FechaPrograma As Date, ByVal EsEtiquetaPrueba As Boolean) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Try
            parametro = New SqlParameter
            parametro.ParameterName = "@LoteInicio"
            parametro.Value = LoteInicio
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@LoteFin"
            parametro.Value = LoteFin
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@NaveSICYId"
            parametro.Value = NaveSICYID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@ClienteSICYID"
            parametro.Value = ClienteSICYID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@AñoPrograma"
            parametro.Value = AñoPrograma
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@FechaPrograma"
            parametro.Value = FechaPrograma
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@EsEtiquetaPrueba"
            parametro.Value = EsEtiquetaPrueba
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_Etiquetas_MostrarDetallesTallasExtranjeras_Rastreo]", listaParametros)

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function MostrarDetallesTallasExtranjerasPares(ByVal LoteInicio As Integer, ByVal LoteFin As Integer, ByVal NaveSICYID As Integer, ByVal AñoPrograma As Integer, ByVal FechaPrograma As Date) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Try
            parametro = New SqlParameter
            parametro.ParameterName = "@LoteInicio"
            parametro.Value = LoteInicio
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@LoteFin"
            parametro.Value = LoteFin
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@NaveSICYId"
            parametro.Value = NaveSICYID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@AñoPrograma"
            parametro.Value = AñoPrograma
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@FechaPrograma"
            parametro.Value = FechaPrograma
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_Etiquetas_MostrarDetallesTallasExtranjeras_Pares]", listaParametros)

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function ImpresionEtiquetasBATTA(ByVal Lotes As String, ByVal NaveSICYID As Integer, ByVal AñoPrograma As Integer, ByVal ImpresoraID As Integer, ByVal UsuarioID As Integer, ByVal FechaPrograma As Date) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Try
            parametro = New SqlParameter
            parametro.ParameterName = "@lotes"
            parametro.Value = Lotes
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@nave"
            parametro.Value = NaveSICYID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@anio"
            parametro.Value = AñoPrograma
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@ImpresoraID"
            parametro.Value = ImpresoraID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@UsuarioID"
            parametro.Value = UsuarioID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@FechaPrograma"
            parametro.Value = FechaPrograma
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_Etiqueta_ImpresionBATTA]", listaParametros)

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function ConsultaImagenesBatta(ByVal Lotes As String, ByVal NaveSICYID As Integer, ByVal Año As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Try
            parametro = New SqlParameter
            parametro.ParameterName = "@lotes"
            parametro.Value = Lotes
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@nave"
            parametro.Value = NaveSICYID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@anio"
            parametro.Value = Año
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_Etiquetas_consultaImagenesBATTA]", listaParametros)

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function ValidarImagenesBatta(ByVal Lotes As String, ByVal NaveSICYID As Integer, ByVal Año As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Try
            parametro = New SqlParameter
            parametro.ParameterName = "@lotes"
            parametro.Value = Lotes
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@nave"
            parametro.Value = NaveSICYID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@anio"
            parametro.Value = Año
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_Etiquetas_ValidarImagenesBATTA]", listaParametros)

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function ImprimeEtiquetasBattaOpcionesCliente(ByVal ImpresoraID As Integer,
                                           ByVal UsuarioID As Integer,
                                           ByVal ClienteID As Integer,
                                           ByVal TipoEtiquetaID As Int16,
                                           ByVal MostrarDetalle As Boolean,
                                           ByVal PorLotes As Integer,
                                           ByVal Nave As Integer,
                                           ByVal FechaPrograma As Date,
                                           ByVal LoteDe As Integer,
                                           ByVal LoteHasta As Integer,
                                           ByVal PorPedido As Boolean,
                                           ByVal PedidoSICY As Integer,
                                           ByVal PedidoSAY As Integer,
                                           ByVal PorApartados As Boolean,
                                           ByVal CadenaApartados As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Try

            parametro.ParameterName = "@ImpresoraID"
            parametro.Value = ImpresoraID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@UsuarioID"
            parametro.Value = UsuarioID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@ClienteID"
            parametro.Value = ClienteID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@tipoetiquetaid"
            parametro.Value = TipoEtiquetaID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@MostrarDetalle"
            parametro.Value = MostrarDetalle
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@PorLotes"
            parametro.Value = PorLotes
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@nave"
            parametro.Value = Nave
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@FechaPrograma"
            parametro.Value = FechaPrograma
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@LoteDe"
            parametro.Value = LoteDe
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@LoteHasta"
            parametro.Value = LoteHasta
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@PorPedido"
            parametro.Value = PorPedido
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@PedidoSicy"
            parametro.Value = PedidoSICY
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@PedidoSay"
            parametro.Value = PedidoSAY
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@PorApartados"
            parametro.Value = PorApartados
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@CadenaApartados"
            parametro.Value = CadenaApartados
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_Etiquetas_ImprimirEtiquetasBattaOpcionesClienteProduccion]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function ConsultaImagenesBattaOpcionesCliente(ByVal PorLote As Boolean, ByVal LoteInicio As Integer, ByVal LoteFin As Integer, ByVal Nave As Integer, ByVal Fechaprograma As Date, ByVal PorPedido As Boolean, ByVal PedidoSAY As Integer, ByVal PedidoSICY As Integer, ByVal PorApartado As Boolean, ByVal CadenaApartados As String, ByVal IdCliente As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Try
            parametro = New SqlParameter
            parametro.ParameterName = "@PorLotes"
            parametro.Value = PorLote
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@loteInicio"
            parametro.Value = LoteInicio
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@loteFin"
            parametro.Value = LoteFin
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@nave"
            parametro.Value = Nave
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@FechaPrograma"
            parametro.Value = Fechaprograma
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@PorPedido"
            parametro.Value = PorPedido
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@PedidoSAY"
            parametro.Value = PedidoSAY
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@PedidoSICY"
            parametro.Value = PedidoSICY
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@PorApartado"
            parametro.Value = PorApartado
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@CadenaApartados"
            parametro.Value = CadenaApartados
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@IdCliente"
            parametro.Value = IdCliente
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_Etiquetas_ConsultaImagenesBattaOpcionesCliente_PPrueba]", listaParametros)

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function ImprimeParesBattaOpcionesCliente(ByVal ImpresoraId As Integer, ByVal Pares As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Try
            parametro = New SqlParameter
            parametro.ParameterName = "@ImpresoraID"
            parametro.Value = ImpresoraId
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@Pares"
            parametro.Value = Pares
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_Etiquetas_ImprimirEtiquetasBattaOpcionesClienteProduccionDetalles]", listaParametros)

        Catch ex As Exception
            Throw ex
        End Try

    End Function


    Public Function ObtenerEstiloCOPPEL(ByVal CodigoRapido As String, ByVal Calce As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Try
            parametro = New SqlParameter
            parametro.ParameterName = "@CodigoRapido"
            parametro.Value = CodigoRapido
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@Calce"
            parametro.Value = Calce
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_Etiquetas_ObtenerEstiloCOPPEL]", listaParametros)

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function ImprimirEtiquetasCOPPEL(ByVal IdArchivoCOPPEL As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Try
            parametro = New SqlParameter
            parametro.ParameterName = "@IdArchivoCoppel"
            parametro.Value = IdArchivoCOPPEL
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_Etiquetas_COPPEL_ImpresionEtiquetas]", listaParametros)

        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function ReporteTallasLoteCliente(ByVal Lote As Integer, ByVal NaveSICYID As Integer, ByVal FechaPrograma As Date) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Try
            parametro = New SqlParameter
            parametro.ParameterName = "@lote"
            parametro.Value = Lote
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@nave"
            parametro.Value = NaveSICYID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@FechaPrograma"
            parametro.Value = FechaPrograma
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_Etiquetas_ReporteTallasLote_Clientes]", listaParametros)

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ReporteTallasLoteClienteTienda(ByVal Lote As Integer, ByVal NaveSICYID As Integer, ByVal FechaPrograma As Date) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Try
            parametro = New SqlParameter
            parametro.ParameterName = "@lote"
            parametro.Value = Lote
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@nave"
            parametro.Value = NaveSICYID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@FechaPrograma"
            parametro.Value = FechaPrograma
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_Etiquetas_ReporteTallasLote_ClienteTiendas]", listaParametros)

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ReporteTallasLotePartidasTienda(ByVal Lote As Integer, ByVal NaveSICYID As Integer, ByVal FechaPrograma As Date) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Try
            parametro = New SqlParameter
            parametro.ParameterName = "@lote"
            parametro.Value = Lote
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@nave"
            parametro.Value = NaveSICYID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@FechaPrograma"
            parametro.Value = FechaPrograma
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_Etiquetas_ReporteTallasLote_PartidasTiendas]", listaParametros)

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ReporteTallasLoteEncabezadoTallas(ByVal Lote As Integer, ByVal NaveSICYID As Integer, ByVal FechaPrograma As Date) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Try
            parametro = New SqlParameter
            parametro.ParameterName = "@lote"
            parametro.Value = Lote
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@nave"
            parametro.Value = NaveSICYID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@FechaPrograma"
            parametro.Value = FechaPrograma
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_Etiquetas_ReporteTallasLote_EncabezadoTallas]", listaParametros)

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ReporteTallasLoteParesPartidaTallas(ByVal Lote As Integer, ByVal NaveSICYID As Integer, ByVal FechaPrograma As Date) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Try
            parametro = New SqlParameter
            parametro.ParameterName = "@lote"
            parametro.Value = Lote
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@nave"
            parametro.Value = NaveSICYID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@FechaPrograma"
            parametro.Value = FechaPrograma
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_Etiquetas_ReporteTallasLote_ParesPartidaTallas]", listaParametros)

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ImprimeEtiquetasBattaOpcionesCliente_ConsultaDetalles(ByVal ImpresoraID As Integer,
                                         ByVal UsuarioID As Integer,
                                         ByVal ClienteID As Integer,
                                         ByVal TipoEtiquetaID As Int16,
                                         ByVal MostrarDetalle As Boolean,
                                         ByVal PorLotes As Integer,
                                         ByVal Nave As Integer,
                                         ByVal FechaPrograma As Date,
                                         ByVal LoteDe As Integer,
                                         ByVal LoteHasta As Integer,
                                         ByVal PorPedido As Boolean,
                                         ByVal PedidoSICY As Integer,
                                         ByVal PedidoSAY As Integer,
                                         ByVal PorApartados As Boolean,
                                         ByVal CadenaApartados As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try

            parametro.ParameterName = "@ImpresoraID"
            parametro.Value = ImpresoraID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@UsuarioID"
            parametro.Value = UsuarioID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@ClienteID"
            parametro.Value = ClienteID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@tipoetiquetaid"
            parametro.Value = TipoEtiquetaID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@MostrarDetalle"
            parametro.Value = MostrarDetalle
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@PorLotes"
            parametro.Value = PorLotes
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@nave"
            parametro.Value = Nave
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@FechaPrograma"
            parametro.Value = FechaPrograma
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@LoteDe"
            parametro.Value = LoteDe
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@LoteHasta"
            parametro.Value = LoteHasta
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@PorPedido"
            parametro.Value = PorPedido
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@PedidoSicy"
            parametro.Value = PedidoSICY
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@PedidoSay"
            parametro.Value = PedidoSAY
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@PorApartados"
            parametro.Value = PorApartados
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@CadenaApartados"
            parametro.Value = CadenaApartados
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_Etiquetas_ImprimirEtiquetasBattaOpcionesClienteProduccion_ConsultaDetalles]", listaParametros)

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function ReporteTallasTiendasPartidas(ByVal Lote As Integer, ByVal NaveSICYID As Integer, ByVal FechaPrograma As Date) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Try
            parametro = New SqlParameter
            parametro.ParameterName = "@lote"
            parametro.Value = Lote
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@nave"
            parametro.Value = NaveSICYID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@FechaPrograma"
            parametro.Value = FechaPrograma
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_Etiquetas_ReporteTallasLote_TiendasPartidas]", listaParametros)

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ImpresionConArchivo(ByVal Serie As String, ByVal Estilo As String, ByVal Color As String, ByVal Marca As String, ByVal Punto As String, ByVal Pedido As String, ByVal UsuarioId As Integer, ByVal ClienteSAYID As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Try
            parametro = New SqlParameter
            parametro.ParameterName = "@Serie"
            parametro.Value = Serie
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@Estilo"
            parametro.Value = Estilo
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@Color"
            parametro.Value = Color
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@Marca"
            parametro.Value = Marca
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@punto"
            parametro.Value = Punto
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@Pedido"
            parametro.Value = Pedido
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@UsuarioId"
            parametro.Value = UsuarioId
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@ClienteSAYID"
            parametro.Value = ClienteSAYID
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_Etiquetas_Archivo_InsertarInformacion]", listaParametros)

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function EliminarInformacionImpresionArchivo(ByVal UsuarioID As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Try
            parametro = New SqlParameter
            parametro.ParameterName = "@UsuarioId"
            parametro.Value = UsuarioID
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_Etiquetas_Archivo_Eliminar]", listaParametros)

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ImpresionArchivo(ByVal UsuarioId As Integer, ByVal ImpresoraID As Integer, ByVal ClienteID As Integer, ByVal TipoEtiquetaID As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Try
            parametro = New SqlParameter
            parametro.ParameterName = "@IdUsuario"
            parametro.Value = UsuarioId
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@ImpresoraID"
            parametro.Value = ImpresoraID
            listaParametros.Add(parametro)


            parametro = New SqlParameter
            parametro.ParameterName = "@ClienteID"
            parametro.Value = ClienteID
            listaParametros.Add(parametro)


            parametro = New SqlParameter
            parametro.ParameterName = "@TipoEtiquetaId"
            parametro.Value = TipoEtiquetaID
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_Etiquetas_ImpresionArchivo]", listaParametros)

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ObtenerParesPorCodigo(ByVal FechaPrograma As String, ByVal NaveSICYID As Integer, ByVal PedidoSICY As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro = New SqlParameter
            parametro.ParameterName = "@FechaPrograma"
            parametro.Value = FechaPrograma
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@NaveId"
            parametro.Value = NaveSICYID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@PedidoSICY"
            parametro.Value = PedidoSICY
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_Etiquetas_ParesCodigoSICY]", listaParametros)

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function ObtenerClienesEtiquetasEspecialLengua() As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try

            Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_Etiquetas_ConsultarClientesEtiquetaEspecialLengua]", listaParametros)

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ObtenerColecciones() As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try

            Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_Etiquetas_ConsultarColeccionesEtiqueEspecial]", listaParametros)

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ValidarClienteColeccion(ClienteID As Integer, ColeccionID As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro = New SqlParameter
            parametro.ParameterName = "@ClienteID"
            parametro.Value = ClienteID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@ColeccionID"
            parametro.Value = ColeccionID
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_Etiquetas_ValidarClienteColeccion]", listaParametros)

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub GuardarBitacoraImpresion(LoteInicio As Integer, LoteFIn As Integer, Año As Integer, Nave As Integer,
                                                Programa As Integer, FechaPrograma As Date, UsuarioID As Integer,
                                                PedidoCliente As Integer, Pares As String, TipoEtiquetaID As Integer,
                                                PedidoSAY As Integer, PedidoSICY As Integer, ApartadosConfirmados As Integer,
                                                ColeccionID As Integer, ClienteID As Integer)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro = New SqlParameter
            parametro.ParameterName = "@LoteInicio"
            parametro.Value = LoteInicio
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@LoteFIn"
            parametro.Value = LoteFIn
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@Año"
            parametro.Value = Año
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@Nave"
            parametro.Value = Nave
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@Programa"
            parametro.Value = Programa
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@FechaPrograma"
            parametro.Value = FechaPrograma
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@UsuarioID"
            parametro.Value = UsuarioID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@PedidoCliente"
            parametro.Value = PedidoCliente
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@Pares"
            parametro.Value = Pares
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@TipoEtiqueta"
            parametro.Value = TipoEtiquetaID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@PedidoSAY"
            parametro.Value = PedidoSAY
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@PedidoSICY"
            parametro.Value = PedidoSICY
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@ApartadosConfirmados"
            parametro.Value = ApartadosConfirmados
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@ColeccionID"
            parametro.Value = ColeccionID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@ClienteID"
            parametro.Value = ClienteID
            listaParametros.Add(parametro)


            objPersistencia.EjecutarConsultaSP("[Programacion].[SP_Etiquetas_InsertarBitacoraImpresionEtiquetas]", listaParametros)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function ProveedorPlanta(ByVal naveid As Integer, ByVal fechaPrograma As Date, ByVal clasificacionProvPlanta As Integer) As DataTable
        Dim objpersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "@naveId"
        parametro.Value = naveid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@fechaPrograma"
        parametro.Value = fechaPrograma
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Clasificacion"
        parametro.Value = clasificacionProvPlanta
        listaParametros.Add(parametro)

        Return objpersistencia.EjecutarConsultaSP("[Produccion].[SP_ConsultaSaySicyEtiquetasPlanta]", listaParametros)

    End Function

    Public Function ProveedorSuela(ByVal naveid As Integer, ByVal fechaPrograma As Date, ByVal clasificacionProvSuela As Integer) As DataTable
        Dim objpersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "@naveId"
        parametro.Value = naveid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@fechaPrograma"
        parametro.Value = fechaPrograma
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Clasificacion"
        parametro.Value = clasificacionProvSuela
        listaParametros.Add(parametro)

        Return objpersistencia.EjecutarConsultaSP("[Produccion].[SP_ConsultaSaySicyEtiquetasSuela]", listaParametros)

    End Function

    Public Function ProveedorPlantilla(ByVal naveid As Integer, ByVal fechaPrograma As Date, ByVal clasificacionProvPlantilla As Integer) As DataTable
        Dim objpersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "@naveId"
        parametro.Value = naveid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@fechaPrograma"
        parametro.Value = fechaPrograma
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Clasificacion"
        parametro.Value = clasificacionProvPlantilla
        listaParametros.Add(parametro)

        Return objpersistencia.EjecutarConsultaSP("[Produccion].[SP_ConsultaSaySicyEtiquetasPlantilla]", listaParametros)

    End Function

    Public Function ConsultaEtiquetasConsumos(ByVal naveId As Integer, ByVal fechaPrograma As Date, ByVal impresora As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "@gNave"
        parametro.Value = naveId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@gPrograma"
        parametro.Value = fechaPrograma
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@gImpresora"
        parametro.Value = impresora
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_EtiquetasProveedorConsumos]", listaParametros)

    End Function

    Public Function ConsultaEtiquetasPlantaSuela(ByVal naveid As Integer, ByVal fechaPrograma As Date, ByVal idProveedor As Integer, ByVal idLotes As Integer, ByVal Clasificacion As String, ByVal Impresora As Integer, ByVal grupo As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "@IdNave"
        parametro.Value = naveid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FECHA"
        parametro.Value = fechaPrograma
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@IdProveedor"
        parametro.Value = idProveedor
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@IdLotes"
        parametro.Value = idLotes
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Clasificacion"
        parametro.Value = Clasificacion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Impresora"
        parametro.Value = Impresora
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Grupo"
        parametro.Value = grupo
        listaParametros.Add(parametro)

        'Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_EtiquetasProveedorPlantaSuela]", listaParametros)
        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_EtiquetasProveedorPlantaSuelaPorGrupo]", listaParametros)

    End Function

    Public Function ConsultaEtiquetasPlantilla(ByVal naveid As Integer, ByVal fechaPrograma As Date, ByVal idProveedor As Integer, ByVal idLotes As Integer, ByVal Impresora As Integer, ByVal grupo As String) As DataTable
        Dim objPersistencia = New Persistencia.OperacionesProcedimientos
        Dim parametro = New SqlParameter
        Dim listaParametro = New List(Of SqlParameter)

        parametro.ParameterName = "@fechaPrograma"
        parametro.Value = fechaPrograma
        listaParametro.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@naveSICYId"
        parametro.Value = naveid
        listaParametro.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@idProveedor"
        parametro.Value = idProveedor
        listaParametro.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@idLote"
        parametro.Value = idLotes
        listaParametro.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Impresora"
        parametro.Value = Impresora
        listaParametro.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@grupo"
        parametro.Value = grupo
        listaParametro.Add(parametro)

        'Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_EtiquetasProveedorPlantillaInteligente]", listaParametro)
        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_EtiquetasProveedorPlantillaInteligentePorGrupo]", listaParametro)

    End Function
    Public Function CmbConsultaEtiquetasCliente(ByVal clienteId As Integer, ByVal tipoEtiqueta As Integer) As DataTable
        Dim objPersistencia = New Persistencia.OperacionesProcedimientos
        Dim parametro = New SqlParameter
        Dim listaParametro = New List(Of SqlParameter)

        parametro.ParameterName = "@ClienteId"
        parametro.Value = clienteId
        listaParametro.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@TipoEtiqueta"
        parametro.Value = tipoEtiqueta
        listaParametro.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_Etiquetas_ConsultarEtiquetasCliente]", listaParametro)

    End Function
    Public Function ConsultaEtiquetasClienteColeccion(ByVal etiquetaId As Integer) As DataTable
        Dim objPersistencia = New Persistencia.OperacionesProcedimientos
        Dim parametro = New SqlParameter
        Dim listaParametro = New List(Of SqlParameter)

        parametro.ParameterName = "@etiquetaId"
        parametro.Value = etiquetaId
        listaParametro.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_Etiquetas_ConsultarColeccionesEtiquetasCliente]", listaParametro)

    End Function
    Public Function ObtenerColeccionesNoAsignadasPorCliente(ByVal clienteId As Integer, ByVal etiquetaId As Integer) As DataTable
        Dim objPersistencia = New Persistencia.OperacionesProcedimientos
        Dim parametro = New SqlParameter
        Dim listaParametro = New List(Of SqlParameter)

        parametro.ParameterName = "@ClienteId"
        parametro.Value = clienteId
        listaParametro.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@IdEtiqueta"
        parametro.Value = etiquetaId
        listaParametro.Add(parametro)


        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_Etiquetas_ConsultarColeccionesEtiquetasClienteNoAsignadas]", listaParametro)

    End Function
    Public Function AsignarEtiquetaClienteCollecion(ByVal clienteId As Integer, ByVal etiquetaId As Integer, ByVal coleccionIds As String, ByVal UsuarioId As Integer) As DataTable
        Dim objPersistencia = New Persistencia.OperacionesProcedimientos
        Dim parametro = New SqlParameter
        Dim listaParametro = New List(Of SqlParameter)

        parametro.ParameterName = "@ClienteId"
        parametro.Value = clienteId
        listaParametro.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@EtiquetaId"
        parametro.Value = etiquetaId
        listaParametro.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@ColeccionesId"
        parametro.Value = coleccionIds
        listaParametro.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@UsuarioId"
        parametro.Value = UsuarioId
        listaParametro.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_Etiquetas_AsignarEtiquetaClienteColeccion]", listaParametro)

    End Function
    Public Function EliminarColeccionesAsignadasPorCliente(ByVal clienteId As Integer, ByVal etiquetaId As Integer, ByVal coleccionIds As String, ByVal UsuarioId As Integer) As DataTable
        Dim objPersistencia = New Persistencia.OperacionesProcedimientos
        Dim parametro = New SqlParameter
        Dim listaParametro = New List(Of SqlParameter)

        parametro.ParameterName = "@ClienteId"
        parametro.Value = clienteId
        listaParametro.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@EtiquetaId"
        parametro.Value = etiquetaId
        listaParametro.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@UsuarioId"
        parametro.Value = UsuarioId
        listaParametro.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@ColeccionesId"
        parametro.Value = coleccionIds
        listaParametro.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_Etiquetas_EliminarEtiquetaClienteColeccion]", listaParametro)

    End Function

    Public Function cargarGrupoXNave()
        Dim objPersistencia = New Persistencia.OperacionesProcedimientos
        Dim parametros = New SqlParameter
        Dim listaParametro = New List(Of SqlParameter)

        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_Etiquetas_ConsultarGrupo]", listaParametro)

    End Function

    Public Function ProveedorPlantaPorGrupo(ByVal fechaPrograma As Date, ByVal clasificacionProvPlanta As Integer, ByVal grupo As String) As DataTable
        Dim objpersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro = New SqlParameter
        parametro.ParameterName = "@fechaPrograma"
        parametro.Value = fechaPrograma
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Clasificacion"
        parametro.Value = clasificacionProvPlanta
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@grupo"
        parametro.Value = grupo
        listaParametros.Add(parametro)

        Return objpersistencia.EjecutarConsultaSP("[Produccion].[SP_ConsultaSaySicyEtiquetasPlantaPorGrupo]", listaParametros)

    End Function

    Public Function ProveedorSuelaPorGrupo(ByVal fechaPrograma As Date, ByVal clasificacionProvSuela As Integer, ByVal grupo As String) As DataTable
        Dim objpersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim objP As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)


        parametro = New SqlParameter
        parametro.ParameterName = "@fechaPrograma"
        parametro.Value = fechaPrograma
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Clasificacion"
        parametro.Value = clasificacionProvSuela
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@grupo"
        parametro.Value = grupo
        listaParametros.Add(parametro)

        Return objpersistencia.EjecutarConsultaSP("[Produccion].[SP_ConsultaSaySicyEtiquetasSuelaPorGrupo]", listaParametros)

    End Function


    Public Function ProveedorPlantillaPorGrupo(ByVal fechaPrograma As Date, ByVal clasificacionProvPlantilla As Integer, ByVal grupo As String) As DataTable
        Dim objpersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro = New SqlParameter
        parametro.ParameterName = "@fechaPrograma"
        parametro.Value = fechaPrograma
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Clasificacion"
        parametro.Value = clasificacionProvPlantilla
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@grupo"
        parametro.Value = grupo
        listaParametros.Add(parametro)

        Return objpersistencia.EjecutarConsultaSP("[Produccion].[SP_ConsultaSaySicyEtiquetasPlantillaPorGrupo]", listaParametros)

    End Function


    Public Function ConsultaColecciones()
        Dim objpersistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        Return objpersistencia.EjecutarConsultaSP("[Programacion].[SP_Consulta_Colecciones]", listaParametros)

    End Function

    Public Function ConsultaImagenesCoppel(ByVal Lotes As String, ByVal NaveSICYID As Integer, ByVal Año As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Try
            parametro = New SqlParameter
            parametro.ParameterName = "@lotes"
            parametro.Value = Lotes
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@nave"
            parametro.Value = NaveSICYID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@anio"
            parametro.Value = Año
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_Etiquetas_consultaImagenesCoppel]", listaParametros)

        Catch ex As Exception
            Throw ex
        End Try

    End Function
    Public Function ValidarImagenesCoppel(ByVal Lotes As String, ByVal NaveSICYID As Integer, ByVal Año As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Try
            parametro = New SqlParameter
            parametro.ParameterName = "@lotes"
            parametro.Value = Lotes
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@nave"
            parametro.Value = NaveSICYID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@anio"
            parametro.Value = Año
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_Etiquetas_ValidarImagenesCoppel]", listaParametros)

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function ImpresionEtiquetasCoppel(ByVal Lotes As String, ByVal NaveSICYID As Integer, ByVal AñoPrograma As Integer, ByVal ImpresoraID As Integer, ByVal UsuarioID As Integer, ByVal FechaPrograma As Date) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Try
            parametro = New SqlParameter
            parametro.ParameterName = "@lotes"
            parametro.Value = Lotes
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@nave"
            parametro.Value = NaveSICYID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@anio"
            parametro.Value = AñoPrograma
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@ImpresoraID"
            parametro.Value = ImpresoraID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@UsuarioID"
            parametro.Value = UsuarioID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@FechaPrograma"
            parametro.Value = FechaPrograma
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_Etiqueta_ImpresionCOPPEL]", listaParametros)

        Catch ex As Exception
            Throw ex
        End Try

    End Function


    Public Function ImprimeEtiquetasCoppelOpcionesCliente(ByVal ImpresoraID As Integer,
                                           ByVal UsuarioID As Integer,
                                           ByVal ClienteID As Integer,
                                           ByVal TipoEtiquetaID As Int16,
                                           ByVal MostrarDetalle As Boolean,
                                           ByVal PorLotes As Integer,
                                           ByVal Nave As Integer,
                                           ByVal FechaPrograma As Date,
                                           ByVal LoteDe As Integer,
                                           ByVal LoteHasta As Integer,
                                           ByVal PorPedido As Boolean,
                                           ByVal PedidoSICY As Integer,
                                           ByVal PedidoSAY As Integer,
                                           ByVal PorApartados As Boolean,
                                           ByVal CadenaApartados As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Try

            parametro.ParameterName = "@ImpresoraID"
            parametro.Value = ImpresoraID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@UsuarioID"
            parametro.Value = UsuarioID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@ClienteID"
            parametro.Value = ClienteID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@tipoetiquetaid"
            parametro.Value = TipoEtiquetaID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@MostrarDetalle"
            parametro.Value = MostrarDetalle
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@PorLotes"
            parametro.Value = PorLotes
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@nave"
            parametro.Value = Nave
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@FechaPrograma"
            parametro.Value = FechaPrograma
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@LoteDe"
            parametro.Value = LoteDe
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@LoteHasta"
            parametro.Value = LoteHasta
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@PorPedido"
            parametro.Value = PorPedido
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@PedidoSicy"
            parametro.Value = PedidoSICY
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@PedidoSay"
            parametro.Value = PedidoSAY
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@PorApartados"
            parametro.Value = PorApartados
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@CadenaApartados"
            parametro.Value = CadenaApartados
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_Etiquetas_ImprimirEtiquetasCoppelOpcionesClienteProduccion_Coppel]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function ImprimeEtiquetasCoppelOpcionesCliente_ConsultaDetalles(ByVal ImpresoraID As Integer,
                                         ByVal UsuarioID As Integer,
                                         ByVal ClienteID As Integer,
                                         ByVal TipoEtiquetaID As Int16,
                                         ByVal MostrarDetalle As Boolean,
                                         ByVal PorLotes As Integer,
                                         ByVal Nave As Integer,
                                         ByVal FechaPrograma As Date,
                                         ByVal LoteDe As Integer,
                                         ByVal LoteHasta As Integer,
                                         ByVal PorPedido As Boolean,
                                         ByVal PedidoSICY As Integer,
                                         ByVal PedidoSAY As Integer,
                                         ByVal PorApartados As Boolean,
                                         ByVal CadenaApartados As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try

            parametro.ParameterName = "@ImpresoraID"
            parametro.Value = ImpresoraID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@UsuarioID"
            parametro.Value = UsuarioID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@ClienteID"
            parametro.Value = ClienteID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@tipoetiquetaid"
            parametro.Value = TipoEtiquetaID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@MostrarDetalle"
            parametro.Value = MostrarDetalle
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@PorLotes"
            parametro.Value = PorLotes
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@nave"
            parametro.Value = Nave
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@FechaPrograma"
            parametro.Value = FechaPrograma
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@LoteDe"
            parametro.Value = LoteDe
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@LoteHasta"
            parametro.Value = LoteHasta
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@PorPedido"
            parametro.Value = PorPedido
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@PedidoSicy"
            parametro.Value = PedidoSICY
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@PedidoSay"
            parametro.Value = PedidoSAY
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@PorApartados"
            parametro.Value = PorApartados
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@CadenaApartados"
            parametro.Value = CadenaApartados
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_Etiquetas_ImprimirEtiquetasCoppelOpcionesClienteProduccion_ConsultaDetalles]", listaParametros)

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function ImprimeParesCoppelOpcionesCliente(ByVal ImpresoraId As Integer, ByVal Pares As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Try
            parametro = New SqlParameter
            parametro.ParameterName = "@ImpresoraID"
            parametro.Value = ImpresoraId
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@Pares"
            parametro.Value = Pares
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_Etiquetas_ImprimirEtiquetasCoppelOpcionesClienteProduccionDetalles]", listaParametros)

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function DescargarNiceLabeCoppel(ByVal tipoEtiqueta As Integer)
        Dim objPersistencias As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro = New SqlParameter
            parametro.ParameterName = "@TipoEtiqueta"
            parametro.Value = tipoEtiqueta
            listaParametros.Add(parametro)

            Return objPersistencias.EjecutarConsultaSP("[Programacion].[SP_ConsultarArchivoTipoEtiquetaCoppel]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ConsultaLotesSinGRFImagen(ByVal fechaDel As DateTime,
                                              ByVal fechaAl As DateTime,
                                              ByVal fechasProg As Integer,
                                              ByVal sinGrf200 As Integer,
                                              ByVal sinGrf300 As Integer,
                                              ByVal sinImagen As Integer,
                                              ByVal sinLogoMarca As Integer)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@fechaDel"
            parametro.Value = fechaDel
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@fechaAl"
            parametro.Value = fechaAl
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@filtroFechas"
            parametro.Value = fechasProg
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@sinGRF200"
            parametro.Value = sinGrf200
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@sinGRF300"
            parametro.Value = sinGrf300
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@sinImagen"
            parametro.Value = sinImagen
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@sinLogoMarca"
            parametro.Value = sinLogoMarca
            listaParametros.Add(parametro)

            'Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_ConsultaLotesConSinGRFImagen]", listaParametros)
            Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_ConsultaLotesConSinGRFImagenV2]", listaParametros)

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function ConsultaEtiquetasCoppelPantilla(ByVal accion As Integer,
                                                 ByVal idNave As Integer,
                                                 ByVal tipoEtiquetaId As Integer,
                                                 ByVal loteDel As Integer,
                                                 ByVal loteAl As Integer,
                                                 ByVal fechaPrograma As Date,
                                                 ByVal pedidoSAY As Integer,
                                                 ByVal pedidoSICY As Integer,
                                                 ByVal cadenaApartados As String
                                                 ) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@accion"
            parametro.Value = accion
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@nave"
            parametro.Value = idNave
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@tipoetiquetaid"
            parametro.Value = tipoEtiquetaId
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@LoteDel"
            parametro.Value = loteDel
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@LoteAl"
            parametro.Value = loteAl
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@FechaPrograma"
            parametro.Value = fechaPrograma
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@PedidoSAY"
            parametro.Value = pedidoSAY
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@PedidoSICY"
            parametro.Value = pedidoSICY
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@CadenaApartados"
            parametro.Value = cadenaApartados
            listaParametros.Add(parametro)

            ' CarlosMtz (Se crea nuevo SP para etiqueta de coppel por plantilla, agregando un separador por cada Lote)
            'Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_ConsultaEtiquetasCoppelPantilla]", listaParametros)
            Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_ConsultaEtiquetasCoppelPantilla_SeparacionLotes]", listaParametros)

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ConsultaArticulosSinImagenCoppel(ByVal accion As Integer,
                                                 ByVal idNave As Integer,
                                                 ByVal tipoEtiquetaId As Integer,
                                                 ByVal loteDel As Integer,
                                                 ByVal loteAl As Integer,
                                                 ByVal fechaPrograma As Date,
                                                 ByVal pedidoSAY As Integer,
                                                 ByVal pedidoSICY As Integer,
                                                 ByVal cadenaApartados As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@accion"
            parametro.Value = accion
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@nave"
            parametro.Value = idNave
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@tipoetiquetaid"
            parametro.Value = tipoEtiquetaId
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@LoteDel"
            parametro.Value = loteDel
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@LoteAl"
            parametro.Value = loteAl
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@FechaPrograma"
            parametro.Value = fechaPrograma
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@PedidoSAY"
            parametro.Value = pedidoSAY
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@PedidoSICY"
            parametro.Value = pedidoSICY
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@CadenaApartados"
            parametro.Value = cadenaApartados
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_ConsultaArticulosSinImagenCoppel]", listaParametros)

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ConsultaNavesXGrupo(ByVal grupo As String)
        Dim objPersistencias As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@Grupo"
            parametro.Value = grupo
            listaParametros.Add(parametro)

            Return objPersistencias.EjecutarConsultaSP("[Programacion].[SP_ConsultaNaveXGrupo]", listaParametros)

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function ConsultaEtiquetasPlantaSuela_Naves(ByVal navesId As String, ByVal fechaPrograma As Date, ByVal idProveedor As Integer, ByVal idLotes As Integer, ByVal Clasificacion As String, ByVal Impresora As Integer, ByVal grupo As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "@navesId"
        parametro.Value = navesId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FECHA"
        parametro.Value = fechaPrograma
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@IdProveedor"
        parametro.Value = idProveedor
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@IdLotes"
        parametro.Value = idLotes
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Clasificacion"
        parametro.Value = Clasificacion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Impresora"
        parametro.Value = Impresora
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Grupo"
        parametro.Value = grupo
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_EtiquetasProveedorPlantaSuelaPorGrupo_Naves]", listaParametros)

    End Function

    Public Function ConsultaEtiquetasPlantilla_Naves(ByVal navesId As String, ByVal fechaPrograma As Date, ByVal idProveedor As Integer, ByVal idLotes As Integer, ByVal Impresora As Integer, ByVal grupo As String) As DataTable
        Dim objPersistencia = New Persistencia.OperacionesProcedimientos
        Dim parametro = New SqlParameter
        Dim listaParametro = New List(Of SqlParameter)

        parametro.ParameterName = "@fechaPrograma"
        parametro.Value = fechaPrograma
        listaParametro.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@navesId"
        parametro.Value = navesId
        listaParametro.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@idProveedor"
        parametro.Value = idProveedor
        listaParametro.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@idLote"
        parametro.Value = idLotes
        listaParametro.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Impresora"
        parametro.Value = Impresora
        listaParametro.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@grupo"
        parametro.Value = grupo
        listaParametro.Add(parametro)

        'Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_EtiquetasProveedorPlantillaInteligente]", listaParametro)
        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_EtiquetasProveedorPlantillaInteligentePorGrupo_Naves]", listaParametro)

    End Function

    Public Function BitacoraEtiquetasProveedores(ByVal navesId As String,
                                                 ByVal fechaPrograma As Date,
                                                 ByVal idProveedor As Integer,
                                                 ByVal idLotes As Integer,
                                                 ByVal Clasificacion As String,
                                                 ByVal Impresora As Integer,
                                                 ByVal grupo As String,
                                                 ByVal usuario As String)
        Dim objPersistencia = New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "@navesId"
        parametro.Value = navesId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FECHA"
        parametro.Value = fechaPrograma
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@IdProveedor"
        parametro.Value = idProveedor
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@IdLotes"
        parametro.Value = idLotes
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Clasificacion"
        parametro.Value = Clasificacion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Impresora"
        parametro.Value = Impresora
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Grupo"
        parametro.Value = grupo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@usuarioImprimio"
        parametro.Value = usuario
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_BitacoraImpresionEtiquetasProveedores]", listaParametros)

    End Function

    Public Function CoosultaCodigoRapidoCoppelTalla(ByVal codigorapido As String, ByVal Talla As String) As DataTable ', ByVal Talla As String
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro = New SqlParameter
            parametro.ParameterName = "@codrapido"
            parametro.Value = codigorapido
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@talla"
            parametro.Value = Talla
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_Etiquetas_ConsultaEstiloPielColorColppelTalla]", listaParametros)

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function ConsultaEtiquetasBattaPantilla(ByVal accion As Integer, ByVal nave As Integer, ByVal FechaPrograma As Date,
                                                   ByVal loteDe As Integer, ByVal loteHasta As Integer, ByVal pedidoSay As Integer,
                                                   ByVal pedidoSICY As Integer, ByVal apartado As String)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter("@Accion", accion)
        listaParametros.Add(parametro)
        parametro = New SqlParameter("@nave", nave)
        listaParametros.Add(parametro)
        parametro = New SqlParameter("@FechaPrograma", FechaPrograma)
        listaParametros.Add(parametro)
        parametro = New SqlParameter("@LoteDe", loteDe)
        listaParametros.Add(parametro)
        parametro = New SqlParameter("@LoteHasta", loteHasta)
        listaParametros.Add(parametro)
        parametro = New SqlParameter("@PedidoSicy", pedidoSay)
        listaParametros.Add(parametro)
        parametro = New SqlParameter("@PedidoSay", pedidoSICY)
        listaParametros.Add(parametro)
        parametro = New SqlParameter("@CadenaApartados", apartado)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_Etiquetas_ImprimirEtiquetasBattaOpcionesClienteProduccion_Plantilla]", listaParametros)

    End Function

    Public Function ConsultaArticulosSinImagenBatta(ByVal accion As Integer, ByVal nave As Integer, ByVal FechaPrograma As Date,
                                                   ByVal loteDe As Integer, ByVal loteHasta As Integer, ByVal pedidoSay As Integer,
                                                   ByVal pedidoSICY As Integer, ByVal apartado As String)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter("@Accion", accion)
        listaParametros.Add(parametro)
        parametro = New SqlParameter("@nave", nave)
        listaParametros.Add(parametro)
        parametro = New SqlParameter("@FechaPrograma", FechaPrograma)
        listaParametros.Add(parametro)
        parametro = New SqlParameter("@LoteDe", loteDe)
        listaParametros.Add(parametro)
        parametro = New SqlParameter("@LoteHasta", loteHasta)
        listaParametros.Add(parametro)
        parametro = New SqlParameter("@PedidoSicy", pedidoSay)
        listaParametros.Add(parametro)
        parametro = New SqlParameter("@PedidoSay", pedidoSICY)
        listaParametros.Add(parametro)
        parametro = New SqlParameter("@CadenaApartados", apartado)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_ConsultaArticulosSinImagenBatta]", listaParametros)

    End Function

    Public Function ValidacionDiseñoEtiquetaLengua(ByVal LoteInicio As Integer, ByVal Lotefin As Integer, ByVal NaveSICY As Integer, ByVal Año As Integer)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter("@loteInicio", LoteInicio)
        listaParametros.Add(parametro)
        parametro = New SqlParameter("@loteFin", Lotefin)
        listaParametros.Add(parametro)
        parametro = New SqlParameter("@naveID", NaveSICY)
        listaParametros.Add(parametro)
        parametro = New SqlParameter("@anio", Año)
        listaParametros.Add(parametro)


        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_EtiquetaLengua_validarEtiquetasFaltantes]", listaParametros)

    End Function

    Public Function ComandosImprimirEtiquetasSAY_V2SINGRF(ByVal Lotes As String, ByVal Nave As Integer, ByVal Año As Int32, ByVal ImpresoraId As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "lotes"
        parametro.Value = Lotes
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "nave"
        parametro.Value = Nave
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "anio"
        parametro.Value = Año
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ImpresoraSAYID"
        parametro.Value = ImpresoraId
        listaParametros.Add(parametro)

        'Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_ComandosImprimirEtiqueta_v2]", listaParametros)
        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_ComandosImprimirEtiqueta_v2_PPruebaSINGRF]", listaParametros)

    End Function

    Public Function ImprimeEtiquetasPriceShoes(ByVal ImpresoraID As Integer,
                                          ByVal UsuarioID As Integer,
                                          ByVal ClienteID As Integer,
                                          ByVal TipoEtiquetaID As Int16,
                                          ByVal MostrarDetalle As Boolean,
                                          ByVal PorLotes As Integer,
                                          ByVal Nave As Integer,
                                          ByVal FechaPrograma As Date,
                                          ByVal LoteDe As Integer,
                                          ByVal LoteHasta As Integer,
                                          ByVal PorPedido As Boolean,
                                          ByVal PedidoSICY As Integer,
                                          ByVal PedidoSAY As Integer,
                                          ByVal PorApartados As Boolean,
                                          ByVal CadenaApartados As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Try

            parametro.ParameterName = "@ImpresoraID"
            parametro.Value = ImpresoraID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@UsuarioID"
            parametro.Value = UsuarioID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@ClienteID"
            parametro.Value = ClienteID
            listaParametros.Add(parametro)

            'parametro = New SqlParameter
            'parametro.ParameterName = "@tipoetiquetaid"
            'parametro.Value = TipoEtiquetaID
            'listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@MostrarDetalle"
            parametro.Value = MostrarDetalle
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@PorLotes"
            parametro.Value = PorLotes
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@nave"
            parametro.Value = Nave
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@FechaPrograma"
            parametro.Value = FechaPrograma
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@LoteDe"
            parametro.Value = LoteDe
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@LoteHasta"
            parametro.Value = LoteHasta
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@PorPedido"
            parametro.Value = PorPedido
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@PedidoSicy"
            parametro.Value = PedidoSICY
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@PedidoSay"
            parametro.Value = PedidoSAY
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@PorApartados"
            parametro.Value = PorApartados
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@CadenaApartados"
            parametro.Value = CadenaApartados
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_Etiquetas_ImprimirEtiquetasPriceShoesLabelMatrix]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function ConsultaEtiquetasConsumosFechas(ByVal naveId As Integer, ByVal fechaPrograma As Date, ByVal fechaProgramaAl As Date, ByVal impresora As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro = New SqlParameter("@gNave", naveId)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@gPrograma", fechaPrograma)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@gProgramaAl", fechaProgramaAl)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@gImpresora", impresora)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_EtiquetasProveedorConsumosRangoFechas]", listaParametros)

    End Function

    Public Function ConsultaEtiquetasPlantaSuelaFechas(ByVal naveid As Integer, ByVal fechaPrograma As Date, ByVal fechaProgramaAl As Date, ByVal idProveedor As Integer, ByVal idLotes As Integer, ByVal Clasificacion As String, ByVal Impresora As Integer, ByVal grupo As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro = New SqlParameter("@IdNave", naveid)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@FECHA", fechaPrograma)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@FECHA_AL", fechaProgramaAl)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@IdProveedor", idProveedor)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@IdLotes", idLotes)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@Clasificacion", Clasificacion)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@Impresora", Impresora)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@Grupo", grupo)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_EtiquetasProveedorPlantaSuelaPorGrupoRangoFechas]", listaParametros)

    End Function

    Public Function ConsultaEtiquetasPlantaSuela_NavesFechas(ByVal navesId As String, ByVal fechaPrograma As Date, ByVal fechaProgramaAl As Date, ByVal idProveedor As Integer, ByVal idLotes As Integer, ByVal Clasificacion As String, ByVal Impresora As Integer, ByVal grupo As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro = New SqlParameter("@navesId", navesId)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@FECHA", fechaPrograma)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@FECHA_AL", fechaProgramaAl)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@IdProveedor", idProveedor)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@IdLotes", idLotes)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@Clasificacion", Clasificacion)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@Impresora", Impresora)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@Grupo", grupo)
        listaParametros.Add(parametro)

        If grupo = "RVO" Or grupo = "FVO" Then
            Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_EtiquetasProveedorPlantaSuelaPorGrupo_NavesRangoFechas]", listaParametros)
        Else
            Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_EtiquetasProveedorPlantaSuelaPorGrupo_NavesRangoFechasGrupos]", listaParametros)
        End If


    End Function

    Public Function ConsultaEtiquetasPlantilla_NavesFechas(ByVal navesId As String, ByVal fechaPrograma As Date, ByVal fechaProgramaAl As Date, ByVal idProveedor As Integer, ByVal idLotes As Integer, ByVal Impresora As Integer, ByVal grupo As String) As DataTable
        Dim objPersistencia = New Persistencia.OperacionesProcedimientos
        Dim listaParametro = New List(Of SqlParameter)

        Dim parametro = New SqlParameter("@fechaPrograma", fechaPrograma)
        listaParametro.Add(parametro)

        parametro = New SqlParameter("@fechaProgramaAl", fechaProgramaAl)
        listaParametro.Add(parametro)

        parametro = New SqlParameter("@navesId", navesId)
        listaParametro.Add(parametro)

        parametro = New SqlParameter("@idProveedor", idProveedor)
        listaParametro.Add(parametro)

        parametro = New SqlParameter("@idLote", idLotes)
        listaParametro.Add(parametro)

        parametro = New SqlParameter("@Impresora", Impresora)
        listaParametro.Add(parametro)

        parametro = New SqlParameter("@grupo", grupo)
        listaParametro.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_EtiquetasProveedorPlantillaInteligentePorGrupo_NavesRangoFechas]", listaParametro)

    End Function

    Public Function ConsultaEtiquetasPlantillaFechas(ByVal naveid As Integer, ByVal fechaPrograma As Date, ByVal fechaProgramaAl As Date, ByVal idProveedor As Integer, ByVal idLotes As Integer, ByVal Impresora As Integer, ByVal grupo As String) As DataTable
        Dim objPersistencia = New Persistencia.OperacionesProcedimientos
        Dim listaParametro = New List(Of SqlParameter)

        Dim parametro = New SqlParameter("@fechaPrograma", fechaPrograma)
        listaParametro.Add(parametro)

        parametro = New SqlParameter("@fechaProgramaAl", fechaProgramaAl)
        listaParametro.Add(parametro)

        parametro = New SqlParameter("@naveSICYId", naveid)
        listaParametro.Add(parametro)

        parametro = New SqlParameter("@idProveedor", idProveedor)
        listaParametro.Add(parametro)

        parametro = New SqlParameter("@idLote", idLotes)
        listaParametro.Add(parametro)

        parametro = New SqlParameter("@Impresora", Impresora)
        listaParametro.Add(parametro)

        parametro = New SqlParameter("@grupo", grupo)
        listaParametro.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_EtiquetasProveedorPlantillaInteligentePorGrupoFechas]", listaParametro)

    End Function

    Public Function ProveedorSuelaPorGrupoFechas(ByVal fechaPrograma As Date, ByVal fechaProgramaAL As Date, ByVal clasificacionProvSuela As Integer, ByVal grupo As String) As DataTable
        Dim objpersistencia As New Persistencia.OperacionesProcedimientos
        Dim objP As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)


        Dim parametro = New SqlParameter("@fechaPrograma", fechaPrograma)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@fechaProgramaAl", fechaProgramaAL)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@Clasificacion", clasificacionProvSuela)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@grupo", grupo)
        listaParametros.Add(parametro)

        Return objpersistencia.EjecutarConsultaSP("[Produccion].[SP_ConsultaSaySicyEtiquetasSuelaPorGrupoRangoFecha]", listaParametros)

    End Function

    Public Function ReporteControlEtiquetasProveedoresSuelas(ByVal fechaDel As Date, ByVal fechaAl As Date, ByVal IdProveedor As Integer)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter("@FechaDel", fechaDel)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@FechaAl", fechaAl)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@IdProveedor", IdProveedor)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_ReporteControlEtiquetasProveedoresSuelas]", listaParametros)

    End Function

    Public Function ProveedorSuelaRangoFechas(ByVal naveid As Integer, ByVal fechaPrograma As Date, ByVal fechaAl As Date, ByVal clasificacionProvSuela As Integer) As DataTable
        Dim objpersistencia As New Persistencia.OperacionesProcedimientos

        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro = New SqlParameter("@naveId", naveid)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@fechaPrograma", fechaPrograma)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@fechaAl", fechaAl)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@Clasificacion", clasificacionProvSuela)
        listaParametros.Add(parametro)

        Return objpersistencia.EjecutarConsultaSP("[Produccion].[SP_ConsultaSaySicyEtiquetasSuelaRangoFechas]", listaParametros)

    End Function

    Public Function ProveedorPlantaRangoFechas(ByVal naveid As Integer, ByVal fechaPrograma As Date, ByVal fechaAl As Date, ByVal clasificacionProvPlanta As Integer) As DataTable
        Dim objpersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)


        Dim parametro = New SqlParameter("@naveId", naveid)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@fechaPrograma", fechaPrograma)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@fechaAl", fechaAl)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@Clasificacion", clasificacionProvPlanta)
        listaParametros.Add(parametro)

        Return objpersistencia.EjecutarConsultaSP("[Produccion].[SP_ConsultaSaySicyEtiquetasPlantaRangoFechas]", listaParametros)

    End Function

    Public Function ProveedorPlantillaRangoFechas(ByVal naveid As Integer, ByVal fechaPrograma As Date, ByVal fechaAl As Date, ByVal clasificacionProvPlantilla As Integer) As DataTable
        Dim objpersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter("@naveId", naveid)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@fechaPrograma", fechaPrograma)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@fechaAl", fechaAl)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@Clasificacion", clasificacionProvPlantilla)
        listaParametros.Add(parametro)

        Return objpersistencia.EjecutarConsultaSP("[Produccion].[SP_ConsultaSaySicyEtiquetasPlantillaRangoFechas]", listaParametros)

    End Function

    Public Function ConsultarNavesSAY()
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Return persistencia.EjecutarConsultaSP("[Programacion].[Sp_ConsultaNavesSimulacion]", New List(Of SqlParameter))
    End Function

    Public Function ConsultaModelosAndrea(ByVal asignados As Integer)
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter("@asignados", asignados)
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("[Programacion].[SP_ConsultaModelosAndrea]", listaParametros)
    End Function

    Public Function GuardarModelosAndreaRastreo(ByVal xml As String)
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter("@xmlCeldas", xml)
        listaParametros.Add(parametro)
        Return persistencia.EjecutarConsultaSP("[Programacion].[SP_GuardarModelosAndreaRastreo]", listaParametros)
    End Function



    Public Function ObtenerImagenProductoEstilo(ByVal ProductoEstiloId As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@ProductoEstiloId"
            parametro.Value = ProductoEstiloId
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_Inventario_ObtenerImagenProductoEstilo]", listaParametros)

        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class
