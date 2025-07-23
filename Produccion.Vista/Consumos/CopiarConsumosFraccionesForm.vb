Imports Entidades
Imports Produccion.Negocios
Imports System.Net
Imports Infragistics.Win.UltraWinGrid
Imports Tools
Imports Infragistics.Win

Public Class CopiarConsumosFraccionesForm
    Public idProducto As Integer = 0
    Public idEstiloProd As Integer = 0
    Public idNave As Integer = 0
    Public productoEstiloId As Integer = 0
    Public idNaveProduccion As Integer = 0
    Public PRoductoNaveID As Integer = 0
    Public NaveDesarrollaId As Integer = 0
    Public NaveIDConsulta As Integer = 0

    Public accion As String = "" 'Desarrollo,Producción
    Dim exito As New ExitoForm
    Dim adv As New AdvertenciaForm
    Dim validaConsumo As Boolean = False
    Dim borrar As Boolean = False
    Dim mensaje As String = ""
    Dim codigoProd As String = ""
    Dim suela As String = ""
    Dim caja As String = ""
    Dim marca As String = ""
    Public modelo As String = ""
    Public listaComponentesCopiados As New List(Of Integer)
    Public listaFraccionesCopiadas As New List(Of Integer)
    Public TABLA As New DataTable
    Dim TablaConsumosCopiados As New DataTable

    Public EsAltaProducto As Boolean = False
    Public IdNaveAlta As Integer = -1

    Private Sub CopiarConsumosFraccionesForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim consumo As New ConsumosBU
        Dim NAveDesarrollaID2 As String
        Me.Cursor = Cursors.WaitCursor
        llenarCampos()
        getDatosConsumos()
        getDatosFracciones()
        pintarceldas()
        historial()
        calcularTotales()
        Me.Cursor = Cursors.Default
        crearTablaComponentes()
        Me.tbcImagenesConsumosFracciones.TabPages.Remove(Me.Imagenes)
        Me.tbcImagenesConsumosFracciones.TabPages.Remove(Me.Historiale)

        If EsAltaProducto = True Then

            If NaveIDConsulta <> IdNaveAlta Then
                Me.tbcImagenesConsumosFracciones.TabPages.Remove(Me.Consumos)
                lblTitulo.Text = "Importar Fracciones"
            End If
        Else
            NAveDesarrollaID2 = consumo.getNaveDesarrollaID(productoEstiloId)
            If NaveDesarrollaId <> NaveIDConsulta Then
                Me.tbcImagenesConsumosFracciones.TabPages.Remove(Me.Consumos)
                lblTitulo.Text = "Importar Fracciones"
            End If
        End If

        


    End Sub

    Private Sub llenarCampos()
        Dim datos As New DataTable
        Dim obj As New ConsumosBU
        Me.Text = "" & productoEstiloId & " - Importar Consumos y Fracciones"
        datos = obj.getDatosProducto(productoEstiloId)
        For Each row As DataRow In datos.Rows
            codigoProd = row("Código")
            lblMarca1.Text = row("Marca")
            idProducto = row("idProducto")
            idEstiloProd = row("idEstiloProd")
            idNave = row("idNave")
            lblColec.Text = row("Colección")
            lblTemp.Text = row("Temporada")
            lblCodcli.Text = row("CodigoCliente")
            lblHor.Text = row("Horma")
            lblPielCol.Text = row("PielColor")
            lblCli.Text = row("Cliente")
            lblCorrida.Text = row("Corrida")
            leerimagen(row("Imagen"))
            leerimagen2(row("suela1"))
            leerimagen3(row("caja"))
            leerimagen4(row("Norma"))
            lblModelo1.Text = modelo
        Next
    End Sub

    Public Sub pintarceldas()
        Dim conPrecio As Integer = 0
        Dim sinPrecio As Integer = 0
        Dim i As Integer = 0
        Do
            Try
                If grdFracciones.Rows(i).Cells("Activo").Value = 0 Then
                    grdFracciones.Rows(i).Cells("Activo").Appearance.BackColor = Color.Salmon
                Else
                    grdFracciones.Rows(i).Cells("Activo").Appearance.BackColor = Color.YellowGreen
                    grdFracciones.Rows(i).Cells("Activo").Appearance.BackColor = Color.YellowGreen
                End If
                i += 1
            Catch ex As Exception
            End Try
        Loop While i < grdFracciones.Rows.Count
        i = 0
        Do
            Try
                If grdConsumos.Rows(i).Cells("Activo").Value = 0 Then
                    grdConsumos.Rows(i).Cells("Activo").Appearance.BackColor = Color.Salmon
                Else
                    grdConsumos.Rows(i).Cells("Activo").Appearance.BackColor = Color.YellowGreen
                    grdConsumos.Rows(i).Cells("Activo").Appearance.BackColor = Color.YellowGreen
                End If
            Catch ex As Exception
            End Try
            Try
                If grdConsumos.Rows(i).Cells("Consumo").Value <= 0 Then
                    grdConsumos.Rows(i).Cells("Consumo").Appearance.BackColor = Color.Salmon
                Else
                    grdConsumos.Rows(i).Cells("Consumo").Appearance.BackColor = Color.YellowGreen
                    grdConsumos.Rows(i).Cells("Consumo").Appearance.BackColor = Color.YellowGreen
                End If
            Catch ex As Exception

            End Try
            i += 1
        Loop While i < grdConsumos.Rows.Count
        Try
            For value = 0 To grdConsumos.Rows.Count - 1
                grdConsumos.Rows(value).Cells(" ").Appearance.BackColor = Color.Red
            Next
            For value = 0 To grdFracciones.Rows.Count - 1
                grdFracciones.Rows(value).Cells(" ").Appearance.BackColor = Color.Red
            Next
        Catch ex As Exception
        End Try
    End Sub

    Private Sub getDatosFracciones()
        Dim obj As New catalagosBU
        Dim obj2 As New ConsumosBU
        grdFracciones.DataSource = obj2.getfraccionesDes2(productoEstiloId, idNaveProduccion)
        'getfraccionesDes
        '        grdFracciones.DataSource = obj.getfraccionesCopiar(productoEstiloId)

        With grdFracciones.DisplayLayout.Bands(0)

            .Columns(" ").Header.CheckBoxAlignment = HeaderCheckBoxAlignment.Right
            .Columns(" ").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
            .Columns(" ").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
            .Columns(" ").AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False

            For value = 0 To grdFracciones.Rows.Count - 1
                grdFracciones.Rows(value).Cells(" ").Appearance.BackColor = Color.Red
            Next

            .Columns(" ").Width = 25
            .Columns("Activo").Width = 35
            .Columns("Pagar").Width = 35
            .Columns("Maquinaria").Width = 250
            .Columns("Costo").Width = 45            
            .Columns("maquinaid").Hidden = True
            .Columns("Fracción").Width = 250
            .Columns("Costo").CellAppearance.TextHAlign = HAlign.Right
            .Columns("Activo").CellActivation = Activation.NoEdit
            .Columns("Orden").CellActivation = Activation.NoEdit
            .Columns("idFraccion").Hidden = True
            .Columns("idFraccDes").Hidden = True
            .Columns("Fracción").CellActivation = Activation.NoEdit
            .Columns("Costo").CellActivation = Activation.NoEdit
            .Columns("Maquinaria").CellActivation = Activation.NoEdit
            .Columns("Activo").Header.CheckBoxAlignment = HeaderCheckBoxAlignment.Right
            .Columns("Activo").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
            .Columns("Activo").Style = ColumnStyle.CheckBox
            .Columns("Activo").Header.Caption = "Activo"
            .Columns("Costo").Format = "####0.000"
            .Columns("Pagar").CellActivation = Activation.NoEdit
            '''''''''''''''''''''''''''''''''''''''''''
            .Columns("Sumar Costo").CellActivation = Activation.NoEdit
            .Columns("Observaciones").CellActivation = Activation.NoEdit
            .Columns("Sumar Tiempo").CellActivation = Activation.NoEdit
            .Columns("Horas").CellActivation = Activation.NoEdit
            .Columns("Minutos").CellActivation = Activation.NoEdit
            .Columns("Segundos").CellActivation = Activation.NoEdit
            .Columns("Activo").CellActivation = Activation.NoEdit

            .Columns("Horas").CellAppearance.TextHAlign = HAlign.Right
            .Columns("Minutos").CellAppearance.TextHAlign = HAlign.Right
            .Columns("Segundos").CellAppearance.TextHAlign = HAlign.Right
            .Columns("Sumar Costo").CellAppearance.TextHAlign = HAlign.Right
            .Columns("Pagar").CellAppearance.TextHAlign = HAlign.Right
            .Columns("Costo").CellAppearance.TextHAlign = HAlign.Right
            .Columns("Orden").CellAppearance.TextHAlign = HAlign.Right
            .Columns("Activo").Hidden = True

        End With
        grdFracciones.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdFracciones.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex

        For value = 0 To grdFracciones.Rows.Count - 1
            grdFracciones.Rows(value).Cells(" ").Appearance.BackColor = Color.Red
        Next
    End Sub

    Private Sub getDatosConsumos()
        Dim obj As New catalagosBU
        Dim obj2 As New ConsumosBU
        Dim NaveDesarrolla As String = String.Empty
        'grdConsumos.DataSource = obj.getconsumosCopiar(productoEstiloId)

        NaveDesarrolla = obj2.getNaveDesarrollaID(productoEstiloId)
        If CInt(NaveDesarrolla) = idNaveProduccion Then

            grdConsumos.DataSource = obj2.getconsumosDes2(productoEstiloId)
        Else
            grdConsumos.DataSource = obj2.getconsumosProd2(productoEstiloId, idNaveProduccion)
        End If

        With grdConsumos.DisplayLayout.Bands(0)

            .Columns(" ").Header.CheckBoxAlignment = HeaderCheckBoxAlignment.Right
            .Columns(" ").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
            .Columns(" ").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
            .Columns(" ").AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False

            For value = 0 To grdConsumos.Rows.Count - 1
                grdConsumos.Rows(value).Cells(" ").Appearance.BackColor = Color.Red
            Next

            .Columns("productoEstiloId").Hidden = True
            .Columns("Editado").Hidden = True
            .Columns("idComponente").Hidden = True
            .Columns("idClasificacion").Hidden = True
            .Columns("IdMaterial").Hidden = True
            .Columns("idConsumo").Hidden = True
            .Columns("idProveedor").Hidden = True
            .Columns("idUMC").Hidden = True
            .Columns("idUMProd").Hidden = True
            .Columns("Bloqueado").Hidden = True

            .Columns("Explosionar").Hidden = True
            .Columns("Lotear").Hidden = True

            .Columns("Consumo").CellActivation = Activation.NoEdit
            .Columns("Componente").CellActivation = Activation.NoEdit
            .Columns("Clasificación").CellActivation = Activation.NoEdit
            .Columns("IdMaterial").CellActivation = Activation.NoEdit
            .Columns("SKU").CellActivation = Activation.NoEdit
            .Columns("Material").CellActivation = Activation.NoEdit
            .Columns("UMC").CellActivation = Activation.NoEdit
            .Columns("Proveedor").CellActivation = Activation.NoEdit
            .Columns("Precio UMC").CellActivation = Activation.NoEdit
            .Columns("UMP").CellActivation = Activation.NoEdit
            .Columns("Factor").CellActivation = Activation.NoEdit
            .Columns("Precio UMP").CellActivation = Activation.NoEdit
            .Columns("Costo X Par").CellActivation = Activation.NoEdit
            .Columns("Orden").CellActivation = Activation.NoEdit
            .Columns("Costo X Par").Header.CheckBoxAlignment = HeaderCheckBoxAlignment.Right
            .Columns("Precio UMP").Header.CheckBoxAlignment = HeaderCheckBoxAlignment.Right
            .Columns("Factor").Header.CheckBoxAlignment = HeaderCheckBoxAlignment.Right
            .Columns("Precio UMC").Header.CheckBoxAlignment = HeaderCheckBoxAlignment.Right


            .Columns("Bloqueado").Header.CheckBoxAlignment = HeaderCheckBoxAlignment.Right
            .Columns("Bloqueado").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Bloqueado").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
            .Columns("Bloqueado").AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False

            .Columns("Explosionar").Header.CheckBoxAlignment = HeaderCheckBoxAlignment.Right
            .Columns("Explosionar").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Explosionar").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
            .Columns("Explosionar").AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False

            .Columns("Lotear").Header.CheckBoxAlignment = HeaderCheckBoxAlignment.Right
            .Columns("Lotear").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Lotear").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
            .Columns("Lotear").AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False

            .Columns("Activo").Header.CheckBoxAlignment = HeaderCheckBoxAlignment.Right
            '.Columns("Seleccion").Header.CheckBoxSynchronization = HeaderCheckBoxSynchronization.RowsCollection
            .Columns("Activo").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Activo").Style = ColumnStyle.CheckBox
            .Columns("Activo").Header.Caption = "Activo"
            ' .Columns("").Header.Caption = "Código"

            .Columns("Consumo").Format = "##,##0.00"
            .Columns("Precio UMC").Format = "##,##0.00"
            .Columns("Precio UMP").Format = "##,##0.00"
            .Columns("Costo X Par").Format = "##,##0.00"

            .Columns("Precio UMC").CellAppearance.TextHAlign = HAlign.Right
            .Columns("Precio UMP").CellAppearance.TextHAlign = HAlign.Right
            .Columns("Consumo").CellAppearance.TextHAlign = HAlign.Right
            .Columns("Factor").CellAppearance.TextHAlign = HAlign.Right
            .Columns("Costo X Par").CellAppearance.TextHAlign = HAlign.Right
            .Columns("Orden").CellAppearance.TextHAlign = HAlign.Right
            .Columns("Activo").Hidden = True



            For value = 0 To grdConsumos.Rows.Count - 1
                grdConsumos.Rows(value).Cells(" ").Appearance.BackColor = Color.Red
            Next

        End With
        grdConsumos.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdConsumos.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
    End Sub

    Public Sub leerimagen2(ByVal imagen As String)
        If imagen <> "" Then
            Dim rutaImagen As String
            Dim nombreImagen As String

            rutaImagen = imagen
            nombreImagen = rutaImagen.Substring(rutaImagen.LastIndexOf("\") + 1)
            Try
                'Dim request = DirectCast(WebRequest.Create("ftp://192.168.7.16"), FtpWebRequest)
                'request.Credentials = New NetworkCredential("prod\yuyinerp", "yuyinerp")
                Dim objFTP As New Tools.TransferenciaFTP
                Dim Stream As System.IO.Stream
                Stream = objFTP.StreamFile("Programacion/Modelos/", nombreImagen)
                picSuela.Image = Image.FromStream(Stream)
                'picFotografia.SizeMode = PictureBoxSizeMode.StretchImage
            Catch
            End Try
        ElseIf imagen = "" Then
            imagen = "noimage.jpg"
            Try
                'Dim request = DirectCast(WebRequest.Create("ftp://192.168.7.16"), FtpWebRequest)
                'request.Credentials = New NetworkCredential("prod\yuyinerp", "yuyinerp")
                Dim objFTP As New Tools.TransferenciaFTP
                Dim Stream As System.IO.Stream
                Stream = objFTP.StreamFile("/Administracion/Proveedores/", imagen)
                picSuela.Image = Image.FromStream(Stream)
                picSuela.SizeMode = PictureBoxSizeMode.StretchImage
            Catch
            End Try
        End If

    End Sub
    Public Sub leerimagen3(ByVal imagen As String)
        If imagen <> "" Then
            Dim rutaImagen As String
            Dim nombreImagen As String

            rutaImagen = imagen
            nombreImagen = rutaImagen.Substring(rutaImagen.LastIndexOf("\") + 1)
            Try
                'Dim request = DirectCast(WebRequest.Create("ftp://192.168.7.16"), FtpWebRequest)
                'request.Credentials = New NetworkCredential("prod\yuyinerp", "yuyinerp")
                Dim objFTP As New Tools.TransferenciaFTP
                Dim Stream As System.IO.Stream
                Stream = objFTP.StreamFile("Programacion/Modelos/", nombreImagen)
                picCaja.Image = Image.FromStream(Stream)
                'picFotografia.SizeMode = PictureBoxSizeMode.StretchImage
            Catch
            End Try
        ElseIf imagen = "" Then
            imagen = "noimage.jpg"
            Try
                'Dim request = DirectCast(WebRequest.Create("ftp://192.168.7.16"), FtpWebRequest)
                'request.Credentials = New NetworkCredential("prod\yuyinerp", "yuyinerp")
                Dim objFTP As New Tools.TransferenciaFTP
                Dim Stream As System.IO.Stream
                Stream = objFTP.StreamFile("/Administracion/Proveedores/", imagen)
                picCaja.Image = Image.FromStream(Stream)
                picCaja.SizeMode = PictureBoxSizeMode.StretchImage
            Catch
            End Try
        End If

    End Sub
    Public Sub leerimagen4(ByVal imagen As String)
        If imagen <> "" Then
            Dim rutaImagen As String
            Dim nombreImagen As String

            rutaImagen = imagen
            nombreImagen = rutaImagen.Substring(rutaImagen.LastIndexOf("\") + 1)
            Try
                'Dim request = DirectCast(WebRequest.Create("ftp://192.168.7.16"), FtpWebRequest)
                'request.Credentials = New NetworkCredential("prod\yuyinerp", "yuyinerp")
                Dim objFTP As New Tools.TransferenciaFTP
                Dim Stream As System.IO.Stream
                Stream = objFTP.StreamFile("Programacion/Modelos/", nombreImagen)
                picMarca.Image = Image.FromStream(Stream)
                'picFotografia.SizeMode = PictureBoxSizeMode.StretchImage
            Catch
            End Try
        ElseIf imagen = "" Then
            imagen = "noimage.jpg"
            Try
                'Dim request = DirectCast(WebRequest.Create("ftp://192.168."), FtpWebRequest)
                'request.Credentials = New NetworkCredential("prod\yuyinerp", "yuyinerp")
                Dim objFTP As New Tools.TransferenciaFTP
                Dim Stream As System.IO.Stream
                Stream = objFTP.StreamFile("/Administracion/Proveedores/", imagen)
                picMarca.Image = Image.FromStream(Stream)
                picMarca.SizeMode = PictureBoxSizeMode.StretchImage
            Catch
            End Try
        End If

    End Sub
    Public Sub leerimagen(ByVal imagen As String)
        If imagen <> "" Then
            Dim rutaImagen As String
            Dim nombreImagen As String

            rutaImagen = imagen
            nombreImagen = rutaImagen.Substring(rutaImagen.LastIndexOf("\") + 1)
            Try
                'Dim request = DirectCast(WebRequest.Create("ftp://192.168.7.16"), FtpWebRequest)
                'request.Credentials = New NetworkCredential("prod\yuyinerp", "yuyinerp")
                Dim objFTP As New Tools.TransferenciaFTP
                Dim Stream As System.IO.Stream
                Stream = objFTP.StreamFile("Programacion/Modelos/", nombreImagen)
                picFotografia.Image = Image.FromStream(Stream)
                'picFotografia.SizeMode = PictureBoxSizeMode.StretchImage
            Catch
            End Try
        ElseIf imagen = "" Then
            imagen = "noimage.jpg"
            Try
                'Dim request = DirectCast(WebRequest.Create("ftp://192.168.7.16"), FtpWebRequest)
                'request.Credentials = New NetworkCredential("prod\yuyinerp", "yuyinerp")
                Dim objFTP As New Tools.TransferenciaFTP
                Dim Stream As System.IO.Stream
                Stream = objFTP.StreamFile("/Administracion/Proveedores/", imagen)
                picFotografia.Image = Image.FromStream(Stream)
                picFotografia.SizeMode = PictureBoxSizeMode.StretchImage
            Catch
            End Try
        End If

    End Sub

    Private Sub grdConsumos_KeyUp(sender As Object, e As KeyEventArgs) Handles grdConsumos.KeyUp
        pintarceldas()
    End Sub

    Private Function nuevoconsumo() As Boolean
        Dim d As New DataTable
        d = grdConsumos.DataSource
        For Each row As DataRow In d.Rows
            Try
                If row("idComponente") = 0 Then
                    Return False
                End If
                If row("idclasificacion") = 0 Then
                    Return False
                End If
                If row("IdMaterial") = 0 Then
                    Return False
                End If
                If row("idUMC") = 0 Then
                    Return False
                End If
                If row("idProveedor") = 0 Then
                    Return False
                End If
                If row("Consumo") <= 0 Then
                    Return False
                End If
            Catch ex As Exception
                Return True
            End Try
        Next
        Return True
    End Function

    Private Function nuevofraccion() As Boolean
        Dim d As New DataTable
        d = grdFracciones.DataSource
        For Each row As DataRow In d.Rows
            Try
                If row("idFraccion") = 0 Then
                    Return False
                End If
            Catch ex As Exception
                Return True
            End Try
        Next
        Return True
    End Function

    Private Sub guardarFraccionesDesarrollo()
        Dim fraccion As New Fracciones
        Dim obj As New ConsumosBU
        Dim datos As New DataTable
        Try
            datos = grdFracciones.DataSource
            Me.Cursor = Cursors.WaitCursor
            For Each row As DataRow In datos.Rows
                Try
                    fraccion = New Fracciones
                    'consumo.bloqueado = CBool(row("Bloqueado"))
                    fraccion.productoEstiloId = productoEstiloId
                    fraccion.frap_fraccionid = row("idFraccion")
                    fraccion.fraccionidProd = row("idFraccDes")
                    If CBool(row("Activo")) Then
                        fraccion.frap_activo = 1
                    Else
                        fraccion.frap_activo = 0
                    End If
                    If row("idFraccDes") = 0 Then
                        fraccion.accion = 1
                    Else
                        fraccion.accion = 2
                    End If
                    fraccion.frap_activo = row("Activo")
                    obj.insertFraccionDes(fraccion)
                Catch ex As Exception
                End Try
            Next
            getDatosFracciones()

            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            adv.mensaje = "Surgió algo inesperado: " & ex.Message
            adv.StartPosition = FormStartPosition.CenterScreen
            adv.ShowDialog()
        End Try
    End Sub

    Private Sub guardarConsumosDesarrollo()
        Dim consumo As New Consumo
        Dim obj As New ConsumosBU
        Dim datos As New DataTable
        Try
            datos = grdConsumos.DataSource
            Me.Cursor = Cursors.WaitCursor
            For Each row As DataRow In datos.Rows
                Try
                    consumo = New Consumo
                    consumo.bloqueado = CBool(row("Bloqueado"))
                    consumo.explosionar = CBool(row("Explosionar"))
                    consumo.lotear = CBool(row("Lotear"))
                    consumo.componenteid = row("idComponente")
                    consumo.clasificacionid = row("idclasificacion")
                    consumo.materialId = row("IdMaterial")
                    consumo.idconsumo = row("idConsumo")
                    consumo.umproduccionid = row("idUMC")
                    consumo.proveedorId = row("idProveedor")
                    consumo.costopar = row("Costo X Par")
                    consumo.productoEstiloId = productoEstiloId
                    consumo.consumo = row("Consumo")
                    consumo.umProveedorId = row("idUMProd")
                    consumo.precioumproduccion = row("PrecioUM")
                    consumo.factorconversion = row("Factor")
                    consumo.preciocompra = row("Precio Compra")
                    consumo.activo = row("Activo")
                    If row("idConsumo") = 0 Then
                        consumo.accion = 1
                    Else
                        consumo.accion = 2
                    End If
                    obj.insertConsumo(consumo)
                Catch ex As Exception
                End Try
            Next
            getDatosConsumos()
            pintarceldas()
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            adv.mensaje = "Surgió algo inesperado: " & ex.Message
            adv.StartPosition = FormStartPosition.CenterScreen
            adv.ShowDialog()
        End Try
    End Sub

    Private Sub grdConsumos_BeforeCellUpdate(sender As Object, e As BeforeCellUpdateEventArgs) Handles grdConsumos.BeforeCellUpdate
        If e.Cell.Column.ToString = "Consumo" Or e.Cell.Column.ToString = "Costo X Par" Then
            Try
                Convert.ToDouble(e.NewValue)
                validaConsumo = True
            Catch ex As Exception
                e.Cancel = True
                validaConsumo = False
                adv.mensaje = "Ingrese un número válido."
                adv.StartPosition = FormStartPosition.CenterScreen
                adv.ShowDialog()
            End Try
        End If
    End Sub

    Private Sub grdConsumos_KeyPress(sender As Object, e As KeyPressEventArgs) Handles grdConsumos.KeyPress
        If grdConsumos.Rows.Count > 0 Then
            Try
                If Not grdConsumos.ActiveCell.IsFilterRowCell Then
                    If Char.IsDigit(e.KeyChar) Then
                        e.Handled = False
                    ElseIf Char.IsControl(e.KeyChar) Then
                        e.Handled = False
                    ElseIf e.KeyChar = "." Then
                        e.Handled = False
                    Else
                        e.Handled = True
                    End If
                End If
            Catch ex As Exception
            End Try
        End If
    End Sub

    Public Sub GuardarImagen()
        Try
            Dim obj As New ConsumosBU

            If suela.Length > 0 Then
                obj.ActualizarImagenes(codigoProd & "/" & suela, "",
                                  "", productoEstiloId)
            End If
            If caja.Length > 0 Then
                obj.ActualizarImagenes("", codigoProd & "/" & caja,
                                      "", productoEstiloId)
            End If
            If marca.Length > 0 Then
                obj.ActualizarImagenes("", "",
                                      codigoProd & "/" & marca, productoEstiloId)
            End If
            Dim objFTP As New Tools.TransferenciaFTP
            ''Crea la carpeta
            objFTP.EnviarArchivo("Programacion/Modelos/" & codigoProd & "/", "")
            'Copia las imagenes
            objFTP.EnviarArchivo("Programacion/Modelos/" & codigoProd & "/", txtSuela.Text)
            objFTP.EnviarArchivo("Programacion/Modelos/" & codigoProd, txtCaja.Text)
            objFTP.EnviarArchivo("Programacion/Modelos/" & codigoProd, txtMarca.Text)
        Catch ex As Exception
            mensaje += "Fotos"
        End Try
    End Sub

    Public Sub crearTablaComponentes()
        TABLA.Columns.Add(" ")
        TABLA.Columns.Add("Activo", System.Type.GetType("System.Boolean"))
        TABLA.Columns.Add("idFraccion")
        TABLA.Columns.Add("idFraccDes")
        TABLA.Columns.Add("Fracción")
        TABLA.Columns.Add("Costo")
        TABLA.Columns.Add("Pagar")
        TABLA.Columns.Add("Maquinaria")
        ''''''''''''''''''''''''''''''''''''''
        TABLA.Columns.Add("Sumar Costo")
        TABLA.Columns.Add("Sumar Tiempo")
        TABLA.Columns.Add("Horas")
        TABLA.Columns.Add("Minutos")
        TABLA.Columns.Add("Segundos")
        TABLA.Columns.Add("Observaciones")
    End Sub


    Public Sub crearTablaConsumos()
        TablaConsumosCopiados.Columns.Add(" ")
        TablaConsumosCopiados.Columns.Add("Activo", System.Type.GetType("System.Boolean"))
        TablaConsumosCopiados.Columns.Add("productoEstiloId")
        TablaConsumosCopiados.Columns.Add("idComponente")
        TablaConsumosCopiados.Columns.Add("idClasificacion")
        TablaConsumosCopiados.Columns.Add("IdMaterial")
        TablaConsumosCopiados.Columns.Add("idConsumo")
        TablaConsumosCopiados.Columns.Add("idProveedor")
        ''''''''''''''''''''''''''''''''''''''
        TablaConsumosCopiados.Columns.Add("idUMC")
        TablaConsumosCopiados.Columns.Add("idUMProd")
        TablaConsumosCopiados.Columns.Add("Bloqueado", System.Type.GetType("System.Boolean"))
        TablaConsumosCopiados.Columns.Add("Explosionar", System.Type.GetType("System.Boolean"))
        TablaConsumosCopiados.Columns.Add("Lotear", System.Type.GetType("System.Boolean"))

        TablaConsumosCopiados.Columns.Add("Consumo")
        TablaConsumosCopiados.Columns.Add("Componente")
        TablaConsumosCopiados.Columns.Add("Clasificación")        
        TablaConsumosCopiados.Columns.Add("SKU")
        TablaConsumosCopiados.Columns.Add("Material")
        TablaConsumosCopiados.Columns.Add("UMC")
        TablaConsumosCopiados.Columns.Add("Proveedor")
        TablaConsumosCopiados.Columns.Add("Precio UMC")
        TablaConsumosCopiados.Columns.Add("UMP")
        TablaConsumosCopiados.Columns.Add("Factor")
        TablaConsumosCopiados.Columns.Add("Precio UMP")
        TablaConsumosCopiados.Columns.Add("Costo X Par")
        TablaConsumosCopiados.Columns.Add("Orden")
       
     

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim r As DataRow
        Dim c As DataRow
        crearTablaConsumos()

        Try
            For value = 0 To grdConsumos.Rows.Count - 1
                If CBool(grdConsumos.Rows(value).Cells(" ").Text) = True Then
                    listaComponentesCopiados.Add(grdConsumos.Rows(value).Cells("idConsumo").Text)

                    c = TablaConsumosCopiados.NewRow()
                    c(" ") = grdConsumos.Rows(value).Cells(" ").Text
                    c("Activo") = CBool(grdConsumos.Rows(value).Cells("Activo").Value)
                    c("productoEstiloId") = grdConsumos.Rows(value).Cells("productoEstiloId").Text
                    c("idComponente") = grdConsumos.Rows(value).Cells("idComponente").Text
                    c("idClasificacion") = grdConsumos.Rows(value).Cells("idClasificacion").Text
                    c("IdMaterial") = grdConsumos.Rows(value).Cells("IdMaterial").Text
                    c("idConsumo") = grdConsumos.Rows(value).Cells("idConsumo").Text
                    c("idProveedor") = grdConsumos.Rows(value).Cells("idProveedor").Text
                    ''''''''''''''''''''
                    c("idUMC") = grdConsumos.Rows(value).Cells("idUMC").Text
                    c("idUMProd") = grdConsumos.Rows(value).Cells("idUMProd").Text
                    c("Bloqueado") = CBool(grdConsumos.Rows(value).Cells("Bloqueado").Value)
                    c("Explosionar") = CBool(grdConsumos.Rows(value).Cells("Explosionar").Value)
                    c("Lotear") = CBool(grdConsumos.Rows(value).Cells("Lotear").Value)
                    c("Consumo") = grdConsumos.Rows(value).Cells("Consumo").Text
                    c("Componente") = grdConsumos.Rows(value).Cells("Componente").Text
                    c("Clasificación") = grdConsumos.Rows(value).Cells("Clasificación").Text
                    c("SKU") = grdConsumos.Rows(value).Cells("SKU").Text
                    c("Material") = grdConsumos.Rows(value).Cells("Material").Text
                    c("UMC") = grdConsumos.Rows(value).Cells("UMC").Text
                    c("Proveedor") = grdConsumos.Rows(value).Cells("Proveedor").Text
                    c("Precio UMC") = grdConsumos.Rows(value).Cells("Precio UMC").Text
                    c("UMP") = grdConsumos.Rows(value).Cells("UMP").Text
                    c("Factor") = grdConsumos.Rows(value).Cells("Factor").Text
                    c("Precio UMP") = grdConsumos.Rows(value).Cells("Precio UMP").Text
                    c("Costo X Par") = grdConsumos.Rows(value).Cells("Costo X Par").Text
                    c("Orden") = grdConsumos.Rows(value).Cells("Orden").Text
                    TablaConsumosCopiados.Rows.Add(c)

                  
                  


                End If
            Next
            For value = 0 To grdFracciones.Rows.Count - 1
                If CBool(grdFracciones.Rows(value).Cells(" ").Text) = True Then
                    listaFraccionesCopiadas.Add(grdFracciones.Rows(value).Cells("idFraccDes").Text)
                    r = TABLA.NewRow()
                    r(" ") = grdFracciones.Rows(value).Cells(" ").Text
                    r("Activo") = CBool(grdFracciones.Rows(value).Cells("Activo").Value)
                    r("idFraccion") = grdFracciones.Rows(value).Cells("idFraccion").Text
                    r("idFraccDes") = grdFracciones.Rows(value).Cells("idFraccDes").Text
                    r("Fracción") = grdFracciones.Rows(value).Cells("Fracción").Text
                    r("Costo") = grdFracciones.Rows(value).Cells("Costo").Text
                    r("Pagar") = grdFracciones.Rows(value).Cells("Pagar").Text
                    r("Maquinaria") = grdFracciones.Rows(value).Cells("Maquinaria").Text
                    ''''''''''''''''''''
                    r("Sumar Costo") = grdFracciones.Rows(value).Cells("Sumar Costo").Text
                    r("Sumar Tiempo") = grdFracciones.Rows(value).Cells("Sumar Tiempo").Text
                    r("Horas") = grdFracciones.Rows(value).Cells("Horas").Text
                    r("Minutos") = grdFracciones.Rows(value).Cells("Minutos").Text
                    r("Segundos") = grdFracciones.Rows(value).Cells("Segundos").Text
                    r("Observaciones") = grdFracciones.Rows(value).Cells("Observaciones").Text
                    TABLA.Rows.Add(r)
                End If
            Next
            Me.Close()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub grdConsumos_AfterCellUpdate(sender As Object, e As CellEventArgs) Handles grdConsumos.AfterCellUpdate
        If validaConsumo Then
            Try
                grdConsumos.ActiveRow.Cells("Costo X Par").Value = (grdConsumos.ActiveRow.Cells("PrecioUM").Value * grdConsumos.ActiveRow.Cells("Consumo").Value)
            Catch ex As Exception
            End Try
        End If
        pintarceldas()
    End Sub

    Private Sub grdConsumos_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdConsumos.BeforeRowsDeleted, grdFracciones.BeforeRowsDeleted
        e.DisplayPromptMsg = False
        If borrar Then
            borrar = False
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles btnAddSuela.Click
        ofdFoto.Filter = "Image Files (JPEG,GIF,BMP,PNG,ICO)|*.jpg;*.jpeg;*.gif;*.bmp;*.png;*ico"
        If ofdFoto.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Dim sr As New System.IO.StreamReader(ofdFoto.FileName)
            picSuela.Image = Drawing.Image.FromFile(ofdFoto.FileName)
            suela = ofdFoto.FileName
            Dim tabla() As String
            tabla = Split(suela, "\")
            For n = 0 To UBound(tabla, 1)
                If UBound(tabla) = n Then
                    suela = tabla(n)
                End If
            Next
            txtSuela.Text = ofdFoto.FileName
        End If
    End Sub

    Private Sub btnAgregarFotografia_Click(sender As Object, e As EventArgs) Handles btnAgregarFotografia.Click
        'ofdFoto.Filter = "Image Files (JPEG,GIF,BMP,PNG,ICO)|*.jpg;*.jpeg;*.gif;*.bmp;*.png;*ico"
        'If ofdFoto.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
        '    Dim sr As New System.IO.StreamReader(ofdFoto.FileName)
        '    picFotografia.Image = Drawing.Image.FromFile(ofdFoto.FileName)

        '    txtFoto.Text = ofdFoto.FileName
        'End If
    End Sub

    Private Sub btnAddCaja_Click(sender As Object, e As EventArgs) Handles btnAddCaja.Click
        ofdFoto.Filter = "Image Files (JPEG,GIF,BMP,PNG,ICO)|*.jpg;*.jpeg;*.gif;*.bmp;*.png;*ico"
        If ofdFoto.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Dim sr As New System.IO.StreamReader(ofdFoto.FileName)
            picCaja.Image = Drawing.Image.FromFile(ofdFoto.FileName)
            caja = ofdFoto.FileName
            Dim tabla() As String
            tabla = Split(caja, "\")
            For n = 0 To UBound(tabla, 1)
                If UBound(tabla) = n Then
                    caja = tabla(n)
                End If
            Next
            txtCaja.Text = ofdFoto.FileName
        End If
    End Sub

    Private Sub btnAddMarca_Click(sender As Object, e As EventArgs) Handles btnAddMarca.Click
        ofdFoto.Filter = "Image Files (JPEG,GIF,BMP,PNG,ICO)|*.jpg;*.jpeg;*.gif;*.bmp;*.png;*ico"
        If ofdFoto.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Dim sr As New System.IO.StreamReader(ofdFoto.FileName)
            picMarca.Image = Drawing.Image.FromFile(ofdFoto.FileName)
            marca = ofdFoto.FileName
            Dim tabla() As String
            tabla = Split(marca, "\")
            For n = 0 To UBound(tabla, 1)
                If UBound(tabla) = n Then
                    marca = tabla(n)
                End If
            Next
            txtMarca.Text = ofdFoto.FileName
        End If
    End Sub

    Private Sub grdFracciones_KeyUp(sender As Object, e As KeyEventArgs) Handles grdFracciones.KeyUp
        pintarceldas()
    End Sub

    Private Sub tbcImagenesConsumosFracciones_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tbcImagenesConsumosFracciones.SelectedIndexChanged
        Try
            If tbcImagenesConsumosFracciones.SelectedIndex = 1 Then
                ''lblTotalEtq.Text = "Total Consumos"
                ''Dim d As New DataTable
                ''Dim total As Double = 0
                ''d = grdConsumos.DataSource
                ''For Each row As DataRow In d.Rows
                ''    total += row("Costo X Par")
                ''Next
                ''lblTotal.Visible = True
                ''lblTotalEtq.Visible = True
                ''lblTotal.Text = "$ " & total.ToString("##,##0.0#")
                'lblTotalEtq.Text = "Total Consumos"
                'Dim d As New DataTable
                'Dim total As Double = 0
                'd = grdConsumos.DataSource
                'For Each row As DataRow In d.Rows
                '    total += row("Costo X Par")
                'Next
                'lblTotal.Visible = True
                'lblTotalEtq.Visible = True
                'lblTotal.Text = "$ " & total.ToString("##,##0.00")
                'Try
                '    Dim d2 As New DataTable
                '    Dim total2 As Double = 0
                '    d2 = grdFracciones.DataSource
                '    For Each row As DataRow In d2.Rows
                '        total2 += row("Costo")
                '    Next
                '    lblTotalF.Text = "$ " & total2.ToString("##,##0.000")
                'Catch ex As Exception
                'End Try

                calcularTotales()
            End If
            If tbcImagenesConsumosFracciones.SelectedIndex = 2 Then
                calcularTotales()
            End If
            'lblTotalEtq.Text = "Total Fracciones"
            'Dim d As New DataTable
            'Dim total As Double = 0
            'd = grdFracciones.DataSource
            'For Each row As DataRow In d.Rows
            '    total += row("Costo")
            'Next
            'lblTotal.Visible = True
            'lblTotalEtq.Visible = True
            'lblTotal.Text = "$ " & total.ToString("##,##0.0#")
            '        lblTotalEtq.Text = "Total Consumos"
            '        Dim d As New DataTable
            '        Dim total As Double = 0
            '        d = grdConsumos.DataSource
            '        For Each row As DataRow In d.Rows
            '            total += row("Costo X Par")
            '        Next
            '        lblTotal.Visible = True
            '        lblTotalEtq.Visible = True
            '        lblTotal.Text = "$ " & total.ToString("##,##0.00")
            '        Try
            '            Dim d2 As New DataTable
            '            Dim total2 As Double = 0
            '            d2 = grdFracciones.DataSource
            '            For Each row As DataRow In d2.Rows
            '                total2 += row("Costo")
            '            Next
            '            lblTotalF.Text = "$ " & total2.ToString("##,##0.000")
            '        Catch ex As Exception
            '        End Try
            '    End If
        Catch ex As Exception
        End Try
    End Sub

    'Public Sub calcularTotales()
    '    Try

    '        lblTotalEtq.Text = "Total Consumos"
    '        Dim d As New DataTable
    '        Dim total As Double = 0
    '        Dim totalCasco As Double = 0
    '        Dim totalContra As Double = 0
    '        Dim totalCaja As Double = 0
    '        d = grdConsumos.DataSource
    '        For Each row As DataRow In d.Rows
    '            If row("Componente") = "CASCO" Or row("Componente") = "CONTRAFUERTE" Or row("Componente") = "CAJA" Then
    '            Else
    '                total += row("Costo X Par")
    '            End If
    '        Next

    '        For Each row As DataRow In d.Rows
    '            Dim x = row("Componente")
    '            If row("Componente") = "CASCO" Then
    '                Dim y = row("Costo X Par")
    '                If totalCasco < row("Costo X Par") Then
    '                    totalCasco = row("Costo X Par")
    '                End If
    '            End If
    '            If row("Componente") = "CONTRAFUERTE" Then
    '                Dim y2 = row("Costo X Par")
    '                If totalContra < row("Costo X Par") Then
    '                    totalContra = row("Costo X Par")
    '                End If
    '            End If
    '            If row("Componente") = "CAJA" Then
    '                Dim y3 = row("Costo X Par")
    '                If totalCaja < row("Costo X Par") Then
    '                    totalCaja = row("Costo X Par")
    '                End If
    '            End If
    '        Next

    '        total += totalCasco + totalContra + totalCaja

    '        lblTotal.Visible = True
    '        lblTotalEtq.Visible = True
    '        lblTotal.Text = "$ " & total.ToString("##,##0.00")
    '        Try
    '            Dim d2 As New DataTable
    '            Dim total2 As Double = 0

    '            For value = 0 To grdConsumos.Rows.Count - 1
    '                total = total + grdConsumos.Rows(value).Cells("Costo").Value
    '            Next
    '            lblTotalF.Text = "$ " & total2.ToString("##,##0.000")
    '        Catch ex As Exception
    '        End Try

    '        lblTotalEtq.Text = "Total Consumos"

    '        For Each row As DataRow In d.Rows
    '            If row("Componente") = "CASCO" Or row("Componente") = "CONTRAFUERTE" Or row("Componente") = "CAJA" Then
    '            Else
    '                total += row("Costo X Par")
    '            End If
    '        Next

    '        For Each row As DataRow In d.Rows
    '            Dim x = row("Componente")
    '            If row("Componente") = "CASCO" Then
    '                Dim y = row("Costo X Par")
    '                If totalCasco < row("Costo X Par") Then
    '                    totalCasco = row("Costo X Par")
    '                End If
    '            End If
    '            If row("Componente") = "CONTRAFUERTE" Then
    '                Dim y2 = row("Costo X Par")
    '                If totalContra < row("Costo X Par") Then
    '                    totalContra = row("Costo X Par")
    '                End If
    '            End If
    '            If row("Componente") = "CAJA" Then
    '                Dim y3 = row("Costo X Par")
    '                If totalCaja < row("Costo X Par") Then
    '                    totalCaja = row("Costo X Par")
    '                End If
    '            End If
    '        Next

    '        total += totalCasco + totalContra + totalCaja
    '        total = total / 2

    '        lblTotal.Visible = True
    '        lblTotalEtq.Visible = True
    '        lblTotal.Text = "$ " & total.ToString("##,##0.00")
    '        Try
    '            Dim d2 As New DataTable
    '            Dim total2 As Double = 0
    '            d2 = grdFracciones.DataSource

    '            For value = 0 To grdFracciones.Rows.Count - 1
    '                If grdFracciones.Rows(value).Cells("Sumar Costo").Value = True Then
    '                    total2 = total2 + grdFracciones.Rows(value).Cells("Costo").Value
    '                End If
    '            Next

    '            lblTotalF.Text = "$ " & total2.ToString("##,##0.000")
    '        Catch ex As Exception
    '        End Try
    '    Catch ex As Exception
    '    End Try
    '    Try
    '        Dim Horas As Integer = 0
    '        Dim h1 As Integer = 0
    '        Dim Minutos As Integer = 0
    '        Dim m1 As Integer = 0
    '        Dim Segundos As Integer = 0
    '        Dim s1 As Integer = 0
    '        Dim tiempo As String = ""

    '        For value = 0 To grdFracciones.Rows.Count - 1

    '            If grdFracciones.Rows(value).Cells("Sumar Tiempo").Value = True Then
    '                If grdFracciones.Rows(value).Cells("Horas").Text <> "" Then
    '                    Horas = Horas + grdFracciones.Rows(value).Cells("Horas").Value
    '                End If
    '                If grdFracciones.Rows(value).Cells("Minutos").Text <> "" Then
    '                    Minutos = Minutos + grdFracciones.Rows(value).Cells("Minutos").Value
    '                End If
    '                If grdFracciones.Rows(value).Cells("Segundos").Text <> "" Then
    '                    Segundos = Segundos + grdFracciones.Rows(value).Cells("Segundos").Value
    '                End If
    '            End If
    '        Next

    '        Horas = Horas * 3600
    '        Minutos = Minutos * 60
    '        Segundos = Segundos + Horas + Minutos

    '        h1 = Math.Floor(Segundos / 3600)
    '        m1 = Math.Floor((Segundos - h1 * 3600) / 60)
    '        s1 = Segundos - (h1 * 3600 + m1 * 60)
    '        Dim h As String = ""
    '        Dim m As String = ""
    '        Dim s As String = ""

    '        If h1.ToString.Length = 1 Then
    '            h = "0" + h1.ToString
    '        ElseIf h1.ToString.Length = 0 Then
    '            h = "00"
    '        Else
    '            h = h1.ToString
    '        End If
    '        If m1.ToString.Length = 1 Then
    '            m = "0" + m1.ToString
    '        ElseIf m1.ToString.Length = 0 Then
    '            m = "00"
    '        Else
    '            m = m1.ToString
    '        End If
    '        If s1.ToString.Length = 1 Then
    '            s = "0" + s1.ToString
    '        ElseIf s1.ToString.Length = 0 Then
    '            s = "00"
    '        Else
    '            s = s1.ToString
    '        End If
    '        tiempo = h.ToString + ":" + m.ToString + ":" + s.ToString
    '        lblTotalTiempo.Text = tiempo
    '    Catch ex As Exception
    '    End Try

    'End Sub



    Public Sub calcularTotales()
        Try

            lblTotalEtq.Text = "Total Consumos"
            Dim d As New DataTable
            Dim total As Double = 0
            Dim totalCasco As Double = 0
            Dim totalContra As Double = 0
            Dim totalCaja As Double = 0
            d = grdConsumos.DataSource

            For Each fila As UltraGridRow In grdConsumos.Rows
                If CBool(fila.Cells("Activo").Value) = True Then
                    total += fila.Cells("Costo X Par").Text
                End If
            Next


            lblTotal.Visible = True
            lblTotalEtq.Visible = True
            lblTotal.Text = "$ " & total.ToString("##,##0.00")
            Try
                Dim d2 As New DataTable
                Dim total2 As Double = 0
                d2 = grdFracciones.DataSource

                For value = 0 To grdFracciones.Rows.Count - 1
                    If CBool(grdFracciones.Rows(value).Cells("Activo").Value) = True Then
                        If grdFracciones.Rows(value).Cells("Sumar Costo").Value = True Then
                            total2 = total2 + grdFracciones.Rows(value).Cells("Costo").Text
                        End If
                    End If
                Next
                lblTotalF.Text = "$ " & total2.ToString("##,##0.000")
            Catch ex As Exception
                Dim valor As String = String.Empty
                valor = "cadena"
            End Try
        Catch ex As Exception
        End Try
        Try
            Dim Horas As Integer = 0
            Dim h1 As Integer = 0
            Dim Minutos As Integer = 0
            Dim m1 As Integer = 0
            Dim Segundos As Integer = 0
            Dim s1 As Integer = 0
            Dim tiempo As String = ""

            For value = 0 To grdFracciones.Rows.Count - 1

                If CBool(grdFracciones.Rows(value).Cells("Sumar Tiempo").Value) = True Then
                    If grdFracciones.Rows(value).Cells("Horas").Text <> "" Then
                        Horas = Horas + grdFracciones.Rows(value).Cells("Horas").Text
                    End If
                    If grdFracciones.Rows(value).Cells("Minutos").Text <> "" Then
                        Minutos = Minutos + grdFracciones.Rows(value).Cells("Minutos").Text
                    End If
                    If grdFracciones.Rows(value).Cells("Segundos").Text <> "" Then
                        Segundos = Segundos + grdFracciones.Rows(value).Cells("Segundos").Text
                    End If
                End If
            Next

            Horas = Horas * 3600
            Minutos = Minutos * 60
            Segundos = Segundos + Horas + Minutos

            h1 = Math.Floor(Segundos / 3600)
            m1 = Math.Floor((Segundos - h1 * 3600) / 60)
            s1 = Segundos - (h1 * 3600 + m1 * 60)
            Dim h As String = ""
            Dim m As String = ""
            Dim s As String = ""

            If h1.ToString.Length = 1 Then
                h = "0" + h1.ToString
            ElseIf h1.ToString.Length = 0 Then
                h = "00"
            Else
                h = h1.ToString
            End If
            If m1.ToString.Length = 1 Then
                m = "0" + m1.ToString
            ElseIf m1.ToString.Length = 0 Then
                m = "00"
            Else
                m = m1.ToString
            End If
            If s1.ToString.Length = 1 Then
                s = "0" + s1.ToString
            ElseIf s1.ToString.Length = 0 Then
                s = "00"
            Else
                s = s1.ToString
            End If
            tiempo = h.ToString + ":" + m.ToString + ":" + s.ToString
            lblTotalTiempo.Text = tiempo
        Catch ex As Exception
        End Try

    End Sub


    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub grdFracciones_CellChange(sender As Object, e As CellEventArgs) Handles grdFracciones.CellChange
        'If e.Cell.Column.ToString = "Activo" Then
        '    If CBool(e.Cell.Value) Then
        '        grdFracciones.ActiveRow.Cells("Activo").Value = False
        '    Else
        '        grdFracciones.ActiveRow.Cells("Activo").Value = True
        '    End If
        'End If
        'pintarceldas()
    End Sub

    Private Sub grdConsumos_CellChange(sender As Object, e As CellEventArgs) Handles grdConsumos.CellChange
        If e.Cell.Column.ToString = "Activo" Then
            If CBool(e.Cell.Value) Then
                grdConsumos.ActiveRow.Cells("Activo").Value = False
            Else
                grdConsumos.ActiveRow.Cells("Activo").Value = True
            End If
        End If
        pintarceldas()
    End Sub

    Private Sub grdConsumos_KeyDown(sender As Object, e As KeyEventArgs) Handles grdConsumos.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Enter Then
                grdConsumos.PerformAction(UltraGridAction.ExitEditMode, False, False)
                Dim banda As UltraGridBand = grdConsumos.DisplayLayout.Bands(0)
                If grdConsumos.ActiveRow.HasNextSibling(True) Then
                    Dim nextRow As UltraGridRow = grdConsumos.ActiveRow.GetSibling(SiblingRow.Next, True)
                    grdConsumos.ActiveCell = nextRow.Cells(grdConsumos.ActiveCell.Column)
                    e.Handled = True
                    grdConsumos.PerformAction(UltraGridAction.EnterEditMode, False, False)
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        suela = "..."
        picSuela.Image = Nothing
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        caja = "..."
        picCaja.Image = Nothing
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        marca = "..."
        picMarca.Image = Nothing
    End Sub

    Private Sub chbSeleccionarTodo_CheckedChanged(sender As Object, e As EventArgs) Handles chbSeleccionarTodo.CheckedChanged

        If tbcImagenesConsumosFracciones.SelectedIndex = 0 Then
            Dim x = 0
            If chbSeleccionarTodo.Text = "Seleccionar Todo" And x = 0 Then
                For value = 0 To grdConsumos.Rows.Count - 1
                    grdConsumos.Rows(value).Cells(" ").Value = 1
                Next
                chbSeleccionarTodo.Text = "Deseleccionar Todo"
                x = x + 1
            End If
            If chbSeleccionarTodo.Text = "Deseleccionar Todo" And x = 0 Then
                For value = 0 To grdConsumos.Rows.Count - 1
                    grdConsumos.Rows(value).Cells(" ").Value = 0
                Next
                chbSeleccionarTodo.Text = "Seleccionar Todo"
                x = x + 1
            End If

        Else
        End If
    End Sub

    Public Sub historial()
        Dim obj As New catalagosBU
        Dim tablaHistorial As DataTable
        tablaHistorial = obj.HistorialProductoEstilo(productoEstiloId)
        grdHistorial.DataSource = tablaHistorial
        disenioHistorial()
    End Sub

    Public Sub disenioHistorial()
        With grdHistorial.DisplayLayout.Bands(0)
            For value = 0 To grdHistorial.Rows.Count - 1
                If grdHistorial.Rows(value).Cells("Estatus de").Text = "D" Then
                    grdHistorial.Rows(value).Cells("Estatus de").Value = "DESARROLLO"
                End If
                If grdHistorial.Rows(value).Cells("Estatus de").Text = "AD" Then
                    grdHistorial.Rows(value).Cells("Estatus de").Value = "AUTORIZADO DESARROLLO"
                End If
                If grdHistorial.Rows(value).Cells("Estatus de").Text = "AP" Then
                    grdHistorial.Rows(value).Cells("Estatus de").Value = "AUTORIZADO PRODUCCIÓN"
                End If
                If grdHistorial.Rows(value).Cells("Estatus de").Text = "I" Then
                    grdHistorial.Rows(value).Cells("Estatus de").Value = "INACTIVO NAVE"
                End If
                If grdHistorial.Rows(value).Cells("Estatus de").Text = "DP" Then
                    grdHistorial.Rows(value).Cells("Estatus de").Value = "DESCONTINUADO"
                End If
                If grdHistorial.Rows(value).Cells("Estatus a").Text = "D" Then
                    grdHistorial.Rows(value).Cells("Estatus a").Value = "DESARROLLO"
                End If
                If grdHistorial.Rows(value).Cells("Estatus a").Text = "AD" Then
                    grdHistorial.Rows(value).Cells("Estatus a").Value = "AUTORIZADO DESARROLLO"
                End If
                If grdHistorial.Rows(value).Cells("Estatus a").Text = "AP" Then
                    grdHistorial.Rows(value).Cells("Estatus a").Value = "AUTORIZADO PRODUCCIÓN"
                End If
                If grdHistorial.Rows(value).Cells("Estatus a").Text = "I" Then
                    grdHistorial.Rows(value).Cells("Estatus a").Value = "INACTIVO NAVE"
                End If
                If grdHistorial.Rows(value).Cells("Estatus a").Text = "DP" Then
                    grdHistorial.Rows(value).Cells("Estatus a").Value = "DESCONTINUADO"
                End If
            Next

        End With
        grdHistorial.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdHistorial.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
    End Sub

    Private Sub chbSeleccionarTodo2_CheckedChanged(sender As Object, e As EventArgs) Handles chbSeleccionarTodo2.CheckedChanged

        'Fracciones

        If tbcImagenesConsumosFracciones.SelectedTab.Name = "Fracciones" Then
            Dim x = 0
            If chbSeleccionarTodo2.Text = "Seleccionar Todo" And x = 0 Then
                For value = 0 To grdFracciones.Rows.Count - 1
                    grdFracciones.Rows(value).Cells(" ").Value = 1
                Next
                chbSeleccionarTodo2.Text = "Deseleccionar Todo"
                x = x + 1
            End If
            If chbSeleccionarTodo2.Text = "Deseleccionar Todo" And x = 0 Then
                For value = 0 To grdFracciones.Rows.Count - 1
                    grdFracciones.Rows(value).Cells(" ").Value = 0
                Next
                chbSeleccionarTodo2.Text = "Seleccionar Todo"
                '        x = x + 1
            End If
        End If


       

    End Sub
End Class