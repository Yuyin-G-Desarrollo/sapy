Imports System.IO

Public Class ConfigurarEtiquetaLenguaEspecialForm

    Public EsEtiquetaLengua As Boolean = False

    Private objBU As New Negocios.EtiquetasBU
    Private _EntidadEtiqueta As Entidades.ConfiguracionEtiqueta
    Private dtTipoEtiqueta As New DataTable

    Public Property EntidadEtiqueta() As Entidades.ConfiguracionEtiqueta
        Get
            Return _EntidadEtiqueta
        End Get
        Set(ByVal value As Entidades.ConfiguracionEtiqueta)
            _EntidadEtiqueta = value
        End Set
    End Property
    Private Sub ConfigurarEtiquetaLenguaEspecialForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        CargarComboClientes()
        CargarComboColeccion()

        dtTipoEtiqueta.Columns.Add("TipoEtiquetaID")
        dtTipoEtiqueta.Columns.Add("TipoEtiqueta")

        Dim row As DataRow = dtTipoEtiqueta.NewRow
        row.Item("TipoEtiquetaID") = "29"
        row.Item("TipoEtiqueta") = "ESPECIAL (LENGUA CLIENTE-COLECCIÓN)"

        dtTipoEtiqueta.Rows.Add(row)

        cmbTipoEtiqueta.DataSource = dtTipoEtiqueta
        cmbTipoEtiqueta.ValueMember = "TipoEtiquetaID"
        cmbTipoEtiqueta.DisplayMember = "TipoEtiqueta"

        cmbImpresionAlPaso.Items.Add("")
        cmbImpresionAlPaso.Items.Add("1")
        cmbImpresionAlPaso.Items.Add("2")
        cmbImpresionAlPaso.Items.Add("3")

        If _EntidadEtiqueta.EtiquetaId > 0 Then
            _EntidadEtiqueta = objBU.ConsultarInformacionEtiquetaPorAutorizar(_EntidadEtiqueta.EtiquetaId)

            cmbClientes.SelectedText = _EntidadEtiqueta.NombreCliente
            cmbColeccion.SelectedText = _EntidadEtiqueta.Coleccion
            cmbTipoEtiqueta.SelectedIndex = 0
            cmbImpresionAlPaso.Text = _EntidadEtiqueta.EtiquetaImpresionesAlPaso

            txtAlto.Text = _EntidadEtiqueta.EtiquetaAlto
            txtAncho.Text = _EntidadEtiqueta.EtiquetaAncho

            If _EntidadEtiqueta.EtiquetaActiva Then
                rdoSi.Checked = True
            Else
                rdoNo.Checked = True
            End If

        End If

    End Sub

    Private Sub CargarComboClientes()
        Dim dtClientes As DataTable
        Try
            dtClientes = objBU.ObtenerClienesEtiquetasEspecialLengua()
            dtClientes.Rows.InsertAt(dtClientes.NewRow, 0)
            cmbClientes.DataSource = dtClientes
            cmbClientes.ValueMember = "ClienteID"
            cmbClientes.DisplayMember = "Cliente"
        Catch ex As Exception
            show_message("Error", ex.Message)
        End Try
    End Sub

    Private Sub CargarComboColeccion()
        Dim dtColecciones As DataTable
        Try
            dtColecciones = objBU.ObtenerColecciones
            dtColecciones.Rows.InsertAt(dtColecciones.NewRow, 0)

            cmbColeccion.DataSource = dtColecciones
            cmbColeccion.ValueMember = "ColeccionID"
            cmbColeccion.DisplayMember = "Coleccion"
        Catch ex As Exception
            show_message("Error", ex.Message)
        End Try
    End Sub
    Private Sub btnExaminar200_Click(sender As Object, e As EventArgs) Handles btnExaminar200.Click
        ofdRutaArchivo.Reset()
        ofdRutaArchivo.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
        ofdRutaArchivo.Filter = "PRN|*.prn;"
        ofdRutaArchivo.FilterIndex = 3
        ofdRutaArchivo.ShowDialog()
        txt200dpi.Text = ofdRutaArchivo.FileName
    End Sub
    Private Sub btnExaminar300_Click(sender As Object, e As EventArgs) Handles btnExaminar300.Click
        ofdRutaArchivo.Reset()
        ofdRutaArchivo.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
        ofdRutaArchivo.Filter = "PRN|*.prn;"
        ofdRutaArchivo.FilterIndex = 3
        ofdRutaArchivo.ShowDialog()
        txt300dpi.Text = ofdRutaArchivo.FileName
    End Sub

    Private Sub btnExaminarlbl_Click(sender As Object, e As EventArgs) Handles btnExaminarlbl.Click
        ofdRutaArchivo.Reset()
        ofdRutaArchivo.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
        ofdRutaArchivo.Filter = "LBL|*.lbl;"
        ofdRutaArchivo.FilterIndex = 3
        ofdRutaArchivo.ShowDialog()
        txtArchivolbl.Text = ofdRutaArchivo.FileName
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim negobj As New Programacion.Negocios.EtiquetasBU
        Dim objEtiqueta As New Entidades.ConfiguracionEtiqueta
        Try
            If ValidarCampos() = False And ValidaClienteColeccion(cmbClientes.SelectedValue, cmbColeccion.SelectedValue) = False Then
                Return
            End If
            If validaSoloNumeros() = False Then
                show_message("Advertencia", "El ancho y alto de la etiqueta debe ser mayor a 0 y menor que 38 cm.")
                Return
            End If


            If txt200dpi.Text = String.Empty And _EntidadEtiqueta.CodigoZPL = String.Empty Then
                show_message("Advertencia", "Se dede de cargar el diseño de 203.")
                lblTextoImpresion203.ForeColor = Color.Red
                Return
            Else
                lblTextoImpresion203.ForeColor = Color.Black
            End If

            If txt300dpi.Text = String.Empty And _EntidadEtiqueta.EtiquetaCodigoZPL300 = String.Empty Then
                show_message("Advertencia", "Se dede cargar el diseño de 300.")
                lblTextoImpresion300.ForeColor = Color.Red
                Return
            Else
                lblTextoImpresion300.ForeColor = Color.Black
            End If

            If txtArchivolbl.Text = String.Empty And _EntidadEtiqueta.RutaLBL = String.Empty Then
                show_message("Advertencia", "Se dede cargar archivo lbl")
                lblArchivolbl.ForeColor = Color.Red
                Return
            Else
                lblArchivolbl.ForeColor = Color.Black
            End If

            objEtiqueta.EtiquetaId = _EntidadEtiqueta.EtiquetaId

            objEtiqueta.EtiquetaVistaPrevia = _EntidadEtiqueta.EtiquetaVistaPrevia
            objEtiqueta.CodigoZPL = _EntidadEtiqueta.CodigoZPL
            objEtiqueta.EtiquetaCodigoZPL300 = _EntidadEtiqueta.EtiquetaCodigoZPL300

            objEtiqueta.TipoEtiqueta = cmbTipoEtiqueta.Text
            objEtiqueta.ClienteId = cmbClientes.SelectedValue
            objEtiqueta.NombreCliente = cmbClientes.Text
            objEtiqueta.EtiquetaClave = cmbTipoEtiqueta.Text
            objEtiqueta.TipoEtiquetaId = cmbTipoEtiqueta.SelectedValue
            objEtiqueta.EtiquetaNombre = cmbTipoEtiqueta.Text

            objEtiqueta.EtiquetaDescripcion = "ETIQUETA DE " & objEtiqueta.TipoEtiqueta & " PARA EL CLIENTE " & objEtiqueta.NombreCliente

            objEtiqueta.EtiquetaAncho = txtAncho.Text
            objEtiqueta.EtiquetaAlto = txtAlto.Text
            objEtiqueta.EtiquetaOrientacion = "1"
            objEtiqueta.EtiquetaUsuarioCreoId = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
            objEtiqueta.UsuarioModificoId = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
            objEtiqueta.EtiquetaYuyin = False
            objEtiqueta.EtiquetaImpresionesAlPaso = cmbImpresionAlPaso.Text

            objEtiqueta.ColeccionID = cmbColeccion.SelectedValue

            If Not Guardar_Archivo_LBL(txtArchivolbl.Text, objEtiqueta.ClienteId, objEtiqueta.TipoEtiqueta, objEtiqueta) Then
                Return
            End If

            leer_Archivo_prn(objEtiqueta)

            If rdoSi.Checked Then
                objEtiqueta.EtiquetaActiva = 1
            Else
                objEtiqueta.EtiquetaActiva = 0
            End If

            If objEtiqueta.EtiquetaId = 0 Then
                objEtiqueta.EtiquetaId = negobj.AltaEtiquetaPorAutorizar(objEtiqueta, 1)
            ElseIf objEtiqueta.EtiquetaId > 0 Then
                negobj.AltaEtiquetaPorAutorizar(objEtiqueta, 2)
            End If


            If txt200dpi.Text <> String.Empty Then
                LeerParametrosEtiqueta(objEtiqueta.CodigoZPL, objEtiqueta.EtiquetaId, 203)
            End If

            If txt300dpi.Text <> String.Empty Then
                LeerParametrosEtiqueta(objEtiqueta.EtiquetaCodigoZPL300, objEtiqueta.EtiquetaId, 300)
            End If
            show_message("Exito", "La configuración de la etiqueta se ha guardado correctamente.")
        Catch ex As Exception
            show_message("Error", ex.Message)
        End Try



    End Sub

    Private Function ValidarCampos()
        Dim valida As Boolean = True


        If txtAlto.Text = "" Then
            lblAlto.ForeColor = Color.Red
            valida = False
        Else
            lblAlto.ForeColor = Color.Black
        End If

        If txtAncho.Text = "" Then
            lblAncho.ForeColor = Color.Red
            valida = False
        Else
            lblAncho.ForeColor = Color.Black
        End If

        Return valida

    End Function

    Private Function validaSoloNumeros() As Boolean

        Dim valida As Boolean = True

        Dim ancho As Integer = txtAncho.Text
        Dim alto As Integer = txtAlto.Text

        If ancho <= 0 Or ancho > 38 Then
            lblAncho.ForeColor = Color.Red
            valida = False
        Else
            lblAncho.ForeColor = Color.Black
        End If

        If alto <= 0 Or alto > 38 Then
            lblAlto.ForeColor = Color.Red
            valida = False
        Else
            lblAlto.ForeColor = Color.Black
        End If

        Return valida

    End Function

    Private Function Guardar_Archivo_LBL(ByVal ArchivoLBl As String, ByVal ClienteID As Integer, ByVal TipoEtiqueta As String, objEtiquetas As Entidades.ConfiguracionEtiqueta) As Boolean
        Dim objNeg As New Negocios.EtiquetasBU
        Dim ruta_lbl As String
        Dim msg_error As New Tools.ErroresForm
        Dim nueva_ruta As String
        Dim FechaAct As String

        Try

            If ArchivoLBl = String.Empty And _EntidadEtiqueta.RutaLBL <> String.Empty Then
                ArchivoLBl = _EntidadEtiqueta.RutaLBL
            End If
            ruta_lbl = objNeg.ConsultarRutaLBLOpciones

            FechaAct = Date.Now.ToString.Replace(":", "").Replace(".", "").Replace(" ", "_").Replace("/", "")

            If Not System.IO.Directory.Exists(ruta_lbl + ClienteID.ToString) Then
                Directory.CreateDirectory(ruta_lbl + ClienteID.ToString)
            End If

            nueva_ruta = ruta_lbl + ClienteID.ToString + "\" + ClienteID.ToString + "_" + TipoEtiqueta + "_" + FechaAct.ToString + ".lbl"

            System.IO.File.Copy(ArchivoLBl, nueva_ruta)
            objEtiquetas.RutaLBL = nueva_ruta

            Return True
        Catch ex As Exception
            show_message("Error", ex.Message)
            Return False
        End Try

    End Function

    Private Sub leer_Archivo_prn(ByVal objEtiqueta As Entidades.ConfiguracionEtiqueta)

        Dim ruta_200dpi As String = txt200dpi.Text
        Dim ruta_300dpi As String = txt300dpi.Text
        Dim ruta_vista_previa As String = ""

        If File.Exists(ruta_vista_previa) Then
            objEtiqueta.EtiquetaVistaPrevia = File.ReadAllText(ruta_vista_previa)
        End If

        If File.Exists(ruta_200dpi) Then
            objEtiqueta.CodigoZPL = File.ReadAllText(ruta_200dpi)
            objEtiqueta.CodigoZPL = AgregarMedios(objEtiqueta.CodigoZPL)
            objEtiqueta.CodigoZPL = ReemplazarCodigoBarras(objEtiqueta.CodigoZPL)
            objEtiqueta.CodigoZPL = ReemplazarCodigo128A(objEtiqueta.CodigoZPL)
            objEtiqueta.CodigoZPL = ReemplazarCodigo39(objEtiqueta.CodigoZPL)
            objEtiqueta.CodigoZPL = ReemplazarCodigoEAN13(objEtiqueta.CodigoZPL)
            objEtiqueta.CodigoZPL = ReemplazarCodigo128C(objEtiqueta.CodigoZPL)
            objEtiqueta.CodigoZPL = ReemplazarCodigoEntrelazado2de5(objEtiqueta.CodigoZPL)
        End If

        If File.Exists(ruta_300dpi) Then
            objEtiqueta.EtiquetaCodigoZPL300 = File.ReadAllText(ruta_300dpi)
            objEtiqueta.EtiquetaCodigoZPL300 = AgregarMedios(objEtiqueta.EtiquetaCodigoZPL300)
            objEtiqueta.EtiquetaCodigoZPL300 = ReemplazarCodigoBarras(objEtiqueta.EtiquetaCodigoZPL300)
            objEtiqueta.EtiquetaCodigoZPL300 = ReemplazarCodigo128A(objEtiqueta.EtiquetaCodigoZPL300)
            objEtiqueta.EtiquetaCodigoZPL300 = ReemplazarCodigo39(objEtiqueta.EtiquetaCodigoZPL300)
            objEtiqueta.EtiquetaCodigoZPL300 = ReemplazarCodigoEAN13(objEtiqueta.EtiquetaCodigoZPL300)
            objEtiqueta.EtiquetaCodigoZPL300 = ReemplazarCodigo128C(objEtiqueta.EtiquetaCodigoZPL300)
            objEtiqueta.EtiquetaCodigoZPL300 = ReemplazarCodigoEntrelazado2de5(objEtiqueta.EtiquetaCodigoZPL300)
        End If

    End Sub

    Private Function ValidaClienteColeccion(ClienteID As Integer, ColeccionID As Integer) As Boolean
        Try
            If objBU.ValidarClienteColeccion(ClienteID, ColeccionID) > 0 Then
                show_message("Advertecnia", "No puede agregar una nueva etiqueta para este cliente-colección, modifique el diseño existente")
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            show_message("Error", ex.Message)
            Return False
        End Try
    End Function

    Private Sub LeerParametrosEtiqueta(ByVal ZPL As String, ByVal EtiquetaId As Integer, ByVal Resolucion As Integer)
        Dim ObjBu As New Programacion.Negocios.EtiquetasBU
        Dim dtParametros As DataTable

        dtParametros = ObjBu.ConsultarParametrosRelacionados()
        ObjBu.EliminarParametrosEtiquetaPorAutorizar(EtiquetaId, Resolucion)

        For Each Fila As DataRow In dtParametros.Rows
            If ZPL.Contains(Fila.Item("Valor Etiqueta").ToString()) = True Then
                ObjBu.InsertarParametroEtiquetaPorAutorizar(EtiquetaId, Fila.Item("ParametroID").ToString(), Resolucion)
            End If
        Next

    End Sub


    Private Function ReemplazarCodigoBarras(ByVal Codigozpl As String) As String
        Dim cadenareemplazar As String = String.Empty
        cadenareemplazar = "'Q)P)A)R)A)M4'Q"

        Try
            If Codigozpl.Contains(")P)A)R)A)M") = True Then

                For index As Integer = 1 To 100
                    cadenareemplazar = "'Q)P)A)R)A)M" & index.ToString() & "'Q"

                    If Codigozpl.Contains(cadenareemplazar) = True Then
                        Codigozpl = Codigozpl.Replace(cadenareemplazar, "|param" & index.ToString & "|")
                    End If
                Next
            End If

        Catch ex As Exception
            show_message("Error", ex.Message.ToString)
        End Try
        Return Codigozpl
    End Function

    Private Function AgregarMedios(ByVal Codigozpl As String) As String
        Dim cadenareemplazar As String = String.Empty
        cadenareemplazar = "^FH\^FD|param35"

        Try
            If Codigozpl.Contains("param35") = True Then
                Codigozpl = Codigozpl.Replace(cadenareemplazar, "^CI0^FH\^FD|param35")
            End If

        Catch ex As Exception
            show_message("Error", ex.Message.ToString)
        End Try
        Return Codigozpl
    End Function

    Private Function ReemplazarCodigo128A(ByVal Codigozpl As String) As String
        Dim cadenareemplazar As String = String.Empty
        cadenareemplazar = "9483350334520"

        Try
            If Codigozpl.Contains("9483350334520") = True Then
                Codigozpl = Codigozpl.Replace(cadenareemplazar, "|param4|")
            End If

        Catch ex As Exception
            show_message("Error", ex.Message.ToString)
        End Try
        Return Codigozpl
    End Function

    Private Function ReemplazarCodigo39(ByVal Codigozpl As String) As String
        Dim cadenareemplazar As String = String.Empty
        cadenareemplazar = "PARAM4"

        Try
            If Codigozpl.Contains("PARAM4") = True Then
                Codigozpl = Codigozpl.Replace(cadenareemplazar, "|param4|")
            End If

        Catch ex As Exception
            show_message("Error", ex.Message.ToString)
        End Try
        Return Codigozpl
    End Function

    Private Function ReemplazarCodigoEAN13(ByVal Codigozpl As String) As String
        Dim cadenareemplazar As String = String.Empty
        cadenareemplazar = "0123456789012"

        Try
            If Codigozpl.Contains("0123456789012") = True Then
                Codigozpl = Codigozpl.Replace(cadenareemplazar, "|param4|")
            End If

        Catch ex As Exception
            show_message("Error", ex.Message.ToString)
        End Try
        Return Codigozpl
    End Function

    Private Function ReemplazarCodigo128C(ByVal Codigozpl As String) As String
        Dim cadenareemplazar As String = String.Empty
        cadenareemplazar = "0000000000"

        Try
            If Codigozpl.Contains("0000000000") = True Then
                Codigozpl = Codigozpl.Replace("0000000000", "|param52|")
            End If

            If Codigozpl.Contains("0000000001") = True Then
                Codigozpl = Codigozpl.Replace("0000000001", "|param52_1|")
            End If

            If Codigozpl.Contains("0000000002") = True Then
                Codigozpl = Codigozpl.Replace("0000000002", "|param52_2|")
            End If

        Catch ex As Exception
            show_message("Error", ex.Message.ToString)
        End Try
        Return Codigozpl
    End Function
    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Public Sub show_message(ByVal tipo As String, ByVal mensaje As String)

        If tipo.ToString.Equals("Advertencia") Then

            Dim mensajeAdvertencia As New Tools.AdvertenciaForm
            mensajeAdvertencia.mensaje = mensaje
            mensajeAdvertencia.ShowDialog()

        End If

        If tipo.ToString.Equals("Aviso") Then

            Dim mensajeAviso As New Tools.AvisoForm
            mensajeAviso.mensaje = mensaje
            mensajeAviso.ShowDialog()

        End If

        If tipo.ToString.Equals("Error") Then

            Dim mensajeError As New Tools.ErroresForm
            mensajeError.mensaje = mensaje
            mensajeError.ShowDialog()

        End If

        If tipo.ToString.Equals("Exito") Then

            Dim mensajeExito As New Tools.ExitoForm
            mensajeExito.mensaje = mensaje
            mensajeExito.ShowDialog()

        End If

        If tipo.ToString.Equals("Confirmar") Then

            Dim mensajeExito As New Tools.ConfirmarForm
            mensajeExito.mensaje = mensaje
            mensajeExito.ShowDialog()

        End If

    End Sub

    Private Function ReemplazarCodigoEntrelazado2de5(ByVal Codigozpl As String) As String
        Dim cadenareemplazar As String = String.Empty
        cadenareemplazar = "99999999"

        Try
            If Codigozpl.Contains(cadenareemplazar) = True Then
                Codigozpl = Codigozpl.Replace(cadenareemplazar, "|param100| |param182|30")
            End If

        Catch ex As Exception
            show_message("Error", ex.Message.ToString)
        End Try
        Return Codigozpl
    End Function

End Class