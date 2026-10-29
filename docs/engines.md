# Engines

`artgate init` recognises your engine and sets up the right defaults. In a project that already has
art, it uses the folder the art is in. `artgate index` writes an **index**: a small code file listing
every image of your asset list, the frame count of every animation, and which images are still
placeholders. (Other PNGs in the folder, such as backgrounds you made yourself, aren't listed.) Your game
loads art through it, so frames your artist adds later are picked up with no code change. `apply`
refreshes it automatically.

All engines share these rules:

- artgate only ever replaces the image file itself. Godot's `.import` files and Unity's `.meta`
  files next to your art are never touched, so every reference in your scenes and prefabs stays
  intact.
- After `apply`, commit the new art and the index like any other change.

## Godot 4

`init` sets:

- art folder `assets/art` (that's `res://assets/art`), index `scripts/art_index.gd`;
- a `.gdignore` in `art/` and in the inbox, so Godot doesn't import the manifest or your artist's
  drafts. (`readme` puts one into the inbox again if it's missing.)

The index is a class called `ArtIndex`, available everywhere in your scripts:

```gdscript
# One image
$Icon.texture = ArtIndex.texture("ui/icon_coin")

# An animation for an AnimatedSprite2D: one animation per path, 8 fps, looping
$Hero.sprite_frames = ArtIndex.sprite_frames(["characters/hero_walk_down", "characters/hero_walk_up"])
$Hero.play("characters/hero_walk_down")

# The frames themselves, e.g. for your own animation code
var frames: Array[Texture2D] = ArtIndex.frames("characters/hero_walk_down")

# Everything that exists
for key in ArtIndex.IMAGES: print(key)
print(ArtIndex.FRAMES["characters/hero_walk_down"])   # number of frames
if ArtIndex.has("ui/icon_coin"): pass                 # an image, or an animation by its base path

# What still needs real art: { "ui/icon_coin": "P1", … }
if ArtIndex.is_placeholder("characters/hero_walk_down"): pass   # any frame still a placeholder
if not OS.is_debug_build() and ArtIndex.PLACEHOLDERS.values().has("P1"):
	push_error("This release still contains P1 placeholders")
```

When files change on disk, Godot reimports them as soon as you switch back to the editor.

To try it: open `examples/godot-demo` from the artgate repository in Godot, after running
`placeholders` and `index` in that folder, and press Play.

## Unity

`init` sets:

- art folder `Assets/Resources/Art`, index `Assets/Scripts/ArtIndex.cs`;
- an editor script `Assets/Editor/ArtgateImport.cs` that imports the art as **sprites**, with the
  pixels-per-unit and filter from the settings (`index.sprites`). For pixel art set
  `"filter": "point"`. The inbox stays outside `Assets`, so Unity never imports drafts.

The index is a static class `ArtIndex`:

```csharp
// One image as a sprite
spriteRenderer.sprite = ArtIndex.LoadSprite("ui/icon_coin");

// Every frame of an animation, in order
Sprite[] frames = ArtIndex.LoadFrames("characters/hero_walk_down");

// Everything that exists
foreach (var key in ArtIndex.Images) Debug.Log(key);
int count = ArtIndex.Frames["characters/hero_walk_down"];
bool listed = ArtIndex.Has("ui/icon_coin");          // an image, or an animation by its base path

// What still needs real art: { "ui/icon_coin": "P1", … }
bool missing = ArtIndex.IsPlaceholder("characters/hero_walk_down");
foreach (var pair in ArtIndex.Placeholders) Debug.Log($"{pair.Key} ({pair.Value}) is still a placeholder");
```

`LoadSprite` and `LoadFrames` work because the art sits below a folder called `Resources`. If you
keep the art elsewhere, the index still lists everything, but you reference the sprites in the
editor as usual.

After changing the sprite settings, right-click the art folder in Unity → **Reimport**.

To try it: add `examples/unity-demo` in Unity Hub (after `placeholders` and `index` in that
folder), open it and press Play in any scene with a camera.

## Phaser / Vite (and other web games)

`init` sets art folder `public/assets` and index `src/art.gen.ts`:

```ts
import { ART_FRAMES, ART_IMAGES, ART_PLACEHOLDERS, hasArt, isPlaceholder } from "./art.gen";

// preload(): every image, keyed by its path
for (const key of ART_IMAGES) this.load.image(key, `assets/${key}.png`);

// create(): an animation from all frames that exist
const base = "characters/hero_walk_down";
this.anims.create({
  key: base,
  frames: Array.from({ length: ART_FRAMES[base] }, (_, i) => ({ key: `${base}_${i}` })),
  frameRate: 8,
  repeat: -1,
});

// What still needs real art: { "ui/icon_coin": "P1", … }
if (isPlaceholder(base)) console.warn(`${base} is still a placeholder`);
```

## Any other engine

With `"adapter": "json"`, the index is a plain JSON file your game or build tools can read:

```json
{
  "folder": "assets",
  "images": ["characters/hero_walk_down_0", "ui/icon_coin"],
  "frames": { "characters/hero_walk_down": 4 },
  "placeholders": { "ui/icon_coin": "P1" }
}
```
