﻿﻿<h1 align="center">Kirei</h1><div align="center">

<h4 align="center">Enhance your Wallpaper Engine experience even more!</h4>

[![forthebadge](https://forthebadge.com/images/badges/made-with-c-sharp.svg)](https://forthebadge.com)
[![forthebadge](https://forthebadge.com/images/badges/built-with-love.svg)](https://forthebadge.com)
[![forthebadge](https://forthebadge.com/images/badges/you-didnt-ask-for-this.svg)](https://forthebadge.com)

[![GitHub license](https://img.shields.io/github/license/LegendaryB/Kirei.svg?longCache=true&style=flat-square)](https://github.com/LegendaryB/Kirei/blob/master/LICENSE)
[![GitHub last commit](https://img.shields.io/github/last-commit/LegendaryB/Kirei.svg?longCache=true&style=flat-square)](https://github.com/LegendaryB/Kirei)
[![GitHub issues](https://img.shields.io/github/issues/LegendaryB/Kirei.svg?longCache=true&style=flat-square)](https://github.com/LegendaryB/Kirei/issues)

Kirei is a japanese word and means clean or neat.
<br>
<br>
<sub>Built with ❤︎ by Daniel Belz</sub>
</div><br>

## Configuration
The configuration resides in the same folder as the application. There is a file called `appsettings.json`.
```json
{
  "Application": {
    "ShouldRunOnStartup": true,
    "InactiveAfter": 0, // time period after which the actions are executed in seconds. default: 180s (3m)
    "InputPollingRate": 0 // polling rate for the input handler in milliseconds. default: 200ms
  },
  "Actions": {
    "HideDesktopIcons": true,
    "HideTaskBar": true,
    "HideApplicationWindows": true
  }  
}
```

## Use the application
1. Extract the folder and go into it.
2. Configure your settings in `appsettings.json`.
2. Execute the application.

## Contributing

__Contributions are always welcome!__  
When you send me a pull request with changes, improvements or bugfixes please make sure to use the pull request template. 
I want to have all information regarding the pull request at a glance.

## License

This project is licensed under the MIT license - see the [LICENSE](LICENSE) file for details
