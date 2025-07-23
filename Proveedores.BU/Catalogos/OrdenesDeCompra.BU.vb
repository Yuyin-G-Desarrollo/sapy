Imports Entidades
Imports Proveedores.DA

Public Class OrdenesDeCompra

    Public Sub AltaOrdenDeCompra(ByVal OrdenDeCompra As Entidades.OrdenDeCompra)
        Dim OBJDA As New DA.OrdenesDeCompra
        OBJDA.AltaOrdenDeCompra(OrdenDeCompra)
    End Sub

    Public Sub ModificarOrdenCompra(ByVal OrdenDeCompra As Entidades.OrdenDeCompra)
        Dim OBJDA As New DA.OrdenesDeCompra
        OBJDA.ModificarOrdenCompra(OrdenDeCompra)
    End Sub

    'Public Sub ModificarEstatusOrdenCompra(ByVal OrdenDeCompra As Entidades.OrdenDeCompra)
    '    Dim OBJDA As New DA.OrdenesDeCompra
    '    OBJDA.ModificarEstatusOrdenCompra()
    'End Sub

    Public Sub ModificarCostosOrdenCompra(ByVal OrdenDeCompra As Entidades.OrdenDeCompra)
        Dim OBJDA As New DA.OrdenesDeCompra
        OBJDA.ModificarCostosOrdenCompra(OrdenDeCompra)
    End Sub

    Public Function listaProveedoresNave(ByVal idnave As Integer) As DataTable
        Dim OBJDA As New DA.OrdenesDeCompra
        Dim tabla As New DataTable
        tabla = OBJDA.ListaProveedorNave(idnave)
        Return tabla
    End Function

    Public Function ListaRazonSocial(ByVal idnave As Integer) As DataTable
        Dim OBJDA As New DA.OrdenesDeCompra
        Dim tabla As New DataTable
        tabla = OBJDA.ListaRazonSocial(idnave)
        Return tabla
    End Function

    Public Function consultaGeneral(ByVal idnave As Int32, ByVal del As String, ByVal al As String, ByVal anio As Integer) As DataTable
        Dim OBJDA As New DA.OrdenesDeCompra
        Dim tabla As New DataTable
        tabla = OBJDA.consultaGeneral(idnave, del, al, anio)
        Return tabla
    End Function

    Public Function consulta1(ByVal idnave As Int32, ByVal del As String, ByVal al As String, ByVal anio As Integer, ByVal busca As String) As DataTable
        Dim OBJDA As New DA.OrdenesDeCompra
        Dim tabla As New DataTable
        tabla = OBJDA.consulta1(idnave, del, al, anio, busca)
        Return tabla
    End Function

    Public Function consultaConEstatus(ByVal idnave As Int32, ByVal del As String, ByVal al As String, ByVal anio As Integer, ByVal estatus As String) As DataTable
        Dim OBJDA As New DA.OrdenesDeCompra
        Dim tabla As New DataTable
        tabla = OBJDA.consultaEstatus(idnave, del, al, anio, estatus)
        Return tabla
    End Function

    Public Function consultaConFolio(ByVal idnave As Int32, ByVal anio As Integer, ByVal folio As Integer) As DataTable
        Dim OBJDA As New DA.OrdenesDeCompra
        Dim tabla As New DataTable
        tabla = OBJDA.consultaFolio(idnave, anio, folio)
        Return tabla
    End Function

    Public Function ListaPLazoProveedor(ByVal proveedorid As Integer) As DataTable
        Dim OBJDA As New DA.OrdenesDeCompra
        Dim tabla As New DataTable
        tabla = OBJDA.ListaPLazoProveedor(proveedorid)
        Return tabla
    End Function

    Public Function ListaDiasPLazoProveedor(ByVal plazoid As Integer) As DataTable
        Dim OBJDA As New DA.OrdenesDeCompra
        Dim tabla As New DataTable
        tabla = OBJDA.ListaDiasPLazoProveedor(plazoid)
        Return tabla
    End Function

    Public Function ListaMaterialSeleccionado(ByVal lista As List(Of Integer), ByVal proveedorid As Integer, ByVal naveid As Integer) As DataTable
        Dim OBJDA As New DA.OrdenesDeCompra
        Dim tabla As New DataTable
        tabla = OBJDA.ListaMaterialSeleccionado(lista, proveedorid, naveid)
        Return tabla
    End Function

    Public Function ListaiDOrdenCompra(ByVal idoc As Integer) As DataTable
        Dim OBJDA As New DA.OrdenesDeCompra
        Dim tabla As New DataTable
        tabla = OBJDA.ListaiDOrdenCompra(idoc)
        Return tabla
    End Function

    Public Function ListaMaterialesConsulta(ByVal lista As List(Of Integer), ByVal proveedorid As Integer, ByVal naveid As Integer) As DataTable
        Dim OBJDA As New DA.OrdenesDeCompra
        Dim tabla As New DataTable
        tabla = OBJDA.ListaMaterialSeleccionado(lista, proveedorid, naveid)
        Return tabla
    End Function

    Public Function LlenarTablacONSULTA(ByVal idproveedor As Integer, ByVal idOC As Integer) As DataTable
        Dim OBJDA As New DA.OrdenesDeCompra
        Dim tabla As New DataTable
        tabla = OBJDA.LlenarTablacONSULTA(idproveedor, idOC)
        Return tabla
    End Function

    Public Function consultaFormularioGrid(ByVal lista As List(Of Integer), ByVal proveedorid As Integer, ByVal naveid As Integer, ByVal oc As Integer) As DataTable
        Dim OBJDA As New DA.OrdenesDeCompra
        Dim tabla As New DataTable
        tabla = OBJDA.consultaFormularioGrid(lista, proveedorid, naveid, oc)
        Return tabla
    End Function

    Public Function obtenerDireccion(ByVal naveid As Integer) As DataTable
        Dim OBJDA As New DA.OrdenesDeCompra
        Dim tabla As New DataTable
        tabla = OBJDA.obtenerDirecciones(naveid)
        Return tabla
    End Function

    Public Function reporteOrdenDeCompra(ByVal idoc As Integer) As DataTable
        Dim OBJDA As New DA.OrdenesDeCompra
        Dim tabla As New DataTable
        tabla = OBJDA.reporteOrdenDeCompra(idoc)
        Return tabla
    End Function

    Public Function idocRegistrado(ByVal folio As Integer, ByVal nave As Integer) As DataTable
        Dim OBJDA As New DA.OrdenesDeCompra
        Dim tabla As New DataTable
        tabla = OBJDA.idocRegistrado(folio, nave)
        Return tabla
    End Function

    Public Function autorizo(ByVal idoc As Integer) As DataTable
        Dim OBJDA As New DA.OrdenesDeCompra
        Dim tabla As New DataTable
        tabla = OBJDA.autorizo(idoc)
        Return tabla
    End Function

    Public Function reporteOrdenDeCompraMateriales(ByVal idoc As Integer) As DataTable
        Dim OBJDA As New DA.OrdenesDeCompra
        Dim tabla As New DataTable
        tabla = OBJDA.reporteOrdenDeCompraMateriales(idoc)
        Return tabla
    End Function

    Public Function obtenerPais(ByVal ciudadid As Integer) As DataTable
        Dim OBJDA As New DA.OrdenesDeCompra
        Dim tabla As New DataTable
        tabla = OBJDA.obtenerPais(ciudadid)
        Return tabla
    End Function

    Public Function ObtenerFolioRecienInsertado(ByVal id As Int32) As Int32
        Dim OBJDA As New DA.OrdenesDeCompra
        Dim tabla As New DataTable
        tabla = OBJDA.ObtenerFolioRecienInsertado(id)
        Dim Folio As New Int32
        For Each row As DataRow In tabla.Rows
            Folio = CInt(row("ordc_folio"))
        Next
        Return Folio
    End Function

    Public Function ultimaOrdenCompra()
        Dim OBJDA As New DA.OrdenesDeCompra
        Dim tabla As New DataTable
        tabla = OBJDA.ultimaOrdenCompra()
        Dim oc As New Int32
        For Each row As DataRow In tabla.Rows
            oc = CInt(row("ordc_ordendecompraid"))
        Next
        Return oc
    End Function

    Public Function ultimoMaterial()
        Dim OBJDA As New DA.OrdenesDeCompra
        Dim tabla As New DataTable
        tabla = OBJDA.ultimoMaterial()
        Dim oc As New Int32
        For Each row As DataRow In tabla.Rows
            oc = CInt(row("maoc_materialordendecompraid"))
        Next
        Return oc
    End Function

    Public Function ListaPaises() As DataTable
        Dim objDA As New DA.OrdenesDeCompra
        Dim tabla As New DataTable
        tabla = objDA.ListaPaises()
        Return tabla
    End Function

    Public Function ListaFamilias() As DataTable
        Dim objDA As New DA.OrdenesDeCompra
        Dim tabla As New DataTable
        tabla = objDA.ListaFamilias()
        Return tabla
    End Function


    Public Function ListaMaterialesPorNave(ByVal idnave As Integer) As DataTable
        Dim objDA As New DA.OrdenesDeCompra
        Dim tabla As New DataTable
        tabla = objDA.ListaMaterialesPorNave(idnave)
        Return tabla
    End Function

    Public Function listaNaves() As DataTable
        Dim objDA As New DA.OrdenesDeCompra
        Dim tabla As New DataTable
        tabla = objDA.listaNaves()
        Return tabla
    End Function

    Public Function ListaEstados(ByVal paisid As Integer) As DataTable
        Dim objDA As New DA.OrdenesDeCompra
        Dim tabla As New DataTable
        tabla = objDA.ListaEstados(paisid)
        Return tabla
    End Function

    Public Function ListaCiudades(ByVal estadoid As Integer) As DataTable
        Dim objDA As New DA.OrdenesDeCompra
        Dim tabla As New DataTable
        tabla = objDA.ListaCiudades(estadoid)
        Return tabla
    End Function

    Public Function ListaMateriales(ByVal proveedorid As Integer, ByVal naveid As Integer) As DataTable
        Dim objDA As New DA.OrdenesDeCompra
        ListaMateriales = objDA.ListaMaterialesProveedor(proveedorid, naveid)
        Return ListaMateriales
    End Function

    Public Function autorizarMaterial(ByVal OrdenDeCompra As Entidades.OrdenDeCompra) As DataTable
        Dim objDA As New DA.OrdenesDeCompra
        objDA.autorizarMaterial(OrdenDeCompra)
    End Function

    Public Function ListaOrdenesDeCompraGeneral(ByVal naveid As Integer) As DataTable
        Dim objDA As New DA.OrdenesDeCompra
        ListaOrdenesDeCompraGeneral = objDA.ListaOrdenesCompraGeneral(naveid)
        Return ListaOrdenesDeCompraGeneral
    End Function

    Public Function ListaOrdenesDeCompraFiltrada(ByVal estatus As String, ByVal naveid As Integer) As DataTable
        Dim objDA As New DA.OrdenesDeCompra
        ListaOrdenesDeCompraFiltrada = objDA.ListaOrdenesCompraFiltrada(estatus, naveid)
        Return ListaOrdenesDeCompraFiltrada(estatus, naveid)
    End Function

    Public Function ObtenerUltimoFolio(ByVal idFolio As Int32) As DataTable
        Dim OBJDA As New DA.OrdenesDeCompra
        Dim tabla As New DataTable
        tabla = OBJDA.ObtenerUltimoFolio(idFolio)
        Dim IdPersona As New Int32
        For Each row As DataRow In tabla.Rows
            IdPersona = CInt(row("dage_proveedorid"))
        Next
        Return tabla
        'Return IdPersona
    End Function

    Public Function consultaFormulario(ByVal idOC As Int32) As DataTable
        Dim OBJDA As New DA.OrdenesDeCompra
        Dim tabla As New DataTable
        tabla = OBJDA.consultaFormulario(idOC)
        Return tabla
    End Function

    Public Function telefonoProveedor(ByVal idproveedor As Integer) As DataTable
        Dim OBJDA As New DA.OrdenesDeCompra
        Dim tabla As New DataTable
        tabla = OBJDA.telefonoProveedor(idproveedor)
        Return tabla
    End Function

End Class




