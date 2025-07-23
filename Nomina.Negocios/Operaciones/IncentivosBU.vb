Imports Nomina.Datos
Imports System.Data.SqlClient
Public Class IncentivosBU
    Public Sub guardarIncentivo(ByVal incentivo As Entidades.Incentivos)
        Dim objIncentivo As New IncentivosDA
        objIncentivo.AltaIncentivo(incentivo)
    End Sub

    Public Function ConcentradoAnualGratificaciones(ByVal Naveid As Int32) As DataTable
        Dim objDa As New IncentivosDA
        Return objDa.ConcentradoGratificacionesAnual(Naveid)
    End Function


    Public Function buscarMotivoIncentivo(ByVal idMotivo As Int32) As Entidades.Incentivos
        Dim objPDA As New Datos.IncentivosDA 'Creamos el objeto referente a la capa de Datos
        Dim objIntentivo As New IncentivosDA
        Dim tabla As New DataTable 'Creamos tabla de tipo DataTable
        tabla = objIntentivo.buscarMotivoIncentivo(idMotivo)
        Dim Incentivo As New Entidades.Incentivos
        For Each fila As DataRow In tabla.Rows

            Incentivo.INombre = CStr(fila("moin_nombre"))
            Incentivo.IActivo = CBool(fila("moin_activo"))
            Incentivo.IIncentivoId = CInt(fila("moin_motivoincentivoid"))
            Incentivo.IMontoMaximo = CInt(fila("moin_montomax"))
            Incentivo.IDescripcion = CStr(fila("moin_descripcion"))
        Next

        Return Incentivo
    End Function

    Public Function buscarNombreIncentivo(ByVal idMotivo As Int32) As String
        Dim objPDA As New Datos.IncentivosDA 'Creamos el objeto referente a la capa de Datos
        Dim objIntentivo As New IncentivosDA
        Dim tabla As New DataTable 'Creamos tabla de tipo DataTable
        tabla = objIntentivo.buscarMotivoIncentivo(idMotivo)
        Dim Incentivo As New Entidades.Incentivos
        Dim NNombre As String = ""
        For Each fila As DataRow In tabla.Rows

            NNombre = CStr(fila("moin_nombre"))
           
        Next
        buscarNombreIncentivo = NNombre
        Return buscarNombreIncentivo
    End Function
   


    Public Function BuscarSolicitudIncentivo(ByVal idSolicitudIncentivo As Int32) As Entidades.SolicitudIncentivos
        Dim objDA As New Datos.IncentivosDA
        Dim Tabla As New DataTable
        Tabla = objDA.BuscarSolicitudIncetivo(idSolicitudIncentivo)
        Dim Solicitud As New Entidades.SolicitudIncentivos
        For Each fila As DataRow In Tabla.Rows
            Dim Incentivo As New Entidades.Incentivos
            Incentivo.IIncentivoId = CInt(fila("soin_motivoincentivoid"))
            Solicitud.PMotivoID = Incentivo
            Solicitud.PMonto = CInt(fila("soin_monto"))
            Solicitud.PDescripcion = CStr(fila("soin_justificación"))
        Next
        Return Solicitud

    End Function

    Public Function BuscarSolicitudIncentivosVarios(ByVal idSolicitudIncentivo As Int32) As Entidades.SolicitudIncentivos
        Dim objDA As New Datos.IncentivosDA
        Dim Tabla As New DataTable
        Tabla = objDA.BuscarSolicitudIncetivo(idSolicitudIncentivo)
        Dim Solicitud As New Entidades.SolicitudIncentivos
        For Each fila As DataRow In Tabla.Rows
            Dim Incentivo As New Entidades.Incentivos
            Dim Incentivo2 As New Entidades.Incentivos
            Dim Incentivo3 As New Entidades.Incentivos
            If Not IsDBNull(fila("soin_motivoincentivoid2")) Then
                Incentivo2.IIncentivoId = CInt(fila("soin_motivoincentivoid2"))
            End If
            If Not IsDBNull(fila("soin_motivoincentivoid3")) Then
                Incentivo3.IIncentivoId = CInt(fila("soin_motivoincentivoid3"))
            End If
            Incentivo.IIncentivoId = CInt(fila("soin_motivoincentivoid"))
            Solicitud.PMotivoID = Incentivo
            ' Solicitud.PMonto = CInt(fila("soin_monto"))
            Solicitud.PMotivoID2 = Incentivo2
            Solicitud.PMotivoID3 = Incentivo3
            If Not IsDBNull(fila("soin_monto1")) Then
                Solicitud.PMontoGratificacion1 = CInt(fila("soin_monto1"))
            End If
            If Not IsDBNull(fila("soin_monto2")) Then
                Solicitud.PMontoGratificacion2 = CInt(fila("soin_monto2"))
            End If
            If Not IsDBNull(fila("soin_monto3")) Then
                Solicitud.PMontoGratificacion3 = CInt(fila("soin_monto3"))
            End If
            Solicitud.PDescripcion = CStr(fila("soin_justificación"))
        Next
        Return Solicitud

    End Function

    Public Sub EnviarSolicitudIncentivo(ByVal SolicitudIncentivo As Entidades.SolicitudIncentivos, ByVal Naveid As Int32, ByVal periodonomina As Int32)
        Dim objSolIncentivo As New IncentivosDA
        objSolIncentivo.EnviarSolicitud(SolicitudIncentivo, Naveid, periodonomina)
    End Sub


    Public Function EnviarSolicitud(ByVal SolicitudIncentivo As Entidades.SolicitudIncentivos, ByVal Naveid As Int32, ByVal periodonomina As Int32) As String

        'QUITAR

        Dim objSolIncentivo As New IncentivosDA

        EnviarSolicitud = ""

        Dim objListaIncentivos As New IncentivosDA

        'aqui poner consulta si puedo insertar

        Dim tablaIncentivos As New DataTable
        Dim tablaIncentivosAprobados As New DataTable
        tablaIncentivos = objListaIncentivos.ValidacionSolicitudesIncentivos("", "", "A", SolicitudIncentivo.PColaboradorID)
        tablaIncentivosAprobados = objListaIncentivos.ValidacionSolicitudesIncentivos("", "", "B", SolicitudIncentivo.PColaboradorID)

        If (tablaIncentivos.Rows.Count) <= 0 And (tablaIncentivosAprobados.Rows.Count) <= 0 Then
            SolicitudIncentivo.PMotivoID = buscarMotivoIncentivo(SolicitudIncentivo.PMotivoID.IIncentivoId)
            SolicitudIncentivo.PMotivoID2 = buscarMotivoIncentivo(SolicitudIncentivo.PMotivoID2.IIncentivoId)
            SolicitudIncentivo.PMotivoID3 = buscarMotivoIncentivo(SolicitudIncentivo.PMotivoID3.IIncentivoId)
            SolicitudIncentivo.PMonto = SolicitudIncentivo.PMontoGratificacion1 + SolicitudIncentivo.PMontoGratificacion2 + SolicitudIncentivo.PMontoGratificacion3
            Dim MontoMax As New Entidades.Incentivos
            If ((SolicitudIncentivo.PMontoGratificacion1 <= SolicitudIncentivo.PMotivoID.IMontoMaximo) And (SolicitudIncentivo.PMontoGratificacion2 <= SolicitudIncentivo.PMotivoID2.IMontoMaximo) And (SolicitudIncentivo.PMontoGratificacion3 <= SolicitudIncentivo.PMotivoID3.IMontoMaximo)) Then
                objSolIncentivo.EnviarSolicitud(SolicitudIncentivo, Naveid, periodonomina)
            Else
                If SolicitudIncentivo.PMotivoID.IMontoMaximo = 0 And SolicitudIncentivo.PMotivoID2.IMontoMaximo = 0 And SolicitudIncentivo.PMotivoID3.IMontoMaximo = 0 Then
                    objSolIncentivo.EnviarSolicitud(SolicitudIncentivo, Naveid, periodonomina)
                Else

                    EnviarSolicitud = "El monto solicitado excede el limite del monto permitido."
                End If


            End If

        Else
            'objSolIncentivo.EnviarSolicitud(SolicitudIncentivo, Naveid, periodonomina)
            EnviarSolicitud = "No se puede realizar esta Solicitud el usuario ya cuenta con un tramite"

        End If

        Return EnviarSolicitud

    End Function

    Public Sub EditarIncentivo(ByRef incentivo As Entidades.Incentivos)
        Dim objIntentivo As New IncentivosDA
        objIntentivo.EditarIncentivo(incentivo)
    End Sub


    Public Sub EditarSolicitud(ByRef incentivo As Entidades.SolicitudIncentivos, ByVal idsolicitud As Int32)
        Dim objIntentivo As New IncentivosDA
        objIntentivo.EditarSolicitud(incentivo, idsolicitud)
    End Sub




    Public Sub CancelarSolicitud(ByVal IDincentivo As Int32)
        Dim objIncentivo As New IncentivosDA
        objIncentivo.CancelarSolicitudIncentivo(IDincentivo)
    End Sub


    Public Function AceptarSolicitud(ByVal IDincentivo As Int32, ByVal IdAprobo As Int32, ByVal monto As Double, ByVal motivo As Int32) As String
        Dim objIncentivo As New IncentivosDA
        Dim objSolIncentivo As New IncentivosDA

        Dim EnviarSolicitud As String = ""


        Dim objListaIncentivos As New IncentivosDA

        'aqui poner consulta si puedo insertar

        Dim tablaIncentivos As New DataTable
        Dim tablaIncentivosAprobados As New DataTable
        tablaIncentivos = objListaIncentivos.ValidacionSolicitudesIncentivos("", "", "A", IDincentivo)
        tablaIncentivosAprobados = objListaIncentivos.ValidacionSolicitudesIncentivos("", "", "B", IDincentivo)
        Dim SolicitudIncentivo As New Entidades.Incentivos
        If (tablaIncentivos.Rows.Count) <= 0 And (tablaIncentivosAprobados.Rows.Count) <= 0 Then
            SolicitudIncentivo = buscarMotivoIncentivo(motivo)
            Dim MontoMax As New Entidades.Incentivos
            ' If (monto <= SolicitudIncentivo.IMontoMaximo) Then
            objIncentivo.AceptarSolicitudIncentivo(IDincentivo, IdAprobo, monto)
            'Else
            'EnviarSolicitud = "El monto solicitado excede el limite del monto permitido."
            '  End If


        Else

            EnviarSolicitud = "No se puede realizar esta Solicitud el usuario ya cuenta con un tramite"

        End If



        Return EnviarSolicitud

    End Function
    Public Function AceptarSolicitudDirector(ByVal IDincentivo As Int32, ByVal IdAprobo As Int32, ByVal monto As Double, ByVal motivo As Int32) As String
        Dim objIncentivo As New IncentivosDA
        Dim objSolIncentivo As New IncentivosDA

        Dim EnviarSolicitud As String = ""


        Dim objListaIncentivos As New IncentivosDA

        'aqui poner consulta si puedo insertar

        Dim tablaIncentivos As New DataTable
        Dim tablaIncentivosAprobados As New DataTable
        tablaIncentivos = objListaIncentivos.ValidacionSolicitudesIncentivos("", "", "A", IDincentivo)
        tablaIncentivosAprobados = objListaIncentivos.ValidacionSolicitudesIncentivos("", "", "B", IDincentivo)
        Dim SolicitudIncentivo As New Entidades.Incentivos
        If (tablaIncentivos.Rows.Count) <= 0 And (tablaIncentivosAprobados.Rows.Count) <= 0 Then
            SolicitudIncentivo = buscarMotivoIncentivo(motivo)
            Dim MontoMax As New Entidades.Incentivos
            If (monto <= SolicitudIncentivo.IMontoMaximo) Then
                objIncentivo.AceptarSolicitudIncentivoDirector(IDincentivo, IdAprobo, monto)
            Else
                EnviarSolicitud = "El monto solicitado excede el limite del monto permitido."
            End If


        Else

            EnviarSolicitud = "No se puede realizar esta Solicitud el usuario ya cuenta con un tramite"

        End If



        Return EnviarSolicitud
    End Function


    Public Sub SolicitarCajaChicaIncentivo(ByVal IDincentivo As Int32, ByVal IdAprobo As Int32, ByVal monto As Double, ByVal motivo As Int32, ByVal idCaja As Int32)
        Dim objIncentivo As New IncentivosDA
        Dim objSolIncentivo As New IncentivosDA
        Dim objListaIncentivos As New IncentivosDA
        'aqui poner consulta si puedo insertar

        Dim tablaIncentivos As New DataTable
        Dim tablaIncentivosAprobados As New DataTable
        Dim SolicitudIncentivo As New Entidades.Incentivos
        Dim MontoMax As New Entidades.Incentivos

        objIncentivo.SolicitarACajaChica(IDincentivo, IdAprobo, monto)
        If idCaja > 0 Then
            objIncentivo.AgregarIdSolicitudCajaChica(IDincentivo, idCaja)
        End If

    End Sub


    Public Sub RechazarSolicitud(ByVal IDincentivo As Int32, ByVal IdAprobo As Int32)
        Dim objIncentivo As New IncentivosDA
        objIncentivo.RechazarrSolicitudIncentivo(IDincentivo, IdAprobo)
    End Sub


    Public Function ListaIncentivos(ByVal nombre As String, ByVal activo As Boolean, ByVal idNave As Int32) As List(Of Entidades.Incentivos) 'llamamos al metodo con parametros
        Dim objPDA As New Datos.IncentivosDA 'Creamos el objeto referente a la capa de Datos
        Dim tabla As New DataTable 'Creamos tabla de tipo DataTable

        ListaIncentivos = New List(Of Entidades.Incentivos) 'creamos una nueva lista del tipo Entidades de Incentivos
        tabla = objPDA.ListaIncentivos(nombre, activo, idNave) 'Creamos nuestra tabla 
        For Each fila As DataRow In tabla.Rows
            Dim Incentivo As New Entidades.Incentivos
            Incentivo.INombre = CStr(fila("moin_nombre"))
            Incentivo.IActivo = CBool(fila("moin_activo"))
            Incentivo.IIncentivoId = CInt(fila("moin_motivoincentivoid"))
            Incentivo.IMontoMaximo = CInt(fila("moin_montomax"))
            Incentivo.IDescripcion = CStr(fila("moin_descripcion"))

            Dim naves As New Entidades.Naves
            naves.PNaveId = CInt(fila("nave_naveid"))
            naves.PNombre = CStr(fila("nave_nombre"))

            Incentivo.IIncentivosNaveId = naves
            Incentivo.INaveNombre = naves
            ListaIncentivos.Add(Incentivo)



        Next
    End Function


    Public Function ListaSolicitudesIncentivos(ByVal nombre As String, ByVal fecha As String, ByVal estatus As String, ByVal userid As Int32, _
                                               ByVal SegundaFecha As String, ByVal NaveId As Int32, ByVal Accesototal As Boolean, ByVal idPeriodo As Int32) As List(Of Entidades.SolicitudIncentivos)
        Dim ObjeDA As New Datos.IncentivosDA
        Dim tabla As New DataTable

        ListaSolicitudesIncentivos = New List(Of Entidades.SolicitudIncentivos)

        tabla = ObjeDA.ListaSolicitudesIncentivos(nombre, fecha, estatus, userid, SegundaFecha, NaveId, Accesototal, idPeriodo)
        For Each fila As DataRow In tabla.Rows
            Dim Colaborador As New Entidades.Colaborador
            Try
                Colaborador.PNombre = CStr(fila("codr_nombre"))
            Catch ex As Exception

            End Try
            Dim Departamento As New Entidades.Departamentos
            Try

                Departamento.DNombre = CStr(fila("grup_name"))
            Catch ex As Exception

            End Try
            Dim Incentivo As New Entidades.Incentivos
            Try

                Incentivo.INombre = CStr(fila("moin_nombre"))
                Incentivo.IIncentivoId = CInt(fila("moin_motivoincentivoid"))
            Catch ex As Exception

            End Try
            Dim SolicitudIncentivo As New Entidades.SolicitudIncentivos
            Try

                SolicitudIncentivo.PMonto = CInt(fila("soin_monto"))
            Catch ex As Exception

            End Try

            SolicitudIncentivo.PFechaSolicitud = CDate(fila("soin_fechacreacion"))
            If Not IsDBNull(fila("soin_fechaautorizacion")) Then

                SolicitudIncentivo.PFechaAutorizacion = CDate(fila("soin_fechaautorizacion"))
            End If


            Dim Usuarios As New Entidades.Usuarios
            SolicitudIncentivo.PSolicitudID = CInt(fila("soin_solicitudincentivoid"))
            SolicitudIncentivo.PEstatus = CStr(fila("soin_estado"))
            Usuarios.PUserUsername = (fila("user_username"))
            Colaborador.PApaterno = CStr(fila("codr_apellidopaterno"))
            Colaborador.PAmaterno = CStr(fila("codr_apellidomaterno"))
            SolicitudIncentivo.PNombreColaborador = Colaborador
            SolicitudIncentivo.PDepartamento = Departamento
            SolicitudIncentivo.PSolicito = Usuarios
            SolicitudIncentivo.PNombreIncentivo = Incentivo
            SolicitudIncentivo.PColaboradorID = CInt(fila("soin_colaboradorid"))


            Usuarios = New Entidades.Usuarios
            If Not IsDBNull(fila("soin_usuarioautorizo")) Then
                Usuarios.PUserUsername = (fila("nombreAutorizo")).ToString
            Else
                Usuarios.PUserUsername = ""
            End If

            Try
                SolicitudIncentivo.PDescripcion = CStr(fila("soin_justificación"))
            Catch ex As Exception

            End Try

            Dim celulas As New Entidades.Celulas
            If Not IsDBNull(fila("celu_nombre")) Then
                celulas.PNombre = fila("celu_nombre")
            Else
                celulas.PNombre = ""
            End If

            SolicitudIncentivo.Pcelulas = celulas
            SolicitudIncentivo.PAutorizo = Usuarios


            If Not IsDBNull(fila("soin_monto1")) Then
                SolicitudIncentivo.PMontoGratificacion1 = fila("soin_monto1")
            Else
                SolicitudIncentivo.PMontoGratificacion1 = 0
            End If

            If Not IsDBNull(fila("soin_monto2")) Then
                SolicitudIncentivo.PMontoGratificacion2 = fila("soin_monto2")
            Else
                SolicitudIncentivo.PMontoGratificacion2 = 0
            End If

            If Not IsDBNull(fila("soin_monto3")) Then
                SolicitudIncentivo.PMontoGratificacion3 = fila("soin_monto3")
            Else
                SolicitudIncentivo.PMontoGratificacion3 = 0
            End If

            Dim buscarmotivo2, buscarmotivo3 As New IncentivosBU
            Dim motivo2 As String = ""
            Dim motivo3 As String = ""
            Dim incentivo2 As New Entidades.Incentivos
            Dim incentivo3 As New Entidades.Incentivos
            Dim idmotivoincentivo2 As Int32 = 0
            Dim idmotivoincentivo3 As Int32 = 0
            If Not IsDBNull(fila("soin_motivoincentivoid2")) Then
                idmotivoincentivo2 = fila("soin_motivoincentivoid2")
            Else
                idmotivoincentivo2 = 0
            End If
            If Not IsDBNull(fila("soin_motivoincentivoid3")) Then
                idmotivoincentivo3 = fila("soin_motivoincentivoid3")
            Else
                idmotivoincentivo3 = 0
            End If

            motivo2 = buscarmotivo2.buscarNombreIncentivo(idmotivoincentivo2)
            motivo3 = buscarmotivo3.buscarNombreIncentivo(idmotivoincentivo3)
            incentivo2.IIncentivoId = idmotivoincentivo2
            incentivo2.INombre = motivo2
            incentivo3.IIncentivoId = idmotivoincentivo3
            incentivo3.INombre = motivo3
            SolicitudIncentivo.PMotivoID2 = incentivo2
            SolicitudIncentivo.PMotivoID3 = incentivo3

            ListaSolicitudesIncentivos.Add(SolicitudIncentivo)
        Next

    End Function

    Public Function ListaSolicitudesIncentivosConsulta(ByVal nombre As String, ByVal estatus As String, ByVal userid As Int32,
                                              ByVal NaveId As Int32, ByVal Accesototal As Integer, ByVal idPeriodo As Int32) As DataTable
        Dim ObjeDA As New Datos.IncentivosDA
        Dim tabla As New DataTable

        Return ObjeDA.ListaSolicitudesIncentivosConsulta(nombre, estatus, userid, NaveId, Accesototal, idPeriodo)
    End Function


    Public Function ListaSolicitudesIncentivosSinFechas(ByVal nombre As String, ByVal estatus As String, ByVal userid As Int32, ByVal NaveId As Int32, ByVal Accesototal As Boolean, ByVal PeriodoNomina As Int32) As List(Of Entidades.SolicitudIncentivos)
        Dim ObjeDA As New Datos.IncentivosDA
        Dim tabla As New DataTable


        ListaSolicitudesIncentivosSinFechas = New List(Of Entidades.SolicitudIncentivos)



        tabla = ObjeDA.ListaSolicitudesIncentivosSinFechas(nombre, estatus, userid, NaveId, Accesototal, PeriodoNomina)
        For Each fila As DataRow In tabla.Rows
            Dim Colaborador As New Entidades.Colaborador
            Try

                Colaborador.PNombre = CStr(fila("codr_nombre"))
            Catch ex As Exception

            End Try
            Dim Departamento As New Entidades.Departamentos
            Try

                Departamento.DNombre = CStr(fila("grup_name"))
            Catch ex As Exception

            End Try
            Dim Incentivo As New Entidades.Incentivos
            Try

                Incentivo.INombre = CStr(fila("moin_nombre"))
                Incentivo.IIncentivoId = CInt(fila("moin_motivoincentivoid"))
            Catch ex As Exception

            End Try
            Dim SolicitudIncentivo As New Entidades.SolicitudIncentivos
            Try

                SolicitudIncentivo.PMonto = CInt(fila("soin_monto"))
            Catch ex As Exception

            End Try

            SolicitudIncentivo.PFechaSolicitud = CDate(fila("soin_fechacreacion"))
            If Not IsDBNull(fila("soin_fechaautorizacion")) Then

                SolicitudIncentivo.PFechaAutorizacion = CDate(fila("soin_fechaautorizacion"))
            End If




            Dim Usuarios As New Entidades.Usuarios
            SolicitudIncentivo.PSolicitudID = CInt(fila("soin_solicitudincentivoid"))
            SolicitudIncentivo.PEstatus = CStr(fila("soin_estado"))
            Usuarios.PUserUsername = (fila("user_username"))
            Colaborador.PApaterno = CStr(fila("codr_apellidopaterno"))
            Colaborador.PAmaterno = CStr(fila("codr_apellidomaterno"))
            SolicitudIncentivo.PNombreColaborador = Colaborador
            SolicitudIncentivo.PDepartamento = Departamento
            SolicitudIncentivo.PSolicito = Usuarios
            SolicitudIncentivo.PNombreIncentivo = Incentivo
            SolicitudIncentivo.PColaboradorID = CInt(fila("soin_colaboradorid"))


            Usuarios = New Entidades.Usuarios
            If Not IsDBNull(fila("soin_usuarioautorizo")) Then
                Usuarios.PUserUsername = (fila("nombreAutorizo")).ToString
            Else
                Usuarios.PUserUsername = ""
            End If

            Try
                SolicitudIncentivo.PDescripcion = CStr(fila("soin_justificación"))
            Catch ex As Exception

            End Try

            Dim celulas As New Entidades.Celulas
            If Not IsDBNull(fila("celu_nombre")) Then
                celulas.PNombre = fila("celu_nombre")
            Else
                celulas.PNombre = ""
            End If

            SolicitudIncentivo.Pcelulas = celulas
            SolicitudIncentivo.PAutorizo = Usuarios
            '
            If Not IsDBNull(fila("soin_monto1")) Then
                SolicitudIncentivo.PMontoGratificacion1 = fila("soin_monto1")
            Else
                SolicitudIncentivo.PMontoGratificacion1 = 0
            End If

            If Not IsDBNull(fila("soin_monto2")) Then
                SolicitudIncentivo.PMontoGratificacion2 = fila("soin_monto2")
            Else
                SolicitudIncentivo.PMontoGratificacion2 = 0
            End If

            If Not IsDBNull(fila("soin_monto3")) Then
                SolicitudIncentivo.PMontoGratificacion3 = fila("soin_monto3")
            Else
                SolicitudIncentivo.PMontoGratificacion3 = 0
            End If

            Dim buscarmotivo2, buscarmotivo3 As New IncentivosBU
            Dim motivo2 As String = ""
            Dim motivo3 As String = ""
            Dim incentivo2 As New Entidades.Incentivos
            Dim incentivo3 As New Entidades.Incentivos
            Dim idmotivoincentivo2 As Int32 = 0
            Dim idmotivoincentivo3 As Int32 = 0
            If Not IsDBNull(fila("soin_motivoincentivoid2")) Then
                idmotivoincentivo2 = fila("soin_motivoincentivoid2")
            Else
                idmotivoincentivo2 = 0
            End If
            If Not IsDBNull(fila("soin_motivoincentivoid3")) Then
                idmotivoincentivo3 = fila("soin_motivoincentivoid3")
            Else
                idmotivoincentivo3 = 0
            End If

            motivo2 = buscarmotivo2.buscarNombreIncentivo(idmotivoincentivo2)
            motivo3 = buscarmotivo3.buscarNombreIncentivo(idmotivoincentivo3)
            incentivo2.IIncentivoId = idmotivoincentivo2
            incentivo2.INombre = motivo2
            incentivo3.IIncentivoId = idmotivoincentivo3
            incentivo3.INombre = motivo3
            SolicitudIncentivo.PMotivoID2 = incentivo2
            SolicitudIncentivo.PMotivoID3 = incentivo3

            ListaSolicitudesIncentivosSinFechas.Add(SolicitudIncentivo)
        Next

    End Function


    Public Function ListaIncentivosSUsuario(ByVal IDUsuario As Integer, ByVal idNave As Int32) As List(Of Entidades.Incentivos)
        'QUITAR
        Dim objDA As New Datos.IncentivosDA
        Dim tabla As New DataTable
        ListaIncentivosSUsuario = New List(Of Entidades.Incentivos)
        tabla = objDA.ListaIncentivosSegUsuario(IDUsuario, idNave)
        For Each fila As DataRow In tabla.Rows
            Dim IncentivoSegunID As New Entidades.Incentivos
            IncentivoSegunID.INombre = CStr(fila("moin_nombre")).ToUpper
            IncentivoSegunID.IIncentivoId = CInt(fila("moin_motivoincentivoid"))
            IncentivoSegunID.IMontoMaximo = CInt(fila("moin_montomax"))
            ListaIncentivosSUsuario.Add(IncentivoSegunID)
        Next
    End Function


    Public Function ListaIncentivosSUsuarioConsulta(ByVal IDUsuario As Integer, ByVal idNave As Int32) As DataTable
        Dim objDA As New Datos.IncentivosDA
        Dim tabla As New DataTable
        Return objDA.ListaIncentivosSegUsuarioConsulta(IDUsuario, idNave)
    End Function


    Public Function ListaIncentivosSUser(ByVal IDUsuario As Integer) As List(Of Entidades.Incentivos)
        Dim objDA As New Datos.IncentivosDA
        Dim tabla As New DataTable
        ListaIncentivosSUser = New List(Of Entidades.Incentivos)
        tabla = objDA.ListaIncentivosSegUser(IDUsuario)
        For Each fila As DataRow In tabla.Rows
            Dim IncentivoSegunID As New Entidades.Incentivos
            IncentivoSegunID.INombre = CStr(fila("moin_nombre")).ToUpper
            IncentivoSegunID.IIncentivoId = CInt(fila("moin_motivoincentivoid"))
            IncentivoSegunID.IMontoMaximo = CInt(fila("moin_montomax"))
            ListaIncentivosSUser.Add(IncentivoSegunID)
        Next
    End Function


    Public Function TablaImprimirIncentivos(ByVal UsuarioId As Int32, ByVal FechaInicio As String, ByVal FechaDos As String, ByVal NaveId As Int32)
        Dim ObjDA As New IncentivosDA
        TablaImprimirIncentivos = ObjDA.ListaIncentivosSegUserImprimir(UsuarioId, FechaInicio, FechaDos, NaveId)
        Return TablaImprimirIncentivos
    End Function

    Public Function BuscarFechaInicialPerdiodo(ByVal PerionoNomina As Int32) As Date
        Dim objDA As New IncentivosDA
        Dim Tabla As New DataTable
        Tabla = objDA.BuscarFechaInicialPerdiodo(PerionoNomina)
        Dim FechaInicial As New Date
        For Each row As DataRow In Tabla.Rows
            FechaInicial = CDate(row("pnom_FechaInicial"))

        Next
        Return FechaInicial
    End Function

    Public Function BuscarFechaFinalPerdiodo(ByVal PerionoNomina As Int32) As Date
        Dim objDA As New IncentivosDA
        Dim Tabla As New DataTable
        Tabla = objDA.BuscarFechaFinalPerdiodo(PerionoNomina)
        Dim FechaFinal As New Date
        For Each row As DataRow In Tabla.Rows
            FechaFinal = CDate(row("pnom_FechaFinal"))

        Next
        Return FechaFinal
    End Function

    Public Function validarEstatusAutorizado(ByVal colaboradorid As Int32, ByVal solicituid As Int32)
        Dim objDA As New IncentivosDA
        Dim tabla As New DataTable
        Dim estatus As String = ""
        tabla = objDA.validarEstatusAutorizado(colaboradorid, solicituid)
        For Each row As DataRow In tabla.Rows
            estatus = CStr(row("soin_estado"))
        Next
        Return estatus
    End Function

    Public Function validarConfiguracion(ByVal naveID As Integer) As DataTable
        Dim objDA As New IncentivosDA
        Return objDA.validarConfiguracion(naveID)
    End Function

    Public Sub EnviarSolicitudDiaAdicional(ByVal EnviarSolIncentivo As Entidades.SolicitudIncentivos, ByVal Naveid As Int32, ByVal PeriodoNomina As Int32)
        Dim objIntentivo As New IncentivosDA
        objIntentivo.EnviarSolicitudDiaAdicional(EnviarSolIncentivo, Naveid, PeriodoNomina)
    End Sub

    Public Function verIncentivosDiasAdicional(ByVal naveid As Int32) As DataTable
        Dim objDA As New IncentivosDA
        Return objDA.verIncentivosDiasAdicional(naveid)
    End Function

    Public Function validarDiaAdicionalColaborador(ByVal motivoid As Int32, ByVal colaboradorid As Int32, ByVal periodoid As Int32) As Int32
        Dim objDA As New IncentivosDA
        Return objDA.validarDiaAdicionalColaborador(motivoid, colaboradorid, periodoid)
    End Function
End Class
