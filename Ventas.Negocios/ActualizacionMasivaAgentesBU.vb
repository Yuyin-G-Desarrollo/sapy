Public Class ActualizacionMasivaAgentesBU

    Public Function verCoordinadores() As DataTable
        Dim objverAgentesVentaComisionDA As New Datos.ActualizacionMasivaAgentesDA
        Return objverAgentesVentaComisionDA.verCoordinadores
    End Function

    Public Function verAgentesVentaComision() As DataTable
        Dim objverAgentesVentaComisionDA As New Datos.ActualizacionMasivaAgentesDA
        Return objverAgentesVentaComisionDA.verAgentesVentaComision
    End Function

    Public Function verRutas() As DataTable
        Dim objverRutasDA As New Datos.ActualizacionMasivaAgentesDA
        Return objverRutasDA.verRutas
    End Function

    Public Function verMarcas() As DataTable
        Dim objverMarcasDA As New Datos.ActualizacionMasivaAgentesDA
        Return objverMarcasDA.verMarcas
    End Function

    Public Function verFamiliaVentas() As DataTable
        Dim objverFamiliasVentaDA As New Datos.ActualizacionMasivaAgentesDA
        Return objverFamiliasVentaDA.verFamiliaVentas
    End Function

    Public Function verAgentesAsignados() As DataTable
        Dim objverAgentesAsignadosDA As New Datos.ActualizacionMasivaAgentesDA
        Return objverAgentesAsignadosDA.verAgentesAsignados
    End Function

    Public Function verListaPrincipal(idRuta As ArrayList, idMarca As ArrayList, idFamiliaVentas As ArrayList, idAgenteAsignado As ArrayList, agente As String) As DataTable
        Dim objverListaPrincipalDA As New Datos.ActualizacionMasivaAgentesDA
        Return objverListaPrincipalDA.verListaPrincipal(idRuta, idMarca, idFamiliaVentas, idAgenteAsignado, agente)
    End Function

    Public Sub actualizaAgenteVentas(idAgenteVentasSAY As Integer, idClienteSAY As Integer, idClientSICY As Integer, idMarcaSAY As Integer, idFamiliaSAY As Integer, usuarioModifica As String, usuarioModificaNombre As String, idCoord As Integer)
        Dim objactualizaAgenteVentas As New Datos.ActualizacionMasivaAgentesDA
        objactualizaAgenteVentas.actualizaAgenteVentas(idAgenteVentasSAY, idClienteSAY, idClientSICY, idMarcaSAY, idFamiliaSAY, usuarioModifica, usuarioModificaNombre, idCoord)
    End Sub

    Public Sub actualizaAgenteComision(idMarcaSAY As Integer, idClienteSAY As Integer, idClienteSICY As Integer, idAgenteComisionSAY As Integer, usuarioModifica As Integer, usuarioModificaNombre As String, idAgenteVentas As Integer)
        Dim objactualizaAgenteComision As New Datos.ActualizacionMasivaAgentesDA
        objactualizaAgenteComision.actualizaAgenteComision(idMarcaSAY, idClienteSAY, idClienteSICY, idAgenteComisionSAY, usuarioModifica, usuarioModificaNombre, idAgenteVentas)
    End Sub

    Public Sub replicacionesClienteMarcaFamiliaProyeccionAgente_ClienteMarcaAgenteEmpresa_SAY_SICY(nombreUsuario As String)
        Dim objreplicacionesCMFPA_CLMAE_SAY_SICY As New Datos.ActualizacionMasivaAgentesDA
        objreplicacionesCMFPA_CLMAE_SAY_SICY.replicacionesClienteMarcaFamiliaProyeccionAgente_ClienteMarcaAgenteEmpresa_SAY_SICY(nombreUsuario)
    End Sub


    Public Sub actualizaProspecta()
        Dim objActualizaProspecta As New Datos.ActualizacionMasivaAgentesDA
        objActualizaProspecta.actualizaProspecta()
    End Sub

    Public Sub quitaAgenteComision(idUsuario As Integer, nombreUsuario As String, idClienteSAY As Integer, idMarcaSAY As Integer, idAgenteSAY As Integer)
        Dim objActualizaProspecta As New Datos.ActualizacionMasivaAgentesDA
        objActualizaProspecta.quitaAgenteComision(idUsuario, nombreUsuario, idClienteSAY, idMarcaSAY, idAgenteSAY)
    End Sub

    Public Sub ActualizaColeccionMarcaFamiliaCadenaAgente(ByVal cadenasIds As String)
        Dim objDA As New Datos.ActualizacionMasivaAgentesDA
        objDA.ActualizaColeccionMarcaFamiliaCadenaAgente(cadenasIds)
    End Sub

    Public Sub ActualizarAgentesProyeccionMarcaFamiliaCliente()
        Dim objDA As New Datos.ActualizacionMasivaAgentesDA
        objDA.ActualizarAgentesProyeccionMarcaFamiliaCliente()
    End Sub

End Class
