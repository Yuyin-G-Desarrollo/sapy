Imports System.Data.SqlClient
Public Class CargaEquivalenciaDA
#Region "Naves"
    Public Function ConsultaNavesCatalogo() As DataTable

        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim dtNaves As DataTable
        Try
            dtNaves = operacion.EjecutaConsulta("Programacion.Sp_ConsultaNavesSimulacion")
        Catch ex As Exception
            Throw ex
        Finally
            operacion = Nothing
        End Try
        Return dtNaves

    End Function
#End Region

#Region "Validaciones"
    Public Function ConsultaColeccionSimulacion() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim dtColeccion As DataTable
        Try
            dtColeccion = operacion.EjecutaConsulta("Programacion.Sp_ValidaColeccionSimulacion")
        Catch ex As Exception
            Throw ex
        Finally
            operacion = Nothing
        End Try
        Return dtColeccion
    End Function

    Public Function ConsultaMarcasSimulacion() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim dtMarcas As DataTable
        Try
            dtMarcas = operacion.EjecutaConsulta("Programacion.Sp_ValidaMarcasSimulacion")
        Catch ex As Exception
            Throw ex
        Finally
            operacion = Nothing
        End Try
        Return dtMarcas
    End Function

    Public Function ConsultaModeloSICYSimulacion() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim dtModeloSICY As DataTable
        Try
            dtModeloSICY = operacion.EjecutaConsulta("Programacion.Sp_ValidaModeloSICYSimulacion")
        Catch ex As Exception
            Throw ex
        Finally
            operacion = Nothing
        End Try
        Return dtModeloSICY
    End Function

    Public Function ConsultaModeloSimulacion() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim dtModelo As DataTable
        Try
            dtModelo = operacion.EjecutaConsulta("Programacion.Sp_ValidaModeloSimulacion")
        Catch ex As Exception
            Throw ex
        Finally
            operacion = Nothing
        End Try
        Return dtModelo
    End Function

    Public Function ConsultaProductoEstiloSimulacion(ByVal nave As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)
        Dim ParametroParaLista As New SqlParameter
        ParametroParaLista.ParameterName = "Nave"
        ParametroParaLista.Value = nave
        ListaParametros.Add(ParametroParaLista)

        Dim dtCatalogoSimulacion As DataTable

        Try
            dtCatalogoSimulacion = operacion.EjecutarConsultaSP("Programacion.Sp_ValidaProductoEstilo", ListaParametros)
        Catch ex As Exception
            Throw ex
        Finally
            operacion = Nothing
        End Try
        Return dtCatalogoSimulacion
    End Function

    Public Function ConsultaTipoProductoSimulacion() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim dtTipoProducto As DataTable
        Try
            dtTipoProducto = operacion.EjecutaConsulta("Programacion.Sp_ValidaTipoProductoSimulacion")
        Catch ex As Exception
            Throw ex
        Finally
            operacion = Nothing
        End Try
        Return dtTipoProducto
    End Function

#End Region

#Region "Equivalencias"
    Public Function CargarProductosEquivalencia(ByVal nave As Integer, ByVal accion As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)
        Dim ParametroParaLista As New SqlParameter
        ParametroParaLista.ParameterName = "IdNave"
        ParametroParaLista.Value = nave
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "Accion"
        ParametroParaLista.Value = accion
        ListaParametros.Add(ParametroParaLista)

        Dim dtCatalogoSimulacion As DataTable

        Try
            dtCatalogoSimulacion = operacion.EjecutarConsultaSP("Programacion.Sp_ConsultaFactorEquivalencia", ListaParametros)
        Catch ex As Exception
            Throw ex
        Finally
            operacion = Nothing
        End Try
        Return dtCatalogoSimulacion
    End Function

    Public Function CargarProductosEquivalenciaExport(ByVal nave As Integer, ByVal accion As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)
        Dim ParametroParaLista As New SqlParameter
        ParametroParaLista.ParameterName = "IdNave"
        ParametroParaLista.Value = nave
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "Accion"
        ParametroParaLista.Value = accion
        ListaParametros.Add(ParametroParaLista)

        Dim dtCatalogoSimulacion As DataTable

        Try
            dtCatalogoSimulacion = operacion.EjecutarConsultaSP("Programacion.Sp_ConsultaFactorEquivalenciaExport", ListaParametros)
        Catch ex As Exception
            Throw ex
        Finally
            operacion = Nothing
        End Try
        Return dtCatalogoSimulacion
    End Function

    Public Function InsertarFactorEquivalencia(ByVal coleccion As Integer, ByVal productoEstilo As Integer, ByVal talla As Integer, ByVal equivalencia As Decimal) As Boolean
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)
        Dim ParametroParaLista As New SqlParameter
        ParametroParaLista.ParameterName = "Prod_ColeccionId"
        ParametroParaLista.Value = coleccion
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "Prod_ProductoEstiloId"
        ParametroParaLista.Value = productoEstilo
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "Prod_TallaId"
        ParametroParaLista.Value = talla
        ListaParametros.Add(ParametroParaLista)


        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "Prod_Equivalencia"
        ParametroParaLista.Value = equivalencia
        ListaParametros.Add(ParametroParaLista)

        Try
            operacion.EjecutarSentenciaSP("Programacion.Sp_FactorEquivalencia_Ins", ListaParametros)
            Return 1
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Function ModificarFactorEquivalencia(ByVal coleccion As Integer, ByVal productoEstilo As Integer, ByVal talla As Integer, ByVal equivalencia As Decimal) As Boolean
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)
        Dim ParametroParaLista As New SqlParameter
        ParametroParaLista.ParameterName = "coleccion"
        ParametroParaLista.Value = coleccion
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "productoestilo"
        ParametroParaLista.Value = productoEstilo
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "talla"
        ParametroParaLista.Value = talla
        ListaParametros.Add(ParametroParaLista)


        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "equivalencia"
        ParametroParaLista.Value = equivalencia
        ListaParametros.Add(ParametroParaLista)

        Try
            operacion.EjecutarSentenciaSP("Programacion.Sp_EquivalenciaColeccion_Mod", ListaParametros)
            Return 1
        Catch ex As Exception
            Return 0
        End Try
    End Function
    Public Function ModificarFactorEquivalenciaMasivo(ByVal Nave As Integer, _
                                                      ByVal modelo As String, _
                                                      ByVal marca As String, _
                                                      ByVal coleccion As String, _
                                                      ByVal aplicaciones As String, _
                                                      ByVal tipoProducto As String, _
                                                      ByVal equivalencia As Decimal) As Boolean
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)
        Dim ParametroParaLista As New SqlParameter
        ParametroParaLista.ParameterName = "Nave"
        ParametroParaLista.Value = Nave
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "Modelo"
        ParametroParaLista.Value = modelo
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "coleccion"
        ParametroParaLista.Value = coleccion
        ListaParametros.Add(ParametroParaLista)


        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "aplicaciones"
        ParametroParaLista.Value = aplicaciones
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "TipoProducto"
        ParametroParaLista.Value = tipoProducto
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "Equivalencia"
        ParametroParaLista.Value = equivalencia
        ListaParametros.Add(ParametroParaLista)

        Try
            operacion.EjecutarSentenciaSP("Programacion.Sp_FactorEquivalencia_Mod", ListaParametros)
            Return 1
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Function ValidaNaveArticulo(ByVal nave As Integer, ByVal productoEstilo As Integer, ByVal prioridad As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)
        Dim ParametroParaLista As New SqlParameter
        ParametroParaLista.ParameterName = "Nave"
        ParametroParaLista.Value = nave
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "ProductoEstilo"
        ParametroParaLista.Value = productoEstilo
        ListaParametros.Add(ParametroParaLista)
        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "Prioridad"
        ParametroParaLista.Value = prioridad

        ListaParametros.Add(ParametroParaLista)

        Dim dtCatalogoSimulacion As DataTable

        Try
            dtCatalogoSimulacion = operacion.EjecutarConsultaSP("Programacion.Sp_NaveArtivuloPrioridad_Obt", ListaParametros)
        Catch ex As Exception
            Throw ex
        Finally
            operacion = Nothing
        End Try
        Return dtCatalogoSimulacion
    End Function

    Public Function InsertarNaveArticuloPrioridad(ByVal nave As Integer, ByVal productoEstilo As Integer, ByVal prioridad As Integer, ByVal fechaInici As DateTime, ByVal fechaFin As DateTime) As Boolean
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)
        Dim ParametroParaLista As New SqlParameter
        ParametroParaLista.ParameterName = "Nave"
        ParametroParaLista.Value = nave
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "ProductoEstilo"
        ParametroParaLista.Value = productoEstilo
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "Prioridad"
        ParametroParaLista.Value = prioridad
        ListaParametros.Add(ParametroParaLista)


        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "FechaInicio"
        ParametroParaLista.Value = fechaInici
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "FechaFin"
        ParametroParaLista.Value = fechaFin
        ListaParametros.Add(ParametroParaLista)

        Try
            operacion.EjecutarSentenciaSP("Programacion.Sp_NaveArtivuloPrioridad_Ins", ListaParametros)
            Return 1
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Function ConsultaTallaEquivalencia(ByVal nave As Integer, ByVal productoEstilo As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)

        Dim ParametroParaLista As New SqlParameter
        ParametroParaLista.ParameterName = "NaveId"
        ParametroParaLista.Value = nave
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "ProductoEstiloId"
        ParametroParaLista.Value = productoEstilo
        ListaParametros.Add(ParametroParaLista)

        Dim dtTallaEquivalencia As DataTable

        Try
            dtTallaEquivalencia = operacion.EjecutarConsultaSP("Programacion.Sp_ConsultaTallaEquivalencia", ListaParametros)
        Catch ex As Exception
            Throw ex
        Finally
            operacion = Nothing
        End Try
        Return dtTallaEquivalencia
    End Function

    Public Function ValidaEquivalenciaColeccion(ByVal coleccion As Integer, ByVal productoEstilo As Integer, ByVal talla As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)

        Dim ParametroParaLista As New SqlParameter
        ParametroParaLista.ParameterName = "ColeccionId"
        ParametroParaLista.Value = coleccion
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "ProductoEstiloId"
        ParametroParaLista.Value = productoEstilo
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "TallaId"
        ParametroParaLista.Value = talla
        ListaParametros.Add(ParametroParaLista)


        Dim dtTallaEquivalencia As DataTable

        Try
            dtTallaEquivalencia = operacion.EjecutarConsultaSP("Programacion.Sp_ValidaEquivalenciaColeccion", ListaParametros)
        Catch ex As Exception
            Throw ex
        Finally
            operacion = Nothing
        End Try
        Return dtTallaEquivalencia
    End Function

    Public Function RegistraBitacoraEquivalencia(ByVal coleccion As Integer, ByVal productoEstilo As Integer, ByVal talla As Integer, ByVal equivalencia As Decimal) As Boolean
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)

        Dim ParametroParaLista As New SqlParameter
        ParametroParaLista.ParameterName = "Usuario"
        ParametroParaLista.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "equivalencia"
        ParametroParaLista.Value = equivalencia
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "coleccionId"
        ParametroParaLista.Value = coleccion
        ListaParametros.Add(ParametroParaLista)


        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "productoEstiloId"
        ParametroParaLista.Value = productoEstilo
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "tallaId"
        ParametroParaLista.Value = talla
        ListaParametros.Add(ParametroParaLista)

        Try
            operacion.EjecutarSentenciaSP("Programacion.Sp_RegistraBitacoraEquivalencia", ListaParametros)
            Return 1
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Function ConsultaProductosModelo(ByVal nave As Integer, ByVal modelo As String, ByVal coleccion As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)

        Dim ParametroParaLista As New SqlParameter
        ParametroParaLista.ParameterName = "naveId"
        ParametroParaLista.Value = nave
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "Modelo"
        ParametroParaLista.Value = modelo
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "Coleccion"
        ParametroParaLista.Value = coleccion
        ListaParametros.Add(ParametroParaLista)


        Dim dtTallaEquivalencia As DataTable

        Try
            dtTallaEquivalencia = operacion.EjecutarConsultaSP("Programacion.Sp_ConsultaProductosEquivalencia", ListaParametros)
        Catch ex As Exception
            Throw ex
        Finally
            operacion = Nothing
        End Try
        Return dtTallaEquivalencia
    End Function

#End Region

End Class
