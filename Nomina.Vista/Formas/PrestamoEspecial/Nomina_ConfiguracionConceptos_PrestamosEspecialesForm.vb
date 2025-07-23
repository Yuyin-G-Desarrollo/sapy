Imports DevExpress.XtraGrid
Imports Nomina.Negocios
Imports Tools

Public Class Nomina_ConfiguracionConceptos_PrestamosEspecialesForm
    Public NaveID As Integer
    Dim exito As New ExitoForm
    Dim advertencia As New AdvertenciaForm
    Dim activo As Integer

    Private Sub Nomina_ConfiguracionConceptos_PrestamosEspecialesForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenarComboNaves()

    End Sub

    Public Sub llenarComboNaves()
        Dim objBU As New ConsultarPrestamosBU
        Dim dtNaves As New DataTable
        dtNaves = objBU.ObtenerNaves()
        dtNaves.Rows.InsertAt(dtNaves.NewRow, 0)
        cmbNave.DataSource = dtNaves
        cmbNave.DisplayMember = "Nave"
        cmbNave.ValueMember = "NaveID"
    End Sub

    Private Sub btnAltas_Click(sender As Object, e As EventArgs) Handles btnAltas.Click

        If cmbNave.SelectedIndex = 0 Then
            advertencia.mensaje = "Seleccione una Nave."
            advertencia.ShowDialog()
        Else
            Dim AltaConfPresEsp As New Nomina_AltaEdicion_ConfPrestamosEspeciales
            AltaConfPresEsp.NaveID = cmbNave.SelectedValue
            AltaConfPresEsp.Accion = 1
            AltaConfPresEsp.ShowDialog()
            btnMostrar_Click(Nothing, Nothing)
        End If


    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        Dim EditarConfPresEsp As New Nomina_AltaEdicion_ConfPrestamosEspeciales
        Dim NumeroFilas = MVConfiguracionPE.DataRowCount

        For index As Integer = 0 To NumeroFilas Step 1
            If CBool(MVConfiguracionPE.GetRowCellValue(MVConfiguracionPE.GetVisibleRowHandle(index), " ")) = True Or CBool(MVConfiguracionPE.IsRowSelected(MVConfiguracionPE.GetVisibleRowHandle(index))) = True Then
                EditarConfPresEsp.Concepto = MVConfiguracionPE.GetRowCellValue(MVConfiguracionPE.GetVisibleRowHandle(index), "Concepto")
                EditarConfPresEsp.PorcentajeCC = MVConfiguracionPE.GetRowCellValue(MVConfiguracionPE.GetVisibleRowHandle(index), "PorcentajeCC")
                EditarConfPresEsp.ConceptoID = MVConfiguracionPE.GetRowCellValue(MVConfiguracionPE.GetVisibleRowHandle(index), "ConceptoID")
                EditarConfPresEsp.Accion = 2
                EditarConfPresEsp.NaveID = cmbNave.SelectedValue
                EditarConfPresEsp.Semanas = MVConfiguracionPE.GetRowCellValue(MVConfiguracionPE.GetVisibleRowHandle(index), "Semanas")
            End If
        Next
        EditarConfPresEsp.ShowDialog()
        btnMostrar_Click(Nothing, Nothing)

    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        CargarDatos()
    End Sub

    Public Sub CargarDatos()
        Dim objBU As New ConsultarPrestamosBU
        Dim dtDatosConfiguracion As New DataTable
        Dim NaveID As Integer


        NaveID = cmbNave.SelectedValue

        If rdoNo.Checked = True Then
            activo = 0
        Else
            activo = 1
        End If

        If NaveID <> 0 Then
            dtDatosConfiguracion = objBU.MostrarConfiguracionPorNave(NaveID, activo)

            If dtDatosConfiguracion.Rows.Count > 0 Then
                grdConfiguracionPE.DataSource = dtDatosConfiguracion
                lblFechaUltimaActualización.Text = Date.Now
                DiseñoGrid()
            Else
                advertencia.mensaje = "No hay datos para mostrar."
                advertencia.ShowDialog()
            End If


        Else
            advertencia.mensaje = "Debe seleccionar una nave."
            advertencia.ShowDialog()
        End If
    End Sub


    Private Sub DiseñoGrid()

        If IsNothing(MVConfiguracionPE.Columns.FirstOrDefault(Function(x) x.FieldName = "#")) = True Then
            MVConfiguracionPE.Columns.AddVisible("#").UnboundType = DevExpress.Data.UnboundColumnType.[Integer]
            AddHandler MVConfiguracionPE.CustomUnboundColumnData, AddressOf GridView1_CustomUnboundColumnData
            MVConfiguracionPE.Columns.Item("#").VisibleIndex = 0
        End If


        For Each col As DevExpress.XtraGrid.Columns.GridColumn In MVConfiguracionPE.Columns
            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            col.OptionsFilter.AutoFilterCondition = Columns.AutoFilterCondition.Contains
            col.OptionsColumn.AllowEdit = False
        Next


        MVConfiguracionPE.Columns.ColumnByFieldName(" ").Fixed = Columns.FixedStyle.Left
        MVConfiguracionPE.Columns.ColumnByFieldName(" ").OptionsColumn.AllowEdit = True

        MVConfiguracionPE.Columns.ColumnByFieldName("ConceptoID").Visible = False



        MVConfiguracionPE.Columns.ColumnByFieldName("PorcentajeCC").Caption = "% Caja Chica"



        MVConfiguracionPE.Columns.ColumnByFieldName("PorcentajeCC").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        '  MVConfiguracionPE.BestFitColumns()

        MVConfiguracionPE.Columns.ColumnByFieldName("Concepto").Width = 200
        MVConfiguracionPE.Columns.ColumnByFieldName("PorcentajeCC").Width = 100
        MVConfiguracionPE.Columns.ColumnByFieldName("Semanas").Width = 100
        MVConfiguracionPE.Columns.ColumnByFieldName(" ").Width = 40
        MVConfiguracionPE.Columns.Item("#").Width = 50


    End Sub


    Private Sub GridView1_CustomUnboundColumnData(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs)
        If e.IsGetData Then
            e.Value = MVConfiguracionPE.GetRowHandle(e.ListSourceRowIndex)
            e.Value = e.Value + 1

        End If
    End Sub

    Private Sub bntSalir_Click(sender As Object, e As EventArgs) Handles bntSalir.Click
        Me.Close()
    End Sub

    Private Sub rdoNo_CheckedChanged(sender As Object, e As EventArgs) Handles rdoNo.CheckedChanged
        If rdoNo.Checked = True Then
            activo = 0
            CargarDatos()
        Else
            activo = 1
            CargarDatos()
        End If
    End Sub
End Class