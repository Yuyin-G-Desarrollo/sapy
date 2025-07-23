Imports Almacen.Negocios
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports System.IO
Imports Stimulsoft.Report
Imports Tools
Imports System.Media
Imports System.Text


Public Class SalidaNavesLotesForm
    Dim CadenaCapturada As String
    Dim IdNave As Integer
    Dim IdOperador As Integer
    Dim campos_vacios As Boolean = True
    Dim CodigoPar As String

    Dim lAtados As New HashSet(Of String)
    Dim lAtadosBien As New HashSet(Of String)
    Dim lAtadosErroneos As New HashSet(Of String)
    Dim lAtadosDescartados As New HashSet(Of String)
    Dim lAtadosEmbarcados As New HashSet(Of String)

    Dim llotes As New HashSet(Of String)
    Dim llotesBien As New HashSet(Of String)
    Dim lLotesErroneos As New HashSet(Of String)
    Dim lLotesDescartados As New HashSet(Of String)
    Dim lLotesEmbarcados As New HashSet(Of String)
    Dim llotesSinTerminar As New HashSet(Of String)
    Dim llotesNoEmbarcados As New HashSet(Of String)

    Dim lpares As New HashSet(Of String)
    Dim lparesBien As New HashSet(Of String)
    Dim lparesErroneos As New HashSet(Of String)
    Dim lparesDescartados As New HashSet(Of String)
    Dim lparesEmbarcados As New HashSet(Of String)


    Dim lCodigosErroneos As New List(Of String)
    Dim lClientesValidacionParXPar_Nave As New List(Of String)
    Dim lClientesValidacionParXPar_Lote As New List(Of String)
    Dim lLotesParXPar As New HashSet(Of String)


    Dim n_lotes As Integer = 0
    Dim n_Atados_Descartados As Integer = 0
    Dim n_Pares_Pares_Descartados As Integer = 0
    Dim n_lotes_Descartados As Integer = 0
    Dim n_Atados_Correctos As Integer = 0
    Dim n_Pares_Correctos As Integer = 0
    Dim n_lotes_Correctos As Integer = 0


    Dim IdSalidaNave As Integer = 0
    Dim NumAtadoActual As Integer = 0
    Dim AtadoActual As String = "0"
    Dim AñoAtadoActual As Integer = 0
    Dim NparesAtadoActual As Integer = 0
    Dim NparesAtadoActualLeeidos As Integer = 0
    Dim IdClienteAtadoActual As Integer = 0
    Dim loteAtadoActual As Integer = 0
    Dim DescripcionAtadoActual As String
    Dim DescripcionParActual As String
    Dim IdProductoParActual As String
    Dim TallaParActual As String
    Dim TipoCodigo As String
    Dim ResultadoLoteCompleto As String 'SIRVE PARA VERIFICAR SI UN LOTE ESTA COMPLETO O INCOMPLETO, 

    Dim par_valido As Boolean
    Dim salida_pendiente As Boolean = False
    Dim ResultadoHashSet_add As Boolean

    Dim dtParesCodigoCliente As New DataTable
    Dim dtTablaGridCodigosParesEscaneados As New DataTable
    Dim dtTablaGridErrores As New DataTable
    Dim dtTalla_DescripcionParAgregado As New DataTable
    Dim dtTablaAtados As New DataTable
    Dim TipoEscaneoPar_CodInterno_CodCliente As Boolean 'true = codigo de la empresa, false = codigocliente.

    Dim n As Integer = 0
    Dim n_iniciar As Integer = 0
    Dim Numero_Par As Integer = 0

    Dim lAtadosCorrespondientes As New HashSet(Of String)
    Dim lParesAtadoActual As New HashSet(Of String)

    Dim Tipo_Nave_Maquila_o_Interna As Boolean 'TRUE PARA MAQUILA, FALSE PARA NAVE NORMAL
    Dim lListaAcciones As New List(Of String)

    ' --------------VARIABLES PARA LA SALIDA DE NAVES
    Dim Atado_Incluido_SalidaNave_en_Curso As Boolean 'TRUE PARA ATADO PERTENECIENTE, FALSE PARA ATADO SOBRANTE
    Dim LecturaParXPar As Boolean 'TRUE PARA LECTURA PAR POR PAR, FALSE PARA LECTURA POR ATADOS

    Dim IdCarritoActual As Integer

    Dim Proceso As String
    Dim Carrito_Actual_Split() As String

    Dim lAtadosDeSalida As New HashSet(Of String)
    Dim dtTablaAtados_EntradaDeLotes As New DataTable
    Dim lcarritos As New HashSet(Of Integer)
    Dim w As Integer = 0
    Dim externa As Boolean
    Dim precio As Double = 0
    Dim estatusAtado As Integer

    Dim PrimeraCarga As Boolean = True

    Private Sub SalidaNavesLotes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Location = New Point(0, 0)
        Me.WindowState = 2

        cmbNaves = Tools.Controles.ComboNavesSegunUsuarioConIdSIcy(cmbNaves, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid) 'LLENA EL COMBO NAVES
        cmbNaves.SelectedIndex = 0

        btnDetener.Enabled = False

        'DAR FORMATO A GRIDS
        DarFormatoDataTable_para_grid_Erroneos()
        DarFormatoDataTable_para_grid_Escaneados()
        '---

        'VERIFICA LOS PERMISOS DEL USUARIO LOGGEADO
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ALM_CALIDAD_ENTRADALOTES", "ALM_CAL_ENTRADA") _
            And Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ALM_EMBARQUES_SALIDANAVES", "EMBARQUES_SALIDA") Then
            Me.Text = "Entrada Y Salida de Lotes"
            lblEncabezado.Text = "Entrada Y Salida de Lotes"
            lblEncabezado.Location = New Point(96, 24)

            lListaAcciones.Insert(0, "")
            lListaAcciones.Add("ENTRADA")
            lListaAcciones.Add("SALIDA")
            cmbProceso.DataSource = lListaAcciones
        ElseIf Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ALM_CALIDAD_ENTRADALOTES", "ALM_CAL_ENTRADA") Then
            Me.Text = "Entrada de Lotes"
            lblEncabezado.Text = "Entrada de Lotes"
            lListaAcciones.Add("ENTRADA")
            Proceso = "ENTRADA"
            cmbProceso.DataSource = lListaAcciones

            lblParesAEmbarcar.Text = "Pares a Ingresar"
            lblAtadosAEmbarcar.Text = "Atados a Ingresar"
            lblLotesAEmbarcar.Text = "Lotes a Ingresar"

            pnlTotales.Height = 116
            pnlAcciones.Height = 89

            lblTotalPares.ForeColor = Color.Black
            lblTotalAtados.ForeColor = Color.Black
            lblTotalLotes.ForeColor = Color.Black
        Else
            lListaAcciones.Add("SALIDA")
            Proceso = "SALIDA"
            cmbProceso.DataSource = lListaAcciones
            lblSinTerminarNoLeido.Text = "Lote sin terminar"
            lblPink.Visible = False
            lblChocolate.Visible = False
            lblOrangered.Visible = False
            lblLoteSinTerminarAtadoConFaltante.Visible = False
            lblLoteSinTerminarAtadoCorrecto.Visible = False
            lblLoteSinTerminarAtadoMalFormado.Visible = False

            pnlAcciones.Height = 39
            pnlTotales.Height = 79

            lblTotalPares.ForeColor = Color.Red
            lblTotalAtados.ForeColor = Color.Red
            lblTotalLotes.ForeColor = Color.Red

            grpNoEmbarcados.Visible = False
        End If

        grdIncorrecto.Size = New System.Drawing.Size((Me.Width / 2 - 10), 333)
        grdLectura.Size = New System.Drawing.Size((Me.Width / 2 - 10), 333)

        listado_naves()

        PrimeraCarga = False
    End Sub


    ''' <summary>
    ''' LLENA LOS COMBOS DE NAVE DEL ALMACEN Y COMBO DE ALMACEN EN DURO(EN UN FUTURO PUEDE HABER MAS ALMACENES Y SE DEBERIA PROGRAMAR ESTA PARTE)
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub listado_naves()
        Try
            'Controles.ComboNavesConAlmacenSegunUsuario(cboxNave, CInt(Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid.ToString))
            Dim objbu As New Almacen.Negocios.AlmacenBU
            Dim dtInformacionCentroDistribucion As DataTable
            Dim dtNumeroAlmacenes As DataTable

            Try
                cboxNaveAlmacen.Enabled = True
                cboxAlmacen.Enabled = True

                If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ALM_CALIDAD_ENTRADALOTES", "VER_ALM_ASIGNADO") Then
                    dtInformacionCentroDistribucion = objbu.ConsultaCentroDistribucionActivosUsuario(Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
                Else
                    dtInformacionCentroDistribucion = objbu.ConsultaCentroDistribucionActivos()
                End If

                cboxNaveAlmacen.DataSource = dtInformacionCentroDistribucion
                cboxNaveAlmacen.DisplayMember = "Nave"
                cboxNaveAlmacen.ValueMember = "NaveSAYID"

                cboxNaveAlmacen.SelectedIndex = 0

                If cboxNaveAlmacen.SelectedIndex = 0 Then
                    dtNumeroAlmacenes = objbu.ConsultaNumeroAlmacenes(cboxNaveAlmacen.SelectedValue)
                    cboxAlmacen.DataSource = dtNumeroAlmacenes
                    cboxAlmacen.ValueMember = "NumeroAlmacen"
                    cboxAlmacen.DisplayMember = "NumeroAlmacen"
                    cboxAlmacen.SelectedIndex = 0
                End If

                'Controles.ComboNavesConAlmacenSegunUsuario(cboxNave, CInt(Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid.ToString))
            Catch ex As Exception

            End Try

        Catch ex As Exception

        End Try

        'Dim dtDatosComboNave As New DataTable
        'dtDatosComboNave.Columns.Add("nave_navesicyid")
        'dtDatosComboNave.Columns.Add("nave_nombre")

        'Dim drFilaComboNave As DataRow
        'drFilaComboNave = dtDatosComboNave.NewRow()
        'drFilaComboNave("nave_navesicyid") = "43"
        'drFilaComboNave("nave_nombre") = "COMERCIALIZADORA"
        'dtDatosComboNave.Rows.Add(drFilaComboNave)

        'cboxNaveAlmacen.DataSource = dtDatosComboNave
        'cboxNaveAlmacen.ValueMember = "nave_navesicyid"
        'cboxNaveAlmacen.DisplayMember = "nave_nombre"
        'cboxNaveAlmacen.SelectedIndex = 0


        'If cboxNaveAlmacen.SelectedIndex = 0 Then
        '    Dim dtDatosComboAlmacen As New DataTable
        '    dtDatosComboAlmacen.Columns.Add("bahi_almacen")

        '    Dim drFilaComboAlmacen As DataRow
        '    drFilaComboAlmacen = dtDatosComboAlmacen.NewRow()
        '    drFilaComboAlmacen("bahi_almacen") = "1"
        '    dtDatosComboAlmacen.Rows.Add(drFilaComboAlmacen)

        '    cboxAlmacen.DataSource = dtDatosComboAlmacen
        '    cboxAlmacen.ValueMember = "bahi_almacen"
        '    cboxAlmacen.DisplayMember = "bahi_almacen"
        '    cboxAlmacen.SelectedIndex = 0
        'End If


    End Sub


    ''' <summary>
    ''' FUNCION PARA MANDAR LLAMAR LOS FORMS DE MENSAJES DE ERROR, ALERTA, EXITO ETC.
    ''' </summary>
    ''' <param name="tipo">TIPO DE MENSAJE QUE SE UTILIZARA</param>
    ''' <param name="mensaje">CONTENIDO DEL MENSAJE</param>
    ''' <remarks></remarks>
    Public Sub show_message(ByVal tipo As String, ByVal mensaje As String)
        If tipo.ToString.Equals("Advertencia") Then
            Dim mensajeAdvertencia As New AdvertenciaForm
            mensajeAdvertencia.mensaje = mensaje
            mensajeAdvertencia.ShowDialog()
        End If

        If tipo.ToString.Equals("Aviso") Then
            Dim mensajeAviso As New AvisoForm
            mensajeAviso.mensaje = mensaje
            mensajeAviso.ShowDialog()
        End If

        If tipo.ToString.Equals("Error") Then
            Dim mensajeError As New ErroresForm
            mensajeError.mensaje = mensaje
            mensajeError.ShowDialog()
        End If

        If tipo.ToString.Equals("Exito") Then
            Dim mensajeExito As New ExitoForm
            mensajeExito.mensaje = mensaje
            mensajeExito.ShowDialog()
        End If

        If tipo.ToString.Equals("Confirmar") Then
            Dim mensajeExito As New ConfirmarForm

            mensajeExito.ShowDialog()
        End If
    End Sub


    ''' <summary>
    ''' VALIDA QUE NO EXISTAN CAMPOS VACIOS OBLIGATORIOS EN LA VENTANA
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ValidarCamposVacios()
        campos_vacios = False

        If IdNave <= 0 And cmbProceso.Text = "" Then
            show_message("Advertencia", "Seleccione una nave y el tipo de proceso para poder comenzar a escanear")
            campos_vacios = True
            lblTipo.ForeColor = Color.Red
            lblNave.ForeColor = Color.Red
        ElseIf IdNave <= 0 Then
            show_message("Advertencia", "Seleccione una nave para poder comenzar a escanear")
            campos_vacios = True
            lblTipo.ForeColor = Color.Black
            lblNave.ForeColor = Color.Red
            campos_vacios = True
        ElseIf cmbProceso.Text = "" Then
            show_message("Advertencia", "Seleccione un proceso para poder comenzar a escanear")
            campos_vacios = True
            lblTipo.ForeColor = Color.Red
            lblNave.ForeColor = Color.Black
        Else
            lblTipo.ForeColor = Color.Black
            lblNave.ForeColor = Color.Black
            campos_vacios = False
        End If
    End Sub


    ''' <summary>
    ''' EVENTO SELECTEDVALUECHANGED PARA EL COMBO CMBNAVES
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cmbNaves_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbNaves.SelectedValueChanged
        If cmbNaves.ContainsFocus Then
            IdNave = CInt(cmbNaves.SelectedValue)
            n_iniciar = 0
        End If
    End Sub

    Private Sub Escribir_linea_en_Bitacora(ByVal Errores_Lectura As String, ByVal Metodo As String)
        Try
            Dim ruta As String = "c:\Bitacora_Salida_Entrada_Lotes\Bitacora_De_Errores_SalidaNaves.txt"
            Dim escritor As StreamWriter
            escritor = File.AppendText(ruta)
            escritor.WriteLine(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + " - " + Errores_Lectura + "      Metodo:" + Metodo)
            escritor.Flush()
            escritor.Close()
        Catch exe As Exception
            show_message("Error", "Escritura realizada incorrectamente " + exe.Message)
        End Try
    End Sub

    Private Sub EscribirErrorEnBiacora(ByVal Errores_Lectura As String, ByVal Metodo As String)
        If File.Exists("c:\Bitacora_Salida_Entrada_Lotes") = False Then

            Directory.CreateDirectory("c:\Bitacora_Salida_Entrada_Lotes")


            If File.Exists("c:\Bitacora_Salida_Entrada_Lotes\Bitacora_De_Errores_SalidaNaves.txt") = False Then
                Dim path As String = "c:\Bitacora_Salida_Entrada_Lotes\Bitacora_De_Errores_SalidaNaves.txt"

                ' Create or overwrite the file.
                Dim fs As FileStream = File.Create(path)

                ' Add text to the file.
                Dim info As Byte() = New UTF8Encoding(True).GetBytes("Bitacora de errores Entrada/Salida de lotes.")
                fs.Write(info, 0, info.Length)
                fs.Close()

                Escribir_linea_en_Bitacora(Errores_Lectura, Metodo)
            Else
                Escribir_linea_en_Bitacora(Errores_Lectura, Metodo)

            End If
        Else
            If File.Exists("c:\Bitacora_Salida_Entrada_Lotes\Bitacora_De_Errores_SalidaNaves.txt") = False Then
                Dim path As String = "c:\Bitacora_Salida_Entrada_Lotes\Bitacora_De_Errores_SalidaNaves.txt"

                ' Create or overwrite the file.
                Dim fs As FileStream = File.Create(path)

                ' Add text to the file.
                Dim info As Byte() = New UTF8Encoding(True).GetBytes("Bitacora de errores Entrada/Salida de lotes.")
                fs.Write(info, 0, info.Length)
                fs.Close()

                Escribir_linea_en_Bitacora(Errores_Lectura, Metodo)

            Else
                Escribir_linea_en_Bitacora(Errores_Lectura, Metodo)

            End If
        End If

    End Sub

    ''' <summary>
    ''' EVENTO KEYPRESS PARA AGREGAR CODIGOS A VERIFICAR
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>

    Private Sub txtcapturacodigos_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtcapturacodigos.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If (LTrim(RTrim(txtcapturacodigos.Text))) = "" Then Return
            CadenaCapturada = (LTrim(RTrim(txtcapturacodigos.Text))).Replace("'", "-")
            If cmbProceso.Text = "SALIDA" Then
                CapturaParAtadosYuyin(CadenaCapturada)
            Else
                CapturarParAtados_EntradaNave(CadenaCapturada)
            End If
            txtcapturacodigos.Text = ""
            txtcapturacodigos.Focus()
        End If
    End Sub


    ''' <summary>
    ''' VERIFICA SÍ EL CODIGO LEEIDO PERTENECE A UN ATADO VALIDO, SI ES EL CASO RECUPERA DATOS COMO LO SON LOTE, AÑO, Y NAVE
    ''' </summary>
    ''' <param name="Codigo">CODIGO A VERIFICAR</param>
    ''' <returns>CLASE ENTIDADES.CAPTURAATADOVALIDO CON DATOS EN SUS VARIABLES</returns>
    ''' <remarks></remarks>
    Private Function VerificarAtadoValido_RecuperarDatosLote(ByVal Codigo As String)
        Dim objBUSalidaNaves As New SalidaNavesBU
        Dim AtadoValido As New Entidades.CapturaAtadoValido

        w = 1
        Do While w = 1
            Try
                AtadoValido = objBUSalidaNaves.VerificarAtadoValido_RecuperaInformacionLote(Codigo)
                w = 0
            Catch ex As Exception
                If ex.Message.Contains(" interbloqueo ") = False Then
                    w = 0
                End If

                EscribirErrorEnBiacora(ex.Message, "VerificarAtadoValido_RecuperarDatosLote")
            End Try
        Loop

        Return AtadoValido
    End Function


    ''' <summary>
    ''' AGREGA UN NUEVO REGISTRO A LA TABLA PRODUCCION.SALIDANAVES Y RECUPERA EL ID GENERADO 
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub IniciarSalidaNaves()
        Dim objBU As New SalidaNavesBU

        w = 1
        Do While w = 1
            Try
                IdSalidaNave = objBU.IniciarSalidaNave(IdNave, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, Tipo_Nave_Maquila_o_Interna)
                w = 0
            Catch ex As Exception
                If ex.Message.Contains(" interbloqueo ") = False Then
                    w = 0
                End If
                EscribirErrorEnBiacora(ex.Message, "IniciarSalidaNaves()")
            End Try
        Loop
    End Sub


    ''' <summary>
    ''' EJECUTA EL PROCEDIMIENTO ALMACENADO EN EL QUE VERIFICA SI EL LOTE DEL CODIGO DE ATADOE SCANEADO YA SE ENCUENTRA EN LA TABLA PRODUCCION.SALIDANAVESDETALLES
    ''' DE LO CONTRARIO AGREGA TODOS LOS PARES PERTENECIENTES A ESE LOTE
    ''' </summary>
    ''' <param name="datosAtado"></param>
    ''' <remarks></remarks>
    Public Function ValidarLoteTerminado(ByVal datosAtado As Entidades.CapturaAtadoValido)
        Dim objBU As New SalidaNavesBU
        Dim dtTabla As New DataTable

        w = 1
        Do While w = 1
            Try
                dtTabla = objBU.ValidarLoteTerminado(datosAtado, IdSalidaNave)
                w = 0
            Catch ex As Exception
                If ex.Message.Contains(" interbloqueo ") = False Then
                    w = 0
                End If
                EscribirErrorEnBiacora(ex.Message, "ValidarLoteTerminado()")
            End Try
        Loop

        Dim resultado As String = String.Empty
        For Each row As DataRow In dtTabla.Rows
            resultado = row.Item(0)
        Next

        If resultado = "INCOMPLETO" Then
            llotesSinTerminar.Add(datosAtado.PLote.ToString + "-" + datosAtado.PAño.ToString + "-" + datosAtado.PIdNAve.ToString)
        ElseIf resultado = "COMPLETO" Then
            llotesSinTerminar.Remove(datosAtado.PLote.ToString + "-" + datosAtado.PAño.ToString + "-" + datosAtado.PIdNAve.ToString)
        End If

        Return resultado
    End Function


    ''' <summary>
    ''' RECUPERA UNA TABLA CON LOS TOTALES DE PARES DE UN ATADO DEACUERDO EN EL ESTADO EN EL QUE SE ENCUENTRA(ENCONTRADO, FALTANTE SOBRANTE)
    ''' </summary>
    ''' <returns>TABLA CON LOS TOTALES DE PARES DE DETERMINADO ATADO ENCONTRADOS</returns>
    ''' <remarks></remarks>
    Public Function Recuperar_Totales_Pares_De_Atado_Segun_Estatus()
        Dim objBU As New SalidaNavesBU
        Dim dtTotales As New DataTable
        dtTotales = objBU.Recuperar_Totales_Pares_De_Atado_Segun_Estatus(IdSalidaNave, AtadoActual, Proceso, Tipo_Nave_Maquila_o_Interna, IdNave)
        Return dtTotales
    End Function


    ''' <summary>
    ''' VERIFICA LOS TOTALES DE PARES DE UN ATADO QUE FUE ESCANEADO CON CODIGOS UNICOS YUYIN PARA DETERMINAR EN QUE ESTADO SE ENCUENTRA EL ATADO(CORRECTO, FALTANTE, SOBRANTE, MAL CONFIGURADO)
    ''' </summary>
    ''' <returns>ESTADO CORRESPONDIENTE AL ATADO DEACUERDO A LOS PARES ENCONTRADOS</returns>
    ''' <remarks></remarks>
    Public Function RecuperarEstatusDeAtadoN()
        Dim tmpBien As Integer
        Dim tmpSobrante As Integer
        Dim tmpFaltante As Integer
        Dim EstadoAtado As Integer
        Dim dtTotales As New DataTable

        w = 1
        Do While w = 1
            Try
                dtTotales = Recuperar_Totales_Pares_De_Atado_Segun_Estatus()
                w = 0
            Catch ex As Exception
                If ex.Message.Contains(" interbloqueo ") = False Then
                    w = 0
                End If
                EscribirErrorEnBiacora(ex.Message, "RecuperarEstatusDeAtadoN, Recuperar_Totales_Pares_De_Atado_Segun_Estatus")
            End Try
        Loop

        n = 0
        For Each row As DataRow In dtTotales.Rows
            n += 1
            If IsDBNull(row.Item("RESULTADO")) Then
                tmpFaltante += 1
                lparesBien.Remove(CStr(row.Item("ATADO")) + "-" + CStr(row.Item("PAR")) + "-" + CStr(row.Item("Numero_Par")))
            Else
                If row.Item("RESULTADO") = 1 Then
                    tmpBien += 1
                    lparesBien.Add(CStr(row.Item("ATADO")) + "-" + CStr(row.Item("PAR")) + "-" + CStr(row.Item("Numero_Par")))
                    lparesErroneos.Remove(CStr(row.Item("ATADO")) + "-" + CStr(row.Item("PAR")) + "-" + CStr(row.Item("Numero_Par")))
                ElseIf row.Item("RESULTADO") = 2 Then
                    tmpFaltante += 1
                    lparesBien.Remove(CStr(row.Item("ATADO")) + "-" + CStr(row.Item("PAR")) + "-" + CStr(row.Item("Numero_Par")))
                Else
                    tmpSobrante += 1
                    lparesErroneos.Add(CStr(row.Item("ATADO")) + "-" + CStr(row.Item("PAR")) + "-" + CStr(row.Item("Numero_Par")))
                    lparesBien.Remove(CStr(row.Item("ATADO")) + "-" + CStr(row.Item("PAR")) + "-" + CStr(row.Item("Numero_Par")))
                End If
            End If

        Next


        If tmpBien = 0 And tmpFaltante = 0 And tmpSobrante = 0 Then
            If llotesSinTerminar.Contains(loteAtadoActual.ToString + "-" + AñoAtadoActual.ToString + "-" + IdNave.ToString) = False Then
                If llotesNoEmbarcados.Contains(loteAtadoActual.ToString + "-" + AñoAtadoActual.ToString + "-" + IdNave.ToString) = False Then
                    EstadoAtado = 2
                Else
                    EstadoAtado = 11
                End If
            Else
                EstadoAtado = 7
            End If
            'REPRODUCIR EL SONIDO DE ERROR
            ReproducrirSonidoError()
        ElseIf tmpBien - tmpFaltante = tmpBien And tmpSobrante = 0 Then
            If llotesSinTerminar.Contains(loteAtadoActual.ToString + "-" + AñoAtadoActual.ToString + "-" + IdNave.ToString) = False Then
                If llotesNoEmbarcados.Contains(loteAtadoActual.ToString + "-" + AñoAtadoActual.ToString + "-" + IdNave.ToString) = False Then
                    EstadoAtado = 1
                Else
                    EstadoAtado = 10
                    'REPRODUCIR EL SONIDO DE ERROR
                    ReproducrirSonidoError()
                End If
            Else
                EstadoAtado = 6
                'REPRODUCIR EL SONIDO DE ERROR
                ReproducrirSonidoError()
            End If
        ElseIf tmpBien - tmpFaltante = tmpBien And tmpSobrante > 0 Then
            If llotesSinTerminar.Contains(loteAtadoActual.ToString + "-" + AñoAtadoActual.ToString + "-" + IdNave.ToString) = False Then
                If llotesNoEmbarcados.Contains(loteAtadoActual.ToString + "-" + AñoAtadoActual.ToString + "-" + IdNave.ToString) = False Then
                    EstadoAtado = 4
                Else
                    EstadoAtado = 12
                End If
            Else
                EstadoAtado = 8
            End If
            'REPRODUCIR EL SONIDO DE ERROR
            ReproducrirSonidoError()
        ElseIf tmpFaltante > 0 And tmpSobrante = 0 Then
            If llotesSinTerminar.Contains(loteAtadoActual.ToString + "-" + AñoAtadoActual.ToString + "-" + IdNave.ToString) = False Then
                EstadoAtado = 2
                If llotesNoEmbarcados.Contains(loteAtadoActual.ToString + "-" + AñoAtadoActual.ToString + "-" + IdNave.ToString) = False Then
                    EstadoAtado = 2
                Else
                    EstadoAtado = 11
                End If
            Else
                EstadoAtado = 7
            End If
            'REPRODUCIR EL SONIDO DE ERROR
            ReproducrirSonidoError()
        ElseIf tmpFaltante = tmpSobrante And tmpFaltante > 0 Then
            If llotesSinTerminar.Contains(loteAtadoActual.ToString + "-" + AñoAtadoActual.ToString + "-" + IdNave.ToString) = False Then
                If llotesNoEmbarcados.Contains(loteAtadoActual.ToString + "-" + AñoAtadoActual.ToString + "-" + IdNave.ToString) = False Then
                    EstadoAtado = 4
                Else
                    EstadoAtado = 12
                End If
            Else
                EstadoAtado = 8
            End If
            'REPRODUCIR EL SONIDO DE ERROR
            ReproducrirSonidoError()
        ElseIf tmpFaltante > 0 And tmpSobrante > 0 Then
            If llotesSinTerminar.Contains(loteAtadoActual.ToString + "-" + AñoAtadoActual.ToString + "-" + IdNave.ToString) = False Then
                If llotesNoEmbarcados.Contains(loteAtadoActual.ToString + "-" + AñoAtadoActual.ToString + "-" + IdNave.ToString) = False Then
                    EstadoAtado = 4
                Else
                    EstadoAtado = 12
                End If
            Else
                EstadoAtado = 8
            End If
            'REPRODUCIR EL SONIDO DE ERROR
            ReproducrirSonidoError()
        End If

        Return EstadoAtado
    End Function


    ''' <summary>
    ''' VERIFICA LOS TOTALES DE PARES DE UN ATADO QUE FUE ESCANEADO CON CODIGOS DE CLIENTES PARA DETERMINAR EN QUE ESTADO SE ENCUENTRA EL ATADO(CORRECTO, FALTANTE, SOBRANTE, MAL CONFIGURADO)
    ''' </summary>
    ''' <returns>ESTADO CORRESPONDIENTE AL ATADO DEACUERDO A LOS PARES ENCONTRADOS</returns>
    ''' <remarks></remarks>
    Public Function RecuperarEstatusDeAtadoN_CodigosCliente()
        Dim tmpBien As Integer
        Dim tmpSobrante As Integer
        Dim tmpFaltante As Integer
        Dim EstadoAtado As Integer
        Dim dtTotales As New DataTable

        n = 0
        For Each row As DataRow In dtParesCodigoCliente.Rows
            n += 1
            If IsDBNull(row.Item("Estado")) = True Then
                tmpFaltante = tmpFaltante + 1
                lparesBien.Remove(AtadoActual + "-" + CStr(row.Item("CODIGO_CLIENTE")) + "-" + CStr(row.Item("#")))
            Else
                If row.Item("Estado") = 1 Then
                    tmpBien = tmpBien + 1
                    If IsDBNull(row.Item("CODIGO_CLIENTE")) Then
                        lparesBien.Add(AtadoActual + "-" + CStr(row.Item("PAR")) + "-" + CStr(row.Item("#")))
                    Else
                        lparesBien.Add(AtadoActual + "-" + CStr(row.Item("CODIGO_CLIENTE")) + "-" + CStr(row.Item("#")))
                    End If
                ElseIf row.Item("Estado") = 3 Then
                    lparesErroneos.Add(AtadoActual + "-" + row.Item("PAR") + "-" + CStr(row.Item("#")))
                    tmpSobrante = tmpSobrante + 1
                Else
                    tmpFaltante = tmpFaltante + 1
                End If
            End If
        Next


        If tmpBien = 0 And tmpFaltante = 0 And tmpSobrante = 0 Then
            If llotesSinTerminar.Contains(loteAtadoActual.ToString + "-" + AñoAtadoActual.ToString + "-" + IdNave.ToString) = False Then
                If llotesNoEmbarcados.Contains(loteAtadoActual.ToString + "-" + AñoAtadoActual.ToString + "-" + IdNave.ToString) = False Then
                    EstadoAtado = 2
                Else
                    EstadoAtado = 11
                End If
            Else
                EstadoAtado = 7
            End If

            'REPRODUCIMOS EL SONIDO DE ERROR
            ReproducrirSonidoError()
        ElseIf tmpBien - tmpFaltante = tmpBien And tmpSobrante = 0 Then
            If llotesSinTerminar.Contains(loteAtadoActual.ToString + "-" + AñoAtadoActual.ToString + "-" + IdNave.ToString) = False Then
                If llotesNoEmbarcados.Contains(loteAtadoActual.ToString + "-" + AñoAtadoActual.ToString + "-" + IdNave.ToString) = False Then
                    EstadoAtado = 1
                Else
                    EstadoAtado = 10
                    'REPRODUCIR EL SONIDO DE ERROR
                    ReproducrirSonidoError()
                End If
            Else
                EstadoAtado = 6
                'REPRODUCIR EL SONIDO DE ERROR
                ReproducrirSonidoError()
            End If
        ElseIf tmpBien - tmpFaltante = tmpBien And tmpSobrante > 0 Then
            If llotesSinTerminar.Contains(loteAtadoActual.ToString + "-" + AñoAtadoActual.ToString + "-" + IdNave.ToString) = False Then
                If llotesNoEmbarcados.Contains(loteAtadoActual.ToString + "-" + AñoAtadoActual.ToString + "-" + IdNave.ToString) = False Then
                    EstadoAtado = 4
                Else
                    EstadoAtado = 12
                End If
            Else
                EstadoAtado = 8
            End If
            'REPRODUCIR EL SONIDO DE ERROR
            ReproducrirSonidoError()
        ElseIf tmpFaltante > 0 And tmpSobrante = 0 Then
            If llotesSinTerminar.Contains(loteAtadoActual.ToString + "-" + AñoAtadoActual.ToString + "-" + IdNave.ToString) = False Then
                If llotesNoEmbarcados.Contains(loteAtadoActual.ToString + "-" + AñoAtadoActual.ToString + "-" + IdNave.ToString) = False Then
                    EstadoAtado = 2
                Else
                    EstadoAtado = 11
                End If
            Else
                EstadoAtado = 7
            End If
            'REPRODUCIR EL SONIDO DE ERROR
            ReproducrirSonidoError()
        ElseIf tmpFaltante = tmpSobrante And tmpFaltante > 0 Then
            If llotesSinTerminar.Contains(loteAtadoActual.ToString + "-" + AñoAtadoActual.ToString + "-" + IdNave.ToString) = False Then
                If llotesNoEmbarcados.Contains(loteAtadoActual.ToString + "-" + AñoAtadoActual.ToString + "-" + IdNave.ToString) = False Then
                    EstadoAtado = 4
                Else
                    EstadoAtado = 12
                End If
            Else
                EstadoAtado = 8
            End If
            'REPRODUCIR EL SONIDO DE ERROR
            ReproducrirSonidoError()
        ElseIf tmpFaltante > 0 And tmpSobrante > 0 Then
            If llotesSinTerminar.Contains(loteAtadoActual.ToString + "-" + AñoAtadoActual.ToString + "-" + IdNave.ToString) = False Then
                If llotesNoEmbarcados.Contains(loteAtadoActual.ToString + "-" + AñoAtadoActual.ToString + "-" + IdNave.ToString) = False Then
                    EstadoAtado = 4
                Else
                    EstadoAtado = 12
                End If
            Else
                EstadoAtado = 8
            End If
            'REPRODUCIR EL SONIDO DE ERROR
            ReproducrirSonidoError()
        End If
        If estatusAtado = 911 Then
            EstadoAtado = 911
        End If
        Return EstadoAtado
    End Function


    ''' <summary>
    ''' ACTUALIZA EL ESTATUS DE  UN ATADO EN LA TABLA PRODUCCION.SALIDANAVESDETALLES, EN CASO DE NO ESTAR CORRECTO LO AGREGA AL GRID DE ERRORES
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ActualizarEstatusDeAtado()
        Dim Estatus_Atado As Integer

        'NO REALIZA ACCION ALGUNA EN CASO DE QUE LA NAVE SEA DE LA EMRPESA, NO HAYA QUE VALIDAR PAR POR PAR Y EL PROCESO ES UNA ENTRADA
        If LecturaParXPar = False And Proceso = "ENTRADA" Then
            lAtadosBien.Add(loteAtadoActual.ToString + "-" + AñoAtadoActual.ToString + "-" + IdNave.ToString + "-" + AtadoActual.ToString)
            lAtadosErroneos.Remove(loteAtadoActual.ToString + "-" + AñoAtadoActual.ToString + "-" + IdNave.ToString + "-" + AtadoActual.ToString)

            If llotesSinTerminar.Contains(loteAtadoActual.ToString + "-" + AñoAtadoActual.ToString + "-" + IdNave.ToString) = False Then
                'ELIMINA EL ATADO DEL GRID ERRORES
                If llotesNoEmbarcados.Contains(loteAtadoActual.ToString + "-" + AñoAtadoActual.ToString + "-" + IdNave.ToString) = False Then
                    For cont = grdIncorrecto.Rows.Count - 1 To 0 Step -1
                        If grdIncorrecto.Rows(cont).Cells("Atado").Text = AtadoActual Then
                            grdIncorrecto.Rows(cont).Delete(True)
                            cont = 0
                        End If
                    Next
                    Estatus_Atado = 1
                Else
                    For cont = grdIncorrecto.Rows.Count - 1 To 0 Step -1
                        If grdIncorrecto.Rows(cont).Cells("Atado").Text = AtadoActual Then
                            grdIncorrecto.Rows(cont).Cells("Estado").Value = 10
                            grdIncorrecto.Rows(cont).CellAppearance.BackColor = Color.DodgerBlue
                            cont = 0
                        End If
                    Next
                    Estatus_Atado = 10
                    ReproducrirSonidoError()
                End If
            Else
                For cont = grdIncorrecto.Rows.Count - 1 To 0 Step -1
                    If grdIncorrecto.Rows(cont).Cells("Atado").Text = AtadoActual Then
                        'colorear_grid(grdIncorrecto)
                        grdIncorrecto.Rows(cont).Cells("Estado").Value = 6
                        grdIncorrecto.Rows(cont).CellAppearance.BackColor = Color.Pink
                        cont = 0
                    End If
                Next
                Estatus_Atado = 6

                ReproducrirSonidoError()
            End If

            Dim objBU As New SalidaNavesBU

            w = 1
            Do While w = 1
                Try
                    If estatusAtado <> 911 Then
                        objBU.ActualizarEstatusDeAtadoN(AtadoActual, Estatus_Atado, IdSalidaNave, AñoAtadoActual, LecturaParXPar, NparesAtadoActualLeeidos, loteAtadoActual, IdNave, Proceso, Tipo_Nave_Maquila_o_Interna, IdCarritoActual)
                    End If
                    w = 0
                Catch ex As Exception
                    If ex.Message.Contains(" interbloqueo ") = False Then
                        w = 0
                    End If
                    EscribirErrorEnBiacora(ex.Message, "ActualizarEstatusDeAtado, objbu.ActualizarEstatusDeAtadoN - 1")
                End Try
            Loop
        Else
            If LecturaParXPar = False Then
                lAtadosBien.Add(loteAtadoActual.ToString + "-" + AñoAtadoActual.ToString + "-" + IdNave.ToString + "-" + AtadoActual.ToString)
                lAtadosErroneos.Remove(loteAtadoActual.ToString + "-" + AñoAtadoActual.ToString + "-" + IdNave.ToString + "-" + AtadoActual.ToString)

                'ELIMINA EL ATADO DEL GRID ERRORES
                For cont = grdIncorrecto.Rows.Count - 1 To 0 Step -1
                    If grdIncorrecto.Rows(cont).Cells("Atado").Text = AtadoActual Then
                        grdIncorrecto.Rows(cont).Delete(True)
                        cont = 0
                    End If
                Next
                Estatus_Atado = 1

                Dim objBU As New SalidaNavesBU

                w = 1
                Do While w = 1
                    Try
                        If estatusAtado <> 911 Then
                            objBU.ActualizarEstatusDeAtadoN(AtadoActual, Estatus_Atado, IdSalidaNave, AñoAtadoActual, LecturaParXPar, NparesAtadoActualLeeidos, loteAtadoActual, IdNave, Proceso, Tipo_Nave_Maquila_o_Interna, IdCarritoActual)
                        End If

                        w = 0
                    Catch ex As Exception
                        If ex.Message.Contains(" interbloqueo ") = False Then
                            w = 0
                        End If
                        EscribirErrorEnBiacora(ex.Message, "ActualizarEstatusDeAtado, objbu.ActualizarEstatusDeAtadoN - 2")
                    End Try
                Loop
            Else
                If TipoEscaneoPar_CodInterno_CodCliente = False Then
                    Estatus_Atado = RecuperarEstatusDeAtadoN_CodigosCliente()
                Else
                    Estatus_Atado = RecuperarEstatusDeAtadoN()
                End If

                Dim objBU As New SalidaNavesBU
                If AtadoActual <> "0" And LecturaParXPar = True Then
                    w = 1
                    Do While w = 1
                        Try
                            If estatusAtado <> 911 Then
                                objBU.ActualizarEstatusDeAtadoN(AtadoActual, Estatus_Atado, IdSalidaNave, AñoAtadoActual, LecturaParXPar, _
                                                           NparesAtadoActualLeeidos, loteAtadoActual, IdNave, Proceso, _
                                                           Tipo_Nave_Maquila_o_Interna, IdCarritoActual)
                            End If

                            w = 0
                        Catch ex As Exception
                            If ex.Message.Contains(" interbloqueo ") = False Then
                                w = 0
                            End If
                            EscribirErrorEnBiacora(ex.Message, "    ActualizarEstatusDeAtado, objBU.ActualizarEstatusDeAtadoN - 3")
                        End Try
                    Loop
                End If

                If Estatus_Atado > 1 Then
                    For cont = grdIncorrecto.Rows.Count - 1 To 0 Step -1
                        If grdIncorrecto.Rows(cont).Cells("Atado").Text = AtadoActual Then
                            'colorear_grid(grdIncorrecto)
                            grdIncorrecto.Rows(cont).Cells("Estado").Value = Estatus_Atado
                            If Estatus_Atado = 2 Then
                                grdIncorrecto.Rows(cont).CellAppearance.BackColor = Color.Khaki '-------COLOR PAEA ATADO CON FALTANTE
                            ElseIf Estatus_Atado = 4 Then
                                grdIncorrecto.Rows(cont).CellAppearance.BackColor = Color.LightSalmon '-COLOR PARA ATADO MAL FORMADO
                            ElseIf Estatus_Atado = 0 Then
                                grdIncorrecto.Rows(cont).CellAppearance.BackColor = Color.Silver '-------COLOR PAEA ATADO NO LEIDO
                            ElseIf Estatus_Atado = 5 Then
                                grdIncorrecto.Rows(cont).CellAppearance.BackColor = Color.Orange '------COLOR PARA LOTE SIN TERMINAR
                            ElseIf Estatus_Atado = 6 Then
                                grdIncorrecto.Rows(cont).CellAppearance.BackColor = Color.Pink '--------COLOR APRA ATADO CORRECTO DE LOTE SIN TERMINAR
                            ElseIf Estatus_Atado = 7 Then
                                grdIncorrecto.Rows(cont).CellAppearance.BackColor = Color.Chocolate '---COLOR PARA ATADO CON FALTANTE DE LOTE SIN TERMINAR
                            ElseIf Estatus_Atado = 8 Then
                                grdIncorrecto.Rows(cont).CellAppearance.BackColor = Color.OrangeRed '---------COLOR PARA ATADO MAL FORMADO DE LOTE SIN TERMINAR
                            ElseIf Estatus_Atado = 9 Then
                                grdIncorrecto.Rows(cont).CellAppearance.BackColor = Color.SteelBlue  '------COLOR PARA LOTE NO EMBARCADO
                            ElseIf Estatus_Atado = 10 Then
                                grdIncorrecto.Rows(cont).CellAppearance.BackColor = Color.DodgerBlue '--------COLOR ATADO CORRECTO DE LOTE SIN EMBARCAR
                            ElseIf Estatus_Atado = 11 Then
                                grdIncorrecto.Rows(cont).CellAppearance.BackColor = Color.Aqua '---COLOR PARA ATADO CON FALTANTE DE LOTE SIN EMBARCAR
                            ElseIf Estatus_Atado = 12 Then
                                grdIncorrecto.Rows(cont).CellAppearance.BackColor = Color.CadetBlue '---------COLOR PARA ATADO MAL FORMADO DE LOTE SIN EMBARCAR
                            ElseIf Estatus_Atado = 911 Then
                                grdIncorrecto.Rows(cont).CellAppearance.BackColor = Color.MediumSlateBlue '---------COLOR PARA ATADO SIN PRECIO
                            End If
                            cont = 0
                        End If
                    Next

                    'REMOVEMOS EL ATADO DEL HASHSET DE ATADOSBIEN Y LO AGREGAMOS AL HASHSET DE ATADOS MAL
                    lAtadosBien.Remove(loteAtadoActual.ToString + "-" + AñoAtadoActual.ToString + "-" + IdNave.ToString + "-" + AtadoActual.ToString)
                    lAtadosErroneos.Add(loteAtadoActual.ToString + "-" + AñoAtadoActual.ToString + "-" + IdNave.ToString + "-" + AtadoActual.ToString)
                Else
                    'REMOVEMOS EL ATADO DEL HASHSET DE ATADOS MAL Y LO AGREGAMOS AL HASHSET DE ATADOS BIEN
                    lAtadosBien.Add(loteAtadoActual.ToString + "-" + AñoAtadoActual.ToString + "-" + IdNave.ToString + "-" + AtadoActual.ToString)
                    lAtadosErroneos.Remove(loteAtadoActual.ToString + "-" + AñoAtadoActual.ToString + "-" + IdNave.ToString + "-" + AtadoActual.ToString)

                    'ELIMINAMOS EL TADO DEL GRID DE ERRORES
                    For cont = grdIncorrecto.Rows.Count - 1 To 0 Step -1
                        If grdIncorrecto.Rows(cont).Cells("Atado").Text = AtadoActual Then
                            grdIncorrecto.Rows(cont).Delete(True)
                            cont = 0 '---ADECUACION
                        End If
                    Next
                End If
            End If
        End If

        Dim n_1 As Integer = 0

        For cont = grdLectura.Rows.Count - 1 To 0 Step -1
            If grdLectura.Rows(cont).Cells("Atado").Text = AtadoActual Then
                grdLectura.Rows(cont).Cells("Estado").Value = Estatus_Atado
                If grdLectura.Rows(cont).Cells("Estado").Value = 1 Then
                    grdLectura.Rows(cont).CellAppearance.BackColor = Color.White
                ElseIf grdLectura.Rows(cont).Cells("Estado").Value = 2 Then
                    grdLectura.Rows(cont).CellAppearance.BackColor = Color.Khaki '-------COLOR PAEA ATADO CON FALTANTE
                ElseIf grdLectura.Rows(cont).Cells("Estado").Value = 4 Then
                    grdLectura.Rows(cont).CellAppearance.BackColor = Color.LightSalmon '-COLOR PARA ATADO MAL FORMADO
                ElseIf grdLectura.Rows(cont).Cells("Estado").Value = 5 Then
                    grdLectura.Rows(cont).CellAppearance.BackColor = Color.Orange '------COLOR PARA LOTE SIN TERMINAR
                ElseIf grdLectura.Rows(cont).Cells("Estado").Value = 6 Then
                    grdLectura.Rows(cont).CellAppearance.BackColor = Color.Pink '--------COLOR APRA ATADO CORRECTO DE LOTE SIN TERMINAR
                ElseIf grdLectura.Rows(cont).Cells("Estado").Value = 7 Then
                    grdLectura.Rows(cont).CellAppearance.BackColor = Color.Chocolate '---COLOR PARA ATADO CON FALTANTE DE LOTE SIN TERMINAR
                ElseIf grdLectura.Rows(cont).Cells("Estado").Value = 8 Then
                    grdLectura.Rows(cont).CellAppearance.BackColor = Color.OrangeRed '---------COLOR PARA ATADO MAL FORMADO DE LOTE SIN TERMINAR
                ElseIf grdLectura.Rows(cont).Cells("Estado").Value = 9 Then
                    grdLectura.Rows(cont).CellAppearance.BackColor = Color.SteelBlue  '------COLOR PARA LOTE NO EMBARCADO
                ElseIf grdLectura.Rows(cont).Cells("Estado").Value = 10 Then
                    grdLectura.Rows(cont).CellAppearance.BackColor = Color.DodgerBlue '--------COLOR ATADO CORRECTO DE LOTE SIN EMBARCAR
                ElseIf grdLectura.Rows(cont).Cells("Estado").Value = 11 Then
                    grdLectura.Rows(cont).CellAppearance.BackColor = Color.Aqua '---COLOR PARA ATADO CON FALTANTE DE LOTE SIN EMBARCAR
                ElseIf grdLectura.Rows(cont).Cells("Estado").Value = 12 Then
                    grdLectura.Rows(cont).CellAppearance.BackColor = Color.CadetBlue '---------COLOR PARA ATADO MAL FORMADO DE LOTE SIN EMBARCAR
                End If
            End If

            n_1 += 1

            If NparesAtadoActualLeeidos > NparesAtadoActual Then
                If n_1 = NparesAtadoActualLeeidos Then
                    cont = 0
                End If
            Else
                If n_1 = NparesAtadoActual Then
                    cont = 0
                End If
            End If
        Next

        'VALIDAMOS SI YA ESTA COMPLETO ALGUNO DE LOS LOTES
        ValidarLotes_Y_Atados_LeeidosCompletamente(loteAtadoActual, AñoAtadoActual)
        LlenarEtiquetas()

    End Sub


#Region "RECUPERAR INFORMACION DE SALIDA EN PROCESO"

    ''' <summary>
    ''' VALIDA QUE NO EXISTAN SALIDAS DE NAVE PENDIENTES
    ''' </summary>
    ''' <remarks>VALIDADO</remarks>
    Public Sub ValidarSalidasPendientes()
        Dim objBU As New Negocios.SalidaNavesBU
        Dim dtPermitir_Continuar As New DataTable

        w = 1
        Do While w = 1
            Try
                dtPermitir_Continuar = objBU.ValidarSalidasPendientes(IdNave)
                w = 0
            Catch ex As Exception
                If ex.Message.Contains(" interbloqueo ") = False Then
                    w = 0
                End If
                EscribirErrorEnBiacora(ex.Message, "ValidarSalidasPendientes")
            End Try
        Loop

        If dtPermitir_Continuar.Rows.Count > 0 Then
            For Each row As DataRow In dtPermitir_Continuar.Rows
                IdSalidaNave = row.Item("Id_SalidaNave")
                IdNave = row.Item("Nave")
                IdOperador = row.Item("Operador")
            Next
            salida_pendiente = True
        Else
            salida_pendiente = False
        End If
    End Sub


    ''' <summary>
    ''' LA INFORMACION QUE HABIA SIDO LEEIDA EN UNA SALIDA DE NAVE QUE NO FUE CONCLUIDA
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub RecuperarInformacionSalidaEnProceso()
        cmbNaves.SelectedValue = IdNave
        cmbNaves.Enabled = False

        cmbOperador.SelectedValue = IdOperador
        cmbOperador.Enabled = False

        'RECUPERAMOS LOS TOTALES PARA AGREGARLOS A LAS ETIQUETAS DE TOTALES
        recuperarTotalesParesLeeidos_Bien_Mal()

        'COLOREAMOS EL GRID LECTURA
        colorear_grid(grdLectura, 0)
        colorear_grid(grdIncorrecto, 0)
        'ValidarLotes_Y_Atados_LeeidosCompletamente()
        LlenarEtiquetas()
    End Sub


    ''' <summary>
    ''' RECUPERA LA INFORMACION QUE HABIA SIDO LEEIDA EN UNA SALIDA DE NAVE QUE NO FUE CONCLUIDA PARA MOSTRAR LA INFORMACION RECUPERADA EN LOS GRIDS Y LAS ETIQUETAS DE LA INTERFAZ
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub recuperarTotalesParesLeeidos_Bien_Mal()
        Dim objBU As New Negocios.SalidaNavesBU
        Dim dtTabla As New DataTable

        objBU.EliminarErroresDeLaLectura(IdNave, IdSalidaNave, LTrim(RTrim(cmbProceso.Text)))

        w = 1
        Do While w = 1
            Try
                dtTabla = objBU.RecuperaParesDeSalidaNaveEnProceso(IdSalidaNave, IdNave)
                w = 0
            Catch ex As Exception
                If ex.Message.Contains(" interbloqueo ") = False Then
                    w = 0
                End If
                EscribirErrorEnBiacora(ex.Message, "recuperarTotalesParesLeeidos_Bien_Mal(),  objBU.RecuperaParesDeSalidaNaveEnProceso")
            End Try
        Loop

        Dim resultado_Agregar_HS As Boolean = False

        For Each row As DataRow In dtTabla.Rows
            DescripcionAtadoActual = row.Item("DESCRIPCION")

            AgregarAtadosDelLoteAlGridErrores(CStr(row.Item("LOTE")), (row.Item("AÑO")), (row.Item("IDNAVE")))

            lAtados.Add(CStr(row.Item("LOTE")) + "-" + CStr(row.Item("AÑO")) + "-" + IdNave.ToString + "-" + CStr(row.Item("ATADO")))
            lpares.Add(CStr(row.Item("ATADO")) + "-" + CStr(row.Item("PAR")) + "-" + CStr(row.Item("N_PAR")))

            'AGREGAMOS LOS PARS A SU LISTA CORRESPONDIENTE, YA SEA PARA PARES ERRONOS O PARES CORRECTOS
            If (row.Item("R_PAR")) > 1 Then
                lparesErroneos.Add(CStr(row.Item("ATADO")) + "-" + CStr(row.Item("PAR")) + "-" + CStr(row.Item("N_PAR")))
                lparesBien.Remove(CStr(row.Item("ATADO")) + "-" + CStr(row.Item("PAR")) + "-" + CStr(row.Item("N_PAR")))
            Else
                lparesBien.Add(CStr(row.Item("ATADO")) + "-" + CStr(row.Item("PAR")) + "-" + CStr(row.Item("N_PAR")))
                lparesErroneos.Remove(CStr(row.Item("ATADO")) + "-" + CStr(row.Item("PAR")) + "-" + CStr(row.Item("N_PAR")))
            End If

            'AGREGAMOS LOS ATADOS A SUS RESPECTIVAS LISTAS, YA SEAN ATADOS CORRECTOS O ATADOS ERRONEOS
            If IsDBNull(row.Item("R_ATADO")) Then
                lAtadosErroneos.Add(CStr(row.Item("LOTE")) + "-" + CStr(row.Item("AÑO")) + "-" + CStr(row.Item("IDNAVE")) + "-" + CStr(row.Item("ATADO")))
                lAtadosBien.Remove(CStr(row.Item("LOTE")) + "-" + CStr(row.Item("AÑO")) + "-" + CStr(row.Item("IDNAVE")) + "-" + CStr(row.Item("ATADO")))
                'SÍ UN ATADO ESTA DESCARTADO TAMBIEN SU LOTE LO ESTARA
                lLotesErroneos.Add(CStr(row.Item("LOTE")) + "-" + CStr(row.Item("AÑO")) + "-" + CStr(row.Item("IDNAVE")))
                lLotesDescartados.Add(CStr(row.Item("LOTE")) + "-" + CStr(row.Item("AÑO")) + "-" + CStr(row.Item("IDNAVE")))
            ElseIf row.Item("R_ATADO") > 1 Then
                lAtadosErroneos.Add(CStr(row.Item("LOTE")) + "-" + CStr(row.Item("AÑO")) + "-" + CStr(row.Item("IDNAVE")) + "-" + CStr(row.Item("ATADO")))
                lAtadosBien.Remove(CStr(row.Item("LOTE")) + "-" + CStr(row.Item("AÑO")) + "-" + CStr(row.Item("IDNAVE")) + "-" + CStr(row.Item("ATADO")))
                'SÍ UN ATADO ESTA DESCARTADO TAMBIEN SU LOTE LO ESTARA
                lLotesErroneos.Add(CStr(row.Item("LOTE")) + "-" + CStr(row.Item("AÑO")) + "-" + CStr(row.Item("IDNAVE")))
                lLotesDescartados.Add(CStr(row.Item("LOTE")) + "-" + CStr(row.Item("AÑO")) + "-" + CStr(row.Item("IDNAVE")))
            Else
                lAtadosBien.Add(CStr(row.Item("LOTE")) + "-" + CStr(row.Item("AÑO")) + "-" + CStr(row.Item("IDNAVE")) + "-" + CStr(row.Item("ATADO")))
                lAtadosErroneos.Remove(CStr(row.Item("LOTE")) + "-" + CStr(row.Item("AÑO")) + "-" + CStr(row.Item("IDNAVE")) + "-" + CStr(row.Item("ATADO")))
            End If

            PoblarGridLectura(CInt(row.Item("LOTE")), CInt(row.Item("N_ATADO")), CStr(row.Item("ATADO")), CStr(row.Item("PAR")), CStr(row.Item("DESCRIPCION")), CStr(row.Item("TALLA")), CStr(row.Item("R_ATADO")), row.Item("AÑO"))
        Next

        'AHORA RECUPERAMOS LOS ATADOS ESCANEADOS Y SU ESTADO PARA ACTUALIZAR LA TABLA ERRORES
        Dim dtTabla2 As New DataTable

        w = 1
        Do While w = 1
            Try
                dtTabla2 = objBU.RecuperarResultadosDeAtadosLeeidosEnProduccionSalidaNAves(IdSalidaNave, IdNave)
                w = 0
            Catch ex As Exception
                If ex.Message.Contains(" interbloqueo ") = False Then
                    w = 0
                End If
                EscribirErrorEnBiacora(ex.Message, "recuperarTotalesParesLeeidos_Bien_Mal(), objBU.RecuperarResultadosDeAtadosLeeidosEnProduccionSalidaNAves")
            End Try
        Loop

        For Each row In dtTabla2.Rows
            If row.item("RESULTADO") > 1 Then
                'POBLAMOS EL GRID ERRONEOS
                poblarGrigErroneos(row.item("LOTE"), row.item("#"), row.item("ATADO"), row.item("DESCRIPCION"), row.item("RESULTADO"), row.item("AÑO"))
            Else
                For cont = grdIncorrecto.Rows.Count - 1 To 0 Step -1
                    If grdIncorrecto.Rows(cont).Cells("Atado").Text = row.item("ATADO") Then
                        grdIncorrecto.Rows(cont).Delete(True)
                    End If
                Next
            End If
        Next

        'FINALMENTE VERIFICAMOS SU UN LOTE HA SIDO ESCANEADO POR COMPLETO.
        For Each item In llotes
            If item.EndsWith("-DESCARTADO") Then

            Else
                Dim q As Integer = 0
                For Each row As UltraGridRow In grdIncorrecto.Rows
                    If item.StartsWith(row.Cells("LOTE").Text) Then
                        q += 1
                    End If
                Next

                If q = 0 Then
                    lLotesErroneos.Remove(item)
                    lLotesDescartados.Remove(item)
                    ResultadoHashSet_add = llotesBien.Add(item)

                    If ResultadoHashSet_add = True Then
                        Dim dtpares As New DataTable
                        Dim codigosplit As String()
                        codigosplit = item.Split("-")

                        w = 1
                        Do While w = 1
                            Try
                                dtpares = objBU.RecuperarPares_De_Lote(codigosplit(0), codigosplit(1), codigosplit(2))
                                w = 0
                            Catch ex As Exception
                                If ex.Message.Contains(" interbloqueo ") = False Then
                                    w = 0
                                End If
                                EscribirErrorEnBiacora(ex.Message, "recuperarTotalesParesLeeidos_Bien_Mal(), objBU.RecuperarPares_De_Lote")
                            End Try
                        Loop

                        For Each row As DataRow In dtpares.Rows
                            lLotesEmbarcados.Add(item)
                            lAtadosEmbarcados.Add(item + "-" + row.Item(1))
                            lparesEmbarcados.Add(item + "-" + row.Item(1) + "-" + row.Item(0))

                            lLotesDescartados.Remove(item)
                            lAtadosDescartados.Remove(item + "-" + row.Item(1))
                            lparesDescartados.Remove(item + "-" + row.Item(1) + "-" + row.Item(0))
                        Next
                    End If
                End If
            End If
        Next

    End Sub


    ''' <summary>
    ''' VERIFICA SI EN EL GRID ERRONEOS YA NO EXISTE ALGUN CODIGO DE LOTE QUE EXISTIO EN ALGUN MOMENTO, ESTO INDICARIOA QUE ESTA COMPLETO Y LO AGREGARIA A LA LISTA DE LOTES CORRECTOS
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ValidarLotes_Y_Atados_LeeidosCompletamente(ByVal lote As Integer, ByVal año As Integer)
        Dim lIncorrectos As New HashSet(Of String)
        Dim objBU As New Negocios.SalidaNavesBU
        Dim dtTabla As New DataTable
        Dim dtpares As New DataTable
        Dim codigosplit As String()

        If llotesNoEmbarcados.Contains(lote.ToString + "-" + año.ToString() + "-" + IdNave.ToString) Then Return

        If Tipo_Nave_Maquila_o_Interna = False Then
            If llotesSinTerminar.Contains(lote.ToString + "-" + año.ToString() + "-" + IdNave.ToString) Then Return
        End If

        If grdIncorrecto.Rows.Count = 0 Then
            For Each Miembro In llotes
                If Miembro.EndsWith("-DESCARTADO") = False Then
                    If llotesNoEmbarcados.Contains(Miembro) = False And llotesSinTerminar.Contains(Miembro) = False Then
                        Dim r_HASH_1 As Boolean = False

                        llotesBien.Add(Miembro)
                        r_HASH_1 = lLotesEmbarcados.Add(Miembro)
                        lLotesDescartados.Remove(Miembro)
                        lLotesErroneos.Remove(Miembro)
                        If r_HASH_1 = True Then
                            codigosplit = Miembro.Split("-")
                            w = 1
                            Do While w = 1
                                Try
                                    dtpares = objBU.RecuperarPares_De_Lote(codigosplit(0), codigosplit(1), codigosplit(2))
                                    w = 0
                                Catch ex As Exception
                                    If ex.Message.Contains(" interbloqueo ") = False Then
                                        w = 0
                                    End If
                                    EscribirErrorEnBiacora(ex.Message, " Metodo: ValidarLotes_Y_Atados_LeeidosCompletamente,  objBU.RecuperarPares_De_Lote")
                                End Try
                            Loop

                            For Each row As DataRow In dtpares.Rows
                                lAtadosEmbarcados.Add(Miembro + "-" + row.Item(1))
                                lparesEmbarcados.Add(Miembro + "-" + row.Item(1) + "-" + row.Item(0))

                                lAtadosDescartados.Remove(Miembro + "-" + row.Item(1))
                                lparesDescartados.Remove(Miembro + "-" + row.Item(1) + "-" + row.Item(0))
                                lAtadosErroneos.Remove(Miembro + "-" + row.Item(1))
                                'PrintLine(grdLectura.Rows.Count)
                            Next
                            If Proceso = "ENTRADA" Then
                                Dim objBUEntrada As New Negocios.EntradaProductoBU

                                w = 1
                                While w = 1
                                    Try
                                        'ACTUALIZAMOS EL ESTADO DE LOS PARES, ENTREGADO = 1, REGRESADO = 0
                                        objBUEntrada.Actualizar_Estado_De_Pares_Del_Lote_A_Entregado(IdSalidaNave, codigosplit(0), codigosplit(1), Tipo_Nave_Maquila_o_Interna, IdNave)
                                        w = 0
                                    Catch ex As Exception
                                        If ex.Message.Contains(" interbloqueo ") = False Then
                                            w = 0
                                        End If
                                        EscribirErrorEnBiacora(ex.Message, " Metodo: ValidarLotes_Y_Atados_LeeidosCompletamente, objBUEntrada.Actualizar_Estado_De_Pares_Del_Lote_A_Entregado - 1")
                                    End Try
                                End While
                            End If
                        End If
                    End If
                End If
            Next
        Else
            Dim q As Integer = 0
            For Each item In llotes
                If llotesNoEmbarcados.Contains(item) = False And llotesSinTerminar.Contains(item) = False Then
                    If item.EndsWith("-DESCARTADO") = False Then
                        q = 0

                        For Each row_grid As UltraGridRow In grdIncorrecto.Rows
                            If item.StartsWith(row_grid.Cells("LOTE").Text) Then
                                q += 1
                            End If
                        Next

                        If q = 0 Then
                            lLotesErroneos.Remove(item)
                            lLotesDescartados.Remove(item)

                            ResultadoHashSet_add = llotesBien.Add(item)
                            If ResultadoHashSet_add = True Then
                                lLotesEmbarcados.Add(item)
                                codigosplit = item.Split("-")

                                w = 1
                                Do While w = 1
                                    Try
                                        dtpares = objBU.RecuperarPares_De_Lote(codigosplit(0), codigosplit(1), codigosplit(2))
                                        w = 0
                                    Catch ex As Exception
                                        If ex.Message.Contains(" interbloqueo ") = False Then
                                            w = 0
                                        End If
                                        EscribirErrorEnBiacora(ex.Message, " Metodo: ValidarLotes_Y_Atados_LeeidosCompletamente, objBU.RecuperarPares_De_Lote")
                                    End Try
                                Loop

                                For Each row As DataRow In dtpares.Rows
                                    lLotesEmbarcados.Add(item)
                                    lAtadosEmbarcados.Add(item + "-" + row.Item(1))
                                    lparesEmbarcados.Add(item + "-" + row.Item(1) + "-" + row.Item(0))

                                    lLotesDescartados.Remove(item)
                                    lAtadosDescartados.Remove(item + "-" + row.Item(1))
                                    lparesDescartados.Remove(item + "-" + row.Item(1) + "-" + row.Item(0))
                                Next
                                If Proceso = "ENTRADA" Then
                                    Dim objBUEntrada As New Negocios.EntradaProductoBU

                                    w = 1
                                    Do While w = 1
                                        Try
                                            'ACTUALIZAMOS EL ESTADO DE LOS PARES, ENTREGADO = 1, REGRESADO = 0
                                            objBUEntrada.Actualizar_Estado_De_Pares_Del_Lote_A_Entregado(IdSalidaNave, codigosplit(0), codigosplit(1), Tipo_Nave_Maquila_o_Interna, IdNave)
                                            w = 0
                                        Catch ex As Exception
                                            If ex.Message.Contains(" interbloqueo ") = False Then
                                                w = 0
                                            End If
                                            EscribirErrorEnBiacora(ex.Message, " Metodo: ValidarLotes_Y_Atados_LeeidosCompletamente,objBUEntrada.Actualizar_Estado_De_Pares_Del_Lote_A_Entregado - 2")
                                        End Try
                                    Loop
                                End If
                            End If
                        End If
                    End If
                End If
            Next
        End If
    End Sub
#End Region


    ''' <summary>
    ''' METODO PARA VERIFICAR SI EL CODIGO LEEIDO PERTENECE A UN PAR VALIDO EN LA TABLA TMPDOCENASPARES
    ''' </summary>
    ''' <param name="codigo">CODIGO DEL POSIBLE PAR  A VERIFICAR</param>
    ''' <remarks></remarks>
    Public Sub verificar_par(ByVal codigo As String)
        par_valido = False
        Dim codigo_split = LTrim(RTrim(codigo)).Split("-") ''parte la cadena
        If codigo_split.Length = 3 Then
            If codigo_split(2).Length >= 10 And codigo_split(2).Length <= 13 Then ''verifica que la extension del codigo conincida con la extension del codigo de pares
                Dim objBU As New Negocios.SalidaNavesBU

                w = 1
                Do While w = 1
                    Try
                        If objBU.Consulta_Par_tmpDocenasPares(codigo_split(2)) Then
                            par_valido = True
                            CodigoPar = codigo_split(2)
                        End If
                        w = 0
                    Catch ex As Exception
                        If ex.Message.Contains(" interbloqueo ") = False Then
                            w = 0
                        End If
                        EscribirErrorEnBiacora(ex.Message, "verificar_par()")
                    End Try
                Loop
            End If
        Else
            par_valido = False
        End If
    End Sub


    ''' <summary>
    ''' EJECUTA EL PROCEDIMIENTO ALMACENADO EN EL QUE SE ACTUALIZARA EL ESTADO DEL PAR PERTENECIENTE AL ATADO QUE SE ESTA VALIDIDANDO, EN CASO DE NO 
    ''' PERTENECER SE GREGARA EL PAR AL ATADO COMO SOBRANTE, Y RECUPERA UNA TABLA CON LOS DATOS .
    ''' </summary>
    ''' <param name="cadena">CODIGO DEL PAR A ACTUALIZAR</param>
    ''' <param name="Talla">TALLA DEL PAR A ACTUALIZAR(PUEDE QUE VENGA VACIA ESTA VARIABLE)</param>
    ''' <remarks></remarks>
    Private Sub ActualizarEstatusPar(ByVal cadena As String, ByVal Talla As String, ByVal IdNave As Integer, ByVal NumeroPar As Integer, _
                                     ByVal TipoEscaneo As Boolean, ByVal IdProducto As String, ByVal Descripcion As String, ByVal Tipo_NAve As Boolean)
        Dim objBU As New SalidaNavesBU

        w = 1
        Do While w = 1
            Try
                dtTalla_DescripcionParAgregado = objBU.ActualizarEstatusPar(cadena, AtadoActual, IdSalidaNave, AñoAtadoActual, loteAtadoActual, IdNave, Talla, NumeroPar, _
                                                                        TipoEscaneo, IdProducto, Descripcion, Proceso, Tipo_NAve, IdCarritoActual)
                w = 0
            Catch ex As Exception
                If ex.Message.Contains(" interbloqueo ") = False Then
                    w = 0
                End If
                EscribirErrorEnBiacora(ex.Message, " ActualizarEstatusPar()")
            End Try
        Loop

        'AGREGAMOS LA TALLA Y LA DESCRIPCION DEL PAR ACTUALIZADO A LAS VARIABLE CORRESPONDIENTES
        For Each row As DataRow In dtTalla_DescripcionParAgregado.Rows
            TallaParActual = row.Item(0)
            DescripcionParActual = row.Item(2)
            Numero_Par = row.Item(3)
        Next

    End Sub


    ''' <summary>
    ''' AGREGA LOS PARES DEL ATADO ACTUAL A LA TABLA PRODUCCION.SALIDANAVESDETALLES
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub AgregarParesAtadoActual(ByVal TipoCodigo As String)
        Dim objBU As New Negocios.SalidaNavesBU
        Dim LoteTerminado As Boolean

        If ResultadoLoteCompleto = "COMPLETO" Then
            LoteTerminado = True
        Else
            LoteTerminado = False
        End If

        w = 1
        Do While w = 1
            Try
                objBU.AgregarParesAtadoActual(Atado_Incluido_SalidaNave_en_Curso, IdSalidaNave, AtadoActual, loteAtadoActual, AñoAtadoActual, IdNave,
                                              NumAtadoActual, LecturaParXPar, Proceso, TipoCodigo, Tipo_Nave_Maquila_o_Interna, IdCarritoActual, LoteTerminado)
                w = 0
            Catch ex As Exception
                If ex.Message.Contains(" interbloqueo ") = False Then
                    w = 0
                End If
                EscribirErrorEnBiacora(ex.Message, "AgregarParesAtadoActual()")
            End Try
        Loop

    End Sub


    ''' <summary>
    ''' RECUPERA UNA TABLA CON LOS CODIGOS DE ATADO PERTENECIENTES A UN LOTE NO TERMINADO
    ''' </summary>
    ''' <param name="Lote">LOTE DEL CUALS E RECUPERARAN LOS CODIGOS DE ATADO</param>
    ''' <returns>DATATABLE CON LA INFORMACION DE LOS CODIGOS DE ATADO</returns>
    ''' <remarks></remarks>
    Public Function RecuperarAtados_de_LoteIncompleto(ByVal Lote As Integer, ByVal Año As Integer)
        Dim objBU As New Negocios.SalidaNavesBU
        Dim dtTabla As New DataTable

        dtTabla = objBU.RecuperarAtados_de_LoteIncompleto(Lote, Año, IdNave)
        Return dtTabla
    End Function


    ''' <summary>
    ''' AGREGA UN LOTE AL HASHSET LLOTES, EN CASO DE QUE EL LOTE NO EXISTIERA EN EL HASH SET AGREGA LOS ATADOS DEL LOTE AL GRID ERRONEOS DE LO CONTRAIO NO REALIZA
    ''' NINGUNA ACCION, AL FINAL VALIDA SI EL TIPO DE LECTURA SERA PAR X PAR O SI LA LECTURA SERA POR ATADOS
    ''' </summary>
    ''' <param name="Lote">LOTE A VERIFICAR Y DEL CUAL SE AGREGARAN LOS ATADOS AL GRID ERRONEO EN CASO DE NO EXISTIR EN LA LISTA</param>
    ''' <param name="Año">AÑO DEL LOTE A VALIDAR</param>
    ''' <param name="Id_Nave">iD DE LA NAVE A LA QUE PERTENECE EL LOTE</param>
    ''' <remarks></remarks>
    Public Sub AgregarAtadosDelLoteAlGridErrores(ByVal Lote As Integer, ByVal Año As Integer, ByVal Id_Nave As Integer)
        Dim objBU As New Negocios.SalidaNavesBU
        Dim LoteDescartado As Integer = 0

        'VALIDAMOS QUE EL HASH-SET NO CONTENGA EL LOTE QUE SE LE AGREGO
        ResultadoHashSet_add = llotes.Add(Lote.ToString + "-" + Año.ToString + "-" + IdNave.ToString)


        If ResultadoHashSet_add = True Then

            For cont = llotes.Count - 1 To 0 Step -1

                ''Sí el el lote del atado acual pertenece a un lote descartado, le quitara el estado de descartado para poderlo leer de nuevo
                If llotes(cont) = (Lote.ToString + "-" + Año.ToString + "-" + Id_Nave.ToString + "-DESCARTADO") Then
                    LoteDescartado += 1

                    llotes.Remove(Lote.ToString + "-" + Año.ToString + "-" + IdNave.ToString + "-DESCARTADO")

                    lLotesErroneos.Add(Lote.ToString + "-" + Año.ToString + "-" + IdNave.ToString)
                    llotesBien.Remove(Lote.ToString + "-" + Año.ToString + "-" + IdNave.ToString)
                    lLotesEmbarcados.Remove(Lote.ToString + "-" + Año.ToString + "-" + IdNave.ToString)

                    Dim dtpares As New DataTable

                    w = 1
                    Do While w = 1
                        Try
                            dtpares = objBU.RecuperarPares_De_Lote(Lote, Año, Id_Nave)
                            w = 0
                        Catch ex As Exception
                            If ex.Message.Contains(" interbloqueo ") = False Then
                                w = 0
                            End If
                            EscribirErrorEnBiacora(ex.Message, "AgregarAtadosDelLoteAlGridErrores() - objBU.RecuperarPares_De_Lote - 1")
                        End Try
                    Loop

                    For Each fila As DataRow In dtpares.Rows
                        lparesEmbarcados.Remove(Lote.ToString + "-" + Año.ToString + "-" + Id_Nave.ToString + "-" + fila.Item(1) + "-" + fila.Item(0))
                        lLotesEmbarcados.Remove(Lote.ToString + "-" + Año.ToString + "-" + Id_Nave.ToString)
                        lAtadosEmbarcados.Remove(Lote.ToString + "-" + Año.ToString + "-" + Id_Nave.ToString + "-" + fila.Item(1))

                        lparesDescartados.Add(Lote.ToString + "-" + Año.ToString + "-" + Id_Nave.ToString + "-" + fila.Item(1) + "-" + fila.Item(0))
                        lAtadosDescartados.Add(Lote.ToString + "-" + Año.ToString + "-" + Id_Nave.ToString + "-" + fila.Item(1))
                        lLotesDescartados.Add(Lote.ToString + "-" + Año.ToString + "-" + Id_Nave.ToString)
                    Next

                    LecturaParXPar = ValidarLecturaPar_por_Par(Lote, Año, Id_Nave)

                    For Each row As DataRow In dtTablaAtados.Rows
                        If row.Item("Lote") = Lote And row.Item("Año") = Año Then
                            poblarGrigErroneos(Lote, row.Item("#"), row.Item("Atado"), row.Item("Descripción"), estatusAtado, Año)
                        End If
                    Next

                    cont = 0
                End If
            Next
        End If

        '   SÍ EL LOTE NO PERTENECIA A LOS LOTES DESCARTADOS ANTERIORMENTE ENTONCES AGREGARA TODOS LOS ATADOS A LA TABLA ERRONEOS Y ACTUALIZARA 
        ''  LA ETIQUETA DE PARES DESCARTADOS Y LOTES DESCARTADOS
        If LoteDescartado = 0 Then

            If ResultadoHashSet_add = True Then 'SÍ EL LOTE ES NUEVO EN LA LECTURA

                lLotesErroneos.Add(Lote.ToString + "-" + Año.ToString + "-" + IdNave.ToString)
                llotesBien.Remove(Lote.ToString + "-" + Año.ToString + "-" + IdNave.ToString)
                lLotesEmbarcados.Remove(Lote.ToString + "-" + Año.ToString + "-" + IdNave.ToString)

                Dim dtpares As New DataTable

                w = 1
                Do While w = 1
                    Try
                        dtpares = objBU.RecuperarPares_De_Lote(Lote, Año, Id_Nave)
                        w = 0
                    Catch ex As Exception
                        If ex.Message.Contains(" interbloqueo ") = False Then
                            w = 0
                        End If
                        EscribirErrorEnBiacora(ex.Message, "AgregarAtadosDelLoteAlGridErrores() - objBU.RecuperarPares_De_Lote - 2")
                    End Try
                Loop

                Dim numero_Atado As Integer = 0


                For Each fila As DataRow In dtpares.Rows
                    lparesEmbarcados.Remove(Lote.ToString + "-" + Año.ToString + "-" + Id_Nave.ToString + "-" + fila.Item(1) + "-" + fila.Item(0))
                    lLotesEmbarcados.Remove(Lote.ToString + "-" + Año.ToString + "-" + Id_Nave.ToString)
                    lAtadosEmbarcados.Remove(Lote.ToString + "-" + Año.ToString + "-" + Id_Nave.ToString + "-" + fila.Item(1))

                    lparesDescartados.Add(Lote.ToString + "-" + Año.ToString + "-" + Id_Nave.ToString + "-" + fila.Item(1) + "-" + fila.Item(0))
                    lLotesDescartados.Add(Lote.ToString + "-" + Año.ToString + "-" + Id_Nave.ToString)

                    ResultadoHashSet_add = lAtadosDescartados.Add(Lote.ToString + "-" + Año.ToString + "-" + Id_Nave.ToString + "-" + fila.Item(1))

                    If ResultadoHashSet_add = True Then
                        numero_Atado += 1 'adecuación
                        poblarGrigErroneos(Lote, fila.Item(2), fila.Item(1).ToString, DescripcionAtadoActual, estatusAtado, Año) 'El cero es el estado
                        Poblar_Tabla_Erroneos(Lote, fila.Item(2), fila.Item(1).ToString, DescripcionAtadoActual, estatusAtado, Año)
                        lAtadosCorrespondientes.Add(Lote.ToString + "-" + Año.ToString + "-" + IdNave.ToString + "-" + CStr(fila.Item(1)))
                    End If
                Next
                'VERIFICAMOS SI ES NECESARIO LEER PAR POR PAR TODO EL LOTE
                LecturaParXPar = ValidarLecturaPar_por_Par(Lote, Año, Id_Nave)
            End If
        End If

        'VALDAMOS SI EL EL LOTE DEL ATADO ACTUAL SE ENCUENTRA EN LA LISTA DE LOTES PARA VALIDAR POR PAR POR PAR Y ASIGNAMOS EL VALOR CORRESPONDIENTE A
        'LA VARIABLE VALIDARÁRXPAR
        If lLotesParXPar.Contains(Lote.ToString + "-" + Año.ToString + "-" + IdNave.ToString) Then
            LecturaParXPar = True
        Else
            LecturaParXPar = False
        End If

    End Sub


    ''' <summary>
    ''' RECUPERA LA TALLA DE UN PAR EN ESPECIFICO
    ''' </summary>
    ''' <param name="Codigo">CODIGO DEL PAR A RECUPERAR LA TALLA</param>
    ''' <remarks></remarks>
    Public Sub RecuperarTalla_IdProducto_DescripcionPar(ByVal Codigo As String)
        Dim objBU As New Negocios.SalidaNavesBU
        Dim dtTallaDescripcion As New DataTable
        Dim talla As String

        w = 1
        Do While w = 1
            Try
                dtTallaDescripcion = objBU.RecuperarTalla(Codigo)
                w = 0
            Catch ex As Exception
                If ex.Message.Contains(" interbloqueo ") = False Then
                    w = 0
                End If
                EscribirErrorEnBiacora(ex.Message, "RecuperarTalla_IdProducto_DescripcionPar()")
            End Try
        Loop

        For Each row As DataRow In dtTallaDescripcion.Rows
            talla = row.Item(0)
            TallaParActual = row.Item(0)
            DescripcionParActual = row.Item(1)
            IdProductoParActual = row.Item(2)
        Next
    End Sub

    ''' <summary>
    ''' VALIDA SÍ EL CODIGO ESCANEADO ES EL CODIGO DE UN CLIENTE, SÍ ES EL CASO RECUPERA LA TALLA DEL CODIGO LEEIDO
    ''' </summary>
    ''' <param name="CodigoEscaneado">CODIGO ESCANEADO</param>
    ''' <returns>TALLA RECUPERADA DEL CODIGO ESCANEADO</returns>
    ''' <remarks></remarks>
    Public Function Validar_Codigo_De_Cliente(ByVal CodigoEscaneado As String, ByVal IdCodigos As String)
        Dim objBU As New Negocios.SalidaNavesBU
        Dim dtCodigoCliente As New DataTable
        Dim talla As String = String.Empty

        w = 1
        Do While w = 1
            Try
                talla = objBU.Validar_Codigo_De_Cliente(CodigoEscaneado, IdClienteAtadoActual, IdCodigos)
                w = 0
            Catch ex As Exception
                If ex.Message.Contains(" interbloqueo ") = False Then
                    w = 0
                End If
                EscribirErrorEnBiacora(ex.Message, "Validar_Codigo_De_Cliente()")
            End Try
        Loop

        Return talla
    End Function


    ''' <summary>
    ''' RECUPERA LOS CODIGOS DE PAR CON SU CODIGO DE CLIENTE(EN CASO DE QUE EL PRIMER CODIGO DE PAR ESCANEADO DE UN ATADO SEA CODIGO DE CLIENTE)
    ''' </summary>
    ''' <param name="IdAtado">ID DEL ATADO ACTUAL</param>
    ''' <remarks></remarks>
    Public Sub Recuperar_dtPares_Para_Escanea_CodClientes(ByVal IdAtado As String)
        Dim objBU As New Negocios.SalidaNavesBU

        w = 1
        Do While w = 1
            Try
                dtParesCodigoCliente = objBU.Recuperar_dtPares_Para_Escanea_CodClientes(IdAtado)
                w = 0
            Catch ex As Exception
                If ex.Message.Contains(" interbloqueo ") = False Then
                    w = 0
                End If
                EscribirErrorEnBiacora(ex.Message, "Recuperar_dtPares_Para_Escanea_CodClientes()")
            End Try
        Loop
    End Sub


    ''' <summary>
    ''' EVENTO LEAVE EN LA CAJA DE TEXTO TXTXCAPTURACODIGOS QUE HACE QUE LA CAJA DE TEXTO OBTENGA EL FOCO CADA VEZ QUE LO PIERDE SIEMPRE Y CUANDO
    ''' NO SE PRESIONE EL BOTÓN DETENER.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub txtcapturacodigos_Leave(sender As Object, e As EventArgs) Handles txtcapturacodigos.Leave
        If btnDetener.Focused = False Then
            txtcapturacodigos.Focus()
        End If
    End Sub

    ''' <summary>
    ''' HABILITA LOS CONTROLES NECESARIOS PARA USAR LA APLICACION AL DETENER EL PROCESO DE LECTURA, ADEMAS DE ACTUALIZAR EL ESTADO DEL ULTIMO
    ''' ATADO LEÍDO
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Proceso_Detener()
        btnIniciar.Enabled = True
        btnDetener.Enabled = False
        txtcapturacodigos.Enabled = False
        cmbOperador.Enabled = False
        cmbNaves.Enabled = False
        btnGuardar.Enabled = True
        btnSalir.Enabled = True
        btnDescartarLotes.Enabled = True
        btnImprimirReporte.Enabled = True


        'falta actualiar el estdo del atado n
        If AtadoActual <> "0" Then
            If NparesAtadoActualLeeidos > 0 Or LecturaParXPar = False Then
                ActualizarEstatusDeAtado()
            End If

            AtadoActual = "0"
            LlenarEtiquetas()
        End If

        ControlBox = True

        If lAtados.Count = 0 And llotes.Count = 0 And IdSalidaNave = 0 And lpares.Count = 0 Then
            cmbProceso.Enabled = True
            cmbNaves.Enabled = True
        End If
    End Sub


    ''' <summary>
    ''' EVENTO QUE EJECUTA EL METODO 'PROCESO_DETENER'
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnDetener_Click(sender As Object, e As EventArgs) Handles btnDetener.Click
        Proceso_Detener()
    End Sub

#Region "grids"

    ''' <summary>
    ''' AGREGA UN ATADO QUE HABIA SIDO LEEIDO ANTERIORMENTE COMO COREECTO AL GRID ERRORES
    ''' </summary>
    ''' <param name="Atado">ATADO A AGREGAR</param>
    ''' <param name="lote">LOTE DEL ATADO</param>
    ''' <param name="Año">AÑO DEL LOTE A AGREGAR</param>
    ''' <param name="descripcion">DESCRIPCION DEL ATADO</param>
    ''' <remarks></remarks>
    Public Sub AgregarAtadoCorrectoAlGridErrores(ByVal Atado As String, ByVal lote As Integer, ByVal Año As Integer, ByVal descripcion As String)
        Dim dtpares As New DataTable
        Dim objBU As New Negocios.SalidaNavesBU

        llotesBien.Remove(lote.ToString + "-" + Año.ToString + "-" + IdNave.ToString)
        lLotesErroneos.Add(lote.ToString + "-" + Año.ToString + "-" + IdNave.ToString)
        poblarGrigErroneos(lote, NumAtadoActual, Atado, descripcion, 2, Año)

        w = 1
        Do While w = 1
            Try
                dtpares = objBU.RecuperarPares_De_Lote(lote, Año, IdNave)
                w = 0
            Catch ex As Exception
                If ex.Message.Contains(" interbloqueo ") = False Then
                    w = 0
                End If
                EscribirErrorEnBiacora(ex.Message, "AgregarAtadoCorrectoAlGridErrores(), objBU.RecuperarPares_De_Lote")
            End Try
        Loop

        For Each row As DataRow In dtpares.Rows
            lLotesEmbarcados.Remove(lote.ToString + "-" + Año.ToString + "-" + IdNave.ToString)
            lAtadosEmbarcados.Remove(lote.ToString + "-" + Año.ToString + "-" + IdNave.ToString + "-" + row.Item(1))
            lparesEmbarcados.Remove(lote.ToString + "-" + Año.ToString + "-" + IdNave.ToString + "-" + row.Item(1) + "-" + row.Item(0))

            lLotesDescartados.Add(lote.ToString + "-" + Año.ToString + "-" + IdNave.ToString)
            lAtadosDescartados.Add(lote.ToString + "-" + Año.ToString + "-" + IdNave.ToString + "-" + row.Item(1))
            lparesDescartados.Add(lote.ToString + "-" + Año.ToString + "-" + IdNave.ToString + "-" + row.Item(1) + "-" + row.Item(0))
        Next
    End Sub


    ''' <summary>
    ''' AGREGA UNA FILA A LA TABLA DE ATADOS QUE SE DEBEN DE LEER PARA COMPLETAR LOS LOTES LEIDOS
    ''' </summary>
    ''' <param name="Lote">LOTE DEL ATADO A VERIFICAR</param>
    ''' <param name="Numero">NUMERO DE ATADO A VERIFICAR</param>
    ''' <param name="Atado">ATADO A VERIFICAR</param>
    ''' <param name="descripcion">DESCRIPCION DEL ATADO A VERIFICAR</param>
    ''' <param name="Estado">ESTADO DEL ATADO A ACTUALIZAR O AGREGAR</param>
    ''' <param name="año">AÑO DEL ATADO A VERIFICAR</param>
    ''' <remarks></remarks>
    Public Sub Poblar_Tabla_Erroneos(ByVal Lote As Integer, ByVal Numero As Int32, ByVal Atado As String, ByVal descripcion As String, ByVal Estado As Integer, ByVal año As Integer)

        If Proceso = "ENTRADA" Then
            Dim rowAtados As DataRow = dtTablaAtados_EntradaDeLotes.NewRow
            rowAtados("Lote") = Lote
            rowAtados("# En Lote") = Numero
            rowAtados("Atado") = Atado
            rowAtados("Descripción") = descripcion
            rowAtados("Año") = año
            rowAtados("Quitar") = False
            rowAtados("Estado") = 0
            dtTablaAtados_EntradaDeLotes.Rows.Add(rowAtados)
        Else
            Dim rowAtados As DataRow = dtTablaAtados.NewRow
            rowAtados("Lote") = Lote
            rowAtados("#") = Numero
            rowAtados("Atado") = Atado
            rowAtados("Descripción") = descripcion
            rowAtados("Año") = año
            dtTablaAtados.Rows.Add(rowAtados)
        End If

    End Sub


    ''' <summary>
    ''' ACTUALIZA EL ESTADO DEL ATADO EN EL GRID ERRORES, SI EL ESTADO ES 1 ELIMINA LA FILA, SI EL ATADO NO EXISTE EN EL GRID ERRORES LO AGREGA, Y AL FINAL ACTUALIZA LOS COLORE DE CADA FILA EN EL GRID
    ''' </summary>
    ''' <param name="Lote">LOTE DEL ATADO A VERIFICAR</param>
    ''' <param name="Numero">NUMERO DE ATADO A VERIFICAR</param>
    ''' <param name="Atado">ATADO A VERIFICAR</param>
    ''' <param name="descripcion">DESCRIPCION DEL ATADO A VERIFICAR</param>
    ''' <param name="Estado">ESTADO DEL ATADO A ACTUALIZAR O AGREGAR</param>
    ''' <param name="año">AÑO DEL ATADO A VERIFICAR</param>
    ''' <remarks></remarks>
    Public Sub poblarGrigErroneos(ByVal Lote As Integer, ByVal Numero As Int32, ByVal Atado As String, ByVal descripcion As String, ByVal Estado As Integer, ByVal año As Integer)
        Dim x As Integer = 0

        For Each rowExiste As UltraGridRow In grdIncorrecto.Rows
            If rowExiste.Cells("Atado").Text = Atado And Atado <> 0 Then
                x += 1
                rowExiste.Cells("Estado").Value = Estado
                If rowExiste.Cells("Estado").Text = 1 Then
                    rowExiste.Delete(True)
                End If
            End If
        Next

        If x = 0 Then
            Dim rowErrores As UltraGridRow = Me.grdIncorrecto.DisplayLayout.Bands(0).AddNew()
            rowErrores.Cells("Quitar").Value = False
            rowErrores.Cells("Lote").Value = Lote
            rowErrores.Cells("# En Lote").Value = Numero
            rowErrores.Cells("Atado").Value = Atado
            rowErrores.Cells("Descripción").Value = descripcion
            rowErrores.Cells("Estado").Value = Estado
            rowErrores.Cells("Año").Value = año
        End If
    End Sub


    ''' <summary>
    ''' ELIMINA LOS PARES DE UN ATADO ESCANEADO ANTERIORMENTE DEL GRID LECTURA, LOS ELIMINA DE LOS HASHSET LPARESBIEN, LPARES, LPARESERRONEOS Y LATADOSBIEN
    ''' </summary>
    ''' <param name="Atado">ATADO DE LOS PARES A BORRAR</param>
    ''' <param name="lote">LOTE DE LOS PARES A BORRAR</param>
    ''' <param name="año">AÑO DEL LOTE DE LOS PARES A BORRAR</param>
    ''' <remarks></remarks>
    Public Sub EliminarParesDeAtadoYaEscaneado(ByVal Atado As String, ByVal lote As Integer, ByVal año As Integer)
        Dim cont As Int32 = 0

        If lAtados.Contains(lote.ToString + "-" + año.ToString + "-" + IdNave.ToString + "-" + Atado) = True Then
            For cont = grdLectura.Rows.Count - 1 To 0 Step -1
                If grdLectura.Rows(cont).Cells("Atado").Text = Atado Then
                    grdLectura.Rows(cont).Delete(True)
                End If
            Next

            For contDos = lparesBien.Count - 1 To 0 Step -1
                If lparesBien(contDos).StartsWith(CStr(Atado)) Then
                    lparesBien.Remove(lparesBien(contDos))
                End If
            Next

            For contDos = lpares.Count - 1 To 0 Step -1
                If lpares(contDos).StartsWith(CStr(Atado)) Then
                    lpares.Remove(lpares(contDos))
                End If
            Next

            For contDos = lparesErroneos.Count - 1 To 0 Step -1
                If lparesErroneos(contDos).StartsWith(CStr(Atado)) Then
                    lparesErroneos.Remove(lparesErroneos(contDos))
                End If
            Next

            If lAtadosBien.Contains(CStr(lote) + "-" + CStr(año) + "-" + CStr(IdNave) + "-" + CStr(Atado)) Then
                lAtadosBien.Remove(CStr(lote) + "-" + CStr(año) + "-" + CStr(IdNave) + "-" + CStr(Atado))
                lAtadosErroneos.Add(CStr(lote) + "-" + CStr(año) + "-" + CStr(IdNave) + "-" + CStr(Atado))
            End If
        End If
    End Sub


    ''' <summary>
    ''' ELIMINA LOS PARES DE CIERTO ATADO DE LA TABLA PRODUCCION.SALIDANAVESDETALLES EN CASO DE QUE YA SE HUBIERAN AGREGADO PARES PARA ESE ATADO EN ESA TABLA
    ''' </summary>
    ''' <param name="Atado">CODIGO DE ATADO DEL CUAL VERIFICAREMOS SI EXISTEN PARES EN LA TABLA</param>
    ''' <remarks></remarks>
    Private Sub ELiminarParesAtadoYaEscaneadoTabla_ProduccionSalidaNacesDetalles(ByVal Atado As String)
        Dim objBU As New Negocios.SalidaNavesBU

        w = 1
        Do While w = 1
            Try
                objBU.ELiminarParesAtadoYaEscaneadoTabla_ProduccionSalidaNacesDetalles(Atado, IdSalidaNave, IdNave)
                w = 0
            Catch ex As Exception
                If ex.Message.Contains(" interbloqueo ") = False Then
                    w = 0
                End If
                EscribirErrorEnBiacora(ex.Message, "ELiminarParesAtadoYaEscaneadoTabla_ProduccionSalidaNacesDetalles()")
            End Try
        Loop
    End Sub


    ''' <summary>
    ''' AGREGA UNA FILA NUEVA AL GRIDLECTURA
    ''' </summary>
    ''' <param name="Lote">LOTE CON EL QUE SE ESTA TABAJANDP</param>
    ''' <param name="Numero">NUEMRO DE ATADO</param>
    ''' <param name="Atado">CODIGO ATADO</param>
    ''' <param name="Par">CODIGO PAR</param>
    ''' <param name="descripcion">DESCRIPCION</param>
    ''' <param name="Talla">TALLA DEL PAR</param>
    ''' <param name="Estado">ESTADO DEL PAR</param>
    ''' <remarks></remarks>
    Public Sub PoblarGridLectura(ByVal Lote As Integer, ByVal Numero As Integer, ByVal Atado As String, ByVal Par As String, ByVal descripcion As String, ByVal Talla As String, ByVal Estado As Integer, ByVal Año As Integer)
        Dim rowEscaneado As UltraGridRow = Me.grdLectura.DisplayLayout.Bands(0).AddNew()
        rowEscaneado.Cells("Atado").Value = Atado
        rowEscaneado.Cells("Lote").Value = Lote
        rowEscaneado.Cells("# En Lote").Value = Numero
        rowEscaneado.Cells("Atado").Value = Atado
        rowEscaneado.Cells("Par").Value = Par
        rowEscaneado.Cells("Descripción").Value = descripcion
        rowEscaneado.Cells("Talla").Value = Talla
        rowEscaneado.Cells("Estado").Value = Estado
        rowEscaneado.Cells("Año").Value = Año


        If Estado = 5 Or Estado = 7 Then
            rowEscaneado.CellAppearance.BackColor = Color.Chocolate
        ElseIf Estado = 10 Or Estado = 11 Then
            rowEscaneado.CellAppearance.BackColor = Color.Aqua
        Else
            rowEscaneado.CellAppearance.BackColor = Color.Khaki
        End If

        'actualizamos los indices de atados
        EnumerarIndicesDeAtados()
    End Sub


    ''' <summary>
    ''' ENUMERA (AGREGA O ACTUALIZA) LOS INDICES DE ATADOS E EL GRID LECTURA, ORDENADO ASCENDENTEMENTE
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub EnumerarIndicesDeAtados()
        Dim lAtados_Lectura As New HashSet(Of String)

        For cont2 = grdLectura.Rows.Count - 1 To 0 Step -1
            If grdLectura.Rows.Count = 1 Then
                grdLectura.Rows(cont2).Cells("#").Value = 1
                cont2 = 0
            Else
                If grdLectura.Rows(cont2).Cells("Atado").Text = grdLectura.Rows(cont2 - 1).Cells("Atado").Text Then
                    grdLectura.Rows(cont2).Cells("#").Value = grdLectura.Rows(cont2 - 1).Cells("#").Value
                    cont2 = 0
                Else
                    grdLectura.Rows(cont2).Cells("#").Value = grdLectura.Rows(cont2 - 1).Cells("#").Value + 1
                    cont2 = 0
                End If
            End If
        Next
    End Sub


    ''' <summary>
    ''' RECORRE FILA POR FILA EL UN CONTROL DEL TIPO ULTRAGRID PINTANDO LA FILA DE UN COLOR DETERMINADO DEPENDIENDO
    ''' DEL VALOR QUE TENGA EN EL CAMPO ESTADO
    ''' </summary>
    ''' <param name="grid"></param>
    ''' <remarks></remarks>
    Public Sub colorear_grid(ByVal grid As UltraGrid, ByVal N_Actualizaciones As Integer)

        If grid.Rows.Count = 0 Then Return

        Dim m As Integer = 0

        If N_Actualizaciones = 0 Then
            N_Actualizaciones = grid.Rows.Count
        End If


        For cont = grid.Rows.Count - 1 To 0 Step -1
            If grid.Rows(cont).Cells("Estado").Value = 1 Then
                grid.Rows(cont).CellAppearance.BackColor = Color.White
            ElseIf grid.Rows(cont).Cells("Estado").Value = 2 Then
                grid.Rows(cont).CellAppearance.BackColor = Color.Khaki '-------COLOR PAEA ATADO CON FALTANTE
            ElseIf grid.Rows(cont).Cells("Estado").Value = 4 Then
                grid.Rows(cont).CellAppearance.BackColor = Color.LightSalmon '-COLOR PARA ATADO MAL FORMADO
            ElseIf grid.Rows(cont).Cells("Estado").Value = 0 Then
                grid.Rows(cont).CellAppearance.BackColor = Color.Silver '-------COLOR PAEA ATADO NO LEIDO
            ElseIf grid.Rows(cont).Cells("Estado").Value = 5 Then
                grid.Rows(cont).CellAppearance.BackColor = Color.Orange '------COLOR PARA LOTE SIN TERMINAR
            ElseIf grid.Rows(cont).Cells("Estado").Value = 6 Then
                grid.Rows(cont).CellAppearance.BackColor = Color.Pink '--------COLOR APRA ATADO CORRECTO DE LOTE SIN TERMINAR
            ElseIf grid.Rows(cont).Cells("Estado").Value = 7 Then
                grid.Rows(cont).CellAppearance.BackColor = Color.Chocolate '---COLOR PARA ATADO CON FALTANTE DE LOTE SIN TERMINAR
            ElseIf grid.Rows(cont).Cells("Estado").Value = 8 Then
                grid.Rows(cont).CellAppearance.BackColor = Color.OrangeRed '---------COLOR PARA ATADO MAL FORMADO DE LOTE SIN TERMINAR
            ElseIf grid.Rows(cont).Cells("Estado").Value = 9 Then
                grid.Rows(cont).CellAppearance.BackColor = Color.SteelBlue  '------COLOR PARA LOTE NO EMBARCADO
            ElseIf grid.Rows(cont).Cells("Estado").Value = 10 Then
                grid.Rows(cont).CellAppearance.BackColor = Color.DodgerBlue '--------COLOR ATADO CORRECTO DE LOTE SIN EMBARCAR
            ElseIf grid.Rows(cont).Cells("Estado").Value = 11 Then
                grid.Rows(cont).CellAppearance.BackColor = Color.Aqua '---COLOR PARA ATADO CON FALTANTE DE LOTE SIN EMBARCAR
            ElseIf grid.Rows(cont).Cells("Estado").Value = 12 Then
                grid.Rows(cont).CellAppearance.BackColor = Color.CadetBlue '---------COLOR PARA ATADO MAL FORMADO DE LOTE SIN EMBARCAR
            End If

            m += 1

            If m = N_Actualizaciones Then
                cont = 0
            End If
        Next


    End Sub


    ''' <summary>
    ''' EVENTO INITIALIZE LAYOUT EN EL GRID GRDINCORRECTO EN EL CUAL SE LE DA FORMATO AL GRID Y COLOR A LAS FILAS DEPENDIENDE DEL VALOR EN LA COLUMNA ESTADO
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub grdIncorrecto_InitializeLayout_1(sender As Object, e As InitializeLayoutEventArgs) Handles grdIncorrecto.InitializeLayout
        With grdIncorrecto
            .DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
            .DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            .DisplayLayout.Override.RowSelectorWidth = 45

            .DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
            .DisplayLayout.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
            .DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True
            .DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
            .DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True

            '.DisplayLayout.Bands(0).Columns("#").Hidden = True
            .DisplayLayout.Bands(0).Columns("Estado").Hidden = True
            .DisplayLayout.Bands(0).Columns("Año").Hidden = True

            .DisplayLayout.Bands(0).Columns("# En lote").CellActivation = Activation.NoEdit
            .DisplayLayout.Bands(0).Columns("Descripción").CellActivation = Activation.NoEdit
            .DisplayLayout.Bands(0).Columns("Quitar").Style = ColumnStyle.CheckBox
            .DisplayLayout.Bands(0).Columns("Quitar").CellActivation = Activation.AllowEdit
            .DisplayLayout.Bands(0).Columns("Lote").CellActivation = Activation.NoEdit
            .DisplayLayout.Bands(0).Columns("Atado").CellActivation = Activation.NoEdit


            'grdIncorrecto.DisplayLayout.Bands(0).Columns("#").Width = 35
            grdIncorrecto.DisplayLayout.Bands(0).Columns("# En lote").Width = 45
            grdIncorrecto.DisplayLayout.Bands(0).Columns("Lote").Width = 40
            grdIncorrecto.DisplayLayout.Bands(0).Columns("Atado").Width = 80
            grdIncorrecto.DisplayLayout.Bands(0).Columns("Quitar").Width = 30
        End With


        For Each row As UltraGridRow In grdIncorrecto.Rows

            If row.Cells("Estado").Value = 1 Then
                row.CellAppearance.BackColor = Color.White
            ElseIf row.Cells("Estado").Value = 2 Then
                row.CellAppearance.BackColor = Color.Khaki '-------COLOR PAEA ATADO CON FALTANTE
            ElseIf row.Cells("Estado").Value = 4 Then
                row.CellAppearance.BackColor = Color.LightSalmon '-COLOR PARA ATADO MAL FORMADO
            ElseIf row.Cells("Estado").Value = 0 Then
                row.CellAppearance.BackColor = Color.Silver '-------COLOR PAEA ATADO NO LEIDO
            ElseIf row.Cells("Estado").Value = 5 Then
                row.CellAppearance.BackColor = Color.Orange '------COLOR PARA LOTE SIN TERMINAR
            ElseIf row.Cells("Estado").Value = 6 Then
                row.CellAppearance.BackColor = Color.Pink '--------COLOR APRA ATADO CORRECTO DE LOTE SIN TERMINAR
            ElseIf row.Cells("Estado").Value = 7 Then
                row.CellAppearance.BackColor = Color.Chocolate '---COLOR PARA ATADO CON FALTANTE DE LOTE SIN TERMINAR
            ElseIf row.Cells("Estado").Value = 8 Then
                row.CellAppearance.BackColor = Color.OrangeRed '---------COLOR PARA ATADO MAL FORMADO DE LOTE SIN TERMINAR
            ElseIf row.Cells("Estado").Value = 9 Then
                row.CellAppearance.BackColor = Color.SteelBlue  '------COLOR PARA LOTE NO EMBARCADO
            ElseIf row.Cells("Estado").Value = 10 Then
                row.CellAppearance.BackColor = Color.DodgerBlue '--------COLOR ATADO CORRECTO DE LOTE SIN EMBARCAR
            ElseIf row.Cells("Estado").Value = 11 Then
                row.CellAppearance.BackColor = Color.Aqua '---COLOR PARA ATADO CON FALTANTE DE LOTE SIN EMBARCAR
            ElseIf row.Cells("Estado").Value = 12 Then
                row.CellAppearance.BackColor = Color.CadetBlue '---------COLOR PARA ATADO MAL FORMADO DE LOTE SIN EMBARCAR
            ElseIf row.Cells("Estado").Value = 911 Then
                row.CellAppearance.BackColor = Color.MediumSlateBlue '---------COLOR PARA ATADO SIN PRECIO
            End If
        Next

    End Sub





    ''' <summary>
    ''' EVENTO INITIALIZE LAYOUT EN EL GRID GRDLECTURA EN EL CUAL SE LE DA FORMATO AL GRID Y COLOR A LAS FILAS DEPENDIENDE DEL VALOR EN LA COLUMNA ESTADO
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub grdLectura_InitializeLayout_1(sender As Object, e As InitializeLayoutEventArgs) Handles grdLectura.InitializeLayout
        With grdLectura

            .DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
            .DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            .DisplayLayout.Override.RowSelectorWidth = 45

            .DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
            .DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
            .DisplayLayout.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
            .DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
            .DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True

            .DisplayLayout.Bands(0).Columns("Estado").Hidden = True
            .DisplayLayout.Bands(0).Columns("#").CellActivation = Activation.NoEdit
            .DisplayLayout.Bands(0).Columns("Descripción").CellActivation = Activation.NoEdit
            .DisplayLayout.Bands(0).Columns("Talla").CellActivation = Activation.NoEdit
            .DisplayLayout.Bands(0).Columns("Lote").CellActivation = Activation.NoEdit
            .DisplayLayout.Bands(0).Columns("Par").CellActivation = Activation.NoEdit
            .DisplayLayout.Bands(0).Columns("Atado").CellActivation = Activation.NoEdit

            .DisplayLayout.Bands(0).Columns("#").Width = 35
            .DisplayLayout.Bands(0).Columns("# En lote").Width = 40
            .DisplayLayout.Bands(0).Columns("Lote").Width = 40
            .DisplayLayout.Bands(0).Columns("Talla").Width = 35
            .DisplayLayout.Bands(0).Columns("Par").Width = 85
            .DisplayLayout.Bands(0).Columns("Atado").Width = 80

        End With


        For Each row As UltraGridRow In grdLectura.Rows
            If row.Cells("Estado").Value = 1 Then
                row.CellAppearance.BackColor = Color.White
            ElseIf row.Cells("Estado").Value = 2 Then
                row.CellAppearance.BackColor = Color.Khaki '-------COLOR PAEA ATADO CON FALTANTE
            ElseIf row.Cells("Estado").Value = 4 Then
                row.CellAppearance.BackColor = Color.LightSalmon '-COLOR PARA ATADO MAL FORMADO
            ElseIf row.Cells("Estado").Value = 0 Then
                row.CellAppearance.BackColor = Color.Silver '-------COLOR PAEA ATADO NO LEIDO
            ElseIf row.Cells("Estado").Value = 5 Then
                row.CellAppearance.BackColor = Color.Orange '------COLOR PARA LOTE SIN TERMINAR
            ElseIf row.Cells("Estado").Value = 6 Then
                row.CellAppearance.BackColor = Color.Pink '--------COLOR APRA ATADO CORRECTO DE LOTE SIN TERMINAR
            ElseIf row.Cells("Estado").Value = 7 Then
                row.CellAppearance.BackColor = Color.Chocolate '---COLOR PARA ATADO CON FALTANTE DE LOTE SIN TERMINAR
            ElseIf row.Cells("Estado").Value = 8 Then
                row.CellAppearance.BackColor = Color.OrangeRed '---------COLOR PARA ATADO MAL FORMADO DE LOTE SIN TERMINAR
            ElseIf row.Cells("Estado").Value = 9 Then
                row.CellAppearance.BackColor = Color.SteelBlue  '------COLOR PARA LOTE NO EMBARCADO
            ElseIf row.Cells("Estado").Value = 10 Then
                row.CellAppearance.BackColor = Color.DodgerBlue '--------COLOR ATADO CORRECTO DE LOTE SIN EMBARCAR
            ElseIf row.Cells("Estado").Value = 11 Then
                row.CellAppearance.BackColor = Color.Aqua '---COLOR PARA ATADO CON FALTANTE DE LOTE SIN EMBARCAR
            ElseIf row.Cells("Estado").Value = 12 Then
                row.CellAppearance.BackColor = Color.CadetBlue '---------COLOR PARA ATADO MAL FORMADO DE LOTE SIN EMBARCAR
            End If
        Next

    End Sub


    ''' <summary>
    ''' AGREGA COLUMNAS AL GRID DE ERRORES
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub DarFormatoDataTable_para_grid_Erroneos()
        Dim ColumnaQuitar As New DataColumn("Quitar")
        ColumnaQuitar.DataType = GetType(Boolean)

        Dim ColumnaLote As New DataColumn("Lote")
        ColumnaLote.DataType = GetType(Integer)

        Dim ColumnaNumeroEnLote As New DataColumn("# En lote")
        ColumnaNumeroEnLote.DataType = GetType(Integer)

        Dim ColumnaAtado As New DataColumn("Atado")
        ColumnaAtado.DataType = GetType(String)

        Dim ColumnaDescripcion As New DataColumn("Descripción")
        ColumnaDescripcion.DataType = GetType(String)

        Dim ColumnaEstado As New DataColumn("Estado")
        ColumnaDescripcion.DataType = GetType(String)

        Dim ColumnaAño As New DataColumn("Año")
        ColumnaDescripcion.DataType = GetType(String)

        dtTablaGridErrores.Columns.Add(ColumnaQuitar)
        dtTablaGridErrores.Columns.Add(ColumnaLote)
        dtTablaGridErrores.Columns.Add(ColumnaNumeroEnLote)
        dtTablaGridErrores.Columns.Add(ColumnaAtado)
        dtTablaGridErrores.Columns.Add(ColumnaDescripcion)
        dtTablaGridErrores.Columns.Add(ColumnaEstado)
        dtTablaGridErrores.Columns.Add(ColumnaAño)

        grdIncorrecto.DataSource = Nothing
        grdIncorrecto.DataSource = dtTablaGridErrores
        grdIncorrecto.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdIncorrecto.DisplayLayout.Override.RowSelectorWidth = 35


        Dim ColLote As New DataColumn("Lote")
        ColumnaLote.DataType = GetType(Integer)
        Dim ColNumero As New DataColumn("#")
        ColNumero.DataType = GetType(Integer)
        Dim ColAtado As New DataColumn("Atado")
        ColumnaAtado.DataType = GetType(String)
        Dim ColDescripcion As New DataColumn("Descripción")
        ColumnaDescripcion.DataType = GetType(String)
        Dim ColAño As New DataColumn("Año")
        ColumnaDescripcion.DataType = GetType(String)

        dtTablaAtados.Columns.Add(ColLote)
        dtTablaAtados.Columns.Add(ColNumero)
        dtTablaAtados.Columns.Add(ColAtado)
        dtTablaAtados.Columns.Add(ColDescripcion)
        dtTablaAtados.Columns.Add(ColAño)

    End Sub


    ''' <summary>
    ''' AGREGA COLUMNAS AL GRID DE CODIGOS LEEIDOS
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub DarFormatoDataTable_para_grid_Escaneados()

        Dim ColumnaNumero As New DataColumn("#")
        ColumnaNumero.DataType = GetType(Integer)

        Dim ColumnaNumeroEnLote As New DataColumn("# En lote")
        ColumnaNumero.DataType = GetType(Integer)


        Dim ColumnaLote As New DataColumn("Lote")
        ColumnaLote.DataType = GetType(Integer)

        Dim ColumnaAtado As New DataColumn("Atado")
        ColumnaAtado.DataType = GetType(String)

        Dim ColumnaPar As New DataColumn("Par")
        ColumnaPar.DataType = GetType(String)

        Dim ColumnaDescripcion As New DataColumn("Descripción")
        ColumnaDescripcion.DataType = GetType(String)

        Dim ColumnaTalla As New DataColumn("Talla")
        ColumnaTalla.DataType = GetType(String)

        Dim ColumnaEstado As New DataColumn("Estado")
        ColumnaDescripcion.DataType = GetType(String)

        Dim ColumnaAño As New DataColumn("Año")
        ColumnaDescripcion.DataType = GetType(String)

        dtTablaGridCodigosParesEscaneados.Columns.Add(ColumnaNumero)
        dtTablaGridCodigosParesEscaneados.Columns.Add(ColumnaNumeroEnLote)
        dtTablaGridCodigosParesEscaneados.Columns.Add(ColumnaLote)
        dtTablaGridCodigosParesEscaneados.Columns.Add(ColumnaAtado)
        dtTablaGridCodigosParesEscaneados.Columns.Add(ColumnaPar)
        dtTablaGridCodigosParesEscaneados.Columns.Add(ColumnaDescripcion)
        dtTablaGridCodigosParesEscaneados.Columns.Add(ColumnaTalla)
        dtTablaGridCodigosParesEscaneados.Columns.Add(ColumnaEstado)
        dtTablaGridCodigosParesEscaneados.Columns.Add(ColumnaAño)

        grdLectura.DataSource = Nothing
        grdLectura.DataSource = dtTablaGridCodigosParesEscaneados
        grdLectura.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdLectura.DisplayLayout.Override.RowSelectorWidth = 45
    End Sub


#End Region


#Region "LIMPIAR HASH SETS"

    ''' <summary>
    ''' LIMPIA DE LA LISTA DE LPARES LOS PARES DL ATADO QUE ESTA POR SER ACTUALIZADO
    ''' </summary>
    ''' <param name="Atado">CODIGO DEL ATADO CON EL QUE SE COMPARARA</param>
    ''' <remarks></remarks>
    Public Sub Limpiar_HashSet_Pares(ByVal Atado As String)
        For cont = lpares.Count - 1 To 0 Step -1
            If lpares(cont).StartsWith(Atado + "-") Then
                lpares.Remove(lpares(cont))
            End If
        Next
    End Sub

#End Region


#Region "proceso de captura de codigo"

    ''' <summary>
    ''' ACTUALIZA ELTIPO DE CODIGO DE PAR DE CODIGO UNICO YUYIN A CODIGO DE CLIENTE CORRESPONDIENTE DE UN ATADO COMPLETO 
    ''' EN LA TABLA ALMACEN.SALIDANAVESDETALLES CUANDO 
    ''' </summary>
    ''' <param name="Id_Salida">ID DE LA SALIDA DE NAVE EN LA QUE SE ACTUALIZARA EL CODIGO DE PAR</param>
    ''' <param name="Atado">ATADO DEL CUAL SE ACTUALIZARAN LOS CODIGOS DE PAR</param>
    ''' <param name="dtPares">DATATABLE CON LOS CODIGOS DE CLIENTE CORRESPONDIENTES</param>
    ''' <remarks></remarks>
    Public Sub Actualizar_TiposDeCodigo_A_Codigos_Cliente_Cuando_En_La_Salida_No_Se_Valido_ParxPar(ByVal Id_Salida As Integer, ByVal Atado As String, ByVal dtPares As DataTable)
        Dim objBUEntrada As New Negocios.EntradaProductoBU
        w = 1
        Do While w = 1
            Try
                objBUEntrada.Actualizar_TiposDeCodigo_A_Codigos_Cliente_Cuando_En_La_Salida_No_Se_Valido_ParxPar(Id_Salida, Atado, dtPares, IdNave)
                w = 0
            Catch ex As Exception
                If ex.Message.Contains(" interbloqueo ") = False Then
                    w = 0
                End If
                EscribirErrorEnBiacora(ex.Message, " Actualizar_TiposDeCodigo_A_Codigos_Cliente_Cuando_En_La_Salida_No_Se_Valido_ParxPar()")
            End Try
        Loop
    End Sub


    ''' <summary>
    ''' REALIZA LAS VALIDACIONES NECESARIAS Y TRANSACCIONES PARA CUANDO SE LEE UN POSIBLE CODIGO DE CLIENTE
    ''' </summary>
    ''' <param name="Codigo_Escaneado">CODIGO ESCANEADO</param>
    ''' <remarks></remarks>
    Public Sub Proceso_Para_Codigo_De_Cliente_Capturado(ByVal Codigo_Escaneado As String)

        ' 'VALIDAMOS QUE SEA UN CODIGO DE CLIENTE VALIDO Y RECUPERAMOS LA TALLA
        If AtadoActual = 0 Then
            show_message("Alerta", "Escanea primero un código de atado para comenzar con el proceso de salida.")
            Return
        End If

        'RECUPERA LA TALLA DEL CODIGO CLIENTE, SÍ DEVUELVE UN VALOR NULO INDICA QUE EL CODIGO LEEIDO NO PERTENECE A UN CODIGO DE CLIENTE VALIDO
        Dim talla_Par_CodCLiente As String
        Dim IDcodigos As String = String.Empty
        If dtParesCodigoCliente.Rows.Count = 0 Then
            Recuperar_dtPares_Para_Escanea_CodClientes(AtadoActual)
            For Each row As DataRow In dtParesCodigoCliente.Rows
                If IDcodigos = "" Then
                    IDcodigos = "'" + row.Item("Id_Producto") + "'"
                Else
                    IDcodigos += ",'" + row.Item("Id_Producto") + "'"
                End If
            Next
            dtParesCodigoCliente.Clear()
        Else
            For Each row As DataRow In dtParesCodigoCliente.Rows
                If IDcodigos = "" Then
                    IDcodigos = "'" + row.Item("Id_Producto") + "'"
                Else
                    IDcodigos += ",'" + row.Item("Id_Producto") + "'"
                End If
            Next
        End If


        talla_Par_CodCLiente = Validar_Codigo_De_Cliente(LTrim(RTrim(Codigo_Escaneado)), IDcodigos)


        If talla_Par_CodCLiente = String.Empty Then 'EL CODIGO ESCANEADO NO ES VALIDO, AGREGAMOS EL CODIGO ESCANEADO A LA LISTA DE CODIGOS DE CLIENTES CON ERRORES
            ReproducrirSonidoError()
            lCodigosErroneos.Add("Código erroneo:" + LTrim(RTrim(Codigo_Escaneado)) + " * Atado actual: " + AtadoActual.ToString + "* Causa: Posible codigo cliente no valido")
        Else 'INDICA QUE EL CODIGO ES DE CLIENTE VALIDO 
            'SÍ AUN NO SE HA LEEIDO ALGUN PAR DE EL ATADO ACTUAL RECUPERA LOS PARES DE EL ATADO ACTUAL
            If NparesAtadoActualLeeidos = 0 Then
                NparesAtadoActualLeeidos += 1

                'INDICAMOS QUE EL TIPO DE ESCANEO SERA POR CODIGOS DE CLIENTE
                TipoEscaneoPar_CodInterno_CodCliente = False

                'RECUPERAMOS LOS PARES QUE DEBERIA DE CONTENER EL ATADO CON CODIGOS DE CLIENTE
                Recuperar_dtPares_Para_Escanea_CodClientes(AtadoActual)


                If TipoCodigo = "A" And Proceso = "ENTRADA" And Tipo_Nave_Maquila_o_Interna = False Then
                    Actualizar_TiposDeCodigo_A_Codigos_Cliente_Cuando_En_La_Salida_No_Se_Valido_ParxPar(IdSalidaNave, AtadoActual, dtParesCodigoCliente)
                ElseIf Tipo_Nave_Maquila_o_Interna = True Or Proceso = "SALIDA" Then
                    'AGREGAMOS LOS PARES DE CODIGO DE CLIENTE A LA TABLA SALIDANAVESDETALLES
                    If estatusAtado <> 911 Then
                        Agregar_Pares_CodigoCliente_SalidaNavesDetalles_AtadoActual("C")
                    End If
                End If

                'ACTUALIZAMOS EL ESTADO DE LA TALLA DEL PRIMER PAR ENCONTRADO 
                Actualizar_Par_Tabla_ParesConCodigoCliente(LTrim(RTrim(Codigo_Escaneado)), talla_Par_CodCLiente, "CLIENTE")

                LlenarEtiquetas()

            ElseIf NparesAtadoActualLeeidos > 0 And TipoEscaneoPar_CodInterno_CodCliente = False Then 'INDICA QUE EL TIPO DE ESCANEO DEL ATADO ES POR CODIGO DE CLIENTE 
                'Y QUE YA HAY PARES LEEIDOS
                NparesAtadoActualLeeidos = NparesAtadoActualLeeidos + 1

                Actualizar_Par_Tabla_ParesConCodigoCliente(LTrim(RTrim(Codigo_Escaneado)), talla_Par_CodCLiente, "CLIENTE")

                LlenarEtiquetas()

            ElseIf NparesAtadoActualLeeidos > 0 And TipoEscaneoPar_CodInterno_CodCliente = True Then ' INDICA QUE EL TIPO DE PARES DE ATADO TRAE CODIGOS DE CLIENTE 
                ' Y QUE YA HAY PARES AGREGADOS, ASI QUE AGREGAMOS EL CODIGO A LA TABLA PRODUCCION.SALIDANAVESDETALLES
                NparesAtadoActual += 1

                RecuperarDesripcionPar(CStr(Codigo_Escaneado))

                NparesAtadoActualLeeidos = NparesAtadoActualLeeidos + 1
                NparesAtadoActual = NparesAtadoActual + 1
                ActualizarEstatusPar(Codigo_Escaneado, talla_Par_CodCLiente, IdNave, 0, TipoEscaneoPar_CodInterno_CodCliente, IdProductoParActual, DescripcionParActual, Tipo_Nave_Maquila_o_Interna)

                ResultadoHashSet_add = lParesAtadoActual.Add(AtadoActual + "-" + Codigo_Escaneado)

                lpares.Add(CStr(AtadoActual) + "-" + CStr(Codigo_Escaneado) + "-" + NparesAtadoActual.ToString)
                'AGREGAR PAR AL GRID DE PARES LEEIDOS
                If ResultadoHashSet_add = True Then
                    PoblarGridLectura(loteAtadoActual, NumAtadoActual, AtadoActual, (Codigo_Escaneado), DescripcionAtadoActual, TallaParActual, 2, AñoAtadoActual)
                End If
                LlenarEtiquetas()
            End If
        End If

    End Sub


    ''' <summary>
    ''' VALIDA QUE EL LOTE ESCANEADO NO SE ENCUENTRE EN LA EL HASHSET DE LOTES ERRONEOS, SI NO SE ENCUENTRA RECUPERA SUS ATADOS Y SUS PARES Y LOS AGREGA A LAS LISTAS DE PARES Y ATADOS DESCARTADOS
    ''' </summary>
    ''' <param name="DAtosAtado">CLASE DE LA CAPA ENTIDADES CON LAS VARIABLES LLENAS DE INFORMACION DEL LOTE EN CUESTION</param>
    ''' <remarks></remarks>
    Public Sub Proceso_Para_Lote_Incompleto(ByVal DAtosAtado As Entidades.CapturaAtadoValido)

        llotesSinTerminar.Add(CStr(DAtosAtado.PLote) + "-" + CStr(DAtosAtado.PAño) + "-" + IdNave.ToString)

        If Proceso = "SALIDA" Then

            If AtadoActual <> "0" Then
                ActualizarEstatusDeAtado()
            End If

            AtadoActual = "0"

            'AGREGAMOS EL LOTE DESCARTADO A LA LISTA DE LOTES ERRONOES Y LA DE LOTES DESCARTADOS
            lLotesErroneos.Add(CStr(DAtosAtado.PLote) + "-" + CStr(DAtosAtado.PAño) + "-" + IdNave.ToString)
            lLotesDescartados.Add(CStr(DAtosAtado.PLote) + "-" + CStr(DAtosAtado.PAño) + "-" + IdNave.ToString)
            llotes.Add(CStr(DAtosAtado.PLote) + "-" + CStr(DAtosAtado.PAño) + "-" + IdNave.ToString)
            llotesBien.Remove(CStr(DAtosAtado.PLote) + "-" + CStr(DAtosAtado.PAño) + "-" + IdNave.ToString)

            Dim r_1 As Integer = 0
            For Each row_grid As UltraGridRow In grdIncorrecto.Rows
                If row_grid.Cells("Lote").Text = DAtosAtado.PLote And row_grid.Cells("Año").Text = DAtosAtado.PAño Then
                    r_1 += 1
                End If
            Next

            If r_1 = 0 Then
                poblarGrigErroneos(DAtosAtado.PLote, 0, 0, DAtosAtado.PDescripcion, 5, DAtosAtado.PAño)

                Dim objBU As New Negocios.SalidaNavesBU
                Dim dtpares As New DataTable

                w = 1
                Do While w = 1
                    Try
                        dtpares = objBU.RecuperarPares_De_Lote(DAtosAtado.PLote, DAtosAtado.PAño, IdNave)
                        w = 0
                    Catch ex As Exception
                        If ex.Message.Contains(" interbloqueo ") = False Then
                            w = 0
                        End If
                        EscribirErrorEnBiacora(ex.Message, "Proceso_Para_Lote_Incompleto(), objBU.RecuperarPares_De_Lote")
                    End Try
                Loop

                For Each row As DataRow In dtpares.Rows
                    lLotesEmbarcados.Remove(DAtosAtado.PLote.ToString + "-" + DAtosAtado.PAño.ToString + "-" + IdNave.ToString)
                    lAtadosEmbarcados.Remove(DAtosAtado.PLote.ToString + "-" + DAtosAtado.PAño.ToString + "-" + IdNave.ToString + "-" + row.Item("ID_Docena"))
                    lparesEmbarcados.Remove(DAtosAtado.PLote.ToString + "-" + DAtosAtado.PAño.ToString + "-" + IdNave.ToString + "-" + row.Item("ID_Par"))

                    lLotesDescartados.Add(DAtosAtado.PLote.ToString + "-" + DAtosAtado.PAño.ToString + "-" + IdNave.ToString)
                    lAtadosDescartados.Add(DAtosAtado.PLote.ToString + "-" + DAtosAtado.PAño.ToString + "-" + IdNave.ToString + "-" + row.Item("ID_Docena"))
                    lparesDescartados.Add(DAtosAtado.PLote.ToString + "-" + DAtosAtado.PAño.ToString + "-" + IdNave.ToString + "-" + row.Item("ID_Par"))
                Next

                AtadoActual = "0"
            End If

        Else
            If Tipo_Nave_Maquila_o_Interna = False Then
                'AGREGAMOS LOS ATADOS DEL LOTE AL GRID COMO INCOMPLETOS
                AgregarAtadosDelLoteAlGridErrores_Entrada_Naves(DAtosAtado.PLote, DAtosAtado.PAño, IdNave)

                'ACTUALIZAMOS EL ATADO CON EL QUE SE ESTARA TRABAJANDO
                AtadoActual = DAtosAtado.PIdAtado
                AñoAtadoActual = DAtosAtado.PAño
                loteAtadoActual = DAtosAtado.PLote
                IdClienteAtadoActual = DAtosAtado.PIdCliente
                NparesAtadoActual = DAtosAtado.PN_Pares
                NparesAtadoActualLeeidos = 0
                DescripcionAtadoActual = DAtosAtado.PDescripcion

                'ELIMINAMOS LOS PARES SOBRANTES DEL ATADO EN CASO DE HABER SIDO ANTERIORMENTE Y ACRUALIZAMOS EL ESTATUS DE LOS PARES DE ESTE ATADO A NULLO
                Reiniciar_Atado_Escaneado_Anteriormente_Entrada_De_Lotes()

                'AGREGAMOS EL ATADO A LA LISTA DE ATADOS LEEIDOS
                lAtados.Add(loteAtadoActual.ToString + "-" + AñoAtadoActual.ToString + "-" + IdNave.ToString + "-" + AtadoActual.ToString)

                lParesAtadoActual.Clear()
                NumAtadoActual = 0

                For Each ROW As UltraGridRow In grdIncorrecto.Rows
                    If ROW.Cells("Atado").Text = DAtosAtado.PIdAtado Then
                        NumAtadoActual = ROW.Cells("# En Lote").Text
                    End If
                Next

                If NumAtadoActual = 0 Then
                    For Each row As DataRow In dtTablaAtados_EntradaDeLotes.Rows
                        If row.Item("Atado") = AtadoActual Then
                            'Dim lote_Atados_Escaneados_Anterior_Mente_Y_Descartados As Integer
                            NumAtadoActual = row.Item("#")
                            AgregarAtadoCorrectoAlGridErrores(AtadoActual, loteAtadoActual, AñoAtadoActual, DescripcionAtadoActual)

                            If lLotesDescartados.Contains(loteAtadoActual.ToString + "-" + AñoAtadoActual.ToString + "-" + IdNave.ToString + "-DESCARTADO") Then
                                For Each fila As DataRow In dtTablaAtados_EntradaDeLotes.Rows
                                    If fila.Item("Año") = fila.Item("Año") And fila.Item("Lote") = loteAtadoActual Then
                                        poblarGrigErroneos(loteAtadoActual, row.Item("#"), row.Item("Atado"), row.Item("Descripción"), 0, row.Item("Año"))
                                    End If
                                Next
                            End If
                        End If
                    Next
                End If


                'AGREGAMOS EL LOTE A LA LISTA DE LOTES CON ERRORES LEEIDOS YA QUE NO ESTA COMPLETO
                lLotesErroneos.Add(loteAtadoActual.ToString + "-" + AñoAtadoActual.ToString + "-" + IdNave.ToString)
                lLotesDescartados.Add(loteAtadoActual.ToString + "-" + AñoAtadoActual.ToString + "-" + IdNave.ToString)


                'ELIMINAMOS LOS PARES DEL ATADO EN EL GRID LECTURA EN CASO DE YA HABER SIDO ESCANEADO 
                EliminarParesDeAtadoYaEscaneado(AtadoActual, loteAtadoActual, AñoAtadoActual)

                'AHORA VERIFICAMOS SI EL TIPO DE LECTUA ES DE PAR POR PAR O SOLO POR ATADO
                Verificar_Atado_Leido_VS_TipoLecturaParOAtado(AtadoActual)
            End If
        End If

        'LIMPIAMOS LA TABLA DE LOS PARES CON CODIGOS DE CLIENTE
        dtParesCodigoCliente.Clear()

        'LLENAMOS ETIQUETAS
        LlenarEtiquetas()

    End Sub


    ''' <summary>
    ''' VALIDA SI EL ATADO ESCANEADO DEBE SER PAR POR PAR O SOLO EL CODIGO DE ATADO, EN CASO DE SE POR CODIGO DE ATADO AGREGA
    ''' LOS PARES DEL ATADO AL GRID LECTURA Y AGREGA LOS PARES DEL ATADO A LAS LISTAS DE PARES BIEN, Y ATADOS BIEN
    ''' </summary>
    ''' <param name="Atado"></param>
    ''' <remarks></remarks>
    Private Sub Verificar_Atado_Leido_VS_TipoLecturaParOAtado(ByVal Atado As String)
        If LecturaParXPar = True Then Return

        If Proceso = "SALIDA" Then
            'INDICAMOS QUE EL TIPO DE ESCANEO SEA POR CLIENTE PARA QUE AL MOMENTO DE ACTUALIZAR EL ESTATUS DEL ATADO NO CONSULTE EN LA BASE DE DATOS
            TipoEscaneoPar_CodInterno_CodCliente = False
            TipoCodigo = "A"

            If estatusAtado <> 911 Then
                AgregarParesAtadoActual(TipoCodigo)
                Atado_Incluido_SalidaNave_en_Curso = True
                Recuperar_dtPares_Para_Escanea_CodClientes(Atado)
            End If

            For Each row As DataRow In dtParesCodigoCliente.Rows
                row.Item("Estado") = 1

                If IsDBNull(row.Item("Descripcion")) Then

                    If estatusAtado <> 911 Then
                        PoblarGridLectura(loteAtadoActual, NumAtadoActual, row.Item("ATADO"), row.Item("PAR"), DescripcionAtadoActual, row.Item("TALLA"), 1, AñoAtadoActual)
                        lpares.Add(CStr(row.Item("ATADO")) + "-" + CStr(row.Item("PAR")) + "-" + CStr(row.Item("#")))
                        lparesErroneos.Remove(CStr(row.Item("ATADO")) + "-" + CStr(row.Item("PAR")) + "-" + CStr(row.Item("#")))
                        lparesBien.Add(CStr(row.Item("ATADO")) + "-" + CStr(row.Item("PAR")) + "-" + CStr(row.Item("#")))
                    End If

                Else
                    If IsDBNull(row.Item("CODIGO_CLIENTE")) Then
                        If estatusAtado <> 911 Then
                            PoblarGridLectura(loteAtadoActual, NumAtadoActual, row.Item("ATADO"), row.Item("PAR"), row.Item("Descripcion"), row.Item("TALLA"), 1, AñoAtadoActual)
                            lpares.Add(CStr(row.Item("ATADO")) + "-" + CStr(row.Item("PAR")) + "-" + CStr(row.Item("#")))
                            lparesBien.Add(CStr(row.Item("ATADO")) + "-" + CStr(row.Item("PAR")) + "-" + CStr(row.Item("#")))
                            lparesErroneos.Remove(CStr(row.Item("ATADO")) + "-" + CStr(row.Item("PAR")) + "-" + CStr(row.Item("#")))
                        End If
                    Else
                        If estatusAtado <> 911 Then
                            PoblarGridLectura(loteAtadoActual, NumAtadoActual, row.Item("ATADO"), row.Item("PAR"), row.Item("Descripcion"), row.Item("TALLA"), 1, AñoAtadoActual)
                            lpares.Add(CStr(row.Item("ATADO")) + "-" + CStr(row.Item("PAR")) + "-" + CStr(row.Item("#")))
                            lparesBien.Add(CStr(row.Item("ATADO")) + "-" + CStr(row.Item("PAR")) + "-" + CStr(row.Item("#")))
                            lparesErroneos.Remove(CStr(row.Item("ATADO")) + "-" + CStr(row.Item("PAR")) + "-" + CStr(row.Item("#")))
                        End If
                    End If
                End If
            Next
        Else
            'INDICAMOS QUE EL TIPO DE ESCANEO SEA POR CLIENTE PARA QUE AL MOMENTO DE ACTUALIZAR EL ESTATUS DEL ATADO NO CONSULTE EN LA BASE DE DATOS
            TipoEscaneoPar_CodInterno_CodCliente = False

            TipoCodigo = "U"

            If Atado_Incluido_SalidaNave_en_Curso = True Then
                Recuperar_dtPares_Para_de_tabla_SalidaNavesDetalles(Atado)
            Else
                Recuperar_dtPares_Para_Escanea_CodClientes(Atado)
            End If


            For Each row As DataRow In dtParesCodigoCliente.Rows
                row.Item("Estado") = 1

                If IsDBNull(row.Item("Descripcion")) Then
                    If ResultadoLoteCompleto = "COMPLETO" Then
                        If llotesNoEmbarcados.Contains(loteAtadoActual.ToString + "-" + AñoAtadoActual.ToString + "-" + IdNave.ToString) Then
                            PoblarGridLectura(loteAtadoActual, NumAtadoActual, row.Item("ATADO"), row.Item("PAR"), DescripcionAtadoActual, row.Item("TALLA"), 10, AñoAtadoActual)
                        Else
                            PoblarGridLectura(loteAtadoActual, NumAtadoActual, row.Item("ATADO"), row.Item("PAR"), DescripcionAtadoActual, row.Item("TALLA"), 1, AñoAtadoActual)
                        End If
                    Else
                        PoblarGridLectura(loteAtadoActual, NumAtadoActual, row.Item("ATADO"), row.Item("PAR"), DescripcionAtadoActual, row.Item("TALLA"), 7, AñoAtadoActual)
                    End If

                    lpares.Add(CStr(row.Item("ATADO")) + "-" + CStr(row.Item("PAR")) + "-" + CStr(row.Item("#")))
                    lparesErroneos.Remove(CStr(row.Item("ATADO")) + "-" + CStr(row.Item("PAR")) + "-" + CStr(row.Item("#")))
                    lparesBien.Add(CStr(row.Item("ATADO")) + "-" + CStr(row.Item("PAR")) + "-" + CStr(row.Item("#")))
                Else
                    If ResultadoLoteCompleto = "COMPLETO" Then
                        If llotesNoEmbarcados.Contains(loteAtadoActual.ToString + "-" + AñoAtadoActual.ToString + "-" + IdNave.ToString) Then
                            If estatusAtado <> 911 Then
                                PoblarGridLectura(loteAtadoActual, NumAtadoActual, row.Item("ATADO"), row.Item("PAR"), DescripcionAtadoActual, row.Item("TALLA"), 10, AñoAtadoActual)
                            End If
                        Else
                            If estatusAtado <> 911 Then
                                PoblarGridLectura(loteAtadoActual, NumAtadoActual, row.Item("ATADO"), row.Item("PAR"), DescripcionAtadoActual, row.Item("TALLA"), 1, AñoAtadoActual)
                            End If

                        End If
                    Else
                        If estatusAtado <> 911 Then
                            PoblarGridLectura(loteAtadoActual, NumAtadoActual, row.Item("ATADO"), row.Item("PAR"), DescripcionAtadoActual, row.Item("TALLA"), 7, AñoAtadoActual)
                        End If

                    End If
                    If IsDBNull(row.Item("CODIGO_CLIENTE")) Then
                        lpares.Add(CStr(row.Item("ATADO")) + "-" + CStr(row.Item("PAR")) + "-" + CStr(row.Item("#")))
                        lparesBien.Add(CStr(row.Item("ATADO")) + "-" + CStr(row.Item("PAR")) + "-" + CStr(row.Item("#")))
                        lparesErroneos.Remove(CStr(row.Item("ATADO")) + "-" + CStr(row.Item("PAR")) + "-" + CStr(row.Item("#")))
                    Else
                        lpares.Add(CStr(row.Item("ATADO")) + "-" + CStr(row.Item("CODIGO_CLIENTE")) + "-" + CStr(row.Item("#")))
                        lparesBien.Add(CStr(row.Item("ATADO")) + "-" + CStr(row.Item("CODIGO_CLIENTE")) + "-" + CStr(row.Item("#")))
                        lparesErroneos.Remove(CStr(row.Item("ATADO")) + "-" + CStr(row.Item("CODIGO_CLIENTE")) + "-" + CStr(row.Item("#")))
                    End If
                End If
            Next
        End If
    End Sub


    ''' <summary>
    ''' ACTUALIZA EL ESTATUS DEL ATADO EN CASO DE EXISTIR UN ATADO ESCANEADO ANTERIORMENTE, LLENA LA LISTA DE ATADOS, ELIMINA PARES DEL ATADO DEL GRID LECTURA EN CASO DE YA HABER SIDO ESCANEADO ANTERIORMENTE
    ''' </summary>
    ''' <param name="datosatado">CLASE DE LA CAPA ENTIDADES CON LAS VARIABLES LLENAS DE INFORMACION DEL LOTE EN CUESTION</param>
    ''' <remarks></remarks>
    Public Sub Proceso_Para_Lote_completo(ByVal datosatado As Entidades.CapturaAtadoValido)
        Dim objBU As New SalidaNavesBU
        If externa Then
            precio = objBU.VerificarAtadoValido_RecuperaPrecioLote(datosatado.PLote, datosatado.PAño, datosatado.PIdNAve)
            If precio > 0 Then
                estatusAtado = 0 'Estatus indica que el proceso puede seguir normal cuenta con precio
            Else
                estatusAtado = 911 'Estatus indica que no tiene precio el lote 
            End If
        End If

        'ACTUALIZAMOS EL ESTATUS DE LOS PARES Y DE EL ATADO CON EL QUE SE ESTUBO TRABAJANDO
        If AtadoActual <> "0" Then
            ActualizarEstatusDeAtado()
        End If

        If lAtados.Contains(datosatado.PLote.ToString + "-" + datosatado.PAño.ToString + "-" + IdNave.ToString + "-" + datosatado.PIdAtado) = True Then
            EliminarParesDeAtadoYaEscaneado(datosatado.PIdAtado, datosatado.PLote, datosatado.PAño)
            If Proceso = "SALIDA" Then
                'ELIMINAMOS LOS PARES DE LA TABLA ALMACEN.SALIDANAVESDETALLES
                ELiminarParesAtadoYaEscaneadoTabla_ProduccionSalidaNacesDetalles(datosatado.PIdAtado)
            End If
        End If

        'LIMPIAMOS LA TABLA DE LOS PARES CON CODIGOS DE CLIENTE
        dtParesCodigoCliente.Clear()

        'ACTUALIZAMOS EL ATADO CON EL QUE SE ESTARA TRABAJANDO
        AtadoActual = datosatado.PIdAtado
        AñoAtadoActual = datosatado.PAño
        loteAtadoActual = datosatado.PLote
        IdClienteAtadoActual = datosatado.PIdCliente
        NparesAtadoActual = datosatado.PN_Pares
        NparesAtadoActualLeeidos = 0
        DescripcionAtadoActual = datosatado.PDescripcion
        NumAtadoActual = datosatado.PN_AtadoEscaneado

        'AGREGAMOS LOS ATADOS DEL LOTE AL GRID COMO INCOMPLETOS
        Try
            AgregarAtadosDelLoteAlGridErrores(datosatado.PLote, datosatado.PAño, IdNave)
        Catch ex As Exception
            EscribirErrorEnBiacora(ex.Message, "AgregarAtadosDelLoteAlGridErrores() - Gral. Salida")
        End Try


        'AGREGAMOS EL ATADO A LA LISTA DE ATADOS LEEIDOS
        lAtados.Add(loteAtadoActual.ToString + "-" + AñoAtadoActual.ToString + "-" + IdNave.ToString + "-" + AtadoActual.ToString)

        lParesAtadoActual.Clear()
        'NumAtadoActual = 0

        n = 0
        For cont = grdIncorrecto.Rows.Count - 1 To 0 Step -1
            If grdIncorrecto.Rows(cont).Cells("# En lote").Text = NumAtadoActual Then
                NumAtadoActual = grdIncorrecto.Rows(cont).Cells("# en lote").Text
                n += 1
                cont = 0
            End If
        Next

        If n = 0 Then
            AgregarAtadoCorrectoAlGridErrores(AtadoActual, loteAtadoActual, AñoAtadoActual, DescripcionAtadoActual)
        End If

        'AGREGAMOS EL LOTE A LA LISTA DE LOTES CON ERRORES LEEIDOS YA QUE NO ESTA COMPLETO
        lLotesErroneos.Add(loteAtadoActual.ToString + "-" + AñoAtadoActual.ToString + "-" + IdNave.ToString)
        lLotesDescartados.Add(loteAtadoActual.ToString + "-" + AñoAtadoActual.ToString + "-" + IdNave.ToString)

        'AHORA VERIFICAMOS SI EL TIPO DE LECTUA ES DE PAR POR PAR O SOLO POR ATADO
        Verificar_Atado_Leido_VS_TipoLecturaParOAtado(AtadoActual)

        'LLENAMOS ETIQUETAS
        LlenarEtiquetas()

    End Sub


    ''' <summary>
    ''' REALIZA LA ACTUALIZACION DEL PAR EN LA TABLA SALIDANAVESDETALLES DEPENDIENDO DEL TIPO DE ESCANEO ASIGNADO PARA EL ATADO Y EL TIPO DE CODIGO DE PAR LEÍDO
    ''' </summary>
    ''' <param name="Cadena"></param>
    ''' <remarks></remarks>
    Public Sub Proceso_Para_Par_Codigo_Empresa_Valido(ByVal Cadena As String)
        Dim codigo_split = LTrim(RTrim(Cadena)).Split("-")

        If NparesAtadoActualLeeidos = 0 Or TipoEscaneoPar_CodInterno_CodCliente = True Then
            If NparesAtadoActualLeeidos = 0 Then
                TipoEscaneoPar_CodInterno_CodCliente = True
                TipoCodigo = "U"

                If Proceso = "SALIDA" Then
                    If estatusAtado <> 911 Then
                        AgregarParesAtadoActual(TipoCodigo)
                    End If

                End If
            End If

            NparesAtadoActualLeeidos = NparesAtadoActualLeeidos + 1

            RecuperarDescripcionCodigoParEmpresa(codigo_split(2))

            'ACTUALIZA EL ESTATUS DEL PAR EN CASO DE EXISTIR Y LO AGREGA EN CASO DE SER SOBRANTE, Y RECUPERA LA TALLA Y LA DESCRIPCION DEL PAR EN CUESTION
            ActualizarEstatusPar(codigo_split(2), TallaParActual, IdNave, 0, TipoEscaneoPar_CodInterno_CodCliente, IdProductoParActual, DescripcionParActual, Tipo_Nave_Maquila_o_Interna)

            ResultadoHashSet_add = lParesAtadoActual.Add(CStr(AtadoActual) + "-" + CStr(codigo_split(2)))
            lpares.Add(CStr(AtadoActual) + "-" + CStr(codigo_split(2)) + "-" + Numero_Par.ToString)
            'AGREGAR PAR AL GRID DE PARES LEEIDOS
            If ResultadoHashSet_add = True Then
                If llotesSinTerminar.Contains(loteAtadoActual.ToString + "-" + AñoAtadoActual.ToString + "-" + IdNave.ToString) Then
                    PoblarGridLectura(loteAtadoActual, NumAtadoActual, AtadoActual, (codigo_split(2)), DescripcionParActual, TallaParActual, 7, AñoAtadoActual)
                Else
                    If llotesNoEmbarcados.Contains(loteAtadoActual.ToString + "-" + AñoAtadoActual.ToString + "-" + IdNave.ToString) Then
                        PoblarGridLectura(loteAtadoActual, NumAtadoActual, AtadoActual, (codigo_split(2)), DescripcionParActual, TallaParActual, 11, AñoAtadoActual)
                    Else
                        PoblarGridLectura(loteAtadoActual, NumAtadoActual, AtadoActual, (codigo_split(2)), DescripcionParActual, TallaParActual, 2, AñoAtadoActual)
                    End If
                End If
            End If

            LlenarEtiquetas()
        ElseIf TipoEscaneoPar_CodInterno_CodCliente = False And NparesAtadoActualLeeidos > 0 Then
            NparesAtadoActualLeeidos = NparesAtadoActualLeeidos + 1
            RecuperarTalla_IdProducto_DescripcionPar(codigo_split(2))

            'ACTUALIZAMOS LA LISTA DE PAR DE CODIGOCLIENTE
            Actualizar_Par_Tabla_ParesConCodigoCliente(LTrim(RTrim(codigo_split(2))), TallaParActual, "EMPRESA")
        End If
    End Sub


#Region "VERIFICAR SI HAY QUE VALIDAR PAR POR PAR"

    ''' <summary>
    ''' FUNCION QUE RECUPERA LOS ID DE CLIENTES QUE HAY QUE VALIDAR PAR POR PAR PERTENECIENTES A LA NAVE CON LA QUE SE ESTA TRABJANDO
    ''' </summary>
    ''' <param name="Id_Nave"> ID DE LA NACE CON LA QUE SE ESTA TRABAJANDO</param>
    ''' <returns>LISTA DEL TIPO STRING CON LOS ID DE LOS CLIENTES QUE HABRIA QUE VALIDAR PAR POR PAR</returns>
    ''' <remarks></remarks>
    Public Function RecuperarClientesParaValidacionParxPar(ByVal Id_Nave As Integer)
        Dim objBU As New Negocios.SalidaNavesBU
        Dim lListas As New List(Of String)

        w = 1
        Do While w = 1
            Try
                lListas = objBU.RecuperarClientesParaValidacionParxPar(Id_Nave, Proceso)
                w = 0
            Catch ex As Exception
                If ex.Message.Contains(" interbloqueo ") = False Then
                    w = 0
                End If
                EscribirErrorEnBiacora(ex.Message, "RecuperarClientesParaValidacionParxPar()")
            End Try
        Loop

        Return lListas

    End Function


    ''' <summary>
    ''' RECUPERA UNA LISTA CON LOS  IDS DE CLIENTES A LOS QUE SE LE HAN ASIGNADO LOS ATADOS PERTENECIENTES AL LOTE CON EL QUE SE ESTA TRABAJANDO
    ''' </summary>
    ''' <param name="Lote"> LOTE CON EL QUE SE ESTA TRABAJANDO</param>
    ''' <param name="Año"> AÑO CON EL QUE SE ESTA TRABAJANDO</param>
    ''' <param name="Id_Nave"> ID DE LA NAVE CON LA QUE SE ESTA TRABAJANDO</param>
    ''' <returns>LISTA CON LOS IDS DE CLIENTES </returns>
    ''' <remarks></remarks>
    Public Function RecuperarClientesIncluidos_En_El_Lote(ByVal Lote As Integer, ByVal Año As Integer, ByVal Id_Nave As Integer)
        Dim objBU As New Negocios.SalidaNavesBU
        Dim lListas As New List(Of String)

        w = 1
        Do While w = 1
            Try
                lListas = objBU.RecuperarClientesIncluidos_En_El_Lote(Lote, Año, Id_Nave)
                w = 0
            Catch ex As Exception
                If ex.Message.Contains(" interbloqueo ") = False Then
                    w = 0
                End If
                EscribirErrorEnBiacora(ex.Message, "RecuperarClientesIncluidos_En_El_Lote()")
            End Try
        Loop

        Return lListas
    End Function


    ''' <summary>
    ''' RECUPERA LA LISTA DE LOS CLIENTE QUE HAY QUE VALIDAR PAR POR PAR, LA LISTA DE LOC CLIENTE PERTENECIENTES AL LOTE CON EL QUE SE TRABAJA,
    '''  Y DEPENDIENDO DE ESTAS REGRESA UN VALOR DEL TIPO BOOLEANO CON EL RESULTADO DEL TIPO DE LECTURA QUE SE DEBE DE REALIZAR
    ''' </summary>
    ''' <param name="Lote">LOTE CON EL QUE SE ESTA TRABAJANDO</param>
    ''' <param name="Año">AÑO CON EL QUE SE ESTA TRABAJANDO</param>
    ''' <param name="Id_Nave">ID DE LA NAVE CON LA QUE SE ESTA TRABAJANDO</param>
    ''' <returns>VALOR DEL TIPO BOLEANO, TRUE PARA LECTURA PAR POR PAR, FALSE PARA LECTURA POR ATADOS</returns>
    ''' <remarks></remarks>
    Private Function ValidarLecturaPar_por_Par(ByVal Lote As Integer, ByVal Año As Integer, ByVal Id_Nave As Integer) As Boolean
        Dim n_validacion As Integer = 0
        lClientesValidacionParXPar_Lote.Clear()

        'RECUPERAMOS LOS CLIENTES A LOS QUE SE LE ASIGNARON LOS ATADOS PERTENECIENTES AL LOTE EN CUESTION
        lClientesValidacionParXPar_Lote = RecuperarClientesIncluidos_En_El_Lote(Lote, Año, Id_Nave)

        'AHORA VALIDAMOS QUE LOS CLIENTES DE LA NAVE QUE HAY QUE VALIDAR COINCIDAN CON ALGUNO DE LOS CLIENTES QUE ESTAN INCLUIDOS EN EL LOTES
        For Each item In lClientesValidacionParXPar_Nave
            For Each elemento In lClientesValidacionParXPar_Lote
                If item = elemento Then
                    n_validacion = n_validacion + 1
                End If
            Next
        Next

        If n_validacion > 0 Then
            lLotesParXPar.Add(Lote.ToString + "-" + Año.ToString + "-" + Id_Nave.ToString)
            Return True
        Else
            Return False
        End If
    End Function

#End Region

    ''' <summary>
    ''' REPRODUCE UN SONIDO, EN ESTE CASO EL SONIDO DE ERRORES
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ReproducrirSonidoError()
        Dim player As New SoundPlayer(My.Resources.beep_04)
        player.Play()
    End Sub


    ''' <summary>
    ''' VERIFICA SI EL CODIGO LEEIDO ES DE UN PAR CON COD DE YUYIN O CON CODIGO DEL CLIENTE, Ó SEA DE UN ATADO VALIDO PARA REALIZAR LA ACICON ESPECIFICA PARA CADA TIPO DE CODIGO
    ''' </summary>
    ''' <param name="Cadena">CODIGO LEEIDO A VERIFICAR</param>
    ''' <remarks></remarks>
    Public Sub CapturaParAtadosYuyin(ByVal Cadena As String)

        Dim codigo_split = LTrim(RTrim(Cadena)).Split("-") ''parte la cadena
        ResultadoLoteCompleto = String.Empty 'SIRVE PARA VERIFICAR SI UN LOTE ESTA COMPLETO O INCOMPLETO

        Dim DatosAtado As New Entidades.CapturaAtadoValido

        If Cadena.Length >= 10 And Cadena.Length <= 13 And IsNumeric(Cadena) Then
            If AtadoActual = LTrim(RTrim(Cadena)) Then
                Return
            End If

            DatosAtado = VerificarAtadoValido_RecuperarDatosLote(Cadena) 'VERIFICA SI EL CODIGO ES DE UN ATADO VALIDO

            If DatosAtado.PIdAtado <> "0" Then 'VERIFICA SI SE RECUPERO UN ATADO VALIDO

                ' SI LA NAVE DEL ATADO NO CORRECPONDE CON LA NAVE QUE SE ESTA USANDO, SE DESCARTARA EL ATADO LEÍDO
                If DatosAtado.PIdNAve <> IdNave Then

                    'Reproducimos sonido de error
                    ReproducrirSonidoError()
                    lCodigosErroneos.Add("Código erroneo:" + LTrim(RTrim(Cadena)) + " * Atado actual: " + AtadoActual.ToString + "* Causa: Atado no pertenece a la nave en proceso")

                    'ACTUALIZA EL ESTADO DEL ATADO ANTERIOR AL ESCANEADO
                    If AtadoActual <> "0" Then
                        ActualizarEstatusDeAtado()
                    End If
                    AtadoActual = "0"
                    Return
                End If

                ''dtParesCodigoCliente = Nothing

                If lAtados.Count = 0 Then 'VALIDA QUE EL ATADO SEA EL PRIMER ATADO LEEIDO PARA INICIAR CON EL ESCANEO
                    If IdSalidaNave = 0 Then  'SÍ NO EXISTE ID DE SALIDA DE NAVE INICIARA UN NUEVO REGISTRO DE SALIDA DE NAVE

                        IniciarSalidaNaves() 'INICIA EL REGISTRO DE SALIDA NAVES
                    End If

                    'If Tipo_Nave_Maquila_o_Interna = True Then
                    '    Proceso_Para_Lote_Incompleto(DatosAtado)
                    'Else
                    ResultadoLoteCompleto = ValidarLoteTerminado(DatosAtado)
                    If ResultadoLoteCompleto = "COMPLETO" Then
                        'LOTE COMPLETO
                        Proceso_Para_Lote_completo(DatosAtado)
                    Else
                        'LOTE INCOMPLETO
                        Proceso_Para_Lote_Incompleto(DatosAtado)
                    End If
                    'End If
                Else
                    If Tipo_Nave_Maquila_o_Interna = True Then
                        Proceso_Para_Lote_Incompleto(DatosAtado)
                    Else
                        ResultadoLoteCompleto = ValidarLoteTerminado(DatosAtado)
                        If ResultadoLoteCompleto = "COMPLETO" Then
                            'LOTE COMPLETO
                            Proceso_Para_Lote_completo(DatosAtado)
                        Else
                            'LOTE INCOMPLETO
                            Proceso_Para_Lote_Incompleto(DatosAtado)
                        End If
                    End If
                End If
            Else
                If LecturaParXPar = False Then
                    'Reproducimos sonido de error
                    ReproducrirSonidoError()
                    lCodigosErroneos.Add("Código erroneo:" + LTrim(RTrim(Cadena)) + " * Atado actual: " + AtadoActual.ToString + "* Causa: Posible código de atado no valido ó código de cliente leído en lectura de 'Solo atados'.")
                    Return
                Else
                    'POSIBLE CODIGO DE CLIENTE
                    Proceso_Para_Codigo_De_Cliente_Capturado(LTrim(RTrim(Cadena)))
                End If
            End If
        ElseIf codigo_split.Length = 3 Then
            If LecturaParXPar = False Then
                ReproducrirSonidoError()
                lCodigosErroneos.Add("Código erroneo:" + LTrim(RTrim(Cadena)) + " * Atado actual: " + AtadoActual.ToString + "* Causa: Código de par leído en lectura de 'Solo atados'")
                Return
            Else
                If AtadoActual = 0 Then
                    ReproducrirSonidoError()
                    lCodigosErroneos.Add("Código erroneo:" + LTrim(RTrim(Cadena)) + " * Atado actual: " + AtadoActual.ToString + " * Causa: Código de par escaneado sin haber leído un código de atado valido.")
                    Return
                End If

                If externa Then
                    If precio > 0 Then
                        verificar_par(Cadena)
                        If par_valido = True Then
                            'PROCESO PARA CODIGO DE EMPRESA VALIDO
                            Proceso_Para_Par_Codigo_Empresa_Valido(LTrim(RTrim(Cadena)))
                        Else
                            'POSIBLE CODIGO DECLIENTE
                            Proceso_Para_Codigo_De_Cliente_Capturado(LTrim(RTrim(Cadena)))
                        End If
                    Else
                        ReproducrirSonidoError()
                    End If
                Else
                    verificar_par(Cadena)
                    If par_valido = True Then
                        'PROCESO PARA CODIGO DE EMPRESA VALIDO
                        Proceso_Para_Par_Codigo_Empresa_Valido(LTrim(RTrim(Cadena)))
                    Else
                        'POSIBLE CODIGO DECLIENTE
                        Proceso_Para_Codigo_De_Cliente_Capturado(LTrim(RTrim(Cadena)))
                    End If
                End If

            End If
        Else
            If LecturaParXPar = False Then
                ReproducrirSonidoError()
                lCodigosErroneos.Add("Código erroneo:" + LTrim(RTrim(Cadena)) + " * Atado actual: " + AtadoActual.ToString + " * Causa: Posible código de par de cliente leído en escaneo de 'Solo Atados'.")
                Return
            Else
                'POSIBLE CODIGO DE CLIENTE
                Proceso_Para_Codigo_De_Cliente_Capturado(LTrim(RTrim(Cadena)))
            End If
        End If
    End Sub

#End Region

#Region "codigos de cliente"

    ''' <summary>
    ''' AGREGA LOS PARES CON CODIGO DE CLIENTE A LA TABLA ALMACEN.SALIDANAVESDETALLES
    ''' </summary>
    ''' <param name="TipoPar">CADENA CON EL TIPO DE PAR QUE SE DEBE DE AGREGAR A LA SALIDA DE NAVE</param>
    ''' <remarks></remarks>
    Private Sub Agregar_Pares_CodigoCliente_SalidaNavesDetalles_AtadoActual(ByVal TipoPar As String)
        Dim objBU As New Negocios.SalidaNavesBU

        w = 1
        Do While w = 1
            Try
                objBU.Agregar_PAres_codigoCliente_SalidaNavesDetalles_AtadoActual(IdSalidaNave, AtadoActual, loteAtadoActual, AñoAtadoActual, IdNave, NumAtadoActual, TipoPar)
                w = 0
            Catch ex As Exception
                If ex.Message.Contains(" interbloqueo ") = False Then
                    w = 0
                End If
                EscribirErrorEnBiacora(ex.Message, "Agregar_Pares_CodigoCliente_SalidaNavesDetalles_AtadoActual()")
            End Try
        Loop
    End Sub


    ''' <summary>
    ''' ACTUALIZA EL ESTADO DE UN PAR EN LA TABLA DE CODIGOS DE CLIENTE QUE SE SUPONE DEBERIAN DE ENCONTRARSE EN EL ATADO, SI NO ESTA O 
    ''' YA NO HAY LUGARES A ACTUALIZAR LO PONDRIA COMO SOBRANTE
    ''' </summary>
    ''' <param name="codigo">CODIGO DE PAR A CHECAR</param>
    ''' <param name="Talla">TALA DEL PARA  A CHECAR</param>
    ''' <remarks></remarks>
    Public Sub Actualizar_Par_Tabla_ParesConCodigoCliente(ByVal codigo As String, ByVal Talla As String, ByVal Tipo As String)
        Dim N_Actualizado As Int16
        Dim Num_par As Integer
        If Tipo = "CLIENTE" Then

            For Each row As DataRow In dtParesCodigoCliente.Rows
                If LTrim(RTrim(row.Item("ATADO"))) = LTrim(RTrim(AtadoActual.ToString)) And LTrim(RTrim(row.Item("TALLA"))) = LTrim(RTrim(Talla)) And N_Actualizado = 0 And row.Item("Estado") = 2 _
                    And LTrim(RTrim(row.Item("codigo_cliente"))) = codigo.ToString Then
                    row.Item("Estado") = 1
                    Numero_Par = row.Item("#")
                    lpares.Add(AtadoActual.ToString + "-" + codigo + "-" + CStr(row.Item("#")))

                    N_Actualizado += 1
                    If llotesSinTerminar.Contains(loteAtadoActual.ToString + "-" + AñoAtadoActual.ToString + "-" + IdNave.ToString) Then
                        If estatusAtado <> 911 Then
                            PoblarGridLectura(loteAtadoActual, NumAtadoActual, AtadoActual, LTrim(RTrim(codigo)), row.Item("Descripcion"), Talla, 7, AñoAtadoActual)
                        End If

                    ElseIf llotesNoEmbarcados.Contains(loteAtadoActual.ToString + "-" + AñoAtadoActual.ToString + "-" + IdNave.ToString) Then
                        If estatusAtado <> 911 Then
                            PoblarGridLectura(loteAtadoActual, NumAtadoActual, AtadoActual, LTrim(RTrim(codigo)), row.Item("Descripcion"), Talla, 11, AñoAtadoActual)
                        End If


                    Else
                        If estatusAtado <> 911 Then
                            PoblarGridLectura(loteAtadoActual, NumAtadoActual, AtadoActual, LTrim(RTrim(codigo)), row.Item("Descripcion"), Talla, 2, AñoAtadoActual)
                        End If

                    End If

                    'ACTUALIZA EL ESTATUS DEL PAR EN CASO DE EXISTIR Y LO AGREGA EN CASO DE SER SOBRANTE, Y RECUPERA LA TALLA Y LA DESCRIPCION DEL PAR EN CUESTION
                    ActualizarEstatusPar(codigo, Talla, IdNave, CInt(row.Item("#")), TipoEscaneoPar_CodInterno_CodCliente, row.Item("Id_Producto"), row.Item("Descripcion"), Tipo_Nave_Maquila_o_Interna)
                End If
                Num_par = CInt(row.Item("#"))
            Next

            If N_Actualizado = 0 Then
                Num_par += 1
                If Tipo = "CLIENTE" Then
                    'RECUPERAMOS LA DESCRIPCION DEL CODIGO DE CLIENTE LEEIDO
                    RecuperarDesripcionPar(codigo)

                    NparesAtadoActual = NparesAtadoActual + 1

                    'AGREGAMOS EL PAR LEEIDO A LA TABLA YA QUE SERIA UN PAR SOBRANTE
                    Dim newRow As DataRow = dtParesCodigoCliente.NewRow()
                    newRow("ATADO") = AtadoActual
                    newRow("PAR") = "NA"
                    newRow("TALLA") = Talla
                    newRow("CODIGO_CLIENTE") = codigo
                    newRow("Estado") = 3
                    newRow("Descripcion") = DescripcionParActual
                    newRow("Id_Producto") = IdProductoParActual
                    newRow("#") = NparesAtadoActual
                    Numero_Par = 0

                    lparesErroneos.Add(AtadoActual.ToString + "-" + codigo + "-" + NparesAtadoActual.ToString)
                    lpares.Add(AtadoActual.ToString + "-" + codigo + "-" + NparesAtadoActual.ToString)
                    dtParesCodigoCliente.Rows.Add(newRow)

                    'PoblarGridLectura(loteAtadoActual, NumAtadoActual, AtadoActual, codigo, DescripcionParActual, Talla, 3)
                    If llotesSinTerminar.Contains(loteAtadoActual.ToString + "-" + AñoAtadoActual.ToString + "-" + IdNave.ToString) Then
                        PoblarGridLectura(loteAtadoActual, NumAtadoActual, AtadoActual, LTrim(RTrim(codigo)), DescripcionParActual, Talla, 7, AñoAtadoActual)
                    ElseIf llotesNoEmbarcados.Contains(loteAtadoActual.ToString + "-" + AñoAtadoActual.ToString + "-" + IdNave.ToString) Then
                        PoblarGridLectura(loteAtadoActual, NumAtadoActual, AtadoActual, LTrim(RTrim(codigo)), DescripcionParActual, Talla, 11, AñoAtadoActual)
                    Else
                        PoblarGridLectura(loteAtadoActual, NumAtadoActual, AtadoActual, LTrim(RTrim(codigo)), DescripcionParActual, Talla, 2, AñoAtadoActual)
                    End If
                    ActualizarEstatusPar(codigo, Talla, IdNave, NparesAtadoActual, TipoEscaneoPar_CodInterno_CodCliente, IdProductoParActual, DescripcionParActual, Tipo_Nave_Maquila_o_Interna)
                End If
            End If
        Else
            'RECUPERAMOS LA DESCRIPCION DEL PAR ENCONTRADO
            'RecuperarDescripcionCodigoParEmpresa(CStr(codigo))

            'AGREGAMOS EL PAR LEEIDO A LA TABLA YA QUE SERIA UN PAR SOBRANTE
            Dim newRow As DataRow = dtParesCodigoCliente.NewRow()
            newRow("ATADO") = AtadoActual
            newRow("PAR") = "NA"
            newRow("TALLA") = Talla
            newRow("CODIGO_CLIENTE") = codigo
            newRow("Estado") = 3
            newRow("Descripcion") = DescripcionParActual
            newRow("#") = NparesAtadoActual + 1
            Numero_Par = NparesAtadoActual + 1
            NparesAtadoActual = NparesAtadoActual + 1

            lpares.Add(AtadoActual.ToString + "-" + codigo + "-" + NparesAtadoActual.ToString)
            lparesErroneos.Add(AtadoActual.ToString + "-" + codigo + "-" + NparesAtadoActual.ToString)
            dtParesCodigoCliente.Rows.Add(newRow)

            If Proceso = "ENTRADA" And Tipo_Nave_Maquila_o_Interna = False Then
                If llotesSinTerminar.Contains(loteAtadoActual.ToString + "-" + AñoAtadoActual.ToString + "-" + IdNave.ToString) Then
                    PoblarGridLectura(loteAtadoActual, NumAtadoActual, AtadoActual, LTrim(RTrim(codigo)), DescripcionAtadoActual, Talla, 7, AñoAtadoActual)
                ElseIf llotesNoEmbarcados.Contains(loteAtadoActual.ToString + "-" + AñoAtadoActual.ToString + "-" + IdNave.ToString) Then
                    PoblarGridLectura(loteAtadoActual, NumAtadoActual, AtadoActual, LTrim(RTrim(codigo)), DescripcionAtadoActual, Talla, 11, AñoAtadoActual)
                Else
                    PoblarGridLectura(loteAtadoActual, NumAtadoActual, AtadoActual, LTrim(RTrim(codigo)), DescripcionAtadoActual, Talla, 2, AñoAtadoActual)
                End If
            Else
                PoblarGridLectura(loteAtadoActual, NumAtadoActual, AtadoActual, LTrim(RTrim(codigo)), DescripcionParActual, Talla, 2, AñoAtadoActual)
            End If

            ActualizarEstatusPar(codigo, Talla, IdNave, NparesAtadoActual, TipoEscaneoPar_CodInterno_CodCliente, IdProductoParActual, DescripcionParActual, Tipo_Nave_Maquila_o_Interna)
        End If
    End Sub


    ''' <summary>
    ''' RECUPERA LA DESCRIPCION DE UN PAR USANDO EL CODIGO UNICO DE PAR DE YUYIN
    ''' </summary>
    ''' <param name="Codigo">CODIGO DE PAR A VERIFICAR</param>
    ''' <remarks></remarks>
    Public Sub RecuperarDescripcionCodigoParEmpresa(ByVal Codigo As String)
        Dim objBU As New Negocios.SalidaNavesBU
        Dim dtDescripcion As New DataTable

        w = 1
        Do While w = 1
            Try
                dtDescripcion = objBU.RecuperarDesripcionParEmpresa(Codigo)
                w = 0
            Catch ex As Exception
                If ex.Message.Contains(" interbloqueo ") = False Then
                    w = 0
                End If
                EscribirErrorEnBiacora(ex.Message, "RecuperarDescripcionCodigoParEmpresa")
            End Try
        Loop

        For Each row As DataRow In dtDescripcion.Rows
            DescripcionParActual = row.Item(0)
            IdProductoParActual = row.Item(1)
            TallaParActual = row.Item(2)
        Next

    End Sub


    ''' <summary>
    ''' RECUPERA LA DESCRIPCION DE UN PAR ESCANEADO CON CODIGO DE CLIENTE
    ''' </summary>
    ''' <param name="COdigoCliente">CODIGO DE CLIENTE DEL QUE SE RECUPERARA LA DESCRIPCION DEL PAR</param>
    ''' <remarks></remarks>
    Public Sub RecuperarDesripcionPar(ByVal COdigoCliente As String)
        Dim objBU As New Negocios.SalidaNavesBU
        Dim dtDescripcion As New DataTable

        w = 1
        Do While w = 1
            Try
                dtDescripcion = objBU.RecuperarDesripcionPar(COdigoCliente)
                w = 0
            Catch ex As Exception
                If ex.Message.Contains(" interbloqueo ") = False Then
                    w = 0
                End If
                EscribirErrorEnBiacora(ex.Message, "RecuperarDesripcionPar()")
            End Try
        Loop

        For Each row As DataRow In dtDescripcion.Rows
            DescripcionParActual = row.Item(0)
            IdProductoParActual = row.Item(1)
        Next
    End Sub


#End Region

    ''' <summary>
    ''' VERIFICA SI EL ATADO SE ENCUENTRA EN EL GRID ERRONEOS, DE NO SE ASI LO AGREGARIA, AGREGARIA LOTE A LOTES DESCARTADOS Y LOS PARES A PARES DESCARTADOS EN CASO DE NO ESTAR EL ATADO EN EL LOTE EN EL GRID ERRONEOS
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ValidarAtadoEscaneado_Pertenesca_Aun_Atado_CorrectoAnteriormente()
        Dim objBU As New Negocios.SalidaNavesBU
        Dim dtTabla As New DataTable

        Dim w As Integer
        For Each row As UltraGridRow In grdIncorrecto.Rows
            If row.Cells("ATADO").Text = AtadoActual Then
                w += 1
            End If
        Next

        If w = 0 Then
            dtTabla = objBU.recuperarDatosAtadoSalidaNavesDetalles(AtadoActual, IdSalidaNave, IdNave)
            For Each row As DataRow In dtTabla.Rows
                poblarGrigErroneos(row.Item("lote"), row.Item("#"), row.Item("ATADO"), row.Item("DESCRIPCION"), 2, row.Item("AÑO"))
            Next

            lAtadosBien.Remove(loteAtadoActual + "-" + AñoAtadoActual + "-" + IdNave + "-" + AtadoActual)
            lAtadosErroneos.Add(loteAtadoActual + "-" + AñoAtadoActual + "-" + IdNave + "-" + AtadoActual)

            llotesBien.Remove(loteAtadoActual + "-" + AñoAtadoActual + "-" + IdNave)
            ResultadoHashSet_add = lLotesErroneos.Add(loteAtadoActual + "-" + AñoAtadoActual + "-" + IdNave)
            If ResultadoHashSet_add = True Then
                Dim dtpares As New DataTable
                dtpares = objBU.RecuperarPares_De_Lote(loteAtadoActual, AñoAtadoActual, IdNave)
                For Each row As DataRow In dtpares.Rows
                    lLotesEmbarcados.Remove(loteAtadoActual + "-" + AñoAtadoActual + "-" + IdNave)
                    lAtadosEmbarcados.Remove(loteAtadoActual + "-" + AñoAtadoActual + "-" + IdNave + "-" + row.Item(1))
                    lparesEmbarcados.Remove(loteAtadoActual + "-" + AñoAtadoActual + "-" + IdNave + "-" + row.Item(1) + "-" + row.Item(0))

                    lLotesDescartados.Add(loteAtadoActual + "-" + AñoAtadoActual + "-" + IdNave)
                    lAtadosDescartados.Add(loteAtadoActual + "-" + AñoAtadoActual + "-" + IdNave + "-" + row.Item(1))
                    lparesDescartados.Add(loteAtadoActual + "-" + AñoAtadoActual + "-" + IdNave + "-" + row.Item(1) + "-" + row.Item(0))
                Next
            End If
        End If

    End Sub


    ''' <summary>
    ''' ACTUALIZA EL TEXTO DE LAS ETIQUETAS DE CANTIDADES
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub LlenarEtiquetas()
        lblTotalCarritos.Text = lcarritos.Count.ToString("N0")

        lblParesLeidos.Text = lpares.Count.ToString("N0")
        lblPB.Text = lparesBien.Count.ToString("N0")
        lblParesIncorrectos.Text = lparesErroneos.Count.ToString("N0")
        lblParesDescartados.Text = lparesDescartados.Count.ToString("N0")

        lblLotesLeidos.Text = llotes.Count.ToString("N0")
        lblLB.Text = llotesBien.Count.ToString("N0")
        lblLotesIncorrectos.Text = lLotesErroneos.Count.ToString("N0")
        lblLotesDescardatos.Text = lLotesDescartados.Count.ToString("N0")

        lblAtadosLeidos.Text = lAtados.Count.ToString("N0")
        lblAB.Text = lAtadosBien.Count.ToString("N0")
        lblAtadosIncorrectos.Text = lAtadosErroneos.Count.ToString("N0")
        lblAtadosDescartados.Text = lAtadosDescartados.Count.ToString("N0")

        If Proceso = "SALIDA" Then
            lblTotalPares.Text = lparesEmbarcados.Count.ToString("N0")
            lblTotalAtados.Text = lAtadosEmbarcados.Count.ToString("N0")
            lblTotalLotes.Text = lLotesEmbarcados.Count.ToString("N0")
        Else
            If Tipo_Nave_Maquila_o_Interna = True Then
                lblTotalPares.Text = lparesEmbarcados.Count.ToString("N0")
                lblTotalAtados.Text = lAtadosEmbarcados.Count.ToString("N0")
                lblTotalLotes.Text = lLotesEmbarcados.Count.ToString("N0")

                lblTotalParesIngresados.Text = lparesEmbarcados.Count.ToString("N0")
                lblTotalAtadosIngresados.Text = lAtadosEmbarcados.Count.ToString("N0")
                lblTotalLotesIngresados.Text = lLotesEmbarcados.Count.ToString("N0")
            Else
                lblTotalParesIngresados.Text = lparesEmbarcados.Count.ToString("N0")
                lblTotalAtadosIngresados.Text = lAtadosEmbarcados.Count.ToString("N0")
                lblTotalLotesIngresados.Text = lLotesEmbarcados.Count.ToString("N0")
            End If
        End If

    End Sub


    ''' <summary>
    ''' EVENTO DROPDOWNCLOSE DE EL COMBO CMBOPERADOR PARA AGREGAR EL ID DE OPERADOR CADA VEZ QUE SE SELECCIONA UN OPERADOR EN EL COMBO
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cmbOperador_DropDownClosed(sender As Object, e As EventArgs) Handles cmbOperador.DropDownClosed
        If cmbOperador.SelectedIndex > 0 Then
            IdOperador = cmbOperador.SelectedValue
        End If
    End Sub


    ''' <summary>
    ''' EVENTO BEFOREROWSDELETE EN EL GRID GRDLECTURA EN EL QUE SE CANSELA EL MENSAJE DE CONFIRMACION AL ELIMINAR UNA FILA
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub grdLectura_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdLectura.BeforeRowsDeleted
        e.DisplayPromptMsg = False
    End Sub


    ''' <summary>
    ''' EVENTO BEFOREROWSDELETE EN EL GRID GRDINCORRECTO EN EL QUE SE CANSELA EL MENSAJE DE CONFIRMACION AL ELIMINAR UNA FILA
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub grdIncorrecto_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdIncorrecto.BeforeRowsDeleted
        e.DisplayPromptMsg = False
    End Sub


    ''' <summary>
    ''' EVENTO CLICL EN EL BOTÓN BTNSALIR
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Dim formaConfirmacion As New ConfirmarForm
        formaConfirmacion.StartPosition = FormStartPosition.CenterScreen
        formaConfirmacion.mensaje = "¿Estas seguro que deseas salir?"

        If formaConfirmacion.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Me.Close()
        End If
    End Sub

    Private Sub btnCodigosConErrores_Click(sender As Object, e As EventArgs) Handles btnCodigosConErrores.Click
        Dim FormaListaErrores As New ListaErroresSalidaNavesLotesForm
        FormaListaErrores.lErrores = lCodigosErroneos
        FormaListaErrores.IdNave = IdNave
        FormaListaErrores.StartPosition = FormStartPosition.CenterScreen
        FormaListaErrores.ShowDialog()
    End Sub

    Private Sub btnLeerArchivo_Click(sender As Object, e As EventArgs) Handles btnLeerArchivo.Click
        ValidarCamposVacios()
        If campos_vacios = True Then Return

        Iniciar_Proceso_Lectura()
        Proceso_Detener()

        show_message("Aviso", "Este proceso puede tardar dependiendo de la cantidad de pares a verificar")
        Dim myStream As Stream = Nothing
        Dim openFileDialog1 As New OpenFileDialog

        openFileDialog1.InitialDirectory = "c:\"
        openFileDialog1.Filter = "txt files (*.txt)|*.txt|dat files (*.dat)|*.dat"
        openFileDialog1.FilterIndex = 2
        openFileDialog1.RestoreDirectory = True

        If openFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Me.Cursor = Cursors.WaitCursor
            Try
                myStream = openFileDialog1.OpenFile()
                If (openFileDialog1.FileName IsNot Nothing) Then

                    LeerArchivoDeTextoLineaPorLinea(openFileDialog1.FileName)

                End If
            Catch Ex As Exception
                show_message("Error", "No se puede leer el archivo. Error original: " & Ex.Message)
            Finally
                ' Check this again, since we need to make sure we didn't throw an exception on open.
                If (myStream IsNot Nothing) Then
                    myStream.Close()
                End If
            End Try
            Me.Cursor = Cursors.Default
        End If

        txtcapturacodigos.Enabled = False
        btnDetener.Enabled = False

        cmbOperador.Enabled = False
        cmbNaves.Enabled = False
        cmbProceso.Enabled = False
        btnGuardar.Enabled = True
        btnSalir.Enabled = True
        btnIniciar.Enabled = True

        'falta actualiar el estdo del atado n
        If AtadoActual <> "0" Then
            ActualizarEstatusDeAtado()
            AtadoActual = "0"
            LlenarEtiquetas()
        End If

        ControlBox = True
    End Sub

    ''' <summary>
    ''' FUNCION QUE LEE EL ARCHIVO LINEA POR LINEA Y CADA LINEA EJECUTA EL PROCESO DE LEER CODIGO
    ''' </summary>
    ''' <param name="Directorio">ARCHIVO A LEER</param>
    ''' <remarks></remarks>
    Private Sub LeerArchivoDeTextoLineaPorLinea(ByVal Directorio As String)
        Dim objReader As New StreamReader(Directorio)
        Dim sLine As String = ""
        Dim arrArchivo As New ArrayList()

        Do
            sLine = objReader.ReadLine()
            If Not sLine Is Nothing Then
                arrArchivo.Add(sLine)
            End If
        Loop Until sLine Is Nothing
        objReader.Close()

        For Each item In arrArchivo
            CadenaCapturada = (LTrim(RTrim(item))).Replace("'", "-")
            If Proceso = "SALIDA" Then
                If LTrim(RTrim(item)) <> "" Then
                    CapturaParAtadosYuyin(CadenaCapturada)
                End If
            Else
                If LTrim(RTrim(item)) <> "" Then
                    CapturarParAtados_EntradaNave(CadenaCapturada)
                End If
            End If
        Next
    End Sub



#Region "REPORTES"

#Region "REPORTE SALIDAS"
    ''' <summary>
    ''' RECUPERA LOS TOTALES DE PARES Y ATADOS Y SUS LOTES Y AÑOS CORRESPONDIENTES DE UNA SALIDA DE NAVE YA CONCLUIDA
    ''' </summary>
    ''' <param name="Id_Salida_Nave">ID DE SALIDA DE NAVE DE LA CUAL RE RECUPERARA INFORMACION</param>
    ''' <returns>DATATABLE CON LA INFORMACION RECUPERADA</returns>
    ''' <remarks></remarks>
    Private Function Recuperar_Informacion_Reporte_SalidaNaves(ByVal Id_Salida_Nave As Integer, ByVal Id_Nave As Integer)
        Dim objBU As New Negocios.SalidaNavesBU
        Dim dtTablaGeneral As New DataTable
        Dim dtTablaCorrida As New DataTable

        dtTablaGeneral = objBU.Recuperar_Informacion_Reporte_SalidaNaves(Id_Salida_Nave, Id_Nave)

        Return dtTablaGeneral
    End Function

    Private Function RecuperarFechaDeSalidaDeEmbarque()
        Dim objSalidasBU As New Negocios.SalidaNavesBU
        Dim dtFecha As New DataTable
        dtFecha = objSalidasBU.RecuperarFechaDeSalidaDeEmbarque(IdSalidaNave)

        Return dtFecha.Rows(0).Item(0)
    End Function

    Private Function Recuperar_Totales_LotesAtadosPares_Embarcados(ByVal IdSalidaNave As Integer)
        Dim objSalidaBU As New Negocios.SalidaNavesBU
        Dim dtTotales = objSalidaBU.Recuperar_Totales_LotesAtadosPares_Embarcados(IdSalidaNave)
        Return dtTotales
    End Function

    Private Sub ImprimirReporte_Salida_Naves(ByVal Id_Salida_Nave As Integer, ByVal Id_Nave As Integer, ByVal Operador As String)
        Dim dtParesAEmbarcar As New DataTable
        Dim dtTotalesDelEmbarque As New DataTable
        Dim Fecha_Salida As DateTime
        Dim Hora_Salida As String
        Dim entrega As Integer
        Dim TotalParesEmbarcados As Integer
        Dim TotalAtadosEmbarcados As Integer
        Dim TotalLotesEmbarcados As Integer
        Dim dtTablaCantidadesProgramas
        Me.Cursor = Cursors.WaitCursor
        'RECUPERAMOS LOS TOTALES DE LOS PARES EMBARCADOS DIVIDIDOS POR LOTES Y OBTENIENDOP DETALLES DE CADA LOTE PARA EL REPORTE
        dtParesAEmbarcar = Recuperar_Informacion_Reporte_SalidaNaves(Id_Salida_Nave, Id_Nave)

        'RECUPERAMOS LOS TOTALES DE EL EMBARQUE ASI COMO LA FECHA
        dtTotalesDelEmbarque = Recuperar_Totales_LotesAtadosPares_Embarcados(Id_Salida_Nave)
        TotalParesEmbarcados = dtTotalesDelEmbarque.Rows(0).Item("PARES_SALIDA")
        TotalAtadosEmbarcados = dtTotalesDelEmbarque.Rows(0).Item("ATADOS_SALIDA")
        TotalLotesEmbarcados = dtTotalesDelEmbarque.Rows(0).Item("LOTES_SALIDA")
        Fecha_Salida = dtTotalesDelEmbarque.Rows(0).Item("FECHA_SALIDA")
        Hora_Salida = Fecha_Salida.Hour
        entrega = dtTotalesDelEmbarque.Rows(0).Item("ENTREGA")

        ''RECUPERAMOS LOS TOTALES DE PARES SALIDOS CON ATRASO Y EN TIEMPO
        dtTablaCantidadesProgramas = RecuperarCantidadesProgramasEnTiempoYAtrasados(dtParesAEmbarcar, Fecha_Salida)
        Dim ParesProgramaBien As Integer = 0
        Dim AtadosProgramaBien As Integer = 0
        Dim LotesProgramaBien As Integer = 0
        Dim ParesProgramaMal As Integer = 0
        Dim AtadosProgramaMal As Integer = 0
        Dim LotesProgramaMal As Integer = 0

        ParesProgramaBien = dtTablaCantidadesProgramas.Rows(0).Item("Pares")
        AtadosProgramaBien = dtTablaCantidadesProgramas.Rows(0).Item("Atados")
        LotesProgramaBien = dtTablaCantidadesProgramas.Rows(0).Item("Lotes")
        ParesProgramaMal = dtTablaCantidadesProgramas.Rows(1).Item("Pares")
        AtadosProgramaMal = dtTablaCantidadesProgramas.Rows(1).Item("Atados")
        LotesProgramaMal = dtTablaCantidadesProgramas.Rows(1).Item("Lotes")

        Dim OBJBU As New Framework.Negocios.ReportesBU
        Dim EntidadReporte As Entidades.Reportes
        EntidadReporte = OBJBU.LeerReporteporClave("PROD_SALIDANAVES_SALIDANAVES")
        Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
            LTrim(RTrim(EntidadReporte.Pnombre)) + ".mrt"
        My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)
        Dim reporte As New StiReport
        reporte.Load(archivo)
        reporte.Compile()
        reporte("urlImagenNave") = Tools.Controles.ObtenerLogoNave(43)
        reporte("nombreNave") = Tools.Controles.RecuperarNombreNave(Id_Nave)
        reporte("NombreReporte") = "SAY: RESUMEN_SALIDA_NAVES.mrt"
        reporte("Usuario") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername.ToString
        reporte("Operador") = Operador
        Dim fechaimp As String = DateTime.Parse(Now).ToString("dd/MM/yyyy HH:mm:ss")
        reporte("Fecha_Impresion") = DateTime.Parse(Now).ToShortDateString.ToString
        reporte("Fecha_Salida") = Fecha_Salida.Date.ToString("dd/MM/yyyy")
        reporte("Hora_Salida") = Fecha_Salida.ToShortTimeString
        reporte("Folio") = Id_Salida_Nave
        reporte("TotalPares") = TotalParesEmbarcados
        reporte("TotalAtados") = TotalAtadosEmbarcados
        reporte("TotalLotes") = TotalLotesEmbarcados
        reporte("Entrega") = entrega
        reporte("ParesProgramaBien") = ParesProgramaBien
        reporte("AtadosProgramaBien") = AtadosProgramaBien
        reporte("LotesProgramaBien") = LotesProgramaBien
        reporte("ParesProgramaMal") = ParesProgramaMal
        reporte("AtadosProgramaMal") = AtadosProgramaMal
        reporte("LotesProgramaMal") = LotesProgramaMal

        reporte.Dictionary.Clear()
        reporte.RegData(dtParesAEmbarcar)
        reporte.Dictionary.Synchronize()
        reporte.Show()
    End Sub

    Private Function RecuperarCantidadesProgramasEnTiempoYAtrasados(ByVal dtTabla As DataTable, ByVal fecha_Salida As Date) As DataTable
        Dim dtTablaCantidadesProgramas As New DataTable
        Dim Dias As Integer
        Dim programa As Date
        Dim ParesBien As Integer = 0
        Dim ParesMal As Integer = 0
        Dim AtadosBien As Integer = 0
        Dim AtadosMal As Integer = 0
        Dim LotesBien As Integer = 0
        Dim LotesMal As Integer = 0
        Dim diasTotales As Double = 0

        For Each row As DataRow In dtTabla.Rows
            programa = row.Item("Programa")
            Dias = (fecha_Salida - programa).TotalDays
            'borrar---------------------------------------------------------------------------
            Dias = DateDiff(DateInterval.Day, programa, fecha_Salida) 'dias que existen entre el rango de fechas
            For index As Integer = 1 To Dias
                If index = 1 Then
                    If programa.Month = 3 Then
                        If programa.Day = 21 Then
                        ElseIf programa.Day = 22 Then
                        ElseIf programa.Day = 23 Then
                        ElseIf programa.Day = 24 Then
                        ElseIf programa.Day = 25 Then
                        ElseIf programa.Day = 26 Then
                        ElseIf programa.Day = 27 Then
                            If Not programa.DayOfWeek = 0 Then
                                diasTotales = diasTotales + 1
                            End If
                        Else
                            diasTotales = diasTotales + 1
                        End If
                    Else
                        diasTotales = diasTotales + 1
                    End If
                End If
                If DateAdd(DateInterval.Day, index, programa).Month = 3 Then
                    If DateAdd(DateInterval.Day, index, programa).Day = 21 Then
                    ElseIf DateAdd(DateInterval.Day, index, programa).Day = 22 Then
                    ElseIf DateAdd(DateInterval.Day, index, programa).Day = 23 Then
                    ElseIf DateAdd(DateInterval.Day, index, programa).Day = 24 Then
                    ElseIf DateAdd(DateInterval.Day, index, programa).Day = 25 Then
                    ElseIf DateAdd(DateInterval.Day, index, programa).Day = 26 Then
                    ElseIf DateAdd(DateInterval.Day, index, programa).Day = 27 Then
                        If Not DateAdd(DateInterval.Day, index, programa).DayOfWeek = 0 Then
                            diasTotales = diasTotales + 1
                        End If
                    Else
                        diasTotales = diasTotales + 1
                    End If
                Else
                    diasTotales = diasTotales + 1
                End If
            Next
            Dias = diasTotales
            'borrar---------------------------------------------------------------------------
            'Dias = 14
            If Dias <= 5 Then
                ParesBien += row.Item("PARES")
                AtadosBien += row.Item("ATADOS")
                LotesBien += 1
            ElseIf Dias = 6 Then
                If (programa.DayOfWeek = 3 And fecha_Salida.DayOfWeek = 1) Or _
                    (programa.DayOfWeek = 4 And fecha_Salida.DayOfWeek = 2) Or _
                    (programa.DayOfWeek = 5 And fecha_Salida.DayOfWeek = 3) Or _
                    (programa.DayOfWeek = 6 And fecha_Salida.DayOfWeek = 4) Then
                    ParesBien += row.Item("PARES")
                    AtadosBien += row.Item("ATADOS")
                    LotesBien += 1
                Else
                    ParesMal += row.Item("PARES")
                    AtadosMal += row.Item("ATADOS")
                    LotesMal += 1
                End If
            Else
                ParesMal += row.Item("PARES")
                AtadosMal += row.Item("ATADOS")
                LotesMal += 1
            End If
            diasTotales = 0
        Next

        Dim columns As DataColumnCollection = dtTablaCantidadesProgramas.Columns
        Dim columna0 As New DataColumn
        columna0.DataType = Type.GetType("System.Double")
        columna0.DefaultValue = 0
        columna0.ColumnName = "Pares"
        columns.Add(columna0)

        Dim columna1 As New DataColumn
        columna1.DataType = Type.GetType("System.Double")
        columna1.DefaultValue = 0
        columna1.ColumnName = "Atados"
        columns.Add(columna1)

        Dim columna2 As New DataColumn
        columna2.DataType = Type.GetType("System.Double")
        columna2.DefaultValue = 0
        columna2.ColumnName = "Lotes"
        columns.Add(columna2)

        Dim newCustomersRow As DataRow = dtTablaCantidadesProgramas.NewRow()
        newCustomersRow("Pares") = ParesBien
        newCustomersRow("Atados") = AtadosBien
        newCustomersRow("Lotes") = LotesBien
        dtTablaCantidadesProgramas.Rows.Add(newCustomersRow)

        Dim newCustomersRow1 As DataRow = dtTablaCantidadesProgramas.NewRow()
        newCustomersRow1("Pares") = ParesMal
        newCustomersRow1("Atados") = AtadosMal
        newCustomersRow1("Lotes") = LotesMal
        dtTablaCantidadesProgramas.Rows.Add(newCustomersRow1)

        dtTablaCantidadesProgramas.TableName = "dtTablaCantidadesProgramas"

        Return dtTablaCantidadesProgramas
    End Function

#End Region

#Region "REPORTE ENTRADAS"

    Private Function Recuperar_Informacion_Reporte_Entradas(ByVal Fecha_Inicio As String, ByVal Fecha_Fin As String, ByVal IdNave As Integer)
        Dim objBU As New Negocios.EntradaProductoBU
        Dim dsTotalesDeSalidas As New DataSet("dsTotalesDeSalidas")
        Dim dtTotalesRecibidos As New DataTable("dtTotalesRecibidos")
        Dim dtTotalesNoEmbarcadosLeidos As New DataTable("dtTotalesNoEmbarcadosLeidos")
        Dim dtTotalesFaltantes As New DataTable("dtTotalesFaltantes")

        dtTotalesRecibidos = objBU.Recuperar_Totales_Recibidos(Fecha_Inicio, Fecha_Fin, IdNave)
        dtTotalesNoEmbarcadosLeidos = objBU.Recuperar_Totales_No_Embarcados(Fecha_Inicio, Fecha_Fin, IdNave)
        dtTotalesFaltantes = objBU.Recuperar_Totales_Faltantes(Fecha_Inicio, Fecha_Fin, IdNave)

        dtTotalesRecibidos.TableName = "dtTotalesRecibidos"
        dtTotalesNoEmbarcadosLeidos.TableName = "dtTotalesNoEmbarcadosLeidos"
        dtTotalesFaltantes.TableName = "dtTotalesFaltantes"

        dsTotalesDeSalidas.Tables.Add(dtTotalesRecibidos)
        dsTotalesDeSalidas.Tables.Add(dtTotalesNoEmbarcadosLeidos)
        dsTotalesDeSalidas.Tables.Add(dtTotalesFaltantes)

        Return dsTotalesDeSalidas
    End Function

    Public Function Recuperar_Nombre_Operador_ReporteEntradas(ByVal Fecha_Inicio As String, ByVal Fecha_Fin As String, ByVal IdNave As Integer)
        Dim objBU As New Negocios.EntradaProductoBU
        Dim NombreOperador As String

        NombreOperador = objBU.Recuperar_Nombre_Operador_ReporteEntradas(Fecha_Inicio, Fecha_Fin, IdNave)

        Return NombreOperador
    End Function


    Private Sub ImprimirReporte_Entrada_Almacen()
        Dim dsTotalesDeSalidas As New DataSet
        Dim dtTotalesEntrada As New DataTable
        Dim Fecha_Inicio As String
        Dim Fecha_Fin As String
        Dim Operador As String
        Dim TotalPares As Integer = 0
        Dim TotalAtados As Integer = 0
        Dim TotalLotes As Integer = 0
        Dim lProgramas As New HashSet(Of String)
        Dim Id_Nave As Integer
        Dim Tabla_dataSet_Recuperada As New DataTable
        Dim dtTablaCantidadesProgramas As New DataTable

        Dim formaFecha As New InformacionSecundarioEntradaDeLotesForm
        formaFecha.StartPosition = FormStartPosition.CenterScreen
        formaFecha.Reporte = True
        formaFecha.ShowDialog()

        Fecha_Inicio = formaFecha.fecha_Inicio
        Fecha_Fin = formaFecha.fecha_fin
        Id_Nave = formaFecha.IdNave




        Me.Cursor = Cursors.WaitCursor
        'RECUPERAMOS LOS TOTALES DE LOS PARES EMBARCADOS DIVIDIDOS POR LOTES Y OBTENIENDOP DETALLES DE CADA LOTE PARA EL REPORTE
        dsTotalesDeSalidas = Recuperar_Informacion_Reporte_Entradas(Fecha_Inicio, Fecha_Fin, Id_Nave)


        If dsTotalesDeSalidas.Tables("dtTotalesRecibidos").Rows.Count = 0 Then
            show_message("Aviso", "No se encontro información.")
            Me.Cursor = Cursors.Default
            Return
        End If

        'Recuperamos los totales
        For Each row As DataRow In dsTotalesDeSalidas.Tables("dtTotalesRecibidos").Rows
            TotalPares = TotalPares + row.Item("Pares")
            TotalAtados = TotalAtados + row.Item("Atados")
            TotalLotes = TotalLotes + row.Item("lotes")
            lProgramas.Add(row.Item("Programa"))
        Next

        'Recuperar el Nombre del Operador
        Operador = Recuperar_Nombre_Operador_ReporteEntradas(Fecha_Inicio, Fecha_Fin, Id_Nave)


        dtTablaCantidadesProgramas = RecuperarCantidadesProgramasEnTiempoYAtrasados(dsTotalesDeSalidas.Tables("dtTotalesRecibidos"), Fecha_Inicio)
        Dim ParesProgramaBien As Integer = 0
        Dim AtadosProgramaBien As Integer = 0
        Dim LotesProgramaBien As Integer = 0
        Dim ParesProgramaMal As Integer = 0
        Dim AtadosProgramaMal As Integer = 0
        Dim LotesProgramaMal As Integer = 0

        ParesProgramaBien = dtTablaCantidadesProgramas.Rows(0).Item("Pares")
        AtadosProgramaBien = dtTablaCantidadesProgramas.Rows(0).Item("Atados")
        LotesProgramaBien = dtTablaCantidadesProgramas.Rows(0).Item("Lotes")
        ParesProgramaMal = dtTablaCantidadesProgramas.Rows(1).Item("Pares")
        AtadosProgramaMal = dtTablaCantidadesProgramas.Rows(1).Item("Atados")
        LotesProgramaMal = dtTablaCantidadesProgramas.Rows(1).Item("Lotes")


        Dim OBJBU As New Framework.Negocios.ReportesBU
        Dim EntidadReporte As Entidades.Reportes
        EntidadReporte = OBJBU.LeerReporteporClave("ALM_ENTRADAS_RESUMEN")
        Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
            LTrim(RTrim(EntidadReporte.Pnombre)) + ".mrt"
        My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)
        Dim reporte As New StiReport
        reporte.Load(archivo)
        reporte.Compile()
        reporte("urlImagenNave") = Tools.Controles.ObtenerLogoNave(43)
        reporte("nombreNave") = Tools.Controles.RecuperarNombreNave(Id_Nave)
        reporte("NombreReporte") = "SAY: RESUMEN_ENTRADAS_ALMACEN.mrt"
        reporte("Usuario") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername.ToString
        reporte("Recibio") = Entidades.SesionUsuario.UsuarioSesion.PUserNombreReal.ToString
        reporte("Operador") = Operador
        reporte("fecha_inicio") = DateTime.Parse(Fecha_Inicio).ToShortDateString
        reporte("fecha_fin") = DateTime.Parse(Fecha_Inicio).ToShortDateString
        reporte("TotalPares") = TotalPares
        reporte("TotalAtados") = TotalAtados
        reporte("TotalLotes") = TotalLotes
        reporte("TotalProgramas") = lProgramas.Count
        reporte("ParesProgramaBien") = ParesProgramaBien
        reporte("AtadosProgramaBien") = AtadosProgramaBien
        reporte("LotesProgramaBien") = LotesProgramaBien
        reporte("ParesProgramaMal") = ParesProgramaMal
        reporte("AtadosProgramaMal") = AtadosProgramaMal
        reporte("LotesProgramaMal") = LotesProgramaMal

        reporte.Dictionary.Clear()
        reporte.RegData(dsTotalesDeSalidas)
        reporte.Dictionary.Synchronize()

        Me.Cursor = Cursors.Default

        reporte.Show()


    End Sub
#End Region



#End Region

#Region "BOTONES"

    ''' <summary>
    ''' BOTÓN INICIAR
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnIniciar_Click(sender As Object, e As EventArgs) Handles btnIniciar.Click

        Iniciar_Proceso_Lectura()

    End Sub

    ''' <summary>
    ''' RECUPERA UN VALOR DEL TIPO BOOLEANO PARA DEPENDIENDO DE LA CATEGORIA EN LA QUE SE ENCUENTRA LA NAVE CON LA QUE SE ESTARA TRABAJANDO}
    ''' (VALOR TRUE PARA MAQUILA, VALOR FALSE PARA NORMAL)
    ''' </summary>
    ''' <param name="Id_Nave">ID DE LA NAVE A VERIFICAR</param>
    ''' <remarks></remarks>
    Private Sub Validar_TipoNave_Maquila_O_Normal(ByVal Id_Nave As Integer)
        Dim objBU As New Negocios.SalidaNavesBU
        w = 1
        Do While w = 1
            Try
                Tipo_Nave_Maquila_o_Interna = objBU.Validar_TipoNave_Maquila_O_Normal(Id_Nave)
                w = 0
            Catch ex As Exception
                If ex.Message.Contains(" interbloqueo ") = False Then
                    w = 0
                End If
                EscribirErrorEnBiacora(ex.Message, "Validar_TipoNave_Maquila_O_Normal()")
            End Try
        Loop
    End Sub

    ''' <summary>
    ''' VALIDA DISTINTAS VARIABLES PARA SABER QUE ACCION TOMAR AL PRESIONAR EL BOTON INICIAR, DEPENDE DE SI SE ESTA TRABAJANDO CON LA VENTANA
    ''' COMO SALIDA DE NAVE O COMO ENTRADA A ALMACEN, SI YA SE HABIA INICIADO CON ANTERIORMENTE EL PROCESO AL PRESIONAR EL BOTON INICIAR
    ''' (PARA RECUPERAR DATOS EN CASO DE SE LA PRIMERA VEZ QUE SE PRESIONA Y SE INGRESARON CORRECTAMENTE LOS DATOS NECESARIOS PARA EL PROCESO QUE SE QUIERE REALIZAR)
    ''' Y ACTIVAR Y DESCATIVAR CONTROLES Y BOTONES.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Iniciar_Proceso_Lectura()
        Dim objVal As New SalidaNavesBU
        externa = objVal.validarexterna(IdNave)

        Validar_TipoNave_Maquila_O_Normal(IdNave)

        If Tipo_Nave_Maquila_o_Interna = True And Proceso = "SALIDA" Then
            show_message("Advertencia", "No es posible darle salida a una nave del tipo 'Maquiladora'")
            Return
        End If

        Me.Cursor = Cursors.WaitCursor
        ValidarCamposVacios()
        If campos_vacios = True Then
            Me.Cursor = Cursors.Default
            Return
        Else
            Me.Cursor = Cursors.WaitCursor
            Proceso = cmbProceso.Text
            btnIniciar.Enabled = False
            btnCodigosConErrores.Enabled = True
            txtcapturacodigos.Enabled = True
            txtcapturacodigos.Select()
            btnDetener.Enabled = True
            cmbOperador.Enabled = False
            cmbNaves.Enabled = False
            cmbProceso.Enabled = False
            btnGuardar.Enabled = False
            btnSalir.Enabled = False
            ControlBox = False
            btnDescartarLotes.Enabled = False
            btnImprimirReporte.Enabled = False

            'RECUPERAMOS LOS CLIENTES PARA ESTA NAVE CON LOS QUE HAY QUE VALIDAR PAR POR PAR
            lClientesValidacionParXPar_Nave = RecuperarClientesParaValidacionParxPar(IdNave)

            If cmbProceso.Text = "ENTRADA" Then
                Me.Cursor = Cursors.WaitCursor
                If Tipo_Nave_Maquila_o_Interna = False Then 'INDICA QUE EL TIPO DE NAVE ES NORMAL Y QUE SEGURAMENTE EXISTE UNA SALIDA DE NAVE EN ESTADO DE EMBARCADO
                    If n_iniciar = 0 Then
                        Dim Estado_SalidaNave As String
                        Dim forma_IngresarFolio As New InformacionSecundarioEntradaDeLotesForm
                        Dim Nave_Valida As Boolean 'TRUE PARA CUANDO CONCUERDE LA NAVE SELECCIONADA CON EL FOLIO DE LA NAVE INTRODUCIDO, FALSE PARA CUANDO NO PASE LO MENCIONADO ANTERIORMENTE

                        forma_IngresarFolio.IdNave = IdNave
                        forma_IngresarFolio.StartPosition = FormStartPosition.CenterScreen
                        forma_IngresarFolio.ShowDialog()
                        Me.Cursor = Cursors.WaitCursor
                        IdSalidaNave = forma_IngresarFolio.folio
                        Estado_SalidaNave = forma_IngresarFolio.Estado_SalidaNave
                        Nave_Valida = forma_IngresarFolio.Nave_Valida

                        If Nave_Valida = False Or Estado_SalidaNave = "EN PROCESO" Or Estado_SalidaNave = "ENTREGADO" Then
                            btnIniciar.Enabled = True
                            btnCodigosConErrores.Enabled = False
                            txtcapturacodigos.Enabled = False
                            btnDetener.Enabled = False
                            cmbOperador.Enabled = True
                            cmbProceso.Enabled = True
                            cmbNaves.Enabled = True
                            btnGuardar.Enabled = False
                            btnSalir.Enabled = True
                            ControlBox = True
                            n_iniciar = 0

                            Me.Cursor = Cursors.Default
                            Return
                        Else
                            Dim objBU As New Negocios.EntradaProductoBU

                            If Estado_SalidaNave = "EMBARCADO" Then
                                w = 1
                                Do While w = 1
                                    Try
                                        'ACTUALIZAMOS EL ESTADO DE LA SALIDA DE NAVE
                                        objBU.ActualizarEstatus_SalidaNave_ParaElComienzoDelEscaneo(IdSalidaNave)
                                        w = 0
                                    Catch ex As Exception
                                        If ex.Message.Contains(" interbloqueo ") = False Then
                                            w = 0
                                        End If
                                        EscribirErrorEnBiacora(ex.Message, "Iniciar_Proceso_Lectura(), objBU.ActualizarEstatus_SalidaNave_ParaElComienzoDelEscaneo")
                                    End Try
                                Loop
                            End If

                            Recuperar_Informacion_DeLotes_Embarcados_Y_Asignarla_A_Sus_Controles(Estado_SalidaNave)

                            n_iniciar += 1
                            Me.Cursor = Cursors.Default
                        End If
                    End If
                Else
                    Me.Cursor = Cursors.WaitCursor
                    If n_iniciar = 0 Then
                        'VALIDAMOS QUE NO EXISTA ALGUNA SALIDA DE NAVES ACTIVA PARA LA NAVE SELECCIONADA Y EL OPERADOR LOGGEADO
                        ValidarSalidasPendientes()
                        If salida_pendiente = True Then
                            Dim objBU As New Negocios.SalidaNavesBU

                            show_message("Advertencia", "Existe un proceso de entrada pendiente de lotes para esta nave, por favor terminelo para poder iniciar uno nuevo.")

                            w = 1
                            Do While w = 1
                                Try
                                    objBU.Actualizar_Almacen_salidaNavesDetalles_SalidaNaves(IdSalidaNave, "EN PROCESO", IdNave)
                                    w = 0
                                Catch ex As Exception
                                    If ex.Message.Contains(" interbloqueo ") = False Then
                                        w = 0
                                    End If
                                    EscribirErrorEnBiacora(ex.Message, "Iniciar_Proceso_Lectura(),  objBU.Actualizar_Almacen_salidaNavesDetalles_SalidaNaves")
                                End Try
                            Loop

                            Me.Cursor = Cursors.WaitCursor
                            RecuperarInformacionDeLotesEmbarcados_Y_Asignarla_al_Grid_Errores()
                            RecuperarInformacionDeLotesEmbarcados_Y_Asignarla_al_Grid_Lectura()
                        End If

                        n_iniciar += 1
                    End If
                End If
            Else
                'INDICA QUE EL TIPO ES SALIDA
                If n_iniciar = 0 Then
                    'VALIDAMOS QUE NO EXISTA ALGUNA SALIDA DE NAVES ACTIVA PARA LA NAVE SELECCIONADA Y EL OPERADOR LOGGEADO
                    ValidarSalidasPendientes()
                    If salida_pendiente = True Then
                        Dim objBU As New Negocios.SalidaNavesBU

                        show_message("Advertencia", "Existe un proceso de salida de lotes pendiente para esta nave, por favor terminelo para poder iniciar uno nuevo.")
                        'objBU.Actualizar_Almacen_salidaNavesDetalles_SalidaNaves(IdSalidaNave, "EN PROCESO")
                        RecuperarInformacionSalidaEnProceso()
                    End If
                End If
                n_iniciar += 1
            End If
            Me.Cursor = Cursors.Default
        End If
    End Sub

    ''' <summary>
    ''' CONECTA CON LA CAPA DE NEGOCIOS PARA FINALIZAR EL PROCESO DE ENTRADA, ACTUALIZAR LOS PARES EN LA TABLA TMPDOCENASPARES DE 0 A1 Y SU FECHA DE ENTRADA A ALMACEN, Y ACTUALIZAR LOS TOTALES DE PARES ENTREGADOS Y APRES DEVUELTOS EN LA TABLA 
    ''' SALIDANAVES, ASI COMO EL LLENADO DE LOS CARRITOS EN LAS TABLAS CONTENIDOCARRITO Y CONTENIDOCARRITOATADOS
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function FinalizarEntradaProducto()
        Dim objBUEntrada As New Negocios.EntradaProductoBU
        Dim dtTabla As New DataTable

        dtTabla = objBUEntrada.FinalizarEntradaProducto(IdSalidaNave, Tipo_Nave_Maquila_o_Interna, n_Pares_Correctos, n_Atados_Correctos, n_lotes_Correctos, n_Pares_Pares_Descartados, _
                                                        n_Atados_Descartados, n_lotes_Descartados, IdNave)
        For Each row As DataRow In dtTabla.Rows
            Return row.Item(0)
        Next
    End Function

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim objBU As New Negocios.SalidaNavesBU
        Dim onjBUEntradaProducto As New Negocios.EntradaProductoBU
        Dim dtTabla As New DataTable
        Dim MensajeResultado As String = String.Empty


        If Proceso = "ENTRADA" Then
            Me.Cursor = Cursors.WaitCursor

            dtTabla = onjBUEntradaProducto.Recuperar_Totales_Entrada_De_Nave_En_Proceso(IdSalidaNave, IdNave)
            For Each row As DataRow In dtTabla.Rows
                n_Atados_Correctos = row.Item("ATADOS ENTREGADOS")
                n_Pares_Correctos = row.Item("PARES ENTREGADOS")
                n_lotes_Correctos = row.Item("LOTES ENTREGADOS")
                n_Pares_Pares_Descartados = row.Item("PARES DEVUELTOS")
                n_Atados_Descartados = row.Item("ATADOS DEVUELTOS")
                n_lotes_Descartados = row.Item("LOTES DEVUELTOS")
            Next

            If grdIncorrecto.Rows.Count > 0 Or lparesEmbarcados.Count <> n_Pares_Correctos Or lAtadosEmbarcados.Count <> n_Atados_Correctos Or lLotesEmbarcados.Count <> n_lotes_Correctos.ToString Then
                Me.Cursor = Cursors.Default
                show_message("Advertencia", "Aun cuentas con faltante y/o errores en tu lectura, descarta los atados o termina de leer correctamente para poder guardar.")
            Else

                Me.Cursor = Cursors.WaitCursor
                Try
                    MensajeResultado = String.Empty
                    MensajeResultado = FinalizarEntradaProducto()
                Catch ex As Exception
                    show_message("Error", "Error al guardar, muestre el siguiente mensaje al administrador del sistema: " + ex.Message)
                    Me.Cursor = Cursors.Default
                End Try
                If MensajeResultado = "EXITO" Then
                    show_message("Exito", "El proceso de entrada se finalizo correctamente")
                    Limpiar_Variables()
                    Limpiar_Controles()
                    LlenarEtiquetas()
                    Me.Cursor = Cursors.Default
                Else
                    show_message("Error", "Ocurrio un error al momento de guardar, por favor vuelva a guardar")
                    Me.Cursor = Cursors.Default
                    Return
                End If
            End If
        ElseIf Proceso = "SALIDA" Then
            dtTabla = objBU.Recuperar_Totales_SalidaNaveEnProceso(IdSalidaNave, IdNave)
            For Each row As DataRow In dtTabla.Rows
                n_Atados_Correctos = row.Item("ATADOS")
                n_Pares_Correctos = row.Item("PARES")
                n_lotes_Correctos = row.Item("LOTES")
            Next

            If n_Atados_Correctos = 0 And n_Pares_Correctos = 0 And n_lotes_Correctos = 0 Then
                show_message("Error", "No se ha encontrado ningun lote valido a embarcar para esta salida de nave")
                Return
            End If


            If grdIncorrecto.Rows.Count > 0 Or lparesEmbarcados.Count <> n_Pares_Correctos Or lAtadosEmbarcados.Count <> n_Atados_Correctos _
                Or lLotesEmbarcados.Count <> n_lotes_Correctos.ToString Then

                show_message("Advertencia", "Aun cuentas con faltante y/o errores en tu lectura, descarta los atados o termina de leer correctamente para poder guardar.")
            Else
                Me.Cursor = Cursors.WaitCursor
                Try
                    MensajeResultado = FinalizarSalidaDeNaves(n_Pares_Correctos, n_Atados_Correctos, n_lotes_Correctos)
                Catch ex As Exception
                    show_message("Error", "El proceso de salida de naves no se guardo correctamente, muestre el siguiente mensaje al administrador del sistema: " + ex.Message)
                    Me.Cursor = Cursors.Default
                End Try

                If MensajeResultado <> "EXITO" Then
                    show_message("Error", "Ocurrio un error al momento de guardar, por favor vuelva a guardar")
                    Me.Cursor = Cursors.Default
                    Return
                Else
                    show_message("Exito", "El proceso de salida se finalizo correctamente")
                    cmbNaves.SelectedIndex = 0

                    ImprimirReporte_Salida_Naves(IdSalidaNave, IdNave, Entidades.SesionUsuario.UsuarioSesion.PUserNombreReal.ToString)

                    Limpiar_Variables()
                    Limpiar_Controles()
                    LlenarEtiquetas()
                    Me.Cursor = Cursors.Default
                End If
            End If
        End If
        Me.Cursor = Cursors.Default
    End Sub


    ''' <summary>
    ''' FINALIZA EL PROCESO DE SALIDA DE PRODUCTO DE NAVES
    ''' </summary>
    ''' <param name="TotalPares">TOTAL PARES EMBARCADOS</param>
    ''' <param name="TotalAtados">TOTAL ATADOS EMBARCADOS</param>
    ''' <param name="TotalLotes">TOTAL LOTES EMBARCADOS</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function FinalizarSalidaDeNaves(ByVal TotalPares, TotalAtados, TotalLotes)
        Dim objBU As New Negocios.SalidaNavesBU
        Dim dtTabla As New DataTable
        dtTabla = objBU.FinalizarSalidaNaves(IdSalidaNave, TotalPares, TotalAtados, TotalLotes, IdNave)
        For Each row As DataRow In dtTabla.Rows
            Return row.Item(0)
        Next
    End Function


    Private Sub Limpiar_Controles()
        cmbNaves.Enabled = True
        cmbNaves.SelectedIndex = 0

        cmbProceso.Enabled = True
        cmbProceso.SelectedIndex = 0

        grdIncorrecto.DataSource = Nothing
        grdLectura.DataSource = Nothing

        grdIncorrecto.DataSource = dtTablaGridErrores
        grdLectura.DataSource = dtTablaGridCodigosParesEscaneados

        btnGuardar.Enabled = False

        lblTotalPares.Text = 0
        lblTotalAtados.Text = 0
        lblTotalLotes.Text = 0

        LlenarEtiquetas()

        Me.Cursor = Cursors.Default

    End Sub

    ''' <summary>
    ''' lIMPIA TODAS LAS VARIABLES DE EL FORMULARIO
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Limpiar_Variables()

        lAtados.Clear()
        lAtadosBien.Clear()
        lAtadosErroneos.Clear()
        lAtadosDescartados.Clear()
        lAtadosEmbarcados.Clear()
        llotes.Clear()
        llotesBien.Clear()
        lLotesErroneos.Clear()
        lLotesDescartados.Clear()
        lLotesEmbarcados.Clear()
        llotesSinTerminar.Clear()
        llotesNoEmbarcados.Clear()
        lpares.Clear()
        lparesBien.Clear()
        lparesErroneos.Clear()
        lparesDescartados.Clear()
        lparesEmbarcados.Clear()
        lcarritos.Clear()

        lCodigosErroneos.Clear()
        lClientesValidacionParXPar_Nave.Clear()
        lClientesValidacionParXPar_Lote.Clear()
        lLotesParXPar.Clear()

        IdNave = 0
        IdOperador = 0
        n_lotes = 0
        n_Atados_Descartados = 0
        n_Pares_Pares_Descartados = 0
        n_lotes_Descartados = 0
        n_Atados_Correctos = 0
        n_Pares_Correctos = 0
        n_lotes_Correctos = 0
        IdSalidaNave = 0
        NumAtadoActual = 0
        AñoAtadoActual = 0
        NparesAtadoActual = 0
        NparesAtadoActualLeeidos = 0
        IdClienteAtadoActual = 0
        loteAtadoActual = 0

        AtadoActual = "0"
        DescripcionAtadoActual = String.Empty
        DescripcionParActual = String.Empty
        IdProductoParActual = String.Empty
        TallaParActual = String.Empty
        TipoCodigo = String.Empty
        ResultadoLoteCompleto = String.Empty
        CadenaCapturada = String.Empty
        CodigoPar = String.Empty

        dtParesCodigoCliente.Clear()
        dtTablaGridCodigosParesEscaneados.Clear()
        dtTablaGridErrores.Clear()
        dtTalla_DescripcionParAgregado.Clear()
        dtTablaAtados.Clear()
        dtTablaAtados_EntradaDeLotes.Clear()

        n = 0
        n_iniciar = 0
        Numero_Par = 0
        IdCarritoActual = 0

        lAtadosCorrespondientes.Clear()
        lParesAtadoActual.Clear()
        lAtadosDeSalida.Clear()
        lListaAcciones.Clear()

        Tipo_Nave_Maquila_o_Interna = False
        Atado_Incluido_SalidaNave_en_Curso = False
        LecturaParXPar = False
        TipoEscaneoPar_CodInterno_CodCliente = False
        par_valido = False
        salida_pendiente = False
        ResultadoHashSet_add = False
        campos_vacios = True

        Proceso = cmbProceso.Text
    End Sub
#End Region

#Region "ENTRADA DE PRODUCTO A ALMACEN"

    ''' <summary>
    ''' MANDA LLAMAR EL METODO PARA POBLAR EL GRID LECTURA 
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Recuperar_Informacion_DeLotes_Embarcados_Y_Asignarla_A_Sus_Controles(ByVal Estado_SalidaNave As String)
        'VALIDAMOS EL ESTADO DEL LOTE
        Dim objSalidaBU As New Negocios.SalidaNavesBU
        objSalidaBU.EliminarErroresDeLaLectura(IdNave, IdSalidaNave, LTrim(RTrim(cmbProceso.Text)))

        RecuperarInformacionDeLotesEmbarcados_Y_Asignarla_al_Grid_Errores()

        RecuperarInformacionDeLotesEmbarcados_Y_Asignarla_al_Grid_Lectura()

        Recuperar_Totales_de_Producto_Y_Asignarlo_A_Las_Etiquetas_Correspondientes()

        Dim objBU As New Negocios.EntradaProductoBU
        Dim dtTablaDetalleCarritos As New DataTable

        w = 1
        Do While w = 1
            Try
                dtTablaDetalleCarritos = objBU.PoblarDetalleCarritos(IdSalidaNave, IdNave)
                w = 0
            Catch ex As Exception
                If ex.Message.Contains(" interbloqueo ") = False Then
                    w = 0
                End If
                EscribirErrorEnBiacora(ex.Message, "Recuperar_Informacion_DeLotes_Embarcados_Y_Asignarla_A_Sus_Controles(), objBU.PoblarDetalleCarritos")
            End Try
        Loop

        If dtTablaDetalleCarritos.Rows.Count >= 1 Then
            If IsDBNull(dtTablaDetalleCarritos.Rows(0).Item(0)) = False Then
                For Each row As DataRow In dtTablaDetalleCarritos.Rows
                    lcarritos.Add(row.Item(0))
                Next
            End If
        End If

    End Sub

    ''' <summary>
    ''' RECUPERA LOS TOTALES DE PARES EMBARCADOS, LOTES EMBARCADOS Y ATADOS EMBARCADOS Y LOS ASIGNA A SUS ETIQUETAS CORRESPONDIENTES
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Recuperar_Totales_de_Producto_Y_Asignarlo_A_Las_Etiquetas_Correspondientes()
        If Tipo_Nave_Maquila_o_Interna = True Then Return
        Dim objBU As New Negocios.EntradaProductoBU
        Dim dtTabla As New DataTable

        w = 1
        Do While w = 1
            Try
                dtTabla = objBU.RecuperarTotalesdeSalidaNaveEmbarcada(IdSalidaNave)
                w = 0
            Catch ex As Exception
                If ex.Message.Contains(" interbloqueo ") = False Then
                    w = 0
                End If
                EscribirErrorEnBiacora(ex.Message, "Recuperar_Totales_de_Producto_Y_Asignarlo_A_Las_Etiquetas_Correspondientes()")
            End Try
        Loop

        lblTotalPares.Text = CInt(dtTabla.Rows(0).Item("Total pares")).ToString("N0")
        lblTotalAtados.Text = CInt(dtTabla.Rows(0).Item("Total atados")).ToString("N0")
        lblTotalLotes.Text = CInt(dtTabla.Rows(0).Item("Total lotes")).ToString("N0")
    End Sub

    ''' <summary>
    ''' RECUPERA LOS PARES EMBARCADOS EN UN LOTE DETERMINADO Y LOS AGREGA AL GRID LECTURA COMO FALTANTES DE LEER
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub RecuperarInformacionDeLotesEmbarcados_Y_Asignarla_al_Grid_Lectura()
        Dim objBU As New Negocios.EntradaProductoBU
        Dim objBU2 As New Negocios.SalidaNavesBU
        Dim dtTabla As New DataTable
        Dim DatosAtado2 As New Entidades.CapturaAtadoValido


        w = 1
        Do While w = 1
            Try
                dtTabla = objBU.RecuperaParesDeEntradaLotesEnProceso(IdSalidaNave, IdNave)
                w = 0
            Catch ex As Exception
                If ex.Message.Contains(" interbloqueo ") Then
                    EscribirErrorEnBiacora(ex.Message, "RecuperarInformacionDeLotesEmbarcados_Y_Asignarla_al_Grid_Lectura(), objBU.RecuperaParesDeEntradaLotesEnProceso")
                Else
                    w = 0
                End If
            End Try
        Loop

        For Each row As DataRow In dtTabla.Rows
            llotes.Add(CStr(row.Item("LOTE")) + "-" + CStr(row.Item("AÑO")) + "-" + IdNave.ToString)
            lLotesErroneos.Add(CStr(row.Item("LOTE")) + "-" + CStr(row.Item("AÑO")) + "-" + IdNave.ToString)
            lLotesDescartados.Add(CStr(row.Item("LOTE")) + "-" + CStr(row.Item("AÑO")) + "-" + IdNave.ToString)

            lAtados.Add(CStr(row.Item("LOTE")) + "-" + CStr(row.Item("AÑO")) + "-" + IdNave.ToString + "-" + CStr(row.Item("ATADO")))
            lpares.Add(CStr(row.Item("ATADO")) + "-" + CStr(row.Item("PAR")) + "-" + CStr(row.Item("N_PAR")))

            'AGREGAMOS LOS PARS A SU LISTA CORRESPONDIENTE, YA SEA PARA PARES ERRONOS O PARES CORRECTOS
            If (row.Item("R_PAR")) > 1 Then
                lparesErroneos.Add(CStr(row.Item("ATADO")) + "-" + CStr(row.Item("PAR")) + "-" + CStr(row.Item("N_PAR")))
                lparesBien.Remove(CStr(row.Item("ATADO")) + "-" + CStr(row.Item("PAR")) + "-" + CStr(row.Item("N_PAR")))
            Else
                lparesBien.Add(CStr(row.Item("ATADO")) + "-" + CStr(row.Item("PAR")) + "-" + CStr(row.Item("N_PAR")))
                lparesErroneos.Remove(CStr(row.Item("ATADO")) + "-" + CStr(row.Item("PAR")) + "-" + CStr(row.Item("N_PAR")))
            End If

            'AGREGAMOS LOS ATADOS A SUS RESPECTIVAS LISTAS, YA SEAN ATADOS CORRECTOS O ATADOS ERRONEOS
            If IsDBNull(row.Item("R_ATADO")) Then
                lAtadosErroneos.Add(CStr(row.Item("LOTE")) + "-" + CStr(row.Item("AÑO")) + "-" + CStr(row.Item("IDNAVE")) + "-" + CStr(row.Item("ATADO")))
                lAtadosBien.Remove(CStr(row.Item("LOTE")) + "-" + CStr(row.Item("AÑO")) + "-" + CStr(row.Item("IDNAVE")) + "-" + CStr(row.Item("ATADO")))

            ElseIf row.Item("R_ATADO") > 1 Then
                lAtadosErroneos.Add(CStr(row.Item("LOTE")) + "-" + CStr(row.Item("AÑO")) + "-" + CStr(row.Item("IDNAVE")) + "-" + CStr(row.Item("ATADO")))
                lAtadosBien.Remove(CStr(row.Item("LOTE")) + "-" + CStr(row.Item("AÑO")) + "-" + CStr(row.Item("IDNAVE")) + "-" + CStr(row.Item("ATADO")))

            Else
                lAtadosBien.Add(CStr(row.Item("LOTE")) + "-" + CStr(row.Item("AÑO")) + "-" + CStr(row.Item("IDNAVE")) + "-" + CStr(row.Item("ATADO")))
                lAtadosErroneos.Remove(CStr(row.Item("LOTE")) + "-" + CStr(row.Item("AÑO")) + "-" + CStr(row.Item("IDNAVE")) + "-" + CStr(row.Item("ATADO")))
            End If

            If IsDBNull(row.Item("R_ATADO")) Then
                row.Item("R_ATADO") = 2
            End If

            PoblarGridLectura(CInt(row.Item("LOTE")), CInt(row.Item("N_ATADO")), CStr(row.Item("ATADO")), CStr(row.Item("PAR")), CStr(row.Item("DESCRIPCION")), CStr(row.Item("TALLA")), _
                              CStr(row.Item("R_ATADO")), row.Item("AÑO"))
        Next
        colorear_grid(grdLectura, dtTabla.Rows.Count)

        'AHORA RECUPERAMOS LOS ATADOS ESCANEADOS Y SU ESTADO PARA ACTUALIZAR LA TABLA ERRORES
        Dim dtTabla2 As New DataTable
        w = 1
        Do While w = 1
            Try
                dtTabla2 = objBU.RecuperarResultadosDeAtadosLeeidosEnProduccionSalidaNAves_Entrada_De_Producto(IdSalidaNave, IdNave)
                Dim tmpAtado As String = ""
                Dim tmpestado As Integer = 0
                Dim tmpprecio As Double = 0
                If externa Then

                    For Each row As DataRow In dtTabla2.Rows
                        If Not tmpAtado = row("Atado").ToString Then
                            tmpAtado = row("Atado").ToString
                            DatosAtado2 = VerificarAtadoValido_RecuperarDatosLote(tmpAtado)
                            tmpprecio = objBU2.VerificarAtadoValido_RecuperaPrecioLote(DatosAtado2.PLote, DatosAtado2.PAño, DatosAtado2.PIdNAve)
                            If tmpprecio > 0 Then
                                tmpestado = 0 'Estatus indica que el proceso puede seguir normal cuenta con precio
                            Else
                                tmpestado = 911 'Estatus indica que no tiene precio el lote 
                                row("RESULTADO") = tmpestado
                            End If
                        Else
                            row("RESULTADO") = tmpestado
                        End If
                    Next
                End If
                w = 0
            Catch ex As Exception
                If ex.Message.Contains(" interbloqueo ") = False Then
                    w = 0
                End If
                EscribirErrorEnBiacora(ex.Message, "RecuperarInformacionDeLotesEmbarcados_Y_Asignarla_al_Grid_Lectura(), objBU.RecuperarResultadosDeAtadosLeeidosEnProduccionSalidaNAves_Entrada_De_Producto ")
            End Try
        Loop

        Dim dtNumeroDeAtadosEmbarcados As New DataTable
        w = 1
        Do While w = 1
            Try
                dtNumeroDeAtadosEmbarcados = objBU.RecuperarCantidadDeAtadosEmbarcados(IdSalidaNave)
                w = 0
            Catch ex As Exception
                If ex.Message.Contains(" interbloqueo ") = False Then
                    w = 0
                End If
                EscribirErrorEnBiacora(ex.Message, "RecuperarInformacionDeLotesEmbarcados_Y_Asignarla_al_Grid_Lectura(),  objBU.RecuperarCantidadDeAtadosEmbarcados")
            End Try
        Loop

        For Each row In dtTabla2.Rows
            If IsDBNull(row.item("RESULTADO")) Then
                row.item("RESULTADO") = 0
            ElseIf row.item("RESULTADO") > 1 Then
                poblarGrigErroneos(row.item("LOTE"), row.item("#"), row.item("ATADO"), row.item("DESCRIPCION"), row.item("RESULTADO"), row.item("AÑO"))

                If Tipo_Nave_Maquila_o_Interna = False Then
                    If row.Item("RESULTADO") >= 9 Then
                        llotesNoEmbarcados.Add(CStr(row.item("LOTE")) + "-" + CStr(row.item("AÑO")) + "-" + IdNave.ToString)
                        For cont = grdIncorrecto.Rows.Count - 1 To 0 Step -1
                            If grdIncorrecto.Rows(cont).Cells("Atado").Text = row.item("ATADO") Then
                                grdIncorrecto.Rows(cont).Cells("Estado").Value = row.item("RESULTADO")
                                cont = 0
                            End If
                        Next
                    End If
                End If

                If row.item("RESULTADO") > 4 And row.item("RESULTADO") < 9 Then
                    llotesSinTerminar.Add(CStr(row.item("LOTE")) + "-" + CStr(row.item("AÑO")) + "-" + IdNave.ToString)
                    For cont = grdIncorrecto.Rows.Count - 1 To 0 Step -1
                        If grdIncorrecto.Rows(cont).Cells("Atado").Text = row.item("ATADO") Then
                            grdIncorrecto.Rows(cont).Cells("Estado").Value = row.item("RESULTADO")
                            cont = 0
                        End If
                    Next
                End If

            ElseIf row.item("RESULTADO") = 1 Then
                For cont = grdIncorrecto.Rows.Count - 1 To 0 Step -1
                    If grdIncorrecto.Rows(cont).Cells("Atado").Text = row.item("ATADO") Then
                        grdIncorrecto.Rows(cont).Delete(True)
                    End If
                Next
            End If
        Next

        Dim objBUSalidaNaves As New Negocios.SalidaNavesBU

        'FINALMENTE VERIFICAMOS SU UN LOTE HA SIDO ESCANEADO POR COMPLETO.
        For Each item In llotes
            If llotesNoEmbarcados.Contains(item) = False Or Tipo_Nave_Maquila_o_Interna = True Then
                If llotesSinTerminar.Contains(item) = False Then
                    Dim q As Integer = 0
                    For Each row As UltraGridRow In grdIncorrecto.Rows
                        If item.StartsWith(row.Cells("LOTE").Text) Then
                            q += 1
                        End If
                    Next

                    Dim dtpares As New DataTable
                    Dim codigosplit As String()
                    codigosplit = item.Split("-")

                    If q = 0 Then
                        lLotesErroneos.Remove(item)
                        lLotesDescartados.Remove(item)
                        ResultadoHashSet_add = llotesBien.Add(item)

                        w = 1
                        Do While w = 1
                            Try
                                dtpares = objBUSalidaNaves.RecuperarPares_De_Lote(codigosplit(0), codigosplit(1), codigosplit(2))
                                w = 0
                            Catch ex As Exception
                                If ex.Message.Contains(" interbloqueo ") = False Then
                                    w = 0
                                End If
                                EscribirErrorEnBiacora(ex.Message, "RecuperarInformacionDeLotesEmbarcados_Y_Asignarla_al_Grid_Lectura(),  objBUSalidaNaves.RecuperarPares_De_Lote")
                            End Try
                        Loop

                        For Each row As DataRow In dtpares.Rows
                            lLotesEmbarcados.Add(item)
                            lAtadosEmbarcados.Add(item + "-" + row.Item(1))
                            lparesEmbarcados.Add(item + "-" + row.Item(1) + "-" + row.Item(0))

                            lLotesDescartados.Remove(item)
                            lAtadosDescartados.Remove(item + "-" + row.Item(1))
                            lparesDescartados.Remove(item + "-" + row.Item(1) + "-" + row.Item(0))
                        Next
                        Dim objBUEntrada As New Negocios.EntradaProductoBU

                        w = 1
                        Do While w = 1
                            Try
                                'ACTUALIZAMOS EL ESTADO DE LOS PARES, ENTREGADO = 1, REGRESADO = 0
                                objBUEntrada.Actualizar_Estado_De_Pares_Del_Lote_A_Entregado(IdSalidaNave, codigosplit(0), codigosplit(1), Tipo_Nave_Maquila_o_Interna, IdNave)
                                w = 0
                            Catch ex As Exception
                                If ex.Message.Contains(" interbloqueo ") = False Then
                                    w = 0
                                End If
                                EscribirErrorEnBiacora(ex.Message, "RecuperarInformacionDeLotesEmbarcados_Y_Asignarla_al_Grid_Lectura(),  objBUEntrada.Actualizar_Estado_De_Pares_Del_Lote_A_Entregado")
                            End Try
                        Loop

                    Else
                        w = 1
                        Do While w = 1
                            Try
                                w = 0
                                dtpares = objBUSalidaNaves.RecuperarPares_De_Lote(codigosplit(0), codigosplit(1), codigosplit(2))
                            Catch ex As Exception
                                If ex.Message.Contains(" interbloqueo ") = False Then
                                    w = 0
                                End If
                                EscribirErrorEnBiacora(ex.Message, "RecuperarInformacionDeLotesEmbarcados_Y_Asignarla_al_Grid_Lectura(),  objBUSalidaNaves.RecuperarPares_De_Lote")
                            End Try
                        Loop

                        For Each row As DataRow In dtpares.Rows
                            lLotesEmbarcados.Remove(item)
                            lAtadosEmbarcados.Remove(item + "-" + row.Item(1))
                            lparesEmbarcados.Remove(item + "-" + row.Item(1) + "-" + row.Item(0))

                            lLotesDescartados.Add(item)
                            lAtadosDescartados.Add(item + "-" + row.Item(1))
                            lparesDescartados.Add(item + "-" + row.Item(1) + "-" + row.Item(0))
                        Next
                    End If
                End If
            End If
        Next

        colorear_grid(grdIncorrecto, llotes.Count)
        LlenarEtiquetas()
    End Sub


    ''' <summary>
    ''' RECUPERA LA INFORMACION DE LOS ATADOS DE LOS LOTES EMBARCADOS PARA ASIGNARLA AL GRID ERRORES Y LA INFORMACION DE LOS PARES EMBARCADOS PARA
    ''' ASIGNARLA AL GRID LECTURA
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub RecuperarInformacionDeLotesEmbarcados_Y_Asignarla_al_Grid_Errores()
        Dim objBU As New Negocios.EntradaProductoBU
        Dim objBU2 As New Negocios.SalidaNavesBU
        Dim dtTabla As New DataTable
        Dim DatosAtado2 As New Entidades.CapturaAtadoValido

        'Agregar_Atados_De_Faltantes_a_Lotes_incompletos_en_Entrada_De_Nave()
        w = 1
        Do While w = 1
            Try
                dtTablaAtados_EntradaDeLotes = objBU.RecuperarInformacionDeLotesEmbarcados_Atados_Leidos(IdSalidaNave, IdNave)

                Dim tmpAtado As String = ""
                Dim tmpestado As Integer = 0
                Dim tmpprecio As Double = 0
                If externa Then

                    For Each row As DataRow In dtTablaAtados_EntradaDeLotes.Rows
                        If Not tmpAtado = row("Atado").ToString Then
                            tmpAtado = row("Atado").ToString
                            DatosAtado2 = VerificarAtadoValido_RecuperarDatosLote(tmpAtado)
                            tmpprecio = objBU2.VerificarAtadoValido_RecuperaPrecioLote(DatosAtado2.PLote, DatosAtado2.PAño, DatosAtado2.PIdNAve)
                            If tmpprecio > 0 Then
                                tmpestado = 0 'Estatus indica que el proceso puede seguir normal cuenta con precio
                            Else
                                tmpestado = 911 'Estatus indica que no tiene precio el lote 
                                row("Estado") = tmpestado
                            End If
                        Else
                            row("Estado") = tmpestado
                        End If
                    Next
                End If

                w = 0
            Catch ex As Exception
                If ex.Message.Contains(" interbloqueo ") = False Then
                    w = 0
                End If
                EscribirErrorEnBiacora(ex.Message, "RecuperarInformacionDeLotesEmbarcados_Y_Asignarla_al_Grid_Errores(), objBU.RecuperarInformacionDeLotesEmbarcados_Atados_Leidos")
            End Try
        Loop

        w = 1
        Do While w = 1
            Try
                dtTabla = objBU.RecuperarInformacionDeLotesEmbarcados_Atados_Leidos(IdSalidaNave, IdNave)
                Dim tmpAtado As String = ""
                Dim tmpestado As Integer = 0
                Dim tmpprecio As Double = 0
                If externa Then

                    For Each row As DataRow In dtTabla.Rows
                        If Not tmpAtado = row("Atado").ToString Then
                            tmpAtado = row("Atado").ToString
                            DatosAtado2 = VerificarAtadoValido_RecuperarDatosLote(tmpAtado)
                            tmpprecio = objBU2.VerificarAtadoValido_RecuperaPrecioLote(DatosAtado2.PLote, DatosAtado2.PAño, DatosAtado2.PIdNAve)
                            If tmpprecio > 0 Then
                                tmpestado = 0 'Estatus indica que el proceso puede seguir normal cuenta con precio
                            Else
                                tmpestado = 911 'Estatus indica que no tiene precio el lote 
                                row("Estado") = tmpestado
                            End If
                        Else
                            row("Estado") = tmpestado
                        End If
                    Next
                End If
                w = 0
            Catch ex As Exception
                If ex.Message.Contains(" interbloqueo ") = False Then
                    w = 0
                End If
                EscribirErrorEnBiacora(ex.Message, "RecuperarInformacionDeLotesEmbarcados_Y_Asignarla_al_Grid_Errores(), objBU.RecuperarInformacionDeLotesEmbarcados_Atados_Leidos")
            End Try
        Loop

        grdIncorrecto.DataSource = Nothing
        grdIncorrecto.DataSource = dtTabla

        For Each row As DataRow In dtTablaAtados_EntradaDeLotes.Rows
            lAtadosDeSalida.Add(CStr(row.Item("Lote")) + "-" + CStr(row.Item("# En lote")) + "-" + IdNave.ToString + "-" + CStr(row.Item("Atado")))
            'VERIFICAMOS SI ES NECESARIO LEER PAR POR PAR TODO EL LOTE
            LecturaParXPar = ValidarLecturaPar_por_Par(row.Item("Lote"), row.Item("Año"), IdNave)
        Next

    End Sub


    ''' <summary>
    ''' VELIDA SI EL ATADO ESCANEADO ESTA DENTRO DE LOS ATADOS DE LA SALIDA DE NAVE A LA QUE SE LE DARA ENTRADA
    ''' </summary>
    ''' <param name="Atado">ATADO A VERIFICAR</param>
    ''' <param name="Id_Salida_Nave">ID DE LA SALIDA DE NAVE A LA QUE SE LE DARA ENTRADA</param>
    ''' <remarks></remarks>
    Private Sub ValidarAtadoPertenecienteALaSalidaDeNavesEnProceso(ByVal Atado As String, ByVal Id_Salida_Nave As Integer)
        Dim objBU As New Negocios.EntradaProductoBU
        Dim dtAtado_Incluido As New DataTable

        w = 1
        Do While w = 1
            Try
                dtAtado_Incluido = objBU.ValidarAtadoPertenecienteALaSalidaDeNavesEnProceso(Atado, Id_Salida_Nave, IdNave)
                w = 0
            Catch ex As Exception
                If ex.Message.Contains(" interbloqueo ") = False Then
                    w = 0
                End If
                EscribirErrorEnBiacora(ex.Message, "ValidarAtadoPertenecienteALaSalidaDeNavesEnProceso()")
            End Try
        Loop

        If dtAtado_Incluido.Rows.Count = 0 Then
            TipoCodigo = "-"
            Atado_Incluido_SalidaNave_en_Curso = False

        Else
            Atado_Incluido_SalidaNave_en_Curso = True
            TipoCodigo = dtAtado_Incluido.Rows(0).Item(1)
        End If
    End Sub

    ''' <summary>
    ''' PROCESO PARA CUANDO SE ESCANEA UN ATADO DE UN LOTE COMPLETO PARA UNA ENTRADA DE LOTES
    ''' </summary>
    ''' <param name="datosatado">CLASE CON LA INFORMACION DEL ATADO LEÍDO</param>
    ''' <remarks></remarks>
    Public Sub Proceso_Para_Lote_completo_Entrada_Lotes(ByVal datosatado As Entidades.CapturaAtadoValido)

        'LIMPIAMOS LA TABLA DE LOS PARES CON CODIGOS DE CLIENTE
        dtParesCodigoCliente.Clear()

        'ELIMINAMOS LOS PARES DEL ATADO EN EL GRID LECTURA EN CASO DE YA HABER SIDO ESCANEADO 
        EliminarParesDeAtadoYaEscaneado(datosatado.PIdAtado, datosatado.PLote, datosatado.PAño)

        'ACTUALIZAMOS EL ATADO CON EL QUE SE ESTARA TRABAJANDO
        AtadoActual = datosatado.PIdAtado
        AñoAtadoActual = datosatado.PAño
        loteAtadoActual = datosatado.PLote
        IdClienteAtadoActual = datosatado.PIdCliente
        NparesAtadoActual = datosatado.PN_Pares
        NparesAtadoActualLeeidos = 0
        DescripcionAtadoActual = datosatado.PDescripcion
        NumAtadoActual = datosatado.PN_AtadoEscaneado

        'AGREGAMOS LOS ATADOS DEL LOTE AL GRID COMO INCOMPLETOS
        AgregarAtadosDelLoteAlGridErrores_Entrada_Naves(datosatado.PLote, datosatado.PAño, IdNave)

        n = 0
        For cont = grdIncorrecto.Rows.Count - 1 To 0 Step -1
            If grdIncorrecto.Rows(cont).Cells("# En lote").Text = NumAtadoActual Then
                NumAtadoActual = grdIncorrecto.Rows(cont).Cells("# en lote").Text
                n += 1
                cont = 0
            End If
        Next

        'ELIMINAMOS LOS PARES SOBRANTES DEL ATADO EN CASO DE HABER SIDO ANTERIORMENTE Y ACRUALIZAMOS EL ESTATUS DE LOS PARES DE ESTE ATADO A NULLO
        Reiniciar_Atado_Escaneado_Anteriormente_Entrada_De_Lotes()

        'AGREGAMOS EL ATADO A LA LISTA DE ATADOS LEEIDOS
        lAtados.Add(loteAtadoActual.ToString + "-" + AñoAtadoActual.ToString + "-" + IdNave.ToString + "-" + AtadoActual.ToString)

        lParesAtadoActual.Clear()

        'AGREGAMOS EL LOTE A LA LISTA DE LOTES CON ERRORES LEEIDOS YA QUE NO ESTA COMPLETO
        lLotesErroneos.Add(loteAtadoActual.ToString + "-" + AñoAtadoActual.ToString + "-" + IdNave.ToString)
        lLotesDescartados.Add(loteAtadoActual.ToString + "-" + AñoAtadoActual.ToString + "-" + IdNave.ToString)

        'AHORA VERIFICAMOS SI EL TIPO DE LECTUA ES DE PAR POR PAR O SOLO POR ATADO
        Verificar_Atado_Leido_VS_TipoLecturaParOAtado(AtadoActual)

        'LLENAMOS ETIQUETAS
        LlenarEtiquetas()

    End Sub


    ''' <summary>
    ''' ELIMINA LOS PARES SOBRANTES Y ACTUALIZA EL ESTATUS DE LOS PARES Y EL ATADO COMO SI NUNCA SE UBIERAN LEÍDO EN LA TABLA ALMACEN.SALIDANAVESDETALLES
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Reiniciar_Atado_Escaneado_Anteriormente_Entrada_De_Lotes()
        Dim objBU As New Negocios.EntradaProductoBU

        w = 1
        Do While w = 1
            Try
                objBU.Eliminar_ParesSobrantes_De_Atado_SalidaNavesDetalles(IdSalidaNave, AtadoActual, IdNave)
                w = 0
            Catch ex As Exception
                If ex.Message.Contains(" interbloqueo ") = False Then
                    w = 0
                End If
                EscribirErrorEnBiacora(ex.Message, "Reiniciar_Atado_Escaneado_Anteriormente_Entrada_De_Lotes, objBU.Eliminar_ParesSobrantes_De_Atado_SalidaNavesDetalles")
            End Try
        Loop

        w = 1
        Do While w = 1
            Try
                objBU.Eliminar_Estado_De_Pares_Atado_Para_Entrada_De_Producto_SalidaNavesDetalles(IdSalidaNave, AtadoActual, ResultadoLoteCompleto, IdNave)
                w = 0
            Catch ex As Exception
                If ex.Message.Contains(" interbloqueo ") = False Then
                    w = 0
                End If
                EscribirErrorEnBiacora(ex.Message, "Reiniciar_Atado_Escaneado_Anteriormente_Entrada_De_Lotes, objBU.Eliminar_Estado_De_Pares_Atado_Para_Entrada_De_Producto_SalidaNavesDetalles")
            End Try
        Loop

    End Sub

    ''' <summary>
    ''' RECUPERA LOS PARES DE UN ATADO CUANDO SE ESTA ESCANEANDO ATADO POR ATADO COM LA INFORMACION NECESARIA PARA ESCRIBIR EN ALMACEN.SALIDANAVESDETALLES
    ''' </summary>
    ''' <param name="IdAtado">ID DEL ATADO DEL QUE SE RECUPERARAN LOS PARES</param>
    ''' <remarks></remarks>
    Public Sub Recuperar_dtPares_Para_de_tabla_SalidaNavesDetalles(ByVal IdAtado As String)
        Dim objBU As New Negocios.EntradaProductoBU
        w = 1
        Do While w = 1
            Try
                dtParesCodigoCliente = objBU.Recuperar_dtPares_Para_de_tabla_SalidaNavesDetalles(IdAtado, IdSalidaNave, IdNave)
                w = 0
            Catch ex As Exception
                If ex.Message.Contains(" interbloqueo ") = False Then
                    w = 0
                End If
                EscribirErrorEnBiacora(ex.Message, "Recuperar_dtPares_Para_de_tabla_SalidaNavesDetalles")
            End Try
        Loop
    End Sub

    ''' <summary>
    ''' METODO QUE VALIDA SI LA PLATAFORMA ESCANEADA ESTA ASIGNADA A LA NAVE EN LA QUE SE ESTA REALIZANDO LA ENTRADA DE PRODUCTO
    ''' </summary>
    ''' <param name="IdCarrito">ID DE LA PLATAFORMA A VALIDAR</param>
    ''' <param name="IdNave">ID DE LA NAVE</param>
    ''' <param name="Id_Almacen">ID DEL ALMACEN EN EL QUE SE VERIFICARA SI EXISTE LA PLARAFORMA</param>
    ''' <returns>VALOR BOOLEANO PARA VER SI LA PLATAFORMA EXISTE O NO</returns>
    ''' <remarks></remarks>
    Private Function ValidarCarritoPerteneciente_a_Nave(ByVal IdCarrito As Integer, ByVal IdNave As Integer, ByVal Id_Almacen As Integer) As Boolean
        Dim objBU As New Negocios.EntradaProductoBU
        Dim CarritoValido As Boolean
        w = 1
        Do While w = 1
            Try
                CarritoValido = objBU.ValidarCarritoPerteneciente_a_Nave(IdCarrito, IdNave, Id_Almacen)
                w = 0
            Catch ex As Exception
                If ex.Message.Contains(" interbloqueo ") = False Then
                    w = 0
                End If
                EscribirErrorEnBiacora(ex.Message, "ValidarCarritoPerteneciente_a_Nave()")
            End Try
        Loop

        Return CarritoValido
    End Function

    Private Sub CapturarParAtados_EntradaNave(ByVal codigo As String)

        Dim DatosAtado As New Entidades.CapturaAtadoValido
        Dim objBU As New SalidaNavesBU
        Dim CarritoValido As Boolean
        Carrito_Actual_Split = codigo.Split("-")
        If codigo.Length >= 6 And codigo.Length <= 8 And Not IsNumeric(codigo) And codigo.Contains("-") Then 'POSIBLE CODIGO DE CARRITO

            If Carrito_Actual_Split.Length = 2 And Carrito_Actual_Split(0) = "PLAT" Then
                CarritoValido = ValidarCarritoPerteneciente_a_Nave(CInt(Carrito_Actual_Split(1)), CInt(cboxNaveAlmacen.SelectedValue), (cboxAlmacen.SelectedValue))

                If CarritoValido = False Then
                    ReproducrirSonidoError()
                    lCodigosErroneos.Add("Código erroneo:" + codigo + " * Atado actual: " + AtadoActual.ToString + " * Causa: Código de plataforma invalido.")
                    Return
                Else
                    If AtadoActual <> "0" Then
                        ActualizarEstatusDeAtado()
                        AtadoActual = "0"
                    End If
                    IdCarritoActual = CInt(Carrito_Actual_Split(1))
                    lcarritos.Add(IdCarritoActual)
                    lblTotalCarritos.Text = lcarritos.Count.ToString("N0")
                End If
            End If

        ElseIf codigo.Length >= 10 And codigo.Length <= 13 And IsNumeric(codigo) Then
            'SÍ NO SE HAN LEÍDO PLATAFORMAS TODO CODIGO ESCANEADO SERA MARCADO COMO ERRONEO
            If IdCarritoActual = 0 Then
                ReproducrirSonidoError()
                lCodigosErroneos.Add("Código erroneo:" + codigo + " * Atado actual: " + AtadoActual.ToString + " * Causa: Sin plataforma.")
                Return
            End If

            'SÍ EL ATADO ESCANEADO SE ESCANEA DOS VECES SE REGRESA PARA SEGUIR ESCANEANDO
            If AtadoActual = LTrim(RTrim(codigo)) Then Return

            'VERIFICA SI EL CODIGO ES DE UN ATADO VALIDO
            DatosAtado = VerificarAtadoValido_RecuperarDatosLote(codigo)
            If externa Then
                precio = objBU.VerificarAtadoValido_RecuperaPrecioLote(DatosAtado.PLote, DatosAtado.PAño, DatosAtado.PIdNAve)
                If precio > 0 Then
                    estatusAtado = 0 'Estatus indica que el proceso puede seguir normal cuenta con precio
                Else
                    estatusAtado = 911 'Estatus indica que no tiene precio el lote 
                End If
            End If
            'VERIFICA SI SE RECUPERO UN ATADO VALIDO
            If DatosAtado.PIdAtado <> "0" Then

                ' SI LA NAVE DEL ATADO NO CORRESPONDE A LA NAVE QUE SE ESTA USANDO, SE DESCARTARA EL ATADO LEÍDO
                If DatosAtado.PIdNAve <> IdNave Then
                    ReproducrirSonidoError()
                    If AtadoActual <> "0" Then
                        ActualizarEstatusDeAtado()
                    End If
                    AtadoActual = "0"

                    lCodigosErroneos.Add("Código erroneo:" + LTrim(RTrim(codigo)) + " * Atado actual: " + AtadoActual.ToString + "* Causa: Atado no perteneciente a la nave en proceso")
                    Return
                End If

                ResultadoLoteCompleto = String.Empty 'SIRVE PARA VERIFICAR SI UN LOTE ESTA COMPLETO O INCOMPLETO

                'AGREGAMOS EL ENCABEZADO DE LA SALIDA DE NAVES EN LA TABLA SALIDA NAVES EN CASO DE NO EXISTIR ID DE SALIDA DE NAVE DEBIDO A QUE ES UNA NAVE DEL TIPO MAQUILADORA
                If Tipo_Nave_Maquila_o_Interna = True And IdSalidaNave = 0 Then
                    IniciarSalidaNaves()
                    RecuperarInformacionDeLotesEmbarcados_Y_Asignarla_al_Grid_Errores()
                    RecuperarInformacionDeLotesEmbarcados_Y_Asignarla_al_Grid_Lectura()
                    'Else
                    '    RecuperarInformacionDeLotesEmbarcados_Y_Asignarla_al_Grid_Errores()
                    '    RecuperarInformacionDeLotesEmbarcados_Y_Asignarla_al_Grid_Lectura()
                End If

                'VALIDAMOS QUE EL ATADO LEIDO ES PARTE DE LOS ATADOS PERTENECIENTES A LA SALIDA DE NAVES CON LA QUE SE ESTA TRABAJANDO
                If Tipo_Nave_Maquila_o_Interna = False Then
                    ValidarAtadoPertenecienteALaSalidaDeNavesEnProceso(codigo, IdSalidaNave)
                    If Atado_Incluido_SalidaNave_en_Curso = False And Tipo_Nave_Maquila_o_Interna = False Then
                        llotesNoEmbarcados.Add(DatosAtado.PLote.ToString + "-" + DatosAtado.PAño.ToString + "-" + IdNave.ToString)
                    End If
                End If

                If lAtados.Count = 0 Then 'VALIDA QUE EL ATADO SEA EL PRIMER ATADO LEEIDO PARA INICIAR CON EL ESCANEO
                    If Tipo_Nave_Maquila_o_Interna = True Then
                        ResultadoLoteCompleto = "COMPLETO"

                        'ACTUALIZAMOS EL ESTATUS DE LOS PARES Y DE EL ATADO CON EL QUE SE ESTUBO TRABAJANDO
                        If AtadoActual <> "0" Then
                            ActualizarEstatusDeAtado()
                        End If

                        Proceso_Para_Lote_completo_Entrada_Lotes(DatosAtado)
                    Else
                        ResultadoLoteCompleto = ValidarLoteTerminado(DatosAtado)
                        If ResultadoLoteCompleto = "COMPLETO" Then
                            'ACTUALIZAMOS EL ESTATUS DE LOS PARES Y DE EL ATADO CON EL QUE SE ESTUBO TRABAJANDO
                            If AtadoActual <> "0" Then
                                ActualizarEstatusDeAtado()
                            End If

                            Proceso_Para_Lote_completo_Entrada_Lotes(DatosAtado)
                        Else
                            'LOTE INCOMPLETO
                            Proceso_Para_Lote_Incompleto(DatosAtado)
                        End If
                    End If
                Else
                    If Tipo_Nave_Maquila_o_Interna = True Then
                        ResultadoLoteCompleto = "COMPLETO"
                        If AtadoActual <> "0" Then
                            ActualizarEstatusDeAtado()
                        End If

                        Proceso_Para_Lote_completo_Entrada_Lotes(DatosAtado)
                    Else
                        ResultadoLoteCompleto = ValidarLoteTerminado(DatosAtado)
                        If ResultadoLoteCompleto = "COMPLETO" Then
                            'ACTUALIZAMOS EL ESTATUS DE LOS PARES Y DE EL ATADO CON EL QUE SE ESTUBO TRABAJANDO
                            If AtadoActual <> "0" Then
                                ActualizarEstatusDeAtado()
                            End If

                            Proceso_Para_Lote_completo_Entrada_Lotes(DatosAtado)
                        Else
                            If AtadoActual <> "0" Then
                                ActualizarEstatusDeAtado()
                            End If
                            'LOTE INCOMPLETO
                            Proceso_Para_Lote_Incompleto(DatosAtado)
                        End If
                    End If
                End If
            Else
                If codigo.StartsWith(IdNave.ToString) Then
                    DatosAtado = ValidarAtadoIngresadoAnteriormente(codigo)
                    If DatosAtado.PIdAtado <> "0" Then
                        'Reproducimos sonido de error
                        ReproducrirSonidoError()
                        lCodigosErroneos.Add("Código erroneo:" + LTrim(RTrim(codigo)) + " * Atado actual: " + AtadoActual.ToString + " * Causa: Atado ingresado anteriormente.")
                        Return
                    Else
                        If LecturaParXPar = False Then
                            'Reproducimos sonido de error
                            ReproducrirSonidoError()
                            lCodigosErroneos.Add("Código erroneo:" + LTrim(RTrim(codigo)) + " * Atado actual: " + AtadoActual.ToString + "* Causa: Posible código de atado no valido ó código de cliente leído en lectura de 'Solo atado'.")
                            Return
                        Else
                            'POSIBLE CODIGO DE CLIENTE
                            Proceso_Para_Codigo_De_Cliente_Capturado(LTrim(RTrim(codigo)))
                        End If
                    End If
                Else
                    If LecturaParXPar = False Then
                        'Reproducimos sonido de error
                        ReproducrirSonidoError()
                        lCodigosErroneos.Add("Código erroneo:" + LTrim(RTrim(codigo)) + " * Atado actual: " + AtadoActual.ToString + "* Causa: Posible código de cliente leído en lectura de 'Solo atado'.")
                        Return
                    Else
                        'POSIBLE CODIGO DE CLIENTE
                        Proceso_Para_Codigo_De_Cliente_Capturado(LTrim(RTrim(codigo)))
                    End If
                End If
            End If
        ElseIf Carrito_Actual_Split.Length = 3 Then
            If IdCarritoActual = 0 Then
                'Reproducimos sonido de error
                ReproducrirSonidoError()
                lCodigosErroneos.Add("Código erroneo:" + LTrim(RTrim(codigo)) + " * Atado actual: " + AtadoActual.ToString + "* Causa: Sin plataforma .")
                Return
            Else
                If LecturaParXPar = False Then
                    'Reproducimos sonido de error
                    ReproducrirSonidoError()
                    lCodigosErroneos.Add("Código erroneo:" + LTrim(RTrim(codigo)) + " * Atado actual: " + AtadoActual.ToString + "* Causa: Posible código de par leído en lectura de 'Solo atados'")
                    Return
                Else
                    If AtadoActual = 0 Then
                        show_message("Alerta", "Escanea primero un código de atado para comenzar con el proceso de salida.")
                        Return
                    End If


                    verificar_par(codigo)

                    If par_valido = True Then
                        'PROCESO PARA CODIGO DE EMPRESA VALIDO
                        Proceso_Para_Par_Codigo_Empresa_Valido(LTrim(RTrim(codigo)))
                    Else
                        'POSIBLE CODIGO DECLIENTE
                        Proceso_Para_Codigo_De_Cliente_Capturado(LTrim(RTrim(codigo)))
                    End If
                End If
            End If

        Else
            If IdCarritoActual = 0 Then
                'Reproducimos sonido de error
                ReproducrirSonidoError()
                lCodigosErroneos.Add("Código erroneo:" + LTrim(RTrim(codigo)) + " * Atado actual: " + AtadoActual.ToString + "* Causa: Sin plataforma.")
                Return
            Else
                If LecturaParXPar = False Then
                    'Reproducimos sonido de error
                    ReproducrirSonidoError()
                    lCodigosErroneos.Add("Código erroneo:" + LTrim(RTrim(codigo)) + " * Atado actual: " + AtadoActual.ToString + "* Causa: Posible código de par leído en lectura de 'Solo atados'")
                    Return
                Else
                    'POSIBLE CODIGO DE CLIENTE
                    Proceso_Para_Codigo_De_Cliente_Capturado(LTrim(RTrim(codigo)))
                End If
            End If
        End If

    End Sub


    ''' <summary>
    ''' vERIFICA ´QUE UN ATADO NO HAYA SIDO INGRESADO ANTERIORMENTE AL ALMACEN
    ''' </summary>
    ''' <param name="codigo">ATADO</param>
    ''' <returns>UN ENTIDAD DE LA CLASE  Entidades.CapturaAtadoValido</returns>
    ''' <remarks></remarks>
    Private Function ValidarAtadoIngresadoAnteriormente(ByVal codigo As String) As Entidades.CapturaAtadoValido
        Dim objBUSalidaNaves As New SalidaNavesBU
        Dim AtadoValido As New Entidades.CapturaAtadoValido

        w = 1
        Do While w = 1
            Try
                AtadoValido = objBUSalidaNaves.ValidarAtadoIngresadoAnteriormente(codigo)
                w = 0
            Catch ex As Exception
                If ex.Message.Contains(" interbloqueo ") = False Then
                    w = 0
                End If
                EscribirErrorEnBiacora(ex.Message, "ValidarAtadoIngresadoAnteriormente()")
            End Try
        Loop

        Return AtadoValido
    End Function

    ''' <summary>
    ''' AGREGA LOS ATADOS DE UN LOTE A LA TABLA SALIDANAVESDETALLES
    ''' </summary>
    ''' <param name="Id_Nave">ID DE LA NAVE DE A LA QUE SE LE ESTA REALIZANDO EL PROCESO DE RECEPCION EN ALMACEN</param>
    ''' <param name="Año">AÑO DEL LOTE</param>
    ''' <param name="Lote">LOTE</param>
    ''' <returns>TABLA CON LA INFORMACION DE LOS ATADOS AGREGADOS</returns>
    ''' <remarks></remarks>
    Public Function AgregarAtadosDelLote_SalidaNavesDetalle_Para_entrada(ByVal Id_Nave As Integer, ByVal Año As Integer, ByVal Lote As Integer) As DataTable
        Dim objBUEntradas As New Negocios.EntradaProductoBU
        Dim LoteTerminado As Boolean
        Dim dtTabla As New DataTable

        If ResultadoLoteCompleto = "COMPLETO" Then
            LoteTerminado = True
        Else
            LoteTerminado = False
        End If

        w = 1
        Do While w = 1
            Try
                ''AGREGAMOS TODOS LOS ATADOS DEL LOTE A LA TABLA DE DETALLES DE SALIDAS
                dtTabla = objBUEntradas.AgregarAtadosDelLote_SalidaNavesDetalle_Para_entrada(IdSalidaNave, Id_Nave, Año, Lote, Proceso, "A", Tipo_Nave_Maquila_o_Interna, _
                                                                           Atado_Incluido_SalidaNave_en_Curso, LoteTerminado)
                w = 0
            Catch ex As Exception
                If ex.Message.Contains(" interbloqueo ") = False Then
                    w = 0
                End If
                EscribirErrorEnBiacora(ex.Message, "AgregarAtadosDelLote_SalidaNavesDetalle_Para_entrada()")
            End Try
        Loop

        Return dtTabla
    End Function

    ''' <summary>
    ''' AGREGA ATADOS DE UN LOTE AL GRID GRDERRORES
    ''' </summary>
    ''' <param name="Lote">LOTE</param>
    ''' <param name="Año">AÑO DEL LOTE</param>
    ''' <param name="Id_Nave">NAVE DEL LOTE</param>
    ''' <remarks></remarks>
    Public Sub AgregarAtadosDelLoteAlGridErrores_Entrada_Naves(ByVal Lote As Integer, ByVal Año As Integer, ByVal Id_Nave As Integer)
        Dim objBU As New Negocios.SalidaNavesBU

        Dim loteDescartado As Integer = 0

        'VALIDAMOS QUE EL HASH SET NO CONTENGA EL LOTE QUE SE LE AGREGO
        ResultadoHashSet_add = llotes.Add(Lote.ToString + "-" + Año.ToString + "-" + IdNave.ToString)

        If ResultadoHashSet_add = True Then

            For cont = llotes.Count - 1 To 0 Step -1

                'SE VERIFICA SI EL LOTE DEL ATADO LÉÍDO SE HA DESCARTADO ANTERIORMENTE
                If llotes(cont) = (Lote.ToString + "-" + Año.ToString + "-" + Id_Nave.ToString + "-DESCARTADO") Then
                    loteDescartado += 1

                    lLotesErroneos.Add(Lote.ToString + "-" + Año.ToString + "-" + IdNave.ToString)

                    Dim dtpares As New DataTable

                    w = 1
                    Do While w = 1
                        Try
                            dtpares = objBU.RecuperarPares_De_Lote(Lote, Año, Id_Nave)
                            w = 0
                        Catch ex As Exception
                            If ex.Message.Contains(" interbloqueo ") = False Then
                                w = 0
                            End If
                            EscribirErrorEnBiacora(ex.Message, "AgregarAtadosDelLoteAlGridErrores_Entrada_Naves(), objBU.RecuperarPares_De_Lote - 1")
                        End Try
                    Loop

                    For Each fila As DataRow In dtpares.Rows
                        lparesEmbarcados.Remove(Lote.ToString + "-" + Año.ToString + "-" + Id_Nave.ToString + "-" + fila.Item(1) + "-" + fila.Item(0))
                        lLotesEmbarcados.Remove(Lote.ToString + "-" + Año.ToString + "-" + Id_Nave.ToString)
                        lAtadosEmbarcados.Remove(Lote.ToString + "-" + Año.ToString + "-" + Id_Nave.ToString + "-" + fila.Item(1))

                        lparesDescartados.Add(Lote.ToString + "-" + Año.ToString + "-" + Id_Nave.ToString + "-" + fila.Item(1) + "-" + fila.Item(0))
                        lAtadosDescartados.Add(Lote.ToString + "-" + Año.ToString + "-" + Id_Nave.ToString + "-" + fila.Item(1))
                        lLotesDescartados.Add(Lote.ToString + "-" + Año.ToString + "-" + Id_Nave.ToString)
                    Next

                    LecturaParXPar = ValidarLecturaPar_por_Par(Lote, Año, Id_Nave)

                    For Each row As DataRow In dtTablaAtados_EntradaDeLotes.Rows
                        If row.Item("Lote") = Lote And row.Item("Año") = Año Then
                            If ResultadoLoteCompleto = "COMPLETO" Then
                                If llotesNoEmbarcados.Contains(row.Item("Lote").ToString + "-" + row.Item("Año").ToString + "-" + IdNave.ToString) Then
                                    poblarGrigErroneos(Lote, row.Item("# En lote"), row.Item("Atado"), row.Item("Descripción"), 9, Año)
                                Else

                                    poblarGrigErroneos(Lote, row.Item("# En lote"), row.Item("Atado"), row.Item("Descripción"), estatusAtado, Año)
                                End If

                            ElseIf ResultadoLoteCompleto = "INCOMPLETO" Then
                                poblarGrigErroneos(Lote, row.Item("# En Lote"), row.Item("Atado"), row.Item("Descripción"), 5, Año)
                            End If
                        End If
                    Next
                End If
            Next

            llotes.Remove(Lote.ToString + "-" + Año.ToString + "-" + Id_Nave.ToString + "-DESCARTADO")

            If loteDescartado = 0 Then
                If ResultadoHashSet_add = True Then
                    Dim n_Encontrado As Integer = 0

                    For cont = dtTablaAtados_EntradaDeLotes.Rows.Count - 1 To 0 Step -1
                        If dtTablaAtados_EntradaDeLotes.Rows(cont).Item("lOTE") = Lote And dtTablaAtados_EntradaDeLotes.Rows(cont).Item("Año") = Año Then
                            n_Encontrado += 1
                            cont = 0
                        End If
                    Next


                    If n_Encontrado = 0 Then
                        Dim dtAtados_de_Lote As New DataTable

                        ''AGREGAMOS TODOS LOS ATADOS DEL LOTE A LA TABLA DE SALIDANAVESDETALLES
                        dtAtados_de_Lote = AgregarAtadosDelLote_SalidaNavesDetalle_Para_entrada(Id_Nave, Año, Lote)

                        For Each ROW As DataRow In dtAtados_de_Lote.Rows

                            Dim atado As String = ROW.Item("Atado")

                            If ResultadoLoteCompleto = "COMPLETO" Then
                                If llotesNoEmbarcados.Contains(Lote.ToString + "-" + Año.ToString + "-" + IdNave.ToString) Then
                                    poblarGrigErroneos(Lote, ROW.Item("#"), ROW.Item("Atado").ToString, ROW.Item("Descripción"), 9, Año)
                                Else

                                    poblarGrigErroneos(Lote, ROW.Item("#"), ROW.Item("Atado").ToString, ROW.Item("Descripción"), estatusAtado, Año)
                                End If
                            ElseIf ResultadoLoteCompleto = "INCOMPLETO" Then
                                poblarGrigErroneos(Lote, ROW.Item("#"), ROW.Item("Atado").ToString, ROW.Item("Descripción"), 5, Año)
                            End If
                            If DescripcionAtadoActual = String.Empty And Proceso = "ENTRADA" Then
                                DescripcionAtadoActual = ROW.Item("Descripción")
                            End If

                            Poblar_Tabla_Erroneos(Lote, ROW.Item("#"), ROW.Item("Atado").ToString, DescripcionAtadoActual, estatusAtado, Año)

                            lAtadosCorrespondientes.Add(Lote.ToString + "-" + Año.ToString + "-" + IdNave.ToString + "-" + CStr(ROW.Item("Atado")))
                            lAtadosDeSalida.Add(Lote.ToString + "-" + Año.ToString + "-" + IdNave.ToString + "-" + CStr(ROW.Item("Atado")))
                        Next

                        Dim dtpares As New DataTable

                        w = 1
                        Do While w = 1
                            Try
                                dtpares = objBU.RecuperarPares_De_Lote(Lote, Año, Id_Nave)
                                w = 0
                            Catch ex As Exception
                                If ex.Message.Contains(" interbloqueo ") = False Then
                                    w = 0
                                End If
                                EscribirErrorEnBiacora(ex.Message, "AgregarAtadosDelLoteAlGridErrores_Entrada_Naves(), objBU.RecuperarPares_De_Lote - 2")
                            End Try
                        Loop

                        For Each row As DataRow In dtpares.Rows
                            lLotesDescartados.Add(Lote.ToString + "-" + Año.ToString + "-" + Id_Nave.ToString)
                            lAtadosDescartados.Add(Lote.ToString + "-" + Año.ToString + "-" + Id_Nave.ToString + "-" + row.Item(1))
                            lparesDescartados.Add(Lote.ToString + "-" + Año.ToString + "-" + Id_Nave.ToString + "-" + row.Item(1) + "-" + row.Item(0))

                            lLotesEmbarcados.Remove(Lote.ToString + "-" + Año.ToString + "-" + Id_Nave.ToString)
                            lAtadosEmbarcados.Remove(Lote.ToString + "-" + Año.ToString + "-" + Id_Nave.ToString + "-" + row.Item(1))
                            lparesEmbarcados.Remove(Lote.ToString + "-" + Año.ToString + "-" + Id_Nave.ToString + "-" + row.Item(1) + "-" + row.Item(0))
                        Next

                    Else
                        Dim dtpares As New DataTable

                        w = 1
                        Do While w = 1
                            Try
                                dtpares = objBU.RecuperarPares_De_Lote(Lote, Año, Id_Nave)
                                w = 0
                            Catch ex As Exception
                                If ex.Message.Contains(" interbloqueo ") = False Then
                                    w = 0
                                End If
                                EscribirErrorEnBiacora(ex.Message, "AgregarAtadosDelLoteAlGridErrores_Entrada_Naves(), objBU.RecuperarPares_De_Lote - 3")
                            End Try
                        Loop

                        For Each row As DataRow In dtpares.Rows
                            lLotesDescartados.Add(Lote.ToString + "-" + Año.ToString + "-" + Id_Nave.ToString)
                            lAtadosDescartados.Add(Lote.ToString + "-" + Año.ToString + "-" + Id_Nave.ToString + "-" + row.Item(1))
                            lparesDescartados.Add(Lote.ToString + "-" + Año.ToString + "-" + Id_Nave.ToString + "-" + row.Item(1) + "-" + row.Item(0))

                            lLotesEmbarcados.Remove(Lote.ToString + "-" + Año.ToString + "-" + Id_Nave.ToString)
                            lAtadosEmbarcados.Remove(Lote.ToString + "-" + Año.ToString + "-" + Id_Nave.ToString + "-" + row.Item(1))
                            lparesEmbarcados.Remove(Lote.ToString + "-" + Año.ToString + "-" + Id_Nave.ToString + "-" + row.Item(1) + "-" + row.Item(0))
                        Next
                    End If
                End If
            End If

            'VERIFICAMOS SI ES NECESARIO LEER PAR POR PAR TODO EL LOTE
            LecturaParXPar = ValidarLecturaPar_por_Par(Lote, Año, Id_Nave)
        Else
            If llotesBien.Contains(Lote.ToString + "-" + Año.ToString + "-" + IdNave.ToString) Then

                AgregarAtadoCorrectoAlGridErrores(AtadoActual, loteAtadoActual, AñoAtadoActual, DescripcionAtadoActual)

            End If
        End If

        'VALDAMOS SI EL EL LOTE DEL ATADO ACTUAL SE ENCUENTRA EN LA LISTA DE LOTES PARA VALIDAR POR PAR POR PAR Y ASIGNAMOS EL VALOR CORRESPONDIENTE A LA VARIABLE VALIDARÁRXPAR
        If lLotesParXPar.Contains(Lote.ToString + "-" + Año.ToString + "-" + IdNave.ToString) Then
            LecturaParXPar = True
        Else
            LecturaParXPar = False
        End If
    End Sub

#End Region


    Private Sub cmbProceso_Leave(sender As Object, e As EventArgs) Handles cmbProceso.Leave
        Proceso = cmbProceso.Text

        If cmbProceso.Text = "ENTRADA" Then
            lblParesAEmbarcar.Text = "Pares a Ingresar"
            lblAtadosAEmbarcar.Text = "Atados a Ingresar"
            lblLotesAEmbarcar.Text = "Lotes a Ingresar"
            lblSinTerminarNoLeido.Text = "No Leído"

            lblPink.Visible = True
            lblChocolate.Visible = True
            lblOrangered.Visible = True
            lblLoteSinTerminarAtadoConFaltante.Visible = True
            lblLoteSinTerminarAtadoCorrecto.Visible = True
            lblLoteSinTerminarAtadoMalFormado.Visible = True

            lblTotalPares.ForeColor = Color.Black
            lblTotalAtados.ForeColor = Color.Black
            lblTotalLotes.ForeColor = Color.Black

            pnlTotales.Height = 116
            pnlAcciones.Height = 89

            grpNoEmbarcados.Visible = True

            btnPlataformas.Visible = True
            lblPlataformas.Visible = True

        ElseIf cmbProceso.Text = "SALIDA" Then
            lblParesAEmbarcar.Text = "Pares a Embarcar"
            lblAtadosAEmbarcar.Text = "Atados a Embarcar"
            lblLotesAEmbarcar.Text = "Lotes a Embarcar"

            lblSinTerminarNoLeido.Text = "Lote sin terminar"
            lblPink.Visible = False
            lblChocolate.Visible = False
            lblOrangered.Visible = False
            lblLoteSinTerminarAtadoConFaltante.Visible = False
            lblLoteSinTerminarAtadoCorrecto.Visible = False
            lblLoteSinTerminarAtadoMalFormado.Visible = False

            pnlAcciones.Height = 39
            pnlTotales.Height = 79

            lblTotalPares.ForeColor = Color.Red
            lblTotalAtados.ForeColor = Color.Red
            lblTotalLotes.ForeColor = Color.Red

            grpNoEmbarcados.Visible = False

            btnPlataformas.Visible = False
            lblPlataformas.Visible = False
        End If
    End Sub


    Private Sub btnImprimirReporte_Click(sender As Object, e As EventArgs) Handles btnImprimirReporte.Click
        If Proceso = "SALIDA" Then
            cmsSalidaNaves.Show(btnImprimirReporte, 0, btnImprimirReporte.Height)
        ElseIf Proceso = "ENTRADA" Then
            cmsEntradaProducto.Show(btnImprimirReporte, 0, btnImprimirReporte.Height)
        Else
            show_message("Advertencia", "Seleccione un proceso para mostrar las opciones de reportes disponibles.")
        End If
    End Sub


    Private Sub SalidaDeLotesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalidaDeLotesToolStripMenuItem.Click
        Dim FormaMensaje As New ImprimirReporteSalidaNaveForm
        FormaMensaje.IdNave = IdNave
        FormaMensaje.ShowDialog()

        If FormaMensaje.Imprimir = True Then
            ImprimirReporte_Salida_Naves(FormaMensaje.IdSalidaNave, FormaMensaje.IdNave, FormaMensaje.NombreOperador)
            Me.Cursor = Cursors.Default
        End If
    End Sub


    Private Sub SALIDADELOTESDENAVEToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SALIDADELOTESDENAVEToolStripMenuItem.Click
        Dim FormaMensaje As New ImprimirReporteSalidaNaveForm
        FormaMensaje.IdNave = IdNave
        FormaMensaje.ShowDialog()

        If FormaMensaje.Imprimir = True Then
            ImprimirReporte_Salida_Naves(FormaMensaje.IdSalidaNave, FormaMensaje.IdNave, FormaMensaje.NombreOperador)
            Me.Cursor = Cursors.Default
        End If
    End Sub


    Private Sub RESULTADODEENTRADADEPRODUCTOToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RESULTADODEENTRADADEPRODUCTOToolStripMenuItem.Click
        ImprimirReporte_Entrada_Almacen()
    End Sub


    Private Sub grdIncorrecto_AfterCellUpdate(sender As Object, e As CellEventArgs) Handles grdIncorrecto.AfterCellUpdate
        Dim objBU As New Negocios.SalidaNavesBU
        Dim dtTabla As New DataTable

        Dim row As UltraGridRow = grdIncorrecto.ActiveRow
        If row IsNot Nothing Then
            If IsDBNull(row.Cells("Estado").Value) = False Then
                If row.Cells("Estado").Value = 1 Then
                    row.CellAppearance.BackColor = Color.White
                ElseIf row.Cells("Estado").Value = 2 Then
                    row.CellAppearance.BackColor = Color.Khaki '-------COLOR PAEA ATADO CON FALTANTE
                ElseIf row.Cells("Estado").Value = 4 Then
                    row.CellAppearance.BackColor = Color.LightSalmon '-COLOR PARA ATADO MAL FORMADO
                ElseIf row.Cells("Estado").Value = 0 Then
                    row.CellAppearance.BackColor = Color.Silver '-------COLOR PAEA ATADO NO LEIDO
                ElseIf row.Cells("Estado").Value = 5 Then
                    row.CellAppearance.BackColor = Color.Orange '------COLOR PARA LOTE SIN TERMINAR
                ElseIf row.Cells("Estado").Value = 6 Then
                    row.CellAppearance.BackColor = Color.Pink '--------COLOR APRA ATADO CORRECTO DE LOTE SIN TERMINAR
                ElseIf row.Cells("Estado").Value = 7 Then
                    row.CellAppearance.BackColor = Color.Chocolate '---COLOR PARA ATADO CON FALTANTE DE LOTE SIN TERMINAR
                ElseIf row.Cells("Estado").Value = 8 Then
                    row.CellAppearance.BackColor = Color.OrangeRed '---------COLOR PARA ATADO MAL FORMADO DE LOTE SIN TERMINAR
                ElseIf row.Cells("Estado").Value = 9 Then
                    row.CellAppearance.BackColor = Color.SteelBlue  '------COLOR PARA LOTE NO EMBARCADO
                ElseIf row.Cells("Estado").Value = 10 Then
                    row.CellAppearance.BackColor = Color.DodgerBlue '--------COLOR ATADO CORRECTO DE LOTE SIN EMBARCAR
                ElseIf row.Cells("Estado").Value = 11 Then
                    row.CellAppearance.BackColor = Color.Aqua '---COLOR PARA ATADO CON FALTANTE DE LOTE SIN EMBARCAR
                ElseIf row.Cells("Estado").Value = 12 Then
                    row.CellAppearance.BackColor = Color.CadetBlue '---------COLOR PARA ATADO MAL FORMADO DE LOTE SIN EMBARCAR
                ElseIf row.Cells("Estado").Value = 911 Then
                    row.CellAppearance.BackColor = Color.MediumSlateBlue '---------COLOR PARA ATADO SIN PRECIO
                End If
            End If
        End If
    End Sub


    Private Sub Reiniciar_Indice_Atado()
        Dim r As Integer = 0

        For Each row As UltraGridRow In grdLectura.Rows
            If r = 0 Then
                row.Cells("#").Value = 1
            Else
                If row.Cells("Atado").Text = grdLectura.Rows(r - 1).Cells("Atado").Text Then
                    row.Cells("#").Value = grdLectura.Rows(r - 1).Cells("#").Value
                Else
                    row.Cells("#").Value = grdLectura.Rows(r - 1).Cells("#").Value + 1
                End If
            End If
            r += 1
        Next
    End Sub


    Private Sub grdLectura_AfterRowsDeleted(sender As Object, e As EventArgs) Handles grdLectura.AfterRowsDeleted
        Reiniciar_Indice_Atado()
    End Sub


    Private Sub SalidaNavesLotesForm_SizeChanged(sender As Object, e As EventArgs) Handles MyBase.SizeChanged
        grdIncorrecto.Size = New System.Drawing.Size((Me.Width / 2 - 10), 333)
        grdLectura.Size = New System.Drawing.Size((Me.Width / 2 - 10), 333)
    End Sub


    Private Sub grdLectura_AfterRowInsert(sender As Object, e As RowEventArgs) Handles grdLectura.AfterRowInsert
        If grdLectura.Rows.Count > 1 Then Return
        grdLectura.DisplayLayout.Bands(0).Columns("#").Width = 35
        grdLectura.DisplayLayout.Bands(0).Columns("# En lote").Width = 35
        grdLectura.DisplayLayout.Bands(0).Columns("Lote").Width = 40
        grdLectura.DisplayLayout.Bands(0).Columns("Talla").Width = 35
        grdLectura.DisplayLayout.Bands(0).Columns("Par").Width = 85
        grdLectura.DisplayLayout.Bands(0).Columns("Atado").Width = 80
    End Sub


    Private Sub grdIncorrecto_AfterRowInsert(sender As Object, e As RowEventArgs) Handles grdIncorrecto.AfterRowInsert

        If grdIncorrecto.Rows.Count > 1 Then Return
        grdIncorrecto.DisplayLayout.Bands(0).Columns("# En lote").Width = 35
        grdIncorrecto.DisplayLayout.Bands(0).Columns("Lote").Width = 45
        grdIncorrecto.DisplayLayout.Bands(0).Columns("Atado").Width = 80
        grdIncorrecto.DisplayLayout.Bands(0).Columns("Quitar").Width = 30

    End Sub


    Private Sub SalidaNavesLotesForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Dim formaConfirmacion As New ConfirmarForm
        formaConfirmacion.StartPosition = FormStartPosition.CenterScreen
        formaConfirmacion.mensaje = "¿Estas seguro que deseas salir?"

        If formaConfirmacion.ShowDialog() <> Windows.Forms.DialogResult.OK Then
            e.Cancel = True
        End If
    End Sub


    Private Sub btnPlataformas_Click(sender As Object, e As EventArgs) Handles btnPlataformas.Click
        Dim FormaListaErrores As New ListaErroresSalidaNavesLotesForm
        FormaListaErrores.StartPosition = FormStartPosition.CenterScreen
        FormaListaErrores.Plataformas = True
        FormaListaErrores.IdSalidaNave = IdSalidaNave
        FormaListaErrores.IdNave = IdNave
        FormaListaErrores.ShowDialog()
    End Sub


    Private Sub btnDescartarLotes_Click(sender As Object, e As EventArgs) Handles btnDescartarLotes.Click
        cmsDescartarLotes.Show(btnDescartarLotes, 0, btnDescartarLotes.Height)
    End Sub


    Private Sub LOTESVALIDADOSCORRECTAMENTEToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LOTESVALIDADOSCORRECTAMENTEToolStripMenuItem.Click
        Dim lLotesADescartar As New HashSet(Of String)

        For Each row As UltraGridRow In grdLectura.Selected.Rows
            If row.IsFilterRow Then Return
            If row.Selected = True Then
                If lLotesEmbarcados.Contains(row.Cells("Lote").Text + "-" + row.Cells("Año").Text + "-" + IdNave.ToString) Then
                    lLotesADescartar.Add(row.Cells("Lote").Text + "-" + row.Cells("Año").Text + "-" + IdNave.ToString)
                End If

            End If
        Next

        If lLotesADescartar.Count > 0 Then
            Dim objBUSalidas As New Negocios.SalidaNavesBU
            Dim objBUEntradas As New Negocios.EntradaProductoBU
            Dim dtTabla As New DataTable
            Dim formaConfirmacion As New ConfirmarForm
            formaConfirmacion.StartPosition = FormStartPosition.CenterScreen
            formaConfirmacion.mensaje = "¿Estas seguro que deseas eliminar el lote validado como correcto?"

            If formaConfirmacion.ShowDialog() = Windows.Forms.DialogResult.OK Then

                If Proceso = "ENTRADA" Then
                    objBUEntradas.DescarTarPares_Entrada_De_Producto(IdSalidaNave, lLotesADescartar, IdNave)
                Else
                    objBUSalidas.EliminarParesDeAtadoDescartadoDeLaTablaSalidaNavesDetalles(IdSalidaNave, lLotesADescartar, IdNave)
                End If

                Dim lLotes_Descartados As New HashSet(Of String)

                'DESCARTAMOS LOS LOTES DE LA LISTA DE LOTES LEIDOS
                For cont = llotes.Count - 1 To 0 Step -1
                    For Each item In lLotesADescartar
                        If llotes(cont).StartsWith(item) = True Then
                            lLotes_Descartados.Add(llotes(cont))
                            llotes.Add(llotes(cont) + "-DESCARTADO")
                        End If
                    Next

                Next
                For Each item In lLotes_Descartados
                    llotes.Remove(item)
                Next

                ''------------------DESCARTAMOS PARES Y ATADOS
                Dim lotes() As String
                For Each item In lLotesADescartar
                    lotes = item.Split("-")
                    Dim objBU As New SalidaNavesBU
                    lLotesEmbarcados.Remove(lotes(0) + "-" + lotes(1) + "-" + IdNave.ToString)
                    llotesBien.Remove(lotes(0) + "-" + lotes(1) + "-" + IdNave.ToString)
                    ResultadoHashSet_add = lLotesErroneos.Add(lotes(0) + "-" + lotes(1) + "-" + IdNave.ToString)

                    If ResultadoHashSet_add = True Then
                        Dim dtpares As New DataTable
                        dtpares = objBU.RecuperarPares_De_Lote(lotes(0), lotes(1), IdNave)
                        For Each row As DataRow In dtpares.Rows
                            lLotesEmbarcados.Remove(lotes(0).ToString + "-" + lotes(1).ToString + "-" + IdNave.ToString)
                            lAtadosEmbarcados.Remove(lotes(0) + "-" + lotes(1) + "-" + IdNave.ToString + "-" + row.Item(1))
                            lparesEmbarcados.Remove(lotes(0) + "-" + lotes(1) + "-" + IdNave.ToString + "-" + row.Item(1) + "-" + row.Item(0))

                            lLotesDescartados.Add(lotes(0) + "-" + lotes(1) + "-" + IdNave.ToString)
                            lAtadosDescartados.Add(lotes(0) + "-" + lotes(1) + "-" + IdNave.ToString + "-" + row.Item(1))
                            lparesDescartados.Add(lotes(0) + "-" + lotes(1) + "-" + IdNave.ToString + "-" + row.Item(1) + "-" + row.Item(0))
                        Next
                    End If

                Next

                LlenarEtiquetas()

                Me.Cursor = Cursors.Default
            End If
        Else
            show_message("Advertencia", "No se han seleccionado lotes listos para embarcar, por lo tanto no puede descartarse en esta opción.")
        End If
    End Sub

    Private Sub LOTESCONERRORESOFALTANTEToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LOTESCONERRORESOFALTANTEToolStripMenuItem.Click
        Dim objBUSalidas As New Negocios.SalidaNavesBU
        Dim objBUEntradas As New Negocios.EntradaProductoBU
        Dim dtTabla As New DataTable
        Dim lLotesADescartar As New HashSet(Of String)

        Dim formaConfirmacion As New ConfirmarForm
        formaConfirmacion.StartPosition = FormStartPosition.CenterScreen
        formaConfirmacion.mensaje = "¿Estas seguro que deseas eliminar los lotes marcados?"

        If formaConfirmacion.ShowDialog() = Windows.Forms.DialogResult.OK Then
            For Each row As UltraGridRow In grdIncorrecto.Rows
                If row.Cells("Quitar").Value = True Then
                    lLotesADescartar.Add(row.Cells("Lote").Text + "-" + row.Cells("Año").Text + "-" + IdNave.ToString)
                End If
            Next

            If lLotesADescartar.Count = 0 Then Return

            If Proceso = "ENTRADA" Then
                objBUEntradas.DescarTarPares_Entrada_De_Producto(IdSalidaNave, lLotesADescartar, IdNave)
            Else
                objBUSalidas.EliminarParesDeAtadoDescartadoDeLaTablaSalidaNavesDetalles(IdSalidaNave, lLotesADescartar, IdNave)
            End If

            Dim lLotes_Descartados As New HashSet(Of String)

            'DESCARTAMOS LOS LOTES DE LA LISTA DE LOTES LEIDOS
            For cont = llotes.Count - 1 To 0 Step -1
                For Each item In lLotesADescartar
                    If llotes(cont).StartsWith(item) = True Then
                        lLotes_Descartados.Add(llotes(cont))
                        llotes.Add(llotes(cont) + "-DESCARTADO")
                    End If
                Next

            Next
            For Each item In lLotes_Descartados
                llotes.Remove(item)
            Next

            'ELIMINAR ATADOS DEL LOTE DEL GRID ERRONEOS
            For Each item In lLotesADescartar
                Dim Lote() As String
                Lote = item.Split("-")
                For cont = grdIncorrecto.Rows.Count - 1 To 0 Step -1
                    If grdIncorrecto.Rows(cont).Cells("Lote").Text = Lote(0) And grdIncorrecto.Rows(cont).Cells("Año").Text = Lote(1) Then
                        grdIncorrecto.Rows(cont).Delete(True)
                    End If
                Next
            Next

            LlenarEtiquetas()

            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub cboxNaveAlmacen_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboxNaveAlmacen.SelectedIndexChanged
        Dim objbu As New Almacen.Negocios.AlmacenBU
        Dim dtNumeroAlmacenes As DataTable

        If PrimeraCarga = False Then
            cboxAlmacen.DataSource = Nothing

            dtNumeroAlmacenes = objbu.ConsultaNumeroAlmacenes(cboxNaveAlmacen.SelectedValue)
            cboxAlmacen.DataSource = dtNumeroAlmacenes
            cboxAlmacen.ValueMember = "NumeroAlmacen"
            cboxAlmacen.DisplayMember = "NumeroAlmacen"
            cboxAlmacen.SelectedIndex = 0
        End If
    End Sub

    Private Sub btnMuestras_Click(sender As Object, e As EventArgs) Handles btnMuestras.Click

        Dim EntradaSalidaMuestrasForm As New Programacion.Vista.PedidosMuestras_SalidasEntradas
        EntradaSalidaMuestrasForm.Show()

    End Sub
End Class