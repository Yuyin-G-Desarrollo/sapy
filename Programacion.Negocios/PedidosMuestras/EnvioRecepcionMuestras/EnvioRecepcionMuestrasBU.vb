Public Class EnvioRecepcionMuestrasBU
    Public Function ConsultaTablaFiltros(ByVal Tabla As String, ByVal cedisId As Integer, Optional ByVal Param1 As String = Nothing) As DataTable
        Dim EnvioRecepcionMuestrasDA As New Programacion.Datos.EnvioRecepcionMuestrasDA
        Try
            Return EnvioRecepcionMuestrasDA.ConsultaTablaFiltros(Tabla, cedisId, Param1)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function ConsultarUbicacionPiezas(ByVal EntFiltros As Entidades.FiltrosEnvioRecepcionMuestras) As DataTable
        Dim EnvioRecepcionMuestrasDA As New Programacion.Datos.EnvioRecepcionMuestrasDA
        Try
            Return EnvioRecepcionMuestrasDA.ConsultarUbicacionPiezas(EntFiltros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ConsultaDetallada(ByVal PorPorcentaje As Boolean,
                                  ByVal Operador As String,
                                  ByVal Naves As String,
                                  ByVal Piezas As String,
                                  ByVal Clientes As String,
                                  ByVal PedidosM As String,
                                  ByVal Articulos As String,
                                  ByVal Corridas As String,
                                  ByVal Tallas As String,
                                  ByVal FechaEntregaNave As String,
                                  ByVal FechaEntregaCliente As String,
                                  ByVal FechaEnvioDeNave As String,
                                  ByVal FechaRecepcionDeComer As String,
                                  ByVal cedisIdNave As String
                                  ) As DataTable
        Dim objDA As New Programacion.Datos.EnvioRecepcionMuestrasDA
        Try
            Return objDA.ConsultaDetallada(PorPorcentaje, Operador, Naves, Piezas, Clientes, PedidosM, Articulos, Corridas, Tallas, FechaEntregaNave,
                                           FechaEntregaCliente, FechaEnvioDeNave, FechaRecepcionDeComer, cedisIdNave)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ConsultaResumenProductos(ByVal Operador As String,
                              ByVal Naves As String,
                              ByVal Piezas As String,
                              ByVal Clientes As String,
                              ByVal PedidosM As String,
                              ByVal Articulos As String,
                              ByVal Corridas As String,
                              ByVal Tallas As String,
                              ByVal FechaEntregaNave As String,
                              ByVal FechaEntregaCliente As String,
                              ByVal FechaEnvioDeNave As String,
                              ByVal FechaRecepcionDeComer As String,
                              ByVal cedisIdNave As String
                              ) As DataTable
        Dim objDA As New Programacion.Datos.EnvioRecepcionMuestrasDA
        Try
            Return objDA.ConsultaResumenProductos(Operador, Naves, Piezas, Clientes, PedidosM, Articulos, Corridas, Tallas, FechaEntregaNave,
                                           FechaEntregaCliente, FechaEnvioDeNave, FechaRecepcionDeComer, cedisIdNave)
        Catch ex As Exception
            Throw ex
        End Try
    End Function



    Public Function ConsultaMuestrasPorNave(ByVal AgruparMarcaCollecionTemporada As Boolean,
                                            ByVal AgruparModelo As Boolean,
                                            ByVal AgruparPielColor As Boolean,
                                            ByVal AgruparCorrida As Boolean,
                                            ByVal Operador As String,
                                            ByVal Naves As String,
                                            ByVal Piezas As String,
                                            ByVal Clientes As String,
                                            ByVal PedidosM As String,
                                            ByVal Articulos As String,
                                            ByVal Corridas As String,
                                            ByVal Tallas As String,
                                            ByVal FechaEntregaNave As String,
                                            ByVal FechaEntregaCliente As String,
                                            ByVal FechaEnvioDeNave As String,
                                            ByVal FechaRecepcionDeComer As String,
                                            ByVal cedisIdNave As String
                                            ) As DataTable
        Dim objDA As New Programacion.Datos.EnvioRecepcionMuestrasDA
        Try
            Return objDA.ConsultaMuestrasPorNave(AgruparMarcaCollecionTemporada, AgruparModelo, AgruparPielColor, AgruparCorrida, Operador, Naves, Piezas, Clientes, PedidosM, Articulos, Corridas, Tallas, FechaEntregaNave,
                                           FechaEntregaCliente, FechaEnvioDeNave, FechaRecepcionDeComer, cedisIdNave)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function ConsultaMovimientosMuestras(ByVal EntFiltro As Entidades.FiltrosEnvioRecepcionMuestras) As DataTable
        Dim objDA As New Programacion.Datos.EnvioRecepcionMuestrasDA
        Try
            Return objDA.ConsultaMovimientosMuestras(EntFiltro)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
