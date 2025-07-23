Public Class AlertasBU
    ''' <summary>
    ''' Consulta para la alerta de clientes en lista de ventas temporal de la lista base.
    ''' </summary>
    ''' <returns>Datatable</returns>
    ''' <remarks></remarks>
    Public Function consultaClientesTemporal() As DataTable
        Dim objPDA As New Datos.AlertasDA
        Return objPDA.consultaClientesTemporal()
    End Function

    ''' <summary>
    ''' Consulta para alertar de las listas base o de ventas que se encuentran proximas a vencer
    ''' </summary>
    ''' <returns>Datatable</returns>
    ''' <remarks></remarks>
    Public Function consultaVigenciasProximasLVS() As DataTable
        Dim objPDA As New Datos.AlertasDA
        Return objPDA.consultaVigenciasProximasLVS
    End Function

    ''alerta solicitudes rechazadas contabilidad
    Public Function consultaSolicitudesRechazadas() As DataTable
        Dim dtSolicitudes As New DataTable
        Dim objDa As New Datos.AlertasDA

        dtSolicitudes = objDa.consultaSolicitudesRechazadas()

        Return dtSolicitudes
    End Function

    ''obtiene los datos para enviar el correo 
    Public Function envioCorreoRechazadas(ByVal patronId As Integer) As DataTable
        Dim objDA As New Datos.AlertasDA
        Dim dtCorreo As New DataTable

        dtCorreo = objDA.envioCorreoRechazadas(patronId)
        Return dtCorreo
    End Function

    ''alerta movimientos pendientes contabilidad
    Public Function consultaListadoMovimientosPendientes() As DataTable
        Dim dtListado As New DataTable
        Dim objDa As New Datos.AlertasDA

        dtListado = objDa.consultaListadoMovimientosPendientes()

        Return dtListado
    End Function

    ''Obtiene pantalla a abrir de movimiento pendiente
    Public Function consultarPermisoPantallaNomina(ByVal movimiento As String) As String
        Dim dtListado As New DataTable
        Dim objDa As New Datos.AlertasDA
        Dim resultado As String = String.Empty

        dtListado = objDa.consultarPermisoPantallaNomina(movimiento)
        If Not dtListado Is Nothing Then
            If dtListado.Rows.Count > 0 Then
                resultado = dtListado.Rows(0)("Pantalla").ToString
            End If
        End If

        Return resultado
    End Function

    Public Function alertaParesSinProgramar() As DataTable
        Dim objDA As New Datos.AlertasDA
        Try
            Return objDA.alertaParesSinProgramar()
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ConsultaArticulosIngresados() As DataTable
        Dim obj As New Datos.AlertasDA
        Return obj.ConsultaArticulosIngresados()
    End Function
End Class
