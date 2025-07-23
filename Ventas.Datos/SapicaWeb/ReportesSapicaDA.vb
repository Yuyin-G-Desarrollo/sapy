Imports System.Data.SqlClient
Imports Entidades

Public Class ReportesSapicaDA
    ''consulta de las familia de ventas  pantalla de filtros
    Public Function listadoFamiliaVentas() As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = String.Empty

        consulta = " EXEC Sapica.SP_PedidosWeb_Rep_ListadoFamiliaVentas"

        Return persistencia.EjecutaConsulta(consulta)
    End Function

    ''consulta de los estatus de las partidas pantalla filtros
    Public Function listadoEstatusPartidas() As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = String.Empty

        consulta = " EXEC Sapica.SP_PedidosWeb_Rep_ListadoEstatusPartidas"

        Return persistencia.EjecutaConsulta(consulta)
    End Function

    ''consulta del reporte de pares por familia
    Public Function reporteParesPorFamilia(ByVal idEvento As Int32, ByVal visitantes As String, ByVal clientes As String, ByVal atendio As String, ByVal marcas As String,
                                           ByVal coleccion As String, ByVal familiaVentas As String, ByVal modelo As String, ByVal corrida As String,
                                           ByVal piel As String, ByVal color As String, ByVal estatusPartida As String, ByVal fechaCaptura As Int32,
                                           ByVal fechaCapturaInicio As String, ByVal fechaCapturaFin As String, ByVal fechaProgramacion As Int32,
                                           ByVal fechaProgramacionInicio As String, ByVal fechaProgramacionFin As String, ByVal tipoCondicion As String) As DataTable

        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "idEvento"
        parametro.Value = idEvento
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "visitantes"
        parametro.Value = visitantes
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "clientes"
        parametro.Value = clientes
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "atendio"
        parametro.Value = atendio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "marcas"
        parametro.Value = marcas
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "coleccion"
        parametro.Value = coleccion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "familiaVentas"
        parametro.Value = familiaVentas
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "modelo"
        parametro.Value = modelo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "corrida"
        parametro.Value = corrida
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "piel"
        parametro.Value = piel
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "color"
        parametro.Value = color
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "estatusPartida"
        parametro.Value = estatusPartida
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fechaCaptura"
        parametro.Value = fechaCaptura
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fechaCapturaInicio"
        parametro.Value = fechaCapturaInicio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fechaCapturaFin"
        parametro.Value = fechaCapturaFin
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fechaProgramacion"
        parametro.Value = fechaProgramacion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fechaProgramacionInicio"
        parametro.Value = fechaProgramacionInicio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fechaProgramacionFin"
        parametro.Value = fechaProgramacionFin
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "tipoCondicion"
        parametro.Value = tipoCondicion
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("SAPICA.SP_PedidosWeb_Rep_ParesPorFamilia", listaParametros)
    End Function

    ''consulta del reporte de pares por marca
    Public Function reporteParesPorMarca(ByVal idEvento As Int32, ByVal visitantes As String, ByVal clientes As String, ByVal atendio As String, ByVal marcas As String,
                                           ByVal coleccion As String, ByVal familiaVentas As String, ByVal modelo As String, ByVal corrida As String,
                                           ByVal piel As String, ByVal color As String, ByVal estatusPartida As String, ByVal fechaCaptura As Int32,
                                           ByVal fechaCapturaInicio As String, ByVal fechaCapturaFin As String, ByVal fechaProgramacion As Int32,
                                           ByVal fechaProgramacionInicio As String, ByVal fechaProgramacionFin As String, ByVal tipoCondicion As String) As DataTable

        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "idEvento"
        parametro.Value = idEvento
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "visitantes"
        parametro.Value = visitantes
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "clientes"
        parametro.Value = clientes
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "atendio"
        parametro.Value = atendio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "marcas"
        parametro.Value = marcas
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "coleccion"
        parametro.Value = coleccion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "familiaVentas"
        parametro.Value = familiaVentas
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "modelo"
        parametro.Value = modelo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "corrida"
        parametro.Value = corrida
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "piel"
        parametro.Value = piel
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "color"
        parametro.Value = color
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "estatusPartida"
        parametro.Value = estatusPartida
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fechaCaptura"
        parametro.Value = fechaCaptura
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fechaCapturaInicio"
        parametro.Value = fechaCapturaInicio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fechaCapturaFin"
        parametro.Value = fechaCapturaFin
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fechaProgramacion"
        parametro.Value = fechaProgramacion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fechaProgramacionInicio"
        parametro.Value = fechaProgramacionInicio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fechaProgramacionFin"
        parametro.Value = fechaProgramacionFin
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "tipoCondicion"
        parametro.Value = tipoCondicion
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("SAPICA.SP_PedidosWeb_Rep_ParesPorMarca", listaParametros)
    End Function


    ''consulta del reporte de pares por corrida
    Public Function reporteParesPorCorrida(ByVal idEvento As Int32, visitantes As String, ByVal clientes As String, ByVal atendio As String, ByVal marcas As String,
                                           ByVal coleccion As String, ByVal familiaVentas As String, ByVal modelo As String, ByVal corrida As String,
                                           ByVal piel As String, ByVal color As String, ByVal estatusPartida As String, ByVal fechaCaptura As Int32,
                                           ByVal fechaCapturaInicio As String, ByVal fechaCapturaFin As String, ByVal fechaProgramacion As Int32,
                                           ByVal fechaProgramacionInicio As String, ByVal fechaProgramacionFin As String, ByVal tipoCondicion As String) As DataTable

        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "idEvento"
        parametro.Value = idEvento
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "visitantes"
        parametro.Value = visitantes
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "clientes"
        parametro.Value = clientes
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "atendio"
        parametro.Value = atendio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "marcas"
        parametro.Value = marcas
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "coleccion"
        parametro.Value = coleccion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "familiaVentas"
        parametro.Value = familiaVentas
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "modelo"
        parametro.Value = modelo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "corrida"
        parametro.Value = corrida
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "piel"
        parametro.Value = piel
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "color"
        parametro.Value = color
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "estatusPartida"
        parametro.Value = estatusPartida
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fechaCaptura"
        parametro.Value = fechaCaptura
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fechaCapturaInicio"
        parametro.Value = fechaCapturaInicio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fechaCapturaFin"
        parametro.Value = fechaCapturaFin
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fechaProgramacion"
        parametro.Value = fechaProgramacion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fechaProgramacionInicio"
        parametro.Value = fechaProgramacionInicio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fechaProgramacionFin"
        parametro.Value = fechaProgramacionFin
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "tipoCondicion"
        parametro.Value = tipoCondicion
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("SAPICA.SP_PedidosWeb_Rep_ParesPorCorrida", listaParametros)
    End Function

    ''consulta listado de marcas
    Public Function listadoMarcas() As DataTable
        Dim consulta As String = String.Empty
        Dim persistencia As New Persistencia.OperacionesProcedimientos

        consulta = "EXEC SAPICA.SP_PedidosWeb_Rep_ListadoMarcas"

        Return persistencia.EjecutaConsulta(consulta)
    End Function

    ''consulta del reporte de pares por familia coleccion
    Public Function reporteParesPorFamiliaColeccion(ByVal idEvento As Int32, ByVal visitantes As String, ByVal clientes As String, ByVal atendio As String, ByVal marcas As String,
                                           ByVal coleccion As String, ByVal familiaVentas As String, ByVal modelo As String, ByVal corrida As String,
                                           ByVal piel As String, ByVal color As String, ByVal estatusPartida As String, ByVal fechaCaptura As Int32,
                                           ByVal fechaCapturaInicio As String, ByVal fechaCapturaFin As String, ByVal fechaProgramacion As Int32,
                                           ByVal fechaProgramacionInicio As String, ByVal fechaProgramacionFin As String, ByVal tipoCondicion As String) As DataTable

        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "idEvento"
        parametro.Value = idEvento
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "visitantes"
        parametro.Value = visitantes
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "clientes"
        parametro.Value = clientes
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "atendio"
        parametro.Value = atendio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "marcas"
        parametro.Value = marcas
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "coleccion"
        parametro.Value = coleccion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "familiaVentas"
        parametro.Value = familiaVentas
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "modelo"
        parametro.Value = modelo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "corrida"
        parametro.Value = corrida
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "piel"
        parametro.Value = piel
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "color"
        parametro.Value = color
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "estatusPartida"
        parametro.Value = estatusPartida
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fechaCaptura"
        parametro.Value = fechaCaptura
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fechaCapturaInicio"
        parametro.Value = fechaCapturaInicio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fechaCapturaFin"
        parametro.Value = fechaCapturaFin
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fechaProgramacion"
        parametro.Value = fechaProgramacion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fechaProgramacionInicio"
        parametro.Value = fechaProgramacionInicio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fechaProgramacionFin"
        parametro.Value = fechaProgramacionFin
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "tipoCondicion"
        parametro.Value = tipoCondicion
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("SAPICA.SP_PedidosWeb_Rep_ParesPorFamiliaColeccion", listaParametros)
    End Function

    ''consulta del reporte de pares por coleccion modelo
    Public Function reporteParesPorColeccionModelo(ByVal idEvento As Int32, ByVal visitantes As String, ByVal clientes As String, ByVal atendio As String, ByVal marcas As String,
                                           ByVal coleccion As String, ByVal familiaVentas As String, ByVal modelo As String, ByVal corrida As String,
                                           ByVal piel As String, ByVal color As String, ByVal estatusPartida As String, ByVal fechaCaptura As Int32,
                                           ByVal fechaCapturaInicio As String, ByVal fechaCapturaFin As String, ByVal fechaProgramacion As Int32,
                                           ByVal fechaProgramacionInicio As String, ByVal fechaProgramacionFin As String, ByVal tipoCondicion As String) As DataTable

        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "idEvento"
        parametro.Value = idEvento
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "visitantes"
        parametro.Value = visitantes
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "clientes"
        parametro.Value = clientes
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "atendio"
        parametro.Value = atendio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "marcas"
        parametro.Value = marcas
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "coleccion"
        parametro.Value = coleccion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "familiaVentas"
        parametro.Value = familiaVentas
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "modelo"
        parametro.Value = modelo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "corrida"
        parametro.Value = corrida
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "piel"
        parametro.Value = piel
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "color"
        parametro.Value = color
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "estatusPartida"
        parametro.Value = estatusPartida
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fechaCaptura"
        parametro.Value = fechaCaptura
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fechaCapturaInicio"
        parametro.Value = fechaCapturaInicio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fechaCapturaFin"
        parametro.Value = fechaCapturaFin
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fechaProgramacion"
        parametro.Value = fechaProgramacion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fechaProgramacionInicio"
        parametro.Value = fechaProgramacionInicio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fechaProgramacionFin"
        parametro.Value = fechaProgramacionFin
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "tipoCondicion"
        parametro.Value = tipoCondicion
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("SAPICA.SP_PedidosWeb_Rep_ParesPorColeccionModelo", listaParametros)
    End Function

    ''consulta del reporte de pares por coleccion corrida
    Public Function reporteParesPorColeccionCorrida(ByVal idEvento As Int32, ByVal visitantes As String, ByVal clientes As String, ByVal atendio As String, ByVal marcas As String,
                                           ByVal coleccion As String, ByVal familiaVentas As String, ByVal modelo As String, ByVal corrida As String,
                                           ByVal piel As String, ByVal color As String, ByVal estatusPartida As String, ByVal fechaCaptura As Int32,
                                           ByVal fechaCapturaInicio As String, ByVal fechaCapturaFin As String, ByVal fechaProgramacion As Int32,
                                           ByVal fechaProgramacionInicio As String, ByVal fechaProgramacionFin As String, ByVal tipoCondicion As String) As DataTable

        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "idEvento"
        parametro.Value = idEvento
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "visitantes"
        parametro.Value = visitantes
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "clientes"
        parametro.Value = clientes
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "atendio"
        parametro.Value = atendio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "marcas"
        parametro.Value = marcas
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "coleccion"
        parametro.Value = coleccion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "familiaVentas"
        parametro.Value = familiaVentas
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "modelo"
        parametro.Value = modelo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "corrida"
        parametro.Value = corrida
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "piel"
        parametro.Value = piel
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "color"
        parametro.Value = color
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "estatusPartida"
        parametro.Value = estatusPartida
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fechaCaptura"
        parametro.Value = fechaCaptura
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fechaCapturaInicio"
        parametro.Value = fechaCapturaInicio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fechaCapturaFin"
        parametro.Value = fechaCapturaFin
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fechaProgramacion"
        parametro.Value = fechaProgramacion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fechaProgramacionInicio"
        parametro.Value = fechaProgramacionInicio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fechaProgramacionFin"
        parametro.Value = fechaProgramacionFin
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "tipoCondicion"
        parametro.Value = tipoCondicion
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("SAPICA.SP_PedidosWeb_Rep_ParesPorColeccionCorrida", listaParametros)
    End Function

    ''consulta del reporte de pares por coleccion piel color
    Public Function reporteParesPorColeccionPielColor(ByVal idEvento As Int32, ByVal visitantes As String, ByVal clientes As String, ByVal atendio As String, ByVal marcas As String,
                                           ByVal coleccion As String, ByVal familiaVentas As String, ByVal modelo As String, ByVal corrida As String,
                                           ByVal piel As String, ByVal color As String, ByVal estatusPartida As String, ByVal fechaCaptura As Int32,
                                           ByVal fechaCapturaInicio As String, ByVal fechaCapturaFin As String, ByVal fechaProgramacion As Int32,
                                           ByVal fechaProgramacionInicio As String, ByVal fechaProgramacionFin As String, ByVal tipoCondicion As String) As DataTable

        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "idEvento"
        parametro.Value = idEvento
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "visitantes"
        parametro.Value = visitantes
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "clientes"
        parametro.Value = clientes
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "atendio"
        parametro.Value = atendio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "marcas"
        parametro.Value = marcas
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "coleccion"
        parametro.Value = coleccion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "familiaVentas"
        parametro.Value = familiaVentas
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "modelo"
        parametro.Value = modelo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "corrida"
        parametro.Value = corrida
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "piel"
        parametro.Value = piel
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "color"
        parametro.Value = color
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "estatusPartida"
        parametro.Value = estatusPartida
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fechaCaptura"
        parametro.Value = fechaCaptura
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fechaCapturaInicio"
        parametro.Value = fechaCapturaInicio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fechaCapturaFin"
        parametro.Value = fechaCapturaFin
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fechaProgramacion"
        parametro.Value = fechaProgramacion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fechaProgramacionInicio"
        parametro.Value = fechaProgramacionInicio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fechaProgramacionFin"
        parametro.Value = fechaProgramacionFin
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "tipoCondicion"
        parametro.Value = tipoCondicion
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("SAPICA.SP_PedidosWeb_Rep_ParesPorColeccionPielColor", listaParametros)
    End Function

    ''consulta reporte de visitas
    Public Function reporteVisitas(ByVal idEvento As Int32, ByVal fechaCaptura As Int32, ByVal fechaCapturaInicio As String, ByVal fechaCapturaFin As String) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "idEvento"
        parametro.Value = idEvento
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fechaCaptura"
        parametro.Value = fechaCaptura
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fechaCapturaInicio"
        parametro.Value = fechaCapturaInicio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fechaCapturaFin"
        parametro.Value = fechaCapturaFin
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("SAPICA.SP_PedidosWeb_Rep_Visitas", listaParametros)
    End Function

    ''conuslta reporte comparativo
    Public Function reporteComparativo(ByVal idEvento As Int32, ByVal fechaCaptura As Int32, ByVal fechaCapturaInicio As String,
                                       ByVal fechaCapturaFin As String) As DataTable

        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "idEvento"
        parametro.Value = idEvento
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fechaCaptura"
        parametro.Value = fechaCaptura
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fechaCapturaInicio"
        parametro.Value = fechaCapturaInicio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fechaCapturaFin"
        parametro.Value = fechaCapturaFin
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("SAPICA.SP_PedidosWeb_Rep_Comparativo", listaParametros)
    End Function

    ''consulta reporte partidas
    Public Function reportePartidas(ByVal idEvento As Int32, ByVal visitantes As String, ByVal clientes As String, ByVal atendio As String, ByVal marcas As String,
                                           ByVal coleccion As String, ByVal familiaVentas As String, ByVal modelo As String, ByVal corrida As String,
                                           ByVal piel As String, ByVal color As String, ByVal estatusPartida As String, ByVal fechaCaptura As Int32,
                                           ByVal fechaCapturaInicio As String, ByVal fechaCapturaFin As String, ByVal fechaProgramacion As Int32,
                                           ByVal fechaProgramacionInicio As String, ByVal fechaProgramacionFin As String, ByVal tipoCondicion As String) As DataTable

        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "idEvento"
        parametro.Value = idEvento
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "visitantes"
        parametro.Value = visitantes
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "clientes"
        parametro.Value = clientes
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "atendio"
        parametro.Value = atendio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "marcas"
        parametro.Value = marcas
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "coleccion"
        parametro.Value = coleccion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "familiaVentas"
        parametro.Value = familiaVentas
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "modelo"
        parametro.Value = modelo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "corrida"
        parametro.Value = corrida
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "piel"
        parametro.Value = piel
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "color"
        parametro.Value = color
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "estatusPartida"
        parametro.Value = estatusPartida
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fechaCaptura"
        parametro.Value = fechaCaptura
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fechaCapturaInicio"
        parametro.Value = fechaCapturaInicio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fechaCapturaFin"
        parametro.Value = fechaCapturaFin
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fechaProgramacion"
        parametro.Value = fechaProgramacion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fechaProgramacionInicio"
        parametro.Value = fechaProgramacionInicio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fechaProgramacionFin"
        parametro.Value = fechaProgramacionFin
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "tipoCondicion"
        parametro.Value = tipoCondicion
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("SAPICA.SP_PedidosWeb_Rep_Partidas", listaParametros)
    End Function

    ''consulta listado visitantes
    Public Function consultalistadoVisitantes(ByVal opcionFiltro As Int32, ByVal filtro As String) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "opcionFiltro"
        parametro.Value = opcionFiltro
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "filtro"
        parametro.Value = filtro
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("SAPICA.SP_PedidosWeb_Rep_ConsultaClientesVisitantes", listaParametros)
    End Function


    ''consulta listado de eventos
    Public Function listadoEventos() As DataTable
        Dim consulta As String = String.Empty
        Dim persistencia As New Persistencia.OperacionesProcedimientos

        consulta = "EXEC SAPICA.SP_PedidosWeb_Rep_ConsultaEventos"

        Return persistencia.EjecutaConsulta(consulta)
    End Function

    ''consulta listado de colecciones
    Public Function listadoColecciones() As DataTable
        Dim consulta As String = String.Empty
        Dim persistencia As New Persistencia.OperacionesProcedimientos

        consulta = "EXEC SAPICA.SP_PedidosWeb_Rep_ConsultaListadoColecciones"

        Return persistencia.EjecutaConsulta(consulta)
    End Function

    ''consulta listado de modelos
    Public Function listadoModelos() As DataTable
        Dim consulta As String = String.Empty
        Dim persistencia As New Persistencia.OperacionesProcedimientos

        consulta = "EXEC SAPICA.SP_PedidosWeb_Rep_ListadoModelos"

        Return persistencia.EjecutaConsulta(consulta)
    End Function
#Region "Pedidos Ventas Mensuales"
    Public Function ConsultaReporteVtaMensualClienteFamilia(ByVal usuarioId As Int32, ByVal fechaInicio As Date, ByVal fechaFin As Date, ByVal clientesIdSay As String, ByVal AgentesId As String, ByVal MarcasId As String, ByVal FamiliasId As String, ByVal coleccionesId As String) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientosSICY()
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)
        Dim tabla As DataTable = Nothing
        Try
            listaParametros.Add(New SqlParameter(parameterName:="@UsuarioIdSay", value:=usuarioId))
            listaParametros.Add(New SqlParameter(parameterName:="@FechaInicio", value:=fechaInicio))
            listaParametros.Add(New SqlParameter(parameterName:="@FechaFin", value:=fechaFin))
            listaParametros.Add(New SqlParameter(parameterName:="@ClientesIDSay", value:=clientesIdSay))
            listaParametros.Add(New SqlParameter(parameterName:="@AgentesIDSay", value:=AgentesId))
            listaParametros.Add(New SqlParameter(parameterName:="@MarcasIDSay", value:=MarcasId))
            listaParametros.Add(New SqlParameter(parameterName:="@FamiliasProyeccionIDSay", value:=FamiliasId))
            listaParametros.Add(New SqlParameter(parameterName:="@ColeccionMarcaIDSay", value:=coleccionesId))
            tabla = persistencia.EjecutarConsultaSP("Ventas.SP_Ventas_ReportesSayWeb_EstadVtasMensual_ClienteFamilia", listaParametros)
        Catch ex As Exception
            Throw New ArgumentException(MensajesPedidosMuestra.CNSErrorInsercionPedidoMuestra)
        Finally
            persistencia = Nothing
            listaParametros = Nothing
        End Try

        Return tabla
    End Function

    Public Function ConsultaReporteVtaMensualConcentradoTotal(ByVal usuarioId As Int32, ByVal fechaInicio As Date, ByVal fechaFin As Date, ByVal clientesIdSay As String, ByVal AgentesId As String, ByVal MarcasId As String, ByVal FamiliasId As String, ByVal coleccionesId As String) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientosSICY()
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)
        Dim tabla As DataTable = Nothing
        Try
            listaParametros.Add(New SqlParameter(parameterName:="@UsuarioIdSay", value:=usuarioId))
            listaParametros.Add(New SqlParameter(parameterName:="@FechaInicio", value:=fechaInicio))
            listaParametros.Add(New SqlParameter(parameterName:="@FechaFin", value:=fechaFin))
            listaParametros.Add(New SqlParameter(parameterName:="@ClientesIDSay", value:=clientesIdSay))
            listaParametros.Add(New SqlParameter(parameterName:="@AgentesIDSay", value:=AgentesId))
            listaParametros.Add(New SqlParameter(parameterName:="@MarcasIDSay", value:=MarcasId))
            listaParametros.Add(New SqlParameter(parameterName:="@FamiliasProyeccionIDSay", value:=FamiliasId))
            listaParametros.Add(New SqlParameter(parameterName:="@ColeccionMarcaIDSay", value:=coleccionesId))
            tabla = persistencia.EjecutarConsultaSP("Ventas.SP_Ventas_ReportesSayWeb_EstadVtasMensual_ConcentradoTotal", listaParametros)
        Catch ex As Exception
            Throw New ArgumentException(MensajesPedidosMuestra.CNSErrorInsercionPedidoMuestra)
        Finally
            persistencia = Nothing
            listaParametros = Nothing
        End Try

        Return tabla
    End Function
#End Region
End Class
