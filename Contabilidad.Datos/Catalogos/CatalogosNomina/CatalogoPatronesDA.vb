Imports System.Data.SqlClient

Public Class CatalogoPatronesDA

    Public Function ConsultarPatrones(ByVal nombre As String, ByVal rfc As String, ByVal nopatronal As String, ByVal activo As Boolean) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "nombre"
        parametro.Value = nombre
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "rfc"
        parametro.Value = rfc
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Npatronal"
        parametro.Value = nopatronal
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "activo"
        parametro.Value = activo
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Contabilidad].[Sp_Patrones_ConsultarPatrones]", listaParametros)

    End Function

    Public Function ConsultarEmpresas(ByVal activo As Boolean) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "activo"
        parametro.Value = activo
        listaParametros.Add(parametro)

        'Return objPersistencia.EjecutarConsultaSP("[Contabilidad].[Sp_Patrones_ConsultarEmpresas]", listaParametros)
        'Sp_Patrones_ListaEmpresas
        Return objPersistencia.EjecutarConsultaSP("[Contabilidad].[Sp_Patrones_ListaEmpresas]", listaParametros)

    End Function

    Public Function ConsultarCajas(ByVal activo As Boolean) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "activo"
        parametro.Value = activo
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Contabilidad].[Sp_Patrones_ConsultarCajas]", listaParametros)

    End Function

    Public Function ConsultarTipoColaborador(ByVal activo As Boolean) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "activo"
        parametro.Value = activo
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Contabilidad].[Sp_Patrones_ConsultarTipoColaborador]", listaParametros)

    End Function

    Public Function ConsultarTipoContrato(ByVal activo As Boolean) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "activo"
        parametro.Value = activo
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Contabilidad].[Sp_Patrones_ConsultarTipoContrato]", listaParametros)

    End Function

    Public Function ConsultarRiesgoPuesto(ByVal activo As Boolean) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "activo"
        parametro.Value = activo
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Contabilidad].[Sp_Patrones_ConsultarTipoRiesgoPuesto]", listaParametros)

    End Function

    Public Function ConsultarNaves(ByVal activo As Boolean) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "activo"
        parametro.Value = activo
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Contabilidad].[Sp_Patrones_ConsultarNaves]", listaParametros)

    End Function

    Public Function ConsultarPatronesGrupo(ByVal activo As Boolean) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "activo"
        parametro.Value = activo
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Contabilidad].[Sp_Patrones_ConsultarPatronesRelacionar]", listaParametros)

    End Function

    Public Function AltaEdicionPatron(ByVal objPatron As Entidades.Patron) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "PatronId"
        parametro.Value = objPatron.PPatronId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Nombre"
        parametro.Value = objPatron.PNombre
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "RFC"
        parametro.Value = objPatron.PRFC
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "NoPatronal"
        parametro.Value = objPatron.PNoPatronal
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Calle"
        parametro.Value = objPatron.PCalle
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Numero"
        parametro.Value = objPatron.PNumero
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Colonia"
        parametro.Value = objPatron.PColonia
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "CiudadId"
        parametro.Value = objPatron.PCiudadId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "CP"
        parametro.Value = objPatron.PCP
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Activo"
        parametro.Value = objPatron.PActivo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "EmpresaId"
        parametro.Value = objPatron.PEmpresaId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "NaveId"
        parametro.Value = objPatron.PNaveId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Checador"
        parametro.Value = objPatron.PChecador
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "TipoColaborador"
        parametro.Value = objPatron.PTipoColaborador
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "TipoContrato"
        parametro.Value = objPatron.PTipoContrato
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "RiesgoPuesto"
        parametro.Value = objPatron.PRiesgoPuesto
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "CajaChica"
        parametro.Value = objPatron.PCajaChica
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Comisiones"
        parametro.Value = objPatron.PComisiones
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "DescuentoInfonavit"
        parametro.Value = objPatron.PDescuentoInfonavit
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "PorcentajeAsistencia"
        parametro.Value = objPatron.PPorcentajeAsistencia
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "PorcentajePuntualidad"
        parametro.Value = objPatron.PPorcentajePuntualidad
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ClaveSeguridadSocial"
        parametro.Value = objPatron.PClaveSeguridadSocial
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ClaveRetiroCesantia"
        parametro.Value = objPatron.PClaveRetiroCesantia
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ClaveISR"
        parametro.Value = objPatron.PClaveISR
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ClaveInfonavit"
        parametro.Value = objPatron.PClaveInfonavit
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ClaveSPE"
        parametro.Value = objPatron.PClaveSPE
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ClaveISRAguinaldoVacaciones"
        parametro.Value = objPatron.PClaveISRAguinaldoVacaciones
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ClaveISRAnual"
        parametro.Value = objPatron.PClaveISRAnual
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ClaveSPEAnual"
        parametro.Value = objPatron.PClaveSPEAnual
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ClavePercepcionACargoAnual"
        parametro.Value = objPatron.PClavePercepcionACargoAnual
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ClaveComisiones"
        parametro.Value = objPatron.PClaveComisiones
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Agrupado"
        parametro.Value = objPatron.PAgrupado
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "PatronGrupo"
        parametro.Value = objPatron.PPatronGrupo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Usuario"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Contabilidad].[Sp_Patrones_AltaEdicionPatron]", listaParametros)

    End Function

    Public Function ConsultarPatronEditar(ByVal idPatron As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "PatronId"
        parametro.Value = idPatron
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Contabilidad].[Sp_Patrones_ConsultarPatronEditar]", listaParametros)

    End Function

    Public Function ExistePatron(ByVal RFC As String, ByVal nopatronal As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "RFC"
        parametro.Value = RFC
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "nopatronal"
        parametro.Value = nopatronal
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Contabilidad].[Sp_Patrones_ValidaExistePatron]", listaParametros)

    End Function

    Public Function AltaRutasFacturacion(ByVal EmpresaId As Integer, ByVal TipoComprobante As Integer, ByVal TipoDocumento As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "EmpresaId"
        parametro.Value = EmpresaId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "TipoComprobante"
        parametro.Value = TipoComprobante
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "TipoDocumento"
        parametro.Value = TipoDocumento
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Facturacion].[Sp_AltaRutasFacturacionEmpresa]", listaParametros)

    End Function

End Class
