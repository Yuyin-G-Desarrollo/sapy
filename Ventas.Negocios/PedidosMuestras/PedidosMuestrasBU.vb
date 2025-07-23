Imports Entidades
Public Class PedidosMuestrasBU
    Public Function ListaPedidosMuestras(ByVal idUsuario As Integer, ByVal mostrarTodo As Boolean, ByVal seguimiento As Integer,
                                         ByVal fechaInicio As Date, ByVal fechaFin As Date, ByVal cedisId As Integer) As List(Of Entidades.PedidosMuestras)
        Dim pedidosMuestrasDatos As New Ventas.Datos.PedidosMuestrasDA
        Return pedidosMuestrasDatos.ListaPedidosMuestras(idUsuario, mostrarTodo, seguimiento, fechaInicio, fechaFin, cedisId)
    End Function
    Public Sub EditarEstatusPedidoMuestra(ByVal Folio As Integer, ByVal Estatus As Boolean)
        Dim PedidosMuestraDatos As New Ventas.Datos.PedidosMuestrasDA
        PedidosMuestraDatos.EditarEstatusPedidoMuestra(Folio, Estatus)
    End Sub
    Public Function ListaPedidosMuestrasDetalles(ByVal Folio As Integer, Accion As Integer) As DataTable
        Dim PedidosDetallesMuestrasDatos As New Ventas.Datos.PedidosMuestrasDA
        Return PedidosDetallesMuestrasDatos.ListaPedidosDetalles(Folio, Accion)
    End Function

    Public Sub CambioDeTallaMuestras(ByVal MuestrasDetalleID As String, ByVal talla As Int16)
        Dim pedidosDetallesMuestras As New Datos.PedidosMuestrasDA
        pedidosDetallesMuestras.CambioDeTallaMuestras(MuestrasDetalleID, talla)
    End Sub

    Public Function ReportePedidoMuestras(ByVal Accion As Integer, ByVal Folio As Integer, Optional ByVal Cadena As String = "", Optional ByVal MostrarPrecio As Boolean = False) As DataTable
        Dim PedidoMuestrasDatos As New Ventas.Datos.PedidosMuestrasDA
        Return PedidoMuestrasDatos.ReportePedidoMuestras(Accion, Folio, Cadena, MostrarPrecio)
    End Function

    Public Function ListaArticulos(ByVal modelo As String, ByVal agente As Integer, ByVal cliente As Integer) As DataTable
        Dim PedidosMuestrasArticulosDatos As New Ventas.Datos.PedidosMuestrasDA
        Return PedidosMuestrasArticulosDatos.ListaArticulos(modelo, agente, cliente)
    End Function
    Public Function ListaModelosCancelar(ByVal modelo As String)
        Dim PedidosMuestrasArticulosDatos As New Ventas.Datos.PedidosMuestrasDA
        Return PedidosMuestrasArticulosDatos.ListaModelosCancelar(modelo)
    End Function
    Public Sub EditarPedidoMuestras(ByVal EntidadPedidoMuestra As Entidades.PedidosMuestras)
        Dim PedidosMuestraDatos As New Ventas.Datos.PedidosMuestrasDA
        PedidosMuestraDatos.EditarPedidoMuestras(EntidadPedidoMuestra)
    End Sub
    'Public Sub CancelarMuestra(ByVal Folio As Integer, ByVal Estilo As Integer, ByVal UnidadMedida As Integer, ByVal Talla As String, ByVal UsuarioID As Integer)
    Public Sub CancelarMuestra(ByVal Folio As Integer, ByVal PedidoMuestraDetalle As Integer, ByVal UsuarioID As Integer)
        Dim PedidosMuestraDatos As New Ventas.Datos.PedidosMuestrasDA
        PedidosMuestraDatos.CancelarMuestra(Folio, PedidoMuestraDetalle, UsuarioID)
    End Sub
    Public Sub EditarEstatusPedidoMuestraDetalles(ByVal Folio As Integer, ByVal Estilo As Integer, ByVal UnidadMedida As Integer, ByVal Talla As String, ByVal Estatus As Boolean)
        Dim PedidosMuestraDatos As New Ventas.Datos.PedidosMuestrasDA
        PedidosMuestraDatos.EditarEstatusPedidoMuestraDetalles(Folio, Estilo, UnidadMedida, Talla, Estatus)
    End Sub

    Public Sub AltaPedidoMuestraDetalles(ByVal EntidadPedidoDetalleMuestra As Entidades.PedidoMuestraDetalle)
        Dim PedidosMuestraDetalleDatos As New Ventas.Datos.PedidosMuestrasDA
        PedidosMuestraDetalleDatos.AltaPedidoDetalleMuestra(EntidadPedidoDetalleMuestra)
    End Sub
    Public Function ListaUnidadesDeMedida() As DataTable
        Dim PedidosMuestrasArticulosDatos As New Ventas.Datos.PedidosMuestrasDA
        Return PedidosMuestrasArticulosDatos.ListaUnidadesDeMedida()
    End Function

    Public Function VerListaAsuntos(ByVal activo As Boolean) As DataTable
        Dim AsuntosMuestrasDatos As New Ventas.Datos.PedidosMuestrasDA
        Return AsuntosMuestrasDatos.VerListaAsuntos(activo)
    End Function

    Public Sub APartarPedidoMuestra(Pedido As Integer)
        Dim objDA As New Datos.PedidosMuestrasDA
        Try
            objDA.APartarPedidoMuestra(Pedido)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function ConsultarInventarioDisponiblePedidoMuestra(PedidoID As Integer) As DataTable
        Dim objDA As New Datos.PedidosMuestrasDA
        Try
            Return objDA.ConsultarInventarioDisponiblePedidoMuestra(PedidoID)
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Sub EnviarPedidoPorAutorizar(PedidoID As Integer)
        Dim objDA As New Datos.PedidosMuestrasDA
        Try
            objDA.EnviarPedidoPorAutorizar(PedidoID)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function ConsultarPiezasApartadas(PedidoID As Integer) As DataTable
        Dim objDA As New Datos.PedidosMuestrasDA
        Try
            Return objDA.ConsultarPiezasApartadas(PedidoID)
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function ApartarPiezaMuestra(PiezaID As String, PedidoID As Integer, UsuarioID As Integer) As DataTable
        Dim objDA As New Datos.PedidosMuestrasDA
        Try
            Return objDA.ApartarPiezaMuestra(PiezaID, PedidoID, UsuarioID)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function CopiarPedidoMuestra(ByVal PedidoID As Integer, ByVal UsuarioCopiaId As Integer) As DataTable
        Dim objDA As New Datos.PedidosMuestrasDA

        Try
            Return objDA.CopiarPedidoMuestra(PedidoID, UsuarioCopiaId)
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function CargarComboClientes() As DataTable
        Dim objDA As New Datos.PedidosMuestrasDA

        Try
            Return objDA.CargarComboClientes()
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function CargarComboAgentes() As DataTable
        Dim objDA As New Datos.PedidosMuestrasDA

        Try
            Return objDA.CargarComboAgentes()
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function CargarComboTempordas() As DataTable
        Dim objDA As New Datos.PedidosMuestrasDA

        Try
            Return objDA.CargarComboTempordas()
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function VerificarParesCompletos(PedidoID As Integer, Proceso As Integer, UsuarioID As Integer) As DataTable
        Dim objDA As New Datos.PedidosMuestrasDA
        Try
            Return objDA.VerificarParesCompletos(PedidoID, Proceso, UsuarioID)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function obtenerCedisNaves()
        Dim objDA As New Datos.PedidosMuestrasDA
        Return objDA.CargarCedisNaves
    End Function
    Public Function obtenerValidacionCedisOriginal(ByVal modelo As String) As DataTable
        Dim objDA As New Datos.PedidosMuestrasDA
        Return objDA.validaCedisOriginal(modelo)
    End Function
    Public Function obtenerInventarioPiezasMuestras()
        Dim objInventarioPiezasDA As New Datos.PedidosMuestrasDA
        Return objInventarioPiezasDA.ConsultarInventarioPiezasMuestras
    End Function
End Class
