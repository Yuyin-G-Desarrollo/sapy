Imports System.Windows.Forms

Public Class CatalogoPuestoFiscalBU
    Public Function Consulta_Puestos_Por_Patron(ByVal patron As Integer, estatus As Integer) As DataTable
        Dim ObjB As New Contabilidad.Datos.PuestosFiscalesDA
        Return ObjB.Consulta_Puestos_Por_Patron(patron, estatus)
    End Function

    Public Function InsertarPuesto_PorPatron(ByVal entidadPuesto As Entidades.PuestoFiscal) As Entidades.PuestoFiscal
        Dim ObjB As New Contabilidad.Datos.PuestosFiscalesDA
        Dim entidad As New Entidades.PuestoFiscal
        Try
            Dim respuesta = ObjB.InsertarPuesto_PorPatron(entidadPuesto)
            If IsNothing(respuesta) = False Then
                If respuesta.Rows.Count > 0 Then
                    For Each Fila As DataRow In respuesta.Rows
                        entidad = New Entidades.PuestoFiscal
                        With entidad
                            .Resp = Fila.Item("Respuesta")
                            .Mensaje = Fila.Item("mensaje")
                        End With
                    Next
                End If
            End If
            Return entidad
        Catch ex As Exception
            entidad.Resp = 0
            entidad.Mensaje = "Ocurrio un error favor de comunicarse con TI" + ex.Message
            Return entidad
        End Try

    End Function

    Public Function EliminarPuesto_PorPatron(ByVal accion As Integer, ByVal entidadPuesto As Entidades.PuestoFiscal) As Entidades.PuestoFiscal
        Dim ObjB As New Contabilidad.Datos.PuestosFiscalesDA
        Dim entidad As New Entidades.PuestoFiscal
        Try
            Dim respuesta = ObjB.Eliminar_ActivarPuesto_PorPatron(accion, entidadPuesto)
            If IsNothing(respuesta) = False Then
                If respuesta.Rows.Count > 0 Then
                    For Each Fila As DataRow In respuesta.Rows
                        entidad = New Entidades.PuestoFiscal
                        With entidad
                            .Resp = Fila.Item("Respuesta")
                            .Mensaje = Fila.Item("mensaje")
                        End With
                    Next
                End If
            End If
            Return entidad
        Catch ex As Exception
            entidad.Resp = 0
            entidad.Mensaje = "Ocurrio un error favor de comunicarse con TI" + ex.Message
            Return entidad
        End Try
    End Function


    Public Function llenarcmbPatrón(ByVal ComboEntrada As System.Windows.Forms.ComboBox) As System.Windows.Forms.ComboBox
        Dim ObjB As New Contabilidad.Negocios.UtileriasBU
        llenarcmbPatrón = New ComboBox
        llenarcmbPatrón = ComboEntrada
        Dim listaEntidad As New List(Of Entidades.PuestoFiscal)
        Dim entidad As Entidades.PuestoFiscal

        Dim tablaPatrones As New DataTable
        tablaPatrones = ObjB.consultarPatronEmpresa()
        If IsNothing(tablaPatrones) = False Then
            If tablaPatrones.Rows.Count > 0 Then
                For Each Fila As DataRow In tablaPatrones.Rows
                    entidad = New Entidades.PuestoFiscal
                    With entidad
                        If Fila.Item("ID") > 0 Then
                            .ID_Patron = Fila.Item("ID")
                            Dim strarr() As String
                            strarr = Fila.Item("PATRON").Split("-")
                            .NombrePatron = strarr(1)
                        End If
                    End With
                    listaEntidad.Add(entidad)
                Next
            End If
        End If


        llenarcmbPatrón.DataSource = listaEntidad
        llenarcmbPatrón.DisplayMember = "NombrePatron"
        llenarcmbPatrón.ValueMember = "ID_Patron"

    End Function
End Class
