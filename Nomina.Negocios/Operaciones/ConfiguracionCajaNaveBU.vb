Public Class ConfiguracionCajaNaveBU

    Private pResultado As String = String.Empty

    Public Property Resultado As String
        Get
            Return pResultado
        End Get
        Set(value As String)
            pResultado = value
        End Set
    End Property


    Public Sub AltaConfiguracionCajaNave(objConfiguracionCajaNave As Entidades.ConfiguracionCajaNave)

        Dim objConfiguracionCajaNaveDA As New Nomina.Datos.ConfiguracionCajaNaveDA
        objConfiguracionCajaNaveDA.Altas(objConfiguracionCajaNave)

    End Sub

    Public Sub EditarConfiguracionCajaNave(objConfiguracionCajaNave As Entidades.ConfiguracionCajaNave)

        Dim objConfiguracionCajaNaveDA As New Nomina.Datos.ConfiguracionCajaNaveDA
        objConfiguracionCajaNaveDA.Editar(objConfiguracionCajaNave)

    End Sub


    Public Sub EliminarConfiguracionCajaNave(objConfiguracionCajaNave As Entidades.ConfiguracionCajaNave)
        Dim objConfiguracionCajaNaveDA As New Nomina.Datos.ConfiguracionCajaNaveDA
        objConfiguracionCajaNaveDA.Eliminar(objConfiguracionCajaNave)
    End Sub

    Public Function ObtenerConfiguracionCajaNave(ByVal IdConfiguracionCajaNave As Int32) As Entidades.ConfiguracionCajaNave

        Dim objConfiguracionCajaNaveDA As New Nomina.Datos.ConfiguracionCajaNaveDA
        Dim objConfiguracionCajaNave As New Entidades.ConfiguracionCajaNave
        Dim tblConfiguracionCajaNave As DataTable

        tblConfiguracionCajaNave = objConfiguracionCajaNaveDA.ObtenerConfiguracionCajaNave(IdConfiguracionCajaNave)

        If tblConfiguracionCajaNave.Rows.Count > 0 Then

            Dim objCajaAhorro As New Entidades.CajaAhorro
            Dim objCajaAhorroBU As New Nomina.Negocios.CajaAhorroBU
            objCajaAhorro = objCajaAhorroBU.ObtenerCajaAhorro(tblConfiguracionCajaNave.Rows(0)("cocn_CajaAhorroId"))

            objConfiguracionCajaNave.pCajaAhorro = objCajaAhorro
            objConfiguracionCajaNave.pccnId = tblConfiguracionCajaNave.Rows(0)("cocn_ccnId")
            objConfiguracionCajaNave.pSemanaFinal = tblConfiguracionCajaNave.Rows(0)("cocn_SemanaInicial")
            objConfiguracionCajaNave.pSemanaInicial = tblConfiguracionCajaNave.Rows(0)("cocn_SemanaFinal")
            objConfiguracionCajaNave.pInteres = tblConfiguracionCajaNave.Rows(0)("cocn_Interes")

        End If

        Return objConfiguracionCajaNave

    End Function


    Public Function Listar(idCajaAhorro As Int32) As List(Of Entidades.ConfiguracionCajaNave)

        Listar = New List(Of Entidades.ConfiguracionCajaNave)
        Dim objConfiguracionCajaNaveDA As New Nomina.Datos.ConfiguracionCajaNaveDA
        Dim tablaConfiguracionCajaNave As New DataTable

        tablaConfiguracionCajaNave = objConfiguracionCajaNaveDA.Listar(idCajaAhorro)


        For Each renglon As DataRow In tablaConfiguracionCajaNave.Rows
            Dim objConfiguracionCajaNave As New Entidades.ConfiguracionCajaNave
            Dim objCajaAhorro As New Entidades.CajaAhorro
            Dim objCajaAhorroBU As New Nomina.Negocios.CajaAhorroBU

            objCajaAhorro = objCajaAhorroBU.ObtenerCajaAhorro(renglon("cocn_CajaAhorroId"))

            objConfiguracionCajaNave.pccnId = renglon("cocn_ccnId")
            objConfiguracionCajaNave.pCajaAhorro = objCajaAhorro
            objConfiguracionCajaNave.pSemanaInicial = renglon("cocn_SemanaInicial")
            objConfiguracionCajaNave.pSemanaFinal = renglon("cocn_SemanaFinal")
            objConfiguracionCajaNave.pInteres = renglon("cocn_Interes")

            Listar.Add(objConfiguracionCajaNave)
        Next

        Return Listar


    End Function



    Public Function ListarConfiguracionAnterior(idCajaAhorro As Int32) As List(Of Entidades.ConfiguracionCajaNave)

        ListarConfiguracionAnterior = New List(Of Entidades.ConfiguracionCajaNave)


        Dim objConfiguracionCajaNaveDA As New Nomina.Datos.ConfiguracionCajaNaveDA

        Dim tablaConfiguracionCajaNave As New DataTable

        tablaConfiguracionCajaNave = objConfiguracionCajaNaveDA.ListarConfiguracionAnterior(idCajaAhorro)


        For Each renglon As DataRow In tablaConfiguracionCajaNave.Rows
            Dim objConfiguracionCajaNave As New Entidades.ConfiguracionCajaNave
            Dim objCajaAhorro As New Entidades.CajaAhorro
            Dim objCajaAhorroBU As New Nomina.Negocios.CajaAhorroBU

            objCajaAhorro = objCajaAhorroBU.ObtenerCajaAhorro(renglon("cocn_CajaAhorroId"))

            objConfiguracionCajaNave.pccnId = renglon("cocn_ccnId")
            objConfiguracionCajaNave.pCajaAhorro = objCajaAhorro
            objConfiguracionCajaNave.pSemanaInicial = renglon("cocn_SemanaInicial")
            objConfiguracionCajaNave.pSemanaFinal = renglon("cocn_SemanaFinal")
            objConfiguracionCajaNave.pInteres = renglon("cocn_Interes")

            ListarConfiguracionAnterior.Add(objConfiguracionCajaNave)
        Next

        Return ListarConfiguracionAnterior


    End Function


End Class
