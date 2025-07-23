Imports Entidades
Imports Produccion.Negocios
Imports Stimulsoft.Report
Imports System.Globalization
Imports Tools

Public Class DetalleLotesForm

    Dim DepartamentoAnterior, Orden As Int32
    Dim listaDeps As New List(Of DepartamentosProduccion)
    Dim Departamentos As New List(Of DepartamentosProduccion)
    Dim inventario As New List(Of InventarioProduccion)
    Dim LotesTerminado, ParesTerminado As New Int32
    Dim ListaCelulas As New List(Of CelulasProduccion)
    Dim LotesAtrasadosDepartamento, ParesAtrasadosDepartameto As Int32
    Dim LotesDepartamentoProceso, ParesDepartamentoProceso, ParesTerminadosDepartamento, LotesTerminadosDepartamento As New Int32
    Dim TotalPares, TotalLotes, ParesTerminados, LotesTerminados, ParesProceso, LotesProceso, ParesAtrasados, LotesAtrasados, paresAtrasadosFiltro, LotesAtrasadosFiltro As Int32
    Public validarBotonImprimir As Integer
    Private Departamentoid, Naveid As Int32
    Public tipoReporte As Integer


    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click

        Me.Cursor = Cursors.WaitCursor
        Dim objBU As New LotesAvancesBU
        Dim tabla As New DataTable
        Dim vReporte As String = PNombreDepartamento
        Try
            If tipoReporte = 1 Then
                tabla = objBU.RegistrosCelulaNave(PNombreDepartamento, PNaveid)
            End If
            If tabla.Rows.Count > 1 And PNombreDepartamento <> "MONTADO Y ADORNO" Then
                Cursor = Cursors.WaitCursor
                Cms_Celulas.Show(MousePosition)
                Cursor = Cursors.Default
            ElseIf tipoReporte = 1 Then

                Select Case vReporte
                    Case "CORTE"
                        ImprimirCorteYPespunte()
                    Case "PESPUNTE"
                        ImprimirCorteYPespunte()
                    Case "MONTADO Y ADORNO"
                        ImprimirMontadoYAdorno()
                    Case ""
                        Dim mensajeAdvertencia As New AdvertenciaForm
                        mensajeAdvertencia.mensaje = "Selecciona un reporte"
                        mensajeAdvertencia.ShowDialog()
                End Select
            ElseIf tipoReporte = 2 Then
                ImprimirReporteInventarioNave()
            End If
        Catch ex As Exception
            Cursor = Cursors.Default
        End Try
        Me.Cursor = Cursors.Default


    End Sub

    Private FechaInicial As Date
    Private Atrasados, Terminados, Proceso As Boolean

    Private ShowColDiasRetraso As Boolean = False
    Dim ColorCorte, ColorMontado, ColorPespunte, ColorNave As String

    Private Sub btnImprimir_MouseDown(sender As Object, e As MouseEventArgs) Handles btnImprimir.MouseDown
        'Dim objBU As New LotesAvancesBU
        'Dim tabla As New DataTable
        'Try
        '    tabla = objBU.RegistrosCelulaNave(PNombreDepartamento, PNaveid)
        '    If tabla.Rows.Count > 1 Then
        '        If e.Button = Windows.Forms.MouseButtons.Right Then
        '            Cursor = Cursors.WaitCursor
        '            Cms_Celulas.Show(MousePosition)
        '            Cursor = Cursors.Default
        '        End If
        '    End If
        'Catch ex As Exception
        '    Cursor = Cursors.Default
        'End Try
    End Sub

    Private Sub InvDepartamentoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InvDepartamentoToolStripMenuItem.Click
        Dim vReporte As String = PNombreDepartamento
        If vReporte <> "" Then
            Select Case vReporte
                Case "CORTE"
                    ImprimirCorteYPespunte()
                Case "PESPUNTE"
                    ImprimirCorteYPespunte()
                Case "MONTADO Y ADORNO"
                    ImprimirMontadoYAdorno()
                Case ""
                    Dim mensajeAdvertencia As New AdvertenciaForm
                    mensajeAdvertencia.mensaje = "Selecciona un reporte"
                    mensajeAdvertencia.ShowDialog()
            End Select
        End If
    End Sub

    Private Sub CELULA1ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CELULA1ToolStripMenuItem.Click
        ImprimirReportePorCelulas("CELULA 1")
    End Sub

    Private Sub CELULA2ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CELULA2ToolStripMenuItem.Click
        ImprimirReportePorCelulas("CELULA 2")
    End Sub

    Private Sub btnImprimir_MouseClick(sender As Object, e As MouseEventArgs)
        Dim objBU As New LotesAvancesBU
        Dim tabla As New DataTable
        Try
            If e.Button = Windows.Forms.MouseButtons.Right Then
                Cursor = Cursors.WaitCursor
                Cms_Celulas.Show(MousePosition)
                Cursor = Cursors.Default
            End If
        Catch ex As Exception
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub ImprimirCorteYPespunte()
        Dim objBU As New LotesAvancesBU
        Dim comboText As New ConsultaInventarioForm
        Dim dsTablaResumenNaves As New DataSet("dsListaProduccionAvances")

        Dim tabla1 As New DataTable
        Dim tabla2 As New DataTable

        Me.Cursor = Cursors.WaitCursor

        tabla1 = objBU.RegistrosReporte(PFechaInicial, Now.ToShortDateString, PNaveid, PDepartamentoid)
        tabla2 = objBU.RegistrosResumen(PFechaInicial, Now.ToShortDateString, PNaveid, PDepartamentoid)

        tabla1.TableName = "dtProduccionAvances"
        tabla2.TableName = "dtResumenPorNave"

        'PDepartamentoid
        dsTablaResumenNaves.Tables.Add(tabla1)
        dsTablaResumenNaves.Tables.Add(tabla2)

        If tabla1.Rows.Count = 0 Then
            Tools.MostrarMensaje(Tools.Mensajes.Warning, "No hay información para generar el reporte.")
        Else
            Try
                Dim OBJReporte As New Framework.Negocios.ReportesBU
                Dim EntidadReporte As Entidades.Reportes
                EntidadReporte = OBJReporte.LeerReporteporClave("RESUMEN_INVENTARIO_POR_DEPARTAMENTO")
                Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
                        EntidadReporte.Pnombre + ".mrt"
                My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)
                Dim reporte As New StiReport

                reporte.Load(archivo)
                reporte.Compile()
                reporte("urlImagenNave") = GetRutaLogoPorNave(tabla1)
                reporte("fecha") = Now.ToShortDateString
                reporte("Departamento") = PNombreDepartamento
                reporte("Titulo") = "INVENTARIO " + PNombreDepartamento
                reporte("TotalLotes") = ObtenerTotales(tabla2, "TotalLotes")
                reporte("TotalPares") = ObtenerTotales(tabla2, "TotalPares")
                reporte("C1Lote") = ObtenerTotales(tabla2, "CELULA 1 Lotes")
                reporte("C1Pares") = ObtenerTotales(tabla2, "CELULA 1 Pares")
                reporte("C2Lotes") = ObtenerTotales(tabla2, "CELULA 2 Lotes")
                reporte("C2Pares") = ObtenerTotales(tabla2, "CELULA 2 Pares")
                reporte("C3Lotes") = ObtenerTotales(tabla2, "CELULA 3 Lotes")
                reporte("C3Pares") = ObtenerTotales(tabla2, "CELULA 3 Pares")
                reporte("NoAsignadoLote") = ObtenerTotales(tabla2, "NO ASIGNADO Lotes")
                reporte("NoAsignadoPares") = ObtenerTotales(tabla2, "NO ASIGNADO Pares")
                reporte.RegData(dsTablaResumenNaves)
                reporte.Show()
            Catch ex As Exception
            End Try
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub ImprimirMontadoYAdorno()
        Dim objBU As New LotesAvancesBU
        Dim comboText As New ConsultaInventarioForm
        Dim dsTablaResumenNaves As New DataSet("dsListaProduccionAvances")
        Dim Status As Boolean = True
        Dim tipoReporte As Integer

        Dim tabla1 As New DataTable
        Dim tabla2 As New DataTable
        Dim tabla3 As New DataTable
        Dim tabla4 As New DataTable

        Me.Cursor = Cursors.WaitCursor

        'tabla1 = objBU.RegistrosReporte(PFechaInicial, Now.ToShortDateString, PNaveid, PDepartamentoid)
        'tabla2 = objBU.RegistrosResumen(PFechaInicial, Now.ToShortDateString, PNaveid, PDepartamentoid)

        tabla1 = objBU.RegistrosProduccionDeAvancesMA(PNaveid, PFechaInicial, Now.ToShortDateString)
        tabla2 = objBU.RegistrosResumenProduccionDeAvancesMA(PNaveid, PFechaInicial, Now.ToShortDateString)
        tabla3 = objBU.RegistrosProduccionDeAvancesPT(PNaveid, PFechaInicial, Now.ToShortDateString)
        If tabla1.Rows.Count > 0 And tabla3.Rows.Count = 0 Then
            tipoReporte = 0
            tabla4 = objBU.RegistrosResumenProduccionDeAvancesPT(PNaveid, PFechaInicial, Now.ToShortDateString, tipoReporte)
        ElseIf tabla3.Rows.Count > 0 And tabla1.Rows.Count = 0 Then
            tipoReporte = 1
            tabla4 = objBU.RegistrosResumenProduccionDeAvancesPT(PNaveid, PFechaInicial, Now.ToShortDateString, tipoReporte)
        End If

        'tabla1.TableName = "dtProduccionAvances"
        'tabla2.TableName = "dtResumenPorNave"

        If tabla1.Rows.Count > 0 And tabla3.Rows.Count = 0 Then
            Status = True
            tabla1.TableName = "dtInventarioProduccion"
            tabla4.TableName = "dtResumenDeProduccion"
            dsTablaResumenNaves.Tables.Add(tabla1)
            dsTablaResumenNaves.Tables.Add(tabla4)
        End If
        If tabla3.Rows.Count > 0 And tabla1.Rows.Count = 0 Then
            Status = True
            tabla3.TableName = "dtInventarioProduccion"
            tabla4.TableName = "dtResumenDeProduccion"
            dsTablaResumenNaves.Tables.Add(tabla3)
            dsTablaResumenNaves.Tables.Add(tabla4)
        End If

        If tabla1.Rows.Count > 0 And tabla3.Rows.Count > 0 Then
            Status = False
            tabla1.TableName = "dtProduccionAvancesMA"
            tabla2.TableName = "dtResumen"
            tabla3.TableName = "dtProdAvanceProductoTerminado"
            dsTablaResumenNaves.Tables.Add(tabla1)
            dsTablaResumenNaves.Tables.Add(tabla2)
            dsTablaResumenNaves.Tables.Add(tabla3)
        End If

        'dsTablaResumenNaves.Tables.Add(tabla1)
        'dsTablaResumenNaves.Tables.Add(tabla2)

        'If tabla1.Rows.Count = 0 Then
        '    Tools.MostrarMensaje(Tools.Mensajes.Warning, "No hay información para generar el reporte.")
        'Else
        '    Try
        '        Dim OBJReporte As New Framework.Negocios.ReportesBU
        '        Dim EntidadReporte As Entidades.Reportes
        '        EntidadReporte = OBJReporte.LeerReporteporClave("RESUMEN_INVENTARIO_POR_DEPARTAMENTO_MA")
        '        Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
        '                EntidadReporte.Pnombre + ".mrt"
        '        My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)
        '        Dim reporte As New StiReport

        '        reporte.Load(archivo)
        '        reporte.Compile()
        '        reporte("urlImagenNave") = GetRutaLogoPorNave(tabla1)
        '        reporte("fecha") = Now.ToShortDateString
        '        reporte("Departamento") = PNombreDepartamento
        '        reporte("Titulo") = "INVENTARIO " + PNombreDepartamento
        '        reporte("TotalLotes") = ObtenerTotales(tabla2, "TotalLotes")
        '        reporte("TotalPares") = ObtenerTotales(tabla2, "TotalPares")
        '        reporte.RegData(dsTablaResumenNaves)
        '        reporte.Show()
        '    Catch ex As Exception
        '    End Try
        'End If
        'Me.Cursor = Cursors.Default

        If Status = False Then
            If tabla1.Rows.Count = 0 And tabla3.Rows.Count = 0 Then
                Tools.MostrarMensaje(Tools.Mensajes.Warning, "No hay información para generar el reporte en Montado y Adorno o Embarque.")
            Else
                Try
                    Dim OBJReporte As New Framework.Negocios.ReportesBU
                    Dim EntidadReporte As Entidades.Reportes
                    EntidadReporte = OBJReporte.LeerReporteporClave("REPORTE_AVANCE_PRODUCCION_POR_PROGRAMA")
                    Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
                        EntidadReporte.Pnombre + ".mrt"
                    My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)
                    Dim reporte As New StiReport

                    reporte.Load(archivo)
                    reporte.Compile()
                    reporte("urlImagenNave") = GetRutaLogoPorNave(tabla1)
                    reporte("fecha") = Now.ToShortDateString
                    reporte("Departamento") = "MONTADO Y ADORNO"
                    reporte("Titulo") = "INVENTARIO " + "MONTADO Y ADORNO"
                    reporte.RegData(dsTablaResumenNaves)
                    reporte.Show()
                Catch ex As Exception
                End Try
            End If
        Else
            If tabla1.Rows.Count = 0 And tabla3.Rows.Count = 0 Then
                Tools.MostrarMensaje(Tools.Mensajes.Warning, "No hay información para generar el reporte, en Montado y Adorno.")
            Else
                Try
                    Dim OBJReporte As New Framework.Negocios.ReportesBU
                    Dim EntidadReporte As Entidades.Reportes
                    EntidadReporte = OBJReporte.LeerReporteporClave("REPORTE_AVANCE_PRODUCCION_POR_PROGRAMA_MA_PT")
                    Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
                            EntidadReporte.Pnombre + ".mrt"
                    My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)
                    Dim reporte As New StiReport

                    reporte.Load(archivo)
                    reporte.Compile()
                    If tabla1.Rows.Count > 0 Then
                        reporte("urlImagenNave") = GetRutaLogoPorNave(tabla1)
                        reporte("Encabezado") = "EN PROCESO"
                    Else
                        reporte("urlImagenNave") = GetRutaLogoPorNave(tabla3)
                        reporte("Encabezado") = "TERMINADO"
                    End If
                    reporte("fecha") = Now.ToShortDateString
                    reporte("Departamento") = "MONTADO Y ADORNO"
                    reporte("Titulo") = "INVENTARIO " + "MONTADO Y ADORNO"
                    reporte.RegData(dsTablaResumenNaves)
                    reporte.Show()
                Catch ex As Exception
                End Try
            End If
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub ImprimirReporteInventarioNave()
        Dim tablaDatosOP As DataTable
        Dim objBU As New OrdenesEnProcesoBU

        tablaDatosOP = objBU.imprimirReporteNavesProduccionInventario(PNaveid, FechaInicial.AddDays(-1).ToShortDateString, Today.ToShortDateString, 1, "", "", "", "", "", "", "", "", "", 0, "", "", "", 0, "", "", SesionUsuario.UsuarioSesion.PUserUsuarioid)
        Dim fechaInicio As New Date
        Dim fechaFin As New Date
        Dim diasDeProceso As Double = 0.0
        For i As Integer = 0 To tablaDatosOP.Rows.Count - 1
            fechaInicio = tablaDatosOP.Rows(i).Item("FechaPrograma")
            If Not tablaDatosOP.Rows(i).Item("FechaSalida") = "1/1/1900 12:00:00 AM" Then
                fechaFin = tablaDatosOP.Rows(i).Item("FechaSalida").ToShortDateString
            Else
                fechaFin = DateTime.Now.ToString("dd/MM/yyyy")
            End If
            diasDeProceso = getDiasdeProceso(fechaInicio, fechaFin)
            tablaDatosOP.Rows(i).Item("DiasdeProceso") = diasDeProceso
        Next
        tablaDatosOP.TableName = "dtOrdenesEnProcesoNave"

        'Ordenamiento por dias de proceso descendencte
        tablaDatosOP.DefaultView.Sort = "DiasdeProceso DESC"
        tablaDatosOP = tablaDatosOP.DefaultView.ToTable

        If tablaDatosOP.Rows.Count = 0 Then
            Tools.MostrarMensaje(Tools.Mensajes.Warning, "No hay información para generar el reporte.")
        Else
            Try
                Dim OBJReporte As New Framework.Negocios.ReportesBU
                Dim EntidadReporte As Entidades.Reportes
                EntidadReporte = OBJReporte.LeerReporteporClave("REPORTE_ORDENES_PROCESO_INVENTARIO")
                Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
                        EntidadReporte.Pnombre + ".mrt"
                My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)
                Dim reporte As New StiReport

                reporte.Load(archivo)
                reporte.Compile()
                reporte("urlImagenNave") = GetRutaLogoPorNaveInventario(tablaDatosOP)
                reporte("FechaDel") = "DEL: " + FechaInicial.ToShortDateString
                reporte("FechaAl") = " AL: " + Today.ToShortDateString
                reporte("Titulo") = "PARES EN PROCESO"
                reporte("Usuario") = SesionUsuario.UsuarioSesion.PUserUsername
                reporte.RegData(tablaDatosOP)
                reporte.Show()
            Catch ex As Exception
            End Try
        End If
        Me.Cursor = Cursors.Default
    End Sub


    Private Sub ImprimirReportePorCelulas(ByVal DepCelula As String)
        Dim objBU As New LotesAvancesBU
        Dim comboText As New ConsultaInventarioForm
        Dim dsTablaResumenNaves As New DataSet("dsListaProduccionAvances")

        Dim tabla1 As New DataTable
        Dim tabla2 As New DataTable
        Dim tabla3 As New DataTable

        Me.Cursor = Cursors.WaitCursor

        tabla1 = objBU.RegistrosReporteCelula(PFechaInicial, Now.ToShortDateString, PNaveid, PDepartamentoid, DepCelula)
        tabla2 = objBU.RegistrosResumenCelula(PFechaInicial, Now.ToShortDateString, PNaveid, PDepartamentoid, DepCelula)

        tabla1.TableName = "dtProduccionAvances"
        tabla2.TableName = "dtResumenPorNave"

        'PDepartamentoid
        dsTablaResumenNaves.Tables.Add(tabla1)
        dsTablaResumenNaves.Tables.Add(tabla2)

        If tabla1.Rows.Count = 0 Then
            Tools.MostrarMensaje(Tools.Mensajes.Warning, "No hay información para generar el reporte.")
        Else
            Try
                Dim OBJReporte As New Framework.Negocios.ReportesBU
                Dim EntidadReporte As Entidades.Reportes
                EntidadReporte = OBJReporte.LeerReporteporClave("RESUMEN_INVENTARIO_POR_CELULA")
                Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
                        EntidadReporte.Pnombre + ".mrt"
                My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)
                Dim reporte As New StiReport

                reporte.Load(archivo)
                reporte.Compile()
                reporte("urlImagenNave") = GetRutaLogoPorNave(tabla1)
                reporte("fecha") = Now.ToShortDateString
                reporte("Departamento") = PNombreDepartamento
                reporte("Titulo") = "INVENTARIO " + DepCelula
                reporte("TotalLotes") = ObtenerTotales(tabla2, "Lotes")
                reporte("TotalPares") = ObtenerTotales(tabla2, "Pares")
                reporte.RegData(dsTablaResumenNaves)
                reporte.Show()
            Catch ex As Exception
            End Try
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Function GetRutaLogoPorNave(ByVal img As DataTable)
        Dim imagenNave As String
        For i As Integer = 0 To img.Rows.Count - 1
            If img.Rows(i).Item("Imagen").ToString() <> "" Then
                imagenNave = img.Rows(i).Item("Imagen").ToString()
            End If
        Next
        Return imagenNave
    End Function

    Private Function GetRutaLogoPorNaveInventario(ByVal img As DataTable)
        Dim imagenNave As String
        For i As Integer = 0 To img.Rows.Count - 1
            If img.Rows(i).Item("LogoNave").ToString() <> "" Then
                imagenNave = img.Rows(i).Item("LogoNave").ToString()
            End If
        Next
        Return imagenNave
    End Function

    Private Function ObtenerTotales(ByVal tabla As DataTable, ByVal encabezado As String)
        Dim total As Integer
        For i As Integer = 0 To tabla.Rows.Count - 1
            If tabla.Columns.Contains(encabezado) Then
                If IsDBNull(tabla.Rows(i).Item(encabezado)) = False Then
                    total += tabla.Rows(i).Item(encabezado)
                End If
            End If
        Next
        Return total
    End Function

    Public Property PProceso As Boolean
        Get
            Return Proceso
        End Get
        Set(value As Boolean)
            Proceso = value
        End Set
    End Property
    Public Property PAtrasados As Boolean
        Get
            Return Atrasados
        End Get
        Set(value As Boolean)
            Atrasados = value
        End Set
    End Property
    Public Property PTerminados As Boolean
        Get
            Return Terminados
        End Get
        Set(value As Boolean)
            Terminados = value
        End Set
    End Property

    Public Property PFechaInicial As Date
        Get
            Return FechaInicial
        End Get
        Set(value As Date)
            FechaInicial = value
        End Set
    End Property
    Public Property PDepartamentoid As Int32
        Get
            Return Departamentoid
        End Get
        Set(value As Int32)
            Departamentoid = value
        End Set
    End Property
    Public Property PNaveid As Int32
        Get
            Return Naveid
        End Get
        Set(value As Int32)
            Naveid = value
        End Set
    End Property
    Dim NombreDepartamento As String
    Public Property PNombreDepartamento As String
        Get
            Return NombreDepartamento
        End Get
        Set(value As String)
            NombreDepartamento = value
        End Set
    End Property
    Private Sub DetalleLotesForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        grdAvances.AutoClipboard = True
        grdInventarioNave.AutoClipboard = True

        If validarBotonImprimir = 1 Then
            btnImprimir.Visible = True
            lblImprimir.Visible = True
        Else
            btnImprimir.Visible = False
            lblImprimir.Visible = False
        End If

        'WindowState = FormWindowState.Maximized
        Me.Cursor = Cursors.WaitCursor
        Dim objBu As New Global.Produccion.Negocios.DepartamentosSICYBU
        Departamentos = (objBu.ListaDepartamentosSegunNaveProduccion(Naveid))
        If Departamentoid > 0 Then
            For Each dep As DepartamentosProduccion In Departamentos
                Dim Departamento As New DepartamentosProduccion
                Departamento.PIDConfiguracion = dep.PIDConfiguracion
                Departamento.PNombre = dep.PNombre
                Departamento.PDias = dep.PDias

                If Departamento.PIDConfiguracion = Departamentoid Then
                    listaDeps.Add(Departamento)
                End If
            Next
        Else
            listaDeps = New List(Of DepartamentosProduccion)
            For Each dep As DepartamentosProduccion In Departamentos
                Dim Departamento As New DepartamentosProduccion
                Departamento.PIDConfiguracion = dep.PIDConfiguracion
                Departamento.PNombre = dep.PNombre
                Departamento.PDias = dep.PDias
                listaDeps.Add(Departamento)
            Next
        End If
        LlenarGrid(Naveid)
        If (ShowColDiasRetraso = False) Then
            'grdAvances.Cols("DiasAtraso").Visible = False
        End If
        If Departamentoid > 0 Then
            GenerarInventarioDepartamento()
        Else
            GenerarInventarioNave()
        End If
        For Each row As C1.Win.C1FlexGrid.Row In grdAvances.Rows
            Dim cc As C1.Win.C1FlexGrid.CellStyle
            cc = Me.grdAvances.Styles.Add("ColumnColor")
            ColorNave = "#85A3FF"
            If row.Index > 0 Then

                Try
                    If grdAvances(row.Index, "CORTE").ToString.Length > 0 Then
                        Dim ColorCorteCol As C1.Win.C1FlexGrid.CellStyle
                        ColorCorteCol = Me.grdAvances.Styles.Add("ColumnColorCorte")
                        ColorCorteCol.BackColor = System.Drawing.ColorTranslator.FromHtml(ColorCorte)
                        grdAvances.SetCellStyle(row.Index, grdAvances.Cols("CORTE").Index, ColorCorteCol)
                    End If
                Catch ex As Exception

                End Try
                Try
                    If grdAvances(row.Index, "PESPUNTE").ToString.Length > 0 Then
                        Dim ColorPespunteCol As C1.Win.C1FlexGrid.CellStyle
                        ColorPespunteCol = Me.grdAvances.Styles.Add("ColumnColorPespunte")
                        ColorPespunteCol.BackColor = System.Drawing.ColorTranslator.FromHtml(ColorPespunte)
                        grdAvances.SetCellStyle(row.Index, grdAvances.Cols("PESPUNTE").Index, ColorPespunteCol)
                    End If
                Catch ex As Exception

                End Try
                Try
                    If grdAvances(row.Index, "MONTADO Y ADORNO").ToString.Length > 0 Then
                        Dim ColorMontadoCol As C1.Win.C1FlexGrid.CellStyle
                        ColorMontadoCol = Me.grdAvances.Styles.Add("ColumnColorMontado")
                        ColorMontadoCol.BackColor = System.Drawing.ColorTranslator.FromHtml(ColorMontado)
                        grdAvances.SetCellStyle(row.Index, grdAvances.Cols("MONTADO Y ADORNO").Index, ColorMontadoCol)
                    End If
                Catch ex As Exception

                End Try
                Try
                    If grdAvances(row.Index, "EMBARQUE").ToString.Length > 0 Then
                        cc.BackColor = System.Drawing.ColorTranslator.FromHtml(ColorNave)
                        grdAvances.SetCellStyle(row.Index, grdAvances.Cols("EMBARQUE").Index, cc)
                    End If
                Catch ex As Exception

                End Try


                'If cmbDepartamento.Text = "CORTE" Then
                '    grdAvances.Cols("Célula").Visible = False
                '    cc.BackColor = System.Drawing.ColorTranslator.FromHtml(ColorCorte)
                '    grdAvances.Cols("CORTE").Style = Me.grdAvances.Styles("ColumnColor")
                '    Dim indice As New Int32
                '    indice = grdAvances.Cols("CORTE").Index
                '    grdAvances.Cols(indice + 1).Style = Me.grdAvances.Styles("ColumnColor")
                'End If
                'If cmbDepartamento.Text = "PESPUNTE" Then
                '    cc.BackColor = System.Drawing.ColorTranslator.FromHtml(ColorPespunte)
                '    grdAvances.Cols("PESPUNTE").Style = Me.grdAvances.Styles("ColumnColor")
                '    Dim indice As New Int32
                '    indice = grdAvances.Cols("PESPUNTE").Index
                '    grdAvances.Cols(indice + 1).Style = Me.grdAvances.Styles("ColumnColor")
                'End If
                'If cmbDepartamento.Text = "MONTADO Y ADORNO" Then
                '    cc.BackColor = System.Drawing.ColorTranslator.FromHtml(ColorMontado)
                '    grdAvances.Cols("MONTADO Y ADORNO").Style = Me.grdAvances.Styles("ColumnColor")
                '    Dim indice As New Int32
                '    indice = grdAvances.Cols("MONTADO Y ADORNO").Index
                '    grdAvances.Cols(indice + 1).Style = Me.grdAvances.Styles("ColumnColor")
                'End If
                'If cmbDepartamento.Text = "EMBARQUE" Then
                '    cc.BackColor = System.Drawing.ColorTranslator.FromHtml(ColorNave)
                '    grdAvances.Cols("EMBARQUE").Style = Me.grdAvances.Styles("ColumnColor")
                'End If
                'If cmbDepartamento.Text = Nothing Then
                '    Dim ColorCorteCol As C1.Win.C1FlexGrid.CellStyle
                '    ColorCorteCol = Me.grdAvances.Styles.Add("ColumnColorCorte")
                '    ColorCorteCol.BackColor = System.Drawing.ColorTranslator.FromHtml(ColorCorte)
                '    Dim indice As New Int32
                '    indice = grdAvances.Cols("CORTE").Index
                '    grdAvances.Cols("CORTE").Style = Me.grdAvances.Styles("ColumnColorCorte")
                '    grdAvances.Cols(indice + 1).Style = Me.grdAvances.Styles("ColumnColorCorte")
                '    grdAvances.Cols(indice + 2).Style = Me.grdAvances.Styles("ColumnColorCorte")


                '    Dim ColorPespunteCol As C1.Win.C1FlexGrid.CellStyle
                '    ColorPespunteCol = Me.grdAvances.Styles.Add("ColumnColorPespunte")
                '    ColorPespunteCol.BackColor = System.Drawing.ColorTranslator.FromHtml(ColorPespunte)
                '    grdAvances.Cols("PESPUNTE").Style = Me.grdAvances.Styles("ColumnColorPespunte")
                '    indice = grdAvances.Cols("PESPUNTE").Index
                '    grdAvances.Cols(indice + 1).Style = Me.grdAvances.Styles("ColumnColorPespunte")
                '    grdAvances.Cols(indice + 2).Style = Me.grdAvances.Styles("ColumnColorPespunte")


                '    Dim ColorMontadoCol As C1.Win.C1FlexGrid.CellStyle
                '    ColorMontadoCol = Me.grdAvances.Styles.Add("ColumnColorMontado")
                '    ColorMontadoCol.BackColor = System.Drawing.ColorTranslator.FromHtml(ColorMontado)
                '    grdAvances.Cols("MONTADO Y ADORNO").Style = Me.grdAvances.Styles("ColumnColorMontado")
                '    indice = grdAvances.Cols("MONTADO Y ADORNO").Index
                '    grdAvances.Cols(indice + 1).Style = Me.grdAvances.Styles("ColumnColorMontado")
                '    grdAvances.Cols(indice + 2).Style = Me.grdAvances.Styles("ColumnColorMontado")


                '    cc.BackColor = System.Drawing.ColorTranslator.FromHtml(ColorNave)
                '    grdAvances.Cols("EMBARQUE").Style = Me.grdAvances.Styles("ColumnColor")
                '    indice = grdAvances.Cols("EMBARQUE").Index
                '    grdAvances.Cols(indice + 1).Style = Me.grdAvances.Styles("ColumnColor")

                'End If


            End If
        Next

        'Dim cc As C1.Win.C1FlexGrid.CellStyle
        'cc = Me.grdAvances.Styles.Add("ColumnColor")

        'If NombreDepartamento = "CORTE" Then
        '    grdAvances.Cols("Celula").Visible = False
        '    cc.BackColor = System.Drawing.ColorTranslator.FromHtml(ColorCorte)
        '    grdAvances.Cols("CORTE").Style = Me.grdAvances.Styles("ColumnColor")
        'End If
        'If NombreDepartamento = "PESPUNTE" Then
        '    cc.BackColor = System.Drawing.ColorTranslator.FromHtml(ColorPespunte)
        '    grdAvances.Cols("PESPUNTE").Style = Me.grdAvances.Styles("ColumnColor")
        'End If
        'If NombreDepartamento = "MONTADO Y ADORNO" Then
        '    cc.BackColor = System.Drawing.ColorTranslator.FromHtml(ColorMontado)
        '    grdAvances.Cols("MONTADO Y ADORNO").Style = Me.grdAvances.Styles("ColumnColor")
        'End If
        'If NombreDepartamento = "EMBARQUE" Then
        '    cc.BackColor = System.Drawing.ColorTranslator.FromHtml(ColorNave)
        '    grdAvances.Cols("EMBARQUE").Style = Me.grdAvances.Styles("ColumnColor")
        'End If
        'If NombreDepartamento = Nothing Then
        '    Dim ColorCorteCol As C1.Win.C1FlexGrid.CellStyle
        '    ColorCorteCol = Me.grdAvances.Styles.Add("ColumnColorCorte")
        '    ColorCorteCol.BackColor = System.Drawing.ColorTranslator.FromHtml(ColorCorte)
        '    Dim indice As New Int32
        '    indice = grdAvances.Cols("CORTE").Index
        '    grdAvances.Cols("CORTE").Style = Me.grdAvances.Styles("ColumnColorCorte")
        '    grdAvances.Cols(indice + 1).Style = Me.grdAvances.Styles("ColumnColorCorte")
        '    grdAvances.Cols(indice + 2).Style = Me.grdAvances.Styles("ColumnColorCorte")


        '    Dim ColorPespunteCol As C1.Win.C1FlexGrid.CellStyle
        '    ColorPespunteCol = Me.grdAvances.Styles.Add("ColumnColorPespunte")
        '    ColorPespunteCol.BackColor = System.Drawing.ColorTranslator.FromHtml(ColorPespunte)
        '    grdAvances.Cols("PESPUNTE").Style = Me.grdAvances.Styles("ColumnColorPespunte")
        '    indice = grdAvances.Cols("PESPUNTE").Index
        '    grdAvances.Cols(indice + 1).Style = Me.grdAvances.Styles("ColumnColorPespunte")
        '    grdAvances.Cols(indice + 2).Style = Me.grdAvances.Styles("ColumnColorPespunte")


        '    Dim ColorMontadoCol As C1.Win.C1FlexGrid.CellStyle
        '    ColorMontadoCol = Me.grdAvances.Styles.Add("ColumnColorMontado")
        '    ColorMontadoCol.BackColor = System.Drawing.ColorTranslator.FromHtml(ColorMontado)
        '    grdAvances.Cols("MONTADO Y ADORNO").Style = Me.grdAvances.Styles("ColumnColorMontado")
        '    indice = grdAvances.Cols("MONTADO Y ADORNO").Index
        '    grdAvances.Cols(indice + 1).Style = Me.grdAvances.Styles("ColumnColorMontado")
        '    grdAvances.Cols(indice + 2).Style = Me.grdAvances.Styles("ColumnColorMontado")


        '    cc.BackColor = System.Drawing.ColorTranslator.FromHtml(ColorNave)
        '    grdAvances.Cols("EMBARQUE").Style = Me.grdAvances.Styles("ColumnColor")
        '    indice = grdAvances.Cols("EMBARQUE").Index
        '    grdAvances.Cols(indice + 1).Style = Me.grdAvances.Styles("ColumnColor")
        '    ' grdAvances.Cols(indice + 2).Style = Me.grdAvances.Styles("ColumnColor")
        'End If
        'llenarCombo()
        cmbCelulas.Visible = False
        lbl_Celulas.Visible = False
        Me.Cursor = Cursors.Default
    End Sub

    Public Sub llenarCombo()
        Try
            Dim objBU As New LotesAvancesBU
            Dim tabla As New DataTable

            tabla = objBU.RegistrosCelulaNave(PNombreDepartamento, PNaveid)
            tabla.Rows.InsertAt(tabla.NewRow, 0)
            cmbCelulas.DisplayMember = "Celula"
            cmbCelulas.ValueMember = "IdCelula"
            cmbCelulas.DataSource = tabla

            If tabla.Rows.Count > 2 Then
                cmbCelulas.Visible = True
                lbl_Celulas.Visible = True
            Else
                cmbCelulas.Visible = False
                lbl_Celulas.Visible = False
            End If

        Catch ex As Exception

        End Try
    End Sub

    Public Sub LlenarGrid(ByVal Naveid As Int32)

        Dim ListaAvancesProduccion As New List(Of LotesAvances)
        Dim objBU As New LotesAvancesBU
        Dim diasAtrasados As New Int32

        Dim Consecutivo As Int32 = 1
        Dim DepartamentosAnterioresDatos As New DepartamentosProduccion
        ' Dim Departamentos As New List(Of Int32)
        grdAvances.Cols.Count = 10
        If Departamentoid > 0 Then

            DepartamentosAnterioresDatos = objBU.DepartamentosAnteriores(Naveid, Departamentoid)
            For Each dep As DepartamentosProduccion In Departamentos
                If dep.PIDConfiguracion = Departamentoid Then
                    grdAvances.Cols.Count = grdAvances.Cols.Count + 1
                    Dim DepartamentoNombre As String = dep.PNombre.ToLower
                    grdAvances.Cols(grdAvances.Cols.Count - 1).Caption = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(DepartamentoNombre)
                    grdAvances.Cols(grdAvances.Cols.Count - 1).Name = dep.PNombre
                    grdAvances.Cols.Count = grdAvances.Cols.Count + 1
                    grdAvances.Cols(grdAvances.Cols.Count - 1).Name = "DiasAtraso"
                    grdAvances.Cols(grdAvances.Cols.Count - 1).Caption = "Días retraso"
                    grdAvances.Cols.Count = grdAvances.Cols.Count + 1
                    grdAvances.Cols(grdAvances.Cols.Count - 1).Name = "Celula"
                    grdAvances.Cols(grdAvances.Cols.Count - 1).Caption = "Célula"
                    If dep.PNombre = "CORTE" Then
                        ColorCorte = dep.PColorDepartamento
                    End If
                    If dep.PNombre = "PESPUNTE" Then
                        ColorPespunte = dep.PColorDepartamento
                    End If
                    If dep.PNombre = "MONTADO Y ADORNO" Then
                        ColorMontado = dep.PColorDepartamento
                    End If
                    If dep.PNombre = "EMBARQUE" Then
                        ColorNave = dep.PColorDepartamento
                    End If

                    'grdAvances.Cols(grdAvances.Cols.Count - 2).Style.BackColor = System.Drawing.ColorTranslator.FromHtml(dep.PColorDepartamento)
                End If


            Next

        Else
            For Each dep As DepartamentosProduccion In Departamentos
                grdAvances.Cols.Count = grdAvances.Cols.Count + 1
                Dim DepartamentoNombre As String = dep.PNombre.ToLower
                grdAvances.Cols(grdAvances.Cols.Count - 1).Caption = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(DepartamentoNombre)
                grdAvances.Cols(grdAvances.Cols.Count - 1).Name = dep.PNombre
                grdAvances.Cols.Count = grdAvances.Cols.Count + 1
                grdAvances.Cols(grdAvances.Cols.Count - 1).Caption = "Días retraso"
                grdAvances.Cols.Count = grdAvances.Cols.Count + 1
                grdAvances.Cols(grdAvances.Cols.Count - 1).Caption = "Celula"
                If dep.PNombre = "CORTE" Then
                    ColorCorte = dep.PColorDepartamento
                End If
                If dep.PNombre = "PESPUNTE" Then
                    ColorPespunte = dep.PColorDepartamento
                End If
                If dep.PNombre = "MONTADO Y ADORNO" Then
                    ColorMontado = dep.PColorDepartamento
                End If
                If dep.PNombre = "EMBARQUE" Then
                    ColorNave = dep.PColorDepartamento
                End If
            Next
        End If
        Dim Validacion As Boolean = False
        If DepartamentosAnterioresDatos.PDptoAnterior <> 0 Then
            Validacion = True
        End If

        Dim ContarLotesAtrasadosEmbarque As New Boolean
        ContarLotesAtrasadosEmbarque = False
        If Departamentoid = 0 Then
            grdAvances.Cols.Count = grdAvances.Cols.Count + 1
            grdAvances.Cols(grdAvances.Cols.Count - 1).Caption = "Embarque"
            grdAvances.Cols(grdAvances.Cols.Count - 1).Name = "EMBARQUE"
            ContarLotesAtrasadosEmbarque = True
            grdAvances.Cols.Count = grdAvances.Cols.Count + 1
            grdAvances.Cols(grdAvances.Cols.Count - 1).Caption = "Días retraso"

            ColorNave = "#85A3FF"


        End If
        DepartamentoAnterior = DepartamentosAnterioresDatos.PConfiguracionDptoAnterior
        Orden = DepartamentosAnterioresDatos.POrden
        ListaAvancesProduccion = objBU.ListaAvancesProduccionAvances(FechaInicial.AddDays(-1).ToShortDateString, Today.ToShortDateString, Naveid, listaDeps, DepartamentosAnterioresDatos.PConfiguracionDptoAnterior, Orden)
        For Each Lote As LotesAvances In ListaAvancesProduccion
            Dim Departamentos As Boolean = False
            Dim DepartamentoAnteriorDioAvance As Boolean = False
            If Not Lote.PFechaEmbarque = Date.MinValue Then
                ParesTerminados += Lote.PPares
                LotesTerminados += 1
            Else

            End If



            Dim strFila As String = ControlChars.Tab & Lote.PFechaLote &
                               ControlChars.Tab & Lote.PLote &
                               ControlChars.Tab & Lote.PModelo &
                               ControlChars.Tab & Lote.PColeccion &
                               ControlChars.Tab & Lote.PTalla &
                               ControlChars.Tab & Lote.PColor &
                               ControlChars.Tab & Lote.PPares &
                               ControlChars.Tab & diasAtrasados '&
            'ControlChars.Tab & Lote.PObservaciones

            TotalPares += Lote.PPares
            TotalLotes += 1

            Dim diasTotales As Int32 = 0
            Dim estaatrasado As Boolean = False
            Dim estaProceso As Boolean = False
            Dim contadorDepartamentos As Integer
            For Each departamentoAvance As DepartamentosProduccion In Lote.PAvanceDepartamentos
                Dim Existe As Boolean = False
                Dim depTotales As New DepartamentosProduccion
                Dim IDDEpartamento As Int32
                IDDEpartamento = departamentoAvance.PIDConfiguracion
                'MsgBox(departamentoAvance.PIDConfiguracion)
                depTotales = departamentoAvance
                contadorDepartamentos += 1
                If depTotales.PFechaAvance = Date.MinValue Or (contadorDepartamentos = 3 And Lote.PFechaEmbarque = Date.MinValue) Then
                    If contadorDepartamentos = 3 And depTotales.PFechaAvance <> Date.MinValue Then
                        strFila += ControlChars.Tab & depTotales.PFechaAvance.ToShortDateString
                    Else
                        strFila += ControlChars.Tab & ""
                    End If

                    estaProceso = True

                    If inventario.Count = 0 Then
                        Dim AgregarDatosDepartamentos As New InventarioProduccion
                        AgregarDatosDepartamentos.PParesProg = 0
                        AgregarDatosDepartamentos.PLotesProg += 0
                        AgregarDatosDepartamentos.PIDDepartamento = IDDEpartamento
                        inventario.Add(AgregarDatosDepartamentos)

                    End If

                    For Each recorrerinventario As InventarioProduccion In inventario
                        If recorrerinventario.PIDDepartamento = IDDEpartamento Then
                            Existe = True
                            If Existe = True Then

                                recorrerinventario.PParesProg += Lote.PPares
                                recorrerinventario.PLotesProg += 1
                            End If
                        End If
                    Next
                    If Existe = False Then
                        Dim AgregarDatosDepartamentos As New InventarioProduccion
                        AgregarDatosDepartamentos.PParesProg += Lote.PPares
                        AgregarDatosDepartamentos.PLotesProg += 1
                        AgregarDatosDepartamentos.PIDDepartamento = IDDEpartamento
                        inventario.Add(AgregarDatosDepartamentos)
                    End If


                Else
                    strFila += ControlChars.Tab & depTotales.PFechaAvance.ToShortDateString
                    Departamentos = True
                    Dim AgregarDatosDepartamentos As New InventarioProduccion
                    If inventario.Count = 0 Then
                        AgregarDatosDepartamentos.PParesTerminados = Lote.PPares
                        AgregarDatosDepartamentos.PLotesTerminados += 1
                        AgregarDatosDepartamentos.PIDDepartamento = IDDEpartamento
                        inventario.Add(AgregarDatosDepartamentos)

                    End If

                    For Each recorrerinventario As InventarioProduccion In inventario
                        If recorrerinventario.PIDDepartamento = IDDEpartamento Then
                            Existe = True
                            If Existe = True Then
                                AgregarDatosDepartamentos.PParesTerminados = Lote.PPares
                                AgregarDatosDepartamentos.PLotesTerminados += 1
                            End If
                        End If
                    Next
                    If Existe = False Then
                        AgregarDatosDepartamentos.PParesTerminados += Lote.PPares
                        AgregarDatosDepartamentos.PLotesTerminados += 1
                        AgregarDatosDepartamentos.PIDDepartamento = IDDEpartamento
                        inventario.Add(AgregarDatosDepartamentos)
                    End If




                End If






                diasTotales = departamentoAvance.PDias / 6 - 1







                Dim fechaInicio As New Date
                fechaInicio = Lote.PFechaLote
                Dim FechaFin As New Date
                FechaFin = Today



                While fechaInicio < FechaFin.AddDays(1)
                    If fechaInicio.DayOfWeek = 6 Then
                        diasTotales += 1
                    End If
                    fechaInicio = fechaInicio.AddDays(1)
                End While

                diasAtrasados = DateDiff("d", Lote.PFechaLote.AddDays(diasTotales), Today)

                If diasAtrasados > 0 And departamentoAvance.PFechaAvance = Date.MinValue Then
                    strFila += ControlChars.Tab & diasAtrasados.ToString
                    ShowColDiasRetraso = True
                    If diasAtrasados > 0 Then
                        ParesAtrasados += Lote.PPares
                        LotesAtrasados += 1
                        LotesAtrasadosDepartamento += 1
                        ParesAtrasadosDepartameto += Lote.PPares
                    End If
                    estaatrasado = True
                Else
                    strFila += ControlChars.Tab & " "

                End If

                If departamentoAvance.PCelulas = Nothing Then
                    strFila += ControlChars.Tab & "NO ASIGNADA"
                Else
                    strFila += ControlChars.Tab & departamentoAvance.PCelulas
                    For Each Celula As CelulasProduccion In ListaCelulas
                        If Celula.PNombreCelula = departamentoAvance.PCelulas Then

                            If Not departamentoAvance.PFechaAvance = Date.MinValue Then
                                Celula.PCantidadTerminadasPares += Lote.PPares
                                Celula.PCantidadTerminadasLotes += 1

                            Else
                                Celula.PCantidadAcumuladaLotes += 1
                                Celula.PCantidadAcumuladaPares += Lote.PPares
                            End If

                            If diasAtrasados > 0 And departamentoAvance.PFechaAvance = Date.MinValue Then
                                If diasAtrasados > 0 Then
                                    Celula.PCantidadAtrasadasPares += Lote.PPares
                                    Celula.PCantidadAtrasadasLotes += 1
                                End If
                            End If

                        End If
                    Next

                End If

            Next
            contadorDepartamentos = 0

            '********************************************

            If Departamentoid = 0 Then
                If Not Lote.PFechaEmbarque = Date.MinValue Then
                    strFila += ControlChars.Tab & Lote.PFechaEmbarque.ToShortDateString
                Else
                    diasTotales = 4
                    Dim fechaInicio As New Date
                    fechaInicio = Lote.PFechaLote
                    Dim FechaFin As New Date
                    FechaFin = Today



                    While fechaInicio < FechaFin.AddDays(1)
                        If fechaInicio.DayOfWeek = 6 Then
                            diasTotales += 1
                        End If
                        fechaInicio = fechaInicio.AddDays(1)
                    End While
                    diasAtrasados = DateDiff("d", Lote.PFechaLote.AddDays(diasTotales), Today)
                    If diasAtrasados > 0 Then
                        LotesAtrasados += 1
                        ParesAtrasados += Lote.PPares
                    End If
                    If diasAtrasados > 0 Then
                        strFila += ControlChars.Tab & "" + ControlChars.Tab & diasAtrasados
                        estaatrasado = True
                    Else
                        strFila += ControlChars.Tab & ""
                    End If

                End If
            End If

            If Atrasados = True Or Terminados = True Then
                If Atrasados = True Then
                    If estaatrasado = True Then


                        paresAtrasadosFiltro += Lote.PPares
                        LotesAtrasadosFiltro += 1
                        strFila = "" + ControlChars.Tab & Consecutivo & strFila
                        grdAvances.AddItem(strFila)
                        Consecutivo += 1
                    End If
                Else

                End If

                If Terminados = True Then
                    If Departamentoid > 0 Then
                        If Departamentos = True Then
                            strFila = "" + ControlChars.Tab & Consecutivo & strFila
                            grdAvances.AddItem(strFila)
                            Consecutivo += 1
                        End If
                    Else
                        If Lote.PFechaEmbarque <> Date.MinValue Then
                            strFila = "" + ControlChars.Tab & Consecutivo & strFila
                            grdAvances.AddItem(strFila)
                            Consecutivo += 1
                        End If
                    End If
                Else

                End If
            Else
                If Proceso = True Then
                    If estaProceso = True Then
                        If Departamentoid > 0 Then
                            If Departamentos = False Then
                                strFila = "" + ControlChars.Tab & Consecutivo & strFila
                                grdAvances.AddItem(strFila)
                                Consecutivo += 1
                            End If

                        Else
                                strFila = "" + ControlChars.Tab & Consecutivo & strFila
                            grdAvances.AddItem(strFila)
                            Consecutivo += 1
                        End If

                    End If

                Else

                        strFila = "" + ControlChars.Tab & Consecutivo & strFila
                    grdAvances.AddItem(strFila)
                    Consecutivo += 1
                End If
            End If


            'If cmbCelulas.SelectedIndex > 0 Then
            '    If strFila.Contains(cmbCelulas.Text) Then

            '    Else
            '        grdAvances.RemoveItem()
            '    End If
            'End If










        Next
        'lblTotalParesPrograma.Text = TotalPares.ToString("n0")
        'lblTotalLotesProgramas.Text = TotalLotes.ToString("n0")

        ParesProceso = TotalPares - ParesTerminados
        'lblParesTerminados.Text = ParesTerminados.ToString("n0")
        'lblParesProceso.Text = ParesProceso.ToString("n0")
        'lblLotesTerminados.Text = LotesTerminados.ToString("n0")
        LotesProceso = TotalLotes - LotesTerminados
        'lblLotesProceso.Text = LotesProceso.ToString("n0")
        Dim paresatrasadosgrid, lotesatrasadosgrid As Int32
        If paresAtrasadosFiltro > 0 Then
            'lblParesAtrasados.Text = paresAtrasadosFiltro.ToString("n0")
            'lblLotesAtrasados.Text = LotesAtrasadosFiltro.ToString("n0")
            paresatrasadosgrid = paresAtrasadosFiltro
            lotesatrasadosgrid = LotesAtrasadosFiltro
        Else
            'lblParesAtrasados.Text = ParesAtrasados.ToString("n0")
            'lblLotesAtrasados.Text = LotesAtrasados.ToString("n0")
            paresatrasadosgrid = ParesAtrasados
            lotesatrasadosgrid = LotesAtrasados
        End If
        Dim cadena = ""
        'cadena = ControlChars.Tab & "PROGRAMADO" & ControlChars.Tab & TotalLotes.ToString("n0") & ControlChars.Tab & TotalPares.ToString("n0")
        'grdResumenesNave.AddItem(cadena)
        'cadena = ControlChars.Tab & "PROCESO" & ControlChars.Tab & LotesProceso.ToString("n0") & ControlChars.Tab & ParesProceso.ToString("n0")
        'grdResumenesNave.AddItem(cadena)
        'cadena = ControlChars.Tab & "TERMINADO" & ControlChars.Tab & LotesTerminados.ToString("n0") & ControlChars.Tab & ParesTerminados.ToString("n0")
        'grdResumenesNave.AddItem(cadena)
        'cadena = ControlChars.Tab & "ATRASADOS" & ControlChars.Tab & lotesatrasadosgrid.ToString("n0") & ControlChars.Tab & paresatrasadosgrid.ToString("n0")
        'grdResumenesNave.AddItem(cadena)
    End Sub



    Public Sub GenerarInventarioNave()
        grdInventarioNave.Rows.Count = 1
        Dim ObjBu As New LotesAvancesBU
        Dim ListaInventario As New List(Of InventarioProduccion)

        Dim Departamentos As New List(Of DepartamentosProduccion)
        Dim ObjBUDEP As New DepartamentosSICYBU
        Dim totalParesProgramados, totalParesTerminados As Integer





        'ListaInventario = ObjBu.InventarioLotesAvances(cmbNave.SelectedValue, cmbDepartamento.SelectedValue, fechaInicio, fechaFin)
        ListaInventario = ObjBu.InventarioNaves(Naveid, FechaInicial, Today.Date)
        Dim TotalLotesTerminados, TotalLotesProgramados As New Int32
        Dim DiasDividir As New Double
        Dim InsertoFechaInicial As Boolean = False
        Dim comenzarinsertar As Boolean = False


        For Each inventario As InventarioProduccion In ListaInventario
            Dim paresTerminados As Int32
            paresTerminados = inventario.PParesProg - inventario.PParesTerminados
            If inventario.PParesProg = paresTerminados Then
            Else
                comenzarinsertar = True
            End If
            If inventario.PParesProg = 0 Then
            Else



                If comenzarinsertar = True Then
                    Dim strFila As String = ""

                    paresTerminados = inventario.PParesProg - inventario.PParesTerminados
                    Dim LotesTerminados As Int32
                    LotesTerminados = inventario.PLotesProg - inventario.PLotesTerminados
                    strFila = "" ' & ControlChars.Tab

                    strFila += ControlChars.Tab & inventario.PFecha &
                                            ControlChars.Tab & inventario.PLotesProg &
                                            ControlChars.Tab & inventario.PParesProg &
                                            ControlChars.Tab & LotesTerminados &
                                            ControlChars.Tab & paresTerminados &
                                            ControlChars.Tab & inventario.PLotesTerminados &
                                            ControlChars.Tab & inventario.PParesTerminados &
                                            ControlChars.Tab


                    If inventario.PFecha.DayOfWeek = 7 Then
                        DiasDividir += 0
                    End If
                    If inventario.PFecha.DayOfWeek = 6 Then
                        DiasDividir += 0.5
                    End If

                    If inventario.PFecha.DayOfWeek < 6 Then
                        DiasDividir += 1
                    End If




                    grdInventarioNave.AddItem(strFila)
                    TotalLotesProgramados += inventario.PLotesProg
                    TotalLotesTerminados += LotesTerminados
                    totalParesProgramados += inventario.PParesProg
                    totalParesTerminados = totalParesTerminados + paresTerminados
                End If

            End If
        Next

        '---------------------




        Dim strFilas As String = ""
        strFilas += ControlChars.Tab & "Totales" &
                    ControlChars.Tab & TotalLotesProgramados &
                    ControlChars.Tab & totalParesProgramados &
                    ControlChars.Tab & TotalLotesTerminados &
                    ControlChars.Tab & totalParesTerminados &
                    ControlChars.Tab & (TotalLotesProgramados - TotalLotesTerminados) &
                    ControlChars.Tab & (totalParesProgramados - totalParesTerminados) &
                    ControlChars.Tab
        grdInventarioNave.AddItem(strFilas)
        Dim paresProceso As Int32
        paresProceso = totalParesProgramados - totalParesTerminados
        Dim inventarioFinal As Double
        inventarioFinal = (paresProceso / (totalParesProgramados / DiasDividir))
        '  txtDias.Text = DiasDividir.ToString
        'lblInventarioNave.Text = FormatNumber(inventarioFinal.ToString, 2) + " Días"
    End Sub


    Public Sub GenerarInventarioDepartamento()
        grdInventarioNave.Rows.Count = 1
        Dim ObjBu As New LotesAvancesBU
        Dim ListaInventario As New List(Of InventarioProduccion)
        Dim DiasDepartamento As Int32
        Dim Departamentos As New List(Of DepartamentosProduccion)
        Dim ObjBUDEP As New DepartamentosSICYBU
        Dim totalParesProgramados, totalParesTerminados As Integer
        Departamentos = (ObjBUDEP.ListaDepartamentosSegunNaveProduccion(Naveid))
        If Departamentoid > 0 Then
            For Each dep As DepartamentosProduccion In Departamentos
                Dim Departamento As New DepartamentosProduccion
                Departamento = dep
                If Departamento.PIDConfiguracion = Departamentoid Then
                    DiasDepartamento = 6
                End If
            Next
        End If
        Dim fechaInicio As New Date
        fechaInicio = FechaInicial
        'Dim FechaFin As New Date
        'fechaInicio = dtpFechaInicio.Value.AddDays(DiasDepartamento * (-1))
        'DiasDepartamento = DiasDepartamento - 1
        DiasDepartamento = 6
        Dim contador As Integer = 0
        While contador < DiasDepartamento
            fechaInicio = fechaInicio.AddDays(-1)
            If fechaInicio.DayOfWeek = 6 Then
                fechaInicio = fechaInicio.AddDays(-1)
            End If
            contador += 1
        End While

        Dim fechaFin As New Date
        fechaFin = Today.Date
        'Dim FechaFin As New Date
        'fechaInicio = dtpFechaInicio.Value.AddDays(DiasDepartamento * (-1))
        Dim contadorfinal As Integer = 0
        While contadorfinal < DiasDepartamento
            fechaFin = fechaFin.AddDays(-1)
            If fechaInicio.DayOfWeek = 6 Then
                fechaFin = fechaFin.AddDays(-1)
            End If
            contadorfinal += 1
        End While




        'ListaInventario = ObjBu.InventarioLotesAvances(cmbNave.SelectedValue, cmbDepartamento.SelectedValue, fechaInicio, fechaFin)
        'ListaInventario = ObjBu.InventarioLotesAvancesV2(Naveid, Departamentoid, FechaInicial, Today.ToShortDateString, DepartamentoAnterior, Orden)
        ListaInventario = ObjBu.InventarioLotesAvancesPorDepartamentos(Naveid, FechaInicial, Today.ToShortDateString, Orden, Departamentoid)
        Dim TotalLotesTerminados, TotalLotesProgramados As New Int32
        Dim DiasDividir As New Double
        Dim InsertoFechaInicial As Boolean = False
        Dim comenzarinsertar As Boolean = False


        For Each inventario As InventarioProduccion In ListaInventario

            If inventario.PParesProg = inventario.PParesTerminados Then
            Else
                comenzarinsertar = True
            End If
            If inventario.PParesProg = 0 Then

            Else

                If comenzarinsertar = True Then
                    Dim strFila As String = ""
                    Dim TotalLotesResumen, TotalParesResumen As New Int32
                    TotalLotesResumen = inventario.PLotesProg - inventario.PLotesTerminados
                    TotalParesResumen = inventario.PParesProg - inventario.PParesTerminados

                    If TotalLotesResumen > 0 And TotalParesResumen > 0 Then
                        strFila = "" ' & ControlChars.Tab

                        strFila += ControlChars.Tab & inventario.PFecha &
                                                               ControlChars.Tab & inventario.PLotesProg &
                                                               ControlChars.Tab & inventario.PParesProg &
                                                               ControlChars.Tab & inventario.PLotesTerminados &
                                                               ControlChars.Tab & inventario.PParesTerminados &
                                                               ControlChars.Tab & TotalLotesResumen &
                                                               ControlChars.Tab & TotalParesResumen &
                                                               ControlChars.Tab


                        If inventario.PFecha.DayOfWeek = 7 Then
                            DiasDividir += 0
                        End If
                        If inventario.PFecha.DayOfWeek = 6 Then
                            DiasDividir += 0.5
                        End If

                        If inventario.PFecha.DayOfWeek < 6 Then
                            DiasDividir += 1
                        End If




                        grdInventarioNave.AddItem(strFila)
                        TotalLotesProgramados += inventario.PLotesProg
                        TotalLotesTerminados += inventario.PLotesTerminados
                        totalParesProgramados += inventario.PParesProg
                        totalParesTerminados = totalParesTerminados + inventario.PParesTerminados
                    End If

                End If

            End If

        Next

        '---------------------



        Dim strFilas As String = ""
        strFilas += ControlChars.Tab & "Totales" &
                    ControlChars.Tab & TotalLotesProgramados &
                    ControlChars.Tab & totalParesProgramados &
                    ControlChars.Tab & TotalLotesTerminados &
                    ControlChars.Tab & totalParesTerminados &
                    ControlChars.Tab & (TotalLotesProgramados - TotalLotesTerminados) &
                    ControlChars.Tab & (totalParesProgramados - totalParesTerminados) &
                    ControlChars.Tab
        grdInventarioNave.AddItem(strFilas)
        Dim paresProceso As Int32
        paresProceso = totalParesProgramados - totalParesTerminados
        Dim inventarioFinal As Double
        inventarioFinal = (paresProceso / (totalParesProgramados / DiasDividir))
        'txtDias.Text = DiasDividir.ToString
        ' lblTotalInventario.Text = FormatNumber(inventarioFinal.ToString, 2) + " Días"
    End Sub

    Function getDiasdeProceso(ByVal fInicio As Date, ByVal fFin As Date) As Double
        'Domingo=0,Lunes=1, Martes=2,Miercoles=3,Jueves=4,Viernes=5,Sabado=6
        Dim dias As Integer = 0
        Dim diasTotales As Double = 0
        dias = DateDiff(DateInterval.Day, fInicio, fFin) 'dias que existen entre el rango de fechas
        For index As Integer = 1 To dias
            If index = 1 Then
                If fInicio.DayOfWeek = 0 Then
                    'No cuenta el dia
                ElseIf fInicio.DayOfWeek = 6 Then

                    'If fInicio.Month = 3 Then
                    '    If fInicio.Day = 21 Then
                    '    ElseIf fInicio.Day = 22 Then
                    '    ElseIf fInicio.Day = 23 Then
                    '    ElseIf fInicio.Day = 24 Then
                    '    ElseIf fInicio.Day = 25 Then
                    '    ElseIf fInicio.Day = 26 Then
                    '    Else
                    'diasTotales = diasTotales + 0.5
                    '    End If
                    'Else
                    diasTotales = diasTotales + 0.5
                    'End If

                Else
                    'If fInicio.Month = 3 Then
                    '    If fInicio.Day = 21 Then
                    '    ElseIf fInicio.Day = 22 Then
                    '    ElseIf fInicio.Day = 23 Then
                    '    ElseIf fInicio.Day = 24 Then
                    '    ElseIf fInicio.Day = 25 Then
                    '    ElseIf fInicio.Day = 26 Then

                    '    Else
                    '        diasTotales = diasTotales + 1
                    '    End If
                    'Else
                    diasTotales = diasTotales + 1
                    '    End If
                End If
            End If
            If DateAdd(DateInterval.Day, index, fInicio).DayOfWeek = 0 Then
                'No cuenta el dia
            ElseIf DateAdd(DateInterval.Day, index, fInicio).DayOfWeek = 6 Then
                'If DateAdd(DateInterval.Day, index, fInicio).Month = 3 Then
                '    If DateAdd(DateInterval.Day, index, fInicio).Day = 21 Then
                '    ElseIf DateAdd(DateInterval.Day, index, fInicio).Day = 22 Then
                '    ElseIf DateAdd(DateInterval.Day, index, fInicio).Day = 23 Then
                '    ElseIf DateAdd(DateInterval.Day, index, fInicio).Day = 24 Then
                '    ElseIf DateAdd(DateInterval.Day, index, fInicio).Day = 25 Then
                '    ElseIf DateAdd(DateInterval.Day, index, fInicio).Day = 26 Then
                '    Else
                '        diasTotales = diasTotales + 0.5
                '    End If
                'Else
                diasTotales = diasTotales + 0.5
                'End If

            Else
                'If DateAdd(DateInterval.Day, index, fInicio).Month = 3 Then
                '    If DateAdd(DateInterval.Day, index, fInicio).Day = 21 Then
                '    ElseIf DateAdd(DateInterval.Day, index, fInicio).Day = 22 Then
                '    ElseIf DateAdd(DateInterval.Day, index, fInicio).Day = 23 Then
                '    ElseIf DateAdd(DateInterval.Day, index, fInicio).Day = 24 Then
                '    ElseIf DateAdd(DateInterval.Day, index, fInicio).Day = 25 Then
                '    ElseIf DateAdd(DateInterval.Day, index, fInicio).Day = 26 Then
                '    Else
                'diasTotales = diasTotales + 1
                '    End If
                'Else
                diasTotales = diasTotales + 1
                'End If

            End If
        Next
        If dias = 0 Then
            diasTotales = 1
        End If
        Return diasTotales
    End Function

End Class