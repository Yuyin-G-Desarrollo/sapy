Public Class ControlesEmbarque


    Public Shared Function ComboTipoEmbarque(ByVal ComboEntrada As System.Windows.Forms.ComboBox) As System.Windows.Forms.ComboBox
        ComboTipoEmbarque = New ComboBox
        ComboTipoEmbarque = ComboEntrada
        Dim tablaEmbarque As New DataTable
        Dim objEmbarque As New Embarque.Negocios.MensajeriaDestinoCostos
        tablaEmbarque = objEmbarque.ListaEmbarque

        tablaEmbarque.Rows.InsertAt(tablaEmbarque.NewRow, 0)
        ComboTipoEmbarque.DataSource = tablaEmbarque
        ComboTipoEmbarque.DisplayMember = "tire_nombre"
        ComboTipoEmbarque.ValueMember = "tire_tiporeembarqueid"




    End Function

    Public Shared Function ComboProveedores(ByVal ComboEntrada As System.Windows.Forms.ComboBox) As System.Windows.Forms.ComboBox
        ComboProveedores = New ComboBox
        ComboProveedores = ComboEntrada
        Dim tablaProveedores As New DataTable
        Dim objEmbarque As New Negocios.ProveedoresBU
        tablaProveedores = objEmbarque.ListaProveedores
        tablaProveedores.Rows.InsertAt(tablaProveedores.NewRow, 0)
        ComboProveedores.DataSource = tablaProveedores
        ComboProveedores.DisplayMember = "prov_nombregenerico"
        ComboProveedores.ValueMember = "prov_proveedorid"
    End Function


    Public Shared Function ComboTipoUnidad(ByVal ComboEntrada As System.Windows.Forms.ComboBox) As System.Windows.Forms.ComboBox
        ComboTipoUnidad = New ComboBox
        ComboTipoUnidad = ComboEntrada
        Dim tablaEmbarque As New DataTable
        Dim objEmbarque As New Embarque.Negocios.MensajeriaDestinoCostos
        tablaEmbarque = objEmbarque.ConsultarTipoUnidad

        tablaEmbarque.Rows.InsertAt(tablaEmbarque.NewRow, 0)
        ComboTipoUnidad.DataSource = tablaEmbarque
        ComboTipoUnidad.DisplayMember = "unid_nombre"
        ComboTipoUnidad.ValueMember = "unid_unidadid"




    End Function

End Class
