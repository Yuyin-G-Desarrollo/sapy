Imports Entidades

Public Class HuellaBU
    Public Function insertarHuella(ByVal colaborador As Int32, ByVal mano As Int32, ByVal dedo As Int32, ByVal usuario As Int32, ByVal huella As String, ByVal dedoLibreria As Int32) As DataTable
        Dim objDatos As New Datos.HuellaDA
        Dim tblColaboradores As New DataTable
        tblColaboradores = objDatos.insertarHuella(colaborador, mano, dedo, usuario, huella, dedoLibreria)
        Return tblColaboradores
    End Function

    Public Function buscarHuella(ByVal colaborador As Int32, ByVal mano As String, ByVal dedo As String) As DataTable
        Dim objDatos As New Datos.HuellaDA
        Dim tblColaboradores As New DataTable
        tblColaboradores = objDatos.buscarHuella(colaborador, mano, dedo)
        Return tblColaboradores
    End Function

    Public Function BitacoraHuella(ByVal colaborador As Int32) As DataTable
        Dim objDatos As New Datos.HuellaDA
        Dim tblColaboradores As New DataTable
        tblColaboradores = objDatos.BitacoraHuella(colaborador)
        Return tblColaboradores
    End Function

    Public Function empleadosNaves() As List(Of Entidades.ColaboradorFirmaBiometrica)
        Dim objDatos As New Datos.HuellaDA
        Dim tblColaboradores As New DataTable
        empleadosNaves = New List(Of Entidades.ColaboradorFirmaBiometrica)
        tblColaboradores = objDatos.listaEmpleados()
        For Each row As DataRow In tblColaboradores.Rows
            Dim colaborador As New Entidades.ColaboradorFirmaBiometrica

            colaborador.PcolaboradorId = CInt(row("codr_colaboradorid").ToString)
            colaborador.Pmano = CInt(row("fibi_mano").ToString)
            colaborador.Pdedo = CInt(row("fibi_dedoLibreria").ToString)
            colaborador.Phuella = row("fibi_huella").ToString
            empleadosNaves.Add(colaborador)
        Next
        Return empleadosNaves
    End Function

End Class
