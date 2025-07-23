Imports System.Data.SqlClient

Public Class TrasladosDA
    Private ReadOnly objPersistencia As New Persistencia.OperacionesProcedimientos

    Public Function GenerarInformacionTimbrado(folioEmbarque As Integer, Emisor As Integer, Salida As Boolean) As DataTable
        Dim listaParametros As New List(Of SqlParameter) From {
            New SqlParameter With {
                .ParameterName = "@FolioEmbarque",
                .Value = folioEmbarque
            },
            New SqlParameter With {
                .ParameterName = "@RazonEmisor",
                .Value = Emisor
            },
            New SqlParameter With {
                .ParameterName = "@TipoSalida",
                .Value = Salida
            }
        }

        'Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_CartaPorte_Timbrado_InsertarInformacion]", listaParametros)
        Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_CartaPorte_Timbrado_InsertarInformacion4_0]", listaParametros)
    End Function

    Public Function ObtenerEmpresaFactura(ByVal DocumentoID As Integer) As DataTable
        Dim listaParametros As New List(Of SqlParameter) From {
            New SqlParameter With {
                .ParameterName = "@DocumentoID",
                .Value = DocumentoID
            }
         }

        Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_CartaPorte_ObtenerEmpresaIDFactura]", listaParametros)

    End Function

    Public Function ActualizarUsuarioTimbro(UsuarioID As Integer, DocumentoId As Integer) As DataTable
        Dim listaParametros As New List(Of SqlParameter) From {
            New SqlParameter With {
                .ParameterName = "@UsuarioID",
                .Value = UsuarioID
            },
            New SqlParameter With {
                .ParameterName = "@DocumentoId",
                .Value = DocumentoId
            }
         }

        Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_VerificacionSalidas_ActualizarUsuarioTimbro]", listaParametros)

    End Function

    Public Sub InsertarError(folioEmbarqueId As Integer, tipo As String, mensaje As String)
        Dim listaParametros As New List(Of SqlParameter) From {
            New SqlParameter With {
                .ParameterName = "@folioEmbarqueId",
                .Value = folioEmbarqueId
            },
            New SqlParameter With {
                .ParameterName = "@tipo",
                .Value = tipo
            },
            New SqlParameter With {
                .ParameterName = "@mensaje",
                .Value = mensaje
            }
         }

        objPersistencia.EjecutarConsultaSP("[Almacen].[SP_CartaPorte_InsertarError]", listaParametros)

    End Sub

End Class
