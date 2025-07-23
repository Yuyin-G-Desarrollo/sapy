
Public Class CatalogoEventoBU

    ''' <summary>
    ''' Obtiene un listado con la informacion de los eventos
    ''' </summary>
    ''' <param name="activo">TRUE: Devuelve un listado de los eventos activos, FALSE: Devuelve un listado de los eventos inactivos</param>
    ''' <param name="NombreEvento">Filtra la informacion por el nombre del evento</param>
    ''' <returns>DataTable con la informacion del evento</returns>
    ''' <remarks></remarks>
    Public Function ListaEventos(ByVal activo As Boolean, Optional ByVal NombreEvento As String = "") As DataTable
        Dim objListaEventos As New Datos.CatalogoEventosDA
        Dim DTInformacionEvento As New DataTable
        DTInformacionEvento = objListaEventos.ListaEventos(activo, NombreEvento)

        Return DTInformacionEvento
    End Function

    ''' <summary>
    ''' Obtiene la informacion de un evento en especifico
    ''' </summary>
    ''' <param name="EventoID">Identificador del evento</param>
    ''' <returns>DataTable con la informaicon del evento</returns>
    ''' <remarks></remarks>
    Public Function ObtenerInformacionEvento(ByVal EventoID As Integer) As Entidades.Evento
        Dim objInformacionEvento As New Datos.CatalogoEventosDA
        Dim DTInformacionEvento As New DataTable
        Dim EntidadEvento As New Entidades.Evento
        DTInformacionEvento = objInformacionEvento.ObtenerInformacionEvento(EventoID)

        If DTInformacionEvento.Rows.Count = 1 Then
            EntidadEvento.EEventoId = CInt(DTInformacionEvento.Rows(0).Item(0).ToString())
            EntidadEvento.ENombre = DTInformacionEvento.Rows(0).Item(1).ToString()
            EntidadEvento.EAbreviatura = DTInformacionEvento.Rows(0).Item(2).ToString()
            EntidadEvento.ELugar = DTInformacionEvento.Rows(0).Item(3).ToString()

            If IsDate(DTInformacionEvento.Rows(0).Item(4).ToString()) = True Then
                EntidadEvento.EFechaInicioEvento = CDate(DTInformacionEvento.Rows(0).Item(4).ToString())
            Else
                EntidadEvento.EFechaInicioEvento = Nothing
            End If

            If IsDate(DTInformacionEvento.Rows(0).Item(5).ToString()) = True Then
                EntidadEvento.EFEchaFinEvento = CDate(DTInformacionEvento.Rows(0).Item(5).ToString())
            Else
                EntidadEvento.EFEchaFinEvento = Nothing
            End If

            If IsDate(DTInformacionEvento.Rows(0).Item(8).ToString()) = True Then
                EntidadEvento.EFechaEntregaColeccionesVigentes = CDate(DTInformacionEvento.Rows(0).Item(8).ToString())
            Else
                EntidadEvento.EFechaEntregaColeccionesVigentes = Nothing
            End If

            If IsDate(DTInformacionEvento.Rows(0).Item(9).ToString()) = True Then
                EntidadEvento.EFechaEntregaColeccionesNuevas = CDate(DTInformacionEvento.Rows(0).Item(9).ToString())
            Else
                EntidadEvento.EFechaEntregaColeccionesNuevas = Nothing
            End If

            EntidadEvento.EActivo = CBool(DTInformacionEvento.Rows(0).Item(10).ToString())
            EntidadEvento.EUsuarioCreoId = CInt(DTInformacionEvento.Rows(0).Item(11).ToString())


            If String.IsNullOrEmpty(DTInformacionEvento.Rows(0).Item(6).ToString()) = False Then
                EntidadEvento.EParesPedidos = CInt(DTInformacionEvento.Rows(0).Item(6).ToString())
            Else
                EntidadEvento.EParesPedidos = 0
            End If

            If String.IsNullOrEmpty(DTInformacionEvento.Rows(0).Item(7).ToString()) = False Then
                EntidadEvento.EConsecutivoVisitante = CInt(DTInformacionEvento.Rows(0).Item(7).ToString())
            Else
                EntidadEvento.EConsecutivoVisitante = 0
            End If


            If String.IsNullOrEmpty(DTInformacionEvento.Rows(0).Item(12).ToString()) = False Then
                EntidadEvento.EUsuarioModificoId = CInt(DTInformacionEvento.Rows(0).Item(12).ToString())
            Else
                EntidadEvento.EUsuarioModificoId = 0
            End If

            If String.IsNullOrEmpty(DTInformacionEvento.Rows(0).Item(13).ToString()) = False Then
                EntidadEvento.EFechaCreacion = CDate(DTInformacionEvento.Rows(0).Item(13).ToString())
            Else
                EntidadEvento.EFechaCreacion = Nothing
            End If

            If String.IsNullOrEmpty(DTInformacionEvento.Rows(0).Item(14).ToString()) = False Then
                EntidadEvento.EFechaModificacion = CDate(DTInformacionEvento.Rows(0).Item(14).ToString())
            Else
                EntidadEvento.EFechaModificacion = Nothing
            End If

        End If

        Return EntidadEvento
    End Function

    ''' <summary>
    ''' Registra la informacion de un evento en la base de datos
    ''' </summary>
    ''' <param name="Evento">Es el contenedor de la informacion del evento</param>
    ''' <remarks></remarks>
    Public Sub GuardarEvento(ByVal Evento As Entidades.Evento)
        Dim objEvento As New Datos.CatalogoEventosDA
        objEvento.AltaEvento(Evento)
    End Sub


    ''' <summary>
    ''' Modifica la informacion de un evento
    ''' </summary>
    ''' <param name="Evento">Es el contenedor de un evento</param>
    ''' <remarks></remarks>
    Public Sub EditarEvento(ByVal Evento As Entidades.Evento)
        Dim ObjEditarEvento As New Datos.CatalogoEventosDA
        ObjEditarEvento.EditarEvento(Evento)
    End Sub

    Public Function ComprobarEventoActivo(Optional ByVal EventoID As Integer = -1) As Boolean
        Dim ObjEditarEvento As New Datos.CatalogoEventosDA
        Return ObjEditarEvento.ComprobarEventoActivo(EventoID)
    End Function
End Class
