Public Class NivelSocioEconomicoBU

    Public Function ListadoNivelSocioEconomico() As DataTable
        Dim NivelSocioEconomico As New Datos.NivelSocioEconomicoDA
        Return NivelSocioEconomico.ListadoNivelSocioEconomico()
    End Function

End Class
