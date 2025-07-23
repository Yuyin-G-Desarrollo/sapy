Imports Entidades
Imports Produccion.Negocios
Imports Tools

Public Class AltaDocumentosProduccion_Form
    Public vEstiloId As String
    Public vEsDepto As Boolean = True
    Public vDocumento As String = String.Empty
    Public vTipoDocumento As String = String.Empty
    Public vIdCategoria As Integer
    Public vIdArchivo As Integer
    Public vNombreDocumento As String = String.Empty
    Public vAdmonArchivosProduc As AdministradorArchivosProduccion
    Public vAdmonArchivos As AdministradorArchivosForm
    Public vAdmonArchivosTecnicos As AdministradorArchivosTecnicosForm
    Public vIdNave As Integer?

    Private Sub AltaDocumentosProduccion_Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargaComboCategorias()

        If vEsDepto = True Then
            lblDepto.Visible = True
            lblCategoria.Visible = False
        Else
            lblCategoria.Visible = True
            lblDepto.Visible = False
        End If

        If vIdArchivo <> Nothing Then
            lblAlta.Visible = False
            lblEditar.Visible = True
            txtNombre.Enabled = False
            txtNombre.Text = vNombreDocumento
            txtNombre.BackColor = Color.LightGray
            cmbCategorias.SelectedValue = vIdCategoria
            Me.Text = "Editar Archivos"
        Else
            lblAlta.Visible = True
            lblEditar.Visible = False
            txtNombre.Enabled = True
            Me.Text = "Alta Archivos"
        End If

    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim obj As New AdministradorArchivosBU
        Dim obA As New TransferenciaFTP
        Dim vRuta As String = String.Empty
        Dim dtTabla As DataTable
        Dim confirmar As New Tools.ConfirmarForm
        Dim NombreTipo() As String = Nothing
        Dim n As Integer

        If vEsDepto = True Then
            vRuta = "Produccion/FichasTecnicas"
        Else
            vRuta = "Produccion/OtrosArchivos"
        End If

        NombreTipo = txtArchivo.Text.Split("\")
        n = NombreTipo.Count - 1

        If txtArchivo.Text <> "" And txtNombre.Text <> "" And cmbCategorias.Text <> "" Then
            Try
                If vEstiloId <> Nothing Then
                    Dim vXml As XElement = XElement.Parse(vEstiloId)
                    Dim vIdEstilo As List(Of Integer) = New List(Of Integer)
                    For Each item In vXml.Elements("ESTILO")
                        vIdEstilo.Add(Integer.Parse(item.Attribute("idEstilo").Value))
                    Next
                End If

                dtTabla = obj.ObtieneArchivo(vEstiloId, txtNombre.Text, IIf(vEsDepto = True, False, True), vIdNave, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)

                If dtTabla.Rows.Count > 0 And vIdArchivo = Nothing Then
                    Dim FormaError As New ErroresForm
                    FormaError.mensaje = "Ya existe un archivo con ese nombre"
                    FormaError.ShowDialog()
                Else

                    dtTabla = obj.ObtenerArchivosExistentes(vEstiloId, txtNombre.Text, IIf(vEsDepto = True, False, True), vIdNave)

                    If dtTabla.Rows.Count > 0 Then
                        confirmar.mensaje = "Uno o más artículos contienen archivos con ese nombre ¿Desea remplazarlos? "

                        If confirmar.ShowDialog() = Windows.Forms.DialogResult.OK Then
                            GuardarArchivo(dtTabla.Rows(0).Item("XML_ESTILOS"), vRuta, NombreTipo)
                        End If
                    Else
                        GuardarArchivo(Nothing, vRuta, NombreTipo)
                    End If
                End If

            Catch ex As Exception
                Dim FormaError As New ErroresForm
                FormaError.mensaje = "Error"
                FormaError.ShowDialog()
                obA.BorraArchivo(vRuta, NombreTipo(n))

            End Try
            Me.Close()
        Else
            Dim FormaError As New ErroresForm
            FormaError.mensaje = "Campos vacios"
            FormaError.ShowDialog()
        End If
    End Sub

    Private Sub GuardarArchivo(ByVal pXml As String, ByVal pRuta As String, ByVal pNombreTipo() As String)
        Dim obj As New AdministradorArchivosBU
        Dim obA As New TransferenciaFTP
        Dim vNewDoc As String = String.Empty
        Dim vTabla As New DataTable
        Dim n As Integer

        n = pNombreTipo.Count - 1
        obA.EnviarArchivo(pRuta, txtArchivo.Text)

        If vIdArchivo <> Nothing Then
            obA.BorraArchivo(pRuta, vDocumento + vTipoDocumento)
            Dim Nombre() As String = pNombreTipo(n).Split(".")
            vNewDoc = obj.ActualizarArchivo(vIdArchivo, IIf(vEsDepto = True, vDocumento, Nombre(0)), pNombreTipo(n), cmbCategorias.SelectedValue, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, Entidades.SesionUsuario.UsuarioSesion.PUserUsername)
        Else
            vTabla = obj.GuardarArchivo(vEstiloId, txtNombre.Text, pNombreTipo(n), pNombreTipo(n), cmbCategorias.SelectedValue, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, Entidades.SesionUsuario.UsuarioSesion.PUserUsername, IIf(vEsDepto = True, False, True), Entidades.SesionUsuario.UsuarioSesion.PIDColaboradorUser, vIdNave, pXml)
        End If

        If vTabla.Rows.Count > 0 Then
            obA.RenombraArchivo(pRuta, pNombreTipo(n), IIf(vEsDepto = True, vTabla.Rows(0).Item("NewNombre"), pNombreTipo(n)))

            If (vTabla.Rows(0).Item("FgEliminaArchivo") = True) Then
                obA.BorraArchivo(pRuta, vTabla.Rows(0).Item("NombreArchivoEliminar"))
            End If

        Else
            obA.RenombraArchivo(pRuta, pNombreTipo(n), IIf(vEsDepto = True, vNewDoc, pNombreTipo(n)))
        End If

        Dim FormularioMensaje As New ExitoForm
        FormularioMensaje.mensaje = "Registro Guardado"
        FormularioMensaje.ShowDialog()

    End Sub

    Private Sub btnSelectorArchivo_Click(sender As Object, e As EventArgs) Handles btnSelectorArchivo.Click
        Dim ruta As String = String.Empty
        Dim open As New OpenFileDialog
        Dim OBJBU As New AdministradorArchivosBU
        With open
            .ShowDialog()
        End With
        If open.FileName.Trim.Length > 0 Then
        Else
            Exit Sub
        End If
        If OBJBU.ArchivoEnUso(open.FileName) Then
            MessageBox.Show("El archivo está en uso, debe cerrarlo para poder agregarlo a la base de datos.",
                            "Precaución", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        txtArchivo.Text = open.FileName
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub CargaComboCategorias()
        Dim objBUCombos As New AdministradorArchivosBU
        Dim dtCategorias As New DataTable

        dtCategorias = objBUCombos.ObtenerCategoriasDeptos(vEsDepto)

        Dim vNum As Integer = dtCategorias.Rows.Count() + 1

        If vEsDepto = False Then
            dtCategorias.Rows.Add(New Object() {vNum, "NUEVA CATEGORÍA", False})
        Else
            dtCategorias.Rows.Add(New Object() {vNum, "NUEVO DEPARTAMENTO", False})
        End If

        dtCategorias.Rows.InsertAt(dtCategorias.NewRow, 0)

        cmbCategorias.DataSource = dtCategorias
        cmbCategorias.DisplayMember = "NombreCategoria"
        cmbCategorias.ValueMember = "idCategoria"
        cmbCategorias.SelectedIndex = 0
    End Sub

    Private Sub cmbCategorias_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCategorias.SelectedIndexChanged

        If cmbCategorias.Text = "NUEVA CATEGORÍA" Or cmbCategorias.Text = "NUEVO DEPARTAMENTO" Then

            Dim form As New AdministradorArchivos_GuardarCategoria_Departamento
            form.vEsDepto = vEsDepto
            form.VentanaAltaArchivos = Me
            form.ShowDialog()

        End If
    End Sub

    Public Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        CargaComboCategorias()
    End Sub

    Private Sub AltaDocumentosProduccion_Form_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        If vAdmonArchivos IsNot Nothing Then
            vAdmonArchivos.btnMostrar_Click(Nothing, Nothing)
        ElseIf vAdmonArchivosProduc IsNot Nothing Then
            vAdmonArchivosProduc.btnMostrar_Click(Nothing, Nothing)
        Else
            vAdmonArchivosTecnicos.CargarDatos()
        End If
    End Sub
End Class