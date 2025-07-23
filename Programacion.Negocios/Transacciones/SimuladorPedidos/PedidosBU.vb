Imports Programacion.Datos

Public Class PedidosBU
    Public Function ObtenerAvisos() As DataTable
        Dim vPedidosDA As New PedidosDA
        Return vPedidosDA.ObtenerAvisos
    End Function

    Public Function TablaUsuarioAviso(avisID As Int32) As DataTable
        Dim vPedidosDA As New PedidosDA
        Return vPedidosDA.TablaUsuarioAviso(avisID)
    End Function
    Public Sub AgregarHoraAviso(Hora As String)
        Dim vPedidosDA As New PedidosDA
        vPedidosDA.AgregarHoraAviso(Hora)
    End Sub
    Public Sub EliminarHoraAviso(id As Int32)
        Dim vPedidosDA As New PedidosDA
        vPedidosDA.EliminarHoraAviso(id)
    End Sub
    Public Sub AgregarUsuarioAviso(usuarioID As Int32, avisID As Int32)
        Dim vPedidosDA As New PedidosDA
        vPedidosDA.AgregarUsuarioAviso(usuarioID, avisID)
    End Sub
    Public Sub EliminarUsuarioAviso(ausuID As Int32)
        Dim vPedidosDA As New PedidosDA
        vPedidosDA.EliminarUsuarioAviso(ausuID)
    End Sub
    Public Function VerificarUsuarioAviso(usuarioId As Int32) As Boolean
        Dim vPedidosDA As New PedidosDA
        Dim cuenta As DataTable = vPedidosDA.VerificarUsuarioAviso(usuarioId)
        If cuenta.Rows.Count > 0 Then
            Return False
        Else
            Return True
        End If
    End Function
    Public Function VerificarHoraAviso(hora As String) As Boolean
        Dim vPedidosDA As New PedidosDA
        Dim cuenta As DataTable = vPedidosDA.VerificarHoraAviso(hora)
        If cuenta.Rows.Count > 0 Then
            Return False
        Else
            Return True
        End If
    End Function
    Public Sub ModificarHoraAviso(id As Int32, hora As String)
        Dim vPedidosDA As New PedidosDA
        vPedidosDA.ModificarHoraAviso(id, hora)
    End Sub
End Class
