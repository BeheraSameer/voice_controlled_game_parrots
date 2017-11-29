"git clone https://github.com/BeheraSameer/voice_controlled_game_parrots.git"

Make changes

"git pull --rebase"

"git commit <files changed>"

"git push origin master"


To view the UI integration commit changes:
1. Open Scenes/Human_Menu
2. Open File/Build Settings
3. Make sure "Scenes/Human_Menu 0" & "Scenes/Bird_Game 1" are displayed in the settings.
4. Play Scenes/Human_Menu.
  a. Start button takes you to the game.
  b. The bands are no more logarithmic, but linear.
  c. Game flashes yellow on a match and a red cross otherwise.
  d. To match frequency, look at the value of minIndex in the Console and generate a frequency = 3 * minIndex.

Use the Android App, i.e. Game.apk