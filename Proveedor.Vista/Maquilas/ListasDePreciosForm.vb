Imports Proveedores.BU
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.ExcelExport
Imports Tools
Imports System.Drawing
Imports System.Windows.Forms
Imports Entidades
Imports Stimulsoft.Report
Imports System.Net.Mail
Imports Stimulsoft.Report.Export
Imports System.ComponentModel
Imports System.Net.Mime
Imports Framework.Negocios


Public Class ListasDePreciosForm
    Dim idNave As Integer = 0
    Dim idEmpresa As Integer = 0
    Dim idMarca As String = ""
    Dim idColeccion As String = ""
    Dim EstatusSQL As String = ""
    Dim capturada As String = ""
    Dim autorizada As String = ""
    Dim rechazada As String = ""
    Dim vigente As Boolean = False
    Dim adv As New AdvertenciaForm
    Dim mensajeAviso As New AvisoForm
    Dim destinatarios As String = ""

    Private Sub bntSalir_Click(sender As Object, e As EventArgs) Handles bntSalir.Click
        Me.Close()
    End Sub

    Private Sub ListasDePreciosForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        ' pnlListayprecios.Visible = False

        'tbtPrecios.Visible = False
        llenarComboNaves()
        aplicarPermisos()
        llenarComercializadora()
        CheckForIllegalCrossThreadCalls = False
    End Sub
    Public Sub aplicarPermisos()
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ListasDePrecio", "ALTAPRECIOS") Then
            pnlAlta.Visible = True
        Else
            pnlAlta.Visible = False
        End If
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ListasDePrecio", "EDITARPRECIOS") Then
            pnlEditar.Visible = True
        Else
            pnlEditar.Visible = False
        End If
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ListasDePrecio", "COPIARLISTA") Then
            pnlCopiar.Visible = True
        Else
            pnlCopiar.Visible = False
        End If
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ListasDePrecio", "IMPRIMIR") Then
            pnlImprimir.Visible = True
        Else
            pnlImprimir.Visible = False
        End If
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ListasDePrecio", "ENVIARAUTORIZACION") Then
            pnlEnviar.Visible = True
        Else
            pnlEnviar.Visible = False
        End If
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ListasDePrecio", "AUTORIZAR") Then
            pnlAutorizar.Visible = True
        Else
            pnlAutorizar.Visible = False
        End If
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ListasDePrecio", "REVERTIRAUTORIZACION") Then
            pnlRevertir.Visible = True
        Else
            pnlRevertir.Visible = False
        End If
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ListasDePrecio", "RECHAZAR") Then
            pnlRechazar.Visible = True
        Else
            pnlRechazar.Visible = False
        End If

        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ListasDePrecio", "EXPORTAR") Then
            pnlExportar.Visible = True
        Else
            pnlExportar.Visible = False
        End If

        'If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ListasDePrecio", "PRV_PRCIOS_COMPRA") And Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ListasDePrecio", "PRV_PRCIOS_VENTA") Then
        '    'PESTAÑA CCOMPRA.Visible = True
        '    'tbtPrecios.SelectedTab = tbtPrecioCompra
        '    '  tbtPrecios.TabPages.Add(tbtPrecios.TabPages("tbtPrecioVenta"))
        '    ' tbtPrecios.TabPages.Add(tbtPrecios.TabPages("tbtPrecioCompra"))
        '    '  tbtPrecios.TabPages.Remove(tbtPrecios.TabPages("tbtPrecioVenta"))
        'ElseIf Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ListasDePrecio", "PRV_PRCIOS_VENTA") Then
        '    tbtPrecios.TabPages.Remove(tbtPrecios.TabPages("tbtPrecioCompra"))

        'ElseIf Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ListasDePrecio", "PRV_PRCIOS_COMPRA") Then
        '    tbtPrecios.TabPages.Remove(tbtPrecios.TabPages("tbtPrecioVenta"))
        '    ' tbtPrecios.TabPages.Add(tbtPrecios.TabPages("tbtPrecioCompra"))
        'End If
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ListasDePrecio", "PRV_PRCIOS_COMPRA") And Not (Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ListasDePrecio", "PRV_PRCIOS_VENTA")) Then
            tbtPrecios.TabPages.Remove(tbtPrecios.TabPages("tbtPrecioVenta"))
        ElseIf Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ListasDePrecio", "PRV_PRCIOS_VENTA") And Not (Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ListasDePrecio", "PRV_PRCIOS_COMPRA")) Then
            tbtPrecios.TabPages.Remove(tbtPrecios.TabPages("tbtPrecioCompra"))
        End If
    End Sub
    Public Sub llenarComboNaves()
        cmbNave = Controles.ComboNavesSegunUsuario(cmbNave, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
        If cmbNave.Items.Count = 2 Then
            cmbNave.SelectedIndex = 1
        End If
    End Sub
    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Dim form As New AltaEditarListaPrecios
        If tbtPrecios.SelectedTab Is tbtPrecioCompra Then
            form.lblTipoPrecio.Text = "COMPRA"
        Else
            form.lblTipoPrecio.Text = "VENTA"
        End If

        form.nuevo = True
        form.ShowDialog()
        llenarGrid()
        If tbtPrecios.SelectedTab Is tbtPrecioCompra Then
            pintarceldas()
        Else
            pintarceldaslistaVentas()
        End If

    End Sub

    Private Sub btnUp_Click(sender As Object, e As EventArgs) Handles btnUp.Click
        grbParametros.Height = 30
    End Sub

    Private Sub btnDown_Click(sender As Object, e As EventArgs) Handles btnDown.Click
        grbParametros.Height = 92
    End Sub

    Private Sub rdo1_CheckedChanged(sender As Object, e As EventArgs) Handles rdo1.CheckedChanged
        If rdo1.Checked = True Then
            pnlListayprecios.Visible = False
            tbtPrecios.Visible = False
            chkSeleccionar.Visible = False
            pnlListas.Visible = True
            grdListaPrecios.Visible = True
            btnDown.PerformClick()
            chkSeleccionar.Visible = False

            cmbMarca.Enabled = False
            cmbColeccion.Enabled = False
        End If
    End Sub

    Private Sub rdo2_CheckedChanged(sender As Object, e As EventArgs) Handles rdo2.CheckedChanged
        If rdo2.Checked = True Then
            pnlListas.Visible = False
            pnlListayprecios.Visible = True
            tbtPrecios.Visible = True
            grdListaPrecios.Visible = False
            cmbMarca.Enabled = True
            cmbColeccion.Enabled = True
            btnDown.PerformClick()
            chkSeleccionar.Visible = True

            If idNave > 0 Then
                cmbMarca.Enabled = True
                llenarMarcas()
            Else
                cmbMarca.Enabled = False
            End If
        End If
    End Sub

    Private Sub cmbNave_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbNave.SelectedIndexChanged
        If cmbNave.SelectedIndex > 0 Then
            idNave = cmbNave.SelectedValue

            If rdo2.Checked = True Then
                cmbMarca.Enabled = True
                llenarMarcas()
            End If
        Else
            cmbMarca.Enabled = False
        End If
    End Sub
    Public Sub llenarMarcas()
        Dim obj As New ListaPreciosProdBU
        Dim lst As New DataTable
        '   If cmbComercializadora.SelectedValue > 0 Then
        If cmbComercializadora.SelectedValue.ToString <> "" And cmbComercializadora.Text.ToString <> "" Then
            lst = obj.getMarcas(idNave, cmbComercializadora.SelectedValue)
            If Not lst.Rows.Count = 0 Then
                lst.Rows.InsertAt(lst.NewRow, 0)
                cmbMarca.DataSource = lst
                cmbMarca.DisplayMember = "Marca"
                cmbMarca.ValueMember = "IdMarca"
            Else
                cmbMarca.DataSource = lst
            End If
        Else
            adv.mensaje = "Seleccione una Comercializadora"
            adv.ShowDialog()
        End If

    End Sub

    Public Sub llenarComercializadora()
        Dim obj As New ListaPreciosProdBU
        Dim lst As New DataTable
        lst = obj.getcomercializadoras()
        If Not lst.Rows.Count = 0 Then
            lst.Rows.InsertAt(lst.NewRow, 0)
            cmbComercializadora.DataSource = lst
            cmbComercializadora.DisplayMember = "Nombre"
            cmbComercializadora.ValueMember = "Id"
            cmbComercializadora.SelectedIndex = 1
        End If
    End Sub
    Public Sub llenarColecciones()
        Dim obj As New ListaPreciosProdBU
        Dim lst As New DataTable
        lst = obj.getColecciones(idNave, idMarca)
        If Not lst.Rows.Count = 0 Then
            lst.Rows.InsertAt(lst.NewRow, 0)
            cmbColeccion.DataSource = lst
            cmbColeccion.DisplayMember = "Coleccion"
            cmbColeccion.ValueMember = "IdColeccion"
            cmbColeccion.SelectedIndex = 1
        End If
    End Sub

    Private Sub cmbMarca_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbMarca.SelectedIndexChanged
        If cmbMarca.SelectedIndex > 0 Then
            idMarca = cmbMarca.SelectedValue
            cmbColeccion.Enabled = True
            llenarColecciones()
        Else
            cmbColeccion.Enabled = False
        End If
    End Sub

    Private Sub cmbColeccion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbColeccion.SelectedIndexChanged
        If cmbColeccion.SelectedIndex > 0 Then
            idColeccion = cmbColeccion.SelectedValue
            '  llenarGrid()
            'disenioGrid()
        End If
    End Sub

    Function valPreciosCero(datos As DataTable)
        Dim precios As New DataTable
        Dim obj As New ListaPreciosProdBU
        For Each row As DataRow In datos.Rows
            precios = obj.getPreciosLista(row("idLista"), row("IdMarca"), row("IdColeccion"), row("IdNave"))
            If precios.Rows.Count > 0 Then
                row("SinPreciosCapturados") = 1
            End If
        Next
        Return datos
    End Function

    Public Sub llenarGrid()
        Cursor = Cursors.WaitCursor
        Dim obj As New ListaPreciosProdBU
        Dim datos As New DataTable
        Dim PrecioCompra_Venta As Integer = 1
        If rdo1.Checked = True Then
            pnlListayprecios.Visible = False
            pnlListas.Visible = True
            chkSeleccionar.Visible = False
        Else
            pnlListayprecios.Visible = True
            tbtPrecios.Visible = True
            pnlListas.Visible = False
            chkSeleccionar.Visible = True





        End If
        'pnlListayprecios.Visible = True
        'pnlListas.Visible = False

        If tbtPrecios.SelectedTab Is tbtPrecioVenta Then
            PrecioCompra_Venta = 1
        Else

            PrecioCompra_Venta = 0
        End If


        If cmbComercializadora.SelectedIndex > 0 Then
                If cmbNave.SelectedValue > 0 Then
                    Dim Estatus As String = ""
                    If vigente = True Then
                        autorizada = "AUTORIZADA"
                    End If

                    If rdo1.Checked = True Then
                        Estatus = capturada & "," & autorizada & "," & rechazada & "," & vigente
                        'datos = obj.getDatosListas(capturada, autorizada, rechazada, vigente, obj.getNaveSIcy(cmbNave.SelectedValue))
                        datos = obj.getDatosListas(Estatus, obj.getNaveSIcy(cmbNave.SelectedValue), vigente, idEmpresa)
                        '  grdListaPrecios.DataSource = valPreciosCero(datos)
                        grdListaPrecios.DataSource = datos
                        '   grdListasPreciosCompra.DataSource = datos
                    Else
                    If cmbMarca.SelectedIndex <= 0 Then
                        idMarca = "NA" 'NO SELECCIONARON MARCA
                    End If
                    If cmbColeccion.Enabled = False Then
                        idColeccion = "NA" 'NO SELECCIONARON COLECCIÓN
                    Else
                        If cmbColeccion.SelectedIndex <= 0 Then
                            idColeccion = "NA" 'NO SELECCIONARON COLECCIÓN
                        End If
                    End If

                    Estatus = capturada & "," & autorizada & "," & rechazada & "," & vigente
                        'datos = obj.getDatosListasPrecios(capturada, autorizada, rechazada, vigente, idMarca, idColeccion, obj.getNaveSIcy(cmbNave.SelectedValue))
                        datos = obj.getDatosListasPrecios(Estatus, vigente, idMarca, idColeccion, obj.getNaveSIcy(cmbNave.SelectedValue), 0, idEmpresa)
                        grdListasPreciosCompra.DataSource = datos
                        datos = obj.getDatosListasPrecios(Estatus, vigente, idMarca, idColeccion, obj.getNaveSIcy(cmbNave.SelectedValue), 1, idEmpresa)
                        'If tbtPrecios.SelectedTab Is tbtPrecioVenta Then
                        grdListasPreciosVenta.DataSource = datos
                        'Else


                        'End If


                    End If
                Else
                    adv.mensaje = "Seleccione una nave"
                    adv.ShowDialog()
                End If
            Else
                adv.mensaje = "Seleccione una Comercializadora"
                adv.ShowDialog()

            End If

        Cursor = Cursors.Default
        If rdo1.Checked = True Then
            If grdListaPrecios.Rows.Count > 0 Then
                btnUp_Click(Nothing, Nothing)
            Else
                chkSeleccionar.Visible = False
                mensajeAviso.mensaje = "No hay datos para mostrar"
                mensajeAviso.ShowDialog()
            End If
        Else

            If grdListasPreciosCompra.Rows.Count > 0 Or grdListasPreciosVenta.Rows.Count > 0 Then
                btnUp_Click(Nothing, Nothing)
            Else
                chkSeleccionar.Visible = False
                mensajeAviso.mensaje = "No hay datos para mostrar"
                mensajeAviso.ShowDialog()
            End If
        End If

    End Sub

    Private Sub chkCapturada_CheckedChanged(sender As Object, e As EventArgs) Handles chkCapturada.CheckedChanged
        If chkCapturada.Checked = True Then
            capturada = "CAPTURADA"
        Else
            capturada = ""
        End If
    End Sub

    Private Sub chkAutorizada_CheckedChanged(sender As Object, e As EventArgs) Handles chkAutorizada.CheckedChanged
        If chkAutorizada.Checked = True Then
            autorizada = "AUTORIZADA"
        Else
            autorizada = ""
        End If
    End Sub

    Private Sub chkVigente_CheckedChanged(sender As Object, e As EventArgs) Handles chkVigente.CheckedChanged
        If chkVigente.Checked = True Then
            vigente = True
        Else
            vigente = False
        End If
    End Sub

    Private Sub chkRechazada_CheckedChanged(sender As Object, e As EventArgs) Handles chkRechazada.CheckedChanged
        If chkRechazada.Checked = True Then
            rechazada = "RECHAZADA"
        Else
            rechazada = ""
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        llenarGrid()
        'disenioGrid()
    End Sub

    Public Sub disenioGrid()
        Try
            With grdListasPreciosCompra.DisplayLayout.Bands(0)
                .Columns("IdLista").Hidden = True
                .Columns("IdNave").Hidden = True
                .Columns("Estatus").Hidden = True
                .Columns("IdColeccion").Hidden = True
                .Columns("IdMarca").Hidden = True
                If rdo2.Checked = True Then 'Listas y precios
                    .Columns("Precio").Format = "####0.00"
                    .Columns("idPrecio").Hidden = True
                    grdListasPreciosCompra.DisplayLayout.AutoFitStyle = AutoFitStyle.None
                    .PerformAutoResizeColumns(True, PerformAutoSizeType.AllRowsInBand)
                Else
                    .Columns("SinPreciosCapturados").Hidden = True
                    grdListasPreciosCompra.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
                End If
                '.Columns("Seleccion").Header.CheckBoxVisibility = HeaderCheckBoxVisibility.WhenUsingCheckEditor
                .Columns("Seleccion").Header.CheckBoxAlignment = HeaderCheckBoxAlignment.Right
                '.Columns("Seleccion").Header.CheckBoxSynchronization = HeaderCheckBoxSynchronization.RowsCollection
                .Columns("Seleccion").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
                .Columns("Seleccion").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
                .Columns("Seleccion").Header.Caption = " "
                .Columns("pintar").Header.Caption = " "
                If rdo1.Checked = False Then
                    .Columns("Precio").Header.Caption = "Precio Compra"
                    .Columns("Precio").Width = 90
                End If

                .Columns("Seleccion").AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False
                .Columns("Marca").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                .Columns("Colección").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                '  grdListaPrecios.DisplayLayout.Scrollbars = Infragistics.Win.UltraWinGrid.Scrollbars.Horizontal
                .Columns("Seleccion").Width = 10
                .Columns("pintar").Width = 15
                .Columns("Colección").Width = 100

                .Columns("Inicio").Width = 62
                .Columns("Fin").Width = 62
                .Columns("FCreación").Width = 62
                '.Columns("Precio").Width = 90
                .Columns("FAutorización").Width = 95
                .Columns("FModificación").Width = 90
                .Columns("FCreación").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DateTime
                .Columns("FModificación").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DateTime
                If .Columns.Exists("FAutorización") = True Then
                    .Columns("FAutorización").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DateTime
                End If
            End With

            grdListasPreciosCompra.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            'grdListas.DisplayLayout.Bands(0).RowLayoutStyle = RowLayoutStyle.ColumnLayout
            pintarceldas()
        Catch ex As Exception
            Dim vError As New Tools.ErroresForm
            vError.mensaje = "Ocurrió un error: " & ex.Message
            vError.ShowDialog()
        End Try
    End Sub
    Public Sub disenioGridVenta()
        Try
            With grdListasPreciosVenta.DisplayLayout.Bands(0)
                .Columns("IdLista").Hidden = True
                .Columns("IdNave").Hidden = True
                .Columns("Estatus").Hidden = True
                .Columns("IdColeccion").Hidden = True
                .Columns("IdMarca").Hidden = True
                If rdo2.Checked = True Then 'Listas y precios
                    .Columns("Precio").Format = "####0.00"
                    .Columns("idPrecio").Hidden = True
                    grdListasPreciosVenta.DisplayLayout.AutoFitStyle = AutoFitStyle.None
                    .PerformAutoResizeColumns(True, PerformAutoSizeType.AllRowsInBand)
                Else
                    .Columns("SinPreciosCapturados").Hidden = True
                    grdListasPreciosVenta.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
                End If
                '.Columns("Seleccion").Header.CheckBoxVisibility = HeaderCheckBoxVisibility.WhenUsingCheckEditor
                .Columns("Seleccion").Header.CheckBoxAlignment = HeaderCheckBoxAlignment.Right
                '.Columns("Seleccion").Header.CheckBoxSynchronization = HeaderCheckBoxSynchronization.RowsCollection
                .Columns("Seleccion").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
                .Columns("Seleccion").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
                .Columns("Seleccion").Header.Caption = " "
                .Columns("pintar").Header.Caption = " "
                .Columns("Precio").Header.Caption = "Precio  Venta"
                .Columns("Seleccion").AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False
                .Columns("Marca").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                .Columns("Colección").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                '  grdListaPrecios.DisplayLayout.Scrollbars = Infragistics.Win.UltraWinGrid.Scrollbars.Horizontal
                .Columns("Seleccion").Width = 10
                .Columns("pintar").Width = 15
                .Columns("Colección").Width = 100
                .Columns("Inicio").Width = 62
                .Columns("Fin").Width = 62
                .Columns("FCreación").Width = 62
                .Columns("Precio").Width = 90
                .Columns("FAutorización").Width = 90
                .Columns("FModificación").Width = 90
                .Columns("FCreación").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DateTime
                .Columns("FModificación").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DateTime
                If .Columns.Exists("FAutorización") = True Then
                    .Columns("FAutorización").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DateTime
                End If

            End With

            grdListasPreciosVenta.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            'grdListas.DisplayLayout.Bands(0).RowLayoutStyle = RowLayoutStyle.ColumnLayout
            pintarceldaslistaVentas()
        Catch ex As Exception
            Dim vError As New Tools.ErroresForm
            vError.mensaje = "Ocurrió un error: " & ex.Message
            vError.ShowDialog()
        End Try
    End Sub


    Public Sub pintarceldas()
        Try
            Dim conPrecio As Integer = 0
            Dim sinPrecio As Integer = 0
            Dim i As Integer = 0


            If grdListasPreciosCompra.Rows.Count > 0 Then 'Or grdListasPreciosVenta.Rows.Count > 0 Then
                Do
                    'If rdo1.Checked = True Then 'Listas
                    '    If   grdListaPrecios.Rows(i).Cells("SinPreciosCapturados").Value > 0 Then
                    '          grdListaPrecios.Rows(i).Appearance.BackColor = Color.Crimson
                    '    End If
                    'Else 'Listas y precios
                    If grdListasPreciosCompra.Rows(i).Cells("Precio").Value = 0 Then
                        grdListasPreciosCompra.Rows(i).Appearance.BackColor = Color.Crimson
                    End If

                    'If grdListasPreciosVenta.Rows(i).Cells("Precio").Value = 0 Then
                    '    grdListasPreciosVenta.Rows(i).Appearance.BackColor = Color.Crimson
                    'End If
                    'End If
                    If grdListasPreciosCompra.Rows(i).Cells("Estatus").Value = "CAPTURADA" Then
                        grdListasPreciosCompra.Rows(i).Cells("pintar").Appearance.BackColor = Color.Yellow
                    ElseIf grdListasPreciosCompra.Rows(i).Cells("Estatus").Value = "AUTORIZADA" Then
                        grdListasPreciosCompra.Rows(i).Cells("pintar").Appearance.BackColor = Color.GreenYellow
                    ElseIf grdListasPreciosCompra.Rows(i).Cells("Estatus").Value = "RECHAZADA" Then
                        grdListasPreciosCompra.Rows(i).Cells("pintar").Appearance.BackColor = Color.Salmon
                    End If
                    'If grdListasPreciosVenta.Rows(i).Cells("Estatus").Value = "CAPTURADA" Then
                    '    grdListasPreciosVenta.Rows(i).Cells("pintar").Appearance.BackColor = Color.Yellow
                    'ElseIf grdListasPreciosVenta.Rows(i).Cells("Estatus").Value = "AUTORIZADA" Then
                    '    grdListasPreciosVenta.Rows(i).Cells("pintar").Appearance.BackColor = Color.GreenYellow
                    'ElseIf grdListasPreciosVenta.Rows(i).Cells("Estatus").Value = "RECHAZADA" Then
                    '    grdListasPreciosVenta.Rows(i).Cells("pintar").Appearance.BackColor = Color.Salmon
                    'End If
                    i += 1
                Loop While i < grdListasPreciosCompra.Rows.Count
            End If

        Catch ex As Exception
            Dim vError As New Tools.ErroresForm
            vError.mensaje = "Ocurrió un error: " + ex.Message
            vError.ShowDialog()
        End Try
    End Sub

    Public Sub pintarceldaslistaVentas()
        Try
            Dim conPrecio As Integer = 0
            Dim sinPrecio As Integer = 0
            Dim i As Integer = 0


            If grdListasPreciosVenta.Rows.Count > 0 Then
                Do

                    If grdListasPreciosVenta.Rows(i).Cells("Precio").Value = 0 Then
                        grdListasPreciosVenta.Rows(i).Appearance.BackColor = Color.Crimson
                    End If

                    If grdListasPreciosVenta.Rows(i).Cells("Estatus").Value = "CAPTURADA" Then
                        grdListasPreciosVenta.Rows(i).Cells("pintar").Appearance.BackColor = Color.Yellow
                    ElseIf grdListasPreciosVenta.Rows(i).Cells("Estatus").Value = "AUTORIZADA" Then
                        grdListasPreciosVenta.Rows(i).Cells("pintar").Appearance.BackColor = Color.GreenYellow
                    ElseIf grdListasPreciosVenta.Rows(i).Cells("Estatus").Value = "RECHAZADA" Then
                        grdListasPreciosVenta.Rows(i).Cells("pintar").Appearance.BackColor = Color.Salmon
                    End If
                    i += 1
                Loop While i < grdListasPreciosVenta.Rows.Count
            End If

        Catch ex As Exception
            Dim vError As New Tools.ErroresForm
            vError.mensaje = "Ocurrió un error: " + ex.Message
            vError.ShowDialog()
        End Try
    End Sub
    Public Sub pintarceldaslista()
        Try
            Dim conPrecio As Integer = 0
            Dim sinPrecio As Integer = 0
            Dim i As Integer = 0

            If grdListaPrecios.Rows.Count > 0 Then
                Do
                    If grdListaPrecios.Rows(i).Cells("SinPreciosCapturados").Value > 0 Then
                        grdListaPrecios.Rows(i).Appearance.BackColor = Color.Crimson
                    End If
                    i += 1
                Loop While i < grdListaPrecios.Rows.Count
            End If

        Catch ex As Exception
            Dim vError As New Tools.ErroresForm
            vError.mensaje = "Ocurrió un error: " + ex.Message
            vError.ShowDialog()
        End Try
    End Sub

    'Private Sub   grdListaPrecios_ClickCell(sender As Object, e As ClickCellEventArgs) Handles   grdListasPreciosCompra.ClickCell
    '    Try
    '        If   grdListasPreciosCompra.ActiveRow.Cells("Seleccion").IsActiveCell Then
    '              grdListasPreciosCompra.ActiveRow.Selected = False
    '        Else
    '              grdListasPreciosCompra.ActiveRow.Selected = True
    '        End If
    '    Catch ex As Exception
    '    End Try
    'End Sub
    Public Sub editar()
        If grdListasPreciosCompra.Rows.Count > 0 Then
            Try

                If grdListasPreciosCompra.ActiveRow.Selected Then
                    Me.Cursor = Cursors.WaitCursor
                    Dim obj As New ListaPreciosProdBU
                    Dim form As New AltaEditarListaPrecios
                    Dim estatus As String = ""
                    form.idNave = obj.getNaveSAY(Convert.ToInt32(grdListasPreciosCompra.ActiveRow.Cells("IdNave").Text))
                    form.idNavetmp = Convert.ToInt32(grdListasPreciosCompra.ActiveRow.Cells("IdNave").Text)
                    form.editar = True
                    form.idMarca = grdListasPreciosCompra.ActiveRow.Cells("IdMarca").Text
                    form.idColeccion = grdListasPreciosCompra.ActiveRow.Cells("IdColeccion").Text
                    form.nombreLista = grdListasPreciosCompra.ActiveRow.Cells("Nombre Lista").Text
                    form.idLista = grdListasPreciosCompra.ActiveRow.Cells("IdLista").Text
                    form.dtpFechaInicio.Value = grdListasPreciosCompra.ActiveRow.Cells("Inicio").Value
                    form.dtpFechaFinal.Value = grdListasPreciosCompra.ActiveRow.Cells("Fin").Text
                    estatus = grdListasPreciosCompra.ActiveRow.Cells("Estatus").Text
                    form.lblTipo.Text = estatus
                    If tbtPrecios.SelectedTab Is tbtPrecioVenta Then
                        form.lblTipoPrecio.Text = "VENTA"
                    Else
                        form.lblTipoPrecio.Text = "COMPRA"
                    End If
                    If estatus = "CAPTURADA" Then
                        form.lblTipo.ForeColor = Color.DarkOrange
                        form.lblTipoPrecio.ForeColor = Color.DarkOrange
                    ElseIf estatus = "RECHAZADA" Then
                        'form.lblEstatus.Text = estatus
                        form.lblTipo.ForeColor = Color.Salmon
                        form.lblTipoPrecio.ForeColor = Color.Salmon
                    ElseIf estatus = "AUTORIZADA" Then
                        'form.lblEstatus.Text = estatus
                        form.lblTipo.ForeColor = Color.Green
                        form.lblTipoPrecio.ForeColor = Color.Green
                    End If
                    form.ShowDialog()
                    llenarGrid()
                    If tbtPrecios.SelectedTab Is tbtPrecioVenta Then
                        pintarceldaslistaVentas()

                    Else
                        pintarceldas()

                    End If
                    'pintarceldas()
                    Me.Cursor = Cursors.Default
                End If
            Catch ex As Exception
                Dim ventanaMensaje As New Tools.AdvertenciaForm
                ventanaMensaje.mensaje = "Seleccione un registro"
                ventanaMensaje.ShowDialog()
            End Try

        End If
    End Sub
    Public Sub editarVentas()
        If grdListasPreciosVenta.Rows.Count > 0 Then
            Try

                If grdListasPreciosVenta.ActiveRow.Selected Then
                    Me.Cursor = Cursors.WaitCursor
                    Dim obj As New ListaPreciosProdBU
                    Dim form As New AltaEditarListaPrecios
                    Dim estatus As String = ""
                    form.idNave = obj.getNaveSAY(Convert.ToInt32(grdListasPreciosVenta.ActiveRow.Cells("IdNave").Text))
                    form.idNavetmp = Convert.ToInt32(grdListasPreciosVenta.ActiveRow.Cells("IdNave").Text)
                    form.editar = True
                    form.idMarca = grdListasPreciosVenta.ActiveRow.Cells("IdMarca").Text
                    form.idColeccion = grdListasPreciosVenta.ActiveRow.Cells("IdColeccion").Text
                    form.nombreLista = grdListasPreciosVenta.ActiveRow.Cells("Nombre Lista").Text
                    form.idLista = grdListasPreciosVenta.ActiveRow.Cells("IdLista").Text
                    form.dtpFechaInicio.Value = grdListasPreciosVenta.ActiveRow.Cells("Inicio").Value
                    form.dtpFechaFinal.Value = grdListasPreciosVenta.ActiveRow.Cells("Fin").Text
                    estatus = grdListasPreciosVenta.ActiveRow.Cells("Estatus").Text
                    form.lblTipo.Text = estatus

                    form.lblTipoPrecio.Text = "VENTA"

                    If estatus = "CAPTURADA" Then
                        form.lblTipo.ForeColor = Color.DarkOrange
                        form.lblTipoPrecio.ForeColor = Color.DarkOrange
                    ElseIf estatus = "RECHAZADA" Then
                        'form.lblEstatus.Text = estatus
                        form.lblTipo.ForeColor = Color.Salmon
                        form.lblTipoPrecio.ForeColor = Color.Salmon
                    ElseIf estatus = "AUTORIZADA" Then
                        'form.lblEstatus.Text = estatus
                        form.lblTipo.ForeColor = Color.Green
                        form.lblTipoPrecio.ForeColor = Color.Green
                    End If
                    form.ShowDialog()
                    llenarGrid()
                    pintarceldaslistaVentas()

                    Me.Cursor = Cursors.Default
                End If
            Catch ex As Exception
                Dim ventanaMensaje As New Tools.AdvertenciaForm
                ventanaMensaje.mensaje = "Seleccione un registro"
                ventanaMensaje.ShowDialog()
            End Try

        End If
    End Sub
    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        If tbtPrecios.SelectedTab Is tbtPrecioVenta Then

            editarVentas()
        Else
            editar()

        End If

    End Sub
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles btnAutorizar.Click
        Dim lista As New List(Of Integer)
        If tbtPrecios.SelectedTab Is tbtPrecioVenta Then
            For Each row As UltraGridRow In grdListasPreciosVenta.Rows
                If CBool(row.Cells("Seleccion").Value) Then
                    If row.Cells("Estatus").Value = "CAPTURADA" Then
                        lista.Add(Convert.ToInt32(row.Cells("IdLista").Value))
                    End If
                End If
            Next
        Else
            For Each row As UltraGridRow In grdListasPreciosCompra.Rows
                If CBool(row.Cells("Seleccion").Value) Then
                    If row.Cells("Estatus").Value = "CAPTURADA" Then
                        lista.Add(Convert.ToInt32(row.Cells("IdLista").Value))
                    End If
                End If
            Next
        End If

        If lista.Count > 0 Then
            Dim objMensaje As New Tools.ConfirmarForm
            objMensaje.mensaje = "¿Está seguro que desea autorizar las listas seleccionadas(" & lista.Count & ")?"
            If objMensaje.ShowDialog = Windows.Forms.DialogResult.OK Then
                Dim obj As New ListaPreciosProdBU
                obj.autorizarListas(lista)
                llenarGrid()
                pintarceldas()
            End If
        Else
            adv.mensaje = "No hay elementos seleccionados con estatus CAPTURADA para hacer la autorización"
            adv.ShowDialog()
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles btnRevertir.Click
        Dim lista As New List(Of Integer)
        If tbtPrecios.SelectedTab Is tbtPrecioVenta Then
            For Each row As UltraGridRow In grdListasPreciosVenta.Rows
                If CBool(row.Cells("Seleccion").Value) Then
                    If row.Cells("Estatus").Value = "AUTORIZADA" Or row.Cells("Estatus").Value = "RECHAZADA" Then
                        lista.Add(Convert.ToInt32(row.Cells("IdLista").Value))
                    End If
                End If
            Next
        Else
            For Each row As UltraGridRow In grdListasPreciosCompra.Rows
                If CBool(row.Cells("Seleccion").Value) Then
                    If row.Cells("Estatus").Value = "AUTORIZADA" Or row.Cells("Estatus").Value = "RECHAZADA" Then
                        lista.Add(Convert.ToInt32(row.Cells("IdLista").Value))
                    End If
                End If
            Next
        End If

        If lista.Count > 0 Then
            Dim objMensaje As New Tools.ConfirmarForm
            objMensaje.mensaje = "¿Está seguro que desea regresar a estatus de CAPTURADA las listas seleccionadas(" & lista.Count & ")?"
            If objMensaje.ShowDialog = Windows.Forms.DialogResult.OK Then
                Dim obj As New ListaPreciosProdBU
                obj.revertirListas(lista)
                llenarGrid()
                pintarceldas()
            End If
        Else
            adv.mensaje = "No hay elementos seleccionados con estatus AUTORIZADA ó RECHAZADA para deshacer la actualizaión"
            adv.ShowDialog()
        End If
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles btnRechazar.Click
        Dim lista As New List(Of Integer)
        If tbtPrecios.SelectedTab Is tbtPrecioVenta Then
            For Each row As UltraGridRow In grdListasPreciosVenta.Rows
                If CBool(row.Cells("Seleccion").Value) Then
                    If row.Cells("Estatus").Value = "CAPTURADA" Then
                        lista.Add(Convert.ToInt32(row.Cells("IdLista").Value))
                    End If
                End If
            Next
        Else
            For Each row As UltraGridRow In grdListasPreciosCompra.Rows
                If CBool(row.Cells("Seleccion").Value) Then
                    If row.Cells("Estatus").Value = "CAPTURADA" Then
                        lista.Add(Convert.ToInt32(row.Cells("IdLista").Value))
                    End If
                End If
            Next
        End If

        If lista.Count > 0 Then
            Dim objMensaje As New Tools.ConfirmarForm
            objMensaje.mensaje = "¿Está seguro que desea rechazar las listas seleccionadas(" & lista.Count & ")?"
            If objMensaje.ShowDialog = Windows.Forms.DialogResult.OK Then
                Dim obj As New ListaPreciosProdBU
                obj.rechazarListas(lista)
                llenarGrid()
                pintarceldas()
            End If
        Else
            adv.mensaje = "No hay elementos seleccionados con estatus CAPTURADA para rechazar"
            adv.ShowDialog()
        End If
    End Sub

    Private Sub btnCopiar_Click(sender As Object, e As EventArgs) Handles btnCopiar.Click
        Dim n As Integer = 0
        Dim l As New ListaPrecioProd
        Dim estatus As String = ""
        For Each row As UltraGridRow In grdListasPreciosCompra.Rows
            If CBool(row.Cells("Seleccion").Value) Then
                n += 1
                l.listaid = row.Cells("IdLista").Value()
                l.inicio = row.Cells("Inicio").Value()
                l.fin = row.Cells("Fin").Value()
                l.nombre = row.Cells("Nombre Lista").Value()
                l.idmarca = row.Cells("Marca").Value()
                l.marca = row.Cells("IdMarca").Value()
                l.idcoleccion = row.Cells("Colección").Value()
                l.coleccion = row.Cells("IdColeccion").Value()
                l.idNave = row.Cells("IdNave").Value()
                estatus = row.Cells("Estatus").Value()
            End If
        Next
        If n > 1 Then
            adv.mensaje = "Solo se puede copiar una lista a la vez, seleccione únicamente una lista."
            adv.ShowDialog()
        Else
            If n = 1 Then
                Dim form As New CopiarListaPrecioForm
                form.lista = l
                If estatus = "CAPTURADA" Then
                    form.lblEstatus.Text = estatus
                    form.lblEstatus.ForeColor = Color.DarkOrange
                ElseIf estatus = "RECHAZADA" Then
                    form.lblEstatus.Text = estatus
                    form.lblEstatus.ForeColor = Color.Salmon
                ElseIf estatus = "AUTORIZADA" Then
                    form.lblEstatus.Text = estatus
                    form.lblEstatus.ForeColor = Color.Green
                End If
                form.ShowDialog()
            End If
        End If
    End Sub

    Private Sub btnEnviar_Click(sender As Object, e As EventArgs) Handles btnEnviar.Click
        If getListaIdSeleccionadosCAPTURADA().Count = 1 Then
            picEstado.Visible = True
            lblEstado.Visible = True
            btnEnviar.Enabled = False
            imprimirReporte("enviar")
        Else
            adv.mensaje = "Solo se permite enviar una lista de precios a la vez y listas con estatus 'CAPTURADA'."
            adv.ShowDialog()
        End If
    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        imprimirReporte("imprimir")
    End Sub
    ''' <summary>
    ''' Imprime el reporte de las listas seleccionadas recibe como parametro un String para mostrar el reporte o solo guardarlo y enviarlo "imprimir" ,"enviar".
    ''' </summary>
    ''' <param name="accion"></param>
    ''' <remarks></remarks>
    Public Sub imprimirReporte(ByVal accion As String)
        Me.Cursor = Cursors.WaitCursor
        Dim obj As New ListaPreciosProdBU
        Dim list As New List(Of Integer)
        Dim dsDatos As New DataSet()
        Dim dtLista As New DataTable("dtLista")
        Dim dtDatosLista As New DataTable("dtDatosLista")
        Try
            Me.Cursor = Cursors.WaitCursor
            list = getListaIdSeleccionados()
            If list.Count > 0 Then
                dtLista = obj.getListasReporte(list)
                dtDatosLista = obj.getListasDetallesReporte(list)
                dtLista.TableName = "dtLista"
                dtDatosLista.TableName = "dtDatosLista"
                dsDatos.Tables.Add(dtLista)
                dsDatos.Tables.Add(dtDatosLista)
                Dim OBJBU As New Framework.Negocios.ReportesBU
                Dim EntidadReporte As Entidades.Reportes
                EntidadReporte = OBJBU.LeerReporteporClave("LISTAPRECIOPRODTERMINADO")
                Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
                    EntidadReporte.Pnombre
                My.Computer.FileSystem.WriteAllText(archivo + ".mrt", EntidadReporte.Pxml, False)
                Dim reporte As New StiReport
                reporte.Load((archivo + ".mrt"))
                reporte.Compile()
                reporte.RegData(dsDatos)
                reporte("Usuario") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
                reporte.Render()
                If accion = "imprimir" Then
                    reporte.Show()
                ElseIf accion = "enviar" Then
                    Dim l As New ListaPrecioProd
                    l = getDatosListaSeleccionada()
                    Dim PdfExport As StiPdfExportService = New StiPdfExportService()
                    Dim ruta As String
                    ruta = crearPDF(PdfExport, 0, archivo, reporte)
                    EnviarCorreoArchivo((ruta), l)
                End If
            Else
                adv.mensaje = "Seleccione las listas a imprimir."
                adv.ShowDialog()
            End If
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            adv.mensaje = "Surgió algo inesperado. Detalle: " & ex.ToString
            adv.ShowDialog()
        End Try
    End Sub
    Private Function crearPDF(ByVal PdfExport As StiPdfExportService, ByVal num As Integer, ByVal archivo As String, ByVal reporte As StiReport) As String
        Try
            PdfExport.ExportPdf(reporte, (archivo + num.ToString + ".pdf"))
        Catch ex As Exception
            num += 1
            crearPDF(PdfExport, num, archivo, reporte)
        End Try
        Dim ruta As String
        ruta = archivo + num.ToString + ".pdf"
        Return ruta
    End Function
    Public Function getDatosListaSeleccionada() As ListaPrecioProd
        Dim lista As New ListaPrecioProd
        For Each row As UltraGridRow In grdListasPreciosCompra.Rows
            If CBool(row.Cells("Seleccion").Value) Then
                If row.Cells("Estatus").Value = "CAPTURADA" Then
                    lista.listaid = Convert.ToInt32(row.Cells("IdLista").Value)
                    lista.marca = row.Cells("Marca").Value
                    lista.coleccion = row.Cells("Colección").Value
                    lista.nombre = row.Cells("Nombre Lista").Value
                    lista.inicio = row.Cells("Inicio").Value
                    lista.fin = row.Cells("Fin").Value
                    lista.usuarioId = row.Cells("Creó").Value
                    lista.Nave = row.Cells("Nave").Value
                End If
            End If
        Next
        Return lista
    End Function
    Public Function getListaIdSeleccionados() As List(Of Integer)
        Dim lista As New List(Of Integer)
        For Each row As UltraGridRow In grdListasPreciosCompra.Rows
            If CBool(row.Cells("Seleccion").Value) Then
                lista.Add(Convert.ToInt32(row.Cells("IdLista").Value))
            End If
        Next
        Return lista
    End Function
    Public Function getListaIdSeleccionadosCAPTURADA() As List(Of Integer)
        Dim lista As New List(Of Integer)
        For Each row As UltraGridRow In grdListasPreciosCompra.Rows
            If CBool(row.Cells("Seleccion").Value) Then
                If row.Cells("Estatus").Value = "CAPTURADA" Then
                    lista.Add(Convert.ToInt32(row.Cells("IdLista").Value))
                End If
            End If
        Next
        Return lista
    End Function
    Private Shared mailSent As Boolean = False
    Private Shared Sub SendCompletedCallback(ByVal sender As Object, ByVal e As AsyncCompletedEventArgs)
        'Get the unique identifier for this asynchronous operation.
        Dim token As String = CStr(e.UserState)
        Dim a As New AdvertenciaForm
        Dim x As New ExitoForm
        If e.Cancelled Then
            a.mensaje = "Mensaje cancelado."
            a.ShowDialog()
        End If
        If e.Error IsNot Nothing Then
            a.mensaje = " " + e.Error.ToString()
            a.ShowDialog()
        Else
            x.mensaje = "Mensaje enviado."
            x.ShowDialog()
        End If
        mailSent = True
        CType(sender, SmtpClient).Dispose()
    End Sub

    Public Sub EnviarCorreoArchivo(ByVal archivo As String, ByVal lista As ListaPrecioProd)
        Dim mensaje As String = "Mensaje enviado correctamente"
        Dim cliente As New SmtpClient
        Dim smtpBU As New SmtpBU
        Dim smtp As New Entidades.SMTP
        Dim autenticacion As New System.Net.NetworkCredential("servicioselectronicos@grupoyuyin.com", "Yservicios2015@")
        cliente.Credentials = autenticacion
        cliente.Host = "pod51010.outlook.com"
        cliente.Port = 25
        cliente.EnableSsl = True
        destinatarios = "cdesarrollo.ti@grupoyuyin.com.mx,ge_ti@grupoyuyin.com.mx,proveedores@grupoyuyin.com.mx"
        'Dim [from] As New MailAddress("servicioselectronicos@grupoyuyin.com", "servicioselectronicos@grupoyuyin.com", System.Text.Encoding.UTF8)
        Dim mailMsg As New MailMessage()
        'Asigna los destinatarios.
        For Each mail As String In destinatarios.Split(New Char() {","c})
            mailMsg.To.Add(New System.Net.Mail.MailAddress(mail))
        Next
        mailMsg.From = New System.Net.Mail.MailAddress("servicioselectronicos@grupoyuyin.com")
        mailMsg.BodyEncoding = System.Text.Encoding.UTF8
        mailMsg.Body = "Lista de precios para su autorización."
        'Incluye non-ASCII caracteres en el asunto y cuerpo del correo.
        'Dim someArrows As New String(New Char() {ChrW(&H2190), ChrW(&H2191), ChrW(&H2192), ChrW(&H2193)})
        mailMsg.Body += Environment.NewLine & " Nave: " & lista.Nave
        mailMsg.Body += Environment.NewLine & " Nombre de la lista: " & lista.nombre
        mailMsg.Body += Environment.NewLine & " Vigencia: Del " & lista.inicio.ToShortDateString & " Al " & lista.fin.ToShortDateString
        mailMsg.Body += Environment.NewLine & " Marca: " & lista.marca
        mailMsg.Body += Environment.NewLine & " Colección: " & lista.coleccion
        mailMsg.Body += Environment.NewLine & " Usuario: " & lista.usuarioId
        mailMsg.Subject = "NOTIFICACIÓN DE ALTA DE LISTA DE PRECIOS DE PRODUCTO TERMINADO DE LA NAVE " & lista.Nave
        mailMsg.SubjectEncoding = System.Text.Encoding.UTF8
        Dim data = New Attachment(archivo, MediaTypeNames.Application.Octet)
        Dim disposition As ContentDisposition = data.ContentDisposition
        disposition.CreationDate = System.IO.File.GetCreationTime(archivo)
        disposition.ModificationDate = System.IO.File.GetLastWriteTime(archivo)
        disposition.ReadDate = System.IO.File.GetLastAccessTime(archivo)
        'Agregamos un archivo al correo
        mailMsg.Attachments.Add(data)
        'mailMsg.IsBodyHtml = True
        AddHandler cliente.SendCompleted, AddressOf SendCompletedCallback
        Dim userState As String = "test message1"
        cliente.SendAsync(mailMsg, userState)
        If Not BackgroundWorker1.IsBusy Then
            BackgroundWorker1.RunWorkerAsync()
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            If mailSent = True Then
                mailSent = False
                picEstado.Visible = False
                lblEstado.Visible = False
                btnEnviar.Enabled = True
                Me.Cursor = Cursors.Default
                BackgroundWorker1.CancelAsync()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        If Not BackgroundWorker1.IsBusy Then
            BackgroundWorker1.RunWorkerAsync()
        End If
    End Sub

    Private Sub ListasDePreciosForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        BackgroundWorker1.CancelAsync()
        BackgroundWorker1.Dispose()
        BackgroundWorker1 = New BackgroundWorker
    End Sub

    'Private Sub   grdListaPrecios_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles   grdListasPreciosCompra.InitializeLayout
    '    disenioGrid()
    'End Sub

    Private Sub cmbComercializadora_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbComercializadora.SelectedIndexChanged
        If cmbNave.SelectedIndex > 0 Then
            idNave = cmbNave.SelectedValue

            If rdo2.Checked = True Then
                cmbMarca.Enabled = True
                llenarMarcas()
            End If
        Else
            cmbMarca.Enabled = False
        End If

        If cmbComercializadora.SelectedIndex > 0 Then
            idEmpresa = cmbComercializadora.SelectedValue
            If rdo2.Checked = True Then
                cmbMarca.Enabled = True
                llenarMarcas()
            Else
                cmbMarca.Enabled = False
            End If
        Else
            adv.mensaje = "Seleccione una Comercializadora"
            '  adv.ShowDialog()
        End If
    End Sub

    Private Sub grdListasPreciosVenta_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdListasPreciosVenta.InitializeLayout
        disenioGridVenta()
    End Sub

    Private Sub grdListasPreciosVenta_ClickCell(sender As Object, e As ClickCellEventArgs) Handles grdListasPreciosVenta.ClickCell
        Try
            If grdListasPreciosVenta.ActiveRow.Cells("Seleccion").IsActiveCell Then
                grdListasPreciosVenta.ActiveRow.Selected = False
            Else
                grdListasPreciosVenta.ActiveRow.Selected = True
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub grdListasPreciosCompra_ClickCell(sender As Object, e As ClickCellEventArgs) Handles grdListasPreciosCompra.ClickCell
        Try
            If grdListasPreciosCompra.ActiveRow.Cells("Seleccion").IsActiveCell Then
                grdListasPreciosCompra.ActiveRow.Selected = False
            Else
                grdListasPreciosCompra.ActiveRow.Selected = True
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub grdListasPreciosCompra_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdListasPreciosCompra.InitializeLayout
        disenioGrid()

    End Sub

    Private Sub grdListaPrecios_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdListaPrecios.InitializeLayout
        diseñogridlista()
    End Sub

    Public Sub diseñogridlista()
        Try
            With grdListaPrecios.DisplayLayout.Bands(0)
                .Columns("IdLista").Hidden = True
                .Columns("IdNave").Hidden = True
                .Columns("Estatus").Hidden = True
                .Columns("IdColeccion").Hidden = True
                .Columns("IdMarca").Hidden = True
                'If rdo2.Checked = True Then 'Listas y precios
                '    .Columns("Precio").Format = "####0.00"
                '    .Columns("idPrecio").Hidden = True
                '      grdListasPreciosCompra.DisplayLayout.AutoFitStyle = AutoFitStyle.None
                '    .PerformAutoResizeColumns(True, PerformAutoSizeType.AllRowsInBand)
                'Else
                .Columns("SinPreciosCapturados").Hidden = True
                grdListaPrecios.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
                'End If
                '.Columns("Seleccion").Header.CheckBoxVisibility = HeaderCheckBoxVisibility.WhenUsingCheckEditor
                .Columns("Seleccion").Header.CheckBoxAlignment = HeaderCheckBoxAlignment.Right
                '.Columns("Seleccion").Header.CheckBoxSynchronization = HeaderCheckBoxSynchronization.RowsCollection
                .Columns("Seleccion").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
                .Columns("Seleccion").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
                .Columns("Seleccion").Header.Caption = " "
                .Columns("pintar").Header.Caption = " "
                .Columns("Seleccion").AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False
                .Columns("Marca").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                .Columns("Colección").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                '  grdListaPrecios.DisplayLayout.Scrollbars = Infragistics.Win.UltraWinGrid.Scrollbars.Horizontal
                .Columns("Seleccion").Width = 10
                .Columns("pintar").Width = 15
                .Columns("Colección").Width = 100

                .Columns("Inicio").Width = 62
                .Columns("Fin").Width = 62
                .Columns("FCreación").Width = 62
                '.Columns("Precio").Width = 90
                .Columns("FAutorización").Width = 95
                .Columns("FModificación").Width = 90
                .Columns("FCreación").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DateTime
                .Columns("FModificación").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DateTime
                If .Columns.Exists("FAutorización") = True Then
                    .Columns("FAutorización").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DateTime
                End If
            End With

            grdListaPrecios.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            'grdListas.DisplayLayout.Bands(0).RowLayoutStyle = RowLayoutStyle.ColumnLayout
            pintarceldaslista()
        Catch ex As Exception
            Dim vError As New Tools.ErroresForm
            vError.mensaje = "Ocurrió un error: " & ex.Message
            vError.ShowDialog()
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            Dim objFTP As New Tools.TransferenciaFTP
            objFTP.DescargarArchivo("/ManualesUsuario/Proveedores/", "Descargas\Manuales\Proveedores", "ADPR_MAUS_Listas_de_Precios_V1_20200424.pdf")
            Process.Start("Descargas\Manuales\Proveedores\ADPR_MAUS_Listas_de_Precios_V1_20200424.pdf")
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        If tbtPrecios.SelectedTab Is tbtPrecioCompra Then
            If grdListasPreciosCompra.Rows.Count > 0 Then
                exportarExcel(grdListasPreciosCompra)

            Else
                Dim ventanaMensaje As New Tools.AdvertenciaForm
                ventanaMensaje.mensaje = "No hay información para exportar"
                ventanaMensaje.ShowDialog()

            End If

        End If

        If tbtPrecios.SelectedTab Is tbtPrecioVenta Then

            If grdListasPreciosVenta.Rows.Count > 0 Then
                exportarExcel(grdListasPreciosVenta)
            Else
                Dim ventanaMensaje As New Tools.AdvertenciaForm
                ventanaMensaje.mensaje = "No hay información para exportar"
                ventanaMensaje.ShowDialog()

            End If

        End If

    End Sub

    Public Sub exportarExcel(ByVal grid As UltraGrid)
        Dim sfd As New SaveFileDialog
        sfd.DefaultExt = "xls"
        sfd.Filter = "Excel Files|*.xls"
        Dim result As DialogResult = sfd.ShowDialog()
        Dim fileName As String = sfd.FileName
        If result = Windows.Forms.DialogResult.OK Then
            Try
                Me.Cursor = Cursors.WaitCursor
                ultExportGrid.Export(grid, fileName)
                Dim objMensajeExito As New Tools.ExitoForm
                objMensajeExito.mensaje = "Archivo exportado correctamente en la ubicación: " + fileName
                objMensajeExito.StartPosition = FormStartPosition.CenterScreen
                objMensajeExito.ShowDialog()
                Process.Start(fileName)
                'grdMateriales.DataSource = Nothing
            Catch ex As Exception
                Dim objMensajeError As New Tools.ErroresForm
                objMensajeError.mensaje = "El documento no pudo exportarse." + vbLf + ex.Message
                objMensajeError.StartPosition = FormStartPosition.CenterScreen
                objMensajeError.ShowDialog()
            End Try
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub chkSeleccionar_CheckedChanged(sender As Object, e As EventArgs) Handles chkSeleccionar.CheckedChanged
        If tbtPrecios.SelectedTab Is tbtPrecioVenta Then
            For Each row As UltraGridRow In grdListasPreciosVenta.Rows
                row.Cells("Seleccion").Value = False
            Next
            If chkSeleccionar.Checked Then
                For Each row As UltraGridRow In grdListasPreciosVenta.Rows.GetFilteredInNonGroupByRows
                    row.Cells("Seleccion").Value = True
                Next
            Else
                For Each row As UltraGridRow In grdListasPreciosVenta.Rows.GetFilteredInNonGroupByRows
                    row.Cells("Seleccion").Value = False
                Next
            End If
            Try
                Dim Seleccionados As Integer = 0
                For Each row As UltraGridRow In grdListasPreciosVenta.Rows.GetFilteredInNonGroupByRows
                    If CBool(row.Cells("Seleccion").Value) Then
                        Seleccionados += 1
                    End If
                Next
            Catch ex As Exception

            End Try
        Else
            For Each row As UltraGridRow In grdListasPreciosCompra.Rows
                row.Cells("Seleccion").Value = False
            Next
            If chkSeleccionar.Checked Then
                For Each row As UltraGridRow In grdListasPreciosCompra.Rows.GetFilteredInNonGroupByRows
                    row.Cells("Seleccion").Value = True
                Next
            Else
                For Each row As UltraGridRow In grdListasPreciosCompra.Rows.GetFilteredInNonGroupByRows
                    row.Cells("Seleccion").Value = False
                Next
            End If
            Try
                Dim Seleccionados As Integer = 0
                For Each row As UltraGridRow In grdListasPreciosCompra.Rows.GetFilteredInNonGroupByRows
                    If CBool(row.Cells("Seleccion").Value) Then
                        Seleccionados += 1
                    End If
                Next
            Catch ex As Exception

            End Try
        End If

    End Sub

    Private Sub pbYuyin_Click(sender As Object, e As EventArgs) Handles pbYuyin.Click

    End Sub
End Class
