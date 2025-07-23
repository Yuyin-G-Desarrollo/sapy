Public Class ColeccionBU

    Public Function VerMarcaColecion(ByVal activo As Boolean) As DataTable
        Dim CoMaDatos As New Programacion.Datos.ColeccionDA
        Return CoMaDatos.LlenardatosMarcaColeccion(activo)
    End Function

    Public Function LlenarDatosMarcaColeccionDetalle(ByVal activo As Boolean) As DataTable
        Dim CoMaDatos As New Programacion.Datos.ColeccionDA
        Return CoMaDatos.LlenarDatosMarcaColeccionDetalle(activo)
    End Function

    Public Function VerLotesenProceso(ByVal idColeccion As Integer) As DataTable
        Dim LotesProceso As New Programacion.Datos.ColeccionDA
        Return LotesProceso.LlenarDatosLotesenProceso(idColeccion)
    End Function

    'Public Sub AltaColeccionMarca(ByVal idColeccion As Int32, ByVal Coleccion As String, ByVal idMarca As Int32, ByVal codigoSicy As String, ByVal usuario As Int32, ByVal activo As Boolean)
    '    Dim ColeccionNegocios As New Programacion.Datos.ColeccionDA
    '    ColeccionNegocios.InsertarColeccion(idColeccion, Coleccion, idMarca, codigoSicy, usuario, activo)
    'End Sub

    Public Function VerIdMasAltocColeccion() As DataTable
        Dim ColeccionNegocios As New Programacion.Datos.ColeccionDA
        Return ColeccionNegocios.VerIdMasAltocColeccion
    End Function

    Public Function verMaximaMarcaColecion(ByVal idMarca As Int32) As DataTable
        Dim ColeccionNegocios As New Programacion.Datos.ColeccionDA
        Return ColeccionNegocios.MAXExistenciaMarcasoleccion(idMarca)
    End Function

    'Public Function VerCodigosMarcaDisponibles(ByVal marcaid As Int32) As DataTable
    '    Dim ColeccionNegocios As New Programacion.Datos.ColeccionDA
    '    Return ColeccionNegocios.VerCodigosMarcaDisponibles(marcaid)
    'End Function

    Public Function ValidarCodigosMarcas(ByVal marcaid As Int32, ByVal coleccionid As Int32) As DataTable
        Dim ColeccionNegocios As New Programacion.Datos.ColeccionDA
        Return ColeccionNegocios.ValidaMarcaColeccionEditar(marcaid, coleccionid)
    End Function


    Public Function verComboColeccion(ByVal idMarca As String) As DataTable
        Dim ColeccionNegocios As New Programacion.Datos.ColeccionDA
        Return ColeccionNegocios.VerComboColecciones(idMarca)
    End Function


    Public Function verCodigoColeccionRegistroRapido(ByVal idCole As Int32, ByVal idMarc As Int32) As DataTable
        Dim ColeccionNegocios As New Programacion.Datos.ColeccionDA
        Return ColeccionNegocios.verCodigoColeccionRegistroRapido(idCole, idMarc)
    End Function

    Public Function filtromultipleColeccion(ByVal marcaid As String) As DataTable
        Dim ColeccionNegocios As New Programacion.Datos.ColeccionDA
        Return ColeccionNegocios.filtromultipleColeccion(marcaid)
    End Function

    Public Function validarInactivacionCM(ByVal idmarca As String, ByVal idcoleccion As String) As DataTable
        Dim ColeccionNegocios As New Programacion.Datos.ColeccionDA
        Return ColeccionNegocios.validarInactivacionCM(idmarca, idcoleccion)
    End Function

    Public Function LlenardatosColeccionWEB(ByVal marcaID As String, ByVal coleDescripcion As String, ByVal activo As Boolean, ByVal Cliente As Boolean) As DataTable
        Dim CoMaDatos As New Programacion.Datos.ColeccionDA
        Return CoMaDatos.LlenardatosColeccionWEB(marcaID, coleDescripcion, activo, Cliente)
    End Function

    Public Sub inactivarRelacionColeccionMarca(ByVal idColeccion As Int32)
        Dim CoMaDatos As New Programacion.Datos.ColeccionDA
        CoMaDatos.inactivarRelacionColeccionMarca(idColeccion)
    End Sub


    ' ''Metodo correccion colecciones por año 12/09/2014 
    Public Function verColeccionesAnio(ByVal anio As Int32, ByVal idMarca As Int32) As DataTable
        Dim CoMaDatos As New Programacion.Datos.ColeccionDA
        Return CoMaDatos.verColeccionesAnio(anio, idMarca)
    End Function


    ' '' Metodo corrión alta de colección 12/09/2014 
    Public Function InsertarColeccion(ByVal Coleccion As String, ByVal anio As Int32,
                                      ByVal activo As Boolean, ByVal temporadaId As Int32, ByVal EtiquetaLengua As Boolean,
                                      Codigo As String) As Int32
        Dim CoMaDatos As New Programacion.Datos.ColeccionDA
        Return CoMaDatos.InsertarColeccion(Coleccion, anio, activo, temporadaId, EtiquetaLengua, Codigo)
    End Function


    Public Sub InsertarColeccionEtiquetaEspecial(ByVal TipoEtiqueta As Integer, ByVal ColeccionID As Integer, ByVal activo As Boolean)
        Dim CoMaDatos As New Programacion.Datos.ColeccionDA
        Try
            CoMaDatos.InsertarColeccionEtiquetaEspecial(TipoEtiqueta, ColeccionID, activo)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function ConsultarEtiquetaColeccion(ByVal ColeccionID As Integer) As Integer
        Dim CoMaDatos As New Programacion.Datos.ColeccionDA
        Dim dt As DataTable
        Dim valor As Integer
        Try
            dt = CoMaDatos.ConsultarEtiquetaColeccion(ColeccionID)
            If dt.Rows.Count > 0 Then
                valor = CInt(dt.Rows(0).Item(0).ToString)
            Else
                valor = 0
            End If
            Return valor
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    ' '' Metodo corrión alta de Colección-Marca 12/09/2014 
    Public Sub InsertarColeccionMarca(ByVal idColeccion As Int32, ByVal idMarca As Int32,
                                      ByVal codigo As String, ByVal codigoSicy As String,
                                      ByVal activo As Boolean, ByVal anio As Int32,
                                      ByVal idCliente As Int32, ByVal idMarcYuyin As String,
                                      ByVal descripcionColeccionYuyin As String,
                                      ByVal idFamiliaProyeccion As String, ByVal idNaveDesarrolla As Integer, ByVal clasificacion As String)
        Dim CoMaDatos As New Programacion.Datos.ColeccionDA
        CoMaDatos.InsertarColeccionMarca(idColeccion, idMarca, codigo, codigoSicy, activo, anio, idCliente, idMarcYuyin, descripcionColeccionYuyin, idFamiliaProyeccion, idNaveDesarrolla, clasificacion)
    End Sub

    Public Function consultaMarcaRelacionColeccion(ByVal idColeccion As Int32, ByVal idTemporada As Int32) As DataTable
        Dim MarcaDatos As New Programacion.Datos.ColeccionDA
        Return MarcaDatos.consultaMarcaRelacionColeccion(idColeccion, idTemporada)
    End Function

    Public Function VerColeccion(ByVal idColeccion As Int32) As DataTable
        Dim ColeccionNegocios As New Programacion.Datos.ColeccionDA
        Return ColeccionNegocios.VerColeccion(idColeccion)
    End Function

    Public Sub EditarColeccion(ByVal idColeccion As Int32, ByVal descripcion As String, ByVal activoColeccion As Boolean, ByVal anio As Int32, ByVal idTemporada As Int32, ByVal EtiquetaLengua As Boolean)
        Dim ColeccionNegocios As New Programacion.Datos.ColeccionDA
        ColeccionNegocios.EditarColeccion(idColeccion, descripcion, activoColeccion, anio, idTemporada, EtiquetaLengua)
    End Sub

    Public Sub EditarColeccionDetalle(ByVal idColeccion As Int32, ByVal idMarca As String,
                                      ByVal activoRelacion As Boolean, ByVal codigo As String,
                                      ByVal codSicy As String, ByVal existe As Int32,
                                      ByVal idCliente As Int32, ByVal idMarcYuyin As String,
                                      ByVal descripcionColeccionYuyin As String, ByVal idFamiliaProyeccion As String)
        Dim ColeccionNegocios As New Programacion.Datos.ColeccionDA
        ColeccionNegocios.EditarColeccionDetalle(idColeccion, idMarca, activoRelacion, codigo, codSicy, existe, idCliente, idMarcYuyin, descripcionColeccionYuyin, idFamiliaProyeccion)
    End Sub

    Public Function verColeccionGridProducto(ByVal idMarca As String) As DataTable
        Dim ColeccionNegocios As New Programacion.Datos.ColeccionDA
        Return ColeccionNegocios.verColeccionGridProducto(idMarca)
    End Function

    Public Function validarExistenciaColeccion(ByVal codColeccion As String, ByVal idMarca As String, ByVal ColeccionID As Int32) As DataTable
        Dim objPDA As New Programacion.Datos.ColeccionDA
        Return objPDA.validarExistenciaColeccion(codColeccion, idMarca, ColeccionID)
    End Function

    Public Function verConsecutivoCod(ByVal marcaId As String, ByVal coleId As String) As DataTable
        Dim objPDA As New Programacion.Datos.ColeccionDA
        Return objPDA.verConsecutivoCodigo(marcaId, coleId)
    End Function

    Public Function contarEstatusProductosColecciones(ByVal idColeccion As Int32) As DataTable
        Dim objPDA As New Programacion.Datos.ColeccionDA
        Return objPDA.contarEstatusProductosColecciones(idColeccion)
    End Function

    Public Function productosEditarCodigo(ByVal idColeccion As Int32) As DataTable
        Dim objPDA As New Programacion.Datos.ColeccionDA
        Return objPDA.productosEditarCodigo(idColeccion)
    End Function

    Public Sub editarProductosAfectadosCambioAnio(ByVal idProducto As Int32, ByVal codNuevo As String, ByVal idTemporada As Int32)
        Dim objPDA As New Programacion.Datos.ColeccionDA
        objPDA.editarProductosAfectadosCambioAnio(idProducto, codNuevo, idTemporada)
    End Sub

    Public Function consultarConsecutivos(ByVal idMarca As Int32, ByVal idColeccion As Int32) As DataTable
        Dim objPDA As New Programacion.Datos.ColeccionDA
        Return objPDA.consultarConsecutivos(idMarca, idColeccion)
    End Function

    Public Function contarEstilosColeccion(ByVal idColecicon As Int32) As Int32
        Dim objPDA As New Programacion.Datos.ColeccionDA
        Return objPDA.contarEstilosColeccion(idColecicon)
    End Function

    Public Sub inactivarColeccionesClienteSicyCambioFamilia(ByVal marcaSicy As String, ByVal coleccionSIcy As String)
        Dim objPDA As New Programacion.Datos.ColeccionDA
        objPDA.inactivarColeccionesClienteSicyCambioFamilia(marcaSicy, coleccionSIcy)
    End Sub

    Public Sub ejecutarRegistroCambioFamiliasAgenteColeccionSICY(ByVal idMarca As Int32, ByVal idFamilia As Int32)
        Dim objPDA As New Programacion.Datos.ColeccionDA
        objPDA.ejecutarRegistroCambioFamiliasAgenteColeccionSICY(idMarca, idFamilia)
    End Sub

    Public Sub editarMarcaColeccionMismaFamilia(ByVal idMarca As Int32, ByVal coleccionSicy As String, ByVal idFamilia As Int32, ByVal idNaveDesarrolla As Integer, clasificacion As String)
        Dim objPDA As New Programacion.Datos.ColeccionDA
        objPDA.editarMarcaColeccionMismaFamilia(idMarca, coleccionSicy, idFamilia, idNaveDesarrolla, clasificacion)
    End Sub

    Public Function ValidarConsumosColeccion(ByVal idColeccionMarca As Int32) As DataTable
        Dim objPDA As New Programacion.Datos.ColeccionDA
        Return objPDA.ValidarConsumosColeccion(idColeccionMarca)
    End Function

    Public Sub EditarColeccionDetalle2(ByVal idColeccion As Int32, ByVal idMarca As String,
                                     ByVal activoRelacion As Boolean, ByVal codigo As String,
                                     ByVal codSicy As String, ByVal existe As Int32,
                                     ByVal idCliente As Int32, ByVal idMarcYuyin As String,
                                     ByVal descripcionColeccionYuyin As String, ByVal idFamiliaProyeccion As String,
                                        ByVal lengualinea As Integer)
        Dim ColeccionNegocios As New Programacion.Datos.ColeccionDA
        ColeccionNegocios.EditarColeccionDetalle2(idColeccion, idMarca, activoRelacion, codigo, codSicy, existe, idCliente, idMarcYuyin, descripcionColeccionYuyin, idFamiliaProyeccion, lengualinea)
    End Sub

    Public Function EncontrarColeccionSICY(Opcion As Integer) As DataTable
        Dim CoMaDatos As New Datos.ColeccionDA

        Return CoMaDatos.EncontrarColeccionSICY(Opcion)
    End Function

End Class

