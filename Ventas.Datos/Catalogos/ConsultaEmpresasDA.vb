Imports System.Data.SqlClient

Public Class ConsultaEmpresasDA
    Public Function ConsultaEmpresaDA() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Return operacion.EjecutaConsulta("Ventas.SP_ConsultarEmpresa")

    End Function

End Class
