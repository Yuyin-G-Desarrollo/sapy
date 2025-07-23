Imports System.Data.SqlClient
Public Class TallasDA

    Public Function VerTallas(ByVal descripcion As String, ByVal idTalla As String, ByVal activo As Boolean, ByVal grupo As String)
        Dim operacion As New Persistencia.OperacionesProcedimientos

        Dim ListaParametros As New List(Of SqlClient.SqlParameter)

        Dim ParametroParaLista As New SqlParameter
        ParametroParaLista.ParameterName = "descripcion"
        ParametroParaLista.Value = descripcion
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "idTalla"
        ParametroParaLista.Value = idTalla
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "activo"
        ParametroParaLista.Value = activo.ToString
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "grupo"
        ParametroParaLista.Value = grupo.ToString
        ListaParametros.Add(ParametroParaLista)

        Return operacion.EjecutarConsultaSP("Programacion.SP_Consulta_Tallas", ListaParametros)

    End Function

    Public Function VerPaisesTalla() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Return operacion.EjecutaConsulta("SELECT pais_paisid, pais_nombre, pais_activo FROM Framework.Paises WHERE pais_activo = 'True'")
    End Function

    Public Function VerTallasPrincipales() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Return operacion.EjecutaConsulta("SELECT  tt.talla_tallaid,tt.talla_enteros,tt.talla_sicy, (tt.talla_descripcion+'  ('+ pp.pais_nombre+')') as 'pais' FROM Programacion.Tallas as tt inner join Framework.Paises as pp on tt.talla_paisid =pp.pais_paisid  WHERE talla_tallaprincipalid IS NULL")
    End Function

    Public Function verificarEntero() As Boolean
        Dim operacion As New Persistencia.OperacionesProcedimientos


        Return False
    End Function

    Public Sub RegistrarDatosTalla(ByVal EntidadTallas As Entidades.Tallas, ByVal usuario As Int32)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)
        'If (EntidadTallas.PTallaPrincipal = Nothing) Then
        '    operacion.EjecutaSentencia("insert into Programacion.Tallas (talla_descripcion, talla_inicio, talla_fin, talla_grupo, talla_tallacentral, talla_enteros, talla_paisid, talla_activo, talla_usuariocreoid, talla_fechacreacion) values ('" + EntidadTallas.PTDescripcion + "', '" + EntidadTallas.PTallaInicio + "', '" + EntidadTallas.PTallaFin + "', '" + EntidadTallas.PTallaGrupo + "', '" + EntidadTallas.PTallaCentral + "', '" + EntidadTallas.PTEntero.ToString + "'," + EntidadTallas.PTallaPais.ToString + ", '" + EntidadTallas.PTAcvito.ToString + "', " + usuario.ToString + ", GETDATE())")
        'Else

        '    operacion.EjecutaSentencia("insert into Programacion.Tallas (talla_descripcion, talla_inicio, talla_fin, talla_grupo, talla_tallacentral, talla_enteros, talla_paisid, talla_tallaprincipalid, talla_activo, talla_usuariocreoid, talla_fechacreacion) values ('" + EntidadTallas.PTDescripcion + "', '" + EntidadTallas.PTallaInicio + "', '" + EntidadTallas.PTallaFin + "', '" + EntidadTallas.PTallaGrupo + "', '" + EntidadTallas.PTallaCentral + "', '" + EntidadTallas.PTEntero.ToString + "'," + EntidadTallas.PTallaPais.ToString + ", " + EntidadTallas.PTallaPrincipal + " , '" + EntidadTallas.PTAcvito.ToString + "', " + usuario.ToString + ", GETDATE())")
        'End If


        Dim ParametroParaLista As New SqlParameter
        ParametroParaLista.ParameterName = "descripcion"
        ParametroParaLista.Value = EntidadTallas.PTDescripcion
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "inicio"
        ParametroParaLista.Value = EntidadTallas.PTallaInicio
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "fin"
        ParametroParaLista.Value = EntidadTallas.PTallaFin
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "grupo"
        ParametroParaLista.Value = EntidadTallas.PTallaGrupo
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "tallacentral"
        ParametroParaLista.Value = EntidadTallas.PTallaCentral
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "enteros"
        ParametroParaLista.Value = EntidadTallas.PTEntero
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "paisid"
        ParametroParaLista.Value = EntidadTallas.PTallaPais
        ListaParametros.Add(ParametroParaLista)

        If (EntidadTallas.PTallaPrincipal = Nothing) Then
            ParametroParaLista = New SqlParameter
            ParametroParaLista.ParameterName = "tallaPrincipalid"
            ParametroParaLista.Value = ""
            ListaParametros.Add(ParametroParaLista)
        Else
            ParametroParaLista = New SqlParameter
            ParametroParaLista.ParameterName = "tallaPrincipalid"
            ParametroParaLista.Value = EntidadTallas.PTallaPrincipal
            ListaParametros.Add(ParametroParaLista)
        End If
        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "activo"
        ParametroParaLista.Value = EntidadTallas.PTAcvito
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "usuariocreoid"
        ParametroParaLista.Value = usuario
        ListaParametros.Add(ParametroParaLista)


        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "sicy"
        ParametroParaLista.Value = EntidadTallas.PSicyTalla
        ListaParametros.Add(ParametroParaLista)


        operacion.EjecutarSentenciaSP("Programacion.SP_Alta_Talla_descripcion", ListaParametros)

    End Sub

    Public Sub inretarTallas(ByVal Talla As String, ByVal tallaDescripcion As String, ByVal IdTalla As Int32)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        operacion.EjecutaSentencia("Update Programacion.Tallas set talla_t" + Talla + "='" + tallaDescripcion + "' where talla_tallaid =" + IdTalla.ToString + "")
    End Sub

    Public Function maximaTallaId() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Return operacion.EjecutaConsulta("Select max(talla_tallaid) as 'idMax' from Programacion.Tallas")
    End Function

    Public Function VerDatosTallaEditar(ByVal idTalla As Int32) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Return operacion.EjecutaConsulta("SELECT talla_tallaid, talla_descripcion as 'Talla', talla_inicio as 'Inicio', talla_fin as 'Fin'," +
                                           " talla_t1 as 'T1',talla_t2 'T2',talla_t3 'T3',talla_t4 'T4',talla_t5 'T5',talla_t6 'T6',talla_t7 'T7',talla_t8 'T8',talla_t9 'T9',talla_t10 'T10'," +
                                           " talla_t11 as 'T11',talla_t12 'T12',talla_t13 'T13',talla_t14 'T14',talla_t15 'T15',talla_t16 'T16',talla_t17 'T17',talla_t18 'T18',talla_t19 'T19',talla_t20 'T20'," +
                                           " talla_grupo as 'Grupo', talla_tallacentral, talla_paisid  as 'pais',talla_enteros as 'EnterosT',talla_tallaprincipalid  AS 'tallabase'," +
                                           " talla_activo as 'activo', talla_sicy FROM Programacion.Tallas where talla_tallaid =" + idTalla.ToString + "")
    End Function

    Public Sub EditaTalla(ByVal EntidadTalla As Entidades.Tallas, ByVal usuario As Int32)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)
   

        Dim ParametroParaLista As New SqlParameter
        ParametroParaLista.ParameterName = "Descripcion"
        ParametroParaLista.Value = EntidadTalla.PTDescripcion
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "Inicio"
        ParametroParaLista.Value = EntidadTalla.PTallaInicio
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "Fin"
        ParametroParaLista.Value = EntidadTalla.PTallaFin
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "Central"
        ParametroParaLista.Value = EntidadTalla.PTallaCentral
        ListaParametros.Add(ParametroParaLista)


        If (EntidadTalla.PTalla1 = Nothing) Then
            ParametroParaLista = New SqlParameter
            ParametroParaLista.ParameterName = "Talla1"
            ParametroParaLista.Value = ""
            ListaParametros.Add(ParametroParaLista)
        Else
            ParametroParaLista = New SqlParameter
            ParametroParaLista.ParameterName = "Talla1"
            ParametroParaLista.Value = EntidadTalla.PTalla1.ToString
            ListaParametros.Add(ParametroParaLista)
        End If


        If (EntidadTalla.PTalla2 = Nothing) Then
            ParametroParaLista = New SqlParameter
            ParametroParaLista.ParameterName = "Talla2"
            ParametroParaLista.Value = ""
            ListaParametros.Add(ParametroParaLista)
        Else
            ParametroParaLista = New SqlParameter
            ParametroParaLista.ParameterName = "Talla2"
            ParametroParaLista.Value = EntidadTalla.PTalla2.ToString
            ListaParametros.Add(ParametroParaLista)
        End If

        If (EntidadTalla.PTalla3 = Nothing) Then
            ParametroParaLista = New SqlParameter
            ParametroParaLista.ParameterName = "Talla3"
            ParametroParaLista.Value = ""
            ListaParametros.Add(ParametroParaLista)
        Else
            ParametroParaLista = New SqlParameter
            ParametroParaLista.ParameterName = "Talla3"
            ParametroParaLista.Value = EntidadTalla.PTalla3.ToString
            ListaParametros.Add(ParametroParaLista)
        End If

        If (EntidadTalla.PTalla4 = Nothing) Then
            ParametroParaLista = New SqlParameter
            ParametroParaLista.ParameterName = "Talla4"
            ParametroParaLista.Value = ""
            ListaParametros.Add(ParametroParaLista)
        Else
            ParametroParaLista = New SqlParameter
            ParametroParaLista.ParameterName = "Talla4"
            ParametroParaLista.Value = EntidadTalla.PTalla4.ToString
            ListaParametros.Add(ParametroParaLista)
        End If

        If (EntidadTalla.PTalla5 = Nothing) Then
            ParametroParaLista = New SqlParameter
            ParametroParaLista.ParameterName = "Talla5"
            ParametroParaLista.Value = ""
            ListaParametros.Add(ParametroParaLista)
        Else
            ParametroParaLista = New SqlParameter
            ParametroParaLista.ParameterName = "Talla5"
            ParametroParaLista.Value = EntidadTalla.PTalla5.ToString
            ListaParametros.Add(ParametroParaLista)
        End If

        If (EntidadTalla.PTalla6 = Nothing) Then
            ParametroParaLista = New SqlParameter
            ParametroParaLista.ParameterName = "Talla6"
            ParametroParaLista.Value = ""
            ListaParametros.Add(ParametroParaLista)
        Else
            ParametroParaLista = New SqlParameter
            ParametroParaLista.ParameterName = "Talla6"
            ParametroParaLista.Value = EntidadTalla.PTalla6.ToString
            ListaParametros.Add(ParametroParaLista)
        End If

        If (EntidadTalla.PTalla7 = Nothing) Then
            ParametroParaLista = New SqlParameter
            ParametroParaLista.ParameterName = "Talla7"
            ParametroParaLista.Value = ""
            ListaParametros.Add(ParametroParaLista)
        Else
            ParametroParaLista = New SqlParameter
            ParametroParaLista.ParameterName = "Talla7"
            ParametroParaLista.Value = EntidadTalla.PTalla7.ToString
            ListaParametros.Add(ParametroParaLista)
        End If

        If (EntidadTalla.PTalla8 = Nothing) Then
            ParametroParaLista = New SqlParameter
            ParametroParaLista.ParameterName = "Talla8"
            ParametroParaLista.Value = ""
            ListaParametros.Add(ParametroParaLista)
        Else
            ParametroParaLista = New SqlParameter
            ParametroParaLista.ParameterName = "Talla8"
            ParametroParaLista.Value = EntidadTalla.PTalla8.ToString
            ListaParametros.Add(ParametroParaLista)
        End If

        If (EntidadTalla.PTalla9 = Nothing) Then
            ParametroParaLista = New SqlParameter
            ParametroParaLista.ParameterName = "Talla9"
            ParametroParaLista.Value = ""
            ListaParametros.Add(ParametroParaLista)
        Else
            ParametroParaLista = New SqlParameter
            ParametroParaLista.ParameterName = "Talla9"
            ParametroParaLista.Value = EntidadTalla.PTalla9.ToString
            ListaParametros.Add(ParametroParaLista)
        End If

        If (EntidadTalla.PTalla10 = Nothing) Then
            ParametroParaLista = New SqlParameter
            ParametroParaLista.ParameterName = "Talla10"
            ParametroParaLista.Value = ""
            ListaParametros.Add(ParametroParaLista)
        Else
            ParametroParaLista = New SqlParameter
            ParametroParaLista.ParameterName = "Talla10"
            ParametroParaLista.Value = EntidadTalla.PTalla10.ToString
            ListaParametros.Add(ParametroParaLista)
        End If
        '------------------------------------
        If (EntidadTalla.PTalla11 = Nothing) Then
            ParametroParaLista = New SqlParameter
            ParametroParaLista.ParameterName = "Talla11"
            ParametroParaLista.Value = ""
            ListaParametros.Add(ParametroParaLista)
        Else
            ParametroParaLista = New SqlParameter
            ParametroParaLista.ParameterName = "Talla11"
            ParametroParaLista.Value = EntidadTalla.PTalla11.ToString
            ListaParametros.Add(ParametroParaLista)
        End If


        If (EntidadTalla.PTalla12 = Nothing) Then
            ParametroParaLista = New SqlParameter
            ParametroParaLista.ParameterName = "Talla12"
            ParametroParaLista.Value = ""
            ListaParametros.Add(ParametroParaLista)
        Else
            ParametroParaLista = New SqlParameter
            ParametroParaLista.ParameterName = "Talla12"
            ParametroParaLista.Value = EntidadTalla.PTalla12.ToString
            ListaParametros.Add(ParametroParaLista)
        End If

        If (EntidadTalla.PTalla13 = Nothing) Then
            ParametroParaLista = New SqlParameter
            ParametroParaLista.ParameterName = "Talla13"
            ParametroParaLista.Value = ""
            ListaParametros.Add(ParametroParaLista)
        Else
            ParametroParaLista = New SqlParameter
            ParametroParaLista.ParameterName = "Talla13"
            ParametroParaLista.Value = EntidadTalla.PTalla13.ToString
            ListaParametros.Add(ParametroParaLista)
        End If

        If (EntidadTalla.PTalla14 = Nothing) Then
            ParametroParaLista = New SqlParameter
            ParametroParaLista.ParameterName = "Talla14"
            ParametroParaLista.Value = ""
            ListaParametros.Add(ParametroParaLista)
        Else
            ParametroParaLista = New SqlParameter
            ParametroParaLista.ParameterName = "Talla14"
            ParametroParaLista.Value = EntidadTalla.PTalla14.ToString
            ListaParametros.Add(ParametroParaLista)
        End If

        If (EntidadTalla.PTalla15 = Nothing) Then
            ParametroParaLista = New SqlParameter
            ParametroParaLista.ParameterName = "Talla15"
            ParametroParaLista.Value = ""
            ListaParametros.Add(ParametroParaLista)
        Else
            ParametroParaLista = New SqlParameter
            ParametroParaLista.ParameterName = "Talla15"
            ParametroParaLista.Value = EntidadTalla.PTalla15.ToString
            ListaParametros.Add(ParametroParaLista)
        End If

        If (EntidadTalla.PTalla16 = Nothing) Then
            ParametroParaLista = New SqlParameter
            ParametroParaLista.ParameterName = "Talla16"
            ParametroParaLista.Value = ""
            ListaParametros.Add(ParametroParaLista)
        Else
            ParametroParaLista = New SqlParameter
            ParametroParaLista.ParameterName = "Talla16"
            ParametroParaLista.Value = EntidadTalla.PTalla16.ToString
            ListaParametros.Add(ParametroParaLista)
        End If

        If (EntidadTalla.PTalla17 = Nothing) Then
            ParametroParaLista = New SqlParameter
            ParametroParaLista.ParameterName = "Talla17"
            ParametroParaLista.Value = ""
            ListaParametros.Add(ParametroParaLista)
        Else
            ParametroParaLista = New SqlParameter
            ParametroParaLista.ParameterName = "Talla17"
            ParametroParaLista.Value = EntidadTalla.PTalla17.ToString
            ListaParametros.Add(ParametroParaLista)
        End If

        If (EntidadTalla.PTalla18 = Nothing) Then
            ParametroParaLista = New SqlParameter
            ParametroParaLista.ParameterName = "Talla18"
            ParametroParaLista.Value = ""
            ListaParametros.Add(ParametroParaLista)
        Else
            ParametroParaLista = New SqlParameter
            ParametroParaLista.ParameterName = "Talla18"
            ParametroParaLista.Value = EntidadTalla.PTalla18.ToString
            ListaParametros.Add(ParametroParaLista)
        End If

        If (EntidadTalla.PTalla19 = Nothing) Then
            ParametroParaLista = New SqlParameter
            ParametroParaLista.ParameterName = "Talla19"
            ParametroParaLista.Value = ""
            ListaParametros.Add(ParametroParaLista)
        Else
            ParametroParaLista = New SqlParameter
            ParametroParaLista.ParameterName = "Talla19"
            ParametroParaLista.Value = EntidadTalla.PTalla19.ToString
            ListaParametros.Add(ParametroParaLista)
        End If

        If (EntidadTalla.PTalla20 = Nothing) Then
            ParametroParaLista = New SqlParameter
            ParametroParaLista.ParameterName = "Talla20"
            ParametroParaLista.Value = ""
            ListaParametros.Add(ParametroParaLista)
        Else
            ParametroParaLista = New SqlParameter
            ParametroParaLista.ParameterName = "Talla20"
            ParametroParaLista.Value = EntidadTalla.PTalla20.ToString
            ListaParametros.Add(ParametroParaLista)
        End If
        '-------------------


        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "Enteros"
        ParametroParaLista.Value = EntidadTalla.PTEntero
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "Grupo"
        ParametroParaLista.Value = EntidadTalla.PTallaGrupo
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "Pais"
        ParametroParaLista.Value = EntidadTalla.PTallaPais
        ListaParametros.Add(ParametroParaLista)

        If (EntidadTalla.PTallaPrincipal = Nothing) Then
            ParametroParaLista = New SqlParameter
            ParametroParaLista.ParameterName = "TallaPrincipal"
            ParametroParaLista.Value = ""
            ListaParametros.Add(ParametroParaLista)
        Else
            ParametroParaLista = New SqlParameter
            ParametroParaLista.ParameterName = "TallaPrincipal"
            ParametroParaLista.Value = EntidadTalla.PTallaPrincipal
            ListaParametros.Add(ParametroParaLista)
        End If

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "Activo"
        ParametroParaLista.Value = EntidadTalla.PTAcvito
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "usuario"
        ParametroParaLista.Value = usuario
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "idTalla"
        ParametroParaLista.Value = EntidadTalla.PTallaID
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "sicy"
        ParametroParaLista.Value = EntidadTalla.PSicyTalla
        ListaParametros.Add(ParametroParaLista)

        operacion.EjecutarSentenciaSP("Programacion.SP_Editar_Tallas", ListaParametros)

        'operacion.EjecutaSentencia("Update Programacion.Tallas set talla_descripcion='" + EntidadTalla.PTDescripcion + "', talla_inicio=" + EntidadTalla.PTallaInicio.ToString + ", talla_fin=" + EntidadTalla.PTallaFin.ToString + ", talla_tallacentral='" + EntidadTalla.PTallaCentral.ToString + "'," +
        '                           " talla_t1='" + EntidadTalla.PTalla1 + "', talla_t2='" + EntidadTalla.PTalla2 + "',talla_t3='" + EntidadTalla.PTalla3 + "',talla_t4='" + EntidadTalla.PTalla4 + "',talla_t5='" + EntidadTalla.PTalla5 + "'," +
        '                           " talla_t6='" + EntidadTalla.PTalla6 + "', talla_t7='" + EntidadTalla.PTalla7 + "',  talla_t8='" + EntidadTalla.PTalla8 + "', talla_t9='" + EntidadTalla.PTalla9 + "', talla_t10='" + EntidadTalla.PTalla10 + "', " +
        '                           " talla_t11='" + EntidadTalla.PTalla11 + "', talla_t12='" + EntidadTalla.PTalla12 + "',talla_t13='" + EntidadTalla.PTalla13 + "',talla_t14='" + EntidadTalla.PTalla14 + "',talla_t15='" + EntidadTalla.PTalla15 + "'," +
        '                           " talla_t16='" + EntidadTalla.PTalla16 + "', talla_t17='" + EntidadTalla.PTalla17 + "',  talla_t18='" + EntidadTalla.PTalla18 + "', talla_t19='" + EntidadTalla.PTalla19 + "', talla_t20='" + EntidadTalla.PTalla20 + "', " +
        '                           " talla_enteros='" + EntidadTalla.PTEntero.ToString + "', talla_grupo='" + EntidadTalla.PTallaGrupo + "', talla_paisid=" + EntidadTalla.PTallaPais.ToString + ", talla_tallaprincipalid=" + EntidadTalla.PTallaPrincipal.ToString + ", talla_activo='" + EntidadTalla.PTAcvito.ToString + "'," +
        '                           " talla_usuariomodifico=" + usuario.ToString + ", talla_fechamodificacion=GETDATE() where talla_tallaid=" + EntidadTalla.PTallaID.ToString + " ")
    End Sub

    Public Function VerAmarres(ByVal idTalla As Int32) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Return operacion.EjecutaConsulta("select am.amarre_media1 ,am.amarre_media2, am.amarre_total  from Programacion.Amarres as am inner join Programacion.Tallas as tt" +
                                         " on am.amarre_tallaid =tt.talla_tallaid where tt.talla_tallaid=  " + idTalla.ToString + ";")
    End Function

    Public Sub AlterarAmarres(ByVal IdTalla As Int32)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        operacion.EjecutaSentencia("delete from Programacion.Amarres where amarre_tallaid =" + IdTalla.ToString + ";")
    End Sub

    Public Sub AltaAmarre(ByVal idTalla As Int32, ByVal descripcion As String, ByVal amarreUno As Int32, ByVal amarreDos As Int32, ByVal total As Int32)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        operacion.EjecutaSentencia("insert into Programacion.Amarres(amarre_tallaid ,amarre_talladescripcion , amarre_media1 ,amarre_media2, amarre_total ) values (" + idTalla.ToString + ",'" + descripcion + "'," + amarreUno.ToString + "," + amarreDos.ToString + ", " + total.ToString + ")")
    End Sub

    Public Sub AltaAmarreTotal(ByVal idTalla As Int32, ByVal descripcion As String, ByVal total As Int32)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        operacion.EjecutaSentencia("insert into Programacion.Amarres(amarre_tallaid ,amarre_talladescripcion, amarre_total ) values (" + idTalla.ToString + ",'" + descripcion + "'," + total.ToString + ")")
    End Sub

    Public Function VerTallaInicialSeleccionada(ByVal idTallaInicial As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Return operacion.EjecutaConsulta("SELECT talla_tallaid, talla_descripcion as 'Talla', talla_inicio as 'Inicio', talla_fin as 'Fin'," +
                                         " talla_t1 as 'T1',talla_t2 'T2',talla_t3 'T3',talla_t4 'T4',talla_t5 'T5',talla_t6 'T6',talla_t7 'T7',talla_t8 'T8',talla_t9 'T9',talla_t10 'T10'," +
                                         " talla_t11 as 'T11',talla_t12 'T12',talla_t13 'T13',talla_t14 'T14',talla_t15 'T15',talla_t16 'T16',talla_t17 'T17',talla_t18 'T18',talla_t19 'T19',talla_t20 'T20'," +
                                         " talla_grupo as 'Grupo', talla_tallacentral, talla_paisid  as 'pais',talla_enteros as 'EnterosT',talla_tallaprincipalid  AS 'tallabase'," +
                                         " talla_activo as 'activo' FROM Programacion.Tallas where talla_tallaid =" + idTallaInicial + "")
    End Function

    Public Function VerComboTallas() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "select tt.talla_tallaid, tt.talla_descripcion" +
                                " from Programacion.Tallas as tt" +
                                " inner join Framework.Paises as pa" +
                                " on tt.talla_paisid =pa.pais_paisid " +
                                " where talla_activo='True' and pa.pais_paisid = 1" +
                                " ORDER BY talla_descripcion"
        Return operacion.EjecutaConsulta(cadena)
    End Function


    Public Function validaExistenModelos(ByVal idTalla As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "SELECT a.prod_codigo, a.prod_descripcion FROM Programacion.Productos a" +
                                " INNER JOIN Programacion.ProductoEstilo b ON a.prod_productoid = b.pres_productoid" +
                                " INNER JOIN Programacion.EstilosProducto c ON b.pres_estiloid = c.espr_estiloproductoid" +
                                " WHERE a.prod_activo = 1 AND b.pres_activo = 1" +
                                " AND c.espr_tallaid = " + idTalla +
                                " GROUP BY	a.prod_codigo, a.prod_descripcion "
        Return operaciones.EjecutaConsulta(cadena)
    End Function

    Public Function verTallasRegistroRapido(ByVal idsTallas As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "select tt.talla_tallaid, tt.talla_descripcion" +
                                " from Programacion.Tallas as tt" +
                                " inner join Framework.Paises as pa on tt.talla_paisid =pa.pais_paisid " +
                                " where talla_activo='True' and pa.pais_paisid = 1" +
                                " AND tt.talla_tallaid NOT IN (" + idsTallas + ")"
        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Function VerificarTallasInsertadasPorPais(ByVal Pais As String, ByVal TallaPrincipal As String)
        Dim operacion As New Persistencia.OperacionesProcedimientos

        Dim ListaParametros As New List(Of SqlClient.SqlParameter)

        Dim ParametroParaLista As New SqlParameter
        ParametroParaLista.ParameterName = "idPais"
        ParametroParaLista.Value = Pais
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "idTallaPrincipal"
        ParametroParaLista.Value = TallaPrincipal
        ListaParametros.Add(ParametroParaLista)

        Return operacion.EjecutarConsultaSP("Programacion.SP_Tallas_VerificarTallasPorPais", ListaParametros)

    End Function

    Public Sub AltaAmarreSicy(ByVal idTalla As Int32)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)

        Dim ParametroParaLista As New SqlParameter
        ParametroParaLista.ParameterName = "idTalla"
        ParametroParaLista.Value = idTalla
        ListaParametros.Add(ParametroParaLista)

        operacion.EjecutarSentenciaSP("[Programacion].[SP_Alta_Talla_Amarre]", ListaParametros)
    End Sub

End Class
