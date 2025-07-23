Public Class ConveniosBU

    ''' <summary>
    ''' ENVIA VARIABLES A LA CAPA DE DATOS PARA LA CONSULTA DE LA LISTA DE CONVENIOS
    ''' </summary>
    ''' <returns>LISTA DE CONVENIOS</returns>
    ''' <remarks></remarks>
    Public Function listaConvenios(ByVal IdPersona As Integer) As DataTable
        Dim objDA As New Datos.ConveniosDA
        Return objDA.ListaConvenios(IdPersona)
    End Function


    ''' <summary>
    ''' ENVIA VALORES A LA CAPA DE DATOS PARA GUARDAR EL REGISTRO DE CONVENIOS
    ''' </summary>
    ''' <param name="Convenios">CLASE DE LA CAPA ENTIDADES "CONVENIOS" CON LOS VALORES A AGREGAR</param>
    ''' <remarks></remarks>
    Public Sub GuardarConvenio(ByVal Convenios As Entidades.Convenios)
        Dim objConvenioDA As New Datos.ConveniosDA
        objConvenioDA.AgregarConvenios(Convenios)
    End Sub


    Public Sub ActualizarConvenios(ByVal convenios As Entidades.Convenios)
        Dim objActualizarConveniosBu As New Datos.ConveniosDA
        objActualizarConveniosBu.Actualizarconvenios(convenios)
    End Sub

End Class
