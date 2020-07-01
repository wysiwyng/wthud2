# WtHud2
<a href="https://github.com/wysiwyng/wthud2/actions">
    <img src="https://github.com/wysiwyng/wthud2/workflows/pyinstaller-win-dev/badge.svg" alt="pyinstaller-win-dev">
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
    - Checkbox enables a variable
    - First text entry sets the display name in the HUD
    - Second text entry sets a unit shown behind the data value
    - Third text entry sets a format string for the data, see [here](https://docs.python.org/3/library/string.html#format-string-syntax)
6. Save your custom configuration with the ```Save Config``` button
7. Once a new battle starts, wthud tries to load a saved HUD configuration for the new aircraft. If none is found, the default configuration is loaded
8. Change HUD position using X and Y spinboxes on the bottom of the config GUI

## Advanced Usage
You can edit the HUD configurations manually, they are saved in a JSON format inside the [configs](configs) folder. You can also replace the default HUD by editing the corresponding [file](configs/default_hud.json).

## Implementation Details
War Thunder exposes craft telemetry data on a web interface at ```localhost:8111``` during air battles. This data can be looked at on a second screen in a quite awkward GUI. This project aims to make the presented information more useful by overlaying select telemetry data directly on the game window, similarly to the already present (but limited) data.

Data is collected from the in-game webserver and displayed on screen with a transparent, undecorated window. The data to be shown can be configured individually per aircraft, and is saved between sessions in json files residing inside the [configs](configs) folder.

## Usage Disclaimer
This tool is neither sponsored, endorsed or otherwise approved by Gaijin Entertainment. It merely presents readily available data in a comfortable manner. Use at your own risk, at the time of writing similar tools were more or less "tolerated" when asked about on Gaijin's forums. No liability will be held by the authors should this and similar tools be the reason for the ban or termination of your War Thunder account.

This tool was only properly tested with a handful of planes from the German tech tree. Other planes might be broken in this tool, please report your issue in the GitHub issues tab.

## Contributions
Pull Requests and issues are welcome, expect a slow response as this project is developed in the free time of volunteers.

## TODO / Future Features
- [ ] Position shown items individually
- [ ] Logging
- [ ] Extension interface for calculated telemetry data (WIP)

## License
This program is licensed under a GNU GPL v3 license, see [COPYING](COPYING) for details.
