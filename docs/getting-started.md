# Getting started

From download to the first link for your artist, in about 15 minutes. You'll type a handful of
short commands; if typing commands is new to you, read [Terminal basics](terminal-basics.md) first
(5 minutes).

The commands below are written for **Windows** (`.\artgate.exe …`). On **macOS** or Linux, type
`./artgate …` instead.

## What you need

- Your game project (Godot, Unity, Phaser/Vite, or any engine that loads PNG files).
- Later, for working with an artist: a folder you both can use, e.g. on Google Drive or Dropbox.
  For a first try you don't need it.

## 1. Get artgate

artgate is one file, about 90 MB. It needs nothing else installed.

1. Open **[the newest release](https://github.com/Mike-like/artgate-releases/releases/latest)** and
   download the file for your computer (under "Assets" at the bottom):
   - Windows: `artgate-windows-x64.exe`
   - Mac with Apple chip (M1 or newer): `artgate-macos-arm64`; older Intel Mac: `artgate-macos-x64`
   - Linux: `artgate-linux-x64`
2. Rename it to **`artgate.exe`** (Windows) or **`artgate`** (macOS/Linux).
3. Move it into your **game's project folder** (next to `project.godot`, the `Assets` folder, or
   `package.json`). artgate makes sure git ignores it, so it won't end up in your repository.

**macOS only:** in Terminal, in your game's folder, make the file runnable:

```bash
chmod +x artgate
```

artgate isn't signed yet, so your system may warn the first time:

- **Windows** blocks or warns: right-click `artgate.exe` → **Properties** → tick **Unblock** at the
  bottom → OK.
- **macOS** says it "cannot be opened because the developer cannot be verified": open **System
  Settings → Privacy & Security**, scroll down, click **Open Anyway** next to the artgate message,
  and run the command again.

> **JavaScript projects (Phaser, Vite…) with Node.js 24 or newer** can use the npm package instead:
> `npm install --save-dev artgate`, then write `npx artgate …` wherever this guide says
> `.\artgate.exe …`. *(The npm package isn't published yet.)*

## 2. Check that it runs

Open a terminal in your game's folder ([how](terminal-basics.md#open-a-terminal-in-your-games-folder))
and type:

```powershell
.\artgate.exe --version
```

You should see a version number such as `0.1.0`.

## 3. Set up artgate in your project

```powershell
.\artgate.exe init
```

artgate looks at your folder, recognises the engine and writes a few files. For a Godot project it
shows:

```
Set up artgate for a Godot project.
  wrote   artgate.config.json
  wrote   art/manifest.json
  wrote   art/.gdignore
  wrote   art_inbox/.gdignore
  wrote   .gitignore (+ art_inbox/, .artgate/, /artgate.exe, /artgate)
```

What these are:

| File | What it's for |
|---|---|
| `artgate.config.json` | Settings: where your game's art lives, where the inbox is, which engine. [Details](config.md) |
| `art/manifest.json` | **The list of every image and sound your game needs.** You'll edit this next. |
| `art_inbox/` | The *inbox*: where finished art arrives. For now a folder in your project; later a shared folder. |
| `.gitignore` | Keeps the inbox, artgate's own output and the artgate program out of git. |

`init` never overwrites a file that's already there, so running it twice is harmless.

**A project that already has art:** `init` looks for the PNGs you already have and uses their folder
(e.g. `Found 43 PNG files under assets/`). Replace the example in `art/manifest.json` with your real
assets **before** step 5, or the example's placeholders land in your art folder. Files that are
already there are never touched; `artgate status` checks them against your list.

## 4. Describe the art your game needs

Open `art/manifest.json` in any text editor (VS Code, Notepad, TextEdit…). It contains a small
example: a hero with three walking animations, three icons and a sound. Each entry is one asset:

```json
{
  "path": "ui/icon_coin.png",
  "width": 32, "height": 32,
  "name": "Coin icon",
  "section": "ui",
  "priority": "P1",
  "notes": "Shown at 16–24 points on a dark background."
}
```

- `path` is where the file goes inside your game's art folder (and what the artist names it).
- `width` and `height` are the exact size in pixels the game expects.
- `name`, `section`, `priority` and `notes` are for the artist's page.
- An **animation** has `"frames": 4` and a path without `.png`; the files are then
  `…_0.png`, `…_1.png`, … The artist may add more frames.

Replace the example with a few real assets of your game; three to five are plenty to start.
[The asset list](manifest.md) explains every field, and how one entry can describe many files at
once (all 16 wall tiles, every enemy in every direction).

Save the file, then check it:

```powershell
.\artgate.exe status
```

If something's wrong in the file, artgate says which entry and what to change. Otherwise you see
your assets counted per group and priority.

## 5. Draw the placeholders

```powershell
.\artgate.exe placeholders
```

```
Wrote 16 placeholders; 0 already existed. (assets/art/)
```

Every image now exists in your game, at its final name and size: a coloured box with its name,
size and frame number written on it. You can build your scenes, menus and animations against these
right away. When real art arrives, it replaces them with nothing to change in your game.

artgate never overwrites a file that's there, so real art is safe.

## 6. Let your engine know about the art

```powershell
.\artgate.exe index
```

```
Wrote scripts/art_index.gd: 15 images, 3 animations.
```

This writes a small file for your engine listing every image and how many frames each animation has.
Your game can use it to load the art. When the artist delivers *more* frames than you asked for,
the index includes them automatically. How to use it in Godot, Unity or Phaser:
[Engines](engines.md).

## 7. Prepare the inbox for your artist

For a first try, keep the inbox in your project (`art_inbox/`). To work with a real artist, create a
shared folder (Google Drive, Dropbox, OneDrive) and point artgate at it:
[Sharing the inbox](inbox.md) shows how.

Then put the rules and the folder layout into the inbox:

```powershell
.\artgate.exe readme
```

The inbox now has a `README.md` listing every file with its size and priority, and an empty folder
for each part of the game, so the artist knows exactly where everything goes.

## 8. Give your artist a link

```powershell
.\artgate.exe publish
```

```
Published for the first time. The link and its token are kept in your user folder, not in the project.
Published: 16 previews, 16 new.
Artist link: https://artgate.mbockel.workers.dev/p/…/
```

Send that link to your artist, together with [the guide for artists](for-artists.md). The page shows
every asset with its size, frames and notes, previews of what's in the game now, and later what needs
fixing. It works on phones too.

Want a PIN, a new link, or the page without previews? See [The artist's page](hosted-page.md).

## 9. When art arrives

Your artist drops finished files into the inbox. Check them:

```powershell
.\artgate.exe check
```

```
ERROR characters/Hero_walk_down_0.png: name must be spelled exactly 'hero_walk_down_0.png'
OK    ui/icon_coin.png: ready
ERROR ui/icon_heart.png: is 30x32 px, expected 32x32 px

1 ready, 0 unchanged, 2 with errors.
Nothing changed yet. Run `.\artgate.exe apply` to copy the files marked OK.
```

`check` changes nothing. When you're happy, copy the good files into your game:

```powershell
.\artgate.exe apply
```

Only files marked `OK` are copied; the others stay in the inbox until the artist fixes them. The
artist's page updates by itself after `check` and `apply`, including what needs fixing and why.

**Even easier:** leave this running while your artist works:

```powershell
.\artgate.exe watch
```

It checks whenever something changes in the inbox and updates the artist's page within seconds.
Press Ctrl+C to stop it. (`watch` never copies files into your game; that's always your `apply`.)

## 10. Commit

After `apply`, commit the new art files and the updated index like any other change. The inbox,
artgate's output folder and the artgate program are already ignored by git.

## Your everyday commands

| When | Command |
|---|---|
| The artist delivered something | `check`, then `apply` |
| While the artist is working | `watch` (leave it running) |
| You changed the asset list | `placeholders`, `index`, `readme`, then `publish` to update the artist's page |
| You want an overview | `status` |
| Before a release: is all P1 art in? | `status --require P1` |

All commands: [Commands](commands.md). Something unexpected: [Troubleshooting](troubleshooting.md).
