

# Stat Checker
### ﻿﻿This tool for Dark Souls III allows you to monitor players in your game session, gathers some statistics and have some handy features.



﻿When program starts first time, it creates 2 files. *PlayerBase.txt* and *userconf.json*. *PlayerBase* just stores most of info about players you played recently. *userconf* stores program preferences.

#### **Functions**
Main function of this soft is tracking players stats, each player is shown in 1 of 5 columns. Columns changes their color, depends on the player team.
Here comes the description of the buttons:

- `Kill` button - this button kills people, if they were marked as cheaters.
- `Kick` button - this button can kick any player from session but only if you are host. 
- `KillAllMobs` button - this button kill all mobs in the location. If there are any hostile phantoms in your world, they'll be killed too, so use it careful.
- `Homeward to Bonfire` button - this button teleports you to the bonfire you last rested at or picked in a drop-down menu above.
- `Heal Me` button - this button heals your character. 
- `Kill Me` button - this button kills your character.
- `Stats` button - this button allows you to change your stats anywhere and with no restrictions. Alternative to Rosaria's stats relocation.
- `Heal All` button - this button heals and applies `Tears of Denial` to anyone in the world.
- `Auto-Revive` checkbox - you will revive if your character dies.
- `Auto-Kick` checkbox - it'll kick players with wrong stats automatically.
- `Covenants` checkbox - this checkbox makes covenants like *Watchdogs of Farron* and *Aldriches* invade you anywhere.
- `Ember` checkbox - shows, does your character has active embers effect or not, allows you to change that.
- `Mark` button - saves position on map.
- `Recall` button - teleports to the position, that saved with mark.
- `MapV` checkbox - shows or hides most of textures.
- `HighC` checkbox - shows or hides collision maps.
- `LowC` checkbox - shows or hides collision maps.
- `Reattach` button - this button attaches to the game process.

All buttons with icons just do the same action as their in-game items.

![alt text](https://files.dificen.to/index.php/s/oJ8HxY69nCyNBCR/preview) ![alt text](https://files.dificen.to/index.php/s/jDpYMHKs8PXF3oi/preview)



#### **Installation and usage**

1. Just unzip archive in preferable folder and launch Stat Checker.exe
2. If program was started before launching Dark Souls III, click `Reattach` button when the game is loaded
3. You can configure hotkeys in settings menu. Checking `Allow use everywhere` checkbox will allow hotkeys to be used regardless of whether the game is in focus or not

#### **Troubleshooting**

If program doesn't start, make sure that you:

- Have *Newtonsoft.Json.dll* in program folder
- Have [*.NET Framework 4.7.2*](https://support.microsoft.com/en-us/topic/microsoft-net-framework-4-7-2-web-installer-for-windows-dda5cddc-b85e-545d-8d4a-d213349b7775) installed
- Have permission to read/write to the folder where program is located

Also try to launch the program as Administrator

If doesn't helps, please do not hesitate to open an issue in a [github repo](https://github.com/goodboiiFalseGod/StatChecker/issues).

#### **Can this ban me?**

You won't be banned for using this soft.
