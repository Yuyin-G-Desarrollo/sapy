Imports Framework.Negocios
Imports Programacion.Negocios
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Tools

Public Class EspacioReservadoForm

    Dim AlturaMaximaPanel As Int32 = 0
#Region "UI"



    Private Sub form_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Top = 0
        Me.Left = 0
        ConfigurarSeguridad()
        LlenarComboNaves()
        LlenarTablaEspacio()

        Me.txtPares.NumericType = UltraWinEditors.NumericType.Integer
        'Me.txtPares.MaskInput = "##,###"
    End Sub

    Private Sub LlenarComboNaves()
        Try
            Dim obj As New Framework.Negocios.NavesBU
            With cmbNaves
                .DataSource = obj.TablaDeNavesActivas
                .DisplayMember = "nave_nombre"
                .ValueMember = "id_"
            End With
        Catch ex As Exception

        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub ConfigurarSeguridad()
        Dim permiso As Boolean

        permiso = PermisosUsuarioBU.ConsultarPermiso("PRG_AUTORIZAR", "WRITE")



    End Sub




#End Region









    Private Sub bntBuscaCliente_Click(sender As Object, e As EventArgs) Handles bntBuscaCliente.Click
        Dim f As New BuscarCliente
        f.ShowDialog()
        Me.txtCliente.Tag = f.idCadena
        Me.txtCliente.Text = f.Cadena
    End Sub



    Private Sub chkActivos_CheckedChanged(sender As Object, e As EventArgs)
        LlenarTablaEspacio()
    End Sub

    Private Sub btnExportarExcel_Click_1(sender As Object, e As EventArgs) Handles btnExportarExcel.Click
        ExportarExcel()
    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        LlenarTablaEspacio()
    End Sub
    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        cancelarEspacios()
    End Sub
    Private Sub btnCambiarFecha_Click(sender As Object, e As EventArgs) Handles btnCambiarFecha.Click
        cambiarFecha()
    End Sub


    Public Sub cancelarEspacios()
        Dim vConfirmarForm As New ConfirmarForm
        Dim vAdvertenciaForm As New AdvertenciaForm
        Dim vEspacioReservado As New EspacioReservadoBU
        Dim vExitoForm As New ExitoForm

        Dim bandera As Integer = 0
        For Each rowGrd As UltraGridRow In grdDatos.Rows
            If rowGrd.Cells("Seleccion").Value And Not rowGrd.Cells("Estatus").Value = "Cancelado" Then
                bandera = 1
                Exit For
            End If
        Next
        If bandera = 1 Then
            vConfirmarForm.Text = "Espacio Reservado"
            vConfirmarForm.mensaje = "¿ Desea cancelar los registros seleccionados ?"
            Dim vDialogResult As New DialogResult
            vDialogResult = vConfirmarForm.ShowDialog
            If vDialogResult = Windows.Forms.DialogResult.OK Then
                vAdvertenciaForm.Text = "Espacio Reservado"
                vAdvertenciaForm.mensaje = "Los espacios reservados con el estatus CANCELADO no pueden cancelarse nuevamente ni cambiar la fecha."
                vAdvertenciaForm.ShowDialog()
                For Each rowGrd As UltraGridRow In grdDatos.Rows
                    If rowGrd.Cells("Seleccion").Value And Not rowGrd.Cells("Estatus").Value = "Cancelado" Then
                        vEspacioReservado.CambiarEstatus(rowGrd.Cells("_ID").Value, "Cancelado")
                    End If
                Next
                vEspacioReservado = Nothing
                LlenarTablaEspacio()
                vExitoForm.Text = "Espacio Reservado"
                vExitoForm.mensaje = "Registros cancelados con éxito."
                vExitoForm.ShowDialog()
            End If
        Else
            vAdvertenciaForm.Text = "Espacio Reservado"
            vAdvertenciaForm.mensaje = "Debe seleccionar al menos un espacio reservado"
            vAdvertenciaForm.ShowDialog()
        End If
    End Sub
    Public Sub cambiarFecha()
        Dim vConfirmarForm As New ConfirmarForm
        Dim vAdvertenciaForm As New AdvertenciaForm
        Dim vEspacioReservado As New EspacioReservadoBU
        Dim vExitoForm As New ExitoForm

        Dim bandera As Integer = 0
        For Each rowGrd As UltraGridRow In grdDatos.Rows
            If rowGrd.Cells("Seleccion").Value And Not rowGrd.Cells("Estatus").Value = "Cancelado" Then
                bandera = 1
                Exit For
            End If
        Next

        If bandera = 1 Then
            vConfirmarForm.Text = "Espacio Reservado"
            vConfirmarForm.mensaje = "¿ Desea cambiar la fecha de los registros seleccionados ?"
            Dim vDialogResult As New DialogResult
            vDialogResult = vConfirmarForm.ShowDialog
            If vDialogResult = Windows.Forms.DialogResult.OK Then
                vAdvertenciaForm.Text = "Espacio Reservado"
                vAdvertenciaForm.mensaje = "Los espacios reservados con el estatus CANCELADO no pueden cancelarse nuevamente ni cambiar la fecha."
                vAdvertenciaForm.ShowDialog()
                Dim vPedirFechaForm As New PedirFechaForm
                vDialogResult = vPedirFechaForm.ShowDialog
                If vDialogResult = Windows.Forms.DialogResult.OK Then
                    Dim fecha As Date = vPedirFechaForm.pFecha
                    For Each rowGrd As UltraGridRow In grdDatos.Rows
                        If rowGrd.Cells("Seleccion").Value And Not rowGrd.Cells("Estatus").Value = "Cancelado" Then
                            vEspacioReservado.CambiarFecha(rowGrd.Cells("_ID").Value, fecha)
                        End If
                    Next
                    vEspacioReservado = Nothing
                    LlenarTablaEspacio()
                    vExitoForm.Text = "Espacio Reservado"
                    vExitoForm.mensaje = "Cambio de fecha realizado con éxito"
                    vExitoForm.ShowDialog()
                Else
                    vAdvertenciaForm.Text = "Espacio Reservado"
                    vAdvertenciaForm.mensaje = "No se seleccionó la fecha para actualizar los registros seleccionados "
                    vAdvertenciaForm.ShowDialog()
                End If
            Else
                vAdvertenciaForm.Text = "Espacio Reservado"
                vAdvertenciaForm.mensaje = "Cambio de fecha cancelado "
                vAdvertenciaForm.ShowDialog()
            End If
        Else
            vAdvertenciaForm.Text = "Espacio Reservado"
            vAdvertenciaForm.mensaje = "Debe seleccionar al menos un espacio reservado"
            vAdvertenciaForm.ShowDialog()
        End If

    End Sub
    Private Sub grdDatos_BeforeRowsDeleted(sender As Object, e As Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs) Handles grdDatos.BeforeRowsDeleted
        e.Cancel = True
    End Sub

    Private Sub btnGuardaEspacio_Click(sender As Object, e As EventArgs) Handles btnGuardaEspacio.Click
        If Not validar() Then
            Exit Sub
        End If
        Dim vErrorForm As New ErroresForm
        Dim vExitoForm As New ExitoForm
        Dim vEspacioReservado As New EspacioReservadoBU
        Dim vConfirmarForm As New ConfirmarForm
        Dim vAdvertenciaForm As New AdvertenciaForm
        Try
            vConfirmarForm.Text = "Espacio Reservado"
            vConfirmarForm.mensaje = "¿ Desea guardar el espacio reservado recién capturado ?"
            Dim vDialogResult As New DialogResult
            vDialogResult = vConfirmarForm.ShowDialog
            If vDialogResult = Windows.Forms.DialogResult.OK Then
                Me.Cursor = Cursors.WaitCursor
                vEspacioReservado.Agregar(txtCliente.Tag, dtpFechaEntrega.Value, txtPares.Value, cmbNaves.SelectedValue)
                vEspacioReservado = Nothing
                txtCliente.Tag = ""
                txtCliente.Text = ""
                LlenarTablaEspacio()
                vExitoForm.Text = "Espacio Reservado"
                vExitoForm.mensaje = "Registro guardado con éxito."
                vExitoForm.ShowDialog()

            End If

        Catch ex As Exception
            vErrorForm.Text = "Espacio Reservado"
            vErrorForm.mensaje = ex.Message
            vErrorForm.ShowDialog()
        Finally
            Me.Cursor = Cursors.Default
        End Try

    End Sub
    Private Function validar() As Boolean
        Dim vAdvertenciaForm As New AdvertenciaForm
        ErrorProvider1.Clear()

        With cmbNaves
            If .Text = "" Then
                ErrorProvider1.SetError(cmbNaves, "Falta seleccionar una nave")
                lblNave.ForeColor = Color.Red
                vAdvertenciaForm.Text = "Espacio Reservado"
                vAdvertenciaForm.mensaje = "Falta seleccionar una nave"
                vAdvertenciaForm.ShowDialog()
                .Focus()
                Return False
            Else
                lblNave.ForeColor = Color.Black
            End If
        End With

        With dtpFechaEntrega
            If .Value.DayOfYear >= Now.DayOfYear Then
                lblFecha.ForeColor = Color.Black
            Else
                ErrorProvider1.SetError(dtpFechaEntrega, "No puede seleccionar una fecha inferior a la fecha actual")
                lblFecha.ForeColor = Color.Red
                vAdvertenciaForm.Text = "Espacio Reservado"
                vAdvertenciaForm.mensaje = "No puede seleccionar una fecha inferior a la fecha actual "
                vAdvertenciaForm.ShowDialog()
                .Focus()
                Return False
            End If
        End With

        With txtPares
            If .Value <= 0 Then
                ErrorProvider1.SetError(txtPares, "Indique un valor para pares mayor que cero")
                lblPares.ForeColor = Color.Red
                vAdvertenciaForm.Text = "Espacio Reservado"
                vAdvertenciaForm.mensaje = "Indique un valor para pares mayor que cero"
                vAdvertenciaForm.ShowDialog()
                .Focus()
                Return False
            Else
                lblPares.ForeColor = Color.Black
            End If
        End With

        With txtCliente
            If .Text = "" Then
                ErrorProvider1.SetError(txtCliente, "Falta seleccionar un cliente")
                lblClientes.ForeColor = Color.Red
                vAdvertenciaForm.Text = "Espacio Reservado"
                vAdvertenciaForm.mensaje = "Falta seleccionar un cliente"
                vAdvertenciaForm.ShowDialog()
                Return False
            Else
                lblClientes.ForeColor = Color.Black
            End If
        End With



        Return True
    End Function
    Private Sub LlenarTablaEspacio()
        Dim vEspacioReservado As New EspacioReservadoBU
        Dim vErrorForm As New ErroresForm
        Try
            Me.Cursor = Cursors.WaitCursor
            grdDatos.DataSource = Nothing
            grdDatos.DataSource = vEspacioReservado.TablaFechas(dtpInicio.Value, dtpFinal.Value, chkActivos.Checked, chkCancelados.Checked, chkSimulados.Checked, chk_asignados.Checked, chkFechas.Checked, chk_solo_especiales.Checked)
            disenotabla()
        Catch ex As Exception
            vErrorForm.Text = "Espacio Reservado"
            vErrorForm.mensaje = ex.Message
            vErrorForm.ShowDialog()
        Finally
            Me.Cursor = Cursors.Default
        End Try

    End Sub

    Public Sub disenotabla()



        grdDatos.DisplayLayout.Bands(0).Columns.Add("Seleccion", "")
        grdDatos.DisplayLayout.Bands(0).Columns("Seleccion").Header.VisiblePosition = 0

        Dim band As UltraGridBand = Me.grdDatos.DisplayLayout.Bands(0)
        With band
            .Columns("Seleccion").CellActivation = Activation.AllowEdit
            .Columns("_ID").CellActivation = Activation.NoEdit
            .Columns("Fecha").CellActivation = Activation.NoEdit
            .Columns("Estatus").CellActivation = Activation.NoEdit
            .Columns("Cliente").CellActivation = Activation.NoEdit
            .Columns("Pares").CellActivation = Activation.NoEdit
            .Columns("Nave").CellActivation = Activation.NoEdit
            .Columns("Creacion").CellActivation = Activation.NoEdit
            .Columns("CreadorPor").CellActivation = Activation.NoEdit
            .Columns("_ID").CellAppearance.TextHAlign = HAlign.Right
            .Columns("Pares").CellAppearance.TextHAlign = HAlign.Right
            .Columns("Pares").Format = "##,##0"
            .Columns("_ID").Header.Caption = "ID"
            .Columns("Pares").Header.Caption = "Cantidad"

            .Columns("Creacion").Header.Caption = "Creación"
            .Columns("CreadorPor").Header.Caption = "Creador Por"


            .Columns("seleccion").Style = ColumnStyle.CheckBox

            .PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        End With

        grdDatos.DisplayLayout.PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        grdDatos.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdDatos.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdDatos.DisplayLayout.Override.RowSelectorWidth = 35
        grdDatos.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
        band.Columns("_ID").Width = 20
        band.Columns("Seleccion").Width = 20
        band.Columns("Fecha").Width = 45
        band.Columns("Creacion").Width = 45
        band.Columns("Estatus").Width = 55
        band.Columns("CreadorPor").Width = 55
        band.Columns("Pares").Width = 55
        If band.Summaries.Exists("sumuno") Then
            Dim tmpSettings As SummarySettings = band.Summaries("sumuno")
            band.Summaries.Remove(tmpSettings)
        End If


        For Each rowGrd As UltraGridRow In grdDatos.Rows

            rowGrd.Cells("Seleccion").Value = False

        Next


        band.SummaryFooterCaption = "Total"
        Dim sumuno As SummarySettings = band.Summaries.Add("sumuno", SummaryType.Sum, band.Columns("Pares"))
        sumuno.DisplayFormat = "Sum =  {0:##,##0}"
        sumuno.Appearance.TextHAlign = HAlign.Right


    End Sub



    Private Sub ExportarExcel()
        Dim vErrorForm As New ErroresForm
        Dim vExitoForm As New ExitoForm
        Try
            Dim sfd As New SaveFileDialog
            sfd.DefaultExt = ".xls"
            sfd.Filter = "*.xls|*.xls"
            If sfd.ShowDialog = System.Windows.Forms.DialogResult.Cancel Then
                Exit Sub
            End If

            If sfd.FileName.Trim = "" Then
                Exit Sub
            End If
            Me.Cursor = Cursors.WaitCursor
            Dim nombre As String = sfd.FileName

            Me.UltraGridExcelExporter1.Export(grdDatos, nombre)
            System.Diagnostics.Process.Start(nombre)

            vExitoForm.Text = "Espacio Reservado"
            vExitoForm.mensaje = "Información exportada correctamente"
            vExitoForm.ShowDialog()
        Catch ex As Exception
            vErrorForm.Text = "Espacio Reservado"
            vErrorForm.mensaje = ex.Message
            vErrorForm.ShowDialog()
        Finally
            Me.Cursor = Cursors.Default
        End Try

    End Sub



    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        grbNaves.Height = 32
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        grbNaves.Height = 144
    End Sub

    Private Sub chkSeleccionar_CheckedChanged(sender As Object, e As EventArgs) Handles chkSeleccionar.CheckedChanged
        For Each rowGrd As UltraGridRow In grdDatos.Rows

            rowGrd.Cells("Seleccion").Value = chkSeleccionar.Checked

        Next
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()
    End Sub


End Class