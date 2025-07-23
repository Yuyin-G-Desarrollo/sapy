Public Class ContactosBU

    Public Function TablaContactosSegunAreaOperativa(PersonaID As Integer, AreaOperativaID As Integer) As DataTable
        Dim objDA As New Datos.ContactosDA
        Return objDA.ConsultarContactosAreaOperativa(PersonaID, AreaOperativaID)
    End Function

    Public Function TablaContactosSinAreaOperativa(PersonaID As Integer, AreaOperativaID As Integer) As DataTable
        Dim objDA As New Datos.ContactosDA
        Return objDA.TablaContactosSinAreaOperativa(PersonaID, AreaOperativaID)
    End Function


    Public Function TablaCargosSegunAreaOperativa(AreaOperativaID As Integer) As DataTable
        Dim objDA As New Datos.ContactosDA
        Return objDA.TablaCargosSegunAreaOperativa(AreaOperativaID)
    End Function

    Public Function TablaCargosSinAreaOperativa() As DataTable
        Dim objDA As New Datos.ContactosDA
        Return objDA.TablaCargosSinAreaOperativa()
    End Function
    Public Function consultaClasificacionTipoPersona() As DataTable
        Dim objConsultaTipo As New Datos.ContactosDA
        Return objConsultaTipo.consultarClasificacionPersona
    End Function
    Public Function TablaTipoTelefonos() As DataTable
        Dim objDA As New Datos.ContactosDA
        Return objDA.TablaTipoTelefonos()
    End Function

    Public Sub AltaContacto_PantallaContacto(ByVal nombre As String, ByVal IdClasePersona As Integer, ByVal cliente_IdPersona As Integer)

        Dim ContactosDA As New Datos.ContactosDA

        ContactosDA.AltaContacto_PantallaContacto(nombre, IdClasePersona, cliente_IdPersona)

    End Sub

    Public Sub AltaContacto(persona As Entidades.Persona,
                            clasificacionpersona As Entidades.ClasificacionPersona,
                            cliente_persona As Entidades.Persona,
                            cliente As Entidades.Cliente,
                            email As Entidades.Email,
                            telefono As Entidades.Telefono,
                            tipoTelefono As Entidades.TipoTelefono)
        '    Dim ContactosDA As New Datos.ContactosDA
        '    ContactosDA.AltaContacto(persona, clasificacionpersona, cliente_persona, cliente, email, telefono, tipoTelefono)
    End Sub

    Public Sub EditarContacto(bandera As Integer, clasificacionpersona As Entidades.ClasificacionPersona, persona As Entidades.Persona,
                              email As Entidades.Email, telefono As Entidades.Telefono,
                              tipoTelefono As Entidades.TipoTelefono)

        Dim personaDA As New Datos.ContactosDA
        personaDA.EditarContacto(bandera, clasificacionpersona, persona, email, telefono, tipoTelefono)
    End Sub

    Public Function ConsultaContactosReferenciasComerciales(ByVal IdPersonaClienteSay As Integer, ByVal permiso As Boolean) As DataTable
        Dim objConsulta As New Datos.ContactosDA
        Dim tblDatos As New DataTable
        tblDatos = objConsulta.ObtenerContactosReferenciasComerciales(IdPersonaClienteSay, permiso)
        Return tblDatos
    End Function

    Public Function listaAsignacionesdeContacto(ByVal Id_PersonaContacto As String) As DataTable
        Dim objDA As New Datos.ContactosDA
        listaAsignacionesdeContacto = objDA.listaAsignacionesdeContacto(Id_PersonaContacto)
        Return listaAsignacionesdeContacto
    End Function

    Public Function lista_Asignaciones_De_Contacto_Activas(ByVal IdPersonaClienteSay As Integer, ByVal IdPersonaContactoSay As Integer) As DataTable
        Dim objDA As New Datos.ContactosDA
        lista_Asignaciones_De_Contacto_Activas = objDA.lista_Asignaciones_De_Contacto_Activas(IdPersonaClienteSay, IdPersonaContactoSay)
        Return lista_Asignaciones_De_Contacto_Activas
    End Function

    Public Function Lista_Contactos_Activos(ByVal IdPersonaCliente As Integer) As DataTable
        Dim objda As New Datos.ContactosDA
        Lista_Contactos_Activos = objda.Lista_Contactos_Activos(IdPersonaCliente)
        Return Lista_Contactos_Activos
    End Function

    Public Function Lista_Tipo_Telefono_Activo() As DataTable
        Dim objda As New Datos.ContactosDA
        Lista_Tipo_Telefono_Activo = objda.Lista_Tipo_Telefono_Activo()
        Return Lista_Tipo_Telefono_Activo
    End Function

    Public Function ListaTelefonosdeContacto(ByVal Id_PersonaContacto As String) As DataTable
        Dim objDA As New Datos.ContactosDA
        ListaTelefonosdeContacto = objDA.ConsultarListaTelefonosdeContacto(Id_PersonaContacto)
        Return ListaTelefonosdeContacto
    End Function

    Public Function ListaCorreosdeContacto(ByVal Id_PersonaContacto As String) As DataTable
        Dim objDA As New Datos.ContactosDA
        ListaCorreosdeContacto = objDA.ListaCorreosdeContacto(Id_PersonaContacto)
        Return ListaCorreosdeContacto
    End Function

    Public Sub ActualizarContacto(ByVal IdContacto As Integer, ByVal Nombre As String, ByVal Activo As Boolean)
        Dim objDA As New Datos.ContactosDA
        objDA.ActualizarContacto(IdContacto, Nombre, Activo)
    End Sub

    Public Sub GuardarCargoContacto(relacion As Entidades.RelacionesPersonas)
        Dim objDA As New Datos.ContactosDA
        objDA.GuardarCargoContacto(relacion)
    End Sub

    Public Sub ActualizarCargoContacto(ByVal IdRelacioPersona As Integer, ByVal Activo As Boolean)
        Dim objDA As New Datos.ContactosDA

        objDA.ActualizarCargosContacto(IdRelacioPersona, Activo)
    End Sub

    Public Sub GuardarTelefonoContacto(ByVal Telefono As Entidades.Telefono)
        Dim objDA As New Datos.ContactosDA
        objDA.GuardarTelefonoContacto(Telefono)
    End Sub
    Public Sub GuardarCorreoContacto(ByVal EMail As Entidades.Email)
        Dim objDA As New Datos.ContactosDA
        objDA.GuardarCorreoContacto(EMail)
    End Sub

    Public Sub ActualizarCorreoContacto(ByVal EMail As Entidades.Email)
        Dim objDA As New Datos.ContactosDA
        objDA.ActualizarCorreoContacto(EMail)
    End Sub

    Public Function Lista_ClasificacionPersona_Activos_Sin_Asignar(ByVal IdPersona_Contacto As Integer, ByVal IdPersona_Cliente As Integer) As DataTable
        Dim objDA As New Datos.ContactosDA
        Lista_ClasificacionPersona_Activos_Sin_Asignar = objDA.Lista_ClasificacionPersona_Activos_Sin_Asignar(IdPersona_Contacto, IdPersona_Cliente)
        Return Lista_ClasificacionPersona_Activos_Sin_Asignar
    End Function

    Public Function RecuperarRegistroExistente_Telefono(ByVal Telefono As Entidades.Telefono, ByVal OrigiNal As Boolean) As DataTable
        Dim objDA As New Datos.ContactosDA
        RecuperarRegistroExistente_Telefono = objDA.ConsultarRegistroExistenteTelefono(Telefono, OrigiNal)
        Return RecuperarRegistroExistente_Telefono
    End Function

    Public Function RecuperarRegistroExistente_Correo(ByVal Correo As Entidades.Email, ByVal Original As Boolean) As DataTable
        Dim objDA As New Datos.ContactosDA
        RecuperarRegistroExistente_Correo = objDA.RecuperarRegistroExistente_Correo(Correo, Original)
        Return RecuperarRegistroExistente_Correo
    End Function

    Public Function RecuperarRegistroExistente_Asignacion(ByVal Asignacion As Entidades.RelacionesPersonas, ByVal Original As Boolean) As DataTable
        Dim objDA As New Datos.ContactosDA
        RecuperarRegistroExistente_Asignacion = objDA.RecuperarRegistroExistente_Asignacion(Asignacion, Original)
        Return RecuperarRegistroExistente_Asignacion
    End Function
    Public Function listaContactos_y_ReferenciasComerciales(ByVal IdPersonaClienteSay As String) As DataTable
        Dim objDA As New Datos.ContactosDA
        listaContactos_y_ReferenciasComerciales = objDA.ConsultarListaTelefonosdeContacto(IdPersonaClienteSay)
        Return listaContactos_y_ReferenciasComerciales
    End Function
    Public Sub ActualizarTelefonoContacto(ByVal Telefono As Entidades.Telefono)
        Dim objDA As New Datos.ContactosDA

        objDA.GuardarTelefonoContacto(Telefono)
    End Sub
End Class
