Imports System.Windows.Forms

Public Class CatalogoDepartamentoBU
    Public Function Consulta_Departamento_Por_Patron(ByVal patron As Integer, estatus As Integer) As DataTable
        Dim ObjB As New Contabilidad.Datos.CatalogoDepartamentosDA
        Return ObjB.Consulta_Departamento_Por_Patron(patron, estatus)
    End Function


    Public Function InsertarDepartamento_PorPatron(ByVal entidadDepartamento As Entidades.DepartamentosByPatron) As Entidades.DepartamentosByPatron
        Dim ObjB As New Contabilidad.Datos.CatalogoDepartamentosDA
        Dim entidad As New Entidades.DepartamentosByPatron
        Try
            Dim respuesta = ObjB.InsertarDepartamento_PorPatron(entidadDepartamento)
            If IsNothing(respuesta) = False Then
                If respuesta.Rows.Count > 0 Then
                    For Each Fila As DataRow In respuesta.Rows
                        entidad = New Entidades.DepartamentosByPatron
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

    Public Function EliminarDepartamento_PorPatron(ByVal accion As Integer, ByVal departamento As Entidades.DepartamentosByPatron) As Entidades.DepartamentosByPatron
        Dim ObjB As New Contabilidad.Datos.CatalogoDepartamentosDA
        Dim entidad As New Entidades.DepartamentosByPatron
        Try
            Dim respuesta = ObjB.Eliminar_ActivarDepartamento_PorPatron(accion, departamento)
            If IsNothing(respuesta) = False Then
                If respuesta.Rows.Count > 0 Then
                    For Each Fila As DataRow In respuesta.Rows
                        entidad = New Entidades.DepartamentosByPatron
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

    Public Function llenarcmbClaves(ByVal ComboEntrada As System.Windows.Forms.ComboBox, ByVal tipoClave As Integer) As ComboBox
        Dim ObjB As New Contabilidad.Datos.CatalogoDepartamentosDA
        llenarcmbClaves = New ComboBox
        llenarcmbClaves = ComboEntrada
        Dim listaEntidad As New List(Of Entidades.DepartamentosByPatron)
        Dim entidad As New Entidades.DepartamentosByPatron

        Dim tablaCSueldo As New DataTable
        tablaCSueldo = ObjB.consultarClaves(tipoClave)
        If IsNothing(tablaCSueldo) = False Then
            If tablaCSueldo.Rows.Count > 0 Then
                For Each Fila As DataRow In tablaCSueldo.Rows
                    entidad = New Entidades.DepartamentosByPatron
                    With entidad
                        If Fila.Item("Clave").Equals("Empty") Then

                        Else
                            .ClaveSueldo = Fila.Item("Clave")
                            listaEntidad.Add(entidad)
                        End If
                    End With

                Next
            End If
        End If


        llenarcmbClaves.DataSource = listaEntidad
        llenarcmbClaves.DisplayMember = "ClaveSueldo"
        llenarcmbClaves.ValueMember = "ClaveSueldo"

    End Function

End Class
