
Imports System.Data
Imports System.Data.SqlClient
Imports Persistencia
Imports System.Collections.Generic

Public Class TipoPolizasDA

    Public Function Consulta_lista_Tipo_Poliza() As DataTable

        Dim operaciones As New OperacionesProcedimientos
        Dim consulta As String = String.Empty
        consulta += " SELECT poti_polizatipoid AS 'ID', poti_nombre AS 'Tipo Poliza', (CASE WHEN poti_activo = 1 THEN 'SI' ELSE 'NO' END) AS 'Activo' FROM Contabilidad.PolizasTipos ORDER BY poti_activo DESC, poti_nombre ASC"

        Return operaciones.EjecutaConsulta(consulta)

    End Function

    Public Function alta_edicion_tipo_poliza(ByVal tipoPoliza As Entidades.TipoPoliza)

        Dim operaciones As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        ',@polizatipoid AS VARCHAR(15)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "@polizatipoid"
        parametro.Value = tipoPoliza.polizatipoid
        listaParametros.Add(parametro)

        ',@nombre AS VARCHAR(30)
        parametro = New SqlParameter
        parametro.ParameterName = "@nombre"
        parametro.Value = tipoPoliza.nombre
        listaParametros.Add(parametro)

        ',@status AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "@status"
        parametro.Value = tipoPoliza.status
        listaParametros.Add(parametro)

        ',@usuario AS varchar(1)
        parametro = New SqlParameter
        parametro.ParameterName = "@usuario"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        Return operaciones.EjecutarSentenciaSP("Contabilidad.SP_Alta_Edicion_Tipo_Poliza", listaParametros)

    End Function

End Class
