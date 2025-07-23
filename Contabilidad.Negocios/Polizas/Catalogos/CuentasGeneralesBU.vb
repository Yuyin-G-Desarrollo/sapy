Imports Contabilidad.Datos

Public Class CuentasGeneralesBU

    ''' <summary>
    ''' CONSULTA LA LISTA DE LAS CUENTAS GENERALES EXISTENTES EN LA BASE DE DATOS DEACUERDO A LOS FILTROS SELECCIONADOS POR EL USUARIO
    ''' </summary>
    ''' <param name="TipoPolizaID">ID DEL TIPO DE POLIZA QUE SE BUSCARAN, EN CASO DE QUE EL VALOR SEA = 0 INDICA QUE NO SE USARA ESTA CONDICION EN LA BUSQUEDA</param>
    ''' <param name="TipoDeCUentaID">ID DEL TIPO DE CUENTA QUE SE BUSCARAM EN CASO DE QUE EL VALOR SEA = 0 INDICA QUE NO SE USARA ESTA CONDICION EN LA CONSULTA</param>
    ''' <param name="EmpresaSSCID">ID DE LA EMPRESA EN LA TABLA EMPRESA SAY SICY CONTPAQ, EN CASO DE QUE EL VALOR SEA = O INDICA QUE NO SE USARA ESTA CONDICION EN LA CONSULTA</param>
    ''' <param name="Cuenta">CADENA CON EL NUMERO DE CUENTA QUE SE BUSCARA, EN CASO DE QUE LA CADENA SEA = "" INDICA QUE NO SE USARA ESTA CONDICION EN LA CONSULTA</param>
    ''' <param name="CUentaExacta_O_Aproximada">VARIABLE DEL TIPO BOOLEAN QUE INDICA SI LA CUENTA QUE SE BUSCARA DEBERA SER EXACTA A LA VARIABLE "CUENTA" ESTO EN CASO DE QUE 
    ''' SU VALOR SEA POSITIVO, E INDICA QUE LA CUENTA QUE SE BUSCARA SERA PARECIDA A LA VARIABLE CUENTA ESTO EN CASO DE QUE EL VALOR SEA NEGATIVO</param>
    ''' <returns>INFORMACION RECUPERADA</returns>
    ''' <remarks></remarks>
    Public Function Consulta_lista_Cuentas_Generales(ByVal TipoPolizaID As Integer, ByVal TipoDeCUentaID As Integer, ByVal EmpresaSSCID As Integer, ByVal Cuenta As String,
                                                     ByVal CUentaExacta_O_Aproximada As Boolean) As DataTable

        Dim objDA As New CuentasGeneralesDA
        Return objDA.Consulta_lista_Cuentas_Generales(TipoPolizaID, TipoDeCUentaID, EmpresaSSCID, Cuenta, CUentaExacta_O_Aproximada)

    End Function

    Public Sub alta_edicion_cuenta_contable_general(bandera As Integer, CuentaContableGeneral As Entidades.CuentaContableGeneral)

        Dim objDA As New CuentasGeneralesDA

        objDA.alta_edicion_cuenta_contable_general(bandera, CuentaContableGeneral)

    End Sub

    Public Function Consulta_Datos_Cuentas_Generales(cuenta_general_id As Integer) As DataTable

        Dim objDA As New CuentasGeneralesDA
        Return objDA.Consulta_Datos_Cuentas_Generales(cuenta_general_id)

    End Function

End Class
