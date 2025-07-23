Public Class CargaSimulacionBU
    Dim objDA As Programacion.Datos.CargaSimulacionDA
    Dim tablaNaves As DataTable
    Dim tablaHorma As DataTable
    Dim tablaColeccion As DataTable
    Dim tablaTalla As DataTable
    Dim tablaSuela As DataTable
    Dim tablaLayout As DataTable
    Public Sub New()
        Dim objDa As New Programacion.Datos.CargaSimulacionDA
        tablaNaves = objDa.CargaSimulacionValidaNave()
        tablaHorma = objDa.CargaSimulacionValidaHorma()
        tablaColeccion = objDa.CargaSimulacionValidaColeccion()
        tablaTalla = objDa.CargaSimulacionValidaTalla()
        tablaSuela = objDa.CargaSimulacionValidaSuela()

    End Sub
#Region "Validaciones Catalogos"

#End Region
    ''' <summary>
    ''' Retorna el catalogo de bases que se pueden cargar en el sistema
    ''' </summary>
    ''' <returns>DataTable con catalogo de bases</returns>
    ''' <remarks></remarks>
    Public Function CargaCatalogoBases() As DataTable
        Dim objDA As New Programacion.Datos.CargaSimulacionDA
        Return objDA.CargaCatalogoBaseSimulacion
    End Function
    Public Function CargaSimulacionValidaLayout(ByVal archivo As DataTable, ByVal opcion As Integer) As String
        Dim objDA As New Programacion.Datos.CargaSimulacionDA
        Dim respuesta As String = ""
        tablaLayout = objDA.CargaSimulacionValidaLayout(opcion)
        For Each row As DataRow In tablaLayout.Rows
            If Not archivo.Columns.Contains(row("Campo").ToString()) Then
                respuesta = respuesta & "Layout incorrecto: El archivo no contienen la columna " & row("Campo").ToString & vbNewLine
            End If
        Next
        If respuesta <> "" Then
            Return respuesta
        End If
        Dim tipoDato As Decimal
        Dim rows() As DataRow = tablaLayout.Select("Tipo='Decimal'")
        For Each rowTipo As DataRow In archivo.Rows
            For Each rowTD As DataRow In rows
                Try
                    tipoDato = Decimal.Parse(rowTipo(rowTD("Campo").ToString()).ToString())
                Catch ex As Exception
                    respuesta = respuesta & "Layout incorrecto: La columna  " & rowTD("Campo").ToString & " debe tener un valor numerico" & vbNewLine
                End Try

            Next
        Next
        Return respuesta
    End Function
    Public Function ConsultarInformacionPeriodo(ByVal fechaInici As DateTime, ByVal fechaFin As DateTime) As DataTable
        Dim objDA As New Programacion.Datos.CargaSimulacionDA
        Return objDA.ConsultarCargaSimulacion(fechaInici, fechaFin)
    End Function

    Public Function InsertarHomaNaveTallaBase(ByVal dtBase As DataTable, ByVal Catalogo As String, ByVal fechaIni As DateTime, ByVal fechaFin As DateTime) As String
        Dim objDa As New Programacion.Datos.CargaSimulacionDA
        Dim insercionCorrecta As Boolean
        Dim resultadoCargaArchivo As String = ""
        Dim dtSimulacion As DataTable = Nothing
        For Each rowbase As DataRow In dtBase.Rows

            insercionCorrecta = objDa.InsertarHomaNaveTallaBase(rowbase("Nave"), rowbase("NaveDesarrolla"), rowbase("Horma"), rowbase("Coleccion"), rowbase("Corrida"), rowbase("Talla"), rowbase("Pares"))
            If insercionCorrecta = False Then
                resultadoCargaArchivo = resultadoCargaArchivo & vbNewLine & "El Registro Nave= " & rowbase("Nave").ToString() & " NaveDesarrolla=" & rowbase("NaveDesarrolla").ToString() & " Horma= " & rowbase("Horma").ToString() & " Colección= " & rowbase("Coleccion").ToString() & " Corrida=" & rowbase("Corrida").ToString() & " Talla=" & rowbase("Talla").ToString() & " Pares=" & rowbase("Pares").ToString()
            End If

        Next


        Return resultadoCargaArchivo
    End Function

    Public Function InsertarBaseSimulacion(ByVal fechaInicio As DateTime, ByVal fechaFin As DateTime) As DataTable
        Dim objDA As New Programacion.Datos.CargaSimulacionDA
        Return objDA.InsertarCargaSimulacion(fechaInicio, fechaFin)
        objDA = Nothing
    End Function

#Region "Nave-Corrida-Coleccion"
    Public Function ValidarArchivo(ByVal tabla As DataTable) As String
        'validar duplicados
        '----------------------------------------------------------------------------
        Dim cadenaErrores As String = ""
        Dim cadenaDatos As String = ""
        Dim contador As Integer = 1
        For Each row As DataRow In tabla.Rows
            If ValidarDuplicados(row, tabla) Then
                cadenaErrores = cadenaErrores & "Error (Valor duplicado): La fila " & contador.ToString() & " ya se encuentra en el archivo." & vbNewLine
            End If

            'Valida informacion de cada registro
            '----------------------------------------------------
            cadenaDatos = ValidarDatos(row, tabla, contador)
            If cadenaDatos <> "" Then
                cadenaErrores = cadenaErrores & cadenaDatos
            End If
            contador = contador + 1
        Next
        'Validar Catalogos
        Return cadenaErrores
        '----------------------------------------------------------------------------

    End Function

    Public Function ValidarDuplicados(ByVal fila As DataRow, ByVal tabla As DataTable) As Boolean
        Dim resultado As Boolean
        Dim contadorRegistro As Integer = 0
        Dim filtro As String
        If fila("Nave") IsNot DBNull.Value And fila("NaveDesarrolla") IsNot DBNull.Value And fila("Horma") IsNot DBNull.Value And fila("Coleccion") IsNot DBNull.Value And fila("Corrida") IsNot DBNull.Value And fila("Talla") IsNot DBNull.Value And fila("Pares") IsNot DBNull.Value Then
            filtro = "Nave = '" & fila("Nave").ToString() & "' AND NaveDesarrolla ='" & fila("NaveDesarrolla").ToString() & "' AND Horma = '" & fila("Horma").ToString() & "' AND Coleccion = '" & fila("Coleccion").ToString() & "' AND Corrida = '" & fila("Corrida").ToString() & "' AND Talla = " & fila("Talla").ToString() & " AND Pares = " & fila("Pares").ToString()
            contadorRegistro = Integer.Parse(tabla.Compute("COUNT(Nave)", filtro))
        End If
        If contadorRegistro > 1 Then
            resultado = True
        Else
            resultado = False
        End If
        Return resultado
    End Function

    Public Function ValidarDatos(ByVal fila As DataRow, ByVal tablas As DataTable, ByVal contador As Integer) As String
        Dim resultado As String = ""
        For Each columnas As DataColumn In tablas.Columns
            Select Case columnas.ColumnName
                Case "Nave"
                    If fila("Nave").ToString().Trim = "" Or fila("Nave") Is DBNull.Value Then
                        resultado = resultado & "Error (Datos incorrectos), fila " & contador.ToString() & ". La Nave debe tener un valor" & vbNewLine
                    End If
                    If (tablaNaves.Compute("Count(Nave)", "Nave = '" & fila("Nave").ToString() & "'")) = 0 Then
                        resultado = resultado & "Error (Datos incorrectos), fila " & contador.ToString() & ". La Nave (" & fila("Nave").ToString() & ") no contiene un valor valido" & vbNewLine
                    End If
                Case "NaveDesarrolla"
                    If fila("NaveDesarrolla").ToString().Trim = "" Or fila("NaveDesarrolla") Is DBNull.Value Then
                        resultado = resultado & "Error (Datos incorrectos), fila " & contador.ToString() & ". La Nave que desarrolla debe tener un valor" & vbNewLine
                    End If
                    If (tablaNaves.Compute("Count(Nave)", "Nave = '" & fila("NaveDesarrolla").ToString() & "'")) = 0 Then
                        resultado = resultado & "Error (Datos incorrectos), fila " & contador.ToString() & ". La Nave a desarrollar (" & fila("NaveDesarrolla").ToString() & ") no contiene un valor valido" & vbNewLine
                    End If
                Case "Horma"
                    If fila("Horma").ToString().Trim = "" Or fila("Horma") Is DBNull.Value Then
                        resultado = resultado & "Error (Datos incorrectos), fila " & contador.ToString() & ". La Horma debe tener un valor" & vbNewLine
                    End If
                    If (tablaHorma.Compute("Count(Horma)", "Horma = '" & fila("Horma").ToString() & "'")) = 0 Then
                        resultado = resultado & "Error (Datos incorrectos), fila " & contador.ToString() & ". La Horma (" & fila("Horma").ToString() & ") no contiene un valor valido" & vbNewLine
                    End If
                Case "Coleccion"
                    If fila("Coleccion").ToString().Trim = "" Or fila("Coleccion") Is DBNull.Value Then
                        resultado = resultado & "Error (Datos incorrectos), fila " & contador.ToString() & ". La Coleccion debe tener un valor" & vbNewLine
                    End If
                    If (tablaColeccion.Compute("Count(Coleccion)", "Coleccion = '" & fila("Coleccion").ToString() & "'")) = 0 Then
                        resultado = resultado & "Error (Datos incorrectos), fila " & contador.ToString() & ". La Coleccion (" & fila("Coleccion").ToString() & ") no contiene un valor valido" & vbNewLine
                    End If
                Case "Corrida"
                    If fila("Corrida").ToString().Trim = "" Or fila("Corrida") Is DBNull.Value Then
                        resultado = resultado & "Error (Datos incorrectos), fila " & contador.ToString() & ". La Corrida debe tener un valor" & vbNewLine
                    End If
                    'If (tablas.Compute("Count(Corrida)", "Corrida = '" & fila("Corrida").ToString() & "'")) = 0 Then
                    '    resultado = resultado & "Error (Datos incorrectos), fila " & contador.ToString() & ".La Corrida (" & fila("Corrida").ToString() & ") no contiene un valor valido" & vbNarrow
                    'End If
                Case "Talla"
                    If fila("Talla").ToString().Trim = "" Or fila("Talla") Is DBNull.Value Then
                        resultado = resultado & "Error (Datos incorrectos), fila " & contador.ToString() & ". La Talla debe tener un valor" & vbNewLine
                    End If
                    'Try
                    '    Integer.Parse(fila("Talla"))
                    'Catch ex As Exception
                    '    resultado = resultado & "Error (Datos incorrectos), fila " & contador.ToString() & ". La Talla debe ser un valor numerico" & vbNewLine
                    'End Try
                    If (tablaTalla.Compute("Count(Talla)", "Talla = '" & fila("Talla").ToString() & "'")) = 0 Then
                        resultado = resultado & "Error (Datos incorrectos), fila " & contador.ToString() & ".La Talla (" & fila("Talla").ToString() & ") no contiene un valor valido" & vbNewLine
                    End If
                Case "Pares"
                    If fila("Pares").ToString().Trim = "" Or fila("Pares") Is DBNull.Value Then
                        resultado = resultado & "Error (Datos incorrectos), fila " & contador.ToString() & ". Los Pares debe tener un valor" & vbNewLine
                    End If
                    Try
                        Integer.Parse(fila("Pares"))
                    Catch ex As Exception
                        resultado = resultado & "Error (Datos incorrectos), fila " & contador.ToString() & ". Los Pares debe ser un valor numerico" & vbNewLine
                    End Try
            End Select
        Next
        Return resultado
    End Function
#End Region
#Region "Suela-Talla"
    ''' <summary>
    ''' Validar duplicados del layout de suela-corrida-coleccion
    ''' </summary>
    ''' <param name="fila"></param>
    ''' <param name="tabla"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ValidarDuplicadosSuela(ByVal fila As DataRow, ByVal tabla As DataTable) As Boolean
        Dim resultado As Boolean
        Dim contadorRegistro As Integer = 0
        Dim filtro As String
        If fila("Suela") IsNot DBNull.Value And fila("Coleccion") IsNot DBNull.Value And fila("Corrida") IsNot DBNull.Value And fila("Talla") IsNot DBNull.Value And fila("Pares") IsNot DBNull.Value Then
            filtro = "Suela = '" & fila("Suela").ToString() & "' AND Coleccion ='" & fila("Coleccion").ToString() & "' AND Corrida = '" & fila("Corrida").ToString() & "' AND Talla = '" & fila("Talla").ToString() & "' AND Pares = '" & fila("Pares").ToString() & "'"
            contadorRegistro = Integer.Parse(tabla.Compute("COUNT(Suela)", filtro))
        End If
        If contadorRegistro > 1 Then
            resultado = True
        Else
            resultado = False
        End If
        Return resultado
    End Function
    ''' <summary>
    ''' Valida archivo para layout Suela-Talla
    ''' </summary>
    ''' <param name="tabla"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>

    Public Function ValidarArchivoSuelaTalla(ByVal tabla As DataTable) As String
        'validar duplicados
        '----------------------------------------------------------------------------
        Dim cadenaErrores As String = ""
        Dim cadenaDatos As String = ""
        Dim contador As Integer = 1
        For Each row As DataRow In tabla.Rows
            If ValidarDuplicadosSuela(row, tabla) Then
                cadenaErrores = cadenaErrores & "Error (Valor duplicado): La fila " & contador.ToString() & " ya se encuentra en el archivo." & vbNewLine
            End If

            'Valida informacion de cada registro
            '----------------------------------------------------
            cadenaDatos = ValidarDatosSuelaCorridaColeccion(row, tabla, contador)
            If cadenaDatos <> "" Then
                cadenaErrores = cadenaErrores & cadenaDatos
            End If
            contador = contador + 1
        Next
        'Validar Catalogos
        Return cadenaErrores
        '----------------------------------------------------------------------------

    End Function
    ''' <summary>
    ''' Valida la informacion que contiene el archivo de layout Suela-Corrida-Coleccion
    ''' </summary>
    ''' <param name="fila"></param>
    ''' <param name="tablas"></param>
    ''' <param name="contador"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ValidarDatosSuelaCorridaColeccion(ByVal fila As DataRow, ByVal tablas As DataTable, ByVal contador As Integer) As String
        Dim resultado As String = ""
        For Each columnas As DataColumn In tablas.Columns
            Select Case columnas.ColumnName
                Case "Suela"
                    If fila("Suela").ToString().Trim = "" Or fila("Suela") Is DBNull.Value Then
                        resultado = resultado & "Error (Datos incorrectos), fila " & contador.ToString() & ". La Suela debe tener un valor" & vbNewLine
                    End If
                    If (tablaSuela.Compute("Count(Suela)", "Suela = '" & fila("Suela").ToString() & "'")) = 0 Then
                        resultado = resultado & "Error (Datos incorrectos), fila " & contador.ToString() & ". La Suela (" & fila("Suela").ToString() & ") no contiene un valor valido" & vbNewLine
                    End If
                Case "Coleccion"
                    If fila("Coleccion").ToString().Trim = "" Or fila("Coleccion") Is DBNull.Value Then
                        resultado = resultado & "Error (Datos incorrectos), fila " & contador.ToString() & ". La Coleccion que desarrolla debe tener un valor" & vbNewLine
                    End If
                    If (tablaColeccion.Compute("Count(Coleccion)", "Coleccion = '" & fila("Coleccion").ToString() & "'")) = 0 Then
                        resultado = resultado & "Error (Datos incorrectos), fila " & contador.ToString() & ". La Coleccion a desarrollar (" & fila("Coleccion").ToString() & ") no contiene un valor valido" & vbNewLine
                    End If
                Case "Corrida"
                    If fila("Corrida").ToString().Trim = "" Or fila("Corrida") Is DBNull.Value Then
                        resultado = resultado & "Error (Datos incorrectos), fila " & contador.ToString() & ". La Horma debe tener un valor" & vbNewLine
                    End If
                    'If (tablas.Compute("Count(Corrida)", "Corrida = '" & fila("Corrida").ToString() & "'")) = 0 Then
                    '    resultado = resultado & "Error (Datos incorrectos), fila " & contador.ToString() & ". La Horma (" & fila("Horma").ToString() & ") no contiene un valor valido" & vbNewLine
                    'End If
                Case "Talla"
                    If fila("Talla").ToString().Trim = "" Or fila("Talla") Is DBNull.Value Then
                        resultado = resultado & "Error (Datos incorrectos), fila " & contador.ToString() & ". La Talla debe tener un valor" & vbNewLine
                    End If
                    If (tablaTalla.Compute("Count(Talla)", "Talla = '" & fila("Talla").ToString() & "'")) = 0 Then
                        resultado = resultado & "Error (Datos incorrectos), fila " & contador.ToString() & ". La Talla (" & fila("Talla").ToString() & ") no contiene un valor valido" & vbNewLine
                    End If
                Case "Pares"
                    If fila("Pares").ToString().Trim = "" Or fila("Pares") Is DBNull.Value Then
                        resultado = resultado & "Error (Datos incorrectos), fila " & contador.ToString() & ". Los Pares debe tener un valor" & vbNewLine
                    End If
                    Try
                        Integer.Parse(fila("Pares"))
                    Catch ex As Exception
                        resultado = resultado & "Error (Datos incorrectos), fila " & contador.ToString() & ". Los Pares debe ser un valor numerico" & vbNewLine
                    End Try
            End Select
        Next
        Return resultado
    End Function
    Public Function InsertarSuelaTalla(ByVal dtBase As DataTable, ByVal Catalogo As String, ByVal fechaIni As DateTime, ByVal fechaFin As DateTime) As String
        Dim objDa As New Programacion.Datos.CargaSimulacionDA
        Dim insercionCorrecta As Boolean
        Dim resultadoCargaArchivo As String = ""
        Dim dtSimulacion As DataTable = Nothing
        For Each rowbase As DataRow In dtBase.Rows

            insercionCorrecta = objDa.InsertarSuelaTalla(rowbase("Suela"), rowbase("Coleccion"), rowbase("Corrida"), rowbase("Talla"), rowbase("Pares"))
            If insercionCorrecta = False Then
                resultadoCargaArchivo = resultadoCargaArchivo & vbNewLine & "El Registro Suela= " & rowbase("Suela").ToString() & " Coleccion=" & rowbase("Coleccion").ToString() & " Corrida= " & rowbase("Corrida").ToString() & " Talla= " & rowbase("Talla").ToString() & " Pares=" & rowbase("Pares").ToString()
            End If

        Next
        Return resultadoCargaArchivo
    End Function

    Public Function CargarSuelaSimulacionBase(ByVal fechaIni As DateTime, ByVal fechaFin As DateTime) As DataTable
        Dim objDA As New Programacion.Datos.CargaSimulacionDA
        Return objDA.CargaSuelaSimulacionBase(fechaIni, fechaFin)
    End Function
#End Region


End Class