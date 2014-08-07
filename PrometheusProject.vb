Imports System.Xml
Public Class PrometheusProject
    Public SavedYet As Boolean = False
    Public SavePath As String = "New Project.pmp"
    Public Dirty As Boolean = True
    Public SourceVideoClips As New List(Of VideoSourceClip)
    Public VideoClips As New List(Of VideoClip)
    Public AudioClips As New List(Of AudioClip)
    Public FinalSize As New Size(640, 480)
    Public SourcePath As String = ""
    Public Function BuildFrame(number As Long) As Bitmap
        Dim result As New Bitmap(FinalSize.Width, FinalSize.Height)
        Dim g As Graphics = Graphics.FromImage(result)
        Dim OrderedVideoClips As New List(Of VideoClip)(VideoClips)

        OrderedVideoClips.Sort(Clip.Comparer)

        Dim clipframe As Bitmap
        For Each vc As VideoClip In OrderedVideoClips
            If vc.HitTest(number, False) Then
                clipframe = vc.GetFinalFrame(number - vc.StartFrame)
                g.DrawImage(clipframe, vc.Position.X, vc.Position.Y, clipframe.Width, clipframe.Height)
                clipframe.Dispose()
            End If
        Next
        OrderedVideoClips = Nothing

        g.Dispose()
        Return result
    End Function
    Public Sub New()
    End Sub
    Public Shared Function Load(File As String) As PrometheusProject
        Dim result As New PrometheusProject
        Try
            Dim doc As New XmlDocument
            doc.Load(File)
            Dim project As XmlElement = doc.DocumentElement '= GetChildByName(doc.DocumentElement, "PrometheusProject")
            'Source Videos
            Dim sourcevids As XmlElement = project.Item("SourceVideos")
            For Each sc As XmlElement In sourcevids.ChildNodes
                If sc.Name = "VideoSourceClip" Then
                    Dim newprops As Properties = ReadDataNode(sc.Item("Data"))
                    Dim newsource As New VideoSourceClip(sc.GetAttribute("SourcePath"))
                    newsource.Properties = newprops
                    result.SourceVideoClips.Add(newsource)
                End If
            Next
            'Source Audio

            'Video Clips
            Dim vidclip As XmlElement = project.Item("VideoClips")
            For Each vc As XmlElement In vidclip.ChildNodes
                If vc.Name = "VideoClip" Then
                    Dim newclip As New VideoClip(result.SourceVideoClips(vc.GetAttribute("SourceIndex")), vc.GetAttribute("StartFrame"))
                    newclip.Track = vc.GetAttribute("Track")
                    'newclip.Length = newclip.Length * vc.GetAttribute("Speed")
                    newclip.CropStart = vc.GetAttribute("StartCrop")
                    newclip.CropEnd = vc.GetAttribute("EndCrop")
                    result.VideoClips.Add(newclip)
                    Dim modcollection As XmlElement = vc.Item("Modifiers")
                    For Each mel As XmlElement In modcollection.ChildNodes
                        If mel.Name = "Modifier" Then
                            Dim newmod As IModifierInstance
                            newmod = GetModifier(mel.GetAttribute("ModID")).MakeInstance(newclip)
                            newmod.Properties = ReadDataNode(mel.Item("Data"))
                        End If
                    Next
                End If
            Next
            'Audio Clips

            'Debugger.Break()
            result.SavePath = File
        Catch ex As Exception
            MsgBox("Load failed.")
        End Try
        Return result
    End Function
    Public Sub Save(File As String)
        If IO.File.Exists(File) Then IO.File.Delete(File)
        Try
            Dim doc As New Xml.XmlDocument()
            Dim project As Xml.XmlElement = doc.CreateElement("PrometheusProject")
            project.SetAttribute("FinalSize", Me.FinalSize.Width & "x" & Me.FinalSize.Height)
            project.SetAttribute("SourcePath", Me.SourcePath)
            'Source Videos
            Dim sourcevids As XmlElement = doc.CreateElement("SourceVideos")
            For Each s As VideoSourceClip In Me.SourceVideoClips
                Dim sc As XmlElement = doc.CreateElement("VideoSourceClip")
                sc.SetAttribute("SourcePath", s.Path)
                Dim dataelement As XmlElement = BuildDataNode(doc, s.Properties)
                sc.AppendChild(dataelement)
                sourcevids.AppendChild(sc)
            Next
            project.AppendChild(sourcevids)
            'Source Audio
            Dim sourceaudio As XmlElement = doc.CreateElement("SourceAudio")

            project.AppendChild(sourceaudio)
            'Video Clips
            Dim vidclips As XmlElement = doc.CreateElement("VideoClips")
            For Each vc As VideoClip In VideoClips
                Dim vcnode As XmlElement = doc.CreateElement("VideoClip")
                vcnode.SetAttribute("SourceIndex", GetVideoSource(vc))
                vcnode.SetAttribute("StartFrame", vc.StartFrame)
                vcnode.SetAttribute("Speed", vc.Length / vc.Source.Length)
                vcnode.SetAttribute("StartCrop", vc.CropStart)
                vcnode.SetAttribute("EndCrop", vc.CropEnd)
                vcnode.SetAttribute("Track", vc.Track)
                Dim modcollection As XmlElement = doc.CreateElement("Modifiers")
                For Each m As IModifierInstance In vc.Modifiers
                    Dim modnode As XmlElement = doc.CreateElement("Modifier")
                    modnode.SetAttribute("ModID", m.Source.ID)
                    Dim dataelement As XmlElement = BuildDataNode(doc, m.Properties)
                    modnode.AppendChild(dataelement)
                    modcollection.AppendChild(modnode)
                Next
                vcnode.AppendChild(modcollection)
                vidclips.AppendChild(vcnode)
            Next
            project.AppendChild(vidclips)
            'Audio Clips
            Dim audclips As XmlElement = doc.CreateElement("AudioClips")

            project.AppendChild(audclips)

            doc.AppendChild(project)
            doc.Save(File)
            SavedYet = True
            SavePath = File
        Catch ex As Exception
            Debugger.Break()
        End Try
    End Sub
    Private Shared Function BuildDataNode(Document As XmlDocument, Properties As Properties) As XmlNode
        Dim dataelement As XmlElement = Document.CreateElement("Data")
        For Each DictionaryEntry In Properties.Variables
            Dim dataentry As XmlElement = Document.CreateElement("DataEntry")
            dataentry.SetAttribute("Name", DictionaryEntry.Key)
            dataentry.SetAttribute("Value", DictionaryEntry.Value)
            dataelement.AppendChild(dataentry)
        Next
        Return dataelement
    End Function
    Private Shared Function ReadDataNode(N As XmlElement) As Properties
        Dim result As New Properties
        For Each p As XmlElement In N.ChildNodes
            If p.Name = "DataEntry" Then
                result.SetVar(p.GetAttribute("Name"), p.GetAttribute("Value"))
            End If
        Next
        Return result
    End Function
    Public Function GetVideoSource(clip As VideoClip) As Integer
        If SourceVideoClips.Contains(clip.Source) Then
            Return SourceVideoClips.IndexOf(clip.Source)
        Else
            MsgBox("Source of clip could not be found in the pallete!")
            Return -1
        End If
    End Function
    Public Shared Function GetModifier(Modifier As IModifierSource) As String
        Return Modifier.ID
    End Function
    Public Shared Function GetModifier(ID As String) As IModifierSource
        For Each m As IModifierSource In Plugins.Modifiers
            If m.ID = ID Then
                Return m
            End If
        Next
        Return Nothing
    End Function
End Class
