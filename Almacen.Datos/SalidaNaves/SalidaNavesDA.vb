Imports Persistencia
Imports System.Data.SqlClient
Imports System.Collections.Generic

Public Class SalidaNavesDA
    Public Function validarexterna(ByVal idNave As Integer) As Boolean
        Dim objPersistencia As New OperacionesProcedimientosSICY
        Dim consulta As String = <cadena>
            select externa from naves where IdNave=<%= idNave %>
                                 </cadena>
        Dim d As New DataTable
        d = objPersistencia.EjecutaConsulta(consulta)

        If d.Rows(0).Item(0) = True Then
            Return True
        Else
            Return False
        End If


    End Function
    ''' <summary>
    ''' Recupera el precio del par escaneado
    ''' </summary>
    ''' <param name="lote"></param>
    ''' <param name="año"></param>
    ''' <param name="idNave"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function VerificarAtadoValido_RecuperaPrecioLote(ByVal lote As Integer, ByVal año As Integer, ByVal idNave As Integer) As Integer
        Dim objPersistencia As New OperacionesProcedimientosSICY
        Dim consulta As String = <cadena>
            select top(1) isnull(v.pptd_precio,0) from tmpDocenasPares_Entradas t
        inner join vcatProductos c on IdCodigo=idtblProducto and IdCorrida=idtblTalla and c.IdNave=<%= idNave %>
            left join Proveedores.VPrecioProductoTerminadoDetalles v 
        ON v.pptd_productoid=c.IdProducto  where idtbllote=<%= lote %> and idtblaño=<%= año %> and t.idtblnave=<%= idNave %> and v.pptd_precio is not null
                                 </cadena>
        Dim d As New DataTable
        d = objPersistencia.EjecutaConsulta(consulta)
        Dim precio As Double
        Try
            precio = d.Rows(0).Item(0)
        Catch ex As Exception
            precio = 0
        End Try

        Return precio
    End Function
    ''' <summary>
    ''' EJECUTA LA CONSULTA PARA RECUPERAR LA INFORMACION DE LOS OPERADORES QUE PERTENECEN A CIERTA NAVE
    ''' </summary>
    ''' <param name="IdNave"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ComboOperadoresSegunNave(ByVal IdNave As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String = String.Empty
        consulta = "select * from prdoperadores where naves like '" + IdNave.ToString + ",%' or naves = '" + IdNave.ToString + "'"
        Return operaciones.EjecutaConsulta(consulta)
    End Function
    ''' <summary>
    ''' VERIFICA SI EL CODIGO LEEIDO PERTENECE A UN ATADO VALIDO EN ESTADO 0, SÍ ES ASI RECUPERA LA INFORMACION DE ESE ATADO DE LA TABLA TMPLOTESDOCENAS
    ''' </summary>
    ''' <param name="CodigoAtado">CODIGO DEL POSIBLE ATADO A VERIFICAR</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function VerificarAtadoValido_RecuperaInformacionLote(ByVal CodigoAtado As String) As DataTable
        Dim objPersistencia As New OperacionesProcedimientosSICY
        Dim consulta As String = ""
        consulta = " SELECT TOP 1 ID_Docena AS 'Atado', " +
                   "     idtblnave AS 'Nave',  " +
                   "     idtbllote AS 'Lote', " +
                   "     idtblaño AS 'Año',  " +
                   "    Descripcion AS 'Descripción',  " +
                   "     SUBSTRING(ID_Docena, LEN(ID_Docena),1) AS 'N_Pares',  " +
                    "    No_Atado as 'No_Atado',  " +
                   "     idtblcte AS 'IdCliente'  " +
                   " FROM tmpDocenasPares_Entradas  " +
                   " WHERE ID_Docena = '" + CodigoAtado + "' "

        'consulta = "SELECT TOP 1 ID_Docena AS 'Atado', idtblnave AS 'Nave', idtbllote AS 'Lote', idtblaño AS 'Año', Descripcion AS 'Descripción', " +
        '        " (SELECT COUNT(Pares)" +
        '        " FROM tmpDocenasPares_Entradas WHERE ID_Docena = '" + CodigoAtado + "') AS 'N_Pares', No_Atado as 'No_Atado', idtblcte AS 'IdCliente'" +
        '        " FROM tmpDocenasPares_Entradas WHERE ID_Docena = '" + CodigoAtado + "'" '' and Status = 0"
        Return objPersistencia.EjecutaConsulta(consulta)
    End Function
    ''' <summary>
    ''' VERIFICA SI EL CODIGO LEEIDO PERTENECE A UN ATADO VALIDO en estado 1, SÍ ES ASI RECUPERA LA INFORMACION DE ESE ATADO DE LA TABLA TMPLOTESDOCENAS
    ''' </summary>
    ''' <param name="CodigoAtado">CODIGO DEL POSIBLE ATADO A VERIFICAR</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ValidarAtadoIngresadoAnteriormente(ByVal CodigoAtado As String) As DataTable
        Dim objPersistencia As New OperacionesProcedimientosSICY
        Dim consulta As String = ""
        consulta = "SELECT TOP 1 ID_Docena AS 'Atado', idtblnave AS 'Nave', idtbllote AS 'Lote', idtblaño AS 'Año', Descripcion AS 'Descripción', " +
                " (SELECT COUNT(Pares) FROM tmpDocenasPares_Entradas WHERE ID_Docena = '" + CodigoAtado + "') AS 'N_Pares', No_Atado as 'No_Atado', idtblcte AS 'IdCliente'" +
                " FROM tmpDocenasPares_Entradas WHERE ID_Docena = '" + CodigoAtado + "' and Status = 1"
        Return objPersistencia.EjecutaConsulta(consulta)
    End Function

    ''' <summary>
    ''' EJECUTA EL PROCEDIMIENTO ALMACENADO PARA DAR DE ALTA UN REGISTRO EN LA TABLA Almacen.SALIDANAVES Y RECUPERAR
    ''' EL ID DEL REGITRO AGREGADO
    ''' </summary>
    ''' <param name="IdNave">NAVE QUE SE USARA PARA DAR DE ALTA EL REGISTRO DE SALIDANAVES</param>
    ''' <param name="Operador">OPERADOR QUE SE USARA PARA DAR DE ALTA EL REGISTRO DE SALIDANAVES</param>
    ''' <param name="TipoNave">TIPO NAVE QUE SE USARA PARA DAR DE ALTA EL REGISTRO DE SALIDANAVES</param>
    ''' <returns>ID DEL REGISTRO AGREGADO</returns>
    ''' <remarks></remarks>
    Public Function IniciarSalidaNave(ByVal IdNave As Integer, ByVal Operador As Integer, ByVal TipoNave As Boolean)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@NaveId"
        parametro.Value = IdNave
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@IperadorId"
        parametro.Value = Operador
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@TipoNave"
        parametro.Value = TipoNave
        listaparametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("Almacen.SP_IniciarSalidaNave", listaparametros)
    End Function

    ''' <summary>
    ''' EJECUTA EL PROCEDIMIENTO ALMACENADO PARA AGREGAR VALIDAR QUE UN LOTE ESTA EN ESTADO CONCLUIDO
    ''' ''' </summary>
    ''' <param name="DatosAtado">ENTIDAD CON VARIABLES LLENAS DE INFORMACION UTILIZADA POR EL PROCEDIMIENTO ALMACENADO</param>
    ''' <param name="IdSalidaNAve">ID DE EL REGISTRO DE LA TABLA SALIDANAVES SOBRE LA QUE SE ESTARA TRABAJANDO</param>
    ''' <remarks></remarks>
    Public Function ValidarLoteTerminado(ByVal DatosAtado As Entidades.CapturaAtadoValido, ByVal IdSalidaNAve As Integer)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@SalidaNaveId"
        parametro.Value = IdSalidaNAve
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@CodigoAtado"
        parametro.Value = DatosAtado.PIdAtado
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Lote"
        parametro.Value = DatosAtado.PLote
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@NaveId"
        parametro.Value = DatosAtado.PIdNAve
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Año"
        parametro.Value = DatosAtado.PAño
        listaparametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("Almacen.SP_Validar_Lote_Completo", listaparametros)
    End Function

    ''' <summary>
    ''' RECUPERA EL CODIGO DE ATADO, NUMERO DE ATADO, LOTE, DESCRIPCION, AÑO DE ATADO DE UN ATADO DETERMINADO PERTENECIENTE A UNA SALIDA DE NAVES DETERMINADA
    ''' </summary>
    ''' <param name="Atado">ATADO DEL CUAL SE RECUPERARA LA INFORMACION</param>
    ''' <param name="idSalidaNave">ID DE LA SALIDA DE NAVE DE LA CUAL SE RECUPERARA LA INFORMACION</param>
    ''' <returns>RESULTADO DE LA EJECUCION DE LA CUNSULTA</returns>
    ''' <remarks></remarks>
    Public Function recuperarDatosAtadoSalidaNavesDetalles(ByVal Atado As String, ByVal idSalidaNave As Integer, ByVal IdNave As Integer)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String
        consulta = "select distinct snde_codigoatado AS 'ATADO', snde_numero_atado AS '#',snde_lote AS 'LOTE', Descripcion AS 'DESCRIPCION', snde_año as 'AÑO'"
        If IdNave <> 1 And IdNave <> 2 And IdNave <> 3 And IdNave <> 7 And IdNave <> 11 And IdNave <> 15 And IdNave <> 10 And IdNave <> 18 And IdNave <> 5 And IdNave <> 14 And IdNave <> 60 Then
            consulta += " from Almacen.SalidaNavesDetalles "
        Else
            consulta += " from Almacen.SalidaNavesDetalles_" + IdNave.ToString
        End If
        consulta += " join vEstilos on IdCodigo = snde_idproducto " +
        " where snde_codigoatado =  '" + Atado + "' AND snde_salidanavesid = " + idSalidaNave.ToString
        Return objPersistencia.EjecutaConsulta(consulta)
    End Function

    ''' <summary>
    ''' EJECUTA CONSULTA PARA RECUPERAR EL TOTAL DE PARES QUE SE DEBIERON DE HABER LEIDO COMO SOBRANTES, COMO FALTANTES Y COMO CORRECTO
    ''' </summary>
    ''' <param name="Atado">ID DEL ATADO</param>
    ''' <returns>EJECUCION DE LA CONSULTA PARA ENCONTRAR LAS CANTIDADES</returns>
    ''' <remarks></remarks>
    Public Function Recuperar_Totales_Pares_De_Atado_Segun_Estatus(ByVal IdSalidaNave As Integer, ByVal Atado As String, ByVal Proceso As String, ByVal Tipo_Nave As Boolean, IdNave As Integer)
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim Consulta As String = String.Empty
        If Proceso = "SALIDA" And Tipo_Nave = False Then
            Consulta = " select snde_codigopar AS 'PAR', snde_codigoatado as 'ATADO', snde_resultadoid_par AS 'RESULTADO', snde_numero_par as 'Numero_Par' "
            If IdNave <> 1 And IdNave <> 2 And IdNave <> 3 And IdNave <> 7 And IdNave <> 11 And IdNave <> 15 And IdNave <> 10 And IdNave <> 18 And IdNave <> 5 And IdNave <> 14 And IdNave <> 60 Then
                Consulta += " from Almacen.SalidaNavesDetalles  "
            Else
                Consulta += " from Almacen.SalidaNavesDetalles_" + IdNave.ToString
            End If
            Consulta += " where snde_salidanavesid = " + IdSalidaNave.ToString + " AND snde_codigoatado =" + Atado.ToString
        Else
            Consulta = " select snde_codigopar AS 'PAR', snde_codigoatado as 'ATADO', snde_resultadoid_par_entrada AS 'RESULTADO', snde_numero_par as 'Numero_Par' "
            If IdNave <> 1 And IdNave <> 2 And IdNave <> 3 And IdNave <> 7 And IdNave <> 11 And IdNave <> 15 And IdNave <> 10 And IdNave <> 18 And IdNave <> 5 And IdNave <> 14 And IdNave <> 60 Then
                Consulta += " from Almacen.SalidaNavesDetalles  "
            Else
                Consulta += " from Almacen.SalidaNavesDetalles_" + IdNave.ToString
            End If
            Consulta += " where snde_salidanavesid = " + IdSalidaNave.ToString + " AND snde_codigoatado =" + Atado.ToString
        End If

        Return operaciones.EjecutaConsulta(Consulta)
    End Function

    ''' <summary>
    ''' ACTUALIZA EL ESTATUS DE UN ATADO 
    ''' </summary>
    ''' <param name="Atado">ATADO A ACTUALIZAR</param>
    ''' <param name="Status">ESTADO CORRESPONDIENTE DEL ATADO ESCANEADO</param>
    ''' <param name="IdSalidaNave">ID DE LA SALIDA DE NAVE A LA QUE PERTENECE EL ATADO</param>
    ''' <param name="Año">AÑO DEL LOTE DEL ATADO</param>
    ''' <param name="Num_Pares">NUMERO DE PARES QUE SE ESCANEARON EN EL ATADO</param>
    ''' <param name="Lote">LOTE DEL ATADO</param>
    ''' <param name="NaveId">ID DE LA NAVE DEL ATADO</param>
    ''' <remarks></remarks>
    Public Sub ActualizarEstatusDeAtadoN(ByVal Atado As String, ByVal Status As Integer, ByVal IdSalidaNave As Integer, ByVal Año As Integer, ByVal ParxPar As Boolean, ByVal Num_Pares As Integer _
                                         , ByVal Lote As Integer, ByVal NaveId As Integer, ByVal Proceso As String, ByVal TipoNave As Boolean, ByVal IdCarrito As Integer)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@Atado"
        parametro.Value = Atado
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Status"
        parametro.Value = Status
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@IdSalidaNave"
        parametro.Value = IdSalidaNave
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Año"
        parametro.Value = Año
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@ParxPar"
        parametro.Value = ParxPar
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Lote"
        parametro.Value = Lote
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Pares"
        parametro.Value = Num_Pares
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@NaveId"
        parametro.Value = NaveId
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Proceso"
        parametro.Value = Proceso
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@TipoNave"
        parametro.Value = TipoNave
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@IdCarrito"
        parametro.Value = IdCarrito
        listaparametros.Add(parametro)

        objPersistencia.EjecutarConsultaSP("Almacen.SP_Actualizar_Estatus_Atado_SalidaNavesDetalles_PB", listaparametros)
    End Sub

    ''' <summary>
    ''' BUSCA SI UN PAR EXISTE EN LA TABLA TMPDOCENASPARES
    ''' </summary>
    ''' <param name="codigo">CODIGO DEL PAR A BUSCAR</param>
    ''' <returns>EJECUCION DE LA CONSULTA CON EL RESULTADO DEL PAR ENCONTRADO O NULL SI NO LO ENCONTRO</returns>
    ''' <remarks></remarks>
    Public Function Consulta_Par_tmpDocenasPares(ByVal codigo As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String = " SELECT * FROM tmpDocenasPares_Entradas WHERE Id_Par = '" + codigo + "' AND Status = 0"
        Return objPersistencia.EjecutaConsulta(consulta)
    End Function

    ''' <summary>
    ''' EJECUTA EL PROCEDIMIENTO ALMACENADO PARA ACTUALIZAR EL PAR DE UN REGISTRO DE EMBARQUE DE UN DETERMINADO, SÍ NO PERTENECE AL ATADO ENTONCES LO AGREGARA
    ''' COMO SOBRANTE
    ''' </summary>
    ''' <param name="cadena">CODIGO DEL PAR</param>
    ''' <param name="AtadoActual">ATADO ACTUAL</param>
    ''' <param name="IdSalidaNave">ID SALIDA NAVE SOBRE LA QUE SE ESTA TRABAJANDO</param>
    ''' <param name="AñoAtadoActual">AÑO DEL ATADO ACTUAL SOBRE EL QUE SE ESTA TRABAJANDO</param>
    ''' <param name="loteAtadoActual">LOTE AL QUE PERTENECE EL ATADO SOBRE EL QUE SE ESTA TRABAJANDO</param>
    ''' <param name="IdNave">NAVE DE LA QUE SE ESTA LEVANTANDO EL EMBARQUE</param>
    ''' <remarks></remarks>
    Public Function ActualizarEstatusPar(ByVal cadena As String, ByVal AtadoActual As String, ByVal IdSalidaNave As Integer, ByVal AñoAtadoActual As Integer, ByVal loteAtadoActual As Integer, _
                                         ByVal IdNave As Integer, ByVal Talla As String, ByVal NumeroPar As Integer, ByVal TipoEscaneo As Boolean, ByVal IdProducto As String, _
                                         ByVal Descripcion As String, ByVal Proceso As String, ByVal Tipo_Nave As Boolean, ByVal IdCarrito As Integer)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@CodigoPar"
        parametro.Value = cadena
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@CodigoAtado"
        parametro.Value = AtadoActual
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@IdSalidaNAve"
        parametro.Value = IdSalidaNave
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@NaveId"
        parametro.Value = IdNave
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@AñoLote"
        parametro.Value = AñoAtadoActual
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Lote"
        parametro.Value = loteAtadoActual
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@talla"
        parametro.Value = Talla
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Numero_Par"
        parametro.Value = NumeroPar
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@TipoEscaneo"
        parametro.Value = TipoEscaneo
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Id_Producto"
        parametro.Value = IdProducto
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Descripcion"
        parametro.Value = Descripcion
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Proceso"
        parametro.Value = Proceso
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Tipo_Nave"
        parametro.Value = Tipo_Nave
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@IdCarrito"
        parametro.Value = IdCarrito
        listaparametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("Almacen.SP_SalidaNavesDetalles_Actualizar_Estatus_ParesExistentes_Agregar_ParesSobrantes_PB", listaparametros)
    End Function

    ''' <summary>
    ''' EJECUTA EL PROCEDIMIENTO ALMACENADO PARA AGREGAR LOS PARES DE UN ATADO EN ESPECIFICO A LA TABLA Almacen.SALIDANAVESDETALLES
    ''' </summary>
    ''' <param name="IdSalidaNave">ID DE LA SALIDA DE NAVE SOBRE LA QUE SE ESTA TRABAJANDO</param>
    ''' <param name="Atado">CODIGO DE ATADO DEL QUE SE RECUPERARAN LOS PARES A AGREGAR EN LA TABÑA</param>
    ''' <param name="Lote">LOTE DEL ATADO</param>
    ''' <param name="Año">AÑO DEL LOTE DEL ATADO</param>
    ''' <param name="IdNave">ID DE LA NAVE EN LA QUE SE DARA LA SALIDA</param>
    ''' <remarks></remarks>
    Public Sub AgregarParesAtadoActual(ByVal AtadoIncluidoEnSalida As Boolean, ByVal IdSalidaNave As Integer, ByVal Atado As String, ByVal Lote As Integer, ByVal Año As Integer, ByVal IdNave As Integer, ByVal NumAtado As Integer, _
                                       ByVal LecturaParXPar As Boolean, ByVal Proceso As String, ByVal TipoCodigo As String, ByVal TipoNave As Boolean, ByVal IdCarrito As Integer, ByVal LoteTerminado As Boolean)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@IdSalidaNAve"
        parametro.Value = IdSalidaNave
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Atado"
        parametro.Value = Atado
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Lote"
        parametro.Value = Lote
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Año"
        parametro.Value = Año
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@IdNave"
        parametro.Value = IdNave
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@NumAtado"
        parametro.Value = NumAtado
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@ParXPar"
        parametro.Value = LecturaParXPar
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Proceso"
        parametro.Value = Proceso
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@TipoCodigo"
        parametro.Value = TipoCodigo
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@TipoNave"
        parametro.Value = TipoNave
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@IdCarrito"
        parametro.Value = IdCarrito
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@LoteTerminado"
        parametro.Value = LoteTerminado
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@AtadoIncluidoEnSalida"
        parametro.Value = AtadoIncluidoEnSalida
        listaparametros.Add(parametro)

        objPersistencia.EjecutarConsultaSP("Almacen.SP_Agregar_Pares_de_Atado_salidanavesdetalles_PB", listaparametros)
    End Sub

    ''' <summary>
    ''' CONSULTA LA TALLA DE UN PAR EN LA TABLA TMPDOCENAPARES
    ''' </summary>
    ''' <param name="Codigo">CODIGO DEL PAR DEL CUAL SE RECUPERARA LA TALLA</param>
    ''' <returns>EJECUCION DE LA CONSULTA</returns>
    ''' <remarks></remarks>
    Public Function RecuperarTalla(ByVal Codigo As String)
        Dim objPersistencia As New OperacionesProcedimientosSICY
        Dim consulta As String = ""
        consulta = "select calce as 'talla', Descripcion, idtblproducto from tmpDocenasPares_Entradas where ID_Par = '" + Codigo + "'"
        Return objPersistencia.EjecutaConsulta(consulta)
    End Function

    ''' <summary>
    ''' CONSULTA LA TALLA DE UN CODIGO DE CLIENTE 
    ''' </summary>
    ''' <param name="CodigoEscaneado"></param>
    ''' <param name="IdCliente"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Validar_Codigo_De_Cliente(ByVal CodigoEscaneado As String, ByVal IdCliente As Integer, ByVal Codigos As String)
        Dim objPersistencia As New OperacionesProcedimientosSICY
        Dim consulta As String
        '''''''''''''''''''''''''''''''''''''''''quitar el like cuando se corrijan los codigos de andrea con 0 
        consulta = " select talla, idcodigo from Codigos_Clientes  where codigo like '%" + CodigoEscaneado + "' and idcadena = " + IdCliente.ToString + " and  estatus = 'A' " +
            " and idcodigo in (" + Codigos + ")"
        Return objPersistencia.EjecutaConsulta(consulta)
    End Function

    ''' <summary>
    ''' RECUPERA LOS PARES DEL ATADO CON SUS RESPECTIVOS CODIGOS DE CLIENTE
    ''' </summary>
    ''' <param name="IdAtado">CODIGO DE ATADO DEL QUE RECUPERARA LOS DATOS</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Recuperar_dtPares_Para_Escanea_CodClientes(ByVal IdAtado As String)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String = ""
        consulta = "SELECT LTRIM(RTRIM(ID_Docena)) AS 'ATADO', LTRIM(RTRIM(ID_Par)) AS 'PAR', LTRIM(RTRIM(CALCE)) AS 'TALLA'," +
            " CASE WHEN LTRIM(RTRIM(Cod_Cliente)) LIKE '0%' THEN SUBSTRING((LTRIM(RTRIM(COD_CLIENTE))), 2, LEN(LTRIM(RTRIM(COD_CLIENTE)))) ELSE ltrim(rtrim(Cod_Cliente))" +
            " END AS 'CODIGO_CLIENTE', 2 AS 'Estado', Descripcion AS 'Descripcion'," +
            " idtblproducto AS 'Id_Producto',ROW_NUMBER() OVER (ORDER BY ID_Par ASC) AS '#' " +
            " FROM tmpDocenasPares_Entradas WHERE ID_Docena = '" + IdAtado + "'"
        Return objPersistencia.EjecutaConsulta(consulta)
    End Function

    ''' <summary>
    ''' REGRESA UN RESULTADO DE TIPO ENTERO CUANDO ENCUENTRA UNA SALIDA DE NAVE PENDIENTE EN PROCESO PARA DETERMINADA NAVE
    ''' </summary>
    ''' <param name="IdNave"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ValidarSalidasPendientes(ByVal IdNave As Integer)
        Dim objPersistencia As New OperacionesProcedimientosSICY
        Dim consulta As String
        consulta = "select sana_salidanavesid as 'Id_SalidaNave', sana_naveid as 'Nave', sana_año as 'Año', sana_operadorid as 'Operador'" +
            " from Almacen.SalidaNaves where sana_naveid = " + IdNave.ToString + " and sana_estado='EN PROCESO'"
        Return objPersistencia.EjecutaConsulta(consulta)
    End Function


    ''' <summary>
    ''' RECUPERA UNA TABLA CON LOS CODIGOS DE ATADO PERTENECIENTES A UN LOTE NO TERMINADO
    ''' </summary>
    ''' <param name="Lote">LOTE DEL CUALS E RECUPERARAN LOS CODIGOS DE ATADO</param>
    ''' <returns>DATATABLE CON LA INFORMACION DE LOS CODIGOS DE ATADO</returns>
    ''' <remarks></remarks>
    Public Function RecuperarAtados_de_LoteIncompleto(ByVal Lote As Integer, ByVal Año As Integer, ByVal IdNave As Integer)
        Dim objPersistencia As New OperacionesProcedimientosSICY
        Dim consulta As String
        consulta = "select ID_Docena as 'Atado', ID_Par as 'Par' from tmpDocenasPares_Entradas where idtbllote = " + Lote.ToString + " AND idtblaño =" + Año.ToString + " AND idtblnave =" + IdNave.ToString
        Return objPersistencia.EjecutaConsulta(consulta)
    End Function


    ''' <summary>
    ''' RECUPERA UNA TABLA CON LOS CODIGOS DE ATADO PERTENECIENTES A UN LOTE
    ''' </summary>
    ''' <param name="Lote">LOTE DEL CUALS E RECUPERARAN LOS CODIGOS DE ATADO</param>
    ''' <returns>DATATABLE CON LA INFORMACION DE LOS CODIGOS DE ATADO</returns>
    ''' <remarks></remarks>
    Public Function RecuperarAtados_de_Lote(ByVal Lote As Integer, ByVal Año As Integer, ByVal IdNave As Integer)
        Dim objPersistencia As New OperacionesProcedimientosSICY
        Dim consulta As String
        consulta = " Select distinct ID_Docena as 'Atado', null as '#' from tmpDocenasPares_Entradas where idtbllote = " + Lote.ToString + " AND idtblaño =" + Año.ToString +
                   " AND idtblnave =" + IdNave.ToString
        Return objPersistencia.EjecutaConsulta(consulta)
    End Function

    Public Function RecuperarAtados_de_Lote_Con_Descripcion(ByVal Lote As Integer, ByVal Año As Integer, ByVal IdNave As Integer)
        Dim objPersistencia As New OperacionesProcedimientosSICY
        Dim consulta As String
        consulta = "Select DISTINCT ID_Docena AS 'Atado', No_Atado AS '#', Descripcion AS 'Descripción' FROM tmpDocenasPares_Entradas WHERE" +
            " idtblnave = " + IdNave.ToString + " AND idtblaño = " + Año.ToString + " AND idtbllote = " + Lote.ToString
        Return objPersistencia.EjecutaConsulta(consulta)
    End Function


    ''' <summary>
    ''' RECUPERA LOS ATADOS YA LEEIDOS E INCLUIDOS EN LA TABLA Almacen.SALIDANAVESDETALLES CON SU ESTADO Y SU LOTE CORRESPONDIENTE PARA ACTUALIZAR LA TABLA DE GRID ERRONEOS
    ''' </summary>
    ''' <param name="IdSalidaNave">ID DE LA SALIDA DE NAVE A RECUPERAR INFORMACION</param>
    ''' <returns>RESULTADO DE LA EJECUCION DE LA CONSULTA</returns>
    ''' <remarks></remarks>
    Public Function RecuperarResultadosDeAtadosLeeidosEnProduccionSalidaNAves(ByVal IdSalidaNave As Integer, ByVal IdNave As Integer)
        Dim objPersistencia As New OperacionesProcedimientosSICY
        Dim consulta As String
        If IdNave <> 1 And IdNave <> 2 And IdNave <> 3 And IdNave <> 7 And IdNave <> 11 And IdNave <> 15 And IdNave <> 10 And IdNave <> 18 And IdNave <> 5 And IdNave <> 14 And IdNave <> 60 Then
            consulta = "select DISTINCT snde_codigoatado AS 'ATADO', snde_numero_atado AS '#', snde_resultadoid_atado AS 'RESULTADO', snde_lote AS 'LOTE', Descripcion as 'DESCRIPCION'," +
            " snde_año as 'AÑO' from Almacen.SalidaNavesDetalles join vestilos on IdCodigo = snde_idproducto where snde_salidanavesid = " + IdSalidaNave.ToString
        Else
            consulta = "select DISTINCT snde_codigoatado AS 'ATADO', snde_numero_atado AS '#', snde_resultadoid_atado AS 'RESULTADO', snde_lote AS 'LOTE', Descripcion as 'DESCRIPCION'," +
            " snde_año as 'AÑO' from Almacen.SalidaNavesDetalles_" + IdNave.ToString + " join vestilos on IdCodigo = snde_idproducto where snde_salidanavesid = " + IdSalidaNave.ToString
        End If
        Return objPersistencia.EjecutaConsulta(consulta)
    End Function


    ''' <summary>
    ''' RECUPERA EL TOTAL DE PARES Y EL TOTAL DE ATADOS PERTENECIENTES A UN LOTE
    ''' </summary>
    ''' <param name="Lote">LOTE DEL CUAL SE PRETENDE RECUPERAR PARES</param>
    ''' <param name="Año">AÑO DEL LOTE</param>
    ''' <param name="IdNave">IDNAVE DEL LOTE</param>
    ''' <returns>RESULTADO DE LA EJECUCION DE LA CONSULTA</returns>
    ''' <remarks></remarks>
    Public Function RecuperarPares_De_Lote(ByVal Lote As Integer, ByVal Año As Integer, ByVal IdNave As Integer)
        Dim objPersistencia As New OperacionesProcedimientosSICY
        Dim consulta As String
        consulta = "select  ID_Par , ID_Docena, No_Atado from tmpDocenasPares_Entradas  where idtbllote = " + Lote.ToString + " AND idtblaño =" + Año.ToString +
            " AND idtblnave =" + IdNave.ToString + "Order by idtbllote"
        Return objPersistencia.EjecutaConsulta(consulta)
    End Function

    ''' <summary>
    ''' RECUPERA LA DESCRIPCION DE UN PAR CON CODIGO DE LA EMPRESA
    ''' </summary>
    ''' <param name="cODIGO">CODIGO  DEL CUAL SE RECUPERARA LA DESCRIPCION</param>
    ''' <returns>EJECUCION DE LA CONSULTA CON SU RESULTADO</returns>
    ''' <remarks></remarks>
    Public Function RecuperarDesripcionParEmpresa(ByVal Codigo As String)
        Dim obPersistencia As New OperacionesProcedimientosSICY
        Dim consulta As String
        consulta = "select Descripcion, idtblProducto, calce from tmpDocenasPares_Entradas where ID_Par = '" + Codigo + "'"
        Return obPersistencia.EjecutaConsulta(consulta)
    End Function

    ''' <summary>
    ''' RECUPERA LA DESCRIPCION DE UN PAR DEACUERDO AL CODIGO DE CLIENTE QUE TIENE ASIGNADO
    ''' </summary>
    ''' <param name="COdigoCliente">CODIGO DE CLIENTE DEL CUAL SE RECUPERARA LA DESCRIPCION</param>
    ''' <returns>RESULTADO DE LA EJECUCION DE LA CONSULTA</returns>
    ''' <remarks></remarks>
    Public Function RecuperarDesripcionPar(ByVal COdigoCliente As String)
        Dim obPersistencia As New OperacionesProcedimientosSICY
        Dim consulta As String
        consulta = " select vEstilos.Descripcion, Codigos_Clientes.idcodigo from Codigos_Clientes" +
                    " join vEstilos on vEstilos.IdCodigo = Codigos_Clientes.idcodigo and codigo like '%" + COdigoCliente + "'"
        Return obPersistencia.EjecutaConsulta(consulta)
    End Function

    ''' <summary>
    ''' RECUPERA LOS PARES DE UNA SALIDA DE NAVES EN PROCESO
    ''' </summary>
    ''' <param name="IdSalidaNave">ID DE LA SALIDA DE NAVES DE LA QUE SE RECUPERARA EL PROCESO</param>
    ''' <returns>EJECUCION DE LA CONSULTA</returns>
    ''' <remarks></remarks>
    Public Function RecuperaParesDeSalidaNaveEnProceso(ByVal IdSalidaNave As Integer, ByVal IdNAve As Integer)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String
        If IdNAve <> 1 And IdNAve <> 2 And IdNAve <> 3 And IdNAve <> 7 And IdNAve <> 11 And IdNAve <> 15 And IdNAve <> 10 And IdNAve <> 18 And IdNAve <> 5 And IdNAve <> 14 And IdNAve <> 60 Then
            consulta = " SELECT snde_codigoatado AS 'ATADO',snde_codigopar AS 'PAR',snde_lote AS 'LOTE',snde_naveid AS 'IDNAVE',snde_año AS 'AÑO',snde_resultadoid_par AS 'R_PAR'," +
                " snde_resultadoid_atado AS 'R_ATADO',snde_numero_par AS 'N_PAR',snde_numero_atado AS 'N_ATADO',b.Descripcion AS 'DESCRIPCION',snde_talla AS 'TALLA'" +
                " FROM Almacen.SalidaNavesDetalles a JOIN vEstilos b on b.IdCodigo = a.snde_idproducto WHERE snde_salidanavesid =" + IdSalidaNave.ToString +
                " AND snde_resultadoid_par IS NOT NULL ORDER BY snde_lote, snde_numero_atado, snde_codigoatado "

        Else
            consulta = " SELECT snde_codigoatado AS 'ATADO',snde_codigopar AS 'PAR',snde_lote AS 'LOTE',snde_naveid AS 'IDNAVE',snde_año AS 'AÑO',snde_resultadoid_par AS 'R_PAR'," +
                " snde_resultadoid_atado AS 'R_ATADO',snde_numero_par AS 'N_PAR',snde_numero_atado AS 'N_ATADO',b.Descripcion AS 'DESCRIPCION',snde_talla AS 'TALLA'" +
                " FROM Almacen.SalidaNavesDetalles_" + IdNAve.ToString + " a " +
                " JOIN vEstilos b on b.IdCodigo = a.snde_idproducto " +
                " WHERE snde_salidanavesid = " + IdSalidaNave.ToString +
                " AND snde_resultadoid_par IS NOT NULL ORDER BY snde_lote, snde_numero_atado, snde_codigoatado "

        End If

        Return objPersistencia.EjecutaConsulta(consulta)
    End Function

    ''' <summary>
    ''' EJECUTA LA CONSULTA PARA ELIMINA LOS PARES DE CIERTO ATADO DE LA TABLA Almacen.SALIDANAVESDETALLES EN CASO DE QUE YA SE HUBIERAN AGREGADO PARES PARA ESE ATADO EN ESA TABLA
    ''' </summary>
    ''' <param name="Atado">CODIGO DE ATADO DEL CUAL VERIFICAREMOS SI EXISTEN PARES EN LA TABLA</param>
    ''' <remarks></remarks>
    Public Sub ELiminarParesAtadoYaEscaneadoTabla_ProduccionSalidaNacesDetalles(ByVal Atado As String, ByVal IdSalidaNAve As Integer, ByVal IdNave As Integer)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim Consulta As String = ""
        If IdNave <> 1 And IdNave <> 2 And IdNave <> 3 And IdNave <> 7 And IdNave <> 11 And IdNave <> 15 And IdNave <> 10 And IdNave <> 18 And IdNave <> 5 And IdNave <> 14 And IdNave <> 60 Then
            Consulta = "delete from Almacen.SalidaNavesDetalles where snde_codigoatado = '" + Atado.ToString + "' AND snde_salidanavesid =" + IdSalidaNAve.ToString
        Else
            Consulta = "delete from Almacen.SalidaNavesDetalles_" + IdNave.ToString + " where snde_codigoatado = '" + Atado.ToString + "' AND snde_salidanavesid =" + IdSalidaNAve.ToString
        End If

        objPersistencia.EjecutaConsulta(Consulta)
    End Sub

    ' ''' <summary>
    ' ''' EJECUTA LA CONSULTA PARA RECUPERAR EL NUMERO DE ATADO REGISTRADO EN LA TABLA Almacen.SALIDANAVESDETALLES DE UN ATADO EN ESPECIFICO
    ' ''' </summary>
    ' ''' <param name="Atado">ATADO DEL CUAL SE RECUPERARA INFORMACION</param>
    ' ''' <param name="IdSalidaNave">ID DE LA SALIDA DE NAVE DE LA CUAL SE RECUPERARA INFORMACION</param>
    ' ''' <returns>EJECUCION DE LA CONSULTA SQL</returns>
    ' ''' <remarks></remarks>
    'Public Function RecuperarNumeroAtado(ByVal Atado As String, ByVal IdSalidaNave As Integer, ByVal IdNave As Integer)
    '    Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
    '    Dim consulta As String = ""

    '    If IdNave <> 1 And IdNave <> 2 And IdNave <> 3 And IdNave <> 7 And IdNave <> 11 And IdNave <> 15 Then
    '        consulta = "select distinct snde_numero_atado from Almacen.SalidaNavesDetalles where snde_codigoatado = '" + Atado.ToString + "' and snde_salidanavesid=" + IdSalidaNave.ToString
    '    Else
    '        consulta = "select distinct snde_numero_atado from Almacen.SalidaNavesDetalles_" + IdNave.ToString + " where snde_codigoatado = '" + Atado.ToString + "' and snde_salidanavesid=" + IdSalidaNave.ToString
    '    End If

    '    Return objPersistencia.EjecutaConsulta(consulta)
    'End Function

    ''' <summary>
    ''' ELIMINA TODOS LOS PARES ESCANEADOS DE UN LOTE EN ESPECIFICO DE UN AÑO DETERMINADO Y UNA SALIDA DE NAVE EN ESPECIAL EN LA TABLA ALMACEN.SALIDANAVESDETALLES
    ''' </summary>
    ''' <param name="Lote">LOTE DE LOS PARES A ELIMIAR</param>
    ''' <param name="Año">AÑO DEL LOTE DE LOS PARES A ELIMINAR</param>
    ''' <param name="IdSalidaNave">ID DE LA SALIDA DE NAVE DEL LOTE DE LOS PARES A ELIMINAR</param>
    ''' <remarks></remarks>
    Public Sub EliminarParesDeAtadoDescartadoDeLaTablaSalidaNavesDetalles(ByVal Lote As Integer, ByVal Año As Integer, ByVal IdSalidaNave As Integer, ByVal IdNave As Integer)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String = ""
        If IdNave <> 1 And IdNave <> 2 And IdNave <> 3 And IdNave <> 7 And IdNave <> 11 And IdNave <> 15 And IdNave <> 10 And IdNave <> 18 And IdNave <> 5 And IdNave <> 14 And IdNave <> 60 Then
            consulta = "DELETE FROM Almacen.SalidaNavesDetalles WHERE snde_lote =  " + Lote.ToString + " AND snde_año = " + Año.ToString +
                        " AND snde_salidanavesid = " + IdSalidaNave.ToString
        Else
            consulta = "DELETE FROM Almacen.SalidaNavesDetalles_" + IdNave.ToString + " WHERE snde_lote =  " + Lote.ToString + " AND snde_año = " + Año.ToString +
                    " AND snde_salidanavesid = " + IdSalidaNave.ToString
        End If

        objPersistencia.EjecutaConsulta(consulta)
    End Sub

    ''' <summary>
    ''' AGREGA LOS PARES CON EL CODIGO DE CLIENTE EN EL CAMPO CORRESPONDIENTE AL CODIGO DEL PAR EN LA TABLA SALIDANAVESDETALLES
    ''' </summary>
    ''' <param name="IdSalidaNave">ID DE LA SALINA DE NAVE EN LA QUE SE INSERTARAN LOS CAMPOS</param>
    ''' <param name="Atado">ATADO DE LOS PARES</param>
    ''' <param name="lote">LOTE DE LOS PARES</param>
    ''' <param name="Año">AÑO DEL LOTE DE LOS PARES</param>
    ''' <param name="IdNave">ID DE LA NAVE DEL LOTE  DE LOS PARES</param>
    ''' <param name="NumAtado">NUMERO DE ATADO A ESCANEAR O ESCANEADO</param>
    ''' <param name="TipoPar">"C" PARA CODIGO DE CLIENTE, "U" PARA CODIGO UNICO</param>
    ''' <remarks></remarks>
    Public Sub Agregar_PAres_codigoCliente_SalidaNavesDetalles_AtadoActual(ByVal IdSalidaNave As Integer, ByVal Atado As String, ByVal Lote As Integer, ByVal Año As Integer, _
                                                                           ByVal IdNave As Integer, ByVal NumAtado As Integer, ByVal TipoPar As String)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@IdSalidaNAve"
        parametro.Value = IdSalidaNave
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Atado"
        parametro.Value = Atado
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Lote"
        parametro.Value = Lote
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Año"
        parametro.Value = Año
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@IdNave"
        parametro.Value = IdNave
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@TipoCodigo"
        parametro.Value = TipoPar
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@NumAtado"
        parametro.Value = NumAtado
        listaparametros.Add(parametro)
        objPersistencia.EjecutarConsultaSP("Almacen.SP_Agregar_Pares_Codigo_Cliente_SalidaNavesDetalles_PB", listaparametros)
    End Sub

    ''' <summary>
    ''' ACTUALIZA LA TABLA SALIDA NAVES CUANDO SE FINALIZA EL ESCANEO PARA UNA SALIDA DE NAVES
    ''' </summary>
    ''' <param name="IdSalidaNaves">ID DE LA SALIDA DE NAVES CON LA QUE SE ESTA TRABAJANDO</param>
    ''' <param name="TotalPares">TOTAL DE PARES A EMBARCAR</param>
    ''' <param name="Total_Atados">TOTAL DE ATADOS A EMBARCAR</param>
    ''' <param name="Total_Lotes">TOTAL DE LOTES A EMBARCAR</param>
    ''' <remarks></remarks>
    Public Sub Actualizar_Almacen_salidanaves_SalidaNaves(ByVal IdSalidaNaves As Integer, ByVal TotalPares As Integer, ByVal Total_Atados As Integer, ByVal Total_Lotes As Integer)
        Dim objPersistencia As New OperacionesProcedimientosSICY
        Dim consulta As String
        consulta = "UPDATE ALMACEN.SalidaNaves SET sana_totalpares = " + TotalPares.ToString + ", sana_totalatados = " + Total_Atados.ToString + ", sana_totallotes = " + Total_Lotes.ToString + " , sana_estado = 'EMBARCADO' " +
            ", sana_operadorid	= " + Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid.ToString + ",sana_fechasalida = (SELECT (GETDATE())) WHERE sana_salidanavesid = " + IdSalidaNaves.ToString
        objPersistencia.EjecutaConsulta(consulta)
    End Sub

    ''' <summary>
    ''' ACTUALIZA LA TABLA SALIDANAVESDETALLES CUANDO SE FINALIZA EL ESCANEO PARA UNA SALIDA DE NAVES
    ''' </summary>
    ''' <param name="IdSalidaNaves">ID DE LA SALIDA DE NAVES A FINALIZAR</param>
    ''' <remarks></remarks>
    Public Sub Actualizar_Almacen_salidaNavesDetalles_SalidaNaves(ByVal IdSalidaNaves As Integer, ByVal Estado As String, ByVal IdNave As Integer)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@IdSalidaNave"
        parametro.Value = IdSalidaNaves
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Estado"
        parametro.Value = Estado
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@IdNave"
        parametro.Value = IdNave
        listaparametros.Add(parametro)

        objPersistencia.EjecutarConsultaSP("[Almacen].[SP_SalidaNavesDetalles_ActualizarTablaParaSalidaFinalizada_PB]", listaparametros)
    End Sub

    ''' <summary>
    ''' RECUPERA QUE TIPO DE NAVE ES CON LA QUE SE ESTA TRABAJANDO, SI ES MAQUILA O ES NAVE NORMAL
    ''' </summary>
    ''' <param name="Id_Nave">ID DE LA NAVE A VERIFICAR</param>
    ''' <returns>RESULTADO DE EJECUCION DE LA CONSULTA</returns>
    ''' <remarks></remarks>
    Public Function Validar_TipoNave_Maquila_O_Normal(ByVal Id_Nave As Integer)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String
        consulta = "select maquiladora from Naves where IdNave = " + Id_Nave.ToString
        Return objPersistencia.EjecutaConsulta(consulta)
    End Function

    ''' <summary>
    ''' EJECUTA LA CONSULTA PARA RECUPERAR LOS TOTALES DE PARES Y ATADOS Y SUS LOTES CORRESPONDIENTES EN UNA SALIDA DE NAVES
    ''' </summary>
    ''' <param name="Id_Salida_Nave">ID DE LA SALIDA DE NAVES A RECUPERAR LOS DATOS</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Recuperar_Informacion_Reporte_SalidaNaves(ByVal Id_Salida_Nave As Integer, ByVal IdNave As Integer)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String

        If IdNave <> 1 And IdNave <> 2 And IdNave <> 3 And IdNave <> 7 And IdNave <> 11 And IdNave <> 15 And IdNave <> 10 And IdNave <> 18 And IdNave <> 5 And IdNave <> 14 And IdNave <> 60 Then
            consulta = " SELECT A.snde_lote AS 'LOTE',a.snde_año AS 'AÑO',COUNT(DISTINCT a.snde_codigoatado) AS 'ATADOS',COUNT(a.snde_codigopar) AS 'PARES'," +
            " IdModelo AS 'MODELO',marca + ' ' + Coleccion + ' ' + color AS 'DESCRIPCION',	a.snde_Corrida AS 'CORRIDA'" +
            " ,CONVERT(char(10), (SELECT DISTINCT x.Fecha FROM LotesDocenas AS x WHERE x.Lote = a.snde_lote AND x.Año = a.snde_año AND x.Nave = a.snde_naveid), 103) AS 'Programa'" +
            " FROM Almacen.SalidaNavesDetalles AS A" +
            " LEFT JOIN vEstilos ON IdCodigo = snde_idproducto" +
            " WHERE snde_salidanavesid = " + Id_Salida_Nave.ToString + " and A.snde_resultadoid_par is not null and A.snde_resultadoid_atado is not NULL " +
            " GROUP BY	snde_lote,snde_año,IdModelo,Marca,Coleccion,Color,A.snde_naveid,a.snde_Corrida"
        Else
            consulta = " SELECT A.snde_lote AS 'LOTE',a.snde_año AS 'AÑO',COUNT(DISTINCT a.snde_codigoatado) AS 'ATADOS',COUNT(a.snde_codigopar) AS 'PARES'," +
            " IdModelo AS 'MODELO',marca + ' ' + Coleccion + ' ' + color AS 'DESCRIPCION',	a.snde_Corrida AS 'CORRIDA'" +
            " ,CONVERT(char(10), (SELECT DISTINCT x.Fecha FROM LotesDocenas AS x WHERE x.Lote = a.snde_lote AND x.Año = a.snde_año AND x.Nave = a.snde_naveid), 103) AS 'Programa'" +
            " FROM Almacen.SalidaNavesDetalles_" + IdNave.ToString + " AS A" +
            " LEFT JOIN vEstilos ON IdCodigo = snde_idproducto" +
            " WHERE snde_salidanavesid = " + Id_Salida_Nave.ToString + " and A.snde_resultadoid_par is not null and A.snde_resultadoid_atado is not NULL " +
            " GROUP BY	snde_lote,snde_año,IdModelo,Marca,Coleccion,Color,A.snde_naveid,a.snde_Corrida"
        End If


        Return objPersistencia.EjecutaConsulta(consulta)
    End Function

    ''' <summary>
    ''' EJECUTA LA CONSULTA PARA RECUPERAR EL NOMBRE DE UNA NAVE DEACUERDO CON SU ID
    ''' </summary>
    ''' <param name="IdNave">ID DE LA NAVE A RECUPERAR EL NOMBRE</param>
    ''' <returns>RESULTADO DE LA EJECUCION DE LA CONSULTA</returns>
    ''' <remarks></remarks>
    Public Function RecuperarNombreNave(ByVal IdNave As Integer)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String
        consulta = "select Nave from naves where IdNave = " + IdNave.ToString
        Return objPersistencia.EjecutaConsulta(consulta)
    End Function

    ''' <summary>
    ''' RECUPERA LOS ID DE CLIENTES ASIGNADOS A UNA NAVE DETERMINADA, DE LA TABLA CONFIGURACIONCLIENTEVALIDACIONEMBARQUE, PARA VALIDAR SU ESCANEO PAR X PAR
    ''' </summary>
    ''' <param name="Id_Nave">ID DE LA NAVE DE LA CUAL SE RECUPERARAN LOS CLIENTES QUE HAY QUE VALIDAR PAR POR PAR</param>
    ''' <returns>RESULTADO DE LA EJECUCION DE LA CONSULTA</returns>
    ''' <remarks></remarks>
    Public Function RecuperarClientesParaValidacionParxPar(ByVal Id_Nave As Integer, ByVal Proceso As String)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim Consulta As String = ""
        If Proceso = "SALIDA" Then
            Consulta = "select ccve_cadenaid from almacen.ConfiguracionClienteValidacionEmbarque where ccve_naveid =" + Id_Nave.ToString +
                " AND ccve_validarsalidaporpar = 1 and ccve_activo = 1"
        Else
            Consulta = "select ccve_cadenaid from almacen.ConfiguracionClienteValidacionEmbarque where ccve_naveid =" + Id_Nave.ToString +
                " AND ccve_validarentradaporpar = 1 and ccve_activo = 1"
        End If

        Return objPersistencia.EjecutaConsulta(Consulta)
    End Function

    ''' <summary>
    ''' RECUPERA LOS CLIENTES INCLUIDOS EN UN LOTE DETERMINADO
    ''' </summary>
    ''' <param name="Lote">LOTE EN EL QUE SE BUSCARAN LOS CLIENTES A LOS QUE SE LES ASIGNO EL PRODUCTO DEL LOTE</param>
    ''' <param name="Año">AÑO DEL LOTE</param>
    ''' <param name="Id_Nave">NAVE DEL LOTE</param>
    ''' <returns>RESULTADO DE LA EJECUCION DE LA CONSULTA</returns>
    ''' <remarks></remarks>
    Public Function RecuperarClientesIncluidos_En_El_Lote(ByVal Lote As Integer, ByVal Año As Integer, ByVal Id_Nave As Integer)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim Consulta As String = ""
        Consulta = "SELECT DISTINCT idtblcte FROM tmpDocenasPares_Entradas where idtblnave = " + Id_Nave.ToString +
            " and idtblaño = " + Año.ToString + " and idtbllote = " + Lote.ToString
        Return objPersistencia.EjecutaConsulta(Consulta)
    End Function

    ''' <summary>
    ''' RECUPERA LOS TOTALES DE PARES, ATADOS Y LOTES DE LA TABLA ALMACNE.SALIDANAVESDETALLES
    ''' </summary>
    ''' <param name="IdSalidaNave">ID DE LA SALIDA DE NAVE DE LA CUAL SE RECUPERARAN LOS TOTALES</param>
    ''' <returns>RESULTADO DE LA EJECUCION DE LA CONSULTA</returns>
    ''' <remarks></remarks>
    Public Function Recuperar_Totales_SalidaNaveEnProceso(ByVal IdSalidaNave As Integer, ByVal IdNave As Integer)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim Consulta As String = ""

        If IdNave <> 1 And IdNave <> 2 And IdNave <> 3 And IdNave <> 7 And IdNave <> 11 And IdNave <> 15 And IdNave <> 10 And IdNave <> 18 And IdNave <> 5 And IdNave <> 14 And IdNave <> 60 Then
            Consulta = "SELECT (select count(snde_codigopar) as 'PARES'   from almacen.SalidaNavesDetalles where snde_salidanavesid =  " + IdSalidaNave.ToString + ") AS 'PARES'," +
            " (select count(distinct snde_codigoatado) as 'ATADOS'   from almacen.SalidaNavesDetalles where snde_salidanavesid =  " + IdSalidaNave.ToString + ") AS  'ATADOS'," +
            " (select count(DISTINCT (snde_lote+'-'+ snde_año)) as 'LOTES'   from almacen.SalidaNavesDetalles where snde_salidanavesid =  " + IdSalidaNave.ToString + ") AS 'LOTES'"
        Else
            Consulta = "SELECT (select count(snde_codigopar) as 'PARES'   from almacen.SalidaNavesDetalles_" + IdNave.ToString + " where snde_salidanavesid =  " + IdSalidaNave.ToString + ") AS 'PARES'," +
            " (select count(distinct snde_codigoatado) as 'ATADOS'   from almacen.SalidaNavesDetalles_" + IdNave.ToString + " where snde_salidanavesid =  " + IdSalidaNave.ToString + ") AS  'ATADOS'," +
            " (select count(DISTINCT (snde_lote+'-'+ snde_año)) as 'LOTES'   from almacen.SalidaNavesDetalles_" + IdNave.ToString + " where snde_salidanavesid =  " + IdSalidaNave.ToString + ") AS 'LOTES'"
        End If

        Return objPersistencia.EjecutaConsulta(Consulta)
    End Function

    ''' <summary>
    ''' EJECUTA EL PROCEDIMIENTO ALMACENADO QUE REALIZA LOS PROCESOS PARA FINALIZAR UNA SALIDA DE NAVE MEDIANTE UNA TRANSACCION (ACTUALIZA EL ESTATUS DE LOS PARES A EMBARCADOS, RESETEA LOS NUMEROS DE ATADO
    ''' PARA QUE SEAN CONSECUTIVOS Y ACTUALIZA LOS TOTALES DLEL EMBARQUE EN LA TABLA ALMACEN.SALIDANAVES )
    ''' </summary>
    ''' <param name="IdSalidaNave">ID DE LA SALIDA DE NAVE A FINALIZAR</param>
    ''' <param name="TotalPares">TOTAL DE PARES EMBARCADOS</param>
    ''' <param name="TotalAtados">TOTAL DE ATADOS EMBARCADOS</param>
    ''' <param name="TotalLotes">TOTAL DE LOTES EMBARCADOS</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function FinalizarSalidaNaves(ByVal IdSalidaNave As Integer, ByVal TotalPares As Integer, ByVal TotalAtados As Integer, ByVal TotalLotes As Integer, ByVal IdNave As Integer)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@IdSalidaNave"
        parametro.Value = IdSalidaNave
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@IdUsuario"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@TotalPares"
        parametro.Value = TotalPares
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@TotalAtados"
        parametro.Value = TotalAtados
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@TotalLotes"
        parametro.Value = TotalLotes
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@IdNave"
        parametro.Value = IdNave
        listaparametros.Add(parametro)
        'Dim sentencia As String = "exec Almacen.SP_Finalizar_Proceso_Salida_Producto_Nave " + IdSalidaNave.ToString + "," + Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid.ToString + "," + TotalPares.ToString + "," + TotalAtados.ToString + "," + TotalLotes.ToString
        'Return objPersistencia.EjecutaSentencia(sentencia)
        Return objPersistencia.EjecutarConsultaSP("Almacen.SP_Finalizar_Proceso_Salida_Producto_Nave_PB", listaparametros)
    End Function

    ''' <summary>
    ''' RECUPERA LA FECHA EN AL QUE SE LE DIO SALIDA A UN EMBARQUE
    ''' </summary>
    ''' <param name="IdSAlidaNave">ID DE LA SALIDA DE NAVE DE LA QUE SE RECUPERARA LA INFORMACION</param>
    ''' <returns>RESULTADO DE LA EJECUCION DE LA CONSULTA</returns>
    ''' <remarks></remarks>
    Public Function RecuperarFechaDeSalidaDeEmbarque(ByVal IdSAlidaNave As Integer)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String
        consulta = "select sana_fechasalida from almacen.SalidaNaves where sana_salidanavesid = " + IdSAlidaNave.ToString
        Return objPersistencia.EjecutaConsulta(consulta)
    End Function

    ''' <summary>
    ''' RECUPERA LOS TOTALES DE PARES.LOTES Y ATADOS EMBARCADOS ASI COMO LA FECHA DEL EMBARQUE
    ''' </summary>
    ''' <param name="IdSalidaNave"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Recuperar_Totales_LotesAtadosPares_Embarcados(ByVal IdSalidaNave As Integer)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String
        consulta = "select sana_totalpares AS 'PARES_SALIDA', sana_totalatados AS 'ATADOS_SALIDA', sana_totallotes AS 'LOTES_SALIDA'," +
            " sana_fechasalida AS 'FECHA_SALIDA', sana_entrega as 'ENTREGA'  from almacen.SalidaNaves where sana_salidanavesid = " + IdSalidaNave.ToString
        Return objPersistencia.EjecutaConsulta(consulta)
    End Function

    ''' <summary>
    ''' RECUPERA UNA TABLA CON LA INFORMACION DE TODAS LAS SALIDA DE NAVE DENTRO DE UN RANGO DE TIEMPO, Y TODAS YA EMBARCADAS
    ''' </summary>
    ''' <param name="Fecha_Inicio">FECHA DE INICIO DEL RANGO DE BUSQUEDA DE LOS REPORTES</param>
    ''' <param name="Fecha_Fin">FECHA DE FIN DEL RANGO DE BUSQUEDA DE LOS REPORTES</param>
    ''' <param name="IdNave">ID NAVE SOBRE LA CUAL SE BUSCARAN LOS REPORTES</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Recuperar_Salidas_De_Nave(ByVal Fecha_Inicio As String, ByVal Fecha_Fin As String, ByVal IdNave As Integer)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim operacionesSAY As New Persistencia.OperacionesProcedimientos
        Dim consulta As String
        consulta = "SELECT sana_salidanavesid AS 'Folio', sana_totalpares as 'Total Pares', sana_totalatados as 'Total Atados', sana_totallotes as 'Total Lotes'," +
            " a.user_nombrereal as 'Operador', sana_operadorid as 'Id_Operador'," +
            " sana_fechasalida As 'Fecha Salida'," +
            " sana_fechaentrada As 'Fecha Entrada'," +
            " sana_estado As 'Estatus' FROM ALMACEN.SalidaNaves" +
            " join [" + operacionesSAY.Servidor + "].[" + operacionesSAY.NombreDB + "].Framework.Usuarios as a on a.user_usuarioid = sana_operadorid " +
            " WHERE sana_naveid = " + IdNave.ToString +
            " AND  sana_fechasalida >= '" + Fecha_Inicio + "'" +
            " and sana_fechasalida <= '" + Fecha_Fin + "'" +
            " AND sana_estado<> 'EN PROCESO'"
        Return objPersistencia.EjecutaConsulta(consulta)
    End Function


    Public Sub EliminarErroresDeLaLectura(ByVal IdNave As Integer, ByVal IdEmbarque As Integer, ByVal salida_Entrada As String)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String = ""

        If salida_Entrada = "SALIDA" Then
            If IdNave = 1 Then
                consulta = "delete from Almacen.SalidaNavesDetalles_1 where snde_resultadoid_atado = 1 and snde_numero_par = 0 and snde_salidanavesid = " + IdEmbarque.ToString
            ElseIf IdNave = 2 Then
                consulta = "delete from Almacen.SalidaNavesDetalles_2 where snde_resultadoid_atado = 1 and snde_numero_par = 0 and snde_salidanavesid = " + IdEmbarque.ToString
            ElseIf IdNave = 3 Then
                consulta = "delete from Almacen.SalidaNavesDetalles_3 where snde_resultadoid_atado = 1 and snde_numero_par = 0 and snde_salidanavesid = " + IdEmbarque.ToString
            ElseIf IdNave = 7 Then
                consulta = "delete from Almacen.SalidaNavesDetalles_7 where snde_resultadoid_atado = 1 and snde_numero_par = 0 and snde_salidanavesid = " + IdEmbarque.ToString
            ElseIf IdNave = 11 Then
                consulta = "delete from Almacen.SalidaNavesDetalles_11 where snde_resultadoid_atado = 1 and snde_numero_par = 0 and snde_salidanavesid = " + IdEmbarque.ToString
            ElseIf IdNave = 15 Then
                consulta = "delete from Almacen.SalidaNavesDetalles_15 where snde_resultadoid_atado = 1 and snde_numero_par = 0 and snde_salidanavesid = " + IdEmbarque.ToString
            ElseIf IdNave = 10 Then
                consulta = "delete from Almacen.SalidaNavesDetalles_10 where snde_resultadoid_atado = 1 and snde_numero_par = 0 and snde_salidanavesid = " + IdEmbarque.ToString
            ElseIf IdNave = 18 Then
                consulta = "delete from Almacen.SalidaNavesDetalles_18 where snde_resultadoid_atado = 1 and snde_numero_par = 0 and snde_salidanavesid = " + IdEmbarque.ToString
            ElseIf IdNave = 5 Then
                consulta = "delete from Almacen.SalidaNavesDetalles_5 where snde_resultadoid_atado = 1 and snde_numero_par = 0 and snde_salidanavesid = " + IdEmbarque.ToString
            ElseIf IdNave = 60 Then
                consulta = "delete from Almacen.SalidaNavesDetalles_60 where snde_resultadoid_atado = 1 and snde_numero_par = 0 and snde_salidanavesid = " + IdEmbarque.ToString
            ElseIf IdNave = 14 Then
                consulta = "delete from Almacen.SalidaNavesDetalles_14 where snde_resultadoid_atado = 1 and snde_numero_par = 0 and snde_salidanavesid = " + IdEmbarque.ToString
            End If
        Else
            If IdNave = 1 Then
                consulta = "delete from Almacen.SalidaNavesDetalles_1 where snde_resultadoid_atado_entrada = 1 and snde_numero_par = 0 and snde_salidanavesid = " + IdEmbarque.ToString
            ElseIf IdNave = 2 Then
                consulta = "delete from Almacen.SalidaNavesDetalles_2 where snde_resultadoid_atado_entrada = 1 and snde_numero_par = 0 and snde_salidanavesid = " + IdEmbarque.ToString
            ElseIf IdNave = 3 Then
                consulta = "delete from Almacen.SalidaNavesDetalles_3 where snde_resultadoid_atado_entrada = 1 and snde_numero_par = 0 and snde_salidanavesid = " + IdEmbarque.ToString
            ElseIf IdNave = 7 Then
                consulta = "delete from Almacen.SalidaNavesDetalles_7 where snde_resultadoid_atado_entrada = 1 and snde_numero_par = 0 and snde_salidanavesid = " + IdEmbarque.ToString
            ElseIf IdNave = 11 Then
                consulta = "delete from Almacen.SalidaNavesDetalles_11 where snde_resultadoid_atado_entrada = 1 and snde_numero_par = 0 and snde_salidanavesid = " + IdEmbarque.ToString
            ElseIf IdNave = 15 Then
                consulta = "delete from Almacen.SalidaNavesDetalles_15 where snde_resultadoid_atado_entrada = 1 and snde_numero_par = 0 and snde_salidanavesid = " + IdEmbarque.ToString
            ElseIf IdNave = 10 Then
                consulta = "delete from Almacen.SalidaNavesDetalles_10 where snde_resultadoid_atado_entrada = 1 and snde_numero_par = 0 and snde_salidanavesid = " + IdEmbarque.ToString
            ElseIf IdNave = 18 Then
                consulta = "delete from Almacen.SalidaNavesDetalles_18 where snde_resultadoid_atado_entrada = 1 and snde_numero_par = 0 and snde_salidanavesid = " + IdEmbarque.ToString
            ElseIf IdNave = 5 Then
                consulta = "delete from Almacen.SalidaNavesDetalles_5 where snde_resultadoid_atado_entrada = 1 and snde_numero_par = 0 and snde_salidanavesid = " + IdEmbarque.ToString
            ElseIf IdNave = 14 Then
                consulta = "delete from Almacen.SalidaNavesDetalles_14 where snde_resultadoid_atado_entrada = 1 and snde_numero_par = 0 and snde_salidanavesid = " + IdEmbarque.ToString
            ElseIf IdNave = 60 Then
                consulta = "delete from Almacen.SalidaNavesDetalles_60 where snde_resultadoid_atado_entrada = 1 and snde_numero_par = 0 and snde_salidanavesid = " + IdEmbarque.ToString
        End If
        End If
        objPersistencia.EjecutaConsulta(consulta)
    End Sub

End Class
