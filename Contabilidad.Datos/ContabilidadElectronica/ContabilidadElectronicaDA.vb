Imports Persistencia
Imports System.Data.SqlClient

Public Class ContabilidadElectronicaDA

    Public Function ConsultaPolizasPeriodo(ByVal periodo As Integer, ByVal anio As Integer, ByVal servidor As String, ByVal NombreBD As String) As DataTable

        Dim operaciones As New OperacionesProcedimientosContpaq
        Dim consulta As String = String.Empty
        consulta += "select P.Id 'NumUnIdenPol', replace(convert(varchar, Fecha, 111), '/', '-') 'Fecha', Concepto 'Concepto', TipoPol, Folio, tp.Nombre as TipoPoliza from [" + NombreBD.Trim.Replace(" ", "") + "].[dbo].[Polizas] as p join [ctIRMAC].[dbo].[TiposPolizas] as tp on p.TipoPol=tp.Codigo  where Periodo=" + periodo.ToString + " and Ejercicio=" + anio.ToString + " order by Fecha, TipoPol "
        Return operaciones.EjecutaConsulta(consulta)

    End Function

    Public Function ConsultaMovimientosPoliza(ByVal idPoliza As String, ByVal servidor As String, ByVal NombreBD As String) As DataTable

        Dim operaciones As New OperacionesProcedimientosContpaq
        Dim consulta As String = String.Empty
        consulta += "select mp.NumMovto,c.Codigo 'NumCta', c.Nombre 'DesCta', mp.Concepto 'Concepto', " +
        " Debe= case  mp.TipoMovto when 0 then mp.Importe when 1 then 0 END," +
        " Haber= case  mp.TipoMovto when 1 then mp.Importe when 0 then 0 END, m.CodigoSAT 'Moneda',mp.Referencia Referencia " +
        " from [" + NombreBD.Trim.Replace(" ", "") + "].[dbo].[MovimientosPoliza] as mp " +
        " join [" + NombreBD.Trim.Replace(" ", "") + "].[dbo].[cuentas] as c on c.Id=mp.IdCuenta " +
        " join [" + NombreBD.Trim.Replace(" ", "") + "].[dbo].[Monedas] as m on c.IdMoneda=m.Id" +
        " where IdPoliza = " + idPoliza.ToString
        Return operaciones.EjecutaConsulta(consulta)

    End Function

    Public Function ConsultaComprobantesMovimiento(ByVal idPoliza As String, ByVal folio As String, ByVal TipoPoliza As String, ByVal moneda As String, ByVal servidor As String, ByVal NombreBD As String, ByVal numMovto As String) As DataTable

        Dim operaciones As New OperacionesProcedimientosContpaq
        Dim consulta As String = String.Empty
        consulta += "SELECT top 1 UUID 'UUID_CFDI', " +
            "isnull(" + NombreBD.Trim.Replace(" ", "") + ".dbo.ObtenerRFCTipoPoliza(" + TipoPoliza.Trim.Replace(" ", "") + ",isnull(IdProveedor,0)),(SELECT TOP 1 RFC FROM " + NombreBD.Trim.Replace(" ", "") + ".dbo.Proveedores as p1 join " + NombreBD.Trim.Replace(" ", "") + ".dbo.cuentas c1 on p1.Nombre=c1.Nombre join " + NombreBD.Trim.Replace(" ", "") + ".dbo.MovimientosPoliza as pm1 on pm1.IdCuenta=c1.Id WHERE pm1.IdPoliza=" + idPoliza.ToString + " and pm1.NumMovto=" + numMovto + "))  'RFC'" +
            ", 'MontoTotal' = CASE WHEN ImpNeto =  0 THEN ImpTotalErogacion ELSE ImpNeto END, '" + moneda + "' Moneda " +
        "FROM [" + NombreBD.Trim.Replace(" ", "") + "].[dbo].[MovimientosCFD] WHERE IdPoliza=" + idPoliza + " and (((convert(varchar(50),Serie)) +''+(convert(varchar(50),Folio)) like '" + folio.Replace("F-", "") + "') or (FolioStr like '%" + Tools.ValidacionesDatos.quitarLetrasCadena(folio.Replace("F-", "")) + "%')) order by MontoTotal desc"
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function ConsultaCfdsTransferencia(ByVal idPoliza As String, ByVal TipoPoliza As String, ByVal moneda As String, ByVal servidor As String, ByVal NombreBD As String) As DataTable

        Dim operaciones As New OperacionesProcedimientosContpaq
        Dim consulta As String = String.Empty
        consulta += "SELECT UUID 'UUID_CFDI', " +
            "isnull(" + NombreBD.Trim.Replace(" ", "") + ".dbo.ObtenerRFCTipoPoliza(" + TipoPoliza.Trim.Replace(" ", "") + ",isnull(IdProveedor,0)),(SELECT TOP 1 RFC FROM " + NombreBD.Trim.Replace(" ", "") + ".dbo.Proveedores as p1 join " + NombreBD.Trim.Replace(" ", "") + ".dbo.cuentas c1 on p1.IdCuenta=c1.Id join " + NombreBD.Trim.Replace(" ", "") + ".dbo.MovimientosPoliza as pm1 on pm1.IdCuenta=c1.Id WHERE pm1.IdPoliza=" + idPoliza.ToString + "))  'RFC'" +
            ", 'MontoTotal' = CASE WHEN ImpNeto =  0 THEN ImpTotalErogacion ELSE ImpNeto END, '" + moneda + "' Moneda " +
        "FROM [" + NombreBD.Trim.Replace(" ", "") + "].[dbo].[MovimientosCFD] WHERE IdPoliza=" + idPoliza + " order by MontoTotal desc"
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function ConsultaCuentasRFC_Clientes(ByVal idEmpresa As String) As DataTable

        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)
        Dim operaciones As New Persistencia.OperacionesProcedimientos


        parametro.ParameterName = "idCliente"
        parametro.Value = idEmpresa
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Contabilidad].[SP_Contabilidad_ConsultaCuentasRFC_Clientes]", listaParametros)

        'Dim operaciones As New OperacionesProcedimientos
        'Dim consulta As String = String.Empty
        'consulta += "SELECT cc.cuco_constante1+cc.cuco_constante2+cc.cuco_letra+cc.cuco_consecutivo as cuenta, cc.cuco_clienteid, cc.cuco_descripcion, cl.rfc" +
        '" FROM Contabilidad.CuentasContables  as cc join Framework.empresaSaySicyContpaq as essc on cc.cuco_empresaid=essc.essc_empresaid" +
        '" join [192.168.2.2].[yuyin].[dbo].[Clientes] as cl on cl.idCliente=cc.cuco_clienteid" +
        '" where essc.essc_sayid=" + idEmpresa + " and cc.cuco_constante1='105' and cc.cuco_clienteid>0 order by cuenta"
        'Return operaciones.EjecutaConsulta(consulta)

    End Function

    Public Function ConsultaCheques(ByVal idPoliza As String, ByVal NombreBD As String) As DataTable

        Dim operaciones As New OperacionesProcedimientosContpaq
        Dim consulta As String = String.Empty
        consulta += "select c.folio 'No Cheque', b.ClaveFiscal 'Banco Emisor', cc.Codigo 'Cta Origen',replace(convert(varchar, c.Fecha, 111), '/', '-')  'Fecha cheque', " +
        " c.BeneficiarioPagador 'Beneficiario', p.RFC 'RFC Tercero vinc', c.Total 'Monto', m.CodigoSAT 'Moneda', " +
        " REPLACE('0',c.TipoCambio,'1.0') 'Tipo Cambio'" +
        " from [" + NombreBD.Trim.Replace(" ", "") + "].[dbo].[Cheques] c" +
        " join [" + NombreBD.Trim.Replace(" ", "") + "].[dbo].[CuentasCheques] cc on c.IdCuentaCheques=cc.Id " +
        " join [" + NombreBD.Trim.Replace(" ", "") + "].[dbo].[Bancos] b on cc.IdBanco=b.Id" +
        " join [" + NombreBD.Trim.Replace(" ", "") + "].[dbo].[Monedas] m on c.CodigoMoneda=m.Id" +
        " join [" + NombreBD.Trim.Replace(" ", "") + "].[dbo].[Personas] p on c.CodigoPersona=p.Codigo" +
        " where c.IdPoliza = " + idPoliza
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function ConsultaTransferencias(ByVal idPoliza As String, ByVal NombreBD As String) As DataTable

        Dim operaciones As New OperacionesProcedimientosContpaq
        Dim consulta As String = String.Empty
        consulta += "select cc.codigo 'Cta Origen', b.ClaveFiscal 'Banco Origen', e.CuentaDestino 'Cta Destino', b2.ClaveFiscal 'Banco Destino',replace(convert(varchar, e.Fecha, 111), '/', '-') 'Fecha Transferencia', " +
        "e.BeneficiarioPagador 'Beneficiario', p.RFC 'RFC Tercero vinc', e.Total 'Monto', m.CodigoSAT 'Moneda', REPLACE('0',e.TipoCambio,'1.0') 'Tipo cambio'  " +
        " from [" + NombreBD.Trim.Replace(" ", "") + "].[dbo].[Egresos] e " +
        " join [" + NombreBD.Trim.Replace(" ", "") + "].[dbo].[CuentasCheques] cc on e.IdCuentaCheques=cc.Id" +
        " join [" + NombreBD.Trim.Replace(" ", "") + "].[dbo].[Bancos] b on cc.IdBanco=b.Id" +
        " left join [" + NombreBD.Trim.Replace(" ", "") + "].[dbo].[Bancos] b2 on b2.Id=e.BancoDestino" +
        " join [" + NombreBD.Trim.Replace(" ", "") + "].[dbo].[Personas] p on e.CodigoPersona=p.Codigo" +
        " join [" + NombreBD.Trim.Replace(" ", "") + "].[dbo].[Monedas] m on e.CodigoMoneda=m.Id where e.IdPoliza=" + idPoliza
        Return operaciones.EjecutaConsulta(consulta)
    End Function

End Class
