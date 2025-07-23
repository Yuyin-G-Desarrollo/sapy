Imports System.IO
Imports Tools

Public Class ImprimirEtiquetasPedidosMuestrasForm


    Private _ListaInt As IList(Of Integer)
    Public Property ListaInt() As IList(Of Integer)
        Get
            Return _ListaInt
        End Get
        Set(ByVal value As IList(Of Integer))
            _ListaInt = value
        End Set
    End Property

    Private _ListaStr As List(Of String)
    Public Property ListaStr() As List(Of String)
        Get
            Return _ListaStr
        End Get
        Set(ByVal value As List(Of String))
            _ListaStr = value
        End Set
    End Property

    Private _ImpresionPorEtiqueta As Boolean = False
    Public WriteOnly Property ImpresionPorEtiqueta() As Boolean
        Set(ByVal value As Boolean)
            _ImpresionPorEtiqueta = value
        End Set
    End Property

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click

        Dim accion As Integer = 0
        Dim obj As New Object
        Dim archivo As New Object
        Dim ruta As String = "C:\SAY\Etiquetas.txt"
        Dim sArchivoOrigen As String = "C:\SICY\Etiquetas.bat"
        Dim sRutaDestino As String = "C:\SAY\Etiquetas.bat"
        Dim ArchivoBat As String = "C:\SAY\Etiquetas.bat"
        Dim fsBat As Stream = File.Create(ArchivoBat)
        Dim swBat As New System.IO.StreamWriter(fsBat)
        Try
            If chkColgante.Checked = False And chkCaja.Checked = False And chkSuela.Checked = False Then
                Dim form As New AdvertenciaForm
                form.mensaje = "Selecciona al menos un tipo de eqtiqueta."
                form.ShowDialog()
            Else
                If chkCaja.Checked And chkSuela.Checked Then
                    accion = 4
                ElseIf chkCaja.Checked Then
                    accion = 2
                ElseIf chkSuela.Checked Then
                    accion = 3
                ElseIf chkColgante.Checked Then
                    accion = 1
                End If
            End If

            If accion <> 0 Then
                Dim existe As Boolean
                Dim objNegocios As New Negocios.PedidosMuestrasOP
                existe = System.IO.Directory.Exists("C:\SAY")
                If Not existe Then
                    System.IO.Directory.CreateDirectory("C:\SAY")
                End If
                'If Not File.Exists("C:\SAY\Etiquetas.bat") Then
                '    ' Mover el fichero.si existe lo sobreescribe  
                '    If File.Exists(sArchivoOrigen) Then
                '        My.Computer.FileSystem.CopyFile(sArchivoOrigen, sRutaDestino, True)
                '    End If
                'End If

                obj = CreateObject("Scripting.FileSystemObject")
                archivo = obj.CreateTextFile(ruta, True)

                If _ImpresionPorEtiqueta Then
                    For Each Etiqueta In _ListaStr
                        'MsgBox(idOrden.ToString)
                        Dim dt As DataTable
                        dt = objNegocios.VerListaEtiquetasMuestras(Etiqueta, accion, cmbImpresion.Text)
                        For Each row As DataRow In dt.Rows
                            archivo.WriteLine(row.Item("ZPL").ToString.Trim)
                        Next
                    Next
                Else
                    For Each idOrden In _ListaInt
                        'MsgBox(idOrden.ToString)
                        Dim dt As DataTable
                        dt = objNegocios.VerListaEtiquetasMuestrasOP(idOrden, accion, cmbImpresion.Text)
                        For Each row As DataRow In dt.Rows
                            archivo.WriteLine(row.Item("ZPL").ToString.Trim)
                        Next
                    Next
                End If


                archivo.close()

                'Dim dtComando As DataTable
                'Dim ImpresoraId As Integer
                'ImpresoraId = cmbImpresoras.SelectedValue
                'dtComando = objNegocios.ObtenerComandoImpresorasZebra(8)
                'Dim cmd As String
                'cmd = dtComando.Rows(0).Item("Comando").ToString
                'Shell("cmd.exe /C NET USE LPT1 /DELETE", AppWinStyle.Hide)
                'Shell("cmd.exe /C " + cmd, AppWinStyle.Hide)
                'swBat.WriteLine("net use LPT1: \\PROGRAMACION2\PROGRAMACION3 /persistent:yes ")
                swBat.WriteLine("COPY C:\SAY\ETIQUETAS.TXT C:\PRN")
                swBat.Close()
                Shell("C:\SAY\Etiquetas.bat")

                'Shell("cmd.exe /C COPY C:\SAY\ETIQUETAS.TXT C:\PRN")

                Dim mensaje As New ExitoForm
                mensaje.mensaje = "El registro se realizó con éxito."
                mensaje.ShowDialog()
                btnCancelar_Click(sender, e)
            End If
        Catch ex As Exception
            Dim mensaje As New ErroresForm
            mensaje.mensaje = ex.Message.ToString
            mensaje.ShowDialog()
            archivo.close()
        End Try
    End Sub

    Private Sub ImprimirEtiquetasPedidosMuestrasForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmbImpresion.SelectedIndex = 0
    End Sub

    Private Sub chkColgante_CheckedChanged(sender As Object, e As EventArgs) Handles chkColgante.CheckedChanged
        If chkColgante.Checked Then
            chkCaja.Checked = False
            chkSuela.Checked = False
        End If
    End Sub

    Private Sub chkCaja_CheckedChanged(sender As Object, e As EventArgs) Handles chkCaja.CheckedChanged
        If chkCaja.Checked Then
            chkColgante.Checked = False
        End If
    End Sub

    Private Sub chkSuela_CheckedChanged(sender As Object, e As EventArgs) Handles chkSuela.CheckedChanged
        If chkSuela.Checked Then
            chkColgante.Checked = False
        End If
    End Sub
End Class