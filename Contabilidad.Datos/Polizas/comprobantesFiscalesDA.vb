Imports System.Data.SqlClient
Imports Persistencia

Public Class comprobantesFiscalesDA

    Public Function proveedores() As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = ""
        consulta += " SELECT prov_sicyid,prov_nombregenerico FROM Proveedor.Proveedor"
        consulta += " where prov_activo = 1"
        Return objOperaciones.EjecutaConsulta(consulta)
    End Function

    Public Function Alta_archivos_XML_CFDS(cfdIdNave As Integer, IdEmpresa As Integer, RfcEmpresa As String, RfcProveedor As String, IdProveedor As Integer, _
                                          Fecha As DateTime, Version As String, Serie As String, Folio As String, Total As Decimal, RutaXml As String, _
                                          RutaVisor As String, Estatus As String, IdTabla As Integer)

        Dim operaciones As New OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)

        ',@cfdIdNave AS INT
        Dim parametro As New SqlParameter
        parametro.ParameterName = "@cfdIdNave"
        parametro.Value = cfdIdNave
        listaParametros.Add(parametro)

        ',@IdEmpresa AS INT
        parametro = New SqlParameter
        parametro.ParameterName = "@IdEmpresa"
        parametro.Value = IdEmpresa
        listaParametros.Add(parametro)

        ',@RfcEmpresa AS VARCHAR(20)
        parametro = New SqlParameter
        parametro.ParameterName = "@RfcEmpresa"
        parametro.Value = RfcEmpresa
        listaParametros.Add(parametro)

        ',@RfcProveedor AS VARCHAR(20)
        parametro = New SqlParameter
        parametro.ParameterName = "@RfcProveedor"
        parametro.Value = RfcProveedor
        listaParametros.Add(parametro)

        ',@IdProveedor AS INT
        parametro = New SqlParameter
        parametro.ParameterName = "@IdProveedor"
        parametro.Value = IdProveedor
        listaParametros.Add(parametro)

        ',@Fecha AS DATETIME
        parametro = New SqlParameter
        parametro.ParameterName = "@Fecha"
        parametro.Value = Fecha
        listaParametros.Add(parametro)

        ',@Version AS VARCHAR(3)
        parametro = New SqlParameter
        parametro.ParameterName = "@Version"
        parametro.Value = Version
        listaParametros.Add(parametro)

        ',@Serie AS VARCHAR(10)
        parametro = New SqlParameter
        parametro.ParameterName = "@Serie"
        parametro.Value = Serie
        listaParametros.Add(parametro)

        ',@Folio AS VARCHAR(50)
        parametro = New SqlParameter
        parametro.ParameterName = "@Folio"
        parametro.Value = Folio
        listaParametros.Add(parametro)

        ',@Total AS NUMERIC(18,4)
        parametro = New SqlParameter
        parametro.ParameterName = "@Total"
        parametro.Value = Total
        listaParametros.Add(parametro)

        ',@RutaXml AS VARCHAR(250)
        parametro = New SqlParameter
        parametro.ParameterName = "@RutaXml"
        parametro.Value = RutaXml
        listaParametros.Add(parametro)

        ',@RutaVisor AS VARCHAR(250)
        parametro = New SqlParameter
        parametro.ParameterName = "@RutaVisor"
        parametro.Value = RutaVisor
        listaParametros.Add(parametro)

        ',@Estatus AS VARCHAR(1)
        parametro = New SqlParameter
        parametro.ParameterName = "@Estatus"
        parametro.Value = Estatus
        listaParametros.Add(parametro)

        ',@IdTabla AS INTEGER(1)
        parametro = New SqlParameter
        parametro.ParameterName = "@IdTabla"
        parametro.Value = IdTabla
        listaParametros.Add(parametro)

        Return operaciones.EjecutarSentenciaSP("dbo.SP_CFDS_ALTA_DE_ARCHIVOS_XML", listaParametros)

    End Function

    Public Function Actualiza_archivos_PDF_CFDS(RutaVisor As String, IdTabla As Integer)

        Dim operaciones As New OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)


        Dim parametro As New SqlParameter
        ',@RutaVisor AS VARCHAR(250)
        parametro = New SqlParameter
        parametro.ParameterName = "@RutaVisor"
        parametro.Value = RutaVisor
        listaParametros.Add(parametro)

        ',@IdTabla AS INTEGER(1)
        parametro = New SqlParameter
        parametro.ParameterName = "@IdTabla"
        parametro.Value = IdTabla
        listaParametros.Add(parametro)

        Return operaciones.EjecutarSentenciaSP("dbo.SP_CFDS_ACTUALIZA_ARCHIVOS_PDF", listaParametros)

    End Function

    ''' <summary>
    ''' CONSULTA LA LISTA DE LOS CONTRIBUYENTES A LOS QUE TIENE ACCESO UN USUARIO
    ''' </summary>
    ''' <param name="usuarioID">ID DEL USUARIO DEL CUAL DE RECUPERARA LA LISTA DE CONTRIBUYENTES</param>
    ''' <returns>RESULTADO DE LA EJECUCION DE LA CONSULTA EN UN DATATABLE</returns>
    ''' <remarks></remarks>
    Public Function CargaEmpresaSicy_Contribuyente(ByVal usuarioID As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = String.Empty
        consulta += " SELECT cast(b.essc_sayid as varchar(3))+' '+cast(B.essc_razonsocial as varchar(250)) as 'RazonSocial', " +
                    " B.essc_contribuyentesicyid "
        consulta += " FROM Framework.permisosUsuarioEmpresa as C"
        consulta += " JOIN Framework.empresaSaySicyContpaq as B on B.essc_empresaid=C.prue_empresaid"
        consulta += " where C.prue_usuarioid = " + usuarioID.ToString

        Return objPersistencia.EjecutaConsulta(consulta)
    End Function

    ''' <summary>
    ''' RECUPERA LAS RAZONES SOCIALES(CLIENTES) DE UNA O VARIAS CADENAS(CADENAS)  
    ''' </summary>
    ''' <param name="CadenaCadenas">STRING CON LOS IDS DE LAS CADENAS DE LAS CUALES SE RECUPERARAN SUS RAZONES SOCIALES</param>
    ''' <returns>RESULTADO DE LA EJECUCION DE LA CONSULTA EN UN DATATABLE</returns>
    ''' <remarks></remarks>
    Public Function RecuperarClientesDeCadenaSicy(ByVal CadenaCadenas As String) As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim objOperacionesSAY As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = ""
        consulta = " select CTE.IdCliente, CTE.nombre from Clientes as cte" +
                " join cadenas AS CAD on cte.IdCadena =  CAD.IdCadena" +
                " where CTE.IdCadena in (" + CadenaCadenas + ") order by  CAD.nombre,CTE.nombre"
        Return objOperaciones.EjecutaConsulta(consulta)
    End Function

    ''' <summary>
    ''' CONSULTA LA LISTA DE LAS NAVES RELACIONADAS CON UN CONTRIBUYENTE EN ESPECIFICO
    ''' </summary>
    ''' <param name="IdContribuyente">ID DEL CONTRIBUYENTE DEL CUAL SE RECUPERARAN LAS NAVES</param>
    ''' <returns>RESULTADO DE LA EJECUCION DE LA CONSULTA EN UN DATATABLE</returns>
    ''' <remarks></remarks>
    Public Function RecuperarNavesDeControbuyente(ByVal IdContribuyente As String)
        Dim objOperaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim objOperacionesSAY As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = ""
        consulta = " select DISTINCT NA.IdNave, NA.Nave " +
                    " from CfgRazonSocialTransferenciaNave AS RCT " +
                    " JOIN NAVES AS NA ON NA.IdNave = RCT.IdNave where IdRazSoc in (" + IdContribuyente.ToString + ")"
        Return objOperaciones.EjecutaConsulta(consulta)
    End Function

    ''' <summary>
    ''' CONSULTA LAS CADENAS RELACIONADAS A UN CONTRIBUYENTE EN ESPECIFICO
    ''' </summary>
    ''' <param name="IdContribuyente">ID DEL CONTRIBUYENTE DEL CUAL SE CONSULTARAN LAS CADENAS </param>
    ''' <returns>RESULTADO DE LA EJECUCION DE LA CONSULTA EN UN DATATABLE</returns>
    ''' <remarks></remarks>
    Public Function CadenasSicy_Segun_Contribuyente(ByVal IdContribuyente As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String
        consulta = " Select IdCadena, nombre, Activo from  Cadenas where Activo = 'S' and IdEmpresa='" + IdContribuyente.ToString + "'  ORDER BY nombre"
        Return objPersistencia.EjecutaConsulta(consulta)
    End Function

    ''' <summary>
    ''' CONSULTA LOS TIPOS DE POLIZAS DEPENDIENDO DE EL TIPO DE COMPROBANTES QUE SE BUSCARAN 
    ''' </summary>
    ''' <param name="No_Tipo_Ingresos_Egresos"> VARIABLE DEL TIPO CADENA CUYO VALOR PUEDE SER "INGRESOS" PARA CONSULTAR LAS POLIZAS DE INGRESOS Y "EGRESOS"
    ''' PARA CONSULTAR LAS POLIZAS DE EGRESOS</param>
    ''' <returns>RESULTADO DE LA EJECUCION DE LA CONSULTA EN UN DATATABLE</returns>
    ''' <remarks></remarks>
    Public Function CargaTiposPoliza(ByVal No_Tipo_Ingresos_Egresos As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = ""

        If No_Tipo_Ingresos_Egresos = 1 Then
            ''INGRESOS
            consulta = " SELECT * FROM Contabilidad.PolizasTipos where poti_activo=1 AND poti_tipodetipodepoliza  = 'INGRESOS'"
        ElseIf No_Tipo_Ingresos_Egresos = 2 Then
            ''EGRESOS
            consulta = " SELECT * FROM Contabilidad.PolizasTipos where poti_activo=1 AND poti_tipodetipodepoliza  = 'EGRESOS' "
        End If

        Return objPersistencia.EjecutaConsulta(consulta)
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
                                               ByVal FolioExacto_O_FolioAproximado As Boolean)
        Dim objOperaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim objOperacionesSAY As New Persistencia.OperacionesProcedimientos

        Dim consulta As String

        consulta = " Select Tabla.Serie, case when Tabla.Folio is null then Tabla.No else Tabla.Folio end as 'Folio'," +
            " Tabla.Fecha_Documento, Tabla.RFC, Tabla.Razon_Social,Tabla.Total, Tabla.UUID, Tabla.XML, " +
            " Tabla.PDF, Tabla.No_Poliza, Tabla.Comprobante, Tabla.NAVE, Tabla.EmpresaId, Tabla.RFCEmpresa, " +
            " Tabla.IdProveedor, Tabla.ruta, Tabla.IDTABLA, tabla.RutaArchivos from  ( SELECT s.NUMDOCTO as 'No', c.cfdSerie AS 'Serie', c.cfdFolio AS 'Folio', " +
            " CONVERT(varchar(10), s.FECDOCTO, 103) AS 'Fecha_Documento', d.RFC AS 'RFC', d.RazonSocial AS 'Razon_Social', " +
            " ROUND(s.IMPDOCTO, 2) AS 'Total', '' AS 'UUID',ISNULL(c.cfdRutaXml,'') 'XML', c.cfdRutaVisor AS 'PDF', '' AS 'No_Poliza', " +
            " s.IdComprobante AS 'Comprobante', s.NAVE, s.IDRAZSOC AS 'EmpresaId', (SELECT rfc FROM Contribuyentes CONT WHERE CONT.IDRazSoc = " + IdContribuyentesicy + ") " +
            " AS 'RFCEmpresa', D.IdProveedor, (SELECT DISTINCT g.rutaXml + '\' FROM CfgRazonSocialTransferenciaNave g WHERE g.IdRazSoc=  " + IdContribuyentesicy + "   " +
            " and g.IdNave=(SELECT idnave FROM NavesAlmacen WHERE idAlmacen = S.NAVE)) AS 'ruta' , s.IDTABLA, '' as 'RutaArchivos' " +
            " FROM CxPSALDOS AS s" +
            " LEFT JOIN CFDS AS c ON s.IdComprobante = c.cfdId" +
            " JOIN Proveedores AS d ON s.CVEPROV = d.IdProveedor" +
            "  WHERE s.IdRazSoc = " + IdContribuyentesicy +
            " and FECDOCTO BETWEEN '" + Fec_Inicio + " 00:00' and '" + Fec_Fin + " 23:59'"
        If CadenaIdsProovedores <> "" Then
            consulta += " and d.IdProveedor in (" + CadenaIdsProovedores + ")"
        End If
        If IdNave > 0 Then
            consulta += " and s.NAVE = (SELECT nal.idAlmacen FROM NavesAlmacen nal WHERE nal.idnave = " + IdNave.ToString + ")"
        End If
        If Folio <> "" Then
            If FolioExacto_O_FolioAproximado Then
                consulta += " and s.NUMDOCTO = '" + Folio + "'"
            Else
                consulta += " and s.NUMDOCTO like '%" + Folio + "%'"
            End If
        End If
        consulta += ") as Tabla ORDER BY Fecha_Documento, Serie, Folio"
        Return objOperaciones.EjecutaConsulta(consulta)
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
        Dim objOperaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim objOperacionesSAY As New Persistencia.OperacionesProcedimientos

        Dim consulta As String

        If Documento_EnPoliza_O_SinContabilizar = True Then
            If Fecha_EnDocumento_O_EnPoliza = True Then
                consulta = " select c.cfdSerie as 'Serie', c.cfdFolio as 'Folio', CONVERT(varchar(10), s.FECDOCTO, 103) as 'Fecha_Documento', d.RFC as 'RFC', " +
                        "   d.RazonSocial as 'Razon_Social' ,round (s.IMPDOCTO,2) as 'Total' , '' as 'UUID', b.poli_foliomensual as 'No_Poliza'," +
                        "   c.cfdRutaXml as 'XML',c.cfdRutaVisor AS 'PDF', s.IdComprobante as 'Comprobante'" +
                    "       from CxPSALDOS as s "
                If objOperaciones.Servidor = objOperacionesSAY.Servidor Then
                    consulta += " join  [" + objOperacionesSAY.NombreDB + "].Contabilidad.PolizaMovimientos as a on a.pomo_compraid=s.IDTABLA " +
                    " join [" + objOperacionesSAY.NombreDB + "].Contabilidad.Polizas as b on a.pomo_polizaid=b.poli_polizaid and b.poli_tipoid=" + IdTipoPoliza.ToString + " "

                Else
                    consulta += " join  [" + objOperacionesSAY.Servidor + "].[" + objOperacionesSAY.NombreDB + "].Contabilidad.PolizaMovimientos as a on a.pomo_compraid=s.IDTABLA " +
                    " join [" + objOperacionesSAY.Servidor + "].[" + objOperacionesSAY.NombreDB + "].Contabilidad.Polizas as b on a.pomo_polizaid=b.poli_polizaid and b.poli_tipoid=" + IdTipoPoliza.ToString + " "
                End If
                consulta += " join CFDS as c on s.IdComprobante=c.cfdId" +
                " join Proveedores as d on s.CVEPROV=d.IdProveedor " +
                " where a.pomo_uuid<>'' " +
                " AND s.IDRAZSOC = " + IdContribuyentesicy
                If CadenaIdsProovedores <> "" Then
                    consulta += " AND CVEPROV IN  (" + CadenaIdsProovedores + ")"
                End If
                If IdNave > 0 Then
                    consulta += " and s.NAVE in (select na.idAlmacen from NavesAlmacen na where na.idnave=" + IdNave.ToString + ") "
                End If
                consulta += " and FECDOCTO BETWEEN '" + Fec_Inicio + "' and '" + Fec_Fin + " 23:59' "
                If Folio <> "" Then
                    If FolioExacto_O_FolioAproximado Then
                        consulta += " AND S.NUMDOCTO = '" + Folio + "' "
                    Else
                        consulta += " AND S.NUMDOCTO LIKE '%" + Folio + "%' "
                    End If
                End If
            Else
                consulta = "SELECT c.cfdSerie as 'Serie', c.cfdFolio as 'Folio', CONVERT(varchar(10), s.FECDOCTO, 103) as 'Fecha_Documento', d.RFC as 'RFC', " +
                        " d.RazonSocial as 'Razon_Social', round(s.IMPDOCTO,2) as 'Total', '' as 'UUID', c.cfdRutaXml as 'XML',c.cfdRutaVisor as 'PDF', " +
                        " a.poli_foliomensual as 'No_Poliza', s.IdComprobante as 'Comprobante'"
                If objOperaciones.Servidor = objOperacionesSAY.Servidor Then
                    consulta += " FROM [" + objOperacionesSAY.NombreDB + "].Contabilidad.Polizas AS A" +
                        "         join [" + objOperacionesSAY.NombreDB + "].Contabilidad.PolizaMovimientos as b on a.poli_polizaid=b.pomo_polizaid"
                Else
                    consulta += " FROM [" + objOperacionesSAY.Servidor + "].[" + objOperacionesSAY.NombreDB + "].Contabilidad.Polizas AS A" +
                        "         join [" + objOperacionesSAY.Servidor + "].[" + objOperacionesSAY.NombreDB + "].Contabilidad.PolizaMovimientos as b on a.poli_polizaid=b.pomo_polizaid"
                End If

                consulta += " join CxPSALDOS as s on b.pomo_compraid=s.IDTABLA and A.poli_tipoid= " + IdTipoPoliza.ToString +
                            " join CFDS as c on s.IdComprobante=c.cfdId" +
                            " join Proveedores as d on s.CVEPROV=d.IdProveedor" +
                            " where b.pomo_uuid<>''" +
                            " and s.IDRAZSOC = " + IdContribuyentesicy +
                            " and  A.poli_fecha BETWEEN '" + Fec_Inicio + "' and '" + Fec_Fin + " 23:59' "
                If CadenaIdsProovedores <> "" Then
                    consulta += " AND CVEPROV in (" + CadenaIdsProovedores + ")"
                End If
                If IdNave > 0 Then
                    consulta += " and s.NAVE in (select na.idAlmacen from NavesAlmacen na where na.idnave=" + IdNave.ToString + ") "
                End If
                If Folio <> "" Then
                    If FolioExacto_O_FolioAproximado Then
                        consulta += " AND S.NUMDOCTO = '%" + Folio + "%' "
                    Else
                        consulta += " AND S.NUMDOCTO LIKE '%" + Folio + "%' "
                    End If
                End If
            End If
        Else
            consulta = "	select c.cfdSerie AS 'Serie', c.cfdFolio as 'Folio', CONVERT(varchar(10), s.FECDOCTO, 103) as 'Fecha_Documento'  , d.RFC as 'RFC', " +
                    " d.RazonSocial as 'Razon_Social', round(s.IMPDOCTO,2) as 'Total', '' as 'UUID', c.cfdRutaXml as 'XML', " +
                    " c.cfdRutaVisor as 'PDF', '' as 'No_Poliza', s.IdComprobante as 'Comprobante'" +
                    " from CxPSALDOS as s " +
                    " join CFDS as c on s.IdComprobante=c.cfdId" +
                    " join Proveedores as d on s.CVEPROV=d.IdProveedor" +
                    " where s.IDRAZSOC = " + IdContribuyentesicy +
                    " AND FECDOCTO BETWEEN '" + Fec_Inicio + " 00:00' and '" + Fec_Fin + " 23:59'"
            If CadenaIdsProovedores <> "" Then
                consulta += " AND s.CVEPROV IN (" + CadenaIdsProovedores + ")"
            End If
            If IdNave > 0 Then
                consulta += " AND s.NAVE = (select na.idAlmacen from NavesAlmacen na where na.idnave=" + IdNave.ToString + ")"
            End If
            If Folio <> "" Then
                If FolioExacto_O_FolioAproximado Then
                    consulta += " AND s.NUMDOCTO = '" + Folio + "'"
                Else
                    consulta += " AND s.NUMDOCTO LIKE '%" + Folio + "%'"
                End If
            End If
            If objOperaciones.Servidor = objOperacionesSAY.Servidor Then
                consulta += " AND s.IDTABLA NOT IN (" +
                    "   SELECT A.pomo_compraid FROM [" + objOperacionesSAY.NombreDB + "].Contabilidad.PolizaMovimientos as a" +
                    "   join [" + objOperacionesSAY.NombreDB + "].Contabilidad.Polizas as b on a.pomo_polizaid=b.poli_polizaid and b.poli_tipoid=" + IdTipoPoliza.ToString + ")"
            Else
                consulta += " AND s.IDTABLA NOT IN (" +
                    "   SELECT A.pomo_compraid FROM [" + objOperacionesSAY.Servidor + "].[" + objOperacionesSAY.NombreDB + "].Contabilidad.PolizaMovimientos as a" +
                    "   join [" + objOperacionesSAY.Servidor + "].[" + objOperacionesSAY.NombreDB + "].Contabilidad.Polizas as b on a.pomo_polizaid=b.poli_polizaid and b.poli_tipoid=" + IdTipoPoliza.ToString + ")"
            End If
        End If

        consulta += " order by Fecha_Documento, Serie, Folio"

        Return objOperaciones.EjecutaConsulta(consulta)
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
        Dim objOperaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim objOperacionesSAY As New Persistencia.OperacionesProcedimientos

        Dim consulta As String

        If Documento_EnPoliza_O_SinContabilizar Then
            If Fecha_EnDocumento_O_EnPoliza Then
                consulta = "select c.cfdSerie as 'Serie', c.cfdFolio as 'Folio',CONVERT(varchar(10), s.FECDOCTO, 103) as 'Fecha_Documento', d.RFC as 'RFC'," +
                    " d.RazonSocial 'Razon_Social', round(s.IMPDOCTO,2) as 'Total', '' as 'UUID', c.cfdRutaXml as 'XML',c.cfdRutaVisor as 'PDF'," +
                    " b.poli_foliomensual as 'No_Poliza', s.IdComprobante as 'Comprobante'" +
                " 	from CxPSALDOS as s " +
                " 	JOIN CxPMOVIMIENTOS AS m on s.NUMDOCTO=m.NUMDOCTO and s.CVEPROV=m.CVEPROV"
                If objOperaciones.Servidor = objOperacionesSAY.Servidor Then
                    consulta += " 	join  [" + objOperacionesSAY.NombreDB + "].Contabilidad.PolizaMovimientos as a" +
                                "   on a.pomo_idtransferencia=m.idTrans and a.pomo_idtransferencia > 0" +
                                " 	join [" + objOperacionesSAY.NombreDB + "].Contabilidad.Polizas as b" +
                                "   on a.pomo_polizaid=b.poli_polizaid and b.poli_tipoid= " + IdTipoPoliza.ToString
                Else
                    consulta += " 	join  [" + objOperacionesSAY.Servidor + "].[" + objOperacionesSAY.NombreDB + "].Contabilidad.PolizaMovimientos as a " +
                                "   on a.pomo_idtransferencia=m.idTrans and a.pomo_idtransferencia > 0" +
                                "   join [" + objOperacionesSAY.Servidor + "].[" + objOperacionesSAY.NombreDB + "].Contabilidad.Polizas as b " +
                                "   on a.pomo_polizaid=b.poli_polizaid and b.poli_tipoid= " + IdTipoPoliza.ToString
                End If
                consulta += " 	join CFDS as c on s.IdComprobante=c.cfdId" +
                    " 	join Proveedores as d on s.CVEPROV=d.IdProveedor" +
                    " 	where  a.pomo_uuid<>''" +
                    " 	and s.IDRAZSOC = " + IdContribuyentesicy.ToString +
                    " 	and S.FECDOCTO BETWEEN '" + Fec_Inicio + "' and '" + Fec_Fin + " 23:59'"
                If CadenaIdsProovedores <> "" Then
                    consulta += " 	AND S.CVEPROV in (" + CadenaIdsProovedores + ")"
                End If
                If IdNave > 0 Then
                    consulta += " 	and s.NAVE in (select na.idAlmacen from NavesAlmacen na where na.idnave=" + IdNave.ToString + ") "
                End If
                If Folio <> "" Then
                    If FolioExacto_O_FolioAproximado Then
                        consulta += " 	AND S.NUMDOCTO LIKE '%" + Folio + "%'"
                    Else
                        consulta += " 	AND S.NUMDOCTO = '" + Folio + "'"
                    End If
                End If
            Else
                consulta = "	SELECT c.cfdSerie as 'Serie', c.cfdFolio as 'Folio',CONVERT(varchar(10), s.FECDOCTO, 103) as 'Fecha_Documento', " +
                        "       d.RFC as 'RFC', d.RazonSocial as 'Razon_Social', round(s.IMPDOCTO, 2) as 'Total', '' as 'UUID', " +
                        "       c.cfdRutaXml as 'XML',c.cfdRutaVisor as 'PDF',a.poli_foliomensual as 'No_Poliza', s.IdComprobante as 'Comprobante'"
                If objOperaciones.Servidor = objOperacionesSAY.Servidor Then
                    consulta += "	FROM [" + objOperacionesSAY.NombreDB + "].Contabilidad.Polizas AS A" +
                        "           join [" + objOperacionesSAY.NombreDB + "].Contabilidad.PolizaMovimientos as b on a.poli_polizaid=b.pomo_polizaid"
                Else
                    consulta += "	FROM [" + objOperacionesSAY.Servidor + "].[" + objOperacionesSAY.NombreDB + "].Contabilidad.Polizas AS A " +
                        "           join [" + objOperacionesSAY.Servidor + "].[" + objOperacionesSAY.NombreDB + "].Contabilidad.PolizaMovimientos as b" +
                        "           on a.poli_polizaid=b.pomo_polizaid"
                End If
                consulta += "	JOIN CxPMOVIMIENTOS AS m on b.pomo_idtransferencia=m.idTrans " +
                    "   join CxPSALDOS as s on m.CVEPROV=s.CVEPROV and s.NUMDOCTO=m.NUMDOCTO" +
                    "	join CFDS as c on s.IdComprobante=c.cfdId" +
                    "	join Proveedores as d on s.CVEPROV=d.IdProveedor" +
                    "	where b.pomo_uuid<>'' " +
                    "	and A.poli_tipoid=" + IdTipoPoliza.ToString +
                    "	AND A.poli_fecha BETWEEN '" + Fec_Inicio + " 00:00' and '" + Fec_Fin + " 23:59' " +
                    "	and s.IDRAZSOC = " + IdContribuyentesicy
                If CadenaIdsProovedores <> "" Then
                    consulta += "	AND s.CVEPROV IN (" + CadenaIdsProovedores + ")"
                End If
                If IdNave > 0 Then
                    consulta += "	and s.NAVE in (select na.idAlmacen from NavesAlmacen na where na.idnave=" + IdNave.ToString + ") "
                End If
                If Folio <> "" Then
                    If FolioExacto_O_FolioAproximado Then
                        consulta += "	AND S.NUMDOCTO = '" + Folio + "'"
                    Else
                        consulta += "	AND S.NUMDOCTO LIKE '%" + Folio + "%'"
                    End If
                End If
            End If
        Else
            consulta = "select c.cfdSerie as 'Serie', c.cfdFolio 'Folio', CONVERT(varchar(10), s.FECDOCTO, 103) as 'Fecha_Documento' ,d.RFC as 'RFC', d.RazonSocial as 'Razon_Social', round(s.IMPDOCTO,2) as 'Total', '' as 'UUID'," +
                    " c.cfdRutaXml as 'XML',c.cfdRutaVisor as 'PDF', '' as 'No_Poliza', s.IdComprobante as 'Comprobante'" +
                    " from CxPSALDOS as s " +
                    " join CFDS as c on s.IdComprobante=c.cfdId" +
                    " join Proveedores as d on s.CVEPROV=d.IdProveedor" +
                    " where s.IDRAZSOC = " + IdContribuyentesicy +
                    " AND FECDOCTO BETWEEN '" + Fec_Inicio + " 00:00' and '" + Fec_Fin + " 23:59'"
            If CadenaIdsProovedores <> "" Then
                consulta += " AND s.CVEPROV IN (" + CadenaIdsProovedores + ")"
            End If
            If IdNave > 0 Then
                consulta += " AND s.NAVE = (select na.idAlmacen from NavesAlmacen na where na.idnave=" + IdNave.ToString + ")"
            End If
            If Folio <> "" Then
                If FolioExacto_O_FolioAproximado Then
                    consulta += " AND s.NUMDOCTO = '" + Folio + "'"
                Else
                    consulta += " AND s.NUMDOCTO LIKE '%" + Folio + "%'"
                End If
            End If
            If objOperaciones.Servidor = objOperacionesSAY.Servidor Then
                consulta += " AND s.IDTABLA NOT IN (" +
                    "   SELECT A.pomo_compraid FROM [" + objOperacionesSAY.NombreDB + "].Contabilidad.PolizaMovimientos as a" +
                    "   join [" + objOperacionesSAY.NombreDB + "].Contabilidad.Polizas as b on a.pomo_polizaid=b.poli_polizaid and b.poli_tipoid=" + IdTipoPoliza.ToString + ")"
            Else
                consulta += " AND s.IDTABLA NOT IN (" +
                    "   SELECT A.pomo_compraid FROM [" + objOperacionesSAY.Servidor + "].[" + objOperacionesSAY.NombreDB + "].Contabilidad.PolizaMovimientos as a" +
                    "   join [" + objOperacionesSAY.Servidor + "].[" + objOperacionesSAY.NombreDB + "].Contabilidad.Polizas as b on a.pomo_polizaid=b.poli_polizaid and b.poli_tipoid=" + IdTipoPoliza.ToString + ")"
            End If
        End If

        consulta += " ORDER BY Fecha_Documento, Serie, FOLIO"
        Return objOperaciones.EjecutaConsulta(consulta)
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
        Dim objOperaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim objOperacionesSAY As New Persistencia.OperacionesProcedimientos
        Dim consulta As String

        consulta = " Select  b.serie AS 'Serie', b.Folio as 'Folio',CONVERT(varchar(10), a.FechaVenta, 103) as 'Fecha_Documento', " +
        " d.rfc as 'RFC', D.nombre aS 'Razon_Social', a.Total as 'Total', '' as 'UUID'," +
        " '' as 'No_Poliza', b.RutaXML as 'XML', b.RutaPDF as 'PDF', B.IdUnico AS 'Comprobante'" +
        " from ventas as a" +
        " join DoctosElectronicos as b on a.Año=b.Año and a.IdRemision=b.IdDocto" +
        " LEFT JOIN Cadenas AS c ON a.IdCadena = c.IdCadena AND B.IdCadena = C.IdCadena" +
        " LEFT JOIN Clientes AS d ON c.IdCadena = d.IdCadena AND a.IdCliente = d.IdCliente" +
        " where a.FechaVenta BETWEEN '" + Fec_Inicio + " 00:00' and '" + Fec_Fin + " 23:59:59'" +
        " and b.IdDocumento= " + IdEmpresaSay.ToString
        If CadenaClientesSicy <> "" Then
            consulta += " and d.IdCliente in (" + CadenaClientesSicy + ")"
        End If
        If Folio <> "" Then
            If FolioExacto_O_FolioAproximado Then
                consulta += " and (ltrim(rtrim(b.serie))+ltrim(rtrim(b.Folio))) = '" + Folio + "'"
            Else
                consulta += " and (ltrim(rtrim(b.serie))+ltrim(rtrim(b.Folio))) like '%" + Folio + "%'"
            End If
        End If
        consulta += " order by b.Fecha, b.serie, b.Folio"

        Return objOperaciones.EjecutaConsulta(consulta)
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
        Dim objOperaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim objOperacionesSAY As New Persistencia.OperacionesProcedimientos
        Dim consulta As String
        If Documento_EnPoliza_O_SinContabilizar Then
            If Fecha_EnDocumento_O_EnPoliza Then
                consulta = "select  b.serie AS 'Serie', b.Folio as 'Folio',CONVERT(varchar(10), a.FechaVenta, 103) as 'Fecha_Documento', " +
                " d.rfc as 'RFC', D.nombre aS 'Razon_Social', a.Total as 'Total', '' as 'UUID'," +
                " f.poli_foliomensual as 'No_Poliza', b.RutaXML as 'XML', b.RutaPDF as 'PDF',B.IdUnico AS 'Comprobante'" +
                " from ventas as a join DoctosElectronicos as b on a.Año=b.Año and a.IdRemision=b.IdDocto" +
                " LEFT JOIN Cadenas AS c ON a.IdCadena = c.IdCadena AND B.IdCadena = C.IdCadena" +
                " LEFT JOIN Clientes AS d ON c.IdCadena = d.IdCadena AND a.IdCliente = d.IdCliente"
                If objOperaciones.Servidor = objOperacionesSAY.Servidor Then
                    consulta += " join [" + objOperacionesSAY.NombreDB + "].Contabilidad.PolizaMovimientos as e on e.pomo_ventaid=b.IdUnico" +
                " join [" + objOperacionesSAY.NombreDB + "].Contabilidad.Polizas as f on f.poli_polizaid=e.pomo_polizaid"
                Else
                    consulta += " join [" + objOperacionesSAY.Servidor + "].[" + objOperacionesSAY.NombreDB + "].Contabilidad.PolizaMovimientos as e on e.pomo_ventaid=b.IdUnico" +
                " join [" + objOperacionesSAY.Servidor + "].[" + objOperacionesSAY.NombreDB + "].Contabilidad.Polizas as f on f.poli_polizaid=e.pomo_polizaid"
                End If
                consulta += " where a.FechaVenta BETWEEN '" + Fec_Inicio + " 00:00' and '" + Fec_Fin + " 23:59:59'" +
                " and e.pomo_tipomovimiento=0" +
                " and f.poli_tipoid = " + IdTipoPoliza.ToString +
                " and b.IdDocumento= " + IdEmpresaSay.ToString
                If CadenaClientesSicy <> "" Then
                    consulta += " and d.IdCliente in (" + CadenaClientesSicy + ")"
                End If
                If Folio <> "" Then
                    If FolioExacto_O_FolioAproximado Then
                        consulta += " and (ltrim(rtrim(b.serie))+ltrim(rtrim(b.Folio))) = '" + Folio + "'"
                    Else
                        consulta += " and (ltrim(rtrim(b.serie))+ltrim(rtrim(b.Folio))) Like '%" + Folio + "%'"
                    End If
                End If

                consulta += " order by Fecha_Documento, Serie,Folio"
            Else
                consulta = " select  b.serie AS 'Serie', b.Folio as 'Folio',CONVERT(varchar(10), a.FechaVenta, 103) as 'Fecha_Documento', " +
                    " d.rfc as 'RFC', D.nombre aS 'Razon_Social', a.Total as 'Total', '' as 'UUID'," +
                    " 		f.poli_foliomensual as 'No_Poliza', b.RutaXML as 'XML', b.RutaPDF as 'PDF', B.IdUnico AS 'Comprobante'" +
                    " from ventas as a join DoctosElectronicos as b on a.Año=b.Año and a.IdRemision=b.IdDocto" +
                    " LEFT JOIN Cadenas AS c ON a.IdCadena = c.IdCadena AND B.IdCadena = C.IdCadena" +
                    " LEFT JOIN Clientes AS d ON c.IdCadena = d.IdCadena AND a.IdCliente = d.IdCliente"
                If objOperaciones.Servidor = objOperacionesSAY.Servidor Then
                    consulta += " join [" + objOperacionesSAY.NombreDB + "].Contabilidad.PolizaMovimientos as e on e.pomo_ventaid=b.IdUnico" +
                    " join [" + objOperacionesSAY.NombreDB + "].Contabilidad.Polizas as f on f.poli_polizaid=e.pomo_polizaid"
                Else
                    consulta += " join [" + objOperacionesSAY.Servidor + "].[" + objOperacionesSAY.NombreDB + "].Contabilidad.PolizaMovimientos as e on e.pomo_ventaid=b.IdUnico" +
                    " join [" + objOperacionesSAY.Servidor + "].[" + objOperacionesSAY.NombreDB + "].Contabilidad.Polizas as f on f.poli_polizaid=e.pomo_polizaid"
                End If
                consulta += " where f.poli_fecha BETWEEN '" + Fec_Inicio + " 00:00' and '" + Fec_Fin + " 23:59:59'" +
                " and e.pomo_tipomovimiento=0" +
                " and f.poli_tipoid = " + IdTipoPoliza.ToString +
                " and b.IdDocumento= " + IdEmpresaSay.ToString
                If CadenaClientesSicy <> "" Then
                    consulta += " and d.IdCliente in (" + CadenaClientesSicy + ")"
                End If

                If Folio <> "" Then
                    If FolioExacto_O_FolioAproximado Then
                        consulta += " and (ltrim(rtrim(b.serie))+ltrim(rtrim(b.Folio))) = '" + Folio + "'"
                    Else
                        consulta += " and (ltrim(rtrim(b.serie))+ltrim(rtrim(b.Folio))) LIKE '%" + Folio + "%'"
                    End If
                End If


                consulta += " order by Fecha_Documento, Serie,Folio"
            End If
        Else
            consulta = " select  b.serie AS 'Serie', b.Folio as 'Folio',CONVERT(varchar(10), a.FechaVenta, 103) as 'Fecha_Documento', " +
                " d.rfc as 'RFC', D.nombre aS 'Razon_Social', a.Total as 'Total', '' as 'UUID'," +
                " '' as 'No_Poliza', b.RutaXML as 'XML', b.RutaPDF as 'PDF',B.IdUnico AS 'Comprobante'" +
                " from ventas as a join DoctosElectronicos as b on a.Año=b.Año and a.IdRemision=b.IdDocto" +
                " LEFT JOIN Cadenas AS c ON a.IdCadena = c.IdCadena AND B.IdCadena = C.IdCadena" +
                " LEFT JOIN Clientes AS d ON c.IdCadena = d.IdCadena AND a.IdCliente = d.IdCliente" +
                " where a.FechaVenta BETWEEN '" + Fec_Inicio + " 00:00' and '" + Fec_Fin + " 23:59:59'" +
                " and b.IdDocumento=  " + IdEmpresaSay.ToString
            If CadenaClientesSicy <> "" Then
                consulta += " and d.IdCliente in (" + CadenaClientesSicy + ")"
            End If
            If Folio <> "" Then
                If FolioExacto_O_FolioAproximado Then
                    consulta += " and (ltrim(rtrim(b.serie))+ltrim(rtrim(b.Folio))) = '" + Folio + "'"
                Else
                    consulta += " and (ltrim(rtrim(b.serie))+ltrim(rtrim(b.Folio))) LIKE '%" + Folio + "%'"
                End If
            End If
            If objOperaciones.Servidor = objOperacionesSAY.Servidor Then
                consulta += " AND b.IdUnico NOT IN (SELECT A.pomo_ventaid FROM [" + objOperacionesSAY.NombreDB + "].Contabilidad.PolizaMovimientos as a" +
                " join [" + objOperacionesSAY.NombreDB + "].Contabilidad.Polizas as b on a.pomo_polizaid=b.poli_polizaid and b.poli_tipoid = " + IdTipoPoliza.ToString + ")"
            Else
                consulta += " AND b.IdUnico NOT IN (SELECT A.pomo_ventaid FROM [" + objOperacionesSAY.Servidor + "].[" + objOperacionesSAY.NombreDB + "].Contabilidad.PolizaMovimientos as a" +
                " join [" + objOperacionesSAY.Servidor + "].[" + objOperacionesSAY.NombreDB + "].Contabilidad.Polizas as b on a.pomo_polizaid=b.poli_polizaid and b.poli_tipoid = " + IdTipoPoliza.ToString + ")"
            End If

            consulta += " order by Fecha_Documento, Serie,Folio"
        End If
        Return objOperaciones.EjecutaConsulta(consulta)
    End Function


    Public Function CargarComprobante_PolizaNotasCredito_Ingresos(ByVal IdEmpresaSay As String, ByVal Documento_EnPoliza_O_SinContabilizar As Boolean,
                                                      ByVal IdTipoPoliza As Integer, ByVal Fecha_EnDocumento_O_EnPoliza As Boolean,
                                                      ByVal Fec_Inicio As String, ByVal Fec_Fin As String, ByVal CadenaClientesSicy As String,
                                                      ByVal Folio As String, ByVal FolioExacto_O_FolioAproximado As Boolean)
        Dim objOperaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim objOperacionesSAY As New Persistencia.OperacionesProcedimientos
        Dim consulta As String

        If objOperaciones.Servidor = objOperacionesSAY.Servidor Then
            consulta = <Consulta>            
                        declare @IdDocumento as integer
                        set @IdDocumento = ( select essc_doctoventassicyid 
                                             from [<%= objOperacionesSAY.NombreDB %>].Framework.empresaSaySicyContpaq 
                                             where essc_sayid = <%= IdEmpresaSay %>)
                   </Consulta>.Value
        Else
            consulta = <Consulta>            
                        declare @IdDocumento as integer
                        set @IdDocumento = ( select essc_doctoventassicyid
                                             from [<%= objOperacionesSAY.Servidor %>].[<%= objOperacionesSAY.NombreDB %>].Framework.empresaSaySicyContpaq 
                                             where essc_sayid = <%= IdEmpresaSay %>)
                   </Consulta>.Value
        End If

        If Documento_EnPoliza_O_SinContabilizar Then

            If Fecha_EnDocumento_O_EnPoliza Then
                consulta += <Consulta>
                            SELECT de.serie as 'Serie', de.Folio as 'Folio', convert(varchar(10), nc.FechaRegistro,103) as 'Fecha_Documento', cte.rfc as 'RFC',
	                            cte.nombre as 'Razon_Social', nc.Total as 'Total', '' as 'UUID', f.poli_foliomensual as 'No_Poliza', de.RutaXML as 'XML', 
                                de.RutaPDF as 'PDF', de.IdUnico aS 'Comprobante', f.poli_tipoid
                            FROM cxcNotasCredito AS nc
                            JOIN cxcNotasCreditoDetalles AS ncd ON nc.IdNotaCredito = ncd.IdNotaCredito
                            JOIN DoctosElectronicos AS de ON de.IdDocto = ncd.IdNotaCredito AND de.Año = ncd.Año AND de.TipoDocto = 'NCR'
                            JOIN Clientes AS cte ON nc.IdCliente = cte.IdCliente  AND (LTRIM(RTRIM(cte.cTipoCliente)) = 'NACIONAL')
                            JOIN cxcconceptoscobranza AS cc ON cc.idconcepto = ncd.idconcepto AND cc.DOCUMENTO = 'CREDITO'
                            JOIN VENTAS AS VE ON VE.IdRemision = NCD.IdRemision AND VE.Año = NCD.Año
                            </Consulta>.Value

                If objOperaciones.Servidor = objOperacionesSAY.Servidor Then
                    consulta += <Consulta>            
                            JOIN [<%= objOperacionesSAY.NombreDB %>].Contabilidad.PolizaMovimientos as e  on e.pomo_notacreditoid = nc.IdNotaCredito 
                            join [<%= objOperacionesSAY.NombreDB %>].Contabilidad.Polizas as f on f.poli_polizaid=e.pomo_polizaid   
                            </Consulta>.Value

                Else
                    consulta += <Consulta>            
                            JOIN [<%= objOperacionesSAY.Servidor %>].[<%= objOperacionesSAY.NombreDB %>].Contabilidad.PolizaMovimientos as e  on e.pomo_notacreditoid = nc.IdNotaCredito 
                            join [<%= objOperacionesSAY.Servidor %>].[<%= objOperacionesSAY.NombreDB %>].Contabilidad.Polizas as f on f.poli_polizaid=e.pomo_polizaid   
                            </Consulta>.Value

                End If
                consulta += <Consulta>
                            WHERE nc.FechaRegistro BETWEEN CONVERT(datetime, '<%= Fec_Inicio %> 00:00', 103) AND CONVERT(datetime, '<%= Fec_Fin %> 23:00', 103)
                            AND de.Estatus NOT IN ('CANCELADO')
                            AND nc.IdDocumento =  @IdDocumento 
                            </Consulta>.Value

                If CadenaClientesSicy <> "" Then
                    consulta += <Consulta>
                            and CTE.IdCliente in(<%= CadenaClientesSicy %>)
                            </Consulta>.Value

                End If
                If Folio <> "" Then
                    If FolioExacto_O_FolioAproximado Then
                        consulta += <Consulta>	            
                            and (ltrim(rtrim(DE.serie))+ltrim(rtrim(DE.Folio))) = '<%= Folio %>'
                            </Consulta>.Value

                    Else
                        consulta += <Consulta>	                            
                            and (ltrim(rtrim(DE.serie))+ltrim(rtrim(DE.Folio))) LIKE '%<%= Folio %>%'
                            </Consulta>.Value
                    End If
                End If
                consulta += <Consulta>                
                            GROUP BY de.serie,de.Folio,nc.FechaRegistro, cte.rfc,cte.nombre,nc.Total,f.poli_foliomensual, de.RutaXML,de.RutaPDF,de.IdUnico, f.poli_tipoid
                            order by nc.FechaRegistro,de.serie,de.Folio 
                           </Consulta>.Value
            Else
                consulta += <consulta>
                                SELECT de.serie as 'Serie', de.Folio as 'Folio', convert(varchar(10),nc.FechaRegistro,103) as 'Fecha_Documento', cte.rfc as 'RFC',
	                                cte.nombre as 'Razon_Social', nc.Total as 'Total', '' as 'UUID', f.poli_foliomensual as 'No_Poliza', de.RutaXML as 'XML', 
                                    de.RutaPDF as 'PDF', de.IdUnico aS 'Comprobante'
                                FROM cxcNotasCredito AS nc
                                JOIN cxcNotasCreditoDetalles AS ncd ON nc.IdNotaCredito = ncd.IdNotaCredito
                                JOIN DoctosElectronicos AS de ON de.IdDocto = ncd.IdNotaCredito AND de.Año = ncd.Año AND de.TipoDocto = 'NCR'
                                JOIN Clientes AS cte ON nc.IdCliente = cte.IdCliente  AND (LTRIM(RTRIM(cte.cTipoCliente)) = 'NACIONAL')JOIN cxcconceptoscobranza AS cc ON cc.idconcepto = ncd.idconcepto AND cc.DOCUMENTO = 'CREDITO'
                                JOIN VENTAS AS VE ON VE.IdRemision = NCD.IdRemision AND VE.Año = NCD.Año
                                       </consulta>.Value
                If objOperaciones.Servidor = objOperacionesSAY.Servidor Then
                    consulta += <Consulta>            
                                JOIN [<%= objOperacionesSAY.NombreDB %>].Contabilidad.PolizaMovimientos as e on e.pomo_notacreditoid = nc.IdNotaCredito
                                join [<%= objOperacionesSAY.NombreDB %>].Contabilidad.Polizas as f on f.poli_polizaid=e.pomo_polizaid
                            </Consulta>.Value

                Else
                    consulta += <Consulta>            
                                JOIN [<%= objOperacionesSAY.Servidor %>].[<%= objOperacionesSAY.NombreDB %>].Contabilidad.PolizaMovimientos as e on e.pomo_notacreditoid = nc.IdNotaCredito
                                join [<%= objOperacionesSAY.Servidor %>].[<%= objOperacionesSAY.NombreDB %>].Contabilidad.Polizas as f on f.poli_polizaid=e.pomo_polizaid
                            </Consulta>.Value
                End If
                consulta += <Consulta>

                                WHERE f.poli_fecha BETWEEN CONVERT(datetime, '<%= Fec_Inicio %> 00:00', 103) AND CONVERT(datetime, '<%= Fec_Fin %> 23:00', 103)
                                      AND de.Estatus NOT IN ('CANCELADO')
                                      AND nc.IdDocumento =  @IdDocumento
                </Consulta>.Value
                If CadenaClientesSicy <> "" Then
                    consulta += <Consulta>
                            and CTE.IdCliente in(<%= CadenaClientesSicy %>)
                            </Consulta>.Value
                End If
                If Folio <> "" Then
                    If FolioExacto_O_FolioAproximado Then
                        consulta += <Consulta>	            
                            and (ltrim(rtrim(DE.serie))+ltrim(rtrim(DE.Folio))) = '<%= Folio %>'
                            </Consulta>.Value

                    Else
                        consulta += <Consulta>	                            
                            and (ltrim(rtrim(DE.serie))+ltrim(rtrim(DE.Folio))) LIKE '%<%= Folio %>%'
                            </Consulta>.Value
                    End If
                End If
                consulta += <Consulta>                                                
                                GROUP BY de.serie,de.Folio,nc.FechaRegistro, cte.rfc,cte.nombre,nc.Total,f.poli_foliomensual, de.RutaXML,de.RutaPDF,de.IdUnico
                                ORDER by nc.FechaRegistro,de.serie,de.Folio 
                            </Consulta>.Value
            End If
        Else
            consulta += <Consulta>
                           SELECT de.serie as 'Serie', de.Folio as 'Folio', convert(varchar(10),nc.FechaRegistro,103) as 'Fecha_Documento', cte.rfc as 'RFC',
	                            cte.nombre as 'Razon_Social', nc.Total as 'Total', '' as 'UUID', '' as 'No_Poliza', de.RutaXML as 'XML', de.RutaPDF as 'PDF',
	                            de.IdUnico aS 'Comprobante'
                            FROM cxcNotasCredito AS nc
                            JOIN cxcNotasCreditoDetalles AS ncd ON nc.IdNotaCredito = ncd.IdNotaCredito
                            JOIN DoctosElectronicos AS de ON de.IdDocto = ncd.IdNotaCredito AND de.Año = ncd.Año AND de.TipoDocto = 'NCR'
                            JOIN Clientes AS cte ON nc.IdCliente = cte.IdCliente  AND (LTRIM(RTRIM(cte.cTipoCliente)) = 'NACIONAL')JOIN cxcconceptoscobranza AS cc ON cc.idconcepto = ncd.idconcepto AND cc.DOCUMENTO = 'CREDITO'
                            JOIN VENTAS AS VE ON VE.IdRemision = NCD.IdRemision AND VE.Año = NCD.Año
                            WHERE nc.FechaRegistro BETWEEN CONVERT(datetime, '<%= Fec_Inicio %>', 103) AND CONVERT(datetime, '<%= Fec_Fin %> 23:00', 103)
                                  
                                  AND de.Estatus NOT IN ('CANCELADO')
                                  AND nc.IdDocumento =  @IdDocumento
                        </Consulta>.Value

            If objOperaciones.Servidor = objOperacionesSAY.Servidor Then
                consulta += <Consulta>AND nc.idNotaCredito NOT IN (SELECT ISNULL(pomo_notacreditoid, 0) 
                                                                FROM [<%= objOperacionesSAY.NombreDB %>].[Contabilidad].[PolizaMovimientos])</Consulta>.Value
            Else
                consulta += <Consulta>AND nc.idNotaCredito NOT IN (SELECT ISNULL(pomo_notacreditoid, 0) 
                                                                FROM [<%= objOperacionesSAY.Servidor %>].[<%= objOperacionesSAY.NombreDB %>].[Contabilidad].[PolizaMovimientos])</Consulta>.Value
            End If


            If CadenaClientesSicy <> "" Then
                consulta += <Consulta>
                            and CTE.IdCliente in(<%= CadenaClientesSicy %>)
                            </Consulta>.Value
            End If
            If Folio <> "" Then
                If FolioExacto_O_FolioAproximado Then
                    consulta += <Consulta>	            
                            and (ltrim(rtrim(DE.serie))+ltrim(rtrim(DE.Folio))) = '<%= Folio %>'
                            </Consulta>.Value

                Else
                    consulta += <Consulta>	                            
                            and (ltrim(rtrim(DE.serie))+ltrim(rtrim(DE.Folio))) LIKE '%<%= Folio %>%'
                            </Consulta>.Value
                End If
            End If
            consulta += <Consulta>                                                
                            GROUP BY de.serie,de.Folio,nc.FechaRegistro, cte.rfc,cte.nombre,nc.Total, de.RutaXML,de.RutaPDF,de.IdUnico
                            order by nc.FechaRegistro, DE.Serie,DE.Folio
                       </Consulta>.Value
        End If
        Return objOperaciones.EjecutaConsulta(consulta)
    End Function


    Public Function CargarComprobante_PolizaNotasCargo_Ingresos(ByVal IdEmpresaSay As String, ByVal Documento_EnPoliza_O_SinContabilizar As Boolean,
                                                      ByVal IdTipoPoliza As Integer, ByVal Fecha_EnDocumento_O_EnPoliza As Boolean,
                                                      ByVal Fec_Inicio As String, ByVal Fec_Fin As String, ByVal CadenaClientesSicy As String,
                                                      ByVal Folio As String, ByVal FolioExacto_O_FolioAproximado As Boolean)
        Dim objOperaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim objOperacionesSAY As New Persistencia.OperacionesProcedimientos
        Dim consulta As String

        If objOperaciones.Servidor = objOperacionesSAY.Servidor Then
            consulta = <Consulta>
                            declare @IdDocumento as integer
                            SET @IdDocumento = (    SELECT essc_doctoventassicyid 
                                                    FROM [<%= objOperacionesSAY.NombreDB %>].Framework.empresaSaySicyContpaq 
                                                    WHERE essc_sayid = <%= IdEmpresaSay %> )
                       </Consulta>.Value
        Else
            consulta = <Consulta>            
                            declare @IdDocumento as integer
                            SET @IdDocumento = (    SELECT essc_doctoventassicyid 
                                                    FROM [<%= objOperacionesSAY.Servidor %>].[<%= objOperacionesSAY.NombreDB %>].Framework.empresaSaySicyContpaq }
                                                    WHERE essc_sayid = <%= IdEmpresaSay %>)
                        </Consulta>.Value
        End If

        If Documento_EnPoliza_O_SinContabilizar Then

            If Fecha_EnDocumento_O_EnPoliza Then
                consulta += <Consulta>
                            SELECT de.serie as 'Serie', de.Folio as 'Folio', convert(varchar(10), nc.FechaRegistro,103) as 'Fecha_Documento', cte.rfc as 'RFC',
	                            cte.nombre as 'Razon_Social', nc.Total as 'Total', '' as 'UUID', f.poli_foliomensual as 'No_Poliza', de.RutaXML as 'XML', 
                                de.RutaPDF as 'PDF', de.IdUnico aS 'Comprobante', f.poli_tipoid
                            FROM cxcNotasCredito AS nc
                            JOIN cxcNotasCreditoDetalles AS ncd ON nc.IdNotaCredito = ncd.IdNotaCredito
                            JOIN DoctosElectronicos AS de ON de.IdDocto = ncd.IdNotaCredito AND de.Año = ncd.Año AND de.TipoDocto = 'NCR'
                            JOIN Clientes AS cte ON nc.IdCliente = cte.IdCliente  AND (LTRIM(RTRIM(cte.cTipoCliente)) = 'NACIONAL')
                            JOIN cxcconceptoscobranza AS cc ON cc.idconcepto = ncd.idconcepto AND cc.DOCUMENTO = 'CREDITO'
                            JOIN VENTAS AS VE ON VE.IdRemision = NCD.IdRemision AND VE.Año = NCD.Año
                            </Consulta>.Value

                If objOperaciones.Servidor = objOperacionesSAY.Servidor Then
                    consulta += <Consulta>            
                            JOIN [<%= objOperacionesSAY.NombreDB %>].Contabilidad.PolizaMovimientos as e  on e.pomo_notacreditoid = nc.IdNotaCredito 
                            join [<%= objOperacionesSAY.NombreDB %>].Contabilidad.Polizas as f on f.poli_polizaid=e.pomo_polizaid   
                            </Consulta>.Value
                Else
                    consulta += <Consulta>            
                            JOIN [<%= objOperacionesSAY.Servidor %>].[<%= objOperacionesSAY.NombreDB %>].Contabilidad.PolizaMovimientos as e  on e.pomo_notacreditoid = nc.IdNotaCredito 
                            join [<%= objOperacionesSAY.Servidor %>].[<%= objOperacionesSAY.NombreDB %>].Contabilidad.Polizas as f on f.poli_polizaid=e.pomo_polizaid   
                            </Consulta>.Value
                End If
                consulta += <Consulta>
                            WHERE nc.FechaRegistro BETWEEN CONVERT(datetime, '<%= Fec_Inicio %> 00:00', 103) AND CONVERT(datetime, '<%= Fec_Fin %> 23:00', 103)
                            AND de.Estatus NOT IN ('CANCELADO')
                            AND nc.IdDocumento =  @IdDocumento 
                            </Consulta>.Value

                If CadenaClientesSicy <> "" Then
                    consulta += <Consulta>
                            and CTE.IdCliente in(<%= CadenaClientesSicy %>)
                            </Consulta>.Value

                End If
                If Folio <> "" Then
                    If FolioExacto_O_FolioAproximado Then
                        consulta += <Consulta>	            
                            and (ltrim(rtrim(DE.serie))+ltrim(rtrim(DE.Folio))) = '<%= Folio %>'
                            </Consulta>.Value

                    Else
                        consulta += <Consulta>	                            
                            and (ltrim(rtrim(DE.serie))+ltrim(rtrim(DE.Folio))) LIKE '%<%= Folio %>%'
                            </Consulta>.Value
                    End If
                End If
                consulta += <Consulta>                
                            GROUP BY de.serie,de.Folio,nc.FechaRegistro, cte.rfc,cte.nombre,nc.Total,f.poli_foliomensual, de.RutaXML,de.RutaPDF,de.IdUnico, f.poli_tipoid
                            order by nc.FechaRegistro,de.serie,de.Folio 
                           </Consulta>.Value
            Else
                consulta += <consulta>
                                SELECT de.serie as 'Serie', de.Folio as 'Folio', convert(varchar(10),nc.FechaRegistro,103) as 'Fecha_Documento', cte.rfc as 'RFC',
	                                cte.nombre as 'Razon_Social', nc.Total as 'Total', '' as 'UUID', f.poli_foliomensual as 'No_Poliza', de.RutaXML as 'XML', 
                                    de.RutaPDF as 'PDF', de.IdUnico aS 'Comprobante'
                                FROM cxcNotasCredito AS nc
                                JOIN cxcNotasCreditoDetalles AS ncd ON nc.IdNotaCredito = ncd.IdNotaCredito
                                JOIN DoctosElectronicos AS de ON de.IdDocto = ncd.IdNotaCredito AND de.Año = ncd.Año AND de.TipoDocto = 'NCR'
                                JOIN Clientes AS cte ON nc.IdCliente = cte.IdCliente  AND (LTRIM(RTRIM(cte.cTipoCliente)) = 'NACIONAL')JOIN cxcconceptoscobranza AS cc ON cc.idconcepto = ncd.idconcepto AND cc.DOCUMENTO = 'CREDITO'
                                JOIN VENTAS AS VE ON VE.IdRemision = NCD.IdRemision AND VE.Año = NCD.Año
                                       </consulta>.Value
                If objOperaciones.Servidor = objOperacionesSAY.Servidor Then
                    consulta += <Consulta>            
                                JOIN [<%= objOperacionesSAY.NombreDB %>].Contabilidad.PolizaMovimientos as e on e.pomo_notacreditoid = nc.IdNotaCredito
                                join [<%= objOperacionesSAY.NombreDB %>].Contabilidad.Polizas as f on f.poli_polizaid=e.pomo_polizaid
                            </Consulta>.Value

                Else
                    consulta += <Consulta>            
                                JOIN [<%= objOperacionesSAY.Servidor %>].[<%= objOperacionesSAY.NombreDB %>].Contabilidad.PolizaMovimientos as e on e.pomo_notacreditoid = nc.IdNotaCredito
                                join [<%= objOperacionesSAY.Servidor %>].[<%= objOperacionesSAY.NombreDB %>].Contabilidad.Polizas as f on f.poli_polizaid=e.pomo_polizaid
                            </Consulta>.Value
                End If
                consulta += <Consulta>

                                WHERE f.poli_fecha BETWEEN CONVERT(datetime, '<%= Fec_Inicio %> 00:00', 103) AND CONVERT(datetime, '<%= Fec_Fin %> 23:00', 103)
                                      AND de.Estatus NOT IN ('CANCELADO')
                                      AND nc.IdDocumento =  @IdDocumento
                </Consulta>.Value
                If CadenaClientesSicy <> "" Then
                    consulta += <Consulta>
                            and CTE.IdCliente in(<%= CadenaClientesSicy %>)
                            </Consulta>.Value
                End If
                If Folio <> "" Then
                    If FolioExacto_O_FolioAproximado Then
                        consulta += <Consulta>	            
                            and (ltrim(rtrim(DE.serie))+ltrim(rtrim(DE.Folio))) = '<%= Folio %>'
                            </Consulta>.Value

                    Else
                        consulta += <Consulta>	                            
                            and (ltrim(rtrim(DE.serie))+ltrim(rtrim(DE.Folio))) LIKE '%<%= Folio %>%'
                            </Consulta>.Value
                    End If
                End If
                consulta += <Consulta>                                                
                                GROUP BY de.serie,de.Folio,nc.FechaRegistro, cte.rfc,cte.nombre,nc.Total,f.poli_foliomensual, de.RutaXML,de.RutaPDF,de.IdUnico
                                ORDER by nc.FechaRegistro,de.serie,de.Folio 
                            </Consulta>.Value
            End If
        Else
            consulta += <Consulta>
                           SELECT de.serie as 'Serie', de.Folio as 'Folio', convert(varchar(10),nc.FechaRegistro,103) as 'Fecha_Documento', cte.rfc as 'RFC',
	                            cte.nombre as 'Razon_Social', nc.Total as 'Total', '' as 'UUID', '' as 'No_Poliza', de.RutaXML as 'XML', de.RutaPDF as 'PDF',
	                            de.IdUnico aS 'Comprobante'
                            FROM cxcNotasCredito AS nc
                            JOIN cxcNotasCreditoDetalles AS ncd ON nc.IdNotaCredito = ncd.IdNotaCredito
                            JOIN DoctosElectronicos AS de ON de.IdDocto = ncd.IdNotaCredito AND de.Año = ncd.Año AND de.TipoDocto = 'NCR'
                            JOIN Clientes AS cte ON nc.IdCliente = cte.IdCliente  AND (LTRIM(RTRIM(cte.cTipoCliente)) = 'NACIONAL')JOIN cxcconceptoscobranza AS cc ON cc.idconcepto = ncd.idconcepto AND cc.DOCUMENTO = 'CREDITO'
                            JOIN VENTAS AS VE ON VE.IdRemision = NCD.IdRemision AND VE.Año = NCD.Año
                            WHERE nc.FechaRegistro BETWEEN CONVERT(datetime, '<%= Fec_Inicio %>', 103) AND CONVERT(datetime, '<%= Fec_Fin %> 23:00', 103)
                                  
                                  AND de.Estatus NOT IN ('CANCELADO')
                                  AND nc.IdDocumento =  @IdDocumento
                        </Consulta>.Value

            If objOperaciones.Servidor = objOperacionesSAY.Servidor Then
                consulta += <Consulta>AND nc.idNotaCredito NOT IN (SELECT ISNULL(pomo_notacreditoid, 0) 
                                                                FROM [<%= objOperacionesSAY.NombreDB %>].[Contabilidad].[PolizaMovimientos])</Consulta>.Value
            Else
                consulta += <Consulta>AND nc.idNotaCredito NOT IN (SELECT ISNULL(pomo_notacreditoid, 0) 
                                                                FROM [<%= objOperacionesSAY.Servidor %>].[<%= objOperacionesSAY.NombreDB %>].[Contabilidad].[PolizaMovimientos])</Consulta>.Value
            End If


            If CadenaClientesSicy <> "" Then
                consulta += <Consulta>
                            and CTE.IdCliente in(<%= CadenaClientesSicy %>)
                            </Consulta>.Value
            End If
            If Folio <> "" Then
                If FolioExacto_O_FolioAproximado Then
                    consulta += <Consulta>	            
                            and (ltrim(rtrim(DE.serie))+ltrim(rtrim(DE.Folio))) = '<%= Folio %>'
                            </Consulta>.Value

                Else
                    consulta += <Consulta>	                            
                            and (ltrim(rtrim(DE.serie))+ltrim(rtrim(DE.Folio))) LIKE '%<%= Folio %>%'
                            </Consulta>.Value
                End If
            End If
            consulta += <Consulta>                                                
                            GROUP BY de.serie,de.Folio,nc.FechaRegistro, cte.rfc,cte.nombre,nc.Total, de.RutaXML,de.RutaPDF,de.IdUnico
                            order by nc.FechaRegistro, DE.Serie,DE.Folio
                       </Consulta>.Value
        End If
        Return objOperaciones.EjecutaConsulta(consulta)
    End Function


    ''' <summary>
    ''' CONSULTA EL ID DEL PROVEEDOR Y SU RAZON SOCIAL DE LA BASE DE DATOS DEL SISCY CUANDO SU ESTATUS SEA ACTIVO
    ''' </summary>
    ''' <returns>RESULTADO DE LA EJECUCION DE LA CONSULTA</returns>
    ''' <remarks></remarks>
    Public Function ConsultarProveedoresSicy()
        ''CAMBIAR CONSULTA CUANDO EL MODULO DE PROVEEDORES ESTE EN SAY
        Dim objPersistencia As New OperacionesProcedimientosSICY
        Dim consulta As String = " select IdProveedor, RazonSocial  from Proveedores where Estatus = 'Activo' order by RazonSocial"
        Return objPersistencia.EjecutaConsulta(consulta)
    End Function


    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="tipo_busqueda"></param>
    ''' <param name="id_parametros"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ListadoParametroUbicacion(tipo_busqueda As Integer, id_parametros As String) As DataTable
        Dim operaciones_sicy As New Persistencia.OperacionesProcedimientosSICY
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = String.Empty

        If tipo_busqueda = 1 Then
            consulta += " select CTE.IdCliente,CAST(0 AS BIT) AS ' ', cad.nombre as Cliente,  CTE.nombre as Razon_Social " +
                        " from Clientes as cte join cadenas AS CAD on cte.IdCadena =  CAD.IdCadena where cte.Activo = 1 " +
                        " order by  CAD.nombre,CTE.nombre"
        ElseIf tipo_busqueda = 2 Then
            consulta += " select IdProveedor,CAST(0 AS BIT) AS ' ', RazonSocial as Razon_Social  from Proveedores where Estatus = 'Activo' order by Razon_Social"
        End If

        Return operaciones_sicy.EjecutaConsulta(consulta)
    End Function

End Class
