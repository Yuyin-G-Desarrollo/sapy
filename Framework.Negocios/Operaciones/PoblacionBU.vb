Public Class PoblacionBU

    Public Function listaPoblacion(ByVal ciudadID As Integer) As DataTable
        Dim objDA As New Datos.PoblacionDA
        Return objDA.ListaPoblacion(ciudadID)
    End Function

    Public Function ConsultarPoblaciones(ByVal PaisID As Int32, ByVal EstadoID As Int32, ByVal CiudadID As Int32, ByVal Nombre As String, ByVal Activo As Boolean) As List(Of Entidades.Poblacion)
        Dim OBJDA As New Datos.PoblacionDA
        Dim tabla As New DataTable
        ConsultarPoblaciones = New List(Of Entidades.Poblacion)
        tabla = OBJDA.ConsultaPoblaciones(PaisID, EstadoID, CiudadID, Nombre, Activo)
        For Each row As DataRow In tabla.Rows
            Dim Poblacion As New Entidades.Poblacion
            Dim Ciudad As New Entidades.Ciudades
            Dim Pais As New Entidades.Paises
            Dim Estado As New Entidades.Estados
            Ciudad.CNombre = CStr(row("city_nombre"))
            Pais.PNombre = CStr(row("pais_nombre"))
            Pais.PIDPais = CInt(row("pais_paisid"))
            Estado.ENombre = CStr(row("esta_nombre"))
            Estado.EIDDEstado = CInt(row("esta_estadoid"))
            Ciudad.CciudadId = CInt(row("city_ciudadid"))
            Ciudad.CIDEstado = Estado
            Ciudad.CNombrePais = Pais

            Poblacion.poblacionid = CInt(row("pobl_poblacionid"))
            Poblacion.nombre = CStr(row("pobl_nombre"))
            Poblacion.ciudad = Ciudad
            ConsultarPoblaciones.Add(Poblacion)
        Next

        Return ConsultarPoblaciones
    End Function


    Public Sub AltaPoblaciones(ByVal Entidad As Entidades.Mensajeria)
        Dim OBJDA As New Datos.PoblacionDA
        OBJDA.AltaPoblaciones(Entidad)
    End Sub


    Public Sub EditarPoblaciones(ByVal Entidad As Entidades.Mensajeria)
        Dim OBJDA As New Datos.PoblacionDA
        OBJDA.EditarPoblaciones(Entidad)
    End Sub

End Class
