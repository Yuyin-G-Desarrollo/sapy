Imports Tools
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports System.Drawing.Printing
Imports System.Globalization
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Net
Imports System.Windows.Forms.OpenFileDialog


Public Class AltaContactoProveedorForm

    Public ProveedorId As Integer = -1
    Public NombreProveedor As String = String.Empty
    Public ContactoID As Integer = -1
    Dim Firma As String = String.Empty
    Dim Foto As String = String.Empty
    Dim Directorio As String = String.Empty
  
    'Public Const rutaFTP As String = 'objFTP.Hostname.ToString() '"FTP://192.168.7.16/"
    Public Const RutaImagenesProveedores As String = "Administracion/Proveedores/"
    'Public Const ftpUsuario As String = "prod\yuyinerp"
    'Public Const ftpContrasena As String = "yuyinerp"
    'Public Const rutaTmp As String = "\\192.168.2.2\bin\TmpCartas\"


    Private Sub AltaContactoProveedorForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim OBJContactoProveedor As New Proveedores.BU.ContactoProveedorBU
        Dim objInformacionContacto As Entidades.DatosContacto
        Dim indice As Integer = 0
        'Dim request = DirectCast(WebRequest.Create("ftp://192.168.7.16"), FtpWebRequest)
        'request.Credentials = New NetworkCredential("prod\yuyinerp", "yuyinerp")
        Dim Carpeta As String = RutaImagenesProveedores
        Dim objFTP As New Tools.TransferenciaFTP
        Dim StreamFoto As System.IO.Stream


        txtProveedor.Text = NombreProveedor        

        CargarTipoContacto()

        If ContactoID <> -1 Then
            lblTitulo.Text = "Edición Contacto"
            Me.Text = "Edición Contacto"

            objInformacionContacto = OBJContactoProveedor.ConsultaInformacionContacto(ContactoID)
            txtNombre.Text = objInformacionContacto.daco_nombre
            txtAPaterno.Text = objInformacionContacto.daco_APaterno
            txtAMaterno.Text = objInformacionContacto.daco_AMaterno
            txtemail.Text = objInformacionContacto.daco_email
            'cmbTipoContado.SelectedText = objInformacionContacto.daco_TipoContacto

            indice = cmbTipoContado.FindString(objInformacionContacto.daco_TipoContacto.Trim())
            'indice = cmbTipoContado.Items.IndexOf(objInformacionContacto.daco_TipoContacto.Trim())
            cmbTipoContado.SelectedIndex = indice
            txtCargo.Text = objInformacionContacto.daco_cargo
            txtTelefono.Text = objInformacionContacto.daco_telefono

            If objInformacionContacto.daco_activo = CBool(1).ToString() Then
                rdoSi.Checked = objInformacionContacto.daco_activo
                rdoNo.Checked = False
            Else
                rdoSi.Checked = False
                rdoNo.Checked = True
            End If

            Foto = objInformacionContacto.daco_foto
            Firma = objInformacionContacto.daco_Firma


            If Foto <> String.Empty Then
              
                ptbxFoto.SizeMode = PictureBoxSizeMode.StretchImage
                StreamFoto = objFTP.StreamFile(Carpeta, Foto)
                ptbxFoto.Image = Image.FromStream(StreamFoto)

            End If

            If Firma <> String.Empty Then                                
                ptbxFirma.SizeMode = PictureBoxSizeMode.StretchImage
                StreamFoto = objFTP.StreamFile(Carpeta, Firma)
                ptbxFirma.Image = Image.FromStream(StreamFoto)
            End If

            Foto = String.Empty
            Firma = String.Empty
            'Bloquear controles
            txtNombre.Enabled = False
            txtAPaterno.Enabled = False
            txtAMaterno.Enabled = False

        Else
            rdoSi.Checked = True
            rdoNo.Checked = False
            rdoSi.Enabled = False
            rdoNo.Enabled = False
        End If

    End Sub

    Private Sub bntSalir_Click(sender As Object, e As EventArgs) Handles bntSalir.Click
        Me.Close()
    End Sub

    Private Sub CargarTipoContacto()
        cmbTipoContado.Items.Clear()

        Dim DTTipoRazonSocial As New DataTable       
        DTTipoRazonSocial.Columns.Add("TipoContacto")

        Dim dtRow As DataRow = DTTipoRazonSocial.NewRow


        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ALM_CAT_PROV", "PERMISO_COMERCIALIZADORA") Then            
            dtRow("TipoContacto") = "COBRANZA"
            DTTipoRazonSocial.Rows.Add(dtRow)

            dtRow = DTTipoRazonSocial.NewRow            
            dtRow("TipoContacto") = "COBRANZA/VENTAS"
            DTTipoRazonSocial.Rows.Add(dtRow)

        ElseIf Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ALM_CAT_PROV", "PERMISO_NAVE") Then
            dtRow = DTTipoRazonSocial.NewRow
            dtRow("TipoContacto") = "VENTAS"
            DTTipoRazonSocial.Rows.Add(dtRow)

            dtRow = DTTipoRazonSocial.NewRow
            dtRow("TipoContacto") = "COBRANZA/VENTAS"
            DTTipoRazonSocial.Rows.Add(dtRow)

        End If


        cmbTipoContado.DataSource = DTTipoRazonSocial
        cmbTipoContado.DisplayMember = "TipoContacto"
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim OBJContactoProveedor As New Proveedores.BU.ContactoProveedorBU
        Dim objInformacionContacto As New Entidades.DatosContacto
        Dim ExisteContactoRepetido As Boolean = False
        Dim DTInformacionContacto As DataTable
        Dim RutaArchivoFoto As String = String.Empty
        Dim DirectorioFoto As String = String.Empty

        Cursor = Cursors.WaitCursor

        lblEmail.ForeColor = Color.Black

        If ValidarInformacion() = True Then
            If ContactoID = -1 Then
                If OBJContactoProveedor.BuscarContactoRepetido(txtNombre.Text.Trim(), txtAPaterno.Text.Trim(), txtAMaterno.Text.Trim()) = True Then
                    show_message("Advertencia", "Ya existe un contacto con el mismo nombre")
                    ExisteContactoRepetido = True
                End If
            End If



            If ExisteContactoRepetido = False Then
                objInformacionContacto.daco_nombre = txtNombre.Text.Trim()
                objInformacionContacto.daco_APaterno = txtAPaterno.Text.Trim()
                objInformacionContacto.daco_AMaterno = txtAMaterno.Text.Trim()
                objInformacionContacto.daco_email = txtemail.Text.Trim()
                objInformacionContacto.daco_TipoContacto = cmbTipoContado.Text.Trim()
                objInformacionContacto.daco_cargo = txtCargo.Text.Trim()
                objInformacionContacto.daco_telefono = txtTelefono.Text.Trim()
                objInformacionContacto.daco_activo = rdoSi.Checked
                objInformacionContacto.dage_proveedorid = ProveedorId
                'objInformacionContacto.daco_foto = Foto
                'objInformacionContacto.daco_Firma = Firma
                objInformacionContacto.daco_usuariocreoid = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
                objInformacionContacto.daco_datoscontactoid = ContactoID
                objInformacionContacto.dage_proveedorid = ProveedorId



                If ContactoID = -1 Then
                    DTInformacionContacto = OBJContactoProveedor.AltaContacto(ProveedorId, objInformacionContacto.daco_nombre, objInformacionContacto.daco_APaterno, objInformacionContacto.daco_AMaterno, objInformacionContacto.daco_cargo, objInformacionContacto.daco_telefono, objInformacionContacto.daco_email, objInformacionContacto.daco_TipoContacto, objInformacionContacto.daco_usuariocreoid, objInformacionContacto.daco_foto, objInformacionContacto.daco_Firma)
                Else
                    DTInformacionContacto = OBJContactoProveedor.EditarContacto(ContactoID, objInformacionContacto.daco_nombre, objInformacionContacto.daco_APaterno, objInformacionContacto.daco_AMaterno, objInformacionContacto.daco_cargo, objInformacionContacto.daco_telefono, objInformacionContacto.daco_email, objInformacionContacto.daco_TipoContacto, objInformacionContacto.daco_usuariocreoid, objInformacionContacto.daco_foto, objInformacionContacto.daco_Firma, objInformacionContacto.daco_activo)
                End If
                If DTInformacionContacto.Rows.Count > 0 Then
                    ContactoID = DTInformacionContacto.Rows(0).Item("daco_datoscontactoid").ToString()
                End If


                If Foto <> String.Empty Then
                    subirArchivo(Foto, True)
                End If

                If Firma <> String.Empty Then
                    subirArchivo(Firma, False)
                End If

                show_message("Exito", "Se ha guardado el contacto")
                Me.Close()
                Cursor = Cursors.Default
            End If

        Else

        End If



        Cursor = Cursors.Default

    End Sub


    Private Function ValidarInformacion() As Boolean
        Dim EsValido As Boolean = True

        If txtNombre.Text.Trim() = "" Then
            EsValido = False
            lblNombre.ForeColor = Drawing.Color.Red
        Else
            lblNombre.ForeColor = Drawing.Color.Black
        End If

        If txtAPaterno.Text.Trim() = "" Then
            EsValido = False
            lblAPaterno.ForeColor = Drawing.Color.Red
        Else
            lblAPaterno.ForeColor = Drawing.Color.Black
        End If

        If txtAMaterno.Text.Trim() = "" Then
            EsValido = False
            lblAMaterno.ForeColor = Drawing.Color.Red
        Else
            lblAMaterno.ForeColor = Drawing.Color.Black
        End If

        If txtemail.Text.Trim() = "" Then
            EsValido = False
            lblEmail.ForeColor = Drawing.Color.Red
        Else
            lblEmail.ForeColor = Drawing.Color.Black
        End If

        If txtTelefono.Text.Trim() = "" Then
            EsValido = False
            lblTelefono.ForeColor = Drawing.Color.Red
        Else
            lblTelefono.ForeColor = Drawing.Color.Black
        End If

        If cmbTipoContado.SelectedIndex < 0 Then
            EsValido = False
            lblTipoContacto.ForeColor = Drawing.Color.Red
        Else
            lblTipoContacto.ForeColor = Drawing.Color.Black
        End If

        If txtCargo.Text = String.Empty Then
            EsValido = False
            lblCargo.ForeColor = Color.Red
        Else
            lblCargo.ForeColor = Color.Black
        End If

        If EsValido = False Then
            show_message("Advertencia", "Faltan datos obligatorios por registrar.")
        End If

        If ValidateEmail(txtemail.Text.Trim()) = False Then
            If EsValido = True Then
                show_message("Advertencia", "La dirección de correo es inválida")
            End If

            EsValido = False
            lblEmail.ForeColor = Color.Red
        Else
            lblEmail.ForeColor = Color.Black
        End If

        Return EsValido
    End Function

    Public Function show_message(ByVal tipo As String, ByVal mensaje As String) As DialogResult
        Dim ResultadoDialogo As DialogResult

        If tipo.ToString.Equals("Advertencia") Then
            Dim mensajeAdvertencia As New AdvertenciaForm
            mensajeAdvertencia.mensaje = mensaje
            ResultadoDialogo = mensajeAdvertencia.ShowDialog()
        End If

        If tipo.ToString.Equals("AdvertenciaGrande") Then
            Dim mensajeAdvertencia As New AdvertenciaFormGrande
            mensajeAdvertencia.mensaje = mensaje
            ResultadoDialogo = mensajeAdvertencia.ShowDialog()
        End If

        If tipo.ToString.Equals("Aviso") Then

            Dim mensajeAviso As New AvisoForm
            mensajeAviso.mensaje = mensaje
            ResultadoDialogo = mensajeAviso.ShowDialog()

        End If

        If tipo.ToString.Equals("Error") Then

            Dim mensajeError As New ErroresForm
            mensajeError.mensaje = mensaje
            ResultadoDialogo = mensajeError.ShowDialog()

        End If

        If tipo.ToString.Equals("Exito") Then

            Dim mensajeExito As New ExitoForm
            mensajeExito.mensaje = mensaje
            ResultadoDialogo = mensajeExito.ShowDialog()

        End If

        If tipo.ToString.Equals("Confirmar") Then

            Dim mensajeExito As New ConfirmarForm
            mensajeExito.mensaje = mensaje
            ResultadoDialogo = mensajeExito.ShowDialog()

        End If

        Return ResultadoDialogo
    End Function



    Private Sub btnSubirFirma_Click(sender As Object, e As EventArgs)
        ofdFirma.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
        ofdFirma.Filter = "IMAGEN (*.JPG;*.PNG)|*.JPG;*.PNG;"
        ofdFirma.FilterIndex = 3
        ofdFirma.ShowDialog()

        Firma = ofdFirma.FileName

        If Firma <> String.Empty Then
            Dim Archivo As New System.IO.FileInfo(Firma)

            If Archivo.Length > 500000 Then
                show_message("Advertencia", "¡El tamaño del archivo no puede superar los 500 KB!")
                Firma = String.Empty
                ofdFirma.Reset()
            End If
        End If

    End Sub

    Private Sub ptbxFoto_DoubleClick(sender As Object, e As EventArgs) Handles ptbxFoto.DoubleClick
        ofdSubirFoto.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
        ofdSubirFoto.Filter = "IMAGEN (*.JPG;*.PNG)|*.JPG;*.PNG;"
        ofdSubirFoto.FilterIndex = 3
        ofdSubirFoto.ShowDialog()
        Foto = ofdSubirFoto.FileName

        If Foto <> String.Empty Then
            Dim Archivo As New System.IO.FileInfo(Foto)

            If Archivo.Length > 500000 Then
                show_message("Advertencia", "¡El tamaño del archivo no puede superar los 500 KB!")
                Foto = String.Empty
                ofdSubirFoto.Reset()
            Else
                If Foto <> String.Empty Then
                    ptbxFoto.SizeMode = PictureBoxSizeMode.StretchImage
                    ptbxFoto.Image = System.Drawing.Bitmap.FromFile(Foto)
                End If
            End If
        End If




    End Sub

    Private Function subirArchivo(ByVal ruta As String, ByVal EsFoto As Boolean) As Boolean

        Try
            Dim objbuContacto As New Proveedores.BU.ContactoProveedorBU

            Dim objFTP As New Tools.TransferenciaFTP
            'Dim request = DirectCast(WebRequest.Create(rutaFTP), FtpWebRequest)
            Dim rutaArchivo As String = String.Empty
            Dim RutaCarpeta As String = String.Empty
            Dim RutaFtp As String = objFTP.Hostname.ToString() + "/"

            ' request.Credentials = New NetworkCredential(ftpUsuario, ftpContrasena)
            Directorio = RutaImagenesProveedores & ProveedorId.ToString()


            If ruta <> "" Then
                objFTP.EnviarArchivo(Directorio, ruta)
                rutaArchivo = rutaFTP & Directorio & "/" & IO.Path.GetFileName(ruta)
                If EsFoto = True Then
                    If objFTP.FtpExisteArchivo(rutaFTP & Directorio & "/" + "foto_" + ContactoID.ToString() + IO.Path.GetExtension(ruta)) = True Then
                        RutaCarpeta = Directorio
                        objFTP.BorraArchivo(RutaCarpeta, "foto_" + ContactoID.ToString() + IO.Path.GetExtension(ruta))
                    End If

                    objFTP.RenombraArchivo(Directorio, IO.Path.GetFileName(ruta), "foto_" + ContactoID.ToString() + IO.Path.GetExtension(ruta))
                    objbuContacto.AgregarFotoFirmaContactoProveedor(ContactoID, ProveedorId.ToString() + "/" + "foto_" + ContactoID.ToString() + IO.Path.GetExtension(ruta), True)
                Else

                    If objFTP.FtpExisteArchivo(rutaFTP & Directorio & "/" + "firma_" + ContactoID.ToString() + IO.Path.GetExtension(ruta)) = True Then
                        RutaCarpeta = Directorio
                        objFTP.BorraArchivo(RutaCarpeta, "firma_" + ContactoID.ToString() + IO.Path.GetExtension(ruta))

                        'objFTP.RenombraArchivo(Directorio, IO.Path.GetFileName(ruta), "firma_" + ContactoID.ToString() + "_Anterior" + IO.Path.GetExtension(ruta))
                    End If
                    objFTP.RenombraArchivo(Directorio, IO.Path.GetFileName(ruta), "firma_" + ContactoID.ToString() + IO.Path.GetExtension(ruta))
                    objbuContacto.AgregarFotoFirmaContactoProveedor(ContactoID, ProveedorId.ToString() + "/" + "firma_" + ContactoID.ToString() + IO.Path.GetExtension(ruta), False)
                End If

                If objFTP.FtpExisteArchivo(rutaArchivo) Then
                    Return True


                Else
                    Return False
                End If
            Else
                Return False
            End If
        Catch
            Return False
        End Try

        Return True
    End Function

    Function ValidateEmail(ByVal email As String) As Boolean
        Dim emailRegex As New System.Text.RegularExpressions.Regex(
            "^([0-9a-zA-Z]([-\.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$")
        Dim emailMatch As System.Text.RegularExpressions.Match =
           emailRegex.Match(email)
        Return emailMatch.Success
    End Function

    Private Sub txtemail_LostFocus(sender As Object, e As EventArgs) Handles txtemail.LostFocus
        If ValidateEmail(txtemail.Text.Trim()) = False Then
            lblEmail.ForeColor = Color.Red
            'show_message("Advertencia", "La dirección de correo es inválida")
        Else
            lblEmail.ForeColor = Color.Black
        End If
    End Sub

    Private Sub lblFirma_Click(sender As Object, e As EventArgs) Handles lblFirma.Click

    End Sub

    Private Sub txtTelefono_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTelefono.KeyPress
        If Not (IsNumeric(e.KeyChar) Or e.KeyChar = ChrW(Keys.Back) Or e.KeyChar = "-" Or e.KeyChar = ")" Or e.KeyChar = "(") Then
            e.Handled = True
        End If
    End Sub

    'Private Sub lnkVerFirma_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)


    '    If IsNothing(ptbxFirma.Image) = False Then
    '        If lnkVerFirma.Text = "Ver Firma" Then
    '            ptbxFirma.Visible = True
    '            lnkVerFirma.Text = "Ocultar Firma"
    '        Else
    '            lnkVerFirma.Text = "Ver Firma"
    '            ptbxFirma.Visible = False
    '        End If
    '    End If
    'End Sub



    Private Sub ptbxFirma_DoubleClick(sender As Object, e As EventArgs) Handles ptbxFirma.DoubleClick


        ofdFirma.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
        ofdFirma.Filter = "IMAGEN (*.JPG;*.PNG)|*.JPG;*.PNG;"
        ofdFirma.FilterIndex = 3
        ofdFirma.ShowDialog()

        Firma = ofdFirma.FileName

        If Firma <> String.Empty Then
            Dim Archivo As New System.IO.FileInfo(Firma)

            If Archivo.Length > 500000 Then
                show_message("Advertencia", "¡El tamaño del archivo no puede superar los 500 KB!")
                Firma = String.Empty
                ofdFirma.Reset()
            Else
                If Firma <> String.Empty Then
                    ptbxFirma.SizeMode = PictureBoxSizeMode.StretchImage
                    ptbxFirma.Image = System.Drawing.Bitmap.FromFile(Firma)
                End If
            End If
        End If



    End Sub

    Private Sub pbYuyin_Click(sender As Object, e As EventArgs) Handles pbYuyin.Click

    End Sub
End Class