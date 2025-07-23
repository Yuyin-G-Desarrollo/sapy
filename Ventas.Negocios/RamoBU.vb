Public Class RamoBU

    Public Function ListadoRamos() As DataTable
        Dim objDA As New Datos.RamoDA
        Return objDA.ListadoRamos()
    End Function


    ''' <summary>
    ''' CONECTA CON DATOS PARA RECUPERAR LA LISTA DE RAMOS DE UN CLIENTE EN ESPECIFICO SIEMPRE Y CUANDO ESTEN ACTIVOS Y SU MARCAJE 
    ''' SEA MAYOR A CERO
    ''' </summary>
    ''' <param name="IdCliente">ID DEL CLIENTE DEL CUAL SE RECUPERARAN LOS RAMOS</param>
    ''' <returns>DATATABLE CON LA INFORMACION RECUPERADA</returns>
    ''' <remarks></remarks>
    Public Function ListaRamosPorCliente_con_Marcaje(ByVal IdCliente As Integer)
        Dim objDA As New Datos.RamoDA
        Return objDA.ListaRamosPorCliente_con_Marcaje(IdCliente)
    End Function

    ''' <summary>
    ''' RECUPERA EL MARCAJE DEL RAMO DE UN CLIENTE EN ESPECIFICO
    ''' </summary>
    ''' <param name="IdClienteRamo">ID DEL REGISTRO DE LA TABLA CLIENTERAMO</param>
    ''' <returns>DATATABLE CON LA INFORMACION RECUPERADA</returns>
    ''' <remarks></remarks>
    Public Function recuperarRamoMarcaje(ByVal IdClienteRamo As Integer) As Integer
        Dim objDA As New Datos.RamoDA
        Dim dtMarcaje As New DataTable
        Dim marcaje As Integer
        dtMarcaje = objDA.recuperarRamoMarcaje(IdClienteRamo)

        marcaje = dtMarcaje.Rows(0).Item(0)

        Return marcaje
    End Function

End Class
