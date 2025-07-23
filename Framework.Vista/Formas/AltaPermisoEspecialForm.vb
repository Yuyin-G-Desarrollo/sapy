
Public Class AltaPermisoEspecialForm

    Public idUsuarioArbol As String
    Public nombreUsuario As String

    'Public Sub LlenarComboPerfiles()
    '    Dim perfilesNegocios As New Framework.Negocios.PerfilesBU
    '    Dim dtComboPerfilesDatos As New DataTable
    '    dtComboPerfilesDatos = perfilesNegocios.VerPerfiles()
    '    dtComboPerfilesDatos.Rows.InsertAt(dtComboPerfilesDatos.NewRow, 0)
    '    cmbPerfiles.DataSource = dtComboPerfilesDatos
    '    cmbPerfiles.ValueMember = "perf_perfilid"
    '    cmbPerfiles.DisplayMember = "perf_nombre"
    'End Sub

    'Public Sub LlenarComboUsuarios(ByVal idPerfil As String)
    '    Dim perfilesNegocios As New Framework.Negocios.PerfilesBU
    '    Dim dtComboUsuariosDatos As New DataTable
    '    dtComboUsuariosDatos = perfilesNegocios.VerUsuariosPerfil(idPerfil)
    '    dtComboUsuariosDatos.Rows.InsertAt(dtComboUsuariosDatos.NewRow, 0)
    '    cmbUsuarios.DataSource = dtComboUsuariosDatos
    '    cmbUsuarios.ValueMember = "user_usuarioid"
    '    cmbUsuarios.DisplayMember = "NombreUsuario"
    'End Sub

    Public Sub LlenarNodosModulos(ByVal idUsuario As String)
        Dim FrameworNegocios As New Framework.Negocios.ModulosBU
        Dim dtTablaModulosPrincipales As New DataTable
        Dim dtModulosHijos As New DataTable
        Dim dtModulosHijosUltimos As New DataTable
        Dim filaModPadre As DataRow
        ArbolModulos.CheckBoxes = True
        Dim recorreNieto As Int32 = 1
        Dim recorrepp As Int32 = 0
        Dim recorreHijo As Int32 = 0

        Dim tipoPermiso As String = ""
        If (rdoSiPermiso.Checked = True) Then
            tipoPermiso = "1"
        ElseIf (rdoNoPermiso.Checked = True) Then
            tipoPermiso = "2"
        End If

        dtTablaModulosPrincipales = FrameworNegocios.VerModulosPadres
        ArbolModulos.Nodes.Clear()
        '-----------------------------------------------
        For Each filaModPadre In dtTablaModulosPrincipales.Rows
            Dim NodoModulo As TreeNode
            NodoModulo = New TreeNode(CStr(filaModPadre.Item(1)))
            NodoModulo.Tag = CStr(filaModPadre.Item(0))
            ArbolModulos.Nodes.Add(NodoModulo)

            Dim dtPermisoSeleccionadoPadre As New DataTable
            Dim FilaPermisoSeleccionadoPadre As DataRow
            dtPermisoSeleccionadoPadre = FrameworNegocios.verPermisoPorUsuarioPadre(idUsuario, filaModPadre.Item(0).ToString)

            For Each FilaPermisoSeleccionadoPadre In dtPermisoSeleccionadoPadre.Rows
                If (FilaPermisoSeleccionadoPadre.Item(0).ToString = filaModPadre.Item(0).ToString) Then
                    ArbolModulos.Nodes(recorrepp).Checked = True
                End If
            Next

            dtModulosHijos = FrameworNegocios.VerModulosHijos(CStr(filaModPadre.Item(0)))
            Dim childrow As DataRow
            Dim childnode As TreeNode
            childnode = New TreeNode()
            recorreHijo = 0
            '-----------------------------------------------------
            For Each childrow In dtModulosHijos.Rows
                childnode = New TreeNode(CStr(childrow.Item(1)))
                childnode.Tag = CStr(childrow.Item(0))

                'Dim DetalleHijo1 As String = CStr(childrow.Item(1)).ToString
                NodoModulo.Nodes.Add(childnode)

                Dim dtPermisoSeleccionadoHijoUno As New DataTable
                Dim FilaPermisoSeleccionadoHijoUno As DataRow
                dtPermisoSeleccionadoHijoUno = FrameworNegocios.verPermisoPorUsuarioHijoUno(idUsuario, filaModPadre.Item(0).ToString, childrow.Item(0).ToString)
                For Each FilaPermisoSeleccionadoHijoUno In dtPermisoSeleccionadoHijoUno.Rows
                    If (FilaPermisoSeleccionadoHijoUno.Item(0).ToString = childrow.Item(0).ToString) Then
                        NodoModulo.Nodes(recorreHijo).Checked = True
                    End If
                Next

                dtModulosHijosUltimos = FrameworNegocios.VerModulosHijos(CStr(childrow.Item(0)))
                Dim childrow2 As DataRow
                Dim childnode2 As TreeNode
                childnode2 = New TreeNode()
                recorreNieto = 0
                '-------------------------------------------------------
                For Each childrow2 In dtModulosHijosUltimos.Rows
                    childnode2 = New TreeNode(CStr(childrow2.Item(1)))
                    childnode2.Tag = CStr(childrow2.Item(0))
                    childnode.Nodes.Add(childnode2)

                    Dim dtPermisoSeleccionadoHijoDos As New DataTable
                    Dim FilaPermisoSeleccionadoHijoDos As DataRow
                    dtPermisoSeleccionadoHijoDos = FrameworNegocios.verPermisoPorUsuarioHijoDos(idUsuario, filaModPadre.Item(0).ToString, childrow.Item(0).ToString, childrow2.Item(0).ToString, tipoPermiso)

                    For Each FilaPermisoSeleccionadoHijoDos In dtPermisoSeleccionadoHijoDos.Rows
                        If (FilaPermisoSeleccionadoHijoDos.Item(0).ToString = childrow2.Item(0).ToString) Then
                            childnode.Nodes(recorreNieto).Checked = True
                        End If
                    Next

                    Dim childrow3 As DataRow
                    Dim childnode3 As TreeNode
                    Dim dtAcciones As New DataTable
                    Dim dtNietosSeleccionados As New DataTable
                    Dim FilaDetalleNieto1 As DataRow
                    dtAcciones = FrameworNegocios.verAccionesModulos(CStr(childnode2.Tag), CStr(childnode.Tag), CStr(NodoModulo.Tag))
                    dtNietosSeleccionados = FrameworNegocios.verPermisoPorUsuarioHijoDosDetalle(idUsuario, filaModPadre.Item(0).ToString, childrow2.Item(0).ToString, childrow2.Item(0).ToString, tipoPermiso)

                    ''-----------------------------------------------------
                    Dim recorreAccion As Int32 = 0
                    For Each childrow3 In dtAcciones.Rows
                        childnode3 = New TreeNode(childrow3.Item(1).ToString)
                        childnode3.Tag = childrow3.Item(0).ToString
                        childnode2.Nodes.Add(childnode3)

                        
                        For Each FilaDetalleNieto1 In dtNietosSeleccionados.Rows
                            If (FilaDetalleNieto1.Item(0).ToString = childrow3.Item(0).ToString) Then
                                childnode2.Nodes(recorreAccion).Checked = True
                            End If
                        Next

                        recorreAccion = recorreAccion + 1
                    Next childrow3
                    recorreNieto = recorreNieto + 1
                Next childrow2
                recorreHijo = recorreHijo + 1
            Next childrow
            recorrepp = recorrepp + 1
        Next
    End Sub


    Public Sub guardarPermiso()
        Dim ModulosNegocios As New Framework.Negocios.ModulosBU
        Dim usuario As String = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid.ToString
        Dim tipoPermiso As String = ""
        If (rdoSiPermiso.Checked = True) Then
            tipoPermiso = "1"
        ElseIf (rdoNoPermiso.Checked = True) Then
            tipoPermiso = "2"
        End If

        'Dim idUsuarioEL As String = cmbUsuarios.SelectedValue.ToString
        ModulosNegocios.EliminarPermisosPorUsuario(idUsuarioArbol, tipoPermiso)
        Dim n As TreeNode
        Dim aNode As TreeNode
        Dim aNode1 As TreeNode
        Dim aNode2 As TreeNode
        'Dim idUsuario As String = cmbUsuarios.SelectedValue.ToString
        For Each n In ArbolModulos.Nodes
            If (n.Checked = True) Then
                For Each aNode In n.Nodes
                    If (aNode.Checked = True) Then
                        If (tipoPermiso = "1") Then
                            ModulosNegocios.RegistrarUsuarioPermisoPadre(idUsuarioArbol, CStr(n.Tag), CStr(aNode.Tag), "READ", usuario, tipoPermiso)
                        End If

                        For Each aNode1 In aNode.Nodes
                            If (aNode1.Checked = True) Then
                                For Each aNode2 In aNode1.Nodes
                                    If (aNode2.Checked = True) Then
                                        ModulosNegocios.RegistrarUsuarioPermisoHijoDos(idUsuarioArbol, CStr(n.Tag), CStr(aNode.Tag), CStr(aNode1.Tag), CStr(aNode2.Tag), usuario, tipoPermiso)
                                    End If
                                Next
                            End If
                        Next
                    End If
        Next
            End If
        Next
    End Sub

    'Public Function validaVacio() As Boolean
    '    'If (cmbUsuarios.SelectedIndex.Equals(-1)) Then
    '    '    Return False
    '    'End If
    '    Dim idUs As String = cmbUsuarios.SelectedValue.ToString
    '    If (idUs = Nothing) Then
    '        Return False
    '    End If
    '    Return True
    'End Function

    Private Sub AltaPermisoEspecialForm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.Dispose()
    End Sub


    Private Sub AltaPermisoEspecialForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        rdoSiPermiso.Checked = True
        lblNombreUsuario.Text = nombreUsuario
        LlenarNodosModulos(idUsuarioArbol)
    End Sub


    Private Sub ArbolModulos_AfterCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles ArbolModulos.AfterCheck
        If e.Node.Level = 1 Then
            e.Node.Parent.Checked = True
        End If
        If e.Node.Level = 2 Then
            e.Node.Parent.Checked = True
        End If
        If e.Node.Level = 3 Then
            e.Node.Parent.Checked = True
        End If
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        ''If (validaVacio() = False) Then
        'Dim mensaje As New AdvertenciaForm
        'mensaje.mensaje = "Debe seleccionar un empleado."
        'mensaje.ShowDialog()
        'Else
        If MsgBox("¿Esta seguro de guardar cambios?" + Chr(13), vbYesNo, "") = vbYes Then
            guardarPermiso()
            Dim mensaje As New ExitoForm
            mensaje.mensaje = "El registro se realizó con éxito."
            mensaje.ShowDialog()
        Else
        End If
        'End If
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Dispose()
    End Sub

    Private Sub rdoSiPermiso_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoSiPermiso.CheckedChanged
        LlenarNodosModulos(idUsuarioArbol)
    End Sub

    Private Sub rdoNoPermiso_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoNoPermiso.CheckedChanged
        LlenarNodosModulos(idUsuarioArbol)
    End Sub

End Class