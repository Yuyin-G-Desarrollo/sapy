Imports Persistencia
Imports System.Data.SqlClient
Imports Entidades

Public Class OrdenesDeCompra

    ''' <summary>
    ''' Alta ordenes de compra
    ''' </summary>
    ''' <param name="OrdenDeCompra"></param>
    ''' <remarks></remarks>
    Public Sub AltaOrdenDeCompra(ByVal OrdenDeCompra As Entidades.OrdenDeCompra)
        Dim operaciones As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "ocid"
        parametro.Value = OrdenDeCompra.ordc_ordencompraid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "proveedorid"
        parametro.Value = OrdenDeCompra.ordc_proveedorid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "plazoid"
        parametro.Value = OrdenDeCompra.ordc_plazoid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "plazodias"
        parametro.Value = OrdenDeCompra.ordc_plazodias
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "naveid"
        parametro.Value = OrdenDeCompra.ordc_naveid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fechaelaboracion"
        parametro.Value = OrdenDeCompra.ordc_fechaleaboracion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "prioridad"
        parametro.Value = OrdenDeCompra.ordc_prioridad
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "razonsocial"
        parametro.Value = OrdenDeCompra.ordc_razonsocial
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "documento"
        parametro.Value = OrdenDeCompra.ordc_documento
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "programainicio"
        parametro.Value = OrdenDeCompra.ordc_programainicio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "programafin"
        parametro.Value = OrdenDeCompra.ordc_programafin
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fechaentregaestimada"
        parametro.Value = OrdenDeCompra.ordc_fechaentregaestimada
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fechapagoestimado"
        parametro.Value = OrdenDeCompra.ordc_fechapagoestimado
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "semanapago"
        parametro.Value = OrdenDeCompra.ordc_semanapago
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "calleentrega"
        parametro.Value = OrdenDeCompra.ordc_calleentrega
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "numeroentrega"
        parametro.Value = OrdenDeCompra.ordc_numeroentrega
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "coloniaentrega"
        parametro.Value = OrdenDeCompra.ordc_coloniaentrega
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ciudadid"
        parametro.Value = OrdenDeCompra.ordc_ciudadid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "codigopostal"
        parametro.Value = OrdenDeCompra.ordc_codigopostal
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "observaciones"
        parametro.Value = OrdenDeCompra.ordc_observaciones
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "estatus"
        parametro.Value = OrdenDeCompra.ordc_estatus
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "autorizacompra"
        parametro.Value = OrdenDeCompra.ordc_autorizacompraid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fechaautorizacion"
        parametro.Value = OrdenDeCompra.ordc_fechaautorizacion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "usuariocreoid"
        parametro.Value = OrdenDeCompra.ordc_usuariocreoid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "usuariomodifico"
        parametro.Value = OrdenDeCompra.ordc_usuariomodificoid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fechamodificacion"
        parametro.Value = OrdenDeCompra.ordc_fechamodificacion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "subtotal"
        parametro.Value = OrdenDeCompra.ordc_subtotal
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "iva"
        parametro.Value = OrdenDeCompra.ordc_iva
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "total"
        parametro.Value = OrdenDeCompra.ordc_total
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "anio"
        parametro.Value = OrdenDeCompra.ordc_anio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "folio"
        parametro.Value = OrdenDeCompra.ordc_folio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "tipoCaptura"
        parametro.Value = OrdenDeCompra.ordc_tipocaptura
        listaParametros.Add(parametro)

        operaciones.EjecutarConsultaSP("Proveedor.SP_InsertarOrdenCompra", listaParametros)
        Console.WriteLine("Mando la sentencia")
    End Sub

    ''' <summary>
    ''' Modificacion en orden de compra
    ''' </summary>
    ''' <param name="OrdenDeCompra"></param>
    ''' <remarks></remarks>
    Public Sub ModificarOrdenCompra(ByVal OrdenDeCompra As Entidades.OrdenDeCompra)
        Dim operaciones As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "prioridad"
        parametro.Value = OrdenDeCompra.ordc_prioridad
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "razonsocial"
        parametro.Value = OrdenDeCompra.ordc_razonsocial
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "documento"
        parametro.Value = OrdenDeCompra.ordc_documento
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "calleentrega"
        parametro.Value = OrdenDeCompra.ordc_calleentrega
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "numeroentrega"
        parametro.Value = OrdenDeCompra.ordc_numeroentrega
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "coloniaentrega"
        parametro.Value = OrdenDeCompra.ordc_coloniaentrega
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ciudadid"
        parametro.Value = OrdenDeCompra.ordc_ciudadid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "codigopostal"
        parametro.Value = OrdenDeCompra.ordc_codigopostal
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "observaciones"
        parametro.Value = OrdenDeCompra.ordc_observaciones
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "usuariomodifico"
        parametro.Value = OrdenDeCompra.ordc_usuariomodificoid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fechamodificacion"
        parametro.Value = OrdenDeCompra.ordc_fechamodificacion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "subtotal"
        parametro.Value = OrdenDeCompra.ordc_subtotal
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "iva"
        parametro.Value = OrdenDeCompra.ordc_iva
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "total"
        parametro.Value = OrdenDeCompra.ordc_total
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idordencompra"
        parametro.Value = OrdenDeCompra.ordc_ordencompraid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "folio"
        parametro.Value = OrdenDeCompra.ordc_folio
        listaParametros.Add(parametro)

        operaciones.EjecutarSentenciaSP("Proveedor.SP_ModificarCapturaOrdenCompra", listaParametros)
        Console.WriteLine("Mando la sentencia")
    End Sub

    ''' <summary>
    ''' Estatus eliminado material Ordend e compra
    ''' </summary>
    ''' <param name="OrdenDeCompra"></param>
    ''' <remarks></remarks>
    Public Sub EstatusEliminadoMaterial(ByVal materiial As Entidades.MaterialOrdenDeCompra)
        Dim operaciones As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "id"
        parametro.Value = materiial.maoc_materialid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ocid"
        parametro.Value = materiial.maoc_ordencompraid
        listaParametros.Add(parametro)

        operaciones.EjecutarSentenciaSP("Proveedor.SP_EstatusEliminadoMaterialesOC", listaParametros)
        Console.WriteLine("Mando la sentencia")
    End Sub

    ''' <summary>
    ''' Cambiar estatus orden de compra
    ''' </summary>
    ''' <param name="OrdenDeCompra"></param>
    ''' <remarks></remarks>
    Public Sub autorizarMaterial(ByVal OrdenDeCompra As Entidades.OrdenDeCompra)
        Dim operaciones As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "estatus"
        parametro.Value = OrdenDeCompra.ordc_estatus
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "id"
        parametro.Value = OrdenDeCompra.ordc_ordencompraid
        listaParametros.Add(parametro)

        'parametro = New SqlParameter
        'parametro.ParameterName = "fecha"
        'parametro.Value = OrdenDeCompra.ordc_fechaautorizacion
        'listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "autoriza"
        parametro.Value = SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        operaciones.EjecutarConsultaSP("Proveedor.SP_AutorizarOrdenCompra", listaParametros)
        Console.WriteLine("Mando la sentencia")
    End Sub

    ''' <summary>
    ''' rechazar orden de compra
    ''' </summary>
    ''' <param name="OrdenDeCompra"></param>
    ''' <remarks></remarks>
    Public Sub rechazarMaterial(ByVal OrdenDeCompra As Entidades.OrdenDeCompra)
        Dim operaciones As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "estatus"
        parametro.Value = OrdenDeCompra.ordc_estatus
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "id"
        parametro.Value = OrdenDeCompra.ordc_ordencompraid
        listaParametros.Add(parametro)

        'parametro = New SqlParameter
        'parametro.ParameterName = "fecha"
        'parametro.Value = OrdenDeCompra.ordc_fechaautorizacion
        'listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "autoriza"
        parametro.Value = SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        operaciones.EjecutarConsultaSP("Proveedor.SP_CancelarRechazarOrdenCompra", listaParametros)
        Console.WriteLine("Mando la sentencia")
    End Sub

    ''' <summary>
    ''' modificar costos de orden de compra
    ''' </summary>
    ''' <param name="OrdenDeCompra"></param>
    ''' <remarks></remarks>
    Public Sub ModificarCostosOrdenCompra(ByVal OrdenDeCompra As Entidades.OrdenDeCompra)
        Dim operaciones As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "usuariomodifico"
        parametro.Value = OrdenDeCompra.ordc_usuariomodificoid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fechamodificacion"
        parametro.Value = OrdenDeCompra.ordc_fechamodificacion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "subtotal"
        parametro.Value = OrdenDeCompra.ordc_subtotal
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "iva"
        parametro.Value = OrdenDeCompra.ordc_iva
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "total"
        parametro.Value = OrdenDeCompra.ordc_total
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "folio"
        parametro.Value = OrdenDeCompra.ordc_folio
        listaParametros.Add(parametro)

        operaciones.EjecutarConsultaSP("SP_ModificarPreciosOrdenCompra", listaParametros)
        Console.WriteLine("Mando la sentencia")
    End Sub

    ''' <summary>
    ''' Alta de material para orden de compra
    ''' </summary>
    ''' <param name="MaterialOrdenDeCompra"></param>
    ''' <remarks></remarks>
    Public Sub AltaMaterialOrdenDeCompra(ByVal MaterialOrdenDeCompra As Entidades.MaterialOrdenDeCompra)
        Dim operaciones As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "materialordendecompraid"
        parametro.Value = MaterialOrdenDeCompra.maoc_materialordendecompraid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "materialpreciosid"
        parametro.Value = MaterialOrdenDeCompra.maoc_materialpreciosid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "cantidad"
        parametro.Value = MaterialOrdenDeCompra.maoc_cantidad
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "preciounitario"
        parametro.Value = MaterialOrdenDeCompra.maoc_preciounitario
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "umpid"
        parametro.Value = MaterialOrdenDeCompra.maoc_umpid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "umcid"
        parametro.Value = MaterialOrdenDeCompra.maoc_umcid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ordencompraid"
        parametro.Value = MaterialOrdenDeCompra.maoc_ordencompraid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "usuariocreoid"
        parametro.Value = MaterialOrdenDeCompra.maoc_usuariocreoid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fechacreacion"
        parametro.Value = MaterialOrdenDeCompra.maoc_fechacreacion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "usuariomodifico"
        parametro.Value = MaterialOrdenDeCompra.maoc_usuariomodificoid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fechamodificacion"
        parametro.Value = MaterialOrdenDeCompra.maoc_fechamodificacion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "estatus"
        parametro.Value = MaterialOrdenDeCompra.maoc_estatusmaterial
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idmaterial"
        parametro.Value = MaterialOrdenDeCompra.maoc_materialid
        listaParametros.Add(parametro)

        operaciones.EjecutarConsultaSP("Proveedor.SP_InsertarMaterialOrdenCompra", listaParametros)
        Console.WriteLine("Mando la sentencia")
    End Sub

    ''' <summary>
    ''' Modificar material para orden de compra
    ''' </summary>
    ''' <param name="MaterialOrdenDeCompra"></param>
    ''' <remarks></remarks>
    Public Sub ModificarMaterialOrdenDeCompra(ByVal MaterialOrdenDeCompra As Entidades.MaterialOrdenDeCompra)
        Dim operaciones As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "materialpreciosid"
        parametro.Value = MaterialOrdenDeCompra.maoc_materialpreciosid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "cantidad"
        parametro.Value = MaterialOrdenDeCompra.maoc_cantidad
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "umpid"
        parametro.Value = MaterialOrdenDeCompra.maoc_umpid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "umcid"
        parametro.Value = MaterialOrdenDeCompra.maoc_umcid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ordencompraid"
        parametro.Value = MaterialOrdenDeCompra.maoc_ordencompraid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "usuariomodifico"
        parametro.Value = MaterialOrdenDeCompra.maoc_usuariomodificoid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fechamodificacion"
        parametro.Value = MaterialOrdenDeCompra.maoc_fechamodificacion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "estatus"
        parametro.Value = MaterialOrdenDeCompra.maoc_estatusmaterial
        listaParametros.Add(parametro)

        operaciones.EjecutarConsultaSP("SP_MpdificarMaterialOrdenCompra", listaParametros)
        Console.WriteLine("Mando la sentencia")
    End Sub

    ''' <summary>
    ''' Modifica materiales de la orden de compra
    ''' </summary>
    ''' <param name="MaterialOrdenDeCompra"></param>
    ''' <remarks></remarks>
    Public Sub ModificaMaterialOrdenDeCompra(ByVal MaterialOrdenDeCompra As Entidades.MaterialOrdenDeCompra)
        Dim operaciones As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "materialordendecompraid"
        parametro.Value = MaterialOrdenDeCompra.maoc_materialordendecompraid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "materialpreciosid"
        parametro.Value = MaterialOrdenDeCompra.maoc_materialpreciosid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "cantidad"
        parametro.Value = MaterialOrdenDeCompra.maoc_cantidad
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "preciounitario"
        parametro.Value = MaterialOrdenDeCompra.maoc_preciounitario
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "umpid"
        parametro.Value = MaterialOrdenDeCompra.maoc_umpid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "umcid"
        parametro.Value = MaterialOrdenDeCompra.maoc_umcid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ordencompraid"
        parametro.Value = MaterialOrdenDeCompra.maoc_ordencompraid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "usuariocreoid"
        parametro.Value = MaterialOrdenDeCompra.maoc_usuariocreoid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fechacreacion"
        parametro.Value = MaterialOrdenDeCompra.maoc_fechacreacion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "usuariomodifico"
        parametro.Value = MaterialOrdenDeCompra.maoc_usuariomodificoid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fechamodificacion"
        parametro.Value = MaterialOrdenDeCompra.maoc_fechamodificacion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "estatus"
        parametro.Value = MaterialOrdenDeCompra.maoc_estatusmaterial
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idmaterial"
        parametro.Value = MaterialOrdenDeCompra.maoc_materialid
        listaParametros.Add(parametro)

        operaciones.EjecutarConsultaSP("Proveedor.SP_InsertarMaterialOrdenCompra", listaParametros)
        Console.WriteLine("Mando la sentencia")
    End Sub

    ''' <summary>
    ''' Cambiar estatus de material en orden de compra "Eliminar"
    ''' </summary>
    ''' <param name="MaterialOrdenDeCompra"></param>
    ''' <remarks></remarks>
    Public Sub EliminarMaterialOrdenDeCompra(ByVal MaterialOrdenDeCompra As Entidades.MaterialOrdenDeCompra)
        Dim operaciones As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "materialpreciosid"
        parametro.Value = MaterialOrdenDeCompra.maoc_materialpreciosid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "usuariomodifico"
        parametro.Value = MaterialOrdenDeCompra.maoc_usuariomodificoid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fechamodificacion"
        parametro.Value = MaterialOrdenDeCompra.maoc_fechamodificacion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "estatus"
        parametro.Value = MaterialOrdenDeCompra.maoc_estatusmaterial
        listaParametros.Add(parametro)

        operaciones.EjecutarConsultaSP("SP_EliminarMaterialOrdenCompra", listaParametros)
        Console.WriteLine("Mando la sentencia")
    End Sub

    ''' <summary>
    ''' Lista de paises
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ListaPaises() As DataTable
        Dim operaciones As New OperacionesProcedimientos
        Dim consulta As String = String.Empty
        consulta = "select pais_paisid ,pais_nombre from framework.Paises ORDER BY pais_nombre asc"
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    ''' <summary>
    ''' lista familias
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ListaFamilias() As DataTable
        Dim operaciones As New OperacionesProcedimientos
        Dim consulta As String = String.Empty
        consulta = "select idClas 'ID', nombreClas'Familia' from Materiales.Clasificaciones"
        Return operaciones.EjecutaConsulta(consulta)
    End Function


    ''' <summary>
    ''' lista materiales por nave
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ListaMaterialesPorNave(ByVal idnave As Integer) As DataTable
        Dim operaciones As New OperacionesProcedimientos
        Dim consulta As String = String.Empty
        consulta = "SELECT m.dage_materialid 'ID MATERIAL', m.dage_descripcion 'DESCRIPCION' FROM Materiales.Materiales AS m "
        consulta += "JOIN Materiales.MaterialesNave as n on n.mn_materialid=m.dage_materialid and n.mn_idNave=" + idnave.ToString
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    ''' <summary>
    ''' lista de naves
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function listaNaves() As DataTable
        Dim operaciones As New OperacionesProcedimientos
        Dim consulta As String = String.Empty
        consulta = "select '' 'Seleccion',nave_naveid 'ID', nave_nombre 'Nave' from Framework.Nave "
        Return operaciones.EjecutaConsulta(consulta)
    End Function


    ''' <summary>
    ''' Lista de Estados
    ''' </summary>
    ''' <param name="paisid"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ListaEstados(ByVal paisid As Integer) As DataTable
        Dim operaciones As New OperacionesProcedimientos
        Dim consulta As String = String.Empty
        consulta = "select esta_estadoid ,esta_nombre from framework.Estados where esta_paisid = " + paisid.ToString + " ORDER BY esta_nombre asc"
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    ''' <summary>
    ''' Lista de ciudades
    ''' </summary>
    ''' <param name="estadoid"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ListaCiudades(ByVal estadoid As Integer) As DataTable
        Dim operaciones As New OperacionesProcedimientos
        Dim consulta As String = String.Empty
        consulta = "select city_ciudadid,city_nombre from framework.Ciudades where city_estadoid = " + estadoid.ToString + " ORDER BY city_nombre asc"
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    ''' <summary>
    ''' Lista de Materiales proveedor
    ''' </summary>
    ''' <param name="estadoid"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ListaMaterialesProveedor(ByVal proveedorid As Integer, ByVal naveid As Integer) As DataTable
        Dim operaciones As New OperacionesProcedimientos
        Dim consulta As String = String.Empty
        consulta = "select DISTINCT 0 as 'Seleccion', row_number() over (order by prma_descripcionProv desc) AS '#',mp.prma_descripcionProv as 'Descripción' "
        consulta += ",mp.prma_claveProveedor as 'Clave Proveedor',mp.prma_umproveedor as 'UMP', m.dage_materialid as'ID',mp.prma_umproduccion as 'UMC' "
        consulta += ",mp.prma_diasDeEntrega as 'Tiempo Entrega',mp.prma_preciounitario as 'Precio Unitario',m.dage_sku as 'SKU' "
        consulta += " ,cl.nombreClas as 'Clasificación' from Materiales.Materiales as m join Materiales.MaterialesNave as mn "
        consulta += "on m.dage_materialid=mn.mn_materialid join Materiales.MaterialesPrecio as mp on mp.prma_idMaterialNave=mn.mn_materialNaveid"
        consulta += " and mp.prma_provedorid=" + proveedorid.ToString + "and mp.prma_idnave=" + naveid.ToString
        consulta += " join Materiales.Clasificaciones as cl on cl.idClas=m.dage_idCategoria  and mn.mn_activo=1 and mp.prma_activo=1 and m.dage_activo=1 "
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    ''' <summary>
    ''' Lista de ordenes de compra general
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ListaOrdenesCompraGeneral(ByVal naveid As Integer) As DataTable
        Dim operaciones As New OperacionesProcedimientos
        Dim consulta As String = String.Empty
        consulta = "select oc.ordc_ordendecompraid 'ID',dg.dage_nombrecomercial 'Proveedor', oc.ordc_folio 'Folio',"
        consulta += "oc.ordc_fechaelaboracion 'Fecha Solicutud',oc.ordc_fechaentregaestimada 'Fecha Entrega',"
        consulta += "oc.ordc_total 'Importe', oc.ordc_documento 'Tipo Documento',oc.ordc_razonsocial 'Razon Socuial'"
        consulta += " from Proveedor.OrdenDeCompra as oc left join proveedor.DatosGenerales as dg on oc.ordc_proveedorid=dg.dage_proveedorid"
        consulta += "and oc.ordc_naveid= " + naveid.ToString
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    ''' <summary>
    ''' Lista de ordenes de compra filtrada por estatus
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ListaOrdenesCompraFiltrada(ByVal estatus As String, ByVal naveid As Integer) As DataTable
        Dim operaciones As New OperacionesProcedimientos
        Dim consulta As String = String.Empty
        consulta = "select oc.ordc_ordendecompraid 'ID',dg.dage_nombrecomercial 'Proveedor', oc.ordc_folio 'Folio',"
        consulta += "oc.ordc_fechaelaboracion 'Fecha Solicutud',oc.ordc_fechaentregaestimada 'Fecha Entrega',"
        consulta += "oc.ordc_total 'Importe', oc.ordc_documento 'Tipo Documento',oc.ordc_razonsocial 'Razon Socuial'"
        consulta += " from Proveedor.OrdenDeCompra as oc left join proveedor.DatosGenerales as dg on oc.ordc_proveedorid=dg.dage_proveedorid"
        consulta += " where oc.ordc_estatus=" + estatus + " and oc.ordc_naveid= " + naveid.ToString
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    ''' <summary>
    ''' Lista de ordenes de compra filtrada por folios
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ListaOrdenesCompraFiltradaFolio(ByVal folio As Integer) As DataTable
        Dim operaciones As New OperacionesProcedimientos
        Dim consulta As String = String.Empty
        consulta = "select oc.ordc_ordendecompraid 'ID',dg.dage_nombrecomercial 'Proveedor', oc.ordc_folio 'Folio',"
        consulta += "oc.ordc_fechaelaboracion 'Fecha Solicutud',oc.ordc_fechaentregaestimada 'Fecha Entrega',"
        consulta += "oc.ordc_total 'Importe', oc.ordc_documento 'Tipo Documento',oc.ordc_razonsocial 'Razon Socuial'"
        consulta += " from Proveedor.OrdenDeCompra as oc left join proveedor.DatosGenerales as dg on oc.ordc_proveedorid=dg.dage_proveedorid"
        consulta += " where oc.ordc_folio=" + folio.ToString
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    ''' <summary>
    ''' Lista x
    ''' </summary>
    ''' <param name="folio"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ListaOrdenesCompraFiltradax(ByVal folio As Integer, ByVal naveid As Integer) As DataTable
        Dim operaciones As New OperacionesProcedimientos
        Dim consulta As String = String.Empty
        consulta = "select oc.ordc_ordendecompraid 'ID',dg.dage_nombrecomercial 'Proveedor', oc.ordc_folio 'Folio',"
        consulta += "oc.ordc_fechaelaboracion 'Fecha Solicutud',oc.ordc_fechaentregaestimada 'Fecha Entrega',"
        consulta += "oc.ordc_total 'Importe', oc.ordc_documento 'Tipo Documento',oc.ordc_razonsocial 'Razon Socuial'"
        consulta += " from Proveedor.OrdenDeCompra as oc left join proveedor.DatosGenerales as dg on oc.ordc_proveedorid=dg.dage_proveedorid"
        consulta += " where oc.ordc_folio=" + folio.ToString + " and oc.ordc_naveid= " + naveid.ToString
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    ''' <summary>
    ''' Obtener ultimo folio registrado
    ''' </summary>
    ''' <param name="idPersona"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ObtenerUltimoFolio(ByVal idFolio As Int32) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "" +
                "SELECT top 1 (ordc_ordendecompraid) from Proveedor.OrdenDeCompra order by ordc_ordendecompraid DESC"
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    ''' <summary>
    ''' Consulta para llenar formulario con dato seleccionado
    ''' </summary>
    ''' <param name="idOC"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function consultaFormulario(ByVal idOC As Int32) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String
        consulta = "select  oc.ordc_estatus'Estatus', oc.ordc_naveid 'Nave', oc.ordc_proveedorid 'Proveedor', oc.ordc_fechaelaboracion 'Fecha'"
        consulta += ",oc.ordc_plazoid 'plazo',oc.ordc_prioridad 'Prioridad',oc.ordc_razonsocial 'RazonSocial',oc.ordc_documento 'Documento',"
        consulta += "oc.ordc_programainicio 'Del', oc.ordc_programafin 'Al',oc.ordc_total 'Total',oc.ordc_iva 'Iva',oc.ordc_subtotal 'Subtotal',"
        consulta += "oc.ordc_fechaentregaestimada 'Entrega',oc.ordc_fechapagoestimado 'Pago',oc.ordc_calleentrega 'Calle',oc.ordc_numeroentrega 'No',"
        consulta += "oc.ordc_coloniaentrega 'Colonia',oc.ordc_codigopostal 'Cp',oc.ordc_ciudadid 'Ciudad', oc.ordc_observaciones 'Observaciones',"
        consulta += "c.city_estadoid 'Estado',p.pais_paisid 'Pais' ,oc.ordc_folio'Folio' "
        consulta += "from Proveedor.OrdenDeCompra as oc join Framework.Ciudades as c on c.city_ciudadid=oc.ordc_ciudadid"
        consulta += " join Framework.Estados as e on e.esta_estadoid=c.city_estadoid join Framework.Paises as p on p.pais_paisid=e.esta_paisid"
        consulta += " where oc.ordc_ordendecompraid=" + idOC.ToString
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function consultaFormularioGrid(ByVal lista As List(Of Integer), ByVal proveedorid As Integer, ByVal naveid As Integer, ByVal oc As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String
        consulta = "select 0 as 'Seleccion', row_number() over (order by prma_descripcionProv desc) AS '#', mp.prma_descripcionProv as 'Descripción',"
        consulta += "mp.prma_claveProveedor as 'Clave Proveedor',mp.prma_umproveedor as 'UMP', m.dage_materialid as'ID',mp.prma_umproduccion as 'UMC',"
        consulta += "mp.prma_diasDeEntrega as 'Tiempo Entrega', mp.prma_preciounitario as 'Precio Unitario',m.dage_sku as 'SKU',cl.nombreClas as 'Clasificación',"
        consulta += "mo.maoc_cantidad as 'Cantidad', (mo.maoc_cantidad*mo.maoc_preciounitario) as 'Total',mp.prma_preciosmaterialid 'Id p' "
        consulta += "from Materiales.Materiales as m join Materiales.MaterialesNave as mn on m.dage_materialid=mn.mn_materialid "
        consulta += " join Materiales.MaterialesPrecio as mp on mp.prma_idMaterialNave=mn.mn_materialNaveid and mp.prma_provedorid="
        consulta += proveedorid.ToString + " and mp.prma_idnave= " + naveid.ToString
        consulta += " join Materiales.Clasificaciones as cl on cl.idClas=m.dage_idCategoria "
        consulta += " join Proveedor.MaterialesOrdenCompra as mo on mo.maoc_materialid=mn.mn_materialid "
        consulta += " join Proveedor.OrdenDeCompra as oc on oc.ordc_ordendecompraid=mo.maoc_ordendecompraid "
        consulta += "and mn.mn_activo=1 and mp.prma_activo=1 and m.dage_activo=1 and mo.maoc_eliminado is null and mo.maoc_ordendecompraid=" + oc.ToString
        consulta += "and mn.mn_materialid in("
        For Each id As Integer In lista
            consulta += " " & id & ","
        Next
        consulta += "0)"
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    ''' <summary>
    ''' Consulta general obtener todas las ordenes de compra de cierta nave y rango de fechas sin importar estatus
    ''' </summary>
    ''' <param name="idnave"></param>
    ''' <param name="del"></param>
    ''' <param name="al"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function consultaGeneral(ByVal idnave As Int32, ByVal del As String, ByVal al As String, ByVal anio As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String
        consulta = "select 0 'Seleccion', ''  '#',"
        consulta += "oc.ordc_ordendecompraid 'ID', p.dage_nombrecomercial 'Proveedor',oc.ordc_proveedorid 'ID c',oc.ordc_fechaelaboracion 'Fecha de Solicitud',oc.ordc_folio 'Folio',CASE  oc.ordc_estatus WHEN 'A'THEN 'AUTORIZADA' WHEN 'R' THEN 'RECHAZADA' WHEN 'C' THEN 'CAPTURADA' WHEN 'X' THEN 'CANCELADA' WHEN '/' THEN 'PARCIAL SURTIDA'WHEN 'P' THEN 'POR SURTIR'WHEN 'S' THEN 'SURTIDA'END AS 'Estatus',"
        consulta += " oc.ordc_fechaentregaestimada 'Fecha de Entrega' , oc.ordc_total 'Importe',CASE WHEN oc.ordc_documento = 'F' THEN 'FACTURA'  ELSE 'REMISIÓN' END AS 'Tipo de Documento',CASE  OC.ordc_prioridad WHEN 'A'THEN 'ALTA' WHEN 'B' THEN 'BAJA' WHEN 'M' THEN 'MEDIA' END AS 'Prioridad', "
        consulta += " en.empr_nombre 'Razon Social', pl.plpa_descripcion 'Plazo', oc.ordc_tipocaptura 'Tipo'"
        consulta += " from Proveedor.OrdenDeCompra as oc join Proveedor.DatosGenerales as p on p.dage_proveedorid=oc.ordc_proveedorid"
        consulta += " join Framework.Empresas as en on en.empr_empresaid=oc.ordc_razonsocial join Proveedor.PlazoPago as pl"
        consulta += " on pl.plpa_plazopagoid=oc.ordc_plazoid "
        consulta += "where ordc_naveid= " + idnave.ToString + " and ordc_año=" + anio.ToString + " and (ordc_fechaelaboracion Between '" + del.ToString
        consulta += "' AND '" + al.ToString + "')"
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    ''' <summary>
    ''' Busqueda por checkbox
    ''' </summary>
    ''' <param name="idnave"></param>
    ''' <param name="del"></param>
    ''' <param name="al"></param>
    ''' <param name="anio"></param>
    ''' <param name="busca"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function consulta1(ByVal idnave As Int32, ByVal del As String, ByVal al As String, ByVal anio As Integer, ByVal busca As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String
        consulta = "select 0 'Seleccion', ''  '#',"
        consulta += "oc.ordc_ordendecompraid 'ID', p.dage_nombrecomercial 'Proveedor',oc.ordc_proveedorid 'ID c',oc.ordc_fechaelaboracion 'Fecha de Solicitud',oc.ordc_folio 'Folio',CASE  oc.ordc_estatus WHEN 'A'THEN 'AUTORIZADA' WHEN 'R' THEN 'RECHAZADA' WHEN 'C' THEN 'CAPTURADA' WHEN 'X' THEN 'CANCELADA' WHEN '/' THEN 'PARCIAL SURTIDA'WHEN 'P' THEN 'POR SURTIR'WHEN 'S' THEN 'SURTIDA'END AS 'Estatus',"
        consulta += " oc.ordc_fechaentregaestimada 'Fecha de Entrega' , oc.ordc_total 'Importe',CASE WHEN oc.ordc_documento = 'F' THEN 'FACTURA'  ELSE 'REMISIÓN' END AS 'Tipo de Documento',CASE  OC.ordc_prioridad WHEN 'A'THEN 'ALTA' WHEN 'B' THEN 'BAJA' WHEN 'M' THEN 'MEDIA' END AS 'Prioridad', "
        consulta += " en.empr_nombre 'Razon Social', pl.plpa_descripcion 'Plazo', oc.ordc_tipocaptura 'Tipo'"
        consulta += " from Proveedor.OrdenDeCompra as oc join Proveedor.DatosGenerales as p on p.dage_proveedorid=oc.ordc_proveedorid"
        consulta += " join Framework.Empresas as en on en.empr_empresaid=oc.ordc_razonsocial join Proveedor.PlazoPago as pl"
        consulta += " on pl.plpa_plazopagoid=oc.ordc_plazoid "
        consulta += "where ordc_naveid= " + idnave.ToString + " and ordc_año=" + anio.ToString + " and (" + busca + " Between '" + del.ToString
        consulta += "' AND '" + al.ToString + "')"
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    ''' <summary>
    ''' Consulta por estatus, nave y rango de fechas
    ''' </summary>
    ''' <param name="idnave"></param>
    ''' <param name="del"></param>
    ''' <param name="al"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function consultaEstatus(ByVal idnave As Int32, ByVal del As String, ByVal al As String, ByVal anio As Integer, ByVal estatus As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String
        consulta = "select 0  'Seleccion', ''  '#',"
        consulta += "oc.ordc_ordendecompraid 'ID', p.dage_nombrecomercial 'Proveedor' ,oc.ordc_proveedorid 'ID c',oc.ordc_fechaelaboracion 'Fecha de Solicitud',oc.ordc_folio 'Folio',oc.ordc_estatus'Estatus',"
        consulta += " oc.ordc_fechaentregaestimada 'Fecha de Entrega' , oc.ordc_total 'Importe',CASE WHEN oc.ordc_documento = 'F' THEN 'FACTURA'  ELSE 'REMISIÓN' END AS 'Tipo de Documento',CASE  OC.ordc_prioridad WHEN 'A'THEN 'ALTA' WHEN 'B' THEN 'BAJA' WHEN 'M' THEN 'MEDIA' END AS 'Prioridad',  "
        consulta += " en.empr_nombre 'Razon Social', pl.plpa_descripcion 'Plazo', oc.ordc_tipocaptura 'Tipo'"
        consulta += " from Proveedor.OrdenDeCompra as oc join Proveedor.DatosGenerales as p on p.dage_proveedorid=oc.ordc_proveedorid"
        consulta += " join Framework.Empresas as en on en.empr_empresaid=oc.ordc_razonsocial join Proveedor.PlazoPago as pl"
        consulta += " on pl.plpa_plazopagoid=oc.ordc_plazoid "
        consulta += "where oc.ordc_naveid = " + idnave.ToString + " and oc.ordc_año =" + anio.ToString + " and oc.ordc_estatus ='" + estatus.ToString
        consulta += "' and (oc.ordc_fechaelaboracion Between '" + del.ToString
        consulta += "' AND '" + al.ToString + "')"
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    ''' <summary>
    ''' Consulta por folio, nave
    ''' </summary>
    ''' <param name="idnave"></param>
    ''' <param name="del"></param>
    ''' <param name="al"></param>
    ''' <param name="estatus"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function consultaFolio(ByVal idnave As Int32, ByVal anio As Integer, ByVal folio As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String
        consulta = "select 0 'Seleccion', '' '#',"
        consulta += " oc.ordc_ordendecompraid 'ID', p.dage_nombrecomercial 'Proveedor',oc.ordc_proveedorid 'ID c',oc.ordc_fechaelaboracion 'Fecha de Solicitud',oc.ordc_estatus'Estatus',"
        consulta += " oc.ordc_fechaentregaestimada 'Fecha de Entrega' ,oc.ordc_folio 'Folio', oc.ordc_total 'Importe', oc.ordc_documento 'Tipo de Documento', "
        consulta += " en.empr_nombre 'Razon Social', oc.ordc_prioridad 'Prioridad', pl.plpa_descripcion 'Plazo', oc.ordc_tipocaptura 'Tipo'"
        consulta += " from Proveedor.OrdenDeCompra as oc join Proveedor.DatosGenerales as p on p.dage_proveedorid=oc.ordc_proveedorid"
        consulta += " join Framework.Empresas as en on en.empr_empresaid=oc.ordc_razonsocial join Proveedor.PlazoPago as pl"
        consulta += " on pl.plpa_plazopagoid=oc.ordc_plazoid "
        consulta += "where oc.ordc_naveid=" + idnave.ToString + " and oc.ordc_folio =" + folio.ToString + "and oc.ordc_año = " + anio.ToString
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    ''' <summary>
    ''' Lista de proveedores por nave
    ''' </summary>
    ''' <param name="naveid"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ListaProveedorNave(ByVal naveid As Integer) As DataTable
        Dim operaciones As New OperacionesProcedimientos
        Dim consulta As String = String.Empty
        'If naveid = 0 Then 'mostrar todos los proveedores de todas las naves
        consulta = "select dg.dage_proveedorid as 'ID', dg.dage_nombrecomercial as 'NOMBRE' from Proveedor.DatosGenerales AS dg "
        consulta += "join Proveedor.ProveedorNave as pn on dg.dage_proveedorid = pn.dage_proveedorid and pn.nave_naveid= " + naveid.ToString
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    ''' <summary>
    ''' llenar Razones sociales asociadas a la nave
    ''' </summary>
    ''' <param name="naveid"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ListaRazonSocial(ByVal naveid As Integer) As DataTable
        Dim operaciones As New OperacionesProcedimientos
        Dim consulta As String = String.Empty
        'If naveid = 0 Then 'mostrar todos los proveedores de todas las naves
        consulta = "select  empr_empresaid 'ID',empr_rfc'RFC', empr_nombre 'NOMBRE' from Framework.EmpresasNave join  Framework.Empresas on "
        consulta += "emna_empresaid=empr_empresaid and emna_naveid= " + naveid.ToString
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    ''' <summary>
    ''' llenar combo plazo
    ''' </summary>
    ''' <param name="naveid"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ListaPLazoProveedor(ByVal proveedorid As Integer) As DataTable
        Dim operaciones As New OperacionesProcedimientos
        Dim consulta As String = String.Empty
        'If naveid = 0 Then 'mostrar todos los proveedores de todas las naves
        consulta += "select pl.plpa_plazopagoid 'ID', pl.plpa_plazo 'PLAZO' FROM Proveedor.PlazoPago AS pl JOIN Proveedor.PlazoProveedor "
        consulta += "AS pp ON pp.plpa_plazopagoid=pl.plpa_plazopagoid and pp.dage_proveedorid= " + proveedorid.ToString
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    ''' <summary>
    ''' Obtener dias de plazo
    ''' </summary>
    ''' <param name="plazoid"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ListaDiasPLazoProveedor(ByVal plazoid As Integer) As DataTable
        Dim operaciones As New OperacionesProcedimientos
        Dim consulta As String = String.Empty
        'If naveid = 0 Then 'mostrar todos los proveedores de todas las naves
        consulta = " select plpa_dias 'DIAS' from Proveedor.PlazoPago where plpa_plazopagoid=" + plazoid.ToString
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    ''' <summary>
    ''' Lista de materiales seleccionado para la orden de compra
    ''' </summary>
    ''' <param name="lista"></param>
    ''' <param name="proveedorid"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ListaMaterialSeleccionado(ByVal lista As List(Of Integer), ByVal proveedorid As Integer, ByVal naveid As Integer) As DataTable
        Dim operaciones As New OperacionesProcedimientos
        Dim consulta As String = String.Empty
        'If naveid = 0 Then 'mostrar todos los proveedores de todas las naves
        consulta = "select 0 as 'Seleccion', row_number() over (order by prma_descripcionProv desc) AS '#', "
        consulta += "mp.prma_descripcionProv as 'Descripción',mp.prma_claveProveedor as 'Clave Proveedor',mp.prma_umproveedor as 'UMP', "
        consulta += "m.dage_materialid as'ID',mp.prma_umproduccion as 'UMC',mp.prma_diasDeEntrega as 'Tiempo Entrega', "
        consulta += "mp.prma_preciounitario as 'Precio Unitario',m.dage_sku as 'SKU',cl.nombreClas as 'Clasificación' ,'' as 'Cantidad', '' as 'Total' ,mp.prma_preciosmaterialid 'Id p'"
        consulta += "from Materiales.Materiales as m join Materiales.MaterialesNave as mn "
        consulta += "on m.dage_materialid=mn.mn_materialid join Materiales.MaterialesPrecio as mp "
        consulta += "on mp.prma_idMaterialNave=mn.mn_materialNaveid and mp.prma_provedorid=" + proveedorid.ToString + "and mp.prma_idnave= " + naveid.ToString
        consulta += "join Materiales.Clasificaciones as cl on cl.idClas=m.dage_idCategoria "
        consulta += "and mn.mn_activo=1 and mp.prma_activo=1 and m.dage_activo=1 and mn.mn_materialid in ("
        For Each id As Integer In lista
            consulta += " " & id & ","
        Next
        consulta += "0)"
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    ''' <summary>
    ''' obtener id de lista de materiales en orden de compra
    ''' </summary>
    ''' <param name="lista"></param>
    ''' <param name="proveedorid"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ListaiDOrdenCompra(ByVal idoc As Integer) As DataTable
        Dim operaciones As New OperacionesProcedimientos
        Dim consulta As String = String.Empty
        consulta += "  select maoc_materialid 'ID' from Proveedor.MaterialesOrdenCompra "
        consulta += "where maoc_ordendecompraid= " + idoc.ToString + " and maoc_eliminado is null"
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    ''' <summary>
    ''' EJEMPLO CHARLY
    ''' </summary>
    ''' <param name="lista"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ListaMaterialSeleccionado(ByVal lista As List(Of Integer)) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim operacionesSAY As New Persistencia.OperacionesProcedimientos

        Dim consulta As String =
            <cadena>
            select ppt_listaid 'id',ppt_nombre 'nombre',Nave 'nave',
            ppt_inicio 'inicio',ppt_fin 'fin',nave_logotipourl 'url'
            from Proveedores.PreciosProductoTerminado inner join Naves ON IdNave=ppt_naveid 
            inner join [<%= operacionesSAY.Servidor %>].[<%= operacionesSAY.ToString %>].[Framework].[Naves] as n
            ON IdNave=n.nave_navesicyid
            WHERE ppt_listaid IN (
            </cadena>
        For Each id As Integer In lista
            consulta += " " & id & ","
        Next
        consulta += "0)"
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    ''' <summary>
    ''' Obtener direccion nave
    ''' </summary>
    ''' <param name="proveedorid"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function obtenerDirecciones(ByVal naveid As Integer) As DataTable
        Dim operaciones As New OperacionesProcedimientos
        Dim consulta As String = String.Empty
        consulta = "SELECT nave_calle 'CALLE', nave_colonia 'COLONIA', nave_numero 'NUMERO', nave_codigopostal 'CP' "
        consulta += " FROM Framework.Naves WHERE nave_naveid= " + naveid.ToString
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    ''' <summary>
    ''' Obtener informacion de orden de compra para reporte
    ''' </summary>
    ''' <param name="naveid"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function reporteOrdenDeCompra(ByVal idoc As Integer) As DataTable
        Dim operaciones As New OperacionesProcedimientos
        Dim consulta As String = String.Empty
        consulta = "select oc.ordc_folio 'Folio', oc.ordc_naveid 'Id nave', Convert(Varchar(10),GETDATE(),103)'Fecha',  Convert(Varchar(10),oc.ordc_fechaentregaestimada,103)'Fecha entrega',"
        consulta += "Convert(Varchar(10),oc.ordc_programainicio,103)'Periodo del', Convert(Varchar(10),oc.ordc_programafin,103)  'Periodo al', oc.ordc_prioridad 'Urgencia', oc.ordc_calleentrega 'Calle',"
        consulta += "oc.ordc_coloniaentrega 'Colonia', oc.ordc_numeroentrega'No', oc.ordc_usuariocreoid 'Usuario creo', oc.ordc_observaciones 'Observaciones',"
        consulta += "oc.ordc_subtotal 'Subtotal', oc.ordc_iva 'Iva', oc.ordc_total 'Total', dg.dage_nombrecomercial 'Cadena comercial',"
        consulta += "p.prov_nombregenerico 'Proveedor', dc.daco_telefono'Telefono', u.user_nombrereal 'Nombre',oc.ordc_estatus 'Estatus',oc.ordc_razoncancelacion 'Motivo' "
        consulta += "from proveedor.ordendecompra as oc join Proveedor.DatosGenerales as dg on oc.ordc_proveedorid=dg.dage_proveedorid "
        consulta += "join Proveedor.Proveedor as p on p.dage_proveedorid=dg.dage_proveedorid join Proveedor.DatosContacto as dc "
        consulta += "on dc.dage_proveedorid=dg.dage_proveedorid join framework.Usuarios as u on u.user_usuarioid=oc.ordc_usuariocreoid "
        consulta += "where oc.ordc_ordendecompraid= " + idoc.ToString
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    ''' <summary>
    ''' Obtener Id orden de compra recien ingresado
    ''' </summary>
    ''' <param name="idoc"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function idocRegistrado(ByVal folio As Integer, ByVal nave As Integer) As DataTable
        Dim operaciones As New OperacionesProcedimientos
        Dim consulta As String = String.Empty
        consulta += "select ordc_ordendecompraid from Proveedor.OrdenDeCompra where ordc_folio=" + folio.ToString
        consulta += "and ordc_naveid= " + nave.ToString
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    ''' <summary>
    ''' obtener informacion de la orden de compra materiales
    ''' </summary>
    ''' <param name="idoc"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function reporteOrdenDeCompraMateriales(ByVal idoc As Integer) As DataTable
        Dim operaciones As New OperacionesProcedimientos
        Dim consulta As String = String.Empty
        consulta = "select distinct m.maoc_cantidad 'cantidad', m.maoc_umpid 'um',  ma.dage_descripcion 'descripcion',"
        consulta += "CASE WHEN ma.dage_tipodematerial = 1 THEN 'DIRECTO'  ELSE 'INDIRECTO' END AS 'tipo', mp.prma_claveProveedor 'codigo',m.maoc_preciounitario 'preciou',"
        consulta += "(m.maoc_preciounitario*m.maoc_cantidad)'importe'"
        consulta += "from Proveedor.MaterialesOrdenCompra as m join Materiales.Materiales as ma on ma.dage_materialid=m.maoc_materialid "
        consulta += "join Materiales.MaterialesNave as mn on mn.mn_materialid=m.maoc_materialid join Materiales.MaterialesPrecio as mp  "
        consulta += "on mp.prma_idnave=mn.mn_idNave and mp.prma_preciosmaterialid=m.maoc_materialprecioid "
        consulta += "where m.maoc_ordendecompraid= " + idoc.ToString + " and m.maoc_eliminado is null "
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    ''' <summary>
    ''' Quien autoriza la orden de compra
    ''' </summary>
    ''' <param name="idoc"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function autorizo(ByVal idoc As Integer) As DataTable
        Dim operaciones As New OperacionesProcedimientos
        Dim consulta As String = String.Empty
        consulta += "select user_nombrereal from Framework.Usuarios join Proveedor.OrdenDeCompra on user_usuarioid=ordc_autorizacompraid"
        consulta += " where ordc_ordendecompraid=" + idoc.ToString
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    ''' <summary>
    ''' Obtener id pais, estado y ciudad
    ''' </summary>
    ''' <param name="ciudadid"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function obtenerPais(ByVal ciudadid As Integer) As DataTable
        Dim operaciones As New OperacionesProcedimientos
        Dim consulta As String = String.Empty
        consulta += "select c.city_estadoid 'ID c',c.city_nombre 'Ciudad', e.esta_paisid 'ID e',e.esta_nombre 'Estado',"
        consulta += "p.pais_paisid 'ID p', p.pais_nombre 'Pais' from Framework.Ciudades as c  join Framework.Estados as e on "
        consulta += "e.esta_estadoid = c.city_estadoid join Framework.Paises as p on "
        consulta += "p.pais_paisid=e.esta_paisid  and c.city_ciudadid=" + ciudadid.ToString
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    ''' <summary>
    ''' Obtener ultimo folio registrado
    ''' </summary>
    ''' <param name="idPersona"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ObtenerFolioRecienInsertado(ByVal id As Int32) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "SELECT top 1 (ordc_folio) from Proveedor.OrdenDeCompra   where ordc_proveedorid= " + id.ToString
        consulta += " order by ordc_folio DESC "
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    ''' <summary>
    ''' Ultima orden de compra
    ''' </summary>
    ''' <param name="id"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ultimaOrdenCompra() As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "SELECT top 1 (ordc_ordendecompraid) from Proveedor.OrdenDeCompra  order by ordc_ordendecompraid DESC "
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    ''' <summary>
    ''' Ultimo material ingresado
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ultimoMaterial() As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "SELECT top 1 (maoc_materialordendecompraid) from Proveedor.MaterialesOrdenCompra  order by maoc_materialordendecompraid DESC  "
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    ''' <summary>
    ''' obtener telefono del proveedor
    ''' </summary>
    ''' <param name="idproveedor"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function telefonoProveedor(ByVal idproveedor As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "  select daco_email FROM Proveedor.DatosContacto WHERE dage_proveedorid= " + idproveedor.ToString
        Return operaciones.EjecutaConsulta(consulta)
    End Function
  
    ''' <summary>
    ''' Llenar tabla con materiales de la orden de compra seleccionada
    ''' </summary>
    ''' <param name="proveedorid"></param>
    ''' <param name="idOc"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function LlenarTablacONSULTA(ByVal proveedorid As Integer, ByVal idOc As Integer) As DataTable
        Dim operaciones As New OperacionesProcedimientos
        Dim consulta As String = String.Empty
        'If naveid = 0 Then 'mostrar todos los proveedores de todas las naves
        consulta = " "
        consulta += " "

        Return operaciones.EjecutaConsulta(consulta)
    End Function

End Class




