Imports System.Collections.Generic
Imports System.Data.SqlClient

Public Class AdminCFDITrasladoDA

    Private ReadOnly objPersistencia As New Persistencia.OperacionesProcedimientos

    Public Function InsertarTraslado(FolioEmbaque As String, Usuario As Integer, Salida As Boolean) As DataTable

        Dim listaParametros As New List(Of SqlParameter) From {
            New SqlParameter With {
                .ParameterName = "FolioVerificacionID",
                .Value = FolioEmbaque
            },
            New SqlParameter With {
                .ParameterName = "Usuario",
                .Value = Usuario
            },
            New SqlParameter With {
                .ParameterName = "TipoSalida",
                .Value = Salida
            }
        }

        Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_VerificacionSalidas_InsertarCartaPorte]", listaParametros)

    End Function

    Public Function ConsultaDocumentosTraslados(FechaInicio As String,
                                                FechaFin As String,
                                                Estatus As String,
                                                Emisor As String,
                                                Cliente As String,
                                                Folio As String,
                                                Nave As String,
                                                Salida As String,
                                                Tipo As Integer,
                                                Cedis As Short) As DataTable

        Dim listaParametros As New List(Of SqlParameter) From {
            New SqlParameter With {
                .ParameterName = "FechaInicio",
                .Value = FechaInicio
            },
            New SqlParameter With {
                .ParameterName = "FechaFin",
                .Value = FechaFin
            },
            New SqlParameter With {
                .ParameterName = "ClientesIDSay",
                .Value = Cliente
            },
            New SqlParameter With {
                .ParameterName = "EstatusIDSay",
                .Value = Estatus
            },
            New SqlParameter With {
                .ParameterName = "EmisoresIDSay",
                .Value = Emisor
            },
            New SqlParameter With {
                .ParameterName = "FoliosIDSay",
                .Value = Folio
            },
            New SqlParameter With {
                .ParameterName = "NavesIDSay",
                .Value = Nave
            },
            New SqlParameter With {
                .ParameterName = "Salida",
                .Value = Salida
            },
            New SqlParameter With {
                .ParameterName = "Tipo",
                .Value = Tipo
            },
            New SqlParameter With {
                .ParameterName = "Cedis",
                .Value = Cedis
            }
        }

        Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_CartaPorte_ConsultaAdministradorTraslados]", listaParametros)

    End Function

    Public Function ConsultaEncabezadoTraslado(FolioEmbaque As String) As DataTable

        Dim listaParametros As New List(Of SqlParameter) From {
            New SqlParameter With {
                .ParameterName = "FolioEmbarque",
                .Value = FolioEmbaque
            }
        }

        Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_CartaPorte_ConsultaEncabezadoTraslado]", listaParametros)

    End Function

    Public Function ConsultaDetallesTraslado(FolioEmbaque As String) As DataTable

        Dim listaParametros As New List(Of SqlParameter) From {
            New SqlParameter With {
                .ParameterName = "FolioEmbarque",
                .Value = FolioEmbaque
            }
        }

        Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_CartaPorte_ConsultaDetalleTraslado]", listaParametros)

    End Function

    Public Function ConsultaNave(Colaborador As Integer) As DataTable

        Dim listaParametros As New List(Of SqlParameter) From {
            New SqlParameter With {
                .ParameterName = "Colaborador",
                .Value = Colaborador
            }
        }

        Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_CartaPorte_ObtenerNave]", listaParametros)

    End Function

End Class
