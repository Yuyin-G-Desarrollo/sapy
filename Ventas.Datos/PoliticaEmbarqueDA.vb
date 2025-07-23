Imports Persistencia
Imports System.Data.SqlClient

Public Class PoliticaEmbarqueDA

    Public Sub editarPoliticaEmbarque(ByVal PoliticaEmbarque As Entidades.PoliticaEmbarque, bandera As Integer)

        Dim operaciones As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        ',@bandera AS INTEGER
        Dim parametro As New SqlParameter
        parametro.ParameterName = "bandera"
        parametro.Value = bandera
        listaParametros.Add(parametro)

        ',@lugarentregaid AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "lugarentregaid"
        If IsNothing(PoliticaEmbarque.lugarentrega) Then
            parametro.Value = 0
        Else
            parametro.Value = PoliticaEmbarque.lugarentrega.lugarentregaid
        End If
        listaParametros.Add(parametro)

        ',@tipoflejeid AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "tipoflejeid"
        If IsNothing(PoliticaEmbarque.tipofleje) Then
            parametro.Value = 0
        Else
            parametro.Value = PoliticaEmbarque.tipofleje.tipoflejeid
        End If
        listaParametros.Add(parametro)

        ',@protectorflejeid AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "protectorflejeid"
        If IsNothing(PoliticaEmbarque.protectorfleje) Then
            parametro.Value = 0
        Else
            parametro.Value = PoliticaEmbarque.protectorfleje.protectorflejeid
        End If
        listaParametros.Add(parametro)

        ',@tipoempaqueid AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "tipoempaqueid"
        If IsNothing(PoliticaEmbarque.tipoempaque) Then
            parametro.Value = 0
        Else
            parametro.Value = PoliticaEmbarque.tipoempaque.tipoempaqueid
        End If
        listaParametros.Add(parametro)

        ',@paresempaque AS INTEGER
        'parametro = New SqlParameter
        'parametro.ParameterName = "paresempaque"
        'If PoliticaEmbarque.paresempaque = 0 Then
        '    parametro.Value = 0
        'Else
        '    parametro.Value = PoliticaEmbarque.paresempaque
        'End If
        'listaParametros.Add(parametro)

        ',@tipoentregaid AS INTEGER
        'parametro = New SqlParameter
        'parametro.ParameterName = "tipoentregaid"
        'If IsNothing(PoliticaEmbarque.tipoentrega) Then
        '    parametro.Value = 0
        'Else
        '    parametro.Value = PoliticaEmbarque.tipoentrega.tipoentregaid
        'End If
        'listaParametros.Add(parametro)

        ',@imprimircajainfocte AS BIT
        parametro = New SqlParameter
        parametro.ParameterName = "imprimircajainfocte"
        If Not (PoliticaEmbarque.imprimircajainfocte) Then
            parametro.Value = False
        Else
            parametro.Value = PoliticaEmbarque.imprimircajainfocte
        End If
        listaParametros.Add(parametro)

        '',@citaentrega AS BIT
        'parametro = New SqlParameter
        'parametro.ParameterName = "citaentrega"
        'If Not (PoliticaEmbarque.citaentrega) Then
        '    parametro.Value = False
        'Else
        '    parametro.Value = PoliticaEmbarque.citaentrega
        'End If
        'listaParametros.Add(parametro)

        '',@formaentregaid AS INTEGER
        'parametro = New SqlParameter
        'parametro.ParameterName = "formaentregaid"
        'If IsNothing(PoliticaEmbarque.formaentrega) Then
        '    parametro.Value = 0
        'Else
        '    parametro.Value = PoliticaEmbarque.formaentrega.formaentregaid
        'End If
        'listaParametros.Add(parametro)

        '',@horascitaentrega AS INTEGER
        'parametro = New SqlParameter
        'parametro.ParameterName = "horascitaentrega"
        'If PoliticaEmbarque.horascitaentrega = 0 Then
        '    parametro.Value = 0
        'Else
        '    parametro.Value = PoliticaEmbarque.horascitaentrega
        'End If
        'listaParametros.Add(parametro)

        ',@validarcodigoetiqueta AS BIT
        parametro = New SqlParameter
        parametro.ParameterName = "validarcodigoetiqueta"
        If Not (PoliticaEmbarque.validarcodigoetiqueta) Then
            parametro.Value = False
        Else
            parametro.Value = PoliticaEmbarque.validarcodigoetiqueta
        End If
        listaParametros.Add(parametro)

        ',@etiquetaembarque AS BIT
        parametro = New SqlParameter
        parametro.ParameterName = "etiquetaembarque"
        If Not (PoliticaEmbarque.etiquetaembarque) Then
            parametro.Value = False
        Else
            parametro.Value = PoliticaEmbarque.etiquetaembarque
        End If
        listaParametros.Add(parametro)

        ',@notasembarque AS VARCHAR(200)
        parametro = New SqlParameter
        parametro.ParameterName = "notasembarque"
        If String.IsNullOrWhiteSpace(PoliticaEmbarque.notasembarque) Then
            parametro.Value = String.Empty
        Else
            parametro.Value = PoliticaEmbarque.notasembarque
        End If
        listaParametros.Add(parametro)

        ',@papelenvolventeid AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "papelenvolventeid"
        If IsNothing(PoliticaEmbarque.papelenvolvente) Then
            parametro.Value = 0
        Else
            parametro.Value = PoliticaEmbarque.papelenvolvente.papelenvolventeid
        End If
        listaParametros.Add(parametro)

        ',@clienteid AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "clienteid"
        parametro.Value = PoliticaEmbarque.cliente.clienteid
        listaParametros.Add(parametro)

        ',@activo AS BIT
        parametro = New SqlParameter
        parametro.ParameterName = "activo"
        If PoliticaEmbarque.activo Then
            parametro.Value = False
        Else
            parametro.Value = PoliticaEmbarque.activo
        End If
        listaParametros.Add(parametro)

        ',@usuariomodificoid AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "usuariomodificoid"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)


        ',@notasembarque AS VARCHAR(200)
        parametro = New SqlParameter
        parametro.ParameterName = "notasventas"
        If String.IsNullOrWhiteSpace(PoliticaEmbarque.notasVentas) Then
            parametro.Value = String.Empty
        Else
            parametro.Value = PoliticaEmbarque.notasVentas
        End If
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "CitaParaEntrega"
        If String.IsNullOrWhiteSpace(PoliticaEmbarque.CitaParaEntrega) Then
            parametro.Value = False
        Else
            parametro.Value = PoliticaEmbarque.CitaParaEntrega
        End If
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "HorasAnticipacion"
        If String.IsNullOrWhiteSpace(PoliticaEmbarque.HorasAnticipacion) Then
            parametro.Value = 0
        Else
            parametro.Value = PoliticaEmbarque.HorasAnticipacion
        End If
        listaParametros.Add(parametro)


        parametro = New SqlParameter
        parametro.ParameterName = "DoceneoEspecial"
        parametro.Value = PoliticaEmbarque.DoceneoEspecial.ToString()
        listaParametros.Add(parametro)


        parametro = New SqlParameter
        parametro.ParameterName = "EntregaPartidaCompleta"
        parametro.Value = PoliticaEmbarque.FormaEntregaMercancia.ToString()
        listaParametros.Add(parametro)


        parametro = New SqlParameter
        parametro.ParameterName = "EntregaLotesCompletos"
        parametro.Value = PoliticaEmbarque.EntregaLotesCompletos.ToString()
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "LoteCliente_Tienda"
        parametro.Value = PoliticaEmbarque.EntregaLotesCompletos_Tienda.ToString()
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "LoteCliente_Modelo"
        parametro.Value = PoliticaEmbarque.EntregaLotesCompletos_Modelo.ToString()
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "LoteCliente_Piel"
        parametro.Value = PoliticaEmbarque.EntregaLotesCompletos_Piel.ToString()
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "LoteCliente_Color"
        parametro.Value = PoliticaEmbarque.EntregaLotesCompletos_Color.ToString()
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "LoteCliente_Corrida"
        parametro.Value = PoliticaEmbarque.EntregaLotesCompletos_Corrida.ToString()
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "LoteCliente_Pedido"
        parametro.Value = PoliticaEmbarque.EntregaLotesCompletos_Pedido.ToString()
        listaParametros.Add(parametro)

        operaciones.EjecutarSentenciaSP("Ventas.SP_Editar_PoliticaEmbarque", listaParametros)
        Console.WriteLine("Mando la sentencia")

    End Sub

    Public Function Datos_TablaPoliticaEmbarque(clienteID As Integer) As DataTable

        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "" +
                                " SELECT * FROM Ventas.PoliticaEmbarque WHERE poem_clienteid = " + clienteID.ToString

        Return operaciones.EjecutaConsulta(consulta)

    End Function

End Class
