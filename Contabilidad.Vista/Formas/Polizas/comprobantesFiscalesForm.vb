Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports System.Windows.Forms
Imports System.Xml

Public Class comprobantesFiscalesForm
    Dim objMesj As New Tools.AdvertenciaForm
    Dim empresaBD As String = ""
    Dim servidorBD As String = ""
    Dim doctoVentasID As String = ""
    Dim contribuyentesID As String = ""
    Dim empresaSAYContpaqSICY As String

    Private Sub comprobantesFiscalesForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        WindowState = FormWindowState.Maximized
        LlenadoCombos()
    End Sub

    Public Sub LlenadoCombos()

        Dim altpoliBU As New Negocios.AltaPolizaBU
        Dim comprobantesBU As New Negocios.comprobantesFiscalesBU
        Dim tabla As New DataTable

        Tools.Controles.ComboNavesSegunUsuarioConIdSIcy(cmbNave, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)

        'Cargamos combos
        tabla = altpoliBU.CargaEmpresaCONTPAQ(Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid.ToString)
        tabla.Rows.InsertAt(tabla.NewRow(), 0)

        cmbEmpresa.DataSource = tabla
        cmbEmpresa.ValueMember = "essc_sayid"
        cmbEmpresa.DisplayMember = "RazonSocial"

        tabla = Nothing
        tabla = altpoliBU.CargaTiposPoliza()
        tabla.Rows.InsertAt(tabla.NewRow(), 0)
        tabla.Rows(0).Item("poti_polizaTipoId") = 0
        tabla.Rows(0).Item("poti_nombre") = "SIN PÓLIZA"
        cmbTipo.DataSource = tabla
        cmbTipo.ValueMember = "poti_polizaTipoId"
        cmbTipo.DisplayMember = "poti_nombre"


        tabla = Nothing
        tabla = comprobantesBU.proveedores()
        tabla.Rows.InsertAt(tabla.NewRow(), 0)
        cmbProveedor.DataSource = tabla
        cmbProveedor.ValueMember = "prov_sicyid"
        cmbProveedor.DisplayMember = "prov_nombregenerico"

    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        Dim objBu As New Negocios.comprobantesFiscalesBU
        Dim tabla As New DataTable
        ''Falta ver el pedo de la nave loco.............
        'Dim empresa As Integer = 0
        Dim proveedor As Integer = 0
        Dim tipo As Integer = 0
        Dim nave As Integer = 0

        If cmbProveedor.Text <> "" Then
            proveedor = cmbProveedor.SelectedValue
        End If

        If cmbTipo.Text <> "" Then
            tipo = cmbTipo.SelectedValue
        End If

        If cmbNave.Text <> "" Then
            nave = cmbNave.SelectedValue
        End If

        If cmbEmpresa.Text <> "" Then
            tabla = objBu.cargarComprobantesFiscales(contribuyentesID, proveedor, dtpDe.Value, dtpAl.Value, tipo, txtFolio.Text, nave)
            If tabla.Rows.Count > 0 Then

                Dim tabla2 As DataTable = tabla.Clone
                grdComprobantesFiscales.DataSource = tabla2
                disenoGrid()

                For Each row As DataRow In tabla.Rows
                    grdComprobantesFiscales.DisplayLayout.Bands(0).AddNew()
                    grdComprobantesFiscales.Rows(grdComprobantesFiscales.Rows.Count - 1).Cells("#").Value = grdComprobantesFiscales.Rows.Count
                    grdComprobantesFiscales.Rows(grdComprobantesFiscales.Rows.Count - 1).Cells("Folio").Value = row.Item("Folio")
                    grdComprobantesFiscales.Rows(grdComprobantesFiscales.Rows.Count - 1).Cells("Tipo Doc.").Value = row.Item("Tipo Doc.")
                    grdComprobantesFiscales.Rows(grdComprobantesFiscales.Rows.Count - 1).Cells("RFC").Value = row.Item("RFC")
                    grdComprobantesFiscales.Rows(grdComprobantesFiscales.Rows.Count - 1).Cells("Razon Social").Value = row.Item("Razon Social")
                    grdComprobantesFiscales.Rows(grdComprobantesFiscales.Rows.Count - 1).Cells("Total").Value = row.Item("Total")
                    grdComprobantesFiscales.Rows(grdComprobantesFiscales.Rows.Count - 1).Cells("UUID").Value = row.Item("UUID")
                    grdComprobantesFiscales.Rows(grdComprobantesFiscales.Rows.Count - 1).Cells("Estatus").Value = row.Item("Estatus")
                    grdComprobantesFiscales.Rows(grdComprobantesFiscales.Rows.Count - 1).Cells("Tipo Póliza").Value = row.Item("Tipo Póliza")
                    grdComprobantesFiscales.Rows(grdComprobantesFiscales.Rows.Count - 1).Cells("No. Póliza").Value = row.Item("No. Póliza")
                    grdComprobantesFiscales.Rows(grdComprobantesFiscales.Rows.Count - 1).Cells("XML").Value = row.Item("XML")
                    grdComprobantesFiscales.Rows(grdComprobantesFiscales.Rows.Count - 1).Cells("PDF").Value = row.Item("PDF")
                    grdComprobantesFiscales.Rows(grdComprobantesFiscales.Rows.Count - 1).Cells("Comprobante").Value = row.Item("Comprobante")

                    If row.Item("Comprobante") = 0 Then
                        grdComprobantesFiscales.Rows(grdComprobantesFiscales.Rows.Count - 1).Appearance.BackColor = Drawing.Color.Salmon                        
                        grdComprobantesFiscales.Rows(grdComprobantesFiscales.Rows.Count - 1).Cells("folio").Value = row.Item("NUMDOCTO")
                    Else
                        Dim lista As New Entidades.Polizas
                        lista = extraerUUID(row.Item("XML"))
                        grdComprobantesFiscales.Rows(grdComprobantesFiscales.Rows.Count - 1).Cells("UUID").Value = lista.Puuid
                        grdComprobantesFiscales.Rows(grdComprobantesFiscales.Rows.Count - 1).Cells("folio").Value = lista.Pfolio
                        grdComprobantesFiscales.Rows(grdComprobantesFiscales.Rows.Count - 1).Cells("Serie").Value = lista.Pserie
                    End If
             

                Next

            Else
                grdComprobantesFiscales.DataSource = Nothing
                '                Dim objMesj As New Tools.AdvertenciaForm
                objMesj.mensaje = "No hay información para mostrar."
                objMesj.ShowDialog()

            End If



        Else
            ' Dim objMesj As New Tools.AdvertenciaForm
            objMesj.mensaje = "Favor de seleccionar una empresa."
            objMesj.ShowDialog()
        End If
    End Sub



    Public Sub disenoGrid()

        grdComprobantesFiscales.DisplayLayout.Bands(0).Columns("#").CellAppearance.TextHAlign = HAlign.Right
        grdComprobantesFiscales.DisplayLayout.Bands(0).Columns("Folio").CellAppearance.TextHAlign = HAlign.Left
        grdComprobantesFiscales.DisplayLayout.Bands(0).Columns("Tipo Doc.").CellAppearance.TextHAlign = HAlign.Left
        grdComprobantesFiscales.DisplayLayout.Bands(0).Columns("RFC").CellAppearance.TextHAlign = HAlign.Left
        grdComprobantesFiscales.DisplayLayout.Bands(0).Columns("Razon Social").CellAppearance.TextHAlign = HAlign.Left
        grdComprobantesFiscales.DisplayLayout.Bands(0).Columns("Total").CellAppearance.TextHAlign = HAlign.Right
        grdComprobantesFiscales.DisplayLayout.Bands(0).Columns("UUID").CellAppearance.TextHAlign = HAlign.Left
        grdComprobantesFiscales.DisplayLayout.Bands(0).Columns("Estatus").CellAppearance.TextHAlign = HAlign.Left
        grdComprobantesFiscales.DisplayLayout.Bands(0).Columns("Tipo Póliza").CellAppearance.TextHAlign = HAlign.Left
        grdComprobantesFiscales.DisplayLayout.Bands(0).Columns("No. Póliza").CellAppearance.TextHAlign = HAlign.Right

        grdComprobantesFiscales.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect


        grdComprobantesFiscales.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.False


        grdComprobantesFiscales.DisplayLayout.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)

        grdComprobantesFiscales.DisplayLayout.Override.RowAlternateAppearance.BackColor = Drawing.Color.LightSteelBlue
        grdComprobantesFiscales.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex

        grdComprobantesFiscales.DisplayLayout.MaxRowScrollRegions = 1

        'grdCompras.ActiveRowScrollRegion.ScrollPosition = Top

        Dim width As Integer
        For Each col As UltraGridColumn In grdComprobantesFiscales.Rows.Band.Columns
            If Not col.Hidden Then
                width += col.Width
            End If
        Next

        If width > grdComprobantesFiscales.Width Then
            grdComprobantesFiscales.DisplayLayout.AutoFitStyle = AutoFitStyle.None
        Else
            grdComprobantesFiscales.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        End If
    End Sub

    Private Sub cmbEmpresa_DropDownClosed(sender As Object, e As EventArgs) Handles cmbEmpresa.DropDownClosed
        Dim objDA As New Contabilidad.Negocios.AltaPolizaBU
        Dim tabla As New DataTable
        Dim tamanio As Integer = 0

        empresaBD = ""
        servidorBD = ""
        doctoVentasID = ""
        contribuyentesID = ""
        If cmbEmpresa.SelectedIndex > 0 Then
            tabla = objDA.datosServidorEmpresa(cmbEmpresa.SelectedValue)
            For Each row As DataRow In tabla.Rows
                empresaBD = row.Item("essc_empresacontpaq")
                servidorBD = row.Item("essc_servidor")
                If tabla.Rows.Count > 1 Then
                    contribuyentesID += CStr(row.Item("essc_contribuyentesicyid")).Trim + ","
                    doctoVentasID += CStr(row.Item("essc_doctoventassicyid")).Trim + ","
                Else
                    contribuyentesID = row.Item("essc_contribuyentesicyid")
                    doctoVentasID = CStr(row.Item("essc_doctoventassicyid")).Trim
                End If
                empresaSAYContpaqSICY = row.Item("essc_empresaid")
            Next
            If tabla.Rows.Count > 1 Then
                tamanio = contribuyentesID.Length
                contribuyentesID = contribuyentesID.Remove(tamanio - 1)

                tamanio = doctoVentasID.Length
                doctoVentasID = doctoVentasID.Remove(tamanio - 1)
            End If
        End If
    End Sub

    Public Function extraerUUID(ByVal Ruta As String) As Entidades.Polizas

        Dim reader As XmlTextReader = New XmlTextReader(Ruta)
        Dim lista As New Entidades.Polizas

        Do While (reader.Read())

            Select Case reader.NodeType
                Case XmlNodeType.Element 'Mostrar comienzo del elemento.                    
                    If reader.HasAttributes Then 'If attributes exist
                        While reader.MoveToNextAttribute()
                            If reader.Name = "UUID" Then
                                lista.Puuid = reader.Value
                            End If

                            If reader.Name = "serie" Then
                                lista.Pserie = reader.Value
                            End If

                            If reader.Name = "folio" Then
                                lista.Pfolio = reader.Value
                            End If

                        End While
                    End If
            End Select
        Loop
        Return lista
        reader.Close()
    End Function


    Private Sub btnPDF_Click(sender As Object, e As EventArgs) Handles btnPDF.Click

        If grdComprobantesFiscales.Rows.Count > 0 Then
            Try
                Process.Start(grdComprobantesFiscales.ActiveRow.Cells("PDF").Value)
            Catch ex As Exception

                objMesj.mensaje = "No cuenta con un PDF relacionado."
                objMesj.ShowDialog()
            End Try
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If grdComprobantesFiscales.Rows.Count > 0 Then
            Try
                Process.Start(grdComprobantesFiscales.ActiveRow.Cells("XML").Value)
            Catch ex As Exception
                objMesj.mensaje = "No cuenta con un XML relacionado"
                objMesj.ShowDialog()
            End Try
        End If
    End Sub

    Private Sub btnlimpiar_Click(sender As Object, e As EventArgs) Handles btnlimpiar.Click
        grdComprobantesFiscales.DataSource = Nothing

        cmbEmpresa.SelectedIndex = 0
        cmbTipo.SelectedIndex = 0
        cmbProveedor.SelectedIndex = 0
        cmbNave.SelectedIndex = 0
        txtFolio.Text = ""
        dtpAl.Value = Now.Date
        dtpDe.Value = Now.Date
    End Sub
End Class