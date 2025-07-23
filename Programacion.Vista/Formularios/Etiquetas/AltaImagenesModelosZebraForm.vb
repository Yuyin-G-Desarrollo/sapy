Imports System.IO

Public Class AltaImagenesModelosZebraForm

    Private _EntidadModeloTallas As Entidades.ModeloTallas
    Public Property EntidadModeloTallas() As Entidades.ModeloTallas
        Get
            Return _EntidadModeloTallas
        End Get
        Set(ByVal value As Entidades.ModeloTallas)
            _EntidadModeloTallas = value
        End Set
    End Property


    Private insertado203 As Boolean
    Private insertado300 As Boolean
    Dim esCoppel As Boolean = False

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub AltaImagenesModelosZebraForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtTalla.Text = _EntidadModeloTallas.IdTalla
        txtColeccion.Text = _EntidadModeloTallas.IdLinea
        txtModelo.Text = _EntidadModeloTallas.IdModelo
        txtModeloTallaCorrida.Text = _EntidadModeloTallas.Marca + " " + _EntidadModeloTallas.Coleccion + " " + _EntidadModeloTallas.IdModelo + " " + _EntidadModeloTallas.Talla
        Cargar_Imagen()
        gboxCoppel.Enabled = False
    End Sub


    Private Sub Cargar_Imagen()

        Dim msg_error As New Tools.ErroresForm
        Dim objNeg As New Negocios.EtiquetasBU
        Dim cadena_Tallas As String
        Dim cadena_opciones As String

        Try

            cadena_Tallas = _EntidadModeloTallas.SiluetaZebra
            cadena_opciones = objNeg.ConsultarCadenaRutaJPGOpciones

            If cadena_opciones <> String.Empty And cadena_Tallas <> String.Empty Then
                pnlImagen.Image = Image.FromFile(cadena_opciones + cadena_Tallas)
            End If

        Catch ex As Exception
            msg_error.mensaje = ex.Message
            msg_error.ShowDialog()
        End Try


    End Sub

    Private Sub btnExaminar203_Click(sender As Object, e As EventArgs) Handles btnExaminar203.Click
        ofdRutaArchivo.Reset()
        ofdRutaArchivo.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
        ofdRutaArchivo.Filter = "GRF|*.grf;"
        ofdRutaArchivo.FilterIndex = 3
        ofdRutaArchivo.ShowDialog()
        txtArchivo203.Text = ofdRutaArchivo.FileName
    End Sub

    Private Sub btnExaminar300_Click(sender As Object, e As EventArgs) Handles btnExaminar300.Click
        ofdRutaArchivo.Reset()
        ofdRutaArchivo.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
        ofdRutaArchivo.Filter = "GRF|*.grf;"
        ofdRutaArchivo.FilterIndex = 3
        ofdRutaArchivo.ShowDialog()
        txtArchivo300.Text = ofdRutaArchivo.FileName
    End Sub

    Private Sub btnExaminarjpg_Click(sender As Object, e As EventArgs) Handles btnExaminarjpg.Click
        ofdRutaArchivo.Reset()
        ofdRutaArchivo.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
        ofdRutaArchivo.Filter = "JPG|*.jpg;"
        ofdRutaArchivo.FilterIndex = 3
        ofdRutaArchivo.ShowDialog()
        txtSiluetaJPG.Text = ofdRutaArchivo.FileName
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim msg_adv As New Tools.AdvertenciaForm
        Dim msg_Exito As New Tools.ExitoForm
        Dim msg_Confirmacion As New Tools.ConfirmarForm
        Dim objNeg As New Negocios.EtiquetasBU
        Dim msg_error As New Tools.ErroresForm
        Dim Ruta_GRF As String
        Dim RutaRelativaSilueta As String = String.Empty

        Try
            If Validar_Campos() Then

                'If chkCoppel.Checked Then
                '    If txtArchivoCoppelNiño203.Text <> String.Empty Or txtArchivoCoppelNiño300.Text <> String.Empty Or
                '       txtArchivoCoppelAdulto203.Text = String.Empty Or txtArchivoCoppelAdulto300.Text <> String.Empty Then
                '        msg_adv.mensaje = "Seleccione los archivos a cargar."
                '        msg_adv.ShowDialog()
                '    End If
                'ElseIf chkCoppel.Checked = False Then
                If txtArchivo203.Text <> String.Empty Or txtArchivo300.Text <> String.Empty Then
                    If txtArchivo203.Text = txtArchivo300.Text Then
                        msg_adv.mensaje = "Seleccionó el mismo archivo."
                        msg_adv.ShowDialog()
                        Return
                    End If
                End If
                'End If

                'If txtArchivo203.Text <> String.Empty Or txtArchivo300.Text <> String.Empty Then
                '    If txtArchivo203.Text = txtArchivo300.Text Then
                '        msg_adv.mensaje = "Seleccionó el mismo archivo."
                '        msg_adv.ShowDialog()
                '        Return
                '    End If
                'End If



                msg_Confirmacion.mensaje = "¿Esta seguro de guardar los cambios?"
                If msg_Confirmacion.ShowDialog = Windows.Forms.DialogResult.OK Then

                    Ruta_GRF = objNeg.ConsultarCadenaRutaGRFOpciones


                    If Not System.IO.Directory.Exists(Ruta_GRF) Then
                        Directory.CreateDirectory(Ruta_GRF)
                    End If

                    'If Validar_Existencia_Archivos(txtArchivo203.Text, txtArchivo300.Text, Ruta_GRF) Then
                    If Validar_Existencia_Archivos(txtArchivo203.Text, txtArchivo300.Text, Ruta_GRF, txtArchivoCoppelNiño203.Text, txtArchivoCoppelNiño300.Text, txtArchivoCoppelAdulto203.Text, txtArchivoCoppelAdulto300.Text) Then

                        If txtSiluetaJPG.Text <> String.Empty Then
                            If Guardar_Imagen(txtSiluetaJPG.Text) = False Then Return
                            RutaRelativaSilueta = _EntidadModeloTallas.Marca + "\SILUETAS\" + Path.GetFileName(txtSiluetaJPG.Text.Trim())
                            _EntidadModeloTallas.SiluetaZebra = RutaRelativaSilueta
                        Else
                            _EntidadModeloTallas.SiluetaZebra = String.Empty
                        End If

                        If txtArchivo203.Text <> String.Empty Then
                            Guardar_ArchivoGRF(txtArchivo203.Text, 203, Ruta_GRF, "N")
                        End If

                        If txtArchivo300.Text <> String.Empty Then
                            Guardar_ArchivoGRF(txtArchivo300.Text, 300, Ruta_GRF, "N")
                        End If

                        If txtArchivoCoppelNiño203.Text <> String.Empty Then
                            Guardar_ArchivoGRF(txtArchivoCoppelNiño203.Text, 203, Ruta_GRF, "CN2")
                        End If

                        If txtArchivoCoppelNiño300.Text <> String.Empty Then
                            Guardar_ArchivoGRF(txtArchivoCoppelNiño300.Text, 300, Ruta_GRF, "CN3")
                        End If

                        If txtArchivoCoppelAdulto203.Text <> String.Empty Then
                            Guardar_ArchivoGRF(txtArchivoCoppelAdulto203.Text, 203, Ruta_GRF, "CA2")
                        End If

                        If txtArchivoCoppelAdulto300.Text <> String.Empty Then
                            Guardar_ArchivoGRF(txtArchivoCoppelAdulto300.Text, 300, Ruta_GRF, "CA3")
                        End If

                        _EntidadModeloTallas.UsuarioModifico = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
                            objNeg.ActualizarModeloSiluetaSICY(_EntidadModeloTallas)
                            msg_Exito.mensaje = "El registro se realizó con éxito."
                            msg_Exito.ShowDialog()
                            Me.Close()

                        End If

                    End If

            Else

                If chkCoppel.Checked Then
                    msg_adv.mensaje = "Los campos coppel deben ser completados."
                    msg_adv.ShowDialog()
                Else
                    msg_adv.mensaje = "Los campos deben ser completados."
                    msg_adv.ShowDialog()
                End If
                'msg_adv.mensaje = "Los campos en rojo deben ser completados."
                'msg_adv.ShowDialog()
            End If
        Catch ex As Exception
            msg_error.mensaje = ex.Message
            msg_error.ShowDialog()
        End Try
    End Sub

    Private Function Validar_Existencia_Archivos(ByVal ruta_GRF203 As String, ByVal ruta_GRF300 As String, ByVal directorio As String, ByVal ruta_GRFCN203 As String, ByVal ruta_GRFCN300 As String, ByVal ruta_GRFCA203 As String, ByVal ruta_GRFCA300 As String) As Boolean
        Dim msg_Advertencia As New Tools.AdvertenciaForm
        Dim Ruta_completa_203 As String
        Dim Ruta_completa_300 As String
        Dim valida As Boolean = True
        Dim Archivo203() As String
        Dim Archivo300() As String
        Dim confirmar As New Tools.ConfirmarForm
        Dim ExisteArchivo As Boolean
        Dim ArchivosExistentes As String = String.Empty
        Dim ArchivoCN203() As String
        Dim ArchivoCN300() As String
        Dim ArchivoCA203() As String
        Dim ArchivoCA300() As String
        Dim Ruta_completaCN_203 As String
        Dim Ruta_completaCN_300 As String
        Dim Ruta_completaCA_203 As String
        Dim Ruta_completaCA_300 As String

        Try

            Archivo203 = Split(ruta_GRF203, "\")
            Archivo300 = Split(ruta_GRF300, "\")
            ArchivoCN203 = Split(ruta_GRFCN203, "\")
            ArchivoCN300 = Split(ruta_GRFCN300, "\")
            ArchivoCA203 = Split(ruta_GRFCA203, "\")
            ArchivoCA300 = Split(ruta_GRFCA300, "\")

            If ruta_GRF203 <> String.Empty Then
                Ruta_completa_203 = directorio + Archivo203(Archivo203.Length - 1)
            End If

            If ruta_GRF300 <> String.Empty Then
                Ruta_completa_300 = directorio + Archivo300(Archivo300.Length - 1)
            End If

            '============================================================================================
            ' CarloMtz 
            ' Validación ruta archivo coppel
            If ruta_GRFCN203 <> String.Empty Then
                Ruta_completaCN_203 = directorio + ArchivoCN203(ArchivoCN203.Length - 1)
            End If
            If ruta_GRFCN300 <> String.Empty Then
                Ruta_completaCN_300 = directorio + ArchivoCN300(ArchivoCN300.Length - 1)
            End If
            If ruta_GRFCA203 <> String.Empty Then
                Ruta_completaCA_203 = directorio + ArchivoCA203(ArchivoCA203.Length - 1)
            End If
            If ruta_GRFCA300 <> String.Empty Then
                Ruta_completaCA_300 = directorio + ArchivoCA300(ArchivoCA300.Length - 1)
            End If
            '============================================================================================

            'If chkCoppel.Checked = False Then
            If ruta_GRF203 <> String.Empty Then
                    If File.Exists(Ruta_completa_203) Then
                        ArchivosExistentes = Path.GetFileName(Ruta_completa_203)
                        ExisteArchivo = True
                    End If
                End If

                If ruta_GRF300 <> String.Empty Then
                    If File.Exists(Ruta_completa_300) Then
                        If ArchivosExistentes = String.Empty Then
                            ArchivosExistentes = Path.GetFileName(Ruta_completa_300)
                        Else
                            ArchivosExistentes &= ", " & Path.GetFileName(Ruta_completa_300)
                        End If

                        ExisteArchivo = True
                    End If
                End If
            'ElseIf chkCoppel.Checked Then
            If ruta_GRFCN203 <> String.Empty Then
                    If File.Exists(Ruta_completaCN_203) Then
                        ArchivosExistentes = Path.GetFileName(Ruta_completaCN_203)
                        ExisteArchivo = True
                    End If
                End If

                If ruta_GRFCN300 <> String.Empty Then
                    If File.Exists(Ruta_completaCN_300) Then
                        ArchivosExistentes = Path.GetFileName(Ruta_completaCN_300)
                        ExisteArchivo = True
                    End If
                End If

                If ruta_GRFCA203 <> String.Empty Then
                    If File.Exists(Ruta_completaCA_203) Then
                        ArchivosExistentes = Path.GetFileName(Ruta_completaCA_203)
                        ExisteArchivo = True
                    End If
                End If

                If ruta_GRFCA300 <> String.Empty Then
                    If File.Exists(Ruta_completaCA_300) Then
                        If ArchivosExistentes = String.Empty Then
                            ArchivosExistentes = Path.GetFileName(Ruta_completaCA_300)
                        Else
                            ArchivosExistentes &= ", " & Path.GetFileName(Ruta_completaCA_300)
                        End If
                        ExisteArchivo = True
                    End If
                End If
            'End If



            If ExisteArchivo = True Then
                confirmar.mensaje = "El archivo " & ArchivosExistentes & " ya existe ¿Desea reemplazarlo?"
                If confirmar.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    valida = True
                Else
                    valida = False
                End If
            Else
                valida = True
            End If


            'If File.Exists(Ruta_completa_203) Or File.Exists(Ruta_completa_300) Then
            '    confirmar.mensaje = "El archivo ya existe ¿Desea reemplazarlo?"
            '    If confirmar.ShowDialog() = Windows.Forms.DialogResult.OK Then
            '        valida = True
            '    Else
            '        valida = False
            '    End If

            'End If

            'If File.Exists(Ruta_completa_203) Then
            '    msg_Advertencia.mensaje = "El archivo " + Ruta_completa_203 + " ya existe."
            '    msg_Advertencia.ShowDialog()
            '    valida = False
            'End If

            'If File.Exists(Ruta_completa_300) Then
            '    msg_Advertencia.mensaje = "El archivo " + Ruta_completa_300 + " ya existe."
            '    msg_Advertencia.ShowDialog()
            '    valida = False
            'End If

            Return valida
        Catch ex As Exception
            Dim msg_error As New Tools.ErroresForm
            msg_error.mensaje = ex.Message
            msg_error.ShowDialog()
            Return False
        End Try
    End Function

    Private Sub Guardar_ArchivoGRF(ByVal ruta As String, ByVal silueta As Integer, ByVal Ruta_GRF As String, ByVal Opcion As String)
        Dim msg_error As New Tools.ErroresForm
        Dim objNeg As New Negocios.EtiquetasBU
        Dim msg_Advertencia As New Tools.AdvertenciaForm
        Dim nombre_archivo As String
        Dim archivo() As String

        Try

            archivo = Split(ruta, "\")
            nombre_archivo = archivo(archivo.Length - 1)

            Ruta_GRF = Ruta_GRF + nombre_archivo
            System.IO.File.Copy(ruta, Ruta_GRF, True)

            If silueta = 203 Then
                Select Case Opcion
                    Case = "N"
                        _EntidadModeloTallas.RutaSilueta203 = Ruta_GRF
                        _EntidadModeloTallas.ArchivoZebra = nombre_archivo
                    Case = "CN2"
                        _EntidadModeloTallas.RutaSiluetaCN203 = Ruta_GRF
                        _EntidadModeloTallas.ArchivoZebraCN203 = nombre_archivo
                    Case = "CA2"
                        _EntidadModeloTallas.RutaSiluetaCA203 = Ruta_GRF
                        _EntidadModeloTallas.ArchivoZebraCA203 = nombre_archivo
                End Select

            ElseIf silueta = 300 Then
                Select Case Opcion
                    Case = "N"
                        _EntidadModeloTallas.RutaSilueta300 = Ruta_GRF
                        _EntidadModeloTallas.ArchivoZebra300 = nombre_archivo
                    Case = "CN3"
                        _EntidadModeloTallas.RutaSiluetaCN300 = Ruta_GRF
                        _EntidadModeloTallas.ArchivoZebraCN300 = nombre_archivo
                    Case = "CA3"
                        _EntidadModeloTallas.RutaSiluetaCA300 = Ruta_GRF
                        _EntidadModeloTallas.ArchivoZebraCA300 = nombre_archivo
                End Select



            End If

        Catch ex As Exception
            msg_error.mensaje = ex.Message
            msg_error.ShowDialog()
        End Try
    End Sub

    Private Function Guardar_Imagen(ByVal ruta_imagen_seleccionada As String) As Boolean
        Dim msg_error As New Tools.ErroresForm
        Dim objNeg As New Negocios.EtiquetasBU
        Dim msg_Advertencia As New Tools.AdvertenciaForm
        Dim nombre_archivo As String
        Dim archivo() As String
        Dim cadena_opciones As String
        Dim ruta_opciones As String
        Dim NuevaRuta As String = ""
        Dim confirmar As New Tools.ConfirmarForm

        Try

            If ruta_imagen_seleccionada <> String.Empty Then

                ruta_opciones = objNeg.ConsultarCadenaRutaCompletaJPGOpciones
                NuevaRuta = ruta_opciones + _EntidadModeloTallas.Marca

                If Not System.IO.Directory.Exists(NuevaRuta) Then
                    Directory.CreateDirectory(NuevaRuta)
                End If

                archivo = Split(ruta_imagen_seleccionada, "\")
                nombre_archivo = archivo(archivo.Length - 1)

                If File.Exists(NuevaRuta + "\" + nombre_archivo) Then

                    If confirmar.ShowDialog() = Windows.Forms.DialogResult.OK Then
                        NuevaRuta = NuevaRuta + "\" + nombre_archivo
                        System.IO.File.Copy(ruta_imagen_seleccionada, NuevaRuta, True)
                    Else
                        Return False
                    End If
                    'msg_Advertencia.mensaje = "El archivo " + NuevaRuta + "\" + nombre_archivo + " ya existe."
                    'msg_Advertencia.ShowDialog()
                Else
                    NuevaRuta = NuevaRuta + "\" + nombre_archivo
                    System.IO.File.Copy(ruta_imagen_seleccionada, NuevaRuta, True)
                End If
            Else

                cadena_opciones = objNeg.ConsultarCadenaRutaJPGOpciones

                If _EntidadModeloTallas.SiluetaZebra <> String.Empty Then
                    NuevaRuta = cadena_opciones + _EntidadModeloTallas.SiluetaZebra
                End If

            End If

            _EntidadModeloTallas.RutaCompletaJPG = NuevaRuta

            Return True
        Catch ex As Exception
            msg_error.mensaje = ex.Message
            msg_error.ShowDialog()
            Return False
        End Try

    End Function


    Private Function Validar_Campos() As Boolean

        Dim valida As Boolean = True

        If esCoppel Then
            If txtArchivoCoppelNiño203.Text = String.Empty And txtArchivoCoppelNiño300.Text = String.Empty And
                txtArchivoCoppelAdulto203.Text = String.Empty And txtArchivoCoppelAdulto300.Text = String.Empty Then
                valida = False
            End If
        ElseIf txtArchivo203.Text = String.Empty And txtArchivo300.Text = String.Empty And txtSiluetaJPG.Text = String.Empty Then
            valida = False
        End If

        'If txtArchivo203.Text = String.Empty And txtArchivo300.Text = String.Empty And txtSiluetaJPG.Text = String.Empty Then
        '    valida = False
        'End If

        Return valida

        'If txtArchivo203.Text = String.Empty Then
        '    lblImagen_203.ForeColor = Color.Red
        '    valida = False
        'Else
        '    lblImagen_203.ForeColor = Color.Black
        'End If

        'If txtArchivo300.Text = String.Empty Then
        '    lblImagen_300.ForeColor = Color.Red
        '    valida = False
        'Else
        '    lblImagen_300.ForeColor = Color.Black
        'End If

        Return valida
    End Function

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles rbtCoppel.CheckedChanged
        'If rbtCoppel.Checked Then
        '    gboxCoppel.Enabled = True
        'Else
        '    gboxCoppel.Enabled = False
        '    txtArchivoCoppel203.Text = String.Empty
        '    txtArchivoCoppel300.Text = String.Empty
        'End If
    End Sub

    Private Sub chkCoppel_CheckedChanged(sender As Object, e As EventArgs) Handles chkCoppel.CheckedChanged
        If chkCoppel.Checked Then
            Me.Size = New Size(690, 593)
            gboxCoppel.Enabled = True
            esCoppel = True
        Else
            Me.Size = New Size(690, 425)
            gboxCoppel.Enabled = False
            txtArchivoCoppelNiño203.Text = String.Empty
            txtArchivoCoppelNiño300.Text = String.Empty
            esCoppel = False
        End If
    End Sub

    Private Sub btnExaminarCoppel203_Click(sender As Object, e As EventArgs) Handles btnExaminarCoppelN203.Click
        ofdRutaArchivo.Reset()
        ofdRutaArchivo.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
        ofdRutaArchivo.Filter = "GRF|*.grf;"
        ofdRutaArchivo.FilterIndex = 3
        ofdRutaArchivo.ShowDialog()
        txtArchivoCoppelNiño203.Text = ofdRutaArchivo.FileName
    End Sub

    Private Sub btnExaminarCoppel300_Click(sender As Object, e As EventArgs) Handles btnExaminarCoppelN300.Click
        ofdRutaArchivo.Reset()
        ofdRutaArchivo.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
        ofdRutaArchivo.Filter = "GRF|*.grf;"
        ofdRutaArchivo.FilterIndex = 3
        ofdRutaArchivo.ShowDialog()
        txtArchivoCoppelNiño300.Text = ofdRutaArchivo.FileName
    End Sub

    Private Sub btnExaminarCoppelA203_Click(sender As Object, e As EventArgs) Handles btnExaminarCoppelA203.Click
        ofdRutaArchivo.Reset()
        ofdRutaArchivo.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
        ofdRutaArchivo.Filter = "GRF|*.grf;"
        ofdRutaArchivo.FilterIndex = 3
        ofdRutaArchivo.ShowDialog()
        txtArchivoCoppelAdulto203.Text = ofdRutaArchivo.FileName
    End Sub

    Private Sub btnExaminarCoppelA300_Click(sender As Object, e As EventArgs) Handles btnExaminarCoppelA300.Click
        ofdRutaArchivo.Reset()
        ofdRutaArchivo.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
        ofdRutaArchivo.Filter = "GRF|*.grf;"
        ofdRutaArchivo.FilterIndex = 3
        ofdRutaArchivo.ShowDialog()
        txtArchivoCoppelAdulto300.Text = ofdRutaArchivo.FileName
    End Sub


End Class