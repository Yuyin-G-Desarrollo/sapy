Public Class ListaMotivosIncentivosForm

    Dim IDUsuario As Int32 = IDUsuario = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
    Dim nombre, descripcion As String
    Dim monto, idnave, idincentivo As Int32
    Dim NaveId As Int32 = 0
    Private Sub ListaMotivosIncentivosForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Left = 0
        Me.Top = 0
        grdFiltroIncentivos.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        ' MsgBox(IDUsuario)

        cmbNaves = Controles.ComboNavesSegunUsuario(cmbNaves, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
        '--------------------------------------------------
        grdFiltroIncentivos.Columns.Add("Nombre", "Nombre") '0
        grdFiltroIncentivos.Columns("Nombre").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        '---------------------------------------------------
        grdFiltroIncentivos.Columns.Add("Monto", "Monto") '1
        '-----------------------------------------------------
        grdFiltroIncentivos.Columns.Add("Nave", "Nave") '2
        grdFiltroIncentivos.Columns("Nave").Visible = False
        '------------------------------------------------------
        grdFiltroIncentivos.Columns.Add("Activo", "Activo") '3
        grdFiltroIncentivos.Columns("Activo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        '--------------------------------------------------------
        grdFiltroIncentivos.Columns.Add("IDIcentivo", "IDIncentivo") '4
        grdFiltroIncentivos.Columns("IDIcentivo").Visible = False
        '----------------------------------------------------------
        grdFiltroIncentivos.Columns.Add("IDNave", "IDNave") '5
        grdFiltroIncentivos.Columns("IDNave").Visible = False
        '------------------------------------------------------------
        grdFiltroIncentivos.Columns.Add("Descripcion", "Descripcion") '6
        grdFiltroIncentivos.Columns("Descripcion").Visible = False

        



        nombre = CStr(grdFiltroIncentivos.Rows(0).Cells("Nombre").Value)
        descripcion = CStr(grdFiltroIncentivos.Rows(0).Cells("Descripcion").Value)
        monto = CInt(grdFiltroIncentivos.Rows(0).Cells("Monto").Value)
        idnave = CInt(grdFiltroIncentivos.Rows(0).Cells("IDNave").Value)
        idincentivo = CInt(grdFiltroIncentivos.Rows(0).Cells("IDIcentivo").Value)
        If cmbNaves.Items.Count > 2 Then

        Else

            If cmbNaves.SelectedIndex > 0 Then
                NaveId = CInt(cmbNaves.SelectedValue)
            End If

        End If



  
     

   
    End Sub




    Public Sub AgregarFila(ByVal incentivos As Entidades.Incentivos)


        Dim celda As DataGridViewCell
        Dim fila As New DataGridViewRow

        celda = New DataGridViewTextBoxCell
        celda.Value = incentivos.INombre.ToUpper
        fila.Cells.Add(celda)



        celda = New DataGridViewTextBoxCell
        celda.Value = incentivos.IMontoMaximo
        fila.Cells.Add(celda)

        celda = New DataGridViewTextBoxCell
        celda.Value = incentivos.INaveNombre.PNombre
        fila.Cells.Add(celda)

        celda = New DataGridViewCheckBoxCell
        celda.Value = incentivos.IActivo
        fila.Cells.Add(celda)


        celda = New DataGridViewTextBoxCell
        celda.Value = incentivos.IIncentivoId
        fila.Cells.Add(celda)

        celda = New DataGridViewTextBoxCell
        celda.Value = incentivos.IIncentivosNaveId.PNaveId
        fila.Cells.Add(celda)

        celda = New DataGridViewTextBoxCell
        celda.Value = incentivos.IDescripcion
        fila.Cells.Add(celda)



        grdFiltroIncentivos.Rows.Add(fila)

    End Sub



    Public Sub llenartabla()

        If cmbNaves.SelectedIndex > 0 Then
            NaveId = CInt(cmbNaves.SelectedValue)
        End If
       

        Dim listaMotivos As New List(Of Entidades.Incentivos)
        Dim objBU As New Negocios.IncentivosBU
        listaMotivos = objBU.ListaIncentivos(txtBuscarNombreIncentivo.Text, rdoActivoSi.Checked, NaveId)
        For Each objeto As Entidades.Incentivos In listaMotivos

            AgregarFila(objeto)
        Next
    End Sub

    Private Sub btnAltaIncentivo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAltaIncentivo.Click
        Dim AltasMotivos As New AltasMotivosIncentivosForm

        AltasMotivos.ShowDialog()
        grdFiltroIncentivos.Rows.Clear()
        llenartabla()
    End Sub

    Private Sub btnEditarIncentivo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditarIncentivo.Click

        If idincentivo > 0 Then
            Dim EditarMotivos As New EditarMotivosForm

            EditarMotivos.ENombre = nombre
            EditarMotivos.EMonto = monto
            EditarMotivos.EInave = idnave
            EditarMotivos.EidIncentivo = idincentivo
            EditarMotivos.Edescripcion = descripcion
            EditarMotivos.MdiParent = MdiParent

            If nombre = "TRABAJO MEDIO DIA FESTIVO" Or nombre = "TRABAJO DIA FESTIVO" Then


            Else
                EditarMotivos.Show()
            End If



        End If
       
    End Sub

    Private Sub btnFiltrarPais_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFiltrarPais.Click

        If cmbNaves.SelectedIndex >= 0 Then
            grdFiltroIncentivos.Rows.Clear()
            llenartabla()
        End If
        
    End Sub

    Private Sub btnLimpiarIncentivos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiarIncentivos.Click
        grdFiltroIncentivos.Rows.Clear()
        cmbNaves.SelectedValue = 0
    End Sub

    Private Sub grdFiltroIncentivos_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdFiltroIncentivos.CellClick
        If e.RowIndex > 0 Then

            nombre = (CStr(grdFiltroIncentivos.Rows(e.RowIndex).Cells(0).Value))
            monto = (CInt(grdFiltroIncentivos.Rows(e.RowIndex).Cells(1).Value))
            idincentivo = (CInt(grdFiltroIncentivos.Rows(e.RowIndex).Cells(4).Value))
            idnave = (CInt(grdFiltroIncentivos.Rows(e.RowIndex).Cells(5).Value))
            descripcion = (CStr(grdFiltroIncentivos.Rows(e.RowIndex).Cells(6).Value))

        End If
    End Sub

    Private Sub btnArriba_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnArriba.Click
        'gpbFiltroIncentivos.Height = 30
        'grdFiltroIncentivos.Top = 113
        'grdFiltroIncentivos.Height = 352
        ' pnlBusqueda.Visible = True
        gpbFiltroIncentivos.Height = 41
        grdFiltroIncentivos.Height = 422
        grdFiltroIncentivos.Top = 104

    End Sub

    Private Sub btnAbajo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAbajo.Click
        'gpbFiltroIncentivos.Height = 176
        'grdFiltroIncentivos.Top = 253
        'grdFiltroIncentivos.Height = 212
        ' pnlBusqueda.Visible = False
        gpbFiltroIncentivos.Height = 129
        grdFiltroIncentivos.Height = 334
        grdFiltroIncentivos.Top = 196
    End Sub

    Private Sub txtBuscarNombreIncentivo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBuscarNombreIncentivo.KeyPress
        e.Handled = True
        If Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsLetterOrDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        End If
    End Sub

   
End Class