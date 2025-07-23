Imports System.ComponentModel
Imports System.Reflection

Public Class Enumerados
    Public Enum TipoCortador
        <Description("CORTADOR PIEL")>
        PIEL = 2
        <Description("CORTADOR FORRO")>
        FORRO = 3
        <Description("CORTADOR PIEL SINTETICO")>
        PIEL_SINTETICO = 4
        <Description("CORTADOR FORRO SINTETICO")>
        FORRO_SINTETICO = 5
    End Enum

    ''' <summary>
    ''' Obtiene la descripción de los enumerados
    ''' </summary>
    ''' <param name="EnumConstant">Tipo de Enumerado</param>
    ''' <returns>Cadena de la descripción</returns>
    ''' <remarks></remarks>
    Private Function GetEnumDescription(ByVal EnumConstant As [Enum]) As String
        Dim fi As FieldInfo = EnumConstant.GetType().GetField(EnumConstant.ToString())
        Dim attr() As DescriptionAttribute = _
                      DirectCast(fi.GetCustomAttributes(GetType(DescriptionAttribute), _
                      False), DescriptionAttribute())

        If attr.Length > 0 Then
            Return attr(0).Description
        Else
            Return EnumConstant.ToString()
        End If
    End Function
End Class
