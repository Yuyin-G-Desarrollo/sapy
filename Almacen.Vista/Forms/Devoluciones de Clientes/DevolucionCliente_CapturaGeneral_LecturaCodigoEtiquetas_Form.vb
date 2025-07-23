Imports System.Globalization
Imports System.Media
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinMaskedEdit

Public Class DevolucionCliente_CapturaGeneral_LecturaCodigoEtiquetas_Form

    ''' <summary>
    ''' Identificador del motivo de devolución
    ''' </summary>
    Public idMotivoDevolucion As Int16
    ''' <summary>
    ''' Variable que define el tipo de motivo de devolución 
    ''' 1 => Ventas
    ''' 2 => Almacén
    ''' </summary>
    Public tipoMotivo As Int16
    ''' <summary>
    ''' Variable para definir el grupo de etiquetas que se debe mostrar dependiendo el tipo de códigos del cliente
    ''' 1 => Información Última Salida de Inventario (Código Par Yuyin)
    ''' 2 => Información Código Cliente (Códigos Especiales)
    ''' 3 => Información Código AMECE (Códigos AMECE)
    ''' </summary>
    Public TipoEtiquetasGrpBox As Int16 = 0
    ''' <summary>
    ''' Variable que define el radioButton seleccionado de acuerdo con el tipo de código
    ''' 1 => Par yuyin
    ''' 2 => Cód Cliente
    ''' </summary>
    Public rdbSeleccionado As Int16
    ''' <summary>
    ''' Variable que define el tipo de Código seleccionado, dependiendo el RabioButton seleccionado
    ''' 1 => Par yuyin
    ''' 2 => Cód Cliente
    ''' </summary>
    Public tipoCodigo As Int16

    Public ambosTiposDeCodigos As Boolean

    Public objDevolucion As New Entidades.DevolucionCliente
    Public objPermisos As New Entidades.DevolucionCliente_PermisosPantallas
    Public radioParYuyin As Boolean = False
    Public porGuardar As Integer = 0

    ''' <summary>
    ''' Método que consulta los códigos de devolución registrados por el usuario
    ''' </summary>
    ''' <param name="TipoCodigo">Tipo de códigos para consultar: 'PAR YUYIN', 'ESPECIALES', 'AMECE'</param>
    Public Sub PoblarGrid(TipoCodigo As String)
        ' Se crea un objeto DataTable
        Dim dtCodigosRegistrados As New DataTable
        ' Se manda llamar el método de la capa de negocios para consultar los códigos
        dtCodigosRegistrados = (New Negocios.DevolucionClientesBU).ConsultaCodigos_Devolucion(CInt(lblFolioDev.Text.ToString), TipoCodigo)
        ' El resultado de la consulta se asigna al Grid de códigos correctos
        grdCodigosCorrectos.DataSource = dtCodigosRegistrados
        ' Con la siguiente instrucción se clona la estructura del DataTable (solo la estructura, NO LOS DATOS)
        grdCodigosErroneos.DataSource = dtCodigosRegistrados.Clone
    End Sub

    ''' <summary>
    ''' Configura la suma realizada sobre una columna
    ''' </summary>
    ''' <param name="grid">Grid sobre el que se realizará la operación</param>
    ''' <param name="columna">Nombre de la columna del Grid sobre la que se realizará la operación</param>
    ''' <param name="tipoSuma">Tipo de operación a realizar (Suma, promedio, conteo, etc)</param>
    Public Sub SumarColumnas(grid As UltraGrid, columna As String, tipoSuma As Int16)
        With grid.DisplayLayout.Bands(0)
            ' Validamos que la columna exista
            If .Columns.Exists(columna) Then
                ' Si en el Grid ya se configuró una suma, termina el método para no duplicar renglones
                If .Summaries.Exists(tipoSuma) = True Then Return
                ' Perimitimos operaciones sobre la columna
                .Columns(columna).AllowRowSummaries = AllowRowSummaries.True
                ' Se genera una nueva configuración para la operación
                Dim configuracionDeSuma As SummarySettings = .Summaries.Add(tipoSuma, grid.DisplayLayout.Bands(0).Columns(columna))
                ' Se define el formato con el que se mostrará el resultado de la operación
                configuracionDeSuma.DisplayFormat = "{0}"
                ' Se define la alineación del texto
                configuracionDeSuma.Appearance.TextHAlign = HAlign.Right
                ' Texto que aparecerá al final del Grid
                .SummaryFooterCaption = "Total:"
            End If
        End With
    End Sub

    Public Sub GenerarCombo_Grid()
        cmbProcede_UC.BindingContext = Me.BindingContext
        Dim tabla As New DataTable

        tabla.Columns.Add(New DataColumn("Valor", GetType(Int16)))
        tabla.Columns.Add(New DataColumn("Procede", GetType(String)))

        tabla.Rows.Add(1, "Procede")
        tabla.Rows.Add(0,"No Procede")

        cmbProcede_UC.DataSource = tabla
        cmbProcede_UC.ValueMember = "Valor"
        cmbProcede_UC.DisplayMember = "Procede"
        cmbProcede_UC.BorderStyle = UIElementBorderStyle.Solid
        cmbProcede_UC.DisplayLayout.Bands(0).Columns(0).Hidden = True
        cmbProcede_UC.DisplayLayout.BorderStyle = UIElementBorderStyle.Solid
        cmbProcede_UC.DropDownStyle = UltraComboStyle.DropDown
        cmbProcede_UC.DisplayLayout.Bands(0).ColHeadersVisible = False
    End Sub

    ''' <summary>
    ''' Método que define el formato que tendrá cada columna de acuerdo con el tipo de dato de la misma
    ''' </summary>
    ''' <param name="grid">Grid sobre el que se analizarán las columnas</param>
    Public Sub asignaFormato_Columna(ByVal grid As Infragistics.Win.UltraWinGrid.UltraGrid)
        ' Se recorre cada columna del Grid
        For Each col In grid.DisplayLayout.Bands(0).Columns
            ' Se valida si la columna es de tipo entero
            If col.DataType.Name.ToString.Equals("Int32") Or col.DataType.Name.ToString.Equals("Int16") Then
                col.Style = ColumnStyle.Integer
                col.CellAppearance.TextHAlign = HAlign.Right
            End If
            ' Se valida si la columna es de tipo Decimal
            If col.DataType.Name.ToString.Equals("Decimal") Then
                col.Style = ColumnStyle.DoublePositive
                col.CellAppearance.TextHAlign = HAlign.Right
            End If
            ' Se valida si la columna es de tipo String
            If col.DataType.Name.ToString.Equals("String") Then
                ' Si el encabezado de la columna es 'TELÉFONO'
                If col.Header.Caption.Equals("TELÉFONO") Then
                    ' Se genera una máscara de entrada
                    col.MaskInput = "+## (###) ###-####"
                    col.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeBoth
                    col.CellAppearance.TextHAlign = HAlign.Right
                    ' Si el encbezado de la columna es 'EXTENSIÓN'
                ElseIf col.Header.Caption.Equals("EXTENSIÓN") Then
                    ' Se genera una máscara de entrada
                    col.MaskInput = "ext: 9999"
                    col.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeBoth
                    col.CellAppearance.TextHAlign = HAlign.Right
                Else
                    col.CellAppearance.TextHAlign = HAlign.Left
                End If
            End If
        Next
    End Sub

    ''' <summary>
    ''' Método para diseñar al Grid
    ''' </summary>
    ''' <param name="grid">Grid sobre el que se aplicará el diseño</param>
    ''' <param name="numGrid">Tipo de Grid (Códigos correctos o erróneos)</param>
    Public Sub DiseñoGrid(grid As Infragistics.Win.UltraWinGrid.UltraGrid, numGrid As Int16)
        With grid.DisplayLayout
            ' Todas las columnas se ajustan a su contenido
            .PerformAutoResizeColumns(True, AutoResizeColumnWidthOptions.IncludeCells)
            ' Se intercalan colores entre una fila y otra
            .Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
            ' Se muestra el índice (número de renglón)
            .Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            ' Se define el ancho para la fila seleccionda
            .Override.RowSelectorWidth = 35
            ' Se define lo que se hará cuando se de clic sobre una celda
            .Override.CellClickAction = CellClickAction.CellSelect
            ' No se permite agregar nuevas filas
            .Override.AllowAddNew = AllowAddNew.No
            .Override.AllowUpdate = DefaultableBoolean.True
            ' Mostrar ambas barras de desplazamienro (horizontal, vertical)
            .Scrollbars = Scrollbars.Both
            ' No permite operaciones múltiples sobre las filas
            .Override.AllowMultiCellOperations = AllowMultiCellOperation.None
            ''.Override.SelectTypeRow = SelectType.Single
            ' Se define el número de líneas en las que se podrá mostrar el encabezado de la columna
            .Bands(0).ColHeaderLines = 1
            '------------------------------------------------------------------------------------------
            If rdbParYuyin.Checked = True Then
                OcultarColumna("CodigoID", grid)
                OcultarColumna("PCG", grid)
                If idMotivoDevolucion <> 372 Then
                    OcultarColumna("Defecto/Motivo", grid)
                    OcultarColumna("Clasificación", grid)
                    OcultarColumna("Procede", grid)
                End If
                OcultarColumna("IdMotivo", grid)
                OcultarColumna("PrecioLista", grid)
                OcultarColumna("PrecioDevolución", grid)
                'OcultarColumna("Lote", grid)
                OcultarColumna("AñoLote", grid)
                'OcultarColumna("PedidoSay", grid)
                OcultarColumna("PedidoSICY", grid)
                OcultarColumna("Partida", grid)
                OcultarColumna("OrdenCliente", grid)
                OcultarColumna("ClientePedido", grid)
                OcultarColumna("FSalida", grid)
                OcultarColumna("Status", grid)
                OcultarColumna("Activo", grid)
                OcultarColumna("LoteCompleto", grid)
                OcultarColumna("ProductoEstiloId", grid)
                OcultarColumna("ParEncontrado", grid)
                OcultarColumna("ParCorrecto", grid)
                OcultarColumna("IdClienteSayPar", grid)
                OcultarColumna("ListaPrecio", grid)
                OcultarColumna("PorGuardar", grid)

                .Bands(0).Columns("PCG").Width = 35
                .Bands(0).Columns("PCG").CellAppearance.TextHAlign = HAlign.Center

                '.Bands(0).Columns("DCG").Width = 35
                '.Bands(0).Columns("DCG").CellAppearance.TextHAlign = HAlign.Center

                ' Ciclo para dar formato a cada una de las filas en base a ciertos criterios
                For Each fila As UltraGridRow In grid.Rows
                    ' Si la columna 'PCG' existe y su contenido es 'SI' se define el fondo verde
                    ' Si la columna 'PCG' existe y su contenido es 'NO' se define el fondo en una escala de Rojo
                    If fila.Cells("PCG").Value = "SI" Then
                        fila.Cells("PCG").Appearance.BackColor = Color.Green
                    ElseIf fila.Cells("PCG").Value = "NO" Then
                        fila.Cells("PCG").Appearance.BackColor = Color.Tomato
                    End If

                    ' Si la columna 'DCG' existe y su contenido es 'SI' se define el fondo verde
                    ' Si la columna 'DCG' existe y su contenido es 'NO' se define el fondo en una escala de Rojo
                    'If fila.Cells("DCG").Value = "SI" Then
                    '    fila.Cells("DCG").Appearance.BackColor = Color.Green
                    'ElseIf fila.Cells("DCG").Value = "NO" Then
                    '    fila.Cells("DCG").Appearance.BackColor = Color.Tomato
                    'End If

                    ' Si la columna 'Activo' existe y su contenido es 'NO' o 'FALSE' se cambia el color de fuente de toda la fila a rojo
                    If .Bands(0).Columns.Exists("Activo") Then
                        If fila.Cells("Activo").Value = False And fila.Cells("Error").Value <> "CÓDIGO NO EXISTE" Then
                            fila.Appearance.ForeColor = Color.Red
                        End If
                    End If

                    ' Si el contenido de la columna 'Defecto/Motivo' es diferente al de la etiqueta 'lblMotivo' (la cual contiene el motivo de devolución definido durante la captura general)
                    ' se cambia el color de la letra indicando que esos campos han sido editados
                    If .Bands(0).Columns.Exists("Defecto/Motivo") Then
                        If fila.Cells("Defecto/Motivo").Value.ToString <> lblMotivo.Text Then
                            fila.Cells("Defecto/Motivo").Appearance.ForeColor = Color.Purple
                        End If
                    End If
                Next
            Else
                If lblTipoCodigos.Text = "ESPECIALES" Then
                    OcultarColumna("CodigoID", grid)
                    If idMotivoDevolucion <> 372 Then
                        OcultarColumna("Defecto/Motivo", grid)
                    End If
                    OcultarColumna("IdMotivo", grid)
                    OcultarColumna("PrecioLista", grid)
                    OcultarColumna("PrecioDevolución", grid)
                    OcultarColumna("EstiloCte", grid)
                    OcultarColumna("MarcaCte", grid)
                    OcultarColumna("ColeccionCte", grid)
                    OcultarColumna("FamiliaCte", grid)
                    OcultarColumna("LineaCte", grid)
                    OcultarColumna("MaterialCte", grid)
                    OcultarColumna("ColorCte", grid)
                    OcultarColumna("DescripciónCte", grid)
                    OcultarColumna("ListaCliente", grid)
                    OcultarColumna("Activo", grid)
                    OcultarColumna("ProductoEstiloID", grid)
                    OcultarColumna("Status", grid)
                    'OcultarColumna("Error", grid)
                    OcultarColumna("PorGuardar", grid)
                ElseIf lblTipoCodigos.Text = "AMECE" Then
                    OcultarColumna("CodigoID", grid)
                    If idMotivoDevolucion <> 372 Then
                        OcultarColumna("Defecto/Motivo", grid)
                        OcultarColumna("Procede", grid)
                    End If
                    OcultarColumna("IdMotivo", grid)
                    OcultarColumna("PrecioLista", grid)
                    OcultarColumna("PrecioDevolución", grid)
                    OcultarColumna("ListaCliente", grid)
                    OcultarColumna("Activo", grid)
                    OcultarColumna("ProductoEstiloID", grid)
                    OcultarColumna("Status", grid)
                    'OcultarColumna("Error", grid)
                    OcultarColumna("PorGuardar", grid)
                End If

                For Each fila As UltraGridRow In grid.Rows
                    ' Si la columna 'Activo' existe y su contenido es 'NO' o 'FALSE' se cambia el color de fuente de toda la fila a rojo
                    If .Bands(0).Columns.Exists("Activo") Then
                        If fila.Cells("Activo").Value = False And fila.Cells("Error").Value <> "CÓDIGO NO EXISTE" Then
                            fila.Appearance.ForeColor = Color.Red
                        End If
                    End If

                    ' Si el contenido de la columna 'Defecto/Motivo' es diferente al de la etiqueta 'lblMotivo' (la cual contiene el motivo de devolución definido durante la captura general)
                    ' se cambia el color de la letra indicando que esos campos han sido editados
                    If .Bands(0).Columns.Exists("Defecto/Motivo") Then
                        If fila.Cells("Defecto/Motivo").Value.ToString <> lblMotivo.Text Then
                            fila.Cells("Defecto/Motivo").Appearance.ForeColor = Color.Purple
                        End If
                    End If
                Next
            End If

            If pnlBtnIniciar.Visible = True Then
                ' Si la columna 'Defecto/Motivo' existe la habilita para que se pueda editar
                If .Bands(0).Columns.Exists("Defecto/Motivo") Then
                    .Bands(0).Columns("Defecto/Motivo").CellActivation = Activation.AllowEdit
                End If

                If .Bands(0).Columns.Exists("Procede") Then
                    .Bands(0).Columns("Procede").CellActivation = Activation.AllowEdit
                End If

                If .Bands(0).Columns.Exists("Lote") Then
                    .Bands(0).Columns("Lote").CellActivation = Activation.AllowEdit
                End If

                If .Bands(0).Columns.Exists("Clasificación") Then
                    .Bands(0).Columns("Clasificación").CellActivation = Activation.AllowEdit
                End If

                ' Si la columna 'PrecioDevolución' existe se genera una máscara para poder editar en base a lo definido
                If .Bands(0).Columns.Exists("PrecioDevolución") Then
                    .Bands(0).Columns("PrecioDevolución").MaskInput = "nnnn.nn"
                End If
            Else
                ' Si la columna 'Defecto/Motivo' existe la habilita para que se pueda editar
                If .Bands(0).Columns.Exists("Defecto/Motivo") Then
                    .Bands(0).Columns("Defecto/Motivo").CellActivation = Activation.NoEdit
                End If

                If .Bands(0).Columns.Exists("Procede") Then
                    .Bands(0).Columns("Procede").CellActivation = Activation.NoEdit
                End If

                If .Bands(0).Columns.Exists("Lote") Then
                    .Bands(0).Columns("Lote").CellActivation = Activation.NoEdit
                End If

                If .Bands(0).Columns.Exists("Clasificación") Then
                    .Bands(0).Columns("Clasificación").CellActivation = Activation.NoEdit
                End If
            End If

            ' Si el grid contiene una columna de selección (checkbox) se define un tamaño fijo
            If .Bands(0).Columns.Exists(" ") Then
                .Bands(0).Columns(" ").Width = 30
            End If

            ' Si el Grid es de códigos erróneos o el número de columnas es menor que 15 se autoajustan para llenar el Grid y no mostrar espacios vacíos
            If numGrid = 2 Or grid.Rows.Count < 15 Then
                .Bands(0).Columns(0).Width = 30
                If (TipoEtiquetasGrpBox = 2 Or TipoEtiquetasGrpBox = 3) And grid.Rows.Count = 0 Then
                    .AutoFitStyle = AutoFitStyle.ResizeAllColumns
                Else
                    .AutoFitStyle = AutoFitStyle.None
                End If
            End If

            If grid.Rows.Count <= 0 Then
                .AutoFitStyle = AutoFitStyle.ResizeAllColumns
            Else
                .AutoFitStyle = AutoFitStyle.ExtendLastColumn
            End If

            ' Se habilitan los filtros
            .Override.AllowRowFiltering = DefaultableBoolean.True
            .Override.FilterUIType = FilterUIType.FilterRow
        End With

    End Sub

    ''' <summary>
    ''' Método para consultar los Motivos de devolución alojados en base de datos y desplegarlos en un combo
    ''' </summary>
    Public Sub LlenarComboMotivos()
        ' Objeto para interactuar con la capa de negocios
        Dim objNegocio As New Negocios.DevolucionClientesBU
        ' Objeto para alojar el resultado devuelto por la consulta
        Dim lista As New DataTable
        ' Si el motivo de devolución es de ventas
        If tipoMotivo = 1 Then
            ' Se ejecuta el método de contulta indicando que el parámetro de búsqueda será para motivo ventas
            lista = objNegocio.ListadoMotivos("DEVOLUCION_CLIENTE_MOTIVO_VENTAS")
            ' Se cambia el texto de la etiqueta
            lblTipoMotivo.Text = "Motivo Vtas:"
            ' Se define una nueva ubicación de la etiqueta
            'lblTipoMotivo.Location = New Point(692, 7)
            ' Si el motivo de devolución es de almacén
        ElseIf tipoMotivo = 2 Then
            ' Se ejecuta el método de contulta indicando que el parámetro de búsqueda será para motivo Almacén
            lista = objNegocio.ListadoMotivos("DEVOLUCION_CLIENTE_MOTIVO_INICIAL")
            lblTipoMotivo.Text = "Motivo Almacén:"
            ' Se define una nueva ubicación de la etiqueta
            'lblMotivo.Location = New Point(463, 18)
        End If

        ' Si la consulta regresa uno o más resultados
        If lista.Rows.Count > 0 Then
            ' Se agrega una fila vacía
            Dim newRow As DataRow = lista.NewRow
            lista.Rows.InsertAt(newRow, 0)
            ' El resultado de la consulta se define como fuente de datos del combo
            cmbMotivoDevolucion.DataSource = lista
            ' Se define el nombre de la columna utilizada para las etiquetas del combo
            cmbMotivoDevolucion.DisplayMember = "Motivo"
            ' Se define el nombre de la columna utilizada para los valores del combo
            cmbMotivoDevolucion.ValueMember = "esta_estatusid"
            ' Se selecciona por Default el motivo inicial proveniente de la captura general
            cmbMotivoDevolucion.SelectedValue = idMotivoDevolucion
        End If
    End Sub

    Public Sub MostrarColumna(columna As String, grid As UltraGrid)
        If grid.DisplayLayout.Bands(0).Columns.Exists(columna) Then
            grid.DisplayLayout.Bands(0).Columns(columna).Hidden = False
        End If
    End Sub

    Public Sub OcultarColumna(columna As String, grid As UltraGrid)
        If grid.DisplayLayout.Bands(0).Columns.Exists(columna) Then
            grid.DisplayLayout.Bands(0).Columns(columna).Hidden = True
        End If
    End Sub

    ''' <summary>
    ''' Método para mostrar/ocultar páneles de acuerdo con el tipo de código seleccionado para ese cliente
    ''' </summary>
    ''' <param name="codigos">Tipo de códigos de cliente (PAR YUYIN, ESPECIALES, AMECE)</param>
    Public Sub VisibilidadPaneles(codigos As String)
        ' Si los códigos son de tipo PAR YUYIN
        If codigos = "PAR YUYIN" Then
            ' Se desmarca el RabioButton de los códigos especiales
            rdbCodigoCliente.Checked = False
            ' Se marca el RabioButton de los códigos de Par Yuyin
            rdbParYuyin.Checked = True
            radioParYuyin = True
            ' Se muestra el GroupBox con las etiquetas para códigos de Par Yuyin
            grpbInformacionUltimaSalidaInv.Visible = True
            ' Se ocultan los GroupBox con las etiquetas de códigos de Cliente
            grpbCodigoAMECE.Visible = False
            grpbCodigosEpeciales.Visible = False
            ' Se configura el tipo de etiquetas como 1 (esta variable es usada para validar otros procesos)
            TipoEtiquetasGrpBox = 1
            ' Se configura el RadioButton seleccionado como 1 (esta variable es usada para validar otros procesos)
            rdbSeleccionado = 1
        ElseIf codigos = "ESPECIALES" Then
            ' Se desmarca el RabioButton de los códigos de pay Yuyin
            rdbParYuyin.Checked = False
            ' Se marca el RabioButton de los códigos de cliente
            rdbCodigoCliente.Checked = True
            ' Se muestra el GroupBox con las etiquetas para códigos Especiales
            grpbCodigosEpeciales.Visible = True
            ' Se ocultan los GroupBox con las etiquetas de códigos de Par Yuyin y AMECE
            grpbCodigoAMECE.Visible = False
            grpbInformacionUltimaSalidaInv.Visible = False
            ' Se configura el tipo de etiquetas como 2 (esta variable es usada para validar otros procesos)
            TipoEtiquetasGrpBox = 2
            ' Se configura el RadioButton seleccionado como 2 (esta variable es usada para validar otros procesos). Esto indica que el radio buton seleccionado actualmente es de códigos especiales
            rdbSeleccionado = 2
        ElseIf codigos = "AMECE" Then
            ' Se desmarca el RabioButton de los códigos de pay Yuyin
            rdbParYuyin.Checked = False
            ' Se marca el RabioButton de los códigos de cliente
            rdbCodigoCliente.Checked = True
            ' Se muestra el GroupBox con las etiquetas para códigos AMECE
            grpbCodigoAMECE.Visible = True
            ' Se ocultan los GroupBox con las etiquetas de códigos de Par Yuyin y Especiales
            grpbInformacionUltimaSalidaInv.Visible = False
            grpbCodigosEpeciales.Visible = False
            ' Se configura el tipo de etiquetas como 3 (esta variable es usada para validar otros procesos)
            TipoEtiquetasGrpBox = 3
            ' Se configura el RadioButton seleccionado como 2 (esta variable es usada para validar otros procesos). Esto indica que el radio buton seleccionado actualmente es de códigos especiales
            rdbSeleccionado = 2
        End If
    End Sub

    ''' <summary>
    ''' Método para obtener el tipo de códigos que tiene el cliente (PAR YUYIN, ESPECIALES, AMECE). Este método se ejecuta durante la carga del Formulario
    ''' </summary>
    Public Sub TipoCodigos()
        ' Objeto para interactuar con la capa de negocios
        Dim objBU As New Negocios.DevolucionClientesBU
        ' Objeto para almacenar el resultado obtenedio de la consulta
        Dim listaTipoCodigos As New DataTable
        ' Se ejecuta el método para la consulta
        listaTipoCodigos = objBU.ListaTipoCodigos(objDevolucion.Clienteid)
        ' Se recorre cada una de las filas del DataTable resultante
        For Each row As DataRow In listaTipoCodigos.Rows
            ' Se asigna el texto proveniente de la consulta
            lblTipoCodigos.Text = row("Codigos").ToString
            ' Se ocultan y muestran los páneles correspondientes a acuerdo con el tipo de códigos
            VisibilidadPaneles(row("Codigos").ToString)
            ' Se asigna el texto de incremento por par a la columna
            lblIncrementoXPar.Text = row("IncrementoPorPar").ToString
            ' Se asigna el texto 
            lblEtiquetas.Text = row("Etiqueta").ToString

            Dim tipoEtiqueta As New List(Of String)
            Dim codCliente As Boolean = False
            Dim parYuyin As Boolean = False

            tipoEtiqueta = row("Etiqueta").ToString.Split(",").ToList
            For Each elemento In tipoEtiqueta
                If elemento.Trim.Contains("ESPECIAL") Then
                    codCliente = True
                ElseIf elemento.Trim.Contains("YUYIN") Then
                    parYuyin = True
                End If
            Next

            If codCliente = True And parYuyin = True Then
                ambosTiposDeCodigos = True
                rdbCodigoCliente.Enabled = True
                VisibilidadPaneles("PAR YUYIN")
            ElseIf codCliente = True Then
                ambosTiposDeCodigos = False
                rdbCodigoCliente.Enabled = True
                rdbParYuyin.Enabled = False
                VisibilidadPaneles(lblTipoCodigos.Text)
            ElseIf parYuyin = True Then
                ambosTiposDeCodigos = False
                rdbCodigoCliente.Enabled = False
                rdbParYuyin.Enabled = True
                VisibilidadPaneles("PAR YUYIN")
            End If

            If row("Etiqueta").ToString = "PAR (YUYIN)" Then
                ambosTiposDeCodigos = False
                rdbCodigoCliente.Enabled = False
            Else
                ambosTiposDeCodigos = True
                rdbCodigoCliente.Enabled = True
            End If

            If row("Codigos").ToString = "PAR YUYIN" Then
                tipoCodigo = 1
                ambosTiposDeCodigos = False
                rdbCodigoCliente.Enabled = False
            Else
                tipoCodigo = 2
            End If
        Next
    End Sub

    Public Function EliminarCodigosSeleccionados(grid As UltraGrid)
        Dim codigosSeleccionados As String = ""
        If grid.Rows.Count = 0 Then
            Dim ventanaAlerta As New Tools.AdvertenciaForm
            ventanaAlerta.mensaje = "Aún no se ha ingresado ningun código"
            ventanaAlerta.ShowDialog()
        Else
            Dim validar = False

            Dim ventanaConfirmacion As New Tools.ConfirmarForm
            ventanaConfirmacion.mensaje = "Los códigos seleccionados se eliminarán " + vbCrLf + "¿Desea continuar?"
            ventanaConfirmacion.ShowDialog()
            If ventanaConfirmacion.DialogResult = Windows.Forms.DialogResult.OK Then
                For index = grid.Rows.Count - 1 To 0 Step -1
                    If grid.Rows(index).Cells(" ").Value = True Then
                        If codigosSeleccionados.Length > 0 Then
                            codigosSeleccionados += ","
                        End If
                        If grid.DisplayLayout.Bands(0).Columns.Exists("CodigoID") And grid.DisplayLayout.Bands(0).Columns.Exists("PorGuardar") Then
                            If grid.Rows(index).Cells("PorGuardar").Value.ToString = "NO" Then
                                codigosSeleccionados += grid.Rows(index).Cells("CodigoID").Value.ToString
                            End If
                        End If
                        grid.Rows(index).Delete(False)
                        validar = True
                    End If

                Next
                If validar = False Then
                    Dim ventanaAdvertencia As New Tools.AdvertenciaForm
                    ventanaAdvertencia.mensaje = "No se ha seleccionado ningún código"
                    ventanaAdvertencia.ShowDialog()
                End If
                'grdCodigosCorrectos.DataSource = InicializarGrid(1)
                'LimpiarTodasLasEtiquetasGrpb()
            End If
        End If
        lblNumFiltrados.Text = "0"

        txtEtiquetaPar.Select()

        Return codigosSeleccionados
    End Function

    Public Sub AgregarFilaGrid(grid As UltraGrid, datos As DataTable, tipoGrid As Int16)
        Dim columnas As Int16 = 0
        Dim indexEncabezados As Int16 = 1
        Dim indexColumna As Int16 = 0
        Dim posicionMotivo As Int16 = 0
        'Dim posicionPrecioListaDev As Int16 = 0

        If tipoGrid = 1 Or tipoGrid = 2 Or tipoGrid = 3 Then
            posicionMotivo = 5
            'posicionPrecioListaDev = 6
        ElseIf (tipoGrid = 4 Or tipoGrid = 6) And grid.Name <> "grdCodigosErroneos" Then
            posicionMotivo = 3
            'posicionPrecioListaDev = 4
        ElseIf (tipoGrid = 4 Or tipoGrid = 6) And grid.Name = "grdCodigosErroneos" Then
            posicionMotivo = 2
            'posicionPrecioListaDev = 3
        ElseIf tipoGrid = 5 Then
            posicionMotivo = 4
            'posicionPrecioListaDev = 5
        End If

        columnas = datos.Columns.Count + 3

        Dim tablaContendio As DataTable = grid.DataSource

        For Each row As DataRow In datos.Rows
            Dim fila As DataRow = tablaContendio.NewRow
            For Each columna As DataColumn In datos.Columns
                If columna.Caption = "IdMotivo" Then
                    fila(columna.Caption) = IIf(objDevolucion.Motivoventas_statusid <> 0, objDevolucion.Motivoventas_statusid, objDevolucion.Motivoinicialalmacen_statusid)
                ElseIf columna.Caption = "Defecto/Motivo" Then
                    fila(columna.Caption) = lblMotivo.Text
                Else
                    fila(columna.Caption) = row(columna.Caption)
                End If
            Next

            tablaContendio.Rows.Add(fila)
        Next
        grid.DataSource = Nothing
        grid.DataSource = tablaContendio
    End Sub

    Public Function GenerarFiltros(grid As UltraGrid,
                              index As Int16,
                              numConsulta As Int16)
        Dim filtro As String = ""
        If grid IsNot Nothing And grid.Rows.Count > 0 Then
            For Each elemento As UltraGridRow In grid.Rows
                filtro += elemento.Cells(index).Value.ToString + ","
            Next
            filtro = filtro.Substring(0, filtro.Length - 1)
        End If
        Return filtro
    End Function

    Public Sub Permisos()
        pnlBtnIniciar.Visible = objPermisos.BtnIniciar
        pnlBtnDetener.Visible = objPermisos.BtnIniciar
        pnlBtnEliminarCorrectos.Visible = objPermisos.BtnEliminarCorrectos
        pnlBtnEliminarErroneos.Visible = objPermisos.BtnEliminarErroneos
        btnAceptar.Enabled = objPermisos.BtnGuardar_codigos

        lblEtiquetaMonto.Visible = objPermisos.VerMontos
        lblMonto.Visible = objPermisos.VerMontos
    End Sub

    Public Sub LimpiarEtiquetasInfoPar()
        lblEstatusPar.Text = "-"
        lblArticulo.Text = "-"
        lblTalla.Text = "-"
        lblLote.Text = "-"
        lblcodigoRepetido.Text = "-"
    End Sub

    Public Sub LimpiarEtiquetasGrpbInfoUltimaSalidaInv()
        lblCodPar.Text = "-"
        lblPedidoSay.Text = "-"
        lblPedidoSICY.Text = "-"
        lblIDoctoSAY.Text = "-"
        lblFechaDocumento.Text = "-"
        lblPrecioDocumento.Text = "-"
        lblPedidoSICY.Text = "-"
        lblRemision.Text = "-"
        lblPartida.Text = "-"
        lblAnio.Text = "-"
        lblOrdenCliente.Text = "-"
        lblFactura.Text = "-"
        lblSalidaAlmacen.Text = "-"
        Label11.Text = "-"
        lblClientePedido.Text = "-"
        lblStDocumento.Text = "-"
        pnlPCG.BackColor = Color.Transparent
        pnlIDDocto.BackColor = Color.Transparent
    End Sub

    Public Sub LimpiarEtiquetasGrpbInfoCodCliente()
        lblCodigoCliente.Text = "-"
        lblMarca.Text = "-"
        lblFamilia.Text = "-"
        lblMaterial.Text = "-"
        lblDescripcion.Text = "-"
        lblCodigoRapido.Text = "-"
        lblColeccion.Text = "-"
        lblLinea.Text = "-"
        lblColor.Text = "-"
        lblEstilo.Text = "-"
        lblTallaGrpbICC.Text = "-"
        lblListaPrecioGrpbICC.Text = "-"
        lblListaPrecioGrpbICC.Text = "-"
        lblPrecioGrpbICC.Text = "-"
    End Sub

    Public Sub LimpiarEtiquetasGrpbCodAmece()
        lblCodigoAMECE.Text = "-"
        lblPrecioGrpbAmece.Text = "-"
        lblListaPrecioGrpbAmece.Text = "-"
    End Sub

    Public Sub LimpiarTodasLasEtiquetasGrpb()
        LimpiarEtiquetasInfoPar()
        LimpiarEtiquetasGrpbInfoUltimaSalidaInv()
        LimpiarEtiquetasGrpbInfoCodCliente()
        LimpiarEtiquetasGrpbCodAmece()
    End Sub

    Public Sub LLenarEtiquetaEstatus(estatus As String)
        lblEstatusPar.Text = estatus

        If estatus = "SALIDA VENTAS" Or estatus = "CORRECTO" Then
            lblEstatusPar.ForeColor = Color.Green
        ElseIf estatus = "SALIDA DESTRUCTIVA" Then
            lblEstatusPar.ForeColor = Color.Orange
        ElseIf estatus = "INVENTARIO" Or estatus = "EN PRODUCCIÓN" Then
            lblEstatusPar.ForeColor = Color.Red
        ElseIf estatus = "CÓDIGO NO EXISTE" Then ' ==> CÓDIGO NO EXISTE
            If TipoEtiquetasGrpBox = 1 Then
                lblEstatusPar.ForeColor = Color.Purple
            Else
                lblEstatusPar.ForeColor = Color.Red
            End If
        End If
    End Sub

    Public Function ValidarCodigoRepetido(grid As UltraGrid, index As Int16, codigo As String, ByVal codigoCliente As Boolean) As Boolean
        If codigoCliente <> True Then
            For Each row As UltraGridRow In grid.Rows
                If grid.Name = "grdCodigosCorrectos" Then
                    Dim partesCodigos As String = codigo.Split("-").ToList.Last
                    If row.Cells(index).Value.ToString = codigo Or row.Cells(index).Value.ToString = partesCodigos Then
                        ReproducirSonidoError()
                        Return True
                    End If
                Else
                    If row.Cells(index).Value.ToString = codigo Then
                        ReproducirSonidoError()
                        Return True
                    End If
                End If

            Next
            Return False
        End If
        Return False
    End Function

    Public Sub seleccionarFila(grid As Infragistics.Win.UltraWinGrid.UltraGrid,
                               etiqueta As Label,
                               boton As Button)
        If Not grid.ActiveRow.IsDataRow Then Return
        If IsNothing(grid.ActiveRow) Then Return
        If grid.ActiveRow.Cells(" ").Value Then
            grid.ActiveRow.Cells(" ").Value = False
        Else
            grid.ActiveRow.Cells(" ").Value = True
        End If

        Dim marcados As Integer
        For Each row As UltraGridRow In grid.Rows
            If CBool(row.Cells(" ").Value) Then
                marcados += 1
            End If
        Next
        etiqueta.Text = marcados.ToString("N0", CultureInfo.InvariantCulture)
        If marcados > 0 Then
            boton.Enabled = True
        Else
            boton.Enabled = False
        End If
    End Sub

    Public Function SumarColumna(grid As UltraGrid, columna As String)
        Dim suma As Double = 0
        If grid.DisplayLayout.Bands(0).Columns.Exists(columna) Then
            Dim valor As Double
            For Each row As UltraGridRow In grid.Rows
                Try
                    valor = CDbl(row.Cells(columna).Value)
                Catch ex As Exception
                    valor = 0
                End Try
                suma += valor
            Next
        End If
        Return suma
    End Function

    Public Sub ReproducirSonidoError()
        Dim player As New SoundPlayer(My.Resources.beep_04)
        player.Play()
    End Sub

    Public Sub ReproducirSonidoCorrecto()
        Dim player As New SoundPlayer(My.Resources.OK)
        player.Play()
    End Sub

    Public Sub ActualizarCantidades()
        Dim dtCantidades As New DataTable
        dtCantidades = (New Negocios.DevolucionClientesBU).ConsultaMonto_Cantidad(objDevolucion.Devolucionclienteid)
        ' Se hace la conversión 'CDbl' para dar formato y separación de miles
        lblMonto.Text = CDbl(dtCantidades.Rows(0).Item(1)).ToString("N2")
    End Sub

    Public Sub ConsultarEtiqueta()
        Dim objBU As New Negocios.DevolucionClientesBU
        Dim infoPar As New DataTable
        Dim etiquetaPar As String
        Dim estatusPar As String = ""

        etiquetaPar = txtEtiquetaPar.Text.Trim.Replace("'", "-")
        etiquetaPar = etiquetaPar.Replace("PC", "Y-000-")

        If etiquetaPar.Length = 0 Then
            txtEtiquetaPar.Select()
            Return
        End If

        Try
            If rdbCodigoCliente.Checked = True Then
                VisibilidadPaneles(lblTipoCodigos.Text)

                If TipoEtiquetasGrpBox = 2 Or TipoEtiquetasGrpBox = 3 Then
                    If ValidarCodigoRepetido(grdCodigosCorrectos, 2, etiquetaPar, True) = True Then
                        LimpiarEtiquetasInfoPar()
                        LimpiarEtiquetasGrpbInfoUltimaSalidaInv()
                        lblcodigoRepetido.Text = "CÓDIGO REPETIDO"
                        lblCodigoCliente.Text = txtEtiquetaPar.Text
                        lblCodigoAMECE.Text = txtEtiquetaPar.Text
                        txtEtiquetaPar.Text = ""
                        txtEtiquetaPar.Select()
                        Return
                    End If
                End If

                If TipoEtiquetasGrpBox = 2 Then

                    Dim etiquetaParv2 As String

                    If objDevolucion.Clienteid = 816 Then
                        Dim codigo = objBU.VerificarCodigoCliente_Andrea(objDevolucion.Clienteid, etiquetaPar)
                        etiquetaParv2 = codigo.Rows(0).Item("CodigoCliente")
                    Else
                        etiquetaParv2 = etiquetaPar
                    End If

                    infoPar = objBU.ConsultarEtiquetaCodEspeciales(etiquetaParv2, "ESPECIALES", objDevolucion.Clienteid, CDbl(lblIncrementoXPar.Text.ToString))

                    For Each fila As DataRow In infoPar.Rows
                        If fila("Status") = "CORRECTO" Or fila("Status") <> "CÓDIGO NO EXISTE" Then
                            lblArticulo.Text = fila("Artículo").ToString
                            lblTalla.Text = fila("Talla").ToString
                            lblCodigoCliente.Text = fila("CodCliente").ToString
                            lblMarca.Text = fila("MarcaCte").ToString
                            lblFamilia.Text = fila("FamiliaCte").ToString
                            lblMaterial.Text = fila("LineaCte").ToString
                            lblDescripcion.Text = fila("DescripciónCte").ToString
                            lblCodigoRapido.Text = fila("CodRápido").ToString
                            lblColeccion.Text = fila("ColeccionCte").ToString
                            lblLinea.Text = fila("LineaCte").ToString
                            lblColor.Text = fila("ColorCte").ToString
                            lblEstilo.Text = fila("EstiloCte").ToString
                            lblTallaGrpbICC.Text = fila("Talla").ToString
                            lblPrecioGrpbICC.Text = fila("PrecioLista").ToString
                            lblListaPrecioGrpbICC.Text = fila("ListaCliente").ToString
                            AgregarFilaGrid(grdCodigosCorrectos, infoPar, 3)
                            ReproducirSonidoCorrecto()
                        Else
                            'AgregarFilaCodErroneo(grdCodigosErroneos, infoPar)
                            AgregarFilaGrid(grdCodigosErroneos, infoPar, 4)
                            ReproducirSonidoError()
                            LimpiarEtiquetasInfoPar()
                            LimpiarEtiquetasGrpbInfoCodCliente()
                            lblCodigoCliente.Text = fila("CodCliente").ToString
                        End If
                        txtEtiquetaPar.Text = ""
                    Next
                ElseIf TipoEtiquetasGrpBox = 3 Then
                    infoPar = objBU.ConsultarEtiquetaCodEspeciales(etiquetaPar, "AMECE", objDevolucion.Clienteid, CDbl(lblIncrementoXPar.Text))
                    For Each fila As DataRow In infoPar.Rows
                        estatusPar = fila("Status")
                        If fila("Status") = "CORRECTO" Then
                            lblArticulo.Text = fila("Artículo").ToString
                            lblTalla.Text = fila("Talla").ToString
                            lblCodigoAMECE.Text = fila("CodAMECE").ToString
                            lblPrecioGrpbAmece.Text = fila("PrecioLista").ToString
                            lblListaPrecioGrpbAmece.Text = fila("ListaCliente").ToString
                            AgregarFilaGrid(grdCodigosCorrectos, infoPar, 5)
                            ReproducirSonidoCorrecto()
                        Else
                            '                        AgregarFilaCodErroneo(grdCodigosErroneos, infoPar)
                            AgregarFilaGrid(grdCodigosErroneos, infoPar, 6)
                            ReproducirSonidoError()
                            LimpiarEtiquetasInfoPar()
                            LimpiarEtiquetasGrpbCodAmece()
                            lblCodigoAMECE.Text = fila("CodAMECE").ToString
                        End If
                        txtEtiquetaPar.Text = ""
                    Next
                End If
            ElseIf rdbParYuyin.Checked = True Then
                Dim documento As Boolean = False
                VisibilidadPaneles("PAR YUYIN")

                If ValidarCodigoRepetido(grdCodigosCorrectos, 3, etiquetaPar, False) = True Or ValidarCodigoRepetido(grdCodigosErroneos, 3, etiquetaPar, False) = True Then
                    LimpiarEtiquetasInfoPar()
                    LimpiarEtiquetasGrpbInfoUltimaSalidaInv()
                    lblcodigoRepetido.Text = "CÓDIGO REPETIDO"
                    lblCodPar.Text = txtEtiquetaPar.Text
                    txtEtiquetaPar.Text = ""
                    txtEtiquetaPar.Select()
                    Return
                End If

                'infoPar = objBU.ConsultaEtiquetasParYuyin(etiquetaPar, objDevolucion.Clienteid, GenerarFiltros(grdListaPedidos, 1, 1))
                infoPar = objBU.ConsultaEtiquetasParYuyin(etiquetaPar, objDevolucion.Clienteid, objDevolucion.PedidosSAY.ToString)

                'Dim infoDocumentos As New DataTable
                For Each fila As DataRow In infoPar.Rows
                    estatusPar = fila("Status")

                    If fila("Status") = "CÓDIGO NO EXISTE" Then
                        LimpiarEtiquetasInfoPar()
                        LimpiarEtiquetasGrpbInfoUltimaSalidaInv()
                        AgregarFilaGrid(grdCodigosErroneos, infoPar, 2)
                        ReproducirSonidoError()
                        lblCodPar.Text = etiquetaPar
                    Else
                        lblArticulo.Text = fila("Artículo").ToString
                        lblTalla.Text = fila("Talla").ToString
                        lblLote.Text = fila("LoteCompleto").ToString
                        lblCodPar.Text = fila("CódigoPar")
                        lblPedidoSay.Text = fila("PedidoSay").ToString
                        lblPedidoSICY.Text = fila("PedidoSICY")
                        lblPartida.Text = fila("Partida")
                        lblAnio.Text = fila("AñoLote")
                        lblClientePedido.Text = fila("ClientePedido")
                        Label11.Text = fila("ClientePedido")
                        lblOrdenCliente.Text = fila("OrdenCliente")
                        lblSalidaAlmacen.Text = fila("FSalida").ToString
                        If fila("PCG") = "SI" Then
                            pnlPCG.BackColor = Color.Green
                        Else
                            pnlPCG.BackColor = Color.Tomato
                        End If

                        If fila("Status") <> "CÓDIGO NO EXISTE" Then
                            If fila("Error").ToString.Contains("CODIGO EN FOLIO DEV:") Then
                                AgregarFilaGrid(grdCodigosErroneos, infoPar, 2)
                                ReproducirSonidoError()
                                'ElseIf documento = True Then
                                '    AgregarFilaGrid(grdCodigosCorrectos, CombinarFilas(infoPar, infoDocumentos), 1)
                            Else
                                AgregarFilaGrid(grdCodigosCorrectos, infoPar, 1)
                                ReproducirSonidoCorrecto()
                            End If
                        Else
                            AgregarFilaGrid(grdCodigosErroneos, infoPar, 2)
                            ReproducirSonidoError()
                        End If
                    End If
                Next
            End If
            LLenarEtiquetaEstatus(estatusPar)
            txtEtiquetaPar.Text = ""
            lblcodigoRepetido.Text = "-"
            txtEtiquetaPar.Select()
        Catch ex As Exception
            MsgBox("Error" + ex.Message.ToString)
            ReproducirSonidoError()
        End Try
    End Sub

    'Public Sub LlenarComboMotivos()

    '    Dim objNegocio As New Negocios.DevolucionClientesBU
    '    Dim lista As New DataTable
    '    lista = objNegocio.ListadoMotivos("")

    '    If lista.Rows.Count > 0 Then
    '        Dim newRow As DataRow = lista.NewRow
    '        lista.Rows.InsertAt(newRow, 0)
    '        cmbMotivoDevolucion.DataSource = lista
    '        cmbMotivoDevolucion.DisplayMember = "Motivo"
    '        cmbMotivoDevolucion.ValueMember = "esta_estatusid"
    '    End If
    'End Sub

    Private Sub DevolucionCliente_CapturaGeneral_LecturaCodigoEtiquetas_Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not IsDBNull(objDevolucion.Devolucionclienteid) And objDevolucion.Devolucionclienteid <> 0 Then
            lblCliente.Text = objDevolucion.NombreCliente
            'idCliente = objDevolucion.Clienteid
            'pedidosSeleccionados = objDevolucion.Pedidos
            'documentosSeleccionados = objDevolucion.IdentificadorDocumentos

            objPermisos = (New Negocios.DevolucionClientesBU).ValidaPermisosPantallas(objDevolucion.Devolucionclienteid, "LECTURA_CODIGOS", Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
            Permisos()

            If Not IsDBNull(objDevolucion.Motivoventas_statusid) And objDevolucion.Motivoventas_statusid.ToString.Length > 0 And objDevolucion.Motivoventas_statusid <> "0" Then
                idMotivoDevolucion = objDevolucion.Motivoventas_statusid
                tipoMotivo = 1
                lblMotivo.Text = objDevolucion.Motivoventas
            Else
                idMotivoDevolucion = objDevolucion.Motivoinicialalmacen_statusid
                tipoMotivo = 2
                lblMotivo.Text = objDevolucion.Motivoinicialalmacen
            End If

            'idMotivoDevolucion = idMotivoDevolucion
            lblTipoDevolucion.Text = objDevolucion.Tipodevolucion
            'tipoDevolucion = tipoDevolucion
            lblFolioDev.Text = objDevolucion.Devolucionclienteid
            lblUnidad.Text = objDevolucion.Unidadid
            lblCantidad.Text = objDevolucion.Cantidad_inicial.ToString("N0")

            If objDevolucion.Tipodevolucion = "MENUDEO" Or objDevolucion.Motivoinicialalmacen = "DETALLES DE CALIDAD" Then
                lblIncidenciaAtodos.Visible = True
                btnAplicarIncidenciaaTodos.Visible = True
            End If
            ActualizarCantidades()
        End If

        pnlIDDocto.BackColor = Color.Transparent
        pnlPCG.BackColor = Color.Transparent
        Dim objBU As New Negocios.DevolucionClientesBU

        If objDevolucion.Tipodevolucion = "MENUDEO" Then
            LlenarComboMotivos()
        End If

        TipoCodigos()

        txtEtiquetaPar.Select()

        'grdCodigosCorrectos.DataSource = InicializarGrid(1)
        'grdCodigosErroneos.DataSource = InicializarGrid(2)

        Me.WindowState = FormWindowState.Maximized
        lblUnidad.Text = "(PARES)"
        btnAceptar.Enabled = False
        'pnlBtnIniciar.Visible = True
        'btnAceptar.Visible = True
        'rdbCodigoCliente.Enabled = True
        'pnlBtnDetener.Visible = True
        'lblTipoCodigos.Text = "AMECE"
    End Sub

    Private Sub txtEtiquetaPar_KeyDown(sender As Object, e As KeyEventArgs) Handles txtEtiquetaPar.KeyDown
        If e.KeyCode = Keys.Enter Then
            Cursor = Cursors.WaitCursor
            ConsultarEtiqueta()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub btnOcultarMostrarPedidos_Click(sender As Object, e As EventArgs) Handles btnOcultarMostrarPedidos.Click
        'grpbPedidosDocumentos.Visible = Not grpbPedidosDocumentos.Visible
        'txtEtiquetaPar.Select()
        Dim Formulario As New DevolucionCliente_CapturaGeneral_LecturaCodigos_PedidosDocumentos
        Formulario.documentosSeleccionados = objDevolucion.IdentificadorDocumentos
        Formulario.pedidosSeleccionados = objDevolucion.PedidosSAY
        Formulario.ShowDialog()
    End Sub

    Private Sub grdCodigosCorrectos_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdCodigosCorrectos.InitializeLayout
        DiseñoGrid(grdCodigosCorrectos, 1)
        e.Layout.Bands(0).Columns("Clasificación").EditorComponent = cmbClasificacion
        e.Layout.Bands(0).Columns("Nave").EditorComponent = cmbNave_UC

        e.Layout.Bands(0).Columns("Nave").FilterOperatorDefaultValue = FilterOperatorDefaultValue.Contains

        OcultarColumna("Error", grdCodigosCorrectos)

        e.Layout.Bands(0).Columns("Procede").EditorComponent = cmbProcede_UC
        Dim guardados As Integer = 0
        If grdCodigosCorrectos.Rows.Count > 0 Then

            '4 es el tipo de operación, para este caso se hace una conteo de todos los valores de la columna
            If grdCodigosCorrectos.DisplayLayout.Bands(0).Columns.Exists("CódigoPar") Then
                SumarColumnas(grdCodigosCorrectos, "CódigoPar", 4)
            End If
            '1 es el tipo de operación, para este caso se hace un suma de todas las filas
            If grdCodigosCorrectos.DisplayLayout.Bands(0).Columns.Exists("PrecioDevolución") Then
                SumarColumnas(grdCodigosCorrectos, "PrecioDevolución", 1)
            End If
            '1 es el tipo de operación, para este caso se hace un suma de todas las filas
            If grdCodigosCorrectos.DisplayLayout.Bands(0).Columns.Exists("PrecioDoc") Then
                SumarColumnas(grdCodigosCorrectos, "PrecioDoc", 1)
            End If

            If grdCodigosCorrectos.DisplayLayout.Bands(0).Columns.Exists("Precio") Then
                SumarColumnas(grdCodigosCorrectos, "Precio", 1)
            End If
            lblMonto.Text = SumarColumna(grdCodigosCorrectos, "PrecioDevolución").ToString
        End If

        porGuardar = 0
        For Each fila As UltraGridRow In grdCodigosCorrectos.Rows
            If fila.Cells("PorGuardar").Value.ToString = "SI" Then
                porGuardar += 1
                fila.Appearance.ForeColor = Color.Purple
            Else
                guardados += 1
                fila.Appearance.ForeColor = Color.Black
            End If
        Next

        lblCantidadCodigosDevolucion.Text = grdCodigosCorrectos.Rows.Count
        lblCantidadPorGuardar.Text = porGuardar.ToString
        lblGuardadosAnteriormente.Text = guardados.ToString
        asignaFormato_Columna(grdCodigosCorrectos)

        If btnIniciar.Enabled = False Then
            grdCodigosCorrectos.DisplayLayout.Bands(0).Columns(" ").Hidden = True
        Else
            grdCodigosCorrectos.DisplayLayout.Bands(0).Columns(" ").Hidden = False
        End If
    End Sub

    Private Sub rdbParYuyin_MouseClick(sender As Object, e As MouseEventArgs) Handles rdbParYuyin.MouseClick
        If rdbSeleccionado = 2 Then
            If grdCodigosCorrectos.Rows.Count > 0 Or grdCodigosErroneos.Rows.Count > 0 Then
                Dim ventanaConfirmacion As New Tools.confirmarFormGrande
                ventanaConfirmacion.mensaje = "Para cambiar el tipo de código a buscar, debe guardar los CÓDIGOS DE LA DEVOLUCIÓN, de no guardar tendrá que realizar la lectura nuevamente. Los códigos erróneos no se guardan en el sistema, puede exportarlos a Excel." & vbCrLf &
                                          "¿ Desea cambiar el tipo de código ahora ?"
                ventanaConfirmacion.ShowDialog(Me)
                If ventanaConfirmacion.DialogResult = Windows.Forms.DialogResult.OK Then
                    'Dim ventanaExito As New Tools.ExitoForm()
                    'ventanaExito.mensaje = "Registros guardados con éxito"
                    'ventanaExito.ShowDialog()
                    VisibilidadPaneles("PAR YUYIN")
                    LimpiarEtiquetasGrpbInfoUltimaSalidaInv()
                    LimpiarEtiquetasInfoPar()
                    rdbCodigoCliente.Checked = False
                    rdbParYuyin.Checked = True
                    rdbSeleccionado = 1
                    'grdCodigosCorrectos.DataSource = InicializarGrid(1)
                    'Dim gridPrueba As DataTable = (New Negocios.DevolucionClientesBU).ConsultaCodigos_Devolucion(CInt(lblFolioDev.Text.ToString), "PAR YUYIN")
                    'grdCodigosCorrectos.DataSource = gridPrueba
                    'Dim dtotro As DataTable = gridPrueba.Clone
                    'grdCodigosErroneos.DataSource = InicializarGrid(2)
                    PoblarGrid("PAR YUYIN")
                    LimpiarTodasLasEtiquetasGrpb()
                Else
                    rdbCodigoCliente.Checked = True
                    rdbParYuyin.Checked = False
                End If
            Else
                rdbCodigoCliente.Checked = False
                rdbParYuyin.Checked = True
                rdbSeleccionado = 1
                VisibilidadPaneles("PAR YUYIN")
                'grdCodigosCorrectos.DataSource = InicializarGrid(1)
                'grdCodigosCorrectos.DataSource = (New Negocios.DevolucionClientesBU).ConsultaCodigos_Devolucion(CInt(lblFolioDev.Text.ToString), "PAR YUYIN")
                'grdCodigosErroneos.DataSource = InicializarGrid(2)
                PoblarGrid("PAR YUYIN")
                LimpiarTodasLasEtiquetasGrpb()
            End If

        End If
        txtEtiquetaPar.Select()
    End Sub

    Private Sub rdbCodigoCliente_MouseClick(sender As Object, e As MouseEventArgs) Handles rdbCodigoCliente.MouseClick
        Dim negocios As New Negocios.DevolucionClientesBU
        If rdbSeleccionado = 1 Then
            If grdCodigosCorrectos.Rows.Count > 0 Or grdCodigosErroneos.Rows.Count > 0 Then
                Dim ventanaConfirmacion As New Tools.confirmarFormGrande
                ventanaConfirmacion.mensaje = "Para cambiar el tipo de código a buscar, debe guardar los CÓDIGOS DE LA DEVOLUCIÓN, de no guardar tendrá que realizar la lectura nuevamente. Los códigos erróneos no se guardan en el sistema, puede exportarlos a Excel." & vbCrLf &
                                          "¿ Desea cambiar el tipo de código ahora ?"
                ventanaConfirmacion.ShowDialog(Me)
                If ventanaConfirmacion.DialogResult = Windows.Forms.DialogResult.OK Then
                    'Dim ventanaExito As New Tools.ExitoForm()
                    'ventanaExito.mensaje = "Registros guardados con éxito"
                    'ventanaExito.ShowDialog()
                    LimpiarEtiquetasGrpbCodAmece()
                    LimpiarEtiquetasGrpbInfoCodCliente()
                    LimpiarEtiquetasInfoPar()
                    rdbCodigoCliente.Checked = True
                    rdbParYuyin.Checked = False
                    rdbSeleccionado = 2
                    VisibilidadPaneles(lblTipoCodigos.Text)
                    'grdCodigosCorrectos.DataSource = InicializarGrid(1)
                    'grdCodigosCorrectos.DataSource = negocios.ConsultaCodigos_Devolucion(CInt(lblFolioDev.Text), lblTipoCodigos.Text)
                    'grdCodigosErroneos.DataSource = InicializarGrid(2)
                    PoblarGrid(lblTipoCodigos.Text)
                    LimpiarTodasLasEtiquetasGrpb()
                Else
                    rdbCodigoCliente.Checked = False
                    rdbParYuyin.Checked = True
                End If
            Else
                rdbCodigoCliente.Checked = True
                rdbParYuyin.Checked = False
                rdbSeleccionado = 2
                VisibilidadPaneles(lblTipoCodigos.Text)
                'grdCodigosCorrectos.DataSource = InicializarGrid(1)
                'grdCodigosCorrectos.DataSource = negocios.ConsultaCodigos_Devolucion(CInt(lblFolioDev.Text), lblTipoCodigos.Text)
                'grdCodigosErroneos.DataSource = InicializarGrid(2)
                PoblarGrid(lblTipoCodigos.Text)
                LimpiarTodasLasEtiquetasGrpb()
            End If
        End If
        txtEtiquetaPar.Select()
    End Sub

    Private Sub btnExportarCorrectos_Click(sender As Object, e As EventArgs) Handles btnExportarCorrectos.Click
        Cursor = Cursors.WaitCursor
        Dim gridExcelExporter As New ExcelExport.UltraGridExcelExporter
        Dim fbdUbicacionArchivo As New FolderBrowserDialog
        Dim grid As New UltraGrid
        Dim nombreDocumento As String = String.Empty
        Dim advertencia As New Tools.AdvertenciaForm
        grid = grdCodigosCorrectos
        If grid.Rows.GetFilteredInNonGroupByRows.Count > 0 Then
            With grid.DisplayLayout.Bands(0)
                .Columns(" ").Hidden = True
            End With
            nombreDocumento = "\Devoluciones_CodigosCorrectos"

            With fbdUbicacionArchivo
                .Reset()
                .Description = " Seleccione una carpeta"
                .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                .ShowNewFolderButton = True

                Dim ret As DialogResult = .ShowDialog

                If ret = Windows.Forms.DialogResult.OK Then

                    Dim fecha_hora As String = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString
                    gridExcelExporter.Export(grid, .SelectedPath + nombreDocumento + fecha_hora + ".xlsx")
                    With grid.DisplayLayout.Bands(0)
                        '.Columns("seleccionar").Hidden = False
                    End With
                    Dim mensajeExito As New Tools.ExitoForm
                    Cursor = Cursors.Default
                    mensajeExito.mensaje = "Los datos se exportaron correctamente"
                    mensajeExito.ShowDialog()
                    Process.Start(.SelectedPath + nombreDocumento + fecha_hora + ".xlsx")
                End If
                .Dispose()
            End With

        Else
            Cursor = Cursors.Default
            advertencia.mensaje = "No hay datos para exportar "
            advertencia.ShowDialog()
        End If
        Cursor = Cursors.Default
        txtEtiquetaPar.Select()
    End Sub

    Private Sub btnExportarErroneos_Click(sender As Object, e As EventArgs) Handles btnExportarErroneos.Click
        Cursor = Cursors.WaitCursor
        Dim gridExcelExporter As New ExcelExport.UltraGridExcelExporter
        Dim fbdUbicacionArchivo As New FolderBrowserDialog
        Dim grid As New UltraGrid
        Dim nombreDocumento As String = String.Empty
        Dim advertencia As New Tools.AdvertenciaForm
        grid = grdCodigosErroneos
        If grid.Rows.GetFilteredInNonGroupByRows.Count > 0 Then
            With grid.DisplayLayout.Bands(0)
                .Columns(" ").Hidden = True
            End With
            nombreDocumento = "\Devoluciones_CodigosErroneos"

            With fbdUbicacionArchivo
                .Reset()
                .Description = " Seleccione una carpeta"
                .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                .ShowNewFolderButton = True

                Dim ret As DialogResult = .ShowDialog

                If ret = Windows.Forms.DialogResult.OK Then

                    Dim fecha_hora As String = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString
                    gridExcelExporter.Export(grid, .SelectedPath + nombreDocumento + fecha_hora + ".xlsx")
                    With grid.DisplayLayout.Bands(0)
                        '.Columns("seleccionar").Hidden = False
                    End With
                    Dim mensajeExito As New Tools.ExitoForm
                    Cursor = Cursors.Default
                    mensajeExito.mensaje = "Los datos se exportaron correctamente"
                    mensajeExito.ShowDialog()
                    Process.Start(.SelectedPath + nombreDocumento + fecha_hora + ".xlsx")
                End If
                .Dispose()
            End With
        Else
            Cursor = Cursors.Default
            advertencia.mensaje = "No hay datos para exportar "
            advertencia.ShowDialog()
        End If
        Cursor = Cursors.Default
        txtEtiquetaPar.Select()
    End Sub

    Private Sub grdCodigosErroneos_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdCodigosErroneos.InitializeLayout
        DiseñoGrid(grdCodigosErroneos, 2)

        OcultarColumna("CodRápido", grdCodigosErroneos)
        OcultarColumna("Artículo", grdCodigosErroneos)
        OcultarColumna("Talla", grdCodigosErroneos)

        If grdCodigosErroneos.Rows.Count > 0 Then
            '4 es el número de columna y 1 es el tipo de operación, para este caso se hace una suma de todos los valores de la columna
            If grdCodigosCorrectos.DisplayLayout.Bands(0).Columns.Exists("CódigoPar") Then
                SumarColumnas(grdCodigosErroneos, "CódigoPar", 4)
            End If
            '1 es el número de columna y 1 es el tipo de operación, para este caso se hace un conteo de todas las filas
            If grdCodigosCorrectos.DisplayLayout.Bands(0).Columns.Exists("PrecioDevolución") Then
                SumarColumnas(grdCodigosErroneos, "PrecioDevolución", 1)
            End If

            If grdCodigosErroneos.DisplayLayout.Bands(0).Columns.Exists("PrecioDoc") Then
                SumarColumnas(grdCodigosErroneos, "PrecioDoc", 1)
            End If
        End If
        grdCodigosErroneos.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
        lblCantidadCodigosErroneos.Text = grdCodigosErroneos.Rows.Count
        asignaFormato_Columna(grdCodigosErroneos)

        If btnIniciar.Enabled = False Then
            grdCodigosErroneos.DisplayLayout.Bands(0).Columns(" ").Hidden = True
        Else
            grdCodigosErroneos.DisplayLayout.Bands(0).Columns(" ").Hidden = False
        End If
    End Sub

    Private Sub txtEtiquetaPar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtEtiquetaPar.KeyPress
        e.Handled = Char.IsWhiteSpace(e.KeyChar)
        If e.KeyChar = "'" Then
            e.KeyChar = "-"
        End If
    End Sub

    Private Sub btnEliminarCorrectos_Click(sender As Object, e As EventArgs) Handles btnEliminarCorrectos.Click
        Try
            Dim codigos As String = ""
            codigos = EliminarCodigosSeleccionados(grdCodigosCorrectos)
            Dim negocios As New Negocios.DevolucionClientesBU
            negocios.EliminarCodigoDev(codigos, CInt(lblFolioDev.Text), Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, idMotivoDevolucion)
            Dim porGuardar As Integer = 0
            Dim guardados As Integer = 0
            For Each fila As UltraGridRow In grdCodigosCorrectos.Rows
                If fila.Cells("PorGuardar").Value.ToString = "SI" Then
                    porGuardar += 1
                    fila.Appearance.ForeColor = Color.Purple
                Else
                    guardados += 1
                    fila.Appearance.ForeColor = Color.Black
                End If
            Next
            lblCantidadCodigosDevolucion.Text = grdCodigosCorrectos.Rows.Count
            lblCantidadPorGuardar.Text = porGuardar.ToString
            lblGuardadosAnteriormente.Text = guardados.ToString
            ActualizarCantidades()
            asignaFormato_Columna(grdCodigosCorrectos)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub btnEliminarErroneos_Click(sender As Object, e As EventArgs) Handles btnEliminarErroneos.Click
        EliminarCodigosSeleccionados(grdCodigosErroneos)
        lblCantidadCodigosErroneos.Text = grdCodigosErroneos.Rows.Count
    End Sub

    Private Sub grdCodigosCorrectos_ClickCell(sender As Object, e As ClickCellEventArgs) Handles grdCodigosCorrectos.ClickCell

        If Not grdCodigosCorrectos.ActiveRow.IsDataRow Then Return
        If IsNothing(grdCodigosCorrectos.ActiveRow) Then Return

        If btnIniciar.Enabled = False And e.Cell.Column.ToString <> "Procede" And e.Cell.Column.ToString <> "Clasificación" Then
            txtEtiquetaPar.Select()
            Return
        End If

        If e.Cell.Column.ToString = " " Then
            If grdCodigosCorrectos.ActiveRow.Cells(" ").Value Then
                grdCodigosCorrectos.ActiveRow.Cells(" ").Value = False
            Else
                grdCodigosCorrectos.ActiveRow.Cells(" ").Value = True
            End If

            Dim marcados As Integer
            For Each row As UltraGridRow In grdCodigosCorrectos.Rows
                If CBool(row.Cells(" ").Value) Then
                    marcados += 1
                End If
            Next
            lblNumFiltrados.Text = marcados.ToString("N0", CultureInfo.InvariantCulture)
            If marcados > 0 And cmbMotivoDevolucion.Items.Count > 0 Then
                btnActualizarCodigos.Enabled = True
            Else
                btnActualizarCodigos.Enabled = False
            End If

        End If

        If e.Cell.Column.ToString = "Lote" And pnlBtnIniciar.Visible = True Then
            grdCodigosCorrectos.PerformAction(UltraGridAction.EnterEditMode, False, False)
        End If
    End Sub

    Private Sub chkSeleccionarTodosCorrectos_CheckedChanged(sender As Object, e As EventArgs) Handles chkSeleccionarTodosCorrectos.CheckedChanged
        If chkSeleccionarTodosCorrectos.Checked Then
            For Each row In grdCodigosCorrectos.Rows.GetFilteredInNonGroupByRows
                row.Cells(" ").Value = True
            Next
        Else
            For Each row As UltraGridRow In grdCodigosCorrectos.Rows.GetFilteredInNonGroupByRows
                row.Cells(" ").Value = False
            Next
        End If
        Dim marcados As Integer
        For Each row As UltraGridRow In grdCodigosCorrectos.Rows
            If CBool(row.Cells(" ").Value) Then
                marcados += 1
            End If
        Next
        lblNumFiltrados.Text = marcados.ToString("N0", CultureInfo.InvariantCulture)
        If marcados > 0 Then
            btnActualizarCodigos.Enabled = True
        Else
            btnActualizarCodigos.Enabled = False
        End If
        txtEtiquetaPar.Select()
    End Sub

    Private Sub chkSeleccionarTodosErroneos_CheckedChanged(sender As Object, e As EventArgs) Handles chkSeleccionarTodosErroneos.CheckedChanged
        If chkSeleccionarTodosErroneos.Checked Then
            For Each row In grdCodigosErroneos.Rows.GetFilteredInNonGroupByRows
                row.Cells(" ").Value = True
            Next
        Else
            For Each row As UltraGridRow In grdCodigosErroneos.Rows.GetFilteredInNonGroupByRows
                row.Cells(" ").Value = False
            Next
        End If
        txtEtiquetaPar.Select()
    End Sub

    Private Sub grdCodigosCorrectos_AfterCellUpdate(sender As Object, e As CellEventArgs) Handles grdCodigosCorrectos.AfterCellUpdate
        If e.Cell.Column.ToString = "Defecto/Motivo" Then
            If e.Cell.Value.ToString.Length > 0 And e.Cell.Value <> cmbMotivoDevolucion.Text Then
                e.Cell.Appearance.ForeColor = Color.Purple
            Else
                e.Cell.Appearance.ForeColor = Color.Black
            End If
        ElseIf e.Cell.Column.ToString = "PrecioDevolución" Then
            Try
                If e.Cell.Value.ToString.Length > 0 And grdCodigosCorrectos.Rows(e.Cell.Row.RowSelectorNumber - 1).Cells("PrecioLista").Value <> e.Cell.Value.ToString Then 'And  <> cmbMotivoDevolucion.Text Then
                    e.Cell.Appearance.ForeColor = Color.Purple
                Else
                    e.Cell.Appearance.ForeColor = Color.Black
                End If
            Catch ex As Exception
                e.Cell.Value = 0
                If grdCodigosCorrectos.Rows(e.Cell.Row.RowSelectorNumber - 1).Cells("PrecioLista").Value <> e.Cell.Value.ToString Then
                    e.Cell.Appearance.ForeColor = Color.Purple
                Else
                    e.Cell.Appearance.ForeColor = Color.Black
                End If
            End Try
            lblMonto.Text = SumarColumna(grdCodigosCorrectos, "PrecioDevolución").ToString
        End If
    End Sub

    Private Sub DevolucionCliente_CapturaGeneral_LecturaCodigoEtiquetas_Form_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If CInt(lblCantidadPorGuardar.Text) > 0 Or grdCodigosErroneos.Rows.Count > 0 Then
            Dim ventanaConfirmacion As New Tools.ConfirmarForm
            ventanaConfirmacion.mensaje = "La lectura de registros no guardados se perderá al cerrar la pantalla. Los códigos erróneos no se guardan, puede exportar el listado a Excel." & vbCrLf &
                                    "¿ Desea cerrar la pantalla ahora ?"
            ventanaConfirmacion.ShowDialog()
            If ventanaConfirmacion.DialogResult = Windows.Forms.DialogResult.OK Then
                Me.Dispose()
            Else
                e.Cancel = True
                txtEtiquetaPar.Select()
            End If
        End If
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub btnActualizarCodigos_Click(sender As Object, e As EventArgs) Handles btnActualizarCodigos.Click
        Dim contador As Int16 = 0

        If CInt(lblNumFiltrados.Text) > 0 Then
            Dim ventanaConfirmacion As New Tools.ConfirmarForm
            ventanaConfirmacion.mensaje = "Se modificará el motivo de devolución de los registros seleccionados" & vbCrLf & "¿Desea continuar?"
            ventanaConfirmacion.ShowDialog()
            If ventanaConfirmacion.DialogResult = Windows.Forms.DialogResult.OK Then
                For Each row As UltraGridRow In grdCodigosCorrectos.Rows
                    If row.Cells(" ").Value = True Then
                        row.Cells("Defecto/Motivo").Value = cmbMotivoDevolucion.Text
                        contador += 1
                    End If
                Next
                Dim ventana As New Tools.ExitoForm
                ventana.mensaje = "Se modificó el motivo de devolución de " & contador & " registros"
                cmbMotivoDevolucion.SelectedValue = idMotivoDevolucion
                cmbMotivoDevolucion.SelectedValue = idMotivoDevolucion
                ventana.ShowDialog()
            End If
        Else
            Dim ventanaAlerta As New Tools.AdvertenciaForm
            ventanaAlerta.mensaje = "No ha seleccionado ningún registro"
            ventanaAlerta.ShowDialog()
        End If
        txtEtiquetaPar.Select()
    End Sub

    Private Sub grdCodigosCorrectos_KeyDown(sender As Object, e As KeyEventArgs) Handles grdCodigosCorrectos.KeyDown
        If e.KeyCode = Keys.Delete Then Return
        Dim cell As UltraGridCell = grdCodigosCorrectos.ActiveCell
        Dim currentRow As Integer = grdCodigosCorrectos.ActiveRow.Index
        If e.KeyCode = Keys.Space Then
            If cell.Column.Header.Caption = "Defecto/Motivo" Then
                Dim frmMotivo As New DevolucionCliente_CapturaGeneral_BusquedaMotivosCalidad
                frmMotivo.idDetalle = 0
                frmMotivo.StartPosition = FormStartPosition.CenterScreen
                frmMotivo.ShowDialog()

                cell.Row.Cells("Defecto/Motivo").Value = frmMotivo.Motivo
                cell.Row.Cells("IdMotivo").Value = frmMotivo.IdMotivo
            ElseIf cell.Column.Header.Caption = "Nave" Then
                cell.DroppedDown = True
            ElseIf cell.Column.Header.Caption = "Procede" Then
                cell.DroppedDown = True
            ElseIf cell.Column.Header.Caption = "Clasificación" Then
                cell.DroppedDown = True
            ElseIf cell.Column.Header.Caption <> "Lote" Then
                txtEtiquetaPar.Select()
            End If
        ElseIf e.KeyCode = Keys.Enter Then
            cell.Selected = True
            grdCodigosCorrectos.Focus()
        End If

    End Sub

    Private Sub grdCodigosErroneos_KeyDown(sender As Object, e As KeyEventArgs) Handles grdCodigosErroneos.KeyDown
        If e.KeyCode = Keys.Delete Then Return
        txtEtiquetaPar.Select()
    End Sub

    Private Sub grdCodigosErroneos_ClickCell(sender As Object, e As ClickCellEventArgs) Handles grdCodigosErroneos.ClickCell
        If Not grdCodigosErroneos.ActiveRow.IsDataRow Then Return
        If IsNothing(grdCodigosErroneos.ActiveRow) Then Return

        If btnIniciar.Enabled = False Then
            txtEtiquetaPar.Select()
            Return
        End If

        If e.Cell.Column.ToString = " " Then
            If grdCodigosErroneos.ActiveRow.Cells(" ").Value Then
                grdCodigosErroneos.ActiveRow.Cells(" ").Value = False
            Else
                grdCodigosErroneos.ActiveRow.Cells(" ").Value = True
            End If

        End If
    End Sub

    Private Sub btnIniciar_Click(sender As Object, e As EventArgs) Handles btnIniciar.Click
        btnOcultarMostrarPedidos.Enabled = False
        btnEliminarCorrectos.Enabled = False
        btnEliminarErroneos.Enabled = False
        btnExportarCorrectos.Enabled = False
        btnExportarErroneos.Enabled = False
        chkSeleccionarTodosCorrectos.Enabled = False
        chkSeleccionarTodosErroneos.Enabled = False
        btnAceptar.Enabled = False
        btnCancelar.Enabled = False
        btnDetener.Enabled = True
        grdCodigosCorrectos.DisplayLayout.Bands(0).Columns(" ").Hidden = True
        grdCodigosErroneos.DisplayLayout.Bands(0).Columns(" ").Hidden = True
        btnIniciar.Enabled = False
        txtEtiquetaPar.Enabled = True
        If ambosTiposDeCodigos = True Then
            rdbCodigoCliente.Enabled = False
        End If
        rdbParYuyin.Enabled = False
        txtEtiquetaPar.Select()
    End Sub

    Private Sub btnDetener_Click(sender As Object, e As EventArgs) Handles btnDetener.Click
        btnOcultarMostrarPedidos.Enabled = True
        btnEliminarCorrectos.Enabled = True
        btnEliminarErroneos.Enabled = True
        btnExportarCorrectos.Enabled = True
        btnExportarErroneos.Enabled = True
        chkSeleccionarTodosCorrectos.Enabled = True
        chkSeleccionarTodosErroneos.Enabled = True
        btnAceptar.Enabled = True
        btnCancelar.Enabled = True
        btnDetener.Enabled = False
        grdCodigosCorrectos.DisplayLayout.Bands(0).Columns(" ").Hidden = False
        grdCodigosErroneos.DisplayLayout.Bands(0).Columns(" ").Hidden = False
        btnIniciar.Enabled = True
        txtEtiquetaPar.Enabled = False
        If ambosTiposDeCodigos = True Then
            rdbCodigoCliente.Enabled = True
        End If
        rdbParYuyin.Enabled = radioParYuyin

        If porGuardar > 0 Then
            btnAceptar.Enabled = True
        Else
            btnAceptar.Enabled = False
        End If
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Dim posicion = consultarultimaPosicion(lblFolioDev.Text)
        Try
            grdCodigosCorrectos.Select()
            pgrsPnlCargando.ContentAlignment = ContentAlignment.MiddleCenter
            pgrsPnlCargando.Top = (Me.Height - pgrsPnlCargando.Height) / 2
            pgrsPnlCargando.Left = (Me.Width - pgrsPnlCargando.Width) / 2
            pgrsPnlCargando.Description = "Guardando códigos..."

            pgrsPnlCargando.Show()
            pgrsPnlCargando.Refresh()

            Dim obj As New Negocios.DevolucionClientesBU
            Dim listAtributosFactura As New List(Of String)
            Dim motivoAGuardar As String = ""

            Cursor = Cursors.WaitCursor
            Dim vXmlCeldasModificadas As XElement = New XElement("Codigos")
            If TipoEtiquetasGrpBox = 1 Then
                For Each row As UltraGridRow In grdCodigosCorrectos.Rows

                    If row.Cells("PorGuardar").Value = "SI" Then

                        If row.Cells("IdMotivo").Value.ToString = "372" Then
                            Tools.Controles.Mensajes_Y_Alertas("ADVERTENCIA", "El registro no tiene un motivo válido")
                            row.CellAppearance.ForeColor = Color.Red
                            pgrsPnlCargando.Hide()
                            Cursor = Cursors.Default
                            Exit Sub
                        End If

                        motivoAGuardar = row.Cells("IdMotivo").Value.ToString

                        If motivoAGuardar = "" Or motivoAGuardar = "0" Then
                            If objDevolucion.Motivoventas_statusid.ToString = "" Or objDevolucion.Motivoventas_statusid.ToString = "0" Then
                                motivoAGuardar = objDevolucion.Motivoinicialalmacen_statusid
                            Else
                                motivoAGuardar = objDevolucion.Motivoventas_statusid
                            End If
                        End If

                        'listAtributosFactura = row.Cells("Factura").Value.ToString.Split("-").ToList
                        Dim vNodo As XElement = New XElement("Codigo")
                        vNodo.Add(New XAttribute("devolucionclienteid", lblFolioDev.Text))
                        vNodo.Add(New XAttribute("codigo", row.Cells("CódigoPar").Value))
                        vNodo.Add(New XAttribute("statuscodigo", row.Cells("Status").Value))
                        vNodo.Add(New XAttribute("tipocodigo", "PAR YUYIN"))
                        vNodo.Add(New XAttribute("productoestiloid", row.Cells("ProductoEstiloId").Value))
                        vNodo.Add(New XAttribute("talla", row.Cells("Talla").Value))
                        vNodo.Add(New XAttribute("lote", row.Cells("Lote").Value))
                        vNodo.Add(New XAttribute("añolote", row.Cells("AñoLote").Value))
                        vNodo.Add(New XAttribute("naveid", row.Cells("Nave").Value))
                        vNodo.Add(New XAttribute("motivodevolucion_statusid", motivoAGuardar))
                        vNodo.Add(New XAttribute("clasificacion", IIf(row.Cells("Clasificación").Value.ToString = "", 321, row.Cells("Clasificación").Value)))
                        vNodo.Add(New XAttribute("clienteid_ultimomovimiento", row.Cells("IdClienteSayPar").Value))
                        vNodo.Add(New XAttribute("pedidoid", row.Cells("PedidoSay").Value))
                        vNodo.Add(New XAttribute("pedidosicyid", row.Cells("PedidoSICY").Value))
                        vNodo.Add(New XAttribute("partidaid", row.Cells("Partida").Value))
                        vNodo.Add(New XAttribute("fechaCreacion", Date.Now()))
                        If row.Cells("PCG").Value = "SI" Then
                            vNodo.Add(New XAttribute("pedido_capturageneral", 1))
                        Else
                            vNodo.Add(New XAttribute("pedido_capturageneral", 0))
                        End If
                        'vNodo.Add(New XAttribute("documentoid", row.Cells("DoctoSAY").Value)) --1
                        'vNodo.Add(New XAttribute("remisionid", row.Cells("Remisión").Value)) --2
                        'vNodo.Add(New XAttribute("añodocumento", row.Cells("Año").Value)) --3
                        'If listAtributosFactura.Count >= 2 Then
                        'vNodo.Add(New XAttribute("seriefactura", listAtributosFactura(0))) --4
                        'vNodo.Add(New XAttribute("foliofactura", listAtributosFactura(1))) --5
                        'End If
                        'If row.Cells("DCG").Value = "SI" Then
                        'vNodo.Add(New XAttribute("documento_capturageneral", 1)) --6
                        'Else
                        'vNodo.Add(New XAttribute("documento_capturageneral", 0))
                        'End If
                        vNodo.Add(New XAttribute("listaprecio", row.Cells("ListaPrecio").Value))
                        vNodo.Add(New XAttribute("preciolista", row.Cells("PrecioLista").Value))
                        vNodo.Add(New XAttribute("preciodevolucion", row.Cells("PrecioDevolución").Value))
                        vNodo.Add(New XAttribute("procede", row.Cells("Procede").Value))
                        vNodo.Add(New XAttribute("usuariocreoid", Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid))
                        vNodo.Add(New XAttribute("posicion", posicion))
                        vXmlCeldasModificadas.Add(vNodo)
                        row.Cells("PorGuardar").Value = "NO"
                        posicion = posicion + 1
                    End If
                Next
            ElseIf TipoEtiquetasGrpBox = 2 Then
                For Each row As UltraGridRow In grdCodigosCorrectos.Rows

                    If row.Cells("PorGuardar").Value = "SI" Then

                        If row.Cells("IdMotivo").Value.ToString = "372" Then
                            Tools.Controles.Mensajes_Y_Alertas("ADVERTENCIA", "El registro no tiene un motivo válido")
                            row.CellAppearance.ForeColor = Color.Red
                            pgrsPnlCargando.Hide()
                            Cursor = Cursors.Default
                            Exit Sub
                        End If

                        motivoAGuardar = row.Cells("IdMotivo").Value.ToString

                        If motivoAGuardar = "" Or motivoAGuardar = "0" Then
                            If objDevolucion.Motivoventas_statusid.ToString = "" Or objDevolucion.Motivoventas_statusid.ToString = "0" Then
                                motivoAGuardar = objDevolucion.Motivoinicialalmacen_statusid
                            Else
                                motivoAGuardar = objDevolucion.Motivoventas_statusid
                            End If
                        End If

                        'listAtributosFactura = row.Cells("Factura").Value.ToString.Split("-").ToList
                        Dim vNodo As XElement = New XElement("Codigo")
                        vNodo.Add(New XAttribute("devolucionclienteid", lblFolioDev.Text))
                        vNodo.Add(New XAttribute("codigo", row.Cells("CodCliente").Value))
                        vNodo.Add(New XAttribute("statuscodigo", ""))
                        vNodo.Add(New XAttribute("tipocodigo", "ESPECIALES"))
                        vNodo.Add(New XAttribute("productoestiloid", row.Cells("ProductoEstiloID").Value))
                        vNodo.Add(New XAttribute("talla", row.Cells("Talla").Value))
                        vNodo.Add(New XAttribute("lote", row.Cells("Lote").Value))
                        vNodo.Add(New XAttribute("añolote", ""))
                        vNodo.Add(New XAttribute("naveid", row.Cells("Nave").Value))
                        vNodo.Add(New XAttribute("motivodevolucion_statusid", motivoAGuardar))
                        vNodo.Add(New XAttribute("clasificacion", IIf(row.Cells("Clasificación").Value.ToString = "", 321, row.Cells("Clasificación").Value)))
                        vNodo.Add(New XAttribute("clienteid_ultimomovimiento", ""))
                        vNodo.Add(New XAttribute("pedidoid", ""))
                        vNodo.Add(New XAttribute("pedidosicyid", ""))
                        vNodo.Add(New XAttribute("partidaid", ""))
                        vNodo.Add(New XAttribute("fechaCreacion", Date.Now()))
                        vNodo.Add(New XAttribute("pedido_capturageneral", 0))

                        'vNodo.Add(New XAttribute("documentoid", ""))
                        'vNodo.Add(New XAttribute("remisionid", ""))
                        'vNodo.Add(New XAttribute("añodocumento", ""))

                        'vNodo.Add(New XAttribute("seriefactura", ""))
                        'vNodo.Add(New XAttribute("foliofactura", ""))

                        'vNodo.Add(New XAttribute("documento_capturageneral", 0))

                        'Especiales/AMECE
                        vNodo.Add(New XAttribute("listaprecio", row.Cells("ListaCliente").Value))
                        vNodo.Add(New XAttribute("preciolista", row.Cells("PrecioLista").Value))
                        vNodo.Add(New XAttribute("preciodevolucion", row.Cells("PrecioDevolución").Value))
                        vNodo.Add(New XAttribute("procede", row.Cells("Procede").Value))
                        vNodo.Add(New XAttribute("usuariocreoid", Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid))
                        vNodo.Add(New XAttribute("posicion", posicion))
                        'vNodo.Add(New XAttribute("fechacreacion", row.Cells().Value))
                        vXmlCeldasModificadas.Add(vNodo)
                        row.Cells("PorGuardar").Value = "NO"
                        posicion = posicion + 1
                    End If
                Next
            ElseIf TipoEtiquetasGrpBox = 3 Then
                For Each row As UltraGridRow In grdCodigosCorrectos.Rows

                    If row.Cells("PorGuardar").Value = "SI" Then

                        If row.Cells("IdMotivo").Value.ToString = "372" Then
                            Tools.Controles.Mensajes_Y_Alertas("ADVERTENCIA", "El registro no tiene un motivo válido")
                            row.CellAppearance.ForeColor = Color.Red
                            pgrsPnlCargando.Hide()
                            Cursor = Cursors.Default
                            Exit Sub
                        End If

                        motivoAGuardar = row.Cells("IdMotivo").Value.ToString

                        If motivoAGuardar = "" Or motivoAGuardar = "0" Then
                            If objDevolucion.Motivoventas_statusid.ToString = "" Or objDevolucion.Motivoventas_statusid.ToString = "0" Then
                                motivoAGuardar = objDevolucion.Motivoinicialalmacen_statusid
                            Else
                                motivoAGuardar = objDevolucion.Motivoventas_statusid
                            End If
                        End If

                        'listAtributosFactura = row.Cells("Factura").Value.ToString.Split("-").ToList
                        Dim vNodo As XElement = New XElement("Codigo")
                        vNodo.Add(New XAttribute("devolucionclienteid", lblFolioDev.Text))
                        vNodo.Add(New XAttribute("codigo", row.Cells("CodAMECE").Value))
                        vNodo.Add(New XAttribute("statuscodigo", "Status"))
                        vNodo.Add(New XAttribute("tipocodigo", "AMECE"))
                        vNodo.Add(New XAttribute("productoestiloid", row.Cells("ProductoEstiloID").Value))
                        vNodo.Add(New XAttribute("talla", row.Cells("Talla").Value))
                        vNodo.Add(New XAttribute("lote", row.Cells("Lote").Value))
                        vNodo.Add(New XAttribute("añolote", ""))
                        vNodo.Add(New XAttribute("naveid", row.Cells("Nave").Value))
                        vNodo.Add(New XAttribute("motivodevolucion_statusid", motivoAGuardar))
                        vNodo.Add(New XAttribute("clasificacion", IIf(row.Cells("Clasificación").Value.ToString = "", 321, row.Cells("Clasificación").Value)))
                        vNodo.Add(New XAttribute("clienteid_ultimomovimiento", ""))
                        vNodo.Add(New XAttribute("pedidoid", ""))
                        vNodo.Add(New XAttribute("pedidosicyid", ""))
                        vNodo.Add(New XAttribute("partidaid", ""))
                        vNodo.Add(New XAttribute("fechaCreacion", Date.Now()))
                        vNodo.Add(New XAttribute("pedido_capturageneral", 0))

                        'vNodo.Add(New XAttribute("documentoid", ""))
                        'vNodo.Add(New XAttribute("remisionid", ""))
                        'vNodo.Add(New XAttribute("añodocumento", ""))

                        'vNodo.Add(New XAttribute("seriefactura", ""))
                        'vNodo.Add(New XAttribute("foliofactura", ""))

                        'vNodo.Add(New XAttribute("documento_capturageneral", 0))

                        vNodo.Add(New XAttribute("listaprecio", row.Cells("ListaCliente").Value))
                        vNodo.Add(New XAttribute("preciolista", row.Cells("PrecioLista").Value))
                        vNodo.Add(New XAttribute("preciodevolucion", row.Cells("PrecioDevolución").Value))
                        vNodo.Add(New XAttribute("procede", row.Cells("Procede").Value))
                        vNodo.Add(New XAttribute("usuariocreoid", Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid))
                        vNodo.Add(New XAttribute("posicion", posicion))
                        'vNodo.Add(New XAttribute("fechacreacion", row.Cells().Value))
                        vXmlCeldasModificadas.Add(vNodo)
                        row.Cells("PorGuardar").Value = "NO"
                        posicion = posicion + 1
                    End If
                Next
            End If

            obj.GuardarCodigos(vXmlCeldasModificadas.ToString())
            obj.guardarFacturacionTodosCodigos(lblFolioDev.Text)
            ''obj.actualizaDetallesCodigosDevoluciones(lblFolioDev.Text)

            grdCodigosCorrectos.DataSource = Nothing
            If rdbParYuyin.Checked = True Then
                grdCodigosCorrectos.DataSource = obj.ConsultaCodigos_Devolucion(CInt(lblFolioDev.Text), "PAR YUYIN")
            Else
                grdCodigosCorrectos.DataSource = obj.ConsultaCodigos_Devolucion(CInt(lblFolioDev.Text), lblTipoCodigos.Text.ToString)
            End If
            Dim ventana As New Tools.ExitoForm
            ventana.mensaje = "Los códigos se registraron correctamente"
            ventana.ShowDialog()
            ActualizarCantidades()
            Dim CodporGuardar As Integer = 0
            Dim guardados As Integer = 0
            For Each fila As UltraGridRow In grdCodigosCorrectos.Rows
                If fila.Cells("PorGuardar").Value.ToString = "SI" Then
                    CodporGuardar += 1
                    fila.Appearance.ForeColor = Color.Purple
                Else
                    guardados += 1
                    fila.Appearance.ForeColor = Color.Black
                End If
            Next

            btnAceptar.Enabled = False
            lblCantidadPorGuardar.Text = CodporGuardar.ToString
            lblGuardadosAnteriormente.Text = guardados.ToString
            pgrsPnlCargando.Hide()
        Catch ex As Exception
            pgrsPnlCargando.Hide()
            Dim ventanaError As New Tools.ErroresForm
            ventanaError.mensaje = "Ocurrió un error al guardar" + vbCrLf + ex.Message
            ventanaError.ShowDialog()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub DevolucionCliente_CapturaGeneral_LecturaCodigoEtiquetas_Form_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        pgrsPnlCargando.ContentAlignment = ContentAlignment.MiddleCenter
        pgrsPnlCargando.Top = (Me.Height - pgrsPnlCargando.Height) / 2
        pgrsPnlCargando.Left = (Me.Width - pgrsPnlCargando.Width) / 2
        pgrsPnlCargando.Description = "Cargando códigos..."
        pgrsPnlCargando.Show()
        pgrsPnlCargando.Refresh()
        Dim dtNaves As DataTable
        Dim row As DataRow

        dtNaves = (New Negocios.DevolucionCliente_EntradaSalida_Nave_BU).ConsultaNaves()

        row = dtNaves.NewRow()
        row("IdNave") = 0
        row("Nave") = ""
        dtNaves.Rows.InsertAt(row, 0)

        If rdbParYuyin.Checked = True Then
            PoblarGrid("PAR YUYIN")
        Else
            PoblarGrid(lblTipoCodigos.Text)
        End If
        GenerarCombo_Grid()

        cmbClasificacion.BindingContext = Me.BindingContext
        cmbClasificacion.DataSource = (New Negocios.DevolucionClientesBU).ConsultaClasificacion_Detalles()
        cmbClasificacion.ValueMember = "esta_estatusid"
        cmbClasificacion.DisplayMember = "esta_nombre"
        cmbClasificacion.BorderStyle = UIElementBorderStyle.Solid
        'cmbClasificacion.DisplayLayout.Bands(0).Columns(0).Hidden = True
        'cmbClasificacion.DisplayLayout.BorderStyle = UIElementBorderStyle.Solid
        cmbClasificacion.DropDownStyle = UltraComboStyle.DropDownList
        'cmbClasificacion.DisplayLayout.Bands(0).ColHeadersVisible = False

        cmbNave_UC.BindingContext = Me.BindingContext
        'cmbNave_UC.DataSource = (New Negocios.DevolucionCliente_EntradaSalida_Nave_BU).ConsultaNaves()
        cmbNave_UC.DataSource = dtNaves
        cmbNave_UC.ValueMember = "IdNave"
        cmbNave_UC.DisplayMember = "Nave"
        cmbNave_UC.BorderStyle = UIElementBorderStyle.Solid
        cmbNave_UC.DisplayLayout.Bands(0).Columns(0).Hidden = True
        cmbNave_UC.DisplayLayout.BorderStyle = UIElementBorderStyle.Solid
        cmbNave_UC.DropDownStyle = UltraComboStyle.DropDownList
        cmbNave_UC.DisplayLayout.Bands(0).ColHeadersVisible = False

        pgrsPnlCargando.Hide()
    End Sub

    Private Sub grdCodigosCorrectos_DoubleClickCell(sender As Object, e As DoubleClickCellEventArgs) Handles grdCodigosCorrectos.DoubleClickCell
        If pnlBtnIniciar.Visible = True Then
            If e.Cell.Column.Header.Caption = "Defecto/Motivo" Then
                Dim frmMotivo As New DevolucionCliente_CapturaGeneral_BusquedaMotivosCalidad
                frmMotivo.idDetalle = 0
                frmMotivo.StartPosition = FormStartPosition.CenterScreen
                frmMotivo.ShowDialog()

                e.Cell.Row.Cells("Defecto/Motivo").Value = frmMotivo.Motivo
                e.Cell.Row.Cells("IdMotivo").Value = frmMotivo.IdMotivo
            End If
        End If
    End Sub

    Private Sub btnAplicarIncidenciaaTodos_Click(sender As Object, e As EventArgs) Handles btnAplicarIncidenciaaTodos.Click
        If CInt(lblNumFiltrados.Text) > 0 Then
            Dim frmMotivo As New DevolucionCliente_CapturaGeneral_BusquedaMotivosCalidad
            frmMotivo.idDetalle = 0
            frmMotivo.StartPosition = FormStartPosition.CenterScreen
            frmMotivo.ShowDialog()

            For Each row As UltraGridRow In grdCodigosCorrectos.Rows
                If row.Cells(" ").Value = True Then
                    row.Cells("Defecto/Motivo").Value = frmMotivo.Motivo
                    row.Cells("IdMotivo").Value = frmMotivo.IdMotivo
                End If
            Next
        Else
            Tools.Controles.Mensajes_Y_Alertas("ADVERTENCIA", "No se ha seleccionado ningún registro")
        End If
    End Sub

    Private Function consultarultimaPosicion(foliodev) As Integer
        Dim obj As New Negocios.DevolucionClientesBU
        Dim resultado = obj.ConsultaUltimaPosicionCodigo(foliodev)
        Return resultado.Rows(0).Item("POSICION")
    End Function

End Class