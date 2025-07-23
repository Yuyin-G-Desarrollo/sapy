Imports System.Collections.Generic
Imports System.Data.SqlClient

Public Class MovimientosInvenario_DA

    Public Function ConsultaCodigos(ByVal codigos As String)
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)

        listaParametros.Add(New SqlParameter With {
            .ParameterName = "@Codigos",
            .Value = codigos
        })

        Return operaciones.EjecutarConsultaSP("[Almacen].[SP_MovimientosAlmacen_ConsultaCodigos]", listaParametros)
    End Function

    Public Function ConsultaTipoMovimientos() As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos

        ConsultaTipoMovimientos = operaciones.EjecutarConsultaSP("[Almacen].[SP_MovimientosAlmacen_ConsultaTipoMovimientos]", New List(Of SqlParameter))
        Return ConsultaTipoMovimientos
    End Function

    Public Sub RegistrarMovimientoInv(ByVal movimiento As Int16, ByVal pares As String, ByVal FoliosDev As String, ByVal DestinoID As Int32)
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)

        listaParametros.Add(New SqlParameter With {
            .ParameterName = "@Movimiento_EstatusID",
            .Value = movimiento
        })

        listaParametros.Add(New SqlParameter With {
            .ParameterName = "@ParesID",
            .Value = pares
        })

        listaParametros.Add(New SqlParameter With {
            .ParameterName = "@FoliosDev",
            .Value = FoliosDev
        })

        listaParametros.Add(New SqlParameter With {
            .ParameterName = "@DestinoDev",
            .Value = DestinoID
        })

        operaciones.EjecutarSentenciaSP("[Almacen].[SP_MovimientosAlmacen_RegistrarMovimiento]", listaParametros)
    End Sub

    Public Function ConsultaInfoDevolucion(ByVal FolioDev As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        listaParametros.Add(New SqlParameter With {
            .ParameterName = "@FolioDev",
            .Value = FolioDev
        })

        ConsultaInfoDevolucion = operaciones.EjecutarConsultaSP("[Almacen].[SP_MovimientosAlmacen_ConsultaInfoDevolucion]", listaParametros)
        Return ConsultaInfoDevolucion
    End Function
End Class
