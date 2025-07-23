Imports System.Collections.Generic
Imports System.Data.SqlClient

Public Class AdministradorDocumentosDA
    Public Function ConsultarDocumentos(ByVal conFecha As Integer,
                                         ByVal fechaInicio As Date,
                                         ByVal fechaFin As Date,
                                         ByVal restriccionF As Integer,
                                         ByVal docto As String,
                                         ByVal facturas As String,
                                         ByVal clientes As String,
                                        ByVal verCoppel As Integer) As DataTable

        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try

            parametro.ParameterName = "@conFecha"
            parametro.Value = conFecha
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@fechaInicio"
            parametro.Value = fechaInicio
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@fechaFin"
            parametro.Value = fechaFin
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@restriccionF"
            parametro.Value = restriccionF
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@doctos"
            parametro.Value = docto
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@Facturas"
            parametro.Value = facturas
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@Clientes"
            parametro.Value = clientes
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@verCoppel"
            parametro.Value = verCoppel
            listaParametros.Add(parametro)



            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_AdministradorDocumentos_ConsultarDocumentos]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ConsultarRestricciones() As DataTable

        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try


            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_AdministradorDocumentos_ConsultarRestricciones]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function ConsultarTiposContenidoEmbarque() As DataTable

        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_GuiasEmbarque_Consulta_TipodeContenido]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function ConsultarTransporte() As DataTable

        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_AdministradorDocumentos_ConsultarTrasporte]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function ConsultarOperadores() As DataTable

        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_AdministradorDocumentos_ListadoOperadoresAlmacen]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ConsultarTiposEmpaquesNM() As DataTable

        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_GuiasEmbarque_TipoEmpque]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ConsultarTiposEmpaquesOT() As DataTable

        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_GuiasEmbarque_TipoEmpqueOT]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function ConsultarTallas() As DataTable

        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_GuiasEmbarque_TallasActivas]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function ConsultarRemitentes() As DataTable

        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_GuiasEmbarque_ConsultarRemitente]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ConsultarClientes(ByVal activo As Integer) As DataTable

        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try

            parametro.ParameterName = "@activo"
            parametro.Value = activo
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_AdministradorDocumentos_ConsultarClientes]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ValidarDocumentos(ByVal documentos As String, ByVal usuario As Integer) As DataTable

        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try

            parametro.ParameterName = "@Documentos"
            parametro.Value = documentos
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@usuario"
            parametro.Value = usuario
            listaParametros.Add(parametro)


            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_AdministradorDocumentos_ValidarDocumentos]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ConsultarInformacionEmcabezado(ByVal embarqueid As Integer) As DataTable

        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try

            parametro.ParameterName = "@embarqueid"
            parametro.Value = embarqueid
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_InformacionEncabezadoEmbarque]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ConsultarInformacionEmcabezadoOtroEmbarque(ByVal embarqueid As Integer) As DataTable

        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try

            parametro.ParameterName = "@embarqueid"
            parametro.Value = embarqueid
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_InformacionEncabezadoOtrosEmbarques]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function EliminarDatosSession(ByVal embarqueid As Integer, session As Integer) As DataTable

        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try

            parametro.ParameterName = "@embarqueid"
            parametro.Value = embarqueid
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@sessionid"
            parametro.Value = session
            listaParametros.Add(parametro)


            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_AdministradorDocumentos_EliminarDatosSession]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function ConsultarDocumentosEmbarque(ByVal embarqueid As Integer) As DataTable

        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try

            parametro.ParameterName = "@embarqueid"
            parametro.Value = embarqueid
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_AdministradorDocumentos_ConsultarDocuemntosEmbarque]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ConsultarContenidoEmbarque(ByVal embarqueid As Integer, TipoEmpaque As Integer) As DataTable

        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try

            parametro.ParameterName = "@embarque"
            parametro.Value = embarqueid
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@tipoEmpaque"
            parametro.Value = TipoEmpaque
            listaParametros.Add(parametro)


            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_GuiasEmbarque_ConsultarContenidoEmbarque]", listaParametros)

        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function ConsultarNumeroCaja(ByVal embarqueid As Integer) As DataTable

        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try

            parametro.ParameterName = "@embarqueid"
            parametro.Value = embarqueid
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_GuiasEmbarque_ConsultarNumeroSiguienteCaja]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function AgregarCaja(numCaja As Integer, ByVal embarqueid As Integer, tipoempque As Integer, ByVal tamañoCajaId As Integer) As DataTable

        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro = New SqlParameter
            parametro.ParameterName = "@embarque"
            parametro.Value = embarqueid
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@pares"
            parametro.Value = 0
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@empaque"
            parametro.Value = tipoempque
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@numCaja"
            parametro.Value = numCaja
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@tamañoCajaId"
            parametro.Value = 0
            listaParametros.Add(parametro)

            ''Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_GuiasEmbarque_AgregarCaja]", listaParametros)
            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_GuiasEmbarque_AgregarCaja_v1]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function EditarCaja(numCaja As Integer, ByVal embarqueid As Integer, pares As Integer) As DataTable

        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try

            parametro.ParameterName = "@numCaja"
            parametro.Value = numCaja
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@embarque"
            parametro.Value = embarqueid
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@pares"
            parametro.Value = pares
            listaParametros.Add(parametro)




            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_GuiasEmbarque_EditarCaja]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function EliminarCaja(numCaja As Integer, ByVal embarqueid As Integer) As DataTable

        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try

            parametro.ParameterName = "@numCaja"
            parametro.Value = numCaja
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@EmbarqueID"
            parametro.Value = embarqueid
            listaParametros.Add(parametro)




            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_GuiasEmbarque_EliminarCaja]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ConsultarTallasCajas(numCaja As Integer, ByVal embarqueid As Integer, tallaId As Integer) As DataTable

        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try


            parametro.ParameterName = "@EmbarqueID"
            parametro.Value = embarqueid
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@numCaja"
            parametro.Value = numCaja
            listaParametros.Add(parametro)



            parametro = New SqlParameter
            parametro.ParameterName = "@tallaid"
            parametro.Value = tallaId
            listaParametros.Add(parametro)




            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_GuiasEmbarque_DetalleTallas]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function EditarParestallaCaja(ByVal detallecajaid As Integer, pares As Integer) As DataTable

        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try

            parametro.ParameterName = "@DetalleCajaID"
            parametro.Value = detallecajaid
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@Pares"
            parametro.Value = pares
            listaParametros.Add(parametro)




            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_GuiasEmbarque_ActualizarParesdetalleTalla]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function ConsultarDetalleTallaCajas(ByVal detallecajaid As Integer, pares As Integer) As DataTable

        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try

            parametro.ParameterName = "@EmbarqueID"
            parametro.Value = detallecajaid
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@numCaja"
            parametro.Value = pares
            listaParametros.Add(parametro)




            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_GuiasEmbarque_ConsultarDetalleTallaCaja]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function EditarOperadorEmbarco(ByVal embarqueid As Integer, operadorID As Integer) As DataTable

        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try

            parametro.ParameterName = "@EmbarqueID"
            parametro.Value = embarqueid
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@OperadorID"
            parametro.Value = operadorID
            listaParametros.Add(parametro)


            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_GuiasEmbarque_ModificarOperadorEmbarque]", listaParametros)

        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function EditarUnidadMedida(ByVal embarqueid As Integer, unidad As Integer) As DataTable

        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try

            parametro.ParameterName = "@EmbarqueID"
            parametro.Value = embarqueid
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@unidad"
            parametro.Value = unidad
            listaParametros.Add(parametro)


            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_GuiasEmbarque_ModificarUMedidaEmbarque]", listaParametros)

        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function consultarPatequerias(ByVal TiendaID As Integer) As DataTable

        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try

            parametro.ParameterName = "@tiendaEmbarque"
            parametro.Value = TiendaID
            listaParametros.Add(parametro)


            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_GuiasEmbarque_TrasportePaqueteria]", listaParametros)

        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function EditarPaqueteria(ByVal embarqueid As Integer, paqueteriaid As Integer) As DataTable

        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try

            parametro.ParameterName = "@embarqueid"
            parametro.Value = embarqueid
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@paqueteria"
            parametro.Value = paqueteriaid
            listaParametros.Add(parametro)


            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_GuiasEmbarque_ModificarPaqueteria]", listaParametros)

        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function Editarremitente(ByVal embarqueid As Integer, remitenteid As Integer) As DataTable

        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try

            parametro.ParameterName = "@embarqueid"
            parametro.Value = embarqueid
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@remitenteid"
            parametro.Value = remitenteid
            listaParametros.Add(parametro)


            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_GuiasEmbarque_modificarRemitente]", listaParametros)

        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function Editartalla(ByVal embarqueid As Integer, talla As Integer) As DataTable

        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try

            parametro.ParameterName = "@embarqueid"
            parametro.Value = embarqueid
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@talla"
            parametro.Value = talla
            listaParametros.Add(parametro)


            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_GuiasEmbarque_EditarSoliTalla]", listaParametros)

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function insertardatosfaltantes(ssesionid As Integer, usuario As Integer, reembarque As Integer) As DataTable

        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try

            parametro.ParameterName = "@ssesionid"
            parametro.Value = ssesionid
            listaParametros.Add(parametro)



            parametro = New SqlParameter
            parametro.ParameterName = "@usuario"
            parametro.Value = usuario
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@rembarque"
            parametro.Value = reembarque
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_GuiasEmbarque_InsertarDatosFaltantesEmbarque]", listaParametros)

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ValidarInfomacionCorrectaEmbarque(ByVal embarqueid As Integer) As DataTable

        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try

            parametro.ParameterName = "@sessionid"
            parametro.Value = embarqueid
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_GuiasEmbarqueValidarInformacionEmbarque]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ConsultarEmbarquesSession(ByVal sessionid As Integer) As DataTable

        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try

            parametro.ParameterName = "@sessionID"
            parametro.Value = sessionid
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_GuiasEmbarque_ConsultarEmbarquesPorSession]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ConsultarEtiquetasEmbarque(ByVal sessionID As Integer, ByVal embarquesid As String, ByVal impresionid As Integer, ByVal usuarioid As Integer, ByVal etiquetaEspecias As Integer) As DataTable

        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try

            parametro.ParameterName = "@sessionID"
            parametro.Value = sessionID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@embarquesid"
            parametro.Value = embarquesid
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@ImpresoraID"
            parametro.Value = impresionid
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@UsuarioID"
            parametro.Value = usuarioid
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@etiquetas"
            parametro.Value = etiquetaEspecias
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_GuiaEmbarque_ImprimirEtiquetas]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ConsultarEtiquetasOtrosEmbarque(ByVal sessionid As Integer, embarquesid As String, etiqueta As Integer, ByVal impresionid As Integer, ByVal usuarioid As Integer) As DataTable

        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try

            parametro.ParameterName = "@sessionID"
            parametro.Value = sessionid
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@embarquesid"
            parametro.Value = embarquesid
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@ImpresoraID"
            parametro.Value = impresionid
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@UsuarioID"
            parametro.Value = usuarioid
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@etiquetas"
            parametro.Value = etiqueta
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_GuiaEmbarque_ImprimirEtiquetas_OtrosEmbarques]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function ListaImpresoras() As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_Etiquetas_ConsultaImpresoras]", listaParametros)
    End Function
    Public Function ComandosImprimirEtiquetaGuiasEmbarque(ByVal impresoraid As Integer) As DataTable

        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try

            parametro.ParameterName = "@ImpresoraSAYID"
            parametro.Value = impresoraid
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_ComandosImprimirEtiquetaGuiasEmbarque]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function InsertarBitacoraImprecionGE(ByVal sessionid As Integer, embarqueid As String, ByVal usuarioid As Integer) As DataTable

        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try

            parametro.ParameterName = "@sessionID"
            parametro.Value = sessionid
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@embarquesid"
            parametro.Value = embarqueid
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@UsuarioID"
            parametro.Value = usuarioid
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_GuiasEmbarque_InsertarBitacoraImpresion]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ConsultarGuiasEmbarque(ByVal conFecha As Integer,
                                        ByVal fechaInicio As Date,
                                        ByVal fechaFin As Date,
                                        ByVal GuiasEmbarque As String,
                                        ByVal pendientesGuia As Integer,
                                        ByVal conGuiaRastreo As Integer,
                                           clientes As String,
                                           tipoempaque As Integer,
                                           estatus As String,
                                           transporte As String,
                                           atnCliente As String,
                                           pedidos As String,
                                           Ot As String,
                                           facturas As String,
                                           remision As String) As DataTable

        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try

            parametro.ParameterName = "@conFecha"
            parametro.Value = conFecha
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@fechaInicio"
            parametro.Value = fechaInicio
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@fechaFin"
            parametro.Value = fechaFin
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@guiaEmbarque"
            parametro.Value = GuiasEmbarque
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@pendientesGuia"
            parametro.Value = pendientesGuia
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@conGuiasRastreo"
            parametro.Value = conGuiaRastreo
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@clientes"
            parametro.Value = clientes
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@tipoEmbarque"
            parametro.Value = tipoempaque
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@estatus"
            parametro.Value = estatus
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@transporte"
            parametro.Value = transporte
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@clienteasing"
            parametro.Value = atnCliente
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@ots"
            parametro.Value = Ot
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@pedidossicy"
            parametro.Value = pedidos
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@facturas"
            parametro.Value = facturas
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@remisiones"
            parametro.Value = remision
            listaParametros.Add(parametro)




            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_AdministradorGuiasEmbarque_ConsultarGuiasEmbarque]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function ConsultarMensajerias() As DataTable

        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_GuiasEmbarque_Mensajerias]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function ConsultaExisteEmbarque(ByVal embarqueid As Integer, numguia As String, usuarioid As Integer, cartapoder As String, costoEnvio As Double) As DataTable

        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try

            parametro.ParameterName = "@Embarqueid"
            parametro.Value = embarqueid
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@numeroGuia"
            parametro.Value = numguia
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@usuarioID"
            parametro.Value = usuarioid
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@cartaP"
            parametro.Value = cartapoder
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@costo"
            parametro.Value = costoEnvio
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_AdministradorGuiasEmbarque_ExisteEmbarque]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function CancelarEmbarque(ByVal embarqueid As String) As DataTable

        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try

            parametro.ParameterName = "@Embarquesid"
            parametro.Value = embarqueid
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_AdministradorGuiasEmbarque_CancelarEmbarque]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function PonerEnRutaEmbarque(ByVal embarqueid As String, usuarioid As Integer) As DataTable

        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try

            parametro.ParameterName = "@Embarquesid"
            parametro.Value = embarqueid
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@usuarioID"
            parametro.Value = usuarioid
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_AdministradorGuiasEmbarque_PonerEnRutaEmbarque]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function PonerEntrgadoEmbarque(ByVal embarqueid As String, usuario As Integer) As DataTable

        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try

            parametro.ParameterName = "@embarquesid"
            parametro.Value = embarqueid
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@usuarioR"
            parametro.Value = usuario
            listaParametros.Add(parametro)


            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_AdministradorGuiasEmbarque_PonerEntregadoEmbarque]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GenerarArchivoCastores(ByVal embarques As String) As DataTable

        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try

            parametro.ParameterName = "@embarques"
            parametro.Value = embarques
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_AdministradorGuiasEmbarque_GenerarArchivoCastores]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ModificarBanderaGenerarArchivoCastores(ByVal embarques As String) As DataTable

        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try

            parametro.ParameterName = "@embarques"
            parametro.Value = embarques
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_AdministradorGuiasEmbarque_ModificarBanderaArchivoGenerado]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ConsultarOpcionesRembarque() As DataTable

        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_GuiasEmbarque_ConsultarOpcionesRembarque]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ConsultarOpcionesMensajerias() As DataTable

        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_GuiasEmbarque_ConsultarMensajerias]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ConsultarFolioFinal(ByVal usuarioid As Integer) As DataTable

        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try

            parametro.ParameterName = "@usuarioid"
            parametro.Value = usuarioid
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_GuiasEmbarque_ConsultarFolioFinal]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function EliminarSessionOtrosEmbarques(ByVal embarqueid As Integer) As DataTable

        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try

            parametro.ParameterName = "@embarqueid"
            parametro.Value = embarqueid
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_GuiasEmbarque_EliminarSessionOtrosEmbarques]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GuardarGuiaOtrosEmbarques(ByVal embarques As Entidades.InformacionEmbarque) As DataTable

        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try

            parametro.ParameterName = "@Embarqueid"
            parametro.Value = embarques.FolioEmbarque
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@contenido"
            parametro.Value = embarques.Contenido
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@remitente"
            parametro.Value = embarques.RemitenteID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@Consignatario"
            parametro.Value = embarques.Consignatario
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@solicita"
            parametro.Value = embarques.Solicita
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@ciudadid"
            parametro.Value = embarques.CiudadID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@Estadoid"
            parametro.Value = embarques.Estado
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@colonia"
            parametro.Value = embarques.Colonia
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@calle"
            parametro.Value = embarques.Calle
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@cp"
            parametro.Value = embarques.CP
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@noExt"
            parametro.Value = embarques.NumExt
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@noInt"
            parametro.Value = embarques.NumInt
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@transporte"
            parametro.Value = embarques.Transporte
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@tipoFlete"
            parametro.Value = embarques.FormaPago
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@rembarque"
            parametro.Value = embarques.Rembarque
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@descripcionContenido"
            parametro.Value = embarques.DescripcionContenido
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@costoEnvio"
            parametro.Value = embarques.CostoEnvio
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@telefono"
            parametro.Value = embarques.Telefono
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@lada"
            parametro.Value = embarques.Lada
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@observaciones"
            parametro.Value = embarques.Observaciones
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@contacto"
            parametro.Value = embarques.Contacto
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@unidadid"
            parametro.Value = embarques.UnidadMedida
            listaParametros.Add(parametro)



            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_GuiasEmbarque_GuardarOtrosEmbarques]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ConsultarTodoslosOperadores() As DataTable

        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_GuiasEmbarqueConsultarTodoslosColaboradores]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function consultarEstatusEmbarque(ByVal inicial As Integer) As DataTable

        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try

            parametro.ParameterName = "@inicial"
            parametro.Value = inicial
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_GuiasEmbarque_consultarEstatusEmbarque]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ReembarcarEmbarque(ByVal embarqueid As String, ByVal tipoEmbarque As Integer, ByVal usuario As Integer, motivo As String) As DataTable

        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try

            parametro.ParameterName = "@Embarqueid"
            parametro.Value = embarqueid
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@TipoEmbarque"
            parametro.Value = tipoEmbarque
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@usuario"
            parametro.Value = usuario
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@motivoRembarque"
            parametro.Value = motivo
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_AdministradorGuiasEmbarque_ReEmbarcar]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GuardarNumerosRastreos(ByVal embarqueid As String, ByVal numeroGuia As String, ByVal cartaPoder As String, usuarioid As Integer, costoEnvio As Double) As DataTable

        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try

            parametro.ParameterName = "@embarquesid"
            parametro.Value = embarqueid
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@numeroGuia"
            parametro.Value = numeroGuia
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@cartapoder"
            parametro.Value = cartaPoder
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@usuarioid"
            parametro.Value = usuarioid
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@costoEnvio"
            parametro.Value = costoEnvio
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_GuiasEmbarque_GuardarNumerosRastreos]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function ConsultarEtiquetasZapatoStylo(ByVal xmlCodigos As String, impresora As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@datos"
        parametro.Value = xmlCodigos
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@impresoraid"
        parametro.Value = impresora


        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_GuiasEmbarque_ConsultarEtiquetasZapatoStylo]", listaParametros)
    End Function

    Public Function BorrarCajas(ByVal embarqueid As String) As DataTable

        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try

            parametro.ParameterName = "@embarqueid"
            parametro.Value = embarqueid
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_GuiasEmbarqueBorrarCajas]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ConsultarMotivosRembarque() As DataTable

        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_GuiasEmbarque_ConsultarMotivosReembarque]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function ConsultarClientesEspeciales(ByVal clienteid As Integer) As DataTable

        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try

            parametro.ParameterName = "@clienteid"
            parametro.Value = clienteid
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_GuiasEmbarque_ConsultarClientesEspeciales]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function ActualizarTiendaEmbarques(ByVal embarques As Entidades.InformacionEmbarque) As DataTable

        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try

            parametro.ParameterName = "@FolioEmbarqueid"
            parametro.Value = embarques.FolioEmbarque
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@paisid"
            parametro.Value = embarques.PaisID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@ciudadid"
            parametro.Value = embarques.CiudadID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@EtadoID"
            parametro.Value = embarques.Estado
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@Colonia"
            parametro.Value = embarques.Colonia
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@calle"
            parametro.Value = embarques.Calle
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@cp"
            parametro.Value = embarques.CP
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@numExt"
            parametro.Value = embarques.NumExt
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@numInt"
            parametro.Value = embarques.NumInt
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@telefono"
            parametro.Value = embarques.Telefono
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@consignatario"
            parametro.Value = embarques.Consignatario
            listaParametros.Add(parametro)




            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_GuiasEmbarque_ActualizarTienda]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function ConsultarTipoEmbarque(ByVal embarqueid As String) As DataTable

        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try

            parametro.ParameterName = "@embarqueid"
            parametro.Value = embarqueid
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_GuiasEmbarque_ConsultarTipoEmbarque]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function ConsultarMensjaeriaFiltro() As DataTable

        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try

            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_GuiasEmbarque_ConsultarMensajerias_Filtro]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ConsultarReporteEstadistica(ByVal conFecha As Integer,
                                       ByVal fechaInicio As Date,
                                       ByVal fechaFin As Date,
                                       ByVal GuiasEmbarque As String,
                                       ByVal pendientesGuia As Integer,
                                       ByVal conGuiaRastreo As Integer,
                                          clientes As String,
                                          tipoempaque As Integer,
                                          estatus As String,
                                          transporte As String) As DataTable

        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try

            parametro.ParameterName = "@conFecha"
            parametro.Value = conFecha
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@fechaInicio"
            parametro.Value = fechaInicio
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@fechaFin"
            parametro.Value = fechaFin
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@guiaEmbarque"
            parametro.Value = GuiasEmbarque
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@pendientesGuia"
            parametro.Value = pendientesGuia
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@conGuiasRastreo"
            parametro.Value = conGuiaRastreo
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@clientes"
            parametro.Value = clientes
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@tipoEmbarque"
            parametro.Value = tipoempaque
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@estatus"
            parametro.Value = estatus
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@transporte"
            parametro.Value = transporte
            listaParametros.Add(parametro)




            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_GuiasEmbarque_Reporte_EstadisticasPaqueteria]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function Consultar_ReporteEstadisticaTotalEmpaques(ByVal conFecha As Integer,
                                      ByVal fechaInicio As Date,
                                      ByVal fechaFin As Date,
                                      ByVal GuiasEmbarque As String,
                                      ByVal pendientesGuia As Integer,
                                      ByVal conGuiaRastreo As Integer,
                                         clientes As String,
                                         tipoempaque As Integer,
                                         estatus As String,
                                         transporte As String) As DataTable

        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try

            parametro.ParameterName = "@conFecha"
            parametro.Value = conFecha
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@fechaInicio"
            parametro.Value = fechaInicio
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@fechaFin"
            parametro.Value = fechaFin
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@guiaEmbarque"
            parametro.Value = GuiasEmbarque
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@pendientesGuia"
            parametro.Value = pendientesGuia
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@conGuiasRastreo"
            parametro.Value = conGuiaRastreo
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@clientes"
            parametro.Value = clientes
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@tipoEmbarque"
            parametro.Value = tipoempaque
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@estatus"
            parametro.Value = estatus
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@transporte"
            parametro.Value = transporte
            listaParametros.Add(parametro)




            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_GuiasEmbarque_ReporteEstadisticaTotalEmpaques]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function Consultar_ReporteEstadisticaFechas(ByVal conFecha As Integer,
                                      ByVal fechaInicio As Date,
                                      ByVal fechaFin As Date,
                                      ByVal GuiasEmbarque As String,
                                      ByVal pendientesGuia As Integer,
                                      ByVal conGuiaRastreo As Integer,
                                         clientes As String,
                                         tipoempaque As Integer,
                                         estatus As String,
                                         transporte As String) As DataTable

        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try

            parametro.ParameterName = "@conFecha"
            parametro.Value = conFecha
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@fechaInicio"
            parametro.Value = fechaInicio
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@fechaFin"
            parametro.Value = fechaFin
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@guiaEmbarque"
            parametro.Value = GuiasEmbarque
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@pendientesGuia"
            parametro.Value = pendientesGuia
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@conGuiasRastreo"
            parametro.Value = conGuiaRastreo
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@clientes"
            parametro.Value = clientes
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@tipoEmbarque"
            parametro.Value = tipoempaque
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@estatus"
            parametro.Value = estatus
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@transporte"
            parametro.Value = transporte
            listaParametros.Add(parametro)




            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_GuiasEmbarqueReporteEstadisticaFechas]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ConsultarAtnClienteFiltro() As DataTable

        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try

            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_GuiasEmbarque_ConsultarColaboradorAtnCliente]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function ConsultarAtnClienteInfo(ByVal colaboradorid As Integer) As DataTable

        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@colaboradorid"
            parametro.Value = colaboradorid
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_GuiasEmbarque_ConsultarInfoColaboradorAtnCliente]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function



    Public Function ValidarClientesGuiaEmbarqueDinamico(ByVal Documentos As String) As DataTable

        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@documentos"
            parametro.Value = Documentos
            listaParametros.Add(parametro)



            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_GuiaEmbarqueDinamico_ValidarDocumentos]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GenerarInformacionGuiaEmbarqueDinamico(ByVal Documentos As String, ByVal UsuarioId As Integer) As DataTable

        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@documentos"
            parametro.Value = Documentos
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@usuario"
            parametro.Value = UsuarioId
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_GuiaEmbarqueDinamico_GenerarInformacionEmbarque]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function ObtenerRFCDocumentos(ByVal Documentos As String) As DataTable

        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@documentos"
            parametro.Value = Documentos
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_GuiaEmbarqueDinamico_ObtenerRFC]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ObtenerTiendas(ByVal Documentos As String, ByVal RFCID As Integer) As DataTable

        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@documentos"
            parametro.Value = Documentos
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@RFCID"
            parametro.Value = RFCID
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_GuiaEmbarqueDinamico_ObtenerTiendas]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ObtenerDomicilioTienda(ByVal EmbarqueID As Integer, ByVal TiendaEmbarqueID As Integer, ByVal RFCID As Integer) As DataTable

        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try

            parametro.ParameterName = "@EmbarqueID"
            parametro.Value = EmbarqueID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@TiendaEmbarqueID"
            parametro.Value = TiendaEmbarqueID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@RFCID"
            parametro.Value = RFCID
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_GuiaEmbarqueDinamico_ObtenerInformacionTienda]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function InsertarInformacionFaltanteGuiaEmbarqueDinamico(ByVal objInformacionGuiaEmbarque As Entidades.InformacionEmbarque, ByVal UsuarioId As Integer) As DataTable

        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try

            parametro.ParameterName = "@EmbarqueID"
            parametro.Value = objInformacionGuiaEmbarque.FolioEmbarque
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@EmisorID"
            parametro.Value = objInformacionGuiaEmbarque.Emisorid
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@RFCClienteID"
            parametro.Value = objInformacionGuiaEmbarque.RFCClienteID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@TiendaId"
            parametro.Value = objInformacionGuiaEmbarque.TiendaID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@EmbarcoID"
            parametro.Value = objInformacionGuiaEmbarque.Embarco
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@PaisID"
            parametro.Value = objInformacionGuiaEmbarque.PaisID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@EstadoID"
            parametro.Value = objInformacionGuiaEmbarque.EstadoID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@CiudadId"
            parametro.Value = objInformacionGuiaEmbarque.CiudadID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@TransporteId"
            parametro.Value = objInformacionGuiaEmbarque.Transporte
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@TipoFlejeID"
            parametro.Value = objInformacionGuiaEmbarque.Tipofleje
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@FormaPago"
            parametro.Value = objInformacionGuiaEmbarque.FormaPago
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@Direccion"
            parametro.Value = objInformacionGuiaEmbarque.Direccion
            listaParametros.Add(parametro)


            parametro = New SqlParameter
            parametro.ParameterName = "@Calle"
            parametro.Value = objInformacionGuiaEmbarque.Calle
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@Colonia"
            parametro.Value = objInformacionGuiaEmbarque.Colonia
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@CP"
            parametro.Value = objInformacionGuiaEmbarque.CP
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@NumeroInterior"
            parametro.Value = objInformacionGuiaEmbarque.NumInt
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@NumeroExterior"
            parametro.Value = objInformacionGuiaEmbarque.NumExt
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@UsuarioId"
            parametro.Value = UsuarioId
            listaParametros.Add(parametro)



            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_GuiaEmbarqueDinamico_InsertarInformacionFaltante]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function CerrarSessionGuiaEmbarqueDinamico(ByVal UsuarioId As Integer) As DataTable

        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try

            parametro.ParameterName = "@usuarioID"
            parametro.Value = UsuarioId
            listaParametros.Add(parametro)


            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_GuiaEmbarqueDinamico_CerrarSession]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function obtenerTamañosCajasEmbarques() As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_GuiasEmbarque_ObtenerTamañoCajas]", listaParametros)
    End Function
    Public Sub actualizaTamañoCaja(ByVal cajaId As Integer, ByVal folioEmbarque As Integer, ByVal detalleFolioEmbarque As Integer)
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter = Nothing

        parametro = New SqlParameter("@tamañoCajaId", cajaId)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@folioEmbarqueId", folioEmbarque)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@detalleFolioEmbarque", detalleFolioEmbarque)
        listaParametros.Add(parametro)

        objOperaciones.EjecutarSentenciaSP("[Almacen].[SP_GuiasEmbarque_ActualizaTamañoCajaId]", listaParametros)
    End Sub
    Public Sub eliminaDetalleCajaEmbarque(ByVal detalleCajaId As Integer)
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter = Nothing

        parametro = New SqlParameter("@detalleIdEmbarque", detalleCajaId)
        listaParametros.Add(parametro)

        objOperaciones.EjecutarSentenciaSP("[Almacen].[SP_GuiasEmbarque_EliminaDetalleCaja]", listaParametros)
    End Sub
End Class
