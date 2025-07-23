Public Class CatalogoMaterialesMercadotecniaBU

    ''Función ListaDias para llenar la lista
    Public Function ListaMateriales(ByVal activo As Boolean, ByVal nombreMaterial As String, tipo As String) As DataTable
        Dim objListaMaterialesDA As New Datos.CatalogoMaterialesMercadotecniaDA
        Dim tablas As New DataTable
        ListaMateriales = objListaMaterialesDA.ListaMaterialesMercadotecnia(activo, nombreMaterial, tipo)

        Return ListaMateriales
    End Function

    ''Funcion para llenar el combo box
    Public Function ListaTipoMateriales() As List(Of Entidades.TipoMaterialesMercadotecnia)
        Dim objDA As New Datos.CatalogoMaterialesMercadotecniaDA
        Dim tabla As New DataTable
        ListaTipoMateriales = New List(Of Entidades.TipoMaterialesMercadotecnia)
        tabla = objDA.ListaTipoMateriales()
        For Each fila As DataRow In tabla.Rows
            Dim tipoMateriales As New Entidades.TipoMaterialesMercadotecnia
            tipoMateriales.PTipoMaterial = CStr(fila("tmme_nombre")).ToUpper
            tipoMateriales.PidTipoMaterial = CInt(fila("tmme_tipomaterialmercadotecniaid"))
            ListaTipoMateriales.Add(tipoMateriales)
        Next
        Return ListaTipoMateriales
    End Function

    ''funcion para guardar 
    Public Sub guardarMateriales(ByVal Materiales As Entidades.CatalogoMaterialesMercadotecnia)
        Dim objMaterialesMercadotecnia As New Datos.CatalogoMaterialesMercadotecniaDA
        objMaterialesMercadotecnia.AltaMateriales(Materiales)
    End Sub

    Public Sub editarMateriales(ByVal Materiales As Entidades.CatalogoMaterialesMercadotecnia)
        Dim ObjEditarMateriales As New Datos.CatalogoMaterialesMercadotecniaDA
        ObjEditarMateriales.editarMateriales(Materiales)
    End Sub





End Class
