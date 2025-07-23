Imports System.Windows.Forms
Imports Framework.Negocios
Imports Entidades
Imports System.Deployment
Imports System.Deployment.Application

Public Class MDIParent

    Private Sub MDIParent_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim ctl As Control
        Dim ctlMDI As MdiClient

        tslVersion.Text = "Usuario: " + SesionUsuario.UsuarioSesion.PUserUsername + " | Publicación: " + My.Settings.publicacion + " | Versión: "
        If ApplicationDeployment.IsNetworkDeployed Then
            tslVersion.Text = tslVersion.Text + ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString
        End If


        For Each ctl In Me.Controls
            Try
                ' Attempt to cast the control to type MdiClient.
                ctlMDI = CType(ctl, MdiClient)

                ' Set the BackColor of the MdiClient control.
                ctlMDI.BackColor = Me.BackColor

            Catch exc As InvalidCastException
                ' Catch and ignore the error if casting failed.
            End Try
        Next

        'INICIA CARGA DE MENU
        Dim ObjModulosBU As New ModulosBU
        Dim Nivel1 As New List(Of Modulos)
        Nivel1 = ObjModulosBU.menu("ESCRITORIO")

        For Each Modulo As Modulos In Nivel1
            Dim MenuItem As New ToolStripMenuItem(Modulo.PNombre)
            MenuItem.BackColor = Color.White
            Try
                MenuItem.Image = CType(My.Resources.ResourceManager.GetObject(Modulo.PIcono), Image)
            Catch
            End Try
            'Busca los hijos del menu principal
            Dim Nivel2 As New List(Of Modulos)
            Nivel2 = ObjModulosBU.ChildModules(Modulo.PModuloid, "ESCRITORIO")
            For Each SubModulo As Modulos In Nivel2
                Dim SubMenuItem As New ToolStripMenuItem(SubModulo.PNombre)
                SubMenuItem.BackColor = Color.White
                Try
                    'SubMenuItem.Image = CType(My.Resources.ResourceManager.GetObject(SubModulo.PIcono), Image)
                Catch
                End Try
                'Busca los hijos del submenu
                Dim Nivel3 As New List(Of Modulos)
                Nivel3 = ObjModulosBU.ChildModules(SubModulo.PModuloid, "ESCRITORIO")
                For Each ChildModulo As Modulos In Nivel3
                    Dim ChildMenuItem As New ToolStripMenuItem(ChildModulo.PNombre, Nothing, New EventHandler(AddressOf MenuClick))
                    ChildMenuItem.BackColor = Color.White
                    'Dim ChildMenuItem As New ToolStripMenuItem(ChildModulo.PNombre)
                    Try
                        ' ChildMenuItem.Image = CType(My.Resources.ResourceManager.GetObject(ChildModulo.PIcono), Image)
                    Catch ex As Exception
                    End Try

                    SubMenuItem.DropDownItems.Add(ChildMenuItem)
                Next
                'modificación para pintado cuando no tiene opciones en el tercer nivel
                If Nivel3.Count > 0 Then
                    MenuItem.DropDownItems.Add(SubMenuItem) 'Agrega hijos
                End If
            Next

            MenuStrip.Items.Add(MenuItem) 'Agrega padres
        Next

        ' Dim SalirItem As New ToolStripMenuItem("Salir", Nothing, New EventHandler(AddressOf Salir))
        ' MenuStrip.Items.Add(SalirItem)
        'TERMINA CARGA DE MENU
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VE_LP_PRECIOBASE", "LIST_PRECIOS_ALERTA") Then
            AlertaListaVentas()
        End If

        'MUESTRA ALERTA DE APARTADOS CANCELADOS EN EL DIA
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ALM_ADMON_APARTADOS", "ALM_ADMON_APARTADOS_ALMACEN") Then
            AlertaApartadosCanceladosHoy()
        End If

        ''MUESTRA ALERTA DE SOLICITUDES RECHAZADAS
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ALERTA_SOL_RECHAZADAS", "READ") Then
            alertaSolicitudesRechazadas()
        End If

        ''MUESTRA ALERTA DE MOVIMIENTOS PENDIENTES DE NOMINA FISCAL
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ALERTA_MOV_PENDIENTES", "READ") Then
            alertaMovimientosPendientes()
        End If

        ''MUESTRA ALERTA DE PARES SIN PROGRAMAR DE PEDIDOS TERMINADOS
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("PARES_SIN_PROGRAMAR", "ALERTA_PARES_SIN_PROGRAMAR") Then
            alertaParesSinProgramarPedidosTerminados()
        End If

        ''MUESTRA ALERTA DE ALTA DE NUEVOS MODELOS
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("Prod_ConsultaListadoModelos", "READ") Then
            alertaNuevosModelosNavesDesarrollo()
        End If

        ''MUESTRA ALERTA DE ARTICULOS CON FECHA VIGENCIA 
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ALE_VIG_ART", "PROG_ART_FECH_VIGENCIA") Then
            alertaProgramacionArticulosConFechaVigencia()
        End If

        'MUESTRA ALERTA DEL ESTATUS DEL PLAN DE FABRICACIÓN ACTUAL 
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("PLAN_FABRICACION", "ALERTA_PLANFABRICA") Then
            notificacionPlanFabricacion()
        End If


        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("TIMBRES", "READ") Then
            alertaContadordeTimbres()
        End If

        Dim objPantallaMostrar As New MigracionInfraestucturaBU
        Dim dtPantallaMostrar As New DataTable
        dtPantallaMostrar = objPantallaMostrar.obtenerAlertaMigracion(0)
        If dtPantallaMostrar.Rows.Count > 0 Then
            If CInt(dtPantallaMostrar.Rows(0).Item(0)) = 1 Then
                AlertaMigracionInfraestructuraForm.ShowDialog() '' pantalla 1
            End If
            If CInt(dtPantallaMostrar.Rows(0).Item(0)) = 2 Then
                AlertaDiasMigracionInfraestructuraForm.ShowDialog() '' pantalla 2
            End If
            If CInt(dtPantallaMostrar.Rows(0).Item(0)) = 3 Then
                AlertaFechaMigracionInfraestructuraForm.ShowDialog() '' pantalla 3
            End If
        End If

        GuardarInformacionInicioSesion()

    End Sub

    Public Sub notificacionPlanFabricacion()
        Dim objBU As New Programacion.Vista.Programacion_PlanFabricacion
        Dim dtObtieneInformacionAlerta As New DataTable
        Dim semanaActual As Integer = If(DatePart(DateInterval.Year, Now) = 2021, DatePart(DateInterval.WeekOfYear, Now, FirstDayOfWeek.Monday, FirstWeekOfYear.Jan1) - 1, DatePart(DateInterval.WeekOfYear, Now, FirstDayOfWeek.Monday, FirstWeekOfYear.Jan1)) - 1
        Dim AñoActual As Integer = Now.Year
        Dim Caption = "Notificación" + vbLf + vbLf

        Try
            dtObtieneInformacionAlerta = objBU.GenerarAlertaDesdeMDIParent(SesionUsuario.UsuarioSesion.PUserUsuarioid, semanaActual, AñoActual)

            If dtObtieneInformacionAlerta.Rows.Count > 0 Then

                For Each row As DataRow In dtObtieneInformacionAlerta.Rows

                    Select Case row.Item("Estatus").ToString()

                        Case "SOLICITA MODIFICACIONES"
                            Dim mensaje As String = "Plan Fabricación" + vbLf + "Plan Solicita Modificaciones Nave " + row.Item("Nave").ToString() + vbLf + "Semana " + row.Item("Semana").ToString()
                            Alerta.Show(MDIParent, Caption, mensaje, "", My.Resources.incorrecta, mensaje)

                        Case "AUTORIZADO"
                            Dim mensaje As String = "Plan Fabricación" + vbLf + "Plan Autorizado " + row.Item("Nave").ToString() + vbLf + "Semana " + row.Item("Semana").ToString()
                            Alerta.Show(MDIParent, Caption, mensaje, "", My.Resources.incorrecta, mensaje)

                        Case "ENVIADO PPCP"
                            Dim mensaje As String = "Plan Fabricación" + vbLf + "Plan Enviado PPCP Nave " + row.Item("Nave").ToString() + vbLf + "Semana " + row.Item("Semana").ToString()
                            Alerta.Show(MDIParent, Caption, mensaje, "", My.Resources.incorrecta, mensaje)

                    End Select
                Next
            End If


        Catch ex As Exception

        End Try

    End Sub

    'Private Sub Alerta_BeforeFormShow(sender As Object, e As DevExpress.XtraBars.Alerter.AlertFormEventArgs) Handles Alerta.BeforeFormShow
    '    e.AlertForm.OpacityLevel = 1
    'End Sub

    'Private Sub Alerta_AlertClick(sender As Object, e As DevExpress.XtraBars.Alerter.AlertClickEventArgs) Handles Alerta.AlertClick
    '    Dim PlanFabricacionPantalla As New Programacion.Vista.Programacion_PlanFabricacion
    '    PlanFabricacionPantalla.MdiParent = Me
    '    PlanFabricacionPantalla.Show()
    'End Sub


    Public Sub AlertaListaVentas()
        Dim objAlert As New Negocios.AlertasBU
        Dim objFormALertaLV As New Ventas.Vista.frmAlertaListaVentas
        Dim dtDatosClienteLVTemp As New DataTable
        Dim dtDatosListasVigenciasProx As New DataTable

        dtDatosClienteLVTemp = objAlert.consultaClientesTemporal
        dtDatosListasVigenciasProx = objAlert.consultaVigenciasProximasLVS

        If dtDatosClienteLVTemp.Rows.Count > 0 Or dtDatosListasVigenciasProx.Rows.Count > 0 Then

            If dtDatosClienteLVTemp.Rows.Count > 0 Then
                objFormALertaLV.dtClientesLVTemporales = dtDatosClienteLVTemp
            End If

            If dtDatosListasVigenciasProx.Rows.Count > 0 Then
                objFormALertaLV.dtListasVigenciaProxima = dtDatosListasVigenciasProx
            End If

            objFormALertaLV.MdiParent = Me
            objFormALertaLV.Show()

        End If

    End Sub

    Public Sub AlertaApartadosCanceladosHoy()
        Dim objFormAlertaApartados As New Ventas.Vista.AlertaApartadosCancelados
        objFormAlertaApartados.InicioDeSesion = 1
        objFormAlertaApartados.MdiParent = Me
        objFormAlertaApartados.Show()

    End Sub

    Private Sub MenuClick(ByVal sender As Object,
    ByVal e As System.EventArgs)
        Dim NombreForma As String
        NombreForma = Me.buscarComponente(sender.ToString)
        Try
            Me.AbrirForma(NombreForma, sender.ToString)
        Catch ex As Exception
            MsgBox("Forma bajo construccion", MsgBoxStyle.Exclamation, "Technical Error")
        End Try
    End Sub

    Private Function buscarComponente(ByVal NombreForma As String) As String
        Dim objModulosBU As New ModulosBU
        Return objModulosBU.BuscarComponente(NombreForma)

    End Function

    Private Sub AbrirForma(ByVal objectName As String, Optional ByVal RutaMenu As String = "")
        Dim objForm As Form



        Dim s As String = objectName

        Dim words As String() = s.Split(New Char() {"."c})



        ' Use For Each loop over words and display them
        Dim word As String
        Dim count As Int32 = 1
        Dim assemblyName As String = ""
        Dim className As String = ""
        For Each word In words
            If count = 1 Then
                assemblyName = word + "."
            End If
            If count = 2 Then
                assemblyName += word
            End If
            If count = 3 Then
                className = word
            End If
            count += 1
        Next

        assemblyName = assemblyName.Replace("Framework.Vista", "Framework.Vista.SAPY")
        objectName = objectName.Replace("Framework.Vista", "Framework.Vista.SAPY")

        'If My.Settings.publicacion = "SAY_PRUEBAS" Then
        '    assemblyName = assemblyName.Replace("Framework.Vista", "Framework.Vista.SAPY.Pruebas")
        '    objectName = objectName.Replace("Framework.Vista", "Framework.Vista.SAPY.Pruebas")
        'End If

        Dim t As Type = System.Type.GetType(objectName + "," + assemblyName, True, True)
        'Dim t As Type = System.Type.GetType(objectName, True, True)
        If Not IsNothing(t) Then
            Dim Fullname As String = objectName
            t = Type.GetType(Fullname + "," + assemblyName, True, True)
        End If
        objForm = CType(Activator.CreateInstance(t), Form)
        objForm.MdiParent = Me
        'm_ChildFormNumber += 1

        If RutaMenu = "Inventario Disponible con Fotografía AG" Then

            If words(2).ToString = "InventarioDisponibleConFotografiaform" Then
                objForm.Text = "AGENTE"
                'objForm.ReporteAgente = True
                objForm.Show()
            End If

        Else
            objForm.Show()
        End If


    End Sub

    Private Sub Salir(ByVal sender As Object,
    ByVal e As System.EventArgs)
        Application.Exit()
    End Sub

    Private Sub ToolStripStatusLabel5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim forma As New SesionUsuarios
        forma.MdiParent = Me
        forma.usuarioid = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        forma.Show()
    End Sub

    Private Sub ToolStripStatusLabel6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Dim colores As New ConfiguracionColoresForm
        'colores.MdiParent = Me.MdiParent
        'colores.Show()

        Dim formacolores As New Tools.ConfiguracionColoresForm
        formacolores.Show()
        formacolores.MdiParent = Me.MdiParent
        formacolores.Show()
    End Sub

    Private Sub MDIParent_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        LoginForm.Close()
    End Sub

    Public Sub alertaSolicitudesRechazadas()
        Dim objAlert As New Negocios.AlertasBU
        Dim objFormALerta As New Contabilidad.Vista.AlertaSolicitudesRechazadasForm
        Dim dtSolicitudesRechazadas As New DataTable

        dtSolicitudesRechazadas = objAlert.consultaSolicitudesRechazadas

        If dtSolicitudesRechazadas.Rows.Count > 0 Then

            If dtSolicitudesRechazadas.Rows.Count > 0 Then
                objFormALerta.dtSolicitudesRechazadas = dtSolicitudesRechazadas
            End If

            objFormALerta.MdiParent = Me
            objFormALerta.Show()

        End If
    End Sub

    Public Sub alertaMovimientosPendientes()
        Dim objAlert As New Negocios.AlertasBU
        Dim objFormALerta As New Contabilidad.Vista.AlertaMovimientosPendientesForm
        Dim dtListado As New DataTable

        dtListado = objAlert.consultaListadoMovimientosPendientes

        If dtListado.Rows.Count > 0 Then

            If dtListado.Rows.Count > 0 Then
                objFormALerta.dtMovmientosPendientes = dtListado
            End If

            objFormALerta.MdiParent = Me
            objFormALerta.Show()

        End If
    End Sub

    Private Sub alertaParesSinProgramarPedidosTerminados()
        Dim objFormAlerta As New Ventas.Vista.AlertaParesSinProgramar
        objFormAlerta.MdiParent = Me
        objFormAlerta.Show()
    End Sub

    Private Sub alertaContadordeTimbres()
        Dim objFormContadordeTimbres As New Contabilidad.Vista.ContadorTimbres_Form
        objFormContadordeTimbres.MdiParent = Me
        objFormContadordeTimbres.Show()
    End Sub

    Private Sub alertaNuevosModelosNavesDesarrollo()
        Dim objFormAlerta As New Produccion.Vista.ConsultaListadoModelosForm
        Dim dtListado As Integer = 0

        dtListado = objFormAlerta.verificarInformacion(SesionUsuario.UsuarioSesion.PUserUsuarioid)

        If dtListado = 1 Then
            objFormAlerta.MdiParent = Me
            objFormAlerta.Show()
        End If
    End Sub

    Private Sub alertaProgramacionArticulosConFechaVigencia()
        Dim objFormAlerta As New Ventas.Vista.Ventas_Alerta_VigenciaArticulosForm
        Dim dtListado As New DataTable

        objFormAlerta.inicio = 1

        dtListado = objFormAlerta.CargarArticulosConFechaVigencia()

        If dtListado.Rows.Count > 0 Then
            objFormAlerta.MdiParent = Me

            objFormAlerta.Show()
        End If


    End Sub

    Public Sub AlertaIngresoInventario()
        Dim objAlert As New Negocios.AlertasBU
        Dim objAlerta As New Proveedor.Vista.AlertaIngresosArticulosECommerceForm
        Dim objFormALertaLV As New Ventas.Vista.frmAlertaListaVentas
        Dim dtDatos As DataTable

        dtDatos = objAlert.ConsultaArticulosIngresados()

        If dtDatos.Rows.Count > 0 Then
            objAlerta.MdiParent = Me
            objAlerta.Show()
        End If

    End Sub

    '' OAMB - 20-03-2024
    Public Sub GuardarInformacionInicioSesion()
        'Dim objBU As New AuditoriaBU

        'Try
        '    '' Por temas de seguridad y posibles auditorias, guardamos la información del inicio de sesión de cada usuario.
        '    objBU.GuardarInformacionInicioSesion(SesionUsuario.UsuarioSesion.PUserUsername)
        'Catch ex As Exception

        'End Try

    End Sub

End Class
