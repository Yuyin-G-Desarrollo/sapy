Imports ToolServicios

Public Class VerificacionSalidasBU

    Public Function InsertarParesOT(ByVal CodigoCapturado As String, ByVal EsCodigoPar As Boolean, ByVal FolioVerificacionID As Integer) As DataTable
        Dim objDA As New Almacen.Datos.VerificacionSalidasDA
        Dim tabla As New DataTable
        Try
            tabla = objDA.InsertarParesOT(CodigoCapturado, EsCodigoPar, FolioVerificacionID)
        Catch ex As Exception
            Throw ex
        End Try
        Return tabla
    End Function

    Public Function InsertarFolio(ByVal EntidadFolio As Entidades.InfoVerificacionFolio) As Integer
        Dim objDA As New Almacen.Datos.VerificacionSalidasDA
        Dim tabla As New DataTable
        Dim FolioVerificacionId As Integer = 0

        Try
            tabla = objDA.InsertarFolio(EntidadFolio)
            If IsNothing(tabla) = False Then
                If tabla.Rows.Count > 0 Then
                    FolioVerificacionId = CInt(tabla.Rows(0).Item(0))
                End If
            End If

        Catch ex As Exception
            Throw ex
        End Try
        Return FolioVerificacionId
    End Function

    Public Function ConsultaSessionActiva(ByVal ColaboradorId As Integer) As Boolean
        Dim objDA As New Almacen.Datos.VerificacionSalidasDA
        Dim tabla As New DataTable
        Dim Status As Boolean = False
        Try
            tabla = objDA.ConsultaSessionActiva(ColaboradorId)
            If IsNothing(tabla) = False Then
                If tabla.Rows.Count > 0 Then
                    If CInt(tabla.Rows(0).Item(0)) > 0 Then
                        Status = True
                    Else
                        Status = False
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
        Return Status
    End Function

    Public Function ParesPendientesDeConfirmar(ByVal FolioVerificacionID As Integer) As DataTable
        Dim objDA As New Almacen.Datos.VerificacionSalidasDA
        Dim tabla As New DataTable
        Try
            tabla = objDA.ParesPendientesDeConfirmar(FolioVerificacionID)
        Catch ex As Exception
            Throw ex
        End Try
        Return tabla
    End Function

    Public Function ConsultarParesOrdenTrabajo(ByVal FolioVerificacionID As Integer, ByVal OrdenTrabajoId As Integer) As DataTable
        Dim objDA As New Almacen.Datos.VerificacionSalidasDA
        Dim tabla As New DataTable
        Try
            tabla = objDA.ConsultarParesOrdenTrabajo(FolioVerificacionID, OrdenTrabajoId)
        Catch ex As Exception
            Throw ex
        End Try
        Return tabla
    End Function

    Public Function ConsultarParesConfirmados(ByVal FolioVerificacionID As Integer) As DataTable
        Dim objDA As New Almacen.Datos.VerificacionSalidasDA
        Dim tabla As New DataTable
        Try
            tabla = objDA.ConsultarParesConfirmados(FolioVerificacionID)
        Catch ex As Exception
            Throw ex
        End Try
        Return tabla
    End Function

    Public Function ConsultarFolios(ByVal FiltrarPorFecha As Boolean, ByVal FechaInicio As Date, ByVal FechaFin As Date, ByVal EstatusId As String, FolioVerificacionId As String, ByRef FiltroOT As String, ByVal Cedis As Integer) As DataTable
        Dim objDA As New Almacen.Datos.VerificacionSalidasDA
        Dim tabla As New DataTable
        Try
            tabla = objDA.ConsultarFolios(FiltrarPorFecha, FechaInicio, FechaFin, EstatusId, FolioVerificacionId, FiltroOT, Cedis)
        Catch ex As Exception
            Throw ex
        End Try
        Return tabla
    End Function

    Public Function ObtenerFolioVerificacionSession(ByVal ColaboradorID As Integer) As Integer
        Dim objDA As New Almacen.Datos.VerificacionSalidasDA
        Dim tabla As New DataTable
        Dim FolioVerificacionId As Integer = 0
        Try

            tabla = objDA.ObtenerFolioVerificacionSession(ColaboradorID)
            If IsNothing(tabla) = False Then
                If tabla.Rows.Count > 0 Then
                    FolioVerificacionId = CInt(tabla.Rows(0).Item(0))
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
        Return FolioVerificacionId
    End Function

    Public Function ValidaCodigoCapturado(ByVal CodigoCapturado As String, ByVal EsCodigoPar As Boolean, ByVal FolioVerificacion As Integer) As Boolean
        Dim objDA As New Almacen.Datos.VerificacionSalidasDA
        Dim tabla As New DataTable
        Dim ExisteCodigoPar As Integer = 0
        Dim ExisteCodigoParEnFolio As Integer = 0
        Dim REsultado As Boolean = False

        Try
            tabla = objDA.ValidaCodigoCapturado(CodigoCapturado, EsCodigoPar, FolioVerificacion)
            If IsNothing(tabla) = False Then
                If tabla.Rows.Count > 0 Then
                    ExisteCodigoPar = CInt(tabla.Rows(0).Item(0))
                    ExisteCodigoParEnFolio = CInt(tabla.Rows(0).Item(1))

                    If ExisteCodigoPar > 0 And ExisteCodigoParEnFolio = 0 Then
                        REsultado = True
                    Else
                        REsultado = False
                    End If

                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try

        Return REsultado
    End Function

    Public Function ConsultarParesVerificacionFolio(ByVal FolioVerificacionID As Integer) As DataTable
        Dim objDA As New Almacen.Datos.VerificacionSalidasDA
        Dim tabla As New DataTable
        Try
            tabla = objDA.ConsultarParesVerificacionFolio(FolioVerificacionID)
        Catch ex As Exception
            Throw ex
        End Try
        Return tabla
    End Function

    Public Function ConfirmarParesFolioVerificacion(ByVal FolioVerificacionID As Integer, ByVal EsCodigoPar As Boolean, ByVal CodigoCapturado As String, ByVal ColaboradorId As Integer) As DataTable
        Dim objDA As New Almacen.Datos.VerificacionSalidasDA
        Dim tabla As New DataTable
        Try
            tabla = objDA.ConfirmarParesFolioVerificacion(FolioVerificacionID, EsCodigoPar, CodigoCapturado, ColaboradorId)
        Catch ex As Exception
            Throw ex
        End Try
        Return tabla
    End Function

    Public Function ActualizarEncabezados(ByVal FolioVerificacionID As Integer) As DataTable
        Dim objDA As New Almacen.Datos.VerificacionSalidasDA
        Dim tabla As New DataTable
        Try
            tabla = objDA.ActualizarEncabezados(FolioVerificacionID)
        Catch ex As Exception
            Throw ex
        End Try
        Return tabla
    End Function

    Public Function FinalizarFolioVerificacion(ByVal FolioVerificacionID As Integer, ByVal MensajeriaId As Integer, ByVal Mensajeria As String, ByVal OperadorId As Integer, ByVal Operador As String, ByRef UnidadId As Integer, ByVal Unidad As String, ByVal FolioPaqueteria As String) As DataTable
        Dim objDA As New Almacen.Datos.VerificacionSalidasDA
        Dim tabla As New DataTable
        Try
            tabla = objDA.FinalizarFolioVerificacion(FolioVerificacionID, MensajeriaId, Mensajeria, OperadorId, Operador, UnidadId, Unidad, FolioPaqueteria)
        Catch ex As Exception
            Throw ex
        End Try
        Return tabla
    End Function

    Public Function DescartarOrdenTrabajo(ByVal FolioVerificacionID As Integer, ByVal OrdenTrabajo As Integer) As DataTable
        Dim objDA As New Almacen.Datos.VerificacionSalidasDA
        Dim tabla As New DataTable
        Try
            tabla = objDA.DescartarOrdenTrabajo(FolioVerificacionID, OrdenTrabajo)
        Catch ex As Exception
            Throw ex
        End Try
        Return tabla
    End Function

    Public Function ConsultaDetallesFolio(ByVal FolioVerificacionID As Integer) As DataTable
        Dim objDA As New Almacen.Datos.VerificacionSalidasDA
        Dim tabla As New DataTable
        Try
            tabla = objDA.ConsultaDetallesFolio(FolioVerificacionID)
        Catch ex As Exception
            Throw ex
        End Try
        Return tabla
    End Function

    Public Function ObtenerInformacionFolio(ByVal FolioVerificacionID As Integer) As DataTable
        Dim objDA As New Almacen.Datos.VerificacionSalidasDA
        Dim tabla As New DataTable
        Try
            tabla = objDA.ObtenerInformacionFolio(FolioVerificacionID)
        Catch ex As Exception
            Throw ex
        End Try
        Return tabla
    End Function

    Public Function ObtenerInformacionReporteFolio(ByVal FolioVerificacionID As Integer) As DataTable
        Dim objDA As New Almacen.Datos.VerificacionSalidasDA
        Dim tabla As New DataTable
        Try
            tabla = objDA.ObtenerInformacionReporteFolio(FolioVerificacionID)
        Catch ex As Exception
            Throw ex
        End Try
        Return tabla
    End Function

    Public Function ObtenerInformacionEncabezadoReporteFolio(ByVal FolioVerificacionID As Integer) As DataTable
        Dim objDA As New Almacen.Datos.VerificacionSalidasDA
        Dim tabla As New DataTable
        Try
            tabla = objDA.ObtenerInformacionEncabezadoReporteFolio(FolioVerificacionID)
        Catch ex As Exception
            Throw ex
        End Try
        Return tabla
    End Function

    Public Function GenerarEmbarqueYSalida(ByVal idNave As Integer) As DataTable
        Dim objDA As New Almacen.Datos.VerificacionSalidasDA
        Dim tabla As New DataTable
        Try
            tabla = objDA.GenerarEmbarqueYSalida(idNave)
        Catch ex As Exception
            Throw ex
        End Try
        Return tabla
    End Function

    Public Sub ActualizarFolioEmbarqueAFacturado(ByVal idNave As Integer)
        Dim objDA As New Almacen.Datos.VerificacionSalidasDA

        Try
            objDA.ActualizarFolioEmbarqueAFacturado(idNave)
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Sub GenerarDetallesSalidaVentas(ByVal idNave As Integer)
        Dim objDA As New Almacen.Datos.VerificacionSalidasDA

        Try
            objDA.GenerarDetallesSalidaVentas(idNave)
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Sub ActualizarOT_A_Entregado(ByVal idNave As Integer)
        Dim objDA As New Almacen.Datos.VerificacionSalidasDA

        Try
            objDA.ActualizarOT_A_Entregado(idNave)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function ConsultaCodigoError(ByVal FolioVerificacionID As Integer) As DataTable
        Dim objDA As New Datos.VerificacionSalidasDA
        Dim tabla As New DataTable

        Try
            tabla = objDA.ConsultaCodigoError(FolioVerificacionID)

            Return tabla
        Catch ex As Exception
            Throw ex
            Return Nothing
        End Try
    End Function

    Public Function ValidaUsuario(ByVal Colaborador As Integer) As Integer
        Dim objDA As New Datos.VerificacionSalidasDA
        Dim tabla As New DataTable
        Dim ColaboradorID As Integer = 0

        Try
            tabla = objDA.ValidaUsuario(Colaborador)
            If IsNothing(tabla) = False Then
                If tabla.Rows.Count > 0 Then
                    ColaboradorID = tabla.Rows(0).Item(0)
                End If
            Else
                ColaboradorID = 0
            End If

            Return ColaboradorID

        Catch ex As Exception
            Throw ex
            Return Nothing
        End Try
    End Function

    Public Function DescartarPares(ByVal FolioVerificacionID As Integer, ByVal Codigo As String, ByVal EsCodigoPar As Boolean) As DataTable
        Dim objDA As New Datos.VerificacionSalidasDA
        Dim tabla As New DataTable

        Try
            tabla = objDA.DescartarPares(FolioVerificacionID, Codigo, EsCodigoPar)
            Return tabla
        Catch ex As Exception
            Throw ex
            Return Nothing
        End Try
    End Function

    Public Function ConsultaLotesAndreaPorOT(ByVal FechaConfirmacion As Date, ByVal FechaFinConfirmacion As Date) As DataTable
        Dim objDA As New Datos.VerificacionSalidasDA
        Dim tabla As New DataTable

        Try
            tabla = objDA.ConsultaLotesAndreaPorOT(FechaConfirmacion, FechaFinConfirmacion)
            Return tabla
        Catch ex As Exception
            Throw ex
            Return Nothing
        End Try
    End Function

    Public Function InsertarParesAndrea(ByVal FolioVerificacionID As Integer, ByVal OT As Integer, ByVal LoteAndrea As Integer, ByVal Partida As Integer) As DataTable
        Dim objDA As New Datos.VerificacionSalidasDA
        Dim tabla As New DataTable

        Try
            tabla = objDA.InsertarParesAndrea(FolioVerificacionID, OT, LoteAndrea, Partida)
            Return tabla
        Catch ex As Exception
            Throw ex
            Return Nothing
        End Try
    End Function

    Public Function ConsultarParesAConfirmarAndrea(ByVal FolioVerificacionID As Integer) As DataTable
        Dim objDA As New Datos.VerificacionSalidasDA
        Dim tabla As New DataTable

        Try
            tabla = objDA.ConsultarParesAConfirmarAndrea(FolioVerificacionID)
            Return tabla
        Catch ex As Exception
            Throw ex
            Return Nothing
        End Try
    End Function

    Public Function ConsultarParesConfirmadosAndrea(ByVal FolioVerificacionID As Integer) As DataTable
        Dim objDA As New Datos.VerificacionSalidasDA
        Dim tabla As New DataTable

        Try
            tabla = objDA.ConsultarParesConfirmadosAndrea(FolioVerificacionID)
            Return tabla
        Catch ex As Exception
            Throw ex
            Return Nothing
        End Try
    End Function

    Public Function ConfirmarParesAndrea(ByVal FolioVerificacionID As Integer, ByVal CodigoAndrea As String, ByVal ColaboradorId As Integer) As DataTable
        Dim objDA As New Datos.VerificacionSalidasDA
        Dim tabla As New DataTable

        Try
            tabla = objDA.ConfirmarParesAndrea(FolioVerificacionID, CodigoAndrea, ColaboradorId)
            Return tabla
        Catch ex As Exception
            Throw ex
            Return Nothing
        End Try
    End Function

    Public Function InsertaCodigoErrorAndrea(ByVal FolioVerificacionID As Integer, ByVal CodigoAndrea As String, ByVal MensajeError As String) As DataTable
        Dim objDA As New Datos.VerificacionSalidasDA
        Dim tabla As New DataTable

        Try
            tabla = objDA.InsertaCodigoErrorAndrea(FolioVerificacionID, CodigoAndrea, MensajeError)
            Return tabla
        Catch ex As Exception
            Throw ex
            Return Nothing
        End Try
    End Function

    Public Function LimpiarParesAndrea(ByVal FolioVerificacionID As Integer, ByVal CodigoAndrea As String) As DataTable
        Dim objDA As New Datos.VerificacionSalidasDA
        Dim tabla As New DataTable

        Try
            tabla = objDA.LimpiarParesAndrea(FolioVerificacionID, CodigoAndrea)
            Return tabla
        Catch ex As Exception
            Throw ex
            Return Nothing
        End Try
    End Function

    Public Function ConsultaOTsPendientesSalida(ByVal ClienteID As Integer) As List(Of Entidades.OTPendienteVerificar)
        Dim objDA As New Datos.VerificacionSalidasDA
        Dim tabla As New DataTable
        Dim ListaOT As New List(Of Entidades.OTPendienteVerificar)
        Dim tool As ToolServicios.Convertidor(Of Entidades.OTPendienteVerificar) = New ToolServicios.Convertidor(Of Entidades.OTPendienteVerificar)

        Try
            tabla = objDA.ConsultaOTsPendientesSalida(ClienteID)
            ListaOT = tool.DataTableToList(tabla)

            Return ListaOT
        Catch ex As Exception
            Throw ex
            Return Nothing
        End Try
    End Function


    Public Function InsertarOT(ByVal FolioVerificacionID As Integer, ByVal OrdenTrabajoID As String) As DataTable
        Dim objDA As New Datos.VerificacionSalidasDA
        Dim tabla As New DataTable

        Try
            tabla = objDA.InsertarOT(FolioVerificacionID, OrdenTrabajoID)
            Return tabla
        Catch ex As Exception
            Throw ex
            Return Nothing
        End Try
    End Function

    Public Function SessionActivaAndrea() As Boolean
        Dim objDA As New Datos.VerificacionSalidasDA
        Dim tabla As New DataTable
        Dim Resultado As Boolean = False

        Try
            tabla = objDA.SessionActivaAndrea()
            If tabla.Rows.Count > 0 Then

                If tabla.Rows(0).Item(0) > 0 Then
                    Resultado = True
                Else
                    Resultado = False
                End If
            End If

            Return Resultado
        Catch ex As Exception
            Throw ex
            Return Nothing
        End Try
    End Function

    Public Function ConsultaFolioAndrea() As DataTable
        Dim objDA As New Datos.VerificacionSalidasDA
        Dim tabla As New DataTable

        Try
            tabla = objDA.ConsultaFolioAndrea()
            Return tabla
        Catch ex As Exception
            Throw ex
            Return Nothing
        End Try

    End Function


    Public Function ConsultaLotesAndrea(ByVal FolioVerificacionId As Integer) As List(Of Entidades.LotesAndreaFolioVerificacion)
        Dim objDA As New Datos.VerificacionSalidasDA
        Dim tabla As New DataTable
        Dim ListaLotes As New List(Of Entidades.LotesAndreaFolioVerificacion)
        Dim tool As ToolServicios.Convertidor(Of Entidades.LotesAndreaFolioVerificacion) = New ToolServicios.Convertidor(Of Entidades.LotesAndreaFolioVerificacion)

        Try
            tabla = objDA.ConsultaLotesAndrea(FolioVerificacionId)
            ListaLotes = tool.DataTableToList(tabla)
            Return ListaLotes
        Catch ex As Exception
            Throw ex
            Return Nothing

        End Try

    End Function

    Public Function QuitarLotesAndrea(ByVal FolioVerificacionId As Integer, ByVal OrdenTrabajoID As Integer, ByVal LoteAndrea As Integer) As DataTable
        Dim objDA As New Datos.VerificacionSalidasDA
        Dim tabla As New DataTable


        Try
            tabla = objDA.QuitarLotesAndrea(FolioVerificacionId, OrdenTrabajoID, LoteAndrea)
            Return tabla
        Catch ex As Exception
            Throw ex
            Return Nothing

        End Try

    End Function

    Public Function ConsultaFolioDevolucionPendienteSalida() As DataTable
        Dim objDA As New Datos.VerificacionSalidasDA
        Dim tabla As New DataTable

        Try
            tabla = objDA.ConsultaFolioDevolucionPendienteSalida()
            Return tabla
        Catch ex As Exception
            Throw ex
            Return Nothing

        End Try

    End Function

    Public Function GenerarSalidaFolioDevolucion(ByVal FoliosDevolucion As String) As DataTable
        Dim objDA As New Datos.VerificacionSalidasDA
        Dim tabla As New DataTable

        Try
            tabla = objDA.GenerarSalidaFolioDevolucion(FoliosDevolucion)
            Return tabla
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function ObtenerNaveUsuario(ByVal usuarioid As Integer)
        Dim obj As New Datos.VerificacionSalidasDA
        Dim tbl As New DataTable
        Dim idnave As Integer
        tbl = obj.ObtenerNaveUsuario(usuarioid)
        idnave = tbl.Rows(0).Item("NaveId")
        Return idnave
    End Function

End Class
