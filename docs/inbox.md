# Sharing the inbox with your artist

The **inbox** is a folder where your artist puts finished art. artgate checks what's there and
copies the good files into your game. Your artist never needs access to your project or repository.

Any folder you both see on your computers works: Google Drive, Dropbox, OneDrive, a network share.

## Google Drive (step by step)

1. **Install Google Drive for desktop** if you haven't. Your Drive then appears as a drive in
   Explorer (often `G:`) or under "Google Drive" in Finder.
2. **Create a folder** in your Drive, e.g. `My Drive/Lantern Keep art`.
3. **Share it with your artist:** right-click it on drive.google.com → Share → their email →
   **Editor**.
4. **Tell artgate where it is.** Find the folder in Explorer/Finder, copy its path (Explorer: click
   the address bar; Finder: right-click the folder while holding Option → "Copy … as Pathname"), and
   put it into `artgate.config.json`, **with forward slashes**:

   ```json
   "inbox": { "folder": "G:/My Drive/Lantern Keep art" }
   ```

5. **Fill the inbox:**

   ```powershell
   .\artgate.exe readme
   ```

   This puts a `README.md` (every file, size and priority) and one empty folder per part of the
   game into the shared folder, so your artist sees exactly where everything goes.

Your artist adds the shared folder to their own Drive (in "Shared with me": right-click → Organize →
**Add shortcut to Drive**) and works in it like in any folder.

**Dropbox and OneDrive** work the same way: share a folder, put its path into `inbox.folder`, run
`readme`.

## When each team member has the folder somewhere else

Leave `inbox.folder` out of the shared settings and let everyone set an environment variable instead.
`init` already names one in the settings, e.g. `"env": "LANTERN_KEEP_ART_INBOX"`:

- Windows: Start → "Edit environment variables for your account" → New → name
  `LANTERN_KEEP_ART_INBOX`, value `G:\My Drive\Lantern Keep art`. Open a new terminal afterwards.
- macOS: add `export LANTERN_KEEP_ART_INBOX="$HOME/Google Drive/My Drive/Lantern Keep art"` to the
  file `~/.zshrc`, then open a new Terminal window.

Or point a Windows shortcut at the folder, name it `art_inbox.lnk` and put it into your project
folder. artgate follows it.

For a single command, `--inbox` wins over everything:
`.\artgate.exe check --inbox "G:\My Drive\Lantern Keep art"`

## What artgate does and doesn't do in the inbox

- `check`, `apply` and `watch` **only read** the inbox. They never move, rename or delete your
  artist's files.
- Only `readme` writes there: the `README.md`, the empty folders, a `.gitkeep` in each empty folder
  so syncing keeps it, and for Godot projects a `.gdignore`.
- Files the artist keeps for themselves are fine: drafts named like `hero_walk_down_0_v2.png` or
  `…_vx.png`, source files (`.psd`, `.aseprite`, `.kra`, …) next to the PNG, and the files Windows and
  macOS add by themselves. They're never copied into the game.

## Syncing takes a moment

Synced folders fill up while files are still downloading. artgate notices a half-downloaded PNG and
reports "is incomplete … wait for syncing to finish". Run `check` again a little later, or let
`watch` do it: it looks again every 15 seconds.
