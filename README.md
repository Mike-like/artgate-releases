# artgate

**Gets game art from your artist into your game, checked, without your artist ever touching your project.**

You list the art your game needs once. artgate then:

- **draws placeholders** for every image at its final size and name, so your game runs and you can build
  everything before any real art exists;
- gives your artist **one link** to an always-current page with every asset: size, frames, notes, what's
  already done, and what needs fixing;
- **checks every file** the artist drops into a shared folder (name, folder, size, transparency, frames)
  and copies only the good ones into your game, with a plain message for each problem;
- keeps your engine up to date with **an index of every image and animation**, so new frames the artist
  adds show up without code changes.

It works with **Godot, Unity, Phaser/Vite** and any engine that loads PNG files. Your artist only needs
their art program and a shared folder (Google Drive, Dropbox, OneDrive…).

```
 you                         artgate                              your artist
 ───                         ───────                              ───────────
 list the art  ───────────►  placeholders in the game
                             page with every asset  ───────────►  reads the brief, draws
                             checks the shared folder  ◄────────  drops files into the folder
 your game     ◄───────────  copies the good files
                             page shows what to fix  ───────────►  fixes and drops again
```

## Start here

- **[Getting started](docs/getting-started.md)**: from download to the first link for your artist, step
  by step. About 15 minutes.
- **[Terminal basics](docs/terminal-basics.md)**: if you rarely type commands, read this first.
  It's short.
- **[For your artist](docs/for-artists.md)**: send this to the person making your art.

## Reference

- [The asset list (manifest)](docs/manifest.md): describing your art, including many files at once
- [Settings (artgate.config.json)](docs/config.md)
- [Engines: Godot, Unity, Phaser/Vite, others](docs/engines.md)
- [Sharing the inbox with your artist](docs/inbox.md)
- [The artist's page: link, PIN, privacy](docs/hosted-page.md)
- [All commands](docs/commands.md)
- [Updating artgate](docs/updating.md) and [what's new](CHANGELOG.md)
- [Troubleshooting: messages and what to do](docs/troubleshooting.md)

## Status

Version 0.2, early: see [what's new](CHANGELOG.md). Works on Windows, macOS and Linux.
**Download:** [the newest release](https://github.com/Mike-like/artgate-releases/releases/latest).
Questions and problems:
[open an issue](https://github.com/Mike-like/artgate-releases/issues).
