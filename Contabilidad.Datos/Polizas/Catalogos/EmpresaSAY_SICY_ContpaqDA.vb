Imports Persistencia
Imports System.Data.SqlClient

Public Class EmpresaSAY_SICY_ContpaqDA

    Public Function Consulta_lista_EmpresaSAY_SICY_Contpaq() As DataTable

        Dim operaciones As New OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)

        Return operaciones.EjecutarConsultaSP("[Contabilidad].[SP_Empresas_Consulta_lista_EmpresaSAY_SICY_Contpaq]", ListaParametros)
        'Dim consulta As String = String.Empty
        'consulta += " " +
        '            " SELECT" +
        '            " 	essc_empresaid AS 'ID'," +
        '            "   empr_empresaid AS 'SAY ID'," +
        '            " 	empr_nombre AS 'Empresa'," +
        '            " 	Contribuyentes.IDRazSoc AS 'RazSoc ID'," +
        '            " 	Contribuyentes.RazonSocial AS 'Razón Social'," +
        '            " 	DoctosVentas.idDocumento AS 'Doc ID'," +
        '            " 	DoctosVentas.RazonSocial AS 'Documento'," +
        '            " 	essc_empresacontpaq AS 'Base ID'," +
        '            " 	essc_empresacontpaq AS 'Base Contpaq', essc_servidor" +
        '            " FROM Framework.Empresas" +
        '            " LEFT JOIN Framework.empresaSaySicyContpaq ON empr_empresaid = essc_sayid" +
        '            " LEFT JOIN [192.168.2.2].[Yuyin_respaldo].[dbo].[Contribuyentes] ON IDRazSoc = essc_contribuyentesicyid" +
        '            " LEFT JOIN [192.168.2.2].[Yuyin_respaldo].[dbo].[DoctosVentas] ON IdDocumento = essc_doctoventassicyid" +
        '            " ORDER BY empr_nombre"

        'Return operaciones.EjecutaConsulta(consulta)

    End Function

    
    ''' <summary>
    ''' METODO PARA DAR DE ALTA EMPRESAS Ó MODIFICAR INFORMACIÓN EN LA BASE DE DATOS DEL SAY
    ''' </summary>
    ''' <param name="Empresa">OBJETO DE LA ENTIDAD EMPRESA CON LA INFORMACIÓN DE LA EMPRESA A AGREGAR Ó MODIFICAR</param>
    ''' <param name="AltaEdicion">VARIABLE DEL TIPO BOLEANO, SU VALOR TRUE INDICA QUE SE DARA DE ALTA UN REGISTRO, SU VALOR FALSE
    ''' INDICA QUE SE ACTUALIZARA UN REGISTRO</param>
    ''' <remarks></remarks>
    Public Sub Alta_Edicion_EmpresaSAY(ByVal Empresa As Entidades.Empresa, ByVal AltaEdicion As Boolean)
        Dim operaciones As New OperacionesProcedimientos
        Dim consulta As String
        If AltaEdicion = True Then
            consulta = "INSERT INTO [Framework].[Empresas] (empr_nombre, empr_rfc, empr_activo, empr_usuariocreoid, empr_fechacreacion" +
                        ",empr_tasaiva, empr_tasaivaencabezado, empr_razonsocial)" +
                        "  VALUES('" + Empresa.Pempr_nombre + "', '" + Empresa.PRFCEmpresa + "', '" + Empresa.Pempr_activo.ToString +
                        "', " + Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid.ToString + ",(SELECT GETDATE())" +
                        ", " + Empresa.PTasaIva.ToString +
                        "," + Empresa.PTasaIvaEncabezado.ToString + ", '" + Empresa.Pempr_nombre + "' )"
        Else
            consulta = "UPDATE [Framework].[Empresas]" +
                " SET [empr_nombre] = " + Empresa.Pempr_nombre +
                " ,[empr_rfc] = " + Empresa.PRFCEmpresa +
                ",[empr_activo] = " + Empresa.Pempr_activo.ToString +
                ",[empr_usuariomodificoid] = " + Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid.ToString +
                ",[empr_fechamodificacion] = (select getdate())" +
                ",[empr_tasaiva] = " + Empresa.PTasaIva.ToString +
                ",[empr_tasaivaencabezado] =  " + Empresa.PTasaIvaEncabezado.ToString +
                " WHERE empr_empresaid = " + Empresa.Pempr_empresaid
        End If

        operaciones.EjecutaConsulta(consulta)
    End Sub

    ''' <summary>
    ''' METÓDO PARA AGREGAR REGISTROS Ó EDITAR EN LA TABLA EMPRESASAYSICYCONTPAQ DEL SAY
    ''' </summary>
    ''' <param name="EmpresaSaySicyContpaq">OBJETO DE LA ENTIDAD EmpresaSAY_SICY CON LA INFORMACIÓN NECESARIA PARA EDITAR O
    ''' DAR DE ALTA INFORMACION</param>
    ''' <param name="Alta_Edicion">VARIABLE DEL TIPO BOOLEANO, VALOR TRUE INDICA QUE SE HARA UN INSERT, Y SU VALOR FALSE INDICA QUE SE HARA UN UPDATE</param>
    ''' <remarks></remarks>
    Public Sub AltaEdicion_Relacion_EmpresaSAySicyContpaq(ByVal EmpresaSaySicyContpaq As Entidades.EmpresaSAY_SICY, ByVal Alta_Edicion As Boolean)
        Dim objPersistencia As New OperacionesProcedimientos
        Dim consulta As String = ""

        If Alta_Edicion = True Then
            consulta = "INSERT INTO Framework.empresaSaySicyContpaq" +
                    "   (essc_sayid,essc_contribuyentesicyid" +
                    "   ,essc_razonsocial" +
                    "   ,essc_servidor" +
                    "   ,essc_empresacontpaq" +
                    "   ,essc_doctoventassicyid" +
                    "   ,essc_usuariocreoid,essc_fechacreacion)" +
                    " VALUES (" + EmpresaSaySicyContpaq.sayid.ToString +
                    "   , " + EmpresaSaySicyContpaq.contribuyentesicyid.ToString +
                    "   , '" + EmpresaSaySicyContpaq.razonsocial + "'" +
                    "   , '" + EmpresaSaySicyContpaq.servidor + "'" +
                    "   ,'" + EmpresaSaySicyContpaq.empresacontpaq + "'" +
                    "   ," + EmpresaSaySicyContpaq.doctoventassicyid.ToString +
                    "   ," + Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid.ToString +
                    "   ,(Select Getdate()))"
        Else
            consulta = "UPDATE Framework.empresaSaySicyContpaq" +
                    " SET essc_sayid = " + EmpresaSaySicyContpaq.sayid.ToString +
                    " ,essc_contribuyentesicyid = " + EmpresaSaySicyContpaq.contribuyentesicyid.ToString +
                    " ,essc_razonsocial = '" + EmpresaSaySicyContpaq.razonsocial + "'" +
                    " ,essc_servidor = '" + EmpresaSaySicyContpaq.servidor + "'" +
                    " ,essc_empresacontpaq = '" + EmpresaSaySicyContpaq.empresacontpaq + "'" +
                    " ,essc_doctoventassicyid = " + EmpresaSaySicyContpaq.doctoventassicyid.ToString +
                    " ,essc_usuariomodificoid = " + Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid.ToString +
                    " , essc_fechamodificacion = (SELECT GETDATE())" +
                    " WHERE essc_empresaid = " + EmpresaSaySicyContpaq.empresaid.ToString
        End If

        objPersistencia.EjecutaConsulta(consulta)
    End Sub

End Class
