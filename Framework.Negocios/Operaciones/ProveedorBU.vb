Public Class ProveedorBU

    Public Sub AltaProveedor(ByVal Proveedor As Entidades.Proveedor)
        Dim OBJDA As New Datos.ProveedorDA
        OBJDA.AltaProveedor(Proveedor)
    End Sub

    Public Sub EditarProveedor(ByVal Proveedor As Entidades.Proveedor)
        Dim objda As New Datos.ProveedorDA
        objda.EditarProveedor(Proveedor)
    End Sub
    Public Sub AltaProveedorTiposFletes(ByVal tiposfletes As Entidades.TipoFleteMensajeria)
        Dim objda As New Datos.ProveedorDA
        objda.AltaTiposFleteMensajeria(tiposfletes)
    End Sub

    Public Sub EditarProveedorTiposFletes(ByVal tiposfletes As Entidades.TipoFleteMensajeria)
        Dim objda As New Datos.ProveedorDA
        objda.EditarTiposFleteMensajeria(tiposfletes)
    End Sub

    Public Function DatosProveedor(ByVal IDPersona As Int32) As Entidades.Proveedor
        Dim OBJDA As New Datos.ProveedorDA
        Dim table As New DataTable
        table = OBJDA.DatosProveedor(IDPersona)
        Dim Proveedor As New Entidades.Proveedor
        For Each row As DataRow In table.Rows
            Proveedor.pproveedorid = CInt(row("prov_proveedorid"))
            Try
                Proveedor.pnombregenerico = CStr(row("prov_nombregenerico"))
            Catch ex As Exception

            End Try
            Try
                Proveedor.prazonsocial = CStr(row("prov_razonsocial"))
            Catch ex As Exception

            End Try
            Try
                Proveedor.prfc = CStr(row("prov_rfc"))
            Catch ex As Exception

            End Try
            Try
                Proveedor.pclaveyuyincliente = CInt(row("prov_claveyuyincliente"))
            Catch ex As Exception

            End Try
            Try
                Proveedor.pusuarioweb = CStr(row("prov_usuarioweb"))
            Catch ex As Exception

            End Try
            Try
                Proveedor.pcontrasenaweb = CStr(row("prov_contrasenaweb"))
            Catch ex As Exception

            End Try
            Try
                Proveedor.phorario = CStr(row("prov_horario"))
            Catch ex As Exception

            End Try
            Try
                Proveedor.pcomentarios = CStr(row("prov_comentarios"))
            Catch ex As Exception

            End Try
            Try
                Proveedor.pwebproveedor = CStr(row("prov_sitiowebproveedor"))
            Catch ex As Exception

            End Try

        Next
        Return Proveedor
    End Function

    Public Function GetIDProveedorRecienIngresado(ByVal idPersonav As Int32) As Int32
        Dim OBJDA As New Datos.ProveedorDA
        Dim tabla As New DataTable
        tabla = OBJDA.GetIDProveedorRecienInsertado(idPersonav)
        Dim IdPersona As New Int32
        For Each row As DataRow In tabla.Rows
            IdPersona = CInt(row("prov_proveedorid"))
        Next
        Return IdPersona
    End Function

    Public Function ListaTiposFletes() As DataTable
        Dim objDA As New Datos.ProveedorDA

        Return objDA.ListaTiposFletes

    End Function

    Public Function ListaTiposFletesProveedor(ByVal idProveedor As Int32) As List(Of Entidades.TipoFleteMensajeria)
        Dim objda As New Datos.ProveedorDA
        Dim tabla As New DataTable
        tabla = objda.ListaTiposFletesProveedor(idProveedor)
        ListaTiposFletesProveedor = New List(Of Entidades.TipoFleteMensajeria)
        For Each row As DataRow In tabla.Rows
            Dim TipoFlete As New Entidades.TipoFleteMensajeria
            TipoFlete.tipofleteid = CInt(row("tflm_tipofleteid"))
            TipoFlete.tipofletenombre = CStr(row("tifl_nombre"))
            TipoFlete.tipofletemensajeriaid = CInt(row("tflm_tipofletemensajeriaid"))
            TipoFlete.activo = CBool(row("tflm_activo"))
            TipoFlete.proveedorid = CInt(row("tflm_proveedorid"))
            ListaTiposFletesProveedor.Add(TipoFlete)

        Next

    End Function



End Class
