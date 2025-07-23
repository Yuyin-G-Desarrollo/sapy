Imports Nomina.Datos
Public Class ColaboradorRealBU

    Public Function BuscarColaboradorReal(ByVal idEmpleado As Int32) As Entidades.ColaboradorReal
        Dim ObjColaboradorReal As New Datos.ColaboradorRealDA
        Dim tblColaboradorReal As DataTable
        tblColaboradorReal = ObjColaboradorReal.BuscarDatosReales(idEmpleado)
        BuscarColaboradorReal = New Entidades.ColaboradorReal
        For Each row As DataRow In tblColaboradorReal.Rows

            BuscarColaboradorReal.PFecha = CDate(row("real_fecha"))
            BuscarColaboradorReal.PCantidad = CInt(row("real_cantidad"))
            BuscarColaboradorReal.PTipo = CStr(row("real_tiposueldo"))
            BuscarColaboradorReal.PTipoPago = CStr(row("real_tipo"))
            If Not IsDBNull(row("real_cuenta")) Then
                BuscarColaboradorReal.PNumero = CStr(row("real_cuenta"))
            End If
            If Not IsDBNull(row("real_sueldosemanalaguinaldo")) Then
                BuscarColaboradorReal.PSueldoSemanalAguinaldo = CStr(row("real_sueldosemanalaguinaldo"))
            End If

            Try
                BuscarColaboradorReal.PBanco = CInt(row("real_banco"))
            Catch ex As Exception

            End Try

            Try
                BuscarColaboradorReal.PCostoFraccion = CDbl(row("real_costofraccion"))
            Catch ex As Exception

            End Try


        Next
        Return BuscarColaboradorReal
    End Function

    Public Sub GuardarColaboradorReal(ByVal real As Entidades.ColaboradorReal)
        Dim ObjColaboradorReal As New Datos.ColaboradorRealDA
        ObjColaboradorReal.GuardarColaboradorReal(real)
    End Sub


    Public Sub EditarColaboradorReal(ByVal real As Entidades.ColaboradorReal, ByVal colaboradorId As Int32)
        Dim ObjColaboradorReal As New Datos.ColaboradorRealDA
        ObjColaboradorReal.EditarColaboradorReal(real, colaboradorId)
    End Sub


    Public Function ValidarUpdateOrInsertReal(ByVal ColaboradorId As Int32) As Int32
        Dim ObjDa As New Datos.ColaboradorRealDA
        Dim tabla As New DataTable
        Dim CountReal As Int32
        tabla = ObjDa.BuscarDatosReales(ColaboradorId)
        CountReal = tabla.Rows.Count
        Return CountReal
    End Function

    Public Sub insertarFaltaColaboradorNuevo(ByVal idNave As Int32, ByVal fecha As String, ByVal idColaborador As Int32, ByVal tipoCheck As Int32)
        Dim ObjColaboradorReal As New Datos.ColaboradorRealDA
        ObjColaboradorReal.insertarFaltaColaboradorNuevo(idNave, fecha, idColaborador, tipoCheck)
    End Sub
End Class
