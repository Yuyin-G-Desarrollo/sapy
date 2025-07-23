Imports System.Collections.Generic
Imports System.Data.SqlClient

Public Class DevolucionCliente_EntradaSalida_Naves

    Public operaciones As New Persistencia.OperacionesProcedimientos

    Public Function ConsultaNaves()
        Return operaciones.EjecutarConsultaSP("[Almacen].[SP_DevolucionCliente_SalidaNaves_ConsultaNaves]", New List(Of SqlParameter))
    End Function

    Public Function ConsultarSalidas(ByVal FiltroFecha As Int16,
                                     ByVal TipoFecha As String,
                                     ByVal fechaInicio As String,
                                     ByVal fechaFin As String,
                                     ByVal folioSalida As String,
                                     ByVal estatus As String,
                                     ByVal Cliente As String,
                                     ByVal FoliosDevolucion As String)

        Dim listaParametros As New List(Of SqlParameter)

        listaParametros.Add(New SqlParameter With {
            .ParameterName = "@FiltroFecha",
            .Value = FiltroFecha
        })

        listaParametros.Add(New SqlParameter With {
            .ParameterName = "@TipoFecha",
            .Value = TipoFecha
        })

        listaParametros.Add(New SqlParameter With {
            .ParameterName = "@FechaInicio",
            .Value = fechaInicio
        })

        listaParametros.Add(New SqlParameter With {
            .ParameterName = "@FechaFin",
            .Value = fechaFin
        })

        listaParametros.Add(New SqlParameter With {
            .ParameterName = "@FolioSalida",
            .Value = folioSalida
        })

        listaParametros.Add(New SqlParameter With {
            .ParameterName = "@Estatus",
            .Value = estatus
        })

        listaParametros.Add(New SqlParameter With {
            .ParameterName = "@Cliente",
            .Value = Cliente
        })

        listaParametros.Add(New SqlParameter With {
            .ParameterName = "@FoliosDevolucion",
            .Value = FoliosDevolucion
        })

        Return operaciones.EjecutarConsultaSP("[Almacen].[SP_DevolucionCliente_SalidaNaves_ConsultaSalidas]", listaParametros)
    End Function

    Public Function ConsultaCodigoPar(ByVal codigo As String, ByVal NaveSICY As Int16)
        Dim listaParametros As New List(Of SqlParameter)

        listaParametros.Add(New SqlParameter With {
            .ParameterName = "@CodigoPar",
            .Value = codigo
        })

        listaParametros.Add(New SqlParameter With {
            .ParameterName = "@IdNave",
            .Value = NaveSICY
        })

        Return operaciones.EjecutarConsultaSP("[Almacen].[SP_DevolucionCliente_SalidaNaves_ConsultaCodigo]", listaParametros)
    End Function

    Public Function GenerarSalida(ByVal xmlSalidas As String)
        Dim listaParametros As New List(Of SqlParameter)

        listaParametros.Add(New SqlParameter With {
            .ParameterName = "@xmlSalidas",
            .Value = xmlSalidas
        })

        Return operaciones.EjecutarConsultaSP("[Almacen].[SP_DevolucionCliente_SalidaNaves_GenerarSalida]", listaParametros)
    End Function

    Public Function GenerarEntrada(ByVal xmlEntrada As String)
        Dim listaParametros As New List(Of SqlParameter)

        listaParametros.Add(New SqlParameter With {
            .ParameterName = "@xmlEntrada",
            .Value = xmlEntrada
        })

        Return operaciones.EjecutarConsultaSP("[Almacen].[SP_DevolucionCliente_SalidaNaves_GenerarEntrada]", listaParametros)
    End Function

    Public Function ConsultaDetallesSalidas(ByVal FolioSalida As Integer)
        Dim listaParametros As New List(Of SqlParameter)

        listaParametros.Add(New SqlParameter With {
            .ParameterName = "@FolioSalida",
            .Value = FolioSalida
        })

        Return operaciones.EjecutarConsultaSP("[Almacen].[SP_DevolucionCliente_SalidaNaves_ConsultaDetalles_Salidas]", listaParametros)
    End Function

    Public Function ConsultaReporteSalidas(ByVal FolioSalida As Integer)
        Dim listaParametros As New List(Of SqlParameter)

        listaParametros.Add(New SqlParameter With {
            .ParameterName = "@FolioSalida",
            .Value = FolioSalida
        })

        Return operaciones.EjecutarConsultaSP("[Almacen].[SP_DevolucionCliente_Reportes_ReporteDetalladoTallas]", listaParametros)
    End Function

End Class
