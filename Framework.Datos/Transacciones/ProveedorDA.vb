Imports Persistencia
Imports System.Data.SqlClient

Public Class ProveedorDA




    Public Sub AltaProveedor(ByVal Proveedor As Entidades.Proveedor)
        Dim operaciones As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "prov_nombregenerico"
        parametro.Value = Proveedor.pnombregenerico
        listaParametros.Add(parametro)


        parametro = New SqlParameter
        parametro.ParameterName = "prov_razonsocial"
        If Proveedor.prazonsocial = "" Or Proveedor.prazonsocial = Nothing Then
            parametro.Value = DBNull.Value
        Else
            parametro.Value = Proveedor.prazonsocial
        End If

        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "prov_rfc"
        If Proveedor.prfc = "" Or Proveedor.prfc = Nothing Then
            parametro.Value = DBNull.Value

        Else
            parametro.Value = Proveedor.prfc
        End If

        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "prov_claveyuyincliente"
        If Proveedor.pclaveyuyincliente <= 0 Or Proveedor.pclaveyuyincliente = Nothing Then
            parametro.Value = DBNull.Value
        Else
            parametro.Value = Proveedor.pclaveyuyincliente
        End If

        listaParametros.Add(parametro)


        parametro = New SqlParameter
        parametro.ParameterName = "prov_usuarioweb"
        If Proveedor.pusuarioweb = "" Or Proveedor.pusuarioweb = Nothing Then
            parametro.Value = DBNull.Value
        Else
            parametro.Value = Proveedor.pusuarioweb
        End If

        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "prov_contrasenaweb"
        If Proveedor.pcontrasenaweb = "" Or Proveedor.pcontrasenaweb = Nothing Then
            parametro.Value = DBNull.Value
        Else
            parametro.Value = Proveedor.pcontrasenaweb
        End If

        listaParametros.Add(parametro)


        parametro = New SqlParameter
        parametro.ParameterName = "prov_horario"
        If Proveedor.phorario = "" Or Proveedor.phorario = Nothing Then
            parametro.Value = DBNull.Value
        Else
            parametro.Value = Proveedor.phorario
        End If

        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "prov_personaidproveedor"
        parametro.Value = Proveedor.ppersonaidproveedor
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "prov_clasificacionpersonaid"
        parametro.Value = Proveedor.pclasificacionpersonaid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "prov_comentarios"
        parametro.Value = Proveedor.pcomentarios
        listaParametros.Add(parametro)


        ',@usuariocreoid AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "prov_usuariocreoid"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "prov_sitiowebproveedor"
        parametro.Value = Proveedor.pwebproveedor
        listaParametros.Add(parametro)


        operaciones.EjecutarSentenciaSP("Proveedor.SP_AltaProveedores", listaParametros)
        Console.WriteLine("Mando la sentencia")

    End Sub


    Public Sub EditarProveedor(ByVal Proveedor As Entidades.Proveedor)
        Dim operaciones As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "prov_nombregenerico"
        parametro.Value = Proveedor.pnombregenerico
        listaParametros.Add(parametro)


        parametro = New SqlParameter
        parametro.ParameterName = "prov_razonsocial"
        If Proveedor.prazonsocial = "" Or Proveedor.prazonsocial = Nothing Then
            parametro.Value = DBNull.Value
        Else
            parametro.Value = Proveedor.prazonsocial
        End If

        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "prov_rfc"
        If Proveedor.prfc = "" Or Proveedor.prfc = Nothing Then
            parametro.Value = DBNull.Value

        Else
            parametro.Value = Proveedor.prfc
        End If

        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "prov_claveyuyincliente"
        If Proveedor.pclaveyuyincliente <= 0 Or Proveedor.pclaveyuyincliente = Nothing Then
            parametro.Value = DBNull.Value
        Else
            parametro.Value = Proveedor.pclaveyuyincliente
        End If

        listaParametros.Add(parametro)


        parametro = New SqlParameter
        parametro.ParameterName = "prov_usuarioweb"
        If Proveedor.pusuarioweb = "" Or Proveedor.pusuarioweb = Nothing Then
            parametro.Value = DBNull.Value
        Else
            parametro.Value = Proveedor.pusuarioweb
        End If

        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "prov_contrasenaweb"
        If Proveedor.pcontrasenaweb = "" Or Proveedor.pcontrasenaweb = Nothing Then
            parametro.Value = DBNull.Value
        Else
            parametro.Value = Proveedor.pcontrasenaweb
        End If

        listaParametros.Add(parametro)


        parametro = New SqlParameter
        parametro.ParameterName = "prov_horario"
        If Proveedor.phorario = "" Or Proveedor.phorario = Nothing Then
            parametro.Value = DBNull.Value
        Else
            parametro.Value = Proveedor.phorario
        End If

        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "prov_personaidproveedor"
        parametro.Value = Proveedor.ppersonaidproveedor
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "prov_clasificacionpersonaid"
        parametro.Value = Proveedor.pclasificacionpersonaid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "prov_comentarios"
        parametro.Value = Proveedor.pcomentarios
        listaParametros.Add(parametro)


        ',@usuariocreoid AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "prov_usuariomodificaid"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ProveedorID"
        parametro.Value = Proveedor.pproveedorid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "prov_sitiowebproveedor"
        parametro.Value = Proveedor.pwebproveedor
        listaParametros.Add(parametro)

        operaciones.EjecutarSentenciaSP("Proveedor.SP_EditarProveedores", listaParametros)
        Console.WriteLine("Mando la sentencia")

    End Sub

    Public Function DatosProveedor(ByVal IDPersona As Int32) As DataTable
        Dim operaciones As New OperacionesProcedimientos
        Dim consulta As String = String.Empty
        consulta = "select * from Proveedor.Proveedor where prov_personaidproveedor =" + IDPersona.ToString
        Return operaciones.EjecutaConsulta(consulta)

    End Function

    Public Function GetIDProveedorRecienInsertado(ByVal idPersona As Int32) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "" +
                "SELECT top 1 (prov_proveedorid) from Proveedor.Proveedor order by prov_proveedorid DESC"
        If idPersona > 0 Then
            consulta = "SELECT top 1 (prov_proveedorid) from Proveedor.Proveedor where prov_personaidproveedor = " + idPersona.ToString
        End If
        Return operaciones.EjecutaConsulta(consulta)
    End Function


    Public Sub AltaTiposFleteMensajeria(ByVal tiposmensajeria As Entidades.TipoFleteMensajeria)
        Dim operaciones As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "TipodeFlete"
        parametro.Value = tiposmensajeria.tipofleteid
        listaParametros.Add(parametro)


        parametro = New SqlParameter
        parametro.ParameterName = "Proveedorid"
        parametro.Value = tiposmensajeria.proveedorid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Activo"
        parametro.Value = tiposmensajeria.activo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "UsuarioCreoid"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)


       


        operaciones.EjecutarSentenciaSP("Embarque.SP_AltaTipoFleteMensajeria", listaParametros)
        Console.WriteLine("Mando la sentencia")
    End Sub


    Public Function ListaTiposFletes() As DataTable
        Dim operaciones As New OperacionesProcedimientos
        Dim consulta As String = String.Empty
        consulta = "select * from Ventas.TipoFlete"
        Return operaciones.EjecutaConsulta(consulta)

    End Function


    Public Sub EditarTiposFleteMensajeria(ByVal tiposmensajeria As Entidades.TipoFleteMensajeria)
        Dim operaciones As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "Activo"
        parametro.Value = tiposmensajeria.activo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Usuariomodificoid"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "tipofletemensajeriaid"
        parametro.Value = tiposmensajeria.tipofletemensajeriaid
        listaParametros.Add(parametro)

        operaciones.EjecutarSentenciaSP("Embarque.SP_EditarTipoFleteMensajeria", listaParametros)
        Console.WriteLine("Mando la sentencia")
    End Sub


    Public Function ListaTiposFletesProveedor(ByVal idProveedor As Int32) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String
        consulta = "select * from Embarque.TipoFleteMensajeria as a" +
" join Ventas.TipoFlete as b on (a.tflm_tipofleteid=b.tifl_tipofleteid) where tflm_proveedorid=" + idProveedor.ToString
        Return operaciones.EjecutaConsulta(consulta)
    End Function



End Class
