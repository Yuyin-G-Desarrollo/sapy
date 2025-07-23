



Public Class CatalogoConfiguracionDeValidacionesBU



    '''<comentario> 
    ''' Ejecuta la funcion ListaTipo de la capa DA para pasarla al un combobox en la capa Framework.Vista
    '''</comentario> 
    '''<retorno>Lista tipo, que contiene la lista de los tipos de validacion</retorno>
    Public Function ListaTipo() As List(Of Entidades.ListaTipoValidaciones)
        Dim objDA As New Datos.CatalogoConfiguracionDeValidacionesDA
        Dim tabla As New DataTable
        ListaTipo = New List(Of Entidades.ListaTipoValidaciones)
        tabla = objDA.ListaTipo()
        For Each fila As DataRow In tabla.Rows
            Dim TipoValidacion As New Entidades.ListaTipoValidaciones
            TipoValidacion.PId = CInt(fila("Id"))
            TipoValidacion.Pnombre = CStr(fila("Nombre")).ToUpper
            TipoValidacion.PTabla = CStr(fila("Tabla")).ToUpper
            TipoValidacion.PCampoTabla = CStr(fila("Campo")).ToUpper
            TipoValidacion.PCampoTablaStatus = CStr(fila("Campo_Status")).ToUpper
            TipoValidacion.Pactivo = CBool(fila("Activo"))
            ListaTipo.Add(TipoValidacion)
        Next
        Return ListaTipo
    End Function


    ''' <summary>
    ''' REGRESA LA LISTA DEL METODO DTLISTACONFIGURACIONES DE LA CAPA DE DATOS
    ''' </summary>
    ''' <returns>LISTA CON LAS CONFIGURACIONES Y EL USUARIO QUE TIENE ACCESO A CADA UNA DE ELLAS</returns>
    ''' <remarks></remarks>
    Public Function dtListaConfiguracion() As DataTable
        Dim objconfiguracionDA As New Datos.CatalogoConfiguracionDeValidacionesDA
        dtListaConfiguracion = objconfiguracionDA.dtListaConfiguraciones()
        Return dtListaConfiguracion
    End Function

   
    Public Sub EditarConfiguracioDeValidaciones(ByVal IdColaborador As Integer, ByVal IdTipoValidacion As Integer)
        Dim objValidacion As New Datos.CatalogoConfiguracionDeValidacionesDA
        objValidacion.EditarConfiguracionDeValidaciones(IdColaborador, IdTipoValidacion)
    End Sub

End Class
