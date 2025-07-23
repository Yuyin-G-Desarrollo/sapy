Imports System.Net

Public Class ListaColaboradoresPorCURP
    Private Curp As String
    Public Property PCurp As String
        Get
            Return Curp
        End Get
        Set(ByVal value As String)
            Curp = value
        End Set
    End Property

    Private Sub ListaColaboradoresPorCURP_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LlenarTabla()

        For Each column As DataGridViewImageColumn _
       In grdColaboradores.Columns
            column.ImageLayout = DataGridViewImageCellLayout.Stretch
            column.Description = "Stretched image layout"
            Exit For
        Next

    End Sub

    Public Sub LlenarTabla()
        grdColaboradores.Rows.Clear()
        Dim objColaboradorBU As New Negocios.ColaboradoresBU
        Dim listaColaboradores As New List(Of Entidades.Colaborador)

        listaColaboradores = objColaboradorBU.ListaColaboradoresFiltroCompletoCURP _
            ("", Curp, "", 0, 0, 0)
        For Each colaborador As Entidades.Colaborador In listaColaboradores
            AgregarFila(colaborador)
        Next
    End Sub

    Public Sub AgregarFila(ByVal colaborador As Entidades.Colaborador)
        Dim EntidadArchivos As New Entidades.ColaboradorExpediente
        Dim ObjArchivosBU As New Negocios.EnviodeArchivosBU
        EntidadArchivos = ObjArchivosBU.CredencialColaborador(colaborador.PColaboradorid)
        Dim celda As DataGridViewCell
        Dim fila As New DataGridViewRow

        celda = New DataGridViewImageCell

      
        EntidadArchivos = ObjArchivosBU.CredencialColaborador(colaborador.PColaboradorid)
        Try
            'Dim SourcePicture As String = "\\192.168.2.54\YuyinERP\" + EntidadArchivos.PCarpeta + "\" + EntidadArchivos.PNombreArchivo

            'PictureBox1.Image = Image.FromFile(SourcePicture)
            Dim objFTP As New Tools.TransferenciaFTP
            Dim request = DirectCast(WebRequest.Create(objFTP.obtenerURL), FtpWebRequest)
            request.Credentials = New NetworkCredential(objFTP.obtenerUsuario, objFTP.obtenerContrasena)
            Dim Carpeta As String = ""


            Dim tabla() As String
            tabla = Split(EntidadArchivos.PCarpeta, "\")

            For n = 0 To UBound(tabla, 1)
                Carpeta += tabla(n) + "/"
            Next

            Dim Stream As System.IO.Stream
            Stream = objFTP.StreamFile(Carpeta, EntidadArchivos.PNombreArchivo)
            celda.Value = Image.FromStream(Stream)
        Catch ex As Exception

        End Try
        fila.Cells.Add(celda)

        celda = New DataGridViewTextBoxCell
        celda.Value = colaborador.PColaboradorid
        fila.Cells.Add(celda)

        celda = New DataGridViewTextBoxCell
        celda.Value = colaborador.PNombre.ToUpper + " " + colaborador.PApaterno.ToUpper + " " + colaborador.PAmaterno.ToUpper
        fila.Cells.Add(celda)

        celda = New DataGridViewTextBoxCell
        celda.Value = colaborador.PMotivosFiniquito.PNombre
        fila.Cells.Add(celda)

        celda = New DataGridViewTextBoxCell
        celda.Value = colaborador.PFiniquitos.PJustificacion
        fila.Cells.Add(celda)

        Dim laboral As New Entidades.ColaboradorLaboral
        Dim objLaboralBU As New Negocios.ColaboradorLaboralBU
        laboral = objLaboralBU.buscarInformacionLaboral(colaborador.PColaboradorid)
        If Not IsNothing(laboral) Then
            celda = New DataGridViewTextBoxCell
            If Not IsNothing(laboral.PNaveId) Then
                celda.Value = laboral.PNaveId.PNombre
            End If
            fila.Cells.Add(celda)

            celda = New DataGridViewTextBoxCell
            If Not IsNothing(laboral.PDepartamentoId) Then
                celda.Value = laboral.PDepartamentoId.DNombre
            End If
            fila.Cells.Add(celda)

            celda = New DataGridViewTextBoxCell
            If Not IsNothing(laboral.PDepartamentoId) Then
                celda.Value = laboral.PPuestoId.PNombre
            End If
            fila.Cells.Add(celda)
        End If
        fila.Height = 120
        grdColaboradores.Rows.Add(fila)



    End Sub

    Private Sub grdColaboradores_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdColaboradores.CellDoubleClick
        If e.RowIndex >= 0 Then
            Dim credencias As New CredencialColaboradorForm
            credencias.PColaboradorID = grdColaboradores.Rows(e.RowIndex).Cells("colId").Value
            credencias.MdiParent = MdiParent
            credencias.Show()

        End If
    End Sub
End Class