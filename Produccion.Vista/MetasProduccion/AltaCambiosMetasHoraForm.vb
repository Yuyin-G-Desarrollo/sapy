Imports Produccion.Negocios
Imports Tools

Public Class AltaCambiosMetasHoraForm
    Dim ContinuaProceso As Boolean = False
    Dim ContinuarProcesoEditado As Boolean = False
    Private Sub AltaCambiosMetasHoraForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If tipoAccion = "Editar" Then
            EditarMetas()
        Else
            AltaMetas()
        End If
    End Sub

    Dim Hora As String
    Dim pares As Integer
    Dim tipoAccion As String
    Dim idMetaProduccionMT As Integer
    Dim idMetaHora As Integer
    Dim tablaDatos As DataTable

    Public Property formHora As String
        Get
            Return Hora
        End Get
        Set(value As String)
            Hora = value
        End Set
    End Property

    Public Property formPares As Integer
        Get
            Return pares
        End Get
        Set(value As Integer)
            pares = value
        End Set
    End Property

    Public Property formTipoAccion As String
        Get
            Return tipoAccion
        End Get
        Set(value As String)
            tipoAccion = value
        End Set
    End Property

    Public Property formIdMetaProduccionMT As Integer
        Get
            Return idMetaProduccionMT
        End Get
        Set(value As Integer)
            idMetaProduccionMT = value
        End Set
    End Property

    Public Property formIdMetaHora As Integer
        Get
            Return idMetaHora
        End Get
        Set(value As Integer)
            idMetaHora = value
        End Set
    End Property

    Public Property formTablaMetas As DataTable
        Get
            Return tablaDatos
        End Get
        Set(value As DataTable)
            tablaDatos = value
        End Set
    End Property

    Private Sub btn_Cerrar_Click(sender As Object, e As EventArgs) Handles btn_Cerrar.Click
        Me.Close()
    End Sub

    Private Sub btn_Cancelar_Click(sender As Object, e As EventArgs) Handles btn_Cancelar.Click
        nud_Hora.ResetText()
        nud_Min.ResetText()
        txt_Pares.Text = "0"
    End Sub

    Private Sub btn_Aceptar_Click(sender As Object, e As EventArgs) Handles btn_Aceptar.Click
        Dim objBu As New MetasProduccionBU
        Dim mensajeExito As New ExitoForm
        Dim mensajeError As New ErroresForm
        Dim mensajeConfirmar As New ConfirmarForm
        Dim mensajeAdvertencia As New AdvertenciaForm
        Dim cantidad As Integer
        Dim hora As String
        Dim idMetaProduccion As Integer
        Dim idMetaHora As Integer
        Dim TablaConfirmacion As DataTable
        Dim respuesta As Integer = 0

        cantidad = Convert.ToInt32(txt_Pares.Text)

        If Convert.ToString(nud_Min.Value) = "0" Then
            hora = Convert.ToString(nud_Hora.Value) + ":" + "00"
        Else
            hora = Convert.ToString(nud_Hora.Value) + ":" + Convert.ToString(nud_Min.Value)
        End If

        idMetaProduccion = formIdMetaProduccionMT

        If formTipoAccion = "Alta" Then
            If cantidad > 0 Then
                FuncionValidadora(cantidad, hora, idMetaProduccion)
                If ContinuaProceso = True Then

                    TablaConfirmacion = objBu.MetasProduccionConfigGlobal_ABC(formTipoAccion, hora, cantidad, 0, idMetaProduccion)

                    For Each row As DataRow In TablaConfirmacion.Rows
                        If TablaConfirmacion.Rows.Count > 0 Then
                            respuesta = row.Item("Mensaje").ToString()
                        End If
                    Next

                End If
            End If
        ElseIf formTipoAccion = "Editar" Then
            mensajeConfirmar.mensaje = "¿Está seguro de modificar esta meta? El proceso no se podrá revertir."
            If mensajeConfirmar.ShowDialog() = Windows.Forms.DialogResult.OK Then
                ValidarMetasAEditar(cantidad, hora)
                If ContinuarProcesoEditado = True Then

                    idMetaHora = formIdMetaHora
                    TablaConfirmacion = objBu.MetasProduccionConfigGlobal_ABC(formTipoAccion, "", cantidad, idMetaHora, 0)

                    For Each row As DataRow In TablaConfirmacion.Rows
                        If TablaConfirmacion.Rows.Count > 0 Then
                            respuesta = row.Item("Mensaje").ToString()
                        End If
                    Next
                Else
                    respuesta = 0
                End If
            Else
                respuesta = 3
            End If
        End If

        If respuesta = 1 Then
            mensajeExito.mensaje = "Se ha registrado la nueva meta."
            mensajeExito.ShowDialog()
        ElseIf respuesta = 2 Then
            mensajeExito.mensaje = "Se ha realizado el cambio correctamente."
            mensajeExito.ShowDialog()
        ElseIf respuesta = 0 Then
            mensajeAdvertencia.mensaje = "Favor de verificar horas y cantidades ya existentes con las que se están agregando."
            mensajeAdvertencia.ShowDialog()
        ElseIf respuesta = 3 Then
            'Console.WriteLine("Se cancelo la acción.")
        Else
            mensajeError.mensaje = "Ocurrió un error en el transcurso de la solicitud."
            mensajeError.ShowDialog()
        End If

    End Sub

    Public Sub EditarMetas()
        Dim hora As String = formHora.Substring(0, 2)
        Dim minutos As String = formHora.Substring(3, 2)
        nud_Hora.Value = Convert.ToDecimal(hora)
        nud_Min.Value = Convert.ToDecimal(minutos)
        txt_Pares.Text = formPares
        Me.Text = "Editar Meta Hora"
        lblTitulo.Text = "Editar Meta Hora"
    End Sub

    Public Sub AltaMetas()
        Me.Text = "Alta Meta Hora"
        lblTitulo.Text = "Alta Meta Hora"
    End Sub

    Public Function FuncionValidadora(ByVal cantidad As Integer, ByVal horas As String, ByVal idMetaproduccion As Integer)
        Dim objBU As New MetasProduccionBU
        Dim tablaConfirmacion As DataTable
        Dim valorConfirmado As Integer = 0
        If formTipoAccion = "Editar" And cantidad = 0 Then
            ContinuaProceso = True
        Else

            tablaConfirmacion = objBU.MetasProduccionConfirmar(cantidad, horas, idMetaproduccion)

            For Each row As DataRow In tablaConfirmacion.Rows
                If tablaConfirmacion.Rows.Count > 0 Then
                    valorConfirmado = Convert.ToInt32(row.Item("Mensaje"))
                End If
            Next

            If valorConfirmado = 1 Then
                ContinuaProceso = True
            Else
                ContinuaProceso = False
            End If
        End If
        Return ContinuaProceso
    End Function

    Public Function ValidarMetasAEditar(ByVal cantidad As Integer, ByVal horas As String)
        Dim tablaEditar As New MetasHoraForm
        Dim PosAnterior As Integer
        Dim PosSiguiente As Integer
        'Esta parte valida que no agregue más segun la meta por cada hora, tiene que estas coherente la cantidad de cada una.
        If formTipoAccion = "Editar" And cantidad = 0 Then
            ContinuarProcesoEditado = True
            Return ContinuarProcesoEditado
        Else
            For i As Integer = 0 To formTablaMetas.Rows.Count - 1
                If formTablaMetas.Rows(i).Item("Hora").ToString() = Hora Then
                    PosAnterior = i - 1
                    PosSiguiente = i + 1
                    If PosAnterior = -1 Then
                        If formTablaMetas.Rows(PosSiguiente).Item("Cantidad") > cantidad Then
                            ContinuarProcesoEditado = True
                            Return ContinuarProcesoEditado
                        End If
                    ElseIf PosSiguiente > formTablaMetas.Rows.Count - 1 Then
                        If formTablaMetas.Rows(PosAnterior).Item("Cantidad") < cantidad Then
                            ContinuarProcesoEditado = True
                            Return ContinuarProcesoEditado
                        End If
                    Else
                        If formTablaMetas.Rows(PosAnterior).Item("Cantidad") < cantidad And formTablaMetas.Rows(PosSiguiente).Item("Cantidad") > cantidad Then
                            ContinuarProcesoEditado = True
                            Return ContinuarProcesoEditado
                        ElseIf formTablaMetas.Rows(PosSiguiente).Item("Cantidad") = 0 Then
                            If formTablaMetas.Rows(PosAnterior).Item("Cantidad") < cantidad Then
                                ContinuarProcesoEditado = True
                                Return ContinuarProcesoEditado
                            End If
                        End If
                    End If
                Else
                    ContinuarProcesoEditado = False
                End If
            Next
        End If
        Return ContinuarProcesoEditado
    End Function

End Class