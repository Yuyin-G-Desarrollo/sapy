Public Class DetallesOcupacionForm
    Public BahiasVerde, BahiasAzul, BahiasNaranja, BahiasRojo As Int32
    Public BahiasParesVerde, BahiasParesAzul, BahiasParesNaranja, BahiasParesRojo As Int32
    Public CapacidadTotal, CapacidadUsada As Int32
    Private Sub DetallesOcupacionForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim TotalBahias, TotalPares As Int32

        TotalBahias = BahiasVerde + BahiasAzul + BahiasNaranja + BahiasRojo
        TotalPares = BahiasParesVerde + BahiasParesAzul + BahiasParesNaranja + BahiasParesRojo

        lblBahiasTotal.Text = TotalBahias.ToString("###,##0")
        ' lblBahiasTotal.TextAlign = ContentAlignment.MiddleRight
        lblParesTotal.Text = TotalPares.ToString("###,##0")
        'lblParesTotal.TextAlign = ContentAlignment.MiddleRight

        lblBahiasAzul.Text = BahiasAzul.ToString
        'lblBahiasAzul.TextAlign = ContentAlignment.MiddleRight
        lblBahiasVerde.Text = BahiasVerde.ToString("###,##0")
        'lblBahiasVerde.TextAlign = ContentAlignment.MiddleRight
        lblBahiasNaranja.Text = BahiasNaranja.ToString("###,##0")
        'lblBahiasNaranja.TextAlign = ContentAlignment.MiddleRight
        lblBahiasRojo.Text = BahiasRojo.ToString("###,##0")
        'lblBahiasRojo.TextAlign = ContentAlignment.MiddleRight

        lblParesAzul.Text = BahiasParesAzul.ToString("###,##0")
        'lblParesAzul.TextAlign = ContentAlignment.MiddleRight
        lblParesVerde.Text = BahiasParesVerde.ToString("###,##0")
        'lblParesVerde.TextAlign = ContentAlignment.MiddleRight
        lblParesNaranja.Text = BahiasParesNaranja.ToString("###,##0")
        'lblParesNaranja.TextAlign = ContentAlignment.MiddleRight
        lblParesRojo.Text = BahiasParesRojo.ToString("###,##0")
        'lblParesRojo.TextAlign = ContentAlignment.MiddleRight

        lblTotalCapacidad.Text = CapacidadTotal.ToString("###,##0")


        Dim Disponibilidad As Int32

        Disponibilidad = CapacidadTotal - CapacidadUsada

        lblDisponibilidad.Text = Disponibilidad.ToString("###,##0")

        Dim PorcentajeUsado As New Double
        PorcentajeUsado = (CapacidadUsada / CapacidadTotal) * 100

        lblOcupacion.Text = PorcentajeUsado.ToString("###,##0.00") + "%"
        'lblOcupacion.TextAlign = ContentAlignment.BottomRight

        lblpordisponibilidad.Text = (100 - PorcentajeUsado).ToString("###,##0.00") + "%"
        'lblpordisponibilidad.TextAlign = ContentAlignment.MiddleRight
        If PorcentajeUsado < 50 Then
            pnlOcupacion.BackColor = Color.Green
        ElseIf PorcentajeUsado < 80 Then
            pnlOcupacion.BackColor = Color.Blue
        ElseIf PorcentajeUsado <= 100 Then
            pnlOcupacion.BackColor = Color.Orange
        ElseIf PorcentajeUsado > 100 Then
            pnlOcupacion.BackColor = Color.Red
        End If



    End Sub


    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub
End Class