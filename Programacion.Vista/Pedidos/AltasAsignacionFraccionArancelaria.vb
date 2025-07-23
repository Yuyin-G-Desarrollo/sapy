Imports Tools.Controles
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Tools

Public Class AltasAsignacionFraccionArancelariaForm

    Public IdFraccion As Integer




    Private Sub AltasAsignacionFraccionArancelariaForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.StartPosition = FormStartPosition.CenterScreen

        ''LLENAMOS LOS COMBOS
        Combo_FraccionesArancelariasActivas_SAY(cmbFraccionAAsignar)
        Combo_Familias_Activas_SAY(cmbFalimias)
        Combo_PielMuestra_o_Corte_Activa_SAY(cmbCorte)
        Combo_Forros_Activos_SAY(cmbForro)
        Combo_Suelas_Activas_SAY(cmbSuela)
        Combo_TipoCategoria_Activos_SAY(cmbTipo)
        Combo_Corridas_Mexicanas_Activas_SAY(cmbCorrida)
        cmbFraccionAAsignar.SelectedValue = IdFraccion
    End Sub

#Region "ACCIONES COMBO"

    Private Sub cmbFraccionAAsignar_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbFraccionAAsignar.SelectedIndexChanged
        chkSeleccionarTodo_Tallas.Checked = False
        grdTallas.DataSource = Nothing

        If cmbFraccionAAsignar.SelectedIndex > 0 Then
            gpbCaracteristicasDelArticulo.Enabled = True
            gpbTallas.Enabled = True
        Else
            gpbCaracteristicasDelArticulo.Enabled = False
            gpbTallas.Enabled = False
        End If
    End Sub

    Private Sub cmbCorrida_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCorrida.SelectedIndexChanged
        chkSeleccionarTodo_Tallas.Checked = False
        If cmbCorrida.SelectedIndex > 0 Then
            If ValidarCamposVacios() = False Then
                btnGuardarFraccion.Enabled = True
                PoblarTablaTallas()
            End If
        Else
            ValidarCamposVacios()
            grdTallas.DataSource = Nothing
            btnGuardarFraccion.Enabled = False
        End If
    End Sub

    Private Sub cmbFalimias_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbFalimias.SelectedIndexChanged
        chkSeleccionarTodo_Tallas.Checked = False
        If cmbFalimias.SelectedIndex > 0 Then
            If ValidarCamposVacios() = False Then
                btnGuardarFraccion.Enabled = True
                PoblarTablaTallas()
            End If
        Else
            ValidarCamposVacios()
            grdTallas.DataSource = Nothing
            btnGuardarFraccion.Enabled = False
        End If
    End Sub


    Private Sub cmbCorte_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCorte.SelectedIndexChanged
        chkSeleccionarTodo_Tallas.Checked = False
        If cmbCorte.SelectedIndex > 0 Then
            If ValidarCamposVacios() = False Then
                btnGuardarFraccion.Enabled = True
                PoblarTablaTallas()
            End If
        Else
            ValidarCamposVacios()
            grdTallas.DataSource = Nothing
            btnGuardarFraccion.Enabled = False
        End If
    End Sub


    Private Sub cmbForro_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbForro.SelectedIndexChanged
        chkSeleccionarTodo_Tallas.Checked = False
        If cmbForro.SelectedIndex > 0 Then
            If ValidarCamposVacios() = False Then
                btnGuardarFraccion.Enabled = True
                PoblarTablaTallas()
            End If
        Else
            ValidarCamposVacios()
            grdTallas.DataSource = Nothing
            btnGuardarFraccion.Enabled = False
        End If
    End Sub


    Private Sub cmbSuela_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSuela.SelectedIndexChanged
        chkSeleccionarTodo_Tallas.Checked = False
        If cmbSuela.SelectedIndex > 0 Then
            If ValidarCamposVacios() = False Then
                btnGuardarFraccion.Enabled = True
                PoblarTablaTallas()
            End If

        Else
            ValidarCamposVacios()
            grdTallas.DataSource = Nothing
            btnGuardarFraccion.Enabled = False
        End If
    End Sub


    Private Sub cmbTipo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTipo.SelectedIndexChanged
        chkSeleccionarTodo_Tallas.Checked = False
        If cmbTipo.SelectedIndex > 0 Then
            If ValidarCamposVacios() = False Then
                btnGuardarFraccion.Enabled = True
                PoblarTablaTallas()
            End If

        Else
            ValidarCamposVacios()
            grdTallas.DataSource = Nothing
            btnGuardarFraccion.Enabled = False
        End If
    End Sub



#End Region

    ''' <summary>
    ''' RECUPERA UN DATATABLE CON LA LISTA DE LAS TALLAS DE UNA CORRIDA EN ESPECIFICO Y, SU RELACION CON ALGUNA FRACCION ARANCELARIA, SÍ ES QUE EXISTE LA RELACION
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub PoblarTablaTallas()
        Dim objBU As New Negocios.FraccionesArtancelariasBU
        Dim objFraccionDetalle As New Entidades.Fracciones_Arancelarias_Detalles
        Dim dtTablaGrid As New DataTable

        objFraccionDetalle.PFamiliaId = cmbFalimias.SelectedValue
        objFraccionDetalle.PForroId = cmbForro.SelectedValue
        objFraccionDetalle.PPielMuestraId = cmbCorte.SelectedValue
        objFraccionDetalle.PSuelaId = cmbSuela.SelectedValue
        objFraccionDetalle.PTipoCategoriaId = cmbTipo.SelectedValue

        Try
            dtTablaGrid = objBU.ListaTallas_Para_FraccionArancelariaDetalles(cmbCorrida.SelectedValue, objFraccionDetalle)

            If dtTablaGrid.Rows.Count = 0 Then
                Mensajes_Y_Alertas("ADVERTENCIA", "No se encontraron registros.")
            Else
                grdTallas.DataSource = dtTablaGrid
            End If

        Catch ex As Exception
            Mensajes_Y_Alertas("ERROR", "Ocurrio un error al momento de consultar Las tallas de la corrida seleccionada. Erro: " + ex.Message)
        End Try



    End Sub


    Private Sub grdTallas_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs)

        Diseno_Agrupacion_Headers(grdTallas, e)
        Diseno_Grid(grdTallas)

        With grdTallas
            .DisplayLayout.Bands(0).Columns("Id_Fraccion_Detalle").Hidden = True
            .DisplayLayout.Bands(0).Columns("Activo").Width = 40
            .DisplayLayout.Bands(0).Columns("Talla").Width = 40
            .DisplayLayout.Bands(0).Columns(" ").Width = 20

            .DisplayLayout.Bands(0).Columns(" ").CellActivation = Activation.AllowEdit
            .DisplayLayout.Bands(0).Columns("Activo").CellActivation = Activation.AllowEdit
            .DisplayLayout.Bands(0).Columns("Talla").CellActivation = Activation.Disabled
            .DisplayLayout.Bands(0).Columns("Fracción Arancelaria").CellActivation = Activation.Disabled


        End With

    End Sub

    Private Sub grdTallas_InitializeLayout_1(sender As Object, e As InitializeLayoutEventArgs) Handles grdTallas.InitializeLayout
        Diseno_Agrupacion_Headers(grdTallas, e)
        Diseno_Grid(grdTallas)

        With grdTallas
            .DisplayLayout.Bands(0).Columns("Id_Fraccion_Detalle").Hidden = True

            .DisplayLayout.Bands(0).Columns("Modificación").Style = ColumnStyle.DateTime
            .DisplayLayout.Bands(0).Columns("Modificación").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit

            .DisplayLayout.Bands(0).Columns(" ").Width = 40
            .DisplayLayout.Bands(0).Columns("Talla").Width = 40
            .DisplayLayout.Bands(0).Columns("Activo").Width = 40
            .DisplayLayout.Bands(0).Columns("Fracción Arancelaria").Width = 350
            .DisplayLayout.Bands(0).Columns("Modificación").Width = 100
            .DisplayLayout.Bands(0).Columns("Usuario").Width = 100
        End With
    End Sub

    ''' <summary>
    ''' LE DA EL DISEÑO DE APARIENCIA AL GRID TALLAS
    ''' </summary>
    ''' <param name="Grid"></param>
    ''' <remarks></remarks>
    Private Sub Diseno_Grid(ByVal Grid As UltraGrid)
        With Grid
            ''.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
            .DisplayLayout.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
            .DisplayLayout.AutoFitStyle = AutoFitStyle.None
            .DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
            .DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            .DisplayLayout.Override.RowSelectorWidth = 35
            .DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
            .DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True
            .DisplayLayout.Override.AllowAddNew = AllowAddNew.No
        End With
    End Sub

    ''' <summary>
    ''' CAMBIA LOS ENCABEZADOS DE INGLES A ESPAÑOL AL GRID TALLAS, ESTO EN SU FUNCIONALIDAD PARA AGRUPAR COLUMNAS
    ''' </summary>
    ''' <param name="Grid"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Diseno_Agrupacion_Headers(ByVal Grid As UltraGrid, e As InitializeLayoutEventArgs)
        Grid.DisplayLayout.GroupByBox.Prompt = "Arrastra columnas para agruparlas."
        Dim valueList As ValueList = e.Layout.FilterOperatorsValueList
        Dim item As ValueListItem
        For Each item In valueList.ValueListItems
            Dim filterOperator As FilterComparisionOperator = DirectCast(item.DataValue, FilterComparisionOperator)
            If FilterComparisionOperator.Contains = filterOperator Then
                item.DisplayText = "CONTIENE"
            ElseIf FilterComparisionOperator.DoesNotEndWith = filterOperator Then
                item.DisplayText = "NO TERMINA CON"
            ElseIf FilterComparisionOperator.DoesNotStartWith = filterOperator Then
                item.DisplayText = "NO COMIENZA CON"
            ElseIf FilterComparisionOperator.EndsWith = filterOperator Then
                item.DisplayText = "TERMINA CON"
            ElseIf FilterComparisionOperator.Equals = filterOperator Then
                item.DisplayText = "IGUAL"
            ElseIf FilterComparisionOperator.GreaterThan = filterOperator Then
                item.DisplayText = "MAYOR QUE"
            ElseIf FilterComparisionOperator.GreaterThanOrEqualTo = filterOperator Then
                item.DisplayText = "MAYOR O IGUAL QUE"
            ElseIf FilterComparisionOperator.LessThan = filterOperator Then
                item.DisplayText = "MENOR QUE"
            ElseIf FilterComparisionOperator.LessThanOrEqualTo = filterOperator Then
                item.DisplayText = "MENOR O IGUAL QUE"
            ElseIf FilterComparisionOperator.NotEquals = filterOperator Then
                item.DisplayText = "DIFERENTE A"
            ElseIf FilterComparisionOperator.StartsWith = filterOperator Then
                item.DisplayText = "COMIENZA CON"
            End If
        Next

        Dim cont As Integer
        For cont = valueList.ValueListItems.Count - 1 To 0 Step -1
            Dim filterOperator As FilterComparisionOperator = DirectCast(valueList.ValueListItems.Item(cont).DataValue, FilterComparisionOperator)
            If FilterComparisionOperator.Custom = filterOperator Then
                valueList.ValueListItems.RemoveAt(cont)
            ElseIf FilterComparisionOperator.DoesNotContain = filterOperator Then
                valueList.ValueListItems.RemoveAt(cont)
            ElseIf FilterComparisionOperator.DoesNotMatch = filterOperator Then
                valueList.ValueListItems.RemoveAt(cont)
            ElseIf FilterComparisionOperator.Like = filterOperator Then
                valueList.ValueListItems.RemoveAt(cont)
            ElseIf FilterComparisionOperator.Match = filterOperator Then
                valueList.ValueListItems.RemoveAt(cont)
            ElseIf FilterComparisionOperator.NotLike = filterOperator Then
                valueList.ValueListItems.RemoveAt(cont)
            ElseIf FilterComparisionOperator.LessThan = filterOperator Then
                valueList.ValueListItems.RemoveAt(cont)
            ElseIf FilterComparisionOperator.LessThanOrEqualTo = filterOperator Then
                valueList.ValueListItems.RemoveAt(cont)
            ElseIf FilterComparisionOperator.GreaterThan = filterOperator Then
                valueList.ValueListItems.RemoveAt(cont)
            ElseIf FilterComparisionOperator.GreaterThanOrEqualTo = filterOperator Then
                valueList.ValueListItems.RemoveAt(cont)
            End If
        Next
    End Sub

#Region "Acciones Grid"

#End Region


    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Dispose()
    End Sub

    Private Sub btnGuardarFraccion_Click(sender As Object, e As EventArgs) Handles btnGuardarFraccion.Click

        If ValidarCamposVacios() Then
            Mensajes_Y_Alertas("ADVERTENCIA", "Falta información por seleccionar")
            Return
        End If
        If ValidarTallasSeleccionadas() = True Then

            If Mensajes_Y_Alertas("CONFIRMACION", "¿ Está seguro de guardar esta Fracción Arancelaria con la combinación de características seleccionadas ?" + vbCrLf + "(Los datos guardados como INACTIVOS no se relacionarán con ningún artículo)") Then


                Dim objBU As New Negocios.FraccionesArtancelariasBU
                Dim lsFracciones As New List(Of Entidades.Fracciones_Arancelarias_Detalles)


                Try
                    For Each row As UltraGridRow In grdTallas.Rows
                        If row.Cells(" ").Value = True Then
                            Dim objFraccionArancelariaDetalles As New Entidades.Fracciones_Arancelarias_Detalles
                            objFraccionArancelariaDetalles.PFraccionArancelariaId = cmbFraccionAAsignar.SelectedValue
                            objFraccionArancelariaDetalles.PFraccionArancelariaDetalleID = 0
                            objFraccionArancelariaDetalles.PFamiliaId = cmbFalimias.SelectedValue
                            objFraccionArancelariaDetalles.PPielMuestraId = cmbCorte.SelectedValue
                            objFraccionArancelariaDetalles.PForroId = cmbForro.SelectedValue
                            objFraccionArancelariaDetalles.PSuelaId = cmbSuela.SelectedValue
                            objFraccionArancelariaDetalles.PTipoCategoriaId = cmbTipo.SelectedValue
                            objFraccionArancelariaDetalles.PActivo = row.Cells("Activo").Value


                            If Not IsDBNull(row.Cells("Id_Fraccion_Detalle").Value) Then
                                objFraccionArancelariaDetalles.PFraccionArancelariaDetalleID = row.Cells("Id_Fraccion_Detalle").Value
                            Else
                                objFraccionArancelariaDetalles.PFraccionArancelariaDetalleID = 0
                            End If
                            objFraccionArancelariaDetalles.PTalla = row.Cells("Talla").Value

                            lsFracciones.Add(objFraccionArancelariaDetalles)

                        End If
                    Next


                    objBU.GuardarFraccionArancelariaDetalles(lsFracciones)

                    Dim objExito As New ExitoForm
                    objExito.StartPosition = FormStartPosition.CenterScreen
                    objExito.mensaje = "Registros guardados con éxito"
                    objExito.ShowDialog()


                Catch ex As Exception
                    Dim objErrores As New ErroresForm
                    objErrores.StartPosition = FormStartPosition.CenterScreen
                    objErrores.mensaje = "Ocurrion un error inesperado : " + ex.Message
                    objErrores.ShowDialog()
                    Return
                End Try

                Me.Dispose()
            End If
        Else
            Mensajes_Y_Alertas("ADVERTENCIA", "No se seleccionaron tallas.")

        End If

    End Sub

    ''' <summary>
    ''' VALIDA SI EXISTEN CAMPOS OBLIGATORIOS SIN SELECCIONAR, SI ES ASI COLOREA DE ROJO LAS ETIQUETAZS DE LOS CAMPOS OBLIGATORIOS SIN SELECCIONAR Y REGRESA UNA VARIABLE DEL 
    ''' TIPO BOLEANO, 1 = CAMPOS VACIOS, 0 = A CAMPOS COMPLETOS
    ''' </summary>
    ''' <returns>VARIABLE DEL TIPO BOLEANO INDICANDO SI EXISTEN CAMPOS VACIOS EN LA PANTALLA</returns>
    ''' <remarks></remarks>
    Private Function ValidarCamposVacios() As Boolean
        ValidarCamposVacios = False

        If cmbTipo.SelectedIndex <= 0 Then
            lblTipo.ForeColor = Color.Red
            ValidarCamposVacios = True
        Else
            lblTipo.ForeColor = Color.Black
        End If

        If cmbCorrida.SelectedIndex <= 0 Then
            lblCorrida.ForeColor = Color.Red
            ValidarCamposVacios = True
        Else
            lblCorrida.ForeColor = Color.Black
        End If

        If cmbCorte.SelectedIndex <= 0 Then
            lblCorte.ForeColor = Color.Red
            ValidarCamposVacios = True
        Else
            lblCorte.ForeColor = Color.Black
        End If

        If cmbFalimias.SelectedIndex <= 0 Then
            lblFamilia.ForeColor = Color.Red
            ValidarCamposVacios = True
        Else
            lblFamilia.ForeColor = Color.Black
        End If

        If cmbSuela.SelectedIndex <= 0 Then
            lblSuela.ForeColor = Color.Red
            ValidarCamposVacios = True
        Else
            lblSuela.ForeColor = Color.Black
        End If


        If cmbForro.SelectedIndex <= 0 Then
            lblForro.ForeColor = Color.Red
            ValidarCamposVacios = True
        Else
            lblForro.ForeColor = Color.Black
        End If

        Return ValidarCamposVacios
    End Function

    ''' <summary>
    ''' VALIDA SI EXISTE AL MENOS UNA TALLA SELECCIONADA EN EL GRID GRDTALLAS
    ''' </summary>
    ''' <returns>VARIABLE DEL TIPO BOLEANO 1 = EXISTEN TALLAS SELECCIONADAS, 0 = NO EXISTEN TALLAS SELECCIONADAS</returns>
    ''' <remarks></remarks>
    Private Function ValidarTallasSeleccionadas() As Boolean

        For Each row As UltraGridRow In grdTallas.Rows
            If row.Cells(" ").Value = True Then
                ValidarTallasSeleccionadas = True
                Return ValidarTallasSeleccionadas
            End If
        Next

        Return ValidarTallasSeleccionadas
    End Function

    ''' <summary>
    ''' METODO QUE MANDA A LLAMAR UN FORMULARIO DE MENSAJE DE TOOLS, SEGUN EL TIPO DE MENSAJE QUE SE HAYA ENVIADO COMO PARAMETRO
    ''' </summary>
    ''' <param name="Tipo">CADENA CON EL NOMBRE DEL TIPO DE MENSAJE A MOSTRAR "ADVERTENCIA" PARA EL FORMULARIO ADVERTENCIAFORM DE TOOLS,
    ''' "EXITO" PARA EL FORMULARIO EXITOFORM DE TOOLS, "ERROR" PARA EL FORMULARIO ERRORESFORM DE TOOLS, "INFORMACION" PARA EL FORMULARIO
    ''' "AVISOFORM" DE TOOLS, Y "CONFIRMACION" PARA EL FORMULARIO "CONFIRMARFORM" </param>
    ''' <param name="Mensaje">MENSAJE QUE SE MOSTRARA EN EL FORMULARIO SELECCIONADO</param>
    ''' <remarks></remarks>
    Private Function Mensajes_Y_Alertas(ByVal Tipo As String, ByVal Mensaje As String)
        If Tipo = "ADVERTENCIA" Then
            Dim objAdvertencia As New Tools.AdvertenciaForm
            objAdvertencia.StartPosition = FormStartPosition.CenterScreen
            objAdvertencia.mensaje = Mensaje
            objAdvertencia.ShowDialog()
        ElseIf Tipo = "EXITO" Then
            Dim objExito As New Tools.ExitoForm
            objExito.StartPosition = FormStartPosition.CenterScreen
            objExito.mensaje = Mensaje
            objExito.ShowDialog()
        ElseIf Tipo = "ERROR" Then
            Dim objErrores As New Tools.ErroresForm
            objErrores.StartPosition = FormStartPosition.CenterScreen
            objErrores.mensaje = Mensaje
            objErrores.ShowDialog()
        ElseIf Tipo = "INFORMACION" Then
            Dim objInformacion As New Tools.AvisoForm
            objInformacion.StartPosition = FormStartPosition.CenterScreen
            objInformacion.mensaje = Mensaje
            objInformacion.ShowDialog()
        ElseIf Tipo = "CONFIRMACION" Then
            Dim objConfirmacion As New Tools.ConfirmarForm
            objConfirmacion.StartPosition = FormStartPosition.CenterScreen
            objConfirmacion.mensaje = Mensaje
            If objConfirmacion.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Return True
            Else
                Return False
            End If
        End If
    End Function


    Private Sub grdTallas_ClickCell(sender As Object, e As ClickCellEventArgs) Handles grdTallas.ClickCell
        If grdTallas.ActiveRow.IsDataRow Then
            If grdTallas.ActiveRow.Cells("Activo").IsActiveCell = True And grdTallas.ActiveRow.Cells("Fracción Arancelaria").Text <> "" Then

            Else
                grdTallas.ActiveRow.Cells("Activo").Activated = False
            End If
        End If
    End Sub

    Private Sub chkSeleccionarTodo_Tallas_CheckedChanged(sender As Object, e As EventArgs) Handles chkSeleccionarTodo_Tallas.CheckedChanged
        For Each row As UltraGridRow In grdTallas.Rows
            row.Cells(" ").Value = chkSeleccionarTodo_Tallas.Checked
        Next
    End Sub

    Private Sub grdTallas_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdTallas.BeforeRowsDeleted
        e.Cancel = True
    End Sub
End Class