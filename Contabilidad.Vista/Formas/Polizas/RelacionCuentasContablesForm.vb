Imports System.Windows.Forms
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win

Public Class RelacionCuentasContablesForm
    Public tablaCuentas As New DataTable
    Public tipoCuenta As String = ""
    Public cuentaSAYID As Integer
    Public cuentaContpaqID As Integer
    Public cuentaContpaq As String
    Public cuentaDescripcion As String
    Public proveedorClienteID As Integer
    Public proveedorClienteRFC As String
    Public proveedorDesc As String
    Public empresaSAYContpaqSICY As Integer
    Public servidorBD As String
    Public empresaBD As String
    Public Mensajeform As New ConfirmarForm



    Private Sub RelacionCuentasContablesForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.Location = New Drawing.Point(680, 180)
        Dim campos As DataTable = tablaCuentas.Clone
        grdCuentasContpac.DataSource = campos
        For Each row As DataRow In tablaCuentas.Rows
            grdCuentasContpac.DisplayLayout.Bands(0).AddNew()

            grdCuentasContpac.Rows(grdCuentasContpac.Rows.Count - 1).Cells("id").Value = row.Item("id").ToString
            grdCuentasContpac.Rows(grdCuentasContpac.Rows.Count - 1).Cells("Cuenta").Value = row.Item("Cuenta").ToString
            grdCuentasContpac.Rows(grdCuentasContpac.Rows.Count - 1).Cells("Nombre").Value = row.Item("Nombre").ToString
        Next

        grdCuentasContpac.DisplayLayout.Bands(0).Columns.Add("Seleccion", "Seleccion")
        Dim colSeleccion As UltraGridColumn = grdCuentasContpac.DisplayLayout.Bands(0).Columns("Seleccion")
        colSeleccion.DefaultCellValue = False
        colSeleccion.Header.Caption = "Selección"
        colSeleccion.Header.VisiblePosition = 0
        colSeleccion.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Image
        colSeleccion.Width = 50

        Me.Cursor = Cursors.Default
        disenoGrid()
        grdCuentasContpac.ActiveRowScrollRegion.ScrollPosition = TopLevel

        grdCuentasContpac.DisplayLayout.Bands(0).Columns("Seleccion").AllowRowFiltering = DefaultableBoolean.False
        grdCuentasContpac.DisplayLayout.Bands(0).Columns("id").AllowRowFiltering = DefaultableBoolean.False
        grdCuentasContpac.DisplayLayout.Bands(0).Columns("Cuenta").AllowRowFiltering = DefaultableBoolean.False
        grdCuentasContpac.DisplayLayout.Bands(0).Columns("Nombre").AllowRowFiltering = DefaultableBoolean.True
        grdCuentasContpac.DisplayLayout.Override.FilterUIType = FilterUIType.FilterRow
        grdCuentasContpac.DisplayLayout.Override.FilterOperatorDefaultValue = FilterOperatorDefaultValue.Contains
        grdCuentasContpac.DisplayLayout.Override.FilterOperandStyle = FilterOperandStyle.UseColumnEditor

    End Sub

    Private Sub btnsalir_Click(sender As Object, e As EventArgs) Handles btnsalir.Click
        Me.Close()
    End Sub

    Private Sub grdCuentasContpac_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles grdCuentasContpac.InitializeRow
        If e.Row.Cells.Exists("Seleccion") Then
            e.Row.Cells("Seleccion").Appearance.ImageBackground = Global.Contabilidad.Vista.My.Resources.Resources.seleccionar
        End If

    End Sub

    Public Sub disenoGrid()
        If grdCuentasContpac.Rows.Count > 0 Then
            grdCuentasContpac.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
            grdCuentasContpac.DisplayLayout.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
            grdCuentasContpac.DisplayLayout.Override.RowAlternateAppearance.BackColor = Drawing.Color.LightSteelBlue
            grdCuentasContpac.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            grdCuentasContpac.DisplayLayout.MaxRowScrollRegions = 1

            Dim width As Integer
            For Each col As UltraGridColumn In grdCuentasContpac.Rows.Band.Columns
                If Not col.Hidden Then
                    width += col.Width
                End If
            Next

            If width > grdCuentasContpac.Width Then
                grdCuentasContpac.DisplayLayout.AutoFitStyle = AutoFitStyle.None
            Else
                grdCuentasContpac.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
            End If
        End If
    End Sub

    Private Sub grdCuentasContpac_DoubleClickRow(sender As Object, e As DoubleClickRowEventArgs) Handles grdCuentasContpac.DoubleClickRow

        If e.Row.Index >= 0 Then
            Dim mensaje As New ConfirmarForm
            mensaje.mensaje = "¿Esta seguro de relacionar la cuenta?" + vbNewLine + " La cuenta se creara en SAY con el mismo nombre y numero de cuenta"
            If mensaje.ShowDialog = DialogResult.OK Then
                cuentaContpaq = e.Row.Cells("Cuenta").Value
                cuentaContpaqID = e.Row.Cells("Id").Value
                cuentaDescripcion = e.Row.Cells("Nombre").Value
                Dim tablaIDSAY As DataTable
                Dim objBU As New Contabilidad.Negocios.AltaPolizaBU
                Dim altaPoliza As New Entidades.Polizas

                If tipoCuenta = "COMPRAS" Or tipoCuenta = "TRANSFERENCIAS" Or tipoCuenta = "GASTOS" Or tipoCuenta = "GASTOS Y COMPRAS" Or tipoCuenta = "PRODUCTO TERMINADO" Then

                    validarProveedoresExisten()
                    altaPoliza.Pconstante1 = cuentaContpaq.Substring(0, 3)
                    altaPoliza.Pconstante2 = cuentaContpaq.Substring(3, 4)
                    altaPoliza.Pletra = cuentaContpaq.Substring(7, 1)
                    altaPoliza.Pconsecutivo = cuentaContpaq.Substring(8, 3)
                    altaPoliza.PccContpaqID = cuentaContpaqID
                    altaPoliza.PclienteID = 0
                    altaPoliza.PproveedorSicyID = proveedorClienteID
                    altaPoliza.PccSICYID = 0
                    altaPoliza.PccTipo = 7
                    altaPoliza.PempresaID = empresaSAYContpaqSICY
                    altaPoliza.PproveedorNombre = cuentaDescripcion
                    altaPoliza.PusuarioCreoID = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
                    tablaIDSAY = objBU.AltaCuentasContablesSAY(altaPoliza, servidorBD, empresaBD, cuentaContpaq)
                    cuentaSAYID = tablaIDSAY.Rows(0).Item("cuentaSAYID")

                ElseIf tipoCuenta = "DEPÓSITOS POR IDENTIFICAR" Then

                ElseIf tipoCuenta = "DEPÓSITOS IDENTIFICADOS" Or tipoCuenta = "VENTAS" Or tipoCuenta = "NOTAS DE CRÉDITO" Then

                    altaPoliza.Pconstante1 = cuentaContpaq.Substring(0, 3)
                    altaPoliza.Pconstante2 = cuentaContpaq.Substring(3, 4)
                    altaPoliza.Pletra = cuentaContpaq.Substring(7, 1)
                    altaPoliza.Pconsecutivo = cuentaContpaq.Substring(8, 3)
                    altaPoliza.PccContpaqID = cuentaContpaqID
                    altaPoliza.PclienteID = proveedorClienteID
                    altaPoliza.PproveedorSicyID = 0
                    altaPoliza.PccSICYID = 0
                    altaPoliza.PccTipo = 3
                    altaPoliza.PempresaID = empresaSAYContpaqSICY
                    altaPoliza.PproveedorNombre = cuentaDescripcion
                    altaPoliza.PusuarioCreoID = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
                    tablaIDSAY = objBU.AltaCuentasContablesSAY(altaPoliza, servidorBD, empresaBD, cuentaContpaq)
                    cuentaSAYID = tablaIDSAY.Rows(0).Item("cuentaSAYID")
                End If
                Me.Close()
            End If
        End If
    End Sub

    Public Function ValidarPersonaProveedorExisteContpaq(ByVal RFC As String) As Boolean
        Dim objBu As New Contabilidad.Negocios.AltaPolizaBU
        Dim tabla As New DataTable
        Dim existe As Boolean = False
        tabla = objBu.ValidarPersonaProveedorExisteContpaq(RFC.ToString.Replace("-", "").Replace(" ", "").Trim, servidorBD, empresaBD)
        If tabla.Rows.Count > 0 Then
            existe = True
        End If
        Return existe
    End Function

    Private Sub btnAlta_Click(sender As Object, e As EventArgs) Handles btnAlta.Click
        Dim objAltaCuenta As New AltaCuentasContablesForm

        With objAltaCuenta
            .tipoCuenta = tipoCuenta
            .empresaBD = empresaBD
            .servidorBD = servidorBD
            .proveedorDesc = proveedorDesc
            .proveedorID = proveedorClienteID
            .proveedorRFC = proveedorClienteRFC.ToString.Replace("-", "").Replace(" ", "").Trim
            .empresaSAYContpaqSICY = empresaSAYContpaqSICY
            .ShowDialog()
            cuentaContpaq = .cuentaContpaqNueva
            cuentaDescripcion = .cuentaDescripcion
            cuentaSAYID = .cuentaSAYID
            Me.Close()
        End With
    End Sub

#Region "Validar y dar alta proveedores SAY/Contpaq"

    Public Function ValidarPersonaProveedorExisteContpaq(ByVal proveedorRFC As String, ByVal servidorBD As String, empresaBD As String) As Boolean
        Dim objBu As New Contabilidad.Negocios.AltaPolizaBU
        Dim tabla As New DataTable
        Dim existe As Boolean = False
        tabla = objBu.ValidarPersonaProveedorExisteContpaq(proveedorRFC.ToString.Replace("-", "").Replace(" ", "").Trim, servidorBD, empresaBD)
        If tabla.Rows.Count > 0 Then
            existe = True
        End If
        Return existe
    End Function

    Public Function AltaPersonasCompaq(ByVal RFC As String, ByVal Proveedor As String) As Entidades.Polizas
        Dim listaEntidad As New Entidades.Polizas
        Dim objBU As New Contabilidad.Negocios.AltaPolizaBU
        Dim tabla As New DataTable
        Dim personaCodigo As Integer = 0
        listaEntidad.PproveedorRFC = RFC.ToString.Replace("-", "").Replace(" ", "").Trim
        listaEntidad.PproveedorNombre = Proveedor
        listaEntidad.PempresaBD = empresaBD
        listaEntidad.PservidorBD = servidorBD

        tabla = objBU.AltaPersonasContpaq(listaEntidad)
        personaCodigo = tabla.Rows(0).Item("personaCodigo")
        listaEntidad.PproveedorPersonaID = personaCodigo

        Return listaEntidad
    End Function

    Public Function AltaProveedorCompaq(ByVal listaEntidad As Entidades.Polizas) As String
        Dim objBU As New Contabilidad.Negocios.AltaPolizaBU
        Dim tabla As New DataTable
        Dim proveedorContaq As String = ""
        tabla = objBU.AltaProveedoresContpaq(listaEntidad)
        proveedorContaq = tabla.Rows(0).Item("personaCodigo")
        Return proveedorContaq
    End Function

    Public Sub validarProveedoresExisten()
        Dim tabla As New DataTable
        Dim objBu As New Contabilidad.Negocios.AltaPolizaBU
        Dim listaEntidades As New Entidades.Polizas
        Dim existe As Boolean = False
        Dim proveedorContpaqID As String
        Dim personaSAYid As Integer

        existe = ValidarPersonaProveedorExisteContpaq(proveedorClienteRFC, servidorBD, empresaBD)
        If existe = False Then
            listaEntidades = AltaPersonasCompaq(proveedorClienteRFC.ToString.Replace("-", "").Replace(" ", "").Trim, cuentaDescripcion)
            proveedorContpaqID = AltaProveedorCompaq(listaEntidades)
            tabla = objBu.validarProveedorExisteSAY(proveedorClienteRFC.ToString.Replace("-", "").Replace(" ", "").Trim)

            If tabla.Rows.Count = 0 Then
                tabla = Nothing
                listaEntidades.PproveedorNombre = cuentaDescripcion
                tabla = objBu.insertarPersonaSAY(listaEntidades)
                personaSAYid = tabla.Rows(0).Item("id")
                listaEntidades.PproveedorRFC = proveedorClienteRFC.ToString.Replace("-", "").Replace(" ", "").Trim
                listaEntidades.PproveedoID = personaSAYid
                listaEntidades.PproveedorSicyID = proveedorClienteID
                tabla = objBu.insertarProveedorSAY(listaEntidades)
            End If
        ElseIf existe = True Then
            tabla = objBu.validarProveedorExisteSAY(proveedorClienteRFC.ToString.Replace("-", "").Replace(" ", "").Trim)
            If tabla.Rows.Count = 0 Then
                tabla = Nothing
                listaEntidades.PproveedorNombre = cuentaDescripcion
                tabla = objBu.insertarPersonaSAY(listaEntidades)
                personaSAYid = tabla.Rows(0).Item("id")
                listaEntidades.PproveedorRFC = proveedorClienteRFC.ToString.Replace("-", "").Replace(" ", "").Trim
                listaEntidades.PproveedoID = personaSAYid
                listaEntidades.PproveedorSicyID = proveedorClienteID
                tabla = objBu.insertarProveedorSAY(listaEntidades)
            End If
        End If
        ''#Fin
    End Sub

#End Region



End Class