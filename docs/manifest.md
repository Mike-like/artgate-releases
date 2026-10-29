# The asset list (manifest)

The manifest lists every image and sound your game needs. It's the one place that decides:

- which placeholders artgate draws, at which name and size;
- what the check accepts from your artist;
- what the artist's page and the inbox README show;
- what goes into your engine's index.

It lives in `art/manifest.json` (set by `manifest` in [the settings](config.md)). After changing it,
run `artgate placeholders`, `artgate index`, `artgate readme` and `artgate publish`.

## The shape of the file

```json
{
  "sections": {
    "characters": { "title": "Characters", "intro": "Seen from above, centred on the point that moves." },
    "ui": { "title": "Interface" }
  },
  "priorities": {
    "P1": "needed for the first playable",
    "P2": "can follow"
  },
  "assets": [
    { "path": "ui/icon_coin.png", "width": 32, "height": 32, "name": "Coin icon", "section": "ui", "priority": "P1" }
  ]
}
```

- **`sections`** group the assets on the artist's page, in this order, each with a title, an
  optional introduction and optional `defaults` (below).
- **`priorities`** are your own labels (`P1`, `launch`, `Phase A`…) with what they mean, in order of
  importance. The first one stands out on the page.
- **`assets`** is the list itself.

JSON is strict about punctuation: text in "double quotes", a comma between items but none after the
last one, and Windows paths written with forward slashes. If you get it wrong, artgate says where.

## One asset

| Field | Needed | What it means |
|---|---|---|
| `path` | yes | Where the file goes, inside your game's art folder, with forward slashes: `ui/icon_coin.png`. Lower case is recommended; it's also the name the artist must use. |
| `width`, `height` | for images | The exact size in pixels. The check refuses any other size. |
| `name` | yes | A human name for the page: "Coin icon". |
| `section` | yes | The key of one of your `sections`. |
| `priority` | yes | One of your `priorities`. |
| `notes` | no | Anything the artist should know: where it's used, style, size on screen. Simple HTML such as `<b>` or `<code>` works. |
| `frames` | for animations | Makes it an animation with this many frames (see below). |
| `alpha` | no | `false` for images that are fully painted and don't need transparency (backgrounds, panels, store art). By default every PNG must be able to be transparent. |
| `seconds` | for sounds | The longest the sound may be; shown to the artist. |
| `placeholder` | no | `false` for files artgate can't draw a placeholder for, e.g. a font (`.ttf`) or an `.ogg`. The check still accepts and checks the file. |
| `color` | no | The placeholder's colour as `[red, green, blue]` (0–255), e.g. `[90, 120, 200]`. The artist's page shows it as a small sample next to the name, so a colour can stand for a type or a team. |
| `kind`, `extra` | no | For custom placeholder drawings ([settings](config.md#placeholder-drawings)). |

### Animations

An animation is one PNG per frame, numbered from 0. Give it `frames` and a `path` **without**
`.png`:

```json
{ "path": "characters/hero_walk_down", "frames": 4, "width": 64, "height": 64,
  "name": "Hero · walk down", "section": "characters", "priority": "P1" }
```

The files are `characters/hero_walk_down_0.png` … `_3.png`. The artist may deliver **more** frames
(`_4.png`, `_5.png`, …) as long as the numbers have no gaps; the check accepts them and the index
picks them up.

### Sounds and other files

- Sounds: `"path": "sfx/coin.wav"` with `"seconds": 0.4`. Placeholders are short silent WAV files.
- Fonts, `.ogg` and other types: add `"placeholder": false`. The check makes sure the file really is
  that type.

## Settings shared by a whole section: `defaults`

When every asset of a section has the same size, kind or colour, write it once:

```json
"sections": {
  "coupons": {
    "title": "Coupons",
    "defaults": { "width": 500, "height": 578, "kind": "coupon" }
  }
}
```

Every asset in `coupons` now has that size and kind, unless it sets its own `width`, `height` or
`kind`. Anything except `path`, `name` and `section` can be a default.

## Many files at once: `for`

Most games need families of files: 16 wall tiles, every hero in every direction, a dozen icons.
Instead of writing each one, write one entry with `for`:

```json
{
  "for": { "i": "0..2" },
  "path": "terrain/floor_{i}.png", "width": 64, "height": 64,
  "name": "Floor {i+1}", "section": "terrain", "priority": "P1"
}
```

This makes three assets: `floor_0.png` ("Floor 1"), `floor_1.png` ("Floor 2"), `floor_2.png`
("Floor 3").

### What `for` can take

| Kind | Example | Gives |
|---|---|---|
| A range of numbers | `"i": "0..15"` | 0, 1, 2, … 15 |
| A list | `"dir": ["down", "up", "side"]` | down, up, side |
| Named entries with details | `"hero": { "knight": { "color": [90,120,200] }, "ranger": { "color": [80,160,90] } }` | knight, ranger, and `{hero.color}` reads their details |

Several variables make every combination, in the order written: `"hero"` × `"dir"` gives knight-down,
knight-up, knight-side, ranger-down, …

### Placeholders in the text

| Write | Gives (for `i` = 3, `hero` = "knight") |
|---|---|
| `{i}` | `3` |
| `{i:02}` | `03` (padded to 2 digits) |
| `{i+1}` | `4` |
| `{hero\|title}` | `Knight` (also `\|upper`, `\|lower`) |
| `{hero.color}` | the knight's `color` from its details |

A value that is *only* one placeholder keeps its type, so `"color": "{hero.color}"` gives the list
`[90, 120, 200]`, not text.

### A complete example

```json
{
  "for": {
    "hero": { "knight": { "color": [90, 120, 200] }, "ranger": { "color": [80, 160, 90] } },
    "dir": ["down", "up", "side"]
  },
  "path": "characters/{hero}/{hero}_walk_{dir}", "frames": 4, "width": 64, "height": 64,
  "name": "{hero|title} · walk {dir}", "section": "characters", "priority": "P1",
  "notes": "4 frames at 8 fps.", "color": "{hero.color}"
}
```

Six animations, 24 placeholder files, from one entry.

Different priorities per item work the same way: put `"priority": "P2"` into an item's details and
write `"priority": "{icon.priority}"`.

## For programmers: a TypeScript manifest

If you prefer real code (loops, helpers, shared constants), the manifest can be a TypeScript or
JavaScript file whose default export is the same object: set `"manifest": "art/manifest.ts"` in the
settings. Only `import type` from artgate is allowed in it, because the downloaded program loads the
file as it is. Node's own modules (`node:fs`, `node:path`) work.

### One list instead of two: build it from your game's data

If your game already lists its content (cards, coupons, enemies) in a data file, don't copy that
list into the manifest: let the manifest read it. Then a coupon added to the game is on the artist's
list with the next `publish`, and the two can't drift apart.

```ts
// art/manifest.ts
import type { Asset, Manifest } from "artgate";
import { readFileSync } from "node:fs";

const data = JSON.parse(readFileSync(new URL("../data/coupon_data.json", import.meta.url), "utf8"));

const manifest: Manifest = {
  sections: { coupons: { title: "Coupons", defaults: { width: 500, height: 578, kind: "coupon" } } },
  priorities: { P1: "first playable", P2: "later" },
  assets: data.coupons.map((c: { id: string; title: string; priority: string }): Asset => ({
    path: `coupons/coupon_${c.id}.png`,
    name: `${c.title} coupon`,
    section: "coupons",
    priority: c.priority,
  })),
};
export default manifest;
```

`new URL("../data/…", import.meta.url)` finds the file relative to the manifest, wherever you run
artgate from. Hand-written entries can sit next to the generated ones:
`assets: [...fromData, { path: "ui/logo.png", … }]`.

## When the list changes

- **New asset:** add it, then `placeholders` (draws only what's missing), `index`, `readme`, `publish`.
- **Different size:** change it, **delete the old placeholder file**, then `placeholders`. artgate
  never overwrites a file, so it won't redraw it by itself. Tell your artist first: the game is laid
  out around these sizes.
- **Removed asset:** delete it from the list and its file from the game; then `index`, `readme`,
  `publish`.
