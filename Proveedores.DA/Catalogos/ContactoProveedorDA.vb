Imports Persistencia
Imports System.Data.SqlClient
Imports Entidades
Imports Tools

Public Class ContactoProveedorDA

    Public Function AgregarFotoFirmaContactoProveedor(ByVal ContactoID As Integer, ByVal RutaArchivo As String, ByVal EsFoto As Boolean) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter


        parametro = New SqlParameter
        parametro.ParameterName = "ContactoID"
        parametro.Value = ContactoID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "RutaArchivo"
        parametro.Value = RutaArchivo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "EsFoto"
        parametro.Value = EsFoto
        listaParametros.Add(parametro)

       

        Return objPersistencia.EjecutarConsultaSP("[Proveedor].[SP_AgregarFotoFirmaContactoProveedor]", listaParametros)
    End Function

    Public Function AltaContacto(ByVal ProveedorID As Integer, ByVal Nombre As String, ByVal APaterno As String, ByVal AMaterno As String, ByVal Cargo As String, ByVal Telefono As String, ByVal Email As String, ByVal TipoContacto As String, ByVal UsuarioCreoId As Integer, ByVal Foto As String, ByVal Firma As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "ProveedorID"
        parametro.Value = ProveedorID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Nombre"
        parametro.Value = Nombre
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "APaterno"
        parametro.Value = APaterno
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "AMaterno"
        parametro.Value = AMaterno
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Cargo"
        parametro.Value = Cargo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Telefono"
        parametro.Value = Telefono
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Email"
        parametro.Value = Email
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "TipoContacto"
        parametro.Value = TipoContacto
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "UsuarioCreoID"
        parametro.Value = UsuarioCreoId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Foto"
        If Foto = String.Empty Then
            parametro.Value = DBNull.Value
        Else
            parametro.Value = Foto
        End If
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Firma"

        If Firma = String.Empty Then
            parametro.Value = DBNull.Value
        Else
            parametro.Value = Firma
        End If

        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Proveedor].[SP_AltaContactoProveedor]", listaParametros)
    End Function


    Public Function EditarContacto(ByVal DatosContactoID As Integer, ByVal Nombre As String, ByVal APaterno As String, ByVal AMaterno As String, ByVal Cargo As String, ByVal Telefono As String, ByVal Email As String, ByVal TipoContacto As String, ByVal UsuarioCreoId As Integer, ByVal Foto As String, ByVal Firma As String, ByVal Activo As Boolean) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "DatosContactoId"
        parametro.Value = DatosContactoID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Nombre"
        parametro.Value = Nombre
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "APaterno"
        parametro.Value = APaterno
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "AMaterno"
        parametro.Value = AMaterno
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Cargo"
        parametro.Value = Cargo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Telefono"
        parametro.Value = Telefono
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Email"
        parametro.Value = Email
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "TipoContacto"
        parametro.Value = TipoContacto
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "UsuarioCreoID"
        parametro.Value = UsuarioCreoId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Foto"
        If Foto = String.Empty Then
            parametro.Value = DBNull.Value
        Else
            parametro.Value = Foto
        End If        
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Firma"
        If Firma = String.Empty Then
            parametro.Value = DBNull.Value
        Else
            parametro.Value = Firma
        End If
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Activo"
        parametro.Value = Activo
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Proveedor].[SP_EditarContactoProveedor]", listaParametros)
    End Function

    Public Function ConsultaInformacionContacto(ByVal DatosContactoID As Integer) As DataTable

        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "DatosContactoId"
        parametro.Value = DatosContactoID
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Proveedor].[SP_ConsultaInformacionContacto]", listaParametros)

    End Function

    Public Function BuscarContactoRepetido(ByVal Nombre As String, ByVal APaterno As String, ByVal AMaterno As String) As Boolean

        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Dim DTInformacionContacto As DataTable
        Dim ContactoId As Integer = -1
        Dim Existe As Boolean = False

        parametro = New SqlParameter
        parametro.ParameterName = "Nombre"
        parametro.Value = Nombre
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "APaterno"
        parametro.Value = APaterno
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "AMaterno"
        parametro.Value = AMaterno
        listaParametros.Add(parametro)

        DTInformacionContacto = objPersistencia.EjecutarConsultaSP("[Proveedor].[SP_BuscarContactoRepetido]", listaParametros)

        If DTInformacionContacto.Rows.Count > 0 Then
            ContactoId = DTInformacionContacto.Rows(0).Item("daco_datoscontactoid").ToString
            If ContactoId > 0 Then
                Existe = True
            Else
                Existe = False
            End If

        End If

        Return Existe
    End Function



End Class
