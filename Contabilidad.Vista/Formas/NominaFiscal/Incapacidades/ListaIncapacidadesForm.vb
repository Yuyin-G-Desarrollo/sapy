Imports Framework.Negocios
Imports System.Windows.Forms
Imports Tools
Imports System.Drawing

Public Class ListaIncapacidadesForm

    Dim colaboradorIncId As Int32 = 0
    Dim fechaInicioInc As Date
    Dim fechaFinInc As Date
    Dim idIncGlobal As Int32 = 0

    Private Sub ListaIncapacidadesForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        WindowState = FormWindowState.Maximized

        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("NOM_LIST_INCA", "NOM_INCA_PATR") Then
            cmbPatrones.Visible = True
            lblPatrones.Visible = True
        End If

        Tools.FormatoCtrls.formato(Me)
        Controles.ComboNavesSegunUsuario(cmbNave, CInt(Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid.ToString))
        '  Controles.ComboPatrones(cmbPatrones)
        Dim objBu As New Contabilidad.Negocios.UtileriasBU
        Dim dtEmpresa As New DataTable

        dtEmpresa = objBu.consultarPatronEmpresa()
        If dtEmpresa.Rows.Count > 0 Then
            cmbPatrones.DataSource = dtEmpresa
            cmbPatrones.DisplayMember = "Patron"
            cmbPatrones.ValueMember = "ID"
            cmbPatrones.SelectedIndex = 0
        End If
        cargarComboEstatus()
        configurarPermisosBotonesEspeciales()
    End Sub

    Public Sub cargarComboEstatus()
        Dim objBu As New Negocios.IncapacidadesBU
        Dim dtEstatus As New DataTable
        dtEstatus = objBu.consultaListadoEstatus("INCAPACIDADES")

        If dtEstatus.Rows.Count > 0 Then
            cmbEstatus.DataSource = dtEstatus
            cmbEstatus.DisplayMember = "Estatus"
            cmbEstatus.ValueMember = "ID"
            cmbEstatus.SelectedValue = 110
        End If
    End Sub

    Private Sub ListaIncapacidadesForm_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.KeyChar = Char.ToUpper(e.KeyChar)
        End If
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        grdListaIncapacidades.Rows.Clear()
        Dim estamal As Boolean = False
        Dim patronID As Integer = 0
        colaboradorIncId = 0

        If cmbNave.SelectedIndex = 0 Then
            lblNave.ForeColor = Color.Red
            estamal = True

            'If cmbPatrones.SelectedIndex = 0 Then
            '    lblPatrones.ForeColor = Color.Red
            '    estamal = True
            'Else
            '    estamal = False
            '    lblPatrones.ForeColor = Color.Black
            '    lblNave.ForeColor = Color.Black
            'End If

        Else
            lblNave.ForeColor = Color.Black
            lblPatrones.ForeColor = Color.Black
        End If

        'If cmbEstatus.Text = "" Then
        '    lblEstatus.ForeColor = Color.Red
        '    estamal = True
        'Else
        '    lblEstatus.ForeColor = Color.Black
        'End If

        If estamal = False Then
            Dim Estatus As String = ""
            If cmbEstatus.Text = "TODAS" Then
                Estatus = ""
            ElseIf cmbEstatus.Text = "REPLICADAS" Then
                Estatus = "TRUE"
            ElseIf cmbEstatus.Text = "SIN REPLICAR" Then
                Estatus = "FALSE"
            End If

            If cmbPatrones.SelectedIndex > 0 Then
                patronID = cmbPatrones.SelectedValue
            End If
            ListaIncapacidadesFiltro(cmbNave.SelectedValue, txtColaborador.Text, cmbEstatus.SelectedValue, patronID, dtpFechaInicio.Value, dtpFechaFin.Value)
        End If

    End Sub


    Public Sub ListaIncapacidadesFiltro(ByVal NaveID As Integer, Colaborador As String, Estatus As String, ByVal patronID As Integer, ByVal dtpFechaInicio As DateTime, ByVal dtpFechaFin As DateTime)
        Dim ListaIncapacidades As New List(Of Entidades.Incapacidades)
        Dim ObjBU As New Negocios.IncapacidadesBU
        Dim ObjDA As New Entidades.Incapacidades
        Dim Replicado As String = ""

        ListaIncapacidades = ObjBU.ListaIncapacidadesFiltro(NaveID, Colaborador, Estatus, patronID, dtpFechaInicio, dtpFechaFin)

        For Each fila As Entidades.Incapacidades In ListaIncapacidades
            If fila.PIncapacidadNominpaq = True Then
                Replicado = "SI"
            Else
                Replicado = "NO"
            End If
            grdListaIncapacidades.Rows.Add(fila.PIncapacidadID, fila.PColaborador.PColaboradorid, grdListaIncapacidades.Rows.Count + 1, fila.PColaborador.PNombre, fila.PIncapacidadFolio, fila.PIncapacidadFechaInicio.ToShortDateString, fila.PIncapacidadFechaFin.ToShortDateString, fila.PIncapacidadDiasAutorizados, fila.PRamoSeguroDescripcion, fila.PTipoRiesgoDescripcion, fila.PControlIncapacidadDescripcion, fila.PSecuelaDescripcion, fila.PTipoMaternidadDescripcion, fila.PIncapacidadDescripcion, Replicado)
            If fila.PValidaModificacion <> 0 Then
                grdListaIncapacidades.Rows(grdListaIncapacidades.RowCount - 1).DefaultCellStyle.ForeColor = Color.Red
            End If
            If fila.PValidaInicial <> 0 Then
                grdListaIncapacidades.Rows(grdListaIncapacidades.RowCount - 1).DefaultCellStyle.ForeColor = Color.Green
            End If
        Next

    End Sub

    Private Sub btnLimpiar_clic(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        limpiar()
    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        grbParametros.Height = 45
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        grbParametros.Height = 151
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub cmbNave_DropDownClosed(sender As Object, e As EventArgs) Handles cmbNave.DropDownClosed
        grdListaIncapacidades.Rows.Clear()
        txtColaborador.Text = ""
    End Sub

    Public Sub limpiar()
        grdListaIncapacidades.Rows.Clear()
        cmbNave.SelectedIndex = 0
        cmbEstatus.SelectedIndex = 0
        txtColaborador.Text = ""
        lblNave.ForeColor = Color.Black
        lblPatrones.ForeColor = Color.Black
        dtpFechaInicio.Value = Now
        dtpFechaFin.Value = Now
        colaboradorIncId = 0
    End Sub

    Private Sub BtnAlta_Click(sender As Object, e As EventArgs) Handles BtnAlta.Click
        Dim Objalta As New AltaIncapacidadesForm
        Objalta.Show()
    End Sub

    Public Sub configurarPermisosBotonesEspeciales()
        If PermisosUsuarioBU.ConsultarPermiso("NOM_LIST_INCA", "EDITAR_INCA") Then
            pnlEditar.Visible = True
        Else
            pnlEditar.Visible = False
        End If

        If PermisosUsuarioBU.ConsultarPermiso("NOM_LIST_INCA", "ALTA_INCA") Then
            pnlAltas.Visible = True
        Else
            pnlAltas.Visible = False
        End If
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        Dim ObjEditar As New EditarIncapacidadesForm
        Dim objBu As New Negocios.IncapacidadesContabilidadBU
        Dim dtValida As New DataTable
        Dim estatus As String = String.Empty
        Dim validaRT As Boolean = False

        dtValida = objBu.validarEstatus(idIncGlobal, 2)
        If dtValida.Rows.Count > 0 Then
            estatus = dtValida.Rows(0).Item("mensaje")
            validaRT = dtValida.Rows(0).Item("rt")
        End If
        If colaboradorIncId <> 0 Then
            If estatus = "CORRECTO" Then
                ObjEditar.colaboradorIncapacidadId = colaboradorIncId
                ObjEditar.fechaInicioInc = fechaInicioInc
                ObjEditar.fechaFinInc = fechaFinInc
                ObjEditar.validaRT = validaRT
                ObjEditar.Show()
            Else
                Dim advetencia As New AdvertenciaForm
                advetencia.mensaje = "No es posible editar una incapacidad que se encuentra aplicada"
                advetencia.ShowDialog()
            End If

        Else
            Dim advetencia As New AdvertenciaForm
            advetencia.mensaje = "Seleccione una incapacidad válida"
            advetencia.ShowDialog()
        End If


    End Sub

    Private Sub grdListaIncapacidades_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdListaIncapacidades.CellClick
        If e.RowIndex >= 0 Then
            colaboradorIncId = CInt(grdListaIncapacidades.Rows(e.RowIndex).Cells("colaboradorId").Value)
            fechaInicioInc = CDate(grdListaIncapacidades.Rows(e.RowIndex).Cells("clmFechaInicio").Value)
            fechaFinInc = CDate(grdListaIncapacidades.Rows(e.RowIndex).Cells("clmFechaFin").Value)
            idIncGlobal = CInt(grdListaIncapacidades.Rows(e.RowIndex).Cells("clmIncapacidadID").Value)

        End If
    End Sub
End Class