Public Class MensajeriaDestinoCostos

    Public Function ConsultaMensajeriaDestinoCosto() As List(Of Entidades.Mensajeria)
        Dim ObjDa As New Datos.MensajeriaDA
        Dim Consecutivo As Int32 = 1
        ConsultaMensajeriaDestinoCosto = New List(Of Entidades.Mensajeria)
        Dim tabla As New DataTable
        tabla = ObjDa.ConsultarMensajeriasCostosDestinos()
        Dim sentinela As Int32
        sentinela = 1
        For Each row As DataRow In tabla.Rows
            Dim Entidad As New Entidades.Mensajeria
            Entidad.PConsecutivo = Consecutivo
            Consecutivo += 1
            Entidad.PNombreProveedor = CStr(row("prov_nombregenerico"))
            Try
                If IsDBNull(row("pobl_nombre")) Then

                Else
                    Entidad.PNombrePoblacion = CStr(row("pobl_nombre"))
                End If
                ' Entidad.PNombrePoblacion = CStr(row("pobl_nombre"))
            Catch ex As Exception

            End Try


            Try

                If IsDBNull(row("city_nombre")) Then

                Else
                    Entidad.PNombreCiudad = CStr(row("city_nombre"))
                End If
                '  Entidad.PNombreCiudad = CStr(row("city_nombre"))
            Catch ex As Exception

            End Try
            Try

                If IsDBNull(row("esta_abreviatura")) Then
                    Entidad.PAbrevEstado = CStr(row("EstadoPoblacion"))
                Else
                    Entidad.PAbrevEstado = CStr(row("esta_abreviatura"))
                End If

                ' Entidad.PAbrevEstado = CStr(row("esta_abreviatura"))
            Catch ex As Exception

            End Try

            Try

                If IsDBNull(row("pais_abreviatura")) Then
                    Entidad.PAbrevPais = CStr(row("PaisPoblacion"))
                Else
                    Entidad.PAbrevPais = CStr(row("pais_abreviatura"))
                End If
                'Entidad.PAbrevPais = CStr(row("pais_abreviatura"))
            Catch ex As Exception

            End Try
            Try
                Entidad.PNombreUnidad = CStr(row("unid_nombre"))
            Catch ex As Exception

            End Try
            Try

                Entidad.PReembarque = CStr(row("tire_nombre"))
            Catch ex As Exception

            End Try

            Try
                If IsDBNull(row("CiudadPoblacion")) Then

                Else
                    Entidad.PNombreCiudad = CStr(row("CiudadPoblacion"))
                End If

                ' Entidad.PNombreCiudadPoblacion = CStr(row("CiudadPoblacion"))
            Catch ex As Exception

            End Try
            Try
                Entidad.PDiasMinEntregas = CInt(row("codm_diasminimoentrega"))
            Catch ex As Exception

            End Try
            Try
                Entidad.PDiasMaxEntregas = CInt(row("codm_diasmaximoentrega"))
            Catch ex As Exception

            End Try

            Try
                If row("codm_costoporunidad") = Nothing Then
                Else


                    Entidad.PCostoUnidad = CDbl(row("codm_costoporunidad"))
                End If
            Catch ex As Exception

            End Try

            Try
                Entidad.PFechaAlta = row("codm_fechacreacion")
            Catch ex As Exception

            End Try
            Try
                Entidad.PIDCostoMensajeria = CInt(row("codm_costodestinomensajeriaid"))
            Catch ex As Exception

            End Try

            Try
                Entidad.PFechaAlta = Entidad.PFechaAlta
            Catch ex As Exception

            End Try
            Try
                Entidad.PActivo = CBool(row("codm_activo"))
            Catch ex As Exception

            End Try

            Try
                Entidad.PUsuario = row("Usuario")
            Catch ex As Exception

            End Try

            ConsultaMensajeriaDestinoCosto.Add(Entidad)
            sentinela += 1
        Next
        Return ConsultaMensajeriaDestinoCosto
    End Function

    Public Function ConsultarTipoEmbarque() As DataTable
        Dim objDA As New Datos.MensajeriaDA
        Dim tabla As New DataTable
        tabla = objDA.ConsultarTipoReembarque()
        Return tabla
    End Function

    Public Function ConsultarTipoUnidad() As DataTable
        Dim objDA As New Datos.MensajeriaDA
        Dim tabla As New DataTable
        tabla = objDA.ConsultarTipoUnidad()
        Return tabla
    End Function


    Public Sub ActualizarCostoDestino(ByVal Entidad As Entidades.Mensajeria, ByVal TipoActualizacion As Boolean)
        Dim objDA As New Datos.MensajeriaDA
        objDA.ActualizarCostoDestino(Entidad, TipoActualizacion)
    End Sub

    Public Function ListaEmbarque() As DataTable
        Dim objDA As New Datos.MensajeriaDA
        Dim tabla As New DataTable
        tabla = objDA.ListaEmbarque()
        Return tabla
    End Function

    Public Function ConsultarMensajeriasCostosProveedor(ByVal idProveedor As Int32, ByVal idCiudad As Int32, ByVal idEstado As Int32, ByVal idPais As Int32, ByVal idPoblacion As Int32, ByVal UnidadID As Int32) As List(Of Entidades.Mensajeria)
        Dim OBJDA As New Datos.MensajeriaDA
        Dim tabla As New DataTable
        tabla = OBJDA.ConsultarMensajeriasCostosProveedor(idProveedor, idCiudad, idEstado, idPais, idPoblacion, UnidadID)
        Dim Consecutivo As Int32 = 1
        ConsultarMensajeriasCostosProveedor = New List(Of Entidades.Mensajeria)

        For Each row As DataRow In tabla.Rows
            Dim Entidad As New Entidades.Mensajeria
            Entidad.PConsecutivo = Consecutivo
            Consecutivo += 1
            Entidad.PNombreProveedor = CStr(row("prov_nombregenerico"))
            Try
                If IsDBNull(row("pobl_nombre")) Then

                Else
                    Entidad.PNombrePoblacion = CStr(row("pobl_nombre"))
                End If
                ' Entidad.PNombrePoblacion = CStr(row("pobl_nombre"))
            Catch ex As Exception
            End Try

            Try
                If IsDBNull(row("city_nombre")) Then

                Else
                    Entidad.PNombreCiudad = CStr(row("city_nombre"))
                End If
                '  Entidad.PNombreCiudad = CStr(row("city_nombre"))
            Catch ex As Exception

            End Try
            Try

                If IsDBNull(row("esta_abreviatura")) Then
                    Entidad.PAbrevEstado = CStr(row("EstadoPoblacion"))
                Else
                    Entidad.PAbrevEstado = CStr(row("esta_abreviatura"))
                End If

                ' Entidad.PAbrevEstado = CStr(row("esta_abreviatura"))
            Catch ex As Exception

            End Try

            Try

                If IsDBNull(row("pais_abreviatura")) Then
                    Entidad.PAbrevPais = CStr(row("PaisPoblacion"))
                Else
                    Entidad.PAbrevPais = CStr(row("pais_abreviatura"))
                End If
                'Entidad.PAbrevPais = CStr(row("pais_abreviatura"))
            Catch ex As Exception

            End Try

            Entidad.PNombreUnidad = CStr(row("unid_nombre"))
            Entidad.PReembarque = CStr(row("tire_nombre"))
            Try
                If IsDBNull(row("CiudadPoblacion")) Then

                Else
                    Entidad.PNombreCiudad = CStr(row("CiudadPoblacion"))
                End If

                ' Entidad.PNombreCiudadPoblacion = CStr(row("CiudadPoblacion"))
            Catch ex As Exception

            End Try

            Entidad.PDiasMinEntregas = CInt(row("codm_diasminimoentrega"))
            Entidad.PDiasMaxEntregas = CInt(row("codm_diasmaximoentrega"))
            Entidad.PCostoUnidad = CDbl(row("codm_costoporunidad"))
            Entidad.PFechaAlta = row("Modificación")
            Entidad.PUsuario = CStr(row("Usuario"))
            Entidad.PIDCostoMensajeria = CInt(row("codm_costodestinomensajeriaid"))
            Entidad.PFechaAlta = Entidad.PFechaAlta
            Entidad.PActivo = CBool(row("codm_activo"))
            ConsultarMensajeriasCostosProveedor.Add(Entidad)
        Next

        Return ConsultarMensajeriasCostosProveedor


    End Function







    Public Function ValidarCostoDestino(ByVal idProveedor As Int32, ByVal idCiudad As Int32, ByVal idEstado As Int32, ByVal idPais As Int32, ByVal idPoblacion As Int32, ByVal UnidadID As Int32) As List(Of Entidades.Mensajeria)
        Dim OBJDA As New Datos.MensajeriaDA
        Dim tabla As New DataTable
        tabla = OBJDA.ConsultarMensajeriasCostosProveedor(idProveedor, idCiudad, idEstado, idPais, idPoblacion, UnidadID)
        Dim Consecutivo As Int32 = 1
        ValidarCostoDestino = New List(Of Entidades.Mensajeria)

        For Each row As DataRow In tabla.Rows
            Dim Entidad As New Entidades.Mensajeria
            Entidad.PConsecutivo = Consecutivo
            Consecutivo += 1
            Entidad.PNombreProveedor = CStr(row("prov_nombregenerico"))
            Try
                If IsDBNull(row("pobl_nombre")) Then

                Else
                    Entidad.PNombrePoblacion = CStr(row("pobl_nombre"))
                End If
                ' Entidad.PNombrePoblacion = CStr(row("pobl_nombre"))
            Catch ex As Exception

            End Try

            Try

                If IsDBNull(row("city_nombre")) Then

                Else
                    Entidad.PNombreCiudad = CStr(row("city_nombre"))
                End If
                '  Entidad.PNombreCiudad = CStr(row("city_nombre"))
            Catch ex As Exception

            End Try
            Try

                If IsDBNull(row("esta_abreviatura")) Then
                    Entidad.PAbrevEstado = CStr(row("EstadoPoblacion"))
                Else
                    Entidad.PAbrevEstado = CStr(row("esta_abreviatura"))
                End If

                ' Entidad.PAbrevEstado = CStr(row("esta_abreviatura"))
            Catch ex As Exception

            End Try

            Try

                If IsDBNull(row("pais_abreviatura")) Then
                    Entidad.PAbrevPais = CStr(row("PaisPoblacion"))
                Else
                    Entidad.PAbrevPais = CStr(row("pais_abreviatura"))
                End If
                'Entidad.PAbrevPais = CStr(row("pais_abreviatura"))
            Catch ex As Exception

            End Try

            Entidad.PNombreUnidad = CStr(row("unid_nombre"))
            Entidad.PReembarque = CStr(row("tire_nombre"))
            Try
                If IsDBNull(row("CiudadPoblacion")) Then

                Else
                    Entidad.PNombreCiudad = CStr(row("CiudadPoblacion"))
                End If

                ' Entidad.PNombreCiudadPoblacion = CStr(row("CiudadPoblacion"))
            Catch ex As Exception

            End Try

            Entidad.PDiasMinEntregas = CInt(row("codm_diasminimoentrega"))
            Entidad.PDiasMaxEntregas = CInt(row("codm_diasmaximoentrega"))
            Entidad.PCostoUnidad = CDbl(row("codm_costoporunidad"))
            Entidad.PFechaAlta = row("Modificación")
            Entidad.PIDCostoMensajeria = CInt(row("codm_costodestinomensajeriaid"))
            Entidad.PFechaAlta = Entidad.PFechaAlta.ToShortDateString
            Entidad.PActivo = CBool(row("codm_activo"))
            ValidarCostoDestino.Add(Entidad)
        Next
        Return ValidarCostoDestino


    End Function



    Public Sub AltaNuevoCostoDestinoMensajeria(ByVal EntidadMensajeria As Entidades.Mensajeria)
        Dim objDA As New Datos.MensajeriaDA
        objDA.AltaNuevoCostoDestinoMensajeria(EntidadMensajeria)
    End Sub

    Public Function ObtenerIDDestinoMensajeria(ByVal idProveedor As Int32, ByVal IdCiudad As Int32, IdPoblacion As Integer) As Integer
        Dim objbu As New Negocios.MensajeriaBU
        Dim tabla As New DataTable
        tabla = objbu.ObtenerIDDestinoMensajeria(idProveedor, IdCiudad, IdPoblacion)
        Dim idDestino As Int32
        idDestino = 0
        For Each row As DataRow In tabla.Rows
            idDestino = CInt(row("deme_destinomensajeriaid"))
        Next
        Return idDestino
    End Function


    Public Sub InsertDestino(ByVal Proveedorid As Int32, ByVal CiudadID As Int32, ByVal PoblacionID As Int32)
        Dim objDA As New Datos.MensajeriaDA
        objDA.InsertDestino(Proveedorid, CiudadID, PoblacionID)
    End Sub



End Class
