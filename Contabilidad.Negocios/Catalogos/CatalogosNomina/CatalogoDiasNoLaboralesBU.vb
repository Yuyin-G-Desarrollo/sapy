Imports System.Windows.Forms

Public Class CatalogoDiasNoLaboralesBU
    Public Function Consulta_DiasFestivos(ByVal anio As Int32) As DataTable
        Dim ObjB As New Contabilidad.Datos.CatalogoDiasNoLaboralesDA
        Return ObjB.consultaDiasNoLaborales(anio)
    End Function

    Public Function InsertarDiaNoLaboral(ByVal entidadDia As Entidades.DiasNoLaborales) As Entidades.DiasNoLaborales
        Dim ObjB As New Contabilidad.Datos.CatalogoDiasNoLaboralesDA
        Dim entidad As New Entidades.DiasNoLaborales
        Try
            Dim respuesta = ObjB.InsertarDiaNoLAboral(entidadDia)
            If IsNothing(respuesta) = False Then
                If respuesta.Rows.Count > 0 Then
                    For Each Fila As DataRow In respuesta.Rows
                        entidad = New Entidades.DiasNoLaborales
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

    Public Function EditarDiaNoLaborables(ByVal fechaAnterior As Date, ByVal fechaEditada As Date, ByVal descripcion As String, ByVal usuario As Integer, ByVal accion As Integer) As Entidades.DiasNoLaborales
        Dim ObjB As New Contabilidad.Datos.CatalogoDiasNoLaboralesDA
        Dim entidad As New Entidades.DiasNoLaborales
        Try
            Dim respuesta = ObjB.EditarDiasNoLaborables(fechaAnterior, fechaEditada, descripcion, usuario, accion)
            If IsNothing(respuesta) = False Then
                If respuesta.Rows.Count > 0 Then
                    For Each Fila As DataRow In respuesta.Rows
                        entidad = New Entidades.DiasNoLaborales
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


    Public Function Patrones(ByVal anio As String) As DataTable
        Dim ObjB As New Contabilidad.Datos.CatalogoDiasNoLaboralesDA
        Return ObjB.patrones(anio)
    End Function

    Public Function llenarcmbDescripciones(ByVal ComboEntrada As System.Windows.Forms.ComboBox) As ComboBox
        Dim ObjB As New Contabilidad.Datos.CatalogoDiasNoLaboralesDA
        llenarcmbDescripciones = New ComboBox
        llenarcmbDescripciones = ComboEntrada
        Dim listaEntidad As New List(Of Entidades.DiasNoLaborales)
        Dim entidad As New Entidades.DiasNoLaborales

        Dim tablaCSueldo As New DataTable
        tablaCSueldo = ObjB.descripcionDias()
        If IsNothing(tablaCSueldo) = False Then
            If tablaCSueldo.Rows.Count > 0 Then
                For Each Fila As DataRow In tablaCSueldo.Rows
                    entidad = New Entidades.DiasNoLaborales
                    With entidad
                        .Descripción = Fila.Item("Descripcion")
                        listaEntidad.Add(entidad)
                    End With

                Next
            End If
        End If


        llenarcmbDescripciones.DataSource = listaEntidad
        llenarcmbDescripciones.DisplayMember = "Descripción"
        llenarcmbDescripciones.ValueMember = "Descripción"

    End Function

    Public Function PerdiodoSSCerrado(ByVal fechaISS As Date, ByVal fechaFSS As Date, ByVal idPeriodo As Integer) As Integer
        Dim ObjB As New Contabilidad.Datos.CatalogoDiasNoLaboralesDA
        Dim tablaCSueldo As New DataTable
        Dim count As Integer = 0
        tablaCSueldo = ObjB.periodoCerrado(fechaISS, fechaFSS, idPeriodo)
        If IsNothing(tablaCSueldo) = False Then
            If tablaCSueldo.Rows.Count > 0 Then
                For Each Fila As DataRow In tablaCSueldo.Rows
                    count = Fila.Item("contador")
                Next
            End If
        End If
        Return count
    End Function




    Public Function Consulta_PeriodoVacacional(ByVal anio As Int32, ByVal patron As Integer) As DataTable
        Dim ObjB As New Contabilidad.Datos.CatalogoDiasNoLaboralesDA
        Return ObjB.consultaPeridoVacaciones(anio, patron)
    End Function

    Public Function InsertarVacaciones(ByVal entidadVacaciones As Entidades.DiasNoLaborales) As Entidades.DiasNoLaborales
        Dim ObjB As New Contabilidad.Datos.CatalogoDiasNoLaboralesDA
        Dim entidad As New Entidades.DiasNoLaborales
        Try
            Dim respuesta = ObjB.InsertarVacaciones(entidadVacaciones)
            If IsNothing(respuesta) = False Then
                If respuesta.Rows.Count > 0 Then
                    For Each Fila As DataRow In respuesta.Rows
                        entidad = New Entidades.DiasNoLaborales
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

    Public Function EditarVacaciones(ByVal entidadDia As Entidades.DiasNoLaborales) As Entidades.DiasNoLaborales
        Dim ObjB As New Contabilidad.Datos.CatalogoDiasNoLaboralesDA
        Dim entidad As New Entidades.DiasNoLaborales
        Try
            Dim respuesta = ObjB.EditarVacaciones(entidadDia)
            If IsNothing(respuesta) = False Then
                If respuesta.Rows.Count > 0 Then
                    For Each Fila As DataRow In respuesta.Rows
                        entidad = New Entidades.DiasNoLaborales
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
            entidad.Mensaje = "Ocurrio un error favor de comunicarse con TI" + " " + ex.Message
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
