Imports DiseñoConceptual.Datos
Imports Produccion.Datos

Public Class AdministradorResumenCostosBU
    Dim objAdminCostoDA As New AdministradorResumenCostosDA



    Public Function ConsultarNavesDesarrollo() As DataTable
        Dim dtEstatusProductoCosto As New DataTable

        Try
            dtEstatusProductoCosto = objAdminCostoDA.ConsultarNavesDesarrollo()

            If dtEstatusProductoCosto IsNot Nothing Then
                If dtEstatusProductoCosto.Rows.Count > 0 Then
                    Return dtEstatusProductoCosto
                Else
                    Return Nothing
                End If
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Throw ex
            Return Nothing
        End Try
    End Function
    Public Function ConsultarNaveLabora() As DataTable
        Dim dtNaveLabora As New DataTable

        Try
            dtNaveLabora = objAdminCostoDA.ConsultarNaveLabora()

            If dtNaveLabora IsNot Nothing Then
                If dtNaveLabora.Rows.Count > 0 Then
                    Return dtNaveLabora
                Else
                    Return Nothing
                End If
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Throw ex
            Return Nothing
        End Try
    End Function


    Public Function ConsultarMarcas() As DataTable
        Dim dtEstatusProducto As New DataTable

        Try
            dtEstatusProducto = objAdminCostoDA.ConsultarMarcas()

            If dtEstatusProducto IsNot Nothing Then
                If dtEstatusProducto.Rows.Count > 0 Then
                    Return dtEstatusProducto
                Else
                    Return Nothing
                End If
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Throw ex
            Return Nothing
        End Try
    End Function

    Public Function ConsultarColecciones() As DataTable
        Dim dtColecciones As New DataTable

        Try
            dtColecciones = objAdminCostoDA.ConsultarColecciones()

            If dtColecciones IsNot Nothing Then
                If dtColecciones.Rows.Count > 0 Then
                    Return dtColecciones
                Else
                    Return Nothing
                End If
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Throw ex
            Return Nothing
        End Try
    End Function


    Public Function ConsultarEstatusProductoCosto() As DataTable
        Dim dtEstatusProductoCosto As New DataTable

        Try
            dtEstatusProductoCosto = objAdminCostoDA.ConsultarEstatusProductoCosto()

            If dtEstatusProductoCosto IsNot Nothing Then
                If dtEstatusProductoCosto.Rows.Count > 0 Then
                    Return dtEstatusProductoCosto
                Else
                    Return Nothing
                End If
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Throw ex
            Return Nothing
        End Try
    End Function


    Public Function ConsultarEstatusModelos() As DataTable
        Dim dtEstatusProducto As New DataTable

        Try
            dtEstatusProducto = objAdminCostoDA.ConsultarEstatusModelos()

            If dtEstatusProducto IsNot Nothing Then
                If dtEstatusProducto.Rows.Count > 0 Then
                    Return dtEstatusProducto
                Else
                    Return Nothing
                End If
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Throw ex
            Return Nothing
        End Try
    End Function


    Public Function ConsultarResumenCostosPorNave(ByVal NavesDesarrollo As String, ByVal Marcas As String, ByVal Temporadas As String, ByVal Colecciones As String, ByVal EstatusProductoCompra As String, ByVal EsArticulosClientesEspeciales As Boolean) As DataTable
        Dim dtResumenCostosPorNave As New DataTable

        Try
            dtResumenCostosPorNave = objAdminCostoDA.ConsultarResumenCostosPorNave(NavesDesarrollo, Marcas, Temporadas, Colecciones, EstatusProductoCompra, EsArticulosClientesEspeciales)

            If dtResumenCostosPorNave IsNot Nothing Then
                If dtResumenCostosPorNave.Rows.Count > 0 Then
                    Return dtResumenCostosPorNave
                Else
                    Return Nothing
                End If
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Throw ex
            Return Nothing
        End Try
    End Function


    Public Function ConsultarIndicadoresPorNave(ByVal NavesDesarrollo As String, ByVal Marcas As String, ByVal Temporadas As String, ByVal Colecciones As String) As DataTable
        Dim dtResumenCostosPorNave As New DataTable

        Try
            dtResumenCostosPorNave = objAdminCostoDA.ConsultarIndicadoresPorNave(NavesDesarrollo, Marcas, Temporadas, Colecciones)

            If dtResumenCostosPorNave IsNot Nothing Then
                If dtResumenCostosPorNave.Rows.Count > 0 Then
                    Return dtResumenCostosPorNave
                Else
                    Return Nothing
                End If
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Throw ex
            Return Nothing
        End Try
    End Function





    Public Function ConsultarReporteModelosPorColecciones_Encabezados(ByVal NavesDesarrollo As String, ByVal Temporadas As String, ByVal Colecciones As String, ByVal EstatusProductoCompra As String) As DataTable
        Dim dtResumenCostosPorNave As New DataTable

        Try
            dtResumenCostosPorNave = objAdminCostoDA.ConsultarReporteModelosPorColecciones_Encabezados(NavesDesarrollo, Temporadas, Colecciones, EstatusProductoCompra)

            If dtResumenCostosPorNave IsNot Nothing Then
                If dtResumenCostosPorNave.Rows.Count > 0 Then
                    Return dtResumenCostosPorNave
                Else
                    Return Nothing
                End If
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Throw ex
            Return Nothing
        End Try
    End Function

    Public Function ConsultarReporteModelosPorColecciones_Modelos(ByVal NavesDesarrollo As String, ByVal Temporadas As String, ByVal Colecciones As String, ByVal EstatusProductoCompra As String) As DataTable
        Dim dtResumenCostosPorNave As New DataTable

        Try
            dtResumenCostosPorNave = objAdminCostoDA.ConsultarReporteModelosPorColecciones_Modelos(NavesDesarrollo, Temporadas, Colecciones, EstatusProductoCompra)

            If dtResumenCostosPorNave IsNot Nothing Then
                If dtResumenCostosPorNave.Rows.Count > 0 Then
                    Return dtResumenCostosPorNave
                Else
                    Return Nothing
                End If
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Throw ex
            Return Nothing
        End Try
    End Function

    Public Function ConsultarReporteModelosPorColecciones_Especiales(ByVal ProductosEstilosSeleccionados As String) As DataTable
        Dim dtResumenCostos As New DataTable

        Try
            dtResumenCostos = objAdminCostoDA.ConsultarReporteModelosPorColecciones_Especiales(ProductosEstilosSeleccionados)

            If dtResumenCostos IsNot Nothing Then
                If dtResumenCostos.Rows.Count > 0 Then
                    Return dtResumenCostos
                Else
                    Return Nothing
                End If
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Throw ex
            Return Nothing
        End Try
    End Function




    Public Sub GuardarCostoArticulos(ByVal CadenaXMLPrecios As String, ByVal NuevoEstatusId As Integer)
        Try
            objAdminCostoDA.GuardarCostoArticulos(CadenaXMLPrecios, NuevoEstatusId)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub CambiarEstatusPrecioCosto(ByVal ProductosEstilosConcantenados As String, ByVal NuevoEstatusId As Integer)
        Try
            objAdminCostoDA.CambiarEstatusPrecioCosto(ProductosEstilosConcantenados, NuevoEstatusId)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class
