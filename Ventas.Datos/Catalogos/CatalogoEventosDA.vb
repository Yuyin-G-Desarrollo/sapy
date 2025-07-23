Imports System.Data.SqlClient

Public Class CatalogoEventosDA

    ''' <summary>
    ''' Devuelve un listado de la informacion de los eventos
    ''' </summary>
    ''' <param name="Activo">TRUE= Devuelve solo los eventos activos, FALSE = Devuelve los eventos inactivos</param>
    ''' <param name="Nombre">Parametro opcional, recibe el nombre del evento a buscar</param>    
    ''' <returns>DataTable con la informacion</returns>
    ''' <remarks></remarks>
    Public Function ListaEventos(ByVal Activo As Boolean, Optional ByVal Nombre As String = "") As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "  "

        consulta = "SELECT even_eventoid AS 'EventoID', "
        consulta += "even_nombre AS 'Evento' , "
        consulta += "even_abreviatura AS 'Abreviatura', "
        consulta += "even_lugar AS 'Lugar', "
        consulta += "even_fechainicioevento AS 'FInicio', "
        consulta += "even_fechafinevento AS 'FFin', "
        consulta += "even_parespedidos AS 'Pares Pedido', "
        consulta += "even_consecutivovisitante AS 'Consecutivo Visitante' , "
        consulta += "even_fechaentrega_coleccionesvigentes AS 'FEColeccVigentes' , "
        consulta += "even_fechaentrega_coleccionesnuevas AS 'FEColeccNuevas' , "
        consulta += "even_activo AS 'Activo' , "
        consulta += "even_usuariocreoid AS 'UsuarioCreoID', "
        consulta += "even_usuariomodificaid AS 'UsuarioModificaID', "
        consulta += "even_fechacreacion AS 'FCreación', "
        consulta += "even_fechamodificacion AS 'FModificación' "
        consulta += "FROM Ventas.Eventos "
        consulta += "WHERE even_activo = '" + Activo.ToString() + "' "
        consulta += "AND even_nombre like '%" + Nombre.ToString() + "%' "
        consulta += "ORDER BY even_fechainicioevento DESC "

        Return operaciones.EjecutaConsulta(consulta)
    End Function


    ''' <summary>
    ''' Consulta la informacion de un evento dado
    ''' </summary>
    ''' <returns>Regresa un DataTable</returns>
    ''' <remarks></remarks>
    Public Function ObtenerInformacionEvento(ByVal EventoId As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "  "
        consulta = "SELECT even_eventoid AS 'EventoID', "
        consulta += "even_nombre AS 'Evento', "
        consulta += "even_abreviatura AS 'Abreviatura', "
        consulta += "even_lugar AS 'Lugar', "
        consulta += "even_fechainicioevento AS 'FInicio', "
        consulta += "even_fechafinevento AS 'FFin', "
        consulta += "even_parespedidos AS 'Pares Pedido', "
        consulta += "even_consecutivovisitante AS 'Consecutivo Visitante', "
        consulta += "even_fechaentrega_coleccionesvigentes AS 'FEColeccVigentes', "
        consulta += "even_fechaentrega_coleccionesnuevas AS 'FEColeccNuevas', "
        consulta += "even_activo AS 'Activo', "
        consulta += "even_usuariocreoid AS 'UsuarioCreoID', "
        consulta += "even_usuariomodificaid AS 'UsuarioModificaID', "
        consulta += "even_fechacreacion AS 'FCreación', "
        consulta += "even_fechamodificacion AS 'FModificación' "
        consulta += "FROM Ventas.Eventos "
        consulta += "WHERE even_eventoid='" + EventoId.ToString() + "' "

        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function ComprobarEventoActivo(Optional ByVal EventoId As Integer = -1) As Boolean
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "  "
        Dim ExisteEventoActivo As Boolean = False
        consulta = "SELECT count(*) as 'Existe' "
        consulta += "FROM Ventas.Eventos "
        consulta += "WHERE even_activo =1  "
        If EventoId >= 0 Then
            consulta += "AND  even_eventoid <> '" + EventoId.ToString() + "' "
        End If
        Dim Resultado As Integer = operaciones.EjecutaConsultaEscalar(consulta)
        If Resultado <> 0 Then
            ExisteEventoActivo = True
        Else
            ExisteEventoActivo = False
        End If
        Return ExisteEventoActivo
    End Function


    ''' <summary>
    ''' Registra un evento en la base de datos, ademas de que si es un evento activo 
    ''' cambia el estado de los demas eventos a inactivo
    ''' </summary>
    ''' <param name="Evento">Entidad Evento</param>
    ''' <remarks></remarks>
    Public Sub AltaEvento(ByVal Evento As Entidades.Evento)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "NombreEvento"
        parametro.Value = Evento.ENombre
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Abreviatura"
        parametro.Value = Evento.EAbreviatura
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Lugar"
        parametro.Value = Evento.ELugar
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FechaInicioEvento"
        parametro.Value = Evento.EFechaInicioEvento
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FechaFinEvento"
        parametro.Value = Evento.EFEchaFinEvento
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ParesPedidos"
        parametro.Value = Evento.EParesPedidos
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ConsecutivoVisitante"
        parametro.Value = Evento.EConsecutivoVisitante
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FechaEntregaColeccionNueva"
        parametro.Value = Evento.EFechaEntregaColeccionesNuevas
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FechaEntregaColeccionVigente"
        parametro.Value = Evento.EFechaEntregaColeccionesVigentes
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Activo"
        parametro.Value = Evento.EActivo.ToString()
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "UsuarioIDCreo"
        parametro.Value = Evento.EUsuarioCreoId
        listaparametros.Add(parametro)

        'Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        operaciones.EjecutarSentenciaSP("Ventas.sp_Alta_Evento", listaparametros)
    End Sub

    ''' <summary>
    ''' Modifica la informacion de un evento
    ''' </summary>
    ''' <param name="Evento">Contiene la informacion del evento</param>
    ''' <remarks></remarks>
    Public Sub EditarEvento(ByVal Evento As Entidades.Evento)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "even_eventoid"
        parametro.Value = Evento.EEventoId

        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "NombreEvento"
        parametro.Value = Evento.ENombre
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Abreviatura"
        parametro.Value = Evento.EAbreviatura
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Lugar"
        parametro.Value = Evento.ELugar
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FechaInicioEvento"
        parametro.Value = Evento.EFechaInicioEvento
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FechaFinEvento"
        parametro.Value = Evento.EFEchaFinEvento
        listaparametros.Add(parametro)
        parametro = New SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "ParesPedidos"
        parametro.Value = Evento.EParesPedidos
        listaparametros.Add(parametro)
        parametro = New SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "ConsecutivoVisitante"
        parametro.Value = Evento.EConsecutivoVisitante
        listaparametros.Add(parametro)
        parametro = New SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "FechaEntregaColeccionNueva"
        parametro.Value = Evento.EFechaEntregaColeccionesNuevas
        listaparametros.Add(parametro)
        parametro = New SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "FechaEntregaColeccionVigente"
        parametro.Value = Evento.EFechaEntregaColeccionesVigentes
        listaparametros.Add(parametro)
        parametro = New SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "Activo"
        parametro.Value = Evento.EActivo
        listaparametros.Add(parametro)
        parametro = New SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "UsuarioIDModifica"
        parametro.Value = Evento.EUsuarioModificoId
        listaparametros.Add(parametro)
        parametro = New SqlParameter

        operaciones.EjecutarSentenciaSP("Ventas.sp_Editar_Evento", listaparametros)


    End Sub

End Class
