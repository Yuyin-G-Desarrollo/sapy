﻿'------------------------------------------------------------------------------
' <auto-generated>
'     Este código fue generado por una herramienta.
'     Versión de runtime:4.0.30319.42000
'
'     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
'     se vuelve a generar el código.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict Off
Option Explicit On

Imports System
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Xml.Serialization

'
'Microsoft.VSDesigner generó automáticamente este código fuente, versión=4.0.30319.42000.
'
Namespace mx.com.paxfacturacion.test
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4161.0"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code"),  _
     System.Web.Services.WebServiceBindingAttribute(Name:="wcfRecepcionASMXSoap", [Namespace]:="https://test.paxfacturacion.com.mx:453")>  _
    Partial Public Class wcfRecepcionASMX
        Inherits System.Web.Services.Protocols.SoapHttpClientProtocol
        
        Private fnEnviarXMLOperationCompleted As System.Threading.SendOrPostCallback
        
        Private useDefaultCredentialsSetExplicitly As Boolean
        
        '''<remarks/>
        Public Sub New()
            MyBase.New
            Me.Url = Global.Facturacion.Negocios.My.MySettings.Default.Facturacion_Negocios_mx_com_paxfacturacion_test_wcfRecepcionASMX
            If (Me.IsLocalFileSystemWebService(Me.Url) = true) Then
                Me.UseDefaultCredentials = true
                Me.useDefaultCredentialsSetExplicitly = false
            Else
                Me.useDefaultCredentialsSetExplicitly = true
            End If
        End Sub
        
        Public Shadows Property Url() As String
            Get
                Return MyBase.Url
            End Get
            Set
                If (((Me.IsLocalFileSystemWebService(MyBase.Url) = true)  _
                            AndAlso (Me.useDefaultCredentialsSetExplicitly = false))  _
                            AndAlso (Me.IsLocalFileSystemWebService(value) = false)) Then
                    MyBase.UseDefaultCredentials = false
                End If
                MyBase.Url = value
            End Set
        End Property
        
        Public Shadows Property UseDefaultCredentials() As Boolean
            Get
                Return MyBase.UseDefaultCredentials
            End Get
            Set
                MyBase.UseDefaultCredentials = value
                Me.useDefaultCredentialsSetExplicitly = true
            End Set
        End Property
        
        '''<remarks/>
        Public Event fnEnviarXMLCompleted As fnEnviarXMLCompletedEventHandler
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("https://test.paxfacturacion.com.mx:453/fnEnviarXML", RequestNamespace:="https://test.paxfacturacion.com.mx:453", ResponseNamespace:="https://test.paxfacturacion.com.mx:453", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function fnEnviarXML(ByVal psComprobante As String, ByVal psTipoDocumento As String, ByVal pnId_Estructura As Integer, ByVal sNombre As String, ByVal sContraseña As String, ByVal sVersion As String) As String
            Dim results() As Object = Me.Invoke("fnEnviarXML", New Object() {psComprobante, psTipoDocumento, pnId_Estructura, sNombre, sContraseña, sVersion})
            Return CType(results(0),String)
        End Function
        
        '''<remarks/>
        Public Overloads Sub fnEnviarXMLAsync(ByVal psComprobante As String, ByVal psTipoDocumento As String, ByVal pnId_Estructura As Integer, ByVal sNombre As String, ByVal sContraseña As String, ByVal sVersion As String)
            Me.fnEnviarXMLAsync(psComprobante, psTipoDocumento, pnId_Estructura, sNombre, sContraseña, sVersion, Nothing)
        End Sub
        
        '''<remarks/>
        Public Overloads Sub fnEnviarXMLAsync(ByVal psComprobante As String, ByVal psTipoDocumento As String, ByVal pnId_Estructura As Integer, ByVal sNombre As String, ByVal sContraseña As String, ByVal sVersion As String, ByVal userState As Object)
            If (Me.fnEnviarXMLOperationCompleted Is Nothing) Then
                Me.fnEnviarXMLOperationCompleted = AddressOf Me.OnfnEnviarXMLOperationCompleted
            End If
            Me.InvokeAsync("fnEnviarXML", New Object() {psComprobante, psTipoDocumento, pnId_Estructura, sNombre, sContraseña, sVersion}, Me.fnEnviarXMLOperationCompleted, userState)
        End Sub
        
        Private Sub OnfnEnviarXMLOperationCompleted(ByVal arg As Object)
            If (Not (Me.fnEnviarXMLCompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg,System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent fnEnviarXMLCompleted(Me, New fnEnviarXMLCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
            End If
        End Sub
        
        '''<remarks/>
        Public Shadows Sub CancelAsync(ByVal userState As Object)
            MyBase.CancelAsync(userState)
        End Sub
        
        Private Function IsLocalFileSystemWebService(ByVal url As String) As Boolean
            If ((url Is Nothing)  _
                        OrElse (url Is String.Empty)) Then
                Return false
            End If
            Dim wsUri As System.Uri = New System.Uri(url)
            If ((wsUri.Port >= 1024)  _
                        AndAlso (String.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) = 0)) Then
                Return true
            End If
            Return false
        End Function
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4161.0")>  _
    Public Delegate Sub fnEnviarXMLCompletedEventHandler(ByVal sender As Object, ByVal e As fnEnviarXMLCompletedEventArgs)
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4161.0"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code")>  _
    Partial Public Class fnEnviarXMLCompletedEventArgs
        Inherits System.ComponentModel.AsyncCompletedEventArgs
        
        Private results() As Object
        
        Friend Sub New(ByVal results() As Object, ByVal exception As System.Exception, ByVal cancelled As Boolean, ByVal userState As Object)
            MyBase.New(exception, cancelled, userState)
            Me.results = results
        End Sub
        
        '''<remarks/>
        Public ReadOnly Property Result() As String
            Get
                Me.RaiseExceptionIfNecessary
                Return CType(Me.results(0),String)
            End Get
        End Property
    End Class
End Namespace
