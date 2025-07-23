Imports Tools

Public Class ConfiguracionPrestamosForm
    Public Property MaxInputLength As Integer
    Dim MessageMal As String = " "
    Dim con As Integer = 0


    Private Sub ConfiguracionPrestamosForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        WindowState = FormWindowState.Maximized
        Tools.FormatoCtrls.formato(Me)

        'Me.grdConfiguracion.Columns("MontoMaximoPorNave").DefaultCellStyle.Format = "N0"
        'Me.grdConfiguracion.Columns("MontoMaximoPorColaborado").DefaultCellStyle.Format = "N0"

        llenartabla()


    End Sub


    ''Metodo para llenar la tabla   
    Public Sub AgregarFila(ByVal ConfiguracionPrestamos As Entidades.ConfiguracionPrestamos)


        Dim celda As DataGridViewCell
        Dim fila As New DataGridViewRow

        celda = New DataGridViewTextBoxCell
        celda.Value = ConfiguracionPrestamos.PNaves.PNaveId
        fila.Cells.Add(celda)

        celda = New DataGridViewTextBoxCell
        celda.Value = ConfiguracionPrestamos.PConfiguracionPrestamoId
        fila.Cells.Add(celda)

        celda = New DataGridViewTextBoxCell
        celda.Value = ConfiguracionPrestamos.PNaves.PNombre.ToUpper
        fila.Cells.Add(celda)

        celda = New DataGridViewTextBoxCell
        celda.Value = ConfiguracionPrestamos.PSemanasMaximo
        fila.Cells.Add(celda)

        celda = New DataGridViewTextBoxCell
        celda.Value = ConfiguracionPrestamos.PMontoMaximoPorNave
        fila.Cells.Add(celda)


        celda = New DataGridViewTextBoxCell
        celda.Value = ConfiguracionPrestamos.PMontoMaximoPorColaborador
        fila.Cells.Add(celda)

        celda = New DataGridViewTextBoxCell
        celda.Value = ConfiguracionPrestamos.PInteres
        fila.Cells.Add(celda)


        celda = New DataGridViewCheckBoxCell
        celda.Value = ConfiguracionPrestamos.PInteresSobreSaldo
        fila.Cells.Add(celda)

        celda = New DataGridViewCheckBoxCell
        celda.Value = ConfiguracionPrestamos.PInteresFijo
        fila.Cells.Add(celda)

        celda = New DataGridViewCheckBoxCell
        celda.Value = ConfiguracionPrestamos.PSinInteres
        fila.Cells.Add(celda)

        celda = New DataGridViewCheckBoxCell
        celda.Value = ConfiguracionPrestamos.PAutorizacionGerente
        fila.Cells.Add(celda)

        celda = New DataGridViewCheckBoxCell
        celda.Value = ConfiguracionPrestamos.PAutorizacionDirector
        fila.Cells.Add(celda)

        Me.grdConfiguracion.Rows.Add(fila)
    End Sub

    ''Metodo para llenar el DATAGRIDVIEW
    Public Sub llenartabla()
        Dim Naves As Boolean = False
        Dim listaConfiguracionPrestamos As New List(Of Entidades.ConfiguracionPrestamos)
        Dim prestamosBU As New Nomina.Negocios.ConfiguracionPrestamosBU

        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("NOM_PRES_CONFIG", "NOMPRESTODASNAVES") Then
            Naves = True
        End If

        listaConfiguracionPrestamos = prestamosBU.ListaConfiguracionPrestamos(Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, Naves)

        For Each objeto As Entidades.ConfiguracionPrestamos In listaConfiguracionPrestamos
            AgregarFila(objeto)
        Next
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        GuardarConfiguracionPrestamo()

    End Sub

    ''Metodo para guardar los datos con validacion el guardado
    Public Sub GuardarConfiguracionPrestamo()
        Dim objBU = New Nomina.Negocios.ConfiguracionPrestamosBU
        Dim ObjEnt = New Entidades.ConfiguracionPrestamos
        MessageMal = " "
        Dim siguardo As Boolean = False

        For Each row As DataGridViewRow In grdConfiguracion.Rows 'Recorro todo el grid fila por fila
            Dim nave As New Entidades.Naves
            Dim estamal As Boolean = False

            ''Creacion del objeto para el formato del mensaje
            Dim mensajeError As New AdvertenciaForm
            mensajeError.MdiParent = Me.MdiParent

            Try

                ''VALIDAR QUE ALMENOS UNA PERSONA APRUEBE EL PRESTAMO
                If (row.Cells(10).Value) = False And (row.Cells(11).Value) = False Then
                    grdConfiguracion.CurrentCell = grdConfiguracion.Item(2, 0) ''Cambia el foto del dataGrid
                    MessageMal = vbNewLine & "Los registros en rojo no se guardarán porque la configuración esta incompleta."
                    row.Cells(10).Style.BackColor = Color.Salmon
                    row.Cells(11).Style.BackColor = Color.Salmon
                    estamal = True
                Else
                    ObjEnt.PAutorizacionGerente = CBool(row.Cells(10).Value)
                    ObjEnt.PAutorizacionDirector = CBool(row.Cells(11).Value)

                    row.Cells(10).Style.BackColor = Color.LightSalmon
                    row.Cells(11).Style.BackColor = Color.LightSalmon
                    row.Cells(6).Style.BackColor = Color.LightSalmon
                    row.Cells(3).Style.BackColor = Color.LightSalmon
                    row.Cells(2).Style.BackColor = Color.LightSalmon

                End If

                ''Validacion para que se seleccione siempre un tipo de interes
                If (row.Cells(7).Value) = False And (row.Cells(8).Value) = False And (row.Cells(9).Value) = False Then
                    grdConfiguracion.CurrentCell = grdConfiguracion.Item(2, 0)

                    row.Cells(7).Style.BackColor = Color.Salmon
                    row.Cells(8).Style.BackColor = Color.Salmon
                    row.Cells(9).Style.BackColor = Color.Salmon


                    estamal = True
                    MessageMal = vbNewLine & "Los registros en rojo no se guardarán porque la configuración esta incompleta."
                Else
                    ObjEnt.PInteresSobreSaldo = CBool(row.Cells(7).Value)
                    ObjEnt.PInteresFijo = CBool(row.Cells(8).Value)
                    ObjEnt.PSinInteres = CBool(row.Cells(9).Value)


                    row.Cells(9).Style.BackColor = Color.LightSalmon
                    row.Cells(8).Style.BackColor = Color.LightSalmon
                    row.Cells(7).Style.BackColor = Color.LightSalmon
                    row.Cells(6).Style.BackColor = Color.LightSalmon
                    row.Cells(3).Style.BackColor = Color.LightSalmon
                    row.Cells(2).Style.BackColor = Color.LightSalmon
                End If

                ''VALIDACION DE MONTOS ENTRE NAVE Y COLABORADOR para que el monto de la NAVE no sea menor al del colaborador
                If (CDbl(row.Cells(4).Value) > 0 And (CDbl(row.Cells(4).Value)) < CDbl((row.Cells(5).Value))) Then
                    row.Cells(5).Style.BackColor = Color.Salmon
                    row.Cells(4).Style.BackColor = Color.Salmon


                    grdConfiguracion.CurrentCell = grdConfiguracion.Item(2, 0)

                    estamal = True
                    MessageMal = vbNewLine & "Los registros en rojo no se guardarán porque la configuración esta incompleta." & vbNewLine & "* El monto de la nave es menor al monto del colaborador."
                Else
                    ObjEnt.PSemanasMaximo = CInt(row.Cells(3).Value)
                    ObjEnt.PMontoMaximoPorNave = CDbl(row.Cells(4).Value)

                    row.Cells(4).Style.BackColor = Color.LightSalmon
                    row.Cells(5).Style.BackColor = Color.LightSalmon
                    row.Cells(6).Style.BackColor = Color.LightSalmon
                    row.Cells(3).Style.BackColor = Color.LightSalmon
                    row.Cells(2).Style.BackColor = Color.LightSalmon
                End If


                ''Validacion que Si la configuracion es correcta proceda a guardar
                If estamal = False Then
                    nave.PNaveId = CInt(row.Cells(0).Value)
                    ObjEnt.PNaves = nave
                    ObjEnt.PConfiguracionPrestamoId = CInt(row.Cells(1).Value)
                    ObjEnt.PMontoMaximoPorColaborador = CDbl(row.Cells(5).Value)
                    ObjEnt.PInteres = CDbl(row.Cells(6).Value)
                    ObjEnt.PUsuarioCreo = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
                    ObjEnt.PUsuarioModifico = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid


                    siguardo = True
                    objBU.guardarConfiguracionPrestamos(ObjEnt)
                    row.Cells(1).Value = 1
                    row.Cells(11).Style.BackColor = Color.LightGreen
                    row.Cells(10).Style.BackColor = Color.LightGreen
                    row.Cells(9).Style.BackColor = Color.LightGreen
                    row.Cells(8).Style.BackColor = Color.LightGreen
                    row.Cells(7).Style.BackColor = Color.LightGreen
                    row.Cells(6).Style.BackColor = Color.LightGreen
                    row.Cells(5).Style.BackColor = Color.LightGreen
                    row.Cells(4).Style.BackColor = Color.LightGreen
                    row.Cells(3).Style.BackColor = Color.LightGreen
                    row.Cells(2).Style.BackColor = Color.LightGreen
                    grdConfiguracion.CurrentCell = grdConfiguracion.Item(2, 0)

                End If

            Catch ex As Exception

            End Try
        Next


        ''Validacion del tipo de mensaje que mostrara

        If siguardo Then
            Dim mensajeExito As New ExitoForm
            mensajeExito.MdiParent = Me.MdiParent
            mensajeExito.mensaje = "CONFIGURACIÓN GUARDADA" & vbNewLine & MessageMal.ToString

            mensajeExito.Show()

        Else
            Dim mensajeError As New AdvertenciaForm
            mensajeError.MdiParent = Me.MdiParent
            mensajeError.mensaje = MessageMal.ToString
            mensajeError.Show()
        End If
    End Sub

    ''Metodo para que solo se ingresen NUMEROS y UN punto en un datagridview
    Private Sub DataGridView1_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles grdConfiguracion.EditingControlShowing
        ' referencia a la celda 


        Dim validar As TextBox = CType(e.Control, TextBox)

        ' agregar el controlador de eventos para el KeyPress  
        AddHandler validar.KeyPress, AddressOf validar_Keypress
    End Sub

    ''Evento key press para validacion del datagridview
    Private Sub validar_Keypress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        ' evento Keypress  

        ' obtener indice de la columna  

        Dim columna As Integer = grdConfiguracion.CurrentCell.ColumnIndex

        ' comprobar si la celda en edición corresponde a la columna que se requiera
        If columna = 3 Or columna = 4 Or columna = 5 Or columna = 6 Then
            ' Obtener caracter  
            Dim caracter As Char = e.KeyChar

            ' referencia a la celda  
            Dim txt As TextBox = CType(sender, TextBox)

            ' comprobar si es un número con isNumber, si es el backspace, si el caracter  
            ' es el separador decimal, y que no contiene ya el separador  
            If txt.Text.IndexOf(".") > 0 Then

                TasaDeInteres.MaxInputLength = txt.Text.IndexOf(".") + 3
                MontoMaximoPorColaborado.MaxInputLength = txt.Text.IndexOf(".") + 3
                MontoMaximoPorNave.MaxInputLength = txt.Text.IndexOf(".") + 3
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


    ''Dar formato en cuanto pierde  el foco
    Private Sub grdConfiguracion_CellLeave(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdConfiguracion.CellLeave
        'Try


        If e.ColumnIndex = 11 Or e.ColumnIndex = 10 Or e.ColumnIndex = 9 Or e.ColumnIndex = 8 Or e.ColumnIndex = 7 Or e.ColumnIndex = 6 Or e.ColumnIndex = 5 Or e.ColumnIndex = 4 Or e.ColumnIndex = 3 Then
            Dim MaximoPorColaborador As Double = 0
            Dim MaximoPorNave As Double = 0
            Dim SemanasMax As Double = 0
            Dim Interes As Double = 0
            For Each row As DataGridViewRow In grdConfiguracion.Rows

                Try
                    Interes = row.Cells(6).Value
                    row.Cells(6).Value = Interes
                Catch

                    row.Cells(6).Value = 0
                End Try

                Try
                    MaximoPorColaborador = row.Cells(5).Value
                    row.Cells(5).Value = MaximoPorColaborador
                Catch

                    row.Cells(5).Value = 0
                End Try
                Try
                    MaximoPorNave = row.Cells(4).Value
                    row.Cells(4).Value = MaximoPorNave
                Catch

                    row.Cells(4).Value = 0
                End Try
                Try
                    SemanasMax = row.Cells(3).Value
                    row.Cells(3).Value = SemanasMax
                Catch

                    row.Cells(3).Value = 0
                End Try
            Next
        End If

    End Sub

    Private Sub grdConfiguracion_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdConfiguracion.CellValueChanged

        If e.ColumnIndex = 11 Or e.ColumnIndex = 10 Or e.ColumnIndex = 9 Or e.ColumnIndex = 8 Or e.ColumnIndex = 7 Or e.ColumnIndex = 6 Or e.ColumnIndex = 5 Or e.ColumnIndex = 4 Or e.ColumnIndex = 3 Then
            Dim MaximoPorColaborador As Double = 0
            Dim MaximoPorNave As Double = 0
            Dim SemanasMax As Double = 0
            Dim Interes As Double = 0

            For Each row As DataGridViewRow In grdConfiguracion.Rows

                Try
                    Interes = row.Cells(6).Value
                    row.Cells(6).Value = Interes
                Catch

                    row.Cells(6).Value = 0
                End Try

                Try
                    MaximoPorColaborador = row.Cells(5).Value
                    row.Cells(5).Value = MaximoPorColaborador
                Catch

                    row.Cells(5).Value = 0
                End Try
                Try
                    MaximoPorNave = row.Cells(4).Value
                    row.Cells(4).Value = MaximoPorNave
                Catch

                    row.Cells(4).Value = 0
                End Try
                Try
                    SemanasMax = row.Cells(3).Value
                    row.Cells(3).Value = SemanasMax
                Catch

                    row.Cells(3).Value = 0
                End Try
            Next
        End If

    End Sub
    Private Sub btnCncelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCncelar.Click
        Me.Close()
    End Sub

End Class