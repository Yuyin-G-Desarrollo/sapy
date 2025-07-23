Imports Entidades
Imports Tools
Imports Proveedores.BU

Public Class CopiarListaPrecioForm

    Public lista As New ListaPrecioProd
    Dim adv As New AdvertenciaForm
    Dim exito As New ExitoForm

    Private Sub CopiarListaPrecioForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenarComboNaves()
        setDatosLista()
    End Sub
    Public Sub setDatosLista()
        Try
            Dim idNave As Integer = 0
            Dim obj As New ListaPreciosProdBU
            idNave = obj.getNaveSAY(lista.idNave)

            cmbNave.SelectedValue = idNave
            cmbNave2.SelectedValue = idNave
            txtNombreLista.Text = lista.nombre
            txtNombreLista2.Text = lista.nombre
            txtMarca.Text = lista.idmarca
            txtMarca2.Text = lista.idmarca
            txtColeccion.Text = lista.idcoleccion
            txtColeccion2.Text = lista.idcoleccion
            dtpFechaInicio.Value = lista.inicio
            dtpFechaInicio2.Value = lista.inicio
            dtpFechaFinal.Value = lista.fin
            dtpFechaFinal2.Value = lista.fin
        Catch ex As Exception
            adv.mensaje = "Surgió algo inesperado. Detalles: " & ex.Message
            adv.ShowDialog()
        End Try

    End Sub
    Public Sub llenarComboNaves()
        cmbNave = Controles.ComboNavesSegunUsuario(cmbNave, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
        cmbNave2 = Controles.ComboNavesSegunUsuario(cmbNave2, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim obj As New ListaPreciosProdBU
        Dim datos As New DataTable
        Dim idTmp As Integer = 0
        If validarCampos() Then
            Dim l As New ListaPrecioProd
            lista.idNave = obj.getNaveSIcy(cmbNave2.SelectedValue)
            l = lista
            idTmp = lista.listaid
            l.listaid = 0
            l.inicio = dtpFechaInicio2.Value
            l.fin = dtpFechaFinal2.Value
            l.nombre = txtNombreLista2.Text.Trim
            l.usuarioId = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
            datos = obj.getValidarLista(l)
            l.listaid = idTmp
            If datos.Rows.Count = 0 Then               
                obj.copiarListaPrecioProducto(l)
                exito.mensaje = "Lista copiada con exito."
                exito.ShowDialog()
            Else
                adv.mensaje = "Existe otra lista en la nave con la misma colección y coincidencia de vencimiento:  " & datos.Rows(0).Item(2).ToString & " DEL " & datos.Rows(0).Item(3).ToString & " AL " & datos.Rows(0).Item(4).ToString & ". Modifique las fechas de vigencia de la lista que está capturando"
                adv.ShowDialog()
            End If
        End If
    End Sub
    Public Function validarCampos() As Boolean
        If Not cmbNave2.SelectedIndex > 0 Then
            adv.mensaje = "Selecciona una nave."
            adv.ShowDialog()
            Return False
        End If
        If Not txtNombreLista2.Text.Trim.Length > 0 Then
            adv.mensaje = "Escriba un nombre para la lista."
            adv.ShowDialog()
            Return False
        End If
        Return True
    End Function

    Private Sub bntSalir_Click(sender As Object, e As EventArgs) Handles bntSalir.Click
        Me.Close()
    End Sub

    Private Sub pbYuyin_Click(sender As Object, e As EventArgs) Handles pbYuyin.Click

    End Sub
End Class