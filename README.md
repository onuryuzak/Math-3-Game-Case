# Math-3 Game - Mafia Match

![Game Demo](https://user-images.githubusercontent.com/9118702/226357099-4499b4d4-ec9c-4201-b712-4eba6c6a8f10.mp4)

## Overview

Math-3 Game is a Match-3 puzzle game built in Unity. The game features a grid-based board where players match and merge similar minions by dragging and dropping them to create chains and score points. The game utilizes a finite state machine architecture to manage game states and transitions.

## Game Mechanics

- **Grid-Based Gameplay**: The game is played on a customizable grid (default 5x5).
- **Drag and Drop**: Players can drag minions and drop them on empty cells.
- **Matching System**: Similar minions can be matched to create chains.
- **Merge Mechanics**: When 3 or more minions of the same type are adjacent, they merge together.
- **Level Progression**: The game features a level system that saves progress and offers increasing difficulty.

## Technical Implementation

### Architecture

The game is built using a component-based architecture with the following key systems:

1. **Finite State Machine (FSM)**: Manages game states and transitions between them.
2. **Object Pooling**: Efficiently manages the creation and reuse of game objects.
3. **Factory Pattern**: Creates game objects like cells and minions.
4. **Singleton Pattern**: Used for global managers like GameStateManager.
5. **Scriptable Objects**: Stores level configurations and game settings.

### Key Components

- **GameBoard**: Manages the grid, cell positions, and minion spawning.
- **Minions**: Game pieces that can be matched (Red, Blue, Green).
- **Cells**: Grid positions where minions can be placed.
- **GameStateManager**: Controls the overall game flow (play, win, game over).
- **LevelSystem**: Manages level progression and difficulty settings.

### Game States

The game uses a state machine to manage different states:

- **SetupState**: Initializes the game board and sets up initial minions.
- **IdleState**: Waits for player input.
- **DragItemState**: Handles dragging minions across the board.
- **MergeUIState**: Handles the UI and animations when minions are merged.

## Project Structure

```
Assets/
├── Art/              # Game art assets
├── Common/           # Common components and scenes
│   ├── 3rdAssets/    # Third-party assets
│   └── Scenes/       # Game scenes (Main, Level-1)
├── Dev/              # Main development assets
│   ├── Data/         # Game data assets
│   ├── Materials/    # Materials for game objects
│   ├── Prefabs/      # Prefab game objects
│   │   ├── Items/    # Game items (Cells, Minions)
│   │   ├── Logic/    # Logic components
│   │   └── UI/       # UI components
│   └── Scripts/      # Game scripts
│       ├── Core/     # Core game systems
│       ├── Events/   # Event system
│       ├── GameFSM/  # Finite state machine implementation
│       ├── LevelSystem/ # Level management
│       ├── Management/ # Game managers
│       └── UI/       # UI scripts
├── Plugins/          # Unity plugins
└── Resources/        # Runtime loadable resources
```

## Getting Started

### Prerequisites

- Unity 2020.3 or higher
- Basic knowledge of Unity editor

### Installation

1. Clone this repository
2. Open the project in Unity
3. Open the Main scene in `Assets/Common/Scenes/Main.unity`
4. Press Play to start the game

## How to Play

1. The game starts with a grid of cells populated with minions of different colors
2. Click and drag a minion to an empty cell
3. If the moved minion creates a match of 3 or more adjacent minions of the same color, they will merge
4. Continue matching minions to progress through levels

## Development

### Adding New Minion Types

1. Create a new prefab based on existing minion prefabs
2. Add it to the minion factories list in the GameBoard component
3. Update any relevant game logic to handle the new minion type

### Modifying Level Settings

Level settings can be adjusted through the LevelSystem scriptable objects found in the Data directory.

## License

This project is proprietary software. All rights reserved.

