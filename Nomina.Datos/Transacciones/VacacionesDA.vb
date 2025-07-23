Imports System.Data.SqlClient

Public Class VacacionesDA
    Public Function ListaPercepcionesCarta(ByVal Filtros As Entidades.FiltrosCalculoPercepciones) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter = Nothing

        parametro = New SqlParameter With {
            .ParameterName = "@NaveId",
            .Value = Filtros.PNaveId
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "@Agno",
            .Value = Filtros.PAgno
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "@Periodo",
            .Value = Filtros.PPeriodo
        }
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("[Nomina].[SP_ObtieneDatosVyA_Carta]", listaParametros)
    End Function

    Public Function CalculoPercepcionesLista(ByVal Filtros As Entidades.FiltrosCalculoPercepciones) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter = Nothing

        parametro = New SqlParameter With {
            .ParameterName = "@NaveId",
            .Value = Filtros.PNaveId
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "@Agno",
            .Value = Filtros.PAgno
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "@Periodo",
            .Value = Filtros.PPeriodo
        }
        listaParametros.Add(parametro)
        parametro = New SqlParameter With {
            .ParameterName = "@usuarioid",
            .Value = Filtros.PUsuarioId
        }
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("[Nomina].[SP_ListaPrestacionesAyV]", listaParametros)
    End Function

    Public Function CalculoPercepcionesAgregar(ByVal Filtros As Entidades.FiltrosCalculoPercepciones) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter = Nothing

        parametro = New SqlParameter With {
            .ParameterName = "@naveid",
            .Value = Filtros.PNaveId
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "@anio",
            .Value = Filtros.PAgno
        }
        listaParametros.Add(parametro)
        If Filtros.PPeriodo = "NAVIDAD" Then
            Return operacion.EjecutarConsultaSP("[Nomina].[CalculoAguinaldoVacacionesFiscales_Navidad]", listaParametros)
        Else
            Return operacion.EjecutarConsultaSP("[Nomina].[CalculoAguinaldoVacacionesFiscales_SemanaSanta]", listaParametros)
        End If

    End Function

    Public Function ValidarStatusAguinaldoVacaciones(ByVal Filtros As Entidades.FiltrosCalculoPercepciones) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter = Nothing

        parametro = New SqlParameter With {
            .ParameterName = "@naveid",
            .Value = Filtros.PNaveId
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "@anio",
            .Value = Filtros.PAgno
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "@periodo",
            .Value = Filtros.PPeriodo
        }
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("[Nomina].[SP_ValidaEstatusAguinaldoVacaciones]", listaParametros)
    End Function

    Public Function AutorizarPercepciones(ByVal Filtros As Entidades.FiltrosCalculoPercepciones) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter = Nothing

        parametro = New SqlParameter With {
            .ParameterName = "@naveid",
            .Value = Filtros.PNaveId
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "@anio",
            .Value = Filtros.PAgno
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "@periodo",
            .Value = Filtros.PPeriodo
        }
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("[Nomina].[SP_AutorizarAguinaldoVacaciones]", listaParametros)
    End Function

    Public Function ResumenAguinaldoVacaciones(ByVal Filtros As Entidades.FiltrosCalculoPercepciones) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter = Nothing

        parametro = New SqlParameter With {
            .ParameterName = "@naveid",
            .Value = Filtros.PNaveId
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "@anio",
            .Value = Filtros.PAgno
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "@periodo",
            .Value = Filtros.PPeriodo
        }
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("[Nomina].[SP_ObtenerResumenAguinaldoVacaciones]", listaParametros)
    End Function
    Public Function ConsultaChquesAguinaldoVacaciones(ByVal Filtros As Entidades.FiltrosCalculoPercepciones) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter = Nothing

        parametro = New SqlParameter With {
            .ParameterName = "@naveid",
            .Value = Filtros.PNaveId
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "@anio",
            .Value = Filtros.PAgno
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "@periodo",
            .Value = Filtros.PPeriodo
        }
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("[Nomina].[SPR_AguinaldoVacaciones_ConsultaCheques]", listaParametros)
    End Function

    Public Function ValidarTimbrado(ByVal Filtros As Entidades.FiltrosCalculoPercepciones) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter = Nothing

        parametro = New SqlParameter With {
            .ParameterName = "@naveid",
            .Value = Filtros.PNaveId
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "@anio",
            .Value = Filtros.PAgno
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "@periodo",
            .Value = Filtros.PPeriodo
        }
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("[Contabilidad].[SP_ValidarConsultarAguinaldosVacaciones]", listaParametros)
    End Function

End Class
