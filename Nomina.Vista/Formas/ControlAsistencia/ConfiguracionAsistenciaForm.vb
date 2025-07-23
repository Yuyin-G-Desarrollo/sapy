Imports Tools

Public Class ConfiguracionAsistenciaForm

    Dim boton As String = String.Empty
    Dim cuentaOK, cuentaMal As Integer


    Private Sub ConfiguracionAsistenciaForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Top = 0
        Me.Left = 0
        Tools.FormatoCtrls.formato(Me)
        load_componenentesInicio()
        load_gridConfiguracionAsistencia()

    End Sub

    Private Sub load_componenentesInicio()

        clmRango.ReadOnly = True
        clmResultado.ReadOnly = True
        clmPorcentaje.ReadOnly = True

        btnAgregar.Focus()
        btnAgregar.Visible = True
        lblAgregar.Visible = True

        btnEditar.Visible = True
        lblEditar.Visible = True

        btnGuardar.Visible = False
        lblGuardar.Visible = False

        btnCancelar.Visible = False
        lblCancelar.Visible = False

    End Sub

    Private Sub load_gridConfiguracionAsistencia()

        gridConfiguracionAsistencia.Rows.Clear()
        Dim configuracionAsistenciaBU As New Framework.Negocios.ConfiguracionAsistenciaBU
        Dim listaConfiguracionesUsuarioNave As New List(Of Entidades.ConfiguracionAsistencia)
        listaConfiguracionesUsuarioNave = configuracionAsistenciaBU.listaConfiguracionesUsuarioNave(Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)

        If listaConfiguracionesUsuarioNave.Capacity > 0 Then

            Dim i As Integer

            For Each fila As Entidades.ConfiguracionAsistencia In listaConfiguracionesUsuarioNave

                If fila.PResultadoCheck = 0 Then

                    Me.gridConfiguracionAsistencia.Rows.Insert(0, fila.PConfiguracionAsistenciaId, fila.PNaves.PNaveId, fila.PNaves.PNombre.ToUpper)
                    gridConfiguracionAsistencia.Rows(i).DefaultCellStyle.BackColor = Color.LightYellow

                End If

                'If fila.PResultadoCheck = 1 Then

                '    Me.gridConfiguracionAsistencia.Rows.Insert(0, fila.PConfiguracionAsistenciaId, fila.PNaves.PNaveId, fila.PNaves.PNombre, fila.PRango, clmResultado.Items.Item(0), fila.PPorcentaje)
                '    gridConfiguracionAsistencia.Rows(i).DefaultCellStyle.BackColor = Color.LightGreen

                'End If

                If fila.PResultadoCheck = 2 Then

                    Me.gridConfiguracionAsistencia.Rows.Insert(0, fila.PConfiguracionAsistenciaId, fila.PNaves.PNaveId, fila.PNaves.PNombre.ToUpper, fila.PRango, clmResultado.Items.Item(1), fila.PPorcentaje)
                    gridConfiguracionAsistencia.Rows(i).DefaultCellStyle.BackColor = Color.LightGreen

                End If

                If fila.PResultadoCheck = 3 Then

                    Me.gridConfiguracionAsistencia.Rows.Insert(0, fila.PConfiguracionAsistenciaId, fila.PNaves.PNaveId, fila.PNaves.PNombre.ToUpper, fila.PRango, clmResultado.Items.Item(2), fila.PPorcentaje)
                    gridConfiguracionAsistencia.Rows(i).DefaultCellStyle.BackColor = Color.LightGreen

                End If

                If fila.PResultadoCheck = 4 Then

                    Me.gridConfiguracionAsistencia.Rows.Insert(0, fila.PConfiguracionAsistenciaId, fila.PNaves.PNaveId, fila.PNaves.PNombre.ToUpper, fila.PRango, clmResultado.Items.Item(2), fila.PPorcentaje)
                    gridConfiguracionAsistencia.Rows(i).DefaultCellStyle.BackColor = Color.LightGreen

                End If

                If fila.PResultadoCheck = 6 Then

                    Me.gridConfiguracionAsistencia.Rows.Insert(0, fila.PConfiguracionAsistenciaId, fila.PNaves.PNaveId, fila.PNaves.PNombre.ToUpper, fila.PRango, clmResultado.Items.Item(3), fila.PPorcentaje)
                    gridConfiguracionAsistencia.Rows(i).DefaultCellStyle.BackColor = Color.LightGreen

                End If

            Next

            i += 1

        End If

    End Sub

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click

        Dim navesBU As New Framework.Negocios.NavesBU
        Dim ListaNavesSegunUsuario As New List(Of Entidades.Naves)

        validar_Componentes(btnAgregar.Name.ToString)

        ListaNavesSegunUsuario = navesBU.ListaNavesSegunUsuario("", Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)

        If ListaNavesSegunUsuario.Capacity > 0 Then

            Dim i As Integer = 0

            For Each fila As Entidades.Naves In ListaNavesSegunUsuario

                Me.gridConfiguracionAsistencia.Rows.Insert(0, 0, fila.PNaveId, fila.PNombre)
                gridConfiguracionAsistencia.Rows(i).DefaultCellStyle.BackColor = Color.LightSalmon

            Next

            i += 1

        End If

    End Sub

    Private Sub btnEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditar.Click

        validar_Componentes(btnEditar.Name.ToString)
        clmRango.ReadOnly = False
        clmResultado.ReadOnly = False
        clmPorcentaje.ReadOnly = False

    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click

        Dim configuracionAsistencia As New Entidades.ConfiguracionAsistencia
        Dim configuracionAsistenciaBU As New Framework.Negocios.ConfiguracionAsistenciaBU

        validar_Componentes(btnGuardar.Name.ToString)

        Dim i As Integer

        For Each row As DataGridViewRow In gridConfiguracionAsistencia.Rows 'Recorro todo el grid fila por fila

            Try

                Dim nave As New Entidades.Naves

                configuracionAsistencia.PConfiguracionAsistenciaId = CInt(row.Cells(0).Value)

                nave.PNaveId = CInt(row.Cells(1).Value)
                nave.PNombre = CStr(row.Cells(2).Value)

                configuracionAsistencia.PNaves = nave
                configuracionAsistencia.PRango = CInt(row.Cells(3).Value)

                If row.Cells(4).Value.ToString.Equals("A TIEMPO") Then

                    configuracionAsistencia.PResultadoCheck = 1

                End If

                If row.Cells(4).Value.ToString.Equals("RETARDO MENOR") Then

                    configuracionAsistencia.PResultadoCheck = 2

                End If

                If row.Cells(4).Value.ToString.Equals("RETARDO MAYOR") Then

                    configuracionAsistencia.PResultadoCheck = 3

                End If

                If row.Cells(4).Value.ToString.Equals("INASISTENCIA") Then

                    configuracionAsistencia.PResultadoCheck = 6

                End If

                configuracionAsistencia.PPorcentaje = CDbl(row.Cells(5).Value)
                configuracionAsistenciaBU.guardarConfiguracionAsistencia(configuracionAsistencia)
                cuentaOK += 1
                'End  If
            Catch ex As Exception

                cuentaMal += 1

            End Try


            i += 1

        Next

        show_message()
        load_gridConfiguracionAsistencia()

    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click

        validar_Componentes(btnCancelar.Name.ToString)

        For Each row As DataGridViewRow In gridConfiguracionAsistencia.Rows 'Recorro todo el grid fila por fila

            If row.Cells(0).Value = 0 Then

                row.Cells(3).Value = Nothing
                row.Cells(4).Value = Nothing
                row.Cells(5).Value = Nothing

            End If

        Next

        load_gridConfiguracionAsistencia()

    End Sub

    Private Sub DataGridView1_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles gridConfiguracionAsistencia.EditingControlShowing

        Try

            Dim validar As TextBox = CType(e.Control, TextBox)
            ' agregar el controlador de eventos para el KeyPress 
            AddHandler validar.KeyPress, AddressOf validar_Keypress

        Catch

        End Try

    End Sub

    Private Sub validar_Keypress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        ' evento Keypress 
        ' obtener indice de la columna 
        'Dim posicionPunto As Integer
        'Dim textoCelda As String
        Dim columna As Integer = gridConfiguracionAsistencia.CurrentCell.ColumnIndex

        ' comprobar si la celda en edición corresponde a la columna 3 o 5
        If columna = 3 Then
            ' Obtener caracter 
            Dim caracter As Char = e.KeyChar
            ' referencia a la celda 
            Dim txt As TextBox = CType(sender, TextBox)
            ' comprobar si es un número con isNumber, si es el backspace, si el caracter 
            ' es el separador decimal, y que no contiene ya el separador 
            If (Char.IsNumber(caracter)) Or (caracter = ChrW(Keys.Back)) Then

                e.Handled = False 'Aqui si la muestra

            Else

                e.Handled = True 'Aqui se la come

            End If
        End If

        If columna = 5 Then
            ' Obtener caracter 
            Dim caracter As Char = e.KeyChar
            ' referencia a la celda 
            Dim txt As TextBox = CType(sender, TextBox)
            ' comprobar si es un número con isNumber, si es el backspace, si el caracter 

            If txt.Text.IndexOf(".") >= 0 And txt.Text.IndexOf(".") <= 4 Then

                clmPorcentaje.MaxInputLength = txt.Text.IndexOf(".") + 3

            Else

                clmPorcentaje.MaxInputLength = 3

            End If

            ' es el separador decimal, y que no contiene ya el separador 
            If (Char.IsNumber(caracter)) Or (caracter = ChrW(Keys.Back)) Or (caracter = ".") And (txt.Text.Contains(".") = False) Then

                e.Handled = False

            Else

                e.Handled = True

            End If
        End If

    End Sub

    Private Sub validar_Componentes(ByVal boton As String)

        If boton.Equals(btnAgregar.Name.ToString) = True Then

            btnAgregar.Visible = True
            lblAgregar.Visible = True

            btnEditar.Visible = True
            lblEditar.Visible = True

            btnCancelar.Visible = True
            lblCancelar.Visible = True

            btnGuardar.Visible = True
            lblGuardar.Visible = True

            clmRango.ReadOnly = True
            clmResultado.ReadOnly = True
            clmPorcentaje.ReadOnly = True

        End If

        If boton.Equals(btnEditar.Name.ToString) = True Then

            btnAgregar.Visible = True
            lblAgregar.Visible = True

            btnEditar.Visible = False
            lblEditar.Visible = False

            btnCancelar.Visible = True
            lblCancelar.Visible = True


            btnGuardar.Visible = True
            lblGuardar.Visible = True

            clmRango.ReadOnly = False
            clmRango.MaxInputLength = 3
            clmResultado.ReadOnly = False
            clmPorcentaje.ReadOnly = False
            clmPorcentaje.MaxInputLength = 6

        End If

        If boton.Equals(btnGuardar.Name.ToString) = True Then

            btnAgregar.Visible = True
            lblAgregar.Visible = True

            btnEditar.Visible = True
            lblEditar.Visible = True

            btnCancelar.Visible = False
            lblCancelar.Visible = False

            btnGuardar.Visible = False
            lblGuardar.Visible = False

            clmRango.ReadOnly = True
            clmResultado.ReadOnly = True
            clmPorcentaje.ReadOnly = True

        End If

        If boton.Equals(btnCancelar.Name.ToString) = True Then

            btnAgregar.Visible = True
            lblAgregar.Visible = True

            btnEditar.Visible = True
            lblEditar.Visible = True

            btnCancelar.Visible = False
            lblCancelar.Visible = False


            btnGuardar.Visible = False
            lblGuardar.Visible = False

            clmRango.ReadOnly = True
            clmResultado.ReadOnly = True
            clmPorcentaje.ReadOnly = True

        End If

    End Sub

    Public Sub show_message()

        If cuentaOK > 0 And cuentaMal > 0 Then

            Dim mensajeAviso As New AvisoForm
            mensajeAviso.MdiParent = Me.MdiParent
            'mensajeExito.mensaje = "Configuración Guardada  " & vbNewLine & mensaje.ToString
            mensajeAviso.mensaje = "No fue posible guardar algunos cambios"
            mensajeAviso.Show()

        End If

        If cuentaOK = 0 And cuentaMal >= 0 Then

            Dim mensajeError As New ErroresForm
            mensajeError.MdiParent = Me.MdiParent
            'mensajeExito.mensaje = "Configuración Guardada  " & vbNewLine & mensaje.ToString
            mensajeError.mensaje = "No se guardo ningun cambio"
            mensajeError.Show()

        End If

        If cuentaOK > 0 And cuentaMal = 0 Then

            Dim mensajeExito As New ExitoForm
            mensajeExito.MdiParent = Me.MdiParent
            'mensajeExito.mensaje = "Configuración Guardada  " & vbNewLine & mensaje.ToString
            mensajeExito.mensaje = "Todos los cambios se guardaron con exito"
            mensajeExito.Show()

        End If

    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub pnlOperaciones_Paint(sender As Object, e As PaintEventArgs) Handles pnlOperaciones.Paint

    End Sub
End Class