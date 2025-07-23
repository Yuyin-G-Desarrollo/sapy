Imports System.Windows.Forms
Imports System.Xml

Public Class ReportePolizasPeriodo
    Dim rfc As String

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Dim objBU As New Contabilidad.Negocios.ContabilidadElectronicaBU
        Dim resultado As String = String.Empty


        If validacionCampos() Then
            'Dim avisoForm As New Tools.AvisoForm
            'avisoForm.mensaje = "El proceso de generación del reporte puede tardar uno o varios minutos dependiendo de la cantidad de pólizas y comprobantes."
            'avisoForm.ShowDialog()

            Me.Cursor = Cursors.WaitCursor

            resultado = objBU.ConstruyeXmlPolizasPeriodo(cmbEmpresa.SelectedValue, cmbMeses.SelectedItem.ToString, cmbAnios.SelectedItem.ToString, txtRuta.Text, rfc, cmbTipoSolicitud.SelectedItem, txtNoOrden.Text)

            If resultado.Length = 0 Then
                Dim exitoForm As New Tools.ExitoForm
                exitoForm.mensaje = "Reporte generado correctamente"
                exitoForm.ShowDialog()
            Else
                Dim advertencia As New Tools.AdvertenciaForm
                advertencia.mensaje = resultado
                advertencia.ShowDialog()
            End If
            cmbEmpresa.SelectedIndex = 0
            cmbAnios.SelectedIndex = 0
            cmbMeses.SelectedIndex = 0
            cmbTipoSolicitud.SelectedIndex = 0
            txtNoOrden.Text = ""
            txtRuta.Text = ""

        End If

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub ReportePolizasPeriodo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargaCombos()
    End Sub

    Public Function validacionCampos() As Boolean
        Dim resultado As Boolean = True
        If cmbEmpresa.SelectedIndex = 0 Then
            lblEmpresa.ForeColor = Drawing.Color.Red
            resultado = False
        Else
            lblEmpresa.ForeColor = Drawing.Color.Black
        End If

        If cmbAnios.SelectedIndex = 0 Then
            lblEjercicio.ForeColor = Drawing.Color.Red
            resultado = False
        Else
            lblEjercicio.ForeColor = Drawing.Color.Black
        End If

        If cmbMeses.SelectedIndex = 0 Then
            lblPeriodo.ForeColor = Drawing.Color.Red
            resultado = False
        Else
            lblPeriodo.ForeColor = Drawing.Color.Black
        End If

        If txtRuta.Text.Trim.Length = 0 Then
            lblRuta.ForeColor = Drawing.Color.Red
            resultado = False
        Else
            lblRuta.ForeColor = Drawing.Color.Black
        End If

        If cmbTipoSolicitud.SelectedIndex = 0 Then
            lblTipoSolicitud.ForeColor = Drawing.Color.Red
            resultado = False
        Else
            lblTipoSolicitud.ForeColor = Drawing.Color.Black
        End If

        Return resultado
    End Function

    Public Sub cargaCombos()
        Dim altpoliBU As New Negocios.AltaPolizaBU
        Dim cbempresasContpaq As New DataTable

        cbempresasContpaq = altpoliBU.CargaEmpresaCONTPAQ(Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid.ToString)
        cbempresasContpaq.Rows.InsertAt(cbempresasContpaq.NewRow(), 0)
        cmbEmpresa.DataSource = cbempresasContpaq

        cmbEmpresa.ValueMember = "essc_sayid"
        cmbEmpresa.DisplayMember = "RazonSocial"
    End Sub

    Private Sub btnExaminar_Click(sender As Object, e As EventArgs) Handles btnExaminar.Click
        Dim altpoliBU As New Negocios.AltaPolizaBU
        Dim cbempresas As New DataTable
        cbempresas = altpoliBU.BuscaEmpresaSAY(cmbEmpresa.SelectedValue)
        For Each fila As DataRow In cbempresas.Rows
            rfc = fila.Item("empr_rfc").ToString.Replace("-", "")
        Next

        svfRuta.Filter = "XML files (*.xml)|*.xml"
        svfRuta.Title = "Guardar Reporte de Pólizas"
        svfRuta.FileName = rfc + cmbAnios.SelectedItem.ToString + cmbMeses.SelectedItem.ToString + "PL.xml"
        If svfRuta.ShowDialog() = DialogResult.OK Then
            txtRuta.Text = svfRuta.FileName
        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim myXmlTextWriter As XmlTextWriter = New XmlTextWriter("C:\Users\SISTEMAS6\Desktop\ejemplo.xml", System.Text.Encoding.UTF8)
        myXmlTextWriter.Formatting = System.Xml.Formatting.Indented
        myXmlTextWriter.WriteStartDocument(False)

        ''
        myXmlTextWriter.WriteStartElement("PLZ:Cheque")
        myXmlTextWriter.WriteAttributeString("ctaOri", "1234")
        myXmlTextWriter.WriteAttributeString("banco", "030")
        myXmlTextWriter.WriteAttributeString("banco", "030")
        myXmlTextWriter.WriteEndElement() 'fin cheque

        ''
        myXmlTextWriter.Flush()
        myXmlTextWriter.Close()

    End Sub
End Class