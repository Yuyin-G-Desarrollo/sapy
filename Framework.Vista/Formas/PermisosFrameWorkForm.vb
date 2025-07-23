Imports System.Data.SqlClient
Imports Framework.Negocios

Public Class PermisosFrameWorkForm
    Dim ForUno As Int32
    Dim ForDos As Int32
    Dim NombrePerfil As String
    Dim idDepartamento As Int32 = 0
    Dim idUsuario As String = ""
    Dim idPerfil As String = ""
    Dim perfil As String = ""
    Dim nombreUsuario As String = ""
    Public Sub LlenarNodosModulos(ByVal idPerfil As String)
        Dim FrameworNegocios As New Framework.Negocios.ModulosBU
        Dim dtTablaModulosPrincipales As New DataTable
        Dim dtModulosHijos As New DataTable
        Dim dtModulosHijosUltimos As New DataTable
        Dim filaModPadre As DataRow
        'NombrePerfil = Destalle
        ArbolModulos.CheckBoxes = True
        Dim recorreNieto As Int32 = 1
        'Dim kPadre As String = "Padre"
        'Dim kHijo As String = "Hijo"
        'Dim kNieto As String = "kNieto"
        Dim recorrepp As Int32 = 0
        Dim recorreHijo As Int32 = 0


        dtTablaModulosPrincipales = FrameworNegocios.VerModulosPadres
        ArbolModulos.Nodes.Clear()
        '-----------------------------------------------
        For Each filaModPadre In dtTablaModulosPrincipales.Rows
            Dim dtTablaDetalle As New DataTable
            Dim NodoModulo As TreeNode
            NodoModulo = New TreeNode(CStr(filaModPadre.Item(1)).ToUpper)
            NodoModulo.Tag = CStr(filaModPadre.Item(0))

            Dim FilaDetallePadre As DataRow
            dtTablaDetalle = FrameworNegocios.VerModulosPerfil(idPerfil)
            ArbolModulos.Nodes.Add(NodoModulo)

            For Each FilaDetallePadre In dtTablaDetalle.Rows

                If (FilaDetallePadre.Item(0).Equals(filaModPadre.Item(0))) Then
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
                Dim dtTablaDetalleHijo1 As New DataTable
                Dim FilaDetalleHijo1 As DataRow
                childnode = New TreeNode(CStr(childrow.Item(1)).ToUpper)
                childnode.Tag = CStr(childrow.Item(0))
                'childnode.ForeColor = Color.DarkGoldenrod

                Dim DetalleHijo1 As String = CStr(childrow.Item(1)).ToString
                dtTablaDetalleHijo1 = FrameworNegocios.VerDetallesModulosHijos(idPerfil, filaModPadre.Item(0).ToString)
                NodoModulo.Nodes.Add(childnode)

                For Each FilaDetalleHijo1 In dtTablaDetalleHijo1.Rows

                    If (FilaDetalleHijo1.Item(0).Equals(childrow.Item(0))) Then
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
                    Dim dtTablaDetalleHijo2 As New DataTable
                    Dim FilaDetalleHijo2 As DataRow
                    childnode2 = New TreeNode(CStr(childrow2.Item(1)).ToUpper)
                    childnode2.Tag = CStr(childrow2.Item(0))
                    'childnode2.ForeColor = Color.DarkKhaki

                    childnode.Nodes.Add(childnode2)

                    dtTablaDetalleHijo2 = FrameworNegocios.VerDetalleHijoPrevioAccion(idPerfil, childrow.Item(0).ToString, filaModPadre.Item(0).ToString, childrow2.Item(0).ToString)

                    For Each FilaDetalleHijo2 In dtTablaDetalleHijo2.Rows
                        If (FilaDetalleHijo2.Item(0).Equals(childrow2.Item(0))) Then
                            childnode.Nodes(recorreNieto).Checked = True
                        End If
                    Next
                    Dim childrow3 As DataRow
                    Dim childnode3 As TreeNode
                    Dim dtAcciones As New DataTable
                    Dim FilaDetalleNieto1 As DataRow
                    Dim dtNietosSeleccionados As New DataTable
                    dtAcciones = FrameworNegocios.verAccionesModulos(CStr(childnode2.Tag), CStr(childnode.Tag), CStr(NodoModulo.Tag))
                    '-----------------------------------------------------
                    Dim recorreAccion As Int32 = 0
                    For Each childrow3 In dtAcciones.Rows
                        childnode3 = New TreeNode(childrow3.Item(1).ToString.ToUpper)
                        childnode3.Tag = childrow3.Item(0)
                        'childnode3.ForeColor = Color.Cornsilk

                        childnode2.Nodes.Add(childnode3)
                        dtNietosSeleccionados = FrameworNegocios.VerAccionMooduloSeleccionado(idPerfil, childrow.Item(0).ToString, filaModPadre.Item(0).ToString, childrow2.Item(0).ToString, childrow3.Item(0).ToString)
                        For Each FilaDetalleNieto1 In dtNietosSeleccionados.Rows
                            If (FilaDetalleNieto1.Item(0).ToString.Equals(childrow3.Item(0).ToString)) Then
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

    'Public Sub llenarComboGrupos()
    '    Dim objPerfil As New Framework.Negocios.PerfilesBU
    '    Dim dtGrupos As DataTable
    '    dtGrupos = objPerfil.verGrupos()
    '    dtGrupos.Rows.InsertAt(dtGrupos.NewRow, 0)
    '    cmbDepartamento.DataSource = dtGrupos
    '    cmbDepartamento.DisplayMember = "grup_name"
    '    cmbDepartamento.ValueMember = "grup_grupoid"
    'End Sub


    Public Function validaVacioPerfil() As Boolean
        'Dim cmper As String = cmbDepartamento.SelectedValue.ToString
        If (txtPerfilNuevo.Text = Nothing) Then
            lblPerfil.ForeColor = Color.Red
            Return False
        Else
            lblPerfil.ForeColor = Color.Black
        End If
        Return True
    End Function

    Public Sub guardarPerfilNuevo()
        'Dim idGrupo As Int32
        Dim objPerfil As New Framework.Negocios.PerfilesBU
        Dim entidadPerfil As New Entidades.Perfiles
        Dim dtPerfilValida As DataTable
        Dim nomPerfil As String = txtPerfilNuevo.Text
        dtPerfilValida = objPerfil.ValidarPerfilNuevo(nomPerfil)
        Dim contadorValida As Int32 = Convert.ToInt32(dtPerfilValida.Rows(0)(0).ToString)
        'idGrupo = Convert.ToInt32(cmbDepartamento.SelectedValue.ToString)
        entidadPerfil.PActivo = True
        entidadPerfil.PNombre = nomPerfil
        entidadPerfil.PDepartamento = 1

        If (contadorValida = 0) Then
            If MsgBox("¿Esta seguro de guardar cambios?" + Chr(13), vbYesNo, "") = vbYes Then
                objPerfil.guardarPerfil(entidadPerfil)
                Dim mensaje As New ExitoForm
                mensaje.mensaje = "El registro se realizó con éxito."
                mensaje.ShowDialog()
            Else
            End If
        ElseIf (contadorValida >= 1) Then
            MsgBox("El perfil: " + nomPerfil + " ya existe")
        End If
    End Sub

    Public Sub LlenarArbolUsuarios()
        Dim FrameworNegocios As New Framework.Negocios.ModulosBU
        Dim dtPerfilesActivos As New DataTable
        Dim dtUsuariosHijos As New DataTable
        Dim dtModulosHijosUltimos As New DataTable
        Dim filaPerfilPadre As DataRow
        Dim recorrePadre As Int32 = 0
        Dim recorreHijo As Int32 = 0
        Dim recorreNieto As Int32 = 0
        dtPerfilesActivos = FrameworNegocios.VerPerfilesActivos
        ArbolModulos.Nodes.Clear()
        ' ''---
        For Each filaPerfilPadre In dtPerfilesActivos.Rows
            Dim NodoPerfil As TreeNode

            NodoPerfil = New TreeNode(CStr(filaPerfilPadre.Item(1)).ToUpper)
            NodoPerfil.Tag = filaPerfilPadre.Item(0)
            ArbolUsuarios.Nodes.Add(NodoPerfil)

            dtUsuariosHijos = FrameworNegocios.VerUsuariosHijosPerfil(CStr(filaPerfilPadre.Item(0)))

            Dim HijoFila As DataRow
            Dim HijoNodo As TreeNode
            HijoNodo = New TreeNode()
            '' ''---
            For Each HijoFila In dtUsuariosHijos.Rows

                'HijoNodo = New TreeNode(CStr(HijoFila.Item(1)) + " (" + CStr(HijoFila.Item(2)) + ")")
                'NodoPerfil.Nodes.Add(HijoNodo)

                'HijoNodo.Name = CStr(HijoFila.Item(1)) + " (" + CStr(HijoFila.Item(2)) + ")"
                'HijoNodo.Text.Clone  = CStr(HijoFila.Item(1)) + " (" + CStr(HijoFila.Item(2)) + ")"
                HijoNodo = New TreeNode(CStr(HijoFila.Item(1)).ToUpper + " (" + CStr(HijoFila.Item(2)).ToUpper + ")")
                HijoNodo.Tag = CStr(HijoFila.Item(0))
                NodoPerfil.Nodes.Add(HijoNodo)


            Next HijoFila
            recorrePadre = recorrePadre + 1
        Next
        'ArbolUsuarios.SelectedNode = ArbolUsuarios.Nodes(0)
        'ArbolUsuarios.Select()
    End Sub

    Private Sub PrintRecursive(ByVal n As TreeNode)

        If (n.Checked = True) Then
        End If
        Dim aNode As TreeNode
        For Each aNode In n.Nodes
            PrintRecursive(aNode)
        Next
    End Sub
    Private Sub CallRecursive(ByVal aTreeView As TreeView)
        Dim n As TreeNode
        For Each n In aTreeView.Nodes
            PrintRecursive(n)
        Next
    End Sub

    Public Sub guardarPermiso()
        Dim ModulosNegocios As New Framework.Negocios.ModulosBU
        Dim usuario As String = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid.ToString
        'Dim dtIdPerfil As DataTable = ModulosNegocios.VeridPerfil(NombrePerfil)
        'Dim idPerfil As String = dtIdPerfil.Rows(0)(0).ToString
        Dim dtTablaAccionesPorPerfil As DataTable = ModulosNegocios.VerModulosAccionPorPerfil(idPerfil)
        ModulosNegocios.eliminarPermisoPerfil(idPerfil)
        Dim nodePerfil As TreeNode = ArbolUsuarios.SelectedNode
        'Dim perfil As String = nodePerfil.Text
        Dim n As TreeNode
        Dim aNode As TreeNode
        Dim aNode1 As TreeNode
        Dim aNode2 As TreeNode
        For Each n In ArbolModulos.Nodes
            If (n.Checked = True) Then
                For Each aNode In n.Nodes
                    If (aNode.Checked = True) Then
                        ModulosNegocios.RegistrarPerfilPermisoPadre(idPerfil, CStr(n.Tag), CStr(aNode.Tag), "READ", usuario)
                        '-------------------------------- ultimo nodo y acciones
                        For Each aNode1 In aNode.Nodes
                            If (aNode1.Checked = True) Then
                                For Each aNode2 In aNode1.Nodes
                                    If (aNode2.Checked = True) Then
                                        ModulosNegocios.RegistrarPerfilPermisoHijoDos(idPerfil, CStr(aNode1.Tag), CStr(aNode.Tag), CStr(n.Tag), CStr(aNode2.Tag), usuario)
                                    End If
                                Next
                            End If
                        Next
                    End If
                Next
            End If
        Next
    End Sub

    Public Sub seleccionarModulo()
        Dim nodoModulo As TreeNode
        Dim objEdMod As New EditarModuloArbolForm
        nodoModulo = ArbolModulos.SelectedNode
        If (nodoModulo.Level = 0) Then
            objEdMod.idModulo = CInt(ArbolModulos.SelectedNode.Tag)
            objEdMod.ShowDialog()

        ElseIf (nodoModulo.Level = 1) Then
            objEdMod.idModulo = CInt(ArbolModulos.SelectedNode.Tag)
            objEdMod.idModSuperiorArbol = CStr(ArbolModulos.SelectedNode.Parent.Tag)
            objEdMod.ShowDialog()

        ElseIf (nodoModulo.Level = 2) Then
            objEdMod.idModulo = CInt(ArbolModulos.SelectedNode.Tag)
            objEdMod.idModSuperiorArbol = CStr(ArbolModulos.SelectedNode.Parent.Tag)
            objEdMod.ShowDialog()
        End If
        
    End Sub

    Public Sub seleccionarModuloAltas()
        Dim objAltaMod As New ALtaModuloArbolForm
        objAltaMod.idModuloSuperiorArbol = CStr(ArbolModulos.SelectedNode.Tag)
        objAltaMod.ShowDialog()

        ArbolUsuarios.SelectedNode = Nothing
    End Sub


    Public Function ValidarVacioPermiso() As Boolean
        If (NombrePerfil = Nothing Or NombrePerfil = "0" Or ArbolUsuarios.SelectedNode Is Nothing) Then
            Return False
        End If
        Return True
    End Function

    Public Function ValidarRepetidosModulos(ByVal modulo As String, ByVal moduloSuperior As String, ByVal moduloSuperiorPadre As String, ByVal accionModulo As String) As Boolean
        Dim objModBu As New ModulosBU
        Dim dtContenidoConsultaExistencia As DataTable
        Dim contExisteModulo As Int32 = 0
        dtContenidoConsultaExistencia = objModBu.validarExistenciaModulos(modulo, moduloSuperior, moduloSuperiorPadre, accionModulo)
        contExisteModulo = Convert.ToInt32(dtContenidoConsultaExistencia.Rows(0)(0).ToString)
        If (contExisteModulo >= 1) Then
            Return False
        End If
        Return True
    End Function

    Private Sub PermisosFrameWorkForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Location = New Point(0, 0)
        rdoActivo.Checked = True
        LlenarArbolUsuarios()
        'llenarComboGrupos()
        LlenarNodosModulos("0")
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CallRecursive(ArbolModulos)
    End Sub

    Private Sub ArbolUsuarios_AfterCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles ArbolUsuarios.AfterCheck
        If e.Node.Checked Then
            If e.Node.Level = 2 Then

                For Each node As TreeNode In e.Node.Parent.Nodes
                    If node IsNot e.Node Then
                        node.Checked = False
                    End If
                Next
            Else
                e.Node.Checked = False
            End If
        End If
    End Sub

    Private Sub ArbolUsuarios_AfterSelect(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles ArbolUsuarios.AfterSelect
        If (e.Node.Level = 3) Then
            ArbolModulos.SelectedNode = Nothing
        Else
            'If e.Node.Level = 1 Then
            '    LlenarNodosModulos(e.Node.Parent.Text)
            'Else
            '    LlenarNodosModulos(e.Node.Text)
            'End If
            NombrePerfil = idPerfil
            LlenarNodosModulos(idPerfil)
        End If
    End Sub

    Private Sub ArbolUsuarios_BeforeSelect(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewCancelEventArgs) Handles ArbolUsuarios.BeforeSelect
        If ArbolUsuarios.SelectedNode IsNot Nothing Then
            MakeSelected(ArbolUsuarios.SelectedNode, False)
        End If
        MakeSelected(e.Node, True)

    End Sub

    Private Sub MakeSelected(ByVal node As TreeNode, ByVal selected As Boolean)
        Dim SelectedFont As New Font(ArbolUsuarios.Font, FontStyle.Bold)
        node.NodeFont = CType(IIf(selected, SelectedFont, ArbolUsuarios.Font), Drawing.Font)
        node.ForeColor = CType(IIf(selected, Color.RoyalBlue, ArbolUsuarios.ForeColor), Color)
        If node.Parent IsNot Nothing Then
            idUsuario = CStr(node.Tag)
            nombreUsuario = CStr(node.Text)
            MakeSelected(node.Parent, selected)

            idPerfil = CStr(node.Parent.Tag)
            perfil = node.Parent.Text
        ElseIf node.Parent Is Nothing Then
            idPerfil = CStr(node.Tag)
            perfil = node.Text
        End If

    End Sub

    Private Sub MakeSelectedModulos(ByVal node As TreeNode, ByVal selected As Boolean)
        If (node.Level = 0 Or node.Level = 1 Or node.Level = 2) Then
            Dim SelectedFont As New Font(ArbolModulos.Font, FontStyle.Bold)
            node.NodeFont = CType(IIf(selected, SelectedFont, ArbolModulos.Font), Drawing.Font)
            node.ForeColor = CType(IIf(selected, Color.RoyalBlue, ArbolModulos.ForeColor), Color)
            'If node.Parent IsNot Nothing Then
            '    MakeSelectedModulos(node.Parent, selected)
            'End If
        End If
    End Sub

    Private Sub ArbolModulos_AfterCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles ArbolModulos.AfterCheck
        Dim cont As Int32 = 0

        For Each nodo As TreeNode In e.Node.Nodes
            If (nodo.Checked = True) Then
                cont = cont + 1
            End If
            For Each nodo1 As TreeNode In nodo.Nodes
                If (nodo1.Checked = True) Then
                    cont = cont + 1
                End If
                For Each nodo2 As TreeNode In nodo1.Nodes
                    If (nodo2.Checked = True) Then
                        cont = cont + 1
                    End If

                    For Each nodo3 As TreeNode In nodo2.Nodes
                        If (nodo3.Checked = True) Then
                            cont = cont + 1
                        End If
                    Next
                Next
            Next
        Next

        If (cont = 0) Then
            If (e.Node.Level = 0 And e.Node.Checked = True) Then
                For Each nodoHijoUno As TreeNode In e.Node.Nodes
                    'nodoHijoUno.Checked = True
                    For Each nodoHijoDos As TreeNode In nodoHijoUno.Nodes
                        nodoHijoDos.Checked = True
                        For Each nodoHijoTres As TreeNode In nodoHijoDos.Nodes
                            nodoHijoTres.Checked = True
                        Next
                    Next
                Next
            End If
        End If

        If e.Node.Level = 1 And e.Node.Checked = True Then
            e.Node.Parent.Checked = True
            'For Each nd As TreeNode In e.Node.Nodes
            '    nd.Checked = True
            'Next
        ElseIf e.Node.Level = 1 And e.Node.Checked = False Then
            For Each nd As TreeNode In e.Node.Nodes
                nd.Checked = False
            Next

        ElseIf e.Node.Level = 2 And e.Node.Checked = True Then
            e.Node.Parent.Checked = True
            'For Each nd2 As TreeNode In e.Node.Nodes
            '    nd2.Checked = True
            'Next
        ElseIf e.Node.Level = 2 And e.Node.Checked = False Then
            For Each nd2 As TreeNode In e.Node.Nodes
                nd2.Checked = False
            Next

        ElseIf e.Node.Level = 3 And e.Node.Checked = True Then
            e.Node.Parent.Checked = True


        ElseIf (e.Node.Level = 0 And e.Node.Checked = False) Then
            For Each nodoHijoUno As TreeNode In e.Node.Nodes
                nodoHijoUno.Checked = False
                For Each nodoHijoDos As TreeNode In nodoHijoUno.Nodes
                    nodoHijoDos.Checked = False
                    For Each nodoHijoTres As TreeNode In nodoHijoDos.Nodes
                        nodoHijoTres.Checked = False
                    Next
                Next
            Next
        End If

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If (ValidarVacioPermiso() = True) Then
            If MsgBox("¿Esta seguro de guardar cambios?" + Chr(13), vbYesNo, "") = vbYes Then
                guardarPermiso()
                Dim mensaje As New ExitoForm
                mensaje.mensaje = "El registro se realizó con éxito."
                mensaje.ShowDialog()
            Else
            End If
        ElseIf (ValidarVacioPermiso() = False) Then
            Dim advMensaje As New AdvertenciaForm
            advMensaje.mensaje = "Debe seleccionar un perfil."
            advMensaje.ShowDialog()
        End If
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub btnPermisoEspecial_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPermisoEspecial.Click
        Dim perEspecial As New AltaPermisoEspecialForm
        If (idUsuario <> "") Then
            perEspecial.idUsuarioArbol = idUsuario
            perEspecial.nombreUsuario = nombreUsuario
            perEspecial.ShowDialog()

        Else
            MsgBox("Debe seleccionar un usuario.")
        End If

    End Sub

    Private Sub btnEditarModulo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditarModulo.Click
        If (ArbolModulos.SelectedNode IsNot Nothing) Then
            seleccionarModulo()
            'LlenarNodosModulos("0")
            ArbolUsuarios.SelectedNode = Nothing
        Else
            MsgBox("Debe seleccionar un modulo.")
        End If
    End Sub

    Private Sub btnAgregaPerfil_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregaPerfil.Click

        If (validaVacioPerfil() = True) Then
            guardarPerfilNuevo()
            ArbolUsuarios.Nodes.Clear()
            txtPerfilNuevo.Text = String.Empty
            LlenarArbolUsuarios()
            'llenarComboGrupos()
        ElseIf (validaVacioPerfil() = False) Then
            Dim AdvMensaje As New AdvertenciaForm
            AdvMensaje.mensaje = "Debe completar los datos de perfil."
            AdvMensaje.ShowDialog()
        Else
        End If
    End Sub

    Private Sub txtPerfilNuevo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPerfilNuevo.KeyPress
        Dim caracter As Char = e.KeyChar
        If (txtPerfilNuevo.Text.Length < 50) Then

            If (Char.IsLetterOrDigit(e.KeyChar)) Or (caracter = ChrW(Keys.Back)) Or (caracter = ChrW(Keys.Space) Or (caracter = "/")) Then
                e.Handled = False
            Else
                e.Handled = True
            End If

            If Char.IsLower(e.KeyChar) Then
                txtPerfilNuevo.SelectedText = Char.ToUpper(e.KeyChar)
                e.Handled = True
            End If
        Else
            If e.KeyChar <> vbBack Then
                e.Handled = True
            End If
        End If
    End Sub



    Private Sub ArbolModulos_BeforeSelect(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewCancelEventArgs) Handles ArbolModulos.BeforeSelect
        If ArbolModulos.SelectedNode IsNot Nothing Then
            MakeSelectedModulos(ArbolModulos.SelectedNode, False)
        End If
        MakeSelectedModulos(e.Node, True)
    End Sub

    'Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If ArbolModulos.SelectedNode IsNot Nothing Then
    '        'MakeSelectedModulos(ArbolModulos.SelectedNode, False)
    '        MsgBox("Si que si")
    '    Else
    '        MsgBox("No hay nada seleccionado")
    '    End If
    'End Sub

    Private Sub btnAltaModulo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAltaModulo.Click
        If (ArbolModulos.SelectedNode IsNot Nothing) Then
            seleccionarModuloAltas()
        Else
            Dim objAlMod As New ALtaModuloArbolForm
            objAlMod.ShowDialog()
            'LlenarNodosModulos("0")
            ArbolUsuarios.SelectedNode = Nothing
        End If

    End Sub





    Private Sub btnActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActualizar.Click
        LlenarNodosModulos("0")
        idPerfil = String.Empty
    End Sub

    Private Sub btnAltaUsuario_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAltaUsuario.Click
        'MsgBox("Usuario::: " + idUsuario + "     Perfil::: " + idPerfil)
        Dim objAltaUsuario As New AltaUsuarioForm
        objAltaUsuario.ShowDialog()
        ArbolUsuarios.Nodes.Clear()
        ArbolModulos.Nodes.Clear()
        LlenarArbolUsuarios()
        LlenarNodosModulos("0")
        idPerfil = String.Empty
        idUsuario = String.Empty
    End Sub




    Private Sub ArbolUsuarios_NodeMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles ArbolUsuarios.NodeMouseDoubleClick
        If (e.Node.Level = 1) Then
            'MsgBox("Tag: " + e.Node.Tag + "                Nodo " + e.Node.Text)
            Dim objEditUser As New EditarUsuarioArbolForm
            objEditUser.idUsuario = CInt(e.Node.Tag)
            objEditUser.ShowDialog()
            ArbolUsuarios.Nodes.Clear()
            LlenarArbolUsuarios()
            LlenarNodosModulos("0")
        End If
    End Sub

    Private Sub bntReplicarUsuario_Click(sender As Object, e As EventArgs)
        'MsgBox("Usuario::: " + idUsuario + "     Perfil::: " + idPerfil)
        Dim objAltaUsuario As New ReplicaPermisosForm
        objAltaUsuario.ShowDialog()
        ArbolUsuarios.Nodes.Clear()
        ArbolModulos.Nodes.Clear()
        LlenarArbolUsuarios()
        LlenarNodosModulos("0")
        idPerfil = String.Empty
        idUsuario = String.Empty
    End Sub

    Private Sub bntReplicarPermisos_Click(sender As Object, e As EventArgs) Handles bntReplicarPermisos.Click
        'MsgBox("Usuario::: " + idUsuario + "     Perfil::: " + idPerfil)
        Dim objReplicaPermisos As New ReplicaPermisosForm
        objReplicaPermisos.ShowDialog()
        ArbolUsuarios.Nodes.Clear()
        ArbolModulos.Nodes.Clear()
        LlenarArbolUsuarios()
        LlenarNodosModulos("0")
        idPerfil = String.Empty
        idUsuario = String.Empty
    End Sub
End Class