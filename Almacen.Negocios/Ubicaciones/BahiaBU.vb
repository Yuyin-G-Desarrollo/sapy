Public Class BahiaBU

    Public Function ObtenerContenidoBahia(ByVal ListaBahias As HashSet(Of Entidades.Bahia)) As DataTable
        Dim objDA As New Almacen.Datos.BahiasDA
        Dim lBahias As String = String.Empty

        Dim listbahia As List(Of Entidades.Bahia) = ListaBahias.ToList
        Dim lbahia As String = String.Empty

        For Each item In listbahia

            If listbahia.IndexOf(item) = 0 Then
                lbahia += "'" + item.bahiaid + "'"
            Else
                lbahia += ", '" + item.bahiaid + "'"
            End If

        Next

        Return objDA.ObtenerContenidoBahia(lbahia)
    End Function


    Public Sub AltaBahia(ByVal Bahia As Entidades.Bahia)
        Dim OBJDA As New Almacen.Datos.BahiasDA
        OBJDA.AltaBahias(Bahia)
    End Sub

    Public Sub EdicionBahiasMasiva(ByVal Bahia As Entidades.Bahia)
        Dim objda As New Almacen.Datos.BahiasDA
        objda.EdicionBahiasMasiva(Bahia)

    End Sub
    Public Sub AddEstivas(ByVal Bahia As Entidades.Bahia)
        Dim objda As New Almacen.Datos.BahiasDA
        objda.AddEstivas(Bahia)
    End Sub

    Public Function ObtenerColoBahia(ByVal BahiaID As String) As String
        Dim objDA As New Almacen.Datos.BahiasDA
        Dim color As String = objDA.ObtenerColoBahia(BahiaID)
        Return color
    End Function


    Public Function AgregarColumna(ByVal Nave As Int32, ByVal Almacen As String, ByVal Bloque As String) As DataTable
        Dim objda As New Almacen.Datos.BahiasDA
        'Return objda.AgregarColumna(Nave, Almacen, Bloque)
    End Function


    Public Function CargarConfiguracionBahia(ByVal Naveid As Int32, ByVal Almacenid As Int32, ByVal Bloque As String, ByVal nivel As String) As Entidades.ConfiguracionBahia
        Dim objda As New Almacen.Datos.BahiasDA
        Dim tabla As New DataTable
        tabla = objda.BuscarConfiracionAlmacen(Naveid, Almacenid, Bloque, nivel)
        Dim confbahia As New Entidades.ConfiguracionBahia
        For Each row As DataRow In tabla.Rows

            confbahia.pcobo_configuracionbloqueid = CInt(row("cobl_configuracionbloqueid"))
            confbahia.pcobo_nave = CInt(row("cobl_nave"))
            confbahia.pcobo_almacen = CStr(row("cobl_almacen"))
            confbahia.pcobl_bloque = CStr(row("cobl_bloque"))
            confbahia.pcobl_renglones = CStr(row("cobl_renglones"))
            confbahia.pcobl_columnas = CStr(row("cobl_columnas"))

        Next
        Return confbahia
    End Function


    Public Function CargarMapaAlmacen(ByVal Naveid As Int32, ByVal Almacenid As Int32, ByVal Bloque As String, ByVal Nivel As String) As List(Of Entidades.Bahia)
        Dim objda As New Almacen.Datos.BahiasDA
        Dim tabla As New DataTable
        tabla = objda.CargarMapaBahias(Naveid, Almacenid, Bloque, Nivel)
        CargarMapaAlmacen = New List(Of Entidades.Bahia)
        For Each row As DataRow In tabla.Rows
            Dim bahia As New Entidades.Bahia
            bahia.bahiaid = CStr(row("bahi_bahiaid"))
            bahia.bahia_nave = CInt(row("bahi_nave"))
            bahia.bahi_almacen = CStr(row("bahi_almacen"))
            bahia.bahi_bloque = CStr(row("bahi_bloque"))
            bahia.bahi_fila = CStr(row("bahi_fila"))
            bahia.bahi_segmento = CStr(row("bahi_segmento"))
            bahia.bahi_nivel = CStr(row("bahi_nivel"))

            If Not IsDBNull(row("bahi_capacidadenpares")) Then
                bahia.capacidadenpares = CInt(row("bahi_capacidadenpares"))
            End If
            If Not IsDBNull(row("bahi_referenciaubicacionid")) Then
                bahia.bahi_referenciaubicacionid = CInt(row("bahi_referenciaubicacionid"))
            End If



            'If Not IsDBNull(CStr(row("bahi_estiba"))) Then
            '    bahia.bahi_estiba = CStr(row("bahi_estiba"))
            'End If

            'Try
            '    bahia.bahi_estiba = CStr(row("bahi_estiba"))
            'Catch ex As Exception

            'End Try

            bahia.bahi_descripcion = CStr(row("bahi_descripcion"))
            bahia.bahi_color = CStr(row("bahi_color"))
            bahia.bahi_posicion = CStr(row("bahi_posicion"))
            ' bahia.bahi_capacidadenpares = CInt(row("bahi_capacidadenpares"))
            bahia.bahi_activo = CBool(row("bahi_activo"))
            bahia.bahi_usuariocreoid = CInt(row("bahi_usuariocreoid"))
            bahia.bahi_fechacreacion = CDate(row("bahi_fechacreacion"))

            Dim objbucl As New Datos.ClientesAlmacenDA
            Dim tablas As New DataTable
            tablas = objbucl.CargarClientesBahia(bahia.bahiaid)
            Dim ListaClientes As New List(Of Entidades.ClientesAlmacen)
            For Each renglon As DataRow In tablas.Rows
                Dim Cliente As New Entidades.ClientesAlmacen
                Cliente.Cadena = CInt(renglon("bacl_idcadena"))
                ListaClientes.Add(Cliente)
            Next
            bahia.ListaClientes = ListaClientes



            bahia.bahi_fechamodificacion = Today.Date.ToShortDateString

            CargarMapaAlmacen.Add(bahia)
        Next


        Return CargarMapaAlmacen
    End Function






    Public Function CargarMapaAlmacenCompleto(ByVal Naveid As Int32, ByVal Almacenid As Int32, ByVal Bloque As String, ByVal Nivel As String) As List(Of Entidades.Bahia)
        Dim objda As New Almacen.Datos.BahiasDA
        Dim tabla As New DataTable
        tabla = objda.CargarMapaBahias(Naveid, Almacenid, Bloque, Nivel)
        CargarMapaAlmacenCompleto = New List(Of Entidades.Bahia)
        For Each row As DataRow In tabla.Rows
            Dim bahia As New Entidades.Bahia
            bahia.bahiaid = CStr(row("bahi_bahiaid"))
            bahia.bahia_nave = CInt(row("bahi_nave"))
            bahia.bahi_almacen = CStr(row("bahi_almacen"))
            bahia.bahi_bloque = CStr(row("bahi_bloque"))
            bahia.bahi_fila = CStr(row("bahi_fila"))
            bahia.bahi_segmento = CStr(row("bahi_segmento"))
            bahia.bahi_nivel = CStr(row("bahi_nivel"))

            If Not IsDBNull(row("bahi_capacidadenpares")) Then
                bahia.capacidadenpares = CInt(row("bahi_capacidadenpares"))
            End If
            If Not IsDBNull(row("bahi_referenciaubicacionid")) Then
                bahia.bahi_referenciaubicacionid = CInt(row("bahi_referenciaubicacionid"))
            End If
            bahia.bahi_descripcion = CStr(row("bahi_descripcion"))
            bahia.bahi_color = CStr(row("bahi_color"))
            bahia.bahi_posicion = CStr(row("bahi_posicion"))
            bahia.bahi_activo = CBool(row("bahi_activo"))
            bahia.bahi_usuariocreoid = CInt(row("bahi_usuariocreoid"))
            bahia.bahi_fechacreacion = CDate(row("bahi_fechacreacion"))
            bahia.bahi_fechamodificacion = Today.Date.ToShortDateString
            CargarMapaAlmacenCompleto.Add(bahia)
        Next


        Return CargarMapaAlmacenCompleto
    End Function





    Public Sub AltaConfiguracionBloques(ByVal conf As Entidades.ConfiguracionBahia)
        Dim objda As New Almacen.Datos.BahiasDA
        objda.AltaConfiguracionBloques(conf)
    End Sub

    ''' <summary>
    ''' Establecemos bahias menores cuando se agranda otra 
    ''' </summary>
    ''' <param name="bahia"></param>
    ''' <remarks></remarks>
    Public Sub EstablecerBahiaMenores(ByVal bahia As Entidades.Bahia)
        Dim objda As New Almacen.Datos.BahiasDA
        objda.EstablecerBahiaMenores(bahia)
    End Sub



    Public Function CargarBloques(ByVal Naveid As Int32, ByVal Almacen As String) As DataTable
        Dim objDA As New Almacen.Datos.BahiasDA
        Dim tabla As New DataTable
        tabla = objDA.CargarBloques(Naveid, Almacen)
        Return tabla
    End Function



    Public Function CargarBloquesCombo(ByVal Naveid As Int32, ByVal Almacen As String) As DataTable
        Dim objDA As New Almacen.Datos.BahiasDA
        Dim tabla As New DataTable
        tabla = objDA.CargarBloquesCombo(Naveid, Almacen)
        Return tabla
    End Function

    Public Function CargarNiveles(ByVal Naveid As Int32, ByVal Almacen As String, ByVal Bloque As String) As DataTable
        Dim objDA As New Almacen.Datos.BahiasDA
        Dim tabla As New DataTable
        tabla = objDA.CargarNiveles(Naveid, Almacen, Bloque)
        Return tabla
    End Function

    Public Function ValidadEstibasVacias(ByVal bahia As Entidades.Bahia) As Boolean
        Dim objda As New Almacen.Datos.BahiasDA
        ValidadEstibasVacias = objda.ValidadEstibasVacias(bahia)
    End Function
    Public Sub ActivarDesactivarEstibas(ByVal bahia As Entidades.Bahia, ByVal estado As Boolean)
        Dim objda As New Almacen.Datos.BahiasDA
        objda.ActivarDesactivarEstibas(bahia, estado)
    End Sub

    Public Function BuscarRutaImagen(ByVal idimagen As Int32) As String
        Dim objda As New Almacen.Datos.BahiasDA
        Return objda.BuscarRutaImagen(idimagen)
    End Function

    Public Function ObtenerCantidadParesEnBahia(ByVal idBahia As String) As Int32
        Dim objda As New Almacen.Datos.BahiasDA
        Return objda.ObtenerCantidadParesEnBahia(idBahia)
    End Function


    Public Function OcupacionMapa(ByVal Naveid As Int32, ByVal Almacenid As Int32, ByVal Bloque As String, ByVal Nivel As String) As List(Of Entidades.Bahia)
        Dim objda As New Almacen.Datos.BahiasDA
        Dim tabla As New DataTable
        tabla = objda.ObtenerPorcentajeUbicacion(Naveid, Almacenid, Bloque, Nivel)
        OcupacionMapa = New List(Of Entidades.Bahia)
        For Each row As DataRow In tabla.Rows
            Dim bahia As New Entidades.Bahia
            bahia.bahiaid = CStr(row("bahi_bahiaid"))
            bahia.bahia_nave = CInt(row("bahi_nave"))
            bahia.bahi_almacen = CStr(row("bahi_almacen"))
            bahia.bahi_bloque = CStr(row("bahi_bloque"))
            bahia.bahi_fila = CStr(row("bahi_fila"))
            bahia.bahi_segmento = CStr(row("bahi_segmento"))
            bahia.bahi_nivel = CStr(row("bahi_nivel"))
            If Not IsDBNull(row("bahi_capacidadenpares")) Then
                bahia.capacidadenpares = CInt(row("bahi_capacidadenpares"))
            End If
            If Not IsDBNull(row("bahi_referenciaubicacionid")) Then
                bahia.bahi_referenciaubicacionid = CInt(row("bahi_referenciaubicacionid"))
            End If

            If Not IsDBNull(row("bahi_porcentajeocupacion")) Then
                bahia.porcentajeocupacion = CInt(row("bahi_porcentajeocupacion"))

            End If

            If Not IsDBNull(row("bahi_paresactuales")) Then
                bahia.paresactuales = CInt(row("bahi_paresactuales"))
            End If

            'If Not IsDBNull(CStr(row("bahi_estiba"))) Then
            '    bahia.bahi_estiba = CStr(row("bahi_estiba"))
            'End If

            'Try
            '    bahia.bahi_estiba = CStr(row("bahi_estiba"))
            'Catch ex As Exception

            'End Try

            bahia.bahi_descripcion = CStr(row("bahi_descripcion"))
            bahia.bahi_color = CStr(row("bahi_color"))
            bahia.bahi_posicion = CStr(row("bahi_posicion"))
            ' bahia.bahi_capacidadenpares = CInt(row("bahi_capacidadenpares"))
            bahia.bahi_activo = CBool(row("bahi_activo"))
            bahia.bahi_usuariocreoid = CInt(row("bahi_usuariocreoid"))
            bahia.bahi_fechacreacion = CDate(row("bahi_fechacreacion"))

            Dim objbucl As New Datos.ClientesAlmacenDA
            Dim tablas As New DataTable
            tablas = objbucl.CargarClientesBahia(bahia.bahiaid)
            Dim ListaClientes As New List(Of Entidades.ClientesAlmacen)
            For Each renglon As DataRow In tablas.Rows
                Dim Cliente As New Entidades.ClientesAlmacen
                Cliente.Cadena = CInt(renglon("bacl_idcadena"))
                ListaClientes.Add(Cliente)
            Next
            bahia.ListaClientes = ListaClientes



            bahia.bahi_fechamodificacion = Today.Date.ToShortDateString

            OcupacionMapa.Add(bahia)
        Next


        Return OcupacionMapa
    End Function

    Public Function ImprimirEstibas(ByVal ListaEstibas As HashSet(Of Entidades.Bahia)) As DataTable
        Dim objda As New Datos.BahiasDA
        Dim tabla As New DataTable
        tabla = objda.ImprimirEstibas(ListaEstibas)
        Return tabla
    End Function


    Public Sub LimpiarParesBahia(ByVal Bahia As String)
        Dim objda As New Datos.BahiasDA
        objda.LimpiarParesBahia(Bahia)
    End Sub

End Class
