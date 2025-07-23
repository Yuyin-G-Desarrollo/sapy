Imports System.Data.SqlClient

Public Class CatalogoConfiguracionDeValidacionesDA





    '''<comentario> 
    ''' Funcion que realiza la consulta de los tipos de validacion y les da formato de tabla.
    '''</comentario> 
    '''<retorno>Ejecusion de Consulta SQL para seleccionar los tipos de validacion</retorno>
    Public Function ListaTipo() As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "  "
        consulta = "SELECT vati_validaciontipoid as Id, vati_nombre as Nombre, vati_tabla as Tabla" +
            ", vati_campotablaid as Campo, vati_campotablastatus as Campo_Status, vati_activo as Activo" +
            " FROM Framework.ValidacionTipo order by vati_nombre "
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    ''' <summary>
    ''' CONSULTA OS NOMBRES DE LAS VALIDACIONES EXISTENTES Y LOS COLABORADORES QUE LAS CONTROLAN
    ''' </summary>
    ''' <returns>EJECUCION DE CONSULTA REALIZADA EN FORMATO DE TABLA</returns>
    ''' <remarks></remarks>
    Public Function dtListaConfiguraciones() As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "  "
        consulta = "Select	LTRIM(RTRIM(UPPER(vt.vati_nombre))) as Validación, vu.vati_validaciontipoid AS IDTIPO" +
            ", LTRIM(rtrim(UPPER(nc.codr_nombre)))  +' '+LTRIM(RTRIM(UPPER(nc.codr_apellidoPaterno))) +' '+ LTRIM(RTRIM(UPPER(nc.codr_apellidomaterno)))  as Colaborador" +
            ", vu.vati_colaboradorid AS IDCOLABORADOR, cl.labo_departamentoid AS IDDEPARTAMENTO, GR.grup_areaid AS IDAREA, area_naveid AS idNave" +
            " from framework.ValidacionUsuario vu JOIN framework.ValidacionTipo vt on vt.vati_validaciontipoid = vu.vati_validaciontipoid" +
            " JOIN nomina.Colaborador  nc on nc.codr_colaboradorid = vu.vati_colaboradorid" +
            " JOIN Nomina.ColaboradorLaboral cl ON cl.labo_colaboradorid = vu.vati_colaboradorid" +
            " JOIN Framework.Grupos GR  ON cl.labo_departamentoid =grup_grupoid" +
            " join Nomina.Areas on area_areaid = grup_areaid ORDER BY Validación"
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    ''' <summary>
    ''' EJECUTA PROCEDIMIENTO ALMACENADO DONDE ACTUALIZA UN REGISTRO DE LA TABLA FRAMEWORK.VALIDACIONUSUARIO EN BASE A EL TIPO DE CONFIGURACION
    ''' </summary>
    ''' <param name="IdColaborador">ID DEL COLABORADOR QUE ESTARA AUTORIZADO A USAR LA VALIDACION</param>
    ''' <param name="IdTipoConfiguracion">ID DE LA VALIDACION A LA QUE SE LE DARA AUTORIZACION AL USUARIO</param>
    ''' <remarks></remarks>
    Public Sub EditarConfiguracionDeValidaciones(ByVal IdColaborador As Integer, ByVal IdTipoConfiguracion As Integer)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@ColaboradorId"
        parametro.Value = IdColaborador
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@ValidacionTipoId"
        parametro.Value = IdTipoConfiguracion
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@UsuarioModificoId"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaparametros.Add(parametro)
        parametro = New SqlParameter

        operaciones.EjecutarSentenciaSP("framework.SP_Editar_ValidacionUsuario", listaparametros)

    End Sub


End Class
