Imports Framework.Negocios
Imports Entidades

Public Class Site1
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ObjModulosBU As New ModulosBU
        Dim Nivel1 As New List(Of Modulos)
        Dim usuario As New Entidades.Usuarios
        usuario = System.Web.HttpContext.Current.Session("sessionUsuario")
        If IsNothing(usuario) Then
            Response.Redirect("../../Default.aspx", True)
        Else


            Nivel1 = ObjModulosBU.menu(usuario.PUserUsuarioid)
            menu.Items.Clear()
            For Each Modulo As Modulos In Nivel1
                If Modulo.PModuloWeb = True Then
                    Dim MenuItem As New MenuItem(Modulo.PNombre)

                    ''            MenuItem.ChildItems.Add
                    Try
                        'MenuItem.Image = CType(My.Resources.ResourceManager.GetObject(Modulo.PIcono), Image)
                    Catch
                    End Try
                    'Busca los hijos del menu principal

                    Dim Nivel2 As New List(Of Modulos)
                    Nivel2 = ObjModulosBU.ChildModules(Modulo.PModuloid, usuario.PUserUsuarioid)
                    For Each SubModulo As Modulos In Nivel2
                        If SubModulo.PModuloWeb = True Then
                            Dim SubMenuItem As New MenuItem(SubModulo.PNombre)
                            Try
                                'SubMenuItem.Image = CType(My.Resources.ResourceManager.GetObject(SubModulo.PIcono), Image)
                            Catch
                            End Try
                            'Busca los hijos del submenu
                            Dim Nivel3 As New List(Of Modulos)
                            Nivel3 = ObjModulosBU.ChildModules(SubModulo.PModuloid, usuario.PUserUsuarioid)
                            For Each ChildModulo As Modulos In Nivel3
                                If ChildModulo.PModuloWeb = True Then
                                    Dim ChildMenuItem As New MenuItem(ChildModulo.PNombre)
                                    'ChildMenuItem.ImageUrl
                                    ChildMenuItem.NavigateUrl = (ChildModulo.PComponenteWeb)
                                    'Dim ChildMenuItem As New ToolStripMenuItem(ChildModulo.PNombre)
                                    Try
                                        'ChildMenuItem.Image = CType(My.Resources.ResourceManager.GetObject(ChildModulo.PIcono), Image)
                                    Catch ex As Exception
                                    End Try

                                    SubMenuItem.ChildItems.Add(ChildMenuItem)
                                End If
                            Next

                            MenuItem.ChildItems.Add(SubMenuItem) 'Agrega hijos

                        End If
                    Next

                    menu.Items.Add(MenuItem) 'Agrega padres
                End If

            Next
        End If
    End Sub

    Protected Sub menu_MenuItemClick(sender As Object, e As MenuEventArgs) Handles menu.MenuItemClick

    End Sub
End Class