Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports System.Windows.Forms
Imports Tools
Imports System.IO
Imports Framework.Negocios

Public Class GeneracionAltasIMSSForm

    Private pPatronId As Integer
    Public Property prPatronId() As Integer
        Get
            Return pPatronId
        End Get
        Set(ByVal value As Integer)
            pPatronId = value
        End Set
    End Property

    Private pEstatusId As Integer
    Public Property prEstatusId() As Integer
        Get
            Return pEstatusId
        End Get
        Set(ByVal value As Integer)
            pEstatusId = value
        End Set
    End Property

    Private pNaveId As Integer
    Public Property prNaveId() As Integer
        Get
            Return pNaveId
        End Get
        Set(ByVal value As Integer)
            pNaveId = value
        End Set
    End Property


    Public Sub cargarComboEmpresaPatron()
        Dim objBu As New Contabilidad.Negocios.UtileriasBU
        Dim dtEmpresa As New DataTable

        dtEmpresa = objBu.consultarPatronEmpresa()
        If dtEmpresa.Rows.Count > 0 Then
            cmbPatron.DataSource = dtEmpresa
            cmbPatron.DisplayMember = "Patron"
            cmbPatron.ValueMember = "ID"
            cmbPatron.SelectedIndex = 0
        End If
    End Sub

    Public Sub cargarComboEstatus()
        Dim objBu As New Negocios.UtileriasBU
        Dim dtEstatus As New DataTable
        dtEstatus = objBu.consultaListadoEstatus("ALTAIMSS")

        If dtEstatus.Rows.Count > 0 Then
            cmbEstatus.DataSource = dtEstatus
            cmbEstatus.DisplayMember = "Estatus"
            cmbEstatus.ValueMember = "ID"
            cmbEstatus.SelectedValue = 101
        End If
    End Sub

    Public Sub configurarPermisosBotonesEspeciales()
        If PermisosUsuarioBU.ConsultarPermiso("GEN_ALTAIMSS", "REG_ALTAIMSS") Then
            pnlRegresar.Visible = True
        Else
            pnlRegresar.Visible = False
        End If

        If PermisosUsuarioBU.ConsultarPermiso("GEN_ALTAIMSS", "GEN_TXT") Then
            pnlTTX.Visible = True
        Else
            pnlTTX.Visible = False
        End If
        If PermisosUsuarioBU.ConsultarPermiso("GEN_ALTAIMSS", "ACEP_RECHAZAR") Then
            pnlAutorizar.Visible = True
            pnlRechazar.Visible = True
        Else
            pnlAutorizar.Visible = False
            pnlRechazar.Visible = False
        End If

        If PermisosUsuarioBU.ConsultarPermiso("GEN_ALTAIMSS", "EDT_ALTAIMSS") Then
            pnlEditar.Visible = True
        Else
            pnlEditar.Visible = False
        End If
    End Sub

    Public Sub cargarDatosGeneracionImss()
        Dim dtGeneracion As New DataTable
        Dim objBu As New Negocios.ColaboradoresContabilidadBU
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        dtGeneracion = objBu.consultaGeneracionAltasIMSS(cmbPatron.SelectedValue, cmbEstatus.SelectedValue, txtNombre.Text)

        grdGeneracionImss.DataSource = Nothing

        If Not dtGeneracion Is Nothing Then
            If dtGeneracion.Rows.Count > 0 Then
                grdGeneracionImss.DataSource = Nothing
                grdGeneracionImss.DataSource = dtGeneracion
                formatoGrid()
            End If
        End If
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    Public Sub formatoGrid()
        With grdGeneracionImss.DisplayLayout.Bands(0)

            .Columns("idColaborador").Hidden = True
            .Columns("idAlta").Hidden = True
            .Columns("estatus").Hidden = True
            .Columns("curp").Hidden = True
            .Columns("sdi").Hidden = False
            .Columns("diasAntiguedad").Hidden = True
            .Columns("umfid").Hidden = True
            .Columns("patronId").Hidden = True
            .Columns("patron").Hidden = True

            If cmbEstatus.SelectedValue <> 104 And cmbEstatus.SelectedValue <> 102 Then
                .Columns("motivo").Hidden = True
            End If

            If cmbEstatus.SelectedValue <> 103 Then
                .Columns("fechaaplicacion").Hidden = True
                .Columns("usuarioAplico").Hidden = True
            End If

            .Columns("Seleccion").Header.Caption = ""
            .Columns("nss").Header.Caption = "NSS"
            .Columns("rfc").Header.Caption = "RFC"
            .Columns("apaterno").Header.Caption = "A.Paterno"
            .Columns("aMaterno").Header.Caption = "A.Materno"
            .Columns("nombre").Header.Caption = "Nombre"
            .Columns("fechaAlta").Header.Caption = "Fecha Alta"
            .Columns("Puesto").Header.Caption = "Puesto"
            .Columns("umf").Header.Caption = "UMF"
            .Columns("cp").Header.Caption = "Código Postal"
            .Columns("sexo").Header.Caption = "Sexo"
            .Columns("lugarNacimiento").Header.Caption = "Lugar Nacimiento"
            .Columns("fechaNacimiento").Header.Caption = "Fecha Nacimiento"
            .Columns("motivo").Header.Caption = "Motivo"
            .Columns("fechaaplicacion").Header.Caption = "Fecha Aplicación"
            .Columns("usuarioAplico").Header.Caption = "Usuario Aplicó"
            .Columns("sdi").Header.Caption = "SDI"

            .Columns("apaterno").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("aMaterno").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("nombre").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit

            .Columns("rfc").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("nss").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("fechaAlta").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("puesto").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("umf").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("cp").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("sexo").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("lugarNacimiento").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("fechaNacimiento").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("motivo").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("fechaaplicacion").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("usuarioAplico").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("sdi").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit

            .Columns("Seleccion").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox

            .Columns("Seleccion").AllowRowFiltering = DefaultableBoolean.False


            .PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)

        End With

        grdGeneracionImss.DisplayLayout.PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        grdGeneracionImss.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdGeneracionImss.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdGeneracionImss.DisplayLayout.Override.RowSelectorWidth = 35
        grdGeneracionImss.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
        grdGeneracionImss.Rows(0).Selected = True

        'grdSolicitudes.DisplayLayout.Bands(0).Columns("estDsn").Width = 20
        'grdSolicitudes.DisplayLayout.Bands(0).Columns("Seleccion").Width = 20
        'grdSolicitudes.DisplayLayout.Bands(0).Columns("SemanaEntrega").Width = 50
        'grdSolicitudes.DisplayLayout.Bands(0).Columns("SemanaBaja").Width = 50

        grdGeneracionImss.DisplayLayout.Bands(0).RowLayoutStyle = RowLayoutStyle.ColumnLayout
    End Sub

    Public Sub GenerarArchivosTxt()
        Dim estatus As Boolean = True
        Dim regSeleccionado As Int32 = 0
        Dim advertencia As New AdvertenciaForm
        Dim idsSolicitudes() As Integer
        Dim informacionIdse As New Entidades.InformacionIDSE_SUA
        Dim fecha As String = Date.Now.ToString("ddMMyyyHmm")
        Dim ObjBu As New Negocios.ColaboradoresContabilidadBU
        Dim contGeneradas As Int32 = 0
        Dim exito As New ExitoForm
        Dim dtSUA As New DataTable
        Dim contIdse As Int32 = 0
        Dim countexisteArchivo As Int32 = 0

        dtSUA.Columns.Add("patron")
        dtSUA.Columns.Add("nss")
        dtSUA.Columns.Add("clave")
        dtSUA.Columns.Add("fechaMov")
        dtSUA.Columns.Add("sdi")
        dtSUA.Columns.Add("cp")
        dtSUA.Columns.Add("fechaNac")
        dtSUA.Columns.Add("lugarNac")
        dtSUA.Columns.Add("claveLugarNac")
        dtSUA.Columns.Add("sexo")
        dtSUA.Columns.Add("tipoSalario")
        dtSUA.Columns.Add("hora")
        dtSUA.Columns.Add("umf")
        dtSUA.Columns.Add("ocupacion")


        Dim dtSuATrabajador As New DataTable
        dtSuATrabajador.Columns.Add("patron")
        dtSuATrabajador.Columns.Add("nss")
        dtSuATrabajador.Columns.Add("rfc")
        dtSuATrabajador.Columns.Add("curp")
        dtSuATrabajador.Columns.Add("nombreCompleto")
        dtSuATrabajador.Columns.Add("claveTipoCol")
        dtSuATrabajador.Columns.Add("tipoJornada")
        dtSuATrabajador.Columns.Add("fechaMov")
        dtSuATrabajador.Columns.Add("sdi")
        dtSuATrabajador.Columns.Add("puesto")

        For Each rowGr As UltraGridRow In grdGeneracionImss.Rows
            If CBool(rowGr.Cells("Seleccion").Value) = True Then
                If rowGr.Cells("estatus").Value = "AUTORIZADO" Or rowGr.Cells("estatus").Value = "RECHAZADO IDSE" Then

                Else
                    estatus = False
                End If
                ReDim Preserve idsSolicitudes(regSeleccionado)
                idsSolicitudes(regSeleccionado) = rowGr.Cells("IdAlta").Value
                regSeleccionado += 1

            End If
        Next

        If estatus = True Then

            If regSeleccionado > 0 Then

                For item As Integer = 0 To idsSolicitudes.Length - 1
                    informacionIdse = ObjBu.consultaInformacionIdse(idsSolicitudes(item))
                    If Not informacionIdse.IIAPaterno Is Nothing Then
                        contIdse += 1
                        Dim archivoTXT As String = String.Empty

                        archivoTXT = informacionIdse.IIRutaDescarga & "altaIDSE" & informacionIdse.IINumeroSeguroSocial & "_" & informacionIdse.IITablaId & ".dat"
                        If existeArchivo(archivoTXT) Then
                            countexisteArchivo += 1
                        End If
                    End If
                Next

                If contIdse = regSeleccionado Then
                    If countexisteArchivo > 0 Then
                        Dim mensajeConfirmar As New ConfirmarForm
                        mensajeConfirmar.mensaje = "Ya existen archivos para " + countexisteArchivo.ToString + " de los registros seleccionados, ¿Desea remplazarlos? "
                        If mensajeConfirmar.ShowDialog = DialogResult.OK Then

                            For item As Integer = 0 To idsSolicitudes.Length - 1
                                informacionIdse = ObjBu.consultaInformacionIdse(idsSolicitudes(item))
                                If generarTxtIdse(informacionIdse) Then
                                    Dim row As DataRow = dtSUA.NewRow
                                    row.Item("patron") = informacionIdse.IIRegistroPatronal
                                    row.Item("nss") = informacionIdse.IINumeroSeguroSocial
                                    row.Item("clave") = informacionIdse.IIClaveMovimiento
                                    row.Item("fechaMov") = informacionIdse.IIFechaMovimiento
                                    row.Item("sdi") = informacionIdse.IISalarioDiario


                                    row.Item("cp") = informacionIdse.ICodigoPostal
                                    row.Item("fechaNac") = informacionIdse.IFechaNacimiento
                                    row.Item("lugarNac") = informacionIdse.ILugarNacimiento
                                    row.Item("claveLugarNac") = informacionIdse.IClaveLugarNacimiento
                                    row.Item("sexo") = informacionIdse.ISexo
                                    row.Item("tipoSalario") = informacionIdse.ITipoSalario
                                    row.Item("hora") = informacionIdse.IHora
                                    row.Item("umf") = informacionIdse.IIUnidadMedicaFamiliar
                                    row.Item("ocupacion") = informacionIdse.IOcupacion

                                    dtSUA.Rows.Add(row)

                                    Dim rowTra As DataRow = dtSuATrabajador.NewRow
                                    rowTra.Item("patron") = informacionIdse.IIRegistroPatronal
                                    rowTra.Item("nss") = informacionIdse.IINumeroSeguroSocial
                                    rowTra.Item("rfc") = informacionIdse.IIRFC
                                    rowTra.Item("curp") = informacionIdse.IICurp
                                    rowTra.Item("nombreCompleto") = informacionIdse.IINombreCompleto
                                    rowTra.Item("claveTipoCol") = informacionIdse.IIClaveTipoColaborador
                                    rowTra.Item("tipoJornada") = informacionIdse.IIClaveTipoJornada
                                    rowTra.Item("fechaMov") = informacionIdse.IIFechaMovimiento
                                    rowTra.Item("sdi") = informacionIdse.IISalarioDiario
                                    rowTra.Item("puesto") = informacionIdse.IIPuesto

                                    dtSuATrabajador.Rows.Add(rowTra)
                                    contGeneradas += 1
                                End If

                            Next


                            If regSeleccionado = contGeneradas Then
                                If generarTxtSuaGlobal(dtSUA, fecha, informacionIdse.IIRutaDescarga) Then
                                    If generarTxtSuaTrabajador(dtSuATrabajador, fecha, informacionIdse.IIRutaDescarga) Then

                                        ''genera archivo datos afileatorios
                                        If generarTxtSuaDatosAfileatorios(dtSUA, fecha, informacionIdse.IIRutaDescarga) Then
                                            exito.mensaje = "Los archivos se generaron correctamente."
                                            exito.ShowDialog()
                                        End If

                                    Else

                                    End If

                                Else

                                End If


                            End If

                        End If


                    Else

                        For item As Integer = 0 To idsSolicitudes.Length - 1
                            informacionIdse = ObjBu.consultaInformacionIdse(idsSolicitudes(item))
                            If generarTxtIdse(informacionIdse) Then
                                Dim row As DataRow = dtSUA.NewRow
                                row.Item("patron") = informacionIdse.IIRegistroPatronal
                                row.Item("nss") = informacionIdse.IINumeroSeguroSocial
                                row.Item("clave") = informacionIdse.IIClaveMovimiento
                                row.Item("fechaMov") = informacionIdse.IIFechaMovimiento
                                row.Item("sdi") = informacionIdse.IISalarioDiario

                                row.Item("cp") = informacionIdse.ICodigoPostal
                                row.Item("fechaNac") = informacionIdse.IFechaNacimiento
                                row.Item("lugarNac") = informacionIdse.ILugarNacimiento
                                row.Item("claveLugarNac") = informacionIdse.IClaveLugarNacimiento
                                row.Item("sexo") = informacionIdse.ISexo
                                row.Item("tipoSalario") = informacionIdse.ITipoSalario
                                row.Item("hora") = informacionIdse.IHora
                                row.Item("umf") = informacionIdse.IIUnidadMedicaFamiliar
                                row.Item("ocupacion") = informacionIdse.IOcupacion
                                dtSUA.Rows.Add(row)

                                Dim rowTra As DataRow = dtSuATrabajador.NewRow
                                rowTra.Item("patron") = informacionIdse.IIRegistroPatronal
                                rowTra.Item("nss") = informacionIdse.IINumeroSeguroSocial
                                rowTra.Item("rfc") = informacionIdse.IIRFC
                                rowTra.Item("curp") = informacionIdse.IICurp
                                rowTra.Item("nombreCompleto") = informacionIdse.IINombreCompleto
                                rowTra.Item("claveTipoCol") = informacionIdse.IIClaveTipoColaborador
                                rowTra.Item("tipoJornada") = informacionIdse.IIClaveTipoJornada
                                rowTra.Item("fechaMov") = informacionIdse.IIFechaMovimiento
                                rowTra.Item("sdi") = informacionIdse.IISalarioDiario
                                rowTra.Item("puesto") = informacionIdse.IIPuesto

                                dtSuATrabajador.Rows.Add(rowTra)
                                contGeneradas += 1
                            End If

                        Next


                        If regSeleccionado = contGeneradas Then
                            If generarTxtSuaGlobal(dtSUA, fecha, informacionIdse.IIRutaDescarga) Then
                                If generarTxtSuaTrabajador(dtSuATrabajador, fecha, informacionIdse.IIRutaDescarga) Then
                                    ''genera archivo datos afileatorios
                                    If generarTxtSuaDatosAfileatorios(dtSUA, fecha, informacionIdse.IIRutaDescarga) Then
                                        exito.mensaje = "Los archivos se generaron correctamente."
                                        exito.ShowDialog()
                                    End If
                                Else

                                End If

                            Else

                            End If


                        End If
                    End If
                Else
                    advertencia.mensaje = "La consulta de la información para " + contIdse.ToString + " archivo(s) no arrojó ningún resultado, favor de revisar los datos."
                    advertencia.ShowDialog()
                End If


            End If

        Else
            advertencia.mensaje = "Las solicitudes deben de estar en estatus AUTORIZADO o REGRESADO IDSE para Generar los TXT's."
            advertencia.ShowDialog()
        End If




       


    End Sub

    Public Function generarTxtIdse(ByVal infoIdse As Entidades.InformacionIDSE_SUA) As Boolean
        Dim archivoTXT As String = String.Empty
        Dim informacion As String = String.Empty

        archivoTXT = infoIdse.IIRutaDescarga & "altaIDSE" & infoIdse.IINumeroSeguroSocial & "_" & infoIdse.IITablaId & ".dat"
        If Not existeArchivo(IO.Path.GetDirectoryName(archivoTXT)) Then
            crearCarpeta(IO.Path.GetDirectoryName(archivoTXT))
        End If

        informacion = infoIdse.IIRegistroPatronal.ToString
        informacion &= infoIdse.IINumeroSeguroSocial.ToString
        informacion &= infoIdse.IIAPaterno
        informacion &= infoIdse.IIAMaterno
        informacion &= infoIdse.IINombre
        informacion &= infoIdse.IISalarioDiario.ToString
        informacion &= "000000" 'Filler
        informacion &= infoIdse.IIClaveTipoColaborador.ToString
        informacion &= infoIdse.IIClaveTipoSalario.ToString
        informacion &= infoIdse.IIClaveTipoJornada.ToString
        informacion &= infoIdse.IIFechaMovimiento.ToString
        informacion &= infoIdse.IIUnidadMedicaFamiliar.ToString
        informacion &= "  " 'Filler
        informacion &= infoIdse.IIClaveMovimiento.ToString
        informacion &= guia
        informacion &= infoIdse.IIClaveTrabajador.ToString
        informacion &= " " 'Filler
        informacion &= infoIdse.IICurp.ToString
        informacion &= infoIdse.IIIdentificador.ToString



        'Pie del archivo
        informacion &= vbCrLf
        informacion &= "*************                                           "
        informacion &= "000001                                                                       "
        informacion &= guia
        informacion &= "                             "
        informacion &= infoIdse.IIIdentificador

        Try
            File.WriteAllText(archivoTXT, informacion.ToUpper)
            Return True
        Catch ex As Exception
            Return False
        End Try

        'If generarTxtSua(infoIdse, fecha) Then
        '    If generarTxtSuaTrabajador(infoIdse, fecha) Then
        '        Return True
        '    Else
        '        Return False
        '    End If

        'Else
        '    eliminaArchivo(archivoTXT)
        '    Return False
        'End If
    End Function

    Private Function generarTxtSuaGlobal(ByVal dtDatos As DataTable, ByVal fecha As String, ByVal rutaDescarga As String) As Boolean
        Dim archivoTXT As String = String.Empty
        Dim informacion As String = String.Empty

        archivoTXT = rutaDescarga & "altaSUA" & "_" & fecha & ".txt"
        If Not existeArchivo(IO.Path.GetDirectoryName(archivoTXT)) Then
            crearCarpeta(IO.Path.GetDirectoryName(archivoTXT))
        End If

        For Each rowDato As DataRow In dtDatos.Rows
            informacion &= rowDato("patron").ToString
            informacion &= rowDato("nss").ToString
            informacion &= rowDato("clave").ToString
            informacion &= rowDato("fechaMov").ToString
            informacion &= "00000000" 'Espacio para Folio incapacidad (NO APLICA)
            informacion &= "00" 'Espacio para Dias de incidencia (NO APLICA)
            informacion &= "0" & rowDato("sdi").ToString
            informacion &= vbCrLf
        Next




        File.WriteAllText(archivoTXT, informacion.ToUpper)
        Return existeArchivo(archivoTXT)
    End Function

    Private Function generarTxtSuaDatosAfileatorios(ByVal dtDatos As DataTable, ByVal fecha As String, ByVal rutaDescarga As String) As Boolean
        Dim archivoTXT As String = String.Empty
        Dim informacion As String = String.Empty

        archivoTXT = rutaDescarga & "Datos_AfilSUA" & "_" & fecha & ".txt"
        If Not existeArchivo(IO.Path.GetDirectoryName(archivoTXT)) Then
            crearCarpeta(IO.Path.GetDirectoryName(archivoTXT))
        End If

        For Each rowDato As DataRow In dtDatos.Rows
            informacion &= rowDato("patron").ToString
            informacion &= rowDato("nss").ToString
            informacion &= rowDato("cp").ToString
            informacion &= rowDato("fechaNac").ToString
            informacion &= rowDato("lugarNac").ToString
            informacion &= rowDato("claveLugarNac").ToString
            informacion &= rowDato("umf").ToString
            informacion &= rowDato("ocupacion").ToString
            informacion &= rowDato("sexo").ToString
            informacion &= rowDato("tipoSalario").ToString
            informacion &= rowDato("hora").ToString
            informacion &= vbCrLf
        Next


        File.WriteAllText(archivoTXT, informacion.ToUpper)
        Return existeArchivo(archivoTXT)
    End Function

    Private Function generarTxtSua(ByVal infoIdse As Entidades.InformacionIDSE_SUA, ByVal fecha As String) As Boolean
        Dim archivoTXT As String = String.Empty
        Dim informacion As String = String.Empty

        archivoTXT = infoIdse.IIRutaDescarga & "altaSUA" & infoIdse.IINumeroSeguroSocial & "_" & fecha & ".txt"
        If Not existeArchivo(IO.Path.GetDirectoryName(archivoTXT)) Then
            crearCarpeta(IO.Path.GetDirectoryName(archivoTXT))
        End If

        informacion = infoIdse.IIRegistroPatronal
        informacion &= infoIdse.IINumeroSeguroSocial
        informacion &= infoIdse.IIClaveMovimiento
        informacion &= infoIdse.IIFechaMovimiento
        informacion &= "00000000" 'Espacio para Folio incapacidad (NO APLICA)
        informacion &= "00" 'Espacio para Dias de incidencia (NO APLICA)
        informacion &= "0" & infoIdse.IISalarioDiario

        File.WriteAllText(archivoTXT, informacion.ToUpper)
        Return existeArchivo(archivoTXT)
    End Function

    Private Function generarTxtSuaTrabajador(ByVal dtSuaTra As DataTable, ByVal fecha As String, ByVal rutaDescarga As String) As Boolean
        Dim archivoTXT As String = String.Empty
        Dim informacion As String = String.Empty

        archivoTXT = rutaDescarga & "altaEmpleadoSUA" & "_" & fecha & ".txt"
        If Not existeArchivo(IO.Path.GetDirectoryName(archivoTXT)) Then
            crearCarpeta(IO.Path.GetDirectoryName(archivoTXT))
        End If

        For Each rowDato As DataRow In dtSuaTra.Rows
            informacion &= rowDato("patron").ToString
            informacion &= rowDato("nss").ToString
            informacion &= rowDato("rfc").ToString
            informacion &= rowDato("curp").ToString
            informacion &= rowDato("nombreCompleto").ToString
            informacion &= rowDato("claveTipoCol").ToString
            informacion &= rowDato("tipoJornada").ToString
            informacion &= rowDato("fechaMov").ToString
            informacion &= "0" & rowDato("sdi").ToString
            informacion &= rowDato("puesto").ToString
            informacion &= "          " ''espacio credito infonavit
            informacion &= rowDato("fechaMov").ToString
            informacion &= "0" ''espacio tipo de descuento
            informacion &= "00000000" ''valor de decuento
            informacion &= vbCrLf
        Next



        File.WriteAllText(archivoTXT, informacion.ToUpper)
        Return existeArchivo(archivoTXT)

    End Function

    Public Sub aceptarAltaImss()
        Dim objMensajeAdv As New Tools.AdvertenciaForm
        Dim objMensajeError As New Tools.ErroresForm
        Dim objMensajeExito As New Tools.ExitoForm
        Dim contSeleccionadas As Integer = 0
        Dim solicitudId As Integer = 0
        Dim colaboradorId As Integer = 0
        Dim estatus As String = String.Empty
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        For Each row As UltraGridRow In grdGeneracionImss.Rows
            If row.Cells("seleccion").Value Then
                contSeleccionadas += 1
                solicitudId = row.Cells("idAlta").Value
                colaboradorId = row.Cells("idColaborador").Value
                estatus = row.Cells("estatus").Value
            End If
        Next

        If contSeleccionadas = 0 Then
            objMensajeAdv.mensaje = "Favor de selecionar un registro."
            objMensajeAdv.ShowDialog()
        ElseIf contSeleccionadas > 1 Then
            objMensajeAdv.mensaje = "Favor de selecionar solo un registro."
            objMensajeAdv.ShowDialog()
        Else
            Dim objBu As New Negocios.ColaboradoresContabilidadBU

            If objBu.validaSolicitudBaja(colaboradorId) Then
                If estatus = "AUTORIZADO" Or estatus = "RECHAZADO IDSE" Then
                    Dim objForm As New PDFAcuseMovimientosIDSEForm
                    If Not CheckForm(objForm) Then

                        Dim formaSubirPdf As New PDFAcuseMovimientosIDSEForm
                        formaSubirPdf.solicitudId = solicitudId
                        formaSubirPdf.colaboradorId = colaboradorId
                        formaSubirPdf.movimiento = "Aceptar"
                        formaSubirPdf.ShowDialog()

                        If formaSubirPdf.guardado Then
                            cargarDatosGeneracionImss()
                        End If
                    End If
                Else
                    objMensajeAdv.mensaje = "La solicitudes debe de estar en estatus AUTORIZADO o REGRESADO IDSE para subir el PDF de Acuse."
                    objMensajeAdv.ShowDialog()
                End If
            Else
                objMensajeAdv.mensaje = "El colaborador tiene una solicitud de BAJA por cambio de patrón pendiente de aplicar."
                objMensajeAdv.ShowDialog()
            End If
        End If
        cargarDatosGeneracionImss()
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    Public Sub rechazarAltaImss()
        Dim objMensajeAdv As New Tools.AdvertenciaForm
        Dim objMensajeError As New Tools.ErroresForm
        Dim objMensajeExito As New Tools.ExitoForm
        Dim contSeleccionadas As Integer = 0
        Dim solicitudId As Integer = 0
        Dim colaboradorId As Integer = 0
        Dim estatus As String = String.Empty

        For Each row As UltraGridRow In grdGeneracionImss.Rows
            If row.Cells("seleccion").Value Then
                contSeleccionadas += 1
                solicitudId = row.Cells("idAlta").Value
                colaboradorId = row.Cells("idColaborador").Value
                estatus = row.Cells("estatus").Value
            End If
        Next

        If contSeleccionadas = 0 Then
            objMensajeAdv.mensaje = "Favor de selecionar un registro."
            objMensajeAdv.ShowDialog()
        ElseIf contSeleccionadas > 1 Then
            objMensajeAdv.mensaje = "Favor de selecionar solo un registro."
            objMensajeAdv.ShowDialog()
        Else
            If estatus = "AUTORIZADO" Then
                Dim objForm As New PDFAcuseMovimientosIDSEForm
                If Not CheckForm(objForm) Then

                    Dim formaSubirPdf As New PDFAcuseMovimientosIDSEForm
                    formaSubirPdf.solicitudId = solicitudId
                    formaSubirPdf.colaboradorId = colaboradorId
                    formaSubirPdf.movimiento = "Rechazar"
                    formaSubirPdf.ShowDialog()

                    If formaSubirPdf.guardado Then
                        cargarDatosGeneracionImss()
                    End If
                End If
            Else
                objMensajeAdv.mensaje = "La solicitudes debe de estar en estatus AUTORIZADO para subir el PDF de Acuse."
                objMensajeAdv.ShowDialog()
            End If
        End If
    End Sub

    Public Sub regresarSolicitud()
        Dim objMensajeAdv As New Tools.AdvertenciaForm
        Dim objMensajeError As New Tools.ErroresForm
        Dim objMensajeExito As New Tools.ExitoForm
        Dim idsSolicitudes() As Integer
        Dim contSeleccionadas As Integer = 0
        Dim estatus As Boolean = True

        For Each row As UltraGridRow In grdGeneracionImss.Rows
            If row.Cells("seleccion").Value Then
                ReDim Preserve idsSolicitudes(contSeleccionadas)
                idsSolicitudes(contSeleccionadas) = row.Cells("idAlta").Value
                contSeleccionadas += 1
                If row.Cells("estatus").Value <> "AUTORIZADO" Then
                    estatus = False
                End If
            End If
        Next

        If contSeleccionadas > 0 Then
            If estatus = True Then
                Dim objMensajeConf As New Tools.ConfirmarForm
                objMensajeConf.mensaje = "¿Está seguro de regresar los " & contSeleccionadas & " registros seleccionados?"

                If objMensajeConf.ShowDialog = Windows.Forms.DialogResult.OK Then
                    Dim resultado As String = String.Empty
                    Dim motivoRechazo As String = String.Empty
                    Dim contRegresadas As Integer = 0
                    Dim objBu As New Negocios.ColaboradoresContabilidadBU
                    Dim formMotivo As New MotivoRechazoForm

                    If Not CheckForm(formMotivo) Then
                        formMotivo.ShowDialog()

                        If formMotivo.motivo <> "" Then
                            motivoRechazo = formMotivo.motivo

                        Else
                            objMensajeAdv.mensaje = "No se regresaron las solicitudes debido a que no se ingresó el motivo de regreso."
                            objMensajeAdv.ShowDialog()
                            Exit Sub
                        End If
                    End If

                    For item As Integer = 0 To idsSolicitudes.Length - 1
                        resultado = objBu.regresarSolicitudesImss(idsSolicitudes(item), motivoRechazo)

                        If resultado = "EXITO" Then
                            contRegresadas += 1
                        End If
                    Next

                    If contSeleccionadas = contRegresadas Then
                        objMensajeExito.mensaje = "Solicitudes Regresadas correctamente."
                        objMensajeExito.ShowDialog()
                        cargarDatosGeneracionImss()
                    ElseIf contRegresadas = 0 Then
                        objMensajeError.mensaje = "Error no se pudieron regresar las solicitudes."
                        objMensajeError.ShowDialog()
                    ElseIf contSeleccionadas > contRegresadas Then
                        objMensajeError.mensaje = "Algunas solicitudes seleccionadas no se pudieron regresar, el listado se actualizará favor de intentarlo nuevamente."
                        objMensajeError.ShowDialog()
                        cargarDatosGeneracionImss()
                    End If

                End If
            Else
                objMensajeAdv.mensaje = "Las solicitudes deben de estar en estatus AUTORIZADO para Regresarlas."
                objMensajeAdv.ShowDialog()
            End If
        End If
    End Sub

    Public Sub consultarAltaImss()
        Dim alta As New CompletarAltaColaboradorIMSSForm
        Dim dtEditar As New DataTable

        dtEditar.Columns.Add("seleccion")
        dtEditar.Columns.Add("idColaborador")
        dtEditar.Columns.Add("aPaterno")
        dtEditar.Columns.Add("aMaterno")
        dtEditar.Columns.Add("nombre")
        dtEditar.Columns.Add("curp")
        dtEditar.Columns.Add("rfc")
        dtEditar.Columns.Add("nss")
        dtEditar.Columns.Add("diasAntiguedad")
        dtEditar.Columns.Add("puesto")
        dtEditar.Columns.Add("sdi")
        dtEditar.Columns.Add("umfId")
        dtEditar.Columns.Add("patronId")
        dtEditar.Columns.Add("patron")

        Dim filaCol As DataRow = dtEditar.NewRow

        filaCol.Item("seleccion") = "false"
        filaCol.Item("idColaborador") = grdGeneracionImss.ActiveRow.Cells("idColaborador").Value()
        filaCol.Item("aPaterno") = grdGeneracionImss.ActiveRow.Cells("apaterno").Value()
        filaCol.Item("aMaterno") = grdGeneracionImss.ActiveRow.Cells("amaterno").Value()
        filaCol.Item("nombre") = grdGeneracionImss.ActiveRow.Cells("nombre").Value()
        filaCol.Item("curp") = grdGeneracionImss.ActiveRow.Cells("curp").Value()
        filaCol.Item("rfc") = grdGeneracionImss.ActiveRow.Cells("rfc").Value()
        filaCol.Item("nss") = grdGeneracionImss.ActiveRow.Cells("nss").Value()
        filaCol.Item("diasAntiguedad") = grdGeneracionImss.ActiveRow.Cells("diasAntiguedad").Value()
        filaCol.Item("puesto") = grdGeneracionImss.ActiveRow.Cells("puesto").Value()
        filaCol.Item("sdi") = grdGeneracionImss.ActiveRow.Cells("sdi").Value()
        filaCol.Item("umfId") = grdGeneracionImss.ActiveRow.Cells("umfId").Value()
        filaCol.Item("patronId") = grdGeneracionImss.ActiveRow.Cells("patronId").Value()
        filaCol.Item("patron") = grdGeneracionImss.ActiveRow.Cells("patron").Value()

        dtEditar.Rows.Add(filaCol)

        alta.dtColabo = dtEditar
        alta.editaridColaborador = grdGeneracionImss.ActiveRow.Cells("idColaborador").Value()
        alta.idAlta = grdGeneracionImss.ActiveRow.Cells("idAlta").Value()
        alta.btnGuardar.Visible = False
        alta.txtSDI.Enabled = False
        alta.lblGuardar.Visible = False
        alta.ShowDialog()

    End Sub
    Private Function CheckForm(_form As Form) As Boolean
        For Each f As Form In Application.OpenForms
            If f.Name = _form.Name Then
                Return True
            End If
        Next

        Return False
    End Function

    Public Sub limpiarCampos()
        grdGeneracionImss.DataSource = Nothing
        txtNombre.Text = ""
        cmbEstatus.SelectedValue = 101
        cmbPatron.SelectedIndex = 0
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub GeneracionAltasIMSSForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.WindowState = FormWindowState.Maximized
        Me.Top = 0
        Me.Left = 0
        cargarComboEmpresaPatron()
        cargarComboEstatus()
        configurarPermisosBotonesEspeciales()

        If pPatronId <> 0 And cmbPatron.Items.Count > 0 Then
            cmbPatron.SelectedValue = pPatronId
            If pEstatusId <> 0 Then
                cmbEstatus.SelectedValue = pEstatusId
            End If
            cargarDatosGeneracionImss()
        End If
    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        gpbFiltro.Height = 40
        grdGeneracionImss.Height = 471
        grdGeneracionImss.Top = 115
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        gpbFiltro.Height = 118
        grdGeneracionImss.Height = 346
        grdGeneracionImss.Top = 240
    End Sub

    Private Sub txtNombre_KeyDown(sender As Object, e As Windows.Forms.KeyEventArgs) Handles txtNombre.KeyDown
        If (e.KeyValue = Keys.Enter) Then
            cargarDatosGeneracionImss()
        End If
    End Sub

    Private Sub btnFiltrarSolicitud_Click(sender As Object, e As EventArgs) Handles btnFiltrarSolicitud.Click
        cargarDatosGeneracionImss()
    End Sub


    Private Sub btnGenerarTtx_Click(sender As Object, e As EventArgs) Handles btnGenerarTtx.Click
        GenerarArchivosTxt()
    End Sub

    Private Sub btnAutorizar_Click(sender As Object, e As EventArgs) Handles btnAutorizar.Click
        aceptarAltaImss()
    End Sub



    Private Sub btnRechazar_Click(sender As Object, e As EventArgs) Handles btnRechazar.Click
        rechazarAltaImss()
    End Sub

    Private Sub btnRegresar_Click(sender As Object, e As EventArgs) Handles btnRegresar.Click
        regresarSolicitud()
    End Sub

    Private Sub grdGeneracionImss_DoubleClick(sender As Object, e As EventArgs) Handles grdGeneracionImss.DoubleClick
        consultarAltaImss()
    End Sub

    Private Sub btnLimpiarSolicitudes_Click(sender As Object, e As EventArgs) Handles btnLimpiarSolicitudes.Click
        limpiarCampos()
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        Dim objMensajeAdv As New Tools.AdvertenciaForm
        Dim contSeleccionadas As Integer = 0
        Dim altaId As Integer = 0

        For Each row As UltraGridRow In grdGeneracionImss.Rows
            If row.Cells("seleccion").Value Then
                contSeleccionadas += 1
                altaId = row.Cells("idAlta").Value
            End If
        Next

        If contSeleccionadas = 0 Then
            objMensajeAdv.mensaje = "Favor de selecionar un registro."
            objMensajeAdv.ShowDialog()
        ElseIf contSeleccionadas > 1 Then
            objMensajeAdv.mensaje = "Favor de selecionar solo un registro."
            objMensajeAdv.ShowDialog()
        Else
            Dim idsAlta(0) As Integer
            idsAlta(0) = altaId
            If validarEstatus(1, idsAlta) Then
                editarAltaImss()
            Else
                objMensajeAdv.mensaje = "La solicitud de Alta a IMSS debe de estar en estatus SOLICITADO, AUTORIZADA o RECHAZADO IDSE para Editarla."
                objMensajeAdv.ShowDialog()
            End If
        End If
    End Sub

    Private Function validarEstatus(ByVal opcEstatus As Int16, ByVal idsAlta() As Integer) As Boolean
        Dim objBU As New Negocios.ColaboradoresContabilidadBU
        Dim resultado As String = String.Empty

        For item As Integer = 0 To idsAlta.Length - 1
            resultado = objBU.validarEstatus(idsAlta(item), opcEstatus)
            If resultado <> "CORRECTO" Then
                Return False
                Exit Function
            End If
        Next

        Return True
    End Function

    Public Sub editarAltaImss()
        Dim alta As New CompletarAltaColaboradorIMSSForm
        Dim dtEditar As New DataTable

        dtEditar.Columns.Add("seleccion")
        dtEditar.Columns.Add("idColaborador")
        dtEditar.Columns.Add("aPaterno")
        dtEditar.Columns.Add("aMaterno")
        dtEditar.Columns.Add("nombre")
        dtEditar.Columns.Add("curp")
        dtEditar.Columns.Add("rfc")
        dtEditar.Columns.Add("nss")
        dtEditar.Columns.Add("diasAntiguedad")
        dtEditar.Columns.Add("puesto")
        dtEditar.Columns.Add("sdi")
        dtEditar.Columns.Add("umfId")
        dtEditar.Columns.Add("patronId")
        dtEditar.Columns.Add("patron")

        Dim filaCol As DataRow = dtEditar.NewRow

        filaCol.Item("seleccion") = "false"
        filaCol.Item("idColaborador") = grdGeneracionImss.ActiveRow.Cells("idColaborador").Value()
        filaCol.Item("aPaterno") = grdGeneracionImss.ActiveRow.Cells("apaterno").Value()
        filaCol.Item("aMaterno") = grdGeneracionImss.ActiveRow.Cells("amaterno").Value()
        filaCol.Item("nombre") = grdGeneracionImss.ActiveRow.Cells("nombre").Value()
        filaCol.Item("curp") = grdGeneracionImss.ActiveRow.Cells("curp").Value()
        filaCol.Item("rfc") = grdGeneracionImss.ActiveRow.Cells("rfc").Value()
        filaCol.Item("nss") = grdGeneracionImss.ActiveRow.Cells("nss").Value()
        filaCol.Item("diasAntiguedad") = grdGeneracionImss.ActiveRow.Cells("diasAntiguedad").Value()
        filaCol.Item("puesto") = grdGeneracionImss.ActiveRow.Cells("puesto").Value()
        filaCol.Item("sdi") = grdGeneracionImss.ActiveRow.Cells("sdi").Value()
        filaCol.Item("umfId") = grdGeneracionImss.ActiveRow.Cells("umfId").Value()
        filaCol.Item("patronId") = grdGeneracionImss.ActiveRow.Cells("patronId").Value()
        filaCol.Item("patron") = grdGeneracionImss.ActiveRow.Cells("patron").Value()

        dtEditar.Rows.Add(filaCol)

        alta.dtColabo = dtEditar
        alta.editaridColaborador = grdGeneracionImss.ActiveRow.Cells("idColaborador").Value()
        alta.idAlta = grdGeneracionImss.ActiveRow.Cells("idAlta").Value()
        'alta.btnGuardar.Visible = False
        alta.txtSDI.Enabled = False
        'alta.lblGuardar.Visible = False
        alta.editar = True
        alta.ShowDialog()
    End Sub
End Class