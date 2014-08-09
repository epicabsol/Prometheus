Imports System.ComponentModel
Imports System.ComponentModel.Composition
Imports System.ComponentModel.Composition.Hosting
Public MustInherit Class Plugin
    Public MustOverride Sub Init(Registrar As Registrar)
    Public MustOverride Function GetAuthor() As String
    Public MustOverride Function GetName() As String
    Public Path As String
End Class


Public Module Plugins
    Public Modifiers As New List(Of IModifierSource)
    Public Generators As New List(Of Generator)
    Public Registrar As New Registrar
    Private _plugins As New List(Of Plugin)
    Public ReadOnly Property Plugins As List(Of Plugin)
        Get
            Return _plugins
        End Get
    End Property
    Private Manager As New PluginManager
    Public Sub LoadPlugins()
        Manager.LoadPlugins()
    End Sub
End Module

Friend Class PluginManager
    Private Container As CompositionContainer
    <ImportMany> _
    Public _plugins As New List(Of Lazy(Of Plugin))
    Public Sub LoadPlugins()
        Dim catalog As New AggregateCatalog
        catalog.Catalogs.Add(New AssemblyCatalog(GetType(Plugins).Assembly))
        If Not IO.Directory.Exists("plugins\") Then
            IO.Directory.CreateDirectory("plugins\")
        End If
        catalog.Catalogs.Add(New DirectoryCatalog("plugins\"))
        Container = New CompositionContainer(catalog)
        Try
            Container.ComposeParts(Me)
        Catch ex As Exception
            MsgBox("Error loading extensions." & vbNewLine & vbNewLine & "Error details: " & ex.ToString)
        End Try
        Plugins.Plugins.Clear()
        For Each p As Lazy(Of Plugin) In _plugins
            MsgBox("Plugin """ & p.Value.GetName & """ loaded.")
            Plugins.Plugins.Add(p.Value)
        Next
        For Each p As Plugin In Plugins.Plugins
            p.Init(Plugins.Registrar)
        Next
    End Sub
End Class

Public Class Registrar
    Public Sub RegisterModifier(Modifier As IModifierSource)
        If Not Modifiers.Contains(Modifier) Then
            Modifiers.Add(Modifier)
        End If
    End Sub
    Public Sub RegisterGenerator(Generator As IGenerator)
        If Not Generators.Contains(Generator) Then
            Generators.Add(Generator)
        End If
    End Sub
    Public Sub RegisterSourceLoader(Extension As String, FormatDescription As String, Loader As SourceLoader)
        Loaders.RegisterLoader(Extension, FormatDescription, Loader)
    End Sub
    Public Sub RegisterRenderFormat(RenderFormat As RenderFormat)
        RenderFormats.RegisterRenderFormat(RenderFormat)
    End Sub
End Class