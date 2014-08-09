Prometheus
==========

About
-----

Prometheus is my attempt at a nonlinear video editor in VB.NET. (Please don't laugh.)
At the moment, it can load image sequences into tracks, reorder them, and playback the project. One image sequence plays back at around 22 FPS on the first run, then at 35 FPS when reading from the source cache.
Prometheus automatically composites the tracks from top to bottom, just like an image editor.

Interface (not complete)
---------

-Menu bar: Might replace with a floating form like Office 2007 (Shouldn't look identical) (Working on it now)
-Top Left Pane: Modifier Stack pane
-Top Center pane: Sources(for video/audio) tab, Modifiers tab, and Generators (Also NYI) tab
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

- MAKE COMPOSITING / PLAYBACK FASTER (Help, please!)
- Video Importers:
- AVI
- MP4
- GIF
- Modifiers (functional)
- Rendering to AVI and PNG sequence
- Audio Clips
- Generator Clips
- Limit preview FPS
- Modifier Stack Panel (completed)
- Modifier Property Window (completed)
- Project File Serialization (completed without audio support)
- Cursor changing (Frustrating!!!!)
- Pseudo-clipboard for clips
- Cooler main menu
- Context menu for clips with Remove, Duplicate, Select Source, Open Location options
- Re-theme UI to match the menu somehow
- Add a video converter window via FFmpeg

Notes
-----

- This is my first GitHub Project.
- The #Const s in frmMain.vb and frmMain.Designer.vb are for an Aero Glass implementation I've been working on, but it's terribly buggy, so develop with it off, please.
- Maybe more source formats could be used by convering them into a temp folder with FFmpeg. (sounds easier and more promising than finding a .NET library for each.)
- Prometheus makes heavy use of my Xenon project, which is a set of cooler looking (IMHO) Windows Forms controls, and also is not perfect.