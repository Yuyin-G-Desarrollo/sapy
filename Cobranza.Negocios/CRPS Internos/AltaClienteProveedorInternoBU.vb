Imports Cobranza.Datos
Public Class AltaClienteProveedorInternoBU
    Public Function consultaProveedores()
        Dim objConsultaProveedores As New AltaClienteProveedorInternoDA
        Dim lstProveedores As New DataTable
        lstProveedores = objConsultaProveedores.ObtenerProveedores
        Return lstProveedores
    End Function
    Public Function consultaClientes()
        Dim objConsultaClientes As New AltaClienteProveedorInternoDA
        Dim lstClientes As New DataTable
        lstClientes = objConsultaClientes.ObtenerClientes
        Return lstClientes
    End Function
    Public Function consultaNaves()
        Dim objConsultaNaves As New AltaClienteProveedorInternoDA
        Dim lstNaves As New DataTable
        lstNaves = objConsultaNaves.obtenerNaves
        Return lstNaves
    End Function
    Public Function cargaCuentasClienteInterno(ByVal objCliente As Entidades.ConfiguracionClienteProveedorInterno)
        Dim objConsulta As New AltaClienteProveedorInternoDA
        Dim lstConsulta As New DataTable
        lstConsulta = objConsulta.ConsultaCuentasBancosClienteInterno(objCliente)
        Return lstConsulta
    End Function
    Public Function InsertaProveedorClienteInterno(ByVal objInsertar As Entidades.ConfiguracionClienteProveedorInterno)
        Dim objInsertaInformacion As New AltaClienteProveedorInternoDA
        Dim dtResultado As New DataTable

        dtResultado = objInsertaInformacion.InsertaClienteProveedorInterno(objInsertar)

        If Not dtResultado Is Nothing AndAlso dtResultado.Rows.Count > 0 Then
            objInsertar.IntMsgResult = dtResultado.Rows(0).Item("mensaje")
        Else
            objInsertar.IntMsgResult = Nothing
        End If

        Return objInsertar.IntMsgResult
    End Function
End Class
