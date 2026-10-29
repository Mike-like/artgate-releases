# How delivery works: a guide for artists

You'll get **a link** and **a shared folder** from the game's developer. That's all you need, besides
your art program. You don't install anything.

## The link: your brief

The link opens a page with **every image and sound the game needs**:

- the exact **file name and folder** for each one;
- the exact **size in pixels**;
- for animations, the **number of frames**;
- **notes** from the developer: what it's for, where it appears, style hints;
- a **preview of what's in the game right now**: at first a coloured box with the name and size
  written on it (a *placeholder*), later your art;
- a **status** for each: *Placeholder* (still needed), *Art in* (done), *Fix needed*
  (something's wrong with what you delivered, and it says what), *Ready in inbox* (delivered and
  fine, waiting for the developer to take it in).

The menus at the top filter the list: by group, by priority, by status, or by searching a name.
**"Still needed for P1"** shows what's needed first. You can bookmark a filtered view. The page works
on your phone too.

If the page asks for a **PIN**, ask the developer for it. You enter it once per browser.

## The shared folder: where you deliver

The shared folder (on Google Drive, Dropbox…) is the **inbox**. It already contains a `README.md`
listing every file, and one folder for each part of the game.

To deliver, **save the finished file into the right folder with the exact name listed**. That's it.
You can deliver everything at once or a few files at a time.

Each delivery is checked automatically. Correct files go into the game; anything that needs fixing
shows up on the page with the reason. Fix it and save it again under the same name.

## The rules

1. **Exact size.** Use exactly the width and height listed. The game is built around these sizes;
   if one needs to change, ask first.
2. **PNG with transparency** (RGBA, sometimes called 32-bit PNG): everything not painted must be
   fully transparent. If an asset doesn't need transparency (a background, for example), its notes
   say so.
3. **Exact names, in lower case**, in the folder shown: `characters/hero_walk_down_0.png`, not
   `Characters/Hero walk down 0.png`.
4. **Animations: one PNG per frame, numbered from 0.** `hero_walk_down_0.png`, `hero_walk_down_1.png`,
   … The page shows these as `hero_walk_down_N.png`. More frames than asked for are welcome; just
   continue the numbers without gaps, and no leading zeros (`_4`, not `_04`).
5. **Drafts are fine in the folder**, as long as their name ends in a version: `hero_walk_down_0_v1.png`,
   `…_v2.png` or `…_vx.png`. They're never used; only the file with the exact name is.
6. **Keep your source files** (`.psd`, `.aseprite`, `.kra`, `.clip`, …) next to the PNG if you like,
   with the same name. They're never used in the game.

## Check your files before delivering

On the page, under **"Check your files"**, drop your files or a whole folder (or tap "Choose files"
on a phone). You get the same verdict the real check gives, right away. Your files are **not**
uploaded anywhere: the check runs in your browser.

It finds the right folder by itself when you drop a single file, so you can check work in progress
straight from your export folder.

## What the messages mean

| You see | What to do |
|---|---|
| *is not in the asset list … Did you mean …?* | The name or folder doesn't match. Use the suggested name. |
| *name must be spelled exactly '…'* | Same name, but upper/lower case differs. Rename as shown. |
| *is 60x64 px, expected 64x64 px* | Export at the size listed. |
| *has no transparency* | Export as PNG with transparency (RGBA). |
| *frame 6 without frame 5* | A frame is missing in the middle of an animation. |
| *frame numbers have no leading zeros* | Rename `_04` to `_4`. |
| *wrong file type* | Export as the type listed (usually PNG). |
| *is incomplete … wait for syncing* | The file is still uploading. Wait a moment; if it stays, export again. |
| *ready* / *OK* | All good. It goes into the game with the developer's next update. |

## Style prompts for image AIs

If the developer added one, the page has a **style prompt** with a copy button. Start every prompt
with it so the whole set looks consistent, then describe the single asset.
