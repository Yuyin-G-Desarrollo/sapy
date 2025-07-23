Imports Tools
Imports System.IO
Imports System.Text
Imports DevExpress.XtraGrid.Columns
Imports System.Text.RegularExpressions
Public Class ImpresionEtiquetasApartadosForm
    'Dim mAdvertencia As Tools.AdvertenciaForm
    'Dim mInfo As Tools.AvisoForm
    'Dim mError As Tools.ErroresForm

    Private _Cliente As String = String.Empty
    Public Property Cliente() As String
        Get
            Return _Cliente
        End Get
        Set(ByVal value As String)
            _Cliente = value
        End Set
    End Property

    Private _idCliente As Integer = 0
    Public Property idCliente() As Integer
        Get
            Return _idCliente
        End Get
        Set(ByVal value As Integer)
            _idCliente = value
        End Set
    End Property

    Private _CadenaApartados As String = String.Empty
    Public Property CadenaApartados() As String
        Get
            Return _CadenaApartados
        End Get
        Set(ByVal value As String)
            _CadenaApartados = value
        End Set
    End Property

    Private _CadenaApartadosBatta As String = String.Empty
    Public Property CadenaApartadosBatta() As String
        Get
            Return _CadenaApartadosBatta
        End Get
        Set(ByVal value As String)
            _CadenaApartadosBatta = value
        End Set
    End Property

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub ImpresionEtiquetasApartadosForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim objBU As New Programacion.Negocios.EtiquetasBU
        cmbCliente.Text = _Cliente
        Dim dtCllienteTipoEtiqueta As DataTable
        If _idCliente > 0 Then
            dtCllienteTipoEtiqueta = objBU.ConsultarClientesTipoEtiqueta(1, _idCliente)
            cmbTipoEtiqueta.DataSource = dtCllienteTipoEtiqueta
            cmbTipoEtiqueta.ValueMember = "etiq_tipoetiquetaid"
            cmbTipoEtiqueta.DisplayMember = "TipoEtiqueta"
        End If
        CargarImpresoras(cmbImpresora)
    End Sub

    Private Sub CargarImpresoras(ByVal cmb As ComboBox)
        Dim DTImpresoras As DataTable
        Dim objBU As New Programacion.Negocios.EtiquetasBU
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

    Private Sub btnClientesPruebaImprimir_Click(sender As Object, e As EventArgs) Handles btnClientesPruebaImprimir.Click
        Dim dtZpl As New DataTable
        Dim objBU As New Programacion.Negocios.EtiquetasBU
        Dim objVista As New Programacion.Vista.ImpresionEtiquetasForm


        Try
            Cursor = Cursors.WaitCursor
            objVista.Accion = 1
            If cmbCliente.Text = "" Then
                objVista.mensajeAdvertencia("Debe existir al menos un cliente seleccionado.")
                Exit Sub
            End If

            If cmbImpresora.Text = "" Then
                objVista.mensajeAdvertencia("Debe existir al menos una impresora seleccionada.")
                Exit Sub
            End If

            If cmbTipoEtiqueta.Text = "" Then
                objVista.mensajeAdvertencia("Debe existir al menos un tipo de etiqueta seleccionada.")
                Exit Sub
            End If

            If idCliente = 103 Then
                If EsImpresoraNiceLabel(cmbImpresora.SelectedValue) = False Then
                    objVista.mensajeAdvertencia("Debe seleccionar una impresora de NiceLabel.")
                    Exit Sub
                End If
                CopiarImagenesBatta(False, "0", "0", 0, Date.Now, False, 0, 0, True, CadenaApartadosBatta)
                dtZpl = objBU.ImprimeEtiquetasBattaOpcionesCliente(cmbImpresora.SelectedValue, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, 103, cmbTipoEtiqueta.SelectedValue, chkMostrarDetalles.Checked, False, 0, Date.Now, 0, 0, False, 0, 0, True, CadenaApartadosBatta)
                'dtZpl = objBU.ImprimeEtiquetasBattaOpcionesCliente_ConsultaDetalles(cmbImpresora.SelectedValue, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, 103, cmbTipoEtiqueta.SelectedValue, chkMostrarDetalles.Checked, False, 0, Date.Now, 0, 0, False, 0, 0, True, CadenaApartadosBatta)

            Else

                dtZpl = objBU.ImprimirClientesProduccion(cmbImpresora.SelectedValue, _
                                                     Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, _
                                                     _idCliente, _
                                                     cmbTipoEtiqueta.SelectedValue, _
                                                     chkMostrarDetalles.Checked, _
                                                     False, _
                                                     0, _
                                                     Date.Now, _
                                                     0, _
                                                     0, _
                                                     True, _
                                                     0, _
                                                     0, _
                                                     True, _
                                                     _CadenaApartados)

            End If

            If chkMostrarDetalles.Checked Then
                If Not IsNothing(dtZpl) Then
                    If dtZpl.Rows.Count > 0 Then
                        Dim objDetalles As New Programacion.Vista.ImpresionEtiquetasDetallesForm
                        objDetalles.Data = dtZpl
                        objDetalles.Impresora = cmbImpresora.SelectedValue
                        objDetalles.USuarioID = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
                        objDetalles.TipoEtiqueta = cmbTipoEtiqueta.SelectedValue
                        objDetalles.ClienteID = cmbCliente.SelectedValue
                        objDetalles.Cliente = cmbCliente.Text
                        objDetalles.Usuario = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
                        objDetalles.Accion = 1
                        objDetalles.ShowDialog()
                    Else
                        objVista.mensajeAdvertencia("La tabla de etiquetas no contiene datos.")
                    End If
                Else
                    objVista.mensajeAdvertencia("La consulta de etiquetas realizada no arrojo resultados.")
                End If
            Else
                If idCliente <> 103 Then 'BATTA
                    If Not IsNothing(dtZpl) Then
                        If dtZpl.Rows.Count > 0 Then
                            objVista.GenerarArchivoEtiquetasTxt(dtZpl)
                            Dim grfs As List(Of String) = dtZpl.AsEnumerable() _
                                                       .Select(Function(r) r.Field(Of String)("foto")) _
                                                       .Distinct() _
                                                       .ToList()
                            objVista.GenerarArchivoEtiquetasBat(grfs)
                            objVista.ejecutarBat()
                            objVista.msgExito.mensaje = "Se ejecutó la impresión correctamente."
                            objVista.msgExito.ShowDialog()
                        Else
                            objVista.mensajeAdvertencia("La tabla de etiquetas no contiene datos.")
                        End If
                    Else
                        objVista.mensajeAdvertencia("La consulta de etiquetas realizada no arrojo resultados.")
                    End If
                End If

            End If


        Catch ex As Exception
            objVista.msgError.mensaje = ex.Message + vbCrLf + ex.Source + vbCrLf + ex.StackTrace
            objVista.msgError.ShowDialog()
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Function EsImpresoraNiceLabel(ByVal ImpresoraSeleccionada As Integer) As Boolean
        Dim Resultado As Boolean = False
        Dim DTImpresoras As DataTable
        Dim Software As String = String.Empty
        Dim objBUEtiquetas As New Programacion.Negocios.EtiquetasBU

        Try
            DTImpresoras = objBUEtiquetas.ListaImpresoras()
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

    Private Function CopiarImagenesBatta(ByVal PorLotes As Boolean, ByVal LoteInicio As Integer, ByVal LoteFin As Integer, ByVal NaveSICYID As Integer, ByVal FechaPrograma As Date, ByVal PorPedido As Boolean, ByVal PedidoSAY As Integer, ByVal PedidoSICY As Integer, ByVal PorApartado As Boolean, ByVal CadenaApartados As String) As Boolean
        Dim dtImagenes As New DataTable
        Dim CarpetaDestino As String = String.Empty
        Dim RutaImagenCompletaTemporal As String = String.Empty
        Dim NombreImagenTemporal As String = String.Empty
        Dim RutaCompletaSICY As String = String.Empty
        Dim RutaFTP As String = String.Empty
        Dim RutaCompletaLocal As String = String.Empty
        Dim Resultado As Boolean = False
        Dim ObjBUEtiquetas As New Programacion.Negocios.EtiquetasBU

        Try
            dtImagenes = ObjBUEtiquetas.ConsultaImagenesBattaOpcionesCliente(PorLotes, LoteInicio, LoteFin, NaveSICYID, FechaPrograma, PorPedido, PedidoSAY, PedidoSICY, PorApartado, CadenaApartados, cmbCliente.SelectedValue)

            For Each Fila As DataRow In dtImagenes.Rows
                CarpetaDestino = Fila.Item("Carpeta")
                RutaImagenCompletaTemporal = Fila.Item("RutaNoExite")
                RutaFTP = Fila.Item("RutaFTP")

                NombreImagenTemporal = Path.GetFileName(RutaImagenCompletaTemporal)
                RutaCompletaSICY = CarpetaDestino + NombreImagenTemporal
                If File.Exists(RutaCompletaSICY) = False Then
                    RutaCompletaLocal = ObjBUEtiquetas.DescargarImagenBatta(RutaFTP)
                    File.Copy(RutaCompletaLocal, RutaCompletaSICY)
                End If
            Next

            Resultado = True
        Catch ex As Exception
            Resultado = False
            'show_message("Advertencia", ex.Message.ToString())
        End Try

        Return Resultado

    End Function

End Class