Imports DevExpress.XtraEditors.Controls
Imports System.Threading
Imports System.Threading.Tasks



Public Class AgregarImagenesDT
    Public Shared barraProgresoLocal As New DevExpress.XtraEditors.ProgressBarControl
    Public Shared cancelarProcesoCargaImagenes As CancellationTokenSource



    ''' <summary>
    ''' Carga las imágenes de productos a un DataTable.
    ''' </summary>
    ''' <param name="pantallaOrigen">Formulario desde donde se llama este método.</param>
    ''' <param name="dtTabla">DataTable con los datos.</param>
    ''' <param name="columnaRutaFoto">Nombre de la columna que contiene la ruta de la imagen.</param>
    ''' <param name="columnaImagen">Nombre de la columna de tipo Image donde se asignará la imagen.</param>
    ''' <returns>DataTable actualizado con las imágenes.</returns>
    Public Shared Async Function AgregarImagenesTabla(ByVal pantallaOrigen As Form,
                                                      ByVal dtTabla As DataTable,
                                                      ByVal columnaRutaFoto As String,
                                                      ByVal columnaImagen As String,
                                                      Optional ByVal cancelarProceso As CancellationToken = Nothing) As Task(Of DataTable)
        If pantallaOrigen Is Nothing Then
            Tools.MostrarMensaje(Mensajes.Warning, "No se encuentra la pantalla origen de la tabla. Se cancela el proceso de inserción de imágenes.")
            Return dtTabla
        End If

        If dtTabla Is Nothing OrElse dtTabla.Rows.Count = 0 Then
            Tools.MostrarMensaje(Mensajes.Warning, "La tabla que está usando no tiene información. Se cancela el proceso de inserción de imágenes.")
            Return dtTabla
        End If

        If Not dtTabla.Columns.Contains(columnaRutaFoto) Then
            Tools.MostrarMensaje(Mensajes.Warning, "Es obligatorio tener una columna llamada '" & columnaRutaFoto & "' (ruta de las imágenes) en su tabla. Se cancela el proceso de inserción de imágenes.")
            Return dtTabla
        End If

        If Not dtTabla.Columns.Contains(columnaImagen) Then
            Tools.MostrarMensaje(Mensajes.Warning, "Es obligatorio tener una columna llamada '" & columnaImagen & "' (tipo Image) en su tabla. Se cancela el proceso de inserción de imágenes.")
            Return dtTabla
        End If

        If dtTabla.Columns(columnaImagen).ReadOnly Then
            Tools.MostrarMensaje(Mensajes.Warning, "La columna '" & columnaImagen & "' es de solo lectura y no se pueden asignar imágenes. Se cancela el proceso de inserción de imágenes.")
            Return dtTabla
        End If


        Try
            InicializarBarraProgreso(pantallaOrigen)

            Dim dtReporte As DataTable = Await Task.Run(Function()
                                                            Return AgregarImagenesProductos(pantallaOrigen, dtTabla, columnaRutaFoto, columnaImagen, cancelarProceso)
                                                        End Function, cancelarProceso)

            Return dtReporte
        Catch ex As OperationCanceledException
            Tools.MostrarMensaje(Mensajes.Notice, "El proceso de inserción de imágenes fue cancelado por el usuario.")
            Return dtTabla
        Catch ex As Exception
            Tools.MostrarMensaje(Mensajes.Warning, "Ha ocurrido un error al agregar las imágenes a la tabla: " & ex.Message)
            Return dtTabla
        Finally
            RemoverBarraProgreso(pantallaOrigen)
        End Try
    End Function



    Private Shared Sub InicializarBarraProgreso(ByVal pantallaOrigen As Form)
        ' Si la instancia es Nothing o ya fue dispuesta, crear una nueva.
        If barraProgresoLocal Is Nothing OrElse barraProgresoLocal.IsDisposed Then
            barraProgresoLocal = New DevExpress.XtraEditors.ProgressBarControl()
        End If

        ' Configurar la barra de progreso
        With barraProgresoLocal
            .Size = New Size(300, 30)
            Dim x As Integer = (pantallaOrigen.ClientSize.Width - .Width) \ 2
            Dim y As Integer = (pantallaOrigen.ClientSize.Height - .Height) \ 2
            .Location = New Point(x, y)

            .Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            .Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
            .Properties.ShowTitle = True
            .Properties.StartColor = Color.Blue
            .Properties.EndColor = Color.Blue
            .Properties.Appearance.ForeColor = Color.Blue
            .Properties.Appearance.BackColor = Color.Blue
            .Properties.ProgressViewStyle = ProgressViewStyle.Solid
            .Properties.ProgressKind = ProgressKind.Horizontal
            .Properties.PercentView = True
            .Properties.Minimum = 0
            .Properties.Maximum = 100
            .Position = .Properties.Minimum
        End With

        ' Agregar la barra al formulario
        pantallaOrigen.Controls.Add(barraProgresoLocal)
        barraProgresoLocal.BringToFront()

        ' Agregar el handler para el texto personalizado (si no se agregó previamente)
        RemoveHandler barraProgresoLocal.Properties.CustomDisplayText, AddressOf BarraProgreso_CustomDisplayText
        AddHandler barraProgresoLocal.Properties.CustomDisplayText, AddressOf BarraProgreso_CustomDisplayText
    End Sub

    Private Shared Sub RemoverBarraProgreso(ByVal pantallaOrigen As Form)
        If barraProgresoLocal IsNot Nothing Then
            ' Realizar la remoción en el hilo de la UI
            pantallaOrigen.Invoke(Sub()
                                      barraProgresoLocal.Visible = False
                                      pantallaOrigen.Controls.Remove(barraProgresoLocal)
                                  End Sub)
            barraProgresoLocal.Dispose()
            ' Reiniciar la variable para evitar reuso de una instancia dispuesta
            barraProgresoLocal = Nothing
        End If
    End Sub

    Private Shared Sub BarraProgreso_CustomDisplayText(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs)
        e.DisplayText = $"Cargando imágenes... {CInt(barraProgresoLocal.Position)}% completado"
    End Sub



    ''' <summary>
    ''' Descarga y asigna imágenes a un DataTable desde un servidor FTP.
    ''' Si la imagen no se encuentra o falla la descarga, se usa una imagen por defecto.
    ''' El proceso se ejecuta en paralelo para mejorar el rendimiento.
    ''' </summary>
    ''' <param name="pantallaOrigen">Formulario de origen, usado para mostrar la barra de progreso.</param>
    ''' <param name="dtTabla">DataTable que contiene las rutas de las imágenes.</param>
    ''' <param name="columnaRutaFoto">Nombre de la columna que contiene el nombre de archivo o ruta de la imagen.</param>
    ''' <param name="columnaImagen">Nombre de la columna tipo Image donde se guardará la imagen descargada.</param>
    ''' <returns>El mismo DataTable pero con la columna de imágenes cargada.</returns>
    Private Shared Function AgregarImagenesProductos(ByVal pantallaOrigen As Form,
                                                     ByVal dtTabla As DataTable,
                                                     ByVal columnaRutaFoto As String,
                                                     ByVal columnaImagen As String,
                                                     ByVal cancelarProceso As CancellationToken) As DataTable
        Dim objFTP As New Global.Tools.TransferenciaFTP
        Dim CarpetaUbicacionImagenes As String = "Programacion/Modelos/"
        Dim rutaFotoSinImagen As String = "ImagenModeloNoEncontrada.png"    '' Nombre del archivo de imagen por defecto si no se encuentra la imagen original.

        Dim dtReporte As DataTable = dtTabla.Copy()
        Dim total As Integer = dtReporte.Rows.Count
        Dim progreso As Integer = 0
        ''Dim rutaFoto As String = ""
        Dim syncObject As New Object()  '' Objeto de sincronización para evitar conflictos al modificar variables compartidas entre hilos.


        If total > 0 Then
            '' Mostrar la barra de progreso (esto debe hacerse en el hilo de la interfaz). Esta barra ya existe antes de ejecutar el método, solo que está oculta.
            pantallaOrigen.Invoke(Sub() barraProgresoLocal.Visible = True)

            '' Para evitar sobrecargar el servidor con peticiones, limitamos el número de descargas máximo a 10.
            Dim numMaximoDescargasSimultaneas As New ParallelOptions With {
                .MaxDegreeOfParallelism = 5,
                .CancellationToken = cancelarProceso
            }

            '' Parallel permite ejecutar un código sobre múltiples hilos, permitiendo que se ejecuten simultáneamente sin depender de si una ya terminó o no.
            ''      Esto es muy útil aquí donde cada fila ocupa una imagen distinta y no interfieren entre sí. También se puede liminar el número de hilos que se pueden ejecutar en simultáneo en caso de que un proceso o el servidor no tolere tantas peticiones.
            Parallel.ForEach(dtReporte.AsEnumerable(), numMaximoDescargasSimultaneas, Sub(articulo)
                                                                                          Dim rutaActual As String = If(IsDBNull(articulo(columnaRutaFoto)), "", articulo(columnaRutaFoto).ToString().Trim())
                                                                                          Dim imagenAsignada As Image = Nothing

                                                                                          Try
                                                                                              '' Si existe una ruta de la imagen, se intenta la descarga de la imagen.
                                                                                              If Not String.IsNullOrEmpty(rutaActual) AndAlso rutaActual <> columnaRutaFoto Then
                                                                                                  Using streamFoto As IO.Stream = objFTP.StreamFile(CarpetaUbicacionImagenes, rutaActual)
                                                                                                      Using imgDescargada As Image = Bitmap.FromStream(streamFoto)
                                                                                                          '' Si la imagen tiene una imagen redimencionada, descargamos esa, de lo contrario, redimencionamos la original.
                                                                                                          If rutaActual.Contains("Redimencionada") = False Then
                                                                                                              imagenAsignada = ProcesarImagen(imgDescargada)
                                                                                                          Else
                                                                                                              imagenAsignada = New Bitmap(imgDescargada)
                                                                                                          End If
                                                                                                      End Using
                                                                                                  End Using
                                                                                              Else
                                                                                                  Throw New Exception("Ruta inválida")
                                                                                              End If
                                                                                          Catch
                                                                                              Try
                                                                                                  '' Si falla la descarga (error de conexión o no existe imágen), se busca la imagen por defecto.
                                                                                                  Using streamFoto As IO.Stream = objFTP.StreamFile(CarpetaUbicacionImagenes, rutaFotoSinImagen)
                                                                                                      Using imgDescargada As Image = Bitmap.FromStream(streamFoto)
                                                                                                          If rutaActual.Contains("Redimencionada") = False Then
                                                                                                              imagenAsignada = ProcesarImagen(imgDescargada)
                                                                                                          Else
                                                                                                              imagenAsignada = New Bitmap(imgDescargada)
                                                                                                          End If
                                                                                                      End Using
                                                                                                  End Using
                                                                                              Catch
                                                                                                  '' Si falla incluso la imagen por defecto, se asigna Nothing.
                                                                                                  imagenAsignada = Nothing
                                                                                              End Try
                                                                                          End Try


                                                                                          '' Sección crítica para modificar la tabla y actualizar la barra de progreso.
                                                                                          SyncLock syncObject
                                                                                              '' ----- Asignación de la imagen al datatable
                                                                                              articulo(columnaImagen) = imagenAsignada



                                                                                              '' ----- Incremento del progreso de la barra (esto no interfiere en el datatable).
                                                                                              progreso += 1
                                                                                              Dim porcentaje As Integer = CInt((progreso / total) * 100)
                                                                                              Dim frecuenciaActualizacion As Integer = Math.Max(1, total \ 100) ' cada 1% al menos

                                                                                              '' Actualizamos la barra de progreso solo cada 10 elementos o al final para evitar sobrecarga.
                                                                                              If progreso Mod frecuenciaActualizacion = 0 OrElse progreso = total Then
                                                                                                  pantallaOrigen.Invoke(Sub()
                                                                                                                            barraProgresoLocal.Position = porcentaje
                                                                                                                            barraProgresoLocal.Update()
                                                                                                                        End Sub)

                                                                                                  ''''''' Limpiamos los recursos usados para la generación del archivo de Excel.
                                                                                                  '''''GC.Collect()
                                                                                                  '''''GC.WaitForPendingFinalizers()
                                                                                              End If
                                                                                          End SyncLock
                                                                                      End Sub)
        End If



        '' Limpiamos los recursos usados para la generación del archivo de Excel.
        GC.Collect()
        GC.WaitForPendingFinalizers()

        Return dtReporte
    End Function

    Private Shared Function ProcesarImagen(ByVal imagen As Image) As Image
        Dim imagenRedimensionada As Image
        If imagen.Width > 2000 Then
            imagenRedimensionada = Image.FromStream(Tools.TransferenciaFTP.RedimensionarImagen(imagen, imagen.Width * 0.2, imagen.Height * 0.2))
        Else
            imagenRedimensionada = Image.FromStream(Tools.TransferenciaFTP.RedimensionarImagen(imagen, imagen.Width * 0.4, imagen.Height * 0.4))
        End If
        Return imagenRedimensionada
    End Function



    Public Shared Sub CancelarCargaImagenes()
        If cancelarProcesoCargaImagenes IsNot Nothing Then
            cancelarProcesoCargaImagenes.Cancel()
        End If
    End Sub

End Class
