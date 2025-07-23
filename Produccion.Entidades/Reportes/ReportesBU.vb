Imports Produccion.Datos

Public Class ReportesBU

    Public Function ObtenerClasificacion(ByVal clasificacion As String) As DataTable
        Dim obj As New ReportesDA
        Return obj.ObtenerClasificacion(clasificacion)
    End Function

    Public Function ObtenerIdComponentes(ByVal componente As String, ByVal componente2 As String) As DataTable
        Dim obj As New ReportesDA
        Return obj.ObtenerIdComponentes(componente, componente2)
    End Function

    Public Function ObtenerComponentes(ByVal componente As String, ByVal componente2 As String) As DataTable
        Dim obj As New ReportesDA
        Return obj.ObtenerComponentes(componente, componente2)
    End Function

    Public Function ConcentradoFormato5(ByVal fechaPrograma As String, ByVal nave As Integer,
                                        ByVal clasificacion As Integer) As DataTable
        Dim obj As New ReportesDA
        Return obj.ConcentradoFormato5(fechaPrograma, nave, clasificacion)
    End Function

    Public Function ReporteMaterialesFormato2(ByVal fechaPrograma As String, ByVal nave As Integer,
                                              ByVal clasificacion As Integer) As DataTable
        Dim obj As New ReportesDA
        Return obj.ReporteMaterialesFormato2(fechaPrograma, nave, clasificacion)
    End Function

    Public Function ReporteMaterialesFormato2Planta(ByVal fechaPrograma As String, ByVal nave As Integer,
                                           ByVal clasificacion As Integer) As DataTable
        Dim obj As New ReportesDA
        Return obj.ReporteMaterialesFormato2Planta(fechaPrograma, nave, clasificacion)
    End Function


    Public Function ReporteDesglosadoCaja(ByVal fechaPrograma As String, ByVal nave As Integer,
                                           ByVal clasificacion As Integer) As DataTable
        Dim obj As New ReportesDA
        Return obj.DesglosadoCaja(fechaPrograma, nave, clasificacion)
    End Function


    Public Function ReporteMaterialesFormatoPlanta(ByVal fechaPrograma As String, ByVal nave As Integer,
                                           ByVal clasificacion As Integer) As DataTable
        Dim obj As New ReportesDA
        Return obj.ReporteMaterialesFormatoPlanta(fechaPrograma, nave, clasificacion)
    End Function


    Public Function ReporteMaterialesFormato2Caja(ByVal fechaPrograma As String, ByVal nave As Integer,
                                          ByVal clasificacion As Integer) As DataTable
        Dim obj As New ReportesDA
        Return obj.ReporteMaterialesFormato2Caja(fechaPrograma, nave, clasificacion)
    End Function

    Public Function ReporteRelacionDesglosadaDeSuela(ByVal fechaPrograma As String, ByVal nave As Integer,
                                              ByVal clasificacion As Integer) As DataTable
        Dim obj As New ReportesDA
        Return obj.ReporteRelacionDesglosadaDeSuela(fechaPrograma, nave, clasificacion)
    End Function

    Public Function ReporteRelacionDesglosada(ByVal fechaPrograma As String, ByVal nave As Integer, ByVal Clasificacion As Integer) As DataTable
        Dim obj As New ReportesDA
        Return obj.ReporteRelacionDesglosada(fechaPrograma, nave, Clasificacion)
    End Function

    Public Function ReporteRelacionDesglosadaDePlanta(ByVal fechaPrograma As String, ByVal nave As Integer,
                                              ByVal clasificacion As Integer) As DataTable
        Dim obj As New ReportesDA
        Return obj.ReporteRelacionDesglosadaDePlanta(fechaPrograma, nave, clasificacion)
    End Function

    Public Function ReporteRelacionDesglosadaDeCascoYContrafuerte(ByVal fechaPrograma As String, ByVal nave As Integer,
                                             ByVal clasificacion As Integer) As DataTable
        Dim obj As New ReportesDA
        Return obj.ReporteRelacionDesglosadaDeCascoYContrafuerte(fechaPrograma, nave, clasificacion)
    End Function

    Public Function ConsultaReporteDesglosado(ByVal fechaPrograma As String, ByVal nave As Integer,
                                           ByVal clasificacion As Integer, ByVal clasificacion2 As Integer) As DataTable
        Dim obj As New ReportesDA
        Return obj.ConsultaReporteDesglosado(fechaPrograma, nave, clasificacion, clasificacion2)
    End Function

    Public Function ConsultaReporteHerrajes1N(ByVal fechaPrograma As String, ByVal nave As Integer, ByVal lista As IList(Of Integer)) As DataTable
        Dim obj As New ReportesDA
        Return obj.ConsultaReporteHerrajes1N(fechaPrograma, nave, lista)
    End Function

    Public Function ConsultaReporteHerrajesImpresion(ByVal fechaPrograma As String, ByVal nave As Integer, ByVal lista As IList(Of Integer)) As DataTable
        Dim obj As New ReportesDA
        Return obj.ConsultaReporteHerrajesImpresion(fechaPrograma, nave, lista)
    End Function

    Public Function ConsultaReporteSuelas1N(ByVal fechaPrograma As String, ByVal nave As Integer)
        Dim obj As New ReportesDA
        Return obj.ConsultaReporteSuelas1N(fechaPrograma, nave)
    End Function

    Public Function ConsultaReporteTacon(ByVal fechaprograma As String, ByVal Idnave As Integer, ByVal IdClasificacion As Integer)
        Dim obj As New ReportesDA
        Return obj.ConsultaReporteTacon(fechaprograma, Idnave, IdClasificacion)
    End Function

    Public Function ReporteDeFormato3(ByVal fechaPrograma As String, ByVal nave As Integer,
                                             ByVal clasificacion As Integer) As DataTable
        Dim obj As New ReportesDA
        Return obj.ReporteDeFormato3(fechaPrograma, nave, clasificacion)
    End Function

    'Public Function ReporteDeglosadoPlantilla(ByVal fecha As String, ByVal nave As Integer, ByVal clas As Integer) As DataTable
    '    Dim obj As New ReportesDA
    '    Return obj.ReporteDeglosadoPlantilla(fecha, nave, clas)
    'End Function

    Public Function ReporteOrdenesDeProduccion(ByVal fechaPrograma As String, ByVal nave As Integer,
                                              ByVal clasificacion As Integer) As DataTable
        Dim obj As New ReportesDA
        Return obj.ReporteOrdenesDeProduccion(fechaPrograma, nave, clasificacion)
    End Function

    Public Function ConsultaCasco1(ByVal fechaPrograma As String, ByVal nave As Integer,
                                              ByVal clasificacion As Integer) As DataTable
        Dim obj As New ReportesDA
        Return obj.ConsultaCasco1(fechaPrograma, nave, clasificacion)
    End Function

    Public Function ConsultaCasco2(ByVal fechaPrograma As String, ByVal nave As Integer,
                                              ByVal clasificacion As Integer) As DataTable
        Dim obj As New ReportesDA
        Return obj.ConsultaCasco2(fechaPrograma, nave, clasificacion)
    End Function

    Public Function ConsultaContrafuerte1(ByVal fechaPrograma As String, ByVal nave As Integer,
                                             ByVal clasificacion As Integer) As DataTable
        Dim obj As New ReportesDA
        Return obj.ConsultaContrafuerte1(fechaPrograma, nave, clasificacion)
    End Function

    Public Function ConsultaContrafuerte2(ByVal fechaPrograma As String, ByVal nave As Integer,
                                             ByVal clasificacion As Integer) As DataTable
        Dim obj As New ReportesDA
        Return obj.ConsultaContrafuerte2(fechaPrograma, nave, clasificacion)
    End Function

    Public Function ConsultaProgramaCorteSuperior(ByVal fecha As String, ByVal nave As Integer,
                                                  ByVal lista As List(Of Integer)) As DataTable
        Dim obj As New ReportesDA
        Return obj.ConsultaProgramaCorteSuperior(fecha, nave, lista)
    End Function

    Public Function ConsultaProgramaCorteInferior(ByVal fecha As String, ByVal nave As Integer,
                                                  ByVal lista As List(Of Integer)) As DataTable
        Dim obj As New ReportesDA
        Return obj.ConsultaProgramaCorteInferior(fecha, nave, lista)
    End Function

    Public Function ConsultaOrdenDePedidoDesglosadoPAraCorte1(ByVal fecha As String, ByVal nave As Integer) As DataTable
        Dim obj As New ReportesDA
        Return obj.ConsultaOrdenDePedidoDesglosadoPAraCorte1(fecha, nave)
    End Function

    Public Function ConsultaOrdenDePedidoDesglosadoPAraCorte2(ByVal fecha As String, ByVal nave As Integer) As DataTable
        Dim obj As New ReportesDA
        Return obj.ConsultaOrdenDePedidoDesglosadoPAraCorte2(fecha, nave)
    End Function

    Public Function ConsultarNaveSicy(ByVal naveSay As Integer) As DataTable
        Dim obj As New ReportesDA
        Return obj.ConsultarNaveSicy(naveSay)
    End Function

    Public Function ConsultaCortadoresReporte(ByVal fechaPrograma As String, ByVal nave As Integer,
                                              ByVal lista As List(Of Integer), ByVal Tipo As String) As DataTable
        Dim obj As New ReportesDA
        Return obj.ConsultaCortadoresReporte(fechaPrograma, nave, lista, Tipo)
    End Function

    Public Function ConsultaMaterialesCortadoresPiel(ByVal fechaPrograma As String, ByVal nave As Integer,
                                                     ByVal lista As List(Of Integer), ByVal Tipo As String) As DataTable
        Dim obj As New ReportesDA
        Return obj.ConsultaMaterialesCortadoresPiel(fechaPrograma, nave, lista, Tipo)
    End Function

    Public Function ConsultaCortadoresPiel(ByVal fechaPrograma As String, ByVal nave As Integer,
                                           ByVal lista As List(Of Integer), ByVal Tipo As String) As DataTable
        Dim obj As New ReportesDA
        Return obj.ConsultaCortadoresPiel(fechaPrograma, nave, lista, Tipo)
    End Function


    Public Function ReporteOrdenesDeProduccionfake(ByVal fechaPrograma As String, ByVal nave As Integer,
                                            ByVal clasificacion As Integer) As DataTable
        Dim obj As New ReportesDA
        Return obj.ReporteOrdenesDeProduccionFake(fechaPrograma, nave, clasificacion)
    End Function

    Public Function ReporteTarjetaProduccionEncabezado(ByVal lote As Integer, ByVal nave As Integer, ByVal añolote As Integer, ByVal productoestilo As Integer) As DataTable
        Dim obj As New ReportesDA
        Return obj.ReporteTarjetaProduccionEncabezado(lote, nave, añolote, productoestilo)
    End Function

    Public Function ObtenerRutaID(ByVal clienteid As Integer) As DataTable
        Dim obj As New ReportesDA
        Return obj.ObtenerRutaID(clienteid)
    End Function

    Public Function ReporteTarjetaProduccionTotalDCMComponentePiel(ByVal pe As Integer, ByVal Nave As Integer) As DataTable
        Dim obj As New ReportesDA
        Return obj.ReporteTarjetaProduccionTotalDCMComponentePiel(pe, Nave)
    End Function
    Public Function ReporteTarjetaProduccionTotalDCMPielSintetica(ByVal pi As Integer, ByVal Nave As Integer) As DataTable
        Dim obj As New ReportesDA
        Return obj.ReporteTarjetaProduccionTotalDCMPielSintetica(pi, Nave)
    End Function

    Public Function ReporteTarjetaProduccionProductoEstilo(ByVal lote As Integer, ByVal nave As Integer, ByVal añolote As Integer) As DataTable
        Dim obj As New ReportesDA
        Return obj.ReporteTarjetaProduccionProductoEstilo(lote, nave, añolote)
    End Function

    Public Function ReporteTarjetaProduccionNumeracion(ByVal lote As Integer, ByVal nave As Integer, ByVal añolote As Integer) As DataTable
        Dim obj As New ReportesDA
        Return obj.ReporteTarjetaProduccionNumeracion(lote, nave, añolote)
    End Function

    Public Function ReporteTarjetaProduccionFracciones(ByVal lote As Integer, ByVal nave As Integer, ByVal añolote As Integer) As DataTable
        Dim obj As New ReportesDA
        Return obj.ReporteTarjetaProduccionFracciones(lote, nave, añolote)
    End Function

    Public Function ReporteTarjetaProduccionTotalTiempoFracciones(ByVal tiempo As Integer) As DataTable
        Dim obj As New ReportesDA
        Return obj.ReporteTarjetaProduccionTotalTiempoFracciones(tiempo)
    End Function

    'Public Function x() As DataTable
    '    Dim obj As New ReportesDA
    '    Return obj.x()
    'End Function
    Public Function ConsultaCortadoresPielForroSintetico(ByVal fechaPrograma As String, ByVal nave As Integer,
                                           ByVal lista As List(Of Integer), ByVal Tipo As String) As DataTable
        Dim obj As New ReportesDA
        Return obj.ConsultaCortadoresPielForroSintetico(fechaPrograma, nave, lista, Tipo)
    End Function

    Public Function ConsultaCortadoresPielForro(ByVal fechaPrograma As String, ByVal nave As Integer,
                                          ByVal lista As List(Of Integer), ByVal Tipo As String) As DataTable
        Dim obj As New ReportesDA
        Return obj.ConsultaCortadoresPielForro(fechaPrograma, nave, lista, Tipo)
    End Function

    Public Function ConsultaCortadoresPielSintetico(ByVal fechaPrograma As String, ByVal nave As Integer,
                                          ByVal lista As List(Of Integer), ByVal Tipo As String) As DataTable
        Dim obj As New ReportesDA
        Return obj.ConsultaCortadoresPielSintetico(fechaPrograma, nave, lista, Tipo)
    End Function

    Public Function ConsultaCortadoresPielPiel(ByVal fechaPrograma As String, ByVal nave As Integer,
                                        ByVal lista As List(Of Integer), ByVal Tipo As String) As DataTable
        Dim obj As New ReportesDA
        Return obj.ConsultaCortadoresPielPiel(fechaPrograma, nave, lista, Tipo)
    End Function

    Public Function ConsultarSumaCortadorPielSint(ByVal fechaPrograma As String, ByVal nave As Integer,
                                       ByVal lista As List(Of Integer)) As DataTable
        Dim obj As New ReportesDA
        Return obj.ConsultaSumaCortadorPielSint(fechaPrograma, nave, lista)
    End Function

    Public Function ConsultarSumaCortadorForroSint(ByVal fechaPrograma As String, ByVal nave As Integer,
                                       ByVal lista As List(Of Integer)) As DataTable
        Dim obj As New ReportesDA
        Return obj.ConsultaSumaCortadorForroSint(fechaPrograma, nave, lista)
    End Function

    Public Function ObtenerConcentradoHerraje(ByVal fechaPrograma As String, ByVal nave As Integer,
        ByVal clasificacion As Integer) As DataTable
        Dim obj As New ReportesDA
        Return obj.ObtieneConcentradoHerraje(fechaPrograma, nave, clasificacion)
    End Function

    Public Function ObtenerExplosionAplicaciones(ByVal fechaPrograma As String, ByVal nave As Integer) As DataTable
        Dim obj As New ReportesDA
        Return obj.ObtineExplosionMateriales(fechaPrograma, nave)
    End Function

    Public Function ConsultaArticulosNoAutorizados(ByVal idNaveSICY As Integer, ByVal fechaPrograma As String) As DataTable
        Dim obj As New ReportesDA
        Return obj.ConsultaArticulosNoAutorizados(idNaveSICY, fechaPrograma)
    End Function

    Public Function ObtenerEncabezado_VistaPreviaTarjetaProduccion(ByVal pProductoEstiloId As Integer, ByVal pNaveId As Integer) As DataTable
        Dim obj As New ReportesDA
        Return obj.ObtieneEncabezado_VistaPreviaTarjetaProduccion(pProductoEstiloId, pNaveId)
    End Function

    Public Function ObtenerNumeracion_VistaPreviaTarjetaProduccion(ByVal pProductoEstiloId As Integer) As DataTable
        Dim obj As New ReportesDA
        Return obj.ObtieneNumeracion_VistaPreviaTarjetaProduccion(pProductoEstiloId)
    End Function

    Public Function ObtenerFracciones_VistaPreviaTarjetaProduccion(ByVal pProductoEstiloId As Integer, ByVal pNaveId As Integer) As DataTable
        Dim obj As New ReportesDA
        Return obj.ObtieneFracciones_VistaPreviaTarjetaProduccion(pProductoEstiloId, pNaveId)
    End Function

    Public Function ObtenerFichaCostoConsumos(ByVal pProductoEstiloId As Integer, ByVal pNaveId As Integer) As DataTable
        Dim obj As New ReportesDA
        Return obj.ObtieneFichaCostoConsumos(pProductoEstiloId, pNaveId)
    End Function

    Public Function ObtenerConcentradoCortePielForro(ByVal pFechaPrograma As Date, ByVal pNaveId As Integer) As DataTable
        Dim obj As New ReportesDA
        Return obj.ObtieneConcentradoCortePielForro(pFechaPrograma, pNaveId)
    End Function

    Public Function ObtenerConcentradoCortePielForroSintetico(ByVal pFechaPrograma As Date, ByVal pNaveId As Integer) As DataTable
        Dim obj As New ReportesDA
        Return obj.ObtieneConcentradoCortePielForroSintetico(pFechaPrograma, pNaveId)
    End Function

    Public Function ObtieneArticulosNoAutorizadosProduccion(ByVal NaveSICY As Integer, ByVal FechaInicio As Date, ByVal FechaFin As Date, ByVal ColaboradorId As Integer) As DataTable
        Dim obj As New ReportesDA
        Return obj.ObtieneArticulosNoAutorizadosProduccion(NaveSICY, FechaInicio, FechaFin, ColaboradorId)
    End Function

    Public Function ObtieneLotes_SAY_SICY(ByVal NaveSAY As Integer, ByVal FechaPrograma As String) As DataTable
        Dim obj As New ReportesDA
        Return obj.ObtieneLotes_SAY_SICY(NaveSAY, FechaPrograma)
    End Function

    Public Function ActualizaLotes_SICY_a_SAY(ByVal NaveSAY As Integer, ByVal FechaProgramaInicio As String, ByVal FechaProgramaFin As String) As DataTable
        Dim obj As New ReportesDA
        Return obj.ActualizaLotes_SICY_a_SAY(NaveSAY, FechaProgramaInicio, FechaProgramaFin)
    End Function
    Public Function ObtenerLotesPiloto(ByVal pIdNaves As String, ByVal pFechaInicio As Date, ByVal pFechaFin As Date) As DataTable
        Dim obj As New ReportesDA
        Return obj.ObtieneLotesPiloto(pIdNaves, pFechaInicio, pFechaFin)
    End Function

    Public Function ReporteRelacionDesglosadaPlantilla(ByVal fechaPrograma As String, ByVal nave As Integer, ByVal Clasificacion As Integer) As DataTable
        Dim obj As New ReportesDA
        Return obj.ReporteRelacionDesglosadaPlantilla(fechaPrograma, nave, Clasificacion)
    End Function

    Public Function ReporteOrdenesDeProduccion_FacturadoYRemisionado(ByVal fechaPrograma As String, ByVal nave As Integer) As DataTable
        Dim obj As New ReportesDA
        Return obj.ReporteOrdenesDeProduccion_FacturadoYRemisionado(fechaPrograma, nave)
    End Function

    Public Function ReporteOrdenesDeProduccion_FacturadoYRemisionadoPorTipo(ByVal fechaPrograma As String, ByVal nave As Integer, ByVal tipo As String) As DataTable
        Dim obj As New ReportesDA
        Return obj.ReporteOrdenesDeProduccion_FacturadoYRemisionadoPorTipo(fechaPrograma, nave, tipo)
    End Function

    Public Function cargarGrupoXNave()
        Dim obj As New ReportesDA
        Return obj.cargarGrupoXNave()
    End Function

    Public Function cargarNavesXGrupo(ByVal grupo As String)
        Dim obj As New ReportesDA
        Return obj.cargarNavesXGrupo(grupo)
    End Function


    Public Function ObtieneArticulosNoAutorizadosProduccionGrupo(ByVal NaveSICY As Integer,
                                                                ByVal FechaInicio As Date,
                                                                ByVal FechaFin As Date,
                                                                ByVal ColaboradorId As Integer,
                                                                ByVal Grupo As String) As DataTable
        Dim obj As New ReportesDA
        Return obj.ObtieneArticulosNoAutorizadosProduccionGrupo(NaveSICY, FechaInicio, FechaFin, ColaboradorId, Grupo)
    End Function

    Public Function ConsultaOrdenDePedidoDesglosadoParaMaquila(ByVal fecha As String, ByVal nave As Integer) As DataTable
        Dim obj As New ReportesDA
        Return obj.ConsultaOrdenDePedidoDesglosadoParaMaquila(fecha, nave)
    End Function

    Public Function ReporteSuelasTrento(ByVal fechaDel As Date, ByVal fechaAl As Date, ByVal idNave As String, ByVal IdClasificacion As Integer, ByVal proveedor As Integer)
        Dim obj As New ReportesDA
        Return obj.ReporteSuelasTrento(fechaDel, fechaAl, idNave, IdClasificacion, proveedor)
    End Function

End Class
