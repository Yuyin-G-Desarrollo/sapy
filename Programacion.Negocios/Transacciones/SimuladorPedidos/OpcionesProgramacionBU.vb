Imports Programacion.Datos
Imports Entidades

Public Class OpcionesProgramacionBU
    Dim vOpcionesProgramacion As OpcionesProgramacion
    Dim vOpcionesProgramacionDA As OpcionesProgramacionDA
    Public Function obtnerValoresTabla() As Dictionary(Of String, OpcionesProgramacion)
        vOpcionesProgramacionDA = New OpcionesProgramacionDA
        Dim dictionary As New Dictionary(Of String, OpcionesProgramacion)
        For Each fila As DataRow In vOpcionesProgramacionDA.obtnerValoresTabla.Rows
            vOpcionesProgramacion = New OpcionesProgramacion
            With vOpcionesProgramacion
                .pidOpciones = CInt(fila("opci_opciID"))
                .pdescripcionOpciones = CStr(fila("opci_descripcion"))
                .popcionNumericoUno = CDbl(fila("opci_valor_numerico"))
                .popcionNumericoDos = CDbl(fila("opci_valor_numerico_2"))
                .popcionValorEntero = CInt(fila("opci_valor_entero"))

                If Not IsDBNull((fila("opci_valor_cadena"))) Then
                    .popcionCadena = CStr(fila("opci_valor_cadena"))
                End If
                If Not IsDBNull((fila("opci_valor_date"))) Then
                    .popcionFecha = CDate(fila("opci_valor_date"))
                End If

                .popcionValorBooleano = CBool(fila("opci_valor_booleano"))
            End With
            If Not dictionary.ContainsKey(CStr(fila("opci_descripcion"))) Then
                dictionary.Add(CStr(fila("opci_descripcion")), vOpcionesProgramacion)
            End If

        Next
        Return dictionary
    End Function

    Public Function tablaUsuarioProgramacion() As DataTable
        vOpcionesProgramacionDA = New OpcionesProgramacionDA
        Return vOpcionesProgramacionDA.tablaUsuarioProgramacion
    End Function
    Public Sub Agregar(usuarioID As Int32)
        vOpcionesProgramacionDA = New OpcionesProgramacionDA
        vOpcionesProgramacionDA.Agregar(usuarioID)
    End Sub
    Public Sub Eliminar(usuarioID As Int32)
        vOpcionesProgramacionDA = New OpcionesProgramacionDA
        vOpcionesProgramacionDA.Eliminar(usuarioID)
    End Sub
    Public Function ListarUsuariosSegunPerfil(ByVal perfil As Integer) As DataTable
        vOpcionesProgramacionDA = New OpcionesProgramacionDA
        Return vOpcionesProgramacionDA.ListarUsuariosSegunPerfil(perfil)
    End Function
    Public Sub actualizarOpciones(ByVal valoreOpciones As DataTable)
        vOpcionesProgramacionDA = New OpcionesProgramacionDA
        vOpcionesProgramacionDA.actualizarOpciones(valoreOpciones)
    End Sub
End Class
