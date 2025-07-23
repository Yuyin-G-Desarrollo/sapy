Public Class RutasConfiguracionBU
    Public Function RutasConfiguracion() As Entidades.RutasGenerales
        Try
            RutasConfiguracion = New Entidades.RutasGenerales
            Dim objDA As New Datos.RutasConfiguracionDA
            Dim dtResultado As New DataTable
            dtResultado = objDA.RutasConfiguracion()

            If Not dtResultado Is Nothing AndAlso dtResultado.Rows.Count > 0 Then
                RutasConfiguracion.PRutaEtiquetas_Coppel = dtResultado.Rows(0).Item("rconf_ruta").ToString
                RutasConfiguracion.PRutaCRP_Compensacion = dtResultado.Rows(1).Item("rconf_ruta").ToString
                RutasConfiguracion.PRutaComprobante_Maquilas = dtResultado.Rows(2).Item("rconf_ruta").ToString
                Return RutasConfiguracion
            Else
                Return New Entidades.RutasGenerales
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class
