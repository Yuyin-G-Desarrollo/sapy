Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports System.Windows.Forms
Imports Tools

Public Class ImprimirReporteSalidaNaveForm

    Public IdNave As Integer
    Public IdSalidaNave As Integer
    Public IdOperador As Integer
    Public NombreOperador As String
    Dim fechaInicio As String
    Dim fechaFin As String
    Public Imprimir As Boolean = False


    Private Sub DatosExtraForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmbNaves = Tools.Controles.ComboNavesSegunUsuarioConIdSIcy(cmbNaves, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
        cmbNaves.SelectedIndex = 0
        DateStart.Value = Now.Date
        DateStart.MaxDate = Now.Date
        dateFin.Value = Now.Date
        dateFin.MaxDate = Now.Date
        btnMostrar.Enabled = False

        ControlBox = True
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        IdNave = 0
        cmbNaves.SelectedItem = 0
        IdSalidaNave = 0
        IdOperador = 0
        fechaFin = String.Empty
        fechaInicio = String.Empty

        cmbNaves.Enabled = True
        DateStart.Enabled = True
        dateFin.Enabled = True

        btnMostrar.Enabled = False

        grdListaSalidas.DataSource = Nothing

        cmbNaves.SelectedIndex = 0
    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        pnlCampos.Height = 30
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        pnlCampos.Height = 111
    End Sub

    Private Sub cmbNaves_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbNaves.SelectedValueChanged
        If cmbNaves.ContainsFocus Then
            IdNave = CInt(cmbNaves.SelectedValue)
        End If
    End Sub

    Public Sub Recuperar_Salidas_De_Nave(ByVal Fecha_Inicio As String, ByVal Fecha_Fin As String, ByVal IdNave As Integer)
        Dim objBU As New Negocios.SalidaNavesBU
        Dim dtSalidaNave As New DataTable

        dtSalidaNave = objBU.Recuperar_Salidas_De_Nave(Fecha_Inicio, Fecha_Fin, IdNave)

        grdListaSalidas.DataSource = dtSalidaNave

        cmbNaves.Enabled = False
        DateStart.Enabled = False
        dateFin.Enabled = False
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Dim FormaAdvertencia As New AdvertenciaForm
        FormaAdvertencia.StartPosition = FormStartPosition.CenterScreen

        fechaInicio = DateStart.Value.ToShortDateString + " 00:00:00"
        fechaFin = dateFin.Value.ToShortDateString + " 23:59:59"

        fechaInicio = DateTime.Parse(fechaInicio).ToString("dd/MM/yyyy HH:mm:ss")
        fechaFin = DateTime.Parse(fechaFin).ToString("dd/MM/yyyy HH:mm:ss")

        Dim result As Integer = DateTime.Compare(fechaInicio, fechaFin)

        If result > 0 Then
            FormaAdvertencia.mensaje = "La fecha de inicio no puede ser mayor que la fecha de fin."
            FormaAdvertencia.ShowDialog()
            Return
        End If


        If IdNave = 0 Then
            FormaAdvertencia.mensaje = "Seleccione una nave para poder continuar."
            FormaAdvertencia.ShowDialog()
            Return
        End If


        btnMostrar.Enabled = True
        Recuperar_Salidas_De_Nave(fechaInicio, fechaFin, IdNave)

    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click


        If IdSalidaNave > 0 Then

            Imprimir = True

            Me.Close()

        Else
            show_message("Advertencia", "Seleccione un folio para imprimir el reporte.")
        End If


    End Sub

    Private Sub grdListaSalidas_ClickCell(sender As Object, e As ClickCellEventArgs) Handles grdListaSalidas.ClickCell
        Dim row As UltraGridRow = grdListaSalidas.ActiveRow
        If row.IsFilterRow Then Return

        IdSalidaNave = CInt(row.Cells("Folio").Text)
        NombreOperador = CStr(row.Cells("Operador").Text)
    End Sub

    Private Sub grdListaSalidas_InitializeLayout_1(sender As Object, e As InitializeLayoutEventArgs) Handles grdListaSalidas.InitializeLayout
        With grdListaSalidas
            .DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
            .DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue

            .DisplayLayout.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
            .DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns

            .DisplayLayout.Bands(0).Columns("Folio").CellAppearance.TextHAlign = HAlign.Right
            .DisplayLayout.Bands(0).Columns("Id_Operador").Hidden = True
            .DisplayLayout.Bands(0).Columns("Total Pares").CellAppearance.TextHAlign = HAlign.Right
            .DisplayLayout.Bands(0).Columns("Total Atados").CellAppearance.TextHAlign = HAlign.Right
            .DisplayLayout.Bands(0).Columns("Total Lotes").CellAppearance.TextHAlign = HAlign.Right
            .DisplayLayout.Bands(0).Columns("Total Pares").Format = "N0"
            .DisplayLayout.Bands(0).Columns("Total Atados").Format = "N0"
            .DisplayLayout.Bands(0).Columns("Total Lotes").Format = "N0"

            .DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
            .DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            .DisplayLayout.Override.RowSelectorWidth = 35
            .DisplayLayout.Override.RowSelectorAppearance.ForeColor = Color.AliceBlue
            .DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
            .DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True
            .DisplayLayout.Override.AllowAddNew = AllowAddNew.No
        End With

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

            mensajeExito.ShowDialog()
        End If
    End Sub


End Class