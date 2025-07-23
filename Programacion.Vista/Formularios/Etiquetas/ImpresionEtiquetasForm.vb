Imports Tools
Imports System.IO
Imports System.Text
Imports DevExpress.XtraGrid.Columns
Imports System.Text.RegularExpressions
Imports DevExpress.XtraPrinting
Imports Produccion.Negocios
Imports Stimulsoft.Report
Imports Stimulsoft.Report.Components

Public Class ImpresionEtiquetasForm
    Dim msgAdvertencia As New Tools.AdvertenciaForm
    Public msgError As New Tools.ErroresForm
    Public msgExito As New Tools.ExitoForm
    Dim objBU As New Programacion.Negocios.EtiquetasBU
    Dim ModeloSAY As String = String.Empty
    Dim id As String = String.Empty
    Dim ids() As String
    Dim Talla As String
    Dim CodigoSicy As String
    Dim TallaSicy As String
    Dim PielColor As String
    Private _idNave As Integer = 0
    Dim CadenaAtadosValida As Boolean = True
    Dim CadenaAtadosValida_Devolucion As Boolean = True
    Dim CadenaAtadosValidaLengua As Boolean = True

    Dim EsImpresionConArchivo As Boolean = False
    Dim EsPrimeraCargaPantalla As Boolean = True


    Dim dtCllientePruebaTipoEtiqueta As DataTable
    Dim singleFile As New StiReport
    Dim sb As New StringBuilder


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

    Dim CarpetaUbicacionArchivos As String = "C:\SAY\"
    Dim RutaArchivoEtiquetas As String = "C:\SAY\\ETIQUETAS.txt"
    Dim RutaArchivoBat As String = "C:\SAY\\Etiquetas.bat"

    Private Sub ImpresionEtiquetasForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Este es una prueba para publicar

        EsPrimeraCargaPantalla = True
        dtpFechaPrograma.Enabled = False

        Dim dtClientesPrueba As DataTable
        txtNave.Text = _Nave

        dtpFechaPrograma.Value = _fechaPrograma
        CargarImpresoras(cmbImpresoraAtados)
        CargarImpresoras(cmbImpresoraPares)
        CargarImpresoras(cmbImpresoraClientesPruebas)
        CargarImpresoras(cmbImpresoraLengua)
        CargarImpresoras(cmbImpresoraRastreo)
        CargarClientesRastreo()
        CargarImpresoras(cmbImpresoraGranel)
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
        'lblMostrar.Enabled = False
        lblModeloMensaje.Visible = False

        If _Accion = 2 Then
            lblPrueba.Visible = True
            TabOpcionesDeImpresion.SelectedTab = TabClientes
        Else
            lblPrueba.Visible = False
            If TabOpcionesDeImpresion.SelectedTab.Equals(TabAtados) Then
                txtLoteDe.Focus()
            End If
        End If

        EsPrimeraCargaPantalla = False
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

    Public Function ValidarCampoVacios_Lotes()
        If txtLoteDe.Text = "" Then
            mensajeAdvertencia("El campo de lote del no puede estar vacío.", txtLoteDe)
            Return False
        End If

        If txtLoteHasta.Text = "" Then
            mensajeAdvertencia("El campo de lote al no puede estar vacío.", txtLoteHasta)
            Return False
        End If

        If CInt(txtLoteDe.Text.Trim) > CInt(txtLoteHasta.Text.Trim) Then
            mensajeAdvertencia("El lote inicial no puede ser mayor al lote final")
            Return False
        End If

        If Not CadenaAtadosValida Then
            mensajeAdvertencia("La cadena de atados no tiene el formato requerido")
            Return False
        End If
        Return True
    End Function

    Public Function ValidarCampoVacios_Devolucion()
        Try
            If txtFolioDevSay.Text.Trim.Length = 0 Then
                mensajeAdvertencia("Ingrese un Folio de Devolución", txtFolioDevolucion)
                Return False
            ElseIf CInt(txtFolioDevSay.Text) <= 0 Then
                mensajeAdvertencia("Ingrese un Folio de Devolución válido", txtFolioDevolucion)
                Return False
            End If

            If chkDevCompleta.Checked = True Then
                txtLoteInicio_Devolucion.Text = "0"
                txtLoteFin_Devolucion.Text = "0"
            Else
                If txtLoteInicio_Devolucion.Text = "" Then
                    mensajeAdvertencia("Ingrese un lote de inicio", txtLoteInicio_Devolucion)
                    Return False
                End If

                If txtLoteFin_Devolucion.Text = "" Then
                    txtLoteFin_Devolucion.Text = txtLoteInicio_Devolucion.Text
                End If

                If CadenaAtadosValida_Devolucion = False Then
                    mensajeAdvertencia("La cadena de atados no tiene el formato requerido")
                    Return False
                End If
            End If

            Return True
        Catch ex As Exception

        End Try

    End Function

    Private Sub txtLoteHasta_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtLoteHasta.KeyPress
        e.Handled = soloNumeros(sender, e)
    End Sub

    Private Sub btnImprimirAtados_Click(sender As Object, e As EventArgs) Handles btnImprimirAtados.Click
        Dim objNeg As New Programacion.Negocios.EtiquetasBU
        Dim ResultadoValidacionTallasExtranjeras As Boolean = False
        Dim LoteInicio As Integer = 0
        Dim LoteFin As Integer = 0
        Dim numAtados As String = ""
        Dim FolioDevolucion As Integer = 0

        Dim VentanaDetallesTallasExtranjeras As New MostrarDetallesValidacionTallasExtanjerasForm

        Try
            If rdbLotes.Checked = True Then
                If ValidarCampoVacios_Lotes() = True Then
                    LoteInicio = CInt(txtLoteDe.Text)
                    LoteFin = CInt(txtLoteHasta.Text)
                    numAtados = txtCadenaAtados.Text
                Else
                    Exit Sub
                End If
            Else
                If ValidarCampoVacios_Devolucion() = True Then
                    LoteInicio = CInt(txtLoteInicio_Devolucion.Text)
                    LoteFin = CInt(txtLoteFin_Devolucion.Text)
                    FolioDevolucion = CInt(txtFolioDevSay.Text)
                    numAtados = txtNumAtado_Devolucion.Text
                Else
                    Exit Sub
                End If
            End If

            If ValidaLote(LoteInicio) Then
                If ValidaLote(LoteFin) Then
                    If chkImprimirPar.Checked = True Then
                        If objNeg.ValidarTallasExtranjerasPares(LoteInicio, LoteFin, _idNave, dtpFechaPrograma.Value.Year, dtpFechaPrograma.Value) = True Then
                            ResultadoValidacionTallasExtranjeras = True
                        Else
                            show_message("Advertencia", "Falta información por capturar de las tallas extranjeras.")
                            VentanaDetallesTallasExtranjeras.LoteInicio = txtLoteDe.Text
                            VentanaDetallesTallasExtranjeras.LoteFin = txtLoteHasta.Text
                            VentanaDetallesTallasExtranjeras.NaveSIYCID = _idNave
                            VentanaDetallesTallasExtranjeras.AñoPrograma = dtpFechaPrograma.Value.Year
                            VentanaDetallesTallasExtranjeras.FechaPrograma = dtpFechaPrograma.Value
                            VentanaDetallesTallasExtranjeras.ColeccionID = 0
                            VentanaDetallesTallasExtranjeras.EsEtiquetaPrueba = False
                            VentanaDetallesTallasExtranjeras.TipoEtiqueta = 3
                            VentanaDetallesTallasExtranjeras.ShowDialog()
                        End If
                    Else
                        ResultadoValidacionTallasExtranjeras = True
                    End If

                    If ResultadoValidacionTallasExtranjeras = True Then
                        Dim dtZpl As New DataTable
                        Dim dtGrf As New DataTable

                        If rdbLotes.Checked = True Then
                            dtZpl = objNeg.ImprimirAtados(_idNave, _fechaPrograma, _UsuarioId, cmbImpresoraAtados.SelectedValue, txtLoteDe.Text, txtLoteHasta.Text, chkImprimirPar.CheckState, txtCadenaAtados.Text)
                            dtGrf = objNeg.ComandosImprimirEtiquetasSAY_Lotes(txtLoteDe.Text.Trim, txtLoteHasta.Text.Trim, _idNave, CInt(Year(Format(fechaPrograma, "dd/MM/yyyy"))), cmbImpresoraAtados.SelectedValue)
                        Else
                            dtZpl = objNeg.ImprimirAtados_Devolucion(FolioDevolucion, _idNave, _UsuarioId, cmbImpresoraAtados.SelectedValue, LoteInicio, LoteFin, chkImprimirPar.CheckState, txtCadenaAtados.Text)
                            dtGrf = objNeg.ComandosImprimirEtiquetasSAY_Lotes_Devolucion(FolioDevolucion, LoteInicio, LoteFin, _idNave, CInt(Year(Format(fechaPrograma, "dd/MM/yyyy"))), cmbImpresoraAtados.SelectedValue)
                        End If

                        If Not IsNothing(dtZpl) Then
                            If dtZpl.Rows.Count > 0 Then
                                GenerarArchivoEtiquetasTxt(dtZpl)
                                If Not IsNothing(dtGrf) Then
                                    If dtGrf.Rows.Count > 0 Then
                                        GenerarArchivoEtiquetasBat(dtGrf)
                                        ejecutarBat()
                                        GuardarBitacoraImpresion(3, LoteInicio, LoteFin, 0, 0)
                                        msgExito.mensaje = "Se ejecutó la impresión correctamente."
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
                    End If

                Else
                    mensajeAdvertencia("Los lotes consultados no pertenecen  a la nave o programa seleccionado.", txtLoteHasta)
                End If
            Else
                mensajeAdvertencia("Los lotes consultados no pertenecen  a la nave o programa seleccionado.", txtLoteDe)
            End If
        Catch ex As Exception
            msgError.mensaje = ex.Message + vbCrLf + ex.Source + vbCrLf + ex.StackTrace
            msgError.ShowDialog()
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Public Sub mensajeAdvertencia(ByVal texto As String, ByVal txt As TextBox)
        msgAdvertencia.mensaje = texto
        msgAdvertencia.ShowDialog()
        txt.Focus()
    End Sub

    Public Sub mensajeAdvertencia(ByVal texto As String)
        msgAdvertencia.mensaje = texto
        msgAdvertencia.ShowDialog()
    End Sub

    Private Function ValidaLote(ByVal Lote As Integer) As Boolean
        If _idNave = 4 Then
            Return True
        End If

        For Each num As Integer In Lista
            If num = Lote Then
                Return True
            End If
        Next
        Return False
    End Function

    Private Sub GuardarBitacoraImpresion(TipoEtiqueta As Integer, LoteInicio As Integer, LoteFin As Integer, ColeccionID As Integer, ClienteID As Integer)
        Dim Año As Integer
        Dim NaveID As Integer
        Dim Programa As Integer
        Dim FechaPrograma As Date
        Dim UsuarioID As Integer
        Dim PedidoCliente As Integer = Nothing
        Dim Pares As Integer = Nothing
        Dim PedidoSAY As Integer = Nothing
        Dim pedidoSICY As Integer = Nothing
        Dim ApartadosConfirmados As String = Nothing


        Año = Date.Now.Year
        NaveID = _idNave
        FechaPrograma = _fechaPrograma
        UsuarioID = _UsuarioId


        Try
            objBU.GuardarBitacoraImpresion(LoteInicio, LoteFin, Año, NaveID,
                                                Programa, FechaPrograma, UsuarioID,
                                                PedidoCliente, Pares, TipoEtiqueta,
                                                PedidoSAY, pedidoSICY, ApartadosConfirmados,
                                                ColeccionID, ClienteID)
        Catch ex As Exception
            show_message("Error", ex.Message)
        End Try
    End Sub
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
            txtFolioDevolucion.Text = ""
            txtFolioDevolucion.Enabled = False
            chkMostrarPares.CheckState = CheckState.Unchecked
        ElseIf index = 1 Then
            txtLoteDelPares.Enabled = True
            txtLoteAlPares.Enabled = True
            txtAtadoDel.Enabled = True
            txtAtadoAl.Enabled = True
            chkMostrarPares.Enabled = True
            txtFolioDevolucion.Text = ""
            txtFolioDevolucion.Enabled = False
            txtLoteDelPares.Focus()
        ElseIf index = 2 Then
            txtLoteDelPares.Enabled = True
            txtLoteAlPares.Enabled = True
            txtAtadoDel.Enabled = True
            txtAtadoAl.Enabled = True
            txtLoteDelPares.Text = ""
            txtLoteAlPares.Text = ""
            txtAtadoDel.Text = ""
            txtAtadoAl.Text = ""
            txtFolioDevolucion.Text = ""
            txtFolioDevolucion.Enabled = True
            chkMostrarPares.Enabled = True
            chkMostrarPares.CheckState = CheckState.Unchecked
            txtFolioDevolucion.Select()
        End If
    End Sub

    Private Sub chkMostrarPares_CheckedChanged(sender As Object, e As EventArgs) Handles chkMostrarPares.CheckedChanged
        Dim sql As String = String.Empty
        Dim objNeg As New Negocios.EtiquetasBU
        Dim ListaPares As List(Of Entidades.Pares)

        Dim LoteInicio As Integer
        Dim LoteFin As Integer
        Dim AtadoInicio As String
        Dim AtadoFin As String
        Dim FolioDev As Integer

        Try
            Cursor = Cursors.WaitCursor
            If chkMostrarPares.Checked = True Then
                If cmbTipoImpresion.SelectedIndex = 1 Then
                    If txtLoteDelPares.Text = "" Then
                        mensajeAdvertencia("El campo de lote del no puede estar vacío.", txtLoteDelPares)
                        RemoverManejadorCheckBox(sender, e)
                        Exit Sub
                    End If

                    If txtLoteAlPares.Text = "" Then
                        mensajeAdvertencia("El campo de lote al no puede estar vacío.", txtLoteAlPares)
                        RemoverManejadorCheckBox(sender, e)
                        Exit Sub
                    End If

                    If txtAtadoDel.Text.Trim.Length > 0 Then
                        If txtAtadoAl.Text = "" Then
                            mensajeAdvertencia("El campo de atado al no puede estar vacío, se hace referencia de atados en el campo atado Del.", txtLoteDe)
                            RemoverManejadorCheckBox(sender, e)
                            Exit Sub
                        End If
                    End If

                    If txtAtadoAl.Text.Trim.Length > 0 Then
                        If txtAtadoDel.Text = "" Then
                            mensajeAdvertencia("El campo de atado Del no puede estar vacío, se hace referencia de atado en el campo atado Al.", txtLoteDe)
                            RemoverManejadorCheckBox(sender, e)
                            Exit Sub
                        End If
                    End If

                    If ValidaLote(CInt(txtLoteAlPares.Text.Trim)) Then
                        If ValidaLote(CInt(txtLoteDelPares.Text.Trim)) Then
                            'sql = " AND (ld.Lote Between " & txtLoteDelPares.Text.Trim & " And " & txtLoteAlPares.Text.Trim & ") "
                            ''If txtCadenaAtadosPares.Text.ToString.Trim.Length > 0 Then
                            ''    sql = sql & " AND (ld.No_Docena Between " & txtCadenaAtadosPares.Text.Trim
                            ''End If

                            'If txtAtadoDel.Text.Trim.Length > 0 Then
                            '    sql = sql & " AND (ld.No_Docena Between " & txtAtadoDel.Text & " And " & txtAtadoAl.Text & ") "
                            'End If

                            'sql = sql & " AND (ld.Año=" & CInt(Year(Format(fechaPrograma, "dd/MM/yyyy"))) & ") "

                            'sql = IIf(Len(sql) = 0, "", sql & " ORDER BY IdDocena,Imprimir, ld.Lote, Calce")

                            'CInt(Year(Format(fechaPrograma, "dd/MM/yyyy")))
                            LoteInicio = CInt(txtLoteDelPares.Text)
                            LoteFin = CInt(txtLoteAlPares.Text)
                            AtadoInicio = IIf(txtAtadoDel.Text.Trim.Length > 0, txtAtadoDel.Text.Trim, 0)
                            AtadoFin = IIf(txtAtadoAl.Text.Trim.Length > 0, txtAtadoAl.Text.Trim, 0)
                            FolioDev = 0

                            ListaPares = objNeg.MostrarPares(_idNave, CInt(Year(Format(fechaPrograma, "dd/MM/yyyy"))), LoteInicio, LoteFin, AtadoInicio, AtadoFin, FolioDev)
                            If Not IsNothing(ListaPares) Then
                                If ListaPares.Count > 0 Then
                                    grdPares.DataSource = ListaPares
                                    DiseñoGrid(grdVPares)
                                Else
                                    mensajeAdvertencia("No se encontraron resultados de la consulta solicitada")
                                End If
                            Else
                                mensajeAdvertencia("No se encontraron resultados de la consulta solicitada")
                            End If
                        Else
                            mensajeAdvertencia("Los lotes consultados no pertenecen  a la nave o programa seleccionado.", txtLoteDelPares)
                            RemoverManejadorCheckBox(sender, e)
                        End If
                    Else
                        mensajeAdvertencia("Los lotes consultados no pertenecen  a la nave o programa seleccionado.", txtLoteAlPares)
                        RemoverManejadorCheckBox(sender, e)
                    End If
                ElseIf cmbTipoImpresion.SelectedIndex = 2 Then
                    If txtFolioDevolucion.Text.Trim.Length = 0 Then
                        mensajeAdvertencia("Ingrese un Folio de devolución", txtFolioDevolucion)
                        RemoverManejadorCheckBox(sender, e)
                        Exit Sub
                    End If

                    FolioDev = txtFolioDevolucion.Text.Trim
                    LoteInicio = IIf(txtLoteDelPares.Text.Trim.Length > 0, txtLoteDelPares.Text.Trim, 0)
                    LoteFin = IIf(txtLoteAlPares.Text.Trim.Length > 0, txtLoteAlPares.Text.Trim, 0)
                    AtadoInicio = IIf(txtAtadoDel.Text.Trim.Length > 0, txtAtadoDel.Text.Trim, 0)
                    AtadoFin = IIf(txtAtadoAl.Text.Trim.Length > 0, txtAtadoAl.Text.Trim, 0)

                    ListaPares = objNeg.MostrarPares(_idNave, CInt(Year(Format(fechaPrograma, "dd/MM/yyyy"))), LoteInicio, LoteFin, AtadoInicio, AtadoFin, FolioDev)
                    If Not IsNothing(ListaPares) Then
                        If ListaPares.Count > 0 Then
                            grdPares.DataSource = ListaPares
                            DiseñoGrid(grdVPares)
                        Else
                            mensajeAdvertencia("No se encontraron resultados de la consulta solicitada")
                        End If
                    Else
                        mensajeAdvertencia("No se encontraron resultados de la consulta solicitada")
                    End If
                End If
            Else
                grdPares.DataSource = Nothing
            End If
        Catch ex As Exception
            msgError.mensaje = ex.Message + vbCrLf + ex.Source + vbCrLf + ex.StackTrace
            msgError.ShowDialog()
        Finally
            Cursor = Cursors.Default
        End Try
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
        Grid.Columns.ColumnByFieldName("Docena").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("idDocena").OptionsColumn.AllowEdit = False

        Grid.Columns.ColumnByFieldName("Imprimir").Width = 50
        Grid.Columns.ColumnByFieldName("#").Width = 25
        Grid.Columns.ColumnByFieldName("Lote").Width = 50
        Grid.Columns.ColumnByFieldName("Docena").Width = 50
        'Grid.Columns.ColumnByFieldName("idPar").Width = 50
        Grid.Columns.ColumnByFieldName("Talla").Width = 50

        Grid.Columns.ColumnByFieldName("Imprimir").Caption = " "
        Grid.Columns.ColumnByFieldName("idPar").Caption = "Par"
        Grid.Columns.ColumnByFieldName("Talla").Caption = "Calce"
        Grid.Columns.ColumnByFieldName("idDocena").Caption = "Atado"


        Grid.Columns.ColumnByFieldName("Docena").Visible = False




    End Sub

    Private Sub DiseñoGridApartados(ByVal Grid As DevExpress.XtraGrid.Views.Grid.GridView)

        Grid.OptionsView.ColumnAutoWidth = False
        'Grid.OptionsView.BestFitMaxRowCount = 0


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

        Grid.Columns.ColumnByFieldName("ApartadoSicy").Visible = False


        Grid.Columns.ColumnByFieldName("#").Width = 25
        Grid.Columns.ColumnByFieldName("Sel").Width = 25
        Grid.Columns.ColumnByFieldName("PedidoSAY").Width = 65
        Grid.Columns.ColumnByFieldName("Apartado").Width = 60
        Grid.Columns.ColumnByFieldName("PrsConf").Width = 60
        Grid.Columns.ColumnByFieldName("OrdenCte").Width = 100
        Grid.Columns.ColumnByFieldName("FConfirmación").Width = 120
        Grid.Columns.ColumnByFieldName("Sel").Caption = " "
        Grid.Columns.ColumnByFieldName("PrsConf").Caption = "PrsConf"


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
        Dim LoteInicio As Integer = 0
        Dim LoteFin As Integer = 0
        Dim VentanaDetallesTallasExtranjeras As New MostrarDetallesValidacionTallasExtanjerasForm

        Try
            Cursor = Cursors.WaitCursor
            dtZpl = Nothing
            dtGrf = Nothing
            index = cmbTipoImpresion.SelectedIndex

            If index = 0 Then
                LoteInicio = Lista.Min()
                LoteFin = Lista.Max()

                For Each num As Integer In Lista
                    sbLotes.Append(CStr(num))
                    sbLotes.Append(",")
                Next

                sbLotes.Remove(sbLotes.Length - 1, 1)

                dtZpl = objBU.ImprimirPares(_idNave, _fechaPrograma, _UsuarioId, cmbImpresoraPares.SelectedValue, 0, 0, True, sbLotes.ToString, "", "")
                dtGrf = objNeg.ComandosImprimirEtiquetasSAY_Lotes(txtLoteDelPares.Text.Trim, txtLoteAlPares.Text.Trim, _idNave, CInt(Year(Format(fechaPrograma, "dd/MM/yyyy"))), cmbImpresoraPares.SelectedValue)
                If Not IsNothing(dtZpl) Then
                    If dtZpl.Rows.Count > 0 Then
                        If objNeg.ValidarTallasExtranjerasPares(LoteInicio, LoteFin, _idNave, dtpFechaPrograma.Value.Year, dtpFechaPrograma.Value) = True Then
                            GenerarArchivoEtiquetasTxt(dtZpl)
                            If Not IsNothing(dtGrf) Then
                                If dtGrf.Rows.Count > 0 Then
                                    GenerarArchivoEtiquetasBat(dtGrf)
                                    ejecutarBat()
                                    GuardarBitacoraImpresion(2, LoteInicio, LoteFin, 0, 0)
                                    msgExito.mensaje = "Se ejecutó la impresión correctamente."
                                    msgExito.ShowDialog()
                                    Me.Close()
                                Else
                                    mensajeAdvertencia("La tabla de imagenes no contiene datos.")
                                End If
                            Else
                                mensajeAdvertencia("La consulta de imagenes grf realizada no arrojo resultados.")
                                'mensajeAdvertencia("La tabla de etiquetas no contiene datos.")
                            End If
                        Else
                            show_message("Advertencia", "No hay información capturada de las tallas extranjeras.")
                            VentanaDetallesTallasExtranjeras.LoteInicio = LoteInicio
                            VentanaDetallesTallasExtranjeras.LoteFin = LoteFin
                            VentanaDetallesTallasExtranjeras.NaveSIYCID = _idNave
                            VentanaDetallesTallasExtranjeras.AñoPrograma = dtpFechaPrograma.Value.Year
                            VentanaDetallesTallasExtranjeras.FechaPrograma = dtpFechaPrograma.Value
                            VentanaDetallesTallasExtranjeras.ColeccionID = 0
                            VentanaDetallesTallasExtranjeras.EsEtiquetaPrueba = False
                            VentanaDetallesTallasExtranjeras.TipoEtiqueta = 3
                            VentanaDetallesTallasExtranjeras.ShowDialog()
                        End If
                    Else
                        mensajeAdvertencia("La tabla de etiquetas no contiene datos.")
                        ' mensajeAdvertencia("La consulta de etiquetas realizada no arrojo resultados.")
                    End If
                Else
                    mensajeAdvertencia("La consulta de etiquetas realizada no arrojo resultados.")
                End If

            ElseIf index = 1 Then
                LoteInicio = txtLoteDelPares.Text
                LoteFin = txtLoteAlPares.Text

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
                            dtZpl = objBU.ImprimirPares(_idNave, _fechaPrograma, _UsuarioId, cmbImpresoraPares.SelectedValue, txtLoteDelPares.Text.Trim, txtLoteAlPares.Text.Trim, False, "", "", sb.ToString)
                            dtGrf = objNeg.ComandosImprimirEtiquetasSAY_Lotes(txtLoteDelPares.Text.Trim, txtLoteAlPares.Text.Trim, _idNave, CInt(Year(Format(fechaPrograma, "dd/MM/yyyy"))), cmbImpresoraPares.SelectedValue)
                            If Not IsNothing(dtZpl) Then
                                If dtZpl.Rows.Count > 0 Then
                                    If objNeg.ValidarTallasExtranjerasPares(LoteInicio, LoteFin, _idNave, dtpFechaPrograma.Value.Year, dtpFechaPrograma.Value) = True Then
                                        GenerarArchivoEtiquetasTxt(dtZpl)
                                        If Not IsNothing(dtGrf) Then
                                            If dtGrf.Rows.Count > 0 Then
                                                GenerarArchivoEtiquetasBat(dtGrf)
                                                ejecutarBat()
                                                GuardarBitacoraImpresion(2, LoteInicio, LoteFin, 0, 0)
                                                msgExito.mensaje = "Se ejecutó la impresión correctamente."
                                                msgExito.ShowDialog()
                                            Else
                                                mensajeAdvertencia("La tabla de imagenes no contiene datos.")
                                            End If
                                        Else
                                            mensajeAdvertencia("La consulta de imagenes grf realizada no arrojo resultados.")
                                        End If
                                    Else
                                        show_message("Advertencia", "No hay información capturada de las tallas extranjeras.")
                                        VentanaDetallesTallasExtranjeras.LoteInicio = LoteInicio
                                        VentanaDetallesTallasExtranjeras.LoteFin = LoteFin
                                        VentanaDetallesTallasExtranjeras.NaveSIYCID = _idNave
                                        VentanaDetallesTallasExtranjeras.AñoPrograma = dtpFechaPrograma.Value.Year
                                        VentanaDetallesTallasExtranjeras.FechaPrograma = dtpFechaPrograma.Value
                                        VentanaDetallesTallasExtranjeras.ColeccionID = 0
                                        VentanaDetallesTallasExtranjeras.EsEtiquetaPrueba = False
                                        VentanaDetallesTallasExtranjeras.TipoEtiqueta = 3
                                        VentanaDetallesTallasExtranjeras.ShowDialog()
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
                        mensajeAdvertencia("El campo de lote del no puede estar vacío.", txtLoteDelPares)
                        Exit Sub
                    End If

                    If txtLoteAlPares.Text = "" Then
                        mensajeAdvertencia("El campo de lote al no puede estar vacío.", txtLoteAlPares)
                        Exit Sub
                    End If

                    If txtLoteDelPares.Text <> "" Then
                        If CInt(txtLoteDelPares.Text.Trim) > CInt(txtLoteAlPares.Text.Trim) Then
                            mensajeAdvertencia("El lote inicial no puede ser mayor al lote final", txtLoteDelPares)
                            Exit Sub
                        End If
                    End If
                    If Not ValidaLote(CInt(txtLoteDelPares.Text.Trim)) Then
                        mensajeAdvertencia("Los lotes consultados no pertenecen  a la nave o programa seleccionado.", txtLoteDelPares)
                        Exit Sub
                    End If
                    If Not ValidaLote(CInt(txtLoteAlPares.Text.Trim)) Then
                        mensajeAdvertencia("Los lotes consultados no pertenecen  a la nave o programa seleccionado.", txtLoteAlPares)
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
                    'If _idNave = 4 Then
                    '    dtZpl = objNeg.ImprimirGranel(txtLoteDelPares.Text.Trim, txtLoteAlPares.Text.Trim, 4, Date.Now.Year, cmbImpresoraAtados.SelectedValue, _UsuarioId, Date.Now)
                    'Else
                    '    dtZpl = objBU.ImprimirPares(_idNave, _fechaPrograma, _UsuarioId, cmbImpresoraPares.SelectedValue, txtLoteDelPares.Text.Trim, txtLoteAlPares.Text.Trim, False, "", CadenaAtados, "")
                    'End If
                    dtZpl = objBU.ImprimirPares(_idNave, _fechaPrograma, _UsuarioId, cmbImpresoraPares.SelectedValue, txtLoteDelPares.Text.Trim, txtLoteAlPares.Text.Trim, False, "", CadenaAtados, "")
                    dtGrf = objNeg.ComandosImprimirEtiquetasSAY_Lotes(txtLoteDelPares.Text.Trim, txtLoteAlPares.Text.Trim, _idNave, CInt(Year(Format(fechaPrograma, "dd/MM/yyyy"))), cmbImpresoraPares.SelectedValue)
                    If Not IsNothing(dtZpl) Then
                        If dtZpl.Rows.Count > 0 Then
                            GenerarArchivoEtiquetasTxt(dtZpl)
                            If Not IsNothing(dtGrf) Then
                                If dtGrf.Rows.Count > 0 Then
                                    GenerarArchivoEtiquetasBat(dtGrf)
                                    ejecutarBat()
                                    GuardarBitacoraImpresion(2, LoteInicio, LoteFin, 0, 0)
                                    msgExito.mensaje = "Se ejecutó la impresión correctamente."
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
                End If
            ElseIf index = 2 Then
                Dim FolioDev As Integer

                If txtFolioDevolucion.Text = "" Then
                    mensajeAdvertencia("Ingrese un folio de devolución", txtFolioDevolucion)
                    Exit Sub
                Else
                    FolioDev = CInt(txtFolioDevolucion.Text)
                End If

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

                            If txtLoteDelPares.Text = "" Then
                                LoteInicio = 0

                                If txtLoteAlPares.Text = "" Then
                                    LoteFin = 0
                                Else
                                    mensajeAdvertencia("Ingrese un lote de inicio", txtLoteDelPares)
                                    Exit Sub
                                End If
                            Else
                                LoteInicio = CInt(txtLoteDelPares.Text.ToString)
                                If txtLoteAlPares.Text = "" Then
                                    mensajeAdvertencia("Ingrese un lote de fin", txtLoteAlPares)
                                    Exit Sub
                                Else
                                    LoteFin = CInt(txtLoteAlPares.Text.ToString)
                                    If Not ValidaLote(CInt(txtLoteAlPares.Text.Trim)) Then
                                        mensajeAdvertencia("Los lotes consultados no pertenecen  a la nave o programa seleccionado.", txtLoteAlPares)
                                        Exit Sub
                                    End If
                                End If

                                If Not ValidaLote(CInt(txtLoteDelPares.Text.Trim)) Then
                                    mensajeAdvertencia("Los lotes consultados no pertenecen  a la nave o programa seleccionado.", txtLoteDelPares)
                                    Exit Sub
                                End If
                            End If

                            If LoteInicio > LoteFin Then
                                mensajeAdvertencia("El lote inicial no puede ser mayor al lote final", txtLoteDelPares)
                                Exit Sub
                            End If

                            Dim atadoInicio As String
                            Dim atadoFin As String

                            If txtAtadoDel.Text = "" Then
                                atadoInicio = 0

                                If txtAtadoAl.Text = "" Then
                                    atadoFin = 0
                                Else
                                    mensajeAdvertencia("Ingrese un atado de inicio", txtAtadoDel)
                                    Exit Sub
                                End If
                            Else
                                atadoInicio = txtAtadoDel.Text.ToString

                                If txtAtadoAl.Text = "" Then
                                    mensajeAdvertencia("Ingrese un atado de fin", txtAtadoDel)
                                    Exit Sub
                                Else
                                    atadoFin = txtAtadoAl.Text.ToString
                                End If
                            End If

                            If txtAtadoDel.Text <> "" And txtAtadoAl.Text <> "" Then
                                If CInt(txtAtadoDel.Text.Trim) > CInt(txtAtadoAl.Text.Trim) Then
                                    mensajeAdvertencia("El atado inicial no puede ser mayor al atado final", txtAtadoDel)
                                    Exit Sub
                                End If
                                CadenaAtados = txtAtadoDel.Text + "-" + txtAtadoAl.Text
                            End If


                            dtZpl = objBU.ImprimirPares_Devolucion(FolioDev, _idNave, _UsuarioId, cmbImpresoraPares.SelectedValue, 0, 0, "", sb.ToString)
                            dtGrf = objNeg.ComandosImprimirEtiquetasSAY_Lotes_Devolucion(FolioDev, LoteInicio, LoteFin, _idNave, CInt(Year(Format(fechaPrograma, "dd/MM/yyyy"))), cmbImpresoraPares.SelectedValue)
                            If Not IsNothing(dtZpl) Then
                                If dtZpl.Rows.Count > 0 Then
                                    If objNeg.ValidarTallasExtranjerasPares(LoteInicio, LoteFin, _idNave, dtpFechaPrograma.Value.Year, dtpFechaPrograma.Value) = True Then
                                        GenerarArchivoEtiquetasTxt(dtZpl)
                                        If Not IsNothing(dtGrf) Then
                                            If dtGrf.Rows.Count > 0 Then
                                                GenerarArchivoEtiquetasBat(dtGrf)
                                                ejecutarBat()
                                                GuardarBitacoraImpresion(2, LoteInicio, LoteFin, 0, 0)
                                                msgExito.mensaje = "Se ejecutó la impresión correctamente."
                                                msgExito.ShowDialog()
                                            Else
                                                mensajeAdvertencia("La tabla de imagenes no contiene datos.")
                                            End If
                                        Else
                                            mensajeAdvertencia("La consulta de imagenes grf realizada no arrojo resultados.")
                                        End If
                                    Else
                                        show_message("Advertencia", "No hay información capturada de las tallas extranjeras.")
                                        VentanaDetallesTallasExtranjeras.LoteInicio = LoteInicio
                                        VentanaDetallesTallasExtranjeras.LoteFin = LoteFin
                                        VentanaDetallesTallasExtranjeras.NaveSIYCID = _idNave
                                        VentanaDetallesTallasExtranjeras.AñoPrograma = dtpFechaPrograma.Value.Year
                                        VentanaDetallesTallasExtranjeras.FechaPrograma = dtpFechaPrograma.Value
                                        VentanaDetallesTallasExtranjeras.ColeccionID = 0
                                        VentanaDetallesTallasExtranjeras.EsEtiquetaPrueba = False
                                        VentanaDetallesTallasExtranjeras.TipoEtiqueta = 3
                                        VentanaDetallesTallasExtranjeras.ShowDialog()
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
                        LoteInicio = 0

                        If txtLoteAlPares.Text = "" Then
                            LoteFin = 0
                        Else
                            mensajeAdvertencia("Ingrese un lote de inicio", txtLoteDelPares)
                            Exit Sub
                        End If
                    Else
                        LoteInicio = CInt(txtLoteDelPares.Text.ToString)
                        If txtLoteAlPares.Text = "" Then
                            mensajeAdvertencia("Ingrese un lote de fin", txtLoteAlPares)
                            Exit Sub
                        Else
                            LoteFin = CInt(txtLoteAlPares.Text.ToString)
                            If Not ValidaLote(CInt(txtLoteAlPares.Text.Trim)) Then
                                mensajeAdvertencia("Los lotes consultados no pertenecen  a la nave o programa seleccionado.", txtLoteAlPares)
                                Exit Sub
                            End If
                        End If

                        If Not ValidaLote(CInt(txtLoteDelPares.Text.Trim)) Then
                            mensajeAdvertencia("Los lotes consultados no pertenecen  a la nave o programa seleccionado.", txtLoteDelPares)
                            Exit Sub
                        End If
                    End If

                    If LoteInicio > LoteFin Then
                        mensajeAdvertencia("El lote inicial no puede ser mayor al lote final", txtLoteDelPares)
                        Exit Sub
                    End If

                    Dim atadoInicio As String
                    Dim atadoFin As String

                    If txtAtadoDel.Text = "" Then
                        atadoInicio = 0

                        If txtAtadoAl.Text = "" Then
                            atadoFin = 0
                        Else
                            mensajeAdvertencia("Ingrese un atado de inicio", txtAtadoDel)
                            Exit Sub
                        End If
                    Else
                        atadoInicio = txtAtadoDel.Text.ToString

                        If txtAtadoAl.Text = "" Then
                            mensajeAdvertencia("Ingrese un atado de fin", txtAtadoDel)
                            Exit Sub
                        Else
                            atadoFin = txtAtadoAl.Text.ToString
                        End If
                    End If

                    If txtAtadoDel.Text <> "" And txtAtadoAl.Text <> "" Then
                        If CInt(txtAtadoDel.Text.Trim) > CInt(txtAtadoAl.Text.Trim) Then
                            mensajeAdvertencia("El atado inicial no puede ser mayor al atado final", txtAtadoDel)
                            Exit Sub
                        End If
                        CadenaAtados = txtAtadoDel.Text + "-" + txtAtadoAl.Text
                    End If
                    'If _idNave = 4 Then
                    '    dtZpl = objNeg.ImprimirGranel(txtLoteDelPares.Text.Trim, txtLoteAlPares.Text.Trim, 4, Date.Now.Year, cmbImpresoraAtados.SelectedValue, _UsuarioId, Date.Now)
                    'Else
                    '    dtZpl = objBU.ImprimirPares(_idNave, _fechaPrograma, _UsuarioId, cmbImpresoraPares.SelectedValue, txtLoteDelPares.Text.Trim, txtLoteAlPares.Text.Trim, False, "", CadenaAtados, "")
                    'End If
                    dtZpl = objBU.ImprimirPares_Devolucion(FolioDev, _idNave, _UsuarioId, cmbImpresoraPares.SelectedValue, LoteInicio, LoteFin, CadenaAtados, "")
                    dtGrf = objNeg.ComandosImprimirEtiquetasSAY_Lotes_Devolucion(FolioDev, LoteInicio, LoteFin, _idNave, CInt(Year(Format(fechaPrograma, "dd/MM/yyyy"))), cmbImpresoraPares.SelectedValue)
                    If Not IsNothing(dtZpl) Then
                        If dtZpl.Rows.Count > 0 Then
                            GenerarArchivoEtiquetasTxt(dtZpl)
                            If Not IsNothing(dtGrf) Then
                                If dtGrf.Rows.Count > 0 Then
                                    GenerarArchivoEtiquetasBat(dtGrf)
                                    ejecutarBat()
                                    GuardarBitacoraImpresion(2, LoteInicio, LoteFin, 0, 0)
                                    msgExito.mensaje = "Se ejecutó la impresión correctamente."
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
                End If
            End If

        Catch ex As Exception
            msgError.mensaje = ex.Message + vbCrLf + ex.Source + vbCrLf + ex.StackTrace
            msgError.ShowDialog()
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Public Sub GenerarArchivoEtiquetasTxt(ByVal dt As DataTable)
        Dim ArchivoTxt As String = "C:\SAY\Etiquetas.txt"

        If Not System.IO.Directory.Exists("C:\SAY\") Then
            Directory.CreateDirectory("C:\SAY\")
        End If

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
                dtZplResumen = objNeg.ImprimirEtiquetaResumen(cmbClientesPruebas.SelectedValue, cmbClientesPruebas.Text, cmbClientesPruebasTipoEtiqueta.SelectedValue,
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

    Public Sub GenerarArchivoEtiquetasBat(ByVal Lista As List(Of String))
        Dim ArchivoBat As String = "C:\SAY\Etiquetas.bat"
        Dim grf As String = String.Empty
        Dim fsBat As Stream = File.Create(ArchivoBat)
        Dim swBat As New System.IO.StreamWriter(fsBat)
        Try
            If cmbImpresoraClientesPruebas.SelectedValue = 2 Then
                swBat.WriteLine("net use LPT1: \\PROGRAMACION2\PROGRAMACION3 /persistent:yes ")
            End If

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

    Public Sub GenerarArchivoEtiquetasBat(ByVal dt As DataTable)
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
                            If grf.Contains(".GRF") = True Or grf.Contains(".TXT") = True Then
                                swBat.WriteLine(grf)
                            End If

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

    Public Sub ejecutarBat()
        Shell("C:\SAY\Etiquetas.bat")
    End Sub


    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        Dim dtInformacionImpresion As New DataTable
        Dim ImpresoraId As Integer = 0
        Dim Año As Integer = 0
        Dim LoteInicio As String = String.Empty
        Dim LoteFin As String = String.Empty
        Dim UsuarioID As Integer = 0
        Dim FechaPrograma As Date
        Dim TipoImpresion As Integer = 0
        Dim ColeccionId As Integer = 0
        Dim dtResultadoImpresion As New DataTable
        Dim Resultado As Boolean = False
        Dim NumeroFilas As Integer = 0
        Dim ParesImprimir As String = String.Empty
        Dim EsEtiquetaPrueba As Boolean = False
        Dim VentanaDetallesTallasExtranjeras As New MostrarDetallesValidacionTallasExtanjerasForm
        Dim TipoEtiqueta As Integer
        Dim ClienteID As Integer

        Try

            If cmbTipoImpresionLengua.SelectedIndex < 0 Then
                show_message("Advertencia", "No se ha seleccionado un tipo de impresión.")
                Return
            End If

            If ValidarFiltroLotes() = False Then
                Return
            End If

            Cursor = Cursors.WaitCursor

            If Accion = 1 Then
                EsEtiquetaPrueba = False
            Else
                EsEtiquetaPrueba = True
            End If

            ImpresoraId = cmbImpresoraLengua.SelectedValue
            Año = dtpFechaPrograma.Value.Year
            LoteInicio = txtLoteInicioLengua.Text
            LoteFin = txtLoteFinLengua.Text
            UsuarioID = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
            FechaPrograma = dtpFechaPrograma.Value
            TipoImpresion = cmbTipoImpresionLengua.SelectedIndex
            If cmbColeccionLengua.SelectedIndex >= 0 Then
                ColeccionId = cmbColeccionLengua.SelectedValue
            Else
                ColeccionId = 0
            End If



            'If cmbClienteLengua.SelectedIndex >= 0 Then
            '    ClienteID = cmbClienteLengua.SelectedValue
            'Else
            '    ClienteID = 0
            'End If

            TipoEtiqueta = If(TipoImpresion = 0 Or TipoImpresion = 1, 10, TipoEtiqueta)
            TipoEtiqueta = If(TipoImpresion = 2, 13, TipoEtiqueta)
            TipoEtiqueta = If(TipoImpresion = 3, 29, TipoEtiqueta)

            If ValidarFiltros() = True Then
                If objBU.ValidarExisteEtiquetaLenguaYuyin() = True Then
                    If chkMostrarParesLengua.Checked = True Then
                        If objBU.ValidarExisteEtiquetaLenguaColeccion(ColeccionId, EsEtiquetaPrueba) = True Then
                            If EsEtiquetaPrueba = True Then
                                If ImpresionPorPares(ColeccionId, ClienteID) = True Then
                                    GuardarBitacoraImpresion(TipoEtiqueta, CInt(txtLoteInicioLengua.Text), CInt(txtLoteFinLengua.Text), ColeccionId, ClienteID)
                                    show_message("Exito", "Se ha mandado a imprimir correctamente.")
                                Else
                                    show_message("Advertencia", "Ocurrio un error al mandar imprimir.")
                                End If
                            Else
                                If objBU.ValidarImpresionEtiquetasLengua(txtLoteInicioLengua.Text, txtLoteFinLengua.Text, _idNave, dtpFechaPrograma.Value.Year, cmbImpresoraLengua.SelectedValue, UsuarioID, FechaPrograma, TipoImpresion, ColeccionId, txtAmarreLengua.Text, ClienteID) = True Then
                                    If objBU.ValidarTallasExtranjerasEtiquetaLengua(txtLoteInicioLengua.Text, txtLoteFinLengua.Text, _idNave, ColeccionId, dtpFechaPrograma.Value.Year, dtpFechaPrograma.Value, EsEtiquetaPrueba) = True Then


                                        If TipoImpresion = 0 Or TipoImpresion = 3 Then
                                            'Validacion de carga de diseños
                                            Dim ValidacionDiseñosForm As New EtiquetasLengua_ColeccionesSindiseñoForm
                                            ValidacionDiseñosForm.NaveSICYID = _idNave
                                            ValidacionDiseñosForm.Año = Año
                                            ValidacionDiseñosForm.LoteInicio = LoteInicio
                                            ValidacionDiseñosForm.LoteFin = LoteFin
                                            ValidacionDiseñosForm.Show()
                                            If ValidacionDiseñosForm.TieneDatos = 0 Then
                                                ValidacionDiseñosForm.Close()
                                                If ImpresionPorPares(ColeccionId, ClienteID) = True Then
                                                    GuardarBitacoraImpresion(TipoEtiqueta, CInt(txtLoteInicioLengua.Text), CInt(txtLoteFinLengua.Text), ColeccionId, ClienteID)

                                                    show_message("Exito", "Se ha mandado a imprimir correctamente.")
                                                Else
                                                    show_message("Advertencia", "Ocurrio un error al mandar imprimir.")
                                                End If
                                            Else
                                                Dim confirmacion As New ConfirmarForm

                                                confirmacion.mensaje = "Faltan diseños de etiqueta por realizar ¿Desea imprimir los lotes que si cuenten con diseño?"
                                                If confirmacion.ShowDialog() = Windows.Forms.DialogResult.OK Then
                                                    Cursor = Cursors.WaitCursor
                                                    If ImpresionPorPares(ColeccionId, ClienteID) = True Then
                                                        GuardarBitacoraImpresion(TipoEtiqueta, CInt(txtLoteInicioLengua.Text), CInt(txtLoteFinLengua.Text), ColeccionId, ClienteID)

                                                        show_message("Exito", "Se ha mandado a imprimir correctamente.")
                                                    Else
                                                        show_message("Advertencia", "Ocurrio un error al mandar imprimir.")
                                                    End If
                                                    '        dtInformacionImpresion = objBU.ImpresionEtiquetasLengua(LoteInicio, LoteFin, _idNave, Año, ImpresoraId, UsuarioID, FechaPrograma, TipoImpresion, ColeccionId, txtAmarreLengua.Text,, ClienteID)
                                                End If
                                            End If
                                        Else
                                            'dtInformacionImpresion = objBU.ImpresionEtiquetasLengua(LoteInicio, LoteFin, _idNave, Año, ImpresoraId, UsuarioID, FechaPrograma, TipoImpresion, ColeccionId, txtAmarreLengua.Text,, ClienteID)
                                            If ImpresionPorPares(ColeccionId, ClienteID) = True Then
                                                GuardarBitacoraImpresion(TipoEtiqueta, CInt(txtLoteInicioLengua.Text), CInt(txtLoteFinLengua.Text), ColeccionId, ClienteID)
                                                show_message("Exito", "Se ha mandado a imprimir correctamente.")
                                            Else
                                                show_message("Advertencia", "Ocurrio un error al mandar imprimir.")
                                            End If

                                        End If

                                        'If ImpresionPorPares(ColeccionId, ClienteID) = True Then
                                        '    GuardarBitacoraImpresion(TipoEtiqueta, CInt(txtLoteInicioLengua.Text), CInt(txtLoteFinLengua.Text), ColeccionId, ClienteID)
                                        '    show_message("Exito", "Se ha mandado a imprimir correctamente.")
                                        'Else
                                        '    show_message("Advertencia", "Ocurrio un error al mandar imprimir.")
                                        'End If

                                    Else
                                        show_message("Advertencia", "Falta información por cargar de las tallas extranjeras.")
                                        VentanaDetallesTallasExtranjeras.LoteInicio = txtLoteInicioLengua.Text
                                        VentanaDetallesTallasExtranjeras.LoteFin = txtLoteFinLengua.Text
                                        VentanaDetallesTallasExtranjeras.NaveSIYCID = _idNave
                                        VentanaDetallesTallasExtranjeras.AñoPrograma = dtpFechaPrograma.Value.Year
                                        VentanaDetallesTallasExtranjeras.FechaPrograma = dtpFechaPrograma.Value
                                        VentanaDetallesTallasExtranjeras.ColeccionID = ColeccionId
                                        VentanaDetallesTallasExtranjeras.EsEtiquetaPrueba = EsEtiquetaPrueba
                                        VentanaDetallesTallasExtranjeras.TipoEtiqueta = 1
                                        VentanaDetallesTallasExtranjeras.ShowDialog()
                                    End If
                                Else
                                    show_message("Advertencia", "Hay información incompleta de la etiqueta, verificar en la pantalla de detalles.")

                                    NumeroFilas = viewParesLengua.DataRowCount
                                    For index As Integer = 0 To NumeroFilas Step 1
                                        If CBool(viewParesLengua.GetRowCellValue(viewParesLengua.GetVisibleRowHandle(index), "Imprimir")) = True Then
                                            If ParesImprimir = String.Empty Then
                                                ParesImprimir = viewParesLengua.GetRowCellValue(viewParesLengua.GetVisibleRowHandle(index), "Par")
                                            Else
                                                ParesImprimir = ParesImprimir & "," & viewParesLengua.GetRowCellValue(viewParesLengua.GetVisibleRowHandle(index), "Par")
                                            End If
                                        End If
                                    Next

                                    If Accion = 1 Then
                                        dtResultadoImpresion = objBU.ImpresionEtiquetasPorParLengua(txtLoteInicioLengua.Text, _idNave, dtpFechaPrograma.Value.Year, ParesImprimir, cmbImpresoraLengua.SelectedValue, _UsuarioId, dtpFechaPrograma.Value, ColeccionId, True)
                                    Else
                                        dtResultadoImpresion = objBU.ImpresionEtiquetasPorParLenguaPrueba(txtLoteInicioLengua.Text, _idNave, dtpFechaPrograma.Value.Year, ParesImprimir, cmbImpresoraLengua.SelectedValue, _UsuarioId, dtpFechaPrograma.Value, ColeccionId, True)
                                    End If

                                    MostrarVentanaDetalles(dtResultadoImpresion, 3)
                                End If
                            End If

                        Else
                            show_message("Advertencia", "La etiqueta de lengua para la Colección " + cmbColeccionLengua.SelectedText + " no esta autorizada para su impresión.")
                        End If
                    Else

                        If objBU.ValidarImpresionEtiquetasLengua(txtLoteInicioLengua.Text, txtLoteFinLengua.Text, _idNave, dtpFechaPrograma.Value.Year, cmbImpresoraLengua.SelectedValue, UsuarioID, FechaPrograma, TipoImpresion, ColeccionId, txtAmarreLengua.Text, ClienteID) = True Then

                            If objBU.ValidarTallasExtranjerasEtiquetaLengua(txtLoteInicioLengua.Text, txtLoteFinLengua.Text, _idNave, ColeccionId, dtpFechaPrograma.Value.Year, dtpFechaPrograma.Value, EsEtiquetaPrueba) = True Then
                                If Accion = 1 Then

                                    If TipoImpresion = 0 Or TipoImpresion = 3 Then
                                        'Validacion de carga de diseños
                                        Dim ValidacionDiseñosForm As New EtiquetasLengua_ColeccionesSindiseñoForm
                                        ValidacionDiseñosForm.NaveSICYID = _idNave
                                        ValidacionDiseñosForm.Año = Año
                                        ValidacionDiseñosForm.LoteInicio = LoteInicio
                                        ValidacionDiseñosForm.LoteFin = LoteFin
                                        ValidacionDiseñosForm.Show()
                                        If ValidacionDiseñosForm.TieneDatos = 0 Then
                                            ValidacionDiseñosForm.Close()
                                            dtInformacionImpresion = objBU.ImpresionEtiquetasLengua(LoteInicio, LoteFin, _idNave, Año, ImpresoraId, UsuarioID, FechaPrograma, TipoImpresion, ColeccionId, txtAmarreLengua.Text,, ClienteID)
                                        Else
                                            Dim confirmacion As New ConfirmarForm

                                            confirmacion.mensaje = "Faltan diseños de etiqueta por realizar ¿Desea imprimir los lotes que si cuenten con diseño?"
                                            If confirmacion.ShowDialog() = Windows.Forms.DialogResult.OK Then
                                                Cursor = Cursors.WaitCursor
                                                dtInformacionImpresion = objBU.ImpresionEtiquetasLengua(LoteInicio, LoteFin, _idNave, Año, ImpresoraId, UsuarioID, FechaPrograma, TipoImpresion, ColeccionId, txtAmarreLengua.Text,, ClienteID)
                                            End If
                                        End If
                                    Else
                                        dtInformacionImpresion = objBU.ImpresionEtiquetasLengua(LoteInicio, LoteFin, _idNave, Año, ImpresoraId, UsuarioID, FechaPrograma, TipoImpresion, ColeccionId, txtAmarreLengua.Text,, ClienteID)
                                    End If


                                    'dtInformacionImpresion = objBU.ImpresionEtiquetasLengua(LoteInicio, LoteFin, _idNave, Año, ImpresoraId, UsuarioID, FechaPrograma, TipoImpresion, ColeccionId, txtAmarreLengua.Text,, ClienteID)
                                    'GuardarBitacoraImpresion(TipoEtiqueta, CInt(txtLoteInicioLengua.Text), CInt(txtLoteFinLengua.Text), ColeccionId, ClienteID)




                                Else
                                    dtInformacionImpresion = objBU.ImpresionEtiquetasLenguaPrueba(LoteInicio, LoteFin, _idNave, Año, ImpresoraId, UsuarioID, FechaPrograma, TipoImpresion, ColeccionId, txtAmarreLengua.Text)
                                End If

                                If dtInformacionImpresion.Rows.Count > 0 Then
                                    GeneraArchivosParaImpresion(dtInformacionImpresion, _idNave, cmbImpresoraLengua.SelectedValue, CInt(txtLoteInicioLengua.Text), CInt(txtLoteFinLengua.Text))
                                    show_message("Exito", "Se ha mandado la impresión.")
                                Else
                                    show_message("Advertencia", "No hay información para imprimir las etiquetas.")
                                End If
                            Else
                                show_message("Advertencia", "Falta información por capturar de las tallas extranjeras.")
                                VentanaDetallesTallasExtranjeras.LoteInicio = txtLoteInicioLengua.Text
                                VentanaDetallesTallasExtranjeras.LoteFin = txtLoteFinLengua.Text
                                VentanaDetallesTallasExtranjeras.NaveSIYCID = _idNave
                                VentanaDetallesTallasExtranjeras.AñoPrograma = dtpFechaPrograma.Value.Year
                                VentanaDetallesTallasExtranjeras.FechaPrograma = dtpFechaPrograma.Value
                                VentanaDetallesTallasExtranjeras.ColeccionID = ColeccionId
                                VentanaDetallesTallasExtranjeras.EsEtiquetaPrueba = EsEtiquetaPrueba
                                VentanaDetallesTallasExtranjeras.TipoEtiqueta = 1
                                VentanaDetallesTallasExtranjeras.ShowDialog()
                            End If

                        Else
                            show_message("Advertencia", "Hay información incompleta de la etiqueta, verificar en la pantalla de detalles.")

                            If Accion = 1 Then
                                dtResultadoImpresion = objBU.ImpresionEtiquetasLengua(LoteInicio, LoteFin, _idNave, Año, ImpresoraId, UsuarioID, FechaPrograma, TipoImpresion, ColeccionId, txtAmarreLengua.Text, True)
                            Else
                                dtResultadoImpresion = objBU.ImpresionEtiquetasLenguaPrueba(LoteInicio, LoteFin, _idNave, Año, ImpresoraId, UsuarioID, FechaPrograma, TipoImpresion, ColeccionId, txtAmarreLengua.Text, True)
                            End If

                            MostrarVentanaDetalles(dtResultadoImpresion, 3)
                        End If

                    End If

                Else
                    show_message("Advertencia", "No esta autorizada la impresión de la etiqueta de Lengua.")
                End If
            End If
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            show_message("Error", ex.Message.ToString())
        End Try

    End Sub

    Public Sub show_message(ByVal tipo As String, ByVal mensaje As String)

        If tipo.ToString.Equals("Advertencia") Then

            Dim mensajeAdvertencia As New AdvertenciaForm
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
            mensajeExito.ShowDialog()

        End If

    End Sub

    Private Function ValidarInformacionImpresionLengua() As Boolean
        Dim Resultado As Boolean = True
        Dim ImpresoraId As Integer = 0
        Dim Año As Integer = 0
        Dim LoteInicio As String = String.Empty
        Dim LoteFin As String = String.Empty
        Dim UsuarioID As Integer = 0
        Dim FechaPrograma As Date
        Dim TipoImpresion As Integer = 0

        Try
            ImpresoraId = cmbImpresoraLengua.SelectedValue
            Año = dtpFechaPrograma.Value.Year
            LoteInicio = txtLoteInicioLengua.Text
            LoteFin = txtLoteFinLengua.Text
            UsuarioID = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
            FechaPrograma = dtpFechaPrograma.Value
            TipoImpresion = cmbImpresoraLengua.SelectedValue


            If cmbImpresoraLengua.SelectedIndex > 0 Then
                show_message("Advertencia", "No se ha seleccionado una impresora.")
                Resultado = False
            End If


            If txtLoteInicioLengua.Text = String.Empty Then
                show_message("Advertencia", "No se ha ingresado un numero de lote de inicio.")
            End If

            If txtLoteFinLengua.Text = String.Empty Then
                show_message("Advertencia", "No se ha ingresado un numero de lote de fin.")
            End If


        Catch ex As Exception
            show_message("Error", ex.Message.ToString())
        End Try




        Return Resultado


    End Function

    Private Sub CargarColeccionesLengua(ByVal ClienteID As Integer)
        Dim dtColeccionesLengua As New DataTable

        Try
            dtColeccionesLengua = objBU.ConsultaColeccionesLengua(ClienteID)
            cmbColeccionLengua.DataSource = dtColeccionesLengua
            cmbColeccionLengua.ValueMember = "ColeccionID"
            cmbColeccionLengua.DisplayMember = "Coleccion"

        Catch ex As Exception
            show_message("Error", "Ocurrio un error al cargar las colecciones.")
        End Try

    End Sub

    Private Sub CargarComboClientesLengua()
        Dim dtClientes As DataTable
        Try
            dtClientes = objBU.ObtenerClienesEtiquetasEspecialLengua()
            dtClientes.Rows.InsertAt(dtClientes.NewRow, 0)
            cmbClienteLengua.DataSource = dtClientes
            cmbClienteLengua.ValueMember = "ClienteID"
            cmbClienteLengua.DisplayMember = "Cliente"
        Catch ex As Exception
            show_message("Error", ex.Message)
        End Try
    End Sub


    Private Sub cmbTipoImpresionLengua_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTipoImpresionLengua.SelectedIndexChanged
        lblColeccionLengua.Visible = False
        cmbColeccionLengua.Visible = False
        lblClienteLengua.Visible = False
        cmbClienteLengua.Visible = False
        lblContadorParesLengua.Text = "0"
        txtLoteInicioLengua.Text = String.Empty
        txtLoteFinLengua.Text = String.Empty
        txtLoteInicioLengua.Text = Lista.Min().ToString()
        txtLoteFinLengua.Text = Lista.Max().ToString

        If cmbTipoImpresionLengua.SelectedIndex = 0 Then 'Programa Completo
            txtLoteInicioLengua.Enabled = False
            txtLoteFinLengua.Enabled = False
            txtAmarreLengua.Enabled = False
            txtAmarreLengua.Text = String.Empty
            chkMostrarParesLengua.Enabled = False
            chkMostrarParesLengua.Checked = False
        ElseIf cmbTipoImpresionLengua.SelectedIndex = 1 Then 'Lotes / Atados
            chkMostrarParesLengua.Checked = False
            txtLoteInicioLengua.Enabled = True
            txtLoteFinLengua.Enabled = True
            txtAmarreLengua.Enabled = True
            chkMostrarParesLengua.Enabled = True
        ElseIf cmbTipoImpresionLengua.SelectedIndex = 2 Then 'Etiqueta Especial Coleccion
            chkMostrarParesLengua.Checked = False
            CargarColeccionesLengua(0)
            lblColeccionLengua.Visible = True
            cmbColeccionLengua.Visible = True
            txtLoteInicioLengua.Enabled = True
            txtLoteFinLengua.Enabled = True
            txtAmarreLengua.Enabled = True
            chkMostrarParesLengua.Enabled = True
        ElseIf cmbTipoImpresionLengua.SelectedIndex = 3 Then 'ESPECIAL (LENGUA CLIENTE-COLECCIÓN)
            chkMostrarParesLengua.Checked = False
            'CargarColeccionesLengua()
            CargarComboClientesLengua()
            lblColeccionLengua.Visible = False
            cmbColeccionLengua.Visible = False
            lblClienteLengua.Visible = False
            cmbClienteLengua.Visible = False
            txtLoteInicioLengua.Enabled = True
            txtLoteFinLengua.Enabled = True
            txtAmarreLengua.Enabled = True
            chkMostrarParesLengua.Enabled = True
        End If

    End Sub

#Region "Cliente Prueba"
    Private Sub switch()
        Try
            Dim id As Integer
            'MsgBox(cmbClientesPruebas.SelectedValue.ToString)
            id = IIf(IsNumeric(cmbClientesPruebas.SelectedValue), cmbClientesPruebas.SelectedValue, 0)
            If id > 0 Then
                If id = 763 Or id = 103 Or id = 1230 Then
                    btnImprimirPlantilla.Visible = True
                    lblImprimirPlantilla.Visible = True
                    If id = 103 Or id = 1230 Then
                        gpoPlantilla.Visible = True
                    Else
                        gpoPlantilla.Visible = False
                    End If
                Else
                    btnImprimirPlantilla.Visible = False
                    lblImprimirPlantilla.Visible = False
                    gpoPlantilla.Visible = False
                End If

                If id = 17 Or id = 1358 Then
                    chkLabelMatrixPriceShoes.Visible = True
                    chkLabelMatrixPriceShoes.Enabled = False
                Else
                    chkLabelMatrixPriceShoes.Visible = False
                End If
                'If _UsuarioId = 307 And (id = 103 Or id = 1230) Then
                '    btnImprimirPlantilla.Visible = True
                '    lblImprimirPlantilla.Visible = True
                'Else
                '    btnImprimirPlantilla.Visible = False
                '    lblImprimirPlantilla.Visible = False
                'End If
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

        If dtpApartadofInicial.Value > dtpApartadoFfinal.Value Then
            mensajeAdvertencia("La fecha inicial no puede ser mayor a la fecha final en la busqueda de apartados.")
            Exit Sub
        End If

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
            'lblMostrar.Enabled = True
            dtpApartadofInicial.Focus()
        Else
            dtpApartadofInicial.Enabled = False
            dtpApartadoFfinal.Enabled = False
            btnMostrar.Enabled = False
            grdClientesPruebaApartados.Enabled = False
            'lblMostrar.Enabled = False
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
        Dim dtInformacionArchivoExcel As New DataTable
        Dim dtParesArchivo As New DataTable

        Dim TipoEtiquetaID As Integer = cmbClientesPruebasTipoEtiqueta.SelectedValue
        Dim ClienteID As Integer = cmbClientesPruebas.SelectedValue


        Try
            Cursor = Cursors.WaitCursor

            If EsImpresionConArchivo = True Then
                ofArchivo.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                ofArchivo.Filter = "XLS, XLSX|*.xls;*.xlsx"
                ofArchivo.FilterIndex = 3
                ofArchivo.ShowDialog()

                If ofArchivo.FileName = "" Then
                    'show_message("Advertencia","Es necesario seleccionar un archivo de excel")
                    Return
                End If

                Dim nombresplit = ofArchivo.FileName.Split("\")
                Dim NombreArchivo As String = nombresplit(nombresplit.Length - 1)
                NombreArchivo = NombreArchivo.Replace(".xlsx", "")

                If txtPedidoSICY.Text Is Nothing Then
                    show_message("Advertencia", "No se ha capturado el pedido SICY.")
                    Return
                Else
                    If NombreArchivo <> txtPedidoSICY.Text Then
                        show_message("Advertencia", "El pedido SICY no coincide con el nombre del archivo.")
                        Return
                    End If
                End If

                dtInformacionArchivoExcel = LeerExcel(ofArchivo.FileName)
                Cursor = Cursors.WaitCursor
                objBU.EliminarInformacionImpresionArchivo(Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)

                Dim dtFiltroInformacion = dtInformacionArchivoExcel.AsEnumerable.Where(Function(x) x.Item("Serie").ToString <> String.Empty)

                For Each Fila As DataRow In dtFiltroInformacion
                    objBU.ImpresionConArchivo(Fila.Item("Serie").ToString, Fila.Item("Estilo").ToString, Fila.Item("Color"), Fila.Item("Marca").ToString, Fila.Item("Punto").ToString, Fila.Item("Pedido").ToString, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, cmbClientesPruebas.SelectedValue)
                Next

                dtParesArchivo = objBU.ImpresionArchivo(Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, cmbImpresoraClientesPruebas.SelectedValue, cmbClientesPruebas.SelectedValue, cmbClientesPruebasTipoEtiqueta.SelectedValue)

                If dtParesArchivo.Rows.Count > 0 Then
                    GeneraArchivosParaImpresion_ConArchivo(dtParesArchivo)
                    GuardarBitacoraImpresion(TipoEtiquetaID, 0, 0, 0, ClienteID)
                    'GuardarBitacoraImpresion(TipoEtiquetaID, txtLoteDelClientesPrueba.Text, txtLoteAlClientesPruebas.Text, 0, ClienteID)
                    'ejecutarBat()
                Else
                    show_message("Advertencia", "El archivo no tiene información.")
                End If


                Return

            End If

            'CarlosMtz 
            If cmbClientesPruebas.SelectedValue = 103 Or cmbClientesPruebas.SelectedValue = 1230 Or  'Hermanos Batta
                cmbClientesPruebas.SelectedValue = 763 Or cmbClientesPruebas.SelectedValue = 1181 Then 'Coppel
                If EsImpresoraNiceLabel(cmbImpresoraClientesPruebas.SelectedValue) = False Then
                    mensajeAdvertencia("Debe seleccionar una impresora de NiceLabel.")
                    Exit Sub
                End If
            End If

            ' CarlosMtz 
            ' Valida que sea cliente Coppel y que el tipo de etiqueta sea de Par Especial Niño y Adulto
            If cmbClientesPruebas.SelectedValue = 763 Or cmbClientesPruebas.SelectedValue = 1181 Then
                If cmbClientesPruebasTipoEtiqueta.SelectedValue <> 25 And cmbClientesPruebasTipoEtiqueta.SelectedValue <> 26 Then
                    mensajeAdvertencia("Debe Seleccionar al menos un tipo de etiqueta Adulto o Niño.")
                    Exit Sub
                End If
            ElseIf cmbClientesPruebasTipoEtiqueta.Text = "" Then
                mensajeAdvertencia("Debe Seleccionar al menos un tipo de etiqueta.")
                Exit Sub
            End If


            If rbLotes.Checked Then
                If txtLoteDelClientesPrueba.Text = "" Then
                    mensajeAdvertencia("El campo de lote del: no puede estar vacío.", txtLoteDelClientesPrueba)
                    Exit Sub
                End If

                If txtLoteAlClientesPruebas.Text = "" Then
                    mensajeAdvertencia("El campo de lote al: no puede estar vacío.", txtLoteAlClientesPruebas)
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


                If cmbClientesPruebas.SelectedValue = 103 Or cmbClientesPruebas.SelectedValue = 1230 Then 'Hermanos Batta
                    'cmbClientesPruebas.SelectedValue = 763 Or cmbClientesPruebas.SelectedValue = 1181 Then 'Coppel 
                    'BATTA
                    'descarga las imagenes de Batta
                    'CarlosMtz
                    'CopiarImagenesBatta(True, txtLoteDelClientesPrueba.Text, txtLoteAlClientesPruebas.Text, _idNave, dtpFechaPrograma.Value, False, 0, 0, False, "")
                    CopiarImagenesBatta(True, txtLoteDelClientesPrueba.Text, txtLoteAlClientesPruebas.Text, _idNave, dtpFechaPrograma.Value, False, 0, 0, False, "", cmbClientesPruebas.SelectedValue)
                    If _Accion = 1 Then
                        If chkMostrarDetalles.Checked = True Then
                            dtZpl = objNeg.ImprimeEtiquetasBattaOpcionesCliente_ConsultaDetalles(cmbImpresoraClientesPruebas.SelectedValue, _UsuarioId, cmbClientesPruebas.SelectedValue, cmbClientesPruebasTipoEtiqueta.SelectedValue, chkMostrarDetalles.Checked, True, cmbClientesPruebasNaves.SelectedValue, dtClientesPruebaFechaPrograma.Value, txtLoteDelClientesPrueba.Text.Trim, txtLoteAlClientesPruebas.Text.Trim, False, 0, 0, False, "")
                        Else
                            dtZpl = objNeg.ImprimeEtiquetasBattaOpcionesCliente(cmbImpresoraClientesPruebas.SelectedValue, _UsuarioId, cmbClientesPruebas.SelectedValue, cmbClientesPruebasTipoEtiqueta.SelectedValue, chkMostrarDetalles.Checked, True, cmbClientesPruebasNaves.SelectedValue, dtClientesPruebaFechaPrograma.Value, txtLoteDelClientesPrueba.Text.Trim, txtLoteAlClientesPruebas.Text.Trim, False, 0, 0, False, "")
                            'Proceso de excel para BATTA
                            CrearExcelBatta(dtZpl)
                        End If
                    Else
                        'dtZpl = objNeg.ImprimeEtiquetasBattaOpcionesCliente(cmbImpresoraClientesPruebas.SelectedValue, _UsuarioId, cmbClientesPruebas.SelectedValue, cmbClientesPruebasTipoEtiqueta.SelectedValue, chkMostrarDetalles.Checked, True, cmbClientesPruebasNaves.SelectedValue, dtClientesPruebaFechaPrograma.Value, txtLoteDelClientesPrueba.Text.Trim, txtLoteAlClientesPruebas.Text.Trim, False, 0, 0, False, "")
                        If chkMostrarDetalles.Checked = True Then
                            dtZpl = objNeg.ImprimeEtiquetasBattaOpcionesCliente_ConsultaDetalles(cmbImpresoraClientesPruebas.SelectedValue, _UsuarioId, cmbClientesPruebas.SelectedValue, cmbClientesPruebasTipoEtiqueta.SelectedValue, chkMostrarDetalles.Checked, True, cmbClientesPruebasNaves.SelectedValue, dtClientesPruebaFechaPrograma.Value, txtLoteDelClientesPrueba.Text.Trim, txtLoteAlClientesPruebas.Text.Trim, False, 0, 0, False, "")
                        Else
                            dtZpl = objNeg.ImprimeEtiquetasBattaOpcionesCliente(cmbImpresoraClientesPruebas.SelectedValue, _UsuarioId, cmbClientesPruebas.SelectedValue, cmbClientesPruebasTipoEtiqueta.SelectedValue, chkMostrarDetalles.Checked, True, cmbClientesPruebasNaves.SelectedValue, dtClientesPruebaFechaPrograma.Value, txtLoteDelClientesPrueba.Text.Trim, txtLoteAlClientesPruebas.Text.Trim, False, 0, 0, False, "")
                            'Proceso de excel para BATTA
                            CrearExcelBatta(dtZpl)
                        End If
                    End If

                    ' CarlosMtz
                    ' PROCESO COPPEL CON IMAGENES JPG IMPRESION DE COLOR
                ElseIf cmbClientesPruebas.SelectedValue = 763 Or cmbClientesPruebas.SelectedValue = 1181 Then
                    CopiarImagenesBatta(True, txtLoteDelClientesPrueba.Text, txtLoteAlClientesPruebas.Text, _idNave, dtpFechaPrograma.Value, False, 0, 0, False, "", cmbClientesPruebas.SelectedValue)
                    DescargarNiceLabeCoppel(cmbClientesPruebasTipoEtiqueta.SelectedValue)
                    If _Accion = 1 Then
                        If chkMostrarDetalles.Checked Then
                            dtZpl = objNeg.ImprimeEtiquetasCoppelOpcionesCliente_ConsultaDetalles(cmbImpresoraClientesPruebas.SelectedValue, _UsuarioId, cmbClientesPruebas.SelectedValue, cmbClientesPruebasTipoEtiqueta.SelectedValue, chkMostrarDetalles.Checked, True, cmbClientesPruebasNaves.SelectedValue, dtClientesPruebaFechaPrograma.Value, txtLoteDelClientesPrueba.Text.Trim, txtLoteAlClientesPruebas.Text.Trim, False, 0, 0, False, "")
                            If dtZpl.Rows.Count < 1 Then
                                mensajeCoppel()
                                Exit Sub
                            End If
                        Else
                            dtZpl = objNeg.ImprimeEtiquetasCoppelOpcionesCliente(cmbImpresoraClientesPruebas.SelectedValue, _UsuarioId, cmbClientesPruebas.SelectedValue, cmbClientesPruebasTipoEtiqueta.SelectedValue, chkMostrarDetalles.Checked, True, cmbClientesPruebasNaves.SelectedValue, dtClientesPruebaFechaPrograma.Value, txtLoteDelClientesPrueba.Text.Trim, txtLoteAlClientesPruebas.Text.Trim, False, 0, 0, False, "")
                            If dtZpl.Rows.Count > 0 Then
                                CrearExcelBatta(dtZpl)
                            Else
                                mensajeCoppel()
                                Exit Sub
                            End If

                        End If
                    Else
                        If chkMostrarDetalles.Checked Then
                            dtZpl = objNeg.ImprimeEtiquetasCoppelOpcionesCliente_ConsultaDetalles(cmbImpresoraClientesPruebas.SelectedValue, _UsuarioId, cmbClientesPruebas.SelectedValue, cmbClientesPruebasTipoEtiqueta.SelectedValue, chkMostrarDetalles.Checked, True, cmbClientesPruebasNaves.SelectedValue, dtClientesPruebaFechaPrograma.Value, txtLoteDelClientesPrueba.Text.Trim, txtLoteAlClientesPruebas.Text.Trim, False, 0, 0, False, "")
                            If dtZpl.Rows.Count < 1 Then
                                mensajeCoppel()
                                Exit Sub
                            End If
                        Else
                            dtZpl = objNeg.ImprimeEtiquetasCoppelOpcionesCliente(cmbImpresoraClientesPruebas.SelectedValue, _UsuarioId, cmbClientesPruebas.SelectedValue, cmbClientesPruebasTipoEtiqueta.SelectedValue, chkMostrarDetalles.Checked, True, cmbClientesPruebasNaves.SelectedValue, dtClientesPruebaFechaPrograma.Value, txtLoteDelClientesPrueba.Text.Trim, txtLoteAlClientesPruebas.Text.Trim, False, 0, 0, False, "")
                            If dtZpl.Rows.Count > 0 Then
                                CrearExcelBatta(dtZpl)
                            Else
                                mensajeCoppel()
                                Exit Sub
                            End If

                        End If
                    End If
                ElseIf cmbClientesPruebas.SelectedValue = 17 Or cmbClientesPruebas.SelectedValue = 1358 And chkLabelMatrixPriceShoes.Checked Then
                    CopiarImagenesBatta(True, txtLoteDelClientesPrueba.Text, txtLoteAlClientesPruebas.Text, _idNave, dtpFechaPrograma.Value, False, 0, 0, False, "", cmbClientesPruebas.SelectedValue)
                    dtZpl = objNeg.ImprimeEtiquetasPriceShoes(cmbImpresoraClientesPruebas.SelectedValue, _UsuarioId, cmbClientesPruebas.SelectedValue, cmbClientesPruebasTipoEtiqueta.SelectedValue, chkMostrarDetalles.Checked, True, cmbClientesPruebasNaves.SelectedValue, dtClientesPruebaFechaPrograma.Value, txtLoteDelClientesPrueba.Text.Trim, txtLoteAlClientesPruebas.Text.Trim, False, 0, 0, False, "")
                    If dtZpl.Rows.Count > 0 Then
                        CrearExcelBatta(dtZpl)
                    End If
                Else
                    If _Accion = 1 Then
                        dtZpl = objNeg.ImprimirClientesProduccion(cmbImpresoraClientesPruebas.SelectedValue, _UsuarioId, cmbClientesPruebas.SelectedValue, cmbClientesPruebasTipoEtiqueta.SelectedValue, chkMostrarDetalles.Checked, True, cmbClientesPruebasNaves.SelectedValue, dtClientesPruebaFechaPrograma.Value, txtLoteDelClientesPrueba.Text.Trim, txtLoteAlClientesPruebas.Text.Trim, False, 0, 0, False, "")
                    ElseIf _Accion = 2 Then
                        dtZpl = objNeg.ImprimirClientesPrueba(cmbImpresoraClientesPruebas.SelectedValue, _UsuarioId, cmbClientesPruebas.SelectedValue, cmbClientesPruebasTipoEtiqueta.SelectedValue, chkMostrarDetalles.Checked, True, cmbClientesPruebasNaves.SelectedValue, dtClientesPruebaFechaPrograma.Value, txtLoteDelClientesPrueba.Text.Trim, txtLoteAlClientesPruebas.Text.Trim, False, 0, 0, False, "")
                    End If
                End If




            ElseIf rbPedidoSay.Checked Then
                If txtPedidoSAY.Text = "" Then
                    mensajeAdvertencia("El campo pedido say no puede estar vacío.", txtPedidoSAY)
                    Exit Sub
                End If

                ' Proceso BATTA
                If cmbClientesPruebas.SelectedValue = 103 Or cmbClientesPruebas.SelectedValue = 1230 Then

                    CopiarImagenesBatta(False, "0", "0", _idNave, dtpFechaPrograma.Value, True, txtPedidoSAY.Text, 0, False, "", cmbClientesPruebas.SelectedValue)

                    If _Accion = 1 Then
                        If chkMostrarDetalles.Checked = True Then
                            dtZpl = objNeg.ImprimeEtiquetasBattaOpcionesCliente_ConsultaDetalles(cmbImpresoraClientesPruebas.SelectedValue, _UsuarioId, cmbClientesPruebas.SelectedValue, cmbClientesPruebasTipoEtiqueta.SelectedValue, chkMostrarDetalles.Checked, False, 0, dtClientesPruebaFechaPrograma.Value, 0, 0, True, 0, txtPedidoSAY.Text, False, "")
                        Else
                            dtZpl = objNeg.ImprimeEtiquetasBattaOpcionesCliente(cmbImpresoraClientesPruebas.SelectedValue, _UsuarioId, cmbClientesPruebas.SelectedValue, cmbClientesPruebasTipoEtiqueta.SelectedValue, chkMostrarDetalles.Checked, False, 0, dtClientesPruebaFechaPrograma.Value, 0, 0, True, 0, txtPedidoSAY.Text, False, "")
                            'Proceso de excel para BATTA
                            CrearExcelBatta(dtZpl)
                        End If
                        'dtZpl = objNeg.ImprimeEtiquetasBattaOpcionesCliente(cmbImpresoraClientesPruebas.SelectedValue, _UsuarioId, cmbClientesPruebas.SelectedValue, cmbClientesPruebasTipoEtiqueta.SelectedValue, chkMostrarDetalles.Checked, False, 0, dtClientesPruebaFechaPrograma.Value, 0, 0, True, 0, txtPedidoSAY.Text, False, "")
                    Else
                        If chkMostrarDetalles.Checked = True Then
                            dtZpl = objNeg.ImprimeEtiquetasBattaOpcionesCliente_ConsultaDetalles(cmbImpresoraClientesPruebas.SelectedValue, _UsuarioId, cmbClientesPruebas.SelectedValue, cmbClientesPruebasTipoEtiqueta.SelectedValue, chkMostrarDetalles.Checked, False, 0, dtClientesPruebaFechaPrograma.Value, 0, 0, True, 0, txtPedidoSAY.Text, False, "")
                        Else
                            dtZpl = objNeg.ImprimeEtiquetasBattaOpcionesCliente(cmbImpresoraClientesPruebas.SelectedValue, _UsuarioId, cmbClientesPruebas.SelectedValue, cmbClientesPruebasTipoEtiqueta.SelectedValue, chkMostrarDetalles.Checked, False, 0, dtClientesPruebaFechaPrograma.Value, 0, 0, True, 0, txtPedidoSAY.Text, False, "")
                            'Proceso de excel para BATTA
                            CrearExcelBatta(dtZpl)
                        End If
                        'dtZpl = objNeg.ImprimeEtiquetasBattaOpcionesCliente(cmbImpresoraClientesPruebas.SelectedValue, _UsuarioId, cmbClientesPruebas.SelectedValue, cmbClientesPruebasTipoEtiqueta.SelectedValue, chkMostrarDetalles.Checked, False, 0, dtClientesPruebaFechaPrograma.Value, 0, 0, True, 0, txtPedidoSAY.Text, False, "")
                    End If

                    ' CarlosMtz
                    ' PROCESO COPPEL CON IMAGENES JPG IMPRESION DE COLOR
                ElseIf cmbClientesPruebas.SelectedValue = 763 Or cmbClientesPruebas.SelectedValue = 1181 Then 'COPPEL
                    CopiarImagenesBatta(False, "0", "0", _idNave, dtpFechaPrograma.Value, True, txtPedidoSAY.Text, 0, False, "", cmbClientesPruebas.SelectedValue)
                    DescargarNiceLabeCoppel(cmbClientesPruebasTipoEtiqueta.SelectedValue)
                    If _Accion = 1 Then
                        If chkMostrarDetalles.Checked Then
                            dtZpl = objNeg.ImprimeEtiquetasCoppelOpcionesCliente_ConsultaDetalles(cmbImpresoraClientesPruebas.SelectedValue, _UsuarioId, cmbClientesPruebas.SelectedValue, cmbClientesPruebasTipoEtiqueta.SelectedValue, chkMostrarDetalles.Checked, False, 0, dtClientesPruebaFechaPrograma.Value, 0, 0, True, 0, txtPedidoSAY.Text, False, "")
                            If dtZpl.Rows.Count < 1 Then
                                mensajeCoppel()
                                Exit Sub
                            End If
                        Else
                            dtZpl = objNeg.ImprimeEtiquetasCoppelOpcionesCliente(cmbImpresoraClientesPruebas.SelectedValue, _UsuarioId, cmbClientesPruebas.SelectedValue, cmbClientesPruebasTipoEtiqueta.SelectedValue, chkMostrarDetalles.Checked, False, 0, dtClientesPruebaFechaPrograma.Value, 0, 0, True, 0, txtPedidoSAY.Text, False, "")
                            If dtZpl.Rows.Count > 0 Then
                                CrearExcelBatta(dtZpl)
                            Else
                                mensajeCoppel()
                                Exit Sub
                            End If
                        End If
                    Else
                        If chkMostrarDetalles.Checked Then
                            dtZpl = objNeg.ImprimeEtiquetasCoppelOpcionesCliente_ConsultaDetalles(cmbImpresoraClientesPruebas.SelectedValue, _UsuarioId, cmbClientesPruebas.SelectedValue, cmbClientesPruebasTipoEtiqueta.SelectedValue, chkMostrarDetalles.Checked, False, 0, dtClientesPruebaFechaPrograma.Value, 0, 0, True, 0, txtPedidoSAY.Text, False, "")
                            If dtZpl.Rows.Count < 1 Then
                                mensajeCoppel()
                                Exit Sub
                            End If
                        Else
                            dtZpl = objNeg.ImprimeEtiquetasCoppelOpcionesCliente(cmbImpresoraClientesPruebas.SelectedValue, _UsuarioId, cmbClientesPruebas.SelectedValue, cmbClientesPruebasTipoEtiqueta.SelectedValue, chkMostrarDetalles.Checked, False, 0, dtClientesPruebaFechaPrograma.Value, 0, 0, True, 0, txtPedidoSAY.Text, False, "")
                            If dtZpl.Rows.Count > 0 Then
                                CrearExcelBatta(dtZpl)
                            Else
                                mensajeCoppel()
                                Exit Sub
                            End If
                        End If
                    End If
                ElseIf cmbClientesPruebas.SelectedValue = 17 Or cmbClientesPruebas.SelectedValue = 1358 And chkLabelMatrixPriceShoes.Checked Then
                    CopiarImagenesBatta(False, "0", "0", _idNave, dtpFechaPrograma.Value, True, txtPedidoSAY.Text, 0, False, "", cmbClientesPruebas.SelectedValue)
                    dtZpl = objNeg.ImprimeEtiquetasPriceShoes(cmbImpresoraClientesPruebas.SelectedValue, _UsuarioId, cmbClientesPruebas.SelectedValue, cmbClientesPruebasTipoEtiqueta.SelectedValue, chkMostrarDetalles.Checked, False, 0, dtClientesPruebaFechaPrograma.Value, 0, 0, True, 0, txtPedidoSAY.Text, False, "")
                    If dtZpl.Rows.Count > 0 Then
                        CrearExcelBatta(dtZpl)
                    End If
                Else
                    If _Accion = 1 Then
                        dtZpl = objNeg.ImprimirClientesProduccion(cmbImpresoraClientesPruebas.SelectedValue, _UsuarioId, cmbClientesPruebas.SelectedValue, cmbClientesPruebasTipoEtiqueta.SelectedValue, chkMostrarDetalles.Checked, False, 0, dtClientesPruebaFechaPrograma.Value, 0, 0, True, 0, txtPedidoSAY.Text, False, "")
                    ElseIf _Accion = 2 Then
                        dtZpl = objNeg.ImprimirClientesPrueba(cmbImpresoraClientesPruebas.SelectedValue, _UsuarioId, cmbClientesPruebas.SelectedValue, cmbClientesPruebasTipoEtiqueta.SelectedValue, chkMostrarDetalles.Checked, False, 0, dtClientesPruebaFechaPrograma.Value, 0, 0, True, 0, txtPedidoSAY.Text, False, "")
                    End If
                End If

            ElseIf rbPedidoSicy.Checked Then
                If txtPedidoSICY.Text = "" Then
                    mensajeAdvertencia("El campo pedido sicy no puede estar vacío.", txtPedidoSICY)
                    Exit Sub
                End If

                If cmbClientesPruebas.SelectedValue = 103 Or cmbClientesPruebas.SelectedValue = 1230 Then 'BATTA

                    CopiarImagenesBatta(False, "0", "0", _idNave, dtpFechaPrograma.Value, True, 0, txtPedidoSICY.Text, False, "", cmbClientesPruebas.SelectedValue)
                    If _Accion = 1 Then
                        If chkMostrarDetalles.Checked = True Then
                            dtZpl = objNeg.ImprimeEtiquetasBattaOpcionesCliente_ConsultaDetalles(cmbImpresoraClientesPruebas.SelectedValue, _UsuarioId, cmbClientesPruebas.SelectedValue, cmbClientesPruebasTipoEtiqueta.SelectedValue, chkMostrarDetalles.Checked, False, 0, dtClientesPruebaFechaPrograma.Value, 0, 0, True, txtPedidoSICY.Text, 0, False, "")
                        Else
                            dtZpl = objNeg.ImprimeEtiquetasBattaOpcionesCliente(cmbImpresoraClientesPruebas.SelectedValue, _UsuarioId, cmbClientesPruebas.SelectedValue, cmbClientesPruebasTipoEtiqueta.SelectedValue, chkMostrarDetalles.Checked, False, 0, dtClientesPruebaFechaPrograma.Value, 0, 0, True, txtPedidoSICY.Text, 0, False, "")
                            'Proceso de excel para BATTA
                            CrearExcelBatta(dtZpl)
                        End If

                    Else
                        If chkMostrarDetalles.Checked = True Then
                            dtZpl = objNeg.ImprimeEtiquetasBattaOpcionesCliente_ConsultaDetalles(cmbImpresoraClientesPruebas.SelectedValue, _UsuarioId, cmbClientesPruebas.SelectedValue, cmbClientesPruebasTipoEtiqueta.SelectedValue, chkMostrarDetalles.Checked, False, 0, dtClientesPruebaFechaPrograma.Value, 0, 0, True, txtPedidoSICY.Text, 0, False, "")
                        Else
                            dtZpl = objNeg.ImprimeEtiquetasBattaOpcionesCliente(cmbImpresoraClientesPruebas.SelectedValue, _UsuarioId, cmbClientesPruebas.SelectedValue, cmbClientesPruebasTipoEtiqueta.SelectedValue, chkMostrarDetalles.Checked, False, 0, dtClientesPruebaFechaPrograma.Value, 0, 0, True, txtPedidoSICY.Text, 0, False, "")
                            'Proceso de excel para BATTA
                            CrearExcelBatta(dtZpl)
                        End If
                        'dtZpl = objNeg.ImprimeEtiquetasBattaOpcionesCliente(cmbImpresoraClientesPruebas.SelectedValue, _UsuarioId, cmbClientesPruebas.SelectedValue, cmbClientesPruebasTipoEtiqueta.SelectedValue, chkMostrarDetalles.Checked, False, 0, dtClientesPruebaFechaPrograma.Value, 0, 0, True, txtPedidoSICY.Text, 0, False, "")
                    End If

                    ' CarlosMtz
                    ' PROCESO COPPEL CON IMAGENES JPG IMPRESION DE COLOR
                ElseIf cmbClientesPruebas.SelectedValue = 763 Or cmbClientesPruebas.SelectedValue = 1181 Then 'Coppel
                    CopiarImagenesBatta(False, "0", "0", _idNave, dtpFechaPrograma.Value, True, 0, txtPedidoSICY.Text, False, "", cmbClientesPruebas.SelectedValue)
                    DescargarNiceLabeCoppel(cmbClientesPruebasTipoEtiqueta.SelectedValue)
                    If _Accion = 1 Then
                        If chkMostrarDetalles.Checked Then
                            dtZpl = objNeg.ImprimeEtiquetasCoppelOpcionesCliente_ConsultaDetalles(cmbImpresoraClientesPruebas.SelectedValue, _UsuarioId, cmbClientesPruebas.SelectedValue, cmbClientesPruebasTipoEtiqueta.SelectedValue, chkMostrarDetalles.Checked, False, 0, dtClientesPruebaFechaPrograma.Value, 0, 0, True, txtPedidoSICY.Text, 0, False, "")
                            If dtZpl.Rows.Count < 1 Then
                                mensajeCoppel()
                                Exit Sub
                            End If
                        Else
                            If dtZpl.Rows.Count > 0 Then
                                dtZpl = objNeg.ImprimeEtiquetasCoppelOpcionesCliente(cmbImpresoraClientesPruebas.SelectedValue, _UsuarioId, cmbClientesPruebas.SelectedValue, cmbClientesPruebasTipoEtiqueta.SelectedValue, chkMostrarDetalles.Checked, False, 0, dtClientesPruebaFechaPrograma.Value, 0, 0, True, txtPedidoSICY.Text, 0, False, "")
                                CrearExcelBatta(dtZpl)
                            Else
                                mensajeCoppel()
                                Exit Sub
                            End If

                        End If
                    Else
                        If chkMostrarDetalles.Checked Then
                            dtZpl = objNeg.ImprimeEtiquetasCoppelOpcionesCliente_ConsultaDetalles(cmbImpresoraClientesPruebas.SelectedValue, _UsuarioId, cmbClientesPruebas.SelectedValue, cmbClientesPruebasTipoEtiqueta.SelectedValue, chkMostrarDetalles.Checked, False, 0, dtClientesPruebaFechaPrograma.Value, 0, 0, True, txtPedidoSICY.Text, 0, False, "")
                            If dtZpl.Rows.Count < 1 Then
                                mensajeCoppel()
                                Exit Sub
                            End If
                        Else
                            dtZpl = objNeg.ImprimeEtiquetasCoppelOpcionesCliente(cmbImpresoraClientesPruebas.SelectedValue, _UsuarioId, cmbClientesPruebas.SelectedValue, cmbClientesPruebasTipoEtiqueta.SelectedValue, chkMostrarDetalles.Checked, False, 0, dtClientesPruebaFechaPrograma.Value, 0, 0, True, txtPedidoSICY.Text, 0, False, "")
                            If dtZpl.Rows.Count > 0 Then
                                CrearExcelBatta(dtZpl)
                            Else
                                mensajeCoppel()
                                Exit Sub
                            End If

                        End If

                    End If
                ElseIf cmbClientesPruebas.SelectedValue = 17 Or cmbClientesPruebas.SelectedValue = 1358 And chkLabelMatrixPriceShoes.Checked Then
                    CopiarImagenesBatta(False, "0", "0", _idNave, dtpFechaPrograma.Value, True, 0, txtPedidoSICY.Text, False, "", cmbClientesPruebas.SelectedValue)
                    dtZpl = objNeg.ImprimeEtiquetasPriceShoes(cmbImpresoraClientesPruebas.SelectedValue, _UsuarioId, cmbClientesPruebas.SelectedValue, cmbClientesPruebasTipoEtiqueta.SelectedValue, chkMostrarDetalles.Checked, False, 0, dtClientesPruebaFechaPrograma.Value, 0, 0, True, txtPedidoSICY.Text, 0, False, "")
                    If dtZpl.Rows.Count > 0 Then
                        CrearExcelBatta(dtZpl)
                    End If
                Else
                    If _Accion = 1 Then
                        dtZpl = objNeg.ImprimirClientesProduccion(cmbImpresoraClientesPruebas.SelectedValue, _UsuarioId, cmbClientesPruebas.SelectedValue, cmbClientesPruebasTipoEtiqueta.SelectedValue, chkMostrarDetalles.Checked, False, 0, dtClientesPruebaFechaPrograma.Value, 0, 0, True, txtPedidoSICY.Text, 0, False, "")
                    ElseIf _Accion = 2 Then
                        dtZpl = objNeg.ImprimirClientesPrueba(cmbImpresoraClientesPruebas.SelectedValue, _UsuarioId, cmbClientesPruebas.SelectedValue, cmbClientesPruebasTipoEtiqueta.SelectedValue, chkMostrarDetalles.Checked, False, 0, dtClientesPruebaFechaPrograma.Value, 0, 0, True, txtPedidoSICY.Text, 0, False, "")
                    End If
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

                        If cmbClientesPruebas.SelectedValue = 103 Or cmbClientesPruebas.SelectedValue = 1230 Then 'BATTA
                            'CarlosMtz
                            CopiarImagenesBatta(False, "0", "0", _idNave, dtpFechaPrograma.Value, False, 0, 0, True, sb.ToString, cmbClientesPruebas.SelectedValue)
                            If _Accion = 1 Then
                                If chkMostrarDetalles.Checked = True Then
                                    dtZpl = objNeg.ImprimeEtiquetasBattaOpcionesCliente_ConsultaDetalles(cmbImpresoraClientesPruebas.SelectedValue, _UsuarioId, cmbClientesPruebas.SelectedValue, cmbClientesPruebasTipoEtiqueta.SelectedValue, chkMostrarDetalles.Checked, False, 0, dtClientesPruebaFechaPrograma.Value, 0, 0, False, 0, 0, True, sb.ToString)
                                Else
                                    dtZpl = objNeg.ImprimeEtiquetasBattaOpcionesCliente(cmbImpresoraClientesPruebas.SelectedValue, _UsuarioId, cmbClientesPruebas.SelectedValue, cmbClientesPruebasTipoEtiqueta.SelectedValue, chkMostrarDetalles.Checked, False, 0, dtClientesPruebaFechaPrograma.Value, 0, 0, False, 0, 0, True, sb.ToString)
                                    'Proceso de excel para BATTA
                                    CrearExcelBatta(dtZpl)
                                End If
                            Else
                                If chkMostrarDetalles.Checked = True Then
                                    dtZpl = objNeg.ImprimeEtiquetasBattaOpcionesCliente_ConsultaDetalles(cmbImpresoraClientesPruebas.SelectedValue, _UsuarioId, cmbClientesPruebas.SelectedValue, cmbClientesPruebasTipoEtiqueta.SelectedValue, chkMostrarDetalles.Checked, False, 0, dtClientesPruebaFechaPrograma.Value, 0, 0, False, 0, 0, True, sb.ToString)
                                Else
                                    dtZpl = objNeg.ImprimeEtiquetasBattaOpcionesCliente(cmbImpresoraClientesPruebas.SelectedValue, _UsuarioId, cmbClientesPruebas.SelectedValue, cmbClientesPruebasTipoEtiqueta.SelectedValue, chkMostrarDetalles.Checked, False, 0, dtClientesPruebaFechaPrograma.Value, 0, 0, False, 0, 0, True, sb.ToString)
                                    'Proceso de excel para BATTA
                                    CrearExcelBatta(dtZpl)
                                End If
                                'dtZpl = objNeg.ImprimeEtiquetasBattaOpcionesCliente(cmbImpresoraClientesPruebas.SelectedValue, _UsuarioId, cmbClientesPruebas.SelectedValue, cmbClientesPruebasTipoEtiqueta.SelectedValue, chkMostrarDetalles.Checked, False, 0, dtClientesPruebaFechaPrograma.Value, 0, 0, False, 0, 0, True, sb.ToString)
                            End If

                            ' CarlosMtz
                            ' PROCESO COPPEL CON IMAGENES JPG IMPRESION DE COLOR
                        ElseIf cmbClientesPruebas.SelectedValue = 763 Or cmbClientesPruebas.SelectedValue = 1181 Then 'Coppel
                            CopiarImagenesBatta(False, "0", "0", _idNave, dtpFechaPrograma.Value, False, 0, 0, True, sb.ToString, cmbClientesPruebas.SelectedValue)
                            DescargarNiceLabeCoppel(cmbClientesPruebasTipoEtiqueta.SelectedValue)
                            If _Accion = 1 Then
                                If chkMostrarDetalles.Checked Then
                                    dtZpl = objNeg.ImprimeEtiquetasCoppelOpcionesCliente_ConsultaDetalles(cmbImpresoraClientesPruebas.SelectedValue, _UsuarioId, cmbClientesPruebas.SelectedValue, cmbClientesPruebasTipoEtiqueta.SelectedValue, chkMostrarDetalles.Checked, False, 0, dtClientesPruebaFechaPrograma.Value, 0, 0, False, 0, 0, True, sb.ToString)
                                    If dtZpl.Rows.Count < 1 Then
                                        mensajeCoppel()
                                        Exit Sub
                                    End If
                                Else
                                    dtZpl = objNeg.ImprimeEtiquetasCoppelOpcionesCliente(cmbImpresoraClientesPruebas.SelectedValue, _UsuarioId, cmbClientesPruebas.SelectedValue, cmbClientesPruebasTipoEtiqueta.SelectedValue, chkMostrarDetalles.Checked, False, 0, dtClientesPruebaFechaPrograma.Value, 0, 0, False, 0, 0, True, sb.ToString)
                                    If dtZpl.Rows.Count > 0 Then
                                        CrearExcelBatta(dtZpl)
                                    Else
                                        mensajeCoppel()
                                        Exit Sub
                                    End If
                                End If
                            Else
                                If chkMostrarDetalles.Checked Then
                                    dtZpl = objNeg.ImprimeEtiquetasCoppelOpcionesCliente_ConsultaDetalles(cmbImpresoraClientesPruebas.SelectedValue, _UsuarioId, cmbClientesPruebas.SelectedValue, cmbClientesPruebasTipoEtiqueta.SelectedValue, chkMostrarDetalles.Checked, False, 0, dtClientesPruebaFechaPrograma.Value, 0, 0, False, 0, 0, True, sb.ToString)
                                    If dtZpl.Rows.Count < 1 Then
                                        mensajeCoppel()
                                        Exit Sub
                                    End If
                                Else
                                    dtZpl = objNeg.ImprimeEtiquetasCoppelOpcionesCliente(cmbImpresoraClientesPruebas.SelectedValue, _UsuarioId, cmbClientesPruebas.SelectedValue, cmbClientesPruebasTipoEtiqueta.SelectedValue, chkMostrarDetalles.Checked, False, 0, dtClientesPruebaFechaPrograma.Value, 0, 0, False, 0, 0, True, sb.ToString)
                                    If dtZpl.Rows.Count < 0 Then
                                        CrearExcelBatta(dtZpl)
                                    Else
                                        mensajeCoppel()
                                        Exit Sub
                                    End If

                                End If

                            End If

                        ElseIf cmbClientesPruebas.SelectedValue = 17 Or cmbClientesPruebas.SelectedValue = 1358 And chkLabelMatrixPriceShoes.Checked Then
                            CopiarImagenesBatta(False, "0", "0", _idNave, dtpFechaPrograma.Value, False, 0, 0, True, sb.ToString, cmbClientesPruebas.SelectedValue)
                            dtZpl = objNeg.ImprimeEtiquetasPriceShoes(cmbImpresoraClientesPruebas.SelectedValue, _UsuarioId, cmbClientesPruebas.SelectedValue, cmbClientesPruebasTipoEtiqueta.SelectedValue, chkMostrarDetalles.Checked, False, 0, dtClientesPruebaFechaPrograma.Value, 0, 0, False, 0, 0, True, sb.ToString)
                            If dtZpl.Rows.Count > 0 Then
                                CrearExcelBatta(dtZpl)
                            End If
                        Else
                            If _Accion = 1 Then
                                dtZpl = objNeg.ImprimirClientesProduccion(cmbImpresoraClientesPruebas.SelectedValue, _UsuarioId, cmbClientesPruebas.SelectedValue, cmbClientesPruebasTipoEtiqueta.SelectedValue, chkMostrarDetalles.Checked, False, 0, dtClientesPruebaFechaPrograma.Value, 0, 0, False, 0, 0, True, sb.ToString)
                            ElseIf _Accion = 2 Then
                                dtZpl = objNeg.ImprimirClientesPrueba(cmbImpresoraClientesPruebas.SelectedValue, _UsuarioId, cmbClientesPruebas.SelectedValue, cmbClientesPruebasTipoEtiqueta.SelectedValue, chkMostrarDetalles.Checked, False, 0, dtClientesPruebaFechaPrograma.Value, 0, 0, True, 0, 0, True, sb.ToString)
                            End If
                        End If

                    Else
                        mensajeAdvertencia("No se encontraron registros seleccionados.")
                        Exit Sub
                    End If
                Else
                    mensajeAdvertencia("No se encontraron registros en el panel de datos de apartado.")
                    Exit Sub
                End If
            Else
                mensajeAdvertencia("Debe seleccionar al menos una opcion de busqueda")
                Exit Sub
            End If


            If chkMostrarDetalles.Checked Then
                If Not IsNothing(dtZpl) Then
                    If dtZpl.Rows.Count > 0 Then
                        Dim objDetalles As New ImpresionEtiquetasDetallesForm
                        objDetalles.Data = dtZpl
                        objDetalles.Impresora = cmbImpresoraClientesPruebas.SelectedValue
                        objDetalles.USuarioID = _UsuarioId
                        objDetalles.TipoEtiqueta = cmbClientesPruebasTipoEtiqueta.SelectedValue
                        objDetalles.ClienteID = cmbClientesPruebas.SelectedValue
                        objDetalles.Cliente = cmbClientesPruebas.Text
                        objDetalles.Usuario = _Usuario
                        objDetalles.Accion = _Accion
                        objDetalles.ShowDialog()
                    Else
                        mensajeAdvertencia("La tabla de etiquetas no contiene datos.")
                    End If
                Else
                    mensajeAdvertencia("La consulta de etiquetas realizada no arrojo resultados.")
                End If
            Else
                ' CarlosMtz VALIDACION PROCESO COPPEL ETIQUETA cOLOR
                If cmbClientesPruebas.SelectedValue <> 103 And cmbClientesPruebas.SelectedValue <> 1230 And 'BATTA
                    cmbClientesPruebas.SelectedValue <> 763 And cmbClientesPruebas.SelectedValue <> 1181 And 'Coppel
                    cmbClientesPruebas.SelectedValue <> 17 And cmbClientesPruebas.SelectedValue <> 1358 Then 'PriceShoes
                    If Not IsNothing(dtZpl) Then
                        'If dtZpl.Rows.Count > 0 Then
                        If dtZpl.Rows(0).Item("etiqueta") <> String.Empty Then
                            GenerarArchivoEtiquetasTxt(dtZpl)
                            Dim grfs As List(Of String) = dtZpl.AsEnumerable() _
                            .Select(Function(r) r.Field(Of String)("foto")) _
                            .Distinct() _
                                                       .ToList()
                            GenerarArchivoEtiquetasBat(grfs)
                            Shell("C:\SAY\Etiquetas.bat")
                            If rbLotes.Checked = True Then
                                GuardarBitacoraImpresion(TipoEtiquetaID, txtLoteDelClientesPrueba.Text, txtLoteAlClientesPruebas.Text, 0, ClienteID)
                            End If
                            msgExito.mensaje = "Se ejecutó la impresión correctamente."
                            msgExito.ShowDialog()
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


    Private Sub chkMostrarParesLengua_CheckedChanged(sender As Object, e As EventArgs) Handles chkMostrarParesLengua.CheckedChanged


        Try
            If chkMostrarParesLengua.Checked = True Then
                If ValidarFiltroLotes() = False Then
                    chkMostrarParesLengua.Checked = False
                    Return
                End If

                txtAmarreLengua.Enabled = False
                If txtLoteInicioLengua.Text <> String.Empty And txtLoteFinLengua.Text <> String.Empty Then
                    If IsNumeric(txtLoteInicioLengua.Text) = True And IsNumeric(txtLoteFinLengua.Text) = True Then
                        CargarParesLengua(txtLoteInicioLengua.Text, txtLoteFinLengua.Text, txtAmarreLengua.Text, _idNave, dtpFechaPrograma.Value.Year)
                    Else
                        show_message("Advertencia", "Los campos de Lote inicio y lote fin deben ser numeros.")
                        grdParesLengua.DataSource = Nothing
                    End If
                Else
                    show_message("Advertencia", "El campo de Lote no puede estar vacío.")
                    grdParesLengua.DataSource = Nothing
                End If
            Else
                grdParesLengua.DataSource = Nothing
                txtAmarreLengua.Enabled = True
            End If
            lblContadorParesLengua.Text = "0"
        Catch ex As Exception
            show_message("Error", "Ocurrio un error al mostrar los pares.")
        End Try

    End Sub


    Private Sub CargarParesLengua(ByVal LoteInicio As String, ByVal LoteFin As String, ByVal Amarre As String, ByVal NaveID As Integer, ByVal Año As Integer)
        Dim dtInformacion As New DataTable
        Dim ColeccionID As Integer = 0

        Try
            If cmbTipoImpresionLengua.SelectedIndex = 2 Then
                ColeccionID = cmbColeccionLengua.SelectedValue
            Else
                ColeccionID = 0
            End If

            grdParesLengua.DataSource = Nothing
            dtInformacion = objBU.ConsultaParesLengua(LoteInicio, LoteFin, Amarre, NaveID, Año, ColeccionID)
            grdParesLengua.DataSource = dtInformacion
            DiseñoGridParesLengua(viewParesLengua)

            If dtInformacion.Rows.Count = 0 Then
                show_message("Advertencia", "No se encontro información.")
            End If

        Catch ex As Exception
            show_message("Error", "Ocurrio un error al mostrar los pares.")
        End Try

    End Sub

    Private Sub DiseñoGridParesLengua(ByVal grid As DevExpress.XtraGrid.Views.Grid.GridView)
        'grid.OptionsView.ColumnAutoWidth = False
        grid.BestFitColumns()
        grid.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True

        Tools.DiseñoGrid.AlinearTextoEncabezadoColumnas(grid)
        Tools.DiseñoGrid.AlternarColorEnFilas(grid)

        With grid

            .Columns.ColumnByFieldName("Lote").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
            .Columns.ColumnByFieldName("Atado").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
            .Columns.ColumnByFieldName("Par").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
            .Columns.ColumnByFieldName("Calce").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains

            .Columns.ColumnByFieldName("#").OptionsColumn.AllowSize = True
            .Columns.ColumnByFieldName("Lote").OptionsColumn.AllowSize = True
            .Columns.ColumnByFieldName("Atado").OptionsColumn.AllowSize = True
            .Columns.ColumnByFieldName("Par").OptionsColumn.AllowSize = True
            .Columns.ColumnByFieldName("Calce").OptionsColumn.AllowSize = True

            .Columns.ColumnByFieldName("#").OptionsColumn.AllowEdit = False
            .Columns.ColumnByFieldName("Lote").OptionsColumn.AllowEdit = False
            .Columns.ColumnByFieldName("Atado").OptionsColumn.AllowEdit = False
            .Columns.ColumnByFieldName("Par").OptionsColumn.AllowEdit = False
            .Columns.ColumnByFieldName("Calce").OptionsColumn.AllowEdit = False

        End With


    End Sub

    Private Sub viewParesLengua_CellValueChanging(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles viewParesLengua.CellValueChanging
        If e.Column.FieldName = "Imprimir" Then
            If e.Value = True Then
                lblContadorParesLengua.Text = (CInt(lblContadorParesLengua.Text) + 1).ToString
            Else
                lblContadorParesLengua.Text = (CInt(lblContadorParesLengua.Text) - 1).ToString
            End If
        End If
    End Sub

    Private Function ImpresionPorPares(ByVal ColeccionId As Integer, ByVal ClienteSAY As Integer) As Boolean
        Dim Resultado As Boolean = False
        Dim NumeroFilas As Integer = 0
        Dim ParesImprimir As String = String.Empty
        Dim dtInformacionPares As New DataTable

        Try

            NumeroFilas = viewParesLengua.DataRowCount
            For index As Integer = 0 To NumeroFilas Step 1
                If CBool(viewParesLengua.GetRowCellValue(viewParesLengua.GetVisibleRowHandle(index), "Imprimir")) = True Then
                    If ParesImprimir = String.Empty Then
                        ParesImprimir = viewParesLengua.GetRowCellValue(viewParesLengua.GetVisibleRowHandle(index), "Par")
                    Else
                        ParesImprimir = ParesImprimir & "," & viewParesLengua.GetRowCellValue(viewParesLengua.GetVisibleRowHandle(index), "Par")
                    End If
                End If
            Next

            If ParesImprimir <> String.Empty Then
                If Accion = 1 Then
                    dtInformacionPares = objBU.ImpresionEtiquetasPorParLengua(txtLoteInicioLengua.Text, _idNave, dtpFechaPrograma.Value.Year, ParesImprimir, cmbImpresoraLengua.SelectedValue, _UsuarioId, dtpFechaPrograma.Value, ColeccionId, , ClienteSAY)
                Else
                    dtInformacionPares = objBU.ImpresionEtiquetasPorParLenguaPrueba(txtLoteInicioLengua.Text, _idNave, dtpFechaPrograma.Value.Year, ParesImprimir, cmbImpresoraLengua.SelectedValue, _UsuarioId, dtpFechaPrograma.Value, ColeccionId,, ClienteSAY)
                End If

                Resultado = True
                GeneraArchivosParaImpresion(dtInformacionPares, _idNave, cmbImpresoraLengua.SelectedValue, CInt(txtLoteInicioLengua.Text), CInt(txtLoteFinLengua.Text))
            Else
                show_message("Advertencia", "No se han seleccionado pares para imprimir.")
            End If

        Catch ex As Exception
            Throw ex
        End Try

        Return Resultado

    End Function

    Private Function ValidarFiltros() As Boolean
        Dim Resultado As Boolean = True

        Try
            If cmbTipoImpresionLengua.SelectedIndex = 0 Then
                If cmbImpresoraLengua.SelectedIndex < 0 Then
                    Resultado = False
                    show_message("Advertencia", "No se ha seleccionado una impresora.")
                End If
            ElseIf cmbTipoImpresionLengua.SelectedIndex = 1 Then
                If txtLoteInicioLengua.Text = String.Empty Or txtLoteFinLengua.Text = String.Empty Then
                    Resultado = False
                    show_message("Advertencia", "No se ha capturado el rango de lotes.")
                Else
                    If txtLoteInicioLengua.Text <> String.Empty And txtLoteFinLengua.Text <> String.Empty Then
                        If IsNumeric(txtLoteInicioLengua.Text) = False Or IsNumeric(txtLoteFinLengua.Text) = False Then
                            Resultado = False
                            show_message("Advertencia", "Los lotes capturados deben ser numeros.")
                        Else
                            If CInt(txtLoteInicioLengua.Text) > CInt(txtLoteFinLengua.Text) Then
                                show_message("Advertencia", "El lote de inicio no debe de ser mayor que el lote fin.")
                            End If
                        End If
                    End If
                End If
            ElseIf cmbTipoImpresionLengua.SelectedIndex = 2 Then
                If cmbColeccionLengua.SelectedIndex < 0 Then
                    Resultado = False
                    show_message("Advertencia", "No se ha seleccionado una impresora.")
                Else
                    If txtLoteInicioLengua.Text = String.Empty Or txtLoteFinLengua.Text = String.Empty Then
                        Resultado = False
                        show_message("Advertencia", "No se ha capturado el rango de lotes.")
                    Else
                        If txtLoteInicioLengua.Text <> String.Empty And txtLoteFinLengua.Text <> String.Empty Then
                            If IsNumeric(txtLoteInicioLengua.Text) = False Or IsNumeric(txtLoteFinLengua.Text) = False Then
                                Resultado = False
                                show_message("Advertencia", "Los lotes capturados deben ser numeros.")
                            Else
                                If CInt(txtLoteInicioLengua.Text) > CInt(txtLoteFinLengua.Text) Then
                                    show_message("Advertencia", "El lote de inicio no debe de ser mayor que el lote fin.")
                                End If
                            End If
                        End If
                    End If
                End If
            End If

        Catch ex As Exception
            show_message("Error", ex.Message.ToString())
            Resultado = False
        End Try

        Return Resultado

    End Function


    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub


    Private Function ValidarFiltroLotes() As Boolean
        Dim Resultado As Boolean = True

        Try
            'Validar que el lote capturado este dentro del rango de los lotes del programa
            If txtLoteInicioLengua.Text <> String.Empty Then
                If IsNumeric(txtLoteInicioLengua.Text) = True Then
                    If CInt(txtLoteInicioLengua.Text) < Lista.Min() Or CInt(txtLoteInicioLengua.Text) > Lista.Max() Then
                        show_message("Advertencia", "El lote capturado no se encuentra en los lotes del programa.")
                        Resultado = False
                    End If
                Else
                    show_message("Advertencia", "El Lote capturado tiene que ser un número.")
                    Resultado = False
                End If
            End If

            If txtLoteFinLengua.Text <> String.Empty Then
                If IsNumeric(txtLoteFinLengua.Text) = True Then
                    If CInt(txtLoteFinLengua.Text) < Lista.Min() Or CInt(txtLoteFinLengua.Text) > Lista.Max() Then
                        show_message("Advertencia", "El lote capturado no se encuentra en los lotes del programa.")
                        Resultado = False
                    End If
                Else
                    show_message("Advertencia", "El Lote capturado tiene que ser un número.")
                    Resultado = False
                End If
            End If

            'Validar que el lote de inicio no sea mayor que el lote fin
            If IsNumeric(txtLoteInicioLengua.Text) = True And IsNumeric(txtLoteFinLengua.Text) = True Then
                If CInt(txtLoteInicioLengua.Text) > CInt(txtLoteFinLengua.Text) Then
                    show_message("Advertencia", "El lote de inicio no puede ser mayor al lote fin.")
                    Resultado = False
                End If
            End If

        Catch ex As Exception
            Resultado = False
            show_message("Error", ex.Message.ToString())
        End Try

        Return Resultado

    End Function

    Private Sub CargarClientesRastreo()
        Dim dtResultado As New DataTable
        Try
            dtResultado = objBU.ConsultarClientesRastreo()
            cmbClienteRastreo.DataSource = dtResultado
            cmbClienteRastreo.ValueMember = "ClienteSICYID"
            cmbClienteRastreo.DisplayMember = "Cliente"
        Catch ex As Exception
            show_message("Error", "Ocurrio un error al mostrar los clientes.")
        End Try

    End Sub

    Private Sub InicializarTabRastreo()
        txtLoteInicioRastreo.Text = Lista.Min.ToString
        txtLoteFinRastreo.Text = Lista.Max.ToString
        txtAmarreInicioRastreo.Text = String.Empty
        txtAmarreFinRastreo.Text = String.Empty
        chkMostrarParesRastreo.Checked = False
    End Sub

    Private Sub btnImprimirRastreo_Click(sender As Object, e As EventArgs) Handles btnImprimirRastreo.Click
        Dim UsuarioId As Integer = 0
        Dim dtResultadoImpresion As New DataTable
        Dim EsEtiquetaPrueba As Boolean = False
        Dim NumeroFilas As Integer = 0
        Dim ParesImprimir As String = String.Empty
        Dim VentanaDetallesTallasExtranjeras As New MostrarDetallesValidacionTallasExtanjerasForm

        Try
            If Accion = 1 Then
                EsEtiquetaPrueba = False
            Else
                EsEtiquetaPrueba = True
            End If

            UsuarioId = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
            If cmbClienteRastreo.SelectedIndex >= 0 Then
                If cmbImpresoraRastreo.SelectedIndex >= 0 Then
                    If objBU.ValidarExisteEtiquetaRastreo(cmbClienteRastreo.SelectedValue, EsEtiquetaPrueba) Then
                        'If ValidarFiltroAmarreLote() = True AndAlso ValidarFiltroAmarreRastreo() = True Then
                        If ValidarFiltroAmarreRastreo() = True Then
                            If chkMostrarParesRastreo.Checked = True Then
                                'If objBU.ValidarInformacionEtiquetaRastreo(txtLoteInicioRastreo.Text, txtLoteFinRastreo.Text, txtAmarreInicioRastreo.Text, txtAmarreFinRastreo.Text, _idNave, dtpFechaPrograma.Value.Year, cmbImpresoraRastreo.SelectedValue, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, dtpFechaPrograma.Value, cmbClienteRastreo.SelectedValue) = True Then
                                If objBU.ValidarTallasExtranjerasEtiquetaRastreo(txtLoteInicioRastreo.Text, txtLoteFinRastreo.Text, _idNave, cmbClienteRastreo.SelectedValue, dtpFechaPrograma.Value.Year, dtpFechaPrograma.Value, EsEtiquetaPrueba) = True Then
                                    ImprimirParesRastreo()
                                    'GuardarBitacoraImpresion(7, txtLoteInicioRastreo.Text, txtLoteFinRastreo.Text, 0, cmbClienteRastreo.SelectedValue)
                                Else
                                    show_message("Advertencia", "Falta información por cargar de las tallas extranjeras.")
                                    VentanaDetallesTallasExtranjeras.LoteInicio = txtLoteInicioRastreo.Text
                                    VentanaDetallesTallasExtranjeras.LoteFin = txtLoteFinRastreo.Text
                                    VentanaDetallesTallasExtranjeras.NaveSIYCID = _idNave
                                    VentanaDetallesTallasExtranjeras.AñoPrograma = dtpFechaPrograma.Value.Year
                                    VentanaDetallesTallasExtranjeras.FechaPrograma = dtpFechaPrograma.Value
                                    VentanaDetallesTallasExtranjeras.ClienteSICYId = cmbClienteRastreo.SelectedValue
                                    VentanaDetallesTallasExtranjeras.EsEtiquetaPrueba = EsEtiquetaPrueba
                                    VentanaDetallesTallasExtranjeras.TipoEtiqueta = 2
                                    VentanaDetallesTallasExtranjeras.ShowDialog()
                                End If
                                'Else
                                'show_message("Advertencia", "Hay información incompleta revisar en la pantalla de detalles.")
                                'cambio
                                '    NumeroFilas = viewParesRastreo.DataRowCount
                                '    For index As Integer = 0 To NumeroFilas Step 1
                                '        If CBool(viewParesRastreo.GetRowCellValue(viewParesRastreo.GetVisibleRowHandle(index), "Imprimir")) = True Then
                                '            If ParesImprimir = String.Empty Then
                                '                ParesImprimir = viewParesRastreo.GetRowCellValue(viewParesRastreo.GetVisibleRowHandle(index), "Par")
                                '            Else
                                '                ParesImprimir = ParesImprimir & "," & viewParesRastreo.GetRowCellValue(viewParesRastreo.GetVisibleRowHandle(index), "Par")
                                '            End If
                                '        End If
                                '    Next

                                '    If Accion = 1 Then
                                '        dtResultadoImpresion = objBU.ImpresionParesRastreo(ParesImprimir, _idNave, dtpFechaPrograma.Value.Year, cmbImpresoraRastreo.SelectedValue, UsuarioId, dtpFechaPrograma.Value, cmbClienteRastreo.SelectedValue, True)
                                '    Else
                                '        dtResultadoImpresion = objBU.ImpresionParesRastreoPruebas(ParesImprimir, _idNave, dtpFechaPrograma.Value.Year, cmbImpresoraRastreo.SelectedValue, UsuarioId, dtpFechaPrograma.Value, cmbClienteRastreo.SelectedValue, True)
                                '    End If

                                '    MostrarVentanaDetalles(dtResultadoImpresion, 6)
                                'End If
                            Else
                                'If objBU.ValidarInformacionEtiquetaRastreo(txtLoteInicioRastreo.Text, txtLoteFinRastreo.Text, txtAmarreInicioRastreo.Text, txtAmarreFinRastreo.Text, _idNave, dtpFechaPrograma.Value.Year, cmbImpresoraRastreo.SelectedValue, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, dtpFechaPrograma.Value, cmbClienteRastreo.SelectedValue) = True Then
                                If objBU.ValidarTallasExtranjerasEtiquetaRastreo(txtLoteInicioRastreo.Text, txtLoteFinRastreo.Text, _idNave, cmbClienteRastreo.SelectedValue, dtpFechaPrograma.Value.Year, dtpFechaPrograma.Value, EsEtiquetaPrueba) = True Then
                                    If Accion = 1 Then
                                        dtResultadoImpresion = objBU.ImpresionEtiquetasRastreo(txtLoteInicioRastreo.Text, txtLoteFinRastreo.Text, txtAmarreInicioRastreo.Text, txtAmarreFinRastreo.Text, _idNave, dtpFechaPrograma.Value.Year, cmbImpresoraRastreo.SelectedValue, UsuarioId, dtpFechaPrograma.Value, cmbClienteRastreo.SelectedValue)
                                    Else
                                        dtResultadoImpresion = objBU.ImpresionEtiquetasRastreoPrueba(txtLoteInicioRastreo.Text, txtLoteFinRastreo.Text, txtAmarreInicioRastreo.Text, txtAmarreFinRastreo.Text, _idNave, dtpFechaPrograma.Value.Year, cmbImpresoraRastreo.SelectedValue, UsuarioId, dtpFechaPrograma.Value, cmbClienteRastreo.SelectedValue)
                                    End If
                                    If dtResultadoImpresion.Rows.Count > 0 Then
                                        GeneraArchivosParaImpresion(dtResultadoImpresion, _idNave, cmbImpresoraRastreo.SelectedValue, CInt(txtLoteInicioRastreo.Text), CInt(txtLoteFinRastreo.Text))
                                    Else
                                        show_message("Advertencia", "Verifique que el modelo en su Piel - Color - Corrida, tenga asignado la etiqueta de rastreo")
                                    End If

                                Else
                                    show_message("Advertencia", "Falta información por cargar de las tallas extranjeras.")
                                    VentanaDetallesTallasExtranjeras.LoteInicio = txtLoteInicioRastreo.Text
                                    VentanaDetallesTallasExtranjeras.LoteFin = txtLoteFinRastreo.Text
                                    VentanaDetallesTallasExtranjeras.NaveSIYCID = _idNave
                                    VentanaDetallesTallasExtranjeras.AñoPrograma = dtpFechaPrograma.Value.Year
                                    VentanaDetallesTallasExtranjeras.FechaPrograma = dtpFechaPrograma.Value
                                    VentanaDetallesTallasExtranjeras.ClienteSICYId = cmbClienteRastreo.SelectedValue
                                    VentanaDetallesTallasExtranjeras.EsEtiquetaPrueba = EsEtiquetaPrueba
                                    VentanaDetallesTallasExtranjeras.TipoEtiqueta = 2
                                    VentanaDetallesTallasExtranjeras.ShowDialog()
                                End If
                                'Else

                                'show_message("Advertencia", "Hay información incompleta revisar la pantalla de detalles.")

                                '    If Accion = 1 Then
                                '        dtResultadoImpresion = objBU.ImpresionEtiquetasRastreo(txtLoteInicioRastreo.Text, txtLoteFinRastreo.Text, txtAmarreInicioRastreo.Text, txtAmarreFinRastreo.Text, _idNave, dtpFechaPrograma.Value.Year, cmbImpresoraRastreo.SelectedValue, UsuarioId, dtpFechaPrograma.Value, cmbClienteRastreo.SelectedValue, True)
                                '    Else
                                '        dtResultadoImpresion = objBU.ImpresionEtiquetasRastreoPrueba(txtLoteInicioRastreo.Text, txtLoteFinRastreo.Text, txtAmarreInicioRastreo.Text, txtAmarreFinRastreo.Text, _idNave, dtpFechaPrograma.Value.Year, cmbImpresoraRastreo.SelectedValue, UsuarioId, dtpFechaPrograma.Value, cmbClienteRastreo.SelectedValue, True)
                                '    End If

                                '    MostrarVentanaDetalles(dtResultadoImpresion, 6)

                                'End If
                            End If
                        End If
                    Else
                        show_message("Advertencia", "No se ha cargado la etiqueta de rastreo para este cliente.")
                    End If
                Else
                    show_message("Advertencia", "No se ha seleccionado una impresora.")
                End If
            Else
                show_message("Advertencia", "No se ha seleccionado un cliente.")
            End If

        Catch ex As Exception
            show_message("Error", ex.Message.ToString())
        End Try

    End Sub

    Private Function ValidarFiltroAmarreLote() As Boolean
        Dim Resultado As Boolean = True

        Try

            If txtLoteInicioRastreo.Text <> String.Empty And txtLoteFinRastreo.Text <> String.Empty Then
                If IsNumeric(txtLoteInicioRastreo.Text) = True Or IsNumeric(txtLoteFinRastreo.Text) = True Then
                    If CInt(txtLoteInicioRastreo.Text) < Lista.Min Or CInt(txtLoteInicioRastreo.Text) > Lista.Max Then
                        show_message("Advertencia", "El lote capturado esta fuera del rango del programa.")
                        Resultado = False
                    End If
                    If CInt(txtLoteFinRastreo.Text) < Lista.Min Or CInt(txtLoteFinRastreo.Text) > Lista.Max Then
                        show_message("Advertencia", "El lote capturado esta fuera del rango del programa.")
                        Resultado = False
                    End If
                Else
                    show_message("Advertencia", "El número de lote no es valido.")
                    Resultado = False
                End If
            Else
                show_message("Advertencia", "Los campos de lote no pueden estar vacíos.")
                Resultado = False
            End If

        Catch ex As Exception
            Resultado = False
            Throw ex
        End Try

        Return Resultado
    End Function

    Private Function ValidarFiltroAmarreRastreo() As Boolean
        Dim Resultado As Boolean = True

        Try
            If txtAmarreInicioRastreo.Text <> String.Empty And txtAmarreFinRastreo.Text <> String.Empty Then
                If IsNumeric(txtAmarreInicioRastreo.Text) = True Or IsNumeric(txtAmarreFinRastreo.Text) = True Then
                    If CInt(txtAmarreInicioRastreo.Text) < Lista.Min Or CInt(txtAmarreInicioRastreo.Text) > Lista.Max Then
                        show_message("Advertencia", "El Amarre capturado esta fuera del rango del programa.")
                        Resultado = False
                    End If

                    If CInt(txtAmarreFinRastreo.Text) < Lista.Min Or CInt(txtAmarreFinRastreo.Text) > Lista.Max Then
                        show_message("Advertencia", "El Amarre capturado esta fuera del rango del programa.")
                        Resultado = False
                    End If
                Else
                    show_message("Advertencia", "El número de amarre no es valido.")
                    Resultado = False
                End If
            End If
        Catch ex As Exception
            Resultado = False
            Throw ex
        End Try

        Return Resultado
    End Function

    Private Sub chkMostrarParesRastreo_CheckedChanged(sender As Object, e As EventArgs) Handles chkMostrarParesRastreo.CheckedChanged
        Dim dtResultadoPares As New DataTable

        Try
            Cursor = Cursors.WaitCursor
            If cmbImpresoraRastreo.SelectedIndex >= 0 Then
                'If ValidarFiltroAmarreLote() = True AndAlso ValidarFiltroAmarreRastreo() = True Then
                If ValidarFiltroAmarreRastreo() = True Then
                    dtResultadoPares = objBU.ConsultarParesImprimirRastreo(txtLoteInicioRastreo.Text, txtLoteFinRastreo.Text, txtAmarreInicioRastreo.Text, txtAmarreFinRastreo.Text, _idNave, dtpFechaPrograma.Value.Year, dtpFechaPrograma.Value, cmbClienteRastreo.SelectedValue)
                    If dtResultadoPares.Rows.Count = 0 Then
                        show_message("Advertencia", "No hay información para mostrar.")
                    Else
                        grdParesRastreo.DataSource = dtResultadoPares
                    End If
                End If
            Else
                show_message("Advertencia", "No se ha seleccionado una impresora.")
            End If
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            show_message("Error", ex.Message.ToString())
        End Try

    End Sub

    Private Sub ImprimirParesRastreo()
        Dim Resultado As Boolean = False
        Dim NumeroFilas As Integer = 0
        Dim ParesImprimir As String = String.Empty
        Dim dtInformacionPares As New DataTable
        Dim UsuarioId As Integer = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid

        Try

            NumeroFilas = viewParesRastreo.DataRowCount
            For index As Integer = 0 To NumeroFilas Step 1
                If CBool(viewParesRastreo.GetRowCellValue(viewParesRastreo.GetVisibleRowHandle(index), "Imprimir")) = True Then
                    If ParesImprimir = String.Empty Then
                        ParesImprimir = viewParesRastreo.GetRowCellValue(viewParesRastreo.GetVisibleRowHandle(index), "Par")
                    Else
                        ParesImprimir = ParesImprimir & "," & viewParesRastreo.GetRowCellValue(viewParesRastreo.GetVisibleRowHandle(index), "Par")
                    End If
                End If
            Next

            If ParesImprimir <> String.Empty Then
                If Accion = 1 Then
                    dtInformacionPares = objBU.ImpresionParesRastreo(ParesImprimir, _idNave, dtpFechaPrograma.Value.Year, cmbImpresoraRastreo.SelectedValue, UsuarioId, dtpFechaPrograma.Value, cmbClienteRastreo.SelectedValue)
                Else
                    dtInformacionPares = objBU.ImpresionParesRastreoPruebas(ParesImprimir, _idNave, dtpFechaPrograma.Value.Year, cmbImpresoraRastreo.SelectedValue, UsuarioId, dtpFechaPrograma.Value, cmbClienteRastreo.SelectedValue)
                End If

                If dtInformacionPares.Rows.Count > 0 Then
                    GeneraArchivosParaImpresion(dtInformacionPares, _idNave, cmbImpresoraRastreo.SelectedValue, CInt(txtLoteInicioRastreo.Text), CInt(txtLoteFinRastreo.Text))
                    Resultado = True
                Else
                    Resultado = False
                    show_message("Advertencia", "Ocurrio un error al imprimir la información.")
                End If
            Else
                show_message("Advertencia", "No se han seleccionado pares para imprimir.")
            End If

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub GeneraArchivosParaImpresion(ByVal dtEtiquetas As DataTable, ByVal NaveSICYID As Integer, ByVal ImpresoraId As Integer, ByVal LoteInicio As Integer, ByVal LoteFin As Integer)
        Dim strStreamW As Stream = Nothing
        Dim strStreamWriter As StreamWriter = Nothing
        Dim EtiquetasAImprimir As String = String.Empty
        Dim LotesSeleccionados As String = String.Empty

        Try

            Cursor = Cursors.WaitCursor
            strStreamW = CrearRutasArchivo(CarpetaUbicacionArchivos, RutaArchivoEtiquetas)
            strStreamWriter = New StreamWriter(strStreamW, System.Text.Encoding.Default) ' tipo de codificacion para escritura

            For Each Fila As String In Lista
                If CInt(Fila) >= LoteInicio And CInt(Fila) <= LoteFin Then
                    If LotesSeleccionados = String.Empty Then
                        LotesSeleccionados = Fila
                    Else
                        LotesSeleccionados &= "," & Fila
                    End If
                End If
            Next

            'Escribir la informacion de las etiquetas en el archivo
            For Each FILA As DataRow In dtEtiquetas.Rows
                EtiquetasAImprimir &= FILA.Item(0)
            Next
            strStreamWriter.WriteLine(EtiquetasAImprimir)
            strStreamWriter.Close()
            'Generar archivo bat para enviar a imprimir las etiquetas
            GenerarArchivoBat(LotesSeleccionados, NaveSICYID, dtpFechaPrograma.Value.Year, ImpresoraId)
            If Accion = 1 Then
                GuardarBitacoraImpresion(7, LoteInicio, LoteFin, 0, cmbClienteRastreo.SelectedValue)

            End If
            show_message("Exito", "Se ha enviado a imprimir.")
            Cursor = Cursors.Default

        Catch ex As Exception
            Cursor = Cursors.Default
            Throw ex
        End Try

    End Sub

    Private Function CrearRutasArchivo(ByVal Carpeta As String, ByVal Archivo As String) As Stream
        Dim strStreamW As Stream = Nothing

        Try
            If System.IO.Directory.Exists(Carpeta) = False Then
                System.IO.Directory.CreateDirectory(Carpeta)
            End If

            If File.Exists(Archivo) Then
                File.Delete(Archivo)
                strStreamW = File.Create(Archivo)
            Else
                strStreamW = File.Create(Archivo)
            End If
        Catch ex As Exception
            Throw ex
        End Try

        Return strStreamW

    End Function

    Private Sub GenerarArchivoBat(ByVal LotesSeleccionados As String, ByVal Nave As Integer, ByVal Año As Integer, ByVal ImpresoraID As Integer)
        Dim strStreamW As Stream = Nothing
        Dim strStreamWriter As StreamWriter = Nothing
        Dim PathArchivo As String
        Dim dtArchivo As DataTable


        Try
            Cursor = Cursors.WaitCursor

            If TabOpcionesDeImpresion.SelectedTab.Name = "TabLengua" Then
                dtArchivo = objBU.ComandosImprimirEtiquetasSAY_V2SINGRF(LotesSeleccionados, Nave, Año, ImpresoraID)
            Else
                dtArchivo = objBU.ComandosImprimirEtiquetasSAY_V2(LotesSeleccionados, Nave, Año, ImpresoraID)
            End If


            If System.IO.Directory.Exists(CarpetaUbicacionArchivos) = False Then
                System.IO.Directory.CreateDirectory(CarpetaUbicacionArchivos)
            End If

            PathArchivo = RutaArchivoBat ' Se determina el nombre del archivo con la fecha actual

            'verificamos si existe el archivo
            If File.Exists(PathArchivo) Then
                File.Delete(PathArchivo)
                strStreamW = File.Create(PathArchivo)
            Else
                strStreamW = File.Create(PathArchivo) ' lo creamos
            End If

            strStreamWriter = New StreamWriter(strStreamW, System.Text.Encoding.Default) ' tipo de codificacion para escritura

            For Each FILA As DataRow In dtArchivo.Rows
                strStreamWriter.WriteLine(FILA.Item(0))
            Next

            strStreamWriter.Close() ' cerrar
            'Ejecutar el archivo bat
            Shell(RutaArchivoBat)
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            Throw ex
            'show_message("Error", "Ocurrio un error al generar el archivo, vuelva a intentar.")
        End Try
    End Sub

    Private Sub MostrarVentanaDetalles(ByVal dtInformacion As DataTable, ByVal TipoEtiqueta As Integer)
        Dim VentanaDetallesForm As New ImpresionEtiquetasDetallesForm
        Dim ColeccionId As Integer = 0

        Try
            VentanaDetallesForm.Data = dtInformacion
            If TipoEtiqueta = 3 Then
                VentanaDetallesForm.TipoEtiquetaSeleccionada = TipoEtiqueta
                VentanaDetallesForm.LoteInicio = txtLoteInicioLengua.Text
                VentanaDetallesForm.LoteFin = txtLoteFinLengua.Text
                VentanaDetallesForm.NaveSICYID = _idNave
                VentanaDetallesForm.AñoPrograma = dtpFechaPrograma.Value.Year
                VentanaDetallesForm.FechaPrograma = dtpFechaPrograma.Value
                VentanaDetallesForm.Accion = Accion
                VentanaDetallesForm.Impresora = cmbImpresoraLengua.SelectedValue
                If cmbTipoImpresionLengua.SelectedIndex = 0 Or cmbTipoImpresionLengua.SelectedIndex = 1 Then
                    ColeccionId = 0
                Else
                    If cmbColeccionLengua.SelectedIndex >= 0 Then
                        ColeccionId = cmbColeccionLengua.SelectedValue
                    Else
                        ColeccionId = 0
                    End If
                End If
                VentanaDetallesForm.ColeccionID = ColeccionId
                VentanaDetallesForm.ClienteID = 0
                VentanaDetallesForm.Show()
            ElseIf TipoEtiqueta = 6 Then
                VentanaDetallesForm.TipoEtiquetaSeleccionada = TipoEtiqueta
                VentanaDetallesForm.LoteInicio = txtLoteInicioRastreo.Text
                VentanaDetallesForm.LoteFin = txtLoteFinRastreo.Text
                VentanaDetallesForm.NaveSICYID = _idNave
                VentanaDetallesForm.AñoPrograma = dtpFechaPrograma.Value.Year
                VentanaDetallesForm.FechaPrograma = dtpFechaPrograma.Value
                VentanaDetallesForm.Accion = Accion
                VentanaDetallesForm.ColeccionID = 0
                VentanaDetallesForm.ClienteID = cmbClienteRastreo.SelectedValue
                VentanaDetallesForm.Impresora = cmbImpresoraRastreo.SelectedValue
                VentanaDetallesForm.Show()
            End If

        Catch ex As Exception
            show_message("Error", ex.Message.ToString())
        End Try

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Dim dtInformacionImpresion As New DataTable

        Try
            dtInformacionImpresion = objBU.ImpresionEtiquetasLenguaPrueba(txtLoteInicioLengua.Text, txtLoteFinLengua.Text, _idNave, dtpFechaPrograma.Value.Year, cmbImpresoraLengua.SelectedValue, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, dtpFechaPrograma.Value, cmbTipoImpresion.SelectedIndex, 0, txtAmarreLengua.Text, True)
            MostrarVentanaDetalles(dtInformacionImpresion, 3)
        Catch ex As Exception
            show_message("Error", ex.Message.ToString())
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)
        Dim dtResultadoImpresion As New DataTable

        Try
            dtResultadoImpresion = objBU.ImpresionEtiquetasRastreoPrueba(txtLoteInicioRastreo.Text, txtLoteFinRastreo.Text, txtAmarreInicioRastreo.Text, txtAmarreFinRastreo.Text, _idNave, dtpFechaPrograma.Value.Year, cmbImpresoraRastreo.SelectedValue, UsuarioID, dtpFechaPrograma.Value, cmbClienteRastreo.SelectedValue, True)
            MostrarVentanaDetalles(dtResultadoImpresion, 6)
        Catch ex As Exception
            show_message("Error", ex.Message.ToString())
        End Try

    End Sub


    Private Function EsImpresoraNiceLabel(ByVal ImpresoraSeleccionada As Integer) As Boolean
        Dim Resultado As Boolean = False
        Dim DTImpresoras As DataTable
        Dim Software As String = String.Empty

        Try
            DTImpresoras = objBU.ListaImpresoras()
            Software = DTImpresoras.AsEnumerable().Where(Function(x) x.Item("IdImpresora") = ImpresoraSeleccionada).Select(Function(y) y.Item("Software")).FirstOrDefault()

            If Software = "NICELABEL" Then
                Resultado = True
            Else
                Resultado = False
            End If
        Catch ex As Exception
            Throw ex
        End Try
        Return Resultado
    End Function

    Private Function CopiarImagenesBatta(ByVal PorLotes As Boolean, ByVal LoteInicio As Integer, ByVal LoteFin As Integer, ByVal NaveSICYID As Integer, ByVal FechaPrograma As Date, ByVal PorPedido As Boolean, ByVal PedidoSAY As Integer, ByVal PedidoSICY As Integer, ByVal PorApartado As Boolean, ByVal CadenaApartados As String, ByVal IdCliente As Integer) As Boolean
        Dim dtImagenes As New DataTable
        Dim CarpetaDestino As String = String.Empty
        Dim RutaImagenCompletaTemporal As String = String.Empty
        Dim NombreImagenTemporal As String = String.Empty
        Dim RutaCompletaSICY As String = String.Empty
        Dim RutaFTP As String = String.Empty
        Dim RutaCompletaLocal As String = String.Empty
        Dim Resultado As Boolean = False
        Dim RutaImagenLogoMarcaClienteTemporal As String = String.Empty
        Dim NombreImagenLogoMarcaClienteTemporal As String = String.Empty
        Dim RutaCompletaLocalLogo As String = String.Empty
        Dim RutaCompletaSICYCoppel As String = String.Empty
        Dim RutaCompletaLocalCoppel As String = String.Empty
        Dim RutaFTPLogoMarca As String = String.Empty
        Try
            dtImagenes = objBU.ConsultaImagenesBattaOpcionesCliente(PorLotes, LoteInicio, LoteFin, NaveSICYID, FechaPrograma, PorPedido, PedidoSAY, PedidoSICY, PorApartado, CadenaApartados, IdCliente)

            For Each Fila As DataRow In dtImagenes.Rows
                CarpetaDestino = Fila.Item("Carpeta")
                RutaImagenCompletaTemporal = Fila.Item("RutaNoExite")
                RutaFTP = Fila.Item("RutaFTP")

                'Para Reemplazar las imagenes de coppel (LogoMarca y Foto) solo hay que descomentar los "Else"
                If IdCliente = 763 Or IdCliente = 1181 Then
                    RutaImagenLogoMarcaClienteTemporal = Fila.Item("RutaNoExiteMarcaCliente")
                    RutaFTPLogoMarca = Fila.Item("RutaFTPLogoMarcaCliente")
                    NombreImagenLogoMarcaClienteTemporal = Path.GetFileName(RutaImagenLogoMarcaClienteTemporal)
                    RutaCompletaSICYCoppel = CarpetaDestino + NombreImagenLogoMarcaClienteTemporal
                    If File.Exists(RutaCompletaSICYCoppel) = False Then
                        RutaCompletaLocalCoppel = objBU.DescargarImagenBatta(RutaFTPLogoMarca)
                        File.Copy(RutaCompletaLocalCoppel, RutaCompletaSICYCoppel)
                        'Else
                        '    File.Delete(RutaCompletaSICYCoppel)
                        '    RutaCompletaLocalCoppel = objBU.DescargarImagenBatta(RutaFTPLogoMarca)
                        '    File.Copy(RutaCompletaLocalCoppel, RutaCompletaSICYCoppel)
                    End If
                    NombreImagenTemporal = Path.GetFileName(RutaImagenCompletaTemporal)
                    RutaCompletaSICY = CarpetaDestino + NombreImagenTemporal
                    If File.Exists(RutaCompletaSICY) = False Then
                        RutaCompletaLocal = objBU.DescargarImagenBatta(RutaFTP)
                        File.Copy(RutaCompletaLocal, RutaCompletaSICY)
                        'Else
                        '    File.Delete(RutaCompletaSICY)
                        '    RutaCompletaLocal = objBU.DescargarImagenBatta(RutaFTP)
                        '    File.Copy(RutaCompletaLocal, RutaCompletaSICY)
                    End If
                Else
                    NombreImagenTemporal = Path.GetFileName(RutaImagenCompletaTemporal)
                    RutaCompletaSICY = CarpetaDestino + NombreImagenTemporal
                    If File.Exists(RutaCompletaSICY) = False Then
                        RutaCompletaLocal = objBU.DescargarImagenBatta(RutaFTP)
                        File.Copy(RutaCompletaLocal, RutaCompletaSICY)
                    End If
                End If



            Next

            Resultado = True
        Catch ex As Exception
            Resultado = False
            show_message("Advertencia", ex.Message.ToString())
        End Try

        Return Resultado

    End Function

    Private Sub cmbModelos_SelectedIndexChanged() Handles cmbModelos.SelectedIndexChanged
        Try
            Dim dtNumeracion As DataTable
            Dim dtLoteDocena As DataTable
            Dim dtDocenasEpeciales As DataTable
            Dim objNeg As New Negocios.EtiquetasBU

            Dim valor As Object = cmbModelos.SelectedValue
            Dim total As Integer
            If Not IsNothing(grdVDocenasNormales.DataSource) Then
                grdVDocenasNormales.Columns.Clear()
            End If

            If Not IsNothing(grdVDocenasEspeciales.DataSource) Then
                grdVDocenasEspeciales.Columns.Clear()
            End If

            txtLoteGranel.Text = ""
            txtDocenaGranel.Text = ""

            If Not IsNothing(valor) Then
                If Not (TypeOf valor Is System.Data.DataRowView) Then
                    id = cmbModelos.SelectedValue.ToString
                    id = cmbModelos.SelectedValue.ToString
                    ids = Split(id, "|")
                    Talla = ids(2)
                    CodigoSicy = ids(0)
                    TallaSicy = ids(1)
                    PielColor = ids(3)
                    dtNumeracion = objNeg.ColocarNumeracion(Talla)
                    If dtNumeracion.Rows.Count > 0 Then
                        'For Each row As DataRow In dtNumeracion.Rows
                        For Each column As DataColumn In dtNumeracion.Columns
                            total += CInt(IIf(IsNumeric(dtNumeracion.Rows(0).Item(column.ColumnName)), dtNumeracion.Rows(0).Item(column.ColumnName), 0))
                        Next
                        'Next
                        'MsgBox(total.ToString)
                        dtNumeracion.Columns.Add("TOTAL", GetType(Integer))
                        dtNumeracion.Rows(0).Item("TOTAL") = total
                        grdDocenasNormales.DataSource = dtNumeracion
                        txtNumeroDocenasNormales.Text = "1"
                        dtLoteDocena = objNeg.BuscarLoteDocena(CodigoSicy, TallaSicy)
                        If dtLoteDocena.Rows.Count > 0 Then
                            txtLoteGranel.Text = dtLoteDocena.Rows(0).Item("Lote")
                            txtDocenaGranel.Text = dtLoteDocena.Rows(0).Item("No_Docena")
                        End If
                    End If
                    dtDocenasEpeciales = objNeg.ColocarNumeracion(Talla, True)
                    grdDocenasEspeciales.DataSource = dtDocenasEpeciales
                    Dim row As DataRow = dtDocenasEpeciales.NewRow()
                    dtDocenasEpeciales.Rows.Add(row)
                    Tools.DiseñoGrid.AlinearTextoEncabezadoColumnas(grdVDocenasNormales)
                    Tools.DiseñoGrid.AlinearTextoEncabezadoColumnas(grdVDocenasEspeciales)
                    For Each col As GridColumn In grdVDocenasNormales.Columns
                        grdVDocenasNormales.Columns.ColumnByFieldName(col.FieldName).OptionsColumn.AllowEdit = False
                    Next
                    grdVDocenasEspeciales.Columns.ColumnByFieldName("TOTAL").OptionsColumn.AllowEdit = False
                End If
            End If
        Catch ex As Exception
            msgError.mensaje = ex.Message + vbCrLf + ex.Source + vbCrLf + ex.StackTrace
            msgError.ShowDialog()
        End Try
    End Sub

    Private Sub txtModeloSAY_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtModeloSAY.KeyPress
        e.Handled = soloNumeros(sender, e)
    End Sub
    Private Sub txtNumeroDocenas_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNumeroDocenasNormales.KeyPress
        e.Handled = soloNumeros(sender, e)
    End Sub

    Private Sub txtNumeroDocenas_TextChanged(sender As Object, e As EventArgs) Handles txtNumeroDocenasNormales.TextChanged
        Dim numeroDocenas As Integer
        Dim valor As Integer = 0
        Dim total As Integer = 0
        If grdVDocenasNormales.DataRowCount > 0 Then
            numeroDocenas = IIf(txtNumeroDocenasNormales.Text.Trim = "", 0, txtNumeroDocenasNormales.Text.Trim)
            If numeroDocenas > 0 Then
                Dim dt As New DataTable
                Dim objNeg As New Negocios.EtiquetasBU
                If Not IsNothing(grdVDocenasNormales.DataSource) Then
                    grdVDocenasNormales.Columns.Clear()
                End If
                dt = objNeg.ColocarNumeracion(Talla)
                If dt.Rows.Count > 0 Then
                    For Each column As DataColumn In dt.Columns
                        valor = CInt(IIf(IsNumeric(dt.Rows(0).Item(column.ColumnName)), dt.Rows(0).Item(column.ColumnName), 0))
                        valor = CInt(valor) * CInt(numeroDocenas)
                        dt.Rows(0).Item(column.ColumnName) = valor
                    Next
                    For Each column As DataColumn In dt.Columns
                        total += CInt(IIf(IsNumeric(dt.Rows(0).Item(column.ColumnName)), dt.Rows(0).Item(column.ColumnName), 0))
                    Next
                    dt.Columns.Add("Total", GetType(Integer))
                    dt.Rows(0).Item("Total") = total
                    grdDocenasNormales.DataSource = dt
                End If

                'For Each col As GridColumn In grdVDocenasNormales.Columns
                '    'valor = grdVDocenasNormales.GetRowCellValue(0, col).ToString
                '    'MsgBox(dtNumeracion.Rows(0).Item(col.FieldName))
                '    valor = IIf(_dtNumeracion.Rows(0).Item(col.FieldName).ToString = "", 0, dtNumeracion.Rows(0).Item(col.FieldName))
                '    valor = CInt(valor) * CInt(numeroDocenas)
                '    grdVDocenasNormales.SetRowCellValue(0, col, valor)
                'Next
            End If
        End If
    End Sub

    Private Sub rdbDocenasNormales_CheckedChanged(sender As Object, e As EventArgs) Handles rdbDocenasNormales.CheckedChanged
        If rdbDocenasNormales.Checked Then

            lblParesAtado.Enabled = False
            txtParesPorAtados.Enabled = False
            grdDocenasEspeciales.Enabled = False

            txtNumeroDocenasNormales.Enabled = True
            grdDocenasNormales.Enabled = True

        End If
    End Sub

    Private Sub rdbDocenasEspeaciales_CheckedChanged(sender As Object, e As EventArgs) Handles rdbDocenasEspeaciales.CheckedChanged
        lblParesAtado.Enabled = True
        txtParesPorAtados.Enabled = True
        grdDocenasEspeciales.Enabled = True


        txtNumeroDocenasNormales.Enabled = False
        grdDocenasNormales.Enabled = False
    End Sub

    Private Sub grdDocenasEspeciales_ProcessGridKey(sender As Object, e As KeyEventArgs) Handles grdDocenasEspeciales.ProcessGridKey
        Dim valor As String = String.Empty
        Dim total As Integer = 0
        Dim ParesXAtado As Integer
        Dim numeroAtados As Integer = 0

        If txtParesPorAtados.Text.Trim.ToString.Length = 0 Then
            mensajeAdvertencia("Debe capturar la cantidad de pares por atado")
            Exit Sub
        End If

        If e.KeyCode = Keys.Enter Then
            For Each col As GridColumn In grdVDocenasEspeciales.Columns
                If Not IsNothing(grdVDocenasEspeciales) Then
                    If col.FieldName <> "TOTAL" Then
                        valor = grdVDocenasEspeciales.GetRowCellValue(0, col).ToString.Trim
                        valor = IIf(valor.Length = 0, "0", valor)
                        total += CInt(valor)
                    End If
                End If
            Next
            grdVDocenasEspeciales.SetRowCellValue(0, "TOTAL", total)
            ParesXAtado = CInt(IIf(txtParesPorAtados.Text.Trim.ToString.Length = 0, 0, txtParesPorAtados.Text.Trim.ToString))

            'If ParesXAtado < 6 Then
            '    If Not (ParesXAtado = total) Then
            '        mensajeAdvertencia("El numero de pares por atado debe coincidir con los pares totales.")
            '    End If
            'End If

            If total >= ParesXAtado Then
                numeroAtados = total / ParesXAtado

                Dim M As Int16

                M = total Mod ParesXAtado

                If M > 0 And M < ParesXAtado Then
                    numeroAtados = numeroAtados + 1
                End If

                lblTotalAtados.Text = numeroAtados.ToString
                lblTotalAtados.Visible = True

            ElseIf total > 0 And total <= ParesXAtado Then
                lblTotalAtados.Text = 1
                lblTotalAtados.Visible = True
            End If
        End If
    End Sub

    Private Sub txtParesPorAtados_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtParesPorAtados.KeyPress
        'Verdadero no escribe
        e.Handled = soloNumeros(sender, e)
    End Sub

    Private Sub btnImprimirGranel_Click(sender As Object, e As EventArgs) Handles btnImprimirGranel.Click
        Dim objNeg As New Negocios.EtiquetasBU
        Dim dtZpl As DataTable
        Dim dtGrf As DataTable
        Try
            Cursor = Cursors.WaitCursor
            If txtModeloSAY.Text = "" Then
                mensajeAdvertencia("El campo modelo Say no puede estar vacío.", txtModeloSAY)
                Exit Sub
            End If

            If txtLoteGranel.Text = "" Then
                mensajeAdvertencia("El campo lote no puede estar vacío.")
                Exit Sub
            End If

            If txtDocenaGranel.Text = "" Then
                mensajeAdvertencia("El campo docena no puede estar vacío.")
                Exit Sub
            End If

            If cmbModelos.Text = "" Then
                mensajeAdvertencia("El combo modelo Say no puede estar vacío.")
                Exit Sub
            End If

            If Not rdbDocenasNormales.Checked And Not rdbDocenasEspeaciales.Checked Then
                mensajeAdvertencia("Debes seleccionar al menos un tipo de docena.")
                Exit Sub
            End If

            If rdbDocenasNormales.Checked Then
                If txtNumeroDocenasNormales.Text = "" Then
                    mensajeAdvertencia("El campo numero de docenas no puede estas vacío.")
                    Exit Sub
                End If
            End If

            If rdbDocenasEspeaciales.Checked Then
                If txtParesPorAtados.Text = "" Then
                    mensajeAdvertencia("El campo numero de pares por atado no puede estar vacío.")
                    Exit Sub
                End If
            End If


            If GuardarLoteDocenas() Then
                If chkImprimirEtiquetaGranel.Checked Then
                    dtZpl = objNeg.ImprimirGranel(txtLoteGranel.Text, txtDocenaGranel.Text, 4, Date.Now.Year, cmbImpresoraGranel.SelectedValue, _UsuarioId, Date.Now)
                    dtGrf = objNeg.ComandosImprimirEtiquetasSAY_Lotes(txtLoteGranel.Text, txtLoteGranel.Text, 4, CInt(Year(Format(fechaPrograma, "dd/MM/yyyy"))), cmbImpresoraGranel.SelectedValue)

                    If Not IsNothing(dtZpl) Then
                        If dtZpl.Rows.Count > 0 Then
                            GenerarArchivoEtiquetasTxt(dtZpl)
                            If Not IsNothing(dtGrf) Then
                                If dtGrf.Rows.Count > 0 Then
                                    GenerarArchivoEtiquetasBat(dtGrf)
                                    ejecutarBat()
                                    msgExito.mensaje = "Se ejecutó la impresión correctamente."
                                    msgExito.ShowDialog()
                                    cmbModelos_SelectedIndexChanged()
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
                    msgExito.mensaje = "Se guardo la información correctamente."
                    msgExito.ShowDialog()
                    cmbModelos_SelectedIndexChanged()
                End If


            End If

        Catch ex As Exception
            msgError.mensaje = ex.Message + vbCrLf + ex.Source + vbCrLf + ex.StackTrace
            msgError.ShowDialog()
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Function GuardarLoteDocenas() As Boolean
        Dim idNave As Integer = 4
        Dim objNeg As New Negocios.EtiquetasBU
        Dim Resultado As Boolean
        Dim arr(19) As Integer
        Dim Valor As String
        Dim Total As String
        Dim paresXatado As String
        Dim tmpCad As String


        Dim mAtadosarr As Object
        Dim mAtadosParr As Object
        Dim strCod As String
        Dim noatad As Integer
        Dim cont As Integer
        Dim strTalla As String
        Dim strCodPar As String
        Dim lsSQL As String = String.Empty

        Try
            objNeg.InsertarLoteGranel(txtLoteGranel.Text, PielColor, CodigoSicy, TallaSicy)
            If rdbDocenasNormales.Checked Then
                objNeg.ReingresosGranelInsertaDocenasNormales(txtNumeroDocenasNormales.Text, 4, txtLoteGranel.Text, TallaSicy, CodigoSicy, txtDocenaGranel.Text)
                Resultado = True
            ElseIf rdbDocenasEspeaciales.Checked Then
                For i = 0 To grdVDocenasEspeciales.Columns.Count - 2
                    Valor = grdVDocenasEspeciales.GetRowCellValue(0, grdVDocenasEspeciales.Columns.Item(i).FieldName).ToString()
                    arr(i) = CInt(IIf(Valor = "", 0, Valor))
                Next

                Total = grdVDocenasEspeciales.GetRowCellValue(0, "TOTAL").ToString()

                paresXatado = txtParesPorAtados.Text

                tmpCad = mAtados(0, 0, 0, CInt(IIf(Total = "", 0, Total)), CInt(IIf(paresXatado = "", 0, paresXatado)), arr)

                'INSERTAR DOCENAS Y PARES GRANEL
                If tmpCad <> vbNullString Then
                    'Asigna el arreglo de cadenas separado por "/" resultante de la funcion de mAtados a la variable matadosarr
                    mAtadosarr = Split(tmpCad, "/")

                    For noatad = LBound(mAtadosarr) To UBound(mAtadosarr) - 1

                        mAtadosParr = Split(mAtadosarr(noatad), ",")

                        'Insertar Docena
                        strCod = "4" & txtLoteGranel.Text & CStr(CInt(txtDocenaGranel.Text) + noatad) & (((Year(Date.Now).ToString()))) & CInt(mAtadosParr(UBound(mAtadosParr)))

                        'objNeg.InsertarLoteDocenaGranel(strCod, txtLoteGranel.Text, CInt(Year(Date.Now)), txtDocenaGranel.Text + noatad, CInt(mAtadosParr(UBound(mAtadosParr))))

                        lsSQL = lsSQL & "INSERT INTO LotesDocenas (IdDocena, Nave, Lote, Año, No_Docena, No_Pares, Tipo, Fecha, Saldo, IdAlmacen, PedidoSICY, IdPartida, IdLote, IdtblCancelacion, Empaque, StAtado) " &
                                "VALUES ('" & strCod & "'," & "4" & "," & txtLoteGranel.Text & "," & CInt(Year(Date.Now)) & "," & (txtDocenaGranel.Text + noatad) & "," & CInt(mAtadosParr(UBound(mAtadosParr))) & ",'G',GetDate(), 0, 1, 0,0,0,0,'A','A')" & vbCrLf

                        cont = 1
                        For j = 1 To BuscarFinTallas(TallaSicy)
                            'Insertar Pares
                            For i = 1 To CInt(mAtadosParr(j))
                                strTalla = BuscarTalla(j, TallaSicy)
                                strCodPar = "4" & txtLoteGranel.Text & CStr(CInt(txtDocenaGranel.Text) + noatad) & (((Year(Date.Now).ToString()))) & cont


                                'objNeg.InsertarDocenaParGranel(strCod, strCodPar, strTalla, txtLoteGranel.Text, CodigoSicy, TallaSicy)

                                lsSQL = lsSQL & "INSERT INTO tmpDocenasPares (Id_Docena, Id_Par, Calce, Pares, Status, IdtblNave, IdtblLote, IdtblAño, IdtblPrograma, IdtblAlmacen, IdtblPedido, IdtblPartida, IdtblTienda, IdtblOrdApartado, IdtblPartidaOrdApa, IdtblProducto, IdtblTalla, Idtblcte, TipoNumeracion, IdtblCancelacion, Disponible, Asignado, Calidad, Bloqueado, Transito, Reservado, Devolucion, IdtblMovimiento, Reproceso) " &
                                                "VALUES ('" & strCod & "','" & strCodPar & "','" & strTalla & "',1,0," & "4" & "," & txtLoteGranel.Text & "," & CInt(Year(Date.Now)) & ",0,1,0,0,0,0,0,'" & CodigoSicy & "','" & TallaSicy & "',0,'G',0,0,0,0,0,0,0,0,0,0)" & vbCrLf
                                cont = cont + 1
                            Next i

                        Next j

                    Next noatad
                    '                    txtDocenaGranel2 = txtDocenaGranel + (noatad - 1)
                    objNeg.EjecutaConsulta(False, lsSQL)
                    Resultado = True
                Else
                    MsgBox("Imposible generar atados " & vbCrLf & vbCrLf & "Avise a Sistemas", vbCritical, "Error")

                End If

            End If
        Catch ex As Exception
            msgError.mensaje = ex.Message + vbCrLf + ex.Source + vbCrLf + ex.StackTrace
            msgError.ShowDialog()
        End Try
        Return Resultado
    End Function

    Private Function mAtados(IdPedido As Long, IdPartida As Long, IdLote As Integer, pRs As Integer, TamAtado As Byte, ParamArray arr() As Integer) As String
        Dim Max As Integer       ' Mantiene el maximo de elementos del arreglo
        Dim NumAtados As Integer ' Numero Maximo de Atados
        Dim x, Y As Integer      ' Cordenadas

        Dim Saldo As Integer    ' mantiene el saldo
        Dim pasada As Long
        Dim bandera As Boolean
        Dim Residuo As Single
        Dim Residuo2 As Integer ' Residuo en Pares
        Dim ultimo As Integer
        Dim s As String        ' Contiene la cadena de distribucion por atado
        Dim mSQL As String     ' Contiene el arreglo de cadenas que retornara el sistema
        Dim sumprs As Byte     ' Contiene el total de los pares por atado


        Try
            Max = UBound(arr) + 1

            Residuo = Format((pRs / TamAtado) - Fix(pRs / TamAtado), "##0.00")

            ultimo = 1
            If Residuo > 0 Then
                NumAtados = Fix(pRs / TamAtado) + 1
                If Residuo <= 0.5 Then ultimo = 2
            Else
                NumAtados = Fix(pRs / TamAtado)
            End If

            Dim Atados(NumAtados, Max) As Integer

            'residuo en pares
            Residuo2 = pRs - Fix(pRs / TamAtado) * TamAtado

            'Inicializa variables
            Saldo = pRs
            pasada = -1
            bandera = True
            mSQL = ""

            ' Inicia la distribucion de pares por atado
            While Saldo > 0 And (Saldo > Residuo2 Or Residuo > 0.5)

                pasada = pasada + 1

                If pasada Mod 2 > 0 Then
                    bandera = False
                Else
                    bandera = True
                End If

                For Y = 0 To NumAtados - ultimo

                    If bandera Then
                        x = 0
                        bandera = False
                    Else
                        x = 1
                        bandera = True
                    End If

                    For x = x To Max - 1 Step 2
                        If arr(x) > 0 And Atados(Y, Max) < TamAtado Then
                            If Y < (NumAtados - 1) Then
                                Atados(Y, x) = Atados(Y, x) + 1
                                Atados(Y, Max) = Atados(Y, Max) + 1
                                arr(x) = arr(x) - 1
                                Saldo = Saldo - 1
                            Else
                                If Atados(Y, Max) < Residuo2 Or Residuo2 = 0 Then
                                    Atados(Y, x) = Atados(Y, x) + 1
                                    Atados(Y, Max) = Atados(Y, Max) + 1
                                    arr(x) = arr(x) - 1
                                    Saldo = Saldo - 1
                                End If
                            End If
                        End If
                    Next x

                Next Y

            End While

            If Residuo > 0 And Residuo <= 0.5 Then
                Y = NumAtados - 1
                For x = 0 To Max - 1
                    If arr(x) > 0 And Atados(Y, Max) < TamAtado Then

                        Atados(Y, x) = Atados(Y, x) + arr(x)
                        Atados(Y, Max) = Atados(Y, Max) + arr(x)
                        arr(x) = arr(x) - arr(x)
                        Saldo = Saldo - arr(x)

                    End If
                Next x
            End If

            ' Inicia generacion de arreglo de atados con la distribucion generada separada por "/"
            For Y = 0 To NumAtados - 1
                'c = 0
                sumprs = 0
                s = ""
                For x = 0 To Max - 1
                    sumprs = sumprs + Val(Atados(Y, x))
                    s = s & ", " & Atados(Y, x)
                Next x
                mSQL = mSQL & (Y + 1) & s & ", " & CStr(sumprs) & "/"
            Next Y
            'retorna la cadena de docenas
            mAtados = mSQL
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function BuscarFinTallas(ByVal iIdTalla As String) As Integer
        Dim objNeg As New Negocios.EtiquetasBU
        Dim dt As DataTable

        dt = objNeg.BuscarFinTallas(iIdTalla)

        If dt.Rows.Count > 0 Then
            BuscarFinTallas = dt.Rows(0).Item("Tallas")
        Else
            BuscarFinTallas = 0
        End If
    End Function

    Private Function BuscarTalla(ByVal num As String, ByVal idTalla As String) As String
        Dim objNeg As New Negocios.EtiquetasBU
        Dim dt As DataTable
        dt = objNeg.BuscarTalla(num, idTalla)

        If dt.Rows.Count > 0 Then
            BuscarTalla = dt.Rows(0).Item("Tall")
        Else
            BuscarTalla = ""
        End If
    End Function

    Private Sub txtModeloSAY_KeyDown(sender As Object, e As KeyEventArgs) Handles txtModeloSAY.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim dtModelos As DataTable
            Dim objNeg As New Negocios.EtiquetasBU
            lblModeloMensaje.Visible = False
            cmbModelos.DataSource = Nothing
            Try
                Cursor = Cursors.WaitCursor
                ModeloSAY = txtModeloSAY.Text.Trim.ToString
                If ModeloSAY.Length > 0 Then
                    dtModelos = objNeg.ConsultarModelosGranel(ModeloSAY)
                    If Not IsNothing(ModeloSAY) Then
                        If dtModelos.Rows.Count > 0 Then
                            cmbModelos.DataSource = dtModelos
                            cmbModelos.ValueMember = "id"
                            cmbModelos.DisplayMember = "DescripcionCompleta"
                            cmbModelos.SelectedIndex = 0
                        Else
                            lblModeloMensaje.Visible = True
                        End If
                    Else
                        lblModeloMensaje.Visible = True
                    End If
                Else
                    cmbModelos.DataSource = Nothing
                End If
            Catch ex As Exception
                msgError.mensaje = ex.Message + vbCrLf + ex.Source + vbCrLf + ex.StackTrace
                msgError.ShowDialog()
            Finally
                Cursor = Cursors.Default
                dtModelos = Nothing
                objNeg = Nothing
            End Try
        End If
    End Sub

    Private Sub txtCadenaAtados_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCadenaAtados.KeyPress

        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False 'verdadero
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False 'verdadero
        ElseIf e.KeyChar = "," Then
            e.Handled = False
        ElseIf e.KeyChar = "-" Then
            e.Handled = False
        Else
            e.Handled = True 'falso
        End If
    End Sub

    Private Sub TabOpcionesDeImpresion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabOpcionesDeImpresion.SelectedIndexChanged

        If _Accion = 2 Then
            If Not (TabOpcionesDeImpresion.SelectedTab.Equals(TabClientes) Or TabOpcionesDeImpresion.SelectedTab.Equals(TabRastreos) Or TabOpcionesDeImpresion.SelectedTab.Equals(TabLengua)) Then
                mensajeAdvertencia("No se puede seleccionar la pestaña " + TabOpcionesDeImpresion.SelectedTab.Text + " en modo de prueba")
                TabOpcionesDeImpresion.SelectedTab = TabClientes
            End If
        ElseIf _Accion = 1 Then
            If TabOpcionesDeImpresion.SelectedTab.Equals(TabAtados) Then
                txtLoteDe.Focus()
            ElseIf TabOpcionesDeImpresion.SelectedTab.Equals(TabPares) Then
                cmbTipoImpresion.Focus()
            ElseIf TabOpcionesDeImpresion.SelectedTab.Equals(TabGranel) Then
                txtModeloSAY.Focus()
            ElseIf TabOpcionesDeImpresion.SelectedTab.Equals(TabClientes) Then
                cmbClientesPruebas.Focus()
            ElseIf TabOpcionesDeImpresion.SelectedTab.Equals(TabLengua) Then
                cmbTipoImpresionLengua.Focus()
            ElseIf TabOpcionesDeImpresion.SelectedTab.Equals(TabRastreos) Then
                cmbClienteRastreo.Focus()
            End If
        End If
    End Sub

    Private Sub chboxSeleccionarTodo_CheckedChanged(sender As Object, e As EventArgs) Handles chboxSeleccionarTodo.CheckedChanged
        Dim NumeroFilas As Integer = 0
        Try
            Cursor = Cursors.WaitCursor
            NumeroFilas = grdVClientesPruebaApartados.DataRowCount
            For index As Integer = 0 To NumeroFilas Step 1
                'If grdVPeidosMuestrasOP.GetRowCellValue(index, "Estatus") = "CAPTURADO" Then
                grdVClientesPruebaApartados.SetRowCellValue(grdVClientesPruebaApartados.GetVisibleRowHandle(index), "Sel", chboxSeleccionarTodo.Checked)
                ' End If
            Next
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub chboxSeleccionarTodoPares_CheckedChanged(sender As Object, e As EventArgs) Handles chboxSeleccionarTodoPares.CheckedChanged
        Dim NumeroFilas As Integer = 0
        Try
            Cursor = Cursors.WaitCursor
            NumeroFilas = grdVPares.DataRowCount
            For index As Integer = 0 To NumeroFilas Step 1
                'If grdVPeidosMuestrasOP.GetRowCellValue(index, "Estatus") = "CAPTURADO" Then
                grdVPares.SetRowCellValue(grdVPares.GetVisibleRowHandle(index), "Imprimir", chboxSeleccionarTodoPares.Checked)
                ' End If
            Next
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub txtCadenaAtados_TextChanged(sender As Object, e As EventArgs) Handles txtCadenaAtados.TextChanged

        CadenaAtadosValida = False
        lblEjemplo.Visible = False

        If txtCadenaAtados.Text.ToString.Trim.Length > 0 Then
            If Regex.IsMatch(txtCadenaAtados.Text.Trim.ToString, "^[0-9]+\-[0-9]+$") Or Regex.IsMatch(txtCadenaAtados.Text.Trim.ToString, "^[0-9]+(,[0-9]+)+$") Or Regex.IsMatch(txtCadenaAtados.Text.Trim.ToString, "^[0-9]+$") Then
                CadenaAtadosValida = True
            Else
                lblEjemplo.Visible = True
            End If
        Else
            CadenaAtadosValida = True
        End If

    End Sub


    Private Sub cmbClientesPruebasTipoEtiqueta_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbClientesPruebasTipoEtiqueta.SelectedIndexChanged
        Dim TipoEtiqueta As Integer = 0
        Dim ClienteSAYID As Integer = 0
        Dim FuenteInformacion As Integer = 0

        Try
            If EsPrimeraCargaPantalla = True Then
                Return
            End If

            TipoEtiqueta = cmbClientesPruebasTipoEtiqueta.SelectedValue
            ClienteSAYID = cmbClientesPruebas.SelectedValue

            FuenteInformacion = dtCllientePruebaTipoEtiqueta.AsEnumerable().Where(Function(x) x.Item("etiq_tipoetiquetaid") = TipoEtiqueta).Select(Function(y) y.Item("fiet_fuenteinformacionetiquetaid")).FirstOrDefault()

            If FuenteInformacion = 6 Then
                rbLotes.Enabled = False
                rbPedidoSay.Enabled = False
                rbPedidoSicy.Enabled = False
                rbApartado.Enabled = False
                chkMostrarDetalles.Enabled = False
                EsImpresionConArchivo = True
                txtPedidoSICY.Enabled = True
                rbPedidoSicy.Enabled = True
                rbPedidoSicy.Checked = True
            Else
                rbLotes.Enabled = True
                rbPedidoSay.Enabled = True
                rbPedidoSicy.Enabled = True
                rbApartado.Enabled = True
                chkMostrarDetalles.Enabled = True
                EsImpresionConArchivo = False
            End If

        Catch ex As Exception
            show_message("Error", ex.Message.ToString())
            EsImpresionConArchivo = False
        End Try




    End Sub

    Private Function LeerExcel(ByVal RutaArchivo As String) As DataTable
        Dim dtArchivoExcel As DataTable
        Dim NombreArchivo As String
        dtArchivoExcel = Tools.Excel.LlenarTablaExcelListaTablas("", RutaArchivo, "")
        Return dtArchivoExcel
    End Function


    Private Sub GeneraArchivosParaImpresion_ConArchivo(ByVal dtEtiquetas As DataTable)
        Dim strStreamW As Stream = Nothing
        Dim strStreamWriter As StreamWriter = Nothing
        Dim EtiquetasAImprimir As String = String.Empty
        Dim LotesSeleccionados As String = String.Empty

        Try

            Cursor = Cursors.WaitCursor
            strStreamW = CrearRutasArchivo(CarpetaUbicacionArchivos, RutaArchivoEtiquetas)
            strStreamWriter = New StreamWriter(strStreamW, System.Text.Encoding.Default) ' tipo de codificacion para escritura

            'Escribir la informacion de las etiquetas en el archivo
            For Each FILA As DataRow In dtEtiquetas.Rows
                EtiquetasAImprimir &= FILA.Item(0)
            Next
            strStreamWriter.WriteLine(EtiquetasAImprimir)
            strStreamWriter.Close()
            'Generar archivo bat para enviar a imprimir las etiquetas
            GenerarArchivoBat_Archivo()
            show_message("Exito", "Se ha enviado a imprimir.")
            Cursor = Cursors.Default

        Catch ex As Exception
            Cursor = Cursors.Default
            Throw ex
        End Try

    End Sub


    Private Sub txtAmarreLengua_TextChanged(sender As Object, e As EventArgs) Handles txtAmarreLengua.TextChanged
        CadenaAtadosValidaLengua = False
        lblEjemploLengua.Visible = False

        If txtAmarreLengua.Text.ToString.Trim.Length > 0 Then
            If Regex.IsMatch(txtAmarreLengua.Text.Trim.ToString, "^[0-9]+\-[0-9]+$") Or Regex.IsMatch(txtAmarreLengua.Text.Trim.ToString, "^[0-9]+(,[0-9]+)+$") Then
                CadenaAtadosValidaLengua = True
            Else
                lblEjemploLengua.Visible = True
            End If
        Else
            CadenaAtadosValidaLengua = True
        End If
    End Sub

    Private Sub txtAmarreLengua_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtAmarreLengua.KeyPress

        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False 'verdadero
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False 'verdadero
        ElseIf e.KeyChar = "," Then
            e.Handled = False
        ElseIf e.KeyChar = "-" Then
            e.Handled = False
        Else
            e.Handled = True 'falso
        End If
    End Sub

    Private Sub GenerarArchivoBat_Archivo()
        Dim strStreamW As Stream = Nothing
        Dim strStreamWriter As StreamWriter = Nothing
        Dim PathArchivo As String
        Dim dtArchivo As DataTable

        Try
            Cursor = Cursors.WaitCursor



            If System.IO.Directory.Exists(CarpetaUbicacionArchivos) = False Then
                System.IO.Directory.CreateDirectory(CarpetaUbicacionArchivos)
            End If

            PathArchivo = RutaArchivoBat ' Se determina el nombre del archivo con la fecha actual

            'verificamos si existe el archivo
            If File.Exists(PathArchivo) Then
                File.Delete(PathArchivo)
                strStreamW = File.Create(PathArchivo)
            Else
                strStreamW = File.Create(PathArchivo) ' lo creamos
            End If

            strStreamWriter = New StreamWriter(strStreamW, System.Text.Encoding.Default) ' tipo de codificacion para escritura
            strStreamWriter.WriteLine("COPY C:\SAY\ETIQUETAS.TXT C:\PRN")
            strStreamWriter.Close() ' cerrar
            'Ejecutar el archivo bat
            Shell(RutaArchivoBat)
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            Throw ex
            'show_message("Error", "Ocurrio un error al generar el archivo, vuelva a intentar.")
        End Try
    End Sub

    Private Sub CrearExcelBatta(ByVal dtZpl As DataTable)
        Dim Directorio As String = "C:\EtiquetasNiceLabel\"
        Dim DirectorioCoppel As String = "C:\EtiquetasNiceLabelCoppel\"
        Dim Archivo As String = "EtiquetaParBatta_Excel.xlsx"
        Dim ArchivoCoppel As String = "EtiquetaParCoppel_Excel.xlsx"
        Dim DirectorioPriceShoes As String = "C:\EtiquetasPriceShoesLabel\"
        Dim ArchivoPriceShoes As String = "EtiquetaParPriceShoes_Excel.xlsx"

        If Not IsNothing(dtZpl) Then
            If dtZpl.Rows.Count > 0 Then
                grdEtiquetasBatta.DataSource = dtZpl

                If cmbClientesPruebas.SelectedValue = 763 Or cmbClientesPruebas.SelectedValue = 1181 Then 'Coppel
                    If Not System.IO.Directory.Exists(DirectorioCoppel) Then
                        System.IO.Directory.CreateDirectory(DirectorioCoppel)
                    End If
                    Try
                        Dim exportOptions As New XlsxExportOptionsEx()
                        exportOptions.SheetName = "Hoja1"
                        grdVEtiquetasBatta.ExportToXlsx(DirectorioCoppel & ArchivoCoppel, exportOptions)
                        Tools.Controles.Mensajes_Y_Alertas("EXITO", "Realice la impresión de las etiquetas del archivo " + ArchivoCoppel + " desde Nice Label (Diseño: EtiquetaParCoppel_Excel.nlbl)  ")
                    Catch ex As Exception
                        Tools.Controles.Mensajes_Y_Alertas("ERROR", ex.Message)
                    End Try
                End If

                If cmbClientesPruebas.SelectedValue = 103 Or cmbClientesPruebas.SelectedValue = 1230 Then 'Batta
                    If Not System.IO.Directory.Exists(Directorio) Then
                        System.IO.Directory.CreateDirectory(Directorio)
                    End If
                    Try
                        Dim exportOptions As New XlsxExportOptionsEx()
                        exportOptions.SheetName = "Hoja1"
                        grdVEtiquetasBatta.ExportToXlsx(Directorio & Archivo, exportOptions)
                        Tools.Controles.Mensajes_Y_Alertas("EXITO", "Realice la impresión de las etiquetas del archivo EtiquetaParBatta_Excel.xlsx desde Nice Label (Diseño: EtiquetaParBatta_Excel.nlbl)  ")
                    Catch ex As Exception
                        Tools.Controles.Mensajes_Y_Alertas("ERROR", ex.Message)
                    End Try
                End If

                If cmbClientesPruebas.SelectedValue = 17 Or cmbClientesPruebas.SelectedValue = 17 Then
                    If Not System.IO.Directory.Exists(DirectorioPriceShoes) Then
                        System.IO.Directory.CreateDirectory(DirectorioPriceShoes)
                    End If
                    Try
                        Dim exportOptions As New XlsxExportOptionsEx()
                        exportOptions.SheetName = "Hoja1"
                        grdVEtiquetasBatta.ExportToXlsx(DirectorioPriceShoes & ArchivoPriceShoes, exportOptions)
                        Tools.Controles.Mensajes_Y_Alertas("EXITO", "Realice la impresión de las etiquetas del archivo EtiquetaParPriceShoes_Excel.xlsx desde Label Matrix")
                    Catch ex As Exception
                        Tools.Controles.Mensajes_Y_Alertas("ERROR", ex.Message)
                    End Try
                End If

            End If
        End If
    End Sub

    Private Sub cmbClienteLengua_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbClienteLengua.SelectedIndexChanged
        cmbColeccionLengua.DataSource = Nothing
        cmbColeccionLengua.Text = Nothing

        If cmbClienteLengua.SelectedIndex > 0 Then
            Dim ClienteID As Integer = cmbClienteLengua.SelectedValue
            CargarColeccionesLengua(ClienteID)
        End If
    End Sub

    Private Sub chkDevCompleta_CheckedChanged(sender As Object, e As EventArgs) Handles chkDevCompleta.CheckedChanged
        lblTxtLotes_Dev.Visible = Not chkDevCompleta.Checked
        txtLoteInicio_Devolucion.Visible = Not chkDevCompleta.Checked
        lblTxtAtado_Dev.Visible = Not chkDevCompleta.Checked
        txtNumAtado_Devolucion.Visible = Not chkDevCompleta.Checked
        lblTxtLoteAl.Visible = Not chkDevCompleta.Checked
        txtLoteFin_Devolucion.Visible = Not chkDevCompleta.Checked
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles rdbLotes.CheckedChanged
        If rdbLotes.Checked = True Then
            grpbDevoluciones.Enabled = False
            grpbLotes.Enabled = True
        End If
    End Sub

    Private Sub rdbDevoluciones_CheckedChanged(sender As Object, e As EventArgs) Handles rdbDevoluciones.CheckedChanged
        If rdbDevoluciones.Checked = True Then
            grpbLotes.Enabled = False
            grpbDevoluciones.Enabled = True
        End If
    End Sub

    Private Sub txtFolioDevolucion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFolioDevolucion.KeyPress
        e.Handled = soloNumeros(sender, e)
    End Sub

    Private Sub txtFolioDevSay_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFolioDevSay.KeyPress
        e.Handled = soloNumeros(sender, e)
    End Sub

    Private Sub txtNumAtado_Devolucion_TextChanged(sender As Object, e As EventArgs) Handles txtNumAtado_Devolucion.TextChanged
        CadenaAtadosValida_Devolucion = False
        lblEjemploAtados_Dev.Visible = False

        If txtNumAtado_Devolucion.Text.ToString.Trim.Length > 0 Then
            If Regex.IsMatch(txtNumAtado_Devolucion.Text.Trim.ToString, "^[0-9]+\-[0-9]+$") Or Regex.IsMatch(txtNumAtado_Devolucion.Text.Trim.ToString, "^[0-9]+(,[0-9]+)+$") Or Regex.IsMatch(txtNumAtado_Devolucion.Text.Trim.ToString, "^[0-9]+$") Then
                CadenaAtadosValida_Devolucion = True
            Else
                lblEjemploAtados_Dev.Visible = True
            End If
        Else
            CadenaAtadosValida_Devolucion = True
        End If
    End Sub

    Private Sub DescargarNiceLabeCoppel(ByVal tipoEtiqueta As Integer)
        Dim obj As New Programacion.Negocios.EtiquetasBU
        Dim tabla As New DataTable
        Dim carpetaOrigen As String = String.Empty
        Dim archivo As String = String.Empty
        Dim carpetaDestino As String = String.Empty
        Dim RutaCompletaLocalCoppel As String = String.Empty
        Dim ImagenFondo As String = String.Empty
        Dim RutaCompletaArchivoLocalCoppel As String = String.Empty
        'Dim cadena As String = String.Empty

        Try
            tabla = obj.DescargarNiceLabeCoppel(tipoEtiqueta)
            If tabla.Rows.Count > 0 Then
                carpetaOrigen = tabla.Rows(0).Item("CarpetaOrigen")
                carpetaDestino = tabla.Rows(0).Item("CarpetaDestino")
                archivo = tabla.Rows(0).Item("Archivo")
                ImagenFondo = tabla.Rows(0).Item("Fondo")
                RutaCompletaArchivoLocalCoppel = carpetaDestino + archivo
                'cadena = archivo.Substring(15, 5)
                If File.Exists(RutaCompletaArchivoLocalCoppel) = False Then
                    RutaCompletaLocalCoppel = objBU.DescargararchivoNiceLabel(carpetaOrigen, carpetaDestino, archivo, ImagenFondo)
                Else
                    File.Delete(RutaCompletaArchivoLocalCoppel)
                    RutaCompletaLocalCoppel = objBU.DescargararchivoNiceLabel(carpetaOrigen, carpetaDestino, archivo, ImagenFondo)
                End If


            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub mensajeCoppel()
        show_message("Advertencia", "No se encontró resultados, consulte que la colección corresponda al tipo de etiqueta (Niño o Adulto)")
        Cursor = Cursors.Default
    End Sub

    Public Sub btnImprimirPlantilla_Click(sender As Object, e As EventArgs) Handles btnImprimirPlantilla.Click
        Dim obj As New Programacion.Negocios.EtiquetasBU
        Dim tabla1 As New DataTable
        Dim accion As Integer = 0
        Dim tablaImagen As New DataTable
        Dim idc As Integer

        Try
            idc = IIf(IsNumeric(cmbClientesPruebas.SelectedValue), cmbClientesPruebas.SelectedValue, 0)
            Me.Cursor = Cursors.WaitCursor

            If idc = 763 Then
                If cmbClientesPruebasTipoEtiqueta.SelectedValue <> 25 And cmbClientesPruebasTipoEtiqueta.SelectedValue <> 26 Then
                    mensajeAdvertencia("Debe Seleccionar al menos un tipo de etiqueta Adulto o Niño.")
                    Me.Cursor = Cursors.Default
                    Exit Sub
                End If
            End If


            If rbLotes.Checked = False And rbPedidoSay.Checked = False And rbPedidoSicy.Checked = False And rbApartado.Checked = False Then
                mensajeAdvertencia("Seleccione al menos una opción de impresion (Lotes, Pedidos, Apartados).")
                Me.Cursor = Cursors.Default
                Exit Sub
            ElseIf rbLotes.Checked Then
                accion = 1

                If txtLoteDelClientesPrueba.Text = "" Then
                    mensajeAdvertencia("El campo de lote del: no puede estar vacío.", txtLoteDelClientesPrueba)
                    Me.Cursor = Cursors.Default
                    Exit Sub
                End If

                If txtLoteAlClientesPruebas.Text = "" Then
                    mensajeAdvertencia("El campo de lote al: no puede estar vacío.", txtLoteAlClientesPruebas)
                    Me.Cursor = Cursors.Default
                    Exit Sub
                End If

                If txtLoteDelClientesPrueba.Text <> "" Then
                    If CInt(txtLoteDelClientesPrueba.Text.Trim) > CInt(txtLoteAlClientesPruebas.Text.Trim) Then
                        mensajeAdvertencia("El lote inicial no puede ser mayor al lote final", txtLoteDelClientesPrueba)
                        Me.Cursor = Cursors.Default
                        Exit Sub
                    End If
                End If

                If idc = 763 Then
                    tablaImagen = obj.ConsultaArticulosSinImagenCoppel(accion, _idNave, cmbClientesPruebasTipoEtiqueta.SelectedValue, CInt(txtLoteDelClientesPrueba.Text), CInt(txtLoteAlClientesPruebas.Text), dtClientesPruebaFechaPrograma.Value, 0, 0, "")
                    If tablaImagen.Rows.Count > 0 Then
                        For index As Integer = 0 To tablaImagen.Rows.Count - 1
                            show_message("Advertencia", "No se encuantra la imagen del articulo: " & tablaImagen.Rows(index).Item(0).ToString)
                        Next

                        Me.Cursor = Cursors.Default
                        Exit Sub
                    Else
                        tabla1 = obj.ConsultaEtiquetasCoppelPantilla(accion, _idNave, cmbClientesPruebasTipoEtiqueta.SelectedValue, CInt(txtLoteDelClientesPrueba.Text), CInt(txtLoteAlClientesPruebas.Text), dtClientesPruebaFechaPrograma.Value, 0, 0, "")
                        If tabla1.Rows.Count < 1 Then
                            mensajeCoppel()
                            Exit Sub
                        End If
                        reporteEtiquetasCoppelPlantilla(tabla1)
                    End If
                End If

                If idc = 103 Or idc = 1230 Then
                    'tablaImagen = obj.ConsultaArticulosSinImagenBatta(accion, _idNave, dtClientesPruebaFechaPrograma.Value, CInt(txtLoteDelClientesPrueba.Text), CInt(txtLoteAlClientesPruebas.Text), 0, 0, "")
                    tabla1 = obj.ConsultaEtiquetasBattaPantilla(accion, _idNave, dtClientesPruebaFechaPrograma.Value, CInt(txtLoteDelClientesPrueba.Text), CInt(txtLoteAlClientesPruebas.Text), 0, 0, "")
                    If tabla1.Rows.Count < 1 Then
                        mensajeBatta()
                        Exit Sub
                    End If
                    ReporteEtiquetasBattaPantilla(tabla1)
                End If



            ElseIf rbPedidoSay.Checked Or rbPedidoSicy.Checked Then
                accion = 2

                If rbPedidoSay.Checked Then
                    If txtPedidoSAY.Text = "" Then
                        mensajeAdvertencia("El campo pedido say no puede estar vacío.", txtPedidoSAY)
                        Me.Cursor = Cursors.Default
                        Exit Sub
                    End If

                    If idc = 763 Then
                        tablaImagen = obj.ConsultaArticulosSinImagenCoppel(accion, _idNave, cmbClientesPruebasTipoEtiqueta.SelectedValue, 0, 0, dtClientesPruebaFechaPrograma.Value, CInt(txtPedidoSAY.Text), 0, "")
                        If tablaImagen.Rows.Count > 0 Then
                            For index As Integer = 0 To tablaImagen.Rows.Count - 1
                                show_message("Advertencia", "No se encuantra la imagen del articulo: " & tablaImagen.Rows(index).Item(0).ToString)
                            Next
                            Me.Cursor = Cursors.Default
                            Exit Sub
                        Else
                            tabla1 = obj.ConsultaEtiquetasCoppelPantilla(accion, _idNave, cmbClientesPruebasTipoEtiqueta.SelectedValue, 0, 0, dtClientesPruebaFechaPrograma.Value, CInt(txtPedidoSAY.Text), 0, "")
                            If tabla1.Rows.Count < 1 Then
                                mensajeCoppel()
                                Exit Sub
                            End If

                            reporteEtiquetasCoppelPlantilla(tabla1)

                        End If
                    End If

                    If idc = 103 Or idc = 1230 Then
                        'tablaImagen = obj.ConsultaArticulosSinImagenBatta(accion, _idNave, dtClientesPruebaFechaPrograma.Value, 0, 0, CInt(txtPedidoSAY.Text), 0, "")
                        tabla1 = obj.ConsultaEtiquetasBattaPantilla(accion, _idNave, dtClientesPruebaFechaPrograma.Value, 0, 0, 0, CInt(txtPedidoSAY.Text), "")
                        If tabla1.Rows.Count < 1 Then
                            mensajeBatta()
                            Exit Sub
                        End If
                        ReporteEtiquetasBattaPantilla(tabla1)
                    End If

                ElseIf rbPedidoSicy.Checked Then
                    If txtPedidoSICY.Text = "" Then
                        mensajeAdvertencia("El campo pedido sicy no puede estar vacío.", txtPedidoSICY)
                        Me.Cursor = Cursors.Default
                        Exit Sub
                    End If
                    If idc = 763 Then
                        tablaImagen = obj.ConsultaArticulosSinImagenCoppel(accion, _idNave, cmbClientesPruebasTipoEtiqueta.SelectedValue, 0, 0, dtClientesPruebaFechaPrograma.Value, 0, CInt(txtPedidoSICY.Text), "")
                        If tablaImagen.Rows.Count > 0 Then
                            For index As Integer = 0 To tablaImagen.Rows.Count - 1
                                show_message("Advertencia", "No se encuantra la imagen del articulo: " & tablaImagen.Rows(index).Item(0).ToString)
                            Next
                            Me.Cursor = Cursors.Default
                            Exit Sub
                        Else
                            tabla1 = obj.ConsultaEtiquetasCoppelPantilla(accion, _idNave, cmbClientesPruebasTipoEtiqueta.SelectedValue, 0, 0, dtClientesPruebaFechaPrograma.Value, CInt(txtPedidoSICY.Text), 0, "")
                            If tabla1.Rows.Count < 1 Then
                                mensajeCoppel()
                                Exit Sub
                            End If
                        End If

                        reporteEtiquetasCoppelPlantilla(tabla1)

                    End If
                    If idc = 103 Or idc = 1230 Then
                        'tablaImagen = obj.ConsultaArticulosSinImagenBatta(accion, _idNave, dtClientesPruebaFechaPrograma.Value, 0, 0, CInt(txtPedidoSAY.Text), 0, "")
                        tabla1 = obj.ConsultaEtiquetasBattaPantilla(accion, _idNave, dtClientesPruebaFechaPrograma.Value, 0, 0, CInt(txtPedidoSICY.Text), 0, "")
                        If tabla1.Rows.Count < 1 Then
                            mensajeBatta()
                            Exit Sub
                        End If

                        ReporteEtiquetasBattaPantilla(tabla1)

                    End If
                End If


            ElseIf rbApartado.Checked Then
                accion = 3
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
                        If idc = 763 Then
                            tablaImagen = obj.ConsultaArticulosSinImagenCoppel(accion, _idNave, cmbClientesPruebasTipoEtiqueta.SelectedValue, 0, 0, dtClientesPruebaFechaPrograma.Value, 0, 0, sb.ToString)
                            If tablaImagen.Rows.Count > 0 Then
                                For index As Integer = 0 To tablaImagen.Rows.Count - 1
                                    show_message("Advertencia", "No se encuantra la imagen del articulo: " & tablaImagen.Rows(index).Item(0).ToString)
                                Next
                                Me.Cursor = Cursors.Default
                                Exit Sub
                            Else
                                tabla1 = obj.ConsultaEtiquetasCoppelPantilla(accion, _idNave, cmbClientesPruebasTipoEtiqueta.SelectedValue, 0, 0, dtClientesPruebaFechaPrograma.Value, 0, 0, sb.ToString)
                                If tabla1.Rows.Count < 1 Then
                                    mensajeCoppel()
                                    Me.Cursor = Cursors.Default
                                    Exit Sub
                                End If
                            End If

                            reporteEtiquetasCoppelPlantilla(tabla1)
                        End If
                        If idc = 103 Or idc = 1230 Then
                            'tablaImagen = obj.ConsultaArticulosSinImagenBatta(accion, _idNave, dtClientesPruebaFechaPrograma.Value, 0, 0, CInt(txtPedidoSAY.Text), 0, "")
                            tabla1 = obj.ConsultaEtiquetasBattaPantilla(accion, _idNave, dtClientesPruebaFechaPrograma.Value, 0, 0, 0, 0, sb.ToString)
                            If tabla1.Rows.Count < 1 Then
                                mensajeBatta()
                                Exit Sub
                            End If
                            ReporteEtiquetasBattaPantilla(tabla1)
                        End If


                    Else
                        mensajeAdvertencia("No se encontraron registros seleccionados.")
                        Exit Sub
                    End If
                Else
                    mensajeAdvertencia("No se encontraron registros en el panel de datos de apartado.")
                    Exit Sub
                End If
            End If
            Me.Cursor = Cursors.Default

        Catch ex As Exception
            show_message("Error", ex.Message)
            Me.Cursor = Cursors.Default
        End Try

    End Sub

    Public Sub reporteEtiquetasCoppelPlantilla(ByVal tabla1 As DataTable)
        Dim ds As New DataSet
        Dim singleFile As New StiReport

        Dim Ruta As String = ""
        'Ruta = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\EtiquetasCoppelPlantillaPDF"
        Try
            LimpiarMemoria()

            Dim OBJReporte As New Framework.Negocios.ReportesBU
            Dim EntidadReporte As Entidades.Reportes

            If cmbClientesPruebasTipoEtiqueta.SelectedValue = 25 Then
                ' CarlosMtz (Se crea nuevo reporte para etiqueta de coppel por plantilla, agregando un separador por cada Lote)
                'EntidadReporte = OBJReporte.LeerReporteporClave("REPORTE_ETIQUETASCOPPELPLANTILLA_ADULTO") 
                EntidadReporte = OBJReporte.LeerReporteporClave("REPORTE_ETIQUETASCOPPELPLANTILLA_ADULTO_LOTE")
            ElseIf cmbClientesPruebasTipoEtiqueta.SelectedValue = 26 Then
                'EntidadReporte = OBJReporte.LeerReporteporClave("REPORTE_ETIQUETASCOPPELPLANTILLA_NINO")
                EntidadReporte = OBJReporte.LeerReporteporClave("REPORTE_ETIQUETASCOPPELPLANTILLA_NINO_LOTE")
            End If


            Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
                        EntidadReporte.Pnombre + ".mrt"
            My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)
            Dim reporte As New StiReport

            ds.Tables.Add(tabla1)

            reporte.Load(archivo)
            reporte.Compile()
            reporte.RegData(ds)
            reporte.Dictionary.Synchronize()
            'reporte.Render()
            reporte.Print()


            '**************************************************************

            'Dim JoinReport As StiReport = New StiReport
            'JoinReport.NeedsCompiling = False
            'JoinReport.IsRendered = True
            'JoinReport.RenderedPages.Clear()






            'For Each Fila As DataRow In tabla1.Rows
            '    Dim TablaTemporal As DataTable
            '    TablaTemporal = tabla1.Clone
            '    TablaTemporal.Rows.Clear()
            '    Dim obj As New ReportesBU
            '    Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
            '    EntidadReporte.Pnombre + ".mrt"
            '    My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)
            '    Dim reporte As New StiReport
            '    Dim ds As New DataSet

            '    TablaTemporal.ImportRow(Fila)
            '    ds.Tables.Add(TablaTemporal)
            '    reporte.Load(archivo)
            '    reporte.Compile()
            '    reporte.RegData(ds)
            '    reporte.Dictionary.Synchronize()
            '    reporte.Render()

            '    For Each Page As Stimulsoft.Report.Components.StiPage In reporte.CompiledReport.RenderedPages
            '        Page.Report = JoinReport
            '        Page.NewGuid()
            '        JoinReport.RenderedPages.Add(Page)
            '    Next

            '    'reporte.Print()


            'Next



            ''JoinReport.Show()
            'JoinReport.Print()

            '**************************************************************
#Region "Codigo para exportar a PDF"

            'If cmbClientesPruebasTipoEtiqueta.SelectedValue = 25 Then
            '    If rbLotes.Checked Then
            '        Ruta = Ruta + "\" + Nave
            '        If Not System.IO.Directory.Exists(Ruta) Then
            '            Directory.CreateDirectory(Ruta)
            '        End If
            '        reporte.ExportDocument(StiExportFormat.Pdf, Ruta + "\PlantillaEtiquetasCoppelAdulto Programa_" + dtpFechaPrograma.Value.ToString("dd_MM_yyyy") + ".pdf")
            '    ElseIf rbPedidoSay.Checked Or rbPedidoSicy.Checked Then
            '        Ruta = Ruta + "\Pedidos Y Apartados"
            '        If Not System.IO.Directory.Exists(Ruta) Then
            '            Directory.CreateDirectory(Ruta)
            '        End If
            '        reporte.ExportDocument(StiExportFormat.Pdf, Ruta + "\PlantillaEtiquetasCoppelAdulto Pedido_" + IIf(txtPedidoSAY.Text <> String.Empty, txtPedidoSAY.Text, txtPedidoSICY.Text) + ".pdf")
            '    ElseIf rbApartado.Checked Then
            '        Ruta = Ruta + "\Pedidos Y Apartados"
            '        If Not System.IO.Directory.Exists(Ruta) Then
            '            Directory.CreateDirectory(Ruta)
            '        End If
            '        reporte.ExportDocument(StiExportFormat.Pdf, Ruta + "\PlantillaEtiquetasCoppelAdulto Apartado_" + sb.ToString() + ".pdf")
            '    End If

            'ElseIf cmbClientesPruebasTipoEtiqueta.SelectedValue = 26 Then
            '    If rbLotes.Checked Then
            '        Ruta = Ruta + "\" + Nave
            '        If Not System.IO.Directory.Exists(Ruta) Then
            '            Directory.CreateDirectory(Ruta)
            '        End If
            '        reporte.ExportDocument(StiExportFormat.Pdf, Ruta + "\PlantillaEtiquetasCoppelNiño Programa_" + dtpFechaPrograma.Value.ToString("dd_MM_yyyy") + ".pdf")
            '    ElseIf rbPedidoSay.Checked Or rbPedidoSicy.Checked Then
            '        Ruta = Ruta + "\Pedidos Y Apartados"
            '        If Not System.IO.Directory.Exists(Ruta) Then
            '            Directory.CreateDirectory(Ruta)
            '        End If
            '        reporte.ExportDocument(StiExportFormat.Pdf, Ruta + "\PlantillaEtiquetasCoppelNiño Pedido_" + IIf(txtPedidoSAY.Text <> String.Empty, txtPedidoSAY.Text, txtPedidoSICY.Text) + ".pdf")
            '    ElseIf rbApartado.Checked Then
            '        Ruta = Ruta + "\Pedidos Y Apartados"
            '        If Not System.IO.Directory.Exists(Ruta) Then
            '            Directory.CreateDirectory(Ruta)
            '        End If
            '        reporte.ExportDocument(StiExportFormat.Pdf, Ruta + "\PlantillaEtiquetasCoppelNiño Apartado_" + sb.ToString() + ".pdf")
            '    End If
            'End If


            'show_message("Exito", "Imprima las plantillas de etiquetas desde Documentos, EtiquetasCoppelPlantillaPDF")

#End Region

            'reporte.Show()
            LimpiarMemoria()

        Catch ex As Exception
            show_message("Error", ex.Message.ToString)
        End Try

    End Sub


#Region "Liberar Memoria"
    'Declaración de la API
    Private Declare Auto Function SetProcessWorkingSetSize Lib “kernel32.dll” (ByVal procHandle As IntPtr, ByVal min As Int32, ByVal max As Int32) As Boolean
    'Funcion de liberacion de memoria
    Public Sub LimpiarMemoria()
        Try
            Dim Mem As Process
            Mem = Process.GetCurrentProcess()
            SetProcessWorkingSetSize(Mem.Handle, -1, -1)

        Catch ex As Exception
            'Control de errores
        End Try
    End Sub
#End Region

    Private Sub mensajeBatta()
        show_message("Advertencia", "No se encontró resultados.")
        Cursor = Cursors.Default
    End Sub

    Public Sub ReporteEtiquetasBattaPantilla(ByVal tabla1 As DataTable)
        Dim ds As New DataSet
        Dim singleFile As New StiReport

        Dim Ruta As String = ""
        'Ruta = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\EtiquetasCoppelPlantillaPDF"
        Try
            LimpiarMemoria()

            Dim OBJReporte As New Framework.Negocios.ReportesBU
            Dim EntidadReporte As Entidades.Reportes

            'Validacion
            If rbtPPCP.Checked Then
                EntidadReporte = OBJReporte.LeerReporteporClave("REPORTE_ETIQUETAS_BATTA_PLANTILLA")
            End If
            If rbtMKT.Checked Then
                EntidadReporte = OBJReporte.LeerReporteporClave("REPORTE_ETIQUETAS_BATTA_PLANTILLA_MARKETING")
            End If


            Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
                        EntidadReporte.Pnombre + ".mrt"
            My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)
            Dim reporte As New StiReport

            ds.Tables.Add(tabla1)

            reporte.Load(archivo)
            reporte.Compile()
            reporte.RegData(ds)
            reporte.Dictionary.Synchronize()
            'reporte.Render()
            reporte.Print()


#Region "Codigo para exportar a PDF"



#End Region

            'reporte.Show()
            LimpiarMemoria()

        Catch ex As Exception
            show_message("Error", ex.Message.ToString)
        End Try

    End Sub


End Class
