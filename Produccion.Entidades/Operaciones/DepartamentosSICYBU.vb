Imports Produccion.Datos
Imports Entidades

''' <summary>
''' 
''' </summary>
''' <remarks></remarks>
Public Class DepartamentosSICYBU

    Public Function ListaProgramasNave(ByVal idnave As Integer, ByVal FechaInicial As Date, ByVal FechaFinal As Date) As DataTable
        Dim objDA As New DepartamentosSICYDA
        Dim tabla As New DataTable
        ListaProgramasNave = New DataTable
        tabla = objDA.ListaProgramasNave(idnave, FechaInicial, FechaFinal)
        If tabla.Rows.Count > 0 Then
            ListaProgramasNave = tabla
        End If
    End Function

    Public Function ListaDepartamentosSegunNave(ByVal idnave As Integer) As List(Of Departamentos)
        Dim objDA As New DepartamentosSICYDA
        Dim tabla As New DataTable
        ListaDepartamentosSegunNave = New List(Of Departamentos)
        tabla = objDA.ListaDepartamentosSegunNaves(idnave)
        For Each fila As DataRow In tabla.Rows
            Dim deptop As New Departamentos
            deptop.DNombre = CStr(fila("Departamento"))
            deptop.Ddepartamentoid = CInt(fila("IdDepartamento"))
            ListaDepartamentosSegunNave.Add(deptop)
        Next
    End Function

    Public Function ListaDepartamentosSegunNaveProduccion(ByVal idnave As Integer) As List(Of DepartamentosProduccion)
        Dim objDA As New DepartamentosSICYDA
        Dim tabla As New DataTable
        ListaDepartamentosSegunNaveProduccion = New List(Of DepartamentosProduccion)
        tabla = objDA.ListaDepartamentosSegunNavesProduccion(idnave)
        For Each fila As DataRow In tabla.Rows
            Dim deptop As New DepartamentosProduccion
            deptop.PNombre = CStr(fila("Departamento"))
            deptop.PColorDepartamento = CStr(fila("Color"))
            deptop.PIDConfiguracion = CInt(fila("IdDepartamento"))
            deptop.PDias = CInt(fila("DiasProceso"))
            ListaDepartamentosSegunNaveProduccion.Add(deptop)
        Next
    End Function


    Public Function ListaCelulasSegunDepartamentoSICY(ByVal idnave As Integer, ByVal idConfiguracion As Int32) As List(Of DepartamentosProduccion)
        Dim objDA As New DepartamentosSICYDA
        Dim tabla As New DataTable
        ListaCelulasSegunDepartamentoSICY = New List(Of DepartamentosProduccion)
        tabla = objDA.ListaCelulasSegunDepartamentoSICY(idnave, idConfiguracion)
        For Each fila As DataRow In tabla.Rows
            Dim deptop As New DepartamentosProduccion
            deptop.PNombre = CStr(fila("Celula"))
            ListaCelulasSegunDepartamentoSICY.Add(deptop)
        Next
    End Function




    Public Function InfoAvancesProgramaPares(ByVal vNave As Int32, ByVal vFecha As Date, ByVal vTipo As String, ByVal vValor As String) As Long
        Dim objDA As New DepartamentosSICYDA
        Dim ValorBuscado As Long
        InfoAvancesProgramaPares = 0

        ValorBuscado = objDA.BuscarValoresResumenPrograma(vNave, vFecha, vTipo, vValor)

        If ValorBuscado > 0 Then
            InfoAvancesProgramaPares = ValorBuscado
        End If

    End Function

    Public Function ListaCelulasSegunNaveDepto(ByVal idnave As Integer, ByVal iddepto As Integer) As List(Of Celulas)
        Dim objDA As New DepartamentosSICYDA
        Dim tabla As New DataTable
        ListaCelulasSegunNaveDepto = New List(Of Celulas)
        tabla = objDA.ListaCelulasSegunNaveDepto(idnave, iddepto)
        For Each fila As DataRow In tabla.Rows
            Dim celul As New Celulas
            celul.PNombre = CStr(fila("Celula"))
            celul.PCelulaid = CInt(fila("IdCelula"))
            ListaCelulasSegunNaveDepto.Add(celul)
        Next
    End Function
    Public Function ListaCelulasSegunNaveDepto2(ByVal idnave As Integer, ByVal iddepto As Integer, ByVal conDep As Boolean) As List(Of Celulas)
        Dim objDA As New DepartamentosSICYDA
        Dim tabla As New DataTable
        ListaCelulasSegunNaveDepto2 = New List(Of Celulas)
        tabla = objDA.ListaCelulasSegunNaveDepto2(idnave, iddepto, conDep)
        For Each fila As DataRow In tabla.Rows
            Dim celul As New Celulas
            celul.PNombre = CStr(fila("Celula"))
            celul.PCelulaid = CInt(fila("IdCelula"))
            ListaCelulasSegunNaveDepto2.Add(celul)
        Next
    End Function

    Public Function listaNave(ByVal idnave As Int32) As Naves
        Dim objDA As New DepartamentosSICYDA
        Dim tabla As New DataTable
        listaNave = New Naves
        tabla = objDA.UbicarNave(idnave)
        For Each fila As DataRow In tabla.Rows
            Dim nave As New Naves

            nave.PNaveId = CInt(fila("nave_naveid"))
            nave.PNombre = CStr(fila("nave_nombre"))
            nave.PActivo = CBool(fila("nave_activo"))
            nave.PNaveSICYid = CInt(fila("nave_navesicyid"))

            listaNave = nave

        Next
    End Function

End Class
