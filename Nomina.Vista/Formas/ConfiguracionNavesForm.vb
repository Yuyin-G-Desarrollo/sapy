Imports Nomina.Negocios
Imports Tools

Public Class ConfiguracionNavesForm
    Dim Indice, ActivarInsertsAndUpdates As Int32
    Private Sub ConfiguracionNavesForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Top = 0
        Me.Left = 0
        llenartabla()
    End Sub

    Public Sub llenartabla()
        Dim objBU As New ConfiguracionNaveNominaBU
        Dim listaConfiguraciones As List(Of Entidades.ConfiguracionNaveNomina)
        listaConfiguraciones = objBU.ListaConfiguracionNave()
        For Each objeto As Entidades.ConfiguracionNaveNomina In listaConfiguraciones
            AgregarFila(objeto)
        Next

    End Sub


    Public Sub AgregarFila(ByVal configuracion As Entidades.ConfiguracionNaveNomina)

        Dim celda As DataGridViewCell
        Dim fila As New DataGridViewRow

        celda = New DataGridViewTextBoxCell
        celda.Value = configuracion.PNaveNombre.PNombre.ToUpper
        fila.Cells.Add(celda)




        celda = New DataGridViewTextBoxCell
        celda.Value = configuracion.PconDiasGratificacion
        fila.Cells.Add(celda)

        celda = New DataGridViewCheckBoxCell
        celda.Value = configuracion.PAutorizaGerente
        fila.Cells.Add(celda)

        celda = New DataGridViewCheckBoxCell
        celda.Value = configuracion.PAutorizaDirector
        fila.Cells.Add(celda)

        celda = New DataGridViewTextBoxCell
        celda.Value = configuracion.PConDiasAguinaldo
        fila.Cells.Add(celda)

        celda = New DataGridViewTextBoxCell
        celda.Value = configuracion.PNaveNombre.PNaveId
        fila.Cells.Add(celda)


        celda = New DataGridViewTextBoxCell
        celda.Value = configuracion.PIDconfiguracion
        fila.Cells.Add(celda)

        celda = New DataGridViewTextBoxCell
        celda.Value = configuracion.PconDiasVacaciones
        fila.Cells.Add(celda)

        grdConfiguracionNaves.Rows.Add(fila)

    End Sub



    Public Sub InsertarInformacion(ByVal Indice As Int32)
        Dim objBU As New ConfiguracionNaveNominaBU
        Dim Configuraciones As New Entidades.ConfiguracionNaveNomina
        Dim Gratificacion, Aguinaldo As Double
        Dim Gerente, Director As Boolean
        Dim Nave As Int32
        Dim Vacaciones As Int32
        Indice = 0

        For Each row As DataGridViewRow In grdConfiguracionNaves.Rows
            Gratificacion = grdConfiguracionNaves.Rows(Indice).Cells(1).Value

            Aguinaldo = grdConfiguracionNaves.Rows(Indice).Cells(4).Value
            Gerente = grdConfiguracionNaves.Rows(Indice).Cells(2).Value
            Director = grdConfiguracionNaves.Rows(Indice).Cells(3).Value
            Nave = grdConfiguracionNaves.Rows(Indice).Cells(5).Value
            Vacaciones = grdConfiguracionNaves.Rows(Indice).Cells(7).Value
            If grdConfiguracionNaves.Rows(Indice).Cells(6).Value > 0 Then

                objBU.UpdateConfiguracionNave(Gratificacion, Gerente, Director, Aguinaldo, grdConfiguracionNaves.Rows(Indice).Cells(6).Value, Vacaciones)

            Else
                objBU.InsertarConfiguracionNave(Gratificacion, Gerente, Director, Aguinaldo, Nave, Vacaciones)
            End If
            Indice += 1
        Next



    End Sub



    Private Sub grdConfiguracionNaves_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdConfiguracionNaves.CellClick
        'If (e.RowIndex >= 0) Then
        '    Indice = e.RowIndex
        'End If
        'If grdConfiguracionNaves.Rows(e.RowIndex).Cells(6).Value <= 0 Then
        '    ActivarInsertsAndUpdates = 0
        'Else
        '    ActivarInsertsAndUpdates = 1
        'End If

    End Sub

    Private Sub grdConfiguracionNaves_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdConfiguracionNaves.CellValueChanged
        'If (ActivarInsertsAndUpdates > 0) Then
        '    InsertarInformacion(Indice)
        'End If

    End Sub

    Private Sub btnAutorizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAutorizar.Click
        InsertarInformacion(Indice)
        Dim Exito As New ExitoForm
        Exito.mensaje = "Configuracion Guardada"
        Exito.ShowDialog()
        Me.Close()
    End Sub

    Private Sub grdConfiguracionNaves_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles grdConfiguracionNaves.EditingControlShowing

        Dim validar As TextBox = CType(e.Control, TextBox)

        ' agregar el controlador de eventos para el KeyPress  
        AddHandler validar.KeyPress, AddressOf validar_Keypress
    End Sub


    Private Sub validar_Keypress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        ' evento Keypress  

        ' obtener indice de la columna  

        Dim columna As Integer = grdConfiguracionNaves.CurrentCell.ColumnIndex

        ' comprobar si la celda en edición corresponde a la columna que se requiera
        If columna = 1 Then
            ' Obtener caracter  
            Dim caracter As Char = e.KeyChar

            ' referencia a la celda  
            Dim txt As TextBox = CType(sender, TextBox)

            ' comprobar si es un número con isNumber, si es el backspace, si el caracter  
            ' es el separador decimal, y que no contiene ya el separador  
            If txt.Text.IndexOf(".") > 0 Then

                DiasGratificacion.MaxInputLength = txt.Text.IndexOf(".") + 3


            End If


            If (Char.IsNumber(caracter)) Or _
(caracter = ChrW(Keys.Back)) Or _
            (caracter = ".") And _
            (txt.Text.Contains(".") = False) Then

                e.Handled = False
            Else
                e.Handled = True



            End If
        End If
    End Sub


    Private Sub grdConfiguracionNaves_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdConfiguracionNaves.CellContentClick

    End Sub

    Private Sub lblCerrar_Click(sender As Object, e As EventArgs) Handles lblCerrar.Click

    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub
End Class