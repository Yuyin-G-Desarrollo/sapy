Imports System.IO
Imports System.DirectoryServices

Public Class EnviodeArchivosBU
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
            'Dim domainAndUsername As String = "prod" & "\" & "yuyinerp"
            'Dim entry As DirectoryEntry = New DirectoryEntry(_path, domainAndUsername, pwd)

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


    Public Sub EnvioArchivoBD(ByVal Archivos As Entidades.ColaboradorExpediente, ByVal ColaboradorID As Int32, ByVal Archivo As String)
        Dim ObjDA As New Datos.ArchivosDA
        ObjDA.EnviarArchivos(Archivos, ColaboradorID, Archivo)
    End Sub

    Public Sub EliminarArchivoBD(ByVal archivoid As Int32)
        Dim ObjDA As New Datos.ArchivosDA
        ObjDA.EliminarArchivoColaborador(archivoid)
    End Sub

    Public Function ListaColaboradorArchivos(ByVal colaboradorId As Int32) As List(Of Entidades.ColaboradorExpediente)
        Dim objDA As New Datos.ArchivosDA
        Dim tableArchivos As New DataTable
        ListaColaboradorArchivos = New List(Of Entidades.ColaboradorExpediente)
        tableArchivos = objDA.BuscarArchivosColaborador(colaboradorId)
        For Each row As DataRow In tableArchivos.Rows
            Dim objArchivo As New Entidades.ColaboradorExpediente


            objArchivo.PColaboradorID = CInt(row("cexp_colaboradorid"))
            objArchivo.PNombreArchivo = CStr(row("cexp_nombrearchivo"))
            objArchivo.PCarpeta = CStr(row("cexp_carpeta"))
            objArchivo.PCredencial = CStr(row("cexp_credencial"))
            objArchivo.Ptitulo = CStr(row("cexp_titulo"))
            objArchivo.PArchivoId = CInt(row("cexp_expedienteid"))
            ListaColaboradorArchivos.Add(objArchivo)
        Next
        Return ListaColaboradorArchivos


    End Function

    Public Function CredencialColaborador(ByVal Colaborador As Int32) As Entidades.ColaboradorExpediente
        Dim objDA As New Datos.ArchivosDA
        Dim tablaArchivos As New DataTable
        CredencialColaborador = New Entidades.ColaboradorExpediente
        tablaArchivos = objDA.BuscarCredencialColaborador(Colaborador)
        For Each row As DataRow In tablaArchivos.Rows
            Dim objArchivo As New Entidades.ColaboradorExpediente

            objArchivo.PCarpeta = CStr(row("cexp_carpeta"))
            objArchivo.PNombreArchivo = CStr(row("cexp_nombrearchivo"))
            Return objArchivo
        Next

    End Function


    Public Sub DescargarArchivo(ByVal carpetaOrigen As String, ByVal CarpetaDestino As String, ByVal archivo As String)

        Dim CadenaErrores As String = String.Empty

        Try

            Dim Carpeta As String = String.Empty

            Carpeta = Path.Combine(Ruta, carpetaOrigen)


            If permisosAcceso(Ruta) = True Then

                If Directory.Exists(Carpeta) = True Then
                    If File.Exists(Path.Combine(Carpeta, archivo)) = True Then

                        If Directory.Exists(CarpetaDestino) = False Then
                            Directory.CreateDirectory(CarpetaDestino)
                        End If

                        If permisosAcceso(CarpetaDestino) = True Then
                            File.Copy(Path.Combine(Carpeta, archivo), Path.Combine(CarpetaDestino, archivo), True)
                        Else
                            Message = "No tiene permisos sobre la carpeta Destino "
                        End If

                    Else
                        Message = "No existe el archivo solicitado "
                    End If
                    'Directory.CreateDirectory(Carpeta)
                Else
                    Message = "No existe la carpeta Origen "
                End If

            Else
                Message = "No tiene permisos sobre la carpeta Origen "
            End If


        Catch ex As Exception
            Message = Message = +"Ocurrio el siguiente error: " + ex.Message + " Origen: " + ex.Source + " "
        End Try


    End Sub


End Class
