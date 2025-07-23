Public Class AdministradorDocumentosBU
    Public Function ConsultarDocumentos(ByVal conFecha As Integer,
                                         ByVal fechaInicio As Date,
                                         ByVal fechaFin As Date,
                                         ByVal restriccionF As Integer,
                                         ByVal docto As String,
                                         ByVal facturas As String,
                                         ByVal clientes As String,
                                        ByVal verCoppel As Integer) As DataTable

        Dim objDA As New Datos.AdministradorDocumentosDA
        Dim tabla As New DataTable
        tabla = objDA.ConsultarDocumentos(conFecha, fechaInicio, fechaFin, restriccionF, docto, facturas, clientes, verCoppel)
        Return tabla
    End Function
    Public Function ConsultarRestricciones() As DataTable

        Dim objDA As New Datos.AdministradorDocumentosDA
        Dim tabla As New DataTable
        tabla = objDA.ConsultarRestricciones()
        Return tabla

    End Function
    Public Function ConsultarTiposContenidoEmbarque() As DataTable

        Dim objDA As New Datos.AdministradorDocumentosDA
        Dim tabla As New DataTable
        tabla = objDA.ConsultarTiposContenidoEmbarque()
        Return tabla

    End Function
    Public Function ConsultarTransporte() As DataTable

        Dim objDA As New Datos.AdministradorDocumentosDA
        Dim tabla As New DataTable
        tabla = objDA.ConsultarTransporte()
        Return tabla

    End Function
    Public Function ConsultarOperadores() As DataTable

        Dim objDA As New Datos.AdministradorDocumentosDA
        Dim tabla As New DataTable
        tabla = objDA.ConsultarOperadores()
        Return tabla
    End Function
    Public Function ConsultarTiposEmpaquesNM() As DataTable

        Dim objDA As New Datos.AdministradorDocumentosDA
        Dim tabla As New DataTable
        tabla = objDA.ConsultarTiposEmpaquesNM()
        Return tabla
    End Function

    Public Function ConsultarTiposEmpaquesOT() As DataTable

        Dim objDA As New Datos.AdministradorDocumentosDA
        Dim tabla As New DataTable
        tabla = objDA.ConsultarTiposEmpaquesOT()
        Return tabla
    End Function
    Public Function ConsultarTallas() As DataTable

        Dim objDA As New Datos.AdministradorDocumentosDA
        Dim tabla As New DataTable
        tabla = objDA.ConsultarTallas()
        Return tabla
    End Function
    Public Function ConsultarRemitentes() As DataTable

        Dim objDA As New Datos.AdministradorDocumentosDA
        Dim tabla As New DataTable
        tabla = objDA.ConsultarRemitentes()
        Return tabla
    End Function

    Public Function ConsultarClientes(ByVal activo As Integer) As DataTable

        Dim objDA As New Datos.AdministradorDocumentosDA
        Dim tabla As New DataTable
        tabla = objDA.ConsultarClientes(activo)
        Return tabla

    End Function



    Public Function ValidarDocumentos(ByVal documentos As String, ByVal usuario As Integer) As List(Of Entidades.NivelDocumentos)

        Dim objDA As New Datos.AdministradorDocumentosDA
        Dim tabla As New DataTable
        Dim listaDocumentos As New List(Of Entidades.NivelDocumentos)

        tabla = objDA.ValidarDocumentos(documentos, usuario)

        If tabla.Rows(0).Item("Documentoid") <> "0" Then


            For documentoJuntos = 0 To tabla.Rows.Count - 1
                Dim documentosConcatenados = tabla.Rows(documentoJuntos).Item("Documentoid")
                Dim hoja = tabla.Rows(documentoJuntos).Item("Nivel")
                Dim TotalLVL = tabla.Rows(documentoJuntos).Item("TotalLVL")
                Dim embarque = tabla.Rows(documentoJuntos).Item("EmbarqueID")
                Dim ArrCadena As String() = CStr(documentosConcatenados).Split(",")
                For DocumentosSeparados = 0 To ArrCadena.Count - 1
                    Dim DocumentoConNivel As New Entidades.NivelDocumentos
                    DocumentoConNivel.Documento = ArrCadena(DocumentosSeparados)
                    DocumentoConNivel.Nivel = hoja
                    DocumentoConNivel.TotalNivel = TotalLVL
                    DocumentoConNivel.Embarque = embarque
                    listaDocumentos.Add(DocumentoConNivel)
                Next
            Next
        Else

            Dim DocumentoConNivel As New Entidades.NivelDocumentos
            Dim enti_Error As New Entidades.ErrorEmbarque
            DocumentoConNivel.Documento = 0
            enti_Error.Error = 1
            enti_Error.Mensaje = tabla.Rows(0).Item("Error")
            DocumentoConNivel.Error = enti_Error
            listaDocumentos.Add(DocumentoConNivel)

        End If


        Return listaDocumentos

    End Function

    Public Function ConsultarInformacionEmcabezado(ByVal EmbarqueID As Integer) As Entidades.InformacionEmbarque

        Dim objDA As New Datos.AdministradorDocumentosDA
        Dim tabla As New DataTable
        Dim Embarque As New Entidades.InformacionEmbarque

        tabla = objDA.ConsultarInformacionEmcabezado(EmbarqueID)
        If tabla.Rows.Count > 0 Then

            If tabla.Rows(0).Item("EmbarqueID") <> "0" Then

                Embarque.FolioEmbarque = tabla.Rows(0).Item("EmbarqueID")
                Embarque.Tienda = tabla.Rows(0).Item("Tienda")
                Embarque.TiendaID = tabla.Rows(0).Item("TiendaID")
                Embarque.PaisID = tabla.Rows(0).Item("PaisID")
                Embarque.Ciudad = tabla.Rows(0).Item("Ciudad")
                Embarque.Estado = tabla.Rows(0).Item("Estado")
                Embarque.EstadoID = tabla.Rows(0).Item("EstadoID")
                Embarque.Direccion = tabla.Rows(0).Item("Domicilio")
                Embarque.Colonia = tabla.Rows(0).Item("Colonia")
                Embarque.CP = tabla.Rows(0).Item("CP")
                Embarque.NumExt = tabla.Rows(0).Item("NumExterior")
                Embarque.NumInt = tabla.Rows(0).Item("NumInterior")
                Embarque.Remitente = tabla.Rows(0).Item("Razon Social")
                Embarque.RemitenteID = tabla.Rows(0).Item("Razon Socialid")
                Embarque.Tipofleje = tabla.Rows(0).Item("TipoFlejeID")
                Embarque.FormaPago = tabla.Rows(0).Item("Forma Pago")
                Embarque.Embarco = tabla.Rows(0).Item("Operador")
                Embarque.UnidadMedida = tabla.Rows(0).Item("UMedida")
                Embarque.CiudadID = tabla.Rows(0).Item("ciudadid")
                Embarque.Transporte = tabla.Rows(0).Item("Paqueteria")
                Embarque.Solitalla = If(CBool(tabla.Rows(0).Item("soliTalla")) = True, 1, 0)
                Embarque.Session = tabla.Rows(0).Item("SessionUser")
                Embarque.Rembarque = tabla.Rows(0).Item("Reembarque")
                Embarque.Clienteid = tabla.Rows(0).Item("ClienteID")
                Embarque.Telefono = tabla.Rows(0).Item("Telefono")

            Else

                Dim errorSQL As New Entidades.ErrorEmbarque
                errorSQL.Error = 1
                errorSQL.Mensaje = tabla.Rows(0).Item("Error")

            End If
        Else
            Dim alv As New Entidades.ErrorEmbarque
            alv.Error = 1
            alv.Mensaje = "No hay datos"
        End If

        Return Embarque

    End Function
    Public Function ConsultarInformacionEmcabezadoOtrosEmbarques(ByVal EmbarqueID As Integer) As Entidades.InformacionEmbarque

        Dim objDA As New Datos.AdministradorDocumentosDA
        Dim tabla As New DataTable
        Dim Embarque As New Entidades.InformacionEmbarque

        tabla = objDA.ConsultarInformacionEmcabezadoOtroEmbarque(EmbarqueID)
        If tabla.Rows.Count > 0 Then

            If tabla.Rows(0).Item("EmbarqueID") <> "0" Then

                Embarque.FolioEmbarque = tabla.Rows(0).Item("EmbarqueID")
                Embarque.Consignatario = tabla.Rows(0).Item("Tienda")
                Embarque.TiendaID = tabla.Rows(0).Item("TiendaID")
                Embarque.CiudadID = tabla.Rows(0).Item("CiudadID")
                Embarque.EstadoID = tabla.Rows(0).Item("EstadoID")
                Embarque.Calle = tabla.Rows(0).Item("Calle")
                Embarque.Colonia = tabla.Rows(0).Item("Colonia")
                Embarque.CP = tabla.Rows(0).Item("CP")
                Embarque.NumExt = tabla.Rows(0).Item("NumeroExterior")
                Embarque.NumInt = tabla.Rows(0).Item("NumeroInterior")
                Embarque.Remitente = tabla.Rows(0).Item("Razon Social")
                Embarque.RemitenteID = tabla.Rows(0).Item("Razon Socialid")
                Embarque.Tipofleje = tabla.Rows(0).Item("Forma Pago")
                Embarque.Solicita = tabla.Rows(0).Item("Operador")
                Embarque.Transporte = tabla.Rows(0).Item("Paqueteria")
                Embarque.Lada = tabla.Rows(0).Item("Lada")
                Embarque.Telefono = tabla.Rows(0).Item("Telefono")
                Embarque.Observaciones = tabla.Rows(0).Item("Observaciones")
                Embarque.Session = tabla.Rows(0).Item("SessionUser")
                Embarque.PaisID = tabla.Rows(0).Item("PaisID")
                Embarque.Contenido = tabla.Rows(0).Item("Contenido")
                Embarque.Especifica = tabla.Rows(0).Item("Especifica")
                Embarque.CostoEnvio = tabla.Rows(0).Item("CostoEnvio")
                Embarque.Contacto = tabla.Rows(0).Item("Contacto")
                Embarque.UnidadMedida = tabla.Rows(0).Item("UnidadID")
                Embarque.Rembarque = tabla.Rows(0).Item("Rembarque")
            Else

                Dim errorSQL As New Entidades.ErrorEmbarque
                errorSQL.Error = 1
                errorSQL.Mensaje = tabla.Rows(0).Item("Error")

            End If
        Else
            Dim alv As New Entidades.ErrorEmbarque
            Error alv.Error = 1
            Error alv.Mensaje = "No hay datos"
        End If

        Return Embarque

    End Function
    Public Function EliminarDatosSession(ByVal EmbarqueID As Integer, sessionid As Integer) As Entidades.ErrorEmbarque

        Dim objDA As New Datos.AdministradorDocumentosDA
        Dim tabla As New DataTable
        Dim Embarque As New Entidades.ErrorEmbarque

        tabla = objDA.EliminarDatosSession(EmbarqueID, sessionid)

        If tabla.Rows(0).Item("Error") = "0" Then

            Embarque.Error = 0
        Else

            Embarque.Error = 1
            Embarque.Mensaje = tabla.Rows(0).Item("Mensaje")

        End If


        Return Embarque

    End Function
    'Public Function DatosVWCAJA() As DataTable

    '    Dim objDA As New Datos.AdministradorDocumentosDA
    '    Dim tabla = objDA.DatosVWCAJA()
    '    Return tabla

    'End Function

    Public Function ConsultarDocumentosEmbarque(ByVal EmbarqueID As Integer) As Entidades.ListadoDocumentosEmbarque

        Dim objDA As New Datos.AdministradorDocumentosDA
        Dim tabla As New DataTable
        Dim resultado As New Entidades.ListadoDocumentosEmbarque
        Dim listaDocumentos As New List(Of Entidades.DocumentosEmbarque)
        Dim totalpares As Integer = 0
        Try
            tabla = objDA.ConsultarDocumentosEmbarque(EmbarqueID)
            If tabla.Rows.Count > 0 Then
                If tabla.Rows(0).Item("Error") = "0" Then
                    For index = 0 To tabla.Rows.Count - 1
                        Dim Documento As New Entidades.DocumentosEmbarque

                        Documento.Factura = tabla.Rows(index).Item("Factura")
                        Documento.Documento = tabla.Rows(index).Item("Documento")
                        Documento.ClienteID = tabla.Rows(index).Item("ClienteID")
                        Documento.Cliente = tabla.Rows(index).Item("Cliente")
                        Documento.Importe = tabla.Rows(index).Item("Importe")
                        Documento.Pares = tabla.Rows(index).Item("Pares")
                        totalpares = totalpares + Documento.Pares
                        listaDocumentos.Add(Documento)

                    Next
                    resultado.Error = False
                    resultado.ListadoDocumentos = listaDocumentos
                    resultado.TotalPares = totalpares
                Else

                    resultado.Error = True
                    resultado.Mensaje = tabla.Rows(0).Item("Mensaje")
                End If
            End If
            Return resultado

        Catch ex As Exception
            resultado.Error = True
            resultado.Mensaje = ex.Message
        End Try


    End Function
    Public Function AgregarCaja(numCaja As Integer, ByVal embarqueid As Integer, tipoempque As Integer, ByVal tamañocajaId As Integer) As DataTable

        Dim objDA As New Datos.AdministradorDocumentosDA
        Dim tabla As New DataTable

        tabla = objDA.AgregarCaja(numCaja, embarqueid, tipoempque, tamañocajaId)
        Return tabla
    End Function
    Public Function EditarCaja(numCaja As Integer, ByVal embarqueid As Integer, pares As Integer) As Entidades.ErrorEmbarque

        Dim objDA As New Datos.AdministradorDocumentosDA
        Dim tabla As New DataTable
        Dim Documento As New Entidades.ErrorEmbarque

        tabla = objDA.EditarCaja(numCaja, embarqueid, pares)

        For index = 0 To tabla.Rows.Count - 1

            Documento.Error = tabla.Rows(index).Item("Error")
            Documento.Mensaje = tabla.Rows(index).Item("Mensaje")
        Next

        Return Documento

    End Function
    Public Function EditarParesTallaCaja(ByVal detalletallaid As Integer, pares As Integer) As Entidades.ErrorEmbarque

        Dim objDA As New Datos.AdministradorDocumentosDA
        Dim tabla As New DataTable
        Dim Documento As New Entidades.ErrorEmbarque

        tabla = objDA.EditarParestallaCaja(detalletallaid, pares)

        For index = 0 To tabla.Rows.Count - 1

            Documento.Error = tabla.Rows(index).Item("Error")
            Documento.Mensaje = tabla.Rows(index).Item("Mensaje")
        Next

        Return Documento

    End Function

    Public Function ConsultarDetalleTallaCajas(ByVal EmbarqueID As Integer, numCaja As Integer) As DataTable

        Dim objDA As New Datos.AdministradorDocumentosDA
        Dim tabla As New DataTable
        Dim Documento As New Entidades.ErrorEmbarque

        tabla = objDA.ConsultarDetalleTallaCajas(EmbarqueID, numCaja)

        Return tabla

    End Function


    Public Function ConsultarTallasCaja(numCaja As Integer, ByVal embarqueid As Integer, Tallaid As Integer) As Entidades.ListadoTallasEmbarque

        Dim objDA As New Datos.AdministradorDocumentosDA
        Dim tabla As New DataTable
        Dim listaTallas As New Entidades.ListadoTallasEmbarque
        Dim tallas As New List(Of Entidades.TallasEmbarques)

        tabla = objDA.ConsultarTallasCajas(numCaja, embarqueid, Tallaid)
        If tabla.Rows(0).Item("Error") = "0" Then
            For index = 0 To tabla.Rows.Count - 1
                Dim entTallas As New Entidades.TallasEmbarques
                entTallas.ID = tabla.Rows(index).Item("ID")
                entTallas.Talla = tabla.Rows(index).Item("Talla")
                entTallas.Pares = tabla.Rows(index).Item("Pares")

                tallas.Add(entTallas)

            Next
            Dim entError As New Entidades.ErrorEmbarque
            entError.Error = 0
            listaTallas.ErrorTallas = entError
            listaTallas.ListaTallas = tallas
        Else
            Dim entError As New Entidades.ErrorEmbarque
            entError.Error = 1
            entError.Mensaje = tabla.Rows(0).Item("Mensaje")
            listaTallas.ErrorTallas = entError
        End If


        Return listaTallas

    End Function
    Public Function EliminarCaja(numCaja As Integer, ByVal embarqueid As Integer) As Entidades.ErrorEmbarque

        Dim objDA As New Datos.AdministradorDocumentosDA
        Dim tabla As New DataTable
        Dim Documento As New Entidades.ErrorEmbarque

        tabla = objDA.EliminarCaja(numCaja, embarqueid)

        For index = 0 To tabla.Rows.Count - 1

            Documento.Error = tabla.Rows(index).Item("Error")
            Documento.Mensaje = tabla.Rows(index).Item("Mensaje")
        Next

        Return Documento

    End Function

    Public Function ConsultarNumeroCaja(ByVal EmbarqueID As Integer) As DataTable

        Dim objDA As New Datos.AdministradorDocumentosDA
        Dim tabla As New DataTable

        tabla = objDA.ConsultarNumeroCaja(EmbarqueID)
        Return tabla
    End Function


    Public Function ConsultarContenidoEmbarque(ByVal EmbarqueID As Integer, tipoempaque As Integer) As DataTable

        Dim objDA As New Datos.AdministradorDocumentosDA
        Dim tabla As New DataTable
        tabla = objDA.ConsultarContenidoEmbarque(EmbarqueID, tipoempaque)
        Return tabla

    End Function

    Public Function EditarOperadorEmbarco(ByVal embarcoID As Integer, OperadorID As Integer) As Entidades.ErrorEmbarque

        Dim objDA As New Datos.AdministradorDocumentosDA
        Dim tabla As New DataTable
        Dim Documento As New Entidades.ErrorEmbarque

        tabla = objDA.EditarOperadorEmbarco(embarcoID, OperadorID)

        For index = 0 To tabla.Rows.Count - 1

            Documento.Error = tabla.Rows(index).Item("Error")
            Documento.Mensaje = tabla.Rows(index).Item("Mensaje")
        Next

        Return Documento

    End Function
    Public Function EditarUnidadMedida(ByVal embarcoID As Integer, unidad As Integer) As Entidades.ErrorEmbarque

        Dim objDA As New Datos.AdministradorDocumentosDA
        Dim tabla As New DataTable
        Dim Documento As New Entidades.ErrorEmbarque

        tabla = objDA.EditarUnidadMedida(embarcoID, unidad)

        For index = 0 To tabla.Rows.Count - 1

            Documento.Error = tabla.Rows(index).Item("Error")
            Documento.Mensaje = tabla.Rows(index).Item("Mensaje")
        Next

        Return Documento

    End Function
    Public Function ConsultarPaqueterias(ByVal tiendaid As Integer) As DataTable

        Dim objDA As New Datos.AdministradorDocumentosDA
        Dim tabla As New DataTable

        tabla = objDA.consultarPatequerias(tiendaid)


        Return tabla

    End Function


    Public Function EditarPaqueteria(ByVal embarcoID As Integer, paqueteriaid As Integer) As Entidades.ErrorEmbarque

        Dim objDA As New Datos.AdministradorDocumentosDA
        Dim tabla As New DataTable
        Dim Documento As New Entidades.ErrorEmbarque

        tabla = objDA.EditarPaqueteria(embarcoID, paqueteriaid)

        For index = 0 To tabla.Rows.Count - 1

            Documento.Error = tabla.Rows(index).Item("Error")
            Documento.Mensaje = tabla.Rows(index).Item("Mensaje")
        Next

        Return Documento

    End Function

    Public Function EditarRemitente(ByVal embarcoID As Integer, remitenteid As Integer) As Entidades.ErrorEmbarque

        Dim objDA As New Datos.AdministradorDocumentosDA
        Dim tabla As New DataTable
        Dim Documento As New Entidades.ErrorEmbarque

        tabla = objDA.Editarremitente(embarcoID, remitenteid)

        For index = 0 To tabla.Rows.Count - 1

            Documento.Error = tabla.Rows(index).Item("Error")
            Documento.Mensaje = tabla.Rows(index).Item("Mensaje")
        Next

        Return Documento

    End Function
    Public Function Editartalla(ByVal embarcoID As Integer, talla As Integer) As Entidades.ErrorEmbarque

        Dim objDA As New Datos.AdministradorDocumentosDA
        Dim tabla As New DataTable
        Dim Documento As New Entidades.ErrorEmbarque

        tabla = objDA.Editartalla(embarcoID, talla)

        For index = 0 To tabla.Rows.Count - 1

            Documento.Error = tabla.Rows(index).Item("Error")
            Documento.Mensaje = tabla.Rows(index).Item("Mensaje")
        Next

        Return Documento

    End Function

    Public Function insertardatosfaltantes(ssesionid As Integer, usuario As Integer, reembarque As Integer) As Entidades.ErrorEmbarque
        Dim objDA As New Datos.AdministradorDocumentosDA
        Dim tabla As New DataTable
        Dim Documento As New Entidades.ErrorEmbarque
        tabla = objDA.insertardatosfaltantes(ssesionid, usuario, reembarque)

        For index = 0 To tabla.Rows.Count - 1

            Documento.Error = tabla.Rows(index).Item("Error")
            Documento.Mensaje = tabla.Rows(index).Item("Mensaje")
        Next

        Return Documento

    End Function

    Public Function ValidarInformacionEmbarque(ByVal EmbarqueID As Integer) As DataTable

        Dim objDA As New Datos.AdministradorDocumentosDA
        Dim tabla As New DataTable

        tabla = objDA.ValidarInfomacionCorrectaEmbarque(EmbarqueID)
        Return tabla
    End Function

    Public Function ConsultarEmbarquesSession(ByVal sessionid As Integer) As DataTable

        Dim objDA As New Datos.AdministradorDocumentosDA
        Dim tabla As New DataTable

        tabla = objDA.ConsultarEmbarquesSession(sessionid)
        Return tabla
    End Function
    Public Function ConsultarEtiquetasEmbarque(ByVal sessionID As Integer, ByVal embarquesid As String, ByVal impresionid As Integer, ByVal usuarioid As Integer, ByVal etiquetaEspecias As Integer) As DataTable

        Dim objDA As New Datos.AdministradorDocumentosDA
        Dim tabla As New DataTable

        tabla = objDA.ConsultarEtiquetasEmbarque(sessionID, embarquesid, impresionid, usuarioid, etiquetaEspecias)
        Return tabla
    End Function

    Public Function ConsultarEtiquetasOtrosEmbarque(ByVal sessionid As Integer, embarquesid As String, etiqueta As Integer, ByVal impresionid As Integer, ByVal usuarioid As Integer) As DataTable

        Dim objDA As New Datos.AdministradorDocumentosDA
        Dim tabla As New DataTable

        tabla = objDA.ConsultarEtiquetasOtrosEmbarque(sessionid, embarquesid, etiqueta, impresionid, usuarioid)
        Return tabla
    End Function

    Public Function ListaImpresoras() As DataTable
        Dim objDA As New Datos.AdministradorDocumentosDA
        Return objDA.ListaImpresoras()
    End Function

    Public Function ComandosImprimirEtiquetaGuiasEmbarque(ByVal impresoraid As Integer) As DataTable

        Dim objDA As New Datos.AdministradorDocumentosDA
        Dim tabla As New DataTable

        tabla = objDA.ComandosImprimirEtiquetaGuiasEmbarque(impresoraid)
        Return tabla
    End Function

    Public Function InsertarBitacoraImprecionGE(ByVal sessionid As Integer, embarqueid As String, ByVal usuarioid As Integer) As DataTable

        Dim objDA As New Datos.AdministradorDocumentosDA
        Dim tabla As New DataTable

        tabla = objDA.InsertarBitacoraImprecionGE(sessionid, embarqueid, usuarioid)
        Return tabla

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

        Dim objDA As New Datos.AdministradorDocumentosDA
        Dim tabla As New DataTable
        tabla = objDA.ConsultarGuiasEmbarque(conFecha, fechaInicio, fechaFin, GuiasEmbarque, pendientesGuia, conGuiaRastreo, clientes, tipoempaque, estatus, transporte, atnCliente, pedidos, Ot, facturas, remision)
        Return tabla
    End Function

    Public Function ListaMensajerias() As DataTable
        Dim objDA As New Datos.AdministradorDocumentosDA
        Return objDA.ConsultarMensajerias()
    End Function

    Public Function ConsultaExisteEmbarque(ByVal embarqueid As Integer, numguia As String, usuarioid As Integer, cartaP As String, costoEnvio As Double) As DataTable

        Dim objDA As New Datos.AdministradorDocumentosDA
        Dim tabla As New DataTable

        tabla = objDA.ConsultaExisteEmbarque(embarqueid, numguia, usuarioid, cartaP, costoEnvio)
        Return tabla
    End Function
    Public Function CalcelarEmbarque(ByVal EmbarqueID As String) As DataTable

        Dim objDA As New Datos.AdministradorDocumentosDA
        Dim tabla As New DataTable

        tabla = objDA.CancelarEmbarque(EmbarqueID)
        Return tabla
    End Function

    Public Function PonerEnRutaEmbarque(ByVal EmbarqueID As String, usuarioid As Integer) As DataTable

        Dim objDA As New Datos.AdministradorDocumentosDA
        Dim tabla As New DataTable

        tabla = objDA.PonerEnRutaEmbarque(EmbarqueID, usuarioid)
        Return tabla
    End Function

    Public Function PonerEnEntregadoEmbarque(ByVal EmbarqueID As String, usuario As Integer) As DataTable

        Dim objDA As New Datos.AdministradorDocumentosDA
        Dim tabla As New DataTable

        tabla = objDA.PonerEntrgadoEmbarque(EmbarqueID, usuario)
        Return tabla
    End Function

    Public Function GenerarArchivoCastores(ByVal embarques As String) As DataTable

        Dim objDA As New Datos.AdministradorDocumentosDA
        Dim tabla As New DataTable

        tabla = objDA.GenerarArchivoCastores(embarques)
        Return tabla
    End Function

    Public Function ModificarBanderaGenerarArchivoCastores(ByVal embarques As String) As DataTable

        Dim objDA As New Datos.AdministradorDocumentosDA
        Dim tabla As New DataTable

        tabla = objDA.ModificarBanderaGenerarArchivoCastores(embarques)
        Return tabla
    End Function

    Public Function ConsultarOpcionesRembarque() As DataTable

        Dim objDA As New Datos.AdministradorDocumentosDA
        Dim tabla As New DataTable

        tabla = objDA.ConsultarOpcionesRembarque()
        Return tabla
    End Function

    Public Function ConsultarOpcionesMensajerias() As DataTable

        Dim objDA As New Datos.AdministradorDocumentosDA
        Dim tabla As New DataTable

        tabla = objDA.ConsultarOpcionesMensajerias()
        Return tabla
    End Function


    Public Function ConsultarFolioFinal(ByVal usuario As Integer) As DataTable

        Dim objDA As New Datos.AdministradorDocumentosDA
        Dim tabla As New DataTable

        tabla = objDA.ConsultarFolioFinal(usuario)
        Return tabla
    End Function

    Public Function EliminarSessionOtrosEmbarques(ByVal embarqueid As Integer) As Entidades.ErrorEmbarque

        Dim objDA As New Datos.AdministradorDocumentosDA
        Dim tabla As New DataTable
        Dim Embarque As New Entidades.ErrorEmbarque

        tabla = objDA.EliminarSessionOtrosEmbarques(embarqueid)

        If tabla.Rows(0).Item("Error") = "0" Then

            Embarque.Error = 0
        Else

            Embarque.Error = 1
            Embarque.Mensaje = tabla.Rows(0).Item("Mensaje")

        End If


        Return Embarque
    End Function

    Public Function GuardarGuiaOtrosEmbarques(ByVal embarques As Entidades.InformacionEmbarque) As Entidades.ErrorEmbarque

        Dim objDA As New Datos.AdministradorDocumentosDA
        Dim tabla As New DataTable
        Dim Embarque As New Entidades.ErrorEmbarque

        tabla = objDA.GuardarGuiaOtrosEmbarques(embarques)

        If tabla.Rows(0).Item("Error") = "0" Then

            Embarque.Error = 0
        Else

            Embarque.Error = 1
            Embarque.Mensaje = tabla.Rows(0).Item("Mensaje")

        End If


        Return Embarque
    End Function

    Public Function ConsultarTodosLosOperadores() As DataTable

        Dim objDA As New Datos.AdministradorDocumentosDA
        Dim tabla As New DataTable

        tabla = objDA.ConsultarTodoslosOperadores()
        Return tabla
    End Function

    Public Function consultarEstatusEmbarque(inicial As Integer) As DataTable

        Dim objDA As New Datos.AdministradorDocumentosDA
        Dim tabla As New DataTable

        tabla = objDA.consultarEstatusEmbarque(inicial)
        Return tabla
    End Function
    Public Function ReembarcarEmbarque(ByVal embarqueid As String, ByVal tipoEmbarque As Integer, ByVal usuario As Integer, motivo As String) As List(Of Entidades.NivelDocumentos)

        Dim objDA As New Datos.AdministradorDocumentosDA
        Dim tabla As New DataTable
        Dim Embarque As New Entidades.ErrorEmbarque
        Dim listaDocumentos As New List(Of Entidades.NivelDocumentos)


        tabla = objDA.ReembarcarEmbarque(embarqueid, tipoEmbarque, usuario, motivo)

        If tabla.Rows(0).Item("Error") = "0" Then

            For documentoJuntos = 0 To tabla.Rows.Count - 1

                Dim DocumentoConNivel As New Entidades.NivelDocumentos
                DocumentoConNivel.Nivel = documentoJuntos + 1
                DocumentoConNivel.TotalNivel = tabla.Rows.Count
                DocumentoConNivel.Embarque = tabla.Rows(documentoJuntos).Item("EmbarqueID")
                listaDocumentos.Add(DocumentoConNivel)
            Next
        End If


        Return listaDocumentos
    End Function
    Public Function GuardarNumerosRastreos(ByVal embarqueid As String, ByVal numeroGuia As String, ByVal cartaPoder As String, usuarioid As Integer, costoEnvio As Double) As Entidades.ErrorEmbarque

        Dim objDA As New Datos.AdministradorDocumentosDA
        Dim tabla As New DataTable
        Dim Embarque As New Entidades.ErrorEmbarque

        tabla = objDA.GuardarNumerosRastreos(embarqueid, numeroGuia, cartaPoder, usuarioid, costoEnvio)

        If tabla.Rows(0).Item("Error") = "BN" Then

            Embarque.Error = 0
        Else

            Embarque.Error = 1
            Embarque.Mensaje = tabla.Rows(0).Item("Error")

        End If
        Return Embarque
    End Function
    Public Function ConsultarEtiquetasZapatoStylo(ByVal xmlCodigos As String, impresora As Integer) As DataTable

        Dim objDA As New Datos.AdministradorDocumentosDA
        Dim tabla As New DataTable

        tabla = objDA.ConsultarEtiquetasZapatoStylo(xmlCodigos, impresora)
        Return tabla
    End Function
    Public Function BorrarCajas(embarqueid As Integer) As DataTable

        Dim objDA As New Datos.AdministradorDocumentosDA
        Dim tabla As New DataTable

        tabla = objDA.BorrarCajas(embarqueid)
        Return tabla
    End Function
    Public Function ConsultarMotivosRembarque() As DataTable

        Dim objDA As New Datos.AdministradorDocumentosDA
        Dim tabla As New DataTable

        tabla = objDA.ConsultarMotivosRembarque()
        Return tabla
    End Function
    Public Function ConsultarClientesEspeciales(ByVal clienteid As Integer) As DataTable

        Dim objDA As New Datos.AdministradorDocumentosDA
        Dim tabla As New DataTable

        tabla = objDA.ConsultarClientesEspeciales(clienteid)
        Return tabla
    End Function
    Public Function ActualizarTiendaEmbarque(ByVal embarques As Entidades.InformacionEmbarque) As Entidades.ErrorEmbarque

        Dim objDA As New Datos.AdministradorDocumentosDA
        Dim tabla As New DataTable
        Dim Embarque As New Entidades.ErrorEmbarque

        tabla = objDA.ActualizarTiendaEmbarques(embarques)

        If tabla.Columns.Contains("Error") Then
            Embarque.Error = 1
            Embarque.Mensaje = tabla.Rows(0).Item("Mensaje")
        Else
            Embarque.Error = 0
        End If


        Return Embarque
    End Function
    Public Function ConsultarTipoEmbarque(ByVal embarqueid As String) As DataTable

        Dim objDA As New Datos.AdministradorDocumentosDA
        Dim tabla As New DataTable

        tabla = objDA.ConsultarTipoEmbarque(embarqueid)
        Return tabla
    End Function
    Public Function ConsultarMensjaeriaFiltro() As DataTable

        Dim objDA As New Datos.AdministradorDocumentosDA
        Dim tabla As New DataTable

        tabla = objDA.ConsultarMensjaeriaFiltro()
        Return tabla
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

        Dim objDA As New Datos.AdministradorDocumentosDA
        Dim tabla As New DataTable
        tabla = objDA.ConsultarReporteEstadistica(conFecha, fechaInicio, fechaFin, GuiasEmbarque, pendientesGuia, conGuiaRastreo, clientes, tipoempaque, estatus, transporte)
        Return tabla
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

        Dim objDA As New Datos.AdministradorDocumentosDA
        Dim tabla As New DataTable
        tabla = objDA.Consultar_ReporteEstadisticaTotalEmpaques(conFecha, fechaInicio, fechaFin, GuiasEmbarque, pendientesGuia, conGuiaRastreo, clientes, tipoempaque, estatus, transporte)
        Return tabla
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

        Dim objDA As New Datos.AdministradorDocumentosDA
        Dim tabla As New DataTable
        tabla = objDA.Consultar_ReporteEstadisticaFechas(conFecha, fechaInicio, fechaFin, GuiasEmbarque, pendientesGuia, conGuiaRastreo, clientes, tipoempaque, estatus, transporte)
        Return tabla
    End Function

    Public Function ConsultarAtnClienteFiltro() As DataTable

        Dim objDA As New Datos.AdministradorDocumentosDA
        Dim tabla As New DataTable

        tabla = objDA.ConsultarAtnClienteFiltro()
        Return tabla
    End Function

    Public Function ConsultarAtnClienteInfo(ByVal colaboradorid As Integer) As DataTable

        Dim objDA As New Datos.AdministradorDocumentosDA
        Dim tabla As New DataTable

        tabla = objDA.ConsultarAtnClienteInfo(colaboradorid)
        Return tabla
    End Function

    Public Function ValidarClientesGuiaEmbarqueDinamico(ByVal Documentos As String) As Boolean
        Dim objDA As New Datos.AdministradorDocumentosDA
        Dim tabla As New DataTable
        Dim Resultado As Boolean = False

        tabla = objDA.ValidarClientesGuiaEmbarqueDinamico(Documentos)

        If tabla.Rows.Count > 0 Then
            If tabla.Rows(0).Item(0) = 1 Then
                Resultado = True
            Else
                Resultado = False
            End If

        Else
            Resultado = False
        End If

        Return Resultado

    End Function

    Public Function GenerarInformacionGuiaEmbarqueDinamico(ByVal Documentos As String, ByVal UsuarioId As Integer) As Entidades.SessionGuiaEmbarque
        Dim objDA As New Datos.AdministradorDocumentosDA
        Dim tabla As New DataTable
        Dim EmbarqueId As Integer = 0
        Dim ObjSessionGuiaEmbarque As New Entidades.SessionGuiaEmbarque

        tabla = objDA.GenerarInformacionGuiaEmbarqueDinamico(Documentos, UsuarioId)

        If tabla.Rows.Count > 0 Then
            ObjSessionGuiaEmbarque.PEmbarqueID = tabla.Rows(0).Item(0)
            ObjSessionGuiaEmbarque.PSessionID = tabla.Rows(0).Item(1)

        End If

        Return ObjSessionGuiaEmbarque

    End Function

    Public Function ObtenerRFCDocumentos(ByVal Documentos As String) As DataTable
        Dim objDA As New Datos.AdministradorDocumentosDA
        Dim tabla As New DataTable

        tabla = objDA.ObtenerRFCDocumentos(Documentos)
        Return tabla

    End Function

    Public Function ObtenerTiendas(ByVal Documentos As String, ByVal RFCID As Integer) As DataTable
        Dim objDA As New Datos.AdministradorDocumentosDA
        Dim tabla As New DataTable

        tabla = objDA.ObtenerTiendas(Documentos, RFCID)
        Return tabla
    End Function

    Public Function ObtenerDomicilioTienda(ByVal EmbarqueID As Integer, ByVal TiendaEmbarqueID As Integer, ByVal RFCID As Integer) As Entidades.InformacionEmbarque
        Dim objDA As New Datos.AdministradorDocumentosDA
        Dim tabla As New DataTable
        Dim Embarque As New Entidades.InformacionEmbarque

        tabla = objDA.ObtenerDomicilioTienda(EmbarqueID, TiendaEmbarqueID, RFCID)
        If tabla.Rows.Count > 0 Then


            Embarque.CiudadID = tabla.Rows(0).Item("CiudadID")
            Embarque.EstadoID = tabla.Rows(0).Item("EstadoID")
            Embarque.Calle = tabla.Rows(0).Item("Calle")
            Embarque.Colonia = tabla.Rows(0).Item("Colonia")
            Embarque.CP = tabla.Rows(0).Item("CP")
            Embarque.NumExt = tabla.Rows(0).Item("NumeroExterior")
            Embarque.NumInt = tabla.Rows(0).Item("NumeroInterior")
            Embarque.PaisID = tabla.Rows(0).Item("PaisID")
            Embarque.Telefono = tabla.Rows(0).Item("Telefono")
            Embarque.Tipofleje = tabla.Rows(0).Item("TipoFlejeId")
            Embarque.Domicilio = tabla.Rows(0).Item("Domicilio")
            Embarque.FormaPago = tabla.Rows(0).Item("Convenio")
        End If

        Return Embarque

    End Function

    Public Function InsertarInformacionFaltanteGuiaEmbarqueDinamico(ByVal objInformacionGuiaEmbarque As Entidades.InformacionEmbarque, ByVal UsuarioId As Integer) As DataTable
        Dim objDA As New Datos.AdministradorDocumentosDA
        Dim tabla As New DataTable

        tabla = objDA.InsertarInformacionFaltanteGuiaEmbarqueDinamico(objInformacionGuiaEmbarque, UsuarioId)
        Return tabla
    End Function

    Public Function CerrarSessionGuiaEmbarqueDinamico(ByVal UsuarioId As Integer) As DataTable
        Dim objDA As New Datos.AdministradorDocumentosDA
        Dim tabla As New DataTable

        tabla = objDA.CerrarSessionGuiaEmbarqueDinamico(UsuarioId)
        Return tabla
    End Function
    Public Function obtenerTamañoCajasEmbarque() As DataTable
        Dim objDatos As New Datos.AdministradorDocumentosDA
        Return objDatos.obtenerTamañosCajasEmbarques
    End Function
    Public Sub actualizaTamañoCajaEmbarque(ByVal cajaId As Integer, ByVal folioEmbarque As Integer, ByVal detalleFolioEmbarque As Integer)
        Dim objActualizaCaja As New Datos.AdministradorDocumentosDA
        objActualizaCaja.actualizaTamañoCaja(cajaId, folioEmbarque, detalleFolioEmbarque)
    End Sub
    Public Sub eliminaDetalleCajaEmbarque(ByVal cajaDetalleId As Integer)
        Dim objElimina As New Datos.AdministradorDocumentosDA
        objElimina.eliminaDetalleCajaEmbarque(cajaDetalleId)
    End Sub
End Class
