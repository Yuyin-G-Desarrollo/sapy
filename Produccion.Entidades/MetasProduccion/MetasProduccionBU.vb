Imports Produccion.Datos
Imports Entidades

Public Class MetasProduccionBU

    Function TraerDatosComboNave(ByVal Nave As Integer)
        Dim objDatos As New MetasProduccionDA
        Return objDatos.TraerNavesComboDatos(Nave)
    End Function

    Function TraerDatosMetasPorHora(ByVal idMetaProduccion As Integer)
        Dim objDatos As New MetasProduccionDA
        Return objDatos.TraerMetasPorHoraAlDia(idMetaProduccion)
    End Function

    Function TraerDepartamentos(ByVal NaveId As Integer)
        Dim objDatos As New MetasProduccionDA
        Return objDatos.TraerDepartamentosAltaMetas(NaveId)
    End Function

    Function AgregarNuevaOActualizarMeta(ByVal tipo As String, ByVal cantidad As Integer, Optional ByVal dia As Integer = 0, Optional ByVal idConfiguracion As Integer = 0, Optional idMetaProduccion As Integer = 0)
        Dim objDatos As New MetasProduccionDA
        Return objDatos.AgregarActualizarmetaNave(tipo, cantidad, dia, idConfiguracion, idMetaProduccion)
    End Function

    Function MetasProduccionConfigGlobal_ABC(ByVal tipo As String, Optional Hora As String = "", Optional cantidad As Integer = 0, Optional IdMetaHora As Integer = 0, Optional idMetaProduccion As Integer = 0)
        Dim objDatos As New MetasProduccionDA
        Return objDatos.MetasProduccionAlta_Baja_Cambio(tipo, Hora, cantidad, IdMetaHora, idMetaProduccion)
    End Function

    Function MetasProduccionConfirmar(ByVal cantidad As Integer, ByVal hora As String, idMetaProduccion As Integer)
        Dim objDatos As New MetasProduccionDA
        Return objDatos.ConfirmarAgregarOcambiarMetaProduccion(cantidad, hora, idMetaProduccion)
    End Function

End Class
