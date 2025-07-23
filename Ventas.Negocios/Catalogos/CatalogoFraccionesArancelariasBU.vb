Public Class CatalogoFraccionesArancelariasBU

    Dim objCatalogoFraccionesDA As New Datos.CatalogoFraccionesArancelariasDA
    Dim dtTablaResultadoDeConsulta As New DataTable


    ''' <summary>
    ''' CONSULTA TODO EL ID, CODIGO Y NOMBRE DE LA TABLA VENTAS.FRACCIONARANCELARIA
    ''' </summary>
    ''' <param name="Codigo">CODIGO POR EL QUE SE FILTRARA LA BUSQUEDA, SI SU VALOR ESTA VACIO NO TOMARA EL FILTRO DE CODIGO PARA LA CONSULTA</param>
    ''' <param name="Nombre">NOMBRE POR EL QUE SE FILTRARA LA BUSQUEDA, SI SU VALOR ES VACIO NO SE TOMARA EL FILTRO DE NOMBRE PARA REALIZAR LA BUSQUEDA</param>
    ''' <returns>RESULTADO DE LA EJECIUCION DE LA CONSULTA EN UN DATATABLE</returns>
    ''' <remarks></remarks>
    Public Function Lista_Fracciones_Arancelarias(ByVal Codigo As String, Nombre As String, ByVal Activo As Boolean) As DataTable

        dtTablaResultadoDeConsulta = objCatalogoFraccionesDA.Lista_Fracciones_Arancelarias(Codigo, Nombre, Activo)

        Return dtTablaResultadoDeConsulta
    End Function


    Public Function Agregar_Editar_FraccionArancelaria(ByVal objFraccion As Entidades.Fracciones_Arancelarias, ByVal bandea_Alta_Editar As Boolean) As String

        Dim dtTabla As New DataTable

        dtTabla = objCatalogoFraccionesDA.Agregar_Editar_FraccionArancelaria(objFraccion, bandea_Alta_Editar)

        Agregar_Editar_FraccionArancelaria = dtTabla.Rows(0).Item(0)

        Return Agregar_Editar_FraccionArancelaria
    End Function



End Class
