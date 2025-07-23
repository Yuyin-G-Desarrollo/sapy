Public Class ColaboradoresContabilidadBU
    Public Function consultaListadoColaboradores(ByVal idPatron As Int32, ByVal activo As Int32, ByVal nombre As String) As DataTable
        Dim objDa As New Datos.ColaboradoresContabilidadDA
        Dim dtlista As New DataTable

        dtlista = objDa.consultaListadoColaboradores(idPatron, activo, nombre)

        Return dtlista
    End Function

    Public Function insertaColaboradorExterno(ByVal colaborador As Entidades.ColaboradorExterno) As DataTable
        Dim objDa As New Datos.ColaboradoresContabilidadDA
        Dim dtResultado As New DataTable

        dtResultado = objDa.insertaColaboradorExterno(colaborador)

        Return dtResultado
    End Function

    Public Function consultaDatosColaborador(ByVal idColaborador As Int32) As DataTable
        Dim objDa As New Datos.ColaboradoresContabilidadDA
        Dim dtResultado As New DataTable

        dtResultado = objDa.consultaDatosColaborador(idColaborador)

        Return dtResultado
    End Function

    Public Function editarColaboradorExterno(ByVal colaborador As Entidades.ColaboradorExterno) As DataTable
        Dim objDa As New Datos.ColaboradoresContabilidadDA
        Dim dtResultado As New DataTable

        dtResultado = objDa.editarColaboradorExterno(colaborador)

        Return dtResultado
    End Function

    Public Function consultaListadoExpedienteColaborador(ByVal idColaborador As Int32) As DataTable
        Dim objDa As New Datos.ColaboradoresContabilidadDA
        Dim dtExpediente As New DataTable
        dtExpediente = objDa.consultaListadoExpedienteColaborador(idColaborador)
        Return dtExpediente
    End Function

    Public Sub actualizarArchivoExpediente(ByVal idColaborador As Int32, ByVal idExpediente As Int32, ByVal nombreArchivo As String,
                                           ByVal idUsuario As Int32)

        Dim objDa As New Datos.ColaboradoresContabilidadDA
        objDa.actualizarArchivoExpediente(idColaborador, idExpediente, nombreArchivo, idUsuario)
    End Sub

    Public Function consultaColaboradoresParaALtaImss(ByVal idNave As Int32, ByVal nombre As String) As DataTable
        Dim objDa As New Datos.ColaboradoresContabilidadDA
        Dim dtColaboALta As New DataTable

        dtColaboALta = objDa.consultaColaboradoresParaALtaImss(idNave, nombre)

        Return dtColaboALta
    End Function

    Public Function obtenerFechaAlta(ByVal idPatron As Int32) As DataTable
        Dim objDa As New Datos.ColaboradoresContabilidadDA
        Dim dtFecha As New DataTable

        dtFecha = objDa.obtenerFechaAlta(idPatron)

        Return dtFecha

    End Function

    Public Function consultaDatosComplementariosIMSS(ByVal idColaborador As Int32) As DataTable
        Dim objDa As New Datos.ColaboradoresContabilidadDA
        Dim dtColaboImss As New DataTable

        dtColaboImss = objDa.consultaDatosComplementariosIMSS(idColaborador)

        Return dtColaboImss

    End Function

    Public Function insertaAltaImss(ByVal colaboradorImss As Entidades.AltaColaboradorIMSS, ByVal usuarioCreo As Int32) As DataTable
        Dim objDa As New Datos.ColaboradoresContabilidadDA
        Dim dtAltaImss As New DataTable

        dtAltaImss = objDa.insertaAltaImss(colaboradorImss, usuarioCreo)

        Return dtAltaImss
    End Function

    Public Function consultaAltasImssPorAutorizar(ByVal idNave As Int32, ByVal idEstatus As Int32, ByVal nombre As String) As DataTable
        Dim objDa As New Datos.ColaboradoresContabilidadDA
        Dim dtPorAutorizar As New DataTable

        dtPorAutorizar = objDa.consultaAltasImssPorAutorizar(idNave, idEstatus, nombre)

        Return dtPorAutorizar
    End Function

    Public Function consultaInformacionParaEditarImss(ByVal idAlta As Int32) As DataTable
        Dim objDa As New Datos.ColaboradoresContabilidadDA
        Dim dtEditar As New DataTable

        dtEditar = objDa.consultaInformacionParaEditarImss(idAlta)

        Return dtEditar
    End Function

    Public Function editarAltaImss(ByVal idColaborador As Int32, ByVal idAlta As Int32, ByVal colaboradorImss As Entidades.AltaColaboradorIMSS, ByVal idUsuario As Int32) As DataTable
        Dim dtEdicion As New DataTable
        Dim objDa As New Datos.ColaboradoresContabilidadDA

        dtEdicion = objDa.editarAltaImss(idColaborador, idAlta, colaboradorImss, idUsuario)
        Return dtEdicion
    End Function

    Public Function autorizarAltaImss(ByVal idColaborador As Int32, ByVal idAlta As Int32, ByVal idUsuario As Int32) As DataTable
        Dim dtAutorizar As New DataTable
        Dim objDa As New Datos.ColaboradoresContabilidadDA

        dtAutorizar = objDa.autorizarAltaImss(idColaborador, idAlta, idUsuario)
        Return dtAutorizar
    End Function

    Public Function rechazarAltaImss(ByVal idColaborador As Int32, ByVal idAlta As Int32, ByVal motivo As String, ByVal idUsuario As Int32) As DataTable
        Dim dtRechazar As New DataTable
        Dim objDa As New Datos.ColaboradoresContabilidadDA

        dtRechazar = objDa.rechazarAltaImss(idColaborador, idAlta, motivo, idUsuario)
        Return dtRechazar
    End Function

    Public Function consultaGeneracionAltasIMSS(ByVal patronid As Int32, ByVal estatusId As Int32, ByVal nombre As String) As DataTable
        Dim dtGeneracion As New DataTable
        Dim objDa As New Datos.ColaboradoresContabilidadDA

        dtGeneracion = objDa.consultaGeneracionAltasIMSS(patronid, estatusId, nombre)
        Return dtGeneracion
    End Function

    Public Function consultaInformacionIdse(ByVal idAlta As Int32) As Entidades.InformacionIDSE_SUA
        Dim dtIdse As New DataTable
        Dim objda As New Datos.ColaboradoresContabilidadDA
        Dim informacionIdse As New Entidades.InformacionIDSE_SUA

        dtIdse = objda.consultaInformacionIdse(idAlta)

        If Not dtIdse Is Nothing Then
            If dtIdse.Rows.Count > 0 Then
                informacionIdse.IIAMaterno = dtIdse.Rows(0).Item("amaterno")
                informacionIdse.IIAPaterno = dtIdse.Rows(0).Item("apaterno")
                informacionIdse.IIRegistroPatronal = dtIdse.Rows(0).Item("registropatronal")
                informacionIdse.IINumeroSeguroSocial = dtIdse.Rows(0).Item("nss")
                informacionIdse.IINombre = dtIdse.Rows(0).Item("nombre")
                informacionIdse.IISalarioDiario = dtIdse.Rows(0).Item("sdi")
                informacionIdse.IIClaveTrabajador = dtIdse.Rows(0).Item("claveTrabajador")
                informacionIdse.IIClaveTipoColaborador = dtIdse.Rows(0).Item("tipoTrabajador")
                informacionIdse.IIClaveTipoSalario = dtIdse.Rows(0).Item("claveSalario")
                informacionIdse.IIClaveTipoJornada = dtIdse.Rows(0).Item("claveJornada")
                informacionIdse.IIFechaMovimiento = dtIdse.Rows(0).Item("fechaAlta")
                informacionIdse.IIUnidadMedicaFamiliar = dtIdse.Rows(0).Item("umf")
                informacionIdse.IIClaveMovimiento = dtIdse.Rows(0).Item("tipoMovimiento")
                informacionIdse.IIClaveTrabajador = dtIdse.Rows(0).Item("claveTrabajador")
                informacionIdse.IICurp = dtIdse.Rows(0).Item("curp")
                informacionIdse.IIRFC = dtIdse.Rows(0).Item("rfc")
                informacionIdse.IIRutaDescarga = dtIdse.Rows(0).Item("rutaDescarga")
                informacionIdse.IINombreCompleto = dtIdse.Rows(0).Item("nombreCompleto")
                informacionIdse.IIPuesto = dtIdse.Rows(0).Item("puesto")
                informacionIdse.IITablaId = dtIdse.Rows(0).Item("idAlta")
                informacionIdse.IIIdentificador = dtIdse.Rows(0).Item("identificador")

                informacionIdse.ICodigoPostal = dtIdse.Rows(0).Item("cp")
                informacionIdse.IFechaNacimiento = dtIdse.Rows(0).Item("fechaNacimiento")
                informacionIdse.ILugarNacimiento = dtIdse.Rows(0).Item("lugarNacimiento")
                informacionIdse.IClaveLugarNacimiento = dtIdse.Rows(0).Item("claveEstado")
                informacionIdse.ISexo = dtIdse.Rows(0).Item("sexo")
                informacionIdse.IIClaveTipoSalario = dtIdse.Rows(0).Item("tipoSalario")
                informacionIdse.IHora = dtIdse.Rows(0).Item("hora")
                informacionIdse.IOcupacion = dtIdse.Rows(0).Item("ocupacion")

            End If
        End If

        Return informacionIdse
    End Function

    Public Function aceptarRechazarIdseAltaImss(ByVal idAlta As Int32, ByVal idColaborador As Int32, ByVal carpeta As String,
                                                ByVal archivo As String, ByVal movimiento As String, ByVal motivo As String) As String

        Dim objDa As New Datos.ColaboradoresContabilidadDA
        Dim dtResul As New DataTable
        Dim resula As String = String.Empty
        dtResul = objDa.aceptarRechazarIdseAltaImss(idAlta, idColaborador, carpeta, archivo, movimiento, motivo)

        If Not dtResul Is Nothing Then
            If dtResul.Rows.Count > 0 Then
                resula = dtResul.Rows(0).Item("resul")
            End If
        End If

        Return resula
    End Function

    Public Function consultaDestinatariosAltaIMSS(ByVal idAlta As Int32) As DataTable
        Dim objDa As New Datos.ColaboradoresContabilidadDA
        Dim dtDestinatarios As New DataTable

        dtDestinatarios = objDa.consultaDestinatariosAltaIMSS(idAlta)

        Return dtDestinatarios
    End Function

    Public Function regresarSolicitudesImss(ByVal idAlta As Int32, ByVal motivo As String) As String
        Dim objDa As New Datos.ColaboradoresContabilidadDA
        Dim dtResul As New DataTable
        Dim resula As String = String.Empty
        dtResul = objDa.regresarSolicitudesImss(idAlta, motivo)

        If Not dtResul Is Nothing Then
            If dtResul.Rows.Count > 0 Then
                resula = dtResul.Rows(0).Item("resul")
            End If
        End If

        Return resula
    End Function

    Public Function actualizarDescuentoISR(ByVal idColaborador As Int32, descuento As Double, ByVal imssDiario As Double, ByVal imssSemanal As Double,
                                           ByVal spe As Boolean) As DataTable
        Dim objDa As New Datos.ColaboradoresContabilidadDA
        Dim dtResul As New DataTable

        dtResul = objDa.actualizarDescuentoISR(idColaborador, descuento, imssDiario, imssSemanal, spe)
        Return dtResul
    End Function

    Public Function validaSDIMinimo(ByVal colaboradorId As Int32) As Double
        Dim objDa As New Datos.ColaboradoresContabilidadDA
        Dim dtResul As New DataTable
        Dim sdIminimo As Double = 0

        dtResul = objDa.validaSDIMinimo(colaboradorId)

        If dtResul.Rows.Count > 0 Then
            sdIminimo = dtResul.Rows(0).Item("salariominimo")
        End If
        Return sdIminimo
    End Function

    Public Function validaColaboradorExistente(ByVal curp As String, ByVal rfc As String, ByVal nss As String) As DataTable
        Dim objDa As New Datos.ColaboradoresContabilidadDA
        Dim dtExiste As New DataTable

        dtExiste = objDa.validaColaboradorExistente(curp, rfc, nss)

        Return dtExiste
    End Function

    Public Function altaMovimientoCreditoInfonavit(ByVal credInfonavit As Entidades.CreditoInfonavit, ByVal carpeta As String, ByVal archivo As String) As DataTable
        Dim objDatos As New Datos.CreditoInfonavitDA
        Dim dtResultado As New DataTable
        Dim resultado As String = String.Empty

        dtResultado = objDatos.altaMovimientoCreditoInfonavit(credInfonavit, carpeta, archivo)
        If Not dtResultado Is Nothing Then
            resultado = dtResultado.Rows(0)("mensaje").ToString
        End If

        Return dtResultado
    End Function

    Public Function ActualizaInfonavitALtaImss(ByVal idInfonavit As Int32, ByVal idAlta As Int32) As String
        Dim resul As String = String.Empty
        Dim objDatos As New Datos.ColaboradoresContabilidadDA
        Dim dtResultado As New DataTable

        dtResultado = objDatos.ActualizaInfonavitALtaImss(idInfonavit, idAlta)
        If Not dtResultado Is Nothing Then
            resul = dtResultado.Rows(0)("resul").ToString
        End If

        Return resul

    End Function

    Public Function tipoMovimientoSMDInfonavit() As DataTable
        Dim objDatos As New Datos.ColaboradoresContabilidadDA
        Dim dtResultado As New DataTable

        dtResultado = objDatos.tipoMovimientoSMDInfonavit()

        Return dtResultado
    End Function

    Public Function actualizaExpedienteCartaManifiesto(ByVal idColaborador As Int32, ByVal idAlta As Int32, ByVal tituloMovimiento As String, ByVal carpeta As String,
                                                       ByVal archivo As String) As String
        Dim resul As String = String.Empty
        Dim objDatos As New Datos.ColaboradoresContabilidadDA
        Dim dtResultado As New DataTable

        dtResultado = objDatos.actualizaExpedienteCartaManifiesto(idColaborador, idAlta, tituloMovimiento, carpeta, archivo)
        If Not dtResultado Is Nothing Then
            resul = dtResultado.Rows(0)("resul").ToString
        End If

        Return resul
    End Function

    Public Function validarEstatus(ByVal altaId As Integer, ByVal opcEstatus As Integer) As String
        Dim objDatos As New Datos.ColaboradoresContabilidadDA
        Dim dtResultado As New DataTable
        Dim resultado As String = String.Empty

        dtResultado = objDatos.validarEstatus(altaId, opcEstatus)
        If Not dtResultado Is Nothing Then
            resultado = dtResultado.Rows(0)("mensaje").ToString
        End If

        Return resultado
    End Function

    Public Function validaSolicitudBaja(ByVal colaboradorId As Integer) As Boolean

        Dim objDa As New Datos.ColaboradoresContabilidadDA
        Dim dtResul As New DataTable
        Dim resula As Boolean = True
        dtResul = objDa.validaSolicitudBaja(colaboradorId)

        If Not dtResul Is Nothing Then
            If dtResul.Rows.Count > 0 Then
                resula = False
            End If
        End If

        Return resula
    End Function

    Public Function tipoMovimientoInfonavit(ByVal idColaborador As Integer, ByVal idPatron As Integer) As Integer
        Dim objDatos As New Datos.ColaboradoresContabilidadDA
        Dim dtResultado As New DataTable
        Dim tipoMovimiento As Integer = 1

        dtResultado = objDatos.tipoMovimientoInfonavit(idColaborador, idPatron)

        If dtResultado.Rows.Count > 0 Then
            tipoMovimiento = dtResultado.Rows(0).Item("idMovimiento")
        End If

        Return tipoMovimiento
    End Function

    Public Function obtenerDatosCambioPatron(ByVal idColaborador As Int32) As DataTable
        Dim objDatos As New Datos.ColaboradoresContabilidadDA
        Return objDatos.obtenerDatosCambioPatron(idColaborador)
    End Function

End Class
