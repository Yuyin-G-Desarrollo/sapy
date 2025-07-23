Imports Tools.Controles
Imports System.Text.RegularExpressions
Imports Infragistics.Win.UltraWinEditors
Imports Tools

Public Class AltaConfigProduccionBandaForm
    Public IdNave As Integer
    Dim total As Integer = 0
    Public AgregarOEditar As Boolean
    Dim vacios As Boolean
    Public IdProduccion As Integer
    Public fechainicial As Date
    Public fechafinal As Date
    Public IdPeriodo As Integer
    Dim TotalSay As Integer
    Public IdCelula As Integer
    Dim IdNaveSicy As Integer
    Dim IdCelulaSicy As Integer
    Public Consulta As Boolean
    Public periodo As String
    Public IdDepartamento As Integer


    Private Sub AltaConfigProduccionBanda_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboNavesSegunUsuario(cmbNave, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
        If AgregarOEditar = False Then
            RecuperarIdNave()
            cmbNave.SelectedValue = IdNave
            RecuperarIdNaveSicy()

            ComboPeriodosNominaSinFiltroDescendentePeriodoActivo(cmbPeriodo, IdNave)
            cmbPeriodo.SelectedValue = IdPeriodo
            ComboDepatamentoSegunNave(cmbDepartamentos, IdNave)
            cmbDepartamentos.SelectedValue = IdDepartamento

            ComboCelulasSegunDepartamento(cmbCelula, IdDepartamento)
            cmbCelula.SelectedValue = IdCelula


            RecuperarIdCelulaSicy()
            RecuperarFechaInicial()
            RecuperarTotalSay()

            RecuperarDatosProduccion()
            RecuperarIdCelulaSicy()
            RecuperarFechaInicial()
            RecuperarTotalSay()
            cmbNave.Enabled = False
            cmbPeriodo.Enabled = False
            cmbCelula.Enabled = False
            cmbCelula.Enabled = False
            cmbDepartamentos.Enabled = False
            SumarCajasDeTextoInicioInterfaz()
            If Consulta = True Then
                ComboPeriodosNominaSinFiltroDescendentePeriodoActivo(cmbPeriodo, IdNave)
                RecuperarIdNave()
                cmbNave.SelectedValue = IdNave
                RecuperarIdNaveSicy()

                ComboPeriodosNominaSinFiltroDescendentePeriodoActivo(cmbPeriodo, IdNave)
                cmbPeriodo.SelectedValue = IdPeriodo
                ComboDepatamentoSegunNave(cmbDepartamentos, IdNave)
                cmbDepartamentos.SelectedValue = IdDepartamento

                ComboCelulasSegunDepartamento(cmbCelula, IdDepartamento)
                cmbCelula.SelectedValue = IdCelula


                RecuperarIdCelulaSicy()
                RecuperarFechaInicial()
                RecuperarTotalSay()
                txtCostoSandalia.ReadOnly = True
                txtCostoChoclo.ReadOnly = True
                txtCostoBotin.ReadOnly = True
                txtCostoMediaBota.ReadOnly = True
                txtCostoBotaAlta.ReadOnly = True
                txtparsandalia1.ReadOnly = True
                txtParChoclo1.ReadOnly = True
                txtParBotin1.ReadOnly = True
                txtParMediaBota1.ReadOnly = True
                txtParBotaAlta1.ReadOnly = True
                btnGuardar.Enabled = False
            Else
                SumarCajasDeTextoInicioInterfaz()
            End If

        End If

    End Sub

#Region "Validaciones de textbox"

    Private Sub SumarCajasDeTextoInicioInterfaz()

        total = CInt(txtparsandalia1.Text) + CInt(txtParChoclo1.Text) + CInt(txtParBotin1.Text) + CInt(txtParMediaBota1.Text) + CInt(txtParBotaAlta1.Text)
        txtTotal.Text = total
    End Sub


    ''' <summary>
    ''' SUMA EL VALOR DE LA CAJA DE TEXTO A LA VARIABLE TOTAL
    ''' </summary>
    ''' <param name="sender">CAJA DE TEXTO A SUMAR</param>
    ''' <remarks></remarks>
    Public Sub SumarCajasdetexto(sender As Object)
        total = txtTotal.Text
        Dim txtt = CType(sender, TextBox)
        If txtt.Text = "" Then
            txtt.Text = "0"
        ElseIf txtt.Text <> "" Then
            total = total + CInt(txtt.Text)
        End If

        txtTotal.Text = total
    End Sub

    ''' <summary>
    ''' RESTA EL VALOR DE LA CAJA DE TEXTO DE LA VARIABLE TOTAL
    ''' </summary>
    ''' <param name="sender">CAJA DE TEXTO A RSTAR</param>
    ''' <remarks></remarks>
    Public Sub RestarCajasDeTexto(sender As Object)
        total = CInt(txtTotal.Text)
        Dim txtt = CType(sender, TextBox)
        If txtt.Text = "" Then Return
        total = total - CInt(txtt.Text)
        txtTotal.Text = total
    End Sub

    Public Function txtNumericoSinDecimales(ByVal txtControl As TextBox, ByVal caracter As Char, ByVal decimales As Boolean) As Boolean
        If (Char.IsNumber(caracter, 0) = True) Or caracter = Convert.ToChar(8) Or caracter = "." Then
            If caracter = "." Then
                If decimales = False Then
                    If txtControl.Text.IndexOf(".") <> -1 Then Return True
                Else : Return True
                End If
            End If
            Return False
        Else
            Return True
        End If
    End Function
    Public Function txtNumericoConDecimales(ByVal txtControl As TextBox, ByVal caracter As Char, ByVal decimales As Boolean) As Boolean
        If (Char.IsNumber(caracter, 0) = True) Or caracter = Convert.ToChar(8) Or caracter = "." Then
            If caracter = "." Then
                If decimales = True Then
                    If txtControl.Text.IndexOf(".") <> -1 Then Return True
                Else : Return True
                End If
            End If
            Return False
        Else
            Return True
        End If
    End Function


    Private Sub txtparsandalia1_Leave(sender As Object, e As EventArgs) Handles txtparsandalia1.Leave
        SumarCajasdetexto(txtparsandalia1)
    End Sub
    Private Sub txtparsandalia1_Enter(sender As Object, e As EventArgs) Handles txtparsandalia1.Enter
        RestarCajasDeTexto(txtparsandalia1)
    End Sub
    Private Sub txtparsandalia1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtparsandalia1.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            txtParChoclo1.Select()
        Else
            e.Handled = txtNumericoSinDecimales(txtparsandalia1, e.KeyChar, True)
        End If
    End Sub

    Private Sub txtParChoclo1_Leave(sender As Object, e As EventArgs) Handles txtParChoclo1.Leave
        SumarCajasdetexto(txtParChoclo1)
    End Sub
    Private Sub txtParChoclo1_Enter(sender As Object, e As EventArgs) Handles txtParChoclo1.Enter
        RestarCajasDeTexto(txtParChoclo1)
    End Sub
    Private Sub txtParChoclo1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtParChoclo1.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            txtParMediaBota1.Select()
        Else
            e.Handled = txtNumericoSinDecimales(txtParChoclo1, e.KeyChar, True)
        End If

    End Sub

    Private Sub txtParMediaBota1_Enter(sender As Object, e As EventArgs) Handles txtParMediaBota1.Enter
        RestarCajasDeTexto(txtParMediaBota1)
    End Sub
    Private Sub txtParMediaBota1_Leave(sender As Object, e As EventArgs) Handles txtParMediaBota1.Leave
        SumarCajasdetexto(txtParMediaBota1)
    End Sub
    Private Sub txtParMediaBota1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtParMediaBota1.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            txtParBotin1.Select()
        Else
            e.Handled = txtNumericoSinDecimales(txtParMediaBota1, e.KeyChar, True)
        End If
    End Sub

    Private Sub txtParBotin1_Leave(sender As Object, e As EventArgs) Handles txtParBotin1.Leave
        SumarCajasdetexto(txtParBotin1)
    End Sub
    Private Sub txtParBotin1_Enter(sender As Object, e As EventArgs) Handles txtParBotin1.Enter
        RestarCajasDeTexto(txtParBotin1)
    End Sub
    Private Sub txtParBotin1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtParBotin1.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            txtParBotaAlta1.Select()
        Else
            e.Handled = txtNumericoSinDecimales(txtParBotin1, e.KeyChar, True)
        End If
    End Sub

    Private Sub txtParBotaAlta1_Leave(sender As Object, e As EventArgs) Handles txtParBotaAlta1.Leave
        SumarCajasdetexto(txtParBotaAlta1)
    End Sub
    Private Sub txtParBotaAlta1_Enter(sender As Object, e As EventArgs) Handles txtParBotaAlta1.Enter
        RestarCajasDeTexto(txtParBotaAlta1)
    End Sub
    Private Sub txtParBotaAlta1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtParBotaAlta1.KeyPress
        e.Handled = txtNumericoSinDecimales(txtParBotaAlta1, e.KeyChar, True)
    End Sub

    Private Sub txtCostoSandalia_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCostoSandalia.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            txtCostoChoclo.Select()
        Else
            e.Handled = txtNumericoConDecimales(txtCostoSandalia, e.KeyChar, True)
            ' Obtener caracter  
            Dim caracter As Char = e.KeyChar
            ' referencia a la celda  
            Dim txt As TextBox = CType(sender, TextBox)
            If txt.Text.IndexOf(".") > 0 Then
                txt.MaxLength = txt.Text.IndexOf(".") + 3
            End If
            If (Char.IsNumber(caracter)) Or
            (caracter = ChrW(Keys.Back)) Or
            (caracter = ".") And
            (txt.Text.Contains(".") = False) Then
                e.Handled = False
            Else
                e.Handled = True
            End If
        End If

    End Sub

    Private Sub txtCostoChoclo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCostoChoclo.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            txtCostoMediaBota.Select()
        Else
            e.Handled = txtNumericoConDecimales(txtCostoChoclo, e.KeyChar, True)
            ' Obtener caracter  
            Dim caracter As Char = e.KeyChar
            ' referencia a la celda  
            Dim txt As TextBox = CType(sender, TextBox)
            If txt.Text.IndexOf(".") > 0 Then
                txt.MaxLength = txt.Text.IndexOf(".") + 3
            End If
            If (Char.IsNumber(caracter)) Or
            (caracter = ChrW(Keys.Back)) Or
            (caracter = ".") And
            (txt.Text.Contains(".") = False) Then
                e.Handled = False
            Else
                e.Handled = True
            End If
        End If

    End Sub

    Private Sub txtCostoMediaBota_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCostoMediaBota.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            txtCostoBotin.Select()
        Else
            e.Handled = txtNumericoConDecimales(txtCostoMediaBota, e.KeyChar, True)
            ' Obtener caracter  
            Dim caracter As Char = e.KeyChar
            ' referencia a la celda  
            Dim txt As TextBox = CType(sender, TextBox)
            If txt.Text.IndexOf(".") > 0 Then
                txt.MaxLength = txt.Text.IndexOf(".") + 3
            End If
            If (Char.IsNumber(caracter)) Or
            (caracter = ChrW(Keys.Back)) Or
            (caracter = ".") And
            (txt.Text.Contains(".") = False) Then
                e.Handled = False
            Else
                e.Handled = True
            End If
        End If

    End Sub

    Private Sub txtCostoBotin_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCostoBotin.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            txtCostoBotaAlta.Select()
        Else
            e.Handled = txtNumericoConDecimales(txtCostoBotin, e.KeyChar, True)
            ' Obtener caracter  
            Dim caracter As Char = e.KeyChar
            ' referencia a la celda  
            Dim txt As TextBox = CType(sender, TextBox)
            If txt.Text.IndexOf(".") > 0 Then
                txt.MaxLength = txt.Text.IndexOf(".") + 3
            End If
            If (Char.IsNumber(caracter)) Or
            (caracter = ChrW(Keys.Back)) Or
            (caracter = ".") And
            (txt.Text.Contains(".") = False) Then
                e.Handled = False
            Else
                e.Handled = True
            End If
        End If

    End Sub

    Private Sub txtCostoBotaAlta_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCostoBotaAlta.KeyPress
        e.Handled = txtNumericoConDecimales(txtCostoBotaAlta, e.KeyChar, True)
        ' Obtener caracter  
        Dim caracter As Char = e.KeyChar
        ' referencia a la celda  
        Dim txt As TextBox = CType(sender, TextBox)
        If txt.Text.IndexOf(".") > 0 Then
            txt.MaxLength = txt.Text.IndexOf(".") + 3
        End If
        If (Char.IsNumber(caracter)) Or
        (caracter = ChrW(Keys.Back)) Or
        (caracter = ".") And
        (txt.Text.Contains(".") = False) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

#End Region

    ''' <summary>
    ''' SI LAS CAJAS DE TEXTO TIENEN VALORES NULOS COLOREA DE ROJO LAS ETIQUETAS CORRESPONDIENTES
    ''' </summary>
    ''' <param name="senderText">CAJA DE TEXTO A VALIDAR</param>
    ''' <param name="SenderLabel">ETIQUETA A MODIFICAR LA PROPIEDAD FORECOLOR</param>
    ''' <remarks></remarks>
    Public Sub ValidarCajasYEtiquetas(senderText As Object, SenderLabel As Object)
        Dim txttext = CType(senderText, TextBox)
        Dim lblText = CType(SenderLabel, Label)
        If txttext.Text = "" Then
            vacios = True
            lblText.ForeColor = Color.Red
        Else
            lblText.ForeColor = Color.Black
        End If

    End Sub

    ''' <summary>
    ''' VALIDA QUE TODAS LAS CAJAS DE TEXTO TENGAN CONTENGAN CARACTERES Y NO TENGAN VALOR NULO
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ValidarCamposVacios()
        vacios = False
        ValidarCajasYEtiquetas(txtparsandalia1, lblParSandalia)
        ValidarCajasYEtiquetas(txtParChoclo1, lblParChoclo)
        ValidarCajasYEtiquetas(txtParBotin1, lblParBotin)
        ValidarCajasYEtiquetas(txtParMediaBota1, lblParMediaBota)
        ValidarCajasYEtiquetas(txtParBotaAlta1, lblParBotaAlta)
        ValidarCajasYEtiquetas(txtCostoSandalia, lblCostoSandalia)
        ValidarCajasYEtiquetas(txtCostoChoclo, lblCostoChoclo)
        ValidarCajasYEtiquetas(txtCostoBotin, lblCostoBotin)
        ValidarCajasYEtiquetas(txtCostoMediaBota, lblCostoMediaBota)
        ValidarCajasYEtiquetas(txtCostoBotaAlta, lblCostoBotaAlta)

        If cmbCelula.SelectedIndex > 0 Then
            lblCelula.ForeColor = Color.Black
        Else
            lblCelula.ForeColor = Color.Red
            vacios = True
        End If

        If cmbNave.SelectedIndex > 0 Then
            lblNave.ForeColor = Color.Black
        Else
            lblNave.ForeColor = Color.Red
            vacios = True
        End If

        If cmbPeriodo.SelectedIndex > 0 Then
            lblPeriodo.ForeColor = Color.Black
        Else
            lblPeriodo.ForeColor = Color.Red
            vacios = True

        End If
    End Sub

    ''' <summary>
    ''' REALIZA LAS OPERACIONES NECESARIAS PARA AGREGAR UN REGISTRO
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub AgregarProduccion()
        Dim NominaDestajos As New Entidades.NominaDestajos
        ValidarCamposVacios()
        If vacios = False Then
            With NominaDestajos
                .PIdPeriodo = cmbPeriodo.SelectedValue
                .PIdCelula = cmbCelula.SelectedValue
                .PNSandalia = CInt(txtparsandalia1.Text)
                .PCSandalia = CDbl(txtCostoSandalia.Text)
                .PNChoclo = CInt(txtParChoclo1.Text)
                .PCChoclo = CDbl(txtCostoChoclo.Text)
                .PNBotin = CInt(txtParBotin1.Text)
                .PCBotin = CDbl(txtCostoBotin.Text)
                .PNMediaBota = CInt(txtParMediaBota1.Text)
                .PCMediaBota = CDbl(txtCostoMediaBota.Text)
                .PNBotaALta = CInt(txtParBotaAlta1.Text)
                .PCBotalAlta = CDbl(txtCostoBotaAlta.Text)
                .PParesEMbarcados = CInt(txtTotalSAY.Text)
                .PParesCapturados = CInt(txtTotal.Text)
            End With

            Dim objProduccionBU As New Negocios.NominaDestajosBU
            objProduccionBU.AltaProduccion(NominaDestajos)
            Dim FormularioMensaje As New ExitoForm
            FormularioMensaje.mensaje = "Registro Guardado"
            FormularioMensaje.ShowDialog()
            Me.Close()
        End If

    End Sub

    ''' <summary>
    ''' REALIZA LAS OPERACIONES NECESARIAS PARA MODIFICAR UN REGISTRO
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ModificarProduccion()
        Dim Produccion As New Entidades.NominaDestajos
        ValidarCamposVacios()

        If vacios = False Then
            With Produccion
                .PIdPeriodo = cmbPeriodo.SelectedValue
                .PIdProdNom = IdProduccion
                .PNSandalia = CInt(txtparsandalia1.Text)
                .PCSandalia = CDbl(txtCostoSandalia.Text)
                .PNChoclo = CInt(txtParChoclo1.Text)
                .PCChoclo = CDbl(txtCostoChoclo.Text)
                .PNBotin = CInt(txtParBotin1.Text)
                .PCBotin = CDbl(txtCostoBotin.Text)
                .PNMediaBota = CInt(txtParMediaBota1.Text)
                .PCMediaBota = CDbl(txtCostoMediaBota.Text)
                .PNBotaALta = CInt(txtParBotaAlta1.Text)
                .PCBotalAlta = CDbl(txtCostoBotaAlta.Text)
                .PParesEMbarcados = CInt(txtTotalSAY.Text)
                .PParesCapturados = CInt(txtTotal.Text)
                .PIdCelula = cmbCelula.SelectedValue
            End With

            Dim objProduccionBU As New Negocios.NominaDestajosBU
            objProduccionBU.ModificarProduccion(Produccion)
            Dim FormularioMensaje As New ExitoForm
            FormularioMensaje.mensaje = "Registro Actualizado"
            FormularioMensaje.ShowDialog()
        Else

        End If

    End Sub

    ''' <summary>
    ''' RECUPERA EL ID DE LA NAVE EN LA BASE DE DATOS DEL SICY
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub RecuperarIdNaveSicy()
        Dim RecuperarId As New List(Of Entidades.NominaDestajos)
        Dim objRecuperarIdBU As New Negocios.NominaDestajosBU
        RecuperarId = objRecuperarIdBU.RecuperarIdNavesSicy(IdNave)
        For Each row As Entidades.NominaDestajos In RecuperarId
            IdNaveSicy = row.PIdNaveSicy
        Next
    End Sub

    ''' <summary>
    ''' RECUPERA EL ID DE DE LA CELULA EN LA BASE DE DATOS DEL SICY
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub RecuperarIdCelulaSicy()
        Dim RecuperarIdCelula As New List(Of Entidades.NominaDestajos)
        Dim objRecuperarIdBU As New Negocios.NominaDestajosBU
        RecuperarIdCelula = objRecuperarIdBU.RecuperarIdCelulaSicy(IdCelula)
        For Each row As Entidades.NominaDestajos In RecuperarIdCelula
            IdCelulaSicy = row.PIdCelulaSicy
        Next
    End Sub

    ''' <summary>
    ''' RECUPERA EL ID DE LA NAVE EN LA BASE DE DATOS DEL SAY
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub RecuperarIdNave()
        Dim RecuperarIdNave As New List(Of Entidades.NominaDestajos)
        Dim objRecuperarIdBU As New Negocios.NominaDestajosBU
        RecuperarIdNave = objRecuperarIdBU.RecuperarIdNave(IdCelula)
        For Each row As Entidades.NominaDestajos In RecuperarIdNave
            IdNave = row.PIdNave
        Next
    End Sub

    ''' <summary>
    ''' RECUPERA LA FECHA INICIAL Y LA FECHA FINAL DE UN PERIODO
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub RecuperarFechaInicial()
        Dim Produccion As New List(Of Entidades.NominaDestajos)
        Dim objProduccionBU As New Negocios.NominaDestajosBU
        Produccion = objProduccionBU.RecuperarFechas(IdPeriodo)

        For Each row As Entidades.NominaDestajos In Produccion
            fechainicial = row.PFechaInicial
            fechafinal = row.PFechaFinal
        Next

    End Sub

    ''' <summary>
    ''' RECUPERA EL TOTAL EN EL SICY Y LO MUESTRA EN EL TEXTBOX TXTTOTALSAY
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub RecuperarTotalSay()
        Dim Total As New List(Of Entidades.NominaDestajos)
        Dim objTotalBU As New Negocios.NominaDestajosBU
        Total = objTotalBU.PorBantaTotalLotes(IdNaveSicy, IdCelulaSicy, fechainicial, fechafinal)
        For Each row As Entidades.NominaDestajos In Total
            TotalSay = CInt(row.PParesEMbarcados)
        Next
        txtTotalSAY.Text = TotalSay.ToString
    End Sub

    ''' <summary>
    ''' RECUPERA LOS DATOS DE PRODUCCION Y LOS MUESTRA EN LOS CAMPOS DE TEXTO Y COMBOBOX AL EDITAR UN REGISTRO
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub RecuperarDatosProduccion()
        Dim Produccion As New List(Of Entidades.NominaDestajos)
        Dim objProduccionBU As New Negocios.NominaDestajosBU
        Produccion = objProduccionBU.RecuperarProduccion(IdProduccion)
        For Each row As Entidades.NominaDestajos In Produccion
            IdNave = row.PIdNave
            txtparsandalia1.Text = (row.PNSandalia).ToString
            txtParChoclo1.Text = row.PNChoclo.ToString
            txtParBotin1.Text = row.PNBotin.ToString
            txtParMediaBota1.Text = row.PNMediaBota.ToString
            txtParBotaAlta1.Text = row.PNBotaALta.ToString
            txtCostoSandalia.Text = row.PCSandalia.ToString
            txtCostoChoclo.Text = row.PCChoclo.ToString
            txtCostoBotin.Text = row.PCBotin.ToString
            txtCostoMediaBota.Text = row.PCMediaBota.ToString
            txtCostoBotaAlta.Text = row.PCBotalAlta.ToString
            txtTotal.Text = row.PParesCapturados.ToString
            txtTotalSAY.Text = row.PParesEMbarcados.ToString
        Next
    End Sub

    Private Sub btnCncelar_Click(sender As Object, e As EventArgs) Handles btnCncelar.Click
        Me.Close()

    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If AgregarOEditar = True Then
            ValidarRegistroExistente()
            If IdProduccion = 0 Then
                AgregarProduccion()

            Else
                Dim formaError As New ErroresForm
                formaError.mensaje = "Ya se realizó un registro de esta célula en este periodo, modifica el registro existente"
                formaError.StartPosition = FormStartPosition.CenterScreen
                formaError.ShowDialog()
                Me.Close()
            End If
        Else
            ModificarProduccion()
            Me.Close()
        End If
    End Sub

    Public Sub ValidarRegistroExistente()
        Dim Registro As New List(Of Entidades.NominaDestajos)
        Dim objRegistroBu As New Negocios.NominaDestajosBU
        Registro = objRegistroBu.ValidarRegistroExistente(IdCelula, IdPeriodo, IdNave)
        For Each row As Entidades.NominaDestajos In Registro
            IdProduccion = CInt(row.PIdProdNom)
        Next

    End Sub

    Private Sub cmbCelula_DropDownClosed(sender As Object, e As EventArgs) Handles cmbCelula.DropDownClosed
        If cmbCelula.SelectedIndex = 0 Then Return
        IdCelula = cmbCelula.SelectedValue
        If IdPeriodo > 0 Then
            RecuperarIdCelulaSicy()
            RecuperarFechaInicial()
            RecuperarTotalSay()
        End If

    End Sub

    Private Sub cmbPeriodo_DropDownClosed(sender As Object, e As EventArgs) Handles cmbPeriodo.DropDownClosed
        IdPeriodo = 0
        If cmbPeriodo.SelectedIndex = 0 Then Return
        IdPeriodo = cmbPeriodo.SelectedValue
        RecuperarUltimoRegistroDestajos()
        If IdPeriodo > 0 And IdCelula > 0 Then
            RecuperarIdCelulaSicy()
            RecuperarFechaInicial()
            RecuperarTotalSay()

            RecuperarUltimoRegistroDestajos()

        End If

    End Sub

    Private Sub RecuperarUltimoRegistroDestajos()
        Dim Produccion As New Entidades.NominaDestajos
        Dim objProduccionBU As New Negocios.NominaDestajosBU
        Dim Celulas_Ids As String

        Celulas_Ids = RecuperarCelulasDeLaNave()

        Produccion = objProduccionBU.RecuperarUltimaProduccion(IdPeriodo, Celulas_Ids)

        txtCostoSandalia.Text = Produccion.PCSandalia
        txtCostoChoclo.Text = Produccion.PCChoclo
        txtCostoBotin.Text = Produccion.PCBotin
        txtCostoMediaBota.Text = Produccion.PCMediaBota
        txtCostoBotaAlta.Text = Produccion.PCBotalAlta
        txtparsandalia1.Text = Produccion.PNSandalia
        txtParChoclo1.Text = Produccion.PNChoclo
        txtParBotin1.Text = Produccion.PNBotin
        txtParMediaBota1.Text = Produccion.PNMediaBota
        txtParBotaAlta1.Text = Produccion.PNBotaALta

        SumarCajasDeTextoInicioInterfaz()
    End Sub


    Private Function RecuperarCelulasDeLaNave() As String
        Dim objBU As New Negocios.NominaDestajosBU
        Dim dtIdCelulas As New DataTable
        Dim IdsCelulas As String = ""

        dtIdCelulas = objBU.RecuperarCelulasDeLaNave(IdNave)

        For Each item As DataRow In dtIdCelulas.Rows
            If IdsCelulas = "" Then
                IdsCelulas = CStr(item.Item(0))
            Else
                IdsCelulas = IdsCelulas + "," + CStr(item.Item(0))
            End If
        Next

        Return IdsCelulas
    End Function

    Private Sub cmbNave_DropDownClosed(sender As Object, e As EventArgs) Handles cmbNave.DropDownClosed
        If cmbNave.SelectedIndex = 0 Then Return
        IdNave = cmbNave.SelectedValue
        RecuperarIdNaveSicy()

        ComboPeriodoActivoPorNave(cmbPeriodo, IdNave)
        ComboDepatamentoSegunNave(cmbDepartamentos, IdNave)
    End Sub

    Private Sub cmbDepartamentos_DropDownClosed(sender As Object, e As EventArgs) Handles cmbDepartamentos.DropDownClosed
        If cmbDepartamentos.SelectedIndex = 0 Then Return
        IdDepartamento = cmbDepartamentos.SelectedValue

        ComboCelulasSegunDepartamento(cmbCelula, IdDepartamento)
    End Sub

    Private Sub cmbCelula_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCelula.SelectedIndexChanged

    End Sub
End Class