Imports System.Data.SqlClient

Public Class ColaboradoresContabilidadDA

    Public Function consultaListadoColaboradores(ByVal idPatron As Int32, ByVal activo As Int32, ByVal nombre As String) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "patronId"
        parametro.Value = idPatron
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "activo"
        parametro.Value = activo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "nombre"
        parametro.Value = nombre
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Contabilidad.SP_NFaltaIMSS_ConsultaColaboradoresConta", listaParametros)
    End Function

    Public Function insertaColaboradorExterno(ByVal colaborador As Entidades.ColaboradorExterno) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "curp"
        parametro.Value = colaborador.PCurp
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "rfc"
        parametro.Value = colaborador.PRfc
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fechaNacimiento"
        parametro.Value = colaborador.PFechaNacimiento
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "apellidoPaterno"
        parametro.Value = colaborador.PAPaterno
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "apellidoMaterno"
        parametro.Value = colaborador.PAMaterno
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "nombre"
        parametro.Value = colaborador.PNombre
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "domicilio"
        parametro.Value = colaborador.PCalle
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "domicilioNumero"
        parametro.Value = colaborador.PDomicilioNumero
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "domicilioColonia"
        parametro.Value = colaborador.PColonia
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "codigoPostal"
        parametro.Value = colaborador.PCP
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "sexo"
        parametro.Value = colaborador.PSexo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "lugarNacimientoId"
        parametro.Value = colaborador.PIdCiudadOrigen
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "entreCalles"
        parametro.Value = colaborador.PEntreCalles
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "domicilioReferencia"
        parametro.Value = colaborador.PReferencia
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "usuariocreoid"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)
       
        parametro = New SqlParameter
        parametro.ParameterName = "idNave"
        parametro.Value = colaborador.PidNave
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idPatron"
        parametro.Value = colaborador.PIdPatron
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idPuestoFiscal"
        parametro.Value = colaborador.PIdPuesto
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "sdi"
        parametro.Value = colaborador.PSDI
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idPuestoReal"
        parametro.Value = colaborador.PIdPuestoReal
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idDeptoFiscal"
        parametro.Value = colaborador.PIdDeptoFiscal
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idDeptoReal"
        parametro.Value = colaborador.PIdDeptoReal
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "nss"
        parametro.Value = colaborador.PNSS
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "observaciones"
        parametro.Value = colaborador.PObservaciones
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "obra"
        parametro.Value = colaborador.PObra
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ganaComision"
        parametro.Value = colaborador.PGanaComision
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "montoComision"
        parametro.Value = colaborador.PMontoComision
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Contabilidad.SP_NFaltaIMSS_InsertaColaboradorFiscal", listaParametros)
    End Function

    Public Function consultaDatosColaborador(ByVal idColaborador As Int32) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "idColaborador"
        parametro.Value = idColaborador
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Contabilidad.SP_NFaltaIMSS_ConsultaDatosColaborador", listaParametros)
    End Function

    Public Function editarColaboradorExterno(ByVal colaborador As Entidades.ColaboradorExterno) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "curp"
        parametro.Value = colaborador.PCurp
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "rfc"
        parametro.Value = colaborador.PRfc
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fechaNacimiento"
        parametro.Value = colaborador.PFechaNacimiento
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "apellidoPaterno"
        parametro.Value = colaborador.PAPaterno
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "apellidoMaterno"
        parametro.Value = colaborador.PAMaterno
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "nombre"
        parametro.Value = colaborador.PNombre
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "domicilio"
        parametro.Value = colaborador.PCalle
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "domicilioNumero"
        parametro.Value = colaborador.PDomicilioNumero
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "domicilioColonia"
        parametro.Value = colaborador.PColonia
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "codigoPostal"
        parametro.Value = colaborador.PCP
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "sexo"
        parametro.Value = colaborador.PSexo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "lugarNacimientoId"
        parametro.Value = colaborador.PIdCiudadOrigen
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "entreCalles"
        parametro.Value = colaborador.PEntreCalles
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "domicilioReferencia"
        parametro.Value = colaborador.PReferencia
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "usuarioid"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idColaborador"
        parametro.Value = colaborador.PIdColaborador
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idPuestoFiscal"
        parametro.Value = colaborador.PIdPuesto
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "sdi"
        parametro.Value = colaborador.PSDI
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idPuestoReal"
        parametro.Value = colaborador.PIdPuestoReal
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idDeptoFiscal"
        parametro.Value = colaborador.PIdDeptoFiscal
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idDeptoReal"
        parametro.Value = colaborador.PIdDeptoReal
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "nss"
        parametro.Value = colaborador.PNSS
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "observaciones"
        parametro.Value = colaborador.PObservaciones
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "obra"
        parametro.Value = colaborador.PObra
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ganaComision"
        parametro.Value = colaborador.PGanaComision
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "montoComision"
        parametro.Value = colaborador.PMontoComision
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Contabilidad.SP_NFaltaIMSS_EditarColaboradorFiscal", listaParametros)
    End Function

    Public Function consultaListadoExpedienteColaborador(ByVal idColaborador As Int32) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "idColaborador"
        parametro.Value = idColaborador
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Contabilidad.SP_NFaltaIMSS_ConsultaExpedienteColaborador", listaParametros)
    End Function

    Public Sub actualizarArchivoExpediente(ByVal idColaborador As Int32, ByVal idExpediente As Int32, ByVal nombreArchivo As String,
                                           ByVal idUsuario As Int32)
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "idExpediente"
        parametro.Value = idExpediente
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idColaborador"
        parametro.Value = idColaborador
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "nombre"
        parametro.Value = nombreArchivo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idUsuario"
        parametro.Value = idUsuario
        listaParametros.Add(parametro)

        persistencia.EjecutarSentenciaSP("Contabilidad.SP_NFaltaIMSS_ActualizarArchivoExpediente", listaParametros)
    End Sub

    Public Function consultaColaboradoresParaALtaImss(ByVal idNave As Int32, ByVal nombre As String) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "naveId"
        parametro.Value = idNave
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "nombre"
        parametro.Value = nombre
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Contabilidad.SP_NFaltaIMSS_ConsultaColaboradoresParaAlta", listaParametros)
    End Function

    Public Function obtenerFechaAlta(ByVal idPatron As Int32) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "patronid"
        parametro.Value = idPatron
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Contabilidad.SP_NFaltaIMSS_ObtenerFechaAltaImss", listaParametros)
    End Function

    Public Function consultaDatosComplementariosIMSS(ByVal idColaborador As Int32) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "idColaborador"
        parametro.Value = idColaborador
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Contabilidad.SP_NFaltaIMSS_ConsultaComplementaIMSS", listaParametros)
    End Function

    Public Function insertaAltaImss(ByVal colaboradorImss As Entidades.AltaColaboradorIMSS, ByVal usuarioCreo As Int32) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "idPatron"
        parametro.Value = colaboradorImss.PPAtronId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idColaborador"
        parametro.Value = colaboradorImss.PColaboradorId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idPeriodoNomina"
        parametro.Value = colaboradorImss.PPeriodoNominaID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fechaAlta"
        parametro.Value = colaboradorImss.PFechaAlta
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "tieneCredito"
        parametro.Value = colaboradorImss.PTieneCredito
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "sdi"
        parametro.Value = colaboradorImss.PSDI
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idTipoTrabajador"
        parametro.Value = colaboradorImss.PTipoTrabajadorId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idTipoSalario"
        parametro.Value = colaboradorImss.PTipoSalarioId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idTipoJornada"
        parametro.Value = colaboradorImss.PTipoJornadaID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "umf"
        parametro.Value = colaboradorImss.PUMF
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idDeptoFiscal"
        parametro.Value = colaboradorImss.PDepartamentoFiscalId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idPuestoFiscal"
        parametro.Value = colaboradorImss.PPuestoFiscalId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "usuariocreoid"
        parametro.Value = usuarioCreo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idNave"
        parametro.Value = colaboradorImss.PIdNave
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Contabilidad.SP_NFaltaIMSS_InsertaAltaIMSS", listaParametros)
    End Function

    Public Function consultaAltasImssPorAutorizar(ByVal idNave As Int32, ByVal idEstatus As Int32, ByVal nombre As String) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "naveId"
        parametro.Value = idNave
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "estatusId"
        parametro.Value = idEstatus
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "nombre"
        parametro.Value = nombre
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Contabilidad.SP_NFaltaIMSS_AltasIMSSPorAutorizar", listaParametros)
    End Function

    Public Function consultaInformacionParaEditarImss(ByVal idAlta As Int32) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "idAlta"
        parametro.Value = idAlta
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Contabilidad.SP_NFaltaIMSS_ConsultaDatosEditarAltaIMSS", listaParametros)
    End Function

    Public Function editarAltaImss(ByVal idColaborador As Int32, ByVal idAlta As Int32, ByVal colaboradorImss As Entidades.AltaColaboradorIMSS, ByVal idUsuario As Int32) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "idAlta"
        parametro.Value = idAlta
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idColaborador"
        parametro.Value = idColaborador
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fechaAlta"
        parametro.Value = colaboradorImss.PFechaAlta
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "sdi"
        parametro.Value = colaboradorImss.PSDI
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idTipoTrabajador"
        parametro.Value = colaboradorImss.PTipoTrabajadorId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idTipoSalario"
        parametro.Value = colaboradorImss.PTipoSalarioId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idTipoJornada"
        parametro.Value = colaboradorImss.PTipoJornadaID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "umf"
        parametro.Value = colaboradorImss.PUMF
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "usuariomodificoid"
        parametro.Value = idUsuario
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Contabilidad.SP_NFaltaIMSS_EditarAltaIMSS", listaParametros)
    End Function

    Public Function autorizarAltaImss(ByVal idColaborador As Int32, ByVal idAlta As Int32, ByVal idUsuario As Int32) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "idAlta"
        parametro.Value = idAlta
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idColaborador"
        parametro.Value = idColaborador
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "usuarioautorizoid"
        parametro.Value = idUsuario
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Contabilidad.SP_NFaltaIMSS_AutorizarAltaIMSS", listaParametros)
    End Function

    Public Function rechazarAltaImss(ByVal idColaborador As Int32, ByVal idAlta As Int32, ByVal motivo As String, ByVal idUsuario As Int32) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "idAlta"
        parametro.Value = idAlta
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idColaborador"
        parametro.Value = idColaborador
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "motivo"
        parametro.Value = motivo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "usuariorechazoid"
        parametro.Value = idUsuario
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Contabilidad.SP_NFaltaIMSS_RechazarAltaIMSS", listaParametros)
    End Function

    Public Function consultaGeneracionAltasIMSS(ByVal patronid As Int32, ByVal estatusId As Int32, ByVal nombre As String) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "patronId"
        parametro.Value = patronid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "estatusId"
        parametro.Value = estatusId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "nombre"
        parametro.Value = nombre
        listaParametros.Add(parametro)


        Return persistencia.EjecutarConsultaSP("Contabilidad.SP_NFaltaIMSS_ConsultaGeneracionAltasIMSS", listaParametros)
    End Function

    Public Function consultaInformacionIdse(ByVal idAlta As Int32) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "altaImssId"
        parametro.Value = idAlta
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Contabilidad.SP_NFAltaIMSS_ConsultarInformacionIDSE", listaParametros)
    End Function

    Public Function aceptarRechazarIdseAltaImss(ByVal idAlta As Int32, ByVal idColaborador As Int32, ByVal carpeta As String,
                                                ByVal archivo As String, ByVal movimiento As String, ByVal motivo As String) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "idAlta"
        parametro.Value = idAlta
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idColaborador"
        parametro.Value = idColaborador
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "carpeta"
        parametro.Value = carpeta
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "archivo"
        parametro.Value = archivo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "movimiento"
        parametro.Value = movimiento
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "usuarioid"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "motivo"
        parametro.Value = motivo
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Contabilidad.SP_NFaltaIMSS_AceptarRechazarAltaImssIDSE", listaParametros)
    End Function

    Public Function consultaDestinatariosAltaIMSS(ByVal idAlta As Int32) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "idAlta"
        parametro.Value = idAlta
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Contabilidad.SP_NFaltaIMSS_ConsultaDatosCorreo", listaParametros)
    End Function

    Public Function regresarSolicitudesImss(ByVal idAlta As Int32, ByVal motivo As String) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "idAlta"
        parametro.Value = idAlta
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "motivoRegreso"
        parametro.Value = motivo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "usuarioRegresoid"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Contabilidad.SP_NFaltaIMSS_RegresarAltaIMSS", listaParametros)

    End Function

    Public Function actualizarDescuentoISR(ByVal idColaborador As Int32, descuento As Double, ByVal imssDiario As Double, ByVal imssSemanal As Double,
                                           ByVal spe As Boolean) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "idColaborador"
        parametro.Value = idColaborador
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "descuento"
        parametro.Value = descuento
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "descuentoImssSemanal"
        parametro.Value = imssDiario
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "descuentoImssDiario"
        parametro.Value = imssSemanal
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "spe"
        parametro.Value = spe
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Contabilidad.SP_NFaltaIMSS_ActualizarDescuentoISR", listaParametros)
    End Function

    Public Function validaSDIMinimo(ByVal colaboradorId As Int32) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "colaboradorId"
        parametro.Value = colaboradorId
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Contabilidad.SP_NFaltaIMSS_ValidaSDIMinimo", listaParametros)
    End Function

    Public Function validaColaboradorExistente(ByVal curp As String, ByVal rfc As String, ByVal nss As String) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "curp"
        parametro.Value = curp
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "rfc"
        parametro.Value = rfc
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "nss"
        parametro.Value = nss
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Contabilidad.SP_NFaltaIMSS_ValidaColaboradorExistente", listaParametros)
    End Function

    Public Function ActualizaInfonavitALtaImss(ByVal idInfonavit As Int32, ByVal idAlta As Int32) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "idAlta"
        parametro.Value = idAlta
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idInfonavit"
        parametro.Value = idInfonavit
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Contabilidad.SP_NFaltaIMSS_ActualizaAltaInfonavit", listaParametros)
    End Function

    Public Function tipoMovimientoSMDInfonavit() As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = String.Empty

        consulta = "EXEC Contabilidad.SP_NFAltaImss_TipoMovimientosInfonavit"

        Return persistencia.EjecutaConsulta(consulta)
    End Function

    Public Function actualizaExpedienteCartaManifiesto(ByVal idColaborador As Int32, ByVal idAlta As Int32, ByVal tituloMovimiento As String, ByVal carpeta As String,
                                                       ByVal archivo As String) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "colaboradorid"
        parametro.Value = idColaborador
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idAlta"
        parametro.Value = idAlta
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "tituloMovimiento"
        parametro.Value = tituloMovimiento
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "carpeta"
        parametro.Value = carpeta
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "archivo"
        parametro.Value = archivo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "usuarioId"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Contabilidad.SP_NFaltaIMSS_ExpedienteCartaManifiesto", listaParametros)
    End Function

    Public Function validarEstatus(ByVal altaId As Integer, ByVal opcEstatus As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "altaId"
        parametro.Value = altaId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "opcEstatus"
        parametro.Value = opcEstatus
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Contabilidad.SP_NFaltaIMSS_ValidarEstatus", listaParametros)
    End Function

    Public Function validaSolicitudBaja(ByVal idColaborador As Int32) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "idColaborador"
        parametro.Value = idColaborador
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Contabilidad.SP_NF_CambioPatron_ValidaSolicitudBaja", listaParametros)
    End Function

    Public Function tipoMovimientoInfonavit(ByVal idColaborador As Integer, ByVal idPatron As Integer) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "idColaborador"
        parametro.Value = idColaborador
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idPatron"
        parametro.Value = idPatron
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Contabilidad.SP_NFAltaImss_TipoMovimientoInfonavit", listaParametros)
    End Function

    Public Function obtenerDatosCambioPatron(ByVal idColaborador As Int32) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "idColaborador"
        parametro.Value = idColaborador
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Contabilidad.SP_NF_CambioPatron_ObtenerDatosCambioPatron", listaParametros)
    End Function
End Class
