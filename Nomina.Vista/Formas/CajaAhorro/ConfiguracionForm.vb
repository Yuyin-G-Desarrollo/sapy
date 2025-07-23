Imports Tools

Public Class ConfiguracionForm

    Public IdCajaAhorro As Int32 = 40
    Public Nave As String = ""
    Public Periodo As String = ""


    Private Sub ConfiguracionForm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        grdConfiguracion.Styles.EmptyArea.BackColor = Color.LightSteelBlue

        Inicializa()

        grdConfiguracion(0, 1) = "Semanas Perdidas"
        grdConfiguracion(0, 2) = "Semanas Perdidas"

        grdConfiguracion.Rows(0).AllowMerging = True

        grdConfiguracion(1, 1) = "Inicio"
        grdConfiguracion(1, 2) = "Fin"
        grdConfiguracion(1, 3) = "%"
        'Tools.FormatoCtrls.formato(Me)

    End Sub


    Private Sub Inicializa()

        Dim objConfiguracionBU As New Nomina.Negocios.ConfiguracionCajaNaveBU
        Dim objConfiguracion As New List(Of Entidades.ConfiguracionCajaNave)

        objConfiguracion = objConfiguracionBU.Listar(IdCajaAhorro)

        grdConfiguracion.Rows.Count = 2

        For Each Configuracion In objConfiguracion
            AgregarFila(Configuracion)
        Next

        grdConfiguracion.AllowAddNew = True
        grdConfiguracion.AllowDelete = True
        grdConfiguracion.AllowEditing = True
        grdConfiguracion.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        grdConfiguracion.AllowFiltering = True


        For i = 2 To grdConfiguracion.Rows.Count - 2
            grdConfiguracion(i, 0) = i - 1
        Next


        lblNombreNave.Text = Nave
        lblConceptoPeriodo.Text = Periodo

    End Sub

    Private Sub grdConfiguracion_AfterAddRow(sender As Object, e As C1.Win.C1FlexGrid.RowColEventArgs) Handles grdConfiguracion.AfterAddRow
        FijarRenglon()
    End Sub


    Private Sub grdConfiguracion_BeforeDeleteRow(sender As System.Object, e As C1.Win.C1FlexGrid.RowColEventArgs) Handles grdConfiguracion.BeforeDeleteRow

        e.Cancel = True

        If grdConfiguracion.Row > 2 And grdConfiguracion.Row < grdConfiguracion.Rows.Count - 1 Then
            grdConfiguracion.Rows(grdConfiguracion.Row).Visible = False
        End If

        FijarRenglon()

    End Sub

    Public Sub AgregarFila(ByVal configuracion As Entidades.ConfiguracionCajaNave)

        grdConfiguracion.AddItem("" & vbTab & configuracion.pSemanaInicial & vbTab & configuracion.pSemanaFinal & vbTab & configuracion.pInteres & vbTab & configuracion.pccnId)

    End Sub

    Public Sub AgregarFila(ByVal configuracion As Entidades.ConfiguracionCajaNave, id As Boolean)

        grdConfiguracion.AddItem("" & vbTab & configuracion.pSemanaInicial & vbTab & configuracion.pSemanaFinal & vbTab & configuracion.pInteres & vbTab & "")

    End Sub

    Private Sub btnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles btnGuardar.Click


        Dim resultado As String = String.Empty

        resultado = Validar()
        If resultado.Length = 0 Then
            'If MessageBox.Show("Desea guardar la informacion", "Confirmar Operacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
            '    Guardar()
            'End If

            Dim MensajeConfirmacion As New ConfirmarForm
            MensajeConfirmacion.mensaje = "¿ Desea guardar la información ?"
            MensajeConfirmacion.Text = "Confirmar Operacion"
            MensajeConfirmacion.StartPosition = FormStartPosition.CenterScreen

            If MensajeConfirmacion.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Guardar()
            End If
        Else
            Dim mensajeAdvertencia As New AdvertenciaForm
            mensajeAdvertencia.mensaje = resultado.ToString
            mensajeAdvertencia.ShowDialog()
        End If

    End Sub

    Private Function Validar() As String
        Validar = String.Empty
        Dim ultimorenglon As Int32 = 0
        If grdConfiguracion(2, "SemanaInicial") <> "0" Then
            Validar = "La semana de inicio del primer renglón tiene que empezar en cero."
            Exit Function
        End If

        For i = 2 To grdConfiguracion.Rows.Count - 1
            If grdConfiguracion.Rows(i).Visible = True Then
                If Not IsNumeric(grdConfiguracion.Rows(i)("SemanaInicial")) Then
                    Exit For
                Else
                    ultimorenglon = i
                End If
            End If
        Next

        'If grdConfiguracion(ultimorenglon, "SemanaFinal") <> "52" Then
        '    Validar = "La semana final del último renglón tiene que terminar en 52."
        '    Exit Function
        'End If

        For i = 2 To grdConfiguracion.Rows.Count - 1
            If grdConfiguracion.Rows(i).Visible = True Then
                If IsNumeric(grdConfiguracion.Rows(i)("SemanaInicial")) Then
                    If Not IsNumeric(grdConfiguracion.Rows(i)("SemanaFinal")) Then
                        Validar = "La semana final no puede quedar vacía para el renglón: " & grdConfiguracion(i, 0).ToString
                        Exit Function
                    End If

                    If Not IsNumeric(grdConfiguracion.Rows(i)("Interes")) Then
                        Validar = "El interés no puede quedar vacío para el renglón: " & grdConfiguracion(i, 0).ToString
                        Exit Function
                    End If
                End If
            End If
        Next

        For i = 2 To grdConfiguracion.Rows.Count - 1
            If grdConfiguracion.Rows(i).Visible = True Then
                If IsNumeric(grdConfiguracion.Rows(i)("SemanaInicial")) Then
                    If CLng(grdConfiguracion.Rows(i)("SemanaFinal")) < CLng(grdConfiguracion.Rows(i)("SemanaInicial")) Then
                        Validar += "La semana final no puede ser menor a la semana inicial, renglón: " & grdConfiguracion(i, 0).ToString
                    End If
                End If
            End If
        Next


    End Function

    Private Sub Guardar()

        Dim objCajaAhorro As New Entidades.CajaAhorro
        Dim objCajaAhorroBU As New Nomina.Negocios.CajaAhorroBU

        objCajaAhorro = objCajaAhorroBU.ObtenerCajaAhorro(IdCajaAhorro)


        For i = 2 To grdConfiguracion.Rows.Count - 2
            If IsNumeric(grdConfiguracion.Rows(i)("SemanaInicial")) Then
                Dim objConfiguracionCajaNave As New Entidades.ConfiguracionCajaNave
                Dim objconfiguracionCajaNaveBU As New Nomina.Negocios.ConfiguracionCajaNaveBU

                objConfiguracionCajaNave.pccnId = IIf(grdConfiguracion.Rows(i)("Id") = "", "0", grdConfiguracion.Rows(i)("Id"))
                objConfiguracionCajaNave.pCajaAhorro = objCajaAhorro
                objConfiguracionCajaNave.pSemanaInicial = grdConfiguracion.Rows(i)("SemanaInicial")
                objConfiguracionCajaNave.pSemanaFinal = grdConfiguracion.Rows(i)("SemanaFinal")
                objConfiguracionCajaNave.pInteres = grdConfiguracion.Rows(i)("Interes")


                If grdConfiguracion.Rows(i).Visible = False Then
                    If grdConfiguracion.Rows(i)("Id") <> "" Then
                        'ELIMINAR
                        objconfiguracionCajaNaveBU.EliminarConfiguracionCajaNave(objConfiguracionCajaNave)
                    End If
                Else
                    If grdConfiguracion.Rows(i)("Id") <> "" Then
                        'ACTUALIZAR
                        objconfiguracionCajaNaveBU.EditarConfiguracionCajaNave(objConfiguracionCajaNave)
                    Else
                        'INSERTAR
                        objconfiguracionCajaNaveBU.AltaConfiguracionCajaNave(objConfiguracionCajaNave)
                    End If
                End If
            End If
        Next

        Me.Close()

    End Sub



    Private Sub grdConfiguracion_ValidateEdit(sender As System.Object, e As C1.Win.C1FlexGrid.ValidateEditEventArgs) Handles grdConfiguracion.ValidateEdit

        If Not IsNumeric(grdConfiguracion.Editor.Text) = True Then
            Dim mensajeAdvertencia As New AdvertenciaForm
            mensajeAdvertencia.mensaje = "Introduce un número"
            mensajeAdvertencia.ShowDialog()
            e.Cancel = True
            Exit Sub
        End If


        If e.Col = grdConfiguracion.Cols("SemanaInicial").Index Then
            If CLng(grdConfiguracion.Editor.Text) < 0 Or CLng(grdConfiguracion.Editor.Text) > 52 Then
                Dim mensajeAdvertencia As New AdvertenciaForm
                mensajeAdvertencia.mensaje = "El rango de la semana tiene que estar entre 0 y 52."
                mensajeAdvertencia.ShowDialog()
                e.Cancel = True
                Exit Sub
            End If
        End If

        If e.Col = grdConfiguracion.Cols("SemanaFinal").Index Then
            If CLng(grdConfiguracion.Editor.Text) < 0 Or CLng(grdConfiguracion.Editor.Text) > 52 Then
                Dim mensajeAdvertencia As New AdvertenciaForm
                mensajeAdvertencia.mensaje = "El rango de la semana tiene que estar entre 0 y 52."
                mensajeAdvertencia.ShowDialog()
                e.Cancel = True
                Exit Sub
            End If
        End If



        If e.Col = grdConfiguracion.Cols("Interes").Index Then
            If CLng(grdConfiguracion.Editor.Text) < 0 Or CLng(grdConfiguracion.Editor.Text) > 100 Then
                Dim mensajeAdvertencia As New AdvertenciaForm
                mensajeAdvertencia.mensaje = "El interés tiene que estar entre 0 y 100."
                mensajeAdvertencia.ShowDialog()
                e.Cancel = True
                Exit Sub
            End If
        End If


        If e.Col = grdConfiguracion.Cols("SemanaInicial").Index Or e.Col = grdConfiguracion.Cols("SemanaFinal").Index Then
            For i = 2 To grdConfiguracion.Rows.Count - 1
                If i <> e.Row Then
                    If grdConfiguracion.Rows(i).Visible = True Then
                        If IsNumeric(grdConfiguracion.Rows(i)("SemanaInicial")) Then
                            If CLng(grdConfiguracion.Editor.Text) >= CLng(grdConfiguracion.Rows(i)("SemanaInicial")) And CLng(grdConfiguracion.Editor.Text) <= CLng(grdConfiguracion.Rows(i)("SemanaFinal")) Then
                                Dim mensajeAdvertencia As New AdvertenciaForm
                                mensajeAdvertencia.mensaje = "La semana ya pertenece a un rango existente, cámbielo por otro."
                                mensajeAdvertencia.ShowDialog()
                                e.Cancel = True
                                Exit Sub
                            End If
                        End If
                    End If
                End If
            Next
        End If


    End Sub

    Private Sub FijarRenglon()

        Dim renglon As Int32
        renglon = 0
        For i = 2 To grdConfiguracion.Rows.Count - 2
            If grdConfiguracion.Rows(i).Visible = True Then
                renglon += 1
                grdConfiguracion(i, 0) = renglon
            End If
        Next

    End Sub

    Private Sub btnRegresar_Click(sender As System.Object, e As System.EventArgs) Handles btnRegresar.Click
        Me.Close()
    End Sub


    Private Sub ObtenerUltimaConfiguracion()

        Dim objConfiguracionBU As New Nomina.Negocios.ConfiguracionCajaNaveBU
        Dim objConfiguracion As New List(Of Entidades.ConfiguracionCajaNave)


        objConfiguracion = objConfiguracionBU.ListarConfiguracionAnterior(IdCajaAhorro)

        If objConfiguracion.Count <= 0 Then
            Dim mensajeAdvertencia As New AdvertenciaForm
            mensajeAdvertencia.mensaje = "No hay una configuración previa para esta nave."
            mensajeAdvertencia.ShowDialog()

            Exit Sub
        End If

        grdConfiguracion.AllowAddNew = False

        For i = 2 To grdConfiguracion.Rows.Count - 1
            grdConfiguracion.Rows(i).Visible = False
        Next

        For Each Configuracion In objConfiguracion
            AgregarFila(Configuracion, True)
        Next

        grdConfiguracion.AllowAddNew = True

        Dim j As Long = 1

        For i = 2 To grdConfiguracion.Rows.Count - 2
            If grdConfiguracion.Rows(i).Visible = True Then
                grdConfiguracion(i, 0) = j
                j += 1
            End If
        Next

        lblNombreNave.Text = Nave
        lblConceptoPeriodo.Text = Periodo

    End Sub


    Private Sub btnCopiar_Click(sender As System.Object, e As System.EventArgs) Handles btnCopiar.Click
        ObtenerUltimaConfiguracion()
    End Sub

    Private Sub lblEjemplo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblEjemplo.Click

    End Sub
End Class