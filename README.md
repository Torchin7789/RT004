# RT004
Support for the ***NPGR004 (Photorealistic graphics)*** lecture. Summer semester 2024/2025.

## Project plan
Every `sNN-*` directory refers to one item of the lab plan
(see [row 2 of this table](https://docs.google.com/spreadsheets/d/1z7dicAiSr7U_-kgMnJnSRNH-OPHIabCPl8GcJCNzz-o/edit?usp=sharing))

More details will be provided in this repository. Checkpoint
information will be included in the associated step directories
(e.g. `s03-ch1-HDRimage` contains definition of the `Step 03` and `Checkpoint 1` as well).

Every `tNN-*` directory refers to one optional topic. You
should pick at least two topics for your individual ray-tracer
extensions.

## src
The src directory contains support files from the lecturer. The default
version uses `.NET 8.0`
(it goes well with [OpenTK.Mathematics 5.0-pre13](https://github.com/opentk/opentk/tree/opentk5.0)).

Select `.NET 8.0 (Long Term Support)` if creating a new project,
it works well on Windows, Linux and macOS.

We use `Visual Studio 2022`, the [Community](https://visualstudio.microsoft.com/vs/community/)
(free) version is good enough for all tasks. Linux users can use
[Visual Studio Code](https://code.visualstudio.com/), which is able to open
`.sln`, `.csproj` files and even the saved options from Visual Studio.

## Point table
See [this shared table](https://docs.google.com/spreadsheets/d/1z7dicAiSr7U_-kgMnJnSRNH-OPHIabCPl8GcJCNzz-o/edit?usp=sharing)
for current points. Check the dates of individual Checkpoints...

Contact me <pepca@cgg.mff.cuni.cz> for any suggestions, comments or
complaints.

## Your solution
Please place all your files in new directories located in [solution](solution).

The naming conventions in the standard Visual Studio project creation procedures
allow you to simply copy a [pilot task project](src/rt004) to the `solution` directory.
Rewrite the `README.md` which will be your default file for documentation!

Files and directories that should be copied from `src` to the `solution` directory:
```
rt004/
rt004/rt004.csproj
rt004/rt004.sln
rt004/Program.cs
rt004/Properties/
rt004/Properties/launchSettings.json
rt004/shared/
rt004/shared/placeholder
shared/
shared/FloatImage.cs
shared/Util.cs
```

Template for your documentation is [here](solution/README.md). Please
edit all the sections, you could include individual file sections for
your finished checkpoints and extensions.

## AI assistants
The use of **AI assistants (based on Large Language Models)** is not prohibited,
you can use them under two conditions:
1. you must **acknowledge** for each checkpoint that the AI assistant significantly
   helped you.
2. you must **document your use of the assistant**. For example, if you use
   ChatGPT, record the entire conversation and post a link to it.
   For more "built-in" assistants, you should write a verbal report of
   what the help looked like, how often (and how hard) you had to
   correct the machine-generated code - and if you used comments in
   the code, leave them in!

## GIT instructions
You will work in your own **private repositories**.
You could start from our shared repository and add your own code and
documentation as you solve individual checkpoints.

We recommend using one of the following platforms - there are more
detailed instructions for each of them. The only bigger difference
is in the 3rd step (granting permissions to a lab supervisor).

Although you will grant me access (and I will be notified by email),
you will need to **email me at least initially**! I need to associate
your name with your GIT account and email address.

### GitHub
1. You have to set up a new **private repository** yourself.
2. Connect it to
our shared GIT using `git remote`. The command might look like this
```bash
$ git remote add upstream https://github.com/pepcape/RT004.git
```
3. Finally, you have to give me permissions to access your private
repository, this is done using the **"Collaborator"** role.
Please invite me - https://github.com/pepcape.
4. If your GitHub username is a **nickname**, please email us with
your real name.

### GitLab (MFF UK server)
1. You have to set up a new **private repository** yourself.
2. Connect it to
our shared GIT using `git remote`. The command might look like this
```bash
$ git remote add upstream https://github.com/pepcape/RT004.git
```
3. Finally, you have to give me permissions to access your private
repository, this is done using the **"Reporter"** role.
Please invite me - https://gitlab.mff.cuni.cz/pelikan.

## Notes
* If anything doesn't work well in your **Linux/macOS environment**,
  you should write me (<pepca@cgg.mff.cuni.cz>) as soon as possible.
  Of course you could report positive experience in Linux/macOS as well.
* It seems like the `System.Numerics` library doesn't support fully the `double`
  types yet, so I'm going to use the lightweighted **`OpenTK.Mathematics`**
  library instead, distributed in [NuGet form](https://www.nuget.org/packages/OpenTK.Mathematics/5.0.0-pre.13)
* You can work in your repositories without major restrictions.
  The recommended location for your solution is the [solution](solution)
  directory.
* You can tag your **GIT history** (e.g. `Chk 1` etc.) for archiving your
  progress at the checkpoints. It is always a good idea to write me an email
  or mention me in the **commit message** (`@pepcape` on GitHub, `@pelikan` on
  GitLab)!
* With one exception ([s03-ch1-HDRimage](s03-ch1-HDRimage/README.md)) there is no
  need to use **branches to communicate with me**. Please keep your best
  working version in the **`main`** branch (of course, you can use branches for your
  temporary work states)
* I need to be able to **compile your projects** easily. Please keep your solution
  (`.sln`) and project files (`.csproj`) working all the time
* Use `$(ProjectDir)` as the start directory for your project -
  it is easier to reference input/config files in this case
* Put all your **input config (scene description) files** under GIT control,
  it helps other people (me) to test your project. Fill the text box
  `Debug -> rt004 Debug Properties -> Command line arguments` with reasonable
  values, as this item is also versioned
* Update your `README.md` file[s] frequently, preferably after each checkpoint,
  I'd like to see your progress
* For Markdown syntax, see pages:
  [Markdown syntax](https://docs.github.com/en/get-started/writing-on-github/getting-started-with-writing-and-formatting-on-github/basic-writing-and-formatting-syntax),
  [Another MarkDown page](https://www.markdownguide.org/),
  [Markdown Cheatsheet](https://github.com/adam-p/markdown-here/wiki/Markdown-Cheatsheet)
* **Visual Studio 2022** supports direct **MarkDown editing** with live
  result preview
* While both parsing and writing floating point numbers, use strictly
  **neutral/invariant culture** - no floating "commas" `3,14`,
  only "dots" `3.14`. Remember to force this on English operating systems,
  (use `CultureInfo.InvariantCulture`), your code has to work on Czech/Slovak
  OS as well...
* Update your repository clone from upstream (`git pull upstream main`) often,
  I'll update the original from time to time (small fixes in support files...)
