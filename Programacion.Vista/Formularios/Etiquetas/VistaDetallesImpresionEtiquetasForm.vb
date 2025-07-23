Imports Tools
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid
Imports DevExpress.XtraPrinting
Imports DevExpress.XtraReports.UI
Imports DevExpress.XtraReports.ReportGeneration

Public Class VistaDetallesImpresionEtiquetasForm

    Public Lotes As String = String.Empty
    Public NaveSICYId As Integer = 0
    Public Año As Integer = 0
    Public FechaPrograma As Date
    'Public DtInfomracionValidacion As New DataTable
    Public EtiquetaId As String = String.Empty
    Public ImpresoraId As Integer = 0

    Private OBJBU As New Programacion.Negocios.EtiquetasBU

    Private Sub VistaDetallesImpresionEtiquetasForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        CargarInformacion()
    End Sub

    Private Sub CargarInformacion()
        Dim dtDetallesImpresion As New DataTable

        Try
            dtDetallesImpresion = OBJBU.ConsultaDetallesImpresion(Lotes, NaveSICYId, Año, FechaPrograma, ImpresoraId, EtiquetaId)
            grdDetallesEtiquetas.DataSource = dtDetallesImpresion
            DiseñoGrid(viewgrdDetallesEtiquetas)
            OcultarColumnasParametrosEtiqueta()
        Catch ex As Exception
            show_message("Error", "Ocurrio un error al mostrar la información.")
        End Try

    End Sub

    Private Sub OcultarColumnasParametrosEtiqueta()
        Dim dtParametrosEtiqueta As New DataTable
        Dim ParametroID As Integer = 0
        Dim NombreColumna As String = String.Empty

        Try
            dtParametrosEtiqueta = OBJBU.ConsultarParametrosEtiqueta(EtiquetaId)
            For Each Fila As DataRow In dtParametrosEtiqueta.Rows
                ParametroID = Fila.Item(0)
                NombreColumna = ObtenerNombreColumnaOcultar(ParametroID)
                If NombreColumna <> String.Empty Then
                    viewgrdDetallesEtiquetas.Columns.ColumnByFieldName(NombreColumna).Visible = True
                End If
            Next
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Function ObtenerNombreColumnaOcultar(ByVal ParametroID As Integer) As String
        Dim NombreColumna As String = String.Empty
        Try
            If ParametroID = 1 Then
                NombreColumna = "lote"
            ElseIf ParametroID = 2 Then
                NombreColumna = "atado"
            ElseIf ParametroID = 3 Then
                NombreColumna = "par"
            ElseIf ParametroID = 4 Then
                NombreColumna = "codigocliente"
            ElseIf ParametroID = 5 Then
                NombreColumna = "talla"
            ElseIf ParametroID = 6 Then
                NombreColumna = "marca"
            ElseIf ParametroID = 7 Then
                NombreColumna = "coleccion"
            ElseIf ParametroID = 8 Then
                NombreColumna = "modelo"
            ElseIf ParametroID = 9 Then
                NombreColumna = "piel"
            ElseIf ParametroID = 10 Then
                NombreColumna = "color"
            ElseIf ParametroID = 11 Then
                NombreColumna = "numAtado"
            ElseIf ParametroID = 12 Then
                NombreColumna = "graficoModelo"
            ElseIf ParametroID = 13 Then
                NombreColumna = "nave"
            ElseIf ParametroID = 14 Then
                NombreColumna = "programa"
            ElseIf ParametroID = 15 Then
                NombreColumna = "corrida"
            ElseIf ParametroID = 16 Then
                NombreColumna = "cliente"
            ElseIf ParametroID = 17 Then
                NombreColumna = "pedido"
            ElseIf ParametroID = 18 Then
                NombreColumna = "pedidoCliente"
            ElseIf ParametroID = 19 Then
                NombreColumna = "parespedido"
            ElseIf ParametroID = 20 Then
                NombreColumna = "fechaEntrega"
            ElseIf ParametroID = 21 Then
                NombreColumna = "agenteIniciales"
            ElseIf ParametroID = 22 Then
                NombreColumna = "tienda"
            ElseIf ParametroID = 23 Then
                NombreColumna = "paresAtado"
            ElseIf ParametroID = 24 Then
                NombreColumna = "atadosLote"
            ElseIf ParametroID = 25 Then
                NombreColumna = ""
            ElseIf ParametroID = 26 Then
                NombreColumna = ""
            ElseIf ParametroID = 27 Then
                NombreColumna = ""
            ElseIf ParametroID = 28 Then
                NombreColumna = ""
            ElseIf ParametroID = 29 Then
                NombreColumna = "FechaCapturaPedido"
            ElseIf ParametroID = 30 Then
                NombreColumna = "Familia"
            ElseIf ParametroID = 31 Then
                NombreColumna = "ClienteITEM"
            ElseIf ParametroID = 32 Then
                NombreColumna = "CodigoTienda"
            ElseIf ParametroID = 33 Then
                NombreColumna = ""
            ElseIf ParametroID = 34 Then
                NombreColumna = ""
            ElseIf ParametroID = 35 Then
                NombreColumna = ""
            ElseIf ParametroID = 36 Then
                NombreColumna = ""
            ElseIf ParametroID = 37 Then
                NombreColumna = ""
            ElseIf ParametroID = 38 Then
                NombreColumna = ""
            ElseIf ParametroID = 39 Then
                NombreColumna = ""
            ElseIf ParametroID = 40 Then
                NombreColumna = "ModeloCliente"
            ElseIf ParametroID = 41 Then
                NombreColumna = "colorCliente"
            ElseIf ParametroID = 42 Then
                NombreColumna = "FamiliaCliente"
            ElseIf ParametroID = 43 Then
                NombreColumna = "Corte"
            ElseIf ParametroID = 44 Then
                NombreColumna = "Forro"
            ElseIf ParametroID = 45 Then
                NombreColumna = "Suela"
            ElseIf ParametroID = 46 Then
                NombreColumna = "CodRapido"
            ElseIf ParametroID = 47 Then
                NombreColumna = "CodigoAmece"
            ElseIf ParametroID = 48 Then
                NombreColumna = ""
            ElseIf ParametroID = 49 Then
                NombreColumna = ""
            ElseIf ParametroID = 50 Then
                NombreColumna = ""
            ElseIf ParametroID = 51 Then
                NombreColumna = ""
            ElseIf ParametroID = 52 Then
                NombreColumna = ""
            ElseIf ParametroID = 53 Then
                NombreColumna = ""
            ElseIf ParametroID = 54 Then
                NombreColumna = ""
            ElseIf ParametroID = 55 Then
                NombreColumna = ""
            ElseIf ParametroID = 56 Then
                NombreColumna = ""
            ElseIf ParametroID = 57 Then                           
                NombreColumna = "MarcaCliente"
            ElseIf ParametroID = 58 Then
                NombreColumna = "NaveSICYID"
            ElseIf ParametroID = 59 Then
                NombreColumna = ""
            ElseIf ParametroID = 60 Then
                NombreColumna = ""
            ElseIf ParametroID = 61 Then
                NombreColumna = ""
            ElseIf ParametroID = 62 Then
                NombreColumna = ""
            ElseIf ParametroID = 63 Then
                NombreColumna = ""
            ElseIf ParametroID = 64 Then
                NombreColumna = "TipoFleje"
            ElseIf ParametroID = 65 Then
                NombreColumna = "TipoEmpaque"
            ElseIf ParametroID = 66 Then
                NombreColumna = "ColorTresLetras"
            ElseIf ParametroID = 67 Then
                NombreColumna = ""
            ElseIf ParametroID = 68 Then
                NombreColumna = ""
            ElseIf ParametroID = 69 Then
                NombreColumna = ""
            ElseIf ParametroID = 70 Then
                NombreColumna = "Annotacion"
            ElseIf ParametroID = 71 Then
                NombreColumna = ""
            ElseIf ParametroID = 72 Then
                NombreColumna = "InicialNave"
            ElseIf ParametroID = 73 Then
                NombreColumna = "NumeroSemanaProgramacion"
            ElseIf ParametroID = 74 Then
                NombreColumna = "NumeroProveedor"
            ElseIf ParametroID = 75 Then
                NombreColumna = "ColeccionCliente"
            ElseIf ParametroID = 76 Then
                NombreColumna = "EstiloCliente6Caracteres"
            ElseIf ParametroID = 77 Then
                NombreColumna = "FechaProgramaFormatoEUA"
            End If

        Catch ex As Exception
            Throw ex
        End Try
        

        Return NombreColumna
    End Function


    Private Sub DiseñoGrid(ByVal grid As DevExpress.XtraGrid.Views.Grid.GridView)
        grid.OptionsView.ColumnAutoWidth = False        
        grid.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True

        For Each col As DevExpress.XtraGrid.Columns.GridColumn In grid.Columns
            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Next

        Tools.DiseñoGrid.AlternarColorEnFilas(grid)

        With grid
            .Columns.ColumnByFieldName("IdCadena").Visible = False
            .Columns.ColumnByFieldName("atado").Visible = False
            .Columns.ColumnByFieldName("par").Visible = False
            .Columns.ColumnByFieldName("lote").Visible = False
            .Columns.ColumnByFieldName("codigoEtiqueta").Visible = False
            .Columns.ColumnByFieldName("codigocliente").Visible = False
            .Columns.ColumnByFieldName("talla").Visible = False
            .Columns.ColumnByFieldName("marca").Visible = False
            .Columns.ColumnByFieldName("coleccion").Visible = False
            .Columns.ColumnByFieldName("modelo").Visible = False
            .Columns.ColumnByFieldName("piel").Visible = False
            .Columns.ColumnByFieldName("color").Visible = False
            .Columns.ColumnByFieldName("numAtado").Visible = False
            .Columns.ColumnByFieldName("graficoModelo").Visible = False
            .Columns.ColumnByFieldName("nave").Visible = False
            .Columns.ColumnByFieldName("programa").Visible = False
            .Columns.ColumnByFieldName("corrida").Visible = False
            .Columns.ColumnByFieldName("cliente").Visible = False
            .Columns.ColumnByFieldName("FechaImpresion").Visible = False
            .Columns.ColumnByFieldName("pedido").Visible = False
            .Columns.ColumnByFieldName("pedidoCliente").Visible = False
            .Columns.ColumnByFieldName("parespedido").Visible = False
            .Columns.ColumnByFieldName("fechaEntrega").Visible = False
            .Columns.ColumnByFieldName("agenteIniciales").Visible = False
            .Columns.ColumnByFieldName("tienda").Visible = False
            .Columns.ColumnByFieldName("paresAtado").Visible = False
            .Columns.ColumnByFieldName("atadosLote").Visible = False
            .Columns.ColumnByFieldName("FechaProgramaLoteFormato").Visible = False
            .Columns.ColumnByFieldName("FechaProgramaSinFormato").Visible = False
            .Columns.ColumnByFieldName("FechaEntregaSinFormato").Visible = False
            .Columns.ColumnByFieldName("EtiquetaYuyin").Visible = False
            .Columns.ColumnByFieldName("CodigoTienda").Visible = False
            .Columns.ColumnByFieldName("Familia").Visible = False
            .Columns.ColumnByFieldName("FechaCapturaPedido").Visible = False
            .Columns.ColumnByFieldName("ClienteITEM").Visible = False
            .Columns.ColumnByFieldName("CodRapido").Visible = False
            .Columns.ColumnByFieldName("partida").Visible = False
            .Columns.ColumnByFieldName("codigozpl300").Visible = False
            .Columns.ColumnByFieldName("EtiquetaActiva").Visible = False
            .Columns.ColumnByFieldName("ImpresionAlPaso").Visible = False
            .Columns.ColumnByFieldName("ImprimeYuyin").Visible = False
            .Columns.ColumnByFieldName("ClienteEtiquetaEspecialID").Visible = False
            .Columns.ColumnByFieldName("EtiquetaID").Visible = False
            .Columns.ColumnByFieldName("FormatoFechaProgramaCorta").Visible = False
            .Columns.ColumnByFieldName("colorCliente").Visible = False
            .Columns.ColumnByFieldName("FamiliaCliente").Visible = False
            .Columns.ColumnByFieldName("CodigoAmece").Visible = False
            .Columns.ColumnByFieldName("Corte").Visible = False
            .Columns.ColumnByFieldName("Forro").Visible = False
            .Columns.ColumnByFieldName("Suela").Visible = False
            .Columns.ColumnByFieldName("RequiereEtiquetaParCliente").Visible = False
            .Columns.ColumnByFieldName("RequiereEtiquetaAmarreCliente").Visible = False
            .Columns.ColumnByFieldName("MarcaCliente").Visible = False
            .Columns.ColumnByFieldName("NaveSICYID").Visible = False
            .Columns.ColumnByFieldName("ParesLote").Visible = False
            .Columns.ColumnByFieldName("UsuarioImprimio").Visible = False
            .Columns.ColumnByFieldName("FechaImpresion").Visible = False
            .Columns.ColumnByFieldName("HoraImpresion").Visible = False
            .Columns.ColumnByFieldName("TipoFleje").Visible = False
            .Columns.ColumnByFieldName("TipoEmpaque").Visible = False
            .Columns.ColumnByFieldName("ColorTresLetras").Visible = False
            .Columns.ColumnByFieldName("RutaLogo203").Visible = False
            .Columns.ColumnByFieldName("RutaLogo300").Visible = False
            .Columns.ColumnByFieldName("Annotacion").Visible = False
            .Columns.ColumnByFieldName("Calce").Visible = False
            .Columns.ColumnByFieldName("IdTallaSICY").Visible = False
            .Columns.ColumnByFieldName("IdCodigo").Visible = False
            .Columns.ColumnByFieldName("ModeloCliente").Visible = False
            .Columns.ColumnByFieldName("NumeroProveedor").Visible = False
            .Columns.ColumnByFieldName("ColeccionCliente").Visible = False
            .Columns.ColumnByFieldName("EstiloCliente6Caracteres").Visible = False
            .Columns.ColumnByFieldName("FechaProgramaFormatoEUA").Visible = False
            .Columns.ColumnByFieldName("NumeroSemanaProgramacion").Visible = False
            .Columns.ColumnByFieldName("InicialNave").Visible = False

            
            .Columns.ColumnByFieldName("IdCadena").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
            .Columns.ColumnByFieldName("atado").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
            .Columns.ColumnByFieldName("par").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
            .Columns.ColumnByFieldName("lote").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
            .Columns.ColumnByFieldName("codigoEtiqueta").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
            .Columns.ColumnByFieldName("codigocliente").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
            .Columns.ColumnByFieldName("talla").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
            .Columns.ColumnByFieldName("marca").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
            .Columns.ColumnByFieldName("coleccion").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
            .Columns.ColumnByFieldName("modelo").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
            .Columns.ColumnByFieldName("piel").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
            .Columns.ColumnByFieldName("color").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
            .Columns.ColumnByFieldName("numAtado").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
            .Columns.ColumnByFieldName("graficoModelo").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
            .Columns.ColumnByFieldName("nave").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
            .Columns.ColumnByFieldName("programa").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
            .Columns.ColumnByFieldName("corrida").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
            .Columns.ColumnByFieldName("cliente").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
            .Columns.ColumnByFieldName("FechaImpresion").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
            .Columns.ColumnByFieldName("pedido").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
            .Columns.ColumnByFieldName("pedidoCliente").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
            .Columns.ColumnByFieldName("parespedido").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
            .Columns.ColumnByFieldName("fechaEntrega").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
            .Columns.ColumnByFieldName("agenteIniciales").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
            .Columns.ColumnByFieldName("tienda").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
            .Columns.ColumnByFieldName("paresAtado").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
            .Columns.ColumnByFieldName("atadosLote").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
            .Columns.ColumnByFieldName("FechaProgramaLoteFormato").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
            .Columns.ColumnByFieldName("FechaProgramaSinFormato").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
            .Columns.ColumnByFieldName("FechaEntregaSinFormato").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
            .Columns.ColumnByFieldName("EtiquetaYuyin").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
            .Columns.ColumnByFieldName("CodigoTienda").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
            .Columns.ColumnByFieldName("Familia").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
            .Columns.ColumnByFieldName("FechaCapturaPedido").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
            .Columns.ColumnByFieldName("ClienteITEM").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
            .Columns.ColumnByFieldName("CodRapido").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
            .Columns.ColumnByFieldName("partida").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
            .Columns.ColumnByFieldName("codigozpl300").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
            .Columns.ColumnByFieldName("EtiquetaActiva").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
            .Columns.ColumnByFieldName("ImpresionAlPaso").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
            .Columns.ColumnByFieldName("ImprimeYuyin").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
            .Columns.ColumnByFieldName("ClienteEtiquetaEspecialID").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
            .Columns.ColumnByFieldName("EtiquetaID").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
            .Columns.ColumnByFieldName("FormatoFechaProgramaCorta").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
            .Columns.ColumnByFieldName("colorCliente").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
            .Columns.ColumnByFieldName("FamiliaCliente").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
            .Columns.ColumnByFieldName("CodigoAmece").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
            .Columns.ColumnByFieldName("Corte").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
            .Columns.ColumnByFieldName("Forro").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
            .Columns.ColumnByFieldName("Suela").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
            .Columns.ColumnByFieldName("RequiereEtiquetaParCliente").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
            .Columns.ColumnByFieldName("RequiereEtiquetaAmarreCliente").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
            .Columns.ColumnByFieldName("MarcaCliente").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
            .Columns.ColumnByFieldName("NaveSICYID").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
            .Columns.ColumnByFieldName("ParesLote").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
            .Columns.ColumnByFieldName("UsuarioImprimio").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
            .Columns.ColumnByFieldName("FechaImpresion").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
            .Columns.ColumnByFieldName("HoraImpresion").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
            .Columns.ColumnByFieldName("TipoFleje").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
            .Columns.ColumnByFieldName("TipoEmpaque").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
            .Columns.ColumnByFieldName("ColorTresLetras").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
            .Columns.ColumnByFieldName("RutaLogo203").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
            .Columns.ColumnByFieldName("RutaLogo300").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
            .Columns.ColumnByFieldName("Annotacion").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
            .Columns.ColumnByFieldName("Calce").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
            .Columns.ColumnByFieldName("IdTallaSICY").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
            .Columns.ColumnByFieldName("IdCodigo").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
            .Columns.ColumnByFieldName("ModeloCliente").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
            .Columns.ColumnByFieldName("NumeroProveedor").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
            .Columns.ColumnByFieldName("ColeccionCliente").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
            .Columns.ColumnByFieldName("EstiloCliente6Caracteres").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
            .Columns.ColumnByFieldName("FechaProgramaFormatoEUA").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
            .Columns.ColumnByFieldName("NumeroSemanaProgramacion").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
            .Columns.ColumnByFieldName("InicialNave").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains

            '.Columns.ColumnByFieldName("TotalPares").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            '.Columns.ColumnByFieldName("TotalLotes").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            '.Columns.ColumnByFieldName("pares").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric

            .Columns.ColumnByFieldName("IdCadena").OptionsColumn.AllowSize = True
            .Columns.ColumnByFieldName("atado").OptionsColumn.AllowSize = True
            .Columns.ColumnByFieldName("par").OptionsColumn.AllowSize = True
            .Columns.ColumnByFieldName("lote").OptionsColumn.AllowSize = True
            .Columns.ColumnByFieldName("codigoEtiqueta").OptionsColumn.AllowSize = True
            .Columns.ColumnByFieldName("codigocliente").OptionsColumn.AllowSize = True
            .Columns.ColumnByFieldName("talla").OptionsColumn.AllowSize = True
            .Columns.ColumnByFieldName("marca").OptionsColumn.AllowSize = True
            .Columns.ColumnByFieldName("coleccion").OptionsColumn.AllowSize = True
            .Columns.ColumnByFieldName("modelo").OptionsColumn.AllowSize = True
            .Columns.ColumnByFieldName("piel").OptionsColumn.AllowSize = True
            .Columns.ColumnByFieldName("color").OptionsColumn.AllowSize = True
            .Columns.ColumnByFieldName("numAtado").OptionsColumn.AllowSize = True
            .Columns.ColumnByFieldName("graficoModelo").OptionsColumn.AllowSize = True
            .Columns.ColumnByFieldName("nave").OptionsColumn.AllowSize = True
            .Columns.ColumnByFieldName("programa").OptionsColumn.AllowSize = True
            .Columns.ColumnByFieldName("corrida").OptionsColumn.AllowSize = True
            .Columns.ColumnByFieldName("cliente").OptionsColumn.AllowSize = True
            .Columns.ColumnByFieldName("FechaImpresion").OptionsColumn.AllowSize = True
            .Columns.ColumnByFieldName("pedido").OptionsColumn.AllowSize = True
            .Columns.ColumnByFieldName("pedidoCliente").OptionsColumn.AllowSize = True
            .Columns.ColumnByFieldName("parespedido").OptionsColumn.AllowSize = True
            .Columns.ColumnByFieldName("fechaEntrega").OptionsColumn.AllowSize = True
            .Columns.ColumnByFieldName("agenteIniciales").OptionsColumn.AllowSize = True
            .Columns.ColumnByFieldName("tienda").OptionsColumn.AllowSize = True
            .Columns.ColumnByFieldName("paresAtado").OptionsColumn.AllowSize = True
            .Columns.ColumnByFieldName("atadosLote").OptionsColumn.AllowSize = True
            .Columns.ColumnByFieldName("FechaProgramaLoteFormato").OptionsColumn.AllowSize = True
            .Columns.ColumnByFieldName("FechaProgramaSinFormato").OptionsColumn.AllowSize = True
            .Columns.ColumnByFieldName("FechaEntregaSinFormato").OptionsColumn.AllowSize = True
            .Columns.ColumnByFieldName("EtiquetaYuyin").OptionsColumn.AllowSize = True
            .Columns.ColumnByFieldName("CodigoTienda").OptionsColumn.AllowSize = True
            .Columns.ColumnByFieldName("Familia").OptionsColumn.AllowSize = True
            .Columns.ColumnByFieldName("FechaCapturaPedido").OptionsColumn.AllowSize = True
            .Columns.ColumnByFieldName("ClienteITEM").OptionsColumn.AllowSize = True
            .Columns.ColumnByFieldName("CodRapido").OptionsColumn.AllowSize = True
            .Columns.ColumnByFieldName("partida").OptionsColumn.AllowSize = True
            .Columns.ColumnByFieldName("codigozpl300").OptionsColumn.AllowSize = True
            .Columns.ColumnByFieldName("EtiquetaActiva").OptionsColumn.AllowSize = True
            .Columns.ColumnByFieldName("ImpresionAlPaso").OptionsColumn.AllowSize = True
            .Columns.ColumnByFieldName("ImprimeYuyin").OptionsColumn.AllowSize = True
            .Columns.ColumnByFieldName("ClienteEtiquetaEspecialID").OptionsColumn.AllowSize = True
            .Columns.ColumnByFieldName("EtiquetaID").OptionsColumn.AllowSize = True
            .Columns.ColumnByFieldName("FormatoFechaProgramaCorta").OptionsColumn.AllowSize = True
            .Columns.ColumnByFieldName("colorCliente").OptionsColumn.AllowSize = True
            .Columns.ColumnByFieldName("FamiliaCliente").OptionsColumn.AllowSize = True
            .Columns.ColumnByFieldName("CodigoAmece").OptionsColumn.AllowSize = True
            .Columns.ColumnByFieldName("Corte").OptionsColumn.AllowSize = True
            .Columns.ColumnByFieldName("Forro").OptionsColumn.AllowSize = True
            .Columns.ColumnByFieldName("Suela").OptionsColumn.AllowSize = True
            .Columns.ColumnByFieldName("RequiereEtiquetaParCliente").OptionsColumn.AllowSize = True
            .Columns.ColumnByFieldName("RequiereEtiquetaAmarreCliente").OptionsColumn.AllowSize = True
            .Columns.ColumnByFieldName("MarcaCliente").OptionsColumn.AllowSize = True
            .Columns.ColumnByFieldName("NaveSICYID").OptionsColumn.AllowSize = True
            .Columns.ColumnByFieldName("ParesLote").OptionsColumn.AllowSize = True
            .Columns.ColumnByFieldName("UsuarioImprimio").OptionsColumn.AllowSize = True
            .Columns.ColumnByFieldName("FechaImpresion").OptionsColumn.AllowSize = True
            .Columns.ColumnByFieldName("HoraImpresion").OptionsColumn.AllowSize = True
            .Columns.ColumnByFieldName("TipoFleje").OptionsColumn.AllowSize = True
            .Columns.ColumnByFieldName("TipoEmpaque").OptionsColumn.AllowSize = True
            .Columns.ColumnByFieldName("ColorTresLetras").OptionsColumn.AllowSize = True
            .Columns.ColumnByFieldName("RutaLogo203").OptionsColumn.AllowSize = True
            .Columns.ColumnByFieldName("RutaLogo300").OptionsColumn.AllowSize = True
            .Columns.ColumnByFieldName("Annotacion").OptionsColumn.AllowSize = True
            .Columns.ColumnByFieldName("Calce").OptionsColumn.AllowSize = True
            .Columns.ColumnByFieldName("IdTallaSICY").OptionsColumn.AllowSize = True
            .Columns.ColumnByFieldName("IdCodigo").OptionsColumn.AllowSize = True
            .Columns.ColumnByFieldName("ModeloCliente").OptionsColumn.AllowSize = True
            .Columns.ColumnByFieldName("NumeroProveedor").OptionsColumn.AllowSize = True
            .Columns.ColumnByFieldName("ColeccionCliente").OptionsColumn.AllowSize = True
            .Columns.ColumnByFieldName("EstiloCliente6Caracteres").OptionsColumn.AllowSize = True
            .Columns.ColumnByFieldName("FechaProgramaFormatoEUA").OptionsColumn.AllowSize = True
            .Columns.ColumnByFieldName("NumeroSemanaProgramacion").OptionsColumn.AllowSize = True
            .Columns.ColumnByFieldName("InicialNave").OptionsColumn.AllowSize = True
            '.Columns.ColumnByFieldName("nave").OptionsColumn.AllowSize = True
            '.Columns.ColumnByFieldName("IdModelo").OptionsColumn.AllowSize = True
            '.Columns.ColumnByFieldName("IdCodigo").OptionsColumn.AllowSize = True
            '.Columns.ColumnByFieldName("Coleccion").OptionsColumn.AllowSize = True
            '.Columns.ColumnByFieldName("talla").OptionsColumn.AllowSize = True
            '.Columns.ColumnByFieldName("cortador").OptionsColumn.AllowSize = True
            '.Columns.ColumnByFieldName("Cliente_texto").OptionsColumn.AllowSize = True
            '.Columns.ColumnByFieldName("cliente_Nombre").OptionsColumn.AllowSize = True
            '.Columns.ColumnByFieldName("Usuario").OptionsColumn.AllowSize = True
            '.Columns.ColumnByFieldName("FechaImpresion").OptionsColumn.AllowSize = True
            '.Columns.ColumnByFieldName("NumeroImpresiones").OptionsColumn.AllowSize = True


            .Columns.ColumnByFieldName("IdCadena").OptionsColumn.AllowEdit = False
            .Columns.ColumnByFieldName("atado").OptionsColumn.AllowEdit = False
            .Columns.ColumnByFieldName("par").OptionsColumn.AllowEdit = False
            .Columns.ColumnByFieldName("lote").OptionsColumn.AllowEdit = False
            .Columns.ColumnByFieldName("codigoEtiqueta").OptionsColumn.AllowEdit = False
            .Columns.ColumnByFieldName("codigocliente").OptionsColumn.AllowEdit = False
            .Columns.ColumnByFieldName("talla").OptionsColumn.AllowEdit = False
            .Columns.ColumnByFieldName("marca").OptionsColumn.AllowEdit = False
            .Columns.ColumnByFieldName("coleccion").OptionsColumn.AllowEdit = False
            .Columns.ColumnByFieldName("modelo").OptionsColumn.AllowEdit = False
            .Columns.ColumnByFieldName("piel").OptionsColumn.AllowEdit = False
            .Columns.ColumnByFieldName("color").OptionsColumn.AllowEdit = False
            .Columns.ColumnByFieldName("numAtado").OptionsColumn.AllowEdit = False
            .Columns.ColumnByFieldName("graficoModelo").OptionsColumn.AllowEdit = False
            .Columns.ColumnByFieldName("nave").OptionsColumn.AllowEdit = False
            .Columns.ColumnByFieldName("programa").OptionsColumn.AllowEdit = False
            .Columns.ColumnByFieldName("corrida").OptionsColumn.AllowEdit = False
            .Columns.ColumnByFieldName("cliente").OptionsColumn.AllowEdit = False
            .Columns.ColumnByFieldName("FechaImpresion").OptionsColumn.AllowEdit = False
            .Columns.ColumnByFieldName("pedido").OptionsColumn.AllowEdit = False
            .Columns.ColumnByFieldName("pedidoCliente").OptionsColumn.AllowEdit = False
            .Columns.ColumnByFieldName("parespedido").OptionsColumn.AllowEdit = False
            .Columns.ColumnByFieldName("fechaEntrega").OptionsColumn.AllowEdit = False
            .Columns.ColumnByFieldName("agenteIniciales").OptionsColumn.AllowEdit = False
            .Columns.ColumnByFieldName("tienda").OptionsColumn.AllowEdit = False
            .Columns.ColumnByFieldName("paresAtado").OptionsColumn.AllowEdit = False
            .Columns.ColumnByFieldName("atadosLote").OptionsColumn.AllowEdit = False
            .Columns.ColumnByFieldName("FechaProgramaLoteFormato").OptionsColumn.AllowEdit = False
            .Columns.ColumnByFieldName("FechaProgramaSinFormato").OptionsColumn.AllowEdit = False
            .Columns.ColumnByFieldName("FechaEntregaSinFormato").OptionsColumn.AllowEdit = False
            .Columns.ColumnByFieldName("EtiquetaYuyin").OptionsColumn.AllowEdit = False
            .Columns.ColumnByFieldName("CodigoTienda").OptionsColumn.AllowEdit = False
            .Columns.ColumnByFieldName("Familia").OptionsColumn.AllowEdit = False
            .Columns.ColumnByFieldName("FechaCapturaPedido").OptionsColumn.AllowEdit = False
            .Columns.ColumnByFieldName("ClienteITEM").OptionsColumn.AllowEdit = False
            .Columns.ColumnByFieldName("CodRapido").OptionsColumn.AllowEdit = False
            .Columns.ColumnByFieldName("partida").OptionsColumn.AllowEdit = False
            .Columns.ColumnByFieldName("codigozpl300").OptionsColumn.AllowEdit = False
            .Columns.ColumnByFieldName("EtiquetaActiva").OptionsColumn.AllowEdit = False
            .Columns.ColumnByFieldName("ImpresionAlPaso").OptionsColumn.AllowEdit = False
            .Columns.ColumnByFieldName("ImprimeYuyin").OptionsColumn.AllowEdit = False
            .Columns.ColumnByFieldName("ClienteEtiquetaEspecialID").OptionsColumn.AllowEdit = False
            .Columns.ColumnByFieldName("EtiquetaID").OptionsColumn.AllowEdit = False
            .Columns.ColumnByFieldName("FormatoFechaProgramaCorta").OptionsColumn.AllowEdit = False
            .Columns.ColumnByFieldName("colorCliente").OptionsColumn.AllowEdit = False
            .Columns.ColumnByFieldName("FamiliaCliente").OptionsColumn.AllowEdit = False
            .Columns.ColumnByFieldName("CodigoAmece").OptionsColumn.AllowEdit = False
            .Columns.ColumnByFieldName("Corte").OptionsColumn.AllowEdit = False
            .Columns.ColumnByFieldName("Forro").OptionsColumn.AllowEdit = False
            .Columns.ColumnByFieldName("Suela").OptionsColumn.AllowEdit = False
            .Columns.ColumnByFieldName("RequiereEtiquetaParCliente").OptionsColumn.AllowEdit = False
            .Columns.ColumnByFieldName("RequiereEtiquetaAmarreCliente").OptionsColumn.AllowEdit = False
            .Columns.ColumnByFieldName("MarcaCliente").OptionsColumn.AllowEdit = False
            .Columns.ColumnByFieldName("NaveSICYID").OptionsColumn.AllowEdit = False
            .Columns.ColumnByFieldName("ParesLote").OptionsColumn.AllowEdit = False
            .Columns.ColumnByFieldName("UsuarioImprimio").OptionsColumn.AllowEdit = False
            .Columns.ColumnByFieldName("FechaImpresion").OptionsColumn.AllowEdit = False
            .Columns.ColumnByFieldName("HoraImpresion").OptionsColumn.AllowEdit = False
            .Columns.ColumnByFieldName("TipoFleje").OptionsColumn.AllowEdit = False
            .Columns.ColumnByFieldName("TipoEmpaque").OptionsColumn.AllowEdit = False
            .Columns.ColumnByFieldName("ColorTresLetras").OptionsColumn.AllowEdit = False
            .Columns.ColumnByFieldName("RutaLogo203").OptionsColumn.AllowEdit = False
            .Columns.ColumnByFieldName("RutaLogo300").OptionsColumn.AllowEdit = False
            .Columns.ColumnByFieldName("Annotacion").OptionsColumn.AllowEdit = False
            .Columns.ColumnByFieldName("Calce").OptionsColumn.AllowEdit = False
            .Columns.ColumnByFieldName("IdTallaSICY").OptionsColumn.AllowEdit = False
            .Columns.ColumnByFieldName("IdCodigo").OptionsColumn.AllowEdit = False
            .Columns.ColumnByFieldName("ModeloCliente").OptionsColumn.AllowEdit = False
            .Columns.ColumnByFieldName("NumeroProveedor").OptionsColumn.AllowEdit = False
            .Columns.ColumnByFieldName("ColeccionCliente").OptionsColumn.AllowEdit = False
            .Columns.ColumnByFieldName("EstiloCliente6Caracteres").OptionsColumn.AllowEdit = False
            .Columns.ColumnByFieldName("FechaProgramaFormatoEUA").OptionsColumn.AllowEdit = False
            .Columns.ColumnByFieldName("NumeroSemanaProgramacion").OptionsColumn.AllowEdit = False
            .Columns.ColumnByFieldName("InicialNave").OptionsColumn.AllowEdit = False
            '.Columns.ColumnByFieldName("nave").OptionsColumn.AllowEdit = False
            '.Columns.ColumnByFieldName("IdModelo").OptionsColumn.AllowEdit = False
            '.Columns.ColumnByFieldName("IdCodigo").OptionsColumn.AllowEdit = False
            '.Columns.ColumnByFieldName("Coleccion").OptionsColumn.AllowEdit = False
            '.Columns.ColumnByFieldName("talla").OptionsColumn.AllowEdit = False
            '.Columns.ColumnByFieldName("cortador").OptionsColumn.AllowEdit = False
            '.Columns.ColumnByFieldName("Cliente_texto").OptionsColumn.AllowEdit = False
            '.Columns.ColumnByFieldName("cliente_Nombre").OptionsColumn.AllowEdit = False
            '.Columns.ColumnByFieldName("Usuario").OptionsColumn.AllowEdit = False
            '.Columns.ColumnByFieldName("FechaImpresion").OptionsColumn.AllowEdit = False
            '.Columns.ColumnByFieldName("NumeroImpresiones").OptionsColumn.AllowEdit = False

            .Columns.ColumnByFieldName("IdCadena").Caption = "IdCadena"
            .Columns.ColumnByFieldName("atado").Caption = "atado"
            .Columns.ColumnByFieldName("par").Caption = "par"
            .Columns.ColumnByFieldName("lote").Caption = "lote"
            .Columns.ColumnByFieldName("codigoEtiqueta").Caption = "codigoEtiqueta"
            .Columns.ColumnByFieldName("codigocliente").Caption = "codigocliente"
            .Columns.ColumnByFieldName("talla").Caption = "talla"
            .Columns.ColumnByFieldName("marca").Caption = "marca"
            .Columns.ColumnByFieldName("coleccion").Caption = "coleccion"
            .Columns.ColumnByFieldName("modelo").Caption = "modelo"
            .Columns.ColumnByFieldName("piel").Caption = "piel"
            .Columns.ColumnByFieldName("color").Caption = "color"
            .Columns.ColumnByFieldName("numAtado").Caption = "numAtado"
            .Columns.ColumnByFieldName("graficoModelo").Caption = "graficoModelo"
            .Columns.ColumnByFieldName("nave").Caption = "nave"
            .Columns.ColumnByFieldName("programa").Caption = "programa"
            .Columns.ColumnByFieldName("corrida").Caption = "corrida"
            .Columns.ColumnByFieldName("cliente").Caption = "cliente"
            .Columns.ColumnByFieldName("FechaImpresion").Caption = "FechaImpresion"
            .Columns.ColumnByFieldName("pedido").Caption = "pedido"
            .Columns.ColumnByFieldName("pedidoCliente").Caption = "pedidoCliente"
            .Columns.ColumnByFieldName("parespedido").Caption = "parespedido"
            .Columns.ColumnByFieldName("fechaEntrega").Caption = "fechaEntrega"
            .Columns.ColumnByFieldName("agenteIniciales").Caption = "agenteIniciales"
            .Columns.ColumnByFieldName("tienda").Caption = "tienda"
            .Columns.ColumnByFieldName("paresAtado").Caption = "paresAtado"
            .Columns.ColumnByFieldName("atadosLote").Caption = "atadosLote"
            .Columns.ColumnByFieldName("FechaProgramaLoteFormato").Caption = "FechaProgramaLoteFormato"
            .Columns.ColumnByFieldName("FechaProgramaSinFormato").Caption = "FechaProgramaSinFormato"
            .Columns.ColumnByFieldName("FechaEntregaSinFormato").Caption = "FechaEntregaSinFormato"
            .Columns.ColumnByFieldName("EtiquetaYuyin").Caption = "EtiquetaYuyin"
            .Columns.ColumnByFieldName("CodigoTienda").Caption = "CodigoTienda"
            .Columns.ColumnByFieldName("Familia").Caption = "Familia"
            .Columns.ColumnByFieldName("FechaCapturaPedido").Caption = "FechaCapturaPedido"
            .Columns.ColumnByFieldName("ClienteITEM").Caption = "ClienteITEM"
            .Columns.ColumnByFieldName("CodRapido").Caption = "CodRapido"
            .Columns.ColumnByFieldName("partida").Caption = "partida"
            .Columns.ColumnByFieldName("codigozpl300").Caption = "codigozpl300"
            .Columns.ColumnByFieldName("EtiquetaActiva").Caption = "EtiquetaActiva"
            .Columns.ColumnByFieldName("ImpresionAlPaso").Caption = "ImpresionAlPaso"
            .Columns.ColumnByFieldName("ImprimeYuyin").Caption = "ImprimeYuyin"
            .Columns.ColumnByFieldName("ClienteEtiquetaEspecialID").Caption = "ClienteEtiquetaEspecialID"
            .Columns.ColumnByFieldName("EtiquetaID").Caption = "EtiquetaID"
            .Columns.ColumnByFieldName("FormatoFechaProgramaCorta").Caption = "FormatoFechaProgramaCorta"
            .Columns.ColumnByFieldName("colorCliente").Caption = "colorCliente"
            .Columns.ColumnByFieldName("FamiliaCliente").Caption = "FamiliaCliente"
            .Columns.ColumnByFieldName("CodigoAmece").Caption = "CodigoAmece"
            .Columns.ColumnByFieldName("Corte").Caption = "Corte"
            .Columns.ColumnByFieldName("Forro").Caption = "Forro"
            .Columns.ColumnByFieldName("Suela").Caption = "Suela"
            .Columns.ColumnByFieldName("RequiereEtiquetaParCliente").Caption = "RequiereEtiquetaParCliente"
            .Columns.ColumnByFieldName("RequiereEtiquetaAmarreCliente").Caption = "RequiereEtiquetaAmarreCliente"
            .Columns.ColumnByFieldName("MarcaCliente").Caption = "MarcaCliente"
            .Columns.ColumnByFieldName("NaveSICYID").Caption = "NaveSICYID"
            .Columns.ColumnByFieldName("ParesLote").Caption = "ParesLote"
            .Columns.ColumnByFieldName("UsuarioImprimio").Caption = "UsuarioImprimio"
            .Columns.ColumnByFieldName("FechaImpresion").Caption = "FechaImpresion"
            .Columns.ColumnByFieldName("HoraImpresion").Caption = "HoraImpresion"
            .Columns.ColumnByFieldName("TipoFleje").Caption = "TipoFleje"
            .Columns.ColumnByFieldName("TipoEmpaque").Caption = "TipoEmpaque"
            .Columns.ColumnByFieldName("ColorTresLetras").Caption = "ColorTresLetras"
            .Columns.ColumnByFieldName("RutaLogo203").Caption = "RutaLogo203"
            .Columns.ColumnByFieldName("RutaLogo300").Caption = "RutaLogo300"
            .Columns.ColumnByFieldName("Annotacion").Caption = "Annotacion"
            .Columns.ColumnByFieldName("Calce").Caption = "Calce"
            .Columns.ColumnByFieldName("IdTallaSICY").Caption = "IdTallaSICY"
            .Columns.ColumnByFieldName("IdCodigo").Caption = "IdCodigo"
            .Columns.ColumnByFieldName("ModeloCliente").Caption = "ModeloCliente"
            .Columns.ColumnByFieldName("NumeroProveedor").Caption = "NumeroProveedor"
            .Columns.ColumnByFieldName("ColeccionCliente").Caption = "ColeccionCliente"
            .Columns.ColumnByFieldName("EstiloCliente6Caracteres").Caption = "EstiloCliente6Caracteres"
            .Columns.ColumnByFieldName("FechaProgramaFormatoEUA").Caption = "FechaProgramaFormatoEUA"
            .Columns.ColumnByFieldName("NumeroSemanaProgramacion").Caption = "NumeroSemanaProgramacion"
            .Columns.ColumnByFieldName("InicialNave").Caption = "InicialNave"
            '.Columns.ColumnByFieldName("nave").Caption = "nave"
            '.Columns.ColumnByFieldName("IdModelo").Caption = "IdModelo"
            '.Columns.ColumnByFieldName("IdCodigo").Caption = "IdCodigo"
            '.Columns.ColumnByFieldName("Coleccion").Caption = "Coleccion"
            '.Columns.ColumnByFieldName("talla").Caption = "talla"
            '.Columns.ColumnByFieldName("cortador").Caption = "cortador"
            '.Columns.ColumnByFieldName("Cliente_texto").Caption = "Cliente_texto"
            '.Columns.ColumnByFieldName("cliente_Nombre").Caption = "cliente_Nombre"
            '.Columns.ColumnByFieldName("Usuario").Caption = "Usuario"
            '.Columns.ColumnByFieldName("FechaImpresion").Caption = "FechaImpresion"
            '.Columns.ColumnByFieldName("NumeroImpresiones").Caption = "NumeroImpresiones"

            '.Columns.ColumnByFieldName(" ").Width = 30

            
            '.OptionsView.ShowFooter = GroupFooterShowMode.VisibleAlways


            'If IsNothing(.Columns("TotalPares").Summary.FirstOrDefault(Function(x) x.FieldName = "TotalPares")) = True Then
            '    .Columns("TotalPares").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "TotalPares", "{0:N0}")
            '    Dim item As GridGroupSummaryItem = New GridGroupSummaryItem()
            '    item.FieldName = "TotalPares"
            '    item.SummaryType = DevExpress.Data.SummaryItemType.Sum
            '    item.DisplayFormat = "{0}"
            '    .GroupSummary.Add(item)
            'End If

       

        End With
    End Sub

    Public Sub show_message(ByVal tipo As String, ByVal mensaje As String)

        If tipo.ToString.Equals("Advertencia") Then

            Dim mensajeAdvertencia As New AdvertenciaForm
            mensajeAdvertencia.mensaje = mensaje
            mensajeAdvertencia.ShowDialog()

        End If

        If tipo.ToString.Equals("Aviso") Then

            Dim mensajeAviso As New AvisoForm
            mensajeAviso.mensaje = mensaje
            mensajeAviso.ShowDialog()

        End If

        If tipo.ToString.Equals("Error") Then

            Dim mensajeError As New ErroresForm
            mensajeError.mensaje = mensaje
            mensajeError.ShowDialog()

        End If

        If tipo.ToString.Equals("Exito") Then

            Dim mensajeExito As New ExitoForm
            mensajeExito.mensaje = mensaje
            mensajeExito.ShowDialog()

        End If

        If tipo.ToString.Equals("Confirmar") Then

            Dim mensajeExito As New ConfirmarForm
            mensajeExito.mensaje = mensaje
            mensajeExito.ShowDialog()

        End If

    End Sub





End Class