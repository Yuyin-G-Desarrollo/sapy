Imports System.Data
Imports Contabilidad.Datos

Public Class PermisosUsuarioEmpresaBU

    Public Function Consulta_lista_Usuario_Contabilidad() As DataTable

        Dim objDA As New PermisosUsuarioEmpresaDA
        Return objDA.Consulta_lista_Usuario_Contabilidad()

    End Function

    Public Function lista_Permisos_Usuario_Empresa(userID As Integer) As DataTable

        Dim objDA As New PermisosUsuarioEmpresaDA
        Return objDA.lista_Permisos_Usuario_Empresa(userID)

    End Function

    Public Sub Permisos_Usuario_Empresa(bandera As Integer, userID As Integer, empresaID As Integer)

        Dim clientesDatosDA As New Datos.PermisosUsuarioEmpresaDA
        clientesDatosDA.Permisos_Usuario_Empresa(bandera, userID, empresaID)

    End Sub

End Class
