Imports Framework.Datos

Public Class NavesBU

    Public Function listaNavesActivas() As DataTable
        Dim objDA As New Datos.NavesDA
        Return objDA.listaNaves()
    End Function

    Public Function ListaNavesSegunUsuarioConIdSicy(ByVal IDUsuario As Integer) As List(Of Entidades.Naves)
        Dim objDA As New Datos.NavesDA
        Dim tabla As New DataTable
        ListaNavesSegunUsuarioConIdSicy = New List(Of Entidades.Naves)
        tabla = objDA.ListaNavesSegunUsuario("", IDUsuario)
        For Each fila As DataRow In tabla.Rows
            Dim naveSegunID As New Entidades.Naves
            naveSegunID.PNombre = CStr(fila("nave_nombre")).ToUpper
            naveSegunID.PNaveSICYid = CInt(fila("nave_navesicyid"))
            ListaNavesSegunUsuarioConIdSicy.Add(naveSegunID)
        Next
    End Function

    Public Function ListaNavesSegunUsuario(ByVal nombre As String, ByVal IDUsuario As Integer) As List(Of Entidades.Naves)
        Dim objDA As New Datos.NavesDA
        Dim tabla As New DataTable
        ListaNavesSegunUsuario = New List(Of Entidades.Naves)
        tabla = objDA.ListaNavesSegunUsuario(nombre, IDUsuario)
        For Each fila As DataRow In tabla.Rows
            Dim naveSegunID As New Entidades.Naves
            naveSegunID.PNombre = CStr(fila("nave_nombre")).ToUpper
            naveSegunID.PNaveId = CInt(fila("nave_naveid"))
            naveSegunID.PNaveSICYid = CInt(fila("nave_navesicyid"))
            ListaNavesSegunUsuario.Add(naveSegunID)
        Next
    End Function

    Public Function ListaNavesSegunUsuario_Especial(ByVal Usuario As Integer) As List(Of Entidades.Naves)
        Dim objDA As New Datos.NavesDA
        Dim tabla As New DataTable
        ListaNavesSegunUsuario_Especial = New List(Of Entidades.Naves)
        tabla = objDA.ListaNavesSegunUsuario_Especial(Usuario)
        For Each fila As DataRow In tabla.Rows
            Dim naveSegunID As New Entidades.Naves
            naveSegunID.PNombre = CStr(fila("nave_nombre")).ToUpper
            naveSegunID.PNaveId = CInt(fila("nave_naveid"))
            naveSegunID.PNaveSICYid = CInt(fila("nave_navesicyid"))
            ListaNavesSegunUsuario_Especial.Add(naveSegunID)
        Next
    End Function


    Public Function ListaNavesSegunUsuarioMaquilas(ByVal IDUsuario As Integer, ByVal PermisoMaquilas As Boolean) As List(Of Entidades.Naves)
        Dim objDA As New Datos.NavesDA
        Dim tabla As New DataTable
        ListaNavesSegunUsuarioMaquilas = New List(Of Entidades.Naves)
        tabla = objDA.ListaNavesSegunUsuarioMaquilas(IDUsuario, PermisoMaquilas)
        For Each fila As DataRow In tabla.Rows
            Dim naveSegunID As New Entidades.Naves
            naveSegunID.PNombre = CStr(fila("nave_nombre")).ToUpper
            naveSegunID.PNaveId = CInt(fila("nave_naveid"))
            naveSegunID.PNaveSICYid = CInt(fila("nave_navesicyid"))
            ListaNavesSegunUsuarioMaquilas.Add(naveSegunID)
        Next
    End Function

    Public Function ListaNavesConIdSicy_SegunUsuario(ByVal nombre As String, ByVal IDUsuario As Integer) As List(Of Entidades.Naves)
        Dim objDA As New Datos.NavesDA
        Dim tabla As New DataTable
        ListaNavesConIdSicy_SegunUsuario = New List(Of Entidades.Naves)
        tabla = objDA.ListaNavesSegunUsuario(nombre, IDUsuario)
        For Each fila As DataRow In tabla.Rows
            Dim naveSegunID As New Entidades.Naves
            naveSegunID.PNombre = CStr(fila("nave_nombre")).ToUpper
            naveSegunID.PNaveId = CInt(fila("nave_naveid"))
            naveSegunID.PNaveSICYid = CInt(fila("nave_navesicyid"))
            ListaNavesConIdSicy_SegunUsuario.Add(naveSegunID)
        Next
    End Function

    ''' <summary>
    ''' Funcion que retorna el listado de naves de la BD de SICY segun usuario de Yuyin ERP
    ''' </summary>
    ''' <param name="nombre">Nombre del Usuario</param>
    ''' <param name="IDUsuario">Id del usuario</param>
    ''' <returns>Tabla de Naves</returns>
    ''' <remarks></remarks>
    Public Function ListaNavesSICYSegunUsuario(ByVal nombre As String, ByVal IDUsuario As Integer) As List(Of Entidades.Naves)
        Dim objDA As New Datos.NavesDA
        Dim tabla As New DataTable
        ListaNavesSICYSegunUsuario = New List(Of Entidades.Naves)
        tabla = objDA.ListaNavesSegunUsuario(nombre, IDUsuario)
        For Each fila As DataRow In tabla.Rows
            Dim naveSegunID As New Entidades.Naves
            naveSegunID.PNombre = CStr(fila("nave_nombre")).ToUpper
            naveSegunID.PNaveSICYid = CInt(fila("nave_navesicyid"))
            ListaNavesSICYSegunUsuario.Add(naveSegunID)
        Next
    End Function

    Public Function listaNaves() As DataTable
        Dim da As New Datos.NavesDA
        Return da.listaNaves()
    End Function

    Public Function listaDeNaves(ByVal nombre As String, ByVal activo As Boolean) As List(Of Entidades.Naves)
        Dim objDA As New Datos.NavesDA
        Dim tabla As New DataTable
        listaDeNaves = New List(Of Entidades.Naves)
        tabla = objDA.listaDeNaves(nombre, activo)
        For Each fila As DataRow In tabla.Rows
            Dim nave As New Entidades.Naves

            nave.PNaveId = CInt(fila("nave_naveid"))
            nave.PNombre = CStr(fila("nave_nombre"))
            nave.PActivo = CBool(fila("nave_activo"))

            listaDeNaves.Add(nave)

        Next
    End Function
    Public Sub editarNaves(ByVal nave As Entidades.Naves)
        Dim ObjNave As New NavesDA
        ObjNave.editarNaves(nave)

    End Sub
    Public Sub guardarNaves(ByVal nave As Entidades.Naves)
        Dim objNaves As New NavesDA
        objNaves.guardarNaves(nave)

    End Sub

    Public Function buscarNaves(ByVal navesid As Int32) As Entidades.Naves

        Dim objNavesDA As New Datos.NavesDA
        Dim nave As New Entidades.Naves
        Dim tablaNave As New DataTable
        tablaNave = objNavesDA.buscarNaves(navesid)

        For Each fila As DataRow In tablaNave.Rows


            nave.PNaveId = CInt(fila("nave_naveid"))
            nave.PNombre = CStr(fila("nave_nombre"))
            nave.PActivo = CBool(fila("nave_activo"))
        Next


        Return nave
    End Function

    Public Function ListaNavesSegunUsuarioTabla(ByVal nombre As String, ByVal IDUsuario As Integer) As DataTable

        Dim objDA As New Datos.NavesDA
        Return objDA.ListaNavesSegunUsuario(nombre, IDUsuario)

    End Function

    Public Function TablaDeNaves() As DataTable
        Dim objDA As New Datos.NavesDA
        TablaDeNaves = New DataTable
        TablaDeNaves = objDA.listaDeNavesTabla()
    End Function
    Public Function TablaDeNavesActivas() As DataTable
        Dim objDA As New Datos.NavesDA
        TablaDeNavesActivas = New DataTable
        TablaDeNavesActivas = objDA.listaDeNavesTablaActivas()
        Dim R As DataRow = TablaDeNavesActivas.NewRow
        R(0) = 0
        R(1) = ""
        TablaDeNavesActivas.Rows.InsertAt(R, 0)
    End Function
    Public Function ListaNavesConAlmacenSegunUsuario(ByVal IDUsuario As Integer) As List(Of Entidades.Naves)
        Dim objDA As New Datos.NavesDA
        Dim tabla As New DataTable
        ListaNavesConAlmacenSegunUsuario = New List(Of Entidades.Naves)
        tabla = objDA.ListaNavesConAlmacenSegunUsuario(IDUsuario)
        For Each fila As DataRow In tabla.Rows
            Dim naveSegunID As New Entidades.Naves
            naveSegunID.PNombre = CStr(fila("nave_nombre")).ToUpper
            naveSegunID.PNaveId = CInt(fila("bahi_nave"))
            ListaNavesConAlmacenSegunUsuario.Add(naveSegunID)
        Next
    End Function

    Public Function ListaAlmacenSegunNave(ByVal naveid As Integer) As List(Of Integer)

        Dim objDA As New Datos.NavesDA
        Dim tabla As New DataTable

        tabla = objDA.ListaAlmacenSegunNave(naveid)
        Dim lista As New List(Of Integer)

        For Each row As DataRow In tabla.Rows
            Dim almacen As Integer = CInt(row.Item("bahi_almacen"))
            lista.Add(almacen)
        Next
        ListaAlmacenSegunNave = lista

    End Function


    ''' <summary>
    ''' Funcion para obtener el logotipo de la nave
    ''' Return String
    ''' </summary>
    ''' <param name="naveid"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ObtenerLogoNave(ByVal naveid As Int32) As String
        Dim objbu As New Framework.Datos.NavesDA
        Dim tabla As New DataTable
        tabla = objbu.ObtenerLogotipoNave(naveid)
        Dim url As String = String.Empty
        For Each row As DataRow In tabla.Rows
            url = row("nave_logotipourl").ToString
        Next
        Return url
    End Function
    Public Function ObtenerLogoNaveSICY(ByVal naveid As Int32) As String
        Dim objbu As New Framework.Datos.NavesDA
        Dim tabla As New DataTable
        tabla = objbu.ObtenerLogotipoSICYNave(naveid)
        Dim url As String = String.Empty
        For Each row As DataRow In tabla.Rows
            url = row("nave_logotipourl").ToString
        Next
        Return url
    End Function
    Public Function TablaNavesAux() As DataTable
        Dim objbu As New Framework.Datos.NavesDA
        Return objbu.TablaNavesAux
    End Function
    Public Function TablaNavesAuxOrdenar() As DataTable
        Dim objbu As New Framework.Datos.NavesDA
        Return objbu.TablaNavesAuxOrdena
    End Function
    Public Sub actualizarDiaNaveAuxiliar(ByVal columna As String, ByVal valor As Double, ByVal id As Integer)
        Dim objbu As New Framework.Datos.NavesDA
        objbu.actualizarDiaNaveAuxiliar(columna, valor, id)
    End Sub
    Public Sub Actualizar(ByVal id As Integer, ByVal lugar As Integer)
        Dim objbu As New Framework.Datos.NavesDA
        objbu.Actualizar(id, lugar)
    End Sub
    Public Function obtenerNavesComboAuxiliar() As DataTable
        Dim objbu As New Framework.Datos.NavesDA
        Dim tablas As New DataTable
        tablas = objbu.obtenerNavesComboAuxiliar
        Dim newRow As DataRow = tablas.NewRow
        tablas.Rows.InsertAt(newRow, 0)
        Return tablas
    End Function
    Public Sub ActualizarNaveSicy(ByVal id As Integer, ByVal ID_SICY As Integer)
        Dim objbu As New Framework.Datos.NavesDA
        objbu.ActualizarNaveSicy(id, ID_SICY)
    End Sub
    Public Sub ActualizarNaveProduccion(ByVal id As Integer, ByVal activo As Integer)
        Dim objbu As New Framework.Datos.NavesDA
        objbu.ActualizarNaveProduccion(id, activo)
    End Sub
    Public Function TablaNavesAuxAsignar() As DataTable

        Dim objbu As New Framework.Datos.NavesDA
        Return objbu.TablaNavesAuxAsignar
    End Function

    Public Function TablaDeNavesAuxiliares() As DataTable
        Dim objDA As New Datos.NavesDA
        Return objDA.listaDeNavesTablaActivas()
    End Function
End Class

