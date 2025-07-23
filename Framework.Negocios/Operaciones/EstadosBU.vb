Public Class EstadosBU


    Public Function ListaEstados(ByVal nombre As String, ByVal activo As Boolean, ByVal paisid As Int32) As List(Of Entidades.Estados)
        Dim objPDA As New Datos.EstadosDA
        Dim tabla As New DataTable

        ListaEstados = New List(Of Entidades.Estados)
        tabla = objPDA.ListaEstados(nombre, activo, paisid)
        For Each fila As DataRow In tabla.Rows
            Dim Estados As New Entidades.Estados
            Estados.ENombre = CStr(fila("esta_nombre"))
            Estados.EActivo = CBool(fila("pais_activo"))
            Estados.EIDPais = CInt(fila("pais_paisid"))
            Estados.EIDDEstado = CInt(fila("esta_estadoid"))
            ListaEstados.Add(Estados)
        Next


    End Function

    Public Sub guardarEstado(ByVal Estado As Entidades.Estados, ByVal Pais As Entidades.Paises)
        Dim objEstado As New Datos.EstadosDA
        objEstado.AltaEstado(Estado, Pais)

    End Sub

    Public Sub editarRegistro(ByRef Estado As Entidades.Estados, ByVal Pais As Entidades.Paises)
        Dim objEstado As New Datos.EstadosDA
        objEstado.EditarEstado(Estado, Pais)
    End Sub


    Public Function buscarEstado(ByVal estadoidselect As Int32) As Entidades.Estados

        Dim objEstadoDA As New Datos.EstadosDA
        Dim estado As New Entidades.Estados
        Dim tablaestado As New DataTable
        tablaestado = objEstadoDA.buscarEstado(estadoidselect)

        For Each fila As DataRow In tablaestado.Rows
            estado.ENombre = CStr(fila("esta_nombre"))
            estado.EActivo = CBool(fila("esta_activo"))
            estado.EIDPais = CInt(fila("esta_estadoid"))

        Next

        Return estado
    End Function

    Public Function ListaEstadosPais(ByVal nombre As String, ByVal activo As Boolean, ByVal paisid As Int32) As List(Of Entidades.Estados)
        Dim objPDA As New Datos.EstadosDA
        Dim tabla As New DataTable

        ListaEstadosPais = New List(Of Entidades.Estados)
        tabla = objPDA.ListaEstadosPais(nombre, activo, paisid)
        For Each fila As DataRow In tabla.Rows
            Dim Estados As New Entidades.Estados
            Estados.ENombre = CStr(fila("esta_nombre"))
            Estados.EIDDEstado = CInt(fila("esta_estadoid"))
            ListaEstadosPais.Add(Estados)
        Next


    End Function

End Class
