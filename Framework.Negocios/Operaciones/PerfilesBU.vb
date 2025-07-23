Imports Framework.Datos

Public Class PerfilesBU
    Public Function listaPerfiles(ByVal nombre As String, ByVal idDepartamento As Int32, ByVal activo As Boolean) As List(Of Entidades.Perfiles)
        Dim objDA As New Datos.PerfilesDA
        Dim tabla As New DataTable
        listaPerfiles = New List(Of Entidades.Perfiles)
        tabla = objDA.listaPerfiles(nombre, idDepartamento, activo)
        For Each fila As DataRow In tabla.Rows
            Dim perfil As New Entidades.Perfiles
            perfil.Pperfilid = CInt(fila("perf_perfilid"))
            perfil.PNombre = CStr(fila("perf_nombre"))
            perfil.PActivo = CBool(fila("perf_activo"))
            perfil.PDepartamento = CInt(fila("perf_grupoid"))
            perfil.PNombreDepartamento = CStr(fila("grup_name"))
            listaPerfiles.Add(perfil)
        Next
    End Function


    Public Sub guardarPerfil(ByVal perfil As Entidades.Perfiles)
        Dim objPerfilesDA As New PerfilesDA
        objPerfilesDA.guardarPerfil(perfil)
    End Sub

    Public Sub editarPerfil(ByVal perfil As Entidades.Perfiles)
        Dim objPerfilesDA As New PerfilesDA
        objPerfilesDA.editarPerfil(perfil)
    End Sub

    Public Function buscarPerfil(ByVal idPerfil As Int32) As Entidades.Perfiles
        Dim objPerfilDA As New Datos.PerfilesDA
        Dim perfil As New Entidades.Perfiles
        Dim tablaPerfil As New DataTable
        tablaPerfil = objPerfilDA.buscarPerfil(idPerfil)

        For Each fila As DataRow In tablaPerfil.Rows
            perfil.Pperfilid = CInt(fila("perf_perfilid"))
            perfil.PNombre = CStr(fila("perf_nombre"))
            perfil.PActivo = CBool(fila("perf_activo"))
            perfil.PDepartamento = CInt(fila("perf_grupoid"))
        Next

        Return perfil
    End Function

    Public Function listaPerfilesActivos() As DataTable
        Dim objDA As New Datos.PerfilesDA
        Return objDA.listaPerfiles("", 0, True)
    End Function

    Public Function listaPerfilesDepartamento(ByVal departamentoId As Integer) As DataTable
        Dim objDA As New Datos.PerfilesDA
        Return objDA.listaPerfiles("", departamentoId, True)
	End Function

	''lista perfiles segun departamento'''
	Public Function ListaPerfilesSegunDepartamentos(ByVal departamentoid As Integer) As List(Of Entidades.Perfiles)
		Dim objDA As New Datos.PerfilesDA
		Dim tabla As New DataTable
		ListaPerfilesSegunDepartamentos = New List(Of Entidades.Perfiles)
		tabla = objDA.ListaPerfilesSegunDepartamento(departamentoid)
		For Each fila As DataRow In tabla.Rows
			Dim perfil As New Entidades.Perfiles
			perfil.PNombre = CStr(fila("perf_nombre"))
			perfil.Pperfilid = CInt(fila("perf_perfilid"))
			ListaPerfilesSegunDepartamentos.Add(perfil)
		Next
    End Function

    Public Function VerPerfiles() As DataTable
        Dim objDA As New Datos.PerfilesDA
        Return objDA.VerPerfiles()
    End Function

    Public Function VerUsuariosPerfil(ByVal idPerfil As String) As DataTable
        Dim objDA As New Datos.PerfilesDA
        Return objDA.VerUsuariosPerfil(idPerfil)
    End Function

    Public Function ValidarPerfilNuevo(ByVal nomPerfil As String) As DataTable
        Dim objDA As New Datos.PerfilesDA
        Return objDA.ValidarPerfilNuevo(nomPerfil)
    End Function

    Public Function verGrupos() As DataTable
        Dim objDA As New Datos.PerfilesDA
        Return objDA.verGrupos()
    End Function

End Class
