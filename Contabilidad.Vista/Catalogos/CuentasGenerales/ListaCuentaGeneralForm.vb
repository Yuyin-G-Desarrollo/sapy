Imports System.Windows.Forms
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports System.Drawing
Imports Tools

Public Class ListaCuentaGeneralForm

    Private Sub ListaCuentaGeneralForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Location = New Point(0, 0)

        lista_Empresas_SaySicyContpaq()
        lista_TipoCuentaContable()
        lista_TipoPoliza()



    End Sub


#Region "Poblar Combos"

    ''' <summary>
    ''' ASIGNA LAS EMPRESAS DADAS DE ALTA EN LA BASE DE DATOS DEL SAY(EMPRESA SAY-SICY-CONTPAQ) ASIGNANDO COMO VALOR EL ID DE LA EMPRESA Y EL 
    ''' TEXTO A MOSTRAR LA RAZON SOCIAL
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub lista_Empresas_SaySicyContpaq()
        Dim objBU As New Negocios.PolizaBU
        Dim tabla As New DataTable
        tabla = objBU.Combo_lista_Empresas_Say_Sicy_Contpaq
        tabla.Rows.InsertAt(tabla.NewRow, 0)
        cmbRazonSocial.DataSource = tabla
        cmbRazonSocial.DisplayMember = "essc_razonsocial"
        cmbRazonSocial.ValueMember = "essc_empresaid"
    End Sub

    ''' <summary>
    ''' ASIGA LOS TIPOS DE CUENTAS CONTABLES EXISTENTES EN LA BASE DE DATOS A UN CONTROL DEL TIPO COMBOBOX
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub lista_TipoCuentaContable()

        Dim objBU As New Negocios.PolizaBU
        Dim tabla As New DataTable
        tabla = objBU.Combo_lista_TipoCuentaContable
        tabla.Rows.InsertAt(tabla.NewRow, 0)
        cmbTipoCuenta.DataSource = tabla
        cmbTipoCuenta.ValueMember = "ticc_tipocuentacontabilidadid"
        cmbTipoCuenta.DisplayMember = "ticc_nombre"
    End Sub

    ''' <summary>
    ''' ASIGNA LA LISTA DE LOS TIPOS DE POLIZA ACTIVOS EN LA BASE DE DATOS A UN CONTROL DEL TIPO COMBOBOX
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub lista_TipoPoliza()
        cmbTipoPoliza.DataSource = Nothing
        Dim objBU As New Negocios.PolizaBU
        Dim tabla As New DataTable
        tabla = objBU.Combo_lista_TipoPoliza
        tabla.Rows.InsertAt(tabla.NewRow, 0)
        cmbTipoPoliza.DisplayMember = "poti_nombre"
        cmbTipoPoliza.ValueMember = "poti_polizatipoid"
        cmbTipoPoliza.DataSource = tabla
        cmbTipoPoliza.SelectedValue = 0
    End Sub

#End Region

#Region "ACCIONES GRID"

    ''' <summary>
    ''' CONSULTA LA LISTA DE LAS CUENTAS GENERALES EXISTENTES DEACUERDO A LOS FILTROS SELECCIONADOS POR EL USUARIO
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub poblar_gridListaCuentaGeneral()
        Dim Cuenta As String = String.Empty
        Dim IdTipoPoliza As Integer
        Dim IdTipoCuenta As Integer
        Dim IdEmpresa As Integer
        Dim objBU As New Negocios.CuentasGeneralesBU
        Dim dtTabla As New DataTable
        gridListaCuentaGeneral.DataSource = Nothing

        Cuenta = LTrim(RTrim(txtCuenta.Text))
        If cmbTipoCuenta.SelectedIndex > 0 Then
            IdTipoCuenta = cmbTipoCuenta.SelectedValue
        End If

        If cmbTipoPoliza.SelectedIndex > 0 Then
            IdTipoPoliza = cmbTipoPoliza.SelectedValue
        End If

        If cmbRazonSocial.SelectedIndex > 0 Then
            IdEmpresa = cmbRazonSocial.SelectedValue
        End If

        dtTabla = objBU.Consulta_lista_Cuentas_Generales(IdTipoPoliza, IdTipoCuenta, IdEmpresa, Cuenta, rdoFolioExacto.Checked)

        If dtTabla.Rows.Count > 0 Then
            gridListaCuentaGeneral.DataSource = dtTabla
            gridListaCuentaGeneralDiseño(gridListaCuentaGeneral)
        Else
            Dim objAviso As New Tools.AvisoForm
            objAviso.mensaje = "No se encontraron registros."
            objAviso.StartPosition = FormStartPosition.CenterScreen
            objAviso.ShowDialog()
        End If


    End Sub

    Private Sub gridListaCuentaGeneralDiseño(grid As Infragistics.Win.UltraWinGrid.UltraGrid)

        With grid.DisplayLayout

            ''OCULTAMOS FILAS INECESARIAS PARA LA VISTA DEL USUARIO
            .Bands(0).Columns("ID").Hidden = True
            .Bands(0).Columns("Empresa_ID").Hidden = True
            .Bands(0).Columns("CuentaContpaq_Id").Hidden = True
            .Bands(0).Columns("CuentaSay_ID").Hidden = True
            .Bands(0).Columns("TipoPoliza_ID").Hidden = True
            ''.Bands(0).Columns("Clave").Hidden = True
            .Bands(0).Columns("CuentaBancaria_Id").Hidden = True
            .Bands(0).Columns("TipoPolizaContpaq_Id").Hidden = True
            If cmbTipoPoliza.Text <> "BANCOS" And cmbTipoPoliza.SelectedIndex > 0 Then
                .Bands(0).Columns("Cuenta Bancaria").Hidden = True
            End If


            .Bands(0).Columns("Nombre de Cuenta").FilterOperandStyle = FilterOperandStyle.Combo
            .Bands(0).Columns("No. Cuenta").FilterOperandStyle = FilterOperandStyle.Combo
            .Bands(0).Columns("Cuenta Contable").FilterOperandStyle = FilterOperandStyle.Combo
            .Bands(0).Columns("Tipo de Poliza").FilterOperandStyle = FilterOperandStyle.Combo
            .Bands(0).Columns("Cuenta Bancaria").FilterOperandStyle = FilterOperandStyle.Combo


            .PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
            .Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
            .Override.RowSelectors = DefaultableBoolean.True
            .Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            .Override.RowSelectorWidth = 35
            .Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
            .Override.CellClickAction = CellClickAction.RowSelect
            .Override.AllowRowFiltering = DefaultableBoolean.True
            .Override.FilterUIType = FilterUIType.FilterRow
            .Override.AllowAddNew = AllowAddNew.No
        End With

        Dim width As Integer
        For Each col As UltraGridColumn In grid.Rows.Band.Columns
            If Not col.Hidden Then
                width += col.Width
            End If
        Next

        If width > grid.Width Then
            grid.DisplayLayout.AutoFitStyle = AutoFitStyle.None
        Else
            grid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        End If

    End Sub

#End Region



#Region "ACCIONES BOTONES"

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Dispose()
    End Sub

    Private Sub btnAbajo_Click_1(sender As Object, e As EventArgs) Handles btnAbajo.Click
        pnlFiltros.Height = 116
    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        pnlFiltros.Height = 30
    End Sub

    Private Sub btnMostrar_Click_1(sender As Object, e As EventArgs) Handles btnMostrar.Click
        poblar_gridListaCuentaGeneral()
    End Sub

    Private Sub btnAlta_Click(sender As Object, e As EventArgs) Handles btnAlta.Click
        Dim form As New AltaCuentaGeneralForm
        form.Agregar_Editar = True
        form.StartPosition = FormStartPosition.CenterScreen
        form.ShowDialog()
        poblar_gridListaCuentaGeneral()
    End Sub


    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        If gridListaCuentaGeneral.Selected.Rows.Count > 1 Then
            show_message("Advertencia", "Solo se puede editar una cuenta general a la vez.")
        ElseIf gridListaCuentaGeneral.Selected.Rows.Count < 1 Then
            show_message("Advertencia", "Seleccione una cuenta general antes de presionar el botón 'Editar'.")
        Else
            Dim form As New AltaCuentaGeneralForm
            form.Agregar_Editar = False
            form.StartPosition = FormStartPosition.CenterScreen
            form.cuenta_general_id = CInt(gridListaCuentaGeneral.ActiveRow.Cells(0).Value)
            form.ShowDialog()
            poblar_gridListaCuentaGeneral()
        End If
    End Sub


#End Region


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



    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        gridListaCuentaGeneral.DataSource = Nothing
        cmbRazonSocial.SelectedIndex = 0
        cmbTipoCuenta.SelectedIndex = 0
        cmbTipoPoliza.SelectedIndex = 0
        txtCuenta.Text = ""
        rdoFolioExacto.Checked = True
    End Sub
End Class