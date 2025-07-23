
Public Class ContactoProveedorBU


    Public Function AgregarFotoFirmaContactoProveedor(ByVal ContactoID As Integer, ByVal RutaArchivo As String, ByVal EsFoto As Boolean) As DataTable
        Dim objContactoProveedor As New Proveedores.DA.ContactoProveedorDA
        Return objContactoProveedor.AgregarFotoFirmaContactoProveedor(ContactoID, RutaArchivo, EsFoto)
    End Function

    Public Function AltaContacto(ByVal ProveedorID As Integer, ByVal Nombre As String, ByVal APaterno As String, ByVal AMaterno As String, ByVal Cargo As String, ByVal Telefono As String, ByVal Email As String, ByVal TipoContacto As String, ByVal UsuarioCreoId As Integer, ByVal Foto As String, ByVal Firma As String) As DataTable
        Dim objContactoProveedor As New Proveedores.DA.ContactoProveedorDA
        Return objContactoProveedor.AltaContacto(ProveedorID, Nombre, APaterno, AMaterno, Cargo, Telefono, Email, TipoContacto, UsuarioCreoId, Foto, Firma)
    End Function

    Public Function EditarContacto(ByVal DatosContactoID As Integer, ByVal Nombre As String, ByVal APaterno As String, ByVal AMaterno As String, ByVal Cargo As String, ByVal Telefono As String, ByVal Email As String, ByVal TipoContacto As String, ByVal UsuarioCreoId As Integer, ByVal Foto As String, ByVal Firma As String, ByVal Activo As Boolean) As DataTable
        Dim objContactoProveedor As New Proveedores.DA.ContactoProveedorDA
        Return objContactoProveedor.EditarContacto(DatosContactoID, Nombre, APaterno, AMaterno, Cargo, Telefono, Email, TipoContacto, UsuarioCreoId, Foto, Firma, Activo)
    End Function

    Public Function ConsultaInformacionContacto(ByVal DatosContactoID As Integer) As Entidades.DatosContacto
        Dim objContactoProveedor As New Proveedores.DA.ContactoProveedorDA
        Dim EntContacto As New Entidades.DatosContacto
        Dim DtInformacionContacto As DataTable

        DtInformacionContacto = objContactoProveedor.ConsultaInformacionContacto(DatosContactoID)

        If DtInformacionContacto.Rows.Count > 0 Then
            EntContacto.daco_datoscontactoid = DtInformacionContacto.Rows(0).Item("daco_datoscontactoid").ToString()
            EntContacto.daco_nombre = DtInformacionContacto.Rows(0).Item("daco_nombre").ToString()
            EntContacto.daco_APaterno = DtInformacionContacto.Rows(0).Item("daco_apaterno").ToString()
            EntContacto.daco_AMaterno = DtInformacionContacto.Rows(0).Item("daco_amaterno").ToString()
            EntContacto.daco_cargo = DtInformacionContacto.Rows(0).Item("daco_cargo").ToString()
            EntContacto.daco_telefono = DtInformacionContacto.Rows(0).Item("daco_telefono").ToString()
            EntContacto.daco_email = DtInformacionContacto.Rows(0).Item("daco_email").ToString()
            EntContacto.daco_TipoContacto = DtInformacionContacto.Rows(0).Item("daco_tipocontacto").ToString()
            EntContacto.dage_proveedorid = DtInformacionContacto.Rows(0).Item("daco_proveedorid").ToString()
            EntContacto.daco_usuariocreoid = DtInformacionContacto.Rows(0).Item("daco_usuariocreoid").ToString()
            If IsDBNull(DtInformacionContacto.Rows(0).Item("daco_usuariomodificoid")) = False Then
                EntContacto.daco_usuariomodificoid = DtInformacionContacto.Rows(0).Item("daco_usuariomodificoid").ToString()
            Else
                EntContacto.daco_usuariomodificoid = -1
            End If

            If IsDBNull(DtInformacionContacto.Rows(0).Item("daco_fechamodificacion")) = False Then
                EntContacto.daco_fechamodificacion = DtInformacionContacto.Rows(0).Item("daco_fechamodificacion").ToString()
            End If

            EntContacto.daco_fechacreacion = DtInformacionContacto.Rows(0).Item("daco_fechacreacion").ToString()

            If IsDBNull(DtInformacionContacto.Rows(0).Item("daco_foto")) = False Then
                EntContacto.daco_foto = DtInformacionContacto.Rows(0).Item("daco_foto").ToString()
            Else
                EntContacto.daco_foto = String.Empty
            End If

            If IsDBNull(DtInformacionContacto.Rows(0).Item("daco_firma")) = False Then
                EntContacto.daco_Firma = DtInformacionContacto.Rows(0).Item("daco_firma").ToString()
            Else
                EntContacto.daco_Firma = String.Empty
            End If


            EntContacto.daco_activo = DtInformacionContacto.Rows(0).Item("daco_activo").ToString()
        End If

        Return EntContacto
    End Function

    Public Function BuscarContactoRepetido(ByVal Nombre As String, ByVal APaterno As String, ByVal AMaterno As String) As Boolean
        Dim objContactoProveedor As New Proveedores.DA.ContactoProveedorDA
        Return objContactoProveedor.BuscarContactoRepetido(Nombre, APaterno, AMaterno)
    End Function

   
End Class
