Imports System.Data.SqlClient

Public Class AltaPolizaDA

#Region "CARGAR CATALOGOS"
    Public Function datosServidorEmpresa(ByVal empresaID As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = ""
        consulta += " SELECT essc_empresaid,essc_sayid, essc_empresacontpaq,essc_servidor,essc_doctoventassicyid,essc_contribuyentesicyid" +
                    " FROM Framework.empresaSaySicyContpaq"
        consulta += " where essc_sayid=" + empresaID.ToString
        Return objPersistencia.EjecutaConsulta(consulta)
    End Function

    Public Function buscaEmpresaSAY(ByVal empresaID As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = ""
        consulta += " select * from Framework.Empresas where empr_empresaid=" + empresaID.ToString
        Return objPersistencia.EjecutaConsulta(consulta)
    End Function

    Public Function CargaEmpresaCONTPAQ(ByVal usuarioID As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = ""
        consulta += " SELECT cast(b.essc_sayid as varchar(3))+' '+cast(B.essc_razonsocial as varchar(250)) as 'RazonSocial', B.essc_sayid"
        consulta += " FROM Framework.permisosUsuarioEmpresa as C"
        consulta += " JOIN Framework.empresaSaySicyContpaq as B on B.essc_empresaid=C.prue_empresaid"
        consulta += " where C.prue_usuarioid = " + usuarioID.ToString + " ORDER BY essc_sayid ASC"
        Return objPersistencia.EjecutaConsulta(consulta)
    End Function

    Public Function CargaTiposPoliza() As DataTable
        Dim objpersistencia As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = ""
        consulta += " SELECT * FROM Contabilidad.PolizasTipos "
        consulta += " where poti_activo=1 ORDER BY poti_nombre ASC"
        Return objpersistencia.EjecutaConsulta(consulta)
    End Function

    Public Function cuentasGenerales(ByVal empresaID As Integer, ByVal clave As String, ByVal cuentaBancaria As String, ByVal tipoPoliza As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        'Dim consulta As String = ""
        'If clave = "BANCOS" Then
        '    consulta += " SELECT"
        '    consulta += " cgen_cuenta,"
        '    consulta += " A.cgen_nombre + ' (' + C.banc_nombre + ' ' + B.cuba_numero + ')' AS CuentaBancaria,"
        '    consulta += " ISNULL(B.cuba_cuentacontpaqid, '') AS 'CuentaContpaqid',"
        '    consulta += " ISNULL(B.cuba_bancocontpaqid, '') AS 'bancoContpaqid',"
        '    consulta += " cc.cuco_cuentacontableid as  'cuentaSAYID',"
        '    consulta += " ISNULL(a.cgen_tipopolizacontpaqid, 0) as 'tipoPolizaCompaqID'"
        '    consulta += " FROM Contabilidad.CuentasContablesGenerales AS A"
        '    consulta += " JOIN Bancos.CuentasBancarias AS B ON B.cuba_cuentaid = A.cgen_cuentabancariaid"
        '    consulta += " JOIN Framework.Bancos AS C ON C.banc_bancoid = B.cuba_bancoid"
        '    consulta += " JOIN Contabilidad.CuentasContables as cc on cc.cuco_cuentacontableid=A.cgen_cuentasayid"
        '    consulta += " where cgen_empresaid = " + empresaID.ToString
        '    consulta += " AND cgen_clave='" + clave.ToString + "'"
        '    consulta += " and B.cuba_numero='" + cuentaBancaria.ToString + "'"
        'Else
        '    consulta += " SELECT ccg.cgen_cuenta,ccg.cgen_nombre,cc.cuco_cuentacontableid as 'cuentaSAYID' "
        '    consulta += " FROM Contabilidad.CuentasContablesGenerales  ccg"
        '    consulta += " JOIN Contabilidad.CuentasContables as cc on cc.cuco_cuentacontableid=ccg.cgen_cuentasayid"
        '    consulta += " where cgen_empresaid =" + empresaID.ToString
        '    consulta += " AND cgen_clave='" + clave.ToString + "'"
        'End If
        'Return operaciones.EjecutaConsulta(consulta)

        'ByVal empresaID As Integer, ByVal clave As String, ByVal cuentaBancaria As String, ByVal tipoPoliza As Integer

        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@empresaID"
        parametro.Value = empresaID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@clave"
        parametro.Value = clave
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@cuentaBancaria"
        parametro.Value = cuentaBancaria
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@tipoPoliza"
        parametro.Value = tipoPoliza
        listaParametros.Add(parametro)


        Return operaciones.EjecutarConsultaSP("Contabilidad.SP_AltaPoliza_ConsultarCuentasGenerales", listaParametros)
    End Function

    Public Function cuentasGeneralesBancos(ByVal empresaID As Integer, ByVal clave As String, ByVal tipoPoliza As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = ""

        consulta += " SELECT cgen_cuenta,"
        consulta += " A.cgen_nombre + ' (' + C.banc_nombre + ' ' + B.cuba_numero + ')' AS CuentaBancaria,"
        consulta += " ISNULL(B.cuba_cuentacontpaqid, '') AS 'CuentaContpaqid',"
        consulta += " ISNULL(B.cuba_bancocontpaqid, '') AS 'bancoContpaqid',"
        consulta += " cc.cuco_cuentacontableid as  'cuentaSAYID',"
        consulta += " ISNULL(a.cgen_tipopolizacontpaqid, 0) as 'tipoPolizaCompaqID', REPLACE(B.cuba_numero,'-','') as cuba_numero"
        consulta += " FROM Contabilidad.CuentasContablesGenerales AS A"
        consulta += " JOIN Bancos.CuentasBancarias AS B ON B.cuba_cuentaid = A.cgen_cuentabancariaid"
        consulta += " JOIN Framework.Bancos AS C ON C.banc_bancoid = B.cuba_bancoid"
        consulta += " JOIN Contabilidad.CuentasContables as cc on cc.cuco_cuentacontableid=A.cgen_cuentasayid"
        consulta += " join Contabilidad.PolizasTipos t on  A.cgen_tipopolizaid=t.poti_polizatipoid"
        consulta += " where cgen_empresaid = " + empresaID.ToString
        consulta += " AND cgen_clave='" + clave.ToString + "'"
        consulta += " and poti_nombre='" + tipoPoliza.ToString + "'"

        Return operaciones.EjecutaConsulta(consulta)
    End Function

#End Region

#Region "CARGAR GRID COMPRAS"
    Public Function CargaGridPolizaCompras(ByVal estatus As String, ByVal RazSoc As String, ByVal FechaDe As String, ByVal FechaA As String, ByVal empresaID As Integer) As DataTable

        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim operacionesSAY As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = ""

        consulta = "  IF OBJECT_ID ('tempdb.dbo.#tmpCompras') is not null BEGIN" +
                    " DROP TABLE #tmpCompras;" +
                    " END" +
                    " " +
                    " DECLARE @mes int, @año int " +
                    " set @mes=month('" + FechaDe.ToString + "' )" +
                    " set @año=year('" + FechaDe.ToString + "' )" +
                    "  create table #tmpCompras( PolizaSAYID varchar(5), PolizaContpaqID varchar(5), Movimiento varchar(5), Cuenta varchar(5), Proveedor varchar(200),     " +
                    " 							Cargos money,Abonos money, Fecha smalldatetime, Referencia varchar(50), Nave int, proveedorSicyID int,  IVA money,  " +
                    " 							Subtotal money, RutaXML varchar(500), Rfc varchar(50), Uuid varchar(5), Serie varchar(5), Folio varchar(5), RutaPDF varchar(500)," +
                    " 							compraSICYID int, TipoMovimiento int, bandera varchar(5), RespaldoColor varchar(5), TipoCompra varchar(5),Tipo_Doc varchar(2))" +
                    " " +
                    " INSERT INTO #tmpCompras (PolizaSAYID, PolizaContpaqID, Movimiento, Cuenta, Proveedor, Cargos, Abonos, Fecha, Referencia, Nave, proveedorSicyID, " +
                    " 						IVA, Subtotal, RutaXML, Rfc, Uuid, Serie, Folio, RutaPDF, compraSICYID, TipoMovimiento, bandera, RespaldoColor, TipoCompra, Tipo_Doc)" +
                    " 	SELECT *" +
                    " 	FROM (" +
                    " 		SELECT '' AS 'PolizaSAYID', '' AS 'PolizaContpaqID', '' AS Movimiento, '' AS Cuenta, RTRIM(p.RazonSocial) AS Proveedor," +
                    " 			'' AS Cargos, cxps.IMPDOCTO AS Abonos, CONVERT(varchar(10), cxps.FECDOCTO, 103) AS Fecha, cxps.NUMDOCTO AS Referencia," +
                    " 			cxpm.NAVE AS Nave, p.IdProveedor AS proveedorSicyID, cxps.IMPIVA AS IVA, cxps.SUBTOT AS Subtotal, cf.cfdRutaXml AS RutaXML," +
                    " 			p.RFC AS Rfc, '' AS Uuid, '' AS Serie, '' AS Folio, cf.cfdRutaVisor AS RutaPDF, IDTABLA AS 'compraSICYID', '1' AS 'TipoMovimiento'," +
                    " 			'' AS bandera, '' AS RespaldoColor, DBO.TipoPolizaCompra(cxps.IDTABLA) TipoCompra, cxps.TIPODOCTO as 'Tipo_Doc'" +
                    " 	FROM CxPSALDOS cxps" +
                    " 	INNER JOIN Proveedores p ON p.IdProveedor = cxps.CVEPROV" +
                    " 	INNER JOIN CxPMOVIMIENTOS cxpm ON cxpm.CVEPROV = cxps.CVEPROV AND cxpm.NUMDOCTO = cxps.NUMDOCTO AND cxpm.AÑOSEMANA = cxps.AÑOSEMPAGO AND cxpm.SEMANA = cxps.SEMPAGO" +
                    " 	LEFT JOIN CFDS AS cf ON cf.cfdId = cxps.IdComprobante" +
                    " 	WHERE cxps.IDRAZSOC IN (" + RazSoc.ToString + ")"
        consulta += " AND cxps.FECDOCTO BETWEEN '" + FechaDe.ToString + "' AND '" + FechaA.ToString + " 23:59:00' "

        If operaciones.Servidor = operacionesSAY.Servidor Then
            consulta += "AND cxps.IDTABLA NOT IN (SELECT pomo_compraid FROM [" + operacionesSAY.NombreDB + "].[Contabilidad].[PolizaMovimientos]  where pomo_fecha BETWEEN " +
                        "(select '01/' + cast(@mes as varchar(5)) + '/' + cast(@año as varchar(5)) as fecha) and (SELECT (select convert(DATE,dateadd(ms,-3,DATEADD(mm, DATEDIFF(m,0,'" + FechaDe.ToString + "')+1, 0)),112))))"
        Else
            consulta += " AND cxps.IDTABLA NOT IN (SELECT pomo_compraid FROM [" + operacionesSAY.Servidor + "].[" + operacionesSAY.NombreDB + "].[Contabilidad].[PolizaMovimientos]  where pomo_fecha BETWEEN " +
                        "(select '01/' + cast(@mes as varchar(5)) + '/' + cast(@año as varchar(5)) as fecha) and (SELECT (select convert(DATE,dateadd(ms,-3,DATEADD(mm, DATEDIFF(m,0,'" + FechaDe.ToString + "')+1, 0)),112))))"
        End If
        consulta += "							AND cxps.IdComprobante > 0" +
                    " 								GROUP BY	p.RazonSocial, cxps.IMPDOCTO,cxps.FECDOCTO, cxps.NUMDOCTO, cxpm.NAVE, p.IdProveedor, cxps.IMPIVA, cxps.SUBTOT, cf.cfdRutaXml, p.RFC, cf.cfdRutaVisor, IDTABLA,cxps.TIPODOCTO" +
                    " ) AS tabla" +
                    " " +
                    " DELETE FROM #tmpCompras" +
                    " WHERE TipoCompra <> 'CP'" +
                    " " +
                    " SELECT Movimiento AS 'Movimiento', cuenta AS 'Cuenta', Proveedor AS 'Proveedor', Cargos AS 'Cargos', Abonos AS 'Abonos', '' AS 'Concepto', " +
                    " 	Fecha AS 'Fecha', Uuid AS 'Uuid', 'F-' + Referencia AS 'Referencia', PolizaSAYID, PolizaContpaqID, nave, proveedorSicyID, iva," +
                    " 	Subtotal, RutaXML, Rfc,serie, Folio, RutaPDF, compraSICYID, TipoMovimiento, bandera, RespaldoColor, TipoCompra, '' AS 'cuentaSAYID'" +
                    " FROM #tmpCompras AS A" +
                    " JOIN RecepcionOrdenes AS  b ON a.proveedorSicyID = b.CVEPRV AND a.Referencia = b.NUMFAC AND B.TIPDOC = a.Tipo_Doc" +
                    " group by Movimiento, cuenta, Proveedor, Cargos, Abonos, Fecha, Uuid, Referencia, PolizaSAYID, PolizaContpaqID, nave, proveedorSicyID, iva, " +
                    " 	Subtotal, RutaXML, Rfc, serie, Folio, RutaPDF, compraSICYID, TipoMovimiento, bandera, RespaldoColor, TipoCompra" +
                    " ORDER BY Fecha, Proveedor"



        Return operaciones.EjecutaConsulta(consulta)
    End Function


    Public Function cargarComprasSinComprobante(ByVal FechaDe As Date, ByVal FechaA As Date, ByVal empresaID As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        'Dim consulta As String = ""
        'consulta += " SELECT"
        'consulta += " S.IDTABLA,"
        'consulta += " s.IdComprobante,"
        'consulta += " s.NUMDOCTO Folio,"
        'consulta += " s.FECDOCTO Fecha,"
        'consulta += " 'FACTURA' [Tipo Documento],"
        'consulta += " P.RFC RFC,"
        'consulta += " P.RazonSocial [Razon Social],"
        'consulta += " s.IMPDOCTO Total,"
        'consulta += " '' UUID,"
        'consulta += " ISNULL(cf.cfdRutaXml, '') 'XML',"
        'consulta += " ISNULL(cf.cfdRutaVisor, '') 'PDF',"
        'consulta += " p.IdProveedor,"
        'consulta += " (SELECT DISTINCT"
        'consulta += " g.IdRazSoc"
        'consulta += " FROM CfgRazonSocialTransferenciaNave g"
        'consulta += " WHERE g.IdDoctoVta = " + empresaID.ToString + "/* and g.IdNave=s.NAVE*/)"
        'consulta += " EmpresaId,"
        'consulta += " (SELECT DISTINCT"
        'consulta += " g.rutaXml + '\'"
        'consulta += " FROM CfgRazonSocialTransferenciaNave g"
        'consulta += " WHERE g.IdDoctoVta = " + empresaID.ToString + " AND g.IdNave = (select na.idnave from NavesAlmacen na where na.idAlmacen=s.NAVE))"
        'consulta += " ruta,"
        'consulta += " s.NAVE Nave,"
        'consulta += " (SELECT"
        'consulta += "     rfc"
        'consulta += "     FROM DoctosVentas"
        'consulta += "   WHERE IdDocumento = " + empresaID.ToString + ")"
        'consulta += "        RFCEmpresa"
        'consulta += " FROM CXPSALDOS AS S"
        'consulta += " JOIN Proveedores p"
        'consulta += "   ON p.IdProveedor = s.CVEPROV"
        'consulta += " LEFT JOIN CFDS cf"
        'consulta += " ON cf.cfdId = s.IdComprobante"
        'consulta += " WHERE s.IDRAZSOC IN (SELECT DISTINCT TOP 1 g.IdRazSoc FROM CfgRazonSocialTransferenciaNave g         WHERE g.IdDoctoVta = " + empresaID.ToString + ")"
        'consulta += " AND s.FECDOCTO BETWEEN '" + FechaDe.ToString + "' AND '" + FechaA.ToString + " 23:59:00'"
        'consulta += " AND S.IdComprobante <= 0"
        'consulta += " ORDER BY p.RazonSocial, s.FECDOCTO"
        'Return operaciones.EjecutaConsulta(consulta)
        'SCDA 22082019 Se cambia consulta a sp

        Dim listaParametros As New List(Of SqlParameter)
        ''ByVal empresa As Integer, ByVal FechaInicio As DateTime, ByVal FechaFin As DateTime, ByVal estatus As String, ByVal tipoPoliza As Integer

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@IdEmpresa"
        parametro.Value = empresaID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FechaInicio"
        parametro.Value = FechaDe
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FechaFin"
        parametro.Value = FechaA
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("Contabilidad.SP_AltaPoliza_cargarComprasSinComprobante", listaParametros)
    End Function

    Public Function cargarCuentaProveedor(ByVal servidor As String, ByVal BD As String, ByVal proveedor As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = ""
        consulta += " SELECT Codigo FROM [" + servidor.ToString.Trim + "].[" + BD.ToString.Trim + "].[dbo].[Cuentas]"
        consulta += " WHERE id=(SELECT idCuenta FROM [" + servidor.ToString.Trim + "].[" + BD.ToString.Trim + "].[dbo].[Proveedores]"
        consulta += " where Nombre like '%" + proveedor.ToString + "%')"
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function cargarCuentaProveedorSAY(ByVal proveedorSicyID As Integer, ByVal empresaID As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = ""
        consulta += " SELECT A.cuco_cuentacontableid,A.cuco_constante1,A.cuco_constante2,A.cuco_letra,A.cuco_consecutivo FROM Contabilidad.CuentasContables as A"
        consulta += " JOIN Proveedor.Proveedor as B on B.prov_proveedorid=A.cuco_proveedorid"
        consulta += " WHERE B.prov_sicyid= " + proveedorSicyID.ToString
        consulta += " and B.prov_activo=1 "
        consulta += " and cuco_empresaid=" + empresaID.ToString
        consulta += " and A.cuco_cuentacontabletipoid=7"
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function cargarCuentaContableSayProveedorNueva(ByVal empresaID As Integer, ByVal proveedorIDSicy As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = ""
        consulta += " SELECT cc.cuco_constante1+cc.cuco_constante2+cc.cuco_letra+cc.cuco_consecutivo as 'CuentaContableSAY',cc.cuco_descripcion as 'Descripcion'," +
            " cc.cuco_cuentacontableid as 'cuentaSAYID'  "
        consulta += " FROM Proveedor.Proveedor as p"
        consulta += " join Contabilidad.CuentasContables  as cc on cc.cuco_proveedorid= p.prov_proveedorid"
        consulta += " where p.prov_sicyid = " + proveedorIDSicy.ToString
        consulta += " and cc.cuco_empresaid=" + empresaID.ToString
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function cargarCuentaContableSayProveedorNueva2(ByVal empresaID As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = ""
        consulta += " SELECT cc.cuco_constante1+cc.cuco_constante2+cc.cuco_letra+cc.cuco_consecutivo as 'CuentaContableSAY',cc.cuco_descripcion as 'Descripcion'," +
            " cc.cuco_cuentacontableid as 'cuentaSAYID',prov_sicyid "
        consulta += " FROM Proveedor.Proveedor as p"
        consulta += " join Contabilidad.CuentasContables  as cc on cc.cuco_proveedorid= p.prov_proveedorid"
        consulta += " where cc.cuco_descripcion is not null "
        consulta += " and cc.cuco_empresaid=" + empresaID.ToString
        consulta += " order by Descripcion"
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function cargarCuentaProveedorSICY(ByVal proveedor As String, ByVal empresaID As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String = ""
        consulta += " SELECT * FROM CuentasContabilidad"
        consulta += " where claveSICY =" + proveedor.ToString
        consulta += " and IdTipo=6"
        consulta += " and IdEmpresaSicy IN (" + empresaID.ToString + ")"
        Return operaciones.EjecutaConsulta(consulta)
    End Function

#End Region

#Region "CARGAR DEPOSITOS POR IDENTIFICAR"
    Public Function cargarGridDepositosPorIdentificar(ByVal empresa As Integer, ByVal FechaInicio As DateTime, ByVal FechaFin As DateTime, ByVal estatus As String)
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim operacionesSay As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = ""

        consulta += " DECLARE @mes int, @año int " +
                    " set @mes=month('" + FechaInicio.ToShortDateString + "' )" +
                    " set @año=year('" + FechaInicio.ToShortDateString + "' )  "

        consulta += " select "
        consulta += " '' as 'Movimiento',"
        consulta += " '' as 'Cuenta',"
        consulta += " b.Banco+SPACE(1)+'('+cb.Cuenta+')' as 'Banco',"
        consulta += " mb.Importe as 'Cargos',"
        consulta += " '' as 'Abonos',"
        consulta += " '' as 'Concepto',"
        consulta += " mb.Fecha AS 'Fecha',"
        consulta += " '' as 'Uuid',"
        consulta += " '' as 'Referencia',"
        consulta += " mb.IdCuenta as 'Cuentaid',"
        consulta += " mb.IdMovimiento as 'Movimientoid',"
        consulta += " cb.Cuenta as 'Cuentabancaria',"
        consulta += " '' as 'TipoMovimiento',"
        consulta += " '' as 'RespaldoColor',"
        consulta += " '' as 'bandera',"
        consulta += " '' as 'cuentaSAYID',"
        consulta += " '' as 'tipoPolizaContpaqID'"
        consulta += " from MovimientosBancarios  as mb"
        consulta += " JOIN CuentasBancarias  as cb  on cb.IdCuenta=mb.IdCuenta"
        consulta += " JOIN Bancos as b on b.IdBanco= cb.IdBanco"
        consulta += " where mb.Fecha"
        consulta += " BETWEEN '" + FechaInicio.ToShortDateString + "' AND '" + FechaFin.ToShortDateString + " 23:59:00'"
        consulta += " and mb.IdCuenta in (select IdCuenta from CuentasBancarias where IdDocumento=" + empresa.ToString + " and Estatus='S') "
        consulta += " and Movimiento='DEPOSITO'"

        If estatus = "NUEVAS" Then
            If operaciones.Servidor = operacionesSay.Servidor Then
                consulta += " AND mb.IdMovimiento NOT IN (SELECT       pomo_compraid FROM [" + operacionesSay.NombreDB + "].[Contabilidad].[PolizaMovimientos] where pomo_fecha BETWEEN " +
                        "(select '01/' + cast(@mes as varchar(5)) + '/' + cast(@año as varchar(5)) as fecha) and (SELECT (select convert(DATE,dateadd(ms,-3,DATEADD(mm, DATEDIFF(m,0, '" + FechaInicio.ToShortDateString + "')+1, 0)),112))))"
            Else
                consulta += "AND mb.IdMovimiento NOT IN (SELECT        pomo_compraid FROM [" + operacionesSay.Servidor() + "].[" + operacionesSay.NombreDB + "].[Contabilidad].[PolizaMovimientos] where pomo_fecha BETWEEN " +
                        "(select '01/' + cast(@mes as varchar(5)) + '/' + cast(@año as varchar(5)) as fecha) and (SELECT (select convert(DATE,dateadd(ms,-3,DATEADD(mm, DATEDIFF(m,0, '" + FechaInicio.ToShortDateString + "')+1, 0)),112))))"
            End If
        Else
            If operaciones.Servidor = operacionesSay.Servidor Then
                consulta += " AND mb.IdMovimiento IN (SELECT   pomo_compraid FROM [" + operacionesSay.NombreDB + "].[Contabilidad].[PolizaMovimientos] where pomo_fecha BETWEEN " +
                        "(select '01/' + cast(@mes as varchar(5)) + '/' + cast(@año as varchar(5)) as fecha) and (SELECT (select convert(DATE,dateadd(ms,-3,DATEADD(mm, DATEDIFF(m,0, '" + FechaInicio.ToShortDateString + "')+1, 0)),112))))"
            Else
                consulta += " AND mb.IdMovimiento IN (SELECT   pomo_compraid FROM [" + operacionesSay.Servidor() + "].[" + operacionesSay.NombreDB + "].[Contabilidad].[PolizaMovimientos] where pomo_fecha BETWEEN " +
                        "(select '01/' + cast(@mes as varchar(5)) + '/' + cast(@año as varchar(5)) as fecha) and (SELECT (select convert(DATE,dateadd(ms,-3,DATEADD(mm, DATEDIFF(m,0, '" + FechaInicio.ToShortDateString + "')+1, 0)),112))))"
            End If
        End If
        consulta += " AND cb.Cuenta not in ('01700004472')"
        consulta += " and cb.Cuenta not in ('4044866507')"
        consulta += " and cb.Cuenta not in ('28290000201')"
        Return operaciones.EjecutaConsulta(consulta)

    End Function

#End Region

#Region "CARGAR DEPOSITOS IDENTIFICADOS"
    Public Function cargarGridDepositosIdentificados(ByVal empresa As Integer, ByVal FechaInicio As DateTime, ByVal FechaFin As DateTime, ByVal estatus As String, ByVal tipoPoliza As Integer)
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim operacionesSay As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = ""

        'consulta += " DECLARE @mes int, @año int " +
        '            " set @mes=month('" + FechaInicio.ToShortDateString + "' )" +
        '            " set @año=year('" + FechaInicio.ToShortDateString + "' )  "

        'consulta += "select * from (SELECT"
        'consulta += " '' AS 'Movimiento',"
        'consulta += " '' AS 'Cuenta',"
        'consulta += " cl.nombre AS 'Cliente',"
        'consulta += " cl.IdCliente AS 'Clienteid',"
        'consulta += " (select sum(c2.Importe) from cobros c2 join MovimientosBancarios mb2 on c2.IdDeposito=mb2.IdMovimiento "
        'consulta += " WHERE mb2.FechaAplicacion BETWEEN '" + FechaInicio.ToShortDateString + " 00:00:00' AND '" + FechaFin.ToShortDateString + " 23:59:00' and c2.IdDeposito=a.IdDeposito) "
        'consulta += " AS 'Cargos',"
        'consulta += " a.Importe AS 'Abonos',"
        'consulta += " a.Concepto AS 'Concepto',"
        'consulta += " mb.FechaAplicacion AS 'Fecha',"
        'consulta += " mb.Fecha AS 'FechaDeposito',"
        'consulta += " '' AS 'Uuid',"
        'consulta += " a.IdDeposito as 'depositoID',"
        'consulta += " a.IdCobro AS 'Cobroid',"
        'consulta += " b.RutaXML AS 'Xml',"
        'consulta += " b.RutaPDF AS 'Pdf',"
        'consulta += " '' AS 'Serie',"
        'consulta += " '' AS 'Folio',"
        'consulta += " '' AS 'Tipomovimiento',"
        'consulta += " '' AS 'RespaldoColor',"
        'consulta += " '' AS 'bandera',"
        'consulta += " '' AS 'Referencia',"
        'consulta += " cl.rfc AS 'RFC',"
        'consulta += " '' AS 'cuentaSAYID'"
        'consulta += " FROM cobros AS a"
        'consulta += " JOIN DoctosElectronicos AS b ON b.IdDocto = a.IdRemision AND a.Año = b.Año  AND a.IdCadena = b.IdCadena "
        'consulta += " JOIN Clientes AS cl ON cl.IdCliente = b.IdCliente"
        'consulta += " JOIN MovimientosBancarios mb ON A.IdDeposito=mb.IdMovimiento"
        'consulta += " LEFT JOIN (SELECT CLAVESICY, CLAVECUENTA, CUENTA, DESCRIPCION, IDSEGMENTONEGOCIO FROM CUENTASCONTABILIDAD"
        'consulta += " WHERE IDTIPO = 2"
        'consulta += " AND IDEMPRESASICY = " + empresa.ToString + ""
        'consulta += " ) CTA"
        'consulta += " ON CLAVESICY = cl.IDCLIENTE"
        'consulta += " WHERE MB.FechaAplicacion BETWEEN '" + FechaInicio.ToShortDateString + " 00:00:00' AND '" + FechaFin.ToShortDateString + " 23:59:00'"
        'consulta += " AND a.TipoCobro = 'DEPOSITO'"
        'consulta += " AND a.Cuenta IN (SELECT"
        'consulta += " Cuenta"
        'consulta += " FROM CuentasBancarias"
        'consulta += " WHERE IdDocumento = " + empresa.ToString
        'consulta += " AND Estatus = 'S'"
        'consulta += " AND Tipo = 1)"
        'consulta += " AND B.TipoDocto = 'FAC'"

        'If estatus = "NUEVAS" Then
        '    If operaciones.Servidor = operacionesSay.Servidor Then
        '        consulta += " AND a.IdCobro NOT IN (SELECT	pomo_cobroid FROM [" + operacionesSay.NombreDB + "].[Contabilidad].[PolizaMovimientos] where pomo_fecha BETWEEN " +
        '                "(select '01/' + cast(@mes as varchar(5)) + '/' + cast(@año as varchar(5)) as fecha) and (SELECT (select convert(DATE,dateadd(ms,-3,DATEADD(mm, DATEDIFF(m,0,'" + FechaInicio.ToShortDateString + "')+1, 0)),112))))"
        '    Else
        '        consulta += " AND a.IdCobro NOT IN (SELECT	pomo_cobroid FROM [" + operacionesSay.Servidor + "].[" + operacionesSay.NombreDB + "].[Contabilidad].[PolizaMovimientos] where pomo_fecha BETWEEN " +
        '                "(select '01/' + cast(@mes as varchar(5)) + '/' + cast(@año as varchar(5)) as fecha) and (SELECT (select convert(DATE,dateadd(ms,-3,DATEADD(mm, DATEDIFF(m,0,'" + FechaInicio.ToShortDateString + "')+1, 0)),112))))"
        '    End If
        'Else
        '    If operaciones.Servidor = operacionesSay.Servidor Then
        '        consulta += " AND a.IdCobro IN (SELECT	pomo_cobroid FROM [" + operacionesSay.NombreDB + "].[Contabilidad].[PolizaMovimientos] where pomo_cobroid <> 0 and  pomo_fecha BETWEEN " +
        '                "(select '01/' + cast(@mes as varchar(5)) + '/' + cast(@año as varchar(5)) as fecha) and (SELECT (select convert(DATE,dateadd(ms,-3,DATEADD(mm, DATEDIFF(m,0,'" + FechaInicio.ToShortDateString + "')+1, 0)),112))))"
        '    Else
        '        consulta += " AND a.IdCobro IN (SELECT	pomo_cobroid FROM [" + operacionesSay.Servidor + "].[" + operacionesSay.NombreDB + "].[Contabilidad].[PolizaMovimientos] where pomo_cobroid <> 0 and pomo_fecha BETWEEN " +
        '                "(select '01/' + cast(@mes as varchar(5)) + '/' + cast(@año as varchar(5)) as fecha) and (SELECT (select convert(DATE,dateadd(ms,-3,DATEADD(mm, DATEDIFF(m,0,'" + FechaInicio.ToShortDateString + "')+1, 0)),112))))"
        '    End If
        'End If
        'consulta += " ) as cons" +
        '    " GROUP by cons.Movimiento,cons.Cuenta,cons.Cliente,cons.Clienteid,cons.Cargos,cons.Abonos,cons.Concepto,cons.Fecha,cons.FechaDeposito,cons.Uuid,cons.depositoID," +
        '    " cons.Cobroid,cons.Xml,cons.Pdf,cons.Serie,cons.Folio,cons.Tipomovimiento,cons.RespaldoColor,cons.bandera,cons.Referencia,cons.RFC,cons.cuentaSAYID" +
        '    " ORDER BY fecha, cliente"

        'Return operaciones.EjecutaConsulta(consulta)

        'SCDA 11042019 Se cambia consulta a sp

        Dim listaParametros As New List(Of SqlParameter)
        ''ByVal empresa As Integer, ByVal FechaInicio As DateTime, ByVal FechaFin As DateTime, ByVal estatus As String, ByVal tipoPoliza As Integer

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@IdEmpresa"
        parametro.Value = empresa
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
        parametro.ParameterName = "@Estatus"
        parametro.Value = estatus
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@tipoPoliza"
        parametro.Value = tipoPoliza
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@ServidorSicy"
        parametro.Value = operaciones.Servidor
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@ServidorSAY"
        parametro.Value = operacionesSay.Servidor
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Base"
        parametro.Value = operacionesSay.NombreDB
        listaParametros.Add(parametro)


        Return operaciones.EjecutarConsultaSP("Contabilidad.SP_AltaPoliza_DepositosIdentificados", listaParametros)

    End Function

    Public Function cargarCuentasContablesSayClientes(ByVal empresaID As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        'Dim consulta As String = ""
        'consulta += " SELECT "
        'consulta += " isnull(cc.cuco_constante1 + cc.cuco_constante2 + cc.cuco_letra + cc.cuco_consecutivo,0) AS 'CuentaContableSAY' , cc.cuco_descripcion as 'Descripcion', cc.cuco_cuentacontableid as  'cuentaSAYID', pers_IdSICY"
        'consulta += " FROM Cliente.ClienteRFC cr"
        'consulta += " JOIN Framework.Persona pr ON cr.crfc_personaid = pr.pers_personaid"
        'consulta += " JOIN Contabilidad.CuentasContables as cc on convert (varchar,cc.cuco_clienteid)=pr.pers_IdSICY"
        'consulta += " WHERE cc.cuco_empresaid=" + empresaID.ToString
        'Return operaciones.EjecutaConsulta(consulta)
        'SCDA 23072020 Se cambia consulta a sp
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "@empresaID"
        parametro.Value = empresaID
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("Contabilidad.SP_Polizas_cargarCuentasContablesSayClientes", listaParametros)

    End Function

    Public Function cargarCuentaContableSayClienteNueva(ByVal empresaID As Integer, ByVal cleinteSicyID As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = ""
        consulta += " SELECT "
        consulta += " isnull(cc.cuco_constante1 + cc.cuco_constante2 + cc.cuco_letra + cc.cuco_consecutivo,0) AS 'CuentaContableSAY' , cc.cuco_descripcion as 'Descripcion', cc.cuco_cuentacontableid as  'cuentaSAYID'"
        consulta += " FROM Cliente.ClienteRFC cr"
        consulta += " JOIN Framework.Persona pr ON cr.crfc_personaid = pr.pers_personaid"
        consulta += " JOIN Contabilidad.CuentasContables as cc on cc.cuco_clienteid=pr.pers_IdSICY"
        consulta += " WHERE pers_IdSICY = '" + cleinteSicyID.ToString + "'"
        consulta += " and cc.cuco_empresaid=" + empresaID.ToString
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function validarclienteExisteSay2(ByVal IdEmpresa As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        'Dim consulta As String = ""
        'consulta += "SELECT  pers_IdSICY, A.crfc_clienterfcid AS clienteID"
        'consulta += " FROM Framework.Persona RIGHT JOIN Cliente.ClienteRFC AS A ON crfc_personaid = pers_personaid"
        'consulta += " where A.crfc_personaid<> 10732"
        ''consulta += " and pers_activo = 1"
        'consulta += " GROUP by pers_IdSICY, A.crfc_clienterfcid"
        'Return operaciones.EjecutaConsulta(consulta)

        'SCDA 23072020 Se cambia consulta a sp
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "@IdEmpresa"
        parametro.Value = IdEmpresa
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("Contabilidad.SP_Polizas_validarclienteExiste", listaParametros)

    End Function

    Public Function validarclienteExisteSay(ByVal clienteID As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = ""
        consulta += " SELECT A.crfc_clienterfcid AS clienteID	FROM Framework.Persona"
        consulta += " JOIN Framework.TiposPersonas ON tipe_personaid = pers_personaid"
        consulta += " JOIN Framework.ClasificacionPersona ON clpe_clasificacionpersonaid = tipe_clasificacionpersonaid"
        consulta += " JOIN Cliente.ClienteRFC AS A ON crfc_personaid = pers_personaid"
        consulta += " LEFT JOIN Cliente.ClienteRFC AS B ON B.crfc_clienterfcid = A.crfc_clienterfcidafacturar"
        consulta += " WHERE pers_IdSICY = '" + clienteID.ToString + "'"
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function validarProveedorExisteSAY(ByVal proveedor As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = ""
        consulta += " SELECT * FROM Proveedor.Proveedor "
        consulta += " where prov_sicyid =" + proveedor.ToString
        Return operaciones.EjecutaConsulta(consulta)
    End Function

#End Region

#Region "CARGAR GRID DE VENTAS"
    Public Function CargaGridPolizaVentas(ByVal estatus As String, ByVal RazSoc As String, ByVal FechaDe As String, ByVal FechaA As String, ByVal empresaID As Integer) As DataTable

        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim operacionesSAY As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = ""

        consulta += " DECLARE @mes int, @año int " +
                    " set @mes=month('" + FechaDe.ToString + "' )" +
                    " set @año=year('" + FechaDe.ToString + "' )  "

        consulta += " SELECT"
        consulta += " '' Movimiento,"
        consulta += " '' Cuenta,"
        consulta += " c.nombre Cliente,"
        consulta += " V.Total Cargos,"
        consulta += " (v.Total - v.IVA) Abonos,"
        consulta += " '' Concepto,"
        consulta += " d.Fecha,"
        consulta += " '' Uuid,"
        consulta += " ('F-' + d.serie + CONVERT(VARCHAR, d.Folio)) Referencia,"
        consulta += " '' Serie,"
        consulta += " '' Folio,	"
        consulta += " '' TipoMovimiento,"
        consulta += " '' RespaldoColor,"
        consulta += " '' bandera,"
        consulta += " d.RutaXML rutaXML,"
        consulta += " d.RutaPDF rutaPDF,"
        consulta += " d.IdCliente Clienteid,"
        consulta += " v.IVA AS 'IVA',"
        consulta += " 	v.SubTotal as 'Subtotal',"
        consulta += " REPLACE(RTRIM(LTRIM(c.rfc)), '-', '') RFC,"
        consulta += " d.IdUnico IdVenta,"
        consulta += " '' AS cuentaSAYID"
        consulta += " from Ventas v"
        consulta += " inner join DoctosElectronicos d on v.IdRemision=d.IdDocto and d.Año=v.Año"
        consulta += " inner join Clientes c on d.IdCliente=c.IdCliente"
        consulta += " where d.TipoDocto='FAC' and  CONVERT(datetime, d.Fecha, 103) BETWEEN CONVERT(datetime, '" + FechaDe + " 00:00',103) and CONVERT(datetime, '" + FechaA + " 23:00' ,103)"
        consulta += " and v.IDMONEDA=1 /*and d.Estatus not in ('CANCELADO')*/ and d.IdDocumento=" + RazSoc.ToString

        If operaciones.Servidor = operacionesSAY.Servidor Then
            consulta += " AND  d.IdUnico not in (SELECT isNULL(pomo_ventaid,0) from [" + operacionesSAY.NombreDB + "].[Contabilidad].[PolizaMovimientos]  where pomo_fecha BETWEEN " +
                        "(select '01/' + cast(@mes as varchar(5)) + '/' + cast(@año as varchar(5)) as fecha) and (SELECT (select convert(DATE,dateadd(ms,-3,DATEADD(mm, DATEDIFF(m,0,'" + FechaDe.ToString + "')+1, 0)),112))))"
        Else
            consulta += " AND  d.IdUnico not in (SELECT isNULL(pomo_ventaid,0) from [" + operacionesSAY.Servidor() + "].[" + operacionesSAY.NombreDB + "].[Contabilidad].[PolizaMovimientos] where pomo_fecha BETWEEN " +
                        "(select '01/' + cast(@mes as varchar(5)) + '/' + cast(@año as varchar(5)) as fecha) and (SELECT (select convert(DATE,dateadd(ms,-3,DATEADD(mm, DATEDIFF(m,0,'" + FechaDe.ToString + "')+1, 0)),112))))"
        End If

        consulta += " order by d.Fecha, c.IdCliente"
        Return operaciones.EjecutaConsulta(consulta)
    End Function
#End Region

#Region "CARGAR GRID DE VENTAS CANCELADAS"
    Public Function CargaGridPolizaVentasCanceladas(ByVal estatus As String, ByVal RazSoc As String, ByVal FechaDe As String, ByVal FechaA As String, ByVal empresaID As Integer) As DataTable

        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim operacionesSAY As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = ""

        consulta += " DECLARE @mes int, @año int " +
                    " set @mes=month('" + FechaDe.ToString + "' )" +
                    " set @año=year('" + FechaDe.ToString + "' )  "

        consulta += " SELECT '' Movimiento, '' Cuenta, c.nombre Cliente, (v.Total - v.IVA) Cargos, V.Total Abonos, '' Concepto, v.FechaCancelacion as Fecha, '' Uuid," +
                    "       ('F-' + d.serie + CONVERT(varchar, d.Folio)) Referencia, '' Serie, '' Folio, '' TipoMovimiento, '' RespaldoColor, '' bandera," +
                    "      	d.RutaXML, d.comFormatoCancelacion rutaPDF, d.IdCliente Clienteid, v.IVA AS 'IVA', v.SubTotal AS 'Subtotal'," +
                    "       REPLACE(RTRIM(LTRIM(c.rfc)), '-', '') RFC, d.IdUnico IdVenta, '' AS cuentaSAYID" +
                    " FROM Ventas v" +
                    " INNER JOIN DoctosElectronicos d ON v.IdRemision = d.IdDocto AND CONVERT(date, v.FechaFE) = CONVERT(date, d.Fecha)" +
                    " INNER JOIN Clientes c ON d.IdCliente = c.IdCliente" +
                    " WHERE d.TipoDocto = 'FAC'" +
                    " and  CONVERT(datetime, v.FechaCancelacion, 103) BETWEEN CONVERT(datetime, '" + FechaDe + " 00:00',103) and CONVERT(datetime, '" + FechaA + " 23:00' ,103)"
        consulta += " and d.Estatus in ('CANCELADO') and v.IDMONEDA=1 and d.IdDocumento=" + RazSoc.ToString

        If operaciones.Servidor = operacionesSAY.Servidor Then
            consulta += " AND  d.IdUnico not in (SELECT isNULL(pomo_ventacanceladaid,0) from [" + operacionesSAY.NombreDB + "].[Contabilidad].[PolizaMovimientos]  where pomo_fecha BETWEEN " +
                        "(select '01/' + cast(@mes as varchar(5)) + '/' + cast(@año as varchar(5)) as fecha) and (SELECT (select convert(DATE,dateadd(ms,-3,DATEADD(mm, DATEDIFF(m,0,'" + FechaDe.ToString + "')+1, 0)),112))))"
        Else
            consulta += " AND  d.IdUnico not in (SELECT isNULL(pomo_ventacanceladaid,0) from [" + operacionesSAY.Servidor() + "].[" + operacionesSAY.NombreDB + "].[Contabilidad].[PolizaMovimientos]  where pomo_fecha BETWEEN " +
                        "(select '01/' + cast(@mes as varchar(5)) + '/' + cast(@año as varchar(5)) as fecha) and (SELECT (select convert(DATE,dateadd(ms,-3,DATEADD(mm, DATEDIFF(m,0,'" + FechaDe.ToString + "')+1, 0)),112))))"
        End If

        consulta += " order by d.Fecha, c.IdCliente"
        Return operaciones.EjecutaConsulta(consulta)
    End Function
#End Region

#Region "CARGAR GRID GASTOS"

    Public Function cargarGridComprasGastos(ByVal contribuyentesID As Integer, ByVal doctoVentasID As Integer, ByVal FechaInicio As DateTime, ByVal FechaFin As DateTime, ByVal estatus As String, ByVal tipoPoliza As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim operacionesSAY As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter = Nothing

        parametro = New SqlParameter("@contribuyentesId", contribuyentesID)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@doctoVentasId", doctoVentasID)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@fechaInicio", FechaInicio)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@fechaFin", FechaFin)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@tipoPoliza", tipoPoliza)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@servidorSicy", operaciones.Servidor)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@servidorSAY", operacionesSAY.Servidor)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@base", operacionesSAY.NombreDB)
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Contabilidad].[SP_AltaPoliza_cargarGridComprasGastos]", listaParametros)

    End Function

    Public Function cargarGridProductoTerminado(ByVal contribuyentesID As Integer, ByVal doctoVentasID As Integer, ByVal FechaInicio As DateTime, ByVal FechaFin As DateTime, ByVal estatus As String, ByVal tipoPoliza As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim operacionesSAY As New Persistencia.OperacionesProcedimientos
        'Dim consulta As String = ""
        'consulta += " IF OBJECT_ID ('tempdb.dbo.#tmpCompras') is not null BEGIN"
        'consulta += " DROP TABLE #tmpCompras;"
        'consulta += " End"
        'consulta += " "
        'consulta += " DECLARE @mes int, @año int "
        'consulta += " set @mes=month('" + FechaInicio.ToShortDateString + "' )"
        'consulta += " set @año=year('" + FechaInicio.ToShortDateString + "' )"
        'consulta += " create table #tmpCompras( PolizaSAYID varchar(5),    PolizaContpaqID varchar(5), Movimiento varchar(5), Cuenta varchar(5),    Proveedor varchar(200),    Cargos money,Abonos money,       Fecha smalldatetime,      Referencia varchar(50),    Nave int,    proveedorSicyID int, IVA money,       Subtotal money,     RutaXML varchar(500),      Rfc varchar(50),    Uuid varchar(5),    Serie varchar(5),  Folio varchar(5),   RutaPDF varchar(500),      compraSICYID int,  TipoMovimiento int,       bandera varchar(5), RespaldoColor varchar(5), TipoCompra varchar(5))"
        'consulta += " INSERT INTO #tmpCompras (PolizaSAYID, PolizaContpaqID, Movimiento, Cuenta, Proveedor, Cargos, Abonos, Fecha, Referencia, Nave, proveedorSicyID, IVA, Subtotal, RutaXML, Rfc, Uuid, Serie, Folio, RutaPDF, compraSICYID, TipoMovimiento, bandera, RespaldoColor, TipoCompra)"
        'consulta += " SELECT"
        'consulta += " PolizaSAYID,"
        'consulta += " PolizaContpaqID,"
        'consulta += " Movimiento,"
        'consulta += " Cuenta,"
        'consulta += " Proveedor,"
        'consulta += " Cargos,"
        'consulta += " Abonos,"
        'consulta += " Fecha,"
        'consulta += " Referencia,"
        'consulta += " Nave,"
        'consulta += " proveedorSicyID,"
        'consulta += " IVA,"
        'consulta += " Subtotal,"
        'consulta += " RutaXML,"
        'consulta += " Rfc,"
        'consulta += " Uuid,"
        'consulta += " Serie,"
        'consulta += " Folio,"
        'consulta += " RutaPDF,"
        'consulta += " compraSICYID,"
        'consulta += " TipoMovimiento,"
        'consulta += " bandera,"
        'consulta += " RespaldoColor,"
        'consulta += " TipoCompra"
        'consulta += " FROM (SELECT"
        'consulta += " '' AS 'PolizaSAYID',"
        'consulta += " '' AS 'PolizaContpaqID',"
        'consulta += " '' AS Movimiento,"
        'consulta += " '' AS Cuenta,"
        'consulta += " RTRIM(p.RazonSocial) AS Proveedor,"
        'consulta += " '' AS Cargos,"
        'consulta += " cxps.IMPDOCTO AS Abonos,"
        'consulta += " CONVERT(VARCHAR(10), cxps.FECDOCTO, 103) AS Fecha,"
        'consulta += " cxps.NUMDOCTO AS Referencia,"
        'consulta += " cxpm.NAVE AS Nave,"
        'consulta += " p.IdProveedor AS proveedorSicyID,"
        'consulta += " cxps.IMPIVA AS IVA,"
        'consulta += " cxps.SUBTOT AS Subtotal,"
        'consulta += " cf.cfdRutaXml AS RutaXML,"
        'consulta += " p.RFC AS Rfc,"
        'consulta += "         '' AS Uuid,"
        'consulta += " '' AS Serie,"
        'consulta += " '' AS Folio,"
        'consulta += " cf.cfdRutaVisor AS RutaPDF,"
        'consulta += " IDTABLA AS 'compraSICYID',"
        'consulta += " '1' AS 'TipoMovimiento',"
        'consulta += " '' AS bandera,"
        'consulta += " '' AS RespaldoColor,"
        'consulta += " CASE WHEN cxpS.REFERENCIA = 'MAQUILAS' THEN 'PT'" +
        '            "   ELSE	CASE WHEN cxpS.REFERENCIA = 'MAQUILA' THEN 'PT'" +
        '            "   ELSE	CASE WHEN cxpS.REFERENCIA = 'CALZADO' THEN 'PT'" +
        '            "   ELSE	CASE WHEN cxpS.REFERENCIA = 'TRANSPORTES' THEN 'GT'" +
        '            "   ELSE 'NA' END END END" +
        '            " END AS TipoCompra"
        'consulta += " FROM CxPSALDOS cxps"
        'consulta += " INNER JOIN Proveedores p ON p.IdProveedor = cxps.CVEPROV"
        'consulta += " INNER JOIN CxPMOVIMIENTOS cxpm ON cxpm.CVEPROV = cxps.CVEPROV AND cxpm.NUMDOCTO = cxps.NUMDOCTO AND cxpm.AÑOSEMANA = cxps.AÑOSEMPAGO AND cxpm.SEMANA = cxps.SEMPAGO"
        'consulta += " LEFT JOIN CFDS AS cf ON cf.cfdId = cxps.IdComprobante"
        'consulta += " WHERE cxps.IDRAZSOC IN (" + contribuyentesID.ToString + ")"
        'consulta += " AND cxps.FECDOCTO BETWEEN '" + FechaInicio.ToShortDateString + " 00:00:00' AND '" + FechaFin.ToShortDateString + " 23:59:00'"

        'If operaciones.Servidor = operacionesSAY.Servidor Then
        '    consulta += " AND cxps.IDTABLA NOT IN (SELECT	pomo_compraid FROM [" + operacionesSAY.NombreDB + "].[Contabilidad].[PolizaMovimientos]  where pomo_fecha BETWEEN " +
        '                "(select '01/' + cast(@mes as varchar(5)) + '/' + cast(@año as varchar(5)) as fecha) and (SELECT (select convert(DATE,dateadd(ms,-3,DATEADD(mm, DATEDIFF(m,0,'" + FechaInicio.ToShortDateString + "')+1, 0)),112))))"
        'Else
        '    consulta += " AND cxps.IDTABLA NOT IN (SELECT	pomo_compraid FROM [" + operacionesSAY.Servidor() + "].[" + operacionesSAY.NombreDB + "].[Contabilidad].[PolizaMovimientos]  where pomo_fecha BETWEEN " +
        '                "(select '01/' + cast(@mes as varchar(5)) + '/' + cast(@año as varchar(5)) as fecha) and (SELECT (select convert(DATE,dateadd(ms,-3,DATEADD(mm, DATEDIFF(m,0,'" + FechaInicio.ToShortDateString + "')+1, 0)),112))))"
        'End If

        'consulta += " AND cxps.IdComprobante > 0 AND cxps.REFERENCIA IN ('TRANSPORTES', 'MAQUILAS', 'MAQUILA', 'CALZADO') "
        'consulta += " GROUP BY     p.RazonSocial,"
        'consulta += " cxps.IMPDOCTO,"
        'consulta += " cxps.FECDOCTO,"
        'consulta += " cxps.NUMDOCTO,"
        'consulta += " cxpm.NAVE,"
        'consulta += " p.IdProveedor,"
        'consulta += " cxps.IMPIVA,"
        'consulta += " cxps.SUBTOT,"
        'consulta += " cf.cfdRutaXml,"
        'consulta += " p.RFC,"
        'consulta += " cf.cfdRutaVisor,"
        'consulta += " IDTABLA,cxpS.REFERENCIA) AS tabla"

        'If tipoPoliza = "PRODUCTO TERMINADO" Then
        '    consulta += " DELETE FROM #tmpCompras"
        '    consulta += " WHERE TipoCompra IN ('GT','CP','CPC')"
        'ElseIf tipoPoliza = "GASTOS DE TRANSPORTE" Then
        '    consulta += " DELETE FROM #tmpCompras"
        '    consulta += " WHERE TipoCompra IN ('PT','CP','CPC')"
        'End If

        'consulta += " SELECT"
        'consulta += " Movimiento,"
        'consulta += " a.Cuenta,"
        'consulta += " Proveedor,"
        'consulta += " Cargos,"
        'consulta += " Abonos,"
        'consulta += " '' AS Concepto,"
        'consulta += " Fecha,"
        'consulta += " Referencia,"
        'consulta += " PolizaSAYID,"
        'consulta += " PolizaContpaqID,"
        'consulta += " Nave,"
        'consulta += " proveedorSicyID,"
        'consulta += " IVA,"
        'consulta += " Subtotal,"
        'consulta += " isnull(RutaXML,'') as 'RutaXML',"
        'consulta += " Rfc,"
        'consulta += " Uuid,"
        'consulta += " Serie,"
        'consulta += " Folio,"
        'consulta += " isnull(RutaPDF,'') as 'RutaPDF',"
        'consulta += " compraSICYID,"
        'consulta += " TipoMovimiento,"
        'consulta += " bandera,"
        'consulta += " RespaldoColor,"
        'consulta += " TipoCompra,"
        'consulta += " ISNULL(REPLACE(d.Cuenta, '-', ''), '') AS 'CuentaMaterial',"
        'consulta += " ISNULL(d.Descripcion, '') DescripcionCuentaMaterial,"
        'consulta += " ISNULL(d.Descripcion, '') descripcionCuenta,"
        'consulta += " '' AS cuentaSAYID"
        'consulta += " FROM #tmpCompras a"
        'consulta += " join ctbProveedorTipoCompra as b on a.proveedorSicyID=b.idproveedor and b.idempresa=" + contribuyentesID.ToString.ToString
        'consulta += " LEFT JOIN ctbCuentasContabilidadGastosCompras d ON REPLACE(b.Cuentacontable, '-', '') = d.cuenta"
        'consulta += " GROUP BY     REPLACE(D.Cuenta, '-', ''),"
        'consulta += " d.descripcion,"
        'consulta += " d.descripcion,"
        'consulta += " a.PolizaSAYID,"
        'consulta += " a.PolizaContpaqID,"
        'consulta += " a.Movimiento,"
        'consulta += " a.Cuenta,"
        'consulta += " a.Proveedor,"
        'consulta += " a.Cargos,"
        'consulta += " a.Abonos,"
        'consulta += " a.Fecha,"
        'consulta += " a.Referencia,"
        'consulta += " a.Nave,"
        'consulta += " a.proveedorSicyID,"
        'consulta += " a.IVA,"
        'consulta += " a.Subtotal,"
        'consulta += " a.RutaXML,"
        'consulta += " rfc,"
        'consulta += " uuid,"
        'consulta += " a.Serie,"
        'consulta += " a.Folio,"
        'consulta += " a.RutaPDF,"
        'consulta += " a.compraSICYID,"
        'consulta += " a.TipoMovimiento,"
        'consulta += " a.bandera,"
        'consulta += " a.RespaldoColor,"
        'consulta += " a.TipoCompra"
        'consulta += " ORDER BY a.Referencia"
        'Return operaciones.EjecutaConsulta(consulta)
        'SCDA 29062020 Se cambia la consulta a SP
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@contribuyentesID"
        parametro.Value = contribuyentesID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@doctoVentasID"
        parametro.Value = doctoVentasID
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
        parametro.ParameterName = "@tipoPoliza"
        parametro.Value = tipoPoliza
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@ServidorSicy"
        parametro.Value = operaciones.Servidor
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@ServidorSAY"
        parametro.Value = operacionesSAY.Servidor
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Base"
        parametro.Value = operacionesSAY.NombreDB
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Contabilidad].[SP_AltaPoliza_cargarGridProductoTerminado]", listaParametros)
    End Function
#End Region

#Region "Cargar Grid Activo Fijo"

    Public Function CargaGridActivoFijo(ByVal contribuyentesID As Integer, ByVal FechaInicio As DateTime, ByVal FechaFin As DateTime, ByVal DoctosVentas As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim operacionesSAY As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = ""

        consulta += " DECLARE @mes int, @año int "
        consulta += " set @mes=month('" + FechaInicio.ToShortDateString + "' )"
        consulta += " set @año=year('" + FechaInicio.ToShortDateString + "' )"

        consulta += "  IF OBJECT_ID ('tempdb.dbo.#tmpCompras') is not null BEGIN" +
                    "   DROP TABLE #tmpCompras;" +
                    " End" +
                    " create table #tmpCompras( PolizaSAYID varchar(5), PolizaContpaqID varchar(5), Movimiento varchar(5), Cuenta varchar(5), Proveedor varchar(200),    " +
                    " 	Cargos money,Abonos money, Fecha smalldatetime, Referencia varchar(50), Nave int, proveedorSicyID int, IVA money, Subtotal money, RutaXML varchar(500)," +
                    " 	Rfc varchar(50), Uuid varchar(5), Serie varchar(5), Folio varchar(5), RutaPDF varchar(500), compraSICYID int, TipoMovimiento int, bandera varchar(5), " +
                    " 	RespaldoColor varchar(5), TipoCompra varchar(5))" +
                    " INSERT INTO #tmpCompras (PolizaSAYID, PolizaContpaqID, Movimiento, Cuenta, Proveedor, Cargos, Abonos, Fecha, Referencia, Nave, proveedorSicyID, IVA, " +
                    " 	Subtotal, RutaXML, Rfc, Uuid, Serie, Folio, RutaPDF, compraSICYID, TipoMovimiento, bandera, RespaldoColor, TipoCompra)" +
                    " " +
                    " 	SELECT PolizaSAYID, PolizaContpaqID, Movimiento, Cuenta, Proveedor, Cargos, Abonos, Fecha, Referencia, Nave, proveedorSicyID," +
                    " 		IVA,Subtotal,RutaXML,Rfc,Uuid,Serie,Folio,RutaPDF,compraSICYID,TipoMovimiento,bandera,RespaldoColor,TipoCompra" +
                    " 	FROM" +
                    " 	(" +
                    " 	SELECT '' AS 'PolizaSAYID'," +
                    "                     '' AS 'PolizaContpaqID'," +
                    "                     '' AS Movimiento," +
                    "                     '' AS Cuenta," +
                    " 		RTRIM(p.RazonSocial) AS Proveedor," +
                    "                     '' AS Cargos," +
                    " 		cxps.IMPDOCTO AS Abonos," +
                    " 		CONVERT(varchar(10), cxps.FECDOCTO, 103) AS Fecha," +
                    " 		cxps.NUMDOCTO AS Referencia," +
                    " 		cxpm.NAVE AS Nave," +
                    " 		p.IdProveedor AS proveedorSicyID," +
                    " 		cxps.IMPIVA AS IVA," +
                    " 		cxps.SUBTOT AS Subtotal," +
                    " 		cf.cfdRutaXml AS RutaXML," +
                    " 		p.RFC AS Rfc," +
                    "                     '' AS Uuid," +
                    "                     '' AS Serie," +
                    "                      '' AS Folio," +
                    " 		cf.cfdRutaVisor AS RutaPDF," +
                    " 		IDTABLA AS 'compraSICYID'," +
                    "                     '1' AS 'TipoMovimiento'," +
                    "                     '' AS bandera," +
                    "                     '' AS RespaldoColor," +
                    " 		DBO.TipoPolizaCompra(cxps.IDTABLA) TipoCompra" +
                    " 	FROM CxPSALDOS cxps" +
                    " 	INNER JOIN Proveedores p ON p.IdProveedor = cxps.CVEPROV" +
                    " 	INNER JOIN CxPMOVIMIENTOS cxpm ON cxpm.CVEPROV = cxps.CVEPROV AND cxpm.NUMDOCTO = cxps.NUMDOCTO AND cxpm.AÑOSEMANA = cxps.AÑOSEMPAGO AND cxpm.SEMANA = cxps.SEMPAGO" +
                    " 	LEFT JOIN CFDS AS cf ON cf.cfdId = cxps.IdComprobante" +
                    " 	WHERE cxps.IDRAZSOC IN (" + contribuyentesID.ToString + ")" +
                    " 	AND cxps.FECDOCTO BETWEEN '" + FechaInicio.ToShortDateString + " 00:00:00' AND '" + FechaFin.ToShortDateString + " 23:59:00'"
        If operaciones.Servidor = operacionesSAY.Servidor Then
            consulta += " 	AND cxps.IDTABLA NOT IN (SELECT pomo_compraid FROM [" + operacionesSAY.NombreDB + "].[Contabilidad].[PolizaMovimientos]   where pomo_fecha BETWEEN " +
                        "(select '01/' + cast(@mes as varchar(5)) + '/' + cast(@año as varchar(5)) as fecha) and (SELECT (select convert(DATE,dateadd(ms,-3,DATEADD(mm, DATEDIFF(m,0,'" + FechaInicio.ToShortDateString + "')+1, 0)),112))))"
        Else
            consulta += " 	AND cxps.IDTABLA NOT IN (SELECT pomo_compraid FROM  [" + operacionesSAY.Servidor + "].[" + operacionesSAY.NombreDB + "].[Contabilidad].[PolizaMovimientos]   where pomo_fecha BETWEEN " +
                        "(select '01/' + cast(@mes as varchar(5)) + '/' + cast(@año as varchar(5)) as fecha) and (SELECT (select convert(DATE,dateadd(ms,-3,DATEADD(mm, DATEDIFF(m,0,'" + FechaInicio.ToShortDateString + "')+1, 0)),112))))"
        End If

        consulta += " 	AND cxps.IdComprobante > 0" +
                    " 	GROUP BY  p.RazonSocial,cxps.IMPDOCTO,cxps.FECDOCTO,cxps.NUMDOCTO,cxpm.NAVE,p.IdProveedor,cxps.IMPIVA,cxps.SUBTOT," +
                    " 		cf.cfdRutaXml,p.RFC,cf.cfdRutaVisor,IDTABLA	" +
                    " 	) " +
                    " 	AS tabla" +
                    " " +
                    " DELETE FROM #tmpCompras" +
                    " WHERE TipoCompra <> 'AF'" +
                    " " +
                    " SELECT" +
                    " 	Movimiento," +
                    " 	a.Cuenta," +
                    " 	Proveedor," +
                    " 	b.IMPORT AS Cargos," +
                    " 	Abonos," +
                    " 	STUFF(LOWER(mt.Descripcion1), 1, 1,UPPER(left(LOWER(mt.Descripcion1),1))) AS Concepto," +
                    " 	Fecha," +
                    " 	Referencia," +
                    " 	PolizaSAYID," +
                    " 	PolizaContpaqID," +
                    " 	Nave," +
                    " 	proveedorSicyID," +
                    " 	IVA," +
                    " 	0.0 AS subtotal," +
                    " 	RutaXML," +
                    " 	Rfc," +
                    " 	Uuid," +
                    " 	Serie," +
                    " 	Folio," +
                    " 	RutaPDF," +
                    " 	compraSICYID," +
                    " 	TipoMovimiento," +
                    " 	bandera," +
                    " 	RespaldoColor," +
                    " 	TipoCompra," +
                    " 	ISNULL(REPLACE(c.Cuenta, '-', ''), '') CuentaMaterial," +
                    " 	ISNULL(d.Descripcion, '') DescripcionCuentaMaterial," +
                    " 	ISNULL(c.Descripcion, '') descripcionCuenta," +
                    "                         '' AS cuentaSAYID" +
                    " FROM #tmpCompras a" +
                    " INNER JOIN RecepcionOrdenes b ON a.proveedorSicyID = b.CVEPRV AND a.Referencia = b.NUMFAC AND b.TIPDOC = 1 AND year(b.FECFAC) = @año" +
                    " LEFT JOIN Materiales AS mt ON b.CVEMAT = mt.IdMaterial" +
                    " LEFT JOIN CuentasContabilidad c ON b.CVEMAT = c.ClaveSicy AND c.IdEmpresaSicy = " + DoctosVentas.ToString + " AND a.Nave = c.IdAlmacen" +
                    " LEFT JOIN ctbCuentasContabilidadGastosCompras d ON REPLACE(c.Cuenta, '-', '') = d.cuenta" +
                    " ORDER BY a.Referencia"

        Return operaciones.EjecutaConsulta(consulta)
    End Function
#End Region

#Region "CARGAR GRID NOTAS DE CREDITO"
    Public Function CargaGridPolizaNoteasDeCredito(ByVal RazSoc As String, ByVal FechaDe As String, ByVal FechaA As String, ByVal empresaID As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim operacionesSAY As New Persistencia.OperacionesProcedimientos

        Dim consulta As String

        consulta = <consulta>
                        SELECT
	                        '' 'Movimiento', '' 'Cuenta',
	                        CONS.Cliente, CONS.ClienteID, cTipoCliente AS 'TipoCliente', sum(CONS.Cargos) as 'Cargos',CONS.TOTAL, SUM(CONS.Abonos) AS 'Abonos', CONS.IVA,
	                        '' 'Nombre de la Cuenta', '' 'Concepto',
	                        CONS.Subtotal, CONS.Fecha,
	                        '' 'UUID', '' 'Serie', '' 'Folio',
	                        CONS.Referencia, '' 'RespaldoColor', '' 'bandera',
	                        CONS.rutaXML, CONS.rutaPDF, CONS.RFC, CONS.IdNotaCredito,
	                        '' AS 'cuentaSAYID',
	                        CONS.CuentaNotaCredito, CONS.DescripcionCuenta,
	                        '' 'PolizaSAYID', '' 'PolizaContpaqID', CONS.TipoMovimiento,
	                        CONS.Concepto_NotaCredito, CONS.FACTURA
                        FROM  ( 
                        --=======================================================================================================================================
                        --CLIENTES NACIONALES
                        --=======================================================================================================================================
                        ----CARGOS PARA CLIENTES NACIONALES
                        SELECT * FROM (
                        SELECT * FROM ( SELECT cte.nombre 'Cliente', 
	                        cte.IdCliente AS 'ClienteID', CTE.cTipoCliente,
	                        SUM(ncd.importe - ncd.ImporteDescuento) AS 'Cargos', 
	                        nc.Total AS 'TOTAL',
	                        0 AS 'Abonos',
	                        nc.IVA AS 'IVA',
	                        nc.Subtotal AS 'Subtotal',
	                        cc.Concepto AS 'Nombre de la Cuenta',
	                        cc.Concepto AS 'Concepto',
	                        nc.FechaRegistro 'Fecha',
	                        ('NCR-' + nc.cnSerie + CONVERT(varchar, nc.Folio)) Referencia,
	                        de.RutaXML rutaXML,
	                        de.RutaPDF rutaPDF,
	                        REPLACE(RTRIM(LTRIM(cte.rfc)), '-', '') RFC,
	                        nc.IdNotaCredito,
	                        ISNULL(REPLACE(co.Cuenta, '-', ''), '') CuentaNotaCredito,
	                        ISNULL(co.Descripcion, '') DescripcionCuenta,
	                        nc.Concepto AS 'Concepto_NotaCredito',
	                        '' AS 'FACTURA', 
	                        '0' AS 'TipoMovimiento'
                        FROM cxcNotasCredito AS nc
                        JOIN cxcNotasCreditoDetalles AS ncd ON nc.IdNotaCredito = ncd.IdNotaCredito
                        JOIN DoctosElectronicos AS de ON de.IdDocto = nc.IdNotaCredito AND de.TipoDocto = 'NCR'
                        JOIN Clientes AS cte ON nc.IdCliente = cte.IdCliente  AND (LTRIM(RTRIM(cte.cTipoCliente)) = 'NACIONAL')
                        JOIN cxcconceptoscobranza AS cc ON cc.idconcepto = ncd.idconcepto AND cc.DOCUMENTO = 'CREDITO'
                        LEFT JOIN CUENTASCONTABILIDAD CO ON CC.IDCONCEPTO = CO.CLAVESICY AND CO.IDTIPO = 4 AND IdEmpresaSicy = <%= RazSoc.ToString %>
                        JOIN VENTAS AS VE ON VE.IdRemision = NCD.IdRemision AND VE.Año = NCD.Año
                        WHERE nc.FechaRegistro BETWEEN CONVERT(datetime, '<%= FechaDe.ToString %> 00:00', 103) AND CONVERT(datetime, ' <%= FechaA.ToString %> 23:00', 103)
                        AND de.Estatus NOT IN ('CANCELADO')
	                    AND nc.IdDocumento is not null
                          </consulta>.Value

        If operaciones.Servidor = operacionesSAY.Servidor Then
            consulta += <Consulta>
                        AND nc.IdDocumento = (  select essc_doctoventassicyid 
                                                from [<%= operacionesSAY.NombreDB %>].Framework.empresaSaySicyContpaq 
                                                where essc_sayid = <%= empresaID.ToString %>)
                        </Consulta>.Value

        Else
            consulta += <Consulta>
                        AND nc.IdDocumento = (  select essc_doctoventassicyid 
                                                from [<%= operacionesSAY.Servidor %>].[<%= operacionesSAY.NombreDB %>].Framework.empresaSaySicyContpaq 
                                                where essc_sayid = <%= empresaID.ToString %>)
                        </Consulta>.Value
        End If

        consulta += <Consulta>
                        AND nc.IdNotaCredito NOT IN (SELECT * from contabilidad.vPolizasSay )
                        GROUP BY cte.nombre, cte.IdCliente, CTE.cTipoCliente, nc.Total, nc.IVA, nc.Subtotal, cc.Concepto, nc.FechaRegistro, nc.cnSerie, nc.Folio, de.RutaXML, de.RutaPDF,cte.rfc,nc.IdNotaCredito,co.Cuenta
	                        , co.Descripcion,nc.Concepto
                        UNION
                        --------------------------------ABONOS PARA CLIENTES NACIONALES
                        SELECT cte.nombre 'Cliente', 
	                        cte.IdCliente AS 'ClienteID', CTE.cTipoCliente,
	                        0 AS 'Cargos', 
	                        nc.Total AS 'TOTAL',
	                        ROUND(((SELECT (ncdd.importe - ncdd.ImporteDescuento) FROM cxcNotasCreditoDetalles AS ncdd WHERE ncdd.IdDetalle = ncd.iddetalle) * (1 + nc.cnpIVA)), 2) AS 'Abonos',
	                        nc.IVA AS 'IVA',
	                        nc.Subtotal AS 'Subtotal',
	                        cc.Concepto AS 'Nombre de la Cuenta',
	                        cc.Concepto AS 'Concepto',
	                        nc.FechaRegistro 'Fecha',
	                        ('NCR-' + nc.cnSerie + CONVERT(varchar, nc.Folio)) Referencia,
	                        de.RutaXML rutaXML,
	                        de.RutaPDF rutaPDF,
	                        REPLACE(RTRIM(LTRIM(cte.rfc)), '-', '') RFC,
	                        nc.IdNotaCredito,
	                        ISNULL(REPLACE(co.Cuenta, '-', ''), '') CuentaNotaCredito,
	                        ISNULL(co.Descripcion, '') DescripcionCuenta,
	                        nc.Concepto AS 'Concepto_NotaCredito',
	                        (SELECT 'FA-' + DD.serie + CAST(DD.Folio AS varchar(max)) 
		                        FROM Ventas AS VV 
		                        INNER JOIN DoctosElectronicos dD ON vV.IdRemision = Dd.IdDocto 
		                        AND CONVERT(date, Vv.FechaFE) = CONVERT(date, dD.Fecha) 
	                        WHERE VV.IdRemision = VE.IdRemision AND VV.Año = VE.Año) AS 'FACTURA',
	                        '1' as 'TipoMovimiento'
                        FROM cxcNotasCredito AS nc
                        JOIN cxcNotasCreditoDetalles AS ncd ON nc.IdNotaCredito = ncd.IdNotaCredito
                        JOIN DoctosElectronicos AS de ON de.IdDocto = nc.IdNotaCredito AND de.TipoDocto = 'NCR'
                        JOIN Clientes AS cte ON nc.IdCliente = cte.IdCliente  AND (LTRIM(RTRIM(cte.cTipoCliente)) = 'NACIONAL')
                        JOIN cxcconceptoscobranza AS cc ON cc.idconcepto = ncd.idconcepto AND cc.DOCUMENTO = 'CREDITO'
                        LEFT JOIN CUENTASCONTABILIDAD CO ON CC.IDCONCEPTO = CO.CLAVESICY AND CO.IDTIPO = 4 AND IdEmpresaSicy =  <%= RazSoc.ToString %>
                        JOIN VENTAS AS VE ON VE.IdRemision = NCD.IdRemision AND VE.Año = NCD.Año
                        WHERE nc.FechaRegistro BETWEEN CONVERT(datetime, ' <%= FechaDe.ToString %> 00:00', 103) AND CONVERT(datetime, ' <%= FechaA.ToString %> 23:00', 103)
                        AND de.Estatus NOT IN ('CANCELADO')
	                    AND nc.IdDocumento is not null
</Consulta>.Value

        If operaciones.Servidor = operacionesSAY.Servidor Then
            consulta += <Consulta>
                        AND nc.IdDocumento = (  select essc_doctoventassicyid 
                                                from [<%= operacionesSAY.NombreDB %>].Framework.empresaSaySicyContpaq 
                                                where essc_sayid = <%= empresaID.ToString %>)
                        </Consulta>.Value

        Else
            consulta += <Consulta>
                        AND nc.IdDocumento = (  select essc_doctoventassicyid 
                                                from [<%= operacionesSAY.Servidor %>].[<%= operacionesSAY.NombreDB %>].Framework.empresaSaySicyContpaq 
                                                where essc_sayid = <%= empresaID.ToString %>)
                        </Consulta>.Value
        End If

        consulta += <Consulta>
                        AND nc.IdNotaCredito NOT IN (SELECT * from contabilidad.vPolizasSay )
                        ) AS PRIMERA
                        union
                        --=======================================================================================================================================
                        --CLIENTES EXTRANJEROS
                        --=======================================================================================================================================
                        -----------------------------CARGOS-----------------------------------------------------------------------------------------------------
                        SELECT * FROM ( SELECT cte.nombre 'Cliente', 
	                        cte.IdCliente AS 'ClienteID', CTE.cTipoCliente,
	                        (SUM(ncd.importe - ncd.ImporteDescuento))   AS 'Cargos', 
	                        nc.Total AS 'TOTAL',
	                        0 AS 'Abonos',
	                        0 AS 'IVA',
	                        nc.Subtotal AS 'Subtotal',
	                        cc.Concepto AS 'Nombre de la Cuenta',
	                        cc.Concepto AS 'Concepto',
	                        nc.FechaRegistro 'Fecha',
	                        ('NCR-' + nc.cnSerie + CONVERT(varchar, nc.Folio)) Referencia,
	                        de.RutaXML rutaXML,
	                        de.RutaPDF rutaPDF,
	                        REPLACE(RTRIM(LTRIM(cte.rfc)), '-', '') RFC,
	                        nc.IdNotaCredito,
	                        ISNULL(REPLACE(co.Cuenta, '-', ''), '') CuentaNotaCredito,
	                        ISNULL(co.Descripcion, '') DescripcionCuenta,
	                        nc.Concepto AS 'Concepto_NotaCredito',
	                       '' AS 'FACTURA', 
	                        '0' AS 'TipoMovimiento'
                        FROM cxcNotasCredito AS nc
                        JOIN cxcNotasCreditoDetalles AS ncd ON nc.IdNotaCredito = ncd.IdNotaCredito
                        JOIN DoctosElectronicos AS de ON de.IdDocto = nc.IdNotaCredito AND de.TipoDocto = 'NCR'
                        JOIN Clientes AS cte ON nc.IdCliente = cte.IdCliente  AND (LTRIM(RTRIM(cte.cTipoCliente)) = 'EXTRANJERO')
                        JOIN cxcconceptoscobranza AS cc ON cc.idconcepto = ncd.idconcepto AND cc.DOCUMENTO = 'CREDITO'
                        LEFT JOIN CUENTASCONTABILIDAD CO ON CC.IDCONCEPTO = CO.CLAVESICY AND CO.IDTIPO = 4 AND IdEmpresaSicy = <%= RazSoc.ToString %>
                        JOIN VENTAS AS VE ON VE.IdRemision = NCD.IdRemision AND VE.Año = NCD.Año
                        WHERE nc.FechaRegistro BETWEEN CONVERT(datetime, ' <%= FechaDe.ToString %> 00:00', 103) AND CONVERT(datetime, ' <%= FechaA.ToString %> 23:00', 103)
                        AND de.Estatus NOT IN ('CANCELADO')
	                    AND nc.IdDocumento is not null
          </Consulta>.Value

        If operaciones.Servidor = operacionesSAY.Servidor Then
            consulta += <Consulta>
                        AND nc.IdDocumento = (  select essc_doctoventassicyid 
                                                from [<%= operacionesSAY.NombreDB %>].Framework.empresaSaySicyContpaq 
                                                where essc_sayid = <%= empresaID.ToString %>)
                        </Consulta>.Value

        Else
            consulta += <Consulta>
                        AND nc.IdDocumento = (  select essc_doctoventassicyid 
                                                from [<%= operacionesSAY.Servidor %>].[<%= operacionesSAY.NombreDB %>].Framework.empresaSaySicyContpaq 
                                                where essc_sayid = <%= empresaID.ToString %>)
                        </Consulta>.Value
        End If

        consulta += <Consulta>
                        AND nc.IdMoneda = 1                       
                        AND nc.IdNotaCredito NOT IN (SELECT * from contabilidad.vPolizasSay )
                        GROUP BY cte.nombre, cte.IdCliente,CTE.cTipoCliente, nc.Total, nc.IVA, nc.Subtotal, cc.Concepto, nc.FechaRegistro, nc.cnSerie, nc.Folio, de.RutaXML, de.RutaPDF,cte.rfc,nc.IdNotaCredito,co.Cuenta
	                        , co.Descripcion,nc.Concepto, nc.IdMoneda
                        UNION
                        -----------------------------ABONOS-----------------------------------------------------------------------------------------------------
                        SELECT cte.nombre 'Cliente', 
	                        cte.IdCliente AS 'ClienteID', CTE.cTipoCliente,
	                        0 AS 'Cargos', 
	                        nc.Total AS 'TOTAL',
	                        ROUND(((SELECT (ncdd.importe - ncdd.ImporteDescuento) FROM cxcNotasCreditoDetalles AS ncdd WHERE ncdd.IdDetalle = ncd.iddetalle) * (1 + nc.cnpIVA)), 2) AS 'Abonos',
	                        0 AS 'IVA',
	                        nc.Subtotal AS 'Subtotal',
	                        cc.Concepto AS 'Nombre de la Cuenta',
	                        cc.Concepto AS 'Concepto',
	                        nc.FechaRegistro 'Fecha',
	                        ('NCR-' + nc.cnSerie + CONVERT(varchar, nc.Folio)) Referencia,
	                        de.RutaXML rutaXML,
	                        de.RutaPDF rutaPDF,
	                        REPLACE(RTRIM(LTRIM(cte.rfc)), '-', '') RFC,
	                        nc.IdNotaCredito,
	                        ISNULL(REPLACE(co.Cuenta, '-', ''), '') CuentaNotaCredito,
	                        ISNULL(co.Descripcion, '') DescripcionCuenta,
	                        nc.Concepto AS 'Concepto_NotaCredito',
	                        (SELECT 'FA-' + DD.serie + CAST(DD.Folio AS varchar(max)) 
		                        FROM Ventas AS VV 
		                        INNER JOIN DoctosElectronicos dD ON vV.IdRemision = Dd.IdDocto 
		                        AND CONVERT(date, Vv.FechaFE) = CONVERT(date, dD.Fecha) 
	                        WHERE VV.IdRemision = VE.IdRemision AND VV.Año = VE.Año) AS 'FACTURA',
	                        '1' as 'TipoMovimiento'
                        FROM cxcNotasCredito AS nc
                        JOIN cxcNotasCreditoDetalles AS ncd ON nc.IdNotaCredito = ncd.IdNotaCredito
                        JOIN DoctosElectronicos AS de ON de.IdDocto = nc.IdNotaCredito AND de.TipoDocto = 'NCR'
                        JOIN Clientes AS cte ON nc.IdCliente = cte.IdCliente  AND (LTRIM(RTRIM(cte.cTipoCliente)) = 'EXTRANJERO')
                        JOIN cxcconceptoscobranza AS cc ON cc.idconcepto = ncd.idconcepto AND cc.DOCUMENTO = 'CREDITO'
                        LEFT JOIN CUENTASCONTABILIDAD CO ON CC.IDCONCEPTO = CO.CLAVESICY AND CO.IDTIPO = 4 AND IdEmpresaSicy =  <%= RazSoc.ToString %>
                        JOIN VENTAS AS VE ON VE.IdRemision = NCD.IdRemision AND VE.Año = NCD.Año
                        WHERE nc.FechaRegistro BETWEEN CONVERT(datetime, ' <%= FechaDe.ToString %> 00:00', 103) AND CONVERT(datetime, ' <%= FechaA.ToString %> 23:00', 103)
                        AND de.Estatus NOT IN ('CANCELADO')
	                    AND nc.IdDocumento is not null
                        AND nc.IdMoneda = 1
                         </Consulta>.Value

        If operaciones.Servidor = operacionesSAY.Servidor Then
            consulta += <Consulta>
                        AND nc.IdDocumento = (  select essc_doctoventassicyid 
                                                from [<%= operacionesSAY.NombreDB %>].Framework.empresaSaySicyContpaq 
                                                where essc_sayid = <%= empresaID.ToString %>)
                        </Consulta>.Value

        Else
            consulta += <Consulta>
                        AND nc.IdDocumento = (  select essc_doctoventassicyid 
                                                from [<%= operacionesSAY.Servidor %>].[<%= operacionesSAY.NombreDB %>].Framework.empresaSaySicyContpaq 
                                                where essc_sayid = <%= empresaID.ToString %>)
                        </Consulta>.Value
        End If

        consulta += <Consulta>
                        AND nc.IdNotaCredito NOT IN (SELECT * from contabilidad.vPolizasSay )
                        ) AS SEGUNDA ) AS FINAL  ) AS CONS 
                        GROUP BY	CONS.Cliente,
			                        CONS.ClienteID,
                                    cons.cTipoCliente,
			                        CONS.TOTAL,
			                        CONS.IVA,
			                        CONS.Subtotal,
			                        CONS.Fecha,
			                        CONS.Referencia,
			                        CONS.TipoMovimiento,
			                        CONS.rutaXML,
			                        CONS.rutaPDF,
			                        CONS.RFC,
			                        CONS.IdNotaCredito,
			                        CONS.CuentaNotaCredito,
			                        CONS.DescripcionCuenta,
			                        CONS.Concepto_NotaCredito,
			                        CONS.FACTURA
                        ORDER BY  CONS.Fecha ASC, CONS.Referencia, CONS.TipoMovimiento asc,CONS.CLIENTE
                    </Consulta>.Value

        Return operaciones.EjecutaConsulta(consulta)
    End Function

#End Region

#Region "CARGAR GRID NOTAS DE CREDITO CANCELADAS"
    Public Function CargaGridPolizaNoteasDeCredito_Canceladas(ByVal RazSoc As String, ByVal FechaDe As String, ByVal FechaA As String, ByVal empresaID As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim operacionesSAY As New Persistencia.OperacionesProcedimientos

        Dim consulta As String

        consulta = <consulta>
            SELECT
	            '' 'Movimiento', '' 'Cuenta',
	            CONS.Cliente, CONS.ClienteID, cTipoCliente AS 'TipoCliente', sum(CONS.Cargos) as 'Cargos',CONS.TOTAL, SUM(CONS.Abonos) AS 'Abonos', CONS.IVA,
	            '' 'Nombre de la Cuenta', '' 'Concepto',
	            CONS.Subtotal, CONS.Fecha,
	            '' 'UUID', '' 'Serie', '' 'Folio',
	            CONS.Referencia, '' 'RespaldoColor', '' 'bandera',
	            CONS.rutaXML, CONS.rutaPDF, CONS.RFC, CONS.IdNotaCredito,
	            '' AS 'cuentaSAYID',
	            CONS.CuentaNotaCredito, CONS.DescripcionCuenta,
	            '' 'PolizaSAYID', '' 'PolizaContpaqID', CONS.TipoMovimiento,
	            CONS.Concepto_NotaCredito, CONS.FACTURA
            FROM  ( 
            --=======================================================================================================================================
            --CLIENTES NACIONALES
            --=======================================================================================================================================
            ----CARGOS PARA CLIENTES NACIONALES
		        SELECT * FROM (
		        SELECT * FROM ( 
		        --------------------------------ABONOS PARA CLIENTES NACIONALES
		        SELECT cte.nombre 'Cliente', 
			        cte.IdCliente AS 'ClienteID', CTE.cTipoCliente,
			        ROUND(((SELECT (ncdd.importe - ncdd.ImporteDescuento) FROM cxcNotasCreditoDetalles AS ncdd WHERE ncdd.IdDetalle = ncd.iddetalle) * (1 + nc.cnpIVA)), 2) AS 'Cargos', 
			        nc.Total AS 'TOTAL',
			        0 AS 'Abonos',
			        nc.IVA AS 'IVA',
			        nc.Subtotal AS 'Subtotal',
			        cc.Concepto AS 'Nombre de la Cuenta',
			        cc.Concepto AS 'Concepto',
			        nc.cnFechaCancelacion 'Fecha',
			        ('NCR-' + nc.cnSerie + CONVERT(varchar, nc.Folio)) Referencia,
			        de.RutaXML rutaXML,
			        de.RutaPDF rutaPDF,
			        REPLACE(RTRIM(LTRIM(cte.rfc)), '-', '') RFC,
			        nc.IdNotaCredito,
			        ISNULL(REPLACE(co.Cuenta, '-', ''), '') CuentaNotaCredito,
			        ISNULL(co.Descripcion, '') DescripcionCuenta,
			        nc.Concepto AS 'Concepto_NotaCredito',
			        (SELECT 'FA-' + DD.serie + CAST(DD.Folio AS varchar(max)) 
				        FROM Ventas AS VV 
				        INNER JOIN DoctosElectronicos dD ON vV.IdRemision = Dd.IdDocto 
				        AND CONVERT(date, Vv.FechaFE) = CONVERT(date, dD.Fecha) 
			        WHERE VV.IdRemision = VE.IdRemision AND VV.Año = VE.Año) AS 'FACTURA',
			        '0' as 'TipoMovimiento'
		        FROM cxcNotasCredito AS nc
		        JOIN cxcNotasCreditoDetalles AS ncd ON nc.IdNotaCredito = ncd.IdNotaCredito
		        JOIN DoctosElectronicos AS de ON de.IdDocto = ncd.IdNotaCredito AND de.TipoDocto = 'NCR'
		        JOIN Clientes AS cte ON nc.IdCliente = cte.IdCliente  AND (LTRIM(RTRIM(cte.cTipoCliente)) = 'NACIONAL')
		        JOIN cxcconceptoscobranza AS cc ON cc.idconcepto = ncd.idconcepto AND cc.DOCUMENTO = 'CREDITO'
		        LEFT JOIN CUENTASCONTABILIDAD CO ON CC.IDCONCEPTO = CO.CLAVESICY AND CO.IDTIPO = 4 AND IdEmpresaSicy =  <%= RazSoc.ToString %>
		        JOIN VENTAS AS VE ON VE.IdRemision = NCD.IdRemision AND VE.Año = NCD.Año
		        WHERE nc.cnFechaCancelacion BETWEEN CONVERT(datetime, '<%= FechaDe %> 00:00', 103) AND CONVERT(datetime, '<%= FechaA %> 23:00', 103)
		        AND de.Estatus NOT IN ('CANCELADO')
		         </consulta>.Value

        If operaciones.Servidor = operacionesSAY.Servidor Then
            consulta += <Consulta>
                        AND nc.IdDocumento = (  select essc_doctoventassicyid 
                                                from [<%= operacionesSAY.NombreDB %>].Framework.empresaSaySicyContpaq 
                                                where essc_sayid = <%= empresaID.ToString %>)
                        </Consulta>.Value

        Else
            consulta += <Consulta>
                        AND nc.IdDocumento = (  select essc_doctoventassicyid 
                                                from [<%= operacionesSAY.Servidor %>].[<%= operacionesSAY.NombreDB %>].Framework.empresaSaySicyContpaq 
                                                where essc_sayid = <%= empresaID.ToString %>)
                        </Consulta>.Value
        End If

        consulta += <Consulta>
		        and nc.Estatus = 'C'
		        AND nc.IdNotaCredito NOT IN (SELECT * from contabilidad.vPolizasSay_NotasCreditoCanceladas )
		        UNION
		        SELECT cte.nombre 'Cliente', 
			        cte.IdCliente AS 'ClienteID', CTE.cTipoCliente,
			        0 as 'Cargos', 
			        nc.Total AS 'TOTAL',
			        SUM(ncd.importe - ncd.ImporteDescuento)  AS 'Abonos',
			        nc.IVA AS 'IVA',
			        nc.Subtotal AS 'Subtotal',
			        cc.Concepto AS 'Nombre de la Cuenta',
			        cc.Concepto AS 'Concepto',
			        nc.cnFechaCancelacion 'Fecha',
			        ('NCR-' + nc.cnSerie + CONVERT(varchar, nc.Folio)) Referencia,
			        de.RutaXML rutaXML,
			        de.RutaPDF rutaPDF,
			        REPLACE(RTRIM(LTRIM(cte.rfc)), '-', '') RFC,
			        nc.IdNotaCredito,
			        ISNULL(REPLACE(co.Cuenta, '-', ''), '') CuentaNotaCredito,
			        ISNULL(co.Descripcion, '') DescripcionCuenta,
			        nc.Concepto AS 'Concepto_NotaCredito',
			        '' AS 'FACTURA', 
			        '1' AS 'TipoMovimiento'
		        FROM cxcNotasCredito AS nc
		        JOIN cxcNotasCreditoDetalles AS ncd ON nc.IdNotaCredito = ncd.IdNotaCredito
		        JOIN DoctosElectronicos AS de ON de.IdDocto = ncd.IdNotaCredito AND de.TipoDocto = 'NCR'
		        JOIN Clientes AS cte ON nc.IdCliente = cte.IdCliente  AND (LTRIM(RTRIM(cte.cTipoCliente)) = 'NACIONAL')
		        JOIN cxcconceptoscobranza AS cc ON cc.idconcepto = ncd.idconcepto AND cc.DOCUMENTO = 'CREDITO'
		        LEFT JOIN CUENTASCONTABILIDAD CO ON CC.IDCONCEPTO = CO.CLAVESICY AND CO.IDTIPO = 4 AND IdEmpresaSicy = <%= RazSoc.ToString %>
		        JOIN VENTAS AS VE ON VE.IdRemision = NCD.IdRemision AND VE.Año = NCD.Año
		        WHERE nc.cnFechaCancelacion BETWEEN CONVERT(datetime, '<%= FechaDe %> 00:00', 103) AND CONVERT(datetime, '<%= FechaA %> 23:00', 103)
		        AND de.Estatus NOT IN ('CANCELADO')
            </Consulta>.Value

        If operaciones.Servidor = operacionesSAY.Servidor Then
            consulta += <Consulta>
                        AND nc.IdDocumento = (  select essc_doctoventassicyid 
                                                from [<%= operacionesSAY.NombreDB %>].Framework.empresaSaySicyContpaq 
                                                where essc_sayid = <%= empresaID.ToString %>)
                        </Consulta>.Value

        Else
            consulta += <Consulta>
                        AND nc.IdDocumento = (  select essc_doctoventassicyid 
                                                from [<%= operacionesSAY.Servidor %>].[<%= operacionesSAY.NombreDB %>].Framework.empresaSaySicyContpaq 
                                                where essc_sayid = <%= empresaID.ToString %>)
                        </Consulta>.Value
        End If

        consulta += <Consulta>
		        and nc.Estatus = 'C'
		        AND nc.IdNotaCredito NOT IN (SELECT * from contabilidad.vPolizasSay_NotasCreditoCanceladas )
		        GROUP BY cte.nombre, cte.IdCliente, CTE.cTipoCliente, nc.Total, nc.IVA, nc.Subtotal, cc.Concepto, nc.cnFechaCancelacion, nc.cnSerie, nc.Folio, de.RutaXML, de.RutaPDF,cte.rfc,nc.IdNotaCredito,co.Cuenta
			        , co.Descripcion,nc.Concepto
		        ) AS PRIMERA
        union
		        --=======================================================================================================================================
		        --CLIENTES EXTRANJEROS
		        --=======================================================================================================================================
		        -----------------------------ABONOS-----------------------------------------------------------------------------------------------------
                Select cte.nombre 'Cliente', 
			        cte.IdCliente AS 'ClienteID', CTE.cTipoCliente,
			        ROUND(((SELECT (ncdd.importe - ncdd.ImporteDescuento) FROM cxcNotasCreditoDetalles AS ncdd WHERE ncdd.IdDetalle = ncd.iddetalle) * (1 + nc.cnpIVA)), 2) AS 'Cargos', 
			        nc.Total AS 'TOTAL',
			        0 AS 'Abonos',
			        0 AS 'IVA',
			        nc.Subtotal AS 'Subtotal',
			        cc.Concepto AS 'Nombre de la Cuenta',
			        cc.Concepto AS 'Concepto',
			        nc.cnFechaCancelacion 'Fecha',
			        ('NCR-' + nc.cnSerie + CONVERT(varchar, nc.Folio)) Referencia,
			        de.RutaXML rutaXML,
			        de.RutaPDF rutaPDF,
			        REPLACE(RTRIM(LTRIM(cte.rfc)), '-', '') RFC,
			        nc.IdNotaCredito,
			        ISNULL(REPLACE(co.Cuenta, '-', ''), '') CuentaNotaCredito,
			        ISNULL(co.Descripcion, '') DescripcionCuenta,
			        nc.Concepto AS 'Concepto_NotaCredito',
			        (SELECT 'FA-' + DD.serie + CAST(DD.Folio AS varchar(max)) 
				        FROM Ventas AS VV 
				        INNER JOIN DoctosElectronicos dD ON vV.IdRemision = Dd.IdDocto 
				        AND CONVERT(date, Vv.FechaFE) = CONVERT(date, dD.Fecha) 
			        WHERE VV.IdRemision = VE.IdRemision AND VV.Año = VE.Año) AS 'FACTURA',
            '0' as 'TipoMovimiento'
		        FROM cxcNotasCredito AS nc
		        JOIN cxcNotasCreditoDetalles AS ncd ON nc.IdNotaCredito = ncd.IdNotaCredito
		        JOIN DoctosElectronicos AS de ON de.IdDocto = ncd.IdNotaCredito AND de.TipoDocto = 'NCR'
		        JOIN Clientes AS cte ON nc.IdCliente = cte.IdCliente  AND (LTRIM(RTRIM(cte.cTipoCliente)) = 'EXTRANJERO')
		        JOIN cxcconceptoscobranza AS cc ON cc.idconcepto = ncd.idconcepto AND cc.DOCUMENTO = 'CREDITO'
		        LEFT JOIN CUENTASCONTABILIDAD CO ON CC.IDCONCEPTO = CO.CLAVESICY AND CO.IDTIPO = 4 AND IdEmpresaSicy =  <%= RazSoc.ToString %>
		        JOIN VENTAS AS VE ON VE.IdRemision = NCD.IdRemision AND VE.Año = NCD.Año
		        WHERE nc.cnFechaCancelacion BETWEEN CONVERT(datetime, '<%= FechaDe %> 00:00', 103) AND CONVERT(datetime, '<%= FechaA %> 23:00', 103)
		        AND de.Estatus NOT IN ('CANCELADO')
		        AND nc.IdMoneda = 1
		        </Consulta>.Value

        If operaciones.Servidor = operacionesSAY.Servidor Then
            consulta += <Consulta>
                        AND nc.IdDocumento = (  select essc_doctoventassicyid 
                                                from [<%= operacionesSAY.NombreDB %>].Framework.empresaSaySicyContpaq 
                                                where essc_sayid = <%= empresaID.ToString %>)
                        </Consulta>.Value

        Else
            consulta += <Consulta>
                        AND nc.IdDocumento = (  select essc_doctoventassicyid 
                                                from [<%= operacionesSAY.Servidor %>].[<%= operacionesSAY.NombreDB %>].Framework.empresaSaySicyContpaq 
                                                where essc_sayid = <%= empresaID.ToString %>)
                        </Consulta>.Value
        End If
        consulta += <Consulta>

                and nc.Estatus = 'C'
		        AND nc.IdNotaCredito NOT IN (SELECT * from contabilidad.vPolizasSay_NotasCreditoCanceladas )
		        UNION
		        -----------------------------CARGOS-----------------------------------------------------------------------------------------------------
		        SELECT * FROM ( SELECT cte.nombre 'Cliente', 
			        cte.IdCliente AS 'ClienteID', CTE.cTipoCliente,
			        0   AS 'Cargos', 
			        nc.Total AS 'TOTAL',
			        (SUM(ncd.importe - ncd.ImporteDescuento)) AS 'Abonos',
			        0 AS 'IVA',
			        nc.Subtotal AS 'Subtotal',
			        cc.Concepto AS 'Nombre de la Cuenta',
			        cc.Concepto AS 'Concepto',
			        nc.cnFechaCancelacion 'Fecha',
			        ('NCR-' + nc.cnSerie + CONVERT(varchar, nc.Folio)) Referencia,
			        de.RutaXML rutaXML,
			        de.RutaPDF rutaPDF,
			        REPLACE(RTRIM(LTRIM(cte.rfc)), '-', '') RFC,
			        nc.IdNotaCredito,
			        ISNULL(REPLACE(co.Cuenta, '-', ''), '') CuentaNotaCredito,
			        ISNULL(co.Descripcion, '') DescripcionCuenta,
			        nc.Concepto AS 'Concepto_NotaCredito',
                '' AS 'FACTURA', 
                '1' AS 'TipoMovimiento'
		        FROM cxcNotasCredito AS nc
		        JOIN cxcNotasCreditoDetalles AS ncd ON nc.IdNotaCredito = ncd.IdNotaCredito
		        JOIN DoctosElectronicos AS de ON de.IdDocto = ncd.IdNotaCredito AND de.TipoDocto = 'NCR'
		        JOIN Clientes AS cte ON nc.IdCliente = cte.IdCliente  AND (LTRIM(RTRIM(cte.cTipoCliente)) = 'EXTRANJERO')
		        JOIN cxcconceptoscobranza AS cc ON cc.idconcepto = ncd.idconcepto AND cc.DOCUMENTO = 'CREDITO'
		        LEFT JOIN CUENTASCONTABILIDAD CO ON CC.IDCONCEPTO = CO.CLAVESICY AND CO.IDTIPO = 4 AND IdEmpresaSicy = <%= RazSoc.ToString %>
		        JOIN VENTAS AS VE ON VE.IdRemision = NCD.IdRemision AND VE.Año = NCD.Año
		        WHERE nc.cnFechaCancelacion BETWEEN CONVERT(datetime, '<%= FechaDe %> 00:00', 103) AND CONVERT(datetime, '<%= FechaA %> 23:00', 103)
		        AND de.Estatus NOT IN ('CANCELADO')
		           </Consulta>.Value

        If operaciones.Servidor = operacionesSAY.Servidor Then
            consulta += <Consulta>
                        AND nc.IdDocumento = (  select essc_doctoventassicyid 
                                                from [<%= operacionesSAY.NombreDB %>].Framework.empresaSaySicyContpaq 
                                                where essc_sayid = <%= empresaID.ToString %>)
                        </Consulta>.Value

        Else
            consulta += <Consulta>
                        AND nc.IdDocumento = (  select essc_doctoventassicyid 
                                                from [<%= operacionesSAY.Servidor %>].[<%= operacionesSAY.NombreDB %>].Framework.empresaSaySicyContpaq 
                                                where essc_sayid = <%= empresaID.ToString %>)
                        </Consulta>.Value
        End If

        consulta += <Consulta>
		        AND nc.IdMoneda = 1
		        and nc.Estatus = 'C'                       
		        AND nc.IdNotaCredito NOT IN (SELECT * from contabilidad.vPolizasSay_NotasCreditoCanceladas )
		        GROUP BY cte.nombre, cte.IdCliente,CTE.cTipoCliente, nc.Total, nc.IVA, nc.Subtotal, cc.Concepto, nc.cnFechaCancelacion, nc.cnSerie, nc.Folio, de.RutaXML, de.RutaPDF,cte.rfc,nc.IdNotaCredito,co.Cuenta
			        , co.Descripcion,nc.Concepto, nc.IdMoneda
	        ) AS SEGUNDA ) AS FINAL  ) AS CONS where CONS.rutaXML not in ('')
            GROUP BY	CONS.Cliente,
			            CONS.ClienteID,
                        cons.cTipoCliente,
			            CONS.TOTAL,
			            CONS.IVA,
			            CONS.Subtotal,
			            CONS.Fecha,
			            CONS.Referencia,
			            CONS.TipoMovimiento,
			            CONS.rutaXML,
			            CONS.rutaPDF,
			            CONS.RFC,
			            CONS.IdNotaCredito,
			            CONS.CuentaNotaCredito,
			            CONS.DescripcionCuenta,
			            CONS.Concepto_NotaCredito,
			            CONS.FACTURA
            ORDER BY  CONS.Fecha ASC, CONS.Referencia, CONS.TipoMovimiento asc,CONS.CLIENTE
                   </Consulta>.Value
        Return operaciones.EjecutaConsulta(consulta)
    End Function
#End Region

#Region "CARGAR GRID NOTAS DE CARGO"
    Public Function CargaGridPolizaNotasDeCargo(ByVal RazSoc As String, ByVal FechaDe As String, ByVal FechaA As String, ByVal empresaID As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim operacionesSAY As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = ""

        If operaciones.Servidor = operacionesSAY.Servidor Then
            consulta += <Consulta>
                        declare @IdEmpresa as integer
                        set @IdEmpresa = (  select essc_doctoventassicyid 
                                                from [<%= operacionesSAY.NombreDB %>].Framework.empresaSaySicyContpaq 
                                                where essc_sayid = <%= empresaID.ToString %>)
                        </Consulta>.Value

        Else
            consulta += <Consulta>
                        declare @IdEmpresa as integer
                        set @IdEmpresa = (  select essc_doctoventassicyid 
                                                from [<%= operacionesSAY.Servidor %>].[<%= operacionesSAY.NombreDB %>].Framework.empresaSaySicyContpaq 
                                                where essc_sayid = <%= empresaID.ToString %>)
                        </Consulta>.Value
        End If


        consulta += " SELECT '' 'Movimiento', '' 'Cuenta', '' 'Nombre de la Cuenta', nc.Total  AS 'Cargos',nc.Subtotal AS 'Abonos'," +
                    "	nc.IVA AS 'IVA', nc.Subtotal AS 'Subtotal', nc.Total AS 'TOTAL',  cc.Concepto AS 'Concepto',cte.nombre 'Cliente', cte.IdCliente AS 'ClienteID', de.fecha 'Fecha'," +
                    "   '' 'UUID', '' 'Serie', '' 'Folio', ('NCR-' + nc.ncSerie + CONVERT(varchar, nc.Folio)) 'Referencia', '' 'RespaldoColor', '' 'bandera', " +
                    "   de.RutaXML 'rutaXML', de.RutaPDF 'rutaPDF', REPLACE(RTRIM(LTRIM(cte.rfc)), '-', '') 'RFC', nc.IdNotaCargo, '' AS 'cuentaSAYID'," +
                    "	ISNULL(REPLACE(co.Cuenta, '-', ''), '') 'CuentaNotaCredito', ISNULL(co.Descripcion, '') 'DescripcionCuenta', '' 'PolizaSAYID'," +
                    "   '' 'PolizaContpaqID', '' 'TipoMovimiento'" +
                    " FROM cxcNotasCargo AS nc" +
                    " JOIN cxcNotasCargoDetalles AS ncd ON nc.IdNotaCargo = ncd.IdNotaCargo" +
                    " JOIN DoctosElectronicos AS de ON de.IdDocto = ncd.IdNotaCargo AND de.TipoDocto = 'NCA'" +
                    " JOIN Clientes AS cte ON nc.IdCliente = cte.IdCliente" +
                    " JOIN cxcconceptoscobranza AS cc ON cc.idconcepto = ncd.idconcepto AND cc.DOCUMENTO = 'CARGO'" +
                    " LEFT JOIN CUENTASCONTABILIDAD CO ON CC.IDCONCEPTO = CO.CLAVESICY AND CO.IDTIPO = 3 AND IdEmpresaSicy = " + RazSoc.ToString +
                    " where nc.FechaRegistro BETWEEN convert(datetime,'" + FechaDe + " 00:00',103) AND convert(datetime,'" + FechaA + " 23:00' ,103) " +
                    " and de.Estatus not in ('CANCELADO') " +
                    " and nc.IdDocumento =  @IdEmpresa"
        If operaciones.Servidor = operacionesSAY.Servidor Then
            consulta += " AND nc.IdNotaCargo NOT IN (SELECT ISNULL(pomo_notacreditoid, 0) from [" + operacionesSAY.NombreDB + "].[Contabilidad].[PolizaMovimientos]) "
        Else
            consulta += " AND nc.IdNotaCargo NOT IN (SELECT ISNULL(pomo_notacreditoid, 0) from [" + operacionesSAY.Servidor() + "].[" + operacionesSAY.NombreDB + "].[Contabilidad].[PolizaMovimientos]) "
        End If
        consulta += " group by cte.nombre, cte.IdCliente, nc.Subtotal, nc.Total, nc.IVA, nc.Subtotal, cc.Concepto, cc.Concepto, de.fecha, de.RutaXML," +
            " de.RutaPDF, rfc, nc.IdNotaCargo, co.Cuenta, co.Descripcion, nc.ncSerie, nc.Folio" +
            " ORDER BY de.fecha, cte.nombre"

        Return operaciones.EjecutaConsulta(consulta)
    End Function

#End Region

#Region "CARGAR GRID DE CHEQUES POSFECHADOS"
    Public Function CargaGridChequesPosfechados(ByVal estatus As String, ByVal RazSoc As String, ByVal FechaDe As String, ByVal FechaA As String, ByVal empresaID As Integer) As DataTable

        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim operacionesSAY As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = ""

        consulta = <Consulta>
                        ---CHEQUES POSTFECHADOS
                        select   '' as 'Movimiento', '' as 'Cuenta', '' 'Nombre de la cuenta', cte.nombre as 'Cliente', cc.Importe as 'Cargos', c.importe AS 'Abonos', 
		                        v.Total as 'TotalVenta_?', '' AS 'Concepto', c.FechaAplicacion as 'Fecha', '' 'UUID', 'CH-'+CAST(c.Cheque AS VARCHAR(20)) AS 'Cheque', 
		                        ('F-' + d.serie + CONVERT(varchar, d.Folio)) 'Referencia', '' 'Serie', '' 'Folio', '' 'TipoMovimiento', '' 'RespaldoColor', 
		                        '' 'bandera', d.RutaXML 'rutaXML', d.RutaPDF 'rutaPDF', d.IdCliente 'Clienteid', c.FechaVence, 
		                        round(c.importe - (c.importe*0.16),2)  'SubtotalAbono', round((c.importe*0.16),2) as 'IVA_Abono', 
		                        c.IdCheque AS 'IdCheque', c.IdCobro as 'CobroId', c.IdRemision as 'RemisionID', d.IdUnico as 'IdVenta',
		                        d.IdDocumento as 'DoctosVentas', '' 'cuentaSAYID',  cte.rfc as RFC
                        from cobros as c
                        INNER join Ventas as v on c.IdRemision=v.IdRemision and c.Año=v.Año
                        INNER JOIN DoctosElectronicos d ON v.IdRemision = d.IdDocto AND CONVERT(date, v.FechaFE) = CONVERT(date, d.Fecha)
                        INNER JOIN Clientes cte ON d.IdCliente = cte.IdCliente
                        join ChequesClientes as cc on cc.IdCheque=c.IdCheque
                        where  TipoCobro='CHEQUE'
                        AND cc.Estatus in('DP', 'ED', 'RB','P')
                        AND d.IdDocumento = <%= RazSoc %> --IdDoctosventas
                        AND v.IDMONEDA = 1
                        AND CONVERT(datetime, c.FechaAplicacion, 103) BETWEEN '<%= FechaDe %> 00:00:00' and '<%= FechaA %> 23:59:59'
                        AND c.AÑO=2015
                   </Consulta>.Value
        If operaciones.Servidor = operacionesSAY.Servidor Then
            consulta += <Consulta>
                        and c.IdCheque not in (select distinct isnull(pomo_ChequePosfechadoId,0) from [<%= operacionesSAY.NombreDB %>].Contabilidad.PolizaMovimientos)
                   </Consulta>.Value
        Else
            consulta += <Consulta>
                        and c.IdCheque not in (select distinct isnull(pomo_ChequePosfechadoId,0) from [<%= operacionesSAY.Servidor %>].[<%= operacionesSAY.NombreDB %>].Contabilidad.PolizaMovimientos)
                   </Consulta>.Value
        End If
        consulta += <Consulta>
                group by cte.nombre,c.Cheque,d.serie, d.Folio, c.FechaAplicacion, c.FechaVence, d.RutaXML, d.RutaPDF, d.IdCliente,c.IdCheque, 
                        c.IdCobro, c.IdRemision, d.IdDocumento, v.total, c.importe, cc.importe, d.IdUnico, cte.rfc
                        order by c.FechaAplicacion, IdCheque
                   </Consulta>.Value
        Return operaciones.EjecutaConsulta(consulta)
    End Function
#End Region

#Region "CARGAR GRID DE DEPOSITOS INTERNOS"
    Public Function CargaGridDepositosInternos(ByVal estatus As String, ByVal RazSoc As String, ByVal FechaDe As String, ByVal FechaA As String, ByVal empresaID As Integer) As DataTable

        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim operacionesSAY As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = ""

        consulta = <Consulta>
                       ---CHEQUES DEPOSITOS INTERNOS
                        select  '' as 'Movimiento', '' as 'Cuenta', '' 'Nombre de la cuenta',REPLACE(RTRIM(LTRIM(MC.movctacontpaq )), '-', '') AS 'CUENTA_CONTPAQ', 
                                cqc.Descripcion as 'NOMBRE_CUENTA_CONTPAQ', round(cc.Importe - (cc.importe*0.16),2) as 'Cargos',  
                                round(cc.Importe - (cc.importe*0.16),2) as 'Abonos', round((cc.importe*0.16),2) as 'IVA',cc.Importe as Total,'' as Referencia,  
                                '' as 'Concepto',   CHD.FechaEntrega as 'Fecha','CH-'+CAST(c.Cheque AS VARCHAR(20)) AS 'Cheque', '' TipoMovimiento, '' RespaldoColor, 
                                '' bandera, c.IdCheque AS 'IdCheque',   '' AS cuentaSAYID,  d.IdDocumento, cte.nombre as 'Cliente', cte.IdCliente
                   </Consulta>.Value
        If operaciones.Servidor = operacionesSAY.Servidor Then
            consulta += <Consulta>
                                ,case when c.IdCheque in (  SELECT DISTINCT ISNULL(pomo_ChequePosfechadoId,0) 
                                                            FROM [<%= operacionesSAY.NombreDB %>].Contabilidad.PolizaMovimientos ) 
                                then 1 else 0 END as 'EN_POSFECHADOS'
                   </Consulta>.Value
        Else
            consulta += <Consulta>
                                ,case when c.IdCheque in (  SELECT DISTINCT ISNULL(pomo_ChequePosfechadoId,0) 
                                                            FROM [<%= operacionesSAY.Servidor %>].[<%= operacionesSAY.NombreDB %>].Contabilidad.PolizaMovimientos ) 
		                        then 1 else 0 END as 'EN_POSFECHADOS'
                   </Consulta>.Value
        End If
        consulta += <Consulta>
                       from cobros as c
                            INNER join Ventas as v on c.IdRemision=v.IdRemision and c.Año=v.Año
                            INNER JOIN DoctosElectronicos d ON v.IdRemision = d.IdDocto AND CONVERT(date, v.FechaFE) = CONVERT(date, d.Fecha)
                            INNER JOIN Clientes cte ON d.IdCliente = cte.IdCliente
                            INNER join ChequesClientes as cc on cc.IdCheque=c.IdCheque
                            LEFT JOIN web..FI_ctrlCheques CHD ON CHD.IDCHEQUE = C.IDCHEQUE
                            LEFT JOIN CTBMOVIMIENTOSCONTABLES MC ON MOVIDENCABEZADO = IDMOVIMIENTO
                            LEFT JOIN  MovimientosBancarios AS MB ON C.IdDeposito = MB.IdMovimiento
                            LEFT JOIN CuentasBancarias AS CB ON CB.IdCuenta = MB.IdCuenta
                            LEFT JOIN BANCOS  as bC on bC.IdBanco= cb.IdBanco 
                            LEFT JOIN CuentasContabilidad as cqc on REPLACE(RTRIM(LTRIM(cqc.Cuenta )), '-', '')  =REPLACE(RTRIM(LTRIM(MC.movctacontpaq )), '-', '') and cqc.IdEmpresaSicy = d.IdDocumento
                            where  TipoCobro = 'CHEQUE'
                            AND cc.Estatus in('DP', 'ED', 'RB','P')
                            AND MC.movdescripoperacion = 'ALTA'
                            AND d.IdDocumento =  <%= RazSoc %>
                            AND v.IDMONEDA = 1
                            and CHD.FechaEntrega BETWEEN '<%= FechaDe %> 00:00:00' and '<%= FechaA %> 23:59:59'
                            AND c.AÑO>=2015
                   </Consulta>.Value
        If operaciones.Servidor = operacionesSAY.Servidor Then
            consulta += <Consulta>
                        and c.IdCheque not in ( SELECT DISTINCT ISNULL(pomo_ChequeDepositoInternoId,0) 
                                                FROM [<%= operacionesSAY.NombreDB %>].Contabilidad.PolizaMovimientos ) 
                   </Consulta>.Value
        Else
            consulta += <Consulta>
                       and c.IdCheque not in (  SELECT DISTINCT ISNULL(pomo_ChequeDepositoInternoId,0) 
                                                FROM [<%= operacionesSAY.Servidor %>].[<%= operacionesSAY.NombreDB %>].Contabilidad.PolizaMovimientos ) 
                   </Consulta>.Value
        End If
        consulta += <Consulta>
                        GROUP by  MC.movctacontpaq, cqc.Descripcion,  cc.Importe,  CHD.FechaEntrega, c.Cheque, c.IdCheque, d.IdDocumento, cte.nombre ,cte.IdCliente
                        order by CHD.FechaEntrega
                   </Consulta>.Value
        Return operaciones.EjecutaConsulta(consulta)
    End Function
#End Region


#Region "ALTA CUENTAS CONTABLES CONTPAQ/SAY"

    Public Function AltaCuentasContablesSAY(ByVal altaCuentaContable As Entidades.Polizas, ByVal servidor As String, ByVal BD As String, ByVal cuentacontable As String) As DataTable

        Dim operaciones As New Persistencia.OperacionesProcedimientos

        Dim listaValores As New List(Of SqlParameter)
        Dim valores As New SqlParameter
        valores.ParameterName = "@Constante1"
        valores.Value = altaCuentaContable.Pconstante1
        listaValores.Add(valores)

        valores = New SqlParameter
        valores.ParameterName = "@constante2"
        valores.Value = altaCuentaContable.Pconstante2
        listaValores.Add(valores)

        valores = New SqlParameter
        valores.ParameterName = "@cuco_letra"
        valores.Value = altaCuentaContable.Pletra
        listaValores.Add(valores)

        valores = New SqlParameter
        valores.ParameterName = "@cuco_consecutivo"
        valores.Value = altaCuentaContable.Pconsecutivo
        listaValores.Add(valores)

        valores = New SqlParameter
        valores.ParameterName = "@cuentaContableContpaqID"
        valores.Value = altaCuentaContable.PccContpaqID
        listaValores.Add(valores)

        valores = New SqlParameter
        valores.ParameterName = "@cuentaContableSICYID"
        valores.Value = altaCuentaContable.PccSICYID
        listaValores.Add(valores)

        valores = New SqlParameter
        valores.ParameterName = "@proveedorID"
        valores.Value = altaCuentaContable.PproveedorSicyID
        listaValores.Add(valores)

        valores = New SqlParameter
        valores.ParameterName = "@cuentaContableTipo"
        valores.Value = altaCuentaContable.PccTipo
        listaValores.Add(valores)

        valores = New SqlParameter
        valores.ParameterName = "@empresa"
        valores.Value = altaCuentaContable.PempresaID
        listaValores.Add(valores)

        valores = New SqlParameter
        valores.ParameterName = "@clienteid"
        valores.Value = altaCuentaContable.PclienteID
        listaValores.Add(valores)

        valores = New SqlParameter
        valores.ParameterName = "@cuco_usuariocreo"
        valores.Value = altaCuentaContable.PusuarioCreoID
        listaValores.Add(valores)

        valores = New SqlParameter
        valores.ParameterName = "@cuco_descripcion"
        valores.Value = altaCuentaContable.PproveedorNombre
        listaValores.Add(valores)




        Return operaciones.EjecutarConsultaSP("Contabilidad.SP_ALTA_CuentasContablesSAY", listaValores)

    End Function

    Public Function AltaCuentasContablesCONTPAQ(ByVal proveedor As String, ByVal cuenta As String, ByVal servidor As String, ByVal BD As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = ""

        consulta += " DECLARE @Proveedor  varchar (250)"
        consulta += " DECLARE @Cuenta  varchar(20)"
        consulta += " DECLARE @Consecutivo int"
        consulta += " DECLARE @ConsecutivoS varchar(4)"
        consulta += " DECLARE @CuentaNueva varchar(20)"
        consulta += " DECLARE @RowVersion varchar(20)"
        consulta += " DECLARE @id int"
        consulta += " SET @Proveedor='" + proveedor.ToString + "'"
        consulta += " SET @cuenta='" + cuenta.ToString + "'"
        consulta += " SELECT @Consecutivo=SUBSTRING ((SELECT TOP 1 Codigo FROM [" + servidor.ToString.Trim + "].[" + BD.ToString.Trim + "].[dbo].[cuentas] WHERE Codigo like '" + cuenta.ToString.Trim.Substring(0, 8) + "%'ORDER BY Codigo DESC) ,9 , 3)"
        consulta += " SET @Consecutivo= isNULL(@Consecutivo,0)"
        consulta += " SET @Consecutivo=@Consecutivo+1"
        consulta += " IF @Consecutivo <10 "
        consulta += " BEGIN"
        consulta += " SET  @ConsecutivoS='00'+CAST(@Consecutivo as varchar(2))"
        consulta += " End"
        consulta += " "
        consulta += " IF @consecutivo<100 AND @Consecutivo>9"
        consulta += " BEGIN"
        consulta += " SET @ConsecutivoS='0'+CAST(@Consecutivo as varchar(2))"
        consulta += " End"
        consulta += " IF @consecutivo>99"
        consulta += " BEGIN"
        consulta += " SET @ConsecutivoS=@Consecutivo"
        consulta += " End"
        consulta += " SET @id=(SELECT Top 1 id+1 FROM [" + servidor.ToString.Trim + "].[" + BD.ToString.Trim + "].[dbo].[cuentas] order by id DESC)"
        consulta += " SET @Cuenta= SUBSTRING(@Cuenta,0,9)"
        consulta += " SET @CuentaNueva=@Cuenta+@ConsecutivoS"
        consulta += " SET @RowVersion=(SELECT ABS(CAST(CAST(NEWID() AS VARBINARY) AS INT)) AS [RandomNumber])"
        consulta += " INSERT INTO [" + servidor.ToString.Trim + "].[" + BD.ToString.Trim + "].[dbo].[cuentas]"
        consulta += " (id,RowVersion,Codigo,Nombre,NomIdioma,Tipo,EsBaja,CtaMayor,CtaEfectivo,FechaRegistro,SistOrigen,IdMoneda,DigAgrup,IdSegNeg,SegNegMovtos,Afectable,Idrubro,Consume,IdAgrupadorSAT)"
        consulta += " VALUES"
        consulta += " (isnull(@id,1),@RowVersion,@CuentaNueva,@Proveedor,'','D',0,2,0,GETDATE(),'11','1',0,0,0,1,0,76,198)"
        consulta += "SELECT @CuentaNueva  as 'CuentaNueva', isnull(@id,1) as 'ID'"

        Return operaciones.EjecutaConsulta(consulta)
    End Function
#End Region

#Region "ALTA POLIZA CONTPAQ/SAY"


    Public Function AltaPolizaCompaq(ByVal PolizaCompaq As Entidades.Polizas) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosContpaq
        Dim consulta As String = ""

        consulta += " DECLARE @Folio int"
        consulta += " DECLARE @RowVersion varchar (20)"
        consulta += " DECLARE @GUID uniqueidentifier"
        consulta += " DECLARE @ID int"

        'consulta += " SET @Folio=(SELECT Top 1 Folio+1  from [" + PolizaCompaq.PservidorBD.ToString.Trim + "].[" + PolizaCompaq.PempresaBD.ToString.Trim + "].[dbo].[Polizas] where Ejercicio=" + PolizaCompaq.Pejercicio.ToString + " and Periodo=" + PolizaCompaq.Pperiodo.ToString + " ORDER bY Folio desc)"
        consulta += " SET @Folio=(SELECT Top 1 Folio+1  from [" + PolizaCompaq.PempresaBD.ToString.Trim + "].[dbo].[Polizas] where Ejercicio=" + PolizaCompaq.Pejercicio.ToString + " and Periodo=" + PolizaCompaq.Pperiodo.ToString + " and TipoPol=" + PolizaCompaq.PtipoPolizaCompaq.ToString + "  ORDER bY Folio desc)"
        consulta += " SET @RowVersion=(SELECT ABS(CAST(CAST(NEWID() AS VARBINARY) AS INT)) AS [RandomNumber])"
        consulta += " SET @GUID = NEWID()"
        consulta += " SET @ID=(SELECT TOP 1 id from [" + PolizaCompaq.PempresaBD.ToString.Trim + "].[dbo].[Polizas]  order by Id DESC)"
        consulta += " SET @ID=ISNULL(@ID,0)"
        consulta += " IF @ID>99999999 "
        consulta += " BEGIN"
        consulta += " SET @ID=@ID+1"
        consulta += " END"
        consulta += " ELSE"
        consulta += " BEGIN"
        consulta += " SET @ID=100000000"
        consulta += " END"
        consulta += " INSERT INTO [" + PolizaCompaq.PempresaBD.ToString.Trim + "].[dbo].[Polizas]"
        consulta += " (id, RowVersion, Ejercicio, periodo, TipoPol, Folio, clase, Impresa, Concepto, Fecha, Cargos, Abonos, IdDiario, SistOrig, Ajuste, IdUsuario, ConFlujo, ConCuadre,TimeStamp,RutaAnexo,ArchivoAnexo,Guid,tieneDoctoBancario)"
        consulta += " VALUES "
        consulta += " (ISNULL(@ID,1),"
        consulta += " @RowVersion,"
        consulta += " " + PolizaCompaq.Pejercicio.ToString + ","
        consulta += " " + PolizaCompaq.Pperiodo.ToString + ","
        consulta += " " + PolizaCompaq.PtipoPolizaCompaq.ToString + ","
        consulta += " ISNULL(@Folio,1),"
        consulta += " 1,"
        consulta += " 0,"
        consulta += " '" + PolizaCompaq.Pconcepto.ToString + "',"
        consulta += " '" + PolizaCompaq.Pfecha.ToShortDateString + "',"
        consulta += " " + PolizaCompaq.Pcargos.ToString + ","
        consulta += " " + PolizaCompaq.Pabonos.ToString + ","
        consulta += " " + PolizaCompaq.PdiarioID.ToString + ","
        consulta += " 11,0,0,0,0,'','','',"
        consulta += " UPPER(@GUID)"
        consulta += " ,0)"
        consulta += " SELECT  isNULL(@Folio,1) as 'FOLIO', @GUID as 'GUID',isNULL(@ID,1) as 'ID'"
        Return operaciones.EjecutaConsulta(consulta)

    End Function

    Public Function AltaPolizaMovimientoCompaq(ByVal PolizaCompaq As Entidades.Polizas)
        Dim operaciones As New Persistencia.OperacionesProcedimientosContpaq
        Dim consulta As String = ""
        Dim consulta2 As String = ""

        consulta += " DECLARE @RowVersion varchar (20)"
        consulta += " DECLARE @ID int"
        consulta += " DECLARE @cuentaID int"
        consulta += " DECLARE @GUID uniqueidentifier"

        consulta += " SET @GUID = NEWID()"
        consulta += " SET @ID=(SELECT Top 1 id FROM [" + PolizaCompaq.PempresaBD.ToString.Trim + "].[dbo].[MovimientosPoliza]  order	by id desc)"
        consulta += " SET @ID=ISNULL(@ID,0)"
        consulta += " IF @ID>99999999 "
        consulta += " BEGIN"
        consulta += " SET @ID=@ID+1"
        consulta += " END"
        consulta += " ELSE"
        consulta += " BEGIN"
        consulta += " SET @ID=100000000"
        consulta += " END"
        consulta += " SET @RowVersion=(SELECT ABS(CAST(CAST(NEWID() AS VARBINARY) AS INT)) AS [RandomNumber])"
        consulta += " SET @cuentaID=(SELECT Id FROM [" + PolizaCompaq.PempresaBD.ToString.Trim + "].[dbo].[Cuentas] where Codigo='" + PolizaCompaq.PcuentaContable.ToString.Trim + "')"

        consulta += " INSERT INTO [" + PolizaCompaq.PempresaBD.ToString.Trim + "].[dbo].[MovimientosPoliza]"
        consulta += " ( Id,RowVersion,IdPoliza,Ejercicio,Periodo,TipoPol,Folio,NumMovto,IdCuenta,TipoMovto,Importe,ImporteME,Referencia,Concepto,IdDiario,Fecha,IdSegNeg," +
                        "TimeStamp,Guid)"
        consulta += " VALUES"
        consulta += " (ISNULL(@Id,1),"
        consulta += " @RowVersion,"
        consulta += " " + PolizaCompaq.PpolizaCONTPAQID.ToString + ","
        consulta += " " + PolizaCompaq.Pejercicio.ToString + ","
        consulta += " " + PolizaCompaq.Pperiodo.ToString + ","
        consulta += " " + PolizaCompaq.PtipoPolizaCompaq.ToString + ","
        consulta += " " + PolizaCompaq.Pfolio.ToString + ","
        consulta += " " + PolizaCompaq.PnumMovimiento.ToString + ","
        consulta += " @cuentaID,"
        consulta += " " + PolizaCompaq.PtipoMovimiento.ToString + ","
        consulta += " " + PolizaCompaq.Pcargos.ToString + ","
        consulta += " 0,"
        consulta += " '" + PolizaCompaq.Preferencia.ToString.Trim + "',"
        consulta += " '" + PolizaCompaq.Pconcepto.ToString + "',"
        consulta += " " + PolizaCompaq.PdiarioID.ToString + ","
        consulta += " '" + PolizaCompaq.Pfecha.ToShortDateString + "',"
        consulta += " '1',"
        consulta += " '',"
        consulta += " UPPER(@GUID))"
        consulta += "SELECT @GUID as 'GUID'"

        Return operaciones.EjecutaConsulta(consulta)

    End Function

    Public Sub AltaPolizaCFDICompaq(ByVal PolizaCompaq As Entidades.Polizas)

        Dim operaciones As New Persistencia.OperacionesProcedimientosContpaq
        Dim consulta As String = ""
        consulta += " DECLARE @RowVersion varchar (20)"
        consulta += " DECLARE @ID int"

        consulta += " SET @ID=(SELECT Top 1 id FROM [" + PolizaCompaq.PempresaBD.ToString.Trim + "].[dbo].[AsocCFDIs] order	by id desc)"
        consulta += " SET @ID=ISNULL(@ID,0)"
        consulta += " IF @ID>99999999 "
        consulta += " BEGIN"
        consulta += " SET @ID=@ID+1"
        consulta += " END"
        consulta += " ELSE"
        consulta += " BEGIN"
        consulta += " SET @ID=100000000"
        consulta += " END"
        consulta += " SET @RowVersion=(SELECT ABS(CAST(CAST(NEWID() AS VARBINARY) AS INT)) AS [RandomNumber])"

        consulta += " INSERT INTO[" + PolizaCompaq.PempresaBD.ToString.Trim + "].[dbo].[AsocCFDIs]"
        consulta += " (Id,RowVersion,GuidRef,UUID,Referencia,AppType)"
        consulta += " VALUES"
        consulta += " (ISNULL(@ID,1),@RowVersion,"
        consulta += " '" + PolizaCompaq.Pguid.ToString.ToUpper + "',"
        consulta += " '" + PolizaCompaq.Puuid.ToString + "',"
        consulta += " '" + PolizaCompaq.Preferencia.ToString + "',"
        consulta += " 'Contabilidad')"

        operaciones.EjecutaConsulta(consulta)
    End Sub

    Public Sub AltaPolizaCFDIMovimiento(ByVal PolizaContpaq As Entidades.Polizas)
        Dim operaciones As New Persistencia.OperacionesProcedimientosContpaq
        Dim consulta As String = ""
        consulta += " DECLARE @RowVersion varchar(20)"
        consulta += " DECLARE @ID int"
        consulta += " SET @ID=(SELECT Top 1 id FROM [" + PolizaContpaq.PempresaBD.ToString.Trim + "].[dbo].[MovimientosCFD] order by id desc)"
        consulta += " SET @ID=ISNULL(@ID,0)"
        consulta += " IF @ID>99999999 "
        consulta += " BEGIN"
        consulta += " SET @ID=@ID+1"
        consulta += " END"
        consulta += " ELSE"
        consulta += " BEGIN"
        consulta += " SET @ID=100000000"
        consulta += " END"
        consulta += " SET @RowVersion=(SELECT ABS(CAST(CAST(NEWID() AS VARBINARY) AS INT)) AS [RandomNumber])"

        consulta += " INSERT INTO [" + PolizaContpaq.PempresaBD.ToString.Trim + "].[dbo].[MovimientosCFD]"
        consulta += " (Id,RowVersion,IdPoliza,IdCuentaFlujoEfectivo,IdSegmentoNegCtaFlujo,NumMovto,Fecha,Serie,Folio,UUID,ClaveRastreo,Referencia," +
                    " IdProveedor,CodigoConceptoIETU,ImpNeto,ImpNetoME,IdCuentaNeto,IdSegmentoNegNeto,PorIVA,ImporteIVA,ImporteIVAME,IVATasaExcenta," +
                    " IdCuentaIVA,IdSegmentoNegIVA,NombreImpuesto,ImpImpuesto,ImpImpuestoME,IdCuentaImpuesto,IdSegmentoNegImp,ImpOtrosGastos,ImpOtrosGastosME," +
                    " IdCuentaOtrosGastos,IdSegmentoNegOtrosGastos,IVARetenido,IVARetenidoME,IdCuentaRetIVA,IdSegmentoNegRetIVA,ISRRetenido,ISRRetenidoME," +
                    " IdCuentaRetISR,IdSegmentoNegRetISR,NombreOtrasRetenciones,ImpOtrasRetenciones,ImpOtrasRetencionesME,IdCuentaOtrasRetenciones," +
                    " IdSegmentoNegOtrasRet,BaseIVADIOT,BaseIETU,IVANoAcreditable,ImpTotalErogacion,IVAAcreditable,ImpExtra1,ImpExtra2,IdCategoria,IdSubCategoria," +
                    " TipoCambio,IdDocGastos,EsCapturaCompleta,UsuAutorizaPresupuesto,tipoCambioCategoria,impCategoria,Concepto,FolioStr,GuidComprobante)"
        consulta += " VALUES"
        consulta += " ("
        consulta += " isnull(@ID,1),@RowVersion,"
        consulta += " " + PolizaContpaq.PpolizaCONTPAQID.ToString + ","
        consulta += " 0,0,"
        consulta += " " + PolizaContpaq.PnumMovimiento.ToString + ","
        consulta += " '" + PolizaContpaq.Pfecha.ToShortDateString + "',"
        consulta += " '" + PolizaContpaq.Pserie.ToString + "',"
        consulta += " '" + PolizaContpaq.Pfolio.ToString + "',"
        consulta += " '" + PolizaContpaq.Puuid.ToString + "',"
        consulta += " '',"
        consulta += " '" + PolizaContpaq.Preferencia.ToString + "',"
        consulta += " (SELECT TOP 1 ID FROM [" + PolizaContpaq.PempresaBD.ToString.Trim + "].[dbo].[Proveedores] where rtrim(ltrim(REPLACE(REPLACE(RFC,'-',''),' ',''))) ='" + PolizaContpaq.PproveedorRFC.ToString + "' order by id desc) ,"
        consulta += " '',"
        consulta += " " + PolizaContpaq.Psubtotal.ToString + ","
        consulta += " 0,0,0,16,"
        consulta += " " + PolizaContpaq.Piva.ToString + ","
        consulta += " 0,0,0,0,'',0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,'',0,0,0,0,"
        consulta += " " + PolizaContpaq.Psubtotal.ToString + ","
        consulta += " " + PolizaContpaq.Psubtotal.ToString + ","
        consulta += " 0,"
        consulta += " " + PolizaContpaq.Pabonos.ToString + ","
        consulta += " " + PolizaContpaq.Piva.ToString + ","
        consulta += " 0,0,0,0,1,0,1,'',0,0,'',"
        consulta += " '" + PolizaContpaq.Pfolio + "',"
        consulta += " '" + PolizaContpaq.Pguid.ToString + "'"
        consulta += " )"
        operaciones.EjecutaConsulta(consulta)
    End Sub

    Public Function AltaPolizaSAY(ByVal PolizaSAY As Entidades.Polizas) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos

        Dim listaValores As New List(Of SqlParameter)

        Dim valores As New SqlParameter
        valores.ParameterName = "@poli_foliomensual"
        valores.Value = PolizaSAY.Pfolio
        listaValores.Add(valores)

        valores = New SqlParameter
        valores.ParameterName = "poli_contpaqid"
        valores.Value = PolizaSAY.PpolizaCONTPAQID
        listaValores.Add(valores)

        valores = New SqlParameter
        valores.ParameterName = "poli_fecha"
        valores.Value = PolizaSAY.Pfecha
        listaValores.Add(valores)

        valores = New SqlParameter
        valores.ParameterName = "poli_concepto"
        valores.Value = PolizaSAY.Pconcepto
        listaValores.Add(valores)

        valores = New SqlParameter
        valores.ParameterName = "poli_cargos"
        valores.Value = PolizaSAY.Pcargos
        listaValores.Add(valores)

        valores = New SqlParameter
        valores.ParameterName = "poli_abonos"
        valores.Value = PolizaSAY.Pabonos
        listaValores.Add(valores)

        valores = New SqlParameter
        valores.ParameterName = "poli_usuariocreoid"
        valores.Value = PolizaSAY.PusuarioCreoID
        listaValores.Add(valores)

        valores = New SqlParameter
        valores.ParameterName = "poli_anio"
        valores.Value = PolizaSAY.Pejercicio
        listaValores.Add(valores)

        valores = New SqlParameter
        valores.ParameterName = "poli_mes"
        valores.Value = PolizaSAY.Pperiodo
        listaValores.Add(valores)

        valores = New SqlParameter
        valores.ParameterName = "poli_guid"
        valores.Value = PolizaSAY.Pguid
        listaValores.Add(valores)

        valores = New SqlParameter
        valores.ParameterName = "poli_empresaid"
        valores.Value = PolizaSAY.PempresaID
        listaValores.Add(valores)

        valores = New SqlParameter
        valores.ParameterName = "poli_tipoid"
        valores.Value = PolizaSAY.PtipoPoliza
        listaValores.Add(valores)

        Return operaciones.EjecutarConsultaSP("Contabilidad.SP_Alta_PolizaSAY", listaValores)

    End Function

    Public Sub AltaPolizaMovimientoSAY(ByVal polizaSAY As Entidades.Polizas)
        Dim operaciones As New Persistencia.OperacionesProcedimientos

        Dim listaValores As New List(Of SqlParameter)

        Dim valores As New SqlParameter
        valores.ParameterName = "@pomo_polizaid"
        valores.Value = polizaSAY.PpolizaID
        listaValores.Add(valores)

        valores = New SqlParameter
        valores.ParameterName = "@pomo_cargos"
        valores.Value = polizaSAY.Pcargos
        listaValores.Add(valores)

        valores = New SqlParameter
        valores.ParameterName = "@pomo_abonos"
        valores.Value = polizaSAY.Pabonos
        listaValores.Add(valores)

        valores = New SqlParameter
        valores.ParameterName = "@cuenta"
        valores.Value = polizaSAY.PcuentaContable
        listaValores.Add(valores)

        valores = New SqlParameter
        valores.ParameterName = "@pomo_numeromovimiento"
        valores.Value = polizaSAY.PnumMovimiento
        listaValores.Add(valores)

        valores = New SqlParameter
        valores.ParameterName = "@pomo_fecha"
        valores.Value = polizaSAY.Pfecha
        listaValores.Add(valores)

        valores = New SqlParameter
        valores.ParameterName = "@pomo_compraid"
        valores.Value = polizaSAY.PcompraID
        listaValores.Add(valores)

        valores = New SqlParameter
        valores.ParameterName = "@pomo_transferencia"
        valores.Value = polizaSAY.PtransferenciaID
        listaValores.Add(valores)


        valores = New SqlParameter
        valores.ParameterName = "@pomo_uuid"
        valores.Value = polizaSAY.Puuid
        listaValores.Add(valores)

        valores = New SqlParameter
        valores.ParameterName = "@pomo_referencia"
        valores.Value = polizaSAY.Preferencia
        listaValores.Add(valores)

        valores = New SqlParameter
        valores.ParameterName = "@pomo_rutaxml"
        valores.Value = polizaSAY.PrutaXML
        listaValores.Add(valores)

        valores = New SqlParameter
        valores.ParameterName = "@pomo_rutapdf"
        valores.Value = polizaSAY.PrutaPDF
        listaValores.Add(valores)

        valores = New SqlParameter
        valores.ParameterName = "@empresaSaySicy"
        valores.Value = polizaSAY.PempresaID
        listaValores.Add(valores)

        valores = New SqlParameter
        valores.ParameterName = "@tipoMovimiento"
        valores.Value = polizaSAY.PtipoMovimiento
        listaValores.Add(valores)

        valores = New SqlParameter
        valores.ParameterName = "@pomo_proveedorid"
        valores.Value = polizaSAY.PproveedorSicyID
        listaValores.Add(valores)

        valores = New SqlParameter
        valores.ParameterName = "@pomo_concepto"
        valores.Value = polizaSAY.Pconcepto
        listaValores.Add(valores)

        valores = New SqlParameter
        valores.ParameterName = "@cuentaSAYID"
        valores.Value = polizaSAY.PccSAYID
        listaValores.Add(valores)

        valores = New SqlParameter
        valores.ParameterName = "@pomo_ventaID"
        valores.Value = polizaSAY.PventaID
        listaValores.Add(valores)

        valores = New SqlParameter
        valores.ParameterName = "@pomo_cobroid"
        valores.Value = polizaSAY.pcobroid
        listaValores.Add(valores)

        valores = New SqlParameter
        valores.ParameterName = "@pomo_notacreditoid"
        valores.Value = polizaSAY.PNotaCredito
        listaValores.Add(valores)

        valores = New SqlParameter
        valores.ParameterName = "@pomo_notacargoid"
        valores.Value = polizaSAY.PNotaCargo
        listaValores.Add(valores)

        valores = New SqlParameter
        valores.ParameterName = "@pomo_VentaCanceladaId"
        valores.Value = polizaSAY.PventaCanceladaID
        listaValores.Add(valores)

        valores = New SqlParameter
        valores.ParameterName = "@pomo_notacreditoidCancelada"
        valores.Value = polizaSAY.PNotaCreditoCandelada
        listaValores.Add(valores)

        valores = New SqlParameter
        valores.ParameterName = "@pomo_ChequePosfechadoId"
        valores.Value = polizaSAY.PIdChequePosfechado
        listaValores.Add(valores)

        valores = New SqlParameter
        valores.ParameterName = "@pomo_ChequeDepositoInternoId"
        valores.Value = polizaSAY.PIdChequeDepositoInterno
        listaValores.Add(valores)

        valores = New SqlParameter
        valores.ParameterName = "@pomo_ChequeDevueltoId"
        valores.Value = polizaSAY.PIdChequeDevuelto
        listaValores.Add(valores)

        valores = New SqlParameter
        valores.ParameterName = "@pomo_ChequeDepositoDevueltoId"
        valores.Value = polizaSAY.PIdChequeDepositoDevuelto
        listaValores.Add(valores)

        operaciones.EjecutarConsultaSP("Contabilidad.SP_Alta_PolizaMovimientos", listaValores)
    End Sub

    Public Sub ActualizaCargosAbonosPoliza(ByVal polizaid As Integer)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaValores As New List(Of SqlParameter)

        Dim valores As New SqlParameter
        valores.ParameterName = "@polizaid"
        valores.Value = polizaid
        listaValores.Add(valores)

        operaciones.EjecutarConsultaSP("Contabilidad.SP_actualizar_saldo_poliza", listaValores)
    End Sub

    Public Sub ActualizaTipoPoliza(ByVal polizaID As Integer, ByVal tipoPolizaID As Integer, ByVal servidorBD As String, ByVal empresaBD As String)
        Dim operaciones As New Persistencia.OperacionesProcedimientosContpaq
        Dim consulta As String = ""
        consulta += " UPDATE [" + empresaBD.ToString.Trim + "].[dbo].[Polizas]"
        consulta += " SET TipoPol = '" + tipoPolizaID.ToString + "'"
        consulta += " where Id='" + polizaID.ToString + "'"
        operaciones.EjecutaConsulta(consulta)
        consulta = ""
        consulta += " UPDATE [" + empresaBD.ToString.Trim + "].[dbo].[MovimientosPoliza]"
        consulta += " SET TipoPol='" + tipoPolizaID.ToString + "'"
        consulta += " WHERE IdPoliza='" + polizaID.ToString + "'"
        operaciones.EjecutaConsulta(consulta)
    End Sub

    Public Sub AltaMovimientoEgresos(ByVal poliza As Entidades.Polizas, ByVal servidorID As String, servidorBD As String)
        Dim operaciones As New Persistencia.OperacionesProcedimientosContpaq
        Dim consulta As String = ""
        consulta += " DECLARE @RowVersion varchar(20)"
        consulta += " DECLARE @ID int"
        consulta += " DECLARE @personaID int"
        consulta += " DECLARE @beneficfiarioPagador as varchar(100)"
        consulta += " DECLARE @GUID uniqueidentifier"
        consulta += "  DECLARE @Folio as int"
        consulta += " SET @Folio=(SELECT TOP 1	Folio + 1 FROM  [" + servidorBD.ToString.Trim + "].[dbo].[egresos] ORDER BY id DESC)"

        consulta += " SELECT @personaID=Codigo, @beneficfiarioPagador=Nombre FROM [" + servidorBD.ToString.Trim + "].[dbo].[Personas] WHERE upper(RFC)='" + poliza.PproveedorRFC.ToString + "'"
        consulta += " DECLARE @Codigo varchar(20)"
        consulta += " SET @GUID=NEWID()"
        consulta += " SET @ID=(SELECT Top 1 id+1 FROM  [" + servidorID.ToString.Trim + "].[" + servidorBD.ToString.Trim + "].[dbo].[egresos] order by id desc)"
        consulta += " SET @RowVersion=(SELECT ABS(CAST(CAST(NEWID() AS VARBINARY) AS INT)) AS [RandomNumber])"
        consulta += " INSERT INTO [" + servidorBD.ToString.Trim + "].[dbo].[Egresos]"
        consulta += " ([Id]"
        consulta += " ,[RowVersion]"
        consulta += " ,[IdDocumentoDe]"
        consulta += " ,[TipoDocumento]"
        consulta += " ,[Folio]"
        consulta += " ,[Fecha]"
        consulta += " ,[Ejercicio]"
        consulta += " ,[Periodo]"
        consulta += " ,[FechaAplicacion]"
        consulta += " ,[EjercicioAp]"
        consulta += " ,[PeriodoAp]"
        consulta += " ,[CodigoPersona]"
        consulta += " ,[BeneficiarioPagador]"
        consulta += " ,[IdCuentaCheques]"
        consulta += " ,[NatBancaria]"
        consulta += " ,[Naturaleza]"
        consulta += " ,[CodigoMoneda]"
        consulta += " ,[CodigoMonedaTipoCambio]"
        consulta += " ,[TipoCambio]"
        consulta += " ,[Total]"
        consulta += " ,[Referencia]"
        consulta += " ,[Concepto]"
        consulta += " ,[EsConciliado]"
        consulta += " ,[EsAsociado]"
        consulta += " ,[UsuAutorizaPresupuesto]"
        consulta += " ,[IdMovEdoCta]"
        consulta += " ,[IdIngresoDestino]"
        consulta += " ,[EjercicioPol]"
        consulta += " ,[PeriodoPol]"
        consulta += " ,[TipoPol]"
        consulta += " ,[NumPol]"
        consulta += " ,[PosibilidadPago]"
        consulta += " ,[EsProyectado]"
        consulta += " ,[IdPoliza]"
        consulta += " ,[Origen]"
        consulta += " ,[IdDocumento]"
        consulta += " ,[EjercicioPolOrigen]"
        consulta += " ,[PeriodoPolOrigen]"
        consulta += " ,[TipoPolOrigen]"
        consulta += " ,[NumPolOrigen]"
        consulta += " ,[IdPolizaOrigen]"
        consulta += " ,[EsAnticipo]"
        consulta += " ,[EsTraspasado]"
        consulta += " ,[PolizaAgrupada]"
        consulta += " ,[UsuarioCrea]"
        consulta += " ,[UsuarioModifica]"
        consulta += " ,[tieneCFD]"
        consulta += " ,[Guid]"
        consulta += " ,[CuentaDestino]"
        consulta += " ,[BancoDestino])"
        consulta += " VALUES"
        consulta += " ("
        consulta += " isnull(@ID,1)"
        consulta += " ,@RowVersion"
        consulta += " ,36"
        consulta += " ,53"
        consulta += " ,isnull(@Folio,1)"
        consulta += " ,'" + poliza.Pfecha.ToShortDateString + "'"
        consulta += " ," + poliza.Pejercicio.ToString
        consulta += " ," + poliza.Pperiodo.ToString
        consulta += " ,'" + poliza.Pfecha.ToShortDateString + "'"
        consulta += " ," + poliza.Pejercicio.ToString
        consulta += " ," + poliza.Pperiodo.ToString
        consulta += " ,@personaID"
        consulta += " ,@beneficfiarioPagador"
        consulta += " ," + poliza.PCuentaGeneralContpaqid.ToString
        consulta += " ,0"
        consulta += " ,2"
        consulta += " ,1"
        consulta += " ,2"
        consulta += " ,0"
        consulta += " ," + poliza.PtotalPoliza.ToString
        consulta += " ,'" + poliza.Preferencia.ToString + "'"
        consulta += " ,'" + poliza.Pconcepto.ToString + "'"
        consulta += " ,0"
        consulta += " ,0"
        consulta += " ,''"
        consulta += " ,0"
        consulta += " ,0"
        consulta += " ," + poliza.Pejercicio.ToString
        consulta += " ," + poliza.Pperiodo.ToString
        consulta += " ,2"
        consulta += " ," + poliza.PpolizaCONTPAQID.ToString
        consulta += " ,0"
        consulta += " ,0"
        consulta += " ," + poliza.PpolizaCONTPAQID.ToString
        consulta += " ,11"
        consulta += " ,''"
        consulta += " ,0"
        consulta += " ,0"
        consulta += " ,0"
        consulta += " ,0 "
        consulta += " ,0 "
        consulta += " ,0 "
        consulta += " ,0"
        consulta += " ,0"
        consulta += " ,'Sistemas'"
        consulta += " ,''"
        consulta += " ,0"
        consulta += " ,@GUID "
        consulta += " ,'" + poliza.PclabeInterbancaria.ToString + "'"
        consulta += " ," + poliza.PbancoContpaqid.ToString
        consulta += " )"
        operaciones.EjecutaConsulta(consulta)
    End Sub
#End Region

#Region "ALTA PERSONAS Y PROVEEDORES"

    Public Function ValidarPersonaProveedorExisteContpaq(ByVal proveedorRFC As String, ByVal servidorBD As String, empresaBD As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosContpaq
        Dim consulta As String = ""
        consulta += " SELECT Id FROM [" + empresaBD.ToString.Trim + "].[dbo].[Proveedores]"
        consulta += " where  rtrim(ltrim(REPLACE(REPLACE(RFC,'-',''),' ','')))  ='" + proveedorRFC.ToString.Replace("-", "").Replace(" ", "").Trim + "'"
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function AltaPersonasContpaq(ByVal PolizaSAY As Entidades.Polizas) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosContpaq

        Dim consulta As String = ""
        consulta += " DECLARE @RowVersion varchar(20)"
        consulta += " DECLARE @ID int"
        consulta += " DECLARE @Codigo int"
        consulta += " SET @ID=(SELECT Top 1 id  FROM [" + PolizaSAY.PempresaBD.ToString.Trim + "].[dbo].[Personas] order by id desc)"
        consulta += " SET @ID=ISNULL(@ID,0)"
        consulta += " IF @ID>99999999 "
        consulta += " BEGIN"
        consulta += " SET @ID=@ID+1"
        consulta += " END"
        consulta += " ELSE"
        consulta += " BEGIN"
        consulta += " SET @ID=100000000"
        consulta += " END"

        consulta += " SET @RowVersion=(SELECT ABS(CAST(CAST(NEWID() AS VARBINARY) AS INT)) AS [RandomNumber])"
        consulta += " SET @Codigo = (SELECT TOP 1	Codigo  FROM [" + PolizaSAY.PempresaBD.ToString.Trim + "].[dbo].[Personas] ORDER BY id DESC)"
        consulta += " SET @Codigo=ISNULL(@Codigo,0)"
        consulta += " IF @Codigo>99999999 "
        consulta += " BEGIN"
        consulta += " SET @Codigo=@Codigo+1"
        consulta += " END"
        consulta += " ELSE"
        consulta += " BEGIN"
        consulta += " SET @Codigo=100000000"
        consulta += " END"
        consulta += " INSERT INTO [" + PolizaSAY.PempresaBD.ToString.Trim + "].[dbo].[Personas]"
        consulta += " ([Id],[RowVersion],[Codigo],[Nombre],[RFC],[CURP],[FechaRegistro],[EsCliente],[EsProveedor],[EsEmpleado],[EsAgente],[EsPersona],[EsBaja],[Telefono1],[Telefono2],[Telefono3],[Fax],[eMail],[PaginaWeb],[IdDatoExtra],[GenerarPolizaAuto],[PosibilidadPago],[SistOrig],[CodigoAdminPAQ],[EsResponsableGasto],[CtaContableGasto],[PagarDoctosAMismoRFC],[GeneraContraCuentaDeudor],[IdCategoria],[IdSubCategoria])"
        consulta += " VALUES"
        consulta += " (isnull(@ID,1),@RowVersion,IsNULL(@Codigo,1),"
        consulta += " '" + PolizaSAY.PproveedorNombre.ToString + "',"
        consulta += " '" + PolizaSAY.PproveedorRFC.ToString.Replace(" ", "").Trim + "',"
        consulta += " '',"
        consulta += " GETDATE(),0,1,0,0,0,0,'','','','','','',0,0,0,11,'',0,'',0,0,0,0)"
        consulta += " SELECT isnull(@ID,1) as 'personaID', IsNULL(@Codigo,1) as 'personaCodigo'"

        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function AltaProveedoresContpaq(ByVal ProveedoresContpaq As Entidades.Polizas) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosContpaq

        Dim consulta As String = ""
        consulta += " DECLARE @RowVersion varchar(20)"
        consulta += " DECLARE @ID int"
        consulta += " DECLARE @Codigo varchar(20)"

        consulta += " SET @ID=(SELECT Top 1 id FROM  [" + ProveedoresContpaq.PempresaBD.ToString.Trim + "].[dbo].[Proveedores] order by id desc)"
        consulta += " SET @ID=ISNULL(@ID,0)"
        consulta += " IF @ID>99999999 "
        consulta += " BEGIN"
        consulta += " SET @ID=@ID+1"
        consulta += " END"
        consulta += " ELSE"
        consulta += " BEGIN"
        consulta += " SET @ID=100000000"
        consulta += " END"
        consulta += " SET @RowVersion=(SELECT ABS(CAST(CAST(NEWID() AS VARBINARY) AS INT)) AS [RandomNumber])"
        consulta += " SET @Codigo = (SELECT TOP 1	Codigo FROM [" + ProveedoresContpaq.PempresaBD.ToString.Trim + "].[dbo].[Proveedores] ORDER BY id DESC)"
        consulta += " SET @Codigo=ISNULL(@Codigo,0)"
        consulta += " IF @Codigo>99999999 "
        consulta += " BEGIN"
        consulta += " SET @Codigo=@Codigo+1"
        consulta += " END"
        consulta += " ELSE"
        consulta += " BEGIN"
        consulta += " SET @Codigo=100000000"
        consulta += " END"

        consulta += " INSERT INTO [" + ProveedoresContpaq.PempresaBD.ToString.Trim + "].[dbo].[Proveedores]"
        consulta += " ([Id],[RowVersion],[Codigo],[Nombre],[RFC],[CURP],[TipoOperacion],[IdCuenta],[TimeStamp],[TasaIVA15],[TasaIVA10],[TasaIVA0],[TasaIVAExento],[TasaIVAOtra1],[TasaIVAOtra2],[TasaOtra1],[TasaOtra2],[TasaAsumida],[RetencionIVA],[RetencionISR],[TipoTercero],[IdFiscal],[NomExtranjero],[Pais],[Nacionalidad],[IdConceptoIETU],[CodigoPersona],[CodigoCuenta],[EsParaAbonoCta],[CodigoCtaComplementaria],[CodigoPrepoliza],[IdSegNeg],[TasaIVA16],[TasaIVA11],[ClaveBanco],[Sucursal],[CuentaClabe],[Referencia])"
        consulta += " VALUES"
        consulta += " (ISNULL(@ID,1),@RowVersion,isnull(@Codigo,1),"
        consulta += " '" + ProveedoresContpaq.PproveedorNombre.ToString + "',"
        consulta += " '" + ProveedoresContpaq.PproveedorRFC.ToString.Replace(" ", "").Trim + "',"
        consulta += " '',"
        consulta += " 85,0,'',0,0,0,0,0,0,0,0,7,0,0,4,'','','','',0,"
        consulta += " " + ProveedoresContpaq.PproveedorPersonaID.ToString + ","
        consulta += " '',0,'','',0,1,0,'','','','')"

        consulta += "SELECT ISNULL(@ID,1) as 'proveedorID',isnull(@Codigo,1) as 'personaCodigo' "
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function validarProveedorExisteSAY(ByVal proveedorRFC As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = ""
        consulta += " SELECT * FROM  Proveedor.Proveedor"
        consulta += "  where rtrim(ltrim(REPLACE(REPLACE(prov_rfc,'-',''),' ','')))  ='" + proveedorRFC.ToString.Replace("-", "").Replace(" ", "").Trim + "'"


        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function insertarPersonaSAY(ByVal listaEntidades As Entidades.Polizas) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = ""
        consulta += " INSERT INTO Framework.Persona "
        consulta += " (pers_nombre,pers_personafisica,pers_activo,pers_usuariocreoid,pers_fechacreacion)"
        consulta += " VALUES"
        consulta += " ("
        consulta += "'" + listaEntidades.PproveedorNombre.ToString + "',"
        consulta += " 1,"
        consulta += " 1,"
        consulta += Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid.ToString + ","
        consulta += " GETDATE()"
        consulta += " )"
        consulta += " SELECT isnull(@@identity,0) as 'id'"
        Return operaciones.EjecutaConsulta(consulta)
    End Function


    Public Function insertarProveedorSAY(ByVal listaEntidades As Entidades.Polizas) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = ""
        consulta += " INSERT INTO Proveedor.Proveedor "
        consulta += " (prov_nombregenerico,prov_razonsocial,prov_rfc,prov_personaidproveedor,prov_clasificacionpersonaid,prov_activo,prov_usuariocreoid,prov_fechacreacion,prov_sicyid)"
        consulta += " VALUES"
        consulta += "('" + listaEntidades.PproveedorNombre.ToString + "'"
        consulta += ",'" + listaEntidades.PproveedorNombre.ToString + "'"
        consulta += ",'" + listaEntidades.PproveedorRFC.ToString + "'"
        consulta += "," + listaEntidades.PproveedoID.ToString
        consulta += " ,20"
        consulta += " ,1"
        consulta += " ," + Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid.ToString
        consulta += " ,GETDATE()"
        consulta += " ," + listaEntidades.PproveedorSicyID.ToString
        consulta += ")"
        consulta += " SELECT isnull(@@identity,0) as 'id'"
        Return operaciones.EjecutaConsulta(consulta)
    End Function

#End Region

#Region "CARGAR GRID TRANSFERENCIAS"
    Public Function cargarGridTransferencias(ByVal fechaInicio As DateTime, ByVal fechaFin As DateTime, ByVal empresaID As String, ByVal estatus As String)
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim operacionesSAY As New Persistencia.OperacionesProcedimientos
        'Dim consulta As String = ""

        'consulta += " DECLARE @mes int, @año int "
        'consulta += " set @mes=month('" + fechaInicio.ToShortDateString + "' )"
        'consulta += " set @año=year('" + fechaInicio.ToShortDateString + "' )"

        'consulta += " IF OBJECT_ID ('tempdb.dbo.#tmpTransferencias') is not null"
        'consulta += " BEGIN"
        'consulta += " DROP TABLE #tmpTransferencias;"
        'consulta += " End"

        'consulta += " create table #tmpTransferencias("
        'consulta += " idTransferencia int, Movimiento varchar(10), Cuenta Varchar(10), proveedor varchar (100), Cargos money, Abonos money, Fecha smalldatetime, Referencia varchar(20), Uuid varchar(100),"
        'consulta += " Concepto varchar(100), subtotal money, IVA money, CuentaBancaria varchar(50), RazonSocialP varchar(200),RFC varchar(50), proveedorSICYID int, importeTransferencia money, rutaXML varchar(500),"
        'consulta += " rutaPDF varchar(500), Serie Varchar(50),FOLIO Varchar(50), NAVE varchar(50), TipoMovimiento int, compraSICYID int, bandera varchar(1), RespaldoColor varchar(1), CuentaContpaqid varchar(1),"
        'consulta += " bancoContpaqid varchar(1),ClabeInterbancaria varchar(50), NumAutorizacion varchar(50), comprobanteID varchar(20)"
        'consulta += " )"
        'consulta += " insert into #tmpTransferencias ("
        'consulta += " idTransferencia, Movimiento, Cuenta, proveedor, Cargos, Abonos, Fecha, Referencia, Uuid,"
        'consulta += " Concepto, subtotal, IVA, CuentaBancaria, RazonSocialP, RFC, proveedorSICYID, importeTransferencia, rutaXML,"
        'consulta += " rutaPDF, Serie, FOLIO, NAVE, TipoMovimiento, compraSICYID, bandera, RespaldoColor, CuentaContpaqid,"
        'consulta += " bancoContpaqid, ClabeInterbancaria, NumAutorizacion,comprobanteID"
        'consulta += " )"
        'consulta += " SELECT idTransferencia , Movimiento , Cuenta , proveedor , Cargos , Abonos , Fecha , Referencia , Uuid ,"
        'consulta += " Concepto , subtotal , IVA , CuentaBancaria , RazonSocialP ,RFC , proveedorSICYID , importeTransferencia , rutaXML ,"
        'consulta += " rutaPDF, Serie ,FOLIO , NAVE , TipoMovimiento , compraSICYID , bandera, RespaldoColor , CuentaContpaqid ,"
        'consulta += " bancoContpaqid ,ClabeInterbancaria , NumAutorizacion,comprobanteID   FROM"
        'consulta += " (SELECT"
        'consulta += " t.idTrans idTransferencia,"
        'consulta += " '' Movimiento,"
        'consulta += " '' Cuenta,"
        'consulta += " P.RazonSocial PROVEEDOR,"
        'consulta += " 0 Cargos,"
        'consulta += " t.imppago AS Abonos,"
        'consulta += " T.FecAplicada Fecha,"
        'consulta += " '' Referencia,"
        'consulta += " '' Uuid,"
        'consulta += " '' Concepto,"
        'consulta += " ((t.imppago * cxpM.TIPOCAMBIO) / 1.16) Subtotal,"
        'consulta += " ((t.imppago * cxpM.TIPOCAMBIO) / 1.16) * 0.16 IVA,"
        'consulta += " cb.Cuenta CuentaBancaria,"
        'consulta += " p.RazonSocial RazonSocialP,"
        'consulta += " p.RFC RFC,"
        'consulta += " p.IdProveedor proveedorSICYID,"
        'consulta += " t.imppago importeTransferencia,"
        'consulta += " '' rutaXML,"
        'consulta += " '' rutaPDF,"
        'consulta += " '' SERIE,"
        'consulta += " '' FOLIO,"
        'consulta += " '' NAVE,"
        'consulta += " 0 TipoMovimiento,"
        'consulta += " '' compraSICYID,"
        'consulta += " '' AS 'bandera',"
        'consulta += " '' AS 'RespaldoColor',"
        'consulta += " '' AS 'CuentaContpaqid',"
        'consulta += " '' AS 'bancoContpaqid',"
        'consulta += " cbp.ClabeInterbancaria AS 'ClabeInterbancaria',"
        'consulta += " ISNULL(t.NumAutorizacion, 0) AS 'NumAutorizacion',"
        'consulta += " '' as 'comprobanteID'"
        'consulta += " FROM Transferencias T"
        'consulta += " JOIN Proveedores P"
        'consulta += " ON t.idproveedor = p.IdProveedor"
        'consulta += " JOIN CuentasBancarias AS cb"
        'consulta += " ON t.idcuenta = cb.IdCuenta"
        'consulta += " LEFT JOIN CtaBcoProveedor AS cbp"
        'consulta += " ON t.idcuentaProv = cbp.idctaProv"
        'consulta += " JOIN CxPMOVIMIENTOS as cxpM on cxpM.idTrans=t.idTrans"
        'consulta += " WHERE T.TipoDocto = 1"
        'consulta += " AND T.Estatus IN ('APLICADA')"
        'consulta += " AND T.Formapago = 13"
        'consulta += " AND T.IdRazSoc IN (" + empresaID.ToString + ")"
        'consulta += " AND cxpM.MONEDA=1"

        'If operaciones.Servidor = operacionesSAY.Servidor Then
        '    consulta += "and T.idTrans not in  (select pomo_idtransferencia from [" + operacionesSAY.NombreDB + "].Contabilidad.PolizaMovimientos where pomo_idtransferencia>0 and pomo_fecha BETWEEN " +
        '                "(select '01/' + cast(@mes as varchar(5)) + '/' + cast(@año as varchar(5)) as fecha) and (SELECT (select convert(DATE,dateadd(ms,-3,DATEADD(mm, DATEDIFF(m,0,'" + fechaInicio.ToShortDateString + "')+1, 0)),112))))"
        'Else
        '    consulta += "and T.idTrans not in  (select pomo_idtransferencia from [" + operacionesSAY.Servidor() + "].[" + operacionesSAY.NombreDB + "].Contabilidad.PolizaMovimientos where pomo_idtransferencia>0 and pomo_fecha BETWEEN " +
        '                "(select '01/' + cast(@mes as varchar(5)) + '/' + cast(@año as varchar(5)) as fecha) and (SELECT (select convert(DATE,dateadd(ms,-3,DATEADD(mm, DATEDIFF(m,0,'" + fechaInicio.ToShortDateString + "')+1, 0)),112))))"
        'End If

        'consulta += " AND CONVERT(datetime, T.FecAplicada, 103) BETWEEN CONVERT(datetime, '" + fechaInicio.ToShortDateString + " 00:00:00', 103) AND CONVERT(datetime, '" + fechaFin.ToShortDateString + " 23:59:00', 103)"
        '''''Esto es temporal 
        'consulta += " and cb.Cuenta not in ('01700004472','4044866507','28290000201')"

        'consulta += " UNION"
        'consulta += " SELECT"
        'consulta += " m.idTrans idTransferencia,"
        'consulta += " '' Movimiento,"
        'consulta += " ' ' Cuenta,"
        'consulta += " P.RazonSocial PROVEEDOR,"
        'consulta += "		case when (m.idpagare is null or  m.idpagare =0) THEN (m.IMPMOV * m.TIPOCAMBIO)" +
        '            " else (select sum(ccc.IMPMOV) from CxPMOVIMIENTOS as ccc where  LTRIM(RTRIM(ccc.NUMDOCTO)) = LTRIM(RTRIM(m.NUMDOCTO)) " +
        '            " AND ccc.CVEPROV = m.CVEPROV AND ccc.AÑOSEMANA = m.AÑOSEMANA and ccc.idTrans <> 0" +
        '            " and ccc.FECMOV BETWEEN '" + fechaInicio.ToShortDateString + " 00:00:00' AND '" + fechaFin.ToShortDateString + " 23:59:00') end Cargos,"
        'consulta += " 0 Abonos,"
        'consulta += " '' Fecha,"
        'consulta += " cf.cfdSerie+ cf.cfdFolio 'Referencia',"
        'consulta += " '' Uuid,"
        'consulta += " '' Concepto,"
        'consulta += " s.SUBTOT Subtotal,"
        'consulta += " s.IMPIVA IVA,"
        'consulta += " '' CuentaBancaria,"
        'consulta += " p.RazonSocial RazonSocialP,"
        'consulta += " p.RFC,"
        'consulta += " p.IdProveedor proveedorSICYID,"
        'consulta += " s.IMPDOCTO ImporteTransferencia,"
        'consulta += " cf.cfdRutaXml RutaXML,"
        'consulta += " cf.cfdRutaVisor RutaPDF,"
        'consulta += " '' SERIE,"
        'consulta += " '' FOLIO,"
        'consulta += " '' NAVE,"
        'consulta += " 0 TipoMovimiento,"
        'consulta += " s.IDTABLA compraSICYID,"
        'consulta += " '' AS 'bandera',"
        'consulta += " '' AS 'RespaldoColor',"
        'consulta += " '' AS 'CuentaContpaqid',"
        'consulta += " '' AS 'bancoContpaqid',"
        'consulta += " '' AS 'ClabeInterbancaria',"
        'consulta += " '' AS 'NumAutorizacion',"
        'consulta += " s.IdComprobante as 'comprobanteID'"
        'consulta += " FROM CxPMOVIMIENTOS AS m"
        'consulta += " JOIN Proveedores p"
        'consulta += " ON p.IdProveedor = m.CVEPROV"
        'consulta += " JOIN CxPSALDOS s"
        'consulta += " ON LTRIM(RTRIM(s.NUMDOCTO)) = LTRIM(RTRIM(m.NUMDOCTO))"
        'consulta += " AND s.CVEPROV = m.CVEPROV"
        'consulta += " AND s.AÑOSEMPAGO = m.AÑOSEMANA   "
        'consulta += " LEFT JOIN CFDS cf"
        'consulta += " ON cf.cfdId = s.IdComprobante"
        'consulta += " JOIN Transferencias T on m.idTrans=T.idTrans and t.tipodocto = s.TIPODOCTO"
        'consulta += " WHERE"
        'consulta += " m.idTrans>0"
        'consulta += " AND T.TipoDocto = 1"
        'consulta += " AND T.Estatus IN ('APLICADA')"
        'consulta += " AND T.Formapago = 13"
        'consulta += " AND T.IdRazSoc IN (" + empresaID.ToString + ") "
        'consulta += " and s.MONEDA=1"

        'If operaciones.Servidor = operacionesSAY.Servidor Then
        '    consulta += "and T.idTrans not in  (select pomo_idtransferencia from [" + operacionesSAY.NombreDB + "].Contabilidad.PolizaMovimientos  where pomo_fecha BETWEEN " +
        '                "(select '01/' + cast(@mes as varchar(5)) + '/' + cast(@año as varchar(5)) as fecha) and (SELECT (select convert(DATE,dateadd(ms,-3,DATEADD(mm, DATEDIFF(m,0,'" + fechaInicio.ToShortDateString + "')+1, 0)),112))))"
        'Else
        '    consulta += "and T.idTrans not in  (select pomo_idtransferencia from [" + operacionesSAY.Servidor() + "].[" + operacionesSAY.NombreDB + "].Contabilidad.PolizaMovimientos  where pomo_fecha BETWEEN " +
        '                "(select '01/' + cast(@mes as varchar(5)) + '/' + cast(@año as varchar(5)) as fecha) and (SELECT (select convert(DATE,dateadd(ms,-3,DATEADD(mm, DATEDIFF(m,0,'" + fechaInicio.ToShortDateString + "')+1, 0)),112))))"
        'End If

        'consulta += " AND T.idcuenta not IN (SELECT IdCuenta FROM CuentasBancarias where Cuenta in ('01700004472', '4044866507', '28290000201') )"
        'consulta += " AND CONVERT(datetime, T.FecAplicada, 103) BETWEEN CONVERT(datetime, '" + fechaInicio.ToShortDateString + " 00:00:00', 103) AND CONVERT(datetime, '" + fechaFin.ToShortDateString + " 23:59:00', 103)"
        'consulta += " ) as tabla"
        'consulta += " ORDER BY idTransferencia ASC, CuentaBancaria ASC"
        'consulta += " delete from #tmpTransferencias where idTransferencia in("
        'consulta += " select idTRansferencia from #tmpTransferencias"
        'consulta += " where comprobanteID=0 and Cargos>0)"

        'consulta += " delete from #tmpTransferencias where idTransferencia in(select idTransferencia as contador from #tmpTransferencias"
        'consulta += " group by idTransferencia"
        'consulta += " having count(idTransferencia) = 1"
        'consulta += " )"
        'consulta += " SELECT"
        'consulta += " Movimiento AS 'Movimiento',"
        'consulta += " Cuenta AS 'Cuenta',"
        'consulta += " Proveedor AS 'Proveedor',"
        'consulta += " Cargos AS 'Cargos',"
        'consulta += " Abonos AS 'Abonos',"
        'consulta += " Concepto AS 'Concepto',"
        'consulta += " Fecha AS 'Fecha',"
        'consulta += " Uuid AS 'Uuid',"
        'consulta += " 'F-'+Referencia AS 'Referencia',"
        'consulta += " idTransferencia AS 'idTransferencia',"
        'consulta += " subtotal AS 'subtotal',"
        'consulta += " iva,"
        'consulta += " CuentaBancaria,"
        'consulta += " RazonSocialP,"
        'consulta += " RFC,"
        'consulta += " proveedorSICYID,"
        'consulta += " importeTransferencia,"
        'consulta += " rutaXML,"
        'consulta += " rutaPDF,"
        'consulta += " Serie,"
        'consulta += " Folio,"
        'consulta += " Nave,"
        'consulta += " TipoMovimiento,"
        'consulta += " compraSICYID,"
        'consulta += " bandera,"
        'consulta += " RespaldoColor,"
        'consulta += " CuentaContpaqid,"
        'consulta += " bancoContpaqid,"
        'consulta += " ClabeInterbancaria,"
        'consulta += " 'T-'+NumAutorizacion as 'NumAutorizacion',"
        'consulta += " '' as 'cuentaSAYID'   ,"
        'consulta += " comprobanteID as 'comprobanteID',"
        'consulta += " '' as 'tipoPolizaContpaqID'"
        'consulta += " FROM #tmpTransferencias"
        'consulta += " where idTransferencia not in (select DISTINCT S.idTrans from CxPMOVIMIENTOS AS S where MONEDA <> 1 and S.idTrans in (select DISTINCT TT.idTransferencia FROM #tmpTransferencias AS TT))"
        'consulta += " ORDER BY idTransferencia, CuentaBancaria"

        'Return operaciones.EjecutaConsulta(consulta)
        'SCDA 29062020 Se cambia la consulta a SP
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@IdEmpresa"
        parametro.Value = empresaID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FechaInicio"
        parametro.Value = fechaInicio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FechaFin"
        parametro.Value = fechaFin
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@ServidorSicy"
        parametro.Value = operaciones.Servidor
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@ServidorSAY"
        parametro.Value = operacionesSAY.Servidor
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Base"
        parametro.Value = operacionesSAY.NombreDB
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Contabilidad].[SP_AltaPoliza_cargarGridTransferencias]", listaParametros)
    End Function

    Public Function buscaDocumentosSinXML_Transferencias(ByVal fechaInicio As DateTime, ByVal fechaFin As DateTime, ByVal empresaID As String)
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim operacionesSAY As New Persistencia.OperacionesProcedimientos
        'Dim consulta As String = ""
        'consulta += " SELECT S.IDTABLA,s.IdComprobante,  s.NUMDOCTO Folio, s.FECDOCTO Fecha, 'FACTURA' [Tipo Documento], P.RFC RFC,P.RazonSocial [Razon Social],"
        'consulta += " s.IMPDOCTO Total, '' UUID, ISNULL(cf.cfdRutaXml,'') XML, "
        'consulta += " isnull(cf.cfdRutaVisor,'') PDF, p.IdProveedor, "
        'consulta += " (select distinct top 1 g.IdRazSoc from CfgRazonSocialTransferenciaNave g where g.IdDoctoVta=" + empresaID.ToString + ") EmpresaId, "
        'consulta += " (select distinct top 1 g.rutaXml+'\' from CfgRazonSocialTransferenciaNave g where g.IdDoctoVta=" + empresaID.ToString + "  and g.IdNave=(select na.idnave from NavesAlmacen na where na.idAlmacen=m.NAVE)) ruta, m.NAVE Nave,(select top 1 rfc from DoctosVentas where IdDocumento=" + empresaID + ") RFCEmpresa "
        'consulta += " FROM CxPMOVIMIENTOS AS m"
        'consulta += " JOIN Proveedores p       ON p.IdProveedor = m.CVEPROV"
        'consulta += " JOIN CxPSALDOS s ON LTRIM(RTRIM(s.NUMDOCTO)) = LTRIM(RTRIM(m.NUMDOCTO))         AND s.CVEPROV = m.CVEPROV       AND s.AÑOSEMPAGO = m.AÑOSEMANA"
        'consulta += " LEFT JOIN CFDS cf        ON cf.cfdId = s.IdComprobante"
        'consulta += " WHERE idTrans IN "
        'consulta += " (SELECT t.idTrans FROM Transferencias t WHERE T.TipoDocto = 1 AND T.Estatus IN ('APLICADA') AND T.Formapago = 13 AND T.IdRazSoc IN (" + empresaID + ")"
        'consulta += " AND CONVERT(datetime, T.FecAplicada, 103) BETWEEN CONVERT(datetime, '" + fechaInicio.ToShortDateString + " 00:00:00', 103) AND CONVERT(datetime, '" + fechaFin.ToShortDateString + " 00:00:00', 103)"
        'consulta += " AND T.idTrans NOT IN ("

        'If operaciones.Servidor = operacionesSAY.Servidor Then
        '    consulta += " SELECT pomo_idtransferencia FROM [" + operacionesSAY.NombreDB + "].[Contabilidad].[PolizaMovimientos] WHERE pomo_idtransferencia > 0 "
        'Else
        '    consulta += " SELECT pomo_idtransferencia FROM [" + operacionesSAY.Servidor + "].[" + operacionesSAY.NombreDB + "].[Contabilidad].[PolizaMovimientos] WHERE pomo_idtransferencia > 0 "
        'End If

        'consulta += "                   ))"
        'consulta += " AND S.IdComprobante <= 0 "
        'consulta += " order by p.RazonSocial, s.FECDOCTO"

        'Return operaciones.EjecutaConsulta(consulta)

        'SCDA 13092019 Se cambia consulta a sp

        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@IdEmpresa"
        parametro.Value = empresaID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FechaInicio"
        parametro.Value = fechaInicio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FechaFin"
        parametro.Value = fechaFin
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@ServidorSicy"
        parametro.Value = operaciones.Servidor
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@ServidorSAY"
        parametro.Value = operacionesSAY.Servidor
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Base"
        parametro.Value = operacionesSAY.NombreDB
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("Contabilidad.SP_AltaPoliza_DocumentosSinXML_Transferencias", listaParametros)

    End Function


#End Region

#Region "Lo nuevo"

    Public Function obtenerProveedores(ByVal servidorBD As String, empresaBD As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosContpaq
        Dim consulta As String = ""
        consulta += "SELECT DISTINCT RFC FROM [" + empresaBD.ToString.Trim + "].[dbo].[Proveedores]  where RFC<>''"
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function obtenerIdDescripcionCuentaGeneral(ByVal cuenta As String, ByVal empresaID As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = ""
        consulta += " SELECT cc.cuco_cuentacontableid as cuentaSAYID,cc.cuco_descripcion as Descripcion, * FROM Contabilidad.CuentasContablesGenerales as cg"
        consulta += " JOIN Contabilidad.CuentasContables as cc on cc.cuco_cuentacontableid=cg.cgen_cuentasayid"
        consulta += " where  cg.cgen_cuenta='" + cuenta.ToString + "'"
        consulta += " and cg.cgen_empresaid=" + empresaID.ToString
        consulta += " and cc.cuco_status=1"
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function obtenerIdDescripcionCuentaGeneral2(ByVal empresaID As String, ByVal tipoPoliza As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = ""
        consulta += " SELECT cc.cuco_cuentacontableid as cuentaSAYID,cc.cuco_descripcion as Descripcion, cg.cgen_cuenta,cg.cgen_tipopolizaid  FROM Contabilidad.CuentasContablesGenerales as cg "
        consulta += " JOIN Contabilidad.CuentasContables as cc on cc.cuco_cuentacontableid=cg.cgen_cuentasayid"
        consulta += "  left join Contabilidad.PolizasTipos on  cg.cgen_tipopolizaid=poti_polizatipoid"
        consulta += " where cg.cgen_empresaid=" + empresaID.ToString
        consulta += " and cc.cuco_status=1"
        consulta += " and poti_nombre in ( '" + tipoPoliza.ToString + "')"
        consulta += " GROUP by cgen_cuenta,cuco_cuentacontableid, cuco_descripcion,cg.cgen_tipopolizaid  "
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function obtenerNombreProveedorContpaq(ByVal RFC As String, ByVal servidorBD As String, ByVal empresaBD As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosContpaq
        Dim consulta As String = ""
        consulta += "SELECT Nombre as 'Nombre' FROM [" + empresaBD + "].[dbo].[Proveedores] "
        consulta += " where upper(RFC)='" + RFC.ToUpper + "'"
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function obtenerNombreCuentaContpaq(ByVal Cuenta As String, ByVal servidorBD As String, ByVal empresaBD As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosContpaq
        Dim consulta As String = ""
        consulta += "SELECT Nombre as 'Nombre' FROM [" + empresaBD.Trim + "].[dbo].[Cuentas] "
        consulta += " where Codigo='" + Cuenta.ToString + "'"
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function cargarCuentasContablesContpaqRelacion(ByVal empresaID As Integer, ByVal tipoCuentaID As Integer, ByVal nomenclatura As String, ByVal nomenclatura2 As String, ByVal servidor As String, ByVal BD As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosContpaq
        Dim consulta As String = ""

        consulta += " SELECT  id,Codigo as 'Cuenta',Nombre FROM  [" + BD.ToString.Trim + "].[dbo].[cuentas]"
        consulta += " where (codigo like '" + nomenclatura.ToString + "%'"
        consulta += " or codigo like '" + nomenclatura2.ToString + "%')"
        consulta += " order by Nombre"
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function obtenerConsecutivo(ByVal servidor As String, ByVal empresaBD As String, ByVal nomenclatura As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosContpaq
        Dim consulta As String = ""
        consulta += " SELECT top 1  id,Codigo as 'Cuenta',Nombre FROM  [" + empresaBD.ToString.Trim + "].[dbo].[cuentas] "
        consulta += " where upper(codigo) like upper('" + nomenclatura.ToString + "%')"
        consulta += " order by Cuenta DESC"
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Sub actualizarTotales(ByVal servidor As String, ByVal empresaBD As String, ByVal polizaContpaqID As String)
        Dim operaciones As New Persistencia.OperacionesProcedimientosContpaq

        Dim consulta As String = ""
        consulta += " UPDATE [" + empresaBD.ToString.Trim + "].[dbo].[Polizas] "
        consulta += " SET Cargos=(SELECT SUM(Importe) FROM [" + empresaBD.ToString.Trim + "].[dbo].[MovimientosPoliza] where IdPoliza=" + polizaContpaqID.ToString + "  and TipoMovto=0) ,"
        consulta += " Abonos=(SELECT SUM(Importe) FROM [" + empresaBD.ToString.Trim + "].[dbo].[MovimientosPoliza] where IdPoliza=" + polizaContpaqID.ToString + "  and TipoMovto=1)"
        consulta += " where Id = " + polizaContpaqID
        operaciones.EjecutaConsulta(consulta)
    End Sub

#End Region

    Public Function RecuperarCodigoTipoPolizaContpaq(ByVal Nombre As String, ByVal servidorBD As String, ByVal empresaBD As String)
        Dim operaciones As New Persistencia.OperacionesProcedimientosContpaq
        Dim consulta As String = ""
        consulta += " select codigo from [" + empresaBD.ToString.Trim + "].dbo.TiposPolizas where Nombre = '" + Nombre + "'"

        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function RecuperarIdDiarioContpaq(ByVal Nombre As String, ByVal servidorBD As String, ByVal empresaBD As String)
        Dim operaciones As New Persistencia.OperacionesProcedimientosContpaq
        Dim consulta As String = ""

        consulta += "select Id from  [" + empresaBD.ToString.Trim + "].dbo.DiariosEspeciales" +
            " where codigo = " + Nombre
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function CuentasContables_ActivoFijo(ByVal IdEmpresa As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = ""
        consulta += " select cgen_cuentageneralid, cgen_empresaid, cgen_cuenta from Contabilidad.CuentasContablesGenerales where cgen_tipopolizaid = 22 and cgen_empresaid = (select essc_empresaid from Framework.empresaSaySicyContpaq where essc_sayid = " + IdEmpresa.ToString + ")"
        Return operaciones.EjecutaConsulta(consulta)
    End Function


End Class
