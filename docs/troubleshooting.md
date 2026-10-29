# Troubleshooting

When artgate stops with **"Can't run"** or **"Can't check"**, it hasn't changed anything. Find the
message below. The command names are shown as `artgate …`; artgate's own messages show them the way
your computer needs them.

## Starting artgate

**Nothing happens / a window flashes and closes**
You double-clicked artgate. It has no window of its own; open a terminal in your game's folder and
type the command ([Terminal basics](terminal-basics.md)).

**Windows: "artgate.exe is not recognized…" / "The term 'artgate' is not recognized"**
In PowerShell, a program in the current folder needs `.\` in front: `.\artgate.exe check`. Also make
sure the terminal is in the folder where `artgate.exe` is (the prompt shows the folder).

**Windows blocks the file or shows a warning**
artgate isn't code-signed yet. Right-click `artgate.exe` → Properties → tick **Unblock** → OK.

**macOS: "permission denied"**
Run `chmod +x artgate` once in that folder.

**macOS: "cannot be opened because the developer cannot be verified"**
System Settings → Privacy & Security → scroll down → **Open Anyway**, then run the command again.

## Settings and asset list

**`no artgate config found in … or above`**
artgate looks for `artgate.config.json` in the folder you're in and the folders above it. Either
you're in the wrong folder (check the path in the prompt), or the project isn't set up yet: run
`artgate init` there.

**`… is not valid JSON: … (line 7 column 33). Windows paths need forward slashes in JSON`**
Write paths as `"G:/My Drive/Art"`, not `"G:\My Drive\Art"`.

**`… is not valid JSON: … Look for a missing or extra comma …`**
Go to the line and column named in the message. Typical causes: a comma missing between two entries,
a comma after the last entry of a list, a missing `"`.

**`the manifest (art/manifest.json) has 2 mistake(s):`** followed by a list
Each line names the asset and what to fix, e.g. `asset ui/icon.png: width and height must be whole
numbers above 0`. See [The asset list](manifest.md).

**`the manifest …: "j", which isn't in "for"`** (or similar)
A placeholder like `{j}` in an entry with `for` doesn't match a variable of that `for`. The message
names the entry number.

## The inbox

**`no inbox found: pass --inbox, or create one of: …`**
artgate couldn't find the inbox. Set `inbox.folder` in the settings to your shared folder, or create
`art_inbox` in your project ([Sharing the inbox](inbox.md)).

**`the inbox G:/… (from …) does not exist`**
The path is set but the folder isn't there: a typo, the drive isn't connected, or Google Drive for
desktop isn't running.

**`The inbox is empty, nothing to check.`**
Nothing has been delivered yet. (The README, empty folders and `.gitkeep` files don't count.)

## Messages about delivered files

These come from `check`, `apply` and `watch`, and also appear on the artist's page with the same
wording. Only files marked `OK` are copied into the game; everything else stays in the inbox.

| Message | What happened | Fix |
|---|---|---|
| `is not in the asset list (check the name and folder). Did you mean …?` | No asset has this name in this folder. | Rename the file, or move it to the right folder. Often a typo; the suggestion names the closest matches. |
| `name must be spelled exactly '…'` | Right name, wrong upper/lower case. | Rename exactly as shown. |
| `is 60x64 px, expected 64x64 px` | Wrong size. | Export at the size listed. Sizes are fixed because the game is laid out around them. |
| `has no transparency (export as RGBA PNG)` | The PNG can't be transparent. | Export as PNG with transparency (RGBA / 32-bit). |
| `frame 6 without frame 5: frames must be numbered without gaps` | An animation frame is missing in between. | Add the missing frame, or renumber. |
| `frame numbers have no leading zeros: name it '…_4.png'` | `_04` instead of `_4`. | Rename as shown. |
| `wrong file type: expected PNG (.png)` | E.g. a `.jpg` or `.ogg` where a `.png`/`.wav` is listed. | Export in the type listed. |
| `is incomplete (the PNG ends early); wait for syncing …` | The file is still downloading in the shared folder, or the export broke. | Wait a moment and check again; if it stays, export again. |
| `is not a real PNG file` / `is a damaged PNG` / `is not a valid WAV file` | The file only has the right ending. | Export it again from the art program. |
| `identical to the file already in the game` (`SAME`) | Nothing new. | Nothing to do. |
| `SKIP … not an art or source file type` | E.g. a `.txt` note in the inbox. | Fine to leave; it's never copied. |

**`Art already in the game that needs fixing`** (from `status` or `check`)
Files already in your game break the rules of your asset list, e.g. `is 501x579 px, expected
500x578 px`. Fix them in the game folder, or have the artist deliver corrected files. Until then,
`status --require` counts those assets as not done, and the artist's page shows them as
"Fix needed".

## Publishing

**`can't reach https://… : check the connection and try again`**
No internet, or a firewall blocks the connection. artgate already retried twice.

**`Couldn't update the artist's page: …`** after `check` or `apply`
The check itself worked; only the page update failed. Run `artgate publish` once the connection is
back.

**`The old page no longer existed …, so this is a NEW link`**
The page was deleted on the server (after 90 days without a publish, or with `link --delete` from
another computer). artgate made a new one by itself; send the new link to your artist.

**`unknown project or wrong token`** (from `link`)
Same cause: the page is gone. Run `artgate publish` to get a new one.

**`too many requests` / `too many new projects`**
Wait a minute and try again.

**`This project isn't published yet.`**
`link` needs a page: run `artgate publish` first.

## Still stuck?

Run the command again with `--json` and include the output when you ask for help.
[Open an issue](https://github.com/Mike-like/artgate-releases/issues) with what you typed and what
artgate printed.
