Imports Tools
Imports System.IO
Imports System.Text
Public Class EtiquetasOpcionesAvanzadasForm

    Dim msgAdvertencia As New Tools.AdvertenciaForm
    Dim msgError As New Tools.ErroresForm
    Dim msgExito As New Tools.ExitoForm
    Dim objBU As New Programacion.Negocios.EtiquetasBU
    Private _idNave As Integer = 0

    Public Property idNave() As Integer
        Get
            Return _idNave
        End Get
        Set(ByVal value As Integer)
            _idNave = value
        End Set
    End Property

    Private _Nave As String
    Public Property Nave() As String
        Get
            Return _Nave
        End Get
        Set(ByVal value As String)
            _Nave = value
        End Set
    End Property

    Private _fechaPrograma As Date = Date.Now
    Public Property fechaPrograma() As Date
        Get
            Return _fechaPrograma
        End Get
        Set(ByVal value As Date)
            _fechaPrograma = value
        End Set
    End Property

    Private _Lista As List(Of Integer)
    Public Property Lista() As List(Of Integer)
        Get
            Return _Lista
        End Get
        Set(ByVal value As List(Of Integer))
            _Lista = value
        End Set
    End Property

    Private _UsuarioId As Integer = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
    Public Property UsuarioID() As Integer
        Get
            Return _UsuarioId
        End Get
        Set(ByVal value As Integer)
            _UsuarioId = value
        End Set
    End Property

    Private _Usuario As String = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
    Public Property Usuario() As String
        Get
            Return _Usuario
        End Get
        Set(ByVal value As String)
            _Usuario = value
        End Set
    End Property


    'Accion 1: Produccion
    'Accion 2: Prueba
    Private _Accion As Int16 = 2
    Public Property Accion() As Int16
        Get
            Return _Accion
        End Get
        Set(ByVal value As Int16)
            _Accion = value
        End Set
    End Property



    Private Sub ImpresionEtiquetasForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        dtpFechaPrograma.Enabled = False

        Dim dtClientesPrueba As DataTable
        txtNave.Text = _Nave

        dtpFechaPrograma.Value = _fechaPrograma
        CargarImpresoras(cmbImpresoraAtados)
        CargarImpresoras(cmbImpresoraPares)
        CargarImpresoras(cmbImpresoraClientesPruebas)

        cmbTipoImpresion.SelectedIndex = 0

        dtClientesPrueba = objBU.ConsultarClientesEtiqueta()
        cmbClientesPruebas.DataSource = dtClientesPrueba
        cmbClientesPruebas.DisplayMember = "clie_nombregenerico"
        cmbClientesPruebas.ValueMember = "clie_clienteid"

        switch()

        Dim DTNAves As DataTable
        DTNAves = objBU.ConsultarNavesProduccion()
        'DTNAves.Rows.InsertAt(DTNAves.NewRow, 0)
        cmbClientesPruebasNaves.DataSource = DTNAves
        cmbClientesPruebasNaves.DisplayMember = "Nave"
        cmbClientesPruebasNaves.ValueMember = "NaveSICYID"


        cmbClientesPruebasNaves.SelectedValue = _idNave

        dtClientesPruebaFechaPrograma.Value = _fechaPrograma


        cmbClientesPruebasNaves.Enabled = False
        dtClientesPruebaFechaPrograma.Enabled = False
        txtLoteDelClientesPrueba.Enabled = False
        txtLoteAlClientesPruebas.Enabled = False
        txtPedidoSAY.Enabled = False
        txtPedidoSICY.Enabled = False
        dtpApartadofInicial.Enabled = False
        dtpApartadoFfinal.Enabled = False
        btnMostrar.Enabled = False
        lblMostrar.Enabled = False


        If _Accion = 2 Then
            lblPrueba.Visible = True
            TabControl1.SelectedTab = TabClientes
        Else
            lblPrueba.Visible = False
        End If

    End Sub


    Private Sub txtLoteDe_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtLoteDe.KeyPress
        'Verdadero no escribe
        e.Handled = soloNumeros(sender, e)
    End Sub

    Public Function soloNumeros(ByVal txt As TextBox, e As KeyPressEventArgs) As Boolean
        Dim Manejo As Boolean

        If Char.IsDigit(e.KeyChar) Then
            Manejo = False
        ElseIf Char.IsControl(e.KeyChar) Then
            Manejo = False
        Else
            Manejo = True
        End If
        Return Manejo
    End Function

    Private Sub txtLoteHasta_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtLoteHasta.KeyPress
        e.Handled = soloNumeros(sender, e)
    End Sub

    Private Sub btnImprimirAtados_Click(sender As Object, e As EventArgs) Handles btnImprimirAtados.Click


        Dim objNeg As New Programacion.Negocios.EtiquetasBU

        Try
            Cursor = Cursors.WaitCursor
            If txtLoteDe.Text = "" Then
                mensajeAdvertencia("El campo de lote del: no puede estar vacio.", txtLoteDe)
                Exit Sub
            End If

            If txtLoteHasta.Text = "" Then
                mensajeAdvertencia("El campo de lote al: no puede estar vacio.", txtLoteHasta)
                Exit Sub
            End If

            If CInt(txtLoteDe.Text.Trim) > CInt(txtLoteHasta.Text.Trim) Then
                mensajeAdvertencia("El lote inicial no puede ser mayor al lote final")
                Exit Sub
            End If

            If ValidaLote(CInt(txtLoteDe.Text.Trim)) Then
                If ValidaLote(CInt(txtLoteHasta.Text.Trim)) Then
                    Dim dtZpl As DataTable = objNeg.ImprimirAtados(_idNave, _fechaPrograma, _UsuarioId, cmbImpresoraAtados.SelectedValue, txtLoteDe.Text, txtLoteHasta.Text, chkImprimirPar.CheckState, txtCadenaAtados.Text)
                    Dim dtGrf As DataTable = objNeg.ComandosImprimirEtiquetasSAY_Lotes(txtLoteDe.Text.Trim, txtLoteHasta.Text.Trim, _idNave, CInt(Year(Format(fechaPrograma, "dd/MM/yyyy"))), cmbImpresoraAtados.SelectedValue)
                    If Not IsNothing(dtZpl) Then
                        If dtZpl.Rows.Count > 0 Then
                            GenerarArchivoEtiquetasTxt(dtZpl)
                            If Not IsNothing(dtGrf) Then
                                If dtGrf.Rows.Count > 0 Then
                                    GenerarArchivoEtiquetasBat(dtGrf)
                                    ejecutarBat()
                                    msgExito.mensaje = "Se ejecuto la impresion correctamente."
                                    msgExito.ShowDialog()
                                    Me.Close()
                                Else
                                    mensajeAdvertencia("La tabla de imagenes no contiene datos.")
                                End If
                            Else
                                mensajeAdvertencia("La consulta de imagenes grf realizada no arrojo resultados.")
                            End If
                        Else
                            mensajeAdvertencia("La tabla de etiquetas no contiene datos.")
                        End If
                    Else
                        mensajeAdvertencia("La consulta de etiquetas realizada no arrojo resultados.")
                    End If
                Else
                    mensajeAdvertencia("El numero de lote al: no es valido en la consulta actual.", txtLoteHasta)
                End If
            Else
                mensajeAdvertencia("El numero de lote del: no es valido en la consulta actual.", txtLoteDe)
            End If
        Catch ex As Exception
            msgError.mensaje = ex.Message + vbCrLf + ex.Source + vbCrLf + ex.StackTrace
            msgError.ShowDialog()
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub mensajeAdvertencia(ByVal texto As String, ByVal txt As TextBox)
        msgAdvertencia.mensaje = texto
        msgAdvertencia.ShowDialog()
        txt.Focus()
    End Sub

    Private Sub mensajeAdvertencia(ByVal texto As String)
        msgAdvertencia.mensaje = texto
        msgAdvertencia.ShowDialog()
    End Sub

    Private Function ValidaLote(ByVal Lote As Integer) As Boolean
        For Each num As Integer In Lista
            If num = Lote Then
                Return True
            End If
        Next
        Return False
    End Function

    Private Sub CargarImpresoras()
        Dim DTImpresoras As DataTable
        DTImpresoras = objBU.ListaImpresoras()
        cmbImpresoraAtados.DataSource = DTImpresoras
        cmbImpresoraAtados.DisplayMember = "Nombre"
        cmbImpresoraAtados.ValueMember = "IdImpresora"
        Dim dt As DataTable
        dt = objBU.ConsultaImpresoraAsignada(My.Computer.Name)
        If Not IsNothing(dt) Then
            If dt.Rows.Count > 0 Then
                cmbImpresoraAtados.SelectedValue = dt.Rows(0).Item("IdImpresora")
            End If
        End If
    End Sub

    Private Sub CargarImpresoras(ByVal cmb As ComboBox)
        Dim DTImpresoras As DataTable
        DTImpresoras = objBU.ListaImpresoras()
        cmb.DataSource = DTImpresoras
        cmb.DisplayMember = "Nombre"
        cmb.ValueMember = "IdImpresora"
        Dim dt As DataTable
        dt = objBU.ConsultaImpresoraAsignada(My.Computer.Name)
        If Not IsNothing(dt) Then
            If dt.Rows.Count > 0 Then
                cmb.SelectedValue = dt.Rows(0).Item("IdImpresora")
            End If
        End If
    End Sub

    Private Sub cmbTipoImpresion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTipoImpresion.SelectedIndexChanged
        Dim index As Integer = cmbTipoImpresion.SelectedIndex
        If index = 0 Then
            txtLoteDelPares.Enabled = False
            txtLoteAlPares.Enabled = False
            txtAtadoDel.Enabled = False
            txtAtadoAl.Enabled = False
            chkMostrarPares.Enabled = False
            txtLoteDelPares.Text = ""
            txtLoteAlPares.Text = ""
            txtAtadoDel.Text = ""
            txtAtadoAl.Text = ""
            chkMostrarPares.CheckState = CheckState.Unchecked

        ElseIf index = 1 Then
            txtLoteDelPares.Enabled = True
            txtLoteAlPares.Enabled = True
            txtAtadoDel.Enabled = True
            txtAtadoAl.Enabled = True
            chkMostrarPares.Enabled = True
            txtLoteDelPares.Focus()
        End If
    End Sub

    Private Sub chkMostrarPares_CheckedChanged(sender As Object, e As EventArgs) Handles chkMostrarPares.CheckedChanged
        Dim sql As String = String.Empty
        Dim objNeg As New Negocios.EtiquetasBU
        Dim ListaPares As List(Of Entidades.Pares)
        If chkMostrarPares.Checked = True Then

            If txtLoteDelPares.Text = "" Then
                mensajeAdvertencia("El campo de lote del: no puede estar vacio.", txtLoteDelPares)
                RemoverManejadorCheckBox(sender, e)
                Exit Sub
            End If

            If txtLoteAlPares.Text = "" Then
                mensajeAdvertencia("El campo de lote al: no puede estar vacio.", txtLoteAlPares)
                RemoverManejadorCheckBox(sender, e)
                Exit Sub
            End If

            If txtAtadoDel.Text.Trim.Length > 0 Then
                If txtAtadoAl.Text = "" Then
                    mensajeAdvertencia("El campo de atado al: no puede estar vacio, se hace referencia de atados en el campo atado Del.", txtLoteDe)
                    RemoverManejadorCheckBox(sender, e)
                    Exit Sub
                End If
            End If


            If txtAtadoAl.Text.Trim.Length > 0 Then
                If txtAtadoDel.Text = "" Then
                    mensajeAdvertencia("El campo de atado Del: no puede estar vacio, se hace referencia de atado en el campo atado Al.", txtLoteDe)
                    RemoverManejadorCheckBox(sender, e)
                    Exit Sub
                End If
            End If

            If ValidaLote(CInt(txtLoteAlPares.Text.Trim)) Then
                If ValidaLote(CInt(txtLoteDelPares.Text.Trim)) Then
                    sql = " AND (ld.Lote Between " & txtLoteDelPares.Text.Trim & " And " & txtLoteAlPares.Text.Trim & ") "
                    'If txtCadenaAtadosPares.Text.ToString.Trim.Length > 0 Then
                    '    sql = sql & " AND (ld.No_Docena Between " & txtCadenaAtadosPares.Text.Trim
                    'End If

                    If txtAtadoDel.Text.Trim.Length > 0 Then
                        sql = sql & " AND (ld.No_Docena Between " & txtAtadoDel.Text & " And " & txtAtadoAl.Text & ") "
                    End If

                    sql = sql & " AND (ld.Año=" & CInt(Year(Format(fechaPrograma, "dd/MM/yyyy"))) & ") "

                    sql = IIf(Len(sql) = 0, "", sql & " ORDER BY IdDocena,Imprimir, ld.Lote, Calce")

                    ListaPares = objNeg.MostrarPares(_idNave, sql)
                    If Not IsNothing(ListaPares) Then
                        grdPares.DataSource = ListaPares
                        DiseñoGrid(grdVPares)
                    End If
                Else
                    mensajeAdvertencia("El numero de lote del: no es valido en la consulta actual.", txtLoteDelPares)
                    RemoverManejadorCheckBox(sender, e)
                End If
            Else
                mensajeAdvertencia("El numero de lote al: no es valido en la consulta actual.", txtLoteAlPares)
                RemoverManejadorCheckBox(sender, e)
            End If
        Else
            grdPares.DataSource = Nothing
        End If
    End Sub

    Private Sub RemoverManejadorCheckBox(sender As Object, e As EventArgs)
        Dim cb As CheckBox = DirectCast(sender, CheckBox)
        RemoveHandler cb.CheckedChanged, AddressOf chkMostrarPares_CheckedChanged
        cb.Checked = Not cb.Checked
        AddHandler cb.CheckedChanged, AddressOf chkMostrarPares_CheckedChanged
    End Sub

    Private Sub txtLoteDelPares_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtLoteDelPares.KeyPress
        e.Handled = soloNumeros(sender, e)
    End Sub

    Private Sub txtLoteAlPares_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtLoteAlPares.KeyPress
        e.Handled = soloNumeros(sender, e)
    End Sub

    Private Sub DiseñoGrid(ByVal Grid As DevExpress.XtraGrid.Views.Grid.GridView)


        If IsNothing(Grid.Columns.FirstOrDefault(Function(x) x.FieldName = "#")) = True Then
            Grid.Columns.AddVisible("#").UnboundType = DevExpress.Data.UnboundColumnType.[Integer]
            AddHandler Grid.CustomUnboundColumnData, AddressOf grdVpares_CustomUnboundColumnData
            Grid.Columns.Item("#").VisibleIndex = 0
        End If


        Tools.DiseñoGrid.AlinearTextoEncabezadoColumnas(Grid)
        Tools.DiseñoGrid.AlternarColorEnFilas(Grid)

        Grid.Columns.ColumnByFieldName("#").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("Lote").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("Docena").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("idPar").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("Talla").OptionsColumn.AllowEdit = False


        Grid.Columns.ColumnByFieldName("Imprimir").Width = 50
        Grid.Columns.ColumnByFieldName("#").Width = 25
        Grid.Columns.ColumnByFieldName("Lote").Width = 40
        Grid.Columns.ColumnByFieldName("Docena").Width = 50
        'Grid.Columns.ColumnByFieldName("idPar").Width = 50
        Grid.Columns.ColumnByFieldName("Talla").Width = 50


        Grid.Columns.ColumnByFieldName("idPar").Caption = "Par"
        Grid.Columns.ColumnByFieldName("Talla").Caption = "Calce"






    End Sub

    Private Sub DiseñoGridApartados(ByVal Grid As DevExpress.XtraGrid.Views.Grid.GridView)

        If IsNothing(Grid.Columns.FirstOrDefault(Function(x) x.FieldName = "#")) = True Then
            Grid.Columns.AddVisible("#").UnboundType = DevExpress.Data.UnboundColumnType.[Integer]
            AddHandler Grid.CustomUnboundColumnData, AddressOf grdVClientesPruebaApartados_CustomUnboundColumnData
            Grid.Columns.Item("#").VisibleIndex = 0
        End If
        Tools.DiseñoGrid.AlinearTextoEncabezadoColumnas(Grid)
        Tools.DiseñoGrid.AlternarColorEnFilas(Grid)

        Grid.Columns.ColumnByFieldName("#").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("Apartado").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("PedidoSAY").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("OrdenCte").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("FProgramación").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("FentregaCte").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("PrsConf").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("FConfirmación").OptionsColumn.AllowEdit = False



        Grid.Columns.ColumnByFieldName("#").Width = 25
        Grid.Columns.ColumnByFieldName("Sel").Width = 25
        Grid.Columns.ColumnByFieldName("PrsConf").Width = 40
        Grid.Columns.ColumnByFieldName("OrdenCte").Width = 100
        Grid.Columns.ColumnByFieldName("Sel").Caption = ""
        Grid.Columns.ColumnByFieldName("PrsConf").Caption = "Pares"


    End Sub

    Private Sub grdVpares_CustomUnboundColumnData(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs)
        If e.IsGetData Then
            e.Value = grdVPares.GetRowHandle(e.ListSourceRowIndex)
            e.Value = e.Value + 1
        End If
    End Sub


    Private Sub grdVClientesPruebaApartados_CustomUnboundColumnData(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs)
        If e.IsGetData Then
            e.Value = grdVClientesPruebaApartados.GetRowHandle(e.ListSourceRowIndex)
            e.Value = e.Value + 1
        End If
    End Sub


    Private Sub txtAtadoDel_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtAtadoDel.KeyPress
        e.Handled = soloNumeros(sender, e)
    End Sub

    Private Sub txtAtadoAl_KeyPress(sender As Object, e As KeyPressEventArgs)
        e.Handled = soloNumeros(sender, e)
    End Sub

    Private Sub btnImprimirPares_Click(sender As Object, e As EventArgs) Handles btnImprimirPares.Click
        Dim objNeg As New Programacion.Negocios.EtiquetasBU
        Dim sb As New StringBuilder
        Dim sbLotes As New StringBuilder
        Dim index As Integer
        Dim dtZpl As DataTable
        Dim dtGrf As DataTable
        Dim CadenaAtados As String = String.Empty
        Try
            Cursor = Cursors.WaitCursor
            index = cmbTipoImpresion.SelectedIndex

            If index = 0 Then
                For Each num As Integer In Lista
                    sbLotes.Append(CStr(num))
                    sbLotes.Append(",")
                Next
                sbLotes.Remove(sbLotes.Length - 1, 1)
                dtZpl = objBU.ImprimirPares(_idNave, _fechaPrograma, _UsuarioId, cmbImpresoraAtados.SelectedValue, 0, 0, True, sbLotes.ToString, "", "")
                dtGrf = objNeg.ComandosImprimirEtiquetasSAY_Lotes(txtLoteDelPares.Text.Trim, txtLoteAlPares.Text.Trim, _idNave, CInt(Year(Format(fechaPrograma, "dd/MM/yyyy"))), cmbImpresoraAtados.SelectedValue)
                If Not IsNothing(dtZpl) Then
                    If dtZpl.Rows.Count > 0 Then
                        GenerarArchivoEtiquetasTxt(dtZpl)
                        If Not IsNothing(dtGrf) Then
                            If dtGrf.Rows.Count > 0 Then
                                GenerarArchivoEtiquetasBat(dtGrf)
                                ejecutarBat()
                                msgExito.mensaje = "Se ejecuto la impresion correctamente."
                                msgExito.ShowDialog()
                                Me.Close()
                            Else
                                mensajeAdvertencia("La tabla de imagenes no contiene datos.")
                            End If
                        Else
                            mensajeAdvertencia("La consulta de imagenes grf realizada no arrojo resultados.")
                        End If
                    Else
                        mensajeAdvertencia("La tabla de etiquetas no contiene datos.")
                    End If
                Else
                    mensajeAdvertencia("La consulta de etiquetas realizada no arrojo resultados.")
                End If
            Else
                If chkMostrarPares.Checked Then
                    Dim numFilas As Integer
                    If grdVPares.DataRowCount > 0 Then
                        numFilas = grdVPares.DataRowCount - 1
                        For i = 0 To numFilas
                            If grdVPares.GetRowCellValue(i, "Imprimir") Then
                                sb.Append(grdVPares.GetRowCellValue(i, "idPar"))
                                sb.Append(",")
                            End If
                        Next


                        If sb.Length > 0 Then
                            sb.Remove(sb.Length - 1, 1)
                            dtZpl = objBU.ImprimirPares(_idNave, _fechaPrograma, _UsuarioId, cmbImpresoraAtados.SelectedValue, txtLoteDelPares.Text.Trim, txtLoteAlPares.Text.Trim, False, "", "", sb.ToString)
                            dtGrf = objNeg.ComandosImprimirEtiquetasSAY_Lotes(txtLoteDelPares.Text.Trim, txtLoteAlPares.Text.Trim, _idNave, CInt(Year(Format(fechaPrograma, "dd/MM/yyyy"))), cmbImpresoraAtados.SelectedValue)
                            If Not IsNothing(dtZpl) Then
                                If dtZpl.Rows.Count > 0 Then
                                    GenerarArchivoEtiquetasTxt(dtZpl)
                                    If Not IsNothing(dtGrf) Then
                                        If dtGrf.Rows.Count > 0 Then
                                            GenerarArchivoEtiquetasBat(dtGrf)
                                            ejecutarBat()
                                            msgExito.mensaje = "Se ejecuto la impresion correctamente."
                                            msgExito.ShowDialog()
                                        Else
                                            mensajeAdvertencia("La tabla de imagenes no contiene datos.")
                                        End If
                                    Else
                                        mensajeAdvertencia("La consulta de imagenes grf realizada no arrojo resultados.")
                                    End If
                                Else
                                    mensajeAdvertencia("La tabla de etiquetas no contiene datos.")
                                End If
                            Else
                                mensajeAdvertencia("La consulta de etiquetas realizada no arrojo resultados.")
                            End If
                        Else
                            mensajeAdvertencia("No se encuentran registros seleccionados.")
                        End If
                    Else
                        mensajeAdvertencia("No se encuentran registros seleccionados.")
                    End If
                Else
                    If txtLoteDelPares.Text = "" Then
                        mensajeAdvertencia("El campo de lote del: no puede estar vacio.", txtLoteDelPares)
                        Exit Sub
                    End If

                    If txtLoteAlPares.Text = "" Then
                        mensajeAdvertencia("El campo de lote al: no puede estar vacio.", txtLoteAlPares)
                        Exit Sub
                    End If

                    If txtLoteDelPares.Text <> "" Then
                        If CInt(txtLoteDelPares.Text.Trim) > CInt(txtLoteAlPares.Text.Trim) Then
                            mensajeAdvertencia("El lote inicial no puede ser mayor al lote final", txtLoteDelPares)
                            Exit Sub
                        End If
                    End If
                    If Not ValidaLote(CInt(txtLoteDelPares.Text.Trim)) Then
                        mensajeAdvertencia("El numero de lote del: no es valido en la consulta actual.", txtLoteDelPares)
                        Exit Sub
                    End If
                    If Not ValidaLote(CInt(txtLoteAlPares.Text.Trim)) Then
                        mensajeAdvertencia("El numero de lote Al: no es valido en la consulta actual.", txtLoteAlPares)
                        Exit Sub
                    End If
                    If txtAtadoDel.Text <> "" And txtAtadoAl.Text = "" Then
                        mensajeAdvertencia("Rango de atados incompleto.", txtAtadoAl)
                        Exit Sub
                    End If

                    If txtAtadoDel.Text = "" And txtAtadoAl.Text <> "" Then
                        mensajeAdvertencia("Rango de atados incompleto.", txtAtadoDel)
                        Exit Sub
                    End If

                    If txtAtadoDel.Text <> "" And txtAtadoAl.Text <> "" Then
                        If CInt(txtAtadoDel.Text.Trim) > CInt(txtAtadoAl.Text.Trim) Then
                            mensajeAdvertencia("El atado inicial no puede ser mayor al atado final", txtAtadoDel)
                            Exit Sub
                        End If
                        CadenaAtados = txtAtadoDel.Text + "-" + txtAtadoAl.Text
                    End If
                    dtZpl = objBU.ImprimirPares(_idNave, _fechaPrograma, _UsuarioId, cmbImpresoraAtados.SelectedValue, txtLoteDelPares.Text.Trim, txtLoteAlPares.Text.Trim, False, "", CadenaAtados, "")
                    dtGrf = objNeg.ComandosImprimirEtiquetasSAY_Lotes(txtLoteDelPares.Text.Trim, txtLoteAlPares.Text.Trim, _idNave, CInt(Year(Format(fechaPrograma, "dd/MM/yyyy"))), cmbImpresoraAtados.SelectedValue)
                    If Not IsNothing(dtZpl) Then
                        If dtZpl.Rows.Count > 0 Then
                            GenerarArchivoEtiquetasTxt(dtZpl)
                            If Not IsNothing(dtGrf) Then
                                If dtGrf.Rows.Count > 0 Then
                                    GenerarArchivoEtiquetasBat(dtGrf)
                                    ejecutarBat()
                                    msgExito.mensaje = "Se ejecuto la impresion correctamente."
                                    msgExito.ShowDialog()
                                    Me.Close()
                                Else
                                    mensajeAdvertencia("La tabla de imagenes no contiene datos.")
                                End If
                            Else
                                mensajeAdvertencia("La consulta de imagenes grf realizada no arrojo resultados.")
                            End If
                        Else
                            mensajeAdvertencia("La tabla de etiquetas no contiene datos.")
                        End If
                    Else
                        mensajeAdvertencia("La consulta de etiquetas realizada no arrojo resultados.")
                    End If
                End If
            End If

        Catch ex As Exception
            msgError.mensaje = ex.Message + vbCrLf + ex.Source + vbCrLf + ex.StackTrace
            msgError.ShowDialog()
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub GenerarArchivoEtiquetasTxt(ByVal dt As DataTable)
        Dim ArchivoTxt As String = "C:\SAY\Etiquetas.txt"
        Dim fsTxt As Stream = File.Create(ArchivoTxt)
        Dim swTxt As New System.IO.StreamWriter(fsTxt)
        Dim etiqueta As String = String.Empty
        Try
            For Each row As DataRow In dt.Rows
                If row.Item(0).ToString.Trim.Length > 0 Then
                    etiqueta = String.Empty
                    etiqueta = row.Item(0).ToString.Trim
                    swTxt.WriteLine(etiqueta)
                End If
            Next
            If _Accion = 2 Then
                Dim dtZplResumen As DataTable
                Dim objNeg As New Negocios.EtiquetasBU
                Dim EtiquetaResumen As String = String.Empty
                dtZplResumen = objNeg.ImprimirEtiquetaResumen(cmbClientesPruebas.SelectedValue, cmbClientesPruebas.Text, cmbClientesPruebasTipoEtiqueta.SelectedValue, _
                                                              cmbImpresoraClientesPruebas.SelectedValue, Usuario, Date.Now.ToString("dd/MM/yyyy HH:mm"))
                If Not IsNothing(dtZplResumen) Then
                    If dtZplResumen.Rows.Count > 0 Then
                        EtiquetaResumen = dtZplResumen.Rows(0).Item(0)
                        swTxt.WriteLine(EtiquetaResumen)
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        Finally
            swTxt.Close()
        End Try
    End Sub

    Private Sub GenerarArchivoEtiquetasBat(ByVal Lista As List(Of String))
        Dim ArchivoBat As String = "C:\SAY\Etiquetas.bat"
        Dim grf As String = String.Empty
        Dim fsBat As Stream = File.Create(ArchivoBat)
        Dim swBat As New System.IO.StreamWriter(fsBat)
        Try
            For Each item As String In Lista
                If item.Trim.Length > 0 Then
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

    Private Sub GenerarArchivoEtiquetasBat(ByVal dt As DataTable)
        Dim ArchivoBat As String = "C:\SAY\Etiquetas.bat"
        Dim grf As String = String.Empty
        Dim fsBat As Stream = File.Create(ArchivoBat)
        Dim swBat As New System.IO.StreamWriter(fsBat)
        Try
            If Not IsNothing(dt) Then
                If dt.Rows.Count > 0 Then
                    For Each row As DataRow In dt.Rows
                        If row.Item(0).ToString.Trim.Length > 0 Then
                            grf = String.Empty
                            grf = row.Item(0).ToString.Trim
                            swBat.WriteLine(grf)
                        End If
                    Next
                End If
            End If
        Catch ex As Exception
            Throw ex
        Finally
            swBat.Close()
        End Try
    End Sub

    Private Sub ejecutarBat()
        Shell("C:\SAY\Etiquetas.bat")
    End Sub

#Region "Cliente Prueba"
    Private Sub switch()
        Try
            Dim id As Integer
            Dim dtCllientePruebaTipoEtiqueta As DataTable
            'MsgBox(cmbClientesPruebas.SelectedValue.ToString)
            id = IIf(IsNumeric(cmbClientesPruebas.SelectedValue), cmbClientesPruebas.SelectedValue, 0)
            If id > 0 Then
                dtCllientePruebaTipoEtiqueta = objBU.ConsultarClientesTipoEtiqueta(_Accion, id)
                cmbClientesPruebasTipoEtiqueta.DataSource = dtCllientePruebaTipoEtiqueta
                cmbClientesPruebasTipoEtiqueta.ValueMember = "etiq_tipoetiquetaid"
                cmbClientesPruebasTipoEtiqueta.DisplayMember = "TipoEtiqueta"
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbClientesPruebas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbClientesPruebas.SelectedIndexChanged
        switch()
    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        Dim ClienteId As Integer = 0
        Dim fInicial As Date
        Dim fFinal As Date = Date.Now
        Dim dtApartados As DataTable


        ClienteId = cmbClientesPruebas.SelectedValue
        fInicial = dtpApartadofInicial.Value
        fFinal = dtpApartadoFfinal.Value



        dtApartados = objBU.ConsultarClientesApartados(ClienteId, fInicial, fFinal)

        If Not IsNothing(dtApartados) Then
            If dtApartados.Rows.Count > 0 Then
                grdClientesPruebaApartados.DataSource = dtApartados
                DiseñoGridApartados(grdVClientesPruebaApartados)
            Else
                mensajeAdvertencia("La consulta de apartados no contiene resultados ")
            End If
        Else
            mensajeAdvertencia("La consulta de apartados no contiene resultados")
        End If




    End Sub




    Private Sub rbApartado_CheckedChanged(sender As Object, e As EventArgs) Handles rbApartado.CheckedChanged
        If rbApartado.Checked Then
            dtpApartadofInicial.Enabled = True
            dtpApartadoFfinal.Enabled = True
            btnMostrar.Enabled = True
            grdClientesPruebaApartados.Enabled = True
            lblMostrar.Enabled = True
            dtpApartadofInicial.Focus()
        Else
            dtpApartadofInicial.Enabled = False
            dtpApartadoFfinal.Enabled = False
            btnMostrar.Enabled = False
            grdClientesPruebaApartados.Enabled = False
            lblMostrar.Enabled = False
        End If
    End Sub

    Private Sub rbLotes_CheckedChanged(sender As Object, e As EventArgs) Handles rbLotes.CheckedChanged
        If rbLotes.Checked Then
            cmbClientesPruebasNaves.Enabled = True
            dtClientesPruebaFechaPrograma.Enabled = True
            txtLoteDelClientesPrueba.Enabled = True
            txtLoteAlClientesPruebas.Enabled = True
            cmbClientesPruebasNaves.Focus()
        Else
            cmbClientesPruebasNaves.Enabled = False
            dtClientesPruebaFechaPrograma.Enabled = False
            txtLoteDelClientesPrueba.Enabled = False
            txtLoteAlClientesPruebas.Enabled = False
        End If

    End Sub

    Private Sub rbPedidoSay_CheckedChanged(sender As Object, e As EventArgs) Handles rbPedidoSay.CheckedChanged
        If rbPedidoSay.Checked Then
            txtPedidoSAY.Enabled = True
            txtPedidoSAY.Focus()
        Else
            txtPedidoSAY.Enabled = False
        End If
    End Sub

    Private Sub rbPedidoSicy_CheckedChanged(sender As Object, e As EventArgs) Handles rbPedidoSicy.CheckedChanged
        If rbPedidoSicy.Checked Then
            txtPedidoSICY.Enabled = True
            txtPedidoSICY.Focus()
        Else
            txtPedidoSICY.Enabled = False
        End If
    End Sub

    Private Sub btnClientesPruebaImprimir_Click(sender As Object, e As EventArgs) Handles btnClientesPruebaImprimir.Click

        Dim objNeg As New Negocios.EtiquetasBU
        Dim sb As New StringBuilder
        Dim dtZpl As New DataTable
        Try
            Cursor = Cursors.WaitCursor

            If cmbClientesPruebasTipoEtiqueta.Text = "" Then
                mensajeAdvertencia("Debe Seleccionar al menos un tipo de etiqueta.")
                Exit Sub
            End If


            If rbLotes.Checked Then
                If txtLoteDelClientesPrueba.Text = "" Then
                    mensajeAdvertencia("El campo de lote del: no puede estar vacio.", txtLoteDelClientesPrueba)
                    Exit Sub
                End If

                If txtLoteAlClientesPruebas.Text = "" Then
                    mensajeAdvertencia("El campo de lote al: no puede estar vacio.", txtLoteAlClientesPruebas)
                    Exit Sub
                End If

                If txtLoteDelClientesPrueba.Text <> "" Then
                    If CInt(txtLoteDelClientesPrueba.Text.Trim) > CInt(txtLoteAlClientesPruebas.Text.Trim) Then
                        mensajeAdvertencia("El lote inicial no puede ser mayor al lote final", txtLoteDelClientesPrueba)
                        Exit Sub
                    End If
                End If


                If cmbClientesPruebasNaves.Text = "" Then
                    mensajeAdvertencia("Debe Seleccionar al menos una nave.")
                    Exit Sub
                End If

                If _Accion = 1 Then
                    dtZpl = objNeg.ImprimirClientesProduccion(cmbImpresoraClientesPruebas.SelectedValue, _UsuarioId, cmbClientesPruebas.SelectedValue, cmbClientesPruebasTipoEtiqueta.SelectedValue, True, cmbClientesPruebasNaves.SelectedValue, dtClientesPruebaFechaPrograma.Value, txtLoteDelClientesPrueba.Text.Trim, txtLoteAlClientesPruebas.Text.Trim, False, 0, 0, False, "")
                ElseIf _Accion = 2 Then
                    dtZpl = objNeg.ImprimirClientesPrueba(cmbImpresoraClientesPruebas.SelectedValue, _UsuarioId, cmbClientesPruebas.SelectedValue, cmbClientesPruebasTipoEtiqueta.SelectedValue, True, cmbClientesPruebasNaves.SelectedValue, dtClientesPruebaFechaPrograma.Value, txtLoteDelClientesPrueba.Text.Trim, txtLoteAlClientesPruebas.Text.Trim, False, 0, 0, False, "")
                End If

            ElseIf rbPedidoSay.Checked Then
                If txtPedidoSAY.Text = "" Then
                    mensajeAdvertencia("El campo pedido say no puede estar vacio.", txtPedidoSAY)
                    Exit Sub
                End If

                If _Accion = 1 Then
                    dtZpl = objNeg.ImprimirClientesProduccion(cmbImpresoraClientesPruebas.SelectedValue, _UsuarioId, cmbClientesPruebas.SelectedValue, cmbClientesPruebasTipoEtiqueta.SelectedValue, False, 0, dtClientesPruebaFechaPrograma.Value, 0, 0, True, 0, txtPedidoSAY.Text, False, "")
                ElseIf _Accion = 2 Then
                    dtZpl = objNeg.ImprimirClientesPrueba(cmbImpresoraClientesPruebas.SelectedValue, _UsuarioId, cmbClientesPruebas.SelectedValue, cmbClientesPruebasTipoEtiqueta.SelectedValue, False, 0, dtClientesPruebaFechaPrograma.Value, 0, 0, True, 0, txtPedidoSAY.Text, False, "")
                End If
            ElseIf rbPedidoSicy.Checked Then
                If txtPedidoSICY.Text = "" Then
                    mensajeAdvertencia("El campo pedido sicy no puede estar vacio.", txtPedidoSICY)
                    Exit Sub
                End If

                If _Accion = 1 Then
                    dtZpl = objNeg.ImprimirClientesProduccion(cmbImpresoraClientesPruebas.SelectedValue, _UsuarioId, cmbClientesPruebas.SelectedValue, cmbClientesPruebasTipoEtiqueta.SelectedValue, False, 0, dtClientesPruebaFechaPrograma.Value, 0, 0, True, txtPedidoSICY.Text, 0, False, "")
                ElseIf _Accion = 2 Then
                    dtZpl = objNeg.ImprimirClientesPrueba(cmbImpresoraClientesPruebas.SelectedValue, _UsuarioId, cmbClientesPruebas.SelectedValue, cmbClientesPruebasTipoEtiqueta.SelectedValue, False, 0, dtClientesPruebaFechaPrograma.Value, 0, 0, True, txtPedidoSICY.Text, 0, False, "")
                End If

            ElseIf rbApartado.Checked Then
                If grdVClientesPruebaApartados.RowCount > 0 Then
                    Dim numFilas As Integer
                    numFilas = grdVClientesPruebaApartados.DataRowCount - 1
                    For i = 0 To numFilas
                        If grdVClientesPruebaApartados.GetRowCellValue(i, "Sel") Then
                            sb.Append(grdVClientesPruebaApartados.GetRowCellValue(i, "Apartado"))
                            sb.Append(",")
                        End If
                    Next

                    If sb.Length > 0 Then
                        sb.Remove(sb.Length - 1, 1)

                        If _Accion = 1 Then
                            dtZpl = objNeg.ImprimirClientesProduccion(cmbImpresoraClientesPruebas.SelectedValue, _UsuarioId, cmbClientesPruebas.SelectedValue, cmbClientesPruebasTipoEtiqueta.SelectedValue, False, 0, dtClientesPruebaFechaPrograma.Value, 0, 0, True, 0, 0, True, sb.ToString)
                        ElseIf _Accion = 2 Then
                            dtZpl = objNeg.ImprimirClientesPrueba(cmbImpresoraClientesPruebas.SelectedValue, _UsuarioId, cmbClientesPruebas.SelectedValue, cmbClientesPruebasTipoEtiqueta.SelectedValue, False, 0, dtClientesPruebaFechaPrograma.Value, 0, 0, True, 0, 0, True, sb.ToString)
                        End If
                    Else
                        mensajeAdvertencia("No se encontraron registros seleccionados.")
                    End If
                Else
                    mensajeAdvertencia("No se encontraron registros en el panel de datos de apartado.")
                End If
            Else
                mensajeAdvertencia("Debe seleccionar al menos una opcion de busqueda")
            End If

            If Not IsNothing(dtZpl) Then
                If dtZpl.Rows.Count > 0 Then
                    GenerarArchivoEtiquetasTxt(dtZpl)
                    Dim grfs As List(Of String) = dtZpl.AsEnumerable() _
                                               .Select(Function(r) r.Field(Of String)("foto")) _
                                               .Distinct() _
                                               .ToList()

                    'If Not IsNothing(grfs) Then
                    'If grfs.Count > 0 Then
                    GenerarArchivoEtiquetasBat(grfs)
                    ejecutarBat()
                    msgExito.mensaje = "Se ejecuto la impresion correctamente."
                    msgExito.ShowDialog()
                    'Else
                    'mensajeAdvertencia("La tabla de imagenes no contiene datos.")
                    'End If
                    'Else
                    ' mensajeAdvertencia("La consulta de imagenes grf realizada no arrojo resultados.")
                    'End If
                Else
                    mensajeAdvertencia("La tabla de etiquetas no contiene datos.")
                End If
            Else
                mensajeAdvertencia("La consulta de etiquetas realizada no arrojo resultados.")
            End If


        Catch ex As Exception
            msgError.mensaje = ex.Message + vbCrLf + ex.Source + vbCrLf + ex.StackTrace
            msgError.ShowDialog()

        Finally
            Cursor = Cursors.Default
        End Try


    End Sub


    Private Sub txtLoteDelClientesPrueba_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtLoteDelClientesPrueba.KeyPress
        e.Handled = soloNumeros(sender, e)
    End Sub

    Private Sub txtLoteAlClientesPruebas_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtLoteAlClientesPruebas.KeyPress
        e.Handled = soloNumeros(sender, e)
    End Sub

    Private Sub txtPedidoSAY_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPedidoSAY.KeyPress
        e.Handled = soloNumeros(sender, e)
    End Sub

    Private Sub txtPedidoSICY_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPedidoSICY.KeyPress
        e.Handled = soloNumeros(sender, e)
    End Sub
#End Region

    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged
        If _Accion = 2 And TabControl1.SelectedTab.Equals(TabClientes) Then
            TabControl1.SelectedTab = TabClientes
        ElseIf _Accion = 2 And Not (TabControl1.SelectedTab.Equals(TabClientes)) Then
            mensajeAdvertencia("No se puede seleccionar la pestaña " + TabControl1.SelectedTab.Text + " en modo de prueba")
            TabControl1.SelectedTab = TabClientes
        End If
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub


End Class