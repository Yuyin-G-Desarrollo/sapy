Imports System.Data.SqlClient
Imports Entidades

Public Class AgregarComprobanteDA
    Public Function verificarFolioCxpagar(ByVal comprobante As MaquilaComprobante)
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim datos As New DataTable
        Dim datos2 As New DataTable
        Dim serie As String = ""
        Dim folio As String = ""
        datos = getDatosComprobantes(comprobante.idComprobante)
        If datos.Rows.Count > 0 Then
            Dim consulta As String =
             <cadena>
          select numDocto,CVEPROV from CxPSALDOS where CVEPROV=<%= datos.Rows(0).Item("idProveedor").ToString %> and NUMDOCTO='<%= datos.Rows(0).Item("folio").ToString %>'     
            </cadena>
            Return operaciones.EjecutaConsulta(consulta)
        End If
        Return datos2
    End Function
    Public Function getDiasCredito(ByVal idProveedor As Integer) As Integer
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim datos As New DataTable
        Dim consulta As String =
            <cadena>
           select * from Proveedores where IdProveedor=
            </cadena>
        consulta += " " & idProveedor & " "
        datos = operaciones.EjecutaConsulta(consulta)
        If datos.Rows.Count > 0 Then
            Return Convert.ToInt32(datos.Rows(0).Item("DiasCredito").ToString)
        End If
        Return 0
    End Function
    Public Function validarSiExistenDiasInhabiles(ByVal inicio As Date, ByVal fin As Date) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim datos As New DataTable
        Dim consulta As String =
            <cadena>
            select * from CalendarioDiasInhabiles where fechaInicio BETWEEN 
            </cadena>
        consulta += "'" & inicio.ToString("dd/MM/yyyy") & "' and '" & fin.ToString("dd/MM/yyyy") & "' or fechaFin BETWEEN '" & inicio.ToString("dd/MM/yyyy") & "' and '" & fin.ToString("dd/MM/yyyy") & "'"
        datos = operaciones.EjecutaConsulta(consulta)
        Return datos
    End Function
    Public Function validarSiesDiaHabil(ByVal fecha As Date) As Boolean
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim datos As New DataTable
        Dim consulta As String =
            <cadena>
            select * from CalendarioDiasInhabiles where 
            </cadena>
        consulta += " '" & fecha.ToString("dd/MM/yyyy") & "' BETWEEN fechaInicio and fechaFin "
        datos = operaciones.EjecutaConsulta(consulta)
        If datos.Rows.Count > 0 Then
            Return False
        End If
        Return True
    End Function
    Public Function getSemana(ByVal fecha As Date) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim datos As New DataTable
        Dim consulta As String =
            <cadena>
            select numano,numsem,FecIni,FecFin from catSemanas where 
            </cadena>
        consulta += " '" & fecha.ToString("dd/MM/yyyy") & "' BETWEEN FecIni and FecFin "
        datos = operaciones.EjecutaConsulta(consulta)
        Return datos
    End Function


    Public Function getNaveSIcy(ByVal idNave As Integer) As Integer
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim datos As New DataTable
        Dim consulta As String =
            <cadena>
           select nave_navesicyid from Framework.Naves where nave_naveid=
            </cadena>
        consulta += " " & idNave & " "
        datos = operaciones.EjecutaConsulta(consulta)
        If datos.Rows.Count > 0 Then
            Return Convert.ToInt32(datos.Rows(0).Item(0).ToString)
        End If
        Return 0
    End Function
    Public Function getFacturacionRemision(ByVal idNave As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim datos As New DataTable
        Dim consulta As String =
            <cadena>
           select * from Proveedores.ConfigPagoMaquilas where cpm_idNave=
            </cadena>
        consulta += " " & idNave & " "
        datos = operaciones.EjecutaConsulta(consulta)
        Return datos
    End Function
    Public Function verificarRazonSocialParaNave(ByVal idNave As Integer, ByVal RFC As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim datos As New DataTable
        Dim consulta As String =
            <cadena>
            select * from Proveedores.ConfigPagoMaquilasDetalles inner join 
            Proveedores.ConfigPagoMaquilas on ConfigPagoMaquilas.cpm_id=ConfigPagoMaquilasDetalles.cpm_id
            inner join Contribuyentes on cpmd_idRazSoc=IDRazSoc
            where
            </cadena>
        consulta += " cpm_idNave=" & idNave & " and REPLACE(rfc,'-','')='" & RFC & "' and cpm_estatus=1"
        datos = operaciones.EjecutaConsulta(consulta)
        Return datos
    End Function
    Public Function verificarEmisor(ByVal idNave As Integer, ByVal RFC As String) As Boolean
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim datos As New DataTable
        Dim consulta As String =
            <cadena>         
            select RFC from Proveedores 
            inner join Proveedores.MaquilaProveedores on mapo_proveedorid=IdProveedor
            </cadena>
        consulta += " where mapo_naveid=" & idNave & ""
        datos = operaciones.EjecutaConsulta(consulta)
        For Each row As DataRow In datos.Rows
            If quitarGuionyEspacios(row("RFC")).ToUpper = quitarGuionyEspacios(RFC).ToUpper Then
                Return True
            End If
        Next
        Return False
    End Function
    Function quitarGuionyEspacios(ByVal cadena As String) As String
        Dim tmp As String = ""
        tmp = cadena.Replace("-", "")
        tmp = tmp.Replace(" ", "")
        Return tmp
    End Function
    Public Function verificarUUID(ByVal uuid As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@UUID"
            parametro.Value = uuid
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Proveedor].[SP_ObtenerComprobanteIDMaquilaComprobantes]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function getIdProveedorPorRFC(ByVal idNave As Integer, ByVal RFC As String) As Integer
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim datos As New DataTable
        Dim consulta As String =
            <cadena>         
            select RFC,IdProveedor from Proveedores 
            inner join Proveedores.MaquilaProveedores on mapo_proveedorid=IdProveedor
            </cadena>
        consulta += " where mapo_naveid=" & idNave & ""
        datos = operaciones.EjecutaConsulta(consulta)
        For Each row As DataRow In datos.Rows
            If quitarGuionyEspacios(row("RFC")) = quitarGuionyEspacios(RFC) Then
                Return row("IdProveedor")
            End If
        Next
        Return 0
    End Function
    Public Function insertComprobanteMaquila(ByVal comprobante As MaquilaComprobante) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaparametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "@maco_usuariocreo"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@maco_naveid"
        parametro.Value = comprobante.idNave
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@maco_folio"
        parametro.Value = comprobante.folio
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@maco_receptorid"
        parametro.Value = comprobante.receptorid
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@maco_pares"
        parametro.Value = comprobante.pares
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@maco_subtotal"
        parametro.Value = comprobante.subtotal
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@maco_iva"
        parametro.Value = comprobante.iva
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@maco_total"
        parametro.Value = comprobante.total
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@maco_uuid"
        parametro.Value = comprobante.uuid
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@maco_rutaxml"
        parametro.Value = comprobante.rutaxml
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@maco_rutapdf"
        parametro.Value = comprobante.rutapdf
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@maco_fecha"
        parametro.Value = comprobante.fecha
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@maco_estatus"
        parametro.Value = comprobante.estatus.Trim
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@maco_fechadocumento"
        parametro.Value = comprobante.fechadocumento
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@maco_proveedorid"
        parametro.Value = comprobante.proveedorid
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@maco_tipo"
        parametro.Value = comprobante.tipo
        listaparametros.Add(parametro)
        Return objPersistencia.EjecutarConsultaSP("[Proveedores].[SP_InsertMaquilaComprobantes]", listaparametros)
    End Function

    Public Function updateComprobanteMaquila(ByVal comprobante As MaquilaComprobante) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaparametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "@idComprobante"
        parametro.Value = comprobante.idComprobante
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@maco_semanacompra"
        parametro.Value = comprobante.datosPagoCompra.semanaCompra
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@maco_aniocompra"
        parametro.Value = comprobante.datosPagoCompra.añoCompra
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@maco_semanapago"
        parametro.Value = comprobante.datosPagoCompra.semanaPago
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@maco_aniopago"
        parametro.Value = comprobante.datosPagoCompra.añoPago
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@maco_fechavencimiento"
        parametro.Value = comprobante.datosPagoCompra.fechaPago
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@idProveedor"
        parametro.Value = comprobante.proveedorid
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@idReceptor"
        parametro.Value = comprobante.receptorid
        listaparametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Proveedores].[SP_UpdateMaquilaComprobantes]", listaparametros)
    End Function
    Public Function verificarFecha(ByVal fecha As Date, ByVal idNave As Integer) As Boolean
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim datos As New DataTable
        Dim consulta As String =
            <cadena>         
            select * from Proveedores.MaquilaComprobantes where 
            </cadena>
        consulta += " maco_fecha='" & fecha.ToString("dd/MM/yyyy") & "' and maco_estatus in ('C','A') and maco_naveid=" & getNaveSIcy(idNave)
        datos = operaciones.EjecutaConsulta(consulta)
        If datos.Rows.Count > 0 Then
            Return False
        End If
        Return True
    End Function

    Public Function consecutivoFolio(ByVal razonSocial As String, ByVal rfcEmisorXML As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim datos As New DataTable
        Dim consulta As String = "select IdProveedor,consecutivoRemisionCompMaquila From Proveedores where RazonSocial like"
        consulta += " '%" & razonSocial & "%' "
        consulta += " or RFC like  '%" & rfcEmisorXML & "%' "

        datos = operaciones.EjecutaConsulta(consulta)
        Return datos
    End Function

    Public Function ActualizaConsecutivoRemisionCompMaquila(idProveedor As Int16, idConsecutivoRemsionMaquila As Int16) As DataTable

        'hace falta meter el update
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaparametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "@idProveedor"
        parametro.Value = idProveedor
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@idConsecutivoRemsionMaquila"
        parametro.Value = idConsecutivoRemsionMaquila
        listaparametros.Add(parametro)
        parametro = New SqlParameter

        Return objPersistencia.EjecutarConsultaSP("Proveedores.SP_ActualizaConsecutivoRemisionCompMaquila", listaparametros)



    End Function


    Public Function maquilaProveedores(idNave As Int16) As DataTable

        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim datos As New DataTable
        Dim consulta As String =
            <cadena>
                select p.IdProveedor IdProveedor, p.RazonSocial RazonSocial, p.consecutivoRemisionCompMaquila Consecutivo
                from Proveedores.MaquilaProveedores mp
                inner join Proveedores p on p.IdProveedor = mp.mapo_proveedorid
                where mp.mapo_naveid = 
            </cadena>
        consulta += " " & idNave & " "
        datos = operaciones.EjecutaConsulta(consulta)
        Return datos
    End Function


    Public Function proveedores(maquilaProveedores As DataTable) As DataTable

        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim datos As New DataTable
        Dim consulta As String = ""
        Dim cadena As String
        For Each row As DataRow In maquilaProveedores.Rows
            consulta = consulta + row("mapo_proveedorid").ToString + ","
        Next
        consulta = consulta.TrimEnd(",")
        cadena = "select * From Proveedores where IdProveedor in (" + consulta + ") "

        datos = operaciones.EjecutaConsulta(cadena)
        Return datos
    End Function


    Public Function consecutivo(idProveedor As Integer) As Integer

        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String = ""
        Dim datos As DataTable

        consulta = "select consecutivoRemisionCompMaquila From Proveedores where IdProveedor=" + idProveedor.ToString + " "

        datos = operaciones.EjecutaConsulta(consulta)
        If datos.Rows.Count > 0 Then
            Return Convert.ToInt64(datos.Rows(0).Item(0).ToString)
        End If
        Return 0

    End Function

    Public Function InsertaComprobanteDetalle(ByVal comprobante As MaquilaComprobante) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaparametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@idComprobante"
        parametro.Value = comprobante.idComprobante
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@tipo"
        parametro.Value = comprobante.tipo
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@fecha"
        parametro.Value = comprobante.fecha
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@idNave"
        parametro.Value = comprobante.idNave
        listaparametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Proveedores].[SP_InsertMaquilaComprobantesDetalle]", listaparametros)
    End Function

    Public Function ObtenerComprobanteDetalle(ByVal idComprobante As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaparametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@idComprobante"
        parametro.Value = idComprobante
        listaparametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Proveedores].[SP_ObtenerMaquilaComprobantesDetalle]", listaparametros)
    End Function

#Region "ConsultaComprobantesForm"
    Public Function getComprobantes(ByVal idNave As Integer, ByVal estatus As String, ByVal tipoFecha As String, ByVal fechaFin As Date, ByVal fechaInicio As Date) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        'Dim datos As New DataTable
        'Dim consulta As String =
        '    <cadena>
        '    select 0 seleccionar,'' Vacia,Nave,maco_fecha 'Fecha Ingreso',
        '    maco_fechadocumento 'Fecha Documento',maco_fechacreacion 'Fecha Captura',
        '    maco_tipo 'Tipo',maco_folio 'Folio',RazonSocial 'Razón Social',
        '    maco_subtotal 'Subtotal',maco_iva 'IVA',maco_total 'Total',isnull(maco_descuento,0) 'Descuento',
        '    maco_semanacompra 'Sem Compra',maco_semanapago 'Sem Pago',maco_rutaxml 'XML',
        '    maco_rutapdf 'PDF',maco_comprobanteid,IdNave,IdProveedor,maco_estatus,maco_receptorid
        '    from Proveedores.MaquilaComprobantes
        '    left join Naves on IdNave=maco_naveid left join Proveedores on 
        '    maco_proveedorid=IdProveedor
        '    </cadena>
        'consulta += " Where "
        'If idNave > 0 Then
        '    consulta += " maco_naveid=" & getNaveSIcy(idNave) & "  AND "
        'End If
        'If Not estatus.Trim = String.Empty Then
        '    consulta += " maco_estatus='" & estatus & "' AND"
        'End If
        'If tipoFecha = "FechaIngreso" Then
        '    consulta += " maco_fecha BETWEEN '" & fechaInicio.ToString("dd/MM/yyyy") & " 00:00:00' and '" & fechaFin.ToString("dd/MM/yyyy") & " 23:59:00'"
        'ElseIf tipoFecha = "FechaDocumento" Then
        '    consulta += " maco_fechadocumento BETWEEN '" & fechaInicio.ToString("dd/MM/yyyy") & " 00:00:00' and '" & fechaFin.ToString("dd/MM/yyyy") & " 23:59:00'"
        'ElseIf tipoFecha = "FechaCreacion" Then
        '    consulta += " maco_fechacreacion BETWEEN '" & fechaInicio.ToString("dd/MM/yyyy") & " 00:00:00' and '" & fechaFin.ToString("dd/MM/yyyy") & " 23:59:00'"
        'ElseIf tipoFecha = "FechaVencimiento" Then
        '    consulta += " maco_fechavencimiento BETWEEN '" & fechaInicio.ToString("dd/MM/yyyy") & " 00:00:00' and '" & fechaFin.ToString("dd/MM/yyyy") & " 23:59:00'"
        'End If
        'datos = operaciones.EjecutaConsulta(consulta)
        'Return datos
        Dim listaparametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        'ByVal  As Integer, ByVal  As String, ByVal  As String, ByVal  As Date, ByVal 
        parametro.ParameterName = "@idNave"
        parametro.Value = getNaveSIcy(idNave)
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@estatus"
        parametro.Value = estatus
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@tipoFecha"
        parametro.Value = tipoFecha
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@fechaInicio"
        parametro.Value = fechaInicio
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@fechaFin"
        parametro.Value = fechaFin
        listaparametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Proveedores].[SP_ConsultaComprobantesMaquila]", listaparametros)
    End Function

    Public Function updateEstatusComprobanteMaquila(ByVal comprobante As MaquilaComprobante) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim datos As New DataTable
        Dim consulta As String =
            <cadena>         
            update Proveedores.MaquilaComprobantes 
            </cadena>
        consulta += " set maco_estatus='" & comprobante.estatus & "', maco_motivoSustitucion='" & comprobante.motivo & "' where maco_comprobanteid=" & comprobante.idComprobante
        datos = operaciones.EjecutaConsulta(consulta)
        Return datos
    End Function
    Public Function getDatosComprobantes(ByVal idComprobante As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim datos As New DataTable
        Dim consulta As String =
            <cadena>         
            select  case when maco_tipo='F' Then 1 Else 2 end tipoDoc,maco_proveedorid idProveedor,maco_folio numDoc,
            maco_fechadocumento fechaDoc,maco_fechavencimiento fechaVencimiento,maco_semanapago semanaPago,
            maco_subtotal subTotal,maco_iva iva,maco_total total,1 moneda,maco_naveid idNave,
            maco_aniopago añoSemPago,maco_receptorid idContribuyente,IdBanco,IdCuenta,Contribuyentes.rfc rfcContribuyente,
            Proveedores.RFC rfcProveedor,maco_fecha fecha,maco_folio folio,maco_rutaxml,maco_rutapdf,isnull(maco_descuento,0) 'descuento'
            from Proveedores.MaquilaComprobantes left join Contribuyentes on IDRazSoc=maco_receptorid
            left join CuentasBancarias on IDCtaBco=IdCuenta left join Proveedores on maco_proveedorid=IdProveedor
            </cadena>
        consulta += " where maco_comprobanteid=" & idComprobante
        datos = operaciones.EjecutaConsulta(consulta)
        Return datos
    End Function
    Public Function InsertcxpSaldoscxpMovimientos(ByVal comprobante As MaquilaComprobante) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim datos As New DataTable
        Dim serie As String = ""
        Dim folio As String = ""
        datos = getDatosComprobantes(comprobante.idComprobante)
        If datos.Rows.Count > 0 Then
            Dim separators() As String = {"-"}
            Dim value As String = datos.Rows(0).Item("folio").ToString
            Dim words() As String = value.Split(separators, StringSplitOptions.RemoveEmptyEntries)
            If words.Count > 1 Then
                serie = words(0)
                folio = words(1)
            Else
                folio = words(0)
            End If
            Dim listaparametros As New List(Of SqlParameter)
            Dim parametro As New SqlParameter
            parametro.ParameterName = "@tipoDoc"
            parametro.Value = datos.Rows(0).Item("tipoDoc").ToString
            listaparametros.Add(parametro)
            parametro = New SqlParameter
            parametro.ParameterName = "@idProveedor"
            parametro.Value = datos.Rows(0).Item("idProveedor").ToString
            listaparametros.Add(parametro)
            parametro = New SqlParameter
            parametro.ParameterName = "@numDoc"
            parametro.Value = datos.Rows(0).Item("numDoc").ToString
            listaparametros.Add(parametro)
            parametro = New SqlParameter
            parametro.ParameterName = "@fechaDoc"
            parametro.Value = datos.Rows(0).Item("fechaDoc")
            listaparametros.Add(parametro)
            parametro = New SqlParameter
            parametro.ParameterName = "@fechaVencimiento"
            parametro.Value = datos.Rows(0).Item("fechaVencimiento")
            listaparametros.Add(parametro)
            parametro = New SqlParameter
            parametro.ParameterName = "@semanaPago"
            parametro.Value = datos.Rows(0).Item("semanaPago")
            listaparametros.Add(parametro)
            parametro = New SqlParameter
            parametro.ParameterName = "@semanaPagada"
            parametro.Value = datos.Rows(0).Item("semanaPago")
            listaparametros.Add(parametro)
            parametro = New SqlParameter
            parametro.ParameterName = "@subTotal"
            parametro.Value = datos.Rows(0).Item("subTotal")
            listaparametros.Add(parametro)
            parametro = New SqlParameter
            parametro.ParameterName = "@iva"
            parametro.Value = datos.Rows(0).Item("iva")
            listaparametros.Add(parametro)

            If datos.Rows(0).Item("idNave") = 53 Then
                parametro = New SqlParameter
                parametro.ParameterName = "@nave"
                parametro.Value = 32
                listaparametros.Add(parametro)
            Else
                parametro = New SqlParameter
                parametro.ParameterName = "@nave"
                parametro.Value = getNaveIdAlmacenSIcy(datos.Rows(0).Item("idNave"))
                listaparametros.Add(parametro)
            End If


            parametro = New SqlParameter
            parametro.ParameterName = "@total"
            parametro.Value = datos.Rows(0).Item("total")
            listaparametros.Add(parametro)
            parametro = New SqlParameter
            parametro.ParameterName = "@totalDoc"
            parametro.Value = datos.Rows(0).Item("total")
            listaparametros.Add(parametro)
            parametro = New SqlParameter
            parametro.ParameterName = "@moneda"
            parametro.Value = 1
            listaparametros.Add(parametro)
            parametro = New SqlParameter
            parametro.ParameterName = "@añoSemPago"
            parametro.Value = datos.Rows(0).Item("añoSemPago")
            listaparametros.Add(parametro)
            parametro = New SqlParameter
            parametro.ParameterName = "@usuario"
            parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
            listaparametros.Add(parametro)
            parametro = New SqlParameter
            parametro.ParameterName = "@idContribuyente"
            parametro.Value = datos.Rows(0).Item("idContribuyente")
            listaparametros.Add(parametro)
            parametro = New SqlParameter
            parametro.ParameterName = "@idBanco"
            parametro.Value = datos.Rows(0).Item("idBanco")
            listaparametros.Add(parametro)
            parametro = New SqlParameter
            parametro.ParameterName = "@idCuenta"
            parametro.Value = datos.Rows(0).Item("idCuenta")
            listaparametros.Add(parametro)
            parametro = New SqlParameter
            parametro.ParameterName = "@rfcContribuyente"
            parametro.Value = datos.Rows(0).Item("rfcContribuyente").ToString
            listaparametros.Add(parametro)
            parametro = New SqlParameter
            parametro.ParameterName = "@rfcProveedor"
            parametro.Value = datos.Rows(0).Item("rfcProveedor").ToString
            listaparametros.Add(parametro)
            parametro = New SqlParameter
            parametro.ParameterName = "@fecha"
            parametro.Value = datos.Rows(0).Item("fecha")
            listaparametros.Add(parametro)
            parametro = New SqlParameter
            parametro.ParameterName = "@serie"
            parametro.Value = serie
            listaparametros.Add(parametro)
            parametro = New SqlParameter
            parametro.ParameterName = "@folio"
            parametro.Value = folio
            listaparametros.Add(parametro)
            parametro = New SqlParameter
            parametro.ParameterName = "@rutaXml"
            parametro.Value = datos.Rows(0).Item("maco_rutaxml").ToString
            listaparametros.Add(parametro)
            parametro = New SqlParameter
            parametro.ParameterName = "@rutaPDF"
            parametro.Value = datos.Rows(0).Item("maco_rutapdf").ToString
            listaparametros.Add(parametro)
            parametro = New SqlParameter
            parametro.ParameterName = "@descuento"
            parametro.Value = datos.Rows(0).Item("descuento")
            listaparametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Proveedores].[SP_InsertcxpSaldoscxpMovimientos]", listaparametros)
        End If
        Return New DataTable
    End Function
    Public Function getEmailProveedor(ByVal idProveedor As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim datos As New DataTable
        Dim consulta As String =
            <cadena>         
            SELECT Email,IdProveedor FROM Proveedores 
            </cadena>
        consulta += " where IdProveedor=" & idProveedor
        datos = operaciones.EjecutaConsulta(consulta)
        Return datos
    End Function
    Public Function getInfoIdCompProveedor(ByVal idProveedor As String, ByVal idComprobantes As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim datos As New DataTable
        Dim consulta As String =
            <cadena>         
            SELECT maco_folio 'Folio',Case when maco_tipo='F' then 'Factura' else 'Remisión' end 'Tipo',
            maco_fechadocumento 'Fecha Documento',maco_fecha 'Fecha Ingreso',maco_fechacreacion 'Fecha Captura',
            Proveedores.RazonSocial 'Emisor',Contribuyentes.RazonSocial 'Receptor',maco_total 'Total', maco_semanapago 'Semana Pago'
             from Proveedores.MaquilaComprobantes
            left join Proveedores on maco_proveedorid=IdProveedor
            left join Contribuyentes on IDRazSoc=maco_receptorid
            </cadena>
        consulta += " where maco_proveedorid in (" & idProveedor & ") and maco_comprobanteid in (" & idComprobantes & ")"
        datos = operaciones.EjecutaConsulta(consulta)
        Return datos
    End Function

    Public Function getNaveIdAlmacenSIcy(ByVal idNaveSicy As Integer) As Integer
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim datos As New DataTable
        Dim consulta As String =
            <cadena>
           select idAlmacen from NavesAlmacen where idnave=
            </cadena>
        consulta += " " & idNaveSicy & " "
        datos = operaciones.EjecutaConsulta(consulta)
        If datos.Rows.Count > 0 Then
            Return Convert.ToInt32(datos.Rows(0).Item(0).ToString)
        End If
        Return 0
    End Function
#End Region

End Class
