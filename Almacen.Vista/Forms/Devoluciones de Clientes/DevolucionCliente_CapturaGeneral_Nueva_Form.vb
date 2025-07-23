Public Class DevolucionCliente_CapturaGeneral_Nueva_Form

    Public tablaPedidosSeleccionados As DataTable
    Public tablaDocumentosSeleccionados As DataTable
    Public vacios As Boolean

    Public Sub InicializarCombos(control As ComboBox, tipoCombo As Int32, parametroProcedimiento As String,
                                 etiquetaCombo As String, valorCombo As String)

        Dim objNegocio As New Negocios.DevolucionClientesBU
            Dim lista As New DataTable
            If tipoCombo = 1 Then
                lista = objNegocio.ListadoMotivos(parametroProcedimiento)
            ElseIf tipoCombo = 2 Then
                lista = objNegocio.ListaGenerica("ConsultaClientes")
            ElseIf tipoCombo = 3 Then
                lista = objNegocio.ListaGenerica("ListadoEmpresas")
            ElseIf tipoCombo = 4 Then
                lista = objNegocio.ListaGenerica("ListadoFletes")
            ElseIf tipoCombo = 5 Then
                lista = objNegocio.ListaGenerica("ListadoColaboradorRecibe")
            ElseIf tipoCombo = 6 Then
                lista = objNegocio.ListadoUnidadesMedida()
            End If

        If lista.Rows.Count > 0 Then
            If valorCombo <> "unme_idunidad" Then
                Dim newRow As DataRow = lista.NewRow
                lista.Rows.InsertAt(newRow, 0)
            End If
            control.DataSource = lista
            control.DisplayMember = etiquetaCombo
            control.ValueMember = valorCombo
            If valorCombo = "unme_idunidad" Then
                control.SelectedIndex = 0
            End If
        End If
    End Sub

    Public Sub comboTipoDev()
        Dim estructura As New DataTable
        ' Variable para llevar el conteo de las columnas (index de columnas)
        Dim contador As Int16 = 0
        ' Variable que contendrá la columna
        Dim columna As New DataColumn
        columna.DataType = GetType(String)
        columna.DefaultValue = "-"
        columna.ColumnName = "IDTipoDev"
        columna.Caption = "IDTipoDev"
        columna.ReadOnly = False
        columna.Unique = False
        estructura.Columns.Add(columna)

        columna = New DataColumn
        columna.DataType = GetType(String)
        columna.DefaultValue = "-"
        columna.ColumnName = "TipoDev"
        columna.Caption = "TipoDev"
        columna.ReadOnly = False
        columna.Unique = False
        estructura.Columns.Add(columna)

        Dim fila As DataRow = estructura.NewRow
        fila(0) = "MAYOREO"
        fila(1) = "MAYOREO"

        estructura.Rows.Add(fila)

        cmbTipoDevolucion.DataSource = estructura
        cmbTipoDevolucion.DisplayMember = "IDTipoDev"
        cmbTipoDevolucion.ValueMember = "TipoDev"
    End Sub

    Public Function GenerarObjetoDevoluciones()
        Dim devolucion As New Entidades.DevolucionCliente
        devolucion.Tipodevolucion = cmbTipoDevolucion.Text
        devolucion.Clienteid = cmbCliente.SelectedValue
        'devolucion.Statusid
        For Each control As Control In grpbResolucion.Controls
            If TypeOf (control) Is RadioButton Then
                Dim radio As RadioButton = control
                If radio.Checked = True Then
                    devolucion.Resolucion = radio.Text
                End If
            End If
        Next
        devolucion.Fechacaptura = DateTime.Now
        devolucion.Usuariocapturaid = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        devolucion.Fecharecepcion = dtpFechaRecepcion.Value
        'devolucion.Recibio = cmbRecibio.SelectedValue
        devolucion.Cantidad_inicial = txtCantidad.Text.ToString
        devolucion.Cajas = txtCajas.Text.ToString
        devolucion.Motivoinicialalmacen_statusid = cmbMotivoInicial.SelectedValue
        devolucion.Observaciones_almacen = txtComentarios.Text
        devolucion.Paqueteria_proveedorid = cmbEmpresa.SelectedValue
        devolucion.Tipofleteid = cmbFlete.SelectedValue
        devolucion.Costopaqueteria = txtCosto.Text
        ' devolucion.Usuariomodificaid = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        devolucion.Almacen_fechamodificacion = DateTime.Now
        devolucion.Fechalimiteaccion = dtpFechaRecepcion.Value.AddDays(15)
        'devolucion.Dias_transcurridosventas = lbld
        Return devolucion
    End Function

    Public Sub LlenarCombos()
        InicializarCombos(cmbMotivoInicial, 1, "DEVOLUCION_CLIENTE_MOTIVO_INICIAL", "Motivo", "esta_estatusid")
        InicializarCombos(cmbCliente, 2, "", "clie_nombregenerico", "clie_clienteid")
        InicializarCombos(cmbEmpresa, 3, "", "prov_nombregenerico", "prov_nombregenerico")
        InicializarCombos(cmbFlete, 4, "", "tifl_nombre", "tifl_nombre")
        InicializarCombos(cmbRecibio, 5, "", "Colaborador", "IdColaborador")
        InicializarCombos(cmbUnidad, 6, "", "unme_descripcion", "unme_idunidad")
    End Sub

    Public Sub RecorrerControles(contenedor As Control)
        For Each control As Control In contenedor.Controls
            If TypeOf (control) Is GroupBox Then
                RecorrerControles(control)
            ElseIf TypeOf (control) Is ComboBox Then
                Dim comboBox As ComboBox = control
                If comboBox.Items.Count = 1 Then
                    comboBox.SelectedIndex = 0
                End If
            End If
        Next
    End Sub

    Public Sub ActualizarAtnCliente_Agente(idCliente As Int32)
        Dim objBU As New Negocios.DevolucionClientesBU
        lblAtnClientes.Text = objBU.GetAtnClientes(idCliente)
        lblAgentes.Text = objBU.ObtenerAgente(idCliente).ToString.Replace(",", "/")
        btnPedido.Enabled = True
        'btnDocumentosRelacionados.Enabled = True
        btnGuardar.Enabled = True
        'btnVerAgregarDetalle.Enabled = True
    End Sub

    Public Sub LimpiarAtnCliente_Agente()
        lblAgentes.Text = ""
        lblAtnClientes.Text = ""
        txtPedidoSay.Text = ""
        'txtDocumentosRelacionados.Text = ""
        btnPedido.Enabled = False
        'btnDocumentosRelacionados.Enabled = False
        btnVerAgregarDetalle.Enabled = False
    End Sub

    Public Sub SepararLista(cajaTexto As TextBox, tabla As DataTable, index As Int16)
        Dim contenido As String = ""
        If tabla IsNot Nothing And tabla.Rows.Count > 0 Then
            For Each elemento As DataRow In tabla.Rows
                contenido += elemento(index).ToString + ","
            Next
            cajaTexto.Text = contenido.Substring(0, contenido.Length - 1)
        End If
    End Sub

    Public Sub ValidarCamposObligatorios(control As Control, etiqueta As Label)
        If TypeOf (control) Is TextBox Then
            If control.Text.ToString.Length <= 0 Then
                etiqueta.ForeColor = Color.Red
                vacios = True
            Else
                etiqueta.ForeColor = Color.Black
            End If
        ElseIf TypeOf (control) Is ComboBox Then
            Dim combo As ComboBox = control
            If combo.SelectedValue Is Nothing Then
                etiqueta.ForeColor = Color.Red
                vacios = True
            ElseIf combo.SelectedValue.ToString.Length > 0 Or combo.SelectedText.Length > 0 Then
                etiqueta.ForeColor = Color.Black
            Else
                etiqueta.ForeColor = Color.Red
                vacios = True
            End If
        ElseIf TypeOf (control) Is MaskedTextBox Then
            Try
                If CInt(control.Text.ToString) >= 0 Then
                    etiqueta.ForeColor = Color.Black
                End If
            Catch ex As Exception
                etiqueta.ForeColor = Color.Red
                vacios = True
            End Try
        End If

        'MsgBox(CInt(txtCajas.ToString))
    End Sub

    Private Sub DevolucionCliente_CapturaGeneral_Nueva_Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtPedidoSay.ReadOnly = True
        'txtDocumentosRelacionados.ReadOnly = True
        txtPedidoSay.BackColor = Color.White
        'txtDocumentosRelacionados.BackColor = Color.White
        LlenarCombos()
        'lblFechaUsuarioRegistro.Text = DateTime.Now & " " & Entidades.SesionUsuario.UsuarioSesion.PUserUsername
        lblStatus.Text = "ABIERTA"
        lblStatus.ForeColor = Color.DarkGray
        dtpFechaRecepcion.Value = Date.Now

        'grpbVentas.Enabled = False
        'grpbCobranza.Enabled = False
        'lblUsuarioActual.Text = "Usuario de: DEVOLUCIONES"

        RecorrerControles(pnlDatos)
        comboTipoDev()
    End Sub

    Private Sub cmbCliente_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbCliente.SelectedValueChanged
        If cmbCliente.Text.Trim = "" Or cmbCliente.SelectedValue Is Nothing Then
            LimpiarAtnCliente_Agente()
        Else
            Try
                Dim idClientes As Int32 = cmbCliente.SelectedValue
                ActualizarAtnCliente_Agente(idClientes)

            Catch ex As Exception
                LimpiarAtnCliente_Agente()
            End Try
        End If
    End Sub

    Private Sub btnPedido_Click(sender As Object, e As EventArgs) Handles btnPedido.Click
        Dim FormularioFiltroPorPedidos As New DevolucionCliente_Filtro_PedidosDocumentos_PorCliente_Form
        FormularioFiltroPorPedidos.lblTitulo.Text = "Pedidos Por Cliente"
        FormularioFiltroPorPedidos.lblNombreCliente.Text = cmbCliente.Text
        FormularioFiltroPorPedidos.idCliente = cmbCliente.SelectedValue
        FormularioFiltroPorPedidos.tipoConsulta = 1
        FormularioFiltroPorPedidos.filtroActual = txtPedidoSay.Text.Split(",").ToList
        FormularioFiltroPorPedidos.Text = "Pedidos Por Cliente"
        FormularioFiltroPorPedidos.StartPosition = FormStartPosition.CenterScreen
        FormularioFiltroPorPedidos.ShowDialog(Me)
        If Not FormularioFiltroPorPedidos.DialogResult = Windows.Forms.DialogResult.OK Then Return
        tablaPedidosSeleccionados = FormularioFiltroPorPedidos.listaSeleccionados
        SepararLista(txtPedidoSay, tablaPedidosSeleccionados, 1)
    End Sub

    Private Sub btnVerAgregarDetalle_Click(sender As Object, e As EventArgs) Handles btnVerAgregarDetalle.Click
        Dim ventana As New Tools.AvisoForm
        ventana.mensaje = "En esta parte se pueden seleccionar los artículos de la devolución, a partir de pedidos, documentos y/o lectura de códigos"
        ventana.ShowDialog()
        Dim FormDetallesArticulos As New DevolucionCliente_CapturaGeneral_DetallesArticulos
        FormDetallesArticulos.idCliente = cmbCliente.SelectedValue
        FormDetallesArticulos.lblCliente.Text = cmbCliente.Text
        'FormDetallesArticulos.documentosSeleccionados = tablaDocumentosSeleccionados
        FormDetallesArticulos.pedidosSeleccionados = txtPedidoSay.Text
        FormDetallesArticulos.tipoDevolucion = cmbTipoDevolucion.Text
        FormDetallesArticulos.lblFolioDevolucion.Text = lblFolioDev.Text
        FormDetallesArticulos.unidadMedida = cmbUnidad.Text
        Try
            FormDetallesArticulos.cantidad = CInt(txtCantidad.Text)
        Catch ex As Exception
            FormDetallesArticulos.cantidad = 0
        End Try

        Try
            FormDetallesArticulos.cajas = CInt(txtCajas.Text)
        Catch ex As Exception
            FormDetallesArticulos.cajas = 0
        End Try

        If cmbMotivoInicial.Text <> "" And cmbMotivoInicial.Text.Length > 0 Then
            FormDetallesArticulos.tipoMotivo = 2
            FormDetallesArticulos.motivoDevolucion = cmbMotivoInicial.Text
            FormDetallesArticulos.idMotivoDevolucion = cmbMotivoInicial.SelectedValue
        End If
        FormDetallesArticulos.StartPosition = FormStartPosition.CenterScreen
        FormDetallesArticulos.ShowDialog(Me)
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Dispose()
    End Sub

    Private Sub dtpFechaRecepcion_ValueChanged(sender As Object, e As EventArgs) Handles dtpFechaRecepcion.ValueChanged
        lblNumSemana.Text = DatePart(DateInterval.WeekOfYear, dtpFechaRecepcion.Value, FirstDayOfWeek.Monday, FirstWeekOfYear.System)
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        vacios = False
        ValidarCamposObligatorios(cmbTipoDevolucion, lblEtiquetaTipoDevolucion)
        ValidarCamposObligatorios(cmbCliente, lblEtiquetaCliente)
        ValidarCamposObligatorios(cmbEmpresa, lblEtiquetaEmpresa)
        ValidarCamposObligatorios(cmbFlete, lblEtiquetaFlete)
        ValidarCamposObligatorios(txtCosto, lblEtiquetaCosto)
        ValidarCamposObligatorios(cmbRecibio, lblEtiquetaRecibio)
        ValidarCamposObligatorios(txtCantidad, lblEtiquetaCantidad)
        ValidarCamposObligatorios(cmbUnidad, lblEtiquetaUnidad)
        ValidarCamposObligatorios(txtCajas, lblEtiquetaCajas)
        ValidarCamposObligatorios(cmbMotivoInicial, lblEtiquetaMotivoIniDev)
        If rdbProcedeAutoriza.Checked = True Then
            ValidarCamposObligatorios(txtProcedeAutoriza, lblEtiquetaProcede)
        End If
        'ValidarCamposObligatorios()
        If vacios = True Then
            Dim advertencia As New Tools.AdvertenciaForm
            advertencia.mensaje = "Los campos marcados con asterísco (*) son obligatorios"
            advertencia.ShowDialog()
            Return
        End If
        'Return
        Dim ventana As New Tools.ExitoForm
        ventana.mensaje = "Se generó la devolución del cliente " & cmbCliente.Text & " con Folio 589"
        ventana.ShowDialog()
        btnVerAgregarDetalle.Enabled = True
        lblFechaUsuarioRegistro.Text = DateTime.Now & " (" + Entidades.SesionUsuario.UsuarioSesion.PUserUsername + ")"
        lblFolioDev.Text = "589"
        'Dim objDev As New Entidades.DevolucionCliente
        'Dim negocios As New Negocios.DevolucionClientesBU
        'negocios.RegistrarDevolucionCliente(objDev)
    End Sub

    Private Sub btnSolicitarRevisionVentas_Click(sender As Object, e As EventArgs) Handles btnSolicitarRevisionVentas.Click
        Dim ventana As New Tools.ExitoForm
        ventana.mensaje = "Ventas tiene hasta el " + (dtpFechaRecepcion.Value).AddDays(15) + " para indicarle el tratamiento de devolución del cliente " + cmbCliente.Text + " con Folio 589"
        ventana.ShowDialog()
        lblStatus.Text = "EN REVISIÓN"
        lblStatus.ForeColor = Color.Blue
    End Sub

    Private Sub btnAgregarCliente_Click(sender As Object, e As EventArgs) Handles btnAgregarCliente.Click
        Dim busquedaCliente As New Devolucioncliente_CapturaGeneral_Busqueda_Form
        Dim idCliente As Int32
        busquedaCliente.StartPosition = FormStartPosition.CenterScreen
        busquedaCliente.ShowDialog(Me)
        If Not busquedaCliente.DialogResult = Windows.Forms.DialogResult.OK Then Return
        idCliente = busquedaCliente.rowCliente(1)
        cmbCliente.SelectedValue = idCliente
        ActualizarAtnCliente_Agente(idCliente)
    End Sub

    Private Sub cmbEmpresa_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbEmpresa.SelectedValueChanged
        If cmbEmpresa.Text.ToString.Length > 0 And cmbEmpresa.Text = "CLIENTE (ENTREGA)" Then
            cmbFlete.SelectedValue = "PAGADO"
            txtCosto.Text = 0
        Else
            cmbFlete.SelectedIndex = 0
        End If
    End Sub

    Private Sub rdbProcedeAutoriza_CheckedChanged(sender As Object, e As EventArgs) Handles rdbProcedeAutoriza.CheckedChanged
        lblEtiquetaProcede.ForeColor = Color.Black
        If rdbProcedeAutoriza.Checked = True Then
            txtProcedeAutoriza.Enabled = True
            txtProcedeAutoriza.Select()
        Else
            txtProcedeAutoriza.Enabled = False
        End If
    End Sub
End Class