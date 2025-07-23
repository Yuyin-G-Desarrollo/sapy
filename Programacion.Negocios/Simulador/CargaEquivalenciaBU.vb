Public Class CargaEquivalenciaBU
    Dim tablaProductoEstilo As DataTable
    Dim tablaModelo As DataTable
    Dim tablaModeloSICY As DataTable
    Dim tablaMarcas As DataTable
    Dim tablaColeccion As DataTable

    Public Function CargaCatalogoNaveBases() As DataTable
        Dim objDA As New Programacion.Datos.CargaEquivalenciaDA
        Return objDA.ConsultaNavesCatalogo
    End Function
#Region "Validacion Archivo"
    ''' <summary>
    ''' Valida que no exista el mismo registro dentro del archivo
    ''' </summary>
    ''' <param name="tabla"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ValidarDuplicados(ByVal tabla As DataTable) As String
        Dim resultado As String = ""
        Dim consecutivos As String = ""
        Dim contadorRegistro As Integer = 0
        Dim filtro As String
        For Each fila As DataRow In tabla.Rows
            If fila("Consecutivo") IsNot DBNull.Value And fila("ModeloSICY") IsNot DBNull.Value And fila("Modelo") IsNot DBNull.Value And fila("Marca") IsNot DBNull.Value And fila("Coleccion") IsNot DBNull.Value And fila("TipoProducto") IsNot DBNull.Value Then
                filtro = "Consecutivo = " & fila("Consecutivo").ToString() & " AND ModeloSICY ='" & fila("ModeloSICY").ToString() & "' AND Modelo = '" & fila("Modelo").ToString() & "' AND Marca = '" & fila("Marca").ToString() & "' AND Coleccion = '" & fila("Coleccion").ToString() & "' AND TipoProducto = '" & fila("TipoProducto").ToString() & "'"
                contadorRegistro = Integer.Parse(tabla.Compute("COUNT(ModeloSICY)", filtro))
            End If
            If contadorRegistro > 1 Then
                consecutivos = consecutivos & fila("Consecutivo") & ", "
            Else
                resultado = ""
            End If
        Next
        If consecutivos <> "" Then
            resultado = "Existen registros duplicados filas: " & consecutivos
        End If
        Return resultado
    End Function
    ''' <summary>
    ''' Verifica si el archivo de excel viene completo
    ''' </summary>
    ''' <param name="tablas"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ValidarLayout(ByVal tablas As DataTable) As Boolean
        Dim validacion As Boolean = True
        If Not tablas.Columns.Contains("idProductoEstilo") Then
            validacion = False
        End If
        If Not tablas.Columns.Contains("Consecutivo") Then
            validacion = False
        End If
        If Not tablas.Columns.Contains("ModeloSICY") Then
            validacion = False
        End If
        If Not tablas.Columns.Contains("Modelo") Then
            validacion = False
        End If
        If Not tablas.Columns.Contains("Marca") Then
            validacion = False
        End If
        If Not tablas.Columns.Contains("Coleccion") Then
            validacion = False
        End If
        'If Not tablas.Columns.Contains("Aplicaciones") Then
        '    validacion = False
        'End If
        If Not tablas.Columns.Contains("TipoProducto") Then
            validacion = False
        End If
        'If Not tablas.Columns.Contains("FechaInicioProduccion") Then
        '    validacion = False
        'End If
        'If Not tablas.Columns.Contains("FechaFinProduccion") Then
        '    validacion = False
        'End If
        Return validacion
    End Function
    Public Function ValidarColeccion(ByVal nave As Integer, ByVal tabla As DataTable) As String
        Dim validacion As String = ""
        Dim objCargaEquivalencia As New Programacion.Datos.CargaEquivalenciaDA()
        tablaColeccion = objCargaEquivalencia.ConsultaColeccionSimulacion()
        For Each row As DataRow In tabla.Rows
            If Integer.Parse(tablaColeccion.Compute("COUNT(ColeccionSAY)", String.Format("ColeccionSAY='{0}'", row("Coleccion")))) = 0 Then
                validacion = validacion & row("Coleccion").ToString & vbNewLine
            End If
        Next

        Return validacion
    End Function
    Public Function ValidarMarcas(ByVal nave As Integer, ByVal tabla As DataTable) As String
        Dim validacion As String = ""
        Dim objCargaEquivalencia As New Programacion.Datos.CargaEquivalenciaDA()
        tablaMarcas = objCargaEquivalencia.ConsultaMarcasSimulacion()
        For Each row As DataRow In tabla.Rows
            If Integer.Parse(tablaMarcas.Compute("COUNT(MarcaSAY)", String.Format("MarcaSAY='{0}'", row("Marca")))) = 0 Then
                validacion = validacion & row("Marca").ToString & vbNewLine
            End If
        Next

        Return validacion
    End Function
    Public Function ValidarModelosSICY(ByVal nave As Integer, ByVal tabla As DataTable) As String
        Dim validacion As String = ""
        Dim objCargaEquivalencia As New Programacion.Datos.CargaEquivalenciaDA()
        tablaModeloSICY = objCargaEquivalencia.ConsultaModeloSICYSimulacion()
        For Each row As DataRow In tabla.Rows
            If Integer.Parse(tablaModeloSICY.Compute("COUNT(ModeloSICY)", String.Format("ModeloSICY='{0}'", row("ModeloSICY")))) = 0 Then
                validacion = validacion & row("ModeloSICY").ToString & vbNewLine
            End If
        Next

        Return validacion
    End Function
    Public Function ValidarModelos(ByVal nave As Integer, ByVal tabla As DataTable) As String
        Dim validacion As String = ""
        Dim objCargaEquivalencia As New Programacion.Datos.CargaEquivalenciaDA()
        tablaModelo = objCargaEquivalencia.ConsultaModeloSimulacion()
        For Each row As DataRow In tabla.Rows
            If Integer.Parse(tablaModelo.Compute("COUNT(prod_modelo)", String.Format("prod_modelo='{0}'", row("Modelo")))) = 0 Then
                validacion = validacion & row("Modelo").ToString & vbNewLine
            End If
        Next

        Return validacion
    End Function
    Public Function ValidarProductoEstilo(ByVal nave As Integer, ByVal tabla As DataTable) As String
        Dim validacion As String = ""
        Dim objCargaEquivalencia As New Programacion.Datos.CargaEquivalenciaDA()
        tablaProductoEstilo = objCargaEquivalencia.ConsultaProductoEstiloSimulacion(nave)
        For Each row As DataRow In tabla.Rows
            If Integer.Parse(tablaProductoEstilo.Compute("COUNT(prod_productoid)", String.Format("prod_productoid='{0}'", Integer.Parse(row("idProductoEstilo"))))) = 0 Then
                validacion = validacion & Integer.Parse(row("idProductoEstilo").ToString).ToString & vbNewLine
            End If
        Next

        Return validacion
    End Function
#End Region

#Region "Factor Equivalencia"
    ''' <summary>
    ''' Consulta la informacion de Equivalencias desde base de datos
    ''' </summary>
    ''' <param name="nave"></param>
    ''' <param name="opcion"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ConsultaFactorEquivalencia(ByVal nave As Integer, ByVal opcion As Integer) As DataTable
        Dim tabla As DataTable
        Dim objCargaEquivalencia As New Programacion.Datos.CargaEquivalenciaDA()
        Try
            tabla = objCargaEquivalencia.CargarProductosEquivalencia(nave, opcion)
        Catch ex As Exception
            tabla = Nothing
        End Try
        Return tabla
    End Function
    Public Function ConsultaFactorEquivalenciaExport(ByVal nave As Integer, ByVal opcion As Integer) As DataTable
        Dim tabla As DataTable
        Dim objCargaEquivalencia As New Programacion.Datos.CargaEquivalenciaDA()
        Try
            tabla = objCargaEquivalencia.CargarProductosEquivalenciaExport(nave, opcion)
        Catch ex As Exception
            tabla = Nothing
        End Try
        Return tabla
    End Function
    ''' <summary>
    ''' Inserta en equivalecia colección
    ''' </summary>
    ''' <param name="coleccion"></param>
    ''' <param name="productoEstilo"></param>
    ''' <param name="talla"></param>
    ''' <param name="equivalencia"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function InsertarFactorEquivalecia(ByVal coleccion As Integer, ByVal productoEstilo As Integer, ByVal talla As Integer, ByVal equivalencia As Decimal) As Boolean
        Dim insercionCorrecta As Boolean
        Dim resultadoCargaArchivo As String = ""
        Dim dtSimulacion As DataTable = Nothing
        Dim objCargaEquivalencia As New Programacion.Datos.CargaEquivalenciaDA()

        insercionCorrecta = objCargaEquivalencia.InsertarFactorEquivalencia(coleccion, productoEstilo, talla, equivalencia)

        If insercionCorrecta = False Then

        End If

        Return resultadoCargaArchivo

    End Function
    Public Function GuardarEquivalencia(ByVal tabla As DataTable, ByVal opcion As Integer, ByVal nave As Integer) As Boolean
        Dim validacion As Boolean = True
        Dim objCargaEquivalencia As New Programacion.Datos.CargaEquivalenciaDA()
        Dim tablaEquivalencia As DataTable
        If opcion = 0 Then
            'Opcion = 0 ---Viene de importarcion de excel
            '1. Validar NaveArticulo
            '2. Insertar o modificar
            '3. Obtener talla
            '4. Validar Equivalencia
            '5. Insertar Modificar equivalencia
            '6. Bitacora
            Dim tallaId As Integer = 0
            Dim ColeccionId As Integer = 0
            Dim TablaTalla As DataTable


            For Each row As DataRow In tabla.Rows
                Dim dt As DataTable

                dt = objCargaEquivalencia.ValidaNaveArticulo(nave, row("idProductoEstilo"), 1)
                If Not validaTabla(dt) Then
                    objCargaEquivalencia.InsertarNaveArticuloPrioridad(nave, row("idProductoEstilo"), 1, Today.Date, DateAdd(DateInterval.Day, 1, Today.Date))
                End If

                TablaTalla = objCargaEquivalencia.ConsultaTallaEquivalencia(nave, row("idProductoEstilo"))
                If validaTabla(TablaTalla) Then
                    tallaId = TablaTalla.Rows(0)(0)
                    ColeccionId = TablaTalla.Rows(0)(1)
                End If

                tablaEquivalencia = objCargaEquivalencia.ValidaEquivalenciaColeccion(ColeccionId, row("idProductoEstilo"), tallaId)
                If Not validaTabla(tablaEquivalencia) Then
                    objCargaEquivalencia.InsertarFactorEquivalencia(ColeccionId, row("idProductoEstilo"), tallaId, row("FactorDeEquivalencia"))
                Else
                    objCargaEquivalencia.ModificarFactorEquivalencia(ColeccionId, row("idProductoEstilo"), tallaId, row("FactorDeEquivalencia"))
                End If

                objCargaEquivalencia.RegistraBitacoraEquivalencia(ColeccionId, row("idProductoEstilo"), tallaId, row("FactorDeEquivalencia"))

            Next
        Else
            'Opcion = 1 ---Viene de consulta
            '1. traer productos modelo
            '2. Validar Equivalencia
            '3. Insertar Modificar equivalencia
            '4. Bitacora
            Dim tablaProductos As DataTable
            For Each row As DataRow In tabla.Rows
                tablaProductos = objCargaEquivalencia.ConsultaProductosModelo(nave, row("Modelo"), row("Coleccion"))
                If validaTabla(tablaProductos) Then
                    For Each rowNew As DataRow In tablaProductos.Rows
                        tablaEquivalencia = objCargaEquivalencia.ValidaEquivalenciaColeccion(rowNew("ColeccionId"), rowNew("ProductoEstiloId"), rowNew("TallaId"))
                        If validaTabla(tablaEquivalencia) Then
                            objCargaEquivalencia.ModificarFactorEquivalencia(rowNew("ColeccionId"), rowNew("ProductoEstiloId"), rowNew("TallaId"), row("FactorDeEquivalencia"))
                        Else
                            objCargaEquivalencia.InsertarFactorEquivalencia(rowNew("ColeccionId"), rowNew("ProductoEstiloId"), rowNew("TallaId"), row("FactorDeEquivalencia"))
                        End If

                        objCargaEquivalencia.RegistraBitacoraEquivalencia(rowNew("ColeccionId"), rowNew("ProductoEstiloId"), rowNew("TallaId"), row("FactorDeEquivalencia"))
                    Next
                End If
            Next
        End If

        Return validacion
    End Function

#End Region

#Region "General"
    Private Function validaTabla(ByVal tabla As DataTable) As Boolean
        Dim respuesta As Boolean = True
        If tabla.Rows Is Nothing Then
            respuesta = False
        Else
            If tabla.Rows.Count = 0 Then
                respuesta = False
            Else
                respuesta = True
            End If
        End If
        Return respuesta
    End Function
#End Region

End Class
