Imports System.Data.SqlClient

Public Class CatalogoFraccionesArancelariasDA

    Dim objPersistencia As New Persistencia.OperacionesProcedimientos
    Dim Consulta As String = String.Empty

    ''' <summary>
    ''' CONSULTA TODO EL ID, CODIGO Y NOMBRE DE LA TABLA VENTAS.FRACCIONARANCELARIA
    ''' </summary>
    ''' <param name="Codigo">CODIGO POR EL QUE SE FILTRARA LA BUSQUEDA, SI SU VALOR ESTA VACIO NO TOMARA EL FILTRO DE CODIGO PARA LA CONSULTA</param>
    ''' <param name="Nombre">NOMBRE POR EL QUE SE FILTRARA LA BUSQUEDA, SI SU VALOR ES VACIO NO SE TOMARA EL FILTRO DE NOMBRE PARA REALIZAR LA BUSQUEDA</param>
    ''' <returns>RESULTADO DE LA EJECIUCION DE LA CONSULTA EN UN DATATABLE</returns>
    ''' <remarks></remarks>
    Public Function Lista_Fracciones_Arancelarias(ByVal Codigo As String, Nombre As String, ByVal Activo As Boolean) As DataTable

        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim Consulta As String = String.Empty

        Consulta = "Select frar_fraccionarancelariaid as 'ID', frar_codigo as 'Código',frar_nombre as 'Nombre', frar_activo as 'Activo' " +
            " from Ventas.FraccionArancelaria" +
            " where frar_activo = '" + Activo.ToString + "'"
        If Codigo <> String.Empty Then
            Consulta += "and frar_codigo LIKE '%" + Codigo + "%'"
        End If
        If Nombre <> String.Empty Then
            Consulta += "and frar_nombre like '%" + Nombre + "%'"
        End If
        Consulta += " order by frar_codigo, frar_nombre asc "

        Return objPersistencia.EjecutaConsulta(Consulta)
    End Function


    Public Function Agregar_Editar_FraccionArancelaria(ByVal objFraccion As Entidades.Fracciones_Arancelarias, ByVal bandea_Alta_Editar As Boolean) As DataTable

        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@bandera"
        parametro.Value = bandea_Alta_Editar
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Nombre"
        parametro.Value = objFraccion.PNombre
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Codigo"
        parametro.Value = objFraccion.PCodigo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@IdFraccion"
        parametro.Value = objFraccion.PIdPraccionArancelaria
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Activo"
        parametro.Value = objFraccion.PActivo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Usuario"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)


        Return operaciones.EjecutarConsultaSP("Ventas.SP_AgregarEditar_Fracciones_Arancelarias", listaParametros)
        Console.WriteLine("Mando la sentencia")

    End Function




End Class
