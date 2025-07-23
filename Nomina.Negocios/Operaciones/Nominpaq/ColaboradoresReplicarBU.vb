Public Class ColaboradoresReplicarBU




    Public Function ListaColaboradores(ByVal idNave As Integer, ByVal estatus As String) As List(Of Entidades.ColaboradoresReplicar)
        Dim objDA As New Nomina.Datos.ColaboradoresReplicarDA

        Dim tabla As New DataTable

        ListaColaboradores = New List(Of Entidades.ColaboradoresReplicar)
        tabla = objDA.ListaColaboradores(idNave, estatus)

        For Each fila As DataRow In tabla.Rows
            Dim ColaboradorEnt As New Entidades.Colaborador
            Dim ColaboradorReal As New Entidades.ColaboradorReal
            Dim nominaReal As New Entidades.CalcularNominaReal
            Dim ciudades As New Entidades.Ciudades
            Dim CiudadesOrigen As New Entidades.Ciudades
            Dim ColaboradoresReplicar As New Entidades.ColaboradoresReplicar

            ColaboradorEnt.PColaboradorid = CInt(fila("codr_colaboradorid"))
            If Not IsDBNull(fila("codr_nominpaqid")) Then
                ColaboradorEnt.PColaboradoridNP = fila("codr_nominpaqid")
            End If

            If Not IsDBNull(fila("codr_CodigoEmpleadoNP")) Then
                ColaboradorEnt.PCodigoEmpleadoNp = fila("codr_CodigoEmpleadoNP")
            End If

            If Not IsDBNull(fila("codr_idciudadorigen")) Then
                CiudadesOrigen.CciudadId = fila("codr_idciudadorigen")
            End If

            If Not IsDBNull(fila("codr_ciudadid")) Then
                ciudades.CciudadId = fila("codr_ciudadid")
            End If

            ColaboradorEnt.PNombre = CStr(fila("codr_nombre"))
            ColaboradorEnt.PApaterno = CStr(fila("codr_apellidopaterno"))
            ColaboradorEnt.PAmaterno = CStr(fila("codr_apellidomaterno"))

            ColaboradorReal.PCantidad = CDbl(fila("real_cantidad"))
            ColaboradorReal.PFecha = CDate(fila("real_fecha"))

            ColaboradoresReplicar.PColaborador = ColaboradorEnt
            ColaboradoresReplicar.PColaboradorReal = ColaboradorReal
            ColaboradoresReplicar.PCiudades = ciudades
            ColaboradoresReplicar.PCiudadesOrigen = CiudadesOrigen


            ListaColaboradores.Add(ColaboradoresReplicar)
        Next

    End Function

    Public Function CiudadNombre(ByVal IDCiudad As Integer) As Entidades.ColaboradoresReplicar
        Dim ObjDA As New Nomina.Datos.ColaboradoresReplicarDA
        Dim ObjENT As New Entidades.ColaboradoresReplicar
        Dim Tabla As DataTable
        CiudadNombre = New Entidades.ColaboradoresReplicar
        Tabla = ObjDA.CiudadNombre(IDCiudad)

        For Each fila As DataRow In Tabla.Rows
            Dim Ciudades As New Entidades.Ciudades
            Dim Estados As New Entidades.Estados
            Ciudades.CNombre = fila("city_nombre")
            Estados.ENombre = fila("esta_nombre")
            ObjENT.PCiudades = Ciudades
            ObjENT.PEstados = Estados
        Next
        Return ObjENT
    End Function

    Public Sub ReplciarColaboradoresUpdate(ByVal Colaborador As Entidades.ColaboradoresReplicar, ByVal BD As String, ByVal servidor As String)
        Dim ObjDA As New Nomina.Datos.ColaboradoresReplicarDA
        ObjDA.ReplciarColaboradoresUpdate(Colaborador, BD, servidor)
    End Sub

    Public Sub ReplciarColaboradoresInsert(ByVal Colaborador As Entidades.ColaboradoresReplicar, ByVal BD As String, ByVal servidor As String)
        Dim ObjDA As New Nomina.Datos.ColaboradoresReplicarDA
        ObjDA.ReplciarColaboradoresInsert(Colaborador, BD, servidor)
    End Sub



    Public Sub ReplicarNominpaqSay(ByVal idNave As Integer, ByVal BD As String, ByVal Servidor As String)
        Dim ObjDA As New Nomina.Datos.ColaboradoresReplicarDA
        ObjDA.ReplicarNominpaqSay(idNave, BD, Servidor)
    End Sub

    Public Sub ActualizarEditar(ByVal idColaborador As Integer)
        Dim ObjDA As New Nomina.Datos.ColaboradoresReplicarDA
        ObjDA.ActualizarEditar(idColaborador)
    End Sub

    Public Function validarCodigoEmpleadoNPSAY(ByVal codigoEmpleado As String, ByVal BD As String, ByVal Servidor As String) As DataTable
        Dim objDA As New Datos.ColaboradoresReplicarDA
        Return objDA.validarCodigoEmpleadoNPSAY(codigoEmpleado, BD, Servidor)
    End Function

End Class
