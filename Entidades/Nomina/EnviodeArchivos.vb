Imports System.IO

Public Class EnviodeArchivos
    Dim Ruta As String = "\\192.168.2.54\YuyinERP\" '"C:\YuyinERP\"


    Dim _Message As String = String.Empty
    Public Property Message() As String
        Get
            Return _Message
        End Get
        Set(ByVal value As String)
            If _Message <> value Then
                _Message = value
            End If
        End Set
    End Property



    Public Sub EnviarArchivo(ByVal CarpetaDestino As String, ByVal archivo As String)

        Try

            Dim Carpeta As String = String.Empty

            Carpeta = Path.Combine(Ruta, CarpetaDestino)

            If permisosAcceso(Ruta) = True Then

                If Directory.Exists(Carpeta) = False Then

                    Directory.CreateDirectory(Carpeta)
                End If

                File.Copy(archivo, Path.Combine(Carpeta, Path.GetFileName(archivo)), True)
            Else
                Message = "No tiene permisos sobre la carpeta Origen "
            End If

        Catch ex As Exception
            Message = Message + "Ocurrio el siguiente error: " + ex.Message + " Origen: " + ex.Source + " "
        End Try


    End Sub




    Private Function permisosAcceso(ByVal ruta As String) As Boolean

        permisosAcceso = False

        Try
            Dim fs As FileStream = File.Create(Path.Combine(ruta, "accesstemp.txt"), 1, FileOptions.DeleteOnClose)
            fs.Close()
            permisosAcceso = True
        Catch ex As Exception
            permisosAcceso = False
        End Try

    End Function


End Class
