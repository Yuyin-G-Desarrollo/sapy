
Imports System.Windows.Forms
Imports Proveedores.BU
Imports Stimulsoft.Report
Imports Tools

Public Class ConsultaReciboForm
    Dim inicio As Integer = True

    Private Sub ConsultaReciboForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenarComboAño()
        llenarComboProveedor()

    End Sub

    Public Sub llenarComboProveedor()
        Dim objBU As New EntregarPagosProveedorBU
        Dim dtProveedor As New DataTable
        dtProveedor = objBU.verComboProveedores()
        cmbProveedor.DataSource = dtProveedor
        dtProveedor.Rows.InsertAt(dtProveedor.NewRow, 0)
        cmbProveedor.ValueMember = "idproveedor"
        cmbProveedor.DisplayMember = "razonsocial"
        inicio = False
    End Sub

    Public Sub llenarComboReciboProveedor()
        Dim objBU As New EntregarPagosProveedorBU
        Dim dtReciboProveedor As New DataTable
        Dim semana As Integer = 0
        Dim proveedorid As Integer = 0
        Dim año As Integer = 0
        If cmbSemana.SelectedIndex < 0 Then
            semana = 0
        Else
            semana = cmbSemana.SelectedValue
        End If
        If cmbProveedor.SelectedIndex <= 0 Then
            proveedorid = 0
            llenarComboProveedor()
        Else
            If IsNumeric(cmbProveedor.SelectedValue) Then
                proveedorid = CInt(cmbProveedor.SelectedValue)
            Else
                proveedorid = 0
                llenarComboProveedor()
            End If
            If cmbAño.SelectedIndex <= 0 Then
                año = 0
            Else
                año = cmbAño.SelectedValue
            End If

        End If
        dtReciboProveedor = objBU.verComboReciboPago(proveedorid, semana, año)
        cmbRecibo.DataSource = dtReciboProveedor
        dtReciboProveedor.Rows.InsertAt(dtReciboProveedor.NewRow, 0)
        cmbRecibo.DataSource = dtReciboProveedor
        cmbRecibo.DisplayMember = "consec"
        cmbRecibo.ValueMember = "REC"
    End Sub

    Public Sub llenarComboAño()
        Dim objBU As New EntregarPagosProveedorBU
        Dim dtaño As New DataTable
        dtaño = objBU.verComboAño()
        dtaño.Rows.InsertAt(dtaño.NewRow, 0)
        cmbAño.DataSource = dtaño
        cmbAño.DisplayMember = "año"
        cmbAño.ValueMember = "añoPago"
    End Sub

    Public Sub llenarComboSemana()
        Dim objBU As New EntregarPagosProveedorBU
        Dim dtSemana As New DataTable
        dtSemana = objBU.verComboSemanaPago(cmbAño.SelectedValue)
        cmbSemana.DataSource = Nothing
        If dtSemana.Rows.Count > 0 Then
            cmbSemana.DataSource = dtSemana
            cmbSemana.DisplayMember = "num"
            cmbSemana.ValueMember = "numsem"
            cmbSemana.SelectedIndex = 0
        End If
    End Sub


    Private Sub bntSalir_Click(sender As Object, e As EventArgs) Handles bntSalir.Click
        Me.Close()
    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        Dim objBU As New EntregarPagosProveedorBU
        Dim dtEncabezadoReporte As New DataTable
        Dim dtConcentradoReporte As New DataTable("dtPagosProveedor")
        Dim advertencia As New AdvertenciaForm
        Dim dtTiposPago As New DataTable
        Dim lstTiposPago As New List(Of String)

        Dim semana As Integer = 0
        Dim proveedor As Integer = 0
        Dim recibo As Integer = 0
        Dim año As Integer = Now.Year
        Dim rep As Integer = 0
        Dim fec As Date = Date.Now
        Dim usuario As String = String.Empty
        Dim sumChequeEndosado As Double = 0
        Dim sumCheque As Double = 0
        Dim sumEfectivo As Double = 0
        Dim sumTransferencia As Double = 0
        Dim granTotal As Double = 0
        Dim FechaRecibo As String = Date.Now.ToShortDateString

        Dim usuarioSesion As Integer = 0

        usuarioSesion = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid

        If usuarioSesion = 43 Or usuarioSesion = 350 Or usuarioSesion = 29 Then

            ' If cmbSemana.SelectedValue.ToString() = "" Then
            'semana = 0
            'Else
            'semana = cmbSemana.SelectedValue
            'End If

            proveedor = cmbProveedor.SelectedValue
            recibo = cmbRecibo.SelectedValue
            usuario = Entidades.SesionUsuario.UsuarioSesion.PUserUsername

            dtEncabezadoReporte = objBU.ObtieneReciboPagoAnterior(proveedor, recibo, usuario)
            dtConcentradoReporte = objBU.ObtieneReciboPagoAnteriorDetalles(semana, proveedor, recibo, año, usuario)

            If dtEncabezadoReporte.Rows.Count > 0 And dtConcentradoReporte.Rows.Count > 0 Then

                For Each Filas As DataRow In dtEncabezadoReporte.Rows
                    If lstTiposPago.Contains((Filas.Item("FormaPago").ToString)) = False Then
                        lstTiposPago.Add((Filas.Item("FormaPago").ToString))
                    End If
                Next

                dtTiposPago.Columns.Add("FormaPago", System.Type.GetType("System.String"))

                For Each Fila As String In lstTiposPago
                    dtTiposPago.Rows.Add(Fila)
                Next


                Dim ObjBUReporte As New Framework.Negocios.ReportesBU
                Dim EntidadReporte As Entidades.Reportes
                Dim dsPagosProveedor As New DataSet("dsPagosProveedor")

                Cursor = Cursors.WaitCursor

                dtConcentradoReporte.TableName = "dtPagosProveedor"
                dtEncabezadoReporte.TableName = "dtEncabezadoReporte"
                dtTiposPago.TableName = "dtTiposPago"
                dsPagosProveedor.Tables.Add(dtConcentradoReporte)
                dsPagosProveedor.Tables.Add(dtEncabezadoReporte)
                dsPagosProveedor.Tables.Add(dtTiposPago)

                For Each fila As DataRow In dtEncabezadoReporte.Rows
                    If fila.Item("FormaPago").ToString = "CHEQUE ENDOSADO" And fila.Item("usuario").ToString <> "" Then
                        sumChequeEndosado += CDbl(fila.Item("ImportePago").ToString)
                    ElseIf fila.Item("FormaPago").ToString = "CHEQUE" And fila.Item("usuario").ToString <> "" Then
                        sumCheque += CDbl(fila.Item("ImportePago").ToString)
                    ElseIf fila.Item("FormaPago").ToString = "EFECTIVO" And fila.Item("usuario").ToString <> "" Then
                        sumEfectivo += CDbl(fila.Item("ImportePago").ToString)
                    ElseIf fila.Item("FormaPago").ToString = "TRANSFERENCIA" And fila.Item("usuario").ToString <> "" Then
                        sumTransferencia += CDbl(fila.Item("ImportePago").ToString)
                    End If
                Next

                granTotal = sumCheque + sumChequeEndosado + sumEfectivo + sumTransferencia

                EntidadReporte = ObjBUReporte.LeerReporteporClave("REC_PAGOPROV")
                Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
                    LTrim(RTrim(EntidadReporte.Pnombre)) + ".mrt"
                My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)
                Dim reporte As New StiReport

                reporte.Load(archivo)
                reporte.Compile()
                reporte("NbUsuarioReal") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername.ToString
                reporte("NombreEntrega") = Entidades.SesionUsuario.UsuarioSesion.PUserNombreReal.ToString
                reporte("urlImagenNave") = Tools.Controles.ObtenerLogoNave(43)
                reporte("Nave") = dtEncabezadoReporte.Rows(0).Item("Nave").ToString
                reporte("Recibo") = dtEncabezadoReporte.Rows(0).Item("Recibo").ToString
                reporte("sumChequeEndosado") = sumChequeEndosado
                reporte("sumCheque") = sumCheque
                reporte("sumEfectivo") = sumEfectivo
                reporte("sumTransferencia") = sumTransferencia
                reporte("granTotal") = granTotal
                reporte("Proveedor") = dtEncabezadoReporte.Rows(0).Item("Proveedor").ToString
                reporte("FechaRecibo") = FechaRecibo
                reporte.Dictionary.Clear()

                reporte.RegData(dsPagosProveedor)
                reporte.Dictionary.Synchronize()
                reporte.Show()


                Cursor = Cursors.Default

            Else
                advertencia.mensaje = "No hay información para imprimir"
                advertencia.ShowDialog()
            End If
        Else
            advertencia.mensaje = "No cuenta con permiso para realizar esta acción."
            advertencia.ShowDialog()

        End If
    End Sub

    Private Sub cmbRecibo_SelectedIndexChanged(sender As Object, e As EventArgs)
        'If cmbProveedor.SelectedIndex Then
        '    llenarComboReciboProveedor()
        'End If
    End Sub

    Private Sub cmbAño_DropDownClosed(sender As Object, e As EventArgs) Handles cmbAño.DropDownClosed
        llenarComboSemana()
    End Sub

    Private Sub cmbSemana_DropDownClosed(sender As Object, e As EventArgs) Handles cmbSemana.DropDownClosed
        llenarComboReciboProveedor()
    End Sub

    Private Sub cmbProveedor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbProveedor.SelectedIndexChanged
        If inicio = False Then
            If cmbProveedor.SelectedIndex > 0 Then
                llenarComboReciboProveedor()
            Else
                cmbRecibo.DataSource = Nothing
            End If

        End If
    End Sub
End Class