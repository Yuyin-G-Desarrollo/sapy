Imports Contabilidad.Datos

Public Class EmpresaSAY_SICY_ContpaqBU

    Public Function Consulta_lista_Tipo_Poliza() As DataTable

        Dim objDA As New EmpresaSAY_SICY_ContpaqDA
        Return objDA.Consulta_lista_EmpresaSAY_SICY_Contpaq()

    End Function

    ''' <summary>
    ''' METODO PARA DAR DE ALTA EMPRESAS Ó MODIFICAR INFORMACIÓN EN LA BASE DE DATOS DEL SAY
    ''' </summary>
    ''' <param name="Empresa">OBJETO DE LA ENTIDAD EMPRESA CON LA INFORMACIÓN DE LA EMPRESA A AGREGAR Ó MODIFICAR</param>
    ''' <param name="AltaEdicion">VARIABLE DEL TIPO BOLEANO, SU VALOR TRUE INDICA QUE SE DARA DE ALTA UN REGISTRO, SU VALOR FALSE
    ''' INDICA QUE SE ACTUALIZARA UN REGISTRO</param>
    ''' <remarks></remarks>
    Public Sub Alta_Edicion_EmpresaSAY(ByVal Empresa As Entidades.Empresa, ByVal AltaEdicion As Boolean)
        Dim objDA As New Datos.EmpresaSAY_SICY_ContpaqDA
        objDA.Alta_Edicion_EmpresaSAY(Empresa, AltaEdicion)
    End Sub

    ''' <summary>
    ''' METÓDO PARA AGREGAR REGISTROS Ó EDITAR EN LA TABLA EMPRESASAYSICYCONTPAQ DEL SAY
    ''' </summary>
    ''' <param name="EmpresaSaySicyContpaq">OBJETO DE LA ENTIDAD EmpresaSAY_SICY CON LA INFORMACIÓN NECESARIA PARA EDITAR O
    ''' DAR DE ALTA INFORMACION</param>
    ''' <param name="AltaEdicion">VARIABLE DEL TIPO BOOLEANO, VALOR TRUE INDICA QUE SE HARA UN INSERT, Y SU VALOR FALSE INDICA QUE SE HARA UN UPDATE</param>
    ''' <remarks></remarks>
    Public Sub AltaEdicion_Relacion_EmpresaSAySicyContpaq(ByVal EmpresaSaySicyContpaq As Entidades.EmpresaSAY_SICY, ByVal AltaEdicion As Boolean)
        Dim objDA As New Datos.EmpresaSAY_SICY_ContpaqDA

        objDA.AltaEdicion_Relacion_EmpresaSAySicyContpaq(EmpresaSaySicyContpaq, AltaEdicion)
    End Sub
End Class
