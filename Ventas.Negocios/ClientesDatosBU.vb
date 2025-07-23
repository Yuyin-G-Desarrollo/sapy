Imports Ventas.Datos

Public Class ClientesDatosBU

    Public Function verCoordinadores() As DataTable
        Dim objverAgentesVentaComisionDA As New Datos.ClientesDatosDA
        Return objverAgentesVentaComisionDA.verCoordinadores
    End Function

    Public Sub altaDomicilioCliente(ByVal domicilio As Entidades.Domicilio, bandera As Integer)

        Dim clientesDatosDA As New Datos.ClientesDatosDA
        clientesDatosDA.altaDomicilioCliente(domicilio, bandera)

    End Sub

    Public Sub editarDomicilioCliente(ByVal domicilio As Entidades.Domicilio, bandera As Integer)

        Dim clientesDatosDA As New Datos.ClientesDatosDA
        clientesDatosDA.editarDomicilioCliente(domicilio, bandera)

    End Sub

    Public Sub editarVentasInfoCliente(ByVal infoCliente As Entidades.InformacionClienteVentas, bandera As Integer)

        Dim clientesDatosDA As New Datos.ClientesDatosDA
        clientesDatosDA.editarVentasInfoCliente(infoCliente, bandera)

    End Sub

    Public Function Datos_TablaVentasInfoCliente(clienteID As Integer) As DataTable

        Dim clientesDatosDA As New Datos.ClientesDatosDA
        Return clientesDatosDA.Datos_TablaVentasInfoCliente(clienteID)

    End Function

    Public Sub editarCobranzaInfoCliente(ByVal infoCliente As Entidades.InformacionClienteCobranza, bandera As Integer)

        Dim clientesDatosDA As New Datos.ClientesDatosDA
        clientesDatosDA.editarCobranzaInfoCliente(infoCliente, bandera)

    End Sub

    Public Function Datos_TablaCobranzaInfoCliente(clienteID As Integer) As DataTable
        Dim clientesDatosDA As New Datos.ClientesDatosDA
        Return clientesDatosDA.Datos_TablaCobranzaInfoCliente(clienteID)
    End Function

    Public Sub editarClienteClienteRFC(clienteRFC As Entidades.ClienteRFC, tipoPersona As Entidades.TipoPersona, bandera As Integer)

        Dim clientesDatosDA As New Datos.ClientesDatosDA
        clientesDatosDA.editarClienteClienteRFC(clienteRFC, tipoPersona, bandera)

    End Sub

    Public Sub editarClienteNotaCredito(ByVal metodoPago As Int16, ByVal formaPago As Int16, ByVal clienteID As Int64)
        Dim clientesDA As New Datos.ClientesDatosDA
        clientesDA.actualizarInfoClientePago_NotaCredito(metodoPago, formaPago, clienteID)
    End Sub

    Public Function Datos_TablaClienteRFC(personaID As Integer) As DataTable

        Dim clientesDatosDA As New Datos.ClientesDatosDA
        Return clientesDatosDA.Datos_TablaClienteRFC(personaID)

    End Function

    Public Sub editarCedisClienteCEDIS(TEC As Entidades.TiendaEmbarqueCedis, tipoPersona As Entidades.TipoPersona, bandera As Integer)

        Dim clientesDatosDA As New Datos.ClientesDatosDA
        clientesDatosDA.editarCedisClienteCEDIS(TEC, tipoPersona, bandera)

    End Sub

    Public Function Datos_ClienteRFCCEDIS(personaID As Integer, areaOperativa As Integer) As DataTable

        Dim clientesDatosDA As New Datos.ClientesDatosDA
        Return clientesDatosDA.Datos_ClienteRFCCEDIS(personaID, areaOperativa)

    End Function

    Public Function Datos_ClienteRFCCEDIS_Mensajeria(cedisID As Integer, ciudadID As Integer, poblacionID As Integer) As DataTable

        Dim clientesDatosDA As New Datos.ClientesDatosDA
        Return clientesDatosDA.Datos_ClienteRFCCEDIS_Mensajeria(cedisID, ciudadID, poblacionID)

    End Function

    Public Function Datos_TablaClienteCEDIS(personaID As Integer) As DataTable

        Dim clientesDatosDA As New Datos.ClientesDatosDA
        Return clientesDatosDA.Datos_TablaClienteCEDIS(personaID)

    End Function

    Public Function ListadoClienteRFCPersona(clienteID As Integer) As DataTable

        Dim clientesDatosDA As New Datos.ClientesDatosDA
        Return clientesDatosDA.ListadoClienteRFCPersona(clienteID)

    End Function

    Public Function ListadoTECClienteRFC(clienteRFCID As Integer) As DataTable

        Dim clientesDatosDA As New Datos.ClientesDatosDA
        Return clientesDatosDA.ListadoTECClienteRFC(clienteRFCID)

    End Function

    Public Function ListadoClienteRFCPersonaFactura(clienteRFC As Integer) As DataTable

        Dim clientesDatosDA As New Datos.ClientesDatosDA
        Return clientesDatosDA.ListadoClienteRFCPersonaFactura(clienteRFC)

    End Function

    Public Function Datos_Grid_ClienteRFC(clienteid As Integer, areaOperativa As Integer) As DataTable

        Dim clientesDatosDA As New Datos.ClientesDatosDA
        Return clientesDatosDA.Datos_Grid_ClienteRFC(clienteid, areaOperativa)

    End Function

    Public Function Datos_ClienteRFCTelefonos(personaID As Integer, areaOperativa As Integer) As DataTable

        Dim clientesDatosDA As New Datos.ClientesDatosDA
        Return clientesDatosDA.Datos_ClienteRFCTelefonos(personaID, areaOperativa)

    End Function

    Public Function Datos_ClienteRFCEmails(personaID As Integer, areaOperativa As Integer) As DataTable

        Dim clientesDatosDA As New Datos.ClientesDatosDA
        Return clientesDatosDA.Datos_ClienteRFCEmails(personaID, areaOperativa)

    End Function

    Public Sub AltaTelefono(persona As Entidades.Persona, _
                           clasificacionpersona As Entidades.ClasificacionPersona, _
                           telefono As Entidades.Telefono, _
                           tipoTelefono As Entidades.TipoTelefono)

        Dim clientesDatosDA As New Datos.ClientesDatosDA
        clientesDatosDA.AltaTelefono(persona, clasificacionpersona, telefono, tipoTelefono)

    End Sub

    Public Sub EditarTelefono(persona As Entidades.Persona, _
                       clasificacionpersona As Entidades.ClasificacionPersona, _
                       telefono As Entidades.Telefono, _
                       tipoTelefono As Entidades.TipoTelefono)

        Dim clientesDatosDA As New Datos.ClientesDatosDA
        clientesDatosDA.EditarTelefono(persona, clasificacionpersona, telefono, tipoTelefono)

    End Sub

    Public Sub AltaEmail(persona As Entidades.Persona, _
                           clasificacionpersona As Entidades.ClasificacionPersona, _
                           email As Entidades.Email)

        Dim clientesDatosDA As New Datos.ClientesDatosDA
        clientesDatosDA.AltaEmail(persona, clasificacionpersona, email)

    End Sub

    Public Sub EditarEmail(persona As Entidades.Persona, _
                       clasificacionpersona As Entidades.ClasificacionPersona, _
                       email As Entidades.Email)

        Dim clientesDatosDA As New Datos.ClientesDatosDA
        clientesDatosDA.EditarEmail(persona, clasificacionpersona, email)

    End Sub

    Public Function Datos_TablaContrarecibos(clienteID As Integer, AreaOperativa As Integer) As DataTable

        Dim clientesDatosDA As New Datos.ClientesDatosDA
        Return clientesDatosDA.Datos_TablaContrarecibos(clienteID, AreaOperativa)

    End Function

    Public Function Datos_TablaTipoHorario(AreaOperativa As Integer) As DataTable

        Dim clientesDatosDA As New Datos.ClientesDatosDA
        Return clientesDatosDA.Datos_TablaTipoHorario(AreaOperativa)

    End Function

    Public Sub AltaHorarioContrarecibo(horario As Entidades.HorarioContrarecibo)

        Dim clientesDatosDA As New Datos.ClientesDatosDA
        clientesDatosDA.AltaHorarioContrarecibo(horario)

    End Sub

    Public Sub EditarHorarioContrarecibo(horario As Entidades.HorarioContrarecibo)

        Dim clientesDatosDA As New Datos.ClientesDatosDA
        clientesDatosDA.EditarHorarioContrarecibo(horario)

    End Sub

    Public Function Datos_TablaDescuentosCliente(clienteID As Integer, areaOperativa As Integer) As DataTable

        Dim clientesDatosDA As New Datos.ClientesDatosDA
        Return clientesDatosDA.Datos_TablaDescuentosCliente(clienteID, areaOperativa)

    End Function

    Public Function Datos_TablaMotivoDescuento() As DataTable

        Dim clientesDatosDA As New Datos.ClientesDatosDA
        Return clientesDatosDA.Datos_TablaMotivoDescuento()

    End Function

    Public Function Datos_TablaLugarDescuento() As DataTable

        Dim clientesDatosDA As New Datos.ClientesDatosDA
        Return clientesDatosDA.Datos_TablaLugarDescuento()

    End Function

    Public Sub AltaDescuentosCliente(descuento As Entidades.DescuentoCliente)

        Dim clientesDatosDA As New Datos.ClientesDatosDA
        clientesDatosDA.AltaDescuentosCliente(descuento)

    End Sub

    Public Sub EditarDescuentosCliente(descuento As Entidades.DescuentoCliente)

        Dim clientesDatosDA As New Datos.ClientesDatosDA
        clientesDatosDA.EditarDescuentosCliente(descuento)

    End Sub

    Public Function Datos_TablaRamoCliente(clienteID As Integer, areaOperativa As Integer, ByVal Modo_Edicion As Boolean) As DataTable

        Dim clientesDatosDA As New Datos.ClientesDatosDA
        Return clientesDatosDA.Datos_TablaRamoCliente(clienteID, areaOperativa, Modo_Edicion)

    End Function

    Public Sub EditarRamoCliente(ramo As Entidades.ClienteRamo)

        Dim clientesDatosDA As New Datos.ClientesDatosDA
        clientesDatosDA.EditarRamoCliente(ramo)

    End Sub

    Public Function Datos_TablaTiendaCliente(clienteID As Integer, areaOperativa As Integer, ByVal Modo_Edicion As Boolean) As DataTable
        Dim clientesDatosDA As New Datos.ClientesDatosDA
        Return clientesDatosDA.Datos_TablaTiendaCliente(clienteID, areaOperativa, Modo_Edicion)
    End Function

    Public Sub EditarTiendaCliente(tienda As Entidades.ClienteTienda)

        Dim clientesDatosDA As New Datos.ClientesDatosDA
        clientesDatosDA.EditarTiendaCliente(tienda)

    End Sub

    Public Function Datos_TablaZapateriaCliente(clienteID As Integer, areaOperativa As Integer) As DataTable
        Dim clientesDatosDA As New Datos.ClientesDatosDA
        Return clientesDatosDA.Datos_TablaZapateriaCliente(clienteID, areaOperativa)
    End Function

    Public Function Datos_TablaZapateriaCompetencia() As DataTable

        Dim clientesDatosDA As New Datos.ClientesDatosDA
        Return clientesDatosDA.Datos_TablaZapateriaCompetencia()

    End Function

    Public Function Datos_Catalogo_ZapateriasCompetencia() As DataTable

        Dim clientesDatosDA As New Datos.ClientesDatosDA
        Return clientesDatosDA.Datos_Catalogo_ZapateriasCompetencia()

    End Function


    Public Sub AltaZapateriaCliente(zapateria As Entidades.ZapateriaCompetenciaCliente)
        Dim clientesDatosDA As New Datos.ClientesDatosDA
        clientesDatosDA.AltaZapateriaCliente(zapateria)
    End Sub

    Public Sub AltaZapateria(zapateria As Entidades.ZapateriaCompetencia)
        Dim clientesDatosDA As New Datos.ClientesDatosDA
        clientesDatosDA.AltaZapateria(zapateria)
    End Sub


    Public Sub EditarZapateriaCliente(zapateria As Entidades.ZapateriaCompetenciaCliente)
        Dim clientesDatosDA As New Datos.ClientesDatosDA
        clientesDatosDA.EditarZapateriaCliente(zapateria)

    End Sub

    Public Sub EditarZapateria(zapateria As Entidades.ZapateriaCompetencia)
        Dim clientesDatosDA As New Datos.ClientesDatosDA
        clientesDatosDA.EditarZapateria(zapateria)

    End Sub

    Public Function Datos_TablaMaterialMKTCliente(clienteID As Integer, areaOperativa As Integer) As DataTable

        Dim clientesDatosDA As New Datos.ClientesDatosDA
        Return clientesDatosDA.Datos_TablaMaterialMKTCliente(clienteID, areaOperativa)

    End Function

    Public Function Datos_TablaTipoMaterialMKT() As DataTable

        Dim clientesDatosDA As New Datos.ClientesDatosDA
        Return clientesDatosDA.Datos_TablaTipoMaterialMKT()

    End Function

    Public Function Datos_TablaMaterialMKT(tipoMaterial As Integer) As DataTable

        Dim clientesDatosDA As New Datos.ClientesDatosDA
        Return clientesDatosDA.Datos_TablaMaterialMKT(tipoMaterial)

    End Function

    Public Sub AltaMaterialMKTCliente(materialMKT As Entidades.MaterialMKTCliente)

        Dim clientesDatosDA As New Datos.ClientesDatosDA
        clientesDatosDA.AltaMaterialMKTCliente(materialMKT)

    End Sub

    Public Sub EditarMaterialMKTCliente(materialMKT As Entidades.MaterialMKTCliente)

        Dim clientesDatosDA As New Datos.ClientesDatosDA
        clientesDatosDA.EditarMaterialMKTCliente(materialMKT)

    End Sub

    Public Function Datos_Vinculacion_TEC_RFC(rfcID As Integer, clienteID As Integer) As DataTable

        Dim clientesDatosDA As New Datos.ClientesDatosDA
        Return clientesDatosDA.Datos_Vinculacion_TEC_RFC(rfcID, clienteID)

    End Function

    Public Sub Vinculacion_RFC_TEC(bandera As Integer, rfcid As Integer, _
                                   tecid As Integer, vinculacionid As Integer)

        Dim clientesDatosDA As New Datos.ClientesDatosDA
        clientesDatosDA.Vinculacion_RFC_TEC(bandera, rfcid, tecid, vinculacionid)

    End Sub

    Public Sub EditarPrioridadMensajerias(bandera As Integer, prioridad As Integer, tiendaembarquecedisid As Integer, costodestinomensajeriaid As Integer)
        Dim clientesDatosDA As New Datos.ClientesDatosDA
        clientesDatosDA.EditarPrioridadMensajerias(bandera, prioridad, tiendaembarquecedisid, costodestinomensajeriaid)
    End Sub

    Public Function Datos_TablaVendedoresCliente(clienteID As Integer) As DataTable

        Dim clientesDatosDA As New Datos.ClientesDatosDA
        Return clientesDatosDA.Datos_TablaVendedoresCliente(clienteID)

    End Function


    Public Sub Alta_ClienteMarcaAgenteEmpresa(clienteid As Integer, marcaid As Integer, colaboradorid_agente As Integer, empresaid As Integer)

        Dim clientesDatosDA As New Datos.ClientesDatosDA
        clientesDatosDA.Alta_ClienteMarcaAgenteEmpresa(clienteid, marcaid, colaboradorid_agente, empresaid)

    End Sub

    Public Sub Editar_ClienteMarcaAgenteEmpresa(clientemarcaagenteempresaid As Integer, clienteid As Integer, marcaid As Integer, colaboradorid_agente As Integer, empresaid As Integer, activo As Boolean)

        Dim clientesDatosDA As New Datos.ClientesDatosDA
        clientesDatosDA.Editar_ClienteMarcaAgenteEmpresa(clientemarcaagenteempresaid, clienteid, marcaid, colaboradorid_agente, empresaid, activo)

    End Sub

    Public Function ListaRFC_Sicy(clienteID As Integer, rfc_sicyID As Integer, editando As Boolean) As DataTable

        Dim clientesDatosDA As New Datos.ClientesDatosDA
        Return clientesDatosDA.ListaRFC_Sicy(clienteID, rfc_sicyID, editando)

    End Function

    Public Function ListaTEC_Sicy(clienteID As Integer, distribucion_sicyID As Integer, editando As Boolean) As DataTable

        Dim clientesDatosDA As New Datos.ClientesDatosDA
        Return clientesDatosDA.ListaTEC_Sicy(clienteID, distribucion_sicyID, editando)

    End Function

    Public Function AgenteClienteListaPrecios(ByVal idCliente As Int32) As DataTable
        Dim clientesDatosDA As New Datos.ClientesDatosDA
        Return clientesDatosDA.AgenteClienteListaPrecios(idCliente)
    End Function


    ''' <summary>
    ''' RECUPERA LA MONEDA DE CLIENTE EN CASO DE QUE SEA MONEDA EXTRANJERA, DE LO CONTRARIO SOLO RECUPERA LA MONEDA PESOS
    ''' </summary>
    ''' <param name="IdMonedaCliente">ID DE LA MONEDA DEL CLIENTE</param>
    ''' <returns>DATATABLE CON LA INFORMACION RECUPERADA</returns>
    ''' <remarks></remarks>
    Public Function RecuperarMonedaDelClienteMasMonedaPeso(ByVal IdMonedaCliente As Integer)
        Dim clientesDatosDA As New Datos.ClientesDatosDA
        Return clientesDatosDA.RecuperarMonedaDelClienteMasMonedaPeso(IdMonedaCliente)
    End Function

    Public Function Recuperar_NumeracionPais()
        Dim clientesDatosDA As New Datos.ClientesDatosDA
        Return clientesDatosDA.Recuperar_NumeracionPais()
    End Function

    Public Function FiltroMarcaAgente(ByVal idCliente As Int32, ByVal idUsuario As Int32) As DataTable
        Dim clientesDatosDA As New Datos.ClientesDatosDA
        Try
            Return clientesDatosDA.FiltroMarcaAgente(idCliente, idUsuario)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function AgenteClienteMarcasListaPrecios(ByVal idCliente As Int32,
                                                    ByVal IdListaVentaClientePrecio As Integer,
                                                    ByVal conlista As Boolean,
                                                    ByVal marcaEspecial As Int32, ByVal idListaBase As Int32) As DataTable
        Dim clientesDatosDA As New Datos.ClientesDatosDA
        Return clientesDatosDA.AgenteClienteMarcasListaPrecios(idCliente, IdListaVentaClientePrecio, conlista, marcaEspecial, idListaBase)
    End Function

    ''' <summary>
    ''' RECUPERAR EL TIPO DE CLIENTE (NACIONAL O EXTRANJERO) DE UN CLIENTE EN ESPECIFICO
    ''' </summary>
    ''' <param name="IdCliente">ID DEL CLIENTE DEL CUAL SE RECUPERARA LA INFORMACIÓN</param>
    ''' <returns>DATATABLE CON LA INFORMACION RECUPERADA</returns>
    ''' <remarks></remarks>
    Public Function ListaClienteNacional_Extranjero(ByVal IdCliente As Integer) As DataTable
        Dim objDA As New Datos.ClientesDatosDA
        ListaClienteNacional_Extranjero = objDA.ListaClienteNacional_Extranjero(IdCliente)
        Return ListaClienteNacional_Extranjero
    End Function


    Public Function RecuperarVentas_InfoCliente(ByVal IdCLiente As Integer) As DataTable
        Dim objDA As New Datos.ClientesDatosDA
        RecuperarVentas_InfoCliente = objDA.RecuperarVentas_InfoCliente(IdCLiente)
        Return RecuperarVentas_InfoCliente
    End Function




    ''' <summary>
    ''' RECUPERA LOS NOMBRES DE LOS AJENTES ASIGNADOS A UN CLIENTE EN ESPECIFICO
    ''' </summary>
    ''' <param name="IdCLiente_say">ID DEL CLIENTE DEL CUAL SE RECUPERARAN LOS DATOS DE SUS AGENTES DE VENTAS ASIGNADOS</param>
    ''' <returns>DATATABLE CON LA INFORMACION RECUPERADA</returns>
    ''' <remarks></remarks>
    Public Function ListaAgentes_de_cliente(ByVal IdCLiente_say As Integer) As DataTable
        Dim objDA As New Datos.ClientesDatosDA
        ListaAgentes_de_cliente = objDA.ListaAgentes_de_cliente(IdCLiente_say)

        Return ListaAgentes_de_cliente
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="IdClienteSay"></param>
    ''' <param name="IdAgente"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ListaMarcas_De_Agente_de_cliente(ByVal IdClienteSay As Integer, ByVal IdAgente As Integer) As DataTable
        Dim objDA As New Datos.ClientesDatosDA
        ListaMarcas_De_Agente_de_cliente = objDA.ListaMarcas_De_Agente_de_cliente(IdClienteSay, IdAgente)

        Return ListaMarcas_De_Agente_de_cliente
    End Function


    Public Function RelacionarContactoMarcaAgente(ByVal Bandera As Integer, ByVal EMail As String, ByVal IdEmailPersona As Integer,
                    ByVal Contacto As String, ByVal IdPersona As Integer, ByVal IdsClienteMarcaAgenteEmpresa As String, ByVal IdClienteSay As Integer) As String
        Dim objDA As New Datos.ClientesDatosDA
        Dim dtResultado As New DataTable

        dtResultado = objDA.RelacionarContactoMarcaAgente(Bandera, EMail, IdEmailPersona, Contacto, IdPersona, IdsClienteMarcaAgenteEmpresa, IdClienteSay)

        RelacionarContactoMarcaAgente = dtResultado.Rows(0).Item(0)

        Return RelacionarContactoMarcaAgente
    End Function


    Public Function Desasignar_Prioridad_CedisMensajeria(ByVal tiendaembarquecedisid As Integer) As DataTable
        Dim objDA As New Datos.ClientesDatosDA
        Desasignar_Prioridad_CedisMensajeria = objDA.Desasignar_Prioridad_CedisMensajeria(tiendaembarquecedisid)
        Return Desasignar_Prioridad_CedisMensajeria
    End Function

    Public Function ValidarRelaciones_Zapaterias(ByVal IdZApateria As Integer) As Boolean
        Dim objDA As New Datos.ClientesDatosDA
        Dim dtZapaterias As DataTable
        dtZapaterias = objDA.ValidarRelaciones_Zapaterias(IdZApateria)

        If dtZapaterias.Rows(0).Item(0) > 0 Then
            Return True
        Else
            Return False
        End If
    End Function


    Public Function consultaAgenteMarcaClienteDemoWEB(ByVal idCliente As Integer) As DataTable
        Dim objDA As New Datos.ClientesDatosDA
        Return objDA.consultaAgenteMarcaClienteDemoWEB(idCliente)
    End Function

    Public Function consultaComboMarcasParaFamilia(ByVal idCliente As Int32) As DataTable
        Dim objDA As New Datos.ClientesDatosDA
        Dim dtMarcas As New DataTable

        dtMarcas = objDA.consultaComboMarcasParaFamilia(idCliente)
        Return dtMarcas
    End Function

    Public Function consultaComboAgentesParaFamilia(ByVal idCliente As Int32, ByVal idMarca As Int32) As DataTable
        Dim objDA As New Datos.ClientesDatosDA
        Dim dtAgentes As New DataTable

        dtAgentes = objDA.consultaComboAgentesParaFamilia(idCliente, idMarca)
        Return dtAgentes
    End Function

    Public Function consultaAgenteMarcaFamiliaAsignados(ByVal idCliente As Int32) As DataTable
        Dim dtAsignacion As New DataTable
        Dim objDA As New Datos.ClientesDatosDA

        dtAsignacion = objDA.consultaAgenteMarcaFamiliaAsignados(idCliente)
        Return dtAsignacion
    End Function

    Public Function consultaAgenteSicy(ByVal idAgenteSay As Int32) As DataTable
        Dim dtAgtSicy As New DataTable
        Dim objDa As New Datos.ClientesDatosDA

        dtAgtSicy = objDa.consultaAgenteSicy(idAgenteSay)
        Return dtAgtSicy
    End Function

    Public Function consultaMarcasFamiliasPorAsignar(ByVal idCliente As Int32, ByVal idMarca As Int32) As DataTable
        Dim dtPorAsignar As New DataTable
        Dim objDa As New Datos.ClientesDatosDA

        dtPorAsignar = objDa.consultaMarcasFamiliasPorAsignar(idCliente, idMarca)

        Return dtPorAsignar
    End Function

    Public Sub insertaActualizaRelacionMarcaFamilia(ByVal idCliente As Int32, ByVal idAgente As Int32, ByVal idFamilia As Int32, ByVal idMarca As Int32, ByVal idUsuario As Int32, ByVal operacion As Int32, idCoord As Int32)
        Dim objDa As New Datos.ClientesDatosDA

        objDa.insertaActualizaRelacionMarcaFamila(idCliente, idAgente, idFamilia, idMarca, idUsuario, operacion, idCoord)
    End Sub

    Public Sub replica_ClienteMarcaFamiliaproyeccion_SAY_SICY()
        Dim objreplica_ClienteMarcaFamiliaproyeccion_SAY_SICY As New Datos.ClientesDatosDA
        objreplica_ClienteMarcaFamiliaproyeccion_SAY_SICY.replica_ClienteMarcaFamiliaproyeccion_SAY_SICY()
    End Sub

    Public Sub replica_ClienteMarcaAgentEmpresa_SAY_SICY(nombreUsuario As String, idClienteSAY As Integer)
        Dim objreplica_ClienteMarcaAgentEmpresa_SAY_SICY As New Datos.ClientesDatosDA

        objreplica_ClienteMarcaAgentEmpresa_SAY_SICY.replica_ClienteMarcaAgentEmpresa_SAY_SICY(nombreUsuario, idClienteSAY)
    End Sub

    Public Sub actualizaProspecta()
        Dim objActualizaProspecta As New Datos.ClientesDatosDA
        objActualizaProspecta.actualizaProspecta()
    End Sub

    Public Sub quitaAgenteComision(idUsuario As Integer, nombreUsuario As String, idClienteSAY As Integer, idMarcaSAY As Integer, idAgenteSAY As Integer)
        Dim objActualizaProspecta As New Datos.ClientesDatosDA
        objActualizaProspecta.quitaAgenteComision(idUsuario, nombreUsuario, idClienteSAY, idMarcaSAY, idAgenteSAY)
    End Sub

#Region "Cambios FTC facturacion 3.3"
    Public Sub actualizaClaveSAT(clave As Int32, idClienteSAY As Integer)
        Dim objDa As New Datos.ClientesDatosDA
        objDa.actualizaClaveSAT(clave, idClienteSAY)
    End Sub

    Public Function consultaUsoCFDI(ByVal personaFisica As Int32, ByVal personaMoral As Int32) As DataTable
        Dim dtUsoCfdi As New DataTable
        Dim objDa As New Datos.ClientesDatosDA

        dtUsoCfdi = objDa.consultaUsoCFDI(personaFisica, personaMoral)

        If dtUsoCfdi.Rows.Count > 0 Then
            Dim dtRow As DataRow = dtUsoCfdi.NewRow
            dtRow("cfus_clave_usocfdi") = 0
            dtRow("cfus_descripcion") = ""
            dtUsoCfdi.Rows.InsertAt(dtRow, 0)
        End If

        Return dtUsoCfdi
    End Function

    Public Function consultaUsoCFDIPorCliente(ByVal clienteid As Int32) As String
        Dim dtUsoCfdi As New DataTable
        Dim objDa As New Datos.ClientesDatosDA
        Dim claveCFDI As String = String.Empty

        dtUsoCfdi = objDa.consultaUsoCFDIPorCliente(clienteid)

        If dtUsoCfdi.Rows.Count > 0 Then
            claveCFDI = dtUsoCfdi.Rows(0).Item("claveUsoCFDI")
        End If

        Return claveCFDI
    End Function

    Public Sub editarUsoCFDICliente(ByVal clienteid As Int32, ByVal clave As String)
        Dim objDa As New Datos.ClientesDatosDA
        objDa.editarUsoCFDICliente(clienteid, clave)

    End Sub

    Public Function consultaRestriccionClienteMarca(ByVal clienteid As Int32) As DataTable
        Dim objDa As New Datos.ClientesDatosDA
        Dim dtRestriccion As New DataTable

        dtRestriccion = objDa.consultaRestriccionClienteMarca(clienteid)

        Return dtRestriccion
    End Function

    Public Sub insertaActualizaMarcaPorFacturaCliente(ByVal clienteid As Int32, ByVal marcaid As Int32, ByVal operacionM As Int32,
                                                      ByVal seleccion As Int32)
        Dim objDa As New Datos.ClientesDatosDA
        objDa.insertaActualizaMarcaPorFacturaCliente(clienteid, marcaid, operacionM, seleccion)
    End Sub

    Public Function consultaMarcasConcatenadasRestriccionFactura(ByVal clienteid As Int32) As DataTable
        Dim objDa As New Datos.ClientesDatosDA
        Dim dtRestriccion As New DataTable

        dtRestriccion = objDa.consultaMarcasConcatenadasRestriccionFactura(clienteid)

        Return dtRestriccion
    End Function

    Public Function consultaUsoCFDIPedidos(ByVal personaFisica As Int32, ByVal personaMoral As Int32) As DataTable
        Dim dtUsoCfdi As New DataTable
        Dim objDa As New Datos.ClientesDatosDA

        dtUsoCfdi = objDa.consultaUsoCFDIPedidos(personaFisica, personaMoral)

        If dtUsoCfdi.Rows.Count > 0 Then
            Dim dtRow As DataRow = dtUsoCfdi.NewRow
            dtRow("cfus_clave_usocfdi") = 0
            dtRow("cfus_descripcion") = ""
            'dtUsoCfdi.Rows.InsertAt(dtRow, 0)
        End If

        Return dtUsoCfdi
    End Function
#End Region

    Public Function ExisteTiendaEnPedidosActivos(ByVal PersonaID As Integer) As Boolean
        Dim objActualizaProspecta As New Datos.ClientesDatosDA
        Dim ExisteTiendaEnPedido As Boolean = False
        Dim dtResultado As DataTable

        dtResultado = objActualizaProspecta.ExisteTiendaEnPedidosActivos(PersonaID)

        If dtResultado.Rows.Count > 0 Then
            If CType(dtResultado.Rows(0).Item(0), Integer) > 0 Then
                ExisteTiendaEnPedido = True
            Else
                ExisteTiendaEnPedido = False
            End If
        Else
            ExisteTiendaEnPedido = False
        End If


        Return ExisteTiendaEnPedido

    End Function


    Public Function ObtenerIdMarcaIdFamilia(ByVal xml As String)
        Dim obj As New Datos.ClientesDatosDA
        Return obj.ObtenerIdMarcaIdFamilia(xml)
    End Function


    Public Function ConsultaPedidosCliente(ByVal idCliente As Integer)
        Dim obj As New Datos.ClientesDatosDA
        Return obj.ConsultaPedidosCliente(idCliente)
    End Function

    Public Function ConsultaPedidosDetalleCliente(ByVal idpedido As Integer)
        Dim obj As New Datos.ClientesDatosDA
        Return obj.ConsultaPedidosDetalleCliente(idpedido)
    End Function

    Public Function ValidaExistenArticulos(ByVal idPedido As Integer, ByVal idMarca As Integer, ByVal idFamilia As Integer)
        Dim obj As New Datos.ClientesDatosDA
        Return obj.ValidaExistenArticulos(idPedido, idMarca, idFamilia)
    End Function

    Public Function Eliminarregistro(ByVal cadenaids As String)
        Dim obj As New Datos.ClientesDatosDA
        Return obj.Eliminarregistro(cadenaids)
    End Function

    Public Function GuardarBitacoraInactivos(ByVal id As Integer, ByVal idcliente As Integer, ByVal idmarca As Integer, ByVal idfamiliap As Integer,
                                            ByVal colaboradoridagente As Integer, ByVal usuarioinactivo As Integer)
        Dim obj As New Datos.ClientesDatosDA
        Return obj.GuardarBitacoraInactivos(id, idcliente, idmarca, idfamiliap, colaboradoridagente, usuarioinactivo)
    End Function

End Class
