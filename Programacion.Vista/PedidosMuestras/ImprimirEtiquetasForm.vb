Imports System.IO
Imports System.Text
Imports DevExpress.XtraEditors.Repository
Imports Tools

Public Class ImprimirEtiquetasForm

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

    Private _TblEtiquetasImprimir
    Public Property Tbl_EtiquetasImprimir As DataTable
        Get
            Return _TblEtiquetasImprimir
        End Get
        Set(value As DataTable)
            _TblEtiquetasImprimir = value
        End Set
    End Property

    'Private ListaCategorias As New List(Of Categorias)()
    'Public Class Categorias
    '    Public Property ID() As Integer
    '    Public Property TipoImpresion() As String
    'End Class

    'Private ListaEtiquetas As New List(Of Etiquetas)()
    'Public Class Etiquetas
    '    Public Property EtiquetaID() As Integer
    '    Public Property TipoEtiqueta() As String
    'End Class

    Dim cerrar As Boolean
    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        cerrar = True
        Me.Close()
    End Sub

    Private Sub ImprimirEtiquetasForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If Not cerrar Then
            ' Cancelamos el cierre del formulario
            e.Cancel = True
        End If

    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click

        Dim accion As Integer = 0
        Dim obj As New Object
        Dim archivo As New Object
        Dim ruta As String = "C:\SAY\Etiquetas.txt"
        Dim sArchivoOrigen As String = "C:\SICY\Etiquetas.bat"
        Dim sRutaDestino As String = "C:\SAY\Etiquetas.bat"
        Dim ArchivoBat As String = "C:\SAY\Etiquetas.bat"

        Dim var_Etiqueta As String = String.Empty
        Dim var_Coleccion As String = String.Empty
        Dim var_UDM As String = String.Empty
        Dim var_TipoImpresion As String = String.Empty
        Dim var_EtiquetasOpcion As String = String.Empty

        Dim fsBat As Stream = File.Create(ArchivoBat)
        Dim swBat As New System.IO.StreamWriter(fsBat)

        obj = CreateObject("Scripting.FileSystemObject")

        archivo = obj.CreateTextFile(ruta, True)

        Try

            For i As Integer = 0 To grdVImpresionEtiquetas.RowCount - 1
                'archivo = New Object

                var_Etiqueta = grdVImpresionEtiquetas.GetRowCellValue(i, grdVImpresionEtiquetas.Columns(0))
                var_Coleccion = grdVImpresionEtiquetas.GetRowCellValue(i, grdVImpresionEtiquetas.Columns(1))
                var_UDM = grdVImpresionEtiquetas.GetRowCellValue(i, grdVImpresionEtiquetas.Columns(2))
                var_TipoImpresion = grdVImpresionEtiquetas.GetRowCellValue(i, grdVImpresionEtiquetas.Columns(3))
                var_EtiquetasOpcion = grdVImpresionEtiquetas.GetRowCellValue(i, grdVImpresionEtiquetas.Columns(4))

                If var_EtiquetasOpcion = "Caja y Suela" Then
                    accion = 4
                ElseIf var_EtiquetasOpcion = "Caja" Then
                    accion = 2
                ElseIf var_EtiquetasOpcion = "Suela" Then
                    accion = 3
                ElseIf var_EtiquetasOpcion = "Colgante" Then
                    accion = 1
                End If

                If accion <> 0 Then
                    Dim existe As Boolean
                    Dim objNegocios As New Negocios.PedidosMuestrasOP
                    existe = System.IO.Directory.Exists("C:\SAY")
                    If Not existe Then
                        System.IO.Directory.CreateDirectory("C:\SAY")
                    End If

                    If existe = System.IO.Directory.Exists("C:\SAY\Etiquetas.txt") Then
                        System.IO.Directory.CreateDirectory("Etiquetas.txt")
                    End If


                    If _ImpresionPorEtiqueta Then
                        Dim dt As DataTable
                        dt = objNegocios.VerListaEtiquetasMuestras(var_Etiqueta, accion, var_TipoImpresion)
                        For Each row As DataRow In dt.Rows
                            archivo.WriteLine(row.Item("ZPL").ToString.Trim)
                        Next
                    Else ''''For Each idOrden In _ListaInt''''revisar a detalle
                        Dim dt As DataTable
                        dt = objNegocios.VerListaEtiquetasMuestrasOP(var_Etiqueta, accion, var_TipoImpresion)
                        For Each row As DataRow In dt.Rows
                            archivo.WriteLine(row.Item("ZPL").ToString.Trim)
                        Next
                    End If

                    archivo.WriteLine("" + vbLf)
                End If
            Next
            archivo.close()

            swBat.WriteLine("COPY C:\SAY\ETIQUETAS.TXT C:\PRN")
            swBat.Close()
            Shell("C:\SAY\Etiquetas.bat")

            Dim mensaje As New ExitoForm
            mensaje.mensaje = "El registro se realizó con éxito."
            mensaje.ShowDialog()
            btnCancelar_Click(sender, e)

        Catch ex As Exception
            Dim mensaje As New ErroresForm
            mensaje.mensaje = ex.Message.ToString
            mensaje.ShowDialog()
            archivo.close()
        End Try
    End Sub

    Private Sub ImprimirEtiquetasForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'InicializarListaImpresion()
        'InicializarListaEtiquetas()

        grdImpresionEtiquetas.DataSource = Tbl_EtiquetasImprimir

        'Dim lookUp_ImpresionEtiquetas As New RepositoryItemLookUpEdit()
        'lookUp_ImpresionEtiquetas.DataSource = ListaCategorias
        'lookUp_ImpresionEtiquetas.ValueMember = "ID"
        'lookUp_ImpresionEtiquetas.DisplayMember = "TipoImpresion"
        'lookUp_ImpresionEtiquetas.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup
        'lookUp_ImpresionEtiquetas.DropDownRows = ListaCategorias.Count

        'lookUp_ImpresionEtiquetas.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete
        'lookUp_ImpresionEtiquetas.AutoSearchColumnIndex = 1

        'grdImpresionEtiquetas.RepositoryItems.Add(lookUp_ImpresionEtiquetas)

        'Dim lookUp_ImpresionEtiquetasTipo As New RepositoryItemLookUpEdit()
        'lookUp_ImpresionEtiquetasTipo.DataSource = ListaEtiquetas
        'lookUp_ImpresionEtiquetasTipo.ValueMember = "EtiquetaID"
        'lookUp_ImpresionEtiquetasTipo.DisplayMember = "TipoEtiqueta"
        'lookUp_ImpresionEtiquetasTipo.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup
        'lookUp_ImpresionEtiquetasTipo.DropDownRows = ListaEtiquetas.Count

        'lookUp_ImpresionEtiquetasTipo.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete
        'lookUp_ImpresionEtiquetasTipo.AutoSearchColumnIndex = 1

        'grdImpresionEtiquetas.RepositoryItems.Add(lookUp_ImpresionEtiquetasTipo)

        'grdVImpresionEtiquetas.Columns("TipoImpresion").ColumnEdit = lookUp_ImpresionEtiquetas
        'grdVImpresionEtiquetas.Columns("Etiquetas").ColumnEdit = lookUp_ImpresionEtiquetasTipo
        'grdVImpresionEtiquetas.BestFitColumns()

        DiseñoGridInventarioMuestras(grdVImpresionEtiquetas)

        'cmbImpresion.SelectedIndex = 0
    End Sub

    Private Sub DiseñoGridInventarioMuestras(ByVal Grid As DevExpress.XtraGrid.Views.Grid.GridView)

        Grid.OptionsView.ColumnAutoWidth = True
        Grid.OptionsView.BestFitMaxRowCount = -1

        For Each col As DevExpress.XtraGrid.Columns.GridColumn In Grid.Columns
            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Next
        Grid.Columns.ColumnByFieldName("Etiqueta").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("Coleccion").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("UDM").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("TipoImpresion").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("Etiquetas").OptionsColumn.AllowEdit = False
        Grid.BestFitColumns()

    End Sub

    'Private Sub InicializarListaImpresion()
    '    ListaCategorias.Add(New Categorias() With {.ID = 1, .TipoImpresion = "IMPRESIÓN 200"})
    '    ListaCategorias.Add(New Categorias() With {.ID = 2, .TipoImpresion = "IMPRESIÓN 300"})
    'End Sub

    'Private Sub InicializarListaEtiquetas()
    '    ListaEtiquetas.Add(New Etiquetas() With {.EtiquetaID = 1, .TipoEtiqueta = "Colgante"})
    '    ListaEtiquetas.Add(New Etiquetas() With {.EtiquetaID = 2, .TipoEtiqueta = "Caja"})
    '    ListaEtiquetas.Add(New Etiquetas() With {.EtiquetaID = 3, .TipoEtiqueta = "Suela"})
    '    ListaEtiquetas.Add(New Etiquetas() With {.EtiquetaID = 4, .TipoEtiqueta = "Caja y Suela"})
    'End Sub

    'Private Sub chkColgante_CheckedChanged(sender As Object, e As EventArgs)
    '    If chkColgante.Checked Then
    '        chkCaja.Checked = False
    '        chkSuela.Checked = False
    '    End If
    'End Sub

    'Private Sub chkCaja_CheckedChanged(sender As Object, e As EventArgs)
    '    If chkCaja.Checked Then
    '        chkColgante.Checked = False
    '    End If
    'End Sub

    'Private Sub chkSuela_CheckedChanged(sender As Object, e As EventArgs)
    '    If chkSuela.Checked Then
    '        chkColgante.Checked = False
    '    End If
    'End Sub
End Class