Imports System.Data.SqlClient


Public Class MensajeriaDA


    Public Function ConsultarMensajeriasCostosDestinos() As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Return operaciones.EjecutarConsultaSP("Embarque.SP_Consultar_MesajeriaDestinoCostos", New List(Of System.Data.SqlClient.SqlParameter))

    End Function


    Public Function ConsultarTipoReembarque() As DataTable
        Dim Operaciones As New Persistencia.OperacionesProcedimientos
        Dim Consulta As String = String.Empty
        Consulta = "select * from Embarque.TipoReembarque"
        Return Operaciones.EjecutaConsulta(Consulta)

    End Function

    Public Function ConsultarTipoUnidad() As DataTable
        Dim Operaciones As New Persistencia.OperacionesProcedimientos
        Dim Consulta As String = String.Empty
        Consulta = "select * from Framework.Unidad"
        Return Operaciones.EjecutaConsulta(Consulta)

    End Function



    Public Sub ActualizarCostoDestino(ByVal Mensaje As Entidades.Mensajeria, ByVal TipoActualizacion As Boolean)

        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaValores As New List(Of SqlParameter)



        Dim valores As New SqlParameter
        valores.ParameterName = "codm_costodestinomensajeriaid"
        valores.Value = Mensaje.PIDCostoMensajeria
        listaValores.Add(valores)


        valores = New SqlParameter
        valores.ParameterName = "codm_costoporunidad"
        valores.Value = Mensaje.PCostoUnidad
        listaValores.Add(valores)


        valores = New SqlParameter
        valores.ParameterName = "codm_diasminimoentrega"
        valores.Value = Mensaje.PDiasMinEntregas
        listaValores.Add(valores)

        valores = New SqlParameter
        valores.ParameterName = "codm_diasmaximoentrega"
        valores.Value = Mensaje.PDiasMaxEntregas
        listaValores.Add(valores)

        valores = New SqlParameter
        valores.ParameterName = "codm_fechainiciovigencia"
        valores.Value = Date.Today
        listaValores.Add(valores)


        valores = New SqlParameter
        valores.ParameterName = "codm_fechafinvigencia"
        valores.Value = Date.Today
        listaValores.Add(valores)

        valores = New SqlParameter
        valores.ParameterName = "codm_tiporeembarqueid"
        valores.Value = CInt(Mensaje.PReembarque)
        listaValores.Add(valores)

        valores = New SqlParameter
        valores.ParameterName = "codm_unidadid"
        valores.Value = CInt(Mensaje.PNombreUnidad)
        listaValores.Add(valores)

        valores = New SqlParameter
        valores.ParameterName = "codm_activo"
        valores.Value = Mensaje.PActivo
        listaValores.Add(valores)

        valores = New SqlParameter
        valores.ParameterName = "codm_usuariomodificoid"
        valores.Value = 1
        listaValores.Add(valores)

        valores = New SqlParameter
        valores.ParameterName = "codm_fechamodificacion"
        valores.Value = Date.Today
        listaValores.Add(valores)

        valores = New SqlParameter
        valores.ParameterName = "codm_actualizacionmasiva"
        valores.Value = TipoActualizacion
        listaValores.Add(valores)


        operaciones.EjecutarSentenciaSP("Embarque.SP_Actualizar_CostoDestinos", listaValores)

    End Sub


    Public Function ListaEmbarque() As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim Consulta As String = "SELECT * from Embarque.TipoReembarque"
        Return operaciones.EjecutaConsulta(Consulta)
    End Function


    Public Function ConsultarMensajeriasCostosProveedor(ByVal idProveedor As Int32, ByVal idCiudad As Int32, ByVal idEstado As Int32, ByVal idPais As Int32, ByVal idPoblacion As Int32, ByVal UnidadID As Int32) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim Consulta As String = String.Empty

        If idPoblacion > 0 Then
            Consulta = " SELECT c.prov_nombregenerico, g.pobl_nombre, b.city_nombre,h.esta_abreviatura,i.pais_abreviatura,f.unid_nombre,d.codm_costoporunidad," +
                          " e.tire_nombre,d.codm_diasminimoentrega,d.codm_diasmaximoentrega," +
                          " (SELECT w.city_nombre FROM Framework.Ciudades AS w WHERE w.city_ciudadid = g.pobl_ciudadid) AS 'CiudadPoblacion'," +
                          " CASE WHEN d.codm_fechamodificacion IS NULL THEN d.codm_fechacreacion ELSE d.codm_fechamodificacion END AS 'Modificación'," +
                          " CASE WHEN d.codm_usuariomodificaid IS NULL THEN (SELECT user_username FROM Framework.Usuarios WHERE user_usuarioid = d.codm_usuariocreoid)" +
                          " ELSE (SELECT user_username FROM Framework.Usuarios WHERE user_usuarioid = d.codm_usuariomodificaid) END AS 'Usuario'," +
                          " d.codm_costodestinomensajeriaid," +
                          " d.codm_activo," +
                          " (SELECT z.esta_abreviatura FROM Framework.Estados AS z WHERE z.esta_estadoid = (SELECT w.city_estadoid FROM Framework.Ciudades AS w WHERE w.city_ciudadid = g.pobl_ciudadid)) AS EstadoPoblacion," +
                          " (SELECT z.pais_abreviatura FROM Framework.Paises AS z WHERE z.pais_paisid = (SELECT z.esta_paisid FROM Framework.Estados AS z WHERE z.esta_estadoid = (SELECT w.city_estadoid FROM Framework.Ciudades AS w WHERE w.city_ciudadid = g.pobl_ciudadid))) AS PaisPoblacion" +
                      " FROM Embarque.DestinoMensajeria AS a" +
                      " LEFT JOIN Framework.Poblaciones AS g ON a.deme_poblacionid = g.pobl_poblacionid" +
                      " LEFT JOIN Framework.Ciudades AS b ON g.pobl_ciudadid = b.city_ciudadid" +
                      " LEFT JOIN Framework.Estados AS h ON b.city_estadoid = h.esta_estadoid" +
                      " LEFT JOIN Framework.Paises AS i	ON h.esta_paisid = i.pais_paisid" +
                      " LEFT JOIN Embarque.CostoDestinoMensajeria AS d ON a.deme_destinomensajeriaid = d.codm_destinomensajeriaid" +
                      " LEFT JOIN Proveedor.Proveedor AS c ON a.deme_proveedorid = c.prov_proveedorid" +
                      " LEFT JOIN Embarque.TipoReembarque AS e ON d.codm_tiporeembarqueid = e.tire_tiporeembarqueid" +
                      " LEFT JOIN Framework.Unidad AS f ON d.codm_unidadid = f.unid_unidadid" +
                                  " WHERE prov_proveedorid = " + idProveedor.ToString

            If idEstado > 0 Then
                Consulta += " and h.esta_estadoid = " + idEstado.ToString
            End If

            If idCiudad > 0 Then
                Consulta += " AND  g.pobl_ciudadid =  " + idCiudad.ToString
            End If
            If idPoblacion > 0 Then
                Consulta += " AND g.pobl_poblacionid = " + idPoblacion.ToString
            End If

        ElseIf idCiudad > 0 Then

            Consulta = " SELECT c.prov_nombregenerico," +
     " '' AS 'pobl_nombre'," +
     " b.city_nombre," +
     " h.esta_abreviatura," +
     " i.pais_abreviatura," +
     " f.unid_nombre," +
     " d.codm_costoporunidad," +
     " e.tire_nombre," +
     " d.codm_diasminimoentrega," +
     " d.codm_diasmaximoentrega," +
     " b.city_nombre AS 'CiudadPoblacion'," +
     " CASE WHEN d.codm_fechamodificacion IS NULL THEN d.codm_fechacreacion ELSE d.codm_fechamodificacion END AS 'Modificación'," +
     " CASE WHEN d.codm_usuariomodificaid IS NULL THEN (SELECT user_username FROM Framework.Usuarios WHERE user_usuarioid = d.codm_usuariocreoid) " +
     " ELSE (SELECT user_username FROM Framework.Usuarios WHERE user_usuarioid = d.codm_usuariomodificaid) END AS 'Usuario'," +
     " d.codm_costodestinomensajeriaid," +
     " d.codm_activo," +
     "  h.esta_abreviatura AS 'EstadoPoblacion', i.pais_abreviatura AS 'PaisPoblacion'" +
 " FROM Embarque.DestinoMensajeria AS a" +
 " LEFT JOIN Framework.Ciudades AS b ON (a.deme_ciudadid = b.city_ciudadid)" +
 " LEFT JOIN Proveedor.Proveedor AS c ON (a.deme_proveedorid = c.prov_proveedorid)" +
 " LEFT JOIN Embarque.CostoDestinoMensajeria AS d ON (a.deme_destinomensajeriaid = d.codm_destinomensajeriaid)" +
 " LEFT JOIN Embarque.TipoReembarque AS e ON (d.codm_tiporeembarqueid = e.tire_tiporeembarqueid)" +
 " LEFT JOIN Framework.Unidad AS f ON (d.codm_unidadid = f.unid_unidadid)" +
 " LEFT JOIN Framework.Estados AS h ON (b.city_estadoid = h.esta_estadoid)" +
 " LEFT JOIN Framework.Paises AS i	ON (h.esta_paisid = i.pais_paisid)" +
 " WHERE prov_proveedorid = " + idProveedor.ToString
            If idPais > 0 Then
                Consulta += "AND i.pais_paisid = " + idPais.ToString
            End If
            If idEstado > 0 Then
                Consulta += " AND h.esta_estadoid = " + idEstado.ToString
            End If
            If idCiudad > 0 Then
                Consulta += " and  b.city_ciudadid = " + idCiudad.ToString
            End If



        Else
            Consulta = " SELECT c.prov_nombregenerico, '' AS 'pobl_nombre',b.city_nombre,h.esta_abreviatura,i.pais_abreviatura,f.unid_nombre,d.codm_costoporunidad," +
                        " 	e.tire_nombre,d.codm_diasminimoentrega,d.codm_diasmaximoentrega,b.city_nombre AS 'CiudadPoblacion'," +
                        " 	CASE WHEN d.codm_fechamodificacion IS NULL THEN d.codm_fechacreacion ELSE d.codm_fechamodificacion END AS 'Modificación'," +
                        " 	CASE WHEN d.codm_usuariomodificaid IS NULL THEN (SELECT user_username FROM Framework.Usuarios WHERE user_usuarioid = d.codm_usuariocreoid) " +
                        " 	ELSE (SELECT user_username FROM Framework.Usuarios WHERE user_usuarioid = d.codm_usuariomodificaid) END AS 'Usuario'," +
                        " 	d.codm_costodestinomensajeriaid, d.codm_activo,  h.esta_abreviatura AS 'EstadoPoblacion', i.pais_abreviatura AS 'PaisPoblacion'" +
                        " FROM Embarque.DestinoMensajeria AS a" +
                        " LEFT JOIN Framework.Ciudades AS b ON (a.deme_ciudadid = b.city_ciudadid)" +
                        " LEFT JOIN Proveedor.Proveedor AS c ON (a.deme_proveedorid = c.prov_proveedorid)" +
                        " LEFT JOIN Embarque.CostoDestinoMensajeria AS d ON (a.deme_destinomensajeriaid = d.codm_destinomensajeriaid)" +
                        " LEFT JOIN Embarque.TipoReembarque AS e ON (d.codm_tiporeembarqueid = e.tire_tiporeembarqueid)" +
                        " LEFT JOIN Framework.Unidad AS f ON (d.codm_unidadid = f.unid_unidadid)" +
                        " LEFT JOIN Framework.Estados AS h ON (b.city_estadoid = h.esta_estadoid)" +
                        " LEFT JOIN Framework.Paises AS i	ON (h.esta_paisid = i.pais_paisid)" +
                        " WHERE prov_proveedorid = " + idProveedor.ToString
            If idEstado > 0 Then
                Consulta += " AND h.esta_estadoid = " + idEstado.ToString
            End If
            Consulta += "  union" +
                        " SELECT c.prov_nombregenerico, g.pobl_nombre, b.city_nombre,h.esta_abreviatura,i.pais_abreviatura,f.unid_nombre,d.codm_costoporunidad," +
                        " 	e.tire_nombre,d.codm_diasminimoentrega,d.codm_diasmaximoentrega," +
                        " 	(SELECT w.city_nombre FROM Framework.Ciudades AS w WHERE w.city_ciudadid = g.pobl_ciudadid) AS 'CiudadPoblacion'," +
                        " 	CASE WHEN d.codm_fechamodificacion IS NULL THEN d.codm_fechacreacion ELSE d.codm_fechamodificacion END AS 'Modificación'," +
                        " 	CASE WHEN d.codm_usuariomodificaid IS NULL THEN (SELECT user_username FROM Framework.Usuarios WHERE user_usuarioid = d.codm_usuariocreoid)" +
                        " 	ELSE (SELECT user_username FROM Framework.Usuarios WHERE user_usuarioid = d.codm_usuariomodificaid) END AS 'Usuario'," +
                        " 	d.codm_costodestinomensajeriaid," +
                        " 	d.codm_activo," +
                        " 	(SELECT z.esta_abreviatura FROM Framework.Estados AS z WHERE z.esta_estadoid = (SELECT w.city_estadoid FROM Framework.Ciudades AS w WHERE w.city_ciudadid = g.pobl_ciudadid)) AS EstadoPoblacion," +
                        " 	(SELECT z.pais_abreviatura FROM Framework.Paises AS z WHERE z.pais_paisid = (SELECT z.esta_paisid FROM Framework.Estados AS z WHERE z.esta_estadoid = (SELECT w.city_estadoid FROM Framework.Ciudades AS w WHERE w.city_ciudadid = g.pobl_ciudadid))) AS PaisPoblacion" +
                        " FROM Embarque.DestinoMensajeria AS a" +
                        " LEFT JOIN Framework.Poblaciones AS g ON a.deme_poblacionid = g.pobl_poblacionid" +
                        " LEFT JOIN Framework.Ciudades AS b ON g.pobl_ciudadid = b.city_ciudadid" +
                        " LEFT JOIN Framework.Estados AS h ON b.city_estadoid = h.esta_estadoid" +
                        " LEFT JOIN Framework.Paises AS i	ON h.esta_paisid = i.pais_paisid" +
                        " LEFT JOIN Embarque.CostoDestinoMensajeria AS d ON a.deme_destinomensajeriaid = d.codm_destinomensajeriaid" +
                        " LEFT JOIN Proveedor.Proveedor AS c ON a.deme_proveedorid = c.prov_proveedorid" +
                        " LEFT JOIN Embarque.TipoReembarque AS e ON d.codm_tiporeembarqueid = e.tire_tiporeembarqueid" +
                        " LEFT JOIN Framework.Unidad AS f ON d.codm_unidadid = f.unid_unidadid" +
                        " WHERE prov_proveedorid = " + idProveedor.ToString
            If idEstado > 0 Then
                Consulta += " and h.esta_estadoid = " + idEstado.ToString

            End If
        End If




        If UnidadID > 0 Then
            Consulta += " and f.unid_unidadid=" + UnidadID.ToString
        End If


        Return operaciones.EjecutaConsulta(Consulta)


    End Function




    Public Sub AltaNuevoCostoDestinoMensajeria(ByVal EntidadMensajeria As Entidades.Mensajeria)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim ListaValores As New List(Of SqlParameter)
        Dim Valores As New SqlParameter

        Valores = New SqlParameter
        Valores.ParameterName = "Costoporunidad"
        Valores.Value = EntidadMensajeria.PCostoUnidad
        ListaValores.Add(Valores)

        Valores = New SqlParameter
        Valores.ParameterName = "Diasminimoentrega"
        Valores.Value = EntidadMensajeria.PDiasMinEntregas
        ListaValores.Add(Valores)

        Valores = New SqlParameter
        Valores.ParameterName = "Diasmaximoentrega"
        Valores.Value = EntidadMensajeria.PDiasMaxEntregas
        ListaValores.Add(Valores)

        Valores = New SqlParameter
        Valores.ParameterName = "Fechainiciovigencia"
        Valores.Value = EntidadMensajeria.PFechaInicioVigencia.ToShortDateString
        ListaValores.Add(Valores)

        Valores = New SqlParameter
        Valores.ParameterName = "FechaFinVigencia"
        Valores.Value = EntidadMensajeria.PFechaFinVigencia.ToShortDateString
        ListaValores.Add(Valores)

        Valores = New SqlParameter
        Valores.ParameterName = "TipodeReembarque"
        Valores.Value = EntidadMensajeria.PReembarque
        ListaValores.Add(Valores)

        Valores = New SqlParameter
        Valores.ParameterName = "UnidadID"
        Valores.Value = EntidadMensajeria.PNombreUnidad
        ListaValores.Add(Valores)

        Valores = New SqlParameter
        Valores.ParameterName = "DestinoMensajeriaID"
        Valores.Value = EntidadMensajeria.PIdDestinoMensajeria
        ListaValores.Add(Valores)

        Valores = New SqlParameter
        Valores.ParameterName = "UsuarioCreoid"
        Valores.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        ListaValores.Add(Valores)

        operaciones.EjecutarSentenciaSP("Embarque.SP_AltaDestinoMensajeria", ListaValores)

    End Sub

    Public Function ObtenerIDDestinoMensajeria(ByVal idProveedor As Int32, ByVal idCiudad As Int32, ByVal IdPoblacion As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = String.Empty

        If IdPoblacion = 0 Then
            consulta = "SELECT deme_destinomensajeriaid FROM Embarque.DestinoMensajeria where deme_ciudadid=" + idCiudad.ToString + " and deme_proveedorid=" + idProveedor.ToString
        Else
            consulta = "SELECT deme_destinomensajeriaid FROM Embarque.DestinoMensajeria where  deme_poblacionid=" + IdPoblacion.ToString + " and deme_proveedorid=" + idProveedor.ToString
        End If

        Return operaciones.EjecutaConsulta(consulta)
    End Function


    Public Sub InsertDestino(ByVal Proveedorid As Int32, ByVal CiudadID As Int32, ByVal PoblacionID As Int32)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaValores As New List(Of SqlParameter)

        Dim valores As New SqlParameter
        valores.ParameterName = "deme_proveedorid"
        valores.Value = Proveedorid
        listaValores.Add(valores)

        valores = New SqlParameter
        valores.ParameterName = "deme_ciudadid"
        valores.Value = CiudadID
        listaValores.Add(valores)

        valores = New SqlParameter
        valores.ParameterName = "deme_poblacionid"
        valores.Value = PoblacionID
        listaValores.Add(valores)

        valores = New SqlParameter
        valores.ParameterName = "deme_usuariocreoid"
        valores.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaValores.Add(valores)

        operaciones.EjecutarSentenciaSP("Embarque.SP_AltaDestino", listaValores)
    End Sub

End Class
