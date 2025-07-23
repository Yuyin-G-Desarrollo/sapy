Imports Nomina.Datos

Public Class ColaboradorNominaBU
    Public Sub guardarColaboradorNomina(ByVal col As Entidades.ColaboradorNomina, ByVal idNave As Int32, ByVal idPuesto As Int32)
        Dim objDA As New ColaboradorNominaDA
        objDA.guardarColaboradorNomina(col, idNave, idPuesto)
    End Sub

    Public Sub EditarColaboradorNomina(ByVal col As Entidades.ColaboradorNomina, ByVal colaboradorId As Int32)
        Dim objDA As New ColaboradorNominaDA
        objDA.EditarrColaboradorNomina(col, colaboradorId)
    End Sub

    Public Function buscarColaborarNomina(ByVal colaboradorid As Int32) As Entidades.ColaboradorNomina
        Dim objColaboradorNominaDA As New ColaboradorNominaDA
        Dim objColaboradorBU As New ColaboradoresBU
        Dim colaborador As New Entidades.Colaborador
        Dim tablaColaboradorNom As New DataTable
        buscarColaborarNomina = New Entidades.ColaboradorNomina
        colaborador = objColaboradorBU.BuscarColaboradorGeneral(colaboradorid)
        tablaColaboradorNom = objColaboradorNominaDA.buscarColaboradorNomina(colaboradorid)
        For Each row As DataRow In tablaColaboradorNom.Rows

            'buscarColaborarNomina.PCuenta = CStr(row("cono_cuenta"))
            buscarColaborarNomina.PFechaAltaImss = CDate(row("cono_fechaaltaimss"))
            buscarColaborarNomina.PFormaPago = CStr(row("cono_formapago"))
            buscarColaborarNomina.PNss = CStr(row("cono_nss"))
            buscarColaborarNomina.PSalario = CDbl(row("cono_salario"))
            buscarColaborarNomina.PColaborador = colaborador

            Dim patron As New Entidades.Patrones
            patron.Ppatronid = CInt(row("patr_patronid"))
            patron.Pnombre = CStr(row("patr_nombre"))
            patron.PNpatronal = CStr(row("patr_nopatronal"))


            If IsDBNull(row("patr_nominpaqID")) Then
                patron.PNpatronalNP = ""
            Else
                patron.PNpatronalNP = CStr(row("patr_nominpaqID"))
            End If

            patron.Prfc = CStr(row("patr_rfc"))

            If IsDBNull(row("datas_BD")) Then
                patron.PpatronBD = ""
            Else
                patron.PpatronBD = CStr(row("datas_BD"))
            End If

            If IsDBNull(row("datas_Servidor")) Then
                patron.PServidor = ""
            Else
                patron.PServidor = CStr(row("datas_Servidor"))
            End If

            If Not IsDBNull(row("cono_afore")) Then
                buscarColaborarNomina.PAfore = CStr(row("cono_afore"))
            End If

            If Not IsDBNull(row("cono_infonavit")) Then
                buscarColaborarNomina.PInfonavit = CStr(row("cono_infonavit"))
            End If

            If Not IsDBNull(row("cono_bancoid")) Then
                buscarColaborarNomina.PBancoID = CInt(row("cono_bancoid"))
            End If

            Try
                buscarColaborarNomina.PSalarioDiario = CDbl(row("cono_salariodiario"))
            Catch ex As Exception

            End Try

            If Not IsDBNull(row("cono_infonavit_tipo")) Then
                buscarColaborarNomina.PInfonavitTipo = CStr(row("cono_infonavit_tipo"))
            End If

            If Not IsDBNull(row("cono_infonavit_monto")) Then
                buscarColaborarNomina.PInfonavitMonto = CStr(row("cono_infonavit_monto"))
            End If

            If Not IsDBNull(row("cono_infonavit_fecha")) Then
                buscarColaborarNomina.PfechaAltaInfonavit = CDate(row("cono_infonavit_fecha"))
            End If

            If Not IsDBNull(row("cono_isrmonto")) Then
                buscarColaborarNomina.PMontoISR = CDbl(row("cono_isrmonto"))
            End If

            If Not IsDBNull(row("cono_asegurado")) Then
                buscarColaborarNomina.PAsegurado = CStr(row("cono_asegurado"))
            End If

            If Not IsDBNull(row("cono_externo")) Then
                buscarColaborarNomina.PExterno = CStr(row("cono_externo"))
            End If

            If Not IsDBNull(row("cono_codigopostalsat")) Then
                buscarColaborarNomina.PCPSAT = CStr(row("cono_codigopostalsat"))
            End If

            buscarColaborarNomina.PPatron = patron
        Next

    End Function

    Public Function ValidacionInsertUpdateNomina(ByVal Colaboradorid As Int32) As Int32
        Dim ObjDA As New Datos.ColaboradorNominaDA
        Dim tabla As New DataTable
        tabla = ObjDA.buscarColaboradorNomina(Colaboradorid)
        Dim Count As New Int32

        Count = tabla.Rows.Count
        Return Count
    End Function
End Class
