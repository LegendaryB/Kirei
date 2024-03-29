﻿﻿﻿<h1 align="center">Kirei</h1><div align="center">

<h4 align="center">Enhance your Wallpaper Engine experience even more!</h4>

[![forthebadge](https://forthebadge.com/images/badges/made-with-c-sharp.svg)](https://forthebadge.com)
[![forthebadge](https://forthebadge.com/images/badges/built-with-love.svg)](https://forthebadge.com)
[![forthebadge](https://forthebadge.com/images/badges/you-didnt-ask-for-this.svg)](https://forthebadge.com)

[![GitHub license](https://img.shields.io/github/license/LegendaryB/Kirei.svg?longCache=true&style=flat-square)](https://github.com/LegendaryB/Kirei/blob/master/LICENSE)
[![Donate](https://img.shields.io/badge/Donate-PayPal-blue.svg)](https://paypal.me/alphadaniel)

Kirei is a japanese word and means clean or neat.
<br>
<br>
<sub>Built with ❤︎ by Daniel Belz</sub>
</div><br>

## Configuration
The `appsettings.json` file resides in the same folder as the application.
```json
{
  "Application": {
    "ShouldRunOnStartup": true,
    "InactiveAfter": 0,
    "InputPollingRate": 0
  },
  "Actions": {
    "PreventSleep": true,
    "HideDesktopIcons": true,
    "HideTaskBar": true,
    "HideApplicationWindows": true
  }  
}
```

|Property   |Description   |Default value   |
|---|---|---|
|InactiveAfter   |Time period after which the actions are executed in seconds.   |180 Seconds|
|InputPollingRate   |Polling rate for the input handler in milliseconds.   |200 Milliseconds|

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
