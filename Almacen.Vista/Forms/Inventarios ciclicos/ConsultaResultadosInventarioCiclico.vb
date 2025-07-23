Imports Stimulsoft.Report

Public Class ConsultaResultadosInventarioCiclico

    Public fechaInicio As String
    Public fechaFin As String
    Public NombreOperador As String
    Public idnave As Integer
    Public SinDiferencias As Double
    Public Condiferencias As Double



    Private Sub ConsultaResultadosInventarioCiclico_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DateStart.Value = Now.Date
        DateStart.MaxDate = Now.Date
        dateFin.Value = Now.Date
        dateFin.MaxDate = Now.Date
        ControlBox = False
    End Sub


    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        Dim dsResumenInventarios As New DataSet

        fechaInicio = DateStart.Value.ToShortDateString + " 00:00:00"
        fechaFin = dateFin.Value.ToShortDateString + " 23:59:59"

        fechaInicio = DateTime.Parse(fechaInicio).ToString("dd/MM/yyyy HH:mm:ss")
        fechaFin = DateTime.Parse(fechaFin).ToString("dd/MM/yyyy HH:mm:ss")


        ''LLENA EL DATASET
        'dsResumenInventarios = RecuperarTablasReporteTartaInventarios()
        ''IMPRIME EL REPORTE
        'Imprimir_ReporteIndicadoresDeInventatiosCiclicos(dsResumenInventarios)

        Me.Close()
    End Sub


    ' ''' <summary>
    ' ''' RECUPERA DOS TABLAS QUE SE UTILZARAN EN EL "REPORTE DE INDICADORES DE INVENTARIOS CICLICOS" LA PRIMERA PARA EL 
    ' ''' GRAFICO DE RESULTADOS POR INVENTARIO Y LA SEGUNDA PARA LA GRAFICA DE RESULTADOS POR PARES 
    ' ''' </summary>
    ' ''' <returns>DATASET CON DOS TABLAS PARA LA ELABORACION DE LAS GRAFICAS EN EL REPORTE</returns>
    ' ''' <remarks></remarks>
    'Private Function RecuperarTablasReporteTartaInventarios() As DataSet
    '    Dim dsResumenInventarios As New DataSet
    '    Dim dtInventarios As New DataTable
    '    Dim dtPares As New DataTable
    '    Dim IdInventarios As String
    '    Dim objBU As New Negocios.InventarioCiclicoBU
    '    dtInventarios = objBU.TotaLInventariosLevantados(fechaInicio, fechaFin)
    '    dtInventarios.TableName = "dtInventarios"
    '    'CALCULAR PROCENTAJES DE LAS CANTIDADES OBTENIDAS
    '    For Each row As DataRow In dtInventarios.Rows
    '        If row.Item(0) > 0 Then
    '            SinDiferencias = (100 / row.Item(0) * row.Item(1))
    '            Condiferencias = (100 / row.Item(0) * row.Item(3))
    '            SinDiferencias = Math.Round(SinDiferencias, 2)
    '            Condiferencias = Math.Round(Condiferencias, 2)

    '            row.Item(2) = SinDiferencias
    '            row.Item(4) = Condiferencias
    '        End If
    '    Next

    '    dsResumenInventarios.Tables.Add(dtInventarios)
    '    'Recuperamos los ids de los inventarios ciclicos que estan en estado "Concluido" para recuperar los pares que contiene cada inventario
    '    IdInventarios = objBU.RecuperarIdsInvCi(fechaInicio, fechaFin)
    '    'Consultamos los pares de los inventarios ciclicos recuperados
    '    dtPares = objBU.TotalParesConsultados(IdInventarios)
    '    'CALCULAR PROCENTAJES DE LAS CANTIDADES OBTENIDAS

    '    For Each row As DataRow In dtPares.Rows
    '        If row.Item(0) <> 0 Then
    '            SinDiferencias = (100 / row.Item(0) * row.Item(1))
    '            Condiferencias = (100 / row.Item(0) * row.Item(3))
    '            SinDiferencias = Math.Round(SinDiferencias, 2)
    '            Condiferencias = Math.Round(Condiferencias, 2)
    '            row.Item(2) = SinDiferencias
    '            row.Item(4) = Condiferencias
    '        End If
    '    Next


    '    dtPares.TableName = ("dtPares")
    '    dsResumenInventarios.Tables.Add(dtPares)
    '    Return dsResumenInventarios
    'End Function

    'Public Sub Imprimir_ReporteIndicadoresDeInventatiosCiclicos(ByVal dsResumenInventarios As DataSet)
    '    Dim objBU As New Framework.Negocios.ReportesBU
    '    Dim EntidadReporte As Entidades.Reportes
    '    EntidadReporte = objBU.LeerReporteporClave("ALM_INV_REPORTEINDICADORES")
    '    Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
    '        EntidadReporte.Pnombre + ".mrt"
    '    My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)
    '    Dim reporte As New StiReport
    '    reporte.Load(archivo)
    '    reporte.Compile()
    '    reporte("NombreReporte") = "SAY: REPORTE_DE_INDICADORES_INVCI.mrt"
    '    reporte("Usuario") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername.ToString
    '    reporte("Operador") = NombreOperador
    '    reporte("urlImagenNave") = Tools.Controles.ObtenerLogoNave(idnave)
    '    reporte("nombreNave") = "Comercializadora"
    '    reporte("FechaInicio") = DateStart.Value.ToShortDateString
    '    reporte("FechaFin") = dateFin.Value.ToShortDateString
    '    reporte.Dictionary.Clear()
    '    reporte.RegData(dsResumenInventarios.DataSetName, dsResumenInventarios)
    '    reporte.Dictionary.Synchronize()
    '    reporte.Show()
    '    Me.Cursor = Cursors.Default

    'End Sub


End Class