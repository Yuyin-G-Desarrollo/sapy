Imports System.Data.SqlClient
Public Class MarcasDA

    Public Function MostrarMarcas(ByVal Activo As Boolean) As DataTable
        Dim Operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "SELECT" +
                                " marc_marcaid," +
                                " marc_codigo," +
                                " marc_descripcion," +
                                " marc_activo," +
                                " marc_codigosicy," +
                                " marc_esCliente" +
                                " FROM Programacion.Marcas" +
                        " WHERE marc_activo = '" + Activo.ToString + "'" +
                        " ORDER BY marc_descripcion"
        Return Operacion.EjecutaConsulta(consulta)
    End Function

    Public Function TraerIdMarcaMAsAlto() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Return operacion.EjecutaConsulta("SELECT MAX(marc_marcaid) AS 'MaximoID' FROM Programacion.Marcas")
    End Function

    Public Function VerCodigosDisponibles() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Return operacion.EjecutaConsulta("Select marc_codigo from Programacion.Marcas where marc_activo='False' and marc_codigo not in (Select marc_codigo from  Programacion.Marcas where marc_activo='True')")
    End Function

    Public Sub RegistrarNuevaMarca(ByVal EnMarca As Entidades.Marcas, ByVal usuario As Int32)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)

        Dim DatoActivo As String = String.Empty

        If (EnMarca.PActivo = True) Then
            DatoActivo = "True"
        ElseIf (EnMarca.PActivo = False) Then
            DatoActivo = "False"
        End If

        Dim ParametroParaLista As New SqlParameter
        ParametroParaLista.ParameterName = "descripcion"
        ParametroParaLista.Value = EnMarca.PDescripcion
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "codigo"
        ParametroParaLista.Value = EnMarca.PCodigo
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "activo"
        ParametroParaLista.Value = DatoActivo
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "usuario"
        ParametroParaLista.Value = usuario
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "codigoSicy"
        ParametroParaLista.Value = EnMarca.PSicyCodigo
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "cliente"
        ParametroParaLista.Value = EnMarca.PClienteMarca
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "comercializadora"
        ParametroParaLista.Value = EnMarca.PComercializadora
        ListaParametros.Add(ParametroParaLista)

        operacion.EjecutarSentenciaSP("Programacion.SP_altas_Marcas", ListaParametros)

    End Sub

    Public Function ValidarRepetidos(ByVal Codigo As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Return operacion.EjecutaConsulta("Select marc_codigo from Programacion.Marcas where marc_codigo='" + Codigo + "' and marc_activo='true'")
    End Function

    Public Function ContadorFilas() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Return operacion.EjecutaConsulta("SELECT * FROM Programacion.Marcas;")
    End Function


    Public Sub EditarMarca(ByVal EnMarca As Entidades.Marcas, ByVal usuario As Int32)

        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)

        Dim ParametroParaLista As New SqlParameter
        ParametroParaLista.ParameterName = "idMarca"
        ParametroParaLista.Value = EnMarca.PMarcaId
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "descripcion"
        ParametroParaLista.Value = EnMarca.PDescripcion
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "Activo"
        ParametroParaLista.Value = EnMarca.PActivo
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "usuarioModifico"
        ParametroParaLista.Value = usuario
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "codigoSicy"
        ParametroParaLista.Value = EnMarca.PSicyCodigo
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "escliente"
        ParametroParaLista.Value = EnMarca.PClienteMarca
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "comercializadora"
        ParametroParaLista.Value = EnMarca.PComercializadora
        ListaParametros.Add(ParametroParaLista)

        operacion.EjecutarSentenciaSP("Programacion.SP_Editar_Marca", ListaParametros)

    End Sub

    Public Function ComboMarcas() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "Select marc_marcaid," +
                                " marc_codigo as 'Código'," +
                                " marc_descripcion as 'Descripción'," +
                                " marc_escliente, marc_codigosicy" +
                                " from Programacion.Marcas" +
                                " where marc_activo='True'"
        Return operacion.EjecutaConsulta(cadena)
    End Function


    Public Function VerMarcas() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Return operacion.EjecutaConsulta("Select m.marc_marcaid, m.marc_descripcion from Programacion.Marcas as m")
    End Function

    Public Function verCodigoRegistrado(ByVal idMarca As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Return operacion.EjecutaConsulta("SELECT marc_codigo, marc_descripcion, marc_codigosicy, marc_esCliente FROM Programacion.Marcas where marc_marcaid =" + idMarca + "")
    End Function


    Public Function verMarcasRapido(ByVal descripcion As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "Select marc_marcaid, marc_codigo, marc_descripcion, marc_esCliente as 'Cliente', marc_codigosicy as 'Sicy' from Programacion.Marcas where marc_activo='True'"
        If (descripcion <> "") Then
            cadena += " and marc_descripcion like '%" + descripcion + "%' "
        End If
        cadena += "ORDER BY marc_codigo"
        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Function validarInactivarMarca(ByVal idmarca As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "SELECT prod_codigo, prod_descripcion FROM Programacion.Productos WHERE prod_marcaid =" + idmarca + " and prod_activo = 1"
        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Function verMarcasYuyin() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "SELECT marc_marcaid, marc_codigosicy, marc_descripcion" +
            " FROM Programacion.Marcas" +
            " WHERE marc_esCliente = 0" +
            " AND marc_codigosicy <> '' AND marc_activo = 1 ORDER BY marc_descripcion"
        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Function MostrarMarcasWeb(ByVal Cliente As Boolean) As DataTable
        Dim Operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = ""
        consulta += " SELECT marc_marcaid, marc_codigo, marc_descripcion, marc_activo, marc_codigosicy, marc_esCliente "
        consulta += " FROM Programacion.Marcas"
        consulta += " where marc_esCliente='FALSE'"
        consulta += " AND marc_activo='" + Cliente.ToString + "'"


        Return Operacion.EjecutaConsulta(consulta)
    End Function

    Public Function ModelosLlenarComboMarcas(ByVal idcedis As Integer)
        Dim objpersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter("@Cedis", idcedis)
        listaParametros.Add(parametro)
        Return objpersistencia.EjecutarConsultaSP("[Programacion].[SP_Modelos_LlenarComboMarcas]", listaParametros)
    End Function

    Public Function verMarcasCedis(ByVal idcedis As Integer) As DataTable
        Dim objpersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter("@Cedis", idcedis)
        listaParametros.Add(parametro)
        Return objpersistencia.EjecutarConsultaSP("[Programacion].[SP_ModelosConsultarMarcasedis]", listaParametros)
    End Function

    Public Function verMarcasCedis(ByVal descripcion As String, ByVal idcedis As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "Select marc_marcaid, marc_codigo, marc_descripcion, marc_esCliente as 'Cliente', marc_codigosicy as 'Sicy', marc_esLicencia from Programacion.Marcas where marc_activo='True'"
        If (descripcion <> "") Then
            cadena += " and marc_descripcion like '%" + descripcion + "%' "
        End If

        cadena += " AND marc_comercializadoraid = " + CStr(idcedis) + " ORDER BY marc_codigo"
        Return operacion.EjecutaConsulta(cadena)
    End Function

End Class
