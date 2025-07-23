Imports System.Security.Cryptography
Public Class InspeccionCalidadBU

    Public Function ValidaFolio(ByVal Folio As String) As Entidades.InspeccionCalidadValidaFolio
        Dim objDA As New Datos.InspeccionCalidadDA
        Dim tabla As New DataTable
        Dim EntFolio As New Entidades.InspeccionCalidadValidaFolio

        Try
            tabla = objDA.ValidaFolio(Folio)
            If IsNothing(tabla) = False Then
                If tabla.Rows.Count > 0 Then
                    EntFolio.Folio = tabla.Rows(0).Item("Folio")
                    EntFolio.Mensaje = tabla.Rows(0).Item("Mensaje")
                    EntFolio.Estatus = CBool(tabla.Rows(0).Item("EstatusFolio"))
                End If
            End If

        Catch ex As Exception
            Throw ex
        End Try

        Return EntFolio

    End Function

    Public Function ValidarExisteIncidenciaPar(ByVal InspeccionParID As Integer, ByVal IncidenciaID As Integer) As DataTable
        Dim objDA As New Datos.InspeccionCalidadDA
        Dim tabla As New DataTable

        Try
            tabla = objDA.ValidarExisteIncidenciaPar(InspeccionParID, IncidenciaID)
        Catch ex As Exception
            Throw ex
        End Try

        Return tabla

    End Function

    Public Function RegistrarIncidenciaPar(ByVal InspeccionParID As Integer, ByVal InspeccionId As Integer, ByVal IdIncidencia As Integer, ByVal UsuarioID As Integer, ByVal Observaciones As String, ByVal TipoIncidencia As String, ByVal RutaFotoUno As String, ByVal RutaFotoDos As String) As DataTable
        Dim objDA As New Datos.InspeccionCalidadDA
        Dim tabla As New DataTable

        Try
            tabla = objDA.RegistrarIncidenciaPar(InspeccionParID, InspeccionId, IdIncidencia, UsuarioID, Observaciones, TipoIncidencia, RutaFotoUno, RutaFotoDos)
        Catch ex As Exception
            Throw ex
        End Try

        Return tabla

    End Function

    Public Function ObtenerInformacionCodigoClienteEscaneado(ByVal CodigoCliente As String, ByVal CodigoAtado As String, ByVal FolioInspeccion As Integer) As DataTable
        Dim objDA As New Datos.InspeccionCalidadDA
        Dim tabla As New DataTable

        Try
            tabla = objDA.ObtenerInformacionCodigoClienteEscaneado(CodigoCliente, CodigoAtado, FolioInspeccion)
        Catch ex As Exception
            Throw ex
        End Try

        Return tabla

    End Function

    Public Function ObtenerInformacionParEscaneado(ByVal CodigoPar As String, ByVal FolioInspeccion As String, ByVal FolioSalidaId As Integer, ByVal UsuarioID As Integer) As Entidades.LecturaParInspeccionado
        'Dim objDA As New Datos.InspeccionCalidadDA
        'Dim tabla As New DataTable
        'Dim EntInformacionParLeido As New Entidades.InformacionParLeido
        'Try
        '    tabla = objDA.ObtenerInformacionParEscaneado(CodigoPar, FolioInspeccion, UsuarioID)
        '    If IsNothing(tabla) = False Then
        '        If tabla.Rows.Count > 0 Then
        '            With EntInformacionParLeido
        '                .Estatus = CBool(tabla.Rows(0).Item("Estatus"))
        '                .InspeccionParID = tabla.Rows(0).Item("InspeccionParID")
        '                .Lote = tabla.Rows(0).Item("Lote")
        '                .NaveID = tabla.Rows(0).Item("NaveID")
        '                .Nave = tabla.Rows(0).Item("Nave")
        '                .Año = tabla.Rows(0).Item("Año")
        '                .MarcaSAY = tabla.Rows(0).Item("MarcaSAY")
        '                .ColeccionSAY = tabla.Rows(0).Item("ColeccionSAY")
        '                .Color = tabla.Rows(0).Item("Color")
        '                .Piel = tabla.Rows(0).Item("Piel")
        '                .Corrida = tabla.Rows(0).Item("Corrida")
        '                .Talla = tabla.Rows(0).Item("Talla")
        '                .Pedido = tabla.Rows(0).Item("Pedido")
        '                .Atado = tabla.Rows(0).Item("Atado")
        '                .NumeroAtado = tabla.Rows(0).Item("NumeroAtado")
        '                .CodigoPar = tabla.Rows(0).Item("CodigoPar")
        '                .Folio = tabla.Rows(0).Item("Folio")
        '                .UsuarioId = tabla.Rows(0).Item("UsuarioID")
        '            End With
        '        End If
        '    End If

        'Catch ex As Exception
        '    Throw ex
        'End Try

        'Return EntInformacionParLeido

        '****************************************************************

        Dim objDA As New Datos.InspeccionCalidadDA
        Dim tabla As New DataTable
        Dim dtLotesPilotoFolio As New DataTable
        Dim EntInformacionParLeido As New Entidades.LecturaParInspeccionado
        Try
            tabla = objDA.ObtenerInformacionParEscaneado(CodigoPar, FolioInspeccion, FolioSalidaId, UsuarioID)
            If IsNothing(tabla) = False Then
                If tabla.Rows.Count > 0 Then
                    With EntInformacionParLeido
                        With .InformacionPar
                            .Estatus = CBool(tabla.Rows(0).Item("Estatus"))
                            .InspeccionParID = tabla.Rows(0).Item("InspeccionParID")
                            .Lote = tabla.Rows(0).Item("Lote")
                            .NaveID = tabla.Rows(0).Item("NaveID")
                            .Nave = tabla.Rows(0).Item("Nave")
                            .Año = tabla.Rows(0).Item("Año")
                            .MarcaSAY = tabla.Rows(0).Item("MarcaSAY")
                            .ColeccionSAY = tabla.Rows(0).Item("ColeccionSAY")
                            .Color = tabla.Rows(0).Item("Color")
                            .Piel = tabla.Rows(0).Item("Piel")
                            .Corrida = tabla.Rows(0).Item("Corrida")
                            .Talla = tabla.Rows(0).Item("Talla")
                            .Pedido = tabla.Rows(0).Item("Pedido")
                            .Atado = tabla.Rows(0).Item("Atado")
                            .NumeroAtado = tabla.Rows(0).Item("NumeroAtado")
                            .CodigoPar = tabla.Rows(0).Item("CodigoPar")
                            .Folio = tabla.Rows(0).Item("Folio")
                            .UsuarioId = tabla.Rows(0).Item("UsuarioID")
                            .ClienteSAYID = tabla.Rows(0).Item("ClienteSAYID")
                            .ClienteSICYID = tabla.Rows(0).Item("ClienteSICYID")
                            .RutaImagenZapato = tabla.Rows(0).Item("RutaImagenZapato")
                            .NombreCliente = tabla.Rows(0).Item("NombreCliente")
                            .ModeloSAY = tabla.Rows(0).Item("ModeloSAY")
                        End With

                        If IsDate(tabla.Rows(0).Item("FechaInicio")) = True Then
                            .FechaInicio = tabla.Rows(0).Item("FechaInicio")
                        Else
                            .FechaInicio = Nothing
                        End If

                        If IsDate(tabla.Rows(0).Item("FechaTemino")) = True Then
                            .FechaTermino = tabla.Rows(0).Item("FechaTemino")
                        Else
                            .FechaTermino = Nothing
                        End If

                        .Nave = tabla.Rows(0).Item("Nave")
                        .NaveId = CInt(tabla.Rows(0).Item("NaveID"))
                        .ParesAInspeccionar = tabla.Rows(0).Item("ParesAInspeccionar")
                        .ParesDevueltos = tabla.Rows(0).Item("ParesDevueltos")
                        .ParesFolio = tabla.Rows(0).Item("ParesFolio")
                        .ParesIncidencias = tabla.Rows(0).Item("NumeroIncidencias")
                        .ParesIncidenciasCriticas = tabla.Rows(0).Item("NumeroIncidenciasCriticas")
                        .ParesInspeccionados = tabla.Rows(0).Item("ParesInspeccionados")
                        .ParesInspeccionadosLotePiloto = tabla.Rows(0).Item("ParesInspeccionadosLotesPiloto")
                        .ParesLotePiloto = tabla.Rows(0).Item("ParesLotesPiloto")
                        .PorcentajeAInspeccionar = tabla.Rows(0).Item("PorcentajeAInspeccionar")
                        .PorcentajeInspeccionado = tabla.Rows(0).Item("PorcentajeInspeccionado")
                        .RutaLogoNave = tabla.Rows(0).Item("RutaLogo")
                        .UsuarioId = CInt(tabla.Rows(0).Item("UsuarioID"))
                        .FolioInspeccionID = tabla.Rows(0).Item("FolioInspeccionID")
                        .Folio = tabla.Rows(0).Item("Folio")

                        .LotesPiloto = New List(Of Entidades.LotesInspeccionados)

                        dtLotesPilotoFolio = objDA.ObtenerLotesPiloto(.FolioInspeccionID)
                        Dim LotePiloto As New Entidades.LotesInspeccionados

                        For Each Fila As DataRow In dtLotesPilotoFolio.Rows
                            LotePiloto = New Entidades.LotesInspeccionados
                            LotePiloto.Año = Fila.Item("Año")
                            LotePiloto.Estatus = Fila.Item("Status")
                            LotePiloto.Estilo = Fila.Item("Descripcion")
                            LotePiloto.Lote = Fila.Item("Lote")
                            LotePiloto.NaveID = Fila.Item("NaveID")
                            LotePiloto.Pares = Fila.Item("ParesLote")
                            LotePiloto.Descripcion = Fila.Item("Descripcion")
                            .LotesPiloto.Add(LotePiloto)
                        Next
                    End With

                End If
            End If

        Catch ex As Exception
            Throw ex
        End Try

        Return EntInformacionParLeido

    End Function

    Public Function ObtenerInformacionParEscaneado(ByVal Folio As Integer, ByVal UsuarioId As Integer) As DataTable
        Dim objDA As New Datos.InspeccionCalidadDA
        Dim tabla As New DataTable

        Try
            tabla = objDA.ObtenerInformacionParEscaneado(Folio, UsuarioId)
        Catch ex As Exception
            Throw ex
        End Try

        Return tabla

    End Function


    Public Function login(ByVal Usuario As String, ByVal Password As String) As Entidades.Usuarios
        Dim ObjUsuarioDA As New Almacen.Datos.InspeccionCalidadDA
        'Convierte la cadena de la contraseña a md5
        Dim Resultado As String
        Resultado = StringToMd5(Password)
        Dim UsuarioLogin As New Entidades.Usuarios
        UsuarioLogin = ObjUsuarioDA.CheckLogin(Usuario, Resultado)

        If (Not IsNothing(UsuarioLogin)) And UsuarioLogin.PUserUsuarioid > 0 Then
            Return UsuarioLogin
        Else
            UsuarioLogin.PUserUsuarioid = -1
            Return UsuarioLogin
        End If

    End Function

    Public Function login(ByVal Usuario As String) As Entidades.Usuarios
        Dim ObjUsuarioDA As New Almacen.Datos.InspeccionCalidadDA
        'Convierte la cadena de la contraseña a md5

        Dim UsuarioLogin As New Entidades.Usuarios
        UsuarioLogin = ObjUsuarioDA.CheckLogin(Usuario)

        If (Not IsNothing(UsuarioLogin)) And UsuarioLogin.PUserUsuarioid > 0 Then
            Return UsuarioLogin
        Else
            UsuarioLogin.PUserUsuarioid = -1
            Return UsuarioLogin
        End If

    End Function

    Private Function StringToMd5(StrPass As String) As String
        Dim PasConMd5 As String
        PasConMd5 = ""
        Dim md5 As New MD5CryptoServiceProvider
        Dim bytValue() As Byte
        Dim bytHash() As Byte
        Dim i As Integer

        bytValue = System.Text.Encoding.UTF8.GetBytes(StrPass)
        bytHash = md5.ComputeHash(bytValue)
        md5.Clear()

        For i = 0 To bytHash.Length - 1
            PasConMd5 &= bytHash(i).ToString("x").PadLeft(2, CChar("0"))
        Next

        Return PasConMd5
    End Function

    Public Function ValidaCodigoLeido(ByVal CodigoLeido As String, ByVal EsCodigoPar As Boolean, ByVal FolioSalidaID As Integer, ByVal NaveID As Integer) As Entidades.ValidacionCodigoLeido

        Dim ObjUsuarioDA As New Almacen.Datos.InspeccionCalidadDA
        Dim dtResultado As New DataTable
        Dim entValidaCodigoPar As New Entidades.ValidacionCodigoLeido

        Try
            dtResultado = ObjUsuarioDA.ValidaCodigoLeido(CodigoLeido, EsCodigoPar, FolioSalidaID, NaveID)

            If IsNothing(dtResultado) = False Then
                If dtResultado.Rows.Count > 0 Then
                    With entValidaCodigoPar
                        .EsAtado = CBool(dtResultado.Rows(0).Item("EsAtado"))
                        .EsCodigoCliente = CBool(dtResultado.Rows(0).Item("EsCodigoCliente"))
                        .EsCodigoPar = CBool(dtResultado.Rows(0).Item("EsCodigoPar"))
                        .ExisteOParEnFolio = CBool(dtResultado.Rows(0).Item("ExisteParEnFolio"))
                        .FolioSalidaID = dtResultado.Rows(0).Item("FolioSalidaID")
                    End With
                End If
            End If
        Catch ex As Exception
            With entValidaCodigoPar
                .EsAtado = 0
                .EsCodigoCliente = 0
                .EsCodigoPar = 0
                .ExisteOParEnFolio = 0
                .FolioSalidaID = 0
            End With
        End Try

        Return entValidaCodigoPar

    End Function

    Public Function ObtenerInformacionCapturaIncidencia(ByVal InspeccionParID As Integer) As Entidades.CapturaIncidenciaPar

        Dim ObjUsuarioDA As New Almacen.Datos.InspeccionCalidadDA
        Dim dtResultado As New DataTable
        Dim entCapturaIncidenciaPar As New Entidades.CapturaIncidenciaPar

        Try
            dtResultado = ObjUsuarioDA.ObtenerInformacionCapturaIncidencia(InspeccionParID)

            If IsNothing(dtResultado) = False Then
                If dtResultado.Rows.Count > 0 Then
                    With entCapturaIncidenciaPar
                        .Foto1 = dtResultado.Rows(0).Item("Foto1")
                        .Foto2 = dtResultado.Rows(0).Item("Foto2")
                        .IncicidenciaID = dtResultado.Rows(0).Item("IncidenciaID")
                        .InspeccionParID = dtResultado.Rows(0).Item("InspeccionParID")
                        .Observaciones = dtResultado.Rows(0).Item("Observaciones")
                        .TipoIncidencia = dtResultado.Rows(0).Item("TipoIncidencia")

                        With .InformacionPar
                            .Atado = dtResultado.Rows(0).Item("Atado")
                            .Año = dtResultado.Rows(0).Item("Año")
                            .ClienteSAYID = dtResultado.Rows(0).Item("ClienteSAYID")
                            .ClienteSICYID = dtResultado.Rows(0).Item("ClienteSICYID")
                            .CodigoPar = dtResultado.Rows(0).Item("CodigoPar")
                            .ColeccionSAY = dtResultado.Rows(0).Item("ColeccionSay")
                            .Color = dtResultado.Rows(0).Item("Color")
                            .Corrida = dtResultado.Rows(0).Item("Corrida")
                            .Estatus = dtResultado.Rows(0).Item("Estatus")
                            .Folio = dtResultado.Rows(0).Item("Folio")
                            .InspeccionParID = dtResultado.Rows(0).Item("InspeccionParId")
                            .Lote = dtResultado.Rows(0).Item("Lote")
                            .MarcaSAY = dtResultado.Rows(0).Item("MarcaSay")
                            .Nave = dtResultado.Rows(0).Item("Nave")
                            .NaveID = dtResultado.Rows(0).Item("NaveId")
                            .NombreCliente = dtResultado.Rows(0).Item("NombreCliente")
                            .NumeroAtado = dtResultado.Rows(0).Item("NumeroAtado")
                            .Pedido = dtResultado.Rows(0).Item("Pedido")
                            .Piel = dtResultado.Rows(0).Item("Piel")
                            .RutaImagenZapato = dtResultado.Rows(0).Item("RutaImagenZapato")
                            .Talla = dtResultado.Rows(0).Item("Talla")
                            .UsuarioId = dtResultado.Rows(0).Item("UsuarioId")
                            .ModeloSAY = dtResultado.Rows(0).Item("ModeloSAY")
                        End With
                    End With
                End If
            End If
        Catch ex As Exception
            With entCapturaIncidenciaPar
                .Foto1 = ""
                .Foto2 = ""
                .IncicidenciaID = "0"
                .InspeccionParID = "0"
                .Observaciones = ""
                .TipoIncidencia = "0"

                With .InformacionPar
                    .Atado = ""
                    .Año = "0"
                    .ClienteSAYID = "0"
                    .ClienteSICYID = "0"
                    .CodigoPar = ""
                    .ColeccionSAY = ""
                    .Color = ""
                    .Corrida = ""
                    .Estatus = "0"
                    .Folio = ""
                    .InspeccionParID = "0"
                    .Lote = "0"
                    .MarcaSAY = ""
                    .Nave = ""
                    .NaveID = "0"
                    .NombreCliente = ""
                    .NumeroAtado = ""
                    .Pedido = "0"
                    .Piel = ""
                    .RutaImagenZapato = ""
                    .Talla = ""
                    .UsuarioId = "0"
                    .ModeloSAY = ""

                End With
            End With
        End Try

        Return entCapturaIncidenciaPar

    End Function

    Public Function ObtenerIncidenciasDepartamento(ByVal DepartamentoID As Integer) As List(Of Entidades.TipoIncidencia)
        Dim ObjUsuarioDA As New Almacen.Datos.InspeccionCalidadDA
        Dim dtResultado As New DataTable
        Dim entListaIncidencias As New List(Of Entidades.TipoIncidencia)
        Dim entTipoIncidencia As New Entidades.TipoIncidencia

        Try
            dtResultado = ObjUsuarioDA.ObtenerIncidenciasDepartamento(DepartamentoID)

            If IsNothing(dtResultado) = False Then
                If dtResultado.Rows.Count > 0 Then

                    For Each Fila As DataRow In dtResultado.Rows
                        entTipoIncidencia = New Entidades.TipoIncidencia
                        With entTipoIncidencia
                            .Incidencia = Fila.Item("Incidencia")
                            .IncidenciaID = Fila.Item("IncidenciaID")
                        End With
                        entListaIncidencias.Add(entTipoIncidencia)
                    Next

                End If
            End If
        Catch ex As Exception

        End Try

        Return entListaIncidencias

    End Function

    Public Function CapturaIncidenciaPar(ByVal InspeccionParID As Integer, ByVal IncidenciaID As Integer, ByVal UsuarioID As Integer, ByVal Observaciones As String, ByVal TipoIncidencia As String, ByVal Foto1 As String, ByVal Foto2 As String, ByVal TipoDevolucion As Integer, ByVal Accion As Integer) As Boolean
        Dim ObjUsuarioDA As New Almacen.Datos.InspeccionCalidadDA
        Dim dtResultado As New DataTable
        Dim entListaIncidencias As New List(Of Entidades.TipoIncidencia)
        Dim entTipoIncidencia As New Entidades.TipoIncidencia
        Dim Resultado As Boolean = False


        Try
            dtResultado = ObjUsuarioDA.CapturaInciedenciaPar(InspeccionParID, IncidenciaID, UsuarioID, Observaciones, TipoIncidencia, Foto1, Foto2, TipoDevolucion, Accion)

            If IsNothing(dtResultado) = False Then
                If dtResultado.Rows.Count > 0 Then
                    Resultado = CBool(dtResultado.Rows(0).Item(0))
                End If
            End If

        Catch ex As Exception

        End Try

        Return Resultado

    End Function

    Public Function ResumenInspeccion(ByVal FolioInspeccion As Integer) As List(Of Entidades.ResumenInspeccion)
        Dim ObjUsuarioDA As New Almacen.Datos.InspeccionCalidadDA
        Dim dtResultado As New DataTable
        Dim entListaResumenInspeccion As New List(Of Entidades.ResumenInspeccion)
        Dim entResumenInspeccion As New Entidades.ResumenInspeccion
        Dim Resultado As Boolean = False

        Try
            dtResultado = ObjUsuarioDA.ResumenInspeccion(FolioInspeccion)
            If IsNothing(dtResultado) = False Then
                If dtResultado.Rows.Count > 0 Then
                    For Each Fila As DataRow In dtResultado.Rows
                        entResumenInspeccion = New Entidades.ResumenInspeccion
                        With entResumenInspeccion
                            .Cliente = Fila.Item("Cliente")
                            .Coleccion = Fila.Item("Coleccion")
                            .Foto1 = Fila.Item("Foto1")
                            .Foto2 = Fila.Item("Foto2")
                            .Incidencia = Fila.Item("Incidencia")
                            .IncidenciaParID = CInt(Fila.Item("IncidenciaParID"))
                            .lote = CInt(Fila.Item("lote"))
                            .Modelo = Fila.Item("Modelo")
                            .TipoIncidencia = Fila.Item("TipoIncidencia")
                            .Rechazo = Fila.Item("Rechazo")
                            .ParesDevueltos = Fila.Item("ParesDevueltosTotal").ToString
                            .Inspector = Fila.Item("Inspector").ToString
                            .Nave = Fila.Item("Nave").ToString()
                            .Accion = Fila.Item("Accion").ToString()
                            .EsLotePiloto = CBool(Fila.Item("EsLotePiloto"))
                            .LotePiloto = Fila.Item("LotePiloto")
                            .Corrida = Fila.Item("Corrida")

                        End With
                        entListaResumenInspeccion.Add(entResumenInspeccion)
                    Next
                End If
            End If

        Catch ex As Exception

        End Try

        Return entListaResumenInspeccion

    End Function


    Public Function ObtenerInformacionParMaquila(ByVal CodigoPar As String, ByVal FolioInspeccion As String, ByVal NaveId As Integer, ByVal UsuarioId As Integer) As Entidades.LecturaParInspeccionado
        Dim objDA As New Datos.InspeccionCalidadDA
        Dim tabla As New DataTable
        Dim dtLotesPilotoFolio As New DataTable
        Dim EntInformacionParLeido As New Entidades.LecturaParInspeccionado
        Try
            tabla = objDA.ObtenerInformacionParMaquila(CodigoPar, FolioInspeccion, NaveId, UsuarioId)
            If IsNothing(tabla) = False Then
                If tabla.Rows.Count > 0 Then
                    With EntInformacionParLeido
                        With .InformacionPar
                            .Estatus = CBool(tabla.Rows(0).Item("Estatus"))
                            .InspeccionParID = tabla.Rows(0).Item("InspeccionParID")
                            .Lote = tabla.Rows(0).Item("Lote")
                            .NaveID = tabla.Rows(0).Item("NaveID")
                            .Nave = tabla.Rows(0).Item("Nave")
                            .Año = tabla.Rows(0).Item("Año")
                            .MarcaSAY = tabla.Rows(0).Item("MarcaSAY")
                            .ColeccionSAY = tabla.Rows(0).Item("ColeccionSAY")
                            .Color = tabla.Rows(0).Item("Color")
                            .Piel = tabla.Rows(0).Item("Piel")
                            .Corrida = tabla.Rows(0).Item("Corrida")
                            .Talla = tabla.Rows(0).Item("Talla")
                            .Pedido = tabla.Rows(0).Item("Pedido")
                            .Atado = tabla.Rows(0).Item("Atado")
                            .NumeroAtado = tabla.Rows(0).Item("NumeroAtado")
                            .CodigoPar = tabla.Rows(0).Item("CodigoPar")
                            .Folio = tabla.Rows(0).Item("Folio")
                            .UsuarioId = tabla.Rows(0).Item("UsuarioID")
                            .ClienteSAYID = tabla.Rows(0).Item("ClienteSAYID")
                            .ClienteSICYID = tabla.Rows(0).Item("ClienteSICYID")
                            .RutaImagenZapato = tabla.Rows(0).Item("RutaImagenZapato")
                            .NombreCliente = tabla.Rows(0).Item("NombreCliente")
                            .ModeloSAY = tabla.Rows(0).Item("ModeloSAY")
                        End With

                        If IsDate(tabla.Rows(0).Item("FechaInicio")) = True Then
                            .FechaInicio = tabla.Rows(0).Item("FechaInicio")
                        Else
                            .FechaInicio = Nothing
                        End If

                        If IsDate(tabla.Rows(0).Item("FechaTemino")) = True Then
                            .FechaTermino = tabla.Rows(0).Item("FechaTemino")
                        Else
                            .FechaTermino = Nothing
                        End If

                        .Nave = tabla.Rows(0).Item("Nave")
                        .NaveId = CInt(tabla.Rows(0).Item("NaveID"))
                        .ParesAInspeccionar = tabla.Rows(0).Item("ParesAInspeccionar")
                        .ParesDevueltos = tabla.Rows(0).Item("ParesDevueltos")
                        .ParesFolio = tabla.Rows(0).Item("ParesFolio")
                        .ParesIncidencias = tabla.Rows(0).Item("NumeroIncidencias")
                        .ParesIncidenciasCriticas = tabla.Rows(0).Item("NumeroIncidenciasCriticas")
                        .ParesInspeccionados = tabla.Rows(0).Item("ParesInspeccionados")
                        .ParesInspeccionadosLotePiloto = tabla.Rows(0).Item("ParesInspeccionadosLotesPiloto")
                        .ParesLotePiloto = tabla.Rows(0).Item("ParesLotesPiloto")
                        .PorcentajeAInspeccionar = tabla.Rows(0).Item("PorcentajeAInspeccionar")
                        .PorcentajeInspeccionado = tabla.Rows(0).Item("PorcentajeInspeccionado")
                        .RutaLogoNave = tabla.Rows(0).Item("RutaLogo")
                        .UsuarioId = CInt(tabla.Rows(0).Item("UsuarioID"))
                        .FolioInspeccionID = tabla.Rows(0).Item("FolioInspeccionID")
                        .Folio = tabla.Rows(0).Item("Folio")

                        .LotesPiloto = New List(Of Entidades.LotesInspeccionados)

                        dtLotesPilotoFolio = objDA.ObtenerLotesPiloto(.FolioInspeccionID)
                        Dim LotePiloto As New Entidades.LotesInspeccionados

                        For Each Fila As DataRow In dtLotesPilotoFolio.Rows
                            LotePiloto = New Entidades.LotesInspeccionados
                            LotePiloto.Año = Fila.Item("Año")
                            LotePiloto.Estatus = Fila.Item("Status")
                            LotePiloto.Estilo = Fila.Item("Descripcion")
                            LotePiloto.Lote = Fila.Item("Lote")
                            LotePiloto.NaveID = Fila.Item("NaveID")
                            LotePiloto.Pares = Fila.Item("ParesLote")
                            LotePiloto.Descripcion = Fila.Item("Descripcion")
                            .LotesPiloto.Add(LotePiloto)
                        Next
                    End With

                End If
            End If

        Catch ex As Exception
            Throw ex
        End Try

        Return EntInformacionParLeido

    End Function

    Public Function ObtenerInformacionParCodigoCliente(ByVal CodigoAtado As String, ByVal CodigoCliente As String, ByVal FolioInspeccion As String, ByVal FolioSalidaID As Integer, ByVal UsuarioId As Integer) As Entidades.LecturaParInspeccionado
        Dim objDA As New Datos.InspeccionCalidadDA
        Dim tabla As New DataTable
        Dim dtLotesPilotoFolio As New DataTable
        Dim EntInformacionParLeido As New Entidades.LecturaParInspeccionado
        Try
            tabla = objDA.ObtenerInformacionParCodigoCliente(CodigoAtado, CodigoCliente, FolioInspeccion, FolioSalidaID, UsuarioId)
            If IsNothing(tabla) = False Then
                If tabla.Rows.Count > 0 Then
                    With EntInformacionParLeido
                        With .InformacionPar
                            .Estatus = CBool(tabla.Rows(0).Item("Estatus"))
                            .InspeccionParID = tabla.Rows(0).Item("InspeccionParID")
                            .Lote = tabla.Rows(0).Item("Lote")
                            .NaveID = tabla.Rows(0).Item("NaveID")
                            .Nave = tabla.Rows(0).Item("Nave")
                            .Año = tabla.Rows(0).Item("Año")
                            .MarcaSAY = tabla.Rows(0).Item("MarcaSAY")
                            .ColeccionSAY = tabla.Rows(0).Item("ColeccionSAY")
                            .Color = tabla.Rows(0).Item("Color")
                            .Piel = tabla.Rows(0).Item("Piel")
                            .Corrida = tabla.Rows(0).Item("Corrida")
                            .Talla = tabla.Rows(0).Item("Talla")
                            .Pedido = tabla.Rows(0).Item("Pedido")
                            .Atado = tabla.Rows(0).Item("Atado")
                            .NumeroAtado = tabla.Rows(0).Item("NumeroAtado")
                            .CodigoPar = tabla.Rows(0).Item("CodigoPar")
                            .Folio = tabla.Rows(0).Item("Folio")
                            .UsuarioId = tabla.Rows(0).Item("UsuarioID")
                            .ClienteSAYID = tabla.Rows(0).Item("ClienteSAYID")
                            .ClienteSICYID = tabla.Rows(0).Item("ClienteSICYID")
                            .RutaImagenZapato = tabla.Rows(0).Item("RutaImagenZapato")
                            .NombreCliente = tabla.Rows(0).Item("NombreCliente")
                            .ModeloSAY = tabla.Rows(0).Item("ModeloSAY")
                        End With

                        If IsDate(tabla.Rows(0).Item("FechaInicio")) = True Then
                            .FechaInicio = tabla.Rows(0).Item("FechaInicio")
                        Else
                            .FechaInicio = Nothing
                        End If

                        If IsDate(tabla.Rows(0).Item("FechaTemino")) = True Then
                            .FechaTermino = tabla.Rows(0).Item("FechaTemino")
                        Else
                            .FechaTermino = Nothing
                        End If

                        .Nave = tabla.Rows(0).Item("Nave")
                        .NaveId = CInt(tabla.Rows(0).Item("NaveID"))
                        .ParesAInspeccionar = tabla.Rows(0).Item("ParesAInspeccionar")
                        .ParesDevueltos = tabla.Rows(0).Item("ParesDevueltos")
                        .ParesFolio = tabla.Rows(0).Item("ParesFolio")
                        .ParesIncidencias = tabla.Rows(0).Item("NumeroIncidencias")
                        .ParesIncidenciasCriticas = tabla.Rows(0).Item("NumeroIncidenciasCriticas")
                        .ParesInspeccionados = tabla.Rows(0).Item("ParesInspeccionados")
                        .ParesInspeccionadosLotePiloto = tabla.Rows(0).Item("ParesInspeccionadosLotesPiloto")
                        .ParesLotePiloto = tabla.Rows(0).Item("ParesLotesPiloto")
                        .PorcentajeAInspeccionar = tabla.Rows(0).Item("PorcentajeAInspeccionar")
                        .PorcentajeInspeccionado = tabla.Rows(0).Item("PorcentajeInspeccionado")
                        .RutaLogoNave = tabla.Rows(0).Item("RutaLogo")
                        .UsuarioId = CInt(tabla.Rows(0).Item("UsuarioID"))
                        .FolioInspeccionID = tabla.Rows(0).Item("FolioInspeccionID")
                        .Folio = tabla.Rows(0).Item("Folio")

                        .LotesPiloto = New List(Of Entidades.LotesInspeccionados)

                        dtLotesPilotoFolio = objDA.ObtenerLotesPiloto(.FolioInspeccionID)
                        Dim LotePiloto As New Entidades.LotesInspeccionados

                        For Each Fila As DataRow In dtLotesPilotoFolio.Rows
                            LotePiloto = New Entidades.LotesInspeccionados
                            LotePiloto.Año = Fila.Item("Año")
                            LotePiloto.Estatus = Fila.Item("Status")
                            LotePiloto.Estilo = Fila.Item("Descripcion")
                            LotePiloto.Lote = Fila.Item("Lote")
                            LotePiloto.NaveID = Fila.Item("NaveID")
                            LotePiloto.Pares = Fila.Item("ParesLote")
                            LotePiloto.Descripcion = Fila.Item("Descripcion")
                            .LotesPiloto.Add(LotePiloto)
                        Next
                    End With

                End If
            End If

        Catch ex As Exception
            Throw ex
        End Try

        Return EntInformacionParLeido
    End Function

    Public Function ObtenerInformacionParCodigoCliente_Maquila(ByVal CodigoAtado As String, ByVal CodigoCliente As String, ByVal FolioInspeccion As String, ByVal NaveId As Integer, ByVal UsuarioId As Integer) As Entidades.LecturaParInspeccionado
        Dim objDA As New Datos.InspeccionCalidadDA
        Dim tabla As New DataTable
        Dim dtLotesPilotoFolio As New DataTable
        Dim EntInformacionParLeido As New Entidades.LecturaParInspeccionado
        Try
            tabla = objDA.ObtenerInformacionParCodigoCliente_Maquila(CodigoAtado, CodigoCliente, FolioInspeccion, NaveId, UsuarioId)
            If IsNothing(tabla) = False Then
                If tabla.Rows.Count > 0 Then
                    With EntInformacionParLeido
                        With .InformacionPar
                            .Estatus = CBool(tabla.Rows(0).Item("Estatus"))
                            .InspeccionParID = tabla.Rows(0).Item("InspeccionParID")
                            .Lote = tabla.Rows(0).Item("Lote")
                            .NaveID = tabla.Rows(0).Item("NaveID")
                            .Nave = tabla.Rows(0).Item("Nave")
                            .Año = tabla.Rows(0).Item("Año")
                            .MarcaSAY = tabla.Rows(0).Item("MarcaSAY")
                            .ColeccionSAY = tabla.Rows(0).Item("ColeccionSAY")
                            .Color = tabla.Rows(0).Item("Color")
                            .Piel = tabla.Rows(0).Item("Piel")
                            .Corrida = tabla.Rows(0).Item("Corrida")
                            .Talla = tabla.Rows(0).Item("Talla")
                            .Pedido = tabla.Rows(0).Item("Pedido")
                            .Atado = tabla.Rows(0).Item("Atado")
                            .NumeroAtado = tabla.Rows(0).Item("NumeroAtado")
                            .CodigoPar = tabla.Rows(0).Item("CodigoPar")
                            .Folio = tabla.Rows(0).Item("Folio")
                            .UsuarioId = tabla.Rows(0).Item("UsuarioID")
                            .ClienteSAYID = tabla.Rows(0).Item("ClienteSAYID")
                            .ClienteSICYID = tabla.Rows(0).Item("ClienteSICYID")
                            .RutaImagenZapato = tabla.Rows(0).Item("RutaImagenZapato")
                            .NombreCliente = tabla.Rows(0).Item("NombreCliente")
                            .ModeloSAY = tabla.Rows(0).Item("ModeloSAY")
                        End With

                        If IsDate(tabla.Rows(0).Item("FechaInicio")) = True Then
                            .FechaInicio = tabla.Rows(0).Item("FechaInicio")
                        Else
                            .FechaInicio = Nothing
                        End If

                        If IsDate(tabla.Rows(0).Item("FechaTemino")) = True Then
                            .FechaTermino = tabla.Rows(0).Item("FechaTemino")
                        Else
                            .FechaTermino = Nothing
                        End If

                        .Nave = tabla.Rows(0).Item("Nave")
                        .NaveId = CInt(tabla.Rows(0).Item("NaveID"))
                        .ParesAInspeccionar = tabla.Rows(0).Item("ParesAInspeccionar")
                        .ParesDevueltos = tabla.Rows(0).Item("ParesDevueltos")
                        .ParesFolio = tabla.Rows(0).Item("ParesFolio")
                        .ParesIncidencias = tabla.Rows(0).Item("NumeroIncidencias")
                        .ParesIncidenciasCriticas = tabla.Rows(0).Item("NumeroIncidenciasCriticas")
                        .ParesInspeccionados = tabla.Rows(0).Item("ParesInspeccionados")
                        .ParesInspeccionadosLotePiloto = tabla.Rows(0).Item("ParesInspeccionadosLotesPiloto")
                        .ParesLotePiloto = tabla.Rows(0).Item("ParesLotesPiloto")
                        .PorcentajeAInspeccionar = tabla.Rows(0).Item("PorcentajeAInspeccionar")
                        .PorcentajeInspeccionado = tabla.Rows(0).Item("PorcentajeInspeccionado")
                        .RutaLogoNave = tabla.Rows(0).Item("RutaLogo")
                        .UsuarioId = CInt(tabla.Rows(0).Item("UsuarioID"))
                        .FolioInspeccionID = tabla.Rows(0).Item("FolioInspeccionID")
                        .Folio = tabla.Rows(0).Item("Folio")

                        .LotesPiloto = New List(Of Entidades.LotesInspeccionados)

                        dtLotesPilotoFolio = objDA.ObtenerLotesPiloto(.FolioInspeccionID)
                        Dim LotePiloto As New Entidades.LotesInspeccionados

                        For Each Fila As DataRow In dtLotesPilotoFolio.Rows
                            LotePiloto = New Entidades.LotesInspeccionados
                            LotePiloto.Año = Fila.Item("Año")
                            LotePiloto.Estatus = Fila.Item("Status")
                            LotePiloto.Estilo = Fila.Item("Descripcion")
                            LotePiloto.Lote = Fila.Item("Lote")
                            LotePiloto.NaveID = Fila.Item("NaveID")
                            LotePiloto.Pares = Fila.Item("ParesLote")
                            LotePiloto.Descripcion = Fila.Item("Descripcion")
                            .LotesPiloto.Add(LotePiloto)
                        Next
                    End With

                End If
            End If

        Catch ex As Exception
            Throw ex
        End Try

        Return EntInformacionParLeido
    End Function
    'hola
    Public Function ReporteDeInspeccion(ByVal NaveId As String, ByVal FiltrarPorFecha As Boolean, ByVal FechaInicio As Date, ByVal FechaFin As Date, ByVal ResultadoInspeccion As String, ByVal FolioInspeccion As String, ByVal FolioSalida As String, ByVal Almacen2 As Boolean, ByVal Cedis As Integer) As DataTable
        Dim objDA As New Datos.InspeccionCalidadDA
        Dim dtResultado As New DataTable
        Dim dtLotesPilotoFolio As New DataTable
        Dim EntInformacionParLeido As New Entidades.LecturaParInspeccionado


        Try
            dtResultado = objDA.ReporteDeInspeccion(NaveId, FiltrarPorFecha, FechaInicio, FechaFin, ResultadoInspeccion, FolioInspeccion, FolioSalida, Almacen2, Cedis)
            Return dtResultado
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function ListadoParametroProyeccionEntregas(tipo_busqueda As Integer) As DataTable
        Dim objDA As New Datos.InspeccionCalidadDA
        Dim tabla As New DataTable
        tabla = objDA.ListadoParametroProyeccionEntregas(tipo_busqueda)
        Return tabla
    End Function


    Public Function ReporteDetallesFolioInspeccion(ByVal FolioInspeccion As String) As DataTable
        Dim objDA As New Datos.InspeccionCalidadDA
        Dim tabla As New DataTable
        tabla = objDA.ReporteDetallesFolioInspeccion(FolioInspeccion)
        Return tabla
    End Function

    Public Function ConsultaListadoClientesPorcentajeInspeccion() As DataTable
        Dim objDA As New Datos.InspeccionCalidadDA
        Dim tabla As New DataTable
        tabla = objDA.ConsultaListadoClientesPorcentajeInspeccion()
        Return tabla
    End Function

    Public Function FinalizarInspeccion(ByVal FolioInspeccionID As Integer, ByVal ColaboradorID As Integer) As Boolean
        Dim objDA As New Datos.InspeccionCalidadDA
        Dim tabla As New DataTable
        Dim Resultado As Boolean = False
        Try
            tabla = objDA.FinalizarInspeccion(FolioInspeccionID, ColaboradorID)

            If IsNothing(tabla) = False Then
                If tabla.Rows.Count > 0 Then
                    Resultado = CBool(tabla.Rows(0).Item(0))
                End If
            End If
            Return Resultado
        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function ConsultarDevolucionesNave(ByVal FolioDevolucionId As String, ByVal FolioSalidaId As String, ByVal FolioInspeccionId As String, ByVal NaveId As String, ByVal StatusId As String, ByVal FiltrarPorFecha As Boolean, ByVal FechaInicio As String, ByVal FechaFin As String, ByVal CEDISID As String) As DataTable
        Dim objDA As New Datos.InspeccionCalidadDA
        Dim tabla As New DataTable
        Try
            tabla = objDA.ConsultarDevolucionesNave(FolioDevolucionId, FolioSalidaId, FolioInspeccionId, NaveId, StatusId, FiltrarPorFecha, FechaInicio, FechaFin, CEDISID)
            Return tabla
        Catch ex As Exception
            Throw ex
            Return Nothing
        End Try

    End Function

    Public Function ConsultarDetallesDevolucion(ByVal FolioDevolucionID As Integer) As DataTable
        Dim objDA As New Datos.InspeccionCalidadDA
        Dim tabla As New DataTable
        Try
            tabla = objDA.ConsultarDetallesDevolucion(FolioDevolucionID)
            Return tabla
        Catch ex As Exception
            Throw ex
            Return Nothing
        End Try
    End Function

    Public Function ConsultaParesPendientesIngresar(ByVal FolioDevolucionID As Integer) As DataTable
        Dim objDA As New Datos.InspeccionCalidadDA
        Dim tabla As New DataTable
        Try
            tabla = objDA.ConsultaParesPendientesIngresar(FolioDevolucionID)
            Return tabla
        Catch ex As Exception
            Throw ex
            Return Nothing
        End Try
    End Function

    Public Function ConsultaParesIngresados(ByVal FolioDevolucionID As Integer) As DataTable
        Dim objDA As New Datos.InspeccionCalidadDA
        Dim tabla As New DataTable
        Try
            tabla = objDA.ConsultaParesIngresados(FolioDevolucionID)
            Return tabla
        Catch ex As Exception
            Throw ex
            Return Nothing
        End Try
    End Function

    Public Function ObtenerInformacionFolioDevolucion(ByVal FolioDevolucionID As Integer) As Entidades.infoFolioDevolucion
        Dim objDA As New Datos.InspeccionCalidadDA
        Dim tabla As New DataTable
        Dim EntidadFolio As New Entidades.infoFolioDevolucion
        Try
            tabla = objDA.ObtenerInformacionFolioDevolucion(FolioDevolucionID)
            If IsNothing(tabla) = False Then
                If tabla.Rows.Count > 0 Then
                    With EntidadFolio
                        .CantidadDevuelta = tabla.Rows(0).Item("CantidadDevuelta").ToString()
                        .CantidadPendiente = tabla.Rows(0).Item("CantidadPendiente").ToString()
                        .CantidadRegreso = tabla.Rows(0).Item("CantidadRegreso").ToString()
                        .Colaborador = tabla.Rows(0).Item("Colaborador").ToString()
                        .ColaboradorRecibio = tabla.Rows(0).Item("ColaboradorRecibio").ToString()
                        .DevolucionNaveID = tabla.Rows(0).Item("DevolucionNaveID").ToString()
                        .NaveID = tabla.Rows(0).Item("NaveID")

                        If tabla.Rows(0).Item("FechaCancelacion").ToString() = "" Then
                            .FechaCancelacion = Nothing
                        Else
                            .FechaCancelacion = tabla.Rows(0).Item("FechaCancelacion").ToString()
                        End If

                        If tabla.Rows(0).Item("FechaCaptura").ToString() = "" Then
                            .FechaCaptura = Nothing
                        Else
                            .FechaCaptura = tabla.Rows(0).Item("FechaCaptura").ToString()
                        End If

                        If tabla.Rows(0).Item("FechaEstimadaRegreso").ToString() = "" Then
                            .FechaEstimadaRegreso = Nothing
                        Else
                            .FechaEstimadaRegreso = tabla.Rows(0).Item("FechaEstimadaRegreso").ToString()
                        End If

                        If tabla.Rows(0).Item("FechaRegreso").ToString() = "" Then
                            .FechaRegreso = Date.Now
                        Else
                            .FechaRegreso = tabla.Rows(0).Item("FechaRegreso").ToString()
                        End If


                        .FolioInspeccionID = tabla.Rows(0).Item("FolioInspeccionID").ToString()
                        .FolioSalidaID = tabla.Rows(0).Item("FolioSalidaID").ToString()
                        .MotivoCancelacion = tabla.Rows(0).Item("MotivoCancelacion").ToString()
                        .Nave = tabla.Rows(0).Item("Nave").ToString()
                        .Status = tabla.Rows(0).Item("Status").ToString()
                        .Tratamiento = tabla.Rows(0).Item("Tratamiento").ToString()
                    End With
                End If
            End If
            Return EntidadFolio
        Catch ex As Exception
            Throw ex
            Return Nothing
        End Try
    End Function

    Public Function ConsultaOperadoresNave(ByVal NaveSICYID As Integer) As DataTable
        Dim objDA As New Datos.InspeccionCalidadDA
        Dim tabla As New DataTable
        Try
            tabla = objDA.ConsultaOperadoresNave(NaveSICYID)
            Return tabla
        Catch ex As Exception
            Throw ex
            Return Nothing
        End Try
    End Function

    Public Function ConsultaEncabezadoDevolucionReporte(ByVal FolioDevolucion As Integer) As DataTable
        Dim objDA As New Datos.InspeccionCalidadDA
        Dim tabla As New DataTable
        Try
            tabla = objDA.ConsultaEncabezadoDevolucionReporte(FolioDevolucion)
            Return tabla
        Catch ex As Exception
            Throw ex
            Return Nothing
        End Try
    End Function

    Public Function ConsultaDetallesDevolucionReporte(ByVal FolioDevolucion As Integer) As DataTable
        Dim objDA As New Datos.InspeccionCalidadDA
        Dim tabla As New DataTable
        Try
            tabla = objDA.ConsultaDetallesDevolucionReporte(FolioDevolucion)
            Return tabla
        Catch ex As Exception
            Throw ex
            Return Nothing
        End Try
    End Function

    Public Function ConsultaParesDevolucion(ByVal FolioDevolucionID As Integer) As DataTable
        Dim objDA As New Datos.InspeccionCalidadDA
        Dim tabla As New DataTable
        Try
            tabla = objDA.ConsultaParesDevolucion(FolioDevolucionID)
            Return tabla
        Catch ex As Exception
            Throw ex
            Return Nothing
        End Try
    End Function


    Public Function IngresarParesDevolucion(ByVal FolioDevolucionID As Integer, ByVal EsCodigoPar As Boolean, ByVal CodigoLeido As String, ByVal ColaboradorId As Integer) As DataTable
        Dim objDA As New Datos.InspeccionCalidadDA
        Dim tabla As New DataTable
        Try
            tabla = objDA.IngresarParesDevolucion(FolioDevolucionID, EsCodigoPar, CodigoLeido, ColaboradorId)
            Return tabla
        Catch ex As Exception
            Throw ex
            Return Nothing
        End Try
    End Function

    Public Function FinalizarIngreso(ByVal FolioDevolucionID As Integer, ByVal ColaboradorId As Integer, ByVal Entrego As String) As DataTable
        Dim objDA As New Datos.InspeccionCalidadDA
        Dim tabla As New DataTable
        Try
            tabla = objDA.FinalizarIngreso(FolioDevolucionID, ColaboradorId, Entrego)
            Return tabla
        Catch ex As Exception
            Throw ex
            Return Nothing
        End Try
    End Function

    Public Function DevlucionValidaAtado_Alta(ByVal Atado As String, ByVal NaveId As Integer, ByVal EsCodigoPar As Boolean) As Boolean
        Dim objDA As New Datos.InspeccionCalidadDA
        Dim tabla As New DataTable
        Dim Resultado As Boolean = False
        Try
            tabla = objDA.DevlucionValidaAtado_Alta(Atado, NaveId, EsCodigoPar)
            If IsNothing(tabla) = False Then
                If tabla.Rows.Count > 0 Then
                    Resultado = CBool(tabla.Rows(0).Item(0))
                Else
                    Resultado = False
                End If
            Else
                Resultado = False
            End If

            Return Resultado
        Catch ex As Exception
            Throw ex
            Return False
        End Try
    End Function

    Public Function DevlucionObtenerInformacionAtado_Alta(ByVal Atado As String, ByVal EsCodigoPar As Boolean) As DataTable
        Dim objDA As New Datos.InspeccionCalidadDA
        Dim tabla As New DataTable
        Try
            tabla = objDA.DevlucionObtenerInformacionAtado_Alta(Atado, EsCodigoPar)
            Return tabla
        Catch ex As Exception
            Throw ex
            Return Nothing
        End Try
    End Function

    Public Function GuardarEncabezadoFolioAlta(ByVal NaveID As Integer, ByVal UsuarioId As Integer, ByVal FechaEstimadaRegreso As Date, ByVal CantidadPares As Integer, ByVal Tratamiento As String) As Integer
        Dim objDA As New Datos.InspeccionCalidadDA
        Dim tabla As New DataTable
        Dim FolioDevolucionID As Integer = 0
        Try
            tabla = objDA.GuardarEncabezadoFolioAlta(NaveID, UsuarioId, FechaEstimadaRegreso, CantidadPares, Tratamiento)
            If IsNothing(tabla) = False Then
                If tabla.Rows.Count > 0 Then
                    FolioDevolucionID = tabla.Rows(0).Item(0)
                Else
                    FolioDevolucionID = 0
                End If
            Else
                FolioDevolucionID = 0
            End If

            Return FolioDevolucionID
        Catch ex As Exception
            Throw ex
            Return Nothing
        End Try
    End Function

    Public Function ConsultaNavesDevolucion_Alta() As DataTable
        Dim objDA As New Datos.InspeccionCalidadDA
        Dim tabla As New DataTable
        Try
            tabla = objDA.ConsultaNavesDevolucion_Alta()
            Return tabla
        Catch ex As Exception
            Throw ex
            Return Nothing
        End Try
    End Function

    Public Function GuardarParesFolioAlta(ByVal FolioDevolucion As Integer, ByVal CodigoAtado As String, ByVal ColaboradorId As Integer, ByVal EsAtado As Boolean) As DataTable
        Dim objDA As New Datos.InspeccionCalidadDA
        Dim tabla As New DataTable
        Try
            tabla = objDA.GuardarParesFolioAlta(FolioDevolucion, CodigoAtado, ColaboradorId, EsAtado)
            Return tabla
        Catch ex As Exception
            Throw ex
            Return Nothing
        End Try
    End Function

    Public Function ValidaFolioDevolucion(ByVal FolioDevolucion As Integer) As Boolean
        Dim objDA As New Datos.InspeccionCalidadDA
        Dim tabla As New DataTable
        Dim Resultado As Boolean
        Try
            tabla = objDA.ValidaFolioDevolucion(FolioDevolucion)
            If IsNothing(tabla) = False Then
                If tabla.Rows.Count > 0 Then
                    Resultado = CBool(tabla.Rows(0).Item(0))
                Else
                    Resultado = False
                End If
            Else
                Resultado = False
            End If

            Return Resultado
        Catch ex As Exception
            Throw ex
            Return Nothing
        End Try
    End Function

    Public Function EditarFolioDevolucion(ByVal FolioDevolucion As Integer, ByVal FechaEstimadaRegreso As Date, ByVal Tratamiento As String) As DataTable
        Dim objDA As New Datos.InspeccionCalidadDA
        Dim tabla As New DataTable

        Try
            tabla = objDA.EditarFolioDevolucion(FolioDevolucion, FechaEstimadaRegreso, Tratamiento)

            Return tabla
        Catch ex As Exception
            Throw ex
            Return Nothing
        End Try
    End Function


End Class
