Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Tools

Public Class Agregar_o_Editar_ConfiguracionEmbarquesParPorParForm

    Public Editar As Boolean 'TRUE PARA EDITAR, FALSE PARA AGREGAR
    Public IdNave As Integer
    Public IdCadena As Integer
    Public idConfiguracion As Integer
    Public Salida As Boolean
    Public Entrada As Boolean
    Dim CamposVacios As Boolean 'TRUE PARA VACIOS, FALSE PARA COMPLETOS
    Dim registroExistente As Boolean 'TRUE PARA EXISTENTE, FALSE PARA NO EXISTENTE'
    Dim ValorEntradaAnterior As Boolean
    Dim ValorSalidaAnterior As Boolean


    Private Sub Agregar_o_Editar_ConfiguracionEmbarquesParPorParForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Tools.Controles.ComboNavesSegunUsuarioConIdSIcy(cmbNaves, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)

        Tools.Controles.UltraComboCadenasSicy(cmbUCLientes)

        If Editar = True Then
            cmbNaves.SelectedValue = IdNave

            For cont = cmbUCLientes.Rows.Count - 1 To 0 Step -1
                If cmbUCLientes.Rows(cont).Cells("IdCadena").Text = IdCadena.ToString Then
                    cmbUCLientes.Rows(cont).Activate()
                End If
            Next

            cmbUCLientes.Enabled = False
            cmbNaves.Enabled = False

            chboxEntradaParPorPar.Checked = Entrada
            chboxSalidaparporpar.Checked = Salida
            ValorEntradaAnterior = Entrada
            ValorSalidaAnterior = Salida

        End If

    End Sub

    Private Sub ValidarCamposVacios()

        Dim FORMAERRORES As New ErroresForm

        If cmbNaves.SelectedIndex = 0 And cmbUCLientes.Rows(0).IsActiveRow = True Then
            CamposVacios = True
            lblNave.ForeColor = Color.Red
            lblCliente.ForeColor = Color.Red
            FORMAERRORES.mensaje = "Selecciona una nave y un cliente para poder guardar."
            FORMAERRORES.ShowDialog()
        ElseIf cmbUCLientes.Rows(0).IsActiveRow = True And cmbNaves.SelectedIndex > 0 Then
            CamposVacios = True
            lblCliente.ForeColor = Color.Red
            lblNave.ForeColor = Color.Black
            FORMAERRORES.mensaje = "Selecciona un cliente para poder guardar."
            FORMAERRORES.ShowDialog()
        ElseIf cmbUCLientes.Rows(0).IsActiveRow = False And cmbNaves.SelectedIndex = 0 Then
            CamposVacios = True
            lblNave.ForeColor = Color.Red
            lblCliente.ForeColor = Color.Black
            FORMAERRORES.mensaje = "Selecciona una nave para poder guardar."
            FORMAERRORES.ShowDialog()
        Else
            CamposVacios = False
            lblNave.ForeColor = Color.Black
            lblCliente.ForeColor = Color.Black
        End If




    End Sub


    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim formaExito As New ExitoForm

        ValidarCamposVacios()

        If CamposVacios = True Then Return

        If Editar = True Then
            EditarRegistroConfiguracionDeEmbarques()
            formaExito.mensaje = "El registro se actualizo exitosamente."
            formaExito.ShowDialog()
            Me.Close()
        Else
            If chboxEntradaParPorPar.Checked = False And chboxSalidaparporpar.Checked = False Then
                Dim formaAdvertencia As New AdvertenciaForm
                formaAdvertencia.mensaje = "Debes activar una de las dos validaciones para poder guardar."
                formaAdvertencia.StartPosition = FormStartPosition.CenterScreen
                formaAdvertencia.ShowDialog()
                Return
            Else
                AgregarRegistroConfiguracionDeEmbarques()
                If registroExistente = False Then
                    formaExito.mensaje = "El registro se guardo correctamente."
                    formaExito.ShowDialog()
                End If
                Me.Close()
            End If
        End If

    End Sub

    ''' <summary>
    ''' METODO QUE REALIZA LAS ACCIONES NECESARIOAS PARA EDITAR UN REGISTRO EN CASO DE QUE ESTE ACTIVO CUALQUIERA DE LAS DOS VALIDACIONES POSIBLES O INACTIVA UN REGISTRO 
    ''' CUANDO SE DESACTIVAN LAS DOS POSIBLES VALIDACIONES(ENTRADA PAR POR PAR Y SALIDA PAR POR PAR)
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub EditarRegistroConfiguracionDeEmbarques()
        Dim objBU As New Negocios.EntradaProductoBU
        If chboxEntradaParPorPar.Checked = False And chboxSalidaparporpar.Checked = False Then
            objBU.DesactivarRegistro(idConfiguracion)
            objBU.RegistrarBitacora(idConfiguracion, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, ValorEntradaAnterior, ValorSalidaAnterior, chboxEntradaParPorPar.Checked, chboxSalidaparporpar.Checked)
            objBU.EditarRegistroConfiguracionDeEmbarques(idConfiguracion, chboxEntradaParPorPar.Checked, chboxSalidaparporpar.Checked)
        Else
            objBU.EditarRegistroConfiguracionDeEmbarques(idConfiguracion, chboxEntradaParPorPar.Checked, chboxSalidaparporpar.Checked)
            objBU.RegistrarBitacora(idConfiguracion, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, ValorEntradaAnterior, ValorSalidaAnterior, chboxEntradaParPorPar.Checked, chboxSalidaparporpar.Checked)
        End If

    End Sub


    Private Sub AgregarRegistroConfiguracionDeEmbarques()
        Dim objBU As New Negocios.EntradaProductoBU
        Dim dtRegistrosExistentes As New DataTable

        'VALIDAMOS QUE NO EXISTA UN REGISTRO EN LA BASE DE DATOS
        dtRegistrosExistentes = objBU.ValidarRegistrosExistentes(cmbNaves.SelectedValue, CInt(cmbUCLientes.SelectedRow.Cells(0).Text))
        registroExistente = False

        If dtRegistrosExistentes.Rows.Count = 0 Then
            objBU.AgregarRegistroConfiguracionDeEmbarques(CInt(cmbUCLientes.SelectedRow.Cells(0).Text), chboxEntradaParPorPar.Checked, chboxSalidaparporpar.Checked, cmbNaves.SelectedValue)
        Else
            If dtRegistrosExistentes.Rows(0).Item("ACTIVO") = "FALSE" Then
                objBU.ActivarRegistroDeValidacion(dtRegistrosExistentes.Rows(0).Item("ID_CONFIGURACION"), chboxEntradaParPorPar.Checked, chboxSalidaparporpar.Checked)
            Else
                Dim formaAdvertencia As New AdvertenciaForm
                formaAdvertencia.mensaje = "El registro ya existe."
                formaAdvertencia.StartPosition = FormStartPosition.CenterScreen
                formaAdvertencia.ShowDialog()

                registroExistente = True
                Return
            End If
        End If

    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
        Me.Dispose()
    End Sub


    Private Sub cmbUCLientes_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles cmbUCLientes.InitializeLayout
        With cmbUCLientes
            .DisplayLayout.Bands(0).Columns("IdCadena").Hidden = True
            .DisplayLayout.Bands(0).Columns("Activo").Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Header.Caption = "CLIENTE"
            .DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns 'Ajusta todas las columnas a un tamaño igual.
            .DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
            .DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            .DisplayLayout.Override.RowSelectorWidth = 35
            .DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
            .DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
            .DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True
            .DisplayLayout.Override.AllowAddNew = AllowAddNew.No
            .AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest
            .AutoSuggestFilterMode = Infragistics.Win.AutoSuggestFilterMode.Contains
        End With
    End Sub
End Class