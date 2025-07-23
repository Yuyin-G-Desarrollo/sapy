Public Class Utilerias

    Enum TipoMensaje
        Advertencia
        Aviso
        Errores
        Exito
        Confirmacion
    End Enum

    Public Shared Sub show_message(ByVal tipo As TipoMensaje, ByVal mensaje As String)

        Try
            If tipo = TipoMensaje.Advertencia Then
                Dim mensajeAdvertencia As New AdvertenciaForm
                mensajeAdvertencia.mensaje = mensaje
                mensajeAdvertencia.ShowDialog()
            End If

            If tipo = TipoMensaje.Aviso Then
                Dim mensajeAviso As New AvisoForm
                mensajeAviso.mensaje = mensaje
                mensajeAviso.ShowDialog()
            End If

            If tipo = TipoMensaje.Errores Then
                Dim mensajeError As New ErroresForm
                mensajeError.mensaje = mensaje
                mensajeError.ShowDialog()
            End If

            If tipo = TipoMensaje.Exito Then
                Dim mensajeExito As New ExitoForm
                mensajeExito.mensaje = mensaje
                mensajeExito.ShowDialog()
            End If

            If tipo = TipoMensaje.Confirmacion Then
                Dim mensajeExito As New ConfirmarForm
                mensajeExito.mensaje = mensaje
                mensajeExito.ShowDialog()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Public Shared Function ComboObtenerCEDISUsuario(ByVal comboEntrada As System.Windows.Forms.ComboBox) As System.Windows.Forms.ComboBox
        Dim objbu As New Almacen.Negocios.AlmacenBU
        Dim dtInformacionCentroDistribucion As DataTable

        ComboObtenerCEDISUsuario = New ComboBox
        ComboObtenerCEDISUsuario = comboEntrada

        Dim listaPaises As New List(Of Entidades.Paises)
        dtInformacionCentroDistribucion = objbu.ConsultaCentroDistribucionActivosUsuario(Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
        ComboObtenerCEDISUsuario.DataSource = dtInformacionCentroDistribucion
        ComboObtenerCEDISUsuario.DisplayMember = "Nave"
        ComboObtenerCEDISUsuario.ValueMember = "NaveSAYID"
    End Function

    Public Shared Function ComboObtenerCEDIS(ByVal comboEntrada As System.Windows.Forms.ComboBox) As System.Windows.Forms.ComboBox
        Dim objbu As New Almacen.Negocios.AlmacenBU
        Dim dtInformacionCentroDistribucion As DataTable

        ComboObtenerCEDIS = New ComboBox
        ComboObtenerCEDIS = comboEntrada

        Dim listaPaises As New List(Of Entidades.Paises)
        dtInformacionCentroDistribucion = objbu.ConsultaCentroDistribucionActivos()
        ComboObtenerCEDIS.DataSource = dtInformacionCentroDistribucion
        ComboObtenerCEDIS.DisplayMember = "Nave"
        ComboObtenerCEDIS.ValueMember = "NaveSAYID"


    End Function

    'Se agrego para tomar el usuario por medio del SAYWEB
    Public Function ComboObtenerCEDISUsuarioWEB(ByVal UsuarioActual As Integer) As DataTable
        Dim objbu As New Almacen.Negocios.AlmacenBU
        Dim dtInformacionCentroDistribucion As DataTable

        dtInformacionCentroDistribucion = objbu.ConsultaCentroDistribucionActivosUsuario(UsuarioActual)
        Return dtInformacionCentroDistribucion
    End Function

End Class
