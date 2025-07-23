Imports Persistencia
Imports System.Data.SqlClient
Imports Entidades
Imports Tools

Public Class ProveedorDA
    'test'
    Dim objAdvertencia As New Tools.AdvertenciaForm
    Dim objConfirmacionGde As New Tools.confirmarFormGrande
    Dim objMensaje As New AdvertenciaForm
    Dim objExito As New Tools.ExitoForm
    Dim objErrores As New Tools.ErroresForm
    Dim objInformacion As New Tools.AvisoForm
    Dim objConfirmacion As New Tools.ConfirmarForm

    Public Function BuscarRazonSocialNoFiscal(ByVal RazonSocial As String, ByVal ProveedorID As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter


        parametro = New SqlParameter
        parametro.ParameterName = "RazonSocial"
        parametro.Value = RazonSocial
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ProveedorID"
        parametro.Value = ProveedorID
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Proveedor].[SP_BuscarRazonSocialNoFiscal]", listaParametros)
    End Function

    Public Function BuscarRazonSocial(ByVal RazonSocial As String, ByVal ProveedorID As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "NombreRazonSocial"
        parametro.Value = RazonSocial
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ProveedorID"
        parametro.Value = ProveedorID
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Proveedor].[SP_BuscarRazonSocial]", listaParametros)
    End Function

    Public Function ActualizarPaisNombreComercial(ByVal Dage_ProveedorID As Integer, ByVal Pais As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "dage_ProveedorID"
        parametro.Value = Dage_ProveedorID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Pais"
        parametro.Value = Pais
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Proveedor].[SP_ActualizarPaisNombreComercial]", listaParametros)
    End Function


    Public Function BuscarNaveNombreComercial(ByVal NaveID As Integer, ByVal Dage_ProveedorID As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "NaveID"
        parametro.Value = NaveID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "dage_ProveedorID"
        parametro.Value = Dage_ProveedorID
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Proveedor].[SP_BuscarNaveNombreComercial]", listaParametros)
    End Function


    Public Function ConsultaGiroClasificacion(ByVal ClasificacionId As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "ClasificacionID"
        parametro.Value = ClasificacionId
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Proveedor].[SP_ConsultaGiroClasificacion]", listaParametros)
    End Function



    Public Function EditarInformacionProveedor2(ByVal Proveedores As Entidades.DatosProveedor) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter



        parametro = New SqlParameter
        parametro.ParameterName = "ProveedorID"
        parametro.Value = Proveedores.prov_ProveedorID
        listaParametros.Add(parametro)


        parametro = New SqlParameter
        parametro.ParameterName = "prov_tiporazonsocial"
        If IsDBNull(Proveedores.prov_tiporazonsocial) = True Then
            parametro.Value = DBNull.Value
        Else
            parametro.Value = Proveedores.prov_tiporazonsocial
        End If
        listaParametros.Add(parametro)


        parametro = New SqlParameter
        parametro.ParameterName = "prov_tipofiscal"
        If IsDBNull(Proveedores.prov_tipofiscal) = True Then
            parametro.Value = DBNull.Value
        Else
            parametro.Value = Proveedores.prov_tipofiscal
        End If
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "prov_colonia"
        parametro.Value = Proveedores.prov_colonia
        listaParametros.Add(parametro)


        parametro = New SqlParameter
        parametro.ParameterName = "prov_ciudad"
        parametro.Value = Proveedores.prov_ciudad
        listaParametros.Add(parametro)


        parametro = New SqlParameter
        parametro.ParameterName = "prov_calle"
        parametro.Value = Proveedores.prov_calle
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "prov_numeroexterior"
        parametro.Value = Proveedores.prov_numeroexterior
        listaParametros.Add(parametro)


        parametro = New SqlParameter
        parametro.ParameterName = "prov_numerointerior"
        If IsDBNull(Proveedores.prov_numerointerior) = True Then
            parametro.Value = DBNull.Value
        Else
            parametro.Value = Proveedores.prov_numerointerior
        End If
        listaParametros.Add(parametro)


        parametro = New SqlParameter
        parametro.ParameterName = "prov_codigopostal"
        parametro.Value = Proveedores.prov_codigopostal
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "prov_estado"
        parametro.Value = Proveedores.prov_estado
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "prov_nombre"
        If IsDBNull(Proveedores.prov_nombre) = True Then
            parametro.Value = DBNull.Value
        Else
            parametro.Value = Proveedores.prov_nombre
        End If
        listaParametros.Add(parametro)


        parametro = New SqlParameter
        parametro.ParameterName = "prov_apellidopaterno"
        If IsDBNull(Proveedores.prov_apellidopaterno) = True Then
            parametro.Value = DBNull.Value
        Else
            parametro.Value = Proveedores.prov_apellidopaterno
        End If
        listaParametros.Add(parametro)


        parametro = New SqlParameter
        parametro.ParameterName = "prov_apellidomaterno"
        If IsDBNull(Proveedores.prov_apellidomaterno) = True Then
            parametro.Value = DBNull.Value
        Else
            parametro.Value = Proveedores.prov_apellidomaterno
        End If
        listaParametros.Add(parametro)


        parametro = New SqlParameter
        parametro.ParameterName = "prov_usuariomodificoid"
        parametro.Value = Proveedores.prov_usuariomodificoid
        listaParametros.Add(parametro)


        parametro = New SqlParameter
        parametro.ParameterName = "prov_fechamodificacion"
        parametro.Value = Proveedores.prov_fechamodificacion
        listaParametros.Add(parametro)


        parametro = New SqlParameter
        parametro.ParameterName = "prov_razonsocial"
        parametro.Value = Proveedores.prov_razonsocial
        listaParametros.Add(parametro)


        parametro = New SqlParameter
        parametro.ParameterName = "prov_pais"
        parametro.Value = Proveedores.prov_pais
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ClasificacionGiroId"
        parametro.Value = Proveedores.prov_clasificaciongiroid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "EstadoID"
        parametro.Value = Proveedores.prov_estadoid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "PaisID"
        parametro.Value = Proveedores.prov_paisid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "CiudadID"
        parametro.Value = Proveedores.prov_ciudadid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Activo"
        parametro.Value = Proveedores.prov_activo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "RFC"
        parametro.Value = Proveedores.prov_rfc
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "prov_sicyid"
        parametro.Value = Proveedores.prov_rfcsicy
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "dage_proveedorid"
        parametro.Value = Proveedores.dage_proveedorid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "NombreGenerico"
        parametro.Value = Proveedores.prov_nombregenerico
        listaParametros.Add(parametro)

        parametro = New SqlParameter("PagoParcialidades", Proveedores.prov_pagoParcialidades)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Proveedor].[SP_EditarInformacionProveedor2]", listaParametros)
    End Function


    Public Function ConsultarProveedoresPorNombreComercial(ByVal dage_proveedorid As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "dage_proveedorid"
        parametro.Value = dage_proveedorid
        listaParametros.Add(parametro)


        Return objPersistencia.EjecutarConsultaSP("[Proveedor].[SP_ConsultaProveedoresPorNombreComercial]", listaParametros)
    End Function



    Public Function ConsultarContactosProveedor(ByVal ProveedorID As Integer, ByVal Activo As Boolean) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "ProveedorID"
        parametro.Value = ProveedorID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Activo"
        parametro.Value = Activo
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Proveedor].[SP_ConsultaContactosProveedor]", listaParametros)
    End Function

    Public Function InsertarRelacionNaveNombreComercial(ByVal NombreComercialID As Integer, ByVal NaveID As Integer, ByVal UsuarioCreoID As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "Dage_Proveedorid"
        parametro.Value = NombreComercialID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "NaveId"
        parametro.Value = NaveID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "UsuarioCreo"
        parametro.Value = UsuarioCreoID
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Proveedor].[SP_InsertarRelacionNaveNombreComercial]", listaParametros)
    End Function

    Public Function AltaNombreComercial(ByVal NombreComercial As String, ByVal PaginaWeb As String, ByVal UsuarioCreoID As Integer, ByVal Pais As String, ByVal PaisId As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter


        parametro = New SqlParameter
        parametro.ParameterName = "NombreComercial"
        parametro.Value = NombreComercial
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "PaginaWeb"
        If PaginaWeb = String.Empty Then
            parametro.Value = DBNull.Value
        Else
            parametro.Value = PaginaWeb
        End If
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "UsuarioCreoID"
        parametro.Value = UsuarioCreoID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Pais"
        If Pais = String.Empty Then
            parametro.Value = DBNull.Value
        Else
            parametro.Value = Pais
        End If

        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "PaisId"
        If PaisId = -1 Then
            parametro.Value = DBNull.Value
        Else
            parametro.Value = PaisId
        End If

        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Proveedor].[SP_InsertarNombreComercial]", listaParametros)
    End Function

    Public Function BuscarExisteRFC(ByVal RFC As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "RFC"
        parametro.Value = RFC
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Proveedor].[SP_BuscarRFC]", listaParametros)
    End Function


    Public Function ConsultaClasificacionGiroProveedor(ByVal ClasificacionGiroID As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "ClasificacionGiroID"
        parametro.Value = ClasificacionGiroID
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Proveedor].[SP_ConsultarClasificacionGiroProveedor]", listaParametros)
    End Function

    Public Function ConsultarPlazosPagoProveedor(ByVal ProveedorId As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "ProveedorID"
        parametro.Value = ProveedorId
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Proveedor].[SP_ConsultaPlazosPagoProveedor]", listaParametros)
    End Function

    Public Function ConsultaInformacionProveedor(ByVal ProveedorID As Integer) As Entidades.DatosProveedor
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Dim DtInformacionProveedor As DataTable
        Dim objDatosProveedor As New Entidades.DatosProveedor

        parametro = New SqlParameter
        parametro.ParameterName = "ProveedorID"
        parametro.Value = ProveedorID
        listaParametros.Add(parametro)


        DtInformacionProveedor = objPersistencia.EjecutarConsultaSP("[Proveedor].[SP_ConsultaInformacionProveedor]", listaParametros)

        If DtInformacionProveedor.Rows.Count > 0 Then

            objDatosProveedor.prov_ProveedorID = DtInformacionProveedor.Rows(0).Item("prov_proveedorid").ToString()
            objDatosProveedor.prov_nombregenerico = DtInformacionProveedor.Rows(0).Item("prov_nombregenerico").ToString()
            objDatosProveedor.prov_rfc = DtInformacionProveedor.Rows(0).Item("prov_rfc").ToString()
            objDatosProveedor.prov_razonsocial = DtInformacionProveedor.Rows(0).Item("prov_razonsocial").ToString()

            If IsDBNull(DtInformacionProveedor.Rows(0).Item("prov_personaidproveedor")) = False Then
                objDatosProveedor.prov_personaidproveedor = DtInformacionProveedor.Rows(0).Item("prov_personaidproveedor").ToString()
            End If

            If IsDBNull(DtInformacionProveedor.Rows(0).Item("prov_clasificacionpersonaid")) = False Then
                objDatosProveedor.prov_clasificacionpersonaid = DtInformacionProveedor.Rows(0).Item("prov_clasificacionpersonaid").ToString()
            End If


            If CBool(DtInformacionProveedor.Rows(0).Item("prov_activo")) = True Then
                objDatosProveedor.prov_activo = 1
            Else
                objDatosProveedor.prov_activo = 0
            End If


            objDatosProveedor.prov_usuariocreoid = DtInformacionProveedor.Rows(0).Item("prov_usuariocreoid").ToString()

            If IsDBNull(DtInformacionProveedor.Rows(0).Item("prov_usuariomodificaid")) = False Then
                objDatosProveedor.prov_usuariomodificoid = DtInformacionProveedor.Rows(0).Item("prov_usuariomodificaid").ToString()
            Else
                objDatosProveedor.prov_usuariomodificoid = -1
            End If

            objDatosProveedor.prov_fechacreacion = DtInformacionProveedor.Rows(0).Item("prov_fechacreacion").ToString()
            If IsDBNull(DtInformacionProveedor.Rows(0).Item("prov_fechamodificacion")) = False Then
                objDatosProveedor.prov_fechamodificacion = DtInformacionProveedor.Rows(0).Item("prov_fechamodificacion").ToString()
            Else
                objDatosProveedor.prov_fechamodificacion = Nothing
            End If

            'objDatosProveedor.prov_fechamodificacion = DtInformacionProveedor.Rows(0).Item("prov_fechamodificacion").ToString()

            If IsDBNull(DtInformacionProveedor.Rows(0).Item("prov_sicyid")) = False Then
                objDatosProveedor.prov_rfcsicy = DtInformacionProveedor.Rows(0).Item("prov_sicyid").ToString()
            End If



            objDatosProveedor.prov_tiporazonsocial = DtInformacionProveedor.Rows(0).Item("prov_tiporazonsocial").ToString()
            objDatosProveedor.prov_tipofiscal = DtInformacionProveedor.Rows(0).Item("prov_tipofiscal").ToString()
            objDatosProveedor.prov_curp = DtInformacionProveedor.Rows(0).Item("prov_curp").ToString()
            objDatosProveedor.prov_colonia = DtInformacionProveedor.Rows(0).Item("prov_colonia").ToString()
            objDatosProveedor.prov_ciudad = DtInformacionProveedor.Rows(0).Item("prov_ciudad").ToString()
            objDatosProveedor.prov_calle = DtInformacionProveedor.Rows(0).Item("prov_calle").ToString()
            objDatosProveedor.prov_numeroexterior = DtInformacionProveedor.Rows(0).Item("prov_numeroexterior").ToString()
            objDatosProveedor.prov_numerointerior = DtInformacionProveedor.Rows(0).Item("prov_numerointerior").ToString()
            objDatosProveedor.prov_codigopostal = DtInformacionProveedor.Rows(0).Item("prov_codigopostal").ToString()
            objDatosProveedor.prov_estado = DtInformacionProveedor.Rows(0).Item("prov_estado").ToString()
            objDatosProveedor.prov_activocompras = DtInformacionProveedor.Rows(0).Item("prov_activocompras").ToString()
            objDatosProveedor.prov_nombre = DtInformacionProveedor.Rows(0).Item("prov_nombre").ToString()
            objDatosProveedor.prov_apellidopaterno = DtInformacionProveedor.Rows(0).Item("prov_apellidopaterno").ToString()
            objDatosProveedor.prov_apellidomaterno = DtInformacionProveedor.Rows(0).Item("prov_apellidomaterno").ToString()
            objDatosProveedor.dage_proveedorid = DtInformacionProveedor.Rows(0).Item("dage_proveedorid").ToString()
            objDatosProveedor.prov_pais = DtInformacionProveedor.Rows(0).Item("prov_pais").ToString()
            objDatosProveedor.prov_paisid = DtInformacionProveedor.Rows(0).Item("prov_paisid").ToString()
            objDatosProveedor.prov_estadoid = DtInformacionProveedor.Rows(0).Item("prov_estadoid").ToString()
            objDatosProveedor.prov_ciudadid = DtInformacionProveedor.Rows(0).Item("prov_ciudadid").ToString()

            If IsDBNull(DtInformacionProveedor.Rows(0).Item("prov_clasificaciongiroid")) = False Then
                objDatosProveedor.prov_clasificaciongiroid = DtInformacionProveedor.Rows(0).Item("prov_clasificaciongiroid").ToString()
            End If

            If IsDBNull(DtInformacionProveedor.Rows(0).Item("dage_nombrecomercial")) = False Then
                objDatosProveedor.dage_nombrecomercial = DtInformacionProveedor.Rows(0).Item("dage_nombrecomercial").ToString()
            End If

            objDatosProveedor.prov_pagoParcialidades = DtInformacionProveedor(0)("PagoParcialidades")

        End If

        Return objDatosProveedor

    End Function



    Public Function ObtenerGiro(ByVal CategoriaID As Integer, ByVal GiroId As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "CategoriaID"
        parametro.Value = CategoriaID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "GiroID"
        parametro.Value = GiroId
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Proveedor].[SP_ObtenerClasificacionGiro]", listaParametros)
    End Function

    Public Function BuscarRFC(ByVal RFC As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "RFC"
        parametro.Value = RFC
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Proveedores].[SP_BuscarRFC]", listaParametros)
    End Function

    Public Function ConsultarProveedorSicy(ByVal ProveedorID As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "ProveedorID"
        parametro.Value = ProveedorID
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Proveedores].[SP_ConsultarProveedor]", listaParametros)
    End Function


    Public Function ConsultaClasificaciones(ByVal Activo As Boolean) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "Activo"
        parametro.Value = Activo
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@ColaboradorID", Entidades.SesionUsuario.UsuarioSesion.PIDColaboradorUser)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Proveedor].[SP_ConsultaClasificaciones]", listaParametros)
    End Function


    Public Function ConsultaTiposRazonSocial() As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Return objPersistencia.EjecutarConsultaSP("[Proveedor].[SP_ConsultaTiposRazonSocial]", listaParametros)
    End Function


    Public Function ConsultaNombresComerciales() As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Return objPersistencia.EjecutarConsultaSP("[Proveedor].[SP_ConsultaNombresComerciales]", listaParametros)
    End Function

    Public Function ConsultaInformacionProveedores(ByVal NaveID As Integer, ByVal Activo As Boolean) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter


        parametro = New SqlParameter
        parametro.ParameterName = "NaveID"
        parametro.Value = NaveID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Activo"
        parametro.Value = Activo
        listaParametros.Add(parametro)


        Return objPersistencia.EjecutarConsultaSP("[Proveedor].[SP_ConsultaProvedores]", listaParametros)

    End Function




    'Alta de datos generales *****ok
    Public Sub AltaDatosGenerales(ByVal Proveedores As Entidades.DatosGenerales)
        Dim operaciones As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "dage_nombrecomercial"
        parametro.Value = Proveedores.dage_nombrecomercial
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "dage_categoria"
        parametro.Value = Proveedores.dage_categoria
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "dage_giro"
        parametro.Value = Proveedores.dage_giro
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "dage_paginaweb"
        If Proveedores.dage_paginaweb = "" Or Proveedores.dage_paginaweb = Nothing Then
            parametro.Value = DBNull.Value
        Else
            parametro.Value = Proveedores.dage_paginaweb
        End If
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "dage_limitedecredito"
        If Proveedores.dage_limitedecredito = Nothing Then
            parametro.Value = DBNull.Value
        Else
            parametro.Value = Proveedores.dage_limitedecredito
        End If
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "dage_tiempodeentrega"
        If Proveedores.dage_tiempodeentrega = "" Or Proveedores.dage_tiempodeentrega = Nothing Then
            parametro.Value = DBNull.Value
        Else
            parametro.Value = Proveedores.dage_tiempodeentrega
        End If
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "dage_tiempoderespuesta"
        If Proveedores.dage_tiempoderespuesta = "" Or Proveedores.dage_tiempoderespuesta = Nothing Then
            parametro.Value = DBNull.Value
        Else
            parametro.Value = Proveedores.dage_tiempoderespuesta
        End If
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "dage_usuariocreoid"
        parametro.Value = Proveedores.dage_usuariocreoid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "dage_usuariomodificoid"
        parametro.Value = Proveedores.dage_usuariomodificoid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "dage_fechacreacion"
        parametro.Value = Proveedores.dage_fechacreacion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "dage_fechamodificacion"
        parametro.Value = Proveedores.dage_fechamodificacion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "dage_activo"
        parametro.Value = Proveedores.dage_activo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "dage_pais"
        parametro.Value = Proveedores.dage_pais
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "dage_paisid"
        parametro.Value = Proveedores.dage_paisid
        listaParametros.Add(parametro)

        operaciones.EjecutarConsultaSP("Proveedor.SP_InsertarDatosGenerales", listaParametros)
        Console.WriteLine("Mando la sentencia")

    End Sub

    Public Sub AltaDatosGeneralesSICY(ByVal Proveedores As Entidades.DatosGeneralesSICY)
        Dim operaciones As New OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "IdProveedor"
        parametro.Value = Proveedores.dage_idProveedorSICY
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "RazonSocial"
        parametro.Value = Proveedores.dage_RazonSocial
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "NomComercial"
        parametro.Value = Proveedores.dage_NombreComercial
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FechaAlta"
        parametro.Value = Proveedores.dage_FechaAlta
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Clasificacion"
        parametro.Value = Proveedores.dage_clasificacion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Tipo"
        parametro.Value = Proveedores.dage_Tipo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Tiempo"
        parametro.Value = Proveedores.dage_Tiempo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Entrega"
        parametro.Value = Proveedores.dage_Entregar
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "DiasCredito"
        parametro.Value = Proveedores.dage_DiasCredito
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "CreditoLimite"
        parametro.Value = Proveedores.dage_CreditoLimite
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Estatus"
        parametro.Value = Proveedores.dage_Estatus
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "DiaPago"
        parametro.Value = Proveedores.dage_DiaPago
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Cadena"
        parametro.Value = Proveedores.dage_Cadena
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "pctFactura"
        parametro.Value = Proveedores.dage_pctFactura
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "checarmanual"
        parametro.Value = Proveedores.dage_checarmanual
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "NombreRepresentanteLegal"
        parametro.Value = Proveedores.dage_NombreRepresentanteLegal
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "PuestoRespresentanteLegal"
        parametro.Value = Proveedores.dage_PuestoRespresentanteLegal
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "EmailRepresentanteLegal"
        parametro.Value = Proveedores.dage_EmailRepresentanteLegal
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "TelRepresentanteLegal"
        parametro.Value = Proveedores.dage_TelRepresentanteLegal
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "CobranzaEmail"
        parametro.Value = Proveedores.dage_CobranzaEmail
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "VentasEmail"
        parametro.Value = Proveedores.dage_VentasEmail
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "HoraPago"
        parametro.Value = Proveedores.dage_HoraPago
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ValidarFolio"
        parametro.Value = Proveedores.dage_ValidarFolio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "TamanoSerie"
        parametro.Value = Proveedores.dage_TamanoSerie
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Series"
        parametro.Value = Proveedores.dage_Series
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "CompletarFolio"
        parametro.Value = Proveedores.dage_CompletarFolio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Observaciones"
        parametro.Value = Proveedores.dage_Observaciones
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "CaracterCompletar"
        parametro.Value = Proveedores.dage_CaracterCompletar
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "TipoFactura"
        parametro.Value = Proveedores.dage_TipoFactura
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "IdCatGiro"
        parametro.Value = Proveedores.dage_IdCatGiro
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idSay"
        parametro.Value = Proveedores.dage_IdProveedor
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "RFC"
        parametro.Value = Proveedores.dage_rfc
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "NomPagoDoc"
        parametro.Value = Proveedores.prov_NomPagoDoc
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Calle"
        parametro.Value = Proveedores.prov_Calle
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Colonia"
        parametro.Value = Proveedores.prov_Colonia
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "CodPost"
        parametro.Value = Proveedores.prov_CodPost
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "CURP"
        parametro.Value = Proveedores.prov_CURP
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "IdCiudad"
        parametro.Value = Proveedores.prov_IdCiudad
        listaParametros.Add(parametro)

        operaciones.EjecutarConsultaSP("dbo.SP_ReplicarProveedorSAY", listaParametros)
        Console.WriteLine("Mando la sentencia")

    End Sub

    Public Sub ModificaDatosGeneralesSICY(ByVal Proveedores As Entidades.DatosGeneralesSICY)
        Dim operaciones As New OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "RazonSocial"
        parametro.Value = Proveedores.dage_RazonSocial
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "NomComercial"
        parametro.Value = Proveedores.dage_NombreComercial
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Clasificacion"
        parametro.Value = Proveedores.dage_clasificacion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Tiempo"
        parametro.Value = Proveedores.dage_Tiempo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Entrega"
        parametro.Value = Proveedores.dage_Entregar
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "CreditoLimite"
        parametro.Value = Proveedores.dage_CreditoLimite
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Estatus"
        parametro.Value = Proveedores.dage_Estatus
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "IdCatGiro"
        parametro.Value = Proveedores.dage_IdCatGiro
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idSay"
        parametro.Value = Proveedores.dage_IdProveedor
        listaParametros.Add(parametro)

        operaciones.EjecutarConsultaSP("dbo.SP_ModificarReplicacionProveedorSAY", listaParametros)
        Console.WriteLine("Mando la sentencia")

    End Sub

    Public Sub AltaRFCSICY(ByVal Proveedores As Entidades.DatosProveedorSICY)

        Dim operaciones As New OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "RazonSocial"
        parametro.Value = Proveedores.prov_RazonSocial
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "NomPagoDoc"
        parametro.Value = Proveedores.prov_NomPagoDoc
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Calle"
        parametro.Value = Proveedores.prov_Calle
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Colonia"
        parametro.Value = Proveedores.prov_Colonia
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "CodPost"
        parametro.Value = Proveedores.prov_CodPost
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "RFC"
        parametro.Value = Proveedores.prov_RFC
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "CURP"
        parametro.Value = Proveedores.prov_CURP
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "IdCiudad"
        parametro.Value = Proveedores.prov_IdCiudad
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "NombreRepresentanteLegal"
        parametro.Value = Proveedores.prov_NombreRepresentanteLegal
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "IdProveedor"
        parametro.Value = Proveedores.prov_IdProveedor
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idsay"
        parametro.Value = Proveedores.prov_idsicy
        listaParametros.Add(parametro)

        operaciones.EjecutarConsultaSP("dbo.SP_ReplicarRFCProveedorSAY", listaParametros)
        Console.WriteLine("Mando la sentencia")

    End Sub

    Public Sub AltaContactoCobranzaSICY(ByVal Proveedores As Entidades.DatosContactoSICY)
        Dim operaciones As New OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "RutaFoto"
        parametro.Value = Proveedores.daco_rutafoto
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "TelCobranza"
        parametro.Value = Proveedores.daco_telcobranza
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ContactoCobranza"
        parametro.Value = Proveedores.daco_contactocobranza
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "CobranzaEmail"
        parametro.Value = Proveedores.daco_CobranzaEmail
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ContactoPAgos"
        parametro.Value = Proveedores.daco_ContactoPagos
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idProveedor"
        parametro.Value = Proveedores.daco_IdProveedor
        listaParametros.Add(parametro)

        operaciones.EjecutarConsultaSP("dbo.SP_ReplicarCobranzaProveedorSAY", listaParametros)
        Console.WriteLine("Mando la sentencia")

    End Sub

    Public Sub AltaContactoVentasSICY(ByVal Proveedores As Entidades.DatosContactoSICY)
        Dim operaciones As New OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "Email"
        parametro.Value = Proveedores.daco_Email
        listaParametros.Add(parametro)


        parametro = New SqlParameter
        parametro.ParameterName = "ContactoVentas"
        parametro.Value = Proveedores.daco_ContactoVentas
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "TelContact"
        parametro.Value = Proveedores.daco_telcontact
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Telefono"
        parametro.Value = Proveedores.daco_Telefono
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "VentasEmail"
        parametro.Value = Proveedores.daco_VentasEmail
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idProveedor"
        parametro.Value = Proveedores.daco_IdProveedor
        listaParametros.Add(parametro)

        operaciones.EjecutarConsultaSP("dbo.SP_ReplicarVendedorProveedorSAY", listaParametros)
        Console.WriteLine("Mando la sentencia")

    End Sub

    Public Sub AltaPlazoSICY(ByVal Proveedores As Entidades.PlazoProveedoresSICY)
        Dim operaciones As New OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "Dias"
        parametro.Value = Proveedores.plpr_DiasCredito
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "IdProveedor"
        parametro.Value = Proveedores.plpr_IdProveedor
        listaParametros.Add(parametro)

        operaciones.EjecutarConsultaSP("dbo.SP_ReplicarDiasPagoProveedorSAY", listaParametros)
        Console.WriteLine("Mando la sentencia")

    End Sub

    Public Sub AltaBancoSICY(ByVal Proveedores As Entidades.DatosDeCuentaBancariaSICY)
        Dim operaciones As New OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "idBanco"
        parametro.Value = Proveedores.banc_idBanco
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "tipcta"
        parametro.Value = Proveedores.banc_tipcta
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "cuentabco"
        parametro.Value = Proveedores.banc_cuentabco
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "cuentahabiente"
        parametro.Value = Proveedores.banc_cuentahabiente
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "usualta"
        parametro.Value = Proveedores.banc_usualta
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idproveedor"
        parametro.Value = Proveedores.banc_idProveedor
        listaParametros.Add(parametro)

        operaciones.EjecutarSentenciaSP("dbo.SP_ReplicarBancoProveedorSAY2", listaParametros)
        Console.WriteLine("Mando la sentencia")

    End Sub

    Public Sub AltaCobradorSICY(ByVal Proveedores As Entidades.DatosCobradorSICY)
        Dim operaciones As New OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "idProveedor"
        parametro.Value = Proveedores.cobr_idproveedor
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idCobrador"
        parametro.Value = Proveedores.cobr_idcobrador
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Nombre"
        parametro.Value = Proveedores.cobr_Nombre
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Estatus"
        parametro.Value = Proveedores.cobr_Estatus
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "UsuCreo"
        parametro.Value = Proveedores.cobr_UsuCreo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fechacreo"
        parametro.Value = Proveedores.cobr_fechacreo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "usumod"
        parametro.Value = Proveedores.cobr_usumod
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fecultmov"
        parametro.Value = Proveedores.cobr_fecultmov
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "RutaFoto"
        parametro.Value = Proveedores.cobr_RutaFoto
        listaParametros.Add(parametro)

        operaciones.EjecutarConsultaSP("dbo.SP_ReplicarCobradorProveedorSAY", listaParametros)
        Console.WriteLine("Mando la sentencia")

    End Sub

    'Alta de datos de contacto ****ok 
    Public Sub AltaDatosContacto(ByVal Proveedores As Entidades.DatosContacto)
        Dim operaciones As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "daco_nombre"
        parametro.Value = Proveedores.daco_nombre()
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "daco_cargo"
        parametro.Value = Proveedores.daco_cargo()
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "daco_telefono"
        parametro.Value = Proveedores.daco_telefono()
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "daco_notificarpago"
        parametro.Value = Proveedores.daco_notificaciondepago()
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "daco_email"
        parametro.Value = Proveedores.daco_email()
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "daco_departamento"
        parametro.Value = Proveedores.daco_departamento()
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "dage_proveedorid"
        parametro.Value = Proveedores.dage_proveedorid()
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "daco_usuariocreoid"
        parametro.Value = Proveedores.daco_usuariocreoid()
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "daco_usuariomodificoid"
        parametro.Value = Proveedores.daco_usuariomodificoid()
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "daco_fechacreacion"
        parametro.Value = Proveedores.daco_fechacreacion()
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "daco_fechamodificacion"
        parametro.Value = Proveedores.daco_fechamodificacion()
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "daco_foto"
        If Proveedores.daco_foto = "" Or Proveedores.daco_foto = Nothing Then
            parametro.Value = DBNull.Value
        Else
            parametro.Value = Proveedores.daco_foto
        End If
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "daco_activo"
        parametro.Value = Proveedores.daco_activo()
        listaParametros.Add(parametro)

        operaciones.EjecutarConsultaSP("Proveedor.SP_InsertarDatosContacto", listaParametros)
        Console.WriteLine("Mando la sentencia")

    End Sub

    'Alta de usuarios de proveedor *****ok
    Public Sub AltaUsuarioProveedor(ByVal Proveedores As Entidades.UsuarioProveedor)
        Dim operaciones As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "dage_proveedorid"
        parametro.Value = Proveedores.dage_proveedorid()
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "upro_fechacreacion"
        parametro.Value = Proveedores.upro_fechacreacion()
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "upro_fechamodificacion"
        parametro.Value = Proveedores.upro_fechamodificacion()
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "upro_password"
        parametro.Value = Proveedores.upro_password()
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "upro_usuario"
        parametro.Value = Proveedores.upro_usuario()
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "upro_nombreUsuario"
        parametro.Value = Proveedores.dage_nombreUsuario()
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "upro_usuariocreoid"
        parametro.Value = Proveedores.upro_usuariocreoid()
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "upro_usuariomodificoid"
        parametro.Value = Proveedores.upro_usuariomodificoid()
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "upro_activo"
        parametro.Value = Proveedores.upro_activo()
        listaParametros.Add(parametro)

        operaciones.EjecutarSentenciaSP("Proveedor.SP_InsertarUsuariosProveedor", listaParametros)
        Console.WriteLine("Mando la sentencia")

    End Sub

    'Alta de cuentas bancarias  ****ok
    Public Sub AltaDatosDeCuentaBancaria(ByVal Proveedores As Entidades.DatosDeCuentaBancaria)
        Dim operaciones As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "dcba_banco"
        parametro.Value = Proveedores.dcba_banco()
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "dcba_cuenta"
        parametro.Value = Proveedores.dcba_cuenta()
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "dcba_clabe"
        parametro.Value = Proveedores.dcba_clabe()
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "dcba_cuentahabiente"
        parametro.Value = Proveedores.dcba_cuentahabiente()
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "dcba_plaza"
        parametro.Value = Proveedores.dcba_plaza()
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "dcba_sucursal"
        parametro.Value = Proveedores.dcba_sucursal()
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "dcba_predeterminada"
        parametro.Value = Proveedores.dcba_predeterminada()
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "dcba_activa"
        parametro.Value = Proveedores.dcba_activa()
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "dcba_fechadealta"
        parametro.Value = Proveedores.dcba_fechadealta()
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "dcba_usuariocreo"
        parametro.Value = Proveedores.dcba_usuariocreoid()
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "dage_proveedorid"
        parametro.Value = Proveedores.dage_proveedorid()
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "dcba_usuariocreoid"
        parametro.Value = Proveedores.dcba_usuariocreoid()
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "dcba_usuariomodificoid"
        parametro.Value = Proveedores.dcba_usuariomodificoid()
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "dcba_fechacreacion"
        parametro.Value = Proveedores.dcba_fechacreacion()
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "dcba_fechamodificacion"
        parametro.Value = Proveedores.dcba_fechamodificacion()
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "dcba_tipodecuenta"
        parametro.Value = Proveedores.dcba_tipodecuenta()
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "dcba_rfc"
        parametro.Value = Proveedores.dcba_rfc()
        listaParametros.Add(parametro)

        operaciones.EjecutarConsultaSP("Proveedor.SP_InsertarDatosDeCuentaBancaria", listaParametros)
        Console.WriteLine("Mando la sentencia")

    End Sub

    'Alta de datos de proveedor *************ok
    Public Function AltaDatosDeProveedor(ByVal Proveedores As Entidades.DatosProveedor) As DataTable

        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)
        Dim operaciones As New OperacionesProcedimientos
        Dim parametro As New SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "prov_razonsocial"
        If Proveedores.prov_razonsocial = "" Or Proveedores.prov_razonsocial = Nothing Then
            parametro.Value = DBNull.Value
        Else
            parametro.Value = Proveedores.prov_razonsocial
        End If
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "prov_rfc"
        If Proveedores.prov_rfc = "" Or Proveedores.prov_rfc = Nothing Then
            parametro.Value = ""
        Else
            parametro.Value = Proveedores.prov_rfc
        End If
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "prov_usuariocreoid"
        parametro.Value = Proveedores.prov_usuariocreoid()
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "prov_usuariomodificaid"
        parametro.Value = Proveedores.prov_usuariomodificoid()
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "prov_fechacreacion"
        parametro.Value = Proveedores.prov_fechacreacion()
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "prov_fechamodificacion"
        parametro.Value = Proveedores.prov_fechamodificacion()
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "prov_sicyid"
        If Proveedores.prov_rfcsicy = -1 Then
            parametro.Value = DBNull.Value
        Else
            parametro.Value = Proveedores.prov_rfcsicy()
        End If


        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "prov_tiporazonsocial"
        If Proveedores.prov_tiporazonsocial = "" Or Proveedores.prov_tiporazonsocial = Nothing Then
            parametro.Value = DBNull.Value
        Else
            parametro.Value = Proveedores.prov_tiporazonsocial
        End If
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "prov_tipofiscal"
        parametro.Value = Proveedores.prov_tipofiscal()
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "prov_curp"
        If Proveedores.prov_curp = "" Or Proveedores.prov_curp = Nothing Then
            parametro.Value = DBNull.Value
        Else
            parametro.Value = Proveedores.prov_curp
        End If
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "prov_colonia"
        parametro.Value = Proveedores.prov_colonia()
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "prov_ciudad"
        parametro.Value = Proveedores.prov_ciudad()
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "prov_calle"
        parametro.Value = Proveedores.prov_calle()
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "prov_numeroexterior"
        parametro.Value = Proveedores.prov_numeroexterior()
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "prov_numerointerior"
        If Proveedores.prov_numerointerior = "" Or Proveedores.prov_numerointerior = Nothing Then
            parametro.Value = DBNull.Value
        Else
            parametro.Value = Proveedores.prov_numerointerior
        End If
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "prov_codigopostal"
        parametro.Value = Proveedores.prov_codigopostal()
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "prov_estado"
        parametro.Value = Proveedores.prov_estado()
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "prov_activocompras"
        If Proveedores.prov_activocompras = "" Or Proveedores.prov_activocompras = Nothing Then
            parametro.Value = DBNull.Value
        Else
            parametro.Value = Proveedores.prov_activocompras()
        End If
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "prov_nombre"
        If Proveedores.prov_nombre = "" Or Proveedores.prov_nombre = Nothing Then
            parametro.Value = DBNull.Value
        Else
            parametro.Value = Proveedores.prov_nombre
        End If
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "prov_apellidopaterno"
        If Proveedores.prov_apellidopaterno = "" Or Proveedores.prov_apellidopaterno = Nothing Then
            parametro.Value = DBNull.Value
        Else
            parametro.Value = Proveedores.prov_apellidopaterno
        End If
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "prov_apellidomaterno"
        If Proveedores.prov_apellidomaterno = "" Or Proveedores.prov_apellidomaterno = Nothing Then
            parametro.Value = DBNull.Value
        Else
            parametro.Value = Proveedores.prov_apellidomaterno
        End If
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "dage_proveedorid"
        parametro.Value = Proveedores.dage_proveedorid()
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "prov_pais"
        parametro.Value = Proveedores.prov_pais()
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "prov_paisid"
        parametro.Value = Proveedores.prov_paisid()
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "prov_estadoid"
        parametro.Value = Proveedores.prov_estadoid()
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "prov_ciudadid"
        parametro.Value = Proveedores.prov_ciudadid()
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "prov_clasificaciongiroid"
        If Proveedores.prov_clasificaciongiroid = -1 Then
            parametro.Value = DBNull.Value
        Else
            parametro.Value = Proveedores.prov_clasificaciongiroid()
        End If

        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "NombreGenerico"
        parametro.Value = Proveedores.prov_nombregenerico
        listaparametros.Add(parametro)

        parametro = New SqlParameter("@PagoParcialidades", Proveedores.prov_pagoParcialidades)
        listaparametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("Proveedor.SP_InsertarProveedor", listaparametros)
        Console.WriteLine("Mando la sentencia")

    End Function

    Public Function BuscarRfcSicy(ByVal rfc As String) As DataTable
        Dim operaciones As New OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)
        Dim parametro As SqlClient.SqlParameter


        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "@rfc"
        parametro.Value = rfc
        ListaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Proveedor].[SP_Proveedpres_BuscarRfcSicy] ", ListaParametros)

    End Function

    Public Function ListaDatosGeneralesProveedor() As DataTable
        Dim operaciones As New OperacionesProcedimientos
        Dim consulta As String = String.Empty
        'If naveid = 0 Then 'mostrar todos los proveedores de todas las naves
        consulta = "select '' as ' ',dage_proveedorid 'ID', dage_nombrecomercial 'NOMBRE COMERCIAL',dage_pais 'PAIS', "
        consulta += "dage_categoria 'CATEGORIA', dage_giroproveedorid 'GIRO', dage_paginaweb 'PAGINA WEB', "
        consulta += "dage_limitedecredito 'LIMITE DE CREDITO', dage_tiempoderespuesta 'RESPUESTA', dage_tiempodeentrega 'ENTREGA',"
        consulta += "dage_activo 'ACTIVO', girp_descripcion 'NOMBRE GIRO', clpe_nombre 'CLASIFICACION' from Proveedor.DatosGenerales,"
        consulta += " Proveedor.GiroProveedor, framework.ClasificacionPersona where Proveedor.DatosGenerales.dage_activo= 'SI' "
        consulta += "and Proveedor.GiroProveedor.girp_giroproveedorid=Proveedor.DatosGenerales.dage_giroproveedorid"
        consulta += "  AND framework.ClasificacionPersona.clpe_clasificacionpersonaid=Proveedor.DatosGenerales.dage_categoria"
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function ListaDatosGeneralesProveedorFiltrarNave(ByVal naveid As Integer, ByVal activa As String) As DataTable
        Dim operaciones As New OperacionesProcedimientos
        Dim consulta As String = String.Empty
        consulta = "SELECT	'' AS ' ',	dg.dage_proveedorid 'ID', dage_nombrecomercial 'NOMBRE COMERCIAL', dage_pais 'PAIS', dage_categoria 'CATEGORIA', dage_giroproveedorid 'GIRO', dage_paginaweb 'PAGINA WEB', dage_limitedecredito 'LIMITE DE CREDITO',dage_tiempoderespuesta 'RESPUESTA',	dage_tiempodeentrega 'ENTREGA',	dage_activo 'ACTIVO', girp_descripcion 'NOMBRE GIRO', clpe_nombre 'CLASIFICACION' FROM	Proveedor.DatosGenerales dg JOIN Proveedor.GiroProveedor gp ON gp.girp_giroproveedorid = dg.dage_giroproveedorid JOIN framework.ClasificacionPersona cp ON cp.clpe_clasificacionpersonaid = dg.dage_categoria JOIN Proveedor.ProveedorNave pn ON pn.dage_proveedorid=dg.dage_proveedorid WHERE dg.dage_activo ='" + activa + "' and pn.nave_naveid=" + naveid.ToString + "order by dg.dage_nombrecomercial"
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function ListaDatosGeneralesProveedorFiltrarNaveNo(ByVal naveid As Integer, ByVal activa As String) As DataTable
        Dim operaciones As New OperacionesProcedimientos
        Dim consulta As String = String.Empty
        consulta = "SELECT	'' AS ' ',	dg.dage_proveedorid 'ID', dage_nombrecomercial 'NOMBRE COMERCIAL', dage_pais 'PAIS', dage_categoria 'CATEGORIA', dage_giroproveedorid 'GIRO', dage_paginaweb 'PAGINA WEB', dage_limitedecredito 'LIMITE DE CREDITO',dage_tiempoderespuesta 'RESPUESTA',	dage_tiempodeentrega 'ENTREGA',	dage_activo 'ACTIVO', girp_descripcion 'NOMBRE GIRO', clpe_nombre 'CLASIFICACION' FROM	Proveedor.DatosGenerales dg JOIN Proveedor.GiroProveedor gp ON gp.girp_giroproveedorid = dg.dage_giroproveedorid JOIN framework.ClasificacionPersona cp ON cp.clpe_clasificacionpersonaid = dg.dage_categoria JOIN Proveedor.ProveedorNave pn ON pn.dage_proveedorid=dg.dage_proveedorid WHERE dg.dage_activo = '" + activa + "' and pn.nave_naveid=" + naveid.ToString + "order by dg.dage_nombrecomercial"
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function ListaDatosGeneralesTodosProveedorFiltrarNaveNo(ByVal naveid As Integer) As DataTable
        Dim operaciones As New OperacionesProcedimientos
        Dim consulta As String = String.Empty
        consulta = "SELECT	'' AS ' ',	dg.dage_proveedorid 'ID', dage_nombrecomercial 'NOMBRE COMERCIAL', dage_pais 'PAIS', dage_categoria 'CATEGORIA', dage_giroproveedorid 'GIRO', dage_paginaweb 'PAGINA WEB', dage_limitedecredito 'LIMITE DE CREDITO',dage_tiempoderespuesta 'RESPUESTA',	dage_tiempodeentrega 'ENTREGA',	dage_activo 'ACTIVO', girp_descripcion 'NOMBRE GIRO', clpe_nombre 'CLASIFICACION' FROM	Proveedor.DatosGenerales dg JOIN Proveedor.GiroProveedor gp ON gp.girp_giroproveedorid = dg.dage_giroproveedorid JOIN framework.ClasificacionPersona cp ON cp.clpe_clasificacionpersonaid = dg.dage_categoria JOIN Proveedor.ProveedorNave pn ON pn.dage_proveedorid=dg.dage_proveedorid WHERE pn.nave_naveid=" + naveid.ToString + "order by dg.dage_nombrecomercial"
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function ListaDatosGeneralesProveedor2() As DataTable
        Dim operaciones As New OperacionesProcedimientos
        Dim consulta As String = String.Empty
        consulta = "select '' as ' ',dage_proveedorid 'ID', dage_nombrecomercial 'NOMBRE COMERCIAL',dage_pais 'PAIS', dage_categoria 'CATEGORIA', dage_giroproveedorid 'GIRO', dage_paginaweb 'PAGINA WEB', dage_limitedecredito 'LIMITE DE CREDITO', dage_tiempoderespuesta 'RESPUESTA', dage_tiempodeentrega 'ENTREGA',dage_activo 'ACTIVO', girp_descripcion 'NOMBRE GIRO', clpe_nombre 'CLASIFICACION' from Proveedor.DatosGenerales, Proveedor.GiroProveedor, framework.ClasificacionPersona where Proveedor.DatosGenerales.dage_activo= 'NO' and Proveedor.GiroProveedor.girp_giroproveedorid=Proveedor.DatosGenerales.dage_giroproveedorid AND framework.ClasificacionPersona.clpe_clasificacionpersonaid=Proveedor.DatosGenerales.dage_categoria order by dage_nombrecomercial"""
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function ListaDatosGeneralesProveedor3() As DataTable
        Dim operaciones As New OperacionesProcedimientos
        Dim consulta As String = String.Empty
        consulta = "select '' as ' ',dage_proveedorid 'ID', dage_nombrecomercial 'NOMBRE COMERCIAL',dage_pais 'PAIS', dage_categoria 'CATEGORIA', dage_giroproveedorid 'GIRO', dage_paginaweb 'PAGINA WEB', dage_limitedecredito 'LIMITE DE CREDITO', dage_tiempoderespuesta 'RESPUESTA', dage_tiempodeentrega 'ENTREGA',dage_activo 'ACTIVO',girp_descripcion 'NOMBRE GIRO', clpe_nombre 'CLASIFICACION' from Proveedor.DatosGenerales, Proveedor.GiroProveedor, framework.ClasificacionPersona where Proveedor.GiroProveedor.girp_giroproveedorid=Proveedor.DatosGenerales.dage_giroproveedorid AND framework.ClasificacionPersona.clpe_clasificacionpersonaid=Proveedor.DatosGenerales.dage_categoria order by dage_nombrecomercial"
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function UltimoIdSICY(ByVal idPersona As Int32) As DataTable
        Dim operaciones As New OperacionesProcedimientosSICY
        Dim consulta As String = String.Empty
        consulta = "SELECT TOP 1 IdProveedor FROM Proveedores ORDER BY IdProveedor DESC"
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function UltimoIdBancoSICY(ByVal idPersona As Int32) As DataTable
        Dim operaciones As New OperacionesProcedimientosSICY
        Dim consulta As String = String.Empty
        consulta = "SELECT TOP 1 idctaProv from CtaBcoProveedor  ORDER BY idctaProv DESC"
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    'combo lista de rfc de x proveedor y no sea igual a -
    Public Function ListaRFC(ByVal idProveedor As Integer) As DataTable
        Dim operaciones As New OperacionesProcedimientos
        Dim consulta As String = String.Empty
        consulta = "select prov_rfc from Proveedor.proveedor where dage_proveedorid = " + idProveedor.ToString + "and prov_rfc Not like '-'"
        Return operaciones.EjecutaConsulta(consulta)
    End Function


    'Combo lista giros
    Public Function ListaDeGiros() As DataTable
        Dim operaciones As New OperacionesProcedimientos
        Dim consulta As String = String.Empty
        consulta = "select girp_giroproveedorid 'ID', girp_descripcion 'GIRO' from Proveedor.GiroProveedor  where girp_activo= 'SI'ORDER BY girp_descripcion asc"
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    'Combo lista de paises
    Public Function ListaPaises() As DataTable
        Dim operaciones As New OperacionesProcedimientos
        Dim consulta As String = String.Empty
        consulta = "select pais_paisid ,pais_nombre from framework.Paises ORDER BY pais_nombre asc"
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    'Combo lista de categorias
    Public Function ListaCategorias() As DataTable
        Dim operaciones As New OperacionesProcedimientos
        Dim consulta As String = String.Empty
        consulta = "select clpe_nombre 'CLASIFICACION',clpe_clasificacionpersonaid 'ID' from framework.ClasificacionPersona WHERE clpe_clasepersonaid=4"
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    'Combo lista de bancos
    Public Function ListaBancos() As DataTable
        Dim operaciones As New OperacionesProcedimientos
        Dim consulta As String = String.Empty
        consulta = "select banc_bancoid, banc_nombre from Framework.Bancos where banc_activo=1 "
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    'Combo lista de estados
    Public Function ListaEstados(ByVal paisid As Integer) As DataTable
        Dim operaciones As New OperacionesProcedimientos
        Dim consulta As String = String.Empty
        consulta = "select esta_estadoid ,esta_nombre from framework.Estados where esta_paisid = " + paisid.ToString + " ORDER BY esta_nombre asc"
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function BuscaRazonSocial(ByVal rfc As String, ByVal id As Integer) As DataTable
        Dim operaciones As New OperacionesProcedimientos
        Dim consulta As String = String.Empty
        consulta = "select prov_razonsocial from Proveedor.proveedor where prov_rfc like'%" + rfc.ToString + "%' and dage_proveedorid=" + id.ToString
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function BuscaRfcSicyCta(ByVal rfc As String) As DataTable
        Dim operaciones As New OperacionesProcedimientosSICY
        Dim consulta As String = String.Empty
        consulta = "select idProveedor from Proveedores where RFC like'%" + rfc.ToString + "%'"
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function BuscarNumCobrador(ByVal idProveedor As Integer) As DataTable
        Dim operaciones As New OperacionesProcedimientosSICY
        Dim consulta As String = String.Empty
        consulta = "select * from CXPProveedorCobrador where idProveedor = " + idProveedor.ToString
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function RazonSocial(ByVal Razon As Integer) As DataTable
        Dim operaciones As New OperacionesProcedimientos
        Dim consulta As String = String.Empty
        consulta = "select prov_razonsocial from Proveedor.proveedor where dage_proveedorid=" + Razon.ToString + " and prov_tiporazonsocial like 'NO FISCAL'"
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    'Combo lista de ciudades
    Public Function ListaCiudades(ByVal estadoid As Integer) As DataTable
        Dim operaciones As New OperacionesProcedimientos
        Dim consulta As String = String.Empty
        consulta = "select city_ciudadid,city_nombre from framework.Ciudades where city_estadoid = " + estadoid.ToString + " ORDER BY city_nombre asc"
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function ListaTiposRFC() As DataTable
        Dim operaciones As New OperacionesProcedimientos
        Dim consulta As String = String.Empty
        consulta = "select  tirz_tiporazonsocialid 'ID', tirz_abreviacion 'Tipo' from proveedor.TipoRazonSocial"
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function ListaProveedorRFC(ByVal idProveedor As Integer) As DataTable
        Dim operaciones As New OperacionesProcedimientos
        Dim consulta As String = String.Empty
        consulta = "select  prov_proveedorid 'ID',prov_razonsocial 'RAZON SOCIAL',prov_rfc'RFC',prov_sicyid 'ID SICY',prov_activoordenesdecompra'ACTIVO OC',prov_activocompras'ACTIVO COMPRAS',prov_activopagos'ACTIVO PAGOS',prov_calle'CALLE',prov_numeroexterior'NUMERO EXTERIOR',prov_numerointerior'NUMERO INTERIOR',prov_colonia'COLONIA',prov_ciudad'CIUDAD',prov_estado'ESTADO',prov_pais'PAIS',prov_nombre'NOMBRE',prov_apellidomaterno'APELLIDO MATERNO',prov_apellidopaterno'APELLIDO PATERNO',prov_tipofiscal'TIPO RAZON SOCIAL',prov_curp 'CURP', prov_codigopostal 'CP',prov_activopagos 'AP', prov_activocompras 'AC',prov_tiporazonsocial 'TIPO FISCAL', prov_paisid 'IDP', prov_estadoid 'IDE', prov_ciudadid 'IDC' from Proveedor.Proveedor  where dage_proveedorid = " + idProveedor.ToString
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function ListaPlazo(ByVal idProveedor As Integer) As DataTable
        Dim operaciones As New OperacionesProcedimientos
        Dim consulta As String = String.Empty
        consulta = "select cast( '0' as bit) as ' ', plpa_plazopagoid 'ID',plpa_plazo 'PLAZO',plpa_dias 'DIAS',plpa_activo 'ACTIVO' from Proveedor.PlazoPago "
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function ListaPlazoProveedor(ByVal idProveedor As Integer) As DataTable
        Dim operaciones As New OperacionesProcedimientos
        Dim consulta As String = String.Empty
        consulta = "select plpr_plazoproveedorid 'ID',plpa_plazo 'PLAZO PAGO',plpa_dias 'DIAS' from Proveedor.PlazoProveedor pr, proveedor.PlazoPago pp where pr.dage_proveedorid=" + idProveedor.ToString + " and pp.plpa_plazopagoid=pr.plpa_plazopagoid "
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function ListaNavesProveedor(ByVal idProveedor As Integer) As DataTable
        Dim operaciones As New OperacionesProcedimientos
        Dim consulta As String = String.Empty
        consulta = "select pn.prna_datonaveid '1' , pn.nave_naveid '2' ,na.nave_naveid '3', na.nave_nombre 'NAVE'from Proveedor.ProveedorNave pn, Framework.Naves na where dage_proveedorid= " + idProveedor.ToString + " and prna_activo ='SI' and  na.nave_naveid= pn.nave_naveid"
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function BuscaUsuarioRepetido(ByVal nombre As String, ByVal usuario As String, ByVal id As Integer) As DataTable
        Dim operaciones As New OperacionesProcedimientos
        Dim consulta As String = String.Empty
        consulta = "select * from Proveedor.UsuariosProveedor  where upro_usuario = '" + usuario.ToString + "' and upro_nombreUsuario = '" + nombre.ToString + "' and dage_proveedorid= " + id.ToString
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function BuscaProveedorRepetido(ByVal nombre As String) As DataTable
        Dim operaciones As New OperacionesProcedimientos
        Dim consulta As String = String.Empty
        consulta = "select * from Proveedor.DatosGenerales  where dage_nombrecomercial = '" + nombre.ToString + "'"
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function BusquedaGrande(ByVal nombre As String) As DataTable
        Dim operaciones As New OperacionesProcedimientos
        Dim consulta As String = String.Empty
        consulta = "select p.prov_proveedorid 'p', b.dcba_banco 'b', u.upro_usuario 'u',c.daco_datoscontactoid 'c',p.dage_proveedorid 'pl',"
        consulta += "n.nave_naveid 'n' from Proveedor.Proveedor as p join Proveedor.DatosDeCuentaBancaria as b on p.dage_proveedorid=b.dage_proveedorid"
        consulta += " join Proveedor.UsuariosProveedor as u on u.dage_proveedorid= p.dage_proveedorid join Proveedor.DatosContacto as c"
        consulta += " on c.dage_proveedorid= p.dage_proveedorid join Proveedor.PlazoProveedor as pl on p.dage_proveedorid=pl.dage_proveedorid"
        consulta += " join Proveedor.ProveedorNave as n on n.dage_proveedorid=p.dage_proveedorid where p.dage_proveedorid=" + nombre.ToString
        Return operaciones.EjecutaConsulta(consulta)
    End Function


    Public Function BuscaAlgunRfc(ByVal nombre As String) As DataTable
        Dim operaciones As New OperacionesProcedimientos
        Dim consulta As String = String.Empty
        consulta = "select prov_proveedorid from Proveedor.Proveedor where dage_proveedorid= '" + nombre.ToString + "'"
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function BuscaAlgunaCuenta(ByVal nombre As String) As DataTable
        Dim operaciones As New OperacionesProcedimientos
        Dim consulta As String = String.Empty
        consulta = "select dcba_banco from Proveedor.DatosDeCuentaBancaria where dage_proveedorid= '" + nombre.ToString + "'"
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function BuscaAlgunUsuario(ByVal nombre As String) As DataTable
        Dim operaciones As New OperacionesProcedimientos
        Dim consulta As String = String.Empty
        consulta = "select upro_usuario from Proveedor.UsuariosProveedor where dage_proveedorid= '" + nombre.ToString + "'"
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function BuscaAlgunContacto(ByVal nombre As String) As DataTable
        Dim operaciones As New OperacionesProcedimientos
        Dim consulta As String = String.Empty
        consulta = "select daco_datoscontactoid from Proveedor.DatosContacto where dage_proveedorid= '" + nombre.ToString + "'"
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function BuscaAlgunPlazo(ByVal nombre As String) As DataTable
        Dim operaciones As New OperacionesProcedimientos
        Dim consulta As String = String.Empty
        consulta = "select plpr_plazoproveedorid from Proveedor.PlazoProveedor where dage_proveedorid= '" + nombre.ToString + "'"
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function BuscaAlgunaNave(ByVal nombre As String) As DataTable
        Dim operaciones As New OperacionesProcedimientos
        Dim consulta As String = String.Empty
        consulta = "select prna_datonaveid from Proveedor.ProveedorNave where dage_proveedorid= '" + nombre.ToString + "'"
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    ''' <summary>
    ''' Buscar coincidencias en registros
    ''' </summary>
    ''' <param name="nombre"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' 
    Public Function BuscaCoincidenciaNombre(ByVal nombre As String) As DataTable
        Dim operaciones As New OperacionesProcedimientos
        Dim consulta As String = String.Empty
        Dim count As Integer
        Dim separators() As String = {",", ".", "!", "?", ";", ":", "#", "-", "/", "\", " Y ", " DE "}
        Dim busqueda() As String = nombre.Split
        Dim tamano As Integer = nombre.Length / 4

        consulta = "select  UPPER (dg.dage_nombrecomercial) 'NOMBRE COMERCIAL',UPPER (p.prov_razonsocial) 'RAZON SOCIAL',"
        consulta += " UPPER (p.prov_rfc) 'RFC', dg.dage_proveedorid 'ID SAY',p.prov_sicyid 'ID SICY'  "
        consulta += " from Proveedor.DatosGenerales as dg "
        consulta += " RIGHT JOIN Proveedor.Proveedor as p  on p.dage_proveedorid=dg.dage_proveedorid "
        consulta += "   WHERE"
        consulta += " (dg.dage_nombrecomercial LIKE '%" & nombre & "%'"
        For Each word In busqueda
            If word.Length > 3 Then
                consulta += " OR dg.dage_nombrecomercial like '%" & word.Substring(0, 4) & "%'"
            End If
        Next
        consulta += ") OR (p.prov_razonsocial LIKE '%" & nombre & "%'"

        For Each word In busqueda
            If word.Length > 3 Then
                consulta += "  OR p.prov_razonsocial LIKE '%" & word.Substring(0, 4) & "%'"
            End If
        Next
        consulta += ")"

        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function BuscaCoincidenciaNombreDAGE(ByVal nombre As String) As DataTable
        Dim operaciones As New OperacionesProcedimientos
        Dim consulta As String = String.Empty
        Dim count As Integer
        Dim busqueda() As String = nombre.Split(" ")
        Dim tamano As Integer = nombre.Length / 4

        Dim TxtLen As Integer = Len(nombre) 'Longitud de la cadena a escribir 
        Dim Bloques As Integer
        Dim cadena(tamano - 1) As String
        'Para contar el numero de bloques de memoria 
        If (TxtLen Mod 4) > 0 Then
            Bloques = (TxtLen * 4) + 1
        Else
            Bloques = TxtLen / 4
        End If
        'Para separar el texto en bloques de 4 
        For i As Integer = 0 To tamano - 1
            cadena(i) = Mid(nombre, 1 + i * 4, 4)
        Next
        consulta = "select dg.dage_proveedorid 'ID', dg.dage_nombrecomercial 'NOMBRE COMERCIAL', n.nave_nombre 'NAVE' from Proveedor.ProveedorNave as pm join Proveedor.DatosGenerales as dg"
        consulta += " on dg.dage_proveedorid=pm.dage_proveedorid join Framework.Naves as n on n.nave_naveid=pm.nave_naveid"
        consulta += " where "
        For count = 0 To tamano - 1
            If count = 0 Then
                consulta += " (dage_nombrecomercial LIKE '%" + cadena(count) + "%'"
            ElseIf cadena(count).Length > 2 Then
                consulta += " OR dage_nombrecomercial LIKE '%" + cadena(count) + "%'"
            End If
        Next
        consulta += ")"
        Return operaciones.EjecutaConsulta(consulta)
    End Function
    '*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*--*--*-*-*-*-*-*-*-*-*-*/-*-*-*-*-*-*-*-/-/-*/**-

    '*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*--*--*-*-*-*-*-*-*-*-*-*/-*-*-*-*-*-*-*-/-/-*/**-

    '*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*--*--*-*-*-*-*-*-*-*-*-*/-*-*-*-*-*-*-*-/-/-*/**-
    Public Function BuscaCoincidenciaRFC(ByVal rfc As String) As DataTable
        Dim operaciones As New OperacionesProcedimientos
        Dim consulta As String = String.Empty
        consulta = "select prov_sicyid 'SICY ID',prov_razonsocial'RAZON SOCIAL',prov_nombregenerico 'NOMBRE COMERCIAL',prov_rfc 'RFC'"
        consulta += " from Proveedor.Proveedor where prov_rfc like ('%" & rfc & "%')"
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function BuscaCoincidenciaNombreRazonSocial(ByVal rfc As String) As DataTable
        Dim operaciones As New OperacionesProcedimientos
        Dim consulta As String = String.Empty
        Dim count As Integer
        Dim busqueda() As String = rfc.Split(" ")
        consulta = "select IdProveedor 'SICY ID', RazonSocial 'RAZON SOCIAL', NomComercial 'NOMBRE COMERCIAL', RFC 'RFC' from Yuyin2_NOBORRAR.[dbo].[Proveedores] where  "
        For count = 0 To busqueda.Length - 1
            If count = 0 Then
                consulta += " (RazonSocial like '%" + busqueda(count) + "%'"
            End If
        Next
        consulta += ")"
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function BuscaCoincidenciaRazonSocial(ByVal razonSocial As String) As DataTable
        Dim operaciones As New OperacionesProcedimientos
        Dim busqueda() As String = razonSocial.Split(" ")
        Dim consulta As String = String.Empty
        consulta =
            <CADENA>
                SELECT prov_nombregenerico FROM Proveedor.Proveedor
            </CADENA>
        consulta += " where (prov_nombregenerico like '%" + Left(razonSocial, 4) + "%')"
        Return operaciones.EjecutaConsulta(consulta)
    End Function


    Public Function BuscaGiroRepetido(ByVal giro As String) As DataTable
        Dim operaciones As New OperacionesProcedimientos
        Dim consulta As String = String.Empty
        Dim tamano As Integer = giro.Length
        Dim cadena(tamano - 1) As String
        For i As Integer = 0 To tamano - 1
            cadena(i) = Mid(giro, 1 + i * 4, 4)
        Next

        consulta = "select girp_descripcion from Proveedor.GiroProveedor  where girp_descripcion like '%" + Left(giro, 4) + "%'"

        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function BuscaGiroRepetidoNoActivo(ByVal giro As String) As DataTable
        Dim operaciones As New OperacionesProcedimientos
        Dim consulta As String = String.Empty
        Dim tamano As Integer = giro.Length
        Dim cadena(tamano - 1) As String
        For i As Integer = 0 To tamano - 1
            cadena(i) = Mid(giro, 1 + i * 4, 4)
        Next
        consulta = "select girp_descripcion from Proveedor.GiroProveedor  where girp_descripcion like '%" + giro + "%' and girp_activo='NO' "
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function BuscaUsuarioPlazoRepetido(ByVal id As Integer, idproveedor As Integer) As DataTable
        Dim operaciones As New OperacionesProcedimientos
        Dim consulta As String = String.Empty
        consulta = "select * from Proveedor.PlazoProveedor  where plpa_plazopagoid= " + id.ToString + " and dage_proveedorid = " + idproveedor.ToString
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function BuscaUsuarioNaveRepetida(ByVal id As Integer, idproveedor As Integer) As DataTable
        Dim operaciones As New OperacionesProcedimientos
        Dim consulta As String = String.Empty
        consulta = "select * from Proveedor.ProveedorNave  where nave_naveid= " + id.ToString + " and dage_proveedorid = " + idproveedor.ToString
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function BuscaContactoRepetido(ByVal nombre As String, ByVal cargo As String, ByVal departamento As String, ByVal proveedorid As Integer) As DataTable
        Dim operaciones As New OperacionesProcedimientos
        Dim consulta As String = String.Empty
        consulta = "select * from Proveedor.DatosContacto  where daco_nombre = '" + nombre.ToString + "'  and daco_departamento = '" + departamento.ToString + "'  and dage_proveedorid = '" + proveedorid.ToString + "'"
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function ListaUsuariosSitioProveedor(ByVal idProveedor As Integer) As DataTable
        Dim operaciones As New OperacionesProcedimientos
        Dim consulta As String = String.Empty
        consulta = "select upro_usuarioproveedorid 'ID', upro_nombreUsuario 'NOMBRE USUARIO',upro_usuario 'USUARIO',upro_password 'PASSWORD',upro_activo 'ACTIVO' from Proveedor.UsuariosProveedor where dage_proveedorid = " + idProveedor.ToString
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function listaCuentasBancarias(ByVal idProveedor As Int32) As DataTable
        Dim operaciones As New OperacionesProcedimientos
        Dim consulta As String = String.Empty
        consulta = "select dcba_banco 'BANCO',dcba_cuenta 'CUENTA',dcba_clabe 'CLABE',dcba_cuentahabiente 'CUENTAHABIENTE',dcba_predeterminada 'PREDETERMINADA',dcba_activa 'ACTIVA' from Proveedor.DatosDeCuentaBancaria where dage_proveedorid =" + idProveedor.ToString
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function listaCuentasBancariasCompleta(ByVal idProveedor As Int32) As DataTable
        Dim operaciones As New OperacionesProcedimientos
        Dim consulta As String = String.Empty
        consulta = "select dcba_datosdecuentabancariaid'ID',dcba_banco'BANCO',dcba_cuenta'CUENTA',dcba_clabe'CLABE',dcba_cuentahabiente'CUENTAHABIENTE',dcba_plaza'PLAZA',dcba_sucursal'SUCURSAL',dcba_predeterminada'PREDETERMINADA',dcba_activa'ACTIVA',dcba_rfc'RFC',dcba_tipodecuenta'TIPO DE CUENTA' from Proveedor.DatosDeCuentaBancaria where dage_proveedorid =" + idProveedor.ToString
        Return operaciones.EjecutaConsulta(consulta)
    End Function


    Public Function listaContactosVentasCompleta(ByVal idProveedor As Int32) As DataTable
        Dim operaciones As New OperacionesProcedimientos
        Dim consulta As String = String.Empty
        consulta = "select daco_datoscontactoid'ID',daco_nombre 'NOMBRE',daco_cargo 'CARGO',daco_telefono 'TELEFONO',daco_email 'EMAIL',daco_foto 'RUTA FOTO',daco_departamento'DEPARTAMENTO',daco_notificacionpago'NOTIFICACION DE PAGO', daco_activo 'ACTIVO' from Proveedor.DatosContacto where dage_proveedorid =" + idProveedor.ToString + " and daco_departamento = 'VENTAS' and daco_activo='SI'"
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function listaContactosVentasCompleta2(ByVal idProveedor As Int32) As DataTable
        Dim operaciones As New OperacionesProcedimientos
        Dim consulta As String = String.Empty
        consulta = "select daco_datoscontactoid'ID',daco_nombre 'NOMBRE',daco_cargo 'CARGO',daco_telefono 'TELEFONO',daco_email 'EMAIL',daco_foto 'RUTA FOTO',daco_departamento'DEPARTAMENTO',daco_notificacionpago'NOTIFICACION DE PAGO', daco_activo 'ACTIVO' from Proveedor.DatosContacto where dage_proveedorid =" + idProveedor.ToString + " and daco_departamento = 'VENTAS' and daco_activo ='NO'"
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function listaContactosCobranzaCompleta(ByVal idProveedor As Int32) As DataTable
        Dim operaciones As New OperacionesProcedimientos
        Dim consulta As String = String.Empty
        consulta = "select daco_datoscontactoid'ID',daco_nombre 'NOMBRE',daco_cargo 'CARGO',daco_telefono 'TELEFONO',daco_email 'EMAIL',daco_foto 'RUTA FOTO',daco_departamento'DEPARTAMENTO',daco_notificacionpago'NOTIFICACION DE PAGO', daco_activo 'ACTIVO' from Proveedor.DatosContacto where dage_proveedorid =" + idProveedor.ToString + " and daco_departamento = 'COBRANZA' and daco_activo='SI'"
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function listaContactosCobranzaCompleta2(ByVal idProveedor As Int32) As DataTable
        Dim operaciones As New OperacionesProcedimientos
        Dim consulta As String = String.Empty
        consulta = "select daco_datoscontactoid'ID',daco_nombre 'NOMBRE',daco_cargo 'CARGO',daco_telefono 'TELEFONO',daco_email 'EMAIL',daco_foto 'RUTA FOTO',daco_departamento'DEPARTAMENTO',daco_notificacionpago'NOTIFICACION DE PAGO', daco_activo 'ACTIVO' from Proveedor.DatosContacto where dage_proveedorid =" + idProveedor.ToString + " and daco_departamento = 'COBRANZA' and  daco_activo= 'NO'"
        Return operaciones.EjecutaConsulta(consulta)
    End Function


    'Lista de naves
    Public Function listaNaves() As DataTable
        Dim operaciones As New OperacionesProcedimientos
        Dim consulta As String = String.Empty
        consulta = "select cast('0' as bit) as ' ', nave_naveid  'NAVE ID', nave_nombre  'NOMBRE', nave_navesicyid  'ID SICY' from Framework.Naves where nave_activo=1"
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    'Lista de naves con combo
    Public Function listaNavesCombo() As DataTable
        Dim operaciones As New OperacionesProcedimientos
        Dim consulta As String = String.Empty
        consulta = "select 0 ' ', nave_naveid  'ID', nave_nombre  'NOMBRE ', nave_navesicyid  'ID SICY' from Framework.Naves where nave_activo=1"
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function listaUsuariosActivosProveedor(ByVal proveedorid As Int32) As DataTable
        Dim operaciones As New OperacionesProcedimientos
        Dim consulta As String = String.Empty
        consulta = "select upro_usuarioproveedorid 'ID',upro_nombreUsuario 'NOMBRE USUARIO', upro_usuario 'USUARIO', upro_password 'PASSWORD',upro_activo'ACTIVO' from Proveedor.UsuariosProveedor where dage_proveedorid =" + proveedorid.ToString + "and upro_activo='SI'"
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function listaUsuariosInactivosProveedor(ByVal proveedorid As Int32) As DataTable
        Dim operaciones As New OperacionesProcedimientos
        Dim consulta As String = String.Empty
        consulta = "select upro_usuarioproveedorid 'ID',upro_nombreUsuario 'NOMBRE USUARIO', upro_usuario 'USUARIO', upro_password 'PASSWORD' ,upro_activo'ACTIVO' from Proveedor.UsuariosProveedor where dage_proveedorid =" + proveedorid.ToString + "and upro_activo='NO'"
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function GetIDProveedorRecienInsertado(ByVal idPersona As Int32) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "" +
                "SELECT top 1 (dage_proveedorid) from Proveedor.DatosGenerales order by dage_proveedorid DESC"
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    'Modificacion de datos Generales de proveedor
    Public Sub ModificarDatosGenerales(ByVal Proveedores As Entidades.DatosGenerales)
        Dim operaciones As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "dage_proveedorid"
        parametro.Value = Proveedores.dage_proveedorid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "dage_nombrecomercial"
        parametro.Value = Proveedores.dage_nombrecomercial
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "dage_categoria"
        parametro.Value = Proveedores.dage_categoria
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "dage_giro"
        parametro.Value = Proveedores.dage_giro
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "dage_paginaweb"
        If Proveedores.dage_paginaweb = "" Or Proveedores.dage_paginaweb = Nothing Then
            parametro.Value = DBNull.Value
        Else
            parametro.Value = Proveedores.dage_paginaweb
        End If
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "dage_limitedecredito"
        If Proveedores.dage_limitedecredito < 1 Then
            parametro.Value = 1
        Else
            parametro.Value = Proveedores.dage_limitedecredito
        End If
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "dage_tiempodeentrega"
        If Proveedores.dage_tiempodeentrega = "" Or Proveedores.dage_tiempodeentrega = Nothing Then
            parametro.Value = DBNull.Value
        Else
            parametro.Value = Proveedores.dage_tiempodeentrega
        End If
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "dage_tiempoderespuesta"
        If Proveedores.dage_tiempoderespuesta = "" Or Proveedores.dage_tiempoderespuesta = Nothing Then
            parametro.Value = DBNull.Value
        Else
            parametro.Value = Proveedores.dage_tiempoderespuesta
        End If
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "dage_usuariomodificoid"
        parametro.Value = Proveedores.dage_usuariomodificoid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "dage_fechamodificacion"
        parametro.Value = Proveedores.dage_fechamodificacion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "dage_pais"
        parametro.Value = Proveedores.dage_pais
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "dage_activo"
        parametro.Value = Proveedores.dage_activo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "dage_paisid"
        parametro.Value = Proveedores.dage_paisid
        listaParametros.Add(parametro)

        operaciones.EjecutarSentenciaSP("Proveedor.SP_EditarDatosGenerales", listaParametros)
        Console.WriteLine("Mando la sentencia")

    End Sub

    'Modificacionlta de datos de contacto
    Public Sub ModificacionContacto(ByVal Proveedores As Entidades.DatosContacto)
        Dim operaciones As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "daco_nombre"
        parametro.Value = Proveedores.daco_nombre()
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "daco_cargo"
        parametro.Value = Proveedores.daco_cargo()
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "daco_telefono"
        parametro.Value = Proveedores.daco_telefono()
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "daco_notificacionpago"
        parametro.Value = Proveedores.daco_notificaciondepago()
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "daco_email"
        parametro.Value = Proveedores.daco_email()
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "daco_departamento"
        parametro.Value = Proveedores.daco_departamento()
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "daco_usuariomodificoid"
        parametro.Value = Proveedores.daco_usuariomodificoid()
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "daco_fechamodificacion"
        parametro.Value = Proveedores.daco_fechamodificacion()
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "daco_foto"
        parametro.Value = Proveedores.daco_foto()
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "daco_datoscontactoid"
        parametro.Value = Proveedores.daco_datoscontactoid()
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "daco_activo"
        parametro.Value = Proveedores.daco_activo()
        listaParametros.Add(parametro)

        operaciones.EjecutarConsultaSP("Proveedor.SP_EditarContactos", listaParametros)
        Console.WriteLine("Mando la sentencia")

    End Sub

    Public Sub DesactivarRFC(ByVal proveedores As Entidades.DatosProveedor)
        Dim operaciones As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "dage_proveedorid"
        parametro.Value = proveedores.dage_proveedorid()
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "prov_usuariomodificoid"
        parametro.Value = proveedores.prov_usuariomodificoid()
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "prov_fechamodificacion"
        parametro.Value = proveedores.prov_fechamodificacion()
        listaParametros.Add(parametro)

        operaciones.EjecutarConsultaSP("Proveedor.SP_DesactivarRFC", listaParametros)
        Console.WriteLine("Mando la sentencia")

    End Sub

    Public Sub DesactivarCuenta(ByVal Proveedores As Entidades.DatosDeCuentaBancaria)
        Dim operaciones As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "dage_proveedorid"
        parametro.Value = Proveedores.dage_proveedorid()
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "dcba_usuariomodificoid"
        parametro.Value = Proveedores.dcba_usuariomodificoid()
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "dcba_fechamodificacion"
        parametro.Value = Proveedores.dcba_fechamodificacion()
        listaParametros.Add(parametro)


        operaciones.EjecutarConsultaSP("Proveedor.SP_DesactivarCuenta", listaParametros)
        Console.WriteLine("Mando la sentencia")

    End Sub

    Public Sub DesactivarContacto(ByVal Proveedores As Entidades.DatosContacto)
        Dim operaciones As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "dage_proveedorid"
        parametro.Value = Proveedores.dage_proveedorid()
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "daco_usuariomodificoid"
        parametro.Value = Proveedores.daco_usuariomodificoid()
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "daco_fechamodificacion"
        parametro.Value = Proveedores.daco_fechamodificacion()
        listaParametros.Add(parametro)

        operaciones.EjecutarConsultaSP("Proveedor.SP_DesactivarContacto", listaParametros)
        Console.WriteLine("Mando la sentencia")

    End Sub

    Public Sub DesactivarUsuario(ByVal Proveedores As Entidades.UsuarioProveedor)
        Dim operaciones As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "dage_proveedorid"
        parametro.Value = Proveedores.dage_proveedorid()
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "upro_usuariomodificoid"
        parametro.Value = Proveedores.upro_usuariomodificoid()
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "upro_fechamodificacion"
        parametro.Value = Proveedores.upro_fechamodificacion()
        listaParametros.Add(parametro)

        operaciones.EjecutarConsultaSP("Proveedor.SP_DesactivarUsuario", listaParametros)
        Console.WriteLine("Mando la sentencia")

    End Sub


    Public Function BuscarProveedorSicy(ByVal razonSocial As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String = "select * from Proveedores where RazonSocial= '" + razonSocial + "'"
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Sub DesactivarContacto(ByVal Proveedores As Entidades.DatosGenerales)
        Dim operaciones As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro = New SqlParameter
        parametro.ParameterName = "dage_proveedorid"
        parametro.Value = Proveedores.dage_proveedorid()
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "dage_activo"
        parametro.Value = Proveedores.dage_activo()
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "dage_usuariomodificoid"
        parametro.Value = Proveedores.dage_usuariomodificoid()
        listaParametros.Add(parametro)

        operaciones.EjecutarConsultaSP("Proveedor.SP_BajaContactos", listaParametros)
        Console.WriteLine("Mando la sentencia")

    End Sub

    'Activar proveedor
    Public Sub ActivarContacto(ByVal Proveedores As Entidades.DatosGenerales)
        Dim operaciones As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro = New SqlParameter
        parametro.ParameterName = "dage_proveedorid"
        parametro.Value = Proveedores.dage_proveedorid()
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "dage_activo"
        parametro.Value = Proveedores.dage_activo()
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "dage_usuariomodificoid"
        parametro.Value = Proveedores.dage_usuariomodificoid()
        listaParametros.Add(parametro)

        operaciones.EjecutarConsultaSP("Proveedor.SP_AltaContactos", listaParametros)
        Console.WriteLine("Mando la sentencia")

    End Sub

    'Modificacion de cuentas bancarias
    Public Sub ModificacionDatosDeCuentaBancaria(ByVal Proveedores As Entidades.DatosDeCuentaBancaria)
        Dim operaciones As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "dcba_banco"
        parametro.Value = Proveedores.dcba_banco()
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "dcba_cuenta"
        parametro.Value = Proveedores.dcba_cuenta()
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "dcba_clabe"
        parametro.Value = Proveedores.dcba_clabe()
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "dcba_cuentahabiente"
        parametro.Value = Proveedores.dcba_cuentahabiente()
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "dcba_plaza"
        parametro.Value = Proveedores.dcba_plaza()
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "dcba_sucursal"
        parametro.Value = Proveedores.dcba_sucursal()
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "dcba_predeterminada"
        If Proveedores.dcba_predeterminada = "" Or Proveedores.dcba_predeterminada = Nothing Then
            parametro.Value = DBNull.Value
        Else
            parametro.Value = Proveedores.dcba_predeterminada
        End If
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "dcba_activa"
        If Proveedores.dcba_activa = "" Or Proveedores.dcba_activa = Nothing Then
            parametro.Value = DBNull.Value
        Else
            parametro.Value = Proveedores.dcba_activa
        End If
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "dcba_usuariomodificoid"
        parametro.Value = Proveedores.dcba_usuariomodificoid()
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "dcba_fechamodificacion"
        parametro.Value = Proveedores.dcba_fechamodificacion()
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "dcba_rfc"
        parametro.Value = Proveedores.dcba_rfc()
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "dcba_tipodecuenta"
        parametro.Value = Proveedores.dcba_tipodecuenta()
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "dcba_datosdecuentabancariaid"
        parametro.Value = Proveedores.dcba_datosdecuentabancariaid()
        listaParametros.Add(parametro)

        operaciones.EjecutarSentenciaSP("Proveedor.SP_EditarCuentas", listaParametros)
        Console.WriteLine("Mando la sentencia")

    End Sub

    'Modificacion de datos de proveedor
    Public Sub ModificacionDatosDeProveedor(ByVal Proveedores As Entidades.DatosProveedor)
        Dim operaciones As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "prov_rfc"
        If Proveedores.prov_rfc = "" Or Proveedores.prov_rfc = Nothing Then
            parametro.Value = "-"
        Else
            parametro.Value = Proveedores.prov_rfc
        End If
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "prov_tiporazonsocial"
        parametro.Value = Proveedores.prov_tiporazonsocial
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "prov_tipofiscal"
        parametro.Value = Proveedores.prov_tipofiscal
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "prov_curp"
        If Proveedores.prov_curp = "" Or Proveedores.prov_curp = Nothing Then
            parametro.Value = "-"
        Else
            parametro.Value = Proveedores.prov_curp
        End If
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "prov_colonia"
        parametro.Value = Proveedores.prov_colonia
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "prov_ciudad"
        parametro.Value = Proveedores.prov_ciudad
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "prov_calle"
        parametro.Value = Proveedores.prov_calle
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "prov_numeroexterior"
        parametro.Value = Proveedores.prov_numeroexterior
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "prov_numerointerior"
        If Proveedores.prov_numerointerior = "" Or Proveedores.prov_numerointerior = Nothing Then
            parametro.Value = 0
        Else
            parametro.Value = Proveedores.prov_numerointerior
        End If
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "prov_codigopostal"
        parametro.Value = Proveedores.prov_codigopostal
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "prov_estado"
        parametro.Value = Proveedores.prov_estado
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "prov_activoordenesdecompra"
        parametro.Value = Proveedores.prov_activoordenesdecompra
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "prov_activopagos"
        parametro.Value = Proveedores.prov_activopagos
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "prov_activocompras"
        parametro.Value = Proveedores.prov_activocompras
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "prov_nombre"
        If Proveedores.prov_nombre = "" Or Proveedores.prov_nombre = Nothing Then
            parametro.Value = "-"
        Else
            parametro.Value = Proveedores.prov_nombre
        End If
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "prov_apellidopaterno"
        If Proveedores.prov_apellidopaterno = "" Or Proveedores.prov_apellidopaterno = Nothing Then
            parametro.Value = "-"
        Else
            parametro.Value = Proveedores.prov_apellidopaterno
        End If
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "prov_apellidomaterno"
        If Proveedores.prov_apellidomaterno = "" Or Proveedores.prov_apellidomaterno = Nothing Then
            parametro.Value = "-"
        Else
            parametro.Value = Proveedores.prov_apellidomaterno
        End If
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "prov_usuariomodificoid"
        parametro.Value = Proveedores.prov_usuariomodificoid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "prov_fechamodificacion"
        parametro.Value = Proveedores.prov_fechamodificacion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "prov_razonsocial"
        parametro.Value = Proveedores.prov_razonsocial
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "prov_pais"
        parametro.Value = Proveedores.prov_pais
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "prov_datosrfcid"
        parametro.Value = Proveedores.prov_datosrfcid
        listaParametros.Add(parametro)

        operaciones.EjecutarSentenciaSP("Proveedor.SP_EditarRFC", listaParametros)
        Console.WriteLine("Mando la sentencia")

    End Sub

    'Modificacion de usuarios de proveedor
    Public Sub ModificacionUsuarioProveedor(ByVal Proveedores As Entidades.UsuarioProveedor)
        Dim operaciones As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        ' TE HICE UN PARO
        'operaciones.Servidor()+"."+operaciones.NombreDB()+".TABLA"

        Dim parametro As New SqlParameter
        parametro.ParameterName = "upro_usuario"
        parametro.Value = Proveedores.upro_usuario()
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "upro_password"
        parametro.Value = Proveedores.upro_password()
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "upro_usuariomodificoid"
        parametro.Value = Proveedores.upro_usuariomodificoid()
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "upro_fechamodificacion"
        parametro.Value = Proveedores.upro_fechamodificacion()
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "upro_usuarioproveedorid"
        parametro.Value = Proveedores.upro_usuarioproveedorid()
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "upro_activo"
        parametro.Value = Proveedores.upro_activo()
        listaParametros.Add(parametro)

        operaciones.EjecutarSentenciaSP("Proveedor.SP_EditarUsuarios", listaParametros)
        Console.WriteLine("Mando la sentencia")

    End Sub

    'Asociar nave a proveedor
    Public Sub AsignarNaveProveedor(ByVal Proveedores As Entidades.NaveProveedor)
        Dim operaciones As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "prna_activo"
        parametro.Value = Proveedores.prna_activo()
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "dage_proveedorid"
        parametro.Value = Proveedores.dage_proveedorid()
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "nave_naveid"
        parametro.Value = Proveedores.nave_naveid()
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "prna_usuariocreoid"
        parametro.Value = Proveedores.prna_usuariocreoid()
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "prna_usuariomodificoid"
        parametro.Value = Proveedores.prna_usuariomodificoid()
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "prna_fechacreacion"
        parametro.Value = Proveedores.prna_fechacreacion()
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "prna_fechamodificacion"
        parametro.Value = Proveedores.prna_fechamodificacion()
        listaParametros.Add(parametro)

        operaciones.EjecutarSentenciaSP("Proveedor.SP_InsertarNave", listaParametros)
        Console.WriteLine("Mando la sentencia")

    End Sub

    'Modificacion de proveedor en nave


    'Modificacion de plazo de pago
    Public Sub ModificacionPlazoPago(ByVal Proveedores As Entidades.PlazoPago)
        Dim operaciones As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "plpa_plazopagoid"
        parametro.Value = Proveedores.plpa_plazopagoid()
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "dage_proveedorid"
        parametro.Value = Proveedores.dage_proveedorid()
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "plpr_usuariocreoid"
        parametro.Value = Proveedores.plpr_usuariocreoid()
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "plpr_usuariomodificoid"
        parametro.Value = Proveedores.plpr_usuariomodificoid()
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "plpr_fechacreacion"
        parametro.Value = Proveedores.plpr_fechacreacion()
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "plpr_fechamodificacion"
        parametro.Value = Proveedores.plpr_fechamodificacion()
        listaParametros.Add(parametro)

        operaciones.EjecutarConsultaSP("Proveedor.SP_AgregarPLazo", listaParametros)
        Console.WriteLine("Mando la sentencia")

    End Sub

    Public Function EliminarPlazoPago(ByVal plazopagoid As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "delete from Proveedor.PlazoProveedor where plpr_plazoproveedorid = " + plazopagoid.ToString
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function EliminarNave(ByVal idnave As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "delete from Proveedor.ProveedorNave where prna_datonaveid = " + idnave.ToString
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    'Alta de plazo de proveedor
    Public Sub AltaPlazoProveedor(ByVal Proveedores As Entidades.PlazoProveedor)
        Dim operaciones As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "PlazoPagoId"
        parametro.Value = Proveedores.plpa_plazopago
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Proveedor"
        parametro.Value = Proveedores.dage_proveedorid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "UsuarioCreo"
        parametro.Value = Proveedores.plpr_usuariocreoid
        listaParametros.Add(parametro)

        operaciones.EjecutarSentenciaSP("[Proveedor].[SP_InsertarPlazoPagoProveedor]", listaParametros)


    End Sub

    Public Sub BajaPlazoProveedor(ByVal Proveedores As Entidades.PlazoProveedor)
        Dim operaciones As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "PlazoPagoId"
        parametro.Value = Proveedores.plpa_plazopago
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Proveedor"
        parametro.Value = Proveedores.dage_proveedorid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "UsuarioCreo"
        parametro.Value = Proveedores.plpr_usuariocreoid
        listaParametros.Add(parametro)

        operaciones.EjecutarSentenciaSP("[Proveedor].[SP_DesactivarPlazoPagoProveedor]", listaParametros)


    End Sub

    'Alta de giro
    Public Sub AltaGiro(ByVal Proveedores As Entidades.Giro)
        Dim operaciones As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "girp_descripcion"
        parametro.Value = Proveedores.girp_descripcion()
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "girp_usuariocreoid"
        parametro.Value = Proveedores.girp_usuariocreoid()
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "girp_usuariomodificoid"
        parametro.Value = Proveedores.girp_usuariomodificoid()
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "girp_fechacreacion"
        parametro.Value = Proveedores.girp_fechacreacion()
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "girp_fechamodificacion"
        parametro.Value = Proveedores.girp_fechamodificacion()
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "girp_activo"
        parametro.Value = Proveedores.girp_activo()
        listaParametros.Add(parametro)

        operaciones.EjecutarSentenciaSP("Proveedor.SP_InsertarGiro", listaParametros)
        Console.WriteLine("Mando la sentencia")
    End Sub

    'Activar contacto proveedor
    Public Sub ActivarContactoProveedor(ByVal Proveedores As Entidades.DatosContacto)
        Dim operaciones As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro = New SqlParameter
        parametro.ParameterName = "daco_datoscontactoid"
        parametro.Value = Proveedores.daco_datoscontactoid()
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "daco_activo"
        parametro.Value = Proveedores.daco_activo()
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "daco_usuariomodificoid"
        parametro.Value = Proveedores.daco_usuariomodificoid()
        listaParametros.Add(parametro)

        operaciones.EjecutarConsultaSP("Proveedor.SP_AltaContactosProveedor", listaParametros)
        Console.WriteLine("Mando la sentencia")

    End Sub

    'Desactivar contacto proveedor
    Public Sub DesactivarContactoProveedor(ByVal Proveedores As Entidades.DatosContacto)
        Dim operaciones As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro = New SqlParameter
        parametro.ParameterName = "daco_datoscontactoid"
        parametro.Value = Proveedores.daco_datoscontactoid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "daco_activo"
        parametro.Value = Proveedores.daco_activo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "daco_usuariomodificoid"
        parametro.Value = Proveedores.daco_usuariomodificoid
        listaParametros.Add(parametro)

        operaciones.EjecutarConsultaSP("Proveedor.SP_BajaContactosProveedor", listaParametros)
        Console.WriteLine("Mando la sentencia")

    End Sub

    'Activa Desactiva Usuario Proveedor
    Public Sub ActivaDesactivaUsuarioProveedor(ByVal Proveedores As Entidades.UsuarioProveedor)
        Dim operaciones As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro = New SqlParameter
        parametro.ParameterName = "upro_usuarioproveedorid"
        parametro.Value = Proveedores.upro_usuarioproveedorid()
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "upro_activo"
        parametro.Value = Proveedores.upro_activo()
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "upro_usuariomodificoid"
        parametro.Value = Proveedores.upro_usuariomodificoid()
        listaParametros.Add(parametro)

        operaciones.EjecutarConsultaSP("Proveedor.SP_ActivarUsuarios", listaParametros)
        Console.WriteLine("Mando la sentencia")

    End Sub

    Public Function EliminarGiro(ByVal idgiro As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "update Proveedor.GiroProveedor set girp_activo='NO' where girp_giroproveedorid = " + idgiro.ToString
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function ActivarGiro(ByVal giro As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "update Proveedor.GiroProveedor set girp_activo='SI' where where girp_descripcion like'" + giro + "'"
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function ObtieneMonedasProveedor() As DataTable
        Dim operaciones As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Return operaciones.EjecutarConsultaSP("[Proveedor].[SP_Obtiene_MonedasProveedor]", listaParametros)
    End Function

    Public Function InsertarMonedasProveedor(ByVal ProveedorID As Integer, ByVal Monedas As String) As DataTable
        Dim operaciones As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@ProveedorID", ProveedorID)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@Monedas", Monedas)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@UsuarioID", Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Proveedor].[SP_AltaEdicion_MonedasProveedor]", listaParametros)
    End Function

    Public Function CargarMonedasProveedor(ByVal ProveedorID As Integer) As DataTable
        Dim operaciones As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@ProveedorID", ProveedorID)
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Proveedor].[SP_Consulta_MonedasPorProveedor]", listaParametros)
    End Function


End Class



