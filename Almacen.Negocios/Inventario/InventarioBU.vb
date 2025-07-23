

Public Class InventarioBU
    Public Function ListadoInventarioAntiguedad(cedis As Integer) As DataTable

        'Dim TablaDatosInventario As New DataTable
        'Dim ConsultaInvetario As String = String.Empty

        'ConsultaInvetario = "SELECT PE_ID,MarcaSAY as 'Marca',ColeccionSAY as 'Colección',Temporada,ModeloSAY,ModeloSICY,CodigoSICY,Piel,Color,Corrida,Talla,FEntrada,Existencia,DiasAntig "
        'ConsultaInvetario += "FROM Almacen.vInventarioAntiguedad "
        'ConsultaInvetario += "ORDER BY  MarcaSAY,ColeccionSAY,Temporada, ModeloSAY,ModeloSICY,CodigoSICY,Piel,Color,Corrida,Talla,FEntrada DESC "

        'TablaDatosInventario = objbu.ListadoInventarioAntiguedad(ConsultaInvetario)

        Dim objDA As New Almacen.Datos.InventarioDA
        Return objDA.ListadoInventarioAntiguedad(cedis)
    End Function

    Public Function InventarioDisponible(ByVal antiguedad As Integer, ByVal vigentes As Integer, ByVal descontinuados As Integer, ByVal verTalla As Integer,
                                         ByVal familia As String, ByVal marca As String, ByVal coleccion As String, ByVal articulo As String,
                                         ByVal disponible As Integer, ByVal bloqueados As Integer) As DataTable
        Dim obj As New Almacen.Datos.InventarioDA
        Return obj.InventarioDisponible(antiguedad, vigentes, descontinuados, verTalla, familia, marca, coleccion, articulo, disponible, bloqueados)
    End Function
    Public Function ListadoInventario_Antiguo_Prevendido(ByVal cedisId As Integer) As DataTable
        Dim objInventario_DA As New Datos.InventarioDA
        Return objInventario_DA.ListadoInventarioAntiguo_Prevendido(cedisId)
    End Function
    Public Function InventarioDisponibleAG(ByVal antiguedad As Integer, ByVal vigentes As Integer, ByVal descontinuados As Integer, ByVal verTalla As Integer,
                                         ByVal familia As String, ByVal marca As String, ByVal coleccion As String, ByVal articulo As String,
                                         ByVal disponible As Integer, ByVal bloqueados As Integer) As DataTable
        Dim obj As New Almacen.Datos.InventarioDA
        Return obj.InventarioDisponibleAG(antiguedad, vigentes, descontinuados, verTalla, familia, marca, coleccion, articulo, disponible, bloqueados)
    End Function


End Class
