# Terminal basics

artgate is a program you run by typing short commands, like `artgate check`, in a terminal window.
If you've never done that, this page covers everything you need. Nothing here is specific to
artgate, and none of it can break anything.

## Open a terminal in your game's folder

You always run artgate **in your game's project folder** (the folder with `project.godot`, the
`Assets` folder, or `package.json`).

**Windows 11**

1. Open your game's folder in Explorer.
2. Right-click an empty spot in the folder → **Open in Terminal**.

A window opens with a line like `PS C:\Users\you\Games\MyGame>`. The path shows the folder you're in.
That window is PowerShell, Windows' built-in terminal.

(Windows 10: click into the Explorer address bar, type `powershell`, press Enter.)

**macOS**

1. Open the **Terminal** app (Spotlight: Cmd+Space, type "Terminal").
2. Type `cd ` (with a space after it), then drag your game's folder from Finder into the Terminal
   window and press Enter.

The line now ends with your folder's name.

## Run a command

Type the command and press **Enter**. artgate prints what it did and comes back to the prompt.

When the artgate program sits in your game's folder, you start it like this:

| | Windows (PowerShell) | macOS / Linux |
|---|---|---|
| Show the version | `.\artgate.exe --version` | `./artgate --version` |
| Check the inbox | `.\artgate.exe check` | `./artgate check` |

The `.\` (Windows) or `./` (macOS) at the start means "the program in this folder". The guides
write commands as `artgate check`; type them the way the table shows. artgate's own messages already
show the right form for your computer.

## Useful things to know

- **Tab completes names.** Type `.\art` and press Tab: Windows fills in `.\artgate.exe`. Works for
  folder and file names too.
- **Arrow up** brings back the last command, so you don't retype it.
- **Ctrl+C stops** a command that keeps running, like `artgate watch`. It never harms your files.
- **Copy and paste** work as usual in Windows Terminal (Ctrl+C with text selected copies;
  Ctrl+V pastes). On macOS: Cmd+C / Cmd+V.
- **Paths with spaces need quotes:** `--inbox "G:\My Drive\Game Art"`.
- **Red text or "Can't run"** means artgate stopped before changing anything. The message says why
  and what to do; [Troubleshooting](troubleshooting.md) lists them all.

## Don't double-click artgate

artgate has no window of its own. Double-clicking it flashes a black window that closes right away.
That's normal: open a terminal as described above and type the command.

## Optional: run `artgate` from any folder

If you'd rather type just `artgate check` instead of `.\artgate.exe check`, and keep one copy for
all your projects:

- **Windows:** put `artgate.exe` in a folder such as `C:\Tools`, then open Start → "Edit
  environment variables for your account" → select **Path** → Edit → New → `C:\Tools` → OK. Open a
  new terminal window afterwards.
- **macOS:** move `artgate` to `/usr/local/bin`. In Terminal, in the folder where `artgate` is:
  `sudo mkdir -p /usr/local/bin`, then `sudo mv artgate /usr/local/bin/` (enter your Mac password
  when asked; nothing shows while you type it).

This is optional. Keeping the program in the project folder works just as well.
