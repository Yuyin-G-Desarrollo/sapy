﻿'------------------------------------------------------------------------------
' <auto-generated>
'     Este código fue generado por una herramienta.
'     Versión de runtime:4.0.30319.42000
'
'     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
'     se vuelve a generar el código.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On


Namespace My
    
    <Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute(),  _
     Global.System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "17.10.0.0"),  _
     Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
    Partial Friend NotInheritable Class MySettings
        Inherits Global.System.Configuration.ApplicationSettingsBase
        
        Private Shared defaultInstance As MySettings = CType(Global.System.Configuration.ApplicationSettingsBase.Synchronized(New MySettings()),MySettings)
        
#Region "Funcionalidad para autoguardar My.Settings"
#If _MyType = "WindowsForms" Then
    Private Shared addedHandler As Boolean

    Private Shared addedHandlerLockObject As New Object

    <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)> _
    Private Shared Sub AutoSaveSettings(sender As Global.System.Object, e As Global.System.EventArgs)
        If My.Application.SaveMySettingsOnExit Then
            My.Settings.Save()
        End If
    End Sub
#End If
#End Region
        
        Public Shared ReadOnly Property [Default]() As MySettings
            Get
                
#If _MyType = "WindowsForms" Then
               If Not addedHandler Then
                    SyncLock addedHandlerLockObject
                        If Not addedHandler Then
                            AddHandler My.Application.Shutdown, AddressOf AutoSaveSettings
                            addedHandler = True
                        End If
                    End SyncLock
                End If
#End If
                Return defaultInstance
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Data Source=192.168.2.5;Initial Catalog=Yuyin_Respaldo;Pooling=true;Max Pool Size"& _ 
            "=100;Min Pool Size=1;User ID=sa;Password=poder335")>  _
        Public ReadOnly Property CadenaConexionPoolSICYTEST() As String
            Get
                Return CType(Me("CadenaConexionPoolSICYTEST"),String)
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Data Source=192.168.2.2;Initial Catalog=YuyinERP;Pooling=true;Max Pool Size=100;M"& _ 
            "in Pool Size=1;User ID=say;Password=Yuyin2017")>  _
        Public ReadOnly Property CadenaConexionPool() As String
            Get
                Return CType(Me("CadenaConexionPool"),String)
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Data Source=192.168.2.2;Initial Catalog=Yuyin_Respaldo;Pooling=true;Max Pool Size"& _ 
            "=100;Min Pool Size=1;User ID=sicy_app;Password=Yuyin2019")>  _
        Public ReadOnly Property CadenaConexionPoolSICY() As String
            Get
                Return CType(Me("CadenaConexionPoolSICY"),String)
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Data Source=192.168.2.5;Initial Catalog=YuyinERP;Pooling=true;Max Pool Size=100;M"& _ 
            "in Pool Size=1;User ID=sa;Password=poder335")>  _
        Public ReadOnly Property CadenaConexionPoolPruebas() As String
            Get
                Return CType(Me("CadenaConexionPoolPruebas"),String)
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Data Source=192.168.20.227\COMPAC;Initial Catalog=master;Pooling=true;Max Pool Si"& _ 
            "ze=100;Min Pool Size=1;User ID=sa;Password=Poder335")>  _
        Public ReadOnly Property CadenaConexionContpaq() As String
            Get
                Return CType(Me("CadenaConexionContpaq"),String)
            End Get
        End Property
    End Class
End Namespace

Namespace My
    
    <Global.Microsoft.VisualBasic.HideModuleNameAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute()>  _
    Friend Module MySettingsProperty
        
        <Global.System.ComponentModel.Design.HelpKeywordAttribute("My.Settings")>  _
        Friend ReadOnly Property Settings() As Global.Persistencia.My.MySettings
            Get
                Return Global.Persistencia.My.MySettings.Default
            End Get
        End Property
    End Module
End Namespace
