Imports System.Data.SqlClient
Public Class ColaboradorMedicaDA

    Public Sub InsertarInformacionMedica(ByVal Salud As Entidades.ColaboradorMedica)
        Dim operecion As New Persistencia.OperacionesProcedimientos
        Dim listaparametro As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "clsa_colaboradorid"
        parametro.Value = Salud.PColaboradorID.PColaboradorid
        listaparametro.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "clsa_tiposanguineo"
        parametro.Value = Salud.PTipoSanguineo
        listaparametro.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "clsa_telefonoemergencias"
        parametro.Value = Salud.PTelefonoEmergencias
        listaparametro.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "clsa_contactoemergencias"
        parametro.Value = Salud.PContactoEmergencias
        listaparametro.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "clsa_comentarios"
        parametro.Value = Salud.PComentarios
        listaparametro.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "clsa_usuariocreoid"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaparametro.Add(parametro)

        operecion.EjecutarConsultaSP("Nomina.SP_AgregarINF_Medica", listaparametro)

    End Sub

End Class
