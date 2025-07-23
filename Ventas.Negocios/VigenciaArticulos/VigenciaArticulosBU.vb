Imports Ventas.Datos

Public Class VigenciaArticulosBU

    Public Function ObtenerInformacionArticulos(ByVal FMarca As String, ByVal FColeccion As String,
                                                ByVal TipoEstatusArticulo As Integer, ByVal FechaInicio As Date, ByVal FechaFin As Date) As DataTable

        Dim objDA As New VigenciaArticulosDA
        Dim dtResultado As New DataTable
        dtResultado = objDA.ObtenerInformacionArticulos(FMarca, FColeccion, TipoEstatusArticulo, FechaInicio, FechaFin)
        Return dtResultado
    End Function

    Public Function GuardarFechaVigencia_ArticulosSeleccionados(ByVal ProductoEstilosSeleccionados As String, ByVal FechaVigencia As Date, ByVal Observaciones As String, ByVal UsuarioID As Integer) As DataTable
        Dim objDA As New VigenciaArticulosDA
        Dim dtResultado As New DataTable

        dtResultado = objDA.GuardarFechaVigencia_ArticulosSeleccionados(ProductoEstilosSeleccionados, FechaVigencia, Observaciones, UsuarioID)
        Return dtResultado
    End Function

    Public Function RevertirFechaVigencia_ArticulosSeleccionados(ByVal ProductoEstilosSeleccionados As String, ByVal UsuarioID As Integer) As DataTable
        Dim objDA As New VigenciaArticulosDA
        Dim dtResultado As New DataTable

        dtResultado = objDA.RevertirFechaVigencia_ArticulosSeleccionados(ProductoEstilosSeleccionados, UsuarioID)
        Return dtResultado
    End Function


    Public Function ObtieneArticulos_FechaVigencia() As DataTable
        Dim objDA As New VigenciaArticulosDA
        Dim dtResultado As New DataTable
        dtResultado = objDA.ObtieneArticulos_FechaVigencia()
        Return dtResultado
    End Function

    Public Function CancelarSolicitudVencimiento(ByVal ProductoEstiloSeleccionados As String, ByVal UsuarioID As Integer) As DataTable
        Dim objDA As New VigenciaArticulosDA
        Dim dtResultado As New DataTable
        dtResultado = objDA.CancelarSolicitudVencimiento(ProductoEstiloSeleccionados, UsuarioID)
        Return dtResultado
    End Function

End Class
