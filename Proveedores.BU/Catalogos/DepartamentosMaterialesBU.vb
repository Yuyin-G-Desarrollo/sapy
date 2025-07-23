Imports Proveedores.DA
Public Class DepartamentosMaterialesBU
    Public Function getDepartamentosMateriales(ByVal id As Integer) As DataTable
        Dim obj As New DepartamentosMaterialesDA
        Return obj.getDepartamentosMateriales(id)
    End Function
    Public Function updateDepartamentosMateriales(ByVal idDep As Integer, ByVal idNave As Integer, ByVal nombre As String, ByVal status As String) As DataTable
        Dim obj As New DepartamentosMaterialesDA
        Return obj.updateDepartamentosMateriales(idDep, idNave, nombre, status)
    End Function
    Public Function insertDepartamentosMateriales(ByVal idNave As Integer, ByVal departamento As String) As DataTable
        Dim obj As New DepartamentosMaterialesDA
        Return obj.insertDepartamentosMateriales(idNave, departamento)
    End Function
    Public Function ListaNavesSegunUsuario() As DataTable
        Dim obj As New DepartamentosMaterialesDA
        Return obj.ListaNavesSegunUsuario()
    End Function
    Public Function validarNombreDepartamento(ByVal idNave As Integer, ByVal departamento As String) As DataTable
        Dim obj As New DepartamentosMaterialesDA
        Return obj.validarNombreDepartamento(idNave, departamento)
    End Function
    Public Function validarNombreDepartamentoEditado(ByVal idNave As Integer, ByVal departamento As String, ByVal idDepto As Integer) As DataTable
        Dim obj As New DepartamentosMaterialesDA
        Return obj.validarNombreDepartamentoEditado(idNave, departamento, idDepto)
    End Function
End Class
