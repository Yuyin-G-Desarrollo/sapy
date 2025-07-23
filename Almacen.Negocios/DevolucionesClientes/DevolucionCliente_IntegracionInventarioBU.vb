Public Class DevolucionCliente_IntegracionInventarioBU

    Dim ObjDA As New Datos.DevolucionCliente_IntegracionInventarioDA


    Public Function ConsultaDetallesDevolucion(ByVal FolioDev As Integer, ByVal FoliosDev As String) As DataTable
        Dim dtResultado As New DataTable
        dtResultado = ObjDA.ConsultaDetallesDevolucion(FolioDev, FolioDev)
        Return dtResultado
    End Function

    Public Function ConsultaDocenaNormal(ByVal TallaID As Integer) As DataTable
        Dim dtResultado As New DataTable
        dtResultado = ObjDA.ConsultaDocenaNormal(TallaID)
        Return dtResultado
    End Function
    Public Function ConsultaTallasFolio(ByVal FolioDevolucionID As Integer) As DataTable
        Dim dtResultado As New DataTable
        dtResultado = ObjDA.ConsultaTallasFolio(FolioDevolucionID)
        Return dtResultado
    End Function

    Public Function ConsultaParesTallasFolio(ByVal FolioDevolucionID As Integer) As DataTable
        Dim dtResultado As New DataTable
        dtResultado = ObjDA.ConsultaParesTallasFolio(FolioDevolucionID)
        Return dtResultado
    End Function
    Public Function ObtnerDocenasNormalesArticulo(ByVal Tallaid As Integer, ByVal Fila As DataRow)

    End Function

    Public Function ConsultaInformacionDetalle(ByVal FolioDetalleID As Integer) As Entidades.FolioDevolucion_Detalle
        Dim dtResultado As New DataTable
        Dim FolioDetalle As New Entidades.FolioDevolucion_Detalle

        Try
            dtResultado = ObjDA.ConsultaInformacionDetalle(FolioDetalleID)
            If dtResultado.Rows.Count > 0 Then

                With FolioDetalle
                    .Articulo = dtResultado.Rows(0).Item("Articulo")
                    .CantidadPares = dtResultado.Rows(0).Item("CantidadPares")
                    .Cliente = dtResultado.Rows(0).Item("Cliente")
                    .FolioDevolucion = dtResultado.Rows(0).Item("FolioDevolucionID")
                    .FolioDevolucionDetalle = dtResultado.Rows(0).Item("FolioDevolucionDetalleID")
                End With

            End If

        Catch ex As Exception
            Throw ex
        End Try

        Return FolioDetalle

    End Function

    Public Function ConsultaTallasCorridas(ByVal TallaId As Integer) As DataTable
        Dim dtResultado As New DataTable
        dtResultado = ObjDA.ConsultaTallasCorridas(TallaId)
        Return dtResultado
    End Function

    Public Function BuscarLoteDocena(ByVal idCodigoSicy As String, ByVal tallaSicy As String) As Entidades.LoteGranel
        Dim dtResultado As New DataTable
        Dim Lote As New Entidades.LoteGranel

        dtResultado = ObjDA.BuscarLoteDocena(idCodigoSicy, tallaSicy)

        If IsNothing(dtResultado) = False Then
            If dtResultado.Rows.Count > 0 Then

                Lote.Lote = dtResultado.Rows(0).Item("Lote")
                Lote.NoDocena = dtResultado.Rows(0).Item("No_Docena")
                Lote.Año = dtResultado.Rows(0).Item("Año")
            End If

        End If

        Return Lote

    End Function

    Public Function InsertarLoteGranel(ByVal Lote As Integer, ByVal PielColor As String, ByVal CodigoSicy As String, ByVal tallaSicy As String) As DataTable
        Dim dtResultado As New DataTable
        dtResultado = ObjDA.InsertarLoteGranel(Lote, PielColor, CodigoSicy, tallaSicy)
        Return dtResultado
    End Function

    Public Function ReingresosGranelInsertaDocenasNormales(ByVal FolioDevolucionId As Integer,
                                                            ByVal FolioDevolucionSICYId As Integer,
                                                            ByVal NumDocenas As Integer,
                                                            ByVal Nave As Integer,
                                                            ByVal Lote As Integer,
                                                            ByVal idTallaSicy As String,
                                                            ByVal idCodigoSICY As String,
                                                            ByVal idDocena As Integer,
                                                            ByVal ProductoEstiloOriginalID As Integer,
                                                            ByVal ProductoEstiloId As Integer
                                                      )

        Dim dtResultado As New DataTable
        dtResultado = ObjDA.ReingresosGranelInsertaDocenasNormales(FolioDevolucionId, FolioDevolucionSICYId, NumDocenas, Nave, Lote, idTallaSicy, idCodigoSICY, idDocena, ProductoEstiloOriginalID, ProductoEstiloId)

        Return dtResultado
    End Function

    Public Function BuscarFinTallas(ByVal idTallaSicy As String) As Integer
        Dim dt As DataTable
        Dim Resultado As Integer = 0

        dt = ObjDA.BuscarFinTallas(idTallaSicy)

        If dt.Rows.Count > 0 Then
            Resultado = dt.Rows(0).Item("Tallas")
        Else
            Resultado = 0
        End If
        Return Resultado
    End Function


    Public Function BuscarTalla(ByVal num As String, ByVal idTallaSicy As String) As String
        Dim dt As New DataTable
        Dim Resultado As String = String.Empty

        Try
            dt = ObjDA.BuscarTalla(num, idTallaSicy)

            If dt.Rows.Count > 0 Then
                Resultado = dt.Rows(0).Item("Tall")
            Else
                Resultado = ""
            End If

        Catch ex As Exception
            Throw ex
        End Try

        Return Resultado

    End Function

    Public Function EjecutaConsulta(ByVal Tabla As Boolean, ByVal sql As String) As DataTable
        Dim dt As New DataTable
        Try
            Return ObjDA.EjecutaConsulta(Tabla, sql)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub ActualizaFolioLotesGenerados(ByVal FolioDevolucionID As Integer, ByVal UsuarioID As Integer)
        Dim dt As New DataTable
        Try
            ObjDA.ActualizaFolioLotesGenerados(FolioDevolucionID, UsuarioID)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function ConsultaParesFolioDevolucion(ByVal FolioDevolucionID As Integer) As DataTable
        Dim dt As New DataTable
        Try
            Return ObjDA.ConsultaParesFolioDevolucion(FolioDevolucionID)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ConsultaAtadosFolioDevolucion(ByVal FolioDevolucionID As Integer) As DataTable
        Dim dt As New DataTable
        Try
            Return ObjDA.ConsultaAtadosFolioDevolucion(FolioDevolucionID)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GuardarLoteGranelFolioDetalle(ByVal FolioDetalleID As Integer, LoteGranel As Integer, ByVal Año As Integer) As DataTable
        Dim dt As New DataTable
        Try
            Return ObjDA.GuardarLoteGranelFolioDetalle(FolioDetalleID, LoteGranel, Año)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ConsultarModelos(ByVal Modelo As String, ByVal TallaId As Integer) As DataTable
        Dim dt As New DataTable
        Try
            Return ObjDA.ConsultarModelos(Modelo, TallaId)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ConsultarArticulosPorColeccion(ByVal Modelo As String, ByVal Coleccion As String, ByVal TallaId As Integer) As DataTable
        Dim dt As New DataTable
        Try
            Return ObjDA.ConsultarArticulosPorColeccion(Modelo, Coleccion, TallaId)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function SustituirArticulo(ByVal FolioDetalleDevolucionId As String, ByVal ProductoEstiloOriginal As Integer) As Entidades.ProductoEstilo
        Dim dt As New DataTable
        Dim Ent_ProductoEstiloId As New Entidades.ProductoEstilo
        Try
            dt = ObjDA.SustituirArticulo(FolioDetalleDevolucionId, ProductoEstiloOriginal)
            If IsNothing(dt) = False Then
                If dt.Rows.Count > 0 Then
                    With Ent_ProductoEstiloId
                        .ProductoEstiloId = ProductoEstiloOriginal
                        .ColeccionSAY = dt.Rows(0).Item("ColeccionSAY")
                        .Color = dt.Rows(0).Item("Color")
                        .DescripcionCompleta = dt.Rows(0).Item("DescripcionCompleta")
                        .Familia = dt.Rows(0).Item("Familia")
                        .MarcaSAY = dt.Rows(0).Item("MarcaSAY")
                        .ModeloSAY = dt.Rows(0).Item("ModeloSAY")
                        .Piel = dt.Rows(0).Item("Piel")
                        .PielColor = dt.Rows(0).Item("PielColor")
                        .Talla = dt.Rows(0).Item("Talla")
                        .TallaID = dt.Rows(0).Item("TallaId")
                        .Temporada = dt.Rows(0).Item("Temporada")
                        .ModeloSICY = dt.Rows(0).Item("ModeloSICY")
                        .CodigoSICY = dt.Rows(0).Item("CodigoSICY")
                    End With

                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
        Return Ent_ProductoEstiloId
    End Function



End Class
