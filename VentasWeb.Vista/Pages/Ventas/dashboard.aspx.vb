Imports System
Imports System.IO
Imports System.Data
Imports System.Web.UI

Public Class dashboard
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim dt As DataTable = TryCast(Session("datos"), DataTable)
        grdDatosDetalles.DataSource = dt
        grdDatosDetalles.DataBind()

    End Sub


    Protected Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        Try
            'Response.Clear()
            'Response.Buffer = True
            'Response.AddHeader("content-disposition", "attachment;filename=gridviewdata.xls")
            'Response.Charset = ""
            'Response.ContentType = "application/vnd.ms-excel"
            'Dim sWriter As New StringWriter()
            'Dim hWriter As New HtmlTextWriter(sWriter)
            'grdDatosDetalles.RenderControl(hWriter)
            'Response.Output.Write(sWriter.ToString())
            'Response.Flush()
            'Response.End()

            Dim sb As StringBuilder = New StringBuilder()
            Dim sw As StringWriter = New StringWriter(sb)
            Dim htw As HtmlTextWriter = New HtmlTextWriter(sw)
            Dim pagina As Page = New Page
            Dim form = New HtmlForm
            grdDatosDetalles.EnableViewState = False
            pagina.EnableEventValidation = False
            pagina.DesignerInitialize()
            pagina.Controls.Add(form)
            form.Controls.Add(grdDatosDetalles)
            pagina.RenderControl(htw)
            Response.Clear()
            Response.Buffer = True
            Response.ContentType = "application/vnd.ms-excel"
            Response.AddHeader("Content-Disposition", "attachment;filename=ReporteDashboard.xls")
            Response.Charset = "UTF-8"
            Response.ContentEncoding = Encoding.Default
            Response.Write(sb.ToString())
            Response.End()
        
        Catch ex As Exception

        End Try


    End Sub
End Class