Imports Persistencia
Imports System.Data.SqlClient

Public Class TamaniosDA
    Public Function getTamañosMateriales(ByVal id As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
            <cadena>
            select tama_idTamano 'ID',tama_nombre 'Tamaño',tama_sku 'SKU',tama_status 'Activo' from Materiales.Tamano  order by tama_nombre ASC
            </cadena>
        If id > 0 Then
            consulta += " where tama_idTamano=" & id
        End If
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function getTamañosMaterialesid(ByVal id As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
            <cadena>
            select tama_idTamano 'ID',tama_nombre 'Tamaño',tama_sku 'SKU',tama_status 'Activo' from Materiales.Tamano
            </cadena>
        If id > 0 Then
            consulta += " where tama_idTamano=" & id
        End If
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function updateTamañosMateriales(ByVal id As Integer, ByVal nombre As String, ByVal sku As String, ByVal status As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim usuariomodifico = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        Dim fechamodificacion = DateTime.Now.ToString("dd/MM/yyyy")
        Dim consulta As String =
            <cadena>
            update Materiales.Tamano set tama_nombre=
            </cadena>
        consulta += " '" & nombre & "' ,tama_status=" & status & ", tama_usuariomodificoid=" & usuariomodifico & ", tama_fechamodificacion='" & fechamodificacion & "' where tama_idTamano=" & id & ""
        Return operaciones.EjecutaConsulta(consulta)
    End Function
    Public Function insertTamañosMateriales(ByVal nombre As String, ByVal sku As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim obj As New Tools.Combinaciones
        Dim datos As New DataTable
        Dim usuariocreo = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        Dim fechacreacion = DateTime.Now.ToString("dd/MM/yyyy")
        Dim usuariomodifico = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        Dim fechamodificacion = DateTime.Now.ToString("dd/MM/yyyy")
        datos = getTamañosMaterialesid(0)
        If datos.Rows.Count > 0 Then
            sku = datos.Rows(datos.Rows.Count - 1).Item(2).ToString
            sku = obj.getNextNumeroAlfaNumerico(sku)
        Else
            sku = "00"
        End If
        Dim consulta As String =
            <cadena>
            insert into Materiales.Tamano(tama_nombre,tama_sku,tama_status,tama_usuariocreoid,tama_fechacreacion,tama_usuariomodificoid,tama_fechamodificacion)
            </cadena>
        consulta += " values('" & nombre & "','" & sku & "',1," & usuariocreo & ",'" & fechacreacion & "'," & usuariomodifico & ",'" & fechamodificacion & "')"
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function idtamanoinsertado() As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String
        consulta = "SELECT TOP 1 tama_idTamano 'idTam' FROM Materiales.Tamano ORDER BY tama_idTamano DESC "
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Sub isertarTamanoClasificacion(ByVal tamano As Entidades.ClasificacionTamanovb)
        Dim operaciones As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "@clta_idclasificacion"
        parametro.Value = tamano.clta_idclasificacion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@clta_idtamano"
        parametro.Value = tamano.clta_idtamano
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@clta_usuariocreoid"
        parametro.Value = tamano.clta_usuariocreoid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@clta_fechacreacion"
        parametro.Value = tamano.clta_fechacreacion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@clta_usuariomodificoid"
        parametro.Value = tamano.clta_usuariomodificoid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@clta_fechamodificacion"
        parametro.Value = tamano.clta_fechamodificacion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@clta_estatus"
        parametro.Value = tamano.clta_estatus
        listaParametros.Add(parametro)

        operaciones.EjecutarSentenciaSP("Materiales.SP_ClasificacionesTamanos", listaParametros)
        Console.WriteLine("Mando la sentencia")
    End Sub

    Public Function ActualizarTamanoClasificacion(ByVal estatus As Integer, ByVal idclas As Integer, ByVal usumod As Integer,
                                                  ByVal clasificaciontamid As Integer, ByVal fecha As Date, ByVal idtam As Integer) As DataTable
        Dim operaciones As New OperacionesProcedimientos
        'Dim listaParametros As New List(Of SqlParameter)
        'Dim parametro As New SqlParameter

        'parametro = New SqlParameter
        'parametro.ParameterName = "@clta_clasificaciontamanoid"
        'parametro.Value = tamano.clta_clasificaciontamanoid
        'listaParametros.Add(parametro)

        'parametro = New SqlParameter
        'parametro.ParameterName = "@clta_idclasificacion"
        'parametro.Value = tamano.clta_idclasificacion
        'listaParametros.Add(parametro)

        'parametro = New SqlParameter
        'parametro.ParameterName = "@clta_usuariomodificoid"
        'parametro.Value = tamano.clta_usuariomodificoid
        'listaParametros.Add(parametro)

        'parametro = New SqlParameter
        'parametro.ParameterName = "@clta_fechamodificacion"
        'parametro.Value = tamano.clta_fechamodificacion
        'listaParametros.Add(parametro)

        'parametro = New SqlParameter
        'parametro.ParameterName = "@clta_estatus"
        'parametro.Value = tamano.clta_estatus
        'listaParametros.Add(parametro)

        'operaciones.EjecutarSentenciaSP("Materiales.SP_ActualizarTamanoClasificacion", listaParametros)
        'Console.WriteLine("Mando la sentencia")

        Dim consulta As String = ""

        consulta += "update Materiales.ClasificacionTamanos"
        consulta += "  set"
        consulta += "  clta_estatus=" + estatus.ToString
        consulta += " , clta_usuariomodificoid=" + usumod.ToString
        consulta += " , clta_fechamodificacion='" + fecha.ToString + "'"
        consulta += "  where clta_idclasificacion=" + idclas.ToString + " and  clta_idtamano=" + idtam.ToString
        Return operaciones.EjecutaConsulta(consulta)

        'Dim consulta As String = ""

        'consulta += "update Materiales.ClasificacionColores"
        'consulta += "  set"
        'consulta += "  clco_estatus=" + estatus.ToString
        'consulta += " , clco_usuariomodificoid=" + usumod.ToString
        'consulta += " , clco_fechamodificacion='" + fecha.ToString + "'"
        'consulta += "  where clco_clasificacioncoloresid=" + idclas.ToString
        'consulta += " End"
        'Return operaciones.EjecutaConsulta(consulta)
    End Function

End Class
