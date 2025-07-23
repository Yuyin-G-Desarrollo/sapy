Public Class CatalogoFraccionesArancelariasForm

    Dim objAdvertencia As New Tools.AdvertenciaForm
    Dim objBU As New Negocios.CatalogoFraccionesArancelariasBU
    Dim objAviso As New Tools.AvisoForm

    Private Sub CatalogoFraccionesArancelariasForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Location = New Point(0, 0)

    End Sub

#Region "REGION BOTONES"

    ''' <summary>
    ''' BTNARRIBA, REDUCE LA ALTURA DE EL PANEL ACCIONES PARA OCULTAR SUS BOTONES
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        pnlAcciones.Height = 30
    End Sub


    ''' <summary>
    ''' AUMENTA LA ALTURA DEL PANEL ACCIONES PARA MOSTRAR SUS BOTONES
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        pnlAcciones.Height = 130
    End Sub

    ''' <summary>
    ''' LIMPIA LOS CONTROLES(FILTROS) Y LAS VARIABLES GENERALES
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        grdListaFraccionesArancelarias.DataSource = Nothing
        txtCodigo.Text = ""
        txtNombre.Text = ""
        rdoSi.Checked = True
    End Sub

    ''' <summary>
    ''' BTNBUSCAR, CONSULTA LA LISTA DE LAS FRACCIONES ARANCELARIAS
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        ListaFraccionesArancelarias(LTrim(RTrim(txtCodigo.Text)), LTrim(RTrim(txtNombre.Text)), rdoSi.Checked)
    End Sub


#End Region



    Private Sub ListaFraccionesArancelarias(ByVal Codigo As String, ByVal Nombre As String, ByVal Activo As Boolean)

        Dim dtListaFracciones As New DataTable

        dtListaFracciones = objBU.Lista_Fracciones_Arancelarias(Codigo, Nombre, Activo)

        If dtListaFracciones.Rows.Count > 0 Then
            grdListaFraccionesArancelarias.DataSource = dtListaFracciones
            grdListaFraccionesArancelarias.DisplayLayout.Bands(0).Columns("Código").Width = 80
        Else
            grdListaFraccionesArancelarias.DataSource = Nothing
            objAviso.mensaje = "No se encontro información."
            objAviso.StartPosition = FormStartPosition.CenterScreen
            objAviso.ShowDialog()
        End If
    End Sub

    Private Sub grdListaFraccionesArancelarias_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles grdListaFraccionesArancelarias.InitializeLayout
        With grdListaFraccionesArancelarias
            'OCULTAMOS COLUMNAS
            .DisplayLayout.Bands(0).Columns("ID").Hidden = True
            .DisplayLayout.Bands(0).Columns("Activo").Hidden = True


            ''DAMOS FORMATO
            .DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn
            .DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
            .DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True
            .DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
            .DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
            .DisplayLayout.Override.RowSelectorWidth = 35
            .DisplayLayout.Override.RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.VisibleIndex



            ''
            .DisplayLayout.Bands(0).Columns("Código").Width = 80
            .DisplayLayout.Bands(0).Columns("Código").Width = 70

        End With
    End Sub

    Private Sub btnAltas_Click(sender As Object, e As EventArgs) Handles btnAltas.Click
        Dim objAltasBajas As New AgregarFraccionesArancelariasForm
        objAltasBajas.StartPosition = FormStartPosition.CenterScreen
        objAltasBajas.Bandera_Agregar_Editar = True
        objAltasBajas.ShowDialog()
        ListaFraccionesArancelarias(txtCodigo.Text, txtNombre.Text, rdoSi.Checked)
    End Sub


    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        Dim objAdvertencia As New Tools.AdvertenciaForm

        If grdListaFraccionesArancelarias.Selected.Rows.Count = 0 Then
            objAdvertencia.mensaje = "Seleccione una Fraccion Arancelara antes de dar click en 'Editar'."
            objAdvertencia.StartPosition = FormStartPosition.CenterScreen
            objAdvertencia.ShowDialog()
        Else
            If grdListaFraccionesArancelarias.ActiveRow.IsDataRow Then
                If grdListaFraccionesArancelarias.Selected.Rows.Count > 1 Then
                    objAdvertencia.mensaje = "Seleccione una fracción Arancelaria a la vez para poder editar los registros."
                    objAdvertencia.StartPosition = FormStartPosition.CenterScreen
                    objAdvertencia.ShowDialog()
                Else
                    Dim objFracciones As New Entidades.Fracciones_Arancelarias
                    objFracciones.PIdPraccionArancelaria = grdListaFraccionesArancelarias.ActiveRow.Cells("ID").Value
                    objFracciones.PNombre = grdListaFraccionesArancelarias.ActiveRow.Cells("Nombre").Value
                    objFracciones.PCodigo = grdListaFraccionesArancelarias.ActiveRow.Cells("Código").Value
                    objFracciones.PActivo = grdListaFraccionesArancelarias.ActiveRow.Cells("Activo").Value

                    Dim objAltasBajas As New AgregarFraccionesArancelariasForm
                    objAltasBajas.StartPosition = FormStartPosition.CenterScreen
                    objAltasBajas.Bandera_Agregar_Editar = False
                    objAltasBajas.objFracciones = objFracciones
                    objAltasBajas.ShowDialog()

                    ListaFraccionesArancelarias(txtCodigo.Text, txtNombre.Text, rdoSi.Checked)
                End If

            Else
                objAdvertencia.mensaje = "Seleccione una fraccion antes de precionar 'Editar'."
                objAdvertencia.StartPosition = FormStartPosition.CenterScreen
                objAdvertencia.ShowDialog()
            End If
        End If



    End Sub
End Class