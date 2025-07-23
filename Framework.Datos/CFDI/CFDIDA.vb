Imports Entidades
Imports System.Data.SqlClient

Public Class CFDIDA
    Public Function getFacturasEliminadas(ByVal idNaveSay As Integer, ByVal f1 As Date, ByVal f2 As Date) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim datos As New DataTable
        Dim consulta As String =
           CStr(<cadena>
                    Select  cfd_razonSocialProveedor 'PROVEEDOR',cfd_RfcEmpresa 'RFC EMPRESA',
                    cfd_RfcProveedor 'RFC PROVEEDOR',cfd_Fecha 'FECHA FACTURA',cfd_fechaEliminado 'ELIMINADA',
                    cfd_Serie 'SERIE',cfd_Folio 'FOLIO',cfd_Total 'TOTAL', cfd_RutaXml 'rutaXML', cfd_RutaVisor 'rutaPDF'
                    from CFDSValidador
                    where cfd_eliminado=1 and cfd_IdNave=<%= getNaveAlmacenSIcy(getNaveSIcy(idNaveSay)) %> 
                    and cfd_fechaEliminado BETWEEN '<%= f1.ToString("dd/MM/yyyy") %> 00:00:00.000' 
                    and '<%= f2.ToString("dd/MM/yyyy") %> 23:59:59.000'
                    order by cfd_FechaRegistro asc
                </cadena>)
        Return operaciones.EjecutaConsulta(consulta)

    End Function

    'Public Function getFacturasAutorizadas(ByVal idNaveSay As Integer, ByVal f1 As Date, ByVal f2 As Date) As DataTable
    '    Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
    '    Dim datos As New DataTable
    '    Dim consulta As String =
    '       CStr(<cadena>
    '                select RazonSocial 'PROVEEDOR',cfdRfcEmpresa 'RFC EMPRESA',
    '                cfdRfcProveedor 'RFC PROVEEDOR',cfdFecha 'FECHA FACTURA', cfdFechaRegistro 'AUTORIZADA',
    '                cfdSerie 'SERIE',cfdFolio 'FOLIO',cfdTotal 'TOTAL', cfdRutaXml 'rutaXML', cfdRutaVisor 'rutaPDF'
    '                from CFDS 
    '                left join proveedores on cfdIdProveedor=IdProveedor
    '                where cfdIdNave=<%= getNaveAlmacenSIcy(getNaveSIcy(idNaveSay)) %> 
    '                and cfdFechaRegistro BETWEEN '<%= f1.ToString("dd/MM/yyyy") %> 00:00:00.000' 
    '                and '<%= f2.ToString("dd/MM/yyyy") %> 23:59:59.000'
    '                order by cfdFechaRegistro desc
    '            </cadena>)
    '    Return operaciones.EjecutaConsulta(consulta)

    'End Function

    Public Function getConfiguracionNave(ByVal idNaveSay As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim datos As New DataTable
        Dim consulta As String =
           CStr(<cadena>
           select fac_correo,fac_serverEntrada,fac_contrasena,fac_rutaFacturas,fac_puertoEntrada,fac_rutaFacturasPorAutorizar from ConfiguracionRecepcionFacturas where fac_idNaveSay=<%= idNaveSay %>
                </cadena>)
        Return operaciones.EjecutaConsulta(consulta)

    End Function
    Public Function getNaveAlmacenSIcy(ByVal idNaveSicy As Integer) As Integer
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim datos As New DataTable
        Dim consulta As String =
           CStr(<cadena>
           SELECT idAlmacen FROM NavesAlmacen WHERE idnave=<%= idNaveSicy %>
                </cadena>)
        datos = operaciones.EjecutaConsulta(consulta)
        If datos.Rows.Count > 0 Then
            Return Convert.ToInt32(datos.Rows(0).Item(0).ToString)
        End If
        Return 0
    End Function
    Public Function getNaveSIcy(ByVal idNaveSay As Integer) As Integer
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim datos As New DataTable
        Dim consulta As String =
           CStr(<cadena>
           select nave_navesicyid from Framework.Naves where nave_naveid=<%= idNaveSay %>
                </cadena>)
        datos = operaciones.EjecutaConsulta(consulta)
        If datos.Rows.Count > 0 Then
            Return Convert.ToInt32(datos.Rows(0).Item(0).ToString)
        End If
        Return 0
    End Function
    Public Function getCFDISinRecibir(ByVal idNave As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@NaveID"
        parametro.Value = idNave
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Proveedores].[SP_ObtenerFacturas_ValidadorCFDI_PorAutorizar_13042022]", listaParametros)

        'Dim consulta As String =
        'CStr(<cadena>
        '    SELECT DISTINCT cfd_Id 'idFactura',cfd_EstatusRecibido 'AUTORIZAR',cfd_razonSocialProveedor 'PROVEEDOR',cfd_RfcEmpresa 'RFC EMPRESA',
        '    RTRIM(replace(RFC,'-','')) 'RFC PROVEEDOR2',cfd_RfcProveedor as 'RFC PROVEEDOR',cfd_Fecha 'FECHA FACTURA', cfd_FechaRegistro 'FECHA REGISTRO',
        '    cfd_Serie 'SERIE',cfd_Folio 'FOLIO',cfd_Total 'TOTAL',
        '    cfd_RutaXml 'RUTA',
        '    cfd_EstatusValidacion 'CORRECTA',cfd_uuid 'UUID',cfd_IdNave 'idNave','' 'IMAGEN'  
        '    from CFDSValidador LEFT JOIN Proveedores ON RTRIM(replace(cfd_RfcProveedor,'-','')) = RTRIM(replace(RFC,'-',''))
        '    WHERE cfd_EstatusRecibido=0 and cfd_eliminado=0 and cfd_IdNave = <%= getNaveAlmacenSIcy(getNaveSIcy(idNave)) %> 
        '    ORDER BY cfd_FechaRegistro
        '     </cadena>)
        'Return operaciones.EjecutaConsulta(consulta)
    End Function
    Public Function getCFDIRecibidas(ByVal idNave As Integer, ByVal FechaInicio As Date, ByVal FechaFin As Date) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@NaveID"
        parametro.Value = idNave
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FechaInicio"
        parametro.Value = FechaInicio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FechaFin"
        parametro.Value = FechaFin
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Proveedores].[SP_ObtenerFacturas_ValidadorCFDI_Autorizadas_13042022]", listaParametros)

        'Dim consulta As String =
        'CStr(<cadena>
        '    Select  cfd_Id 'idFactura',cfd_EstatusRecibido 'AUTORIZAR',cfd_razonSocialProveedor 'PROVEEDOR',cfd_RfcEmpresa 'RFC EMPRESA',
        '    cfd_RfcProveedor 'RFC PROVEEDOR',cfd_Fecha 'FECHA FACTURA',
        '    cfd_Serie 'SERIE',cfd_Folio 'FOLIO',cfd_Total 'TOTAL',
        '    cfd_RutaXml 'RUTA',
        '    cfd_EstatusValidacion 'CORRECTA',cfd_uuid 'UUID',cfd_IdNave 'idNave','' 'IMAGEN'
        '    from CFDSValidador
        '    where cfd_EstatusRecibido=1 and cfd_IdNave=<%= getNaveAlmacenSIcy(getNaveSIcy(idNave)) %>
        '     </cadena>)
        'Return operaciones.EjecutaConsulta(consulta)

    End Function
    Public Function insertarFactura(ByVal xml As xml) As Integer
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim idTabla As New DataTable
        Dim idFactura As Integer = 0
        Dim listaparametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "@cfd_RfcEmpresa"
        parametro.Value = xml.rfcReceptor
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@cfd_RfcProveedor"
        parametro.Value = xml.rfcEmisor
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@cfd_Fecha"
        parametro.Value = xml.fechaxml
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@cfd_Version"
        parametro.Value = xml.version
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@cfd_Serie"
        parametro.Value = xml.serie
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@cfd_Folio"
        parametro.Value = xml.folio
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@cfd_Total"
        parametro.Value = xml.total
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@cfd_RutaXml"
        parametro.Value = xml.rutaxml
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@cfd_RutaVisor"
        parametro.Value = xml.rutapdf
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@cfd_EstatusRecibido"
        parametro.Value = 0
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@cfd_EstatusValidacion"
        parametro.Value = xml.estatusValidacion
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@cfd_uuid"
        parametro.Value = xml.uuid
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@cfd_razonSocialProveedor"
        parametro.Value = xml.razonSocEmisor
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@idNave"
        parametro.Value = getNaveAlmacenSIcy(getNaveSIcy(xml.idNave))
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@regimenfiscal"
        parametro.Value = xml.RegimenFiscal
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@razonSocialReceptor"
        parametro.Value = xml.razonSocReceptor
        listaparametros.Add(parametro)
        idTabla = objPersistencia.EjecutarConsultaSP("[dbo].[insertCFDIValidada_13042022]", listaparametros)
        If idTabla.Rows.Count > 0 Then
            idFactura = CInt(idTabla.Rows(0).Item(0).ToString)
        End If
        Return idFactura
    End Function
    Public Function actualizarRutadeFactura(ByVal idCFDI As Integer, ByVal rutaxml As String, ByVal rutapdf As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String =
        CStr(<cadena>
           update CFDSValidador set cfd_RutaXml='<%= rutaxml %>', cfd_RutaVisor='<%= rutapdf %>' where cfd_Id=<%= idCFDI %>
             </cadena>)
        Return operaciones.EjecutaConsulta(consulta)
    End Function
    Public Function eliminarFactura(ByVal idCFDI As Integer, ByVal ruta As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim rutaPDF = ruta.Replace("XML", "PDF")
        Dim consulta As String =
        CStr(<cadena>
           update CFDSValidador set cfd_eliminado=1 , cfd_fechaEliminado=getdate(),
           cfd_rutaxml='<%= ruta %>', cfd_RutaVisor = '<%= rutaPDF %>'
           where cfd_Id=<%= idCFDI %>
             </cadena>)
        Return operaciones.EjecutaConsulta(consulta)
    End Function
    Public Function recibirFacturaEstatusValidador(ByVal idCFDI As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String =
        CStr(<cadena>
          update CFDSValidador set cfd_EstatusRecibido=1 where cfd_Id=<%= idCFDI %>
             </cadena>)
        Return operaciones.EjecutaConsulta(consulta)
    End Function
    Public Function recibirFacturaInsertarCFDS(ByVal idCFDI As Integer) As String
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim tabla As New DataTable
        Dim mensaje As String = ""
        Dim listaparametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "@idFactura"
        parametro.Value = idCFDI
        listaparametros.Add(parametro)
        tabla = objPersistencia.EjecutarConsultaSP("[dbo].[SP_recibirFactura]", listaparametros)
        If tabla.Rows.Count > 0 Then
            mensaje = tabla.Rows(0).Item(0).ToString
        End If
        Return mensaje
    End Function
    Public Function validarReceptor(ByVal rfc As String) As Boolean
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim tabla As New DataTable
        Dim consulta As String = CStr(<cadena>SELECT *  FROM contribuyentes WHERE RTRIM(REPLACE(rfc,'-','')) = RTRIM(REPLACE('<%= rfc %>','-',''))</cadena>)
        tabla = objPersistencia.EjecutaConsulta(consulta)
        If tabla.Rows.Count >= 1 Then
            Return True
        End If
        Return False
    End Function
    Public Function validarExistenciaFactura(ByVal uuid As String) As String
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Dim tabla As New DataTable
        Dim mensaje As String = ""
        'Dim consulta As String = CStr(<cadena>SELECT * FROM cfdsvalidador WHERE cfd_uuid = '<%= uuid %>' AND cfd_eliminado = 0</cadena>)
        'tabla = objPersistencia.EjecutaConsulta(consulta)

        parametro = New SqlParameter("@UUID", uuid)
        listaParametros.Add(parametro)

        tabla = objPersistencia.EjecutarConsultaSP("[Proveedores].[SP_ValidaFactua_CFDISAY]", listaParametros)

        If tabla.Rows.Count >= 1 Then
            mensaje = tabla.Rows(0).Item(0).ToString

        End If
        Return mensaje
        'Return False
    End Function

    Public Function llenarComboProveedorNuevo() As DataTable
        Dim tabla As New DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String = CStr(<cadena> SELECT IdProveedor ProveedorID, RazonSocial RazonSocial FROM Proveedores WHERE Estatus='Activo' ORDER BY RazonSocial </cadena>)
        tabla = objPersistencia.EjecutaConsulta(consulta)
        Return tabla
    End Function

    Public Function llenarComboNaveSICY() As DataTable
        Dim tabla As New DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String = CStr(<cadena>SELECT C.Idcat NaveIDSICY, C.nomcat Nave FROM catalogos C JOIN NavesAlmacen NA ON C.Idcat = NA.idnave WHERE tipcat = 3</cadena>)
        tabla = objPersistencia.EjecutaConsulta(consulta)
        Return tabla
    End Function

    Public Function actualizarDatosFactura(ByVal NaveID As Integer, ByVal FolioNuevo As String, ByVal FolioAnterior As String, ByVal NaveAnteriorID As Integer, ByVal ProveedorAnteriorID As Integer, ByVal SerieP As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "@NaveID"
        parametro.Value = NaveID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Folio"
        parametro.Value = FolioNuevo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FolioAnterior"
        parametro.Value = FolioAnterior
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@NaveAnteriorID"
        parametro.Value = NaveAnteriorID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@ProveedorAnteriorID"
        parametro.Value = ProveedorAnteriorID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Serie"
        parametro.Value = SerieP
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Proveedores].[SP_ActualizaDatos_ValidadorFacturas]", listaParametros)

    End Function

    Public Function actualizarProveedorFactura(ByVal FolioNuevo As String, ByVal ProveedorAnteriorID As Integer, ByVal ProveedorID As Integer, ByVal SerieP As String, ByVal NaveID As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@ProveedorID"
        parametro.Value = ProveedorID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@NaveID"
        parametro.Value = NaveID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Folio"
        parametro.Value = FolioNuevo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@ProveedorAnteriorID"
        parametro.Value = ProveedorAnteriorID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Serie"
        parametro.Value = SerieP
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Proveedores].[SP_ActualizaDatosProveedor_ValidadorFacturas]", listaParametros)
    End Function

End Class
