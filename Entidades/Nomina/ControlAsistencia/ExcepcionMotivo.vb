Public Class ExcepcionMotivo

    Private exmot_id As Integer
    Private exmot_nombre As String
    Private exmot_puntualidad_asistencia As Boolean
    Private exmot_caja_ahorro As Boolean
    Private exmot_nave As Naves
    Private exmot_motivo_laboral As Boolean

    Public Property Pexmot_id() As Integer
        Get
            Return exmot_id
        End Get
        Set(ByVal value As Integer)
            exmot_id = value
        End Set
    End Property

    Public Property Pexmot_nombre() As String
        Get
            Return exmot_nombre
        End Get
        Set(ByVal value As String)
            exmot_nombre = value
        End Set
    End Property

    Public Property Pexmot_puntualidad_asistencia() As Boolean
        Get
            Return exmot_puntualidad_asistencia
        End Get
        Set(ByVal value As Boolean)
            exmot_puntualidad_asistencia = value
        End Set
    End Property

    Public Property Pexmot_caja_ahorro() As Boolean
        Get
            Return exmot_caja_ahorro
        End Get
        Set(ByVal value As Boolean)
            exmot_caja_ahorro = value
        End Set
    End Property

    Public Property Pexmot_nave() As Naves
        Get
            Return exmot_nave
        End Get
        Set(ByVal value As Naves)
            exmot_nave = value
        End Set
    End Property

    Public Property Pexmot_motivo_laboral() As Boolean
        Get
            Return exmot_motivo_laboral
        End Get
        Set(ByVal value As Boolean)
            exmot_motivo_laboral = value
        End Set
    End Property

End Class
