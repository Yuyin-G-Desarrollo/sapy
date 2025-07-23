Imports System.Data.SqlClient

Public Class TablasTarifasDA

    Public Function consultaTarifas(ByVal tipo As String, ByVal activo As Boolean) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "Tipo"
        parametro.Value = tipo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Activo"
        parametro.Value = activo
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Contabilidad.SP_NFTablasyTarifas_Consultar", listaParametros)
    End Function

    Public Function consultaDatosTarifa(ByVal idTarifa As Integer) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "tarifaId"
        parametro.Value = idTarifa
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Contabilidad.SP_NFTablasyTarifas_ConsultarTarifa", listaParametros)
    End Function

    Public Function guardarTarifas(ByVal objTarifa As Entidades.TablasTarifas) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "TarifaId"
        If IsDBNull(objTarifa.PTarifaId) Then
            parametro.Value = 0
        Else
            parametro.Value = objTarifa.PTarifaId
        End If
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Tipo"
        parametro.Value = objTarifa.PTipo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "LimiteInferior"
        parametro.Value = objTarifa.PLimiteInferior
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "LimiteSuperior"
        parametro.Value = objTarifa.PLimiteSuperior
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "CuotaFija"
        parametro.Value = objTarifa.PCuotaFija
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Porcentaje"
        parametro.Value = objTarifa.PPorcentaje
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Usuario"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Contabilidad.SP_NFTablasyTarifas_Alta", listaParametros)
    End Function

    Public Function desactivarTarifa(ByVal idTarifa As Integer) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "tarifaId"
        parametro.Value = idTarifa
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Usuario"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Contabilidad.SP_NFTablasyTarifas_Desactivar", listaParametros)
    End Function

    Public Function existeRango(ByVal objTarifa As Entidades.TablasTarifas) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "TarifaId"
        If IsDBNull(objTarifa.PTarifaId) Then
            parametro.Value = 0
        Else
            parametro.Value = objTarifa.PTarifaId
        End If
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Tipo"
        parametro.Value = objTarifa.PTipo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "LimiteInferior"
        parametro.Value = objTarifa.PLimiteInferior
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "LimiteSuperior"
        parametro.Value = objTarifa.PLimiteSuperior
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Contabilidad.SP_TablasyTarifas_ValidaExiste", listaParametros)
    End Function

End Class
