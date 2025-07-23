Imports Framework.Datos

Public Class ConfiguracionAsistenciaBU


    Public Function listaConfiguracionAsistencia(ByVal naveID As Integer) As List(Of Entidades.ConfiguracionAsistencia)

        Dim objDA As New Datos.ConfiguracionAsistenciaDA
        Dim tabla As New DataTable
        listaConfiguracionAsistencia = New List(Of Entidades.ConfiguracionAsistencia)
        tabla = objDA.listaConfiguracionAsistencia(naveID)
        For Each fila As DataRow In tabla.Rows

            Dim configuracionSegunNave As New Entidades.ConfiguracionAsistencia
            Dim nave As New Entidades.Naves

            'nave.PNaveId = CInt(fila("nave_naveid"))
            'nave.PNombre = CStr(fila("nave_nombre"))
            'configuracionSegunNave.PNaves = nave

            If IsDBNull(fila("confasis_id")) Then
                configuracionSegunNave.PConfiguracionAsistenciaId = Nothing
                configuracionSegunNave.PRango = Nothing
                configuracionSegunNave.PResultadoCheck = Nothing
                configuracionSegunNave.PPorcentaje = Nothing
            Else
                configuracionSegunNave.PConfiguracionAsistenciaId = CInt(fila("confasis_id"))
                configuracionSegunNave.PRango = CInt(fila("confasis_rango"))
                configuracionSegunNave.PResultadoCheck = CInt(fila("confasis_resultado"))
                configuracionSegunNave.PPorcentaje = CDbl(fila("confasis_porcentaje"))
            End If

            listaConfiguracionAsistencia.Add(configuracionSegunNave)

        Next



    End Function

    Public Function listaConfiguracionesUsuarioNave(ByVal IDUsuario As Integer) As List(Of Entidades.ConfiguracionAsistencia)

        Dim objDA As New Datos.ConfiguracionAsistenciaDA
        Dim tabla As New DataTable
        listaConfiguracionesUsuarioNave = New List(Of Entidades.ConfiguracionAsistencia)
        tabla = objDA.listaConfiguracionesUsuarioNave(IDUsuario)
        For Each fila As DataRow In tabla.Rows

            Dim configuracionSegunNave As New Entidades.ConfiguracionAsistencia
            Dim nave As New Entidades.Naves

            nave.PNaveId = CInt(fila("nave_naveid"))
            nave.PNombre = CStr(fila("nave_nombre"))
            configuracionSegunNave.PNaves = nave

            If IsDBNull(fila("confasis_id")) Then
                configuracionSegunNave.PConfiguracionAsistenciaId = Nothing
                configuracionSegunNave.PRango = Nothing
                configuracionSegunNave.PResultadoCheck = Nothing
                configuracionSegunNave.PPorcentaje = Nothing
            Else
                configuracionSegunNave.PConfiguracionAsistenciaId = CInt(fila("confasis_id"))
                configuracionSegunNave.PRango = CInt(fila("confasis_rango"))
                configuracionSegunNave.PResultadoCheck = CInt(fila("confasis_resultado"))
                configuracionSegunNave.PPorcentaje = CDbl(fila("confasis_porcentaje"))
            End If

            listaConfiguracionesUsuarioNave.Add(configuracionSegunNave)

        Next

    End Function

    Public Sub guardarConfiguracionAsistencia(ByVal configuracionAsistencia As Entidades.ConfiguracionAsistencia)

        Dim objConfiguracionAsistencia As New Datos.ConfiguracionAsistenciaDA

        objConfiguracionAsistencia.guardarConfiguracionAsistencia(configuracionAsistencia)

    End Sub

End Class
