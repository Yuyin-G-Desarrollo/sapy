Imports System.Data.SqlClient

Public Class ListaCadenaConexionForm
	Dim conexion1 As Boolean
	Dim conexion2 As Boolean
	Dim conexion3 As Boolean
	Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelar.Click
		Me.Close()

	End Sub

	Private Sub ListaCadenaConexionForm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
		txtConexionSAY.Text = Persistencia.Configuracion.CadenaConexionPool
		txtConexionPoolSicy.Text = Persistencia.Configuracion.CadenaConexionPoolSICY
		txtConexionPoolPruebas.Text = Persistencia.Configuracion.CadenaConexionPoolPruebas
	End Sub

	Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles btnGuardar.Click
		
		Dim falla As Boolean = False
		If conexion1 And conexion2 And conexion3 Then
			Persistencia.Configuracion.cambiarConexion(txtConexionSAY.Text, txtConexionPoolSicy.Text, txtConexionPoolPruebas.Text)
			Dim mensajeAdvertencia As New ExitoForm
			mensajeAdvertencia.mensaje = "Configuración guardada"
			mensajeAdvertencia.ShowDialog()
		Else
			Dim mensajeAdvertencia As New AdvertenciaForm
			mensajeAdvertencia.mensaje = "Cadena de conexion incorrecta"
			mensajeAdvertencia.ShowDialog()
		End If
		'Else
		'	falla = True

		'	If pbMal.Visible = False Then
		'	Else
		'		falla = True

		'		If pbMalI.Visible = False Then

		'			Persistencia.Configuracion.cambiarConexion(txtConexionSAY.Text, txtConexionPoolSicy.Text, txtConexionPoolPruebas.Text)
		'		Else
		'			falla = True
		'			Dim mensajeAdvertencia As New AdvertenciaForm
		'			mensajeAdvertencia.mensaje = "Cadena de conexion incorrecta"
		'			mensajeAdvertencia.ShowDialog()
		'		End If




		'	End If

		'End If






	End Sub

	Private Sub PictureBox1_Click(sender As System.Object, e As System.EventArgs) Handles PictureBox1.Click
		
	End Sub

	Private Sub btnComprobar_Click(sender As System.Object, e As System.EventArgs) Handles btnComprobar.Click
		Dim sqlCon As New SqlClient.SqlConnection
		sqlCon = New SqlConnection(txtConexionSAY.Text)
		Try

			sqlCon.Open()
			'btnComprobar.Visible = False
			PictureBox1.Visible = True
			pbMal.Visible = False
			conexion1 = True
		Catch ex_sql As SqlException
			'MessageBox.Show(ex_sql.ToString)
			'MessageBox.Show("la cadena es incorrecta")

			PictureBox1.Visible = False
			pbMal.Visible = True


		Catch ex As Exception
			MessageBox.Show(ex.ToString)

		End Try

	End Sub

	Private Sub Button1_Click_1(sender As System.Object, e As System.EventArgs) Handles Button1.Click
		Dim sqlCon As New SqlClient.SqlConnection
		sqlCon = New SqlConnection(txtConexionPoolSicy.Text)
		Try

			sqlCon.Open()
			PictureBox2.Visible = True
			pbIncorrecto.Visible = False
			conexion2 = True
		Catch ex_sql As SqlException
			'MessageBox.Show(ex_sql.ToString)
			PictureBox2.Visible = False
			pbIncorrecto.Visible = True


		Catch ex As Exception
			MessageBox.Show(ex.ToString)

		End Try
	End Sub

	Private Sub txtConexionPoolPruebas_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtConexionPoolPruebas.TextChanged
		'Dim sqlCon As New SqlClient.SqlConnection
		'sqlCon = New SqlConnection(txtConexionPoolPruebas.Text)
		'Try

		'	sqlCon.Open()
		'	PictureBox3.Visible = True

		'Catch ex_sql As SqlException
		'	'MessageBox.Show(ex_sql.ToString)
		'	PictureBox3.Visible = False
		'	pbMalI.Visible = True

		'Catch ex As Exception
		'	MessageBox.Show(ex.ToString)

		'End Try
	End Sub

	Private Sub Button2_Click_1(sender As System.Object, e As System.EventArgs) Handles Button2.Click
		Dim sqlCon As New SqlClient.SqlConnection
		sqlCon = New SqlConnection(txtConexionPoolPruebas.Text)
		Try

			sqlCon.Open()
			PictureBox3.Visible = True
			pbMalI.Visible = False
			conexion3 = True
		Catch ex_sql As SqlException
			'MessageBox.Show(ex_sql.ToString)
			PictureBox3.Visible = False
			pbMalI.Visible = True

		Catch ex As Exception
			MessageBox.Show(ex.ToString)

		End Try
	End Sub
End Class