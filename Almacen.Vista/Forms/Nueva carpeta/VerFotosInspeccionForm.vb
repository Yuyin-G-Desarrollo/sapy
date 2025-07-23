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
    Public Devuelto As String = String.Empty
    Public Piel As String = String.Empty
    Public Lote As String = String.Empty
    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub VerFotosInspeccionForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            Cursor = Cursors.WaitCursor
            imgFoto1.ImageLocation = Foto1
            imgFoto2.ImageLocation = Foto2

            lblIncidencia.Text = Incidencia
            lblAtado.Text = NumeroAtado
            lblClasificacion.Text = Clasificacion
            lblCodigoPar.Text = CodigoPar
            lblColeccion.Text = Coleccion
            lblColor.Text = Color
            lblCorrida.Text = Corrida
            lblDepartamento.Text = Departamento
            lblDevuelto.Text = Devuelto
            lblModelo.Text = Modelo
            lblPiel.Text = Piel
            lblTalla.Text = Talla
            lblLote.Text = Lote

            Cursor = Cursors.Default
        Catch ex As Exception

        End Try
    End Sub

End Class