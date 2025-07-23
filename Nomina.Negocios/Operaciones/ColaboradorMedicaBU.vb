Imports Nomina.Datos

Public Class ColaboradorMedicaBU

    Public Sub AgregarINFMedica(ByVal salud As Entidades.ColaboradorMedica)
        Dim objDA As New Datos.ColaboradorMedicaDA
        objDA.InsertarInformacionMedica(salud)
    End Sub

    Public Sub EditarINFMedica(ByVal salud As Entidades.ColaboradorMedica, ByVal colaboradorId As Int32)
        Dim objDA As New Datos.ColaboradorMedicaDA
        objDA.EditarInformacionMedica(salud, colaboradorId)
    End Sub


    Public Function buscarColaborarMedica(ByVal colaboradorid As Int32) As Entidades.ColaboradorMedica
        Dim objColaboradorMedica As New ColaboradorMedicaDA

        Dim colaborador As New Entidades.ColaboradorMedica
        Dim tablaColaboradorMedica As New DataTable

        tablaColaboradorMedica = objColaboradorMedica.BuscarInformacionMedica(colaboradorid)

        For Each row As DataRow In tablaColaboradorMedica.Rows
            colaborador.PTipoSanguineo = CStr(row("clsa_tiposanguineo"))
            colaborador.PTelefonoEmergencias = CStr(row("clsa_telefonoemergencias"))
            colaborador.PContactoEmergencias = CStr(row("clsa_contactoemergencias"))
            colaborador.PComentarios = CStr(row("clsa_comentarios"))

        Next


        Return colaborador
    End Function

    Public Function ValidarUpdateOrInsertMedica(ByVal Colaboradorid As Int32) As Int32
        Dim obj As New ColaboradorMedicaDA
        Dim tabla As New DataTable
        tabla = obj.BuscarInformacionMedica(Colaboradorid)
        Dim CountMedica As Int32
        CountMedica = tabla.Rows.Count
        Return CountMedica
    End Function


End Class
