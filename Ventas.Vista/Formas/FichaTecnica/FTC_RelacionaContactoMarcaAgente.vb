Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win

Public Class FTC_RelacionaContactoMarcaAgente

    Public Bandera As Integer ''2 VENTAS, 7, DATOS
    Public objCorreo As New Entidades.Email
    Public objPersona As New Entidades.Persona
    Public objClasificacionPersona As New Entidades.ClasificacionPersona
    Public ClienteId As Integer

    Private Sub FTC_RelacionaContactoMarcaAgente_Load(sender As Object, e As EventArgs) Handles MyBase.Load

            txtContacto.Text = objCorreo.persona.nombre
            txtEmail.Text = objCorreo.email
            ComboAgentes_Marcas()



    End Sub


#Region "ACCIONES COMBO"

    ''' <summary>
    ''' RECUPERA LA LISTA DE LOS AGENTES ASIGNADOS A UN CLIENTE EN ESPECIFICO Y LA ASIGNA AL DATASOURCE DEL COMBOBOX CMBAGENTESVENTAS
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ComboAgentes_Marcas()
        Dim ClientesDatosBU As New Negocios.ClientesDatosBU
        Dim dtMarcaVendedorEmpresa As New DataTable

        dtMarcaVendedorEmpresa = ClientesDatosBU.ListaAgentes_de_cliente(ClienteId)

        dtMarcaVendedorEmpresa.Rows.InsertAt(dtMarcaVendedorEmpresa.NewRow, 0)

        cmbAgentesVentas.DataSource = dtMarcaVendedorEmpresa
        cmbAgentesVentas.DisplayMember = "AGENTE DE VENTAS"
        cmbAgentesVentas.ValueMember = "ID"

        If dtMarcaVendedorEmpresa.Rows.Count > 0 Then
            cmbAgentesVentas.SelectedIndex = 1
        End If
    End Sub


    Private Sub cmbAgentesVentas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbAgentesVentas.SelectedIndexChanged
        If cmbAgentesVentas.SelectedIndex > 0 Then
            chkMarcas.Checked = True
            PoblarGridContactoMarcaAgente(ClienteId, cmbAgentesVentas.SelectedValue)
        Else
            grdContactoMarcaAgente.DataSource = Nothing
        End If

    End Sub


#End Region

#Region "GRID"

    ''' <summary>
    ''' CONSULTA LA INFORMACION DE LAS MARCAS DE UN AGENTE ASIGNADOS A UN CLIENTE EN ESPECIFICO Y LA TABLA CON LA INFORMACION RECUPERADA
    ''' LA ASIGNA AL DATASOURCE DEL GRID 'GRDCONTACTOMARCAAGENTE'
    ''' </summary>
    ''' <param name="IdClienteSay">ID DEL CLIENTE DEL CUAL SE RECUPERARA LA INFORMACION</param>
    ''' <param name="IdAgente">ID DEL AGENTE DEL CUAL SE RECUPERARAN LAS MARCAS ASIGNADAS PARA EL AGENTE Y PARA EL CLIENTE EN CUESTION</param>
    ''' <remarks></remarks>
    Private Sub PoblarGridContactoMarcaAgente(ByVal IdClienteSay As Integer, ByVal IdAgente As Integer)
        Dim objBU As New Negocios.ClientesDatosBU
        Dim dtTablaGrid As New DataTable

        dtTablaGrid = objBU.ListaMarcas_De_Agente_de_cliente(IdClienteSay, IdAgente)

        grdContactoMarcaAgente.DataSource = dtTablaGrid
    End Sub


    Private Sub grdContactoMarcaAgente_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdContactoMarcaAgente.InitializeLayout

        With grdContactoMarcaAgente
            .DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
            .DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
            .DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            .DisplayLayout.Override.RowSelectorWidth = 35
            .DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
            .DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True
            .DisplayLayout.Override.AllowAddNew = AllowAddNew.No

            .DisplayLayout.Bands(0).Columns("ID").Hidden = True

            .DisplayLayout.Bands(0).Columns("MARCA").CellActivation = Activation.NoEdit
            .DisplayLayout.Bands(0).Columns(" ").CellActivation = Activation.AllowEdit
            .DisplayLayout.Bands(0).Columns(" ").CellActivation = Activation.AllowEdit
            .DisplayLayout.Bands(0).Columns("ACTIVO").CellActivation = Activation.AllowEdit
        End With
    End Sub


    Private Sub grdContactoMarcaAgente_ClickCell(sender As Object, e As ClickCellEventArgs) Handles grdContactoMarcaAgente.ClickCell

        If Not Me.grdContactoMarcaAgente.ActiveRow.IsDataRow Then Return

        If IsNothing(grdContactoMarcaAgente.ActiveRow) Then Return

        If grdContactoMarcaAgente.ActiveRow.Cells(" ").IsActiveCell Then
            If grdContactoMarcaAgente.ActiveRow.Cells(" ").Value = True Then
                grdContactoMarcaAgente.ActiveRow.Cells(" ").Value = False
            Else
                grdContactoMarcaAgente.ActiveRow.Cells(" ").Value = True
            End If
        End If

    End Sub

#End Region

    Private Sub chkMarcas_CheckedChanged(sender As Object, e As EventArgs) Handles chkMarcas.CheckedChanged
        For Each ROW As UltraGridRow In grdContactoMarcaAgente.Rows
            ROW.Cells(" ").Value = chkMarcas.Checked
        Next

    End Sub



#Region "BOTONES"
    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim objDatosCliente As New Negocios.ClientesDatosBU
        Dim objConfirmar As New Tools.ConfirmarForm
        Dim idsMarcaAgente As String
        Dim objBU As New Negocios.ClientesDatosBU
        Dim Resultado As String
        Dim objExito As New Tools.ExitoForm
        Dim objErrores As New Tools.ErroresForm

        If ValidarCamposVacios() = True Then Return

        objConfirmar.StartPosition = FormStartPosition.CenterScreen
        objConfirmar.mensaje = "¿ Desea relacionar el contacto con la(s) marca(s) seleccionada(s)?"

        If objConfirmar.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Me.Cursor = Cursors.WaitCursor
            btnGuardar.Enabled = False
            Try

                For Each row As UltraGridRow In grdContactoMarcaAgente.Rows
                    If row.Cells(" ").Value = True Then
                        If idsMarcaAgente = String.Empty Then
                            idsMarcaAgente = CStr(row.Cells("ID").Value)
                        Else
                            idsMarcaAgente += ", " + CStr(row.Cells("ID").Value)
                        End If
                    End If
                Next


                If Bandera = 2 Then

                    Resultado = objBU.RelacionarContactoMarcaAgente(Bandera, txtEmail.Text, objCorreo.emailpersonasid, txtContacto.Text, objCorreo.persona.personaid, idsMarcaAgente, ClienteId)

                    If Resultado = "EXITO" Then
                        objExito.mensaje = "Contacto(s) – marca(s) – agente(s) relacionados con éxito."
                        objExito.StartPosition = FormStartPosition.CenterScreen
                        objExito.ShowDialog()
                    Else
                        Me.Cursor = Cursors.Default
                        btnGuardar.Enabled = True

                        objErrores.mensaje = "Ocurrio un error al momento de guardar, por favor intenta guardar de nuevo"
                        objErrores.StartPosition = FormStartPosition.CenterScreen
                        objErrores.ShowDialog()

                        Return
                    End If
                ElseIf Bandera = 7 Then
                    Resultado = objBU.RelacionarContactoMarcaAgente(Bandera, txtEmail.Text, objCorreo.emailpersonasid, txtContacto.Text, objCorreo.persona.personaid, idsMarcaAgente, ClienteId)
                    If Resultado = "EXITO" Then
                        objExito.mensaje = "Contacto pedidos agregado y Contacto(s) – marca(s) – agente(s) relacionados con éxito."
                        objExito.StartPosition = FormStartPosition.CenterScreen
                        objExito.ShowDialog()
                    Else
                        Me.Cursor = Cursors.Default
                        btnGuardar.Enabled = True

                        objErrores.mensaje = "Ocurrio un error al momento de guardar, por favor intenta guardar de nuevo"
                        objErrores.StartPosition = FormStartPosition.CenterScreen
                        objErrores.ShowDialog()

                        Return
                    End If
                End If

                Me.Close()
            Catch ex As Exception

                objErrores.StartPosition = FormStartPosition.CenterScreen
                objErrores.mensaje = "Ocurrio un errore inesperados: " + ex.Message
                objErrores.ShowDialog()
            End Try
            
            Me.Cursor = Cursors.Default
        Else
            Me.Close()
        End If
    End Sub


    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub


#End Region

    Private Function ValidarCamposVacios() As Boolean
        ValidarCamposVacios = False

        Dim objErrores As New Tools.AdvertenciaForm
        objErrores.StartPosition = FormStartPosition.CenterScreen

        If txtContacto.Text = "" Then
            lblContacto.ForeColor = Color.Red
            objErrores.mensaje = "Ingresa el nombre de contacto"
            objErrores.ShowDialog()
            ValidarCamposVacios = True
        Else
            lblContacto.ForeColor = Color.Black
        End If

        If txtEmail.Text = "" Then
            lblEmail.ForeColor = Color.Red
            objErrores.mensaje = "Ingresa el e-mail de contacto"
            objErrores.ShowDialog()
            ValidarCamposVacios = True
        Else
            lblEmail.ForeColor = Color.Black
        End If

        If cmbAgentesVentas.SelectedIndex <= 0 Then
            gpbAgentedeVentas.ForeColor = Color.Red
            gpbMarcas.ForeColor = Color.Red
            ValidarCamposVacios = True
            objErrores.mensaje = "Aún no seleccionas un agente y su(s) marca(s)."
            objErrores.ShowDialog()
        Else
            gpbAgentedeVentas.ForeColor = Color.Black
            gpbMarcas.ForeColor = Color.Black
            Dim cont As Integer = 0

            For Each row As UltraGridRow In grdContactoMarcaAgente.Rows
                If row.Cells(" ").Value = True Then
                    cont += 1
                End If
            Next

            If cont = 0 Then
                objErrores.mensaje = "Debes seleccionar al menos una marca del agente para poder guardar."
                objErrores.ShowDialog()
                ValidarCamposVacios = True
            End If
        End If

        Return ValidarCamposVacios
    End Function


    
End Class