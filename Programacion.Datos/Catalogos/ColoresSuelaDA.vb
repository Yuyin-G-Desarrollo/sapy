Imports System.Data.SqlClient

Public Class ColoresSuelaDA
    Public Function obtenerColoresSuelas(ByVal cosu_activo As Boolean) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@cosu_activo"
        parametro.Value = cosu_activo
        ListaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_Obtener_ColoresSuelas]", ListaParametros)
    End Function

    Public Function ContarFilasColoresSuelas() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Return operacion.EjecutaConsulta("SELECT COUNT(*) FROM Programacion.TBL_ColorSuela")
    End Function

    Public Function VerMaximoIdColorSuela() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Return operacion.EjecutaConsulta("SELECT MAX(cosu_colorsuelaid) FROM Programacion.TBL_ColorSuela")
    End Function

    Public Function VerCodigosDisponibles() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Return operacion.EjecutaConsulta("SELECT cosu_colorsuelaid FROM Programacion.TBL_ColorSuela WHERE cosu_activo='False' AND cosu_colorsuelaid NOT IN (SELECT cosu_colorsuelaid FROM Programacion.TBL_ColorSuela WHERE cosu_activo = 'True')")
    End Function

    Public Function registrarSuela(ByVal EntidadColorSuela As Entidades.ColorSuela, ByVal usuario As Int32)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "colorsuelaid"
        parametro.Value = EntidadColorSuela.PColorSuelaId
        ListaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "nombrecolor"
        parametro.Value = EntidadColorSuela.PNombreColor
        ListaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "activo"
        parametro.Value = EntidadColorSuela.PActivo
        ListaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "usuario"
        parametro.Value = usuario
        ListaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("[Programacion].[SP_Alta_ColoresSuelas]", ListaParametros)
    End Function

    Public Function EditarSuela(ByVal EntidadColorSuela As Entidades.ColorSuela, ByVal usuario As String)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "colorsuelaid"
        parametro.Value = EntidadColorSuela.PColorSuelaId
        ListaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "nombrecolor"
        parametro.Value = EntidadColorSuela.PNombreColor
        ListaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "activo"
        parametro.Value = EntidadColorSuela.PActivo
        ListaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "usuariomodifica"
        parametro.Value = usuario
        ListaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("[Programacion].[SP_Editar_ColoresSuelas]", ListaParametros)

    End Function

    Public Function validarRepetidos(ByVal colorsuelaId As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Return operaciones.EjecutaConsulta("SELECT COUNT(*) FROM Programacion.TBL_ColorSuela WHERE cosu_activo ='TRUE' AND cosu_colorsuelaid ='" + colorsuelaId + "'")
    End Function

    Public Function verComboColorSuela() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "SELECT cosu_colorsuelaid, cosu_nombrecolor FROM Programacion.TBL_ColorSuela WHERE cosu_activo = 1 ORDER BY cosu_nombrecolor "
        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Function verColorSuelaRegistradaRapido(ByVal idsColorSuela As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "SELECT cosu_colorsuelaid, cosu_nombrecolor  FROM Programacion.TBL_ColorSuela where cosu_activo = 'True' AND cosu_colorsuelaid NOT IN (" + idsColorSuela + ") "
        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Function verColorSuelaId(ByVal ColorSuelaId As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlClient.SqlParameter)
        Dim parametroLista As New SqlParameter

        Try
            parametroLista.ParameterName = "@ColorSuelaId"
            parametroLista.Value = ColorSuelaId
            listaParametros.Add(parametroLista)

            Return operaciones.EjecutarConsultaSP("[Ventas].[SP_Modelos_ObtenerInfoColorSuela]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try


    End Function


End Class
