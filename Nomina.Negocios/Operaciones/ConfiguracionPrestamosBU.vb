Public Class ConfiguracionPrestamosBU

    Public Function ListaConfiguracionPrestamos(ByVal IdUsuario As Int32, ByVal Naves As Boolean) As List(Of Entidades.ConfiguracionPrestamos)
        Dim objDA As New Datos.ConfiguracionPrestamosDA
        Dim tabla As New DataTable
        ListaConfiguracionPrestamos = New List(Of Entidades.ConfiguracionPrestamos)

        tabla = objDA.ListaNaves(IdUsuario, Naves)

        For Each fila As DataRow In tabla.Rows
            Dim configuracionPrestamo As New Entidades.ConfiguracionPrestamos

            If IsDBNull(fila("cpre_semanasmaximo")) Then
                configuracionPrestamo.PSemanasMaximo = 0

            Else
                configuracionPrestamo.PSemanasMaximo = CInt(fila("cpre_semanasmaximo"))
            End If

            If IsDBNull(fila("cpre_configuracionprestamoid")) Then
                configuracionPrestamo.PConfiguracionPrestamoId = 0
            Else
                configuracionPrestamo.PConfiguracionPrestamoId = CInt(fila("cpre_configuracionprestamoid"))
            End If

            If IsDBNull(fila("cpre_montomaximonave")) Then
                configuracionPrestamo.PMontoMaximoPorNave = 0
            Else
                configuracionPrestamo.PMontoMaximoPorNave = CDbl(fila("cpre_montomaximonave"))
            End If

            If IsDBNull(fila("cpre_montomaximocolaborador")) Then
                configuracionPrestamo.PMontoMaximoPorColaborador = 0
            Else
                configuracionPrestamo.PMontoMaximoPorColaborador = CDbl(fila("cpre_montomaximocolaborador"))
            End If

            If IsDBNull(fila("cpre_interes")) Then
                configuracionPrestamo.PInteres = 0
            Else
                configuracionPrestamo.PInteres = CDbl(fila("cpre_interes"))
            End If

            If IsDBNull(fila("cpre_interessobresaldo")) Then
                configuracionPrestamo.PInteres = False
            Else
                configuracionPrestamo.PInteresSobreSaldo = CBool(fila("cpre_interessobresaldo"))
            End If

            If IsDBNull(fila("cpre_interesfijo")) Then
                configuracionPrestamo.PInteresFijo = False
            Else
                configuracionPrestamo.PInteresFijo = CBool(fila("cpre_interesfijo"))
            End If

            If IsDBNull(fila("cpre_sininteres")) Then
                configuracionPrestamo.PSinInteres = False
            Else
                configuracionPrestamo.PSinInteres = CBool(fila("cpre_sininteres"))
            End If

            If IsDBNull(fila("cpre_autorizaciongerente")) Then
                configuracionPrestamo.PAutorizacionGerente = False
            Else
                configuracionPrestamo.PAutorizacionGerente = CBool(fila("cpre_autorizaciongerente"))
            End If

            If IsDBNull(fila("cpre_autorizaciondirector")) Then
                configuracionPrestamo.PAutorizacionDirector = False
            Else
                configuracionPrestamo.PAutorizacionDirector = CBool(fila("cpre_autorizaciondirector"))
            End If


            Dim nave As New Entidades.Naves
            nave.PNaveId = CInt(fila("nave_naveid"))
            nave.PNombre = CStr(fila("nave_nombre"))

            configuracionPrestamo.PNaves = nave
            ListaConfiguracionPrestamos.Add(configuracionPrestamo)
        Next
    End Function

    Public Sub guardarConfiguracionPrestamos(ByVal prestamo As Entidades.ConfiguracionPrestamos)
        Dim objPrestamo As New Datos.ConfiguracionPrestamosDA
        objPrestamo.ConfiguracionPrestamoGuardar(prestamo)
    End Sub
End Class
