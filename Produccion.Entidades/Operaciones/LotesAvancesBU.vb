Imports Produccion.Datos
Imports Entidades

''' <summary>
''' 
''' </summary>
''' <remarks></remarks>
Public Class LotesAvancesBU

    Public Function ListaLotesAvances(ByVal vNave As Int32,
                                     ByVal vBuscaFechaLote As Int16,
                                     ByVal vFechaLoteIni As DateTime,
                                     ByVal vFechaLoteFin As DateTime,
                                     ByVal vEstatus As String,
                                     ByVal vNoLote As Int32,
                                     ByVal vDepto As Int32,
                                     ByVal vCelula As Int32,
                                     ByVal vBuscaFechaAva As Int16,
                                     ByVal vFechaAvaIni As DateTime,
                                     ByVal vFechaAvaFin As DateTime) As List(Of LotesAvances)

        Dim objDA As New Datos.LotesAvancesDA
        Dim tabla As New DataTable
        ListaLotesAvances = New List(Of LotesAvances)
        tabla = objDA.ListaLotesAvances(vNave, vBuscaFechaLote, vFechaLoteIni, vFechaLoteFin, vEstatus, vNoLote, vDepto, vCelula, vBuscaFechaAva, vFechaAvaIni, vFechaAvaFin)
        For Each fila As DataRow In tabla.Rows
            Dim LoteAvance As New LotesAvances

            LoteAvance.PAño = CInt(fila("Año"))
            LoteAvance.PNave = CByte(fila("Nave"))
            LoteAvance.PLote = CInt(fila("Lote"))
            LoteAvance.PModelo = CStr(fila("Modelo"))
            LoteAvance.PColeccion = CStr(fila("Coleccion"))
            LoteAvance.PTalla = CStr(fila("Talla"))
            LoteAvance.PColor = CStr(fila("Color"))
            LoteAvance.PPares = CInt(fila("Pares"))
            LoteAvance.PObservaciones = CStr(fila("Observacion"))

            LoteAvance.PIdD1 = CByte(fila("IdD1"))
            LoteAvance.PD1 = CStr(fila("D1"))
            LoteAvance.PFD1 = CDate(fila("FD1"))

            LoteAvance.PIdD2 = CByte(fila("IdD2"))
            LoteAvance.PD2 = CStr(fila("D2"))
            LoteAvance.PFD2 = CDate(fila("FD2"))

            LoteAvance.PIdD3 = CByte(fila("IdD3"))
            LoteAvance.PD3 = CStr(fila("D3"))
            LoteAvance.PFD3 = CDate(fila("FD3"))

            LoteAvance.PIdD4 = CByte(fila("IdD4"))
            LoteAvance.PD4 = CStr(fila("D4"))
            LoteAvance.PFD4 = CDate(fila("FD4"))

            LoteAvance.PIdD5 = CByte(fila("IdD5"))
            LoteAvance.PD5 = CStr(fila("D5"))
            LoteAvance.PFD5 = CDate(fila("FD5"))

            LoteAvance.PFechaEmbarque = CDate(fila("EMBARQUE"))
            LoteAvance.PFechaLote = CDate(fila("FechaLote"))

            ListaLotesAvances.Add(LoteAvance)
        Next
    End Function

    Public Function ListaAvancesProduccion(ByVal FechaInicio As Date, ByVal FechaFin As Date, ByVal Naveid As Int32, ByVal Departamentos As List(Of DepartamentosProduccion)) As List(Of LotesAvances)
        Dim objDa As New Datos.LotesAvancesDA
        Dim tablaAvances As DataTable
        ListaAvancesProduccion = New List(Of LotesAvances)
        tablaAvances = objDa.ListaAvancesProduccion(FechaInicio, FechaFin, Naveid, Departamentos)
        For Each row As DataRow In tablaAvances.Rows
            Dim Lote As New LotesAvances
            Lote.PFechaLote = CDate(row("Fecha"))
            Lote.PLote = CInt(row("Lote"))
            Lote.PModelo = CStr(row("IdModelo"))
            Lote.PColeccion = CStr(row("Coleccion"))
            Lote.PTalla = CStr(row("Talla"))
            Lote.PColor = CStr(row("Color"))
            Lote.pclienteTexto = CStr(row("Cliente_Texto"))
            If CInt(row("Lote")) = 11555 Then
                Lote.PColor = CStr(row("Color"))
                Lote.pclienteTexto = CStr(row("Cliente_Texto"))
            End If
            Try
                If Departamentos(0).PNombre = "CORTE" Then
                    Lote.pmotivoDepartamento1 = CStr(row("motivoDepartamento" + Departamentos(0).PIDConfiguracion.ToString))
                    Lote.PDiasAtrasados1 = CStr(row("diasAtrasos" + Departamentos(0).PIDConfiguracion.ToString))
                End If
                If Departamentos(0).PNombre = "PESPUNTE" Then
                    Lote.pmotivoDepartamento2 = CStr(row("motivoDepartamento" + Departamentos(0).PIDConfiguracion.ToString))
                    Lote.PDiasAtrasados2 = CStr(row("diasAtrasos" + Departamentos(0).PIDConfiguracion.ToString))
                End If
                If Departamentos(0).PNombre = "MONTADO Y ADORNO" Then
                    Lote.pmotivoDepartamento3 = CStr(row("motivoDepartamento" + Departamentos(0).PIDConfiguracion.ToString))
                    Lote.PDiasAtrasados3 = CStr(row("diasAtrasos" + Departamentos(0).PIDConfiguracion.ToString))
                End If
            Catch ex As Exception
                'MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK)
            End Try
            Try
                If Departamentos(1).PNombre = "CORTE" Then
                    Lote.pmotivoDepartamento1 = CStr(row("motivoDepartamento" + Departamentos(1).PIDConfiguracion.ToString))
                    Lote.PDiasAtrasados1 = CStr(row("diasAtrasos" + Departamentos(1).PIDConfiguracion.ToString))
                End If
                If Departamentos(1).PNombre = "PESPUNTE" Then
                    Lote.pmotivoDepartamento2 = CStr(row("motivoDepartamento" + Departamentos(1).PIDConfiguracion.ToString))
                    Lote.PDiasAtrasados2 = CStr(row("diasAtrasos" + Departamentos(1).PIDConfiguracion.ToString))
                End If
                If Departamentos(1).PNombre = "MONTADO Y ADORNO" Then
                    Lote.pmotivoDepartamento3 = CStr(row("motivoDepartamento" + Departamentos(1).PIDConfiguracion.ToString))
                    Lote.PDiasAtrasados3 = CStr(row("diasAtrasos" + Departamentos(1).PIDConfiguracion.ToString))
                End If
            Catch ex As Exception
                'MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK)
            End Try
            Try
                If Departamentos(2).PNombre = "CORTE" Then
                    Lote.pmotivoDepartamento1 = CStr(row("motivoDepartamento" + Departamentos(2).PIDConfiguracion.ToString))
                    Lote.PDiasAtrasados1 = CStr(row("diasAtrasos" + Departamentos(2).PIDConfiguracion.ToString))
                End If
                If Departamentos(2).PNombre = "PESPUNTE" Then
                    Lote.pmotivoDepartamento2 = CStr(row("motivoDepartamento" + Departamentos(2).PIDConfiguracion.ToString))
                    Lote.PDiasAtrasados2 = CStr(row("diasAtrasos" + Departamentos(2).PIDConfiguracion.ToString))
                End If
                If Departamentos(2).PNombre = "MONTADO Y ADORNO" Then
                    Lote.pmotivoDepartamento3 = CStr(row("motivoDepartamento" + Departamentos(2).PIDConfiguracion.ToString))
                    Lote.PDiasAtrasados3 = CStr(row("diasAtrasos" + Departamentos(2).PIDConfiguracion.ToString))

                End If
            Catch ex As Exception
                'MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK)
            End Try
            Try
                Lote.PPares = CInt(row("Pares"))
            Catch ex As Exception

            End Try

            Lote.PObservaciones = CStr(row("Observacion"))
            Try
                'Lote.PProductoTerminado = CDate(row("ProductoTerminado"))
                Lote.PFechaEmbarque = CDate(row("Fecha_Salida"))
            Catch ex As Exception

            End Try

            'Try
            '    Lote.PavanceDepartamento1 = CDate(row("avanceDepartamento1"))

            'Catch ex As Exception

            'End Try
            'Try
            '    Lote.PavanceDepartamento2 = CDate(row("avanceDepartamento2"))

            'Catch ex As Exception

            'End Try
            'Try

            '    Lote.PavanceDepartamento3 = CDate(row("avanceDepartamento3"))
            'Catch ex As Exception

            'End Try

            'codigo juana
            Dim listaFechasAvance As New List(Of DepartamentosProduccion)
            For Each dep As DepartamentosProduccion In Departamentos
                Dim departamento As New DepartamentosProduccion
                departamento.PDias = dep.PDias
                departamento.PIDConfiguracion = dep.PIDConfiguracion
                departamento.PNombre = dep.PNombre
                Dim nombreCol As String = "avanceDepartamento" + dep.PIDConfiguracion.ToString
                Dim nombreCelula As String = "Celula" + dep.PIDConfiguracion.ToString
                Dim fechaAvance As New DateTime
                Try
                    fechaAvance = CDate(row(nombreCol))
                    departamento.PFechaAvance = fechaAvance
                Catch ex As Exception
                    departamento.PFechaAvance = Nothing
                End Try
                Try
                    departamento.PCelulas = CStr(row(nombreCelula))

                Catch ex As Exception
                    departamento.PCelulas = Nothing

                End Try

                listaFechasAvance.Add(departamento)
                'Try
                '    departamento.PCelulas = CStr(row(nombreCelula))
                '    listaFechasAvance.Add(departamento)
                'Catch ex As Exception
                '    departamento.PCelulas = Nothing
                '    listaFechasAvance.Add(departamento)
                'End Try
            Next
            Lote.PAvanceDepartamentos = listaFechasAvance

            ListaAvancesProduccion.Add(Lote)
        Next
        Return ListaAvancesProduccion
    End Function
    Public Function ListaAvancesProduccionDetallado(ByVal FechaInicio As Date, ByVal FechaFin As Date, ByVal Naveid As Int32, ByVal Departamentos As List(Of DepartamentosProduccion)) As List(Of LotesAvances)
        Dim objDa As New Datos.LotesAvancesDA
        Dim tablaAvances As DataTable
        ListaAvancesProduccionDetallado = New List(Of LotesAvances)
        tablaAvances = objDa.ListaAvancesProduccionDetallado(FechaInicio, FechaFin, Naveid, Departamentos)
        For Each row As DataRow In tablaAvances.Rows
            Dim Lote As New LotesAvances
            Lote.PFechaLote = CDate(row("Fecha"))
            Lote.PLote = CInt(row("Lote"))
            Lote.PModelo = CStr(row("IdModelo"))
            Lote.PColeccion = CStr(row("Coleccion"))
            Lote.PTalla = CStr(row("Talla"))
            Lote.PColor = CStr(row("Color"))
            Lote.pclienteTexto = CStr(row("nombre"))
            Lote.pidPedido = CStr(row("IdPedido"))
            Try
                If Departamentos(0).PNombre = "CORTE" Then
                    Lote.pmotivoDepartamento1 = CStr(row("motivoDepartamento" + Departamentos(0).PIDConfiguracion.ToString))
                    Lote.PDiasAtrasados1 = CStr(row("diasAtrasos" + Departamentos(0).PIDConfiguracion.ToString))
                End If
                If Departamentos(0).PNombre = "PESPUNTE" Then
                    Lote.pmotivoDepartamento2 = CStr(row("motivoDepartamento" + Departamentos(0).PIDConfiguracion.ToString))
                    Lote.PDiasAtrasados2 = CStr(row("diasAtrasos" + Departamentos(0).PIDConfiguracion.ToString))
                End If
                If Departamentos(0).PNombre = "MONTADO Y ADORNO" Then
                    Lote.pmotivoDepartamento3 = CStr(row("motivoDepartamento" + Departamentos(0).PIDConfiguracion.ToString))
                    Lote.PDiasAtrasados3 = CStr(row("diasAtrasos" + Departamentos(0).PIDConfiguracion.ToString))
                End If
            Catch ex As Exception
                'MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK)
            End Try
            Try
                If Departamentos(1).PNombre = "CORTE" Then
                    Lote.pmotivoDepartamento1 = CStr(row("motivoDepartamento" + Departamentos(1).PIDConfiguracion.ToString))
                    Lote.PDiasAtrasados1 = CStr(row("diasAtrasos" + Departamentos(1).PIDConfiguracion.ToString))
                End If
                If Departamentos(1).PNombre = "PESPUNTE" Then
                    Lote.pmotivoDepartamento2 = CStr(row("motivoDepartamento" + Departamentos(1).PIDConfiguracion.ToString))
                    Lote.PDiasAtrasados2 = CStr(row("diasAtrasos" + Departamentos(1).PIDConfiguracion.ToString))
                End If
                If Departamentos(1).PNombre = "MONTADO Y ADORNO" Then
                    Lote.pmotivoDepartamento3 = CStr(row("motivoDepartamento" + Departamentos(1).PIDConfiguracion.ToString))
                    Lote.PDiasAtrasados3 = CStr(row("diasAtrasos" + Departamentos(1).PIDConfiguracion.ToString))
                End If
            Catch ex As Exception
                'MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK)
            End Try
            Try
                If Departamentos(2).PNombre = "CORTE" Then
                    Lote.pmotivoDepartamento1 = CStr(row("motivoDepartamento" + Departamentos(2).PIDConfiguracion.ToString))
                    Lote.PDiasAtrasados1 = CStr(row("diasAtrasos" + Departamentos(2).PIDConfiguracion.ToString))
                End If
                If Departamentos(2).PNombre = "PESPUNTE" Then
                    Lote.pmotivoDepartamento2 = CStr(row("motivoDepartamento" + Departamentos(2).PIDConfiguracion.ToString))
                    Lote.PDiasAtrasados2 = CStr(row("diasAtrasos" + Departamentos(2).PIDConfiguracion.ToString))
                End If
                If Departamentos(2).PNombre = "MONTADO Y ADORNO" Then
                    Lote.pmotivoDepartamento3 = CStr(row("motivoDepartamento" + Departamentos(2).PIDConfiguracion.ToString))
                    Lote.PDiasAtrasados3 = CStr(row("diasAtrasos" + Departamentos(2).PIDConfiguracion.ToString))
                End If
            Catch ex As Exception
                'MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK)
            End Try
            Try
                Lote.PPares = CInt(row("Pares"))
            Catch ex As Exception

            End Try

            Lote.PObservaciones = CStr(row("Observacion"))
            Try
                Lote.PFechaEmbarque = CDate(row("Fecha_Salida"))
            Catch ex As Exception

            End Try

            'Try
            '    Lote.PavanceDepartamento1 = CDate(row("avanceDepartamento1"))

            'Catch ex As Exception

            'End Try
            'Try
            '    Lote.PavanceDepartamento2 = CDate(row("avanceDepartamento2"))

            'Catch ex As Exception

            'End Try
            'Try

            '    Lote.PavanceDepartamento3 = CDate(row("avanceDepartamento3"))
            'Catch ex As Exception

            'End Try

            'codigo juana
            Dim listaFechasAvance As New List(Of DepartamentosProduccion)
            For Each dep As DepartamentosProduccion In Departamentos
                Dim departamento As New DepartamentosProduccion
                departamento.PDias = dep.PDias
                departamento.PIDConfiguracion = dep.PIDConfiguracion
                departamento.PNombre = dep.PNombre
                Dim nombreCol As String = "avanceDepartamento" + dep.PIDConfiguracion.ToString
                Dim nombreCelula As String = "Celula" + dep.PIDConfiguracion.ToString
                Dim fechaAvance As New DateTime
                Try
                    fechaAvance = CDate(row(nombreCol))
                    departamento.PFechaAvance = fechaAvance
                Catch ex As Exception
                    departamento.PFechaAvance = Nothing
                End Try
                Try
                    departamento.PCelulas = CStr(row(nombreCelula))

                Catch ex As Exception
                    departamento.PCelulas = Nothing

                End Try

                listaFechasAvance.Add(departamento)
                'Try
                '    departamento.PCelulas = CStr(row(nombreCelula))
                '    listaFechasAvance.Add(departamento)
                'Catch ex As Exception
                '    departamento.PCelulas = Nothing
                '    listaFechasAvance.Add(departamento)
                'End Try
            Next
            Lote.PAvanceDepartamentos = listaFechasAvance

            ListaAvancesProduccionDetallado.Add(Lote)
        Next
        Return ListaAvancesProduccionDetallado
    End Function

    Public Function ListaAvancesProduccionAvances(ByVal FechaInicio As Date, ByVal FechaFin As Date, ByVal Naveid As Int32, ByVal Departamentos As List(Of DepartamentosProduccion), ByVal DepartamentoAnterior As Int32, ByVal Orden As Int32) As List(Of LotesAvances)
        Dim objDa As New Datos.LotesAvancesDA
        Dim tablaAvances As DataTable
        ListaAvancesProduccionAvances = New List(Of LotesAvances)
        tablaAvances = objDa.ListaAvancesProduccionAvances(FechaInicio, FechaFin, Naveid, Departamentos, DepartamentoAnterior, Orden)
        For Each row As DataRow In tablaAvances.Rows
            Dim Lote As New LotesAvances
            Lote.PFechaLote = CDate(row("Fecha"))
            Lote.PLote = CInt(row("Lote"))
            Lote.PModelo = CStr(row("IdModelo"))
            Lote.PColeccion = CStr(row("Coleccion"))
            Lote.PTalla = CStr(row("Talla"))
            Lote.PColor = CStr(row("Color"))
            Try
                Lote.PPares = CInt(row("Pares"))
            Catch ex As Exception

            End Try

            Lote.PObservaciones = CStr(row("Observacion"))
            Try
                Lote.PFechaEmbarque = CDate(row("Fecha_Salida"))
            Catch ex As Exception

            End Try

            'Try
            '    Lote.PavanceDepartamento1 = CDate(row("avanceDepartamento1"))

            'Catch ex As Exception

            'End Try
            'Try
            '    Lote.PavanceDepartamento2 = CDate(row("avanceDepartamento2"))

            'Catch ex As Exception

            'End Try
            'Try

            '    Lote.PavanceDepartamento3 = CDate(row("avanceDepartamento3"))
            'Catch ex As Exception

            'End Try

            'codigo juana
            Dim listaFechasAvance As New List(Of DepartamentosProduccion)
            For Each dep As DepartamentosProduccion In Departamentos
                Dim departamento As New DepartamentosProduccion
                departamento.PDias = dep.PDias
                departamento.PIDConfiguracion = dep.PIDConfiguracion
                departamento.PNombre = dep.PNombre
                Dim nombreCol As String = "avanceDepartamento" + dep.PIDConfiguracion.ToString
                Dim nombreCelula As String = "Celula" + dep.PIDConfiguracion.ToString
                Dim fechaAvance As New DateTime
                Try
                    fechaAvance = CDate(row(nombreCol))
                    departamento.PFechaAvance = fechaAvance
                Catch ex As Exception
                    departamento.PFechaAvance = Nothing
                End Try
                Try
                    departamento.PCelulas = CStr(row(nombreCelula))

                Catch ex As Exception
                    departamento.PCelulas = Nothing

                End Try

                listaFechasAvance.Add(departamento)
                'Try
                '    departamento.PCelulas = CStr(row(nombreCelula))
                '    listaFechasAvance.Add(departamento)
                'Catch ex As Exception
                '    departamento.PCelulas = Nothing
                '    listaFechasAvance.Add(departamento)
                'End Try
            Next
            Lote.PAvanceDepartamentos = listaFechasAvance

            ListaAvancesProduccionAvances.Add(Lote)
        Next
        Return ListaAvancesProduccionAvances
    End Function







    Public Function VerificarAvancesProduccion(ByVal FechaInicio As Date, ByVal FechaFin As Date, ByVal Naveid As Int32, ByVal Departamentos As List(Of DepartamentosProduccion)) As List(Of LotesAvances)
        Dim objDa As New Datos.LotesAvancesDA
        Dim tablaAvances As DataTable
        VerificarAvancesProduccion = New List(Of LotesAvances)
        tablaAvances = objDa.VerificarAvancesProduccion(FechaInicio, FechaFin, Naveid, Departamentos)
        For Each row As DataRow In tablaAvances.Rows
            Dim Lote As New LotesAvances
            Lote.PFechaLote = CDate(row("Fecha"))
            Lote.PLote = CInt(row("Lote"))
            Lote.PMarca = CStr(row("Marca"))
            Lote.PModelo = CStr(row("IdModelo"))
            Lote.PColeccion = CStr(row("Coleccion"))
            Lote.PTalla = CStr(row("Talla"))
            Lote.PColor = CStr(row("Color"))
            Lote.PPares = CInt(row("Pares"))
            Lote.PObservaciones = CStr(row("Observacion"))
            Try
                Lote.PFechaEmbarque = CDate(row("Fecha_Salida"))
            Catch ex As Exception

            End Try

            'Try
            '    Lote.PavanceDepartamento1 = CDate(row("avanceDepartamento1"))

            'Catch ex As Exception

            'End Try
            'Try
            '    Lote.PavanceDepartamento2 = CDate(row("avanceDepartamento2"))

            'Catch ex As Exception

            'End Try
            'Try

            '    Lote.PavanceDepartamento3 = CDate(row("avanceDepartamento3"))
            'Catch ex As Exception

            'End Try

            'codigo juana
            Dim listaFechasAvance As New List(Of DepartamentosProduccion)
            For Each dep As DepartamentosProduccion In Departamentos
                Dim departamento As New DepartamentosProduccion
                departamento.PDias = dep.PDias
                departamento.PIDConfiguracion = dep.PIDConfiguracion
                departamento.PNombre = dep.PNombre
                Dim nombreCol As String = "avanceDepartamento" + dep.PIDConfiguracion.ToString
                Dim nombreCelula As String = "Celula" + dep.PIDConfiguracion.ToString
                Dim fechaAvance As New DateTime
                Try
                    fechaAvance = CDate(row(nombreCol))
                    departamento.PFechaAvance = fechaAvance
                Catch ex As Exception
                    departamento.PFechaAvance = Nothing
                End Try
                Try
                    departamento.PCelulas = CStr(row(nombreCelula))

                Catch ex As Exception
                    departamento.PCelulas = Nothing

                End Try

                listaFechasAvance.Add(departamento)
                'Try
                '    departamento.PCelulas = CStr(row(nombreCelula))
                '    listaFechasAvance.Add(departamento)
                'Catch ex As Exception
                '    departamento.PCelulas = Nothing
                '    listaFechasAvance.Add(departamento)
                'End Try
            Next
            Lote.PAvanceDepartamentos = listaFechasAvance


            VerificarAvancesProduccion.Add(Lote)
        Next
        Return VerificarAvancesProduccion
    End Function


    Public Function VerificarAvancesProduccionembarque(ByVal FechaInicio As Date, ByVal FechaFin As Date, ByVal Naveid As Int32, ByVal Departamentos As List(Of DepartamentosProduccion)) As List(Of LotesAvances)
        Dim objDa As New Datos.LotesAvancesDA
        Dim tablaAvances As DataTable
        VerificarAvancesProduccionembarque = New List(Of LotesAvances)
        tablaAvances = objDa.VerificarAvancesProduccionembarque(FechaInicio, FechaFin, Naveid, Departamentos)
        For Each row As DataRow In tablaAvances.Rows
            Dim Lote As New LotesAvances
            Lote.PFechaLote = CDate(row("Fecha"))
            Lote.PLote = CInt(row("Lote"))
            Lote.PMarca = CStr(row("Marca"))
            Lote.PModelo = CStr(row("IdModelo"))
            Lote.PColeccion = CStr(row("Coleccion"))
            Lote.PTalla = CStr(row("Talla"))
            Lote.PColor = CStr(row("Color"))
            Lote.PPares = CInt(row("Pares"))
            Lote.PObservaciones = CStr(row("Observacion"))
            Try
                Lote.PFechaEmbarque = CDate(row("Fecha_Salida"))
            Catch ex As Exception

            End Try

            'Try
            '    Lote.PavanceDepartamento1 = CDate(row("avanceDepartamento1"))

            'Catch ex As Exception

            'End Try
            'Try
            '    Lote.PavanceDepartamento2 = CDate(row("avanceDepartamento2"))

            'Catch ex As Exception

            'End Try
            'Try

            '    Lote.PavanceDepartamento3 = CDate(row("avanceDepartamento3"))
            'Catch ex As Exception

            'End Try

            'codigo juana
            Dim listaFechasAvance As New List(Of DepartamentosProduccion)
            For Each dep As DepartamentosProduccion In Departamentos
                Dim departamento As New DepartamentosProduccion
                departamento.PDias = dep.PDias
                departamento.PIDConfiguracion = dep.PIDConfiguracion
                departamento.PNombre = dep.PNombre
                Dim nombreCol As String = "avanceDepartamento" + dep.PIDConfiguracion.ToString
                Dim nombreCelula As String = "Celula" + dep.PIDConfiguracion.ToString
                Dim fechaAvance As New DateTime
                Try
                    fechaAvance = CDate(row(nombreCol))
                    departamento.PFechaAvance = fechaAvance
                Catch ex As Exception
                    departamento.PFechaAvance = Nothing
                End Try
                Try
                    departamento.PCelulas = CStr(row(nombreCelula))

                Catch ex As Exception
                    departamento.PCelulas = Nothing

                End Try

                listaFechasAvance.Add(departamento)
                'Try
                '    departamento.PCelulas = CStr(row(nombreCelula))
                '    listaFechasAvance.Add(departamento)
                'Catch ex As Exception
                '    departamento.PCelulas = Nothing
                '    listaFechasAvance.Add(departamento)
                'End Try
            Next
            Lote.PAvanceDepartamentos = listaFechasAvance


            VerificarAvancesProduccionembarque.Add(Lote)
        Next
        Return VerificarAvancesProduccionembarque
    End Function






    Public Sub GuardarObsLote(ByVal Lote As Lote)
        Dim objLoteAvance As New LotesAvancesDA
        objLoteAvance.GuardarObsLoteAvence(Lote)
    End Sub

    Public Function MostrarInfoLote(ByVal vAño As Int32, ByVal vNave As Int32, ByVal vLote As Int32) As List(Of Lote)
        Dim objDA As New Datos.LotesAvancesDA
        Dim tabla As New DataTable

        MostrarInfoLote = New List(Of Lote)
        tabla = objDA.OtenerInfoLote(vAño, vNave, vLote)

        For Each fila As DataRow In tabla.Rows
            Dim LoteInfo As New Lote

            LoteInfo.PLoteNumero = CInt(fila("Lote"))
            LoteInfo.PLoteFecha = CDate(fila("Fecha"))
            LoteInfo.PLoteModelo = CStr(fila("Descripcion"))
            LoteInfo.PLoteDepartamentoAvance = CStr(fila("Departamento"))
            LoteInfo.PLoteFechaAvance = CDate(fila("FechaAvance"))
            LoteInfo.PLoteUsuarioAvance = CStr(fila("Empleado"))
            LoteInfo.PLoteTalla = CStr(fila("Talla"))
            LoteInfo.PLoteFechaEmbarque = CDate(fila("FechaEmbarque"))

            MostrarInfoLote.Add(LoteInfo)
        Next

    End Function


    Public Function InventarioLotesAvances(ByVal vNave As Int32,
                                    ByVal idDepartamento As Int32,
                                    ByVal vFechaLoteIni As Date,
                                    ByVal vFechaLoteFin As Date
                                    ) As List(Of InventarioProduccion)

        Dim objDA As New Datos.LotesAvancesDA
        Dim tabla As New DataTable
        InventarioLotesAvances = New List(Of InventarioProduccion)
        tabla = objDA.InventarioLotesAvances(vNave, idDepartamento, vFechaLoteIni, vFechaLoteFin)
        For Each fila As DataRow In tabla.Rows
            Dim LoteAvance As New InventarioProduccion

            LoteAvance.PFecha = CDate(fila("Fecha"))
            Try
                LoteAvance.PLotesTerminados = CInt(fila("lotes_terminados"))
            Catch ex As Exception
                LoteAvance.PLotesTerminados = 0
            End Try

            Try
                LoteAvance.PParesTerminados = CInt(fila("pares_terminados"))
            Catch ex As Exception
                LoteAvance.PParesTerminados = 0
            End Try
            Try

                LoteAvance.PParesProg = CInt(fila("pares_programados"))

            Catch ex As Exception
                LoteAvance.PParesProg = 0
            End Try
            Try
                LoteAvance.PLotesProg = CInt(fila("lotes_programados"))
            Catch ex As Exception
                LoteAvance.PLotesProg = 0
            End Try


            InventarioLotesAvances.Add(LoteAvance)
        Next
    End Function



    Public Function InventarioLotesAvancesV2(ByVal vNave As Int32,
                                    ByVal idDepartamento As Int32,
                                    ByVal vFechaLoteIni As Date,
                                    ByVal vFechaLoteFin As Date, ByVal DepartamentoAnterior As Int32, ByVal Orden As Int32
                                    ) As List(Of InventarioProduccion)



        Dim objDA As New Datos.LotesAvancesDA
        Dim tabla As New DataTable
        InventarioLotesAvancesV2 = New List(Of InventarioProduccion)
        'Tomaba una fecha posterior y no cuadraba el inventario
        'If Orden = 1 Then
        '    If vFechaLoteFin.DayOfWeek = 6 Then
        '        vFechaLoteFin.AddDays(2)
        '    Else
        '        vFechaLoteFin = vFechaLoteFin.AddDays(1)
        '    End If
        'End If
        If DepartamentoAnterior > 0 Then
            If Orden = 3 Then
                tabla = objDA.InventarioLotesAvancesMontado(vNave, idDepartamento, vFechaLoteIni, vFechaLoteFin, DepartamentoAnterior)

            Else
                If Orden = 1 Then
                    tabla = objDA.InventarioLotesAvances(vNave, idDepartamento, vFechaLoteIni, vFechaLoteFin)
                Else
                    tabla = objDA.InventarioLotesAvancesV2(vNave, idDepartamento, vFechaLoteIni, vFechaLoteFin, DepartamentoAnterior)

                End If

            End If
        Else
            tabla = objDA.InventarioLotesAvances(vNave, idDepartamento, vFechaLoteIni, vFechaLoteFin)
        End If

        For Each fila As DataRow In tabla.Rows
            Dim LoteAvance As New InventarioProduccion

            LoteAvance.PFecha = CDate(fila("Fecha"))
            Try
                LoteAvance.PLotesTerminados = CInt(fila("lotes_terminados"))
            Catch ex As Exception
                LoteAvance.PLotesTerminados = 0
            End Try

            Try
                LoteAvance.PParesTerminados = CInt(fila("pares_terminados"))
            Catch ex As Exception
                LoteAvance.PParesTerminados = 0
            End Try
            Try

                LoteAvance.PParesProg = CInt(fila("pares_programados"))

            Catch ex As Exception
                LoteAvance.PParesProg = 0
            End Try
            Try
                LoteAvance.PLotesProg = CInt(fila("lotes_programados"))
            Catch ex As Exception
                LoteAvance.PLotesProg = 0
            End Try


            InventarioLotesAvancesV2.Add(LoteAvance)
        Next
    End Function


    'Desde aquí

    Public Function InventarioLotesAvancesPorDepartamentos(ByVal vNave As Int32,
                                    ByVal vFechaLoteIni As Date,
                                    ByVal vFechaLoteFin As Date, ByVal Orden As Int32, ByVal idDepartamento As Int32
                                    ) As List(Of InventarioProduccion)

        Dim objDA As New Datos.LotesAvancesDA
        Dim tabla As New DataTable
        InventarioLotesAvancesPorDepartamentos = New List(Of InventarioProduccion)
        'Esto aplica para corte
        If Orden = 1 Then
            If vFechaLoteFin.DayOfWeek = 6 Then
                vFechaLoteFin.AddDays(2)
            Else
                vFechaLoteFin = vFechaLoteFin.AddDays(1)
            End If
        End If
        'Falta por revisar
        tabla = objDA.InventarioDepartamentos_NavesProd(vNave, vFechaLoteIni, vFechaLoteFin, Orden, idDepartamento)

            For Each fila As DataRow In tabla.Rows
            Dim LoteAvance As New InventarioProduccion

            LoteAvance.PFecha = CDate(fila("Fecha"))
            Try
                LoteAvance.PLotesTerminados = CInt(fila("lotes_terminados"))
            Catch ex As Exception
                LoteAvance.PLotesTerminados = 0
            End Try

            Try
                LoteAvance.PParesTerminados = CInt(fila("pares_terminados"))
            Catch ex As Exception
                LoteAvance.PParesTerminados = 0
            End Try
            Try

                LoteAvance.PParesProg = CInt(fila("pares_programados"))

            Catch ex As Exception
                LoteAvance.PParesProg = 0
            End Try
            Try
                LoteAvance.PLotesProg = CInt(fila("lotes_programados"))
            Catch ex As Exception
                LoteAvance.PLotesProg = 0
            End Try


            InventarioLotesAvancesPorDepartamentos.Add(LoteAvance)
        Next
    End Function

    'Hasta aquí




    Public Function InventarioNaves(ByVal vNave As Int32,
                                    ByVal vFechaLoteIni As DateTime,
                                    ByVal vFechaLoteFin As DateTime
                                    ) As List(Of InventarioProduccion)

        Dim objDA As New Datos.LotesAvancesDA
        Dim tabla As New DataTable
        InventarioNaves = New List(Of InventarioProduccion)
        tabla = objDA.InventarioNavesV2(vNave, vFechaLoteIni, vFechaLoteFin)
        For Each fila As DataRow In tabla.Rows
            Dim LoteAvance As New InventarioProduccion

            LoteAvance.PFecha = CDate(fila("Fecha"))



            Try
                LoteAvance.PLotesTerminados = CInt(fila("lotesProceso"))
            Catch ex As Exception
                LoteAvance.PLotesTerminados = 0
            End Try

            Try
                LoteAvance.PParesTerminados = CInt(fila("paresProceso"))
            Catch ex As Exception
                LoteAvance.PParesTerminados = 0
            End Try
            Try
                LoteAvance.PParesProg = CInt(fila("pares_programados"))
                LoteAvance.PLotesProg = CInt(fila("lotes_programados"))

            Catch ex As Exception

            End Try
            Try
                LoteAvance.PCantidadDiaslote = CDbl(fila("DiasLote"))
            Catch ex As Exception
                LoteAvance.PCantidadDiaslote = 0
            End Try


            InventarioNaves.Add(LoteAvance)
        Next
    End Function



    Public Function GenerarInventarioNave(ByVal idNave As Int32) As InventarioProduccion

        Dim ObjBu As New LotesAvancesBU
        Dim ListaInventario As New List(Of InventarioProduccion)

        Dim Departamentos As New List(Of DepartamentosProduccion)
        Dim ObjBUDEP As New DepartamentosSICYBU
        Dim totalParesProgramados, totalParesTerminados As Integer

        Dim PrimerFecha As Date
        PrimerFecha = Date.MinValue
        Dim ObjetoInventario As New InventarioProduccion

        'ListaInventario = ObjBu.InventarioLotesAvances(cmbNave.SelectedValue, cmbDepartamento.SelectedValue, fechaInicio, fechaFin)
        ListaInventario = ObjBu.InventarioNaves(idNave, Today, Today)
        Dim TotalLotesTerminados, TotalLotesProgramados As New Int32
        Dim DiasDividir As New Double
        Dim InsertoFechaInicial As Boolean = False
        Dim comenzarinsertar As Boolean = False


        For Each inventario As InventarioProduccion In ListaInventario
            Dim paresTerminados As Int32
            If PrimerFecha = Date.MinValue Then
                PrimerFecha = inventario.PFecha
            End If
            paresTerminados = inventario.PParesProg - inventario.PParesTerminados
            If inventario.PParesProg = paresTerminados Then
                comenzarinsertar = False
            Else
                comenzarinsertar = True
            End If
            If inventario.PParesProg = 0 Then
            Else
                If comenzarinsertar = True Then
                    Dim strFila As String = ""

                    paresTerminados = inventario.PParesProg - inventario.PParesTerminados
                    Dim LotesTerminados As Int32
                    LotesTerminados = inventario.PLotesProg - inventario.PLotesTerminados

                    'COMENTADO POR LUIS MARIO PARA OBTENER LOS DATOS DE DIAS DE MEDIO DIA LABORAL 14/05/2018

                    'If inventario.PLotesTerminados > 0 Then
                    '    If inventario.PFecha.DayOfWeek = 7 Then
                    '        DiasDividir += 0
                    '    End If
                    '    If inventario.PFecha.DayOfWeek = 6 Then
                    '        DiasDividir += 0.5
                    '    End If

                    '    If inventario.PFecha.DayOfWeek < 6 Then
                    '        DiasDividir += 1
                    '    End If
                    'End If

                    'AGREGADO POR LUIS MARIO PARA OBTENER LOS DATOS DE DIAS DE MEDIO DIA LABORAL 14/05/2018

                    DiasDividir += inventario.PCantidadDiaslote

                    TotalLotesProgramados += inventario.PLotesProg
                    TotalLotesTerminados += LotesTerminados
                    totalParesProgramados += inventario.PParesProg

                    totalParesTerminados = totalParesTerminados + paresTerminados
                End If
            End If
        Next

        '---------------------






        Dim paresProceso As Int32
        paresProceso = totalParesProgramados - totalParesTerminados


        Dim inventarioFinal As Double
        inventarioFinal = (paresProceso / (totalParesProgramados / DiasDividir))
        'txtDias.Text = DiasDividir.ToString
        ' lblInventarioNave.Text = FormatNumber(inventarioFinal.ToString, 2) + " Días"
        ObjetoInventario.PInventario = inventarioFinal
        ObjetoInventario.PProgramas = DiasDividir
        ObjetoInventario.PParesProceso = paresProceso
        ObjetoInventario.PParesTerminadosnave = totalParesTerminados
        ObjetoInventario.PFecha = PrimerFecha
        Return ObjetoInventario
    End Function




    Public Function GenerarInventarioDepartamento(ByVal idNave As Int32, ByVal idDepartamento As Int32, ByVal DepartamentoAnterior As Int32, ByVal Orden As Int32) As InventarioProduccion

        Dim ObjBu As New LotesAvancesBU
        Dim ListaInventario As New List(Of InventarioProduccion)
        Dim DiasDepartamento As Int32
        Dim Departamentos As New List(Of DepartamentosProduccion)
        Dim ObjBUDEP As New DepartamentosSICYBU
        Dim objDA As New Datos.LotesAvancesDA
        Dim resumenProgramados As New DataTable
        Dim totalParesProgramados, totalParesTerminados, totalParesProgramadosResumen As Integer
        Departamentos = (ObjBUDEP.ListaDepartamentosSegunNaveProduccion(idNave))
        If idDepartamento > 0 Then

            For Each dep As DepartamentosProduccion In Departamentos
                Dim Departamento As New DepartamentosProduccion
                Departamento = dep
                If Departamento.PIDConfiguracion = idDepartamento Then
                    DiasDepartamento = 6
                End If
            Next
        End If
        Dim fechaInicio As New Date
        fechaInicio = Today
        'Dim FechaFin As New Date
        'fechaInicio = dtpFechaInicio.Value.AddDays(DiasDepartamento * (-1))
        'DiasDepartamento = DiasDepartamento - 1
        DiasDepartamento = 6
        Dim contador As Integer = 0
        While contador < DiasDepartamento
            fechaInicio = fechaInicio.AddDays(-1)
            If fechaInicio.DayOfWeek = 6 Then
                fechaInicio = fechaInicio.AddDays(-1)
            End If
            contador += 1
        End While

        Dim fechaFin As New Date
        fechaFin = Today
        'Dim FechaFin As New Date
        'fechaInicio = dtpFechaInicio.Value.AddDays(DiasDepartamento * (-1))
        'Dim contadorfinal As Integer = 0
        'While contadorfinal < DiasDepartamento
        '    fechaFin = fechaFin.AddDays(-1)
        '    If fechaInicio.DayOfWeek = 6 Then
        '        fechaFin = fechaFin.AddDays(-1)
        '    End If
        '    contadorfinal += 1
        'End While

        If Orden = 1 Then
            If fechaFin.DayOfWeek = 6 Then
                fechaFin.AddDays(2)
            Else
                fechaFin = fechaFin.AddDays(1)
            End If
        End If




        'ListaInventario = ObjBu.InventarioLotesAvances(cmbNave.SelectedValue, cmbDepartamento.SelectedValue, fechaInicio, fechaFin)
        ListaInventario = ObjBu.InventarioLotesAvancesV2(idNave, idDepartamento, Today.ToShortDateString, Today.ToShortDateString, DepartamentoAnterior, Orden)
        resumenProgramados = objDA.InventarioDepartamentos_NavesProd(idNave, Today.ToShortDateString, fechaFin, Orden, idDepartamento)
        Dim TotalLotesTerminados, TotalLotesProgramados As New Int32
        Dim DiasDividir, DiasDividirCorte As New Double
        Dim Programas, ProgramasMontado As New Double
        Dim InsertoFechaInicial As Boolean = False
        Dim comenzarinsertar As Boolean = False
        Dim FechaInicial As Date
        FechaInicial = Date.MinValue


        For Each inventario As InventarioProduccion In ListaInventario
            If FechaInicial = Date.MinValue Then
                FechaInicial = inventario.PFecha
            End If
            'If inventario.PParesProg = inventario.PParesTerminados Then
            'Else
            comenzarinsertar = True
            'End If
            If inventario.PParesProg = 0 Then

            Else

                If comenzarinsertar = True Then
                    Dim strFila As String = ""
                    Dim TotalLotesResumen, TotalParesResumen As New Int32
                    Programas += 1
                    TotalLotesResumen = inventario.PLotesProg - inventario.PLotesTerminados
                    TotalParesResumen = inventario.PParesProg - inventario.PParesTerminados

                    'Aqui va la otra validacion de los pares terminados

                    If TotalLotesResumen > 0 And TotalParesResumen > 0 Then

                        If inventario.PFecha.DayOfWeek = 7 Then
                            DiasDividir += 0
                        End If
                        If inventario.PFecha.DayOfWeek = 6 Then
                            DiasDividir += 0.5
                        End If

                        If inventario.PFecha.DayOfWeek < 6 Then
                            DiasDividir += 1
                        End If
                        ProgramasMontado += 1
                    End If


                    ' grdInventarioDepartamento.AddItem(strFila)
                    TotalLotesProgramados += inventario.PLotesProg
                    TotalLotesTerminados += inventario.PLotesTerminados
                    totalParesProgramados += inventario.PParesProg
                    totalParesTerminados = totalParesTerminados + inventario.PParesTerminados
                End If

            End If

        Next

        '---------------------

        For Each fila As DataRow In resumenProgramados.Rows
            If (CInt(fila("pares_programados")) <> CInt(fila("pares_terminados"))) Then
                totalParesProgramadosResumen += CInt(fila("pares_programados"))
                If (Orden = 1) Then
                    DiasDividirCorte += 1
                End If
            End If
        Next


        ' grdInventarioDepartamento.AddItem(strFilas)
        Dim paresProceso As Int32
        paresProceso = totalParesProgramados - totalParesTerminados
        Dim inventarioFinal As Double
        If (Orden = 1) Then
            inventarioFinal = (paresProceso / (totalParesProgramadosResumen / DiasDividirCorte))
        Else
            inventarioFinal = (paresProceso / (totalParesProgramadosResumen / DiasDividir))
        End If

        If DiasDividir = 0.0 Then
            inventarioFinal = 0.0
        End If
        ' txtDias.Text = DiasDividir.ToString
        '  lblTotalInventario.Text = FormatNumber(inventarioFinal.ToString, 2) + " Días"
        Dim ObjetoInventario As New InventarioProduccion
        ObjetoInventario.PInventario = inventarioFinal
        If Orden = 3 Then
            ObjetoInventario.PProgramas = ProgramasMontado
        Else
            ObjetoInventario.PProgramas = Programas
        End If

        ObjetoInventario.PParesProceso = paresProceso
        ObjetoInventario.PParesTerminadosnave = totalParesTerminados
        ObjetoInventario.PPrimerFechaDepartamento = FechaInicial
        Return ObjetoInventario
    End Function



    Public Function DepartamentosAnteriores(ByVal idNave As Int32, ByVal idConfiguracion As Int32) As DepartamentosProduccion

        Dim objDA As New Datos.LotesAvancesDA
        Dim tabla As New DataTable

        DepartamentosAnteriores = New DepartamentosProduccion
        tabla = objDA.DepartamentosAnteriores(idNave, idConfiguracion)

        For Each fila As DataRow In tabla.Rows

            Try
                DepartamentosAnteriores.POrden = CInt(fila("Orden"))
            Catch ex As Exception

            End Try

            Try
                DepartamentosAnteriores.PDptoAnterior = CInt(fila("DptoAnterior"))
            Catch ex As Exception

            End Try

            Try
                DepartamentosAnteriores.PConfiguracionDptoAnterior = CStr(fila("idConfiguracionDptoAnterior"))
            Catch ex As Exception

            End Try

           


        Next



        Return DepartamentosAnteriores

    End Function

    Public Function getdiasAtrasosDepartamento(ByVal lote As Integer, ByVal idNave As Integer, ByVal año As Integer, ByVal departamento As String) As DataTable

        Dim objDA As New Datos.LotesAvancesDA
        Dim tabla As New DataTable
        tabla = objDA.getdiasAtrasosDepartamento(lote, idNave, año, departamento)
        Return tabla
    End Function

    Public Function RegistrosReporte(ByVal FechaInicial As DateTime, ByVal FechaFinal As Date, ByVal Naveid As Integer, ByVal Departamentoid As Integer)
        Dim objDA As New Datos.LotesAvancesDA
        Dim tabla As New DataTable
        tabla = objDA.RegistrosReporte(FechaInicial, FechaFinal, Naveid, Departamentoid)
        Return tabla
    End Function
    Public Function RegistrosResumen(ByVal FechaInicial As DateTime, ByVal FechaFinal As Date, ByVal Naveid As Integer, ByVal Departamentoid As Integer)
        Dim objDA As New Datos.LotesAvancesDA
        Dim tabla As New DataTable
        tabla = objDA.RegistrosResumen(FechaInicial, FechaFinal, Naveid, Departamentoid)
        Return tabla
    End Function
    Public Function RegistrosCelulaNave(ByVal nombreDepartamento As String, ByVal naveId As Integer)
        Dim objDA As New Datos.LotesAvancesDA
        Dim tabla As New DataTable
        tabla = objDA.RegistrosCelulaNave(nombreDepartamento, naveId)
        Return tabla
    End Function

    Public Function RegistrosReporteCelula(ByVal FechaInicial As DateTime, ByVal FechaFinal As Date, ByVal Naveid As Integer, ByVal Departamentoid As Integer, ByVal celula As String)
        Dim objDA As New Datos.LotesAvancesDA
        Dim tabla As New DataTable
        tabla = objDA.RegistrosReporteCelula(FechaInicial, FechaFinal, Naveid, Departamentoid, celula)
        Return tabla
    End Function

    Public Function RegistrosResumenCelula(ByVal FechaInicial As DateTime, ByVal FechaFinal As Date, ByVal Naveid As Integer, ByVal Departamentoid As Integer, ByVal celula As String)
        Dim objDA As New Datos.LotesAvancesDA
        Dim tabla As New DataTable
        tabla = objDA.RegistrosResumenCelula(FechaInicial, FechaFinal, Naveid, Departamentoid, celula)
        Return tabla
    End Function

    Public Function RegistrosProduccionDeAvancesMA(ByVal Naveid As Integer, ByVal FechaInicial As DateTime, ByVal FechaFinal As Date)
        Dim objDA As New Datos.LotesAvancesDA
        Dim tabla As New DataTable
        tabla = objDA.RegistrosProduccionDeAvancesMA(Naveid, FechaInicial, FechaFinal)
        Return tabla
    End Function
    Public Function RegistrosResumenProduccionDeAvancesMA(ByVal Naveid As Integer, ByVal FechaInicial As DateTime, ByVal FechaFinal As Date)
        Dim objDA As New Datos.LotesAvancesDA
        Dim tabla As New DataTable
        tabla = objDA.RegistrosResumenProduccionDeAvancesMA(Naveid, FechaInicial, FechaFinal)
        Return tabla
    End Function
    Public Function RegistrosProduccionDeAvancesPT(ByVal Naveid As Integer, ByVal FechaInicial As DateTime, ByVal FechaFinal As Date)
        Dim objDA As New Datos.LotesAvancesDA
        Dim tabla As New DataTable
        tabla = objDA.RegistrosProduccionDeAvancesPT(Naveid, FechaInicial, FechaFinal)
        Return tabla
    End Function
    Public Function RegistrosResumenProduccionDeAvancesPT(ByVal Naveid As Integer, ByVal FechaInicial As DateTime, ByVal FechaFinal As Date, ByVal tipoReporte As Integer)
        Dim objDA As New Datos.LotesAvancesDA
        Dim tabla As New DataTable
        tabla = objDA.RegistrosResumenProduccionDeAvancesPT(Naveid, FechaInicial, FechaFinal, tipoReporte)
        Return tabla
    End Function

End Class
