Imports Contabilidad.Datos

Public Class CuentasBancariasBU

    Public Function Consulta_lista_Cuentas_Bancarias(razonSocialID As Integer, bancoID As Integer) As DataTable

        Dim objDA As New CuentasBancariasDA
        Return objDA.Consulta_lista_Cuentas_Bancarias(razonSocialID, bancoID)

    End Function

    Public Sub alta_edicion_CuentaBancaria(cuentaid As Integer, numero As String, cuentahabiente As String, empresaid As Integer _
                                                   , cuentasicyid As Integer, bancoid As Integer, cuentacontpaqid As Integer,
                                                   bancocontpaqid As Integer, status As Boolean, ByVal idMoneda As Int32, ByVal clabe As String,
                                                    incluircotizaciones As Boolean, pagoremision As Boolean, pagofacturas As Boolean)

        Dim objDA As New CuentasBancariasDA

        objDA.alta_edicion_CuentaBancaria(cuentaid, numero, cuentahabiente, empresaid, cuentasicyid, bancoid, cuentacontpaqid, bancocontpaqid, status, idMoneda, clabe, incluircotizaciones, pagoremision, pagofacturas)

    End Sub

    Public Function Datos_CuentaBancaria(cuentaID As Integer) As DataTable

        Dim objDA As New CuentasBancariasDA
        Return objDA.Datos_CuentaBancaria(cuentaID)

    End Function

    Public Function Datos_Banco_Contpaq(empresaID As Integer, bancocontpaqID As Integer) As DataTable

        Dim objDA As New CuentasBancariasDA
        Return objDA.Datos_Banco_Contpaq(empresaID, bancocontpaqID)

    End Function

End Class
