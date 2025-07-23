Imports Framework.Negocios

Public Class EditarAgregarDiaForm

    Public IdDia As Integer
    Public AgregarOModificar As Boolean
    Public Activo As Boolean
    Public Nombre As String


    Private Sub EditarAgregarDiaForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtAltaNombreDias.MaxLength = 50

        'validamos que si presiono el boton de editar llene el cuadro de texto y seleccione el radiobutton
        If AgregarOModificar = False Then
            txtAltaNombreDias.Text = Nombre
            If Activo Then
                rdoActivoSi.Checked = True
            Else
                rdoActivoNo.Checked = True
            End If
        End If
    End Sub


    Private Sub btnGuardarDia_Click(sender As Object, e As EventArgs) Handles btnGuardarDia.Click

        'Condicion para verificar si dara de alta o realizara una actualizacion a los datos
        If AgregarOModificar = True Then

            ''validar que los campos no estan vacios
            Dim vacios As Boolean = False

            If txtAltaNombreDias.Text <> "" Then
                lblAltaNombreDia.ForeColor = Color.Black
            Else
                lblAltaNombreDia.ForeColor = Color.Red
                vacios = True
            End If

            If vacios = True Then
                Dim FormularioError As New ErroresForm
                FormularioError.mensaje = "Campos Vacios"
                FormularioError.Show()
            Else
                '' asignammos los valores a la clase de la capa entidad 
                Dim Dias As New Entidades.CatalogosDias
                Dias.PNombreDia = txtAltaNombreDias.Text
                If rdoActivoSi.Checked = True Then
                    Dias.PActivo = True
                Else
                    Dias.PActivo = False
                End If

                Dim objDiasBU As New CatalogoDiasBU
                objDiasBU.guardarDias(Dias)
                Dim FormularioMensaje As New ExitoForm
                FormularioMensaje.mensaje = "Registro Guardado"
                FormularioMensaje.ShowDialog()
               
                Me.Close()

               
            End If

        Else

            Dim falla As Boolean = False
            If txtAltaNombreDias.Text <> "" Then

                lblAltaNombreDia.ForeColor = Color.Black
            Else
                lblAltaNombreDia.ForeColor = Color.Red
                falla = True
            End If


            If falla Then
                Dim FormaError As New ErroresForm
                FormaError.mensaje = "Campos vacíos"
                FormaError.Show()
            Else
                ''se valida que este todo bien para editar
                Dim Dias As New Entidades.CatalogosDias
                Dias.PNombreDia = txtAltaNombreDias.Text
                If rdoActivoSi.Checked = True Then
                    Dias.PActivo = True
                Else
                    Dias.PActivo = False
                End If
                Dias.PIdDia = IdDia

                Dim objDiasBu As New CatalogoDiasBU
                objDiasBu.editarDias(Dias)
                Dim FormaExito As New ExitoForm
                FormaExito.mensaje = "Registro Guardado"
                FormaExito.ShowDialog()
            End If
          
            Me.Close()

        End If
    End Sub


    Private Sub btnCancelarDia_Click(sender As Object, e As EventArgs) Handles btnCancelarDia.Click
        Me.Dispose()

    End Sub

    Private Sub lblLimpiar_Click(sender As Object, e As EventArgs) Handles lblLimpiar.Click

    End Sub

    Private Sub lblBuscar_Click(sender As Object, e As EventArgs) Handles lblBuscar.Click

    End Sub
End Class