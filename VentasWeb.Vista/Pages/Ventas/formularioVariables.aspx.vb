Imports Ventas.Negocios.VentasSicyBU

Public Class formularioVariables

    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Public Sub MetodoSusana(ByVal filas As String)
      
    End Sub

    Protected Sub btnGenerarConsulta_Click(sender As Object, e As EventArgs) Handles btnGenerarConsulta.Click

        Dim filas As String = Request.Form("txtFilas")
        Dim columnas As String = Request.Form("txtColumnas")
        Dim fechaUno As String = Request.Form("AbrirCalendarioFechaUno")
        Dim fechaDos As String = Request.Form("AbrirCalendarioFechaDos")
        Dim agentes As String = Request.Form("cmbAgente")
        Dim clientes As String = Request.Form("txtClienteSeleccionado")
        Dim modelos As String = Request.Params("txtModeloSeleccionado")
        Dim descripcion As String = Request.Params("txtDescripcionSeleccionado")
        Dim marcas As String = Request.Form("cmbMarcas")
        Dim colecciones As String = Request.Params("txtColeccionesSeleccion")
        Dim categorias As String = Request.Form("cmbTipoCategoria")
        Dim corridas As String = Request.Params("txtCorridasSeleccion")
        Dim familias As String = Request.Form("cmbFamilias")
        Dim clasificacion As String = Request.Form("cmbClasificacion")

        Dim agenteRdo As String = Request.Form("radiosAgente")
        Dim clienteRdo As String = Request.Form("radiosCliente")
        Dim modeloRdo As String = Request.Form("radiosModelos")
        Dim marcaRdo As String = Request.Form("radiosMarcas")
        Dim coleccioneRdo As String = Request.Form("radiosColeccion")
        Dim categoriaRdo As String = Request.Form("radiosCategoria")
        Dim corridaRdo As String = Request.Form("radiosCorrida")
        Dim familiasRdo As String = Request.Form("radiosFamilia")
        Dim clasificacionRdo As String = Request.Form("radiosClasificacion")
        Dim descripcionRdo As String = Request.Form("radiosDescripcion")
        Dim operaciones As String = Request.Form("txtOperaciones")
        Dim categoria As String = Request.Form("cmbTipoCategoria")

        Dim objFormularioVariables As New Ventas.Negocios.VentasSicyBU
        Dim dt As New DataTable
        dt = objFormularioVariables.enviarParametrosConsulta(filas, columnas, fechaUno, fechaDos, clasificacion, clientes, agentes, marcas,
        colecciones, modelos, descripcion, corridas, familias, categoria, agenteRdo, clienteRdo, modeloRdo,
        marcaRdo, coleccioneRdo, categoriaRdo, corridaRdo, familiasRdo, clasificacionRdo, descripcionRdo, operaciones)

        Session("datos") = dt
        Response.Redirect("~/Pages/Ventas/dashboard.aspx")

    End Sub
End Class