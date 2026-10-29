# What's new in artgate

Each version: what changed, and **what you need to do** after updating. How to update:
[Updating artgate](docs/updating.md). To see which version you have:
`.\artgate.exe --version` (Windows) or `./artgate --version` (macOS/Linux).

## 0.2.1 (2026-10-29)

### What you need to do

Nothing: replace the program and you're done.

### New place for downloads

artgate's downloads, documentation and issues are public now, at
**[github.com/Mike-like/artgate-releases](https://github.com/Mike-like/artgate-releases)**. Get new
versions there; to hear about them, click **Watch → Custom → Releases** on that page.

### Fixed

- **`status`'s table now agrees with the list below it.** Art that's in the game but needs fixing
  counted as plain "real art" in the table (`8/8`), while the list and `status --require` counted
  it as not done. The table now shows `8/8 (8 to fix)`.

## 0.2.0 (2026-10-29)

Mostly feedback from the first real project. Thank you!

### What you need to do

1. **Replace the program** with the new one ([how](docs/updating.md)) and check that
   `--version` shows `0.2.0`.
2. **Run `artgate status` once.** It now also checks the art that's *already in your game* against
   your asset list (see below). If it lists files, fix them in the game folder or ask your artist
   for corrected ones.
3. **Run `artgate index` once**, so your game's index gets the new helpers (`has()`,
   `is_placeholder()`, the placeholder list). `apply` does this from now on by itself.
4. **Run `artgate publish`** (or your next `check`/`apply`) so your artist's page shows the
   problems from step 2. The page itself is already updated on the server.
5. **If your build or CI uses `status --require`:** it now also fails while art in the game has
   the wrong size or no transparency. That's on purpose, but it may stop a build that passed before.

Nothing else changes: your settings, asset list, inbox and artist link all keep working.

### Fixed

- **Bold or other inline text in notes** (`<b>ADD</b> coupon`) no longer breaks the line on the
  artist's page.
- **Art already in the game is checked now.** Before, a 501×579 image where the list says 500×578
  counted as done without a word. `status` and `check` list such files, `status --require` counts
  them as not done, and the artist's page shows them as "Fix needed … (already in the game)".
- The comment in the generated index said it lists every image in the folder. It lists the images
  of your asset list (other PNGs, such as backgrounds you made yourself, aren't in it).

### New

- **Index helpers** in every engine: `has(key)` to ask whether an image or animation exists, and a
  list of what's still a placeholder, with its priority. A game can show missing art in a debug
  overlay, or refuse a release build while P1 placeholders remain, without running artgate.
  Godot: `ArtIndex.has()`, `ArtIndex.is_placeholder()`, `ArtIndex.PLACEHOLDERS`. Unity:
  `ArtIndex.Has()`, `ArtIndex.IsPlaceholder()`, `ArtIndex.Placeholders`. Vite: `hasArt()`,
  `isPlaceholder()`, `ART_PLACEHOLDERS`. ([Engines](docs/engines.md))
- **Defaults per section:** write a shared size, kind or colour once for a whole section instead
  of on every asset. ([The asset list](docs/manifest.md#settings-shared-by-a-whole-section-defaults))
- **Colour samples:** an asset's `color` now shows as a small sample next to its name on the
  artist's page.
- **One list instead of two:** the docs show how a TypeScript manifest builds the asset list from
  your game's own data file, so the two can't drift apart.
  ([How](docs/manifest.md#one-list-instead-of-two-build-it-from-your-games-data))
- **Custom placeholder drawings** get `canvas.textWidth()`, `canvas.shade()` and `tools.box()`
  (artgate's standard placeholder, to draw on top of). Existing drawers keep working.

### Better

- **`init` in a project that already has art** uses the folder the art is in, instead of
  suggesting a new one, and warns to replace the example list before drawing placeholders. It also
  creates the `art_inbox` folder for every engine.
- **The first `publish`** says who can see the page, and how to add a PIN or leave the images out.
- The docs explain how to work **without artgate's server**: the page as a file in your shared
  folder, or your own copy of the server.

## 0.1.0 (2026-10-17)

The first version: the asset list (manifest) with generators, placeholders, the inbox check and
`apply`, the inbox README, engine indexes for Godot, Unity, Phaser/Vite and JSON, the artist's page
with the in-browser check, publishing with link and PIN, `watch`, the release gate
`status --require`, and the user documentation.
