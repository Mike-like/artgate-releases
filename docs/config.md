# Settings (`artgate.config.json`)

`artgate init` writes this file into your project. artgate finds it from the folder you run it in,
or any folder above. You'll mostly touch `inbox` and `page`; the rest `init` sets up for your engine.

A typical file (Godot):

```json
{
  "title": "Lantern Keep",
  "manifest": "art/manifest.json",
  "assets": "assets/art",
  "inbox": { "folder": "G:/My Drive/Lantern Keep art" },
  "index": { "adapter": "godot", "out": "scripts/art_index.gd" },
  "page": {
    "intro": "Every image and sound the game needs.",
    "meta": ["64 px tiles", "Top-down"],
    "contact": "mike@example.com"
  }
}
```

Paths can be relative to the folder of this file (`assets/art`) or full (`G:/My Drive/…`). **Always
use forward slashes `/`, also on Windows.** JSON treats a backslash as a special character.

## The basics

| Setting | What it is |
|---|---|
| `title` | Your game's name, shown on the page and in the inbox README. |
| `manifest` | Your [asset list](manifest.md), usually `art/manifest.json`. |
| `assets` | The folder your game loads its art from, e.g. `assets/art` (Godot), `Assets/Resources/Art` (Unity), `public/assets` (Vite). Placeholders and delivered art go here. |

## `inbox`: where the art arrives

| Setting | What it is |
|---|---|
| `folder` | The inbox folder: `art_inbox` (inside the project) or a full path to a shared folder, e.g. `G:/My Drive/Game art`. |
| `env` | The name of an environment variable that may hold the inbox path. Useful when every team member has the shared folder somewhere else. |
| `shortcut` | A Windows shortcut (`.lnk`) in the project that points to the inbox. Default: `art_inbox.lnk`. |

artgate uses the first of these that works: the `--inbox` option on the command, then the
environment variable, then `folder`, then the shortcut. [Sharing the inbox](inbox.md) shows a
Google Drive setup step by step.

## `index`: the file for your engine

| Setting | What it is |
|---|---|
| `adapter` | `godot`, `unity`, `vite` or `json`. |
| `out` | The file to write, e.g. `scripts/art_index.gd`. |
| `className` | Godot/Unity: the class name. Default `ArtIndex`. |
| `sprites` | Unity only: `{ "pixelsPerUnit": 100, "filter": "bilinear" }` also writes an editor script that imports the art as sprites. Use `"filter": "point"` for pixel art. |

What each engine gets and how to use it: [Engines](engines.md).

## `page`: the artist's page

Every text is Markdown: either written right here, or the name of a `.md` file next to the
settings (e.g. `"intro": "page/intro.md"`).

| Setting | What it is |
|---|---|
| `intro` | The first paragraph under the title. |
| `meta` | Short facts under the title: `["64 px tiles", "Portrait, phone first"]`. |
| `contact` | Who answers questions, shown at the bottom. |
| `before` | Blocks shown before the asset list, e.g. your style guide: `[{ "eyebrow": "Rules for every asset", "title": "General spec", "text": "page/spec.md" }]`. |
| `after` | Blocks shown after "How to deliver", e.g. extra tasks. Same shape as `before`. |
| `prompt` | A style prompt for image AIs, with a copy button: `{ "intro": "…", "text": "page/prompt.txt", "after": "…" }`. |
| `previewSize` | The largest size a frame is shown at on the page, in pixels. Default 96. |
| `out` | Where `artgate page` writes the page as a file. Default `.artgate/asset-list.html`. |

In page texts you can use simple HTML for layout: `<div class="card">` boxes,
`<div class="grid2">` to put boxes side by side, and colour samples:
`<span class="sw"><i style="background:#5a78c8"></i>Knight</span>`. Anything else (scripts,
images from other sites, …) is removed for safety.

## `readme`: the inbox README

| Setting | What it is |
|---|---|
| `intro` | Replaces the README's first paragraph. |
| `rules` | Extra rules, added after artgate's own: `["Sounds: WAV, mono, 44.1 kHz."]`. |
| `pageUrl` | A link to show in the README, e.g. your artist page link. |

## `publish`: the hosted page

| Setting | What it is |
|---|---|
| `previews` | `false` publishes the page without any images, so none of your art leaves your computer. |
| `server` | Only if you run your own artgate server. |

## Placeholder drawings

| Setting | What it is |
|---|---|
| `drawers` | A TypeScript/JavaScript file with your own placeholder drawings, e.g. wall tiles that show which neighbours they join. For programmers; see `examples/demo/art/drawers.ts`. An asset uses one with `"kind": "wall"`. |

A drawer is a function `(canvas, asset, frame, tools)`. `canvas` has `rect`, `circle`, `ring`,
`polygon`, `text`, `textWidth` and `shade`; `tools.box(canvas, asset, frame)` draws artgate's
standard placeholder (with name and size) first, if you only want to add to it. Only `import type`
works in this file.

## File types

| Setting | What it is |
|---|---|
| `types` | Replaces artgate's lists of file types: `art` (go into the game; default `.png .wav .ogg .ttf .otf .ico`), `source` (kept next to the art and never imported: `.psd`, `.aseprite`, `.kra`, …), `ignored` (file names synced folders add, like `desktop.ini`). Each list you give replaces the default list. |
