Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports System.Windows.Forms
Imports System.Drawing
Imports Tools
Imports System.ComponentModel

Public Class AltaComisionesMensualesForm
    Public idComisionEditar As Integer
    Dim objComsionEditar As Entidades.ComisionMensual = Nothing
    Dim cerrar As Integer = 0

    Private Sub AltaComisionesMensualesForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        lblMontoMax.Text = ""
        numAnio.Value = Now.Year
        numMes.Value = Now.Month
        numMontoComision.Value = 0

        If idComisionEditar > 0 Then
            Dim objBU As New Negocios.ComisionesBU
            objComsionEditar = New Entidades.ComisionMensual
            objComsionEditar = objBU.obtenerComisionModificar(idComisionEditar)

            If Not objComsionEditar Is Nothing Then
                numAnio.Value = objComsionEditar.PAnioComision
                numMes.Value = objComsionEditar.PMesComision
                numMontoComision.Value = objComsionEditar.PMontoComision
            End If
        End If

        llenarComboEmpresa()

        Me.Show()
    End Sub
    Private Sub llenarComboEmpresa()
        Dim objBU As New Negocios.UtileriasBU
        Dim dtEmpresas As New DataTable

        dtEmpresas = objBU.consultarPatronEmpresaComisiones()
        If Not dtEmpresas Is Nothing Then
            If dtEmpresas.Rows.Count > 0 Then
                cmbEmpresa.DataSource = dtEmpresas
                cmbEmpresa.ValueMember = "ID"
                cmbEmpresa.DisplayMember = "PATRON"

                If Not objComsionEditar Is Nothing Then
                    cmbEmpresa.SelectedValue = objComsionEditar.PPatronId
                End If

            Else
                cmbEmpresa.DataSource = Nothing
            End If
        Else
            cmbEmpresa.DataSource = Nothing
        End If
    End Sub

    Private Sub llenarComboPeriodo()
        Dim objMensajeError As New Tools.ErroresForm
        Dim objMensajeAdv As New Tools.AdvertenciaForm
        Try
            cmbPeriodo.DataSource = Nothing
            If cmbEmpresa.SelectedIndex > 0 Or cmbEmpresa.Items.Count = 1 And IsNumeric(cmbEmpresa.SelectedValue) Then
                Dim objBU As New Negocios.ComisionesBU
                Dim dtListado As New DataTable

                dtListado = objBU.consultarPeriodoNomina(CInt(cmbEmpresa.SelectedValue.ToString))
                If Not dtListado Is Nothing Then
                    If dtListado.Rows.Count > 0 Then
                        cmbPeriodo.DataSource = dtListado
                        cmbPeriodo.ValueMember = "Id"
                        cmbPeriodo.DisplayMember = "Descripcion"

                        If dtListado.Rows.Count > 1 Then
                            Dim dtRow As DataRow = dtListado.NewRow
                            dtRow("Id") = 0
                            dtRow("Descripcion") = ""
                            dtListado.Rows.InsertAt(dtRow, 0)
                            cmbPeriodo.SelectedIndex = 0
                        End If

                        If Not objComsionEditar Is Nothing Then
                            cmbPeriodo.SelectedValue = objComsionEditar.PPeriodoId
                        End If

                    Else
                        objMensajeAdv.mensaje = "No hay periodos de nómina para el patrón seleccionado."
                        objMensajeAdv.ShowDialog()
                    End If
                Else
                    objMensajeAdv.mensaje = "No hay periodos de nómina para el patrón seleccionado."
                    objMensajeAdv.ShowDialog()
                End If
            End If
        Catch ex As Exception
            objMensajeError.mensaje = "Error al consultar los periodos de nómina"
            objMensajeError.ShowDialog()
        End Try
    End Sub

    Private Sub cmbEmpresa_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbEmpresa.SelectedIndexChanged
        lblMontoMax.Text = ""
        llenarComboPeriodo()
        llenarComboColaboradores()
    End Sub

    Private Sub llenarComboColaboradores()
        Dim objMensajeAdv As New Tools.AdvertenciaForm
        Dim objMensajeError As New Tools.ErroresForm

        Try
            cmbColaborador.DataSource = Nothing

            If cmbEmpresa.SelectedIndex > 0 Or cmbEmpresa.Items.Count = 1 And IsNumeric(cmbEmpresa.SelectedValue) Then
                Dim objBU As New Negocios.ComisionesBU
                Dim dtColaboradores As New DataTable

                dtColaboradores = objBU.consultarColaboradoresAltaComision(cmbEmpresa.SelectedValue)
                If Not dtColaboradores Is Nothing Then
                    If dtColaboradores.Rows.Count > 0 Then
                        cmbColaborador.DataSource = dtColaboradores
                        cmbColaborador.ValueMember = "IdColaborador"
                        cmbColaborador.DisplayMember = "nombreCompleto"

                        If dtColaboradores.Rows.Count > 0 Then
                            Dim dtRow As DataRow = dtColaboradores.NewRow
                            dtRow("IdColaborador") = 0
                            dtRow("nombreCompleto") = ""
                            dtColaboradores.Rows.InsertAt(dtRow, 0)
                            cmbColaborador.SelectedIndex = 0
                        End If

                        If Not objComsionEditar Is Nothing Then
                            cmbColaborador.SelectedValue = objComsionEditar.PColaboradorId
                        End If

                    Else
                        objMensajeAdv.mensaje = "No hay colaboradores que ganen comisiones y que estén asegurados con el patrón seleccionado."
                        objMensajeAdv.ShowDialog()
                    End If
                Else
                    objMensajeAdv.mensaje = "No hay colaboradores que ganen comisiones y que estén asegurados con el patrón seleccionado."
                    objMensajeAdv.ShowDialog()
                End If

            End If
        Catch ex As Exception
            objMensajeError.mensaje = "Error al consultar los colaboradores"
            objMensajeError.ShowDialog()
        End Try
    End Sub

    Private Sub cmbColaborador_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbColaborador.SelectedIndexChanged
        numMontoComision.Maximum = 11500
        lblMontoMax.Text = ""

        If cmbColaborador.SelectedIndex > 0 Or cmbColaborador.Items.Count = 1 And IsNumeric(cmbColaborador.SelectedValue) Then
            Dim objBU As New Negocios.ComisionesBU
            Dim dtResultado As New DataTable
            Dim resultado As String = ""

            dtResultado = objBU.obtenerMaximoComision(cmbColaborador.SelectedValue)

            If dtResultado.Rows.Count > 0 Then
                If dtResultado.Rows(0).Item("cono_maximocomisiones") > 0 Then
                    resultado = String.Format("{0:C}", dtResultado.Rows(0).Item("cono_maximocomisiones"))
                    numMontoComision.Maximum = CDec(dtResultado.Rows(0).Item("cono_maximocomisiones"))

                End If
            End If

            If resultado <> "" Then
                lblMontoMax.Text = "Máximo: " & resultado
            End If

        End If

    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim objComisonesBU As New Negocios.ComisionesBU
        Dim objMensajeAdv As New AdvertenciaForm
        Dim objConfirmacion As New ConfirmarForm


        If objComisonesBU.validaEstatusPeriodoNominaFiscal(CInt(cmbPeriodo.SelectedValue)) Then
            objMensajeAdv.mensaje = "El periodo de nómina ha sido cerrado, no se pueden guardar los cambios."
            objMensajeAdv.ShowDialog()
        ElseIf validarCampos() Then
            Dim existeComision As Boolean
            existeComision = objComisonesBU.validaExisteComision(CInt(cmbColaborador.SelectedValue), CInt(numMes.Value), CInt(numAnio.Value))

            If objComsionEditar Is Nothing AndAlso existeComision Then
                'Si es un nuevo registro y valida que no exista
                objMensajeAdv.mensaje = "Ya existe una comisión registrada para el colaborador en este mes y año."
                objMensajeAdv.ShowDialog()
            ElseIf Not objComsionEditar Is Nothing AndAlso objComsionEditar.PPeriodoId <> cmbPeriodo.SelectedValue AndAlso existeComision Then
                'Si está editanto y envía a otro periodo verifica que no haya otra comisión con esos datos
                objMensajeAdv.mensaje = "Ya existe una comisión registrada para el colaborador en este mes y año."
                objMensajeAdv.ShowDialog()
            Else
                objConfirmacion.mensaje = "¿Está seguro de guardar los cambios?"
                If objConfirmacion.ShowDialog = DialogResult.OK Then
                    guardarComisiones()
                End If
            End If
        Else
            objMensajeAdv.mensaje = "Existen datos pendentes de capturar."
            objMensajeAdv.ShowDialog()
        End If


    End Sub

    Private Function validarCampos() As Boolean
        Dim resultado As Boolean = True

        If cmbEmpresa.SelectedIndex > 0 Then
            lblPatron.ForeColor = Color.Black
        Else
            lblPatron.ForeColor = Color.Red
            resultado = False
        End If

        If cmbPeriodo.SelectedIndex > 0 Then
            lblPeriodo.ForeColor = Color.Black
        Else
            lblPeriodo.ForeColor = Color.Red
            resultado = False
        End If

        If cmbColaborador.SelectedValue <> 0 Then
            lblColaborador.ForeColor = Color.Black
        Else
            lblColaborador.ForeColor = Color.Red
            resultado = False
        End If

        If numMontoComision.Value > 0 Then
            lblMontoComision.ForeColor = Color.Black
        Else
            lblMontoComision.ForeColor = Color.Red
            resultado = False
        End If

        Return resultado
    End Function
    Private Sub guardarComisiones()
        Try
            Dim objComision As New Entidades.ComisionMensual
            Dim objBU As New Negocios.ComisionesBU
            Dim mensajeExito As New ExitoForm
            Dim mensajeError As ErroresForm = Nothing
            Dim mensaje As String
            Dim contadorerror As Integer = 0


            If Not objComsionEditar Is Nothing Then
                objComision.PComisionId = objComsionEditar.PComisionId
            Else
                objComision.PComisionId = 0
            End If

            objComision.PColaboradorId = cmbColaborador.SelectedValue
            ''objComision.PSDIColaborador = row.Cells("SDI").Value ''Guardar en SP
            objComision.PPatronId = cmbEmpresa.SelectedValue
            objComision.PPeriodoId = cmbPeriodo.SelectedValue
            objComision.PMontoComision = numMontoComision.Value
            objComision.PMesComision = numMes.Value
            objComision.PAnioComision = numAnio.Value
            objComision.PUsuarioCreo = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
            objComision.PUsuarioModifica = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
            ''objComision.PMaxColaborador = ''Guardar en SP
            ''objComision.PMaxPatron = row.Cells("patr_porcentajecomisiones").Value ''No se usará

            mensaje = objBU.guardarComisiones(objComision)
            If mensaje <> "EXITO" Then
                contadorerror += 1
            End If


            If contadorerror > 0 Then
                mensajeError = New ErroresForm
                mensajeError.mensaje = "Ocurrió un erro al intentar guardar la información."
                mensajeError.ShowDialog()
            Else
                mensajeExito.mensaje = "Información guardada correctamente."
                mensajeExito.ShowDialog()
                cerrar = 1
                Me.Close()
            End If

            'limpiar()

        Catch ex As Exception
            Dim mensajeError As New ErroresForm
            mensajeError.mensaje = "Ocurrió un erro al intentar guardar la información." + vbNewLine + ex.ToString
            mensajeError.ShowDialog()
        End Try

    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        cerrar = 1
        Me.Close()
    End Sub

    Private Sub AltaComisionesMensualesForm_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        If cerrar = 0 Then
            e.Cancel = True
        End If
    End Sub
End Class