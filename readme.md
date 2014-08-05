Prometheus
==========

About
-----

Prometheus is my attempt at a nonlinear video editor in VB.NET. (Please don't laugh.)
At the moment, it can load image sequences into tracks, reorder them, and playback the project. One image sequence plays back at around 22 FPS on the first run, then at 35 FPS when reading from the source cache.
Prometheus automatically composites the tracks from top to bottom, just like an image editor.

Interface (not complete)
---------

-Menu bar: Might replace with a floating form like Office 2007 (Shouldn't look identical)
-Top Left Pane: Modifier Stack pane (Incomplete)
-Top Center pane: Sources(for video/audio) tab, Modifiers (NYI) tab, and Generators (Also NYI) tab
-Top Right Pane: Preview
-Bottom Pane: Track\Clip Editor
-Bottom-er Buttons: Playback controls

How To Use
----------

-Import a source clip by clicking the "Add Source" button
-Drag it onto the track/clip editor
-Drag the bottom half of the front of the clip to move it.
-Drag the top half of the front or back of the clip to crop it.

To Do (in no particular order)
------------------------------

-MAKE COMPOSITING / PLAYBACK FASTER (Help, please!)
-Video Importers:
-AVI
-MP4
-GIF
-Modifiers
-Rendering to AVI and PNG sequence
-Audio Clips
-Generator Clips
-Clip property window
-Limit preview FPS
-MEF Plugins
-Modifier Stack Panel
-Modifier Property Window
-Project File Serialization (completed without audio support)
-Cursor changing (Frustrating!!!!)
-Audio Playback

Notes
-----

-This is my first GitHub Project.
-The #Const s in frmMain.vb and frmMain.Designer.vb are for an Aero Glass implementation I've been working on, but it's terribly buggy, so develop with it off, please.
-Maybe more source formats could be used by convering them into a temp folder with ffdshow. (sounds easier and more promising than finding a .NET library for each.)
-Prometheus makes heavy use of my Xenon project, which is a set of cooler looking (IMHO) Windows Forms controls, and also is not perfect.