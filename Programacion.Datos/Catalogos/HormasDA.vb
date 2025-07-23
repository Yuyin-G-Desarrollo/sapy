Imports System.Data.SqlClient

Public Class HormasDA

    Public Function verListaHormas(ByVal Horma As String, ByVal idHorma As String, ByVal Activo As Boolean) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "Select horma_hormaid, horma_descripcion, horma_activo from Programacion .hormas where horma_activo='" + Activo.ToString + "'"
        If (Horma <> "") Then
            cadena += " and horma_descripcion like '%" + Horma + "%'"
        End If
        If (idHorma <> "") Then
            cadena += " and horma_hormaid=" + idHorma + ""
        End If
        cadena += " ORDER BY horma_descripcion"
        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Function idMaximoHorma()
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "select MAX(horma_hormaid) from Programacion.Hormas"
        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Sub guardarHorma(ByVal entidadHorma As Entidades.Hormas)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlClient.SqlParameter)

        Dim parametroLista As New SqlParameter
        parametroLista.ParameterName = "descripcion"
        parametroLista.Value = entidadHorma.PHorma
        listaParametros.Add(parametroLista)

        parametroLista = New SqlParameter
        parametroLista.ParameterName = "activo"
        parametroLista.Value = entidadHorma.PActivoHorma
        listaParametros.Add(parametroLista)

        parametroLista = New SqlParameter
        parametroLista.ParameterName = "usuario"
        parametroLista.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametroLista)

        operaciones.EjecutarSentenciaSP("Programacion.SP_Alta_Horma", listaParametros)
    End Sub

    Public Sub EditarHorma(ByVal entidadHorma As Entidades.Hormas)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlClient.SqlParameter)

        Dim parametroLista As New SqlParameter
        parametroLista.ParameterName = "idHorma"
        parametroLista.Value = entidadHorma.PidHorma
        listaParametros.Add(parametroLista)

        parametroLista = New SqlParameter
        parametroLista.ParameterName = "descripcion"
        parametroLista.Value = entidadHorma.PHorma
        listaParametros.Add(parametroLista)

        parametroLista = New SqlParameter
        parametroLista.ParameterName = "activo"
        parametroLista.Value = entidadHorma.PActivoHorma
        listaParametros.Add(parametroLista)

        parametroLista = New SqlParameter
        parametroLista.ParameterName = "usuario"
        parametroLista.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametroLista)

        operaciones.EjecutarSentenciaSP("Programacion.SP_Editar_Horma", listaParametros)
    End Sub

    Public Function verHormaId(ByVal idHorma As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "Select horma_hormaid , horma_descripcion , horma_activo from Programacion .hormas where horma_hormaid=" + idHorma + " and horma_activo='True'"
        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Function validarExistenmodelos(ByVal idHorma As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "SELECT a.prod_codigo, a.prod_descripcion FROM Programacion.Productos a INNER JOIN Programacion.ProductoEstilo b" +
                                " ON a.prod_productoid = b.pres_productoid WHERE a.prod_activo = 1 AND b.pres_activo = 1 AND b.pres_horma=" + idHorma +
                                " GROUP BY	a.prod_codigo, a.prod_descripcion"
        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Function ValidarExisteHorma(ByVal descripcion As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlClient.SqlParameter)

        Dim parametroLista As New SqlParameter
        parametroLista.ParameterName = "DescripcionHorma"
        parametroLista.Value = descripcion
        listaParametros.Add(parametroLista)

        Return operacion.EjecutarConsultaSP("[Programacion].[SP_ValidaExisteHorma_SAY]", listaParametros)

    End Function

End Class
