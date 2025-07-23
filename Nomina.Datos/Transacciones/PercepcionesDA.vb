Imports System.Data.SqlClient

Public Class PercepcionesDA

    Public Sub GuardarPercepcionesPreNomina(ByVal nomina As Entidades.Percepciones)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro = New SqlParameter
        parametro.ParameterName = "perc_colaboradorid"
        parametro.Value = nomina.PColaborador.PColaboradorid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "perc_periodonominaid"
        parametro.Value = nomina.PCobranza.PsemanaNominaId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "perc_tipo"
        parametro.Value = nomina.PPercepcionTipo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "perc_monto"
        parametro.Value = nomina.PMontoPercepcion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "perc_usuariocreoid"
        parametro.Value = nomina.PPrestamos.Pusuariocreoid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "perc_fechacreacion"
        parametro.Value = nomina.PCobranza.PfechaFinNomina
        listaParametros.Add(parametro)


        operaciones.EjecutarSentenciaSP("Nomina.SP_Alta_Percepciones", listaParametros)

    End Sub




End Class
