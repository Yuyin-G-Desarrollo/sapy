Imports Produccion.Negocios
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Entidades
Imports Tools

Public Class AsignacionColaboradoresAvancesProduccionForm

    Dim objAdvertencia As New Tools.AdvertenciaForm
    Dim objMensaje As New AdvertenciaForm
    Dim objExito As New Tools.ExitoForm
    Dim objErrores As New Tools.ErroresForm
    Dim objInformacion As New Tools.AvisoForm
    Dim objConfirmacion As New Tools.ConfirmarForm
    Public idNaveSay As Integer = 0
    Public idNaveSicy As Integer = 0

    Private Sub AsignacionColaboradoresAvancesProduccionForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        llenarCampoNaves()
    End Sub

    Public Sub obtenerIdNaveSay()
        Dim obj As New ProduccionBU
        Dim tabla As New DataTable
        If cmbNave.Text <> "" Then
            tabla = obj.idNaveSay(cmbNave.Text)
            idNaveSay = tabla.Rows(0).Item(0)
        End If
    End Sub

    Public Sub llenarCampoNaves()
        cmbNave = Controles.ComboNavesSegunUsuario(cmbNave, SesionUsuario.UsuarioSesion.PUserUsuarioid)
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        rdoActivo.Checked = True
        cmbNave.SelectedValue = 0
    End Sub

    Private Sub btnBuscar1_Click(sender As Object, e As EventArgs)
        Dim form As New listaColaboradoresForm
        Dim obj As New catalagosBU
        Dim tablas As New DataTable
        obtenerIdNaveSay()
        'tablas = obj.listaNavesSicy(1)
        'idNaveSicy = tablas.Rows(0).Item(0)
        'form.nave = idNaveSay
        form.nave = cmbNave.SelectedValue
        form.ShowDialog()
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Dim form As New ListaDepartamentosForm
        obtenerIdNaveSay()
        form.nave = idNaveSay
        form.ShowDialog()
    End Sub

    Public Sub obtenetIdNaveSicy()
        Dim obj As New catalagosBU
        Dim tablas As New DataTable
        If cmbNave.Text <> "" Then
            tablas = obj.listaNavesSicy(cmbNave.Text)
            'idNaveSicy = tablas.Rows(0).Item(0)
            idNaveSicy = cmbNave.SelectedValue
        End If
    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        Try
            mostrar()
        Catch ex As Exception
        End Try
    End Sub

    Public Sub mostrar()
        If cmbNave.Text = "" Then
            objMensaje.mensaje = "Seleccione una nave"
            objMensaje.ShowDialog()
            lblNaveBuscar.ForeColor = Drawing.Color.Red
        Else
            lblNaveBuscar.ForeColor = Drawing.Color.Black
            Dim estatus As String = ""
            'Dim estatus As Integer = 0
            Try
                'obtenerIdNaveSay()
                'obtenetIdNaveSicy()
                If rdoActivo.Checked = True Then
                    estatus = "A"
                    'estatus = 1
                Else
                    estatus = "B"
                    'estatus = 0
                End If
                listaEmpleadosDepartamento(estatus, cmbNave.SelectedValue)
            Catch ex As Exception
            End Try
        End If
    End Sub

    Public Sub listaEmpleadosDepartamento(ByVal Estatus As String, ByVal nave As Integer)
        Dim obj As New catalagosBU
        Dim tablas As New DataTable
        tablas = obj.listaEmpledosLotesProduccion(Estatus, nave)
        grdEmpleadosDpto.DataSource = tablas
        disenioGrid()
    End Sub

    'Public Sub listaEmpleadosDepartamento(ByVal Estatus As Integer, ByVal nave As Integer)
    '    Dim obj As New catalagosBU
    '    Dim tablas As New DataTable
    '    tablas = obj.listaEmpledosLotesProduccion(Estatus, nave)
    '    grdEmpleadosDpto.DataSource = tablas
    '    disenioGrid()
    'End Sub

    Public Sub disenioGrid()
        Dim band As UltraGridBand = Me.grdEmpleadosDpto.DisplayLayout.Bands(0)
        band.ColHeaderLines = 2
        band.GroupHeaderLines = 2
        With grdEmpleadosDpto.DisplayLayout.Bands(0)

            '.Columns("ID").CellActivation = Activation.NoEdit
            '.Columns("Empleado").CellActivation = Activation.NoEdit
            '.Columns("IdDepto").CellActivation = Activation.NoEdit
            '.Columns("cava_NombreGrupo").CellActivation = Activation.NoEdit
            '.Columns("dava_Activo").CellActivation = Activation.NoEdit

            '.Columns("IdDepto").Hidden = True
            '.Columns("dava_Activo").Hidden = True

            '.Columns("ID").Header.Caption = "ID COLABORADOR"
            '.Columns("Empleado").Header.Caption = "COLABORADOR"
            '.Columns("cava_NombreGrupo").Header.Caption = "DEPARTAMENTO"

            '.Columns("ID").Width = 30
            '.Columns("Empleado").Width = 140
            '.Columns("cava_NombreGrupo").Width = 140
            .Columns("Estatus").Width = 50

            .Columns("IdEmpleado").Hidden = True
            .Columns("IdDepto").Hidden = True
            .Columns("IDC").Hidden = True
            .Columns("Empleado").CellActivation = Activation.NoEdit
            .Columns("ID").CellActivation = Activation.NoEdit
            .Columns("Departamento").CellActivation = Activation.NoEdit
            .Columns("Estatus").CellActivation = Activation.NoEdit
            .Columns("ID").CellAppearance.TextHAlign = HAlign.Right
            .Columns("Empleado").Header.Caption = "Colaborador"
            .Columns("Empleado").Width = 140
            .Columns("Departamento").Width = 140
            .Columns("Estatus").Width = 50
            .Columns("ID").Width = 30
            .Columns("Estatus").Hidden = True
        End With

        grdEmpleadosDpto.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdEmpleadosDpto.DisplayLayout.Override.RowSelectorWidth = 35
        grdEmpleadosDpto.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
    End Sub

    Private Sub grdEmpleadosDpto_DoubleClick(sender As Object, e As EventArgs) Handles grdEmpleadosDpto.DoubleClick
        Try
            modificar()
        Catch ex As Exception
        End Try
        Try
            mostrar()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnAlta_Click(sender As Object, e As EventArgs) Handles btnAlta.Click
        If cmbNave.Text = "" Then
            objMensaje.mensaje = "Seleccione una nave"
            objMensaje.ShowDialog()
            lblNaveBuscar.ForeColor = Drawing.Color.Red
        Else
            lblNaveBuscar.ForeColor = Drawing.Color.Black
            obtenetIdNaveSicy()
            obtenerIdNaveSay()
            Dim form As New AsignarColaboradoresAvancesProduccionForm
            form.nave = cmbNave.SelectedValue
            form.rdoActivo.Checked = True
            form.ShowDialog()
        End If
        Try
            mostrar()
        Catch ex As Exception
        End Try
    End Sub

    Public Sub modificar()
        If cmbNave.Text = "" Then
            objMensaje.mensaje = "Seleccione una nave"
            objMensaje.ShowDialog()
            lblNaveBuscar.ForeColor = Drawing.Color.Red
        Else
            obtenetIdNaveSicy()
            obtenerIdNaveSay()
            Dim form As New AsignarColaboradoresAvancesProduccionForm
            form.idDepartamento = grdEmpleadosDpto.ActiveRow.Cells("IdDepto").Text
            form.Departamento = grdEmpleadosDpto.ActiveRow.Cells("Departamento").Text
            form.colaborador = grdEmpleadosDpto.ActiveRow.Cells("Empleado").Value
            form.idColaborador = grdEmpleadosDpto.ActiveRow.Cells("IdEmpleado").Value
            form.estatus = grdEmpleadosDpto.ActiveRow.Cells("Estatus").Value
            form.id = grdEmpleadosDpto.ActiveRow.Cells("ID").Value
            form.lblIdConfiguracion.Text = grdEmpleadosDpto.ActiveRow.Cells("IDC").Value
            form.nave = cmbNave.SelectedValue
            form.modificar = 1
            form.ShowDialog()

            'form.idDepartamento = grdEmpleadosDpto.ActiveRow.Cells("IdDepto").Value
            'form.Departamento = grdEmpleadosDpto.ActiveRow.Cells("cava_NombreGrupo").Text
            'form.colaborador = grdEmpleadosDpto.ActiveRow.Cells("Empleado").Text
            'form.idColaborador = grdEmpleadosDpto.ActiveRow.Cells("ID").Value
            'form.estatus = grdEmpleadosDpto.ActiveRow.Cells("dava_Activo").Value
            'form.nave = cmbNave.SelectedValue
            'form.modificar = 1
            'form.ShowDialog()

        End If
        mostrar()
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        Try
            modificar()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub cmbNave_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbNave.SelectedIndexChanged
        Try
            grdEmpleadosDpto.DataSource = Nothing
            rdoActivo.Checked = True
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        If grdEmpleadosDpto.Rows.Count > 0 Then
            exportarExcel()
        End If
    End Sub

    Public Sub exportarExcel()
        Dim sfd As New SaveFileDialog
        'sfd.DefaultExt = "xlsx"
        'sfd.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm"
        sfd.DefaultExt = "xls"
        sfd.Filter = "Excel Files|*.xls"
        Dim result As DialogResult = sfd.ShowDialog()
        Dim fileName As String = sfd.FileName
        If result = Windows.Forms.DialogResult.OK Then
            Try
                Me.Cursor = Cursors.WaitCursor
                ultExportGrid.Export(grdEmpleadosDpto, fileName)
                Dim objMensajeExito As New Tools.ExitoForm
                objMensajeExito.mensaje = "Archivo exportado correctamente en la ubicación: " + fileName
                objMensajeExito.StartPosition = FormStartPosition.CenterScreen
                objMensajeExito.ShowDialog()
                Process.Start(fileName)
                'grdLotesProduccion.DataSource = Nothing
            Catch ex As Exception
                Dim objMensajeError As New Tools.ErroresForm
                objMensajeError.mensaje = "El documento no pudo exportarse." + vbLf + ex.Message
                objMensajeError.StartPosition = FormStartPosition.CenterScreen
                objMensajeError.ShowDialog()
            End Try
        End If
        Me.Cursor = Cursors.Default
    End Sub


End Class