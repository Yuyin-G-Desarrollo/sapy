Imports System.Windows.Forms

Public Class AltaEdicion_Empresa_SayForm

    Public Agregar_Editar_Empresa As Boolean
    Public Empresa As New Entidades.Empresa
    Private CamposVacios As Boolean = False

    Private Sub AltaEdicion_Empresa_SayForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Empresa.Pempr_empresaid <> 0 Then
            txtRazonSocial.Text = Empresa.Pempr_nombre
            txtRFC.Text = Empresa.PRFCEmpresa
            numTasaIva.Value = Empresa.PTasaIva
            numTasaIVAEnEncabezado.Value = Empresa.PTasaIvaEncabezado
            chkActivo.Checked = Empresa.Pempr_activo
            chkActivo.Enabled = True
        End If

    End Sub

    ''' <summary>
    ''' EVENTO KEYPRESS PARA INHABILITAR LA ESCRITURA DE CARACTERES QUE NO SEAN NUMERICOS O ALFABETICOS EN EL TEXTBOX "TXTRFC"
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub txtRFC_KeyPress(sender As Object, e As Windows.Forms.KeyPressEventArgs) Handles txtRFC.KeyPress
        If (Char.IsLetterOrDigit(e.KeyChar)) Or (e.KeyChar = ChrW(Keys.Back)) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    ''' <summary>
    ''' EVENTO CLICK EN EL BOTÓN "BTNGUARDAR" PARA GUARDAR LA INFORMACIÓN
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        ValidarCamposVacios()

        If CamposVacios = True Then
            Dim objAdvertencia As New Tools.AdvertenciaForm
            objAdvertencia.mensaje = "Existen campos sin llenar."
            objAdvertencia.StartPosition = FormStartPosition.CenterScreen
            objAdvertencia.ShowDialog()
        Else
            Dim objBU As New Negocios.EmpresaSAY_SICY_ContpaqBU

            Empresa.Pempr_activo = chkActivo.Checked
            Empresa.Pempr_nombre = txtRazonSocial.Text
            Empresa.PRFCEmpresa = txtRFC.Text
            Empresa.PTasaIva = numTasaIva.Value
            Empresa.PTasaIvaEncabezado = numTasaIVAEnEncabezado.Value

            objBU.Alta_Edicion_EmpresaSAY(Empresa, Agregar_Editar_Empresa)

        End If

    End Sub

    ''' <summary>
    ''' METODO PARA VALIDAR QUE NO EXISTAN CAMPOS OBLIGATORIOS SIN SER LLENADOS, SI ES EL CASO PERMITE GUARDAR LA INFORMACIÓN,
    ''' DE LO CONTRARIO NO PERMITIRA GUARDAR HASTA QUE LOS CAMPOS OBLIGATORIOS ESTEN LLENOS EN SU TOTALIDAD.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ValidarCamposVacios()
        CamposVacios = False

        If txtRazonSocial.Text = "" Then
            CamposVacios = True
            lblRazonSocial.ForeColor = Drawing.Color.Red
        Else
            lblRazonSocial.ForeColor = Drawing.Color.Black
        End If

        If txtRFC.Text = "" Then
            CamposVacios = True
            lblRFC.ForeColor = Drawing.Color.Red
        Else
            lblRFC.ForeColor = Drawing.Color.Black
        End If

    End Sub

    ''' <summary>
    ''' EVENTO CLICK EN EL BOTÓN "BTNCERRAR" PARA CERRAR LA VENTANA
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub
End Class