Public Class IncapacidadesBU

    Public Function ValidarIncapacidad(ByVal ColaboradorID As Integer, ByVal FechaInicio As DateTime, ByVal FechaFin As DateTime) As Entidades.Incapacidades
        Dim ObjDA As New Datos.IncapacidadesDA
        Dim Tabla As New DataTable
        Dim Incapacidad As New Entidades.Incapacidades
        ValidarIncapacidad = New Entidades.Incapacidades

        Tabla = ObjDA.ValidarIncapacidad(ColaboradorID, FechaInicio, FechaFin)
        If Tabla.Rows.Count > 0 Then
            Incapacidad.PIncapacidadFechaFin = Tabla.Rows(0).Item("inc_fechafin")
            For Each fila As DataRow In Tabla.Rows

                Incapacidad.PValidarIncapacidad = True

                Return Incapacidad
            Next
        End If


    End Function

    Public Function ValidarIncapacidadEditar(ByVal ColaboradorID As Integer, ByVal FechaInicio As DateTime, ByVal FechaFin As DateTime, ByVal incapacidadID As Integer) As Entidades.Incapacidades
        Dim ObjDA As New Datos.IncapacidadesDA
        Dim Tabla As New DataTable

        ValidarIncapacidadEditar = New Entidades.Incapacidades

        Tabla = ObjDA.ValidarIncapacidadEditar(ColaboradorID, FechaInicio, FechaFin, incapacidadID)

        For Each fila As DataRow In Tabla.Rows
            Dim Incapacidad As New Entidades.Incapacidades
            Incapacidad.PValidarIncapacidad = True
            Return Incapacidad
        Next
    End Function



    Public Function RamoDelSeguro() As DataTable
        Dim objDA As New Datos.IncapacidadesDA
        Return objDA.RamoDelSeguro()
    End Function

    Public Function TipoRiesgo() As DataTable
        Dim objDA As New Datos.IncapacidadesDA
        Return objDA.TipoRiesgo()
    End Function

    Public Function ControlIncapacidad(ByVal idTipoIncapacidad As Int32) As DataTable
        Dim objDA As New Datos.IncapacidadesDA
        Return objDA.ControlIncapacidad(idTipoIncapacidad)
    End Function

    Public Function SecuelaOconsecuencia() As DataTable
        Dim objDA As New Datos.IncapacidadesDA
        Return objDA.SecuelaOconsecuencia()
    End Function

    Public Function TipoMaternidad() As DataTable
        Dim objDA As New Datos.IncapacidadesDA
        Return objDA.TipoMaternidad()
    End Function

    Public Function AltaIncapacidad(ByVal Incapacidad As Entidades.Incapacidades) As DataTable
        Dim ObjDA As New Datos.IncapacidadesDA
        Dim dtGuardar As New DataTable
        dtGuardar = ObjDA.AltaIncapacidad(Incapacidad)
        Return dtGuardar
    End Function

    Public Function ListaIncapacidades(ByVal ColaboradorID As Integer) As List(Of Entidades.Incapacidades)
        Dim ObjDA As New Datos.IncapacidadesDA
        Dim Tabla As New DataTable
        ListaIncapacidades = New List(Of Entidades.Incapacidades)
        Tabla = ObjDA.ListaIncapacidades(ColaboradorID)

        For Each fila As DataRow In Tabla.Rows
            Dim Incapacidad As New Entidades.Incapacidades
            Incapacidad.PIncapacidadFechaInicio = fila("inc_fechainicio")
            Incapacidad.PIncapacidadFechaFin = fila("inc_fechafin")
            ListaIncapacidades.Add(Incapacidad)
        Next
    End Function

    Public Function ListaIncapacidadesReplicadas(ByVal ColaboradorID As Integer) As List(Of Entidades.Incapacidades)
        Dim ObjDA As New Datos.IncapacidadesDA
        Dim Tabla As New DataTable
        ListaIncapacidadesReplicadas = New List(Of Entidades.Incapacidades)
        Tabla = ObjDA.ListaIncapacidadesReplicadas(ColaboradorID)

        For Each fila As DataRow In Tabla.Rows
            Dim Incapacidad As New Entidades.Incapacidades
            Incapacidad.PIncapacidadFechaInicio = fila("inc_fechainicio")
            Incapacidad.PIncapacidadFechaFin = fila("inc_fechafin")
            ListaIncapacidadesReplicadas.Add(Incapacidad)
        Next
    End Function


    Public Function ListaDetalleIncapacidades(ByVal ColaboradorID As Integer, ByVal Fechainicio As DateTime, ByVal FechaFin As DateTime) As List(Of Entidades.Incapacidades)
        Dim ObjDA As New Datos.IncapacidadesDA
        Dim Tabla As New DataTable
        ListaDetalleIncapacidades = New List(Of Entidades.Incapacidades)
        Tabla = ObjDA.ListaDetalleIncapacidades(ColaboradorID, Fechainicio, FechaFin)

        For Each Fila As DataRow In Tabla.Rows
            Dim Incapacidad As New Entidades.Incapacidades
            Incapacidad.PIncapacidadNominpaq = Fila("inc_replicadonominpaq")
            Incapacidad.PIncapacidadID = Fila("inc_incapacidadid")
            Incapacidad.PIncapacidadFolio = Fila("inc_folio")
            Incapacidad.PIncapacidadFechaInicio = Fila("inc_fechainicio")
            Incapacidad.PIncapacidadFechaFin = Fila("inc_fechafin")
            Incapacidad.PIncapacidadDiasAutorizados = Fila("inc_diasautorizados")
            Incapacidad.PRamoSeguroID = Fila("inc_ramoseguroid")
            Incapacidad.PTipoRiesgoID = Fila("inc_tiporiesgoid")
            Incapacidad.PControlIncapacidadID = Fila("inc_controlincapacidadid")
            Incapacidad.PSecuelaID = Fila("inc_secuelaid")
            Incapacidad.PTipoMaternidadID = Fila("inc_tipomaternidadid")
            Incapacidad.PIncapacidadDescripcion = Fila("inc_descripcion")
            Incapacidad.PIncapacidadAnteirorId = Fila("idAnterior")
            Incapacidad.PAceptadoRT = Fila("aceptadort")
            Incapacidad.PEstatusId = Fila("idEstatus")
            ListaDetalleIncapacidades.Add(Incapacidad)
        Next
    End Function

    Public Sub EditarIncapacidades(ByVal Incapacidad As Entidades.Incapacidades)
        Dim ObjDA As New Datos.IncapacidadesDA
        ObjDA.EditarIncapacidades(Incapacidad)
    End Sub

    Public Sub EliminarIncapacidades(ByVal Incapacidad As Entidades.Incapacidades)
        Dim ObjDA As New Datos.IncapacidadesDA
        ObjDA.EliminarIncapacidades(Incapacidad)
    End Sub

    Public Function ListaIncapacidadesFiltro(ByVal NaveID As Integer, ByVal Colaborador As String, ByVal Replicado As String, ByVal patronID As Integer, ByVal fechaInicio As DateTime, ByVal fechafin As DateTime) As List(Of Entidades.Incapacidades)
        Dim ObjDA As New Datos.IncapacidadesDA
        Dim Tabla As New DataTable
        ListaIncapacidadesFiltro = New List(Of Entidades.Incapacidades)
        Tabla = ObjDA.ListaIncapacidadesFiltro(NaveID, Colaborador, Replicado, patronID, fechaInicio, fechafin)

        For Each fila As DataRow In Tabla.Rows
            Dim IncapacidadEnt As New Entidades.Incapacidades
            Dim ColaboradorEnt As New Entidades.Colaborador

            IncapacidadEnt.PIncapacidadID = fila("inc_incapacidadid")
            IncapacidadEnt.PIncapacidadFolio = fila("inc_folio")

            ColaboradorEnt.PNombre = fila("codr_nombre") + " " + fila("codr_apellidopaterno") + " " + fila("codr_apellidomaterno")
            ColaboradorEnt.PColaboradorid = fila("codr_colaboradorID")
            If Not IsDBNull(fila("codr_nominpaqID")) Then
                ColaboradorEnt.PColaboradoridNP = fila("codr_nominpaqID")
            End If

            IncapacidadEnt.PIncapacidadFechaInicio = fila("inc_fechainicio")
            IncapacidadEnt.PIncapacidadFechaFin = fila("inc_fechafin")
            IncapacidadEnt.PIncapacidadDiasAutorizados = fila("inc_diasautorizados")
            IncapacidadEnt.PIncapacidadDescripcion = fila("inc_descripcion")
            IncapacidadEnt.PRamoSeguroDescripcion = fila("ramo_descripcion")
            IncapacidadEnt.PValidaModificacion = fila("validaMov")
            ''Replicacion
            If Not IsDBNull(fila("ramo_NP")) Then
                IncapacidadEnt.PRamoDelSeguroNP = fila("ramo_NP")
            End If

            'If Not IsDBNull(fila("inma_NP")) Then
            '    IncapacidadEnt.PTipoMaternidadNP = fila("inma_NP")
            'End If

            If Not IsDBNull(fila("trin_idNP")) Then
                IncapacidadEnt.PTipoRiesgoNP = fila("trin_idNP")
            End If


            If IsDBNull(fila("trin_descripcion")) Then
                IncapacidadEnt.PTipoRiesgoDescripcion = ""
            Else
                IncapacidadEnt.PTipoRiesgoDescripcion = fila("trin_descripcion")
            End If

            If IsDBNull(fila("inco_descripcion")) Then
                IncapacidadEnt.PControlIncapacidadDescripcion = ""
            Else
                IncapacidadEnt.PControlIncapacidadDescripcion = fila("inco_descripcion")
            End If

            If Not IsDBNull(fila("inco_nominpaqID")) Then
                IncapacidadEnt.PControlIncapacidadIDNP = fila("inco_nominpaqID")
            Else
                'IncapacidadEnt.PControlIncapacidadIDNP = fila("inma_NPID")
            End If

            If IsDBNull(fila("inse_descripcion")) Then
                IncapacidadEnt.PSecuelaDescripcion = ""
            Else
                IncapacidadEnt.PSecuelaDescripcion = fila("inse_descripcion")
            End If

            If Not IsDBNull(fila("inse_nominpaqid")) Then
                IncapacidadEnt.PSecuelaIDNP = fila("inse_nominpaqid")
            End If

            'If IsDBNull(fila("inma_descripcion")) Then
            '    IncapacidadEnt.PTipoMaternidadDescripcion = ""
            'Else
            '    IncapacidadEnt.PTipoMaternidadDescripcion = fila("inma_descripcion")
            'End If

            IncapacidadEnt.PIncapacidadNominpaq = fila("inc_replicadonominpaq")

            IncapacidadEnt.PColaborador = ColaboradorEnt
            ListaIncapacidadesFiltro.Add(IncapacidadEnt)

        Next
    End Function

    Public Function consultaIncapacidadesAnteriores(ByVal idColaborador As Int32) As DataTable
        Dim objDa As New Datos.IncapacidadesDA
        Dim dtAnt As New DataTable

        dtAnt = objDa.consultaIncapacidadesAnteriores(idColaborador)

        If dtAnt.Rows.Count > 1 Then
            Dim dtRow As DataRow = dtAnt.NewRow
            dtRow("idIncapacidad") = 0
            dtRow("descripcion") = ""
            dtAnt.Rows.InsertAt(dtRow, 0)
        End If
        Return dtAnt
    End Function

    Public Function validarPerfilContabilidad() As Boolean
        Dim objDatos As New Datos.IncapacidadesDA
        Dim dtResultado As New DataTable
        Dim resultado As Boolean = False

        dtResultado = objDatos.validarPerfilContabilidad()
        If Not dtResultado Is Nothing Then
            resultado = CBool(dtResultado.Rows(0)("RESULTADO").ToString)
        End If

        Return resultado
    End Function

    Public Function actualizarExpediente(ByVal idColaborador As Int32, ByVal idIncapacidad As Int32, ByVal tituloMovimiento As String,
                                         ByVal carpeta As String, ByVal archivo As String) As String
        Dim resul As String = String.Empty
        Dim dtExp As New DataTable
        Dim objDa As New Datos.IncapacidadesDA

        dtExp = objDa.actualizarExpediente(idColaborador, idIncapacidad, tituloMovimiento, carpeta, archivo)

        If dtExp.Rows.Count > 0 Then
            resul = dtExp.Rows(0).Item("resul")
        End If

        Return resul
    End Function

    Public Function consultaListadoArchivos(ByVal idIncapacidad As Int32) As List(Of Entidades.AcusesIncapacidades)
        Dim objDa As New Datos.IncapacidadesDA
        Dim dtInc As New DataTable
        Dim listaArchivos As New List(Of Entidades.AcusesIncapacidades)

        dtInc = objDa.consultaListadoArchivos(idIncapacidad)

        If dtInc.Rows.Count > 0 Then

            For Each rowInc As DataRow In dtInc.Rows
                Dim archivo As New Entidades.AcusesIncapacidades
                archivo.PCarpetaArchivo = rowInc.Item("carpeta")
                archivo.PNombreArchivo = rowInc.Item("nombreArchivo")
                archivo.PRutaArchivo = rowInc.Item("ruta")
                archivo.PTipo = rowInc.Item("tipo")
                listaArchivos.Add(archivo)
            Next
        End If

        Return listaArchivos
    End Function

    Public Function consultaListadoEstatus(ByVal tipoMovimiento As String) As DataTable
        Dim objDatos As New Datos.IncapacidadesDA
        Dim dtListado As New DataTable

        dtListado = objDatos.consultaListadoEstatus(tipoMovimiento)
        If Not dtListado Is Nothing Then
            If dtListado.Rows.Count > 1 Then
                Dim dtRow As DataRow = dtListado.NewRow
                dtRow("ID") = 0
                dtRow("estatus") = ""
                dtListado.Rows.InsertAt(dtRow, 0)
            End If
        End If

        Return dtListado
    End Function

    Public Function ValidarLaboral(ByVal ColaboradorId As Int32) As Int32
        Dim objDA As New Datos.IncapacidadesDA
        Dim tabla As New DataTable
        tabla = objDA.buscarInformacionLaboral(ColaboradorId)
        Dim CountLaboral As New Int32
        CountLaboral = tabla.Rows.Count
        Return CountLaboral
    End Function
End Class
