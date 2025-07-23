Imports Entidades
Imports Nomina.Negocios

Public Class PagoProveedorBU

    Public Function buscarProveedor(ByVal proveedorID As Integer) As Boolean

        Dim objDA As New Datos.PagoProveedorDA
        Dim tabla As New DataTable

        tabla = objDA.buscarProveedor(proveedorID)

        If CInt(tabla.Rows.Count) > 0 Then

            Return True

        Else

            Return False

        End If

    End Function

    Public Function buscarDatosProveedor(ByVal proveedorID As Integer) As DataTable

        Dim objDA As New Datos.PagoProveedorDA
        Dim tabla As New DataTable

        tabla = objDA.buscarProveedor(proveedorID)

        If CInt(tabla.Rows.Count) > 0 Then

            Return tabla

        Else

            Return Nothing

        End If

    End Function

    Public Function buscarCobrador(ByVal proveedorID As Integer, ByVal cobradorID As Integer) As Boolean
        Dim objDA As New Datos.PagoProveedorDA
        Dim tabla As New DataTable

        tabla = objDA.buscarCobrador(proveedorID, cobradorID)

        If CInt(tabla.Rows.Count) > 0 Then

            Return True

        Else

            Return False

        End If

    End Function

    Public Function buscarDatosCobrador(ByVal proveedorID As Integer, ByVal cobradorID As Integer) As DataTable
        Dim objDA As New Datos.PagoProveedorDA
        Dim tabla As New DataTable

        tabla = objDA.buscarCobrador(proveedorID, cobradorID)

        If CInt(tabla.Rows.Count) > 0 Then

            Return tabla

        Else

            Return Nothing

        End If

    End Function

    Public Function buscarPago(ByVal proveedorID As Integer) As Boolean
        Dim objDA As New Datos.PagoProveedorDA
        Dim tabla As New DataTable

        tabla = objDA.buscarPago(proveedorID)

        If CInt(tabla.Rows.Count) > 0 Then

            Return True

        Else

            Return False

        End If

    End Function

    Public Function buscarChecke(ByVal proveedorID As Integer) As Boolean
        Dim objDA As New Datos.PagoProveedorDA
        Dim tabla As New DataTable

        tabla = objDA.buscarChecke(proveedorID)

        If CInt(tabla.Rows.Count) > 0 Then

            Return True

        Else

            Return False

        End If

    End Function

    Public Sub insertarRegistroProveedor(ByVal proveedorID As Integer, ByVal cobradorID As Integer)
        Dim PagoProveedorDA As New Datos.PagoProveedorDA

        PagoProveedorDA.insertarRegistroProveedor(proveedorID, cobradorID)
    End Sub

End Class
