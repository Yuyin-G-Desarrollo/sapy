Imports Framework.Negocios

Public Class ListaPoblacionesForm
    Dim idPoblacion As Int32
    Dim NombrePoblacion As String
    Dim Pais, Estado, Ciudad As Int32
    Private Sub ListaPoblacionesForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Top = 0
        Me.Left = 0
        cmbPais = Controles.ComboPaises(cmbPais)
        If PermisosUsuarioBU.ConsultarPermiso("FWKCATPOBL", "WRITE") Then
            btnAltas.Visible = True
            lblAltas.Visible = True
        Else
            btnAltas.Visible = False
            lblAltas.Visible = False
        End If
        If PermisosUsuarioBU.ConsultarPermiso("FWKCATPOBL", "UPDATE") Then
            btnEditar.Visible = True
            Editar.Visible = True
        Else
            btnEditar.Visible = False
            Editar.Visible = False
        End If
    End Sub

    Public Sub CargarInformacion()
        Dim contador As Int32
        contador = 1
        Dim OBJBU As New Negocios.PoblacionBU
        Dim tabla As New List(Of Entidades.Poblacion)
        Dim Pais, Estado, Ciudad As Int32
        If cmbPais.SelectedIndex > 0 Then
            Pais = CInt(cmbPais.SelectedValue)
        Else

        End If
        If cmbEstado.SelectedIndex > 0 Then
            Estado = CInt(cmbEstado.SelectedValue)
        Else

        End If
        If cmbCiudad.SelectedIndex > 0 Then
            Ciudad = CInt(cmbCiudad.SelectedValue)
        Else

        End If
        Dim Activo As Boolean = False
        If rdoSi.Checked = True Then
            Activo = True
        Else
            Activo = False
        End If

        tabla = OBJBU.ConsultarPoblaciones(Pais, Estado, Ciudad, txtNombreDelPuesto.Text, Activo)

        For Each elemento As Entidades.Poblacion In tabla
            grdPoblaciones.Rows.Add(elemento.poblacionid, contador, elemento.ciudad.CNombrePais.PNombre.ToUpper, _
                elemento.ciudad.CIDEstado.ENombre, elemento.ciudad.CNombre, elemento.nombre, elemento.activo, elemento.ciudad.CciudadId, elemento.ciudad.CIDEstado.EIDDEstado, elemento.ciudad.CNombrePais.PIDPais)
            contador += 1
        Next

    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        grdPoblaciones.Rows.Clear()
        CargarInformacion()
    End Sub

    Private Sub cmbPais_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPais.SelectedIndexChanged
        Try

            cmbEstado = Controles.ComboEstadosAnidado(cmbEstado, CInt(cmbPais.SelectedValue))
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbEstado_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbEstado.SelectedIndexChanged
        Try
            cmbCiudad = Controles.ComboCiudades(cmbCiudad, CInt(cmbEstado.SelectedValue))

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnAltas_Click(sender As Object, e As EventArgs) Handles btnAltas.Click
        Dim AltaPoblacion As New AltaPoblacion
        AltaPoblacion.Show()
    End Sub


    Private Sub grdPoblaciones_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdPoblaciones.CellClick
        If e.RowIndex > 0 Then
            NombrePoblacion = CStr(grdPoblaciones.Rows(e.RowIndex).Cells("ColPoblacion").Value)
            Pais = CInt(grdPoblaciones.Rows(e.RowIndex).Cells("idPais").Value)
            Estado = CInt(grdPoblaciones.Rows(e.RowIndex).Cells("idEstado").Value)
            Ciudad = CInt(grdPoblaciones.Rows(e.RowIndex).Cells("idCiudad").Value)
            idPoblacion = CInt(grdPoblaciones.Rows(e.RowIndex).Cells("colPoblacionid").Value)
        End If
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        Dim AltaPoblacion As New AltaPoblacion
        AltaPoblacion.lblTitle.Text = "Editar Población"
        AltaPoblacion.Text = "Editar Población"
        AltaPoblacion.txtNombrePoblacion.Text = NombrePoblacion
        AltaPoblacion.PPais = Pais
        AltaPoblacion.PEstado = Estado
        AltaPoblacion.PCiudad = Ciudad
        AltaPoblacion.PEdicion = True
        AltaPoblacion.PidPoblacion = idPoblacion
        AltaPoblacion.Show()
    End Sub


    Private Sub ListaPoblacionesForm_KeyPress(sender As Object, e As KeyPressEventArgs) Handles MyBase.KeyPress
        If Char.IsLetter(e.KeyChar) Then

            e.KeyChar = Char.ToUpper(e.KeyChar)

        End If

    End Sub

    Private Sub lblListaPoblaciones_Click(sender As Object, e As EventArgs) Handles lblListaPoblaciones.Click

    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        grbPuestos.Height = 175
        grdPoblaciones.Height = 299
        grdPoblaciones.Top = 235
    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        grbPuestos.Height = 38
        grdPoblaciones.Height = 435
        grdPoblaciones.Top = 98
    End Sub

    Private Sub grbPuestos_Enter(sender As Object, e As EventArgs) Handles grbPuestos.Enter

    End Sub
End Class