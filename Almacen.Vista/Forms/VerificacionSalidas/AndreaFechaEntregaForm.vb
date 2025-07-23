Imports Tools
Public Class AndreaFechaEntregaForm

    Dim ObjBU As New Negocios.VerificacionSalidasBU
    Public _FolioVerificacionId As Integer = 0
    Public _AgregarLote As Boolean = False

    Private Sub AndreaFechaEntregaForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            Cursor = Cursors.WaitCursor
            dtmFechaConfirmacionInicio.Value = Date.Now
            CargarOperadores()
            MostrarLotes()
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, ex.Message.ToString())
        End Try
    End Sub

    Private Sub MostrarLotes()
        Try
            Cursor = Cursors.WaitCursor

            grdFacturasAndrea.DataSource = Nothing
            grdFacturasAndrea.DataSource = ObjBU.ConsultaLotesAndreaPorOT(dtmFechaConfirmacionInicio.Value.ToShortDateString(), dtmFechaConfirmacionA.Value.ToShortDateString())


            grdFacturasAndrea.Text = CDbl(viewFacturasAndrea.RowCount).ToString("N0")
            DiseñoGrid.DiseñoBaseGrid(viewFacturasAndrea)
            viewFacturasAndrea.Columns.ColumnByFieldName("FechaConfirmo").DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss"

            'DiseñoGrid.EstiloColumna(viewFacturasAndrea, "Seleccionar", " ", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Like, True, True, 60, False, Nothing, "")
            DiseñoGrid.EstiloColumna(viewFacturasAndrea, "OT", "OT", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Like, False, True, 60, False, Nothing, "")
            DiseñoGrid.EstiloColumna(viewFacturasAndrea, "loteAndrea", "Lote Andrea", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Like, False, True, 60, False, Nothing, "")
            DiseñoGrid.EstiloColumna(viewFacturasAndrea, "Cantidad", "Cantidad", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Like, False, True, 60, True, DevExpress.Data.SummaryItemType.Sum, "{0:N0}")
            DiseñoGrid.EstiloColumna(viewFacturasAndrea, "Confirmados", "Confirmados", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Like, False, True, 60, True, DevExpress.Data.SummaryItemType.Sum, "{0:N0}")
            DiseñoGrid.EstiloColumna(viewFacturasAndrea, "FechaConfirmo", "Fecha Confirmo", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Like, False, True, 60, False, Nothing, "")
            DiseñoGrid.EstiloColumna(viewFacturasAndrea, "XMLGenerado", "XMLGenerado", False, DevExpress.XtraGrid.Columns.AutoFilterCondition.Like, False, True, 60, False, Nothing, "")

            viewFacturasAndrea.Columns.ColumnByFieldName("Seleccionar").OptionsColumn.AllowEdit = True


            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, "Ocurrio un error al mostrar la información, intente de nuevo.")
        End Try

    End Sub

    Private Sub CargarOperadores()
        Dim objBUSalidas As New Negocios.SalidasAlmacenBU
        Dim Tabla_ListadoParametros As New DataTable

        Try
            Tabla_ListadoParametros = objBUSalidas.LlenarCombosGenerarEntrega(2)
            Tabla_ListadoParametros.Rows.InsertAt(Tabla_ListadoParametros.NewRow, 0)
            cmbOperador.DataSource = Tabla_ListadoParametros
            cmbOperador.DisplayMember = "Operador"
            cmbOperador.ValueMember = "ID"
        Catch ex As Exception
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, ex.Message.ToString())
        End Try

    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        Try
            Cursor = Cursors.WaitCursor
            MostrarLotes()
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, ex.Message.ToString())
        End Try

    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnFinalizar_Click(sender As Object, e As EventArgs) Handles btnFinalizar.Click
        Try

            If _AgregarLote = True Then
                If ValidarPartidasSeleccionadas() = True Then
                    If InsertarParesLotesAndrea(_FolioVerificacionId) = True Then
                        Me.DialogResult = DialogResult.OK
                        Me.Close()
                    Else
                        Utilerias.show_message(Utilerias.TipoMensaje.Aviso, "Ocurrio un error al insertar la informacion.")
                    End If

                Else
                    Utilerias.show_message(Utilerias.TipoMensaje.Aviso, "No se ha seleccionado un lote de Andrea.")
                End If

            Else
                If cmbOperador.SelectedIndex = 0 Then
                    Utilerias.show_message(Utilerias.TipoMensaje.Aviso, "No se ha seleccionado un operador.")
                Else
                    ValidarSessionesActivas()
                End If
            End If




        Catch ex As Exception
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, ex.Message.ToString())
        End Try

    End Sub


    Private Sub ValidarSessionesActivas()
        Dim ColaboradorId As Integer = 0
        Dim FolioVerificacionID As Integer = 0
        Dim entFolio As New Entidades.InfoVerificacionFolio
        Dim UsuarioID As Integer = 0

        Try
            Cursor = Cursors.WaitCursor
            ColaboradorId = cmbOperador.SelectedValue
            UsuarioID = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid



            If ObjBU.ConsultaSessionActiva(ColaboradorId) = True Then
                FolioVerificacionID = ObjBU.ObtenerFolioVerificacionSession(ColaboradorId)
                Utilerias.show_message(Utilerias.TipoMensaje.Aviso, "Ya existe una session activa.")
            ElseIf _FolioVerificacionId > 0 Then 'Verifica si ya existe un folio de verificacion.
                If ValidarPartidasSeleccionadas() = True Then
                    If InsertarParesLotesAndrea(_FolioVerificacionId) = True Then
                        Utilerias.show_message(Utilerias.TipoMensaje.Exito, "Se ha generado el folio de verificación.")
                        Dim LecturasParesForm As New LecturaParesSalidaForm
                        LecturasParesForm.FolioVerificacionId = _FolioVerificacionId
                        LecturasParesForm.ColaboradorId = ColaboradorId
                        LecturasParesForm.EsAndrea = True
                        LecturasParesForm.MdiParent = Me.MdiParent
                        LecturasParesForm.Show()
                        Me.Close()
                    Else
                        Utilerias.show_message(Utilerias.TipoMensaje.Errores, "Ocurrio un error al generar el Folio de Verificación.")
                    End If
                Else
                    Utilerias.show_message(Utilerias.TipoMensaje.Aviso, "No se ha seleccionado una partida.")
                End If

            Else 'Inserta el folio de verificacion de salida.
                With entFolio
                    .ColaboradorId = ColaboradorId
                    .FolioPaqueteria = ""
                    .Mensajeria = ""
                    .MensajeriaId = 0
                    .Operador = ""
                    .OperadorID = 0
                    .StatusID = 0
                    .Unidad = ""
                    .UnidadID = 0
                    .UsuarioID = UsuarioID
                    .EsAndrea = True
                End With

                FolioVerificacionID = ObjBU.InsertarFolio(entFolio)

                If ValidarPartidasSeleccionadas() = True Then
                    If InsertarParesLotesAndrea(FolioVerificacionID) = True Then
                        Utilerias.show_message(Utilerias.TipoMensaje.Exito, "Se ha generado el folio de verificación.")
                        Dim LecturasParesForm As New LecturaParesSalidaForm
                        LecturasParesForm.FolioVerificacionId = FolioVerificacionID
                        LecturasParesForm.ColaboradorId = ColaboradorId
                        LecturasParesForm.EsAndrea = True
                        LecturasParesForm.MdiParent = Me.MdiParent
                        LecturasParesForm.Show()
                        Me.Close()
                    Else
                        Utilerias.show_message(Utilerias.TipoMensaje.Errores, "Ocurrio un error al generar el Folio de Verificación.")
                    End If
                Else
                    Utilerias.show_message(Utilerias.TipoMensaje.Aviso, "No se ha seleccionado una partida.")
                End If
            End If

            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, ex.Message.ToString())
        End Try
    End Sub

    Private Function ValidarPartidasSeleccionadas() As Boolean
        Dim NumeroFilas As Integer = 0
        Dim FilasSeleccionadas As Boolean = False

        Try
            NumeroFilas = viewFacturasAndrea.DataRowCount

            For index As Integer = 0 To NumeroFilas Step 1
                If CBool(viewFacturasAndrea.GetRowCellValue(viewFacturasAndrea.GetVisibleRowHandle(index), "Seleccionar")) = True Then
                    FilasSeleccionadas = True
                    'EstatusID = CInt(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "EstatusID"))
                End If
            Next

            Return FilasSeleccionadas
        Catch ex As Exception
            Return False
        End Try

    End Function


    Private Function InsertarParesLotesAndrea(ByVal FolioVerificacionID As Integer) As Boolean
        Dim NumeroFilas As Integer = 0
        Dim OT As Integer = 0
        Dim LoteAndrea As Integer = 0
        Dim Partida As Integer = 0
        Dim confirmar As New Tools.ConfirmarForm


        Try
            NumeroFilas = viewFacturasAndrea.DataRowCount
            Cursor = Cursors.WaitCursor


            confirmar.mensaje = "Se generará un folio de Verificación ¿Esta seguro de continuar?"

            If confirmar.ShowDialog() = Windows.Forms.DialogResult.OK Then
                For index As Integer = 0 To NumeroFilas Step 1
                    If CBool(viewFacturasAndrea.GetRowCellValue(viewFacturasAndrea.GetVisibleRowHandle(index), "Seleccionar")) = True Then

                        OT = CInt(viewFacturasAndrea.GetRowCellValue(viewFacturasAndrea.GetVisibleRowHandle(index), "OT"))
                        LoteAndrea = CInt(viewFacturasAndrea.GetRowCellValue(viewFacturasAndrea.GetVisibleRowHandle(index), "loteAndrea"))
                        Partida = CInt(viewFacturasAndrea.GetRowCellValue(viewFacturasAndrea.GetVisibleRowHandle(index), "Partida"))
                        ObjBU.InsertarParesAndrea(FolioVerificacionID, OT, LoteAndrea, Partida)

                    End If
                Next
            End If

            Return True

            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            Return False
        End Try

    End Function

    Private Sub chkSeleccionar_CheckedChanged(sender As Object, e As EventArgs) Handles chkSeleccionar.CheckedChanged
        Dim NumeroFilas As Integer = 0

        Try
            Cursor = Cursors.WaitCursor
            NumeroFilas = viewFacturasAndrea.DataRowCount

            For index As Integer = 0 To NumeroFilas Step 1
                viewFacturasAndrea.SetRowCellValue(viewFacturasAndrea.GetVisibleRowHandle(index), "Seleccionar", chkSeleccionar.Checked)
            Next
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
        End Try
    End Sub


End Class