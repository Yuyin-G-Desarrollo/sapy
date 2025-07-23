Imports System.Data.SqlClient

Public Class SucursalesDA
    Public Function getSucursales(ByVal condicion As Boolean) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String
        Dim auxBit As Int16

        If condicion Then
            auxBit = 1
        Else
            auxBit = 0
        End If

        consulta = "select suc_sucursalid NUM, suc_nombre NOMBRE, isnull(c.city_nombre, '') CIUDAD, " & _
                    "(case when s.suc_facturaproductos = 1 then 'SI' else	'NO' end) [FACTURA PRODUCTOS] " & _
                    "from Facturacion.Sucursales s " & _
                    "left join Framework.Ciudades c on c.city_ciudadid = s.suc_ciudadid " & _
                    "where s.suc_activo = " & auxBit
        Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function getUsuariosNA(ByVal sucursalId As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String

        Dim condicion As String

        If sucursalId = 0 Then
            condicion = ""
        Else
            condicion = " and u.user_usuarioid not in (select susu_usuarioid from Facturacion.SucursalUsuarios where sucu_sucursaldid = " & sucursalId & ") "
        End If

        consulta = "select distinct u.user_usuarioid, u.user_nombrereal NOMBRE, u.user_username USUARIO " & _
                    "from Framework.Usuarios u " & _
                    "inner join Framework.PerfilesUsuario pu on u.user_usuarioid = pu.peus_usuarioid " & _
                    "inner join Framework.PermisosPerfil pp on pu.peus_perfilid = pp.pepe_perfilid " & _
                    "inner join Framework.AccionesModulo am on am.acmo_accionmoduloid = pp.pepe_accionid " & _
                    "where am.acmo_moduloid = " & _
                    "(select modu_moduloid from Framework.Modulos where modu_clave = 'ConfigSucursales') " & _
                    " and u.user_activo = 1 " & condicion & " order by NOMBRE "
        Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function getDatosSucursal(ByVal sucursalId As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String
        consulta = "select suc_sucursalid, " & _
                    "ISNULL(suc_nombre, '') suc_nombre, " & _
                    "ISNULL(suc_calle, '') suc_calle, " & _
                    "ISNULL(suc_numero, '') suc_numero, " & _
                    "ISNULL(suc_colonia, '') suc_colonia, " & _
                    "ISNULL(suc_cp, '') suc_cp, " & _
                    "ISNULL(suc_ciudadid, 0) suc_ciudadid, " & _
                    "ISNULL(suc_logo, '') suc_logo, " & _
                    "ISNULL(suc_facturaproductos, 0) suc_facturaproductos, " & _
                    "ISNULL(suc_activo, 0) suc_activo, " & _
                    "ISNULL(suc_remision, 0) suc_remision, " & _
                    "ISNULL(suc_reporteRemision, 0) suc_reporteRemision, " & _
                    "ISNULL(e.esta_estadoid, 0) esta_estadoid, " & _
                    "ISNULL(c.city_nombre, '') ciudad, " & _
                    "ISNULL(e.esta_nombre, '') estado, " & _
                    "ISNULL(p.pais_nombre , '') pais " & _
                    "from Facturacion.Sucursales s " & _
                    "left join Framework.Ciudades c on s.suc_ciudadid = c.city_ciudadid " & _
                    "left join Framework.Estados e on e.esta_estadoid = c.city_estadoid " & _
                    "left join Framework.Paises p on p.pais_paisid = e.esta_paisid " & _
                    "where suc_sucursalid = " & sucursalId
        Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function getUsuariosA(ByVal sucursalId As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String
        Dim condicion As String

        If sucursalId = 0 Then
            condicion = ""
        Else
            condicion = " and su.sucu_sucursaldid = " & sucursalId
        End If
        consulta = "select u.user_usuarioid, u.user_nombrereal NOMBRE, u.user_username USUARIO " & _
                    "from Facturacion.SucursalUsuarios su " & _
                    "inner join Framework.Usuarios u on su.susu_usuarioid = u.user_usuarioid " & _
                    "where u.user_activo = 1 " & condicion & " order by NOMBRE "
        Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function getSucEmpresas(ByVal sucursalId As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String
        Dim condicion As String

        If sucursalId = 0 Then
            condicion = ""
        Else
            condicion = " where su.suem_sucursalid = " & sucursalId
        End If
        consulta = "select suem_sucursalempresaid, " & _
                    "suem_sucursalid, " & _
                    "suem_empresaid, " & _
                    "e.empr_nombre EMPRESA, " & _
                    "suem_serie SERIE, " & _
                    "suem_folioactual [FOLIO ACTUAL], " & _
                    "suem_folioinicio [FOLIO INICIO], " & _
                    "suem_foliofinal [FOLIO FIN], " & _
                    "(case when suem_activo = 1 then 'SI' else 'NO' end) ACTIVO, " & _
                    "isnull (suem_reportefacturaid, 0) suem_reportefacturaid, " & _
                    "isnull (suem_reportecancelacionid, 0) suem_reportecancelacionid, " & _
                    "suem_imprimirsucursal " & _
                    "from Facturacion.SucursalEmpresa su " & _
                    "inner join Framework.Empresas e on e.empr_empresaid = su.suem_empresaid " & condicion
        Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function ExisteSucursal(ByVal strSucursal As String, ByVal sucursalId As Int32) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String
        Dim strCampo As String = ""
        Dim strCondicion As String = ""

        If sucursalId = 0 Then
            strCondicion = ""
        Else
            strCondicion = " and suc_sucursalid <> " & sucursalId
        End If

        consulta = "select * from Facturacion.Sucursales where suc_nombre = '" & strSucursal & "'" & strCondicion
        Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function guardarConfiguracionSucursal(ByVal suc As Entidades.SucursalesFacturacion) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "sucursalid"
        parametro.Value = suc.SID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "nombre"
        parametro.Value = suc.SNombre
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "calle"
        parametro.Value = suc.SCalle
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "numero"
        parametro.Value = suc.SNumero
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "colonia"
        parametro.Value = suc.SColonia
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "cp"
        parametro.Value = suc.SCp
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ciudadid"
        parametro.Value = suc.SCiudadid
        listaParametros.Add(parametro)

        If suc.SLogo <> "" Then
            parametro = New SqlParameter
            parametro.ParameterName = "logo"
            parametro.Value = suc.SLogo
            listaParametros.Add(parametro)
        End If

        parametro = New SqlParameter
        parametro.ParameterName = "usuario"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "facturaproductos"
        parametro.Value = suc.SFacturaproductos
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "activo"
        parametro.Value = suc.SActivo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "remision"
        parametro.Value = suc.SRemisiona
        listaParametros.Add(parametro)

        If suc.SRemisiona Then
            parametro = New SqlParameter
            parametro.ParameterName = "reporteRemision"
            parametro.Value = suc.SReporteRemision
            listaParametros.Add(parametro)
        End If

        Return operacion.EjecutarConsultaSP("Facturacion.SP_ConfiguracionSucursal", listaParametros)
    End Function

    Public Sub guardarSucursalEmpresa(ByVal suem As Entidades.SucursalEmpresa)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "sucursalempresaid"
        parametro.Value = suem.SEId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "sucursalid"
        parametro.Value = suem.SESucursalid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "empresaid"
        parametro.Value = suem.SEEmpresaid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "serie"
        parametro.Value = suem.SESerie
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "folioinicio"
        parametro.Value = suem.SEFolioinicio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "foliofinal"
        parametro.Value = suem.SEFoliofinal
        listaParametros.Add(parametro)

        If suem.SEReportefacturaid <> 0 And suem.SEReportefacturaid <> -1 Then
            parametro = New SqlParameter
            parametro.ParameterName = "reportefacturaid"
            parametro.Value = suem.SEReportefacturaid
            listaParametros.Add(parametro)
        End If

        If suem.SEReportecancelacionid <> 0 And suem.SEReportecancelacionid <> -1 Then
            parametro = New SqlParameter
            parametro.ParameterName = "reportecancelacionid"
            parametro.Value = suem.SEReportecancelacionid
            listaParametros.Add(parametro)
        End If

        parametro = New SqlParameter
        parametro.ParameterName = "imprimirsucursal"
        parametro.Value = suem.SEImprimirsucursal
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "activo"
        parametro.Value = suem.SEActivo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "usuario"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        operacion.EjecutarSentenciaSP("Facturacion.SP_ConfiguracionSucursalEmpresa", listaParametros)
    End Sub

    Public Sub guardarSucursalUsuario(ByVal suus As Entidades.SucursalUsuario)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String

        consulta = "insert into Facturacion.SucursalUsuarios (susu_usuarioid, sucu_sucursaldid, susu_fechacreacion, susu_usuariocreoid) " & _
                    "values (" & suus.SUUsuarioid & ", " & suus.SUSucursaldid & ", getdate(), " & Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid & ")"
        operacion.EjecutaConsulta(consulta)
    End Sub

    Public Sub eliminaSucursalUsuario(ByVal suus As Entidades.SucursalUsuario)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String

        consulta = "delete from Facturacion.SucursalUsuarios where susu_usuarioid = " & suus.SUUsuarioid & " and sucu_sucursaldid = " & suus.SUSucursaldid
        operacion.EjecutaConsulta(consulta)
    End Sub

    Public Function ExisteRegistro(ByVal suus As Entidades.SucursalUsuario) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String

        consulta = "select * from Facturacion.SucursalUsuarios where susu_usuarioid = " & suus.SUUsuarioid & " and sucu_sucursaldid = " & suus.SUSucursaldid
        Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function getDatosSucEmpresa(ByVal sucursalId As Integer, ByVal empresaId As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String

        consulta = "select isnull(suem_reportefacturaid,0) as reporteID, isnull(suem_reportecancelacionid,0) as reporteCancID, * " & _
                    "from Facturacion.SucursalEmpresa " & _
                    "where suem_sucursalid = " & sucursalId & " and suem_empresaid = " & empresaId & ""
        Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function getSucursalesActivas() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String
        consulta = "select suc_sucursalid, suc_nombre " & _
                    "from Facturacion.Sucursales where suc_activo = 1 order by suc_nombre"
        Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function getSucursalesUsuarios(ByVal idUsuario As Integer, ByVal filtroRemision As Boolean) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = String.Empty
        Dim filtro As String = String.Empty

        If filtroRemision Then
            filtro = " and suc_remision = 1"
        End If

        consulta = "select s.suc_sucursalid ID, s.suc_nombre SUCURSAL " & _
                    "from Facturacion.SucursalUsuarios su " & _
                    "inner join Facturacion.Sucursales s on s.suc_sucursalid = su.sucu_sucursaldid " & _
                    "where suc_activo = 1 and susu_usuarioid = " & idUsuario & filtro & " " & _
                    "order by s.suc_nombre"
        Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function obtenerEmpresasSuc(ByVal sucursalId As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String

        consulta = "select e.empr_empresaid ID, e.empr_nombre EMPRESA " & _
                    "from Framework.Empresas e " & _
                    "inner join Facturacion.SucursalEmpresa su on e.empr_empresaid = su.suem_empresaid " & _
                    "where empr_activo = 1 and suem_activo = 1 and su.suem_sucursalid = " & sucursalId & " order by e.empr_nombre"
        Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function obtenerFolioSerieSucursal(ByVal sucursalId As Integer, ByVal empresaId As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = String.Empty

        consulta = "select suem_serie, ISNULL(suem_folioactual, 0) suem_folioactual, suem_folioinicio, suem_foliofinal " & _
                    "from Facturacion.SucursalEmpresa " & _
                    "where suem_sucursalid = " & sucursalId & " and suem_empresaid = " & empresaId

        Return operacion.EjecutaConsulta(consulta)
    End Function
End Class
