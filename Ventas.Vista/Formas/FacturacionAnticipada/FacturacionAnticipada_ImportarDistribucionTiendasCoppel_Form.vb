Imports DevExpress
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Grid

Public Class FacturacionAnticipada_ImportarDistribucionTiendasCoppel_Form
#Region "Variables"
    Private distribuciones As New List(Of Entidades.DistribucionPedidoCoppel)
    Private objBu As New Negocios.FacturacionAnticipadaCoppelBU
    Private pedidoSAY As Integer
    Private pedidoSICY As Integer
    Private paresPedido As Integer
    Private paresPendientes As Integer
    Private paresArchivo As Integer
    Private ordenCompra As String
    Private cliente As String
    Private tabArticulosSinEmpaque As TabPage
    Private distribucionesArticulosSinEmpaque As New DataTable

    Private mdiForm As Form
    Private colorErrorArticulo As Color = Color.FromArgb(255, 192, 203)
#End Region

    Private Sub FacturacionAnticipada_ImportarDistribucionTiendasCoppel_Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'MostrarInformacionPedido()
    End Sub

    Private Sub DisenioGrid()

        Tools.DiseñoGrid.DiseñoBaseGridSinBestFit(grdDatosImportacionDistribucion)

        For i = 0 To grdDatosImportacionDistribucion.Columns.Count - 1
            grdDatosImportacionDistribucion.Columns(i).OptionsColumn.AllowEdit = False
        Next

        grdDatosImportacionDistribucion.Columns("DistribucionPedidoID").Visible = False
        grdDatosImportacionDistribucion.Columns("DistribucionPedidoDetalleID").Visible = False
        grdDatosImportacionDistribucion.Columns("Cliente").Visible = False
        grdDatosImportacionDistribucion.Columns("PedidoSAY").Visible = False
        grdDatosImportacionDistribucion.Columns("PedidoSICY").Visible = False
        grdDatosImportacionDistribucion.Columns("TiendaEmbarqueId").Visible = False
        grdDatosImportacionDistribucion.Columns("EstatusArchivo").Visible = False
        grdDatosImportacionDistribucion.Columns("NombreTiendaEmbarque").Visible = False

        grdDatosImportacionDistribucion.Columns("CodigoRapidoCliente").Caption = "Código"
        grdDatosImportacionDistribucion.Columns("CantidadPedida").Caption = "Cant. Pedida"
        grdDatosImportacionDistribucion.Columns("CantidadSurtida").Caption = "Cant. Surtida"
        grdDatosImportacionDistribucion.Columns("OrdenCliente").Caption = "OC"
        grdDatosImportacionDistribucion.Columns("OrdenTrabajoID").Caption = "Orden Trabajo"
        grdDatosImportacionDistribucion.Columns("OrdenTrabajoID").Visible = False

        grdDatosImportacionDistribucion.Columns("Importe").DisplayFormat.FormatType = Utils.FormatType.Numeric
        grdDatosImportacionDistribucion.Columns("Importe").DisplayFormat.FormatString = "c0"
        grdDatosImportacionDistribucion.Columns("IVA").DisplayFormat.FormatType = Utils.FormatType.Numeric
        grdDatosImportacionDistribucion.Columns("IVA").DisplayFormat.FormatString = "c0"


        'grdDatosImportacionDistribucion.Columns("FechaDocumento").Width = 95
        'grdDatosImportacionDistribucion.Columns("TipoComprobante").Width = 105
        'grdDatosImportacionDistribucion.Columns("TipoEmpaque").Width = 105

        'grdDatosImportacionDistribucion.Columns("Cliente").OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains

        'grdDatosImportacionDistribucion.Columns("Pares").DisplayFormat.FormatType = Utils.FormatType.Numeric
        'grdDatosImportacionDistribucion.Columns("Pares").DisplayFormat.FormatString = "###,###"
        'grdDatosImportacionDistribucion.Columns("Importe").DisplayFormat.FormatType = Utils.FormatType.Numeric
        'grdDatosImportacionDistribucion.Columns("Importe").DisplayFormat.FormatString = "c0"

        'grdDatosImportacionDistribucion.Columns("Transporte").Visible = False
        'grdDatosImportacionDistribucion.Columns("TipoEmpaque").Caption = "Tipo" + vbCrLf + "Empaque"
        'grdDatosImportacionDistribucion.Columns("AñoRemision").Caption = "Año" + vbCrLf + "Remisión"
        'grdDatosImportacionDistribucion.Columns("TipoComprobante").Caption = "Tipo" + vbCrLf + "Comprobante"
        'grdDatosImportacionDistribucion.Columns("UsuarioEntrega").Caption = "Usuario" + vbCrLf + "Entrega"
        'grdDatosImportacionDistribucion.Columns("MotivoNoEntrega").Caption = "Motivo" + vbCrLf + "No Entrega"
        'grdDatosImportacionDistribucion.Columns("FechaDocumento").Caption = "F Documento"
        'grdDatosImportacionDistribucion.Columns("FechaEntregado").Caption = "F Entrega"
        'grdDatosImportacionDistribucion.Columns("UsuarioCaptura").Caption = "Captura"
        'grdDatosImportacionDistribucion.Columns("Cliente").Width = 200

        'DiseñoGrid.PropiedadesGrid(grdDatos, False, Utils.HorzAlignment.Center, True)


        'grdDatos.BestFitColumns()
    End Sub

    Private Sub DisenioGridTabPares()

        'Tools.DiseñoGrid.DiseñoBaseGridSinBestFit(grdDatosImportacionDistribucion)

        For i = 0 To grdDatosInformacionPares.Columns.Count - 1
            grdDatosInformacionPares.Columns(i).OptionsColumn.AllowEdit = False
        Next

        grdDatosInformacionPares.Columns("Pares").DisplayFormat.FormatType = Utils.FormatType.Numeric
        grdDatosInformacionPares.Columns("Pares").DisplayFormat.FormatString = "N0"
        grdDatosInformacionPares.Columns("Pares").AppearanceCell.TextOptions.HAlignment = Utils.HorzAlignment.Far


        'grdDatosInformacionPares.BestFitColumns()
    End Sub

    Private Sub ContarNumeroTiendas()
        Dim tiendas = distribuciones.GroupBy(Function(x) x.Destino).ToList
        lblTotalTiendas.Text = String.Format("{0:N0}", tiendas.Count)
    End Sub

    Private Sub SumarParesArchivo()
        lblParesArchivos.Text = String.Format("{0:N0}", paresArchivo)
    End Sub

    Public Sub LLenarInformacionPedido(pedidoSAY As Integer,
                                       pedidoSICY As Integer,
                                       paresPedido As Integer,
                                       paresPendientes As Integer,
                                       cliente As String,
                                       ordenCompra As String,
                                       distribuciones As List(Of Entidades.DistribucionPedidoCoppel))
        Me.pedidoSAY = pedidoSAY
        Me.pedidoSICY = pedidoSICY
        Me.paresPedido = paresPedido
        Me.paresPendientes = paresPendientes
        paresArchivo = distribuciones.AsEnumerable().Sum(Function(x) x.CantidadSurtida)
        Me.cliente = cliente
        Me.ordenCompra = ordenCompra
        Me.distribuciones = distribuciones
    End Sub

    Private Sub MostrarInformacionPedido()
        grdImportacionDistribucion.DataSource = distribuciones
        CargarGrdOrdenTrabajo()
        DisenioGrid()
        DisenioGridTabPares()
        lblCliente.Text = cliente
        lblPedidoSAY.Text = pedidoSAY
        lblPedidoSICY.Text = pedidoSICY
        lblParesPedido.Text = String.Format("{0:N0}", paresPedido)
        lblParesPendientes.Text = String.Format("{0:N0}", paresPendientes)
        lblOrdenCompra.Text = ordenCompra

        ContarNumeroTiendas()
        SumarParesArchivo()
        CrearSummarAlPiePantalla()

    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        GuardarDistribucion()
    End Sub

    Private Sub GuardarDistribucion()
        Dim idDistribucionGenerado As Integer
        Dim cantidadOT As Integer
        Dim usuariocapturaid As Integer = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid

        Cursor = Cursors.WaitCursor
        idDistribucionGenerado = objBu.InsertarDistribucion_Encabezado(Me.ordenCompra, usuariocapturaid, pedidoSAY)

        If idDistribucionGenerado > 0 Then
            Dim dresult As DialogResult
            For Each distribucion In distribuciones
                objBu.InsertarDistribucion(idDistribucionGenerado, distribucion, usuariocapturaid)
            Next
            objBu.InsertarDistribucion_CargarInformacionFaltante(idDistribucionGenerado)
            cantidadOT = objBu.GenerarOT(pedidoSAY)

            'show_message("Exito", "Se han generado: " + cantidadOT.ToString + " Órdenes de Trabajo")
            dresult = show_message("Confirmar", "Se han generado: " + cantidadOT.ToString + " Órdenes de Trabajo. ¿Desea facturar las órdenes de trabajo?")

            If dresult = DialogResult.OK Then
                Cursor = Cursors.WaitCursor
                Dim administraroOTPF As New AdministradorOT_Form_Facturacion
                administraroOTPF.MdiParent = mdiForm
                administraroOTPF.Show()
                Cursor = Cursors.Default
                Me.Close()
            End If
        Else
            show_message("Advertencia", "Ha ocurrido un error, no se ha guardado la información.")
        End If

        Me.Close()
        Cursor = Cursors.Default
    End Sub

    Private Sub CrearSummarAlPiePantalla()
        grdDatosImportacionDistribucion.OptionsView.ShowFooter = GroupFooterShowMode.VisibleAlways
        grdDatosInformacionPares.OptionsView.ShowFooter = GroupFooterShowMode.VisibleAlways

        grdDatosImportacionDistribucion.GroupSummary.Clear()
        grdDatosInformacionPares.GroupSummary.Clear()
        grdDatosImportacionDistribucion.Columns("CantidadPedida").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "CantidadPedida", "{0:N0}")
        grdDatosImportacionDistribucion.Columns("CantidadSurtida").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "CantidadSurtida", "{0:N0}")
        grdDatosInformacionPares.Columns("Pares").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Pares", "{0:N0}")


        Dim item As New GridGroupSummaryItem
        item.FieldName = "CantidadPedida"
        item.ShowInGroupColumnFooter = grdDatosImportacionDistribucion.Columns("CantidadPedida")
        item.SummaryType = Data.SummaryItemType.Sum
        item.DisplayFormat = "Total {0:N}"
        grdDatosImportacionDistribucion.GroupSummary.Add(item)

        Dim item2 As New GridGroupSummaryItem
        item2.FieldName = "CantidadSurtida"
        item2.SummaryType = Data.SummaryItemType.Sum
        item2.DisplayFormat = "Total {0:N}"
        item2.ShowInGroupColumnFooter = grdDatosImportacionDistribucion.Columns("CantidadSurtida")
        grdDatosImportacionDistribucion.GroupSummary.Add(item2)

        Dim item3 As New GridGroupSummaryItem
        item2.FieldName = "Pares"
        item2.SummaryType = Data.SummaryItemType.Sum
        item2.DisplayFormat = "Total {0:N}"
        item2.ShowInGroupColumnFooter = grdDatosInformacionPares.Columns("Pares")
        grdDatosImportacionDistribucion.GroupSummary.Add(item3)
    End Sub

    Private Function ValidarPares() As Boolean
        Dim validado As Boolean = False

        If paresArchivo <= paresPendientes Then
            validado = True
        Else
            validado = False
        End If
        Return validado
    End Function

    Private Sub CargarGrdOrdenTrabajo()
        Dim tabla As New DataTable
        Dim fila As DataRow
        Dim tiendas = distribuciones.GroupBy(Function(x) x.Destino).ToList
        tabla.Columns.Add("Tienda")
        tabla.Columns.Add("Pares")


        Dim Query = (From d In distribuciones
                     Group By d.Destino
                     Into DetinoTienda = Group, Sum(d.CantidadSurtida))


        For Each datos In Query
            fila = tabla.NewRow
            fila("Tienda") = datos.Destino.ToString
            fila("Pares") = datos.Sum
            tabla.Rows.Add(fila)
        Next
        'For index = 0 To tiendas.Count - 1
        '    fila = tabla.NewRow
        '    fila("Tienda") = tiendas(index).Key.ToString
        '    fila("Pares") = (From d In distribuciones
        '                     Group d By d.Destino Into grp
        '                     Where d.Destino = fila("Tienda").ToString
        '                     Select d.CantidadSurtida).Sum()
        '    'fila("Pares") = distribuciones.GroupBy(Function(x) x.Destino).Select(Of x >= New Entidades)
        '    'fila("Pares") = (From d In distribuciones Where d.Destino = tiendas(index).Key Group By d.Destino Into tienda(.))).Sum(y.)
        '    tabla.Rows.Add(fila)
        'Next

        grdInformacionPares.DataSource = tabla
    End Sub
#Region "Mensajes"
    Public Function show_message(ByVal tipo As String, ByVal mensaje As String) As DialogResult
        Dim result As DialogResult

        If tipo.ToString.Equals("Advertencia") Then

            Dim mensajeAdvertencia As New AdvertenciaForm
            mensajeAdvertencia.mensaje = mensaje
            mensajeAdvertencia.ShowDialog()

        End If

        If tipo.ToString.Equals("AdvertenciaGrande") Then

            Dim mensajeAdvertencia As New AdvertenciaFormGrande
            mensajeAdvertencia.mensaje = mensaje
            mensajeAdvertencia.ShowDialog()

        End If

        If tipo.ToString.Equals("Aviso") Then

            Dim mensajeAviso As New AvisoForm
            mensajeAviso.mensaje = mensaje
            mensajeAviso.ShowDialog()

        End If

        If tipo.ToString.Equals("Error") Then

            Dim mensajeError As New ErroresForm
            mensajeError.mensaje = mensaje
            mensajeError.ShowDialog()

        End If

        If tipo.ToString.Equals("Exito") Then

            Dim mensajeExito As New ExitoForm
            mensajeExito.mensaje = mensaje
            mensajeExito.ShowDialog()

        End If

        If tipo.ToString.Equals("Confirmar") Then
            Dim mensajeExito As New ConfirmarForm
            mensajeExito.mensaje = mensaje

            result = mensajeExito.ShowDialog()
        End If

        Return result
    End Function
#End Region
    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub grdDatosImportacionDistribucion_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs)
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub

    Private Sub FacturacionAnticipada_ImportarDistribucionTiendasCoppel_Form_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        MostrarInformacionPedido()
        Validar()
    End Sub

    Private Sub Validar()
        btnGuardar.Enabled = False
        If ValidarEmparqueArticulos() Then
            If ValidarPares() Then
                btnGuardar.Enabled = True
                Return
            Else
                show_message("Advertencia", "Este archivo tiene más pares que los pares pendientes del pedido")
                lblParesArchivos.ForeColor = Color.Red
                lblParesPendientes.ForeColor = Color.Red
            End If
        Else
            show_message("Advertencia", "Artículos sin estándar de empaque")
        End If
    End Sub

    Private Sub FacturacionAnticipada_ImportarDistribucionTiendasCoppel_Form_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
        'ValidarPares()
    End Sub

    Private Sub grdDatosImportacionDistribucion_CustomDrawRowIndicator_1(sender As Object, e As RowIndicatorCustomDrawEventArgs) Handles grdDatosImportacionDistribucion.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub

    Private Sub grdDatosOrdenTrabajo_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs)
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub

    Private Function ValidarEmparqueArticulos() As Boolean
        Dim validado As Boolean = False
        If LecturaCorrectaArticuloEmpaque() Then
            validado = True
        Else
            validado = False
        End If

        Return validado
    End Function

    Private Function LecturaCorrectaArticuloEmpaque() As Boolean
        'Dim tabla As GridView
        'Dim datos As GridControl
        Dim dResultado As DataTable
        Dim resultado As Boolean = True
        Dim articulosEmpaque As New System.Text.StringBuilder

        For Each distribucion In distribuciones
            articulosEmpaque.Append(distribucion.CodigoRapidoCliente + "," + distribucion.Talla.ToString + ";")
        Next

        dResultado = objBu.ConsultarEmpaqueArticulos(articulosEmpaque.ToString)

        If dResultado.Rows.Count > 0 Then
            resultado = False
            distribucionesArticulosSinEmpaque = dResultado
        End If

        Return resultado
    End Function

    Private Sub grdDatosImportacionDistribucion_RowStyle(sender As Object, e As RowStyleEventArgs) Handles grdDatosImportacionDistribucion.RowStyle
        ColorearFila(e)
    End Sub

    Private Sub ColorearFila(e As RowStyleEventArgs)
        If distribucionesArticulosSinEmpaque.Rows.Count > 0 Then
            If e.RowHandle >= 0 Then
                Dim codigo As String = grdDatosImportacionDistribucion.GetRowCellValue(e.RowHandle, "CodigoRapidoCliente")
                Dim talla As String = grdDatosImportacionDistribucion.GetRowCellValue(e.RowHandle, "Talla")


                For index = 0 To distribucionesArticulosSinEmpaque.Rows.Count - 1
                    Dim aux = distribucionesArticulosSinEmpaque.Rows(index)("Cod").ToString
                    If distribucionesArticulosSinEmpaque.Rows(index)("Cod").ToString.Equals(codigo) And distribucionesArticulosSinEmpaque.Rows(index)("Talla").ToString.Equals(talla) Then
                        e.Appearance.BackColor = colorErrorArticulo
                        e.Appearance.ForeColor = Color.Red

                        'distribucionesArticulosSinEmpaque.Rows.RemoveAt(index)
                    End If
                Next
            End If
        End If
    End Sub

    Private Sub grdDatosInformacionPares_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs) Handles grdDatosInformacionPares.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub

    Public Sub SetMdiParent(obj As Form)
        mdiForm = obj
    End Sub
End Class