Imports System.Data.OleDb
Imports Infragistics.Win.UltraWinGrid

Public Class SuelaGlobalForm
    Dim msjError As New Tools.AdvertenciaForm
    Dim msjExito As New Tools.ExitoForm
    Dim objCargaEquivalenciaBU As New Programacion.Negocios.CargaEquivalenciaBU
    '1 = Consulta, 0 = Excel
    Dim nuevo As Integer = 1
    Dim idSuela As Integer
    Dim descripcion As String
    Dim activa As Boolean

    Private Sub AsignaEquivalenciaForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        consultar()
    End Sub

    Private Sub consultar()
        Dim objBU As New Programacion.Negocios.CargaSuelaGlobalBU()
        Dim tb As DataTable
        If rbActivas.Checked Then
            tb = objBU.CargarSuelaGlobal(1)
        Else
            tb = objBU.CargarSuelaGlobal(0)
        End If

        If validaTabla(tb) Then
            grdSuelaGlobal.DataSource = tb
        Else
            msjError.mensaje = "No existen datos con estas caracteristicas"
            msjError.ShowDialog()
        End If
        objBU = Nothing
    End Sub
    Private Function validaTabla(ByVal tabla As DataTable) As Boolean
        Dim respuesta As Boolean = True
        If tabla Is Nothing Then
            respuesta = False
        Else
            If tabla.Rows Is Nothing Then
                respuesta = False
            Else
                If tabla.Rows.Count = 0 Then
                    respuesta = False
                Else
                    respuesta = True
                End If
            End If
        End If
        
        Return respuesta
    End Function

   

    Private Sub btnConsultar_Click(sender As Object, e As EventArgs)
        Dim tbSuelaGlobal As DataTable = Nothing
        Dim objSuelaGlobalBU As New Programacion.Negocios.CargaSuelaGlobalBU()
        tbSuelaGlobal = objSuelaGlobalBU.CargarSuelaGlobal(rbActivas.Checked)
        If validaTabla(tbSuelaGlobal) Then
            grdSuelaGlobal.DataSource = tbSuelaGlobal
        Else
            msjError.mensaje = "No se encontraron registros con los campos seleccionados"
            msjError.ShowDialog()
        End If
    End Sub




    Private Sub btnNuevo_Click(sender As Object, e As EventArgs)
        Dim forma As New AltaSuelaGlobalForm
        forma.ShowDialog()
        consultar()
        forma = Nothing
    End Sub

   
    Private Sub btnModificacion_Click(sender As Object, e As EventArgs) Handles btnModificacion.Click

        Dim fila As Int32 = -1
        fila = grdSuelaGlobal.ActiveRow.Index
        If fila >= 0 Then

            idSuela = grdSuelaGlobal.Rows(fila).Cells("Id_Suela").Value
            descripcion = grdSuelaGlobal.Rows(fila).Cells("Descripcion").Value
            activa = grdSuelaGlobal.Rows(fila).Cells("Activo").Value

            Dim forma As New AltaSuelaGlobalForm()
            forma.txtCodigo.Text = idSuela.ToString
            forma.txtDescripcion.Text = descripcion.ToString()
            If activa Then
                forma.rdoActivo.Checked = activa
            Else
                forma.rdoInactivo.Checked = True
            End If

            forma.ShowDialog()
            consultar()
            forma = Nothing

        End If
    End Sub

    Private Sub btnAltas_Click(sender As Object, e As EventArgs) Handles btnAltas.Click
        Dim forma As New AltaSuelaGlobalForm
        forma.ShowDialog()
        consultar()
        forma = Nothing
    End Sub

    Private Sub rbActivas_CheckedChanged(sender As Object, e As EventArgs) Handles rbActivas.CheckedChanged
        consultar()
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub
End Class