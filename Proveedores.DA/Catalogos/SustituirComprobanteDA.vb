Public Class SustituirComprobanteDA
    Public Function getComprobante(ByVal id As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim datos As New DataTable
        Dim consulta As String =
            <cadena>
            select m.*,isNull(c.RazonSocial,'') Receptor,isnull(p.RazonSocial,'') Proveedor,isNull(c.rfc,'') RFCReceptor,isNull(p.RFC,'') RFCEmisor,Nave from 
            Proveedores.MaquilaComprobantes m left join Contribuyentes c on IDRazSoc=maco_receptorid
            left join Proveedores p on maco_proveedorid=IdProveedor left join Naves on m.maco_naveid=IdNave
            where maco_comprobanteid=
            </cadena>
        consulta += " " & id
        datos = operaciones.EjecutaConsulta(consulta)
        Return datos
    End Function
    Public Function updateComprobanteMaquila(ByVal idComprobante As Integer,
                                             ByVal idReceptor As Integer,
                                             ByVal motivo As String,
                                             ByVal fechadocumento As Date,
                                             ByVal uuid As String, ByVal xml As String, ByVal pdf As String,
                                             ByVal estatus As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim datos As New DataTable
        Dim consulta As String = "update Proveedores.MaquilaComprobantes set maco_fechadocumento='" & fechadocumento.ToString("dd/MM/yyyy") & "',"
        consulta += " maco_receptorid=" & idReceptor & ", maco_motivoSustitucion='" & motivo & "', maco_uuid='" & uuid & "',"
        consulta += " maco_rutaXML='" & xml & "', maco_rutapdf='" & pdf & "'"
        If estatus.Length > 0 Then
            consulta += " ,maco_estatus='" & estatus & "'"
        End If
        consulta += " where maco_comprobanteid = " & idComprobante    
        datos = operaciones.EjecutaConsulta(consulta)
        Return datos
    End Function
    Public Function updateComprobanteMaquilaRemision(ByVal idComprobante As Integer, ByVal pdf As String, ByVal motivo As String, ByVal estatus As String, ByVal folio As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim datos As New DataTable
        Dim consulta As String = "update Proveedores.MaquilaComprobantes set maco_folio='" & folio & "' ,maco_rutapdf='" & pdf & "',maco_motivoSustitucion='" & motivo & "'"
        If estatus.Length > 0 Then
            consulta += " ,maco_estatus='" & estatus & "'"
        End If
        consulta += " where maco_comprobanteid = " & idComprobante
        datos = operaciones.EjecutaConsulta(consulta)
        Return datos
    End Function
End Class
