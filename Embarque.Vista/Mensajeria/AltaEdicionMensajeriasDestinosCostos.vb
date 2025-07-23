Imports Infragistics
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win

Public Class AltaEdicionMensajeriasDestinosCostos

    Public Destinos_SinPaqueteria As Boolean ''valor true cuando esta ventana se invoca desde la ventana de destinos sin paqueteria
    Public IdPais As Integer
    Public IdEstado As Integer
    Public IdCiudad As Integer
    Public IdPoblacion As Integer


    Private Sub AltaEdicionMensajeriasDestinosCostos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmbPais = Tools.Controles.ComboPaisesMayusculas(cmbPais)
        cmbProveedor = ControlesEmbarque.ComboProveedores(cmbProveedor)
        cmbReenbarque = ControlesEmbarque.ComboTipoEmbarque(cmbReenbarque)
        cmbUnidad = ControlesEmbarque.ComboTipoUnidad(cmbUnidad)

        If Destinos_SinPaqueteria = True Then
            If IdPoblacion > 0 Then
                chkPoblacion.Checked = True
            End If

            cmbPais.SelectedValue = IdPais
            cmbEstado.SelectedValue = IdEstado
            cmbCiudad.SelectedValue = IdCiudad
            cmbPoblacion.SelectedValue = IdPoblacion
        End If

    End Sub


    Private Sub chkPoblacion_CheckedChanged(sender As Object, e As EventArgs) Handles chkPoblacion.CheckedChanged
        chkPoblacion.ForeColor = Color.Black

        If chkPoblacion.Checked = True Then
            cmbPoblacion.Visible = True
        Else
            cmbPoblacion.Visible = False
        End If
    End Sub



    Public Sub CargarDatos()
        Dim idProveedor, idCiudad, idEstado, idPais, idPoblacion As Int32

        If cmbProveedor.SelectedIndex > 0 Then
            idProveedor = cmbProveedor.SelectedValue
        Else
            idProveedor = 0
        End If

        If cmbCiudad.SelectedIndex > 0 Then
            idCiudad = cmbCiudad.SelectedValue
        Else
            idCiudad = 0
        End If
        If cmbEstado.SelectedIndex > 0 Then
            idEstado = cmbEstado.SelectedValue
        Else
            idEstado = 0
        End If
        If cmbPais.SelectedIndex > 0 Then
            idPais = cmbPais.SelectedValue
        Else
            idPais = 0
        End If
        If cmbPoblacion.SelectedIndex > 0 And chkPoblacion.Checked Then
            idPoblacion = cmbPoblacion.SelectedValue
        Else
            idPoblacion = 0
        End If

        Dim objbu As New Negocios.MensajeriaDestinoCostos
        Dim tabla As New List(Of Entidades.Mensajeria)
        tabla = objbu.ConsultarMensajeriasCostosProveedor(idProveedor, idCiudad, idEstado, idPais, idPoblacion, 0)
        grdDestinos.DataSource = tabla

    End Sub


    Private Function ValidarCamposVacios() As Boolean
        ValidarCamposVacios = False

        If cmbProveedor.SelectedIndex <= 0 Then
            ValidarCamposVacios = True
        ElseIf cmbPais.SelectedIndex <= 0 Then
            ValidarCamposVacios = True
        ElseIf cmbCiudad.SelectedIndex <= 0 Then
            ValidarCamposVacios = True
        ElseIf cmbPoblacion.SelectedIndex <= 0 And chkPoblacion.Checked Then
            ValidarCamposVacios = True
        End If

        Return ValidarCamposVacios
    End Function


#Region "Cambio de Valores en combos"

    Private Sub cmbProveedor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbProveedor.SelectedIndexChanged
        Try
            If ValidarCamposVacios() = False Then
                CargarDatos()
            Else
                grdDestinos.DataSource = Nothing
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbPais_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPais.SelectedIndexChanged
        Try
            If Not IsNothing(cmbPais.DataSource) Then
                If cmbPais.SelectedIndex > 0 Then
                    cmbEstado = Tools.Controles.ComboEstados(cmbEstado, cmbPais.SelectedValue)
                ElseIf cmbPais.SelectedIndex = 0 Then
                    cmbEstado.DataSource = Nothing
                End If

                grdDestinos.DataSource = Nothing

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cboxEstado_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbEstado.SelectedIndexChanged
        Try
            If Not IsNothing(cmbEstado.DataSource) Then
                If cmbEstado.SelectedIndex > 0 Then
                    cmbCiudad = Tools.Controles.ComboCiudadesMayusculas(cmbCiudad, cmbEstado.SelectedValue)
                    If chkPoblacion.Checked Then
                        grdDestinos.DataSource = Nothing
                    Else
                        CargarDatos()
                    End If
                Else
                    cmbCiudad.DataSource = Nothing
                    grdDestinos.DataSource = Nothing
                End If


            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cboxCiudad_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCiudad.SelectedIndexChanged
        Try
            If Not IsNothing(cmbCiudad.DataSource) Then
                If chkPoblacion.Checked Then
                    If cmbCiudad.SelectedIndex > 0 Then
                        cmbPoblacion = Tools.Controles.ComboPoblaciones(cmbPoblacion, cmbCiudad.SelectedValue)
                    Else
                        cmbPoblacion.DataSource = Nothing
                    End If
                    grdDestinos.DataSource = Nothing
                Else
                    If cmbCiudad.SelectedIndex > 0 Then
                        CargarDatos()
                        cmbPoblacion = Tools.Controles.ComboPoblaciones(cmbPoblacion, cmbCiudad.SelectedValue)
                    Else
                        grdDestinos.DataSource = Nothing
                    End If
                End If
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub cmbPoblacion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPoblacion.SelectedIndexChanged
        If cmbPoblacion.SelectedIndex > 0 And chkPoblacion.Checked Then
            CargarDatos()
        Else
            grdDestinos.DataSource = Nothing
        End If
    End Sub

#End Region

#Region "Grid"

    Private Sub grdDestinos_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdDestinos.InitializeLayout

        grdDestinos.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdDestinos.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.SortMulti
        grdDestinos.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdDestinos.DisplayLayout.Override.RowSelectorWidth = 35
        grdDestinos.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True


        With grdDestinos.DisplayLayout.Bands(0)

            .PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)


            .Columns("PIdDestinoMensajeria").Hidden = True
            .Columns("PIdPais").Hidden = True
            .Columns("PIdEstado").Hidden = True
            .Columns("PIdCiudad").Hidden = True
            .Columns("PIdProveedor").Hidden = True
            .Columns("PIdPoblacion").Hidden = True


            .Columns("PNombreCiudadPoblacion").Hidden = True
            .Columns("PIDCostoMensajeria").Hidden = True
            .Columns("PFechaInicioVigencia").Hidden = True
            .Columns("PFechaFinVigencia").Hidden = True

            .Columns("PConsecutivo").Header.Caption = "#"
            .Columns("PConsecutivo").Header.VisiblePosition = 0
            .Columns("PConsecutivo").CellActivation = Activation.NoEdit
            .Columns("PConsecutivo").AutoSizeMode = Infragistics.Win.UltraWinGrid.ColumnAutoSizeMode.AllRowsInBand

            .Columns("PNombreProveedor").Header.Caption = "Mensajería"
            .Columns("PNombreProveedor").Header.VisiblePosition = 2
            .Columns("PNombreProveedor").CellActivation = Activation.NoEdit
            .Columns("PNombreProveedor").AutoSizeMode = Infragistics.Win.UltraWinGrid.ColumnAutoSizeMode.AllRowsInBand

            .Columns("PNombrePoblacion").Header.Caption = "Población"
            .Columns("PNombrePoblacion").Header.VisiblePosition = 3
            .Columns("PNombrePoblacion").CellActivation = Activation.NoEdit

            .Columns("PNombreCiudad").Header.Caption = "Ciudad"
            .Columns("PNombreCiudad").Header.VisiblePosition = 4
            .Columns("PNombreCiudad").CellActivation = Activation.NoEdit

            .Columns("PAbrevEstado").Header.Caption = "Estado"
            .Columns("PAbrevEstado").Header.VisiblePosition = 5
            .Columns("PAbrevEstado").CellActivation = Activation.NoEdit

            .Columns("PAbrevPais").Header.Caption = "País"
            .Columns("PAbrevPais").Header.VisiblePosition = 6
            .Columns("PAbrevPais").CellActivation = Activation.NoEdit

            .Columns("PNombreUnidad").Header.Caption = "Unidad"
            .Columns("PNombreUnidad").Header.VisiblePosition = 9
            .Columns("PNombreUnidad").CellActivation = Activation.NoEdit

            .Columns("PReembarque").Header.Caption = "Reembarque"
            .Columns("PReembarque").Header.VisiblePosition = 10
            .Columns("PReembarque").CellActivation = Activation.NoEdit

            .Columns("PNombreCiudadPoblacion").Header.Caption = "Ciudad Poblacion"

            .Columns("PConsecutivo").CellActivation = Activation.NoEdit
            .Columns("PConsecutivo").CellActivation = Activation.NoEdit

            .Columns("PDiasMinEntregas").Header.Caption = "D. Mín. Entrega"
            .Columns("PDiasMinEntregas").Header.VisiblePosition = 11
            .Columns("PDiasMinEntregas").CellActivation = Activation.NoEdit
            .Columns("PDiasMinEntregas").CellAppearance.TextHAlign = Win.HAlign.Right

            .Columns("PDiasMaxEntregas").Header.Caption = "D. Máx. Entrega"
            .Columns("PDiasMaxEntregas").CellActivation = Activation.NoEdit
            .Columns("PDiasMaxEntregas").Header.VisiblePosition = 12
            .Columns("PDiasMaxEntregas").CellAppearance.TextHAlign = Win.HAlign.Right

            .Columns("PFechaAlta").Header.Caption = "Modificación"
            .Columns("PFechaAlta").Style = ColumnStyle.DateTime
            .Columns("PFechaAlta").Header.VisiblePosition = 13
            .Columns("PFechaAlta").CellActivation = Activation.NoEdit
            .Columns("PFechaAlta").Style = ColumnStyle.DateTime

            .Columns("PUsuario").Header.Caption = "Usuario"
            .Columns("PUsuario").Header.VisiblePosition = 14
            .Columns("PUsuario").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit


            .Columns("PCostoUnidad").CellAppearance.TextHAlign = Win.HAlign.Right
            .Columns("PCostoUnidad").Header.VisiblePosition = 8
            .Columns("PCostoUnidad").CellActivation = Activation.NoEdit
            .Columns("PCostoUnidad").Header.Caption = "Costo"
            .Columns("PCostoUnidad").Format = "N2"
            .Columns("PCostoUnidad").MaskInput = "nnn,nnn,nnn.nn"

            .Columns("PIDCostoMensajeria").CellActivation = Activation.NoEdit

            .Columns("PActivo").Header.Caption = "  Activo"
            .Columns("PActivo").Header.VisiblePosition = 15
            .Columns("PActivo").CellActivation = Activation.NoEdit

        End With

    End Sub


    Private Sub grdDestinos_BeforeRowInsert(sender As Object, e As BeforeRowInsertEventArgs) Handles grdDestinos.BeforeRowInsert
        e.Cancel = True
    End Sub


    Private Sub grdDestinos_BeforeRowUpdate(sender As Object, e As CancelableRowEventArgs) Handles grdDestinos.BeforeRowUpdate
        e.Cancel = True
    End Sub


#End Region

    Private Function ValidarCamposVacios_ParaGuardardoDeInformacion() As Boolean
        ValidarCamposVacios_ParaGuardardoDeInformacion = False

        If cmbProveedor.SelectedIndex > 0 Then
            lblProveedor.ForeColor = Color.Black
        Else
            lblProveedor.ForeColor = Color.Red
            ValidarCamposVacios_ParaGuardardoDeInformacion = True
        End If

        If cmbCiudad.SelectedIndex > 0 Then
            lblCiudad.ForeColor = Color.Black
        Else
            lblCiudad.ForeColor = Color.Red
            ValidarCamposVacios_ParaGuardardoDeInformacion = True
        End If

        If cmbEstado.SelectedIndex > 0 Then
            lblEstado.ForeColor = Color.Black
        Else
            lblEstado.ForeColor = Color.Red
            ValidarCamposVacios_ParaGuardardoDeInformacion = True
        End If

        If cmbPais.SelectedIndex > 0 Then
            lblPais.ForeColor = Color.Black
        Else
            lblPais.ForeColor = Color.Red
            ValidarCamposVacios_ParaGuardardoDeInformacion = True
        End If

        If chkPoblacion.Checked = True Then
            If cmbPoblacion.SelectedIndex > 0 Then
                chkPoblacion.ForeColor = Color.Black
            Else
                chkPoblacion.ForeColor = Color.Red
                ValidarCamposVacios_ParaGuardardoDeInformacion = True
            End If
        End If


        If cmbUnidad.SelectedIndex > 0 Then
            lblTipoUnidad.ForeColor = Color.Black
        Else
            lblTipoUnidad.ForeColor = Color.Red
            ValidarCamposVacios_ParaGuardardoDeInformacion = True
        End If

        If cmbReenbarque.SelectedIndex > 0 Then
            lblReembarque.ForeColor = Color.Black
        Else
            lblReembarque.ForeColor = Color.Red
            ValidarCamposVacios_ParaGuardardoDeInformacion = True
        End If

        If txtCostoUnidad.Text.Length > 0 Then
            lblCostoUnidad.ForeColor = Color.Black
        Else
            lblCostoUnidad.ForeColor = Color.Red
            ValidarCamposVacios_ParaGuardardoDeInformacion = True
        End If


        Return ValidarCamposVacios_ParaGuardardoDeInformacion

    End Function


    Private Sub btnGuardarCosto_Click(sender As Object, e As EventArgs) Handles btnGuardarCosto.Click
        Try
            If ValidarCamposVacios_ParaGuardardoDeInformacion() = False Then

                If numMinEntrega.Value > numMaxEntrega.Value Then
                    Dim objAdvertencia As New Tools.AdvertenciaForm
                    objAdvertencia.mensaje = "El valor de días mínimos de entrega no puede ser mayor a días máximos de entrega."
                    objAdvertencia.StartPosition = FormStartPosition.CenterScreen
                    objAdvertencia.ShowDialog()
                    Return
                Else
                    Dim objMensajeria As New Entidades.Mensajeria
                    Dim objBU As New Negocios.MensajeriaDestinoCostos
                    Dim ListValidacion As New List(Of Entidades.Mensajeria)
                    Dim idProveedor, idCiudad, idEstado, idPais, idPoblacion As Int32
                    Dim IDCOSTO As New Int32

                    idProveedor = cmbProveedor.SelectedValue
                    idPais = cmbPais.SelectedValue
                    idEstado = cmbEstado.SelectedValue
                    idCiudad = cmbCiudad.SelectedValue
                    If chkPoblacion.Checked Then
                        idPoblacion = cmbPoblacion.SelectedValue
                    End If


                    ListValidacion = objBU.ValidarCostoDestino(idProveedor, idCiudad, idEstado, idPais, idPoblacion, cmbUnidad.SelectedValue)
                    For Each mensajeria As Entidades.Mensajeria In ListValidacion
                        IDCOSTO = mensajeria.PIDCostoMensajeria
                    Next

                    If ListValidacion.Count > 0 Then
                        Dim objAvertencia As New Tools.AdvertenciaForm
                        objAvertencia.mensaje = "Ya se encuentra un registro."
                        objAvertencia.StartPosition = FormStartPosition.CenterScreen
                        objAvertencia.ShowDialog()

                        For Each row As Infragistics.Win.UltraWinGrid.UltraGridRow In grdDestinos.Rows
                            If row.Cells("PIDCostoMensajeria").Value = IDCOSTO Then
                                row.CellAppearance.BackColor = Color.GreenYellow
                            End If
                        Next

                    Else

                        objMensajeria.PCostoUnidad = CDbl(txtCostoUnidad.Text)
                        objMensajeria.PDiasMinEntregas = numMinEntrega.Value
                        objMensajeria.PDiasMaxEntregas = numMaxEntrega.Value
                        objMensajeria.PFechaInicioVigencia = dateFechaVigenciaInicio.Value
                        objMensajeria.PFechaFinVigencia = dateFechaVigenciaFin.Value
                        objMensajeria.PReembarque = CInt(cmbReenbarque.SelectedValue)
                        objMensajeria.PNombreUnidad = CInt(cmbUnidad.SelectedValue)

                        objMensajeria.PIdPais = idPais
                        objMensajeria.PIdEstado = idEstado
                        objMensajeria.PIdCiudad = cmbCiudad.SelectedValue

                        If chkPoblacion.Checked Then
                            objMensajeria.PIdPoblacion = cmbPoblacion.SelectedValue
                        Else
                            objMensajeria.PIdPoblacion = 0
                        End If

                        Dim idDestino As Int32
                        idDestino = objBU.ObtenerIDDestinoMensajeria(cmbProveedor.SelectedValue, idCiudad, idPoblacion)

                        If idDestino = 0 Then
                            objBU.InsertDestino(cmbProveedor.SelectedValue, idCiudad, idPoblacion)

                            idDestino = objBU.ObtenerIDDestinoMensajeria(cmbProveedor.SelectedValue, idCiudad, idPoblacion)
                        End If

                        objMensajeria.PIdDestinoMensajeria = idDestino
                        objBU.AltaNuevoCostoDestinoMensajeria(objMensajeria)


                        CargarDatos()
                        cmbUnidad.SelectedIndex = 0
                        cmbReenbarque.SelectedIndex = 0
                        txtCostoUnidad.Text = ""
                        numMinEntrega.Value = 0
                        numMaxEntrega.Value = 0
                    End If

                End If
            Else
                Dim objAdvertencia As New Tools.AdvertenciaForm
                objAdvertencia.StartPosition = FormStartPosition.CenterScreen
                objAdvertencia.mensaje = "Campos vacíos."
                objAdvertencia.ShowDialog()
            End If

        Catch ex As Exception
            Dim objErrores As New Tools.ErroresForm
            objErrores.mensaje = "Ocurrio un errore inesperado. Error: " + ex.Message
            objErrores.StartPosition = FormStartPosition.CenterScreen
            objErrores.ShowDialog()
        End Try

    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub



End Class