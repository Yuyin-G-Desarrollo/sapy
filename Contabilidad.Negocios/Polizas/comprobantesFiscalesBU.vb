Imports Contabilidad.Datos

Public Class ComprobantesFiscalesBU


    Public Function proveedores() As DataTable
        Dim objDA As New comprobantesFiscalesDA
        Return objDA.proveedores()
    End Function

   
    Public Sub Alta_archivos_XML_CFDS(cfdIdNave As Integer, IdEmpresa As Integer, RfcEmpresa As String, RfcProveedor As String, IdProveedor As Integer, _
                                          Fecha As DateTime, Version As String, Serie As String, Folio As String, Total As Decimal, RutaXml As String, _
                                          RutaVisor As String, Estatus As String, IdTabla As Integer)

        Dim objDA As New comprobantesFiscalesDA

        objDA.Alta_archivos_XML_CFDS(cfdIdNave, IdEmpresa, RfcEmpresa, RfcProveedor, IdProveedor, _
                                          Fecha, Version, Serie, Folio, Total, RutaXml, _
                                          RutaVisor, Estatus, IdTabla)

    End Sub

    Public Sub Actualiza_archivos_PDF_CFDS(RutaVisor As String, IdTabla As Integer)

        Dim objDA As New comprobantesFiscalesDA
        objDA.Actualiza_archivos_PDF_CFDS(RutaVisor, IdTabla)

    End Sub


    ''' <summary>
    ''' CONSULTA LA LISTA DE LOS CONTRIBUYENTES A LOS QUE TIENE ACCESO UN USUARIO
    ''' </summary>
    ''' <param name="usuarioID">ID DEL USUARIO DEL CUAL DE RECUPERARA LA LISTA DE CONTRIBUYENTES</param>
    ''' <returns>RESULTADO DE LA EJECUCION DE LA CONSULTA EN UN DATATABLE</returns>
    ''' <remarks></remarks>
    Public Function CargaEmpresaSicy_Contribuyente(ByVal usuarioID As Integer) As DataTable
        Dim objDA As New Datos.comprobantesFiscalesDA
        CargaEmpresaSicy_Contribuyente = New DataTable
        CargaEmpresaSicy_Contribuyente = objDA.CargaEmpresaSicy_Contribuyente(usuarioID)
        Return CargaEmpresaSicy_Contribuyente
    End Function

    ''' <summary>
    ''' RECUPERA LAS RAZONES SOCIALES(CLIENTES) DE UNA O VARIAS CADENAS(CADENAS)  
    ''' </summary>
    ''' <param name="CadenaCadenas">STRING CON LOS IDS DE LAS CADENAS DE LAS CUALES SE RECUPERARAN SUS RAZONES SOCIALES</param>
    ''' <returns>RESULTADO DE LA EJECUCION DE LA CONSULTA EN UN DATATABLE</returns>
    ''' <remarks></remarks>
    Public Function RecuperarClientesDeCadenaSicy(ByVal CadenaCadenas As String) As DataTable
        Dim objDA As New Datos.comprobantesFiscalesDA
        RecuperarClientesDeCadenaSicy = New DataTable
        RecuperarClientesDeCadenaSicy = objDA.RecuperarClientesDeCadenaSicy(CadenaCadenas)
        Return RecuperarClientesDeCadenaSicy
    End Function

    ''' <summary>
    ''' CONSULTA LA LISTA DE LAS NAVES RELACIONADAS CON UN CONTRIBUYENTE EN ESPECIFICO
    ''' </summary>
    ''' <param name="IdContribuyente">ID DEL CONTRIBUYENTE DEL CUAL SE RECUPERARAN LAS NAVES</param>
    ''' <returns>RESULTADO DE LA EJECUCION DE LA CONSULTA EN UN DATATABLE</returns>
    ''' <remarks></remarks>
    Public Function RecuperarNavesDeControbuyente(ByVal IdContribuyente As String) As DataTable
        Dim objDA As New Datos.comprobantesFiscalesDA
        RecuperarNavesDeControbuyente = New DataTable
        RecuperarNavesDeControbuyente = objDA.RecuperarNavesDeControbuyente(IdContribuyente)
        Return RecuperarNavesDeControbuyente

    End Function

    ''' <summary>
    ''' CONSULTA LAS CADENAS RELACIONADAS A UN CONTRIBUYENTE EN ESPECIFICO
    ''' </summary>
    ''' <param name="IdContribuyente">ID DEL CONTRIBUYENTE DEL CUAL SE CONSULTARAN LAS CADENAS </param>
    ''' <returns>RESULTADO DE LA EJECUCION DE LA CONSULTA EN UN DATATABLE</returns>
    ''' <remarks></remarks>
    Public Function CadenasSicy_Segun_Contribuyente(ByVal IdContribuyente As Integer) As DataTable
        Dim objDA As New Datos.comprobantesFiscalesDA
        CadenasSicy_Segun_Contribuyente = New DataTable
        CadenasSicy_Segun_Contribuyente = objDA.CadenasSicy_Segun_Contribuyente(IdContribuyente)
        Return CadenasSicy_Segun_Contribuyente
    End Function

    ''' <summary>
    ''' CONSULTA LOS TIPOS DE POLIZAS DEPENDIENDO DE EL TIPO DE COMPROBANTES QUE SE BUSCARAN 
    ''' </summary>
    ''' <param name="No_Tipo_Ingresos_Egresos"> VARIABLE DEL TIPO CADENA CUYO VALOR PUEDE SER "INGRESOS" PARA CONSULTAR LAS POLIZAS DE INGRESOS Y "EGRESOS"
    ''' PARA CONSULTAR LAS POLIZAS DE EGRESOS</param>
    ''' <returns>RESULTADO DE LA EJECUCION DE LA CONSULTA EN UN DATATABLE</returns>
    ''' <remarks></remarks>
    Public Function CargaTiposPoliza(ByVal No_Tipo_Ingresos_Egresos As Integer) As DataTable
        Dim objDA As New Datos.comprobantesFiscalesDA
        CargaTiposPoliza = New DataTable
        CargaTiposPoliza = objDA.CargaTiposPoliza(No_Tipo_Ingresos_Egresos)
        Return CargaTiposPoliza
    End Function

    ''' <summary>
    ''' CONSULTA LOS COMPROBANTES DE EGRESOS EXISTENTES
    ''' </summary>
    ''' <param name="IdContribuyentesicy">ID DE EL CONTRIBUYENTE DE LA TABLA CONTRIBUYENTES DE LA BASE DE DATOS DEL SICY</param>
    ''' <param name="Fec_Inicio">FECHA DE INICIO DEL RANGO DE BUSQUEDA DE COMPROBANTES</param>
    ''' <param name="Fec_Fin">FECHA DE FIN DEL RANGO DE BUSQUEDA DEL COMPROBANTE</param>
    ''' <param name="CadenaIdsProovedores">VARIABLE DEL TIPO STRING CON LOS IDS DE LOS PROVEEDORES POR LOS CUALES SE BUSCARAN LOS COMPROBANTES, PUEDE ESTAR VACIA</param>
    ''' <param name="IdNave">ID DE LA NAVE DE LA CUAL SE BUSCARAN COMPROBANTES, PUEDE ESTAR EN VALOR 0</param>
    ''' <param name="Folio">FOLIO DEL COMPROBANTE</param>
    ''' <param name="FolioExacto_O_FolioAproximado">VARIABLE DEL TIPO BOOLEANO QUE INDICA SI EL FOLIO QUE SE BUSCARA TIENE QUE SER EXATO CUANDO ESTA EN VALOR  "TRUE"
    ''' O SI SE BUSCARA EL COMPROBANTE POR FOLIO APROXIMADO SI SU VALOR ES "FALSE"</param>
    ''' <returns>RESULTADO DE LA EJECUCION DE LA CONSULTA EN UN DATATABLE</returns>
    ''' <remarks></remarks>
    Public Function CargarComprobantes_Egresos(ByVal IdContribuyentesicy As String, ByVal Fec_Inicio As String, ByVal Fec_Fin As String,
                                               ByVal CadenaIdsProovedores As String, ByVal IdNave As Integer, ByVal Folio As String,
                                               ByVal FolioExacto_O_FolioAproximado As Boolean) As DataTable
        Dim objDA As New Datos.comprobantesFiscalesDA
        CargarComprobantes_Egresos = New DataTable
        CargarComprobantes_Egresos = objDA.CargarComprobantes_Egresos(IdContribuyentesicy, Fec_Inicio, Fec_Fin, CadenaIdsProovedores,
                                                              IdNave, Folio, FolioExacto_O_FolioAproximado)
        Return CargarComprobantes_Egresos
    End Function

    ''' <summary>
    ''' CONSULTA LOS COMPROBANTES FISCALLES QUE ESTEN O NO ESTEN DENTRO DE UNA POLIZA DEL TIPO "TRANSFERENCIA"
    ''' </summary>
    ''' <param name="IdContribuyentesicy">ID DEL CONTRIBUYENTE DE LA TABLA CONTRIBUYENTES DE LA BASE DE DATOS DEL SICY</param>
    ''' <param name="Documento_EnPoliza_O_SinContabilizar">VARIABLE DEL TIPO BOOLEANO QUE INDICA QUE LOS COMPROBANTES QUE SE BUSCARAN DEBEN DE ESTAR DENTRO DE UNA
    ''' POLIZA DE TRANSFERENCIAS CUANDO SU VALOR ES TRUE, Y QUE LA BUSQUEDA SERA PARA LOS COMPROBANTES QUE NO ESTEN DENTRO DE UNA POLIZA DE TRANSFERENCIA CUANDO
    ''' SU VALOR ESTE EN FALSE</param>
    ''' <param name="Fecha_EnDocumento_O_EnPoliza">VARIABLE DEL TIPO BOOLEANO QUE INDICA QUE LA CONSULTA SE REALIZARA POR FECHA EN COMPRONBANTE CUANDO SU VALOR SEA TRUE
    ''' Y QUE LA CONSULTA SE REALIZARA POR FECHA DE POLIZA CUANDO SU VALOR SEA FALSO</param>
    ''' <param name="Fec_Inicio">FECHA DE INICIO DE LA BUSQUEDA</param>
    ''' <param name="Fec_Fin">FECHA DE FIN DE LA BUSQUEDA</param>
    ''' <param name="CadenaIdsProovedores">CADENA CON LOS IDS DE LOS PROVEEDORES POR LOS QUE SE REALIZARA LA CONSULTA, SI LA VARIABLE = "" ENTONCES INDICA QUE NO SE REALIZARA 
    ''' LA BUSQUEDA POR ID DE PROVEEDORES</param>
    ''' <param name="IdNave">ID DE LA NAVE POR LA QUE SE REALIZARA LA BUSQUEDA DE COMPROBANTES, SI EL ID = 0 ENTONCES INDICA QUE NO SE REALIZARA LA BUSQUEDA POR NAVE</param>
    ''' <param name="Folio">FOLIO DEL COMPROBANTE POR EL CUAL SE REALIZARA LA CONSULTA, SI EL FOLIO = "" INDICA QUE NO SE REALIZARA LA BUSQUEDA POR FOLIO</param>
    ''' <param name="FolioExacto_O_FolioAproximado">VARIABLE DEL TIPO BOLEANO QUE INDICA QUE EL FOLIO QUE SE BUSCARA SERA EXACTO CUANDO SU VALOR SEA POSITIVO Y 
    ''' QUE LA BUSQUEDA POR FOLIO SERA APROXIMADA CUANDO SU VALOR SEA NEGAIVO</param>
    ''' <param name="IdTipoPoliza">ID DEL TIPO DE POLIZA POR EL CUAL SE REALIZARA LA BUSQUEDA, ESTE SIEMPRE SERA EL ID DE LAS POLIZAR DEL TIPO DE TRANSFERENCIA</param>
    ''' <returns>RESULTADO DE LA EJECUCION DE LA CONSULTA</returns>
    ''' <remarks></remarks>
    Public Function CargarComprobantes_PolizaCompras_Egresos(ByVal IdContribuyentesicy As String, ByVal Documento_EnPoliza_O_SinContabilizar As Boolean,
                                                             ByVal Fecha_EnDocumento_O_EnPoliza As Boolean, ByVal Fec_Inicio As String,
                                                             ByVal Fec_Fin As String, ByVal CadenaIdsProovedores As String, ByVal IdNave As Integer,
                                                             ByVal Folio As String, ByVal FolioExacto_O_FolioAproximado As Boolean, ByVal IdTipoPoliza As Integer)
        Dim objDA As New Datos.comprobantesFiscalesDA
        CargarComprobantes_PolizaCompras_Egresos = New DataTable
        CargarComprobantes_PolizaCompras_Egresos = objDA.CargarComprobantes_PolizaCompras_Egresos(IdContribuyentesicy, Documento_EnPoliza_O_SinContabilizar,
                                                                                                  Fecha_EnDocumento_O_EnPoliza, Fec_Inicio, Fec_Fin, CadenaIdsProovedores,
                                                                                                  IdNave, Folio, FolioExacto_O_FolioAproximado, IdTipoPoliza)
        Return CargarComprobantes_PolizaCompras_Egresos
    End Function

    ''' <summary>
    ''' FUNCION QUE REALIZA LA CONSULTA DE LOS COMPROBANTES FISCALES QUE SE ENCUENTRAN DENTRO DE UNA POLIZA DE COMPRAS O TRODOS LOS COMPROBANTES QUE NO SE ENCUENTRAN
    ''' DENTRO DE UNA POLIZA DE COMPRAS, USANDO DIFERENTES FILTROS
    ''' </summary>
    ''' <param name="IdContribuyentesicy">ID DEL CONTRIBUYENTE POR EL CUAL SE REALIZARA LA CONSULTA</param>
    ''' <param name="Documento_EnPoliza_O_SinContabilizar">VARIABLE DEL TIPO BOLEANO QUE INDICA QUE LOS COMPROBANTES QUE SE BUSCARAN NO ESTARAN DENTRO DE UNA POLIZA CUANDO
    ''' SU VALOR SEA POSITIVO, E INDICA QUE LOS COMPROBANTES QUE SE BUSCARAN DEBERAN ESTAR DENTRO DE UNA POLIZA DE VENTAS CUANDO SU VALOR SEA NEGATIVO</param>
    ''' <param name="Fecha_EnDocumento_O_EnPoliza">VARIABLE DEL TIPO BOLEANO QUE INDICA QUE LA BUSQUEDA SE REALIZARA POR FECHA DEL COMPROBANTE CUANDO SU VALOR SEA POSITIVO 
    ''' OQ EU LA BUSQUEDA SE REALIZARA POR FECHA</param>
    ''' <param name="Fec_Inicio">FECHA DE INICIO DE EL RANGO DE BUSQUEDA DE FECHA</param>
    ''' <param name="Fec_Fin">FECHA DE FIN DEL RANGO DE BUSQUEDA DE LA FECHA</param>
    ''' <param name="CadenaIdsProovedores">CADENA CON LOS IDS DE LOS PROVEEDORES POR LOS QUE SE REALIZARA LA BUSQUEDA, SI EL VARIABLE = "" INDICA QUE NO SE REALIZARA LA BUSQUEDA POR IDS DE PROVEEDORES</param>
    ''' <param name="IdNave">ID DE LA NAVE POR LA CUAL SE REALIZARA LA BUSQUEDA, SI LA VARIABLE = 0 INDICA QUE NO SE REALIZARA LA BUSQUEDA POR NAVE</param>
    ''' <param name="Folio">FOLIO DE EL COMPROBANTE POR EL CUAL SE REALIZARA LA BUSQUEDA, SI LA VARIABLE = "" INDICA QUE NO SE REALIZARA LA BUSQUEDA POR FOLIO</param>
    ''' <param name="FolioExacto_O_FolioAproximado">VARIABLE DEL TIPO BOLEANO QUE INDICA QUE LA BUSQUEDA SE REALIZARA POR FOLIO EXACTO CUANDO LA VARIABLE SEA = TRUE
    ''' Y QUE LA BUSQUEDA SE REALIZARA POR FOLIO APROXIMADO CUANDO LA VARIABLE = FALSE</param>
    ''' <param name="IdTipoPoliza">ID DEL TIPO POLIZA POR EL QUE SE REALIZARA LA BUQUEDA, EN ESTE CASO SIEMPRE SERA PARA POLIZAS DE TRANSFERENCIA</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function CargarComprobantes_PolizaTransferencia_Egresos(ByVal IdContribuyentesicy As String, ByVal Documento_EnPoliza_O_SinContabilizar As Boolean,
                                                             ByVal Fecha_EnDocumento_O_EnPoliza As Boolean, ByVal Fec_Inicio As String, ByVal Fec_Fin As String,
                                                             ByVal CadenaIdsProovedores As String, ByVal IdNave As Integer, ByVal Folio As String,
                                                             ByVal FolioExacto_O_FolioAproximado As Boolean, ByVal IdTipoPoliza As Integer)
        Dim objDA As New Datos.comprobantesFiscalesDA
        CargarComprobantes_PolizaTransferencia_Egresos = New DataTable
        CargarComprobantes_PolizaTransferencia_Egresos = objDA.CargarComprobantes_PolizaTransferencia_Egresos(IdContribuyentesicy, Documento_EnPoliza_O_SinContabilizar,
                                                              Fecha_EnDocumento_O_EnPoliza, Fec_Inicio, Fec_Fin, CadenaIdsProovedores, IdNave, Folio,
                                                              FolioExacto_O_FolioAproximado, IdTipoPoliza)
        Return CargarComprobantes_PolizaTransferencia_Egresos
    End Function

    ''' <summary>
    '''  FUNCION PARA BUSCAR TODOS LOS COMPROBANTES DE INGRESOS
    ''' </summary>
    ''' <param name="IdEmpresaSay">ID DE LA EMPRESA EN LA BASE DE DATOS DEL SAY POR LA CUAL SE REALIZARA LA BUSQUEDA DE COMPROBANTES</param>
    ''' <param name="Fec_Inicio">FECHA DE INICIO DEL RANGO DE BUSQUEDA DE COMPROBANTES POR FECHA DE COMPROBANTES</param>
    ''' <param name="Fec_Fin">FECHA DE FIN DEL RANGO DE BUSQUEDA DE COMPROBANTES POR FECHA DE COMPROBANTES</param>
    ''' <param name="CadenaClientesSicy">CADENA CON EL ID DEL CLIENTE DE LA TABLA CLIENTES DE LA BASE DE DATOS DEL SICY</param>
    ''' <param name="FolioExacto_O_FolioAproximado">VARIABLE DEL TIPO BOLEANO QUE INDICA QUE LA BUSQUEDA SE REALIZARA PÓR FOLIO EXACTO CUANDO SU VALOR SEA TRUE
    ''' Y QUE LA BUSQUEDA SE REALIZARA POR FOLIO APROXIMADO CUANDO SU VALOR SEA FALSE</param>
    ''' <param name="Folio">FOLIO POR EL CUAL SE REALZIARA LA BUSQUEDA DE COMPROBANTES, SI LA VARIABLE = "" INDICA QUE NO SE REALIZARA LA BUSQUEDA POR FOLIO</param>
    ''' <returns>RESULTADO DE LA EJECUCION DE LA CONSULTA EN UN DATATABLE</returns>
    ''' <remarks></remarks>
    Public Function CargarComprobante_Ingresos(ByVal IdEmpresaSay As Integer, ByVal Fec_Inicio As String, ByVal Fec_Fin As String, CadenaClientesSicy As String,
                                                           ByVal FolioExacto_O_FolioAproximado As Boolean, ByVal Folio As String)
          Dim objDA As New Datos.comprobantesFiscalesDA
        CargarComprobante_Ingresos = New DataTable
        CargarComprobante_Ingresos = objDA.CargarComprobante_Ingresos(IdEmpresaSay, Fec_Inicio, Fec_Fin, CadenaClientesSicy, FolioExacto_O_FolioAproximado, Folio)
        Return CargarComprobante_Ingresos
    End Function

    ''' <summary>
    ''' EJECUTA LA CONSULTA PARA REALIZAR LA BUSQUEDA DE COMPROBANTES QUE ESTEN DENTRO DE UNA POLIZA DE VENTAS O LOS COMPROBANTES QUE NO SE ENCUENTREN 
    ''' DENTRO DE UNA POLIZA DE VENTAS
    ''' </summary>
    ''' <param name="IdEmpresaSay">IS DE LA EMPRESA EN LA BASE DE DATOS DEL SAY POR LA CUAL SE REALIZARA LA BUSQUEDA DE COMPROBANTES</param>
    ''' <param name="Documento_EnPoliza_O_SinContabilizar">VARIABLE DEL TIPO BOLEANO QUE INDICA QUE LA BUSQUEDA SE REALIZARA POR COMPROBANTES DENTRO DE UNA POLIZA 
    ''' DE VENTAS CUANDO SU VALOR SEA TRUE Y QUE LOS COMPROBANTES QUE SE BUSCARAN NO DEBEN DE ESTAR DENTRO DE UNA POLIZA DE VENTAS CUANDO SU VALOR SEA FALSE</param>
    ''' <param name="IdTipoPoliza">ID DEL TIPO DE POLIZA POR LA CUAL SE REALIZARA LA CONSULTA, EN ESTE CASO SIEMPRE SERA EL ID DE LAS POLIZAS DE VENTAS</param>
    ''' <param name="Fecha_EnDocumento_O_EnPoliza">VARIABLE DEL TIPO BOOLEAN QUE INDICA QUE LA BUSQUEDA SE REALZIARA POR FECHA EN DOCUMENTO CUANDO SU VALOR SEA TRUE Y QUE LA BUSQUEDA SE REALZIARA POR 
    ''' FECHA EN POLIZA CUANDO SU VALOR SEA FALSE</param>
    ''' <param name="Fec_Inicio">FECHA DE INICIO DEL RANGO DE BUSQUEDA DE COMPROBANTES</param>
    ''' <param name="Fec_Fin">FECHA DE FIN DEL RANGO DE BUSQUEDA DE COMPROBANTES</param>
    ''' <param name="CadenaClientesSicy">CADENA CON LOS IDS DE LOS CLIENTES  DE LA BASE DE DATOS DEL SICY POR LOS CUALES SE REALIZARA LA BUSQUEDA DE COMPROBANTES, SI LA VARIABLE = "" INDICA QUE NO SE REALZIARA
    ''' LA BUSQUEDA POR CLIENTE</param>
    ''' <param name="Folio">FOLIO POR EL CUAL SE REALIZARA LA BUSQUEDA DE COMPROBANTES, SI LA VARIABLE = "" INDICA QUE NO SE REALIZARA LA BUSQUEDA POR FOLIO</param>
    ''' <param name="FolioExacto_O_FolioAproximado">VARIABLE DEL TIPO BOLEANO QUE INDICA QUE LA BUSQUEDA SE REALIZARA POR FOLIO EXACTO CUANDO LA VARIABLE SEA TRUE
    ''' Y QUE LA BUSQUEDA SERA POR FOLIO APROXIMADO CUANDO LA VARIABLE SEA FALSE</param>
    ''' <returns>RESULTADO DE LA EJECUCION DE LA CONSULTA</returns>
    ''' <remarks></remarks>
    Public Function CargarComprobante_PolizaVentas_Ingresos(ByVal IdEmpresaSay As String, ByVal Documento_EnPoliza_O_SinContabilizar As Boolean,
                                                       ByVal IdTipoPoliza As Integer, ByVal Fecha_EnDocumento_O_EnPoliza As Boolean,
                                                       ByVal Fec_Inicio As String, ByVal Fec_Fin As String, ByVal CadenaClientesSicy As String,
                                                       ByVal Folio As String, ByVal FolioExacto_O_FolioAproximado As Boolean)

        Dim objDA As New Datos.comprobantesFiscalesDA
        CargarComprobante_PolizaVentas_Ingresos = New DataTable
        CargarComprobante_PolizaVentas_Ingresos = objDA.CargarComprobante_PolizaVentas_Ingresos(IdEmpresaSay, Documento_EnPoliza_O_SinContabilizar, IdTipoPoliza, Fecha_EnDocumento_O_EnPoliza,
                                                        Fec_Inicio, Fec_Fin, CadenaClientesSicy, Folio, FolioExacto_O_FolioAproximado)

        Return CargarComprobante_PolizaVentas_Ingresos
    End Function

    Public Function CargarComprobante_PolizaNotasCredito_Ingresos(ByVal IdEmpresaSay As String, ByVal Documento_EnPoliza_O_SinContabilizar As Boolean,
                                                      ByVal IdTipoPoliza As Integer, ByVal Fecha_EnDocumento_O_EnPoliza As Boolean,
                                                      ByVal Fec_Inicio As String, ByVal Fec_Fin As String, ByVal CadenaClientesSicy As String,
                                                      ByVal Folio As String, ByVal FolioExacto_O_FolioAproximado As Boolean)

        Dim objDA As New Datos.comprobantesFiscalesDA
        CargarComprobante_PolizaNotasCredito_Ingresos = New DataTable
        CargarComprobante_PolizaNotasCredito_Ingresos = objDA.CargarComprobante_PolizaNotasCredito_Ingresos(IdEmpresaSay, Documento_EnPoliza_O_SinContabilizar, IdTipoPoliza, Fecha_EnDocumento_O_EnPoliza,
                                                        Fec_Inicio, Fec_Fin, CadenaClientesSicy, Folio, FolioExacto_O_FolioAproximado)

        Return CargarComprobante_PolizaNotasCredito_Ingresos
    End Function

    ''' <summary>
    ''' CONSULTA LOS IDS DE PROVEEDORES Y SU RAZON SOCIAL DE LA BASE DE DATOS DEL SICY CUANDO SU ESTATUS SEA ACTIVP
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ConsultarProveedoresSicy() As DataTable
        Dim objDA As New Datos.comprobantesFiscalesDA
        Return objDA.ConsultarProveedoresSicy
    End Function


    Public Function ListadoParametroUbicacion(tipo_busqueda As Integer, id_parametros As String) As DataTable
        Dim objbu As New Contabilidad.Datos.comprobantesFiscalesDA
        Dim tabla As New DataTable
        tabla = objbu.ListadoParametroUbicacion(tipo_busqueda, id_parametros)
        Return tabla
    End Function


  

End Class
