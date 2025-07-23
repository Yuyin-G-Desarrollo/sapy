Public Class Bitacora

    Public email_envia As String
    Public subject As String
    Public clave_email As String
    Public naveID As Integer
    Public RegistroPrincipalID As Integer
    Public TipoNotificacionID As Integer

    Private tblTipoNotificacion As New DataTable
    Private tblDatosCabecera As New DataTable
    Private tblBitacora As New DataTable
    Private tblBitacoraOrdenada As New DataTable
    Private tblEmail As New DataTable
    Private email As String = String.Empty
    Private tblUsuariosModifica As New DataTable

    Public Sub recuperar_datos_notificacion()

        Dim objBU As New Framework.Negocios.BitacoraBU

        tblBitacora = objBU.recuperar_datos_bitacora_sin_enviar(TipoNotificacionID, RegistroPrincipalID) ''RECUPERA LA BITACORA SEGUNLA PERSONA Y EL TIPO DE NOTIFICACION

        If Not tblBitacora.Rows.Count > 0 Then Return


        tblTipoNotificacion = objBU.recuperar_datos_notificacion(TipoNotificacionID)
        email = "" +
                                "<html>" +
                                    "<head>" +
                                        "<style type ='" + "text/css" + "'> " +
                                            "body {display: block; margin: 8px; background: #FFFFFF;color: #003366;	font-family: Arial, Helvetica, sans-serif;	font-size: 12px;}" +
                                            "#header{ position: fixed;	height: 30px;	top: 0;	left: 0;	right: 0;	color: #003366;	font-family: Arial, Helvetica, sans-serif;	font-size: 12px;	font-weight: bold;}" +
                                            "#leftcolumn{	float: left;	position: fixed;	width: 2%;	margin: 1%;	padding-top: 1%;	top: 0;	left: 0;	right: 0;}" +
                                            "#content{	width: 90%;	position: fixed;	margin: 1% 1px;		padding-top: 1px;	padding-bottom: 1%;}" +
                                            "#rightcolumn{	float: right;	width: 5%;	margin: 1%;			padding-top: 1%;}" +
                                            "#footer{	position: fixed;	width: 100%;	heigt: 5%;	bottom: 0;	margin: 0;	padding: 0;	color: #003366; font-family: Arial, Helvetica, sans-serif;	font-size: 10px;	font-weight: bold;}" +
                                            "table.header-table { font-family: Arial, Helvetica, sans-serif;    font-size: 12px; font-weight: bold;}" +
                                            "table.tableizer-table { font-family: Arial, Helvetica, sans-serif; font-size: 9px; color: #003366;}" +
                                            ".tableizer-table th {	background-color: #003366; color: #FFF;	font-weight: bold;	height: 30px;	font-size: 10px;    border: 1px;    border-color:#FFF}" +
                                            ".tableizer-table tr {  padding: 4px; color: #000;}" +
                                            ".tableizer-table td {	padding: 4px;	margin: 0px;    width: 200px; border: 1px;    border-color:#003366;}" +
                                        "</style>" +
                                    "</head>" +
                                        "<body>" +
                                            "<div id='" + "wrapper" + "'>" +
                                                "<div id='" + "header" + "'>" +
                                                "</div>" +
                                                "<div id='" + "leftcolumn" + "'>" +
                                                "</div>" +
                                                "<div id='" + "rightcolumn" + "'>" +
                                                "</div>"

        recuperar_datos_cabecera_reporte(RegistroPrincipalID)

        eliminar_registros_tabla_bitacora_temporal(TipoNotificacionID, RegistroPrincipalID)

        recuperar_datos_bitacora_sin_enviar(TipoNotificacionID, RegistroPrincipalID)

        actualizar_registros_notificados_bitacora(TipoNotificacionID, RegistroPrincipalID)

        insertar_registros_notificados_bitacora_temporal(TipoNotificacionID, RegistroPrincipalID)

        eliminar_datos_bitacora_enviados(TipoNotificacionID, RegistroPrincipalID)

        enviar_correo(naveID, clave_email)


    End Sub

    Private Sub recuperar_datos_cabecera_reporte(RegistroPrincipalID As Integer)

        Dim objBu As New Framework.Negocios.BitacoraBU
        Dim campo As String = tblTipoNotificacion.Rows(0).Item(4).ToString + "," + tblTipoNotificacion.Rows(0).Item(5).ToString
        Dim campos() As String
        campos = campo.Split(",")
        Dim esquema As String = tblTipoNotificacion.Rows(0).Item(2).ToString
        Dim tabla As String = tblTipoNotificacion.Rows(0).Item(3).ToString

        tblDatosCabecera = objBu.recuperar_datos_cabecera_reporte(campos, tabla, esquema, RegistroPrincipalID)
        '"<th width ='" + "10%" + "'><img src='" + "http://grupoyuyin.com.mx/images/SAY170.jpg" + "'style='" + "vertical-align:middle" + "' align='" + "left" + "' height='" + "57" + "' widht='" + "125" + "'></td>" +
        email += "" +
                                                "<div id='" + "content" + "'>" +
                                                    "<table id='" + "mi_tabla" + "' class='" + "header-table" + "' cellspacing='0'>" +
                                                        "<tr class='" + "tableizer-header" + "'>" +
                                                        "<th width ='" + "10%" + "'><img src='" + "http://192.168.2.158/nomina/LOGOTIPOS/GRUPOYUYIN.JPG" + "' 'style='" + "vertical-align:middle" + "' align='" + "left" + "' height='" + "57" + "' widht='" + "125" + "'></td>" +
                                                        "<th width ='" + "1%" + "'>&nbsp;</td>" +
                                                        "<th width ='" + "10%" + "'>" + tblTipoNotificacion.Rows(0).Item(1).ToString + "</td>" +
                                                        "<th width ='" + "1%" + "'>&nbsp;</td>" +
                                                        "<th width ='" + "10%" + "'>" + Now.ToLongDateString.ToUpper + " " + Now.ToLongTimeString.ToUpper + "</td>" +
                                                        "</tr>" +
                                                    "</table>" +
                                                    "<p>&nbsp;</p>" +
                                                    "<p>" + "ID: " + tblDatosCabecera.Rows(0).Item(0).ToString + "</p>" +
                                                    "<p>" + "Nombre: " + tblDatosCabecera.Rows(0).Item(1).ToString + "</p>"


        Dim s As String = email


    End Sub

    Private Sub eliminar_registros_tabla_bitacora_temporal(TipoNotificacionID As Integer, RegistroPrincipalID As Integer)
        Dim objBu As New Framework.Negocios.BitacoraBU
        objBu.eliminar_registros_tabla_bitacora_temporal(TipoNotificacionID, RegistroPrincipalID)
    End Sub

    Private Sub recuperar_datos_bitacora_sin_enviar(TipoNotificacionID As Integer, RegistroPrincipalID As Integer)

        Dim objBU As New Framework.Negocios.BitacoraBU

        tblBitacora = objBU.recuperar_datos_bitacora_sin_enviar(TipoNotificacionID, RegistroPrincipalID) ''RECUPERA LA BITACORA SEGUNLA PERSONA Y EL TIPO DE NOTIFICACION

        If tblBitacora.Rows.Count > 0 Then
            Dim consulta As String = String.Empty
            Dim consulta1 As String = String.Empty
            Dim consulta2 As String = String.Empty

            Dim consulta_anterior As String = String.Empty ''ESTA VARIABLE NO LA ESTOY USANDO
            Dim consulta1_anterior As String = String.Empty
            Dim consulta2_anterior As String = String.Empty

            Dim NivelInformacion_anterior As String = String.Empty
            Dim nombre_nivel_informacion1_Anterior As String = String.Empty
            Dim nombre_nivel_informacion2_Anterior As String = String.Empty
            Dim registroID_anterior As String = String.Empty
            Dim tablaOrigen_anterior As String = String.Empty
            Dim campos As String = String.Empty

            RecuperarUsuariosModifica(tblBitacora)

            For Each row In tblBitacora.Rows

                Dim NivelInformacion As String = String.Empty
                Dim tablaOrigen As String = String.Empty


                Dim nombre_nivel_informacion1 As String = String.Empty
                Dim nombre_nivel_informacion2 As String = String.Empty

                Dim busquedaID As Integer

                Dim camposRestantes As String = String.Empty
                Dim ValoresAntes As String = String.Empty
                Dim ValoresDespues As String = String.Empty
                Dim registroID As String = String.Empty


                Dim bitacoraID As Integer = row.Item("bita_bitacoraid")
                NivelInformacion = Trim(CStr(row.Item("bita_nivelinformacion")))
                ''registroID = CStr(row.Item("bita_registroid"))
                tablaOrigen = CStr(row.Item("bita_tabla"))

                camposRestantes = CStr(row.Item("bita_campos")).Trim
                If IsDBNull(row.Item("bita_valor_antes")) Then
                    ValoresAntes = ""
                Else
                    ValoresAntes = CStr(row.Item("bita_valor_antes")).Trim
                End If

                If IsDBNull(row.Item("bita_valor_despues")) Then
                    ValoresDespues = ""
                Else
                    ValoresDespues = CStr(row.Item("bita_valor_despues")).Trim
                End If

                ''idPersona = CStr(row.Item("bita_personaregistroid")).Trim
                registroID = CStr(row.Item("bita_registroid")).Trim

                Dim Valor_antes As String = String.Empty
                Dim Valor_despues As String = String.Empty

                While camposRestantes.Length > 0

                    Dim ApartadoPrincipal As String = String.Empty
                    Dim Apartado As String = String.Empty
                    Dim Etiqueta As String = String.Empty

                    Dim Orden As Integer
                    Dim tabla As String = String.Empty
                    Dim TablaCatalogo As String = String.Empty
                    Dim CampoIdCatalogo As String = String.Empty
                    Dim CampoDescrCatalogo As String = String.Empty
                    Dim Mostrar As Boolean = True

                    Dim tblConsultasNotificacion, tblNombreNivelInformacion, tblInformacionEtiqueta As New DataTable



                    If Not NivelInformacion = NivelInformacion_anterior Or Not registroID = registroID_anterior Or Not tablaOrigen = tablaOrigen_anterior Then

                        If Not Trim(CStr(row.Item("bita_nivelinformacion"))).Equals("CLIENTE") Then

                            consulta = " SELECT " +
                                        "   bcon_esquemapersona " +
                                        " , bcon_consultanombrenivelinfo1_1 " +
                                        " , bcon_consultanombrenivelinfo1_2 " +
                                        " , bcon_consultanombrenivelinfo2_1 " +
                                        " , bcon_consultanombrenivelinfo2_2  " +
                                        " FROM Framework.BitacoraConsultasNotificacion  " +
                                        " WHERE bcon_nivelinformacion = '" + NivelInformacion + "'" +
                                        " AND bcon_bitacoratablasnotificacionid = " + CStr(row.Item("bita_tabla"))

                            tblConsultasNotificacion = objBU.recuperar_datos_bitacora_consulta(consulta)

                            If tblConsultasNotificacion.Rows.Count > 0 Then

                                If IsDBNull(tblConsultasNotificacion.Rows(0).Item("bcon_esquemapersona")) Then
                                    busquedaID = CInt(row.Item("bita_registroid"))
                                Else
                                    If tblConsultasNotificacion.Rows(0).Item("bcon_esquemapersona") Then
                                        busquedaID = CInt(row.Item("bita_personaregistroid"))
                                    Else
                                        busquedaID = CInt(row.Item("bita_registroid"))
                                    End If
                                End If


                                Dim consultanombrenivelinfo1_1 As String = String.Empty
                                If Not IsDBNull(tblConsultasNotificacion.Rows(0).Item("bcon_consultanombrenivelinfo1_1")) Then
                                    consultanombrenivelinfo1_1 = Trim(CStr(tblConsultasNotificacion.Rows(0).Item("bcon_consultanombrenivelinfo1_1")))
                                End If
                                Dim consultanombrenivelinfo1_2 As String = String.Empty
                                If Not IsDBNull(tblConsultasNotificacion.Rows(0).Item("bcon_consultanombrenivelinfo1_2")) Then
                                    consultanombrenivelinfo1_2 = Trim(CStr(tblConsultasNotificacion.Rows(0).Item("bcon_consultanombrenivelinfo1_2")))
                                End If

                                consulta1 = consultanombrenivelinfo1_1 + busquedaID.ToString + consultanombrenivelinfo1_2
                                If Not consulta1 = consulta1_anterior Then

                                    tblNombreNivelInformacion = objBU.recuperar_datos_bitacora_consulta(consulta1)
                                    If tblNombreNivelInformacion.Rows.Count > 0 Then
                                        nombre_nivel_informacion1 = (Trim(tblNombreNivelInformacion.Rows(0).Item(0))) '& " (" & idRegistro & ")"
                                    Else
                                        nombre_nivel_informacion1 = "****NO ENCONTRADO " + CStr(row.Item("bita_nivelinformacion")) + "*****"
                                    End If
                                Else
                                    MessageBox.Show("ERROR 1")
                                End If


                                Dim consultanombrenivelinfo2_1 As String = String.Empty
                                If Not IsDBNull(tblConsultasNotificacion.Rows(0).Item("bcon_consultanombrenivelinfo2_1")) Then
                                    consultanombrenivelinfo1_1 = Trim(CStr(tblConsultasNotificacion.Rows(0).Item("bcon_consultanombrenivelinfo2_1")))
                                End If

                                Dim consultanombrenivelinfo2_2 As String = String.Empty
                                If Not IsDBNull(tblConsultasNotificacion.Rows(0).Item("bcon_consultanombrenivelinfo2_2")) Then
                                    consultanombrenivelinfo1_2 = Trim(CStr(tblConsultasNotificacion.Rows(0).Item("bcon_consultanombrenivelinfo2_2")))
                                End If

                                consulta2 = consultanombrenivelinfo1_1 + busquedaID.ToString + consultanombrenivelinfo1_2
                                If Not consulta2 = consulta2_anterior Then
                                    If Not IsDBNull(tblConsultasNotificacion.Rows(0).Item("bcon_consultanombrenivelinfo2_1")) Then
                                        If Not consulta2 = consulta2_anterior Then
                                            tblNombreNivelInformacion = objBU.recuperar_datos_bitacora_consulta(consulta2)
                                            If tblNombreNivelInformacion.Rows.Count > 0 Then
                                                nombre_nivel_informacion2 = (Trim(tblNombreNivelInformacion.Rows(0).Item(0))) '& " (" & idRegistro & ")"
                                            Else
                                                nombre_nivel_informacion2 = "****NO ENCONTRADO " + CStr(row.Item("bita_nivelinformacion")) + "*****"
                                            End If
                                        End If
                                    Else
                                        nombre_nivel_informacion2 = String.Empty
                                    End If
                                Else
                                    MessageBox.Show("ERROR 2")
                                End If
                            End If
                        End If
                    Else
                        nombre_nivel_informacion1 = nombre_nivel_informacion1_Anterior
                        nombre_nivel_informacion2 = nombre_nivel_informacion2_Anterior
                    End If

                    Dim posicion As Integer = camposRestantes.IndexOf("|")
                    Dim campo As String = camposRestantes.Substring(2, posicion - 2)
                    Dim operacion As String = camposRestantes.Substring(0, 1)
                    ''posicion_valorAntes + 1, ValoresAntes.Length - posicion_valorAntes - 1
                    camposRestantes = camposRestantes.Substring(posicion + 1, camposRestantes.Length - posicion - 1)

                    consulta = "" +
                                " SELECT " +
                                "    ba.biap_nombre AS ApartadoPrincipal " +
                                "  , ba2.biap_nombre AS Apartado " +
                                "  , be.biet_etiqueta AS Etiqueta " +
                                "  , be.biet_campo AS Campo " +
                                "  , be.biet_orden AS Orden " +
                                "  , bt.btan_tabla AS Tabla " +
                                "  , be.biet_catalogo AS TablaCatalogo " +
                                "  , be.biet_campoidcatalogo AS CampoIdCatalogo " +
                                "  , be.biet_campodescripcioncatalogo AS CampoDescrCatalogo " +
                                "  , be.biet_mostrarennotificacion AS Mostrar " +
                                " FROM framework.BitacoraApartado ba " +
                                " INNER JOIN Framework.BitacoraEtiquetas be " +
                                " 	ON ba.biap_bitacoraapartadoid = be.biet_bitacoraapartadoprincipalid " +
                                " INNER JOIN Framework.BitacoraTablasNotificacion bt " +
                                " 	ON bt.btan_bitacoratablasnotificacionid = be.biet_bitacoratablasnotificacionid " +
                                " LEFT JOIN framework.BitacoraApartado ba2 " +
                                " 	ON ba2.biap_bitacoraapartadoid = be.biet_bitacoraapartadoid " +
                                " WHERE biet_campo IN ('" + campo + "') " +
                                " AND biet_nivelinformacion = '" + NivelInformacion + "' "

                    ''IDENTIFICAR APARTADO DEL CAMPO
                    tblInformacionEtiqueta = objBU.recuperar_datos_bitacora_consulta(consulta)

                    If tblInformacionEtiqueta.Rows.Count > 0 Then

                        If Not IsDBNull(tblInformacionEtiqueta.Rows(0).Item("ApartadoPrincipal")) Then
                            ApartadoPrincipal = Trim(CStr(tblInformacionEtiqueta.Rows(0).Item("ApartadoPrincipal")))
                        End If

                        If Not IsDBNull(tblInformacionEtiqueta.Rows(0).Item("Apartado")) Then
                            Apartado = Trim(CStr(tblInformacionEtiqueta.Rows(0).Item("Apartado")))
                        End If

                        If Not IsDBNull(tblInformacionEtiqueta.Rows(0).Item("Etiqueta")) Then
                            Etiqueta = Trim(CStr(tblInformacionEtiqueta.Rows(0).Item("Etiqueta")))
                        End If

                        If Not IsDBNull(tblInformacionEtiqueta.Rows(0).Item("Orden")) Then
                            Orden = CInt(tblInformacionEtiqueta.Rows(0).Item("Orden"))
                        End If

                        If Not IsDBNull(tblInformacionEtiqueta.Rows(0).Item("Tabla")) Then
                            tabla = Trim(CStr(tblInformacionEtiqueta.Rows(0).Item("Tabla")))
                        End If

                        If Not IsDBNull(tblInformacionEtiqueta.Rows(0).Item("TablaCatalogo")) Then
                            TablaCatalogo = Trim(CStr(tblInformacionEtiqueta.Rows(0).Item("TablaCatalogo")))
                        End If

                        If Not IsDBNull(tblInformacionEtiqueta.Rows(0).Item("CampoIdCatalogo")) Then
                            CampoIdCatalogo = Trim(CStr(tblInformacionEtiqueta.Rows(0).Item("CampoIdCatalogo")))
                        End If

                        If Not IsDBNull(tblInformacionEtiqueta.Rows(0).Item("CampoDescrCatalogo")) Then
                            CampoDescrCatalogo = Trim(CStr(tblInformacionEtiqueta.Rows(0).Item("CampoDescrCatalogo")))
                        End If

                        If Not IsDBNull(tblInformacionEtiqueta.Rows(0).Item("Mostrar")) Then
                            Mostrar = CBool(tblInformacionEtiqueta.Rows(0).Item("Mostrar"))
                        End If

                    End If

                    If String.IsNullOrEmpty(campos) Then
                        campos = "'" + campo + "'"
                    Else
                        campos = campos + ",'" + campo + "'"
                    End If
                    ''IDENTIFICAR VALORES ANTES
                    Dim posicion_valorAntes As Integer = ValoresAntes.IndexOf("|")
                    If posicion_valorAntes > 0 Then
                        Valor_antes = ValoresAntes.Substring(0, posicion_valorAntes)
                        ValoresAntes = ValoresAntes.Substring(posicion_valorAntes + 1, ValoresAntes.Length - posicion_valorAntes - 1)
                    Else
                        Valor_antes = ValoresAntes.Substring(0, posicion_valorAntes + 1)
                        ValoresAntes = ValoresAntes.Substring(posicion_valorAntes + 1, ValoresAntes.Length - posicion_valorAntes - 1)
                        If Valor_antes.Equals("|") Then
                            Valor_antes = String.Empty
                        End If
                    End If
                    ''IDENTIFICAR VALORES DESPUES
                    Dim posicion_valorDespues As Integer = ValoresDespues.IndexOf("|")
                    If posicion_valorDespues > 0 Then
                        Valor_despues = ValoresDespues.Substring(0, posicion_valorDespues)
                        ValoresDespues = ValoresDespues.Substring(posicion_valorDespues + 1, ValoresDespues.Length - posicion_valorDespues - 1)
                    Else
                        Valor_despues = ValoresDespues.Substring(0, posicion_valorDespues + 1)
                        ValoresDespues = ValoresDespues.Substring(posicion_valorDespues + 1, ValoresDespues.Length - posicion_valorDespues - 1)
                        If Valor_despues.Equals("|") Then
                            Valor_despues = String.Empty
                        End If
                    End If
                    ''SI LOS VALORES SON DE UN CATALOGO
                    If Not String.IsNullOrEmpty(TablaCatalogo) And Not String.IsNullOrEmpty(CampoIdCatalogo) And Not String.IsNullOrEmpty(CampoDescrCatalogo) Then
                        Dim tblCatalogo As New DataTable
                        If Not String.IsNullOrEmpty(Valor_antes) Then
                            consulta = "SELECT " + CampoDescrCatalogo + " from " + TablaCatalogo + " WHERE " + CampoIdCatalogo + " = " + Valor_antes
                            tblCatalogo = objBU.recuperar_datos_bitacora_consulta(consulta)
                            If tblCatalogo.Rows.Count > 0 Then
                                Valor_antes = Trim(CStr(tblCatalogo.Rows(0).Item(0)))
                            End If
                        End If

                        If Not String.IsNullOrEmpty(Valor_despues) Then
                            consulta = "SELECT " + CampoDescrCatalogo + " from " + TablaCatalogo + " WHERE " + CampoIdCatalogo + " = " + Valor_despues
                            tblCatalogo = objBU.recuperar_datos_bitacora_consulta(consulta)
                            If tblCatalogo.Rows.Count > 0 Then
                                Valor_despues = Trim(CStr(tblCatalogo.Rows(0).Item(0)))
                            End If
                        End If

                    End If

                    If Not Valor_antes.Equals(Valor_despues) Then ''INSERTAR EN LA TABLA TEMPORAL
                        consulta = " " +
                                    " INSERT INTO Framework.BitacoraTemporal " +
                                    " ( " +
                                    "   btem_tiponotificacionid " +
                                    " , btem_principalid " +
                                    " , btem_nivelinformacion " +
                                    " , btem_nombrenivelinformacion1 " +
                                    " , btem_nombrenivelinformacion2 " +
                                    " , btem_orden" +
                                    " , btem_apartadoprincipal" +
                                    " , btem_apartado" +
                                    " , btem_etiqueta" +
                                    " , btem_campo" +
                                    " , btem_tabla" +
                                    " , btem_registroid" +
                                    " , btem_valor_antes" +
                                    " , btem_valor_despues" +
                                    " , btem_mostrar" +
                                    " , btem_fechacreacion" +
                                    " ) " +
                                    " VALUES " +
                                    " ( " +
                                    TipoNotificacionID.ToString +
                                    " , " + RegistroPrincipalID.ToString +
                                    " ,' " + Trim(NivelInformacion) + "' " +
                                    " ,' " + Trim(nombre_nivel_informacion1) + "' " +
                                    " ,' " + Trim(nombre_nivel_informacion2) + "' " +
                                    " ," + Orden.ToString + " " +
                                    " ,'" + ApartadoPrincipal + "' " +
                                    " ,'" + Apartado + "' " +
                                    " ,'" + Etiqueta + "' " +
                                    " ,'" + Trim(campo) + "' " +
                                    " ,'" + Trim(tabla) + "' " +
                                    " ," + registroID.ToString +
                                    " ,'" + UCase(Valor_antes) + "' " +
                                    " ,'" + UCase(Valor_despues) + "' " +
                                    " ,'" + Mostrar.ToString + "' " +
                                    " , GETDATE() " +
                                    " )"

                        objBU.insertar_registros_tabla_bitacora_temporal(consulta)

                    End If

                End While
                NivelInformacion_anterior = NivelInformacion
                nombre_nivel_informacion1_Anterior = nombre_nivel_informacion1
                nombre_nivel_informacion2_Anterior = nombre_nivel_informacion2
                registroID_anterior = registroID
                tablaOrigen_anterior = tablaOrigen
            Next

        End If




        Dim s As String = email
        recuperar_datos_bitacora_ordenada(TipoNotificacionID, RegistroPrincipalID)
    End Sub

    Private Sub recuperar_datos_bitacora_ordenada(TipoNotificacionID As Integer, RegistroPrincipalID As Integer)

        Dim objBU As New Framework.Negocios.BitacoraBU
        Try
            tblBitacoraOrdenada = objBU.recuperar_registros_tabla_bitacora_temporal(TipoNotificacionID, RegistroPrincipalID)
        Catch ex As Exception

        End Try

        If tblBitacoraOrdenada.Rows.Count > 0 Then

            email += "" +
                                                                "<div id='" + "bitacora" + "'>" +
                                                                    "<table id='" + "mi_tabla" + "' class='" + "tableizer-table" + "' cellspacing='0'>"

            tblEmail.Columns.Add("nivel_informacion")
            tblEmail.Columns.Add("etiqueta_campo")
            tblEmail.Columns.Add("valor_anterior")
            tblEmail.Columns.Add("valor_actual")
            tblEmail.Columns.Add("operacion_bitacora")
            tblEmail.Columns.Add("registro_id")
            tblEmail.Rows.Add("", "CAMPO", "ANTERIOR", "ACTUAL", "OPERACIÓN", "")

            Dim NivelInformacion_Anterior As String = String.Empty
            Dim nombre_nivel_informacion1_Anterior As String = String.Empty
            Dim nombre_nivel_informacion2_Anterior As String = String.Empty
            Dim ApartadoPrincipal_Anterior As String = String.Empty
            Dim Apartado_Anterior As String = String.Empty
            Dim Etiqueta_Anterior As String = String.Empty
            Dim registroID_Anterior As String = String.Empty
            Dim tipo_infomacion_Anterior As String = String.Empty
            Dim usuario_Anterior As String = String.Empty

            For Each row As DataRow In tblBitacoraOrdenada.Rows


                Dim NivelInformacion As String = String.Empty
                Dim nombre_nivel_informacion1 As String = String.Empty
                Dim nombre_nivel_informacion2 As String = String.Empty
                Dim ApartadoPrincipal As String = String.Empty
                Dim Apartado As String = String.Empty
                Dim Etiqueta As String = String.Empty
                Dim ValorAntes As String = String.Empty
                Dim ValorDespues As String = String.Empty
                Dim registroID As String = String.Empty
                Dim usuario As String = String.Empty

                If Not String.IsNullOrWhiteSpace(CStr(row.Item("btem_nivelinformacion"))) Then
                    NivelInformacion = Trim(CStr(row.Item("btem_nivelinformacion")))
                End If
                If Not String.IsNullOrWhiteSpace(CStr(row.Item("btem_nombrenivelinformacion1"))) Then
                    nombre_nivel_informacion1 = Trim(CStr(row.Item("btem_nombrenivelinformacion1")))
                End If
                If Not String.IsNullOrWhiteSpace(CStr(row.Item("btem_nombrenivelinformacion2"))) Then
                    nombre_nivel_informacion2 = Trim(CStr(row.Item("btem_nombrenivelinformacion2")))
                End If
                If Not String.IsNullOrWhiteSpace(CStr(row.Item("btem_apartadoprincipal"))) Then
                    ApartadoPrincipal = Trim(CStr(row.Item("btem_apartadoprincipal")))
                End If
                If Not String.IsNullOrWhiteSpace(CStr(row.Item("btem_apartado"))) Then
                    Apartado = Trim(CStr(row.Item("btem_apartado")))
                End If
                If Not String.IsNullOrWhiteSpace(CStr(row.Item("btem_etiqueta"))) Then
                    Etiqueta = Trim(CStr(row.Item("btem_etiqueta")))
                End If
                If Not String.IsNullOrWhiteSpace(CStr(row.Item("btem_valor_antes"))) Then
                    ValorAntes = Trim(CStr(row.Item("btem_valor_antes")))
                End If
                If Not String.IsNullOrWhiteSpace(CStr(row.Item("btem_valor_despues"))) Then
                    ValorDespues = Trim(CStr(row.Item("btem_valor_despues")))
                End If
                If Not String.IsNullOrWhiteSpace(CStr(row.Item("btem_registroid"))) Then
                    registroID = Trim(CStr(row.Item("btem_registroid")))
                End If

                If Not String.IsNullOrWhiteSpace(CStr(tblUsuariosModifica.Rows(0).Item("usuario"))) Then
                    usuario = Trim(CStr(tblUsuariosModifica.Rows(0).Item("usuario")))
                End If

                Dim tipo_infomacion As String = String.Empty

                If Not String.IsNullOrEmpty(NivelInformacion) Then
                    If Not NivelInformacion.Equals(NivelInformacion_Anterior) Then
                        tblEmail.Rows.Add(String.Empty, String.Empty, String.Empty, String.Empty, String.Empty)
                        tblEmail.Rows.Add(NivelInformacion, String.Empty, String.Empty, String.Empty, String.Empty)
                    End If
                End If

                If Not String.IsNullOrEmpty(nombre_nivel_informacion1) Then
                    If Not nombre_nivel_informacion1.Equals(nombre_nivel_informacion1_Anterior) Then
                        tblEmail.Rows.Add("&nbsp;&nbsp;&nbsp;" + nombre_nivel_informacion1, String.Empty, String.Empty, String.Empty, String.Empty, String.Empty)
                    Else
                        If Not NivelInformacion.Equals(NivelInformacion_Anterior) And nombre_nivel_informacion1.Equals(nombre_nivel_informacion1_Anterior) Then
                            tblEmail.Rows.Add("&nbsp;&nbsp;&nbsp;" + nombre_nivel_informacion1, String.Empty, String.Empty, String.Empty, String.Empty, String.Empty)
                        End If
                    End If
                End If

                If Not String.IsNullOrEmpty(nombre_nivel_informacion2) Then
                    If Not nombre_nivel_informacion2.Equals(nombre_nivel_informacion2_Anterior) Then
                        tblEmail.Rows.Add("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + nombre_nivel_informacion2, String.Empty, String.Empty, String.Empty, String.Empty, String.Empty)
                    Else
                        If Not NivelInformacion.Equals(NivelInformacion_Anterior) And nombre_nivel_informacion2.Equals(nombre_nivel_informacion2_Anterior) Then
                            tblEmail.Rows.Add("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + vbTab + nombre_nivel_informacion2, String.Empty, String.Empty, String.Empty, String.Empty, String.Empty)
                        End If
                    End If
                End If

                If Not String.IsNullOrEmpty(ApartadoPrincipal) Then
                    If Not ApartadoPrincipal.Equals(ApartadoPrincipal_Anterior) Then
                        tblEmail.Rows.Add("&nbsp;&nbsp;&nbsp;&nbsp;" + ApartadoPrincipal, String.Empty, String.Empty, String.Empty, String.Empty, String.Empty)
                    Else
                        If Not NivelInformacion.Equals(NivelInformacion_Anterior) And ApartadoPrincipal.Equals(ApartadoPrincipal_Anterior) Then
                            tblEmail.Rows.Add("&nbsp;&nbsp&nbsp;&nbsp;" + ApartadoPrincipal, String.Empty, String.Empty, String.Empty, String.Empty, String.Empty)
                        End If
                    End If
                End If

                If Not String.IsNullOrEmpty(Apartado) Then
                    If Not Apartado.Equals(Apartado_Anterior) Then
                        tblEmail.Rows.Add("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + Apartado, String.Empty, String.Empty, String.Empty, String.Empty, String.Empty)
                    Else
                        If Not NivelInformacion.Equals(NivelInformacion_Anterior) And Apartado.Equals(Apartado_Anterior) Then
                            tblEmail.Rows.Add("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + Apartado, String.Empty, String.Empty, String.Empty, String.Empty, String.Empty)
                        End If
                    End If
                End If


                Dim Operacion As String = "Modificación"
                If String.IsNullOrEmpty(ValorAntes) Then
                    Operacion = "Alta"
                End If

                tblEmail.Rows.Add(String.Empty, Etiqueta, ValorAntes, ValorDespues, Operacion, registroID)

                NivelInformacion_Anterior = NivelInformacion
                nombre_nivel_informacion1_Anterior = nombre_nivel_informacion1
                nombre_nivel_informacion2_Anterior = nombre_nivel_informacion2
                ApartadoPrincipal_Anterior = ApartadoPrincipal
                Apartado_Anterior = Apartado
                Etiqueta_Anterior = Etiqueta
                registroID_Anterior = registroID
                tipo_infomacion_Anterior = tipo_infomacion
                usuario_Anterior = usuario

            Next

            Dim tblEmail_limpio As New DataTable
            tblEmail_limpio = tblEmail.Clone
            For Each row As DataRow In tblEmail.Rows
                If tblEmail.Rows.IndexOf(row) = 0 Then
                    tblEmail_limpio.ImportRow(row)
                Else
                    If String.IsNullOrEmpty(row.Item(1)) Then
                        tblEmail_limpio.ImportRow(row)
                    Else
                        If row.Item(1).ToString.Equals(tblEmail.Rows(tblEmail.Rows.IndexOf(row) - 1).Item(1).ToString) Then

                            If row.Item(1).ToString.Equals(tblEmail.Rows(tblEmail.Rows.IndexOf(row) - 1).Item(1).ToString) _
                               And row.Item(5).ToString.Equals(tblEmail.Rows(tblEmail.Rows.IndexOf(row) - 1).Item(5).ToString) _
                                Then
                                tblEmail_limpio.Rows(tblEmail_limpio.Rows.Count - 1).Item(3) = row.Item(3).ToString
                            Else
                                tblEmail_limpio.Rows.Add("", "", row.Item(2).ToString, row.Item(3).ToString, row.Item(4).ToString, row.Item(5).ToString)
                            End If

                        Else
                            tblEmail_limpio.ImportRow(row)
                        End If
                    End If
                End If
            Next

            tblEmail_limpio.Columns.Remove("registro_id")

            For Each row As DataRow In tblEmail_limpio.Rows

                If tblEmail_limpio.Rows.IndexOf(row) = 0 Then
                    email += "" +
                               "<thead>" +
                                    "<tr class='" + "tableizer-firstrow" + "'>"
                    For Each col As DataColumn In tblEmail_limpio.Columns
                        email += "" +
                                        "<th bgcolor = '#003366'>" + row.Item(tblEmail_limpio.Columns.IndexOf(col)).ToString + "</th>"
                    Next
                    email += "" +
                                    "</tr>" +
                                "</thead>"
                Else
                    If String.IsNullOrEmpty(row.Item(0)) _
                        And String.IsNullOrEmpty(row.Item(1)) _
                        And String.IsNullOrEmpty(row.Item(2)) _
                        And String.IsNullOrEmpty(row.Item(3)) _
                        And String.IsNullOrEmpty(row.Item(4)) Then
                        email += "" +
                                                                               "<tr>" +
                                                                                   "<td bgcolor='" + "#003366" + "'></td>" +
                                                                                   "<td bgcolor='" + "#003366" + "'></td>" +
                                                                                   "<td bgcolor='" + "#003366" + "'></td>" +
                                                                                   "<td bgcolor='" + "#003366" + "'></td>" +
                                                                                   "<td bgcolor='" + "#003366" + "'></td>" +
                                                                               "</tr>"
                    Else
                        email += "" +
                                    "<tr>"
                        For Each col As DataColumn In tblEmail_limpio.Columns

                            If tblEmail_limpio.Columns.IndexOf(col) = 0 Then
                                If String.IsNullOrEmpty(tblEmail_limpio.Columns.IndexOf(col)) Then
                                    email += "" +
                                     "<td>" + row.Item(tblEmail_limpio.Columns.IndexOf(col)).ToString + "</td>"
                                Else
                                    Dim cadena As String = row.Item(tblEmail_limpio.Columns.IndexOf(col)).ToString
                                    If Not cadena.Contains("&nbsp;") Then
                                        email += "" +
                                                    "<td>" + row.Item(tblEmail_limpio.Columns.IndexOf(col)).ToString + "</td>"
                                    Else
                                        If cadena.Length > 17 Then
                                            cadena = cadena.Substring(17)
                                            If Not cadena.Contains("&nbsp;") Then
                                                email += "" +
                                                            "<td><b>" + row.Item(tblEmail_limpio.Columns.IndexOf(col)).ToString + "</b></td>"
                                            Else
                                                email += "" +
                                                       "<td>" + row.Item(tblEmail_limpio.Columns.IndexOf(col)).ToString + "</td>"
                                            End If
                                        Else
                                            email += "" +
                                                        "<td>" + row.Item(tblEmail_limpio.Columns.IndexOf(col)).ToString + "</td>"
                                        End If
                                    End If
                                End If
                            Else
                                email += "" +
                                  "<td>" + row.Item(tblEmail_limpio.Columns.IndexOf(col)).ToString + "</td>"
                            End If
                        Next

                        email += "" +
                                    "<tr>"
                    End If


                End If


            Next


            email += "" +
                                                                                "<tr>" +
                                                                                    "<td bgcolor='" + "#003366" + "'></td>" +
                                                                                    "<td bgcolor='" + "#003366" + "'></td>" +
                                                                                    "<td bgcolor='" + "#003366" + "'></td>" +
                                                                                    "<td bgcolor='" + "#003366" + "'></td>" +
                                                                                    "<td bgcolor='" + "#003366" + "'></td>" +
                                                                                "</tr>" +
                                                                                 "<tr>" +
                                                                                    "<td></td>" +
                                                                                    "<td></td>" +
                                                                                    "<td></td>" +
                                                                                    "<td></td>" +
                                                                                    "<td align='right'>" + "Modificó: " + Trim(CStr(tblUsuariosModifica.Rows(tblUsuariosModifica.Rows.Count - 1).Item("usuario"))) + "</td>" +
                                                                                "</tr>" +
                                                                            "</table>" +
                                                                        "</div>" +
                                                                    "</div>" +
                                                                "<div id='" + "footer" + "'>" +
                                                                "</div>" +
                                                        "</div>" +
                                                    "</body>" +
                                            "</html>"



        End If



    End Sub

    Private Sub actualizar_registros_notificados_bitacora(TipoNotificacionID As Integer, RegistroPrincipalID As Integer)
        Dim objBu As New Framework.Negocios.BitacoraBU
        objBu.actualizar_registros_notificados_bitacora(TipoNotificacionID, RegistroPrincipalID)
    End Sub

    Private Sub insertar_registros_notificados_bitacora_temporal(TipoNotificacionID As Integer, RegistroPrincipalID As Integer)
        Dim objBu As New Framework.Negocios.BitacoraBU
        objBu.insertar_registros_notificados_bitacora_temporal(TipoNotificacionID, RegistroPrincipalID)
    End Sub

    Private Sub eliminar_datos_bitacora_enviados(TipoNotificacionID As Integer, RegistroPrincipalID As Integer)
        Dim objBu As New Framework.Negocios.BitacoraBU
        objBu.eliminar_datos_bitacora_enviados(TipoNotificacionID, RegistroPrincipalID)
    End Sub

    Private Sub enviar_correo(ByVal naveID As Integer, ByVal clave As String)
        Dim enviosCorreoBU As New Framework.Negocios.EnviosCorreoBU
        Dim destinatarios As String
        Dim correo As New Tools.Correo
        destinatarios = enviosCorreoBU.consulta_destinatarios_email(naveID, clave)

        correo.EnviarCorreoHtml(destinatarios, email_envia, subject, email)

    End Sub

    Private Sub RecuperarUsuariosModifica(tblBitacoras As DataTable)
        Dim fila As DataRow
        Dim objUsuarios As New Framework.Negocios.UsuariosBU

        tblUsuariosModifica.Columns.Add("bitacoraid")
        tblUsuariosModifica.Columns.Add("usuario")

        For Each e In tblBitacora.Rows
            fila = tblUsuariosModifica.NewRow
            fila("bitacoraid") = e("bita_bitacoraid").ToString
            fila("usuario") = objUsuarios.buscarUsuario(e("bita_usuarioid").ToString).PUserUsername
            tblUsuariosModifica.Rows.Add(fila)
        Next

    End Sub

End Class
