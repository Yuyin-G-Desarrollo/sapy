Imports Infragistics.Win.UltraWinGrid

Public Class AltaReportesForm
    Public idReporte As New Int32
    Public Esquema, Nombre, Clave, XML As String
    Public AgregarOEditar As Boolean
    Public activo As Boolean = True
    Dim CamposVacios As Boolean

    Private Sub AltaReportesForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtNombre.Text = Nombre
        txtClave.Text = Clave
        txtEsquema.Text = Esquema

        If activo = False Then
            rdoNo.Checked = True
        Else
            rdoSi.Checked = True
        End If
    End Sub



    ''' <summary>
    ''' VERIFICA SI HAY CAMPOS VACIOS Y ASIGNA VALOR A LA VARIABLE CAMPOSVACIOS
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub verificarCamposVacios()
        Dim FormaError As New ErroresForm
        If AgregarOEditar = True Then
            If txtEsquema.Text = "" Or txtNombre.Text = "" Or txtClave.Text = "" Or txt_archivo.Text = "" Then
                FormaError.mensaje = "Campos vacios"
                FormaError.ShowDialog()
                lblEsquema.ForeColor = Color.Red
                CamposVacios = True
            Else
                CamposVacios = False
            End If


            If txtEsquema.Text = "" Then
                lblEsquema.ForeColor = Color.Red
            Else
                lblEsquema.ForeColor = Color.Black
            End If

            If txtNombre.Text = "" Then
                lblNombre.ForeColor = Color.Red
            Else
                lblNombre.ForeColor = Color.Black
            End If

            If txtClave.Text = "" Then
                lblClave.ForeColor = Color.Red
            Else
                lblClave.ForeColor = Color.Black
            End If

            If txt_archivo.Text = "" Then
                lblArchivo.ForeColor = Color.Red
            Else
                lblArchivo.ForeColor = Color.Black
            End If
        Else
            If txtEsquema.Text = "" Or txtNombre.Text = "" Or txtClave.Text = "" Then
                FormaError.mensaje = "Campos vacios"
                FormaError.ShowDialog()
                lblEsquema.ForeColor = Color.Red
                CamposVacios = True
            Else
                CamposVacios = False
            End If


            If txtEsquema.Text = "" Then
                lblEsquema.ForeColor = Color.Red
            Else
                lblEsquema.ForeColor = Color.Black
            End If

            If txtNombre.Text = "" Then
                lblNombre.ForeColor = Color.Red
            Else
                lblNombre.ForeColor = Color.Black
            End If

            If txtClave.Text = "" Then
                lblClave.ForeColor = Color.Red
            Else
                lblClave.ForeColor = Color.Black
            End If

        End If


    End Sub

    ''' <summary>
    ''' REALIZA LAS ACCIONES NECESARIAS PARA DAR DE ALTA UN REGISTO
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub AgregarRegistro()
        verificarCamposVacios()
        If CamposVacios = False Then
            Try
                Dim ReporteEntidad As New Entidades.Reportes
                Dim OBJBU As New Negocios.ReportesBU
                Dim s_xml As String

                s_xml = My.Computer.FileSystem.ReadAllText(txt_archivo.Text)

                ReporteEntidad.PClavereporte = txtClave.Text
                ReporteEntidad.Pxml = s_xml
                ReporteEntidad.Pnombre = txtNombre.Text
                ReporteEntidad.Pesquema = txtEsquema.Text


                If rdoSi.Checked Then
                    ReporteEntidad.Pactivo = True
                Else
                    ReporteEntidad.Pactivo = False
                End If

                OBJBU.AltaReporte(ReporteEntidad)

                Dim FormularioMensaje As New ExitoForm
                FormularioMensaje.mensaje = "Registro Guardado"
                FormularioMensaje.ShowDialog()
            Catch ex As Exception
                Negocios.ReportesBU.Mostrar(ex)
            End Try
            Me.Close()
        End If

    End Sub


    ''' <summary>
    ''' REALIZA LAS ACCIONES NECESARIAS PARA MODIFICAR UN REGISTRO DE REPORTES
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ModificarRegistro()
        verificarCamposVacios()

        If CamposVacios = False Then
            Dim ReporteEntidad As New Entidades.Reportes

            Dim OBJBU As New Negocios.ReportesBU
            Dim s_xml As String
            If txt_archivo.Text.Length > 0 Then
                s_xml = My.Computer.FileSystem.ReadAllText(txt_archivo.Text)
                ReporteEntidad.Pxml = s_xml
            Else
                ReporteEntidad.Pxml = ""
            End If
            If rdoSi.Checked = True Then
                ReporteEntidad.Pactivo = True
            Else
                ReporteEntidad.Pactivo = False
            End If
            ReporteEntidad.Preporteid = idReporte
            ReporteEntidad.PClavereporte = txtClave.Text
            ReporteEntidad.Pesquema = txtEsquema.Text
            ReporteEntidad.Pnombre = txtNombre.Text

            OBJBU.EditarReporte(ReporteEntidad)
            Dim FormularioMensaje As New ExitoForm
            FormularioMensaje.mensaje = "Registro Actualizado"
            FormularioMensaje.ShowDialog()
            Me.Close()
        End If

    End Sub


    Private Sub btnGuardarDia_Click(sender As Object, e As EventArgs) Handles btnGuardarDia.Click

        If AgregarOEditar = True Then 'DA DE ALTA EL REGISTRO
            AgregarRegistro()

        Else 'MODIFICA EL REGISTRO
            ModificarRegistro()
        End If


    End Sub


    Private Sub btnCancelarDia_Click(sender As Object, e As EventArgs) Handles btnCancelarDia.Click
        Me.Close()
    End Sub

    Private Sub btnBuscarArchivo_Click_1(sender As Object, e As EventArgs) Handles btnBuscarArchivo.Click
        Dim ruta As String = String.Empty
        Dim open As New OpenFileDialog
        Dim OBJBU As New Framework.Negocios.ReportesBU
        With open
            .Filter = "*.mrt|*.mrt"
            .Title = "Seleccionar MRT"
            .ShowDialog()
        End With
        If open.FileName.Trim.Length > 0 Then
        Else
            Exit Sub
        End If
        '-revisar si esta en uso el archivo seleccionado
        If Negocios.ReportesBU.ArchivoEnUso(open.FileName) Then
            MessageBox.Show("El archivo está en uso, debe cerrarlo para poder agregarlo a la base de datos.",
                            "Precaución", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        Me.txt_archivo.Text = open.FileName
    End Sub
End Class