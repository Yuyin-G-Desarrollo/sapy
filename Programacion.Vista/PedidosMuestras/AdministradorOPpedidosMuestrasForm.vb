Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid
Imports System.Text
Imports DevExpress.XtraPrinting
Imports Tools
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports DevExpress.XtraEditors
Imports Infragistics.Documents.Excel
Imports System.Text.RegularExpressions
Imports System.IO
Imports DevExpress.Utils.DragDrop
Imports DevExpress.Utils.Behaviors
Imports Entidades
Imports DevExpress.XtraExport.Helpers
Imports System.Net.WebRequestMethods



Public Class AdministradorOPpedidosMuestrasForm
    Dim objBU As New Programacion.Negocios.PedidosMuestrasOP

    Dim timerRevisionSesionAdminOP As New Timer '' CAMBIOS OAMB (22/5/2024) - Variables nuevas para los cambios del proyecto de muestras.mom
    Dim fechaInicioSesionActual As String = ""
    Dim usuarioIdFormulario As Integer = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
    Dim nombreFormulario As String = "AdministradorOPpedidosMuestrasForm"


    Dim listaDatosColocacionCompleto As List(Of DatosColocacion)
    Dim listaDatosColocacionPedido As List(Of DatosColocacion)


    '' -------------------------- Reporte Excel -------------------------- ''
    ''Dim rutaDescargas As String = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads")
    Dim rutaDescargas As String = "G:\2. PROCESOS\2.11 ESPECIALISTAS PROYECTOS\2.6.1 AMUESTRAS\2. PROGRAMACIÓN DE MUESTRAS\3. NAVES DE PRODUCCIÓN\"   '' Ruta del servidor de respaldo de Muestras.
    '' -------------------------- Reporte Excel -------------------------- ''


    Dim regexNumerosYLetras As New Regex("^(?=.*\d)[a-zA-Z0-9]+$")  '' https://regex101.com/ página para revisar las expresiones regulares.
    Dim regexCorrida As New Regex("^[0-9-½]+$")


    Private comportamientosTablaPrincipal As BehaviorManager
    ''Dim comportamientoDragDrop As IDisposable


    Dim Accion As Integer
    Dim RestriccionCuatroDias As Boolean = True '' Es obligatorio que la producción/entrega de muestras sea mayor a cuatro días del día actual.
    Dim consultarProduccion, consultarEnviados, ConsultarAutorizados, ConsultarProduccionEnviados, ConsultarAutorizadosBloqueados, consultarSoloReprocesos As Boolean
    Dim dtPedidosMuestras As New DataTable
    Dim vlstOrdenesEditadas As New List(Of Integer)
    Dim deptoDisCon As Boolean = False
    Dim deptoOtros As Boolean = False



    Public Sub New()
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        '' Agregamos toda modificación visual o de comportamiento de los controles (que no involucren consultas a la base de datos).
        ConsultarPermisos()
    End Sub
    Private Sub AdministradorOPpedidosMuestrasForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim usuario As Int32 = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid

        '' Agregamos toda modificación de los valores de los controles o manejo de la información de la pantalla que lo llama (variables públicas, etc).
        Me.Top = 0
        Me.Left = 0
        Me.WindowState = FormWindowState.Maximized
        Me.CenterToParent() 'Alineación al centro del form padre


        '' --------------- Configuraciones iniciales --------------- ''
        VerificarRutaDescargas()


        '' CAMBIOS OAMB (21/05/2024) - Habilitamos la posibilidad de seleciconar multiples líneas.
        Me.grdVPeidosMuestrasOP.OptionsSelection.MultiSelect = True
        Me.grdVPeidosMuestrasOP.OptionsSelection.MultiSelectMode = GridMultiSelectMode.RowSelect


        '' Inicializamos el comportamiento de nuestra tabla (DragDrop).
        comportamientosTablaPrincipal = New BehaviorManager(Me.components)


        grdVPeidosMuestrasOP.OptionsBehavior.Editable = True    '' CAMBIOS OAMB (09/05/2024) - Es necesario activar esta opción para que el evento ShowingEditor funcione de lo contrario no se activará nunca.


        lblNombreUsuarioSesion.Text = ""    '' CAMBIOS OAMB (22/05/2024) - Limpiamos el label. Nos servirá para la validación de la sesión.
        fechaInicioSesionActual = Date.Now.ToString("yyyy-MM-dd HH:mm:ss")
        '' --------------- Configuraciones iniciales --------------- ''



        '' --------------- Llenado de Combo Estatus --------------- ''

        Me.WindowState = FormWindowState.Maximized
        pnlNave.Visible = False
        Dim PedidosMuestrasOPNegocios As New Programacion.Negocios.PedidosMuestrasOP
        Dim EsEncargadoDeNave As Boolean = PedidosMuestrasOPNegocios.EsEncargadoDeNave(usuario)


        'Creo mi datatable y columnas
        Dim dtEstatus As New DataTable
        dtEstatus.Columns.Add("id")
        dtEstatus.Columns.Add("Descripcion")

        Dim dtNaves As DataTable
        'dtNaves = PedidosMuestrasOPNegocios.VerListaComboNaves(usuario)
        dtNaves = PedidosMuestrasOPNegocios.obtenerNaveReproceso(usuario)
        If dtNaves.Rows.Count > 0 Then
            cmbNaveMenu.DisplayMember = "nave"
            cmbNaveMenu.ValueMember = "id"
            cmbNaveMenu.DataSource = dtNaves
        End If

        'Renglon es la variable que adicionara renglones a mi datatable
        Dim Renglon As DataRow = dtEstatus.NewRow()

        If consultarSoloReprocesos = False Then
            If ConsultarAutorizados Then
                Renglon = dtEstatus.NewRow()
                Renglon("id") = 1
                Renglon("Descripcion") = "AUTORIZADOS PRODUCCION"
                dtEstatus.Rows.Add(Renglon)
            End If
            If ConsultarAutorizadosBloqueados Then
                Renglon = dtEstatus.NewRow()
                Renglon("id") = 5
                Renglon("Descripcion") = "AUTORIZADOS BLOQUEADOS"
                dtEstatus.Rows.Add(Renglon)
            End If
            If consultarProduccion Then
                Renglon = dtEstatus.NewRow()
                Renglon("id") = 2
                Renglon("Descripcion") = "EN PRODUCCION"
                dtEstatus.Rows.Add(Renglon)
            End If
            If consultarEnviados Then
                Renglon = dtEstatus.NewRow()
                Renglon("id") = 3
                Renglon("Descripcion") = "ENVIADOS"
                dtEstatus.Rows.Add(Renglon)
            End If

            If ConsultarProduccionEnviados Then
                Renglon = dtEstatus.NewRow()
                Renglon("id") = 4
                Renglon("Descripcion") = "EN PRODUCCION Y ENVIADOS"
                dtEstatus.Rows.Add(Renglon)
            End If
        End If

        If consultarSoloReprocesos = True And consultarProduccion = True Then '' PERMISO SOLO PARA VER REPROCESOS
            Renglon = dtEstatus.NewRow()
            Renglon("id") = 6
            Renglon("Descripcion") = "REPROCESO"
            dtEstatus.Rows.Add(Renglon)

            Renglon = dtEstatus.NewRow()
            Renglon("id") = 2
            Renglon("Descripcion") = "EN PRODUCCION"
            dtEstatus.Rows.Add(Renglon)

            If ConsultarProduccionEnviados Then
                Renglon = dtEstatus.NewRow()
                Renglon("id") = 4
                Renglon("Descripcion") = "EN PRODUCCION Y ENVIADOS"
                dtEstatus.Rows.Add(Renglon)
            End If

            If consultarEnviados Then
                Renglon = dtEstatus.NewRow()
                Renglon("id") = 3
                Renglon("Descripcion") = "ENVIADOS"
                dtEstatus.Rows.Add(Renglon)
            End If

        End If

        cmbEstatus.DisplayMember = "Descripcion"
        cmbEstatus.ValueMember = "id"
        cmbEstatus.DataSource = dtEstatus

        '''''Creo mi datatable y columnas
        ''''Dim dtEstatus As New DataTable
        ''''dtEstatus.Columns.Add("id")
        ''''dtEstatus.Columns.Add("Descripcion")

        '''''Renglon es la variable que adicionara renglones a mi datatable
        ''''Dim Renglon As DataRow = dtEstatus.NewRow()

        '''''' Renglón vacío.
        ''''Renglon = dtEstatus.NewRow()
        ''''Renglon("id") = 0
        ''''Renglon("Descripcion") = ""
        ''''dtEstatus.Rows.Add(Renglon)

        ''''If ConsultarAutorizados Then
        ''''    Renglon = dtEstatus.NewRow()
        ''''    Renglon("id") = 1
        ''''    Renglon("Descripcion") = "AUTORIZADOS PRODUCCION"
        ''''    dtEstatus.Rows.Add(Renglon)
        ''''End If

        ''''If ConsultarAutorizadosBloqueados Then
        ''''    Renglon = dtEstatus.NewRow()
        ''''    Renglon("id") = 5
        ''''    Renglon("Descripcion") = "AUTORIZADOS BLOQUEADOS"
        ''''    dtEstatus.Rows.Add(Renglon)
        ''''End If

        ''''If consultarProduccion Then
        ''''    Renglon = dtEstatus.NewRow()
        ''''    Renglon("id") = 2
        ''''    Renglon("Descripcion") = "EN PRODUCCION"
        ''''    dtEstatus.Rows.Add(Renglon)
        ''''End If

        ''''If consultarEnviados Then
        ''''    Renglon = dtEstatus.NewRow()
        ''''    Renglon("id") = 3
        ''''    Renglon("Descripcion") = "ENVIADOS"
        ''''    dtEstatus.Rows.Add(Renglon)
        ''''End If

        ''''If ConsultarProduccionEnviados Then
        ''''    Renglon = dtEstatus.NewRow()
        ''''    Renglon("id") = 4
        ''''    Renglon("Descripcion") = "EN PRODUCCION Y ENVIADOS"
        ''''    dtEstatus.Rows.Add(Renglon)
        ''''End If

        ''''If ConsultarProduccionEnviados Then
        ''''    Renglon = dtEstatus.NewRow()
        ''''    Renglon("id") = 6
        ''''    Renglon("Descripcion") = "REPROCESO"
        ''''    dtEstatus.Rows.Add(Renglon)
        ''''End If

        ''''cmbEstatus.DisplayMember = "Descripcion"    ''  <-------------------- Aquí se activa el evento del selected index y llena la tabla con la información.
        ''''cmbEstatus.ValueMember = "id"
        ''''cmbEstatus.DataSource = dtEstatus

        '' --------------- Llenado de Combo Estatus --------------- ''



        Dim FechaActual As Date = Date.Now
        Dim DiaSemana As Integer = FechaActual.DayOfWeek
        Dim FechaInicio As Date
        Dim FechaFin As Date

        If DiaSemana >= 1 Then
            FechaInicio = FechaActual.AddDays((1 - DiaSemana))
        Else
            FechaInicio = FechaActual.AddDays(1)
        End If
        FechaFin = FechaActual.AddDays(6 - DiaSemana)
        dtpFechaInicio.Value = FechaInicio
        dtpFechaFin.Value = FechaFin
    End Sub
    Private Sub AdministradorOPpedidosMuestrasForm_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        '' Agregamos toda consulta de información a la base de datos o de llenado de controles.
        Try
            'LlenarNaves()

            '' Asignamos el método de búsqueda al combo de los estatus.
            AddHandler cmbEstatus.SelectedIndexChanged, AddressOf switch
            cmbEstatus.SelectedIndex = 1    '' Se selecciona el primer estatus. Al seleccionar el estatus consultan las OPs.


            '' Se quita la revisión de las sesiones. CAMBIOS OAMB (22/05/2024) - Petición de Josué.
            'RegistrarSesionActual(usuarioIdFormulario, nombreFormulario)  '' CAMBIOS OAMB (22/05/2024) - Registramos la sesión del usuario al formulario.
            'ConsultarSesionActualAdministradorOPMuestras()  '' CAMBIOS OAMB (27/05/2024) - Consultamos la sesión para que actualice desde un inicio.


            'IniciarTimerConsultarSesiones() '' CAMBIOS OAMB (22/05/2024) - Timer para consultar la sesión de la pantalla.
        Catch ex As Exception
            Tools.MostrarMensaje(Mensajes.Warning, "A ocurrido un error al cargar la información del análisis: " + ex.Message)
        End Try
    End Sub



    Private Sub LlenarNaves()
        Dim PedidosMuestrasOPNegocios As New Programacion.Negocios.PedidosMuestrasOP
        Dim dtNaves As DataTable

        Try
            dtNaves = PedidosMuestrasOPNegocios.VerListaComboNaves(usuarioIdFormulario)

            cmbNaveMenu.DisplayMember = "Descripcion"
            cmbNaveMenu.ValueMember = "id"
            cmbNaveMenu.DataSource = dtNaves

            Dim dr As DataRow
            dr = dtNaves.NewRow()
            dr("Descripcion") = " "
            dr("id") = 0
            dtNaves.Rows.Add(dr)
        Catch ex As Exception
            Tools.MostrarMensaje(Mensajes.Warning, "A ocurrido un error al llenar la tabla de las naves:" + ex.Message)
        End Try
    End Sub
    Private Sub ConsultarPermisos()
        Try
            '' --------------- Permisos especiales --------------- ''

            If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ADMIN_OP_MUESTRAS", "GENERAR_OP") Then
                pnlGenerarOP.Visible = True
                'btnGenerarOP.Visible = True
                'lblGenerarOP.Visible = True
            End If
            If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ADMIN_OP_MUESTRAS", "ENVIAR") Then
                'btnEnviar.Visible = True
                'lblEnviar.Visible = True
            End If
            If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ADMIN_OP_MUESTRAS", "IMPRIMIR") Then
                pnlImprimirEtiquetas.Visible = True
                'btnImprimirEtiquetas.Visible = True
                'lblImprimirEtiquetas.Visible = True
            End If



            If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ADMIN_OP_MUESTRAS", "CONSULTAR_PROD") Then
                consultarProduccion = True
                ConsultarProduccionEnviados = True
            End If
            If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ADMIN_OP_MUESTRAS", "CONSULTAR_ENV") Then
                consultarEnviados = True
                ConsultarProduccionEnviados = True
            End If
            If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ADMIN_OP_MUESTRAS", "CONSULTAR_AUT") Then
                ConsultarAutorizados = True
            End If
            If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ADMIN_OP_MUESTRAS", "GENERAR_OP_DIS_CON") Then
                deptoDisCon = True
            End If
            If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ADMIN_OP_MUESTRAS", "GENERAR_OP_OTROSDEPTOS") Then
                deptoOtros = True
            End If
            If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ADMIN_OP_MUESTRAS", "CONSULTAR_AUTBLOQ") Then
                ConsultarAutorizadosBloqueados = True
            End If
            If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ADMIN_OP_MUESTRAS", "CONSULTAR_REPROCESOS_NAVES") Then '' PERMISOS PARA SOLO VER LOS REPROCESOS
                consultarSoloReprocesos = True
            End If
            If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ADMIN_OP_MUESTRAS", "ACTUALIZAR_COLOCACION_GERENCIA") Then '' CAMBIOS OAMB (22/05/2024) - Se agrega un permiso especial para el gerente de muestras que permite modificar la colocación como prefiera sin ir en orden.
                RestriccionCuatroDias = False   '' El gerente puede poner la fecha de entrega de las muestras sin restricciones.
            End If

            '' --------------- Permisos especiales --------------- ''
        Catch ex As Exception
            Tools.MostrarMensaje(Mensajes.Warning, "A ocurrido un error al consultar los permisos del usuario:" + ex.Message)
        End Try
    End Sub

    Private Sub ValidaSeleccion(ByVal mensaje As String)
        Dim form As New AdvertenciaForm
        form.mensaje = mensaje
        form.ShowDialog()
    End Sub

    Private Function ValidaAlta() As Boolean
        Dim NumeroFilas As Integer = 0
        Dim fila As Integer
        Dim Valida, sel As Boolean
        Dim obj As New Programacion.Negocios.PedidosMuestrasOP

        Cursor = Cursors.WaitCursor
        NumeroFilas = grdVPeidosMuestrasOP.DataRowCount
        For index As Integer = 0 To NumeroFilas Step 1
            fila = index + 1
            If grdVPeidosMuestrasOP.GetRowCellValue(index, "Sel") Then
                sel = True
                If grdVPeidosMuestrasOP.GetListSourceRowCellValue(index, "NaveDesarrollo").ToString <> "" Then  '' CAMBIOS OAMB (09/05/2024) - Pasa a ser NaveDesarrollo (Nave)
                    If grdVPeidosMuestrasOP.GetRowCellValue(index, "FechaEntregaPropuesta").ToString <> "" Then    '' CAMBIOS OAMB (09/05/2024) - Pasa a ser FechaEntregaPropuesta (FCorte)
                        If grdVPeidosMuestrasOP.GetRowCellValue(index, "DeptoId") = 294 And (
                                        (grdVPeidosMuestrasOP.GetRowCellValue(index, "PE_Status") = "6") Or
                                        (grdVPeidosMuestrasOP.GetRowCellValue(index, "PE_Status") = "7")) Then
                            Dim mensaje As New AdvertenciaForm
                            mensaje.mensaje = "El modelo " & grdVPeidosMuestrasOP.GetRowCellValue(index, "Modelo") & " del pedido " & grdVPeidosMuestrasOP.GetRowCellValue(index, "FolioDePedido") & " tiene estatus de " & grdVPeidosMuestrasOP.GetRowCellValue(index, "Estatus Articulo") & ", No se puede generar la Orden de Producción"
                            mensaje.ShowDialog()
                            grdVPeidosMuestrasOP.SetRowCellValue(index, "Sel", False)
                            Valida = False
                        ElseIf grdVPeidosMuestrasOP.GetRowCellValue(index, "DeptoId") <> 294 And (
                                (grdVPeidosMuestrasOP.GetRowCellValue(index, "PE_Status") = "1") Or
                                (grdVPeidosMuestrasOP.GetRowCellValue(index, "PE_Status") = "6") Or
                                (grdVPeidosMuestrasOP.GetRowCellValue(index, "PE_Status") = "7")) Then

                            Dim mensaje As New AdvertenciaForm
                            mensaje.mensaje = "El modelo " & grdVPeidosMuestrasOP.GetRowCellValue(index, "Modelo") & " del pedido " & grdVPeidosMuestrasOP.GetRowCellValue(index, "FolioDePedido") & " tiene estatus de " & grdVPeidosMuestrasOP.GetRowCellValue(index, "Estatus Articulo") & ", No se puede generar la Orden de Producción"
                            mensaje.ShowDialog()
                            grdVPeidosMuestrasOP.SetRowCellValue(index, "Sel", False)
                            Valida = False
                        Else
                            Valida = True
                        End If
                    Else
                        ValidaSeleccion("La fila " & fila.ToString & " seleccionada no contiene fecha de corte capturada.")
                        Exit For
                    End If
                Else
                    ValidaSeleccion("La fila " & fila.ToString & " seleccionada no contiene nave capturada.")
                    Exit For
                End If
            End If
        Next
        If sel = False Then ValidaSeleccion("No se encuentraron filas seleccionadas.")
        Cursor = Cursors.Default
        Return Valida
    End Function

    Private Function ValidaEnviar() As Boolean
        Dim NumeroFilas As Integer = 0
        Dim fila As Integer
        Dim Valida, sel As Boolean
        Dim obj As New Programacion.Negocios.PedidosMuestrasOP
        Cursor = Cursors.WaitCursor
        NumeroFilas = grdVPeidosMuestrasOP.DataRowCount
        For index As Integer = 0 To NumeroFilas Step 1
            fila = index + 1
            If grdVPeidosMuestrasOP.GetRowCellValue(index, "Sel") Then
                sel = True
                If IsNumeric(grdVPeidosMuestrasOP.GetListSourceRowCellValue(index, "Cantidad")) Then
                    If grdVPeidosMuestrasOP.GetRowCellValue(index, "Cantidad") > 0 Then
                        If Not CInt(grdVPeidosMuestrasOP.GetRowCellValue(index, "Cantidad")) > CInt(grdVPeidosMuestrasOP.GetRowCellValue(index, "Cantidad_resp")) Then
                            Dim pendientes As Integer
                            pendientes = obj.VerCantidadPendiente(grdVPeidosMuestrasOP.GetListSourceRowCellValue(index, "idUDM"),
                                                        grdVPeidosMuestrasOP.GetListSourceRowCellValue(index, "Articulo"),
                                                        grdVPeidosMuestrasOP.GetListSourceRowCellValue(index, "FolioDePedido"),
                                                        grdVPeidosMuestrasOP.GetListSourceRowCellValue(index, "Talla"),
                                                        grdVPeidosMuestrasOP.GetListSourceRowCellValue(index, "Cantidad"))


                            If pendientes = 0 Then
                                Valida = True
                            Else
                                ValidaSeleccion("La fila " & fila.ToString & " seleccionada no puede contener una cantidad mayor a la pendiente por enviar " + pendientes.ToString + ".")
                            End If
                        Else
                            ValidaSeleccion("La fila " & fila.ToString & " seleccionada no puede contener una cantidad mayor a la capturada.")
                        End If
                    Else
                        ValidaSeleccion("La fila " & fila.ToString & " seleccionada debe contener una cantidad mayor a 0 capturada.")
                        Exit For
                    End If
                Else
                    ValidaSeleccion("La fila " & fila.ToString & " seleccionada no contiene un numero valido capturada.")
                    Exit For
                End If
            End If
        Next
        If sel = False Then ValidaSeleccion("No se encuentraron filas seleccionadas.")
        Cursor = Cursors.Default
        Return Valida
    End Function





    Public Sub LlenarGridPedidosMuestrasOP(Optional ByVal Nave As Integer = 0, Optional ByVal FechaIni As String = "", Optional ByVal FechaFin As String = "")
        Dim PedidosMuestrasOPNegocios As New Programacion.Negocios.PedidosMuestrasOP
        Dim dtMuestrasReproceso As New DataTable
        Dim usuario As Int32 = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid

        Try
            Me.Cursor = Cursors.WaitCursor


            FechasEntregaMuestras(RestriccionCuatroDias)


            grdPedidosMuestrasOP.DataSource = Nothing
            grdVPeidosMuestrasOP.Columns.Clear()


            If (Accion = 1 Or Accion = 5) Then
                dtPedidosMuestras = PedidosMuestrasOPNegocios.VerListaPedidosMuestrasOPAutorizadoProdBloq(Accion, usuario, Nave, FechaIni, FechaFin)
            Else
                If consultarSoloReprocesos = True And consultarProduccion = True Then
                    If cmbEstatus.Text = "REPROCESO" Then
                        Dim dtNaveReproceso As New DataTable
                        dtNaveReproceso = PedidosMuestrasOPNegocios.obtenerNaveReproceso(usuario)
                        If dtNaveReproceso.Rows.Count > 0 Then
                            dtMuestrasReproceso = PedidosMuestrasOPNegocios.obtenerReporteMuestrasReprocesoPorNave(usuario, dtNaveReproceso.Rows(0).Item(0))
                        End If
                    Else
                        dtPedidosMuestras = PedidosMuestrasOPNegocios.VerListaPedidosMuestrasOP(Accion, usuario, Nave, FechaIni, FechaFin)
                    End If
                    'End If
                Else
                    dtPedidosMuestras = PedidosMuestrasOPNegocios.VerListaPedidosMuestrasOP(Accion, usuario, Nave, FechaIni, FechaFin)
                End If
            End If

            If consultarSoloReprocesos = False Then
                grdPedidosMuestrasOP.DataSource = dtPedidosMuestras
            Else
                If cmbEstatus.Text = "REPROCESO" Then
                    If dtMuestrasReproceso.Rows.Count > 0 Then
                        grdPedidosMuestrasOP.DataSource = dtMuestrasReproceso
                    End If
                Else
                    grdPedidosMuestrasOP.DataSource = dtPedidosMuestras
                End If
            End If

            If grdVPeidosMuestrasOP.RowCount > 0 Then
                DiseñoGridPedidosMuestrasOP(grdVPeidosMuestrasOP)

                If Accion = 1 Then
                    '' Generamos la colocación de las naves
                    chboxSeleccionarTodo.Checked = True
                    GeneracionColocacionPedidosCompleto(chboxSeleccionarTodo.Checked, dtpFechaEntregaPropuesta)
                    chboxSeleccionarTodo.Checked = False
                End If
            End If
        Catch ex As Exception
            Tools.MostrarMensaje(Mensajes.Warning, "A ocurrido un error al consultar los pedidos autorizados: " + ex.Message)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub


    ''Private Sub consultarNavesProduccionProducto(ByVal sender As Object, ByVal e As EventArgs)
    ''    Dim dtNavesProduccion As DataTable
    ''    Dim PedidosMuestrasOPNegocios As New Programacion.Negocios.PedidosMuestrasOP

    ''    Try
    ''        Dim productoEstiloId = grdVPeidosMuestrasOP.GetFocusedRowCellValue("Articulo")
    ''        Dim estatusProductoEstiloId = grdVPeidosMuestrasOP.GetFocusedRowCellValue("PE_Status")


    ''        dtNavesProduccion = objBU.ConsultarNavesProduccion(productoEstiloId, estatusProductoEstiloId)

    ''        If dtNavesProduccion IsNot Nothing Then
    ''            If dtNavesProduccion.Rows.Count > 0 Then
    ''                Dim lkueComboNaves As LookUpEdit = CType(sender, LookUpEdit)
    ''                Dim rileComboNavesSeleccionado As RepositoryItemLookUpEdit = CType(lkueComboNaves.Properties, RepositoryItemLookUpEdit)


    ''                rileComboNavesSeleccionado.DataSource = dtNavesProduccion
    ''                rileComboNavesSeleccionado.DropDownRows = dtNavesProduccion.Rows.Count
    ''            End If
    ''        End If

    ''    Catch ex As Exception

    ''    End Try
    ''End Sub


    Private Sub DiseñoGridPedidosMuestrasOP(ByVal Grid As DevExpress.XtraGrid.Views.Grid.GridView)

        '' ------------------ Formato general ------------------ ''

        lblMovimientoFilasEstatus.Text = "INACTIVO" '' Pasamos el valor por defecto del label que indica si es posible mover las filas de la tabla.

        chboxSeleccionarTodo.Checked = False    '' Quitamos la selección del check cada vez que se consulte la información.

        Grid.IndicatorWidth = 40
        Grid.ColumnPanelRowHeight = 30  '' Tamaño del nombre de las columnas
        'Grid.OptionsSelection.CheckBoxSelectorColumnWidth = 20 '' Tamaño de la columna de selección
        'Grid.OptionsSelection.MultiSelect = True
        'Grid.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect


        ''For Each columnaDetallado In Grid.Columns

        ''    '' El encabezado de cada columna podrá dar un salto de línea como crea necesario.
        ''    columnaDetallado.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        ''    '' Cambiar la búsqueda de los filtros por Contiene en vez de Comienza por.
        ''    columnaDetallado.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        ''Next

        DiseñoGrid.AlinearTextoEncabezadoColumnas(grdVPeidosMuestrasOP)
        DiseñoGrid.AlternarColorEnFilasTenue(grdVPeidosMuestrasOP)



        Grid.ClearSelection()
        Grid.OptionsView.ColumnAutoWidth = False
        Grid.OptionsView.BestFitMaxRowCount = -1

        '' ------------------ Formato general ------------------ ''



        '' AUTORIZADOS PRODUCCION (1) y AUTORIZADOS BLOQUEADOS (5).
        If Accion = 1 Or Accion = 5 Then

            '' - El combo de las naves se llena con todas las que tengan capacidades, de forma que en el llenado de las columnas se pueda seleccionar la nave de la consulta principal.
            Dim dt As DataTable
            Dim PedidosMuestrasOPNegocios As New Programacion.Negocios.PedidosMuestrasOP
            ''dt = PedidosMuestrasOPNegocios.VerListaComboNaves
            dt = objBU.ConsultarNavesProduccion()

            Dim rileComboNaves As New RepositoryItemLookUpEdit
            rileComboNaves.DataSource = dt
            rileComboNaves.DisplayMember = "Descripcion"
            rileComboNaves.ValueMember = "id"
            rileComboNaves.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup
            rileComboNaves.DropDownRows = 20
            rileComboNaves.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete
            rileComboNaves.AutoSearchColumnIndex = 1
            rileComboNaves.PopulateColumns()
            rileComboNaves.Columns("id").Visible = False
            rileComboNaves.ShowHeader = False



            Dim rileFechaEntregaPropuesta As New RepositoryItemDateEdit
            If RestriccionCuatroDias = False Then '' CAMBIOS OAMB (22/05/2024) - Se agrega un permiso especial para el gerente de muestras que permite modificar la colocación como prefiera sin ir en orden.
                rileFechaEntregaPropuesta.MinValue = Date.Now
            Else
                rileFechaEntregaPropuesta.MinValue = Date.Now.AddDays(4)
            End If



            If Accion = 1 Then

                lblMovimientoFilasEstatus.Text = "ACTIVO"   '' Cuando el estatus que se está revisando es AUTORIZADOS PARA PRODUCCIÓN, se activa el movimiento y cambiamos el texto del label.
            End If

            Grid.Columns("NaveDesarrollo").ColumnEdit = rileComboNaves                          '' CAMBIOS OAMB (09/05/2024) - Pasa a ser NaveDesarrollo (Nave). Ahora esta columna es informativa.
            Grid.Columns.ColumnByFieldName("NaveDesarrollo").OptionsColumn.AllowEdit = False    '' CAMBIOS OAMB (09/05/2024) - Pasa a ser NaveDesarrollo (Nave). La columna ya no se puede modificar.

            Grid.Columns("NaveProduccion").ColumnEdit = rileComboNaves                          '' CAMBIOS OAMB (09/05/2024) - Agregamos NaveProduccion (Nueva columna que asigna la nave al pedido).
            AddHandler grdVPeidosMuestrasOP.CellValueChanged, AddressOf ActualizarNavesMasivamente
            ''NaveProduccion (grdVPeidosMuestrasOP_ShowingEditor)                                  CAMBIOS OAMB (09/05/2024) - Este evento es para bloquear aquellas celdas cuyo artículo deba ser producido por una nave Desarrollo (PROTOTIPO y MUESTRAS).
            Grid.Columns.ColumnByFieldName("NaveProduccion").AppearanceCell.BackColor = Color.Lavender

            Grid.Columns("BloqueoNaveProduccion").Visible = False

            Grid.Columns.ColumnByFieldName("FechaEntrada").OptionsColumn.AllowEdit = False      '' CAMBIOS OAMB (09/05/2024) - Nueva columna informativa. La columna no se puede modificar.

            Grid.Columns.ColumnByFieldName("EnviarAProducir").OptionsColumn.AllowEdit = False

            Grid.Columns.ColumnByFieldName("Apartados").OptionsColumn.AllowEdit = False

            Grid.Columns.ColumnByFieldName("Cantidad").OptionsColumn.AllowEdit = False

            Grid.Columns.ColumnByFieldName("Disponibles").OptionsColumn.AllowEdit = False

            Grid.Columns("FechaEntregaPropuesta").ColumnEdit = rileFechaEntregaPropuesta        '' CAMBIOS OAMB (09/05/2024) - Nueva columna para la asignación de la fecha de entrega.
            Grid.Columns.ColumnByFieldName("FechaEntregaPropuesta").AppearanceCell.BackColor = Color.Lavender

            Grid.Columns("PE_Status").Visible = False

            Grid.Columns.ColumnByFieldName("Estatus Articulo").OptionsColumn.AllowEdit = False

            Grid.Columns("DeptoId").Visible = False

            Grid.Columns("Capturó").OptionsColumn.AllowEdit = False



            Grid.Columns("Sel").Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
            Grid.Columns("FolioDePedido").Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
            Grid.Columns("NaveDesarrollo").Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
            Grid.Columns("NaveProduccion").Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
            Grid.Columns("FechaEntregaPropuesta").Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Right
        End If


        '' EN PRODUCCION (2).
        If Accion = 2 Then

            Grid.Columns.ColumnByFieldName("OrdenP").OptionsColumn.AllowEdit = False

            Grid.Columns.ColumnByFieldName("FolioDePedido").OptionsColumn.AllowEdit = False

            Grid.Columns.ColumnByFieldName("NaveDesarrollo").Visible = False    '' CAMBIOS OAMB (27/05/2024) - Se agrega la nave desarrollo, no es necesario verse.
            Grid.Columns.ColumnByFieldName("NombreNaveDesarrollo").Visible = False    '' CAMBIOS OAMB (27/05/2024) - Se agrega el id de la nave desarrollo para la reutilización del algoritmo de colocación, no es necesario verse.

            Grid.Columns.ColumnByFieldName("NaveProduccion").Visible = False    '' CAMBIOS OAMB (09/05/2024) - Se agrega el id de la nave producción para la reutilización del algoritmo de colocación, no es necesario verse.
            Grid.Columns.ColumnByFieldName("NombreNaveProduccion").OptionsColumn.AllowEdit = False    '' CAMBIOS OAMB (09/05/2024) - La NaveProduccion es la nave registrada en la OP.
            Grid.Columns.ColumnByFieldName("NombreNaveProduccion").Caption = "Nave Produccion"   '' CAMBIOS OAMB (27/05/2024) - Cambio de nombre de la columna referenciando a la anterior.

            Grid.Columns.ColumnByFieldName("NaveId").Visible = False
            'Grid.Columns.ColumnByFieldName("NaveId").OptionsColumn.AllowEdit = False

            Grid.Columns.ColumnByFieldName("NaveIdOriginal").Visible = False

            Grid.Columns.ColumnByFieldName("Cantidad").AppearanceCell.BackColor = Color.Lavender
            DiseñoGrid.EstiloColumna(Grid, "Cantidad", "* Enviar", True, AutoFilterCondition.Contains, True, True, Nothing, True, DevExpress.Data.SummaryItemType.Sum, "{0:N0}")

            Grid.Columns.ColumnByFieldName("Cantidad_resp").Visible = False

            DiseñoGrid.EstiloColumna(Grid, "Solicitados", "Solicitados", True, AutoFilterCondition.Contains, False, True, Nothing, True, DevExpress.Data.SummaryItemType.Sum, "{0:N0}")

            DiseñoGrid.EstiloColumna(Grid, "Pendientes", "Pendientes", True, AutoFilterCondition.Contains, False, True, Nothing, True, DevExpress.Data.SummaryItemType.Sum, "{0:N0}")

            DiseñoGrid.EstiloColumna(Grid, "Enviados", "Enviados", True, AutoFilterCondition.Contains, False, True, Nothing, True, DevExpress.Data.SummaryItemType.Sum, "{0:N0}")

            Grid.Columns.ColumnByFieldName("FechaEntregaPropuesta").OptionsColumn.AllowEdit = False    '' CAMBIOS OAMB (09/05/2024) - Se cambia el nombre de la columna (FCorte) por Fecha Entrega Nave

            Grid.Columns.ColumnByFieldName("FCorteOriginal").Visible = False

            Grid.Columns.ColumnByFieldName("FProgramacion").OptionsColumn.AllowEdit = False

            Grid.Columns.ColumnByFieldName("FAutorizacion").OptionsColumn.AllowEdit = False

            Grid.Columns.ColumnByFieldName("FImpresion").OptionsColumn.AllowEdit = False

            Grid.Columns.ColumnByFieldName("FCaptura").Visible = True

            Grid.Columns.ColumnByFieldName("Estatus Articulo").OptionsColumn.AllowEdit = False



            Grid.Columns("Sel").Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
            Grid.Columns("ImprimeEtiqLengua").Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
            Grid.Columns("OrdenP").Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
            Grid.Columns("FolioDePedido").Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
            Grid.Columns("NombreNaveProduccion").Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left

            Grid.Columns("FechaEntregaPropuesta").Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Right
            Grid.Columns("Cantidad").Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Right
        End If


        '' ENVIADOS (3).
        If Accion = 3 Then

            Grid.Columns.ColumnByFieldName("Cantidad").Caption = "Enviados"
            Grid.Columns.ColumnByFieldName("FImpresion").OptionsColumn.AllowEdit = False
            Grid.Columns.ColumnByFieldName("FProgramacion").OptionsColumn.AllowEdit = False
            Grid.Columns.ColumnByFieldName("FAutorizacion").OptionsColumn.AllowEdit = False

            Grid.Columns.ColumnByFieldName("Estatus Articulo").OptionsColumn.AllowEdit = False
        End If


        '' EN PRODUCCION Y ENVIADOS (4).
        '' No hay formato para esa tabla.


        '' REPROCESO (6).
        If Accion = 6 Then

            '' CAMBIOS OAMB (27/05/2024) - Se quita la edición de las columnas de la consulta del estatus REPROCESO.
            Grid.OptionsBehavior.Editable = False
        End If


        '' AGREGAMOS FORMATO GENERAL A LA TABLA EN CASO DE QUE EL ESTATUS CONSULTADO NO SEA REPROCESO.
        If Accion <> 6 Then

            'Grid.Columns.ColumnByFieldName("Sel").OptionsColumn.AllowEdit = True
            Grid.Columns.ColumnByFieldName("FolioDePedido").Caption = "Pedido"
            Grid.Columns.ColumnByFieldName("FolioDePedido").OptionsColumn.AllowEdit = False

            Grid.Columns.ColumnByFieldName("Cliente").OptionsColumn.AllowEdit = False

            Grid.Columns.ColumnByFieldName("Marca").OptionsColumn.AllowEdit = False

            Grid.Columns.ColumnByFieldName("Coleccion").Caption = "Colección"
            Grid.Columns.ColumnByFieldName("Coleccion").OptionsColumn.AllowEdit = False

            Grid.Columns.ColumnByFieldName("Modelo").OptionsColumn.AllowEdit = False

            Grid.Columns.ColumnByFieldName("Articulo").Visible = False
            'Grid.Columns.ColumnByFieldName("Articulo").OptionsColumn.AllowEdit = False

            Grid.Columns.ColumnByFieldName("PielColor").OptionsColumn.AllowEdit = False
            Grid.Columns.ColumnByFieldName("Corrida").OptionsColumn.AllowEdit = False
            Grid.Columns.ColumnByFieldName("Talla").OptionsColumn.AllowEdit = False
            Grid.Columns.ColumnByFieldName("Corte").OptionsColumn.AllowEdit = False
            Grid.Columns.ColumnByFieldName("Forro").OptionsColumn.AllowEdit = False
            Grid.Columns.ColumnByFieldName("Suela").OptionsColumn.AllowEdit = False

            Grid.Columns.ColumnByFieldName("Estatus").OptionsColumn.AllowEdit = False

            Grid.Columns.ColumnByFieldName("idUDM").Visible = False

            Grid.Columns.ColumnByFieldName("UDM").OptionsColumn.AllowEdit = False

            Grid.Columns.ColumnByFieldName("FSolicitada").Visible = True


            If Accion = 1 Or Accion = 5 Then

                Grid.Columns.ColumnByFieldName("FolioDePedidoPartida").Visible = False  '' CAMBIOS OAMB (22/05/2024) - Se agrega la partida del pedido para el cambio de estatus de solo la partida y no el pedido completo.
                Grid.Columns.ColumnByFieldName("Cantidad").Caption = "Cantidad"
            Else

                Grid.Columns.ColumnByFieldName("ImprimeEtiqLengua").OptionsColumn.AllowEdit = False
                Grid.Columns.ColumnByFieldName("ImprimeEtiqLengua").Caption = "Req. Etq. Lengua"
            End If

            Grid.Columns.ColumnByFieldName("FechaEntregaPropuesta").Caption = "Fecha Entrega Nave" '' CAMBIOS OAMB (09/05/2024) - Esta columna ya no se ve en la acción 1.



            Grid.Columns.ColumnByFieldName("FSolicitada").Caption = "Fecha Solicitada "
            Grid.Columns.ColumnByFieldName("FSolicitada").OptionsColumn.AllowEdit = False

            Grid.Columns.ColumnByFieldName("FCaptura").Caption = "Fecha Captura"
            Grid.Columns.ColumnByFieldName("FCaptura").OptionsColumn.AllowEdit = False

            Grid.Columns.ColumnByFieldName("FAutorizacion").OptionsColumn.AllowEdit = False

            Grid.OptionsView.ShowFooter = GroupFooterShowMode.VisibleAlways

            If IsNothing(Grid.Columns("Cantidad").Summary.FirstOrDefault(Function(x) x.FieldName = "Cantidad")) = True Then

                DiseñoGrid.EstiloColumna(Grid, "Cantidad", "Cantidad", True, AutoFilterCondition.Contains, False, True, Nothing, True, DevExpress.Data.SummaryItemType.Sum, "{0:N0}")
            End If
        End If


        '' ------------------ Formato general ------------------ ''

        Grid.BestFitColumns()

        '' ------------------ Formato general ------------------ ''
    End Sub



    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Try
            '' CAMBIOS OAMB(22/05/2024)
            CerrarSesionActual(usuarioIdFormulario, nombreFormulario)

            Me.Close()
        Catch ex As Exception
            Throw ex
        Finally

            '' CAMBIOS OAMB(22/05/2024)
            CerrarSesionActual(usuarioIdFormulario, nombreFormulario)
        End Try
    End Sub


    Private Sub switch()
        Try

            Accion = cmbEstatus.SelectedValue



            '' ---------- Inactivamos los paneles y los botones de las acciones de la pantalla. Los iremos activando conforme se vayan seleccionando los estatus. ---------- ''
            pnlNave.Visible = False
            pnlEditar.Visible = False
            pnlFechaEntregaPropuesta.Visible = False

            '' Botones
            pnlGenerarOP.Visible = False
            pnlEnviarComercializadora.Visible = False
            pnlImprimirEtiquetas.Visible = False
            pnlExportar.Visible = False
            pnlBotonEditar.Visible = False
            pnlGenerarColocacion.Visible = False

            btnGuardar.Visible = False
            lblGuardar.Visible = False

            '' Valores informativos.
            pnlParamCaptura.Visible = False
            lblParamCaptura.Visible = False
            pnlNoGenerarOP.Visible = False
            lblNoGenerarOP.Visible = False

            '' Información columnas.
            lblParamNave.Visible = False        '' Nave
            lblParamEnviar.Visible = False      '' Enviar
            lblParamFechaCorte.Visible = False  '' F Corte.



            '' AUTORIZADOS PRODUCCION (1) y AUTORIZADOS BLOQUEADOS (5)
            If Accion = 1 Or Accion = 5 Then

                If Accion = 1 Then
                    pnlFechaEntregaPropuesta.Visible = True
                End If

                If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ADMIN_OP_MUESTRAS", "GENERAR_OP") Then
                    pnlGenerarOP.Visible = True
                End If
                pnlExportar.Visible = True
                pnlGenerarColocacion.Visible = True         '' CAMBIOS OAMB (09/05/2024) - Agregamos el botón para la generación de la colocación.

                pnlParamCaptura.Visible = True
                lblParamCaptura.Visible = True
                pnlNoGenerarOP.Visible = True
                lblNoGenerarOP.Visible = True

                lblParamNave.Visible = True
                lblParamFechaCorte.Visible = True
            End If

            If Accion = 2 Then

                pnlNave.Visible = True

                'pnlEnviarComercializadora.Visible = True
                pnlImprimirEtiquetas.Visible = True
                pnlExportar.Visible = True
                pnlBotonEditar.Visible = True

                pnlParamCaptura.Visible = True
                lblParamCaptura.Visible = True
                pnlNoGenerarOP.Visible = True
                lblNoGenerarOP.Visible = True

                lblParamEnviar.Visible = True
            End If

            If Accion = 3 Then

                pnlNave.Visible = True

                pnlImprimirEtiquetas.Visible = True
                pnlExportar.Visible = True

                pnlNoGenerarOP.Visible = True
                lblNoGenerarOP.Visible = True
            End If

            '' EN PRODUCCION Y ENVIADOS
            If Accion = 4 Then

                pnlNave.Visible = True

                pnlImprimirEtiquetas.Visible = True
                pnlExportar.Visible = True

                pnlNoGenerarOP.Visible = True
                lblNoGenerarOP.Visible = True
            End If

            If Accion = 6 Then

                pnlImprimirEtiquetas.Visible = True
                pnlExportar.Visible = True

                pnlNoGenerarOP.Visible = True
                lblNoGenerarOP.Visible = True
            End If



            LlenarGridPedidosMuestrasOP()



            '' ------------ Comportamiento de arrastrar y soltar filas ------------ ''
            '' Quitar el comportamiento del Load a toda costa. ''
            If Accion = 1 Then
                '' Cambiamos el color de las filas seleccionadas para ubicarlas mejor. ''
                grdVPeidosMuestrasOP.Appearance.SelectedRow.BackColor = Color.Aquamarine

                '' Generamos un objeto que contenga el comportamiento de arrastrar y soltar (DragDrop). ''
                comportamientosTablaPrincipal.Attach(Of DragDropBehavior)(grdVPeidosMuestrasOP, Sub(behavior)
                                                                                                    behavior.Properties.AllowDrop = True
                                                                                                    behavior.Properties.InsertIndicatorVisible = True
                                                                                                    behavior.Properties.PreviewVisible = True
                                                                                                    AddHandler behavior.DragOver, AddressOf Behavior_DragOver
                                                                                                    AddHandler behavior.DragDrop, AddressOf Behavior_DragDrop
                                                                                                End Sub)
            Else
                '' Utilizamos Detach para eliminar el comportamiento. ''
                comportamientosTablaPrincipal.Detach(Of DragDropBehavior)(grdVPeidosMuestrasOP)
            End If
            '' ------------ Comportamiento de arrastrar y soltar filas ------------ ''
        Catch ex As Exception
            Dim msg_error As New Tools.ErroresForm
            msg_error.mensaje = ex.Message
            msg_error.ShowDialog()
        End Try
    End Sub

    Private Sub grdVPeidosMuestrasOP_CustomUnboundColumnData(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs)
        If e.IsGetData Then
            e.Value = grdVPeidosMuestrasOP.GetRowHandle(e.ListSourceRowIndex)
            e.Value = e.Value + 1
        End If
    End Sub

    Private Sub chboxSeleccionarTodo_CheckedChanged(sender As Object, e As EventArgs) Handles chboxSeleccionarTodo.CheckedChanged
        Dim NumeroFilas As Integer = 0
        Try
            Cursor = Cursors.WaitCursor
            NumeroFilas = grdVPeidosMuestrasOP.DataRowCount
            For index As Integer = 0 To NumeroFilas Step 1
                'If grdVPeidosMuestrasOP.GetRowCellValue(index, "Estatus") = "CAPTURADO" Then
                grdVPeidosMuestrasOP.SetRowCellValue(grdVPeidosMuestrasOP.GetVisibleRowHandle(index), "Sel", chboxSeleccionarTodo.Checked)
                ' End If
            Next
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
        End Try
    End Sub





    Private Sub btnGenerarOP_Click(sender As Object, e As EventArgs) Handles btnGenerarOP.Click
        Dim NumeroFilas As Integer = 0
        Dim arreglo As New ArrayList
        Dim ListaInt As New List(Of Integer)
        Dim usuario As Int32 = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        Dim ListaDatosCorreo As New List(Of DatosCorreo)
        Dim Cadena As New StringBuilder


        Dim lstNaveId As New List(Of Integer)
        Dim dtOrdenProduccion As New DataTable
        Dim lstOrdenesProduccion As New List(Of Entidades.OrdenesProduccionMuestras)


        Try
            If ValidaAlta() Then
                Dim objMensajeQ As New ConfirmarForm
                objMensajeQ.mensaje = "¿Esta seguro de guardar cambios?"

                If objMensajeQ.ShowDialog = Windows.Forms.DialogResult.OK Then
                    Cursor = Cursors.WaitCursor
                    NumeroFilas = grdVPeidosMuestrasOP.DataRowCount

                    For index As Integer = 0 To NumeroFilas Step 1
                        If grdVPeidosMuestrasOP.GetRowCellValue(index, "Sel") Then

                            Dim distribucionPedido As New List(Of DatosColocacion)

                            Dim PedidoSeleccionado = grdVPeidosMuestrasOP.GetRowCellValue(index, "FolioDePedido")
                            Dim FechaEntregaTabla = grdVPeidosMuestrasOP.GetRowCellValue(index, "FechaEntregaPropuesta")
                            Dim NaveDesarrollo = grdVPeidosMuestrasOP.GetRowCellValue(index, "NaveDesarrollo")
                            Dim NaveProduccion = grdVPeidosMuestrasOP.GetRowCellValue(index, "NaveProduccion")
                            Dim Articulo = grdVPeidosMuestrasOP.GetRowCellValue(index, "Articulo")
                            Dim Talla = grdVPeidosMuestrasOP.GetRowCellValue(index, "Talla")
                            Dim Cantidad = grdVPeidosMuestrasOP.GetRowCellValue(index, "Cantidad")



                            '' Buscamos la distribución generada por el algoritmo de colocación.
                            distribucionPedido.AddRange(From datosColocacion In listaDatosColocacionCompleto
                                                        Where (datosColocacion.NaveProduccion = NaveProduccion And datosColocacion.FolioDePedido = PedidoSeleccionado And datosColocacion.Articulo = Articulo And datosColocacion.Talla = Talla))

                            '' Si el registro que estamos revisando, no coincide con ninguna entidad de la lista de colocación, significa que el usuario modificó manualmente los valores después de la colocación, por lo que tomaremos esos registros.
                            If distribucionPedido.Count = 0 Then
                                Dim datoColocacion As New DatosColocacion

                                datoColocacion.FolioDePedido = PedidoSeleccionado
                                datoColocacion.FechaAsignada = FechaEntregaTabla
                                datoColocacion.NaveDesarrollo = NaveDesarrollo
                                datoColocacion.NaveProduccion = NaveProduccion
                                datoColocacion.Articulo = Articulo
                                datoColocacion.Talla = Talla
                                datoColocacion.Cantidad = Cantidad

                                GeneracionColocacionPedido(datoColocacion, FechaEntregaTabla)

                                distribucionPedido.AddRange(listaDatosColocacionPedido)
                            End If



                            For Each filaDistribucionPedidosSeleccionado As DatosColocacion In distribucionPedido
                                Dim PedidosMuestrasOPNegocios As New Negocios.PedidosMuestrasOP
                                Dim EntidadOrdenesProduccionMuestras As New Entidades.OrdenesProduccionMuestras
                                Dim EntidadDatosCorreo As New DatosCorreo



                                EntidadOrdenesProduccionMuestras.pdetorm_naveid = CInt(grdVPeidosMuestrasOP.GetRowCellValue(index, "NaveProduccion"))   '' CAMBIOS OAMB (10/06/2024) - Pasa a ser NaveProduccion (Nave). En este caso es la nave producción que fue seleccionada para hacer la muestra.
                                'EntidadOrdenesProduccionMuestras.pdetorm_cantsolicitada = grdVPeidosMuestrasOP.GetRowCellValue(index, "EnviarAProducir")
                                EntidadOrdenesProduccionMuestras.pdetorm_cantsolicitada = filaDistribucionPedidosSeleccionado.Cantidad
                                EntidadOrdenesProduccionMuestras.pdetorm_productoestiloid = filaDistribucionPedidosSeleccionado.Articulo
                                EntidadOrdenesProduccionMuestras.pdetorm_pedidoid = filaDistribucionPedidosSeleccionado.FolioDePedido
                                EntidadOrdenesProduccionMuestras.pdetm_partidaid = grdVPeidosMuestrasOP.GetRowCellValue(index, "FolioDePedidoPartida")  '' CAMBIOS OAMB (09/05/2024) - Agregamos el id de la partida del pedido seleccionado.
                                EntidadOrdenesProduccionMuestras.pdetorm_unidadmedidaid = grdVPeidosMuestrasOP.GetRowCellValue(index, "idUDM")
                                'EntidadOrdenesProduccionMuestras.pdetorm_fechacorte = grdVPeidosMuestrasOP.GetRowCellValue(index, "FechaEntregaPropuesta") '' CAMBIOS OAMB (09/05/2024) - Pasa a ser FechaEntregaPropuesta (FCorte)
                                EntidadOrdenesProduccionMuestras.pdetorm_fechacorte = filaDistribucionPedidosSeleccionado.FechaAsignada
                                EntidadOrdenesProduccionMuestras.pdetorm_talla = filaDistribucionPedidosSeleccionado.Talla
                                EntidadOrdenesProduccionMuestras.pdetorm_fechacreacion = DateTime.Now
                                EntidadOrdenesProduccionMuestras.pdetorm_usuariocreoid = usuario


                                EntidadDatosCorreo.Folio = filaDistribucionPedidosSeleccionado.FolioDePedido
                                EntidadDatosCorreo.Coleccion = grdVPeidosMuestrasOP.GetRowCellValue(index, "Coleccion")
                                EntidadDatosCorreo.Modelo = grdVPeidosMuestrasOP.GetRowCellValue(index, "Modelo")
                                EntidadDatosCorreo.Asunto = grdVPeidosMuestrasOP.GetRowCellValue(index, "Asunto")
                                EntidadDatosCorreo.PielColor = grdVPeidosMuestrasOP.GetRowCellValue(index, "PielColor")
                                EntidadDatosCorreo.Corrida = grdVPeidosMuestrasOP.GetRowCellValue(index, "Corrida")
                                'EntidadDatosCorreo.Cantidad = grdVPeidosMuestrasOP.GetRowCellValue(index, "EnviarAProducir")
                                EntidadDatosCorreo.Cantidad = filaDistribucionPedidosSeleccionado.Cantidad
                                EntidadDatosCorreo.Talla = EntidadOrdenesProduccionMuestras.pdetorm_talla
                                EntidadDatosCorreo.Cliente = grdVPeidosMuestrasOP.GetRowCellValue(index, "Cliente")
                                EntidadDatosCorreo.Fsolicitud = grdVPeidosMuestrasOP.GetRowCellValue(index, "FSolicitada")
                                'EntidadDatosCorreo.Fcorte = grdVPeidosMuestrasOP.GetRowCellValue(index, "FechaEntregaPropuesta")    '' CAMBIOS OAMB (09/05/2024) - Pasa a ser FechaEntregaPropuesta (FCorte)
                                EntidadDatosCorreo.Fcorte = filaDistribucionPedidosSeleccionado.FechaAsignada
                                EntidadDatosCorreo.idNave = EntidadOrdenesProduccionMuestras.pdetorm_naveid
                                EntidadDatosCorreo.Nave = filaDistribucionPedidosSeleccionado.NaveDesarrollo '' CAMBIOS OAMB (09/05/2024) - Pasa a ser NaveDesarrollo (Nave)
                                EntidadDatosCorreo.unidadMedida = grdVPeidosMuestrasOP.GetRowCellDisplayText(index, "UDM")
                                ''EntidadDatosCorreo.EntidadDatosNave.idNave = EntidadOrdenesProduccionMuestras.pdetorm_naveid
                                ''EntidadDatosCorreo.EntidadDatosNave.Descripcio = grdVPeidosMuestrasOP.GetRowCellValue(index, "Nave")


                                dtOrdenProduccion = PedidosMuestrasOPNegocios.AltaPedidoMuestraOP(EntidadOrdenesProduccionMuestras) '' CAMBIOS OAMB (09/05/2024) - 

                                lstNaveId.Add(EntidadOrdenesProduccionMuestras.pdetorm_naveid)
                                ListaDatosCorreo.Add(EntidadDatosCorreo)


                                '' CAMBIOS OAMB (09/05/2024) - Guardamos las OPs y las Naves generadas en una lista auxiliar para realizar los reportes de fabricación de muestras.
                                Dim ordenProduccionReporte As New Entidades.OrdenesProduccionMuestras
                                ordenProduccionReporte.pdetorm_ordenproduccionid = dtOrdenProduccion.Rows(0).Item("OrdenProduccionId")
                                ordenProduccionReporte.pdetorm_pedidoid = dtOrdenProduccion.Rows(0).Item("PedidoId")
                                ordenProduccionReporte.pdetorm_naveid = dtOrdenProduccion.Rows(0).Item("NaveId")
                                lstOrdenesProduccion.Add(ordenProduccionReporte)
                            Next
                        End If
                    Next


                    enviarCorreoOPMuestras(ListaDatosCorreo, lstNaveId)


                    '' CAMBIOS OAMB (09/05/2024) - Agregamos la generación de los reportes de fabricación.
                    '' Si la lista tiene OPs, entramos.
                    If lstOrdenesProduccion.Count > 0 Then

                        '' Guardamos una lista con todas las naves generadas.
                        Dim listaNaves = lstOrdenesProduccion.Select(Function(naves) naves.pdetorm_naveid).Distinct.ToList()

                        '' Generamos un ciclo para tomar las OPs de cada nave para generar los reportes de fabricación.
                        While (listaNaves.Count() > 0)

                            '' Tomamos la primer nave de la lista.
                            Dim naveSeleccionada = listaNaves.Distinct().FirstOrDefault()

                            '' Guardamos una lista con los pedidos de la nave seleccionada.
                            Dim listaPedidos = lstOrdenesProduccion.Where(Function(pedido) pedido.pdetorm_naveid = naveSeleccionada).Select(Function(pedido) pedido.pdetorm_pedidoid).Distinct.ToList()


                            '' Generamos un ciclo para tomar los pedidos de la nave seleccionada.
                            While (listaPedidos.Count() > 0)

                                '' Tomamos el primer pedido de la lista.
                                Dim pedidoSeleccionado = listaPedidos.Distinct().FirstOrDefault()

                                '' Guardamos una lista con las OPs del pedido seleccionado.
                                Dim listaOPs = lstOrdenesProduccion.Where(Function(ops) ops.pdetorm_naveid = naveSeleccionada And ops.pdetorm_pedidoid = pedidoSeleccionado).Select(Function(ops) ops.pdetorm_ordenproduccionid).Distinct.ToList()

                                '' Quitamos el pedido seleccionado.
                                listaPedidos.Remove(pedidoSeleccionado)



                                '' Generamos los reportes de las OPs de la nave (es necesario generar los reportes por nave y pedido).
                                Dim ordenesProduccionConcatenadas = ""

                                ordenesProduccionConcatenadas = ConcatenarOrdenesProduccion(listaOPs)

                                GenerarReporteFabricacionMuestras(ordenesProduccionConcatenadas, naveSeleccionada, "FABRICACIÓN")
                            End While

                            '' Quitamos la nave seleccionada.
                            listaNaves.Remove(naveSeleccionada)
                        End While
                    End If
                End If

                Tools.MostrarMensaje(Mensajes.Success, "¡Se han generado las OPs y los reportes de forma correcta!")
            End If
        Catch ex As Exception

            Tools.MostrarMensaje(Mensajes.Warning, ex.Message)
        Finally

            LlenarGridPedidosMuestrasOP()
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub enviarCorreoOPMuestras(ByVal lista As List(Of DatosCorreo), ByVal ListaInt As List(Of Integer))
        Dim distinct As List(Of Integer) = ListaInt.Distinct().ToList
        Dim t As List(Of DatosCorreo)
        t = lista
        For Each idNave As Integer In distinct

            Dim enviosCorreoBU As New Framework.Negocios.EnviosCorreoBU
            Dim destinatarios As String = String.Empty
            Dim objBu As New Negocios.PedidosMuestrasOP
            Dim dtResultadoDatosCorreos As New DataTable
            Dim remitente As String = String.Empty
            Dim correo As New Tools.Correo
            Dim cadenaCorreo As String = String.Empty
            Dim asuntoCorreo As String = String.Empty
            Dim tipoBusquedaPartidas As Integer = 0
            Dim idBusquedaPartidas As Integer = 0
            Dim dtResultadoPartidasCanceladas As New DataTable
            Dim dtResultadoUsuarioCaptura As New DataTable
            Dim destinatariosConUsuarioCapturo As String = String.Empty
            Dim result As List(Of DatosCorreo) = t.Where(Function(x) x.idNave = idNave).ToList

            Dim Nave As String = result.FirstOrDefault.Nave.ToString




            dtResultadoDatosCorreos = objBu.consultaCorreosGeneraOP("ENVIO_ORDEN_PRODUCCION_MUESTRAS", idNave)

            If dtResultadoDatosCorreos.Rows.Count > 0 Then

                remitente = dtResultadoDatosCorreos.Rows(0).Item("CorreoEnvia").ToString()
                destinatarios = dtResultadoDatosCorreos.Rows(0).Item("Destinatarios").ToString()

                cadenaCorreo = "<html> " +
                                                " <head>" +
                                                    " <style type='text/css'>body {display: block; margin: 8px; background: #FFFFFF;}" +
                                                    " #header{	position: fixed;" +
                                                    " height: 62px;" +
                                                    " margin: 1% 1%;" +
                                                    " top: 0;" +
                                                    " left: 0;" +
                                                    " right: 0;" +
                                                    " color: black;" +
                                                    " font-family: Arial, Helvetica ,sans-serif;" +
                                                    " font-size: 12px;" +
                                                     " }" +
                                                    " #content   {width: 90%;" +
                                                    " position: fixed;" +
                                                    " margin: 0% 0%;" +
                                                    " padding-top: 15%;" +
                                                    " padding-bottom: 1%;" +
                                                    " font-family: Arial, Helvetica ,sans-serif;" +
                                                    " font-size: 12px;" +
                                                    " }" +
                                                    " table.tableizer-table { 	font-family: Arial, Helvetica, sans-serif;" +
                                                    " font-size: 10px;}" +
                                                    " .tableizer-table td {	padding: 4px;" +
                                                    " margin: 0px;" +
                                                    " border: 1px solid #FFFFFF;" +
                                                    " border-color: #FFFFFF;" +
                                                     " border: 1px solid #CCCCCC;" +
                                                    " width: 90px;}" +
                                                    " .tableizer-table tr {	padding: 4px;" +
                                                    " margin: 0;" +
                                                    " color: #003366;" +
                                                    " font-weight: bold;" +
                                                    " background-color: #transparent;" +
                                                    " opacity: 1;}" +
                                                    " .tableizer-table th {	background-color: #DFDFDF;" +
                                                    " color: black;" +
                                                    " font-weight: bold;" +
                                                    " height: 30px;" +
                                                    " font-size: 11px;}" +
                                                    " .tableizer-table tr:nth-child(odd){ background-color: #9BC4E2;}" +
                                                    " .tableizer-table tr:nth-child(even){ background-color:  #transparent;}" +
                                                    " </style>" +
                                                " </head>"
                cadenaCorreo += " <body> "
                cadenaCorreo += " <div id='wrapper'>"
                cadenaCorreo += " <div id='header'>"
                cadenaCorreo += " <p><B>ORDEN DE PRODUCCI&Oacute;N DE MUESTRAS</p>"
                cadenaCorreo += " <br><p align='center'><B>DETALLES DE LA ORDEN</B></p>"
                cadenaCorreo += " </div>"
                cadenaCorreo += " </div>"
                cadenaCorreo += " <div id='content' >"
                cadenaCorreo += " <p><B>USUARIO:</B> " + Entidades.SesionUsuario.UsuarioSesion.PUserNombreReal + " </p>"
                cadenaCorreo += " <p><B>FECHA:</B> " + Date.Now.ToString() + "</p>"
                cadenaCorreo += " <p><B>MOTIVO:</B> ORDEN DE PRODUCCI&Oacute;N MUESTRAS " + Nave.ToUpper.ToString + "</p>"
                cadenaCorreo += " <table id= 'mi_tabla'  class='tableizer-table'align='center' >"
                cadenaCorreo += " <thead>"
                cadenaCorreo += " <tr class='tableizer-firstrow'>"
                cadenaCorreo += " <th >Pedido</th>"
                cadenaCorreo += " <th width='30%' height='30px'>Cliente</th>"
                cadenaCorreo += " <th width='30%' height='30px'>Asunto</th>"
                cadenaCorreo += " <th width='15%'>Colección</th>"
                cadenaCorreo += " <th>Modelo</th>"
                cadenaCorreo += " <th width='25%'>Piel-Color</th>"
                cadenaCorreo += " <th >Corrida</th>"
                cadenaCorreo += " <th>Cantidad</th>"
                cadenaCorreo += " <th>UDM</th>"
                cadenaCorreo += " <th>Talla</th>"
                cadenaCorreo += " <th>Fecha de solicitud</th>"
                cadenaCorreo += " <th>Fecha corte</th>"
                cadenaCorreo += " </tr>"
                cadenaCorreo += " </thead>"
                cadenaCorreo += " <tbody>"

                'Dim result As List(Of DatosCorreo) = t.Where(Function(x) x.idNave = idNave).ToList
                For Each Entidad As DatosCorreo In result
                    cadenaCorreo += " <tr>"
                    cadenaCorreo += " <td align='right'>" + Entidad.Folio.ToString + "</td>"
                    cadenaCorreo += " <td>" + Entidad.Cliente + "</td>"
                    cadenaCorreo += " <td>" + Entidad.Asunto + "</td>"
                    cadenaCorreo += " <td> " + Entidad.Coleccion + "</td>"
                    cadenaCorreo += " <td>" + Entidad.Modelo + "</td>"
                    cadenaCorreo += " <td> " + Entidad.PielColor + "</td>"
                    cadenaCorreo += " <td> " + Entidad.Corrida + "</td>"
                    cadenaCorreo += " <td align='right'> " + Entidad.Cantidad.ToString + "</td>"
                    cadenaCorreo += " <td align='right'> " + Entidad.unidadMedida + "</td>"
                    cadenaCorreo += " <td align='right'> " + Entidad.Talla + "</td>"
                    cadenaCorreo += " <td> " + Entidad.Fsolicitud.ToString("dd/MM/yyyy") + "</td>"
                    cadenaCorreo += " <td> " + Entidad.Fcorte.ToString("dd/MM/yyyy") + "</td>"

                    cadenaCorreo += " </tr>"
                Next

                asuntoCorreo = "SOLICITUD DE MUESTRAS " + Nave.ToUpper.ToString

                'For Each Entidad As DatosCorreo In lista

                'Next
                cadenaCorreo += " </tbody>" +
                 " </table>" +
                  " </div>" +
                  " </body> " +
                  " </html> "
                correo.EnviarCorreoHtml(destinatarios, remitente, asuntoCorreo, cadenaCorreo)
            End If
        Next
    End Sub

    Private Sub btnBuscarFin_Click(sender As Object, e As EventArgs) Handles btnBuscarFin.Click

        If CDate(dtpFechaInicio.Value.ToShortDateString) > CDate(dtpFechaFin.Value.ToShortDateString) Then
            Dim mensaje As New AdvertenciaForm
            mensaje.mensaje = "La fecha inicial no puede ser mayor a la fecha final."
            mensaje.ShowDialog()
            Return
        End If


        Dim idNave As Integer
        idNave = cmbNaveMenu.SelectedValue

        LlenarGridPedidosMuestrasOP(idNave, dtpFechaInicio.Value.ToShortDateString, dtpFechaFin.Value.ToShortDateString)
    End Sub

    Private Sub btnEnviar_Click(sender As Object, e As EventArgs) Handles btnEnviar.Click
        Dim NumeroFilas As Integer = 0
        Dim usuario As Int32 = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid

        Try
            If ValidaEnviar() Then
                Dim objMensajeQ As New ConfirmarForm
                objMensajeQ.mensaje = "¿Esta seguro de guardar cambios?"
                If objMensajeQ.ShowDialog = Windows.Forms.DialogResult.OK Then
                    Cursor = Cursors.WaitCursor
                    NumeroFilas = grdVPeidosMuestrasOP.DataRowCount
                    For index As Integer = 0 To NumeroFilas Step 1
                        If grdVPeidosMuestrasOP.GetRowCellValue(index, "Sel") Then
                            Dim PedidosMuestrasOPNegocios As New Negocios.PedidosMuestrasOP
                            Dim EntidadOrdenesProduccionMuestras As New Entidades.OrdenesProduccionMuestras
                            Dim EntidadDatosCorreo As New DatosCorreo
                            'EntidadOrdenesProduccionMuestras.pdetorm_naveid = CInt(grdVPeidosMuestrasOP.GetListSourceRowCellValue(index, "Nave"))
                            EntidadOrdenesProduccionMuestras.pdetorm_cantsolicitada = grdVPeidosMuestrasOP.GetRowCellValue(index, "Cantidad")
                            EntidadOrdenesProduccionMuestras.pdetorm_productoestiloid = grdVPeidosMuestrasOP.GetRowCellValue(index, "Articulo")
                            EntidadOrdenesProduccionMuestras.pdetorm_pedidoid = grdVPeidosMuestrasOP.GetRowCellValue(index, "FolioDePedido")
                            EntidadOrdenesProduccionMuestras.pdetorm_unidadmedidaid = grdVPeidosMuestrasOP.GetRowCellValue(index, "idUDM")
                            'EntidadOrdenesProduccionMuestras.pdetorm_fechacorte = grdVPeidosMuestrasOP.GetRowCellValue(index, "FCorte")
                            EntidadOrdenesProduccionMuestras.pdetorm_talla = grdVPeidosMuestrasOP.GetRowCellValue(index, "Talla")
                            'EntidadOrdenesProduccionMuestras.pdetorm_fechacreacion = DateTime.Now
                            'EntidadOrdenesProduccionMuestras.pdetorm_usuariocreoid = usuario
                            PedidosMuestrasOPNegocios.EnviaPedidoMuestraOP(EntidadOrdenesProduccionMuestras)
                        End If
                    Next
                    Dim mensaje As New ExitoForm
                    mensaje.mensaje = "El registro se realizó con éxito."
                    mensaje.ShowDialog()
                    Cursor = Cursors.Default
                End If
                LlenarGridPedidosMuestrasOP()
            End If
        Catch ex As Exception
            Dim mensaje As New ErroresForm
            mensaje.mensaje = ex.Message.ToString
            mensaje.ShowDialog()
            LlenarGridPedidosMuestrasOP()
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimirEtiquetas.Click
        Dim NumeroFilas As Integer = 0
        Dim ListaInt As New List(Of Integer)

        Try
            Cursor = Cursors.WaitCursor

            NumeroFilas = grdVPeidosMuestrasOP.DataRowCount

            For index As Integer = 0 To NumeroFilas Step 1
                If grdVPeidosMuestrasOP.GetRowCellValue(index, "Sel") Then
                    ListaInt.Add(CInt(grdVPeidosMuestrasOP.GetRowCellValue(index, "OrdenP")))
                End If
            Next

            If ListaInt.Count > 0 Then
                Dim form As New ImprimirEtiquetasPedidosMuestrasForm
                form.ListaInt = ListaInt
                form.ShowDialog()
            Else
                Tools.MostrarMensaje(Mensajes.Warning, "No se encontraron registros seleccionados. Favor de corroborar la selección para la impresión.")
            End If
        Catch ex As Exception
            Tools.MostrarMensaje(Mensajes.Warning, "A ocurrido un error al seleccionar los pedidos a imprimir:" + ex.Message)
        Finally
            Cursor = Cursors.Default
            LlenarGridPedidosMuestrasOP()
        End Try
    End Sub

    Private Sub btnExportarExcel_Click(sender As Object, e As EventArgs) Handles btnExportarExcel.Click
        Dim fbdUbicacionArchivo As New FolderBrowserDialog

        Try
            With fbdUbicacionArchivo

                .Reset()
                .Description = " Seleccione una carpeta "
                .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                .ShowNewFolderButton = True

                Dim ret As DialogResult = .ShowDialog
                Dim fecha_hora As String = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString

                If ret = Windows.Forms.DialogResult.OK Then

                    If grdVPeidosMuestrasOP.GroupCount > 0 Then
                        grdVPeidosMuestrasOP.ExportToXlsx(.SelectedPath + "\Datos_OrdenesDeProduccion_" + fecha_hora + ".xlsx")
                        'grdPedidosMuestras.ExportToXlsx(.SelectedPath + "\" + fecha_hora + ".xlsx")
                    Else
                        Dim exportOptions = New XlsxExportOptionsEx()
                        AddHandler exportOptions.CustomizeCell, AddressOf exportOptions_CustomizeCell
                        grdPedidosMuestrasOP.ExportToXlsx(.SelectedPath + "\Datos_OrdenesDeProduccion_" + fecha_hora + ".xlsx", exportOptions)

                    End If

                    Dim mensajeExito As New ExitoForm
                    mensajeExito.mensaje = "Los datos se exportaron correctamente."
                    mensajeExito.ShowDialog()

                    .Dispose()

                    Process.Start(fbdUbicacionArchivo.SelectedPath + "\Datos_OrdenesDeProduccion_" + fecha_hora + ".xlsx")
                End If

            End With
        Catch ex As Exception
            Dim mensajeError As New ErroresForm
            mensajeError.mensaje = ex.Message
            mensajeError.ShowDialog()
        End Try
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click

        If dtPedidosMuestras.Rows.Count > 0 Then

            If cmbEstatus.Text = "EN PRODUCCION" Then
                ''dtpCambioFecha.Value = Date.Now
                ''dtpCambioFecha.Value = DateAdd(DateInterval.Day, 5, dtpCambioFecha.Value) '' CAMBIOS OAMB (28/05/2024) - Quitamos este código para que siempre tome la fecha actual pero hacemos que ya no tome ningún día anterior al actual.


                'DatePart(DateInterval.WeekOfYear, Now, FirstDayOfWeek.Saturday, FirstWeekOfYear.Jan1)
                'If dtpCambioFecha.Value Then
                '    dtpCambioFecha.Value = DateAdd(DateInterval.Day, 6, dtpCambioFecha.Value)
                'End If

                pnlEditar.Visible = True
                btnGuardar.Visible = True
                lblGuardar.Visible = True
                cmbCambioNave = Controles.ComboNavesSegunUsuario(cmbCambioNave, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
            Else

                pnlEditar.Visible = False
                btnGuardar.Visible = False
                lblGuardar.Visible = False

                Dim mensajeExito As New AdvertenciaForm
                mensajeExito.mensaje = "Solo se pueden editar las ordenes en status EN PRODUCCION."
                mensajeExito.ShowDialog()
            End If
        Else
            Dim mensajeExito As New AdvertenciaForm
            mensajeExito.mensaje = "No hay registros para editar."
            mensajeExito.ShowDialog()
        End If

    End Sub

    Private Sub btnAsignar_Click(sender As Object, e As EventArgs) Handles btnAsignar.Click
        Dim NumeroFilas As Integer
        Cursor = Cursors.WaitCursor

        grdVPeidosMuestrasOP.Columns("NombreNaveProduccion").ClearFilter()    '' CAMBIOS OAMB (09/05/2024) - Pasa a ser NaveProduccion (Nave)
        grdVPeidosMuestrasOP.Columns("FechaEntregaPropuesta").ClearFilter()

        If dtPedidosMuestras.Rows.Count > 0 Then
            If cmbEstatus.Text = "EN PRODUCCION" Then
                If chFecha.Checked = True Or cmbCambioNave.Text <> "" Then
                    NumeroFilas = grdVPeidosMuestrasOP.RowCount
                    For index As Integer = 0 To NumeroFilas Step 1
                        If grdVPeidosMuestrasOP.GetRowCellValue(index, "Sel") = True Then

                            '' CAMBIOS OAMB (27/05/2024) - Modificamos la fecha de entrega de la nave para posteriormente usar le algoritmo de colocación para hacerlo igual que en los pedidos autorizados (Estatus 1).
                            If cmbCambioNave.Text <> "" Then
                                grdVPeidosMuestrasOP.SetRowCellValue(index, "NombreNaveProduccion", cmbCambioNave.Text)   '' CAMBIOS OAMB (09/05/2024) - Pasa a ser NaveProduccion (Nave)
                                grdVPeidosMuestrasOP.SetRowCellValue(index, "NaveProduccion", cmbCambioNave.SelectedValue)
                            End If

                            If chFecha.Checked = True Then
                                If RestriccionCuatroDias = False Then '' CAMBIOS OAMB (22/05/2024) - Se agrega un permiso especial para el gerente de muestras que permite modificar la colocación como prefiera sin ir en orden.
                                    grdVPeidosMuestrasOP.SetRowCellValue(index, "FechaEntregaPropuesta", dtpCambioFecha.Value)
                                Else
                                    GeneracionColocacionPedidosCompleto(chFecha.Checked, dtpCambioFecha)
                                End If
                            End If
                        End If

                    Next index
                Else
                    Dim mensajeExito As New AdvertenciaForm
                    mensajeExito.mensaje = "Seleccionar una nave o habilitar el campo de fecha."
                    mensajeExito.ShowDialog()
                End If
            Else
                Dim mensajeExito As New AdvertenciaForm
                mensajeExito.mensaje = "Solo se pueden editar las ordenes en status EN PRODUCCION."
                mensajeExito.ShowDialog()
            End If
        Else
            Dim mensajeExito As New AdvertenciaForm
            mensajeExito.mensaje = "No hay registros para editar."
            mensajeExito.ShowDialog()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim vXmlOrdenes = New XElement("Ordenes")
        Dim OBJ As New Programacion.Negocios.PedidosMuestrasOP

        Try
            Cursor = Cursors.WaitCursor
            For item As Integer = 0 To grdVPeidosMuestrasOP.DataRowCount - 1
                'If grdVPeidosMuestrasOP.GetRowCellValue(item, "NaveIdOriginal") <> grdVPeidosMuestrasOP.GetRowCellValue(item, "NaveProduccion") Or
                'grdVPeidosMuestrasOP.GetRowCellValue(item, "FCorteOriginal") <> grdVPeidosMuestrasOP.GetRowCellValue(item, "FechaEntregaPropuesta") Then
                If grdVPeidosMuestrasOP.GetRowCellValue(item, "Sel") = True Then
                    Dim vNodo As XElement = New XElement("Orden")
                    vNodo.Add(New XAttribute("OrdenProduccionId", grdVPeidosMuestrasOP.GetRowCellValue(item, "OrdenP")))
                    vNodo.Add(New XAttribute("NaveId", grdVPeidosMuestrasOP.GetRowCellValue(item, "NaveProduccion")))
                    vNodo.Add(New XAttribute("FechaEntregaNave", grdVPeidosMuestrasOP.GetRowCellValue(item, "FechaEntregaPropuesta")))
                    vNodo.Add(New XAttribute("CantidadSolicitada", grdVPeidosMuestrasOP.GetRowCellValue(item, "Cantidad")))
                    vNodo.Add(New XAttribute("UsuarioId", usuarioIdFormulario))
                    vXmlOrdenes.Add(vNodo)
                End If
            Next

            OBJ.ActulizarOrdenesProduccionMuestra(vXmlOrdenes.ToString())
            Dim mensajeExito As New ExitoForm
            mensajeExito.mensaje = "Los cambios se realizaron correctamente."
            mensajeExito.ShowDialog()

            LlenarGridPedidosMuestrasOP()
        Catch ex As Exception

            Dim mensajeError As New ErroresForm
            mensajeError.mensaje = ex.Message
            mensajeError.ShowDialog()
        Finally

            Cursor = Cursors.Default
        End Try
    End Sub



    Private Sub grdVPeidosMuestrasOP_RowStyle(sender As Object, e As RowStyleEventArgs) Handles grdVPeidosMuestrasOP.RowStyle
        If cmbEstatus.Text = "EN PRODUCCION" Then
            If grdVPeidosMuestrasOP.GetRowCellValue(e.RowHandle, "NaveIdOriginal") <> grdVPeidosMuestrasOP.GetRowCellValue(e.RowHandle, "NaveProduccion") Or
                grdVPeidosMuestrasOP.GetRowCellValue(e.RowHandle, "FCorteOriginal") <> grdVPeidosMuestrasOP.GetRowCellValue(e.RowHandle, "FechaEntregaPropuesta") Then
                e.Appearance.ForeColor = Color.DarkRed
            End If
        End If
        If cmbEstatus.Text = "AUTORIZADOS BLOQUEADOS" Then
            If grdVPeidosMuestrasOP.GetRowCellValue(e.RowHandle, "DeptoId") = 294 And
                                    ((grdVPeidosMuestrasOP.GetRowCellValue(e.RowHandle, "PE_Status") = "3") Or
                                    (grdVPeidosMuestrasOP.GetRowCellValue(e.RowHandle, "PE_Status") = "6") Or
                                    (grdVPeidosMuestrasOP.GetRowCellValue(e.RowHandle, "PE_Status") = "7")) Then
                e.Appearance.ForeColor = Color.DarkOrange
            ElseIf grdVPeidosMuestrasOP.GetRowCellValue(e.RowHandle, "DeptoId") <> 294 And
                                    ((grdVPeidosMuestrasOP.GetRowCellValue(e.RowHandle, "PE_Status") = "1") Or
                                    (grdVPeidosMuestrasOP.GetRowCellValue(e.RowHandle, "PE_Status") = "3") Or
                                    (grdVPeidosMuestrasOP.GetRowCellValue(e.RowHandle, "PE_Status") = "6") Or
                                    (grdVPeidosMuestrasOP.GetRowCellValue(e.RowHandle, "PE_Status") = "7")) Then
                e.Appearance.ForeColor = Color.DarkOrange
            End If
        End If

        '' CAMBIOS OAMB (20/05/2024) - Se agregó la opción de marcar en naranja aquellos pedidos con fechas propuestas incorrectas.
        If cmbEstatus.Text = "AUTORIZADOS PRODUCCION" Then
            If grdVPeidosMuestrasOP.GetRowCellValue(e.RowHandle, "FechaEntregaPropuesta") = "01/01/1900" Then
                e.Appearance.ForeColor = Color.DarkOrange
            End If
        End If
    End Sub

    Private Sub chFecha_CheckedChanged(sender As Object, e As EventArgs) Handles chFecha.CheckedChanged

        Dim ch As New CheckBox
        ch = sender

        If ch.Checked = True Then
            dtpCambioFecha.Enabled = True
        Else
            dtpCambioFecha.Enabled = False
        End If

    End Sub

    Private Sub exportOptions_CustomizeCell(ByVal e As DevExpress.Export.CustomizeCellEventArgs)


        Dim EstatusID As Integer = grdVPeidosMuestrasOP.GetRowCellValue(e.RowHandle, "EstatusID")
        'Dim Bloqueado As String = grdVentas.GetRowCellValue(e.RowHandle, "BE")
        'Dim TotalErrores As Integer = 0
        'Dim TotalIncidencias As Integer = 0

        Try

            If EstatusID = 130 Then
                e.Formatting.BackColor = Color.Azure

            End If


            '    If e.ColumnFieldName = "ColorEstatus" Then
            '        e.Formatting.BackColor = ObtenerColorStatusOT(grdVentas.GetRowCellValue(e.RowHandle, "EstatusID"))

            '    End If

            '    If TipoPerfil = 2 Then

            '        If chkDetallada.Checked = False Then
            '            If e.ColumnFieldName = "TotalErrores" Then
            '                TotalErrores = grdVentas.GetRowCellValue(e.RowHandle, "TotalErrores")
            '                If TotalErrores > 0 Then
            '                    e.Formatting.Font.Color = Color.Red
            '                Else
            '                    e.Formatting.Font.Color = Color.Black
            '                End If
            '            End If
            '        End If



            '        If e.ColumnFieldName = "TotalIncidencias" Then
            '            TotalIncidencias = grdVentas.GetRowCellValue(e.RowHandle, "TotalIncidencias")

            '            If TotalIncidencias > 0 Then
            '                e.Formatting.Font.Color = Color.Red
            '            Else
            '                e.Formatting.Font.Color = Color.Black
            '            End If
            '        End If

            '        If e.ColumnFieldName = "FechaValidoAlmacen" Then
            '            If IsDBNull(grdVentas.GetRowCellValue(e.RowHandle, "UsuarioValidoAlmacen")) = False Then
            '                If EstatusID = "129" Or EstatusID = "130" Then
            '                    e.Formatting.Font.Color = Color.Red
            '                Else
            '                    e.Formatting.Font.Color = Color.Green
            '                End If
            '            End If

            '        End If

            '        If e.ColumnFieldName = "UsuarioValidoAlmacen" Then
            '            If IsDBNull(grdVentas.GetRowCellValue(e.RowHandle, "UsuarioValidoAlmacen")) = False Then
            '                If EstatusID = "129" Or EstatusID = "130" Then
            '                    e.Formatting.Font.Color = Color.Red
            '                Else
            '                    e.Formatting.Font.Color = Color.Green
            '                End If
            '            End If

            '        End If


            '    End If

        Catch ex As Exception
            Dim mensaje As New ErroresForm
            mensaje.mensaje = ex.Message.ToString
            mensaje.ShowDialog()
        End Try
        'e.Handled = True
    End Sub

    Private Sub grdPedidosMuestrasOP_DoubleClick(sender As Object, e As EventArgs) Handles grdPedidosMuestrasOP.DoubleClick
        Try

            If Accion = 1 Or Accion = 5 Then

                Dim entidadOP As New Entidades.OrdenesProduccionMuestras
                entidadOP.pdetorm_cantsolicitada = CInt(grdVPeidosMuestrasOP.GetFocusedRowCellValue("Cantidad"))
                entidadOP.Disponible = CInt(grdVPeidosMuestrasOP.GetFocusedRowCellValue("Disponibles"))
                entidadOP.pdetorm_productoestiloid = grdVPeidosMuestrasOP.GetFocusedRowCellValue("Articulo").ToString
                entidadOP.pdetorm_pedidoid = grdVPeidosMuestrasOP.GetFocusedRowCellValue("FolioDePedido").ToString
                entidadOP.pdetorm_unidadmedidaid = grdVPeidosMuestrasOP.GetFocusedRowCellValue("idUDM")
                entidadOP.pdetorm_talla = grdVPeidosMuestrasOP.GetFocusedRowCellValue("Talla").ToString
                entidadOP.EnviarAproducir = grdVPeidosMuestrasOP.GetFocusedRowCellValue("EnviarAProducir").ToString
                If entidadOP.Disponible > 0 Then
                    Dim apartarForm As New ApartarMuestrasForm
                    apartarForm.RecibirDatos(entidadOP)
                    apartarForm.ShowDialog()
                    LlenarGridPedidosMuestrasOP()
                Else
                    Dim mensaje As New AdvertenciaForm
                    mensaje.mensaje = "No existen disponibles para apartar."
                    mensaje.ShowDialog()
                End If
                'PedidosMuestraDetalles.MdiParent = Me.MdiParent
            End If
        Catch ex As Exception
            MsgBox(" Debe seleccionar un registro.")
        End Try
    End Sub







#Region "Botones" '' CAMBIOS OAMB (13/05/2024)

    Private Sub btnGenerarColocacion_Click(sender As Object, e As EventArgs) Handles btnGenerarColocacion.Click
        Dim filasSeleccionadas As Integer = 0

        Try
            Cursor = Cursors.WaitCursor

            For fila As Integer = 0 To grdVPeidosMuestrasOP.DataRowCount Step 1
                If grdVPeidosMuestrasOP.GetRowCellValue(fila, "Sel") Then
                    filasSeleccionadas += 1
                End If
            Next

            If filasSeleccionadas > 0 Then
                GeneracionColocacionPedidosCompleto(chkFechaEntregaPropuesta.Checked, dtpFechaEntregaPropuesta)
                'NotificacionesGlobales.MostrarNotificacionPorNombre("Toast_Muestras_OP_GeneracionColocacionCorrecta")
            Else
                Tools.MostrarMensaje(Mensajes.Warning, "¡No ha seleccionado pedidos para la generación de colocación!")
            End If
        Catch ex As Exception
            Tools.MostrarMensaje(Mensajes.Fault, ex.Message)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

#End Region



#Region "Métodos" '' CAMBIOS OAMB (20/05/2024)

    Private Sub VerificarRutaDescargas()
        Try
            If Not Directory.Exists(rutaDescargas) Then
                rutaDescargas = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\3. NAVES DE PRODUCCIÓN\"
                If Not Directory.Exists(rutaDescargas) Then
                    Directory.CreateDirectory(rutaDescargas)
                End If
            End If
        Catch ex As Exception
            Tools.MostrarMensaje(Mensajes.Warning, "Ocurrió un problema al buscar la ruta de descargas.")
        End Try
    End Sub

    Private Sub FechasEntregaMuestras(ByVal RestriccionCuatroDias As Boolean)
        If RestriccionCuatroDias = False Then

            dtpFechaEntregaPropuesta.MinDate = Date.Now
            dtpCambioFecha.MinDate = Date.Now
        Else

            dtpFechaEntregaPropuesta.MinDate = Date.Now.AddDays(4)
            dtpCambioFecha.MinDate = Date.Now.AddDays(4)
        End If
    End Sub

    Private Sub IniciarTimerConsultarSesiones()
        Try

            timerRevisionSesionAdminOP.Interval = 10000 '' Asignamos un tiempo de diez segundos al timer para que consulte a ese ritmo la tabla de Work con los datos de las sesiones.
            timerRevisionSesionAdminOP.Enabled = True
            AddHandler timerRevisionSesionAdminOP.Tick, AddressOf ConsultarSesionActualAdministradorOPMuestras  '' Asignamos el método que revisa la sesión en la base de datos al timer.
        Catch ex As Exception

            Tools.MostrarMensaje(Mensajes.Warning, "A surgido un error al consultar las sesiones actuales: " + ex.Message)
        End Try
    End Sub

    Private Sub RegistrarSesionActual(ByVal UsuarioId As Integer, ByVal NombreFormulario As String)
        Try
            objBU.RegistrarSesionActualMuestrasFormulario(UsuarioId, NombreFormulario)
        Catch ex As Exception
            Tools.MostrarMensaje(Mensajes.Warning, "A ocurrido un error al registrar la sesión: " + ex.Message)
        End Try
    End Sub

    Private Sub CerrarSesionActual(ByVal UsuarioId As Integer, ByVal NombreFormulario As String)
        Try
            timerRevisionSesionAdminOP.Enabled = False
            objBU.CerrarSesionActualMuestrasFormulario(UsuarioId, NombreFormulario)
        Catch ex As Exception
            Tools.MostrarMensaje(Mensajes.Warning, "A ocurrido un error al registrar la sesión: " + ex.Message)
        End Try
    End Sub

    Private Sub GeneracionColocacionPedidosCompleto(ByVal FechaEntregaPropuestaActiva As Boolean, ByVal dtpFecha As DateTimePicker)
        Dim dsColocacionPedidosMuestras As New DataSet
        Dim dtDistribucionDeColocacion As DataTable
        Dim dtPedidosGenerarColocacion As New DataTable
        Dim dtPedidosDistribucionColocacion As New DataTable

        Dim FechaEntregaPropuesta As String = ""

        Dim vXmlPedidosMuestras = New XElement("PedidosMuestras")

        Try

            For filaActual As Integer = 0 To grdVPeidosMuestrasOP.DataRowCount - 1
                If grdVPeidosMuestrasOP.GetRowCellValue(filaActual, "Sel") = True Then

                    Dim vNodo As XElement = New XElement("Pedido")
                    vNodo.Add(New XAttribute("FolioDePedido", grdVPeidosMuestrasOP.GetRowCellValue(filaActual, "FolioDePedido")))
                    vNodo.Add(New XAttribute("NaveDesarrollo", grdVPeidosMuestrasOP.GetRowCellValue(filaActual, "NaveDesarrollo")))
                    vNodo.Add(New XAttribute("NaveProduccion", grdVPeidosMuestrasOP.GetRowCellValue(filaActual, "NaveProduccion")))
                    vNodo.Add(New XAttribute("Articulo", grdVPeidosMuestrasOP.GetRowCellValue(filaActual, "Articulo")))
                    vNodo.Add(New XAttribute("Talla", grdVPeidosMuestrasOP.GetRowCellValue(filaActual, "Talla")))
                    vNodo.Add(New XAttribute("Cantidad", grdVPeidosMuestrasOP.GetRowCellValue(filaActual, "Cantidad")))
                    vXmlPedidosMuestras.Add(vNodo)
                End If
            Next


            '' Si el usuario a seleccionado la casilla de la fecha programación propuesta, el sistema tomará la fecha como su punto de partida sin importar la fecha actual.
            If FechaEntregaPropuestaActiva = True Then
                FechaEntregaPropuesta = CStr(dtpFecha.Value.ToShortDateString)
            Else
                FechaEntregaPropuesta = ""
            End If


            '' Enviamos la cadena json a un SP que generará la colocación de la entrega por las capacidades de la nave.
            dsColocacionPedidosMuestras = objBU.GenerarColocacionPedidosMuestras(vXmlPedidosMuestras.ToString(), FechaEntregaPropuesta)


            dtPedidosGenerarColocacion = New DataTable("dtPedidosGenerarColocacion")
            dtDistribucionDeColocacion = New DataTable("dtDistribucionDeColocacion")


            '' EN PRODUCCION están separados los pedidos por OPs, entonces no necesitamos la división para cada OP.
            If cmbEstatus.Text = "EN PRODUCCION" Then
                dtPedidosGenerarColocacion = dsColocacionPedidosMuestras.Tables(1)
                dtDistribucionDeColocacion = dsColocacionPedidosMuestras.Tables(1)
            Else
                dtPedidosGenerarColocacion = dsColocacionPedidosMuestras.Tables(0)
                dtDistribucionDeColocacion = dsColocacionPedidosMuestras.Tables(1)
            End If



            If dtPedidosGenerarColocacion IsNot Nothing AndAlso dtDistribucionDeColocacion IsNot Nothing Then
                If dtPedidosGenerarColocacion.Rows.Count > 0 AndAlso dtDistribucionDeColocacion.Rows.Count > 0 Then

                    '' Este contador es para tomar en órden los pedidos devueltos en el dataTable (no coincidirían si fueran por el índice).
                    Dim contadorGenerarColocacion As Integer = 0

                    For filaActual As Integer = 0 To grdVPeidosMuestrasOP.RowCount - 1 Step 1
                        If grdVPeidosMuestrasOP.GetRowCellValue(filaActual, "Sel") = True Then   '' Modificaremos la fecha propuesta entrega solo de los pedidos seleccionados.

                            '' Asignamos la fecha propuesta resultante del SP.
                            grdVPeidosMuestrasOP.SetRowCellValue(filaActual, "FechaEntregaPropuesta", CDate(dtPedidosGenerarColocacion.Rows(contadorGenerarColocacion).Item("FechaAsignada")))

                            contadorGenerarColocacion += 1
                        End If
                    Next


                    listaDatosColocacionCompleto = New List(Of DatosColocacion)

                    For filaActual As Integer = 0 To dtDistribucionDeColocacion.Rows.Count - 1 Step 1

                        Dim datos = New DatosColocacion()

                        datos.FolioDePedido = dtDistribucionDeColocacion.Rows(filaActual).Item("FolioDePedido")
                        datos.FechaAsignada = dtDistribucionDeColocacion.Rows(filaActual).Item("FechaAsignada")
                        datos.NaveDesarrollo = dtDistribucionDeColocacion.Rows(filaActual).Item("NaveDesarrollo")
                        datos.NaveProduccion = dtDistribucionDeColocacion.Rows(filaActual).Item("NaveProduccion")
                        datos.Articulo = dtDistribucionDeColocacion.Rows(filaActual).Item("Articulo")
                        datos.Talla = dtDistribucionDeColocacion.Rows(filaActual).Item("Talla")
                        datos.Cantidad = dtDistribucionDeColocacion.Rows(filaActual).Item("Cantidad")

                        listaDatosColocacionCompleto.Add(datos)
                    Next
                Else

                    Tools.MostrarMensaje(Mensajes.Warning, "¡No ha sido posible generar la colocación!")
                End If
            End If
        Catch ex As Exception
            Tools.MostrarMensaje(Mensajes.Warning, "A ocurrido un error al generar la colocación: " + ex.Message)
        End Try
    End Sub

    Private Sub GeneracionColocacionPedido(ByVal datosColocacion As DatosColocacion, ByVal FechaEntregaPropuesta As String)
        Dim dsColocacionPedidosMuestras As New DataSet
        Dim dtDistribucionDeColocacion As DataTable
        Dim dtPedidosGenerarColocacion As New DataTable
        Dim dtPedidosDistribucionColocacion As New DataTable

        Dim vXmlPedidosMuestras = New XElement("PedidosMuestras")

        Try

            Dim vNodo As XElement = New XElement("Pedido")
            vNodo.Add(New XAttribute("FolioDePedido", datosColocacion.FolioDePedido))
            vNodo.Add(New XAttribute("NaveDesarrollo", datosColocacion.NaveDesarrollo))
            vNodo.Add(New XAttribute("NaveProduccion", datosColocacion.NaveProduccion))
            vNodo.Add(New XAttribute("Articulo", datosColocacion.Articulo))
            vNodo.Add(New XAttribute("Talla", datosColocacion.Talla))
            vNodo.Add(New XAttribute("Cantidad", datosColocacion.Cantidad))
            vXmlPedidosMuestras.Add(vNodo)



            '' Enviamos la cadena json a un SP que generará la colocación de la entrega por las capacidades de la nave.
            dsColocacionPedidosMuestras = objBU.GenerarColocacionPedidosMuestras(vXmlPedidosMuestras.ToString(), FechaEntregaPropuesta)


            dtPedidosGenerarColocacion = New DataTable("dtPedidosGenerarColocacion")
            dtDistribucionDeColocacion = New DataTable("dtDistribucionDeColocacion")


            '' EN PRODUCCION están separados los pedidos por OPs, entonces necesitamos la división para cada OP.
            If cmbEstatus.Text = "EN PRODUCCION" Then
                dtPedidosGenerarColocacion = dsColocacionPedidosMuestras.Tables(1)
                dtDistribucionDeColocacion = dsColocacionPedidosMuestras.Tables(1)
            Else
                dtPedidosGenerarColocacion = dsColocacionPedidosMuestras.Tables(0)
                dtDistribucionDeColocacion = dsColocacionPedidosMuestras.Tables(1)
            End If



            If dtPedidosGenerarColocacion IsNot Nothing AndAlso dtDistribucionDeColocacion IsNot Nothing Then
                If dtPedidosGenerarColocacion.Rows.Count > 0 AndAlso dtDistribucionDeColocacion.Rows.Count > 0 Then

                    listaDatosColocacionPedido = New List(Of DatosColocacion)

                    For filaActual As Integer = 0 To dtDistribucionDeColocacion.Rows.Count - 1 Step 1

                        Dim datos = New DatosColocacion()

                        datos.FolioDePedido = dtDistribucionDeColocacion.Rows(filaActual).Item("FolioDePedido")
                        datos.FechaAsignada = dtDistribucionDeColocacion.Rows(filaActual).Item("FechaAsignada")
                        datos.NaveDesarrollo = dtDistribucionDeColocacion.Rows(filaActual).Item("NaveDesarrollo")
                        datos.NaveProduccion = dtDistribucionDeColocacion.Rows(filaActual).Item("NaveProduccion")
                        datos.Articulo = dtDistribucionDeColocacion.Rows(filaActual).Item("Articulo")
                        datos.Talla = dtDistribucionDeColocacion.Rows(filaActual).Item("Talla")
                        datos.Cantidad = dtDistribucionDeColocacion.Rows(filaActual).Item("Cantidad")

                        listaDatosColocacionPedido.Add(datos)
                    Next
                Else

                    Tools.MostrarMensaje(Mensajes.Warning, "¡No ha sido posible generar la colocación!")
                End If
            End If
        Catch ex As Exception
            Tools.MostrarMensaje(Mensajes.Warning, "A ocurrido un error al generar la colocación: " + ex.Message)
        End Try
    End Sub



#End Region



#Region "Eventos"   '' CAMBIOS OAMB (13/05/2024)


    '' CAMBIOS OAMB (20/05/2024) -
    Private Sub chkFechaEntregaPropuesta_CheckedChanged(sender As Object, e As EventArgs) Handles chkFechaEntregaPropuesta.CheckedChanged

        If chkFechaEntregaPropuesta.Checked Then

            dtpFechaEntregaPropuesta.Enabled = True
        Else

            dtpFechaEntregaPropuesta.Enabled = False
        End If
    End Sub



    '' CAMBIOS OAMB (21/05/2024) - Evento que permite la asignación de múltiples naves producción a las filas seleccionadas.
    Private Sub grdVPeidosMuestrasOP_CellValueChanging(sender As Object, e As Views.Base.CellValueChangedEventArgs) Handles grdVPeidosMuestrasOP.CellValueChanging
        Dim nombreNaveProduccionSeleccionada = e.Value

        If e.Column.FieldName = "NaveProduccion" Then   '' Si la columna modificada es NaveProduccion (celda que tiene un combobox incluído con las naves), entramos.

            grdVPeidosMuestrasOP.SetRowCellValue(e.RowHandle, "NaveProduccion", nombreNaveProduccionSeleccionada)
        End If
    End Sub



    Dim bloqueoEdicionNaveProduccion As Boolean = False

    '' CAMBIOS OAMB (09/05/2024) - Evento que bloquea la modificación de aquellas celdas de la columna NaveProducción cuyos productos tengan estatus PROTOTIPO o MUESTRAS (solo las naves desarrollo pueden producir estos artículos).
    Private Sub grdVPeidosMuestrasOP_ShowingEditor(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles grdVPeidosMuestrasOP.ShowingEditor
        '' Obtenemos la información de la ubicación actual del mouse.
        Dim hitInfo As GridHitInfo = grdVPeidosMuestrasOP.CalcHitInfo(grdPedidosMuestrasOP.PointToClient(MousePosition))

        '' Si el usuario selecciona la columna NaveProduccion, entramos.
        If grdVPeidosMuestrasOP.FocusedColumn.FieldName = "NaveProduccion" Then

            If grdVPeidosMuestrasOP.GetRowCellValue(hitInfo.RowHandle, "BloqueoNaveProduccion") = 1 Then    '' Si la columna BloqueoNaveProduccion es igual a uno, significa que el artículo del pedido tiene estatus PROTOTIPO o MUESTRAS.

                bloqueoEdicionNaveProduccion = True
            Else
                bloqueoEdicionNaveProduccion = False
            End If

            e.Cancel = bloqueoEdicionNaveProduccion
        End If
    End Sub

    Private Sub grdVPeidosMuestrasOP_ShownEditor(sender As Object, e As EventArgs) Handles grdVPeidosMuestrasOP.ShownEditor
        '' Obtenemos la información de la ubicación actual del mouse.
        Dim hitInfo As GridHitInfo = grdVPeidosMuestrasOP.CalcHitInfo(grdPedidosMuestrasOP.PointToClient(MousePosition))

        '' Si el usuario selecciona la columna NaveProduccion, entramos.
        If grdVPeidosMuestrasOP.FocusedColumn.FieldName = "NaveProduccion" Then

            If bloqueoEdicionNaveProduccion = False Then

                Dim lookup As LookUpEdit = TryCast(grdVPeidosMuestrasOP.ActiveEditor, LookUpEdit)
                lookup.Properties.DataSource = objBU.ConsultarNavesProduccion()
            End If
        End If

    End Sub



    '' CAMBIOS OAMB (22/05/2024) -
    Private Sub dtpFechaEntregaPropuesta_ValueChanged(sender As Object, e As EventArgs) Handles dtpFechaEntregaPropuesta.ValueChanged

        If (dtpFechaEntregaPropuesta.Value.DayOfWeek = DayOfWeek.Sunday) Then

            '' Si el usuario llegara a seleccionar un día domingo como fecha, el sistema siempre cambiará el día a Lunes.
            dtpFechaEntregaPropuesta.Value = dtpFechaEntregaPropuesta.Value.AddDays(1)
        End If
    End Sub

    '' CAMBIOS OAMB (22/05/2024) -
    Private Sub dtpCambioFecha_ValueChanged(sender As Object, e As EventArgs) Handles dtpCambioFecha.ValueChanged

        If (dtpCambioFecha.Value.DayOfWeek = DayOfWeek.Sunday) Then

            '' Si el usuario llegara a seleccionar un día domingo como fecha, el sistema siempre cambiará el día a Lunes.
            dtpCambioFecha.Value = dtpCambioFecha.Value.AddDays(1)
        End If
    End Sub

    '' CAMBIOS OAMB (21/05/2024) - Evento que evita que la fecha programación sea día domingo.
    Private Sub grdVPeidosMuestrasOP_CellValueChanged(sender As Object, e As Views.Base.CellValueChangedEventArgs) Handles grdVPeidosMuestrasOP.CellValueChanged
        '' Si la columna modificada es FechaEntregaPropuesta, entramos.
        If e.Column.FieldName = "FechaEntregaPropuesta" Then
            If (e.Value.DayOfWeek = DayOfWeek.Sunday) Then

                '' Si el usuario llegara a seleccionar un día domingo como fecha, el sistema siempre cambiará el día a Lunes.
                grdVPeidosMuestrasOP.SetRowCellValue(e.RowHandle, "FechaEntregaPropuesta", e.Value.AddDays(1))
            End If
        End If
    End Sub



    '' CAMBIOS OAMB (22/05/2024) - Evento que cierra la sesión del usuario cada vez que el formulario se cierra, no importa la razón.
    Private Sub AdministradorOPpedidosMuestrasForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        CerrarSesionActual(usuarioIdFormulario, nombreFormulario)
    End Sub

    '' CAMBIOS OAMB (22/05/2024) -
    Private Sub grdVPeidosMuestrasOP_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs) Handles grdVPeidosMuestrasOP.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1 'Numeramos la columna de indicador
        End If
    End Sub

#End Region



#Region "Mover filas en diferentes posiciones (Drag and Drop)"  '' CAMBIOS OAMB (13/05/2024)

    Private Sub Behavior_DragOver(ByVal sender As Object, ByVal e As DragOverEventArgs)
        Dim args As DragOverGridEventArgs = DragOverGridEventArgs.GetDragOverGridEventArgs(e)
        e.InsertType = args.InsertType
        e.InsertIndicatorLocation = args.InsertIndicatorLocation
        e.Action = args.Action
        Cursor.Current = args.Cursor
        args.Handled = True


        '' Auto-Desplazamiento
        If grdVPeidosMuestrasOP IsNot Nothing Then
            Dim gridViewInfo As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridViewInfo = CType(grdVPeidosMuestrasOP.GetViewInfo(), DevExpress.XtraGrid.Views.Grid.ViewInfo.GridViewInfo)
            Dim posicionMouse As Point = grdVPeidosMuestrasOP.GridControl.PointToClient(Cursor.Position)


            ' Obtener limite del GridView
            Dim limitesGrid As Rectangle = gridViewInfo.ViewRects.Bounds
            '' Margen
            Dim umbralDesplazamiento As Integer = 70


            ' Comprueba si el ratón está cerca de la parte inferior/superior del área visible.
            If posicionMouse.Y >= limitesGrid.Bottom - umbralDesplazamiento Then
                If grdVPeidosMuestrasOP.TopRowIndex < grdVPeidosMuestrasOP.RowCount - 1 Then
                    grdVPeidosMuestrasOP.TopRowIndex += 1
                End If
            ElseIf posicionMouse.Y <= limitesGrid.Top + umbralDesplazamiento Then
                If grdVPeidosMuestrasOP.TopRowIndex > 0 Then
                    grdVPeidosMuestrasOP.TopRowIndex -= 1
                End If
            End If
        End If
    End Sub

    Private Sub Behavior_DragDrop(ByVal sender As Object, ByVal e As DevExpress.Utils.DragDrop.DragDropEventArgs)
        Dim targetGrid As GridView = TryCast(e.Target, GridView)
        Dim sourceGrid As GridView = TryCast(e.Source, GridView)
        If e.Action = DragDropActions.None OrElse targetGrid IsNot sourceGrid Then
            Return
        End If
        Dim sourceTable As DataTable = TryCast(sourceGrid.GridControl.DataSource, DataTable)

        Dim hitPoint As Point = targetGrid.GridControl.PointToClient(Cursor.Position)
        Dim hitInfo As GridHitInfo = targetGrid.CalcHitInfo(hitPoint)


        'Dim sourceHandles() As Integer = e.GetData(Of Integer())() '' Si se desea la selección por una sola fila, se debe descomentar esta línea y comentar la otra. También, desactivar el MultiSelect al cargar la pantalla.
        Dim sourceHandles() As Integer = sourceGrid.GetSelectedRows()


        Dim targetRowHandle As Integer = hitInfo.RowHandle
        Dim targetRowIndex As Integer = targetGrid.GetDataSourceRowIndex(targetRowHandle)

        Dim draggedRows As New List(Of DataRow)()
        For Each sourceHandle As Integer In sourceHandles
            Dim oldRowIndex As Integer = sourceGrid.GetDataSourceRowIndex(sourceHandle)
            Dim oldRow As DataRow = sourceTable.Rows(oldRowIndex)
            draggedRows.Add(oldRow)
        Next sourceHandle

        Dim newRowIndex As Integer

        Select Case e.InsertType
            Case InsertType.Before
                newRowIndex = If(targetRowIndex > sourceHandles(sourceHandles.Length - 1), targetRowIndex - 1, targetRowIndex)
                If newRowIndex >= 0 Then
                    For i As Integer = draggedRows.Count - 1 To 0 Step -1
                        Dim oldRow As DataRow = draggedRows(i)
                        Dim newRow As DataRow = sourceTable.NewRow()
                        newRow.ItemArray = oldRow.ItemArray
                        sourceTable.Rows.Remove(oldRow)
                        sourceTable.Rows.InsertAt(newRow, newRowIndex)
                    Next i
                Else
                    newRowIndex = -1
                End If
            Case InsertType.After
                newRowIndex = If(targetRowIndex < sourceHandles(0), targetRowIndex + 1, targetRowIndex)
                If newRowIndex >= 0 Then
                    For i As Integer = 0 To draggedRows.Count - 1
                        Dim oldRow As DataRow = draggedRows(i)
                        Dim newRow As DataRow = sourceTable.NewRow()
                        newRow.ItemArray = oldRow.ItemArray
                        sourceTable.Rows.Remove(oldRow)
                        sourceTable.Rows.InsertAt(newRow, newRowIndex)
                    Next i
                Else
                    newRowIndex = -1
                End If
            Case Else
                newRowIndex = -1
        End Select
        Dim insertedIndex As Integer = targetGrid.GetRowHandle(newRowIndex)
        targetGrid.FocusedRowHandle = insertedIndex
        targetGrid.SelectRow(targetGrid.FocusedRowHandle)
    End Sub

#End Region


    Private actualizacionMasivaNavesActiva As Boolean = False
    Private Sub ActualizarNavesMasivamente(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs)
        ' Verifica si la actualización masiva está en curso para evitar bucles infinitos
        If actualizacionMasivaNavesActiva = True Then
            Return
        End If

        ' Solo ejecuta el código si el cambio ocurrió en la columna "NaveProduccion"
        If e.Column.FieldName = "NaveProduccion" Then
            Dim NumeroFilas = grdVPeidosMuestrasOP.DataRowCount
            Dim totalPedidosModificarNaves As Integer = 0
            For index As Integer = 0 To NumeroFilas Step 1
                If grdVPeidosMuestrasOP.GetRowCellValue(index, "Sel") Then
                    totalPedidosModificarNaves += 1
                End If
            Next

            If totalPedidosModificarNaves > 1 Then
                Dim naveSeleccionada As Integer = CInt(e.Value)

                ' Activa la bandera para indicar que estamos en modo de actualización masiva.
                actualizacionMasivaNavesActiva = True

                ' Llama a la función para aplicar el valor a todas las filas seleccionadas.
                CambiarNavePedidos(naveSeleccionada)

                ' Desactiva la bandera después de que el proceso haya terminado.
                actualizacionMasivaNavesActiva = False
            End If
        End If
    End Sub

    Private Sub CambiarNavePedidos(nuevoValorSeleccionado As Integer)
        Dim formaConfirmacion As New ConfirmarForm
        formaConfirmacion.StartPosition = FormStartPosition.CenterParent
        formaConfirmacion.mensaje = "¿Estás seguro de querer modificar todos los pedidos seleccionados a la nave seleccionada?"
        Dim confirmacionUsuario As DialogResult = formaConfirmacion.ShowDialog()

        If confirmacionUsuario = DialogResult.OK Then
            ' Recorre cada fila seleccionada y actualiza el valor de la columna "NaveProduccion"
            Dim NumeroFilas = grdVPeidosMuestrasOP.DataRowCount
            For fila As Integer = 0 To NumeroFilas Step 1
                If grdVPeidosMuestrasOP.GetRowCellValue(fila, "Sel") Then
                    grdVPeidosMuestrasOP.SetRowCellValue(fila, "NaveProduccion", nuevoValorSeleccionado)
                End If
            Next
        End If
    End Sub



#Region "Timer que consulta la sesión."

    Private Sub ConsultarSesionActualAdministradorOPMuestras()
        Dim dtUsuarioSesion As New DataTable

        Dim prioridadSesion As Integer = 0
        Dim usuarioIdProyectando As Integer = 0
        Dim usuarioProyectando As String = ""

        Try

            '' Buscamos la información de la sesión actual.
            dtUsuarioSesion = objBU.ConsultarSesionActualMuestrasFormulario(nombreFormulario)

            If dtUsuarioSesion IsNot Nothing Then
                If dtUsuarioSesion.Rows.Count > 0 Then

                    prioridadSesion = dtUsuarioSesion.Rows(0).Item("PrioridadSesion")
                    usuarioIdProyectando = dtUsuarioSesion.Rows(0).Item("UsuarioId")
                    usuarioProyectando = dtUsuarioSesion.Rows(0).Item("NombreUsuario")
                End If
            End If


            '' Si el estatus consultado por el usuario es AUTORIZADOS PRODUCCION, entramos.
            If Accion = 1 Then
                '' Si el usuario proyectando es el mismo usuario que está consultando la pantalla, entramos.
                If usuarioIdProyectando = usuarioIdFormulario Then

                    '' Si la prioridad del usuario es igual a 1 (el usuario que entró primero y/o es quien está proyectando), entramos.
                    If prioridadSesion = 1 Then

                        '' Si el nombre del usuario que está proyectando (db) es distinto al usuario que está consultando la pantalla (SAY), significa que el usuario proyectando a cambiado y debemos habilitarle el permiso.
                        If lblNombreUsuarioSesion.Text.Equals(usuarioProyectando) = False Then

                            btnGenerarOP.Enabled = True
                            lblGenerarOP.Enabled = True

                            lblNombreUsuarioSesion.Text = usuarioProyectando


                            '' Mandamos la notificación de la liberación de la proyección.
                            'NotificacionesGlobales.MostrarNotificacionPorNombre("Toast_Muestras_OP_SesionLiberada")
                        End If
                    Else    '' Si el usuario 

                        btnGenerarOP.Enabled = False
                        lblGenerarOP.Enabled = False

                        lblNombreUsuarioSesion.Text = usuarioProyectando
                    End If
                Else    '' Si el usuario proyectando (db) no es el mismo que el usuario consultando la pantalla (SAY), bloqueamos la acción de generar OPs y mostramos al usuario proyectando.

                    btnGenerarOP.Enabled = False
                    lblGenerarOP.Enabled = False

                    lblNombreUsuarioSesion.Text = usuarioProyectando
                End If
            End If
        Catch ex As Exception
            Tools.MostrarMensaje(Mensajes.Warning, "Ah ocurrido un error al consultar la sesión del formulario: " + ex.Message)
        End Try
    End Sub

#End Region



#Region "Diseño de los reportes de OP."

    Private Function ConcatenarOrdenesProduccion(ByVal lstOrdenesProduccionMuestras As List(Of Integer)) As String
        Return String.Join(",", lstOrdenesProduccionMuestras)
    End Function

    Private Sub GenerarReporteFabricacionMuestras(ByVal ordenesProduccion As String, ByVal naveId As Integer, ByVal nombreReporte As String)
        Dim dtOrdenesProduccion As New DataTable

        Dim rutaArchivoExcel As String = ""
        Dim nombreNave As String = ""
        Dim pedidoId As String = ""

        Try
            dtOrdenesProduccion = objBU.ConsultarReporteFabricacionMuestrasOP(ordenesProduccion, naveId)


            If dtOrdenesProduccion.Rows.Count > 0 Then

                '' ------------------------------------------------------------------------------- ''
                '' -------------------------------- VALORES FIJOS -------------------------------- ''
                '' ------------------------------------------------------------------------------- ''

                '' Guardamos el nombre de la nave y eliminas la columna del reporte.
                nombreNave = dtOrdenesProduccion.Rows(0).Item("Nave_Produccion")
                dtOrdenesProduccion.Columns.Remove("Nave_Produccion")

                pedidoId = dtOrdenesProduccion.Rows(0).Item("Pedido_Id").ToString()

                '' ------------------------------------------------------------------------------- ''
                '' -------------------------------- VALORES FIJOS -------------------------------- ''
                '' ------------------------------------------------------------------------------- ''



                rutaArchivoExcel = rutaDescargas + "\\FR.MTR.05. " + nombreReporte + " DE MUESTRAS NAVE " + nombreNave + ". PED. " + pedidoId + "..xlsx"



                '' ----------------------------------------------------------------------------------------------------- ''
                '' ---------------------------------- GENERACIÓN DEL REPORTE DE EXCEL ---------------------------------- ''
                '' ----------------------------------------------------------------------------------------------------- ''

                Dim reporteExcel As New ReportesExcel
                Dim archivoExcel As New Infragistics.Documents.Excel.Workbook
                Dim hojaExcel As Worksheet


                Dim formatoFecha As String = Date.Now.ToString("dd.MM.yyyy")


                '' .RutaArchivo = SpecialDirectories.MyDocuments + "/",    '' <----- Pruebas locales
                '' .RutaArchivo = "G:\2. PROCESOS\2.11 ESPECIALISTAS PROYECTOS\2.6.1 AMUESTRAS\2. PROGRAMACIÓN DE MUESTRAS\3. NAVES DE PRODUCCIÓN\",
                Dim configInicial As New ConfiguracionArchivoExcel With {
                        .ExtensionArchivo = ExtensionArchivoExcel.XLSX,
                        .NombreArchivo = "FR.MTR.05. " + nombreReporte + " DE MUESTRAS NAVE " + nombreNave + ". PED. " + pedidoId,
                        .RutaArchivo = rutaDescargas,
                        .ArchivoExcel = archivoExcel
                    }

                Dim configHojaExcel As New ConfiguracionHojaExcel With {
                        .NombreHoja = "PED. " + pedidoId + ".",
                        .OcultarCuadricula = True,
                        .FijarFila = True,
                        .NumeroFilaFija = 6,
                        .HojaExcel = hojaExcel
                    }

                Dim configEncabezado As New ConfiguracionEncabezado With {
                        .NombreArea = "MUESTRAS",
                        .NombreReporte = nombreReporte + " DE MUESTRAS NAVE " + nombreNave,
                        .NombreVersionDocumento = "REV.01 " + formatoFecha,
                        .Mes = "FR.MTR.05",
                        .NombreResponsable = "RESP.: Esp. Muestras"
                    }

                Dim tamañoColumnas As New List(Of Integer) From {
                        10,   '' Espacio (10 px)
                        90,  '' F. ENTREGA NAVE (90 px)
                        90,  '' PEDIDO (90 px)
                        90,  '' ORDEN DE PRODUC. (90 px)
                        200,    '' CLIENTE (200 px)
                        110,  '' ASUNTO (110 px)
                        180,    '' COLECCIÓN (180 px)
                        70,  '' MODELO (70 px)
                        200,    '' PIEL COLOR (200 px)
                        80,    '' CORTE (80 px)
                        80,    '' FORRO (80 px)
                        90,  '' MARCA (90 px)
                        70,  '' CORRIDA (70 px)
                        60,    '' TALLA (60 px)
                        80,    '' UDM (80 px)
                        70,  '' TOTAL (70 px)
                        10    '' Espacio (10 px)               
                        }

                Dim configInfoReporte As New ConfiguracionInformacionReporte With {
                    .InformacionReporte = dtOrdenesProduccion,
                    .TamañoColumnas = tamañoColumnas,
                    .MostrarTotalGeneral = True
                }

                Dim configImpresion As New ConfiguracionImpresion With {
                    .TamañoHoja = TamañoHojaImpresion.Carta,
                    .OrientacionHoja = OrientacionHoja.Horizontal,
                    .AjustarMargenesImpresion = True,
                    .AjustarContenidoAUnaHoja = True,
                    .ModificarAreaImpresion = False,
                    .AreaImpresion = "A1:R16",
                    .PreguntarAbrirArchivo = False
                }



                ''reporteExcel.GenerarReporteGeneral(configInfoReporte, configInicial, configHojaExcel, configEncabezado)
                reporteExcel.GenerarReporteGeneral(configInfoReporte, configInicial, configHojaExcel, configEncabezado, configImpresion)

                '' ----------------------------------------------------------------------------------------------------- ''
                '' ---------------------------------- GENERACIÓN DEL REPORTE DE EXCEL ---------------------------------- ''
                '' ----------------------------------------------------------------------------------------------------- ''

                'DiseñoReporteExcel(dtOrdenesProduccion, ArchivoExcel, rutaArchivoExcel, pedidoId, nombreNave)
            Else

                Tools.MostrarMensaje(Mensajes.Warning, "Ah ocurrido un error al generar el reporte de las Ordenes de Producción: " + ordenesProduccion)
            End If
        Catch ex As Exception

            Dim ErrorMensajeForm As New ErroresForm
            ErrorMensajeForm.StartPosition = FormStartPosition.CenterScreen
            ErrorMensajeForm.mensaje = "Hubo un error al exportar el reporte: " + ex.Message + "."
            ErrorMensajeForm.ShowDialog()
        End Try

    End Sub

    Private Sub DiseñoReporteExcel(ByVal dtOrdenesProduccion As DataTable, ByVal archivoExcel As Workbook, ByVal rutaArchivo As String, ByVal pedidoId As String, ByVal nombreNave As String)
        Try

            Dim HojaExcel As Worksheet = archivoExcel.Worksheets.Add("PED. " + pedidoId + ".") 'Asignamos nombre a la hoja (PED. 6174.)

            HojaExcel.DisplayOptions.GridlineColor = Color.Transparent 'Quitamos la cuadricula de la hoja de excel 

            Dim ColorBordes As Color = Color.FromArgb(128, 128, 128)
            Dim ColorTablas As System.Drawing.Color = Color.FromArgb(217, 217, 217)



            '' ------------------------------------------------------------------------------------ ''
            '' -------------------------------- ENCABEZADO REPORTE -------------------------------- ''

            Dim MergedEncabezadoLogo As WorksheetMergedCellsRegion = HojaExcel.MergedCellsRegions.Add(1, 1, 2, 2) 'B2:C3. Logo Yuyin
            Dim MergedEncabezadoNombreReporte As WorksheetMergedCellsRegion = HojaExcel.MergedCellsRegions.Add(1, 3, 3, 13) 'D2:N4. Nombre del reporte
            Dim MergedArea As WorksheetMergedCellsRegion = HojaExcel.MergedCellsRegions.Add(3, 1, 3, 2) 'A4:B4. Área

            Dim MergedVersionDocumento As WorksheetMergedCellsRegion = HojaExcel.MergedCellsRegions.Add(1, 14, 1, 15) 'O1:P1.  Versión del documento
            Dim MergedMes As WorksheetMergedCellsRegion = HojaExcel.MergedCellsRegions.Add(2, 14, 2, 15) 'O2:P2.
            Dim MergedResponsable As WorksheetMergedCellsRegion = HojaExcel.MergedCellsRegions.Add(3, 14, 3, 15) 'O3:OP3.   Responsable

            '' Configuración para inmovilizar filas.
            HojaExcel.DisplayOptions.PanesAreFrozen = True
            HojaExcel.DisplayOptions.FrozenPaneSettings.FrozenRows = 6 ' Evita que se muevan de lugar las primeras cinco filas.

            '' -------------------------------- ENCABEZADO REPORTE -------------------------------- ''
            '' ------------------------------------------------------------------------------------ ''



            '' ------------------------------------------------------------------------ ''
            '' -------------------------------- IMAGEN -------------------------------- ''
            '' ------------------------------------------------------------------------ ''

            Dim ImagenLogoYuyin As System.Drawing.Image = Image.FromFile("\\192.168.2.156\Graficos Zebra\Logo_Yuyin.PNG") 'Obtenemos el logo de yuyin 'Image.FromFile("C:\\Users\\SISTEMAS6\\Pictures\\Logo_Yuyin.png") '
            'Dim ImagenLogoYuyin As System.Drawing.Image = Image.FromFile("\\192.168.2.156\Graficos Zebra\prueba lengua\LOGOTIPO NEGRO.PNG")

            Dim ImagenHojaExcel As WorksheetImage = New WorksheetImage(ImagenLogoYuyin)
            ImagenHojaExcel.TopLeftCornerCell = HojaExcel.Rows.Item(1).Cells.Item(1)    '' Delimitamos los margenes y la ubicacion de la imagen
            ImagenHojaExcel.TopLeftCornerPosition = New PointF(70.0F, 70.0F)            '' Ampliación de la imagen
            ImagenHojaExcel.BottomRightCornerCell = HojaExcel.Rows.Item(2).Cells.Item(2)
            ImagenHojaExcel.BottomRightCornerPosition = New PointF(100.0F, 100.0F)
            ImagenHojaExcel.Outline = Nothing   '' Quitamos el contorno de la imagen.

            HojaExcel.Shapes.Add(ImagenHojaExcel) 'Añadimos la imagen (Los archivos con formato WorksheetImage son considerados formas(shapes))

            '' ------------------------------------------------------------------------ ''
            '' -------------------------------- IMAGEN -------------------------------- ''
            '' ------------------------------------------------------------------------ ''



            '' ----------------------------------------------------------------------------------------- ''
            '' -------------------------------- DIMENSIONES DEL REPORTE -------------------------------- ''
            '' ----------------------------------------------------------------------------------------- ''
            '' 1 px en Excel equivalen a 15 en visual (Filas)
            '' 1 px en Excel equivalen a 36.75 en visual (Columnas)

            '' Damos formato al encabezaso del reporte.       
            Dim formatoFecha As String = Date.Now.ToString("dd.MM.yyyy")

            FormatoCeldasCombinadasReporte(MergedEncabezadoLogo, "", 100, ExcelDefaultableBoolean.False, HorizontalCellAlignment.Center, Color.White, ColorBordes, CellBorderLineStyle.Medium)
            FormatoCeldasCombinadasReporte(MergedEncabezadoNombreReporte, "FABRICACIÓN DE MUESTRAS NAVE " + nombreNave, 300, ExcelDefaultableBoolean.True, HorizontalCellAlignment.Center, Color.White, ColorBordes, CellBorderLineStyle.Medium)
            FormatoCeldasCombinadasReporte(MergedArea, "MUESTRAS", 200, ExcelDefaultableBoolean.False, HorizontalCellAlignment.Center, Color.White, ColorBordes, CellBorderLineStyle.Medium)
            FormatoCeldasCombinadasReporte(MergedVersionDocumento, "REV.01 " + formatoFecha, 200, ExcelDefaultableBoolean.False, HorizontalCellAlignment.Left, Color.White, ColorBordes, CellBorderLineStyle.Medium)
            FormatoCeldasCombinadasReporte(MergedMes, "FR.MTR.05", 200, ExcelDefaultableBoolean.False, HorizontalCellAlignment.Left, Color.White, ColorBordes, CellBorderLineStyle.Medium)
            FormatoCeldasCombinadasReporte(MergedResponsable, "RESP.: Esp. Muestras", 200, ExcelDefaultableBoolean.False, HorizontalCellAlignment.Left, Color.White, ColorBordes, CellBorderLineStyle.Medium)

            '' Alto de las filas.
            HojaExcel.Rows(0).Height = 150  '' Espacio (10 px)
            HojaExcel.Rows(1).Height = 450
            HojaExcel.Rows(2).Height = 450
            HojaExcel.Rows(3).Height = 450

            '' 920 px para el alto de la hoja carta

            '' Ancho de las columnas.
            HojaExcel.Columns(0).Width = 367.5      '' Espacio (10 px)
            HojaExcel.Columns(1).Width = 3307.5     '' F. ENTREGA NAVE (90 px)
            HojaExcel.Columns(2).Width = 3307.5     '' PEDIDO (90 px)
            HojaExcel.Columns(3).Width = 3307.5     '' ORDEN DE PRODUC. (90 px)
            HojaExcel.Columns(4).Width = 7350       '' CLIENTE (200 px)
            HojaExcel.Columns(5).Width = 4042.5     '' ASUNTO (110 px)
            HojaExcel.Columns(6).Width = 6615       '' COLECCIÓN (180 px)
            HojaExcel.Columns(7).Width = 2572.5     '' MODELO (70 px)
            HojaExcel.Columns(8).Width = 7350       '' PIEL COLOR (200 px)
            HojaExcel.Columns(9).Width = 2940       '' CORTE (80 px)
            HojaExcel.Columns(10).Width = 2572.5    '' FORRO (70 px)
            HojaExcel.Columns(11).Width = 3307.5    '' MARCA (90 px)
            HojaExcel.Columns(12).Width = 2572.5    '' CORRIDA (70 px)
            HojaExcel.Columns(13).Width = 2205      '' TALLA (60 px)
            HojaExcel.Columns(14).Width = 2940      '' UDM (80 px)
            HojaExcel.Columns(15).Width = 2940      '' TOTAL (80 px)
            HojaExcel.Columns(16).Width = 367.5     '' Espacio (10 px)

            '' Damos formato a los nombres de las columnas.
            FormatoContenidoReporte("Titulo", HojaExcel.Rows.Item(5).Cells.Item(1), "F. ENTREGA NAVE", 200, ColorTablas, ColorBordes)
            FormatoContenidoReporte("Titulo", HojaExcel.Rows.Item(5).Cells.Item(2), "PEDIDO", 200, ColorTablas, ColorBordes)
            FormatoContenidoReporte("Titulo", HojaExcel.Rows.Item(5).Cells.Item(3), "ORDEN DE PRODUC.", 200, ColorTablas, ColorBordes)
            FormatoContenidoReporte("Titulo", HojaExcel.Rows.Item(5).Cells.Item(4), "CLIENTE", 200, ColorTablas, ColorBordes)
            FormatoContenidoReporte("Titulo", HojaExcel.Rows.Item(5).Cells.Item(5), "ASUNTO", 200, ColorTablas, ColorBordes)
            FormatoContenidoReporte("Titulo", HojaExcel.Rows.Item(5).Cells.Item(6), "COLECCIÓN", 200, ColorTablas, ColorBordes)
            FormatoContenidoReporte("Titulo", HojaExcel.Rows.Item(5).Cells.Item(7), "MODELO", 200, ColorTablas, ColorBordes)
            FormatoContenidoReporte("Titulo", HojaExcel.Rows.Item(5).Cells.Item(8), "PIEL COLOR", 200, ColorTablas, ColorBordes)
            FormatoContenidoReporte("Titulo", HojaExcel.Rows.Item(5).Cells.Item(9), "CORTE", 200, ColorTablas, ColorBordes)
            FormatoContenidoReporte("Titulo", HojaExcel.Rows.Item(5).Cells.Item(10), "FORRO", 200, ColorTablas, ColorBordes)
            FormatoContenidoReporte("Titulo", HojaExcel.Rows.Item(5).Cells.Item(11), "MARCA", 200, ColorTablas, ColorBordes)
            FormatoContenidoReporte("Titulo", HojaExcel.Rows.Item(5).Cells.Item(12), "CORRIDA", 200, ColorTablas, ColorBordes)
            FormatoContenidoReporte("Titulo", HojaExcel.Rows.Item(5).Cells.Item(13), "TALLA", 200, ColorTablas, ColorBordes)
            FormatoContenidoReporte("Titulo", HojaExcel.Rows.Item(5).Cells.Item(14), "UDM", 200, ColorTablas, ColorBordes)
            FormatoContenidoReporte("Titulo", HojaExcel.Rows.Item(5).Cells.Item(15), "TOTAL", 200, ColorTablas, ColorBordes)

            '' ----------------------------------------------------------------------------------------- ''
            '' -------------------------------- DIMENSIONES DEL REPORTE -------------------------------- ''
            '' ----------------------------------------------------------------------------------------- ''



            '' -------------------------------------------------------------------------------------------- ''
            '' -------------------------------- CONFIGURACION DE IMPRESIÓN -------------------------------- ''
            '' -------------------------------------------------------------------------------------------- ''

            '' Configuración de impresión
            HojaExcel.PrintOptions.PaperSize = PaperSize.Letter '' Tipo de hoja Carta.
            HojaExcel.PrintOptions.Orientation = Orientation.Landscape  '' Orientezación horizontal.

            '' Configuración de los márgenes ESTRECHO (son las mismas medidas que en Excel). La medida que maneja Infragistics es en pulgadas.
            HojaExcel.PrintOptions.TopMargin = 0.75
            HojaExcel.PrintOptions.BottomMargin = 0.75
            HojaExcel.PrintOptions.LeftMargin = 0.25
            HojaExcel.PrintOptions.RightMargin = 0.25
            HojaExcel.PrintOptions.HeaderMargin = 0.3
            HojaExcel.PrintOptions.FooterMargin = 0.3

            ' Configuración para ajustar hoja en una página.
            HojaExcel.PrintOptions.ScalingType = ScalingType.FitToPages

            '' -------------------------------------------------------------------------------------------- ''
            '' -------------------------------- CONFIGURACION DE IMPRESIÓN -------------------------------- ''
            '' -------------------------------------------------------------------------------------------- ''



            ''  Inicio insercion datos del reporte
            Dim FilaReporte As Integer = 6
            Dim NumRegistros = 0

            For i As Int16 = 0 To dtOrdenesProduccion.Rows.Count - 1 Step 1 'Asignamos el número de la fila de excel donde se insertarán los datos del reporte (5)

                Dim ColumnaReporte As Integer = 1  '' Esta variable es donde inicia la tabla (como existe un margen debemos tomar eso en cuenta).

                HojaExcel.Rows.Item(FilaReporte).Height = 315   '1 px en Excel equivalen a 15 px en visual (Filas)

                For j As Int16 = 0 To dtOrdenesProduccion.Columns.Count - 1 Step 1 'Asignamos el número de la columna de excel donde se insertarán los datos del reporte (1)
                    Dim Valor As String = ""

                    Valor = dtOrdenesProduccion.Rows(i).Item(j).ToString()

                    FormatoContenidoReporte(
                                    "Celda",
                                    HojaExcel.Rows.Item(FilaReporte).Cells.Item(ColumnaReporte),
                                    Valor,
                                    200,
                                    Color.White,
                                    ColorBordes
                                )

                    ColumnaReporte += 1
                Next

                FilaReporte += 1
            Next



            '' Agregamos la barra gris del pie del reporte.
            Dim MergedPiePagina As WorksheetMergedCellsRegion = HojaExcel.MergedCellsRegions.Add(FilaReporte, 1, FilaReporte, 14) 'B*:O*. Barra del pie de reporte.
            FormatoCeldasCombinadasReporte(MergedPiePagina, "TOTAL GENERAL ", 200, ExcelDefaultableBoolean.True, HorizontalCellAlignment.Right, ColorTablas, ColorBordes, CellBorderLineStyle.Default)



            '' Agregamos el cuadro con el total de pares a producir.
            Dim totalParesPedido = (From a In dtOrdenesProduccion.AsEnumerable()
                                    Select a.Field(Of Double)("Total")).Sum()

            FormatoContenidoReporte("Celda", HojaExcel.Rows.Item(FilaReporte).Cells.Item(15), totalParesPedido, 240, ColorTablas, ColorBordes)


            ''Dim formulaTotalMuestras As String = "=SUMA(P7:P" & FilaReporte & ")"

            ''HojaExcel.Rows.Item(FilaReporte).Cells.Item(15).ApplyFormula(formulaTotalMuestras)


            'FormatoContenidoReporte(
            '                        "Celda",
            '                        HojaExcel.Rows.Item(FilaReporte).Cells.Item(15),
            '                        "=SUMA(P7:P" & FilaReporte & ")",
            '                        200,
            '                        Color.White,
            '                        ColorBordes
            '                    )


            '' Asignamos el área de impresión
            FilaReporte += 2    '' Agregamos dos filas extra al área de impresión para tener una fila sola de margen.
            HojaExcel.PrintOptions.PrintAreas.Add(HojaExcel.GetRegion("A1:Q" + CStr(FilaReporte)))



            'Inicio guardado del reporte
            archivoExcel.Save(rutaArchivo)
            'Dim objMensajeExito As New ExitoForm
            'objMensajeExito.StartPosition = FormStartPosition.CenterScreen
            'objMensajeExito.mensaje = "Los datos se exportaron correctamente en la ubicacion \n" + rutaArchivo + ". "
            'objMensajeExito.ShowDialog()
            'Process.Start(rutaArchivo)
            'Fin guardado del reporte
        Catch ex As Exception
            Dim ErrorMensajeForm As New ErroresForm
            ErrorMensajeForm.StartPosition = FormStartPosition.CenterScreen
            ErrorMensajeForm.mensaje = "Hubo un error al exportar el reporte: " + ex.Message + "."
            ErrorMensajeForm.ShowDialog()
        End Try

    End Sub


    Private Sub FormatoCeldasCombinadasReporte(ByVal celdasCombinadas As WorksheetMergedCellsRegion,
                                               ByVal Contenido As String,
                                               ByVal Fuente As Integer,
                                               ByVal NegritaActiva As ExcelDefaultableBoolean,
                                               ByVal AlineacionHorizontal As HorizontalCellAlignment,
                                               ByVal ColorFondo As Color,
                                               ByVal ColorBorde As Color,
                                               ByVal GrosorBorde As CellBorderLineStyle)
        ' Interior celda
        celdasCombinadas.Value = Contenido
        celdasCombinadas.CellFormat.Alignment = AlineacionHorizontal
        celdasCombinadas.CellFormat.VerticalAlignment = VerticalCellAlignment.Center
        celdasCombinadas.CellFormat.Font.Bold = NegritaActiva
        celdasCombinadas.CellFormat.Font.Height = Fuente ' 20 es equivalente a 1 en tamaño letra
        celdasCombinadas.CellFormat.Fill = New CellFillPattern(New WorkbookColorInfo(ColorFondo), WorkbookColorInfo.Automatic, FillPatternStyle.Solid)
        celdasCombinadas.CellFormat.Font.Name = "Arial"


        ' Bordes
        celdasCombinadas.CellFormat.TopBorderStyle = GrosorBorde
        celdasCombinadas.CellFormat.TopBorderColorInfo = New WorkbookColorInfo(ColorBorde)
        celdasCombinadas.CellFormat.RightBorderStyle = GrosorBorde
        celdasCombinadas.CellFormat.RightBorderColorInfo = New WorkbookColorInfo(ColorBorde)
        celdasCombinadas.CellFormat.BottomBorderStyle = GrosorBorde
        celdasCombinadas.CellFormat.BottomBorderColorInfo = New WorkbookColorInfo(ColorBorde)
        celdasCombinadas.CellFormat.LeftBorderStyle = GrosorBorde
        celdasCombinadas.CellFormat.LeftBorderColorInfo = New WorkbookColorInfo(ColorBorde)
    End Sub


    Private Sub FormatoContenidoReporte(ByVal TipoCelda As String,
                                         ByVal Celda As WorksheetCell,
                                         ByVal Contenido As String,
                                         ByVal Fuente As Integer,
                                         ByVal ColorFondo As Color,
                                         ByVal ColorBorde As Color)


        If TipoCelda = "Celda" Then
            ' Convertimos el contenido en el tipo de dato correcto normal.
            If IsDate(Contenido) Then
                Celda.Value = CDate(Contenido)
                Celda.CellFormat.Alignment = HorizontalCellAlignment.Right
            ElseIf IsNumeric(Contenido) Then
                Celda.Value = CInt(Contenido)
                Celda.CellFormat.Alignment = HorizontalCellAlignment.Right
            ElseIf regexNumerosYLetras.IsMatch(Contenido) Then
                Celda.Value = CStr(Contenido)
                Celda.CellFormat.Alignment = HorizontalCellAlignment.Left
                'valoresEspeciales = True
            ElseIf regexCorrida.IsMatch(Contenido) Then
                Celda.Value = CStr(Contenido)
                Celda.CellFormat.Alignment = HorizontalCellAlignment.Left
                'valoresEspeciales = True
            Else
                Celda.Value = Contenido
                Celda.CellFormat.Alignment = HorizontalCellAlignment.Left
            End If

        ElseIf TipoCelda = "Titulo" Then
            Celda.Value = Contenido

            Celda.CellFormat.Alignment = HorizontalCellAlignment.Center
            Celda.CellFormat.VerticalAlignment = VerticalCellAlignment.Center
            Celda.CellFormat.Font.Bold = ExcelDefaultableBoolean.True
        End If



        Celda.CellFormat.Font.Name = "Arial"
        Celda.CellFormat.Font.Height = Fuente ' 20 es equivalente a 1 en tamaño letra
        Celda.CellFormat.Fill = New CellFillPattern(New WorkbookColorInfo(ColorFondo), WorkbookColorInfo.Automatic, FillPatternStyle.Solid)



        ' Bordes
        Celda.CellFormat.TopBorderStyle = CellBorderLineStyle.Default
        Celda.CellFormat.TopBorderColorInfo = New WorkbookColorInfo(ColorBorde)
        Celda.CellFormat.RightBorderStyle = CellBorderLineStyle.Default
        Celda.CellFormat.RightBorderColorInfo = New WorkbookColorInfo(ColorBorde)
        Celda.CellFormat.BottomBorderStyle = CellBorderLineStyle.Default
        Celda.CellFormat.BottomBorderColorInfo = New WorkbookColorInfo(ColorBorde)
        Celda.CellFormat.LeftBorderStyle = CellBorderLineStyle.Default
        Celda.CellFormat.LeftBorderColorInfo = New WorkbookColorInfo(ColorBorde)
        Celda.CellFormat.WrapText = ExcelDefaultableBoolean.True

    End Sub

#End Region


End Class


Public Class DatosNave
    Private _idNave As Integer
    Public Property idNave() As Integer
        Get
            Return _idNave
        End Get
        Set(ByVal value As Integer)
            _idNave = value
        End Set
    End Property
    Private _Descripcion As String
    Public Property Descripcio() As String
        Get
            Return _Descripcion
        End Get
        Set(ByVal value As String)
            _Descripcion = value
        End Set
    End Property
End Class


Public Class DatosCorreo
    'Public Sub New()
    '    _EntidadDatosNave = New DatosNave
    'End Sub

    'Private _EntidadDatosNave As DatosNave
    'Public Property EntidadDatosNave() As DatosNave
    '    Get
    '        Return _EntidadDatosNave
    '    End Get
    '    Set(ByVal value As DatosNave)
    '        _EntidadDatosNave = value
    '    End Set
    'End Property
    Private _idNave As Integer
    Public Property idNave() As Integer
        Get
            Return _idNave
        End Get
        Set(ByVal value As Integer)
            _idNave = value
        End Set
    End Property
    Private _Nave As String
    Public Property Nave() As String
        Get
            Return _Nave
        End Get
        Set(ByVal value As String)
            _Nave = value
        End Set
    End Property
    Private _Folio As Integer
    Public Property Folio() As Integer
        Get
            Return _Folio
        End Get
        Set(ByVal value As Integer)
            _Folio = value
        End Set
    End Property
    Private _Coleccion As String
    Public Property Coleccion() As String
        Get
            Return _Coleccion
        End Get
        Set(ByVal value As String)
            _Coleccion = value
        End Set
    End Property
    Private _Modelo As String
    Public Property Modelo() As String
        Get
            Return _Modelo
        End Get
        Set(ByVal value As String)
            _Modelo = value
        End Set
    End Property
    Private _PielColor As String
    Public Property PielColor() As String
        Get
            Return _PielColor
        End Get
        Set(ByVal value As String)
            _PielColor = value
        End Set
    End Property
    Private _Corrida As String
    Public Property Corrida() As String
        Get
            Return _Corrida
        End Get
        Set(ByVal value As String)
            _Corrida = value
        End Set
    End Property
    Private _Cantidad As Integer
    Public Property Cantidad() As Integer
        Get
            Return _Cantidad
        End Get
        Set(ByVal value As Integer)
            _Cantidad = value
        End Set
    End Property
    Private _Talla As String
    Public Property Talla() As String
        Get
            Return _Talla
        End Get
        Set(ByVal value As String)
            _Talla = value
        End Set
    End Property
    Private _Cliente As String
    Public Property Cliente() As String
        Get
            Return _Cliente
        End Get
        Set(ByVal value As String)
            _Cliente = value
        End Set
    End Property
    Private _FCorte As Date
    Public Property Fcorte() As Date
        Get
            Return _FCorte
        End Get
        Set(ByVal value As Date)
            _FCorte = value
        End Set
    End Property
    Private _Fsolicitud As Date
    Public Property Fsolicitud() As Date
        Get
            Return _Fsolicitud
        End Get
        Set(ByVal value As Date)
            _Fsolicitud = value
        End Set
    End Property
    Private _unidadMedida As String
    Public Property unidadMedida() As String
        Get
            Return _unidadMedida
        End Get
        Set(ByVal value As String)
            _unidadMedida = value
        End Set
    End Property
    Private _Asunto As String
    Public Property Asunto() As String
        Get
            Return _Asunto
        End Get
        Set(ByVal value As String)
            _Asunto = value
        End Set
    End Property
End Class


Public Class DatosColocacion

    Private _FolioDePedido As Integer
    Public Property FolioDePedido() As Integer
        Get
            Return _FolioDePedido
        End Get
        Set(ByVal value As Integer)
            _FolioDePedido = value
        End Set
    End Property

    Private _FechaAsignada As Date
    Public Property FechaAsignada() As Date
        Get
            Return _FechaAsignada
        End Get
        Set(ByVal value As Date)
            _FechaAsignada = value
        End Set
    End Property

    Private _NaveDesarrollo As Integer
    Public Property NaveDesarrollo() As Integer
        Get
            Return _NaveDesarrollo
        End Get
        Set(ByVal value As Integer)
            _NaveDesarrollo = value
        End Set
    End Property

    Private _NaveProduccion As Integer
    Public Property NaveProduccion() As Integer
        Get
            Return _NaveProduccion
        End Get
        Set(ByVal value As Integer)
            _NaveProduccion = value
        End Set
    End Property

    Private _Articulo As Integer
    Public Property Articulo() As Integer
        Get
            Return _Articulo
        End Get
        Set(ByVal value As Integer)
            _Articulo = value
        End Set
    End Property

    Private _Talla As String
    Public Property Talla() As String
        Get
            Return _Talla
        End Get
        Set(ByVal value As String)
            _Talla = value
        End Set
    End Property

    Private _Cantidad As Integer
    Public Property Cantidad() As Integer
        Get
            Return _Cantidad
        End Get
        Set(ByVal value As Integer)
            _Cantidad = value
        End Set
    End Property
End Class
