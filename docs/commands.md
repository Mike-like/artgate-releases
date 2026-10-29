# All commands

Run every command in your game's folder (or any folder below it). This page writes `artgate …`;
type it the way your computer needs it, e.g. `.\artgate.exe check` on Windows with the program in the
project folder ([Terminal basics](terminal-basics.md)).

| Command | What it does | Changes your game? |
|---|---|---|
| `init` | Sets artgate up in this folder: settings, an example asset list, `.gitignore` lines. | No (adds artgate files only) |
| `placeholders` | Draws a placeholder for every listed file that's missing. Never overwrites anything. | Adds missing files |
| `check` | Checks every file in the inbox and lists what's ready and what needs fixing. | No |
| `apply` | Like `check`, then copies the files marked OK into the game and refreshes the index. | Yes |
| `watch` | Runs `check` whenever the inbox changes and updates the artist's page. Stop with Ctrl+C. | No |
| `index` | Writes the index file for your engine. | Writes the index |
| `readme` | Writes the README and the folder layout into the inbox. | No |
| `page` | Writes the artist's page as a single HTML file (e.g. to email or put on your own site). | No |
| `publish` | Puts the artist's page online and prints the link. | No |
| `link` | Shows the link; manages PIN, new link and deletion (below). | No |
| `status` | Counts how many assets have real art, per group and priority, and lists art already in the game that breaks the rules (wrong size, no transparency…). | No |

## Options

| Option | Works with | What it does |
|---|---|---|
| `--inbox <folder>` | check, apply, watch, readme, page, publish | Use this inbox instead of the one in the settings. Put paths with spaces in quotes. |
| `--no-publish` | check, apply, watch | Don't update the artist's page this time. |
| `--no-thumbs` | publish, check, apply, watch | Publish without previews. |
| `--require <P1,…>` | status | Fails (see exit codes) while any asset of these priorities has no real art yet. Useful before a release. |
| `--engine <name>` | init | `godot`, `unity`, `vite` or `generic` instead of detecting it. |
| `--rotate` | link | Makes a new link; the old one stops working. |
| `--pin <pin>` / `--remove-pin` | link | Adds or removes a PIN (4 characters or more). |
| `--delete --yes` | link | Deletes the online page for good. |
| `--out <file>` | page | Write the HTML here. |
| `--config <file>` | all | Use this settings file. |
| `--json` | all | Machine-readable output, for scripts and CI. |
| `--help`, `--version` | | Help and version. |

## Results (exit codes)

For scripts and CI: every command ends with a code.

| Code | Meaning |
|---|---|
| 0 | All fine. |
| 1 | It ran, but some files have problems (`check`/`apply`), or `status --require` found missing art. |
| 2 | It couldn't run: no settings, no inbox, a mistake in the asset list. The message says why. |

## The release gate

Before a release, make sure every launch asset has real art:

```powershell
.\artgate.exe status --require P1
```

It lists what's still a placeholder, and art in the game that breaks the rules, and ends with code 1
until everything is in and correct, so a build script or CI can stop a release that would ship
placeholders or wrong-sized art.
