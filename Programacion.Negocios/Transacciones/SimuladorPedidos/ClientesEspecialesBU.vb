Imports Programacion.Datos

Public Class ClientesEspecialesBU

    Public Function TablaCombo() As DataTable
        Dim vClientesespeciales As New ClientesEspecialesDA
        Return vClientesespeciales.TablaCombo
    End Function

    Public Function Tabla() As DataTable
        Dim vClientesespeciales As New ClientesEspecialesDA
        Return vClientesespeciales.Tabla
    End Function

    Public Sub Agregar(idCadena As Int32, orden As Int32)
        Dim vClientesespeciales As New ClientesEspecialesDA
        vClientesespeciales.Agregar(idCadena, orden)
    End Sub

    Public Sub Eliminar(cesp_cespID As Int32)
        Dim vClientesespeciales As New ClientesEspecialesDA
        vClientesespeciales.Eliminar(cesp_cespID)
    End Sub

    Public Sub Actualizar(ByVal id_ As Integer, ByVal cesp_cespId As Integer)
        Dim vClientesespeciales As New ClientesEspecialesDA
        vClientesespeciales.Actualizar(id_, cesp_cespId)
    End Sub

    Public Function datosClietesEspecialesNoConfiguradosSimulacion(ByVal idSimulacion As Int32) As DataTable
        Dim objDA As New Datos.ClientesEspecialesDA
        Return objDA.datosClietesEspecialesNoConfiguradosSimulacion(idSimulacion)
    End Function

    Public Function datosClientesEspecialesConfiguradosSimulacion(ByVal idSimulacion As Int32) As DataTable
        Dim objDA As New Datos.ClientesEspecialesDA
        Return objDA.datosClientesEspecialesConfiguradosSimulacion(idSimulacion)
    End Function

    Public Sub insertarClienteEspecialSimulacion(ByVal idSimulacion As Int32, ByVal idCadema As String, ByVal orden As Int32)
        Dim objDA As New Datos.ClientesEspecialesDA
        objDA.insertarClienteEspecialSimulacion(idSimulacion, idCadema, orden)
    End Sub

    Public Sub eliminarSimulacionClienteEspecial(ByVal idClienteEspecialSim As Int32)
        Dim objDA As New Datos.ClientesEspecialesDA
        objDA.eliminarSimulacionClienteEspecial(idClienteEspecialSim)
    End Sub

    Public Sub editarOrdenClienteEspecialSim(ByVal orden As Int32, ByVal idClienteEspecialSim As Int32)
        Dim objDA As New Datos.ClientesEspecialesDA
        objDA.editarOrdenClienteEspecialSim(orden, idClienteEspecialSim)
    End Sub

End Class
