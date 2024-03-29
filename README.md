# WtHud2
<a href="https://github.com/wysiwyng/wthud2/actions">
    <img src="https://github.com/wysiwyng/wthud2/workflows/.NET%20msbuild%20Desktop/badge.svg" alt=".NET%20msbuild%20Desktop">
</a>

Head-up Display for additional War Thunder air battle data. Written in C#, uses data exposed by War Thunder on ```localhost:8111```. The shown data is configurable per aircraft. This is a continuation of my previous [HUD-for-War Thunder project](https://github.com/wysiwyng/wthud) using Windows Forms as a more appealing UI framework.

Compatible only with Windows! Transparency is handled by the window manager / compositor in most Linux distros, and is therefore neither easy nor portable to handle.

You need .Net Framework 4.7.2, which should already be installed on your machine.

## Installation (Development builds)
1. Download the latest zip package [here](https://github.com/wysiwyng/wthud2/releases/tag/latest) (chose the file ```wthud.zip```)
2. Unzip the package wherever
3. Run ```wthud2.exe```

## Installation (From source)
1. Clone / Download this repo
2. Open ```wthud2.sln``` with Visual Studio
3. Press ```F5``` to launch the debugger

## Usage
1. Complete installation as above
2. Configure War Thunder to run in either windowed or borderless mode
3. Join an air battle or start a test flight
4. All available telemetry data is loaded into the config screen once the match starts, also a basic minimal default HUD is loaded
5. For custom per-aircraft configuration, change the parameters in the config UI:
    - Enable a parameter by selecting it in the left list and pressing the right arrow button
    - Set description and unit in the right list
    - Format sets justification and significant digits, see [here](https://docs.microsoft.com/en-us/dotnet/standard/base-types/standard-numeric-format-strings)
6. Save your custom configuration with the ```Save``` button
7. Once a new battle starts, wthud tries to load a saved HUD configuration for the new aircraft. If none is found, the default configuration is loaded
8. Change HUD position using X and Y spinboxes on the bottom of the config GUI

If you want the actual font War Thunder uses for its HUD, you have to extract it from the game's files. Its name is "Default Normal", once you extract the font, install it on your system. You can then use the font within wthud in the font selection.

## Advanced Usage
You can edit the HUD configurations manually, they are saved in a JSON format inside the [WtHud2/configs](WtHud2/configs) folder. You can also replace the default HUD by editing the corresponding [file](WtHud2/configs/default_hud.json).

## Logging
Flight telemetry can be logged by enabling the feature in the config GUI. Logging can only be turned on or off inbetween matches. The log files are saved as ```<craft_name>_<hhmmss>_<yyMMdd>_log.dat``` inside the ```logs``` subfolder. Data is logged in a custom binary format optimized for space and speed. For details, see the [WtLogging](WtLogging) library. A very simple log viewer/converter is included as `LogViewer.exe` in the binary releases. The source code is located in [LogViewer](LogViewer). For better analysis, a CSV export is provided, be mindful that for long logs spreadsheet programs might have trouble opening very large files.

## Implementation Details
War Thunder exposes craft telemetry data on a web interface at ```localhost:8111``` during air battles. This data can be looked at on a second screen in a quite awkward GUI. This project aims to make the presented information more useful by overlaying select telemetry data directly on the game window, similarly to the already present (but limited) data.

Data is collected from the in-game webserver and displayed on screen with a transparent, undecorated window. The data to be shown can be configured individually per aircraft, and is saved between sessions in json files residing inside the [WtHud2/configs](WtHud2/configs) folder.

## Usage Disclaimer
This tool is neither sponsored, endorsed or otherwise approved by Gaijin Entertainment. It merely presents readily available data in a comfortable manner. Use at your own risk, at the time of writing similar tools were more or less "tolerated" when asked about on Gaijin's forums. No liability will be held by the authors should this and similar tools be the reason for the ban or termination of your War Thunder account.

This tool was only properly tested with a handful of planes from the German tech tree. Other planes might be broken in this tool, please report your issue in the GitHub issues tab.

## Contributions
Pull Requests and issues are welcome, expect a slow response as this project is developed in the free time of volunteers.

## TODO / Future Features
- [ ] Position shown items individually
- [x] Logging
- [ ] Extension interface for calculated telemetry data

## License
This program is licensed under a GNU GPL v3 license, see [COPYING](COPYING) for details.
