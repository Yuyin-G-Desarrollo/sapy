Imports Tools
Imports Entidades
Imports System.IO
Public Class EtiquetasProveedoresForm

    Private _ListaStr As List(Of String)
    Public Property ListaStr() As List(Of String)
        Get
            Return _ListaStr
        End Get
        Set(ByVal value As List(Of String))
            _ListaStr = value
        End Set
    End Property

    Dim naveid As Integer
    Dim tablanaves As New DataTable
    Dim tablaProveedor As New DataTable
    Dim fechaPrograma As Date
    Dim clasificacionProvPlanta As Integer = 40
    Dim clasificacionProvSuela As Integer = 49
    Dim clasificacionProvPlantilla As Integer = 41
    Dim clasificacionEtiqPlanta As String = "11"
    Dim ClasificacionEtiqSuela As String = "14,15"
    Dim validacion As Boolean = False
    Dim tablaDatos As DataTable
    Dim lote As Integer
    Dim idProveedor As Integer
    Dim grupo As String
    Dim navesId As String
    Dim navesNombre = String.Empty
    Dim usuario = String.Empty

    Dim clik As Integer = 0
    Dim contimer As Integer = 0
    Private Sub EtiquetasProveedoresForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        iniciar()
    End Sub

    Public Sub iniciar()
        cboNave = Tools.Controles.ComboNavesSegunUsuarioConIdSIcy(cboNave, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
        'cboNave = Tools.Controles.ComboNavesSegunUsuarioConIdSIcysinIndiceCero(cboNave, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
        dtpFecha.Value = Now.ToShortDateString
        dtpFechaAl.Value = Now.ToShortDateString
        cargarImpresoras(cboImpresora)
        cargarGrupo()
        usuario = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
    End Sub

    Private Sub cboNave_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboNave.SelectedIndexChanged
        'btEtiquetasConsumos.Checked = True
    End Sub

    Private Sub rbtEtiquetasConsumos_CheckedChanged(sender As Object, e As EventArgs) Handles rbtEtiquetasConsumos.CheckedChanged


        If rbtEtiquetasConsumos.Checked = False Then
            Exit Sub
        End If
        chkTodosProveedores.Checked = False
        chkTodasNaves.Checked = False
        cboProveedor.SelectedValue = 0
        cboProveedor.Text = Nothing
        cboProveedor.Enabled = False
        gpodetalles.Enabled = False

        Cursor = Cursors.Default
    End Sub

    Private Sub rbtEtiquetasPlanta_CheckedChanged(sender As Object, e As EventArgs) Handles rbtEtiquetasPlanta.CheckedChanged
        Dim objBu = New Programacion.Negocios.EtiquetasBU

        Cursor = Cursors.WaitCursor
        Try
            If rbtEtiquetasPlanta.Checked = False Then
                Exit Sub
            End If

            cboProveedor.SelectedValue = 0
            cboProveedor.Text = Nothing
            gpodetalles.Enabled = True
            cboProveedor.Enabled = False
            chkTodosProveedores.Checked = True
            txtLote.Text = Nothing
            chkTodasNaves.Enabled = True
            naveid = Nothing
            grupo = Nothing

            If cboNave.SelectedValue > 0 Or cboGrupo.SelectedItem("grupo").ToString() <> "" Then

                If cboGrupo.SelectedItem("grupo").ToString() <> "TODAS" Then
                    fechaPrograma = dtpFecha.Value

                    If rbtPorNave.Checked Then
                        naveid = cboNave.SelectedValue
                        If chkRangoFechas.Checked Then
                            tablaProveedor = objBu.ProveedorPlantaRangoFechas(naveid, fechaPrograma, dtpFechaAl.Value.ToShortDateString, clasificacionProvPlanta)
                        Else
                            tablaProveedor = objBu.ProveedorPlanta(naveid, fechaPrograma, clasificacionProvPlanta)
                        End If

                    End If
                    If rbtPorGrupo.Checked Then
                        grupo = cboGrupo.SelectedItem("grupo")
                        tablaProveedor = objBu.ProveedorPlantaPorGrupo(fechaPrograma, clasificacionProvPlanta, grupo)
                    End If


                    If tablaProveedor.Rows.Count > 0 Then
                        tablaProveedor.Rows.InsertAt(tablaProveedor.NewRow, 0)
                        cboProveedor.DataSource = tablaProveedor
                        cboProveedor.ValueMember = "IdProveedor"
                        cboProveedor.DisplayMember = "RazonSocial"
                    Else
                        cboProveedor.SelectedText = ""
                        show_message("Advertencia", "No existe información para mostrar el proveedor.")
                    End If
                Else
                    Cursor = Cursors.Default
                    cboGrupo.Text = ""
                    Exit Sub
                End If

            Else
                show_message("Advertencia", "Seleccione una nave o grupo")
            End If
            'Cursor = Cursors.Default
        Catch ex As Exception
            'Cursor = Cursors.Default
            show_message("Error", ex.Message)
        End Try

        Cursor = Cursors.Default
    End Sub


    Private Sub rbtEtiquetasSuela_CheckedChanged(sender As Object, e As EventArgs) Handles rbtEtiquetasSuela.CheckedChanged
        Dim objBu = New Programacion.Negocios.EtiquetasBU
        Cursor = Cursors.WaitCursor
        Try
            If rbtEtiquetasSuela.Checked = False Then
                Exit Sub
            End If

            cboProveedor.SelectedValue = 0
            cboProveedor.Text = Nothing
            gpodetalles.Enabled = True
            cboProveedor.Enabled = False
            chkTodosProveedores.Checked = True
            txtLote.Text = Nothing
            chkTodasNaves.Enabled = True
            naveid = Nothing
            grupo = Nothing

            If cboNave.SelectedValue > 0 Or cboGrupo.SelectedItem("grupo").ToString() <> "" Then


                fechaPrograma = dtpFecha.Value

                If rbtPorNave.Checked Then
                    naveid = cboNave.SelectedValue
                    If chkRangoFechas.Checked Then
                        tablaProveedor = objBu.ProveedorSuelaRangoFechas(naveid, fechaPrograma, dtpFechaAl.Value.ToShortDateString, clasificacionProvSuela)
                    Else
                        tablaProveedor = objBu.ProveedorSuela(naveid, fechaPrograma, clasificacionProvSuela)
                    End If
                End If
                If rbtPorGrupo.Checked Then
                    grupo = cboGrupo.SelectedItem("grupo")
                    If chkRangoFechas.Checked Then
                        tablaProveedor = objBu.ProveedorSuelaPorGrupoFechas(fechaPrograma, dtpFechaAl.Value.ToShortDateString, clasificacionProvSuela, grupo)
                    Else
                        tablaProveedor = objBu.ProveedorSuelaPorGrupo(fechaPrograma, clasificacionProvSuela, grupo)
                    End If

                End If


                If tablaProveedor.Rows.Count > 0 Then
                    tablaProveedor.Rows.InsertAt(tablaProveedor.NewRow, 0)
                    cboProveedor.DataSource = tablaProveedor
                    cboProveedor.ValueMember = "IdProveedor"
                    cboProveedor.DisplayMember = "RazonSocial"
                Else
                    show_message("Advertencia", "No existe información para mostrar el proveedor.")
                End If

            Else
                show_message("Advertencia", "Seleccione una nave o grupo")
            End If
            'Cursor = Cursors.Default
        Catch ex As Exception
            'Cursor = Cursors.Default
            show_message("Error", ex.Message)
        End Try
        Cursor = Cursors.Default
    End Sub


    Private Sub rbtEtiquetasPlantilla_CheckedChanged(sender As Object, e As EventArgs) Handles rbtEtiquetasPlantilla.CheckedChanged
        Dim objBu = New Programacion.Negocios.EtiquetasBU
        Cursor = Cursors.WaitCursor
        Try
            If rbtEtiquetasPlantilla.Checked = False Then
                Exit Sub
            End If

            cboProveedor.SelectedValue = 0
            cboProveedor.Text = Nothing
            cboProveedor.Enabled = False
            chkTodosProveedores.Checked = True
            gpodetalles.Enabled = True
            txtLote.Text = Nothing
            chkTodasNaves.Enabled = True
            naveid = Nothing
            grupo = Nothing

            If cboNave.SelectedValue > 0 Or cboGrupo.SelectedItem("grupo").ToString() <> "" Then

                If cboGrupo.SelectedItem("grupo").ToString() <> "TODAS" Then
                    fechaPrograma = dtpFecha.Value

                    If rbtPorNave.Checked Then
                        naveid = cboNave.SelectedValue
                        If chkRangoFechas.Checked Then
                            tablaProveedor = objBu.ProveedorPlantillaRangoFechas(naveid, fechaPrograma, dtpFechaAl.Value.ToShortDateString, clasificacionProvPlantilla)
                        Else
                            tablaProveedor = objBu.ProveedorPlantilla(naveid, fechaPrograma, clasificacionProvPlantilla)
                        End If

                    End If

                    If rbtPorGrupo.Checked Then
                        grupo = cboGrupo.SelectedItem("grupo")
                        tablaProveedor = objBu.ProveedorPlantillaPorGrupo(fechaPrograma, clasificacionProvPlantilla, grupo)
                    End If

                    If tablaProveedor.Rows.Count > 0 Then
                        tablaProveedor.Rows.InsertAt(tablaProveedor.NewRow, 0)
                        cboProveedor.DataSource = tablaProveedor
                        cboProveedor.ValueMember = "IdProveedor"
                        cboProveedor.DisplayMember = "RazonSocial"
                    Else
                        show_message("Advertencia", "No existe información para mostrar el proveedor.")
                    End If
                Else
                    Cursor = Cursors.Default
                    cboGrupo.Text = ""
                    Exit Sub
                End If

            Else
                show_message("Advertencia", "Seleccione una nave o grupo")
            End If
        Catch ex As Exception
            show_message("Error", ex.Message)
        End Try
        Cursor = Cursors.Default

    End Sub

    Public Sub cargarImpresoras(ByVal cmb As ComboBox)
        Dim objBu As New Programacion.Negocios.EtiquetasBU
        Dim tablaImpresoras As New DataTable

        tablaImpresoras = objBu.ListaImpresoras()
        cboImpresora.DataSource = tablaImpresoras
        cboImpresora.DisplayMember = "Nombre"
        cboImpresora.ValueMember = "IdImpresora"

    End Sub
    Public Sub show_message(ByVal tipo As String, ByVal mensaje As String)

        If tipo.ToString.Equals("Advertencia") Then

            Dim mensajeAdvertencia As New Tools.AdvertenciaForm
            mensajeAdvertencia.mensaje = mensaje
            mensajeAdvertencia.ShowDialog()

        End If

        If tipo.ToString.Equals("Aviso") Then

            Dim mensajeAviso As New Tools.AvisoForm
            mensajeAviso.mensaje = mensaje
            mensajeAviso.ShowDialog()

        End If

        If tipo.ToString.Equals("Error") Then

            Dim mensajeError As New Tools.ErroresForm
            mensajeError.mensaje = mensaje
            mensajeError.ShowDialog()

        End If

        If tipo.ToString.Equals("Exito") Then

            Dim mensajeExito As New Tools.ExitoForm
            mensajeExito.mensaje = mensaje
            mensajeExito.ShowDialog()

        End If

        If tipo.ToString.Equals("Confirmar") Then

            Dim mensajeExito As New Tools.ConfirmarForm
            mensajeExito.mensaje = mensaje
            mensajeExito.ShowDialog()

        End If

    End Sub

    Private Sub chkTodosProveedores_CheckedChanged(sender As Object, e As EventArgs) Handles chkTodosProveedores.CheckedChanged
        If chkTodosProveedores.Checked = True Then
            cboProveedor.Text = ""
            cboProveedor.Enabled = False
            chkTodasNaves.Checked = False

        ElseIf chkTodosProveedores.Checked = False Then
            cboProveedor.Text = ""
            cboProveedor.Enabled = True
            chkTodasNaves.Checked = True
        End If
    End Sub

    Private Sub chkTodasNaves_CheckedChanged(sender As Object, e As EventArgs) Handles chkTodasNaves.CheckedChanged
        If chkTodasNaves.Checked = True Then
            cboProveedor.Text = ""
            cboProveedor.Enabled = True
            chkTodosProveedores.Checked = False
        ElseIf chkTodasNaves.Checked = False Then
            chkTodosProveedores.Checked = True
            cboProveedor.Enabled = False
        End If
    End Sub

    Private Sub txtlevantamiento_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtLote.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
            show_message("Advertencia", "Solo se admite ingresar números enteros.")
        End If
    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        Dim objN As New Programacion.Negocios.EtiquetasBU
        Dim objNeg As New Programacion.Negocios.EtiquetasBU
        Dim obj As New Object
        Dim archivo As New Object
        Dim ruta As String = "C:\SAY\Etiquetas.txt"
        Dim sArchivoOrigen As String = "C:\SICY\Etiquetas.bat"
        Dim sRutaDestino As String = "C:\SAY\Etiquetas.bat"
        Dim existe As Boolean
        Dim impresora As Integer


        Me.Cursor = Cursors.WaitCursor
        Try
            validar()
            If validacion = True Then

                If cboGrupo.SelectedItem("grupo").ToString() <> "" Then
                    grupo = cboGrupo.SelectedItem("grupo")
                Else
                    grupo = ""
                End If

                'If chkTodasNaves.Checked = True Then
                '    naveid = 0
                'Else
                '    naveid = cboNave.SelectedValue
                'End If

                If rbtPorNave.Checked Then
                    naveid = cboNave.SelectedValue
                Else
                    naveid = 0
                End If

                navesId = String.Empty
                navesNombre = String.Empty
                If rbtPorGrupo.Checked Then
                    If cboNave.Enabled Then
                        naveid = cboNave.SelectedValue

                    ElseIf cboNave2.Enabled Then
                        For Each item As Infragistics.Win.ValueListItem In cboNave2.Items
                            If item.CheckState = CheckState.Checked Then
                                If navesId = String.Empty Then
                                    navesId = CStr(item.DataValue.ToString)
                                    navesNombre = item.DisplayText
                                Else
                                    navesId = CStr(item.DataValue.ToString) + "," + navesId
                                    navesNombre = item.DisplayText + "," + navesNombre
                                End If
                            End If
                        Next
                    End If
                End If

                If txtLote.Text.Length > 0 Then
                    lote = CInt(txtLote.Text)
                Else
                    lote = 0
                End If


                'If cboProveedor.Text.Length > 0 Then
                '    idProveedor = cboProveedor.SelectedValue
                'Else
                '    idProveedor = 0
                'End If

                If rbtEtiquetasConsumos.Checked = False Then
                    If chkTodasNaves.Checked Then
                        If cboProveedor.Text.Length > 0 Then
                            idProveedor = cboProveedor.SelectedValue
                        Else
                            show_message("Advertencia", "Seleccione un proveedor.")
                            Me.Cursor = Cursors.Default
                            Return
                        End If
                    Else
                        idProveedor = 0
                    End If
                End If


                impresora = cboImpresora.SelectedValue

                existe = System.IO.Directory.Exists("C:\SAY")
                If Not existe Then
                    System.IO.Directory.CreateDirectory("C:\SAY")
                End If

                obj = CreateObject("Scripting.FileSystemObject")
                archivo = obj.CreateTextFile(ruta, True)

                If rbtEtiquetasConsumos.Checked = True Then
                    If chkRangoFechas.Checked Then
                        tablaDatos = objN.ConsultaEtiquetasConsumosFechas(naveid, dtpFecha.Value.ToShortDateString, dtpFechaAl.Value.ToShortDateString, impresora)
                    Else
                        tablaDatos = objN.ConsultaEtiquetasConsumos(naveid, dtpFecha.Value.ToShortDateString, impresora)
                    End If
                End If

                If rbtEtiquetasPlanta.Checked = True Then
                    'tablaDatos = objN.ConsultaEtiquetasPlantaSuela(naveid, dtpFecha.Value.ToShortDateString, idProveedor, lote, clasificacionEtiqPlanta, impresora)
                    If cboGrupo.Text = "FVO" Or cboGrupo.Text = "RVO" Or cboGrupo.Text = "" Then
                        If navesId = String.Empty Then
                            If chkRangoFechas.Checked Then
                                tablaDatos = objN.ConsultaEtiquetasPlantaSuelaFechas(naveid, dtpFecha.Value.ToShortDateString, dtpFechaAl.Value.ToShortDateString, idProveedor, lote, clasificacionEtiqPlanta, impresora, grupo)
                            Else
                                tablaDatos = objN.ConsultaEtiquetasPlantaSuela(naveid, dtpFecha.Value.ToShortDateString, idProveedor, lote, clasificacionEtiqPlanta, impresora, grupo)
                            End If
                        Else
                            If chkRangoFechas.Checked Then
                                tablaDatos = objN.ConsultaEtiquetasPlantaSuela_NavesFechas(navesId, dtpFecha.Value.ToShortDateString, dtpFechaAl.Value.ToShortDateString, idProveedor, lote, clasificacionEtiqPlanta, impresora, grupo)
                            Else
                                tablaDatos = objN.ConsultaEtiquetasPlantaSuela_Naves(navesId, dtpFecha.Value.ToShortDateString, idProveedor, lote, clasificacionEtiqPlanta, impresora, grupo)
                                objNeg.BitacoraEtiquetasProveedores(navesId, dtpFecha.Value.ToShortDateString, idProveedor, lote, clasificacionEtiqPlanta, impresora, grupo, usuario)
                            End If
                        End If
                    Else
                        cboGrupo.Text = ""
                    End If
                End If

                If rbtEtiquetasSuela.Checked = True Then
                    'tablaDatos = objN.ConsultaEtiquetasPlantaSuela(naveid, dtpFecha.Value.ToShortDateString, idProveedor, lote, ClasificacionEtiqSuela, impresora)

                    If navesId = String.Empty Then
                        If chkRangoFechas.Checked Then
                            tablaDatos = objN.ConsultaEtiquetasPlantaSuelaFechas(naveid, dtpFecha.Value.ToShortDateString, dtpFechaAl.Value.ToShortDateString, idProveedor, lote, ClasificacionEtiqSuela, impresora, grupo)
                        Else
                            tablaDatos = objN.ConsultaEtiquetasPlantaSuela(naveid, dtpFecha.Value.ToShortDateString, idProveedor, lote, ClasificacionEtiqSuela, impresora, grupo)
                        End If
                    Else
                        If chkRangoFechas.Checked Then
                            tablaDatos = objN.ConsultaEtiquetasPlantaSuela_NavesFechas(navesId, dtpFecha.Value.ToShortDateString, dtpFechaAl.Value.ToShortDateString, idProveedor, lote, ClasificacionEtiqSuela, impresora, grupo)
                        Else
                            tablaDatos = objN.ConsultaEtiquetasPlantaSuela_Naves(navesId, dtpFecha.Value.ToShortDateString, idProveedor, lote, ClasificacionEtiqSuela, impresora, grupo)
                            objNeg.BitacoraEtiquetasProveedores(navesId, dtpFecha.Value.ToShortDateString, idProveedor, lote, ClasificacionEtiqSuela, impresora, grupo, usuario)
                        End If
                    End If


                End If

                If rbtEtiquetasPlantilla.Checked = True Then
                    'tablaDatos = objN.ConsultaEtiquetasPlantilla(naveid, dtpFecha.Value.ToShortDateString, idProveedor, lote, impresora)
                    If cboGrupo.Text = "FVO" Or cboGrupo.Text = "RVO" Or cboGrupo.Text = "" Then
                        If navesId = String.Empty Then
                            If chkRangoFechas.Checked Then
                                tablaDatos = objN.ConsultaEtiquetasPlantillaFechas(naveid, dtpFecha.Value.ToShortDateString, dtpFechaAl.Value.ToShortDateString, idProveedor, lote, impresora, grupo)
                            Else
                                tablaDatos = objN.ConsultaEtiquetasPlantilla(naveid, dtpFecha.Value.ToShortDateString, idProveedor, lote, impresora, grupo)
                            End If
                        Else
                            If chkRangoFechas.Checked Then
                                tablaDatos = objN.ConsultaEtiquetasPlantilla_NavesFechas(navesId, dtpFecha.Value.ToShortDateString, dtpFechaAl.Value.ToShortDateString, idProveedor, lote, impresora, grupo)
                            Else
                                tablaDatos = objN.ConsultaEtiquetasPlantilla_Naves(navesId, dtpFecha.Value.ToShortDateString, idProveedor, lote, impresora, grupo)
                            End If

                        End If
                    Else
                        cboGrupo.Text = ""
                    End If


                End If

                    If tablaDatos.Rows.Count > 0 Then
                    For Each row As DataRow In tablaDatos.Rows
                        archivo.WriteLine(row.Item("ZPL").ToString.Trim)
                    Next
                    Dim grfs As List(Of String) = tablaDatos.AsEnumerable() _
                                                       .Select(Function(r) r.Field(Of String)("foto")) _
                                                       .Distinct() _
                                                       .ToList()
                    GenerarArchivoEtiquetasBat(grfs)
                    Shell("C:\SAY\Etiquetas.bat")
                    show_message("Exito", "Se han impreso correctamente")
                Else
                    show_message("Aviso", "No se encontro información para mostrar.")
                End If

                txtLote.Text = ""
                archivo.close()
                tablaDatos.Clear()

            Else
                Me.Cursor = Cursors.Default
                Exit Sub
            End If

        Catch ex As Exception
            show_message("Error", ex.Message)
            archivo.close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Public Sub validar()
        If cboNave.SelectedValue > 0 Or cboGrupo.SelectedItem("grupo").ToString() <> "" Then
            If rbtEtiquetasConsumos.Checked Or rbtEtiquetasPlanta.Checked Or rbtEtiquetasSuela.Checked Or rbtEtiquetasPlantilla.Checked Then
                If cboImpresora.SelectedValue > 0 Then
                    validacion = True
                Else
                    show_message("Advertencia", "Seleccione una impresora.")
                    validacion = False
                End If
            Else
                show_message("Advertencia", "Seleccione la opción en tipo de impresión")
                validacion = False
            End If
        Else
            'show_message("Advertencia", "Seleccione una nave.")
            show_message("Advertencia", "Seleccione una opción en la configuración.")
            validacion = False
        End If
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Public Sub GenerarArchivoEtiquetasBat(ByVal Lista As List(Of String))
        Dim ArchivoBat As String = "C:\SAY\Etiquetas.bat"
        Dim grf As String = String.Empty
        Dim fsBat As Stream = File.Create(ArchivoBat)
        Dim swBat As New System.IO.StreamWriter(fsBat)
        Try
            If cboImpresora.SelectedValue = 2 Then
                swBat.WriteLine("net use LPT1: \\PROGRAMACION2\PROGRAMACION3 /persistent:yes ")
            End If

            For Each item As String In Lista
                If item IsNot Nothing Then
                    grf = String.Empty
                    grf = item.ToString.Trim
                    swBat.WriteLine(grf)
                End If
            Next
            swBat.WriteLine("COPY C:\SAY\ETIQUETAS.TXT C:\PRN")

        Catch ex As Exception
            Throw ex
        Finally
            swBat.Close()
        End Try
    End Sub

    Private Sub Panel1_MouseClick(sender As Object, e As MouseEventArgs) Handles Panel1.MouseClick

        clik = clik + 1

        If clik = 5 Then ' And contimer <= 5
            If pb.Visible = True Then
                pb.Visible = False
                clik = 0
            Else
                pb.Visible = True
                pb.Width = 49
                pb.Height = 59
                clik = 0
            End If
        End If
    End Sub

    'Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
    '    contimer += 1

    '    If contimer >= 5 Then
    '        clik = 0
    '        contimer = 0
    '    End If

    'End Sub

    Public Sub cargarGrupo()
        Dim obj = New Programacion.Negocios.EtiquetasBU
        Dim tablaGrupos As New DataTable

        tablaGrupos = obj.cargarGrupoXNave()
        tablaGrupos.Rows.InsertAt(tablaGrupos.NewRow, 0)
        cboGrupo.DataSource = tablaGrupos
        cboGrupo.DisplayMember = "grupo"
        cboGrupo.ValueMember = "grupo"
    End Sub

    Private Sub rbtPorNave_CheckedChanged(sender As Object, e As EventArgs) Handles rbtPorNave.CheckedChanged
        If rbtPorNave.Checked Then
            cboNave.Enabled = True
            cboGrupo.Enabled = False
            cboGrupo.Text = ""
            cboGrupo.SelectedText = ""
            rbtEtiquetasConsumos.Checked = True
            rbtEtiquetasConsumos.Enabled = True
            txtLote.Enabled = True
            cboNave2.Enabled = False
            cboNave2.Visible = False
            'For Each item As Infragistics.Win.ValueListItem In cboNave2.Items
            '    item.CheckState = CheckState.Unchecked
            'Next
            cboNave2.DataSource = Nothing
        Else
            cboNave.Enabled = False
            cboNave.Text = ""
            cboNave.SelectedText = ""
            cboGrupo.Enabled = True
            cboNave2.Enabled = True
            cboNave2.Visible = True
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub rbtPorGrupo_CheckedChanged(sender As Object, e As EventArgs) Handles rbtPorGrupo.CheckedChanged
        If rbtPorGrupo.Checked Then
            cboNave.Enabled = False
            cboGrupo.Enabled = True
            rbtEtiquetasConsumos.Enabled = False
            rbtEtiquetasConsumos.Checked = False
            txtLote.Enabled = False
            cboNave2.Enabled = True
            cboNave2.Visible = True
        Else
            cboNave.Enabled = True
            cboGrupo.Enabled = False
            cboNave2.Enabled = False
            cboNave2.Visible = False
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub cboGrupo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboGrupo.SelectedIndexChanged
        Dim objBU As New Programacion.Negocios.EtiquetasBU
        rbtEtiquetasConsumos.Checked = False
        rbtEtiquetasPlanta.Checked = False
        rbtEtiquetasSuela.Checked = False
        rbtEtiquetasPlantilla.Checked = False
        If cboGrupo.Text = "FVO" Then
            CargarNavesCheck("FVO")
        ElseIf cboGrupo.Text = "RVO" Then
            CargarNavesCheck("RVO")
        ElseIf cboGrupo.Text = "TODAS" Then
            CargarNavesCheck("TODAS")
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub dtpFecha_ValueChanged(sender As Object, e As EventArgs) Handles dtpFecha.ValueChanged
        rbtPorNave.Checked = True
        rbtEtiquetasConsumos.Checked = True
        Cursor = Cursors.Default
        dtpFechaAl.MinDate = dtpFecha.Value
    End Sub

    Private Sub CargarNavesCheck(ByVal grupo As String)
        Dim objBu As New Programacion.Negocios.EtiquetasBU
        Dim naves As New DataTable

        naves = objBu.ConsultaNavesXGrupo(grupo)
        cboNave2.DataSource = naves
        cboNave2.ValueMember = "IdNave"
        cboNave2.DisplayMember = "Nave"

        If rbtPorNave.Checked Then
            For Each item As Infragistics.Win.ValueListItem In cboNave2.Items
                item.CheckState = CheckState.Unchecked
            Next
        ElseIf rbtPorGrupo.Checked Then
            For Each item As Infragistics.Win.ValueListItem In cboNave2.Items
                'If item.DataValue = 60 Or item.DataValue = 5 Then ' RECALZA Y ZONAX '
                '    item.CheckState = CheckState.Unchecked
                'Else
                item.CheckState = CheckState.Checked
                'End If
            Next
        End If

    End Sub

    Private Sub chkRangoFechas_CheckedChanged(sender As Object, e As EventArgs) Handles chkRangoFechas.CheckedChanged
        If chkRangoFechas.Checked Then
            lblFecha1.Text = "Fecha del:"
            dtpFechaAl.Enabled = True
            lblFecha2.Enabled = True
        Else
            lblFecha1.Text = "F.Programa:"
            dtpFechaAl.Enabled = False
            lblFecha2.Enabled = False
        End If
    End Sub

    Private Sub dtpFechaAl_ValueChanged(sender As Object, e As EventArgs) Handles dtpFechaAl.ValueChanged
        dtpFechaAl.MinDate = dtpFecha.Value
    End Sub

    Private Sub btnReporte_Click(sender As Object, e As EventArgs) Handles btnReporte.Click
        Dim form As New ReporteControlEtiquetasProveedoresForm
        Dim objN As New Programacion.Negocios.EtiquetasBU


        If chkRangoFechas.Checked Then
            If rbtEtiquetasSuela.Checked Then
                If cboProveedor.SelectedValue = Nothing Then
                    show_message("Advertencia", "Seleccione el proveedor")
                Else
                    form.fechaDel = dtpFecha.Value
                    form.fechaAl = dtpFechaAl.Value
                    form.idproveedor = cboProveedor.SelectedValue
                    form.nombreProveedor = cboProveedor.Text
                    form.Show()
                    'tbl = objN.ReporteControlEtiquetasProveedoresSuelas(dtpFecha.Value, dtpFechaAl.Value, cboProveedor.SelectedValue)
                End If
            Else
                show_message("Advertencia", "Seleccione el tipo de impresion 'Etiquetas Pedido de Suela'")
            End If
        Else
            show_message("Advertencia", "Seleccione el rango de fecha")
        End If



    End Sub

End Class