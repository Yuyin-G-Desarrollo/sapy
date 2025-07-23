Imports Produccion.Datos

Public Class ProyeccionMaterialBU

    Public Function ObtenerProyeccionMaterialAnual(ByVal pIdNave As Integer, ByVal pFechaInicio As Date, ByVal pFechaFin As Date, ByVal pIdColeccion As String, ByVal pIdModelo As String, ByVal pPielColor As String, ByVal pIdCorrida As String, ByVal pIdProveedor As String, ByVal pIdClasificacion As String, ByVal CriticosDias As Integer) As DataTable
        Dim obj As New ProyeccionMaterialDA
        Return obj.ObtieneProyeccionMaterialAnual(pIdNave, pFechaInicio, pFechaFin, pIdColeccion, pIdModelo, pPielColor, pIdCorrida, pIdProveedor, pIdClasificacion, CriticosDias)
    End Function

    Public Function ObtenerProyeccionMaterialAnualColeccion(ByVal pIdNave As Integer, ByVal pFechaInicio As Date, ByVal pFechaFin As Date, ByVal pIdColeccion As String, ByVal pIdModelo As String, ByVal pPielColor As String, ByVal pIdCorrida As String, ByVal pIdProveedor As String, ByVal pIdClasificacion As String, ByVal CriticosDias As Integer) As DataTable
        Dim obj As New ProyeccionMaterialDA
        Return obj.ObtieneProyeccionMaterialAnualColeccion(pIdNave, pFechaInicio, pFechaFin, pIdColeccion, pIdModelo, pPielColor, pIdCorrida, pIdProveedor, pIdClasificacion, CriticosDias)
    End Function

    Public Function ObtenerProyeccionMaterialMensual(ByVal pIdNave As Integer, ByVal pFechaInicio As Date, ByVal pFechaFin As Date, ByVal pIdColeccion As String, ByVal pIdModelo As String, ByVal pPielColor As String, ByVal pIdCorrida As String, ByVal pIdProveedor As String, ByVal pIdClasificacion As String, ByVal CriticosDias As Integer) As DataTable
        Dim obj As New ProyeccionMaterialDA
        Return obj.ObtieneProyeccionMaterialMensual(pIdNave, pFechaInicio, pFechaFin, pIdColeccion, pIdModelo, pPielColor, pIdCorrida, pIdProveedor, pIdClasificacion, CriticosDias)
    End Function

    Public Function ObtenerProyeccionMaterialMensualColeccion(ByVal pIdNave As Integer, ByVal pFechaInicio As Date, ByVal pFechaFin As Date, ByVal pIdColeccion As String, ByVal pIdModelo As String, ByVal pPielColor As String, ByVal pIdCorrida As String, ByVal pIdProveedor As String, ByVal pIdClasificacion As String, ByVal CriticosDias As Integer) As DataTable
        Dim obj As New ProyeccionMaterialDA
        Return obj.ObtieneProyeccionMaterialMensualColeccion(pIdNave, pFechaInicio, pFechaFin, pIdColeccion, pIdModelo, pPielColor, pIdCorrida, pIdProveedor, pIdClasificacion, CriticosDias)
    End Function

    Public Function ObtenerProyeccionMaterialSemanal(ByVal pIdNave As Integer, ByVal pFechaInicio As Date, ByVal pFechaFin As Date, ByVal pIdColeccion As String, ByVal pIdModelo As String, ByVal pPielColor As String, ByVal pIdCorrida As String, ByVal pIdProveedor As String, ByVal pIdClasificacion As String, ByVal CriticosDias As Integer) As DataTable
        Dim obj As New ProyeccionMaterialDA
        Return obj.ObtieneProyeccionMaterialSemanal(pIdNave, pFechaInicio, pFechaFin, pIdColeccion, pIdModelo, pPielColor, pIdCorrida, pIdProveedor, pIdClasificacion, CriticosDias)
    End Function

    Public Function ObtenerProyeccionMaterialSemanalColeccion(ByVal pIdNave As Integer, ByVal pFechaInicio As Date, ByVal pFechaFin As Date, ByVal pIdColeccion As String, ByVal pIdModelo As String, ByVal pPielColor As String, ByVal pIdCorrida As String, ByVal pIdProveedor As String, ByVal pIdClasificacion As String, ByVal CriticosDias As Integer) As DataTable
        Dim obj As New ProyeccionMaterialDA
        Return obj.ObtieneProyeccionMaterialSemanalColeccion(pIdNave, pFechaInicio, pFechaFin, pIdColeccion, pIdModelo, pPielColor, pIdCorrida, pIdProveedor, pIdClasificacion, CriticosDias)
    End Function

    Public Function ObtenerProyeccionMaterialPrograma(ByVal pIdNave As Integer, ByVal pFechaInicio As Date, ByVal pFechaFin As Date, ByVal pIdColeccion As String, ByVal pIdModelo As String, ByVal pPielColor As String, ByVal pIdCorrida As String, ByVal pIdProveedor As String, ByVal pIdClasificacion As String, ByVal CriticosDias As Integer) As DataTable
        Dim obj As New ProyeccionMaterialDA
        Return obj.ObtieneProyeccionMaterialPrograma(pIdNave, pFechaInicio, pFechaFin, pIdColeccion, pIdModelo, pPielColor, pIdCorrida, pIdProveedor, pIdClasificacion, CriticosDias)
    End Function

    Public Function ObtenerProyeccionMaterialProgramaColeccion(ByVal pIdNave As Integer, ByVal pFechaInicio As Date, ByVal pFechaFin As Date, ByVal pIdColeccion As String, ByVal pIdModelo As String, ByVal pPielColor As String, ByVal pIdCorrida As String, ByVal pIdProveedor As String, ByVal pIdClasificacion As String, ByVal CriticosDias As Integer) As DataTable
        Dim obj As New ProyeccionMaterialDA
        Return obj.ObtieneProyeccionMaterialProgramaColeccion(pIdNave, pFechaInicio, pFechaFin, pIdColeccion, pIdModelo, pPielColor, pIdCorrida, pIdProveedor, pIdClasificacion, CriticosDias)
    End Function

    Public Function ObtenerConsultaFiltro(ByVal pTipoConsulta As Integer, ByVal pIdNave As Integer) As DataTable
        Dim obj As New ProyeccionMaterialDA
        Return obj.ObtieneConsultaFiltro(pTipoConsulta, pIdNave)
    End Function

    Public Function ObtenerExplosionMateriales(ByVal pIdNave As Integer, ByVal pFechaInicio As Date, ByVal pFechaFin As Date) As DataTable
        Dim obj As New ProyeccionMaterialDA
        Return obj.ObtieneExplosionMateriales(pIdNave, pFechaInicio, pFechaFin)
    End Function

    '..............................

    Public Function ObtenerProyeccionMaterialAnualLoteado(ByVal pIdNave As Integer, ByVal pFechaInicio As Date, ByVal pFechaFin As Date, ByVal pIdColeccion As String, ByVal pIdModelo As String, ByVal pPielColor As String, ByVal pIdCorrida As String, ByVal pIdProveedor As String, ByVal pIdClasificacion As String, ByVal CriticosDias As Integer) As DataTable
        Dim obj As New ProyeccionMaterialDA
        Return obj.ObtieneProyeccionMaterialAnualLoteado(pIdNave, pFechaInicio, pFechaFin, pIdColeccion, pIdModelo, pPielColor, pIdCorrida, pIdProveedor, pIdClasificacion, CriticosDias)
    End Function

    Public Function ObtenerProyeccionMaterialMensualLoteado(ByVal pIdNave As Integer, ByVal pFechaInicio As Date, ByVal pFechaFin As Date, ByVal pIdColeccion As String, ByVal pIdModelo As String, ByVal pPielColor As String, ByVal pIdCorrida As String, ByVal pIdProveedor As String, ByVal pIdClasificacion As String, ByVal CriticosDias As Integer) As DataTable
        Dim obj As New ProyeccionMaterialDA
        Return obj.ObtieneProyeccionMaterialMensualLoteado(pIdNave, pFechaInicio, pFechaFin, pIdColeccion, pIdModelo, pPielColor, pIdCorrida, pIdProveedor, pIdClasificacion, CriticosDias)
    End Function

    Public Function ObtenerProyeccionMaterialSemanalLoteado(ByVal pIdNave As Integer, ByVal pFechaInicio As Date, ByVal pFechaFin As Date, ByVal pIdColeccion As String, ByVal pIdModelo As String, ByVal pPielColor As String, ByVal pIdCorrida As String, ByVal pIdProveedor As String, ByVal pIdClasificacion As String, ByVal CriticosDias As Integer) As DataTable
        Dim obj As New ProyeccionMaterialDA
        Return obj.ObtieneProyeccionMaterialSemanalLoteado(pIdNave, pFechaInicio, pFechaFin, pIdColeccion, pIdModelo, pPielColor, pIdCorrida, pIdProveedor, pIdClasificacion, CriticosDias)
    End Function

    Public Function ObtenerProyeccionMaterialProgramaLoteado(ByVal pIdNave As Integer, ByVal pFechaInicio As Date, ByVal pFechaFin As Date, ByVal pIdColeccion As String, ByVal pIdModelo As String, ByVal pPielColor As String, ByVal pIdCorrida As String, ByVal pIdProveedor As String, ByVal pIdClasificacion As String, ByVal CriticosDias As Integer) As DataTable
        Dim obj As New ProyeccionMaterialDA
        Return obj.ObtieneProyeccionMaterialProgramaLoteado(pIdNave, pFechaInicio, pFechaFin, pIdColeccion, pIdModelo, pPielColor, pIdCorrida, pIdProveedor, pIdClasificacion, CriticosDias)
    End Function

    Public Function ObtenerExplosionMaterialesLoteado(ByVal pIdNave As Integer, ByVal pFechaInicio As Date, ByVal pFechaFin As Date) As DataTable
        Dim obj As New ProyeccionMaterialDA
        Return obj.ObtieneExplosionMaterialesLoteado(pIdNave, pFechaInicio, pFechaFin)
    End Function

    Public Function ObtieneProyeccionMaterialTallas(ByVal pIdNave As Integer, ByVal pFechaInicio As Date, ByVal pFechaFin As Date, ByVal pIdColeccion As String, ByVal pIdModelo As String, ByVal pPielColor As String, ByVal pIdCorrida As String, ByVal pIdProveedor As String, ByVal pIdClasificacion As String, ByVal CriticosDias As Integer) As DataTable
        Dim obj As New ProyeccionMaterialDA
        Return obj.ObtieneProyeccionMaterialTallas(pIdNave, pFechaInicio, pFechaFin, pIdColeccion, pIdModelo, pPielColor, pIdCorrida, pIdProveedor, pIdClasificacion, CriticosDias)
    End Function

    Public Function ObtieneProyeccionMaterialTallasColeccion(ByVal pIdNave As Integer, ByVal pFechaInicio As Date, ByVal pFechaFin As Date, ByVal pIdColeccion As String, ByVal pIdModelo As String, ByVal pPielColor As String, ByVal pIdCorrida As String, ByVal pIdProveedor As String, ByVal pIdClasificacion As String, ByVal CriticosDias As Integer) As DataTable
        Dim obj As New ProyeccionMaterialDA
        Return obj.ObtieneProyeccionMaterialTallasColeccion(pIdNave, pFechaInicio, pFechaFin, pIdColeccion, pIdModelo, pPielColor, pIdCorrida, pIdProveedor, pIdClasificacion, CriticosDias)
    End Function

    Public Function ObtieneProyeccionMaterialTallasLoteado(ByVal pIdNave As Integer, ByVal pFechaInicio As Date, ByVal pFechaFin As Date, ByVal pIdColeccion As String, ByVal pIdModelo As String, ByVal pPielColor As String, ByVal pIdCorrida As String, ByVal pIdProveedor As String, ByVal pIdClasificacion As String, ByVal CriticosDias As Integer) As DataTable
        Dim obj As New ProyeccionMaterialDA
        Return obj.ObtieneProyeccionMaterialTallasLoteado(pIdNave, pFechaInicio, pFechaFin, pIdColeccion, pIdModelo, pPielColor, pIdCorrida, pIdProveedor, pIdClasificacion, CriticosDias)
    End Function

    Public Function ObtieneProyeccionMaterialProgramaLote(ByVal pIdNave As Integer, ByVal pFechaInicio As Date, ByVal pFechaFin As Date, ByVal pIdColeccion As String, ByVal pIdModelo As String, ByVal pPielColor As String, ByVal pIdCorrida As String, ByVal pIdProveedor As String, ByVal pIdClasificacion As String, ByVal CriticosDias As Integer) As DataTable
        Dim obj As New ProyeccionMaterialDA
        Return obj.ObtieneProyeccionMaterialProgramaLote(pIdNave, pFechaInicio, pFechaFin, pIdColeccion, pIdModelo, pPielColor, pIdCorrida, pIdProveedor, pIdClasificacion, CriticosDias)
    End Function

    Public Function ObtenerProyeccionMaterialSemanalLote(ByVal pIdNave As Integer, ByVal pFechaInicio As Date, ByVal pFechaFin As Date, ByVal pIdColeccion As String, ByVal pIdModelo As String, ByVal pPielColor As String, ByVal pIdCorrida As String, ByVal pIdProveedor As String, ByVal pIdClasificacion As String, ByVal CriticosDias As Integer) As DataTable
        Dim obj As New ProyeccionMaterialDA
        Return obj.ObtieneProyeccionMaterialSemanalLote(pIdNave, pFechaInicio, pFechaFin, pIdColeccion, pIdModelo, pPielColor, pIdCorrida, pIdProveedor, pIdClasificacion, CriticosDias)
    End Function

    Public Function ObtenerProyeccionMaterialMensualLote(ByVal pIdNave As Integer, ByVal pFechaInicio As Date, ByVal pFechaFin As Date, ByVal pIdColeccion As String, ByVal pIdModelo As String, ByVal pPielColor As String, ByVal pIdCorrida As String, ByVal pIdProveedor As String, ByVal pIdClasificacion As String, ByVal CriticosDias As Integer) As DataTable
        Dim obj As New ProyeccionMaterialDA
        Return obj.ObtieneProyeccionMaterialMensualLote(pIdNave, pFechaInicio, pFechaFin, pIdColeccion, pIdModelo, pPielColor, pIdCorrida, pIdProveedor, pIdClasificacion, CriticosDias)
    End Function

    Public Function ObtenerProyeccionMaterialAnualLote(ByVal pIdNave As Integer, ByVal pFechaInicio As Date, ByVal pFechaFin As Date, ByVal pIdColeccion As String, ByVal pIdModelo As String, ByVal pPielColor As String, ByVal pIdCorrida As String, ByVal pIdProveedor As String, ByVal pIdClasificacion As String, ByVal CriticosDias As Integer) As DataTable
        Dim obj As New ProyeccionMaterialDA
        Return obj.ObtieneProyeccionMaterialAnualLote(pIdNave, pFechaInicio, pFechaFin, pIdColeccion, pIdModelo, pPielColor, pIdCorrida, pIdProveedor, pIdClasificacion, CriticosDias)
    End Function

    Public Function ObtieneProyeccionMaterialTallasLote(ByVal pIdNave As Integer, ByVal pFechaInicio As Date, ByVal pFechaFin As Date, ByVal pIdColeccion As String, ByVal pIdModelo As String, ByVal pPielColor As String, ByVal pIdCorrida As String, ByVal pIdProveedor As String, ByVal pIdClasificacion As String, ByVal CriticosDias As Integer) As DataTable
        Dim obj As New ProyeccionMaterialDA
        Return obj.ObtieneProyeccionMaterialTallasLote(pIdNave, pFechaInicio, pFechaFin, pIdColeccion, pIdModelo, pPielColor, pIdCorrida, pIdProveedor, pIdClasificacion, CriticosDias)
    End Function

    Public Function ReporteProyeccionMateriales(ByVal pIdNave As Integer, ByVal pFechaInicio As Date, ByVal pFechaFin As Date, pClasificacion As String) As DataTable
        Dim obj As New ProyeccionMaterialDA
        Return obj.ReporteProyeccionMateriales(pIdNave, pFechaInicio, pFechaFin, pClasificacion)
    End Function

    Public Function ReporteProyeccionMaterialesSinteticosCorte(ByVal pIdNave As Integer, ByVal pFechaInicio As Date, ByVal pFechaFin As Date, pClasificacion As String, semana As Integer, anio As Integer) As DataTable
        Dim obj As New ProyeccionMaterialDA
        Return obj.ReporteProyeccionMaterialesSinteticosCorte(pIdNave, pFechaInicio, pFechaFin, pClasificacion, semana, anio)
    End Function

    Public Function ObtenerFEchaInicioFin(ByVal Semana As Integer, ByVal Año As Integer) As DataTable
        Dim obj As New ProyeccionMaterialDA
        Return obj.ObtenerFEchaInicioFin(Semana, Año)
    End Function

    Public Function GenerarReporteExplosionMaterialesDirectosSinIVA(ByVal pIdNave As Integer,
                                                                    ByVal pFechaInicio As Date,
                                                                    ByVal pFechaFin As Date,
                                                                    ByVal Accion As Integer,
                                                                    ByVal NumeroSemana As Integer,
                                                                    ByVal AnioConsulta As Integer) As DataTable
        Dim obj As New ProyeccionMaterialDA
        Return obj.GenerarReporteExplosionMaterialesDirectosSinIVA(pIdNave, pFechaInicio, pFechaFin, Accion, NumeroSemana, AnioConsulta)
    End Function


    Public Function GenerarReporteExplosionMaterialesDirectosConIVA(ByVal pIdNave As Integer,
                                                                ByVal pFechaInicio As Date,
                                                                ByVal pFechaFin As Date,
                                                                ByVal Accion As Integer,
                                                                ByVal NumeroSemana As Integer,
                                                                ByVal AnioConsulta As Integer) As DataTable
        Dim obj As New ProyeccionMaterialDA
        Return obj.GenerarReporteExplosionMaterialesDirectosConIVA(pIdNave, pFechaInicio, pFechaFin, Accion, NumeroSemana, AnioConsulta)
    End Function

End Class
