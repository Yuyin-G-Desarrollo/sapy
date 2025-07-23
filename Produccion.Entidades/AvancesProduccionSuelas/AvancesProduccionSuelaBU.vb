Imports System.Security.Cryptography
Public Class AvancesProduccionSuelaBU
    Public Function ObtenerColaborador(ByVal pClColaborador As String) As Entidades.ValidaColaborador
        Dim objDA As New Datos.AvancesProduccionSuelaDA
        Dim tabla As New DataTable
        Dim vColaborador As New Entidades.ValidaColaborador

        Try
            tabla = objDA.ObtieneColaborador(pClColaborador)
            If IsNothing(tabla) = False Then
                If tabla.Rows.Count > 0 Then
                    vColaborador.Nave = tabla.Rows(0).Item("Nave")
                    vColaborador.NaveId = tabla.Rows(0).Item("NaveId")
                    vColaborador.NombreColaborador = tabla.Rows(0).Item("NombreColaborador")
                    vColaborador.ColaboradorId = tabla.Rows(0).Item("ColaboradorId")

                End If
            End If

        Catch ex As Exception
            Throw ex
        End Try

        Return vColaborador
    End Function

    Public Function ObtenerEncabezado(ByVal pFolio As String) As Entidades.EncabezadoSuelas
        Dim objDA As New Datos.AvancesProduccionSuelaDA
        Dim tabla As New DataTable
        Dim vEncabezado As New Entidades.EncabezadoSuelas

        Try
            tabla = objDA.ObtieneEncabezado(pFolio)
            If IsNothing(tabla) = False Then
                If tabla.Rows.Count > 0 Then
                    vEncabezado.Programa = tabla.Rows(0).Item("Programa")
                    vEncabezado.ProgramaSuelas = tabla.Rows(0).Item("ProgramaSuelas")
                    vEncabezado.Pares = tabla.Rows(0).Item("Pares")
                    vEncabezado.Nave = tabla.Rows(0).Item("Nave")
                    vEncabezado.Molde = tabla.Rows(0).Item("Molde")
                    vEncabezado.ColorSuela = tabla.Rows(0).Item("ColorSuela")
                    vEncabezado.Acabado = tabla.Rows(0).Item("Acabado")
                    vEncabezado.Familia = tabla.Rows(0).Item("Familia")
                    vEncabezado.RutaImagen = tabla.Rows(0).Item("RutaImagen")
                    vEncabezado.MaquinaId = tabla.Rows(0).Item("MaquinaId")
                    vEncabezado.TotalAvance = tabla.Rows(0).Item("TotalAvance")
                    vEncabezado.ConsecutivoTarjeta = tabla.Rows(0).Item("ConsecutivoTarjeta")
                    vEncabezado.FgTarjetaAgrupada = tabla.Rows(0).Item("FgTarjetaAgrupada")
                End If
            End If

        Catch ex As Exception
            Throw ex
        End Try

        Return vEncabezado
    End Function

    Public Function ObtenerAvances(ByVal pFolio As String, ByVal pMaquina As Integer) As List(Of Entidades.AvanceSuelas)
        Dim objDA As New Datos.AvancesProduccionSuelaDA
        Dim tabla As New DataTable
        Dim vAvance As New Entidades.AvanceSuelas
        Dim vLstAvance As New List(Of Entidades.AvanceSuelas)


        Try
            tabla = objDA.ObtieneAvances(pFolio, pMaquina)

            If IsNothing(tabla) = False Then
                If tabla.Rows.Count > 0 Then
                    For Each Fila As DataRow In tabla.Rows
                        vAvance = New Entidades.AvanceSuelas
                        With vAvance
                            .ClSuela = Fila.Item("ClSuela")
                            .Descripcion = Fila.Item("Descripcion")
                            .N1 = Fila.Item("N1")
                            .N2 = Fila.Item("N2")
                            .N3 = Fila.Item("N3")
                            .N4 = Fila.Item("N4")
                            .N5 = Fila.Item("N5")
                            .N6 = Fila.Item("N6")
                            .N7 = Fila.Item("N7")
                            .N8 = Fila.Item("N8")
                            .N9 = Fila.Item("N9")
                            .N10 = Fila.Item("N10")
                            .N11 = Fila.Item("N11")
                            .N12 = Fila.Item("N12")
                            .N13 = Fila.Item("N13")
                            .N14 = Fila.Item("N14")
                            .N15 = Fila.Item("N15")
                            .TOTAL = Fila.Item("TOTAL")
                        End With
                        vLstAvance.Add(vAvance)
                    Next
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try

        Return vLstAvance
    End Function

    Public Function ObtenerMaquinasProduccion(ByVal pNaveId As Integer) As List(Of Entidades.MaquinasProduccion)
        Dim objDA As New Datos.AvancesProduccionSuelaDA
        Dim tabla As New DataTable
        Dim vMaquina As New Entidades.MaquinasProduccion
        Dim vLstMaquinas As New List(Of Entidades.MaquinasProduccion)

        Try
            tabla = objDA.ObtieneMaquinasProduccion(pNaveId)

            If IsNothing(tabla) = False Then
                If tabla.Rows.Count > 0 Then
                    For Each Fila As DataRow In tabla.Rows
                        vMaquina = New Entidades.MaquinasProduccion
                        With vMaquina
                            .MaquinaProveedorId = Fila.Item("tpmp_maquinaproveedorid")
                            .Maquina = Fila.Item("tpmp_maquina")

                        End With
                        vLstMaquinas.Add(vMaquina)
                    Next
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try

        Return vLstMaquinas
    End Function


    Public Function GuardarAvancesProduccion(ByVal Maquina As Integer, ByVal IdColaborador As Integer, ByVal Avances As String) As DataTable
        Dim objDA As New Datos.AvancesProduccionSuelaDA
        Dim tabla As New DataTable
        Try
            tabla = objDA.GuardaAvancesProduccion(Maquina, IdColaborador, Avances)
            Return tabla
        Catch ex As Exception
            Throw ex
            Return Nothing
        End Try
    End Function

    Public Function ObtenerUltimoAvance(ByVal pFolio As String) As Entidades.UltimoAvance
        Dim objDA As New Datos.AvancesProduccionSuelaDA
        Dim tabla As New DataTable
        Dim vUltimoAvance As New Entidades.UltimoAvance

        Try
            tabla = objDA.ObtieneUltimoAvance(pFolio)
            If IsNothing(tabla) = False Then
                If tabla.Rows.Count > 0 Then
                    vUltimoAvance.Fecha = tabla.Rows(0).Item("fecha")
                    vUltimoAvance.Hora = tabla.Rows(0).Item("Hora")
                    vUltimoAvance.Maquina = tabla.Rows(0).Item("Maquina")
                    vUltimoAvance.NombreColaborador = tabla.Rows(0).Item("NombreColaborador")
                    vUltimoAvance.ParesTerminados = tabla.Rows(0).Item("ParesTerminados")
                End If
            End If

        Catch ex As Exception
            Throw ex
        End Try

        Return vUltimoAvance
    End Function
End Class
