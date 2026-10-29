# Updating artgate

Updating takes a minute and never touches your game, your art or your artist's link.

## 1. See what's new

Open [What's new](../CHANGELOG.md). Every version lists **what you need to do** after updating,
usually one or two commands. Read the steps for every version newer than yours.

Your version:

```powershell
.\artgate.exe --version
```

## 2. Get the new program

Download it the same way as the first time ([Getting started, step 1](getting-started.md#1-get-artgate))
and replace the old file in your game's folder. Keep the name `artgate.exe` (Windows) or `artgate`
(macOS/Linux).

- **Windows:** if Windows asks, unblock the new file again (right-click → Properties → Unblock).
- **macOS:** run `chmod +x artgate` again, and allow it once in System Settings → Privacy & Security
  if macOS asks.
- **npm package:** `npm install --save-dev artgate@latest`.

Check that it worked:

```powershell
.\artgate.exe --version
```

## 3. Do what the notes say

Usually that's running `index` (so your game gets the latest helpers) and `publish` (so your
artist's page is current). Then commit as usual: the updated index is a normal change.

## When something goes wrong

Keep the old program for a moment (rename it to `artgate-old.exe`). If the new version causes
trouble, swap the files back and [tell us](troubleshooting.md#still-stuck).

## Hearing about new versions

New versions appear on the **[releases page](https://github.com/Mike-like/artgate-releases/releases)**,
with the same notes. To get an email for each one: open
[github.com/Mike-like/artgate-releases](https://github.com/Mike-like/artgate-releases) while signed
in to GitHub, click **Watch → Custom**, tick **Releases**, and **Apply**.
