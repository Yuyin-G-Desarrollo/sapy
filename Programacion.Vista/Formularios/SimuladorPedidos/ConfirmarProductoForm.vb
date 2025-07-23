Imports Programacion.Negocios
Imports Infragistics.Win.UltraWinGrid
Imports Tools

Public Class ConfirmarProductoForm
    Dim vHormasCapacidadesBU As HormasCapacidadesBU
#Region "EntidadesFormulario"
    Dim naveDestino As String
    Dim idNaveDestino As Integer
    Dim horma As String
    Dim idHorma As Integer
    Dim corrida As String
    Dim idCorrida As Integer
    Dim idProducto As Integer
    Dim idProductoEstilo As Integer
    Dim ordenDestino As Integer
    Dim ordendestinoMaximo As Integer
    Dim productosSeleccionados As Integer
    Dim tablaProductos As DataTable
    Public Property vTablaProductos As DataTable
        Get
            Return tablaProductos
        End Get
        Set(value As DataTable)
            tablaProductos = value
        End Set
    End Property
    Public Property vNaveDestino As String
        Get
            Return naveDestino
        End Get
        Set(value As String)
            naveDestino = value
        End Set
    End Property
    Public Property vIdNaveDestino As Integer
        Get
            Return idNaveDestino
        End Get
        Set(value As Integer)
            idNaveDestino = value
        End Set
    End Property
    Public Property vHorma As String
        Get
            Return horma
        End Get
        Set(value As String)
            horma = value
        End Set
    End Property
    Public Property vIdHorma As Integer
        Get
            Return idHorma
        End Get
        Set(value As Integer)
            idHorma = value
        End Set
    End Property
    Public Property vCorrida As String
        Get
            Return corrida
        End Get
        Set(value As String)
            corrida = value
        End Set
    End Property
    Public Property vOrdenDestino As Integer
        Get
            Return ordenDestino
        End Get
        Set(value As Integer)
            ordenDestino = value
        End Set
    End Property
    Public Property vOrdendestinoMaximo As Integer
        Get
            Return ordendestinoMaximo
        End Get
        Set(value As Integer)
            ordendestinoMaximo = value
        End Set
    End Property
    Public Property vIdCorrida As Integer
        Get
            Return idCorrida
        End Get
        Set(value As Integer)
            idCorrida = value
        End Set
    End Property
    Public Property vIdProducto As Integer
        Get
            Return idProducto
        End Get
        Set(value As Integer)
            idProducto = value
        End Set
    End Property
    Public Property vIdProductoEstilo As Integer
        Get
            Return idProductoEstilo
        End Get
        Set(value As Integer)
            idProductoEstilo = value
        End Set
    End Property
    Public Property vProductosSeleccionados As Integer
        Get
            Return productosSeleccionados
        End Get
        Set(value As Integer)
            productosSeleccionados = value
        End Set
    End Property
#End Region
#Region "Mensajes Programas"
    Public Sub mensajeAdvertencia(ByVal titulo As String, ByVal mensaje As String)
        Dim vAdvertenciaForm As New AdvertenciaForm
        vAdvertenciaForm.Text = titulo
        vAdvertenciaForm.mensaje = mensaje
        vAdvertenciaForm.ShowDialog()
        vAdvertenciaForm = Nothing
    End Sub
    Public Sub mensajeError(ByVal titulo As String, ByVal mensaje As String)
        Dim vErrorForm As New ErroresForm
        vErrorForm.Text = titulo
        vErrorForm.mensaje = mensaje
        vErrorForm.ShowDialog()
        vErrorForm = Nothing
    End Sub
    Public Sub mensajeExito(ByVal titulo As String, ByVal mensaje As String)
        Dim vExitoForm As New ExitoForm
        vExitoForm.Text = titulo
        vExitoForm.mensaje = mensaje
        vExitoForm.ShowDialog()
        vExitoForm = Nothing
    End Sub
    Public Function mensajeConfirmar(ByVal titulo As String, mensaje As String) As DialogResult
        Dim vConfirmarForm As New ConfirmarForm
        Dim vDialogResult As New DialogResult
        vConfirmarForm.Text = titulo
        vConfirmarForm.mensaje = mensaje
        vDialogResult = vConfirmarForm.ShowDialog
        Return vDialogResult
    End Function
#End Region

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        AsignarProductosNaves()
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        If mensajeConfirmar("Capacidades de horma y producto", "Si cierra esta ventana no se guardarán los cambios ¿ Desea cerrar ?") = Windows.Forms.DialogResult.OK Then
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()
        Else
            Me.DialogResult = Windows.Forms.DialogResult.None
        End If
    End Sub

    Public Sub inicializarParametros()
        lblCorrida.Text = vCorrida
        lblHorma.Text = vHorma
        lblNaveDestino.Text = vNaveDestino
        txtOrden.Value = If(vOrdenDestino = 0, 1, vOrdenDestino)
        lblTotalProductos.Text = vProductosSeleccionados
        grdProductosSeleccionados.DataSource = vTablaProductos
        formatoTabla()
    End Sub

    Public Sub formatoTabla()

        Dim band As Infragistics.Win.UltraWinGrid.UltraGridBand = Me.grdProductosSeleccionados.DisplayLayout.Bands(0)
        With band
            .Columns("Seleccion").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("prna_prnaID").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("ModSicy").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Marca").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Coleccion").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Modelo").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Piel").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Color").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Corrida").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Horma").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("prna_muestras").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("prna_capacidad").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("prna_orden").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("v_hormaID").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("prna_productoID").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("prna_productoEstiloID").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("prna_tallaID").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("nave_nombre").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("prna_naveID").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit



            .Columns("prna_productoID").Hidden = True '
            .Columns("prna_productoEstiloID").Hidden = True
            .Columns("prna_tallaID").Hidden = True
            .Columns("ModSicy").Hidden = True
            .Columns("prna_prnaID").Hidden = True
            .Columns("prna_naveID").Hidden = True
            .Columns("v_hormaID").Hidden = True
            .Columns("nave_nombre").Hidden = True
            .Columns("prna_capacidad").Hidden = True
            .Columns("prna_orden").Hidden = True
            .Columns("Horma").Hidden = True
            .Columns("prna_muestras").Hidden = True
            .Columns("Seleccion").Hidden = True

            .Columns("Marca").Header.VisiblePosition = 0
            .Columns("Coleccion").Header.VisiblePosition = 1
            .Columns("Modelo").Header.VisiblePosition = 2
            .Columns("Piel").Header.VisiblePosition = 3
            .Columns("Color").Header.VisiblePosition = 4
            .Columns("Corrida").Header.VisiblePosition = 5


            .Columns("Coleccion").Header.Caption = "Colección"
            .PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)

        End With

        grdProductosSeleccionados.DisplayLayout.PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        grdProductosSeleccionados.DisplayLayout.Override.RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.VisibleIndex
        grdProductosSeleccionados.DisplayLayout.Override.RowSelectorWidth = 35
        grdProductosSeleccionados.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
        grdProductosSeleccionados.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
        grdProductosSeleccionados.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns

    End Sub

    Public Sub AsignarProductosNaves()
        vHormasCapacidadesBU = New HormasCapacidadesBU
        If mensajeConfirmar("Capacidades de horma y producto", "¿ Desea asignar los productos seleccionados a la nave seleccionada ?") = Windows.Forms.DialogResult.OK Then

            If txtOrden.Value > 0 And txtOrden.Value < vOrdendestinoMaximo + 1 Then
                If vHormasCapacidadesBU.verificarHormaNave(vIdNaveDestino, vIdHorma, vIdCorrida) Then
                    vHormasCapacidadesBU.actualizarHormaNave(vIdNaveDestino, vIdHorma, vIdCorrida, txtCapacidadProducto.Value)
                Else
                    vHormasCapacidadesBU.AsigarHorma(vIdNaveDestino, vIdHorma, vIdCorrida, txtCapacidadProducto.Value)
                End If
                For Each rowGrd As UltraGridRow In grdProductosSeleccionados.Rows
                    If vHormasCapacidadesBU.verificarProductoAsignar(vIdNaveDestino, rowGrd.Cells("prna_productoID").Value, rowGrd.Cells("prna_productoEstiloID").Value, rowGrd.Cells("prna_tallaID").Value) Then
                        vHormasCapacidadesBU.actualizarProductoAsignar(vIdNaveDestino, rowGrd.Cells("prna_productoID").Value, rowGrd.Cells("prna_productoEstiloID").Value, rowGrd.Cells("prna_tallaID").Value, txtCapacidadProducto.Value, txtOrden.Value)
                    Else
                        vHormasCapacidadesBU.AsignarProducto(vIdNaveDestino, rowGrd.Cells("prna_productoID").Value, rowGrd.Cells("prna_productoEstiloID").Value, rowGrd.Cells("prna_tallaID").Value, txtCapacidadProducto.Value, txtOrden.Value)
                    End If
                Next

                mensajeExito("Hormas y Productos por nave", "Productos asignados con éxito")
                Me.DialogResult = Windows.Forms.DialogResult.OK
            Else
                mensajeAdvertencia("Capacidades de horma y producto", "El orden debe de ser mayor a 0 y menor a " + (vOrdendestinoMaximo + 1).ToString)
                Me.DialogResult = Windows.Forms.DialogResult.None
            End If


        Else
            Me.DialogResult = Windows.Forms.DialogResult.None
        End If

    End Sub



    Private Sub ConfirmarProductoForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        inicializarParametros()
    End Sub
End Class