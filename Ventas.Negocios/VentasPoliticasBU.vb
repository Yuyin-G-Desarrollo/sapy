Imports Ventas.Datos

Public Class VentasPoliticasBU

    Public Sub editarVentasPoliticas(ByVal PoliticaVenta As Entidades.PoliticaVenta, bandera As Integer)

        Dim guardarVentasPoliticas As New Datos.VentasPoliticasDA

        guardarVentasPoliticas.editarVentasPoliticas(PoliticaVenta, bandera)

    End Sub

    Public Function TablaDocumentosSegunClaseDocumento(claseDocumento As String, clienteID As Integer, AreaOperativa As Integer) As DataTable

        Dim TablaDocumentos As New Datos.VentasPoliticasDA

        Return TablaDocumentos.TablaDocumentosSegunClaseDocumento(claseDocumento, clienteID, AreaOperativa)

    End Function

    Public Function TablaTipoDocumentosSegunClaseDocumento(claseDocumento As String, AreaOperativa As Integer) As DataTable

        Dim TablaTipoDocumentos As New Datos.VentasPoliticasDA

        Return TablaTipoDocumentos.TablaTipoDocumentosSegunClaseDocumento(claseDocumento, AreaOperativa)

    End Function

    Public Sub altaDocumentosCliente(documento As Entidades.Documento, cliente As Entidades.Cliente)

        Dim altaDocumentosClienteDA As New Datos.VentasPoliticasDA

        altaDocumentosClienteDA.altaDocumentosCliente(documento, cliente)

    End Sub

    Public Sub editarDocumentosCliente(documento As Entidades.Documento, cliente As Entidades.Cliente)

        Dim editarDocumentosClienteDA As New Datos.VentasPoliticasDA

        editarDocumentosClienteDA.editarDocumentosCliente(documento, cliente)

    End Sub

    Public Function Datos_TablaEtiquetasCliente(clienteID As Integer, areaOperativa As Integer) As DataTable

        Dim VentasPoliticasDA As New Datos.VentasPoliticasDA

        Return VentasPoliticasDA.Datos_TablaEtiquetasCliente(clienteID, areaOperativa)

    End Function

    Public Function Datos_TablaTipoEtiquetasCliente() As DataTable

        Dim VentasPoliticasDA As New Datos.VentasPoliticasDA

        Return VentasPoliticasDA.Datos_TablaTipoEtiquetasCliente()

    End Function

    Public Function Datos_TablaFuenteInformacionEtiquetasCliente() As DataTable

        Dim VentasPoliticasDA As New Datos.VentasPoliticasDA

        Return VentasPoliticasDA.Datos_TablaFuenteInformacionEtiquetasCliente()

    End Function

    Public Function Datos_TablaTamanoEtiquetasCliente() As DataTable

        Dim VentasPoliticasDA As New Datos.VentasPoliticasDA

        Return VentasPoliticasDA.Datos_TablaTamanoEtiquetasCliente()

    End Function

    Public Function Datos_TablaUbicacionEtiquetasCliente() As DataTable

        Dim VentasPoliticasDA As New Datos.VentasPoliticasDA

        Return VentasPoliticasDA.Datos_TablaUbicacionEtiquetasCliente()

    End Function

    Public Function Datos_UltimaEtiquetaCliente() As Integer

        Dim VentasPoliticasDA As New Datos.VentasPoliticasDA
        Dim tabla As New DataTable

        tabla = VentasPoliticasDA.Datos_UltimaEtiquetaCliente()

        Return CInt(tabla.Rows(0).Item(0))

    End Function

    Public Function Datos_UltimaEtiquetaCliente_mas1() As Integer

        Dim VentasPoliticasDA As New Datos.VentasPoliticasDA
        Dim tabla As New DataTable

        tabla = VentasPoliticasDA.Datos_UltimaEtiquetaCliente_mas1()

        Return CInt(tabla.Rows(0).Item(0))

    End Function

    Public Sub AltaEtiquetaCliente(etiqueta As Entidades.EtiquetaCliente)

        Dim VentasPoliticasDA As New Datos.VentasPoliticasDA

        VentasPoliticasDA.AltaEtiquetaCliente(etiqueta)

    End Sub

    Public Sub EditarEtiquetaCliente(etiqueta As Entidades.EtiquetaCliente)

        Dim VentasPoliticasDA As New Datos.VentasPoliticasDA

        VentasPoliticasDA.EditarEtiquetaCliente(etiqueta)

    End Sub

    Public Function Datos_TablaRequerimientosEspecialesCliente(clienteID As Integer, areaOperativa As Integer) As DataTable

        Dim VentasPoliticasDA As New Datos.VentasPoliticasDA

        Return VentasPoliticasDA.Datos_TablaRequerimientosEspecialesCliente(clienteID, areaOperativa)

    End Function

    Public Function Datos_TablaRequerimientosCliente() As DataTable

        Dim VentasPoliticasDA As New Datos.VentasPoliticasDA

        Return VentasPoliticasDA.Datos_TablaRequerimientosCliente()

    End Function

    Public Function Datos_TablaTipoRequerimientosCliente() As DataTable

        Dim VentasPoliticasDA As New Datos.VentasPoliticasDA

        Return VentasPoliticasDA.Datos_TablaTipoRequerimientosCliente()

    End Function

    Public Sub AltaRequerimientoCliente(requerimiento As Entidades.RequerimientoEspCliente)

        Dim VentasPoliticasDA As New Datos.VentasPoliticasDA

        VentasPoliticasDA.AltaRequerimientoCliente(requerimiento)

    End Sub

    Public Sub EditarRequerimientoCliente(requerimiento As Entidades.RequerimientoEspCliente)

        Dim VentasPoliticasDA As New Datos.VentasPoliticasDA

        VentasPoliticasDA.EditarRequerimientoCliente(requerimiento)

    End Sub

    Public Function Datos_TablaPoliticaVenta(clienteID As Integer) As DataTable

        Dim VentasPoliticasDA As New Datos.VentasPoliticasDA
        Return VentasPoliticasDA.Datos_TablaPoliticaVenta(clienteID)

    End Function

    ''' <summary>
    ''' RECUPERA EL NOMBRE DEL TIPO DE ETIQUETA CONFIGURADA COMO ETIQUETA ESPECIAL.
    ''' </summary>
    ''' <returns>DATATABLE CON LA INFORMACION RECUPERADA</returns>
    ''' <remarks></remarks>
    Public Function Consultar_Nombre_TipoEtiqueta() As DataTable
        Dim objDA As New Datos.VentasPoliticasDA
        Consultar_Nombre_TipoEtiqueta = objDA.Consultar_Nombre_Etiqueta_Cliente
        Return Consultar_Nombre_TipoEtiqueta
    End Function
    
    Public Sub ActualizarRutaArchivoPDF_FTC_Etiquetado(ByVal Ruta_PDF As String, ByVal IdClienteSAY As Integer, ByVal Alta_Baja_Archivo As Boolean)
        Dim objDA As New Datos.VentasPoliticasDA
        objDA.ActualizarRutaArchivoPDF_FTC_Etiquetado(Ruta_PDF, IdClienteSAY, Alta_Baja_Archivo)
    End Sub


    Public Function ConsultarRutaFTCEtiqueta(ByVal IdClienteSAY As Integer)
        Dim objDA As New Datos.VentasPoliticasDA
        Dim dtDatos As New DataTable

        dtDatos = objDA.ConsultarRutaFTCEtiqueta(IdClienteSAY)

        Return dtDatos
    End Function

    Public Sub EliminarRutaEtiquetaespecial(ByVal IdClienteSAY As Integer)
        Dim objDA As New Datos.VentasPoliticasDA
        objDA.EliminarRutaEtiquetaespecial(IdClienteSAY)
    End Sub

    Public Function ConsultarCorridasExtranjeras(ClienteID As Integer) As DataTable
        Dim objDA As New Datos.VentasPoliticasDA

        Try
            Return objDA.ConsultarCorridasExtranjeras(ClienteID)
        Catch ex As Exception
            Throw ex
        End Try

    End Function


    Public Sub GuardarCorridaExtranjeraCliente(TallasExtranjeras As Entidades.TallasExtranjerasCliente, Seleccionado As Integer)
        Dim VentasDatos As New Datos.VentasPoliticasDA

        Try
            VentasDatos.GuardarCorridaExtranjeraCliente(TallasExtranjeras, Seleccionado)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Public Function ConsultaEtiquetaAutorizada(ByVal clienteID As Integer) As DataTable
        Dim VentasDatos As New Datos.VentasPoliticasDA
        Try
            Return VentasDatos.ConsultaEtiquetaAutorizada(clienteID)
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Sub EliminaEtiquetaFichaTecnica(ByVal clienteID As Integer, ByVal usuarioID As Integer, ByVal tipoEtiqueta As Integer, ByVal NombreEtiqueta As String)
        Dim VentasDatos As New Datos.VentasPoliticasDA
        Try
            VentasDatos.EliminaEtiquetaFichaTecnica(clienteID, usuarioID, tipoEtiqueta, NombreEtiqueta)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


End Class
