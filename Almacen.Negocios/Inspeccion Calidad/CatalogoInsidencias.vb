Public Class CatalogoInsidencias
    ' Public Function ConsultarInsidencias(ByVal Status As Integer, ByVal depa As Integer) As List(Of Entidades.CatalogoInsidencias)
    Public Function ConsultarInsidencias(ByVal Status As Integer, ByVal depa As Integer) As DataTable
        Dim objDA As New Datos.CatalogosInsidenciasDA
        Dim tabla As New DataTable
        'Dim EntInspeccion As Entidades.CatalogoInsidencias
        'Dim ListEntidad As New List(Of Entidades.CatalogoInsidencias)
        Try
            tabla = objDA.ConsultarInsidencias(Status, depa)
            'If IsNothing(tabla) = False Then
            '    If tabla.Rows.Count > 0 Then
            '        For Each Fila As DataRow In tabla.Rows
            '            EntInspeccion = New Entidades.CatalogoInsidencias
            '            With EntInspeccion
            '                EntInspeccion.Seleccion = Fila.Item("SELECCION")
            '                EntInspeccion.IDIncidencias = Fila.Item("ID")
            '                EntInspeccion.Incidencias = Fila.Item("Incidencia")
            '                EntInspeccion.IdDepa = Fila.Item("IDDepa")
            '                EntInspeccion.Departamento = Fila.Item("Departamento")
            '                EntInspeccion.Fecha = Fila.Item("Fecha_Creacion")
            '                EntInspeccion.Usuario = Fila.Item("Usuario_Creo")
            '            End With
            '            ListEntidad.Add(EntInspeccion)
            '        Next
            '    End If
            'End If

        Catch ex As Exception
            Throw ex
        End Try

        Return tabla
    End Function


    Public Function AgregarIncidencias(ByVal entidad As Entidades.CatalogoInsidencias) As DataTable
        Dim objDA As New Datos.CatalogosInsidenciasDA
        Dim tabla As New DataTable
        tabla = objDA.AgregarIncidencias(entidad)
        Return tabla
    End Function

    Public Function EditarIncidencias(ByVal entidad As Entidades.CatalogoInsidencias) As DataTable
        Dim objDA As New Datos.CatalogosInsidenciasDA
        Dim tabla As New DataTable
        tabla = objDA.EditarIncidencias(entidad)
        Return tabla
    End Function

    Public Function ModificarEstatusInsidencias(ByVal cadena As String, ByVal usuario As Int16, ByVal status As Integer) As DataTable
        Dim objDA As New Datos.CatalogosInsidenciasDA
        Dim tabla As New DataTable
        tabla = objDA.ModificarEstatusInsidencias(cadena, usuario, status)
        Return tabla
    End Function

    Public Function llenarcmbDepartamento(ByVal ComboEntrada As System.Windows.Forms.ComboBox) As System.Windows.Forms.ComboBox
        Dim ObjB As New Datos.CatalogosInsidenciasDA
        llenarcmbDepartamento = New ComboBox
        llenarcmbDepartamento = ComboEntrada
        Dim listaEntidad As New List(Of Entidades.PuestoFiscal) 'Se reutilizo la entidad puesto fiscal'
        Dim entidad As Entidades.PuestoFiscal

        entidad = New Entidades.PuestoFiscal
        entidad.ID_Patron = 0
        entidad.NombrePatron = ""
        listaEntidad.Add(entidad)
        Dim tablaDepartamentos As New DataTable
        tablaDepartamentos = ObjB.ObtenerDepartamentos()
        If IsNothing(tablaDepartamentos) = False Then
            If tablaDepartamentos.Rows.Count > 0 Then
                For Each Fila As DataRow In tablaDepartamentos.Rows
                    entidad = New Entidades.PuestoFiscal
                    With entidad
                        If Fila.Item("ID") > 0 Then
                            .ID_Patron = Fila.Item("ID")
                            .NombrePatron = Fila.Item("Nombre")
                        End If
                    End With
                    listaEntidad.Add(entidad)
                Next
            End If
        End If
        llenarcmbDepartamento.DataSource = listaEntidad
        llenarcmbDepartamento.DisplayMember = "NombrePatron"
        llenarcmbDepartamento.ValueMember = "ID_Patron"

    End Function

End Class
