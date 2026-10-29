# The artist's page: link, PIN, privacy

`artgate publish` puts your asset list online and prints a link for your artist. The page shows every
asset with its size, frames and notes, a preview of what's in the game now, what's done and what still
needs fixing. Your artist can also drop files onto it to check them before delivering
([guide for artists](for-artists.md)).

## Keeping it up to date

After the first `publish`, the page updates by itself whenever you run `check`, `apply` or `watch`
in that project on that computer. Run `publish` again after you change the asset list or the
settings. (`--no-publish` on `check`/`apply`/`watch` skips the update once.)

The artist reloads the page to see changes.

## The link

```powershell
.\artgate.exe link
```

shows the current link, whether it has a PIN, and when it was last updated.

Anyone with the link can open the page, so share it like a password: with your artist, not in
public. Search engines are told not to list it. The first `publish` reminds you of this.

**If a link got out**, make a new one. The old one stops working immediately:

```powershell
.\artgate.exe link --rotate
```

## A PIN

For extra protection, add a PIN. The artist enters it once per browser.

```powershell
.\artgate.exe link --pin 4711
```

Remove it again with `link --remove-pin`. Wrong PINs are limited to a few tries a minute.

## Without previews

If your art must not leave your computer at all (unannounced projects, strict contracts), publish
without images:

```powershell
.\artgate.exe publish --no-thumbs
```

To make that permanent, set `"publish": { "previews": false }` in [the settings](config.md). The
page then shows names, sizes, statuses and problems, but no pictures.

## What is stored, and for how long

The page is stored on artgate's server (Cloudflare):

- the asset list with your notes and page texts, file names and sizes, and the last check's results;
- small previews of what's in your game now (unless you publish with `--no-thumbs`), and short
  sounds up to 256 KB so the artist can listen to them.

The art itself, your project and your inbox are **never** uploaded. Previews are shrunk copies,
stored only for the page.

A page that hasn't been published for **90 days** is deleted automatically, with all its previews.
To delete it yourself right away:

```powershell
.\artgate.exe link --delete --yes
```

## Without artgate's server

The hosted page is a convenience, not a requirement. Everything else (placeholders, the check,
`apply`, the index) runs only on your computer. Two ways to work without the server:

- **A page file.** `artgate page` writes the same page as one HTML file, with previews and the
  pre-check built in. Put it into the shared inbox, e.g.
  `.\artgate.exe page --out "G:\My Drive\Game art\asset-list.html"`, and run it again after each
  `check`. Your artist downloads the file and opens it in a browser; it works offline. The downside:
  it's only as current as your last `page`.
- **Your own server.** The server is a small Cloudflare Worker that's part of artgate's repository
  (`worker/`). With a Cloudflare account you can run your own copy (a free plan is enough for a
  team) and set `"publish": { "server": "https://…" }` in the settings.

## Your token and other computers

The first `publish` creates a secret **token** that allows changing the page. artgate keeps it in your
user folder, never in the project:

- Windows: `%APPDATA%\artgate\links.json`
- macOS: `~/Library/Application Support/artgate/links.json`
- Linux: `~/.config/artgate/links.json`

So the page belongs to *this* project folder on *this* computer. To update the same page from another
computer, copy that file over, keeping the project at the same path. Otherwise publish there too and
send the new link.

For automated builds (CI): set the environment variables `ARTGATE_PROJECT` and `ARTGATE_TOKEN` (the
`id` and `token` from `links.json`) as secrets.
