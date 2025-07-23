Imports System.Collections.Generic
Imports System.Data.SqlClient

Public Class InventarioCiclicoDA

    ''' <summary>
    ''' RECUPERA EL ID DEL CLIENTE Y EL NOMBRE COMPLETO DE LA TABLA CADENAS 
    ''' </summary>
    ''' <param name="IdCliente">ID DEL CLIENTE A RECUPERAR LA INFORMACION</param>
    ''' <returns>RESULTADO DE LA CONSULTA DEL ID DEL CLIENTE Y NOMBRE DEL CLIENTE</returns>
    ''' <remarks></remarks>
    Public Function RecuperarNombreCliente(ByVal IdCliente As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String = ""
        consulta = "Select cast(vc.IdCadena as varchar) as 'Identificador','CLIENTE' as 'Etiqueta','CADENAS' AS 'Tabla', vc.nombre as 'Descripción' from Cadenas vc" +
            " where vc.IdCadena in (" + IdCliente + ") order by vc.nombre"
        Return objPersistencia.EjecutaConsulta(consulta)
    End Function

    ''' <summary>
    ''' RECUPERA EL ID DEL AGENTE Y NOMBRE DE LA TABLA "AGENTES"
    ''' </summary>
    ''' <param name="IdAgente"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function RecuperarNombreAgente(ByVal IdAgente As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String = ""
        consulta = "select cast (ag.IdAgente as varchar) as 'Identificador', 'AGENTE' AS 'Etiqueta', 'AGENTES' AS 'Tabla', ag.Nombre as 'Descripción' from Agentes ag" +
            " where AG.IdAgente in (" + IdAgente + ") order by ag.Nombre"
        Return objPersistencia.EjecutaConsulta(consulta)
    End Function

    ''' <summary>
    ''' RECUPERA LOS NOMBRES DE LAS TIENDAS CUYO ID SE ENCUENTRE EN CIERTA CADENA DESDE LA TABLA "DISTRIBUCIONES" DE LA BASE DE DATOS "YUYIN"
    ''' </summary>
    ''' <param name="IdTienda">CADENA CON LOS ID DE LAS TIENDAS A BUSCAR</param>
    ''' <returns>CONSULTA CON EL ID DE LA TIENDA, Y LA TIENDA</returns>
    ''' <remarks></remarks>
    Public Function RecuperarNombreTienda(ByVal IdTienda As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String = ""
        If IdTienda.Contains("--") Then
            IdTienda = "0"
        End If
        consulta = "select cast(vcd.IdDistribucion as varchar) as 'Identificador', 'TIENDA' AS 'Etiqueta', 'DISTRIBUCIONES' AS 'Tabla', UPPER(vcd.nombre) as 'Descripción'  from Distribuciones vcd" +
            " where vcd.IdDistribucion IN (" + IdTienda + ") order by vcd.nombre "
        Return objPersistencia.EjecutaConsulta(consulta)
    End Function

    ''' <summary>
    ''' RECUPERA LOS NOMBRE DE PRODUCTOS CUYO IDENTIFICADOR SE ENCUENTRE DENTRO DE UNA CADENA DESDE LA TABLA "VESTILOS"
    ''' </summary>
    ''' <param name="IdProducto">CADENA CON LOS ID´S DE LOS PRODUCTOS A BUSCAR</param>
    ''' <returns>CONSULTA CON EL ID DE EL PRODUCTO, ETIQUETA, TABLA Y SU DESCRIPCION</returns>
    ''' <remarks></remarks>
    Public Function RecuperarNombreProducto(ByVal IdProducto As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String = ""
        consulta = "select ve.IdCodigo as 'Identificador', 'PRODUCTO' AS 'Etiqueta', 'VESTILOS' AS 'Tabla', VE.descripcion as 'Descripción'" +
            " from vEstilos ve where VE.IdCodigo in (" + IdProducto + ") order by VE.descripcion"
        Return objPersistencia.EjecutaConsulta(consulta)
    End Function

    ''' <summary>
    ''' RECURA LOS NOMBRES DE BAHIAS CUYOS ID SE ENCUENTREN EN UNA CADENA
    ''' </summary>
    ''' <param name="IdBahia">CADENA CON LOS ID´S DE LAS BAHIAS A BUSCAR NOMBRE</param>
    ''' <returns>TABLA CON EL ID DE BAHIA Y SU NOMBRE CORRESPONDIENTE PRINCIPALMENTE Y CAMPOS PUESTOS POR DEFAULT COMO LO SON "ETIQUETA" Y "TABLA"</returns>
    ''' <remarks></remarks>
    Public Function RecuperarNombreBahia(ByVal IdBahia As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim Consulta As String = ""
        Consulta = "SELECT aba.bahi_bahiaid as 'Identificador', 'UBICACIÓN' AS 'Etiqueta', ' ALMACEN.BAHIA' AS 'Tabla', LEFT(aba.bahi_bahiaid, CHARINDEX('-', aba.bahi_bahiaid) - 1) AS 'Descripción'" +
            " FROM Almacen.Bahia aba WHERE bahi_bahiaid in (" + IdBahia + ") order by aba.bahi_bahiaid"
        Return objPersistencia.EjecutaConsulta(Consulta)
    End Function

    ''' <summary>
    ''' RECUPERA LA DESCRIPCION DE UNA CORRIDA DEACUERDO A LOS ID´S ENCONTRADOS EN UNA CADENA</summary>
    ''' <param name="IdCorrida">CADENA CON LOS IDS DE CORRIDA A BUSCAR</param>
    ''' <returns>TABLA CON EL ID DE CORRIDA Y LA DESCRIPCIÓN</returns>
    ''' <remarks></remarks>
    Public Function RecuperarDescripcionCorrida(ByVal IdCorrida As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim Consulta As String = ""
        Consulta = "SELECT ta.IdTalla as 'Identificador', 'CORRIDAS' AS 'Etiqueta', 'TALLAS' AS 'Tabla', ta.Talla AS 'Descripción'" +
            " FROM tallas ta where IdTalla in (" + IdCorrida + ") ORDER BY ta.Talla"
        Return objPersistencia.EjecutaConsulta(Consulta)
    End Function

    ''' <summary>
    ''' RECUPERA LOS NOMBRES DE MARCAS CUYOS IDS SEAN ENCONTRADOS EN UNA CADENA
    ''' </summary>
    ''' <param name="IdMarca">CADENA CON LOS IDS DE LAS MARCAS A ENCONTRAR</param>
    ''' <returns>TABLA CON LOS IDS DE MARCAS Y SUS DESCRIPCIONES CORRESPONDIENTES</returns>
    ''' <remarks></remarks>
    Public Function RecuperarMarca(ByVal IdMarca As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim Consulta As String = ""
        Consulta = "select 'ID' AS 'Identificador', 'MARCA' AS 'Etiqueta', 'VESTILOS' AS 'Tabla', ves.Marca AS 'Descripción'" +
            "  from vEstilos ves where ves.IdCodigo in (" + IdMarca + ") GROUP BY ves.Marca ORDER BY ves.Marca"
        Return objPersistencia.EjecutaConsulta(Consulta)
    End Function

    ''' <summary>
    ''' RECUPERA LAS COLECCIONES CUYOS IDS SE ENCUENTREN EN UNA CADENA
    ''' </summary>
    ''' <param name="IdColeccion">CADENA CON LOS IDS DE COLECCIONES A BUSCAR</param>
    ''' <returns>TABLA CON LOS IDS Y DESCRIPCION DE COLECCIONES RESPECTIVAMENTE</returns>
    ''' <remarks></remarks>
    Public Function RecuperarColeccion(ByVal IdColeccion As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim Consulta As String = ""
        Consulta = "select '0' AS 'Identificador', 'COLECCIÓN' AS 'Etiqueta', 'VESTILOS' AS 'Tabla', ves.Coleccion AS 'Descripción'" +
            "  from vEstilos ves  where ves.IdCodigo in (" + IdColeccion + ") GROUP BY ves.Coleccion ORDER BY ves.Coleccion "
        Return objPersistencia.EjecutaConsulta(Consulta)
    End Function

    ''' <summary>
    ''' RECUPERA LOS PEDIDOS CUYOS IDS SE ENCUENTREN EN UNA CADENA
    ''' </summary>
    ''' <param name="IdPedido">CADENA CON LOS IDS DE LOS PEDIDOS</param>
    ''' <returns>TABLA CON LOS RESULTADOS</returns>
    ''' <remarks></remarks>
    Public Function RecuperarPedido(ByVal IdPedido As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY

        Dim Consulta As String = ""
        Consulta = "Select cast(IdPedido as varchar) as 'Identificador', 'PEDIDO' AS 'Etiqueta', 'PEDIDOS' AS 'Tabla',  cast(IdPedido as varchar) AS 'Descripción'" +
            " from Pedidos where IdPedido in (" + IdPedido + ") "
        Return objPersistencia.EjecutaConsulta(Consulta)
    End Function

    ''' <summary>
    ''' RECUPERA LA LISTA DE LOS COLABORADORES QUE PERTENECEN AL DEPARTAMENTO DEL ALMACEN
    ''' </summary>
    ''' <returns>DEVUELVE LA LISTA DE LOS OPERADORES DE ALMACEN</returns>
    ''' <remarks></remarks>
    Public Function ListaOperadores() As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        'Dim consulta As String = ""
        'consulta = "SELECT A.codr_colaboradorid AS 'Parámetro' " +
        '" , CAST (0 AS bit) AS ' ' " +
        '" , CAST(A.codr_nombre + ' ' + A.codr_apellidopaterno + ' ' + A.codr_apellidomaterno AS varchar(200)) AS 'Operador' " +
        '" FROM [Nomina].[Colaborador] AS A " +
        '" JOIN [Nomina].[ColaboradorLaboral] AS B ON B.labo_colaboradorid = A.codr_colaboradorid " +
        '" JOIN [Framework].[Grupos] AS C ON C.grup_grupoid = B.labo_departamentoid " +
        '" WHERE A.codr_activo = 1 AND C.grup_grupoid = 97 ORDER BY A.codr_nombre"
        'Return objPersistencia.EjecutaConsulta(consulta)
        Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_InventarioCiclico_ListaOperadores]", New List(Of SqlParameter))
    End Function

    ''' <summary>
    ''' EJECUTA EL PROCEDIMIENTO ALMACENADO PARADAR DE ALTA UN INVENTARIO CICLICO Y RECUPERAR EL ID DE ESE INVENTARIO QUE SE ACABA DE AGREGAR
    ''' </summary>
    ''' <param name="InventarioCiclico">CLASE INVENTARIOSCICLICOS DE LA CAPA ENTIDADES</param>
    ''' <returns>ID DEL INVENTARIO CICLICO QUE SE ACABA DE AGREGAR</returns>
    ''' <remarks></remarks>
    Public Function AgregarInventarioCiclico(ByVal InventarioCiclico As Entidades.InventariosCiclicos) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@Descripcion"
        parametro.Value = InventarioCiclico.PDescripcion
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@IdOperador"
        parametro.Value = InventarioCiclico.PIdOPerador
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FechaProgramada"
        parametro.Value = InventarioCiclico.PFechaProgramada
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@TotalPares"
        parametro.Value = InventarioCiclico.PTotalPares
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Par_Atado"
        parametro.Value = InventarioCiclico.PPar_Atado
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Usuario"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaparametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("Almacen.SP_Alta_Inventario_Ciclico", listaparametros)

    End Function

    ''' <summary>
    ''' EJECUTA EL PROCEDIMIENTO ALMACENADO PARA EDITAR UN INVENTARIO CICLICO
    ''' </summary>
    ''' <param name="InventarioCiclico">CLASE INVENTARIOSCICLICOS DE LA CAPA ENTIDADES</param>
    ''' <remarks></remarks>
    Public Sub EditarInventarioCiclico(ByVal InventarioCiclico As Entidades.InventariosCiclicos)
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@Descripcion"
        parametro.Value = InventarioCiclico.PDescripcion
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@IdInventario"
        parametro.Value = InventarioCiclico.PIdInventario
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Estado"
        parametro.Value = InventarioCiclico.PEstado
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@IdOperador"
        parametro.Value = InventarioCiclico.PIdOPerador
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FechaProgramada"
        parametro.Value = InventarioCiclico.PFechaProgramada
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Par_Atado"
        parametro.Value = InventarioCiclico.PPar_Atado
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Usuario"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaparametros.Add(parametro)

        operaciones.EjecutarConsultaSP("Almacen.SP_Editar_Inventario_Ciclico", listaparametros)

    End Sub

    ''' <summary>
    ''' EJECUTA EL PROCEDIMIENTO ALMACENADO EN EL QUE SE AGREGAN DATOS A LA TABLA ALMACEN.INVENTARIOSCICLICOSDETALLES PARA UN INVENTARIO CILCICO QUE SE ACABA DE AGREGAR
    ''' </summary>
    ''' <param name="DetallesInventario"></param>
    ''' <remarks></remarks>
    Public Sub AgregarDetallesInventarioCiclico(ByVal DetallesInventario As Entidades.InventarioCiclicoDetalle)
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@IdInventario"
        parametro.Value = DetallesInventario.PInventarioId
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@IdPar"
        parametro.Value = DetallesInventario.PIdPar
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@IdAtado"
        parametro.Value = DetallesInventario.PIdAtado
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Uicacion"
        parametro.Value = DetallesInventario.PUbicacionVirtual
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Usuario"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaparametros.Add(parametro)

        operaciones.EjecutarSentenciaSP("Almacen.SP_Alta_Inventario_Ciclico_Detalles", listaparametros)
    End Sub

    ''' <summary>
    ''' EJECUTA EL PROCEDIMIENTO ALMACENADO PARA AGREGAR DATOS A LA TABLA ALMACEN.INVENTARIOSCICLICOSCARACTERISTICAS
    ''' </summary>
    ''' <param name="Caracteristicas">CASE InvenatariosCiclicosCaracteristicas DE LA CAPA ENTIDADES</param>
    ''' <remarks></remarks>
    Public Sub AgregarCaracteristicaInventarioCiclico(ByVal Caracteristicas As Entidades.InvenatariosCiclicosCaracteristicas)

        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@IdInventario"
        parametro.Value = Caracteristicas.PIdInventarioCiclico
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@IdConfiguracionCaracteristicaInvCic"
        parametro.Value = Caracteristicas.PIdConfiguracionCaracteristicaInventarioCiclico
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@IdCaracteristicaInvCic"
        parametro.Value = Caracteristicas.PCaracteristicaId
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Usuario"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaparametros.Add(parametro)

        operaciones.EjecutarSentenciaSP("Almacen.SP_Alta_Inventario_Ciclico_Caracteristicas", listaparametros)

    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="Inventarios">CLASE InventarioCiclicoBusqueda DE LA CAPA ENTIDADES CON SUS RESPECTIVAS VARIABLES QUE SE USARAN EN EL FILTRO DE BUSQUEDA </param>
    ''' <param name="y_o">VARIABLE PARA SABER SI LA CONSULTA SERA CON AND U OR</param>
    ''' <returns>TABLA CON LOS INVENTARIOS CICLICOS ENCONTRADOS</returns>
    ''' <remarks></remarks>
    Public Function ListaInventariosCiclicos(ByVal Inventarios As Entidades.InventarioCiclicoBusqueda, ByVal y_o As Boolean) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim cadena As String
        Dim LenCadena As Integer
        Dim cadenaSecundaria As String
        Dim consulta As String = ""
        consulta = "select ici.inve_inventariociclicoid as 'IdInventarioCiclico', UPPER(LTRIM(RTRIM(ici.inve_descripcion))) as 'Descripción', UPPER(LTRIM(RTRIM(ici.inve_operadorid))) as 'Id Operador'" +
            ", UPPER(LTRIM(RTRIM(CAST(A.codr_nombre + ' ' + A.codr_apellidopaterno + ' ' + A.codr_apellidomaterno AS varchar(200))))) AS 'Operador'" +
            ", ici.inve_fechaprogramada as 'Fecha Programada', ici.inve_fechainicioejecucion as 'Fecha de Ejecución', ici.inve_totalpares as 'Pares'" +
            ", ici.inve_totalparesfaltantes as 'Faltantes',	ici.inve_totalparessobrantes as 'Sobrantes', ici.inve_estadoid as 'EstadoID', ines_estado as 'Estado'," +
            " inre_resultado as 'Resultado', inve_par_atado as 'Tipo_Escaneo' from almacen.InventariosCiclicos ici" +
            " inner join [Nomina].[Colaborador] as A on A.codr_colaboradorid = ici.inve_operadorid" +
            " inner join almacen.InventariosCiclicosEstados on ines_estadoid = ici.inve_estadoid" +
            " LEFT join almacen.InventariosCiclicosResultados on ici.inve_resultadoid = inre_resultadoid"
        '" inner join [192.168.7.16].[YuyinERP].[Nomina].[Colaborador] as A on A.codr_colaboradorid = ici.inve_operadorid"
        With Inventarios
            cadena = .PAgente + .PCliente + .PTienda + .PPedido + .PProducto + .PMarcas + .Pcoleccion + .PModelo + .PCorridas + .PUbicacion
            cadenaSecundaria = .POperador + .PEstado
        End With
        If cadena <> String.Empty Or cadenaSecundaria <> String.Empty Then

            consulta += " WHERE  "
            If y_o = True Then
                Lencadena = Len(consulta)

                If Inventarios.PTienda <> String.Empty Then
                    consulta += " ici.inve_inventariociclicoid IN  (SELECT	icc.icca_inventariosciclicosid FROM almacen.InventariosCiclicosCaracteristicas icc JOIN Almacen.InventariosCiclicosConfiguracionCaracteristicas AS icconf" +
                        " ON icc.icca_inventariosciclicosconfiguracioncaracteristicasid = icconf.iccc_inventariosciclicosconfiguracioncaracteristicasid JOIN Almacen.InventariosCiclicos AS alci ON alci.inve_inventariociclicoid = icc.icca_inventariosciclicosid" +
                        " AND (icconf.iccc_tabla = 'DISTRIBUCIONES' AND icc.icca_caracteristicaid IN (" + Inventarios.PTienda + ")))"
                End If

              
                If Inventarios.PCliente <> String.Empty Then
                    If LenCadena <> Len(consulta) Then
                        consulta += " and "
                    End If
                    consulta += " ici.inve_inventariociclicoid IN (SELECT	icc.icca_inventariosciclicosid FROM almacen.InventariosCiclicosCaracteristicas icc JOIN Almacen.InventariosCiclicosConfiguracionCaracteristicas AS icconf" +
                    " ON icc.icca_inventariosciclicosconfiguracioncaracteristicasid = icconf.iccc_inventariosciclicosconfiguracioncaracteristicasid JOIN Almacen.InventariosCiclicos AS alci ON alci.inve_inventariociclicoid = icc.icca_inventariosciclicosid" +
                    " AND (icconf.iccc_tabla = 'CADENAS' AND icc.icca_caracteristicaid IN (" + Inventarios.PCliente + ")))"
                End If

              
                If Inventarios.PProducto <> String.Empty Then
                    If LenCadena <> Len(consulta) Then
                        consulta += " and "
                    End If
                    consulta += " ici.inve_inventariociclicoid IN (SELECT	icc.icca_inventariosciclicosid FROM almacen.InventariosCiclicosCaracteristicas icc JOIN Almacen.InventariosCiclicosConfiguracionCaracteristicas AS icconf" +
                        " ON icc.icca_inventariosciclicosconfiguracioncaracteristicasid = icconf.iccc_inventariosciclicosconfiguracioncaracteristicasid JOIN Almacen.InventariosCiclicos AS alci ON alci.inve_inventariociclicoid = icc.icca_inventariosciclicosid" +
                        " AND (icconf.iccc_tabla = 'VESTILOS' AND icc.icca_caracteristicaid IN (" + Inventarios.PProducto + ")))"
                End If

               

                If Inventarios.PCorridas <> String.Empty Then
                    If LenCadena <> Len(consulta) Then
                        consulta += " and "
                    End If
                    consulta += "  ici.inve_inventariociclicoid IN (SELECT	icc.icca_inventariosciclicosid FROM almacen.InventariosCiclicosCaracteristicas icc JOIN Almacen.InventariosCiclicosConfiguracionCaracteristicas AS icconf" +
                        " ON icc.icca_inventariosciclicosconfiguracioncaracteristicasid = icconf.iccc_inventariosciclicosconfiguracioncaracteristicasid JOIN Almacen.InventariosCiclicos AS alci ON alci.inve_inventariociclicoid = icc.icca_inventariosciclicosid" +
                        " AND (icconf.iccc_tabla = 'TALLAS'AND icc.icca_caracteristicaid IN (" + Inventarios.PCorridas + ")))"
                End If

                
                If Inventarios.PPedido <> String.Empty Then
                    If LenCadena <> Len(consulta) Then
                        consulta += " and "
                    End If
                    consulta += "  ici.inve_inventariociclicoid IN (SELECT icc.icca_inventariosciclicosid FROM almacen.InventariosCiclicosCaracteristicas icc JOIN Almacen.InventariosCiclicosConfiguracionCaracteristicas AS icconf" +
                        " ON icc.icca_inventariosciclicosconfiguracioncaracteristicasid = icconf.iccc_inventariosciclicosconfiguracioncaracteristicasid JOIN Almacen.InventariosCiclicos AS alci ON alci.inve_inventariociclicoid = icc.icca_inventariosciclicosid" +
                        " AND (icconf.iccc_tabla = 'PEDIDOS' AND icc.icca_caracteristicaid IN (" + Inventarios.PPedido + ")))"
                End If

                
                If Inventarios.PUbicacion <> String.Empty Then
                    If LenCadena <> Len(consulta) Then
                        consulta += " and "
                    End If
                    consulta += "  ici.inve_inventariociclicoid IN (SELECT	icc.icca_inventariosciclicosid FROM almacen.InventariosCiclicosCaracteristicas icc JOIN Almacen.InventariosCiclicosConfiguracionCaracteristicas AS icconf" +
                        " ON icc.icca_inventariosciclicosconfiguracioncaracteristicasid = icconf.iccc_inventariosciclicosconfiguracioncaracteristicasid JOIN Almacen.InventariosCiclicos AS alci ON alci.inve_inventariociclicoid = icc.icca_inventariosciclicosid" +
                        " AND (icconf.iccc_tabla = 'UBICACIONES' AND icc.icca_caracteristicaid IN (" + Inventarios.PUbicacion + ")))"
                End If

                
                If Inventarios.PAgente <> String.Empty Then
                    If LenCadena <> Len(consulta) Then
                        consulta += " and "
                    End If
                    consulta += "  ici.inve_inventariociclicoid IN (SELECT icc.icca_inventariosciclicosid FROM almacen.InventariosCiclicosCaracteristicas icc JOIN Almacen.InventariosCiclicosConfiguracionCaracteristicas AS icconf" +
                        " ON icc.icca_inventariosciclicosconfiguracioncaracteristicasid = icconf.iccc_inventariosciclicosconfiguracioncaracteristicasid JOIN Almacen.InventariosCiclicos AS alci ON alci.inve_inventariociclicoid = icc.icca_inventariosciclicosid" +
                        " AND (icconf.iccc_tabla = 'AGENTES' AND icc.icca_caracteristicaid IN (" + Inventarios.PAgente + ")))"
                End If
            
                If Inventarios.POperador <> String.Empty Then
                    If LenCadena <> Len(consulta) Then
                        consulta += " and "
                    End If
                    consulta += "  ici.inve_operadorid  in (" + Inventarios.POperador.ToString + ") "
                End If
                
                If Inventarios.PEstado <> String.Empty Then
                    If LenCadena <> Len(consulta) Then
                        consulta += " and "
                    End If
                    consulta += "  ici.inve_estadoid  IN (" + Inventarios.PEstado.ToString + ")  "
                End If
                'If LenCadena <> Len(consulta) Then
                '    consulta += " and "
                'End If
                consulta += " ORDER BY ici.inve_inventariociclicoid desc"

            Else
                LenCadena = Len(consulta)
                If Inventarios.PTienda <> String.Empty Then
                    consulta += " ici.inve_inventariociclicoid IN  (SELECT	icc.icca_inventariosciclicosid FROM almacen.InventariosCiclicosCaracteristicas icc JOIN Almacen.InventariosCiclicosConfiguracionCaracteristicas AS icconf" +
                        " ON icc.icca_inventariosciclicosconfiguracioncaracteristicasid = icconf.iccc_inventariosciclicosconfiguracioncaracteristicasid JOIN Almacen.InventariosCiclicos AS alci ON alci.inve_inventariociclicoid = icc.icca_inventariosciclicosid" +
                        " AND (icconf.iccc_tabla = 'DISTRIBUCIONES' AND icc.icca_caracteristicaid IN (" + Inventarios.PTienda + ")))"
                End If

                If Inventarios.PCliente <> String.Empty Then
                    If LenCadena <> Len(consulta) Then
                        consulta += " OR "
                    End If
                    consulta += "  ici.inve_inventariociclicoid IN (SELECT	icc.icca_inventariosciclicosid FROM almacen.InventariosCiclicosCaracteristicas icc JOIN Almacen.InventariosCiclicosConfiguracionCaracteristicas AS icconf" +
                    " ON icc.icca_inventariosciclicosconfiguracioncaracteristicasid = icconf.iccc_inventariosciclicosconfiguracioncaracteristicasid JOIN Almacen.InventariosCiclicos AS alci ON alci.inve_inventariociclicoid = icc.icca_inventariosciclicosid" +
                    " AND (icconf.iccc_tabla = 'CADENAS' AND icc.icca_caracteristicaid IN (" + Inventarios.PCliente + ")))"
                End If
               
                If Inventarios.PProducto <> String.Empty Then
                    If LenCadena <> Len(consulta) Then
                        consulta += " OR "
                    End If
                    consulta += "  ici.inve_inventariociclicoid IN (SELECT	icc.icca_inventariosciclicosid FROM almacen.InventariosCiclicosCaracteristicas icc JOIN Almacen.InventariosCiclicosConfiguracionCaracteristicas AS icconf" +
                        " ON icc.icca_inventariosciclicosconfiguracioncaracteristicasid = icconf.iccc_inventariosciclicosconfiguracioncaracteristicasid JOIN Almacen.InventariosCiclicos AS alci ON alci.inve_inventariociclicoid = icc.icca_inventariosciclicosid" +
                        " AND (icconf.iccc_tabla = 'VESTILOS' AND icc.icca_caracteristicaid IN (" + Inventarios.PProducto + ")))"
                End If
                
                If Inventarios.PCorridas <> String.Empty Then
                    If LenCadena <> Len(consulta) Then
                        consulta += " OR "
                    End If
                    consulta += "  ici.inve_inventariociclicoid IN (SELECT	icc.icca_inventariosciclicosid FROM almacen.InventariosCiclicosCaracteristicas icc JOIN Almacen.InventariosCiclicosConfiguracionCaracteristicas AS icconf" +
                        " ON icc.icca_inventariosciclicosconfiguracioncaracteristicasid = icconf.iccc_inventariosciclicosconfiguracioncaracteristicasid JOIN Almacen.InventariosCiclicos AS alci ON alci.inve_inventariociclicoid = icc.icca_inventariosciclicosid" +
                        " AND (icconf.iccc_tabla = 'TALLAS'AND icc.icca_caracteristicaid IN (" + Inventarios.PCorridas + ")))"
                End If
             
                If Inventarios.PPedido <> String.Empty Then
                    If LenCadena <> Len(consulta) Then
                        consulta += " OR "
                    End If
                    consulta += " ici.inve_inventariociclicoid IN (SELECT icc.icca_inventariosciclicosid FROM almacen.InventariosCiclicosCaracteristicas icc JOIN Almacen.InventariosCiclicosConfiguracionCaracteristicas AS icconf" +
                        " ON icc.icca_inventariosciclicosconfiguracioncaracteristicasid = icconf.iccc_inventariosciclicosconfiguracioncaracteristicasid JOIN Almacen.InventariosCiclicos AS alci ON alci.inve_inventariociclicoid = icc.icca_inventariosciclicosid" +
                        " AND (icconf.iccc_tabla = 'PEDIDOS' AND icc.icca_caracteristicaid IN (" + Inventarios.PPedido + ")))"
                End If
               
                If Inventarios.PUbicacion <> String.Empty Then
                    If LenCadena <> Len(consulta) Then
                        consulta += " OR "
                    End If
                    consulta += "  ici.inve_inventariociclicoid IN (SELECT	icc.icca_inventariosciclicosid FROM almacen.InventariosCiclicosCaracteristicas icc JOIN Almacen.InventariosCiclicosConfiguracionCaracteristicas AS icconf" +
                        " ON icc.icca_inventariosciclicosconfiguracioncaracteristicasid = icconf.iccc_inventariosciclicosconfiguracioncaracteristicasid JOIN Almacen.InventariosCiclicos AS alci ON alci.inve_inventariociclicoid = icc.icca_inventariosciclicosid" +
                        " AND (icconf.iccc_tabla = 'UBICACIONES' AND icc.icca_caracteristicaid IN (" + Inventarios.PUbicacion + ")))"
                End If
                
                If Inventarios.PAgente <> String.Empty Then
                    If LenCadena <> Len(consulta) Then
                        consulta += " OR "
                    End If
                    consulta += "  ici.inve_inventariociclicoid IN (SELECT icc.icca_inventariosciclicosid FROM almacen.InventariosCiclicosCaracteristicas icc JOIN Almacen.InventariosCiclicosConfiguracionCaracteristicas AS icconf" +
                        " ON icc.icca_inventariosciclicosconfiguracioncaracteristicasid = icconf.iccc_inventariosciclicosconfiguracioncaracteristicasid JOIN Almacen.InventariosCiclicos AS alci ON alci.inve_inventariociclicoid = icc.icca_inventariosciclicosid" +
                        " AND (icconf.iccc_tabla = 'AGENTES' AND icc.icca_caracteristicaid IN (" + Inventarios.PAgente + ")))"
                End If
                
                If Inventarios.POperador <> String.Empty Then
                    If LenCadena <> Len(consulta) Then
                        consulta += " OR "
                    End If
                    consulta += "  ici.inve_operadorid  in (" + Inventarios.POperador.ToString + ") "
                End If
                
                If Inventarios.PEstado <> String.Empty Then
                    If LenCadena <> Len(consulta) Then
                        consulta += " OR "
                    End If
                    consulta += " ici.inve_estadoid  IN (" + Inventarios.PEstado.ToString + ")  "
                End If
                'If LenCadena <> Len(consulta) Then
                '    consulta += " AND "
                'End If
                consulta += " ORDER BY ici.inve_inventariociclicoid desc"
        End If
        Else
            consulta = consulta + " ORDER BY ici.inve_inventariociclicoid desc"
        End If
        Return objPersistencia.EjecutaConsulta(consulta)
    End Function

    ''' <summary>
    ''' RECUPERA LA LISTA DE LOS ESTADOS EN LOS QUE PUEDE ESTAR UN INVENTARIO CICLICO
    ''' </summary>
    ''' <returns>EJECUCION DE LA CONSULTA CON LA LISTA DE LOS INVENTARIOS CICLICOS</returns>
    ''' <remarks></remarks>
    Public Function ListaEstadosInventariosCiclicos() As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim Consulta As String = ""
        Consulta = "select ines_estadoid as 'Identificador', ines_estado as 'Estado' from Almacen.InventariosCiclicosEstados where ines_activo = 'TRUE'"
        Return objPersistencia.EjecutaConsulta(Consulta)
    End Function

    ''' <summary>
    ''' DIBUJA LAS CARACTERISTICAS O CRITERIO DE BUSQUEDA CON LA QUE SE REALIZO DETERMINADO INVENTARIO CICLICO    
    ''' </summary>
    ''' <param name="IdInventario">ID DEL INVENTARIO A RECUPERAR LOS DATOS</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ListaCriterioFiltradoEditar(ByVal IdInventario As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta = " "
        consulta = "SELECT	b.icca_inventariosciclicoscaracteristicasid AS 'Identificador', UPPER(c.iccc_campoid) as 'IdCampo', UPPER(iccc_campodescripcion) as 'Campo'," +
            " UPPER(iccc_tabla) AS 'Tabla', UPPER(iccc_etiqueta) AS 'Criterio', ltrim(rtrim(CONVERT  (nvarchar(30),b.icca_caracteristicaid))) as 'Característica' FROM ALMACEN.InventariosCiclicos a" +
            " INNER JOIN almacen.InventariosCiclicosCaracteristicas b on a.inve_inventariociclicoid=b.icca_inventariosciclicosid" +
            " inner JOIN almacen.InventariosCiclicosConfiguracionCaracteristicas c" +
            " on b.icca_inventariosciclicosconfiguracioncaracteristicasid =c.iccc_inventariosciclicosconfiguracioncaracteristicasid" +
            " where b.icca_inventariosciclicosid = " + IdInventario.ToString + ""
        Return objPersistencia.EjecutaConsulta(consulta)
    End Function

    ''' <summary>
    ''' DIBUJA LAS CARACTERISTICAS O CRITERIO DE BUSQUEDA CON LA QUE SE REALIZO DETERMINADO INVENTARIO CICLICO
    ''' </summary>
    ''' <param name="CampoDesccripcion">CAMPO DEL CUAL SE RECUPERARA ALGUN DATO DE DETERMINADA TABLA</param>
    ''' <param name="Tabla">TABLA DE LA CUAL SE RECUPERARAN DATOS</param>
    ''' <param name="IdCampo">ID DEL CAMPO A RECUPERAR INFORMACION</param>
    ''' <param name="IdCaracteristica">ID DEL CAMPO A RECUPERAR INFORMACION ALMACENADO EN LA TABLA ALMACEN.INVENTARIOCICLICOCARACTERISTICAS</param>
    ''' <returns>EJECUCION DE LA TABLA CON LOS CRITERIOS DE BUSQUEDA USADOS PARA LEVANTAR UN INVENTARIO CICLICO</returns>
    ''' <remarks></remarks>
    Public Function RecuperarCaracteristica(ByVal CampoDesccripcion As String, ByVal Tabla As String, ByVal IdCampo As String, ByVal IdCaracteristica As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String = ""
        consulta = "Select " + CampoDesccripcion + " as 'Caracteristica' from " + Tabla + " where " + IdCampo + " = '" + IdCaracteristica + "'"
        Return objPersistencia.EjecutaConsulta(consulta)
    End Function

    ''' <summary>
    ''' RECUPERA LA LISTA DE LOS PARES PERTENECIENTES A DETERMINADO INVENTARIO CICLICO Y SUS RESPECTIVAS CARACTERISTICAS
    ''' </summary>
    ''' <param name="IdInvetario">ID DEL INVENTARIO A CONSULTAR</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ListaDetalleInventario(ByVal IdInvetario As Integer, ByVal IdEstado As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY

        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@IDInventario"
        parametro.Value = IdInvetario
        listaparametros.Add(parametro)



        Return objPersistencia.EjecutarConsultaSP("Almacen.ListaDetalleInventario", listaparametros)

        'Dim consulta As String = ""
        'consulta = "" +
        '    " SELECT 'P' AS 'P/A',
        'a.inde_idpar AS 'Par', 
        'a.inde_idatado AS 'Atado', 
        'Left(bahi_bahiaid, CHARINDEX('-', bahi_bahiaid) - 1) AS 'Bahía',
        'f.Descripcion AS 'Producto', Talla AS 'Corrida'," +
        '    " CAST(e.ubpa_talla AS varchar) AS 'Talla', h.nombre AS 'Cliente', e.ubpa_pedido AS 'Pedido', CAST(e.ubpa_apartado AS varchar) AS 'Apartado', Iniciales AS 'Agte'," +
        '    " CAST(e.ubpa_idtienda AS varchar) AS 'Tienda', Naves.Nave AS 'Nave', e.ubpa_lote AS 'Lote', " +
        '    " CASE WHEN (a.inde_existencia IS NULL AND a.inde_sobra IS NULL) OR a.inde_sobra = 1 THEN CAST(0 AS integer) ELSE a.inde_existencia END AS 'Existencia', " +
        '    " CASE WHEN a.inde_sobra IS NULL THEN CAST('1' AS varchar)ELSE CAST('0' AS varchar)END AS 'Prs',bahi_bahiaid AS 'Bahía ID',bahi_bloque AS 'Bloque',bahi_nivel AS 'Nivel'," +
        '    " bahi_posicion AS 'Posicion',bahi_color AS 'Color',codr_nombrecorto as 'Operador',ubpa_fechamodificacion AS 'Fecha'" +
        '    " FROM almacen.InventariosCiclicosDetalles AS a" +
        '    " join almacen.InventariosCiclicos on inve_inventariociclicoid = a.inde_inventarioid LEFT JOIN Almacen.UbicacionPares e ON e.ubpa_codigopar = a.inde_idpar" +
        '    " LEFT JOIN Nomina.Colaborador d ON d.codr_colaboradorid = e.ubpa_colaboradormodificaid JOIN vEstilos f ON f.IdCodigo = e.ubpa_producto" +
        '    " LEFT JOIN Tallas g ON g.IdTalla = e.ubpa_idcorrida LEFT JOIN vCadenas h ON h.IdCadena = ubpa_idcadena LEFT JOIN Agentes ON ubpa_idagente = Agentes.IdAgente LEFT JOIN Naves ON IdNave = ubpa_nave"
        'consulta += " left join Almacen.Estiba on LEFT(esti_estibaid, CHARINDEX('-', esti_estibaid) -1) = a.inde_ubicacionvirtual"
        'consulta += " left join Almacen.Bahia on bahi_bahiaid = esti_bahiaid" +
        '    " WHERE inde_inventarioid = " + IdInvetario.ToString + " And e.ubpa_codigopar = a.inde_idpar" +
        '    " UNION SELECT 'P' AS 'P/A', a.inde_idpar AS 'Par', a.inde_idatado AS 'Atado', LEFT(bahi_bahiaid, CHARINDEX('-', bahi_bahiaid) - 1) AS 'Bahía', f.Descripcion AS 'Producto', Talla AS 'Corrida'," +
        '    " CAST(coat_talla AS varchar) AS 'Talla', h.nombre AS 'Cliente', coat_idpedido AS 'Pedido', coat_idapartado AS 'Apartado', Iniciales AS 'Agte', coat_idtienda AS 'Tienda', Naves.Nave AS 'Nave'," +
        '    " e.ubat_lote AS 'Lote', CASE WHEN a.inde_existencia IS NULL AND a.inde_sobra IS NULL THEN CAST(0 AS integer) ELSE a.inde_existencia END AS 'Existencia'," +
        '    " CASE WHEN a.inde_sobra IS NULL THEN CAST('1' AS varchar) ELSE CAST('0' AS varchar) END AS 'Prs', bahi_bahiaid AS 'Bahía ID', bahi_bloque AS 'Bloque', bahi_nivel AS 'Nivel'," +
        '    " bahi_posicion AS 'Posicion', bahi_color AS 'Color', 	codr_nombrecorto as 'Operador', coat_fechamodificacion AS 'Fecha'" +
        '    " FROM almacen.InventariosCiclicosDetalles AS a" +
        '    " join almacen.InventariosCiclicos on inve_inventariociclicoid = a.inde_inventarioid JOIN Almacen.ContenidoAtados ON coat_codigopar = a.inde_idpar " +
        '    " JOIN Almacen.UbicacionAtados e ON e.ubat_codigoatado = coat_codigoatado LEFT JOIN Nomina.Colaborador d ON d.codr_colaboradorid = e.ubat_colaboradormodificaid JOIN vEstilos f ON f.IdCodigo = e.ubat_producto" +
        '    " LEFT JOIN Tallas g ON g.IdTalla = e.ubat_idcorrida LEFT JOIN vCadenas h ON h.IdCadena = e.ubat_idcadena" +
        '    " LEFT JOIN Agentes ON e.ubat_idagente = Agentes.IdAgente LEFT JOIN Naves ON IdNave = e.ubat_nave"
        'consulta += " left join Almacen.Estiba on LEFT(esti_estibaid, CHARINDEX('-', esti_estibaid) -1 ) = a.inde_ubicacionvirtual"
        'consulta += " left join Almacen.Bahia on bahi_bahiaid = esti_bahiaid" +
        '    " WHERE inde_inventarioid = " + IdInvetario.ToString + " And a.inde_idpar = coat_codigopar" +
        '    " UNION SELECT 'P' AS 'P/A',a.inde_idpar AS 'Par',a.inde_idatado AS 'Atado',LEFT(bahi_bahiaid, CHARINDEX('-', bahi_bahiaid) - 1) AS 'Bahía',Descripcion AS 'Producto',Talla AS 'Corrida'," +
        '    " CAST(ersp_talla AS varchar) AS 'Talla',h.nombre AS 'Cliente',ersp_pedido AS 'Pedido',ersp_apartado AS 'Apartado',Iniciales AS 'Agte',ersp_idtienda AS 'Tienda',Naves.Nave AS 'Nave'," +
        '    " ersp_lote AS 'Lote',CASE WHEN a.inde_existencia IS NULL AND a.inde_sobra IS NULL THEN CAST(0 AS integer) ELSE a.inde_existencia END AS 'Existencia', " +
        '    " CASE WHEN a.inde_sobra IS NULL THEN CAST('1' AS varchar) ELSE CAST('0' AS varchar)END AS 'Prs',bahi_bahiaid AS 'Bahía ID',bahi_bloque AS 'Bloque',bahi_nivel AS 'Nivel'," +
        '    " bahi_posicion AS 'Posicion', bahi_color AS 'Color', codr_nombrecorto as 'Operador', ersp_fechamodificacion AS 'Fecha'" +
        '    " FROM almacen.InventariosCiclicosDetalles AS a" +
        '    " join almacen.InventariosCiclicos on inve_inventariociclicoid = a.inde_inventarioid LEFT JOIN Almacen.ErroresStatusPar ON a.inde_idpar = ersp_codigopar JOIN vEstilos f ON f.IdCodigo = ersp_producto" +
        '    " LEFT JOIN Tallas g ON g.IdTalla = ersp_idcorrida LEFT JOIN vCadenas h ON h.IdCadena = ersp_idcadena LEFT JOIN Agentes ON ersp_idagente = Agentes.IdAgente LEFT JOIN Naves ON IdNave = ersp_nave LEFT JOIN Nomina.Colaborador d ON d.codr_colaboradorid = ersp_colaboradormodificaid "
        'consulta += " left join Almacen.Estiba on LEFT(esti_estibaid, CHARINDEX('-', esti_estibaid) -1) = a.inde_ubicacionvirtual "
        'consulta += " left join Almacen.Bahia on bahi_bahiaid = esti_bahiaid" +
        '    " WHERE inde_inventarioid = " + IdInvetario.ToString + " and a.inde_idpar = ersp_codigopar" +
        '    " UNION SELECT 'P' AS 'P/A',a.inde_idpar AS 'Par',a.inde_idatado AS 'Atado',LEFT(bahi_bahiaid, CHARINDEX('-', bahi_bahiaid) - 1) AS 'Bahía',Descripcion AS 'Producto',Talla AS 'Corrida'," +
        '    " CAST(B.calce AS varchar) AS 'Talla',h.nombre AS 'Cliente',b.idtblPedido AS 'Pedido',B.idtblOrdApartado AS 'Apartado','N/A' AS 'Agte',B.idtblTienda AS 'Tienda', " +
        '    " Naves.Nave AS 'Nave', B.idtbllote AS 'Lote', CASE WHEN a.inde_existencia IS NULL AND a.inde_sobra IS NULL THEN CAST(0 AS integer) ELSE a.inde_existencia END AS 'Existencia'," +
        '    " CASE WHEN a.inde_sobra IS NULL THEN CAST('1' AS varchar) ELSE CAST('0' AS varchar) END AS 'Prs', bahi_bahiaid AS 'Bahía ID', bahi_bloque AS 'Bloque', bahi_nivel AS 'Nivel', " +
        '    " bahi_posicion AS 'Posicion', bahi_color AS 'Color', 'N/A' as 'Operador', NULL  AS 'Fecha'" +
        '    " FROM almacen.InventariosCiclicosDetalles AS a" +
        '    " join almacen.InventariosCiclicos on inve_inventariociclicoid = a.inde_inventarioid LEFT JOIN tmpDocenasPares b ON a.inde_idpar = b.ID_Par" +
        '    " JOIN vEstilos f ON f.IdCodigo = b.idtblProducto LEFT JOIN Tallas g ON g.IdTalla = b.idtblTalla LEFT JOIN Distribuciones h ON h.IdDistribucion = b.idtblTienda LEFT JOIN Naves ON IdNave = B.idtblnave"
        'consulta += " left join Almacen.Estiba on LEFT(esti_estibaid, CHARINDEX('-', esti_estibaid)-1 ) = a.inde_ubicacionvirtual"
        'consulta += " left join Almacen.Bahia on bahi_bahiaid = esti_bahiaid" +
        '    " WHERE inde_inventarioid = " + IdInvetario.ToString + " AND b.ID_Par NOT IN (" +
        '    " SELECT a.inde_idpar FROM Almacen.InventariosCiclicosDetalles a" +
        '    " LEFT JOIN Almacen.UbicacionPares b ON a.inde_idpar = b.ubpa_codigopar LEFT JOIN almacen.ContenidoAtados c ON a.inde_idpar = c.coat_codigopar LEFT JOIN Almacen.ErroresStatusPar d ON a.inde_idpar = d.ersp_codigopar" +
        '    " WHERE a.inde_inventarioid = " + IdInvetario.ToString + ") ORDER BY 'Par' DESC"

    End Function

    ''' <summary>
    ''' RECUPERA LAS CORRIDAS CON LAS QUE CUENTA DETERMINADO INVENTARIO CICLICO
    ''' </summary>
    ''' <param name="IdInventario">ID DEL INVENTARIO A CONSULTAR</param>
    ''' <returns>EJECUCION DE LA CONSULTA DE LAS CORRIDAS DE DETERMINADO INVENTARIO</returns>
    ''' <remarks></remarks>
    Public Function CorridasReporte(ByVal IdInventario As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String = String.Empty
        consulta = "select t.Corridax from (SELECT ubpa_idcorrida as 'Corridax' FROM ALMACEN.InventariosCiclicosDetalles " +
            "JOIN Almacen.UbicacionPares	ON ubpa_codigopar = inde_idpar JOIN vestilos ON IdCodigo = ubpa_producto WHERE inde_inventarioid =" + IdInventario.ToString + " GROUP BY ubpa_idcorrida" +
            " union all select ubat_idcorrida 'Corridax' from almacen.InventariosCiclicosDetalles join Almacen.UbicacionAtados on inde_idatado = ubat_codigoatado where inde_inventarioid = " + IdInventario.ToString +
            " GROUP by ubat_idcorrida)as t GROUP by t.Corridax"
        Return objPersistencia.EjecutaConsulta(consulta)
    End Function

    ''' <summary>
    ''' EJECUTA UN PROCEDIMIENTO ALMACENADO EN EL QUE SE RECUPERA LOS PARES QUE PERTENECEN A CIERTO INVENTARIO CICLIICO, LA POSICION EN LA QUE SE DENERIAN LOCALIZAR, Y CUANTOS PARES DE CADA CORRIDA/TALLA TENDRIAN QUE EXISTIR
    ''' </summary>
    ''' <param name="IdInventario">ID DEL INVENTARIO A CONSULTAR</param>
    ''' <returns>EJECUCION DEL PROCEDIMIENTO ALMACENADO</returns>
    ''' <remarks></remarks>
    Public Function ResumenInventario(ByVal IdInventario As Integer)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String = String.Empty
        consulta = " SELECT ROW_NUMBER() OVER (ORDER BY UBICACIÓN ASC) AS '#', *" +
            " FROM (SELECT * FROM" +
            " (SELECT" +
            " A.inde_idpar AS 'CT', inde_ubicacionvirtual AS 'UBICACIÓN', (MARCA + ' ' + Coleccion + ' ' + IdModelo + ' ' + talla +' lte.'+ cast (B.ubpa_lote as varchar(max))) AS 'PRODUCTO', d.IdTalla AS 'CORRIDA'," +
            " COUNT(inde_inventariodetalleid) AS 'PARES', B.ubpa_talla AS 'Talla'" +
            " FROM almacen.InventariosCiclicosDetalles A" +
            " JOIN Almacen.UbicacionPares B ON B.ubpa_codigopar = A.inde_idpar AND inde_inventarioid = CAST(" + IdInventario.ToString + " AS varchar(max))" +
            " JOIN vEstilos ON IdCodigo = B.ubpa_producto" +
            " JOIN Tallas d ON d.IdTalla = b.ubpa_idcorrida" +
            " GROUP BY	A.inde_idpar,inde_ubicacionvirtual,MARCA,Coleccion,IdModelo,d.Talla,D.IdTalla,B.ubpa_talla, B.ubpa_lote " +
            " UNION ALL" +
            " SELECT" +
            " coat_codigopar AS 'CT',inde_ubicacionvirtual AS 'UBICACIÓN',(MARCA + ' ' + Coleccion + ' ' + IdModelo + ' ' + talla +' lte.'+ cast (ubat_lote  as varchar(max))) AS 'PRODUCTO',IdTalla AS 'CORRIDA'," +
            " COUNT(inde_inventariodetalleid) AS 'PARES',coat_talla AS 'Talla'" +
            " FROM almacen.InventariosCiclicosDetalles" +
            " INNER JOIN Almacen.ContenidoAtados ON coat_codigopar = inde_idpar AND inde_inventarioid = CAST(" + IdInventario.ToString + " AS varchar(max))" +
            " JOIN vEstilos ON IdCodigo = coat_producto" +
            " JOIN Almacen.UbicacionAtados ON ubat_codigoatado = inde_idatado" +
            " JOIN TALLAS ON IdTalla = ubat_idcorrida" +
            " GROUP BY coat_codigopar,inde_ubicacionvirtual,MARCA,Coleccion,IdModelo,Talla,IdTalla,coat_talla, ubat_lote" +
            " union " +
            " SELECT" +
            " A.inde_idpar AS 'CT', inde_ubicacionvirtual AS 'UBICACIÓN', (MARCA + ' ' + Coleccion + ' ' + IdModelo + ' ' + talla+' lte.'+cast(idtbllote  as varchar(max))) AS 'PRODUCTO', d.IdTalla AS 'CORRIDA'," +
            " COUNT(inde_inventariodetalleid) AS 'PARES', Calce AS 'Talla'" +
            " FROM almacen.InventariosCiclicosDetalles A" +
            " JOIN tmpDocenasPares ON ID_Par = A.inde_idpar AND inde_inventarioid = CAST(" + IdInventario.ToString + " AS varchar(max)) AND A.inde_idpar NOT IN" +
            " (SELECT inde_idpar FROM almacen.InventariosCiclicosDetalles A" +
            " JOIN Almacen.UbicacionPares B ON B.ubpa_codigopar = A.inde_idpar AND inde_inventarioid = CAST(" + IdInventario.ToString + " AS varchar(max))" +
            " UNION  " +
            " SELECT inde_idpar FROM almacen.InventariosCiclicosDetalles A" +
            " INNER JOIN Almacen.ContenidoAtados ON coat_codigopar = inde_idpar AND inde_inventarioid = CAST(" + IdInventario.ToString + " AS varchar(max)))" +
            " JOIN vEstilos ON IdCodigo = idtblProducto" +
            " JOIN Tallas d ON d.IdTalla = idtblTalla" +
            " GROUP BY	A.inde_idpar,inde_ubicacionvirtual,MARCA,Coleccion,IdModelo,d.Talla,D.IdTalla, Calce,idtbllote" +
            " ) AS T" +
            " GROUP BY	CT,T.UBICACIÓN,T.PRODUCTO,T.CORRIDA,T.PARES,T.Talla) AS PVT " +
            " PIVOT (COUNT(PVT.CT) FOR TALLA IN ([12], [12½], [13], [13½], [14], [14½], [15], [15½], [16], [16½], [17], [17½], [18], [18½], [19], [19½], [20], [20½], [21], [21½], [22]," +
            " [22½], [23], [23½], [24], [24½], [25], [25½], [26], [26½], [27], [27½], [28], [28½], [29], [29½], [30], [30½], [31], [31½], [32])) AS pvot"
        Return objPersistencia.EjecutaConsulta(consulta)
    End Function

    ''' <summary>
    ''' REGRESA LA CONSULTA CON LOS RESULTADOS DE LOS PARES QUE CONTIENE CIERTO INVENTARIO CICLICO, AGRUPADOS POR ATADO,UBICACION, DESCRIPCION Y MOSTRANDO CUANTOS PARES HAY POR TALLAS
    ''' </summary>
    ''' <param name="IdInventario">ID DEL INVENTARIO EN EL CUAL SE RECUPERARAN LOS PARES PERTENECIENTES A ESTE</param>
    ''' <returns>EJECUCION DE LA CONSULTA CON LOS RESULTADOS DE PARES ENCONTRADOS EN UN INVENTARIO YA REALIZADO</returns>
    ''' <remarks></remarks>
    Public Function ImprimirReporteResultadoInventario(ByVal IdInventario As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim Consulta As String = ""
        Consulta = "SELECT ROW_NUMBER() OVER (ORDER BY T.Ubicación ASC) AS '#', * FROM (SELECT * FROM (" +
            " SELECT '' AS 'Par', inde_idatado AS 'Atado', inde_idpar 'CONTAR', case when inde_ubicacionreal is null then inde_ubicacionvirtual ELSE inde_ubicacionreal END AS 'Ubicación', Descripcion AS 'Descripción', IdCodigo AS 'Clave_Producto'," +
            " ubpa_lote AS 'Lote', ubpa_idcorrida AS 'Corrida', NULL AS 'Total', NULL AS 'Encontrados', NULL AS 'Faltantes', ubpa_talla" +
            " FROM Almacen.InventariosCiclicosDetalles JOIN Almacen.UbicacionPares ON ubpa_codigopar = inde_idpar JOIN vestilos ON IdCodigo = ubpa_producto" +
            " WHERE inde_inventarioid = " + IdInventario.ToString + " And inde_sobra Is NULL" +
            " UNION SELECT '' AS 'Par', inde_idatado, inde_idpar, case when inde_ubicacionreal is null then inde_ubicacionvirtual ELSE inde_ubicacionreal END AS 'Ubicación', Descripcion, IdCodigo AS 'Clave Producto', ubat_lote, ubat_idcorrida," +
            " NULL AS 'total', NULL AS 'Encontrados', NULL AS 'Faltantes', coat_talla" +
            " FROM ALMACEN.InventariosCiclicosDetalles JOIN Almacen.UbicacionAtados ON ubat_codigoatado = ubat_codigoatado JOIN almacen.ContenidoAtados" +
            " ON coat_codigoatado = ubat_codigoatado AND coat_codigopar = inde_idpar JOIN vestilos ON IdCodigo = coat_producto" +
            " WHERE inde_inventarioid = " + IdInventario.ToString + " And inde_sobra Is NULL" +
            " UNION SELECT" +
            " '' AS 'Par', inde_idatado, inde_idpar, case when inde_ubicacionreal is null then inde_ubicacionvirtual ELSE inde_ubicacionreal END AS 'Ubicación', Descripcion, IdCodigo AS 'Clave Producto', idtbllote, idtblTalla AS 'CORRIDA', NULL AS 'total', NULL AS 'Encontrados'," +
            " NULL AS 'Faltantes', Calce FROM ALMACEN.InventariosCiclicosDetalles JOIN tmpDocenaspares ON ID_Par = inde_idpar JOIN vestilos ON IdCodigo = idtblProducto" +
            " WHERE inde_inventarioid = " + IdInventario.ToString + "  AND inde_sobra IS NULL AND inde_idpar NOT IN (" +
            " SELECT inde_idpar FROM almacen.InventariosCiclicosDetalles JOIN Almacen.UbicacionPares ON inde_idpar = ubpa_codigopar where inde_inventarioid = " + IdInventario.ToString + "" +
            " UNION ALL SELECT inde_idpar FROM almacen.InventariosCiclicosDetalles JOIN almacen.ContenidoAtados ON inde_idpar = coat_codigopar where inde_inventarioid = " + IdInventario.ToString + ")) AS chavs " +
            " PIVOT (COUNT(chavs.CONTAR) FOR ubpa_talla IN ([12], [12½], [13], [13½], [14], [14½], [15], [15½], [16], [16½], [17], [17½], [18], [18½], [19], [19½], [20], [20½], [21], [21½]," +
            " [22], [22½], [23], [23½], [24], [24½], [25], [25½], [26], [26½], [27], [27½], [28], [28½], [29], [29½], [30], [30½], [31], [31½], [32])) AS pvot) AS T"
        Return objPersistencia.EjecutaConsulta(Consulta)
    End Function

    ''' <summary>
    ''' RECUPERA EL TOTAL DE PARES ENCONTRADOS EN LA TABLA ALMACEN.INVENTARIOSCICLICOSDETALLES DE DETERMINADO ATADO, UBICACION E INVENTARIO
    ''' </summary>
    ''' <param name="IdInventario">ID DEL INVENTARIO EN EL QUE SE BUSCARAN LOS TOTALES ENCONTRADOS</param>
    ''' <param name="Atado">NUMERO DE ATADO EN EL QUE SE BUSCARA</param>
    ''' <param name="Ubicacion">ESTIBA EN LA QUE SE BUSCARA</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function RecuperarEncontrados(ByVal IdInventario As Integer, ByVal Atado As String, ByVal Ubicacion As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim Consulta As String = ""
        Consulta = "select sum(inde_existencia) from Almacen.InventariosCiclicosDetalles where inde_idatado='" + Atado + "' and inde_sobra is null and inde_ubicacionreal = '" + Ubicacion + "' and inde_inventarioid = " + IdInventario.ToString
        Return objPersistencia.EjecutaConsulta(Consulta)
    End Function

    ''' <summary>
    ''' RECUPERA EL CODIGO DE PAR DE DETERMINADO PAR EN LA TABLA ALMACEN.INVENTARIOSCICLICOSDETALLES
    ''' </summary>
    ''' <param name="IdInventario">ID DEL INVENTARIO EN EL QUE SE BUSCARA EL CODIGO DEL PAR</param>
    ''' <param name="Atado">ATADO EN EL QUE SE BUSCARA EL CODIGO DEL PAR</param>
    ''' <param name="Ubicacion">UBICACION EN LA QUE SE BUSCARA EL CODIGO DEL PAR</param>
    ''' <returns>CONSULTA CON LOS PARES ENCONTRADOS</returns>
    ''' <remarks></remarks>
    Public Function RecuperarCodigoPar(ByVal IdInventario As Integer, ByVal Atado As String, ByVal Ubicacion As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String = ""
        consulta = "select inde_idpar from Almacen.InventariosCiclicosDetalles where inde_idatado='" + Atado + "' and inde_ubicacionreal = '" + Ubicacion + "' and inde_inventarioid = " + IdInventario.ToString
        Return objPersistencia.EjecutaConsulta(consulta)
    End Function

    ''' <summary>
    ''' RECUPERA UNA TABLA CON TODOS LOS PARES SOBRANTES EN UN DETERMINADO INVENTARIO CICLICO
    ''' </summary>
    ''' <param name="IdInventario">ID DEL INVENTARIO A RECUPERAR PARES SOBRANTES</param>
    ''' <returns>TABLA CON LOS PARES ENCONTRADOS COMO SOBRANTES DE UN DETERMINADO INVENTARIO CICLICO</returns>
    ''' <remarks></remarks>
    Public Function ImprimirSobrantesInventario(ByVal IdInventario As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String = ""
        consulta = "SELECT ROW_NUMBER() OVER (ORDER BY T.Ubicación ASC) AS '#', * FROM (SELECT * FROM ( " +
            " SELECT '' AS 'Par',inde_idatado AS 'Atado',inde_idpar 'CONTAR',inde_ubicacionreal AS 'Ubicación', IdCodigo AS 'Clave_Producto',Descripcion AS 'Descripción', ubpa_lote AS 'Lote',ubpa_idcorrida AS 'Corrida',NULL AS 'Total',NULL AS 'Encontrados',NULL AS 'Faltantes',ubpa_talla" +
            " FROM Almacen.InventariosCiclicosDetalles" +
            " JOIN Almacen.UbicacionPares ON ubpa_codigopar = inde_idpar JOIN vestilos ON IdCodigo = ubpa_producto WHERE inde_inventarioid = " + IdInventario.ToString +
            " AND inde_sobra = 1) AS chavs PIVOT (COUNT(chavs.CONTAR) FOR ubpa_talla IN ([12], [12½], [13], [13½], [14], [14½], [15], [15½], [16], [16½], [17], [17½], [18], [18½], [19], [19½], [20], [20½], [21], [21½]," +
            " [22], [22½], [23], [23½], [24], [24½], [25], [25½], [26], [26½], [27], [27½], [28], [28½], [29], [29½], [30], [30½], [31], [31½], [32])) AS pvot " +
            " UNION SELECT * FROM (" +
            " Select '' AS 'Par',inde_idatado,inde_idpar,inde_ubicacionreal,IdCodigo AS 'Clave Producto',Descripcion,ubat_lote,ubat_idcorrida,NULL AS 'total',NULL AS 'Encontrados',NULL AS 'Faltantes',coat_talla" +
            " FROM Almacen.InventariosCiclicosDetalles" +
            " JOIN Almacen.UbicacionAtados ON ubat_codigoatado = ubat_codigoatado JOIN almacen.ContenidoAtados ON coat_codigoatado = ubat_codigoatado AND coat_codigopar = inde_idpar JOIN vestilos ON IdCodigo = coat_producto WHERE inde_inventarioid = " + IdInventario.ToString +
            " AND inde_sobra = 1) AS chavs PIVOT (COUNT(chavs.inde_idpar) FOR coat_talla IN ([12], [12½], [13], [13½], [14], [14½], [15], [15½], [16], [16½], [17], [17½], [18], [18½], [19], [19½], [20], [20½], [21], [21½]," +
            " [22], [22½], [23], [23½], [24], [24½], [25], [25½], [26], [26½], [27], [27½], [28], [28½], [29], [29½], [30], [30½], [31], [31½], [32])) AS pvot " +
            " UNION SELECT * FROM (" +
            " SELECT '' AS 'Par',inde_idatado AS 'Atado',inde_idpar 'CONTAR',inde_ubicacionreal AS 'Ubicación',IdCodigo AS 'Clave Producto',Descripcion AS 'Descripcion',ersp_lote AS 'Lote',ersp_idcorrida AS 'Corrida',NULL AS 'Total',NULL AS 'Encontrados',NULL AS 'Faltantes',ersp_talla" +
            " FROM ALMACEN.InventariosCiclicosDetalles JOIN Almacen.ErroresStatusPar ON ersp_codigopar = inde_idpar JOIN vestilos ON IdCodigo = ersp_producto WHERE inde_inventarioid = " + IdInventario.ToString +
            " AND inde_sobra = 1) AS chavs PIVOT (COUNT(chavs.CONTAR) FOR ersp_talla IN ([12], [12½], [13], [13½], [14], [14½], [15], [15½], [16], [16½], [17], [17½], [18], [18½], [19], [19½], [20], [20½], [21], [21½]," +
            " [22], [22½], [23], [23½], [24], [24½], [25], [25½], [26], [26½], [27], [27½], [28], [28½], [29], [29½], [30], [30½], [31], [31½], [32])) AS pvot " +
            " UNION SELECT * FROM ( " +
            " SELECT '' AS 'Par',inde_idatado AS 'Atado',inde_idpar 'CONTAR',inde_ubicacionreal AS 'Ubicación',IdCodigo AS 'Clave Producto',Descripcion AS 'Descripcion',idtbllote AS 'Lote',idtblTalla AS 'Corrida',NULL AS 'Total',NULL AS 'Encontrados',NULL AS 'Faltantes', Calce" +
            " FROM Almacen.InventariosCiclicosDetalles" +
            " left JOIN tmpDocenasPares t ON inde_idpar = ID_Par left JOIN vestilos v ON v.IdCodigo = t.idtblProducto WHERE  inde_inventarioid = " + IdInventario.ToString + " AND inde_sobra = 1 AND inde_idpar NOT IN (" +
            " SELECT inde_idpar FROM almacen.InventariosCiclicosDetalles JOIN Almacen.UbicacionPares ON ubpa_codigopar = inde_idpar WHERE inde_inventarioid = " + IdInventario.ToString + " AND inde_sobra = 1 " +
            " UNION SELECT inde_idpar FROM almacen.InventariosCiclicosDetalles JOIN Almacen.UbicacionAtados ON ubat_codigoatado = ubat_codigoatado JOIN almacen.ContenidoAtados ON coat_codigoatado = ubat_codigoatado AND coat_codigopar = inde_idpar WHERE inde_inventarioid = " + IdInventario.ToString + " AND inde_sobra = 1 " +
            " UNION SELECT inde_idpar FROM almacen.InventariosCiclicosDetalles JOIN Almacen.ErroresStatusPar ON ersp_codigopar = inde_idpar WHERE inde_inventarioid = " + IdInventario.ToString + " AND inde_sobra = 1)) AS chavs" +
            " PIVOT (COUNT(chavs.CONTAR) FOR Calce IN ([12], [12½], [13], [13½], [14], [14½], [15], [15½], [16], [16½], [17], [17½], [18], [18½], [19], [19½], [20], [20½], [21], [21½], [22], [22½], [23], [23½], [24], [24½], [25], [25½], [26], [26½], [27], [27½], [28], [28½], [29], [29½], [30], [30½], [31], [31½], [32])) AS pvot) AS T" +
            " ORDER BY T.Atado, T.Ubicación, t.Descripción, t.Lote, T.Corrida"
        Return objPersistencia.EjecutaConsulta(consulta)
    End Function

    ''' <summary>
    ''' RECUPERA UNA TABLA CON LOS TOTALES DE LOS INVENTARIOS ELABORADOS, INVENTARIOC SIN ERRORES E INVENTARIOS CON ERRORES QUE ESTEN EN ESTADO "FINALIZADO"
    ''' </summary>
    ''' <returns>TABLA CON LOS TOTALES ENCONTRADOS</returns>
    ''' <remarks></remarks>
    Public Function TotaLInventariosLevantados(ByVal FechaInicio As String, ByVal fechaFin As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String = ""
        consulta = "select (select count(inve_inventariociclicoid) from Almacen.InventariosCiclicos where inve_estadoid=3 and inve_fechainicioejecucion>= '" + FechaInicio + "' and inve_fechafinejecucion<= '" + fechaFin + "') as 'Total'," +
        "(select count(inve_resultadoid) from Almacen.InventariosCiclicos where inve_resultadoid=1 and inve_estadoid=3 and inve_fechainicioejecucion>= '" + FechaInicio + "' and inve_fechafinejecucion<= '" + fechaFin + "') as 'Sin diferencias', 00.00 as '%sin'," +
        "(select count(inve_resultadoid) from Almacen.InventariosCiclicos where inve_resultadoid in (2,3) and inve_estadoid=3 and inve_fechainicioejecucion>= '" + FechaInicio + "' and inve_fechafinejecucion<= '" + fechaFin + "') as 'Con diferencias', 00.00 as '%con'"
        Return objPersistencia.EjecutaConsulta(consulta)
    End Function

    ''' <summary>
    ''' RECUPERA LOS IDS DE LOS INVENTARIOS EN ESTADO FINALIZADO
    ''' </summary>
    ''' <returns>TABLA CON LOS IDS DE LOS INVENTARIOS EN ESTADO "CONCLUIDO"</returns>
    ''' <remarks></remarks>
    Public Function RecuperarIdsInvCi(ByVal FechaInicio As String, ByVal fechaFin As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim Consulta As String = ""
        Consulta = "Select inve_inventariociclicoid FROM ALMACEN.InventariosCiclicos WHERE inve_estadoid=3 and inve_fechainicioejecucion>= '" + FechaInicio + "' and inve_fechafinejecucion<= '" + fechaFin + "'"
        Return objPersistencia.EjecutaConsulta(Consulta)
    End Function

    ''' <summary>
    ''' RECUPERA UNA TABLA CON LOS VALORES DE PARES A ENCONTRAR, PARES ENCONTRADOS Y PARES CON ERRORES(SOBRANTES O FALTANTES) DE TODOS LOS INVENTARIOS CICLICOS EN ESTADO "FINALIZADO"
    ''' </summary>
    ''' <param name="IdsInventarios">VARABLE CON LOS IDENTIFICADORES DE LOS INVENTARIOS EN LOS QUE TENDRA QUE BUSCAR</param>
    ''' <returns>TABLA CON LOS TOTALES DE PARES A ENCONTRAR, ENCONTRADOS SIN ERRORES Y ENCONTRADOS CON ERRORES</returns>
    ''' <remarks></remarks>
    Public Function TotalParesConsultados(ByVal IdsInventarios As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim Consulta As String = ""
        Consulta = "select(select count(inde_inventariodetalleid) from almacen.InventariosCiclicosDetalles where inde_inventarioid in (" + IdsInventarios + ")) as 'TOTAL'," +
            " (select COUNT(inde_existencia)  from almacen.InventariosCiclicosDetalles where inde_inventarioid in (" + IdsInventarios + ")) as 'Correctos', 00.00 as '%sin'," +
            " ((select COUNT (inde_sobra) from almacen.InventariosCiclicosDetalles where inde_inventarioid in (" + IdsInventarios + "))+ " +
            " (select COUNT (inde_falta) from almacen.InventariosCiclicosDetalles where inde_inventarioid in (" + IdsInventarios + "))) as 'Diferencias', 00.00 as '%con'"
        Return objPersistencia.EjecutaConsulta(Consulta)
    End Function

    ''' <summary>
    ''' EJECUTA LA CONSULTA DE LOS PARES DENTRO DE UN INVENTARIO CONCLUIDO Y SUS CARACTERISTICAS CORRESPONDIENTES
    ''' </summary>
    ''' <param name="IdInventarioCilcico">ID DEL INVENTARIO EN EL CUAL SE BUSCARA INFORMACIÓN</param>
    ''' <returns>EJECUCION DE LA CONSULTA PARA RECUPERAR LA TABLA DE LOS PARES DE DETERMINADO INVENTARIO CICLÍCO</returns>
    ''' <remarks></remarks>
    Public Function RecuperarListaParesInventarioConcluido(ByVal IdInventarioCilcico As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@IdInventarioCilcico"
        parametro.Value = IdInventarioCilcico
        listaparametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("Almacen.RecuperarListaParesInventarioConcluido", listaparametros)
        'Dim Consulta As String = "SELECT" +
        '    " 'P' AS 'P/A',a.inde_idpar AS 'Par',a.inde_idatado AS 'Atado',a.inde_ubicacionvirtual AS 'Ubicación Virtual',a.inde_ubicacionreal as 'Ubicación Real',UPPER(f.Descripcion) AS 'Producto'," +
        '    " Talla AS 'Corrida',CAST(e.ubpa_talla AS varchar) AS 'Talla',h.nombre AS 'Cliente',e.ubpa_pedido AS 'Pedido',CAST(e.ubpa_apartado AS varchar) AS 'Apartado',Iniciales AS 'Agte'," +
        '    " CAST(e.ubpa_idtienda AS varchar) AS 'Tienda',j.Nave AS 'Nave',e.ubpa_lote AS 'Lote',CASE WHEN a.inde_existencia IS NULL AND a.inde_sobra IS NULL THEN CAST(0 AS integer) ELSE 1 END AS 'Existencia'," +
        '    " 1 AS 'Prs', CASE WHEN a.inde_sobra = 1 THEN a.inde_sobra ELSE 0 END AS 'Sobra',bahi_bahiaid AS 'Bahía ID',bahi_bloque AS 'Bloque',bahi_nivel AS 'Nivel',bahi_posicion AS 'Posicion'," +
        '    " bahi_color AS 'Color',codr_nombrecorto AS 'Operador',ubpa_fechamodificacion AS 'Fecha'" +
        '    " FROM almacen.InventariosCiclicosDetalles AS a" +
        '    " LEFT JOIN Almacen.UbicacionPares e ON e.ubpa_codigopar = a.inde_idpar LEFT JOIN Nomina.Colaborador d ON d.codr_colaboradorid = e.ubpa_colaboradormodificaid" +
        '    " JOIN vEstilos f ON f.IdCodigo = e.ubpa_producto LEFT JOIN Tallas g ON g.IdTalla = e.ubpa_idcorrida LEFT JOIN vCadenas h ON h.IdCadena = ubpa_idcadena" +
        '    " LEFT JOIN Agentes i ON ubpa_idagente = i.IdAgente LEFT JOIN Naves j ON j.IdNave = ubpa_nave  LEFT JOIN Almacen.Estiba k ON " +
        '    " LEFT(esti_estibaid, CHARINDEX('-', esti_estibaid) - 1) = a.inde_ubicacionvirtual LEFT JOIN Almacen.Bahia ON bahi_bahiaid = esti_bahiaid" +
        '    " WHERE inde_inventarioid = " + IdInventarioCilcico.ToString + " And e.ubpa_codigopar = a.inde_idpar" +
        '    " UNION SELECT " +
        '    " 'P' AS 'P/A',a.inde_idpar AS 'Par',a.inde_idatado AS 'Atado',a.inde_ubicacionvirtual AS 'Ubicación Virtual',a.inde_ubicacionreal as 'Ubicación Real',f.Descripcion AS 'Producto'," +
        '    " Talla AS 'Corrida', CAST(coat_talla AS varchar) AS 'Talla', h.nombre AS 'Cliente', coat_idpedido AS 'Pedido', coat_idapartado AS 'Apartado', Iniciales AS 'Agte', coat_idtienda AS 'Tienda'," +
        '    " Naves.Nave AS 'Nave', e.ubat_lote AS 'Lote', CASE WHEN a.inde_existencia IS NULL AND a.inde_sobra IS NULL THEN CAST(0 AS integer) ELSE 1 END AS 'Existencia', 1 AS 'Prs'," +
        '    " CASE WHEN a.inde_sobra = 1 THEN a.inde_sobra ELSE 0 END AS 'Sobra',bahi_bahiaid AS 'Bahía ID',bahi_bloque AS 'Bloque',bahi_nivel AS 'Nivel',bahi_posicion AS 'Posicion'," +
        '    " bahi_color AS 'Color',codr_nombrecorto AS 'Operador',coat_fechamodificacion AS 'Fecha'" +
        '    " FROM almacen.InventariosCiclicosDetalles AS a" +
        '    " JOIN Almacen.ContenidoAtados ON coat_codigopar = a.inde_idpar JOIN Almacen.UbicacionAtados e ON e.ubat_codigoatado = coat_codigoatado " +
        '    " LEFT JOIN Nomina.Colaborador d ON d.codr_colaboradorid = e.ubat_colaboradormodificaid JOIN vEstilos f ON f.IdCodigo = e.ubat_producto " +
        '    " LEFT JOIN Tallas g ON g.IdTalla = e.ubat_idcorrida LEFT JOIN vCadenas h ON h.IdCadena = e.ubat_idcadena LEFT JOIN Agentes ON e.ubat_idagente = Agentes.IdAgente " +
        '    " LEFT JOIN Naves ON IdNave = e.ubat_nave LEFT JOIN Almacen.Estiba ON LEFT(esti_estibaid, CHARINDEX('-', esti_estibaid) - 1) = a.inde_ubicacionvirtual " +
        '    " LEFT JOIN Almacen.Bahia ON bahi_bahiaid = esti_bahiaid" +
        '    " WHERE inde_inventarioid = " + IdInventarioCilcico.ToString + " AND a.inde_idpar = coat_codigopar" +
        '    " UNION SELECT" +
        '    " 'P' AS 'P/A',a.inde_idpar AS 'Par',a.inde_idatado AS 'Atado',a.inde_ubicacionvirtual AS 'Ubicación Virtual',a.inde_ubicacionreal as 'Ubicación Real',Descripcion AS 'Producto'," +
        '    " Talla AS 'Corrida',CAST(ersp_talla AS varchar) AS 'Talla',h.nombre AS 'Cliente',ersp_pedido AS 'Pedido',ersp_apartado AS 'Apartado',Iniciales AS 'Agte',ersp_idtienda AS 'Tienda'," +
        '    " Naves.Nave AS 'Nave', ersp_lote AS 'Lote', CASE WHEN a.inde_existencia IS NULL AND a.inde_sobra IS NULL THEN CAST(0 AS integer) ELSE 1 END AS 'Existencia', 1 AS 'Prs', " +
        '    " CASE WHEN a.inde_sobra = 1 THEN a.inde_sobra ELSE 0 END AS 'Sobra',bahi_bahiaid AS 'Bahía ID',bahi_bloque AS 'Bloque',bahi_nivel AS 'Nivel',bahi_posicion AS 'Posicion'," +
        '    " bahi_color AS 'Color',codr_nombrecorto AS 'Operador', ersp_fechamodificacion AS 'Fecha'" +
        '    " FROM almacen.InventariosCiclicosDetalles AS a" +
        '    " LEFT JOIN Almacen.ErroresStatusPar ON a.inde_idpar = ersp_codigopar JOIN vEstilos f ON f.IdCodigo = ersp_producto LEFT JOIN Tallas g ON g.IdTalla = ersp_idcorrida " +
        '    " LEFT JOIN vCadenas h ON h.IdCadena = ersp_idcadena LEFT JOIN Agentes ON ersp_idagente = Agentes.IdAgente LEFT JOIN Naves ON IdNave = ersp_nave " +
        '    " LEFT JOIN Almacen.Estiba ON LEFT(esti_estibaid, CHARINDEX('-', esti_estibaid) - 1) = a.inde_ubicacionvirtual LEFT JOIN Almacen.Bahia ON bahi_bahiaid = esti_bahiaid " +
        '    " LEFT JOIN Nomina.Colaborador d ON d.codr_colaboradorid = ersp_colaboradormodificaid" +
        '    " WHERE inde_inventarioid = " + IdInventarioCilcico.ToString + "" +
        '    " UNION SELECT" +
        '    " 'P' AS 'P/A', a.inde_idpar AS 'Par', a.inde_idatado AS 'Atado', a.inde_ubicacionvirtual AS 'Ubicación Virtual', a.inde_ubicacionreal as 'Ubicación Real', Descripcion AS 'Producto'," +
        '    " Talla AS 'Corrida', CAST(B.calce AS varchar) AS 'Talla', h.nombre AS 'Cliente', b.idtblPedido AS 'Pedido', B.idtblOrdApartado AS 'Apartado', 'N/A' AS 'Agte'," +
        '    " B.idtblTienda AS 'Tienda', Naves.Nave AS 'Nave', B.idtbllote AS 'Lote', CASE WHEN a.inde_existencia IS NULL AND a.inde_sobra IS NULL THEN CAST(0 AS integer) ELSE 1 END AS 'Existencia'," +
        '    " 1 AS 'Prs', CASE WHEN a.inde_sobra = 1 THEN a.inde_sobra ELSE 0 END AS 'Sobra', bahi_bahiaid AS 'Bahía ID',bahi_bloque AS 'Bloque',bahi_nivel AS 'Nivel',bahi_posicion AS 'Posicion'," +
        '    " bahi_color AS 'Color','N/A' AS 'Operador',NULL AS 'Fecha'" +
        '    " FROM almacen.InventariosCiclicosDetalles AS a" +
        '    " LEFT JOIN tmpDocenasPares b ON a.inde_idpar = b.ID_Par JOIN vEstilos f ON f.IdCodigo = b.idtblProducto LEFT JOIN Tallas g ON g.IdTalla = b.idtblTalla " +
        '    " LEFT JOIN Distribuciones h ON h.IdDistribucion = b.idtblTienda LEFT JOIN Naves ON IdNave = B.idtblnave LEFT JOIN Almacen.Estiba ON LEFT(esti_estibaid, CHARINDEX('-', esti_estibaid) - 1) = a.inde_ubicacionreal" +
        '    " LEFT JOIN Almacen.Bahia ON bahi_bahiaid = esti_bahiaid" +
        '    " WHERE inde_inventarioid = " + IdInventarioCilcico.ToString + " AND b.ID_Par NOT IN (SELECT" +
        '    " a.inde_idpar FROM Almacen.InventariosCiclicosDetalles a JOIN Almacen.UbicacionPares b ON a.inde_idpar = b.ubpa_codigopar WHERE a.inde_inventarioid = " + IdInventarioCilcico.ToString + " " +
        '    " UNION SELECT a.inde_idpar FROM Almacen.InventariosCiclicosDetalles a JOIN almacen.ContenidoAtados c ON a.inde_idpar = c.coat_codigopar WHERE a.inde_inventarioid = " + IdInventarioCilcico.ToString + " " +
        '    " UNION SELECT a.inde_idpar FROM Almacen.InventariosCiclicosDetalles a JOIN Almacen.ErroresStatusPar d ON a.inde_idpar = d.ersp_codigopar AND a.inde_inventarioid = " + IdInventarioCilcico.ToString + "" +
        '    " )ORDER BY 'Par', Atado ASC"
        'Return objPersistencia.EjecutaConsulta(Consulta)
    End Function

    ''' <summary>
    ''' VERIFICA SI UN OPERADOR EN ESPECIFICO TIENE AKLGUN INVENTARIO CÍCLICO EN ESTADO "EN PROCESO"
    ''' </summary>
    ''' <returns>RESULTADO DE LA CONSULTA DE INVENTARIO EN PROCESO DE UN USUARIO EN ESPECIFICO</returns>
    ''' <remarks></remarks>
    Public Function VerificarInventariosEnProcesoUsuarioLoggueado()
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim Consulta As String
        Consulta = " select inve_inventariociclicoid from almacen.InventariosCiclicos where inve_operadorid=" +
                    Entidades.SesionUsuario.UsuarioSesion.PIDColaboradorUser.ToString + " and inve_estadoid=2 "
        Return objPersistencia.EjecutaConsulta(Consulta)
    End Function

    ''' <summary>
    ''' CAMBIA EL ESTADO DE UN INVENTARIO CICLICO DE "CAPTURADO" A "EN PROCESO" SIEMPRE Y CUANDO EL USUARIO QUE PRETENDE CAMBIAR EL ESTADO DELO INVENTARIO SEA EL 
    ''' USUARIO AL QUE SE LE ASIGNO ESE INVENTARIO CICLICO
    ''' </summary>
    ''' <param name="IdInventario">ID DEL INVENTARIO A ACTUALIZAR</param>
    ''' <returns>TABLA CON UN MENSAJE: Este inventario no esta asignado para ti, solo el usuario al que se le ha asignado este inventario puede iniciarlo.</returns>
    ''' <remarks></remarks>
    Public Function IniciarInventarioCiclico(ByVal IdInventario As Integer)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim Consulta As String = ""
        Consulta = "If (select inve_operadorid from almacen.InventariosCiclicos where inve_inventariociclicoid = " + IdInventario.ToString + ") = " + Entidades.SesionUsuario.UsuarioSesion.PIDColaboradorUser.ToString +
            " BEGIN " +
            "   UPDATE almacen.InventariosCiclicos SET inve_fechainicioejecucion = (select GETDATE()), inve_estadoid = 2," +
            "       inve_usuariomodificoid = " + Entidades.SesionUsuario.UsuarioSesion.PIDColaboradorUser.ToString +
            "   WHERE inve_inventariociclicoid = " + IdInventario.ToString + " End " +
            "ELSE BEGIN  " +
            "   select 'Este inventario no esta asignado para ti, solo el usuario al que se le ha asignado este inventario puede iniciarlo.' End"
        Return objPersistencia.EjecutaConsulta(Consulta)
    End Function

    ''' <summary>
    ''' CONSULTA SI UNA ESTIBA EN ESPECIFICO EXISTE EN LA BASE DE DATOS
    ''' </summary>
    ''' <param name="codigo">CODIGO DE ESTIBA A VALIDAR</param>
    ''' <returns>RESULTADO DE LA CONSULTA DE ESTIBA VALIDA, VALOR BIT</returns>
    ''' <remarks></remarks>
    Public Function Consulta_Estiba_Valido(ByVal codigo As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String = " SELECT CAST(1 AS BIT) AS esti_valida FROM Almacen.Estiba WHERE esti_estibaid = '" + codigo + "' AND esti_activo = 1 "
        Return objPersistencia.EjecutaConsulta(consulta)
    End Function

    ''' <summary>
    ''' CONSULTA SI EL CODIGO DEL PAR LEEIDO EXISTE EN LA TABLA "ALMACEN.INVENTARIOSCICLICOSDETALLES" 
    ''' </summary>
    ''' <param name="Codigo">CODIGO A VERIFICAR</param>
    ''' <param name="IdInventario">INVENTARIO CICLICO AL QUE SE SUPONE QUE PERTENECE EL CODIGO</param>
    ''' <returns>EL ID DEL PAR SI ES QUE LO ENCONTRO EN LA TABLA</returns>
    ''' <remarks></remarks>
    Public Function Consulta_Par_Valido_InventarioCiclicoDetalles(ByVal Codigo As String, ByVal IdInventario As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String = ""
        consulta = "Select inde_idpar from almacen.InventariosCiclicosDetalles where inde_idpar = '" + Codigo + "' and inde_inventarioid =" + IdInventario.ToString
        Return objPersistencia.EjecutaConsulta(consulta)
    End Function

    ''' <summary>
    ''' CONSULTA SÍ EL CODIGO LEEIDO PERTENECE A LA TABLA "ALMACEN.UBICACIONPARES"
    ''' </summary>
    ''' <param name="codigo">CODIGO A VERIFICAR</param>
    ''' <returns>CODIGO DEL PAR ENCONTRADO, EN CASO DE HABERLO ENCONTRADO</returns>
    ''' <remarks></remarks>
    Public Function Consulta_Par_Valido(ByVal codigo As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String = " SELECT * FROM Almacen.UbicacionPares WHERE ubpa_codigopar = '" + codigo + "' "
        Return objPersistencia.EjecutaConsulta(consulta)
    End Function

    ''' <summary>
    ''' CONSULTA SI UN PAR SE ENCUENTRA EN LA TABLA CONTENIDOATADOS
    ''' </summary>
    ''' <param name="Codigo">CODIGO DEL PAR A BUSCAR</param>
    ''' <returns>EJECUCION DE LA CONSULTA CON EL CODIGO DEL PAR SÍ LO ENCONTRO, SI NO NO TRAERA DATOS</returns>
    ''' <remarks></remarks>
    Public Function Consulta_Par_ContenidoAtados(ByVal codigo As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String = " select * from Almacen.ContenidoAtados where coat_codigopar= '" + codigo + "'"
        Return objPersistencia.EjecutaConsulta(consulta)
    End Function

    ''' <summary>
    ''' CONSULTA SI UN PAR SE ENCUENTRA EN LA TABLA TMPERRORESSTATUSPAR
    ''' </summary>
    ''' <param name="Codigo">CODIGO DEL PAR A BUSCAR</param>
    ''' <returns>EJECUCION DE LA CONSULTA CON EL CODIGO DEL PAR SÍ LO ENCONTRO, SI NO NO TRAERA DATOS</returns>
    ''' <remarks></remarks>
    Public Function Consulta_Par_tmpErroresPares(ByVal Codigo As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String = ""
        consulta = "select * from Almacen.ErroresStatusPar where ersp_codigopar = '" + Codigo.ToString + "'"
        Return objPersistencia.EjecutaConsulta(consulta)
    End Function

    ''' <summary>
    ''' BUSCA SI UN PAR EXISTE EN LA TABLA TMPDOCENASPARES
    ''' </summary>
    ''' <param name="codigo">CODIGO DEL PAR A BUSCAR</param>
    ''' <returns>EJECUCION DE LA CONSULTA CON EL RESULTADO DEL PAR ENCONTRADO O NULL SI NO LO ENCONTRO</returns>
    ''' <remarks></remarks>
    Public Function Consulta_Par_tmpDocenasPares(ByVal codigo As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String = " SELECT Descripcion, idtblProducto, calce FROM tmpDocenasPares_entradas WHERE Id_Par = '" + codigo + "'"
        Return objPersistencia.EjecutaConsulta(consulta)
    End Function

    ''' <summary>
    ''' AGREGAR UN PAR A LA TMPERRORESSTATUSPAR CUANDO NO ENCONTRO EL PAR EN LAS TABLAS UBICACIONPARES, CONTENIDOATADOS NI ERRORESSTATUSPAR
    ''' </summary>
    ''' <param name="CodigoPar">CODIGO DEL PAR</param>
    ''' <param name="EstibaId">ESTIBA EN LA QUE SE ESCANEO</param>
    ''' <param name="IdUsuario">ID DEL USUARIO QUE LO ESCANEO</param>
    ''' <remarks></remarks>
    Public Sub AgregarParAErroresStatusPar(ByVal CodigoPar As String, ByVal EstibaId As String, ByVal IdUsuario As Integer)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim ListaParametros As New List(Of SqlParameter)

        ''@CodigoPar as varchar(50)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "@CodigoPar"
        parametro.Value = CodigoPar
        ListaParametros.Add(parametro)

        '@estibaid as String
        parametro = New SqlParameter
        parametro.ParameterName = "@estibaid"
        parametro.Value = EstibaId
        ListaParametros.Add(parametro)

        '@Usuario as int
        parametro = New SqlParameter
        parametro.ParameterName = "@colaboradorcreoid"
        parametro.Value = IdUsuario
        ListaParametros.Add(parametro)

        objPersistencia.EjecutarSentenciaSP("Almacen.SP_Alta_Par_ErroresStatusPar_InventarioCiclico", ListaParametros)
    End Sub

    ''' <summary>
    ''' EJECUTA EL PROCEDIMIENTO ALMACENADO PARA AGREGAR/MODIFICAR EL PAR ESCANEADO A LA TABLA INVENTARIO CICLICO DETALLE, 
    ''' Y REGRESA LAS CANTIDADES ACTUALIZADAS DE PARES SOBRANTES Y PARES ENCONTRADOS DEL INVENTARIO CICLICO EN CUESTION
    ''' </summary>
    ''' <param name="IdInventarioCiclico">ID DEL INVENTARIO A ACTUALIZAR</param>
    ''' <param name="CodigoPar">CODIGO DEL PAR A AGREGAR O MODIFICAR</param>
    ''' <param name="Estiba">ESTIBA EN LA QUE SE ENCONTRO EL PAR</param>
    ''' <param name="IdUsuario">UUARIO QUE ESCANEO EL PAR</param>
    ''' <returns>TOTAL DE PARES ENCONTRADOS Y PARES SOBRANTES HASTA EL MONENTO DENTRO DE EL INVENTARIO CÍCLICO</returns>
    ''' <remarks></remarks>
    Public Function AgregarParEscaneadoICIDetalle(ByVal IdInventarioCiclico As Integer, ByVal CodigoPar As String, ByVal Estiba As String, _
                                      ByVal IdUsuario As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim ListaParametros As New List(Of SqlParameter)

        ''@CodigoPar as varchar(50)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "@CodigoPar"
        parametro.Value = CodigoPar
        ListaParametros.Add(parametro)

        '@IdInventario as integer
        parametro = New SqlParameter
        parametro.ParameterName = "@IdInventario"
        parametro.Value = IdInventarioCiclico
        ListaParametros.Add(parametro)

        '@Ubicacion as varchar(50)
        parametro = New SqlParameter
        parametro.ParameterName = "@Ubicacion"
        parametro.Value = Estiba
        ListaParametros.Add(parametro)

        '@Usuario as int
        parametro = New SqlParameter
        parametro.ParameterName = "@Usuario"
        parametro.Value = IdUsuario
        ListaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("Almacen.SP_Escaneo_Par_Inventario_Ciclico", ListaParametros)
    End Function

    ''' <summary>
    ''' RECUPERA EL TOTAL DE PARES, TOTAL DE PARES FALTANTES, TOTAL DE PARES SOBRANTES Y TOTAL DE PARES ENCONTRADOS DE DETERMINADO INVENTARIO CICLICO
    ''' CUANDO ESTA EN ESTADO "EN PROCESO". 
    ''' </summary>
    ''' <param name="IdInventario">ID DEL INVENTARIO EN EL QUE BUSCARA INFORMACIÓN</param>
    ''' <returns>EJECUCION DE LA CONSULTA</returns>
    ''' <remarks></remarks>
    Public Function CargarTotalParesInventarioEnProceso(ByVal IdInventario As Integer)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim Consulta As String = ""
        Consulta = "select  count (*)-count(inde_sobra) as 'Pares' , count(inde_existencia) as 'Encontrados', " +
            " COUNT(*) - COUNT(inde_sobra) - COUNT(inde_existencia) 'Faltantes',count(inde_sobra) as 'Sobrantes'" +
            " from Almacen.InventariosCiclicosDetalles where inde_inventarioid = " + IdInventario.ToString
        Return objPersistencia.EjecutaConsulta(Consulta)
    End Function

    ''' <summary>
    ''' ACTUALIZA EL ESTADO DEL INVENTARIO CICLICO DE "EN PROCESO" A FINALIZADO, TOTAL DE PARES ENCONTRADOS, TOTAL FALTANTES Y TOTAL DE PARES SOBRANTES, FECHA FIN DE EJECUCION
    ''' USUAIRO QUE MODIFICO, Y EL RESULTADO FINAL(sIN DIFERENCIAS, CON FALTANTES, CON SOBRANTES)
    ''' </summary>
    ''' <param name="IdInventarioCiclico">ID DEL INVENTARIO A CERRAR</param>
    ''' <param name="Total">TOTAL DE PARES</param>
    ''' <param name="Nbien">TOTAL DE PARES BIEN</param>
    ''' <param name="NFaltante">TOTAL DE PARES FALTANTES</param>
    ''' <param name="NSobrantes">TOTAL DE PARES SOBRANTES</param>
    ''' <param name="IdUsuaio">ID DEL USUARIO QUE FINALIZO</param>
    ''' <remarks></remarks>
    Public Sub CerrarInventarioCiclico(ByVal IdInventarioCiclico As Integer, ByVal Total As Integer, ByVal Nbien As Integer, _
                                   ByVal NFaltante As Integer, ByVal NSobrantes As Integer, ByVal IdUsuaio As Integer)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String = ""
        consulta = "update almacen.InventariosCiclicos SET inve_estadoid = 3,inve_fechafinejecucion= (select GETDATE()),  inve_usuariomodificoid = " + Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid.ToString + ", inve_fechamodificacion = (select GETDATE()) , inve_totalparesbien = " + Nbien.ToString
        consulta += ", inve_totalparesfaltantes =" + NFaltante.ToString + ", inve_totalparessobrantes = " + NSobrantes.ToString + ", inve_resultadoid ="
        If Nbien = Total And NFaltante = 0 And NSobrantes = 0 Then
            consulta += "1"
        ElseIf Nbien = Total And NFaltante = 0 And NSobrantes > 0 Then
            consulta += "3"
        Else
            consulta += "2"
        End If
        consulta += "  where inve_inventariociclicoid = " + IdInventarioCiclico.ToString
        objPersistencia.EjecutaConsulta(consulta)
    End Sub

    ''' <summary>
    ''' ACTUALIZA LOS PARES FALTANTES DE NULL A 1 AL FINALIZAR UN INVENTARIO CÍCLICO, SIEMPRE Y CUANDO EL CAMPO DE EXISTENCIA Y EL CAMPO DE SOBRA SEAN NULL
    ''' </summary>
    ''' <param name="IdInventariociclico"></param>
    ''' <remarks></remarks>
    Public Sub CerrarInventarioCiclicoDetalle(ByVal IdInventariociclico As Integer)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String = ""
        consulta = "  UPDATE Almacen.InventariosCiclicosDetalles set inde_falta = 1 WHERE inde_inventarioid =" + IdInventariociclico.ToString +
                    " and inde_existencia is null and inde_sobra is null"
        objPersistencia.EjecutaConsulta(consulta)
    End Sub

    ''' <summary>
    ''' VERIFICA SÍ UN CODIGO DE ATADO EXISTE EN LA TABLA UBICACION ATADO Y LO RECUPERA
    ''' </summary>
    ''' <param name="Codigo">ATADO A VERIFICAR</param>
    ''' <returns>CONSULTA CON EL RESULTADO DE LA BUSQUEDA DEL ATADO</returns>
    ''' <remarks></remarks>
    Public Function VerificarAtadoUbicacionAtados(ByVal Codigo As String)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String = ""
        consulta = "select ubat_codigoatado from Almacen.UbicacionAtados where ubat_codigoatado = '" + Codigo + "'"
        Return objPersistencia.EjecutaConsulta(consulta)
    End Function

    ''' <summary>
    ''' VERIFICA SI UN CODIGO DE ATADO EXISTE EN LA TABLA LOTESDOCENAS Y LO RECUPERA
    ''' </summary>
    ''' <param name="Codigo">CODIGO DEL ATADO A RECUPERAR</param>
    ''' <returns>RESULTADO DE LA CONSULTA DE CODIGO DE ATADO</returns>
    ''' <remarks></remarks>
    Public Function VerificarAtadoLotesDocenas(ByVal Codigo As String)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String = ""
        consulta = "select IdDocena from LotesDocenas where IdDocena = '" + Codigo + "'"
        Return objPersistencia.EjecutaConsulta(consulta)
    End Function

    ''' <summary>
    ''' RECUPERA LOS CODIGOS DE PARES PERTENECIENTES A UN DETERMIADO ATADO EN LA TABLA CONTENIDOATADOS
    ''' </summary>
    ''' <param name="Codigo">CODIGO DEL ATADO DEL QUE SE RECUPERARAN LOS PARES</param>
    ''' <returns>RECULTADO DE LA EJECUCION DE LA CONSUTA</returns>
    ''' <remarks></remarks>
    Public Function RecuperarParesAtadoContenidoAtado(ByVal Codigo As String)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String = ""
        consulta = "select coat_codigopar from Almacen.ContenidoAtados where coat_codigoatado = '" + Codigo + "'"
        Return objPersistencia.EjecutaConsulta(consulta)
    End Function

    ''' <summary>
    ''' RECUPERA LOS CODIGOS DE PARES PERTENECIENTES A UN DETERMIADO ATADO EN LA TABLA TMPDOCENASPARES
    ''' </summary>
    ''' <param name="Codigo">CODIGO DEL ATADO DEL QUE SE RECUPERARAN LOS PARES</param>
    ''' <returns>RECULTADO DE LA EJECUCION DE LA CONSUTA</returns>
    ''' <remarks></remarks>
    Public Function RecuperarParesAtadotmpDocenasPares(ByVal Codigo As String)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String = ""
        consulta = "select ID_Par from tmpDocenasPares where ID_Docena = '" + Codigo + "'"
        Return objPersistencia.EjecutaConsulta(consulta)
    End Function

    ''' <summary>
    ''' RECUPERA LA INFORMACION DE LA BAHIA DE  UNA ESTIBA EN ESPECIFICO
    ''' </summary>
    ''' <param name="Estiba">ESTIBA EN LA QUE SE RECUPERARA LA INFORMACION DE SU BAHIA</param>
    ''' <returns>EJECUCION DE LA CONSULTA CON SU RESULTADO</returns>
    ''' <remarks></remarks>
    Public Function RecuperarDatosUbicacionReal(ByVal Estiba As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String
        consulta = "select bahi_bahiaid as 'Bahía ID', bahi_bloque as 'Bloque', bahi_nivel as 'Nivel', bahi_posicion as 'Posicion', bahi_color as 'Color'" +
            " from Almacen.Bahia join Almacen.Estiba on esti_bahiaid = bahi_bahiaid and LEFT(esti_estibaid, CHARINDEX('-', esti_estibaid) -1) = '" + Estiba + "'"
        Return objPersistencia.EjecutaConsulta(consulta)
    End Function


End Class
