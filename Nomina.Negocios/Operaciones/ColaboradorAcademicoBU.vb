Imports Nomina.Datos


Public Class ColaboradorAcademicoBU

    Public Sub AgregarInformacionAcademica(ByVal Academica As Entidades.AcademicosColaborador, ByVal ColaboradorId As Int32)
        Dim objDA As New ColaboradorAcademicoDA
        objDA.AgregarInformacionAcademica(Academica, ColaboradorId)

    End Sub

    Public Sub EditarInformacionAcademica(ByVal Academica As Entidades.AcademicosColaborador, ByVal IdAcademica As Int32)
        Dim objDA As New ColaboradorAcademicoDA
        objDA.EditarInformacionAcademica(Academica, IdAcademica)

    End Sub

    Public Sub EliminarInformacionAcademica(ByVal aca As Int32)
        Dim objDA As New ColaboradorAcademicoDA
        objDA.EliminarInformacionAcademica(aca)
    End Sub



    Public Function ListaColaboradorAcademica(ByVal colaboradorId As Int32) As List(Of Entidades.AcademicosColaborador)
        Dim objDA As New Datos.ColaboradorAcademicoDA
        Dim tableAcademicas As New DataTable
        ListaColaboradorAcademica = New List(Of Entidades.AcademicosColaborador)
        tableAcademicas = objDA.listaColaboradorAcademica(colaboradorId)
        For Each row As DataRow In tableAcademicas.Rows
            Dim objAcademicas As New Entidades.AcademicosColaborador
            Dim colaborador As New Entidades.Colaborador

            colaborador.PColaboradorid = CInt(row("coac_colaboradorid"))
            objAcademicas.PColaboradorId = colaborador
            objAcademicas.PNombreEscuela = CStr(row("coac_escuela"))
            objAcademicas.PAnioInicio = CInt(row("coac_inicio"))
            Try
                objAcademicas.PAnioTermino = CInt(row("coac_fin"))
            Catch ex As Exception

            End Try

            objAcademicas.PEstado = CStr(row("coac_estado"))
            objAcademicas.PCarrera = CStr(row("coac_carrera"))
            objAcademicas.PAcademicaId = CInt(row("coac_academicaid"))
            Try
                objAcademicas.PGrado = CStr(row("coac_grado"))
            Catch
                objAcademicas.PGrado = ""
            End Try
            ListaColaboradorAcademica.Add(objAcademicas)
        Next
    End Function



End Class
