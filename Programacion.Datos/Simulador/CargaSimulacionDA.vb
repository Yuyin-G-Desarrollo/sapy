Imports System.Data.SqlClient

Public Class CargaSimulacionDA

#Region "Validaciones Simulación"


    Public Function CargaCatalogoBaseSimulacion() As DataTable

        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim dtCatalogoSimulacion As DataTable
        Try
            dtCatalogoSimulacion = operacion.EjecutaConsulta("Programacion.SP_CatalogoBasesSimulacion")
        Catch ex As Exception
            Throw ex
        Finally
            operacion = Nothing
        End Try
        Return dtCatalogoSimulacion

    End Function
    ''' <summary>
    ''' Consulta la simulación, despues de insertar nave-corrida-talla
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function CargaSimulacionValidaNave() As DataTable

        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim dtCatalogoSimulacion As DataTable
        Try
            dtCatalogoSimulacion = operacion.EjecutaConsulta("Programacion.SP_CargaSimulacionValidaNaves")
        Catch ex As Exception
            Throw ex
        Finally
            operacion = Nothing
        End Try
        Return dtCatalogoSimulacion

    End Function
    ''' <summary>
    ''' Carga información para la validación de Nave
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function CargaSimulacionValidaHorma() As DataTable

        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim dtCatalogoSimulacion As DataTable
        Try
            dtCatalogoSimulacion = operacion.EjecutaConsulta("Programacion.SP_CargaSimulacionValidaHorma")
        Catch ex As Exception
            Throw ex
        Finally
            operacion = Nothing
        End Try
        Return dtCatalogoSimulacion

    End Function
    ''' <summary>
    ''' Carga información para la validación de Horma
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function CargaSimulacionValidaColeccion() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim dtCatalogoSimulacion As DataTable
        Try
            dtCatalogoSimulacion = operacion.EjecutaConsulta("Programacion.SP_CargaSimulacionValidaColeccion")
        Catch ex As Exception
            Throw ex
        Finally
            operacion = Nothing
        End Try
        Return dtCatalogoSimulacion

    End Function
    ''' <summary>
    ''' Carga información para la validación de talla
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function CargaSimulacionValidaTalla() As DataTable

        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim dtCatalogoSimulacion As DataTable
        Try
            dtCatalogoSimulacion = operacion.EjecutaConsulta("Programacion.SP_CargaSimulacionValidaTalla")
        Catch ex As Exception
            Throw ex
        Finally
            operacion = Nothing
        End Try
        Return dtCatalogoSimulacion

    End Function
    ''' <summary>
    ''' Carga Informacion para la validación de Suela
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function CargaSimulacionValidaSuela() As DataTable

        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim dtCatalogoSimulacion As DataTable
        Try
            dtCatalogoSimulacion = operacion.EjecutaConsulta("Programacion.Sp_CargaSimulacionValidaSuela")
        Catch ex As Exception
            Throw ex
        Finally
            operacion = Nothing
        End Try
        Return dtCatalogoSimulacion

    End Function
    Public Function CargaSimulacionValidaLayout(ByVal opcion As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)
        Dim ParametroParaLista As New SqlParameter
        ParametroParaLista.ParameterName = "opcion"
        ParametroParaLista.Value = opcion
        ListaParametros.Add(ParametroParaLista)

        Dim dtCatalogoSimulacion As DataTable

        Try
            dtCatalogoSimulacion = operacion.EjecutarConsultaSP("Programacion.Sp_CargaSimulacionValidaLayout", ListaParametros)
        Catch ex As Exception
            Throw ex
        Finally
            operacion = Nothing
        End Try
        Return dtCatalogoSimulacion
    End Function
#End Region
#Region "Horma-Nave-Talla"


    Public Function InsertarHomaNaveTallaBase(ByVal nave As String, ByVal naveDesarrollo As String, ByVal horma As String, ByVal coleccion As String, ByVal corrida As String, ByVal talla As Integer, ByVal pares As Integer) As Boolean
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)
        Dim ParametroParaLista As New SqlParameter
        ParametroParaLista.ParameterName = "honata_nave"
        ParametroParaLista.Value = nave
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "honata_navedesarrollo"
        ParametroParaLista.Value = naveDesarrollo
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "honata_horma"
        ParametroParaLista.Value = horma
        ListaParametros.Add(ParametroParaLista)


        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "honata_coleccion"
        ParametroParaLista.Value = coleccion
        ListaParametros.Add(ParametroParaLista)


        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "honata_corrida"
        ParametroParaLista.Value = corrida
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "honata_talla"
        ParametroParaLista.Value = talla
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "honata_pares"
        ParametroParaLista.Value = pares
        ListaParametros.Add(ParametroParaLista)

        Try
            operacion.EjecutarSentenciaSP("Programacion.SP_HormaNaveTallaBase_Ins", ListaParametros)
            Return 1
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Function InsertarCargaSimulacion(ByVal fechaIni As DateTime, ByVal fechafin As DateTime) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)
        Dim ParametroParaLista As New SqlParameter
        ParametroParaLista.ParameterName = "fechaIni"
        ParametroParaLista.Value = fechaIni
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "fechaFin"
        ParametroParaLista.Value = fechafin
        ListaParametros.Add(ParametroParaLista)

        Dim dtCatalogoSimulacion As DataTable

        Try
            dtCatalogoSimulacion = operacion.EjecutarConsultaSP("Programacion.SP_CargaSimulacionBase", ListaParametros)
        Catch ex As Exception
            Throw ex
        Finally
            operacion = Nothing
        End Try
        Return dtCatalogoSimulacion
    End Function
    Public Function ConsultarCargaSimulacion(ByVal fechaIni As DateTime, ByVal fechafin As DateTime) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)
        Dim ParametroParaLista As New SqlParameter
        ParametroParaLista.ParameterName = "fechaIni"
        ParametroParaLista.Value = fechaIni
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "fechaFin"
        ParametroParaLista.Value = fechafin
        ListaParametros.Add(ParametroParaLista)

        Dim dtCatalogoSimulacion As DataTable

        Try
            dtCatalogoSimulacion = operacion.EjecutarConsultaSP("Programacion.SP_ConsultaSimulacionHorma", ListaParametros)
        Catch ex As Exception
            Throw ex
        Finally
            operacion = Nothing
        End Try
        Return dtCatalogoSimulacion
    End Function
    Public Function ConsultarSuelaCargaSimulacion(ByVal fechaIni As DateTime, ByVal fechafin As DateTime) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)
        Dim ParametroParaLista As New SqlParameter
        ParametroParaLista.ParameterName = "fechaIni"
        ParametroParaLista.Value = fechaIni
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "fechaFin"
        ParametroParaLista.Value = fechafin
        ListaParametros.Add(ParametroParaLista)

        Dim dtCatalogoSimulacion As DataTable

        Try
            dtCatalogoSimulacion = operacion.EjecutarConsultaSP("Programacion.SP_ConsultaSimulacionSuela", ListaParametros)
        Catch ex As Exception
            Throw ex
        Finally
            operacion = Nothing
        End Try
        Return dtCatalogoSimulacion
    End Function
    Public Function ConsultaHomaNaveTallaBase() As DataTable

        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim dtSuelaTalla As DataTable
        Try
            dtSuelaTalla = operacion.EjecutaConsulta("Programacion.SP_HormaNaveTallaBaseVal_Obt")
        Catch ex As Exception
            Throw ex
        Finally
            operacion = Nothing
        End Try
        Return dtSuelaTalla

    End Function
#End Region
#Region "Suela-Talla"
    Public Function InsertarSuelaTalla(ByVal suela As String, ByVal coleccion As String, ByVal corrida As String, ByVal talla As String, ByVal pares As String) As Boolean
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)
        Dim ParametroParaLista As New SqlParameter
        ParametroParaLista.ParameterName = "Suela"
        ParametroParaLista.Value = suela
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "coleccion"
        ParametroParaLista.Value = coleccion
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "corrida"
        ParametroParaLista.Value = corrida
        ListaParametros.Add(ParametroParaLista)


        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "talla"
        ParametroParaLista.Value = talla
        ListaParametros.Add(ParametroParaLista)


        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "pares"
        ParametroParaLista.Value = pares
        ListaParametros.Add(ParametroParaLista)

        Try
            operacion.EjecutarSentenciaSP("Programacion.Sp_InsertaSuelaTallaBase", ListaParametros)
            Return 1
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Function CargaSuelaSimulacionBase(ByVal fechaIni As DateTime, ByVal fechafin As DateTime) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)
        Dim ParametroParaLista As New SqlParameter
        ParametroParaLista.ParameterName = "FechaIni"
        ParametroParaLista.Value = fechaIni
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "FechaFin"
        ParametroParaLista.Value = fechafin
        ListaParametros.Add(ParametroParaLista)

        Dim dtCatalogoSimulacion As DataTable

        Try
            dtCatalogoSimulacion = operacion.EjecutarConsultaSP("Programacion.SP_CargaSuelaSimulacionBase", ListaParametros)
        Catch ex As Exception
            Throw ex
        Finally
            operacion = Nothing
        End Try
        Return dtCatalogoSimulacion
    End Function

    Public Function ConsultaSuelaTalla() As DataTable

        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim dtSuelaTalla As DataTable
        Try
            dtSuelaTalla = operacion.EjecutaConsulta("Programacion.Sp_CargaSimulacionValidaSuela")
        Catch ex As Exception
            Throw ex
        Finally
            operacion = Nothing
        End Try
        Return dtSuelaTalla

    End Function

    Public Function ConsultaSuelaTallaVal() As DataTable

        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim dtSuelaTalla As DataTable
        Try
            dtSuelaTalla = operacion.EjecutaConsulta("Programacion.Sp_SuelaTallaVal_Obt")
        Catch ex As Exception
            Throw ex
        Finally
            operacion = Nothing
        End Try
        Return dtSuelaTalla

    End Function
#End Region
End Class
