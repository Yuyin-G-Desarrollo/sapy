Public Class AgregarFraccionesArancelariasForm

    Public objFracciones As New Entidades.Fracciones_Arancelarias
    Public Bandera_Agregar_Editar As Boolean ''1 para agregar, 0 para editar
    Dim objAdvertencia As New Tools.AdvertenciaForm


    Private Sub AgregarFraccionesArancelariasForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Bandera_Agregar_Editar = False Then
            txtCodigo.Text = objFracciones.PCodigo
            txtNombre.Text = objFracciones.PNombre
            If objFracciones.PActivo = True Then
                rdoSi.Checked = True
                rdoNo.Checked = False
            Else
                rdoSi.Checked = False
                rdoNo.Checked = True
            End If
        Else
            rdoSi.Checked = True
            rdoSi.Visible = False
            lblActivo.Visible = False
            rdoNo.Visible = False
        End If

    End Sub



    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click

        If ValidarCamposVacios() = True Then Return

        Try
            Agregar_EditarFracciones(objFracciones, Bandera_Agregar_Editar)
        Catch ex As Exception
            Dim objErrores As New Tools.ErroresForm
            objErrores.StartPosition = FormStartPosition.CenterScreen
            objErrores.mensaje = "Ocurrio un error inesperado. Error:" + ex.Message
            objErrores.ShowDialog()
        End Try



    End Sub


    Private Function ValidarCamposVacios() As Boolean

        ValidarCamposVacios = False

        If LTrim(RTrim(txtNombre.Text)) = "" Then
            lblNombre.ForeColor = Color.Red
            ValidarCamposVacios = True
        Else
            lblNombre.ForeColor = Color.Black

        End If

        If LTrim(RTrim(txtCodigo.Text)) = "" Then
            lblCodigo.ForeColor = Color.Red
            ValidarCamposVacios = True
           
        Else
            lblCodigo.ForeColor = Color.Black
        End If

        If ValidarCamposVacios Then
            objAdvertencia.mensaje = "Campos vacios."
            objAdvertencia.StartPosition = FormStartPosition.CenterScreen
            objAdvertencia.ShowDialog()
        End If
        
        Return ValidarCamposVacios
    End Function


    Private Sub Agregar_EditarFracciones(ByVal objFraccion_ar As Entidades.Fracciones_Arancelarias, ByVal bandera_Agr_Edi As Boolean)
        Dim Resultado As String
        Dim Cadena() As String

        objFraccion_ar.PNombre = txtNombre.Text
        objFraccion_ar.PCodigo = txtCodigo.Text
        objFraccion_ar.PActivo = rdoSi.Checked
        
        Dim objBU As New Negocios.CatalogoFraccionesArancelariasBU
        Resultado = objBU.Agregar_Editar_FraccionArancelaria(objFraccion_ar, bandera_Agr_Edi)

        Cadena = Resultado.Split("-")

        If Cadena(0) = "ADVERTENCIA " Then
            Dim objAdvertencia As New Tools.AdvertenciaForm
            objAdvertencia.mensaje = Cadena(1)
            objAdvertencia.StartPosition = FormStartPosition.CenterScreen
            objAdvertencia.ShowDialog()
        ElseIf Cadena(0) = "EXITO " Then
            Dim objExito As New Tools.ExitoForm
            objExito.mensaje = Cadena(1)
            objExito.StartPosition = FormStartPosition.CenterScreen
            objExito.ShowDialog()

            Me.Close()
        Else
            Dim objErrores As New Tools.ErroresForm
            objErrores.StartPosition = FormStartPosition.CenterScreen
            objErrores.mensaje = "Ocurrio un error insesperado, vuelve a intentar guardar la información"
            objErrores.ShowDialog()
        End If

    End Sub


    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Dispose()
    End Sub
End Class