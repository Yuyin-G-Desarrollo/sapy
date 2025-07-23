Imports System.Data.SqlClient
Public Class PielesMuestraDA

    Public Function VerPielesMuestra(ByVal Descripcion As String, ByVal codigo As String, ByVal activo As Boolean) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "Select plmu_pielmuestraid, plmu_codigo, plmu_descripcion, plmu_activo from Programacion.PielMuestras where plmu_descripcion like '%" + Descripcion + "%' and plmu_activo='" + activo.ToString + "'"
        If (codigo <> "") Then
            cadena += " and plmu_codigo like '%" + codigo + "%'"
        End If
        cadena += " ORDER BY plmu_descripcion"
        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Function VerIdMaximoPielMuestra() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Return operacion.EjecutaConsulta("Select max(plmu_pielmuestraid) as 'idMax' from Programacion.PielMuestras")
    End Function

    Public Function VerCantidadFilas() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Return operacion.EjecutaConsulta("Select * from Programacion.PielMuestras")
    End Function

    Public Sub RegistrarPielMuestra(ByVal EntidadPielMuestra As Entidades.PielesMuestra, ByVal usuario As Int32)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)

        Dim ParametroParaLista As New SqlParameter
        ParametroParaLista.ParameterName = "descripcion"
        ParametroParaLista.Value = EntidadPielMuestra.PiMuDescripcion
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "codigo"
        ParametroParaLista.Value = EntidadPielMuestra.PiMuCodigo
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "activo"
        ParametroParaLista.Value = EntidadPielMuestra.PiMuActivo
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "usuario"
        ParametroParaLista.Value = usuario
        ListaParametros.Add(ParametroParaLista)

        operacion.EjecutarSentenciaSP("Programacion.SP_Alta_PielMuestra", ListaParametros)
    End Sub

    Public Sub EditarPielMuestra(ByVal EntidadPielMuestra As Entidades.PielesMuestra, ByVal usuario As Int32)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)

        Dim ParametroParaLista As New SqlParameter
        ParametroParaLista.ParameterName = "descripcion"
        ParametroParaLista.Value = EntidadPielMuestra.PiMuDescripcion
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "activo"
        ParametroParaLista.Value = EntidadPielMuestra.PiMuActivo
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "usuario"
        ParametroParaLista.Value = usuario
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "idPielMuestra"
        ParametroParaLista.Value = EntidadPielMuestra.PiMUId
        ListaParametros.Add(ParametroParaLista)
        operacion.EjecutarSentenciaSP("Programacion.SP_Editar_PielMuestra", ListaParametros)
    End Sub

    Public Function verComboCortes() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Return operacion.EjecutaConsulta("select plmu_pielmuestraid, plmu_codigo, plmu_descripcion" +
                                         " from Programacion.PielMuestras where plmu_activo =1 ORDER BY plmu_descripcion")
    End Function

    Public Function validaExistenModelos(ByVal idPielMuestra As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "SELECT a.prod_codigo, a.prod_descripcion FROM Programacion.Productos a" +
                                " INNER JOIN Programacion.ProductoEstilo b ON a.prod_productoid = b.pres_productoid" +
                                " INNER JOIN Programacion.EstilosProducto c ON b.pres_estiloid = c.espr_estiloproductoid" +
                                " WHERE a.prod_activo = 1 AND b.pres_activo = 1" +
                                " AND c.espr_pielmuestraid = " + idPielMuestra +
                                " GROUP BY	a.prod_codigo, a.prod_descripcion "
        Return operaciones.EjecutaConsulta(cadena)
    End Function

    Public Function verCortesRegistroRapido(ByVal idsCortes As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "SELECT" +
                                " plmu_pielmuestraid," +
                                " plmu_codigo," +
                                " plmu_descripcion" +
                                " FROM Programacion.PielMuestras" +
                        " WHERE plmu_activo = 'True'" +
                        " AND plmu_pielmuestraid NOT IN (" + idsCortes + ")"
        Return operacion.EjecutaConsulta(cadena)
    End Function


End Class
