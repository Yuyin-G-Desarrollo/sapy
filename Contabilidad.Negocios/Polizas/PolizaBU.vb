Imports Contabilidad.Datos

Public Class PolizaBU

    Public Function Combo_lista_Bases_Contpaq() As DataTable

        Dim objDA As New PolizaDA
        Return objDA.Combo_lista_Bases_Contpaq()

    End Function

    Public Function Combo_lista_Contribuyentes() As DataTable

        Dim objDA As New PolizaDA
        Return objDA.Combo_lista_Contribuyentes()

    End Function

    Public Function Combo_lista_Documentos_SICY() As DataTable

        Dim objDA As New PolizaDA
        Return objDA.Combo_lista_Documentos_SICY()

    End Function

    Public Function Combo_lista_Cuentas_Bancarias_SICY(ByVal Modo_Edicion As Boolean, ByVal IdCuenta As Integer) As DataTable

        Dim objDA As New PolizaDA
        Return objDA.Combo_lista_Cuentas_Bancarias_SICY(Modo_Edicion, IdCuenta)

    End Function


    ''' <summary>
    ''' CONSULTA LA INFORMACION DE LA TABLA EMPRESASAYSICYCONTPAQ
    ''' </summary>
    ''' <returns>INFORMACION RECUPERADA DE LA BD</returns>
    ''' <remarks></remarks>
    Public Function Combo_lista_Empresas_Say_Sicy_Contpaq() As DataTable

        Dim objDA As New PolizaDA
        Return objDA.Combo_lista_Empresas_Say_Sicy_Contpaq()

    End Function

    Public Function Combo_lista_Cuentas_Cheques_Contpaq(empresaID As Integer) As DataTable

        Dim objDA As New PolizaDA
        Return objDA.Combo_lista_Cuentas_Cheques_Contpaq(empresaID)

    End Function

    Public Function Combo_lista_Bancos() As DataTable

        Dim objDA As New PolizaDA
        Return objDA.Combo_lista_Bancos()

    End Function


    ''' <summary>
    ''' CONSULTA TODA LA INFORMACIÓN ACTIVA DE LA TABLA TIPOSCUENTACONTABILIDAD
    ''' </summary>
    ''' <returns>DATATABLE CON LA INFORMACIÓN RECUPERADA</returns>
    ''' <remarks></remarks>
    Public Function Combo_lista_TipoCuentaContable() As DataTable

        Dim objDA As New PolizaDA
        Return objDA.Combo_lista_TipoCuentaContable()

    End Function


    Public Function Combo_lista_TipoPoliza() As DataTable

        Dim objDA As New PolizaDA
        Return objDA.Combo_lista_TipoPoliza()

    End Function

    Public Function Combo_lista_Proveedor() As DataTable

        Dim objDA As New PolizaDA
        Return objDA.Combo_lista_Proveedor()

    End Function

    Public Function ListadoParametroBusqueda(tipo_busqueda As Integer, id_parametros As String) As DataTable
        Dim objbu As New PolizaDA
        Dim tabla As New DataTable
        tabla = objbu.ListadoParametroBusqueda(tipo_busqueda, id_parametros)
        Return tabla
    End Function

    Public Function Existe_Tabla_Contpaq(empresaID As Integer, nombre_tabla As String) As Boolean

        Dim objDA As New PolizaDA

        Return CBool(objDA.Existe_Tabla_Contpaq(empresaID, nombre_tabla).Rows(0).Item(0))

    End Function

    Public Function lista_polizas_generadas(empresaID As Integer, tipoPolizaID As Integer, fechaInicio As DateTime, fechaTermino As DateTime) As DataTable

        Dim objDA As New PolizaDA
        Return objDA.lista_polizas_generadas(empresaID, tipoPolizaID, fechaInicio, fechaTermino)

    End Function

    Public Function lista_movimientos_poliza(polizaID As Integer) As DataTable

        Dim objDA As New PolizaDA
        Return objDA.lista_movimientos_poliza(polizaID)

    End Function

    Public Sub Eliminar_Poliza_Solo_SAY(polizaID As Integer)

        Dim objDA As New PolizaDA

        objDA.Eliminar_Poliza_Solo_SAY(polizaID)

    End Sub


    Public Function consultacolaboradoresPrueba() As DataTable
        Dim objDA As New PolizaDA
        Return objDA.consultaPruebaDemo
    End Function


End Class
