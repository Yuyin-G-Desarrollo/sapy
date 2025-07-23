Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Tools

Public Class MensajeConfirmarExcepcionForm

#Region "Variables Globales"

    Public OK As Boolean = False
    Public Alerta As Boolean = False
    Public Datos As New DataTable
    Public listaDeseleccion As List(Of String)
    Public listaSeleccion As List(Of String)
    Public listaNuevos As List(Of String)
    Private tipoGuardado As String = String.Empty
    Private ReadOnly idUsuario As Integer = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid

#End Region

    Private Sub MensajeConfirmarExcepcionForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InicializarVista(gridClientes)

        If Alerta Then
            Me.Top = (Me.Owner.Height - Me.Height) / 2
            Me.Left = (Me.Owner.Width - Me.Width) / 2
        End If
    End Sub

#Region "Panel Pie"

    Private Sub BtnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Dim id_Cliente = String.Empty
        Dim id_Cliente_Des = String.Empty
        Dim Cliente = String.Empty
        Dim Motivo = String.Empty
        Dim Solicita = String.Empty
        Dim objBU = New Negocios.MotivoExcepcionBU

        Try
            If Not tipoGuardado.Equals("Combinado") Then
                If tipoGuardado.Equals("Insertado") Then
                    For Each item In listaNuevos
                        For Each Row As UltraGridRow In gridClientes.Rows
                            If item = Row.Cells("ID").Value Then
                                id_Cliente = Row.Cells("ID").Value.ToString()
                                Cliente = Row.Cells("Nombre").Value.ToString()
                                Motivo = Row.Cells("Motivo").Value.ToString()
                                Solicita = Row.Cells("Solicita").Value.ToString()
                                objBU.GuardarExcepcion(id_Cliente, id_Cliente_Des, Motivo, tipoGuardado, idUsuario, Solicita, Cliente)
                            End If
                        Next
                    Next
                    OK = True
                Else
                    For Each Row As UltraGridRow In gridClientes.Rows
                        If id_Cliente <> "" Then
                            id_Cliente += ","
                        End If
                        id_Cliente += Row.Cells("ID").Value.ToString()
                        Motivo = Row.Cells("Motivo").Value.ToString()
                        Solicita = Row.Cells("Solicita").Value.ToString()
                    Next
                    objBU.GuardarExcepcion(id_Cliente, id_Cliente_Des, Motivo, tipoGuardado, idUsuario, Solicita, Cliente)
                    OK = True
                End If
            Else
                For Each item In listaSeleccion
                    For Each Row As UltraGridRow In gridClientes.Rows
                        If item = Row.Cells("ID").Value Then
                            If id_Cliente <> "" Then
                                id_Cliente += ","
                            End If
                            id_Cliente += Row.Cells("ID").Value.ToString()
                            Motivo = Row.Cells("Motivo").Value.ToString()
                            Solicita = Row.Cells("Solicita").Value.ToString()
                        End If
                    Next
                Next

                For Each item In listaDeseleccion
                    For Each Row As UltraGridRow In gridClientes.Rows
                        If item = Row.Cells("ID").Value Then
                            If id_Cliente_Des <> "" Then
                                id_Cliente_Des += ","
                            End If
                            id_Cliente_Des += Row.Cells("ID").Value.ToString()
                        End If
                    Next
                Next

                objBU.GuardarExcepcion(id_Cliente, id_Cliente_Des, Motivo, tipoGuardado, idUsuario, Solicita, Cliente)

                id_Cliente = String.Empty
                id_Cliente_Des = String.Empty
                Cliente = String.Empty
                Motivo = String.Empty
                Solicita = String.Empty

                If listaNuevos.Count > 0 Then
                    For Each item In listaNuevos
                        For Each Row As UltraGridRow In gridClientes.Rows
                            If item = Row.Cells("ID").Value Then
                                id_Cliente = Row.Cells("ID").Value.ToString()
                                Cliente = Row.Cells("Nombre").Value.ToString()
                                Motivo = Row.Cells("Motivo").Value.ToString()
                                Solicita = Row.Cells("Solicita").Value.ToString()
                                objBU.GuardarExcepcion(id_Cliente, id_Cliente_Des, Motivo, "Insertado", idUsuario, Solicita, Cliente)
                            End If
                        Next
                    Next
                End If

                OK = True
            End If
            'If OK Then
            '    Controles.Mensajes_Y_Alertas("EXITO", "Registro correcto.")
            'End If
        Catch ex As Exception
            Controles.Mensajes_Y_Alertas("ERROR", ex.Message)
            OK = False
        End Try

    End Sub

    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Close()
    End Sub

#End Region

#Region "Metodos Privados"

    Private Sub InicializarVista(grid As UltraGrid)
        grid.DataSource = Nothing

        Try
            lblMensaje.Text = "Se realizarán los siguientes cambios"

            If listaSeleccion.Count > 0 Then
                If listaDeseleccion.Count > 0 Then
                    tipoGuardado = "Combinado"
                ElseIf listaNuevos.Count > 0 Then
                    tipoGuardado = "Combinado"
                Else
                    tipoGuardado = "Activacion"
                End If
            End If

            If listaDeseleccion.Count > 0 Then
                If listaSeleccion.Count > 0 Then
                    tipoGuardado = "Combinado"
                ElseIf listaNuevos.Count > 0 Then
                    tipoGuardado = "Combinado"
                Else
                    tipoGuardado = "Desactivacion"
                End If
            End If

            If listaNuevos.Count > 0 Then
                If listaSeleccion.Count > 0 Then
                    tipoGuardado = "Combinado"
                ElseIf listaDeseleccion.Count > 0 Then
                    tipoGuardado = "Combinado"
                Else
                    tipoGuardado = "Insertado"
                End If
            End If

            grid.DataSource = Datos

            For Each col In grid.DisplayLayout.Bands(0).Columns
                col.CellAppearance.TextHAlign = HAlign.Left
            Next

            With grid.DisplayLayout
                .Bands(0).Columns(0).Hidden = True
                .PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
                .AutoFitStyle = AutoFitStyle.ResizeAllColumns
                .Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
                .Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
                .Override.RowSelectorWidth = 35
                .Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
                .Override.CellClickAction = CellClickAction.RowSelect
                .Override.AllowRowFiltering = DefaultableBoolean.True
                .Override.AllowAddNew = AllowAddNew.No
            End With

        Catch ex As Exception
            Controles.Mensajes_Y_Alertas("ERROR", ex.Message)
        End Try

    End Sub

#End Region

End Class