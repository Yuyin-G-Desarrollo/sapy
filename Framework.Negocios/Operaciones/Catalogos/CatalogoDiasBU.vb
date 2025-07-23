Imports Entidades


Public Class CatalogoDiasBU

    '''<comentario> 
    ''' Obtiene los Datos del dia desde el formulario CatalogoDias para enviarlos a la clase CatalogoDiasDA 
    '''</comentario> 
    '''<parametro1>Activo</parametro1> 
    '''<parametro2>Nombre del día</parametro2>
    '''<retorno>Lista Dias</retorno>
    Public Function ListaDias(ByVal activo As Boolean, ByVal nombreDia As String) As DataTable
        Dim objDA As New Datos.CatalogosDiasDA
        ListaDias = objDA.ListaDias(activo, nombreDia)
        Return ListaDias
    End Function



    '''<comentario> 
    ''' Obtiene los Datos para dar de alta un nuevo dia desde la clase entidades.CatalogosDias para enviarlos a la clase CatalogoDiasDA 
    '''</comentario> 
    '''<parametro1></parametro1>
    '''<retorno></retorno>
    Public Sub guardarDias(ByVal Dias As Entidades.CatalogosDias)
        Dim objDias As New Datos.CatalogosDiasDA
        objDias.AltaDias(Dias)
    End Sub



    '''<comentario> 
    ''' Obtiene los Datos para editar un registro de dias desde la clase CatalogosDias para enviarlos a la clase CatalogoDiasDA 
    '''</comentario> 
    '''<parametro1></parametro1> 
    '''<parametro2></parametro2>
    '''<retorno></retorno>
    Public Sub editarDias(ByVal Dias As Entidades.CatalogosDias)
        Dim ObjEditarDias As New Datos.CatalogosDiasDA
        ObjEditarDias.EditarDias(Dias)
    End Sub



End Class
