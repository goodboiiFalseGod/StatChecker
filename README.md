# Stat Checker

### Redesigned version of the program originally made by [goodboiiFalseGod](https://github.com/goodboiiFalseGod/).

#### **Changes:**

- Remade hotkeys and added a menu for easy customization
- Disabled sound notifications
- Unlocked `Kill` button. (Since the program detects only deviations of stats and levels, and it is not yet known way how to programmatically check whether the player is cheating or not, I decided to unlock the `kill` button. This means that the entire responsibility for identifying and punishing unfair players lies with the user.)
- Unlocked ability to use `KillAllMobs` button while phantoms are in your world. It means all hostile phantoms 'll die. (I decided to unlock this because people often forget to use it before summoning a friendly phantom.)
- Removed some buttons and added another
  - Removed `ShrineTp ` ,  `AddSouls` and `PontiffTp` buttons
  - Replaced `ApplyEffect` button with three (`Tears of denial`, `Dried Finger`,  `Ember`) buttons
  - Added `Seed of Giant Tree` button
  - Added `Auto-kick` checkbox (automatically kicks players with wrong stats)
- Added ability to teleport to any bonfire in the game
- Cosmetic improvements:  ![alt text](https://files.dificen.to/index.php/s/oJ8HxY69nCyNBCR/preview) ![alt text](https://files.dificen.to/index.php/s/jDpYMHKs8PXF3oi/preview)

**Installation and usage**

1. Just unzip archive in preferable folder and launch Stat Checker.exe
2. If program was started before launching Dark Souls III, click `Reattach` button when the game is loaded
3. You can configure hotkeys in settings menu. Checking `Allow use everywhere` checkbox will allow hotkeys to be used regardless of whether the game is in focus or not

**Troubleshooting:**

If program doesn't start, make sure that you:

- Have _Newtonsoft.Json.dll_ in program folder
- Have [_.NET Framework 4.7.2_](https://support.microsoft.com/en-us/topic/microsoft-net-framework-4-7-2-web-installer-for-windows-dda5cddc-b85e-545d-8d4a-d213349b7775) installed
- Have permission to write to the folder where program is located

Also try to launch the program as Administrator
