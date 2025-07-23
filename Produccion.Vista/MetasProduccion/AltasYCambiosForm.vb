Imports Produccion.Negocios
Imports Tools

Public Class AltasYCambiosForm

    Dim continuarAgregando As Boolean = True

    Private Sub AltasYCambiosForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If FormTipoAccion = "Editar" Then
            ModificarMetas()
        Else
            AltaMetas()
        End If
    End Sub

    Dim Departamento As String
    Dim Dia As String
    Dim Pares As Integer
    Dim Tipo As String
    Dim NaveId As Integer
    Dim MetaIdProduccion As Integer
    Dim esPlantilla As Integer
    Dim idConfiguracion As Integer
    Dim tablaDatos As DataTable

    Public Property formNaveId As Integer
        Get
            Return NaveId
        End Get
        Set(value As Integer)
            NaveId = value
        End Set
    End Property

    Public Property FormDepartamento As String
        Get
            Return Departamento
        End Get
        Set(value As String)
            Departamento = value
        End Set
    End Property

    Public Property FormDia As String
        Get
            Return Dia
        End Get
        Set(value As String)
            Dia = value
        End Set
    End Property

    Public Property FormPares As Integer
        Get
            Return Pares
        End Get
        Set(value As Integer)
            Pares = value
        End Set
    End Property

    Public Property FormTipoAccion As String
        Get
            Return Tipo
        End Get
        Set(value As String)
            Tipo = value
        End Set
    End Property

    Public Property FormIdMetaProduccion As Integer
        Get
            Return MetaIdProduccion
        End Get
        Set(value As Integer)
            MetaIdProduccion = value
        End Set
    End Property

    Public Property FormEsPlantilla As Integer
        Get
            Return esPlantilla
        End Get
        Set(value As Integer)
            esPlantilla = value
        End Set
    End Property

    Public Property formIdConfiguracion As Integer
        Get
            Return idConfiguracion
        End Get
        Set(value As Integer)
            idConfiguracion = value
        End Set
    End Property

    Public Property formtablaDatos As DataTable
        Get
            Return tablaDatos
        End Get
        Set(value As DataTable)
            tablaDatos = value
        End Set
    End Property

    Public Sub ModificarMetas()
        cmb_Departamento.Items.Add(FormDepartamento)
        cmb_Departamento.Text = FormDepartamento
        cmbDia.Items.Add(FormDia)
        cmbDia.Text = FormDia
        txt_Pares.Text = FormPares
        Me.lblTitulo.Text = "Editar Metas"
        Me.Text = "Editar Metas"
        cmb_Departamento.Enabled = False
        cmbDia.Enabled = False
    End Sub

    Public Sub AltaMetas()
        'If FormEsPlantilla = 1 Then
        '    cmb_Departamento.Items.Add(FormDepartamento)
        '    cmb_Departamento.Text = FormDepartamento
        '    cmbDia.Items.Add(FormDia)
        '    cmbDia.Text = FormDia
        'Else
        departamentosNave()
        diasSemana()
        'End If
        txt_Pares.Text = 0
        Me.lblTitulo.Text = "Alta Metas"
        Me.Text = "Alta Metas"
    End Sub

    Public Sub diasSemana()
        cmbDia.Items.Add("LUNES")
        cmbDia.Items.Add("MARTES")
        cmbDia.Items.Add("MIERCOLES")
        cmbDia.Items.Add("JUEVES")
        cmbDia.Items.Add("VIERNES")
        cmbDia.Items.Add("SABADO")
        cmbDia.Items.Add("DOMINGO")
    End Sub

    Public Sub departamentosNave()
        Dim objBu As New MetasProduccionBU
        Dim tbaDepartamentos As DataTable
        tbaDepartamentos = objBu.TraerDepartamentos(formNaveId)
        'For Each row As DataRow In tbaDepartamentos.Rows
        'If row.Item("Departamento").ToString() <> "" Then
        'cmb_Departamento.Items.Add(row.Item("Departamento").ToString())
        If tbaDepartamentos.Rows.Count > 0 Then
            cmb_Departamento.DataSource = tbaDepartamentos
            cmb_Departamento.DisplayMember = "Departamento"
            cmb_Departamento.ValueMember = "IdConfiguracion"
        End If
        '    End If
        'Next
    End Sub

    Private Sub btn_Aceptar_Click(sender As Object, e As EventArgs) Handles btn_Aceptar.Click
        Dim objBu As New MetasProduccionBU

        Dim ConfiguracionId As Integer
        Dim cantidad As Integer
        Dim dia As Integer
        Dim accionMeta As String
        Dim IdMetaProduccion As Integer
        Dim mensaje As New AdvertenciaForm
        Dim mensajeExito As New ExitoForm
        Dim mensajeError As New ErroresForm

        dia = ObtenerDia(cmbDia.SelectedItem)
        cantidad = Convert.ToInt32(txt_Pares.Text)
        'If FormEsPlantilla = 1 Then
        '    ConfiguracionId = formIdConfiguracion
        'Else
        ConfiguracionId = cmb_Departamento.SelectedValue
        'End If
        accionMeta = FormTipoAccion
        IdMetaProduccion = FormIdMetaProduccion

        Try
            If FormTipoAccion = "Alta" Then
                If cmb_Departamento.SelectedValue > 0 And cmbDia.Text <> "" And Convert.ToInt32(txt_Pares.Text) > 0 Then
                    If verificarDiaTabla(cmbDia.Text) = True Then
                        objBu.AgregarNuevaOActualizarMeta(accionMeta, cantidad, dia, ConfiguracionId, IdMetaProduccion)
                        mensajeExito.mensaje = "El registro se realizó correctamente."
                        mensajeExito.Show()
                    Else
                        mensaje.mensaje = "No se pueden agregar días iguales en un mismo departamento."
                        mensaje.Show()
                    End If
                Else
                    mensaje.mensaje = "Favor de ingresar todos los datos solicitados."
                        mensaje.Show()
                    End If
                ElseIf FormTipoAccion = "Editar" Then
                    If txt_Pares.Text <> "" Then
                        objBu.AgregarNuevaOActualizarMeta(accionMeta, cantidad, dia, ConfiguracionId, IdMetaProduccion)
                        mensajeExito.mensaje = "Se realizo la acción con éxito."
                        mensajeExito.Show()
                    Else
                        mensaje.mensaje = "Favor de ingresar los pares."
                        mensaje.Show()
                    End If
                End If
        Catch ex As Exception
            mensajeError.mensaje = "Ha ocurrido un error interno, favor de verificar información y volver a intentar."
            mensajeError.Show()
        End Try
    End Sub

    Private Sub btn_Cancelar_Click(sender As Object, e As EventArgs) Handles btn_Cancelar.Click
        cmb_Departamento.Text = ""
        cmbDia.Text = ""
        txt_Pares.Text = ""
        Me.Close()
    End Sub

    Public Function ObtenerDia(ByVal Dia As String)
        Dim ValorDia As Integer = 0

        Select Case Dia
            Case "LUNES"
                ValorDia = 1
            Case "MARTES"
                ValorDia = 2
            Case "MIERCOLES"
                ValorDia = 3
            Case "JUEVES"
                ValorDia = 4
            Case "VIERNES"
                ValorDia = 5
            Case "SABADO"
                ValorDia = 6
            Case "DOMINGO"
                ValorDia = 7
            Case Else
                ValorDia = 0
        End Select

        Return ValorDia
    End Function

    Public Function verificarDiaTabla(ByVal Dia As String)
        Dim metasProduccion As New MetasHoraForm

        For Each row As DataRow In formtablaDatos.Rows
            If row.Item("IdConfiguracion") = cmb_Departamento.SelectedValue Then
                If row.Item("DiaLetra").ToString() = Dia Then
                    Return continuarAgregando = False
                End If
            Else
                continuarAgregando = True
            End If
        Next

        Return continuarAgregando
    End Function
End Class