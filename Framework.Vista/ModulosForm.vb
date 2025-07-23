Imports Framework.Negocios

Public Class ModulosForm

	Private Sub ModulosForm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

		If (PermisosUsuarioBU.ConsultarPermiso("FWK_MODULOS", "WRITE")) Then
			btnAgregar.Visible = True
			lblAltas.Visible = True
		Else
			btnAgregar.Visible = False
			lblAltas.Visible = False
		End If
	End Sub
End Class