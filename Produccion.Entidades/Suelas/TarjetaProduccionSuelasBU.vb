Imports Entidades
Imports Produccion.Datos

Public Class TarjetaProduccionSuelasBU




    Public Function ObtenerProgramaPorDia(ByVal fechaInicio As String, ByVal fechaFin As String, estatusTarjeta As String, naveid As String, usuarioId As Integer) As DataTable
        Dim obj As New TarjetaProduccionSuelasDA
        Return obj.ObtenerProgramaPorDia(fechaInicio, fechaFin, estatusTarjeta, naveid, usuarioId)
    End Function

    Public Function FinalizarTarjetaProduccion(ByVal TarjetaID As String, ByVal UsuarioID As Integer) As DataTable
        Dim obj As New TarjetaProduccionSuelasDA
        Return obj.FinalizarTarjetaProduccion(TarjetaID, UsuarioID)
    End Function

    Public Function ActualizarPrioridadMaquina(ByVal pXmlCeldas As String) As DataTable
        Dim obj As New TarjetaProduccionSuelasDA
        Dim tabla As New DataTable
        tabla = obj.ActualizarTarjetaPrioridadMaquina(pXmlCeldas)
        Return tabla
    End Function
    Public Function ObtenerIdNavePorColaborador(ByVal colaboradorId As Integer) As Integer
        Dim obj As New TarjetaProduccionSuelasDA
        Dim tabla As New DataTable
        Dim naveId As Integer
        tabla = obj.ObtenerIdNavePorColaborador(colaboradorId)
        For Each row In tabla.Rows
            naveId = row(0)
        Next
        Return naveId
    End Function
    Public Function ConsultaAvanceProduccionSuelas(objEntidad As AvanceProduccionSuelas) As DataTable
        Dim obj As New TarjetaProduccionSuelasDA
        Dim tabla As New DataTable
        Dim contador As Int16 = 0
        Dim filasEliminar As New List(Of Integer)
        tabla = obj.ConsultaAvanceProduccionSuelas(objEntidad)
        'If navesID.Length > 0 And navesID <> "0" Then
        '    For Each fila As DataRow In tabla.Rows
        '        Dim eliminarFila As Boolean = True
        '        Dim idNavesBD As String() = CStr(fila("idNaves")).Split(New Char() {","c})
        '        For Each idNaveBD In idNavesBD
        '            Dim idNaves As String() = navesID.Split(New Char() {","c})
        '            For Each idNave In idNaves
        '                If (Int16.Parse(idNave) = Int16.Parse(idNaveBD)) Then
        '                    eliminarFila = False
        '                End If
        '            Next
        '        Next
        '        If eliminarFila Then
        '            filasEliminar.Add(contador)
        '        End If
        '        contador = contador + 1
        '    Next
        '    For indice As Integer = filasEliminar.Count - 1 To 0 Step -1
        '        tabla.Rows.RemoveAt(filasEliminar.ElementAt(indice))
        '    Next
        'End If
        Return tabla
    End Function


    Public Function ObtenerDetallesTarjetasProduccionSuelas(ByVal TarjetasId As String) As DataTable
        Dim obj As New TarjetaProduccionSuelasDA
        Return obj.ObtenerDetallesTarjetasProduccionSuelas(TarjetasId)
    End Function


    Public Function ObtenerConcentradoTarjetasProduccionSuelas(ByVal FechaDe As String, ByVal FechaA As String, ByVal ProveedorSuelaId As Integer) As DataTable
        Dim obj As New TarjetaProduccionSuelasDA
        Return obj.ObtenerConcentradoTarjetasProduccionSuelas(FechaDe, FechaA, ProveedorSuelaId)
    End Function

    Public Function InsertaAgrupamientoTarjetaSuela(ByVal pXmlTarjetas As String, ByVal pUsuario As Integer) As DataTable
        Dim obj As New TarjetaProduccionSuelasDA
        Dim tabla As New DataTable
        tabla = obj.InsertarAgrupamientoTarjetaSuela(pXmlTarjetas, pUsuario)
        Return tabla
    End Function

    Public Function DesagrupaTarjetaSuela(ByVal pXmlTarjetas As String) As DataTable
        Dim obj As New TarjetaProduccionSuelasDA
        Dim tabla As New DataTable
        tabla = obj.DesagruparTarjetaSuela(pXmlTarjetas)
        Return tabla
    End Function

End Class
