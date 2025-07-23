Public Class SalidaNavesProduccion_ConsultasFiltrosBU

    Private objDA As New Datos.SalidaNavesProduccion_ConsultasFiltrosDA

    Public Function ConsultarEstatusSalidasNaves() As DataTable
        Dim dt As DataTable
        Try
            dt = objDA.ConsultarEstatusSalidasNaves()
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function ConsultarNavesCEDIS() As List(Of Entidades.Naves)
        Dim dt As DataTable
        Dim ListaNaves As New List(Of Entidades.Naves)
        Try
            dt = objDA.ConsultarNavesCEDIS()

            For Each row As DataRow In dt.Rows
                Dim Nave As New Entidades.Naves
                Nave.PNaveId = row("NaveID")
                Nave.PNombre = row("Nave")
                Nave.PNaveSICYid = row("NaveSICY")
                ListaNaves.Add(Nave)
            Next
            Return ListaNaves
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ConsultarNavesCEDIS(ByVal IdNave As Integer) As DataTable
        Dim dt As DataTable
        Try
            dt = objDA.ConsultarNavesCEDIS(IdNave)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ListaNaves(ByVal IDUsuario As Integer) As DataTable
        Dim dt As DataTable
        Try
            dt = objDA.ListaNaves(IDUsuario)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ListaClientes() As DataTable
        Dim dt As DataTable
        Try
            dt = objDA.ListaClientes()
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ListaTiendas() As DataTable
        Dim dt As DataTable
        Try
            dt = objDA.ListaTiendas()
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ListaArticulos() As DataTable
        Dim dt As DataTable
        Try
            dt = objDA.ListaArticulos()
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ListaCorridas() As DataTable
        Dim dt As DataTable
        Try
            dt = objDA.ListaCorridas()
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ListaTallas() As DataTable
        Dim dt As DataTable
        Try
            dt = objDA.ListaTallas()
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ConsultarSalidasNavesProduccion(ByVal Filtros As Entidades.FiltrosSalidaNavesProduccion)
        Dim dt As DataTable
        Try
            dt = objDA.ConsultarSalidasNavesProduccion(Filtros)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function ObtenerTotalParesRecibidos(ByVal NaveSICYID As Integer, ByVal FechaSalidaInicio As Date, ByVal FechaSalidaFin As Date, ByVal CedisID As String, ByVal ComercializadoraId As Integer) As DataTable
        Dim objDA As New Almacen.Datos.SalidasAlmacenDA
        Try
            Return objDA.ObtenerTotalParesRecibidos(NaveSICYID, FechaSalidaInicio, FechaSalidaFin, CedisID, ComercializadoraId)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ObtenerTotalParesNoEmbarcados(ByVal NaveSICYID As Integer, ByVal FechaSalidaInicio As Date, ByVal FechaSalidaFin As Date, ByVal CedisID As String, ByVal ComercializadoraId As Integer) As DataTable
        Dim objDA As New Almacen.Datos.SalidasAlmacenDA
        Try
            Return objDA.ObtenerTotalParesNoEmbarcados(NaveSICYID, FechaSalidaInicio, FechaSalidaFin, CedisID, ComercializadoraId)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ObtenerTotalParesFaltantes(ByVal NaveSICYID As Integer, ByVal FechaSalidaInicio As Date, ByVal FechaSalidaFin As Date, ByVal CedisID As String, ByVal ComercializadoraId As Integer) As DataTable
        Dim objDA As New Almacen.Datos.SalidasAlmacenDA
        Try
            Return objDA.ObtenerTotalParesFaltantes(NaveSICYID, FechaSalidaInicio, FechaSalidaFin, CedisID, ComercializadoraId)
        Catch ex As Exception
            Throw ex
        End Try
    End Function


End Class
