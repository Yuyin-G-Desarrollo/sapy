Public Class AutorizacionPrestamoBU

    Public Function NavesColaborador(ByRef idColaborador As Integer) As DataTable
        Dim objDA As New Datos.AutorizacionPrestamoDA
        Return objDA.NavesColaborador(idColaborador)
    End Function


    Public Function ListaPrestamos(ByVal IdNave As Int32) As List(Of Entidades.AutorizacionPrestamo)
        Dim objDA As New Datos.AutorizacionPrestamoDA
        Dim tabla As New DataTable
        ListaPrestamos = New List(Of Entidades.AutorizacionPrestamo)

        tabla = objDA.ListaPrestamos(IdNave)

        For Each fila As DataRow In tabla.Rows
            Dim Prestamo As New Entidades.AutorizacionPrestamo
            Dim colaborador As New Entidades.Colaborador
            Prestamo.PprestamoId = CInt(fila("pres_prestamoid"))
            Prestamo.Psaldo = CDbl(fila("pres_montoautorizado"))
            Prestamo.Psemanas = CInt(fila("pres_semanasautorizadas"))
            Prestamo.Ptipodeinteres = CStr(fila("pres_tipointeresautorizado"))
            Prestamo.Pinteres = CStr(fila("pres_interesautorizado"))
            Prestamo.Pnombre = CStr(fila("codr_nombre"))
            Prestamo.PapellidoPaterno = CStr(fila("codr_apellidopaterno"))
            Prestamo.PapellidoMaterno = CStr(fila("codr_apellidomaterno"))
            Prestamo.Pabono = CDbl(fila("pres_abonoautorizado"))
            Prestamo.Pestatus = CStr(fila("pres_estatus"))
            Prestamo.Pjustificacion = CStr(fila("pres_justificacion"))

            colaborador.PColaboradorid = CInt(fila("pres_colaboradorid"))
            Prestamo.PColabodadorId = colaborador
            ListaPrestamos.Add(Prestamo)



         



        Next
    End Function


    Public Sub guardarAutorizacionPrestamosDirector(ByVal prestamo As Entidades.AutorizacionPrestamo)
        Dim objPrestamo As New Datos.AutorizacionPrestamoDA
        objPrestamo.AutorizacionDirectorGuardar(prestamo)
    End Sub









End Class
