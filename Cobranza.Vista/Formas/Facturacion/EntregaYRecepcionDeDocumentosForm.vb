Imports System.Drawing
Imports System.Windows.Forms
Imports DevExpress
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraPrinting
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Tools

Public Class EntregaYRecepcionDeDocumentosForm

#Region "Variables"
    Dim objBu As New Negocios.FacturacionBU
    Private permisoQuitarEntrega As Boolean = False
    Private permisoQuitarRecibido As Boolean = False
    'Permiso que permite a un usuario de cobranza marcar como entregado
    Private permisoEntregar As Boolean = False
    Private WithEvents cmTipoComprobante As New ContextMenuStrip
    Private WithEvents cmMotivosNoEntrega As New ContextMenuStrip
    Private cmbOpcionesTipoComprobante As RepositoryItemLookUpEdit
    Private WithEvents cmbOpcionesMotivosNoEntrega As RepositoryItemLookUpEdit
    Private WithEvents repositorioChkEntregado As New RepositoryItemCheckEdit
    Private WithEvents repositorioChkRecibido As New RepositoryItemCheckEdit
#End Region
    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub EntregaYRecepcionDeDocumentosForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Top = 0
        Me.Left = 0
        Me.Location = New Point(0, 0)
        Me.WindowState = 2

        dtpFechaInicio.Value = DateTime.Now
        dtpFechaFin.Value = DateTime.Now

        ConsultarTipoComprobantes()
        ConsultarMotivosNoEntrega()

        Tools.Utilerias.ComboObtenerCEDISUsuario(cboCedis)

        grdDatos.OptionsSelection.MultiSelect = True

        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("CBZ_FACTURACION_RECEPCION_DOC", "READ") Then
            If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("FACT_ENTREGA_DOC", "READ") Then
                permisoEntregar = True
            End If
            grpFiltrosRecibidos.Visible = True
            chkPendientesPorRecibir.Checked = True
        Else
            grpFiltrosRecibidos.Visible = False
            chkPendientesPorEntregar.Checked = True
        End If

        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("FACT_ENTREGA_DOC", "FACT_ENTREGA_DOC_MARCAR_ENTREGADO") Then
            permisoQuitarEntrega = True
        End If

        'Permiso de jefatura
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("CBZ_FACTURACION_RECEPCION_DOC", "CBZ_FACTURACION_DERMARCAR_DOCUMENTOS_RECIBIDOS") Then
            permisoQuitarRecibido = True
        End If


        'RemoveHandler repositorioCheckBox.EditValueChanged, AddressOf MarcarSeleccionado
        'RemoveHandler repositorioCheckBox.EditValueChanged, AddressOf MarcarMotivoNoEntrega

    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        OcultarFiltros()
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        MostrarFiltros()
    End Sub

    Private Sub btnFiltroCliente_Click(sender As Object, e As EventArgs)
        AbrirBusquedaFiltroCliente()
    End Sub

    Private Sub grdDatos_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs) Handles grdDatos.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub


    Private Sub AbrirBusquedaFiltroCliente()
        Dim listado As New ListadoParametrosProyeccionEntregasForm
        listado.tipo_busqueda = 1

        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In grdFiltroCliente.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next

        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)

        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        grdFiltroCliente.DataSource = listado.listParametros
        With grdFiltroCliente
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
            .DisplayLayout.Bands(0).Columns(3).Hidden = True
            .DisplayLayout.Bands(0).Columns(4).Hidden = True
            .DisplayLayout.Bands(0).Columns(5).Hidden = True

            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Cliente"
        End With

        grdFiltroCliente.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        Try
            MostrarDatos()
        Catch ex As Exception
            show_message("Error", "Hubo un error al generar los datos para mostrar, intente de nuevo" + ex.Message)
            Cursor = Cursors.Default
            Exit Sub
        End Try

    End Sub

    Private Sub MostrarDatos()
        Dim fechaInicio As DateTime
        Dim fechaFin As DateTime
        Dim usuarioConsultaId As Int32
        Dim permiso As Int32
        Dim entregados As Int32
        Dim recibidos As Int32
        Dim filtroCliente As String = String.Empty
        Dim datos As New DataTable
        Dim cedis As Integer


        cedis = cboCedis.SelectedValue

        grdContenedor.DataSource = Nothing

        fechaInicio = dtpFechaInicio.Value
        fechaFin = dtpFechaFin.Value
        usuarioConsultaId = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid

        If chkRecibidos.Checked And chkPendientesPorRecibir.Checked = False Then
            recibidos = 1
        ElseIf chkPendientesPorRecibir.Checked And chkRecibidos.Checked = False Then
            recibidos = 0
        Else
            recibidos = 2
        End If

        If chkEntregados.Checked And chkPendientesPorEntregar.Checked = False Then
            entregados = 1
        ElseIf chkPendientesPorEntregar.Checked And chkEntregados.Checked = False Then
            entregados = 0
        Else
            entregados = 2
        End If

        For Each row As UltraGridRow In grdFiltroCliente.Rows
            If row.Index = 0 Then
                filtroCliente += " " + Replace(row.Cells(0).Text, ",", "")
            Else
                filtroCliente += ", " + Replace(row.Cells(0).Text, ",", "")
            End If
        Next


        Cursor = Cursors.WaitCursor
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("CBZ_FACTURACION_RECEPCION_DOC", "READ") Then

            If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("CBZ_FACTURACION_RECEPCION_DOC", "CBZ_FACTURACION_FACTURAS_RECIBIDAS_USUARIO") Then
                permiso = 1
            ElseIf Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("CBZ_FACTURACION_RECEPCION_DOC", "CBZ_FACTURACION_VER_TODAS_FACTURAS_RECIBIDAS") Then
                permiso = 2
            Else
                permiso = 3
            End If

            datos = objBu.ConsultarDocumentosCobranza(fechaInicio, fechaFin, usuarioConsultaId, permiso, entregados, recibidos, filtroCliente, cedis)

        ElseIf Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("FACT_ENTREGA_DOC", "READ") Then

            If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("FACT_ENTREGA_DOC", "FACT_ENTREGA_DOC_SOLO_FACTURAS_USUARIOS") Then
                permiso = 1
            ElseIf Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("FACT_ENTREGA_DOC", "FACT_ENTREGA_DOC_TODAS_FACTURAS") Then
                permiso = 2
            Else
                permiso = 3
            End If

            datos = objBu.ConsultarDocumentos(fechaInicio, fechaFin, usuarioConsultaId, permiso, entregados, filtroCliente, cedis)
        End If

        If datos.Rows.Count > 0 Then
            Dim v As DataView = datos.DefaultView
            v.Sort = "FechaDocumento"
            grdContenedor.DataSource = datos
            AgregarComboBoxGrid()
            DisenioGrid()
            OcultarFiltros()
        End If

        Cursor = Cursors.Default

        lblRegistros.Text = CDbl(grdDatos.RowCount).ToString("N0")
    End Sub

    Private Sub RegistrarDocumento(fila As Integer)
        Dim documentoId As Integer
        Dim remision As Integer
        Dim anio As Integer
        Dim tipoComprobante As Integer
        Dim motivoNoEntrega As Integer
        Dim usuarioCaptura As Integer
        Dim filaTablaTipoComprobantes As DataRowView
        Dim resultado As DataTable
        Dim fechaResultado As DateTime

        Try
            documentoId = Integer.Parse(grdDatos.GetRowCellValue(fila, "Documento").ToString)
            remision = Integer.Parse(grdDatos.GetRowCellValue(fila, "Remision").ToString)
            anio = Integer.Parse(grdDatos.GetRowCellValue(fila, "AñoRemision").ToString)
            filaTablaTipoComprobantes = cmbOpcionesTipoComprobante.GetDataSourceRowByDisplayValue(grdDatos.GetRowCellValue(fila, "TipoComprobante"))
            tipoComprobante = Integer.Parse(filaTablaTipoComprobantes("ID").ToString)
            'filaTablaTipoComprobantes = cmbOpcionesMotivosNoEntrega.GetDataSourceRowByDisplayValue(grdDatos.GetRowCellValue(fila, "MotivoNoEntrega"))
            'motivoNoEntrega = Integer.Parse(filaTablaTipoComprobantes("ID").ToString)

            usuarioCaptura = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid

            resultado = objBu.RegistrarEntregadoDocumento(documentoId, tipoComprobante, motivoNoEntrega, usuarioCaptura)
            objBu.RegistrarEntregadoDocumento_SICY(remision, anio, filaTablaTipoComprobantes("Descripcion").ToString, "", Entidades.SesionUsuario.UsuarioSesion.PUserUsername)

            If resultado.Rows.Count > 0 Then
                fechaResultado = Date.Parse(resultado.Rows(0)("Resultado").ToString)
                grdDatos.SetRowCellValue(fila, "FechaEntregado", fechaResultado)
                grdDatos.SetRowCellValue(fila, "UsuarioEntrega", Entidades.SesionUsuario.UsuarioSesion.PUserUsername)
                grdDatos.SetRowCellValue(fila, "MotivoNoEntrega", "")
            End If

            'MsgBox(documentoId.ToString)
        Catch ex As Exception
            show_message("Error", "Hubo un error al generar la solicitud, intente de nuevo" + ex.Message)
            Cursor = Cursors.Default
            Exit Sub
        End Try

    End Sub

    Private Sub CancelarDocumento(fila As Integer)
        Dim documentoId As Integer
        Dim usuarioCaptura As Integer
        Dim resultado As DataTable
        Dim mensaje As String

        Try
            documentoId = Integer.Parse(grdDatos.GetRowCellValue(fila, "Documento").ToString)
            usuarioCaptura = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid

            resultado = objBu.CancelarEntregadoDocumento(documentoId, usuarioCaptura)

            If resultado.Rows.Count > 0 Then
                mensaje = resultado.Rows(0)("Mensaje").ToString
                If Not String.IsNullOrEmpty(mensaje) Then
                    show_message("Aviso", mensaje)
                End If
            End If

            'MsgBox(documentoId.ToString)
        Catch ex As Exception
            show_message("Error", "Hubo un error al generar la solicitud, intente de nuevo" + ex.Message)
            Cursor = Cursors.Default
            Exit Sub
        End Try
    End Sub

    Private Sub CancelarDocumento_Cobranza(fila As Integer)
        Dim documentoId As Integer
        Dim usuarioCaptura As Integer
        Dim resultado As DataTable
        Dim mensaje As String

        Try
            documentoId = Integer.Parse(grdDatos.GetRowCellValue(fila, "Documento").ToString)
            usuarioCaptura = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid

            resultado = objBu.CancelarEntregadoDocumento_Cobranza(documentoId, usuarioCaptura)

            If resultado.Rows.Count > 0 Then
                mensaje = resultado.Rows(0)("Mensaje").ToString
                If Not mensaje.Equals("Correcto") Then
                    show_message("Advertencia", mensaje)
                End If
            End If

            'MsgBox(documentoId.ToString)
        Catch ex As Exception
            show_message("Error", "Hubo un error al generar la solicitud, intente de nuevo" + ex.Message)
            Cursor = Cursors.Default
            Exit Sub
        End Try
    End Sub

    Private Sub RegistrarDocumentoConMotivo(fila As Integer, motivo As String)
        Dim documentoId As Integer
        Dim remision As Integer
        Dim anio As Integer
        Dim tipoComprobante As Integer
        Dim motivoNoEntrega As Integer
        Dim motivoNoEntregaDescripcion As String
        Dim usuarioCaptura As Integer
        Dim filaTablaTipoComprobantes As DataRowView
        Dim resultado As DataTable
        Dim fechaResultado As DateTime

        Try
            documentoId = Integer.Parse(grdDatos.GetRowCellValue(fila, "Documento").ToString)
            remision = Integer.Parse(grdDatos.GetRowCellValue(fila, "Remision").ToString)
            anio = Integer.Parse(grdDatos.GetRowCellValue(fila, "AñoRemision").ToString)
            filaTablaTipoComprobantes = cmbOpcionesMotivosNoEntrega.GetDataSourceRowByDisplayValue(motivo)
            motivoNoEntrega = Integer.Parse(filaTablaTipoComprobantes("ID").ToString)
            motivoNoEntregaDescripcion = filaTablaTipoComprobantes("Descripcion").ToString

            usuarioCaptura = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid

            resultado = objBu.RegistrarEntregadoDocumento(documentoId, tipoComprobante, motivoNoEntrega, usuarioCaptura)
            objBu.RegistrarEntregadoDocumento_SICY(remision, anio, tipoComprobante, motivoNoEntregaDescripcion, Entidades.SesionUsuario.UsuarioSesion.PUserUsername)

            If resultado.Rows.Count > 0 Then
                fechaResultado = Date.Parse(resultado.Rows(0)("Resultado").ToString)
                grdDatos.SetRowCellValue(fila, "FechaEntregado", fechaResultado)
            End If

            'MsgBox(documentoId.ToString)
        Catch ex As Exception
            show_message("Error", "Hubo un error al generar la solicitud, intente de nuevo" + ex.Message)
            Cursor = Cursors.Default
            Exit Sub
        End Try


    End Sub

    Private Sub RegistrarRecibidoDocumento(fila As Integer)
        Dim documentoId As Integer
        Dim usuarioCaptura As Integer
        Dim filaTablaTipoComprobantes As DataRowView
        Dim resultado As DataTable
        Dim fechaResultado As DateTime

        Try
            documentoId = Integer.Parse(grdDatos.GetRowCellValue(fila, "Documento").ToString)
            filaTablaTipoComprobantes = cmbOpcionesTipoComprobante.GetDataSourceRowByDisplayValue(grdDatos.GetRowCellValue(fila, "TipoComprobante"))
            'filaTablaTipoComprobantes = cmbOpcionesMotivosNoEntrega.GetDataSourceRowByDisplayValue(grdDatos.GetRowCellValue(fila, "MotivoNoEntrega"))
            'motivoNoEntrega = Integer.Parse(filaTablaTipoComprobantes("ID").ToString)

            usuarioCaptura = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid

            resultado = objBu.RegistrarRecibidoDocumento(documentoId, usuarioCaptura)

            If resultado.Rows.Count > 0 Then
                fechaResultado = Date.Parse(resultado.Rows(0)("Resultado").ToString)
                grdDatos.SetRowCellValue(fila, "FechaRecibido", fechaResultado)
                grdDatos.SetRowCellValue(fila, "UsuarioRecibe", Entidades.SesionUsuario.UsuarioSesion.PUserUsername)
                grdDatos.SetRowCellValue(fila, "Recibido", True)
            End If

            'MsgBox(documentoId.ToString)
        Catch ex As Exception
            show_message("Error", "Hubo un error al generar la solicitud, intente de nuevo" + ex.Message)
            Cursor = Cursors.Default
            Exit Sub
        End Try

    End Sub
#Region "Grid Busqueda Cliente"
    Private Sub grid_diseño(grid As UltraGrid)
        With grid.DisplayLayout
            .Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            .Override.RowSelectorWidth = 15
            .Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
            '.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
            .AutoFitStyle = AutoFitStyle.ResizeAllColumns
            .Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
            .Override.CellClickAction = CellClickAction.RowSelect
            .Override.AllowAddNew = AllowAddNew.No
        End With

        For Each row In grid.Rows
            row.Activation = Activation.NoEdit
        Next

        asignaFormato_Columna(grid)

    End Sub

    Public Sub asignaFormato_Columna(ByVal grid As Infragistics.Win.UltraWinGrid.UltraGrid)

        For Each col In grid.DisplayLayout.Bands(0).Columns

            If col.DataType.Name.ToString.Equals("Int32") Or col.DataType.Name.ToString.Equals("Int16") Then

                col.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Integer
                col.CellAppearance.TextHAlign = HAlign.Right

            End If

            If col.DataType.Name.ToString.Equals("Decimal") Then

                col.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DoublePositive
                col.CellAppearance.TextHAlign = HAlign.Right

            End If

            If col.DataType.Name.ToString.Equals("String") Then

                If col.Header.Caption.Equals("Télefono") Then
                    col.MaskInput = "+## (###) ###-####"
                    col.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeBoth
                    col.CellAppearance.TextHAlign = HAlign.Right
                ElseIf col.Header.Caption.Equals("Extensión") Then
                    col.MaskInput = "ext: 9999"
                    col.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeBoth
                    col.CellAppearance.TextHAlign = HAlign.Right
                Else
                    col.CellAppearance.TextHAlign = HAlign.Left
                End If

            End If

        Next
    End Sub

#End Region
    Private Sub AgregarComboBoxGrid()
        grdDatos.Columns("TipoComprobante").ColumnEdit = cmbOpcionesTipoComprobante
        grdDatos.Columns("MotivoNoEntrega").ColumnEdit = cmbOpcionesMotivosNoEntrega
        cmbOpcionesTipoComprobante.TextEditStyle = TextEditStyles.DisableTextEditor
        cmbOpcionesMotivosNoEntrega.TextEditStyle = TextEditStyles.DisableTextEditor

    End Sub

    Private Sub ConsultarTipoComprobantes()
        Dim cmbOpciones As New RepositoryItemLookUpEdit()
        Dim tiposComprobante As New DataTable
        tiposComprobante = objBu.ConsultarCatalogoTipoComprobante()
        Dim filaVacia As DataRow = tiposComprobante.NewRow
        filaVacia("ID") = 0
        filaVacia("Descripcion") = ""
        tiposComprobante.Rows.InsertAt(filaVacia, 0)

        cmbOpciones.DataSource = tiposComprobante
        cmbOpciones.ValueMember = "Descripcion"
        cmbOpciones.DisplayMember = "Descripcion"
        cmbOpciones.PopulateColumns()
        cmbOpciones.Columns("ID").Visible = False
        cmbOpciones.AllowNullInput = True

        cmbOpcionesTipoComprobante = cmbOpciones
    End Sub

    Private Sub ConsultarMotivosNoEntrega()
        Dim cmbOpciones As New RepositoryItemLookUpEdit()
        Dim motivosNoEntrega As New DataTable
        motivosNoEntrega = objBu.ConsultarCatalogoMotivosNoEntrega()
        Dim filaVacia As DataRow = motivosNoEntrega.NewRow
        filaVacia("ID") = 0
        filaVacia("Descripcion") = ""
        motivosNoEntrega.Rows.InsertAt(filaVacia, 0)

        cmbOpciones.DataSource = motivosNoEntrega
        cmbOpciones.ValueMember = "Descripcion"
        cmbOpciones.DisplayMember = "Descripcion"
        cmbOpciones.PopulateColumns()
        cmbOpciones.Columns("ID").Visible = False
        cmbOpciones.AllowNullInput = True

        cmbOpcionesMotivosNoEntrega = cmbOpciones
    End Sub

#Region "Acciones Botones Arriba Abajo"
    Private Sub OcultarFiltros()
        pnlFiltros.Height = 0
    End Sub

    Private Sub MostrarFiltros()
        pnlFiltros.Height = 159
    End Sub
#End Region
#Region "Diseño Grid"
    Private Sub DisenioGrid()

        DiseñoGrid.DiseñoBaseGridSinBestFit(grdDatos)

        For i = 0 To grdDatos.Columns.Count - 1
            grdDatos.Columns(i).OptionsColumn.AllowEdit = False
        Next

        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("CBZ_FACTURACION_RECEPCION_DOC", "READ") Then
            grdDatos.Columns("Recibido").OptionsColumn.AllowEdit = True
            grdDatos.Columns("Recibido").ColumnEdit = repositorioChkRecibido
            If permisoEntregar Then
                grdDatos.Columns("TipoComprobante").OptionsColumn.AllowEdit = True
                grdDatos.Columns("Entregado").OptionsColumn.AllowEdit = True
                grdDatos.Columns("MotivoNoEntrega").OptionsColumn.AllowEdit = True
            End If
        Else
            grdDatos.Columns("TipoComprobante").OptionsColumn.AllowEdit = True
            grdDatos.Columns("Entregado").OptionsColumn.AllowEdit = True
            grdDatos.Columns("MotivoNoEntrega").OptionsColumn.AllowEdit = True
        End If
        grdDatos.Columns("Documento").Visible = False

        grdDatos.Columns("FechaDocumento").Width = 95
        grdDatos.Columns("TipoComprobante").Width = 105
        grdDatos.Columns("TipoEmpaque").Width = 105

        grdDatos.Columns("Cliente").OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains

        grdDatos.Columns("Pares").DisplayFormat.FormatType = Utils.FormatType.Numeric
        grdDatos.Columns("Pares").DisplayFormat.FormatString = "###,###"
        grdDatos.Columns("Total").DisplayFormat.FormatType = Utils.FormatType.Numeric
        grdDatos.Columns("Total").DisplayFormat.FormatString = "C"

        grdDatos.Columns("Transporte").Visible = False
        grdDatos.Columns("TipoEmpaque").Caption = "Tipo" + vbCrLf + "Empaque"
        grdDatos.Columns("AñoRemision").Caption = "Año" + vbCrLf + "Remisión"
        grdDatos.Columns("TipoComprobante").Caption = "Tipo" + vbCrLf + "Comprobante"
        grdDatos.Columns("UsuarioEntrega").Caption = "Usuario" + vbCrLf + "Entrega"
        grdDatos.Columns("MotivoNoEntrega").Caption = "Motivo" + vbCrLf + "No Entrega"
        grdDatos.Columns("FechaDocumento").Caption = "F Documento"
        grdDatos.Columns("FechaEntregado").Caption = "F Entrega"
        grdDatos.Columns("UsuarioCaptura").Caption = "Captura"
        grdDatos.Columns("Cliente").Width = 200

        'DiseñoGrid.PropiedadesGrid(grdDatos, False, Utils.HorzAlignment.Center, True)


        'grdDatos.BestFitColumns()

        grdDatos.Columns("Entregado").ColumnEdit = repositorioChkEntregado

    End Sub
#End Region

    Private Sub SeleccionarEntregadoVariasFilas(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles grdDatos.KeyPress
        Dim isChecked As Boolean

        If Convert.ToInt32(e.KeyChar) = Convert.ToInt32(Keys.Enter) Then
            If grdDatos.GetSelectedRows.Count > 0 Then
                If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("FACT_ENTREGA_DOC", "READ") Then
                    Dim filas() = grdDatos.GetSelectedRows
                    If ValidarTieneTipoComprobante(filas) Then
                        If show_message("Confirmar", "¿Confirmar entrega de documentos?" + vbNewLine + "Esta acción no se puede deshacer") = DialogResult.OK Then
                            Cursor = Cursors.WaitCursor
                            For fila = 0 To filas.Count - 1
                                isChecked = Boolean.Parse(grdDatos.GetRowCellValue(filas(fila), "Entregado").ToString)
                                If Not isChecked Then
                                    RegistrarDocumento(filas(fila))
                                    grdDatos.SetRowCellValue(filas(fila), "Entregado", True)
                                End If
                            Next
                            Cursor = Cursors.WaitCursor

                        End If
                    Else
                        show_message("Advertencia", "Los registros deben de tener un tipo de comprobante seleccionado")
                    End If
                ElseIf Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("CBZ_FACTURACION_RECEPCION_DOC", "READ") Then
                    Dim filas() = grdDatos.GetSelectedRows
                    If ValidarEstaEntregado(filas) Then
                        If show_message("Confirmar", "¿Confirmar recepción de documentos?" + vbNewLine + "Esta acción no se puede deshacer") = DialogResult.OK Then
                            Cursor = Cursors.WaitCursor
                            For fila = 0 To filas.Count - 1
                                isChecked = Boolean.Parse(grdDatos.GetRowCellValue(filas(fila), "Entregado").ToString)
                                If isChecked Then
                                    RegistrarRecibidoDocumento(filas(fila))
                                End If
                            Next
                            Cursor = Cursors.WaitCursor

                        End If
                    Else
                        show_message("Advertencia", "Los registros deben de estar entregados por facturación")
                    End If
                End If
            End If
        End If

    End Sub


    'Este metodo se ejecuta cada que se selecciona el checkbox Entregado de un registro
    Private Sub MarcarSeleccionado(ByVal sender As Object, ByVal e As EventArgs) Handles repositorioChkEntregado.EditValueChanged
        Dim fila = grdDatos.FocusedRowHandle
        Dim estadoAnterior As Boolean
        Dim estadoEntregado As Boolean

        If fila >= 0 Then
            estadoEntregado = Boolean.Parse(grdDatos.GetRowCellValue(fila, "Entregado").ToString)
            If Not estadoEntregado Then
                If Not String.IsNullOrEmpty(grdDatos.GetRowCellValue(fila, "TipoComprobante")) Then
                    If show_message("Confirmar", "¿Confirmar entrega de documento?" + vbNewLine + "Esta acción no se puede deshacer") = DialogResult.OK Then
                        grdDatos.SetRowCellValue(fila, "Entregado", True)
                        'grdDatos.SetRowCellValue(fila, "MotivoNoEntrega", "")

                        Cursor = Cursors.WaitCursor
                        RegistrarDocumento(fila)
                        Cursor = Cursors.Default

                        grdDatos.MoveNext()
                    Else
                        estadoAnterior = Boolean.Parse(grdDatos.GetRowCellValue(fila, "Entregado"))
                        grdDatos.SetRowCellValue(fila, "Entregado", estadoAnterior)
                    End If

                Else
                    show_message("Advertencia", "Los registros deben de tener un tipo de comprobante seleccionado")
                    grdDatos.SetRowCellValue(fila, "Entregado", False)
                End If
            Else
                If show_message("Confirmar", "¿Desmarcar este documento?") = DialogResult.OK Then
                    CancelarDocumento(fila)
                    MostrarDatos()
                Else
                    grdDatos.SetRowCellValue(fila, "Entregado", estadoEntregado)
                End If
            End If

        End If

    End Sub

    Private Sub MarcarSeleccionadoRecibido(ByVal sender As Object, ByVal e As EventArgs) Handles repositorioChkRecibido.EditValueChanged
        Dim fila = grdDatos.FocusedRowHandle
        Dim estadoAnterior As Boolean
        Dim estadoRecibido As Boolean

        If fila >= 0 Then
            estadoRecibido = Boolean.Parse(grdDatos.GetRowCellValue(fila, "Recibido").ToString)
            If Not estadoRecibido Then
                If Boolean.Parse(grdDatos.GetRowCellValue(fila, "Entregado")) Then
                    If show_message("Confirmar", "¿Confirmar entrega de documento?" + vbNewLine + "Esta acción no se puede deshacer") = DialogResult.OK Then
                        'grdDatos.SetRowCellValue(fila, "Entregado", True)
                        'grdDatos.SetRowCellValue(fila, "MotivoNoEntrega", "")

                        Cursor = Cursors.WaitCursor
                        RegistrarRecibidoDocumento(fila)
                        Cursor = Cursors.Default

                        grdDatos.MoveNext()
                    Else
                        estadoAnterior = Boolean.Parse(grdDatos.GetRowCellValue(fila, "Recibido"))
                        grdDatos.SetRowCellValue(fila, "Recibido", estadoAnterior)
                    End If

                Else
                    show_message("Advertencia", "Los registros deben de ser entregados anteriormente por facturación.")
                    grdDatos.SetRowCellValue(fila, "Recibido", False)
                End If

            Else
                If show_message("Confirmar", "¿Desmarcar este documento?") = DialogResult.OK Then
                    CancelarDocumento_Cobranza(fila)
                    MostrarDatos()
                Else
                    grdDatos.SetRowCellValue(fila, "Recibido", estadoRecibido)
                End If
            End If

        End If

    End Sub

    Private Sub MarcarMotivoNoEntrega(ByVal sender As Object, ByVal e As EventArgs) Handles cmbOpcionesMotivosNoEntrega.EditValueChanged
        Dim fila = grdDatos.FocusedRowHandle
        Dim textEditor As TextEdit = CType(sender, TextEdit)

        If fila >= 0 Then
            If String.IsNullOrEmpty(grdDatos.GetRowCellValue(fila, "MotivoNoEntrega")) Then
                If show_message("Confirmar", "¿Confirmar motivo de no entrega del documento?" + vbNewLine + "Esta acción no se puede deshacer") = DialogResult.OK Then
                    Cursor = Cursors.WaitCursor
                    RegistrarDocumentoConMotivo(fila, textEditor.EditValue.ToString)
                    MostrarDatos()
                    Cursor = Cursors.Default

                    grdDatos.SetRowCellValue(fila, "TipoComprobante", "")
                Else
                    grdDatos.SetRowCellValue(fila, "MotivoNoEntrega", "")

                End If

            End If
        End If

    End Sub

    Private Sub BloquearEntregado(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles grdDatos.ShowingEditor
        Dim gridView As GridView = sender
        Dim focusRow = grdDatos.GetFocusedDataRow()
        Dim isChecked As Boolean
        Dim tipoCmprobante As String
        If (Not focusRow Is Nothing) Then
            isChecked = Boolean.Parse(focusRow("Entregado").ToString())
            If isChecked AndAlso Not String.IsNullOrEmpty(focusRow("TipoComprobante").ToString) Then
                If permisoQuitarEntrega Then
                    e.Cancel = False
                Else
                    e.Cancel = True
                End If
            Else
                If permisoEntregar Then
                    e.Cancel = False
                End If
            End If

            tipoCmprobante = focusRow("TipoComprobante").ToString
            If Not (grdDatos.Columns("Recibido") Is Nothing) Then
                isChecked = Boolean.Parse(focusRow("Recibido").ToString())
                If isChecked Then
                    If permisoQuitarRecibido = True And tipoCmprobante.Equals("GUÍA") Then
                        e.Cancel = False
                    Else
                        e.Cancel = True
                    End If

                Else
                    e.Cancel = False
                End If
            End If
            'isChecked = Boolean.Parse(focusRow("Recibido").ToString())
            'If isChecked Then
            '    e.Cancel = True
            'End If
        End If
    End Sub

    Private Function ValidarTieneTipoComprobante(filas() As Integer) As Boolean
        Dim tieneTipoComprobante As Boolean = False

        For i = 0 To filas.Count - 1
            If Not String.IsNullOrEmpty(grdDatos.GetRowCellValue(filas(i), "TipoComprobante")) Then
                tieneTipoComprobante = True
            Else
                tieneTipoComprobante = False
                Exit For
            End If
        Next

        Return tieneTipoComprobante
    End Function

    Private Function ValidarEstaEntregado(filas() As Integer) As Boolean
        Dim estaEntregado As Boolean = False

        For i = 0 To filas.Count - 1
            If Boolean.Parse(grdDatos.GetRowCellValue(filas(i), "Entregado").ToString) Then
                estaEntregado = True
            Else
                estaEntregado = False
                Exit For
            End If
        Next

        Return estaEntregado
    End Function
#Region "Mensajes"
    Public Function show_message(ByVal tipo As String, ByVal mensaje As String) As DialogResult
        Dim result As DialogResult

        If tipo.ToString.Equals("Advertencia") Then

            Dim mensajeAdvertencia As New AdvertenciaForm
            mensajeAdvertencia.mensaje = mensaje
            mensajeAdvertencia.ShowDialog()

        End If

        If tipo.ToString.Equals("AdvertenciaGrande") Then

            Dim mensajeAdvertencia As New AdvertenciaFormGrande
            mensajeAdvertencia.mensaje = mensaje
            mensajeAdvertencia.ShowDialog()

        End If

        If tipo.ToString.Equals("Aviso") Then

            Dim mensajeAviso As New AvisoForm
            mensajeAviso.mensaje = mensaje
            mensajeAviso.ShowDialog()

        End If

        If tipo.ToString.Equals("Error") Then

            Dim mensajeError As New ErroresForm
            mensajeError.mensaje = mensaje
            mensajeError.ShowDialog()

        End If

        If tipo.ToString.Equals("Exito") Then

            Dim mensajeExito As New ExitoForm
            mensajeExito.mensaje = mensaje
            mensajeExito.ShowDialog()

        End If

        If tipo.ToString.Equals("Confirmar") Then
            Dim mensajeExito As New ConfirmarForm
            mensajeExito.mensaje = mensaje

            result = mensajeExito.ShowDialog()
        End If

        Return result
    End Function
#End Region

    Private Sub grdDatos_MouseDown(sender As Object, e As MouseEventArgs) Handles grdContenedor.MouseDown
        If e.Button = MouseButtons.Right Then
            If grdDatos.GetSelectedRows.Count > 1 Then
                Dim hitInfo = grdDatos.CalcHitInfo(e.Location)
                If (hitInfo.InRowCell) Then
                    Dim column = hitInfo.Column
                    MarcarVarios(e, column)
                End If
            End If
        End If
    End Sub

    Private Sub MarcarVarios(e As MouseEventArgs, ByRef column As DevExpress.XtraGrid.Columns.GridColumn)
        If column.Name.Equals("colMotivoNoEntrega") Then
            MostrarOpcionesMotivosNoEntrega(e)
        Else
            MostrarOpcionesTipoComprobante(e)
        End If
    End Sub

    Private Sub MostrarOpcionesTipoComprobante(e As MouseEventArgs)
        Dim tiposComprobantes = cmbOpcionesTipoComprobante
        Dim dataTiposComprobantes As DataTable = tiposComprobantes.DataSource
        cmTipoComprobante.Items.Clear()
        cmTipoComprobante.Items.Insert(0, New ToolStripLabel("Seleccionar como:"))
        For i = 0 To dataTiposComprobantes.Rows.Count - 1
            cmTipoComprobante.Items.Add(dataTiposComprobantes.Rows(i).Item("Descripcion"))
        Next
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("FACT_ENTREGA_DOC", "READ") Then
            cmTipoComprobante.Show(Me, New Point(e.X, e.Y))
        End If
    End Sub

    Private Sub MostrarOpcionesMotivosNoEntrega(e As MouseEventArgs)
        Dim motivosNoEntrega = cmbOpcionesMotivosNoEntrega
        Dim datosMotivosNoEntrega As DataTable = motivosNoEntrega.DataSource
        cmMotivosNoEntrega.Items.Clear()
        cmMotivosNoEntrega.Items.Insert(0, New ToolStripLabel("Seleccionar como:"))
        For i = 0 To datosMotivosNoEntrega.Rows.Count - 1
            cmMotivosNoEntrega.Items.Add(datosMotivosNoEntrega.Rows(i).Item("Descripcion"))
        Next
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("FACT_ENTREGA_DOC", "READ") Then
            cmMotivosNoEntrega.Show(Me, New Point(e.X, e.Y))
        End If
    End Sub

    Private Sub SeleccionarTipoComprobanteFilasMarcadas(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles cmTipoComprobante.ItemClicked
        Dim rows() As Integer = grdDatos.GetSelectedRows()
        Dim dialogoMostrado As Boolean = False
        Dim checked As Boolean
        For Each row In rows
            checked = Boolean.Parse(grdDatos.GetRowCellValue(row, "Entregado").ToString)
            If Not checked Then
                grdDatos.SetRowCellValue(row, "TipoComprobante", e.ClickedItem.Text)
            Else
                If dialogoMostrado = False Then
                    show_message("Advertencia", "Algunos documentos ya fueron entregados")
                End If
                dialogoMostrado = True

            End If

        Next

    End Sub

    Private Sub SeleccionarMotivoNoEntregaFilasMarcadas(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles cmMotivosNoEntrega.ItemClicked
        Dim rows() As Integer = grdDatos.GetSelectedRows()
        Dim dialogoMostrado As Boolean = False

        If show_message("Confirmar", "¿Confirmar motivo de no entrega del documentos? Esta acción no se puede deshacer") = DialogResult.OK Then
            For Each row In rows
                If Boolean.Parse(grdDatos.GetRowCellValue(row, "Entregado")) = False Then
                    If String.IsNullOrEmpty(grdDatos.GetRowCellValue(row, "MotivoNoEntrega")) Then
                        grdDatos.SetRowCellValue(row, "MotivoNoEntrega", e.ClickedItem.ToString)
                        grdDatos.SetRowCellValue(row, "TipoComprobante", "")
                        RegistrarDocumentoConMotivo(row, e.ClickedItem.ToString)
                    End If
                Else
                    If dialogoMostrado = False Then
                        show_message("Advertencia", "Algunos documentos ya fueron entregados")
                    End If
                    dialogoMostrado = True
                End If
            Next
        End If

    End Sub

    Private Sub btnFiltroCliente_Click_1(sender As Object, e As EventArgs) Handles btnFiltroCliente.Click
        AbrirBusquedaFiltroCliente()
    End Sub

    Private Sub dtpFechaInicio_ValueChanged(sender As Object, e As EventArgs) Handles dtpFechaInicio.ValueChanged
        If dtpFechaFin.Value < dtpFechaInicio.Value Then
            dtpFechaFin.Value = dtpFechaInicio.Value
        End If
        dtpFechaFin.MinDate = dtpFechaInicio.Value
    End Sub

    Private Sub grdFiltroCliente_KeyDown(sender As Object, e As KeyEventArgs) Handles grdFiltroCliente.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdFiltroCliente.DeleteSelectedRows(False)
    End Sub

    Private Sub grdFiltroCliente_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdFiltroCliente.InitializeLayout
        grid_diseño(grdFiltroCliente)
    End Sub

#Region "Exportar Excel"
    Private Sub btnExportarExcel_Click(sender As Object, e As EventArgs) Handles btnExportarExcel.Click
        Dim fbdUbicacionArchivo As New FolderBrowserDialog

        Try
            If grdDatos.RowCount > 0 Then
                With fbdUbicacionArchivo

                    .Reset()
                    .Description = " Seleccione una carpeta "
                    .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                    .ShowNewFolderButton = True

                    Dim ret As DialogResult = .ShowDialog
                    Dim fecha_hora As String = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString

                    If ret = Windows.Forms.DialogResult.OK Then
                        If grdDatos.GroupCount > 0 Then
                            grdDatos.ExportToXlsx(.SelectedPath + "\Datos_EntregaDocumentos_" + fecha_hora + ".xlsx")
                        Else
                            Dim exportOptions = New XlsxExportOptionsEx()
                            'exportOptions.RawDataMode = False
                            'exportOptions.ExportType = DevExpress.Export.ExportType.DataAware
                            'exportOptions.ApplyFormattingToEntireColumn = DevExpress.Utils.DefaultBoolean.True

                            'exportOptions.AllowConditionalFormatting = DevExpress.Utils.DefaultBoolean.True

                            'exportOptions.ApplyFormattingToEntireColumn = DevExpress.Utils.DefaultBoolean.True
                            'exportOptions.RawDataMode = True

                            'GridView2.OptionsPrint.PrintHorzLines = True
                            'GridView2.ExportToXlsx()

                            'AddHandler exportOptions.RawDataMode=, AddressOf exportOptions_CustomizeCell

                            'AddHandler exportOptions.ApplyFormattingToEntireColumn, AddressOf exportOptions_CustomizeCell


                            grdDatos.ExportToXlsx(.SelectedPath + "\Datos_EntregaDocumentos_" + fecha_hora + ".xlsx", exportOptions)

                        End If

                        show_message("Exito", "Los datos se exportaron correctamente: " & "Datos_EntregaDocumentos_" & fecha_hora.ToString() & ".xlsx")

                        .Dispose()

                        Process.Start(fbdUbicacionArchivo.SelectedPath + "\Datos_EntregaDocumentos_" + fecha_hora + ".xlsx")
                    End If
                End With
            Else
                show_message("Advertencia", "No hay datos para exportar")
            End If
        Catch ex As Exception
            show_message("Error", ex.Message.ToString())
        End Try

    End Sub
#End Region


End Class