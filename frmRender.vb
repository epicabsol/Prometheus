Imports System.Threading
Public Class frmRender
    Private RenderThreadEven As Thread
    Private RenderThreadOdd As Thread
    Private ThreadCount As Integer
    Private Sub frmRender_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If RenderFormats.RenderFormats.Count = 0 Then
            MsgBox("No Render Formas installed! " & vbNewLine & "What happened to the default plugin!!!")
            Close()
        End If
        For Each Format As RenderFormat In RenderFormats.RenderFormats
            ComboBox1.Items.Add(Format.ExtensionTitle & " (*" & Format.Extension & ")")
        Next
        ComboBox1.SelectedIndex = 0
        txtWidth.Text = frmMain.Project.FinalSize.Width
        txtHeight.Text = frmMain.Project.FinalSize.Height
    End Sub

    Private Sub cmdClose_Click(sender As Object, e As EventArgs) Handles cmdClose.Click
        If cmdClose.Enabled Then
            Close()
        End If
    End Sub
    Private Function GetCurrentFormat() As RenderFormat
        Return RenderFormats.RenderFormats(ComboBox1.SelectedIndex)
    End Function
    Private Sub cmdFormatOptions_Click(sender As Object, e As EventArgs) Handles cmdFormatOptions.Click
        frmPropertyEditor.ShowDialog(GetCurrentFormat.Properties, GetCurrentFormat.ExtensionTitle & " Renderer Properties")
    End Sub
    Private Sub RefreshProgress()
        XenonProgressBar1.Value = _FramesComplete
        If _OddThreadDone And _EvenThreadDone Then
            _Rendering = False
            XenonProgressBar1.Value = 0
            XenonProgressBar1.Max = 100
            cmdRender.Text = "Render"
            cmdClose.Enabled = True
            'frmMain.Project.FinalSize = _OldSize
            _RenderFormat.Cleanup()
        End If
    End Sub
    Private Sub XenonButton3_Click(sender As Object, e As EventArgs) Handles XenonButton3.Click
        Dim browser As New SaveFileDialog()
        browser.Filter = BuildRenderFilter()
        browser.ShowDialog()
        If browser.FileName = "" Then Exit Sub
        txtPath.Text = browser.FileName
    End Sub

#Region "Rendering"
    Public Sub StartRender()
        _PleaseStop = False
        _OldSize = frmMain.Project.FinalSize
        _RenderPath = txtPath.Text
        frmMain.Project.FinalSize = New Size(txtWidth.Text, txtHeight.Text)
        _RenderFormat = GetCurrentFormat()
        _RenderFormat.InitFile(_RenderPath, frmMain.Project.FinalSize)
        RenderThreadEven = New Thread(AddressOf RenderEven)
        RenderThreadOdd = New Thread(AddressOf RenderOdd)
        _FramesComplete = 0
        _Project = frmMain.Project
        _Rendering = True
        XenonProgressBar1.Max = frmMain.Length
        RenderThreadEven.Start()
        RenderThreadOdd.Start()
    End Sub
    Private _Project As PrometheusProject
    Private _RenderPath As String = ""
    Private _FramesComplete As Long = 0
    Private _RenderFormat As RenderFormat
    Private _Rendering As Boolean = False
    Private _EvenThreadDone As Boolean = False
    Private _OddThreadDone As Boolean = False
    Private _OldSize As Size
    Private _PleaseStop As Boolean = False
    Private Sub RenderEven()
        _EvenThreadDone = False
        For i As Long = 0 To frmMain.Length - 1 Step 2
            _RenderFormat.AddFrame(_Project.BuildFrame(i), i)
            _FramesComplete += 1
            Invoke(New Action(AddressOf RefreshProgress))
            If _PleaseStop Then Exit For
        Next
        _EvenThreadDone = True
        Invoke(New Action(AddressOf RefreshProgress))
    End Sub
    Private Sub RenderOdd()
        _OddThreadDone = False
        For i As Long = 1 To frmMain.Length - 1 Step 2
            _RenderFormat.AddFrame(_Project.BuildFrame(i), i)
            _FramesComplete += 1
            Invoke(New Action(AddressOf RefreshProgress))
            If _PleaseStop Then Exit For
        Next
        _OddThreadDone = True
        Invoke(New Action(AddressOf RefreshProgress))
    End Sub
    Private Sub cmdRender_Click(sender As Object, e As EventArgs) Handles cmdRender.Click
        If Not _Rendering Then
            If txtPath.Text <> "" Then
                StartRender()
                cmdRender.Text = "Cancel"
                cmdClose.Enabled = False
            End If
        Else
            _PleaseStop = True
        End If
    End Sub
#End Region
End Class