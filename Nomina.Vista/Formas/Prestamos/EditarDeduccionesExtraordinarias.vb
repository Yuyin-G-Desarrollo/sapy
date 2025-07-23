Imports Tools

Public Class EditarDeduccionesExtraordinarias

    Private LISTAID2 As List(Of Int32)

    Public Property PLISTAID2 As List(Of Int32)
        Get
            Return LISTAID2
        End Get
        Set(ByVal value As List(Of Int32))
            LISTAID2 = value
        End Set
    End Property

    Private Sub EditarDeduccionesExtraordinarias_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Tools.Controles.ComboNavesSegunUsuario(cmbNave, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
        If cmbNave.SelectedIndex > 0 Then
            SemanaNomina()
        End If

        lblIdSemanaNomina.Visible = False
        lblSemanaNomina.Visible = False
        lblSemanaNominaFIN.Visible = False

    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        grdDeducciones.Rows.Clear()
        Try

            llenarTablaDeduccionesCobradas(cmbNave.SelectedValue, lblIdSemanaNomina.Text)


        Catch ex As Exception
        End Try
    End Sub

    Public Sub llenarTablaDeduccionesCobradas(ByVal idNave As Integer, ByVal idSemanaNomina As Integer)

        Try
            Dim listaDecucciones As New List(Of Entidades.Deducciones)
            Dim deduccionesBU As New Nomina.Negocios.DeduccionesBU




            If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("NOM_PRES_COBRANZA", "EDITARABONOS") Then
                listaDecucciones = deduccionesBU.ListaDeduccionCobrados(idNave, idSemanaNomina)

                For Each objeto As Entidades.Deducciones In listaDecucciones
                    AgregarFilaDeduccionesCobradas(objeto)
                    btnGuardar.Enabled = True
                Next
            End If


            If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("NOM_PRES_COBRANZA", "EDITARABONOSNEGATIVOS") Then

                For Each DATO As Int32 In LISTAID2
                    listaDecucciones = deduccionesBU.ListaDeduccionCobradosNEgativos(idNave, idSemanaNomina, DATO)

                    For Each objeto As Entidades.Deducciones In listaDecucciones
                        AgregarFilaDeduccionesCobradas(objeto)

                    Next
                Next

            End If

        Catch ex As Exception
        End Try
    End Sub

    Public Sub AgregarFilaDeduccionesCobradas(ByVal Deducciones As Entidades.Deducciones)

        Dim celda As DataGridViewCell
        Dim fila As New DataGridViewRow

        ''El numero de pago
        celda = New DataGridViewTextBoxCell
        celda.Value = Deducciones.PNumeroPago + "/" + Deducciones.PnumeroSemanas
        fila.Cells.Add(celda)

        ''El nombre
        celda = New DataGridViewTextBoxCell
        celda.Value = Deducciones.PColaborador.PNombre.ToUpper + " " + Deducciones.PColaborador.PApaterno.ToUpper + " " + Deducciones.PColaborador.PAmaterno.ToUpper
        fila.Cells.Add(celda)

        ''El departamento
        celda = New DataGridViewTextBoxCell
        celda.Value = Deducciones.PDepartamento
        fila.Cells.Add(celda)

        ''El Puesto
        celda = New DataGridViewTextBoxCell
        celda.Value = Deducciones.PPuesto
        fila.Cells.Add(celda)

        ''El concepto
        celda = New DataGridViewTextBoxCell
        celda.Value = Deducciones.PConceptoDeduccion
        fila.Cells.Add(celda)

        ''Numero de semanas
        celda = New DataGridViewTextBoxCell
        celda.Value = Deducciones.PnumeroSemanas
        fila.Cells.Add(celda)

        ''El monto
        celda = New DataGridViewTextBoxCell
        celda.Value = Deducciones.PMontoDeduccion
        fila.Cells.Add(celda)

        ''El Saldo
        celda = New DataGridViewTextBoxCell
        celda.Value = Deducciones.PSaldoAnterior
        fila.Cells.Add(celda)

        ''El abono
        celda = New DataGridViewTextBoxCell
        celda.Value = Deducciones.Pabono
        fila.Cells.Add(celda)

        'Nuevo saldo
        celda = New DataGridViewTextBoxCell
        celda.Value = Deducciones.PSaldo
        fila.Cells.Add(celda)

        ''El ID del colaborador
        celda = New DataGridViewTextBoxCell
        celda.Value = Deducciones.PColaborador.PColaboradorid
        fila.Cells.Add(celda)

        ''El ID DEDUCCION
        celda = New DataGridViewTextBoxCell
        celda.Value = Deducciones.PidDeduccion
        fila.Cells.Add(celda)

        ''El ID DEDUCCION
        celda = New DataGridViewTextBoxCell
        celda.Value = Deducciones.PPagoID
        fila.Cells.Add(celda)

        ''COBRADO
        celda = New DataGridViewTextBoxCell
        celda.Value = "C"
        fila.Cells.Add(celda)


        Me.grdDeducciones.Rows.Add(fila)

    End Sub

    Private Sub cmbNave_DropDownClosed(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbNave.DropDownClosed
        If cmbNave.SelectedIndex > 0 Then
            SemanaNomina()
        End If
    End Sub

    ''LLENAR SEMANA NOMINA ACTIVA
    Public Sub SemanaNomina()
        Try
            Dim SemanaNominaActiva As New List(Of Entidades.CobranzaPrestamos)
            Dim SenamaActivaBu As New Nomina.Negocios.CobranzaPrestamosBU
            Dim idNave As Integer
            idNave = (Int(cmbNave.SelectedValue))
            SemanaNominaActiva = SenamaActivaBu.SemanaNominaActiva(idNave)

            For Each objeto As Entidades.CobranzaPrestamos In SemanaNominaActiva
                SemanaActiva(objeto)
            Next

        Catch ex As Exception

        End Try
    End Sub

    Public Sub SemanaActiva(ByVal SemanaActiva As Entidades.CobranzaPrestamos)
        Dim mensaje As String = ""
        '' fechaFinNomina = SemanaActiva.PfechaFinNomina
        lblIdSemanaNomina.Text = SemanaActiva.PsemanaNominaId
        lblSemanaNominaFIN.Text = SemanaActiva.PfechaFinNomina
        lblSemanaNomina.Text = SemanaActiva.PPeriodoNominaDeducciones

        If lblSemanaNomina.Text = "C" Then
            btnGuardar.Enabled = False
        Else
            btnGuardar.Enabled = True

        End If

    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        grdDeducciones.Rows.Clear()
        cmbNave.SelectedIndex = 0
    End Sub

    Private Sub btnArriba_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnArriba.Click
        grbParametros.Height = 45
    End Sub

    Private Sub btnAbajo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAbajo.Click
        grbParametros.Height = 115
    End Sub

    Private Sub grdDeducciones_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdDeducciones.CellValueChanged

        Try
            Dim abono As Double = 0
            Dim saldo As Double = 0
            Dim saldonuevo As Double = 0
            Dim estamal As Integer = 0
            If e.ColumnIndex = 8 Then

                For Each row As DataGridViewRow In grdDeducciones.Rows
                    Try
                        abono = row.Cells("clmAbono").Value
                    Catch ex As Exception
                        row.Cells("clmAbono").Value = 0
                    End Try

                    ''VALIDADION PARA QUE EL TOTAL DE ABONO NO SOBRE PASE EL SALDO QUE TIENE
                    If row.Cells("clmAbono").Value > row.Cells("clmSaldo").Value Then
                        row.Cells("clmAbono").Style.BackColor = Color.Salmon
                        estamal += 1

                    Else

                        row.Cells("clmAbono").Style.BackColor = Color.White
                        saldonuevo = row.Cells("clmSaldo").Value - row.Cells("clmAbono").Value
                        abono = row.Cells("clmAbono").Value
                        row.Cells("clmAbono").Value = abono.ToString("c")
                        row.Cells("clmSaldoNuevo").Value = saldonuevo.ToString("c")

                    End If
                Next

                If estamal = 0 Then
                    btnGuardar.Enabled = True
                Else
                    btnGuardar.Enabled = False
                End If

            End If
        Catch ex As Exception

        End Try
    End Sub

    ''Metodo para que solo se ingresen NUMEROS y UN punto en un datagridview
    Private Sub DataGridView1_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles grdDeducciones.EditingControlShowing
        ' referencia a la celda 


        Dim validar As TextBox = CType(e.Control, TextBox)

        ' agregar el controlador de eventos para el KeyPress  
        AddHandler validar.KeyPress, AddressOf validar_Keypress
    End Sub

    ''Evento key press para validacion del datagridview
    Private Sub validar_Keypress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        ' evento Keypress  

        ' obtener indice de la columna  

        Dim columna As Integer = grdDeducciones.CurrentCell.ColumnIndex

        ' comprobar si la celda en edición corresponde a la columna que se requiera
        If columna = 8 Then
            ' Obtener caracter  
            Dim caracter As Char = e.KeyChar

            ' referencia a la celda  
            Dim txt As TextBox = CType(sender, TextBox)

            ' comprobar si es un número con isNumber, si es el backspace, si el caracter  
            ' es el separador decimal, y que no contiene ya el separador  

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



    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Dim contadorFilas As Integer = 0
        For Each dato As DataGridViewRow In grdDeducciones.Rows
            contadorFilas += 1
        Next
        If contadorFilas > 0 Then

            Dim mensajeExito As New ConfirmarForm
            mensajeExito.mensaje = "¿Estas seguro de querer realizar el cierre de deducciones? "

            If mensajeExito.ShowDialog = DialogResult.OK Then
                btnGuardar.Enabled = False
                btnBuscar.Enabled = False
                guardarEdicionDeduccion()
                grdDeducciones.Rows.Clear()
                lblIdSemanaNomina.Text = ""
            End If
        End If
    End Sub

    Public Sub guardarEdicionDeduccion()



        Dim ObjDedu As New Entidades.Deducciones
        Dim objBU As New Negocios.DeduccionesBU
        Dim contadorTrue As Integer = 0

        For Each row As DataGridViewRow In grdDeducciones.Rows
            '         
            '@decx_deduccionid,

            '@decx_usuariomodifico as integer,
            '@decx_estatus as nvarchar(1),

            '@pagodecx_pagoid as integer,
            '@pagodecx_abono as money,
            '@pagodecx_saldoanterior as money,
            '@pagodecx_saldonuevo as money

            ObjDedu.PidDeduccion = row.Cells("clmIdDeduccion").Value
            ObjDedu.PidModifico = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid

            If row.Cells("clmSaldoNuevo").Value = 0 Then
                ObjDedu.PEstatus = "C"
            Else
                ObjDedu.PEstatus = "B"
            End If


            ObjDedu.PPagoID = row.Cells("clmIdPago").Value
            ObjDedu.Pabono = row.Cells("clmAbono").Value
            ObjDedu.PSaldoAnterior = row.Cells("clmSaldo").Value
            ObjDedu.PSaldo = row.Cells("clmSaldoNuevo").Value


            objBU.GuardaEdicionDeduccion(ObjDedu)

        Next

        Dim mensajeExito2 As New ExitoForm
        mensajeExito2.MdiParent = Me.MdiParent
        mensajeExito2.mensaje = "Cierre semanal de deducciones guardado"
        mensajeExito2.Show()
        cmbNave.SelectedIndex = 0
        grdDeducciones.Rows.Clear()

    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub
End Class