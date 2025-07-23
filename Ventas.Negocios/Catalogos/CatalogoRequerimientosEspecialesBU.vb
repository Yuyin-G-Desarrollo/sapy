Public Class CatalogoRequerimientosEspecialesBU


    Public Function ListaRequeriminetos(ByVal Nombre As String, ByVal Tipo As String, ByVal Activo As Boolean) As DataTable
        Dim objListarequerimentosDA As New Datos.CatalogoRequerimientosEspecialesDA
        Dim Tablas As New DataTable
        ListaRequeriminetos = objListarequerimentosDA.listaRequerimientosEspeciales(Nombre, Tipo, Activo)

        Return ListaRequeriminetos
    End Function

    Public Function ListaTipoRequerimientos() As List(Of Entidades.TipoRequerimientosEspeciales)
        Dim objDA As New Datos.CatalogoRequerimientosEspecialesDA
        Dim Tablas As New DataTable

        ListaTipoRequerimientos = New List(Of Entidades.TipoRequerimientosEspeciales)
        Tablas = objDA.ListaTipoRequerimiento
        For Each fila As DataRow In Tablas.Rows
            Dim tipoRequerimiento As New Entidades.TipoRequerimientosEspeciales
            tipoRequerimiento.PIdTipo = CInt(fila("ID"))
            tipoRequerimiento.PTipo = CStr(fila("Nombre")).ToUpper

            ListaTipoRequerimientos.Add(tipoRequerimiento)
        Next

        Return ListaTipoRequerimientos
    End Function

    Public Sub GuardarRequerimiento(ByVal Requerimiento As Entidades.CatalogoRequerimientosEspeciales)
        Dim objGuardarRequerimientoDA As New Datos.CatalogoRequerimientosEspecialesDA
        objGuardarRequerimientoDA.AltaRequerimientos(Requerimiento)

    End Sub

    Public Sub ActualizarRequerimiento(ByVal Requerimiento As Entidades.CatalogoRequerimientosEspeciales)
        Dim objActualizarRequerimientoDA As New Datos.CatalogoRequerimientosEspecialesDA
        objActualizarRequerimientoDA.editarRequerimiento(Requerimiento)
    End Sub

End Class
