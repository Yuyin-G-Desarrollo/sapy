Public Class VerFotosInspeccionForm

    Public Foto1 As String = String.Empty
    Public Foto2 As String = String.Empty
    Public Incidencia As String = String.Empty
    Public Departamento As String = String.Empty
    Public Clasificacion As String = String.Empty
    Public NumeroAtado As String = String.Empty
    Public CodigoPar As String = String.Empty
    Public Modelo As String = String.Empty
    Public Coleccion As String = String.Empty
    Public Corrida As String = String.Empty
    Public Talla As String = String.Empty
    Public Color As String = String.Empty
    Public ParesDevuelto As String = String.Empty
    Public Piel As String = String.Empty
    Public Lote As String = String.Empty
    Public Observaciones As String = String.Empty
    Public Nave As String = String.Empty
    Public Cliente As String = String.Empty
    Public FechaRevision As String = String.Empty
    Public Rechazo As String = String.Empty
    Public Operador As String = String.Empty

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()

    End Sub

    Private Sub VerFotosInspeccionForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            Cursor = Cursors.WaitCursor
            If Foto1 = "" Then
                imgFoto1.ImageLocation = Foto2
            Else
                imgFoto1.ImageLocation = Foto1
            End If

            imgFoto1.ImageLocation = Foto1
            'imgFoto2.ImageLocation = Foto2
            txtCategoria.Text = Clasificacion
            TXTCLIENTE.Text = Cliente
            txtDEFECTO.Text = Incidencia
            ltxtModelo.Text = Modelo
            txtColeccion.Text = Coleccion
            txtLote.Text = Lote
            txtFecha.Text = FechaRevision
            txtDevuelto.Text = CDbl(ParesDevuelto).ToString("N0")
            txtRechazo.Text = Rechazo
            txtOperador.Text = Operador

            If ParesDevuelto <> "" Then
                If ParesDevuelto > "0" Then
                    txtDevuelto.ForeColor = Drawing.Color.Red
                End If
            End If

            lblNAve.Text = Nave
            Cursor = Cursors.Default
        Catch ex As Exception

        End Try
    End Sub


End Class