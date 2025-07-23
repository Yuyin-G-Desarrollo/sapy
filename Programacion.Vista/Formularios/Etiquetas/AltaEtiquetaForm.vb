
Imports System
Imports System.IO
Imports System.Text
Imports Tools

Public Class AltaEtiquetaForm

    Public EsEtiquetaLengua As Boolean = False

    Private _EntidadEtiqueta As Entidades.ConfiguracionEtiqueta
    Public Property EntidadEtiqueta() As Entidades.ConfiguracionEtiqueta
        Get
            Return _EntidadEtiqueta
        End Get
        Set(ByVal value As Entidades.ConfiguracionEtiqueta)
            _EntidadEtiqueta = value
        End Set
    End Property


    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub


    Private Sub AltaEtiquetaForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try
            If EsEtiquetaLengua = True Then
                lblCliente.Text = "Colección"                
            Else
                lblCliente.Text = "Cliente"
            End If

            cmbTipoEtiqueta.Items.Add(_EntidadEtiqueta.TipoEtiqueta)
            cmbTipoEtiqueta.SelectedIndex = 0

            'txtCliente.Text = _EntidadEtiqueta.NombreCliente
            If EsEtiquetaLengua = True Then
                txtCliente.Text = _EntidadEtiqueta.Coleccion
            Else
                txtCliente.Text = _EntidadEtiqueta.NombreCliente
                'txtCliente.Text = objConfiguracionEtiquetas.NombreCliente
            End If

            If _EntidadEtiqueta.EtiquetaId = 0 Then

                cmbImpresionAlPaso.SelectedIndex = 0
                rdoSi.Checked = True

            ElseIf _EntidadEtiqueta.EtiquetaId >= 1 Then

                Dim negEtiquetas As New Programacion.Negocios.EtiquetasBU
                Dim objConfiguracionEtiquetas As Entidades.ConfiguracionEtiqueta

                cmbImpresionAlPaso.SelectedIndex = 0
                rdoSi.Checked = True

                If _EntidadEtiqueta.EtiquetaId > 0 Then
                    objConfiguracionEtiquetas = negEtiquetas.ConsultarInformacionEtiquetaPorAutorizar(_EntidadEtiqueta.EtiquetaId)
                    txtAncho.Text = objConfiguracionEtiquetas.EtiquetaAncho
                    txtAlto.Text = objConfiguracionEtiquetas.EtiquetaAlto                    
                    cmbImpresionAlPaso.Text = objConfiguracionEtiquetas.EtiquetaImpresionesAlPaso
                    _EntidadEtiqueta.EtiquetaVistaPrevia = objConfiguracionEtiquetas.EtiquetaVistaPrevia
                    _EntidadEtiqueta.CodigoZPL = objConfiguracionEtiquetas.CodigoZPL
                    _EntidadEtiqueta.EtiquetaCodigoZPL300 = objConfiguracionEtiquetas.EtiquetaCodigoZPL300
                    If objConfiguracionEtiquetas.EtiquetaActiva = True Then
                        rdoSi.Checked = True
                    Else
                        rdoNo.Checked = True
                    End If
                End If
            End If

        Catch ex As Exception
            show_message("Error", "Ocurrio un error al cargar la información.")
        End Try

    End Sub

    Private Sub btnExaminarlbl_Click(sender As Object, e As EventArgs) Handles btnExaminarlbl.Click
        ofdRutaArchivo.Reset()
        ofdRutaArchivo.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
        ofdRutaArchivo.Filter = "LBL|*.lbl;"
        ofdRutaArchivo.FilterIndex = 3
        ofdRutaArchivo.ShowDialog()
        txtArchivolbl.Text = ofdRutaArchivo.FileName
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



    Private Sub leer_Archivo_prn(ByVal objEtiqueta As Entidades.ConfiguracionEtiqueta)

        Dim ruta_200dpi As String = txt200dpi.Text
        Dim ruta_300dpi As String = txt300dpi.Text
        Dim ruta_vista_previa As String = txtVistaPrevia.Text

        If File.Exists(ruta_vista_previa) Then
            objEtiqueta.EtiquetaVistaPrevia = File.ReadAllText(ruta_vista_previa)
        End If

        If File.Exists(ruta_200dpi) Then
            objEtiqueta.CodigoZPL = File.ReadAllText(ruta_200dpi)
            objEtiqueta.CodigoZPL = ReemplazarCodigoBarras(objEtiqueta.CodigoZPL)
            objEtiqueta.CodigoZPL = ReemplazarCodigo128A(objEtiqueta.CodigoZPL)
            objEtiqueta.CodigoZPL = ReemplazarCodigo39(objEtiqueta.CodigoZPL)
            objEtiqueta.CodigoZPL = ReemplazarCodigoEAN13(objEtiqueta.CodigoZPL)
            objEtiqueta.CodigoZPL = ReemplazarCodigo128C(objEtiqueta.CodigoZPL)
            objEtiqueta.CodigoZPL = ReemplazarCodigoEntrelazado2de5(objEtiqueta.CodigoZPL)
        End If

        If File.Exists(ruta_300dpi) Then
            objEtiqueta.EtiquetaCodigoZPL300 = File.ReadAllText(ruta_300dpi)            
            objEtiqueta.EtiquetaCodigoZPL300 = ReemplazarCodigoBarras(objEtiqueta.EtiquetaCodigoZPL300)
            objEtiqueta.EtiquetaCodigoZPL300 = ReemplazarCodigo128A(objEtiqueta.EtiquetaCodigoZPL300)
            objEtiqueta.EtiquetaCodigoZPL300 = ReemplazarCodigo39(objEtiqueta.EtiquetaCodigoZPL300)
            objEtiqueta.EtiquetaCodigoZPL300 = ReemplazarCodigoEAN13(objEtiqueta.EtiquetaCodigoZPL300)
            objEtiqueta.EtiquetaCodigoZPL300 = ReemplazarCodigo128C(objEtiqueta.EtiquetaCodigoZPL300)
            objEtiqueta.EtiquetaCodigoZPL300 = ReemplazarCodigoEntrelazado2de5(objEtiqueta.EtiquetaCodigoZPL300)
        End If

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

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click

        Dim msg_adv As New Tools.AdvertenciaForm
        Dim objEtiqueta As New Entidades.ConfiguracionEtiqueta
        Dim negobj As New Programacion.Negocios.EtiquetasBU
        Dim msg As New Tools.ExitoForm

        Try

            If ValidarCampos() = False Then
                Return
            End If
            If validaSoloNumeros() = False Then
                msg_adv.mensaje = "El ancho y alto de la etiqueta debe ser mayor a 0 y menor que 38 cm."
                msg_adv.Show()
                Return
            End If


            If txt200dpi.Text = String.Empty Then
                msg_adv.mensaje = "Se dede de cargar el diseño de 203."
                msg_adv.Show()
                lblTextoImpresion203.ForeColor = Color.Red
                Return
            Else
                lblTextoImpresion203.ForeColor = Color.Black
            End If

            If txt300dpi.Text = String.Empty Then
                msg_adv.mensaje = "Se dede cargar el diseño de 300."
                msg_adv.Show()
                lblTextoImpresion300.ForeColor = Color.Red
                Return
            Else
                lblTextoImpresion300.ForeColor = Color.Black
            End If

            If txtArchivolbl.Text = String.Empty Then
                msg_adv.mensaje = "Se dede cargar archivo lbl"
                msg_adv.Show()
                lblTextoImpresion300.ForeColor = Color.Red
                Return
            Else
                lblTextoImpresion300.ForeColor = Color.Black
            End If

            If Not Guardar_Archivo_LBL(txtArchivolbl.Text, _EntidadEtiqueta.ClienteId, _EntidadEtiqueta.TipoEtiqueta) Then
                Return
            End If


            objEtiqueta.EtiquetaVistaPrevia = _EntidadEtiqueta.EtiquetaVistaPrevia
            objEtiqueta.CodigoZPL = _EntidadEtiqueta.CodigoZPL
            objEtiqueta.EtiquetaCodigoZPL300 = _EntidadEtiqueta.EtiquetaCodigoZPL300

            objEtiqueta.TipoEtiqueta = cmbTipoEtiqueta.Text
            objEtiqueta.EtiquetaClave = cmbTipoEtiqueta.Text
            objEtiqueta.TipoEtiquetaId = _EntidadEtiqueta.TipoEtiquetaId
            objEtiqueta.EtiquetaNombre = cmbTipoEtiqueta.Text

            If _EntidadEtiqueta.ClienteId = 0 Then
                If _EntidadEtiqueta.TipoEtiquetaId = 6 Then
                    objEtiqueta.EtiquetaDescripcion = "ETIQUETA DE PAR UNIFICADA"
                ElseIf _EntidadEtiqueta.TipoEtiquetaId = 11 Then
                    objEtiqueta.EtiquetaDescripcion = "ETIQUETA ESTANDAR DE ATADO"
                ElseIf _EntidadEtiqueta.TipoEtiquetaId = 19 Then
                    objEtiqueta.EtiquetaDescripcion = "ETIQUETA ESTANDAR DE LOTE"
                ElseIf _EntidadEtiqueta.TipoEtiquetaId = 10 Or _EntidadEtiqueta.TipoEtiquetaId = 13 Then
                    objEtiqueta.EtiquetaDescripcion = "ETIQUETA DE " & cmbTipoEtiqueta.Text & " PARA LA COLECCIÓN " & txtCliente.Text.Trim
                End If
            Else
                objEtiqueta.EtiquetaDescripcion = "ETIQUETA DE " & cmbTipoEtiqueta.Text & " PARA EL CLIENTE " & _EntidadEtiqueta.NombreCliente
            End If

            objEtiqueta.EtiquetaAncho = txtAncho.Text
            objEtiqueta.EtiquetaAlto = txtAlto.Text
            objEtiqueta.EtiquetaOrientacion = "1"
            objEtiqueta.EtiquetaUsuarioCreoId = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
            objEtiqueta.UsuarioModificoId = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
            objEtiqueta.ClienteId = _EntidadEtiqueta.ClienteId
            objEtiqueta.EtiquetaYuyin = _EntidadEtiqueta.EtiquetaYuyin
            objEtiqueta.EtiquetaImpresionesAlPaso = cmbImpresionAlPaso.Text
            objEtiqueta.EtiquetaId = _EntidadEtiqueta.EtiquetaId
            objEtiqueta.RutaLBL = _EntidadEtiqueta.RutaLBL

            objEtiqueta.ColeccionID = _EntidadEtiqueta.ColeccionID

            leer_Archivo_prn(objEtiqueta)

            If rdoSi.Checked Then
                objEtiqueta.EtiquetaActiva = 1
            Else
                objEtiqueta.EtiquetaActiva = 0
            End If

            If _EntidadEtiqueta.EtiquetaId = 0 Then
                objEtiqueta.EtiquetaId = negobj.AltaEtiquetaPorAutorizar(objEtiqueta, 1)
            ElseIf _EntidadEtiqueta.EtiquetaId > 0 Then
                negobj.AltaEtiquetaPorAutorizar(objEtiqueta, 2)
            End If

            If txt200dpi.Text <> String.Empty Then
                LeerParametrosEtiqueta(objEtiqueta.CodigoZPL, objEtiqueta.EtiquetaId, 203)
            End If

            If txt300dpi.Text <> String.Empty Then
                LeerParametrosEtiqueta(objEtiqueta.EtiquetaCodigoZPL300, objEtiqueta.EtiquetaId, 300)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        msg.mensaje = "La configuración de la etiqueta se ha guardado correctamente"
        msg.ShowDialog()
        Me.Close()
    End Sub

    Private Function Guardar_Archivo_LBL(ByVal ArchivoLBl As String, ByVal ClienteID As Integer, ByVal TipoEtiqueta As String) As Boolean
        Dim objNeg As New Negocios.EtiquetasBU
        Dim ruta_lbl As String
        Dim msg_error As New Tools.ErroresForm
        Dim nueva_ruta As String
        Dim FechaAct As String

        Try
            ruta_lbl = objNeg.ConsultarRutaLBLOpciones

            FechaAct = Date.Now.ToString.Replace(":", "").Replace(".", "").Replace(" ", "_").Replace("/", "")

            If Not System.IO.Directory.Exists(ruta_lbl + ClienteID.ToString) Then
                Directory.CreateDirectory(ruta_lbl + ClienteID.ToString)
            End If

            nueva_ruta = ruta_lbl + ClienteID.ToString + "\" + ClienteID.ToString + "_" + TipoEtiqueta + "_" + FechaAct.ToString + ".lbl"

            System.IO.File.Copy(ArchivoLBl, nueva_ruta)
            _EntidadEtiqueta.RutaLBL = nueva_ruta

            Return True
        Catch ex As Exception
            msg_error.mensaje = ex.Message
            msg_error.ShowDialog()
            Return False
        End Try

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

    Private Sub txtAlto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtAlto.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf e.KeyChar = "." And Not txtAlto.Text.IndexOf(".") Then
            e.Handled = True
        ElseIf e.KeyChar = "." Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txtAncho_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtAncho.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf e.KeyChar = "." And Not txtAncho.Text.IndexOf(".") Then
            e.Handled = True
        ElseIf e.KeyChar = "." Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub


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