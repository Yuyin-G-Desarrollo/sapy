Imports Entidades
Imports Framework.Negocios
Imports Produccion.Negocios


Public Class Controles
    Public Shared Function ComboDepartamentosSegunNave(ByVal ComboEntrada As System.Windows.Forms.ComboBox, ByVal idnave As Int32) As System.Windows.Forms.ComboBox

        ComboDepartamentosSegunNave = New ComboBox
        ComboDepartamentosSegunNave = ComboEntrada
        Dim tabladepartamentos As New List(Of Departamentos)
        Dim objdeptoBU As New DepartamentosSICYBU
        Dim i As Integer = 1

        tabladepartamentos = objdeptoBU.ListaDepartamentosSegunNave(idnave)

        tabladepartamentos.Insert(0, New Departamentos)

        Dim objDepto As New Departamentos
        objDepto.DNombre = "EMBARQUE"
        objDepto.Ddepartamentoid = 999
        tabladepartamentos.Insert(tabladepartamentos.Count, objDepto)


        If tabladepartamentos.Count > 0 Then
            ComboDepartamentosSegunNave.DataSource = tabladepartamentos
            ComboDepartamentosSegunNave.DisplayMember = "Dnombre"
            ComboDepartamentosSegunNave.ValueMember = "Ddepartamentoid"
            i = tabladepartamentos.Count
        End If

        ComboDepartamentosSegunNave.SelectedIndex = 0

    End Function

    Public Shared Function ComboDepartamentosSegunNaveProduccion(ByVal ComboEntrada As System.Windows.Forms.ComboBox, ByVal idnave As Int32) As System.Windows.Forms.ComboBox

        ComboDepartamentosSegunNaveProduccion = New ComboBox
        ComboDepartamentosSegunNaveProduccion = ComboEntrada
        Dim tabladepartamentos As New List(Of DepartamentosProduccion)
        Dim objdeptoBU As New DepartamentosSICYBU
        Dim i As Integer = 1

        tabladepartamentos = objdeptoBU.ListaDepartamentosSegunNaveProduccion(idnave)

        tabladepartamentos.Insert(0, New DepartamentosProduccion)

        Dim objDepto As New DepartamentosProduccion
        objDepto.PNombre = "EMBARQUE"
        objDepto.PIDConfiguracion = 999
        tabladepartamentos.Insert(tabladepartamentos.Count, objDepto)


        If tabladepartamentos.Count > 0 Then
            ComboDepartamentosSegunNaveProduccion.DataSource = tabladepartamentos
            ComboDepartamentosSegunNaveProduccion.DisplayMember = "PNombre"
            ComboDepartamentosSegunNaveProduccion.ValueMember = "PIDConfiguracion"
            i = tabladepartamentos.Count
        End If

        ComboDepartamentosSegunNaveProduccion.SelectedIndex = 0

    End Function


    Public Shared Function ComboCelulasSegunDepartamento(ByVal ComboEntrada As System.Windows.Forms.ComboBox, ByVal idnave As Int32, ByVal iddepto As Int32) As System.Windows.Forms.ComboBox
        ComboCelulasSegunDepartamento = New ComboBox
        ComboCelulasSegunDepartamento = ComboEntrada
        Dim tablaCelulas As New List(Of Celulas)
        Dim objCelulasBU As New DepartamentosSICYBU

        Dim objNaveSicy As New Naves
        objNaveSicy = objCelulasBU.listaNave(idnave)

        tablaCelulas = objCelulasBU.ListaCelulasSegunNaveDepto(objNaveSicy.PNaveSICYid, iddepto)

        tablaCelulas.Insert(0, New Celulas)

        If tablaCelulas.Count > 0 Then
            ComboCelulasSegunDepartamento.DataSource = tablaCelulas
            ComboCelulasSegunDepartamento.DisplayMember = "PNombre"
            ComboCelulasSegunDepartamento.ValueMember = "PCelulaid"
        End If

    End Function


    Public Shared Function ComboCelulasSegunDepartamentoProduccion(ByVal ComboEntrada As System.Windows.Forms.ComboBox, ByVal idnave As Int32, ByVal iddepto As Int32) As System.Windows.Forms.ComboBox
        ComboCelulasSegunDepartamentoProduccion = New ComboBox
        ComboCelulasSegunDepartamentoProduccion = ComboEntrada
        Dim tablaCelulas As New List(Of Celulas)
        Dim objCelulasBU As New DepartamentosSICYBU

        Dim objNaveSicy As New Naves
        objNaveSicy = objCelulasBU.listaNave(idnave)

        tablaCelulas = objCelulasBU.ListaCelulasSegunNaveDepto(objNaveSicy.PNaveSICYid, iddepto)

        tablaCelulas.Insert(0, New Celulas)
        Dim Noasignada As New Celulas
        Noasignada.PNombre = "NO ASIGNADA"

        tablaCelulas.Insert(tablaCelulas.Count, Noasignada)
        If tablaCelulas.Count > 0 Then
            ComboCelulasSegunDepartamentoProduccion.DataSource = tablaCelulas
            ComboCelulasSegunDepartamentoProduccion.DisplayMember = "PNombre"
            ComboCelulasSegunDepartamentoProduccion.ValueMember = "PCelulaid"
        End If
   




    End Function





    Public Shared Function ComboNavesSegunUsuario(ByVal ComboEntrada As System.Windows.Forms.ComboBox, ByVal IDUsuario As Int32) As System.Windows.Forms.ComboBox
        ComboNavesSegunUsuario = New ComboBox
        ComboNavesSegunUsuario = ComboEntrada
        Dim tablaNaves As New List(Of Naves)
        Dim objNavesBU As New Framework.Negocios.NavesBU
        tablaNaves = objNavesBU.ListaNavesSICYSegunUsuario("", IDUsuario)
        'tablaNaves = objNavesBU.ListaNavesSegunUsuarioConIdSicy(IDUsuario)
        tablaNaves.Insert(0, New Naves)
        If tablaNaves.Count > 0 Then
            ComboNavesSegunUsuario.DataSource = tablaNaves
            ComboNavesSegunUsuario.DisplayMember = "PNombre"
            ComboNavesSegunUsuario.ValueMember = "PNaveSICYid"
        End If

        If tablaNaves.Count = 1 Then
            ComboNavesSegunUsuario.SelectedIndex = 0
            ComboNavesSegunUsuario.Enabled = False
        End If

        If tablaNaves.Count > 1 Then
            ComboNavesSegunUsuario.SelectedIndex = 0
        End If

    End Function


    Public Shared Function ComboDepartamentosSegunNaveProduccionV2(ByVal ComboEntrada As System.Windows.Forms.ComboBox, ByVal idnave As Int32) As System.Windows.Forms.ComboBox

        ComboDepartamentosSegunNaveProduccionV2 = New ComboBox
        ComboDepartamentosSegunNaveProduccionV2 = ComboEntrada
        Dim tabladepartamentos As New List(Of DepartamentosProduccion)
        Dim objdeptoBU As New DepartamentosSICYBU
        Dim i As Integer = 1

        tabladepartamentos = objdeptoBU.ListaDepartamentosSegunNaveProduccion(idnave)

        tabladepartamentos.Insert(0, New DepartamentosProduccion)

      


        If tabladepartamentos.Count > 0 Then
            ComboDepartamentosSegunNaveProduccionV2.DataSource = tabladepartamentos
            ComboDepartamentosSegunNaveProduccionV2.DisplayMember = "PNombre"
            ComboDepartamentosSegunNaveProduccionV2.ValueMember = "PIDConfiguracion"
            i = tabladepartamentos.Count
        End If

        ComboDepartamentosSegunNaveProduccionV2.SelectedIndex = 0

    End Function


End Class
