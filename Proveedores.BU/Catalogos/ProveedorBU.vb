Imports Entidades

Public Class ProveedorBU

    Public Function BuscarRazonSocialNoFiscal(ByVal RazonSocial As String, ByVal ProveedorID As Integer) As DataTable
        Dim OBJDA As New DA.ProveedorDA
        Return OBJDA.BuscarRazonSocialNoFiscal(RazonSocial, ProveedorID)
    End Function

    Public Function BuscarRazonSocial(ByVal RazonSocial As String, ByVal ProveedorID As Integer) As DataTable
        Dim OBJDA As New DA.ProveedorDA
        Return OBJDA.BuscarRazonSocial(RazonSocial, ProveedorID)
    End Function

    Public Function ActualizarPaisNombreComercial(ByVal Dage_ProveedorID As Integer, ByVal Pais As String) As DataTable
        Dim OBJDA As New DA.ProveedorDA
        Return OBJDA.ActualizarPaisNombreComercial(Dage_ProveedorID, Pais)
    End Function

    Public Function BuscarNaveNombreComercial(ByVal NaveID As Integer, ByVal Dage_ProveedorID As Integer) As DataTable
        Dim OBJDA As New DA.ProveedorDA
        Return OBJDA.BuscarNaveNombreComercial(NaveID, Dage_ProveedorID)
    End Function

    Public Function ConsultaGiroClasificacion(ByVal ClasificacionId As Integer) As DataTable
        Dim OBJDA As New DA.ProveedorDA
        Return OBJDA.ConsultaGiroClasificacion(ClasificacionId)
    End Function

    Public Function EditarInformacionProveedor2(ByVal Proveedores As Entidades.DatosProveedor) As DataTable
        Dim OBJDA As New DA.ProveedorDA
        Return OBJDA.EditarInformacionProveedor2(Proveedores)
    End Function

    Public Function ConsultarProveedoresPorNombreComercial(ByVal dage_proveedorid As Integer) As DataTable
        Dim OBJDA As New DA.ProveedorDA
        Return OBJDA.ConsultarProveedoresPorNombreComercial(dage_proveedorid)
    End Function

    Public Function ConsultarContactosProveedor(ByVal ProveedorID As Integer, ByVal Activo As Boolean) As DataTable
        Dim OBJDA As New DA.ProveedorDA
        Return OBJDA.ConsultarContactosProveedor(ProveedorID, Activo)
    End Function

    Public Function InsertarRelacionNaveNombreComercial(ByVal NombreComercialID As Integer, ByVal NaveID As Integer, ByVal UsuarioCreoID As Integer) As DataTable
        Dim OBJDA As New DA.ProveedorDA
        Return OBJDA.InsertarRelacionNaveNombreComercial(NombreComercialID, NaveID, UsuarioCreoID)
    End Function

    Public Function AltaNombreComercial(ByVal NombreComercial As String, ByVal PaginaWeb As String, ByVal UsuarioCreoID As Integer, ByVal Pais As String, ByVal PaisId As Integer) As DataTable
        Dim OBJDA As New DA.ProveedorDA
        Return OBJDA.AltaNombreComercial(NombreComercial, PaginaWeb, UsuarioCreoID, Pais, PaisId)
    End Function

    Public Function BuscarExisteRFC(ByVal RFC As String) As DataTable
        Dim OBJDA As New DA.ProveedorDA
        Return OBJDA.BuscarExisteRFC(RFC)
    End Function

    Public Function ConsultaClasificacionGiroProveedor(ByVal ClasificacionGiroID As Integer) As DataTable
        Dim OBJDA As New DA.ProveedorDA
        Return OBJDA.ConsultaClasificacionGiroProveedor(ClasificacionGiroID)
    End Function

    Public Function ConsultarPlazosPagoProveedor(ByVal ProveedorId As Integer) As DataTable
        Dim OBJDA As New DA.ProveedorDA
        Return OBJDA.ConsultarPlazosPagoProveedor(ProveedorId)
    End Function

    Public Function ConsultaInformacionProveedor(ByVal ProveedorID As Integer) As Entidades.DatosProveedor
        Dim OBJDA As New DA.ProveedorDA
        Return OBJDA.ConsultaInformacionProveedor(ProveedorID)
    End Function

    Public Function ObtenerGiro(ByVal CategoriaID As Integer, ByVal GiroId As Integer) As DataTable
        Dim OBJDA As New DA.ProveedorDA
        Return OBJDA.ObtenerGiro(CategoriaID, GiroId)
    End Function

    Public Function BuscarRFC(ByVal RFC As String) As DataTable
        Dim OBJDA As New DA.ProveedorDA
        Return OBJDA.BuscarRFC(RFC)
    End Function
    Public Function ConsultarProveedorSicy(ByVal ProveedorID As Integer) As DataTable
        Dim OBJDA As New DA.ProveedorDA
        Return OBJDA.ConsultarProveedorSicy(ProveedorID)
    End Function

    Public Function ConsultaClasificaciones(ByVal Activo As Boolean) As DataTable
        Dim OBJDA As New DA.ProveedorDA
        Return OBJDA.ConsultaClasificaciones(Activo)
    End Function

    Public Function ConsultaTiposRazonSocial() As DataTable
        Dim OBJDA As New DA.ProveedorDA
        Return OBJDA.ConsultaTiposRazonSocial()
    End Function

    Public Function ConsultaNombresComerciales() As DataTable
        Dim OBJDA As New DA.ProveedorDA
        Return OBJDA.ConsultaNombresComerciales()
    End Function

    Public Function ConsultaInformacionProveedores(ByVal NaveID As Integer, ByVal Activo As Boolean) As DataTable
        Dim OBJDA As New DA.ProveedorDA
        Return OBJDA.ConsultaInformacionProveedores(NaveID, Activo)
    End Function

    Public Sub AltaProveedorDatosGenerales(ByVal Proveedor As Entidades.DatosGenerales)
        Dim OBJDA As New DA.ProveedorDA
        OBJDA.AltaDatosGenerales(Proveedor)
    End Sub

    Public Sub AltaProveedorDatosGeneralesSICY(ByVal Proveedor As Entidades.DatosGeneralesSICY)
        Dim OBJDA As New DA.ProveedorDA
        OBJDA.AltaDatosGeneralesSICY(Proveedor)
    End Sub

    Public Sub ModificaDatosGeneralesSICY(ByVal Proveedor As Entidades.DatosGeneralesSICY)
        Dim OBJDA As New DA.ProveedorDA
        OBJDA.ModificaDatosGeneralesSICY(Proveedor)
    End Sub

    Public Sub AltaRFCSICY(ByVal Proveedor As Entidades.DatosProveedorSICY)
        Dim OBJDA As New DA.ProveedorDA
        OBJDA.AltaRFCSICY(Proveedor)
    End Sub

    Public Sub AltaContactoCobranzaSICY(ByVal Proveedor As Entidades.DatosContactoSICY)
        Dim OBJDA As New DA.ProveedorDA
        OBJDA.AltaContactoCobranzaSICY(Proveedor)
    End Sub

    Public Sub AltaContactoVentasSICY(ByVal Proveedor As Entidades.DatosContactoSICY)
        Dim OBJDA As New DA.ProveedorDA
        OBJDA.AltaContactoVentasSICY(Proveedor)
    End Sub

    Public Sub AltaPlazoSICY(ByVal Proveedor As Entidades.PlazoProveedoresSICY)
        Dim OBJDA As New DA.ProveedorDA
        OBJDA.AltaPlazoSICY(Proveedor)
    End Sub

    Public Sub AltaBancoSICY(ByVal Proveedor As Entidades.DatosDeCuentaBancariaSICY)
        Dim OBJDA As New DA.ProveedorDA
        OBJDA.AltaBancoSICY(Proveedor)
    End Sub

    Public Sub AltaCobradorSICY(ByVal Proveedor As Entidades.DatosCobradorSICY)
        Dim OBJDA As New DA.ProveedorDA
        OBJDA.AltaCobradorSICY(Proveedor)
    End Sub

    '*********************************************
    Public Function AsignarNave(ByVal Proveedor As Entidades.NaveProveedor)
        Dim objDA As New DA.ProveedorDA
        objDA.AsignarNaveProveedor(Proveedor)
    End Function


    Public Sub AltaProveedorDatosContacto(ByVal Proveedor As Entidades.DatosContacto)
        Dim OBJDA As New DA.ProveedorDA
        OBJDA.AltaDatosContacto(Proveedor)
    End Sub

    Public Sub AltaGiro(ByVal Proveedor As Entidades.Giro)
        Dim OBJDA As New DA.ProveedorDA
        OBJDA.AltaGiro(Proveedor)
    End Sub

    Public Sub BorrarGiro(ByVal idgiro As Integer)
        Dim objda As New DA.ProveedorDA
        objda.EliminarGiro(idgiro)
    End Sub

    Public Function BuscaGiroRepetidoNoActivo(ByVal giro As String) As DataTable
        Dim objda As New DA.ProveedorDA
        Return objda.BuscaGiroRepetidoNoActivo(giro)
    End Function

    Public Sub ActivarGiro(ByVal giro As String)
        Dim objda As New DA.ProveedorDA
        objda.ActivarGiro(giro)
    End Sub

    Public Sub EditarProveedorDatosContacto(ByVal datoscontactoid As Entidades.DatosContacto)
        Dim objda As New DA.ProveedorDA
        objda.ModificacionContacto(datoscontactoid)
    End Sub
    '*******************************
    Public Sub EditarDatosGenerales(ByVal proveedor As Entidades.DatosGenerales)
        Dim objda As New DA.ProveedorDA
        objda.ModificarDatosGenerales(proveedor)
    End Sub
    '******************************

    Public Sub DesactivarContacto(ByVal Proveedor As Entidades.DatosGenerales)
        Dim objda As New DA.ProveedorDA
        objda.DesactivarContacto(Proveedor)
    End Sub

    Public Sub ActivarContacto(ByVal Proveedor As Entidades.DatosGenerales)
        Dim objda As New DA.ProveedorDA
        objda.ActivarContacto(Proveedor)
    End Sub

    Public Function BuscarProveedorSicy(ByVal razonSocial As String) As DataTable
        Dim OBJDA As New DA.ProveedorDA
        Dim tabla As New DataTable
        tabla = OBJDA.BuscarProveedorSicy(razonSocial)
        Return tabla
    End Function

    Public Sub ActivarContactoProveedor(ByVal Proveedor As Entidades.DatosContacto)
        Dim objda As New DA.ProveedorDA
        objda.ActivarContactoProveedor(Proveedor)
    End Sub

    Public Sub ActivaDesactivaUsuarioProveedor(ByVal Proveedor As Entidades.UsuarioProveedor)
        Dim objda As New DA.ProveedorDA
        objda.ActivaDesactivaUsuarioProveedor(Proveedor)
    End Sub

    Public Sub DesactivarContactoProveedor(ByVal Proveedor As Entidades.DatosContacto)
        Dim objda As New DA.ProveedorDA
        objda.DesactivarContactoProveedor(Proveedor)
    End Sub

    Public Function AltaProveedorDatos(ByVal Proveedor As Entidades.DatosProveedor) As DataTable
        Dim OBJDA As New DA.ProveedorDA
        Return OBJDA.AltaDatosDeProveedor(Proveedor)
    End Function

    Public Sub BuscarRfcSicy(ByVal rfc As String)
        Dim OBJDA As New DA.ProveedorDA
        OBJDA.BuscarRfcSicy(rfc)
    End Sub

    Public Sub EditarProveedorDatos(ByVal prov_datosrfcid As Entidades.DatosProveedor)
        Dim objda As New DA.ProveedorDA
        objda.ModificacionDatosDeProveedor(prov_datosrfcid)
    End Sub

    Public Sub AltaProveedorCuentaBancaria(ByVal Proveedor As Entidades.DatosDeCuentaBancaria)
        Dim OBJDA As New DA.ProveedorDA
        OBJDA.AltaDatosDeCuentaBancaria(Proveedor)
    End Sub

    Public Sub EditarProveedorCuentaBancaria(ByVal datosdecuentabancariaid As Entidades.DatosDeCuentaBancaria)
        Dim objda As New DA.ProveedorDA
        objda.ModificacionDatosDeCuentaBancaria(datosdecuentabancariaid)
    End Sub


    Public Sub AltaProveedorUsuario(ByVal Proveedor As Entidades.UsuarioProveedor)
        Dim OBJDA As New DA.ProveedorDA
        OBJDA.AltaUsuarioProveedor(Proveedor)
    End Sub

    Public Sub EditarProveedorUsuario(ByVal usuarioid As Entidades.UsuarioProveedor)
        Dim objda As New DA.ProveedorDA
        objda.ModificacionUsuarioProveedor(usuarioid)
    End Sub

    Public Sub EditarProveedorPlazoPago(ByVal plazopagoid As Entidades.PlazoPago)
        Dim objda As New DA.ProveedorDA
        objda.ModificacionPlazoPago(plazopagoid)
    End Sub

    Public Sub EliminarPlazo(ByVal plazopagoid As Integer)
        Dim objda As New DA.ProveedorDA
        objda.EliminarPlazoPago(plazopagoid)
    End Sub

    Public Sub EliminarNave(ByVal naveid As Integer)
        Dim objda As New DA.ProveedorDA
        objda.EliminarNave(naveid)
    End Sub

    Public Sub AltaProveedorPlazoProveedor(ByVal Proveedor As Entidades.PlazoProveedor)
        Dim OBJDA As New DA.ProveedorDA
        OBJDA.AltaPlazoProveedor(Proveedor)
    End Sub

    Public Sub BajaPlazoProveedor(ByVal Proveedor As Entidades.PlazoProveedor)
        Dim OBJDA As New DA.ProveedorDA
        OBJDA.BajaPlazoProveedor(Proveedor)
    End Sub

    Public Function GetIDProveedorRecienIngresado(ByVal idPersonav As Int32) As Int32
        Dim OBJDA As New DA.ProveedorDA
        Dim tabla As New DataTable
        tabla = OBJDA.GetIDProveedorRecienInsertado(idPersonav)
        Dim IdPersona As New Int32
        For Each row As DataRow In tabla.Rows
            IdPersona = CInt(row("dage_proveedorid"))
        Next
        Return IdPersona
    End Function

    Public Function UltimoIdSicy(ByVal idPersonav As Int32) As Int32
        Dim OBJDA As New DA.ProveedorDA
        Dim tabla As New DataTable
        tabla = OBJDA.UltimoIdSICY(idPersonav)
        Dim IdPersona As New Int32
        For Each row As DataRow In tabla.Rows
            IdPersona = CInt(row("IdProveedor"))
        Next
        Return IdPersona
    End Function

    Public Function UltimoIdBancoSicy(ByVal idPersonav As Int32) As Int32
        Dim OBJDA As New DA.ProveedorDA
        Dim tabla As New DataTable
        tabla = OBJDA.UltimoIdBancoSICY(idPersonav)
        Dim Idcta As New Int32
        For Each row As DataRow In tabla.Rows
            Idcta = CInt(row("idctaProv"))
        Next
        Return Idcta
    End Function

    Public Function ListaDatosGeneralesProveedor() As DataTable
        Dim objDA As New DA.ProveedorDA
        ListaDatosGeneralesProveedor = objDA.ListaDatosGeneralesProveedor()
        Return ListaDatosGeneralesProveedor
    End Function

    Public Function ListaDatosGeneralesProveedorFiltradaNave(ByVal idnave As Integer, ByVal activa As String) As DataTable
        Dim objDA As New DA.ProveedorDA
        ListaDatosGeneralesProveedorFiltradaNave = objDA.ListaDatosGeneralesProveedorFiltrarNave(idnave, activa)
        Return ListaDatosGeneralesProveedorFiltradaNave
    End Function

    Public Function ListaDatosGeneralesProveedorFiltradaNaveNo(ByVal idnave As Integer, ByVal activa As String) As DataTable
        Dim objDA As New DA.ProveedorDA
        ListaDatosGeneralesProveedorFiltradaNaveNo = objDA.ListaDatosGeneralesProveedorFiltrarNaveNo(idnave, activa)
        Return ListaDatosGeneralesProveedorFiltradaNaveNo
    End Function

    Public Function ListaDatosGeneralesTodosProveedorFiltradaNaveNo(ByVal idnave As Integer) As DataTable
        Dim objDA As New DA.ProveedorDA
        ListaDatosGeneralesTodosProveedorFiltradaNaveNo = objDA.ListaDatosGeneralesTodosProveedorFiltrarNaveNo(idnave)
        Return ListaDatosGeneralesTodosProveedorFiltradaNaveNo
    End Function

    Public Function ListaDatosGeneralesProveedor2() As DataTable
        Dim objDA As New DA.ProveedorDA
        ListaDatosGeneralesProveedor2 = objDA.ListaDatosGeneralesProveedor2()
        Return ListaDatosGeneralesProveedor2
    End Function

    Public Function ListaDatosGeneralesProveedor3() As DataTable
        Dim objDA As New DA.ProveedorDA
        ListaDatosGeneralesProveedor3 = objDA.ListaDatosGeneralesProveedor3()
        Return ListaDatosGeneralesProveedor3
    End Function

    Public Function ListaRFC(ByVal idProveedor As Integer) As DataTable
        Dim objDA As New DA.ProveedorDA
        Dim tabla As New DataTable
        tabla = objDA.ListaRFC(idProveedor)
        Return tabla
    End Function

    Public Function ListaNombresRFC(ByVal Razonsocial As Integer) As DataTable
        Dim objDA As New DA.ProveedorDA
        Dim tabla As New DataTable
        tabla = objDA.RazonSocial(Razonsocial)
        Return tabla
    End Function

    Public Function ListaDeGiros() As DataTable
        Dim objDA As New DA.ProveedorDA
        Dim tabla As New DataTable
        tabla = objDA.ListaDeGiros()
        Return tabla
    End Function

    Public Function ListaPaises() As DataTable
        Dim objDA As New DA.ProveedorDA
        Dim tabla As New DataTable
        tabla = objDA.ListaPaises()
        Return tabla
    End Function

    Public Function ListaCategorias() As DataTable
        Dim objDA As New DA.ProveedorDA
        Dim tabla As New DataTable
        tabla = objDA.ListaCategorias()
        Return tabla
    End Function

    Public Function ListaBancos() As DataTable
        Dim objDA As New DA.ProveedorDA
        Dim tabla As New DataTable
        tabla = objDA.ListaBancos()
        Return tabla
    End Function

    Public Function ListaEstados(ByVal paisid As Integer) As DataTable
        Dim objDA As New DA.ProveedorDA
        Dim tabla As New DataTable
        tabla = objDA.ListaEstados(paisid)
        Return tabla
    End Function

    Public Function ListaCiudades(ByVal estadoid As Integer) As DataTable
        Dim objDA As New DA.ProveedorDA
        Dim tabla As New DataTable
        tabla = objDA.ListaCiudades(estadoid)
        Return tabla
    End Function

    Public Function ListaTiposRFC() As DataTable
        Dim objDA As New DA.ProveedorDA
        Dim tabla As New DataTable
        tabla = objDA.ListaTiposRFC()
        Return tabla
    End Function


    Public Function ListaUsuariosSitioProveedor(ByVal idProveedor As Integer) As DataTable
        Dim objDA As New DA.ProveedorDA
        Dim tabla As New DataTable
        tabla = objDA.ListaUsuariosSitioProveedor(idProveedor)
        Return tabla
    End Function

    Public Function ListaProveedorRFC(ByVal idProveedor As Integer) As DataTable
        Dim objDA As New DA.ProveedorDA
        Dim tabla As New DataTable
        tabla = objDA.ListaProveedorRFC(idProveedor)
        Return tabla
    End Function

    Public Function ListaPlazo(ByVal idProveedor As Integer) As DataTable
        Dim objDA As New DA.ProveedorDA
        Dim tabla As New DataTable
        tabla = objDA.ListaPlazo(idProveedor)
        Return tabla
    End Function

    Public Function ListaPlazoProveedor(ByVal idProveedor As Integer) As DataTable
        Dim objDA As New DA.ProveedorDA
        Dim tabla As New DataTable
        tabla = objDA.ListaPlazoProveedor(idProveedor)
        Return tabla
    End Function

    Public Function ListaNavesProveedor(ByVal idProveedor As Integer) As DataTable
        Dim objDA As New DA.ProveedorDA
        Dim tabla As New DataTable
        tabla = objDA.ListaNavesProveedor(idProveedor)
        Return tabla
    End Function

    Public Function BuscaContactoRepetido(ByVal nombre As String, ByVal cargo As String, ByVal departamento As String, ByVal proveedorid As Integer) As DataTable
        Dim objDA As New DA.ProveedorDA
        Dim tabla As New DataTable
        tabla = objDA.BuscaContactoRepetido(nombre, cargo, departamento, proveedorid)
        Return tabla
    End Function

    Public Function BuscaRazonSocial(ByVal rfc As String, ByVal id As Integer) As DataTable
        Dim objDA As New DA.ProveedorDA
        Dim tabla As New DataTable
        tabla = objDA.BuscaRazonSocial(rfc, id)
        Return tabla
    End Function

    Public Function BuscaRfcSicyCta(ByVal rfc As String) As DataTable
        Dim objDA As New DA.ProveedorDA
        Dim tabla As New DataTable
        tabla = objDA.BuscaRfcSicyCta(rfc)
        Return tabla
    End Function

    Public Function BuscarNumCobrador(ByVal idProveedor As Integer) As DataTable
        Dim objDA As New DA.ProveedorDA
        Dim tabla As New DataTable
        tabla = objDA.BuscarNumCobrador(idProveedor)
        Return tabla
    End Function

    Public Function BuscaUsuarioRepetido(ByVal nombre As String, ByVal usuario As String, ByVal id As Integer) As DataTable
        Dim objDA As New DA.ProveedorDA
        Dim tabla As New DataTable
        tabla = objDA.BuscaUsuarioRepetido(nombre, usuario, id)
        Return tabla
    End Function

    Public Function BuscaProveedorRepetido(ByVal nombre As String) As DataTable
        Dim objDA As New DA.ProveedorDA
        Dim tabla As New DataTable
        tabla = objDA.BuscaProveedorRepetido(nombre)
        Return tabla
    End Function

    Public Function DesactivarRFC(ByVal Proveedores As Entidades.DatosProveedor) As DataTable
        Dim objDA As New DA.ProveedorDA
        objDA.DesactivarRFC(Proveedores)
    End Function

    Public Function DesactivarCuenta(ByVal Proveedores As Entidades.DatosDeCuentaBancaria) As DataTable
        Dim objDA As New DA.ProveedorDA
        objDA.DesactivarCuenta(Proveedores)
    End Function

    Public Function DesactivarContacto(ByVal Proveedores As Entidades.DatosContacto) As DataTable
        Dim objDA As New DA.ProveedorDA
        objDA.DesactivarContacto(Proveedores)
    End Function

    Public Function DesactivarUsuario(ByVal Proveedores As Entidades.UsuarioProveedor) As DataTable
        Dim objDA As New DA.ProveedorDA
        objDA.DesactivarUsuario(Proveedores)
    End Function

    '*************************************
    Public Function BusquedaGrande(ByVal nombre As String) As DataTable
        Dim objDA As New DA.ProveedorDA
        Dim tabla As New DataTable
        tabla = objDA.BusquedaGrande(nombre)
        Return tabla
    End Function

    Public Function BuscaAlgunRfc(ByVal nombre As String) As DataTable
        Dim objDA As New DA.ProveedorDA
        Dim tabla As New DataTable
        tabla = objDA.BuscaAlgunRfc(nombre)
        Return tabla
    End Function

    Public Function BuscaAlgunaCuenta(ByVal nombre As String) As DataTable
        Dim objDA As New DA.ProveedorDA
        Dim tabla As New DataTable
        tabla = objDA.BuscaAlgunaCuenta(nombre)
        Return tabla
    End Function

    Public Function BuscaAlgunUsuario(ByVal nombre As String) As DataTable
        Dim objDA As New DA.ProveedorDA
        Dim tabla As New DataTable
        tabla = objDA.BuscaAlgunUsuario(nombre)
        Return tabla
    End Function

    Public Function BuscaAlgunContacto(ByVal nombre As String) As DataTable
        Dim objDA As New DA.ProveedorDA
        Dim tabla As New DataTable
        tabla = objDA.BuscaAlgunContacto(nombre)
        Return tabla
    End Function

    Public Function BuscaAlgunPlazo(ByVal nombre As String) As DataTable
        Dim objDA As New DA.ProveedorDA
        Dim tabla As New DataTable
        tabla = objDA.BuscaAlgunPlazo(nombre)
        Return tabla
    End Function

    Public Function BuscaAlguaNave(ByVal nombre As String) As DataTable
        Dim objDA As New DA.ProveedorDA
        Dim tabla As New DataTable
        tabla = objDA.BuscaAlgunaNave(nombre)
        Return tabla
    End Function
    '***************************************

    Public Function BuscaGiroRepetido(ByVal giro As String) As DataTable
        Dim objDA As New DA.ProveedorDA
        Dim tabla As New DataTable
        tabla = objDA.BuscaGiroRepetido(giro)
        Return tabla
    End Function

    Public Function BuscaUsuarPlazoRepetido(ByVal id As Integer, idproveedor As Integer) As DataTable
        Dim objDA As New DA.ProveedorDA
        Dim tabla As New DataTable
        tabla = objDA.BuscaUsuarioPlazoRepetido(id, idproveedor)
        Return tabla
    End Function

    Public Function BuscaUsuarNaveRepetida(ByVal id As Integer, idproveedor As Integer) As DataTable
        Dim objDA As New DA.ProveedorDA
        Dim tabla As New DataTable
        tabla = objDA.BuscaUsuarioNaveRepetida(id, idproveedor)
        Return tabla
    End Function

    Public Function ListaDeCuentasBancarias(ByVal idProveedor As Integer) As DataTable
        Dim objDA As New DA.ProveedorDA
        Dim tabla As New DataTable
        tabla = objDA.listaCuentasBancarias(idProveedor)
        Return tabla
    End Function

    Public Function ListaDeCuentasBancariasCompleta(ByVal idProveedor As Integer) As DataTable
        Dim objDA As New DA.ProveedorDA
        Dim tabla As New DataTable
        tabla = objDA.listaCuentasBancariasCompleta(idProveedor)
        Return tabla
    End Function


    Public Function ListaDeContactosVentasCompleta(ByVal idProveedor As Integer) As DataTable
        Dim objDA As New DA.ProveedorDA
        Dim tabla As New DataTable
        tabla = objDA.listaContactosVentasCompleta(idProveedor)
        Return tabla
    End Function

    Public Function ListaDeUsuariosActivos(ByVal idProveedor As Integer) As DataTable
        Dim objDA As New DA.ProveedorDA
        Dim tabla As New DataTable
        tabla = objDA.listaUsuariosActivosProveedor(idProveedor)
        Return tabla
    End Function

    Public Function ListaDeUsuariosInactivos(ByVal idProveedor As Integer) As DataTable
        Dim objDA As New DA.ProveedorDA
        Dim tabla As New DataTable
        tabla = objDA.listaUsuariosInactivosProveedor(idProveedor)
        Return tabla
    End Function

    Public Function ListaDeContactosVentasCompleta2(ByVal idProveedor As Integer) As DataTable
        Dim objDA As New DA.ProveedorDA
        Dim tabla As New DataTable
        tabla = objDA.listaContactosVentasCompleta2(idProveedor)
        Return tabla
    End Function

    Public Function ListaDeContactosCobranzaCompleta(ByVal idProveedor As Integer) As DataTable
        Dim objDA As New DA.ProveedorDA
        Dim tabla As New DataTable
        tabla = objDA.listaContactosCobranzaCompleta(idProveedor)
        Return tabla
    End Function

    Public Function ListaDeContactosCobranzaCompleta2(ByVal idProveedor As Integer) As DataTable
        Dim objDA As New DA.ProveedorDA
        Dim tabla As New DataTable
        tabla = objDA.listaContactosCobranzaCompleta2(idProveedor)
        Return tabla
    End Function

    Public Function ListaNaves() As DataTable
        Dim objDA As New DA.ProveedorDA
        Dim tabla As New DataTable
        tabla = objDA.listaNaves()
        Return tabla
    End Function

    Public Function ListaNavesCombo() As DataTable
        Dim objDA As New DA.ProveedorDA
        Dim tabla As New DataTable
        tabla = objDA.listaNavesCombo()
        Return tabla
    End Function

    Public Function BuscaCoincidenciaNombre(ByVal rfc As String) As DataTable
        Dim objDA As New DA.ProveedorDA
        Dim tabla As New DataTable
        tabla = objDA.BuscaCoincidenciaNombre(rfc)
        Return tabla
    End Function

    Public Function BuscaCoincidenciaNombreDAGE(ByVal rfc As String) As DataTable
        Dim objDA As New DA.ProveedorDA
        Dim tabla As New DataTable
        tabla = objDA.BuscaCoincidenciaNombreDAGE(rfc)
        Return tabla
    End Function

    Public Function BuscaCoincidenciaRFC(ByVal rfc As String) As DataTable
        Dim objDA As New DA.ProveedorDA
        Dim tabla As New DataTable
        tabla = objDA.BuscaCoincidenciaRFC(rfc)
        Return tabla
    End Function

    Public Function BuscaCoincidenciaNombreRazonSocial(ByVal rfc As String) As DataTable
        Dim objDA As New DA.ProveedorDA
        Dim tabla As New DataTable
        tabla = objDA.BuscaCoincidenciaNombreRazonSocial(rfc)
        Return tabla
    End Function

    Public Function BuscaCoincidenciaRazonSocial(ByVal razonSocial As String) As DataTable
        Dim objDA As New DA.ProveedorDA
        Dim tabla As New DataTable
        tabla = objDA.BuscaCoincidenciaRazonSocial(razonSocial)
        Return tabla
    End Function

    Public Function ObtieneMonedasProveedor() As DataTable
        Dim objDA As New DA.ProveedorDA
        Dim tabla As New DataTable
        tabla = objDA.ObtieneMonedasProveedor()
        Return tabla
    End Function

    Public Function InsertarMonedasProveedor(ByVal ProveedorID As Integer, ByVal Monedas As String) As DataTable
        Dim objDA As New DA.ProveedorDA
        Dim tabla As New DataTable
        tabla = objDA.InsertarMonedasProveedor(ProveedorID, Monedas)
        Return tabla
    End Function

    Public Function CargarMonedasProveedor(ByVal ProveedorID As Integer) As DataTable
        Dim objDA As New DA.ProveedorDA
        Dim tabla As New DataTable
        tabla = objDA.CargarMonedasProveedor(ProveedorID)
        Return tabla
    End Function

End Class



