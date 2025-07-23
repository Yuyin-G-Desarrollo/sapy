Imports System.Drawing
Imports System.Net
Imports System.Windows.Forms
Imports Entidades
Imports Proveedores.BU
Imports Tools

Public Class Mercadotecnia_AltaEdicion_MaterialesForm
    Dim objFTP As New Global.Tools.TransferenciaFTP
    Public vLstMaterialesPOP As New List(Of Entidades.EditarMaterialesMercadotecniaPOP)
    Public vEditarMaterial As EditarMaterialesMercadotecniaPOP
    Dim MaterialesPOP As Mercadotecnia_Inventario_MaterialesForm
    Dim codigoProducto As String = String.Empty
    Dim NombreFoto As String
    Dim NombreDibujo As String
    Dim rutaFtp As String = objFTP.obtenerURL
    Dim FtpUser As String = objFTP.obtenerUsuario
    Dim ftppasswd As String = objFTP.obtenerContrasena
    Dim advertencia As New AdvertenciaForm
    Dim exito As New ExitoForm
    Dim confirmar As New ConfirmarForm
    Public AltaMaterialPOP As Boolean
    Private CamposVacios As Boolean = False
    Dim rutaFotografia As String
    Dim nombreImagen As String
    Dim cambioFoto As Boolean = False
    Public VistaDetalles As Boolean


    Private Sub Mercadotecnia_AltaEdicion_MaterialesForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If VistaDetalles = True Then
            btnGuardar.Visible = False
            lblGuardar.Visible = False
            btnAbrirFoto.Enabled = False
        End If

        If AltaMaterialPOP = True Then
            txtNombreMaterial.Focus()
            llenarComboMarca()
            llenarComboUnidad()
        Else

            vEditarMaterial = vLstMaterialesPOP.FirstOrDefault()

            txtNombreMaterial.Text = vEditarMaterial.PNombreMaterial
            txtDescripcionMaterial.Text = vEditarMaterial.PDescripcion
            txtMotivoFabricacion.Text = vEditarMaterial.PMotivoFabricacion
            txtPrecio.Text = vEditarMaterial.PPrecio.ToString("N2")
            llenarComboMarca()
            cmbMarca.Text = vEditarMaterial.PMarca
            llenarComboUnidad()
            cmbUMC.Text = vEditarMaterial.PUMC

            txtExistencia.Text = vEditarMaterial.PExistencia

            If vEditarMaterial.PEstatusM = "Activo" Then
                rdoSi.Checked = True
                rdoNo.Checked = False

            Else
                rdoNo.Checked = True
                rdoSi.Checked = False
            End If


            NombreFoto = vEditarMaterial.PRutaFoto
            nombreImagen = vEditarMaterial.PnombreImagen


            Try
                Dim request = DirectCast(WebRequest.Create(rutaFtp), FtpWebRequest)
                request.Credentials = New NetworkCredential(FtpUser, ftppasswd)
                Dim Carpeta As String = "Mercadotecnia/Materiales/"
                Dim objFTP As New Tools.TransferenciaFTP
                Dim StreamFoto As System.IO.Stream
                'Dim StreamDibujo As System.IO.Stream

                StreamFoto = objFTP.StreamFile(NombreFoto, nombreImagen)
                picFoto.Image = Image.FromStream(StreamFoto)

            Catch ex As Exception

            End Try
        End If




    End Sub

    Public Sub validarCamposVacios()
        CamposVacios = False

        If txtNombreMaterial.Text = "" Then
            CamposVacios = True
            lblNombre.ForeColor = Drawing.Color.Red
        Else
            lblNombre.ForeColor = Drawing.Color.Black
        End If

        If txtDescripcionMaterial.Text = "" Then
            CamposVacios = True
            lblDescripcion.ForeColor = Drawing.Color.Red
        Else
            lblDescripcion.ForeColor = Drawing.Color.Black
        End If

        If txtMotivoFabricacion.Text = "" Then
            CamposVacios = True
            lblMotivoFabricacion.ForeColor = Drawing.Color.Red
        Else
            lblMotivoFabricacion.ForeColor = Drawing.Color.Black
        End If

        If cmbMarca.Text = "" Then
            CamposVacios = True
            lblMarca.ForeColor = Drawing.Color.Red
        Else
            lblMarca.ForeColor = Drawing.Color.Black
        End If


        If cmbUMC.Text = "" Then
            CamposVacios = True
            lblUMC.ForeColor = Drawing.Color.Red
        Else
            lblUMC.ForeColor = Drawing.Color.Black
        End If

    End Sub

    Public Sub llenarComboMarca()
        Dim objBU As New MercadotecniaBU
        Dim dtMarcaMaterial As New DataTable
        dtMarcaMaterial = objBU.llenarComboMarcas()
        dtMarcaMaterial.Rows.InsertAt(dtMarcaMaterial.NewRow, 0)
        cmbMarca.DataSource = dtMarcaMaterial
        cmbMarca.DisplayMember = "Marca"
        cmbMarca.ValueMember = "MarcaID"

    End Sub

    Public Sub llenarComboUnidad()
        Dim objBU As New MercadotecniaBU
        Dim dtUnidadMaterial As New DataTable
        dtUnidadMaterial = objBU.llenarComboUnidad()
        dtUnidadMaterial.Rows.InsertAt(dtUnidadMaterial.NewRow, 0)
        cmbUMC.DataSource = dtUnidadMaterial
        cmbUMC.DisplayMember = "UnidadNombre"
        cmbUMC.ValueMember = "UnidadID"

    End Sub



    Public Sub registrarImagenesFTP()
        Try
            Dim foto As New Tools.TransferenciaFTP

            If (ofdFoto.SafeFileName().ToString = "ofdFoto") Then
            ElseIf (ofdFoto.SafeFileName.ToString <> "ofdFoto") Then
                foto.EnviarArchivo("Mercadotecnia/Materiales/" + txtNombreMaterial.Text + "/", ofdFoto.FileName)
                foto.EnviarArchivo("Mercadotecnia/Materiales/" + txtNombreMaterial.Text + "/", ofdFoto.FileName)

                rutaFotografia = "Mercadotecnia/Materiales/" + txtNombreMaterial.Text
                nombreImagen = ofdFoto.SafeFileName.ToString
                cambioFoto = True
            End If

        Catch ex As Exception
            MsgBox("Sucedió algo inesperado, no se pudo subir la imagen.")
        End Try
    End Sub


    Private Sub btnAbrirFoto_Click(sender As Object, e As EventArgs) Handles btnAbrirFoto.Click
        If ofdFoto.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Dim sr As New System.IO.StreamReader(ofdFoto.FileName)
            picFoto.Image = Image.FromFile(ofdFoto.FileName)
            sr.Close()
        End If
        cambioFoto = True
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim objBU As New MercadotecniaBU
        Dim NombreMaterial As String
        Dim Descripcion As String
        Dim MotivoFabricacion As String
        Dim IDMarca As String
        Dim UMC As Integer
        Dim Estatus As Integer
        Dim Precio As Integer
        Dim accion As Integer
        Dim usuario As String
        Dim Existencia As Integer

        validarCamposVacios()

        If cambioFoto = True Then
            validacionesGuardar()
        End If


        If CamposVacios = True Then
            advertencia.mensaje = "Existen campos sin llenar."
            advertencia.ShowDialog()
        End If


        Existencia = txtExistencia.Text
        NombreMaterial = txtNombreMaterial.Text
        Descripcion = txtDescripcionMaterial.Text
        MotivoFabricacion = txtMotivoFabricacion.Text
        IDMarca = cmbMarca.SelectedValue
        UMC = cmbUMC.SelectedValue

        usuario = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid

        If rdoSi.Checked = True Then
            Estatus = 1
        Else
            Estatus = 0
        End If

        Precio = txtPrecio.Text

        confirmar.mensaje = "¿Está seguro de actualizar la información?"
        If confirmar.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Cursor = Cursors.WaitCursor


            Dim vXmlMateriales As XElement = New XElement("Materiales")
            If AltaMaterialPOP = True Then

                Dim vNodo As XElement = New XElement("Material")
                vNodo.Add(New XAttribute("PNombreMaterial", NombreMaterial))
                vNodo.Add(New XAttribute("PDescripcion", Descripcion))
                vNodo.Add(New XAttribute("PMotivoFabricacion", MotivoFabricacion))
                vNodo.Add(New XAttribute("PMarca", IDMarca))
                vNodo.Add(New XAttribute("PUMC", UMC))
                vNodo.Add(New XAttribute("PEstatusM", Estatus))
                vNodo.Add(New XAttribute("PPrecio", Precio))
                vNodo.Add(New XAttribute("PUsuario", usuario))
                vNodo.Add(New XAttribute("PExistencia", Existencia))
                If rutaFotografia = "" Then
                    vNodo.Add(New XAttribute("PrutaFotografia", ""))
                    vNodo.Add(New XAttribute("PNombreImagen", ""))
                Else
                    vNodo.Add(New XAttribute("PrutaFotografia", rutaFotografia))
                    vNodo.Add(New XAttribute("PNombreImagen", nombreImagen))
                End If


                vXmlMateriales.Add(vNodo)
                accion = 1
            Else
                If vLstMaterialesPOP.Count > 0 Then
                    For Each item In vLstMaterialesPOP
                        Dim vNodo As XElement = New XElement("Material")
                        vNodo.Add(New XAttribute("PIdMaterial", item.PIdMaterial))
                        vNodo.Add(New XAttribute("PNombreMaterial", NombreMaterial))
                        vNodo.Add(New XAttribute("PDescripcion", Descripcion))
                        vNodo.Add(New XAttribute("PMotivoFabricacion", MotivoFabricacion))
                        vNodo.Add(New XAttribute("PMarca", IDMarca))
                        vNodo.Add(New XAttribute("PUMC", UMC))
                        vNodo.Add(New XAttribute("PEstatusM", Estatus))
                        vNodo.Add(New XAttribute("PPrecio", Precio))
                        vNodo.Add(New XAttribute("PUsuario", usuario))
                        If cambioFoto = True Then
                            vNodo.Add(New XAttribute("PrutaFotografia", rutaFotografia))
                            vNodo.Add(New XAttribute("PNombreImagen", nombreImagen))
                            vNodo.Add(New XAttribute("PCambiaFoto", 1))
                        Else
                            vNodo.Add(New XAttribute("PCambiaFoto", 0))
                        End If
                        vNodo.Add(New XAttribute("PExistencia", Existencia))

                        vXmlMateriales.Add(vNodo)
                        accion = 2
                    Next
                End If
            End If


            objBU.ActualizarInventarioMaterialPOP(vXmlMateriales.ToString(), accion)
            exito.mensaje = "Se realizaron los cambios con éxito."
                exito.ShowDialog()

            Else
                advertencia.mensaje = "No se actualizaron los datos. Intente Nuevamente."
                advertencia.ShowDialog()
            End If
        Cursor = Cursors.WaitCursor

        Me.Close()
    End Sub

    Public Sub validacionesGuardar()
        registrarImagenesFTP()
    End Sub

    Private Sub bntSalir_Click(sender As Object, e As EventArgs) Handles bntSalir.Click
        Me.Close()
    End Sub



    Private Sub txtPrecio_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPrecio.KeyPress
        Dim caracter As Char = e.KeyChar
        If (Char.IsNumber(caracter)) Or (caracter = ChrW(Keys.Back)) Or (caracter = ".") And (txtPrecio.Text.Contains(".") = False) Then
            e.Handled = False
        Else
            e.Handled = True

        End If
    End Sub

    Private Sub txtPrecio_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPrecio.LostFocus
        Try
            Dim Monto As Double = txtPrecio.Text
            Monto = Math.Round(Monto, 2)
            txtPrecio.Text = Monto.ToString("c")

        Catch ex As Exception

        End Try

    End Sub

End Class