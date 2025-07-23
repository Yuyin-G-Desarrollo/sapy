Imports System.Data.SqlClient

Public Class ConveniosDA

    ''' <summary>
    ''' EJECUTA CONSULTA QUE TARE LA LISTA COMPLETA DE CONVENIOS
    ''' </summary>
    ''' <returns>RESULTADO DE LA CONSULTA, LISTA DE CONVENIOS</returns>
    ''' <remarks></remarks>
    Public Function ListaConvenios(ByVal IdPersona As Integer) As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "select coep_convenioempresaproveedorid as IdConvenio, emp.empr_nombre as Empresa" +
            ", coep_numeroconvenio as Numero, coep_fechasuscripcion as 'Fecha Subscripcion', coep_fechainiciovigencia as 'Fecha Inicio'" +
            ",  coep_fechafinvigencia as 'Fecha Fin', coep_personanegocia as Negocioador, coep_descripcion as Descripción" +
            ", coep_comentarios as Comentarios, coep_empresaid as IdEmpresa, coep_proveedorid as IdProveedor, coep_activo as Activo" +
            " from Framework.ConvenioEmpresaProveedor join  framework.empresas  emp on emp.empr_empresaid= coep_empresaid where coep_proveedorid = '" + IdPersona.ToString + "'"
        Return objOperaciones.EjecutaConsulta(consulta)
    End Function

    ''' <summary>
    ''' EJECUTA EL PROCEDIMIENTO ALMACENADO PARA DAR DE ALTA UN CONVENIO
    ''' </summary>
    ''' <param name="convenios">CLASE CONVENIOS DE LA CAPA ENTIDAD CON LOS VALORES A ASIGNAR AL NUEVO REGISTRO</param>
    ''' <remarks></remarks>
    Public Sub AgregarConvenios(ByVal convenios As Entidades.Convenios)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@NumeroConvenio"
        parametro.Value = convenios.PNumeroConvenio
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FechaSubscirpcion"
        parametro.Value = convenios.PFechaSub
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FechaInicio"
        parametro.Value = convenios.PFechaInicio
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FechaFin"
        parametro.Value = convenios.PFechaFin
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Negociador"
        parametro.Value = convenios.PNegociador
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Descripcion"
        parametro.Value = convenios.PDescripcion
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Comentarios"
        parametro.Value = convenios.PComentario
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@EmpresaId"
        parametro.Value = convenios.PIdEmpresa
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@ProveedorId"
        parametro.Value = convenios.PIdProveedor
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Activo"
        parametro.Value = convenios.PActivo
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Usuario"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaparametros.Add(parametro)
        parametro = New SqlParameter

        operaciones.EjecutarSentenciaSP("Framework.SP_Alta_Convenios", listaparametros)
    End Sub

    ''' <summary>
    ''' EJECUTA EL PROCEDIMIENTO ALMACENADO PARA ACTUALIZAR UN REGISTRO DE LA TABLA FRAMEWORK.CONVENIOEMPRESASPROVEEDOR
    ''' </summary>
    ''' <param name="convenios"></param>
    ''' <remarks></remarks>
    Public Sub ActualizarConvenios(ByVal convenios As Entidades.Convenios)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@NumeroConvenio"
        parametro.Value = convenios.PNumeroConvenio
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@IdConvenio"
        parametro.Value = convenios.PIdConvenio
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FechaSubscirpcion"
        parametro.Value = convenios.PFechaSub
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FechaInicio"
        parametro.Value = convenios.PFechaInicio
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FechaFin"
        parametro.Value = convenios.PFechaFin
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Negociador"
        parametro.Value = convenios.PNegociador
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Descripcion"
        parametro.Value = convenios.PDescripcion
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Comentarios"
        parametro.Value = convenios.PComentario
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@EmpresaId"
        parametro.Value = convenios.PIdEmpresa
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@ProveedorId"
        parametro.Value = convenios.PIdProveedor
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Activo"
        parametro.Value = convenios.PActivo
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Usuario"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaparametros.Add(parametro)
        parametro = New SqlParameter

        operaciones.EjecutarSentenciaSP("FRAMEWORK.SP_Editar_Convenios", listaparametros)
    End Sub


End Class
