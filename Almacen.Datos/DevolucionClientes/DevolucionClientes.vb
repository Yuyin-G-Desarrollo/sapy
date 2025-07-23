Imports System.Collections.Generic
Imports System.Data.SqlClient

Public Class DevolucionClientes
    Public operaciones As New Persistencia.OperacionesProcedimientos
    Public operaciones_Sicy As New Persistencia.OperacionesProcedimientosSICY
    ''' <summary>
    ''' Método que genera la lista de parámetros para los procedimientos de Alta/Modificación de devolución
    ''' </summary>
    ''' <param name="objDevolucion">Entidad que contiene los datos de la devolución</param>
    ''' <param name="Modificacion">
    ''' True: indica que la lista es para el procedimiento de Modificación
    ''' False: indica que la lista es para el procedimiento de Alta
    ''' </param>
    ''' <returns>Lista con los parámetros enviados en el objeto Entidades.DevolucionCliente</returns>
    ''' 
    Public Function GenerarListaParametros(ByVal objDevolucion As Entidades.DevolucionCliente, ByVal Modificacion As Boolean, ByVal area As String)
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter("@tipodevolucion", objDevolucion.Tipodevolucion)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@clienteid", objDevolucion.Clienteid)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@statusid", objDevolucion.Statusid)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@resolucion", objDevolucion.Resolucion)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@procedeautoriza", objDevolucion.Procedeautoriza)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@usuariocapturaid", objDevolucion.Usuariocapturaid)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@fecharecepcion", objDevolucion.Fecharecepcion)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@colaboradorid_recibio", objDevolucion.Colaboradorid_recibio)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@cantidad_inicial", objDevolucion.Cantidad_inicial)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@unidadid", objDevolucion.Unidadid)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@cajas", objDevolucion.Cajas)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@motivoinicialalmacen_statusid", objDevolucion.Motivoinicialalmacen_statusid)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@observaciones_almacen", objDevolucion.Observaciones_almacen)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@paqueteria_proveedorid", objDevolucion.Paqueteria_proveedorid)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@tipofleteid", objDevolucion.Tipofleteid)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@costopaqueteria", objDevolucion.Costopaqueteria)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@numeroguia", objDevolucion.Numeroguia)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@modelos_say", objDevolucion.Modelos_say)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@colores_say", objDevolucion.Colores_say)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@corridas_say", objDevolucion.Corridas_say)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@almacen_actual_estatusid", objDevolucion.Almacen_actual_estatusid)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@fechalimiteaccion", objDevolucion.Fechalimiteaccion)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@pedidos", objDevolucion.Pedidos)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@diasProcesamiento", objDevolucion.DiasProcesamiento)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@observacion_facturas", objDevolucion.ObservacionFactura)
        listaParametros.Add(parametro)

        ' Si Modificacion = True indica que la lista se usará para modificar los datos de una devolución existente
        ' Por lo tanto se agrega el parámetro @devolucionclienteid el cual se usa como filtro en la cláusula Where
        ' En caso contrario, se regresa la lista hasta este punto, ya que los parámetros siguientes corresponden a cuando se hace una modificación
        If Modificacion = True Then
            parametro = New SqlParameter("@devolucionclienteid", objDevolucion.Devolucionclienteid)
            listaParametros.Add(parametro)
        Else
            Return listaParametros
        End If

        parametro = New SqlParameter("@almacen_usuariomodificaid", objDevolucion.Almacen_usuariomodificaid)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@dias_transcurridosventas", objDevolucion.Dias_transcurridosventas)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@indicarecepcion", objDevolucion.Indicarecepcion)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@motivoventas_statusid", objDevolucion.Motivoventas_statusid)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@destinoproducto", objDevolucion.Destinoproducto)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@requiereautorizacion", objDevolucion.Requiereautorizacion)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@rutaautorizacion", objDevolucion.Rutaautorizacion)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@aplicanotacredito", objDevolucion.Aplicanotacredito)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@responsabledevolucion_estatusid", objDevolucion.Responsabledevolucion_estatusid)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@observaciones_ventas", objDevolucion.Observaciones_ventas)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@ventas_usuariomodificaid", objDevolucion.Ventas_usuariomodificaid)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@observaciones_cobranza", objDevolucion.Observaciones_cobranza)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@cantidadtotal", objDevolucion.Cantidadtotal)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@total", objDevolucion.Total)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@devolucionsicyid", objDevolucion.Devolucionsicyid)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@cantidad_aplicado", objDevolucion.Cantidad_aplicado)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@cantidad_poraplicar", objDevolucion.Cantidad_poraplicar)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@SinDocumentos", objDevolucion.SinDocumentos)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@Documentos", objDevolucion.XMLDocumentos)
        listaParametros.Add(parametro)

        ' Este parámetro funciona como validador, dependiendo el área que modifique serán los campos de la consulta
        parametro = New SqlParameter("@area", area)
        listaParametros.Add(parametro)

        Return listaParametros
    End Function

    Public Function ListaMotivosDevolucion(ByVal activo, ByVal tipoMotivo, ByVal nombre, ByVal descripcion)

        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@TipoMotivo"
        parametro.Value = tipoMotivo
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Motivo"
        parametro.Value = nombre
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Descripcion"
        parametro.Value = descripcion
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Activo"
        parametro.Value = activo
        listaparametros.Add(parametro)

        ''Ejecutamos procedimiento almacenado.
        Return operaciones.EjecutarConsultaSP("Almacen.SP_DevolucionCliente_Catalogo_ListadoMotivos", listaparametros)
    End Function

    Public Function ListarMotivosDevolucion(ByVal tipoMotivo As String)

        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@TipoMotivo"
        parametro.Value = tipoMotivo
        listaparametros.Add(parametro)

        ''Ejecutamos procedimiento almacenado.
        Return operaciones.EjecutarConsultaSP("Almacen.SP_DevolucionCliente_CapturaGeneral_ListadoMotivos", listaparametros)
    End Function

    Public Function ConsultarListaUnidadesMedida()


        ''Ejecutamos procedimiento almacenado.
        Return operaciones.EjecutarConsultaSP("[Almacen].[SP_DevolucionCliente_CapturaGeneral_ConsultaUnidadMedida]", New List(Of SqlParameter))
    End Function

    Public Function ConsultarLista(nombreLista As String, Optional ByVal CEDIS As Integer = 0)

        Dim listaparametros As New List(Of SqlParameter)
        If CEDIS > 0 Then
            Dim parametro As New SqlParameter
            parametro.ParameterName = "@CEDIS"
            parametro.Value = CEDIS
            listaparametros.Add(parametro)

        End If


        Dim nombreProcedimiento As String = "[Almacen].[SP_DevolucionCliente_CapturaGeneral_" + nombreLista + "]"

        ''Ejecutamos procedimiento almacenado.
        Return operaciones.EjecutarConsultaSP(nombreProcedimiento, listaparametros)
    End Function

    Public Function ConsultarEstatus()


        ''Ejecutamos procedimiento almacenado.
        Return operaciones.EjecutarConsultaSP("[Almacen].[SP_DevolucionCliente_CapturaGeneral_ConsultaEstatus]", New List(Of SqlParameter))
    End Function

    Public Function ConsultaDevoluciones(ByVal filtros As Entidades.FiltroAdministradorDevoluciones)

        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter With {
            .ParameterName = "@TipoDevolucion",
            .Value = filtros.TipoDevolucion
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "@FechaRegistroInicio",
            .Value = filtros.FechaRegistroInicio
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "@FechaRegistroFin",
            .Value = filtros.FechaRegistroFin
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "@FechaRecepcionInicio",
            .Value = filtros.FechaRecepcionInicio
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "@FechaRecepcionFin",
            .Value = filtros.FechaRecepcionFin
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "@FechaConclusionInicio",
            .Value = filtros.FechaConclusionInicio
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "@FechaConclusionFin",
            .Value = filtros.FechaConclusionFin
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "@Estatus",
            .Value = filtros.Estatus
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "@Resolucion",
            .Value = filtros.Resolucion
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "@FolioDev",
            .Value = filtros.FolioDev
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "@PedidoSAY",
            .Value = filtros.PedidoSAY
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "@PedidoSICY",
            .Value = filtros.PedidoSICY
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "@Documentos",
            .Value = filtros.Documentos
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "@AñoDocto",
            .Value = filtros.AñoDocto
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "@IdClientes",
            .Value = filtros.IdClientes
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "@IdAgenteVentas",
            .Value = filtros.IdAgenteVent
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "@IdAtnClientes",
            .Value = filtros.IdAtnClientes
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "@Marca",
            .Value = filtros.Marca
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "@Coleccion",
            .Value = filtros.Coleccion
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "@Modelo",
            .Value = filtros.Modelo
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "@Piel",
            .Value = filtros.Piel
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "@Color",
            .Value = filtros.Color
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "@Corrida",
            .Value = filtros.Corrida
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "@Vista",
            .Value = filtros.Vista
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "@UsuarioID",
            .Value = filtros.Usuario
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "@conNotaC",
            .Value = filtros.ConNotaC
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "@CEDIS",
            .Value = filtros.CEDIS
        }
        listaParametros.Add(parametro)

        ''Ejecutamos procedimiento almacenado.
        Return operaciones.EjecutarConsultaSP("[Almacen].[SP_DevolucionCliente_AdministradorDC_ConsultaAdministrador_v2]", listaParametros)
    End Function

    Public Function ConsultarAtnClientes(idCliente As Int32)

        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@idCliente"
        parametro.Value = idCliente
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Almacen].[SP_DevolucionCliente_CapturaGeneral_ConsultaAtnClientes]", listaParametros)
    End Function
    Public Function ConsultarAgentes(idCliente As Int32)

        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@idCliente"
        parametro.Value = idCliente
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Almacen].[SP_DevolucionCliente_CapturaGeneral_ConsultarAgentes]", listaParametros)
    End Function

    Public Function ConsultarPedidosCliente(ByVal idCliente As Int32,
                                            ByVal fechaInicio As Date,
                                            ByVal fechaFin As Date)

        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@ClienteIDSay"
        parametro.Value = idCliente
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FechaInicio"
        parametro.Value = fechaInicio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FechaFin"
        parametro.Value = fechaFin
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Almacen].[SP_DevolucionCliente_CapturaGeneral_ConsultaPedidosCliente]", listaParametros)
    End Function

    Public Function ConsultarDocumentosCliente(ByVal IdDocumentos As String, ByVal AnioDocto As Int16, ByVal FacturaRemision As String, ByVal idCliente As Int32, ByVal fechaInicio As Date, ByVal fechaFin As Date,
                                               ByVal Modelo As String, ByVal Articulo As String, ByVal pedidos As String)

        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@IdDocumentos"
        parametro.Value = IdDocumentos
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@AnioDocto"
        parametro.Value = AnioDocto
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FacturaRemision"
        parametro.Value = FacturaRemision
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@ClienteIDSay"
        parametro.Value = idCliente
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FechaInicio"
        parametro.Value = fechaInicio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FechaFin"
        parametro.Value = fechaFin
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Modelo"
        parametro.Value = Modelo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Articulo"
        parametro.Value = Articulo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Pedidos"
        parametro.Value = pedidos
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Almacen].[SP_DevolucionCliente_CapturaGeneral_ConsultaDocumentosRelacionados]", listaParametros)
    End Function

    Public Sub RegistrarMotivo(ByVal tipoMotivo As String, ByVal nombre As String, ByVal descripcion As String, ByVal activo As Boolean)

        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@TipoMotivo"
        parametro.Value = tipoMotivo
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Motivo"
        parametro.Value = nombre
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Descripcion"
        parametro.Value = descripcion
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Activo"
        parametro.Value = activo
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@UsuarioCreoID"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaparametros.Add(parametro)

        ''Ejecutamos procedimiento almacenado.
        operaciones.EjecutarSentenciaSP("[Almacen].[SP_DevolucionCliente_Catalogo_InsertarMotivo]", listaparametros)
    End Sub

    Public Sub EditarMotivo(ByVal idMotivo As Int32, ByVal tipoMotivo As String, ByVal nombre As String, ByVal descripcion As String, ByVal activo As Boolean)

        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@Estatusid"
        parametro.Value = idMotivo
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@TipoMotivo"
        parametro.Value = tipoMotivo
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Motivo"
        parametro.Value = nombre
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Descripcion"
        parametro.Value = descripcion
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Activo"
        parametro.Value = activo
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@IdUsuarioModifica"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaparametros.Add(parametro)

        ''Ejecutamos procedimiento almacenado.
        operaciones.EjecutarSentenciaSP("Almacen.SP_DevolucionCliente_Catalogo_EditarMotivo", listaparametros)
    End Sub

    Public Function ListaPedidosFacturados(ByVal filtro As String)

        Dim listaparametros As New List(Of SqlParameter)


        Dim parametro As New SqlParameter
        parametro.ParameterName = "@filtro"
        parametro.Value = filtro
        listaparametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Almacen].[SP_DevolucionCliente_CapturaGeneral_ConsultaPedidosFacturados]", listaparametros)
    End Function

    Public Function ListaDocumentos(ByVal filtro As String)

        Dim listaparametros As New List(Of SqlParameter)


        Dim parametro As New SqlParameter
        parametro.ParameterName = "@Documentos"
        parametro.Value = filtro
        listaparametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Almacen].[SP_DevolucionCliente_CapturaGeneral_ConsultaDocumentos]", listaparametros)
    End Function

    Public Function ConsultarArticulos(ByVal filtro As String, ByVal numConsulta As Int16, ByVal marca As String, ByVal coleccion As String)

        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@filtro"
        parametro.Value = filtro
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@consulta"
        parametro.Value = numConsulta
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Marca"
        parametro.Value = marca
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Coleccion"
        parametro.Value = coleccion
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Almacen].[SP_DevolucionCliente_ConsultaArticulos]", listaParametros)
    End Function

    Public Function ConsultarArtiulos_ModeloSAY(ByVal TipoModelo As String, ByVal modelo As String, ByVal idCliente As Int16, ByVal tipoDevolucion As String)

        Dim listaParametros As New List(Of SqlParameter)

        listaParametros.Add(New SqlParameter With {
            .ParameterName = "@TipoModelo",
            .Value = TipoModelo
        })

        listaParametros.Add(New SqlParameter With {
            .ParameterName = "@Modelo",
            .Value = modelo
        })

        listaParametros.Add(New SqlParameter With {
            .ParameterName = "@clienteId",
            .Value = idCliente
        })

        listaParametros.Add(New SqlParameter With {
            .ParameterName = "@tipoDevolucion",
            .Value = tipoDevolucion
        })

        Return operaciones.EjecutarConsultaSP("[Almacen].[SP_DevolucionCliente_CapturaGeneral_ConsultaArticulo]", listaParametros)
    End Function

    Public Function ConsultaArticuloSeleccionado(ByVal productoEstiloID As Integer, ByVal idCliente As Integer)

        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@ProductoEstiloID"
        parametro.Value = productoEstiloID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@ClienteDevolucion_IdSAY"
        parametro.Value = idCliente
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Almacen].[SP_DevolucionCliente_ConsultaArticulo_Seleccionado]", listaParametros)
    End Function

    Public Function ConsultarTipoCodigos(ByVal idCliente As Integer)

        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@ClienteDevolucion_IdSAY"
        parametro.Value = idCliente
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Almacen].[SP_DevolucionCliente_CapturaGeneral_ConsultaTipoEtiquetaCliente]", listaParametros)
    End Function

    Public Function ConsultarEtiquetaParYuyin(ByVal etiquetaPar As String, ByVal idClienteSay As Integer, ByVal pedidos As String)
        Dim operacionesSICY As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@CodigoEtiqueta"
        parametro.Value = etiquetaPar
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@ClienteDevolucion_IdSAY"
        parametro.Value = idClienteSay
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@PedidosSAYCapturaGeneral"
        parametro.Value = pedidos
        listaParametros.Add(parametro)

        Return operacionesSICY.EjecutarConsultaSP("[Almacen].[SP_DevolucionCliente_CapturaGeneral_Consulta_EtiquetaPar]", listaParametros)
    End Function

    Public Function ConsultarEtiquetaCodEspeciales(ByVal par As String, ByVal tipoCodigo As String, ByVal codClienteSay As Integer, ByVal incrementoPorPar As Double)
        Dim operacionesSICY As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@Par"
        parametro.Value = par
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@TipoCodigo"
        parametro.Value = tipoCodigo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@ClienteDevolucion_IdSAY"
        parametro.Value = codClienteSay
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@IncrementoPorPar"
        parametro.Value = incrementoPorPar
        listaParametros.Add(parametro)

        Return operacionesSICY.EjecutarConsultaSP("[Almacen].[SP_DevolucionCliente_CapturaGeneral_Consulta_EtiquetaCodigoCliente]", listaParametros)
    End Function

    Public Function ConsultarEtiquetaParFacturacion(ByVal par As String, ByVal clienteDevolucion_SAY As Integer, ByVal documentoSAY As String)
        Dim operacionesSICY As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@Par"
        parametro.Value = par
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@ClienteDevolucion_IdSAY"
        parametro.Value = clienteDevolucion_SAY
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@DocumentosSAYCapturaGeneral"
        parametro.Value = documentoSAY
        listaParametros.Add(parametro)

        Return operacionesSICY.EjecutarConsultaSP("[Almacen].[SP_DevolucionCliente_CapturaGeneral_Consulta_EtiquetaPar_Facturacion]", listaParametros)
    End Function

    Public Function RegistrarDevolucionCliente(ByVal objDevolucion As Entidades.DevolucionCliente)

        Return operaciones.EjecutarConsultaSP("[Almacen].[SP_DevolucionCliente_RegistrarDevolucion]", GenerarListaParametros(objDevolucion, False, ""))
    End Function

    Public Sub ModificarDevolucionCliente(ByVal objDevolucion As Entidades.DevolucionCliente, ByVal area As String)

        Dim DT As New DataTable
        DT = operaciones.EjecutarConsultaSP("[Almacen].[SP_DevolucionCliente_ModificarDevolucion]", GenerarListaParametros(objDevolucion, True, area))
    End Sub

    Public Sub GuardarCodigos(ByVal xmlCodigos As String)

        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter With {
            .ParameterName = "@codigos",
            .Value = xmlCodigos
        }
        listaParametros.Add(parametro)
        operaciones.EjecutarSentenciaSP("[Almacen].[SP_DevolucionCliente_RegistrarCodigos_Devolucion]", listaParametros)

    End Sub
    Public Sub guardarFacturacionTodosCodigos(ByVal folio As Integer)
        Dim objOperaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter = Nothing

        parametro = New SqlParameter("@DevolucionID_SAY", folio)
        listaParametros.Add(parametro)

        objOperaciones.EjecutarConsultaSP("[Almacen].[SP_DevolucionCliente_CapturaGeneral_Consulta_EtiquetaPar_Facturacion_TodosCodigos_SICY]", listaParametros)
    End Sub
    Public Sub actualizaDetallesCodigosDevoluciones(ByVal folio As Integer)
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter = Nothing

        parametro = New SqlParameter("@FolioDev", folio)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@Usuario", Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@motivoDev", "")
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@DetalleID", "")
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@productoEstilo", 0)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@motivodevolucion", 0)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@borrar", 0)
        listaParametros.Add(parametro)

        objOperaciones.EjecutarConsultaSP("[Almacen].[SP_DevolucionCliente_RegistrarActualizarDetallesCodigos_Devolucion]", listaParametros)
    End Sub

    Public Sub EliminarCodigoDev(ByVal codigos As String, ByVal folioDev As Integer, ByVal usuario As Integer, ByVal motivoDev As Integer)

        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter With {
            .ParameterName = "@CodigoID",
            .Value = codigos
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "@FolioDev",
            .Value = folioDev
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "@Usuario",
            .Value = usuario
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "@MotivoDev",
            .Value = motivoDev
        }
        listaParametros.Add(parametro)

        operaciones.EjecutarSentenciaSP("[Almacen].[SP_DevolucionCliente_EliminarCodigos_Devolucion]", listaParametros)
    End Sub

    Public Sub EliminarDetallesDev(ByVal detalles As String)

        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter With {
            .ParameterName = "@Detalles",
            .Value = detalles
        }
        listaParametros.Add(parametro)

        operaciones.EjecutarSentenciaSP("[Almacen].[SP_DevolucionCliente_EliminarDetalles_Devolucion]", listaParametros)
    End Sub

    Public Function ConsultaCodigos_Devolucion(ByVal folioDev As Integer, ByVal TipoCodigos As String)

        Dim listaParametros As New List(Of SqlParameter)
        listaParametros.Add(New SqlParameter With {
            .ParameterName = "@FolioDev",
            .Value = folioDev
        })

        listaParametros.Add(New SqlParameter With {
            .ParameterName = "@TipoCodigo",
            .Value = TipoCodigos
        })

        Return operaciones.EjecutarConsultaSP("[Almacen].[SP_DevolucionCliente_ConsultaCodigos_Devolucion]", listaParametros)
    End Function

    Public Function ConsultaDetalles_Devolucion(ByVal folioDev As Integer, ByVal FoliosDev As String) As DataTable

        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter With {
            .ParameterName = "@FolioDev",
            .Value = folioDev
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "@FoliosDev",
            .Value = FoliosDev
        }
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Almacen].[SP_DevolucionCliente_ConsultaDetalles_Devolucion]", listaParametros)
    End Function

    Public Function ConsultaDetalles_PrecioCero(ByVal folioDev As Integer) As DataTable

        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter With {
            .ParameterName = "@FolioDev",
            .Value = folioDev
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "@PrecioCero",
            .Value = 1
        }
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Almacen].[SP_DevolucionCliente_ConsultaDetalles_Devolucion]", listaParametros)
    End Function

    Public Sub GuardarDetalles(ByVal detalles As String)

        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter With {
            .ParameterName = "@Articulos",
            .Value = detalles
        }
        listaParametros.Add(parametro)
        operaciones.EjecutarSentenciaSP("[Almacen].[SP_DevolucionCliente_RegistrarActualizarDetalles_Devolucion]", listaParametros)
    End Sub

    Public Function ConsultaParesPorTallas(ByVal DetalleID As Integer, ByVal productoEstiloID As Integer, ByVal opcion As Int16)

        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter With {
            .ParameterName = "@DetalleID",
            .Value = DetalleID
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "@ProductoEstiloID",
            .Value = productoEstiloID
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "@Opcion",
            .Value = opcion
        }
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Almacen].[SP_DevolucionCliente_CapturaGeneral_ConsultaParesPorTalla]", listaParametros)
    End Function

    Public Function GuardarDetalleTallas(ByVal tallas As String)

        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter With {
            .ParameterName = "@Talla",
            .Value = tallas
        }
        listaParametros.Add(parametro)
        Return operaciones.EjecutarConsultaSP("[Almacen].[SP_DevolucionCliente_CapturaGeneral_ConsultaParesPorTalla]", listaParametros)
    End Function

    Public Function ActualizarTallas(ByVal FolioDev As Integer, ByVal detalleId As Integer, ByVal detallesTallas As String)

        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter With {
            .ParameterName = "@FolioDev",
            .Value = FolioDev
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "@DetalleID",
            .Value = detalleId
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "@DetallesTallas",
            .Value = detallesTallas
        }
        listaParametros.Add(parametro)
        Return operaciones.EjecutarConsultaSP("[Almacen].[SP_DevolucionCliente_ActualizarDetallesTallas_Devolucion]", listaParametros)
    End Function

    Public Sub ActualizarRutaAutorizacion(ByVal folioDev As Integer, ByVal ruta As String)

        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter With {
            .ParameterName = "@FolioDev",
            .Value = folioDev
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "@Ruta",
            .Value = ruta
        }
        listaParametros.Add(parametro)
        operaciones.EjecutarSentenciaSP("[Almacen].[SP_DevolucionCliente_CapturaGeneral_ActualizarRutaFTP]", listaParametros)
    End Sub

    Public Sub ActualizarPrecio(ByVal Detalle As Integer, ByVal precio As Double, ByVal Usuario As Integer)

        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter With {
            .ParameterName = "@DetalleID",
            .Value = Detalle
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "@Precio",
            .Value = precio
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "@Usuario",
            .Value = Usuario
        }
        listaParametros.Add(parametro)
        operaciones.EjecutarSentenciaSP("[Almacen].[SP_DevolucionCliente_ModificarPrecioDevolucion]", listaParametros)
    End Sub

    Public Function ConsultaDatosFiltros(ByVal filtro As String, ByVal Usuario As Integer, ByVal area As String)

        Dim listaParametros As New List(Of SqlParameter)
        listaParametros.Add(New SqlParameter With {
            .ParameterName = "@TipoFiltro",
            .Value = filtro
        })

        listaParametros.Add(New SqlParameter With {
            .ParameterName = "@UsuarioID",
            .Value = Usuario
        })

        listaParametros.Add(New SqlParameter With {
            .ParameterName = "@AreaUsuario",
            .Value = area
        })

        Return operaciones.EjecutarConsultaSP("[Almacen].[SP_DevolucionCliente_AdministradorDC_Filtros]", listaParametros)
    End Function

    Public Sub CambiarEstatusDevolucion(ByVal FolioDev As Integer, ByVal estatus As Int16, Usuario As Integer, Area As String)

        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter With {
            .ParameterName = "@FolioDev",
            .Value = FolioDev
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "@Estatus",
            .Value = estatus
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "@UsuarioID",
            .Value = Usuario
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "@Area",
            .Value = Area
        }
        listaParametros.Add(parametro)

        operaciones.EjecutarSentenciaSP("[Almacen].[SP_DevolucionCliente_CapturaGeneral_ActualizarEstatus]", listaParametros)
    End Sub

    Public Function ConsultaClasificacion_Detalles()

        Return operaciones.EjecutarConsultaSP("[Almacen].[SP_DevolucionCliente_ConsultaClasificacion_Detalles]", New List(Of SqlParameter))
    End Function

    Public Function ConsultaMotivos_Calidad()
        Return operaciones_Sicy.EjecutarConsultaSP("[Almacen].[SP_DevolucionCliente_CapturaDetalles_ListadoMotivos]", New List(Of SqlParameter))
    End Function

    Public Sub ModificarClasificacion_Detalles(ByVal clasificacion As String)

        Dim listaParametros As New List(Of SqlParameter)

        listaParametros.Add(New SqlParameter With {
            .ParameterName = "@ClasificacionNave",
            .Value = clasificacion
        })

        operaciones.EjecutarSentenciaSP("[Almacen].[SP_DevolucionCliente_ModificarClasificacion_Nave_Detalles_Devolucion]", listaParametros)
    End Sub

    Public Function ConsultarDocumentosSeleccionados_CG(ByVal IdDocumentos)

        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@IdDocumentos"
        parametro.Value = IdDocumentos
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Almacen].[SP_DevolucionCliente_CapturaGeneral_ConsultaDocumentosRelacionados]", listaParametros)
    End Function

    Public Function ValidaPermisosPantallas(ByVal folioDev As Integer, ByVal pantalla As String, ByVal usuario As Integer)

        Dim listaParametros As New List(Of SqlParameter)

        listaParametros.Add(New SqlParameter With {
            .ParameterName = "@FolioDev",
            .Value = folioDev
        })

        listaParametros.Add(New SqlParameter With {
            .ParameterName = "@Pantalla",
            .Value = pantalla
        })

        listaParametros.Add(New SqlParameter With {
            .ParameterName = "@Usuario",
            .Value = usuario
        })

        Return operaciones.EjecutarConsultaSP("[Almacen].[SP_DevolucionCliente_ValidarPermisosPantallas_Devolucion]", listaParametros)
    End Function

    Public Function ConsultaMonto_Cantidad(ByVal folioDev As Integer)

        Dim listaParametros As New List(Of SqlParameter)

        listaParametros.Add(New SqlParameter With {
            .ParameterName = "@FolioDev",
            .Value = folioDev
        })

        Return operaciones.EjecutarConsultaSP("[Almacen].[SP_DevolucionCliente_CapturaGeneral_ConsultaCantidadMonto_Total]", listaParametros)
    End Function

    Public Function SolicitarNotaCredito(ByVal folioDev As Integer, ByVal UsuarioID As Integer)
        Dim listaParametros As New List(Of SqlParameter)

        listaParametros.Add(New SqlParameter With {
            .ParameterName = "@FolioDev",
            .Value = folioDev
        })

        listaParametros.Add(New SqlParameter With {
            .ParameterName = "@UsuarioSolicitaID",
            .Value = UsuarioID
        })

        Return operaciones_Sicy.EjecutarConsultaSP("[Almacen].[SP_DevolucionCliente_SolicitarNotaCredito_Devolucion]", listaParametros)
    End Function

    Public Function ConsultaBitacora(ByVal FolioDev As Integer)
        Dim opraciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        listaParametros.Add(New SqlParameter With {
            .ParameterName = "@FolioDev",
            .Value = FolioDev
        })

        Return opraciones.EjecutarConsultaSP("[Almacen].[SP_DevolucionCliente_ConsultaBitacora_Devolucion]", listaParametros)
    End Function

    Public Function CancelarDevolucion(ByVal FolioDev As Integer, ByVal MotivoCancelacion As Integer, ByVal Pares As Integer, ByVal observaciones As String, ByVal usuario As Integer)

        Dim listaParametros As New List(Of SqlParameter)

        listaParametros.Add(New SqlParameter With {
            .ParameterName = "@FolioDev",
            .Value = FolioDev
        })

        listaParametros.Add(New SqlParameter With {
            .ParameterName = "@MotivoCancelacion",
            .Value = MotivoCancelacion
        })

        listaParametros.Add(New SqlParameter With {
            .ParameterName = "@ParesCancelados",
            .Value = Pares
        })

        listaParametros.Add(New SqlParameter With {
            .ParameterName = "@Observaciones",
            .Value = observaciones
        })

        listaParametros.Add(New SqlParameter With {
            .ParameterName = "@Usuario",
            .Value = usuario
        })

        Return operaciones.EjecutarConsultaSP("[Almacen].[SP_DevolucionCliente_CancelarDevolucion]", listaParametros)
    End Function

    Public Function ConsultaNC(ByVal FolioDevSYCI As Integer)
        Dim opraciones As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        listaParametros.Add(New SqlParameter With {
            .ParameterName = "@IdDevolucionSICY",
            .Value = FolioDevSYCI
        })

        Return opraciones.EjecutarConsultaSP("[Almacen].[SP_DevolucionCliente_ConsultaNC_Devolucion_RESP_LCAD]", listaParametros)
    End Function

    Public Function ConsultarTotalesNotas(ByVal FolioDevSYCI As Integer)

        Dim opraciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        listaParametros.Add(New SqlParameter With {
            .ParameterName = "@IdDevolucionSICY",
            .Value = FolioDevSYCI
        })

        Return opraciones.EjecutarConsultaSP("[Almacen].[SP_DevolucionesClientes_ObtenertotaldenotasdeCredito]", listaParametros)
    End Function

    Public Sub MoficiarMotivoDevolucionCalidad(ByVal idDetalle As Integer, ByVal idMotivo As Integer)

        Dim listaParametros As New List(Of SqlParameter)

        listaParametros.Add(New SqlParameter With {
            .ParameterName = "@IdDetalle",
            .Value = idDetalle
        })

        listaParametros.Add(New SqlParameter With {
            .ParameterName = "@IdMotivoDevolucion",
            .Value = idMotivo
        })

        operaciones.EjecutarSentenciaSP("[Almacen].[SP_DevolucionCliente_ConsultaDetalles_ModificarDefectoPartida]", listaParametros)
    End Sub

    Public Function Consulta_Reportes_Devoluciones(ByVal xmlParametros As String, ByVal nombreSP As String)
        Dim listaParametros As New List(Of SqlParameter)
        Dim sp = "[Almacen].[SP_DevolucionCliente_Reportes_Reporte" + nombreSP + "]"

        listaParametros.Add(New SqlParameter With {
            .ParameterName = "@Parametros",
            .Value = xmlParametros
        })

        Return operaciones.EjecutarConsultaSP(sp, listaParametros)
    End Function

    Public Function Consulta_DocumentosDetalles(ByVal FolioDev As Integer)
        Dim listaParametros As New List(Of SqlParameter)

        listaParametros.Add(New SqlParameter With {
            .ParameterName = "@FolioDev",
            .Value = FolioDev
        })

        Return operaciones.EjecutarConsultaSP("[Almacen].[SP_DevolucionCliente_CapturaGeneral_ConsultaDocumentosRelacionados_Detalles]", listaParametros)
    End Function

    Public Function ConsultaDetallesDevolucion_Etiquetas(ByVal FolioDev As String)
        Dim listaParametros As New List(Of SqlParameter)

        listaParametros.Add(New SqlParameter With {
            .ParameterName = "@FolioDev",
            .Value = FolioDev
        })

        Return operaciones.EjecutarConsultaSP("[Almacen].[SP_DevolucionCliente_ConsultaDetallesDevolucion_Etiquetas]", listaParametros)
    End Function

    Public Sub ActualizarLote(ByVal Detalle As Integer, ByVal lote As Integer, ByVal Usuario As Integer)

        Dim listaParametros As New List(Of SqlParameter)

        listaParametros.Add(New SqlParameter With {
            .ParameterName = "@DetalleID",
            .Value = Detalle
        })


        listaParametros.Add(New SqlParameter With {
            .ParameterName = "@Lote",
            .Value = lote
        })

        listaParametros.Add(New SqlParameter With {
            .ParameterName = "@Usuario",
            .Value = Usuario
        })

        operaciones.EjecutarSentenciaSP("[Almacen].[SP_DevolucionCliente_ModificarLoteDetalle_Devolucion]", listaParametros)
    End Sub

    Public Function ConsultaDescuentosCliente(ByVal IdCliente As String)
        Dim listaParametros As New List(Of SqlParameter)

        listaParametros.Add(New SqlParameter With {
            .ParameterName = "@IdCliente",
            .Value = IdCliente
        })

        Return operaciones.EjecutarConsultaSP("[Almacen].[SP_DevolucionCliente_CapturaGeneral_ConsultaDescuentosCliente]", listaParametros)
    End Function

    Public Function ConsultaTipoIvaCliente(ByVal IdCliente As String)
        Dim listaParametros As New List(Of SqlParameter)

        listaParametros.Add(New SqlParameter With {
            .ParameterName = "@ClienteID",
            .Value = IdCliente
        })

        Return operaciones.EjecutarConsultaSP("[Almacen].[SP_DevolucionCliente_CapturaGeneral_ConsultaTipoIvaCliente]", listaParametros)
    End Function

    Public Function ConsultaUltimaPosicionCodigo(ByVal FolioDev As Integer)
        Dim listaParametros As New List(Of SqlParameter)

        listaParametros.Add(New SqlParameter With {
            .ParameterName = "@FolioDev",
            .Value = FolioDev
        })

        Return operaciones.EjecutarConsultaSP("[Almacen].[SP_DevolucionCliente_ConsultarUltimaPosicionCodigos]", listaParametros)
    End Function

    Public Function VerificarCodigoCliente_Andrea(ByVal ClienteID As Integer, ByVal CodigoCliente As String) As DataTable
        Dim listaParametros As New List(Of SqlParameter)

        listaParametros.Add(New SqlParameter With {
            .ParameterName = "@ClienteDevolucion_IdSAY",
            .Value = ClienteID
        })

        listaParametros.Add(New SqlParameter With {
            .ParameterName = "@Par",
            .Value = CodigoCliente
        })

        Return operaciones.EjecutarConsultaSP("[Almacen].[SP_DevolucionCliente_VerificarCodigoCliente_Andrea]", listaParametros)
    End Function


End Class
