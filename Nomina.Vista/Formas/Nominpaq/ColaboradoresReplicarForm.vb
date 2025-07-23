Imports Tools

Public Class ColaboradoresReplicarForm

    Private Sub lblReplicar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        WindowState = FormWindowState.Maximized
        Try
            Tools.Controles.ComboNavesSegunUsuario(cmbNave, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
        Catch ex As Exception
        End Try
    End Sub


    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Me.Cursor = Cursors.WaitCursor
        grdReplicar.Rows.Clear()
        Dim ObjBU As New Nomina.Negocios.ColaboradoresReplicarBU
        Dim listaColaboradores As List(Of Entidades.ColaboradoresReplicar)

        listaColaboradores = ObjBU.ListaColaboradores(cmbNave.SelectedValue, "TRUE")
        ReplicarNPSay(listaColaboradores)

        listaColaboradores = ObjBU.ListaColaboradores(cmbNave.SelectedValue, "FALSE")
        ReplicarNPSay(listaColaboradores)

        listaColaboradores = ObjBU.ListaColaboradores(cmbNave.SelectedValue, "TRUE")
        llenarGrid(listaColaboradores)

        listaColaboradores = ObjBU.ListaColaboradores(cmbNave.SelectedValue, "FALSE")
        ReplicarNPSay(listaColaboradores)
        Me.Cursor = Cursors.Default
    End Sub

    Public Sub ReplicarNPSay(ByVal ColaboradorLista As List(Of Entidades.ColaboradoresReplicar))
        For Each ColaboradorF As Entidades.ColaboradoresReplicar In ColaboradorLista
            Dim ColaboradorID As Integer = 0
            Dim PatronBD As String = ""
            Dim PatronServidor As String = ""
            Dim idNave As Integer = 0
            Dim ObjBUNomina As New Negocios.ColaboradorNominaBU
            Dim ObjReplicarBU As New Negocios.ColaboradoresReplicarBU
            Dim Nomina As New Entidades.ColaboradorNomina
            Dim NominaReal As New Negocios.ColaboradorRealBU
            idNave = cmbNave.SelectedValue
            ColaboradorID = ColaboradorF.PColaborador.PColaboradorid
            Nomina = ObjBUNomina.buscarColaborarNomina(ColaboradorID)
            PatronBD = Nomina.PPatron.PpatronBD
            PatronServidor = Nomina.PPatron.PServidor

            ObjReplicarBU.ReplicarNominpaqSay(idNave, PatronBD, PatronServidor)
            Exit For
        Next
    End Sub


    Public Sub llenarGrid(ByVal ColaboradorLista As List(Of Entidades.ColaboradoresReplicar))
        Dim ColaboradorID As Integer = 0
        Dim ColaboradorIDNP As Integer = 0
        Dim CodigoEmpleado As String = ""
        Dim Colaborador As String = ""
        Dim Puesto As String = ""
        Dim PuestoID As Integer = 0
        Dim PuestoIDNP As Integer = 0
        Dim Departamento As String = ""
        Dim DepartamentoID As Integer = 0
        Dim DepartamentoIDNP As Integer = 0
        Dim Nave As String = ""
        Dim NAveID As Integer = 0

        Dim FechaNac As DateTime
        Dim EstadoCivil As String = ""
        Dim Sexo As String = ""
        Dim Curp As String = ""
        Dim NSS As String = ""
        Dim RFC As String = ""
        Dim SalarioDiario As Double = 0
        Dim Salario As Double = 0
        Dim SalarioIntegrado As Double = 0
        Dim FechaAltaIMSS As DateTime
        Dim FechaAltaInfonavit As DateTime
        Dim Calle As String = ""
        Dim NumDomicilio As String = ""
        Dim Colonia As String = ""
        Dim CP As Integer = 0
        Dim Ciudad As Integer = 0
        Dim EstadoNombre As String = ""
        Dim CiudadNombre As String = ""
        Dim CiudadOrigen As Integer = 0
        Dim CiudadOrigenNombre As String = ""

        Dim diasTrabajados As Integer = 0
        Dim FechaIngreso As DateTime
        Dim AntiguedadAnios As Integer = 0
        Dim FactorIntegracion As Double = 0

        Dim BD As String = ""
        Dim RegPatronal As String = ""
        Dim Servidor As String = ""
        Dim replicacion As Integer = 0


        For Each ColaboradorF As Entidades.ColaboradoresReplicar In ColaboradorLista
            ColaboradorID = ColaboradorF.PColaborador.PColaboradorid
            ColaboradorIDNP = ColaboradorF.PColaborador.PColaboradoridNP
            CodigoEmpleado = ColaboradorF.PColaborador.PCodigoEmpleadoNp

            ''LLENADO DE DATOS PERSONALES
            Dim ObjBUPersonal As New Nomina.Negocios.ColaboradorLaboralBU
            Dim Datos As New Entidades.Colaborador
            Datos = ObjBUPersonal.BuscarCalaboradorDatos(ColaboradorID)
            Colaborador = Datos.PApaterno.ToString + " " + Datos.PAmaterno.ToString + " " + Datos.PNombre.ToString

            Curp = Datos.pCurp
            RFC = Datos.PRfc
            EstadoCivil = Datos.PEstadoCivil
            Calle = Datos.PCalle
            NumDomicilio = Datos.Pnumero
            Colonia = Datos.Pcolonia
            Curp = Datos.pCurp
            CP = Datos.PCP
            Sexo = Datos.PSexo
            FechaNac = Datos.PFechaNacimiento
            Ciudad = ColaboradorF.PCiudades.CciudadId
            CiudadOrigen = ColaboradorF.PCiudadesOrigen.CciudadId

            'NOMBRE DE CIUDAD DOMICILIO
            Dim CiudadDomicilioNombre As New Entidades.ColaboradoresReplicar
            Dim CiudadDomicilioNombreBU As New Nomina.Negocios.ColaboradoresReplicarBU
            If Ciudad > 0 Then
                CiudadDomicilioNombre = CiudadDomicilioNombreBU.CiudadNombre(Ciudad)
                CiudadNombre = CiudadDomicilioNombre.PCiudades.CNombre
                EstadoNombre = CiudadDomicilioNombre.PEstados.ENombre
            Else
                CiudadNombre = ""
            End If

            'NOMBRE DE CIUDAD ORIGEN            
            If CiudadOrigen > 0 Then
                CiudadDomicilioNombre = CiudadDomicilioNombreBU.CiudadNombre(CiudadOrigen)
                CiudadOrigenNombre = CiudadDomicilioNombre.PCiudades.CNombre
            Else
                CiudadOrigenNombre = ""
            End If

            ''LLENADO DE DATOS LABORALES
            Dim DatosLaborales As New Entidades.ColaboradorLaboral
            Dim DatosLaboralesBU As New Nomina.Negocios.ColaboradorLaboralBU

            DatosLaborales = DatosLaboralesBU.buscarInformacionLaboral(ColaboradorID)
            Puesto = DatosLaborales.PPuestoId.PNombre
            PuestoIDNP = DatosLaborales.PPuestoId.PPuestoIDNP
            Departamento = DatosLaborales.PDepartamentoId.DNombre
            DepartamentoIDNP = DatosLaborales.PDepartamentoId.PDepartamentoIDNP
            Nave = UCase(DatosLaborales.PNaveId.PNombre)

            ''LLENADO DATOS NOMINA
            Dim ObjBUNomina As New Negocios.ColaboradorNominaBU
            Dim Nomina As New Entidades.ColaboradorNomina
            Dim NominaReal As New Negocios.ColaboradorRealBU

            Nomina = ObjBUNomina.buscarColaborarNomina(ColaboradorID)

            Salario = Nomina.PSalario
            SalarioDiario = Nomina.PSalarioDiario
            FechaAltaIMSS = Nomina.PFechaAltaImss
            FechaAltaInfonavit = Nomina.PfechaAltaInfonavit
            NSS = Nomina.PNss
            FechaIngreso = Nomina.PFechaAltaImss
            BD = Nomina.PPatron.PpatronBD
            RegPatronal = Nomina.PPatron.PNpatronalNP
            Servidor = Nomina.PPatron.PServidor
            ''INTEGRAR SALARIO DIARIO            
            diasTrabajados = (Now.Date - FechaIngreso).TotalDays
            AntiguedadAnios = Math.Round(diasTrabajados / 365, 0)
            If AntiguedadAnios = 0 Then
                AntiguedadAnios = 1
            End If

            ''FACTOR DE INTEGRACION
            Dim ListaFactorIntegracion As New List(Of Entidades.CalcularNominaReal)
            Dim ObjBU As New Nomina.Negocios.CalcularNominaRealBU
            ListaFactorIntegracion = ObjBU.FactorIntegracion(AntiguedadAnios)

            For Each fila As Entidades.CalcularNominaReal In ListaFactorIntegracion
                FactorIntegracion = fila.PFactorIntegracion
            Next
            ''SALARIO INTEGRADO
            SalarioIntegrado = SalarioDiario * FactorIntegracion

            ''AGREGAR FILA
            grdReplicar.Rows.Add(grdReplicar.Rows.Count + 1, _
                                 False, _
                                 Colaborador.ToUpper, _
                                 Datos.PApaterno.ToUpper, _
                                 Datos.PAmaterno.ToUpper, _
                                 Datos.PNombre.ToUpper, _
                                 ColaboradorIDNP, _
                                 CodigoEmpleado, _
                                 Departamento.ToUpper, _
                                 Puesto.ToUpper, _
                                 FechaNac.ToShortDateString, _
                                 CiudadOrigenNombre.ToUpper, _
                                 EstadoCivil.ToUpper, _
                                 Sexo.ToUpper, _
                                 Curp.ToUpper, _
                                 FechaAltaIMSS.ToShortDateString, _
                                 NSS, _
                                 RFC.ToUpper, _
                                 SalarioDiario, _
                                 SalarioIntegrado, _
                                 Calle.ToUpper, _
                                 NumDomicilio, _
                                 Colonia.ToUpper, _
                                 CP, _
                                 CiudadNombre.ToUpper, _
                                 EstadoNombre.ToUpper, _
                                 RegPatronal, _
                                 DepartamentoIDNP, _
                                 PuestoIDNP, _
                                 BD, _
                                 Servidor, _
                                 ColaboradorID, _
                                 True)
        Next
        ValidarCampos()
    End Sub



    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        grdReplicar.Rows.Clear()
        cmbNave.SelectedIndex = 0
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If grdReplicar.Rows.Count > 0 Then
            Dim mensajeExito As New ConfirmarForm
            mensajeExito.mensaje = "¿ Está seguro de querer replicar los seleccionados? " + vbNewLine + "No podrá hacer modificaciones" + vbNewLine + " despues del guardado."
            If mensajeExito.ShowDialog = DialogResult.OK Then
                Guardar()
                Me.Cursor = Cursors.WaitCursor
                grdReplicar.Rows.Clear()
                Dim ObjBU As New Nomina.Negocios.ColaboradoresReplicarBU
                Dim listaColaboradores As List(Of Entidades.ColaboradoresReplicar)
                listaColaboradores = ObjBU.ListaColaboradores(cmbNave.SelectedValue, "TRUE")
                ReplicarNPSay(listaColaboradores)
                listaColaboradores = ObjBU.ListaColaboradores(cmbNave.SelectedValue, "FALSE")
                ReplicarNPSay(listaColaboradores)
                listaColaboradores = ObjBU.ListaColaboradores(cmbNave.SelectedValue, "TRUE")
                llenarGrid(listaColaboradores)
                Me.Cursor = Cursors.Default
            End If
        End If
    End Sub
    Public Sub Guardar()
        Try
            Dim estaMal As Integer = 0
            For Each row As DataGridViewRow In grdReplicar.Rows
                Dim CodigoEmpleado As String = ""
                Dim contadorCoincidencias As Integer = 0

                CodigoEmpleado = row.Cells("clmCodigoEmpleado").Value
                If CodigoEmpleado <> "" Then
                    contadorCoincidencias = 0
                    For Each row2 As DataGridViewRow In grdReplicar.Rows
                        If CodigoEmpleado = row2.Cells("clmCodigoEmpleado").Value Then
                            contadorCoincidencias += 1
                            If contadorCoincidencias > 1 Then
                                row2.Cells("clmCodigoEmpleado").Style.BackColor = Color.Orange
                                estaMal += 1
                            End If
                        End If
                    Next
                End If

                If row.Cells("clmReplicar").Value = True And row.Cells("clmEstabien").Value = True And contadorCoincidencias = 1 Then
                    Dim ObjBU As New Negocios.ColaboradoresReplicarBU
                    Dim ObjEntRep As New Entidades.ColaboradoresReplicar
                    Dim CurpI As String = ""
                    Dim CurpF As String = ""
                    Dim RFC As String = ""
                    Dim homoClave As String = ""
                    Dim colaboradorID As Integer

                    '''''''''''''''''''''''''''''
                    ''LLENADO DE DATOS PERSONALES                
                    '''''''''''''''''''''''''''''
                    colaboradorID = row.Cells("clmIDColaborador").Value
                    Dim Datos As New Entidades.Colaborador
                    Dim CiudadDomicilio As New Entidades.Ciudades
                    Dim EstadoDomicilio As New Entidades.Estados
                    Dim CiudadOrigen As New Entidades.Ciudades
                    Datos.PCodigoEmpleadoNp = row.Cells("clmCodigoEmpleado").Value
                    Datos.PColaboradoridNP = row.Cells("clmIDColaboradorNP").Value


                    Datos.PNombre = row.Cells("clmNombre").Value
                    Datos.PApaterno = row.Cells("clmAPaterno").Value
                    Datos.PAmaterno = row.Cells("clmAMaterno").Value
                    Datos.PFechaNacimiento = row.Cells("clmFechaNacimiento").Value
                    CiudadOrigen.CNombre = row.Cells("clmCiudadOrigen").Value

                    If row.Cells("clmEstadoCivil").Value = "CASADO(A)" Then
                        Datos.PEstadoCivil = "C"
                    ElseIf row.Cells("clmEstadoCivil").Value = "SOLTERO(A)" Then
                        Datos.PEstadoCivil = "S"
                    ElseIf row.Cells("clmEstadoCivil").Value = "DIVORCIADO(A)" Then
                        Datos.PEstadoCivil = "D"
                    Else
                        row.Cells("clmEstadoCivil").Style.BackColor = Color.Salmon
                    End If

                    If row.Cells("clmSexo").Value = "HOMBRE" Then
                        Datos.PSexo = "H"
                    ElseIf row.Cells("clmSexo").Value = "MUJER" Then
                        Datos.PSexo = "M"
                    Else
                        row.Cells("clmSexo").Style.BackColor = Color.Salmon
                    End If


                    CurpI = row.Cells("clmCurp").Value
                    If CurpI.Length = 18 Then
                        Datos.PCurpI = CurpI.Substring(0, 4)
                        CurpF = CStr(row.Cells("clmCurp").Value)
                        Datos.PCurpF = CurpF.Substring(10, 8)
                    Else
                        row.Cells("clmCurp").Style.BackColor = Color.Salmon
                    End If


                    RFC = row.Cells("clmRFC").Value
                    If RFC.Length = 13 Then
                        Datos.PRfc = RFC.Substring(0, 4)
                        homoClave = row.Cells("clmRFC").Value
                        Datos.PHomoclave = homoClave.Substring(10, 3)
                    Else
                        row.Cells("clmRFC").Style.BackColor = Color.Salmon
                    End If

                    Datos.PCalle = row.Cells("clmCalle").Value
                    Datos.Pnumero = row.Cells("clmNumDomicilio").Value
                    Datos.Pcolonia = row.Cells("clmColonia").Value
                    CiudadDomicilio.CNombre = row.Cells("clmCiudad").Value
                    EstadoDomicilio.ENombre = row.Cells("clmEstado").Value
                    Datos.PCP = row.Cells("clmCP").Value


                    '''''''''''''''''''''''''''''
                    ''LLENADO DE DATOS LABORALES
                    '''''''''''''''''''''''''''''
                    Dim DatosLaborales As New Entidades.ColaboradorLaboral
                    Dim Puestos As New Entidades.Puestos
                    Dim Departamentos As New Entidades.Departamentos

                    Puestos.PPuestoIDNP = row.Cells("clmIDPuestoNP").Value
                    Departamentos.PDepartamentoIDNP = row.Cells("clmIDdepartamentoNP").Value


                    '''''''''''''''''''''''''''''
                    ''LLENADO DATOS NOMINA
                    '''''''''''''''''''''''''''''
                    Dim Nomina As New Entidades.ColaboradorNomina
                    Dim Patron As New Entidades.Patrones
                    Nomina.PSalarioDiario = row.Cells("clmSalarioDiario").Value
                    Nomina.PSalarioIntegrado = row.Cells("clmSalarioIntegrado").Value
                    Nomina.PNss = row.Cells("clmNSS").Value
                    Nomina.PFechaAltaImss = row.Cells("clmFechaAltaImss").Value
                    Patron.PpatronBD = row.Cells("clmDataSourceNP").Value
                    Patron.PServidor = row.Cells("clmServidor").Value
                    Patron.PNpatronalNP = row.Cells("clmRegistroPatronal").Value


                    ObjEntRep.PColaboradorNomina = Nomina
                    ObjEntRep.PColabordorLaboral = DatosLaborales
                    ObjEntRep.PColaborador = Datos
                    ObjEntRep.PCiudadesOrigen = CiudadOrigen
                    ObjEntRep.PCiudades = CiudadDomicilio
                    ObjEntRep.PEstados = EstadoDomicilio
                    ObjEntRep.PPuestos = Puestos
                    ObjEntRep.PDepartamentos = Departamentos
                    ObjEntRep.PPatrones = Patron


                    If row.Cells("clmIDColaboradorNP").Value > 0 Then
                        ObjBU.ReplciarColaboradoresUpdate(ObjEntRep, Patron.PpatronBD, Patron.PServidor)
                        ObjBU.ActualizarEditar(colaboradorID)
                    Else
                        ObjBU.ReplciarColaboradoresInsert(ObjEntRep, Patron.PpatronBD, Patron.PServidor)
                        ObjBU.ActualizarEditar(colaboradorID)
                    End If
                End If

            Next
            If estaMal > 0 Then
                Dim mensajeExito As New AvisoForm
                mensajeExito.MdiParent = Me.MdiParent
                mensajeExito.mensaje = "Algunos colaboradores no fueron replicados por duplicacion en su codigo de empleado."
                mensajeExito.Show()
            Else
                Dim mensajeExito As New ExitoForm
                mensajeExito.MdiParent = Me.MdiParent
                mensajeExito.mensaje = "Replicado correctamente."
                mensajeExito.Show()
            End If
        Catch ex As Exception

        End Try


    End Sub

    Private Sub grdReplicar_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles grdReplicar.CellValueChanged
        If e.ColumnIndex = 7 Then
            ValidarCampos()
            Dim objBU As New Negocios.ColaboradoresReplicarBU
            Dim tablaCodigo As New DataTable
            Dim nombre As String = ""
            Dim codigoEmp As String = ""
            If e.RowIndex >= 0 Then


                Dim ColaboradorID As Integer = 0
                Dim PatronBD As String = ""
                Dim PatronServidor As String = ""
                Dim contador As Integer = 0
                Dim ObjBUNomina As New Negocios.ColaboradorNominaBU
                Dim nombreLista As String = ""
                Dim tamanio As Integer = 0
                Dim Nomina As New Entidades.ColaboradorNomina
                Dim NominaReal As New Negocios.ColaboradorRealBU

                ColaboradorID = grdReplicar.Rows(e.RowIndex).Cells("clmIDColaborador").Value.ToString
                Nomina = ObjBUNomina.buscarColaborarNomina(ColaboradorID)
                PatronBD = Nomina.PPatron.PpatronBD
                PatronServidor = Nomina.PPatron.PServidor

                If grdReplicar.Rows(e.RowIndex).Cells("clmCodigoEmpleado").Value.ToString <> "" Then
                    codigoEmp = grdReplicar.Rows(e.RowIndex).Cells("clmCodigoEmpleado").Value.ToString


                    tablaCodigo = objBU.validarCodigoEmpleadoNPSAY(codigoEmp, PatronBD, PatronServidor)
                    nombreLista = ExisteEnLista(codigoEmp)
                    nombre = "El codigo de empleado " + codigoEmp + " esta utilizado por: " + nombreLista + " "
                    For Each row As DataRow In tablaCodigo.Rows
                        nombre += row("nombrelargo") + ", "
                        grdReplicar.Rows(e.RowIndex).Cells("clmCodigoEmpleado").Value = ""
                        contador += 1
                    Next
                    tamanio = nombre.Length
                    nombre = nombre.Remove(tamanio - 2)

                    If contador > 0 Or nombreLista <> "" Then
                        MsgBox(nombre)
                    End If
                End If
            End If
            ValidarCampos()
        End If
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        grbParametros.Height = 113
    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        grbParametros.Height = 45
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub SeleccionarTodosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SeleccionarTodosToolStripMenuItem.Click
        For Each row As DataGridViewRow In grdReplicar.Rows
            row.Cells("clmReplicar").Value = True
        Next
    End Sub

    Private Sub DeseleccionarTodosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeseleccionarTodosToolStripMenuItem.Click
        For Each row As DataGridViewRow In grdReplicar.Rows
            row.Cells("clmReplicar").Value = False
        Next
    End Sub

    Private Function ExisteEnLista(ByVal rol As String) As String
        Dim codigoEmp As String = ""
        For Each row As DataGridViewRow In grdReplicar.Rows
            Dim verificar As String = Convert.ToString(row.Cells("clmCodigoEmpleado").Value)
            If rol = verificar Then
                'MessageBox.Show("El  codigo de empleado: " + rol + "  " + " ya se asigno en la lista")
                codigoEmp += row.Cells("clmColaborador").Value + ", "
            End If
        Next
        Return codigoEmp
    End Function


    Public Sub ValidarCampos()
        Dim Servidor As String = ""
        Dim BD As String = ""
        'Dim ColaboradorID As Integer = 0
        Dim ColaboradorIDNP As Integer = 0
        Dim CodigoEmpleado As String = ""
        Dim Colaborador As String = ""
        Dim Puesto As String = ""
        Dim PuestoID As Integer = 0
        Dim PuestoIDNP As Integer = 0
        Dim Departamento As String = ""
        Dim DepartamentoID As Integer = 0
        Dim DepartamentoIDNP As Integer = 0
        Dim Nave As String = ""
        Dim NAveID As Integer = 0

        'Dim FechaNac As DateTime
        Dim EstadoCivil As String = ""
        Dim Sexo As String = ""
        Dim Curp As String = ""
        Dim NSS As String = ""
        Dim RFC As String = ""
        Dim SalarioDiario As Double = 0
        Dim Salario As Double = 0
        Dim SalarioIntegrado As Double = 0
        'Dim FechaAltaIMSS As DateTime
        'Dim FechaAltaInfonavit As DateTime
        Dim Calle As String = ""
        Dim NumDomicilio As String = ""
        Dim Colonia As String = ""
        Dim CP As Integer = 0
        Dim Ciudad As Integer = 0
        Dim EstadoNombre As String = ""
        Dim CiudadNombre As String = ""
        Dim CiudadOrigen As Integer = 0
        Dim CiudadOrigenNombre As String = ""


        Dim diasTrabajados As Integer = 0
        'Dim FechaIngreso As DateTime
        Dim AntiguedadAnios As Integer = 0
        Dim FactorIntegracion As Double = 0

        Dim DatasoucePatron As String = ""
        Dim RegistroPatronal As String = ""
        Dim estamal As Integer = 0
        For Each row As DataGridViewRow In grdReplicar.Rows

            Servidor = row.Cells("clmServidor").Value
            If Servidor = "" Then
                row.Cells("clmColaborador").Style.BackColor = Color.OrangeRed
                row.Cells("clmEstabien").Value = False
                estamal += 1
            End If

            BD = row.Cells("clmDataSourceNP").Value
            If BD = "" Then
                row.Cells("clmColaborador").Style.BackColor = Color.OrangeRed
                row.Cells("clmEstabien").Value = False
                estamal += 1
            End If


            CodigoEmpleado = row.Cells("clmCodigoEmpleado").Value
            If CodigoEmpleado = "" Then
                row.Cells("clmCodigoEmpleado").Style.BackColor = Color.Salmon
                row.Cells("clmEstabien").Value = False
                estamal += 1
            End If

            Departamento = row.Cells("clmDepartamento").Value
            If Departamento = "" Then
                row.Cells("clmDepartamento").Style.BackColor = Color.Salmon
                row.Cells("clmEstabien").Value = False
                estamal += 1
            End If


            Puesto = row.Cells("clmPuesto").Value
            If Puesto = "" Then
                row.Cells("clmPuesto").Style.BackColor = Color.Salmon
                row.Cells("clmEstabien").Value = False
                estamal += 1
            End If

            CiudadOrigenNombre = row.Cells("clmCiudadOrigen").Value
            If CiudadOrigenNombre = "" Then
                row.Cells("clmCiudadOrigen").Style.BackColor = Color.Salmon
                row.Cells("clmEstabien").Value = False
                estamal += 1
            End If


            EstadoCivil = row.Cells("clmEstadoCivil").Value
            If EstadoCivil = "" Then
                row.Cells("clmEstadoCivil").Style.BackColor = Color.Salmon
                row.Cells("clmEstabien").Value = False
                estamal += 1
            End If


            Sexo = row.Cells("clmSexo").Value
            If Sexo = "" Then
                row.Cells("clmSexo").Style.BackColor = Color.Salmon
                row.Cells("clmEstabien").Value = False
                estamal += 1
            End If

            Curp = row.Cells("clmCurp").Value
            If Curp.Length <> 18 Then
                row.Cells("clmCurp").Style.BackColor = Color.Salmon
                row.Cells("clmEstabien").Value = False
                estamal += 1
            End If


            NSS = row.Cells("clmNSS").Value
            If NSS.Length <> 11 Then
                row.Cells("clmNSS").Style.BackColor = Color.Salmon
                row.Cells("clmEstabien").Value = False
                estamal += 1
            End If

            RFC = row.Cells("clmRFC").Value
            If RFC.Length <> 13 Then
                row.Cells("clmRFC").Style.BackColor = Color.Salmon
                row.Cells("clmEstabien").Value = False
                estamal += 1
            End If

            Calle = row.Cells("clmCalle").Value
            If Calle = "" Then
                row.Cells("clmCalle").Style.BackColor = Color.Salmon
                row.Cells("clmEstabien").Value = False
                estamal += 1
            End If

            NumDomicilio = row.Cells("clmNumDomicilio").Value
            If NumDomicilio = "" Then
                row.Cells("clmNumDomicilio").Style.BackColor = Color.Salmon
                row.Cells("clmEstabien").Value = False
                estamal += 1

            End If


            Colonia = row.Cells("clmColonia").Value
            If Colonia = "" Then
                row.Cells("clmColonia").Style.BackColor = Color.Salmon
                row.Cells("clmEstabien").Value = False
                estamal += 1
            End If

            CP = row.Cells("clmCP").Value
            If CP.ToString = "" Then
                row.Cells("clmCP").Style.BackColor = Color.Salmon
                row.Cells("clmEstabien").Value = False
                estamal += 1
            End If


            CiudadNombre = row.Cells("clmCiudad").Value
            If CiudadNombre = "" Then
                row.Cells("clmCiudad").Style.BackColor = Color.Salmon
                row.Cells("clmEstabien").Value = False
                estamal += 1
            End If

            DepartamentoIDNP = row.Cells("clmIDdepartamentoNP").Value
            If DepartamentoIDNP = 0 Then
                row.Cells("clmDepartamento").Style.BackColor = Color.Tomato
                row.Cells("clmEstabien").Value = False
                estamal += 1
            End If

            PuestoIDNP = row.Cells("clmIDPuestoNP").Value
            If PuestoIDNP = 0 Then
                row.Cells("clmPuesto").Style.BackColor = Color.Tomato
                row.Cells("clmEstabien").Value = False
                estamal += 1
            End If

            RegistroPatronal = row.Cells("clmRegistroPatronal").Value
            If RegistroPatronal.ToString = "" Then
                row.Cells("clmRegistroPatronal").Style.BackColor = Color.Salmon
                row.Cells("clmEstabien").Value = False
                estamal += 1
            End If

            If estamal > 0 Then
                row.DefaultCellStyle.BackColor = Color.LightSalmon
                row.Cells("clmEstabien").Value = False
                row.Cells("clmReplicar").ReadOnly = True
                estamal = 0
            Else
                row.Cells("clmCodigoEmpleado").Style.BackColor = Color.White
                row.DefaultCellStyle.BackColor = Color.White
                row.Cells("clmEstabien").Value = True
                row.Cells("clmReplicar").ReadOnly = False
                estamal = 0
            End If

        Next
    End Sub
End Class