Imports Entidades
Imports Framework.Negocios
Imports System.Reflection


Public Class MainForm

	Private Sub MainForm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load


	End Sub

	Private Sub MenuClick(ByVal sender As Object,
	ByVal e As System.EventArgs)
		Dim NombreForma As String
		NombreForma = Me.buscarComponente(sender.ToString)
		Try
			Me.AbrirForma(NombreForma)
		Catch
			MsgBox("Forma bajo construccion", MsgBoxStyle.Exclamation, "Technical Error")
		End Try
	End Sub

	Private Function buscarComponente(ByVal NombreForma As String) As String
		Dim objModulosBU As New ModulosBU
		Return objModulosBU.BuscarComponente(NombreForma)

	End Function

	Private Sub AbrirForma(ByVal objectName As String)
		Dim objForm As Form

		Dim t As Type = Type.GetType(objectName) ', True, True)
		If t Is Nothing Then
			Dim Fullname As String = objectName
			t = Type.GetType(Fullname, True, True)
		End If
		objForm = CType(Activator.CreateInstance(t), Form)
		objForm.MdiParent = Me
		Me.LayoutMdi(System.Windows.Forms.MdiLayout.Cascade)

		objForm.Show()
	End Sub

	Private Sub Salir(ByVal sender As Object,
 ByVal e As System.EventArgs)
		Application.Exit()
	End Sub
End Class