Public Class FamiliaProyeccion

    Private idFamiliaProyeccion As Int32
    Public Property PidFamiliaProyeccion As Int32
        Get
            Return idFamiliaProyeccion
        End Get
        Set(ByVal value As Int32)
            idFamiliaProyeccion = value
        End Set
    End Property

    Private familiaProyeccionDescripcion As String
    Public Property PFamiliaProyeccionDescripcion As String
        Get
            Return familiaProyeccionDescripcion
        End Get
        Set(ByVal value As String)
            familiaProyeccionDescripcion = value
        End Set
    End Property

    Private fampProyActivo As Boolean
    Public Property PFampProyActivo As Boolean
        Get
            Return fampProyActivo
        End Get
        Set(ByVal value As Boolean)
            fampProyActivo = value
        End Set
    End Property



End Class
