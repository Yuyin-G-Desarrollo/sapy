Imports Framework.Datos
Public Class PaisesBU

    Public Function ListaPaises(ByVal nombre As String, ByVal activo As Boolean) As List(Of Entidades.Paises)
        Dim objPDA As New Datos.PaisesDA
        Dim tabla As New DataTable

        ListaPaises = New List(Of Entidades.Paises)
        tabla = objPDA.ListaPaises(nombre, activo)
        For Each fila As DataRow In tabla.Rows
            Dim Pais As New Entidades.Paises
            Pais.PNombre = CStr(fila("pais_nombre"))
            Pais.PActivo = CBool(fila("pais_activo"))
            Pais.PIDPais = CInt(fila("pais_paisid"))
            ListaPaises.Add(Pais)
        Next


    End Function

  


    Public Sub guardarPais(ByVal Pais As Entidades.Paises)
        Dim objPais As New PaisesDA
        objPais.AltaPais(Pais)
    End Sub

    Public Sub EditarPais(ByVal Pais As Entidades.Paises)
        Dim ObjEditarPais As New PaisesDA

        ObjEditarPais.EditarPais(Pais)
    End Sub

    Public Function buscarPais(ByVal paisidselect As Int32) As Entidades.Paises

        Dim objPaisDA As New Datos.PaisesDA
        Dim pais As New Entidades.Paises
        Dim tablapais As New DataTable
        tablapais = objPaisDA.buscarPais(paisidselect)

        For Each fila As DataRow In tablapais.Rows
            pais.PNombre = CStr(fila("pais_nombre"))
            pais.PActivo = CBool(fila("pais_activo"))
            pais.PIDPais = CInt(fila("pais_paisid"))

        Next

        Return pais
    End Function

    Public Function ListaPaisesMayusculas() As List(Of Entidades.Paises)
        Dim objPDA As New Datos.PaisesDA
        Dim tabla As New DataTable

        ListaPaisesMayusculas = New List(Of Entidades.Paises)
        tabla = objPDA.ListaPaisesMayusculas()
        For Each fila As DataRow In tabla.Rows
            Dim Pais As New Entidades.Paises
            Pais.PNombre = CStr(fila("pais_nombre"))
            Pais.PIDPais = CInt(fila("pais_paisid"))
            ListaPaisesMayusculas.Add(Pais)
        Next


    End Function

End Class
