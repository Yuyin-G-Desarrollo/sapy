Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports Tools

Public Class CopiarClienteForm

    Dim ObjBU As New Negocios.ReplicaClientesBU
    Dim ListaClientes As New List(Of Entidades.Cliente)

    Public ClienteSAYID As Integer = 0
    Public ClienteSICYID As Integer = 0
    Public NombreCliente As String = String.Empty
    Dim UsuarioId As Integer = 0

    Dim ListaMarcas As New List(Of Entidades.Marcas)
    Dim ListaMarcasReplica As New List(Of Entidades.Marcas)

    Private Sub CopiarClienteForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        lblNombreCliente.Text = NombreCliente
        txtNombreCliente.Text = NombreCliente + " (M,G)"
        UsuarioId = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        CargarMarcaClienteOriginal(ClienteSAYID)

    End Sub


    Private Sub btnCopiarCliente_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Dim MarcaSICYOriginalId As String = String.Empty
        Dim MarcaSICYReplicaId As String = String.Empty
        Dim MarcaSAYOriginalID As String = String.Empty
        Dim MarcaSAYReplicaID As String = String.Empty

        Dim formaConfirmacion As New ConfirmarForm
        formaConfirmacion.StartPosition = FormStartPosition.CenterScreen
        formaConfirmacion.mensaje = "¿Estas seguro que deseas replicar el cliente?"

        Try
            Cursor = Cursors.WaitCursor
            If formaConfirmacion.ShowDialog() = Windows.Forms.DialogResult.OK Then
                If ValidarMarcasSeleccionadas() = True Then
                    If txtNombreCliente.Text.Trim() <> String.Empty Then
                        If ObjBU.ValidaExisteReplicaCliente(ClienteSAYID) = False Then
                            If ObjBU.ValidarNombreCliente(txtNombreCliente.Text.Trim()) = False Then

                                MarcaSICYOriginalId = ObtenerMarcaSICYOriginalID()
                                MarcaSICYReplicaId = ObtenerMarcaSICYReplicaID()
                                MarcaSAYOriginalID = ObtenerMarcaSAYOriginalID()
                                MarcaSAYReplicaID = ObtenerMarcaSAYReplicaID()

                                If ObjBU.ReplicarCliente(ClienteSAYID, ClienteSICYID, txtNombreCliente.Text.Trim(), UsuarioId, MarcaSICYOriginalId, MarcaSICYReplicaId, MarcaSAYOriginalID, MarcaSAYReplicaID) = True Then
                                    Utilerias.show_message(Utilerias.TipoMensaje.Exito, "Se ha replicado correctamente el cliente.")
                                    Me.DialogResult = DialogResult.OK
                                    Me.Close()
                                Else
                                    Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "Ocurrio algun error en la replicacion.Favor de comunicarse a sistemas.")
                                    btnAceptar.Enabled = False
                                End If

                            Else
                                Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "El nombre del cliente ya existe.")
                            End If
                        Else
                            Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "El cliente ya se encuentra replicado.")
                            btnAceptar.Enabled = False
                        End If

                    Else
                        Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "No se ha capturado el nombre del cliente.")
                    End If

                End If
            End If



            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, ex.Message.ToString())
        End Try

    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub CargarMarcaClienteOriginal(ByVal ClienteId As Integer)

        ListaMarcas = ObjBU.ConsultaMarcasCliente(ClienteId)
        grdClienteOriginalMarca.DataSource = ListaMarcas




        'viewClienteOriginalMarca.BestFitColumns()
        DiseñoGrid.DiseñoBaseGrid(viewClienteOriginalMarca)
        DiseñoGrid.EstiloColumna(viewClienteOriginalMarca, "PSeleccion", " ", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Like, True, True, 60, False, Nothing, "")
        DiseñoGrid.EstiloColumna(viewClienteOriginalMarca, "PMarcaId", "MarcaId", False, DevExpress.XtraGrid.Columns.AutoFilterCondition.Like, False, True, 60, False, Nothing, "")
        DiseñoGrid.EstiloColumna(viewClienteOriginalMarca, "PDescripcion", "Marca", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Like, False, True, 60, False, Nothing, "")

        DiseñoGrid.EstiloColumna(viewClienteOriginalMarca, "PCodigo", "Marca", False, DevExpress.XtraGrid.Columns.AutoFilterCondition.Like, False, True, 60, False, Nothing, "")
        DiseñoGrid.EstiloColumna(viewClienteOriginalMarca, "PActivo", "Marca", False, DevExpress.XtraGrid.Columns.AutoFilterCondition.Like, False, True, 60, False, Nothing, "")
        DiseñoGrid.EstiloColumna(viewClienteOriginalMarca, "PSicyCodigo", "Marca", False, DevExpress.XtraGrid.Columns.AutoFilterCondition.Like, False, True, 60, False, Nothing, "")
        DiseñoGrid.EstiloColumna(viewClienteOriginalMarca, "PClienteMarca", "Marca", False, DevExpress.XtraGrid.Columns.AutoFilterCondition.Like, False, True, 60, False, Nothing, "")



        viewClienteOriginalMarca.OptionsView.ColumnAutoWidth = True

    End Sub


    Private Sub AgregarMarcaReplica(ByVal Marca As Entidades.Marcas)
        ListaMarcasReplica.Add(Marca)
        grdClienteReplicaMarca.DataSource = ListaMarcasReplica
        DiseñoGridCopiarClienteMarca()
    End Sub

    Private Sub QuitarMarca(ByVal Marca As Entidades.Marcas)
        ListaMarcasReplica.Remove(Marca)
        grdClienteReplicaMarca.DataSource = ListaMarcasReplica

        DiseñoGridCopiarClienteMarca()
    End Sub

    Private Sub viewClienteOriginalMarca_RowCellClick(sender As Object, e As RowCellClickEventArgs) Handles viewClienteOriginalMarca.RowCellClick

    End Sub

    Private Sub viewClienteOriginalMarca_CellValueChanging(sender As Object, e As CellValueChangedEventArgs) Handles viewClienteOriginalMarca.CellValueChanging
        Dim MarcaId As Integer = 0
        Dim Marca As Entidades.Marcas

        If e.Column.FieldName = "PSeleccion" Then
            MarcaId = viewClienteOriginalMarca.GetRowCellValue(e.RowHandle, "PMarcaId")
            Marca = ListaMarcas.Where(Function(x) x.PMarcaId = MarcaId).FirstOrDefault

            If e.Value = True Then
                QuitarMarca(Marca)
            Else
                AgregarMarcaReplica(Marca)
            End If

        End If
    End Sub

    Public Sub DiseñoGridCopiarClienteMarca()
        DiseñoGrid.DiseñoBaseGrid(viewClienteReplicaMarcas)
        DiseñoGrid.EstiloColumna(viewClienteReplicaMarcas, "PSeleccion", " ", False, DevExpress.XtraGrid.Columns.AutoFilterCondition.Like, True, True, 60, False, Nothing, "")
        DiseñoGrid.EstiloColumna(viewClienteReplicaMarcas, "PMarcaId", "MarcaId", False, DevExpress.XtraGrid.Columns.AutoFilterCondition.Like, False, True, 60, False, Nothing, "")
        DiseñoGrid.EstiloColumna(viewClienteReplicaMarcas, "PDescripcion", "Marca", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Like, False, True, 60, False, Nothing, "")

        DiseñoGrid.EstiloColumna(viewClienteReplicaMarcas, "PCodigo", "Marca", False, DevExpress.XtraGrid.Columns.AutoFilterCondition.Like, False, True, 60, False, Nothing, "")
        DiseñoGrid.EstiloColumna(viewClienteReplicaMarcas, "PActivo", "Marca", False, DevExpress.XtraGrid.Columns.AutoFilterCondition.Like, False, True, 60, False, Nothing, "")
        DiseñoGrid.EstiloColumna(viewClienteReplicaMarcas, "PSicyCodigo", "Marca", False, DevExpress.XtraGrid.Columns.AutoFilterCondition.Like, False, True, 60, False, Nothing, "")
        DiseñoGrid.EstiloColumna(viewClienteReplicaMarcas, "PClienteMarca", "Marca", False, DevExpress.XtraGrid.Columns.AutoFilterCondition.Like, False, True, 60, False, Nothing, "")

        viewClienteReplicaMarcas.OptionsView.ColumnAutoWidth = True

    End Sub


    Private Function ValidarMarcasSeleccionadas() As Boolean
        Dim Resultado As Boolean = False
        Dim NumeroFilas As Integer = 0
        Dim FilasSeleccionadas As Integer = 0
        Dim EstaSeleccionado As Boolean = False

        If ListaMarcasReplica.Count = 0 Then
            Resultado = False
            Utilerias.show_message(Utilerias.TipoMensaje.Aviso, "El cliente a replicar no tiene marcas asignadas.")
        Else
            Resultado = True
        End If


        Cursor = Cursors.WaitCursor
        NumeroFilas = viewClienteOriginalMarca.DataRowCount
        For index As Integer = 0 To NumeroFilas Step 1

            EstaSeleccionado = CBool(viewClienteOriginalMarca.GetRowCellValue(viewClienteOriginalMarca.GetVisibleRowHandle(index), "PSeleccion"))
            If EstaSeleccionado = True Then
                FilasSeleccionadas += 1
            End If
        Next

        If FilasSeleccionadas = 0 Then
            Utilerias.show_message(Utilerias.TipoMensaje.Aviso, "El cliente original no tiene marcas asignadas.")
            Resultado = False
        Else
            Resultado = True
        End If


        Return Resultado

    End Function


    Public Function ObtenerMarcaSAYOriginalID() As String

        Dim NumeroFilas As Integer = 0
        Dim EstaSeleccionado As Boolean = False
        Dim MarcaSICYID As String = String.Empty

        Cursor = Cursors.WaitCursor

        NumeroFilas = viewClienteOriginalMarca.DataRowCount
        For index As Integer = 0 To NumeroFilas Step 1
            EstaSeleccionado = CBool(viewClienteOriginalMarca.GetRowCellValue(viewClienteOriginalMarca.GetVisibleRowHandle(index), "PSeleccion"))

            If EstaSeleccionado = True Then
                If MarcaSICYID = String.Empty Then
                    MarcaSICYID = viewClienteOriginalMarca.GetRowCellValue(viewClienteOriginalMarca.GetVisibleRowHandle(index), "PMarcaId")
                Else
                    MarcaSICYID = MarcaSICYID & "," & viewClienteOriginalMarca.GetRowCellValue(viewClienteOriginalMarca.GetVisibleRowHandle(index), "PMarcaId")
                End If

            End If
        Next

        Return MarcaSICYID

    End Function


    Public Function ObtenerMarcaSAYReplicaID() As String

        Dim NumeroFilas As Integer = 0
        Dim EstaSeleccionado As Boolean = False
        Dim MarcaSICYID As String = String.Empty

        Cursor = Cursors.WaitCursor

        NumeroFilas = viewClienteReplicaMarcas.DataRowCount
        For index As Integer = 0 To NumeroFilas Step 1
            If MarcaSICYID = String.Empty Then
                MarcaSICYID = viewClienteReplicaMarcas.GetRowCellValue(viewClienteReplicaMarcas.GetVisibleRowHandle(index), "PMarcaId")
            Else
                MarcaSICYID = MarcaSICYID & "," & viewClienteReplicaMarcas.GetRowCellValue(viewClienteReplicaMarcas.GetVisibleRowHandle(index), "PMarcaId")
            End If

        Next

        Return MarcaSICYID

    End Function


    Public Function ObtenerMarcaSICYOriginalID() As String
        Dim NumeroFilas As Integer = 0
        Dim EstaSeleccionado As Boolean = False
        Dim MarcaSICYID As String = String.Empty

        Cursor = Cursors.WaitCursor
        NumeroFilas = viewClienteOriginalMarca.DataRowCount
        For index As Integer = 0 To NumeroFilas Step 1
            EstaSeleccionado = CBool(viewClienteOriginalMarca.GetRowCellValue(viewClienteOriginalMarca.GetVisibleRowHandle(index), "PSeleccion"))

            If EstaSeleccionado = True Then
                If MarcaSICYID = String.Empty Then
                    MarcaSICYID = viewClienteOriginalMarca.GetRowCellValue(viewClienteOriginalMarca.GetVisibleRowHandle(index), "PSicyCodigo")
                Else
                    MarcaSICYID = MarcaSICYID & "," & viewClienteOriginalMarca.GetRowCellValue(viewClienteOriginalMarca.GetVisibleRowHandle(index), "PSicyCodigo")
                End If

            End If
        Next

        Return MarcaSICYID

    End Function

    Public Function ObtenerMarcaSICYReplicaID() As String
        Dim NumeroFilas As Integer = 0
        Dim EstaSeleccionado As Boolean = False
        Dim MarcaSICYID As String = String.Empty

        Cursor = Cursors.WaitCursor
        NumeroFilas = viewClienteReplicaMarcas.DataRowCount
        For index As Integer = 0 To NumeroFilas Step 1

            If MarcaSICYID = String.Empty Then
                MarcaSICYID = viewClienteReplicaMarcas.GetRowCellValue(viewClienteReplicaMarcas.GetVisibleRowHandle(index), "PSicyCodigo")
            Else
                MarcaSICYID = MarcaSICYID & "," & viewClienteReplicaMarcas.GetRowCellValue(viewClienteReplicaMarcas.GetVisibleRowHandle(index), "PSicyCodigo")
            End If
        Next

        Return MarcaSICYID

    End Function

    Private Sub btnAyuda_Click(sender As Object, e As EventArgs)

    End Sub
End Class