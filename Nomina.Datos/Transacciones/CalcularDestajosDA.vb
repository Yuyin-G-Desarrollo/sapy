Imports System.Data.SqlClient

Public Class CalcularDestajosDA

    Public Sub CambiarSemanaDestajos(ByVal Destajos As Entidades.CalcularDestajos)

        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "SemanaNominaID"
        parametro.Value = Destajos.PIDSemanaNomina

        listaParametros.Add(parametro)

        operaciones.EjecutarSentenciaSP("Nomina.SP_Cerrar_Destajos", listaParametros)

    End Sub

End Class
