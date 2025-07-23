Imports Proveedores.DA

Public Class MercadotecniaBU

    Public Function ObtieneListadoMaterialesPOP(ByVal Estatus As Integer) As DataTable
        Dim objDA As New MercadotecniaDA
        Return objDA.ObtieneListadoMaterialesPOP(Estatus)
    End Function

    Public Function llenarComboMarcas() As DataTable
        Dim objDa As New MercadotecniaDA
        Return objDa.llenarComboMarcas()
    End Function

    Public Function llenarComboUnidad() As DataTable
        Dim objDa As New MercadotecniaDA
        Return objDa.llenarComboUnidad()
    End Function

    Public Function ActualizarInventarioMaterialPOP(ByVal pXmlMateriales As String, ByVal accion As Integer)
        Dim objDA As New MercadotecniaDA
        Return objDA.ActualizarInventarioMaterialPOP(pXmlMateriales, accion)
    End Function

    Public Function llenarComboClientes() As DataTable
        Dim objDA As New MercadotecniaDA
        Return objDA.llenarComboClientes()
    End Function


    Public Function llenarComboEstatus() As DataTable
        Dim objDA As New MercadotecniaDA
        Return objDA.llenarComboEstatus()
    End Function


    Public Function llenarGridMaterialesPOP(ByVal Material As String) As DataTable
        Dim objDa As New MercadotecniaDA
        Dim tablaMateriales As New DataTable

        tablaMateriales = objDa.llenarGridMaterialesPOP(Material)

        Return tablaMateriales
    End Function

    Public Function GuardarSolicitudesPOP(ByVal pmXLCeldas As String) As DataTable
        Dim objDA As New MercadotecniaDA
        Return objDA.GuardarSolicitudesPOP(pmXLCeldas)

    End Function

    Public Function InsertarEncabezadoOrdenCompra(ByVal ClienteID As Integer, ByVal MotivoSolicitud As String, ByVal EstatusID As Integer, ByVal Observaciones As String, ByVal UsuarioCreoID As Integer, ByVal TotalGrid As Double, ByVal SolicitudOrdenCompra As Integer) As DataTable
        Dim objDa As New MercadotecniaDA
        Return objDa.InsertarEncabezadoOrdenCompra(ClienteID, MotivoSolicitud, EstatusID, Observaciones, UsuarioCreoID, TotalGrid, SolicitudOrdenCompra)
    End Function

    Public Function ObtieneOrdenesCompraEncabezado()
        Dim objDA As New MercadotecniaDA
        Return objDA.ObtieneOrdenesCompraEncabezado()
    End Function

    Public Function ObtieneOrdenesCompraDetalle(ByVal SolicitudID As Integer) As DataTable
        Dim objDA As New MercadotecniaDA
        Return objDA.ObtieneOrdenesCompraDetalle(SolicitudID)
    End Function

    Public Function ObtieneEncabezadoReporte(ByVal SolicitudOrdenCompra As Integer, ByVal Accion As Integer) As DataTable
        Dim objDA As New MercadotecniaDA
        Dim tabla As New DataTable

        tabla = objDA.ObtieneEncabezadoReporte(SolicitudOrdenCompra, Accion)

        Return tabla
    End Function

    Public Function ConsultaInventarioParesECommerce()
        Dim obj As New MercadotecniaDA
        Return obj.ConsultaInventarioParesECommerce()
    End Function

    Public Function ConsultaInventario_ECOMMERCE_PorProgramar() As DataTable
        Dim obj As New MercadotecniaDA
        Return obj.ConsultaInventario_ECOMMERCE_PorProgramar()
    End Function

    Public Function ConsultaInventario_ECOMMERCE_EnProceso() As DataTable
        Dim obj As New MercadotecniaDA
        Return obj.ConsultaInventario_ECOMMERCE_EnProceso()
    End Function

    Public Function ConsultaInventario_ECOMMERCE_EnInventario() As DataTable
        Dim obj As New MercadotecniaDA
        Return obj.ConsultaInventario_ECOMMERCE_EnInventario()
    End Function

    Public Function ConsultaArticulosIngresados(ByVal FechaInicio As Date, ByVal FechaFin As Date) As DataTable
        Dim obj As New MercadotecniaDA
        Return obj.ConsultaArticulosIngresados(FechaInicio, FechaFin)
    End Function


End Class
