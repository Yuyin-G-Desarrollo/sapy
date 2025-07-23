Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid

Public Class frmPlantaCapacidades
    Dim dtCapacidadProducto As DataTable
    Dim dtCapacidadHorma As DataTable
    Dim soltarSemanaCelula As Boolean = False
    Dim semanasDato As Int32 = 0

    Public Sub enviarInactivarCapacidad()
        Dim objElm As New frmEliminarCapacidad
        objElm.semana = CInt(DatePart(DateInterval.WeekOfYear, Date.Now))
        objElm.anio = numAnioInicio.Value
        objElm.fecha = Date.Now.Date
        Dim contSeleccion As Int32 = 0
        Dim objBU As New Negocios.LineasProduccionBU
        Dim contValida As Int32 = 0
        Dim elimino As Boolean = False

        If tbtCapacidades.SelectedTab.Name = tbtCelulas.Name Then
            'objElm.accionPantalla = "Célula"
            'For Each rowDtCel As UltraGridRow In grdLineasSemana.Rows
            '    If CBool(rowDtCel.Cells("Sel").Value = True) Then
            '        contSeleccion += 1
            '    End If
            'Next

            'If contSeleccion > 0 Then
            '    If objElm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            '        Me.Cursor = Cursors.WaitCursor
            '        semanasDato = objElm.semana
            '        For Each rowDtCel As UltraGridRow In grdLineasSemana.Rows
            '            If CBool(rowDtCel.Cells("Sel").Value = True) Then
            '                contValida = objBU.contadorGruposEnCelula(rowDtCel.Cells("idLineaCelula").Value, numAnioInicio.Value)
            '                If contValida = 0 Then
            '                    objBU.inactivarCelula(rowDtCel.Cells("id_").Value, semanasDato)
            '                Else
            '                    Dim objMAdv As New Tools.AdvertenciaForm
            '                    objMAdv.mensaje = "La capacidad de la célula " + rowDtCel.Cells("Celula").Value.ToString +
            '                        " no puede ser inactivada debido a que tiene capacidades registradas en los demás catálogos."
            '                    objMAdv.ShowDialog()
            '                End If
            '            End If
            '        Next
            '        Me.Cursor = Cursors.Default
            '        Dim objMExito As New Tools.ExitoForm
            '        objMExito.mensaje = "Registro exitoso."
            '        objMExito.ShowDialog()
            '        actualizarTablas()
            '    End If

            'Else
            '    Dim objMAdv As New Tools.AdvertenciaForm
            '    objMAdv.mensaje = "Para eliminar la capacidad requiere seleccionar, al menos un registro activo y asignado del listado."
            '    objMAdv.ShowDialog()
            'End If

        ElseIf tbtCapacidades.SelectedTab.Name = tbtGrupo.Name Then
            'objElm.accionPantalla = "Grupo"
            'For Each rowDtGrp As UltraGridRow In grdGrupoCapacidad.Rows
            '    If CBool(rowDtGrp.Cells("Sel").Value = True) Then
            '        contSeleccion += 1
            '    End If
            'Next

            'If contSeleccion > 0 Then
            '    If objElm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            '        Me.Cursor = Cursors.WaitCursor
            '        semanasDato = objElm.semana
            '        For Each rowDtGrp As UltraGridRow In grdGrupoCapacidad.Rows
            '            If CBool(rowDtGrp.Cells("Sel").Value = True) Then
            '                contValida = objBU.contadorGruposEnCelula(rowDtGrp.Cells("gcap_linpID").Value, numAnioInicio.Value)
            '                If contValida = 0 Then
            '                    objBU.inactivarGrupo(rowDtGrp.Cells("id_").Value, semanasDato)
            '                Else
            '                    Dim objMAdv As New Tools.AdvertenciaForm
            '                    objMAdv.mensaje = "La capacidad del grupo " + rowDtGrp.Cells("Grupo").Value.ToString + " en la célula " + rowDtGrp.Cells("Celula").Value.ToString +
            '                        " no puede ser inactivada debido a que tiene capacidades registradas en los demás catálogos."
            '                    objMAdv.ShowDialog()
            '                End If
            '            End If
            '        Next
            '        Me.Cursor = Cursors.Default
            '        Dim objMExito As New Tools.ExitoForm
            '        objMExito.mensaje = "Registro exitoso."
            '        objMExito.ShowDialog()
            '        actualizarTablas()
            '    End If
            'Else
            '    Dim objMAdv As New Tools.AdvertenciaForm
            '    objMAdv.mensaje = "Para eliminar la capacidad requiere seleccionar, al menos un registro activo y asignado del listado."
            '    objMAdv.ShowDialog()
            'End If

        ElseIf tbtCapacidades.SelectedTab.Name = tbtHorma.Name Then
            Dim semanaEliminaHorma As Int32 = 0
            objElm.accionPantalla = "Horma"
            For Each rowDtHrm As UltraGridRow In grdCapacidadHorma.Rows
                If CBool(rowDtHrm.Cells("Sel").Value = True) Then
                    contSeleccion += 1
                End If
            Next

            If contSeleccion > 0 Then
                If objElm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    Me.Cursor = Cursors.WaitCursor
                    semanasDato = objElm.semana
                    For Each rowDtHrm As UltraGridRow In grdCapacidadHorma.Rows
                        If CBool(rowDtHrm.Cells("Sel").Value = True) Then
                            semanaEliminaHorma = objBU.contadosProductoEnHorma(rowDtHrm.Cells("horc_linpID").Value, numAnioInicio.Value, rowDtHrm.Cells("horc_hormaID").Value, rowDtHrm.Cells("horc_tallaid").Value, semanasDato)
                            If semanaEliminaHorma > 0 Then
                                If semanasDato < semanaEliminaHorma Then
                                    Dim objMAdv As New Tools.confirmarFormGrande
                                    objMAdv.mensaje = "La horma " +
                                    rowDtHrm.Cells("Horma").Value.ToString +
                                    " puede ser eliminada a partir de la semana " + semanaEliminaHorma.ToString + " " +
                                    rowDtHrm.Cells("Corrida").Value.ToString +
                                    ", debido a que existen registros activos en capacidad de productos con la horma y la corrida asignados a la célula hasta esa semana." +
                                    " ¿Desea guardar la eliminación con la semana " + semanaEliminaHorma.ToString + "?"
                                    If objMAdv.ShowDialog() = Windows.Forms.DialogResult.OK Then
                                        objBU.inactivarHorma(rowDtHrm.Cells("id_").Value, semanaEliminaHorma, numAnioInicio.Value)
                                        elimino = True
                                    End If
                                Else
                                    objBU.inactivarHorma(rowDtHrm.Cells("id_").Value, semanasDato, numAnioInicio.Value)
                                    elimino = True
                                End If
                            Else
                                Dim objMAdv As New Tools.AdvertenciaFormGrande
                                objMAdv.mensaje = "No se puede eliminar la capacidad de la horma " +
                                    rowDtHrm.Cells("Horma").Value.ToString + " " +
                                    rowDtHrm.Cells("Corrida").Value.ToString +
                                    ", para poder hacerlo requiere eliminar la capacidad de los productos con dicha horma que están asignados a la célula " +
                                    rowDtHrm.Cells("Celula").Value.ToString + " en el año " +
                                    rowDtHrm.Cells("Anio").Value.ToString + ", verifique consultando la pestaña Producto."

                                objMAdv.ShowDialog()
                            End If
                        End If
                    Next
                    Me.Cursor = Cursors.Default
                    If elimino = True Then
                        Dim objMExito As New Tools.ExitoForm
                        objMExito.mensaje = "Registro exitoso."
                        objMExito.ShowDialog()
                        actualizarTablas()
                    End If
                End If
            Else
                Dim objMAdv As New Tools.AdvertenciaForm
                objMAdv.mensaje = "Para eliminar la capacidad requiere seleccionar, al menos un registro activo y asignado del listado."
                objMAdv.ShowDialog()
            End If

        ElseIf tbtCapacidades.SelectedTab.Name = tbtProducto.Name Then
            objElm.accionPantalla = "Producto"
            For Each rowDtProd As UltraGridRow In grdProductos.Rows
                If CBool(rowDtProd.Cells("Sel").Value = True) Then
                    contSeleccion += 1
                End If
            Next

            If contSeleccion > 0 Then
                If objElm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    Me.Cursor = Cursors.WaitCursor
                    semanasDato = objElm.semana
                    For Each rowDtProd As UltraGridRow In grdProductos.Rows
                        If CBool(rowDtProd.Cells("Sel").Value = True) Then
                            objBU.inactivarProducto(rowDtProd.Cells("id_").Value, semanasDato, numAnioInicio.Value)
                            elimino = True
                        End If
                    Next
                    Me.Cursor = Cursors.Default
                    If elimino = True Then
                        Dim objMExito As New Tools.ExitoForm
                        objMExito.mensaje = "Registro exitoso."
                        objMExito.ShowDialog()
                        actualizarTablas()
                    End If
                End If
            Else
                Dim objMAdv As New Tools.AdvertenciaForm
                objMAdv.mensaje = "Para eliminar la capacidad requiere seleccionar, al menos un registro activo y asignado del listado."
                objMAdv.ShowDialog()
            End If

            End If

    End Sub

    Public Sub actualizarLineasProduccionCelulas()
        Dim objBU As New Negocios.LineasProduccionBU
        Dim objGruposBU As New Negocios.GruposBU
        Dim dtNuevas As New DataTable
        Dim dtGrupos As New DataTable
        Dim dtGruposCelula As New DataTable
        Dim hormasNuevaCelula As New DataTable
        Dim hormasActualizarCelula As New DataTable
        Dim objHormasNave As Negocios.HormasCapacidadesBU

        Dim productosNuevaCelula As New DataTable
        Dim productosActualizarCelulas As New DataTable
        Dim objProductoNave As Negocios.productosCapacidadBU

        If numAnioInicio.Value >= Date.Now.Year Then
            Me.Cursor = Cursors.WaitCursor
            dtNuevas = objBU.consultaCelulasNuevas(numAnioInicio.Value)
            dtGrupos = objGruposBU.VerGrupos("", "", 1)

            '' Nuevas Células
            For Each rowDtCelula As DataRow In dtNuevas.Rows
                objBU.insertarCelulaCapacidad(rowDtCelula.Item("id"), numAnioInicio.Value, rowDtCelula.Item("capacidad"))
                '' Grupos
                For Each rowDtGrupo As DataRow In dtGrupos.Rows
                    objBU.insertarGrupoCapacidad(rowDtCelula.Item("id"), rowDtGrupo.Item("grpo_grupoid"), numAnioInicio.Value, 0)
                Next
                '' Hormas
                objHormasNave = New Negocios.HormasCapacidadesBU
                hormasNuevaCelula = New DataTable
                hormasNuevaCelula = objHormasNave.consultaHormaPorNave(rowDtCelula.Item("idNave"))
                For Each rowDtHorma As DataRow In hormasNuevaCelula.Rows
                    objBU.insertarHormaCapacidadCelula(rowDtCelula.Item("id"), rowDtHorma.Item("hona_hormaID"), rowDtHorma.Item("hona_tallaid"), numAnioInicio.Value, rowDtHorma.Item("hona_hormaPorNaveID"), rowDtHorma.Item("hona_capacidad"))
                Next
                '' Productos
                objProductoNave = New Negocios.productosCapacidadBU
                productosNuevaCelula = New DataTable
                productosNuevaCelula = objProductoNave.consultaProductosNave(rowDtCelula.Item("idNave"))
                For Each rowDtProducto As DataRow In productosNuevaCelula.Rows
                    objBU.insertarProductoCapacidad(rowDtCelula.Item("id"), rowDtProducto.Item("prna_productoID"), rowDtProducto.Item("prna_productoEstiloID"), rowDtProducto.Item("prna_hormaid").ToString, rowDtProducto.Item("prna_tallaID"), numAnioInicio.Value, rowDtProducto.Item("prna_capacidad"), rowDtProducto.Item("prna_prnaID"))
                Next
            Next


            ''Actualizar Células
            For Each rowGrdCelAct As UltraGridRow In grdLineasSemana.Rows
                If CBool(rowGrdCelAct.Cells("Sel").Value) = True Then

                    '' Grupos
                    dtGruposCelula = New DataTable
                    dtGruposCelula = objGruposBU.consultaGruposActualizarCapacidadLinea(rowGrdCelAct.Cells("idLineaCelula").Value, numAnioInicio.Value)
                    For Each rowDtGrupo As DataRow In dtGruposCelula.Rows
                        objBU.insertarGrupoCapacidad(rowGrdCelAct.Cells("idLineaCelula").Value, rowDtGrupo.Item("grpo_grupoid"), numAnioInicio.Value, 0)
                    Next


                    '' Hormas
                    hormasActualizarCelula = New DataTable
                    objHormasNave = New Negocios.HormasCapacidadesBU
                    hormasActualizarCelula = objHormasNave.consultaHormaPorNaveCapacidad(rowGrdCelAct.Cells("nave_naveid").Value, rowGrdCelAct.Cells("idLineaCelula").Value, numAnioInicio.Value)

                    For Each rowDtHorma As DataRow In hormasActualizarCelula.Rows
                        objBU.insertarHormaCapacidadCelula(rowGrdCelAct.Cells("idLineaCelula").Value, rowDtHorma.Item("hona_hormaID"), rowDtHorma.Item("hona_tallaid"), numAnioInicio.Value, rowDtHorma.Item("hona_hormaPorNaveID"), rowDtHorma.Item("hona_capacidad"))
                    Next

                    '' Productos 
                    productosActualizarCelulas = New DataTable
                    objProductoNave = New Negocios.productosCapacidadBU
                    productosActualizarCelulas = objProductoNave.consultaProductosNaveCapacidad(rowGrdCelAct.Cells("nave_naveid").Value, rowGrdCelAct.Cells("idLineaCelula").Value, numAnioInicio.Value)


                    For Each rowDtProducto As DataRow In productosActualizarCelulas.Rows
                        objBU.insertarProductoCapacidad(rowGrdCelAct.Cells("idLineaCelula").Value, rowDtProducto.Item("prna_productoID"), rowDtProducto.Item("prna_productoEstiloID"), rowDtProducto.Item("prna_hormaid").ToString, rowDtProducto.Item("prna_tallaID"), numAnioInicio.Value, rowDtProducto.Item("prna_capacidad"), rowDtProducto.Item("prna_prnaID"))
                    Next

                End If
            Next

            actualizarTablas()

        Else
            Dim objMAdv As New Tools.AdvertenciaForm
            objMAdv.mensaje = "No puede actualizar un año con un año menor al actual."
            objMAdv.ShowDialog()
        End If

        objBU.eliminarAniosAnteriores()
     
        Me.Cursor = Cursors.Default
    End Sub

    Public Sub actualizarTablas()

        If numAnioInicio.Value <= numAnioFin.Value Then
            If numSemanaInicio.Value <= numSemanaFinal.Value Then
                lblContSeleccionados.Text = "0"

                chkSeleccionarCelGlobal.Checked = False
                chkSeleccionarGrupo.Checked = False
                chkSeleccionarHorma.Checked = False
                chkSeleccionarProductos.Checked = False

                If Not tbtCapacidades.SelectedTab Is Nothing Then
                    If tbtCapacidades.SelectedTab.Name.ToString = "tbtCelulas" Then
                        LlenarTablaCapacidadLineaAnio()
                    ElseIf tbtCapacidades.SelectedTab.Name.ToString = "tbtGrupo" Then
                        LlenarTablaCapacidadGrupos()
                    ElseIf tbtCapacidades.SelectedTab.Name.ToString = "tbtHorma" Then
                        LlenarTablaCapacidadHorma()
                    ElseIf tbtCapacidades.SelectedTab.Name.ToString = "tbtProducto" Then
                        LlenarTablaCapacidadProducto()
                    End If
                    lblUltimaActualizacion.Text = "Ultima Actualización: " + Now.ToString("g")
                End If
            Else
                Me.Cursor = Cursors.Default
                Dim objMAdv As New Tools.AdvertenciaForm
                objMAdv.mensaje = "La semana de inicio del filtro no puede ser mayor a la semana de fin."
                objMAdv.ShowDialog()
            End If
        Else
            Dim objMAdv As New Tools.AdvertenciaForm
            objMAdv.mensaje = "El año de inicio del filtro no puede ser mayor al año de fin."
            objMAdv.ShowDialog()
        End If


        '' '' ''If numAnioInicio.Value <= numAnioFin.Value Then
        '' '' ''    LlenarTablaCapacidadLineaAnio()
        '' '' ''    LlenarTablaCapacidadGrupos()
        '' '' ''    LlenarTablaCapacidadHorma()
        '' '' ''    LlenarTablaCapacidadProducto()
        '' '' ''    ocultarSemanas()
        '' '' ''    lblContSeleccionados.Text = "0"
        '' '' ''    lblUltimaActualizacion.Text = "Ultima Actualización: " + Now.ToString("g")
        '' '' ''Else
        '' '' ''    Dim objMAdv As New Tools.AdvertenciaForm
        '' '' ''    objMAdv.mensaje = "El año de inicio del filtro no puede ser mayor al año de fin."
        '' '' ''    objMAdv.ShowDialog()
        '' '' ''End If
    End Sub

    Public Sub exportarExcel(ByVal grd As UltraGrid)
        Dim sfd As New SaveFileDialog
        sfd.DefaultExt = "xlsx"
        sfd.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm"
        Dim result As DialogResult = sfd.ShowDialog()
        Dim fileName As String = sfd.FileName
        If result = Windows.Forms.DialogResult.OK Then
            Try
                Me.Cursor = Cursors.WaitCursor
                exportExcelDetalle.Export(grd, fileName)
                Process.Start(fileName)
                Me.Cursor = Cursors.Default

            Catch ex As Exception
                Me.Cursor = Cursors.Default
                MsgBox("El documento no pudo exportarse." + vbLf + "Revise que no tenga otro documento XLS " + vbLf + "abierto con el mismo nombre.", MsgBoxStyle.Critical, "Atención")
            End Try
        End If
    End Sub

    Public Sub enviarCopiarSemana()
        Try
            Dim objCPS As New frmCopiarSemana
            Dim semanaInicio As Int32 = 0
            Dim semanaFin As Int32 = 0
            Dim capacidadCopia As Int32 = 0
            Dim objBU As New Negocios.LineasProduccionBU
            Dim columnaSel As String = ""
            Dim contSelecciono As Int32 = 0

            objCPS.anio = numAnioInicio.Value
            objCPS.semanaInicio = numSemanaInicio.Value.ToString
            objCPS.semanaFin = numSemanaFinal.Value.ToString

            If tbtCapacidades.SelectedTab.Name = tbtCelulas.Name Then
                objCPS.tablaAfectada = "Célula"
                If grdLineasSemana.ActiveRow.IsFilterRow = False Then
                    capacidadCopia = 0

                    If Not grdLineasSemana.ActiveCell Is Nothing Then
                        columnaSel = grdLineasSemana.ActiveCell.Column.ToString
                    Else
                        columnaSel = "Capacidad"
                    End If

                    If IsNumeric(columnaSel) = True Or columnaSel = "Capacidad" Then
                        objCPS.semana = columnaSel
                    Else
                        objCPS.semana = CInt(DatePart(DateInterval.WeekOfYear, Date.Now))
                    End If

                    For Each rowDt As UltraGridRow In grdLineasSemana.Rows
                        If rowDt.Cells("Sel").Value = True Then
                            contSelecciono += 1
                        End If
                    Next

                    If contSelecciono > 0 Then
                        If objCPS.ShowDialog = Windows.Forms.DialogResult.OK Then
                            Me.Cursor = Cursors.WaitCursor
                            semanaInicio = objCPS.semanaInicio
                            semanaFin = objCPS.semanaFin
                            columnaSel = objCPS.semana
                            If semanaInicio <= semanaFin Then
                                For Each rowDt As UltraGridRow In grdLineasSemana.Rows
                                    objBU = New Negocios.LineasProduccionBU
                                    If rowDt.Cells("Sel").Value = True Then
                                        ' ''If rowDt.Cells(columnaSel).Value.ToString <> "" Then
                                        If numAnioInicio.Value = objCPS.anioCopia Or columnaSel = "Capacidad" Then
                                            If rowDt.Cells(columnaSel).Value.ToString <> "" Then
                                                If rowDt.Cells("Anio").Value = Date.Now.Year Then
                                                    For i As Int32 = semanaInicio To semanaFin
                                                        'For i As Int32 = CInt(DatePart(DateInterval.WeekOfYear, Date.Now)) To semanaFin
                                                        objBU.editarCapacidadCelula(i, rowDt.Cells(columnaSel).Value, rowDt.Cells("id_").Value)
                                                    Next
                                                Else
                                                    For i As Int32 = semanaInicio To semanaFin
                                                        objBU.editarCapacidadCelula(i, rowDt.Cells(columnaSel).Value, rowDt.Cells("id_").Value)
                                                    Next
                                                End If
                                            End If
                                        Else
                                            Dim capaConsCel As String = ""

                                            capaConsCel = objBU.consultaidCapacidadCelulaAnioDiferente(rowDt.Cells("idLineaCelula").Value, objCPS.anioCopia, columnaSel)
                                            If capaConsCel <> "" Then

                                                If CInt(numAnioInicio.Value) = Date.Now.Year Then
                                                    For i As Int32 = semanaInicio To semanaFin
                                                        'For i As Int32 = CInt(DatePart(DateInterval.WeekOfYear, Date.Now)) To semanaFin
                                                        objBU.editarCapacidadCelula(i, capaConsCel, rowDt.Cells("id_").Value)
                                                    Next
                                                Else
                                                    For i As Int32 = semanaInicio To semanaFin
                                                        objBU.editarCapacidadCelula(i, capaConsCel, rowDt.Cells("id_").Value)
                                                    Next
                                                End If
                                            End If


                                        End If
                                        ' ''End If
                                    End If
                                Next
                            End If

                            Me.Cursor = Cursors.Default
                            Dim objMAdv As New Tools.ExitoForm
                            objMAdv.mensaje = "Registro exitoso."
                            objMAdv.ShowDialog()
                            actualizarTablas()
                        End If
                    Else
                        Dim objMAdv As New Tools.AdvertenciaForm
                        objMAdv.mensaje = "No seleccionó ninguna célula para actualizar."
                        objMAdv.ShowDialog()
                    End If
                End If

            ElseIf tbtCapacidades.SelectedTab.Name = tbtGrupo.Name Then
                objCPS.tablaAfectada = "Grupo"
                If grdGrupoCapacidad.ActiveRow.IsFilterRow = False Then
                    capacidadCopia = 0

                    If Not grdGrupoCapacidad.ActiveCell Is Nothing Then
                        columnaSel = grdGrupoCapacidad.ActiveCell.Column.ToString
                    Else
                        columnaSel = "1"
                    End If

                    If columnaSel = "Capacidad" Then
                        columnaSel = DatePart(DateInterval.WeekOfYear, Date.Now).ToString
                    End If

                    If IsNumeric(columnaSel) = True Then
                        objCPS.semana = columnaSel
                    Else
                        objCPS.semana = CInt(DatePart(DateInterval.WeekOfYear, Date.Now))
                    End If

                    For Each rowDt As UltraGridRow In grdGrupoCapacidad.Rows
                        If rowDt.Cells("Sel").Value = True Then
                            contSelecciono += 1
                        End If
                    Next

                    If contSelecciono > 0 Then
                        If objCPS.ShowDialog = Windows.Forms.DialogResult.OK Then
                            Me.Cursor = Cursors.WaitCursor
                            semanaInicio = objCPS.semanaInicio
                            semanaFin = objCPS.semanaFin
                            columnaSel = objCPS.semana
                            If semanaInicio <= semanaFin Then
                                For Each rowDt As UltraGridRow In grdGrupoCapacidad.Rows
                                    If rowDt.Cells("Sel").Value = True Then
                                        ' ''If rowDt.Cells(columnaSel).Value.ToString <> "" Then
                                        If numAnioInicio.Value = objCPS.anioCopia Or columnaSel = "Capacidad" Then
                                            If rowDt.Cells(columnaSel).Value.ToString <> "" Then
                                                If rowDt.Cells("Anio").Value = Date.Now.Year Then
                                                    For i As Int32 = semanaInicio To semanaFin
                                                        'For i As Int32 = CInt(DatePart(DateInterval.WeekOfYear, Date.Now)) To semanaFin
                                                        objBU.editarCapacidadGrupo(i, rowDt.Cells(columnaSel).Value, rowDt.Cells("id_").Value)
                                                    Next
                                                Else
                                                    For i As Int32 = semanaInicio To semanaFin
                                                        objBU.editarCapacidadGrupo(i, rowDt.Cells(columnaSel).Value, rowDt.Cells("id_").Value)
                                                    Next
                                                End If
                                            End If
                                        Else

                                            Dim capaConsGrupo As String = ""
                                            capaConsGrupo = objBU.consultaidCapacidadGrupoAnioDiferente(rowDt.Cells("gcap_linpID").Value, rowDt.Cells("grpo_grupoid").Value, objCPS.anioCopia, columnaSel)
                                            If capaConsGrupo <> "" Then
                                                If CInt(numAnioInicio.Value) = Date.Now.Year Then
                                                    For i As Int32 = semanaInicio To semanaFin
                                                        'For i As Int32 = CInt(DatePart(DateInterval.WeekOfYear, Date.Now)) To semanaFin
                                                        objBU.editarCapacidadGrupo(i, capaConsGrupo, rowDt.Cells("id_").Value)
                                                    Next
                                                Else
                                                    For i As Int32 = semanaInicio To semanaFin
                                                        objBU.editarCapacidadGrupo(i, capaConsGrupo, rowDt.Cells("id_").Value)
                                                    Next
                                                End If
                                            End If
                                        End If

                                        ' ''End If
                                    End If
                                Next
                            End If
                            Me.Cursor = Cursors.Default
                            Dim objMAdv As New Tools.ExitoForm
                            objMAdv.mensaje = "Registro exitoso."
                            objMAdv.ShowDialog()
                            actualizarTablas()
                        End If
                    Else
                        Dim objMAdv As New Tools.AdvertenciaForm
                        objMAdv.mensaje = "No seleccionó ningún grupo para actualizar."
                        objMAdv.ShowDialog()
                    End If
                End If

            ElseIf tbtCapacidades.SelectedTab.Name = tbtHorma.Name Then
                objCPS.tablaAfectada = "Horma"
                If grdCapacidadHorma.ActiveRow.IsFilterRow = False Then
                    capacidadCopia = 0

                    If Not grdCapacidadHorma.ActiveCell Is Nothing Then
                        columnaSel = grdCapacidadHorma.ActiveCell.Column.ToString
                    Else
                        columnaSel = "Capacidad"
                    End If

                    If IsNumeric(columnaSel) = True Or columnaSel = "Capacidad" Then
                        objCPS.semana = columnaSel
                    Else
                        objCPS.semana = CInt(DatePart(DateInterval.WeekOfYear, Date.Now))
                    End If

                    For Each rowDt As UltraGridRow In grdCapacidadHorma.Rows
                        If rowDt.Cells("Sel").Value = True Then
                            contSelecciono += 1
                        End If
                    Next

                    If contSelecciono > 0 Then
                        If objCPS.ShowDialog = Windows.Forms.DialogResult.OK Then
                            Me.Cursor = Cursors.WaitCursor
                            semanaInicio = objCPS.semanaInicio
                            semanaFin = objCPS.semanaFin
                            columnaSel = objCPS.semana
                            If semanaInicio <= semanaFin Then
                                For Each rowDt As UltraGridRow In grdCapacidadHorma.Rows
                                    If rowDt.Cells("Sel").Value = True Then
                                        ' ''If rowDt.Cells(columnaSel).Value.ToString <> "" Then
                                        If numAnioInicio.Value = objCPS.anioCopia Or columnaSel = "Capacidad" Then
                                            If rowDt.Cells(columnaSel).Value.ToString <> "" Then
                                                If rowDt.Cells("Anio").Value = Date.Now.Year Then
                                                    For i As Int32 = semanaInicio To semanaFin
                                                        'For i As Int32 = CInt(DatePart(DateInterval.WeekOfYear, Date.Now)) To semanaFin
                                                        objBU.editarCapacidadHorma(i, rowDt.Cells(columnaSel).Value, rowDt.Cells("id_").Value)
                                                    Next
                                                Else
                                                    For i As Int32 = semanaInicio To semanaFin
                                                        objBU.editarCapacidadHorma(i, rowDt.Cells(columnaSel).Value, rowDt.Cells("id_").Value)
                                                    Next
                                                End If
                                            End If
                                        Else
                                            Dim capaConsHorma As String = ""
                                            capaConsHorma = objBU.consultaidCapacidadHormaAnioDiferente(rowDt.Cells("horc_linpID").Value,
                                                                                                        rowDt.Cells("horc_hormaID").Value,
                                                                                                        rowDt.Cells("horc_tallaid").Value,
                                                                                                        rowDt.Cells("hona_hormaPorNaveID").Value,
                                                                                                        objCPS.anioCopia,
                                                                                                        columnaSel)
                                            If capaConsHorma <> "" Then
                                                If CInt(numAnioInicio.Value) = Date.Now.Year Then
                                                    For i As Int32 = semanaInicio To semanaFin
                                                        'For i As Int32 = CInt(DatePart(DateInterval.WeekOfYear, Date.Now)) To semanaFin
                                                        objBU.editarCapacidadHorma(i, capaConsHorma, rowDt.Cells("id_").Value)
                                                    Next
                                                Else
                                                    For i As Int32 = semanaInicio To semanaFin
                                                        objBU.editarCapacidadHorma(i, capaConsHorma, rowDt.Cells("id_").Value)
                                                    Next
                                                End If
                                            End If
                                        End If
                                        ' ''End If
                                    End If
                                Next
                            End If
                            Me.Cursor = Cursors.Default
                            Dim objMAdv As New Tools.ExitoForm
                            objMAdv.mensaje = "Registro exitoso."
                            objMAdv.ShowDialog()
                            actualizarTablas()
                        End If
                    Else
                        Dim objMAdv As New Tools.AdvertenciaForm
                        objMAdv.mensaje = "No seleccionó ninguna horma para actualizar."
                        objMAdv.ShowDialog()
                    End If
                End If
            ElseIf tbtCapacidades.SelectedTab.Name = tbtProducto.Name Then
                objCPS.tablaAfectada = "Producto"
                If grdProductos.ActiveRow.IsFilterRow = False Then
                    capacidadCopia = 0

                    If Not grdProductos.ActiveCell Is Nothing Then
                        columnaSel = grdProductos.ActiveCell.Column.ToString
                    Else
                        columnaSel = "Capacidad"
                    End If


                    If IsNumeric(columnaSel) = True Or columnaSel = "Capacidad" Then
                        objCPS.semana = columnaSel
                    Else
                        objCPS.semana = CInt(DatePart(DateInterval.WeekOfYear, Date.Now))
                    End If

                    For Each rowDt As UltraGridRow In grdProductos.Rows
                        If rowDt.Cells("Sel").Value = True Then
                            contSelecciono += 1
                        End If
                    Next

                    If contSelecciono > 0 Then
                        If objCPS.ShowDialog = Windows.Forms.DialogResult.OK Then
                            Me.Cursor = Cursors.WaitCursor
                            semanaInicio = objCPS.semanaInicio
                            semanaFin = objCPS.semanaFin
                            columnaSel = objCPS.semana
                            If semanaInicio <= semanaFin Then
                                For Each rowDt As UltraGridRow In grdProductos.Rows
                                    If rowDt.Cells("Sel").Value = True Then
                                        ' ''If rowDt.Cells(columnaSel).Value.ToString <> "" Then
                                        If numAnioInicio.Value = objCPS.anioCopia Or columnaSel = "Capacidad" Then
                                            If rowDt.Cells(columnaSel).Value.ToString <> "" Then
                                                If rowDt.Cells("Anio").Value = Date.Now.Year Then
                                                    For i As Int32 = semanaInicio To semanaFin
                                                        'For i As Int32 = CInt(DatePart(DateInterval.WeekOfYear, Date.Now)) To semanaFin
                                                        objBU.editarCapacidadProducto(i, rowDt.Cells(columnaSel).Value, rowDt.Cells("id_").Value)
                                                    Next
                                                Else
                                                    For i As Int32 = semanaInicio To semanaFin
                                                        objBU.editarCapacidadProducto(i, rowDt.Cells(columnaSel).Value, rowDt.Cells("id_").Value)
                                                    Next
                                                End If
                                            End If
                                        Else
                                            Dim capaConsProd As String = ""
                                            capaConsProd = objBU.consultaidCapacidadProductoAnioDiferente(rowDt.Cells("proc_linpID").Value,
                                                                                                              rowDt.Cells("proc_hormaid").Value,
                                                                                                              rowDt.Cells("proc_productoEstiloId").Value,
                                                                                                              rowDt.Cells("proc_tallaID").Value,
                                                                                                              rowDt.Cells("proc_productonaveid").Value,
                                                                                                              objCPS.anioCopia,
                                                                                                              columnaSel)
                                            If capaConsProd <> "" Then
                                                If CInt(numAnioInicio.Value) = Date.Now.Year Then
                                                    For i As Int32 = semanaInicio To semanaFin
                                                        'For i As Int32 = CInt(DatePart(DateInterval.WeekOfYear, Date.Now)) To semanaFin
                                                        objBU.editarCapacidadProducto(i, capaConsProd, rowDt.Cells("id_").Value)
                                                    Next
                                                Else
                                                    For i As Int32 = semanaInicio To semanaFin
                                                        objBU.editarCapacidadProducto(i, capaConsProd, rowDt.Cells("id_").Value)
                                                    Next
                                                End If
                                            End If
                                        End If
                                            ' ''End If
                                        End If
                                Next
                            End If
                            Me.Cursor = Cursors.Default
                            Dim objMAdv As New Tools.ExitoForm
                            objMAdv.mensaje = "Registro exitoso."
                            objMAdv.ShowDialog()
                            actualizarTablas()
                        End If
                    Else
                        Dim objMAdv As New Tools.AdvertenciaForm
                        objMAdv.mensaje = "No seleccionó ningún producto para actualizar."
                        objMAdv.ShowDialog()
                    End If
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Public Sub ocultarSemanas()
        If numSemanaInicio.Value <= numSemanaFinal.Value Then
            If grdLineasSemana.Rows.Count > 0 Then
                For i As Int32 = 1 To 52
                    If i >= CInt(numSemanaInicio.Value) And i <= CInt(numSemanaFinal.Value) Then
                        grdLineasSemana.DisplayLayout.Bands(0).Columns(i.ToString).Hidden = False
                    Else
                        grdLineasSemana.DisplayLayout.Bands(0).Columns(i.ToString).Hidden = True
                    End If
                Next
            End If

            If grdGrupoCapacidad.Rows.Count > 0 Then
                For i As Int32 = 1 To 52
                    If i >= CInt(numSemanaInicio.Value) And i <= CInt(numSemanaFinal.Value) Then
                        grdGrupoCapacidad.DisplayLayout.Bands(0).Columns(i.ToString).Hidden = False
                    Else
                        grdGrupoCapacidad.DisplayLayout.Bands(0).Columns(i.ToString).Hidden = True
                    End If
                Next
            End If

            If grdCapacidadHorma.Rows.Count > 0 Then
                For i As Int32 = 1 To 52
                    If i >= CInt(numSemanaInicio.Value) And i <= CInt(numSemanaFinal.Value) Then
                        grdCapacidadHorma.DisplayLayout.Bands(0).Columns(i.ToString).Hidden = False
                    Else
                        grdCapacidadHorma.DisplayLayout.Bands(0).Columns(i.ToString).Hidden = True
                    End If
                Next
            End If

            If grdProductos.Rows.Count > 0 Then
                For i As Int32 = 1 To 52
                    If i >= CInt(numSemanaInicio.Value) And i <= CInt(numSemanaFinal.Value) Then
                        grdProductos.DisplayLayout.Bands(0).Columns(i.ToString).Hidden = False
                    Else
                        grdProductos.DisplayLayout.Bands(0).Columns(i.ToString).Hidden = True
                    End If
                Next
            End If
        Else
            Dim objMAdv As New Tools.AdvertenciaForm
            objMAdv.mensaje = "La semana de inicio del filtro no puede ser mayor a la semana de fin."
            objMAdv.ShowDialog()
        End If
    End Sub

    Public Sub editarCapacidadCelula(ByVal semana As Int32, ByVal capacidad As Int32, ByVal idCelula As Int32)
        Dim objBU As New Negocios.LineasProduccionBU
        objBU.editarCapacidadCelula(semana, capacidad, idCelula)
    End Sub

    Public Sub editarGrupoCapacidad(ByVal semana As Int32, ByVal capacidad As Int32, ByVal idGrupoC As Int32)
        Dim objBU As New Negocios.LineasProduccionBU
        objBU.editarCapacidadGrupo(semana, capacidad, idGrupoC)
    End Sub

    Public Sub editarCapacidadHorma(ByVal semana As Int32, ByVal capacidad As Int32, ByVal idHormaC As Int32)
        Dim objBU As New Negocios.LineasProduccionBU
        objBU.editarCapacidadHorma(semana, capacidad, idHormaC)
    End Sub

    Public Sub editarCapacidadProducto(ByVal semana As Int32, ByVal capacidad As Int32, ByVal idProcCap As Int32)
        Dim objBU As New Negocios.LineasProduccionBU
        objBU.editarCapacidadProducto(semana, capacidad, idProcCap)
    End Sub

    Private Sub LlenarComboNaves()
        Try
            Dim obj As New Framework.Negocios.NavesBU
            Dim dtNaves As New DataTable
            dtNaves = obj.TablaDeNavesAuxiliares
            dtNaves.Rows.InsertAt(dtNaves.NewRow, 0)
            With cmbNaves
                .DataSource = dtNaves
                .DisplayMember = "nave_nombre"
                .ValueMember = "id_"
            End With
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LlenarTablaCapacidadLineaAnio()
        grdLineasSemana.DataSource = Nothing
        Dim objBU As New Negocios.LineasProduccionBU
        Dim dtSL As New DataTable
        Me.Cursor = Cursors.WaitCursor
        dtSL = objBU.TablaSemanaLineas(CInt(numAnioInicio.Value), CInt(numAnioFin.Value), chkActivo.Checked, chkInactivo.Checked)
        If dtSL.Rows.Count > 0 Then
            grdLineasSemana.DataSource = dtSL
            grdLineasSemana.DataBind()
            disenoGridCelulas()
        Else
            grdLineasSemana.DataSource = Nothing
        End If
        If grdLineasSemana.Rows.Count > 0 Then
            For i As Int32 = 1 To 52
                If i >= CInt(numSemanaInicio.Value) And i <= CInt(numSemanaFinal.Value) Then
                    grdLineasSemana.DisplayLayout.Bands(0).Columns(i.ToString).Hidden = False
                Else
                    grdLineasSemana.DisplayLayout.Bands(0).Columns(i.ToString).Hidden = True
                End If
            Next
        End If
        Me.Cursor = Cursors.Default

        lblUltimaActualizacion.Text = "Ultima Actualización: " + Now.ToString("g")
    End Sub

    Private Sub LlenarTablaCapacidadGrupos()
        grdGrupoCapacidad.DataSource = Nothing
        Dim idNave As String = ""
        If cmbNaves.SelectedIndex > 0 Then
            idNave = cmbNaves.SelectedValue
        Else
            idNave = "0"
        End If

        Dim objBU As New Negocios.LineasProduccionBU
        Dim dtSG As New DataTable
        Me.Cursor = Cursors.WaitCursor
        dtSG = objBU.TablaSemanaGruposAnioNave(idNave, numAnioInicio.Value, numAnioFin.Value, chkActivo.Checked, chkInactivo.Checked, chkAsignado.Checked, chkNOasignado.Checked)
        If dtSG.Rows.Count > 0 Then
            grdGrupoCapacidad.DataSource = dtSG
            disenoGridGrupos()
        Else
            grdGrupoCapacidad.DataSource = Nothing
        End If

        If grdGrupoCapacidad.Rows.Count > 0 Then
            For i As Int32 = 1 To 52
                If i >= CInt(numSemanaInicio.Value) And i <= CInt(numSemanaFinal.Value) Then
                    grdGrupoCapacidad.DisplayLayout.Bands(0).Columns(i.ToString).Hidden = False
                Else
                    grdGrupoCapacidad.DisplayLayout.Bands(0).Columns(i.ToString).Hidden = True
                End If
            Next
        End If
       
        Me.Cursor = Cursors.Default

        lblUltimaActualizacion.Text = "Ultima Actualización: " + Now.ToString("g")
    End Sub

    Private Sub LlenarTablaCapacidadProducto()
        grdProductos.DataSource = Nothing
        Dim idNave As String = ""
        If cmbNaves.SelectedIndex > 0 Then
            idNave = cmbNaves.SelectedValue
        Else
            idNave = "0"
        End If
        Dim objBU As New Negocios.LineasProduccionBU
        dtCapacidadProducto = New DataTable
        Me.Cursor = Cursors.WaitCursor
        dtCapacidadProducto = objBU.TablaSemanaProductosAnioNave(idNave, numAnioInicio.Value, numAnioFin.Value, chkActivo.Checked, chkInactivo.Checked, chkAsignado.Checked, chkNOasignado.Checked)
        If dtCapacidadProducto.Rows.Count > 0 Then
            grdProductos.DataSource = dtCapacidadProducto
            disenoGridProductos()
        Else
            grdProductos.DataSource = Nothing
        End If

        If grdProductos.Rows.Count > 0 Then
            For i As Int32 = 1 To 52
                If i >= CInt(numSemanaInicio.Value) And i <= CInt(numSemanaFinal.Value) Then
                    grdProductos.DisplayLayout.Bands(0).Columns(i.ToString).Hidden = False
                Else
                    grdProductos.DisplayLayout.Bands(0).Columns(i.ToString).Hidden = True
                End If
            Next
        End If
        
        Me.Cursor = Cursors.Default
        lblUltimaActualizacion.Text = "Ultima Actualización: " + Now.ToString("g")
    End Sub

    Private Sub LlenarTablaCapacidadHorma()
        grdCapacidadHorma.DataSource = Nothing
        Dim idNave As String = ""
        If cmbNaves.SelectedIndex > 0 Then
            idNave = cmbNaves.SelectedValue
        Else
            idNave = "0"
        End If
        Dim objBU As New Negocios.LineasProduccionBU
        dtCapacidadHorma = New DataTable
        Me.Cursor = Cursors.WaitCursor
        dtCapacidadHorma = objBU.TablaHormaAnioNave(idNave, numAnioInicio.Value, numAnioFin.Value,
                                                    chkActivo.Checked, chkInactivo.Checked, chkAsignado.Checked,
                                                    chkNOasignado.Checked)
        If dtCapacidadHorma.Rows.Count > 0 Then
            grdCapacidadHorma.DataSource = dtCapacidadHorma
            disenoGridHormas()
        Else
            grdCapacidadHorma.DataSource = Nothing
        End If

        If grdCapacidadHorma.Rows.Count > 0 Then
            For i As Int32 = 1 To 52
                If i >= CInt(numSemanaInicio.Value) And i <= CInt(numSemanaFinal.Value) Then
                    grdCapacidadHorma.DisplayLayout.Bands(0).Columns(i.ToString).Hidden = False
                Else
                    grdCapacidadHorma.DisplayLayout.Bands(0).Columns(i.ToString).Hidden = True
                End If
            Next
        End If

        Me.Cursor = Cursors.Default
        lblUltimaActualizacion.Text = "Ultima Actualización: " + Now.ToString("g")
    End Sub

    Public Sub disenoGridCelulas()
        If grdLineasSemana.Rows.Count > 0 Then

            Dim band As UltraGridBand = Me.grdLineasSemana.DisplayLayout.Bands(0)
            band.SummaryFooterCaption = "Total"

            With grdLineasSemana.DisplayLayout.Bands(0)
                .Columns("id_").Hidden = True
                .Columns("Vigente").Hidden = True
                .Columns("nave_orden").Hidden = True
                .Columns("idLineaCelula").Hidden = True
                .Columns("nave_naveid").Hidden = True
                .Columns("Sel").Header.Caption = ""
                .Columns("Celula").Header.Caption = "Célula"
                .Columns("Modificacion").Header.Caption = "Modificación"
                .Columns("Anio").Header.Caption = "Año"
                .Columns("id_").CellActivation = Activation.NoEdit
                .Columns("Nave").CellActivation = Activation.NoEdit
                .Columns("Celula").CellActivation = Activation.NoEdit
                .Columns("Activo").CellActivation = Activation.NoEdit
                .Columns("Capacidad").CellActivation = Activation.NoEdit
                .Columns("Anio").CellActivation = Activation.NoEdit
                .Columns("Modificacion").CellActivation = Activation.NoEdit
                .Columns("Usuario").CellActivation = Activation.NoEdit
                .Columns("Capacidad").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
                .Columns("Capacidad").Format = "###,###,##0"
                .Columns("Modificacion").Format = "dd/MM/yyyy HH:mm:ss"
                .Columns("Anio").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right

                Dim sum As SummarySettings
                sum = New SummarySettings
                sum = band.Summaries.Add("sum" + "Capacidad", SummaryType.Sum, band.Columns("Capacidad"))
                sum.DisplayFormat = "{0:##,##0}"
                sum.Appearance.TextHAlign = HAlign.Right

                For i As Int32 = 1 To 52

                    .Columns(i.ToString).CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
                    .Columns(i.ToString).Format = "###,###,##0"
                    sum = New SummarySettings
                    sum = band.Summaries.Add("sum" + i.ToString, SummaryType.Sum, band.Columns(i.ToString))
                    sum.DisplayFormat = "{0:##,##0}"
                    sum.Appearance.TextHAlign = HAlign.Right

                Next
                .PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)

            End With

            For Each rowDt As UltraGridRow In grdLineasSemana.Rows
                rowDt.Cells("Anio").Appearance.FontData.Bold = DefaultableBoolean.True
                If rowDt.Cells("Anio").Value < Date.Now.Year Then
                    rowDt.Cells("Anio").Appearance.ForeColor = Color.DarkOrange
                ElseIf rowDt.Cells("Anio").Value = Date.Now.Year Then
                    rowDt.Cells("Anio").Appearance.ForeColor = Color.Green
                ElseIf rowDt.Cells("Anio").Value > Date.Now.Year Then
                    rowDt.Cells("Anio").Appearance.ForeColor = Color.RoyalBlue
                End If

                If rowDt.Cells("Anio").Value < Date.Now.Year Or
                    rowDt.Cells("Activo").Value = False Or
                    rowDt.Cells("Vigente").Value = False Then
                    rowDt.Cells("Sel").Activation = Activation.NoEdit
                    For i As Int32 = 1 To 52
                        rowDt.Cells(i.ToString).Activation = Activation.NoEdit
                    Next
                ElseIf rowDt.Cells("Anio").Value = Date.Now.Year Then
                    Dim semanaActual As Int32 = CInt(DatePart(DateInterval.WeekOfYear, Date.Now))
                    For i As Int32 = 1 To semanaActual - 1
                        rowDt.Cells(i.ToString).Activation = Activation.NoEdit
                    Next

                End If
                For i As Int32 = 1 To 52
                    If rowDt.Cells(i.ToString).Value.ToString = "" Then
                        rowDt.Cells(i.ToString).Activation = Activation.NoEdit
                    End If
                Next
            Next

            grdLineasSemana.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            grdLineasSemana.DisplayLayout.Override.RowSelectorWidth = 35
            grdLineasSemana.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
            grdLineasSemana.Rows(0).Selected = True
            For i As Int32 = 1 To 52
                grdLineasSemana.DisplayLayout.Bands(0).Columns(i.ToString).Hidden = False
                band.Columns(i.ToString).Width = 50
            Next
            band.Columns("Sel").Width = 25
            grdLineasSemana.DisplayLayout.AutoFitStyle = AutoFitStyle.ExtendLastColumn
        End If
    End Sub

    Public Sub disenoGridGrupos()
        If grdGrupoCapacidad.Rows.Count > 0 Then

            Dim band As UltraGridBand = Me.grdGrupoCapacidad.DisplayLayout.Bands(0)
            band.SummaryFooterCaption = "Total"

            With grdGrupoCapacidad.DisplayLayout.Bands(0)
                .Columns("id_").Hidden = True
                .Columns("Vigente").Hidden = True
                .Columns("nave_orden").Hidden = True
                .Columns("gcap_linpID").Hidden = True
                .Columns("grpo_grupoid").Hidden = True
                .Columns("Sel").Header.Caption = ""
                .Columns("Celula").Header.Caption = "Célula"
                .Columns("Modificacion").Header.Caption = "Modificación"
                .Columns("Anio").Header.Caption = "Año"
                .Columns("id_").CellActivation = Activation.NoEdit
                .Columns("Nave").CellActivation = Activation.NoEdit
                .Columns("Celula").CellActivation = Activation.NoEdit
                .Columns("Activo").CellActivation = Activation.NoEdit
                .Columns("Asignado").CellActivation = Activation.NoEdit
                .Columns("Grupo").CellActivation = Activation.NoEdit
                .Columns("Anio").CellActivation = Activation.NoEdit
                .Columns("Modificacion").CellActivation = Activation.NoEdit
                .Columns("Usuario").CellActivation = Activation.NoEdit
                .Columns("Anio").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
                .Columns("Modificacion").Format = "dd/MM/yyyy HH:mm:ss"
                Dim sum As SummarySettings

                For i As Int32 = 1 To 52
                    .Columns(i.ToString).CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
                    .Columns(i.ToString).Format = "###,###,##0"

                    sum = New SummarySettings
                    sum = band.Summaries.Add("sum" + i.ToString, SummaryType.Sum, band.Columns(i.ToString))
                    sum.DisplayFormat = "{0:##,##0}"
                    sum.Appearance.TextHAlign = HAlign.Right

                Next

                .PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
            End With
            For Each rowDt As UltraGridRow In grdGrupoCapacidad.Rows
                rowDt.Cells("Anio").Appearance.FontData.Bold = DefaultableBoolean.True
                If rowDt.Cells("Anio").Value < Date.Now.Year Then
                    rowDt.Cells("Anio").Appearance.ForeColor = Color.DarkOrange
                ElseIf rowDt.Cells("Anio").Value = Date.Now.Year Then
                    rowDt.Cells("Anio").Appearance.ForeColor = Color.Green
                ElseIf rowDt.Cells("Anio").Value > Date.Now.Year Then
                    rowDt.Cells("Anio").Appearance.ForeColor = Color.RoyalBlue
                End If

                If rowDt.Cells("Anio").Value < Date.Now.Year Or
                    rowDt.Cells("Activo").Value = False Or
                    rowDt.Cells("Asignado").Value = False Or
                    rowDt.Cells("Vigente").Value = False Then
                    rowDt.Cells("Sel").Activation = Activation.NoEdit
                    For i As Int32 = 1 To 52
                        rowDt.Cells(i.ToString).Activation = Activation.NoEdit
                    Next
                ElseIf rowDt.Cells("Anio").Value = Date.Now.Year Then
                    Dim semanaActual As Int32 = CInt(DatePart(DateInterval.WeekOfYear, Date.Now))
                    For i As Int32 = 1 To semanaActual - 1
                        rowDt.Cells(i.ToString).Activation = Activation.NoEdit
                    Next
                End If

                For i As Int32 = 1 To 52
                    If rowDt.Cells(i.ToString).Value.ToString = "" Then
                        rowDt.Cells(i.ToString).Activation = Activation.NoEdit
                    End If
                Next

            Next
            grdGrupoCapacidad.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            grdGrupoCapacidad.DisplayLayout.Override.RowSelectorWidth = 35
            grdGrupoCapacidad.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
            grdGrupoCapacidad.Rows(0).Selected = True
            For i As Int32 = 1 To 52
                grdGrupoCapacidad.DisplayLayout.Bands(0).Columns(i.ToString).Hidden = False
                band.Columns(i.ToString).Width = 50
            Next
            band.Columns("Sel").Width = 25
            grdGrupoCapacidad.DisplayLayout.AutoFitStyle = AutoFitStyle.ExtendLastColumn
        End If
    End Sub

    Public Sub disenoGridHormas()
        If grdCapacidadHorma.Rows.Count > 0 Then
            Dim band As UltraGridBand = Me.grdCapacidadHorma.DisplayLayout.Bands(0)
            band.SummaryFooterCaption = "Total"

            With grdCapacidadHorma.DisplayLayout.Bands(0)
                .Columns("id_").Hidden = True
                .Columns("Vigente").Hidden = True
                .Columns("nave_orden").Hidden = True
                .Columns("horc_linpID").Hidden = True
                .Columns("hona_hormaPorNaveID").Hidden = True
                .Columns("horc_hormaID").Hidden = True
                .Columns("horc_tallaid").Hidden = True
                .Columns("Sel").Header.Caption = ""
                .Columns("Celula").Header.Caption = "Célula"
                .Columns("Modificacion").Header.Caption = "Modificación"
                .Columns("Anio").Header.Caption = "Año"
                .Columns("Anio").Header.Caption = "Año"
                .Columns("id_").CellActivation = Activation.NoEdit
                .Columns("Nave").CellActivation = Activation.NoEdit
                .Columns("Celula").CellActivation = Activation.NoEdit
                .Columns("Horma").CellActivation = Activation.NoEdit
                .Columns("Corrida").CellActivation = Activation.NoEdit
                .Columns("Activo").CellActivation = Activation.NoEdit
                .Columns("Asignado").CellActivation = Activation.NoEdit
                .Columns("Capacidad").CellActivation = Activation.NoEdit
                .Columns("Anio").CellActivation = Activation.NoEdit
                .Columns("Modificacion").CellActivation = Activation.NoEdit
                .Columns("Usuario").CellActivation = Activation.NoEdit
                .Columns("Capacidad").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
                .Columns("Capacidad").Format = "###,###,##0"
                .Columns("Modificacion").Format = "dd/MM/yyyy HH:mm:ss"
                .Columns("Anio").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right

                Dim sum As SummarySettings
                sum = New SummarySettings
                sum = band.Summaries.Add("sum" + "Capacidad", SummaryType.Sum, band.Columns("Capacidad"))
                sum.DisplayFormat = "{0:##,##0}"
                sum.Appearance.TextHAlign = HAlign.Right

                For i As Int32 = 1 To 52
                    .Columns(i.ToString).CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
                    .Columns(i.ToString).Format = "###,###,##0"

                    sum = New SummarySettings
                    sum = band.Summaries.Add("sum" + i.ToString, SummaryType.Sum, band.Columns(i.ToString))
                    sum.DisplayFormat = "{0:##,##0}"
                    sum.Appearance.TextHAlign = HAlign.Right

                Next
                .PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
            End With
            For Each rowDt As UltraGridRow In grdCapacidadHorma.Rows
                rowDt.Cells("Anio").Appearance.FontData.Bold = DefaultableBoolean.True
                If rowDt.Cells("Anio").Value < Date.Now.Year Then
                    rowDt.Cells("Anio").Appearance.ForeColor = Color.DarkOrange
                ElseIf rowDt.Cells("Anio").Value = Date.Now.Year Then
                    rowDt.Cells("Anio").Appearance.ForeColor = Color.Green
                ElseIf rowDt.Cells("Anio").Value > Date.Now.Year Then
                    rowDt.Cells("Anio").Appearance.ForeColor = Color.RoyalBlue
                End If

                If rowDt.Cells("Anio").Value < Date.Now.Year Or
                    rowDt.Cells("Activo").Value = False Or
                    rowDt.Cells("Asignado").Value = False Or
                    rowDt.Cells("Vigente").Value = False Then
                    rowDt.Cells("Sel").Activation = Activation.NoEdit
                    For i As Int32 = 1 To 52
                        rowDt.Cells(i.ToString).Activation = Activation.NoEdit
                    Next
                ElseIf rowDt.Cells("Anio").Value = Date.Now.Year Then
                    Dim semanaActual As Int32 = CInt(DatePart(DateInterval.WeekOfYear, Date.Now))
                    For i As Int32 = 1 To semanaActual - 1
                        rowDt.Cells(i.ToString).Activation = Activation.NoEdit
                    Next
                End If

                For i As Int32 = 1 To 52
                    If rowDt.Cells(i.ToString).Value.ToString = "" Then
                        rowDt.Cells(i.ToString).Activation = Activation.NoEdit
                    End If
                Next

            Next
            grdCapacidadHorma.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            grdCapacidadHorma.DisplayLayout.Override.RowSelectorWidth = 35
            grdCapacidadHorma.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
            grdCapacidadHorma.Rows(0).Selected = True
            For i As Int32 = 1 To 52
                grdCapacidadHorma.DisplayLayout.Bands(0).Columns(i.ToString).Hidden = False
                band.Columns(i.ToString).Width = 50
            Next
            band.Columns("Sel").Width = 25
            grdCapacidadHorma.DisplayLayout.AutoFitStyle = AutoFitStyle.ExtendLastColumn
        End If
    End Sub

    Public Sub disenoGridProductos()

        If grdProductos.Rows.Count > 0 Then

            Dim band As UltraGridBand = Me.grdProductos.DisplayLayout.Bands(0)
            band.SummaryFooterCaption = "Total"

            With grdProductos.DisplayLayout.Bands(0)
                .Columns("id_").Hidden = True
                .Columns("Vigente").Hidden = True
                .Columns("nave_orden").Hidden = True
                .Columns("proc_linpID").Hidden = True
                .Columns("prna_hormaid").Hidden = True
                .Columns("proc_productoEstiloId").Hidden = True
                .Columns("proc_tallaID").Hidden = True
                .Columns("proc_productonaveid").Hidden = True
                .Columns("Sel").Header.Caption = ""
                .Columns("Celula").Header.Caption = "Célula"
                .Columns("Modificacion").Header.Caption = "Modificación"
                .Columns("Anio").Header.Caption = "Año"
                .Columns("Coleccion").Header.Caption = "Colección"
                .Columns("id_").CellActivation = Activation.NoEdit
                .Columns("Nave").CellActivation = Activation.NoEdit
                .Columns("Celula").CellActivation = Activation.NoEdit
                .Columns("Modelo").CellActivation = Activation.NoEdit
                .Columns("Horma").CellActivation = Activation.NoEdit
                .Columns("Corrida").CellActivation = Activation.NoEdit
                .Columns("Piel").CellActivation = Activation.NoEdit
                .Columns("Color").CellActivation = Activation.NoEdit
                .Columns("Coleccion").CellActivation = Activation.NoEdit
                .Columns("Marca").CellActivation = Activation.NoEdit
                .Columns("Activo").CellActivation = Activation.NoEdit
                .Columns("Asignado").CellActivation = Activation.NoEdit
                .Columns("Capacidad").CellActivation = Activation.NoEdit
                .Columns("Anio").CellActivation = Activation.NoEdit
                .Columns("Modificacion").CellActivation = Activation.NoEdit
                .Columns("Usuario").CellActivation = Activation.NoEdit
                .Columns("Anio").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
                .Columns("Capacidad").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
                .Columns("Capacidad").Format = "###,###,##0"
                .Columns("Modificacion").Format = "dd/MM/yyyy HH:mm:ss"
                Dim sum As SummarySettings

                sum = New SummarySettings
                sum = band.Summaries.Add("sum" + "Capacidad", SummaryType.Sum, band.Columns("Capacidad"))
                sum.DisplayFormat = "{0:##,##0}"
                sum.Appearance.TextHAlign = HAlign.Right

                For i As Int32 = 1 To 52
                    .Columns(i.ToString).CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
                    .Columns(i.ToString).Format = "###,###,##0"
                    sum = New SummarySettings
                    sum = band.Summaries.Add("sum" + i.ToString, SummaryType.Sum, band.Columns(i.ToString))
                    sum.DisplayFormat = "{0:##,##0}"
                    sum.Appearance.TextHAlign = HAlign.Right
                Next
                .PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
            End With
            For Each rowDt As UltraGridRow In grdProductos.Rows
                rowDt.Cells("Anio").Appearance.FontData.Bold = DefaultableBoolean.True
                If rowDt.Cells("Anio").Value < Date.Now.Year Then
                    rowDt.Cells("Anio").Appearance.ForeColor = Color.DarkOrange
                ElseIf rowDt.Cells("Anio").Value = Date.Now.Year Then
                    rowDt.Cells("Anio").Appearance.ForeColor = Color.Green
                ElseIf rowDt.Cells("Anio").Value > Date.Now.Year Then
                    rowDt.Cells("Anio").Appearance.ForeColor = Color.RoyalBlue
                End If

                If rowDt.Cells("Anio").Value < Date.Now.Year Or
                    rowDt.Cells("Activo").Value = False Or
                    rowDt.Cells("Asignado").Value = False Or
                    rowDt.Cells("Vigente").Value = False Then
                    rowDt.Cells("Sel").Activation = Activation.NoEdit
                    For i As Int32 = 1 To 52
                        rowDt.Cells(i.ToString).Activation = Activation.NoEdit
                    Next
                ElseIf rowDt.Cells("Anio").Value = Date.Now.Year Then
                    Dim semanaActual As Int32 = CInt(DatePart(DateInterval.WeekOfYear, Date.Now))
                    For i As Int32 = 1 To semanaActual - 1
                        rowDt.Cells(i.ToString).Activation = Activation.NoEdit
                    Next
                End If

                For i As Int32 = 1 To 52
                    If rowDt.Cells(i.ToString).Value.ToString = "" Then
                        rowDt.Cells(i.ToString).Activation = Activation.NoEdit
                    End If
                Next

            Next
            grdProductos.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            grdProductos.DisplayLayout.Override.RowSelectorWidth = 35
            grdProductos.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
            grdProductos.Rows(0).Selected = True
            For i As Int32 = 1 To 52
                grdProductos.DisplayLayout.Bands(0).Columns(i.ToString).Hidden = False
                band.Columns(i.ToString()).Width = 50
            Next
            band.Columns("Sel").Width = 25
            band.Columns("Piel").Width = 100
            band.Columns("Coleccion").Width = 100
            band.Columns("Color").Width = 100
            band.Columns("Horma").Width = 100
            grdProductos.DisplayLayout.AutoFitStyle = AutoFitStyle.ExtendLastColumn
        End If
    End Sub

    Private Sub frmPlantaCapacidades_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Me.Top = 0
        'Me.Left = 0
        Me.WindowState = FormWindowState.Maximized
        LlenarComboNaves()
        numAnioInicio.Value = Date.Now.Year
        numAnioFin.Value = Date.Now.Year
        numSemanaInicio.Value = CInt(DatePart(DateInterval.WeekOfYear, Date.Now))
        LlenarTablaCapacidadLineaAnio()
        lblContSeleccionados.Text = "0"
        lblSemanaActual.Text = "Semana actual: " + DatePart(DateInterval.WeekOfYear, Date.Now).ToString
    End Sub

    Private Sub btnActualizarCelulas_Click(sender As Object, e As EventArgs) Handles btnActualizarCelulas.Click
        Dim contCelsSel As Int32 = 0
        Dim objMAdv As New Tools.confirmarFormGrande
        For Each rowGrd As UltraGridRow In grdLineasSemana.Rows
            If CBool(rowGrd.Cells("Sel").Value) = True Then
                contCelsSel += 1
            End If
        Next
        If contCelsSel > 0 Then
            objMAdv.mensaje = "¿Desea actualizar las capacidades del año " + numAnioInicio.Value.ToString + " de las " + contCelsSel.ToString + " células seleccionadas? Adicionalmente se generarán las capacidades de aquellas células recién agregadas al catálogo  que no han sido actualizadas con anterioridad. Este proceso puede tardar varios minutos"
        Else
            objMAdv.mensaje = "No existen células seleccionadas, ¿Desea generar las capacidades de las células recién agregadas al catálogo? Este proceso puede tardar varios minutos"
        End If
        If objMAdv.ShowDialog() = Windows.Forms.DialogResult.OK Then
            actualizarLineasProduccionCelulas()
        End If
    End Sub

    Private Sub btnCopiarSemanas_Click(sender As Object, e As EventArgs) Handles btnCopiarSemanas.Click
        If numSemanaInicio.Value <= numSemanaFinal.Value Then
            enviarCopiarSemana()
            Me.Cursor = Cursors.Default
        Else
            Me.Cursor = Cursors.Default
            Dim objMAdv As New Tools.AdvertenciaForm
            objMAdv.mensaje = "La semana de inicio del filtro no puede ser mayor a la semana de fin."
            objMAdv.ShowDialog()
        End If
    End Sub

    Private Sub btnEliminarAsignacion_Click(sender As Object, e As EventArgs) Handles btnEliminarAsignacion.Click
        If numSemanaInicio.Value <= numSemanaFinal.Value Then
            enviarInactivarCapacidad()
            Me.Cursor = Cursors.Default
        Else
            Me.Cursor = Cursors.Default
            Dim objMAdv As New Tools.AdvertenciaForm
            objMAdv.mensaje = "La semana de inicio del filtro no puede ser mayor a la semana de fin."
            objMAdv.ShowDialog()
        End If
    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        If tbtCapacidades.SelectedTab.Name = tbtCelulas.Name Then
            If grdLineasSemana.Rows.Count > 0 Then
                exportarExcel(grdLineasSemana)
            Else
                MsgBox("No hay registros que exportar", MsgBoxStyle.Information, "")
            End If
        ElseIf tbtCapacidades.SelectedTab.Name = tbtGrupo.Name Then
            If grdGrupoCapacidad.Rows.Count > 0 Then
                exportarExcel(grdGrupoCapacidad)
            Else
                MsgBox("No hay registros que exportar", MsgBoxStyle.Information, "")
            End If
        ElseIf tbtCapacidades.SelectedTab.Name = tbtHorma.Name Then
            If grdCapacidadHorma.Rows.Count > 0 Then
                exportarExcel(grdCapacidadHorma)
            Else
                MsgBox("No hay registros que exportar", MsgBoxStyle.Information, "")
            End If
        ElseIf tbtCapacidades.SelectedTab.Name = tbtProducto.Name Then
            If grdProductos.Rows.Count > 0 Then
                exportarExcel(grdProductos)
            Else
                MsgBox("No hay registros que exportar", MsgBoxStyle.Information, "")
            End If
        End If
    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        actualizarTablas()
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        grpNaves.Height = 38
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        grpNaves.Height = 86
    End Sub

    Private Sub chkSeleccionarCelGlobal_CheckedChanged(sender As Object, e As EventArgs) Handles chkSeleccionarCelGlobal.CheckedChanged
        For Each rowDt As UltraGridRow In grdLineasSemana.Rows.GetFilteredInNonGroupByRows
            If rowDt.Cells("Anio").Value >= Date.Now.Year And
                    rowDt.Cells("Activo").Value = True And
                    rowDt.Cells("Vigente").Value = True Then
                rowDt.Cells("Sel").Value = chkSeleccionarCelGlobal.Checked
            End If
        Next


        lblContSeleccionados.Text = "0"
        For Each rowDt As UltraGridRow In grdLineasSemana.Rows
            If rowDt.Cells("Sel").Value = True Then
                lblContSeleccionados.Text = CInt(CInt(lblContSeleccionados.Text) + 1).ToString("N0")
            End If
        Next
    End Sub

    Private Sub chkSeleccionarGrupo_CheckedChanged(sender As Object, e As EventArgs) Handles chkSeleccionarGrupo.CheckedChanged
        For Each rowDt As UltraGridRow In grdGrupoCapacidad.Rows.GetFilteredInNonGroupByRows
            If rowDt.Cells("Anio").Value >= Date.Now.Year And
                    rowDt.Cells("Activo").Value = True And
                    rowDt.Cells("Vigente").Value = True And
                      rowDt.Cells("Asignado").Value = True Then
                rowDt.Cells("Sel").Value = chkSeleccionarGrupo.Checked
            End If

        Next

        lblContSeleccionados.Text = "0"
        For Each rowDt As UltraGridRow In grdGrupoCapacidad.Rows
            If rowDt.Cells("Sel").Value = True Then
                lblContSeleccionados.Text = CInt(CInt(lblContSeleccionados.Text) + 1).ToString("N0")
            End If
        Next
    End Sub

    Private Sub chkSeleccionarHorma_CheckedChanged(sender As Object, e As EventArgs) Handles chkSeleccionarHorma.CheckedChanged
        For Each rowDt As UltraGridRow In grdCapacidadHorma.Rows.GetFilteredInNonGroupByRows
            If rowDt.Cells("Anio").Value >= Date.Now.Year And
                   rowDt.Cells("Activo").Value = True And
                   rowDt.Cells("Vigente").Value = True And
                      rowDt.Cells("Asignado").Value = True Then
                rowDt.Cells("Sel").Value = chkSeleccionarHorma.Checked
            End If
        Next

        lblContSeleccionados.Text = "0"
        For Each rowDt As UltraGridRow In grdCapacidadHorma.Rows
            If rowDt.Cells("Sel").Value = True Then
                lblContSeleccionados.Text = CInt(CInt(lblContSeleccionados.Text) + 1).ToString("N0")
            End If
        Next
    End Sub

    Private Sub chkSeleccionarProductos_CheckedChanged(sender As Object, e As EventArgs) Handles chkSeleccionarProductos.CheckedChanged
        For Each rowDt As UltraGridRow In grdProductos.Rows.GetFilteredInNonGroupByRows
            If rowDt.Cells("Anio").Value >= Date.Now.Year And
                    rowDt.Cells("Activo").Value = True And
                    rowDt.Cells("Vigente").Value = True And
                      rowDt.Cells("Asignado").Value = True Then
                rowDt.Cells("Sel").Value = chkSeleccionarProductos.Checked
            End If

        Next

        lblContSeleccionados.Text = "0"
        For Each rowDt As UltraGridRow In grdProductos.Rows
            If rowDt.Cells("Sel").Value = True Then
                lblContSeleccionados.Text = CInt(CInt(lblContSeleccionados.Text) + 1).ToString("N0")
            End If
        Next
    End Sub


    ''GRID grdLineasSemana PESTAÑA Células(Global)

    Private Sub grdLineasSemana_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles grdLineasSemana.InitializeLayout

    End Sub

    Private Sub grdLineasSemana_KeyDown(sender As Object, e As KeyEventArgs) Handles grdLineasSemana.KeyDown
        If e.KeyCode = Keys.Enter Then
            grdLineasSemana.PerformAction(UltraGridAction.ExitEditMode, False, False)
            Dim banda As UltraGridBand = grdLineasSemana.DisplayLayout.Bands(0)
            If grdLineasSemana.ActiveRow.HasNextSibling(True) Then
                Dim nextRow As UltraGridRow = grdLineasSemana.ActiveRow.GetSibling(SiblingRow.Next, True)
                grdLineasSemana.ActiveCell = nextRow.Cells(grdLineasSemana.ActiveCell.Column)
                e.Handled = True
                grdLineasSemana.PerformAction(UltraGridAction.EnterEditMode, False, False)
            End If
        End If
    End Sub

    Private Sub grdLineasSemana_BeforeCellUpdate(sender As Object, e As UltraWinGrid.BeforeCellUpdateEventArgs) Handles grdLineasSemana.BeforeCellUpdate
        If e.Cell.Row.IsFilterRow = False Then
            If e.Cell.Column.ToString <> "Sel" Then
                If IsNumeric(e.NewValue.ToString) Or (e.NewValue.ToString = "" And soltarSemanaCelula = True) Then
                    If e.NewValue >= 0 Then
                        If e.NewValue >= 0 Then
                            Dim objMensaje As New Tools.ConfirmarForm
                            objMensaje.mensaje = "¿Desea actualizar la capacidad de la célula "
                            If objMensaje.ShowDialog = Windows.Forms.DialogResult.OK Then
                                Me.Cursor = Cursors.WaitCursor
                                editarCapacidadCelula(e.Cell.Column.ToString, e.NewValue, e.Cell.Row.Cells("id_").Value)
                                Me.Cursor = Cursors.Default
                            Else
                                e.Cancel = True
                            End If
                        Else
                            Dim objMAdv As New Tools.AdvertenciaForm
                            objMAdv.mensaje = "La capacidad debe ser capturada con valores numéricos mayores o iguales a 0."
                            objMAdv.ShowDialog()
                            e.Cancel = True
                        End If
                    Else
                        Dim objMAdv As New Tools.AdvertenciaForm
                        objMAdv.mensaje = "La capacidad debe ser capturada con valores numéricos mayores o iguales a 0."
                        objMAdv.ShowDialog()
                        e.Cancel = True
                    End If
                Else
                    Dim objMAdv As New Tools.AdvertenciaForm
                    objMAdv.mensaje = "La capacidad debe ser capturada con valores numéricos mayores o iguales a 0."
                    objMAdv.ShowDialog()
                    e.Cancel = True
                End If
            End If
        End If
    End Sub

    Private Sub grdLineasSemana_Error(sender As Object, e As ErrorEventArgs) Handles grdLineasSemana.Error
        If e.ErrorText = "Unable to update the data value: Value could not be converted to System.Int32." Then
            e.Cancel = True
            Dim objMAdv As New Tools.AdvertenciaForm
            objMAdv.mensaje = "La capacidad debe ser capturada con valores numéricos mayores o iguales a 0. Presione ""Escape"" para salir"
            objMAdv.ShowDialog()
            e.Cancel = True
        End If
    End Sub

    Private Sub grdLineasSemana_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdLineasSemana.BeforeRowsDeleted
        e.Cancel = True
    End Sub

    Private Sub grdLineasSemana_CellChange(sender As Object, e As CellEventArgs) Handles grdLineasSemana.CellChange
        If e.Cell.Column.ToString = "Sel" Then
            If CBool(e.Cell.Text) = True Then
                lblContSeleccionados.Text = CInt(CInt(lblContSeleccionados.Text) + 1).ToString("N0")
            Else
                lblContSeleccionados.Text = CInt(CInt(lblContSeleccionados.Text) - 1).ToString("N0")
            End If
        End If
    End Sub

    Private Sub grdLineasSemana_AfterSelectChange(sender As Object, e As AfterSelectChangeEventArgs) Handles grdLineasSemana.AfterSelectChange
        Dim contSel As Int32 = 0
        With grdLineasSemana
            If .ActiveRow Is Nothing Then Exit Sub
            If .ActiveRow.Index < 0 Then Exit Sub
        End With

        Try
            Me.Cursor = Cursors.WaitCursor

            For Each rowDt In grdLineasSemana.Rows
                If rowDt.Selected Then
                    If rowDt.Cells("Anio").Value >= Date.Now.Year And
                        rowDt.Cells("Activo").Value = True And
                        rowDt.Cells("Vigente").Value = True Then
                        rowDt.Cells("Sel").Value = True
                        contSel += 1
                    End If
                Else
                    rowDt.Cells("Sel").Value = False
                End If
            Next
            lblContSeleccionados.Text = contSel.ToString("N0")
            grdLineasSemana.EndUpdate()

        Catch ex As Exception

        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub


    ''GRID grdGrupoCapacidad PESTAÑA Grupo

    Private Sub grdGrupoCapacidad_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles grdGrupoCapacidad.InitializeLayout

    End Sub

    Private Sub grdGrupoCapacidad_KeyDown(sender As Object, e As KeyEventArgs) Handles grdGrupoCapacidad.KeyDown
        If e.KeyCode = Keys.Enter Then
            grdGrupoCapacidad.PerformAction(UltraGridAction.ExitEditMode, False, False)
            Dim banda As UltraGridBand = grdGrupoCapacidad.DisplayLayout.Bands(0)
            If grdGrupoCapacidad.ActiveRow.HasNextSibling(True) Then
                Dim nextRow As UltraGridRow = grdGrupoCapacidad.ActiveRow.GetSibling(SiblingRow.Next, True)
                grdGrupoCapacidad.ActiveCell = nextRow.Cells(grdGrupoCapacidad.ActiveCell.Column)
                e.Handled = True
                grdGrupoCapacidad.PerformAction(UltraGridAction.EnterEditMode, False, False)
            End If
        End If
    End Sub

    Private Sub grdGrupoCapacidad_BeforeCellUpdate(sender As Object, e As BeforeCellUpdateEventArgs) Handles grdGrupoCapacidad.BeforeCellUpdate
        If e.Cell.Row.IsFilterRow = False Then
            If e.Cell.Column.ToString <> "Sel" Then
                If IsNumeric(e.NewValue.ToString) Or (e.NewValue.ToString = "" And soltarSemanaCelula = True) Then
                    If e.NewValue >= 0 Then
                        Dim objMensaje As New Tools.ConfirmarForm
                        objMensaje.mensaje = "¿Desea actualizar la capacidad de grupo?"
                        If objMensaje.ShowDialog = Windows.Forms.DialogResult.OK Then
                            Me.Cursor = Cursors.WaitCursor
                            editarGrupoCapacidad(e.Cell.Column.ToString, e.NewValue, e.Cell.Row.Cells("id_").Value)
                            Me.Cursor = Cursors.Default
                        Else
                            e.Cancel = True
                        End If
                    Else
                        Dim objMAdv As New Tools.AdvertenciaForm
                        objMAdv.mensaje = "La capacidad debe ser capturada con valores numéricos mayores o iguales a 0."
                        objMAdv.ShowDialog()
                        e.Cancel = True
                    End If
                Else
                    Dim objMAdv As New Tools.AdvertenciaForm
                    objMAdv.mensaje = "La capacidad debe ser capturada con valores numéricos mayores o iguales a 0."
                    objMAdv.ShowDialog()
                    e.Cancel = True
                End If
            End If
        End If
    End Sub

    Private Sub grdGrupoCapacidad_Error(sender As Object, e As ErrorEventArgs) Handles grdGrupoCapacidad.Error
        If e.ErrorText = "Unable to update the data value: Value could not be converted to System.Int32." Then
            e.Cancel = True
            Dim objMAdv As New Tools.AdvertenciaForm
            objMAdv.mensaje = "La capacidad debe ser capturada con valores numéricos mayores o iguales a 0. Presione ""Escape"" para salir"
            objMAdv.ShowDialog()
            e.Cancel = True
        End If
    End Sub

    Private Sub grdGrupoCapacidad_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdGrupoCapacidad.BeforeRowsDeleted
        e.Cancel = True
    End Sub

    Private Sub grdGrupoCapacidad_CellChange(sender As Object, e As CellEventArgs) Handles grdGrupoCapacidad.CellChange
        If e.Cell.Column.ToString = "Sel" Then
            If CBool(e.Cell.Text) = True Then
                lblContSeleccionados.Text = CInt(CInt(lblContSeleccionados.Text) + 1).ToString("N0")
            Else
                lblContSeleccionados.Text = CInt(CInt(lblContSeleccionados.Text) - 1).ToString("N0")
            End If
        End If
    End Sub

    Private Sub grdGrupoCapacidad_AfterSelectChange(sender As Object, e As AfterSelectChangeEventArgs) Handles grdGrupoCapacidad.AfterSelectChange
        Dim contSel As Int32 = 0
        With grdGrupoCapacidad
            If .ActiveRow Is Nothing Then Exit Sub
            If .ActiveRow.Index < 0 Then Exit Sub
        End With

        Try
            Me.Cursor = Cursors.WaitCursor

            For Each rowDt In grdGrupoCapacidad.Rows
                If rowDt.Selected Then
                    If rowDt.Cells("Anio").Value >= Date.Now.Year And
                      rowDt.Cells("Activo").Value = True And
                      rowDt.Cells("Vigente").Value = True And
                      rowDt.Cells("Asignado").Value = True Then
                        rowDt.Cells("Sel").Value = True
                        contSel += 1
                    End If
                Else
                    rowDt.Cells("Sel").Value = False
                End If
            Next
            lblContSeleccionados.Text = contSel.ToString("N0")
            grdGrupoCapacidad.EndUpdate()

        Catch ex As Exception

        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub


    ''GRID grdCapacidadHorma PESTAÑA Horma

    Private Sub grdCapacidadHorma_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles grdCapacidadHorma.InitializeLayout

    End Sub

    Private Sub grdCapacidadHorma_KeyDown(sender As Object, e As KeyEventArgs) Handles grdCapacidadHorma.KeyDown
        If e.KeyCode = Keys.Enter Then
            grdCapacidadHorma.PerformAction(UltraGridAction.ExitEditMode, False, False)
            Dim banda As UltraGridBand = grdCapacidadHorma.DisplayLayout.Bands(0)
            If grdCapacidadHorma.ActiveRow.HasNextSibling(True) Then
                Dim nextRow As UltraGridRow = grdCapacidadHorma.ActiveRow.GetSibling(SiblingRow.Next, True)
                grdCapacidadHorma.ActiveCell = nextRow.Cells(grdCapacidadHorma.ActiveCell.Column)
                e.Handled = True
                grdCapacidadHorma.PerformAction(UltraGridAction.EnterEditMode, False, False)
            End If
        End If
    End Sub

    Private Sub grdCapacidadHorma_BeforeCellUpdate(sender As Object, e As BeforeCellUpdateEventArgs) Handles grdCapacidadHorma.BeforeCellUpdate
        If e.Cell.Row.IsFilterRow = False Then
            If e.Cell.Column.ToString <> "Sel" Then
                If IsNumeric(e.NewValue.ToString) Or (e.NewValue.ToString = "" And soltarSemanaCelula = True) Then
                    If e.NewValue >= 0 Then
                        Dim objMensaje As New Tools.ConfirmarForm
                        objMensaje.mensaje = "¿Desea actualizar la capacidad de la horma?"
                        If objMensaje.ShowDialog = Windows.Forms.DialogResult.OK Then
                            Me.Cursor = Cursors.WaitCursor
                            editarCapacidadHorma(e.Cell.Column.ToString, e.NewValue, e.Cell.Row.Cells("id_").Value)
                            Me.Cursor = Cursors.Default
                        Else
                            e.Cancel = True
                        End If
                    Else
                        Dim objMAdv As New Tools.AdvertenciaForm
                        objMAdv.mensaje = "La capacidad debe ser capturada con valores numéricos mayores o iguales a 0."
                        objMAdv.ShowDialog()
                        e.Cancel = True
                    End If
                Else
                    Dim objMAdv As New Tools.AdvertenciaForm
                    objMAdv.mensaje = "La capacidad debe ser capturada con valores numéricos mayores o iguales a 0."
                    objMAdv.ShowDialog()
                    e.Cancel = True
                End If
            End If
        End If
    End Sub

    Private Sub grdCapacidadHorma_Error(sender As Object, e As ErrorEventArgs) Handles grdCapacidadHorma.Error
        If e.ErrorText = "Unable to update the data value: Value could not be converted to System.Int32." Then
            e.Cancel = True
            Dim objMAdv As New Tools.AdvertenciaForm
            objMAdv.mensaje = "La capacidad debe ser capturada con valores numéricos mayores o iguales a 0. Presione ""Escape"" para salir"
            objMAdv.ShowDialog()
            e.Cancel = True
        End If
    End Sub

    Private Sub grdCapacidadHorma_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdCapacidadHorma.BeforeRowsDeleted
        e.Cancel = True
    End Sub

    Private Sub grdCapacidadHorma_CellChange(sender As Object, e As CellEventArgs) Handles grdCapacidadHorma.CellChange
        If e.Cell.Column.ToString = "Sel" Then
            If CBool(e.Cell.Text) = True Then
                lblContSeleccionados.Text = CInt(CInt(lblContSeleccionados.Text) + 1).ToString("N0")
            Else
                lblContSeleccionados.Text = CInt(CInt(lblContSeleccionados.Text) - 1).ToString("N0")
            End If
        End If
    End Sub

    Private Sub grdCapacidadHorma_AfterSelectChange(sender As Object, e As AfterSelectChangeEventArgs) Handles grdCapacidadHorma.AfterSelectChange
        Dim contSel As Int32 = 0
        With grdCapacidadHorma
            If .ActiveRow Is Nothing Then Exit Sub
            If .ActiveRow.Index < 0 Then Exit Sub
        End With

        Try
            Me.Cursor = Cursors.WaitCursor

            For Each rowDt In grdCapacidadHorma.Rows
                If rowDt.Selected Then
                    If rowDt.Cells("Anio").Value >= Date.Now.Year And
                      rowDt.Cells("Activo").Value = True And
                      rowDt.Cells("Vigente").Value = True And
                      rowDt.Cells("Asignado").Value = True Then
                        rowDt.Cells("Sel").Value = True
                        contSel += 1
                    End If
                Else
                    rowDt.Cells("Sel").Value = False
                End If
            Next
            lblContSeleccionados.Text = contSel.ToString("N0")
            grdCapacidadHorma.EndUpdate()

        Catch ex As Exception

        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub


    ''GRID grdProductos PESTAÑA Productos

    Private Sub grdProductos_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles grdProductos.InitializeLayout

    End Sub

    Private Sub grdProductos_KeyDown(sender As Object, e As KeyEventArgs) Handles grdProductos.KeyDown
        If e.KeyCode = Keys.Enter Then
            grdProductos.PerformAction(UltraGridAction.ExitEditMode, False, False)
            Dim banda As UltraGridBand = grdProductos.DisplayLayout.Bands(0)
            If grdProductos.ActiveRow.HasNextSibling(True) Then
                Dim nextRow As UltraGridRow = grdProductos.ActiveRow.GetSibling(SiblingRow.Next, True)
                grdProductos.ActiveCell = nextRow.Cells(grdProductos.ActiveCell.Column)
                e.Handled = True
                grdProductos.PerformAction(UltraGridAction.EnterEditMode, False, False)
            End If
        End If
    End Sub

    Private Sub grdProductos_BeforeCellUpdate(sender As Object, e As BeforeCellUpdateEventArgs) Handles grdProductos.BeforeCellUpdate
        If e.Cell.Row.IsFilterRow = False Then
            If e.Cell.Column.ToString <> "Sel" Then
                If IsNumeric(e.NewValue.ToString) Or (e.NewValue.ToString = "" And soltarSemanaCelula = True) Then
                    If e.NewValue >= 0 Then
                        Dim objMensaje As New Tools.ConfirmarForm
                        objMensaje.mensaje = "¿Desea actualizar la capacidad del producto?"
                        If objMensaje.ShowDialog = Windows.Forms.DialogResult.OK Then
                            Me.Cursor = Cursors.WaitCursor
                            editarCapacidadProducto(e.Cell.Column.ToString, e.NewValue, e.Cell.Row.Cells("id_").Value)
                            Me.Cursor = Cursors.Default
                        Else
                            e.Cancel = True
                        End If
                    Else
                        Dim objMAdv As New Tools.AdvertenciaForm
                        objMAdv.mensaje = "La capacidad debe ser capturada con valores numéricos mayores o iguales a 0."
                        objMAdv.ShowDialog()
                        e.Cancel = True
                    End If
                Else
                    Dim objMAdv As New Tools.AdvertenciaForm
                    objMAdv.mensaje = "La capacidad debe ser capturada con valores numéricos mayores o iguales a 0."
                    objMAdv.ShowDialog()
                    e.Cancel = True
                End If
            End If
        End If
    End Sub

    Private Sub grdProductos_Error(sender As Object, e As ErrorEventArgs) Handles grdProductos.Error
        If e.ErrorText = "Unable to update the data value: Value could not be converted to System.Int32." Then
            e.Cancel = True
            Dim objMAdv As New Tools.AdvertenciaForm
            objMAdv.mensaje = "La capacidad debe ser capturada con valores numéricos mayores o iguales a 0. Presione ""Escape"" para salir"
            objMAdv.ShowDialog()
            e.Cancel = True
        End If
    End Sub

    Private Sub grdProductos_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdProductos.BeforeRowsDeleted
        e.Cancel = True
    End Sub

    Private Sub grdProductos_CellChange(sender As Object, e As CellEventArgs) Handles grdProductos.CellChange
        If e.Cell.Column.ToString = "Sel" Then
            If CBool(e.Cell.Text) = True Then
                lblContSeleccionados.Text = CInt(CInt(lblContSeleccionados.Text) + 1).ToString("N0")
            Else
                lblContSeleccionados.Text = CInt(CInt(lblContSeleccionados.Text) - 1).ToString("N0")
            End If
        End If
    End Sub

    Private Sub grdProductos_AfterSelectChange(sender As Object, e As AfterSelectChangeEventArgs) Handles grdProductos.AfterSelectChange
        Dim contSel As Int32 = 0
        With grdProductos
            If .ActiveRow Is Nothing Then Exit Sub
            If .ActiveRow.Index < 0 Then Exit Sub
        End With

        Try
            Me.Cursor = Cursors.WaitCursor

            For Each rowDt In grdProductos.Rows
                If rowDt.Selected Then
                    If rowDt.Cells("Anio").Value >= Date.Now.Year And
                     rowDt.Cells("Activo").Value = True And
                     rowDt.Cells("Vigente").Value = True And
                      rowDt.Cells("Asignado").Value = True Then
                        rowDt.Cells("Sel").Value = True
                        contSel += 1
                    End If
                Else
                    rowDt.Cells("Sel").Value = False
                End If
            Next
            lblContSeleccionados.Text = contSel.ToString("N0")
            grdProductos.EndUpdate()

        Catch ex As Exception

        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    '' 
    Private Sub nudAño_ValueChanged(sender As Object, e As EventArgs) Handles numAnioInicio.ValueChanged
        Dim tbtSel As String = ""
        If Not tbtCapacidades.SelectedTab Is Nothing Then
            tbtSel = tbtCapacidades.SelectedTab.Name.ToString
        Else
            tbtSel = "tbt"
        End If


        If numAnioInicio.Value < Date.Now.Year Then
            pnlBotones.Enabled = False
        Else
            pnlBotones.Enabled = True
        End If
        If numAnioInicio.Value = numAnioFin.Value Then
            btnCopiarSemanas.Enabled = True
            lblCopiarSemana.Enabled = True
            If tbtSel = "tbtHorma" Or tbtSel = "tbtProducto" Then
                btnEliminarAsignacion.Enabled = True
                lblEliminarAsignacion.Enabled = True
            Else
                btnEliminarAsignacion.Enabled = False
                lblEliminarAsignacion.Enabled = False
            End If

        Else
            btnCopiarSemanas.Enabled = False
            lblCopiarSemana.Enabled = False
            btnEliminarAsignacion.Enabled = False
            lblEliminarAsignacion.Enabled = False
        End If
        actualizarTablas()
        'If numAnioInicio.Value <= numAnioFin.Value Then
        '    LlenarTablaCapacidadLineaAnio()
        '    LlenarTablaCapacidadGrupos()
        '    LlenarTablaCapacidadHorma()
        '    LlenarTablaCapacidadProducto()
        '    ocultarSemanas()
        'Else
        '    Dim objMAdv As New Tools.AdvertenciaForm
        '    objMAdv.mensaje = "El año de inicio del filtro no puede ser mayor al año de fin."
        '    objMAdv.ShowDialog()
        'End If
    End Sub

    Private Sub numAnioFin_ValueChanged(sender As Object, e As EventArgs) Handles numAnioFin.ValueChanged
        Dim tbtSel As String = ""
        If Not tbtCapacidades.SelectedTab Is Nothing Then
            tbtSel = tbtCapacidades.SelectedTab.Name.ToString
        Else
            tbtSel = "tbt"
        End If


        If numAnioInicio.Value < Date.Now.Year Then
            pnlBotones.Enabled = False
        Else
            pnlBotones.Enabled = True
        End If
        If numAnioInicio.Value = numAnioFin.Value Then
            btnCopiarSemanas.Enabled = True
            lblCopiarSemana.Enabled = True
            If tbtSel = "tbtHorma" Or tbtSel = "tbtProducto" Then
                btnEliminarAsignacion.Enabled = True
                lblEliminarAsignacion.Enabled = True
            Else
                btnEliminarAsignacion.Enabled = False
                lblEliminarAsignacion.Enabled = False
            End If

        Else
            btnCopiarSemanas.Enabled = False
            lblCopiarSemana.Enabled = False
            btnEliminarAsignacion.Enabled = False
            lblEliminarAsignacion.Enabled = False
        End If
        actualizarTablas()
    End Sub

    Private Sub nudSemana_ValueChanged(sender As Object, e As EventArgs) Handles numSemanaInicio.ValueChanged

    End Sub

    Private Sub nudSemanaFinal_ValueChanged(sender As Object, e As EventArgs) Handles numSemanaFinal.ValueChanged

    End Sub

    Private Sub cmbNaves_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbNaves.SelectedIndexChanged
        actualizarTablas()
    End Sub

    Private Sub tbtCapacidades_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tbtCapacidades.SelectedIndexChanged
        If tbtCapacidades.SelectedTab.Name = "tbtCelulas" Then
            lblEtiquetaSeleccionados.Text = "Células" & vbCrLf & "Seleccionadas"
            btnActualizarCelulas.Enabled = True
            lblctualizarCelulas.Enabled = True
            btnEliminarAsignacion.Enabled = False
        ElseIf tbtCapacidades.SelectedTab.Name = "tbtGrupo" Then
            lblEtiquetaSeleccionados.Text = "Grupos" & vbCrLf & "Seleccionadas"
            btnActualizarCelulas.Enabled = False
            lblctualizarCelulas.Enabled = False
            btnEliminarAsignacion.Enabled = False
        ElseIf tbtCapacidades.SelectedTab.Name = "tbtHorma" Then
            lblEtiquetaSeleccionados.Text = "Hormas" & vbCrLf & "Seleccionadas"
            btnActualizarCelulas.Enabled = False
            lblctualizarCelulas.Enabled = False
            If numAnioInicio.Value = numAnioFin.Value Then
                btnEliminarAsignacion.Enabled = True
                lblEliminarAsignacion.Enabled = True
            Else
                btnEliminarAsignacion.Enabled = False
                lblEliminarAsignacion.Enabled = False
            End If
            Dim objBU As New Negocios.LineasProduccionBU
            objBU.inactivarHormasSemanaActual()

        ElseIf tbtCapacidades.SelectedTab.Name = "tbtProducto" Then
            lblEtiquetaSeleccionados.Text = "Productos" & vbCrLf & "Seleccionadas"
            btnActualizarCelulas.Enabled = False
            lblctualizarCelulas.Enabled = False
            If numAnioInicio.Value = numAnioFin.Value Then
                btnEliminarAsignacion.Enabled = True
                lblEliminarAsignacion.Enabled = True
            Else
                btnEliminarAsignacion.Enabled = False
                lblEliminarAsignacion.Enabled = False
            End If
            Dim objBU As New Negocios.LineasProduccionBU
            objBU.inactivarProductosSemanaActual()
        End If
        actualizarTablas()
    End Sub

End Class
