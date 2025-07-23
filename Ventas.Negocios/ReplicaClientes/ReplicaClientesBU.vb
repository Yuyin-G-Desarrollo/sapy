
Public Class ReplicaClientesBU

    Public ClienteID_Original As Integer = 0
    Public ClienteID_Replica As Integer = 0
    Public NombreCliente_Original As String = String.Empty
    Public NombreCliente_Replica As String = String.Empty
    Public ClienteReplicado As Boolean = False

    Public Function ValidarNombreCliente(ByVal NombreCliente As String) As Boolean
        Dim objDA As New Datos.ReplicaClientesDA
        Dim dtResultado As New DataTable
        Dim Resultado As Boolean = False

        Try

            NombreCliente_Replica = NombreCliente
            dtResultado = objDA.ValidarNombreCliente(NombreCliente)

            If dtResultado.Rows.Count > 0 Then
                If Integer.TryParse(dtResultado.Rows(0).Item(0), 0) > 0 Then
                    Resultado = True
                Else
                    Resultado = False
                End If
            End If

            ClienteReplicado = Resultado

        Catch ex As Exception
            Throw ex
        End Try

        Return Resultado

    End Function



    Public Function ValidaExisteReplicaCliente(ByVal ClienteSAYID As Integer) As Boolean
        Dim objDA As New Datos.ReplicaClientesDA
        Dim dtResultado As New DataTable
        Dim Resultado As Boolean = False

        Try
            LimpiarInformacion()
            ClienteID_Original = ClienteSAYID
            dtResultado = objDA.ValidaExisteReplicaCliente(ClienteSAYID)

            If dtResultado.Rows.Count > 0 Then
                If Integer.TryParse(dtResultado.Rows(0).Item(0), 0) > 0 Then
                    Resultado = True
                Else
                    Resultado = False
                End If
            End If

            ClienteReplicado = Resultado

        Catch ex As Exception
            Throw ex
        End Try

        Return Resultado
    End Function


    Public Function ConsultaClientesSinReplicar(ByVal idcedis As Integer) As DataTable
        Dim objDA As New Datos.ReplicaClientesDA
        Dim tabla As New DataTable
        Dim ListaClientes As New List(Of Entidades.Cliente)
        ' Dim tool As ToolServicios.Convertidor(Of Entidades.Cliente) = New ToolServicios.Convertidor(Of Entidades.Cliente)

        Try

            tabla = objDA.ConsultaClientesSinReplicar(idcedis)
            'ListaClientes = tool.DataTableToList(tabla)

            Return tabla

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Private Sub LimpiarInformacion()
        ClienteID_Original = 0
        ClienteID_Replica = 0
        NombreCliente_Original = String.Empty
        NombreCliente_Replica = String.Empty
        ClienteReplicado = False
    End Sub


    Public Function ReplicarInformacionSAY(ByVal ClienteSAYID As Integer, ByVal ClienteSICYID As Integer, ByVal NombreCliente As String, ByVal UsuarioId As Integer, ByVal MarcaClienteOriginal As String, ByVal MarcaClienteReplica As String) As Boolean
        Dim objDA As New Datos.ReplicaClientesDA
        Dim dtResultado As New DataTable
        Dim Resultado As Boolean = False

        Try
            LimpiarInformacion()
            ClienteID_Original = ClienteSAYID
            dtResultado = objDA.ReplicarInformacionSAY(ClienteSAYID, ClienteSICYID, NombreCliente, UsuarioId, MarcaClienteOriginal, MarcaClienteReplica)

            If dtResultado.Rows.Count > 0 Then

                Resultado = True
            Else
                Resultado = False
            End If



        Catch ex As Exception
            Throw ex
        End Try

        Return Resultado
    End Function

    Public Function ReplicarInformacionSICY(ByVal ClienteSICY As Integer, ByVal NombreCliente As String, ByVal MarcaSICYOriginalId As String, ByVal MarcaSICYReplicaID As String) As Integer
        Dim objDA As New Datos.ReplicaClientesDA
        Dim dtResultado As New DataTable
        Dim ClienteSICYID As Integer = 0

        Try
            LimpiarInformacion()
            dtResultado = objDA.ReplicarInformacionSICY(ClienteSICY, NombreCliente, MarcaSICYOriginalId, MarcaSICYReplicaID)

            If dtResultado.Rows.Count > 0 Then
                If CInt(dtResultado.Rows(0).Item(0)) > 0 Then
                    ClienteSICYID = dtResultado.Rows(0).Item(0)
                Else
                    ClienteSICYID = 0
                End If
            End If

            Return ClienteSICYID

        Catch ex As Exception
            Throw ex
        End Try

        Return ClienteSICYID
    End Function

    Public Function ReplicarCliente(ByVal ClienteSAYID As Integer, ByVal ClienteSICYID As Integer, ByVal NombreCliente As String, ByVal UsuarioId As Integer, ByVal MarcaSICYOriginal As String, ByVal MarcaSICYReplica As String, ByVal MarcaSAYOriginal As String, ByVal MarcaSAYReplica As String) As Boolean
        Dim ClienteReplicaSICYID As Integer = 0
        Dim Resultado As Boolean = False

        Try
            'REplica la informacion en SICY
            ClienteReplicaSICYID = ReplicarInformacionSICY(ClienteSICYID, NombreCliente, MarcaSICYOriginal, MarcaSICYReplica)

            If ClienteReplicaSICYID > 0 Then
                'Replica la informacion en SAY
                Resultado = ReplicarInformacionSAY(ClienteSAYID, ClienteReplicaSICYID, NombreCliente, UsuarioId, MarcaSAYOriginal, MarcaSAYReplica)
            Else
                Resultado = False
            End If

        Catch ex As Exception
            Throw ex
        End Try

        Return Resultado

    End Function

    Public Function ConsultaMarcasCliente(ByVal ClienteId As Integer) As List(Of Entidades.Marcas)
        Dim DtResultado As New DataTable
        Dim objDA As New Datos.ReplicaClientesDA
        Dim Lista As New List(Of Entidades.Marcas)
        Dim EntidadMarca As Entidades.Marcas

        Try

            DtResultado = objDA.ConsultaMarcasCliente(ClienteId)

            For Each Fila As DataRow In DtResultado.Rows
                EntidadMarca = New Entidades.Marcas
                EntidadMarca.PSeleccion = Fila.Item("Seleccion")
                EntidadMarca.PMarcaId = Fila.Item("MarcaId")
                EntidadMarca.PDescripcion = Fila.Item("Marca")
                EntidadMarca.PSicyCodigo = Fila.Item("MarcaSicyID")
                Lista.Add(EntidadMarca)
            Next


        Catch ex As Exception
            Throw ex
        End Try

        Return Lista

    End Function

    Public Function ValidaExisteReplicaClienteReedition(ByVal ClienteSAYID As Integer) As Boolean
        Dim objDA As New Datos.ReplicaClientesDA
        Dim dtResultado As New DataTable
        Dim Resultado As Boolean = False
        Dim var As Integer
        Try
            LimpiarInformacion()
            ClienteID_Original = ClienteSAYID
            dtResultado = objDA.ValidaExisteReplicaClienteReedition(ClienteSAYID)

            If dtResultado.Rows.Count > 0 Then
                'If Integer.TryParse(dtResultado.Rows(0).Item(0), 0) > 0 Then
                '    Resultado = True
                'Else
                '    Resultado = False
                'End If
                var = dtResultado.Rows(0).Item(0)
                If var > 0 Then
                    Resultado = True
                Else
                    Resultado = False
                End If


            End If

            ClienteReplicado = Resultado

        Catch ex As Exception
            Throw ex
        End Try

        Return Resultado
    End Function

    Public Function ReplicarInformacionSICYSinMarcasReedition(ByVal ClienteSICY As Integer, ByVal NombreCliente As String) As Integer
        Dim objDA As New Datos.ReplicaClientesDA
        Dim dtResultado As New DataTable
        Dim ClienteSICYID As Integer = 0

        Try
            LimpiarInformacion()
            dtResultado = objDA.ReplicarInformacionSICYSinMarcasReedition(ClienteSICY, NombreCliente)

            If dtResultado.Rows.Count > 0 Then
                If CInt(dtResultado.Rows(0).Item(0)) > 0 Then
                    ClienteSICYID = dtResultado.Rows(0).Item(0)
                Else
                    ClienteSICYID = 0
                End If
            End If

            Return ClienteSICYID

        Catch ex As Exception
            Throw ex
        End Try

        Return ClienteSICYID
    End Function

    Public Function ReplicarInformacionSAYReedition(ByVal ClienteSAYID As Integer, ByVal ClienteSICYID As Integer, ByVal NombreCliente As String, ByVal UsuarioId As Integer) As Boolean
        Dim objDA As New Datos.ReplicaClientesDA
        Dim dtResultado As New DataTable
        Dim Resultado As Boolean = False

        Try
            LimpiarInformacion()
            ClienteID_Original = ClienteSAYID
            dtResultado = objDA.ReplicarInformacionSAYReedition(ClienteSAYID, ClienteSICYID, NombreCliente, UsuarioId)

            If dtResultado.Rows.Count > 0 Then

                Resultado = True
            Else
                Resultado = False
            End If



        Catch ex As Exception
            Throw ex
        End Try

        Return Resultado
    End Function
    Public Function ReplicarClienteReedition(ByVal ClienteSAYID As Integer, ByVal ClienteSICYID As Integer, ByVal NombreCliente As String, ByVal UsuarioId As Integer) As Boolean
        Dim ClienteReplicaSICYID As Integer = 0
        Dim Resultado As Boolean = False

        Try
            'REplica la informacion en SICY
            ClienteReplicaSICYID = ReplicarInformacionSICYSinMarcasReedition(ClienteSICYID, NombreCliente)

            If ClienteReplicaSICYID > 0 Then
                'Replica la informacion en SAY
                Resultado = ReplicarInformacionSAYReedition(ClienteSAYID, ClienteSICYID, NombreCliente, UsuarioId)
            Else
                Resultado = False
            End If

        Catch ex As Exception
            Throw ex
        End Try

        Return Resultado

    End Function

    Public Function ValidarNombreClienteReedition(ByVal NombreCliente As String) As Boolean
        Dim objDA As New Datos.ReplicaClientesDA
        Dim dtResultado As New DataTable
        Dim Resultado As Boolean = False
        Dim var As Integer
        Try

            NombreCliente_Replica = NombreCliente
            dtResultado = objDA.ValidarNombreClienteReedition(NombreCliente)

            If dtResultado.Rows.Count > 0 Then
                'If Integer.TryParse(dtResultado.Rows(0).Item(0), 0) > 0 Then
                '    Resultado = True
                'Else
                '    Resultado = False
                'End If
                var = dtResultado.Rows(0).Item(0)
                If var > 0 Then
                    Resultado = True
                Else
                    Resultado = False
                End If

            End If

            ClienteReplicado = Resultado

        Catch ex As Exception
            Throw ex
        End Try

        Return Resultado

    End Function

End Class
