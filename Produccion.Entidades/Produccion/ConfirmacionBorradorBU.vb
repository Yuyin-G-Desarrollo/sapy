Imports Produccion.Datos
Imports Entidades

Public Class ConfirmacionBorradorBU
    Public Function getDatosNave(ByVal idNave As Integer) As DataTable
        Dim obj As New ConfirmacionBorradorDA
        Return obj.getDatosNave(idNave)
    End Function

    Public Sub guardarCortadoresSICY(ByVal tipo As Integer, ByVal nave As Integer, ByVal idPrograma As Integer, ByVal pedido As Integer,
                                  ByVal partida As Integer, ByVal idlote As Integer, ByVal cortadorPiel As Integer,
                                  ByVal cortadorForro As Integer, ByVal idCN As Integer, ByVal cortadorPielSint As Integer,
                                      ByVal cortadorForroSint As Integer, ByVal cortadorPielNombre As String,
                                      ByVal cortadorForroNombre As String, ByVal cortadorPielSintNombre As String,
                                      ByVal cortadorForroSintNombre As String)

        Dim obj As New ConfirmacionBorradorDA
        obj.guardarCortadoresSICY(tipo, nave, idPrograma, pedido, partida, idlote, cortadorPiel, cortadorForro, idCN, cortadorPielSint,
                                     cortadorForroSint, cortadorPielNombre,
                                       cortadorForroNombre, cortadorPielSintNombre,
                                       cortadorForroSintNombre)
    End Sub

    Public Sub guardarCortadoresSAY(ByVal tipo As Integer, ByVal nave As Integer, ByVal idPrograma As Integer, ByVal pedido As Integer,
                                  ByVal partida As Integer, ByVal idlote As Integer, ByVal cortadorPiel As Integer,
                                  ByVal cortadorForro As Integer, ByVal idCN As Integer, ByVal cortadorPielSint As Integer,
                                      ByVal cortadorForroSint As Integer, ByVal cortadorPielNombre As String,
                                      ByVal cortadorForroNombre As String, ByVal cortadorPielSintNombre As String,
                                      ByVal cortadorForroSintNombre As String)

        Dim obj As New ConfirmacionBorradorDA
        obj.guardarCortadoresSAY(tipo, nave, idPrograma, pedido, partida, idlote, cortadorPiel, cortadorForro, idCN, cortadorPielSint,
                                     cortadorForroSint, cortadorPielNombre,
                                       cortadorForroNombre, cortadorPielSintNombre,
                                       cortadorForroSintNombre)
    End Sub

    Public Sub confirmarBorrador(ByVal idPrograma As Integer, ByVal idNave As Integer)
        Dim obj As New ConfirmacionBorradorDA
        obj.confirmarBorrador(idPrograma, idNave)
    End Sub

    Public Function verificarNoCompletarLotesCliente(ByVal idCadena As Integer) As DataTable
        Dim obj As New ConfirmacionBorradorDA
        Return obj.verificarNoCompletarLotesCliente(idCadena)
    End Function

    Public Function getDatosCliente(ByVal idPrograma As Integer, ByVal nave As Integer, ByVal pedido As Integer, ByVal partida As Integer) As DataTable
        Dim obj As New ConfirmacionBorradorDA
        Return obj.getDatosCliente(idPrograma, nave, pedido, partida)
    End Function

    Public Function getDatosConcentrado(ByVal idPrograma As Integer, ByVal nave As Integer, ByVal idConcentrado As Integer) As DataTable
        Dim obj As New ConfirmacionBorradorDA
        Return obj.getDatosConcentrado(idPrograma, nave, idConcentrado)
    End Function

    ' ''' <summary>
    ' ''' Saludos
    ' ''' </summary>
    ' ''' <param name="nave">IdNave Say</param>
    ' ''' <param name="tipo"> 1 piel, 2 forro</param>
    ' ''' <returns></returns>
    ' ''' <remarks></remarks>
    'Public Function getCortadores(ByVal nave As Integer, ByVal tipo As Integer) As DataTable
    '    Dim obj As New ConfirmacionBorradorDA
    '    Return obj.getCortadores(nave, tipo)
    'End Function

    ''' <summary>
    ''' Saludos
    ''' </summary>
    ''' <param name="nave">IdNave Say</param>
    ''' <param name="tipo"> 1 piel, 2 forro</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getCortadores(ByVal nave As Integer, ByVal tipo As Enumerados.TipoCortador) As DataTable
        Dim obj As New ConfirmacionBorradorDA
        Return obj.getCortadores(nave, tipo)
    End Function

    Public Function GetIdPrograma(ByVal nave As Integer, ByVal fecha As String) As DataTable
        Dim obj As New ConfirmacionBorradorDA
        Return obj.GetIdPrograma(nave, fecha)
    End Function

    Public Function getBorrador(ByVal nave As Integer, ByVal idPrograma As Integer) As DataTable
        Dim obj As New ConfirmacionBorradorDA
        Return obj.getBorrador(nave, idPrograma)
    End Function

    Public Function GetEstatusRechazoPrograma(ByVal nave As Integer, ByVal idPrograma As Integer) As DataTable
        Dim obj As New ConfirmacionBorradorDA
        Return obj.GetEstatusRechazoPrograma(nave, idPrograma)
    End Function

    Public Sub RechazarBorrador(ByVal nave As Integer, ByVal idPrograma As Integer, ByVal motivoRechazo As String)
        Dim obj As New ConfirmacionBorradorDA
        obj.RechazarBorrador(nave, idPrograma, motivoRechazo)
    End Sub

    Public Function ConsultarNaveSicy(ByVal naveSay As Integer) As DataTable
        Dim obj As New ConfirmacionBorradorDA
        Return obj.ConsultarNaveSicy(naveSay)
    End Function
End Class
