Public Class ColaboradorLaboralBU
    Public Function buscarInformacionLaboral(ByVal colaboradorId As Int32) As Entidades.ColaboradorLaboral

        Dim objDA As New Datos.ColaboradorLaboralDA
        Dim tabla As New DataTable

        Dim laboral As New Entidades.ColaboradorLaboral
        tabla = objDA.buscarInformacionLaboral(colaboradorId)
        For Each row As DataRow In tabla.Rows
            Dim colaborador As New Entidades.Colaborador

            laboral.PColaboradorLaboralId = CInt(row("labo_colaboradorlaboralid"))
            colaborador.PColaboradorid = CInt(row("labo_colaboradorid"))
            laboral.PColaboradorId = colaborador
            If Not IsDBNull(row("labo_naveid")) Then
                Dim nave As New Entidades.Naves
                nave.PNaveId = CInt(row("nave_naveid"))
                nave.PNombre = CStr(row("nave_nombre"))
                laboral.PNaveId = nave
            End If
            If Not IsDBNull(row("labo_telefono")) Then
                laboral.telefono = row("labo_telefono")
            End If
            If Not IsDBNull(row("labo_ext")) Then
                laboral.extencion = row("labo_ext")
            End If
            If Not IsDBNull(row("labo_email")) Then
                laboral.emailLaboral = row("labo_email")
            End If
            If Not IsDBNull(row("labo_jefeInmediato")) Then
                laboral.jefeInmediato = row("labo_jefeInmediato")
            End If
            If Not IsDBNull(row("labo_jefeid")) Then
                laboral.jefeInmediatoid = row("labo_jefeid")
            End If
            If Not IsDBNull(row("labo_idhuellaexterno")) Then
                laboral.PhuellaExterno = row("labo_idhuellaexterno")
            End If

            Try
                laboral.PGeneraHorasExtras = CBool(row("labo_generahorasextras"))
            Catch ex As Exception

            End Try
            Try
                laboral.PNIP = CInt(row("labo_nip"))
            Catch ex As Exception

            End Try



            If Not IsDBNull(row("labo_departamentoid")) Then
                Dim departamento As New Entidades.Departamentos
                departamento.Ddepartamentoid = CInt(row("grup_grupoid"))
                departamento.DNombre = CStr(row("grup_name"))
                If Not IsDBNull(row("grup_nominpaqid")) Then
                    departamento.PDepartamentoIDNP = CStr(row("grup_nominpaqid"))
                Else
                    departamento.PDepartamentoIDNP = 0
                End If
                laboral.PDepartamentoId = departamento

            End If

            If Not IsDBNull(row("labo_puestoid")) Then
                Dim puestos As New Entidades.Puestos
                puestos.Ppuestosid = CInt(row("pues_puestoid"))
                puestos.PNombre = CStr(row("pues_nombre"))
                If Not IsDBNull(row("pues_nominpaqid")) Then
                    puestos.PPuestoIDNP = row("pues_nominpaqid")
                End If

                laboral.PPuestoId = puestos
            End If

            If Not IsDBNull(row("labo_celulaid")) Then
                Dim celula As New Entidades.Celulas
                celula.PCelulaid = CInt(row("labo_celulaid"))
                celula.PNombre = CStr(row("celu_nombre"))
                laboral.PCelula = celula
            End If

            If Not IsDBNull(row("labo_horarioid")) Then
                Dim horario As New Entidades.Horarios
                horario.DHorariosid = CInt(row("labo_horarioid"))
                horario.DNombre = CStr(row("hora_nombre"))
                horario.DRetardo = CInt(row("hora_retardo"))
                laboral.PHorarioId = horario
            End If
            If Not IsDBNull(row("labo_horario2id")) Then
                Dim horario As New Entidades.Horarios
                horario.DHorariosid = CInt(row("labo_horario2id"))
                horario.DNombre = CStr(row("hora_nombre"))
                horario.DRetardo = CInt(row("hora_retardo"))
                laboral.PHorario2Id = horario
            End If
            If Not IsDBNull(row("labo_tienelicencia")) Then
                laboral.PTieneLicencia = row("labo_tienelicencia")
            End If
            If Not IsDBNull(row("labo_numlicencia")) Then
                laboral.PNumLicencia = row("labo_numlicencia")
            End If
            If Not IsDBNull(row("labo_fechaexpiralicencia")) Then
                laboral.PFechaVigencia = row("labo_fechaexpiralicencia")
            End If
            Try
                laboral.PAreaID = (row("labo_areaid"))
            Catch ex As Exception

            End Try
            Try
                laboral.PReporte = (row("labo_reportes"))
            Catch ex As Exception

            End Try
            Try
                laboral.PGanaIncentivos = (row("labo_ganaincentivos"))
            Catch ex As Exception

            End Try

            Try
                laboral.PCheca = (row("labo_checa"))
            Catch ex As Exception

            End Try

        Next
        Return laboral
    End Function



    Public Function BuscarCalaboradorDatos(ByVal Colaboradorid As Int32) As Entidades.Colaborador
        Dim objDA As New Datos.ColaboradorLaboralDA
        Dim tabla As New DataTable
        Dim Colaborador As New Entidades.Colaborador
        tabla = objDA.BuscarDatosColaborador(Colaboradorid)
        For Each row As DataRow In tabla.Rows

            Colaborador.PNombre = CStr(row("codr_nombre"))
            Colaborador.PApaterno = CStr(row("codr_apellidopaterno"))
            Colaborador.PAmaterno = CStr(row("codr_apellidomaterno"))
            Colaborador.pCurp = CStr(row("codr_curp"))
            Colaborador.PRfc = CStr(row("codr_rfc"))
            Colaborador.PEstadoCivil = CStr(row("codr_estadocivil"))
            Colaborador.PFechaNacimiento = CDate(row("codr_fechanacimiento"))
            Colaborador.PCalle = CStr(row("codr_domiciliocalle"))
            Colaborador.Pnumero = CStr(row("codr_domicilionumero"))
            Colaborador.Pcolonia = CStr(row("codr_domiciliocolonia"))
            If Not IsDBNull(row("codr_entrecalles")) Then
                Colaborador.PEntreCalles = CStr(row("codr_entrecalles"))
            End If

            If Not IsDBNull(row("codr_domicilioreferencia")) Then
                Colaborador.PReferencia = CStr(row("codr_domicilioreferencia"))
            End If

            Dim ciudades As New Entidades.Ciudades

            ciudades.CciudadId = CStr(row("ciudadid"))
            Dim estado As New Entidades.Estados
            estado.EIDDEstado = CStr(row("estadoid"))
            ciudades.CIDEstado = estado
            Colaborador.PCiudad = ciudades
            If Not IsDBNull(row("codr_cp")) Then
                Try
                    Colaborador.PCP = CInt(row("codr_cp"))
                Catch ex As Exception

                End Try

            End If

            If Not IsDBNull(row("codr_telefonocasa")) Then
                Colaborador.PTelefonoCasa = CStr(row("codr_telefonocasa"))
            End If



            Colaborador.PTelefonoCel = CStr(row("codr_telefonocelular"))
         

            If Not IsDBNull(row("codr_email")) Then
                Colaborador.PEmail = CStr(row("codr_email"))
            End If

            If Not IsDBNull(row("codr_sexo")) Then
                Colaborador.PSexo = CStr(row("codr_sexo"))
            End If

            If Not IsDBNull(row("codr_claveelector")) Then
                Colaborador.PClaveElector = CStr(row("codr_claveelector"))
            End If

            If Not IsDBNull(row("codr_idciudadorigen")) Then
                Dim ciudad As New Entidades.Ciudades
                ciudad.CciudadId = CInt(row("codr_idciudadorigen"))
                Dim edo As New Entidades.Estados
                edo.EIDDEstado = CInt(row("estadoorigenid"))
                ciudad.CIDEstado = edo
                Colaborador.PCiudadOrigen = ciudad
            End If

            If Not IsDBNull(row("codr_nombrecorto")) Then
                Colaborador.PNombreCorto = CStr(row("codr_nombrecorto"))
            End If

        Next
        Return Colaborador
    End Function


    Public Sub guardarColaboradorLaboral(ByVal laboral As Entidades.ColaboradorLaboral)
        Dim objDA As New Datos.ColaboradorLaboralDA
        objDA.insertarcolaborador(laboral)
    End Sub



    Public Sub EditarColaboradorLaboral(ByVal laboral As Entidades.ColaboradorLaboral, ByVal colaboradorId As Int32)
        Dim objDA As New Datos.ColaboradorLaboralDA
        objDA.Editarcolaborador(laboral, colaboradorId)
    End Sub


    Public Function ValidarLaboral(ByVal ColaboradorId As Int32) As Int32
        Dim objDA As New Datos.ColaboradorLaboralDA
        Dim tabla As New DataTable
        tabla = objDA.buscarInformacionLaboral(ColaboradorId)
        Dim CountLaboral As New Int32
        CountLaboral = tabla.Rows.Count
        Return CountLaboral
    End Function

    Public Sub ActualizarIdAnual(ByVal Naveid As Int32)
        Dim objDA As New Datos.ColaboradorLaboralDA
        objDA.ActualizarIdAnual(Naveid)
    End Sub
    Public Function getColaboradoresDepartamento(ByVal idDep As Int32, ByVal Naveid As Int32) As DataTable
        Dim objDA As New Datos.ColaboradorLaboralDA
        Return objDA.getColaboradoresDepartamento(idDep, Naveid)
    End Function
End Class
