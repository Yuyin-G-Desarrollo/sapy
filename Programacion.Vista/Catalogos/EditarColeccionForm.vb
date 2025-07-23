Imports Infragistics.Win.UltraWinGrid
Imports Tools

Public Class EditarColeccionForm
    Dim dtMarcasSeleccionadas As DataTable
    Dim dtDatosColeccion As DataTable
    Dim IdColeccion As Int32
    Dim anioRegistro As Int32 = 0
    Dim tempRegistro As Int32 = 0

    Public actividadFormulario As String

    Public Sub llenarComboAnios()
        Dim tempBu As New Negocios.TemporadasBU
        Dim dtDatosTemporadas As New DataTable
        dtDatosTemporadas = tempBu.verTemporadasRegistradas()
        dtDatosTemporadas.Rows.InsertAt(dtDatosTemporadas.NewRow(), 0)
        cmbTemporadas.DataSource = dtDatosTemporadas
        cmbTemporadas.ValueMember = "temp_temporadaid"
        cmbTemporadas.DisplayMember = "temp_nombre"
    End Sub

    Public Sub llenarlistaMarcas()
        Dim MarcaBU As New Programacion.Negocios.MarcasBU
        Dim objCole As New Programacion.Negocios.ColeccionBU
        Dim idTemporada As Int32 = cmbTemporadas.SelectedValue
        Dim anio As Int32 = 0
        Dim objTempBu As New Negocios.TemporadasBU
        Dim dtAnioCombo As DataTable = objTempBu.consultaAnioTemporada(cmbTemporadas.SelectedValue.ToString)
        anio = CInt(dtAnioCombo.Rows(0).Item(0).ToString)

        For Each rowDt As DataGridViewRow In grdListaMarcasSeleccion.Rows
            Dim dtDatosColeProd As New DataTable
            dtDatosColeProd = objCole.verColeccionesAnio(anio, CInt(rowDt.Cells("marc_marcaid").Value.ToString))

            For contCods As Int32 = 1 To 99
                Dim codColeccion As String = ""
                Dim existe As Boolean = False
                If contCods <= 9 Then
                    codColeccion = "0" + contCods.ToString
                Else
                    codColeccion = contCods.ToString
                End If

                For Each rowDC As DataRow In dtDatosColeProd.Rows
                    If codColeccion = rowDC.Item("coma_codigo").ToString Then
                        existe = True
                    End If
                Next
                If existe = False And rowDt.Cells("coma_codigo").Value.ToString = "" Then
                    rowDt.Cells("coma_codigo").Value = codColeccion
                    Exit For
                End If
            Next
        Next

        For Each rowGrd As DataGridViewRow In grdListaMarcasSeleccion.Rows
            If rowGrd.Cells("coma_codigo").Value.ToString = "" Then
                rowGrd.Cells("coma_codigo").Value = "Sin Código Asignado"
                rowGrd.ReadOnly = True
            End If
        Next
    End Sub

    Public Sub llenarlistaMarcasDiferenteAnio(ByVal anio As Int32)
        Dim MarcaBU As New Programacion.Negocios.MarcasBU
        Dim objCole As New Programacion.Negocios.ColeccionBU


        For Each rowDt As DataGridViewRow In grdListaMarcasSeleccion.Rows
            Dim dtDatosColeProd As New DataTable
            dtDatosColeProd = objCole.verColeccionesAnio(anio, CInt(rowDt.Cells("marc_marcaid").Value.ToString))
            rowDt.Cells("coma_codigo").Value = ""
            For contCods As Int32 = 1 To 99
                Dim codColeccion As String = ""
                Dim existe As Boolean = False
                If contCods <= 9 Then
                    codColeccion = "0" + contCods.ToString
                Else
                    codColeccion = contCods.ToString
                End If

                For Each rowDC As DataRow In dtDatosColeProd.Rows
                    If codColeccion = rowDC.Item("coma_codigo").ToString Then
                        existe = True
                    End If
                Next
                If existe = False Then
                    rowDt.Cells("coma_codigo").Value = codColeccion
                    Exit For
                End If
            Next
        Next
        For Each rowGrd As DataGridViewRow In grdListaMarcasSeleccion.Rows
            If rowGrd.Cells("coma_codigo").Value.ToString = "" Then
                rowGrd.Cells("coma_codigo").Value = "Sin Código Asignado"
                rowGrd.ReadOnly = True
            End If
        Next
    End Sub

    Public Sub RecibirIdColeccion(ByVal IdCole As Int32)
        IdColeccion = IdCole
    End Sub

    Public Sub LlenarTablaMarcasSeleccionadas(ByVal IdColeccion As Int32)
        Dim objColeBU As New Programacion.Negocios.ColeccionBU
        Dim dtMarcasYuyin As New DataTable
        Dim objMBU As New Negocios.MarcasBU
        Dim objFamProy As New Negocios.FamiliaProyeccionBU


        dtDatosColeccion = New DataTable
        dtDatosColeccion = objColeBU.VerColeccion(IdColeccion)
        Dim Nombre As String = dtDatosColeccion(0)("cole_descripcion").ToString
        Dim activo As Boolean = dtDatosColeccion(0)("cole_activo")
        Dim anio As Int32 = dtDatosColeccion(0)("cole_Anio").ToString
        Dim temporadaId As Int32 = dtDatosColeccion(0)("cole_temporadaid").ToString
        Dim EtiquetaLengua As Boolean = dtDatosColeccion(0)("cole_etiquetalengua").ToString

        If (activo = True) Then
            rdoActivo.Checked = True
        ElseIf (activo = False) Then
            rdoInactivo.Checked = True
        End If

        If EtiquetaLengua = True Then
            RdbEtiquetaLenguaSI.Checked = True
        Else
            rdbEtiquetaLenguaNO.Checked = True
        End If
        txtNombre.Text = Nombre
        cmbTemporadas.SelectedValue = temporadaId
        dtMarcasSeleccionadas = New DataTable
        dtMarcasSeleccionadas = objColeBU.consultaMarcaRelacionColeccion(IdColeccion, temporadaId)
        anioRegistro = anio
        tempRegistro = temporadaId

        Dim tamanoConsulta As Int32 = dtMarcasSeleccionadas.Rows.Count

        grdListaMarcasSeleccion.DataSource = dtMarcasSeleccionadas

        dtMarcasYuyin = objMBU.verMarcasYuyin
        dtMarcasYuyin.Rows.InsertAt(dtMarcasYuyin.NewRow, 0)

        Dim cmbMarcas As New DataGridViewComboBoxColumn()
        cmbMarcas.Name = "MarcaYUYIN"
        cmbMarcas.DataSource = dtMarcasYuyin
        cmbMarcas.DisplayMember = "marc_descripcion"
        cmbMarcas.ValueMember = "marc_marcaid"
        cmbMarcas.DisplayIndex = 10
        grdListaMarcasSeleccion.Columns.Add(cmbMarcas)

        Dim dtFamiliasProyeccion As New DataTable
        dtFamiliasProyeccion = objFamProy.consultaFamiliasProyeccion(True)
        dtFamiliasProyeccion.Rows.InsertAt(dtFamiliasProyeccion.NewRow, 0)

        Dim cmbFamiliaProyeccion As New DataGridViewComboBoxColumn()
        cmbFamiliaProyeccion.Name = "FamiliaProyeccion"
        cmbFamiliaProyeccion.DataSource = dtFamiliasProyeccion
        cmbFamiliaProyeccion.DisplayMember = "fapr_descripcion"
        cmbFamiliaProyeccion.ValueMember = "fapr_familiaproyeccionid"
        cmbFamiliaProyeccion.DisplayIndex = 5
        grdListaMarcasSeleccion.Columns.Add(cmbFamiliaProyeccion)

        Dim dtNaveDes As New DataTable
        dtNaveDes = objFamProy.getNavesDesarrolla()
        dtNaveDes.Rows.InsertAt(dtNaveDes.NewRow, 0)
        Dim cmbNave As New DataGridViewComboBoxColumn()
        cmbNave.Name = "NaveDesarrolla"
        cmbNave.DataSource = dtNaveDes
        cmbNave.DisplayMember = "nave_nombre"
        cmbNave.ValueMember = "nave_naveid"
        cmbNave.DisplayIndex = 6
        grdListaMarcasSeleccion.Columns.Add(cmbNave)


        Dim dtclasificacion As New DataTable
        dtclasificacion = objFamProy.getClasificacion()
        dtclasificacion.Rows.InsertAt(dtclasificacion.NewRow, 0)
        Dim cmbClasificacion As New DataGridViewComboBoxColumn()
        cmbClasificacion.Name = "Clasificación"
        cmbClasificacion.DataSource = dtclasificacion
        cmbClasificacion.DisplayMember = "cocl_clasificacion"
        cmbClasificacion.ValueMember = "cocl_clasificacion"
        cmbClasificacion.DisplayIndex = 7
        grdListaMarcasSeleccion.Columns.Add(cmbClasificacion)



        For Each rowGrd As DataGridViewRow In grdListaMarcasSeleccion.Rows
            If CBool(rowGrd.Cells("marc_escliente").Value) = False Then
                rowGrd.Cells("MarcaYUYIN").ReadOnly = True
                rowGrd.Cells("ColeccionYUYIN").ReadOnly = True
                rowGrd.Cells("MarcaYUYIN").Style.BackColor = SystemColors.ScrollBar
                rowGrd.Cells("ColeccionYUYIN").Style.BackColor = SystemColors.ScrollBar
            Else
                If Not rowGrd.Cells("coma_marcaidyuyin").Value Is Nothing Then
                    Dim ghjd As String = rowGrd.Cells("coma_marcaidyuyin").Value.ToString
                    If rowGrd.Cells("coma_marcaidyuyin").Value.ToString <> "" And rowGrd.Cells("coma_marcaidyuyin").Value.ToString <> "0" Then
                        grdListaMarcasSeleccion.Rows(rowGrd.Index).Cells("MarcaYUYIN").Value = rowGrd.Cells("coma_marcaidyuyin").Value
                    End If
                End If
            End If

            If Not rowGrd.Cells("fapr_familiaproyeccionid").Value Is Nothing Then
                Dim famProyIdGrid As String = rowGrd.Cells("fapr_familiaproyeccionid").Value.ToString
                If rowGrd.Cells("fapr_familiaproyeccionid").Value.ToString <> "" And rowGrd.Cells("fapr_descripcion").Value.ToString <> "0" Then
                    grdListaMarcasSeleccion.Rows(rowGrd.Index).Cells("FamiliaProyeccion").Value = rowGrd.Cells("fapr_familiaproyeccionid").Value
                End If
            End If

            If Not rowGrd.Cells("Nave Desarrolla").Value Is Nothing Then
                Dim famProyIdGrid As String = rowGrd.Cells("Nave Desarrolla").Value.ToString
                If rowGrd.Cells("Nave Desarrolla").Value.ToString <> "" Then
                    grdListaMarcasSeleccion.Rows(rowGrd.Index).Cells("NaveDesarrolla").Value = rowGrd.Cells("Nave Desarrolla").Value
                End If
            End If

            If Not rowGrd.Cells("coma_clasificacion").Value Is Nothing Then
                Dim clasificacionId As String = rowGrd.Cells("coma_clasificacion").Value.ToString
                If rowGrd.Cells("coma_clasificacion").Value.ToString <> String.Empty Then
                    grdListaMarcasSeleccion.Rows(rowGrd.Index).Cells("Clasificación").Value = rowGrd.Cells("coma_clasificacion").Value
                End If
            End If

        Next

        'grdListaMarcasSeleccion.ClearSelection()
        'grdListaMarcasSeleccion.MultiSelect = True

        For recorrer As Int32 = 0 To tamanoConsulta - 1
            If (dtMarcasSeleccionadas.Rows(recorrer)("coma_activo").ToString = "True") Then
                grdListaMarcasSeleccion.Rows(recorrer).Cells(0).Value = True
            End If
            If (dtMarcasSeleccionadas.Rows(recorrer)("coma_activo").ToString() = "False") Then
                grdListaMarcasSeleccion.Rows(recorrer).Cells(0).Value = False
            End If
        Next
        formatoGrid()


    End Sub

    Public Sub formatoGrid()
        'grdListaMarcasSeleccion.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        grdListaMarcasSeleccion.AllowUserToAddRows = False
        grdListaMarcasSeleccion.Columns("marc_marcaid").Visible = False
        grdListaMarcasSeleccion.Columns("coma_coleccionmarcaid").Visible = False
        grdListaMarcasSeleccion.Columns("Nave Desarrolla").Visible = False
        grdListaMarcasSeleccion.Columns("marc_escliente").Visible = False
        grdListaMarcasSeleccion.Columns("coma_marcaidyuyin").Visible = False
        grdListaMarcasSeleccion.Columns("fapr_familiaproyeccionid").Visible = False
        grdListaMarcasSeleccion.Columns("fapr_descripcion").Visible = False
        grdListaMarcasSeleccion.Columns("marc_codigosicy").Visible = False
        grdListaMarcasSeleccion.Columns("familiaAntes").Visible = False
        grdListaMarcasSeleccion.Columns("coma_codigo").HeaderText = "Código"
        grdListaMarcasSeleccion.Columns("marc_descripcion").HeaderText = "Marca"
        grdListaMarcasSeleccion.Columns("clie_nombregenerico").HeaderText = "Cliente"
        grdListaMarcasSeleccion.Columns("NaveDesarrolla").HeaderText = "Nave Desarrolla"
        grdListaMarcasSeleccion.Columns("ColeccionYUYIN").HeaderText = "Colección Yuyin"
        grdListaMarcasSeleccion.Columns("MarcaYUYIN").HeaderText = "Marca Yuyin"
        grdListaMarcasSeleccion.Columns("coma_codigo").ReadOnly = True
        grdListaMarcasSeleccion.Columns("marc_descripcion").ReadOnly = True
        grdListaMarcasSeleccion.Columns("clie_nombregenerico").ReadOnly = True
        grdListaMarcasSeleccion.Columns("coma_codigosicy").Visible = False
        grdListaMarcasSeleccion.Columns("coma_activo").Visible = False
        grdListaMarcasSeleccion.Columns("EXISTE").Visible = False
        grdListaMarcasSeleccion.Columns("clie_clienteid").Visible = False
        grdListaMarcasSeleccion.Columns("coma_clasificacion").Visible = False
        grdListaMarcasSeleccion.Columns("MarcaYUYIN").Width = 45
        grdListaMarcasSeleccion.Columns("ColeccionYUYIN").Width = 45
        grdListaMarcasSeleccion.Columns("ColeccionYUYIN").DisplayIndex = 12

        grdListaMarcasSeleccion.Columns("coma_etiquetalengualinea").Width = 25
        grdListaMarcasSeleccion.Columns("coma_etiquetalengualinea").HeaderText = "Lengua Linea"

        grdListaMarcasSeleccion.Columns("coma_codigo").Width = 50
        grdListaMarcasSeleccion.Columns("Seleccion").Width = 50
        grdListaMarcasSeleccion.Columns("clie_nombregenerico").Width = 200
        grdListaMarcasSeleccion.Columns("ColeccionYUYIN").Width = 250
        grdListaMarcasSeleccion.Columns("MarcaYUYIN").Width = 100
        grdListaMarcasSeleccion.Columns("FamiliaProyeccion").Width = 200
        grdListaMarcasSeleccion.Columns("FamiliaProyeccion").HeaderText = "Famila Ventas"
        grdListaMarcasSeleccion.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        txtSicy.Text = grdListaMarcasSeleccion.Rows(0).Cells("coma_codigosicy").Value.ToString
    End Sub

    'Public Function ValidarExistencia(ByVal idMarca As Int32, ByVal coleccion As Int32, ByVal activo As Boolean) As Boolean
    '    Dim ColeccionNegocios As New Programacion.Negocios.ColeccionBU
    '    Dim dtMaxMarcCole As DataTable
    '    Dim dtMaxMarcDisponible As DataTable
    '    Dim dtColeccionesTrue As DataTable

    '    dtMaxMarcCole = New DataTable
    '    dtMaxMarcDisponible = New DataTable
    '    dtColeccionesTrue = New DataTable
    '    dtColeccionesTrue = ColeccionNegocios.ValidarCodigosMarcas(idMarca, coleccion)
    '    dtMaxMarcCole = ColeccionNegocios.verMaximaMarcaColecion(idMarca)

    '    If Not dtMaxMarcCole.Rows(0)("codigo").ToString() = Nothing Then
    '        If (Convert.ToInt32(dtMaxMarcCole.Rows(0)("codigo").ToString()) > 0 And Convert.ToInt32(dtMaxMarcCole.Rows(0)("codigo").ToString()) <= 99) Then
    '            Return True
    '        ElseIf (dtMaxMarcCole.Rows(0)("codigo").ToString() >= 1 And dtMaxMarcCole.Rows(0)("codigo").ToString() >= 99) Then
    '            dtMaxMarcDisponible = ColeccionNegocios.VerCodigosMarcaDisponibles(idMarca)

    '            If (dtMaxMarcDisponible.Rows.Count = 0) Then

    '                If (dtColeccionesTrue.Rows.Count = 0) Then
    '                    Return False
    '                ElseIf (activo = dtColeccionesTrue.Rows(0)("coma_activo").ToString) Then
    '                    Return True
    '                End If

    '                Return False
    '            End If
    '        End If
    '    End If
    '    Return True
    'End Function

    Public Sub EditarColeccion()

        Dim objColeBU As New Programacion.Negocios.ColeccionBU
        Dim descripcion As String = txtNombre.Text
        Dim activoCole As Boolean = True
        Dim idTemporada As Int32 = cmbTemporadas.SelectedValue
        Dim anio As Int32 = 0
        Dim objTempBu As New Negocios.TemporadasBU
        Dim dtAnioCombo As DataTable = objTempBu.consultaAnioTemporada(cmbTemporadas.SelectedValue.ToString)
        anio = CInt(dtAnioCombo.Rows(0).Item(0).ToString)
        Dim codSicy As String = txtSicy.Text
        Dim recorre As Int32 = 0
        Dim etiquetaLengua As Boolean
        Dim EtiquetaEspecial As Boolean
        If (rdoActivo.Checked = True) Then
            activoCole = True
        ElseIf (rdoInactivo.Checked = True) Then
            activoCole = False
        End If

        If RdbEtiquetaLenguaSI.Checked = True Then
            etiquetaLengua = True
        Else
            etiquetaLengua = False
        End If


        If rdbEtiquetaEspecialSI.Checked = True Then
            EtiquetaEspecial = True
            Dim lotesProceso As New LotesenProcesoform
            lotesProceso.RecibirIdColeccion(IdColeccion)
            lotesProceso.ShowDialog()

        Else
            EtiquetaEspecial = False
        End If
        Try
            objColeBU.InsertarColeccionEtiquetaEspecial(13, IdColeccion, EtiquetaEspecial)

            objColeBU.EditarColeccion(IdColeccion, descripcion, activoCole, anio, idTemporada, etiquetaLengua)
        Catch ex As Exception
            Dim msg_error As New Tools.ErroresForm
            msg_error.mensaje = ex.Message
            msg_error.ShowDialog()
        End Try

        Dim idCliente As String = ""
        For Each fila As DataGridViewRow In grdListaMarcasSeleccion.Rows
            If CBool(fila.Cells("seleccion").Value()) = True Or CInt(fila.Cells("EXISTE").Value()) = 1 Then
                Dim etiqLengua As Boolean
                If IsDBNull(fila.Cells("coma_etiquetalengualinea").Value()) = False Then
                    etiqLengua = 1
                Else
                    etiqLengua = 0
                End If
                Try
                    idCliente = fila.Cells("clie_clienteid").Value().ToString
                Catch ex As Exception
                    idCliente = ""
                End Try

                If idCliente = "" Then
                    idCliente = "0"
                End If
                Try
                    Dim idMarcYuyin As String = "0"
                    If Not fila.Cells("MarcaYUYIN").Value Is Nothing Then
                        idMarcYuyin = fila.Cells("MarcaYUYIN").Value.ToString
                    End If

                    Dim idFamiliaProyeccion As String = "0"
                    If Not fila.Cells("FamiliaProyeccion").Value Is Nothing Then
                        idFamiliaProyeccion = fila.Cells("FamiliaProyeccion").Value.ToString
                    End If


                    'objColeBU.EditarColeccionDetalle(IdColeccion,
                    '                             fila.Cells("marc_marcaid").Value().ToString,
                    '                             fila.Cells("seleccion").Value().ToString,
                    '                             fila.Cells("coma_codigo").Value().ToString,
                    '                             codSicy,
                    '                             fila.Cells("EXISTE").Value().ToString,
                    '                            idCliente,
                    '                            idMarcYuyin,
                    '                              fila.Cells("ColeccionYUYIN").Value().ToString,
                    '                            idFamiliaProyeccion)
                    If fila.Cells("marc_marcaid").Value().ToString = "6" Or fila.Cells("marc_marcaid").Value().ToString = "7" Or fila.Cells("marc_marcaid").Value().ToString = "8" Then
                        If idMarcYuyin = "0" Or idMarcYuyin = "" Then
                            Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "Seleccione una marca Yuyin.")
                        Else
                            objColeBU.EditarColeccionDetalle2(IdColeccion,
                                                 fila.Cells("marc_marcaid").Value().ToString,
                                                 fila.Cells("seleccion").Value().ToString,
                                                 fila.Cells("coma_codigo").Value().ToString,
                                                 codSicy,
                                                 fila.Cells("EXISTE").Value().ToString,
                                                 idCliente,
                                                 idMarcYuyin,
                                                 fila.Cells("ColeccionYUYIN").Value().ToString,
                                                 idFamiliaProyeccion,
                                                 etiqLengua)
                        End If
                    Else
                        objColeBU.EditarColeccionDetalle2(IdColeccion,
                                                 fila.Cells("marc_marcaid").Value().ToString,
                                                 fila.Cells("seleccion").Value().ToString,
                                                 fila.Cells("coma_codigo").Value().ToString,
                                                 codSicy,
                                                 fila.Cells("EXISTE").Value().ToString,
                                                 idCliente,
                                                 idMarcYuyin,
                                                 fila.Cells("ColeccionYUYIN").Value().ToString,
                                                 idFamiliaProyeccion,
                                                 etiqLengua)
                    End If
                    'IIf(IsDBNull(fila.Cells("coma_etiquetalengualinea").Value), 0, CBool(fila.Cells("coma_etiquetalengualinea").Value)))


                    'If fila.Cells("FamiliaProyeccion").Value.ToString <> fila.Cells("familiaAntes").Value.ToString Then
                    Dim idNaveDesarrolla As Integer = 0

                    If Not fila.Cells("NaveDesarrolla").Value Is Nothing Then
                        idNaveDesarrolla = fila.Cells("NaveDesarrolla").Value.ToString
                    End If

                    Dim clasificacion As String = String.Empty
                    If Not fila.Cells("Clasificación").Value Is Nothing Then
                        clasificacion = fila.Cells("Clasificación").Value.ToString
                    End If

                    objColeBU.editarMarcaColeccionMismaFamilia(fila.Cells("marc_marcaid").Value().ToString, codSicy, fila.Cells("FamiliaProyeccion").Value.ToString, idNaveDesarrolla, clasificacion)
                    'Este código ya no se usa no lo descomenten hasta que el usuario se queje 
                    'End If
                    'If fila.Cells("marc_codigosicy").Value.ToString <> "0" Then
                    '    Dim idMarcaSIcy As String = fila.Cells("marc_codigosicy").Value.ToString
                    '    If codSicy <> "" Then
                    '        objColeBU = New Negocios.ColeccionBU
                    '        objColeBU.inactivarColeccionesClienteSicyCambioFamilia(idMarcaSIcy, codSicy)
                    '        If fila.Cells("FamiliaProyeccion").Value.ToString <> "0" Then
                    '            Try
                    '                objColeBU.ejecutarRegistroCambioFamiliasAgenteColeccionSICY(fila.Cells("marc_marcaid").Value().ToString, fila.Cells("FamiliaProyeccion").Value.ToString)
                    '            Catch ex As Exception

                    '            End Try
                    '        End If
                    '    End If
                    'End If
                Catch ex As Exception

                End Try

                'End If
            End If
        Next

        If anio <> anioRegistro Then
            Dim dtProductosAfectados As New DataTable
            dtProductosAfectados = objColeBU.productosEditarCodigo(IdColeccion)
            Dim codNuevo As String = ""
            Dim digitoAnio As String = CStr(anio).Substring(3, 1)
            For Each rowdT As DataRow In dtProductosAfectados.Rows
                codNuevo = ""
                For Each rowgrd As DataGridViewRow In grdListaMarcasSeleccion.Rows
                    If rowdT.Item("prod_marcaid").ToString = rowgrd.Cells("marc_marcaid").Value.ToString Then
                        codNuevo = digitoAnio + rowgrd.Cells("coma_codigo").Value().ToString
                    End If
                Next
                objColeBU.editarProductosAfectadosCambioAnio(CInt(rowdT.Item("prod_productoid").ToString), codNuevo, idTemporada)
            Next
        End If
        Dim mensaje As New ExitoForm
        mensaje.mensaje = "El registro se realizó con éxito."
        mensaje.ShowDialog()
        Me.Dispose()

    End Sub

    Public Function ValidarVacio() As Boolean
        If (txtNombre.Text.Trim = Nothing) Then
            If (txtNombre.Text.Trim = Nothing) Then
                lblNombre.ForeColor = Drawing.Color.Red
            Else
                lblNombre.ForeColor = Drawing.Color.Black
            End If
            Return False
        Else
            lblNombre.ForeColor = Drawing.Color.Black
            Return True
        End If
        Return True
    End Function

    Public Function ValidarInactivarColeccionMarca() As Boolean
        Dim objColeN As New Negocios.ColeccionBU
        Dim dtDatosContenido As New DataTable
        Dim validabool As Boolean = True

        For Each row As DataGridViewRow In grdListaMarcasSeleccion.Rows
            If row.Cells("Seleccion").Value = False Then
                dtDatosContenido = objColeN.validarInactivacionCM(row.Cells("marc_marcaid").Value.ToString, IdColeccion)
                If dtDatosContenido.Rows.Count > 0 Then
                    If CInt(dtDatosContenido.Rows(0).Item(0).ToString) > 0 Then
                        Dim cadena As String = "Modelos: "
                        For Each rowD As DataRow In dtDatosContenido.Rows
                            cadena += vbLf + rowD.Item(1).ToString + " " + rowD.Item(2).ToString
                        Next
                        Dim adv As New AdvertenciaForm
                        adv.mensaje = "La relacióin de la marca  " + row.Cells("marc_descripcion").Value.ToString + " y la colección " + txtNombre.Text + " no se puede inactivar, debido a que existen modelos activos que incluyen esta relación. " & vbLf & " " & cadena
                        adv.ShowDialog()
                        validabool = False
                    End If
                    If validabool = False Then
                        Exit For
                    End If
                End If
            End If
        Next
        Return validabool
    End Function

    Public Function ValidarInactivarCompleta() As Boolean
        Dim objColeN As New Negocios.ColeccionBU
        Dim dtDatosContenido As New DataTable
        Dim validabool As Boolean = True

        If rdoActivo.Checked = False Then
            dtDatosContenido = objColeN.validarInactivacionCM("", IdColeccion)

            If dtDatosContenido.Rows().Count > 0 Then
                Dim cadena As String = "Modelos: "
                For Each rowD As DataRow In dtDatosContenido.Rows

                    cadena += vbLf + rowD.Item(1).ToString + " " + rowD.Item(2).ToString
                Next
                MsgBox("La colección " + txtNombre.Text + vbLf + "No se puede inactivar debido a que existen modelos activos que incluyen esta colección" + vbLf + cadena, MsgBoxStyle.Information, "")
                validabool = False
            End If

        End If
        Return validabool
    End Function

    Private Sub EditarColeccionForm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.Dispose()
    End Sub

    Public Sub validarCambioCodSicy()
        Dim objBU As New Negocios.ColeccionBU
        Dim estilos As Int32 = 0
        estilos = objBU.contarEstilosColeccion(IdColeccion)
        If estilos > 0 Then
            txtSicy.Enabled = False
            txtSicy.ReadOnly = True
        End If
    End Sub

    Public Sub accionesInicio()
        If actividadFormulario = "edicion" Then
            grpDatos.Enabled = True
            grdListaMarcasSeleccion.Enabled = True
            validarCambioCodSicy()
        ElseIf actividadFormulario = "consulta" Then
            grpDatos.Enabled = False
            grdListaMarcasSeleccion.ReadOnly = True
            btnCancelar.Visible = False
            btnGuardar.Visible = False
            lblGuardar.Visible = False
            lblCancelar.Visible = False
            rdbEtiquetaEspecialNO.Enabled = False
            rdbEtiquetaEspecialSI.Enabled = False
            rdbEtiquetaLenguaNO.Enabled = False
            RdbEtiquetaLenguaSI.Enabled = False
        End If
        lblNombre.ForeColor = Drawing.Color.Black

        llenarComboAnios()
        LlenarTablaMarcasSeleccionadas(IdColeccion)
        llenarlistaMarcas()


        If actividadFormulario = "consulta" Then
            For cont As Int32 = grdListaMarcasSeleccion.Rows.Count - 1 To 0 Step -1
                If CBool(grdListaMarcasSeleccion.Rows(cont).Cells("seleccion").Value) = False Then
                    grdListaMarcasSeleccion.Rows.Remove(grdListaMarcasSeleccion.Rows(cont))
                End If
            Next
        End If

        grdListaMarcasSeleccion.Columns("coma_codigo").Width = 40
        grdListaMarcasSeleccion.Columns("seleccion").Width = 40

        Dim dtContadorEstatus As New DataTable
        Dim objColeBU As New Negocios.ColeccionBU

        Try
            If objColeBU.ConsultarEtiquetaColeccion(IdColeccion) > 0 Then
                rdbEtiquetaEspecialSI.Checked = True

            Else
                rdbEtiquetaEspecialNO.Checked = True
            End If
        Catch ex As Exception
            Dim msg_error As New Tools.ErroresForm
            msg_error.mensaje = ex.Message
            msg_error.ShowDialog()
        End Try


        dtContadorEstatus = objColeBU.contarEstatusProductosColecciones(IdColeccion)
        If dtContadorEstatus.Rows.Count = 0 Then
            cmbTemporadas.Enabled = True
        ElseIf dtContadorEstatus.Rows.Count > 0 Then
            cmbTemporadas.Enabled = False
        End If

    End Sub

    Private Sub EditarColeccionForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        accionesInicio()


    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If ValidarInactivarCompleta() = True Then

            If ValidarInactivarColeccionMarca() = True Then
                Dim contadorSeleccionados As Int32 = 0
                Dim clasificacionSeleccionada As Int32 = 0
                For Each rowS As DataGridViewRow In grdListaMarcasSeleccion.Rows
                    If rowS.Cells("Seleccion").Value = True Then
                        contadorSeleccionados = contadorSeleccionados + 1
                        If Not rowS.Cells("Clasificación").Value Is Nothing And rowS.Cells("FamiliaProyeccion").Value <> Nothing Then
                            clasificacionSeleccionada += 1
                        End If
                    End If
                Next
                If (contadorSeleccionados >= 1) Then
                    If clasificacionSeleccionada = contadorSeleccionados Then
                        If (ValidarVacio() = True) Then
                            Dim objMensajeQ As New ConfirmarForm
                            objMensajeQ.mensaje = "¿Está seguro de guardar cambios? (Esta acción puede tardar algunos minutos debido a que actualiza registros del SICY, si decide aceptar el cambio por favor espere.)"
                            If objMensajeQ.ShowDialog = Windows.Forms.DialogResult.OK Then
                                Cursor = Cursors.WaitCursor

                                EditarColeccion()

                                Cursor = Cursors.Default
                            End If
                        End If
                    Else
                        Dim adv As New AdvertenciaForm
                        adv.mensaje = "Hace falta seleccionar una familia de ventas y/o una clasificación en algún registro seleccionado."
                        adv.ShowDialog()
                    End If
                Else
                    Dim objMsjAdv As New AdvertenciaForm
                    objMsjAdv.mensaje = "Debe seleccionar al menos una marca."
                    objMsjAdv.ShowDialog()
                End If
            Else
            End If
        End If

    End Sub

    Private Function validarConsumoColeccion(id As Integer) As Boolean
        Dim dtValidaConsumosColeccion As DataTable
        Dim objColeBU As New Programacion.Negocios.ColeccionBU
        Dim valorValido As Boolean = False
        Try
            dtValidaConsumosColeccion = objColeBU.ValidarConsumosColeccion(id)

            If dtValidaConsumosColeccion.Rows.Count > 0 Then
                If dtValidaConsumosColeccion.Rows(0).Item("valido") = 1 Then
                    valorValido = True
                Else
                    valorValido = False
                End If
            End If
        Catch ex As Exception
            Dim msgError As New Tools.ErroresForm
            msgError.mensaje = ex.Message
            msgError.ShowDialog()
            valorValido = False
        End Try


        Return valorValido
    End Function

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Dispose()
    End Sub

    Private Sub txtNombre_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNombre.KeyPress
        Dim caracter As Char = e.KeyChar
        If (txtNombre.Text.Length < 50) Then
            If (Char.IsLetterOrDigit(e.KeyChar)) Or (caracter = ChrW(Keys.Back)) Or (caracter = ChrW(Keys.Space)) Or (caracter = ("-")) Or (caracter = ("/")) Or (caracter = (".")) Then
                e.Handled = False
            Else
                e.Handled = True
            End If

            If Char.IsLower(e.KeyChar) Then
                txtNombre.SelectedText = Char.ToUpper(e.KeyChar)
                e.Handled = True
            End If
        Else
            If e.KeyChar <> vbBack Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub grdListaMarcasSeleccion_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdListaMarcasSeleccion.CellDoubleClick
        Try
            If grdListaMarcasSeleccion.Columns(e.ColumnIndex).Name = "clie_nombregenerico" Then

                If actividadFormulario = "edicion" Then
                    If CStr(grdListaMarcasSeleccion.Rows(e.RowIndex).Cells("clie_clienteid").Value.ToString) = "0" Or CStr(grdListaMarcasSeleccion.Rows(e.RowIndex).Cells("clie_clienteid").Value.ToString) = "" Then
                        Dim objClientes As New ListaConsultaClientesForm
                        objClientes.accionFormulario = "consultaCColeccion"
                        objClientes.idMarca = CInt(grdListaMarcasSeleccion.Rows(e.RowIndex).Cells("marc_marcaid").Value)
                        objClientes.ShowDialog()
                        grdListaMarcasSeleccion.Rows(e.RowIndex).Cells("clie_clienteid").Value = CStr(objClientes.pIdClienteList)
                        grdListaMarcasSeleccion.Rows(e.RowIndex).Cells("clie_nombregenerico").Value = objClientes.pNombreCliente
                    Else
                        If MsgBox("¿Deseas quitar la relación Marca-Cliente?", MsgBoxStyle.YesNo, "Atención") = MsgBoxResult.Yes Then
                            grdListaMarcasSeleccion.Rows(e.RowIndex).Cells("clie_clienteid").Value = 0
                            grdListaMarcasSeleccion.Rows(e.RowIndex).Cells("clie_nombregenerico").Value = ""
                        End If
                    End If
                End If

            End If

        Catch ex As Exception
            MsgBox("Ocurrió algo inesperado.")
        End Try

    End Sub

    Private Sub grdListaMarcasSeleccion_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles grdListaMarcasSeleccion.EditingControlShowing
        If TypeOf e.Control Is TextBox Then
            DirectCast(e.Control, TextBox).CharacterCasing = CharacterCasing.Upper
            Dim ValidaEntradaDatos As TextBox = CType(e.Control, TextBox)
            AddHandler ValidaEntradaDatos.KeyPress, AddressOf ValidarEntradaDatos_KeyPress
            e.Control.ForeColor = Color.Coral
        End If

        If TypeOf e.Control Is ComboBox Then
            Dim editingComboBox As ComboBox = e.Control
            AddHandler editingComboBox.SelectionChangeCommitted, AddressOf Me.ComboBox_SelectionChangeCommitted

        End If
    End Sub

    Private Sub ComboBox_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs)

        Dim idColeccionMarca As Integer
        Dim Fila As Int32 = 0
        Fila = grdListaMarcasSeleccion.CurrentRow.Index
        If (IsDBNull(grdListaMarcasSeleccion.Rows(Fila).Cells("coma_coleccionmarcaid").Value) = False) Then
            idColeccionMarca = grdListaMarcasSeleccion.Rows(Fila).Cells("coma_coleccionmarcaid").Value
        Else
            idColeccionMarca = 0
        End If

        Dim ComboBox As ComboBox = TryCast(sender, ComboBox)
        Dim selectedEmployee As String = ComboBox.SelectedItem.ToString

        If idColeccionMarca > 0 Then
            If Not validarConsumoColeccion(idColeccionMarca) Then
                Dim msg_Advertencia As New Tools.AdvertenciaFormGrande
                msg_Advertencia.mensaje = “No puede cambiar la nave de desarrollo, ya que tiene consumos capturados. Solicite apoyo a TI mediante un ticket en Service Desk proporcionando el ID_Coleccion_Marca=" + idColeccionMarca.ToString + ", indicando la nave de desarrollo actual y la nave a la que lo desea cambiar.”
                msg_Advertencia.ShowDialog()
                ComboBox.SelectedValue = grdListaMarcasSeleccion.Rows(Fila).Cells("NaveDesarrolla").Value
            End If
        End If




        RemoveHandler ComboBox.SelectionChangeCommitted, AddressOf Me.ComboBox_SelectionChangeCommitted
    End Sub

    Private Sub ValidarEntradaDatos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim columnIndex As Integer = grdListaMarcasSeleccion.CurrentCell.ColumnIndex()
        Dim fila As Int32 = grdListaMarcasSeleccion.CurrentCell.RowIndex
        Dim tam As Int32 = grdListaMarcasSeleccion.Rows(fila).Cells(4).Value.ToString.Length
        If columnIndex = 4 Then
            Dim caracter As Char = e.KeyChar
            Dim txt As TextBox = CType(sender, TextBox)

            If (Char.IsLetterOrDigit(e.KeyChar)) Or (caracter = ChrW(Keys.Back)) Then
                e.Handled = False
            Else
                e.Handled = True
            End If
        ElseIf columnIndex = 10 Then
            Dim caracter As Char = e.KeyChar
            Dim txt As TextBox = CType(sender, TextBox)
            If txt.Text.Length <= 50 Then
                If (Char.IsLetterOrDigit(e.KeyChar)) Or (caracter = ChrW(Keys.Back)) Or (caracter = ChrW(Keys.Space)) Then
                    e.Handled = False
                Else
                    e.Handled = True
                End If
            Else
                If caracter = ChrW(Keys.Back) Then
                    e.Handled = False
                Else
                    e.Handled = True
                End If
            End If
        End If
    End Sub

    Private Sub cmbTemporadas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTemporadas.SelectedIndexChanged
        If anioRegistro > 0 And tempRegistro > 0 Then
            If Not cmbTemporadas.SelectedIndex = 0 Then
                Dim anio As Int32 = 0
                Dim objTempBu As New Negocios.TemporadasBU
                Dim dtAnioCombo As DataTable = objTempBu.consultaAnioTemporada(cmbTemporadas.SelectedValue.ToString)
                anio = CInt(dtAnioCombo.Rows(0).Item(0).ToString)
                If anioRegistro = anio Then
                    LlenarTablaMarcasSeleccionadas(IdColeccion)
                    llenarlistaMarcas()
                Else
                    llenarlistaMarcasDiferenteAnio(anio)
                End If
            Else
                cmbTemporadas.SelectedValue = tempRegistro
            End If
        End If
    End Sub

    Private Sub grdListaMarcasSeleccion_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles grdListaMarcasSeleccion.DataError
        e.Cancel = True
    End Sub

    Private Sub rdbEtiquetaLenguaNO_CheckedChanged(sender As Object, e As EventArgs) Handles rdbEtiquetaLenguaNO.CheckedChanged
        rdbEtiquetaEspecialNO.Checked = True
        rdbEtiquetaEspecialSI.Enabled = False
        rdbEtiquetaEspecialNO.Enabled = False
    End Sub

    Private Sub RdbEtiquetaLenguaSI_CheckedChanged(sender As Object, e As EventArgs) Handles RdbEtiquetaLenguaSI.CheckedChanged
        rdbEtiquetaEspecialSI.Enabled = True
        rdbEtiquetaEspecialNO.Enabled = True


    End Sub

    Private Sub RdbEtiquetaLenguaSI_Click(sender As Object, e As EventArgs) Handles RdbEtiquetaLenguaSI.Click
        If RdbEtiquetaLenguaSI.Checked Then
            Dim lotesProceso As New LotesenProcesoform
            lotesProceso.RecibirIdColeccion(IdColeccion)
            lotesProceso.ShowDialog()
        End If

    End Sub
End Class