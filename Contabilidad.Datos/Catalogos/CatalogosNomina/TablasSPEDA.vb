Imports System.Data.SqlClient

Public Class TablasSPEDA
    Public Function consultarTablasSPE(ByVal tipo As String, ByVal activo As Boolean) As DataTable
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

        Return persistencia.EjecutarConsultaSP("Contabilidad.SP_NFTablasSPE_Consultar", listaParametros)

    End Function

    Public Function existeRango(ByVal objTarifa As Entidades.TablasSPE) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "TablaId"
        If IsDBNull(objTarifa.PTablaId) Then
            parametro.Value = 0
        Else
            parametro.Value = objTarifa.PTablaId
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

        Return persistencia.EjecutarConsultaSP("Contabilidad.SP_NFTablasSPE_ValidaExiste", listaParametros)
    End Function

    Public Function guardarTablaSPE(ByVal objTarifa As Entidades.TablasSPE) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "TablaId"
        If IsDBNull(objTarifa.PTablaId) Then
            parametro.Value = 0
        Else
            parametro.Value = objTarifa.PTablaId
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
        parametro.ParameterName = "Subsidio"
        parametro.Value = objTarifa.PSPEMensual
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Usuario"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Contabilidad.SP_NFTablasSPE_Alta", listaParametros)
    End Function

    Public Function consultaDatosSubsidio(ByVal idSubsidio As Integer) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "SubsidioId"
        parametro.Value = idSubsidio
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Contabilidad.SP_NFTablasSPE_ConsultarSubsidio", listaParametros)
    End Function

    Public Function desactivarSubsidio(ByVal idSubsidio As Integer) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "SubsidioId"
        parametro.Value = idSubsidio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Usuario"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Contabilidad.SP_NFTablasSPE_Desactivar", listaParametros)
    End Function

End Class
