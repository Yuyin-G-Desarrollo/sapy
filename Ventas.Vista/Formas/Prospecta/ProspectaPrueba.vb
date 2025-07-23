Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win

Public Class ProspectaPrueba

    Dim dtDatosCliente As New DataTable()
    Dim dtDatosPedidos As New DataTable()
    Dim dtDatosPartidas As New DataTable()
    Dim dtResumenDiario As New DataTable()

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        Dim seleccionados As Integer = 0
        pnlFiltros.Height = 24
        spcPedidos.SplitterDistance = 20
        For Each row As UltraGridRow In grdPedidos.Rows
            If row.Cells("_").Value = True Then
                seleccionados += 1
            End If
        Next
        If seleccionados = 0 Then
            sPCParesConfirmar.SplitterDistance = sPCParesConfirmar.Height
        End If
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        Dim seleccionados As Integer = 0
        pnlFiltros.Height = 193
        spcPedidos.SplitterDistance = 20
        For Each row As UltraGridRow In grdPedidos.Rows
            If row.Cells("_").Value = True Then
                seleccionados += 1
            End If
        Next
        If seleccionados = 0 Then
            sPCParesConfirmar.SplitterDistance = sPCParesConfirmar.Height
        End If
    End Sub

    Private Sub ProspectaPrueba_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'dtDatosCliente.Columns.Add("#")
        'dtDatosCliente.Columns.Add("_")
        'dtDatosCliente.Columns.Add("Cliente")
        'dtDatosCliente.Columns.Add("PROSPECTADO")
        'dtDatosCliente.Columns.Add("Editando")
        'dtDatosCliente.Columns.Add("PARTIDASCOMPLETAS")
        'dtDatosCliente.Columns.Add("BLOQUEADOENTREGACOBRANZA")
        'dtDatosCliente.Columns.Add("PLAZOCERO")
        'dtDatosCliente.Columns.Add("COTIZACIONESPAGADAS")
        'dtDatosCliente.Columns.Add("COTIZACIONESPAGOPENDIENTE")
        'dtDatosCliente.Columns.Add("CONFIRMACIONCLIENTE")
        'dtDatosCliente.Columns.Add("DIASPARALAPROXIMAENTREGA")
        'dtDatosCliente.Columns.Add("PENDIENTECONATRASO")
        'dtDatosCliente.Columns.Add("PENDIENTESEMANAPROSPECTA")
        'dtDatosCliente.Columns.Add("PORADELANTAR")
        'dtDatosCliente.Columns.Add("TOTALPARES")
        'dtDatosCliente.Columns.Add("INVENTARIO")
        'dtDatosCliente.Columns.Add("APARTADOPORCONFIRMAR")
        'dtDatosCliente.Columns.Add("PENDIENTECONATRASOACTUAL")
        'dtDatosCliente.Columns.Add("PENDIENTESEMANAPROSPECTAACTUAL")
        'dtDatosCliente.Columns.Add("PORADELANTARACTUAL")
        'dtDatosCliente.Columns.Add("TOTALPARESACTUAL")
        'dtDatosCliente.Columns.Add("INVENTARIOACTUAL")
        'dtDatosCliente.Columns.Add("APARTADOPORCONFIRMARACTUAL")
        'dtDatosCliente.Columns.Add("V_Inv")
        'dtDatosCliente.Columns.Add("S_Inv")
        'dtDatosCliente.Columns.Add("L_Inv")
        'dtDatosCliente.Columns.Add("Ma_Inv")
        'dtDatosCliente.Columns.Add("Mi_Inv")
        'dtDatosCliente.Columns.Add("J_Inv")
        'dtDatosCliente.Columns.Add("L_Ent")
        'dtDatosCliente.Columns.Add("Ma_Ent")
        'dtDatosCliente.Columns.Add("Mi_Ent")
        'dtDatosCliente.Columns.Add("J_Ent")
        'dtDatosCliente.Columns.Add("V_Ent")
        'dtDatosCliente.Columns.Add("S_Ent")
        'dtDatosCliente.Columns.Add("P")
        'dtDatosCliente.Columns.Add("V_Proy")
        'dtDatosCliente.Columns.Add("S_Proy")
        'dtDatosCliente.Columns.Add("L_Proy")
        'dtDatosCliente.Columns.Add("Ma_Proy")
        'dtDatosCliente.Columns.Add("Mi_Proy")
        'dtDatosCliente.Columns.Add("J_Proy")
        'dtDatosCliente.Columns.Add("SUMA")
        'dtDatosCliente.Columns.Add("CANTIDADDEPEDIDOS")
        'dtDatosCliente.Columns.Add("CANTIDADTOTALDEPARTIDAS")
        'dtDatosCliente.Columns.Add("CANTIDADDEPEDIDOSAPROSPECTAR")
        'dtDatosCliente.Columns.Add("CANTIDADDEPARTIDASAPROSPECTAR")
        'dtDatosCliente.Columns.Add("TOTALDEPARESAPROSPECTAR")
        'dtDatosCliente.Columns.Add("USUARIO")
        'dtDatosCliente.Columns.Add("FECHA")
        'dtDatosCliente.Columns.Add("FECHAENTREGA")

        Me.WindowState = FormWindowState.Maximized

        dtDatosCliente.Columns.Add("#")
        dtDatosCliente.Columns.Add("_")
        dtDatosCliente.Columns.Add("Cliente")
        dtDatosCliente.Columns.Add("PROSPECTADO")
        dtDatosCliente.Columns.Add("Editando")
        dtDatosCliente.Columns.Add("PARTIDASCOMPLETAS")
        dtDatosCliente.Columns.Add("BLOQUEADOENTREGACOBRANZA")
        dtDatosCliente.Columns.Add("PLAZOCERO")
        dtDatosCliente.Columns.Add("COTIZACIONES")
        dtDatosCliente.Columns.Add("DIASPARALAPROXIMAENTREGA")
        dtDatosCliente.Columns.Add("FechaEntregaCliente")
        dtDatosCliente.Columns.Add("FechaProgramacion")
        dtDatosCliente.Columns.Add("PENDIENTECONATRASO")
        dtDatosCliente.Columns.Add("PENDIENTESEMANAPROSPECTA")
        dtDatosCliente.Columns.Add("PORADELANTAR")
        dtDatosCliente.Columns.Add("TOTALPARES")
        dtDatosCliente.Columns.Add("INVENTARIO")
        dtDatosCliente.Columns.Add("BLOQUEADOS")
        dtDatosCliente.Columns.Add("REPROCESO")
        dtDatosCliente.Columns.Add("APARTADOPORCONFIRMAR")
        dtDatosCliente.Columns.Add("V_Inv")
        dtDatosCliente.Columns.Add("S_Inv")
        dtDatosCliente.Columns.Add("L_Inv")
        dtDatosCliente.Columns.Add("Ma_Inv")
        dtDatosCliente.Columns.Add("Mi_Inv")
        dtDatosCliente.Columns.Add("J_Inv")
        dtDatosCliente.Columns.Add("SUMA")
        dtDatosCliente.Columns.Add("Sumaalmomentodeguardar")
        dtDatosCliente.Columns.Add("L_Ent")
        dtDatosCliente.Columns.Add("Ma_Ent")
        dtDatosCliente.Columns.Add("Mi_Ent")
        dtDatosCliente.Columns.Add("J_Ent")
        dtDatosCliente.Columns.Add("V_Ent")
        dtDatosCliente.Columns.Add("S_Ent")
        dtDatosCliente.Columns.Add("P")
        dtDatosCliente.Columns.Add("V_Proy")
        dtDatosCliente.Columns.Add("S_Proy")
        dtDatosCliente.Columns.Add("L_Proy")
        dtDatosCliente.Columns.Add("Ma_Proy")
        dtDatosCliente.Columns.Add("Mi_Proy")
        dtDatosCliente.Columns.Add("J_Proy")
        dtDatosCliente.Columns.Add("CANTIDADDEPEDIDOS")
        dtDatosCliente.Columns.Add("CANTIDADTOTALDEPARTIDAS")
        dtDatosCliente.Columns.Add("CANTIDADDEPEDIDOSAPROSPECTAR")
        dtDatosCliente.Columns.Add("CANTIDADDEPARTIDASAPROSPECTAR")
        dtDatosCliente.Columns.Add("TOTALDEPARESAPROSPECTAR")
        dtDatosCliente.Columns.Add("USUARIO")
        dtDatosCliente.Columns.Add("FECHA")

        dtDatosCliente.Columns("_").DataType = System.Type.GetType("System.Boolean")
        dtDatosCliente.Columns("L_Ent").DataType = System.Type.GetType("System.Boolean")
        dtDatosCliente.Columns("Ma_Ent").DataType = System.Type.GetType("System.Boolean")
        dtDatosCliente.Columns("Mi_Ent").DataType = System.Type.GetType("System.Boolean")
        dtDatosCliente.Columns("J_Ent").DataType = System.Type.GetType("System.Boolean")
        dtDatosCliente.Columns("V_Ent").DataType = System.Type.GetType("System.Boolean")
        dtDatosCliente.Columns("S_Ent").DataType = System.Type.GetType("System.Boolean")

        'dtDatosPedidos.Columns.Add("#")
        'dtDatosPedidos.Columns.Add("_")
        'dtDatosPedidos.Columns.Add("CLIENTE")
        'dtDatosPedidos.Columns.Add("PEDIDOSAY")
        'dtDatosPedidos.Columns.Add("PEDIDOSICY")
        'dtDatosPedidos.Columns.Add("PROSPECTADO")
        'dtDatosPedidos.Columns.Add("STATUS")
        'dtDatosPedidos.Columns.Add("COTIZACIONESPAGADAS")
        'dtDatosPedidos.Columns.Add("COTIZACIONESPAGOPENDIENTE")
        'dtDatosPedidos.Columns.Add("DIASPARALAPROXIMAENTREGA")
        'dtDatosPedidos.Columns.Add("PENDIENTECONATRASO")
        'dtDatosPedidos.Columns.Add("PENDIENTESEMANAPROSPECTA")
        'dtDatosPedidos.Columns.Add("PORADELANTAR")
        'dtDatosPedidos.Columns.Add("TOTALPARES")
        'dtDatosPedidos.Columns.Add("INVENTARIO")
        'dtDatosPedidos.Columns.Add("APARTADOPORCONFIRMAR")
        'dtDatosPedidos.Columns.Add("PENDIENTECONATRASOACTUAL")
        'dtDatosPedidos.Columns.Add("PENDIENTESEMANAPROSPECTAACTUAL")
        'dtDatosPedidos.Columns.Add("PORADELANTARACTUAL")
        'dtDatosPedidos.Columns.Add("TOTALPARESACTUAL")
        'dtDatosPedidos.Columns.Add("INVENTARIOACTUAL")
        'dtDatosPedidos.Columns.Add("APARTADOPORCONFIRMARACTUAL")
        'dtDatosPedidos.Columns.Add("V_Inv")
        'dtDatosPedidos.Columns.Add("S_Inv")
        'dtDatosPedidos.Columns.Add("L_Inv")
        'dtDatosPedidos.Columns.Add("Ma_Inv")
        'dtDatosPedidos.Columns.Add("Mi_Inv")
        'dtDatosPedidos.Columns.Add("J_Inv")
        'dtDatosPedidos.Columns.Add("L_Ent")
        'dtDatosPedidos.Columns.Add("Ma_Ent")
        'dtDatosPedidos.Columns.Add("Mi_Ent")
        'dtDatosPedidos.Columns.Add("J_Ent")
        'dtDatosPedidos.Columns.Add("V_Ent")
        'dtDatosPedidos.Columns.Add("S_Ent")
        'dtDatosPedidos.Columns.Add("P")
        'dtDatosPedidos.Columns.Add("V_Proy")
        'dtDatosPedidos.Columns.Add("S_Proy")
        'dtDatosPedidos.Columns.Add("L_Proy")
        'dtDatosPedidos.Columns.Add("Ma_Proy")
        'dtDatosPedidos.Columns.Add("Mi_Proy")
        'dtDatosPedidos.Columns.Add("J_Proy")
        'dtDatosPedidos.Columns.Add("SUMA")
        'dtDatosPedidos.Columns.Add("CANTIDADTOTALDEPARTIDAS")
        'dtDatosPedidos.Columns.Add("CANTIDADDEPARTIDASAPROSPECTAR")
        'dtDatosPedidos.Columns.Add("TOTALDEPARESAPROSPECTAR")
        'dtDatosPedidos.Columns.Add("USUARIO")
        'dtDatosPedidos.Columns.Add("FECHA")
        'dtDatosPedidos.Columns.Add("FECHAENTREGA")
        'dtDatosPedidos.Columns.Add("BLOQUEADOENTREGACOBRANZA")

        dtDatosPedidos.Columns.Add("#")
        dtDatosPedidos.Columns.Add("_")
        dtDatosPedidos.Columns.Add("Cliente")
        dtDatosPedidos.Columns.Add("PEDIDOSAY")
        dtDatosPedidos.Columns.Add("PEDIDOSICY")
        dtDatosPedidos.Columns.Add("PROSPECTADO")
        dtDatosPedidos.Columns.Add("STATUS")
        dtDatosPedidos.Columns.Add("COTIZACIONES")
        dtDatosPedidos.Columns.Add("DIASPARALAPROXIMAENTREGA")
        dtDatosPedidos.Columns.Add("FechaEntregaCliente")
        dtDatosPedidos.Columns.Add("FechaProgramacion")
        dtDatosPedidos.Columns.Add("PENDIENTECONATRASO")
        dtDatosPedidos.Columns.Add("PENDIENTESEMANAPROSPECTA")
        dtDatosPedidos.Columns.Add("PORADELANTAR")
        dtDatosPedidos.Columns.Add("TOTALPARES")
        dtDatosPedidos.Columns.Add("INVENTARIO")
        dtDatosPedidos.Columns.Add("BLOQUEADOS")
        dtDatosPedidos.Columns.Add("REPROCESO")
        dtDatosPedidos.Columns.Add("APARTADOPORCONFIRMAR")
        dtDatosPedidos.Columns.Add("V_Inv")
        dtDatosPedidos.Columns.Add("S_Inv")
        dtDatosPedidos.Columns.Add("L_Inv")
        dtDatosPedidos.Columns.Add("Ma_Inv")
        dtDatosPedidos.Columns.Add("Mi_Inv")
        dtDatosPedidos.Columns.Add("J_Inv")
        dtDatosPedidos.Columns.Add("SUMA")
        dtDatosPedidos.Columns.Add("Sumaalmomentodeguardar")
        dtDatosPedidos.Columns.Add("L_Ent")
        dtDatosPedidos.Columns.Add("Ma_Ent")
        dtDatosPedidos.Columns.Add("Mi_Ent")
        dtDatosPedidos.Columns.Add("J_Ent")
        dtDatosPedidos.Columns.Add("V_Ent")
        dtDatosPedidos.Columns.Add("S_Ent")
        dtDatosPedidos.Columns.Add("P")
        dtDatosPedidos.Columns.Add("V_Proy")
        dtDatosPedidos.Columns.Add("S_Proy")
        dtDatosPedidos.Columns.Add("L_Proy")
        dtDatosPedidos.Columns.Add("Ma_Proy")
        dtDatosPedidos.Columns.Add("Mi_Proy")
        dtDatosPedidos.Columns.Add("J_Proy")
        dtDatosPedidos.Columns.Add("CANTIDADTOTALDEPARTIDAS")
        dtDatosPedidos.Columns.Add("CANTIDADDEPARTIDASAPROSPECTAR")
        dtDatosPedidos.Columns.Add("TOTALDEPARESAPROSPECTAR")
        dtDatosPedidos.Columns.Add("USUARIO")
        dtDatosPedidos.Columns.Add("FECHA")
        dtDatosPedidos.Columns.Add("BLOQUEADOENTREGACOBRANZA")
        dtDatosPedidos.Columns.Add("ClienteID")
        dtDatosPedidos.Columns.Add("PlazoCeroSinCot")


        dtDatosPedidos.Columns("_").DataType = System.Type.GetType("System.Boolean")
        dtDatosPedidos.Columns("L_Ent").DataType = System.Type.GetType("System.Boolean")
        dtDatosPedidos.Columns("Ma_Ent").DataType = System.Type.GetType("System.Boolean")
        dtDatosPedidos.Columns("Mi_Ent").DataType = System.Type.GetType("System.Boolean")
        dtDatosPedidos.Columns("J_Ent").DataType = System.Type.GetType("System.Boolean")
        dtDatosPedidos.Columns("V_Ent").DataType = System.Type.GetType("System.Boolean")
        dtDatosPedidos.Columns("S_Ent").DataType = System.Type.GetType("System.Boolean")



        'dtDatosPartidas.Columns.Add("#")
        'dtDatosPartidas.Columns.Add("PEDIDO")
        'dtDatosPartidas.Columns.Add("#PARTIDA")
        'dtDatosPartidas.Columns.Add("PROSPECTADO")
        'dtDatosPartidas.Columns.Add("TIENDA/EMBARQUE/CEDIS")
        'dtDatosPartidas.Columns.Add("STATUS")
        'dtDatosPartidas.Columns.Add("ARTICULO")
        'dtDatosPartidas.Columns.Add("TALLA")
        'dtDatosPartidas.Columns.Add("DIASPARALAPROXIMAENTREGA")
        'dtDatosPartidas.Columns.Add("PENDIENTECONATRASO")
        'dtDatosPartidas.Columns.Add("PENDIENTESEMANAPROSPECTA")
        'dtDatosPartidas.Columns.Add("PORADELANTAR")
        'dtDatosPartidas.Columns.Add("TOTALPARES")
        'dtDatosPartidas.Columns.Add("INVENTARIO")
        'dtDatosPartidas.Columns.Add("APARTADOPORCONFIRMAR")
        'dtDatosPartidas.Columns.Add("PENDIENTECONATRASOACTUAL")
        'dtDatosPartidas.Columns.Add("PENDIENTESEMANAPROSPECTAACTUAL")
        'dtDatosPartidas.Columns.Add("PORADELANTARACTUAL")
        'dtDatosPartidas.Columns.Add("TOTALPARESACTUAL")
        'dtDatosPartidas.Columns.Add("INVENTARIOACTUAL")
        'dtDatosPartidas.Columns.Add("APARTADOPORCONFIRMARACTUAL")
        'dtDatosPartidas.Columns.Add("V_Inv")
        'dtDatosPartidas.Columns.Add("S_Inv")
        'dtDatosPartidas.Columns.Add("L_Inv")
        'dtDatosPartidas.Columns.Add("Ma_Inv")
        'dtDatosPartidas.Columns.Add("Mi_Inv")
        'dtDatosPartidas.Columns.Add("J_Inv")
        'dtDatosPartidas.Columns.Add("L_Ent")
        'dtDatosPartidas.Columns.Add("Ma_Ent")
        'dtDatosPartidas.Columns.Add("Mi_Ent")
        'dtDatosPartidas.Columns.Add("J_Ent")
        'dtDatosPartidas.Columns.Add("V_Ent")
        'dtDatosPartidas.Columns.Add("S_Ent")
        'dtDatosPartidas.Columns.Add("P")
        'dtDatosPartidas.Columns.Add("V_Proy")
        'dtDatosPartidas.Columns.Add("S_Proy")
        'dtDatosPartidas.Columns.Add("L_Proy")
        'dtDatosPartidas.Columns.Add("Ma_Proy")
        'dtDatosPartidas.Columns.Add("Mi_Proy")
        'dtDatosPartidas.Columns.Add("J_Proy")
        'dtDatosPartidas.Columns.Add("SUMA")
        'dtDatosPartidas.Columns.Add("TOTALDEPARESAPROSPECTAR")
        'dtDatosPartidas.Columns.Add("USUARIO")
        'dtDatosPartidas.Columns.Add("FECHA")
        'dtDatosPartidas.Columns.Add("FECHAENTREGA")
        'dtDatosPartidas.Columns.Add("BLOQUEADOENTREGACOBRANZA")

        dtDatosPartidas.Columns.Add("#")
        dtDatosPartidas.Columns.Add("Cliente")
        dtDatosPartidas.Columns.Add("PedidoSAY")
        dtDatosPartidas.Columns.Add("#PARTIDA")
        dtDatosPartidas.Columns.Add("PROSPECTADO")
        dtDatosPartidas.Columns.Add("STATUS")
        dtDatosPartidas.Columns.Add("ARTICULO")
        dtDatosPartidas.Columns.Add("Corrida")
        dtDatosPartidas.Columns.Add("DIASPARALAPROXIMAENTREGA")
        dtDatosPartidas.Columns.Add("FECHAENTREGA")
        dtDatosPartidas.Columns.Add("PENDIENTECONATRASO")
        dtDatosPartidas.Columns.Add("PENDIENTESEMANAPROSPECTA")
        dtDatosPartidas.Columns.Add("PORADELANTAR")
        dtDatosPartidas.Columns.Add("TOTALPARES")
        dtDatosPartidas.Columns.Add("INVENTARIO")
        dtDatosPartidas.Columns.Add("BLOQUEADOS")
        dtDatosPartidas.Columns.Add("REPROCESO")
        dtDatosPartidas.Columns.Add("APARTADOPORCONFIRMAR")
        dtDatosPartidas.Columns.Add("V_Inv")
        dtDatosPartidas.Columns.Add("S_Inv")
        dtDatosPartidas.Columns.Add("L_Inv")
        dtDatosPartidas.Columns.Add("Ma_Inv")
        dtDatosPartidas.Columns.Add("Mi_Inv")
        dtDatosPartidas.Columns.Add("J_Inv")
        dtDatosPartidas.Columns.Add("SUMA")
        dtDatosPartidas.Columns.Add("Sumaalmomentodeguardar")
        dtDatosPartidas.Columns.Add("L_Ent")
        dtDatosPartidas.Columns.Add("Ma_Ent")
        dtDatosPartidas.Columns.Add("Mi_Ent")
        dtDatosPartidas.Columns.Add("J_Ent")
        dtDatosPartidas.Columns.Add("V_Ent")
        dtDatosPartidas.Columns.Add("S_Ent")
        dtDatosPartidas.Columns.Add("P")
        dtDatosPartidas.Columns.Add("V_Proy")
        dtDatosPartidas.Columns.Add("S_Proy")
        dtDatosPartidas.Columns.Add("L_Proy")
        dtDatosPartidas.Columns.Add("Ma_Proy")
        dtDatosPartidas.Columns.Add("Mi_Proy")
        dtDatosPartidas.Columns.Add("J_Proy")
        dtDatosPartidas.Columns.Add("TOTALDEPARESAPROSPECTAR")
        dtDatosPartidas.Columns.Add("USUARIO")
        dtDatosPartidas.Columns.Add("FECHA")
        dtDatosPartidas.Columns.Add("BLOQUEADOENTREGACOBRANZA")
        dtDatosPartidas.Columns.Add("PlazoCeroSinCot")
        dtDatosPartidas.Columns.Add("PartidaIncompleta")


        dtDatosPartidas.Columns("L_Ent").DataType = System.Type.GetType("System.Boolean")
        dtDatosPartidas.Columns("Ma_Ent").DataType = System.Type.GetType("System.Boolean")
        dtDatosPartidas.Columns("Mi_Ent").DataType = System.Type.GetType("System.Boolean")
        dtDatosPartidas.Columns("J_Ent").DataType = System.Type.GetType("System.Boolean")
        dtDatosPartidas.Columns("V_Ent").DataType = System.Type.GetType("System.Boolean")
        dtDatosPartidas.Columns("S_Ent").DataType = System.Type.GetType("System.Boolean")

        dtResumenDiario.Columns.Add("Concepto")
        dtResumenDiario.Columns.Add("L")
        dtResumenDiario.Columns("L").DataType = System.Type.GetType("System.Int32")
        dtResumenDiario.Columns.Add("Ma")
        dtResumenDiario.Columns("Ma").DataType = System.Type.GetType("System.Int32")
        dtResumenDiario.Columns.Add("Mi")
        dtResumenDiario.Columns("Mi").DataType = System.Type.GetType("System.Int32")
        dtResumenDiario.Columns.Add("J")
        dtResumenDiario.Columns("J").DataType = System.Type.GetType("System.Int32")
        dtResumenDiario.Columns.Add("V")
        dtResumenDiario.Columns("V").DataType = System.Type.GetType("System.Int32")
        dtResumenDiario.Columns.Add("S")
        dtResumenDiario.Columns("S").DataType = System.Type.GetType("System.Int32")
        dtResumenDiario.Columns.Add("Total")
        dtResumenDiario.Columns("Total").DataType = System.Type.GetType("System.Int32")


        spcClientes.SplitterDistance = spcClientes.Width - 4
        sPCParesConfirmar.SplitterDistance = sPCParesConfirmar.Height - 4

        spcPedidos.SplitterDistance = 20

    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click

        spcClientes.SplitterDistance = spcClientes.Width - 4
        sPCParesConfirmar.SplitterDistance = sPCParesConfirmar.Height

        spcPedidos.SplitterDistance = 20
        'dtDatosCliente.Rows.Add("1", 0, "FERNANDO HUERTA ARRONIZ", "NO", "", "SI", "NO", "NO", "", "", 1, 596, "", "597", "596", "", "", "", "", "", "", "", "", "", "", "", "", "", "", 0, 1, 0, 0, 0, 0, "", "", "596", "", "", "", "", "596", "1", "11", "1", "11", "596", "FATIMAS", "10/11/2016", "11/11/2016")
        'dtDatosCliente.Rows.Add("2", 0, "ALMACENES LA ORIENTAL", "NO", "", "SI", "SI", "SI", "0", "2", -130, "", "", "", "", "", "", "92", "92", "", "92", "76", "", "", "", "", "", "", "", 0, 0, 0, 0, 0, 0, "", "", "", "", "", "", "", "0", "", "", "", "", "0", "", "", "03/07/2016")
        'dtDatosCliente.Rows.Add("3", 0, "ORGANIZACIÓN SANTILLANA", "NO", "", "SI", "NO", "NO", "", "", 1, "", "", "", "", "", "", "", "442", "", "442", "180", "", "", "", "", "87", "90", "85", 0, 0, 0, 1, 1, 1, "", "", "", "", "53", "270", "119", "442", "31", "31", "31", "31", "442", "FATIMAS", "10/11/2016", "11/11/2016")
        'dtDatosCliente.Rows.Add("4", 0, "GERARDO CHEVAILE RAMOS", "NO", "", "SI", "NO", "NO", "", "", -34, "", "", "", "", "", "", "175", "63", "", "238", "87", "14", "40", "", "", "", "", "21", 0, 1, 0, 0, 0, 1, "", "", "110", "", "", "", "21", "131", "5", "10", "2", "5", "110", "FATIMAS", "10/11/2016", "07/10/2016")
        'dtDatosCliente.Rows.Add("5", 0, "ECOON ZAPATERIAS (ARELLANO)", "NO", "", "NO", "NO", "NO", "", "", 0, "", "", "", "", "", "", "216", "", "", "216", "72", "4", "", "", "", "24", "", "24", 1, 0, 0, 0, 0, 1, "", "72", "", "", "", "", "52", "124", "1", "7", "1", "7", "124", "FATIMAS", "10/11/2016", "10/11/2016")
        'dtDatosCliente.Rows.Add("6", 0, "ANTONIO DOMINGUEZ ALLON", "NO", "", "SI", "NO", "SI", "", "", 8, "", "", "", "", "", "", "", "298", "", "298", "236", "", "", "", "", "", "", "", 1, 1, 0, 0, 0, 0, "", "100", "136", "", "", "", "", "236", "2", "19", "", "", "236", "FATIMAS", "10/11/2016", "18/11/2016")

        'dtDatosCliente.Rows.Add("1", 0, "FERNANDO HUERTA ARRONIZ", "NO", "", "SI", "NO", "NO", "", "", "", "1", "", "596", "", "596", "596", "", "", "", "", "", "", "", "", "", "", "", "", "", 0, 1, 0, 0, 1, 0, "", "", "229", "", "367", "", "", "596", "1", "11", "1", "11", "596", "FATIMAS", "10/11/2016", "11/11/2016")
        'dtDatosCliente.Rows.Add("2", 0, "ALMACENES LA ORIENTAL", "NO", "", "SI", "SI", "SI", "0", "0", "", "-130", "92", "", "", "92", "76", "", "", "", "", "", "", "", "", "", "", "", "", "", 0, 0, 0, 0, 0, 0, "", "", "", "", "", "", "", "0", "", "", "", "", "0", "", "", "03/07/2016")
        'dtDatosCliente.Rows.Add("3", 0, "ORGANIZACIÓN SANTILLANA", "NO", "", "SI", "NO", "NO", "", "", "", "1", "", "442", "", "442", "180", "", "", "", "", "", "", "", "", "", "", "87", "90", "85", 0, 0, 0, 1, 1, 1, "", "", "", "", "53", "270", "119", "442", "31", "31", "31", "31", "442", "FATIMAS", "10/11/2016", "11/11/2016")
        'dtDatosCliente.Rows.Add("4", 0, "GERARDO CHEVAILE RAMOS", "NO", "cesar", "SI", "NO", "NO", "", "", "", "-34", "175", "63", "", "238", "87", "14", "", "", "", "", "", "", "40", "", "", "", "", "21", 0, 1, 0, 0, 0, 1, "", "", "110", "", "", "", "21", "131", "5", "10", "2", "5", "110", "FATIMAS", "10/11/2016", "07/10/2016")
        'dtDatosCliente.Rows.Add("5", 0, "ECOON ZAPATERIAS (ARELLANO)", "NO", "", "NO", "NO", "NO", "", "", "", "-20", "216", "", "", "216", "72", "4", "", "", "", "", "", "", "", "", "", "24", "", "24", 1, 0, 0, 0, 0, 1, "", "72", "", "", "", "", "52", "124", "1", "7", "1", "7", "124", "FATIMAS", "10/11/2016", "21/10/2016")
        'dtDatosCliente.Rows.Add("6", 0, "ANTONIO DOMINGUEZ ALLON", "NO", "", "SI", "NO", "SI", "0", "0", "", "-55", "", "298", "", "298", "236", "", "", "", "", "", "", "", "", "", "", "", "", "", 1, 1, 0, 0, 0, 0, "", "100", "136", "", "", "", "", "236", "2", "19", "", "", "236", "FATIMAS", "20/11/2016", "16/09/2016")

        dtDatosCliente.Rows.Clear()

        dtDatosCliente.Rows.Add("1", 0, "FERNANDO HUERTA ARRONIZ", "N", "", "S", "N", "N", 1, 1, "11/11/2016", "11/11/2016", "", "596", "", "596", "596", "", "", "", "", "", "", "", "", "", "596", "", 0, 1, 0, 0, 1, 0, "", "", "229", "", "367", "", "", "1", "11", "1", "11", "596", "FATIMAS", "10/11/2016")
        dtDatosCliente.Rows.Add("2", 0, "ALMACENES LA ORIENTAL", "N", "", "S", "S", "S", "", -130, "03/07/2016", "26/07/2016", "92", "", "", "92", "76", "", "", "", "", "", "", "", "", "", "76", "", 0, 0, 0, 0, 0, 0, "", "", "", "", "", "", "", "", "", "", "", "0", "", "")
        dtDatosCliente.Rows.Add("3", 0, "ORGANIZACIÓN SANTILLANA", "N", "", "S", "N", "N", "", 1, "11/11/2016", "11/11/2016", "", "442", "", "442", "180", "", "", "", "", "", "", "87", "90", "85", "442", "", 0, 0, 0, 1, 1, 1, "", "", "", "", "53", "270", "119", "31", "31", "31", "31", "442", "FATIMAS", "10/11/2016")
        dtDatosCliente.Rows.Add("4", 0, "GERARDO CHEVAILE RAMOS", "N", "cesar", "S", "N", "N", 2, -34, "07/10/2016", "07/10/2016", "175", "63", "", "238", "87", "", "", "14", "40", "", "", "", "", "21", "162", "", 0, 1, 0, 0, 0, 1, "", "", "110", "", "", "", "21", "5", "10", "2", "5", "110", "FATIMAS", "10/11/2016")
        dtDatosCliente.Rows.Add("5", 0, "ECOON ZAPATERIAS (ARELLANO)", "N", "", "N", "N", "N", 1, -20, "21/10/2016", "04/11/2016", "216", "", "", "216", "72", "", "", "4", "", "", "", "24", "", "24", "124", "", 1, 0, 0, 0, 0, 1, "", "72", "", "", "", "", "52", "1", "7", "1", "7", "124", "FATIMAS", "10/11/2016")
        dtDatosCliente.Rows.Add("6", 0, "ANTONIO DOMINGUEZ ALLON", "N", "", "S", "N", "S", "", -55, "16/09/2016", "16/09/2016", "", "298", "", "298", "236", "", "", "", "", "", "", "", "", "", "236", "", 0, 0, 0, 0, 0, 0, "", "25", "211", "", "", "", "", "2", "19", "", "", "236", "FATIMAS", "10/11/2016")


        'dtDatosPedidos.Rows.Add("1", 0, "FERNANDO HUERTA ARRONIZ", "7052", "120423", "", "FACTURADO", "", "", 1, "", "", "", "", "", "", "", 596, "", 596, 596, "", "", "", "", "", "", "", 0, 1, 0, 0, 0, 0, "", "", 596, "", "", "", "", "596", "1", "11", "596", "FATIMAS", "10/11/2016", "11/11/2016", "NO")
        'dtDatosPedidos.Rows.Add("2", 0, "ALMACENES LA ORIENTAL", "", "97583", "", "TERMINADO", "", "", -130, "", "", "", "", "", "", "16", "", "", "16", "", "", "", "", "", "", "", "", 0, 0, 0, 0, 0, 0, "", "", "", "", "", "", "", "", "", "", "", "", "", "03/07/2016", "SI")
        'dtDatosPedidos.Rows.Add("3", 0, "ORGANIZACIÓN SANTILLANA", "8231", "121432", "", "TERMINADO", "", "", 1, "", "", "", "", "", "", "", "17", "", "17", "", "", "", "", "", "", "", "17", 0, 0, 0, 0, 0, 1, "", "", "", "", "", "", "17", "17", "1", "1", "17", "FATIMAS", "10/11/2016", "11/11/2016", "NO")
        'dtDatosPedidos.Rows.Add("4", 0, "GERARDO CHEVAILE RAMOS", "7931", "121185", "", "PRODUCCIÓN", "", "", 0, "", "", "", "", "", "", "110", "", "", "110", "70", "", "40", "", "", "", "", "", 0, 1, 0, 0, 0, 0, "", "", "110", "", "", "", "", "110", "", "4", "110", "FATIMAS", "10/11/2016", "10/11/2016", "NO")
        'dtDatosPedidos.Rows.Add("5", 0, "ECOON ZAPATERIAS (ARELLANO)", "8875", "121927", "", "PROGRAMADO", "", "", -20, "", "", "", "", "", "", "216", "", "", "216", "72", "4", "", "", "", "24", "", "24", 1, 0, 0, 0, 0, 1, "", "72", "", "", "", "", "52", "124", "", "7", "124", "FATIMAS", "10/11/2016", "21/10/2016", "NO")
        'dtDatosPedidos.Rows.Add("6", 0, "ANTONIO DOMINGUEZ ALLON", "6823", "120216", "", "TERMINADO", "", "", -55, "", "", "", "", "", "", "", "25", "", "25", "25", "", "", "", "", "", "", "", 0, 0, 0, 0, 0, 0, "", "", "", "", "", "", "", "", "", "1", "", "", "", "16/09/2016", "NO")

        dtDatosPedidos.Rows.Clear()

        dtDatosPedidos.Rows.Add("1", 0, "FERNANDO HUERTA ARRONIZ", "7052", "120423", "N", "Terminado", "1", 1, "11/11/2016", "11/11/2016", "", "596", "", "596", "596", "", "", "", "", "", "", "", "", "", "596", "", 0, 1, 0, 0, 1, 0, "", "", "229", "", "367", "", "", "11", "11", "596", "FATIMAS", "10/11/2016", 0, 1, 0)
        dtDatosPedidos.Rows.Add("2", 0, "ALMACENES LA ORIENTAL", "1", "97583", "N", "TERMINADO", "", "-130", "03/07/2016", "03/07/2016", "16", "", "", "16", "", "", "", "", "", "", "", "", "", "", 0, "", 0, 0, 0, 0, 0, 0, "", "", "", "", "", "", "", "", "", "", "", "", 1, 2, 0)
        dtDatosPedidos.Rows.Add("3", 0, "ALMACENES LA ORIENTAL", "2", "113279", "N", "Terminado", "", "-62", "09/09/2016", "09/09/2016", "76", "", "", "76", "76", "", "", "", "", "", "", "", "", "", "76", "", 0, 0, 0, 0, 0, 0, "", "", "", "", "", "", "", "", "", "", "", "", 1, 2, 0)
        dtDatosPedidos.Rows.Add("4", 0, "ORGANIZACIÓN SANTILLANA", "8231", "121432", "N", "Terminado", "", 1, "11/11/2016", "11/11/2016", "", "17", "", "17", "", "", "", "", "", "", "", "", "", "17", "17", "", 0, 0, 0, 0, 0, 1, "", "", "", "", "", "", "17", 1, 1, "17", "FATIMAS", "10/11/2016", 0, 3, 0)
        dtDatosPedidos.Rows.Add("5", 0, "ORGANIZACIÓN SANTILLANA", "8240", "121442", "N", "Terminado", "", 1, "11/11/2016", "11/11/2016", "", "24", "", "24", "", "", "", "", "", "", "", "", "", "24", "24", "", 0, 0, 0, 0, 0, 1, "", "", "", "", "", "", "24", 1, 1, "24", "FATIMAS", "10/11/2016", 0, 3, 0)
        dtDatosPedidos.Rows.Add("6", 0, "ORGANIZACIÓN SANTILLANA", "8245", "121445", "N", "Terminado", "", 1, "11/11/2016", "11/11/2016", "", "20", "", "20", "", "", "", "", "", "", "", "", "", "20", "20", "", 0, 0, 0, 0, 0, 1, "", "", "", "", "", "", "20", 1, 1, "20", "FATIMAS", "10/11/2016", 0, 3, 0)
        dtDatosPedidos.Rows.Add("7", 0, "ORGANIZACIÓN SANTILLANA", "8316", "121508", "N", "Terminado", "", 1, "11/11/2016", "11/11/2016", "", "24", "", "24", "", "", "", "", "", "", "", "", "", "24", "24", "", 0, 0, 0, 0, 0, 1, "", "", "", "", "", "", "24", 1, 1, "24", "FATIMAS", "10/11/2016", 0, 3, 0)
        dtDatosPedidos.Rows.Add("8", 0, "ORGANIZACIÓN SANTILLANA", "8222", "121422", "N", "Terminado", "", 1, "11/11/2016", "11/11/2016", "", "15", "", "15", "", "", "", "", "", "", "", "", "15", "", "15", "", 0, 0, 0, 0, 1, 0, "", "", "", "", "", "15", "", 1, 1, "15", "FATIMAS", "10/11/2016", 0, 3, 0)
        dtDatosPedidos.Rows.Add("9", 0, "ORGANIZACIÓN SANTILLANA", "8224", "121424", "N", "Terminado", "", 1, "11/11/2016", "11/11/2016", "", "15", "", "15", "", "", "", "", "", "", "", "", "15", "", "15", "", 0, 0, 0, 0, 1, 0, "", "", "", "", "", "15", "", 1, 1, "15", "FATIMAS", "10/11/2016", 0, 3, 0)
        dtDatosPedidos.Rows.Add("10", 0, "ORGANIZACIÓN SANTILLANA", "8234", "121434", "N", "Terminado", "", 1, "11/11/2016", "11/11/2016", "", "15", "", "15", "", "", "", "", "", "", "", "", "15", "", "15", "", 0, 0, 0, 0, 1, 0, "", "", "", "", "", "15", "", 1, 1, "15", "FATIMAS", "10/11/2016", 0, 3, 0)
        dtDatosPedidos.Rows.Add("11", 0, "ORGANIZACIÓN SANTILLANA", "8237", "121438", "N", "Terminado", "", 1, "11/11/2016", "11/11/2016", "", "15", "", "15", "", "", "", "", "", "", "", "", "15", "", "15", "", 0, 0, 0, 0, 1, 0, "", "", "", "", "", "15", "", 1, 1, "15", "FATIMAS", "10/11/2016", 0, 3, 0)
        dtDatosPedidos.Rows.Add("12", 0, "ORGANIZACIÓN SANTILLANA", "8310", "121502", "N", "Terminado", "", 1, "11/11/2016", "11/11/2016", "", "15", "", "15", "", "", "", "", "", "", "", "", "15", "", "15", "", 0, 0, 0, 0, 1, 0, "", "", "", "", "", "15", "", 1, 1, "15", "FATIMAS", "10/11/2016", 0, 3, 0)
        dtDatosPedidos.Rows.Add("13", 0, "ORGANIZACIÓN SANTILLANA", "8312", "121504", "N", "Terminado", "", 1, "11/11/2016", "11/11/2016", "", "15", "", "15", "", "", "", "", "", "", "", "", "15", "", "15", "", 0, 0, 0, 0, 1, 0, "", "", "", "", "", "15", "", 1, 1, "15", "FATIMAS", "10/11/2016", 0, 3, 0)
        dtDatosPedidos.Rows.Add("14", 0, "ORGANIZACIÓN SANTILLANA", "8210", "121410", "N", "Terminado", "", 1, "11/11/2016", "11/11/2016", "", "19", "", "19", "", "", "", "", "", "", "", "19", "", "", "19", "", 0, 0, 0, 0, 0, 1, "", "", "", "", "", "", "19", 1, 1, "19", "FATIMAS", "10/11/2016", 0, 3, 0)
        dtDatosPedidos.Rows.Add("15", 0, "ORGANIZACIÓN SANTILLANA", "8217", "121417", "N", "Terminado", "", 1, "11/11/2016", "11/11/2016", "", "14", "", "14", "", "", "", "", "", "", "", "14", "", "", "14", "", 0, 0, 0, 1, 0, 0, "", "", "", "", "14", "", "", 1, 1, "14", "FATIMAS", "10/11/2016", 0, 3, 0)
        dtDatosPedidos.Rows.Add("16", 0, "ORGANIZACIÓN SANTILLANA", "8279", "121477", "N", "Terminado", "", 1, "11/11/2016", "11/11/2016", "", "12", "", "12", "", "", "", "", "", "", "", "12", "", "", "12", "", 0, 0, 0, 1, 0, 0, "", "", "", "", "12", "", "", 1, 1, "12", "FATIMAS", "10/11/2016", 0, 3, 0)
        dtDatosPedidos.Rows.Add("17", 0, "ORGANIZACIÓN SANTILLANA", "8298", "121492", "N", "Terminado", "", 1, "11/11/2016", "11/11/2016", "", "15", "", "15", "", "", "", "", "", "", "", "15", "", "", "15", "", 0, 0, 0, 0, 0, 1, "", "", "", "", "", "", "15", 1, 1, "15", "FATIMAS", "10/11/2016", 0, 3, 0)
        dtDatosPedidos.Rows.Add("18", 0, "ORGANIZACIÓN SANTILLANA", "8307", "121498", "N", "Terminado", "", 1, "11/11/2016", "11/11/2016", "", "15", "", "15", "", "", "", "", "", "", "", "15", "", "", "15", "", 0, 0, 0, 1, 0, 0, "", "", "", "", "15", "", "", 1, 1, "15", "FATIMAS", "10/11/2016", 0, 3, 0)
        dtDatosPedidos.Rows.Add("19", 0, "ORGANIZACIÓN SANTILLANA", "8318", "121510", "N", "Terminado", "", 1, "11/11/2016", "11/11/2016", "", "12", "", "12", "", "", "", "", "", "", "", "12", "", "", "12", "", 0, 0, 0, 1, 0, 0, "", "", "", "", "12", "", "", 1, 1, "12", "FATIMAS", "10/11/2016", 0, 3, 0)
        dtDatosPedidos.Rows.Add("20", 0, "ORGANIZACIÓN SANTILLANA", "8219", "121419", "N", "Terminado", "", 1, "11/11/2016", "11/11/2016", "", "12", "", "12", "12", "", "", "", "", "", "", "", "", "", "12", "", 0, 0, 0, 0, 0, 1, "", "", "", "", "", "12", "", 1, 1, "12", "FATIMAS", "10/11/2016", 0, 3, 0)
        dtDatosPedidos.Rows.Add("21", 0, "ORGANIZACIÓN SANTILLANA", "8247", "121448", "N", "Terminado", "", 1, "11/11/2016", "11/11/2016", "", "12", "", "12", "12", "", "", "", "", "", "", "", "", "", "12", "", 0, 0, 0, 0, 0, 1, "", "", "", "", "", "12", "", 1, 1, "12", "FATIMAS", "10/11/2016", 0, 3, 0)
        dtDatosPedidos.Rows.Add("22", 0, "ORGANIZACIÓN SANTILLANA", "8251", "121451", "N", "Terminado", "", 1, "11/11/2016", "11/11/2016", "", "12", "", "12", "12", "", "", "", "", "", "", "", "", "", "12", "", 0, 0, 0, 0, 0, 1, "", "", "", "", "", "12", "", 1, 1, "12", "FATIMAS", "10/11/2016", 0, 3, 0)
        dtDatosPedidos.Rows.Add("23", 0, "ORGANIZACIÓN SANTILLANA", "8255", "121453", "N", "Terminado", "", 1, "11/11/2016", "11/11/2016", "", "12", "", "12", "12", "", "", "", "", "", "", "", "", "", "12", "", 0, 0, 0, 0, 0, 1, "", "", "", "", "", "12", "", 1, 1, "12", "FATIMAS", "10/11/2016", 0, 3, 0)
        dtDatosPedidos.Rows.Add("24", 0, "ORGANIZACIÓN SANTILLANA", "8258", "121456", "N", "Terminado", "", 1, "11/11/2016", "11/11/2016", "", "12", "", "12", "12", "", "", "", "", "", "", "", "", "", "12", "", 0, 0, 0, 0, 0, 1, "", "", "", "", "", "12", "", 1, 1, "12", "FATIMAS", "10/11/2016", 0, 3, 0)
        dtDatosPedidos.Rows.Add("25", 0, "ORGANIZACIÓN SANTILLANA", "8261", "121459", "N", "Terminado", "", 1, "11/11/2016", "11/11/2016", "", "12", "", "12", "12", "", "", "", "", "", "", "", "", "", "12", "", 0, 0, 0, 0, 0, 1, "", "", "", "", "", "12", "", 1, 1, "12", "FATIMAS", "10/11/2016", 0, 3, 0)
        dtDatosPedidos.Rows.Add("26", 0, "ORGANIZACIÓN SANTILLANA", "8267", "121465", "N", "Terminado", "", 1, "11/11/2016", "11/11/2016", "", "12", "", "12", "12", "", "", "", "", "", "", "", "", "", "12", "", 0, 0, 0, 0, 0, 1, "", "", "", "", "", "12", "", 1, 1, "12", "FATIMAS", "10/11/2016", 0, 3, 0)
        dtDatosPedidos.Rows.Add("27", 0, "ORGANIZACIÓN SANTILLANA", "8269", "121467", "N", "Terminado", "", 1, "11/11/2016", "11/11/2016", "", "12", "", "12", "12", "", "", "", "", "", "", "", "", "", "12", "", 0, 0, 0, 0, 0, 1, "", "", "", "", "", "12", "", 1, 1, "12", "FATIMAS", "10/11/2016", 0, 3, 0)
        dtDatosPedidos.Rows.Add("28", 0, "ORGANIZACIÓN SANTILLANA", "8273", "121471", "N", "Terminado", "", 1, "11/11/2016", "11/11/2016", "", "12", "", "12", "12", "", "", "", "", "", "", "", "", "", "12", "", 0, 0, 0, 0, 0, 1, "", "", "", "", "", "12", "", 1, 1, "12", "FATIMAS", "10/11/2016", 0, 3, 0)
        dtDatosPedidos.Rows.Add("29", 0, "ORGANIZACIÓN SANTILLANA", "8275", "121473", "N", "Terminado", "", 1, "11/11/2016", "11/11/2016", "", "12", "", "12", "12", "", "", "", "", "", "", "", "", "", "12", "", 0, 0, 0, 0, 0, 1, "", "", "", "", "", "12", "", 1, 1, "12", "FATIMAS", "10/11/2016", 0, 3, 0)
        dtDatosPedidos.Rows.Add("30", 0, "ORGANIZACIÓN SANTILLANA", "8277", "121475", "N", "Terminado", "", 1, "11/11/2016", "11/11/2016", "", "12", "", "12", "12", "", "", "", "", "", "", "", "", "", "12", "", 0, 0, 0, 0, 0, 1, "", "", "", "", "", "12", "", 1, 1, "12", "FATIMAS", "10/11/2016", 0, 3, 0)
        dtDatosPedidos.Rows.Add("31", 0, "ORGANIZACIÓN SANTILLANA", "8283", "121480", "N", "Terminado", "", 1, "11/11/2016", "11/11/2016", "", "12", "", "12", "12", "", "", "", "", "", "", "", "", "", "12", "", 0, 0, 0, 0, 0, 1, "", "", "", "", "", "12", "", 1, 1, "12", "FATIMAS", "10/11/2016", 0, 3, 0)
        dtDatosPedidos.Rows.Add("32", 0, "ORGANIZACIÓN SANTILLANA", "8286", "121483", "N", "Terminado", "", 1, "11/11/2016", "11/11/2016", "", "12", "", "12", "12", "", "", "", "", "", "", "", "", "", "12", "", 0, 0, 0, 0, 0, 1, "", "", "", "", "", "12", "", 1, 1, "12", "FATIMAS", "10/11/2016", 0, 3, 0)
        dtDatosPedidos.Rows.Add("33", 0, "ORGANIZACIÓN SANTILLANA", "8292", "121489", "N", "Terminado", "", 1, "11/11/2016", "11/11/2016", "", "12", "", "12", "12", "", "", "", "", "", "", "", "", "", "12", "", 0, 0, 0, 0, 0, 1, "", "", "", "", "", "12", "", 1, 1, "12", "FATIMAS", "10/11/2016", 0, 3, 0)
        dtDatosPedidos.Rows.Add("34", 0, "ORGANIZACIÓN SANTILLANA", "8314", "121506", "N", "Terminado", "", 1, "11/11/2016", "11/11/2016", "", "12", "", "12", "12", "", "", "", "", "", "", "", "", "", "12", "", 0, 0, 0, 0, 0, 1, "", "", "", "", "", "12", "", 1, 1, "12", "FATIMAS", "10/11/2016", 0, 3, 0)
        dtDatosPedidos.Rows.Add("35", 0, "GERARDO CHEVAILE RAMOS", "7925", "121180", "N", "Terminado", "", "-12", "29/10/2016", "29/10/2016", "32", "", "", "32", "17", "", "", "", "", "", "", "", "", "", "17", "", 0, 0, 0, 0, 0, 0, "", "", "", "", "", "", "", 1, 0, 0, "FATIMAS", "10/11/2016", 0, 4, 0)
        dtDatosPedidos.Rows.Add("36", 0, "GERARDO CHEVAILE RAMOS", "7931", "121185", "N", "Terminado", "1", 0, "10/11/2016", "10/11/2016", "110", "", "", "110", "70", "", "", "", "40", "", "", "", "", "", "110", "", 0, 1, 0, 0, 0, 0, "", "", "110", "", "", "", "", 4, 4, "110", "FATIMAS", "10/11/2016", 0, 4, 0)
        dtDatosPedidos.Rows.Add("37", 0, "GERARDO CHEVAILE RAMOS", "7221", "120575", "N", "Capturado", "", "-34", "07/10/2016", "07/10/2016", "12", "", "", "12", 0, "", "", "", "", "", "", "", "", "", 0, "", 0, 0, 0, 0, 0, 0, "", "", "", "", "", "", "", 1, 0, 0, "FATIMAS", "10/11/2016", 0, 4, 0)
        dtDatosPedidos.Rows.Add("38", 0, "GERARDO CHEVAILE RAMOS", "3215", "116453", "N", "Terminado", "1", "-6", "04/11/2016", "04/11/2016", "21", "", "", "21", 0, "", "", "", "", "", "", "", "", "21", "21", "", 0, 0, 0, 0, 0, 1, "", "", "", "", "", "", "21", 1, 1, "21", "FATIMAS", "10/11/2016", 0, 4, 0)
        dtDatosPedidos.Rows.Add("39", 0, "GERARDO CHEVAILE RAMOS", "3216", "116454", "N", "Programado", "", 1, "11/11/2016", "11/11/2016", "", "63", "", "63", 0, "", "", "14", "", "", "", "", "", "", "14", "", 0, 0, 0, 0, 0, 0, "", "", "", "", "", "", "", 3, 0, 0, "FATIMAS", "10/11/2016", 0, 4, 0)
        dtDatosPedidos.Rows.Add("40", 0, "ECOON ZAPATERIAS (ARELLANO)", "8875", "121927", "N", "Programado", "1", "-20", "21/10/2016", "04/11/2016", "216", "", "", "216", "72", "", "", 4, "", "", "", "24", "", "24", "124", "", 1, 0, 0, 0, 0, 1, "", "72", "", "", "", "", "52", "7", "7", "124", "FATIMAS", "10/11/2016", 0, 5, 0)
        dtDatosPedidos.Rows.Add("41", 0, "ANTONIO DOMINGUEZ ALLON", "6823", "120216", "N", "Programado", "", "-55", "16/09/2016", "16/09/2016", "25", "", "", "25", "25", "", "", "", "", "", "", "", "", "", "25", "", 0, 0, 0, 0, 0, 0, "", "25", "", "", "", "", "", 1, 1, "25", "FATIMAS", "10/11/2016", 0, 6, 1)
        dtDatosPedidos.Rows.Add("42", 0, "ANTONIO DOMINGUEZ ALLON", "9008", "121982", "N", "Programado", "", 1, "11/11/2016", "11/11/2016", "", "273", "", "273", "211", "", "", "", "", "", "", "", "", "", "211", "", 0, 0, 0, 0, 0, 0, "", "", "211", "", "", "", "", "18", "14", "211", "FATIMAS", "10/11/2016", 0, 6, 1)


        'dtDatosPartidas.Rows.Add("1", "120423", "1", "", "FERNANDO HUERTA ARRONIZ", "Facturado", "YUYIN BOTIN ATENAS 26281 FLOR ENTERA CAJETA  22-26½", "4C", 1, "", "", "", "", "", "", "", "61", "", "61", "61", "", "", "", "", "", "", "", 0, 1, 0, 0, 0, 0, "", "", "61", "", "", "", "", "61", "61", "FATIMAS", "10/11/2016", "11/11/2016", "NO")
        'dtDatosPartidas.Rows.Add("2", "97583", "15", "", "ALMACENES LA ORIENTAL, S.A. DE C.V.", "Terminado", "YUYIN CLASSIC 25962 MICRO FIBRA BLANCO / FIUSHA  18-21½", "3", -130, "", "", "", "", "", "", "16", "", "", "16", "", "", "", "", "", "", "", "", 0, 0, 0, 0, 0, 0, "", "", "", "", "", "", "", "", "", "", "", "03/07/2015", "SI")
        'dtDatosPartidas.Rows.Add("3", "121432", "1", "", "(SUC. TAMARY) CALZADOS LAREDO, S.A. DE C.V.", "Terminado", "JEANS BOTA FLORENCIA 36152 FLOR ENTERA NEGRO  22-26½", "4C", 1, "", "", "", "", "", "", "", "17", "", "17", "", "", "", "", "", "", "", "17", 0, 0, 0, 0, 0, 1, "", "", "", "", "", "", "17", "17", "17", "FATIMAS", "11/11/2016", "11/11/2016", "NO")
        'dtDatosPartidas.Rows.Add("4", "121185", "1", "", "GERARDO CHEVAILE RAMOS", "Produccion", "YUYIN BOTA CIMA 26060 CRAZY CAFE  18-21½", "3", 0, "", "", "", "", "", "", "32", "", "", "32", "", "", "32", "", "", "", "", "", 0, 1, 0, 0, 0, 0, "", "", "32", "", "", "", "", "32", "32", "FATIMAS", "10/11/2016", "10/11/2016", "NO")
        'dtDatosPartidas.Rows.Add("5", "121927", "14", "", "MAYOREO", "Programado", "JEANS BOTIN VENECIA 36221 FLOR ENTERA CAFE  22-26½", "4C", -20, "", "", "", "", "", "", "36", "", "", "36", "34", "", "", "", "", "", "", "", 1, 0, 0, 0, 0, 0, "", "34", "", "", "", "", "", "34", "34", "FATIMAS", "12/11/2016", "21/10/2016", "NO")
        'dtDatosPartidas.Rows.Add("6", "120216", "28", "", "ANTONIO DOMIGUEZ ALLON", "Terminado", "YUYIN BOTIN ATENAS 26281 FLOR ENTERA NEGRO  22-26½", "4C", -55, "", "", "", "", "", "", "", "25", "", "25", "25", "", "", "", "", "", "", "", 0, 0, 0, 0, 0, 0, "", "", "", "", "", "", "", "", "", "", "", "16/09/2016", "NO")

        dtDatosPartidas.Rows.Clear()

        dtDatosPartidas.Rows.Add(1, "FERNANDO HUERTA ARRONIZ", 7052, 1, "N", "Terminado", "YUYIN BOTIN ATENAS 26281 FLOR ENTERA CAJETA  22-26½", "22-26½", 1, "11/11/2016", "", "61", "", "61", "61", "", "", "", "", "", "", "", "", "", "61", "", 0, 1, 0, 0, 0, 0, "", "", "61", "", "", "", "", "61", "FATIMAS", "10/11/2016", 0, 0, 0)
        dtDatosPartidas.Rows.Add(2, "FERNANDO HUERTA ARRONIZ", 7052, "2", "N", "Terminado", "YUYIN BOTA ATENAS 26270 FLOR ENTERA CAJETA  22-26½", "22-26½", 1, "11/11/2016", "", "61", "", "61", "61", "", "", "", "", "", "", "", "", "", "61", "", 0, 1, 0, 0, 0, 0, "", "", "61", "", "", "", "", "61", "FATIMAS", "10/11/2016", 0, 0, 0)
        dtDatosPartidas.Rows.Add(3, "FERNANDO HUERTA ARRONIZ", 7052, "3", "N", "Terminado", "YUYIN BOTA ATENAS 26270 FLOR ENTERA NEGRO  22-26½", "22-26½", 1, "11/11/2016", "", "61", "", "61", "61", "", "", "", "", "", "", "", "", "", "61", "", 0, 1, 0, 0, 0, 0, "", "", "61", "", "", "", "", "61", "FATIMAS", "10/11/2016", 0, 0, 0)
        dtDatosPartidas.Rows.Add(4, "FERNANDO HUERTA ARRONIZ", 7052, "4", "N", "Terminado", "YUYIN BOTA ATENAS 26270 FLOR ENTERA NEGRO  18-21½", "18-21½", 1, "11/11/2016", "", "46", "", "46", "46", "", "", "", "", "", "", "", "", "", "46", "", 0, 1, 0, 0, 0, 0, "", "", "46", "", "", "", "", "46", "FATIMAS", "10/11/2016", 0, 0, 0)
        dtDatosPartidas.Rows.Add(5, "FERNANDO HUERTA ARRONIZ", 7052, "5", "N", "Terminado", "YUYIN BOTA ATENAS 26270 FLOR ENTERA CAJETA  18-21½", "18-21½", 1, "11/11/2016", "", "46", "", "46", "46", "", "", "", "", "", "", "", "", "", "46", "", 0, 0, 0, 0, 1, 0, "", "", "", "", "46", "", "", "46", "FATIMAS", "10/11/2016", 0, 0, 0)
        dtDatosPartidas.Rows.Add(6, "FERNANDO HUERTA ARRONIZ", 7052, "6", "N", "Terminado", "JEANS BOTA MURALLA 36091 NAPA NEGRO  18-21½", "18-21½", 1, "11/11/2016", "", "46", "", "46", "46", "", "", "", "", "", "", "", "", "", "46", "", 0, 0, 0, 0, 1, 0, "", "", "", "", "46", "", "", "46", "FATIMAS", "10/11/2016", 0, 0, 0)
        dtDatosPartidas.Rows.Add(7, "FERNANDO HUERTA ARRONIZ", 7052, "7", "N", "Terminado", "JEANS BOTA MURALLA 36091 NAPA NEGRO  22-26½", "22-26½", 1, "11/11/2016", "", "61", "", "61", "61", "", "", "", "", "", "", "", "", "", "61", "", 0, 0, 0, 0, 1, 0, "", "", "", "", "61", "", "", "61", "FATIMAS", "10/11/2016", 0, 0, 0)
        dtDatosPartidas.Rows.Add(8, "FERNANDO HUERTA ARRONIZ", 7052, "8", "N", "Terminado", "JEANS BOTA MURALLA 36090 NAPA NEGRO  22-26½", "22-26½", 1, "11/11/2016", "", "61", "", "61", "61", "", "", "", "", "", "", "", "", "", "61", "", 0, 0, 0, 0, 1, 0, "", "", "", "", "61", "", "", "61", "FATIMAS", "10/11/2016", 0, 0, 0)
        dtDatosPartidas.Rows.Add(9, "FERNANDO HUERTA ARRONIZ", 7052, "9", "N", "Terminado", "JEANS BOTA MURALLA 36090 FLOR ENTERA CAFE  22-26½", "22-26½", 1, "11/11/2016", "", "61", "", "61", "61", "", "", "", "", "", "", "", "", "", "61", "", 0, 0, 0, 0, 1, 0, "", "", "", "", "61", "", "", "61", "FATIMAS", "10/11/2016", 0, 0, 0)
        dtDatosPartidas.Rows.Add(0, "FERNANDO HUERTA ARRONIZ", 7052, "10", "N", "Terminado", "JEANS BOTA MURALLA 36090 NAPA NEGRO  18-21½", "18-21½", 1, "11/11/2016", "", "46", "", "46", "46", "", "", "", "", "", "", "", "", "", "46", "", 0, 0, 0, 0, 1, 0, "", "", "", "", "46", "", "", "46", "FATIMAS", "10/11/2016", 0, 0, 0)
        dtDatosPartidas.Rows.Add(11, "FERNANDO HUERTA ARRONIZ", 7052, "11", "N", "Terminado", "JEANS BOTA MURALLA 36090 FLOR ENTERA CAFE  18-21½", "18-21½", 1, "11/11/2016", "", "46", "", "46", "46", "", "", "", "", "", "", "", "", "", "46", "", 0, 0, 0, 0, 1, 0, "", "", "", "", "46", "", "", "46", "FATIMAS", "10/11/2016", 0, 0, 0)
        dtDatosPartidas.Rows.Add(12, "ALMACENES LA ORIENTAL", 1, 1, "N", "Terminado", "YUYIN CLASSIC 25962 MICRO FIBRA BLANCO / FIUSHA  18-21½", "18-21½", "-130", "03/07/2016", "16", "", "", "16", "", "", "", "", "", "", "", "", "", "", 0, "", 0, 0, 0, 0, 0, 0, "", "", "", "", "", "", "", 0, "", "", 1, 0, 0)
        dtDatosPartidas.Rows.Add(13, "ALMACENES LA ORIENTAL", 2, 1, "N", "Terminado", "JEANS BOTIN COLLAGE 36162 GAMUCINA ARENA  18-21½", "18-21½", "-62", "09/09/2016", "12", "", "", "12", "12", "", "", "", "", "", "", "", "", "", "12", "", 0, 0, 0, 0, 0, 0, "", "", "", "", "", "", "", 0, "", "", 1, 0, 0)
        dtDatosPartidas.Rows.Add(14, "ALMACENES LA ORIENTAL", 2, "2", "N", "Terminado", "JEANS BOTIN COLLAGE 36162 GAMUCINA ARENA  22-26½", "22-26½", "-62", "09/09/2016", "14", "", "", "14", "14", "", "", "", "", "", "", "", "", "", "14", "", 0, 0, 0, 0, 0, 0, "", "", "", "", "", "", "", 0, "", "", 1, 0, 0)
        dtDatosPartidas.Rows.Add(15, "ALMACENES LA ORIENTAL", 2, "3", "N", "Terminado", "JEANS BOTIN COLLAGE 36163 GAMUCINA VINO  18-21½", "18-21½", "-62", "09/09/2016", "12", "", "", "12", "12", "", "", "", "", "", "", "", "", "", "12", "", 0, 0, 0, 0, 0, 0, "", "", "", "", "", "", "", 0, "", "", 1, 0, 0)
        dtDatosPartidas.Rows.Add(16, "ALMACENES LA ORIENTAL", 2, "4", "N", "Terminado", "JEANS BOTIN COLLAGE 36163 GAMUCINA VINO  22-26½", "22-26½", "-62", "09/09/2016", "14", "", "", "14", "14", "", "", "", "", "", "", "", "", "", "14", "", 0, 0, 0, 0, 0, 0, "", "", "", "", "", "", "", 0, "", "", 1, 0, 0)
        dtDatosPartidas.Rows.Add(17, "ALMACENES LA ORIENTAL", 2, "7", "N", "Terminado", "YUYIN BOTA SUSPIRO 26311 FLOR ENTERA CHOCOLATE  15-17½", "15-17½", "-62", "09/09/2016", "12", "", "", "12", "12", "", "", "", "", "", "", "", "", "", "12", "", 0, 0, 0, 0, 0, 0, "", "", "", "", "", "", "", 0, "", "", 1, 0, 0)
        dtDatosPartidas.Rows.Add(18, "ALMACENES LA ORIENTAL", 2, "8", "N", "Terminado", "YUYIN BOTA SUSPIRO 26311 FLOR ENTERA CHOCOLATE  18-21½", "18-21½", "-62", "09/09/2016", "12", "", "", "12", "12", "", "", "", "", "", "", "", "", "", "12", "", 0, 0, 0, 0, 0, 0, "", "", "", "", "", "", "", 0, "", "", 1, 0, 0)
        dtDatosPartidas.Rows.Add(19, "ORGANIZACIÓN SANTILLANA", "8231", 1, "N", "Terminado", "JEANS BOTA FLORENCIA 36152 FLOR ENTERA NEGRO  22-26½", "22-26½", 1, "11/11/2016", "", "17", "", "17", "", "", "", "", "", "", "", "", "", "17", "17", "", 0, 0, 0, 0, 0, 1, "", "", "", "", "", "", "17", "17", "FATIMAS", "10/11/2016", 0, 0, 0)
        dtDatosPartidas.Rows.Add(20, "ORGANIZACIÓN SANTILLANA", "8240", 1, "N", "Terminado", "JEANS BOTA FLORENCIA 36152 FLOR ENTERA NEGRO  22-26½", "22-26½", 1, "11/11/2016", "", "24", "", "24", "", "", "", "", "", "", "", "", "", "24", "24", "", 0, 0, 0, 0, 0, 1, "", "", "", "", "", "", "24", "24", "FATIMAS", "10/11/2016", 0, 0, 0)
        dtDatosPartidas.Rows.Add(21, "ORGANIZACIÓN SANTILLANA", "8245", 1, "N", "Terminado", "JEANS BOTA FLORENCIA 36152 FLOR ENTERA NEGRO  22-26½", "22-26½", 1, "11/11/2016", "", "20", "", "20", "", "", "", "", "", "", "", "", "", "20", "20", "", 0, 0, 0, 0, 0, 1, "", "", "", "", "", "", "20", "20", "FATIMAS", "10/11/2016", 0, 0, 0)
        dtDatosPartidas.Rows.Add(22, "ORGANIZACIÓN SANTILLANA", "8316", 1, "N", "Terminado", "JEANS BOTA FLORENCIA 36152 FLOR ENTERA NEGRO  22-26½", "22-26½", 1, "11/11/2016", "", "24", "", "24", "", "", "", "", "", "", "", "", "", "24", "24", "", 0, 0, 0, 0, 0, 1, "", "", "", "", "", "", "24", "24", "FATIMAS", "10/11/2016", 0, 0, 0)
        dtDatosPartidas.Rows.Add(23, "ORGANIZACIÓN SANTILLANA", "8222", 1, "N", "Terminado", "JEANS BOTA FLORENCIA 36152 FLOR ENTERA NEGRO  22-26½", "22-26½", 1, "11/11/2016", "", "15", "", "15", "", "", "", "", "", "", "", "", "15", "", "15", "", 0, 0, 0, 0, 1, 0, "", "", "", "", "", "15", "", "15", "FATIMAS", "10/11/2016", 0, 0, 0)
        dtDatosPartidas.Rows.Add(24, "ORGANIZACIÓN SANTILLANA", "8224", 1, "N", "Terminado", "JEANS BOTA FLORENCIA 36152 FLOR ENTERA NEGRO  22-26½", "22-26½", 1, "11/11/2016", "", "15", "", "15", "", "", "", "", "", "", "", "", "15", "", "15", "", 0, 0, 0, 0, 1, 0, "", "", "", "", "", "15", "", "15", "FATIMAS", "10/11/2016", 0, 0, 0)
        dtDatosPartidas.Rows.Add(25, "ORGANIZACIÓN SANTILLANA", "8234", 1, "N", "Terminado", "JEANS BOTA FLORENCIA 36152 FLOR ENTERA NEGRO  22-26½", "22-26½", 1, "11/11/2016", "", "15", "", "15", "", "", "", "", "", "", "", "", "15", "", "15", "", 0, 0, 0, 0, 1, 0, "", "", "", "", "", "15", "", "15", "FATIMAS", "10/11/2016", 0, 0, 0)
        dtDatosPartidas.Rows.Add(26, "ORGANIZACIÓN SANTILLANA", "8237", 1, "N", "Terminado", "JEANS BOTA FLORENCIA 36152 FLOR ENTERA NEGRO  22-26½", "22-26½", 1, "11/11/2016", "", "15", "", "15", "", "", "", "", "", "", "", "", "15", "", "15", "", 0, 0, 0, 0, 1, 0, "", "", "", "", "", "15", "", "15", "FATIMAS", "10/11/2016", 0, 0, 0)
        dtDatosPartidas.Rows.Add(27, "ORGANIZACIÓN SANTILLANA", "8310", 1, "N", "Terminado", "JEANS BOTA FLORENCIA 36152 FLOR ENTERA NEGRO  22-26½", "22-26½", 1, "11/11/2016", "", "15", "", "15", "", "", "", "", "", "", "", "", "15", "", "15", "", 0, 0, 0, 0, 1, 0, "", "", "", "", "", "15", "", "15", "FATIMAS", "10/11/2016", 0, 0, 0)
        dtDatosPartidas.Rows.Add(28, "ORGANIZACIÓN SANTILLANA", "8312", 1, "N", "Terminado", "JEANS BOTA FLORENCIA 36152 FLOR ENTERA NEGRO  22-26½", "22-26½", 1, "11/11/2016", "", "15", "", "15", "", "", "", "", "", "", "", "", "15", "", "15", "", 0, 0, 0, 0, 1, 0, "", "", "", "", "", "15", "", "15", "FATIMAS", "10/11/2016", 0, 0, 0)
        dtDatosPartidas.Rows.Add(29, "ORGANIZACIÓN SANTILLANA", "8210", 1, "N", "Terminado", "JEANS BOTA FLORENCIA 36152 FLOR ENTERA NEGRO  22-26½", "22-26½", 1, "11/11/2016", "", "19", "", "19", "", "", "", "", "", "", "", "19", "", "", "19", "", 0, 0, 0, 0, 0, 1, "", "", "", "", "", "", "19", "19", "FATIMAS", "10/11/2016", 0, 0, 0)
        dtDatosPartidas.Rows.Add(30, "ORGANIZACIÓN SANTILLANA", "8217", 1, "N", "Terminado", "JEANS BOTA FLORENCIA 36152 FLOR ENTERA NEGRO  22-26½", "22-26½", 1, "11/11/2016", "", "14", "", "14", "", "", "", "", "", "", "", "14", "", "", "14", "", 0, 0, 0, 1, 0, 0, "", "", "", "", "14", "", "", "14", "FATIMAS", "10/11/2016", 0, 0, 0)
        dtDatosPartidas.Rows.Add(31, "ORGANIZACIÓN SANTILLANA", "8279", 1, "N", "Terminado", "JEANS BOTA FLORENCIA 36152 FLOR ENTERA NEGRO  22-26½", "22-26½", 1, "11/11/2016", "", "12", "", "12", "", "", "", "", "", "", "", "12", "", "", "12", "", 0, 0, 0, 1, 0, 0, "", "", "", "", "12", "", "", "12", "FATIMAS", "10/11/2016", 0, 0, 0)
        dtDatosPartidas.Rows.Add(32, "ORGANIZACIÓN SANTILLANA", "8298", 1, "N", "Terminado", "JEANS BOTA FLORENCIA 36152 FLOR ENTERA NEGRO  22-26½", "22-26½", 1, "11/11/2016", "", "15", "", "15", "", "", "", "", "", "", "", "15", "", "", "15", "", 0, 0, 0, 0, 0, 1, "", "", "", "", "", "", "15", "15", "FATIMAS", "10/11/2016", 0, 0, 0)
        dtDatosPartidas.Rows.Add(33, "ORGANIZACIÓN SANTILLANA", "8307", 1, "N", "Terminado", "JEANS BOTA FLORENCIA 36152 FLOR ENTERA NEGRO  22-26½", "22-26½", 1, "11/11/2016", "", "15", "", "15", "", "", "", "", "", "", "", "15", "", "", "15", "", 0, 0, 0, 1, 0, 0, "", "", "", "", "15", "", "", "15", "FATIMAS", "10/11/2016", 0, 0, 0)
        dtDatosPartidas.Rows.Add(34, "ORGANIZACIÓN SANTILLANA", "8318", 1, "N", "Terminado", "JEANS BOTA FLORENCIA 36152 FLOR ENTERA NEGRO  22-26½", "22-26½", 1, "11/11/2016", "", "12", "", "12", "", "", "", "", "", "", "", "12", "", "", "12", "", 0, 0, 0, 1, 0, 0, "", "", "", "", "12", "", "", "12", "FATIMAS", "10/11/2016", 0, 0, 0)
        dtDatosPartidas.Rows.Add(35, "ORGANIZACIÓN SANTILLANA", "8219", 1, "N", "Terminado", "JEANS BOTA FLORENCIA 36152 FLOR ENTERA NEGRO  22-26½", "22-26½", 1, "11/11/2016", "", "12", "", "12", "12", "", "", "", "", "", "", "", "", "", "12", "", 0, 0, 0, 0, 0, 1, "", "", "", "", "", "12", "", "12", "FATIMAS", "10/11/2016", 0, 0, 0)
        dtDatosPartidas.Rows.Add(36, "ORGANIZACIÓN SANTILLANA", "8247", 1, "N", "Terminado", "JEANS BOTA FLORENCIA 36152 FLOR ENTERA NEGRO  22-26½", "22-26½", 1, "11/11/2016", "", "12", "", "12", "12", "", "", "", "", "", "", "", "", "", "12", "", 0, 0, 0, 0, 0, 1, "", "", "", "", "", "12", "", "12", "FATIMAS", "10/11/2016", 0, 0, 0)
        dtDatosPartidas.Rows.Add(37, "ORGANIZACIÓN SANTILLANA", "8251", 1, "N", "Terminado", "JEANS BOTA FLORENCIA 36152 FLOR ENTERA NEGRO  22-26½", "22-26½", 1, "11/11/2016", "", "12", "", "12", "12", "", "", "", "", "", "", "", "", "", "12", "", 0, 0, 0, 0, 0, 1, "", "", "", "", "", "12", "", "12", "FATIMAS", "10/11/2016", 0, 0, 0)
        dtDatosPartidas.Rows.Add(38, "ORGANIZACIÓN SANTILLANA", "8255", 1, "N", "Terminado", "JEANS BOTA FLORENCIA 36152 FLOR ENTERA NEGRO  22-26½", "22-26½", 1, "11/11/2016", "", "12", "", "12", "12", "", "", "", "", "", "", "", "", "", "12", "", 0, 0, 0, 0, 0, 1, "", "", "", "", "", "12", "", "12", "FATIMAS", "10/11/2016", 0, 0, 0)
        dtDatosPartidas.Rows.Add(39, "ORGANIZACIÓN SANTILLANA", "8258", 1, "N", "Terminado", "JEANS BOTA FLORENCIA 36152 FLOR ENTERA NEGRO  22-26½", "22-26½", 1, "11/11/2016", "", "12", "", "12", "12", "", "", "", "", "", "", "", "", "", "12", "", 0, 0, 0, 0, 0, 1, "", "", "", "", "", "12", "", "12", "FATIMAS", "10/11/2016", 0, 0, 0)
        dtDatosPartidas.Rows.Add(40, "ORGANIZACIÓN SANTILLANA", "8261", 1, "N", "Terminado", "JEANS BOTA FLORENCIA 36152 FLOR ENTERA NEGRO  22-26½", "22-26½", 1, "11/11/2016", "", "12", "", "12", "12", "", "", "", "", "", "", "", "", "", "12", "", 0, 0, 0, 0, 0, 1, "", "", "", "", "", "12", "", "12", "FATIMAS", "10/11/2016", 0, 0, 0)
        dtDatosPartidas.Rows.Add(41, "ORGANIZACIÓN SANTILLANA", "8267", 1, "N", "Terminado", "JEANS BOTA FLORENCIA 36152 FLOR ENTERA NEGRO  22-26½", "22-26½", 1, "11/11/2016", "", "12", "", "12", "12", "", "", "", "", "", "", "", "", "", "12", "", 0, 0, 0, 0, 0, 1, "", "", "", "", "", "12", "", "12", "FATIMAS", "10/11/2016", 0, 0, 0)
        dtDatosPartidas.Rows.Add(42, "ORGANIZACIÓN SANTILLANA", "8269", 1, "N", "Terminado", "JEANS BOTA FLORENCIA 36152 FLOR ENTERA NEGRO  22-26½", "22-26½", 1, "11/11/2016", "", "12", "", "12", "12", "", "", "", "", "", "", "", "", "", "12", "", 0, 0, 0, 0, 0, 1, "", "", "", "", "", "12", "", "12", "FATIMAS", "10/11/2016", 0, 0, 0)
        dtDatosPartidas.Rows.Add(43, "ORGANIZACIÓN SANTILLANA", "8273", 1, "N", "Terminado", "JEANS BOTA FLORENCIA 36152 FLOR ENTERA NEGRO  22-26½", "22-26½", 1, "11/11/2016", "", "12", "", "12", "12", "", "", "", "", "", "", "", "", "", "12", "", 0, 0, 0, 0, 0, 1, "", "", "", "", "", "12", "", "12", "FATIMAS", "10/11/2016", 0, 0, 0)
        dtDatosPartidas.Rows.Add(44, "ORGANIZACIÓN SANTILLANA", "8275", 1, "N", "Terminado", "JEANS BOTA FLORENCIA 36152 FLOR ENTERA NEGRO  22-26½", "22-26½", 1, "11/11/2016", "", "12", "", "12", "12", "", "", "", "", "", "", "", "", "", "12", "", 0, 0, 0, 0, 0, 1, "", "", "", "", "", "12", "", "12", "FATIMAS", "10/11/2016", 0, 0, 0)
        dtDatosPartidas.Rows.Add(45, "ORGANIZACIÓN SANTILLANA", "8277", 1, "N", "Terminado", "JEANS BOTA FLORENCIA 36152 FLOR ENTERA NEGRO  22-26½", "22-26½", 1, "11/11/2016", "", "12", "", "12", "12", "", "", "", "", "", "", "", "", "", "12", "", 0, 0, 0, 0, 0, 1, "", "", "", "", "", "12", "", "12", "FATIMAS", "10/11/2016", 0, 0, 0)
        dtDatosPartidas.Rows.Add(46, "ORGANIZACIÓN SANTILLANA", "8283", 1, "N", "Terminado", "JEANS BOTA FLORENCIA 36152 FLOR ENTERA NEGRO  22-26½", "22-26½", 1, "11/11/2016", "", "12", "", "12", "12", "", "", "", "", "", "", "", "", "", "12", "", 0, 0, 0, 0, 0, 1, "", "", "", "", "", "12", "", "12", "FATIMAS", "10/11/2016", 0, 0, 0)
        dtDatosPartidas.Rows.Add(47, "ORGANIZACIÓN SANTILLANA", "8286", 1, "N", "Terminado", "JEANS BOTA FLORENCIA 36152 FLOR ENTERA NEGRO  22-26½", "22-26½", 1, "11/11/2016", "", "12", "", "12", "12", "", "", "", "", "", "", "", "", "", "12", "", 0, 0, 0, 0, 0, 1, "", "", "", "", "", "12", "", "12", "FATIMAS", "10/11/2016", 0, 0, 0)
        dtDatosPartidas.Rows.Add(48, "ORGANIZACIÓN SANTILLANA", "8292", 1, "N", "Terminado", "JEANS BOTA FLORENCIA 36152 FLOR ENTERA NEGRO  22-26½", "22-26½", 1, "11/11/2016", "", "12", "", "12", "12", "", "", "", "", "", "", "", "", "", "12", "", 0, 0, 0, 0, 0, 1, "", "", "", "", "", "12", "", "12", "FATIMAS", "10/11/2016", 0, 0, 0)
        dtDatosPartidas.Rows.Add(49, "ORGANIZACIÓN SANTILLANA", "8314", 1, "N", "Terminado", "JEANS BOTA FLORENCIA 36152 FLOR ENTERA NEGRO  22-26½", "22-26½", 1, "11/11/2016", "", "12", "", "12", "12", "", "", "", "", "", "", "", "", "", "12", "", 0, 0, 0, 0, 0, 1, "", "", "", "", "", "12", "", "12", "FATIMAS", "10/11/2016", 0, 0, 0)
        dtDatosPartidas.Rows.Add(50, "GERARDO CHEVAILE RAMOS", "7925", "3", "N", "Terminado", "YUYIN CIMA 26050 CRAZY CAFE  18-21½", "18-21½", "-12", "29/10/2016", "33", "", "", "33", "17", "", "", "", "", "", "", "", "", "", "17", "", 0, 0, 0, 0, 0, 0, "", "", "", "", "", "", "", 0, "FATIMAS", "10/11/2016", 0, 0, 1)
        dtDatosPartidas.Rows.Add(51, "GERARDO CHEVAILE RAMOS", "7931", 1, "N", "Terminado", "YUYIN BOTA CIMA 26060 CRAZY CAFE  18-21½", "18-21½", 0, "10/11/2016", "32", "", "", "32", "", "", "", "", "32", "", "", "", "", "", "32", "", 0, 1, 0, 0, 0, 0, "", "", "32", "", "", "", "", "32", "FATIMAS", "10/11/2016", 0, 0, 0)
        dtDatosPartidas.Rows.Add(52, "GERARDO CHEVAILE RAMOS", "7931", "2", "N", "Terminado", "YUYIN BOTA CIMA 26060 CRAZY CAFE  15-17½", "15-17½", 0, "10/11/2016", "24", "", "", "24", "16", "", "", "", "8", "", "", "", "", "", "24", "", 0, 1, 0, 0, 0, 0, "", "", "24", "", "", "", "", "24", "FATIMAS", "10/11/2016", 0, 0, 0)
        dtDatosPartidas.Rows.Add(53, "GERARDO CHEVAILE RAMOS", "7931", "3", "N", "Terminado", "YUYIN BOTA CIMA 26060 CRAZY CAFE  22-26", "22-26", 0, "10/11/2016", "19", "", "", "19", "19", "", "", "", "", "", "", "", "", "", "19", "", 0, 1, 0, 0, 0, 0, "", "", "19", "", "", "", "", "19", "FATIMAS", "10/11/2016", 0, 0, 0)
        dtDatosPartidas.Rows.Add(54, "GERARDO CHEVAILE RAMOS", "7931", "4", "N", "Terminado", "YUYIN BOTIN ADVENTURE 25181 NOBUCK MARINO  12-14½", "12-14½", 0, "10/11/2016", "35", "", "", "35", "35", "", "", "", "", "", "", "", "", "", "35", "", 0, 1, 0, 0, 0, 0, "", "", "35", "", "", "", "", "35", "FATIMAS", "10/11/2016", 0, 0, 0)
        dtDatosPartidas.Rows.Add(55, "GERARDO CHEVAILE RAMOS", "7221", 1, "N", "Capturado", "MERANO RECCO 45452 FLOR ENTERA NEGRO  25-29½", "25-29½", "-34", "07/10/2016", "12", "", "", "12", "", "", "", "", "", "", "", "", "", "", 0, "", 0, 0, 0, 0, 0, 0, "", "", "", "", "", "", "", 0, "FATIMAS", "10/11/2016", 0, 0, 1)
        dtDatosPartidas.Rows.Add(56, "GERARDO CHEVAILE RAMOS", "3215", "2", "N", "Terminado", "JEANS BOTA FLORENCIA 36150 FLOR ENTERA NEGRO  22-26½", "22-26½", "-6", "04/11/2016", "21", "", "", "21", "", "", "", "", "", "", "", "", "", "21", "21", "", 0, 0, 0, 0, 0, 1, "", "", "", "", "", "", "21", "21", "FATIMAS", "10/11/2016", 0, 0, 0)
        dtDatosPartidas.Rows.Add(57, "GERARDO CHEVAILE RAMOS", "3216", 1, "N", "Programado", "JEANS BOTIN VENECIA 36221 FLOR ENTERA CAFE  22-26½", "22-26½", 1, "11/11/2016", "", "21", "", "21", "", "", "", "14", "", "", "", "", "", "", "14", "", 0, 0, 0, 0, 0, 0, "", "", "", "", "", "", "", 0, "FATIMAS", "10/11/2016", 0, 0, 1)
        dtDatosPartidas.Rows.Add(58, "GERARDO CHEVAILE RAMOS", "3216", "2", "N", "Programado", "JEANS BOTIN VENECIA 36220 FLOR ENTERA NEGRO  22-26½", "22-26½", 1, "11/11/2016", "", "21", "", "21", "", "", "", "", "", "", "", "", "", "", 0, "", 0, 0, 0, 0, 0, 0, "", "", "", "", "", "", "", 0, "FATIMAS", "10/11/2016", 0, 0, 1)
        dtDatosPartidas.Rows.Add(59, "GERARDO CHEVAILE RAMOS", "3216", "3", "N", "Programado", "JEANS BOTIN VENECIA 36223 FLOR ENTERA NEGRO  22-26½", "22-26½", 1, "11/11/2016", "", "21", "", "21", "", "", "", "", "", "", "", "", "", "", 0, "", 0, 0, 0, 0, 0, 0, "", "", "", "", "", "", "", 0, "FATIMAS", "10/11/2016", 0, 0, 1)
        dtDatosPartidas.Rows.Add(60, "ECOON ZAPATERIAS (ARELLANO)", "8875", "14", "N", "Programado", "JEANS BOTIN VENECIA 36221 FLOR ENTERA CAFE  22-26½", "22-26½", "-20", "04/11/2016", "36", "", "", "36", "34", "", "", "", "", "", "", "", "", "", "34", "", 1, 0, 0, 0, 0, 0, "", "34", "", "", "", "", "", "34", "FATIMAS", "10/11/2016", 0, 0, 0)
        dtDatosPartidas.Rows.Add(61, "ECOON ZAPATERIAS (ARELLANO)", "8875", "21", "N", "Programado", "JEANS MEDIA BOTA FLORENCIA 36142 FLOR ENTERA CAFE  22-26½", "22-26½", "-20", "04/11/2016", "24", "", "", "24", "24", "", "", "", "", "", "", "", "", "", "24", "", 1, 0, 0, 0, 0, 0, "", "24", "", "", "", "", "", "24", "FATIMAS", "10/11/2016", 0, 0, 0)
        dtDatosPartidas.Rows.Add(62, "ECOON ZAPATERIAS (ARELLANO)", "8875", "3", "N", "Programado", "JEANS BOTA VENECIA 36210 FLOR ENTERA CAFE  22-26½", "22-26½", "-20", "04/11/2016", "36", "", "", "36", "10", "", "", "", "", "", "", "", "", "", "10", "", 1, 0, 0, 0, 0, 0, "", "10", "", "", "", "", "", "10", "FATIMAS", "10/11/2016", 0, 0, 0)
        dtDatosPartidas.Rows.Add(63, "ECOON ZAPATERIAS (ARELLANO)", "8875", "11", "N", "Programado", "JEANS BOTIN VENECIA 36220 FLOR ENTERA CAFE  22-26½", "22-26½", "-20", "04/11/2016", "36", "", "", "36", "4", "", "", "", "", "", "", "", "", "", "4", "", 1, 0, 0, 0, 0, 0, "", "4", "", "", "", "", "", "4", "FATIMAS", "10/11/2016", 0, 0, 0)
        dtDatosPartidas.Rows.Add(64, "ECOON ZAPATERIAS (ARELLANO)", "8875", "23", "N", "Programado", "JEANS MEDIA BOTA FLORENCIA 36142 ATANADO CAJETA  22-26½", "22-26½", "-20", "04/11/2016", "24", "", "", "24", "", "", "", "", "", "", "", "24", "", "", "24", "", 0, 0, 0, 0, 0, 1, "", "", "", "", "", "", "24", "24", "FATIMAS", "10/11/2016", 0, 0, 0)
        dtDatosPartidas.Rows.Add(65, "ECOON ZAPATERIAS (ARELLANO)", "8875", "22", "N", "Programado", "JEANS MEDIA BOTA FLORENCIA 36142 FLOR ENTERA NEGRO  22-26½", "22-26½", "-20", "04/11/2016", "24", "", "", "24", "", "", "", "", "", "", "", "", "", "24", "24", "", 0, 0, 0, 0, 0, 1, "", "", "", "", "", "", "24", "24", "FATIMAS", "10/11/2016", 0, 0, 0)
        dtDatosPartidas.Rows.Add(66, "ECOON ZAPATERIAS (ARELLANO)", "8875", "16", "N", "Programado", "JEANS BOTIN VENECIA 36221 FLOR ENTERA NEGRO  22-26½", "22-26½", "-20", "04/11/2016", "36", "", "", "36", "", "", "", "4", "", "", "", "", "", "", "4", "", 0, 0, 0, 0, 0, 1, "", "", "", "", "", "", "4", "4", "FATIMAS", "10/11/2016", 0, 0, 0)
        dtDatosPartidas.Rows.Add(67, "ANTONIO DOMINGUEZ ALLON", "6823", "28", "N", "Terminado", "YUYIN BOTIN ATENAS 26281 FLOR ENTERA NEGRO  22-26½", "22-26½", "-55", "16/09/2016", "", "25", "", "25", "25", "", "", "", "", "", "", "", "", "", "25", "", 0, 0, 0, 0, 0, 0, "", "25", "", "", "", "", "", "25", "FATIMAS", "10/11/2016", 0, 1, 0)
        dtDatosPartidas.Rows.Add(68, "ANTONIO DOMINGUEZ ALLON", "9008", "8", "N", "Programado", "YUYIN BOTIN ATENAS 26280 FLOR ENTERA CAJETA  18-21½", "18-21½", 1, "11/11/2016", "", "16", "", "16", 0, "", "", "", "", "", "", "", "", "", 0, "", 0, 0, 0, 0, 0, 0, "", "", "", "", "", "", "", 0, "FATIMAS", "10/11/2016", 0, 1, 0)
        dtDatosPartidas.Rows.Add(69, "ANTONIO DOMINGUEZ ALLON", "9008", "10", "N", "Programado", "YUYIN BOTIN ATENAS 26280 FLOR ENTERA CAJETA  22-26½", "22-26½", 1, "11/11/2016", "", "16", "", "16", 0, "", "", "", "", "", "", "", "", "", 0, "", 0, 0, 0, 0, 0, 0, "", "", "", "", "", "", "", 0, "FATIMAS", "10/11/2016", 0, 1, 0)
        dtDatosPartidas.Rows.Add(70, "ANTONIO DOMINGUEZ ALLON", "9008", "16", "N", "Programado", "YUYIN BOTA ATENAS 26271 FLOR ENTERA NEGRO  15-17½", "15-17½", 1, "11/11/2016", "", "15", "", "15", 0, "", "", "", "", "", "", "", "", "", 0, "", 0, 0, 0, 0, 0, 0, "", "", "", "", "", "", "", 0, "FATIMAS", "10/11/2016", 0, 1, 0)
        dtDatosPartidas.Rows.Add(71, "ANTONIO DOMINGUEZ ALLON", "9008", "17", "N", "Programado", "YUYIN BOTA ATENAS 26271 FLOR ENTERA CAJETA  15-17½", "15-17½", 1, "11/11/2016", "", "15", "", "15", 0, "", "", "", "", "", "", "", "", "", 0, "", 0, 0, 0, 0, 0, 0, "", "", "", "", "", "", "", 0, "FATIMAS", "10/11/2016", 0, 1, 0)
        dtDatosPartidas.Rows.Add(72, "ANTONIO DOMINGUEZ ALLON", "9008", 1, "N", "Programado", "JEANS BOTA MIA 36290 FLOR ENTERA NEGRO  12-14½", "12-14½", 1, "11/11/2016", "", "12", "", "12", "12", "", "", "", "", "", "", "", "", "", "12", "", 0, 0, 0, 0, 0, 0, "", "", "12", "", "", "", "", "12", "FATIMAS", "10/11/2016", 0, 1, 0)
        dtDatosPartidas.Rows.Add(73, "ANTONIO DOMINGUEZ ALLON", "9008", "2", "N", "Programado", "JEANS BOTA MIA 36291 FLOR ENTERA NEGRO  12-14½", "12-14½", 1, "11/11/2016", "", "12", "", "12", "12", "", "", "", "", "", "", "", "", "", "12", "", 0, 0, 0, 0, 0, 0, "", "", "12", "", "", "", "", "12", "FATIMAS", "10/11/2016", 0, 1, 0)
        dtDatosPartidas.Rows.Add(74, "ANTONIO DOMINGUEZ ALLON", "9008", "3", "N", "Programado", "JEANS BOTA MIA 36291 FLOR ENTERA CAJETA  12-14½", "12-14½", 1, "11/11/2016", "", "12", "", "12", "12", "", "", "", "", "", "", "", "", "", "12", "", 0, 0, 0, 0, 0, 0, "", "", "12", "", "", "", "", "12", "FATIMAS", "10/11/2016", 0, 1, 0)
        dtDatosPartidas.Rows.Add(75, "ANTONIO DOMINGUEZ ALLON", "9008", "4", "N", "Programado", "YUYIN BOTIN SUSPIRO 26321 FLOR ENTERA ARENA  12-14½", "12-14½", 1, "11/11/2016", "", "12", "", "12", "12", "", "", "", "", "", "", "", "", "", "12", "", 0, 0, 0, 0, 0, 0, "", "", "12", "", "", "", "", "12", "FATIMAS", "10/11/2016", 0, 1, 0)
        dtDatosPartidas.Rows.Add(76, "ANTONIO DOMINGUEZ ALLON", "9008", "5", "N", "Programado", "JEANS BOTA MURALLA 36090 NAPA NEGRO  18-21½", "18-21½", 1, "11/11/2016", "", "22", "", "22", "22", "", "", "", "", "", "", "", "", "", "22", "", 0, 0, 0, 0, 0, 0, "", "", "22", "", "", "", "", "22", "FATIMAS", "10/11/2016", 0, 1, 0)
        dtDatosPartidas.Rows.Add(77, "ANTONIO DOMINGUEZ ALLON", "9008", "6", "N", "Programado", "YUYIN BOTA ATENAS 26271 FLOR ENTERA CAJETA  18-21½", "18-21½", 1, "11/11/2016", "", "18", "", "18", "18", "", "", "", "", "", "", "", "", "", "18", "", 0, 0, 0, 0, 0, 0, "", "", "18", "", "", "", "", "18", "FATIMAS", "10/11/2016", 0, 1, 0)
        dtDatosPartidas.Rows.Add(78, "ANTONIO DOMINGUEZ ALLON", "9008", "7", "N", "Programado", "YUYIN BOTA ATENAS 26271 FLOR ENTERA NEGRO  18-21½", "18-21½", 1, "11/11/2016", "", "20", "", "20", "20", "", "", "", "", "", "", "", "", "", "20", "", 0, 0, 0, 0, 0, 0, "", "", "20", "", "", "", "", "20", "FATIMAS", "10/11/2016", 0, 1, 0)
        dtDatosPartidas.Rows.Add(79, "ANTONIO DOMINGUEZ ALLON", "9008", "9", "N", "Programado", "JEANS BOTA MURALLA 36090 NAPA NEGRO  22-26½", "22-26½", 1, "11/11/2016", "", "20", "", "20", "20", "", "", "", "", "", "", "", "", "", "20", "", 0, 0, 0, 0, 0, 0, "", "", "20", "", "", "", "", "20", "FATIMAS", "10/11/2016", 0, 1, 0)
        dtDatosPartidas.Rows.Add(80, "ANTONIO DOMINGUEZ ALLON", "9008", "11", "N", "Programado", "JEANS BOTA MURALLA 36093 NAPA NEGRO  22-26½", "22-26½", 1, "11/11/2016", "", "12", "", "12", "12", "", "", "", "", "", "", "", "", "", "12", "", 0, 0, 0, 0, 0, 0, "", "", "12", "", "", "", "", "12", "FATIMAS", "10/11/2016", 0, 1, 0)
        dtDatosPartidas.Rows.Add(81, "ANTONIO DOMINGUEZ ALLON", "9008", "12", "N", "Programado", "JEANS BOTA MURALLA 36093 FLOR ENTERA CAFE  22-26½", "22-26½", 1, "11/11/2016", "", "12", "", "12", "12", "", "", "", "", "", "", "", "", "", "12", "", 0, 0, 0, 0, 0, 0, "", "", "12", "", "", "", "", "12", "FATIMAS", "10/11/2016", 0, 1, 0)
        dtDatosPartidas.Rows.Add(82, "ANTONIO DOMINGUEZ ALLON", "9008", "13", "N", "Programado", "JEANS BOTA MURALLA 36091 FLOR ENTERA CAFE  22-26½", "22-26½", 1, "11/11/2016", "", "12", "", "12", "12", "", "", "", "", "", "", "", "", "", "12", "", 0, 0, 0, 0, 0, 0, "", "", "12", "", "", "", "", "12", "FATIMAS", "10/11/2016", 0, 1, 0)
        dtDatosPartidas.Rows.Add(83, "ANTONIO DOMINGUEZ ALLON", "9008", "14", "N", "Programado", "JEANS BOTA MURALLA 36090 NAPA NEGRO  15-17½", "15-17½", 1, "11/11/2016", "", "16", "", "16", "16", "", "", "", "", "", "", "", "", "", "16", "", 0, 0, 0, 0, 0, 0, "", "", "16", "", "", "", "", "16", "FATIMAS", "10/11/2016", 0, 1, 0)
        dtDatosPartidas.Rows.Add(84, "ANTONIO DOMINGUEZ ALLON", "9008", "15", "N", "Programado", "JEANS BOTA MURALLA 36090 FLOR ENTERA CAFE  15-17½", "15-17½", 1, "11/11/2016", "", "16", "", "16", "16", "", "", "", "", "", "", "", "", "", "16", "", 0, 0, 0, 0, 0, 0, "", "", "16", "", "", "", "", "16", "FATIMAS", "10/11/2016", 0, 1, 0)
        dtDatosPartidas.Rows.Add(85, "ANTONIO DOMINGUEZ ALLON", "9008", "18", "N", "Programado", "YUYIN BOTIN SUSPIRO 26321 FLOR ENTERA ARENA  12-14½", "12-14½", 1, "11/11/2016", "", "15", "", "15", "15", "", "", "", "", "", "", "", "", "", "15", "", 0, 0, 0, 0, 0, 0, "", "", "15", "", "", "", "", "15", "FATIMAS", "10/11/2016", 0, 1, 0)

        dtResumenDiario.Rows.Clear()

        dtResumenDiario.Rows.Add("Capacidad", 2500, 2500, 2500, 2500, 2500, 1250, 13750)
        dtResumenDiario.Rows.Add("Prospectado", 97, 550, 0, 420, 270, 192, 1529)

        grdClientes.DataSource = Nothing
        grdPedidos.DataSource = Nothing
        grdPartidas.DataSource = Nothing
        grdResumenDiario.DataSource = Nothing

        grdClientes.DataSource = dtDatosCliente
        grdPedidos.DataSource = dtDatosPedidos
        grdPartidas.DataSource = dtDatosPartidas
        grdResumenDiario.DataSource = dtResumenDiario
        gridClientesDiseño(grdClientes)
        gridPedidosDiseño(grdPedidos)
        gridPartidasDiseño(grdPartidas)
        gridResumenDiseño(grdResumenDiario)

        btnArriba_Click(sender, e)
    End Sub

    Private Sub gridClientesDiseño(grid As Infragistics.Win.UltraWinGrid.UltraGrid)
        Dim IndicePrimerColumna As Integer = 0
        Dim UltimaColumna As Integer = 0
        'GUARDAMOS EL DISEÑO Y LA BANDA EN VARIABLES PARA HACER REFERENCIA A ELLOS MAS FACIL 
        Dim Layout As UltraGridLayout = grid.DisplayLayout
        Dim rootBand As UltraGridBand = Layout.Bands(0)

        rootBand.RowLayoutStyle = RowLayoutStyle.GroupLayout

        'Validamos cuantas columnas de informacion hay en el grid, pasa despues determinar la cantidad de columnas de corridas


        'FOR PARA AGREGAR LOS RESPECTIVOS GRUPOS 
        For n = 0 To rootBand.Columns.Count - 1 Step 1

            'If tipoDistribucion = 0 Then
            UltimaColumna = 50
            'Else
            '    UltimaColumna = 47
            'End If

            If (n < 16 Or n > 25) And (n < 28 Or n > 33) And (n < 35 Or n > 40) And n <> 34 Then
                Dim grupo As UltraGridGroup = rootBand.Groups.Add(rootBand.Columns(n).Header.Caption, " ")
                rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = grupo
            Else

                If n > 15 And n < 20 Then
                    If n = 16 Then
                        Dim NombreColumna As String
                        NombreColumna = "En existencia"

                        Dim Grupo As UltraGridGroup = rootBand.Groups.Add(NombreColumna, NombreColumna)
                        rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = Grupo
                    Else
                        Dim Grupo As UltraGridGroup = rootBand.Groups("En existencia")
                        rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = Grupo
                    End If
                End If

                If n > 19 And n < 26 Then
                    If n = 20 Then
                        Dim NombreColumna As String
                        NombreColumna = "Inventario en producción"

                        Dim Grupo As UltraGridGroup = rootBand.Groups.Add(NombreColumna, NombreColumna)
                        rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = Grupo
                    Else
                        Dim Grupo As UltraGridGroup = rootBand.Groups("Inventario en producción")
                        rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = Grupo
                    End If
                End If

                If n > 27 And n < 34 Then
                    If n = 28 Then
                        Dim NombreColumna As String
                        NombreColumna = "Entrega"

                        Dim Grupo As UltraGridGroup = rootBand.Groups.Add(NombreColumna, NombreColumna)
                        rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = Grupo
                    Else
                        Dim Grupo As UltraGridGroup = rootBand.Groups("Entrega")
                        rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = Grupo
                    End If
                End If

                If n > 34 And n < 41 Then
                    If n = 35 Then
                        Dim NombreColumna As String
                        NombreColumna = "Proyección"

                        Dim Grupo As UltraGridGroup = rootBand.Groups.Add(NombreColumna, NombreColumna)
                        rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = Grupo
                    Else
                        Dim Grupo As UltraGridGroup = rootBand.Groups("Proyección")
                        rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = Grupo
                    End If
                End If
            End If
        Next



        grid.DisplayLayout.Bands(0).Columns("FechaEntregaCliente").Format = "dd/MM/yyyy"
        grid.DisplayLayout.Bands(0).Columns("FechaProgramacion").Format = "dd/MM/yyyy"
        'grid.DisplayLayout.Bands(0).Columns("FECHAENTREGA").Hidden = True
        grid.DisplayLayout.Bands(0).Columns("P").Hidden = True



        'grid.DisplayLayout.Bands(0).Columns("PENDIENTECONATRASO").Hidden = True
        'grid.DisplayLayout.Bands(0).Columns("PENDIENTESEMANAPROSPECTA").Hidden = True
        'grid.DisplayLayout.Bands(0).Columns("PORADELANTAR").Hidden = True
        'grid.DisplayLayout.Bands(0).Columns("TOTALPARES").Hidden = True
        'grid.DisplayLayout.Bands(0).Columns("INVENTARIO").Hidden = True
        'grid.DisplayLayout.Bands(0).Columns("APARTADOPORCONFIRMAR").Hidden = True



        'grid.DisplayLayout.Bands(0).Columns("#").Header.Caption = "#"
        'grid.DisplayLayout.Bands(0).Columns("Cliente").Header.Caption = "Cliente"
        'grid.DisplayLayout.Bands(0).Columns("PROSPECTADO").Header.Caption = "Prospectado"
        'grid.DisplayLayout.Bands(0).Columns("Editando").Header.Caption = "Editando"
        'grid.DisplayLayout.Bands(0).Columns("PARTIDASCOMPLETAS").Header.Caption = "PC"
        'grid.DisplayLayout.Bands(0).Columns("BLOQUEADOENTREGACOBRANZA").Header.Caption = "B"
        'grid.DisplayLayout.Bands(0).Columns("PLAZOCERO").Header.Caption = "PL"
        'grid.DisplayLayout.Bands(0).Columns("COTIZACIONESPAGADAS").Header.Caption = "Cots Pagadas"
        'grid.DisplayLayout.Bands(0).Columns("COTIZACIONESPAGOPENDIENTE").Header.Caption = "Cots Pend"
        ''grid.DisplayLayout.Bands(0).Columns("CONFIRMACIONCLIENTE").Header.Caption = ""
        'grid.DisplayLayout.Bands(0).Columns("DIASPARALAPROXIMAENTREGA").Header.Caption = "Días Entrega"
        'grid.DisplayLayout.Bands(0).Columns("PENDIENTECONATRASO").Header.Caption = "Pend Atraso Inicial"
        'grid.DisplayLayout.Bands(0).Columns("PENDIENTESEMANAPROSPECTA").Header.Caption = "Pend Prospecta Inicial"
        'grid.DisplayLayout.Bands(0).Columns("PORADELANTAR").Header.Caption = "Por Adelantar Inicial"
        'grid.DisplayLayout.Bands(0).Columns("TOTALPARES").Header.Caption = "Total Pares Inicial"
        'grid.DisplayLayout.Bands(0).Columns("INVENTARIO").Header.Caption = "Inventario Inicial"
        'grid.DisplayLayout.Bands(0).Columns("APARTADOPORCONFIRMAR").Header.Caption = "Ap Confirmar Inicial"
        'grid.DisplayLayout.Bands(0).Columns("PENDIENTECONATRASOACTUAL").Header.Caption = "Pend Atraso"
        'grid.DisplayLayout.Bands(0).Columns("PENDIENTESEMANAPROSPECTAACTUAL").Header.Caption = "Pend Prospecta"
        'grid.DisplayLayout.Bands(0).Columns("PORADELANTARACTUAL").Header.Caption = "Por Adelantar"
        'grid.DisplayLayout.Bands(0).Columns("TOTALPARESACTUAL").Header.Caption = "Total Pares"
        'grid.DisplayLayout.Bands(0).Columns("INVENTARIOACTUAL").Header.Caption = "Inventario"
        'grid.DisplayLayout.Bands(0).Columns("APARTADOPORCONFIRMARACTUAL").Header.Caption = "Ap Confirmar"
        'grid.DisplayLayout.Bands(0).Columns("V_Inv").Header.Caption = "V"
        'grid.DisplayLayout.Bands(0).Columns("S_Inv").Header.Caption = "S"
        'grid.DisplayLayout.Bands(0).Columns("L_Inv").Header.Caption = "L"
        'grid.DisplayLayout.Bands(0).Columns("Ma_Inv").Header.Caption = "M"
        'grid.DisplayLayout.Bands(0).Columns("Mi_Inv").Header.Caption = "M"
        'grid.DisplayLayout.Bands(0).Columns("J_Inv").Header.Caption = "J"
        'grid.DisplayLayout.Bands(0).Columns("L_Ent").Header.Caption = "L"
        'grid.DisplayLayout.Bands(0).Columns("Ma_Ent").Header.Caption = "M"
        'grid.DisplayLayout.Bands(0).Columns("Mi_Ent").Header.Caption = "M"
        'grid.DisplayLayout.Bands(0).Columns("J_Ent").Header.Caption = "J"
        'grid.DisplayLayout.Bands(0).Columns("V_Ent").Header.Caption = "V"
        'grid.DisplayLayout.Bands(0).Columns("S_Ent").Header.Caption = "S"
        'grid.DisplayLayout.Bands(0).Columns("P").Header.Caption = "P"
        'grid.DisplayLayout.Bands(0).Columns("V_Proy").Header.Caption = "V"
        'grid.DisplayLayout.Bands(0).Columns("S_Proy").Header.Caption = "S"
        'grid.DisplayLayout.Bands(0).Columns("L_Proy").Header.Caption = "L"
        'grid.DisplayLayout.Bands(0).Columns("Ma_Proy").Header.Caption = "M"
        'grid.DisplayLayout.Bands(0).Columns("Mi_Proy").Header.Caption = "M"
        'grid.DisplayLayout.Bands(0).Columns("J_Proy").Header.Caption = "J"
        'grid.DisplayLayout.Bands(0).Columns("SUMA").Header.Caption = "Suma"
        'grid.DisplayLayout.Bands(0).Columns("CANTIDADDEPEDIDOS").Header.Caption = "Cant Pedidos"
        'grid.DisplayLayout.Bands(0).Columns("CANTIDADTOTALDEPARTIDAS").Header.Caption = "Cant Partidas"
        'grid.DisplayLayout.Bands(0).Columns("CANTIDADDEPEDIDOSAPROSPECTAR").Header.Caption = "Cant Pedidos Pros"
        'grid.DisplayLayout.Bands(0).Columns("CANTIDADDEPARTIDASAPROSPECTAR").Header.Caption = "Cant Partidas Pros"
        'grid.DisplayLayout.Bands(0).Columns("TOTALDEPARESAPROSPECTAR").Header.Caption = "Pares Prospectar"
        'grid.DisplayLayout.Bands(0).Columns("USUARIO").Header.Caption = "Usuario"
        'grid.DisplayLayout.Bands(0).Columns("FECHA").Header.Caption = "Fecha"
        'grid.DisplayLayout.Bands(0).Columns("FECHAENTREGA").Header.Caption = ""

        grid.DisplayLayout.UseFixedHeaders = True
        'grid.DisplayLayout.Bands(0).Override.FixedHeaderIndicator = FixedHeaderIndicator.None

        grid.DisplayLayout.Bands(0).Columns("_").Header.Caption = ""
        grid.DisplayLayout.Bands(0).Groups("_").Header.Fixed = True
        grid.DisplayLayout.Bands(0).Columns("_").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
        grid.DisplayLayout.Bands(0).Columns("_").AllowRowFiltering = DefaultableBoolean.False
        grid.DisplayLayout.Bands(0).Columns("#").Header.Caption = "#"
        grid.DisplayLayout.Bands(0).Groups("#").Header.Fixed = True
        grid.DisplayLayout.Bands(0).Columns("Cliente").Header.Caption = "Cliente"
        grid.DisplayLayout.Bands(0).Groups("Cliente").Header.Fixed = True
        grid.DisplayLayout.Bands(0).Columns("PROSPECTADO").Header.Caption = "PR"
        grid.DisplayLayout.Bands(0).Columns("Editando").Header.Caption = "Editando"
        grid.DisplayLayout.Bands(0).Columns("PARTIDASCOMPLETAS").Header.Caption = "PC"
        grid.DisplayLayout.Bands(0).Columns("BLOQUEADOENTREGACOBRANZA").Header.Caption = "BE"
        grid.DisplayLayout.Bands(0).Columns("PLAZOCERO").Header.Caption = "P-0"
        grid.DisplayLayout.Bands(0).Columns("COTIZACIONES").Header.Caption = "COT"
        grid.DisplayLayout.Bands(0).Columns("DIASPARALAPROXIMAENTREGA").Header.Caption = "Días E"
        grid.DisplayLayout.Bands(0).Columns("FechaEntregaCliente").Header.Caption = "F Cliente"
        grid.DisplayLayout.Bands(0).Columns("FechaProgramacion").Header.Caption = "F Programación"
        grid.DisplayLayout.Bands(0).Columns("PENDIENTECONATRASO").Header.Caption = "Total atrasado"
        grid.DisplayLayout.Bands(0).Columns("PENDIENTESEMANAPROSPECTA").Header.Caption = "Total prospecta"
        grid.DisplayLayout.Bands(0).Columns("PORADELANTAR").Header.Caption = "Por adelantar"
        grid.DisplayLayout.Bands(0).Columns("TOTALPARES").Header.Caption = "Total"
        grid.DisplayLayout.Bands(0).Columns("INVENTARIO").Header.Caption = "Inventario"
        grid.DisplayLayout.Bands(0).Columns("BLOQUEADOS").Header.Caption = "BC"
        grid.DisplayLayout.Bands(0).Columns("REPROCESO").Header.Caption = "RP"
        grid.DisplayLayout.Bands(0).Columns("APARTADOPORCONFIRMAR").Header.Caption = "Apartado"
        grid.DisplayLayout.Bands(0).Columns("V_Inv").Header.Caption = "V"
        grid.DisplayLayout.Bands(0).Columns("S_Inv").Header.Caption = "S"
        grid.DisplayLayout.Bands(0).Columns("L_Inv").Header.Caption = "L"
        grid.DisplayLayout.Bands(0).Columns("Ma_Inv").Header.Caption = "M"
        grid.DisplayLayout.Bands(0).Columns("Mi_Inv").Header.Caption = "M"
        grid.DisplayLayout.Bands(0).Columns("J_Inv").Header.Caption = "J"
        grid.DisplayLayout.Bands(0).Columns("SUMA").Header.Caption = "Disponible"
        grid.DisplayLayout.Bands(0).Columns("Sumaalmomentodeguardar").Header.Caption = "Anterior disponible"
        grid.DisplayLayout.Bands(0).Columns("L_Ent").Header.Caption = "L"
        grid.DisplayLayout.Bands(0).Columns("Ma_Ent").Header.Caption = "M"
        grid.DisplayLayout.Bands(0).Columns("Mi_Ent").Header.Caption = "M"
        grid.DisplayLayout.Bands(0).Columns("J_Ent").Header.Caption = "J"
        grid.DisplayLayout.Bands(0).Columns("V_Ent").Header.Caption = "V"
        grid.DisplayLayout.Bands(0).Columns("S_Ent").Header.Caption = "S"
        grid.DisplayLayout.Bands(0).Columns("P").Header.Caption = "P"
        grid.DisplayLayout.Bands(0).Columns("V_Proy").Header.Caption = "V "
        grid.DisplayLayout.Bands(0).Columns("S_Proy").Header.Caption = "S"
        grid.DisplayLayout.Bands(0).Columns("L_Proy").Header.Caption = "L"
        grid.DisplayLayout.Bands(0).Columns("Ma_Proy").Header.Caption = "M"
        grid.DisplayLayout.Bands(0).Columns("Mi_Proy").Header.Caption = "M"
        grid.DisplayLayout.Bands(0).Columns("J_Proy").Header.Caption = "J"
        grid.DisplayLayout.Bands(0).Columns("CANTIDADDEPEDIDOS").Header.Caption = "Pedidos"
        grid.DisplayLayout.Bands(0).Columns("CANTIDADTOTALDEPARTIDAS").Header.Caption = "Partidas"
        grid.DisplayLayout.Bands(0).Columns("CANTIDADDEPEDIDOSAPROSPECTAR").Header.Caption = "Pedidos PR"
        grid.DisplayLayout.Bands(0).Columns("CANTIDADDEPARTIDASAPROSPECTAR").Header.Caption = "Partidas PR"
        grid.DisplayLayout.Bands(0).Columns("TOTALDEPARESAPROSPECTAR").Header.Caption = "Total PR"
        grid.DisplayLayout.Bands(0).Columns("USUARIO").Header.Caption = "Usuario"
        grid.DisplayLayout.Bands(0).Columns("FECHA").Header.Caption = "Fecha"


        grid.DisplayLayout.Bands(0).Columns("L_Ent").AllowRowFiltering = DefaultableBoolean.False
        grid.DisplayLayout.Bands(0).Columns("L_Ent").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
        grid.DisplayLayout.Bands(0).Columns("Ma_Ent").AllowRowFiltering = DefaultableBoolean.False
        grid.DisplayLayout.Bands(0).Columns("Ma_Ent").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
        grid.DisplayLayout.Bands(0).Columns("Mi_Ent").AllowRowFiltering = DefaultableBoolean.False
        grid.DisplayLayout.Bands(0).Columns("Mi_Ent").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
        grid.DisplayLayout.Bands(0).Columns("J_Ent").AllowRowFiltering = DefaultableBoolean.False
        grid.DisplayLayout.Bands(0).Columns("J_Ent").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
        grid.DisplayLayout.Bands(0).Columns("V_Ent").AllowRowFiltering = DefaultableBoolean.False
        grid.DisplayLayout.Bands(0).Columns("V_Ent").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
        grid.DisplayLayout.Bands(0).Columns("S_Ent").AllowRowFiltering = DefaultableBoolean.False
        grid.DisplayLayout.Bands(0).Columns("S_Ent").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit

        grid.DisplayLayout.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
        grid.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grid.DisplayLayout.Override.RowSelectorWidth = 20
        grid.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
        'grid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grid.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
        'grid.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
        grid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No

        grid.DisplayLayout.Bands(0).Columns("#").Width = 25
        grid.DisplayLayout.Bands(0).Columns("_").Width = 25
        'grid.DisplayLayout.Bands(0).Columns("Total").Width = 25
        'grid.DisplayLayout.Bands(0).Columns("Conf").Width = 25
        'grid.DisplayLayout.Bands(0).Columns("Faltante").Width = 25
        'grid.DisplayLayout.Bands(0).Columns("Modelo").Width = 40


        Dim width As Integer
        For Each col As UltraGridColumn In grid.Rows.Band.Columns
            If col.DataType <> System.Type.GetType("System.Boolean") Then
                col.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                col.CharacterCasing = CharacterCasing.Upper
            End If
            If Not col.Hidden Then
                width += col.Width
            End If
        Next

        For Each Row As UltraGridRow In grdClientes.Rows
            If Row.Cells("BLOQUEADOENTREGACOBRANZA").Value = "S" Then
                'Row.Cells("_").Hidden = True
                Row.Appearance.BackColor = Color.LightGray
                Row.Cells("L_Ent").Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                Row.Cells("Ma_Ent").Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                Row.Cells("Mi_Ent").Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                Row.Cells("J_Ent").Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                Row.Cells("V_Ent").Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                Row.Cells("S_Ent").Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            End If
            If Row.Cells("PLAZOCERO").Value = "S" And Row.Cells("COTIZACIONES").Value = "" Then
                Row.Appearance.BackColor = Color.LightGray
                Row.Cells("L_Ent").Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                Row.Cells("Ma_Ent").Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                Row.Cells("Mi_Ent").Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                Row.Cells("J_Ent").Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                Row.Cells("V_Ent").Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                Row.Cells("S_Ent").Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            End If
            If Row.Cells("TOTALDEPARESAPROSPECTAR").Value = 0 Then
                Row.Appearance.BackColor = Color.LightGray
                Row.Cells("L_Ent").Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                Row.Cells("Ma_Ent").Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                Row.Cells("Mi_Ent").Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                Row.Cells("J_Ent").Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                Row.Cells("V_Ent").Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                Row.Cells("S_Ent").Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            End If
            'Row.Cells("DIASPARALAPROXIMAENTREGA").ToolTipText = Row.Cells("FechaEntregaCliente").Value.ToString()
            If Row.Cells("DIASPARALAPROXIMAENTREGA").Value < 0 Then
                Row.Cells("DIASPARALAPROXIMAENTREGA").Appearance.ForeColor = Color.Red
            End If

            If Row.Cells("Editando").Value <> "" Then
                Row.Cells("Editando").Appearance.ForeColor = Color.Red
            End If
            If Row.Cells("PENDIENTECONATRASO").Value <> "" Then
                Row.Cells("PENDIENTECONATRASO").Appearance.ForeColor = Color.Red
            End If

            If Row.Cells("#").Value = 1 Then
                Row.Cells("COTIZACIONES").Appearance.BackColor = pnlTodasCot.BackColor
            End If
            If Row.Cells("#").Value = 4 Then
                Row.Cells("COTIZACIONES").Appearance.BackColor = pnlAlgunasCot.BackColor
            End If
            If Row.Cells("#").Value = 5 Then
                Row.Cells("COTIZACIONES").Appearance.BackColor = pnlNingunaCot.BackColor
            End If
        Next

        For Each col As UltraGridColumn In grid.Rows.Band.Columns
            For Each row As UltraGridRow In grid.Rows
                If IsNumeric(row.Cells(col).Value) Then
                    row.Cells(col).Appearance.TextHAlign = HAlign.Right
                End If
            Next
        Next



    End Sub

    Private Sub gridPedidosDiseño(grid As Infragistics.Win.UltraWinGrid.UltraGrid)

        Dim IndicePrimerColumna As Integer = 0
        Dim UltimaColumna As Integer = 0
        'GUARDAMOS EL DISEÑO Y LA BANDA EN VARIABLES PARA HACER REFERENCIA A ELLOS MAS FACIL 
        Dim Layout As UltraGridLayout = grid.DisplayLayout
        Dim rootBand As UltraGridBand = Layout.Bands(0)

        rootBand.RowLayoutStyle = RowLayoutStyle.GroupLayout

        'Validamos cuantas columnas de informacion hay en el grid, pasa despues determinar la cantidad de columnas de corridas


        'FOR PARA AGREGAR LOS RESPECTIVOS GRUPOS 
        For n = 0 To rootBand.Columns.Count - 1 Step 1

            'If tipoDistribucion = 0 Then
            UltimaColumna = 50
            'Else
            '    UltimaColumna = 47
            'End If

            If (n < 15 Or n > 24) And (n < 27 Or n > 32) And (n < 32 Or n > 39) And n <> 33 And n < 45 Then
                Dim grupo As UltraGridGroup = rootBand.Groups.Add(rootBand.Columns(n).Header.Caption, " ")
                rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = grupo
            Else

                If n > 14 And n < 19 Then
                    If n = 15 Then
                        Dim NombreColumna As String
                        NombreColumna = "En existencia"

                        Dim Grupo As UltraGridGroup = rootBand.Groups.Add(NombreColumna)
                        rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = Grupo
                    Else
                        Dim Grupo As UltraGridGroup = rootBand.Groups("En existencia")
                        rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = Grupo
                    End If
                End If

                If n > 18 And n < 25 Then
                    If n = 19 Then
                        Dim NombreColumna As String
                        NombreColumna = "Inventario en producción"

                        Dim Grupo As UltraGridGroup = rootBand.Groups.Add(NombreColumna)
                        rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = Grupo
                    Else
                        Dim Grupo As UltraGridGroup = rootBand.Groups("Inventario en producción")
                        rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = Grupo
                    End If
                End If

                If n > 26 And n < 33 Then
                    If n = 27 Then
                        Dim NombreColumna As String
                        NombreColumna = "Entrega"

                        Dim Grupo As UltraGridGroup = rootBand.Groups.Add(NombreColumna)
                        rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = Grupo
                    Else
                        Dim Grupo As UltraGridGroup = rootBand.Groups("Entrega")
                        rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = Grupo
                    End If
                End If

                If n > 33 And n < 40 Then
                    If n = 34 Then
                        Dim NombreColumna As String
                        NombreColumna = "Proyección"

                        Dim Grupo As UltraGridGroup = rootBand.Groups.Add(NombreColumna)
                        rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = Grupo
                    Else
                        Dim Grupo As UltraGridGroup = rootBand.Groups("Proyección")
                        rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = Grupo
                    End If
                End If
            End If
        Next

        grid.DisplayLayout.Bands(0).Columns("FechaEntregaCliente").Format = "dd/MM/yyyy"
        grid.DisplayLayout.Bands(0).Columns("FechaProgramacion").Format = "dd/MM/yyyy"
        'grid.DisplayLayout.Bands(0).Columns("FECHAENTREGA").Hidden = True
        grid.DisplayLayout.Bands(0).Columns("P").Hidden = True
        grid.DisplayLayout.Bands(0).Columns("PlazoCeroSinCot").Hidden = True

        'grid.DisplayLayout.Bands(0).Columns("PENDIENTECONATRASO").Hidden = True
        'grid.DisplayLayout.Bands(0).Columns("PENDIENTESEMANAPROSPECTA").Hidden = True
        'grid.DisplayLayout.Bands(0).Columns("PORADELANTAR").Hidden = True
        'grid.DisplayLayout.Bands(0).Columns("TOTALPARES").Hidden = True
        'grid.DisplayLayout.Bands(0).Columns("INVENTARIO").Hidden = True
        'grid.DisplayLayout.Bands(0).Columns("APARTADOPORCONFIRMAR").Hidden = True
        'grid.DisplayLayout.Bands(0).Columns("BLOQUEADOENTREGACOBRANZA").Hidden = True

        grid.DisplayLayout.Bands(0).Columns("_").Header.Caption = ""
        grid.DisplayLayout.Bands(0).Columns("_").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
        grid.DisplayLayout.Bands(0).Columns("_").AllowRowFiltering = DefaultableBoolean.False

        'grid.DisplayLayout.Bands(0).Columns("#").Header.Caption = "#"
        'grid.DisplayLayout.Bands(0).Columns("CLIENTE").Header.Caption = "Cliente"
        'grid.DisplayLayout.Bands(0).Columns("PEDIDOSAY").Header.Caption = "Pedido SAY"
        'grid.DisplayLayout.Bands(0).Columns("PEDIDOSICY").Header.Caption = "Pedido SICY"
        'grid.DisplayLayout.Bands(0).Columns("PROSPECTADO").Header.Caption = "Prospectado"
        'grid.DisplayLayout.Bands(0).Columns("STATUS").Header.Caption = "Status"
        'grid.DisplayLayout.Bands(0).Columns("COTIZACIONESPAGADAS").Header.Caption = "Cots Pagadas"
        'grid.DisplayLayout.Bands(0).Columns("COTIZACIONESPAGOPENDIENTE").Header.Caption = "Cots Pend"
        'grid.DisplayLayout.Bands(0).Columns("DIASPARALAPROXIMAENTREGA").Header.Caption = "Días Entrega"
        'grid.DisplayLayout.Bands(0).Columns("PENDIENTECONATRASO").Header.Caption = "Pend Atraso Inicial"
        'grid.DisplayLayout.Bands(0).Columns("PENDIENTESEMANAPROSPECTA").Header.Caption = "Pend Prospecta Inicial"
        'grid.DisplayLayout.Bands(0).Columns("PORADELANTAR").Header.Caption = "Por Adelantar Inicial"
        'grid.DisplayLayout.Bands(0).Columns("TOTALPARES").Header.Caption = "Total Pares Inicial"
        'grid.DisplayLayout.Bands(0).Columns("INVENTARIO").Header.Caption = "Inventario Inicial"
        'grid.DisplayLayout.Bands(0).Columns("APARTADOPORCONFIRMAR").Header.Caption = "Ap Confirmar Inicial"
        'grid.DisplayLayout.Bands(0).Columns("PENDIENTECONATRASOACTUAL").Header.Caption = "Pend Atraso"
        'grid.DisplayLayout.Bands(0).Columns("PENDIENTESEMANAPROSPECTAACTUAL").Header.Caption = "Pend Prospecta"
        'grid.DisplayLayout.Bands(0).Columns("PORADELANTARACTUAL").Header.Caption = "Por Adelantar"
        'grid.DisplayLayout.Bands(0).Columns("TOTALPARESACTUAL").Header.Caption = "Total Pares"
        'grid.DisplayLayout.Bands(0).Columns("INVENTARIOACTUAL").Header.Caption = "Inventario"
        'grid.DisplayLayout.Bands(0).Columns("APARTADOPORCONFIRMARACTUAL").Header.Caption = "Ap Confirmar"
        'grid.DisplayLayout.Bands(0).Columns("V_Inv").Header.Caption = "V"
        'grid.DisplayLayout.Bands(0).Columns("S_Inv").Header.Caption = "S"
        'grid.DisplayLayout.Bands(0).Columns("L_Inv").Header.Caption = "L"
        'grid.DisplayLayout.Bands(0).Columns("Ma_Inv").Header.Caption = "M"
        'grid.DisplayLayout.Bands(0).Columns("Mi_Inv").Header.Caption = "M"
        'grid.DisplayLayout.Bands(0).Columns("J_Inv").Header.Caption = "J"
        'grid.DisplayLayout.Bands(0).Columns("L_Ent").Header.Caption = "L"
        'grid.DisplayLayout.Bands(0).Columns("Ma_Ent").Header.Caption = "M"
        'grid.DisplayLayout.Bands(0).Columns("Mi_Ent").Header.Caption = "M"
        'grid.DisplayLayout.Bands(0).Columns("J_Ent").Header.Caption = "J"
        'grid.DisplayLayout.Bands(0).Columns("V_Ent").Header.Caption = "V"
        'grid.DisplayLayout.Bands(0).Columns("S_Ent").Header.Caption = "S"
        'grid.DisplayLayout.Bands(0).Columns("P").Header.Caption = "P"
        'grid.DisplayLayout.Bands(0).Columns("V_Proy").Header.Caption = "V"
        'grid.DisplayLayout.Bands(0).Columns("S_Proy").Header.Caption = "S"
        'grid.DisplayLayout.Bands(0).Columns("L_Proy").Header.Caption = "L"
        'grid.DisplayLayout.Bands(0).Columns("Ma_Proy").Header.Caption = "M"
        'grid.DisplayLayout.Bands(0).Columns("Mi_Proy").Header.Caption = "M"
        'grid.DisplayLayout.Bands(0).Columns("J_Proy").Header.Caption = "J"
        'grid.DisplayLayout.Bands(0).Columns("SUMA").Header.Caption = "Suma"
        'grid.DisplayLayout.Bands(0).Columns("CANTIDADTOTALDEPARTIDAS").Header.Caption = "Cant Partidas"
        'grid.DisplayLayout.Bands(0).Columns("CANTIDADDEPARTIDASAPROSPECTAR").Header.Caption = "Cant Partidas Pros"
        'grid.DisplayLayout.Bands(0).Columns("TOTALDEPARESAPROSPECTAR").Header.Caption = ""
        'grid.DisplayLayout.Bands(0).Columns("USUARIO").Header.Caption = "Usuario"
        'grid.DisplayLayout.Bands(0).Columns("FECHA").Header.Caption = "Fecha"
        'grid.DisplayLayout.Bands(0).Columns("FECHAENTREGA").Header.Caption = ""
        grid.DisplayLayout.UseFixedHeaders = True
        grid.DisplayLayout.Bands(0).Override.FixedHeaderIndicator = FixedHeaderIndicator.None

        grid.DisplayLayout.Bands(0).Columns("#").Header.Caption = "#"
        grid.DisplayLayout.Bands(0).Groups("#").Header.Fixed = True
        grid.DisplayLayout.Bands(0).Columns("_").Header.Caption = ""
        grid.DisplayLayout.Bands(0).Groups("_").Header.Fixed = True
        grid.DisplayLayout.Bands(0).Columns("Cliente").Header.Caption = "Cliente"
        grid.DisplayLayout.Bands(0).Groups("Cliente").Header.Fixed = True
        grid.DisplayLayout.Bands(0).Columns("PEDIDOSAY").Header.Caption = "Pedido SAY"
        grid.DisplayLayout.Bands(0).Groups("PEDIDOSAY").Header.Fixed = True
        grid.DisplayLayout.Bands(0).Columns("PEDIDOSICY").Header.Caption = "Pedido SICY"
        grid.DisplayLayout.Bands(0).Groups("PEDIDOSICY").Header.Fixed = True
        grid.DisplayLayout.Bands(0).Columns("PROSPECTADO").Header.Caption = "PR"
        grid.DisplayLayout.Bands(0).Columns("STATUS").Header.Caption = "Status"
        grid.DisplayLayout.Bands(0).Columns("COTIZACIONES").Header.Caption = "COT"
        grid.DisplayLayout.Bands(0).Columns("DIASPARALAPROXIMAENTREGA").Header.Caption = "Días E"
        grid.DisplayLayout.Bands(0).Columns("FechaEntregaCliente").Header.Caption = "F Cliente"
        grid.DisplayLayout.Bands(0).Columns("FechaProgramacion").Header.Caption = "F Programación"
        grid.DisplayLayout.Bands(0).Columns("PENDIENTECONATRASO").Header.Caption = "Total atrasado"
        grid.DisplayLayout.Bands(0).Columns("PENDIENTESEMANAPROSPECTA").Header.Caption = "Total prospecta"
        grid.DisplayLayout.Bands(0).Columns("PORADELANTAR").Header.Caption = "Por adelantar"
        grid.DisplayLayout.Bands(0).Columns("TOTALPARES").Header.Caption = "Total"
        grid.DisplayLayout.Bands(0).Columns("INVENTARIO").Header.Caption = "Inventario"
        grid.DisplayLayout.Bands(0).Columns("BLOQUEADOS").Header.Caption = "BC"
        grid.DisplayLayout.Bands(0).Columns("REPROCESO").Header.Caption = "RP"
        grid.DisplayLayout.Bands(0).Columns("APARTADOPORCONFIRMAR").Header.Caption = "Apartado"
        grid.DisplayLayout.Bands(0).Columns("V_Inv").Header.Caption = "V"
        grid.DisplayLayout.Bands(0).Columns("S_Inv").Header.Caption = "S"
        grid.DisplayLayout.Bands(0).Columns("L_Inv").Header.Caption = "L"
        grid.DisplayLayout.Bands(0).Columns("Ma_Inv").Header.Caption = "M"
        grid.DisplayLayout.Bands(0).Columns("Mi_Inv").Header.Caption = "M"
        grid.DisplayLayout.Bands(0).Columns("J_Inv").Header.Caption = "J"
        grid.DisplayLayout.Bands(0).Columns("SUMA").Header.Caption = "Disponible"
        grid.DisplayLayout.Bands(0).Columns("Sumaalmomentodeguardar").Header.Caption = "Anterior disponible"
        grid.DisplayLayout.Bands(0).Columns("L_Ent").Header.Caption = "L"
        grid.DisplayLayout.Bands(0).Columns("Ma_Ent").Header.Caption = "M"
        grid.DisplayLayout.Bands(0).Columns("Mi_Ent").Header.Caption = "M"
        grid.DisplayLayout.Bands(0).Columns("J_Ent").Header.Caption = "J"
        grid.DisplayLayout.Bands(0).Columns("V_Ent").Header.Caption = "V"
        grid.DisplayLayout.Bands(0).Columns("S_Ent").Header.Caption = "S"
        grid.DisplayLayout.Bands(0).Columns("P").Header.Caption = ""
        grid.DisplayLayout.Bands(0).Columns("V_Proy").Header.Caption = "V "
        grid.DisplayLayout.Bands(0).Columns("S_Proy").Header.Caption = "S"
        grid.DisplayLayout.Bands(0).Columns("L_Proy").Header.Caption = "L"
        grid.DisplayLayout.Bands(0).Columns("Ma_Proy").Header.Caption = "M"
        grid.DisplayLayout.Bands(0).Columns("Mi_Proy").Header.Caption = "M"
        grid.DisplayLayout.Bands(0).Columns("J_Proy").Header.Caption = "J"
        grid.DisplayLayout.Bands(0).Columns("CANTIDADTOTALDEPARTIDAS").Header.Caption = "Partidas"
        grid.DisplayLayout.Bands(0).Columns("CANTIDADDEPARTIDASAPROSPECTAR").Header.Caption = "Partidas PR"
        grid.DisplayLayout.Bands(0).Columns("TOTALDEPARESAPROSPECTAR").Header.Caption = "Total PR"
        grid.DisplayLayout.Bands(0).Columns("USUARIO").Header.Caption = "Usuario"
        grid.DisplayLayout.Bands(0).Columns("FECHA").Header.Caption = "Fecha"
        grid.DisplayLayout.Bands(0).Columns("BLOQUEADOENTREGACOBRANZA").Header.Caption = "Bloqueado"
        grid.DisplayLayout.Bands(0).Columns("BLOQUEADOENTREGACOBRANZA").Hidden = True
        grid.DisplayLayout.Bands(0).Columns("ClienteID").Header.Caption = "Cliente"
        grid.DisplayLayout.Bands(0).Columns("ClienteID").Hidden = True


        grid.DisplayLayout.Bands(0).Columns("L_Ent").AllowRowFiltering = DefaultableBoolean.False
        grid.DisplayLayout.Bands(0).Columns("L_Ent").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
        grid.DisplayLayout.Bands(0).Columns("Ma_Ent").AllowRowFiltering = DefaultableBoolean.False
        grid.DisplayLayout.Bands(0).Columns("Ma_Ent").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
        grid.DisplayLayout.Bands(0).Columns("Mi_Ent").AllowRowFiltering = DefaultableBoolean.False
        grid.DisplayLayout.Bands(0).Columns("Mi_Ent").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
        grid.DisplayLayout.Bands(0).Columns("J_Ent").AllowRowFiltering = DefaultableBoolean.False
        grid.DisplayLayout.Bands(0).Columns("J_Ent").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
        grid.DisplayLayout.Bands(0).Columns("V_Ent").AllowRowFiltering = DefaultableBoolean.False
        grid.DisplayLayout.Bands(0).Columns("V_Ent").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
        grid.DisplayLayout.Bands(0).Columns("S_Ent").AllowRowFiltering = DefaultableBoolean.False
        grid.DisplayLayout.Bands(0).Columns("S_Ent").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit

        grid.DisplayLayout.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
        grid.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grid.DisplayLayout.Override.RowSelectorWidth = 20
        grid.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
        'grid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grid.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
        'grid.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
        grid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No

        grid.DisplayLayout.Bands(0).Columns("#").Width = 25
        grid.DisplayLayout.Bands(0).Columns("_").Width = 25
        'grid.DisplayLayout.Bands(0).Columns("Total").Width = 25
        'grid.DisplayLayout.Bands(0).Columns("Conf").Width = 25
        'grid.DisplayLayout.Bands(0).Columns("Faltante").Width = 25
        'grid.DisplayLayout.Bands(0).Columns("Modelo").Width = 40


        Dim width As Integer
        For Each col As UltraGridColumn In grid.Rows.Band.Columns
            If col.DataType <> System.Type.GetType("System.Boolean") Then
                col.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                col.CharacterCasing = CharacterCasing.Upper
            End If
            If Not col.Hidden Then
                width += col.Width
            End If
        Next

        For Each Row As UltraGridRow In grdPedidos.Rows
            If Row.Cells("BLOQUEADOENTREGACOBRANZA").Value = 1 Then
                'Row.Cells("_").Hidden = True
                Row.Appearance.BackColor = Color.LightGray
                Row.Cells("L_Ent").Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                Row.Cells("Ma_Ent").Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                Row.Cells("Mi_Ent").Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                Row.Cells("J_Ent").Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                Row.Cells("V_Ent").Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                Row.Cells("S_Ent").Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            End If
            If Row.Cells("PlazoCeroSinCot").Value = 1 Then
                Row.Appearance.BackColor = Color.LightGray
                Row.Cells("L_Ent").Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                Row.Cells("Ma_Ent").Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                Row.Cells("Mi_Ent").Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                Row.Cells("J_Ent").Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                Row.Cells("V_Ent").Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                Row.Cells("S_Ent").Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            End If
            If Row.Cells("TOTALDEPARESAPROSPECTAR").Value = "0" Or Row.Cells("TOTALDEPARESAPROSPECTAR").Value = "" Then
                Row.Appearance.BackColor = Color.LightGray
                Row.Cells("L_Ent").Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                Row.Cells("Ma_Ent").Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                Row.Cells("Mi_Ent").Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                Row.Cells("J_Ent").Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                Row.Cells("V_Ent").Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                Row.Cells("S_Ent").Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            End If
            'Row.Cells("DIASPARALAPROXIMAENTREGA").ToolTipText = Row.Cells("FECHAENTREGA").Value.ToString()
            If Row.Cells("DIASPARALAPROXIMAENTREGA").Value < 0 Then
                Row.Cells("DIASPARALAPROXIMAENTREGA").Appearance.ForeColor = Color.Red
            End If
            If Row.Cells("PENDIENTECONATRASO").Value <> "" Then
                Row.Cells("PENDIENTECONATRASO").Appearance.ForeColor = Color.Red
            End If

            If Row.Cells("#").Value = 1 Then
                Row.Cells("COTIZACIONES").Appearance.BackColor = pnlTodasCot.BackColor
            End If
            If Row.Cells("#").Value = 36 Then
                Row.Cells("COTIZACIONES").Appearance.BackColor = pnlTodasCot.BackColor
            End If
            If Row.Cells("#").Value = 38 Then
                Row.Cells("COTIZACIONES").Appearance.BackColor = pnlNingunaCot.BackColor
            End If
            If Row.Cells("#").Value = 40 Then
                Row.Cells("COTIZACIONES").Appearance.BackColor = pnlNingunaCot.BackColor
            End If
        Next

        For Each col As UltraGridColumn In grid.Rows.Band.Columns
            If col.Header.Caption <> "Pedido SAY" And col.Header.Caption <> "Pedido SICY" Then
                For Each row As UltraGridRow In grid.Rows
                    If IsNumeric(row.Cells(col).Value) Then
                        row.Cells(col).Appearance.TextHAlign = HAlign.Right
                    End If
                Next
            End If
        Next

    End Sub

    Private Sub gridPartidasDiseño(grid As Infragistics.Win.UltraWinGrid.UltraGrid)

        Dim IndicePrimerColumna As Integer = 0
        Dim UltimaColumna As Integer = 0
        'GUARDAMOS EL DISEÑO Y LA BANDA EN VARIABLES PARA HACER REFERENCIA A ELLOS MAS FACIL 
        Dim Layout As UltraGridLayout = grid.DisplayLayout
        Dim rootBand As UltraGridBand = Layout.Bands(0)

        rootBand.RowLayoutStyle = RowLayoutStyle.GroupLayout

        'Validamos cuantas columnas de informacion hay en el grid, pasa despues determinar la cantidad de columnas de corridas


        'FOR PARA AGREGAR LOS RESPECTIVOS GRUPOS 
        For n = 0 To rootBand.Columns.Count - 1 Step 1

            'If tipoDistribucion = 0 Then
            UltimaColumna = 50
            'Else
            '    UltimaColumna = 47
            'End If

            If (n < 14 Or n > 23) And (n < 26 Or n > 31) And (n < 32 Or n > 38) And n <> 32 And n < 42 Then
                Dim grupo As UltraGridGroup = rootBand.Groups.Add(rootBand.Columns(n).Header.Caption, " ")
                rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = grupo
            Else

                If n > 13 And n < 18 Then
                    If n = 14 Then
                        Dim NombreColumna As String
                        NombreColumna = "En existencia"

                        Dim Grupo As UltraGridGroup = rootBand.Groups.Add(NombreColumna)
                        rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = Grupo
                    Else
                        Dim Grupo As UltraGridGroup = rootBand.Groups("En existencia")
                        rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = Grupo
                    End If
                End If

                If n > 17 And n < 24 Then
                    If n = 18 Then
                        Dim NombreColumna As String
                        NombreColumna = "Inventario en producción"

                        Dim Grupo As UltraGridGroup = rootBand.Groups.Add(NombreColumna)
                        rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = Grupo
                    Else
                        Dim Grupo As UltraGridGroup = rootBand.Groups("Inventario en producción")
                        rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = Grupo
                    End If
                End If

                If n > 25 And n < 32 Then
                    If n = 26 Then
                        Dim NombreColumna As String
                        NombreColumna = "Entrega"

                        Dim Grupo As UltraGridGroup = rootBand.Groups.Add(NombreColumna)
                        rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = Grupo
                    Else
                        Dim Grupo As UltraGridGroup = rootBand.Groups("Entrega")
                        rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = Grupo
                    End If
                End If

                If n > 32 And n < 39 Then
                    If n = 33 Then
                        Dim NombreColumna As String
                        NombreColumna = "Proyección"

                        Dim Grupo As UltraGridGroup = rootBand.Groups.Add(NombreColumna)
                        rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = Grupo
                    Else
                        Dim Grupo As UltraGridGroup = rootBand.Groups("Proyección")
                        rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = Grupo
                    End If
                End If
            End If
        Next

        grid.DisplayLayout.Bands(0).Columns("FECHAENTREGA").Format = "dd/MM/yyyy"
        grid.DisplayLayout.Bands(0).Columns("P").Hidden = True

        'grid.DisplayLayout.Bands(0).Columns("PENDIENTECONATRASO").Hidden = True
        'grid.DisplayLayout.Bands(0).Columns("PENDIENTESEMANAPROSPECTA").Hidden = True
        'grid.DisplayLayout.Bands(0).Columns("PORADELANTAR").Hidden = True
        'grid.DisplayLayout.Bands(0).Columns("TOTALPARES").Hidden = True
        'grid.DisplayLayout.Bands(0).Columns("INVENTARIO").Hidden = True
        'grid.DisplayLayout.Bands(0).Columns("APARTADOPORCONFIRMAR").Hidden = True
        'grid.DisplayLayout.Bands(0).Columns("TALLA").Hidden = True
        grid.DisplayLayout.Bands(0).Columns("BLOQUEADOENTREGACOBRANZA").Hidden = True
        grid.DisplayLayout.Bands(0).Columns("PlazoCeroSinCot").Hidden = True
        grid.DisplayLayout.Bands(0).Columns("PartidaIncompleta").Hidden = True


        'grid.DisplayLayout.Bands(0).Columns("#").Header.Caption = "#"
        'grid.DisplayLayout.Bands(0).Columns("PEDIDO").Header.Caption = "Pedido SICY"
        'grid.DisplayLayout.Bands(0).Columns("#PARTIDA").Header.Caption = "Partida"
        'grid.DisplayLayout.Bands(0).Columns("PROSPECTADO").Header.Caption = "Prospectado"
        'grid.DisplayLayout.Bands(0).Columns("TIENDA/EMBARQUE/CEDIS").Header.Caption = "Tienda/Embarque/CEDIS"
        'grid.DisplayLayout.Bands(0).Columns("STATUS").Header.Caption = "Status"
        'grid.DisplayLayout.Bands(0).Columns("ARTICULO").Header.Caption = "Articulo"
        'grid.DisplayLayout.Bands(0).Columns("DIASPARALAPROXIMAENTREGA").Header.Caption = "Días Entrega"
        'grid.DisplayLayout.Bands(0).Columns("PENDIENTECONATRASO").Header.Caption = "Pendiente Atraso Anterior incicla"
        'grid.DisplayLayout.Bands(0).Columns("PENDIENTESEMANAPROSPECTA").Header.Caption = "Pendiente pros"
        'grid.DisplayLayout.Bands(0).Columns("PORADELANTAR").Header.Caption = "´Por Adelantar Iniciar"
        'grid.DisplayLayout.Bands(0).Columns("TOTALPARES").Header.Caption = "Total Pares"
        'grid.DisplayLayout.Bands(0).Columns("INVENTARIO").Header.Caption = "Inventario"
        'grid.DisplayLayout.Bands(0).Columns("APARTADOPORCONFIRMAR").Header.Caption = "AP Por Confirmar"
        'grid.DisplayLayout.Bands(0).Columns("PENDIENTECONATRASOACTUAL").Header.Caption = ""
        'grid.DisplayLayout.Bands(0).Columns("PENDIENTESEMANAPROSPECTAACTUAL").Header.Caption = "Pendientes embarcados"
        'grid.DisplayLayout.Bands(0).Columns("PORADELANTARACTUAL").Header.Caption = "Pendientes por adelantar"
        'grid.DisplayLayout.Bands(0).Columns("TOTALPARESACTUAL").Header.Caption = "Total Pares"
        'grid.DisplayLayout.Bands(0).Columns("INVENTARIOACTUAL").Header.Caption = "Inventario"
        'grid.DisplayLayout.Bands(0).Columns("APARTADOPORCONFIRMARACTUAL").Header.Caption = "AP Confirmar"
        'grid.DisplayLayout.Bands(0).Columns("V_Inv").Header.Caption = "V"
        'grid.DisplayLayout.Bands(0).Columns("S_Inv").Header.Caption = "S"
        'grid.DisplayLayout.Bands(0).Columns("L_Inv").Header.Caption = "L"
        'grid.DisplayLayout.Bands(0).Columns("Ma_Inv").Header.Caption = "M"""
        'grid.DisplayLayout.Bands(0).Columns("Mi_Inv").Header.Caption = "M"
        'grid.DisplayLayout.Bands(0).Columns("J_Inv").Header.Caption = "J"
        'grid.DisplayLayout.Bands(0).Columns("L_Ent").Header.Caption = "L"
        'grid.DisplayLayout.Bands(0).Columns("Ma_Ent").Header.Caption = "M"
        'grid.DisplayLayout.Bands(0).Columns("Mi_Ent").Header.Caption = "M"
        'grid.DisplayLayout.Bands(0).Columns("J_Ent").Header.Caption = "J"
        'grid.DisplayLayout.Bands(0).Columns("V_Ent").Header.Caption = "V"
        'grid.DisplayLayout.Bands(0).Columns("S_Ent").Header.Caption = "S"
        'grid.DisplayLayout.Bands(0).Columns("P").Header.Caption = "P"
        'grid.DisplayLayout.Bands(0).Columns("V_Proy").Header.Caption = "V"
        'grid.DisplayLayout.Bands(0).Columns("S_Proy").Header.Caption = "S"
        'grid.DisplayLayout.Bands(0).Columns("L_Proy").Header.Caption = "L"
        'grid.DisplayLayout.Bands(0).Columns("Ma_Proy").Header.Caption = "M"
        'grid.DisplayLayout.Bands(0).Columns("Mi_Proy").Header.Caption = "M"
        'grid.DisplayLayout.Bands(0).Columns("J_Proy").Header.Caption = "J"
        'grid.DisplayLayout.Bands(0).Columns("SUMA").Header.Caption = "Suma"
        'grid.DisplayLayout.Bands(0).Columns("TOTALDEPARESAPROSPECTAR").Header.Caption = "Total Prospectar"
        'grid.DisplayLayout.Bands(0).Columns("USUARIO").Header.Caption = "Usuario"
        'grid.DisplayLayout.Bands(0).Columns("FECHA").Header.Caption = "Fecha"
        'grid.DisplayLayout.Bands(0).Columns("FECHAENTREGA").Header.Caption = ""

        grid.DisplayLayout.UseFixedHeaders = True
        grid.DisplayLayout.Bands(0).Override.FixedHeaderIndicator = FixedHeaderIndicator.None

        grid.DisplayLayout.Bands(0).Columns("#").Header.Caption = "#"
        grid.DisplayLayout.Bands(0).Groups("#").Header.Fixed = True
        grid.DisplayLayout.Bands(0).Columns("Cliente").Header.Caption = "Cliente"
        grid.DisplayLayout.Bands(0).Groups("Cliente").Header.Fixed = True
        grid.DisplayLayout.Bands(0).Columns("PedidoSAY").Header.Caption = "Pedido SAY"
        grid.DisplayLayout.Bands(0).Groups("PedidoSAY").Header.Fixed = True
        grid.DisplayLayout.Bands(0).Columns("#PARTIDA").Header.Caption = "Partida"
        grid.DisplayLayout.Bands(0).Groups("#PARTIDA").Header.Fixed = True
        grid.DisplayLayout.Bands(0).Columns("PROSPECTADO").Header.Caption = "PR"
        grid.DisplayLayout.Bands(0).Columns("STATUS").Header.Caption = "Status"
        grid.DisplayLayout.Bands(0).Columns("ARTICULO").Header.Caption = "Articulo"
        grid.DisplayLayout.Bands(0).Columns("Corrida").Header.Caption = "Corrida"
        grid.DisplayLayout.Bands(0).Columns("DIASPARALAPROXIMAENTREGA").Header.Caption = "Días E"
        grid.DisplayLayout.Bands(0).Columns("FECHAENTREGA").Header.Caption = "F Entrega"
        grid.DisplayLayout.Bands(0).Columns("PENDIENTECONATRASO").Header.Caption = "Total atrasado"
        grid.DisplayLayout.Bands(0).Columns("PENDIENTESEMANAPROSPECTA").Header.Caption = "Total prospecta"
        grid.DisplayLayout.Bands(0).Columns("PORADELANTAR").Header.Caption = "Por adelantar"
        grid.DisplayLayout.Bands(0).Columns("TOTALPARES").Header.Caption = "Total"
        grid.DisplayLayout.Bands(0).Columns("INVENTARIO").Header.Caption = "Inventario"
        grid.DisplayLayout.Bands(0).Columns("BLOQUEADOS").Header.Caption = "BC"
        grid.DisplayLayout.Bands(0).Columns("REPROCESO").Header.Caption = "RP"
        grid.DisplayLayout.Bands(0).Columns("APARTADOPORCONFIRMAR").Header.Caption = "Apartado"
        grid.DisplayLayout.Bands(0).Columns("V_Inv").Header.Caption = "V"
        grid.DisplayLayout.Bands(0).Columns("S_Inv").Header.Caption = "S"
        grid.DisplayLayout.Bands(0).Columns("L_Inv").Header.Caption = "L"
        grid.DisplayLayout.Bands(0).Columns("Ma_Inv").Header.Caption = "M"
        grid.DisplayLayout.Bands(0).Columns("Mi_Inv").Header.Caption = "M"
        grid.DisplayLayout.Bands(0).Columns("J_Inv").Header.Caption = "J"
        grid.DisplayLayout.Bands(0).Columns("SUMA").Header.Caption = "Disponible"
        grid.DisplayLayout.Bands(0).Columns("Sumaalmomentodeguardar").Header.Caption = "Anterior disponible"
        grid.DisplayLayout.Bands(0).Columns("L_Ent").Header.Caption = "L"
        grid.DisplayLayout.Bands(0).Columns("Ma_Ent").Header.Caption = "M"
        grid.DisplayLayout.Bands(0).Columns("Mi_Ent").Header.Caption = "M"
        grid.DisplayLayout.Bands(0).Columns("J_Ent").Header.Caption = "J"
        grid.DisplayLayout.Bands(0).Columns("V_Ent").Header.Caption = "V"
        grid.DisplayLayout.Bands(0).Columns("S_Ent").Header.Caption = "S"
        grid.DisplayLayout.Bands(0).Columns("P").Header.Caption = "P"
        grid.DisplayLayout.Bands(0).Columns("V_Proy").Header.Caption = "V "
        grid.DisplayLayout.Bands(0).Columns("S_Proy").Header.Caption = "S"
        grid.DisplayLayout.Bands(0).Columns("L_Proy").Header.Caption = "L"
        grid.DisplayLayout.Bands(0).Columns("Ma_Proy").Header.Caption = "M"
        grid.DisplayLayout.Bands(0).Columns("Mi_Proy").Header.Caption = "M"
        grid.DisplayLayout.Bands(0).Columns("J_Proy").Header.Caption = "J"
        grid.DisplayLayout.Bands(0).Columns("TOTALDEPARESAPROSPECTAR").Header.Caption = "Total PR"
        grid.DisplayLayout.Bands(0).Columns("USUARIO").Header.Caption = "Usuario"
        grid.DisplayLayout.Bands(0).Columns("FECHA").Header.Caption = "Fecha"
        grid.DisplayLayout.Bands(0).Columns("BLOQUEADOENTREGACOBRANZA").Header.Caption = "Bloqueado"


        grid.DisplayLayout.Bands(0).Columns("L_Ent").AllowRowFiltering = DefaultableBoolean.False
        grid.DisplayLayout.Bands(0).Columns("L_Ent").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
        grid.DisplayLayout.Bands(0).Columns("Ma_Ent").AllowRowFiltering = DefaultableBoolean.False
        grid.DisplayLayout.Bands(0).Columns("Ma_Ent").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
        grid.DisplayLayout.Bands(0).Columns("Mi_Ent").AllowRowFiltering = DefaultableBoolean.False
        grid.DisplayLayout.Bands(0).Columns("Mi_Ent").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
        grid.DisplayLayout.Bands(0).Columns("J_Ent").AllowRowFiltering = DefaultableBoolean.False
        grid.DisplayLayout.Bands(0).Columns("J_Ent").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
        grid.DisplayLayout.Bands(0).Columns("V_Ent").AllowRowFiltering = DefaultableBoolean.False
        grid.DisplayLayout.Bands(0).Columns("V_Ent").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
        grid.DisplayLayout.Bands(0).Columns("S_Ent").AllowRowFiltering = DefaultableBoolean.False
        grid.DisplayLayout.Bands(0).Columns("S_Ent").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit

        grid.DisplayLayout.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
        grid.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grid.DisplayLayout.Override.RowSelectorWidth = 20
        grid.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
        grid.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
        grid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No

        grid.DisplayLayout.Bands(0).Columns("#").Width = 25

        Dim width As Integer
        For Each col As UltraGridColumn In grid.Rows.Band.Columns
            If col.DataType <> System.Type.GetType("System.Boolean") Then
                col.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                col.CharacterCasing = CharacterCasing.Upper
            End If
            If Not col.Hidden Then
                width += col.Width
            End If
        Next

        For Each Row As UltraGridRow In grdPartidas.Rows
            If Row.Cells("BLOQUEADOENTREGACOBRANZA").Value = 1 Then
                'Row.Cells("_").Hidden = True
                Row.Appearance.BackColor = Color.LightGray
                Row.Cells("L_Ent").Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                Row.Cells("Ma_Ent").Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                Row.Cells("Mi_Ent").Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                Row.Cells("J_Ent").Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                Row.Cells("V_Ent").Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                Row.Cells("S_Ent").Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            End If
            If Row.Cells("PlazoCeroSinCot").Value = 1 Then
                Row.Appearance.BackColor = Color.LightGray
                Row.Cells("L_Ent").Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                Row.Cells("Ma_Ent").Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                Row.Cells("Mi_Ent").Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                Row.Cells("J_Ent").Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                Row.Cells("V_Ent").Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                Row.Cells("S_Ent").Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            End If

            If Row.Cells("TOTALDEPARESAPROSPECTAR").Value = 0 Then
                Row.Appearance.BackColor = Color.LightGray
                Row.Cells("L_Ent").Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                Row.Cells("Ma_Ent").Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                Row.Cells("Mi_Ent").Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                Row.Cells("J_Ent").Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                Row.Cells("V_Ent").Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                Row.Cells("S_Ent").Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            End If
            If Row.Cells("PartidaIncompleta").Value = 1 Then
                Row.Appearance.BackColor = Color.LightGray
                Row.Cells("L_Ent").Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                Row.Cells("Ma_Ent").Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                Row.Cells("Mi_Ent").Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                Row.Cells("J_Ent").Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                Row.Cells("V_Ent").Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                Row.Cells("S_Ent").Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                Row.Cells("TOTALPARES").Appearance.ForeColor = Color.Red
                Row.Cells("SUMA").Appearance.ForeColor = Color.Red
                Row.Cells("TOTALDEPARESAPROSPECTAR").Appearance.ForeColor = Color.Red
            End If

            'Row.Cells("DIASPARALAPROXIMAENTREGA").ToolTipText = Row.Cells("FECHAENTREGA").Value.ToString()
            If Row.Cells("DIASPARALAPROXIMAENTREGA").Value < 0 Then
                Row.Cells("DIASPARALAPROXIMAENTREGA").Appearance.ForeColor = Color.Red
            End If
            If Row.Cells("PENDIENTECONATRASO").Value <> "" Then
                Row.Cells("PENDIENTECONATRASO").Appearance.ForeColor = Color.Red
            End If
        Next

        For Each col As UltraGridColumn In grid.Rows.Band.Columns
            If col.Header.Caption <> "Pedido SAY" And col.Header.Caption <> "Pedido SICY" And col.Header.Caption <> "Partida" Then
                For Each row As UltraGridRow In grid.Rows
                    If IsNumeric(row.Cells(col).Value) Then
                        row.Cells(col).Appearance.TextHAlign = HAlign.Right
                    End If
                Next
            End If
        Next


    End Sub

    Private Sub grdClientes_ClickCell(sender As Object, e As ClickCellEventArgs) Handles grdClientes.ClickCell
        'Dim seleccionados As Integer
        'If e.Cell.Column.Header.Caption = "" Then
        '    If e.Cell.Value = False Then
        '        e.Cell.Value = True
        '        If spcClientes.SplitterDistance = spcClientes.Width - 4 Then
        '            spcClientes.SplitterDistance = spcClientes.Width / 2
        '        End If
        '    Else
        '        e.Cell.Value = False
        '        For Each renglon As UltraGridRow In grdClientes.Rows
        '            If renglon.Cells("_").Value = True Then
        '                seleccionados += 1
        '            End If
        '        Next
        '        If seleccionados = 0 Then
        '            spcClientes.SplitterDistance = spcClientes.Width - 4
        '        End If
        '    End If

        '    For Each renglon As UltraGridRow In grdClientes.Rows

        '        If renglon.Cells("_").Value = True Then
        '            For Each row As UltraGridRow In grdPedidos.Rows
        '                If row.Cells("#").Value = renglon.Index + 1 Then
        '                    row.Hidden = False
        '                Else
        '                    If grdClientes.Rows(row.Index).Cells("_").Value = False Then
        '                        row.Hidden = True
        '                    End If
        '                End If
        '            Next
        '        End If
        '    Next
        'End If
    End Sub

    Private Sub grdClientes_CellChange(sender As Object, e As CellEventArgs) Handles grdClientes.CellChange
        Dim seleccionados As Integer
        If e.Cell.Column.Header.Caption = "" Then
            If e.Cell.Value = False Then
                e.Cell.Value = True
                If spcClientes.SplitterDistance = spcClientes.Width - 4 Then
                    spcClientes.SplitterDistance = spcClientes.Width / 2
                End If
            Else
                e.Cell.Value = False
                For Each renglon As UltraGridRow In grdClientes.Rows
                    If renglon.Cells("_").Value = True Then
                        seleccionados += 1
                    End If
                Next
                If seleccionados = 0 Then
                    spcClientes.SplitterDistance = spcClientes.Width - 4
                End If
            End If

            For Each renglon As UltraGridRow In grdClientes.Rows

                If renglon.Cells("_").Value = True Then
                    For Each row As UltraGridRow In grdPedidos.Rows
                        If row.Cells("ClienteID").Value = renglon.Index + 1 Then
                            row.Hidden = False
                        Else
                            If grdClientes.Rows(row.Cells("ClienteID").Value - 1).Cells("_").Value = False Then
                                row.Hidden = True
                            End If
                        End If
                    Next
                End If
            Next
        End If
    End Sub

    Private Sub grdPedidos_CellChange(sender As Object, e As CellEventArgs) Handles grdPedidos.CellChange
        Dim seleccionados As Integer
        Dim index As Integer
        If e.Cell.Column.Header.Caption = "" Then
            If e.Cell.Value = False Then
                e.Cell.Value = True
                If sPCParesConfirmar.SplitterDistance = sPCParesConfirmar.Height - 4 Then
                    sPCParesConfirmar.SplitterDistance = sPCParesConfirmar.Height / 2
                End If
            Else
                e.Cell.Value = False
                For Each renglon As UltraGridRow In grdPedidos.Rows
                    If renglon.Cells("_").Value = True Then
                        seleccionados += 1
                    End If
                Next
                If seleccionados = 0 Then
                    sPCParesConfirmar.SplitterDistance = spcClientes.Width - 4
                End If
            End If

            For Each renglon As UltraGridRow In grdPedidos.Rows

                If renglon.Cells("_").Value = True Then
                    For Each row As UltraGridRow In grdPartidas.Rows
                        If row.Cells("PedidoSAY").Value = renglon.Cells("PedidoSAY").Value Then
                            row.Hidden = False
                        Else
                            For Each rowValidacion As UltraGridRow In grdPedidos.Rows
                                If rowValidacion.Cells("PedidoSAY").Value = row.Cells("PedidoSAY").Value Then
                                    If rowValidacion.Cells("_").Value = False Then
                                        row.Hidden = True
                                    End If
                                End If
                            Next
                        End If
                    Next
                End If
            Next
        End If
    End Sub

    Private Sub gridResumenDiseño(grid As UltraGrid)

        grid.DisplayLayout.Bands(0).Columns("Ma").Header.Caption = "M"
        grid.DisplayLayout.Bands(0).Columns("Mi").Header.Caption = "M"

        grid.DisplayLayout.Bands(0).Columns("L").Format = "n0"
        grid.DisplayLayout.Bands(0).Columns("L").CellAppearance.TextHAlign = HAlign.Right
        grid.DisplayLayout.Bands(0).Columns("Ma").Format = "n0"
        grid.DisplayLayout.Bands(0).Columns("Ma").CellAppearance.TextHAlign = HAlign.Right
        grid.DisplayLayout.Bands(0).Columns("Mi").Format = "n0"
        grid.DisplayLayout.Bands(0).Columns("Mi").CellAppearance.TextHAlign = HAlign.Right
        grid.DisplayLayout.Bands(0).Columns("J").Format = "n0"
        grid.DisplayLayout.Bands(0).Columns("J").CellAppearance.TextHAlign = HAlign.Right
        grid.DisplayLayout.Bands(0).Columns("V").Format = "n0"
        grid.DisplayLayout.Bands(0).Columns("V").CellAppearance.TextHAlign = HAlign.Right
        grid.DisplayLayout.Bands(0).Columns("S").Format = "n0"
        grid.DisplayLayout.Bands(0).Columns("S").CellAppearance.TextHAlign = HAlign.Right
        grid.DisplayLayout.Bands(0).Columns("Total").Format = "n0"
        grid.DisplayLayout.Bands(0).Columns("Total").CellAppearance.TextHAlign = HAlign.Right

        grid.DisplayLayout.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
        grid.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
        'grid.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grid.DisplayLayout.Override.RowSelectorWidth = 0
        'grid.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
        'grid.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
        grid.DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.False
        'grid.DisplayLayout.Override.FilterUIType = FilterUIType.FilterRow
        grid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No
        grid.DisplayLayout.Override.AllowDelete = DefaultableBoolean.False
        'grid.DisplayLayout.ViewStyleBand = ViewStyleBand.OutlookGroupBy
        'grid.DisplayLayout.GroupByBox.Hidden = False
        'grid.DisplayLayout.GroupByBox.Prompt = "Arrastre una columna para agrupar por ese concepto"
        grid.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.Select
        grid.DisplayLayout.Override.SelectTypeCol = SelectType.None

        Dim width As Integer
        For Each col As UltraGridColumn In grid.Rows.Band.Columns
            If Not col.Hidden Then
                col.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                width += col.Width
            End If
        Next

        If width > grid.Width Then
            grid.DisplayLayout.AutoFitStyle = AutoFitStyle.None
        Else
            grid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim punto As Point
        punto.X = Button2.Location.X + Button2.Width
        punto.Y = Button2.Location.Y + Button2.Height
        cmsTiposResumen.Show(punto)
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub tsmiEtiquetaSolicitada_Click(sender As Object, e As EventArgs) Handles tsmiEtiquetaSolicitada.Click
        Dim ventana As New ResumenProspecta
        ventana.tipoConsulta = 1
        ventana.Show()
    End Sub

    Private Sub tsmiAsignarOperador_Click(sender As Object, e As EventArgs) Handles tsmiAsignarOperador.Click
        Dim ventana As New ResumenProspecta
        ventana.tipoConsulta = 2
        ventana.Show()
    End Sub

    Private Sub tsmiDesasignarOperador_Click(sender As Object, e As EventArgs) Handles tsmiDesasignarOperador.Click
        Dim ventana As New ResumenProspecta
        ventana.tipoConsulta = 3
        ventana.Show()
    End Sub

    Private Sub ReprocesoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReprocesoToolStripMenuItem.Click
        Dim ventana As New ResumenProspecta
        ventana.tipoConsulta = 4
        ventana.Show()
    End Sub
End Class