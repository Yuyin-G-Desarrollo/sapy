Imports System.Data.SqlClient
Public Class ReporteEnfoqueVentasDA

    Public Function MostrarModelosEnfoqueVentas() As DataTable
        Dim listaParametros As New List(Of SqlParameter)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim DtResultado As DataTable

        DtResultado = objPersistencia.EjecutarConsultaSP("[Ventas].[SP_EnfoqueVentas_SeleccionModelos]", listaParametros)

        Return DtResultado

    End Function


    Public Function GuardarInformacion(ByVal ProductoId As Integer, ByVal ColeccionId As Integer, ByVal Modelo As String, ByVal PielId As Integer, ByVal ColorId As Integer, ByVal UsuarioId As Integer) As DataTable

        Dim objPersistencia As New Persistencia.OperacionesProcedimientos

        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "@ProductoId"
        parametro.Value = ProductoId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@ColorID"
        parametro.Value = ColorId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@PielId"
        parametro.Value = PielId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@ColeccionId"
        parametro.Value = ColeccionId
        listaParametros.Add(parametro)


        parametro = New SqlParameter
        parametro.ParameterName = "@ModeloSAY"
        parametro.Value = Modelo
        listaParametros.Add(parametro)


        parametro = New SqlParameter
        parametro.ParameterName = "@UsuarioID"
        parametro.Value = UsuarioId
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_EnfoqueVentas_GuardarModelos]", listaParametros)

    End Function


    Public Sub BorrarInformacion()
        Dim listaParametros As New List(Of SqlParameter)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos


        objPersistencia.EjecutarConsultaSP("[Ventas].[SP_EnfoqueVentas_BorrarInformacion]", listaParametros)



    End Sub


End Class
