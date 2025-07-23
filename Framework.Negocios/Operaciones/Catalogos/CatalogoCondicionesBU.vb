

Public Class CatalogoCondicionesBU

    '''<comentario> 
    ''' Ejecuta la funcion ListaTipoCondicoin de la capa DA para pasarla al formulario CatalogoCondicionesForm de la capa Vista.
    '''</comentario> 
    '''<retorno>Lista tipo, que contiene la lista de los tipos de condicion</retorno>
    Public Function ListaTipo() As DataTable
        Dim objTipoDA As New Datos.CatalogoCondicionesDA
        ListaTipo = objTipoDA.ListaTipoCondicion()
        Return ListaTipo
    End Function

    '''<comentario> 
    ''' Ejecuta la funcion ListaCondicion de la capa DA para pasarla al formulario CatalogoCondicionesForm de la capa Vista.
    '''</comentario> 
    '''<parametro1>IdTipo, indica el tipo de condicion con el que se hara el filtro para hacer la consulta de las condiciones</parametro1>
    '''<retorno>ListaCondicion, que contiene la lista de las condiciones</retorno>
    Public Function ListaCondicion(ByVal IdTipo As Integer) As DataTable
        Dim objCondicionDA As New Datos.CatalogoCondicionesDA
        ListaCondicion = objCondicionDA.ListaCondicion(IdTipo)
        Return ListaCondicion
    End Function

    '''<comentario> 
    ''' Ejecuta la funcion ListaCondicionCatalogo de la capa DA para pasarla al formulario CatalogoCondicionesForm de la capa Vista.
    '''</comentario> 
    '''<parametro1>IdCondicion, indica el tipo de condicion con el que se hara el filtro para hacer la consulta delos catalogos</parametro1>
    '''<retorno>ListaCatalogo, que contiene la lista de los catalogos</retorno>
    Public Function ListaCatalogo(ByVal IdCondicion As Integer) As DataTable
        Dim objCondicionCatalogoDA As New Datos.CatalogoCondicionesDA
        ListaCatalogo = objCondicionCatalogoDA.ListaCondicionCatalogo(IdCondicion)
        Return ListaCatalogo
    End Function

    '''<comentario> 
    ''' Ejecuta la funcion ListaAreaOperativa de la capa DA para pasarla al formulario CatalogoCondicionesForm de la capa Vista.
    '''</comentario> 
    '''<parametro1>IdCondicion, indica el tipo de condicion con el que se hara el filtro para hacer la consulta de las areas operativas</parametro1>
    '''<retorno>ListaAreasOperativas</retorno>
    Public Function ListaAreasOperativas(ByVal IdCondicion As Integer) As DataTable
        Dim objAreaOperativaDA As New Datos.CatalogoCondicionesDA
        ListaAreasOperativas = objAreaOperativaDA.ListaAreaOperativa(IdCondicion)
        Return ListaAreasOperativas
    End Function


    '''<comentario> 
    ''' Ejecuta la funcion ListaAreaOperativa de la capa DA para pasarla al formulario CatalogoCondicionesForm de la capa Vista 
    ''' y ocuparlo en el llenado de la tabla de consulta de politicas.
    '''</comentario> 
    '''<parametro1>IdCondicion, indica el tipo de condicion con el que se hara el filtro para hacer la consulta de las areas operativas</parametro1>
    '''<retorno>ListaAreasOperativas</retorno>
    Public Function ListaAreasOperativasConsulta(ByVal IdCondicion As Integer) As DataTable
        Dim objAreaOperativaDA As New Datos.CatalogoCondicionesDA
        ListaAreasOperativasConsulta = objAreaOperativaDA.ListaAreaOperativaConsulta(IdCondicion)
        Return ListaAreasOperativasConsulta
    End Function

    '''<comentario> 
    ''' Ejecuta la funcion ListaCatalogoCondiciones de la capa DA para pasarla al formulario CatalogoCondicionesForm de la capa Vista.
    '''</comentario> 
    '''<retorno>ListaCatalogoCondiciones</retorno>
    Public Function ListaCatalogoCondiciones() As DataTable
        Dim objCatalogoCondicionesDA As New Datos.CatalogoCondicionesDA
        ListaCatalogoCondiciones = objCatalogoCondicionesDA.ListaCatalogoCondiciones()
        Return ListaCatalogoCondiciones
    End Function


    '''<comentario> 
    ''' Ejecuta la funcion ListaTipoCondicion de la capa DA para pasarla al combobox cboTipoCondicion de el formulario AgregarEditarCondicionesForm
    '''</comentario> 
    '''<retorno>Lista tipo, que contiene la lista de los tipos de condicion</retorno>
    Public Function ListaTipoCondicion() As List(Of Entidades.CatalogoCondicionesTipo)
        Dim objDA As New Datos.CatalogoCondicionesDA
        Dim tabla As New DataTable
        ListaTipoCondicion = New List(Of Entidades.CatalogoCondicionesTipo)
        tabla = objDA.ListaTipoCondicion()
        For Each fila As DataRow In tabla.Rows
            Dim TipoCondicion As New Entidades.CatalogoCondicionesTipo
            TipoCondicion.PIdTipo = CInt(fila("Id"))
            TipoCondicion.PNombre = CStr(fila("Tipo")).ToUpper
            TipoCondicion.PActivo = CBool(fila("Activo"))
            ListaTipoCondicion.Add(TipoCondicion)
        Next
        Return ListaTipoCondicion
    End Function

    '''<comentario> 
    ''' Ejecuta la funcion ListaCondicion de la capa DA para pasarla al combobox cboCondicionCatalogo de el formulario AgregarEditarCondicionesForm
    '''</comentario> 
    '''<retorno>Lista tipo, que contiene la lista de las condiciones</retorno>
    Public Function ListaCondicionCatalogo(ByVal IdTipo As Integer) As List(Of Entidades.CatalogoCondicionesCondicion)
        Dim objDA As New Datos.CatalogoCondicionesDA
        Dim tabla As New DataTable
        ListaCondicionCatalogo = New List(Of Entidades.CatalogoCondicionesCondicion)
        tabla = objDA.ListaCondicion(IdTipo)
        For Each fila As DataRow In tabla.Rows
            Dim TipoCondicion As New Entidades.CatalogoCondicionesCondicion
            TipoCondicion.PIdCondicion = CInt(fila("Id"))
            TipoCondicion.PNombre = CStr(fila("Nombre")).ToUpper
            TipoCondicion.PActivo = CBool(fila("Activo"))
            ListaCondicionCatalogo.Add(TipoCondicion)
        Next
        Return ListaCondicionCatalogo
    End Function


    '''<comentario> 
    ''' Obtiene los Datos para dar de alta un nuevo "Tipo de condicion" la clase entidades.CatalogosCondicionesTipo para enviarlos 
    ''' a la clase CatalogoCondicionesDA 
    '''</comentario> 
    '''<parametro1>Condiciones, que son todas las variables de la clase CatalogoCondicionesTipo</parametro1>
    '''<retorno></retorno>
    Public Sub altaTipo(ByVal Condiciones As Entidades.CatalogoCondicionesTipo)
        Dim objTipoDA As New Datos.CatalogoCondicionesDA
        objTipoDA.AltaTipo(Condiciones)
    End Sub

    '''<comentario> 
    ''' Obtiene los Datos para editar un registro de "Tipo de Condiciones" desde la clase CatalogoCondicionesTipo para enviarlos
    '''  a la clase CatalogoCondicionesDA 
    '''</comentario> 
    '''<parametro1></parametro1> 
    '''<retorno></retorno>
    Public Sub editarTipoCondiciones(ByVal Condiciones As Entidades.CatalogoCondicionesTipo)
        Dim objTipoDA As New Datos.CatalogoCondicionesDA
        objTipoDA.EditarTipo(Condiciones)
    End Sub


    '''<comentario> 
    ''' Obtiene los Datos para dar de alta un nuevo "condicion" la clase entidades.CatalogosCondicionesTipo para enviarlos a la clase 
    ''' CatalogoCondicionesDA 
    '''</comentario> 
    '''<parametro1>Condiciones, que son todas las variables de la clase CatalogoCondicionesTipo</parametro1>
    '''<retorno></retorno>
    Public Sub altaCondicion(ByVal Condiciones As Entidades.CatalogoCondicionesCondicion)
        Dim objCondicionDA As New Datos.CatalogoCondicionesDA
        objCondicionDA.AltaCondicion(Condiciones)
    End Sub

    '''<comentario> 
    ''' Obtiene los Datos para editar un registro de "Condiciones" desde la clase CatalogoCondicionesCondicion para enviarlos 
    ''' a la clase CatalogoCondicionesDA 
    '''</comentario> 
    '''<parametro1></parametro1> 
    '''<retorno></retorno>
    Public Sub editarCondicion(ByVal Condiciones As Entidades.CatalogoCondicionesCondicion)
        Dim objCondicionDA As New Datos.CatalogoCondicionesDA
        objCondicionDA.EditarCondicion(Condiciones)
    End Sub


    '''<comentario> 
    ''' Obtiene los Datos para dar de alta un nuevo dato en la tabla "CatalogoCondicion" desde la clase entidades.CatalogosCondicionesCatalogo para enviarlos a la clase 
    ''' CatalogoCondicionesDA 
    '''</comentario> 
    '''<parametro1>Catallogo, que son todas las variables de la clase CatalogoCondicionesTipo</parametro1>
    '''<retorno></retorno>
    Public Sub altaCatalogo(ByVal Catalogo As Entidades.CatalogoCondicionesCatalogo)
        Dim objCatalogoDA As New Datos.CatalogoCondicionesDA
        objCatalogoDA.AltaCatalogo(Catalogo)
    End Sub

    '''<comentario> 
    ''' Obtiene los Datos para editar un dato en la tabla "CatalogoCondicion" desde la clase Entidades.CatalogosCondicionesCatalogo para enviarlos a la clase CatalogoCondicionesDA 
    '''</comentario> 
    '''<parametro1>Catalogo, es una entidad de la clase CatalogoCondicionesCatalogo</parametro1> 
    '''<retorno></retorno>
    Public Sub editarCatalogo(ByVal Catalogo As Entidades.CatalogoCondicionesCatalogo)
        Dim objCatalogoDA As New Datos.CatalogoCondicionesDA
        objCatalogoDA.EditarCatalogo(Catalogo)
    End Sub


    '''<comentario> 
    ''' Obtiene los el registro de la ultima condicion agregada a la tabal Framework.Condicion 
    '''</comentario> 
    '''<parametro1>Condicion, Nombre de la condicion</parametro1> 
    '''<retorno>Condiciones, contienes en IdCondicion, nombre, Id del tipo de condicion, Activo</retorno>
    Public Function RecuperarCondicion() As Entidades.CatalogoCondicionesCondicion

        Dim objCondicionesDA As New Datos.CatalogoCondicionesDA
        Dim Condiciones As New Entidades.CatalogoCondicionesCondicion
        Dim TablaCondiciones As New DataTable
        TablaCondiciones = objCondicionesDA.RecuperarCondicion()
        For Each fila As DataRow In TablaCondiciones.Rows
            Condiciones.PIdCondicion = CInt(fila("cond_condicionid"))
            Condiciones.PNombre = CStr(fila("cond_nombre"))
            Condiciones.PIdTipo = CInt(fila("cond_tipocondicionid"))
            Condiciones.PActivo = CBool(fila("cond_activo"))
        Next
        Return Condiciones
    End Function

    '''<comentario> 
    ''' Obtiene los el registro de la ultima descripción agregada a la tabla Framework.CondicionCatalogo
    '''</comentario> 
    '''<retorno>IdCatalogo, Descripcion, Activo</retorno>
    Public Function RecuperarCatalogo() As Entidades.CatalogoCondicionesCatalogo
        Dim objCondicionesDA As New Datos.CatalogoCondicionesDA
        Dim Condiciones As New Entidades.CatalogoCondicionesCatalogo
        Dim TablaCatalogo As New DataTable
        TablaCatalogo = objCondicionesDA.RecuperarCatalogo()
        For Each fila As DataRow In TablaCatalogo.Rows
            Condiciones.PIdCatalogo = CInt(fila("coca_condicioncatalogoid"))
            Condiciones.PDescripcion = CStr(fila("coca_descripcion"))
            Condiciones.PActivo = CBool(fila("coca_activo"))
        Next
        Return Condiciones
    End Function


    '''<comentario> 
    ''' Obtiene los Datos para dar de alta un nuevo "condicion" la clase entidades.CatalogosCondicionesTipo para enviarlos a la clase 
    ''' CatalogoCondicionesDA 
    '''</comentario> 
    '''<parametro1>Condiciones, que son todas las variables de la clase CatalogoCondicionesTipo</parametro1>
    '''<retorno></retorno>
    Public Sub AltaCondicionAClientes(ByVal IdCatalogo As Integer)
        Dim objCondicionDA As New Datos.CatalogoCondicionesDA
        objCondicionDA.AltaCondicionCliente(IdCatalogo)
    End Sub


    '''<comentario> 
    ''' Actualiza las areas operativas asignadas a cierta condicion y si no existe la relacion la crea
    '''</comentario> 
    '''<parametro1>AreaOperaTiva, es la calse CatalogoCondicionesAreaOperativa de entidades con todas su variables</parametro1>
    '''<retorno></retorno>
    Public Sub ActualizarCondicionAreaOperativa(ByVal AreaOperativa As Entidades.CatalogoCondicionesAreaOperativa)
        Dim objAreaOpDA As New Datos.CatalogoCondicionesDA
        objAreaOpDA.ActualizarCondicionAreaOperativa(AreaOperativa)
    End Sub

    '''<comentario> 
    ''' VALIDA SI NO EXISTE ALGUNA CONDICION CON EL NOMBRE QUE EL USUARIO  PRETENDE PONER A UNA NUEVA CONDICION.
    '''</comentario> 
    '''<retorno>LISTACONDICION</retorno>
    Public Function BuscarCondicion(ByVal nombre As String) As Entidades.CatalogoCondicionesCondicion

        Dim objCondicionDa As New Datos.CatalogoCondicionesDA
        Dim TablaCondicion As New DataTable
        Dim condicion As New Entidades.CatalogoCondicionesCondicion
        TablaCondicion = objCondicionDa.BuscarCondicion(nombre)

        For Each fila As DataRow In TablaCondicion.Rows
            condicion.PIdCondicion = CInt(fila("Id"))
        Next
        Return condicion
    End Function

    ''' <summary>
    ''' ACTUALIZA LOS REGISTROS DE UNA CONDICION PARA TODOS LOS CLIENTES EN EL CAMPO "ACTIVO"
    ''' </summary>
    ''' <param name="IdCatalogo">ID DEL CATALOGO</param>
    ''' <remarks></remarks>
    Public Sub ActualizarCondicionClientes(ByVal IdCatalogo As Integer, Activo As Boolean)
        Dim objCondicionDA As New Datos.CatalogoCondicionesDA
        objCondicionDA.ActualizarCondicionClientes(IdCatalogo, Activo)
    End Sub

    Public Function ConteoCatalogoClientes(ByVal IdCatalogo As Integer) As DataTable
        Dim objConteoDA As New Datos.CatalogoCondicionesDA
        ConteoCatalogoClientes = objConteoDA.ConteoCatalogoClientes(IdCatalogo)
        Return ConteoCatalogoClientes
    End Function

End Class

