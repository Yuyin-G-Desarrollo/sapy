Imports System.Windows.Forms
Imports Cobranza.Negocios
Imports Stimulsoft.Report
Imports Tools
Imports Tools.Utilerias

Public Class Cobranza_Reporte_EstadosdeCuentaporAgente
    Dim objBU As New EstadosDeCuentaReporteBU
    Dim bloqueo As Boolean = True
    Dim colaboradorId As Int32 = Entidades.SesionUsuario.UsuarioSesion.PIDColaboradorUser

    Private Sub lista_Empresas()

        Dim tabla As New DataTable
        tabla = objBU.Combo_lista_Empresas_Say_Sicy_Contpaq
        tabla.Rows.InsertAt(tabla.NewRow, 0)
        cmbRazonSocial.DisplayMember = "essc_razonsocial"
        cmbRazonSocial.ValueMember = "essc_contribuyentesicyid"
        cmbRazonSocial.DataSource = tabla

        cmbRazonSocial.AutoCompleteMode = AutoCompleteMode.Suggest
        cmbRazonSocial.AutoCompleteSource = AutoCompleteSource.ListItems
    End Sub
    Public Sub cargarComboAgentes()
        Dim dtAgentes As New DataTable
        Dim objDatosBu As New EstadosDeCuentaReporteBU
        dtAgentes = objDatosBu.consultaComboAgentesParaFamilia(colaboradorId)

        If dtAgentes.Rows.Count > 0 Then
            Dim newrow As DataRow = dtAgentes.NewRow
            If dtAgentes.Rows.Count > 1 Then
                dtAgentes.Rows.InsertAt(newrow, 0)
            End If

            cmbAgente.DataSource = dtAgentes
            cmbAgente.ValueMember = "cmae_colaboradorid_agente"
            cmbAgente.DisplayMember = "nombre"
            If dtAgentes.Rows.Count = 2 Then
                cmbAgente.SelectedIndex = 1
            End If
        End If
        cmbAgente.AutoCompleteMode = AutoCompleteMode.Suggest
        cmbAgente.AutoCompleteSource = AutoCompleteSource.ListItems
    End Sub

    Public Sub llenarComboClientes()
        Dim objColCli As New EstadosDeCuentaReporteBU
        Dim dtClientes As New DataTable
        dtClientes = objColCli.ConsultarClientesEstadosDCuentaCXC
        If Not dtClientes.Rows.Count = 0 Then
            dtClientes.Rows.InsertAt(dtClientes.NewRow, 0)
            cmbClientes.DataSource = dtClientes
            cmbClientes.DisplayMember = "clie_nombregenerico"
            cmbClientes.ValueMember = "clie_idsicy"
        End If
        cmbClientes.AutoCompleteMode = AutoCompleteMode.Suggest
        cmbClientes.AutoCompleteSource = AutoCompleteSource.ListItems
    End Sub

    Private Sub Cobranza_Reporte_EstadosdeCuentaporAgente_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Centrar(Me)
        llenarComboClientes()
        cargarComboAgentes()
        lista_Empresas()

        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VTAS_ESTADOSCUENTA", "FRM_VER_R_GENERAL") Then
            rdGeneral.Visible = True
            bloqueo = False
        Else
            Dim tamaño As New Drawing.Point
            tamaño.X = 58
            tamaño.Y = 19
            rdDetallado.Location = tamaño
            rdDetallado.Checked = True
        End If

        objBU.EjecutarProce_Obtener_AgenteActualporDocumento()
        cbtipo.SelectedIndex = 0
    End Sub
    Private Sub Centrar(ByVal Objeto As Object)

        ' Centrar un Formulario ...  
        If TypeOf Objeto Is Form Then
            Dim frm As Form = CType(Objeto, Form)
            With Screen.PrimaryScreen.WorkingArea ' Dimensiones de la pantalla sin el TaskBar  
                frm.Top = (.Height - frm.Height) \ 2
                frm.Left = (.Width - frm.Width) \ 2
            End With

            ' Centrar un control dentro del contenedor  
        Else
            ' referencia al control  
            Dim c As Control = CType(Objeto, Control)

            'le  establece el top y el Left dentro del Parent  
            With c
                .Top = (.Parent.ClientSize.Height - c.Height) \ 2
                .Left = (.Parent.ClientSize.Width - c.Width) \ 2
            End With
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim pasas As Integer = 0

        If bloqueo Then
            If IsDBNull(cmbAgente.SelectedValue) Then
                If IsDBNull(cmbClientes.SelectedValue) Then
                    Utilerias.show_message(TipoMensaje.Advertencia, "Es obligatorio seleccionar un Filtro en la busqueda")
                    pasas = 1
                End If
            ElseIf cmbAgente.SelectedValue = 0 Then
                If cmbClientes.SelectedValue = 0 Then
                    Utilerias.show_message(TipoMensaje.Advertencia, "Es obligatorio seleccionar un Filtro en la busqueda")
                    pasas = 1
                End If
            End If
        End If

        If pasas = 0 Then
            ConsultarInformacion()
        End If
    End Sub

    Private Sub ConsultarInformacion()
        Cursor = Cursors.WaitCursor

        Dim dsEstadosCuenta As New DataSet("dsEstadosCuenta")
        Dim dtEstadosCuenta As New DataTable("dtEstadosCuenta")

        Dim razonsocial = If(IsDBNull(cmbRazonSocial.SelectedValue), 0, cmbRazonSocial.SelectedValue)
        Dim agente = If(IsDBNull(cmbAgente.SelectedValue), 0, cmbAgente.SelectedValue)
        Dim cliente = If(IsDBNull(cmbClientes.SelectedValue), 0, cmbClientes.SelectedValue)

        Dim fechaAFA = If(rdFAFA.Checked, 1, 0)
        Dim fechaEFA = If(rdEFA.Checked, 1, 0)
        Dim todos = If(rdTodos.Checked, 1, 0)
        Dim tipo As Integer = 0
        If cbtipo.Text = "TODOS" Then
            tipo = 0
        ElseIf cbtipo.Text = "FACTURAS" Then
            tipo = 1
        Else
            tipo = 2
        End If





        If rdDetallado.Checked Then
            dtEstadosCuenta = objBU.ConsultarReporteEstadoCuenta(Format(CDate(dtfechaAnalisis.Value), "dd/MM/yyyy"), razonsocial, agente, cliente, fechaAFA, fechaEFA, todos, tipo)
        Else
            dtEstadosCuenta = objBU.ConsultarReporteGeneralEstadoCuenta(Format(CDate(dtfechaAnalisis.Value), "dd/MM/yyyy"), razonsocial, agente, cliente, fechaAFA, fechaEFA, todos, tipo)
        End If

        If rdDetallado.Checked Then
            If dtEstadosCuenta.Rows(0).Item("datos") > 0 Then

                Dim OBJBU2 As New Framework.Negocios.ReportesBU
                Dim EntidadReporte As Entidades.Reportes
                EntidadReporte = OBJBU2.LeerReporteporClave("CBR_REPORTE_ESTADO_CUENTA_DTA")
                Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
                LTrim(RTrim(EntidadReporte.Pnombre)) + ".mrt"
                My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)
                Dim reporte As New StiReport
                reporte.Load(archivo)
                reporte.Compile()
                reporte("FECHA") = dtfechaAnalisis.Value
                If rdFAFA.Checked Then
                    reporte("tipoReporte") = "Vencidos a la Fecha de Analisis"
                End If
                If rdEFA.Checked Then
                    reporte("tipoReporte") = "Vencidos en la Fecha de Analisis"
                End If
                If rdTodos.Checked Then
                    reporte("tipoReporte") = "Todos"
                End If

                reporte.Dictionary.Clear()
                reporte.Dictionary.Synchronize()

                reporte.Render()
                reporte.Show()
            Else
                Utilerias.show_message(TipoMensaje.Advertencia, "No hay datos que mostrar")
            End If
        Else
            If dtEstadosCuenta.Rows.Count > 0 Then
                dtEstadosCuenta.TableName = "dtEstadosCuenta"

                dsEstadosCuenta.Tables.Add(dtEstadosCuenta)

                Dim OBJBU2 As New Framework.Negocios.ReportesBU
                Dim EntidadReporte As Entidades.Reportes
                EntidadReporte = OBJBU2.LeerReporteporClave("CBR_REPORTE_GRAL_COBRANZA")
                Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
               LTrim(RTrim(EntidadReporte.Pnombre)) + ".mrt"
                My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)
                Dim reporte As New StiReport
                reporte.Load(archivo)
                reporte.Compile()
                reporte("FECHA") = dtfechaAnalisis.Value
                If rdFAFA.Checked Then
                    reporte("tipoReporte") = "Vencidos a la Fecha de Analisis"
                End If
                If rdEFA.Checked Then
                    reporte("tipoReporte") = "Vencidos en la Fecha de Analisis"
                End If
                If rdTodos.Checked Then
                    reporte("tipoReporte") = "Todos"
                End If

                reporte.Dictionary.Clear()
                reporte.RegData(dsEstadosCuenta)
                reporte.Dictionary.Synchronize()

                reporte.Render()
                reporte.Show()
            Else
                Utilerias.show_message(TipoMensaje.Advertencia, "No hay datos que mostrar")
            End If

        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    'Private Function VerificarVersion() As Boolean
    '    Dim versionNueva As String
    '    Dim VersionProduccion As String

    '    Try
    '        versionNueva = My.Settings.VersionSAY
    '        versionNueva = versionNueva.Substring(versionNueva.Length - 4)
    '        VersionProduccion = ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString

    '        If CInt(versionNueva) <= VersionProduccion Then

    '        End If

    '    Catch ex As Exception

    '        Utilerias.show_message(TipoMensaje.Advertencia, "Es necesario Actualizar >= 1.0.1.2621")
    '        Return False
    '    End Try
    '    Return True
    'End Function

End Class