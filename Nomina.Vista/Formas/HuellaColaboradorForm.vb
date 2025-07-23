Imports Entidades
Imports System.Net
Imports Tools
Imports Framework.Negocios
Imports System.Threading

Public Class HuellaColaboradorForm
    Private ColaboradorID As Int32

    Public Property PColaboradorID As Int32
        Get
            Return ColaboradorID
        End Get
        Set(ByVal value As Int32)
            ColaboradorID = value
        End Set
    End Property


    Dim lector As New Tools.FirmaBiometrica
    Dim datos As Entidades.ColaboradorFirmaBiometrica
    Dim imagen As PictureBox
    Dim bandera As Boolean = False
    Dim objBu As New Framework.Negocios.HuellaBU
    Dim ImagenCaptura As PictureBox

    Private Sub HuellaColaboradorForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Timer1.Enabled = False
        Timer2.Enabled = False
    End Sub

    Private Sub CredencialColaboradorForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'If PermisosUsuarioBU.ConsultarPermiso("NOM_COL_CODR", "HISTORIALSALARIOS") Then
        '    btnSalarios.Visible = True
        '    lblSalarios.Visible = True
        'Else
        '    btnSalarios.Visible = False
        '    lblSalarios.Visible = False
        'End If
        txtDepartamento.Text = ""
        txtPuesto.Text = ""
        lblCurp.Text = ""
        lblRFC.Text = ""

        Dim tooltip1, tooltip2 As New ToolTip
        tooltip1.ShowAlways = True
        tooltip2.ShowAlways = True
        tooltip1.SetToolTip(btnRegistrar, "Registrar información de las huellas del colaborador")
        tooltip2.SetToolTip(btnHistorial, "Mostrar historial de registro de huellas del colaborador")

        CargarInformacionGeneral()
        grdBitacora.ReadOnly = True
        pnlRegistrar.Visible = True
        pnlRegistrar.Dock = DockStyle.Fill
        pnlHistorial.Visible = False
    End Sub

    Public Sub CargarInformacionGeneral()
        Dim ObjBU As New Negocios.ColaboradoresBU
        Dim Datos As New Entidades.Colaborador
        Dim ObjBULaboral As New Negocios.ColaboradorLaboralBU
        Dim DatosLabo As New Entidades.ColaboradorLaboral
        Dim ObjArchivosBU As New Negocios.EnviodeArchivosBU
        Dim EntidadArchivos As New Entidades.ColaboradorExpediente

        EntidadArchivos = ObjArchivosBU.CredencialColaborador(ColaboradorID)
        Datos = ObjBU.BuscarColaboradorGeneral(ColaboradorID)
        lblID.Text = ColaboradorID
        txtNombre.Text = Datos.PNombre + " " + Datos.PApaterno + " " + Datos.PAmaterno
        Try
            Dim request = DirectCast(WebRequest.Create("ftp://192.168.7.16"), FtpWebRequest)
            request.Credentials = New NetworkCredential("prod\yuyinerp", "yuyinerp")
            Dim Carpeta As String = ""
            Dim tabla() As String
            tabla = Split(EntidadArchivos.PCarpeta, "\")
            For n = 0 To UBound(tabla, 1)
                Carpeta += tabla(n) + "/"
            Next
            Dim objFTP As New Tools.TransferenciaFTP
            Dim Stream As System.IO.Stream
            Stream = objFTP.StreamFile(Carpeta, EntidadArchivos.PNombreArchivo)
            PictureBox1.Image = Image.FromStream(Stream)
        Catch

        End Try
        Try
            DatosLabo = ObjBULaboral.buscarInformacionLaboral(ColaboradorID)
            If DatosLabo.PNaveId.PNombre.Length > 0 Then
                txtNave.Text = DatosLabo.PNaveId.PNombre.ToUpper
                txtDepartamento.Text = DatosLabo.PDepartamentoId.DNombre.ToUpper
                txtPuesto.Text = DatosLabo.PPuestoId.PNombre.ToUpper
            End If
        Catch ex As Exception

        End Try

        Try
            lblCurp.Text = Datos.pCurp.ToUpper
            lblRFC.Text = Datos.PRfc.ToUpper
            llenarDatosReales()
        Catch ex As Exception

        End Try

        Try
            cargarBitacora()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub cargarBitacora()
        Dim obj As New Framework.Negocios.HuellaBU
        Dim tablaBtacora As DataTable
        tablaBtacora = obj.BitacoraHuella(ColaboradorID)
        If tablaBtacora.Rows.Count > 0 Then
            grdBitacora.DataSource = tablaBtacora
            For Each row As DataRow In tablaBtacora.Rows
                If Not IsDBNull(row.Item("Huella")) Then
                    Select Case row.Item("ManoId")
                        Case 1
                            Select Case row.Item("DedoId")
                                Case 1
                                    imgPulgarDer.SizeMode = PictureBoxSizeMode.StretchImage
                                    imgPulgarDer.Load(My.Application.Info.DirectoryPath & "\huella.jpg")
                                Case 2
                                    imgIndiceDer.SizeMode = PictureBoxSizeMode.StretchImage
                                    imgIndiceDer.Load(My.Application.Info.DirectoryPath & "\huella.jpg")
                                Case 3
                                    imgMedioDer.SizeMode = PictureBoxSizeMode.StretchImage
                                    imgMedioDer.Load(My.Application.Info.DirectoryPath & "\huella.jpg")
                                Case 4
                                    imgAnularDer.SizeMode = PictureBoxSizeMode.StretchImage
                                    imgAnularDer.Load(My.Application.Info.DirectoryPath & "\huella.jpg")
                                Case 5
                                    imgMeñiqueDer.SizeMode = PictureBoxSizeMode.StretchImage
                                    imgMeñiqueDer.Load(My.Application.Info.DirectoryPath & "\huella.jpg")
                                Case Else

                            End Select
                        Case 2
                            Select Case row.Item("DedoId")
                                Case 1
                                    imgPulgarIzq.SizeMode = PictureBoxSizeMode.StretchImage
                                    imgPulgarIzq.Load(My.Application.Info.DirectoryPath & "\huella.jpg")
                                Case 2
                                    imgIndiceIzq.SizeMode = PictureBoxSizeMode.StretchImage
                                    imgIndiceIzq.Load(My.Application.Info.DirectoryPath & "\huella.jpg")
                                Case 3
                                    imgMedioIzq.SizeMode = PictureBoxSizeMode.StretchImage
                                    imgMedioIzq.Load(My.Application.Info.DirectoryPath & "\huella.jpg")
                                Case 4
                                    imgAnularIzq.SizeMode = PictureBoxSizeMode.StretchImage
                                    imgAnularIzq.Load(My.Application.Info.DirectoryPath & "\huella.jpg")
                                Case 5
                                    imgMeñiqueIzq.SizeMode = PictureBoxSizeMode.StretchImage
                                    imgMeñiqueIzq.Load(My.Application.Info.DirectoryPath & "\huella.jpg")
                                Case Else

                            End Select
                        Case Else
                    End Select
                End If
            Next
            diseñoBitacora()
        End If
    End Sub

    Private Sub diseñoBitacora()
        grdBitacora.Columns.Item("Huella").Visible = False
        grdBitacora.Columns.Item("ManoId").Visible = False
        grdBitacora.Columns.Item("DedoId").Visible = False
    End Sub

    Public Sub llenarDatosReales()
        Dim objBU As New Negocios.ColaboradorRealBU
        Dim EntidadesReal As New Entidades.ColaboradorReal
        Dim anios As Int32 = 0
        Dim meses As Int32 = 0
        Dim diasme As Int32 = 0
        Dim Diastrabajados As Int32

        EntidadesReal = objBU.BuscarColaboradorReal(ColaboradorID)
        Dim Fecha As New Date
        Try
            If EntidadesReal.PFecha = CDate("01/01/0001") Then
                Diastrabajados = 0
            Else
                Diastrabajados = DateDiff("y", EntidadesReal.PFecha.ToShortDateString, Date.Today)
            End If

            anios = Diastrabajados \ 365
            meses = (Diastrabajados Mod 365) \ 30.4
            diasme = (Diastrabajados Mod 365) Mod 30.4
            lblAntiguedadCabeceras.Text = anios.ToString + " AÑOS " + meses.ToString + "  MESES "

        Catch ex As Exception

        End Try
    End Sub

    Private Sub leerHuella(ByVal mano As Int32, ByVal dedo As Int32, imagen As PictureBox, ByVal manoMensaje As String, ByVal dedoMensaje As String)
        Dim lista As New List(Of ColaboradorFirmaBiometrica)
        Dim mensaje As AdvertenciaForm
        If bandera = True Then
            mensaje = New AdvertenciaForm
            mensaje.mensaje = "Ya existe un proceso activo de Captura"
            mensaje.Show()
        Else
            datos = New ColaboradorFirmaBiometrica
            datos.PcolaboradorId = ColaboradorID
            datos.Pdedo = dedo
            datos.Pmano = mano
            datos.PusuarioCreo = SesionUsuario.UsuarioSesion.PUserUsuarioid
            'Dim huellas As DataTable
            'huellas = objBu.buscarHuella(ColaboradorID, mano, dedo)
            'If huellas.Rows.Count > 0 Then
            '    Timer2.Enabled = True
            '    bandera = True
            ListaEmpleados()
            'Else
            'End If
            If imagen.Image Is Nothing Then
                Dim mens = New AvisoForm
                Timer1.Enabled = True
                'Timer2.Enabled = True
                ImagenCaptura = imagen
                lector.leerHuella(datos, imagen, lblRegistros)
                mens.mensaje = "Registrar 4 veces la huella del " & dedoMensaje & " " & manoMensaje
                mens.Show()
                bandera = True
                lblRegistros = lector.etiqueta
                imagen = lector.imagenP
            Else
                mensaje = New AdvertenciaForm
                mensaje.mensaje = "Ya existe una huella registrada de este dedo"
                mensaje.Show()
            End If
        End If
    End Sub

    Private Sub ListaEmpleados()
        Dim objBu As New Framework.Negocios.HuellaBU
        Dim lista As List(Of ColaboradorFirmaBiometrica)
        lista = objBu.empleadosNaves()
        MessageBox.Show("Lista cargada, Comienze la lectura")
        lector.validarHuella(lista)
    End Sub

    Private Sub btnHistorial_Click(sender As Object, e As EventArgs) Handles btnHistorial.Click
        pnlHistorial.Dock = DockStyle.Fill
        pnlHistorial.Visible = True
        pnlRegistrar.Dock = DockStyle.None
        pnlRegistrar.Visible = False
        cargarBitacora()
    End Sub

    Private Sub btnRegistrar_Click(sender As Object, e As EventArgs) Handles btnRegistrar.Click
        pnlRegistrar.Dock = DockStyle.Fill
        pnlRegistrar.Visible = True
        pnlHistorial.Dock = DockStyle.None
        pnlHistorial.Visible = False
    End Sub

    Private Sub imgMeñiqueIzq_Click(sender As Object, e As EventArgs) Handles imgMeñiqueIzq.Click
        leerHuella(2, 5, imgMeñiqueIzq, "Izquierdo", "Meñique")
    End Sub

    Private Sub imgAnularIzq_Click(sender As Object, e As EventArgs) Handles imgAnularIzq.Click
        leerHuella(2, 4, imgAnularIzq, "Izquierdo", "Anular")
    End Sub

    Private Sub imgMedioIzq_Click(sender As Object, e As EventArgs) Handles imgMedioIzq.Click
        leerHuella(2, 3, imgMedioIzq, "Izquierdo", "Medio")
    End Sub

    Private Sub imgIndiceIzq_Click(sender As Object, e As EventArgs) Handles imgIndiceIzq.Click
        leerHuella(2, 2, imgIndiceIzq, "Izquierdo", "Indice")
    End Sub

    Private Sub imgPulgarIzq_Click(sender As Object, e As EventArgs) Handles imgPulgarIzq.Click
        leerHuella(2, 1, imgPulgarIzq, "Izquierdo", "Pulgar")
    End Sub

    Private Sub imgPulgarDer_Click(sender As Object, e As EventArgs) Handles imgPulgarDer.Click
        leerHuella(1, 1, imgPulgarDer, "Derecho", "Pulgar")
    End Sub

    Private Sub imgIndiceDer_Click(sender As Object, e As EventArgs) Handles imgIndiceDer.Click
        leerHuella(1, 2, imgIndiceDer, "Derecho", "Indice")
    End Sub

    Private Sub imgMedioDer_Click(sender As Object, e As EventArgs) Handles imgMedioDer.Click
        leerHuella(1, 3, imgMedioDer, "Derecho", "Medio")
    End Sub

    Private Sub imgAnularDer_Click(sender As Object, e As EventArgs) Handles imgAnularDer.Click
        leerHuella(1, 4, imgAnularDer, "Derecho", "Anular")
    End Sub

    Private Sub imgMeñiqueDer_Click(sender As Object, e As EventArgs) Handles imgMeñiqueDer.Click
        leerHuella(1, 5, imgMeñiqueDer, "Derecho", "Meñique")
    End Sub

    Private Sub BackgroundWorker1_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles BackgroundWorker1.Disposed
        BackgroundWorker1.CancelAsync()
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        If lector.banderaInsertar Then
            Dim mensaje As New ExitoForm
            mensaje.mensaje = "Debera confirmar una vez mas la huella"
            'objBu.insertarHuella(datos.PcolaboradorId, datos.Pmano, datos.Pdedo, datos.PusuarioCreo, lector.empleado.Phuella, lector.empleado.PdedoLibreria)
            lector.banderaInsertar = False
            'mensaje.mensaje = "Registro Realizado"
            'bandera = False
            mensaje.ShowDialog()
            lector.IniciarValidacion()
            'Timer2.Enabled = True
            'bandera = True
            'Timer1.Enabled = False
        ElseIf lector.banderaValidar = 1 Then
            lector.banderaValidar = 0
            Dim ObjBU As New Negocios.ColaboradoresBU
            Dim Datos As New Entidades.Colaborador
            Dim mensaje As New AdvertenciaForm
            Datos = ObjBU.BuscarColaboradorGeneral(CInt(lector.empleado.PcolaboradorId.ToString))
            mensaje.mensaje = "Colaborador encontrado " & lector.empleado.PcolaboradorId & ", " & Datos.PNombre + " " + Datos.PApaterno + " " + Datos.PAmaterno & ". No se registrara esta huella"
            mensaje.ShowDialog()
            Me.Button1_Click(sender, e)
            'lector.CancelarLectura()
            'lblRegistros.Text = ""
            'ImagenCaptura.Image = Nothing
            bandera = False
            'lector.TerminarValidacion()
        ElseIf lector.banderaValidar = 2 Then
            Dim mensaje As New AdvertenciaForm
            Dim mensaje2 As New ExitoForm
            lector.banderaValidar = 0
            mensaje.mensaje = "No existe conincidencia o No esta registrado, Se registrara la Huella"
            bandera = False
            mensaje.ShowDialog()
            objBu.insertarHuella(datos.PcolaboradorId, datos.Pmano, datos.Pdedo, datos.PusuarioCreo, lector.empleado.Phuella, lector.empleado.PdedoLibreria)
            mensaje2.mensaje = "Registro Realizado"
            mensaje2.ShowDialog()
            lector.CancelarLectura()
            lector.TerminarValidacion()
        End If
        BackgroundWorker1.Dispose()

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If BackgroundWorker1.IsBusy Then
            BackgroundWorker1.CancelAsync()
        Else
            BackgroundWorker1.RunWorkerAsync()
        End If
    End Sub

    Private Sub BackgroundWorker2_Disposed(sender As Object, e As EventArgs) Handles BackgroundWorker2.Disposed
        BackgroundWorker2.CancelAsync()
    End Sub

    Private Sub BackgroundWorker2_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker2.DoWork
        Timer1.Enabled = False
        If lector.banderaValidar = 1 Then
            lector.banderaValidar = 0
            Dim ObjBU As New Negocios.ColaboradoresBU
            Dim Datos As New Entidades.Colaborador
            Dim mensaje As New ExitoForm
            datos = ObjBU.BuscarColaboradorGeneral(CInt(lector.empleado.PcolaboradorId.ToString))
            mensaje.mensaje = "Colaborador encontrado " & lector.empleado.PcolaboradorId & ", " & Datos.PNombre + " " + Datos.PApaterno + " " + Datos.PAmaterno
            bandera = False
            mensaje.ShowDialog()
        ElseIf lector.banderaValidar = 2 Then
            Dim mensaje As New AdvertenciaForm
            lector.banderaValidar = 0
            mensaje.mensaje = "No existe conincidencia o No esta registrado "
            bandera = False
            objBu.insertarHuella(datos.PcolaboradorId, datos.Pmano, datos.Pdedo, datos.PusuarioCreo, lector.empleado.Phuella, lector.empleado.PdedoLibreria)
            mensaje.ShowDialog()
        End If
        BackgroundWorker2.Dispose()
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        If BackgroundWorker2.IsBusy Then
            BackgroundWorker2.CancelAsync()
        Else
            BackgroundWorker2.RunWorkerAsync()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        lector.CancelarLectura()
        lector.TerminarValidacion()
        lblRegistros.Text = ""
        ImagenCaptura.Image = Nothing
        bandera = False
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        lector.TerminarValidacion()
    End Sub
End Class