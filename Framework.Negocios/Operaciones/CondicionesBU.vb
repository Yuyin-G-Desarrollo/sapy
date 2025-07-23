Public Class CondicionesBU

    Public Function Datos_TablaCondicionesClienteArea(editando As Boolean, clienteID As Integer, areaOperativa As Integer) As DataTable

        Dim condicionesDA As New Datos.CondicionesDA
        Return condicionesDA.Datos_TablaCondicionesClienteArea(editando, clienteID, areaOperativa)

    End Function

    Public Function Datos_TablaCondicionesCatalogoCondicion(condicionID As Integer, areaOperativa As Integer) As DataTable

        Dim condicionesDA As New Datos.CondicionesDA
        Return condicionesDA.Datos_TablaCondicionesCatalogoCondicion(condicionID, areaOperativa)

    End Function

    Public Sub EditarCondicionPersona(condicion As Entidades.CondicionPersona)

        Dim CondicionesDA As New Datos.CondicionesDA
        CondicionesDA.EditarCondicionPersona(condicion)

    End Sub

End Class
