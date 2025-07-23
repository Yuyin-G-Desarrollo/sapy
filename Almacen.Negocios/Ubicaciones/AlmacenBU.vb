Imports System.Data
Imports Almacen.Datos

Public Class AlmacenBU


    Public Function Consulta__Carritos_Pendientes(ByVal codigo As String) As DataTable

        Dim objDA As New AlmacenDA
        Dim tabla As New DataTable
        tabla = objDA.Consulta__Carritos_Pendientes(codigo)

        Return tabla

    End Function

    Public Function Consulta_Carrito_Valido(ByVal codigo As String) As DataTable

        Dim objDA As New AlmacenDA
        Dim tabla As New DataTable
        tabla = objDA.Consulta_Carrito_Valido(codigo)

        Return tabla

    End Function

    Public Function Consulta_Estiba_Valido(ByVal codigo As String) As Boolean

        Dim objDA As New AlmacenDA
        Dim tabla As New DataTable
        tabla = objDA.Consulta_Estiba_Valido(codigo)

        If tabla.Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If

    End Function

    Public Function Consulta_Ocupacion_SinUbicar_Carrito(ByVal codigo As String) As Integer

        Dim objDA As New AlmacenDA
        Dim tabla As New DataTable
        tabla = objDA.Consulta_Ocupacion_SinUbicar_Carrito(codigo)

        If tabla.Rows.Count > 0 Then
            Return CInt(tabla.Rows(0).Item("occa_sinubicar"))
        Else
            Return 0
        End If

    End Function

    Public Function Consulta_Ocupacion_Ubicados_Carrito(ByVal codigo As String) As Integer

        Dim objDA As New AlmacenDA
        Dim tabla As New DataTable
        tabla = objDA.Consulta_Ocupacion_Ubicados_Carrito(codigo)

        If tabla.Rows.Count > 0 Then
            Return CInt(tabla.Rows(0).Item("occa_atadosubicados"))
        Else
            Return 0
        End If

    End Function


    Public Function Consulta_Atado_Valido(ByVal codigo As String, ByVal carrito_valido As Boolean) As Boolean
        Dim objDA As New AlmacenDA
        Dim tabla As New DataTable
        tabla = objDA.Consulta_Atado_Valido(codigo, carrito_valido)

        If tabla.Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If

    End Function

    Public Function Consulta_Atado_En_Ubicacion_Pares(ByVal codigo As String) As Boolean

        Dim objDA As New AlmacenDA
        Dim tabla As New DataTable
        tabla = objDA.Consulta_Atado_En_Ubicacion_Pares(codigo)

        If tabla.Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If

    End Function

    Public Function Consulta_Atado_tmpDocenasPares(ByVal codigo As String) As Boolean
        Dim objDA As New AlmacenDA
        Dim tabla As New DataTable
        tabla = objDA.Consulta_Atado_tmpDocenasPares(codigo)

        If tabla.Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If

    End Function

    Public Function Consulta_par_contenido_atado(ByVal codigo As String) As Boolean
        Dim objDA As New AlmacenDA
        Dim tabla As New DataTable
        tabla = objDA.Consulta_par_contenido_atado(codigo)

        If tabla.Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If

    End Function

    Public Function Consulta_Par_Valido(ByVal codigo As String) As Boolean
        Dim objDA As New AlmacenDA
        Dim tabla As New DataTable
        tabla = objDA.Consulta_Par_Valido(codigo)

        If tabla.Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If

    End Function

    Public Function Consulta_Par_tmpDocenasPares(ByVal codigo As String) As Boolean
        Dim objDA As New AlmacenDA
        Dim tabla As New DataTable
        tabla = objDA.Consulta_Par_tmpDocenasPares(codigo)

        If tabla.Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If

    End Function

    Public Function Consulta_Apartado_Valido(ByVal apartado As String) As Boolean
        Dim objDA As New AlmacenDA
        Dim tabla As New DataTable
        tabla = objDA.Consulta_Apartado_Valido(apartado)

        If CInt(tabla.Rows(0).Item(0)) > 0 Or CInt(tabla.Rows(0).Item(1)) > 0 Or CInt(tabla.Rows(0).Item(2)) > 0 Then
            Return True
        Else
            Return False
        End If

    End Function

    Public Function Consulta_Pares_en_Apartado(ByVal apartado As String) As DataTable
        Dim objDA As New AlmacenDA
        Dim tabla As New DataTable

        Return objDA.Consulta_Pares_en_Apartado(apartado)

    End Function

    Public Function Consulta_Ubicacion_Atado(ByVal codigo As String) As Boolean
        Dim objDA As New AlmacenDA
        Dim tabla As New DataTable
        tabla = objDA.Consulta_Ubicacion_Atado(codigo)

        If tabla.Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If

    End Function

    'Public Function Consulta_Atados_En_Ubicacion_Par(ByVal codigo As String) As Boolean
    '    Dim objDA As New AlmacenDA
    '    Dim tabla As New DataTable
    '    tabla = objDA.Consulta_Atados_En_Ubicacion_Par(codigo)

    '    If tabla.Rows.Count > 0 Then
    '        Return True
    '    Else
    '        Return False
    '    End If

    'End Function

    Public Function Consulta_Ubicacion_Par(ByVal codigo As String) As Boolean
        Dim objDA As New AlmacenDA
        Dim tabla As New DataTable
        tabla = objDA.Consulta_Ubicacion_Par(codigo)

        If tabla.Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If

    End Function


    Public Function Consulta_Par_Pertenece_Atado(ByVal codigo As String) As String
        Dim objDA As New AlmacenDA
        Dim tabla As New DataTable
        tabla = objDA.Consulta_Par_Pertenece_Atado(codigo)

        If tabla.Rows.Count > 0 Then
            Return CStr(tabla.Rows(0).Item("ubpa_codigoatado"))
        Else
            Return Nothing
        End If

    End Function

    Public Function Consulta_Bahia_Valido(ByVal codigo As String) As Boolean
        Dim objDA As New AlmacenDA
        Dim tabla As New DataTable
        tabla = objDA.Consulta_Bahia_Valido(codigo)

        If tabla.Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If

    End Function


    Public Sub alta_ubicacion_atado(ByVal estibaid As String, ByVal codigoatado As String,
                                    ByVal pares As Integer, ByVal lote As Integer,
                                    ByVal nave As Integer, ByVal colaboradorid As Integer,
                                    ByVal carritoid As Integer)

        Dim objDA As New AlmacenDA

        objDA.alta_ubicacion_atado(estibaid, codigoatado, pares, lote, nave, colaboradorid, carritoid)

    End Sub

    Public Sub editar_ubicacion_atado(ByVal estibaid As String, ByVal codigoatado As String,
                                    ByVal colaboradorid As Integer, ByVal carritoid As Integer)

        Dim objDA As New AlmacenDA

        objDA.editar_ubicacion_atado(estibaid, codigoatado, colaboradorid, carritoid)

    End Sub


    Public Sub alta_ubicacion_par(ByVal estibaid As String, ByVal codigoatado As String, ByVal lote As Integer, ByVal nave As Integer, ByVal colaboradorid As Integer)

        Dim objDA As New AlmacenDA

        objDA.alta_ubicacion_par(estibaid, codigoatado, lote, nave, colaboradorid)

    End Sub

    Public Sub editar_ubicacion_par(ByVal estibaid As String, ByVal codigoatado As String, ByVal colaboradorid As Integer)

        Dim objDA As New AlmacenDA

        objDA.editar_ubicacion_par(estibaid, codigoatado, colaboradorid)

    End Sub



    Public Sub Actualizar_FechaSalidaNave()
        Dim objDA As New AlmacenDA
        objDA.Actualizar_FechaSalidaNave()
    End Sub

    Public Sub Actualizar_GeneraUbicaciones()
        Dim objDA As New AlmacenDA
        objDA.Actualizar_GeneraUbicaciones()
    End Sub

    Public Sub Actualizar_ConvertirParesEnAtado()
        Dim objDA As New AlmacenDA
        objDA.Actualizar_ConvertirParesEnAtado()
    End Sub


    Public Sub InventarioDiarioSICY_Cierre(ByVal ComercializadoraID As Integer)

        Dim objDA As New AlmacenDA

        objDA.InventarioDiarioSICY_Cierre(ComercializadoraID)

    End Sub


    Public Function Consulta_Ocupacion_Plataforma_lista(colaboradorID As String, fechaInicio As String, fechaTermino As String) As DataTable

        Dim objDA As New AlmacenDA

        Return objDA.Consulta_Ocupacion_Plataforma_lista(colaboradorID, fechaInicio, fechaTermino)

    End Function

    Public Function Plataforma_completa_lista_para_validacion(ocupacion_carritoid As Integer) As Boolean

        Dim objDA As New AlmacenDA
        Dim tabla As New DataTable
        tabla = objDA.Plataforma_completa_lista_para_validacion(ocupacion_carritoid)

        If tabla.Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If

    End Function

    Public Sub Editar_Status_Plataforma(bandera As Integer, ocupacion_carritoid As Integer, status As Integer)

        Dim objDA As New AlmacenDA

        objDA.Editar_Status_Plataforma(bandera, ocupacion_carritoid, status)

    End Sub


    Public Function encabezado_Plataforma_Detalle_Plataforma(ocupacion_carritoID As Integer) As DataTable

        Dim objDA As New AlmacenDA

        Return objDA.encabezado_Plataforma_Detalle_Plataforma(ocupacion_carritoID)

    End Function

    Public Function Resumen_Plataforma_Atados_Cargados(ocupacion_carritoID As Integer) As DataTable
        Dim objDA As New AlmacenDA
        Return objDA.Resumen_Plataforma_Atados_Cargados(ocupacion_carritoID)
    End Function

    Public Function Resumen_Plataforma_Atados_Ubicados(ocupacion_carritoID As Integer) As DataTable
        Dim objDA As New AlmacenDA
        Return objDA.Resumen_Plataforma_Atados_Ubicados(ocupacion_carritoID)
    End Function

    Public Function Resumen_Plataforma_Atados_Pendientes(ocupacion_carritoID As Integer) As DataTable
        Dim objDA As New AlmacenDA
        Return objDA.Resumen_Plataforma_Atados_Pendientes(ocupacion_carritoID)
    End Function

    Public Function Resumen_Plataforma_Atados_Ubicados_Sin_Plataforma(ocupacion_carritoID As Integer) As DataTable
        Dim objDA As New AlmacenDA
        Return objDA.Resumen_Plataforma_Atados_Ubicados_Sin_Plataforma(ocupacion_carritoID)
    End Function

    Public Function Resumen_Plataforma_Atados_Con_Status_Diferente_A_1(ocupacion_carritoID As Integer) As DataTable
        Dim objDA As New AlmacenDA
        Return objDA.Resumen_Plataforma_Atados_Con_Status_Diferente_A_1(ocupacion_carritoID)
    End Function

    Public Function Detalle_Plataforma(ocupacion_carritoID As Integer) As DataTable
        Dim objDA As New AlmacenDA
        Return objDA.Detalle_Plataforma(ocupacion_carritoID)
    End Function

    Public Function ConsultaCentroDistribucionActivos() As DataTable
        Dim objDA As New AlmacenDA
        Return objDA.ConsultaCentroDistribucionActivos()
    End Function

    Public Function ConsultaCentroDistribucionActivosUsuario(ByVal UsuarioID As Integer) As DataTable
        Dim objDA As New AlmacenDA
        Return objDA.ConsultaCentroDistribucionActivosUsuario(UsuarioID)
    End Function

    Public Function ConsultaNumeroAlmacenes(ByVal NaveSAYID As Integer) As DataTable
        Dim objDA As New AlmacenDA
        Return objDA.ConsultaNumeroAlmacenes(NaveSAYID)
    End Function
    Public Function ConsultaDePlataformas(ByVal fechainicio As Date, ByVal fechafin As Date) As DataTable
        Dim objDA As New AlmacenDA
        Return objDA.ConsultaDePlataformas(fechainicio, fechafin)
    End Function

    Public Function ConsultaCentroDistribucionActivosUsuarioTipo(ByVal UsuarioID As Integer, ByVal tipo As Integer) As DataTable
        Dim objDA As New AlmacenDA
        Return objDA.ConsultaCentroDistribucionActivosUsuario_tipo(UsuarioID, tipo)
    End Function
End Class


