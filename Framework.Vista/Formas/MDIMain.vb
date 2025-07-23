Imports System.Windows.Forms
Imports Framework.Negocios
Imports Entidades
Imports System.Reflection

Public Class MDIMain

    'Private Sub ShowNewForm(ByVal sender As Object, ByVal e As EventArgs)
    '    ' Cree una nueva instancia del formulario secundario.
    '    Dim ChildForm As New System.Windows.Forms.Form
    '    ' Conviértalo en un elemento secundario de este formulario MDI antes de mostrarlo.
    '    ChildForm.MdiParent = Me

    '    m_ChildFormNumber += 1
    '    ChildForm.Text = "Ventana " & m_ChildFormNumber

    '    ChildForm.Show()
    'End Sub

    'Private Sub OpenFile(ByVal sender As Object, ByVal e As EventArgs)
    '    Dim OpenFileDialog As New OpenFileDialog
    '    OpenFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
    '    OpenFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*"
    '    If (OpenFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
    '        Dim FileName As String = OpenFileDialog.FileName
    '        ' TODO: agregue código aquí para abrir el archivo.
    '    End If
    'End Sub

    'Private Sub SaveAsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
    '    Dim SaveFileDialog As New SaveFileDialog
    '    SaveFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
    '    SaveFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*"

    '    If (SaveFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
    '        Dim FileName As String = SaveFileDialog.FileName
    '        ' TODO: agregue código aquí para guardar el contenido actual del formulario en un archivo.
    '    End If
    'End Sub


    'Private Sub ExitToolsStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
    '    Me.Close()
    'End Sub

    'Private Sub CutToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
    '    ' Utilice My.Computer.Clipboard para insertar el texto o las imágenes seleccionadas en el Portapapeles
    'End Sub

    'Private Sub CopyToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
    '    ' Utilice My.Computer.Clipboard para insertar el texto o las imágenes seleccionadas en el Portapapeles
    'End Sub

    'Private Sub PasteToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
    '    'Utilice My.Computer.Clipboard.GetText() o My.Computer.Clipboard.GetData para recuperar la información del Portapapeles.
    'End Sub


    'Private Sub CascadeToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
    '    Me.LayoutMdi(MdiLayout.Cascade)
    'End Sub

    'Private Sub TileVerticalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
    '    Me.LayoutMdi(MdiLayout.TileVertical)
    'End Sub

    'Private Sub TileHorizontalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
    '    Me.LayoutMdi(MdiLayout.TileHorizontal)
    'End Sub

    'Private Sub ArrangeIconsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
    '    Me.LayoutMdi(MdiLayout.ArrangeIcons)
    'End Sub

    'Private Sub CloseAllToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
    '    ' Cierre todos los formularios secundarios del principal.
    '    For Each ChildForm As Form In Me.MdiChildren
    '        ChildForm.Close()
    '    Next
    'End Sub

    Private m_ChildFormNumber As Integer

    Private Sub MDIMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Dim ctl As Control
        'Dim ctlMDI As MdiClient

        '' Loop through all of the form's controls looking
        '' for the control of type MdiClient.
        'For Each ctl In Me.Controls
        '    Try
        '        ' Attempt to cast the control to type MdiClient.
        '        ctlMDI = CType(ctl, MdiClient)

        '        ' Set the BackColor of the MdiClient control.
        '        ctlMDI.BackColor = Me.BackColor

        '    Catch exc As InvalidCastException
        '        ' Catch and ignore the error if casting failed.
        '    End Try
        'Next

        'INICIA CARGA DE MENU
        Dim ObjModulosBU As New ModulosBU
        Dim Nivel1 As New List(Of Modulos)
        Nivel1 = ObjModulosBU.menu("ESCRITORIO")

        For Each Modulo As Modulos In Nivel1
            Dim MenuItem As New ToolStripMenuItem(Modulo.PNombre)
            Try
                MenuItem.Image = CType(My.Resources.ResourceManager.GetObject(Modulo.PIcono), Image)
            Catch
            End Try
            'Busca los hijos del menu principal
            Dim Nivel2 As New List(Of Modulos)
            Nivel2 = ObjModulosBU.ChildModules(Modulo.PModuloid, "ESCRITORIO")
            For Each SubModulo As Modulos In Nivel2
                Dim SubMenuItem As New ToolStripMenuItem(SubModulo.PNombre)
                Try
                    SubMenuItem.Image = CType(My.Resources.ResourceManager.GetObject(SubModulo.PIcono), Image)
                Catch
                End Try
                'Busca los hijos del submenu
                Dim Nivel3 As New List(Of Modulos)
                Nivel3 = ObjModulosBU.ChildModules(SubModulo.PModuloid, "ESCRITORIO")
                For Each ChildModulo As Modulos In Nivel3
                    Dim ChildMenuItem As New ToolStripMenuItem(ChildModulo.PNombre, Nothing, New EventHandler(AddressOf MenuClick))
                    Try
                        ChildMenuItem.Image = CType(My.Resources.ResourceManager.GetObject(ChildModulo.PIcono), Image)
                    Catch ex As Exception
                    End Try

                    SubMenuItem.DropDownItems.Add(ChildMenuItem)
                Next

                MenuItem.DropDownItems.Add(SubMenuItem) 'Agrega hijos
            Next

            mstMenuPrincipal.Items.Add(MenuItem) 'Agrega padres
        Next

        Dim SalirItem As New ToolStripMenuItem("Salir", Nothing, New EventHandler(AddressOf Salir))
        mstMenuPrincipal.Items.Add(SalirItem)
        'TERMINA CARGA DE MENU


    End Sub

    Private Sub MenuClick(ByVal sender As Object,
    ByVal e As System.EventArgs)
        Dim NombreForma As String
        NombreForma = Me.buscarComponente(sender.ToString)
        Try
            Me.AbrirForma(NombreForma)
		Catch ex As Exception
			MsgBox("Forma bajo construccion", MsgBoxStyle.Exclamation, "Technical Error")
        End Try
    End Sub

    Private Function buscarComponente(ByVal NombreForma As String) As String
        Dim objModulosBU As New ModulosBU
        Return objModulosBU.BuscarComponente(NombreForma)

    End Function

    Private Sub AbrirForma(ByVal objectName As String)
        Dim objForm As Form

        Dim s As String = objectName

        Dim words As String() = s.Split(New Char() {"."c})

        ' Use For Each loop over words and display them
        Dim word As String
        Dim count As Int32 = 1
        Dim assemblyName As String = ""
        Dim className As String = ""
        For Each word In words
            If count = 1 Then
                assemblyName = word + "."
            End If
            If count = 2 Then
                assemblyName += word
            End If
            If count = 3 Then
                className = word
            End If
            count += 1
        Next


        Dim t As Type = System.Type.GetType(objectName + "," + assemblyName, True, True)
        'Dim t As Type = System.Type.GetType(objectName, True, True)
            If Not IsNothing(t) Then
            Dim Fullname As String = objectName
            t = Type.GetType(Fullname + "," + assemblyName, True, True)
            End If
            objForm = CType(Activator.CreateInstance(t), Form)
            objForm.MdiParent = Me
            m_ChildFormNumber += 1

            objForm.Show()
    End Sub

    Private Sub Salir(ByVal sender As Object,
    ByVal e As System.EventArgs)
        Application.Exit()
    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        'ConfiguracionColoresForm.Show()
        Dim formacolores As New Tools.ConfiguracionColoresForm
        formacolores.Show()
        '
    End Sub
End Class
