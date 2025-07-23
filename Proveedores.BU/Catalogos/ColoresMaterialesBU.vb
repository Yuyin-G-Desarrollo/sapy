Imports Proveedores.DA

Public Class ColoresMaterialesBU
    Public Function getColoresMateriales(ByVal id As Integer) As DataTable
        Dim obj As New ColoresMaterialesDa
        Return obj.getColoresMateriales(id)
    End Function
    Public Function updateColoresMateriales(ByVal idColor As Integer, ByVal color As String, ByVal sku As String, ByVal status As Integer) As DataTable
        Dim obj As New ColoresMaterialesDa      
        Return obj.updateColoresMateriales(idColor, color, sku, status)
    End Function
    Public Function insertColoresMateriales(ByVal color As String, ByVal sku As String) As DataTable
        Dim obj As New ColoresMaterialesDa      
        Return obj.insertColoresMateriales(color, sku)
    End Function

    Function activarColores(ByVal idclas As Integer, ByVal idcol As Integer) As DataTable
        Dim obj As New ClasificacionesMaterialesDA
        Return obj.activarColores(idclas, idcol)
    End Function

    Function desactivarColores(ByVal idclas As Integer) As DataTable
        Dim obj As New ClasificacionesMaterialesDA
        Return obj.desactivarColores(idclas)
    End Function

    Function desactivarTamano(ByVal idclas As Integer) As DataTable
        Dim obj As New ClasificacionesMaterialesDA
        Return obj.desactivarTamano(idclas)
    End Function

    Function activarTamano(ByVal idclas As Integer, ByVal idtam As Integer) As DataTable
        Dim obj As New ClasificacionesMaterialesDA
        Return obj.activarTamano(idclas, idtam)
    End Function

    Public Sub ActualizarColorClasificacion(ByVal ActualizarColorClasificacion As Entidades.ClasificacionColores)
        Dim obj As New ColoresMaterialesDa
        obj.ActualizarColorClasificacion(ActualizarColorClasificacion)
    End Sub

    Public Function idColorInsertado() As DataTable
        Dim obj As New ColoresMaterialesDa
        Return obj.idColorInsertado()
    End Function

    Public Function ColoresRepetidos(ByVal color As String) As DataTable
        Dim obj As New ColoresMaterialesDa
        Return obj.ColoresRepetidos(color)
    End Function

    Public Function TamanosRepetidos(ByVal tamano As String) As DataTable
        Dim obj As New ColoresMaterialesDa
        Return obj.TamanosRepetidos(tamano)
    End Function

    Public Sub insertColoresMaterialesClasificacion(ByVal AltaCategoriaClasificacion As Entidades.ClasificacionColores)
        Dim OBJDA As New ColoresMaterialesDa
        OBJDA.insertColoresMaterialesClasificacion(AltaCategoriaClasificacion)
    End Sub

    Public Function Clasificaciones()
        Dim OBJDA As New ClasificacionesMaterialesDA
        Return OBJDA.Clasificaciones()
    End Function

    Public Function ListaColores()
        Dim OBJDA As New ClasificacionesMaterialesDA
        Return OBJDA.ListaColores()
    End Function

    Public Function ListaTamanos()
        Dim OBJDA As New ClasificacionesMaterialesDA
        Return OBJDA.ListaTamanos()
    End Function

    'Public Function insertarColorClas(ByVal AltaCategoriaClasificacion As Entidades.ClasificacionColores)
    '    Dim OBJDA As New ClasificacionesMaterialesDA
    '    Return OBJDA.insertarClasificacionColores(AltaCategoriaClasificacion)
    'End Function

    Public Sub ActualizarColoresClasificacion(ByVal estatus As Integer, ByVal idclas As Integer, ByVal usumod As Integer,
                                             ByVal clasificacioncol As Integer, ByVal fecha As Date, ByVal idcolor As Integer)
        Dim obj As New ColoresMaterialesDa
        obj.ActualizarColorClasificaciones(estatus, idclas, usumod, clasificacioncol, fecha, idcolor)
    End Sub



    'Public Sub insertarClasificacionTamano(ByVal AltaClasificacionTamano As Entidades.ClasificacionTamanovb)
    '    Dim OBJDA As New DA.ClasificacionesMaterialesDA
    '    OBJDA.insertarClasificacionTamano(AltaClasificacionTamano)
    'End Sub

End Class
