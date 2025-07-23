Public Class ClientesEspecialesDA
    Public Function TablaCombo() As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim obj As New Persistencia.OperacionesProcedimientosSICY
        Dim consultas As String
        If operaciones.Servidor = obj.Servidor Then
            consultas = "SELECT IdCadena,nombre FROM [" + obj.NombreDB + "].dbo.cadenas where idCadena not in (select cesp_idCadena from programacion.clientesespeciales ) AND Activo='S' order by 2"
        Else
            consultas = "SELECT IdCadena,nombre FROM [" + obj.Servidor + "].[" + obj.NombreDB + "].dbo.cadenas where idCadena not in (select cesp_idCadena from programacion.clientesespeciales ) AND Activo='S' order by 2"
        End If
        Return operaciones.EjecutaConsulta(consultas)
    End Function
    Public Function Tabla() As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim obj As New Persistencia.OperacionesProcedimientosSICY
        Dim consultas As String
        If operaciones.Servidor = obj.Servidor Then
            consultas = "select cesp_cespID ID_,Nombre,cesp_orden Orden from Programacion.clientesEspeciales inner JOIN [" + obj.NombreDB + "].dbo.Cadenas on IdCadena = cesp_idCadena order by cesp_orden"
        Else
            consultas = "select cesp_cespID ID_,Nombre,cesp_orden Orden from Programacion.clientesEspeciales inner JOIN [" + obj.Servidor + "].[" + obj.NombreDB + "].dbo.Cadenas on IdCadena = cesp_idCadena order by cesp_orden"
        End If
        Return operaciones.EjecutaConsulta(consultas)
    End Function
    Public Sub Agregar(idCadena As Int32, orden As Int32)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim Sql As String =  "INSERT INTO Programacion.ClientesEspeciales (cesp_idCadena,cesp_orden) VALUES (" & idCadena & "," & orden & ")"
        operaciones.EjecutaSentencia(Sql)
    End Sub
    Public Sub Eliminar(cesp_cespID As Int32)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim Sql As String = "DELETE FROM Programacion.ClientesEspeciales WHERE cesp_cespId=" & cesp_cespID
        operaciones.EjecutaSentencia(Sql)
    End Sub
    Public Sub Actualizar(ByVal id_ As Integer, ByVal cesp_cespId As Integer)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim sql As String = "UPDATE programacion.clientesEspeciales set cesp_orden=" & cesp_cespId.ToString & " where cesp_cespID=" & id_.ToString
        operaciones.EjecutaSentencia(sql)
    End Sub

    Public Function datosClietesEspecialesNoConfiguradosSimulacion(ByVal idSimulacion As Int32) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = ""
        cadena = <cadena>
    SELECT
	CAST(0 AS bit) SEL,
	ce.cesp_cespID,
	cl.clie_idsicy,
	ce.cesp_orden,
	cl.clie_clienteid,
	cl.clie_nombregenerico
    FROM Cliente.Cliente cl
    LEFT JOIN Programacion.ClientesEspeciales ce ON cl.clie_idsicy = ce.cesp_idCadena	
    WHERE cl.clie_idsicy NOT IN (SELECT	cesp_idCadena
    FROM Programacion.SimulacionClientesEspeciales WHERE cesp_simuIacionMaestroID = <%= idSimulacion.ToString %>)
    ORDER BY ce.cesp_orden, cl.clie_nombregenerico
               </cadena>.Value
        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Function datosClientesEspecialesConfiguradosSimulacion(ByVal idSimulacion As Int32) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = ""
        cadena = <cadena>
                SELECT
	                CAST(0 AS bit) SEL,
	                cesp_simClientesEspecialesID,
	                cesp_simuIacionMaestroID,
	                cl.clie_idsicy,
	                cesp_orden,
	                cl.clie_clienteid,
	                cl.clie_nombregenerico
                FROM Programacion.SimulacionClientesEspeciales ces
                JOIN Cliente.Cliente cl
	                ON ces.cesp_idCadena = cl.clie_idsicy
                WHERE cesp_simuIacionMaestroID = <%= idSimulacion.ToString %>
                ORDER BY ces.cesp_orden</cadena>.Value
        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Sub insertarClienteEspecialSimulacion(ByVal idSimulacion As Int32, ByVal idCadema As String, ByVal orden As Int32)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = ""
        cadena = "INSERT INTO Programacion.SimulacionClientesEspeciales (cesp_simuIacionMaestroID, cesp_idCadena, cesp_orden) " & _
        " VALUES('" + idSimulacion.ToString + "', '" + idCadema.Trim + "', '" + orden.ToString + "')"
        operacion.EjecutaSentencia(cadena)
    End Sub

    Public Sub eliminarSimulacionClienteEspecial(ByVal idClienteEspecialSim As Int32)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = ""
        cadena = "DELETE FROM Programacion.SimulacionClientesEspeciales WHERE cesp_simClientesEspecialesID = " + idClienteEspecialSim.ToString
        operacion.EjecutaSentencia(cadena)
    End Sub

    Public Sub editarOrdenClienteEspecialSim(ByVal orden As Int32, ByVal idClienteEspecialSim As Int32)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = ""
        cadena = " UPDATE Programacion.SimulacionClientesEspeciales SET cesp_orden = " + orden.ToString & _
                 " WHERE cesp_simClientesEspecialesID = " + idClienteEspecialSim.ToString
        operacion.EjecutaSentencia(cadena)
    End Sub

End Class
