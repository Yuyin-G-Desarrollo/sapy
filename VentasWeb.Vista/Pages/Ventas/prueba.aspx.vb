Imports Programacion.Negocios
Public Class prueba
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lblprueba.Text = "Hola susi"
        Dim objBU As New MarcasBU
        Dim tabla As New DataTable
        tabla = objBU.VerMarcas()
        GridView1.DataSource = tabla
        GridView1.DataBind()
    End Sub


End Class