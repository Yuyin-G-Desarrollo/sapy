Imports Tools
Imports System.IO
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Views.Grid.GridView
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid
Imports DevExpress.XtraPrinting
Imports DevExpress.XtraReports.UI
Imports DevExpress.XtraReports.ReportGeneration
Imports System.Data.OleDb
Imports System.Data
Imports DevExpress.XtraEditors.Repository

Public Class ConfiguracionEtiquetasForm
    Dim fila_seleccionada As Integer = 0
    Dim emptyEditor As RepositoryItem
    Private Sub ConfiguracionEtiquetasForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Me.WindowState = FormWindowState.Maximized
            CargarEstatusEtiquetas()
            PermisosPerfil()
            PreCargarFiltrosPerfil()
            CargarGridEtiquetaEspecial()
            cargarGridEtiquetaYUYIN()
            cargarGridEtiquetaLengua()
            MostrarFechaActualizado()
            btnAltaEtiquetaClienteColeccion.Enabled = False
            lblAltaEtiquetaClienteColeccion.Enabled = False
        Catch ex As Exception
            show_message("Error", ex.Message.ToString())
        End Try
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub PermisosPerfil()
        btnAutorizarLengua.Visible = False
        lblAutorizarLengua.Visible = False
        btnRechazarLengua.Visible = False
        lblRechazarLengua.Visible = False
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ETIQUETAS_CONF_ESP", "PROG_ETIQUETAS_VENTAS") Then
            btnPorAutorizar.Visible = False
            lblPorAutorizar.Visible = False
            btnAutorizar.Visible = True
            lblAutorizar.Visible = True
            btnRechazo.Visible = True
            lblRechazo.Visible = True
            btnAlta.Visible = False
            lblConfigurarEtiqueta.Visible = False
            btnCatalogoParametros.Visible = False
            lblCatalogosParametros.Visible = False
            btnExportarExcel.Visible = False
            lblExportar.Visible = False
        ElseIf Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ETIQUETAS_CONF_ESP", "PROG_ETIQUETAS_PPCP") Then
            btnPorAutorizar.Visible = True
            lblPorAutorizar.Visible = True
            btnAutorizar.Visible = False
            lblAutorizar.Visible = False
            btnRechazo.Visible = False
            lblRechazo.Visible = False
            btnAlta.Visible = True
            lblConfigurarEtiqueta.Visible = True
            btnCatalogoParametros.Visible = True
            lblCatalogosParametros.Visible = True
            btnExportarExcel.Visible = True
            lblExportar.Visible = True
        Else
            btnPorAutorizar.Visible = False
            lblPorAutorizar.Visible = False
            btnAutorizar.Visible = False
            lblAutorizar.Visible = False
            btnRechazo.Visible = False
            lblRechazo.Visible = False
            btnAlta.Visible = False
            lblConfigurarEtiqueta.Visible = False
            btnCatalogoParametros.Visible = False
            lblCatalogosParametros.Visible = False
            btnVistaPrevia.Visible = False
            lblVistaPrevia.Visible = False
        End If
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ETIQUETAS_CONF_ESP", "PROG_AUTORIZAR_ETIQUETA_LENGUA") Then
            btnRechazarLengua.Visible = True
            btnAutorizarLengua.Visible = True
            lblRechazarLengua.Visible = True
            lblAutorizarLengua.Visible = True
            lblInactivarLengua.Visible = True
            btnInactivarLengua.Visible = True
        End If

        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ETIQUETAS_CONF_ESP", "PROG_AUTORIZAR_ETIQUETA_CLIENTE") Then

        End If

    End Sub

    Private Sub PreCargarFiltrosPerfil()
        Dim EstatusID As String = String.Empty
        For Each Item As Infragistics.Win.ValueListItem In cmbEstatusPedido.Items
            If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ETIQUETAS_CONF_ESP", "PROG_ETIQUETAS_VENTAS") Then
                If Item.DataValue = 173 Then
                    Item.CheckState = CheckState.Checked
                End If
            ElseIf Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ETIQUETAS_CONF_ESP", "PROG_ETIQUETAS_PPCP") Then
                If Item.DataValue = 172 Or Item.DataValue = 176 Then
                    Item.CheckState = CheckState.Checked
                End If
            End If
        Next
    End Sub

    Private Sub alta_etiqueta()
        Dim objEtiqueta As New Entidades.ConfiguracionEtiqueta
        Dim msg_error As New Tools.ErroresForm
        Dim FormAltaEtiqueta As New AltaEtiquetaForm
        Dim msg_Advertencia As New Tools.AdvertenciaForm
        Dim EtiquetaLenguaEspecial As New ConfigurarEtiquetaLenguaEspecialForm
        Dim EsEtiquetaLengua As Boolean = False

        Try
            If TabTipo.SelectedIndex = 0 Then
                fila_seleccionada = grdVEtiquetaEspecial.FocusedRowHandle
                If grdVEtiquetaEspecial.GetFocusedRowCellValue("ImpimeYuyin").ToString = "NO" Then
                    msg_Advertencia.mensaje = "Al cliente seleccionado no se le puede cargar etiqueta especial"
                    msg_Advertencia.ShowDialog()
                    Return
                End If
                objEtiqueta.StatusEtiquetaID = CInt(grdVEtiquetaEspecial.GetFocusedRowCellValue("StatusEtiquetaID"))
                If objEtiqueta.StatusEtiquetaID <> 174 And objEtiqueta.StatusEtiquetaID <> 175 Then
                    objEtiqueta.EtiquetaId = CInt(grdVEtiquetaEspecial.GetFocusedRowCellValue("EtiquetaID"))
                Else
                    objEtiqueta.EtiquetaId = 0
                End If
                objEtiqueta.ClienteId = CInt(grdVEtiquetaEspecial.GetFocusedRowCellValue("ClienteID"))
                objEtiqueta.NombreCliente = grdVEtiquetaEspecial.GetFocusedRowCellValue("Cliente").ToString
                objEtiqueta.TipoEtiqueta = grdVEtiquetaEspecial.GetFocusedRowCellValue("TipoEtiqueta").ToString
                objEtiqueta.TipoEtiquetaId = CInt(grdVEtiquetaEspecial.GetFocusedRowCellValue("TipoEtiquetaID"))
                If grdVEtiquetaEspecial.GetFocusedRowCellValue("EtiquetaYuyin").ToString = "SI" Then
                    objEtiqueta.EtiquetaYuyin = True
                ElseIf grdVEtiquetaEspecial.GetFocusedRowCellValue("EtiquetaYuyin").ToString = "NO" Then
                    objEtiqueta.EtiquetaYuyin = False
                End If
                objEtiqueta.CodigoZPL = grdVEtiquetaEspecial.GetFocusedRowCellValue("CodigoZPL200")
                objEtiqueta.EtiquetaCodigoZPL300 = grdVEtiquetaEspecial.GetFocusedRowCellValue("CodigoZPL300")
                objEtiqueta.EtiquetaVistaPrevia = grdVEtiquetaEspecial.GetFocusedRowCellValue("CodigoZPLVistaPrevia")
                objEtiqueta.EtiquetaAncho = CInt(grdVEtiquetaEspecial.GetFocusedRowCellValue("Ancho"))
                objEtiqueta.EtiquetaAlto = CInt(grdVEtiquetaEspecial.GetFocusedRowCellValue("Alto"))
                objEtiqueta.ColeccionID = 0
                objEtiqueta.Coleccion = ""
            ElseIf TabTipo.SelectedIndex = 1 Then
                fila_seleccionada = grdVEtiquetaYuyin.FocusedRowHandle
                objEtiqueta.ClienteId = 0
                objEtiqueta.EtiquetaId = CInt(grdVEtiquetaYuyin.GetFocusedRowCellValue("EtiquetaID"))
                objEtiqueta.EtiquetaClave = grdVEtiquetaYuyin.GetFocusedRowCellValue("Clave").ToString
                objEtiqueta.EtiquetaNombre = grdVEtiquetaYuyin.GetFocusedRowCellValue("TipoEtiqueta").ToString
                objEtiqueta.EtiquetaDescripcion = grdVEtiquetaYuyin.GetFocusedRowCellValue("Descripcion").ToString
                objEtiqueta.EtiquetaAncho = CInt(grdVEtiquetaYuyin.GetFocusedRowCellValue("Ancho"))
                objEtiqueta.EtiquetaAlto = CInt(grdVEtiquetaYuyin.GetFocusedRowCellValue("Alto"))
                objEtiqueta.TipoEtiqueta = grdVEtiquetaYuyin.GetFocusedRowCellValue("TipoEtiqueta").ToString
                objEtiqueta.TipoEtiquetaId = CInt(grdVEtiquetaYuyin.GetFocusedRowCellValue("TipoEtiquetaID"))
                objEtiqueta.StatusEtiquetaID = CInt(grdVEtiquetaYuyin.GetFocusedRowCellValue("StatusEtiquetaID"))
                If objEtiqueta.StatusEtiquetaID <> 174 And objEtiqueta.StatusEtiquetaID <> 175 Then
                    objEtiqueta.EtiquetaId = CInt(grdVEtiquetaYuyin.GetFocusedRowCellValue("EtiquetaID"))
                Else
                    objEtiqueta.EtiquetaId = 0
                End If
                objEtiqueta.Coleccion = ""
                objEtiqueta.ColeccionID = 0
            ElseIf TabTipo.SelectedIndex = 2 Then
                fila_seleccionada = viewEtiquetasLengua.FocusedRowHandle
                objEtiqueta.ClienteId = 0
                objEtiqueta.EtiquetaId = CInt(viewEtiquetasLengua.GetFocusedRowCellValue("EtiquetaID"))
                objEtiqueta.EtiquetaClave = viewEtiquetasLengua.GetFocusedRowCellValue("Clave").ToString
                objEtiqueta.EtiquetaNombre = viewEtiquetasLengua.GetFocusedRowCellValue("TipoEtiqueta").ToString
                objEtiqueta.EtiquetaDescripcion = viewEtiquetasLengua.GetFocusedRowCellValue("Descripcion").ToString
                objEtiqueta.EtiquetaAncho = CInt(viewEtiquetasLengua.GetFocusedRowCellValue("Ancho"))
                objEtiqueta.EtiquetaAlto = CInt(viewEtiquetasLengua.GetFocusedRowCellValue("Alto"))
                objEtiqueta.TipoEtiqueta = viewEtiquetasLengua.GetFocusedRowCellValue("TipoEtiqueta").ToString
                objEtiqueta.TipoEtiquetaId = CInt(viewEtiquetasLengua.GetFocusedRowCellValue("TipoEtiquetaID"))
                objEtiqueta.StatusEtiquetaID = CInt(viewEtiquetasLengua.GetFocusedRowCellValue("StatusEtiquetaID"))
                objEtiqueta.Coleccion = viewEtiquetasLengua.GetFocusedRowCellValue("Coleccion")
                objEtiqueta.ColeccionID = CInt(viewEtiquetasLengua.GetFocusedRowCellValue("ColeccionID"))
                If objEtiqueta.StatusEtiquetaID <> 174 And objEtiqueta.StatusEtiquetaID <> 175 Then
                    objEtiqueta.EtiquetaId = CInt(viewEtiquetasLengua.GetFocusedRowCellValue("EtiquetaID"))
                Else
                    objEtiqueta.EtiquetaId = 0
                End If
            End If

            If objEtiqueta.TipoEtiquetaId = 10 Or objEtiqueta.TipoEtiquetaId = 13 Then
                EsEtiquetaLengua = True
            Else
                EsEtiquetaLengua = False
            End If

            If objEtiqueta.TipoEtiquetaId = 29 Then
                EtiquetaLenguaEspecial.EntidadEtiqueta = objEtiqueta
                EtiquetaLenguaEspecial.ShowDialog()
            Else
                FormAltaEtiqueta.EsEtiquetaLengua = EsEtiquetaLengua
                FormAltaEtiqueta.EntidadEtiqueta = objEtiqueta
                FormAltaEtiqueta.ShowDialog()
            End If


            btnMostrar_Click(Nothing, Nothing)
        Catch ex As Exception
            msg_error.mensaje = ex.Message
            msg_error.Show()
        End Try

    End Sub

    Private Sub btnAltaEtiquetaClienteColeccion_Click(sender As Object, e As EventArgs) Handles btnAltaEtiquetaClienteColeccion.Click
        Dim EtiquetaClienteColeccion As New ConfigurarEtiquetaLenguaEspecialForm
        Dim objEtiqueta As New Entidades.ConfiguracionEtiqueta


        EtiquetaClienteColeccion.EntidadEtiqueta = objEtiqueta

        EtiquetaClienteColeccion.ShowDialog()
        btnMostrar_Click(Nothing, Nothing)
    End Sub

    Private Sub btnVistaPrevia_Click(sender As Object, e As EventArgs) Handles btnVistaPrevia.Click
        Dim VistaPreviaForm As New VistaPreviaZPLForm
        Dim entEtiqueta As Entidades.ConfiguracionEtiqueta
        Dim ListaImagenes As New List(Of String)
        Dim FechaNula As Date = Nothing
        Try
            entEtiqueta = ValidarUnRegistroSeleccionado()
            Cursor = Cursors.WaitCursor
            If IsNothing(entEtiqueta) = False Then
                If entEtiqueta.CodigoZPL <> String.Empty And entEtiqueta.EtiquetaCodigoZPL300 <> String.Empty Then
                    VistaPreviaForm.CodigoZPL200 = entEtiqueta.CodigoZPL
                    VistaPreviaForm.CodigoZPL300 = entEtiqueta.EtiquetaCodigoZPL300
                    VistaPreviaForm.CodigoZPLVistaPrevia = entEtiqueta.EtiquetaVistaPrevia
                    VistaPreviaForm.AnchoEtiqueta = entEtiqueta.EtiquetaAncho
                    VistaPreviaForm.AltoEtiqueta = entEtiqueta.EtiquetaAlto
                    VistaPreviaForm.Cliente = entEtiqueta.NombreCliente
                    VistaPreviaForm.tipoEtiqueta = entEtiqueta.TipoEtiqueta
                    VistaPreviaForm.clienteId = entEtiqueta.ClienteId
                    VistaPreviaForm.etiquetaId = entEtiqueta.EtiquetaId
                    VistaPreviaForm.StatusEtiquetaID = entEtiqueta.StatusEtiquetaID
                    If entEtiqueta.FechaModificacion = FechaNula Then
                        VistaPreviaForm.FechaModificacionEtiqueta = entEtiqueta.FechaCreacion
                    Else
                        VistaPreviaForm.FechaModificacionEtiqueta = entEtiqueta.FechaModificacion
                    End If
                    If String.IsNullOrEmpty(entEtiqueta.UsuarioModifico) = True Then
                        VistaPreviaForm.UsuarioModifico = entEtiqueta.UsuarioCreo
                    Else
                        VistaPreviaForm.UsuarioModifico = entEtiqueta.UsuarioModifico
                    End If
                    VistaPreviaForm.ShowDialog()
                    ListaImagenes = VistaPreviaForm.ListaImagenes
                    VistaPreviaForm.Dispose()
                    VistaPreviaForm = Nothing
                Else
                    show_message("Advertencia", "No se ha cargado la configuración de la etiqueta.")
                End If
            Else
                VistaPreviaForm.CodigoZPL200 = ""
                VistaPreviaForm.CodigoZPL300 = ""
                VistaPreviaForm.CodigoZPLVistaPrevia = ""
            End If
            Cursor = Cursors.Default
        Catch ex As Exception
            show_message("Error", ex.Message.ToString())
            Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub btnAlta_Click(sender As Object, e As EventArgs) Handles btnAlta.Click
        Dim ObjBU As New Programacion.Negocios.EtiquetasBU
        Dim entEtiqueta As Entidades.ConfiguracionEtiqueta
        Try
            Cursor = Cursors.WaitCursor
            entEtiqueta = ValidarUnRegistroSeleccionado()
            If IsNothing(entEtiqueta) = False Then
                If entEtiqueta.StatusEtiquetaID = 174 Then
                    If ObjBU.ValidarEtiquetaPorAutorizar(entEtiqueta.ClienteId, entEtiqueta.TipoEtiquetaId, entEtiqueta.ColeccionID) > 0 Then
                        show_message("Advertencia", "No se puede configurar una nueva etiqueta para este cliente, ya existe una etiqueta en diseño o por autorizar.")
                    Else
                        alta_etiqueta()
                    End If
                ElseIf entEtiqueta.StatusEtiquetaID = 175 Then
                    show_message("Adevertencia", "No se puede modificar una etiqueta descontinuada.")
                Else
                    alta_etiqueta()
                End If
            Else
                ' show_message("Advertencia", "Ocurrio un error al cargar la información de la etiqueta.")
            End If
            CargarPantalla()
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            show_message("Error", "Ocurrio un error al autorizar la etiqueta.")
        End Try
    End Sub


    Private Sub CargarGridEtiquetaEspecial()
        Dim objNeg As New Programacion.Negocios.EtiquetasBU
        Dim dtEtiquetas As DataTable
        Dim msg_error As New Tools.ErroresForm
        Dim StatusEtiquetaId As String = String.Empty

        Try
            StatusEtiquetaId = ObtenerFiltrosEstatus()
            dtEtiquetas = objNeg.ConsultarEtiquetasEspeciales(StatusEtiquetaId)
            If dtEtiquetas.Rows.Count > 0 Then
                grdEtiquetaEspecial.DataSource = dtEtiquetas
                DiseñoGridEtiquetasEspeciales(grdVEtiquetaEspecial)
                grdVEtiquetaEspecial.FocusedRowHandle = fila_seleccionada
            Else
                grdEtiquetaEspecial.DataSource = dtEtiquetas
                DiseñoGridEtiquetasEspeciales(grdVEtiquetaEspecial)
            End If
        Catch ex As Exception
            msg_error.mensaje = ex.Message
            msg_error.Show()
        End Try
    End Sub

    Private Sub cargarGridEtiquetaYUYIN()
        Dim objNeg As New Programacion.Negocios.EtiquetasBU
        Dim dtEtiquetas As DataTable
        Dim msg_error As New Tools.ErroresForm
        Dim StatusEtiquetaId As String = String.Empty

        Try
            StatusEtiquetaId = ObtenerFiltrosEstatus()
            dtEtiquetas = objNeg.ConsultaEtiquetaYuyin(StatusEtiquetaId)

            If dtEtiquetas.Rows.Count > 0 Then
                grdEtiquetaYuyin.DataSource = dtEtiquetas
                DiseñoGridEtiquetasYuyin(grdVEtiquetaYuyin)
                grdVEtiquetaYuyin.FocusedRowHandle = fila_seleccionada
            Else
                grdEtiquetaYuyin.DataSource = dtEtiquetas
                DiseñoGridEtiquetasYuyin(grdVEtiquetaYuyin)
            End If

        Catch ex As Exception
            msg_error.mensaje = ex.Message
            msg_error.Show()
        End Try

    End Sub

    Private Sub cargarGridEtiquetaLengua()
        Dim objNeg As New Programacion.Negocios.EtiquetasBU
        Dim dtEtiquetas As DataTable
        Dim StatusEtiquetaId As String = String.Empty
        Dim etiquetasConDiseño As Boolean = rdbConDiseño.Checked

        Try
            StatusEtiquetaId = ObtenerFiltrosEstatus()
            dtEtiquetas = objNeg.ConsultaEtiquetasLengua(StatusEtiquetaId, etiquetasConDiseño)
            grdEtiquetasLengua.DataSource = Nothing

            If dtEtiquetas.Rows.Count > 0 Then
                grdEtiquetasLengua.DataSource = dtEtiquetas
                DiseñoGridEtiquetasLengua(viewEtiquetasLengua)
                viewEtiquetasLengua.FocusedRowHandle = fila_seleccionada
            End If

        Catch ex As Exception
            show_message("Error", "Ocurrio un error al mostrar la información.")
        End Try

    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        Try
            If TabTipo.SelectedIndex = 0 Then 'Etiquetas de Cliente
                CargarGridEtiquetaEspecial()
            ElseIf TabTipo.SelectedIndex = 1 Then 'Etiquetas de YUYIN
                cargarGridEtiquetaYUYIN()
            ElseIf TabTipo.SelectedIndex = 2 Then 'Etiquetas de LENGUA
                cargarGridEtiquetaLengua()
            End If

            MostrarFechaActualizado()
        Catch ex As Exception
            show_message("Error", "Ocurrio un error al mostrar la información.")
        End Try
    End Sub

    Private Sub CargarPantalla()
        If TabTipo.SelectedIndex = 0 Then
            CargarGridEtiquetaEspecial()
            MostrarFechaActualizado()
        End If

        If TabTipo.SelectedIndex = 1 Then
            cargarGridEtiquetaYUYIN()
            MostrarFechaActualizado()
        End If
    End Sub

    Private Sub MostrarFechaActualizado()
        Dim FechaAct As DateTime = DateTime.Now
        lblFechaUltimaActualizacion.Text = FechaAct
    End Sub

    Private Sub DiseñoGridEtiquetasYuyin(ByVal Grid As DevExpress.XtraGrid.Views.Grid.GridView)

        If IsNothing(Grid.Columns.FirstOrDefault(Function(x) x.FieldName = "#")) = True Then
            Grid.Columns.AddVisible("#").UnboundType = DevExpress.Data.UnboundColumnType.[Integer]
            AddHandler Grid.CustomUnboundColumnData, AddressOf grdVEtiquetaYuyin_CustomUnboundColumnData
            Grid.Columns.Item("#").VisibleIndex = 0
        End If
        Grid.OptionsView.EnableAppearanceEvenRow = True
        Grid.OptionsView.EnableAppearanceOddRow = True
        Grid.Appearance.FocusedRow.BackColor = Color.FromArgb(0, 120, 215)
        Grid.Appearance.FocusedRow.ForeColor = Color.White
        Grid.Appearance.FocusedCell.BackColor = Color.FromArgb(0, 120, 215)
        Grid.Appearance.FocusedCell.ForeColor = Color.White
        DiseñoColumnasGrids(Grid)
        Grid.Columns.ColumnByFieldName(" ").Visible = False
        Grid.Columns.ColumnByFieldName("Clave").Visible = False
        Grid.Columns.ColumnByFieldName("EtiquetaID").Visible = False
        Grid.Columns.ColumnByFieldName("TipoEtiquetaID").Visible = False
        Grid.Columns.ColumnByFieldName("StatusEtiquetaID").Visible = False
        Grid.Columns.ColumnByFieldName("StatusEtiqueta").Visible = True
        Grid.Columns.ColumnByFieldName("CodigoZPL200").Visible = False
        Grid.Columns.ColumnByFieldName("CodigoZPL300").Visible = False
        Grid.Columns.ColumnByFieldName("Orientacion").Visible = False
        Grid.Columns.ColumnByFieldName("UsuarioCreoID").Visible = False
        Grid.Columns.ColumnByFieldName("UsuarioModificoID").Visible = False
        Grid.Columns.ColumnByFieldName("ClienteID").Visible = False
        Grid.Columns.ColumnByFieldName("EtiquetaYuyin").Visible = False
        Grid.Columns.ColumnByFieldName("Activo").Visible = False
        Grid.Columns.ColumnByFieldName("CodigoZPLVistaPrevia").Visible = False
        Grid.Columns.ColumnByFieldName("ImpresionPaso").Visible = False
        Grid.Columns.ColumnByFieldName("UsuarioPorAutorizo").Visible = True
        Grid.Columns.ColumnByFieldName("FechaAutorizacion").Visible = True
        Grid.Columns.ColumnByFieldName("UsuarioAutorizo").Visible = True
        Grid.Columns.ColumnByFieldName("etiq_usuarioporautorizarid").Visible = False
        Grid.Columns.ColumnByFieldName("etiq_usuarioautorizaid").Visible = False
        Grid.Columns.ColumnByFieldName("Ancho").Visible = False
        Grid.Columns.ColumnByFieldName("Alto").Visible = False
        Grid.Columns.ColumnByFieldName("ZPLVistaPrevia").Visible = False

        Grid.Columns.ColumnByFieldName("TipoEtiqueta").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("Descripcion").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("Ancho").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("Alto").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("StatusEtiquetaID").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("StatusEtiqueta").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("UsuarioCreo").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("FechaCreacion").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("UsuarioModifico").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("FechaModificacion").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("ZPL200").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("ZPL300").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("ZPLVistaPrevia").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("#").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("FechaPorAutorizar").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("UsuarioPorAutorizo").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("FechaAutorizacion").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("UsuarioAutorizo").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("etiq_usuarioporautorizarid").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("etiq_usuarioautorizaid").OptionsColumn.AllowEdit = False

        Grid.Columns.ColumnByFieldName("ZPL200").Caption = "ZPL 203"
        Grid.Columns.ColumnByFieldName("ZPL300").Caption = "ZPL 300"
        Grid.Columns.ColumnByFieldName("Descripcion").Caption = "Descripción"
        Grid.Columns.ColumnByFieldName("UsuarioCreo").Caption = "Creó"
        Grid.Columns.ColumnByFieldName("FechaCreacion").Caption = "FCreación"
        Grid.Columns.ColumnByFieldName("UsuarioModifico").Caption = "Modificó"
        Grid.Columns.ColumnByFieldName("FechaModificacion").Caption = "FModificación"
        Grid.Columns.ColumnByFieldName("StatusEtiqueta").Caption = "Status"
        Grid.Columns.ColumnByFieldName("FechaAutorizacion").Caption = "FAutorización"
        Grid.Columns.ColumnByFieldName("UsuarioAutorizo").Caption = "Autorizó"
        Grid.Columns.ColumnByFieldName("FechaPorAutorizar").Caption = "FRevisión"
        Grid.Columns.ColumnByFieldName("UsuarioPorAutorizo").Caption = "Revisó"

        Grid.Columns.ColumnByFieldName("FechaPorAutorizar").DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss"
        Grid.Columns.ColumnByFieldName("FechaAutorizacion").DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss"
        Grid.Columns.ColumnByFieldName("FechaModificacion").DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss"
        Grid.Columns.ColumnByFieldName("FechaCreacion").DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss"

        Grid.Columns.ColumnByFieldName("Descripcion").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Grid.Columns.ColumnByFieldName("TipoEtiqueta").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Grid.Columns.ColumnByFieldName("UsuarioAutorizo").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Grid.Columns.ColumnByFieldName("UsuarioPorAutorizo").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Grid.Columns.ColumnByFieldName("UsuarioCreo").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Grid.Columns.ColumnByFieldName("StatusEtiqueta").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains

        Grid.BestFitColumns()

    End Sub

    Private Sub DiseñoGridEtiquetasEspeciales(ByVal Grid As DevExpress.XtraGrid.Views.Grid.GridView)

        If IsNothing(Grid.Columns.FirstOrDefault(Function(x) x.FieldName = "#")) = True Then
            Grid.Columns.AddVisible("#").UnboundType = DevExpress.Data.UnboundColumnType.[Integer]
            AddHandler Grid.CustomUnboundColumnData, AddressOf grdVEtiquetasEspeciales_CustomUnboundColumnData
            Grid.Columns.Item("#").VisibleIndex = 0
            Grid.Columns.Item("#").OptionsColumn.AllowEdit = False
        End If

        DiseñoColumnasGrids(Grid)
        Grid.Appearance.FocusedRow.BackColor = Color.FromArgb(0, 120, 215)
        Grid.Appearance.FocusedRow.ForeColor = Color.White
        Grid.Appearance.FocusedCell.BackColor = Color.FromArgb(0, 120, 215)
        Grid.Appearance.FocusedCell.ForeColor = Color.White

        Grid.Columns.ColumnByFieldName(" ").Visible = False
        Grid.Columns.ColumnByFieldName("ClienteID").Visible = False
        Grid.Columns.ColumnByFieldName("Cliente").Visible = True
        Grid.Columns.ColumnByFieldName("TipoEtiqueta").Visible = True
        Grid.Columns.ColumnByFieldName("StatusEtiquetaID").Visible = False
        Grid.Columns.ColumnByFieldName("StatusEtiqueta").Visible = True
        Grid.Columns.ColumnByFieldName("ImpimeYuyin").Visible = False
        Grid.Columns.ColumnByFieldName("EtiquetaYuyin").Visible = False
        Grid.Columns.ColumnByFieldName("ZPL200").Visible = True
        Grid.Columns.ColumnByFieldName("ZPL300").Visible = True
        Grid.Columns.ColumnByFieldName("ZPLVistaPrevia").Visible = False
        Grid.Columns.ColumnByFieldName("FechaCreacion").Visible = True
        Grid.Columns.ColumnByFieldName("UsuarioCreo").Visible = True
        Grid.Columns.ColumnByFieldName("FechaModificacion").Visible = True
        Grid.Columns.ColumnByFieldName("UsuarioModifico").Visible = True
        Grid.Columns.ColumnByFieldName("EtiquetaID").Visible = False
        Grid.Columns.ColumnByFieldName("TipoEtiquetaID").Visible = False
        Grid.Columns.ColumnByFieldName("CodigoZPL200").Visible = False
        Grid.Columns.ColumnByFieldName("CodigoZPL300").Visible = False
        Grid.Columns.ColumnByFieldName("CodigoZPLVistaPrevia").Visible = False
        Grid.Columns.ColumnByFieldName("Ancho").Visible = False
        Grid.Columns.ColumnByFieldName("Alto").Visible = False
        Grid.Columns.ColumnByFieldName("FechaPorAutorizar").Visible = True
        Grid.Columns.ColumnByFieldName("UsuarioPorAutorizo").Visible = True
        Grid.Columns.ColumnByFieldName("FechaAutorizacion").Visible = True
        Grid.Columns.ColumnByFieldName("UsuarioAutorizo").Visible = True
        Grid.Columns.ColumnByFieldName("etiq_usuarioporautorizarid").Visible = False
        Grid.Columns.ColumnByFieldName("etiq_usuarioautorizaid").Visible = False

        Grid.Columns.ColumnByFieldName(" ").OptionsColumn.AllowEdit = True
        Grid.Columns.ColumnByFieldName("ClienteID").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("Cliente").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("TipoEtiqueta").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("StatusEtiquetaID").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("StatusEtiqueta").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("ImpimeYuyin").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("EtiquetaYuyin").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("ZPL200").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("ZPL300").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("ZPLVistaPrevia").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("FechaCreacion").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("UsuarioCreo").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("FechaModificacion").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("UsuarioModifico").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("EtiquetaID").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("TipoEtiquetaID").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("CodigoZPL200").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("CodigoZPL300").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("CodigoZPLVistaPrevia").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("Ancho").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("Alto").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("FechaPorAutorizar").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("UsuarioPorAutorizo").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("FechaAutorizacion").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("UsuarioAutorizo").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("etiq_usuarioporautorizarid").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("etiq_usuarioautorizaid").OptionsColumn.AllowEdit = False

        Grid.Columns.ColumnByFieldName(" ").Caption = " "
        Grid.Columns.ColumnByFieldName("Cliente").Caption = "Cliente"
        Grid.Columns.ColumnByFieldName("TipoEtiqueta").Caption = "Tipo Etiqueta"
        Grid.Columns.ColumnByFieldName("StatusEtiqueta").Caption = "Status"
        Grid.Columns.ColumnByFieldName("ZPL200").Caption = "ZPL 203"
        Grid.Columns.ColumnByFieldName("ZPL300").Caption = "ZPL 300"
        Grid.Columns.ColumnByFieldName("FechaCreacion").Caption = "FCreación"
        Grid.Columns.ColumnByFieldName("UsuarioCreo").Caption = "Creó"
        Grid.Columns.ColumnByFieldName("FechaModificacion").Caption = "FModificación"
        Grid.Columns.ColumnByFieldName("UsuarioModifico").Caption = "Modificó"
        Grid.Columns.ColumnByFieldName("FechaPorAutorizar").Caption = "FRevisión"
        Grid.Columns.ColumnByFieldName("UsuarioPorAutorizo").Caption = "Revisó"
        Grid.Columns.ColumnByFieldName("FechaAutorizacion").Caption = "FAutorización"
        Grid.Columns.ColumnByFieldName("UsuarioAutorizo").Caption = "Autorizó"

        Grid.Columns.ColumnByFieldName("FechaPorAutorizar").DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss"
        Grid.Columns.ColumnByFieldName("FechaAutorizacion").DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss"
        Grid.Columns.ColumnByFieldName("FechaModificacion").DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss"
        Grid.Columns.ColumnByFieldName("FechaCreacion").DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss"

        Grid.Columns.ColumnByFieldName("Cliente").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Grid.Columns.ColumnByFieldName("TipoEtiqueta").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Grid.Columns.ColumnByFieldName("UsuarioAutorizo").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Grid.Columns.ColumnByFieldName("UsuarioPorAutorizo").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Grid.Columns.ColumnByFieldName("UsuarioCreo").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Grid.Columns.ColumnByFieldName("StatusEtiqueta").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains

        Grid.BestFitColumns()
    End Sub

    Private Sub DiseñoGridEtiquetasLengua(ByVal Grid As DevExpress.XtraGrid.Views.Grid.GridView)

        If IsNothing(Grid.Columns.FirstOrDefault(Function(x) x.FieldName = "#")) = True Then
            Grid.Columns.AddVisible("#").UnboundType = DevExpress.Data.UnboundColumnType.[Integer]
            AddHandler Grid.CustomUnboundColumnData, AddressOf grdVEtiquetaYuyin_CustomUnboundColumnData
            Grid.Columns.Item("#").VisibleIndex = 0
            Grid.Columns.Item("#").OptionsColumn.AllowEdit = False
        End If

        DiseñoGrid.AlternarColorEnFilas(Grid)

        Grid.Columns.ColumnByFieldName(" ").Visible = True
        Grid.Columns.ColumnByFieldName("Coleccion").Visible = True
        Grid.Columns.ColumnByFieldName("TipoEtiquetaID").Visible = False
        Grid.Columns.ColumnByFieldName("TipoEtiqueta").Visible = True
        Grid.Columns.ColumnByFieldName("EtiquetaID").Visible = False
        Grid.Columns.ColumnByFieldName("Clave").Visible = False
        Grid.Columns.ColumnByFieldName("Descripcion").Visible = False
        Grid.Columns.ColumnByFieldName("StatusEtiquetaID").Visible = False
        Grid.Columns.ColumnByFieldName("StatusEtiqueta").Visible = True
        Grid.Columns.ColumnByFieldName("CodigoZPL200").Visible = False
        Grid.Columns.ColumnByFieldName("CodigoZPL300").Visible = False
        Grid.Columns.ColumnByFieldName("ZPL200").Visible = True
        Grid.Columns.ColumnByFieldName("ZPL300").Visible = True
        Grid.Columns.ColumnByFieldName("ZPLVistaPrevia").Visible = False
        Grid.Columns.ColumnByFieldName("Ancho").Visible = True
        Grid.Columns.ColumnByFieldName("Alto").Visible = True
        Grid.Columns.ColumnByFieldName("Orientacion").Visible = False
        Grid.Columns.ColumnByFieldName("UsuarioCreoID").Visible = False
        Grid.Columns.ColumnByFieldName("UsuarioCreo").Visible = True
        Grid.Columns.ColumnByFieldName("FechaCreacion").Visible = True
        Grid.Columns.ColumnByFieldName("UsuarioModificoID").Visible = False
        Grid.Columns.ColumnByFieldName("UsuarioModifico").Visible = True
        Grid.Columns.ColumnByFieldName("FechaModificacion").Visible = True
        Grid.Columns.ColumnByFieldName("EtiquetaYuyin").Visible = False
        Grid.Columns.ColumnByFieldName("Activo").Visible = False
        Grid.Columns.ColumnByFieldName("CodigoZPLVistaPrevia").Visible = False
        Grid.Columns.ColumnByFieldName("ImpresionPaso").Visible = True
        Grid.Columns.ColumnByFieldName("FechaPorAutorizar").Visible = True
        Grid.Columns.ColumnByFieldName("UsuarioPorAutorizo").Visible = True
        Grid.Columns.ColumnByFieldName("FechaAutorizacion").Visible = True
        Grid.Columns.ColumnByFieldName("UsuarioAutorizo").Visible = True
        Grid.Columns.ColumnByFieldName("etiq_usuarioporautorizarid").Visible = False
        Grid.Columns.ColumnByFieldName("etiq_usuarioautorizaid").Visible = False
        Grid.Columns.ColumnByFieldName("ColeccionID").Visible = False

        Grid.Columns.ColumnByFieldName(" ").OptionsColumn.AllowEdit = True
        Grid.Columns.ColumnByFieldName("Coleccion").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("TipoEtiquetaID").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("TipoEtiqueta").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("EtiquetaID").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("Clave").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("Descripcion").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("StatusEtiquetaID").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("StatusEtiqueta").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("CodigoZPL200").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("CodigoZPL300").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("ZPL200").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("ZPL300").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("ZPLVistaPrevia").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("Ancho").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("Alto").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("Orientacion").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("UsuarioCreoID").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("UsuarioCreo").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("FechaCreacion").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("UsuarioModificoID").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("UsuarioModifico").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("FechaModificacion").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("EtiquetaYuyin").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("Activo").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("CodigoZPLVistaPrevia").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("ImpresionPaso").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("FechaPorAutorizar").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("UsuarioPorAutorizo").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("FechaAutorizacion").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("UsuarioAutorizo").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("etiq_usuarioporautorizarid").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("etiq_usuarioautorizaid").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("ColeccionID").OptionsColumn.AllowEdit = False

        Grid.Columns.ColumnByFieldName(" ").Caption = " "
        Grid.Columns.ColumnByFieldName("Coleccion").Caption = "Colección"
        Grid.Columns.ColumnByFieldName("TipoEtiquetaID").Caption = "TipoEtiquetaID"
        Grid.Columns.ColumnByFieldName("TipoEtiqueta").Caption = "Tipo Etiqueta"
        Grid.Columns.ColumnByFieldName("EtiquetaID").Caption = "EtiquetaID"
        Grid.Columns.ColumnByFieldName("Clave").Caption = "Clave"
        Grid.Columns.ColumnByFieldName("Descripcion").Caption = "Descripción"
        Grid.Columns.ColumnByFieldName("StatusEtiquetaID").Caption = "StatusEtiquetaID"
        Grid.Columns.ColumnByFieldName("StatusEtiqueta").Caption = "Status"
        Grid.Columns.ColumnByFieldName("CodigoZPL200").Caption = "CodigoZPL203"
        Grid.Columns.ColumnByFieldName("CodigoZPL300").Caption = "CodigoZPL300"
        Grid.Columns.ColumnByFieldName("ZPL200").Caption = "ZPL 203"
        Grid.Columns.ColumnByFieldName("ZPL300").Caption = "ZPL 300"
        Grid.Columns.ColumnByFieldName("ZPLVistaPrevia").Caption = "ZPL Vista Previa"
        Grid.Columns.ColumnByFieldName("Ancho").Caption = "Ancho"
        Grid.Columns.ColumnByFieldName("Alto").Caption = "Alto"
        Grid.Columns.ColumnByFieldName("Orientacion").Caption = "Orientación"
        Grid.Columns.ColumnByFieldName("UsuarioCreoID").Caption = "UsuarioCreoID"
        Grid.Columns.ColumnByFieldName("UsuarioCreo").Caption = "Creó"
        Grid.Columns.ColumnByFieldName("FechaCreacion").Caption = "FCreación"
        Grid.Columns.ColumnByFieldName("UsuarioModificoID").Caption = "UsuarioModificoID"
        Grid.Columns.ColumnByFieldName("UsuarioModifico").Caption = "Modificó"
        Grid.Columns.ColumnByFieldName("FechaModificacion").Caption = "FModificación"
        Grid.Columns.ColumnByFieldName("EtiquetaYuyin").Caption = "Etiqueta YUYIN"
        Grid.Columns.ColumnByFieldName("Activo").Caption = "Activo"
        Grid.Columns.ColumnByFieldName("CodigoZPLVistaPrevia").Caption = "ZPLVistaPrevia"
        Grid.Columns.ColumnByFieldName("ImpresionPaso").Caption = "Impresión al paso"
        Grid.Columns.ColumnByFieldName("FechaPorAutorizar").Caption = "FRevisión"
        Grid.Columns.ColumnByFieldName("UsuarioPorAutorizo").Caption = "Revisó"
        Grid.Columns.ColumnByFieldName("FechaAutorizacion").Caption = "FAutorización"
        Grid.Columns.ColumnByFieldName("UsuarioAutorizo").Caption = "Autorizó"
        Grid.Columns.ColumnByFieldName("etiq_usuarioporautorizarid").Caption = "UsuarioPorAutorizar"
        Grid.Columns.ColumnByFieldName("etiq_usuarioautorizaid").Caption = "UsuarioAutorizaID"
        Grid.Columns.ColumnByFieldName("ColeccionID").Caption = "ColeccionID"

        Grid.Columns.ColumnByFieldName("FechaPorAutorizar").DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss"
        Grid.Columns.ColumnByFieldName("FechaAutorizacion").DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss"
        Grid.Columns.ColumnByFieldName("FechaModificacion").DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss"
        Grid.Columns.ColumnByFieldName("FechaCreacion").DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss"
        Grid.Columns.ColumnByFieldName("Descripcion").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Grid.Columns.ColumnByFieldName("TipoEtiqueta").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Grid.Columns.ColumnByFieldName("UsuarioAutorizo").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Grid.Columns.ColumnByFieldName("UsuarioPorAutorizo").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Grid.Columns.ColumnByFieldName("UsuarioCreo").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Grid.Columns.ColumnByFieldName("StatusEtiqueta").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Grid.Columns.ColumnByFieldName("Coleccion").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains

        Grid.BestFitColumns()

    End Sub


    Private Sub grdVEtiquetasEspeciales_CustomUnboundColumnData(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs)
        Try
            If e.IsGetData Then
                e.Value = grdVEtiquetaEspecial.GetRowHandle(e.ListSourceRowIndex)
                e.Value = e.Value + 1
            End If
        Catch ex As Exception
            Dim Valor As String = ""
            Valor = "cadena"
        End Try

    End Sub

    Private Sub grdVEtiquetaYuyin_CustomUnboundColumnData(sender As Object, e As CustomColumnDataEventArgs) Handles grdVEtiquetaYuyin.CustomUnboundColumnData
        If e.IsGetData Then
            e.Value = grdVEtiquetaYuyin.GetRowHandle(e.ListSourceRowIndex)
            e.Value = e.Value + 1
        End If
    End Sub

    Private Sub DiseñoColumnasGrids(ByVal Grid As DevExpress.XtraGrid.Views.Grid.GridView)
        Grid.OptionsView.ColumnAutoWidth = True
        Grid.OptionsView.BestFitMaxRowCount = -1

        For Each col As DevExpress.XtraGrid.Columns.GridColumn In Grid.Columns
            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Next
        Grid.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True
        For i As Integer = 1 To Grid.RowCount - 1
            If i Mod 2 = 0 Then
                'GridView1.OptionsView.EnableAppearanceOddRow = Color.LightSteelBlue
                Grid.Appearance.EvenRow.BackColor = Color.LightSteelBlue
                Grid.OptionsView.EnableAppearanceOddRow = True
                Grid.Invalidate()
            End If
        Next

    End Sub

    Private Function ValidarUnRegistroSeleccionado() As Entidades.ConfiguracionEtiqueta
        Dim NumeroFilas As Integer = 0
        Dim RegistroSeleccionado As Boolean = False
        Dim NumeroRegistrosSeleccionados As Integer = 0
        Dim objEtiqueta As New Entidades.ConfiguracionEtiqueta
        Dim msg_error As New Tools.ErroresForm
        Dim indice As Integer = 0
        Try
            Cursor = Cursors.WaitCursor
            If TabTipo.SelectedIndex = 0 Then 'Etiquetas de Cliente
                If grdVEtiquetaEspecial.GetFocusedDataSourceRowIndex() >= 0 Then
                    objEtiqueta.EtiquetaId = CInt(grdVEtiquetaEspecial.GetFocusedRowCellValue("EtiquetaID"))
                    objEtiqueta.ClienteId = CInt(grdVEtiquetaEspecial.GetFocusedRowCellValue("ClienteID"))
                    objEtiqueta.NombreCliente = grdVEtiquetaEspecial.GetFocusedRowCellValue("Cliente").ToString
                    objEtiqueta.TipoEtiqueta = grdVEtiquetaEspecial.GetFocusedRowCellValue("TipoEtiqueta").ToString
                    objEtiqueta.TipoEtiquetaId = CInt(grdVEtiquetaEspecial.GetFocusedRowCellValue("TipoEtiquetaID"))
                    If grdVEtiquetaEspecial.GetFocusedRowCellValue("ImpimeYuyin").ToString = "SI" Then
                        objEtiqueta.EtiquetaYuyin = True
                    ElseIf grdVEtiquetaEspecial.GetFocusedRowCellValue("ImpimeYuyin").ToString = "NO" Then
                        objEtiqueta.EtiquetaYuyin = False
                    End If
                    objEtiqueta.CodigoZPL = grdVEtiquetaEspecial.GetFocusedRowCellValue("CodigoZPL200")
                    objEtiqueta.EtiquetaCodigoZPL300 = grdVEtiquetaEspecial.GetFocusedRowCellValue("CodigoZPL300")
                    objEtiqueta.EtiquetaVistaPrevia = grdVEtiquetaEspecial.GetFocusedRowCellValue("CodigoZPLVistaPrevia")
                    objEtiqueta.EtiquetaAncho = CInt(grdVEtiquetaEspecial.GetFocusedRowCellValue("Ancho"))
                    objEtiqueta.EtiquetaAlto = CInt(grdVEtiquetaEspecial.GetFocusedRowCellValue("Alto"))
                    objEtiqueta.StatusEtiquetaID = CInt(grdVEtiquetaEspecial.GetFocusedRowCellValue("StatusEtiquetaID"))
                    If IsDBNull(grdVEtiquetaEspecial.GetFocusedRowCellValue("FechaModificacion")) = False Then
                        objEtiqueta.FechaModificacion = CDate(grdVEtiquetaEspecial.GetFocusedRowCellValue("FechaModificacion"))
                    Else
                        objEtiqueta.FechaModificacion = Nothing
                    End If

                    If IsDBNull(grdVEtiquetaEspecial.GetFocusedRowCellValue("UsuarioModifico")) = False Then
                        objEtiqueta.UsuarioModifico = grdVEtiquetaEspecial.GetFocusedRowCellValue("UsuarioModifico")
                    Else
                        objEtiqueta.UsuarioModifico = Nothing
                    End If
                    objEtiqueta.FechaCreacion = grdVEtiquetaEspecial.GetFocusedRowCellValue("FechaCreacion")
                    objEtiqueta.UsuarioCreo = grdVEtiquetaEspecial.GetFocusedRowCellValue("UsuarioCreo")
                    'objEtiqueta.Coleccion = grdVEtiquetaEspecial.GetFocusedRowCellValue("ColeccionID")

                Else
                    objEtiqueta = Nothing
                End If
            ElseIf TabTipo.SelectedIndex = 1 Then 'Etiquetas de YUYIN
                If grdVEtiquetaYuyin.GetFocusedDataSourceRowIndex() >= 0 Then
                    objEtiqueta.ClienteId = 0
                    objEtiqueta.EtiquetaId = CInt(grdVEtiquetaYuyin.GetFocusedRowCellValue("EtiquetaID"))
                    'objEtiqueta.EtiquetaClave = grdVEtiquetaYuyin.GetFocusedRowCellValue("Clave").ToString
                    objEtiqueta.EtiquetaNombre = grdVEtiquetaYuyin.GetFocusedRowCellValue("TipoEtiqueta").ToString
                    objEtiqueta.EtiquetaDescripcion = grdVEtiquetaYuyin.GetFocusedRowCellValue("Descripcion").ToString
                    objEtiqueta.EtiquetaAncho = CInt(grdVEtiquetaYuyin.GetFocusedRowCellValue("Ancho"))
                    objEtiqueta.EtiquetaAlto = CInt(grdVEtiquetaYuyin.GetFocusedRowCellValue("Alto"))
                    objEtiqueta.TipoEtiqueta = grdVEtiquetaYuyin.GetFocusedRowCellValue("TipoEtiqueta").ToString
                    objEtiqueta.TipoEtiquetaId = CInt(grdVEtiquetaYuyin.GetFocusedRowCellValue("TipoEtiquetaID"))
                    objEtiqueta.CodigoZPL = grdVEtiquetaYuyin.GetFocusedRowCellValue("CodigoZPL200")
                    objEtiqueta.EtiquetaCodigoZPL300 = grdVEtiquetaYuyin.GetFocusedRowCellValue("CodigoZPL300")
                    objEtiqueta.EtiquetaVistaPrevia = grdVEtiquetaYuyin.GetFocusedRowCellValue("CodigoZPLVistaPrevia")
                    objEtiqueta.EtiquetaAncho = CInt(grdVEtiquetaYuyin.GetFocusedRowCellValue("Ancho"))
                    objEtiqueta.EtiquetaAlto = CInt(grdVEtiquetaYuyin.GetFocusedRowCellValue("Alto"))
                    objEtiqueta.StatusEtiquetaID = CInt(grdVEtiquetaYuyin.GetFocusedRowCellValue("StatusEtiquetaID"))

                    If IsDBNull(grdVEtiquetaYuyin.GetFocusedRowCellValue("FechaModificacion")) = False Then
                        objEtiqueta.FechaModificacion = CDate(grdVEtiquetaYuyin.GetFocusedRowCellValue("FechaModificacion"))
                    Else
                        objEtiqueta.FechaModificacion = Nothing
                    End If
                    If IsDBNull(grdVEtiquetaYuyin.GetFocusedRowCellValue("UsuarioModifico")) = False Then
                        objEtiqueta.UsuarioModifico = grdVEtiquetaYuyin.GetFocusedRowCellValue("UsuarioModifico")
                    Else
                        objEtiqueta.UsuarioModifico = Nothing
                    End If
                    objEtiqueta.FechaCreacion = grdVEtiquetaEspecial.GetFocusedRowCellValue("FechaCreacion")
                    objEtiqueta.UsuarioCreo = grdVEtiquetaEspecial.GetFocusedRowCellValue("UsuarioCreo")
                End If
            ElseIf TabTipo.SelectedIndex = 2 Then 'Etiqueta de LENGUA
                If viewEtiquetasLengua.GetFocusedDataSourceRowIndex() >= 0 Then
                    objEtiqueta.ClienteId = 0
                    objEtiqueta.EtiquetaId = CInt(viewEtiquetasLengua.GetFocusedRowCellValue("EtiquetaID"))
                    'objEtiqueta.EtiquetaClave = grdVEtiquetaYuyin.GetFocusedRowCellValue("Clave").ToString
                    objEtiqueta.EtiquetaNombre = viewEtiquetasLengua.GetFocusedRowCellValue("TipoEtiqueta").ToString
                    objEtiqueta.EtiquetaDescripcion = viewEtiquetasLengua.GetFocusedRowCellValue("Descripcion").ToString
                    objEtiqueta.EtiquetaAncho = CInt(viewEtiquetasLengua.GetFocusedRowCellValue("Ancho"))
                    objEtiqueta.EtiquetaAlto = CInt(viewEtiquetasLengua.GetFocusedRowCellValue("Alto"))
                    objEtiqueta.TipoEtiqueta = viewEtiquetasLengua.GetFocusedRowCellValue("TipoEtiqueta").ToString
                    objEtiqueta.TipoEtiquetaId = CInt(viewEtiquetasLengua.GetFocusedRowCellValue("TipoEtiquetaID"))
                    objEtiqueta.CodigoZPL = viewEtiquetasLengua.GetFocusedRowCellValue("CodigoZPL200")
                    objEtiqueta.EtiquetaCodigoZPL300 = viewEtiquetasLengua.GetFocusedRowCellValue("CodigoZPL300")
                    objEtiqueta.EtiquetaVistaPrevia = viewEtiquetasLengua.GetFocusedRowCellValue("CodigoZPLVistaPrevia")
                    objEtiqueta.EtiquetaAncho = CInt(viewEtiquetasLengua.GetFocusedRowCellValue("Ancho"))
                    objEtiqueta.EtiquetaAlto = CInt(viewEtiquetasLengua.GetFocusedRowCellValue("Alto"))
                    objEtiqueta.StatusEtiquetaID = CInt(viewEtiquetasLengua.GetFocusedRowCellValue("StatusEtiquetaID"))
                    objEtiqueta.ColeccionID = viewEtiquetasLengua.GetFocusedRowCellValue("ColeccionID")
                    If IsDBNull(viewEtiquetasLengua.GetFocusedRowCellValue("FechaModificacion")) = False Then
                        objEtiqueta.FechaModificacion = CDate(viewEtiquetasLengua.GetFocusedRowCellValue("FechaModificacion"))
                    Else
                        objEtiqueta.FechaModificacion = Nothing
                    End If
                    If IsDBNull(viewEtiquetasLengua.GetFocusedRowCellValue("UsuarioModifico")) = False Then
                        objEtiqueta.UsuarioModifico = viewEtiquetasLengua.GetFocusedRowCellValue("UsuarioModifico")
                    Else
                        objEtiqueta.UsuarioModifico = Nothing
                    End If
                    If IsDBNull(viewEtiquetasLengua.GetFocusedRowCellValue("FechaCreacion")) = False Then
                        objEtiqueta.FechaCreacion = viewEtiquetasLengua.GetFocusedRowCellValue("FechaCreacion")
                    Else
                        objEtiqueta.FechaCreacion = Nothing
                    End If
                    If IsDBNull(viewEtiquetasLengua.GetFocusedRowCellValue("UsuarioCreo")) = False Then
                        objEtiqueta.UsuarioCreo = viewEtiquetasLengua.GetFocusedRowCellValue("UsuarioCreo")
                    Else
                        objEtiqueta.UsuarioCreo = Nothing
                    End If
                End If
            End If
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            msg_error.mensaje = ex.Message
            msg_error.Show()
        End Try

        Return objEtiqueta

    End Function

    Private Function ValidarRegistrosSeleccionado() As List(Of Entidades.ConfiguracionEtiqueta)
        ValidarRegistrosSeleccionado = New List(Of Entidades.ConfiguracionEtiqueta)
        Dim NumeroFilas As Integer = 0
        Dim RegistroSeleccionado As Boolean = False
        Dim NumeroRegistrosSeleccionados As Integer = 0
        Dim objEtiqueta As Entidades.ConfiguracionEtiqueta
        Dim msg_error As New Tools.ErroresForm
        Dim indice As Integer = 0
        Try
            Cursor = Cursors.WaitCursor
            If TabTipo.SelectedIndex = 0 Then 'Etiquetas de Cliente
                For i = 0 To grdVEtiquetaEspecial.RowCount - 1
                    If grdVEtiquetaEspecial.GetRowCellValue(i, " ") Then
                        objEtiqueta = New Entidades.ConfiguracionEtiqueta
                        objEtiqueta.EtiquetaId = CInt(grdVEtiquetaEspecial.GetRowCellValue(i, "EtiquetaID"))
                        objEtiqueta.ClienteId = CInt(grdVEtiquetaEspecial.GetRowCellValue(i, "ClienteID"))
                        objEtiqueta.NombreCliente = grdVEtiquetaEspecial.GetRowCellValue(i, "Cliente").ToString
                        objEtiqueta.TipoEtiqueta = grdVEtiquetaEspecial.GetRowCellValue(i, "TipoEtiqueta").ToString
                        objEtiqueta.TipoEtiquetaId = CInt(grdVEtiquetaEspecial.GetRowCellValue(i, "TipoEtiquetaID"))
                        If grdVEtiquetaEspecial.GetRowCellValue(i, "ImpimeYuyin").ToString = "SI" Then
                            objEtiqueta.EtiquetaYuyin = True
                        ElseIf grdVEtiquetaEspecial.GetRowCellValue(i, "ImpimeYuyin").ToString = "NO" Then
                            objEtiqueta.EtiquetaYuyin = False
                        End If
                        objEtiqueta.CodigoZPL = grdVEtiquetaEspecial.GetRowCellValue(i, "CodigoZPL200")
                        objEtiqueta.EtiquetaCodigoZPL300 = grdVEtiquetaEspecial.GetRowCellValue(i, "CodigoZPL300")
                        objEtiqueta.EtiquetaVistaPrevia = grdVEtiquetaEspecial.GetRowCellValue(i, "CodigoZPLVistaPrevia")
                        objEtiqueta.EtiquetaAncho = CInt(grdVEtiquetaEspecial.GetRowCellValue(i, "Ancho"))
                        objEtiqueta.EtiquetaAlto = CInt(grdVEtiquetaEspecial.GetRowCellValue(i, "Alto"))
                        objEtiqueta.StatusEtiquetaID = CInt(grdVEtiquetaEspecial.GetRowCellValue(i, "StatusEtiquetaID"))
                        If IsDBNull(grdVEtiquetaEspecial.GetRowCellValue(i, "FechaModificacion")) = False Then
                            objEtiqueta.FechaModificacion = CDate(grdVEtiquetaEspecial.GetRowCellValue(i, "FechaModificacion"))
                        Else
                            objEtiqueta.FechaModificacion = Nothing
                        End If

                        If IsDBNull(grdVEtiquetaEspecial.GetRowCellValue(i, "UsuarioModifico")) = False Then
                            objEtiqueta.UsuarioModifico = grdVEtiquetaEspecial.GetRowCellValue(i, "UsuarioModifico")
                        Else
                            objEtiqueta.UsuarioModifico = Nothing
                        End If
                        objEtiqueta.FechaCreacion = grdVEtiquetaEspecial.GetRowCellValue(i, "FechaCreacion")
                        objEtiqueta.UsuarioCreo = grdVEtiquetaEspecial.GetRowCellValue(i, "UsuarioCreo")
                        'objEtiqueta.Coleccion = grdVEtiquetaEspecial.GetRowCellValue(i,"ColeccionID")
                        ValidarRegistrosSeleccionado.Add(objEtiqueta)
                    End If
                Next
            ElseIf TabTipo.SelectedIndex = 1 Then 'Etiquetas de YUYIN
                For i = 0 To grdVEtiquetaYuyin.RowCount - 1
                    If grdVEtiquetaYuyin.GetRowCellValue(i, " ") Then
                        objEtiqueta = New Entidades.ConfiguracionEtiqueta
                        objEtiqueta.ClienteId = 0
                        objEtiqueta.EtiquetaId = CInt(grdVEtiquetaYuyin.GetRowCellValue(i, "EtiquetaID"))
                        'objEtiqueta.EtiquetaClave = grdVEtiquetaYuyin.GetRowCellValue(i,"Clave").ToString
                        objEtiqueta.EtiquetaNombre = grdVEtiquetaYuyin.GetRowCellValue(i, "TipoEtiqueta").ToString
                        objEtiqueta.EtiquetaDescripcion = grdVEtiquetaYuyin.GetRowCellValue(i, "Descripcion").ToString
                        objEtiqueta.EtiquetaAncho = CInt(grdVEtiquetaYuyin.GetRowCellValue(i, "Ancho"))
                        objEtiqueta.EtiquetaAlto = CInt(grdVEtiquetaYuyin.GetRowCellValue(i, "Alto"))
                        objEtiqueta.TipoEtiqueta = grdVEtiquetaYuyin.GetRowCellValue(i, "TipoEtiqueta").ToString
                        objEtiqueta.TipoEtiquetaId = CInt(grdVEtiquetaYuyin.GetRowCellValue(i, "TipoEtiquetaID"))
                        objEtiqueta.CodigoZPL = grdVEtiquetaYuyin.GetRowCellValue(i, "CodigoZPL200")
                        objEtiqueta.EtiquetaCodigoZPL300 = grdVEtiquetaYuyin.GetRowCellValue(i, "CodigoZPL300")
                        objEtiqueta.EtiquetaVistaPrevia = grdVEtiquetaYuyin.GetRowCellValue(i, "CodigoZPLVistaPrevia")
                        objEtiqueta.EtiquetaAncho = CInt(grdVEtiquetaYuyin.GetRowCellValue(i, "Ancho"))
                        objEtiqueta.EtiquetaAlto = CInt(grdVEtiquetaYuyin.GetRowCellValue(i, "Alto"))
                        objEtiqueta.StatusEtiquetaID = CInt(grdVEtiquetaYuyin.GetRowCellValue(i, "StatusEtiquetaID"))

                        If IsDBNull(grdVEtiquetaYuyin.GetRowCellValue(i, "FechaModificacion")) = False Then
                            objEtiqueta.FechaModificacion = CDate(grdVEtiquetaYuyin.GetRowCellValue(i, "FechaModificacion"))
                        Else
                            objEtiqueta.FechaModificacion = Nothing
                        End If
                        If IsDBNull(grdVEtiquetaYuyin.GetRowCellValue(i, "UsuarioModifico")) = False Then
                            objEtiqueta.UsuarioModifico = grdVEtiquetaYuyin.GetRowCellValue(i, "UsuarioModifico")
                        Else
                            objEtiqueta.UsuarioModifico = Nothing
                        End If
                        objEtiqueta.FechaCreacion = grdVEtiquetaEspecial.GetRowCellValue(i, "FechaCreacion")
                        objEtiqueta.UsuarioCreo = grdVEtiquetaEspecial.GetRowCellValue(i, "UsuarioCreo")
                        ValidarRegistrosSeleccionado.Add(objEtiqueta)
                    End If
                Next
            ElseIf TabTipo.SelectedIndex = 2 Then 'Etiqueta de LENGUA
                For i = 0 To viewEtiquetasLengua.RowCount - 1
                    If viewEtiquetasLengua.GetRowCellValue(i, " ") Then
                        objEtiqueta = New Entidades.ConfiguracionEtiqueta
                        objEtiqueta.ClienteId = 0
                        objEtiqueta.EtiquetaId = CInt(viewEtiquetasLengua.GetRowCellValue(i, "EtiquetaID"))
                        'objEtiqueta.EtiquetaClave = grdVEtiquetaYuyin.GetRowCellValue(i,"Clave").ToString
                        objEtiqueta.EtiquetaNombre = viewEtiquetasLengua.GetRowCellValue(i, "TipoEtiqueta").ToString
                        objEtiqueta.EtiquetaDescripcion = viewEtiquetasLengua.GetRowCellValue(i, "Descripcion").ToString
                        objEtiqueta.EtiquetaAncho = CInt(viewEtiquetasLengua.GetRowCellValue(i, "Ancho"))
                        objEtiqueta.EtiquetaAlto = CInt(viewEtiquetasLengua.GetRowCellValue(i, "Alto"))
                        objEtiqueta.TipoEtiqueta = viewEtiquetasLengua.GetRowCellValue(i, "TipoEtiqueta").ToString
                        objEtiqueta.TipoEtiquetaId = CInt(viewEtiquetasLengua.GetRowCellValue(i, "TipoEtiquetaID"))
                        objEtiqueta.CodigoZPL = viewEtiquetasLengua.GetRowCellValue(i, "CodigoZPL200")
                        objEtiqueta.EtiquetaCodigoZPL300 = viewEtiquetasLengua.GetRowCellValue(i, "CodigoZPL300")
                        objEtiqueta.EtiquetaVistaPrevia = viewEtiquetasLengua.GetRowCellValue(i, "CodigoZPLVistaPrevia")
                        objEtiqueta.EtiquetaAncho = CInt(viewEtiquetasLengua.GetRowCellValue(i, "Ancho"))
                        objEtiqueta.EtiquetaAlto = CInt(viewEtiquetasLengua.GetRowCellValue(i, "Alto"))
                        objEtiqueta.StatusEtiquetaID = CInt(viewEtiquetasLengua.GetRowCellValue(i, "StatusEtiquetaID"))
                        objEtiqueta.ColeccionID = viewEtiquetasLengua.GetRowCellValue(i, "ColeccionID")
                        If IsDBNull(viewEtiquetasLengua.GetRowCellValue(i, "FechaModificacion")) = False Then
                            objEtiqueta.FechaModificacion = CDate(viewEtiquetasLengua.GetRowCellValue(i, "FechaModificacion"))
                        Else
                            objEtiqueta.FechaModificacion = Nothing
                        End If
                        If IsDBNull(viewEtiquetasLengua.GetRowCellValue(i, "UsuarioModifico")) = False Then
                            objEtiqueta.UsuarioModifico = viewEtiquetasLengua.GetRowCellValue(i, "UsuarioModifico")
                        Else
                            objEtiqueta.UsuarioModifico = Nothing
                        End If
                        If IsDBNull(viewEtiquetasLengua.GetRowCellValue(i, "FechaCreacion")) = False Then
                            objEtiqueta.FechaCreacion = viewEtiquetasLengua.GetRowCellValue(i, "FechaCreacion")
                        Else
                            objEtiqueta.FechaCreacion = Nothing
                        End If
                        If IsDBNull(viewEtiquetasLengua.GetRowCellValue(i, "UsuarioCreo")) = False Then
                            objEtiqueta.UsuarioCreo = viewEtiquetasLengua.GetRowCellValue(i, "UsuarioCreo")
                        Else
                            objEtiqueta.UsuarioCreo = Nothing
                        End If
                        ValidarRegistrosSeleccionado.Add(objEtiqueta)
                    End If
                Next
            End If
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            msg_error.mensaje = ex.Message
            msg_error.Show()
        End Try

        Return ValidarRegistrosSeleccionado

    End Function
    Private Sub grdVEtiquetaEspecial_RowClick(sender As Object, e As RowClickEventArgs) Handles grdVEtiquetaEspecial.RowClick
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ETIQUETAS_CONF_ESP", "PROG_ETIQUETAS_PPCP") Then
            If e.Clicks = 2 Then
                alta_etiqueta()
            End If
        End If


    End Sub

    Private Sub grdVEtiquetaYuyin_RowCellStyle(sender As Object, e As RowCellStyleEventArgs) Handles grdVEtiquetaYuyin.RowCellStyle
        Dim StatusId As Integer = 0

        If e.Column.FieldName = "ZPL300" Then
            If grdVEtiquetaYuyin.GetRowCellValue(e.RowHandle, "ZPL300") = "NO" Then
                e.Appearance.BackColor = Color.Orange
            End If
        End If

        If e.Column.FieldName = "ZPL200" Then
            If grdVEtiquetaYuyin.GetRowCellValue(e.RowHandle, "ZPL200") = "NO" Then
                e.Appearance.BackColor = Color.Orange
            End If
        End If

        If e.Column.FieldName = "StatusEtiqueta" Then
            StatusId = grdVEtiquetaYuyin.GetRowCellValue(e.RowHandle, "StatusEtiquetaID")

            If StatusId = 172 Then
                e.Appearance.ForeColor = Color.Orange
            ElseIf StatusId = 173 Then
                e.Appearance.ForeColor = Color.Blue
            ElseIf StatusId = 174 Then
                e.Appearance.ForeColor = Color.Green
            ElseIf StatusId = 175 Then
                e.Appearance.ForeColor = Color.Black
            ElseIf StatusId = 176 Then
                e.Appearance.ForeColor = Color.Red
            End If

        End If

        '172	PROGRAMACIÓN	1	ETIQUETAS	DISEÑO
        '173	PROGRAMACIÓN	2	ETIQUETAS	POR AUTORIZAR
        '174	PROGRAMACIÓN	3	ETIQUETAS	AUTORIZADA
        '175	PROGRAMACIÓN	4	ETIQUETAS	DESCONTINUADA
        '176	PROGRAMACIÓN	4	ETIQUETAS	RECHAZADA

    End Sub

    Private Sub grdVEtiquetaYuyin_RowClick(sender As Object, e As RowClickEventArgs) Handles grdVEtiquetaYuyin.RowClick
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ETIQUETAS_CONF_ESP", "PROG_ETIQUETAS_PPCP") Then
            If e.Clicks = 2 Then
                alta_etiqueta()
            End If
        End If
    End Sub

    Private Sub grdVEtiquetaEspecial_RowCellStyle(sender As Object, e As RowCellStyleEventArgs) Handles grdVEtiquetaEspecial.RowCellStyle
        Dim StatusId As Integer = 0

        If e.Column.FieldName = "ZPL300" Then
            If grdVEtiquetaEspecial.GetRowCellValue(e.RowHandle, "ZPL300") = "NO" Then
                e.Appearance.BackColor = Color.Orange
            End If
        End If

        If e.Column.FieldName = "ZPL200" Then
            If grdVEtiquetaEspecial.GetRowCellValue(e.RowHandle, "ZPL200") = "NO" Then
                e.Appearance.BackColor = Color.Orange
            End If
        End If

        If e.Column.FieldName = "StatusEtiqueta" Then
            StatusId = grdVEtiquetaEspecial.GetRowCellValue(e.RowHandle, "StatusEtiquetaID")

            If StatusId = 172 Then
                e.Appearance.ForeColor = Color.Orange
            ElseIf StatusId = 173 Then
                e.Appearance.ForeColor = Color.Blue
            ElseIf StatusId = 174 Then
                e.Appearance.ForeColor = Color.Green
            ElseIf StatusId = 175 Then
                e.Appearance.ForeColor = Color.Black
            ElseIf StatusId = 176 Then
                e.Appearance.ForeColor = Color.Red
            End If

        End If

        '172	PROGRAMACIÓN	1	ETIQUETAS	DISEÑO
        '173	PROGRAMACIÓN	2	ETIQUETAS	POR AUTORIZAR
        '174	PROGRAMACIÓN	3	ETIQUETAS	AUTORIZADA
        '175	PROGRAMACIÓN	4	ETIQUETAS	DESCONTINUADA
        '176	PROGRAMACIÓN	4	ETIQUETAS	RECHAZADA


    End Sub


    Private Sub btnCatalogoParametros_Click(sender As Object, e As EventArgs) Handles btnCatalogoParametros.Click
        Dim CatalogoParamForm As New ConsultarParametrosForm
        'CatalogoParamForm.MdiParent = Me.MdiParent
        CatalogoParamForm.ShowDialog()
    End Sub


    Private Sub CargarEstatusEtiquetas()
        Dim objbu As New Programacion.Negocios.EtiquetasBU
        Dim dtEstatus As New DataTable

        dtEstatus = objbu.ConsultaEstatusEtiquetas()

        cmbEstatusPedido.DataSource = dtEstatus
        cmbEstatusPedido.ValueMember = "EstatusID"
        cmbEstatusPedido.DisplayMember = "Estatus"
    End Sub

    Private Function ObtenerFiltrosEstatus() As String
        Dim EstatusID As String = String.Empty

        For Each Item As Infragistics.Win.ValueListItem In cmbEstatusPedido.Items
            If Item.CheckState = CheckState.Checked Then
                If EstatusID = String.Empty Then
                    EstatusID = Item.DataValue.ToString
                Else
                    EstatusID = EstatusID & "," & Item.DataValue.ToString
                End If
            End If
        Next
        Return EstatusID
    End Function

    Private Sub btnAutorizar_Click(sender As Object, e As EventArgs) Handles btnAutorizar.Click
        Dim ObjBU As New Programacion.Negocios.EtiquetasBU
        Dim entEtiqueta As Entidades.ConfiguracionEtiqueta
        Dim confirmar As New Tools.ConfirmarForm
        Dim EtiquetaAutorizadaID As Integer = 0

        Try
            Cursor = Cursors.WaitCursor
            entEtiqueta = ValidarUnRegistroSeleccionado()

            If IsNothing(entEtiqueta) = False Then
                If entEtiqueta.StatusEtiquetaID = 173 Then 'Status de Por Autorizar
                    confirmar.mensaje = "¿Desea AUTORIZAR el diseño de la etiqueta " & entEtiqueta.TipoEtiqueta & " de " & entEtiqueta.NombreCliente & "? (Una vez realizada esta acción, no se podrá revertir)"
                    If confirmar.ShowDialog() = Windows.Forms.DialogResult.OK Then
                        Cursor = Cursors.WaitCursor
                        EtiquetaAutorizadaID = ObjBU.AutorizarEtiqueta(entEtiqueta.EtiquetaId, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
                        LeerParametrosEtiqueta(entEtiqueta.CodigoZPL, EtiquetaAutorizadaID, 203)
                        LeerParametrosEtiqueta(entEtiqueta.EtiquetaCodigoZPL300, EtiquetaAutorizadaID, 300)

                        If entEtiqueta.ClienteId = 0 Then
                            show_message("Exito", "La " & entEtiqueta.EtiquetaDescripcion & " se actualizó al status AUTORIZADA.  Ya se pueden imprimir las etiquetas de los lotes de producción.")
                        Else
                            show_message("Exito", "La etiqueta " & entEtiqueta.TipoEtiqueta & " de " & entEtiqueta.NombreCliente & " se actualizó al status AUTORIZADA.  Ya se pueden imprimir las etiquetas de los lotes de producción.")
                        End If

                    End If
                Else
                    show_message("Advertencia", "Solo los etiquetas en por autorizar se pueden autorizar.")
                End If
            Else
                show_message("Advertencia", "No se ha seleccionado una etiqueta.")
            End If
            CargarPantalla()
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            show_message("Error", "Ocurrio un error al mostrar la información.")
        End Try

    End Sub

    Private Sub btnPorAutorizar_Click(sender As Object, e As EventArgs) Handles btnPorAutorizar.Click
        Dim ObjBU As New Programacion.Negocios.EtiquetasBU
        Dim entEtiqueta As Entidades.ConfiguracionEtiqueta
        Dim confirmar As New Tools.ConfirmarForm

        Try
            Cursor = Cursors.WaitCursor
            entEtiqueta = ValidarUnRegistroSeleccionado()
            If IsNothing(entEtiqueta) = False Then
                confirmar.mensaje = "¿Desea enviar a POR AUTORIZAR el diseño de la etiqueta  " & entEtiqueta.TipoEtiqueta & " de " & entEtiqueta.NombreCliente & "? (Una vez realizada esta acción, no se podrá revertir)"
                If entEtiqueta.StatusEtiquetaID = 172 Or entEtiqueta.StatusEtiquetaID = 176 Then '172 => Diseño, 176 => Rechazada
                    If confirmar.ShowDialog() = Windows.Forms.DialogResult.OK Then
                        ObjBU.PreAutorizarEtiqueta(entEtiqueta.EtiquetaId, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
                        show_message("Exito", "La etiqueta La etiqueta " & entEtiqueta.TipoEtiqueta & " de " & entEtiqueta.NombreCliente & " se actualizó al status POR AUTORIZAR. Espere la autorización del área de Ventas para poder imprimir las etiquetas de los lotes de producción.")
                    End If
                Else
                    show_message("Advertencia", "Solo las etiquetas con status de DISEÑO o RECHAZADAS se pueden enviar a POR AUTORIZAR.")
                End If
            Else
                show_message("Advertencia", "No se ha seleccionado una etiqueta.")
            End If
            CargarPantalla()
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            show_message("Error", "Ocurrio un error al autorizar la etiqueta.")
        End Try


    End Sub

    Public Sub show_message(ByVal tipo As String, ByVal mensaje As String)

        If tipo.ToString.Equals("Advertencia") Then

            Dim mensajeAdvertencia As New AdvertenciaForm
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
            mensajeExito.ShowDialog()

        End If

    End Sub


    Private Sub btnRechazo_Click(sender As Object, e As EventArgs) Handles btnRechazo.Click
        Dim ObjBU As New Programacion.Negocios.EtiquetasBU
        Dim entEtiqueta As Entidades.ConfiguracionEtiqueta
        Dim confirmar As New Tools.ConfirmarForm

        Try
            Cursor = Cursors.WaitCursor
            entEtiqueta = ValidarUnRegistroSeleccionado()
            If IsNothing(entEtiqueta) = False Then
                If entEtiqueta.StatusEtiquetaID = 173 Then 'Por Autorizar
                    confirmar.mensaje = "¿Desea RECHAZAR el diseño de la etiqueta " & entEtiqueta.TipoEtiqueta & " de " & entEtiqueta.NombreCliente & "? (Una vez realizada esta acción, no se podrá revertir)"
                    If confirmar.ShowDialog() = Windows.Forms.DialogResult.OK Then
                        ObjBU.RechazarEtiqueta(entEtiqueta.EtiquetaId, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
                        show_message("Exito", "La etiqueta " & entEtiqueta.TipoEtiqueta & " de " & entEtiqueta.NombreCliente & " se actualizó al status RECHAZADO, el área de PPCP deberá hacer ajustes para volver a realizar el proceso de autorización.")
                    End If
                Else
                    show_message("Advertencia", "Solo se pueden rechazar las etiquetas en status POR AUTORIZAR.")
                End If
            Else
                'show_message("Advertencia", "Ocurrio un error al cargar la información de la etiqueta.")
            End If
            CargarPantalla()
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            show_message("Error", "Ocurrio un error al autorizar la etiqueta.")
        End Try
    End Sub

    Private Sub LeerParametrosEtiqueta(ByVal ZPL As String, ByVal EtiquetaId As Integer, ByVal Resolucion As Integer)
        Dim ObjBu As New Programacion.Negocios.EtiquetasBU
        Dim dtParametros As DataTable

        dtParametros = ObjBu.ConsultarParametrosRelacionados()
        ObjBu.LimpiarParametroEtiqueta(EtiquetaId, Resolucion)

        For Each Fila As DataRow In dtParametros.Rows
            If ZPL.Contains(Fila.Item("Valor Etiqueta").ToString()) = True Then
                ObjBu.InsertarParametroEtiqueta(EtiquetaId, Fila.Item("ParametroID").ToString(), Resolucion)
            End If
        Next

    End Sub

    Private Sub btnExportarExcel_Click(sender As Object, e As EventArgs) Handles btnExportarExcel.Click
        Dim fbdUbicacionArchivo As New FolderBrowserDialog
        Dim grid As DevExpress.XtraGrid.Views.Grid.GridView
        Dim GControl As DevExpress.XtraGrid.GridControl

        Try
            With fbdUbicacionArchivo

                .Reset()
                .Description = " Seleccione una carpeta "
                .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                .ShowNewFolderButton = True

                Dim ret As DialogResult = .ShowDialog
                Dim fecha_hora As String = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString

                If TabTipo.SelectedIndex = 0 Then 'Etiquetas Cliente
                    grid = grdVEtiquetaEspecial
                    GControl = grdEtiquetaEspecial
                ElseIf TabTipo.SelectedIndex = 1 Then 'Etiquetas YUYIN
                    grid = grdVEtiquetaYuyin
                    GControl = grdEtiquetaYuyin
                ElseIf TabTipo.SelectedIndex = 2 Then 'Etiquetas de LENGUA
                    grid = viewEtiquetasLengua
                    GControl = grdEtiquetasLengua
                End If

                If ret = Windows.Forms.DialogResult.OK Then

                    If grid.GroupCount > 0 Then
                        GControl.ExportToXlsx(.SelectedPath + "\Datos_ConfiguracionEtiquetas_" + fecha_hora + ".xlsx")
                    Else
                        Dim exportOptions = New XlsxExportOptionsEx()
                        AddHandler exportOptions.CustomizeCell, AddressOf exportOptions_CustomizeCell
                        GControl.ExportToXlsx(.SelectedPath + "\Datos_ConfiguracionEtiquetas_" + fecha_hora + ".xlsx", exportOptions)
                    End If

                    show_message("Exito", "Los datos se exportaron correctamente: " & "Datos_ConfiguracionEtiquetas_" & fecha_hora.ToString() & ".xlsx")

                    .Dispose()

                    Process.Start(fbdUbicacionArchivo.SelectedPath + "\Datos_ConfiguracionEtiquetas_" + fecha_hora + ".xlsx")
                End If

            End With
        Catch ex As Exception
            show_message("Error", ex.Message.ToString())
        End Try
    End Sub

    Private Sub exportOptions_CustomizeCell(ByVal e As DevExpress.Export.CustomizeCellEventArgs)
        Dim grid As DevExpress.XtraGrid.Views.Grid.GridView
        Dim GControl As DevExpress.XtraGrid.GridControl
        Dim EstatusID As Integer

        Try

            If TabTipo.SelectedIndex = 0 Then
                grid = grdVEtiquetaEspecial
                GControl = grdEtiquetaEspecial
            ElseIf TabTipo.SelectedIndex = 1 Then
                grid = grdVEtiquetaYuyin
                GControl = grdEtiquetaYuyin
            End If

            EstatusID = grid.GetRowCellValue(e.RowHandle, "StatusEtiquetaID")

            If e.ColumnFieldName = "StatusEtiqueta" Then
                If EstatusID = 172 Then
                    e.Formatting.Font.Color = Color.Orange
                ElseIf EstatusID = 173 Then
                    e.Formatting.Font.Color = Color.Blue
                ElseIf EstatusID = 174 Then
                    e.Formatting.Font.Color = Color.Green
                ElseIf EstatusID = 175 Then
                    e.Formatting.Font.Color = Color.Black
                ElseIf EstatusID = 176 Then
                    e.Formatting.Font.Color = Color.Red
                End If
            End If

            If (e.RowHandle Mod 2) <> 0 Then
                e.Formatting.BackColor = SystemColors.ActiveCaption
            End If



        Catch ex As Exception
            show_message("Error", ex.Message.ToString())
        End Try

        e.Handled = True
    End Sub


    'Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
    '    Dim NumeroFilas As Integer = 0
    '    Dim CodigoZPL203 As String = String.Empty
    '    Dim CodigoZPL300 As String = String.Empty
    '    Dim EtiquetaId As Integer = 0

    '    Try
    '        Cursor = Cursors.WaitCursor
    '        NumeroFilas = grdVEtiquetaEspecial.DataRowCount
    '        For index As Integer = 0 To NumeroFilas Step 1
    '            CodigoZPL203 = (grdVEtiquetaEspecial.GetRowCellValue(grdVEtiquetaEspecial.GetVisibleRowHandle(index), "CodigoZPL200"))
    '            CodigoZPL300 = (grdVEtiquetaEspecial.GetRowCellValue(grdVEtiquetaEspecial.GetVisibleRowHandle(index), "CodigoZPL300"))
    '            EtiquetaId = grdVEtiquetaEspecial.GetRowCellValue(grdVEtiquetaEspecial.GetVisibleRowHandle(index), "EtiquetaID")
    '            LeerParametrosEtiquetaPorAutorizar(CodigoZPL203, EtiquetaId, 203)
    '            LeerParametrosEtiquetaPorAutorizar(CodigoZPL300, EtiquetaId, 300)
    '        Next
    '    Catch ex As Exception

    '    End Try
    'End Sub

    Private Sub LeerParametrosEtiquetaPorAutorizar(ByVal ZPL As String, ByVal EtiquetaId As Integer, ByVal Resolucion As Integer)
        Dim ObjBu As New Programacion.Negocios.EtiquetasBU
        Dim dtParametros As DataTable

        dtParametros = ObjBu.ConsultarParametrosRelacionados()

        For Each Fila As DataRow In dtParametros.Rows
            If ZPL.Contains(Fila.Item("Valor Etiqueta").ToString()) = True Then
                ObjBu.InsertarParametroEtiquetaPorAutorizar(EtiquetaId, Fila.Item("ParametroID").ToString(), Resolucion)
            End If
        Next

    End Sub

    Private Sub TabTipo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabTipo.SelectedIndexChanged
        If TabTipo.SelectedIndex = 2 Then
            btnAltaEtiquetaClienteColeccion.Enabled = True
            lblAltaEtiquetaClienteColeccion.Enabled = True
            btnInactivarLengua.Enabled = True
            lblInactivarLengua.Enabled = True
            rdbConDiseño.Visible = True
            rdbSinDiseño.Visible = True
        Else
            btnAltaEtiquetaClienteColeccion.Enabled = False
            lblAltaEtiquetaClienteColeccion.Enabled = False
            btnInactivarLengua.Enabled = False
            lblInactivarLengua.Enabled = False
            rdbConDiseño.Visible = False
            rdbSinDiseño.Visible = False
        End If
    End Sub

    Private Sub btnAutorizarLengua_Click(sender As Object, e As EventArgs) Handles btnAutorizarLengua.Click
        Dim ObjBU As New Programacion.Negocios.EtiquetasBU
        Dim entEtiqueta As List(Of Entidades.ConfiguracionEtiqueta)
        Dim confirmar As New Tools.ConfirmarForm
        Dim EtiquetaAutorizadaID As Integer = 0

        Try
            Cursor = Cursors.WaitCursor
            entEtiqueta = ValidarRegistrosSeleccionado()

            If entEtiqueta.Count > 0 Then
                If entEtiqueta.Where(Function(x) x.StatusEtiquetaID = 173).Count > 0 Then 'Status de Por Autorizar
                    Dim contador As Integer = entEtiqueta.Where(Function(x) x.StatusEtiquetaID = 173).Count
                    confirmar.mensaje = "¿Desea AUTORIZAR el diseño de las " & contador.ToString & " etiquetas seleccionadas? (Una vez realizada esta acción, no se podrá revertir)"
                    If contador = 1 Then confirmar.mensaje = "¿Desea AUTORIZAR el diseño de la etiqueta seleccionada? (Una vez realizada esta acción, no se podrá revertir)"
                    If confirmar.ShowDialog() = Windows.Forms.DialogResult.OK Then
                        For Each item In entEtiqueta.Where(Function(x) x.StatusEtiquetaID = 173)
                            Cursor = Cursors.WaitCursor
                            EtiquetaAutorizadaID = ObjBU.AutorizarEtiqueta(item.EtiquetaId, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
                            LeerParametrosEtiqueta(item.CodigoZPL, EtiquetaAutorizadaID, 203)
                            LeerParametrosEtiqueta(item.EtiquetaCodigoZPL300, EtiquetaAutorizadaID, 300)

                            'If item.ClienteId = 0 Then
                            '    show_message("Exito", "La " & item.EtiquetaDescripcion & " se actualizó al status AUTORIZADA.  Ya se pueden imprimir las etiquetas de los lotes de producción.")
                            'Else
                            '    show_message("Exito", "La etiqueta " & item.TipoEtiqueta & " de " & item.NombreCliente & " se actualizó al status AUTORIZADA.  Ya se pueden imprimir las etiquetas de los lotes de producción.")
                            'End If

                        Next
                        If contador = 1 Then
                            show_message("Exito", "La etiqueta se actualizó al status de AUTORIZADA.  Ya se pueden imprimir las etiquetas de los lotes de producción.")
                        Else
                            show_message("Exito", "Las " & contador.ToString & " etiquetas se actualizarón al status de AUTORIZADA.  Ya se pueden imprimir las etiquetas de los lotes de producción.")
                        End If
                    End If
                Else
                    show_message("Advertencia", "Solo las etiquetas en por autorizar se pueden autorizar.")
                End If
            Else
                show_message("Advertencia", "No se ha seleccionado una etiqueta.")
            End If
            CargarPantalla()
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            show_message("Error", "Ocurrio un error al mostrar la información.")
        End Try
    End Sub

    Private Sub btnRechazarLengua_Click(sender As Object, e As EventArgs) Handles btnRechazarLengua.Click
        Dim ObjBU As New Programacion.Negocios.EtiquetasBU
        Dim entEtiqueta As Entidades.ConfiguracionEtiqueta
        Dim confirmar As New Tools.ConfirmarForm

        Try
            Cursor = Cursors.WaitCursor
            entEtiqueta = ValidarUnRegistroSeleccionado()
            If IsNothing(entEtiqueta) = False Then
                If entEtiqueta.StatusEtiquetaID = 173 Then 'Por Autorizar
                    confirmar.mensaje = "¿Desea RECHAZAR el diseño de la etiqueta " & entEtiqueta.TipoEtiqueta & " de " & entEtiqueta.NombreCliente & "? (Una vez realizada esta acción, no se podrá revertir)"
                    If confirmar.ShowDialog() = Windows.Forms.DialogResult.OK Then
                        ObjBU.RechazarEtiqueta(entEtiqueta.EtiquetaId, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
                        show_message("Exito", "La etiqueta " & entEtiqueta.TipoEtiqueta & " de " & entEtiqueta.NombreCliente & " se actualizó al status RECHAZADO, el área de PPCP deberá hacer ajustes para volver a realizar el proceso de autorización.")
                    End If
                Else
                    show_message("Advertencia", "Solo se pueden rechazar las etiquetas en status POR AUTORIZAR.")
                End If
            Else
                'show_message("Advertencia", "Ocurrio un error al cargar la información de la etiqueta.")
            End If
            CargarPantalla()
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            show_message("Error", "Ocurrio un error al autorizar la etiqueta.")
        End Try
    End Sub
    Private Sub viewEtiquetasLengua_CustomRowCellEdit(sender As Object, e As DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs) Handles viewEtiquetasLengua.CustomRowCellEdit
        If e.Column.FieldName = " " And viewEtiquetasLengua.GetRowCellValue(e.RowHandle, "ZPL200") <> "SI" And viewEtiquetasLengua.GetRowCellValue(e.RowHandle, "ZPL300") <> "SI" Then
            emptyEditor = New RepositoryItem
            e.RepositoryItem = emptyEditor
        End If
    End Sub

    Private Sub rdbConDiseño_CheckedChanged(sender As Object, e As EventArgs) Handles rdbConDiseño.CheckedChanged
        If rdbConDiseño.Checked And TabTipo.SelectedIndex = 2 Then
            rdbSinDiseño.Checked = False
            btnInactivarLengua.Enabled = True
            lblInactivarLengua.Enabled = True
        End If
    End Sub

    Private Sub rdbSinDiseño_CheckedChanged(sender As Object, e As EventArgs) Handles rdbSinDiseño.CheckedChanged
        If rdbSinDiseño.Checked Then
            rdbConDiseño.Checked = False
            btnInactivarLengua.Enabled = False
        End If
    End Sub

    Private Sub btnInactivarLengua_Click(sender As Object, e As EventArgs) Handles btnInactivarLengua.Click
        Dim ObjBU As New Programacion.Negocios.EtiquetasBU
        Dim entEtiqueta As List(Of Entidades.ConfiguracionEtiqueta)
        Dim confirmar As New Tools.ConfirmarForm
        Dim EtiquetaAutorizadaID As Integer = 0

        Try
            Cursor = Cursors.WaitCursor
            entEtiqueta = ValidarRegistrosSeleccionado()

            If entEtiqueta.Count > 0 Then
                Dim contador As Integer = entEtiqueta.Count
                confirmar.mensaje = "¿Desea INACTIVAR el diseño de las " & contador.ToString & " etiquetas seleccionadas? (Una vez realizada esta acción, no se podrá revertir)"
                If contador = 1 Then confirmar.mensaje = "¿Desea INACTIVAR el diseño de la etiqueta seleccionada? (Una vez realizada esta acción, no se podrá revertir)"
                If confirmar.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    For Each item In entEtiqueta
                        Cursor = Cursors.WaitCursor
                        ObjBU.InactivarEtiquetaLengua(item.EtiquetaId, item.StatusEtiquetaID)
                    Next
                    If contador = 1 Then
                        show_message("Exito", "La etiqueta se ha inactivado.")
                    Else
                        show_message("Exito", "Las " & contador.ToString & " etiquetas se han inactivado.")
                    End If
                    cargarGridEtiquetaLengua()
                End If
            Else
                show_message("Advertencia", "No se ha seleccionado una etiqueta.")
            End If
            CargarPantalla()
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            show_message("Error", "Ocurrio un error al mostrar la información.")
        End Try
    End Sub
End Class



