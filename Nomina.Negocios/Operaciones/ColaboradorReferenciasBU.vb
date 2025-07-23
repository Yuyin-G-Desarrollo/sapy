Public Class ColaboradorReferenciasBU
    Public Sub AgregarColaboradorReferenciaId(ByVal referencia As Entidades.ColaboradorReferencias)
        Dim objDA As New Datos.ColaboradorReferenciasDA
        objDA.AgregarColaboradorReferencias(referencia)
    End Sub


    Public Sub EditarColaboradorReferenciaId(ByVal idReferencia As Int32, ByVal referencia As Entidades.ColaboradorReferencias)
        Dim objDA As New Datos.ColaboradorReferenciasDA
        objDA.EditarColaboradorReferencias(idReferencia, referencia)
    End Sub

    Public Sub EliminarColaboradorReferenciaId(ByVal referenciaId As Int32)
        Dim objDA As New Datos.ColaboradorReferenciasDA
        objDA.EliminarColaboradorReferencia(referenciaId)
    End Sub

    Public Function ListaColaboradorReferencias(ByVal colaboradorId As Int32) As List(Of Entidades.ColaboradorReferencias)
        Dim objDA As New Datos.ColaboradorReferenciasDA
        Dim tableReferencias As New DataTable
        ListaColaboradorReferencias = New List(Of Entidades.ColaboradorReferencias)
        tableReferencias = objDA.listaColaboradorReferencias(colaboradorId)
        For Each row As DataRow In tableReferencias.Rows
            Dim objReferencia As New Entidades.ColaboradorReferencias
            Dim colaborador As New Entidades.Colaborador
            colaborador.PColaboradorid = CInt(row("cref_colaboradorid"))
            objReferencia.PColaboradorId = colaborador
            objReferencia.PNombre = CStr(row("cref_nombre"))
            objReferencia.POcupacion = CStr(row("cref_ocupacion"))
            objReferencia.PParentezco = CStr(row("cref_parentezco"))
            objReferencia.PTelefono = CStr(row("cref_telefono"))
            objReferencia.PColaboradorReferenciaId = CInt(row("cref_colaboradorreferenciaid"))
            'comentado la fecha de nacimiento ya no se muestra
            'objReferencia.PFechaNacimiento = CDate(row("cref_fechanacimiento"))
            ListaColaboradorReferencias.Add(objReferencia)
        Next
    End Function
End Class
