Imports System.Data.SqlClient
Public Class EstadisticasVentasDA
    Public Function reporteGeneralConcentradoTotal(ByVal Reporte As Int16,
                                                        ByVal UsuarioId As Integer,
                                                        ByVal FechaInicio As String,
                                                        ByVal FechaFin As String,
                                                        ByVal Cliente As String,
                                                        ByVal Agente As String,
                                                        ByVal Marca As String,
                                                        ByVal Familia As String,
                                                        ByVal Coleccion As String,
                                                        ByVal Estatus As String,
                                                        ByVal ReporteConVenta As Int16
                                                        ) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim dtResultadoConsulta As New DataTable

        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter


        Try
            parametro.ParameterName = "@UsuarioIdSay"
            parametro.Value = UsuarioId
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@FechaInicio"
            parametro.Value = FechaInicio
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@FechaFin"
            parametro.Value = FechaFin
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@ClientesIDSay"
            parametro.Value = Cliente
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@AgentesIDSay"
            parametro.Value = Agente
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@MarcasIDSay"
            parametro.Value = Marca
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@FamiliasProyeccionIDSay"
            parametro.Value = Familia
            listaParametros.Add(parametro)


            parametro = New SqlParameter
            parametro.ParameterName = "@ColeccionMarcaIDSay"
            parametro.Value = Coleccion
            listaParametros.Add(parametro)





            Select Case Reporte
                Case 1
                    dtResultadoConsulta = objPersistencia.EjecutarConsultaSP("Ventas.SP_Ventas_EscritorioSAY_EstadVtasGral_ConcentradoTotal", listaParametros)
                Case 2
                    dtResultadoConsulta = objPersistencia.EjecutarConsultaSP("Ventas.SP_Ventas_EscritorioSAY_EstadVtasGral_ClienteFamilia", listaParametros)
                Case 3
                    parametro = New SqlParameter
                    parametro.ParameterName = "@EstatusArticulos"
                    parametro.Value = Estatus
                    listaParametros.Add(parametro)

                    parametro = New SqlParameter
                    parametro.ParameterName = "@ReporteConVenta"
                    parametro.Value = ReporteConVenta
                    listaParametros.Add(parametro)

                    dtResultadoConsulta = objPersistencia.EjecutarConsultaSP("Ventas.SP_Ventas_EscritorioSAY_EstadVtasMensual_ConcentradoTotal", listaParametros)
                Case 4

                    dtResultadoConsulta = objPersistencia.EjecutarConsultaSP("Ventas.SP_Ventas_EscritorioSAY_EstadVtasMensual_ClienteFamilia", listaParametros)
            End Select



            Return dtResultadoConsulta
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function reporteGeneralConcentradoTotal_Vista(ByVal Reporte As Int16,
                                                       ByVal UsuarioId As Integer,
                                                       ByVal FechaInicio As String,
                                                       ByVal FechaFin As String,
                                                       ByVal Cliente As String,
                                                       ByVal Agente As String,
                                                       ByVal Marca As String,
                                                       ByVal Familia As String,
                                                       ByVal Coleccion As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim dtResultadoConsulta As New DataTable

        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter


        Try
            parametro.ParameterName = "@UsuarioIdSay"
            parametro.Value = UsuarioId
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@FechaInicio"
            parametro.Value = FechaInicio
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@FechaFin"
            parametro.Value = FechaFin
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@ClientesIDSay"
            parametro.Value = Cliente
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@AgentesIDSay"
            parametro.Value = Agente
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@MarcasIDSay"
            parametro.Value = Marca
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@FamiliasProyeccionIDSay"
            parametro.Value = Familia
            listaParametros.Add(parametro)


            parametro = New SqlParameter
            parametro.ParameterName = "@ColeccionMarcaIDSay"
            parametro.Value = Coleccion
            listaParametros.Add(parametro)

            Select Case Reporte
                Case 1
                    dtResultadoConsulta = objPersistencia.EjecutarConsultaSP("Ventas.SP_Ventas_EscritorioSAY_EstadVtasGral_ConcentradoTotal_V2", listaParametros)
                Case 2
                    dtResultadoConsulta = objPersistencia.EjecutarConsultaSP("Ventas.SP_Ventas_EscritorioSAY_EstadVtasGral_ClienteFamilia", listaParametros)
                Case 3
                    'dtResultadoConsulta = objPersistencia.EjecutarConsultaSP("Ventas.SP_Ventas_EscritorioSAY_EstadVtasMensual_ConcentradoTotal", listaParametros)
                    'dtResultadoConsulta = objPersistencia.EjecutarConsultaSP("Ventas.SP_Ventas_EscritorioSAY_EstadVtasMensual_ConcentradoTotal_Pruebas", listaParametros)
                    dtResultadoConsulta = objPersistencia.EjecutarConsultaSP("Ventas.SP_Ventas_EscritorioSAY_EstadVtasMensual_ConcentradoTotal_V2", listaParametros)
                Case 4
                    dtResultadoConsulta = objPersistencia.EjecutarConsultaSP("Ventas.SP_Ventas_EscritorioSAY_EstadVtasMensual_ClienteFamilia", listaParametros)
            End Select



            Return dtResultadoConsulta
        Catch ex As Exception
            Throw ex
        End Try
    End Function


End Class
