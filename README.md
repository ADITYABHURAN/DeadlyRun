# DeadlyRun

A Unity 3D zombie survival game where players must collect keys and escape through doors to progress through levels.

## Game Description

DeadlyRun is a level-based survival game where players navigate through zombie-infested environments. The objective is simple: find the key, reach the door, and escape to the next level.

## Gameplay

- **Collect the Key**: Find and collect the key in each level
- **Reach the Door**: Navigate to the door while avoiding obstacles
- **Progress**: Successfully opening the door with the key takes you to the next level
- **Survive**: Complete all levels to win the game

## Features

- Level progression system
- Key collection mechanics
- Door unlock system
- Menu controller for scene transitions
- Win/Lose scene support

## Scripts

### PlayerController.cs
Handles player interactions with keys and doors:
- Detects key collection
- Manages door opening when player has the key
- Loads next level scene

### MenuController.cs
Manages scene transitions:
- Press any key to start the game
- Used in menu, win, and lose scenes

## Setup Instructions

### Unity Version
- Built with Unity [Your Unity Version]

### How to Play
1. Clone this repository
2. Open the project in Unity
3. Open the main scene from `Assets/Scenes/`
4. Press Play in Unity Editor

### Build Settings
Make sure all level scenes are added to Build Settings:
1. Go to **File > Build Settings**
2. Add scenes in order:
   - MainMenu
   - Level1
   - Level2
   - (Additional levels)
   - WinScene
   - LoseScene

### GameObject Setup

#### Player
- Add `PlayerController` component
- Set `Next Level Name` to the next scene name
- Must have a Collider component

#### Key
- Add Collider component (Is Trigger: checked)
- Set Tag to "Key"

#### Door
- Add Collider component (Is Trigger: checked)
- Set Tag to "Door"

## Controls

[Add your control scheme here, e.g.:]
- WASD / Arrow Keys - Movement
- Mouse - Look around
- Space - Jump

## Assets Used

- AllSkyFree
- Colonial City LittlePack
- Mini Simple Characters Skeleton Demo
- Standard Assets
- TextMesh Pro

## Development

### Project Structure
```
Assets/
├── Scenes/           # Game scenes
├── Scripts/          # C# scripts
├── Sounds/          # Audio files
├── Fonts/           # Font assets
└── ...              # Other asset folders
```

## License

[Add your license here]

## Credits

Developed by [Your Name]

## Future Improvements

- [ ] Add zombie enemies
- [ ] Implement health system
- [ ] Add collectible items
- [ ] Create more levels
- [ ] Add sound effects and music
- [ ] Implement scoring system
