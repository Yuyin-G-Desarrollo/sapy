Imports Framework.Datos

Public Class CiudadesBU
    ''comentario
    Public Function listaCiudadesActivas(ByVal estadoID As Integer) As DataTable
        Dim objDA As New Datos.CiudadesDA
        Return objDA.listaCiudadesActivas(estadoID)
    End Function

    Public Function listaCiudadesActivasMayusculas(ByVal estadoID As Integer) As DataTable
        Dim objDA As New Datos.CiudadesDA
        Return objDA.listaCiudadesActivasMayusculas(estadoID)
    End Function

    Public Function ListaCiudades(ByVal nombre As String, ByVal activo As Boolean, ByVal idestado As Int32, ByVal idpais As Int32) As List(Of Entidades.Ciudades)
        Dim objPDA As New Datos.CiudadesDA
        Dim tabla As New DataTable

        ListaCiudades = New List(Of Entidades.Ciudades)
        tabla = objPDA.ListaCiudades(nombre, activo, idestado, idpais)
        For Each fila As DataRow In tabla.Rows
            Dim Ciudad As New Entidades.Ciudades
            Ciudad.CNombre = CStr(fila("city_nombre"))
            Ciudad.CActivo = CBool(fila("city_activo"))
            Ciudad.CciudadId = CInt(fila("city_ciudadid"))


            Dim estado As New Entidades.Estados
            estado.EIDDEstado = CInt(fila("esta_estadoid"))
            estado.ENombre = CStr(fila("esta_nombre"))

            Dim pais As New Entidades.Paises
            pais.PIDPais = CInt(fila("pais_paisid"))
            pais.PNombre = CStr(fila("pais_nombre"))

            estado.PPais = pais
            Ciudad.CIDEstado = estado
            Ciudad.CNombreEstado = estado
            Ciudad.CIDPais = estado
            ListaCiudades.Add(Ciudad)
        Next
    End Function

    Public Sub guardarCiudad(ByVal ciudad As Entidades.Ciudades)
        Dim objCiudad As New CiudadesDA
        objCiudad.AltaCiudad(ciudad)
    End Sub

    Public Sub EditarCiudad(ByVal Ciudad As Entidades.Ciudades, ByVal Estado As Entidades.Estados)
        Dim objCiudades As New CiudadesDA
        objCiudades.EditarCiudad(Ciudad, Estado)
    End Sub
End Class
