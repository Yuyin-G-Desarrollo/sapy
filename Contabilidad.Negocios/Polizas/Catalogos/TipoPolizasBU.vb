Imports System.Data
Imports Contabilidad.Datos

Public Class TipoPolizasBU

    Public Function Consulta_lista_Tipo_Poliza() As DataTable

        Dim objDA As New TipoPolizasDA
        Return objDA.Consulta_lista_Tipo_Poliza()

    End Function

    Public Sub alta_edicion_tipo_poliza(ByVal tipoPoliza As Entidades.TipoPoliza)

        Dim objDA As New TipoPolizasDA

        objDA.alta_edicion_tipo_poliza(tipoPoliza)

    End Sub

End Class
